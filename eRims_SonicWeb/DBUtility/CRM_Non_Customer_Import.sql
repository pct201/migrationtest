

if not exists(select PK_Security_ID from Security where [User_Name] = 'Import Process')
begin
	INSERT INTO Security(FIRST_NAME, LAST_NAME, USER_NAME) Values('Import','Process','Import Process')
end

EXEC sp_addlinkedserver @server ='ExcelSource',
   @srvproduct=N'ExcelData',
   @provider=N'Microsoft.ACE.OLEDB.12.0',
   @datasrc='D:\TestFiles\Non_Customer2.xlsx',
   @provstr=N'EXCEL 12.0'   
GO

--Set up login mappings.
EXEC sp_addlinkedsrvlogin 'ExcelSource', 'false', 'sa',NULL, NULL
GO
--List the tables in the linked server.
--EXEC sp_tables_ex ExcelSource
GO

DECLARE @Updated_By nvarchar(30)
SELECT TOP 1 @Updated_By = PK_Security_ID from Security where [User_Name] = 'Import Process'
SELECT ID = IDENTITY(INT,1,1),* INTO #TEMP FROM ExcelSource...[Non_Customer$]

DECLARE @MaxID numeric(20,0), @CurrID numeric(20,0)
SELECT @CurrID = 1
SELECT @MaxID = MAX(ID) FROM #TEMP 

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
WHILE @CurrID <= @MaxID
BEGIN
	
	BEGIN TRANSACTION
	DECLARE 
	 @PK_CRM_Non_Customer numeric(20, 0),  
	 @Record_Date datetime,  
	 @FK_LU_CRM_Source numeric(20, 0),  
	 @FK_LU_Location numeric(20, 0),  
	 @Company_Name nvarchar(50),  
	 @Last_Name nvarchar(50),  
	 @First_Name nvarchar(50),  
	 @City nvarchar(30),  
	 @FK_State numeric(20, 0),  
	 @Zip_Code nvarchar(10),  
	 @Email nvarchar(255),  
	 @Home_Telephone nvarchar(13),  
	 @Cell_Telephone nvarchar(13),  
	 @Work_Telephone nvarchar(13),  
	 @Work_Telephone_Extension nvarchar(10),  
	 @Comment_Call_Inquiry_Summary VARCHAR(8000),  
	 @Media_Call_Response_Summary VARCHAR(8000),  
	 @Action_Summary VARCHAR(8000),  
	 @FK_LU_CRM_Category numeric(20, 0),  
	 @Response_Sent nvarchar(1),  
	 @FK_LU_CRM_Response_Method numeric(20, 0),  
	 @Response_Date datetime,  
	 @Response_NA nvarchar(1),  
	 @Days_To_Close numeric(4, 0),  
	 @Update_Date datetime,
	 @strFK_LU_CRM_Source varchar(200),
	@strFK_LU_Location varchar(200),
	@strFK_State varchar(200),
	@strFK_LU_CRM_Category varchar(200),
	@strFK_LU_CRM_Response_Method varchar(200),
	@strNotes varchar(8000),
	@strResolution varchar(8000)
	
	SELECT 
	@PK_CRM_Non_Customer = CASE WHEN ISNUMERIC([Contact]) = 1 THEN CAST([Contact] AS NUMERIC(20,0)) ELSE NULL END,
	@Record_Date = CASE WHEN ISDATE([Date of Contact]) = 1 THEN CAST([Date of Contact] AS DATETIME) ELSE NULL END,
	@Company_Name =  LEFT(LTRIM(RTRIM([Address])), 50),
	@Last_Name =  LEFT(LTRIM(RTRIM([LastName])), 50),
	@First_Name =  LEFT(LTRIM(RTRIM([FirstName])), 50),
	@City =  LEFT(LTRIM(RTRIM([City])), 30),
	@Zip_Code =  CASE WHEN LEN(LEFT(LTRIM(RTRIM([Zip])), 10)) < 5 THEN NULL ELSE LEFT(LTRIM(RTRIM([Zip])), 10) END ,
	@Email =  LEFT(LTRIM(RTRIM([Email Address])), 255),
	@Home_Telephone =  LEFT(LTRIM(RTRIM([HomePhone])), 13),
	@Cell_Telephone =  LEFT(LTRIM(RTRIM([Cell Phone])), 13),
	@Work_Telephone =  LEFT(LTRIM(RTRIM([WorkPhone])), 13),
	@Work_Telephone_Extension =  LEFT(LTRIM(RTRIM([Ext])), 10),
	@Comment_Call_Inquiry_Summary = CAST([Type of Request] AS VARCHAR(8000)),
	@Media_Call_Response_Summary = NULL,
	@Action_Summary = NULL,
	@Response_Sent = CASE WHEN LTRIM(RTRIM([Response Sent])) IN ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@Response_Date = CASE WHEN ISDATE([Date of Response]) = 1 THEN CAST([Date of Response] AS DATETIME) ELSE NULL END,
	@Response_NA = CASE WHEN LTRIM(RTRIM([Response N/A])) IN ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@Days_To_Close = CASE WHEN ISNUMERIC([Days to Close]) = 1 THEN CAST([Days to Close] AS NUMERIC(20,0)) ELSE NULL END,
	@Update_Date = GETDATE(),
	@strFK_LU_CRM_Source = LTRIM(RTRIM([Source])),
	@strFK_LU_Location = NULL,
	@strFK_State = LTRIM(RTRIM([State])),
	@strFK_LU_CRM_Category = LTRIM(RTRIM([Category])),
	@strFK_LU_CRM_Response_Method = LTRIM(RTRIM([Method of Response])),
	@strNotes = CAST([Notes] as varchar(8000)),
	@strResolution = CAST([Resolution] AS VARCHAR(8000))
	FROM #TEMP WHERE ID = @CurrID
	
	set @Zip_Code = [dbo].[FormatZipForImport](@Zip_Code)
	set @Home_Telephone = [dbo].[fn_FormatPhoneForImport](@Home_Telephone) 
	set @Cell_Telephone = [dbo].[fn_FormatPhoneForImport](@Cell_Telephone)  
	set @Work_Telephone = [dbo].[fn_FormatPhoneForImport](@Work_Telephone)   
	set @Work_Telephone_Extension =  [dbo].[fn_FormatPhoneForImport](@Work_Telephone_Extension)   

	if(ISNULL(@strFK_LU_CRM_Source,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Source = PK_LU_CRM_Source FROM LU_CRM_Source WHERE Fld_Desc like '%' + @strFK_LU_CRM_Source + '%'
	if(ISNULL(@strFK_State,'') <> '') 
		SELECT TOP 1 @FK_State = PK_ID FROM [State] WHERE FLD_abbreviation like '%' + @strFK_State + '%'
	if(ISNULL(@strFK_LU_CRM_Category,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Category = PK_LU_CRM_Category FROM LU_CRM_Category WHERE Fld_Desc like '%' + @strFK_LU_CRM_Category + '%'	
	if(ISNULL(@strFK_LU_CRM_Response_Method,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Response_Method = PK_LU_CRM_Response_Method FROM LU_CRM_Response_Method WHERE Fld_Desc like '%' + @strFK_LU_CRM_Response_Method + '%'
	
	IF (ISNULL(@FK_LU_CRM_Source,0) = 0 and ISNULL(@strFK_LU_CRM_Source,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_Source VALUES (@strFK_LU_CRM_Source, 'N')	
		SELECT @FK_LU_CRM_Source = IDENT_CURRENT('LU_CRM_Source')
	END	
--	IF (ISNULL(@FK_State,0) = 0 and ISNULL(@strFK_State,'') <> '' and @strFK_State <> 'Email')
--	BEGIN
--		INSERT INTO State (FLD_state, FLD_abbreviation, Code) VALUES (@strFK_State, @strFK_State, @strFK_State)
--		SELECT @FK_State = IDENT_CURRENT('State')
--	END
	IF (ISNULL(@FK_LU_CRM_Response_Method,0) = 0 and ISNULL(@strFK_LU_CRM_Response_Method,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_Response_Method VALUES (@strFK_LU_CRM_Response_Method, 'N')
		SELECT @FK_LU_CRM_Response_Method = IDENT_CURRENT('LU_CRM_Response_Method')
	END
	IF (ISNULL(@FK_LU_CRM_Category,0) = 0 and ISNULL(@strFK_LU_CRM_Category,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_Category (Fld_Desc, Active) VALUES (@strFK_LU_CRM_Category, 'N')
		SELECT @FK_LU_CRM_Category = IDENT_CURRENT('LU_CRM_Category')
	END
	
	
	IF ISNULL((SELECT ISNULL(COUNT(1),0) FROM CRM_Non_Customer where PK_CRM_Non_Customer = @PK_CRM_Non_Customer),0) = 0
	BEGIN
		SET IDENTITY_INSERT [dbo].[CRM_Non_Customer] ON
		
		INSERT INTO [CRM_Non_Customer]
		(PK_CRM_Non_Customer, Record_Date, FK_LU_CRM_Source, FK_LU_Location, Company_Name, Last_Name, First_Name, City, FK_State, Zip_Code, Email, Home_Telephone, 
		Cell_Telephone, Work_Telephone, Work_Telephone_Extension, Comment_Call_Inquiry_Summary, Media_Call_Response_Summary, Action_Summary, FK_LU_CRM_Category, 
		Response_Sent, FK_LU_CRM_Response_Method, Response_Date, Response_NA, Days_To_Close, Update_Date, Updated_By)
		VALUES
		(@PK_CRM_Non_Customer, @Record_Date, @FK_LU_CRM_Source, @FK_LU_Location, @Company_Name, @Last_Name, @First_Name, @City, @FK_State, @Zip_Code, @Email, 
		@Home_Telephone, @Cell_Telephone, @Work_Telephone, @Work_Telephone_Extension, @Comment_Call_Inquiry_Summary, @Media_Call_Response_Summary, @Action_Summary, 
		@FK_LU_CRM_Category, @Response_Sent, case when @Response_Sent = 'Y' then @FK_LU_CRM_Response_Method else null end, 
		@Response_Date, @Response_NA, @Days_To_Close, @Update_Date, @Updated_By)
		
		SET IDENTITY_INSERT [dbo].[CRM_Non_Customer] OFF
		
		IF(LEN(@strNotes) > 0)
		BEGIN
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Non_Customer',@PK_CRM_Non_Customer, 3, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@strNotes, @Record_Date) AS tblNote
		END
		IF(LEN(@strResolution) > 0)
		BEGIN
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Non_Customer',@PK_CRM_Non_Customer, 4, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@strResolution, @Record_Date) AS tblNote
		END
	END
	ELSE
	BEGIN
		UPDATE  
		 [CRM_Non_Customer]  
		SET  
		 [Record_Date] = @Record_Date,  
		 [FK_LU_CRM_Source] = @FK_LU_CRM_Source,  
		 [FK_LU_Location] = @FK_LU_Location,  
		 [Company_Name] = @Company_Name,  
		 [Last_Name] = @Last_Name,  
		 [First_Name] = @First_Name,  
		 [City] = @City,  
		 [FK_State] = @FK_State,  
		 [Zip_Code] = @Zip_Code,  
		 [Email] = @Email,  
		 [Home_Telephone] = @Home_Telephone,  
		 [Cell_Telephone] = @Cell_Telephone,  
		 [Work_Telephone] = @Work_Telephone,  
		 [Work_Telephone_Extension] = @Work_Telephone_Extension,  
		 [Comment_Call_Inquiry_Summary] = @Comment_Call_Inquiry_Summary,  
		 [Media_Call_Response_Summary] = @Media_Call_Response_Summary,  
		 [Action_Summary] = @Action_Summary,  
		 [FK_LU_CRM_Category] = @FK_LU_CRM_Category,  
		 [Response_Sent] = @Response_Sent,  
		 [FK_LU_CRM_Response_Method] = case when @Response_Sent = 'Y' then @FK_LU_CRM_Response_Method else null end,  
		 [Response_Date] = @Response_Date,  
		 [Response_NA] = @Response_NA,  
		 [Days_To_Close] = @Days_To_Close,  
		 [Update_Date] = @Update_Date,  
		 [Updated_By] = @Updated_By  
		WHERE  
		  [PK_CRM_Non_Customer] = @PK_CRM_Non_Customer  
		
		IF(LEN(@strNotes) > 0)
		BEGIN
			DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Non_Customer' AND FK_Table_Name = @PK_CRM_Non_Customer AND FK_LU_CRM_Note_Type = 3
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Non_Customer',@PK_CRM_Non_Customer, 3, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@strNotes, @Record_Date) AS tblNote
		END
		IF(LEN(@strResolution) > 0)
		BEGIN
			DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Non_Customer' AND FK_Table_Name = @PK_CRM_Non_Customer AND FK_LU_CRM_Note_Type = 4
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Non_Customer',@PK_CRM_Non_Customer, 4, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@strResolution, @Record_Date) AS tblNote
		END
	END
	COMMIT TRANSACTION
	IF @@ERROR <> 0 
	BEGIN
		DROP TABLE #TEMP 
		ROLLBACK TRANSACTION
		PRINT 'Error Found for PK_Non_Customer : ' + cast(@PK_CRM_Non_Customer as varchar(20)) + char(13) + ltrim(rtrim(@@ERROR))
	END
	SET @CurrID = @CurrID + 1
END


DROP TABLE #TEMP 

SELECT 'CRM Non Customer : Total ' + cast(@CurrID - 1 as varchar(20)) + ' out of ' + cast(@MaxID as varchar(20)) + ' rows imported successfully'

GO

--sp_helpserver
--EXEC sp_tables_ex ExcelSource
EXEC sp_droplinkedsrvlogin 'ExcelSource','sa'
EXEC sp_dropserver 'ExcelSource'




