/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta ****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Group](
	[PK_Group_ID] [int] IDENTITY(1,1) NOT NULL,
	[Group_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[PK_Group_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Right](
	[PK_Right_ID] [int] IDENTITY(1,1) NOT NULL,
	[Right_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Module_ID] [numeric](18, 0) NULL,
	[RightType_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Right] PRIMARY KEY CLUSTERED 
(
	[PK_Right_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assoc_User_Group](
	[PK_Assoc_User_Group_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_User_ID] [int] NOT NULL,
	[FK_Group_ID] [int] NOT NULL,
 CONSTRAINT [PK_Assoc_User_Group] PRIMARY KEY CLUSTERED 
(
	[PK_Assoc_User_Group_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assoc_User_Right](
	[PK_Assoc_User_Right_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_User_ID] [int] NOT NULL,
	[FK_Right_ID] [int] NOT NULL,
 CONSTRAINT [PK_Assoc_User_Right] PRIMARY KEY CLUSTERED 
(
	[PK_Assoc_User_Right_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Building](
	[PK_Building_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NULL,
	[Building_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Ownership] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Occupancy_Sales_New] [bit] NULL,
	[Occupancy_Body_Shop] [bit] NULL,
	[Occupancy_Parking_Lot] [bit] NULL,
	[Occupancy_Sales_Used] [bit] NULL,
	[Occupancy_Parts] [bit] NULL,
	[Occupancy_Raw_Land] [bit] NULL,
	[Occupancy_Service] [bit] NULL,
	[Occupancy_Ofifce] [bit] NULL,
	[Address_1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address_2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Building_Limit] [decimal](18, 0) NULL,
	[Leasehold_Interests_Limit_Betterment] [decimal](18, 0) NULL,
	[Betterment_Date_Complete] [datetime] NULL,
	[Leasehold_Interests_Limit_Expansion] [decimal](18, 0) NULL,
	[Expansion_Date_Complete] [datetime] NULL,
	[Associate_Tools_Limit] [decimal](18, 0) NULL,
	[Contents_Limit] [decimal](18, 0) NULL,
	[Parts_Limit] [decimal](18, 0) NULL,
	[Inventory_Levels] [decimal](18, 0) NULL,
	[Year_Built] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Square_Footage] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Number_of_Stories] [float] NULL,
	[Roof_Reinforced_Concrete] [bit] NULL,
	[Roof_Concrete_Panels] [bit] NULL,
	[Roof_Steel_Deck_with_Fasteners] [bit] NULL,
	[Roof_Poured_Concrete] [bit] NULL,
	[Roof_Steel_Deck] [bit] NULL,
	[Roof_Wood_Joists] [bit] NULL,
	[Floors_Reinforced_Concrete] [bit] NULL,
	[Floors_Poured_Concrete] [bit] NULL,
	[Floors_Wood_Timber] [bit] NULL,
	[Ext_Walls_Reinforced_Concrete] [bit] NULL,
	[Ext_Walls_Masonry] [bit] NULL,
	[Ext_Walls_Corrugated_Metal_Panels] [bit] NULL,
	[Ext_Walls_Tilt_up_Concrete] [bit] NULL,
	[Ext_Walls_Glass_and_Steel_Curtain] [bit] NULL,
	[Ext_Walls_Wood_Frame] [bit] NULL,
	[Int_Walls_Masonry_With_Fire_Doors] [bit] NULL,
	[Int_Walls_Masonry_with_Openings] [bit] NULL,
	[Int_Walls_No_Interior_Walls] [bit] NULL,
	[Int_Walls_Masonry] [bit] NULL,
	[Int_Walls_Gypsum_Board] [bit] NULL,
	[Int_wall_extend_above_roof] [bit] NULL,
	[Number_of_Paint_Booths] [int] NULL,
	[Number_of_Lifts] [int] NULL,
	[Sales_New_Sprinklered] [float] NULL,
	[Sales_Used_Sprinklered] [float] NULL,
	[Service_Sprinklered] [float] NULL,
	[Body_Shop_Sprinklered] [float] NULL,
	[Parts_Sprinklered] [float] NULL,
	[Office_Sprinklered] [float] NULL,
	[Water_Public] [bit] NULL,
	[Water_Private] [bit] NULL,
	[Water_Boosted] [bit] NULL,
	[Design_Densities_for_each_area] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Hydrants_within_500_ft] [bit] NULL,
	[Alarm_UL_Central_Station] [bit] NULL,
	[Alarm_Constant_Attended] [bit] NULL,
	[Alarm_Sprinkler_Valve_Tamper] [bit] NULL,
	[Alarm_Non_UL_Central_Station] [bit] NULL,
	[Alarm_Local] [bit] NULL,
	[Alarm_Smoke_Detectors] [bit] NULL,
	[Alarm_Proprietary] [bit] NULL,
	[Alarm_Sprinkler_Waterflow] [bit] NULL,
	[Alarm_Dry_Pipe_Air] [bit] NULL,
	[Alarm_Remote] [bit] NULL,
	[Alarm_Fire_Pump_Alarms] [bit] NULL,
	[Alarm_Auto_Fire_Alarms] [bit] NULL,
	[Alarm_Security_Cameras] [bit] NULL,
	[SecuCam_System] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_Contact_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_Vendor_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_Contact_Expiration_Date] [datetime] NULL,
	[SecuCam_Address_1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_Address_2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_Telephone_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_Alternate_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_Email] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecuCam_Comments] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_System] [bit] NULL,
	[Guard_System_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_Contact_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_Vendor_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_Contact_Expiration_Date] [datetime] NULL,
	[Guard_Address_1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_Address_2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_Telephone_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_Alternate_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_Email] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guard_Comments] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_System] [bit] NULL,
	[Intru_System_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Contact_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Vendor_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Contact_Expiration_Date] [datetime] NULL,
	[Intru_Address_1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Address_2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Telephone_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Alternate_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Email] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Comments] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Intru_Contact_Alarm_Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fence] [bit] NULL,
	[Fence_Razor_Wire] [bit] NULL,
	[Fence_Electrified] [bit] NULL,
	[Generator] [bit] NULL,
	[Generator_Make] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Generator_Model] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Generator_Size] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fire_Department_Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fire_Department_Distance] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Tier_1_County] [bit] NULL,
	[Earthquake_Zone_Fault_Line] [bit] NULL,
	[Neighboring_Buildings_within_100_ft] [bit] NULL,
	[Neighbor_Occupancy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Distance_from_body_of_water] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Prior_Flood_History] [bit] NULL,
	[Flood_History_Descr] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lowest_finish_floor_elevation] [int] NULL,
	[Property_Damage_Losses_in_the_Past_5_years] [bit] NULL,
	[Property_Loss_Descr] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Flood_Zone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[National_Flood_Policy] [bit] NULL,
	[Flood_Carrier] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Flood_Policy_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Flood_Premium] [decimal](18, 0) NULL,
	[Flood_Polciy_Limits_Contents] [decimal](18, 0) NULL,
	[Flood_Policy_Inception_Date] [datetime] NULL,
	[Flood_Policy_Expiration_Date] [datetime] NULL,
	[Flood_Deductible] [decimal](18, 0) NULL,
	[Flood_Policy_Limits_Building] [decimal](18, 0) NULL,
	[Comments] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Bulding] PRIMARY KEY CLUSTERED 
(
	[PK_Building_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF



/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Building_Attachments](
	[PK_Building_Attachments_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_Building_ID] [int] NULL,
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Filename] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Building_Attachments] PRIMARY KEY CLUSTERED 
(
	[PK_Building_Attachments_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Building_Ownership](
	[PK_Building_Ownership_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_Building_ID] [int] NULL,
	[Owner_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Owner_Address_1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Owner_Address_2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Owner_City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Owner_State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Owner_Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lease_Sublease] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Landlord_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Landlord_Address_1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Landlord_Address_2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Landlord_City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Landlord_State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Landlord_Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lease_ID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Sublease] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubLandlord] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Commencement_Date] [datetime] NULL,
	[Expiration_Date] [datetime] NULL,
	[COI_Wording] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[REQ_WC] [bit] NULL,
	[REQ_EL] [bit] NULL,
	[REQ_GL] [bit] NULL,
	[REQ_Property] [bit] NULL,
	[REQ_Flood] [bit] NULL,
	[REQ_EQ] [bit] NULL,
	[REQ_WaiverofSubrogation] [bit] NULL,
	[SubResponsible_WC] [bit] NULL,
	[SubResponsible_EL] [bit] NULL,
	[SubResponsible_GL] [bit] NULL,
	[SubResponsible_Property] [bit] NULL,
	[SubResponsible_Flood] [bit] NULL,
	[EQ] [bit] NULL,
	[WaiverofSubrogation] [bit] NULL,
	[COI_WC] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COI_EL] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COI_GL] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COI_Property] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COI_Flood] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COI_EQ] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COI_WaiverofSubrogation] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COI_WC_Date] [datetime] NULL,
	[COI_EL_Date] [datetime] NULL,
	[COI_GL_Date] [datetime] NULL,
	[COI_Property_Date] [datetime] NULL,
	[COI_Flood_Date] [datetime] NULL,
	[COI_EQ_Date] [datetime] NULL,
	[COI_WaiverofSubrogation_Date] [datetime] NULL,
	[ReqLim_WC] [decimal](18, 0) NULL,
	[ReqLim_EL] [decimal](18, 0) NULL,
	[ReqLim_GL] [decimal](18, 0) NULL,
	[ReqLim_Property] [decimal](18, 0) NULL,
	[ReqLim_Flood] [decimal](18, 0) NULL,
	[ReqLim_EQ] [decimal](18, 0) NULL,
	[ReqLim_WaiverofSubrogation] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Building_Ownership] PRIMARY KEY CLUSTERED 
(
	[PK_Building_Ownership_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF


/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Building_Additional_Insureds_Payees](
	[PK_Building_Additional_Insureds_Payees_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_Building_ID] [int] NULL,
	[Insured_Payee] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Named] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address_1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address_2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Building_Additional_Insureds_Payees] PRIMARY KEY CLUSTERED 
(
	[PK_Building_Additional_Insureds_Payees_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lease_SubLease_Attachments](
	[PK_Lease_SubLease_Attachments_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_Building_ID] [int] NULL,
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Filename] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Lease_SubLease_Attachments] PRIMARY KEY CLUSTERED 
(
	[PK_Lease_SubLease_Attachments_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Property_Assessment](
	[PK_Property_Assessment_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NULL,
	[Date] [datetime] NULL,
	[Assessor] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Contact_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address_1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address_2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telephone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Property_Assessment] PRIMARY KEY CLUSTERED 
(
	[PK_Property_Assessment_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property_Assessment_Concern](
	[PK_Property_Assessment_Concern_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_Property_Assessment_ID] [int] NULL,
	[Item_Description] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Budgeted_Cost] [decimal](18, 0) NULL,
	[Actual_Cost] [decimal](18, 0) NULL,
	[Date_Complete] [datetime] NULL,
	[Comments] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Property_Assessment_Concern] PRIMARY KEY CLUSTERED 
(
	[PK_Property_Assessment_Concern_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Assessment_Attachments](
	[PK_Assessment_Attachments_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_Building_ID] [int] NULL,
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Filename] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Assessment_Attachments] PRIMARY KEY CLUSTERED 
(
	[PK_Assessment_Attachments_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Property_Contact](
	[PK_Property_Contact_ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Cell_Phone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Aftee_Hours_Contact_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[After_Hours_Contact_Phone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[After_Hours_Contact_Cell_Phone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Organization] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[email] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Property_Contact] PRIMARY KEY CLUSTERED 
(
	[PK_Property_Contact_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enviro_Equipment](
	[PK_Enviro_Equipment_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NULL,
	[Identification] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Contents] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Contents_Other] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Material] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Material_Other] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Construction] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Construction_Other] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Release_Equipment_Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Overfill_Protection] [bit] NULL,
	[Leak_Detection] [bit] NULL,
	[Leak_Detection_Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Insurer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Single_Event_Coverage] [decimal](18, 0) NULL,
	[Multiple_Event_Total_Coverage] [decimal](18, 0) NULL,
	[Coverage_Start_Date] [datetime] NULL,
	[Coverage_End_Date] [datetime] NULL,
	[Flows_to_POTW] [bit] NULL,
	[Date_of_Last_Service] [datetime] NULL,
	[TCLP_on_File] [bit] NULL,
	[Date_of_Last_TCLP] [datetime] NULL,
	[Installation_Date] [datetime] NULL,
	[Removal_Date] [datetime] NULL,
	[Closure_Date] [datetime] NULL,
	[Last_Inspection_Date] [datetime] NULL,
	[Next_Inspection_Date] [datetime] NULL,
	[Insurance_Company] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inspection_Contact] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Inspection_Phone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Registration_Required] [bit] NULL,
	[Registration_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Certificate_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Permit_Begin_Date] [datetime] NULL,
	[Permit_End_Date] [datetime] NULL,
	[Other_Req] [bit] NULL,
	[Other_Req_Descr] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Next_Report_Date] [datetime] NULL,
	[Notes] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Plan_ID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Plan_Effective_Date] [datetime] NULL,
	[Plan_Expiration_Date] [datetime] NULL,
	[Plan_Revision_Date] [datetime] NULL,
	[Plan_Vendor] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Plan_Vendor_Contact] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Plan_Phone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Enviro_Equipment] PRIMARY KEY CLUSTERED 
(
	[PK_Enviro_Equipment_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enviro_Attachments](
	[PK_Enviro_Equipment_Attachments_ID] [int] IDENTITY(1,1) NOT NULL,
	[Foreign_Table] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Foreign_Key] [int] NULL,
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Filename] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[folder] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Enviro_Attachments] PRIMARY KEY CLUSTERED 
(
	[PK_Enviro_Equipment_Attachments_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enviro_Recommendations](
	[PK_Enviro_Equipment_Recommendations_ID] [int] IDENTITY(1,1) NOT NULL,
	[Foreign_Table] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Foreign_Key] [int] NULL,
	[Date] [datetime] NULL,
	[Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Made_by] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[title] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Assigned_to] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Due_date] [datetime] NULL,
	[Assigned_to_phone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Assigned_to_email] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[resolution] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Date_closed] [datetime] NULL,
 CONSTRAINT [PK_Enviro_Recommendations] PRIMARY KEY CLUSTERED 
(
	[PK_Enviro_Equipment_Recommendations_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enviro_Permit](
	[PK_Enviro_Permit_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NULL,
	[type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[required] [bit] NULL,
	[Application_number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Certificate_number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Filing_date] [datetime] NULL,
	[Begin_date] [datetime] NULL,
	[End_date] [datetime] NULL,
	[Last_Inspection_date] [datetime] NULL,
	[Next_Inspection_Date] [datetime] NULL,
	[Next_Report_Date] [datetime] NULL,
	[Notes] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Enviro_Permit] PRIMARY KEY CLUSTERED 
(
	[PK_Enviro_Permit_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enviro_Inspection](
	[PK_Enviro_Inspection_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NULL,
	[Frequency] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Last_Date] [datetime] NULL,
	[Next_Date] [datetime] NULL,
	[Next_Report_Date] [datetime] NULL,
	[Cost] [decimal](18, 0) NULL,
	[Notes] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Enviro_Inspection] PRIMARY KEY CLUSTERED 
(
	[PK_Enviro_Inspection_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enviro_SPCC](
	[PK_Enviro_Inspection_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NULL,
	[Frequency] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Last_Date] [datetime] NULL,
	[Next_Date] [datetime] NULL,
	[Next_Report_Date] [datetime] NULL,
	[Cost] [decimal](18, 0) NULL,
	[Notes] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Enviro_SPCC] PRIMARY KEY CLUSTERED 
(
	[PK_Enviro_Inspection_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enviro_Phase1](
	[PK_Enviro_Phase1_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NULL,
	[Frequency] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Last_Date] [datetime] NULL,
	[Next_Date] [datetime] NULL,
	[Next_Report_Date] [datetime] NULL,
	[Cost] [decimal](18, 0) NULL,
	[Notes] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Enviro_Phase1] PRIMARY KEY CLUSTERED 
(
	[PK_Enviro_Phase1_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Investigation](
	[PK_Investigation_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_WC_FR_ID] [int] NOT NULL,
	[FK_LU_Location_ID] [int] NOT NULL,
	[Cause_1] [bit] NULL,
	[Cause_2] [bit] NULL,
	[Cause_3] [bit] NULL,
	[Cause_4] [bit] NULL,
	[Cause_5] [bit] NULL,
	[Cause_6] [bit] NULL,
	[Cause_7] [bit] NULL,
	[Cause_8] [bit] NULL,
	[Cause_9] [bit] NULL,
	[Cause_10] [bit] NULL,
	[Cause_11] [bit] NULL,
	[Cause_12] [bit] NULL,
	[Cause_13] [bit] NULL,
	[Cause_14] [bit] NULL,
	[Cause_15] [bit] NULL,
	[Cause_16] [bit] NULL,
	[Cause_17] [bit] NULL,
	[Cause_18] [bit] NULL,
	[Cause_19] [bit] NULL,
	[Cause_20] [bit] NULL,
	[Cause_21] [bit] NULL,
	[Cause_22] [bit] NULL,
	[Cause_23] [bit] NULL,
	[Cause_24] [bit] NULL,
	[Cause_25] [bit] NULL,
	[Cause_26] [bit] NULL,
	[Cause_27] [bit] NULL,
	[Cause_28] [bit] NULL,
	[Cause_29] [bit] NULL,
	[Cause_30] [bit] NULL,
	[Cause_31] [bit] NULL,
	[Cause_32] [bit] NULL,
	[Cause_33] [bit] NULL,
	[Cause_34] [bit] NULL,
	[Cause_35] [bit] NULL,
	[Cause_36] [bit] NULL,
	[Cause_37] [bit] NULL,
	[Cause_38] [bit] NULL,
	[Cause_39] [bit] NULL,
	[Cause_40] [bit] NULL,
	[Cause_41] [bit] NULL,
	[Cause_42] [bit] NULL,
	[Cause_42_detail] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Cause_Comment] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Personal_Job_Factors_1] [bit] NULL,
	[Personal_Job_Factors_2] [bit] NULL,
	[Personal_Job_Factors_3] [bit] NULL,
	[Personal_Job_Factors_4] [bit] NULL,
	[Personal_Job_Factors_5] [bit] NULL,
	[Personal_Job_Factors_6] [bit] NULL,
	[Personal_Job_Factors_7] [bit] NULL,
	[Personal_Job_Factors_8] [bit] NULL,
	[Personal_Job_Factors_9] [bit] NULL,
	[Personal_Job_Factors_10] [bit] NULL,
	[Personal_Job_Factors_11] [bit] NULL,
	[Personal_Job_Factors_12] [bit] NULL,
	[Personal_Job_Factors_13] [bit] NULL,
	[Personal_Job_Factors_14] [bit] NULL,
	[Personal_Job_Factors_15] [bit] NULL,
	[Personal_Job_Factors_16] [bit] NULL,
	[Personal_Job_Factors_17] [bit] NULL,
	[Personal_Job_Factors_18] [bit] NULL,
	[Personal_Job_Factors_19] [bit] NULL,
	[Personal_Job_Factors_17_Details] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Personal_Job_Comment] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Conclusions] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OSHA_Recordable] [bit] NULL,
	[Sonic_Cause_Code] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Corrective_Action_Description] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Assigned_To] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AssignedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[To_Be_Competed_by] [datetime] NULL,
	[Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Lessons_Learned] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Cause_Reviewed] [datetime] NULL,
	[Action_Reviewed] [datetime] NULL,
 CONSTRAINT [PK_Investigation] PRIMARY KEY CLUSTERED 
(
	[PK_Investigation_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF


/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inspection](
	[PK_Inspection_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_Inspection] PRIMARY KEY CLUSTERED 
(
	[PK_Inspection_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inspection_Questions](
	[PK_Inspection_Questions_ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_Number_Focus_Area] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Question_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Question_Text] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Guidance_Text] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Inspection_Questions] PRIMARY KEY CLUSTERED 
(
	[PK_Inspection_Questions_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inspection_Responses](
	[PK_Inspection_Responses_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_Inspection_ID] [int] NULL,
	[FK_Inspection_Question_ID] [int] NULL,
	[Deficiency_Noted] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Department] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Date_Opened] [datetime] NULL,
	[Recommended_Action] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Target_Completion_Date] [datetime] NULL,
	[Actual_Completion_Date] [datetime] NULL,
	[Notes] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Inspection_Responses] PRIMARY KEY CLUSTERED 
(
	[PK_Inspection_Responses_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 29-Sep-08    Created By :: Ravi Gupta  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EPA_IDs](
	[PK_Enviro_Permit_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NULL,
	[type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ID_Number] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_EPA_IDs] PRIMARY KEY CLUSTERED 
(
	[PK_Enviro_Permit_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 30-Sep-08    Created By :: Ravi Gupta  ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightInsert]
GO

CREATE PROCEDURE [dbo].[RightInsert] (
	@Right_Name varchar(50)
)
AS

SET NOCOUNT ON

INSERT INTO [Right] (
	[Right_Name]
) VALUES (
	@Right_Name
)

SELECT SCOPE_IDENTITY() AS PK_Right_ID
GO

/****** Created Date :: 30-Sep-08    Created By :: Ravi Gupta  ******/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightSelectByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightSelectByPK]
GO

CREATE PROCEDURE [dbo].[RightSelectByPK] (
	@PK_Right_ID int
)
AS

SET NOCOUNT ON

SELECT
	[PK_Right_ID],
	[Right_Name]
FROM
	[Right]
WHERE
	[PK_Right_ID] = @PK_Right_ID
GO

/****** Created Date :: 30-Sep-08    Created By :: Ravi Gupta  ******/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightSelectAll]
GO

CREATE PROCEDURE [dbo].[RightSelectAll] AS

SET NOCOUNT ON

SELECT
	[PK_Right_ID],
	[Right_Name]
FROM
	[Right]
GO


/****** Created Date :: 30-Sep-08    Created By :: Ravi Gupta  ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightUpdate]
GO

CREATE PROCEDURE [dbo].[RightUpdate] (
	@PK_Right_ID int,
	@Right_Name varchar(50)
)
AS

SET NOCOUNT ON

UPDATE
	[Right]
SET
	[Right_Name] = @Right_Name
WHERE
	 [PK_Right_ID] = @PK_Right_ID
GO

/****** Created Date :: 30-Sep-08    Created By :: Ravi Gupta  ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightDeleteByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightDeleteByPK]
GO

CREATE PROCEDURE [dbo].[RightDeleteByPK] (
	@PK_Right_ID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[Right]
WHERE
	[PK_Right_ID] = @PK_Right_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_GroupInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_GroupInsert]
GO

CREATE PROCEDURE [dbo].[Assoc_User_GroupInsert] (
	@FK_User_ID int,
	@FK_Group_ID int
)
AS

SET NOCOUNT ON

INSERT INTO [Assoc_User_Group] (
	[FK_User_ID],
	[FK_Group_ID]
) VALUES (
	@FK_User_ID,
	@FK_Group_ID
)

SELECT SCOPE_IDENTITY() AS PK_Assoc_User_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_GroupSelectByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_GroupSelectByPK]
GO

CREATE PROCEDURE [dbo].[Assoc_User_GroupSelectByPK] (
	@PK_Assoc_User_Group_ID int
)
AS

SET NOCOUNT ON

SELECT
	[PK_Assoc_User_Group_ID],
	[FK_User_ID],
	[FK_Group_ID]
FROM
	[Assoc_User_Group]
WHERE
	[PK_Assoc_User_Group_ID] = @PK_Assoc_User_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_GroupSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_GroupSelectAll]
GO

CREATE PROCEDURE [dbo].[Assoc_User_GroupSelectAll] AS

SET NOCOUNT ON

SELECT
	[PK_Assoc_User_Group_ID],
	[FK_User_ID],
	[FK_Group_ID]
FROM
	[Assoc_User_Group]
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_GroupUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_GroupUpdate]
GO

CREATE PROCEDURE [dbo].[Assoc_User_GroupUpdate] (
	@PK_Assoc_User_Group_ID int,
	@FK_User_ID int,
	@FK_Group_ID int
)
AS

SET NOCOUNT ON

UPDATE
	[Assoc_User_Group]
SET
	[FK_User_ID] = @FK_User_ID,
	[FK_Group_ID] = @FK_Group_ID
WHERE
	 [PK_Assoc_User_Group_ID] = @PK_Assoc_User_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_GroupDeleteByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_GroupDeleteByPK]
GO

CREATE PROCEDURE [dbo].[Assoc_User_GroupDeleteByPK] (
	@PK_Assoc_User_Group_ID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[Assoc_User_Group]
WHERE
	[PK_Assoc_User_Group_ID] = @PK_Assoc_User_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_RightInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_RightInsert]
GO

CREATE PROCEDURE [dbo].[Assoc_User_RightInsert] (
	@FK_User_ID int,
	@FK_Right_ID int
)
AS

SET NOCOUNT ON

INSERT INTO [Assoc_User_Right] (
	[FK_User_ID],
	[FK_Right_ID]
) VALUES (
	@FK_User_ID,
	@FK_Right_ID
)

SELECT SCOPE_IDENTITY() AS PK_Assoc_User_Right_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_RightSelectByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_RightSelectByPK]
GO

CREATE PROCEDURE [dbo].[Assoc_User_RightSelectByPK] (
	@PK_Assoc_User_Right_ID int
)
AS

SET NOCOUNT ON

SELECT
	[PK_Assoc_User_Right_ID],
	[FK_User_ID],
	[FK_Right_ID]
FROM
	[Assoc_User_Right]
WHERE
	[PK_Assoc_User_Right_ID] = @PK_Assoc_User_Right_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_RightSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_RightSelectAll]
GO

CREATE PROCEDURE [dbo].[Assoc_User_RightSelectAll] AS

SET NOCOUNT ON

SELECT
	[PK_Assoc_User_Right_ID],
	[FK_User_ID],
	[FK_Right_ID]
FROM
	[Assoc_User_Right]
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_RightUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_RightUpdate]
GO

CREATE PROCEDURE [dbo].[Assoc_User_RightUpdate] (
	@PK_Assoc_User_Right_ID int,
	@FK_User_ID int,
	@FK_Right_ID int
)
AS

SET NOCOUNT ON

UPDATE
	[Assoc_User_Right]
SET
	[FK_User_ID] = @FK_User_ID,
	[FK_Right_ID] = @FK_Right_ID
WHERE
	 [PK_Assoc_User_Right_ID] = @PK_Assoc_User_Right_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_User_RightDeleteByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_User_RightDeleteByPK]
GO

CREATE PROCEDURE [dbo].[Assoc_User_RightDeleteByPK] (
	@PK_Assoc_User_Right_ID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[Assoc_User_Right]
WHERE
	[PK_Assoc_User_Right_ID] = @PK_Assoc_User_Right_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GroupInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[GroupInsert]
GO

CREATE PROCEDURE [dbo].[GroupInsert] (
	@Group_Name varchar(50)
)
AS

SET NOCOUNT ON

INSERT INTO [Group] (
	[Group_Name]
) VALUES (
	@Group_Name
)

SELECT SCOPE_IDENTITY() AS PK_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GroupSelectByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[GroupSelectByPK]
GO

CREATE PROCEDURE [dbo].[GroupSelectByPK] (
	@PK_Group_ID int
)
AS

SET NOCOUNT ON

SELECT
	[PK_Group_ID],
	[Group_Name]
FROM
	[Group]
WHERE
	[PK_Group_ID] = @PK_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GroupSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[GroupSelectAll]
GO

CREATE PROCEDURE [dbo].[GroupSelectAll] AS

SET NOCOUNT ON

SELECT
	[PK_Group_ID],
	[Group_Name]
FROM
	[Group]
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GroupUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[GroupUpdate]
GO

CREATE PROCEDURE [dbo].[GroupUpdate] (
	@PK_Group_ID int,
	@Group_Name varchar(50)
)
AS

SET NOCOUNT ON

UPDATE
	[Group]
SET
	[Group_Name] = @Group_Name
WHERE
	 [PK_Group_ID] = @PK_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GroupDeleteByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[GroupDeleteByPK]
GO

CREATE PROCEDURE [dbo].[GroupDeleteByPK] (
	@PK_Group_ID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[Group]
WHERE
	[PK_Group_ID] = @PK_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_Right_GroupInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_Right_GroupInsert]
GO

CREATE PROCEDURE [dbo].[Assoc_Right_GroupInsert] (
	@FK_Group_ID int,
	@FK_Right_ID int
)
AS

SET NOCOUNT ON

INSERT INTO [Assoc_Right_Group] (
	[FK_Group_ID],
	[FK_Right_ID]
) VALUES (
	@FK_Group_ID,
	@FK_Right_ID
)

SELECT SCOPE_IDENTITY() AS Assoc_Right_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_Right_GroupSelectByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_Right_GroupSelectByPK]
GO

CREATE PROCEDURE [dbo].[Assoc_Right_GroupSelectByPK] (
	@Assoc_Right_Group_ID int
)
AS

SET NOCOUNT ON

SELECT
	[Assoc_Right_Group_ID],
	[FK_Group_ID],
	[FK_Right_ID]
FROM
	[Assoc_Right_Group]
WHERE
	[Assoc_Right_Group_ID] = @Assoc_Right_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_Right_GroupSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_Right_GroupSelectAll]
GO

CREATE PROCEDURE [dbo].[Assoc_Right_GroupSelectAll] AS

SET NOCOUNT ON

SELECT
	[Assoc_Right_Group_ID],
	[FK_Group_ID],
	[FK_Right_ID]
FROM
	[Assoc_Right_Group]
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_Right_GroupUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_Right_GroupUpdate]
GO

CREATE PROCEDURE [dbo].[Assoc_Right_GroupUpdate] (
	@Assoc_Right_Group_ID int,
	@FK_Group_ID int,
	@FK_Right_ID int
)
AS

SET NOCOUNT ON

UPDATE
	[Assoc_Right_Group]
SET
	[FK_Group_ID] = @FK_Group_ID,
	[FK_Right_ID] = @FK_Right_ID
WHERE
	 [Assoc_Right_Group_ID] = @Assoc_Right_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Assoc_Right_GroupDeleteByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Assoc_Right_GroupDeleteByPK]
GO

CREATE PROCEDURE [dbo].[Assoc_Right_GroupDeleteByPK] (
	@Assoc_Right_Group_ID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[Assoc_Right_Group]
WHERE
	[Assoc_Right_Group_ID] = @Assoc_Right_Group_ID
GO

/****** Created Date :: 06-Oct-08    Created By :: Ravi Gupta  ******/ 

create proc [selectByGroupID]
(
 @FK_Group_ID int
)
as
select * from Assoc_Right_Group
where FK_Group_ID=@FK_Group_ID


/****** Created Date :: 07-Oct-08    Created By :: Ravi Patel ******/ 

if not exists (select * from syscolumns
  where id=object_id('Enviro_Equipment') and name='Capacity')
    alter table Enviro_Equipment add Capacity decimal(18,2) NULL
go

IF NOT EXISTS (select * from syscolumns
  where id=object_id('Enviro_Equipment') and name='Release_Equipment_Present')
    alter table Enviro_Equipment add Capacity bit NULL
go

EXEC sp_rename @objname = 'Enviro_Phase1.Frequency', 
			   @newname = 'ASSESSOR', 
			   @objtype = 'COLUMN'

IF NOT EXISTS (SELECT * FROM syscolumns
  WHERE id=object_id('Enviro_Phase1') and name='Phone')
	ALTER TABLE Enviro_Phase1 add Phone varchar(50) NULL
go

EXEC sp_rename 
    @objname = 'Enviro_SPCC.PK_Enviro_Inspection_ID', 
    @newname = 'PK_Enviro_SPCC_ID', 
    @objtype = 'COLUMN'

EXEC sp_rename 
    @objname = 'Enviro_SPCC.Frequency', 
    @newname = 'Plan_Preparer', 
    @objtype = 'COLUMN'
    
if not exists (select * from syscolumns
  where id=object_id('Enviro_SPCC') and name='Phone')
	alter table Enviro_SPCC add Phone varchar(50) NULL
go    


/****** Created Date :: 07-Oct-08    Created By :: Hetal Prajapati ******/

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Property_COPE](
	[PK_Property_Cope_ID] [numeric](20, 0) IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [numeric](20, 0) NULL,
	[Status] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status_As_Of_Date] [datetime] NULL,
	[Disposal_Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Union_shop] [bit] NULL,
	[Property_Boundary_Dimemsions] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address_1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address_2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telephone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Web_site] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Valuation_Date] [datetime] NULL,
	[Business_Interruption_Salaries] [numeric](18, 2) NULL,
	[Business_Interruption_Benefits] [numeric](18, 2) NULL,
	[Business_interruption_fixed_costs] [numeric](18, 2) NULL,
	[Business_interruption_net_profit] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Property_COPE_1] PRIMARY KEY CLUSTERED 
(
	[PK_Property_Cope_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Created Date :: 07-Oct-08    Created By :: Ravi Patel ******/

ALTER TABLE Enviro_Attachments
	ALTER Column folder int null


EXEC sp_rename 
    @objname = 'Enviro_Attachments.folder', 
    @newname = 'FK_Enviro_Attachments_Folder_ID', 
    @objtype = 'COLUMN'

USE [ERIMS_SONIC]
GO
/****** Object:  Table [dbo].[Enviro_Attachments_Folder]    Script Date: 10/07/2008 18:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enviro_Attachments_Folder](
	[PK_Enviro_Attachments_Folder_ID] [int] IDENTITY(1,1) NOT NULL,
	[Folder_Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Enviro_Attachments_Folder] PRIMARY KEY CLUSTERED 
(
	[PK_Enviro_Attachments_Folder_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Module]    Script Date: 10/08/2008 15:09:15 Ravi Gupta ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Module](
	[ModuleId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ModuleName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
/*********************** Inserting Values to Module Table Ravi Gupta *******************/
insert into module values('Sonic')
Go
insert into module values('Claim')
Go
insert into module values('Exposures')
Go


/****** Script Date: 10/08/2008 By: Ravi Gupta ******/
Create Procedure dbo.GetUserAccess 
(
@User_ID numeric(18,0)
)
as
select Module_ID,ModuleName,RightType_ID,RightType from [right] 
inner join Module on ModuleId=Module_ID
inner join RightType on RightTypeid=RightType_Id
where PK_Right_ID 
in (
	select distinct FK_Right_ID from Assoc_User_Group AUG 
	inner join Assoc_Right_Group ARG on ARG.FK_Group_Id=AUG.FK_Group_ID
	where AUG.FK_User_ID=@User_ID
	)






GO
/****** Object:  Table [dbo].[Property_COI]    Script Date: 10/09/2008  By: Hetal Prajapati******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Property_COI](
	[PK_Property_COI_ID] [numeric](20, 0) IDENTITY(1,1) NOT NULL,
	[FK_LU_Location_ID] [int] NOT NULL,
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Year] [int] NULL,
	[Path] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Filename] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Property_COI] PRIMARY KEY CLUSTERED 
(
	[PK_Property_COI_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

/****** Object:  Procedure [dbo].[ModuleSelectAll]    Script Date: 11/09/2008  By: Ravi Gupta******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ModuleSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ModuleSelectAll]
GO

CREATE PROCEDURE [dbo].[ModuleSelectAll] AS

SET NOCOUNT ON

SELECT
	[ModuleId],
	[ModuleName]
FROM
	[Module]
GO

/****** Object:  Procedure [dbo].[RightTypeSelectAll]    Script Date: 11/09/2008  By: Ravi Gupta******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightTypeSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightTypeSelectAll]
GO

CREATE PROCEDURE [dbo].[RightTypeSelectAll] AS

SET NOCOUNT ON

SELECT
	[RightTypeId],
	[RightType]
FROM
	[RightType]
GO

/****** Object:  Procedure [dbo].[RightInsert]    Script Date: 11/09/2008  By: Ravi Gupta******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightInsert]
GO

CREATE PROCEDURE [dbo].[RightInsert] (
	@Right_Name varchar(50),
	@Module_ID numeric(18, 0),
	@RightType_ID numeric(18, 0)
)
AS

SET NOCOUNT ON

INSERT INTO [Right] (
	[Right_Name],
	[Module_ID],
	[RightType_ID]
) VALUES (
	@Right_Name,
	@Module_ID,
	@RightType_ID
)

SELECT SCOPE_IDENTITY() AS PK_Right_ID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightSelectByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightSelectByPK]
GO

CREATE PROCEDURE [dbo].[RightSelectByPK] (
	@PK_Right_ID int
)
AS

SET NOCOUNT ON

SELECT
	[PK_Right_ID],
	[Right_Name],
	[Module_ID],
	[RightType_ID]
FROM
	[Right]
WHERE
	[PK_Right_ID] = @PK_Right_ID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightSelectAll]
GO

CREATE PROCEDURE [dbo].[RightSelectAll] AS

SET NOCOUNT ON

SELECT
	[PK_Right_ID],
	[Right_Name],
	[Module_ID],
	[RightType_ID]
FROM
	[Right]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightUpdate]
GO

CREATE PROCEDURE [dbo].[RightUpdate] (
	@PK_Right_ID int,
	@Right_Name varchar(50),
	@Module_ID numeric(18, 0),
	@RightType_ID numeric(18, 0)
)
AS

SET NOCOUNT ON

UPDATE
	[Right]
SET
	[Right_Name] = @Right_Name,
	[Module_ID] = @Module_ID,
	[RightType_ID] = @RightType_ID
WHERE
	 [PK_Right_ID] = @PK_Right_ID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RightDeleteByPK]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RightDeleteByPK]
GO

CREATE PROCEDURE [dbo].[RightDeleteByPK] (
	@PK_Right_ID int
)
AS

SET NOCOUNT ON

DELETE FROM
	[Right]
WHERE
	[PK_Right_ID] = @PK_Right_ID
GO

  
Alter PROCEDURE [dbo].[RightInsert] (  
 @Right_Name varchar(50),  
 @Module_ID numeric(18, 0),  
 @RightType_ID numeric(18, 0)  
)  
AS  
  
SET NOCOUNT ON  
if not Exists(select [Right_Name] from [Right] where [Right_Name] = @Right_Name)        
Begin
INSERT INTO [Right] (  
 [Right_Name],  
 [Module_ID],  
 [RightType_ID]  
) VALUES (  
 @Right_Name,  
 @Module_ID,  
 @RightType_ID  
)  
SELECT SCOPE_IDENTITY() AS PK_Right_ID  
End
Else        
select -2 as PK_Security_ID 

  
Alter PROCEDURE [dbo].[GroupInsert] (  
 @Group_Name varchar(50)  
)  
AS  
  
SET NOCOUNT ON  
if not Exists(select [Group_Name] from [Group] where [Group_Name] = @Group_Name)        
Begin 
INSERT INTO [Group] (  
 [Group_Name]  
) VALUES (  
 @Group_Name  
)  
  
SELECT SCOPE_IDENTITY() AS PK_Group_ID  
End
Else        
select -2 as PK_Group_ID 

/****** Object:  Procedure [dbo].[RightInsert]    Script Date: 15/09/2008  By: Ravi Gupta******/
Alter PROCEDURE [dbo].[RightInsert] (    
 @Right_Name varchar(50),    
 @Module_ID numeric(18, 0),    
 @RightType_ID numeric(18, 0)    
)    
AS    
    
SET NOCOUNT ON    
if not Exists(select [Right_Name] from [Right] where [Right_Name] = @Right_Name)          
Begin  
 if not Exists(select [Right_Name] from [right] where Module_ID=@Module_ID and RightType_ID=@RightType_ID)
 Begin
	INSERT INTO [Right] (    
	 [Right_Name],    
	 [Module_ID],    
	 [RightType_ID]    
	) VALUES (    
	 @Right_Name,    
	 @Module_ID,    
	 @RightType_ID    
	)    
	SELECT SCOPE_IDENTITY() AS PK_Right_ID    
 End
 Else
 select -3 as PK_Security_ID
End  
Else          
select -2 as PK_Security_ID 


/****** Object: Enviro_SPCC  Script Date: 16/10/2008  By: Ravi Patel******/

alter table Enviro_SPCC alter column cost decimal(18,2) NULL

/****** Object: Enviro_Inspection  Script Date: 16/10/2008  By: Ravi Patel******/

alter table Enviro_Inspection alter column cost decimal(18,2) NULL

/****** Object: Enviro_Phase1  Script Date: 16/10/2008  By: Ravi Patel******/

alter table Enviro_Phase1 alter column cost decimal(18,2) NULL

/****** Object: Assoc_User_GroupDeleteByUser  Script Date: 16/10/2008  By: Ravi Gupta******/
create procedure [dbo].[Assoc_User_GroupDeleteByUser]
(
@FK_User_ID int
)
as
delete from Assoc_User_Group where FK_User_ID=@FK_User_ID
Go

/****** Object: Assoc_User_RightDeleteByUserID  Script Date: 16/10/2008  By: Ravi Gupta******/
CREATE PROCEDURE [dbo].[Assoc_User_RightDeleteByUserID] (  
 @FK_User_ID int  
)  
AS  
  
SET NOCOUNT ON  
  
DELETE FROM  
 [Assoc_User_Right]  
WHERE  
 [FK_User_ID] = @FK_User_ID  
Go

/****** Object: Assoc_User_RightDeleteByUserID  Script Date: 16/10/2008  By: Ravi Gupta******/
Create Proc [dbo].[Assoc_User_RightSelectByUserID]
(
@Fk_User_ID int
)
as
select * from [Assoc_User_Right]  where Fk_User_ID=@Fk_User_ID
Go

/****** Object: Assoc_User_RightDeleteByUserID  Script Date: 16/10/2008  By: Ravi Gupta******/
Create Proc [dbo].[Assoc_User_GroupSelectByUserID]
(
@Fk_User_ID int
)
as
select * from [Assoc_User_Group]  where Fk_User_ID=@Fk_User_ID


/****** Object: enviro_recommendations Script Date: 17/10/2008  By: Ravi Patel******/

alter table enviro_recommendations alter column description text null

alter table enviro_recommendations alter column resolution text null

/****** Object: GroupUpdate Script Date: 20/10/2008  By: Ravi Gupta******/  
Alter PROCEDURE [dbo].[GroupUpdate] (  
 @PK_Group_ID int,  
 @Group_Name varchar(50)  
)  
AS  
  
SET NOCOUNT ON  
if not Exists(select [Group_Name] from [Group] where [Group_Name] = @Group_Name)          
Begin   
UPDATE  
 [Group]  
SET  
 [Group_Name] = @Group_Name  
WHERE  
  [PK_Group_ID] = @PK_Group_ID  
SELECT @PK_Group_ID AS PK_Group_ID    
End  
Else          
select -2 as PK_Group_ID 
Go

/****** Object: Assoc_Right_GroupDeleteByGroup Script Date: 20/10/2008  By: Ravi Gupta******/  
create proc Assoc_Right_GroupDeleteByGroup
(
@FK_Group_ID numeric(18,0)
)
as
Begin
delete from Assoc_Right_Group where FK_Group_ID=@FK_Group_ID
End

/****** Object: SecurityDeleteByPKs Script Date: 20/10/2008  By: Ravi Gupta******/  
 Alter Procedure dbo.SecurityDeleteByPKs     
  (      
  @PK_Security_ID nvarchar(200)      
  )      
  as      
  declare @ID numeric(20,0)  
  declare TempCur cursor for select * from fnSplit(@PK_Security_ID, ',')  
  open TempCur  
  fetch NEXT from TempCur into @ID  
  while @@FETCH_STATUS=0  
  begin  
   delete from Security where PK_Security_ID in (@ID)  
   delete from Assoc_User_Group where FK_User_ID in (@ID)
   delete from Assoc_User_Right where FK_User_ID in (@ID)
   fetch NEXT from TempCur into @ID  
  end  
  
  Go

/****** Object: GroupUpdate Script Date: 21/10/2008  By: Ravi Gupta******/  
--GroupUpdate 30, 'All View'
Alter PROCEDURE [dbo].[GroupUpdate] (      
 @PK_Group_ID int,      
 @Group_Name varchar(50)      
)      
AS      
      
SET NOCOUNT ON      
if not Exists(select * from [Group] where Group_Name=@Group_Name and PK_Group_ID not in(@PK_Group_ID))              
Begin       
UPDATE      
 [Group]      
SET      
 [Group_Name] = @Group_Name      
WHERE      
  [PK_Group_ID] = @PK_Group_ID      
SELECT @PK_Group_ID AS PK_Group_ID        
End      
Else              
select -2 as PK_Group_ID 

Go
/****** Object: Assoc_User_RightSelectByUserID Script Date: 22/10/2008  By: Ravi Gupta******/  
Alter Proc [dbo].[Assoc_User_RightSelectByUserID]  
(    
@Fk_User_ID int    
)    
as    
create table #Temp
(
FK_User_ID numeric(18,0),
FK_Right_ID numeric(18,0),
IsAdditional bit
)
insert into #Temp
select FK_User_ID,FK_Right_ID,1  from [Assoc_User_Right]    
where Fk_User_ID=@Fk_User_ID  
union  
select FK_User_ID,FK_Right_ID,0 from [Assoc_User_Group] AUG  
inner join [Assoc_Right_Group] ARG on ARG.FK_Group_ID=AUG.FK_Group_ID  
where AUG.FK_User_ID=@Fk_User_ID  

select * from #Temp
Drop table #Temp

Go

/****** Object: GetUserAccess Script Date: 22/10/2008  By: Ravi Gupta******/  
Alter Procedure dbo.GetUserAccess
(    
@User_ID numeric(18,0)    
)    
as    
select Module_ID,ModuleName,RightType_ID,RightType from [right]     
inner join Module on ModuleId=Module_ID    
inner join RightType on RightTypeid=RightType_Id    
where PK_Right_ID     
in (    
	select FK_Right_ID  from [Assoc_User_Right]    
	where Fk_User_ID=@User_ID  
	union  
	select FK_Right_ID from [Assoc_User_Group] AUG  
	inner join [Assoc_Right_Group] ARG on ARG.FK_Group_ID=AUG.FK_Group_ID  
	where AUG.FK_User_ID=@User_ID     
 )    

Go

/****** Object: GetUserAssociateWithGroup Script Date: 23/10/2008  By: Ravi Gupta******/  
create procedure dbo.[GetUserAssociateWithGroup] 
(
@FK_Group_ID numeric(18,0)
)
as
select count(*) as Total from [Assoc_User_Group]  where FK_Group_ID=@FK_Group_ID


/****** Object: Enviro_equipment Script Date: 01/11/2008  By: Ravi Patel ******/  

ALTER TABLE Enviro_equipment 
ALTER COLUMN Release_Equipment_Description TEXT NULL

/****** Object: Enviro_equipment Script Date: 04/11/2008  By: Ravi Patel ******/  

ALTER TABLE Enviro_attachments
ALTER COLUMN path VARCHAR(200) NULL

