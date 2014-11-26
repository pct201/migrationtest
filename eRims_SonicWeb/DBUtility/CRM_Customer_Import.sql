

if not exists(select PK_Security_ID from Security where [User_Name] = 'Import Process')
begin
	INSERT INTO Security(FIRST_NAME, LAST_NAME, USER_NAME) Values('Import','Process','Import Process')
end

EXEC sp_addlinkedserver @server ='ExcelSource',
   @srvproduct=N'ExcelData',
   @provider=N'Microsoft.ACE.OLEDB.12.0',
   @datasrc='D:\TestFiles\Customer2.xlsx',
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
SELECT ID = IDENTITY(INT,1,1),* INTO #TEMP FROM ExcelSource...[Customer_Relations$] --ORDER BY [Complaint Number] 



DECLARE @PK_LU_Res_Note_Type numeric(20,0)
select @PK_LU_Res_Note_Type = PK_LU_CRM_Note_Type from Lu_CRM_Note_Type where FLD_Desc = 'Field Resolution Information'
DECLARE @MaxID numeric(20,0), @CurrID numeric(20,0)
SELECT @CurrID = 1
SELECT @MaxID = MAX(ID) FROM #TEMP 

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
WHILE @CurrID <= @MaxID
BEGIN
	
	BEGIN TRANSACTION
	DECLARE @PK_CRM_Customer numeric(20, 0),
	@Record_Date datetime,
	@FK_LU_CRM_Source numeric(20, 0),
	@Last_Name nvarchar(50),
	@First_Name nvarchar(50),
	@Address nvarchar(75),
	@City nvarchar(30),
	@FK_State numeric(20, 0),
	@Zip_Code nvarchar(10),
	@Email nvarchar(255),
	@Home_Telephone nvarchar(13),
	@Cell_Telephone nvarchar(13),
	@Work_Telephone nvarchar(13),
	@Work_Telephone_Extension nvarchar(10),
	@Summary varchar(8000),
	@FK_LU_CRM_Department numeric(20, 0),
	@FK_LU_CRM_Dept_Desc_Detail numeric(20, 0),
	@Service_Date datetime,
	@Service_Date_Est nvarchar(1),
	@FK_LU_Location numeric(20, 0),
	@FK_LU_CRM_Brand numeric(20, 0),
	@Model nvarchar(30),
	@Year numeric(4, 0),
	@FK_LU_CRM_Contacted_Resolution_2 numeric(20, 0),
	@FK_LU_CRM_Contacted_Resolution_1 numeric(20, 0),
	@Resolution_Manager nvarchar(50),
	@Resolution_Manager_Email nvarchar(255),
	@Customer_Contacted_GM nvarchar(1),
	@GM_Contact_Date datetime,
	@GM_Name nvarchar(50),
	@RVP_Contact_Date datetime,
	@FK_LU_CRM_RVP numeric(20, 0),
	@DFOD_Contact_Date datetime,
	@FK_LU_CRM_DFOD numeric(20, 0),
	@Other_Cotnact_Name nvarchar(50),
	@Legal_Attorney_General nvarchar(1),
	@FK_LU_CRM_Legal_Email numeric(20, 0),
	@Demand_Letter nvarchar(1),
	@Update_Date datetime,
	@Last_Action nvarchar(75),
	@Field_Resolution_Information varchar(8000),
	@Resolution_Summary varchar(8000),
	@Complete nvarchar(1),
	@Close_Date datetime,
	@Days_To_Close numeric(4, 0),
	@Customer_Callback_After_Resolution nvarchar(1),
	@Resolution_Letter_To_Customer nvarchar(1),
	@Date_Resolution_Letter_Sent datetime,
	@FK_LU_CRM_Response_Method numeric(20, 0),
	@Letter_NA nvarchar(1),
	@FK_LU_CRM_Letter_NA_Reason numeric(20, 0),
	@Letter_NA_Note varchar(8000),
	@strFK_LU_CRM_Source VARCHAR(100),
	@strFK_State VARCHAR(100),
	@strFK_LU_CRM_Department VARCHAR(100),
	@strFK_LU_CRM_Dept_Desc_Detail VARCHAR(100),
	@strFK_LU_Location VARCHAR(100),
	@strFK_LU_CRM_Brand VARCHAR(100),
	@strFK_LU_CRM_Contacted_Resolution_2 VARCHAR(100),
	@strFK_LU_CRM_Contacted_Resolution_1 VARCHAR(100),
	@strFK_LU_CRM_RVP VARCHAR(100),
	@strFK_LU_CRM_DFOD VARCHAR(100),
	@strFK_LU_CRM_Legal_Email VARCHAR(100),
	@strFK_LU_CRM_Response_Method VARCHAR(100),
	@strFK_LU_CRM_Letter_NA_Reason VARCHAR(100),
	@strComplaint varchar(8000),
	@strNotesFieldContact varchar(8000)
	
	select @FK_LU_CRM_Source = null, @FK_State = null,	@FK_LU_CRM_Department = null,@FK_LU_Location = null,
	@FK_LU_CRM_Brand = null,@FK_LU_CRM_Contacted_Resolution_2 = null,@FK_LU_CRM_Contacted_Resolution_1 = null,
	@FK_LU_CRM_RVP = null,@FK_LU_CRM_DFOD = null, @FK_LU_CRM_Legal_Email = null, @FK_LU_CRM_Response_Method = null, @FK_LU_CRM_Letter_NA_Reason = null

	SELECT 
	@PK_CRM_Customer = CASE WHEN ISNUMERIC([Complaint Number]) = 1 THEN CAST([Complaint Number] AS NUMERIC(20,0)) ELSE NULL END,
	@Record_Date = CASE WHEN ISDATE([Contact Date]) = 1 THEN CAST([Contact Date] AS DATETIME) ELSE NULL END,
	@Last_Name = LEFT(LTRIM(RTRIM([Last Name])), 50),
	@First_Name = LEFT(LTRIM(RTRIM([First Name])), 50),
	@Address = LEFT(LTRIM(RTRIM([Address])), 75),
	@City = LEFT(LTRIM(RTRIM([City])), 30),
	@Zip_Code = CASE WHEN LEN(LEFT(LTRIM(RTRIM([Zip])), 10)) < 5 THEN NULL ELSE LEFT(LTRIM(RTRIM([Zip])), 10) END ,
	@Email = LEFT(LTRIM(RTRIM([Email Address])), 255),
	@Home_Telephone = LEFT(LTRIM(RTRIM([Home Number])), 13),
	@Cell_Telephone = LEFT(LTRIM(RTRIM([Cell Number])), 13),
	@Work_Telephone = LEFT(LTRIM(RTRIM([Work Number])), 13),
	@Work_Telephone_Extension = LEFT(LTRIM(RTRIM([Ext])), 10),
	@Service_Date = CASE WHEN ISDATE([Date of Service]) = 1 THEN CAST([Date of Service] AS DATETIME) ELSE NULL END,
	@Service_Date_Est = CASE WHEN LTRIM(RTRIM([Est])) in ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@Model = LEFT(LTRIM(RTRIM([Model])), 30),
	@Year = CASE WHEN ISNUMERIC([Year]) = 1 THEN CAST([Year] AS NUMERIC(4,0)) ELSE NULL END,
	@Resolution_Manager = LEFT(LTRIM(RTRIM([Resolution Mgr Name])), 50),
	@Resolution_Manager_Email = NULL,
	@Customer_Contacted_GM = CASE WHEN LTRIM(RTRIM([Customer Contacted GM])) in ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@GM_Contact_Date = CASE WHEN ISDATE([Date of Contact GM]) = 1 THEN CAST([Date of Contact GM] AS DATETIME) ELSE NULL END,
	@GM_Name = LEFT(LTRIM(RTRIM([GM Name])), 50),
	@RVP_Contact_Date = CASE WHEN ISDATE([Date of Contact RVP]) = 1 THEN CAST([Date of Contact RVP] AS DATETIME) ELSE NULL END,
	@DFOD_Contact_Date = CASE WHEN ISDATE([Date of Contat RFOD]) = 1 THEN CAST([Date of Contat RFOD] AS DATETIME) ELSE NULL END,
	@Other_Cotnact_Name = NULL,
	@Legal_Attorney_General = CASE WHEN LTRIM(RTRIM([Legal/Atty General])) in ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@Demand_Letter = CASE WHEN LTRIM(RTRIM([Demand Letter])) in ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@Update_Date = CASE WHEN ISDATE([Last Update]) = 1 THEN CAST([Last Update] AS DATETIME) ELSE NULL END,
	@Last_Action = LEFT(LTRIM(RTRIM([Last Action])), 75),
	@Complete = CASE WHEN LTRIM(RTRIM([Complete])) in ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@Close_Date = CASE WHEN ISDATE([Close Date]) = 1 THEN CAST([Close Date] AS DATETIME) ELSE NULL END,
	@Days_To_Close = CASE WHEN ISNUMERIC([Days to Close]) = 1 THEN CAST([Days to Close] AS NUMERIC(4,0)) ELSE NULL END,
	@Customer_Callback_After_Resolution = CASE WHEN LTRIM(RTRIM([Cust Call Back after Resolved])) in ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@Resolution_Letter_To_Customer = CASE WHEN LTRIM(RTRIM([Resolution Letter to Cust])) in ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@Date_Resolution_Letter_Sent = CASE WHEN ISDATE([Date (ltr)]) = 1 THEN CAST([Date (ltr)] AS DATETIME) ELSE NULL END,
	@Letter_NA = CASE WHEN LTRIM(RTRIM([Letter N/A])) in ('TRUE','1','Yes') THEN 'Y' ELSE 'N' end,
	@strFK_LU_CRM_Source = LTRIM(RTRIM([Contact Method])),
	@strFK_State = LTRIM(RTRIM([St])),
	@strFK_LU_CRM_Department = LTRIM(RTRIM([Dept])),
	@strFK_LU_Location = LTRIM(RTRIM([Dealership Name])),
	@strFK_LU_CRM_Brand = LTRIM(RTRIM([Mftr])),
	@strFK_LU_CRM_Contacted_Resolution_2 = LTRIM(RTRIM([CRM Contact])),
	@strFK_LU_CRM_Contacted_Resolution_1 = LTRIM(RTRIM([Resolution Manager])),
	@strFK_LU_CRM_RVP = LTRIM(RTRIM([RVP Name])),
	@strFK_LU_CRM_DFOD = CASE WHEN LTRIM(RTRIM([RFOD Name])) <> '' AND LTRIM(RTRIM([RFOD])) <> '' THEN LTRIM(RTRIM([RFOD Name])) ELSE LTRIM(RTRIM([RFOD Name])) + LTRIM(RTRIM([RFOD])) END,
	@strFK_LU_CRM_Legal_Email = LTRIM(RTRIM([Additional Parties Contacted])),
	@strFK_LU_CRM_Response_Method = LTRIM(RTRIM([Sent By])),
	@strFK_LU_CRM_Letter_NA_Reason = LTRIM(RTRIM([Letter N/A Reason])),
	@Summary = CAST([Summary] AS VARCHAR(8000)),
	@Field_Resolution_Information = CAST([Field Resolution Info] AS VARCHAR(8000)),
	@Resolution_Summary = CAST([Res Summary] AS VARCHAR(8000)),
	@Letter_NA_Note = CAST([Ltr N/A Note] AS VARCHAR(8000)),
	@strComplaint = CAST([Complaint] AS VARCHAR(8000)),
	@strNotesFieldContact = CAST([Notes for Field Contact] AS VARCHAR(8000))
	FROM #TEMP WHERE ID = @CurrID
	
	set @strFK_LU_CRM_Department = replace(@strFK_LU_CRM_Department, 'F&I','F & I')
	set @strFK_LU_CRM_Department = replace(@strFK_LU_CRM_Department, 'Bodyshop','Body Shop')
	
	if(@PK_CRM_Customer > 0)
	BEGIN
	set @Zip_Code = [dbo].[FormatZipForImport](@Zip_Code)
	set @Home_Telephone = [dbo].[fn_FormatPhoneForImport](@Home_Telephone) 
	set @Cell_Telephone = [dbo].[fn_FormatPhoneForImport](@Cell_Telephone)  
	set @Work_Telephone = [dbo].[fn_FormatPhoneForImport](@Work_Telephone)   
	set @Work_Telephone_Extension =  [dbo].[fn_FormatPhoneForImport](@Work_Telephone_Extension)   
	
	if(ISNULL(@strFK_LU_CRM_Source,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Source = PK_LU_CRM_Source FROM LU_CRM_Source WHERE Fld_Desc like '%' + @strFK_LU_CRM_Source + '%'
	if(ISNULL(@strFK_State,'') <> '') 
		SELECT TOP 1 @FK_State = PK_ID FROM [State] WHERE FLD_abbreviation like '%' + @strFK_State + '%'
	if(ISNULL(@strFK_LU_CRM_Department,'') <> '') 		
		SELECT TOP 1 @FK_LU_CRM_Department = PK_LU_CRM_Department FROM LU_CRM_Department WHERE Fld_Desc like '%' + @strFK_LU_CRM_Department + '%'
	if(ISNULL(@strFK_LU_Location,'') <> '') 
		SELECT TOP 1 @FK_LU_Location = PK_LU_Location_ID FROM LU_Location WHERE dba like '%' + @strFK_LU_Location + '%'
	if(ISNULL(@strFK_LU_CRM_Brand,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Brand = PK_LU_CRM_Brand FROM LU_CRM_Brand WHERE Fld_Desc like '%' + @strFK_LU_CRM_Brand + '%'
	if(ISNULL(@strFK_LU_CRM_Contacted_Resolution_2,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Contacted_Resolution_2 = PK_LU_CRM_Contacted_Resolution FROM LU_CRM_Contacted_Resolution  WHERE Fld_Desc 
		like '%' + @strFK_LU_CRM_Contacted_Resolution_2 + '%'
	if(ISNULL(@strFK_LU_CRM_Contacted_Resolution_1,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Contacted_Resolution_1 = PK_LU_CRM_Contacted_Resolution FROM LU_CRM_Contacted_Resolution WHERE Fld_Desc 
		like '%' + @strFK_LU_CRM_Contacted_Resolution_1 + '%'
	if(ISNULL(@strFK_LU_CRM_RVP,'') <> '') 	
		SELECT TOP 1 @FK_LU_CRM_RVP = PK_LU_CRM_RVP FROM LU_CRM_RVP WHERE Fld_Desc like '%' + @strFK_LU_CRM_RVP + '%'
	if(ISNULL(@strFK_LU_CRM_DFOD,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_DFOD = PK_LU_CRM_DFOD FROM LU_CRM_DFOD WHERE Fld_Desc like '%' + @strFK_LU_CRM_DFOD + '%'
	if(ISNULL(@strFK_LU_CRM_Legal_Email,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Legal_Email = PK_LU_CRM_Legal_Email FROM LU_CRM_Legal_Email WHERE Recipients like '%' + @strFK_LU_CRM_Legal_Email + '%'
	if(ISNULL(@strFK_LU_CRM_Response_Method,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Response_Method = PK_LU_CRM_Response_Method FROM LU_CRM_Response_Method WHERE Fld_Desc like '%' + @strFK_LU_CRM_Response_Method + '%'
	if(ISNULL(@strFK_LU_CRM_Letter_NA_Reason,'') <> '') 
		SELECT TOP 1 @FK_LU_CRM_Letter_NA_Reason = PK_LU_CRM_Letter_NA_Reason FROM LU_CRM_Letter_NA_Reason WHERE Fld_Desc like '%' + @strFK_LU_CRM_Letter_NA_Reason + '%'
	
	IF (ISNULL(@FK_LU_CRM_Source,0) = 0 and ISNULL(@strFK_LU_CRM_Source,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_Source VALUES (cast(@strFK_LU_CRM_Source as varchar(25)), 'N')	
		SELECT @FK_LU_CRM_Source = IDENT_CURRENT('LU_CRM_Source')
	END
--	IF (ISNULL(@FK_State,0) = 0 and ISNULL(@strFK_State,'') <> '')
--	BEGIN
--		INSERT INTO State (FLD_state, FLD_abbreviation, Code) VALUES (@strFK_State, @strFK_State, @strFK_State)
--		SELECT @FK_State = IDENT_CURRENT('State')
--	END
	IF (ISNULL(@FK_LU_CRM_Department,0) = 0 and ISNULL(@strFK_LU_CRM_Department,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_Department VALUES (cast(@strFK_LU_CRM_Department as varchar(25)), 'N')
		SELECT @FK_LU_CRM_Department = IDENT_CURRENT('LU_CRM_Department')
	END	
	IF (ISNULL(@FK_LU_Location,0) = 0 and ISNULL(@strFK_LU_Location,'') <> '')
	BEGIN
		INSERT INTO LU_Location (dba, Active) VALUES (cast(@strFK_LU_Location as nvarchar(50)), 'N')
		SELECT @FK_LU_Location = IDENT_CURRENT('LU_Location')
	END
	IF (ISNULL(@FK_LU_CRM_Brand,0) = 0 and ISNULL(@strFK_LU_CRM_Brand,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_Brand VALUES (cast(@strFK_LU_CRM_Brand as varchar(25)), 'N')
		SELECT @FK_LU_CRM_Brand = IDENT_CURRENT('LU_CRM_Brand')
	END
	IF (ISNULL(@FK_LU_CRM_Contacted_Resolution_2,0) = 0 and ISNULL(@strFK_LU_CRM_Contacted_Resolution_2,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_Contacted_Resolution VALUES (cast(@strFK_LU_CRM_Contacted_Resolution_2 as varchar(25)), 'N')
		SELECT @FK_LU_CRM_Contacted_Resolution_2 = IDENT_CURRENT('LU_CRM_Contacted_Resolution')
	END
	IF (ISNULL(@FK_LU_CRM_Contacted_Resolution_1,0) = 0 and ISNULL(@strFK_LU_CRM_Contacted_Resolution_1,'') <> '')
	BEGIN	
		INSERT INTO LU_CRM_Contacted_Resolution VALUES (cast(@strFK_LU_CRM_Contacted_Resolution_1 as varchar(25)), 'N')
		SELECT @FK_LU_CRM_Contacted_Resolution_1 = IDENT_CURRENT('LU_CRM_Contacted_Resolution')
	END
	IF (ISNULL(@FK_LU_CRM_RVP,0) = 0 and ISNULL(@strFK_LU_CRM_RVP,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_RVP VALUES (cast(@strFK_LU_CRM_RVP as varchar(50)), 'N')
		SELECT @FK_LU_CRM_RVP = IDENT_CURRENT('LU_CRM_RVP')
	END
	IF (ISNULL(@FK_LU_CRM_DFOD,0) = 0 and ISNULL(@strFK_LU_CRM_DFOD,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_DFOD VALUES (cast(@strFK_LU_CRM_DFOD as varchar(50)), 'N')
		SELECT @FK_LU_CRM_DFOD = IDENT_CURRENT('LU_CRM_DFOD')
	END
	
	IF (ISNULL(@FK_LU_CRM_Response_Method,0) = 0 and ISNULL(@strFK_LU_CRM_Response_Method,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_Response_Method VALUES (cast(@strFK_LU_CRM_Response_Method as varchar(25)), 'N')
		SELECT @FK_LU_CRM_Response_Method = IDENT_CURRENT('LU_CRM_Response_Method')
	END
	IF (ISNULL(@FK_LU_CRM_Letter_NA_Reason,0) = 0 and ISNULL(@strFK_LU_CRM_Letter_NA_Reason,'') <> '')
	BEGIN
		INSERT INTO LU_CRM_Letter_NA_Reason VALUES (cast(@strFK_LU_CRM_Letter_NA_Reason as varchar(25)), 'N')
		SELECT @FK_LU_CRM_Letter_NA_Reason = IDENT_CURRENT('LU_CRM_Letter_NA_Reason')
	END
	
	
	
	
	IF ISNULL((SELECT ISNULL(COUNT(1),0) FROM CRM_Customer where PK_CRM_Customer = @PK_CRM_Customer),0) = 0
	BEGIN
		SET IDENTITY_INSERT [dbo].[CRM_Customer] ON
		INSERT INTO CRM_Customer
		(PK_CRM_Customer, Record_Date, FK_LU_CRM_Source, Last_Name, First_Name, Address, City, FK_State, Zip_Code, Email, Home_Telephone, 
		Cell_Telephone, Work_Telephone, Work_Telephone_Extension, Summary, FK_LU_CRM_Department, FK_LU_CRM_Dept_Desc_Detail, Service_Date,
		Service_Date_Est, FK_LU_Location, FK_LU_CRM_Brand, Model, Year, FK_LU_CRM_Contacted_Resolution_2, FK_LU_CRM_Contacted_Resolution_1, 
		Resolution_Manager, Resolution_Manager_Email, Customer_Contacted_GM, GM_Contact_Date, GM_Name, RVP_Contact_Date, FK_LU_CRM_RVP, 
		DFOD_Contact_Date, FK_LU_CRM_DFOD, Other_Cotnact_Name, Legal_Attorney_General, FK_LU_CRM_Legal_Email, Demand_Letter, User_Update_Date, 
		Last_Action, Field_Resolution_Information, Resolution_Summary, Complete, Close_Date, Days_To_Close, 
		Customer_Callback_After_Resolution, Resolution_Letter_To_Customer, Date_Resolution_Letter_Sent, FK_LU_CRM_Response_Method, 
		Letter_NA, FK_LU_CRM_Letter_NA_Reason, Letter_NA_Note,Update_Date,Updated_By)
		VALUES
		(@PK_CRM_Customer, @Record_Date, @FK_LU_CRM_Source, @Last_Name, @First_Name, @Address, @City, @FK_State, @Zip_Code, @Email, @Home_Telephone, 
		@Cell_Telephone, @Work_Telephone, @Work_Telephone_Extension, @Summary, @FK_LU_CRM_Department, @FK_LU_CRM_Dept_Desc_Detail, @Service_Date, 
		@Service_Date_Est, @FK_LU_Location, @FK_LU_CRM_Brand, @Model, @Year, @FK_LU_CRM_Contacted_Resolution_2, @FK_LU_CRM_Contacted_Resolution_1, 
		@Resolution_Manager, @Resolution_Manager_Email, @Customer_Contacted_GM, @GM_Contact_Date, @GM_Name, @RVP_Contact_Date, @FK_LU_CRM_RVP, 
		@DFOD_Contact_Date, @FK_LU_CRM_DFOD, @Other_Cotnact_Name, @Legal_Attorney_General, @FK_LU_CRM_Legal_Email, @Demand_Letter, @Update_Date, 
		@Last_Action, null , @Resolution_Summary, @Complete, @Close_Date, @Days_To_Close, 
		@Customer_Callback_After_Resolution, @Resolution_Letter_To_Customer, @Date_Resolution_Letter_Sent, 
		case when @Resolution_Letter_To_Customer = 'N' then null else @FK_LU_CRM_Response_Method end, 
		@Letter_NA, @FK_LU_CRM_Letter_NA_Reason, @Letter_NA_Note,@Update_Date,@Updated_By)
		SET IDENTITY_INSERT [dbo].[CRM_Customer] OFF
		
		IF(LEN(@strComplaint) > 0)
		BEGIN
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Customer',@PK_CRM_Customer, 1, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@strComplaint, @Record_Date) AS tblNote
		END
		IF(LEN(@strNotesFieldContact) > 0)
		BEGIN
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Customer',@PK_CRM_Customer, 2, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@strNotesFieldContact, @Record_Date) AS tblNote
		END
		IF(LEN(@Field_Resolution_Information) > 0)
		BEGIN
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Customer',@PK_CRM_Customer, @PK_LU_Res_Note_Type, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@Field_Resolution_Information, @Record_Date) AS tblNote
		END		
	END
	ELSE
	BEGIN
		UPDATE
			[CRM_Customer]
		SET
			[Record_Date] = @Record_Date,
			[FK_LU_CRM_Source] = @FK_LU_CRM_Source,
			[Last_Name] = @Last_Name,
			[First_Name] = @First_Name,
			[Address] = @Address,
			[City] = @City,
			[FK_State] = @FK_State,
			[Zip_Code] = @Zip_Code,
			[Email] = @Email,
			[Home_Telephone] = @Home_Telephone,
			[Cell_Telephone] = @Cell_Telephone,
			[Work_Telephone] = @Work_Telephone,
			[Work_Telephone_Extension] = @Work_Telephone_Extension,
			[Summary] = @Summary,
			[FK_LU_CRM_Department] = @FK_LU_CRM_Department,
			[FK_LU_CRM_Dept_Desc_Detail] = @FK_LU_CRM_Dept_Desc_Detail,
			[Service_Date] = @Service_Date,
			[Service_Date_Est] = @Service_Date_Est,
			[FK_LU_Location] = @FK_LU_Location,
			[FK_LU_CRM_Brand] = @FK_LU_CRM_Brand,
			[Model] = @Model,
			[Year] = @Year,
			[FK_LU_CRM_Contacted_Resolution_2] = @FK_LU_CRM_Contacted_Resolution_2,
			[FK_LU_CRM_Contacted_Resolution_1] = @FK_LU_CRM_Contacted_Resolution_1,
			[Resolution_Manager] = @Resolution_Manager,
			[Resolution_Manager_Email] = @Resolution_Manager_Email,
			[Customer_Contacted_GM] = @Customer_Contacted_GM,
			[GM_Contact_Date] = @GM_Contact_Date,
			[GM_Name] = @GM_Name,
			[RVP_Contact_Date] = @RVP_Contact_Date,
			[FK_LU_CRM_RVP] = @FK_LU_CRM_RVP,
			[DFOD_Contact_Date] = @DFOD_Contact_Date,
			[FK_LU_CRM_DFOD] = @FK_LU_CRM_DFOD,
			[Other_Cotnact_Name] = @Other_Cotnact_Name,
			[Legal_Attorney_General] = @Legal_Attorney_General,
			[FK_LU_CRM_Legal_Email] = @FK_LU_CRM_Legal_Email,
			[Demand_Letter] = @Demand_Letter,
			[User_Update_Date] = @Update_Date,
			[Update_Date] = @Update_Date,
			[Last_Action] = @Last_Action,
			[Field_Resolution_Information] = null,
			[Resolution_Summary] = @Resolution_Summary,
			[Complete] = @Complete,
			[Close_Date] = @Close_Date,
			[Days_To_Close] = @Days_To_Close,
			[Customer_Callback_After_Resolution] = @Customer_Callback_After_Resolution,
			[Resolution_Letter_To_Customer] = @Resolution_Letter_To_Customer,
			[Date_Resolution_Letter_Sent] = @Date_Resolution_Letter_Sent,
			[FK_LU_CRM_Response_Method] = @FK_LU_CRM_Response_Method,
			[Letter_NA] = @Letter_NA,
			[FK_LU_CRM_Letter_NA_Reason] = @FK_LU_CRM_Letter_NA_Reason,
			[Letter_NA_Note] = @Letter_NA_Note,
			[Updated_By] = @Updated_By
		WHERE
			 [PK_CRM_Customer] = @PK_CRM_Customer
			 
		IF(LEN(@strComplaint) > 0)
		BEGIN
			DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Customer' AND FK_Table_Name = @PK_CRM_Customer AND FK_LU_CRM_Note_Type = 1
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Customer',@PK_CRM_Customer, 1, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@strComplaint, @Record_Date) AS tblNote
		END
		IF(LEN(@strNotesFieldContact) > 0)
		BEGIN
			DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Customer' AND FK_Table_Name = @PK_CRM_Customer AND FK_LU_CRM_Note_Type = 2
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Customer',@PK_CRM_Customer, 2, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@strNotesFieldContact, @Record_Date) AS tblNote
		END
		IF(LEN(@Field_Resolution_Information) > 0)
		BEGIN
			DELETE FROM CRM_Notes WHERE Table_Name = 'CRM_Customer' AND FK_Table_Name = @PK_CRM_Customer AND FK_LU_CRM_Note_Type = @PK_LU_Res_Note_Type
			INSERT INTO CRM_Notes (Table_Name, FK_Table_Name, FK_LU_CRM_Note_Type, Note_Date, Note, Update_Date, Updated_By)
			SELECT 'CRM_Customer',@PK_CRM_Customer, @PK_LU_Res_Note_Type, tblNote.Note_Date, tblNote.Note, @Update_Date, @Updated_By
			FROM [dbo].[SelectImportNotes](@Field_Resolution_Information, @Record_Date) AS tblNote
		END		 
	END
	END
	COMMIT TRANSACTION
	IF @@ERROR <> 0 
	BEGIN
		DROP TABLE #TEMP 
		ROLLBACK TRANSACTION
		PRINT 'Error Found for PK_Customer : ' + cast(@PK_CRM_Customer as varchar(20)) + char(13) + ltrim(rtrim(@@ERROR))
	END	 
	SET @CurrID = @CurrID + 1
END


DROP TABLE #TEMP 

SELECT 'CRM Customer : Total ' + cast(@CurrID - 1 as varchar(20)) + ' out of ' + cast(@MaxID as varchar(20)) + ' rows imported successfully'

GO

--sp_helpserver
--EXEC sp_tables_ex ExcelSource
EXEC sp_droplinkedsrvlogin 'ExcelSource','sa'
EXEC sp_dropserver 'ExcelSource'




