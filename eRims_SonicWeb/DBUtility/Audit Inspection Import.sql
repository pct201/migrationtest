

BEGIN

SET NOCOUNT ON

DECLARE @PK_Enviro_Inspection_ID AS NUMERIC(20,0)
DECLARE @FK_LU_Location_ID AS NUMERIC(20,0)
DECLARE @Last_Date AS DATETIME
DECLARE @Next_Date AS DATETIME
DECLARE @Cost AS NUMERIC(20,2)
DECLARE @Next_Report_Date AS DATETIME
DECLARE @Description AS varchar(7999)
DECLARE @Updated_BY AS NVARCHAR(30)
DECLARE @Update_Date AS DATETIME
DECLARE @PK_PM_Site_Information AS NUMERIC(20,0)
DECLARE @GUID AS uniqueidentifier


DECLARE Cursor_Audit_Inspection_Import CURSOR FOR
 SELECT DISTINCT PK_Enviro_Inspection_ID,FK_LU_Location_ID,Last_Date,Next_Date,Cost,Next_Report_Date,cast(Description as varchar(7999)),
 Enviro_Inspection.Updated_BY,Enviro_Inspection.Update_Date  FROM Enviro_Inspection Left Join Enviro_Recommendations 
 ON Enviro_Inspection.PK_Enviro_Inspection_ID= Enviro_Recommendations.Foreign_Key and Foreign_Table='Enviro_Inspection'
 
 OPEN Cursor_Audit_Inspection_Import   
	FETCH NEXT FROM Cursor_Audit_Inspection_Import INTO @PK_Enviro_Inspection_ID,@FK_LU_Location_ID,@Last_Date,@Next_Date,
	@Cost,@Next_Report_Date,@Description,@Updated_BY,@Update_Date
	
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
			 
			 INSERT INTO PM_Frequency VALUES(@PK_PM_Site_Information,@Last_Date,@Next_Date,@Cost,NULL,@Next_Report_Date,@Description,@Updated_BY,@Update_Date,NULL)
			 DECLARE @PK_PM_Frequency AS NUMERIC(20,0)
			 SELECT @PK_PM_Frequency=IDENT_CURRENT('PM_Frequency') 	 
			 IF(ISNULL(@PK_PM_Frequency,0) > 0)
				BEGIN
					INSERT INTO PM_Frequency_Attachments SELECT @PK_PM_Frequency,CASE Enviro_Attachments.Type WHEN 'Document' THEN 1 WHEN 'Image' THEN 2 WHEN 'Note' THEN 3 ELSE null END,
					null,FILENAME,@Updated_BY,@Update_Date FROM Enviro_Attachments WHERE Foreign_Table='Enviro_Inspection' AND FOREIGN_KEY=@PK_Enviro_Inspection_ID 
				END
			
			 FETCH NEXT FROM Cursor_Audit_Inspection_Import INTO @PK_Enviro_Inspection_ID,@FK_LU_Location_ID,@Last_Date,@Next_Date,
			 @Cost,@Next_Report_Date,@Description,@Updated_BY,@Update_Date
		END   

	CLOSE Cursor_Audit_Inspection_Import   
	DEALLOCATE Cursor_Audit_Inspection_Import 
 
 END