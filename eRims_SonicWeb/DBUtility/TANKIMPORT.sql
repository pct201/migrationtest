BEGIN

SET NOCOUNT ON

DECLARE @FK_LU_Location_Id int
DECLARE @PK_Enviro_Equipment_ID int
DECLARE @FK_PM_Site_Information numeric(20,0)
DECLARE @Type	NVarChar(50)
DECLARE @Identification	NVarChar(50)
DECLARE @Certificate_Number	NVarChar(50)
DECLARE @Installation_Date	DateTime
DECLARE @Date_of_Last_Service	DateTime
DECLARE @Status	NVarChar(50)
DECLARE @Last_Inspection_Date	DateTime
DECLARE @Closure_Date	DateTime
DECLARE @Removal_Date	DateTime	
DECLARE @Permit_Begin_Date	DateTime
DECLARE @Permit_End_Date	DateTime	
DECLARE @Registration_Required	nvarchar(1)	
DECLARE @Registration_Number	NVarChar(50)
DECLARE @Leak_Detection	nvarchar(1)	
DECLARE @Leak_Detection_Type NVarChar(50)
DECLARE @Overfill_Protection	nvarchar(1)
DECLARE @Plan_Id NVarChar(50)
DECLARE @Description	varchar(7999)	
DECLARE @Plan_Effective_Date DateTime
DECLARE @Plan_Expiration_Date	DateTime
DECLARE @Insurer	NVarChar(50)
DECLARE @Coverage_Start_Date DateTime
DECLARE @Coverage_End_Date	DateTime	
DECLARE @Multiple_Event_Total_Coverage	Decimal	(18,0)
DECLARE @Single_Event_Coverage	Decimal	(18,0)
DECLARE @Insurance_Company	NVarChar(50)
DECLARE @Inspection_Contact	NVarChar(50)
DECLARE @Inspection_Phone	NVarChar(50)
DECLARE @Notes	varchar(7999)
DECLARE @Updated_By	NVarChar(30)
DECLARE @Update_Date	DateTime	
DECLARE @Contents	NVarChar(50)
DECLARE @Contents_Other	NVarChar(50)
DECLARE @Capacity	Numeric	(18,2)
DECLARE @Material	NVarChar(50)
DECLARE @Material_Other	NVarChar(50)
DECLARE @Construction	NVarChar(50)
DECLARE @Construction_Other	NVarChar(50)
DECLARE @PK_PM_Site_Information AS NUMERIC(20,0)
DECLARE @GUID AS uniqueidentifier


DECLARE Enviro_Equipment_cursor CURSOR FOR
SELECT DISTINCT PK_Enviro_Equipment_ID,FK_LU_Location_Id,Enviro_Equipment.Type,Identification,Certificate_Number,
Installation_Date,Date_of_Last_Service,Status = CASE Enviro_Equipment.Status WHEN 'Active' THEN 'Y' ELSE 'N' END,
Last_Inspection_Date,Closure_Date,Removal_Date,
Permit_Begin_Date,Permit_End_Date,Registration_Required = CASE Registration_Required WHEN 1 THEN 'Y' ELSE 'N' END,
Registration_Number,Leak_Detection = CASE Leak_Detection WHEN 1 THEN 'Y' ELSE 'N' END,Leak_Detection_Type,
Overfill_Protection = CASE Overfill_Protection WHEN 1 THEN 'Y' ELSE 'N' END,Plan_Id,
CAST(ER.Description AS VARCHAR(7999)),Plan_Effective_Date,Plan_Expiration_Date,Insurer,
Coverage_Start_Date,Coverage_End_Date,Multiple_Event_Total_Coverage,Single_Event_Coverage,
Insurance_Company,Inspection_Contact,REPLACE(REPLACE(REPLACE(Inspection_Phone,'(',''),')',''),'-','') AS Inspection_Phone,
CAST(Notes AS VARCHAR(7999)) AS Notes,Enviro_Equipment.Updated_By,Enviro_Equipment.Update_Date,
Contents=CASE WHEN Contents IS NULL AND LEN(LTRIM(RTRIM(Contents)))=0 THEN NULL ELSE (SELECT PK_LU_Tank_Contents FROM LU_Tank_Contents WHERE Fld_Desc=Contents) END,
Contents_Other,Capacity,
Material=CASE WHEN Material IS NULL AND LEN(LTRIM(RTRIM(Material)))=0 THEN NULL ELSE (SELECT PK_LU_Tank_Material FROM LU_Tank_Material WHERE Fld_Desc=Material) END,Material_Other,
Construction=CASE WHEN Construction IS NULL AND LEN(LTRIM(RTRIM(Construction)))=0 THEN NULL ELSE (SELECT PK_LU_Tank_Construction FROM LU_Tank_Construction WHERE Fld_Desc=Construction) END,Construction_Other,
Enviro_Equipment.Updated_By,Enviro_Equipment.Update_Date
 FROM Enviro_Equipment
 LEFT JOIN Enviro_Recommendations ER ON ER.Foreign_Key = Enviro_Equipment.PK_Enviro_Equipment_Id AND ER.Foreign_Table = 'Enviro_Equipment'
WHERE Enviro_Equipment.Type LIKE '%tank%'


OPEN Enviro_Equipment_cursor
FETCH NEXT FROM Enviro_Equipment_cursor INTO @PK_Enviro_Equipment_ID,@FK_LU_Location_Id,@Type,@Identification,@Certificate_Number,
@Installation_Date,@Date_of_Last_Service,@Status,
@Last_Inspection_Date,@Closure_Date,@Removal_Date,
@Permit_Begin_Date,@Permit_End_Date,@Registration_Required,
@Registration_Number,@Leak_Detection,@Leak_Detection_Type,
@Overfill_Protection,@Plan_Id,
@Description,@Plan_Effective_Date,@Plan_Expiration_Date,@Insurer,
@Coverage_Start_Date,@Coverage_End_Date,@Multiple_Event_Total_Coverage,@Single_Event_Coverage,
@Insurance_Company,@Inspection_Contact,@Inspection_Phone,
@Notes,@Updated_By,@Update_Date,
@Contents,
@Contents_Other,@Capacity,
@Material,@Material_Other,
@Construction,@Construction_Other,
@Updated_By,@Update_Date

WHILE @@FETCH_STATUS = 0   
		BEGIN
			 SET @PK_PM_Site_Information=0
			 SELECT @PK_PM_Site_Information=ISNULL(PK_PM_Site_Information,0) FROM PM_Site_Information WHERE FK_LU_Location=@FK_LU_Location_ID
			 IF(ISNULL(@PK_PM_Site_Information,0)=0)	
				BEGIN
					SET @GUID=NEWID()
					INSERT INTO PM_Site_Information (FK_LU_Location,Updated_By,Update_Date,AuditID) VALUES(@FK_LU_Location_ID,@Updated_BY,@Update_Date,@GUID)
					SELECT @PK_PM_Site_Information=IDENT_CURRENT('PM_Site_Information')
				
					INSERT INTO PM_Compliance_Reporting (FK_PM_Site_Information,Updated_By,Update_Date,AuditID) VALUES(@PK_PM_Site_Information,@Updated_BY,@Update_Date,@GUID)	
					INSERT INTO PM_Remediation (FK_PM_Site_Information,Updated_By,Update_Date,AuditID) VALUES(@PK_PM_Site_Information,@Updated_BY,@Update_Date,@GUID)	
					INSERT INTO PM_Waste_Disposal (FK_PM_Site_Information,Updated_By,Update_Date,AuditID) VALUES(@PK_PM_Site_Information,@Updated_BY,@Update_Date,@GUID)	
					INSERT INTO PM_Audit_Inspections (FK_PM_Site_Information,Updated_By,Update_Date,AuditID) VALUES(@PK_PM_Site_Information,@Updated_BY,@Update_Date,@GUID)	
					INSERT INTO PM_Violation_Main (FK_PM_Site_Information,Updated_By,Update_Date,AuditID) VALUES(@PK_PM_Site_Information,@Updated_BY,@Update_Date,@GUID)						
				END	
			 
			 INSERT INTO PM_Equipment_Tank VALUES(@Type,NULL,@Identification,@Certificate_Number,@Installation_Date,NULL,@Date_of_Last_Service,NULL,@Status,@Last_Inspection_Date,@Closure_Date,@Removal_Date,NULL,@Permit_Begin_Date,@Permit_End_Date,@Registration_Required,@Registration_Number,@Leak_Detection,@Leak_Detection_Type,@Overfill_Protection,NULL,NULL,NULL,NULL,@Plan_Id,@Description,@Plan_Effective_Date,@Plan_Expiration_Date,NULL,NULL,NULL,NULL,NULL,@Insurer,@Coverage_Start_Date,@Coverage_End_Date,@Multiple_Event_Total_Coverage,@Single_Event_Coverage,@Insurance_Company,@Inspection_Contact,@Inspection_Phone,@Notes,@Contents,@Contents_Other,@Capacity,@Material,@Material_Other,@Construction,@Construction_Other,@Updated_By,@Update_Date)
			 DECLARE @PK_PM_Equipment_Tank AS NUMERIC(20,0)
			 SELECT @PK_PM_Equipment_Tank=IDENT_CURRENT('PM_Equipment_Tank') 	 
			 IF(ISNULL(@PK_PM_Equipment_Tank,0) > 0)
				BEGIN
					INSERT INTO PM_Equipment VALUES(@PK_PM_Site_Information,'PM_Equipment_Tank',@PK_PM_Equipment_Tank,1)
					INSERT INTO PM_Equipment_Attachments SELECT 'PM_Equipment_Tank',@PK_PM_Equipment_Tank,CASE Enviro_Attachments.Type WHEN 'Document' THEN 1 WHEN 'Image' THEN 2 WHEN 'Note' THEN 3 ELSE null END,
					null,FILENAME,@Updated_BY,@Update_Date FROM Enviro_Attachments WHERE Foreign_Table='Enviro_Equipment' AND FOREIGN_KEY=@PK_Enviro_Equipment_ID 
				END
			
			 FETCH NEXT FROM Enviro_Equipment_cursor INTO @PK_Enviro_Equipment_ID,@FK_LU_Location_Id,@Type,@Identification,@Certificate_Number,
				@Installation_Date,@Date_of_Last_Service,@Status,
				@Last_Inspection_Date,@Closure_Date,@Removal_Date,
				@Permit_Begin_Date,@Permit_End_Date,@Registration_Required,
				@Registration_Number,@Leak_Detection,@Leak_Detection_Type,
				@Overfill_Protection,@Plan_Id,
				@Description,@Plan_Effective_Date,@Plan_Expiration_Date,@Insurer,
				@Coverage_Start_Date,@Coverage_End_Date,@Multiple_Event_Total_Coverage,@Single_Event_Coverage,
				@Insurance_Company,@Inspection_Contact,@Inspection_Phone,
				@Notes,@Updated_By,@Update_Date,
				@Contents,
				@Contents_Other,@Capacity,
				@Material,@Material_Other,
				@Construction,@Construction_Other,
				@Updated_By,@Update_Date
		END   

	CLOSE Enviro_Equipment_cursor   
	DEALLOCATE Enviro_Equipment_cursor 
 
 END