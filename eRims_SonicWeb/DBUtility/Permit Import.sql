BEGIN
SET NOCOUNT ON

DECLARE @PK_Enviro_Permit_ID NUMERIC(20,0),
		@FK_LU_Location_Id NUMERIC(20,0),
		@TYPE VARCHAR(50),
		@REQUIRED BIT,
		@Certificate_Number NVARCHAR(50),
		@Application_Number NVARCHAR(50),
		@Begin_Date DATETIME,
		@End_Date DATETIME,
		@Last_Inspection_Date DATETIME,
		@Next_Inspection_Date DATETIME,
		@Next_Report_Date DATETIME,
		@Updated_By NVARCHAR(30),
		@Update_Date DATETIME,
		@Notes varchar(7999),
		@description as varchar(7999),
		@PK_PM_Site_Information AS NUMERIC(20,0),
		@GUID AS uniqueidentifier
		
DECLARE Cursor_PM_Permits_Import CURSOR FOR
 SELECT DISTINCT 
 ep.PK_Enviro_Permit_ID,
 ep.FK_LU_Location_Id,ep.[TYPE],ep.[REQUIRED],ep.Certificate_Number,ep.Application_Number,
 ep.Begin_Date,ep.End_Date,ep.Last_Inspection_Date,
 ep.Next_Inspection_Date,ep.Next_Report_Date,
 ep.Updated_By,ep.Update_Date,
 cast(ep.Notes as varchar(7999)) [Notes],cast(er.[description] as varchar(7999)) [description]
 FROM Enviro_Permit ep 
 Left Join Enviro_Recommendations er ON ep.PK_Enviro_Permit_ID= er.Foreign_Key and er.Foreign_Table='Enviro_Permit'
 
 OPEN Cursor_PM_Permits_Import   
	FETCH NEXT FROM Cursor_PM_Permits_Import INTO @PK_Enviro_Permit_ID,@FK_LU_Location_Id,@TYPE,@REQUIRED,@Certificate_Number,@Application_Number,
		@Begin_Date,@End_Date,@Last_Inspection_Date,@Next_Inspection_Date,@Next_Report_Date,@Updated_By,
		@Update_Date,@Notes,@description
	
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
			 
			 DECLARE @FK_Permit_Type NUMERIC(20,0)
			 IF EXISTS(SELECT * FROM LU_Permit_Type WHERE Fld_Desc = LTRIM(RTRIM(@TYPE)))
			 BEGIN
			 	SELECT @FK_Permit_Type=PK_LU_Permit_Type FROM LU_Permit_Type WHERE Fld_Desc = LTRIM(RTRIM(@TYPE))
			 END
			 ELSE
			 BEGIN
			 	IF(@Notes IS NULL)
			 		SET @Notes = ''
			 	SET @Notes = @Notes+' Legacy Permit Type = '+@TYPE
			 	SET @FK_Permit_Type = 8
			 	--SELECT @FK_Permit_Type=PK_LU_Permit_Type FROM LU_Permit_Type WHERE Fld_Desc = 'Other Permit'
			 END	
			 
			 INSERT INTO PM_Permits VALUES(@PK_PM_Site_Information,@FK_Permit_Type,(CASE @REQUIRED WHEN 1 THEN 'Y' ELSE 'N' END),@Certificate_Number,
				 @Application_Number,@Begin_Date,@End_Date,@Last_Inspection_Date,@Next_Inspection_Date,@Next_Report_Date,@Updated_By,
				 @Update_Date,@Notes,@description)
			 
			 
			 DECLARE @PK_PM_Permits AS NUMERIC(20,0)
			 SELECT @PK_PM_Permits=IDENT_CURRENT('PM_Permits') 	 
			 IF(ISNULL(@PK_PM_Permits,0) > 0)
			 BEGIN
				INSERT INTO PM_Permits_Attachments SELECT @PK_PM_Permits,CASE Enviro_Attachments.Type WHEN 'Document' THEN 1 WHEN 'Image' THEN 2 WHEN 'Note' THEN 3 ELSE null END,
				null,FILENAME,@Updated_BY,@Update_Date FROM Enviro_Attachments WHERE Foreign_Table='Enviro_Permit' AND FOREIGN_KEY=@PK_Enviro_Permit_ID 
			 END
			
			 FETCH NEXT FROM Cursor_PM_Permits_Import INTO @PK_Enviro_Permit_ID,@FK_LU_Location_Id,@TYPE,@REQUIRED,@Certificate_Number,@Application_Number,
				@Begin_Date,@End_Date,@Last_Inspection_Date,@Next_Inspection_Date,@Next_Report_Date,@Updated_By,
				@Update_Date,@Notes,@description
		END
	CLOSE Cursor_PM_Permits_Import   
	DEALLOCATE Cursor_PM_Permits_Import 
 END