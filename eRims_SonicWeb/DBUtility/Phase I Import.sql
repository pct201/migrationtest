

BEGIN

SET NOCOUNT ON

DECLARE @PK_Enviro_Phase1_ID AS NUMERIC(20,0)
DECLARE @FK_LU_Location_ID AS NUMERIC(20,0)
DECLARE @ASSESSOR AS VARCHAR(50)
DECLARE @Phone AS VARCHAR(50)
DECLARE @Last_Date AS DATETIME
DECLARE @Cost AS NUMERIC(18,2)
DECLARE @Next_Date AS DATETIME
DECLARE @Next_Report_Date AS DATETIME
DECLARE @Description AS varchar(7999)
DECLARE @Updated_BY AS NVARCHAR(30)
DECLARE @Update_Date AS DATETIME
DECLARE @Notes AS varchar(7999)
DECLARE @PK_PM_Site_Information AS NUMERIC(20,0)
DECLARE @GUID AS uniqueidentifier


DECLARE Cursor_PhaseI_Import CURSOR FOR
 SELECT DISTINCT PK_Enviro_Phase1_ID,FK_LU_Location_ID,ASSESSOR,REPLACE(REPLACE(REPLACE(Phone,'-',''),')',''),'(',''),Last_Date,Cost,Next_Date,Next_Report_Date,
 cast(Description as varchar(7999)) as Description,Enviro_Phase1.Updated_BY,Enviro_Phase1.Update_Date,
 cast(Notes as varchar(7999)) as Notes   FROM Enviro_Phase1 
 Left Join Enviro_Recommendations ON Enviro_Phase1.PK_Enviro_Phase1_ID= Enviro_Recommendations.Foreign_Key and 
 Foreign_Table='Enviro_Phase1'
 
 OPEN Cursor_PhaseI_Import   
	FETCH NEXT FROM Cursor_PhaseI_Import INTO @PK_Enviro_Phase1_ID,@FK_LU_Location_ID,@ASSESSOR,@Phone,@Last_Date,@Cost,
	@Next_Date,@Next_Report_Date,@Description,@Updated_BY,@Update_Date,@Notes
	
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
			 
			 INSERT INTO PM_Phase_I VALUES(@PK_PM_Site_Information,@ASSESSOR,null,@Phone,@Last_Date,@Cost,@Next_Date,@Next_Report_Date,@Description,@Updated_BY,@Update_Date,@Notes)
			 DECLARE @PK_PM_Phase_I AS NUMERIC(20,0)
			 SELECT @PK_PM_Phase_I=IDENT_CURRENT('PM_Phase_I') 	 
			 IF(ISNULL(@PK_PM_Phase_I,0) > 0)
				BEGIN
					INSERT INTO PM_Phase_I_Attachments SELECT @PK_PM_Phase_I,CASE Enviro_Attachments.Type WHEN 'Document' THEN 1 WHEN 'Image' THEN 2 WHEN 'Note' THEN 3 ELSE null END,
					null,FILENAME,@Updated_BY,@Update_Date FROM Enviro_Attachments WHERE Foreign_Table='Enviro_Phase1' AND FOREIGN_KEY=@PK_Enviro_Phase1_ID
				END
			
			 FETCH NEXT FROM Cursor_PhaseI_Import INTO @PK_Enviro_Phase1_ID,@FK_LU_Location_ID,@ASSESSOR,@Phone,@Last_Date,@Cost,
			 @Next_Date,@Next_Report_Date,@Description,@Updated_BY,@Update_Date,@Notes
		END   

	CLOSE Cursor_PhaseI_Import   
	DEALLOCATE Cursor_PhaseI_Import 
 
 END