

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InvestigationInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InvestigationInsert]
GO

CREATE PROCEDURE [dbo].[InvestigationInsert] (
	@FK_WC_FR_ID int,
	@Action_Reviewed datetime,
	@FK_LU_Location_ID int,
	@Cause_1 bit,
	@Cause_2 bit,
	@Cause_3 bit,
	@Cause_4 bit,
	@Cause_5 bit,
	@Cause_6 bit,
	@Cause_7 bit,
	@Cause_8 bit,
	@Cause_9 bit,
	@Cause_10 bit,
	@Cause_11 bit,
	@Cause_12 bit,
	@Cause_13 bit,
	@Cause_14 bit,
	@Cause_15 bit,
	@Cause_16 bit,
	@Cause_17 bit,
	@Cause_18 bit,
	@Cause_19 bit,
	@Cause_20 bit,
	@Cause_21 bit,
	@Cause_22 bit,
	@Cause_23 bit,
	@Cause_24 bit,
	@Cause_25 bit,
	@Cause_26 bit,
	@Cause_27 bit,
	@Cause_28 bit,
	@Cause_29 bit,
	@Cause_30 bit,
	@Cause_31 bit,
	@Cause_32 bit,
	@Cause_33 bit,
	@Cause_34 bit,
	@Cause_35 bit,
	@Cause_36 bit,
	@Cause_37 bit,
	@Cause_38 bit,
	@Cause_39 bit,
	@Cause_40 bit,
	@Cause_41 bit,
	@Cause_42 bit,
	@Cause_42_detail varchar(50),
	@Cause_Comment text,
	@Personal_Job_Factors_1 bit,
	@Personal_Job_Factors_2 bit,
	@Personal_Job_Factors_3 bit,
	@Personal_Job_Factors_4 bit,
	@Personal_Job_Factors_5 bit,
	@Personal_Job_Factors_6 bit,
	@Personal_Job_Factors_7 bit,
	@Personal_Job_Factors_8 bit,
	@Personal_Job_Factors_9 bit,
	@Personal_Job_Factors_10 bit,
	@Personal_Job_Factors_11 bit,
	@Personal_Job_Factors_12 bit,
	@Personal_Job_Factors_13 bit,
	@Personal_Job_Factors_14 bit,
	@Personal_Job_Factors_15 bit,
	@Personal_Job_Factors_16 bit,
	@Personal_Job_Factors_17 bit,
	@Personal_Job_Factors_17_Details varchar(50),
	@Personal_Job_Comment text,
	@Conclusions text,
	@OSHA_Recordable bit,
	@Sonic_Cause_Code varchar(50),
	@Corrective_Action_Description text,
	@Assigned_To varchar(50),
	@AssignedBy varchar(50),
	@To_Be_Competed_by datetime,
	@Status varchar(50),
	@Lessons_Learned text,
	@Cause_Reviewed datetime
)
AS

SET NOCOUNT ON

INSERT INTO [Investigation] (
	[FK_WC_FR_ID],
	[Action_Reviewed],
	[FK_LU_Location_ID],
	[Cause_1],
	[Cause_2],
	[Cause_3],
	[Cause_4],
	[Cause_5],
	[Cause_6],
	[Cause_7],
	[Cause_8],
	[Cause_9],
	[Cause_10],
	[Cause_11],
	[Cause_12],
	[Cause_13],
	[Cause_14],
	[Cause_15],
	[Cause_16],
	[Cause_17],
	[Cause_18],
	[Cause_19],
	[Cause_20],
	[Cause_21],
	[Cause_22],
	[Cause_23],
	[Cause_24],
	[Cause_25],
	[Cause_26],
	[Cause_27],
	[Cause_28],
	[Cause_29],
	[Cause_30],
	[Cause_31],
	[Cause_32],
	[Cause_33],
	[Cause_34],
	[Cause_35],
	[Cause_36],
	[Cause_37],
	[Cause_38],
	[Cause_39],
	[Cause_40],
	[Cause_41],
	[Cause_42],
	[Cause_42_detail],
	[Cause_Comment],
	[Personal_Job_Factors_1],
	[Personal_Job_Factors_2],
	[Personal_Job_Factors_3],
	[Personal_Job_Factors_4],
	[Personal_Job_Factors_5],
	[Personal_Job_Factors_6],
	[Personal_Job_Factors_7],
	[Personal_Job_Factors_8],
	[Personal_Job_Factors_9],
	[Personal_Job_Factors_10],
	[Personal_Job_Factors_11],
	[Personal_Job_Factors_12],
	[Personal_Job_Factors_13],
	[Personal_Job_Factors_14],
	[Personal_Job_Factors_15],
	[Personal_Job_Factors_16],
	[Personal_Job_Factors_17],
	[Personal_Job_Factors_17_Details],
	[Personal_Job_Comment],
	[Conclusions],
	[OSHA_Recordable],
	[Sonic_Cause_Code],
	[Corrective_Action_Description],
	[Assigned_To],
	[AssignedBy],
	[To_Be_Competed_by],
	[Status],
	[Lessons_Learned],
	[Cause_Reviewed]
) VALUES (
	@FK_WC_FR_ID,
	@Action_Reviewed,
	@FK_LU_Location_ID,
	@Cause_1,
	@Cause_2,
	@Cause_3,
	@Cause_4,
	@Cause_5,
	@Cause_6,
	@Cause_7,
	@Cause_8,
	@Cause_9,
	@Cause_10,
	@Cause_11,
	@Cause_12,
	@Cause_13,
	@Cause_14,
	@Cause_15,
	@Cause_16,
	@Cause_17,
	@Cause_18,
	@Cause_19,
	@Cause_20,
	@Cause_21,
	@Cause_22,
	@Cause_23,
	@Cause_24,
	@Cause_25,
	@Cause_26,
	@Cause_27,
	@Cause_28,
	@Cause_29,
	@Cause_30,
	@Cause_31,
	@Cause_32,
	@Cause_33,
	@Cause_34,
	@Cause_35,
	@Cause_36,
	@Cause_37,
	@Cause_38,
	@Cause_39,
	@Cause_40,
	@Cause_41,
	@Cause_42,
	@Cause_42_detail,
	@Cause_Comment,
	@Personal_Job_Factors_1,
	@Personal_Job_Factors_2,
	@Personal_Job_Factors_3,
	@Personal_Job_Factors_4,
	@Personal_Job_Factors_5,
	@Personal_Job_Factors_6,
	@Personal_Job_Factors_7,
	@Personal_Job_Factors_8,
	@Personal_Job_Factors_9,
	@Personal_Job_Factors_10,
	@Personal_Job_Factors_11,
	@Personal_Job_Factors_12,
	@Personal_Job_Factors_13,
	@Personal_Job_Factors_14,
	@Personal_Job_Factors_15,
	@Personal_Job_Factors_16,
	@Personal_Job_Factors_17,
	@Personal_Job_Factors_17_Details,
	@Personal_Job_Comment,
	@Conclusions,
	@OSHA_Recordable,
	@Sonic_Cause_Code,
	@Corrective_Action_Description,
	@Assigned_To,
	@AssignedBy,
	@To_Be_Competed_by,
	@Status,
	@Lessons_Learned,
	@Cause_Reviewed
)

SELECT SCOPE_IDENTITY() AS PK_Investigation_ID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InvestigationSelectByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InvestigationSelectByPK]
GO

CREATE PROCEDURE [dbo].[InvestigationSelectByPK] (
	@PK_Investigation_ID int
)
AS

SET NOCOUNT ON

SELECT
	[PK_Investigation_ID],
	[FK_WC_FR_ID],
	[Action_Reviewed],
	[FK_LU_Location_ID],
	[Cause_1],
	[Cause_2],
	[Cause_3],
	[Cause_4],
	[Cause_5],
	[Cause_6],
	[Cause_7],
	[Cause_8],
	[Cause_9],
	[Cause_10],
	[Cause_11],
	[Cause_12],
	[Cause_13],
	[Cause_14],
	[Cause_15],
	[Cause_16],
	[Cause_17],
	[Cause_18],
	[Cause_19],
	[Cause_20],
	[Cause_21],
	[Cause_22],
	[Cause_23],
	[Cause_24],
	[Cause_25],
	[Cause_26],
	[Cause_27],
	[Cause_28],
	[Cause_29],
	[Cause_30],
	[Cause_31],
	[Cause_32],
	[Cause_33],
	[Cause_34],
	[Cause_35],
	[Cause_36],
	[Cause_37],
	[Cause_38],
	[Cause_39],
	[Cause_40],
	[Cause_41],
	[Cause_42],
	[Cause_42_detail],
	[Cause_Comment],
	[Personal_Job_Factors_1],
	[Personal_Job_Factors_2],
	[Personal_Job_Factors_3],
	[Personal_Job_Factors_4],
	[Personal_Job_Factors_5],
	[Personal_Job_Factors_6],
	[Personal_Job_Factors_7],
	[Personal_Job_Factors_8],
	[Personal_Job_Factors_9],
	[Personal_Job_Factors_10],
	[Personal_Job_Factors_11],
	[Personal_Job_Factors_12],
	[Personal_Job_Factors_13],
	[Personal_Job_Factors_14],
	[Personal_Job_Factors_15],
	[Personal_Job_Factors_16],
	[Personal_Job_Factors_17],
	[Personal_Job_Factors_17_Details],
	[Personal_Job_Comment],
	[Conclusions],
	[OSHA_Recordable],
	[Sonic_Cause_Code],
	[Corrective_Action_Description],
	[Assigned_To],
	[AssignedBy],
	[To_Be_Competed_by],
	[Status],
	[Lessons_Learned],
	[Cause_Reviewed]
FROM
	[Investigation]
WHERE
	[PK_Investigation_ID] = @PK_Investigation_ID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InvestigationSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InvestigationSelectAll]
GO

CREATE PROCEDURE [dbo].[InvestigationSelectAll] AS

SET NOCOUNT ON

SELECT
	[PK_Investigation_ID],
	[FK_WC_FR_ID],
	[Action_Reviewed],
	[FK_LU_Location_ID],
	[Cause_1],
	[Cause_2],
	[Cause_3],
	[Cause_4],
	[Cause_5],
	[Cause_6],
	[Cause_7],
	[Cause_8],
	[Cause_9],
	[Cause_10],
	[Cause_11],
	[Cause_12],
	[Cause_13],
	[Cause_14],
	[Cause_15],
	[Cause_16],
	[Cause_17],
	[Cause_18],
	[Cause_19],
	[Cause_20],
	[Cause_21],
	[Cause_22],
	[Cause_23],
	[Cause_24],
	[Cause_25],
	[Cause_26],
	[Cause_27],
	[Cause_28],
	[Cause_29],
	[Cause_30],
	[Cause_31],
	[Cause_32],
	[Cause_33],
	[Cause_34],
	[Cause_35],
	[Cause_36],
	[Cause_37],
	[Cause_38],
	[Cause_39],
	[Cause_40],
	[Cause_41],
	[Cause_42],
	[Cause_42_detail],
	[Cause_Comment],
	[Personal_Job_Factors_1],
	[Personal_Job_Factors_2],
	[Personal_Job_Factors_3],
	[Personal_Job_Factors_4],
	[Personal_Job_Factors_5],
	[Personal_Job_Factors_6],
	[Personal_Job_Factors_7],
	[Personal_Job_Factors_8],
	[Personal_Job_Factors_9],
	[Personal_Job_Factors_10],
	[Personal_Job_Factors_11],
	[Personal_Job_Factors_12],
	[Personal_Job_Factors_13],
	[Personal_Job_Factors_14],
	[Personal_Job_Factors_15],
	[Personal_Job_Factors_16],
	[Personal_Job_Factors_17],
	[Personal_Job_Factors_17_Details],
	[Personal_Job_Comment],
	[Conclusions],
	[OSHA_Recordable],
	[Sonic_Cause_Code],
	[Corrective_Action_Description],
	[Assigned_To],
	[AssignedBy],
	[To_Be_Competed_by],
	[Status],
	[Lessons_Learned],
	[Cause_Reviewed]
FROM
	[Investigation]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InvestigationUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InvestigationUpdate]
GO

CREATE PROCEDURE [dbo].[InvestigationUpdate] (
	@PK_Investigation_ID int,
	@FK_WC_FR_ID int,
	@Action_Reviewed datetime,
	@FK_LU_Location_ID int,
	@Cause_1 bit,
	@Cause_2 bit,
	@Cause_3 bit,
	@Cause_4 bit,
	@Cause_5 bit,
	@Cause_6 bit,
	@Cause_7 bit,
	@Cause_8 bit,
	@Cause_9 bit,
	@Cause_10 bit,
	@Cause_11 bit,
	@Cause_12 bit,
	@Cause_13 bit,
	@Cause_14 bit,
	@Cause_15 bit,
	@Cause_16 bit,
	@Cause_17 bit,
	@Cause_18 bit,
	@Cause_19 bit,
	@Cause_20 bit,
	@Cause_21 bit,
	@Cause_22 bit,
	@Cause_23 bit,
	@Cause_24 bit,
	@Cause_25 bit,
	@Cause_26 bit,
	@Cause_27 bit,
	@Cause_28 bit,
	@Cause_29 bit,
	@Cause_30 bit,
	@Cause_31 bit,
	@Cause_32 bit,
	@Cause_33 bit,
	@Cause_34 bit,
	@Cause_35 bit,
	@Cause_36 bit,
	@Cause_37 bit,
	@Cause_38 bit,
	@Cause_39 bit,
	@Cause_40 bit,
	@Cause_41 bit,
	@Cause_42 bit,
	@Cause_42_detail varchar(50),
	@Cause_Comment text,
	@Personal_Job_Factors_1 bit,
	@Personal_Job_Factors_2 bit,
	@Personal_Job_Factors_3 bit,
	@Personal_Job_Factors_4 bit,
	@Personal_Job_Factors_5 bit,
	@Personal_Job_Factors_6 bit,
	@Personal_Job_Factors_7 bit,
	@Personal_Job_Factors_8 bit,
	@Personal_Job_Factors_9 bit,
	@Personal_Job_Factors_10 bit,
	@Personal_Job_Factors_11 bit,
	@Personal_Job_Factors_12 bit,
	@Personal_Job_Factors_13 bit,
	@Personal_Job_Factors_14 bit,
	@Personal_Job_Factors_15 bit,
	@Personal_Job_Factors_16 bit,
	@Personal_Job_Factors_17 bit,
	@Personal_Job_Factors_17_Details varchar(50),
	@Personal_Job_Comment text,
	@Conclusions text,
	@OSHA_Recordable bit,
	@Sonic_Cause_Code varchar(50),
	@Corrective_Action_Description text,
	@Assigned_To varchar(50),
	@AssignedBy varchar(50),
	@To_Be_Competed_by datetime,
	@Status varchar(50),
	@Lessons_Learned text,
	@Cause_Reviewed datetime
)
AS

SET NOCOUNT ON

UPDATE
	[Investigation]
SET
	[FK_WC_FR_ID] = @FK_WC_FR_ID,
	[Action_Reviewed] = @Action_Reviewed,
	[FK_LU_Location_ID] = @FK_LU_Location_ID,
	[Cause_1] = @Cause_1,
	[Cause_2] = @Cause_2,
	[Cause_3] = @Cause_3,
	[Cause_4] = @Cause_4,
	[Cause_5] = @Cause_5,
	[Cause_6] = @Cause_6,
	[Cause_7] = @Cause_7,
	[Cause_8] = @Cause_8,
	[Cause_9] = @Cause_9,
	[Cause_10] = @Cause_10,
	[Cause_11] = @Cause_11,
	[Cause_12] = @Cause_12,
	[Cause_13] = @Cause_13,
	[Cause_14] = @Cause_14,
	[Cause_15] = @Cause_15,
	[Cause_16] = @Cause_16,
	[Cause_17] = @Cause_17,
	[Cause_18] = @Cause_18,
	[Cause_19] = @Cause_19,
	[Cause_20] = @Cause_20,
	[Cause_21] = @Cause_21,
	[Cause_22] = @Cause_22,
	[Cause_23] = @Cause_23,
	[Cause_24] = @Cause_24,
	[Cause_25] = @Cause_25,
	[Cause_26] = @Cause_26,
	[Cause_27] = @Cause_27,
	[Cause_28] = @Cause_28,
	[Cause_29] = @Cause_29,
	[Cause_30] = @Cause_30,
	[Cause_31] = @Cause_31,
	[Cause_32] = @Cause_32,
	[Cause_33] = @Cause_33,
	[Cause_34] = @Cause_34,
	[Cause_35] = @Cause_35,
	[Cause_36] = @Cause_36,
	[Cause_37] = @Cause_37,
	[Cause_38] = @Cause_38,
	[Cause_39] = @Cause_39,
	[Cause_40] = @Cause_40,
	[Cause_41] = @Cause_41,
	[Cause_42] = @Cause_42,
	[Cause_42_detail] = @Cause_42_detail,
	[Cause_Comment] = @Cause_Comment,
	[Personal_Job_Factors_1] = @Personal_Job_Factors_1,
	[Personal_Job_Factors_2] = @Personal_Job_Factors_2,
	[Personal_Job_Factors_3] = @Personal_Job_Factors_3,
	[Personal_Job_Factors_4] = @Personal_Job_Factors_4,
	[Personal_Job_Factors_5] = @Personal_Job_Factors_5,
	[Personal_Job_Factors_6] = @Personal_Job_Factors_6,
	[Personal_Job_Factors_7] = @Personal_Job_Factors_7,
	[Personal_Job_Factors_8] = @Personal_Job_Factors_8,
	[Personal_Job_Factors_9] = @Personal_Job_Factors_9,
	[Personal_Job_Factors_10] = @Personal_Job_Factors_10,
	[Personal_Job_Factors_11] = @Personal_Job_Factors_11,
	[Personal_Job_Factors_12] = @Personal_Job_Factors_12,
	[Personal_Job_Factors_13] = @Personal_Job_Factors_13,
	[Personal_Job_Factors_14] = @Personal_Job_Factors_14,
	[Personal_Job_Factors_15] = @Personal_Job_Factors_15,
	[Personal_Job_Factors_16] = @Personal_Job_Factors_16,
	[Personal_Job_Factors_17] = @Personal_Job_Factors_17,
	[Personal_Job_Factors_17_Details] = @Personal_Job_Factors_17_Details,
	[Personal_Job_Comment] = @Personal_Job_Comment,
	[Conclusions] = @Conclusions,
	[OSHA_Recordable] = @OSHA_Recordable,
	[Sonic_Cause_Code] = @Sonic_Cause_Code,
	[Corrective_Action_Description] = @Corrective_Action_Description,
	[Assigned_To] = @Assigned_To,
	[AssignedBy] = @AssignedBy,
	[To_Be_Competed_by] = @To_Be_Competed_by,
	[Status] = @Status,
	[Lessons_Learned] = @Lessons_Learned,
	[Cause_Reviewed] = @Cause_Reviewed
WHERE
	 [PK_Investigation_ID] = @PK_Investigation_ID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InvestigationDeleteByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InvestigationDeleteByPK]
GO

CREATE PROCEDURE [dbo].[InvestigationDeleteByPK] (
	@PK_Investigation_ID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[Investigation]
WHERE
	[PK_Investigation_ID] = @PK_Investigation_ID
GO


GO
/****** Object:  StoredProcedure [dbo].[InvestigationGetWCInformation]    Script Date: 10/01/2008 17:37:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InvestigationGetWCInformation]
(
	@WC_FR_ID numeric(13,0)
)
as
select
FK_LU_Location,
isnull(L.dba,'') as dba,
isnull(L.RM_Location_Number,'') as RM_Location_Number,
W.Date_Of_Incident,
W.Time_Of_Incident,
isnull(D.Description,'') as Department,
W.Date_Reported_To_Sonic,
isnull(E.First_Name,'') as FirstName,
isnull(E.Last_Name,'') as LastName,
isnull(E.Middle_Name,'') as MiddleName,
isnull(E.Hire_Date,'01/01/1753') as HireDate,
isnull(E.Job_Title,'') as Job_Title,
isnull(I.Description,'') as Nature_Of_Injury,
isnull(B.Description,'') as Body_Parts_Affected,
isnull(W.Description_Of_Incident,'') as Description_Of_Incident,
Safeguards_Provided,
Safeguards_Used,
Machine_Part_Involved,
Machine_Part_Defective
from
WC_FR W 
left join LU_Location L on W.FK_LU_Location = L.PK_LU_Location_ID
left join LU_Department D on D.PK_LU_Department_ID = W.FK_Department_Where_Occurred
left join Employee E on E.PK_Employee_ID = W.FK_Injured
left join LU_Nature_of_Injury I on I.PK_LU_Nature_of_Injury_ID = W.FK_Nature_Of_Injury
left join LU_Part_Of_Body B on B.PK_LU_Part_Of_Body_ID = W.FK_Body_Parts_Affected

where W.PK_WC_FR_ID = @WC_FR_ID

GO
/****** Object:  StoredProcedure [dbo].[LU_LocationSelectByRMLocationNumber]    Script Date: 10/01/2008 17:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[LU_LocationSelectByRMLocationNumber]
(
	@RM_Location_Number nvarchar(50)
)
as
select * from LU_Location where RM_Location_Number = @RM_Location_Number 

GO
GO
/****** Object:  StoredProcedure [dbo].[InvestigationSelectPKByWc_FR_ID]    Script Date: 10/01/2008 17:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InvestigationSelectPKByWc_FR_ID]
(
	@FK_WC_FR_ID int,
	@PK_Investigation_ID int out
)
as
select @PK_Investigation_ID = PK_Investigation_ID from Investigation where FK_WC_FR_ID = @FK_WC_FR_ID 
if @PK_Investigation_ID is null
	set @PK_Investigation_ID = 0



