
EXEC sp_addlinkedserver @server ='ExcelSource',
   @srvproduct=N'OLE DB Provider for Jet',
   @provider=N'Microsoft.Jet.OLEDB.4.0',
   @datasrc='D:\TestFiles\Customer_Relations.mdb'
   
GO

--Set up login mappings.
EXEC sp_addlinkedsrvlogin 'ExcelSource', 'false', 'sa',NULL, NULL
GO

DECLARE @Updated_By nvarchar(30)
SELECT TOP 1 @Updated_By = PK_Security_ID from Security where [User_Name] = 'Import Process'
DECLARE @MaxID numeric(20,0), @CurrID numeric(20,0)

/************** CRM_CUSTOMER IMPORT START ***********************************************/
SELECT ID = IDENTITY(INT,1,1),[Complaint Number],[Contact Date],[complaint], [notes for field contact],[field resolution info],
[Summary],[Last Action],[Res Summary]
INTO #TEMP FROM ExcelSource...[Customer Relations] where 
len(ltrim(rtrim(cast([complaint] as varchar(8000))))) >= 4000 or
len(ltrim(rtrim(cast([notes for field contact] as varchar(8000))))) >= 4000 or
len(ltrim(rtrim(cast([field resolution info] as varchar(8000))))) >= 4000 or
len(ltrim(rtrim(cast([summary] as varchar(8000))))) >= 4000 or
len(ltrim(rtrim(cast([last action] as varchar(8000))))) >= 4000 or
len(ltrim(rtrim(cast([res summary] as varchar(8000))))) >= 4000
order by [Complaint Number]
SELECT @CurrID = 1
SELECT @MaxID = MAX(ID) FROM #TEMP

DECLARE @PK_LU_Res_Note_Type numeric(20,0)
select @PK_LU_Res_Note_Type = PK_LU_CRM_Note_Type from Lu_CRM_Note_Type where FLD_Desc = 'Field Resolution Information'

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
WHILE @CurrID <= @MaxID
BEGIN
	BEGIN TRANSACTION
	
	DECLARE @PK_CRM_Customer numeric(20,0), @strComplaint VARCHAR(8000), @strNotesFieldContact VARCHAR(8000), @Record_Date datetime,
	@Field_Resolution_Information VARCHAR(8000), @Summary varchar(8000), @Last_Action varchar(8000), @Resolution_Summary varchar(8000)
	
	SELECT
	@PK_CRM_Customer = CASE WHEN ISNUMERIC([Complaint Number]) = 1 THEN CAST([Complaint Number] AS NUMERIC(20,0)) ELSE NULL END,	
	@Record_Date = CASE WHEN ISDATE([Contact Date]) = 1 THEN CAST([Contact Date] AS DATETIME) ELSE NULL END, 
	@strComplaint = ltrim(rtrim(cast([complaint] as varchar(8000)))), 
	@strNotesFieldContact = ltrim(rtrim(cast([notes for field contact] as varchar(8000)))), 
	@Field_Resolution_Information = ltrim(rtrim(cast([field resolution info] as varchar(8000)))),
	@Summary = ltrim(rtrim(cast([Summary] as varchar(8000)))),
	@Last_Action = ltrim(rtrim(cast([Last Action] as varchar(8000)))),
	@Resolution_Summary = ltrim(rtrim(cast([Res Summary] as varchar(8000))))
	FROM #TEMP WHERE ID = @CurrID
	
	UPDATE
		[CRM_Customer]
	SET
		[Summary] = @Summary,
		[Last_Action] = @Last_Action,
		[Resolution_Summary] = @Resolution_Summary
	WHERE [CRM_Customer].PK_CRM_Customer = @PK_CRM_Customer
	
	IF(LEN(@strComplaint) > 0)
	BEGIN
		DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Customer' AND FK_Table_Name = @PK_CRM_Customer AND FK_LU_CRM_Note_Type = 1
		INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
		SELECT 'CRM_Customer',@PK_CRM_Customer, 1, tblNote.Note_Date, tblNote.Note, getdate(), @Updated_By
		FROM [dbo].[SelectImportNotes](@strComplaint, @Record_Date) AS tblNote
	END
	IF(LEN(@strNotesFieldContact) > 0)
	BEGIN
		DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Customer' AND FK_Table_Name = @PK_CRM_Customer AND FK_LU_CRM_Note_Type = 2
		INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
		SELECT 'CRM_Customer',@PK_CRM_Customer, 2, tblNote.Note_Date, tblNote.Note, getdate(), @Updated_By
		FROM [dbo].[SelectImportNotes](@strNotesFieldContact, @Record_Date) AS tblNote
	END
	IF(LEN(@Field_Resolution_Information) > 0)
	BEGIN
		DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Customer' AND FK_Table_Name = @PK_CRM_Customer AND FK_LU_CRM_Note_Type = @PK_LU_Res_Note_Type
		INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
		SELECT 'CRM_Customer',@PK_CRM_Customer, @PK_LU_Res_Note_Type, tblNote.Note_Date, tblNote.Note, getdate(), @Updated_By
		FROM [dbo].[SelectImportNotes](@Field_Resolution_Information, @Record_Date) AS tblNote
	END
	COMMIT TRANSACTION
	IF @@ERROR <> 0 
	BEGIN
		DROP TABLE #TEMP 
		ROLLBACK TRANSACTION		
	END	 
	SET @CurrID = @CurrID + 1
END

DROP TABLE #TEMP
SELECT 'CRM Customer Records imported successfully'
/************** CRM_CUSTOMER IMPORT END ***********************************************/

/************** CRM_NON_CUSTOMER IMPORT START ***********************************************/
SELECT ID = IDENTITY(INT,1,1),[contact #],[Date of Contact],[notes],[resolution] INTO #TEMP1 FROM ExcelSource...[contacts - non customer]
WHERE
len(ltrim(rtrim(cast([notes] as varchar(8000))))) >= 4000 or
len(ltrim(rtrim(cast([resolution] as varchar(8000))))) >= 4000
order by [contact #]
SELECT @CurrID = 1
SELECT @MaxID = MAX(ID) FROM #TEMP1
WHILE @CurrID <= @MaxID
BEGIN
	BEGIN TRANSACTION
	DECLARE @PK_CRM_Non_Customer numeric(20, 0), @strNotes varchar(8000), @strResolution varchar(8000)
	SELECT 
	@PK_CRM_Non_Customer = CASE WHEN ISNUMERIC([contact #]) = 1 THEN CAST([contact #] AS NUMERIC(20,0)) ELSE NULL END,
	@Record_Date = CASE WHEN ISDATE([Date of Contact]) = 1 THEN CAST([Date of Contact] AS DATETIME) ELSE NULL END,
	@strNotes = CAST([Notes] as varchar(8000)),
	@strResolution = CAST([Resolution] AS VARCHAR(8000))
	FROM #TEMP1 WHERE ID = @CurrID
	
	IF(LEN(@strNotes) > 0)
	BEGIN
		DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Non_Customer' AND FK_Table_Name = @PK_CRM_Non_Customer AND FK_LU_CRM_Note_Type = 3
		INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
		SELECT 'CRM_Non_Customer',@PK_CRM_Non_Customer, 3, tblNote.Note_Date, tblNote.Note, getdate(), @Updated_By
		FROM [dbo].[SelectImportNotes](@strNotes, @Record_Date) AS tblNote
	END
	IF(LEN(@strResolution) > 0)
	BEGIN
		DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Non_Customer' AND FK_Table_Name = @PK_CRM_Non_Customer AND FK_LU_CRM_Note_Type = 4
		INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
		SELECT 'CRM_Non_Customer',@PK_CRM_Non_Customer, 4, tblNote.Note_Date, tblNote.Note, getdate(), @Updated_By
		FROM [dbo].[SelectImportNotes](@strResolution, @Record_Date) AS tblNote
	END
	
	COMMIT TRANSACTION
	IF @@ERROR <> 0 
	BEGIN
		DROP TABLE #TEMP1 
		ROLLBACK TRANSACTION		
	END	 
	SET @CurrID = @CurrID + 1
END

DROP TABLE #TEMP1
SELECT 'CRM Non Customer Records imported successfully'
/************** CRM_NON_CUSTOMER IMPORT END   ***********************************************/


GO

--sp_helpserver
--EXEC sp_tables_ex ExcelSource
EXEC sp_droplinkedsrvlogin 'ExcelSource','sa'
EXEC sp_dropserver 'ExcelSource'
