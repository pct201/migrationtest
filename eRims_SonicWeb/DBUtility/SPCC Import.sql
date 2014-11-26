

BEGIN

SET NOCOUNT ON

DECLARE @PK_Enviro_SPCC_ID AS NUMERIC(20,0)
DECLARE @FK_LU_Location_ID AS NUMERIC(20,0)
DECLARE @Last_Date AS DATETIME
DECLARE @Next_Report_Date AS DATETIME
DECLARE @Notes AS varchar(7999)
DECLARE @Description AS varchar(7999)
DECLARE @Updated_BY AS NVARCHAR(30)
DECLARE @Update_Date AS DATETIME
DECLARE @PK_PM_Site_Information AS NUMERIC(20,0)
DECLARE @GUID AS uniqueidentifier
DECLARE @FK_LU_PERMIT_TYPE AS NUMERIC(20,0)

DECLARE Cursor_SPCC_Import CURSOR FOR
 SELECT DISTINCT PK_Enviro_SPCC_ID,FK_LU_Location_ID,Last_Date,Next_Report_Date,cast(Notes as varchar(7999)) as Notes,
 cast(Description as varchar(7999)) as Description,Enviro_SPCC.Updated_BY,Enviro_SPCC.Update_Date  FROM Enviro_SPCC 
 Left Join Enviro_Recommendations ON Enviro_SPCC.PK_Enviro_SPCC_ID= Enviro_Recommendations.Foreign_Key and 
 Foreign_Table='Enviro_SPCC'
 
 SELECT @FK_LU_PERMIT_TYPE=PK_LU_Permit_Type FROM LU_Permit_Type WHERE FLD_DESC='SPCC'
 
 OPEN Cursor_SPCC_Import   
	FETCH NEXT FROM Cursor_SPCC_Import INTO @PK_Enviro_SPCC_ID,@FK_LU_Location_ID,@Last_Date,@Next_Report_Date,@Notes,
	@Description,@Updated_BY,@Update_Date
	
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
			 
			 INSERT INTO PM_Permits VALUES(@PK_PM_Site_Information,@FK_LU_PERMIT_TYPE,'Y',null,null,@Last_Date,null,null,null,@Next_Report_Date,@Updated_BY,@Update_Date,@Notes,@Description)
			 DECLARE @PK_PM_Permits AS NUMERIC(20,0)
			 SELECT @PK_PM_Permits=IDENT_CURRENT('PM_Permits') 	 
			 IF(ISNULL(@PK_PM_Permits,0) > 0)
				BEGIN
					INSERT INTO PM_Permits_Attachments SELECT @PK_PM_Permits,CASE Enviro_Attachments.Type WHEN 'Document' THEN 1 WHEN 'Image' THEN 2 WHEN 'Note' THEN 3 ELSE null END,
					null,FILENAME,@Updated_BY,@Update_Date FROM Enviro_Attachments WHERE Foreign_Table='Enviro_SPCC' AND FOREIGN_KEY=@PK_Enviro_SPCC_ID
				END
			
			 FETCH NEXT FROM Cursor_SPCC_Import INTO @PK_Enviro_SPCC_ID,@FK_LU_Location_ID,@Last_Date,@Next_Report_Date,@Notes,
			 @Description,@Updated_BY,@Update_Date
		END   

	CLOSE Cursor_SPCC_Import   
	DEALLOCATE Cursor_SPCC_Import 
 
 END