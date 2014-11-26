using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for AP_Property_Security table.
    /// </summary>
    public sealed class clsAP_Property_Security
    {

        #region Private variables used to hold the property values

        private decimal? _PK_AP_Property_Security;
        private decimal? _FK_LU_Location_Id;
        private string _CCTV_Company_Name;
        private string _CCTV_Company_Address_1;
        private string _CCTV_Company_Address_2;
        private string _CCTV_Company_City;
        private decimal? _FK_CCTV_Company_State;
        private string _CCTV_Company_Zip;
        private string _CCTV_Company_Contact_Name;
        private string _CCTV_Comapny_Contact_Telephone;
        private string _CCTV_Company_Contact_EMail;
        private string _Cal_Atlantic_System;
        private string _Live_Monitoring;
        private string _Hours_Monitored_From;
        private string _Hours_Monitored_To;
        private string _ECC_Back;
        private string _ECC_Car_Wash;
        private string _ECC_Front;
        private string _ECC_Satellite_Parking;
        private string _ECC_Side;
        private string _ECC_Zero_Lot_Line;
        private string _ECC_Other;
        private string _Exterior_Camera_Coverage_Other_Description;
        private string _ICC_Body_Shop;
        private string _ICC_Cashier;
        private string _ICC_Computer_Room;
        private string _ICC_Detail_Bays;
        private string _ICC_Key_Box_Area;
        private string _ICC_Parts_Receiving_Area;
        private string _ICC_Service_Department;
        private string _ICC_Service_Lane;
        private string _ICC_Showroom;
        private string _ICC_Smart_Safe_Office;
        private string _ICC_Other;
        private string _Interior_Camera_Coverage_Other_Description;
        private string _Buglar_Alarm_System;
        private string _Is_System_Active_and_Function_Properly;
        private string _Burglar_Alarm_Company_Name;
        private string _Burglar_Alarm_Company_Address_1;
        private string _Burglar_Alarm_Company_Address_2;
        private string _Burglar_Alarm_Company_City;
        private decimal? _FK_Burglar_Alarm_Company_State;
        private string _Burglar_Alarm_Company_Zip;
        private string _Burglar_Alarm_Company_Contact_Name;
        private string _Burglar_Alarm_Comapny_Contact_Telephone;
        private string _Burglar_Alarm_Company_Contact_EMail;
        private string _ZD_Collision_Center;
        private string _ZD_Office;
        private string _ZD_Parts;
        private string _ZD_Sales_Showroom;
        private string _ZD_Sales;
        private string _ZD_Other;
        private string _Burglar_Alarm_Coverage_Other_Description;
        private string _Burglar_Alarm_Coverage_Comments;
        private string _Guard_Company_Name;
        private string _Guard_Company_Address_1;
        private string _Guard_Company_Address_2;
        private string _Guard_Company_City;
        private decimal? _FK_Guard_Company_State;
        private string _Guard_Company_Zip;
        private string _Guard_Company_Contact_Name;
        private string _Guard_Comapny_Contact_Telephone;
        private string _Guard_Company_Contact_EMail;
        private string _Guard_Hours_Monitored_From;
        private string _Guard_Hours_Monitored_To;
        private string _OffDuty_Officer_Name;
        private string _OffDuty_Officer_Telephone;
        private string _OffDuty_Officer_Hours_Monitored_From;
        private string _OffDuty_Officer_Hours_Monitored_To;
        private string _AC_1st_Floor_Only;
        private string _AC_Business_Area;
        private string _AC_Cashier;
        private string _AC_Computer_Room;
        private string _AC_Controller_Office;
        private string _AC_EnterExit_Building;
        private string _AC_F_and_I_Office;
        private string _AC_GM_Office;
        private string _AC_Multiple_Floors;
        private string _AC_Parts;
        private string _AC_Smart_Sales_Office;
        private string _AC_Other;
        private string _Access_Control_Other_Description;
        private string _FG_EntranceExit_Alarms;
        private string _FG_EntranceExit_Gate;
        private string _F_Back;
        private string _F_Entire_Perimeter;
        private string _F_Front;
        private string _F_Satellite_Parking_Lot;
        private string _F_Side;
        private string _P_Back;
        private string _P_Entire_Perimeter;
        private string _P_Front;
        private string _P_Satellite_Parking_Lot;
        private string _P_Side;
        private string _SITS_Auto_Tracks;
        private string _SITS_Key_Tracks;
        private string _SITS_Other;
        private string _Security_Inventory_Tracking_System_Other_Description;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private int? _Cap_Index_Crime_Score;
        private decimal? _Cap_Index_Risk_Cateogory;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_AP_Property_Security value.
        /// </summary>
        public decimal? PK_AP_Property_Security
        {
            get { return _PK_AP_Property_Security; }
            set { _PK_AP_Property_Security = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location_Id value.
        /// </summary>
        public decimal? FK_LU_Location_Id
        {
            get { return _FK_LU_Location_Id; }
            set { _FK_LU_Location_Id = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Company_Name value.
        /// </summary>
        public string CCTV_Company_Name
        {
            get { return _CCTV_Company_Name; }
            set { _CCTV_Company_Name = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Company_Address_1 value.
        /// </summary>
        public string CCTV_Company_Address_1
        {
            get { return _CCTV_Company_Address_1; }
            set { _CCTV_Company_Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Company_Address_2 value.
        /// </summary>
        public string CCTV_Company_Address_2
        {
            get { return _CCTV_Company_Address_2; }
            set { _CCTV_Company_Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Company_City value.
        /// </summary>
        public string CCTV_Company_City
        {
            get { return _CCTV_Company_City; }
            set { _CCTV_Company_City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_CCTV_Company_State value.
        /// </summary>
        public decimal? FK_CCTV_Company_State
        {
            get { return _FK_CCTV_Company_State; }
            set { _FK_CCTV_Company_State = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Company_Zip value.
        /// </summary>
        public string CCTV_Company_Zip
        {
            get { return _CCTV_Company_Zip; }
            set { _CCTV_Company_Zip = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Company_Contact_Name value.
        /// </summary>
        public string CCTV_Company_Contact_Name
        {
            get { return _CCTV_Company_Contact_Name; }
            set { _CCTV_Company_Contact_Name = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Comapny_Contact_Telephone value.
        /// </summary>
        public string CCTV_Comapny_Contact_Telephone
        {
            get { return _CCTV_Comapny_Contact_Telephone; }
            set { _CCTV_Comapny_Contact_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the CCTV_Company_Contact_E-Mail value.
        /// </summary>
        public string CCTV_Company_Contact_EMail
        {
            get { return _CCTV_Company_Contact_EMail; }
            set { _CCTV_Company_Contact_EMail = value; }
        }

        /// <summary>
        /// Gets or sets the Cal-Atlantic_System value.
        /// </summary>
        public string Cal_Atlantic_System
        {
            get { return _Cal_Atlantic_System; }
            set { _Cal_Atlantic_System = value; }
        }

        /// <summary>
        /// Gets or sets the Live_Monitoring value.
        /// </summary>
        public string Live_Monitoring
        {
            get { return _Live_Monitoring; }
            set { _Live_Monitoring = value; }
        }

        /// <summary>
        /// Gets or sets the Hours_Monitored_From value.
        /// </summary>
        public string Hours_Monitored_From
        {
            get { return _Hours_Monitored_From; }
            set { _Hours_Monitored_From = value; }
        }

        /// <summary>
        /// Gets or sets the Hours_Monitored_To value.
        /// </summary>
        public string Hours_Monitored_To
        {
            get { return _Hours_Monitored_To; }
            set { _Hours_Monitored_To = value; }
        }

        /// <summary>
        /// Gets or sets the ECC_Back value.
        /// </summary>
        public string ECC_Back
        {
            get { return _ECC_Back; }
            set { _ECC_Back = value; }
        }

        /// <summary>
        /// Gets or sets the ECC_Car_Wash value.
        /// </summary>
        public string ECC_Car_Wash
        {
            get { return _ECC_Car_Wash; }
            set { _ECC_Car_Wash = value; }
        }

        /// <summary>
        /// Gets or sets the ECC_Front value.
        /// </summary>
        public string ECC_Front
        {
            get { return _ECC_Front; }
            set { _ECC_Front = value; }
        }

        /// <summary>
        /// Gets or sets the ECC_Satellite_Parking value.
        /// </summary>
        public string ECC_Satellite_Parking
        {
            get { return _ECC_Satellite_Parking; }
            set { _ECC_Satellite_Parking = value; }
        }

        /// <summary>
        /// Gets or sets the ECC_Side value.
        /// </summary>
        public string ECC_Side
        {
            get { return _ECC_Side; }
            set { _ECC_Side = value; }
        }

        /// <summary>
        /// Gets or sets the ECC_Zero_Lot_Line value.
        /// </summary>
        public string ECC_Zero_Lot_Line
        {
            get { return _ECC_Zero_Lot_Line; }
            set { _ECC_Zero_Lot_Line = value; }
        }

        /// <summary>
        /// Gets or sets the ECC_Other value.
        /// </summary>
        public string ECC_Other
        {
            get { return _ECC_Other; }
            set { _ECC_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Exterior_Camera_Coverage_-_Other_Description value.
        /// </summary>
        public string Exterior_Camera_Coverage_Other_Description
        {
            get { return _Exterior_Camera_Coverage_Other_Description; }
            set { _Exterior_Camera_Coverage_Other_Description = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Body_Shop value.
        /// </summary>
        public string ICC_Body_Shop
        {
            get { return _ICC_Body_Shop; }
            set { _ICC_Body_Shop = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Cashier value.
        /// </summary>
        public string ICC_Cashier
        {
            get { return _ICC_Cashier; }
            set { _ICC_Cashier = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Computer_Room value.
        /// </summary>
        public string ICC_Computer_Room
        {
            get { return _ICC_Computer_Room; }
            set { _ICC_Computer_Room = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Detail_Bays value.
        /// </summary>
        public string ICC_Detail_Bays
        {
            get { return _ICC_Detail_Bays; }
            set { _ICC_Detail_Bays = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Key_Box_Area value.
        /// </summary>
        public string ICC_Key_Box_Area
        {
            get { return _ICC_Key_Box_Area; }
            set { _ICC_Key_Box_Area = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Parts_Receiving_Area value.
        /// </summary>
        public string ICC_Parts_Receiving_Area
        {
            get { return _ICC_Parts_Receiving_Area; }
            set { _ICC_Parts_Receiving_Area = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Service_Department value.
        /// </summary>
        public string ICC_Service_Department
        {
            get { return _ICC_Service_Department; }
            set { _ICC_Service_Department = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Service_Lane value.
        /// </summary>
        public string ICC_Service_Lane
        {
            get { return _ICC_Service_Lane; }
            set { _ICC_Service_Lane = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Showroom value.
        /// </summary>
        public string ICC_Showroom
        {
            get { return _ICC_Showroom; }
            set { _ICC_Showroom = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Smart_Safe_Office value.
        /// </summary>
        public string ICC_Smart_Safe_Office
        {
            get { return _ICC_Smart_Safe_Office; }
            set { _ICC_Smart_Safe_Office = value; }
        }

        /// <summary>
        /// Gets or sets the ICC_Other value.
        /// </summary>
        public string ICC_Other
        {
            get { return _ICC_Other; }
            set { _ICC_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Interior_Camera_Coverage_-_Other_Description value.
        /// </summary>
        public string Interior_Camera_Coverage_Other_Description
        {
            get { return _Interior_Camera_Coverage_Other_Description; }
            set { _Interior_Camera_Coverage_Other_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Buglar_Alarm_System value.
        /// </summary>
        public string Buglar_Alarm_System
        {
            get { return _Buglar_Alarm_System; }
            set { _Buglar_Alarm_System = value; }
        }

        /// <summary>
        /// Gets or sets the Is_System_Active_and_Function_Properly value.
        /// </summary>
        public string Is_System_Active_and_Function_Properly
        {
            get { return _Is_System_Active_and_Function_Properly; }
            set { _Is_System_Active_and_Function_Properly = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Company_Name value.
        /// </summary>
        public string Burglar_Alarm_Company_Name
        {
            get { return _Burglar_Alarm_Company_Name; }
            set { _Burglar_Alarm_Company_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Company_Address_1 value.
        /// </summary>
        public string Burglar_Alarm_Company_Address_1
        {
            get { return _Burglar_Alarm_Company_Address_1; }
            set { _Burglar_Alarm_Company_Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Company_Address_2 value.
        /// </summary>
        public string Burglar_Alarm_Company_Address_2
        {
            get { return _Burglar_Alarm_Company_Address_2; }
            set { _Burglar_Alarm_Company_Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Company_City value.
        /// </summary>
        public string Burglar_Alarm_Company_City
        {
            get { return _Burglar_Alarm_Company_City; }
            set { _Burglar_Alarm_Company_City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Burglar_Alarm_Company_State value.
        /// </summary>
        public decimal? FK_Burglar_Alarm_Company_State
        {
            get { return _FK_Burglar_Alarm_Company_State; }
            set { _FK_Burglar_Alarm_Company_State = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Company_Zip value.
        /// </summary>
        public string Burglar_Alarm_Company_Zip
        {
            get { return _Burglar_Alarm_Company_Zip; }
            set { _Burglar_Alarm_Company_Zip = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Company_Contact_Name value.
        /// </summary>
        public string Burglar_Alarm_Company_Contact_Name
        {
            get { return _Burglar_Alarm_Company_Contact_Name; }
            set { _Burglar_Alarm_Company_Contact_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Comapny_Contact_Telephone value.
        /// </summary>
        public string Burglar_Alarm_Comapny_Contact_Telephone
        {
            get { return _Burglar_Alarm_Comapny_Contact_Telephone; }
            set { _Burglar_Alarm_Comapny_Contact_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Company_Contact_E-Mail value.
        /// </summary>
        public string Burglar_Alarm_Company_Contact_EMail
        {
            get { return _Burglar_Alarm_Company_Contact_EMail; }
            set { _Burglar_Alarm_Company_Contact_EMail = value; }
        }

        /// <summary>
        /// Gets or sets the ZD_Collision_Center value.
        /// </summary>
        public string ZD_Collision_Center
        {
            get { return _ZD_Collision_Center; }
            set { _ZD_Collision_Center = value; }
        }

        /// <summary>
        /// Gets or sets the ZD_Office value.
        /// </summary>
        public string ZD_Office
        {
            get { return _ZD_Office; }
            set { _ZD_Office = value; }
        }

        /// <summary>
        /// Gets or sets the ZD_Parts value.
        /// </summary>
        public string ZD_Parts
        {
            get { return _ZD_Parts; }
            set { _ZD_Parts = value; }
        }

        /// <summary>
        /// Gets or sets the ZD_Sales_Showroom value.
        /// </summary>
        public string ZD_Sales_Showroom
        {
            get { return _ZD_Sales_Showroom; }
            set { _ZD_Sales_Showroom = value; }
        }

        /// <summary>
        /// Gets or sets the ZD_Sales value.
        /// </summary>
        public string ZD_Sales
        {
            get { return _ZD_Sales; }
            set { _ZD_Sales = value; }
        }

        /// <summary>
        /// Gets or sets the ZD_Other value.
        /// </summary>
        public string ZD_Other
        {
            get { return _ZD_Other; }
            set { _ZD_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Coverage_-_Other_Description value.
        /// </summary>
        public string Burglar_Alarm_Coverage_Other_Description
        {
            get { return _Burglar_Alarm_Coverage_Other_Description; }
            set { _Burglar_Alarm_Coverage_Other_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Burglar_Alarm_Coverage_Comments value.
        /// </summary>
        public string Burglar_Alarm_Coverage_Comments
        {
            get { return _Burglar_Alarm_Coverage_Comments; }
            set { _Burglar_Alarm_Coverage_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Company_Name value.
        /// </summary>
        public string Guard_Company_Name
        {
            get { return _Guard_Company_Name; }
            set { _Guard_Company_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Company_Address_1 value.
        /// </summary>
        public string Guard_Company_Address_1
        {
            get { return _Guard_Company_Address_1; }
            set { _Guard_Company_Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Company_Address_2 value.
        /// </summary>
        public string Guard_Company_Address_2
        {
            get { return _Guard_Company_Address_2; }
            set { _Guard_Company_Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Company_City value.
        /// </summary>
        public string Guard_Company_City
        {
            get { return _Guard_Company_City; }
            set { _Guard_Company_City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Guard_Company_State value.
        /// </summary>
        public decimal? FK_Guard_Company_State
        {
            get { return _FK_Guard_Company_State; }
            set { _FK_Guard_Company_State = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Company_Zip value.
        /// </summary>
        public string Guard_Company_Zip
        {
            get { return _Guard_Company_Zip; }
            set { _Guard_Company_Zip = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Company_Contact_Name value.
        /// </summary>
        public string Guard_Company_Contact_Name
        {
            get { return _Guard_Company_Contact_Name; }
            set { _Guard_Company_Contact_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Comapny_Contact_Telephone value.
        /// </summary>
        public string Guard_Comapny_Contact_Telephone
        {
            get { return _Guard_Comapny_Contact_Telephone; }
            set { _Guard_Comapny_Contact_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Company_Contact_E-Mail value.
        /// </summary>
        public string Guard_Company_Contact_EMail
        {
            get { return _Guard_Company_Contact_EMail; }
            set { _Guard_Company_Contact_EMail = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Hours_Monitored_From value.
        /// </summary>
        public string Guard_Hours_Monitored_From
        {
            get { return _Guard_Hours_Monitored_From; }
            set { _Guard_Hours_Monitored_From = value; }
        }

        /// <summary>
        /// Gets or sets the Guard_Hours_Monitored_To value.
        /// </summary>
        public string Guard_Hours_Monitored_To
        {
            get { return _Guard_Hours_Monitored_To; }
            set { _Guard_Hours_Monitored_To = value; }
        }

        /// <summary>
        /// Gets or sets the Off-Duty_Officer_Name value.
        /// </summary>
        public string OffDuty_Officer_Name
        {
            get { return _OffDuty_Officer_Name; }
            set { _OffDuty_Officer_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Off-Duty_Officer_Telephone value.
        /// </summary>
        public string OffDuty_Officer_Telephone
        {
            get { return _OffDuty_Officer_Telephone; }
            set { _OffDuty_Officer_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Off-Duty_Officer_Hours_Monitored_From value.
        /// </summary>
        public string OffDuty_Officer_Hours_Monitored_From
        {
            get { return _OffDuty_Officer_Hours_Monitored_From; }
            set { _OffDuty_Officer_Hours_Monitored_From = value; }
        }

        /// <summary>
        /// Gets or sets the Off-Duty_Officer_Hours_Monitored_To value.
        /// </summary>
        public string OffDuty_Officer_Hours_Monitored_To
        {
            get { return _OffDuty_Officer_Hours_Monitored_To; }
            set { _OffDuty_Officer_Hours_Monitored_To = value; }
        }

        /// <summary>
        /// Gets or sets the AC_1st_Floor_Only value.
        /// </summary>
        public string AC_1st_Floor_Only
        {
            get { return _AC_1st_Floor_Only; }
            set { _AC_1st_Floor_Only = value; }
        }

        /// <summary>
        /// Gets or sets the AC_Business_Area value.
        /// </summary>
        public string AC_Business_Area
        {
            get { return _AC_Business_Area; }
            set { _AC_Business_Area = value; }
        }

        /// <summary>
        /// Gets or sets the AC_Cashier value.
        /// </summary>
        public string AC_Cashier
        {
            get { return _AC_Cashier; }
            set { _AC_Cashier = value; }
        }

        /// <summary>
        /// Gets or sets the AC_Computer_Room value.
        /// </summary>
        public string AC_Computer_Room
        {
            get { return _AC_Computer_Room; }
            set { _AC_Computer_Room = value; }
        }

        /// <summary>
        /// Gets or sets the AC_Controller_Office value.
        /// </summary>
        public string AC_Controller_Office
        {
            get { return _AC_Controller_Office; }
            set { _AC_Controller_Office = value; }
        }

        /// <summary>
        /// Gets or sets the AC_Enter-Exit_Building value.
        /// </summary>
        public string AC_EnterExit_Building
        {
            get { return _AC_EnterExit_Building; }
            set { _AC_EnterExit_Building = value; }
        }

        /// <summary>
        /// Gets or sets the AC_F_and_I_Office value.
        /// </summary>
        public string AC_F_and_I_Office
        {
            get { return _AC_F_and_I_Office; }
            set { _AC_F_and_I_Office = value; }
        }

        /// <summary>
        /// Gets or sets the AC_GM_Office value.
        /// </summary>
        public string AC_GM_Office
        {
            get { return _AC_GM_Office; }
            set { _AC_GM_Office = value; }
        }

        /// <summary>
        /// Gets or sets the AC_Multiple_Floors value.
        /// </summary>
        public string AC_Multiple_Floors
        {
            get { return _AC_Multiple_Floors; }
            set { _AC_Multiple_Floors = value; }
        }

        /// <summary>
        /// Gets or sets the AC_Parts value.
        /// </summary>
        public string AC_Parts
        {
            get { return _AC_Parts; }
            set { _AC_Parts = value; }
        }

        /// <summary>
        /// Gets or sets the AC_Smart_Sales_Office value.
        /// </summary>
        public string AC_Smart_Sales_Office
        {
            get { return _AC_Smart_Sales_Office; }
            set { _AC_Smart_Sales_Office = value; }
        }

        /// <summary>
        /// Gets or sets the AC_Other value.
        /// </summary>
        public string AC_Other
        {
            get { return _AC_Other; }
            set { _AC_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Access_Control_-_Other_Description value.
        /// </summary>
        public string Access_Control_Other_Description
        {
            get { return _Access_Control_Other_Description; }
            set { _Access_Control_Other_Description = value; }
        }

        /// <summary>
        /// Gets or sets the FG_Entrance-Exit_Alarms value.
        /// </summary>
        public string FG_EntranceExit_Alarms
        {
            get { return _FG_EntranceExit_Alarms; }
            set { _FG_EntranceExit_Alarms = value; }
        }

        /// <summary>
        /// Gets or sets the FG_Entrance-Exit_Gate value.
        /// </summary>
        public string FG_EntranceExit_Gate
        {
            get { return _FG_EntranceExit_Gate; }
            set { _FG_EntranceExit_Gate = value; }
        }

        /// <summary>
        /// Gets or sets the F_Back value.
        /// </summary>
        public string F_Back
        {
            get { return _F_Back; }
            set { _F_Back = value; }
        }

        /// <summary>
        /// Gets or sets the F_Entire_Perimeter value.
        /// </summary>
        public string F_Entire_Perimeter
        {
            get { return _F_Entire_Perimeter; }
            set { _F_Entire_Perimeter = value; }
        }

        /// <summary>
        /// Gets or sets the F_Front value.
        /// </summary>
        public string F_Front
        {
            get { return _F_Front; }
            set { _F_Front = value; }
        }

        /// <summary>
        /// Gets or sets the F_Satellite_Parking_Lot value.
        /// </summary>
        public string F_Satellite_Parking_Lot
        {
            get { return _F_Satellite_Parking_Lot; }
            set { _F_Satellite_Parking_Lot = value; }
        }

        /// <summary>
        /// Gets or sets the F_Side value.
        /// </summary>
        public string F_Side
        {
            get { return _F_Side; }
            set { _F_Side = value; }
        }

        /// <summary>
        /// Gets or sets the P_Back value.
        /// </summary>
        public string P_Back
        {
            get { return _P_Back; }
            set { _P_Back = value; }
        }

        /// <summary>
        /// Gets or sets the P_Entire_Perimeter value.
        /// </summary>
        public string P_Entire_Perimeter
        {
            get { return _P_Entire_Perimeter; }
            set { _P_Entire_Perimeter = value; }
        }

        /// <summary>
        /// Gets or sets the P_Front value.
        /// </summary>
        public string P_Front
        {
            get { return _P_Front; }
            set { _P_Front = value; }
        }

        /// <summary>
        /// Gets or sets the P_Satellite_Parking_Lot value.
        /// </summary>
        public string P_Satellite_Parking_Lot
        {
            get { return _P_Satellite_Parking_Lot; }
            set { _P_Satellite_Parking_Lot = value; }
        }

        /// <summary>
        /// Gets or sets the P_Side value.
        /// </summary>
        public string P_Side
        {
            get { return _P_Side; }
            set { _P_Side = value; }
        }

        /// <summary>
        /// Gets or sets the SITS_Auto_Tracks value.
        /// </summary>
        public string SITS_Auto_Tracks
        {
            get { return _SITS_Auto_Tracks; }
            set { _SITS_Auto_Tracks = value; }
        }

        /// <summary>
        /// Gets or sets the SITS_Key_Tracks value.
        /// </summary>
        public string SITS_Key_Tracks
        {
            get { return _SITS_Key_Tracks; }
            set { _SITS_Key_Tracks = value; }
        }

        /// <summary>
        /// Gets or sets the SITS_Other value.
        /// </summary>
        public string SITS_Other
        {
            get { return _SITS_Other; }
            set { _SITS_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Security_Inventory_Tracking_System_-_Other_Description value.
        /// </summary>
        public string Security_Inventory_Tracking_System_Other_Description
        {
            get { return _Security_Inventory_Tracking_System_Other_Description; }
            set { _Security_Inventory_Tracking_System_Other_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Cap_Index_Crime_Score value.
        /// </summary>
        public int? Cap_Index_Crime_Score
        {
            get { return _Cap_Index_Crime_Score; }
            set { _Cap_Index_Crime_Score = value; }
        }

        /// <summary>
        /// Gets or sets the Cap_Index_Risk_Cateogory value.
        /// </summary>
        public decimal? Cap_Index_Risk_Cateogory
        {
            get { return _Cap_Index_Risk_Cateogory; }
            set { _Cap_Index_Risk_Cateogory = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsAP_Property_Security class with default value.
        /// </summary>
        public clsAP_Property_Security()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsAP_Property_Security class based on Primary Key.
        /// </summary>
        public clsAP_Property_Security(decimal pK_AP_Property_Security)
        {
            DataTable dtAP_Property_Security = SelectByPK(pK_AP_Property_Security).Tables[0];

            if (dtAP_Property_Security.Rows.Count == 1)
            {
                SetValue(dtAP_Property_Security.Rows[0]);

            }

        }



        /// <summary>
        /// Initializes a new instance of the clsAP_Property_Security class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drAP_Property_Security)
        {
            if (drAP_Property_Security["PK_AP_Property_Security"] == DBNull.Value)
                this._PK_AP_Property_Security = null;
            else
                this._PK_AP_Property_Security = (decimal?)drAP_Property_Security["PK_AP_Property_Security"];

            if (drAP_Property_Security["FK_LU_Location_Id"] == DBNull.Value)
                this._FK_LU_Location_Id = null;
            else
                this._FK_LU_Location_Id = (decimal?)drAP_Property_Security["FK_LU_Location_Id"];

            if (drAP_Property_Security["CCTV_Company_Name"] == DBNull.Value)
                this._CCTV_Company_Name = null;
            else
                this._CCTV_Company_Name = (string)drAP_Property_Security["CCTV_Company_Name"];

            if (drAP_Property_Security["CCTV_Company_Address_1"] == DBNull.Value)
                this._CCTV_Company_Address_1 = null;
            else
                this._CCTV_Company_Address_1 = (string)drAP_Property_Security["CCTV_Company_Address_1"];

            if (drAP_Property_Security["CCTV_Company_Address_2"] == DBNull.Value)
                this._CCTV_Company_Address_2 = null;
            else
                this._CCTV_Company_Address_2 = (string)drAP_Property_Security["CCTV_Company_Address_2"];

            if (drAP_Property_Security["CCTV_Company_City"] == DBNull.Value)
                this._CCTV_Company_City = null;
            else
                this._CCTV_Company_City = (string)drAP_Property_Security["CCTV_Company_City"];

            if (drAP_Property_Security["FK_CCTV_Company_State"] == DBNull.Value)
                this._FK_CCTV_Company_State = null;
            else
                this._FK_CCTV_Company_State = (decimal?)drAP_Property_Security["FK_CCTV_Company_State"];

            if (drAP_Property_Security["CCTV_Company_Zip"] == DBNull.Value)
                this._CCTV_Company_Zip = null;
            else
                this._CCTV_Company_Zip = (string)drAP_Property_Security["CCTV_Company_Zip"];

            if (drAP_Property_Security["CCTV_Company_Contact_Name"] == DBNull.Value)
                this._CCTV_Company_Contact_Name = null;
            else
                this._CCTV_Company_Contact_Name = (string)drAP_Property_Security["CCTV_Company_Contact_Name"];

            if (drAP_Property_Security["CCTV_Comapny_Contact_Telephone"] == DBNull.Value)
                this._CCTV_Comapny_Contact_Telephone = null;
            else
                this._CCTV_Comapny_Contact_Telephone = (string)drAP_Property_Security["CCTV_Comapny_Contact_Telephone"];

            if (drAP_Property_Security["CCTV_Company_Contact_EMail"] == DBNull.Value)
                this._CCTV_Company_Contact_EMail = null;
            else
                this._CCTV_Company_Contact_EMail = (string)drAP_Property_Security["CCTV_Company_Contact_EMail"];

            if (drAP_Property_Security["Cal_Atlantic_System"] == DBNull.Value)
                this._Cal_Atlantic_System = null;
            else
                this._Cal_Atlantic_System = (string)drAP_Property_Security["Cal_Atlantic_System"];

            if (drAP_Property_Security["Live_Monitoring"] == DBNull.Value)
                this._Live_Monitoring = null;
            else
                this._Live_Monitoring = (string)drAP_Property_Security["Live_Monitoring"];

            if (drAP_Property_Security["Hours_Monitored_From"] == DBNull.Value)
                this._Hours_Monitored_From = null;
            else
                this._Hours_Monitored_From = (string)drAP_Property_Security["Hours_Monitored_From"];

            if (drAP_Property_Security["Hours_Monitored_To"] == DBNull.Value)
                this._Hours_Monitored_To = null;
            else
                this._Hours_Monitored_To = (string)drAP_Property_Security["Hours_Monitored_To"];

            if (drAP_Property_Security["ECC_Back"] == DBNull.Value)
                this._ECC_Back = null;
            else
                this._ECC_Back = (string)drAP_Property_Security["ECC_Back"];

            if (drAP_Property_Security["ECC_Car_Wash"] == DBNull.Value)
                this._ECC_Car_Wash = null;
            else
                this._ECC_Car_Wash = (string)drAP_Property_Security["ECC_Car_Wash"];

            if (drAP_Property_Security["ECC_Front"] == DBNull.Value)
                this._ECC_Front = null;
            else
                this._ECC_Front = (string)drAP_Property_Security["ECC_Front"];

            if (drAP_Property_Security["ECC_Satellite_Parking"] == DBNull.Value)
                this._ECC_Satellite_Parking = null;
            else
                this._ECC_Satellite_Parking = (string)drAP_Property_Security["ECC_Satellite_Parking"];

            if (drAP_Property_Security["ECC_Side"] == DBNull.Value)
                this._ECC_Side = null;
            else
                this._ECC_Side = (string)drAP_Property_Security["ECC_Side"];

            if (drAP_Property_Security["ECC_Zero_Lot_Line"] == DBNull.Value)
                this._ECC_Zero_Lot_Line = null;
            else
                this._ECC_Zero_Lot_Line = (string)drAP_Property_Security["ECC_Zero_Lot_Line"];

            if (drAP_Property_Security["ECC_Other"] == DBNull.Value)
                this._ECC_Other = null;
            else
                this._ECC_Other = (string)drAP_Property_Security["ECC_Other"];

            if (drAP_Property_Security["Exterior_Camera_Coverage_Other_Description"] == DBNull.Value)
                this._Exterior_Camera_Coverage_Other_Description = null;
            else
                this._Exterior_Camera_Coverage_Other_Description = (string)drAP_Property_Security["Exterior_Camera_Coverage_Other_Description"];

            if (drAP_Property_Security["ICC_Body_Shop"] == DBNull.Value)
                this._ICC_Body_Shop = null;
            else
                this._ICC_Body_Shop = (string)drAP_Property_Security["ICC_Body_Shop"];

            if (drAP_Property_Security["ICC_Cashier"] == DBNull.Value)
                this._ICC_Cashier = null;
            else
                this._ICC_Cashier = (string)drAP_Property_Security["ICC_Cashier"];

            if (drAP_Property_Security["ICC_Computer_Room"] == DBNull.Value)
                this._ICC_Computer_Room = null;
            else
                this._ICC_Computer_Room = (string)drAP_Property_Security["ICC_Computer_Room"];

            if (drAP_Property_Security["ICC_Detail_Bays"] == DBNull.Value)
                this._ICC_Detail_Bays = null;
            else
                this._ICC_Detail_Bays = (string)drAP_Property_Security["ICC_Detail_Bays"];

            if (drAP_Property_Security["ICC_Key_Box_Area"] == DBNull.Value)
                this._ICC_Key_Box_Area = null;
            else
                this._ICC_Key_Box_Area = (string)drAP_Property_Security["ICC_Key_Box_Area"];

            if (drAP_Property_Security["ICC_Parts_Receiving_Area"] == DBNull.Value)
                this._ICC_Parts_Receiving_Area = null;
            else
                this._ICC_Parts_Receiving_Area = (string)drAP_Property_Security["ICC_Parts_Receiving_Area"];

            if (drAP_Property_Security["ICC_Service_Department"] == DBNull.Value)
                this._ICC_Service_Department = null;
            else
                this._ICC_Service_Department = (string)drAP_Property_Security["ICC_Service_Department"];

            if (drAP_Property_Security["ICC_Service_Lane"] == DBNull.Value)
                this._ICC_Service_Lane = null;
            else
                this._ICC_Service_Lane = (string)drAP_Property_Security["ICC_Service_Lane"];

            if (drAP_Property_Security["ICC_Showroom"] == DBNull.Value)
                this._ICC_Showroom = null;
            else
                this._ICC_Showroom = (string)drAP_Property_Security["ICC_Showroom"];

            if (drAP_Property_Security["ICC_Smart_Safe_Office"] == DBNull.Value)
                this._ICC_Smart_Safe_Office = null;
            else
                this._ICC_Smart_Safe_Office = (string)drAP_Property_Security["ICC_Smart_Safe_Office"];

            if (drAP_Property_Security["ICC_Other"] == DBNull.Value)
                this._ICC_Other = null;
            else
                this._ICC_Other = (string)drAP_Property_Security["ICC_Other"];

            if (drAP_Property_Security["Interior_Camera_Coverage_Other_Description"] == DBNull.Value)
                this._Interior_Camera_Coverage_Other_Description = null;
            else
                this._Interior_Camera_Coverage_Other_Description = (string)drAP_Property_Security["Interior_Camera_Coverage_Other_Description"];

            if (drAP_Property_Security["Buglar_Alarm_System"] == DBNull.Value)
                this._Buglar_Alarm_System = null;
            else
                this._Buglar_Alarm_System = (string)drAP_Property_Security["Buglar_Alarm_System"];

            if (drAP_Property_Security["Is_System_Active_and_Function_Properly"] == DBNull.Value)
                this._Is_System_Active_and_Function_Properly = null;
            else
                this._Is_System_Active_and_Function_Properly = (string)drAP_Property_Security["Is_System_Active_and_Function_Properly"];

            if (drAP_Property_Security["Burglar_Alarm_Company_Name"] == DBNull.Value)
                this._Burglar_Alarm_Company_Name = null;
            else
                this._Burglar_Alarm_Company_Name = (string)drAP_Property_Security["Burglar_Alarm_Company_Name"];

            if (drAP_Property_Security["Burglar_Alarm_Company_Address_1"] == DBNull.Value)
                this._Burglar_Alarm_Company_Address_1 = null;
            else
                this._Burglar_Alarm_Company_Address_1 = (string)drAP_Property_Security["Burglar_Alarm_Company_Address_1"];

            if (drAP_Property_Security["Burglar_Alarm_Company_Address_2"] == DBNull.Value)
                this._Burglar_Alarm_Company_Address_2 = null;
            else
                this._Burglar_Alarm_Company_Address_2 = (string)drAP_Property_Security["Burglar_Alarm_Company_Address_2"];

            if (drAP_Property_Security["Burglar_Alarm_Company_City"] == DBNull.Value)
                this._Burglar_Alarm_Company_City = null;
            else
                this._Burglar_Alarm_Company_City = (string)drAP_Property_Security["Burglar_Alarm_Company_City"];

            if (drAP_Property_Security["FK_Burglar_Alarm_Company_State"] == DBNull.Value)
                this._FK_Burglar_Alarm_Company_State = null;
            else
                this._FK_Burglar_Alarm_Company_State = (decimal?)drAP_Property_Security["FK_Burglar_Alarm_Company_State"];

            if (drAP_Property_Security["Burglar_Alarm_Company_Zip"] == DBNull.Value)
                this._Burglar_Alarm_Company_Zip = null;
            else
                this._Burglar_Alarm_Company_Zip = (string)drAP_Property_Security["Burglar_Alarm_Company_Zip"];

            if (drAP_Property_Security["Burglar_Alarm_Company_Contact_Name"] == DBNull.Value)
                this._Burglar_Alarm_Company_Contact_Name = null;
            else
                this._Burglar_Alarm_Company_Contact_Name = (string)drAP_Property_Security["Burglar_Alarm_Company_Contact_Name"];

            if (drAP_Property_Security["Burglar_Alarm_Comapny_Contact_Telephone"] == DBNull.Value)
                this._Burglar_Alarm_Comapny_Contact_Telephone = null;
            else
                this._Burglar_Alarm_Comapny_Contact_Telephone = (string)drAP_Property_Security["Burglar_Alarm_Comapny_Contact_Telephone"];

            if (drAP_Property_Security["Burglar_Alarm_Company_Contact_EMail"] == DBNull.Value)
                this._Burglar_Alarm_Company_Contact_EMail = null;
            else
                this._Burglar_Alarm_Company_Contact_EMail = (string)drAP_Property_Security["Burglar_Alarm_Company_Contact_EMail"];

            if (drAP_Property_Security["ZD_Collision_Center"] == DBNull.Value)
                this._ZD_Collision_Center = null;
            else
                this._ZD_Collision_Center = (string)drAP_Property_Security["ZD_Collision_Center"];

            if (drAP_Property_Security["ZD_Office"] == DBNull.Value)
                this._ZD_Office = null;
            else
                this._ZD_Office = (string)drAP_Property_Security["ZD_Office"];

            if (drAP_Property_Security["ZD_Parts"] == DBNull.Value)
                this._ZD_Parts = null;
            else
                this._ZD_Parts = (string)drAP_Property_Security["ZD_Parts"];

            if (drAP_Property_Security["ZD_Sales_Showroom"] == DBNull.Value)
                this._ZD_Sales_Showroom = null;
            else
                this._ZD_Sales_Showroom = (string)drAP_Property_Security["ZD_Sales_Showroom"];

            if (drAP_Property_Security["ZD_Sales"] == DBNull.Value)
                this._ZD_Sales = null;
            else
                this._ZD_Sales = (string)drAP_Property_Security["ZD_Sales"];

            if (drAP_Property_Security["ZD_Other"] == DBNull.Value)
                this._ZD_Other = null;
            else
                this._ZD_Other = (string)drAP_Property_Security["ZD_Other"];

            if (drAP_Property_Security["Burglar_Alarm_Coverage_Other_Description"] == DBNull.Value)
                this._Burglar_Alarm_Coverage_Other_Description = null;
            else
                this._Burglar_Alarm_Coverage_Other_Description = (string)drAP_Property_Security["Burglar_Alarm_Coverage_Other_Description"];

            if (drAP_Property_Security["Burglar_Alarm_Coverage_Comments"] == DBNull.Value)
                this._Burglar_Alarm_Coverage_Comments = null;
            else
                this._Burglar_Alarm_Coverage_Comments = (string)drAP_Property_Security["Burglar_Alarm_Coverage_Comments"];

            if (drAP_Property_Security["Guard_Company_Name"] == DBNull.Value)
                this._Guard_Company_Name = null;
            else
                this._Guard_Company_Name = (string)drAP_Property_Security["Guard_Company_Name"];

            if (drAP_Property_Security["Guard_Company_Address_1"] == DBNull.Value)
                this._Guard_Company_Address_1 = null;
            else
                this._Guard_Company_Address_1 = (string)drAP_Property_Security["Guard_Company_Address_1"];

            if (drAP_Property_Security["Guard_Company_Address_2"] == DBNull.Value)
                this._Guard_Company_Address_2 = null;
            else
                this._Guard_Company_Address_2 = (string)drAP_Property_Security["Guard_Company_Address_2"];

            if (drAP_Property_Security["Guard_Company_City"] == DBNull.Value)
                this._Guard_Company_City = null;
            else
                this._Guard_Company_City = (string)drAP_Property_Security["Guard_Company_City"];

            if (drAP_Property_Security["FK_Guard_Company_State"] == DBNull.Value)
                this._FK_Guard_Company_State = null;
            else
                this._FK_Guard_Company_State = (decimal?)drAP_Property_Security["FK_Guard_Company_State"];

            if (drAP_Property_Security["Guard_Company_Zip"] == DBNull.Value)
                this._Guard_Company_Zip = null;
            else
                this._Guard_Company_Zip = (string)drAP_Property_Security["Guard_Company_Zip"];

            if (drAP_Property_Security["Guard_Company_Contact_Name"] == DBNull.Value)
                this._Guard_Company_Contact_Name = null;
            else
                this._Guard_Company_Contact_Name = (string)drAP_Property_Security["Guard_Company_Contact_Name"];

            if (drAP_Property_Security["Guard_Comapny_Contact_Telephone"] == DBNull.Value)
                this._Guard_Comapny_Contact_Telephone = null;
            else
                this._Guard_Comapny_Contact_Telephone = (string)drAP_Property_Security["Guard_Comapny_Contact_Telephone"];

            if (drAP_Property_Security["Guard_Company_Contact_EMail"] == DBNull.Value)
                this._Guard_Company_Contact_EMail = null;
            else
                this._Guard_Company_Contact_EMail = (string)drAP_Property_Security["Guard_Company_Contact_EMail"];

            if (drAP_Property_Security["Guard_Hours_Monitored_From"] == DBNull.Value)
                this._Guard_Hours_Monitored_From = null;
            else
                this._Guard_Hours_Monitored_From = (string)drAP_Property_Security["Guard_Hours_Monitored_From"];

            if (drAP_Property_Security["Guard_Hours_Monitored_To"] == DBNull.Value)
                this._Guard_Hours_Monitored_To = null;
            else
                this._Guard_Hours_Monitored_To = (string)drAP_Property_Security["Guard_Hours_Monitored_To"];

            if (drAP_Property_Security["OffDuty_Officer_Name"] == DBNull.Value)
                this._OffDuty_Officer_Name = null;
            else
                this._OffDuty_Officer_Name = (string)drAP_Property_Security["OffDuty_Officer_Name"];

            if (drAP_Property_Security["OffDuty_Officer_Telephone"] == DBNull.Value)
                this._OffDuty_Officer_Telephone = null;
            else
                this._OffDuty_Officer_Telephone = (string)drAP_Property_Security["OffDuty_Officer_Telephone"];

            if (drAP_Property_Security["OffDuty_Officer_Hours_Monitored_From"] == DBNull.Value)
                this._OffDuty_Officer_Hours_Monitored_From = null;
            else
                this._OffDuty_Officer_Hours_Monitored_From = (string)drAP_Property_Security["OffDuty_Officer_Hours_Monitored_From"];

            if (drAP_Property_Security["OffDuty_Officer_Hours_Monitored_To"] == DBNull.Value)
                this._OffDuty_Officer_Hours_Monitored_To = null;
            else
                this._OffDuty_Officer_Hours_Monitored_To = (string)drAP_Property_Security["OffDuty_Officer_Hours_Monitored_To"];

            if (drAP_Property_Security["AC_1st_Floor_Only"] == DBNull.Value)
                this._AC_1st_Floor_Only = null;
            else
                this._AC_1st_Floor_Only = (string)drAP_Property_Security["AC_1st_Floor_Only"];

            if (drAP_Property_Security["AC_Business_Area"] == DBNull.Value)
                this._AC_Business_Area = null;
            else
                this._AC_Business_Area = (string)drAP_Property_Security["AC_Business_Area"];

            if (drAP_Property_Security["AC_Cashier"] == DBNull.Value)
                this._AC_Cashier = null;
            else
                this._AC_Cashier = (string)drAP_Property_Security["AC_Cashier"];

            if (drAP_Property_Security["AC_Computer_Room"] == DBNull.Value)
                this._AC_Computer_Room = null;
            else
                this._AC_Computer_Room = (string)drAP_Property_Security["AC_Computer_Room"];

            if (drAP_Property_Security["AC_Controller_Office"] == DBNull.Value)
                this._AC_Controller_Office = null;
            else
                this._AC_Controller_Office = (string)drAP_Property_Security["AC_Controller_Office"];

            if (drAP_Property_Security["AC_EnterExit_Building"] == DBNull.Value)
                this._AC_EnterExit_Building = null;
            else
                this._AC_EnterExit_Building = (string)drAP_Property_Security["AC_EnterExit_Building"];

            if (drAP_Property_Security["AC_F_and_I_Office"] == DBNull.Value)
                this._AC_F_and_I_Office = null;
            else
                this._AC_F_and_I_Office = (string)drAP_Property_Security["AC_F_and_I_Office"];

            if (drAP_Property_Security["AC_GM_Office"] == DBNull.Value)
                this._AC_GM_Office = null;
            else
                this._AC_GM_Office = (string)drAP_Property_Security["AC_GM_Office"];

            if (drAP_Property_Security["AC_Multiple_Floors"] == DBNull.Value)
                this._AC_Multiple_Floors = null;
            else
                this._AC_Multiple_Floors = (string)drAP_Property_Security["AC_Multiple_Floors"];

            if (drAP_Property_Security["AC_Parts"] == DBNull.Value)
                this._AC_Parts = null;
            else
                this._AC_Parts = (string)drAP_Property_Security["AC_Parts"];

            if (drAP_Property_Security["AC_Smart_Sales_Office"] == DBNull.Value)
                this._AC_Smart_Sales_Office = null;
            else
                this._AC_Smart_Sales_Office = (string)drAP_Property_Security["AC_Smart_Sales_Office"];

            if (drAP_Property_Security["AC_Other"] == DBNull.Value)
                this._AC_Other = null;
            else
                this._AC_Other = (string)drAP_Property_Security["AC_Other"];

            if (drAP_Property_Security["Access_Control_Other_Description"] == DBNull.Value)
                this._Access_Control_Other_Description = null;
            else
                this._Access_Control_Other_Description = (string)drAP_Property_Security["Access_Control_Other_Description"];

            if (drAP_Property_Security["FG_EntranceExit_Alarms"] == DBNull.Value)
                this._FG_EntranceExit_Alarms = null;
            else
                this._FG_EntranceExit_Alarms = (string)drAP_Property_Security["FG_EntranceExit_Alarms"];

            if (drAP_Property_Security["FG_EntranceExit_Gate"] == DBNull.Value)
                this._FG_EntranceExit_Gate = null;
            else
                this._FG_EntranceExit_Gate = (string)drAP_Property_Security["FG_EntranceExit_Gate"];

            if (drAP_Property_Security["F_Back"] == DBNull.Value)
                this._F_Back = null;
            else
                this._F_Back = (string)drAP_Property_Security["F_Back"];

            if (drAP_Property_Security["F_Entire_Perimeter"] == DBNull.Value)
                this._F_Entire_Perimeter = null;
            else
                this._F_Entire_Perimeter = (string)drAP_Property_Security["F_Entire_Perimeter"];

            if (drAP_Property_Security["F_Front"] == DBNull.Value)
                this._F_Front = null;
            else
                this._F_Front = (string)drAP_Property_Security["F_Front"];

            if (drAP_Property_Security["F_Satellite_Parking_Lot"] == DBNull.Value)
                this._F_Satellite_Parking_Lot = null;
            else
                this._F_Satellite_Parking_Lot = (string)drAP_Property_Security["F_Satellite_Parking_Lot"];

            if (drAP_Property_Security["F_Side"] == DBNull.Value)
                this._F_Side = null;
            else
                this._F_Side = (string)drAP_Property_Security["F_Side"];

            if (drAP_Property_Security["P_Back"] == DBNull.Value)
                this._P_Back = null;
            else
                this._P_Back = (string)drAP_Property_Security["P_Back"];

            if (drAP_Property_Security["P_Entire_Perimeter"] == DBNull.Value)
                this._P_Entire_Perimeter = null;
            else
                this._P_Entire_Perimeter = (string)drAP_Property_Security["P_Entire_Perimeter"];

            if (drAP_Property_Security["P_Front"] == DBNull.Value)
                this._P_Front = null;
            else
                this._P_Front = (string)drAP_Property_Security["P_Front"];

            if (drAP_Property_Security["P_Satellite_Parking_Lot"] == DBNull.Value)
                this._P_Satellite_Parking_Lot = null;
            else
                this._P_Satellite_Parking_Lot = (string)drAP_Property_Security["P_Satellite_Parking_Lot"];

            if (drAP_Property_Security["P_Side"] == DBNull.Value)
                this._P_Side = null;
            else
                this._P_Side = (string)drAP_Property_Security["P_Side"];

            if (drAP_Property_Security["SITS_Auto_Tracks"] == DBNull.Value)
                this._SITS_Auto_Tracks = null;
            else
                this._SITS_Auto_Tracks = (string)drAP_Property_Security["SITS_Auto_Tracks"];

            if (drAP_Property_Security["SITS_Key_Tracks"] == DBNull.Value)
                this._SITS_Key_Tracks = null;
            else
                this._SITS_Key_Tracks = (string)drAP_Property_Security["SITS_Key_Tracks"];

            if (drAP_Property_Security["SITS_Other"] == DBNull.Value)
                this._SITS_Other = null;
            else
                this._SITS_Other = (string)drAP_Property_Security["SITS_Other"];

            if (drAP_Property_Security["Security_Inventory_Tracking_System_Other_Description"] == DBNull.Value)
                this._Security_Inventory_Tracking_System_Other_Description = null;
            else
                this._Security_Inventory_Tracking_System_Other_Description = (string)drAP_Property_Security["Security_Inventory_Tracking_System_Other_Description"];

            if (drAP_Property_Security["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drAP_Property_Security["Updated_By"];

            if (drAP_Property_Security["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drAP_Property_Security["Update_Date"];

            if (drAP_Property_Security["Cap_Index_Crime_Score"] == DBNull.Value)
                this._Cap_Index_Crime_Score = null;
            else
                this._Cap_Index_Crime_Score = (int?)drAP_Property_Security["Cap_Index_Crime_Score"];

            if (drAP_Property_Security["Cap_Index_Risk_Cateogory"] == DBNull.Value)
                this._Cap_Index_Risk_Cateogory = null;
            else
                this._Cap_Index_Risk_Cateogory = (decimal?)drAP_Property_Security["Cap_Index_Risk_Cateogory"];
        }


        #endregion

        /// <summary>
        /// Inserts a record into the AP_Property_Security table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_SecurityInsert");


            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, this._FK_LU_Location_Id);

            if (string.IsNullOrEmpty(this._CCTV_Company_Name))
                db.AddInParameter(dbCommand, "CCTV_Company_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Name", DbType.String, this._CCTV_Company_Name);

            if (string.IsNullOrEmpty(this._CCTV_Company_Address_1))
                db.AddInParameter(dbCommand, "CCTV_Company_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Address_1", DbType.String, this._CCTV_Company_Address_1);

            if (string.IsNullOrEmpty(this._CCTV_Company_Address_2))
                db.AddInParameter(dbCommand, "CCTV_Company_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Address_2", DbType.String, this._CCTV_Company_Address_2);

            if (string.IsNullOrEmpty(this._CCTV_Company_City))
                db.AddInParameter(dbCommand, "CCTV_Company_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_City", DbType.String, this._CCTV_Company_City);

            db.AddInParameter(dbCommand, "FK_CCTV_Company_State", DbType.Decimal, this._FK_CCTV_Company_State);

            if (string.IsNullOrEmpty(this._CCTV_Company_Zip))
                db.AddInParameter(dbCommand, "CCTV_Company_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Zip", DbType.String, this._CCTV_Company_Zip);

            if (string.IsNullOrEmpty(this._CCTV_Company_Contact_Name))
                db.AddInParameter(dbCommand, "CCTV_Company_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Contact_Name", DbType.String, this._CCTV_Company_Contact_Name);

            if (string.IsNullOrEmpty(this._CCTV_Comapny_Contact_Telephone))
                db.AddInParameter(dbCommand, "CCTV_Comapny_Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Comapny_Contact_Telephone", DbType.String, this._CCTV_Comapny_Contact_Telephone);

            if (string.IsNullOrEmpty(this._CCTV_Company_Contact_EMail))
                db.AddInParameter(dbCommand, "CCTV_Company_Contact_EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Contact_EMail", DbType.String, this._CCTV_Company_Contact_EMail);

            if (string.IsNullOrEmpty(this._Cal_Atlantic_System))
                db.AddInParameter(dbCommand, "Cal_Atlantic_System", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cal_Atlantic_System", DbType.String, this._Cal_Atlantic_System);

            if (string.IsNullOrEmpty(this._Live_Monitoring))
                db.AddInParameter(dbCommand, "Live_Monitoring", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Live_Monitoring", DbType.String, this._Live_Monitoring);

            if (string.IsNullOrEmpty(this._Hours_Monitored_From))
                db.AddInParameter(dbCommand, "Hours_Monitored_From", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Hours_Monitored_From", DbType.String, this._Hours_Monitored_From);

            if (string.IsNullOrEmpty(this._Hours_Monitored_To))
                db.AddInParameter(dbCommand, "Hours_Monitored_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Hours_Monitored_To", DbType.String, this._Hours_Monitored_To);

            if (string.IsNullOrEmpty(this._ECC_Back))
                db.AddInParameter(dbCommand, "ECC_Back", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Back", DbType.String, this._ECC_Back);

            if (string.IsNullOrEmpty(this._ECC_Car_Wash))
                db.AddInParameter(dbCommand, "ECC_Car_Wash", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Car_Wash", DbType.String, this._ECC_Car_Wash);

            if (string.IsNullOrEmpty(this._ECC_Front))
                db.AddInParameter(dbCommand, "ECC_Front", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Front", DbType.String, this._ECC_Front);

            if (string.IsNullOrEmpty(this._ECC_Satellite_Parking))
                db.AddInParameter(dbCommand, "ECC_Satellite_Parking", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Satellite_Parking", DbType.String, this._ECC_Satellite_Parking);

            if (string.IsNullOrEmpty(this._ECC_Side))
                db.AddInParameter(dbCommand, "ECC_Side", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Side", DbType.String, this._ECC_Side);

            if (string.IsNullOrEmpty(this._ECC_Zero_Lot_Line))
                db.AddInParameter(dbCommand, "ECC_Zero_Lot_Line", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Zero_Lot_Line", DbType.String, this._ECC_Zero_Lot_Line);

            if (string.IsNullOrEmpty(this._ECC_Other))
                db.AddInParameter(dbCommand, "ECC_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Other", DbType.String, this._ECC_Other);

            if (string.IsNullOrEmpty(this._Exterior_Camera_Coverage_Other_Description))
                db.AddInParameter(dbCommand, "Exterior_Camera_Coverage_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Exterior_Camera_Coverage_Other_Description", DbType.String, this._Exterior_Camera_Coverage_Other_Description);

            if (string.IsNullOrEmpty(this._ICC_Body_Shop))
                db.AddInParameter(dbCommand, "ICC_Body_Shop", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Body_Shop", DbType.String, this._ICC_Body_Shop);

            if (string.IsNullOrEmpty(this._ICC_Cashier))
                db.AddInParameter(dbCommand, "ICC_Cashier", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Cashier", DbType.String, this._ICC_Cashier);

            if (string.IsNullOrEmpty(this._ICC_Computer_Room))
                db.AddInParameter(dbCommand, "ICC_Computer_Room", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Computer_Room", DbType.String, this._ICC_Computer_Room);

            if (string.IsNullOrEmpty(this._ICC_Detail_Bays))
                db.AddInParameter(dbCommand, "ICC_Detail_Bays", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Detail_Bays", DbType.String, this._ICC_Detail_Bays);

            if (string.IsNullOrEmpty(this._ICC_Key_Box_Area))
                db.AddInParameter(dbCommand, "ICC_Key_Box_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Key_Box_Area", DbType.String, this._ICC_Key_Box_Area);

            if (string.IsNullOrEmpty(this._ICC_Parts_Receiving_Area))
                db.AddInParameter(dbCommand, "ICC_Parts_Receiving_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Parts_Receiving_Area", DbType.String, this._ICC_Parts_Receiving_Area);

            if (string.IsNullOrEmpty(this._ICC_Service_Department))
                db.AddInParameter(dbCommand, "ICC_Service_Department", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Service_Department", DbType.String, this._ICC_Service_Department);

            if (string.IsNullOrEmpty(this._ICC_Service_Lane))
                db.AddInParameter(dbCommand, "ICC_Service_Lane", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Service_Lane", DbType.String, this._ICC_Service_Lane);

            if (string.IsNullOrEmpty(this._ICC_Showroom))
                db.AddInParameter(dbCommand, "ICC_Showroom", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Showroom", DbType.String, this._ICC_Showroom);

            if (string.IsNullOrEmpty(this._ICC_Smart_Safe_Office))
                db.AddInParameter(dbCommand, "ICC_Smart_Safe_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Smart_Safe_Office", DbType.String, this._ICC_Smart_Safe_Office);

            if (string.IsNullOrEmpty(this._ICC_Other))
                db.AddInParameter(dbCommand, "ICC_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Other", DbType.String, this._ICC_Other);

            if (string.IsNullOrEmpty(this._Interior_Camera_Coverage_Other_Description))
                db.AddInParameter(dbCommand, "Interior_Camera_Coverage_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "@Interior_Camera_Coverage_Other_Description", DbType.String, this._Interior_Camera_Coverage_Other_Description);

            if (string.IsNullOrEmpty(this._Buglar_Alarm_System))
                db.AddInParameter(dbCommand, "Buglar_Alarm_System", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Buglar_Alarm_System", DbType.String, this._Buglar_Alarm_System);

            if (string.IsNullOrEmpty(this._Is_System_Active_and_Function_Properly))
                db.AddInParameter(dbCommand, "Is_System_Active_and_Function_Properly", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Is_System_Active_and_Function_Properly", DbType.String, this._Is_System_Active_and_Function_Properly);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Name))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Name", DbType.String, this._Burglar_Alarm_Company_Name);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Address_1))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Address_1", DbType.String, this._Burglar_Alarm_Company_Address_1);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Address_2))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Address_2", DbType.String, this._Burglar_Alarm_Company_Address_2);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_City))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_City", DbType.String, this._Burglar_Alarm_Company_City);

            db.AddInParameter(dbCommand, "FK_Burglar_Alarm_Company_State", DbType.Decimal, this._FK_Burglar_Alarm_Company_State);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Zip))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Zip", DbType.String, this._Burglar_Alarm_Company_Zip);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Contact_Name))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Contact_Name", DbType.String, this._Burglar_Alarm_Company_Contact_Name);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Comapny_Contact_Telephone))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Comapny_Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Comapny_Contact_Telephone", DbType.String, this._Burglar_Alarm_Comapny_Contact_Telephone);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Contact_EMail))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Contact_EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Contact_EMail", DbType.String, this._Burglar_Alarm_Company_Contact_EMail);

            if (string.IsNullOrEmpty(this._ZD_Collision_Center))
                db.AddInParameter(dbCommand, "ZD_Collision_Center", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Collision_Center", DbType.String, this._ZD_Collision_Center);

            if (string.IsNullOrEmpty(this._ZD_Office))
                db.AddInParameter(dbCommand, "ZD_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Office", DbType.String, this._ZD_Office);

            if (string.IsNullOrEmpty(this._ZD_Parts))
                db.AddInParameter(dbCommand, "ZD_Parts", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Parts", DbType.String, this._ZD_Parts);

            if (string.IsNullOrEmpty(this._ZD_Sales_Showroom))
                db.AddInParameter(dbCommand, "ZD_Sales_Showroom", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Sales_Showroom", DbType.String, this._ZD_Sales_Showroom);

            if (string.IsNullOrEmpty(this._ZD_Sales))
                db.AddInParameter(dbCommand, "ZD_Sales", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Sales", DbType.String, this._ZD_Sales);

            if (string.IsNullOrEmpty(this._ZD_Other))
                db.AddInParameter(dbCommand, "ZD_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Other", DbType.String, this._ZD_Other);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Coverage_Other_Description))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Coverage_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Coverage_Other_Description", DbType.String, this._Burglar_Alarm_Coverage_Other_Description);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Coverage_Comments))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Coverage_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Coverage_Comments", DbType.String, this._Burglar_Alarm_Coverage_Comments);

            if (string.IsNullOrEmpty(this._Guard_Company_Name))
                db.AddInParameter(dbCommand, "Guard_Company_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Name", DbType.String, this._Guard_Company_Name);

            if (string.IsNullOrEmpty(this._Guard_Company_Address_1))
                db.AddInParameter(dbCommand, "Guard_Company_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Address_1", DbType.String, this._Guard_Company_Address_1);

            if (string.IsNullOrEmpty(this._Guard_Company_Address_2))
                db.AddInParameter(dbCommand, "Guard_Company_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Address_2", DbType.String, this._Guard_Company_Address_2);

            if (string.IsNullOrEmpty(this._Guard_Company_City))
                db.AddInParameter(dbCommand, "Guard_Company_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_City", DbType.String, this._Guard_Company_City);

            db.AddInParameter(dbCommand, "FK_Guard_Company_State", DbType.Decimal, this._FK_Guard_Company_State);

            if (string.IsNullOrEmpty(this._Guard_Company_Zip))
                db.AddInParameter(dbCommand, "Guard_Company_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Zip", DbType.String, this._Guard_Company_Zip);

            if (string.IsNullOrEmpty(this._Guard_Company_Contact_Name))
                db.AddInParameter(dbCommand, "Guard_Company_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Contact_Name", DbType.String, this._Guard_Company_Contact_Name);

            if (string.IsNullOrEmpty(this._Guard_Comapny_Contact_Telephone))
                db.AddInParameter(dbCommand, "Guard_Comapny_Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Comapny_Contact_Telephone", DbType.String, this._Guard_Comapny_Contact_Telephone);

            if (string.IsNullOrEmpty(this._Guard_Company_Contact_EMail))
                db.AddInParameter(dbCommand, "Guard_Company_Contact_EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Contact_EMail", DbType.String, this._Guard_Company_Contact_EMail);

            if (string.IsNullOrEmpty(this._Guard_Hours_Monitored_From))
                db.AddInParameter(dbCommand, "Guard_Hours_Monitored_From", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Hours_Monitored_From", DbType.String, this._Guard_Hours_Monitored_From);

            if (string.IsNullOrEmpty(this._Guard_Hours_Monitored_To))
                db.AddInParameter(dbCommand, "Guard_Hours_Monitored_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Hours_Monitored_To", DbType.String, this._Guard_Hours_Monitored_To);

            if (string.IsNullOrEmpty(this._OffDuty_Officer_Name))
                db.AddInParameter(dbCommand, "OffDuty_Officer_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OffDuty_Officer_Name", DbType.String, this._OffDuty_Officer_Name);

            if (string.IsNullOrEmpty(this._OffDuty_Officer_Telephone))
                db.AddInParameter(dbCommand, "OffDuty_Officer_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OffDuty_Officer_Telephone", DbType.String, this._OffDuty_Officer_Telephone);

            if (string.IsNullOrEmpty(this._OffDuty_Officer_Hours_Monitored_From))
                db.AddInParameter(dbCommand, "OffDuty_Officer_Hours_Monitored_From", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OffDuty_Officer_Hours_Monitored_From", DbType.String, this._OffDuty_Officer_Hours_Monitored_From);

            if (string.IsNullOrEmpty(this._OffDuty_Officer_Hours_Monitored_To))
                db.AddInParameter(dbCommand, "OffDuty_Officer_Hours_Monitored_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OffDuty_Officer_Hours_Monitored_To", DbType.String, this._OffDuty_Officer_Hours_Monitored_To);

            if (string.IsNullOrEmpty(this._AC_1st_Floor_Only))
                db.AddInParameter(dbCommand, "AC_1st_Floor_Only", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_1st_Floor_Only", DbType.String, this._AC_1st_Floor_Only);

            if (string.IsNullOrEmpty(this._AC_Business_Area))
                db.AddInParameter(dbCommand, "AC_Business_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Business_Area", DbType.String, this._AC_Business_Area);

            if (string.IsNullOrEmpty(this._AC_Cashier))
                db.AddInParameter(dbCommand, "AC_Cashier", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Cashier", DbType.String, this._AC_Cashier);

            if (string.IsNullOrEmpty(this._AC_Computer_Room))
                db.AddInParameter(dbCommand, "AC_Computer_Room", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Computer_Room", DbType.String, this._AC_Computer_Room);

            if (string.IsNullOrEmpty(this._AC_Controller_Office))
                db.AddInParameter(dbCommand, "AC_Controller_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Controller_Office", DbType.String, this._AC_Controller_Office);

            if (string.IsNullOrEmpty(this._AC_EnterExit_Building))
                db.AddInParameter(dbCommand, "AC_EnterExit_Building", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_EnterExit_Building", DbType.String, this._AC_EnterExit_Building);

            if (string.IsNullOrEmpty(this._AC_F_and_I_Office))
                db.AddInParameter(dbCommand, "AC_F_and_I_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_F_and_I_Office", DbType.String, this._AC_F_and_I_Office);

            if (string.IsNullOrEmpty(this._AC_GM_Office))
                db.AddInParameter(dbCommand, "AC_GM_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_GM_Office", DbType.String, this._AC_GM_Office);

            if (string.IsNullOrEmpty(this._AC_Multiple_Floors))
                db.AddInParameter(dbCommand, "AC_Multiple_Floors", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Multiple_Floors", DbType.String, this._AC_Multiple_Floors);

            if (string.IsNullOrEmpty(this._AC_Parts))
                db.AddInParameter(dbCommand, "AC_Parts", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Parts", DbType.String, this._AC_Parts);

            if (string.IsNullOrEmpty(this._AC_Smart_Sales_Office))
                db.AddInParameter(dbCommand, "AC_Smart_Sales_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Smart_Sales_Office", DbType.String, this._AC_Smart_Sales_Office);

            if (string.IsNullOrEmpty(this._AC_Other))
                db.AddInParameter(dbCommand, "AC_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Other", DbType.String, this._AC_Other);

            if (string.IsNullOrEmpty(this._Access_Control_Other_Description))
                db.AddInParameter(dbCommand, "Access_Control_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Access_Control_Other_Description", DbType.String, this._Access_Control_Other_Description);

            if (string.IsNullOrEmpty(this._FG_EntranceExit_Alarms))
                db.AddInParameter(dbCommand, "FG_EntranceExit_Alarms", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FG_EntranceExit_Alarms", DbType.String, this._FG_EntranceExit_Alarms);

            if (string.IsNullOrEmpty(this._FG_EntranceExit_Gate))
                db.AddInParameter(dbCommand, "FG_EntranceExit_Gate", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FG_EntranceExit_Gate", DbType.String, this._FG_EntranceExit_Gate);

            if (string.IsNullOrEmpty(this._F_Back))
                db.AddInParameter(dbCommand, "F_Back", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Back", DbType.String, this._F_Back);

            if (string.IsNullOrEmpty(this._F_Entire_Perimeter))
                db.AddInParameter(dbCommand, "F_Entire_Perimeter", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Entire_Perimeter", DbType.String, this._F_Entire_Perimeter);

            if (string.IsNullOrEmpty(this._F_Front))
                db.AddInParameter(dbCommand, "F_Front", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Front", DbType.String, this._F_Front);

            if (string.IsNullOrEmpty(this._F_Satellite_Parking_Lot))
                db.AddInParameter(dbCommand, "F_Satellite_Parking_Lot", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Satellite_Parking_Lot", DbType.String, this._F_Satellite_Parking_Lot);

            if (string.IsNullOrEmpty(this._F_Side))
                db.AddInParameter(dbCommand, "F_Side", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Side", DbType.String, this._F_Side);

            if (string.IsNullOrEmpty(this._P_Back))
                db.AddInParameter(dbCommand, "P_Back", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Back", DbType.String, this._P_Back);

            if (string.IsNullOrEmpty(this._P_Entire_Perimeter))
                db.AddInParameter(dbCommand, "P_Entire_Perimeter", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Entire_Perimeter", DbType.String, this._P_Entire_Perimeter);

            if (string.IsNullOrEmpty(this._P_Front))
                db.AddInParameter(dbCommand, "P_Front", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Front", DbType.String, this._P_Front);

            if (string.IsNullOrEmpty(this._P_Satellite_Parking_Lot))
                db.AddInParameter(dbCommand, "P_Satellite_Parking_Lot", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Satellite_Parking_Lot", DbType.String, this._P_Satellite_Parking_Lot);

            if (string.IsNullOrEmpty(this._P_Side))
                db.AddInParameter(dbCommand, "P_Side", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Side", DbType.String, this._P_Side);

            if (string.IsNullOrEmpty(this._SITS_Auto_Tracks))
                db.AddInParameter(dbCommand, "SITS_Auto_Tracks", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SITS_Auto_Tracks", DbType.String, this._SITS_Auto_Tracks);

            if (string.IsNullOrEmpty(this._SITS_Key_Tracks))
                db.AddInParameter(dbCommand, "SITS_Key_Tracks", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SITS_Key_Tracks", DbType.String, this._SITS_Key_Tracks);

            if (string.IsNullOrEmpty(this._SITS_Other))
                db.AddInParameter(dbCommand, "SITS_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SITS_Other", DbType.String, this._SITS_Other);

            if (string.IsNullOrEmpty(this._Security_Inventory_Tracking_System_Other_Description))
                db.AddInParameter(dbCommand, "Security_Inventory_Tracking_System_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Security_Inventory_Tracking_System_Other_Description", DbType.String, this._Security_Inventory_Tracking_System_Other_Description);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "Cap_Index_Crime_Score", DbType.Int32, this._Cap_Index_Crime_Score);

            db.AddInParameter(dbCommand, "Cap_Index_Risk_Cateogory", DbType.Decimal, this._Cap_Index_Risk_Cateogory);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the AP_Property_Security table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_AP_Property_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_SecuritySelectByPK");

            db.AddInParameter(dbCommand, "PK_AP_Property_Security", DbType.Decimal, pK_AP_Property_Security);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the AP_Property_Security table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_SecuritySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the AP_Property_Security table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_SecurityUpdate");


            db.AddInParameter(dbCommand, "PK_AP_Property_Security", DbType.Decimal, this._PK_AP_Property_Security);

            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, this._FK_LU_Location_Id);

            if (string.IsNullOrEmpty(this._CCTV_Company_Name))
                db.AddInParameter(dbCommand, "CCTV_Company_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Name", DbType.String, this._CCTV_Company_Name);

            if (string.IsNullOrEmpty(this._CCTV_Company_Address_1))
                db.AddInParameter(dbCommand, "CCTV_Company_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Address_1", DbType.String, this._CCTV_Company_Address_1);

            if (string.IsNullOrEmpty(this._CCTV_Company_Address_2))
                db.AddInParameter(dbCommand, "CCTV_Company_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Address_2", DbType.String, this._CCTV_Company_Address_2);

            if (string.IsNullOrEmpty(this._CCTV_Company_City))
                db.AddInParameter(dbCommand, "CCTV_Company_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_City", DbType.String, this._CCTV_Company_City);

            db.AddInParameter(dbCommand, "FK_CCTV_Company_State", DbType.Decimal, this._FK_CCTV_Company_State);

            if (string.IsNullOrEmpty(this._CCTV_Company_Zip))
                db.AddInParameter(dbCommand, "CCTV_Company_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Zip", DbType.String, this._CCTV_Company_Zip);

            if (string.IsNullOrEmpty(this._CCTV_Company_Contact_Name))
                db.AddInParameter(dbCommand, "CCTV_Company_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Contact_Name", DbType.String, this._CCTV_Company_Contact_Name);

            if (string.IsNullOrEmpty(this._CCTV_Comapny_Contact_Telephone))
                db.AddInParameter(dbCommand, "CCTV_Comapny_Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Comapny_Contact_Telephone", DbType.String, this._CCTV_Comapny_Contact_Telephone);

            if (string.IsNullOrEmpty(this._CCTV_Company_Contact_EMail))
                db.AddInParameter(dbCommand, "CCTV_Company_Contact_EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CCTV_Company_Contact_EMail", DbType.String, this._CCTV_Company_Contact_EMail);

            if (string.IsNullOrEmpty(this._Cal_Atlantic_System))
                db.AddInParameter(dbCommand, "Cal_Atlantic_System", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cal_Atlantic_System", DbType.String, this._Cal_Atlantic_System);

            if (string.IsNullOrEmpty(this._Live_Monitoring))
                db.AddInParameter(dbCommand, "Live_Monitoring", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Live_Monitoring", DbType.String, this._Live_Monitoring);

            if (string.IsNullOrEmpty(this._Hours_Monitored_From))
                db.AddInParameter(dbCommand, "Hours_Monitored_From", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Hours_Monitored_From", DbType.String, this._Hours_Monitored_From);

            if (string.IsNullOrEmpty(this._Hours_Monitored_To))
                db.AddInParameter(dbCommand, "Hours_Monitored_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Hours_Monitored_To", DbType.String, this._Hours_Monitored_To);

            if (string.IsNullOrEmpty(this._ECC_Back))
                db.AddInParameter(dbCommand, "ECC_Back", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Back", DbType.String, this._ECC_Back);

            if (string.IsNullOrEmpty(this._ECC_Car_Wash))
                db.AddInParameter(dbCommand, "ECC_Car_Wash", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Car_Wash", DbType.String, this._ECC_Car_Wash);

            if (string.IsNullOrEmpty(this._ECC_Front))
                db.AddInParameter(dbCommand, "ECC_Front", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Front", DbType.String, this._ECC_Front);

            if (string.IsNullOrEmpty(this._ECC_Satellite_Parking))
                db.AddInParameter(dbCommand, "ECC_Satellite_Parking", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Satellite_Parking", DbType.String, this._ECC_Satellite_Parking);

            if (string.IsNullOrEmpty(this._ECC_Side))
                db.AddInParameter(dbCommand, "ECC_Side", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Side", DbType.String, this._ECC_Side);

            if (string.IsNullOrEmpty(this._ECC_Zero_Lot_Line))
                db.AddInParameter(dbCommand, "ECC_Zero_Lot_Line", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Zero_Lot_Line", DbType.String, this._ECC_Zero_Lot_Line);

            if (string.IsNullOrEmpty(this._ECC_Other))
                db.AddInParameter(dbCommand, "ECC_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ECC_Other", DbType.String, this._ECC_Other);

            if (string.IsNullOrEmpty(this._Exterior_Camera_Coverage_Other_Description))
                db.AddInParameter(dbCommand, "Exterior_Camera_Coverage_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Exterior_Camera_Coverage_Other_Description", DbType.String, this._Exterior_Camera_Coverage_Other_Description);

            if (string.IsNullOrEmpty(this._ICC_Body_Shop))
                db.AddInParameter(dbCommand, "ICC_Body_Shop", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Body_Shop", DbType.String, this._ICC_Body_Shop);

            if (string.IsNullOrEmpty(this._ICC_Cashier))
                db.AddInParameter(dbCommand, "ICC_Cashier", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Cashier", DbType.String, this._ICC_Cashier);

            if (string.IsNullOrEmpty(this._ICC_Computer_Room))
                db.AddInParameter(dbCommand, "ICC_Computer_Room", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Computer_Room", DbType.String, this._ICC_Computer_Room);

            if (string.IsNullOrEmpty(this._ICC_Detail_Bays))
                db.AddInParameter(dbCommand, "ICC_Detail_Bays", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Detail_Bays", DbType.String, this._ICC_Detail_Bays);

            if (string.IsNullOrEmpty(this._ICC_Key_Box_Area))
                db.AddInParameter(dbCommand, "ICC_Key_Box_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Key_Box_Area", DbType.String, this._ICC_Key_Box_Area);

            if (string.IsNullOrEmpty(this._ICC_Parts_Receiving_Area))
                db.AddInParameter(dbCommand, "ICC_Parts_Receiving_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Parts_Receiving_Area", DbType.String, this._ICC_Parts_Receiving_Area);

            if (string.IsNullOrEmpty(this._ICC_Service_Department))
                db.AddInParameter(dbCommand, "ICC_Service_Department", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Service_Department", DbType.String, this._ICC_Service_Department);

            if (string.IsNullOrEmpty(this._ICC_Service_Lane))
                db.AddInParameter(dbCommand, "ICC_Service_Lane", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Service_Lane", DbType.String, this._ICC_Service_Lane);

            if (string.IsNullOrEmpty(this._ICC_Showroom))
                db.AddInParameter(dbCommand, "ICC_Showroom", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Showroom", DbType.String, this._ICC_Showroom);

            if (string.IsNullOrEmpty(this._ICC_Smart_Safe_Office))
                db.AddInParameter(dbCommand, "ICC_Smart_Safe_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Smart_Safe_Office", DbType.String, this._ICC_Smart_Safe_Office);

            if (string.IsNullOrEmpty(this._ICC_Other))
                db.AddInParameter(dbCommand, "ICC_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ICC_Other", DbType.String, this._ICC_Other);

            if (string.IsNullOrEmpty(this._Interior_Camera_Coverage_Other_Description))
                db.AddInParameter(dbCommand, "Interior_Camera_Coverage_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Interior_Camera_Coverage_Other_Description", DbType.String, this._Interior_Camera_Coverage_Other_Description);

            if (string.IsNullOrEmpty(this._Buglar_Alarm_System))
                db.AddInParameter(dbCommand, "Buglar_Alarm_System", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Buglar_Alarm_System", DbType.String, this._Buglar_Alarm_System);

            if (string.IsNullOrEmpty(this._Is_System_Active_and_Function_Properly))
                db.AddInParameter(dbCommand, "Is_System_Active_and_Function_Properly", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Is_System_Active_and_Function_Properly", DbType.String, this._Is_System_Active_and_Function_Properly);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Name))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Name", DbType.String, this._Burglar_Alarm_Company_Name);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Address_1))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Address_1", DbType.String, this._Burglar_Alarm_Company_Address_1);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Address_2))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Address_2", DbType.String, this._Burglar_Alarm_Company_Address_2);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_City))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_City", DbType.String, this._Burglar_Alarm_Company_City);

            db.AddInParameter(dbCommand, "FK_Burglar_Alarm_Company_State", DbType.Decimal, this._FK_Burglar_Alarm_Company_State);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Zip))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Zip", DbType.String, this._Burglar_Alarm_Company_Zip);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Contact_Name))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Contact_Name", DbType.String, this._Burglar_Alarm_Company_Contact_Name);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Comapny_Contact_Telephone))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Comapny_Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Comapny_Contact_Telephone", DbType.String, this._Burglar_Alarm_Comapny_Contact_Telephone);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Company_Contact_EMail))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Contact_EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Company_Contact_EMail", DbType.String, this._Burglar_Alarm_Company_Contact_EMail);

            if (string.IsNullOrEmpty(this._ZD_Collision_Center))
                db.AddInParameter(dbCommand, "ZD_Collision_Center", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Collision_Center", DbType.String, this._ZD_Collision_Center);

            if (string.IsNullOrEmpty(this._ZD_Office))
                db.AddInParameter(dbCommand, "ZD_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Office", DbType.String, this._ZD_Office);

            if (string.IsNullOrEmpty(this._ZD_Parts))
                db.AddInParameter(dbCommand, "ZD_Parts", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Parts", DbType.String, this._ZD_Parts);

            if (string.IsNullOrEmpty(this._ZD_Sales_Showroom))
                db.AddInParameter(dbCommand, "ZD_Sales_Showroom", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Sales_Showroom", DbType.String, this._ZD_Sales_Showroom);

            if (string.IsNullOrEmpty(this._ZD_Sales))
                db.AddInParameter(dbCommand, "ZD_Sales", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Sales", DbType.String, this._ZD_Sales);

            if (string.IsNullOrEmpty(this._ZD_Other))
                db.AddInParameter(dbCommand, "ZD_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZD_Other", DbType.String, this._ZD_Other);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Coverage_Other_Description))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Coverage_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Coverage_Other_Description", DbType.String, this._Burglar_Alarm_Coverage_Other_Description);

            if (string.IsNullOrEmpty(this._Burglar_Alarm_Coverage_Comments))
                db.AddInParameter(dbCommand, "Burglar_Alarm_Coverage_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Burglar_Alarm_Coverage_Comments", DbType.String, this._Burglar_Alarm_Coverage_Comments);

            if (string.IsNullOrEmpty(this._Guard_Company_Name))
                db.AddInParameter(dbCommand, "Guard_Company_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Name", DbType.String, this._Guard_Company_Name);

            if (string.IsNullOrEmpty(this._Guard_Company_Address_1))
                db.AddInParameter(dbCommand, "Guard_Company_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Address_1", DbType.String, this._Guard_Company_Address_1);

            if (string.IsNullOrEmpty(this._Guard_Company_Address_2))
                db.AddInParameter(dbCommand, "Guard_Company_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Address_2", DbType.String, this._Guard_Company_Address_2);

            if (string.IsNullOrEmpty(this._Guard_Company_City))
                db.AddInParameter(dbCommand, "Guard_Company_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_City", DbType.String, this._Guard_Company_City);

            db.AddInParameter(dbCommand, "FK_Guard_Company_State", DbType.Decimal, this._FK_Guard_Company_State);

            if (string.IsNullOrEmpty(this._Guard_Company_Zip))
                db.AddInParameter(dbCommand, "Guard_Company_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Zip", DbType.String, this._Guard_Company_Zip);

            if (string.IsNullOrEmpty(this._Guard_Company_Contact_Name))
                db.AddInParameter(dbCommand, "Guard_Company_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Contact_Name", DbType.String, this._Guard_Company_Contact_Name);

            if (string.IsNullOrEmpty(this._Guard_Comapny_Contact_Telephone))
                db.AddInParameter(dbCommand, "Guard_Comapny_Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Comapny_Contact_Telephone", DbType.String, this._Guard_Comapny_Contact_Telephone);

            if (string.IsNullOrEmpty(this._Guard_Company_Contact_EMail))
                db.AddInParameter(dbCommand, "Guard_Company_Contact_EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Company_Contact_EMail", DbType.String, this._Guard_Company_Contact_EMail);

            if (string.IsNullOrEmpty(this._Guard_Hours_Monitored_From))
                db.AddInParameter(dbCommand, "Guard_Hours_Monitored_From", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Hours_Monitored_From", DbType.String, this._Guard_Hours_Monitored_From);

            if (string.IsNullOrEmpty(this._Guard_Hours_Monitored_To))
                db.AddInParameter(dbCommand, "Guard_Hours_Monitored_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guard_Hours_Monitored_To", DbType.String, this._Guard_Hours_Monitored_To);

            if (string.IsNullOrEmpty(this._OffDuty_Officer_Name))
                db.AddInParameter(dbCommand, "OffDuty_Officer_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OffDuty_Officer_Name", DbType.String, this._OffDuty_Officer_Name);

            if (string.IsNullOrEmpty(this._OffDuty_Officer_Telephone))
                db.AddInParameter(dbCommand, "OffDuty_Officer_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OffDuty_Officer_Telephone", DbType.String, this._OffDuty_Officer_Telephone);

            if (string.IsNullOrEmpty(this._OffDuty_Officer_Hours_Monitored_From))
                db.AddInParameter(dbCommand, "OffDuty_Officer_Hours_Monitored_From", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OffDuty_Officer_Hours_Monitored_From", DbType.String, this._OffDuty_Officer_Hours_Monitored_From);

            if (string.IsNullOrEmpty(this._OffDuty_Officer_Hours_Monitored_To))
                db.AddInParameter(dbCommand, "OffDuty_Officer_Hours_Monitored_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OffDuty_Officer_Hours_Monitored_To", DbType.String, this._OffDuty_Officer_Hours_Monitored_To);

            if (string.IsNullOrEmpty(this._AC_1st_Floor_Only))
                db.AddInParameter(dbCommand, "AC_1st_Floor_Only", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_1st_Floor_Only", DbType.String, this._AC_1st_Floor_Only);

            if (string.IsNullOrEmpty(this._AC_Business_Area))
                db.AddInParameter(dbCommand, "AC_Business_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Business_Area", DbType.String, this._AC_Business_Area);

            if (string.IsNullOrEmpty(this._AC_Cashier))
                db.AddInParameter(dbCommand, "AC_Cashier", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Cashier", DbType.String, this._AC_Cashier);

            if (string.IsNullOrEmpty(this._AC_Computer_Room))
                db.AddInParameter(dbCommand, "AC_Computer_Room", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Computer_Room", DbType.String, this._AC_Computer_Room);

            if (string.IsNullOrEmpty(this._AC_Controller_Office))
                db.AddInParameter(dbCommand, "AC_Controller_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Controller_Office", DbType.String, this._AC_Controller_Office);

            if (string.IsNullOrEmpty(this._AC_EnterExit_Building))
                db.AddInParameter(dbCommand, "AC_EnterExit_Building", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_EnterExit_Building", DbType.String, this._AC_EnterExit_Building);

            if (string.IsNullOrEmpty(this._AC_F_and_I_Office))
                db.AddInParameter(dbCommand, "AC_F_and_I_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_F_and_I_Office", DbType.String, this._AC_F_and_I_Office);

            if (string.IsNullOrEmpty(this._AC_GM_Office))
                db.AddInParameter(dbCommand, "AC_GM_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_GM_Office", DbType.String, this._AC_GM_Office);

            if (string.IsNullOrEmpty(this._AC_Multiple_Floors))
                db.AddInParameter(dbCommand, "AC_Multiple_Floors", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Multiple_Floors", DbType.String, this._AC_Multiple_Floors);

            if (string.IsNullOrEmpty(this._AC_Parts))
                db.AddInParameter(dbCommand, "AC_Parts", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Parts", DbType.String, this._AC_Parts);

            if (string.IsNullOrEmpty(this._AC_Smart_Sales_Office))
                db.AddInParameter(dbCommand, "AC_Smart_Sales_Office", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Smart_Sales_Office", DbType.String, this._AC_Smart_Sales_Office);

            if (string.IsNullOrEmpty(this._AC_Other))
                db.AddInParameter(dbCommand, "AC_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AC_Other", DbType.String, this._AC_Other);

            if (string.IsNullOrEmpty(this._Access_Control_Other_Description))
                db.AddInParameter(dbCommand, "Access_Control_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Access_Control_Other_Description", DbType.String, this._Access_Control_Other_Description);

            if (string.IsNullOrEmpty(this._FG_EntranceExit_Alarms))
                db.AddInParameter(dbCommand, "FG_EntranceExit_Alarms", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FG_EntranceExit_Alarms", DbType.String, this._FG_EntranceExit_Alarms);

            if (string.IsNullOrEmpty(this._FG_EntranceExit_Gate))
                db.AddInParameter(dbCommand, "FG_EntranceExit_Gate", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FG_EntranceExit_Gate", DbType.String, this._FG_EntranceExit_Gate);

            if (string.IsNullOrEmpty(this._F_Back))
                db.AddInParameter(dbCommand, "F_Back", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Back", DbType.String, this._F_Back);

            if (string.IsNullOrEmpty(this._F_Entire_Perimeter))
                db.AddInParameter(dbCommand, "F_Entire_Perimeter", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Entire_Perimeter", DbType.String, this._F_Entire_Perimeter);

            if (string.IsNullOrEmpty(this._F_Front))
                db.AddInParameter(dbCommand, "F_Front", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Front", DbType.String, this._F_Front);

            if (string.IsNullOrEmpty(this._F_Satellite_Parking_Lot))
                db.AddInParameter(dbCommand, "F_Satellite_Parking_Lot", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Satellite_Parking_Lot", DbType.String, this._F_Satellite_Parking_Lot);

            if (string.IsNullOrEmpty(this._F_Side))
                db.AddInParameter(dbCommand, "F_Side", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "F_Side", DbType.String, this._F_Side);

            if (string.IsNullOrEmpty(this._P_Back))
                db.AddInParameter(dbCommand, "P_Back", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Back", DbType.String, this._P_Back);

            if (string.IsNullOrEmpty(this._P_Entire_Perimeter))
                db.AddInParameter(dbCommand, "P_Entire_Perimeter", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Entire_Perimeter", DbType.String, this._P_Entire_Perimeter);

            if (string.IsNullOrEmpty(this._P_Front))
                db.AddInParameter(dbCommand, "P_Front", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Front", DbType.String, this._P_Front);

            if (string.IsNullOrEmpty(this._P_Satellite_Parking_Lot))
                db.AddInParameter(dbCommand, "P_Satellite_Parking_Lot", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Satellite_Parking_Lot", DbType.String, this._P_Satellite_Parking_Lot);

            if (string.IsNullOrEmpty(this._P_Side))
                db.AddInParameter(dbCommand, "P_Side", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "P_Side", DbType.String, this._P_Side);

            if (string.IsNullOrEmpty(this._SITS_Auto_Tracks))
                db.AddInParameter(dbCommand, "SITS_Auto_Tracks", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SITS_Auto_Tracks", DbType.String, this._SITS_Auto_Tracks);

            if (string.IsNullOrEmpty(this._SITS_Key_Tracks))
                db.AddInParameter(dbCommand, "SITS_Key_Tracks", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SITS_Key_Tracks", DbType.String, this._SITS_Key_Tracks);

            if (string.IsNullOrEmpty(this._SITS_Other))
                db.AddInParameter(dbCommand, "SITS_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SITS_Other", DbType.String, this._SITS_Other);

            if (string.IsNullOrEmpty(this._Security_Inventory_Tracking_System_Other_Description))
                db.AddInParameter(dbCommand, "Security_Inventory_Tracking_System_Other_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Security_Inventory_Tracking_System_Other_Description", DbType.String, this._Security_Inventory_Tracking_System_Other_Description);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "Cap_Index_Crime_Score", DbType.Int32, this._Cap_Index_Crime_Score);

            db.AddInParameter(dbCommand, "Cap_Index_Risk_Cateogory", DbType.Decimal, this._Cap_Index_Risk_Cateogory);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the AP_Property_Security table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_AP_Property_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_SecurityDeleteByPK");

            db.AddInParameter(dbCommand, "PK_AP_Property_Security", DbType.Decimal, pK_AP_Property_Security);

            db.ExecuteNonQuery(dbCommand);
        }

        public static decimal SelectPKPropertySecurityByFKLocation(decimal fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectPKPropertySecurityByFKLocation");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);
            db.AddOutParameter(dbCommand, "PK_AP_PROPERTY_SECURITY", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToDecimal(dbCommand.Parameters["@PK_AP_PROPERTY_SECURITY"].Value);
        }

        public static int SelectAP_Cap_Index_Risk_CategorybyScore(int Score)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectAP_Cap_Index_Risk_CategorybyScore");
            db.AddInParameter(dbCommand, "Score", DbType.Int32, Score);
            db.ExecuteNonQuery(dbCommand);

            //return Convert.ToInt32(dbCommand.Parameters["@PK_LU_AP_Cap_Index_Risk_Category"].Value);
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
    }
}
