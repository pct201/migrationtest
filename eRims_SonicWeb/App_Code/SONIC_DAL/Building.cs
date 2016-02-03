using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Building table.
    /// </summary>
    public sealed class Building
    {
        #region Fields

        private int _PK_Building_ID;
        private int _FK_LU_Location_ID;
        private string _SecuCam_System;
        private string _SecuCam_Contact_Name;
        private string _SecuCam_Vendor_Name;
        private DateTime _SecuCam_Contact_Expiration_Date;
        private string _SecuCam_Address_1;
        private string _SecuCam_Address_2;
        private string _SecuCam_City;
        private string _SecuCam_State;
        private string _SecuCam_Zip;
        private string _SecuCam_Telephone_Number;
        private string _SecuCam_Alternate_Number;
        private string _SecuCam_Email;
        private string _SecuCam_Comments;
        private Nullable<bool> _Guard_System;
        private string _Guard_System_Name;
        private string _Guard_Contact_Name;
        private string _Guard_Vendor_Name;
        private DateTime _Guard_Contact_Expiration_Date;
        private string _Guard_Address_1;
        private string _Guard_Address_2;
        private string _Guard_City;
        private string _Guard_State;
        private string _Guard_Zip;
        private string _Guard_Telephone_Number;
        private string _Guard_Alternate_Number;
        private string _Guard_Email;
        private string _Guard_Comments;
        private Nullable<bool> _Intru_System;
        private string _Intru_System_Name;
        private string _Intru_Contact_Name;
        private string _Intru_Vendor_Name;
        private DateTime _Intru_Contact_Expiration_Date;
        private string _Intru_Address_1;
        private string _Intru_Address_2;
        private string _Intru_City;
        private string _Intru_State;
        private string _Intru_Zip;
        private string _Intru_Telephone_Number;
        private string _Intru_Alternate_Number;
        private string _Intru_Email;
        private string _Intru_Comments;
        private string _Intru_Contact_Alarm_Type;
        private Nullable<bool> _Fence;
        private bool _Fence_Razor_Wire;
        private bool _Fence_Electrified;
        private Nullable<bool> _Generator;
        private string _Generator_Make;
        private string _Generator_Model;
        private string _Generator_Size;
        private string _Fire_Department_Type;
        private string _Fire_Department_Distance;
        private Nullable<bool> _Tier_1_County;
        private Nullable<bool> _Earthquake_Zone_Fault_Line;
        private Nullable<bool> _Neighboring_Buildings_within_100_ft;
        private string _Neighbor_Occupancy;
        private string _Distance_from_body_of_water;
        private Nullable<bool> _Prior_Flood_History;
        private string _Flood_History_Descr;
        private int _Lowest_finish_floor_elevation;
        private Nullable<bool> _Property_Damage_Losses_in_the_Past_5_years;
        private string _Property_Loss_Descr;
        private string _Flood_Zone;
        private Nullable<bool> _National_Flood_Policy;
        private string _Flood_Carrier;
        private string _Flood_Policy_Number;
        private Nullable<decimal> _Flood_Premium;
        private Nullable<decimal> _Flood_Polciy_Limits_Contents;
        private DateTime _Flood_Policy_Inception_Date;
        private DateTime _Flood_Policy_Expiration_Date;
        private Nullable<decimal> _Flood_Deductible;
        private Nullable<decimal> _Flood_Policy_Limits_Building;
        private string _Comments;
        private string _Building_Number;
        private string _Ownership;
        private bool _Occupancy_Sales_New;
        private bool _Occupancy_Body_Shop;
        private bool _Occupancy_Parking_Lot;
        private bool _Occupancy_Sales_Used;
        private bool _Occupancy_Parts;
        private bool _Occupancy_Raw_Land;
        private bool _Occupancy_Service;
        private bool _Occupancy_Ofifce;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private string _State;
        private string _Zip;
        private Nullable<decimal> _Building_Limit;
        private Nullable<decimal> _Leasehold_Interests_Limit_Betterment;
        private DateTime _Betterment_Date_Complete;
        private Nullable<decimal> _Leasehold_Interests_Limit_Expansion;
        private DateTime _Expansion_Date_Complete;
        private Nullable<decimal> _Associate_Tools_Limit;
        private Nullable<decimal> _Contents_Limit;
        private Nullable<decimal> _Parts_Limit;
        private Nullable<decimal> _Inventory_Levels;
        private string _Year_Built;
        private string _Square_Footage;
        private Double _Number_of_Stories;
        private bool _Roof_Reinforced_Concrete;
        private bool _Roof_Concrete_Panels;
        private bool _Roof_Steel_Deck_with_Fasteners;
        private bool _Roof_Poured_Concrete;
        private bool _Roof_Steel_Deck;
        private bool _Roof_Wood_Joists;
        private bool _Floors_Reinforced_Concrete;
        private bool _Floors_Poured_Concrete;
        private bool _Floors_Wood_Timber;
        private bool _Ext_Walls_Reinforced_Concrete;
        private bool _Ext_Walls_Masonry;
        private bool _Ext_Walls_Corrugated_Metal_Panels;
        private bool _Ext_Walls_Tilt_up_Concrete;
        private bool _Ext_Walls_Glass_and_Steel_Curtain;
        private bool _Ext_Walls_Wood_Frame;
        private bool _Int_Walls_Masonry_With_Fire_Doors;
        private bool _Int_Walls_Masonry_with_Openings;
        private bool _Int_Walls_No_Interior_Walls;
        private bool _Int_Walls_Masonry;
        private bool _Int_Walls_Gypsum_Board;
        private Nullable<bool> _Int_wall_extend_above_roof;
        private int _Number_of_Paint_Booths;
        private int _Number_of_Lifts;
        private Double _Sales_New_Sprinklered;
        private Double _Sales_Used_Sprinklered;
        private Double _Service_Sprinklered;
        private Double _Body_Shop_Sprinklered;
        private Double _Parts_Sprinklered;
        private Double _Office_Sprinklered;
        private bool _Water_Public;
        private bool _Water_Private;
        private bool _Water_Boosted;
        private string _Design_Densities_for_each_area;
        private Nullable<bool> _Hydrants_within_500_ft;
        private bool _Alarm_UL_Central_Station;
        private bool _Alarm_Constant_Attended;
        private bool _Alarm_Sprinkler_Valve_Tamper;
        private bool _Alarm_Non_UL_Central_Station;
        private bool _Alarm_Local;
        private bool _Alarm_Smoke_Detectors;
        private bool _Alarm_Proprietary;
        private bool _Alarm_Sprinkler_Waterflow;
        private bool _Alarm_Dry_Pipe_Air;
        private bool _Alarm_Remote;
        private bool _Alarm_Fire_Pump_Alarms;
        private Nullable<bool> _Alarm_Auto_Fire_Alarms;
        private Nullable<bool> _Alarm_Security_Cameras;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        private int? _Number_of_Bays;
        private int? _Number_of_Lifts_SC;
        private int? _Number_of_Prep_Areas;
        private int? _Number_of_Car_Wash_Stations;
        private Nullable<decimal> _RS_Means_Building_Value;
        private string _Fire_Contact_Name;
        private string _Fire_Vendor_Name;
        private DateTime? _Fire_Contact_Expiration_Date;
        private string _Fire_Address_1;
        private string _Fire_Address_2;
        private string _Fire_City;
        private string _Fire_State;
        private string _Fire_Zip;
        private string _Fire_Telephone_Number;
        private string _Fire_Alternate_Number;
        private string _Fire_Email;
        private string _Fire_Comments;
        private string _Location_Status;
        private string _Liability;
        private int? _Number_Of_Parking_Spaces;
        private decimal? _Acreage;
        private bool _Occupancy_Car_Wash;
        private bool _Occupancy_Photo_Booth;
        private  string _Total_Amperage_Required;
        private string _Cable_Length_Other;
        private string _Power_Service_Other;
        private string _Voltage_Security_Other;
        private decimal? _FK_LU_Cable_Length;
        private decimal? _FK_LU_Phase_Power;
        private decimal? _FK_LU_Power_Service;
        private decimal? _FK_LU_Voltage_Security;
        private bool _Occupancy_Main;

        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Building_ID value.
        /// </summary>
        public int PK_Building_ID
        {
            get { return _PK_Building_ID; }
            set { _PK_Building_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public int FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_System value.
        /// </summary>
        public string SecuCam_System
        {
            get { return _SecuCam_System; }
            set { _SecuCam_System = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Contact_Name value.
        /// </summary>
        public string SecuCam_Contact_Name
        {
            get { return _SecuCam_Contact_Name; }
            set { _SecuCam_Contact_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Vendor_Name value.
        /// </summary>
        public string SecuCam_Vendor_Name
        {
            get { return _SecuCam_Vendor_Name; }
            set { _SecuCam_Vendor_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Contact_Expiration_Date value.
        /// </summary>
        public DateTime SecuCam_Contact_Expiration_Date
        {
            get { return _SecuCam_Contact_Expiration_Date; }
            set { _SecuCam_Contact_Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Address_1 value.
        /// </summary>
        public string SecuCam_Address_1
        {
            get { return _SecuCam_Address_1; }
            set { _SecuCam_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Address_2 value.
        /// </summary>
        public string SecuCam_Address_2
        {
            get { return _SecuCam_Address_2; }
            set { _SecuCam_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_City value.
        /// </summary>
        public string SecuCam_City
        {
            get { return _SecuCam_City; }
            set { _SecuCam_City = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_State value.
        /// </summary>
        public string SecuCam_State
        {
            get { return _SecuCam_State; }
            set { _SecuCam_State = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Zip value.
        /// </summary>
        public string SecuCam_Zip
        {
            get { return _SecuCam_Zip; }
            set { _SecuCam_Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Telephone_Number value.
        /// </summary>
        public string SecuCam_Telephone_Number
        {
            get { return _SecuCam_Telephone_Number; }
            set { _SecuCam_Telephone_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Alternate_Number value.
        /// </summary>
        public string SecuCam_Alternate_Number
        {
            get { return _SecuCam_Alternate_Number; }
            set { _SecuCam_Alternate_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Email value.
        /// </summary>
        public string SecuCam_Email
        {
            get { return _SecuCam_Email; }
            set { _SecuCam_Email = value; }
        }


        /// <summary> 
        /// Gets or sets the SecuCam_Comments value.
        /// </summary>
        public string SecuCam_Comments
        {
            get { return _SecuCam_Comments; }
            set { _SecuCam_Comments = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_System value.
        /// </summary>
        public Nullable<bool> Guard_System
        {
            get { return _Guard_System; }
            set { _Guard_System = value; }
        }

        public string Guard_System_Name
        {
            get { return _Guard_System_Name; }
            set { _Guard_System_Name = value; }
        }

        /// <summary> 
        /// Gets or sets the Guard_Contact_Name value.
        /// </summary>
        public string Guard_Contact_Name
        {
            get { return _Guard_Contact_Name; }
            set { _Guard_Contact_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_Vendor_Name value.
        /// </summary>
        public string Guard_Vendor_Name
        {
            get { return _Guard_Vendor_Name; }
            set { _Guard_Vendor_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_Contact_Expiration_Date value.
        /// </summary>
        public DateTime Guard_Contact_Expiration_Date
        {
            get { return _Guard_Contact_Expiration_Date; }
            set { _Guard_Contact_Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_Address_1 value.
        /// </summary>
        public string Guard_Address_1
        {
            get { return _Guard_Address_1; }
            set { _Guard_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_Address_2 value.
        /// </summary>
        public string Guard_Address_2
        {
            get { return _Guard_Address_2; }
            set { _Guard_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_City value.
        /// </summary>
        public string Guard_City
        {
            get { return _Guard_City; }
            set { _Guard_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_State value.
        /// </summary>
        public string Guard_State
        {
            get { return _Guard_State; }
            set { _Guard_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_Zip value.
        /// </summary>
        public string Guard_Zip
        {
            get { return _Guard_Zip; }
            set { _Guard_Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_Telephone_Number value.
        /// </summary>
        public string Guard_Telephone_Number
        {
            get { return _Guard_Telephone_Number; }
            set { _Guard_Telephone_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_Alternate_Number value.
        /// </summary>
        public string Guard_Alternate_Number
        {
            get { return _Guard_Alternate_Number; }
            set { _Guard_Alternate_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_Email value.
        /// </summary>
        public string Guard_Email
        {
            get { return _Guard_Email; }
            set { _Guard_Email = value; }
        }


        /// <summary> 
        /// Gets or sets the Guard_Comments value.
        /// </summary>
        public string Guard_Comments
        {
            get { return _Guard_Comments; }
            set { _Guard_Comments = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_System value.
        /// </summary>
        public Nullable<bool> Intru_System
        {
            get { return _Intru_System; }
            set { _Intru_System = value; }
        }

        public string Intru_System_Name
        {
            get { return _Intru_System_Name; }
            set { _Intru_System_Name = value; }
        }

        /// <summary> 
        /// Gets or sets the Intru_Contact_Name value.
        /// </summary>
        public string Intru_Contact_Name
        {
            get { return _Intru_Contact_Name; }
            set { _Intru_Contact_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Vendor_Name value.
        /// </summary>
        public string Intru_Vendor_Name
        {
            get { return _Intru_Vendor_Name; }
            set { _Intru_Vendor_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Contact_Expiration_Date value.
        /// </summary>
        public DateTime Intru_Contact_Expiration_Date
        {
            get { return _Intru_Contact_Expiration_Date; }
            set { _Intru_Contact_Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Address_1 value.
        /// </summary>
        public string Intru_Address_1
        {
            get { return _Intru_Address_1; }
            set { _Intru_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Address_2 value.
        /// </summary>
        public string Intru_Address_2
        {
            get { return _Intru_Address_2; }
            set { _Intru_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_City value.
        /// </summary>
        public string Intru_City
        {
            get { return _Intru_City; }
            set { _Intru_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_State value.
        /// </summary>
        public string Intru_State
        {
            get { return _Intru_State; }
            set { _Intru_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Zip value.
        /// </summary>
        public string Intru_Zip
        {
            get { return _Intru_Zip; }
            set { _Intru_Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Telephone_Number value.
        /// </summary>
        public string Intru_Telephone_Number
        {
            get { return _Intru_Telephone_Number; }
            set { _Intru_Telephone_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Alternate_Number value.
        /// </summary>
        public string Intru_Alternate_Number
        {
            get { return _Intru_Alternate_Number; }
            set { _Intru_Alternate_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Email value.
        /// </summary>
        public string Intru_Email
        {
            get { return _Intru_Email; }
            set { _Intru_Email = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Comments value.
        /// </summary>
        public string Intru_Comments
        {
            get { return _Intru_Comments; }
            set { _Intru_Comments = value; }
        }


        /// <summary> 
        /// Gets or sets the Intru_Contact_Alarm_Type value.
        /// </summary>
        public string Intru_Contact_Alarm_Type
        {
            get { return _Intru_Contact_Alarm_Type; }
            set { _Intru_Contact_Alarm_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Fence value.
        /// </summary>
        public Nullable<bool> Fence
        {
            get { return _Fence; }
            set { _Fence = value; }
        }


        /// <summary> 
        /// Gets or sets the Fence_Razor_Wire value.
        /// </summary>
        public bool Fence_Razor_Wire
        {
            get { return _Fence_Razor_Wire; }
            set { _Fence_Razor_Wire = value; }
        }


        /// <summary> 
        /// Gets or sets the Fence_Electrified value.
        /// </summary>
        public bool Fence_Electrified
        {
            get { return _Fence_Electrified; }
            set { _Fence_Electrified = value; }
        }


        /// <summary> 
        /// Gets or sets the Generator value.
        /// </summary>
        public Nullable<bool> Generator
        {
            get { return _Generator; }
            set { _Generator = value; }
        }


        /// <summary> 
        /// Gets or sets the Generator_Make value.
        /// </summary>
        public string Generator_Make
        {
            get { return _Generator_Make; }
            set { _Generator_Make = value; }
        }


        /// <summary> 
        /// Gets or sets the Generator_Model value.
        /// </summary>
        public string Generator_Model
        {
            get { return _Generator_Model; }
            set { _Generator_Model = value; }
        }


        /// <summary> 
        /// Gets or sets the Generator_Size value.
        /// </summary>
        public string Generator_Size
        {
            get { return _Generator_Size; }
            set { _Generator_Size = value; }
        }


        /// <summary> 
        /// Gets or sets the Fire_Department_Type value.
        /// </summary>
        public string Fire_Department_Type
        {
            get { return _Fire_Department_Type; }
            set { _Fire_Department_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Fire_Department_Distance value.
        /// </summary>
        public string Fire_Department_Distance
        {
            get { return _Fire_Department_Distance; }
            set { _Fire_Department_Distance = value; }
        }


        /// <summary> 
        /// Gets or sets the Tier_1_County value.
        /// </summary>
        public Nullable<bool> Tier_1_County
        {
            get { return _Tier_1_County; }
            set { _Tier_1_County = value; }
        }


        /// <summary> 
        /// Gets or sets the Earthquake_Zone_Fault_Line value.
        /// </summary>
        public Nullable<bool> Earthquake_Zone_Fault_Line
        {
            get { return _Earthquake_Zone_Fault_Line; }
            set { _Earthquake_Zone_Fault_Line = value; }
        }


        /// <summary> 
        /// Gets or sets the Neighboring_Buildings_within_100_ft value.
        /// </summary>
        public Nullable<bool> Neighboring_Buildings_within_100_ft
        {
            get { return _Neighboring_Buildings_within_100_ft; }
            set { _Neighboring_Buildings_within_100_ft = value; }
        }


        /// <summary> 
        /// Gets or sets the Neighbor_Occupancy value.
        /// </summary>
        public string Neighbor_Occupancy
        {
            get { return _Neighbor_Occupancy; }
            set { _Neighbor_Occupancy = value; }
        }


        /// <summary> 
        /// Gets or sets the Distance_from_body_of_water value.
        /// </summary>
        public string Distance_from_body_of_water
        {
            get { return _Distance_from_body_of_water; }
            set { _Distance_from_body_of_water = value; }
        }


        /// <summary> 
        /// Gets or sets the Prior_Flood_History value.
        /// </summary>
        public Nullable<bool> Prior_Flood_History
        {
            get { return _Prior_Flood_History; }
            set { _Prior_Flood_History = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_History_Descr value.
        /// </summary>
        public string Flood_History_Descr
        {
            get { return _Flood_History_Descr; }
            set { _Flood_History_Descr = value; }
        }


        /// <summary> 
        /// Gets or sets the Lowest_finish_floor_elevation value.
        /// </summary>
        public int Lowest_finish_floor_elevation
        {
            get { return _Lowest_finish_floor_elevation; }
            set { _Lowest_finish_floor_elevation = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Damage_Losses_in_the_Past_5_years value.
        /// </summary>
        public Nullable<bool> Property_Damage_Losses_in_the_Past_5_years
        {
            get { return _Property_Damage_Losses_in_the_Past_5_years; }
            set { _Property_Damage_Losses_in_the_Past_5_years = value; }
        }
        /// <summary> 
        /// Gets or sets the Property_Loss_Descr value.
        /// </summary>
        public string Property_Loss_Descr
        {
            get { return _Property_Loss_Descr; }
            set { _Property_Loss_Descr = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Zone value.
        /// </summary>
        public string Flood_Zone
        {
            get { return _Flood_Zone; }
            set { _Flood_Zone = value; }
        }


        /// <summary> 
        /// Gets or sets the National_Flood_Policy value.
        /// </summary>
        public Nullable<bool> National_Flood_Policy
        {
            get { return _National_Flood_Policy; }
            set { _National_Flood_Policy = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Carrier value.
        /// </summary>
        public string Flood_Carrier
        {
            get { return _Flood_Carrier; }
            set { _Flood_Carrier = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Policy_Number value.
        /// </summary>
        public string Flood_Policy_Number
        {
            get { return _Flood_Policy_Number; }
            set { _Flood_Policy_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Premium value.
        /// </summary>
        public Nullable<decimal> Flood_Premium
        {
            get { return _Flood_Premium; }
            set { _Flood_Premium = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Polciy_Limits_Contents value.
        /// </summary>
        public Nullable<decimal> Flood_Polciy_Limits_Contents
        {
            get { return _Flood_Polciy_Limits_Contents; }
            set { _Flood_Polciy_Limits_Contents = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Policy_Inception_Date value.
        /// </summary>
        public DateTime Flood_Policy_Inception_Date
        {
            get { return _Flood_Policy_Inception_Date; }
            set { _Flood_Policy_Inception_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Policy_Expiration_Date value.
        /// </summary>
        public DateTime Flood_Policy_Expiration_Date
        {
            get { return _Flood_Policy_Expiration_Date; }
            set { _Flood_Policy_Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Deductible value.
        /// </summary>
        public Nullable<decimal> Flood_Deductible
        {
            get { return _Flood_Deductible; }
            set { _Flood_Deductible = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Policy_Limits_Building value.
        /// </summary>
        public Nullable<decimal> Flood_Policy_Limits_Building
        {
            get { return _Flood_Policy_Limits_Building; }
            set { _Flood_Policy_Limits_Building = value; }
        }


        /// <summary> 
        /// Gets or sets the Comments value.
        /// </summary>
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }


        /// <summary> 
        /// Gets or sets the Building_Number value.
        /// </summary>
        public string Building_Number
        {
            get { return _Building_Number; }
            set { _Building_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Ownership value.
        /// </summary>
        public string Ownership
        {
            get { return _Ownership; }
            set { _Ownership = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupancy_Sales_New value.
        /// </summary>
        public bool Occupancy_Sales_New
        {
            get { return _Occupancy_Sales_New; }
            set { _Occupancy_Sales_New = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupancy_Body_Shop value.
        /// </summary>
        public bool Occupancy_Body_Shop
        {
            get { return _Occupancy_Body_Shop; }
            set { _Occupancy_Body_Shop = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupancy_Parking_Lot value.
        /// </summary>
        public bool Occupancy_Parking_Lot
        {
            get { return _Occupancy_Parking_Lot; }
            set { _Occupancy_Parking_Lot = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupancy_Sales_Used value.
        /// </summary>
        public bool Occupancy_Sales_Used
        {
            get { return _Occupancy_Sales_Used; }
            set { _Occupancy_Sales_Used = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupancy_Parts value.
        /// </summary>
        public bool Occupancy_Parts
        {
            get { return _Occupancy_Parts; }
            set { _Occupancy_Parts = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupancy_Raw_Land value.
        /// </summary>
        public bool Occupancy_Raw_Land
        {
            get { return _Occupancy_Raw_Land; }
            set { _Occupancy_Raw_Land = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupancy_Service value.
        /// </summary>
        public bool Occupancy_Service
        {
            get { return _Occupancy_Service; }
            set { _Occupancy_Service = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupancy_Ofifce value.
        /// </summary>
        public bool Occupancy_Ofifce
        {
            get { return _Occupancy_Ofifce; }
            set { _Occupancy_Ofifce = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_1 value.
        /// </summary>
        public string Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_2 value.
        /// </summary>
        public string Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the City value.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }


        /// <summary> 
        /// Gets or sets the State value.
        /// </summary>
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }


        /// <summary> 
        /// Gets or sets the Zip value.
        /// </summary>
        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Building_Limit value.
        /// </summary>
        public Nullable<decimal> Building_Limit
        {
            get { return _Building_Limit; }
            set { _Building_Limit = value; }
        }


        /// <summary> 
        /// Gets or sets the Leasehold_Interests_Limit_Betterment value.
        /// </summary>
        public Nullable<decimal> Leasehold_Interests_Limit_Betterment
        {
            get { return _Leasehold_Interests_Limit_Betterment; }
            set { _Leasehold_Interests_Limit_Betterment = value; }
        }
        /// <summary> 
        /// Gets or sets the Betterment_Date_Complete value.
        /// </summary>
        public DateTime Betterment_Date_Complete
        {
            get { return _Betterment_Date_Complete; }
            set { _Betterment_Date_Complete = value; }
        }


        /// <summary> 
        /// Gets or sets the Leasehold_Interests_Limit_Expansion value.
        /// </summary>
        public Nullable<decimal> Leasehold_Interests_Limit_Expansion
        {
            get { return _Leasehold_Interests_Limit_Expansion; }
            set { _Leasehold_Interests_Limit_Expansion = value; }
        }

        /// <summary> 
        /// Gets or sets the Expansion_Date_Complete value.
        /// </summary>
        public DateTime Expansion_Date_Complete
        {
            get { return _Expansion_Date_Complete; }
            set { _Expansion_Date_Complete = value; }
        }


        /// <summary> 
        /// Gets or sets the Associate_Tools_Limit value.
        /// </summary>
        public Nullable<decimal> Associate_Tools_Limit
        {
            get { return _Associate_Tools_Limit; }
            set { _Associate_Tools_Limit = value; }
        }


        /// <summary> 
        /// Gets or sets the Contents_Limit value.
        /// </summary>
        public Nullable<decimal> Contents_Limit
        {
            get { return _Contents_Limit; }
            set { _Contents_Limit = value; }
        }


        /// <summary> 
        /// Gets or sets the Parts_Limit value.
        /// </summary>
        public Nullable<decimal> Parts_Limit
        {
            get { return _Parts_Limit; }
            set { _Parts_Limit = value; }
        }


        /// <summary> 
        /// Gets or sets the Inventory_Levels value.
        /// </summary>
        public Nullable<decimal> Inventory_Levels
        {
            get { return _Inventory_Levels; }
            set { _Inventory_Levels = value; }
        }


        /// <summary> 
        /// Gets or sets the Year_Built value.
        /// </summary>
        public string Year_Built
        {
            get { return _Year_Built; }
            set { _Year_Built = value; }
        }


        /// <summary> 
        /// Gets or sets the Square_Footage value.
        /// </summary>
        public string Square_Footage
        {
            get { return _Square_Footage; }
            set { _Square_Footage = value; }
        }


        /// <summary> 
        /// Gets or sets the Number_of_Stories value.
        /// </summary>
        public Double Number_of_Stories
        {
            get { return _Number_of_Stories; }
            set { _Number_of_Stories = value; }
        }


        /// <summary> 
        /// Gets or sets the Roof_Reinforced_Concrete value.
        /// </summary>
        public bool Roof_Reinforced_Concrete
        {
            get { return _Roof_Reinforced_Concrete; }
            set { _Roof_Reinforced_Concrete = value; }
        }


        /// <summary> 
        /// Gets or sets the Roof_Concrete_Panels value.
        /// </summary>
        public bool Roof_Concrete_Panels
        {
            get { return _Roof_Concrete_Panels; }
            set { _Roof_Concrete_Panels = value; }
        }


        /// <summary> 
        /// Gets or sets the Roof_Steel_Deck_with_Fasteners value.
        /// </summary>
        public bool Roof_Steel_Deck_with_Fasteners
        {
            get { return _Roof_Steel_Deck_with_Fasteners; }
            set { _Roof_Steel_Deck_with_Fasteners = value; }
        }


        /// <summary> 
        /// Gets or sets the Roof_Poured_Concrete value.
        /// </summary>
        public bool Roof_Poured_Concrete
        {
            get { return _Roof_Poured_Concrete; }
            set { _Roof_Poured_Concrete = value; }
        }


        /// <summary> 
        /// Gets or sets the Roof_Steel_Deck value.
        /// </summary>
        public bool Roof_Steel_Deck
        {
            get { return _Roof_Steel_Deck; }
            set { _Roof_Steel_Deck = value; }
        }


        /// <summary> 
        /// Gets or sets the Roof_Wood_Joists value.
        /// </summary>
        public bool Roof_Wood_Joists
        {
            get { return _Roof_Wood_Joists; }
            set { _Roof_Wood_Joists = value; }
        }


        /// <summary> 
        /// Gets or sets the Floors_Reinforced_Concrete value.
        /// </summary>
        public bool Floors_Reinforced_Concrete
        {
            get { return _Floors_Reinforced_Concrete; }
            set { _Floors_Reinforced_Concrete = value; }
        }


        /// <summary> 
        /// Gets or sets the Floors_Poured_Concrete value.
        /// </summary>
        public bool Floors_Poured_Concrete
        {
            get { return _Floors_Poured_Concrete; }
            set { _Floors_Poured_Concrete = value; }
        }


        /// <summary> 
        /// Gets or sets the Floors_Wood_Timber value.
        /// </summary>
        public bool Floors_Wood_Timber
        {
            get { return _Floors_Wood_Timber; }
            set { _Floors_Wood_Timber = value; }
        }


        /// <summary> 
        /// Gets or sets the Ext_Walls_Reinforced_Concrete value.
        /// </summary>
        public bool Ext_Walls_Reinforced_Concrete
        {
            get { return _Ext_Walls_Reinforced_Concrete; }
            set { _Ext_Walls_Reinforced_Concrete = value; }
        }


        /// <summary> 
        /// Gets or sets the Ext_Walls_Masonry value.
        /// </summary>
        public bool Ext_Walls_Masonry
        {
            get { return _Ext_Walls_Masonry; }
            set { _Ext_Walls_Masonry = value; }
        }


        /// <summary> 
        /// Gets or sets the Ext_Walls_Corrugated_Metal_Panels value.
        /// </summary>
        public bool Ext_Walls_Corrugated_Metal_Panels
        {
            get { return _Ext_Walls_Corrugated_Metal_Panels; }
            set { _Ext_Walls_Corrugated_Metal_Panels = value; }
        }


        /// <summary> 
        /// Gets or sets the Ext_Walls_Tilt_up_Concrete value.
        /// </summary>
        public bool Ext_Walls_Tilt_up_Concrete
        {
            get { return _Ext_Walls_Tilt_up_Concrete; }
            set { _Ext_Walls_Tilt_up_Concrete = value; }
        }


        /// <summary> 
        /// Gets or sets the Ext_Walls_Glass_and_Steel_Curtain value.
        /// </summary>
        public bool Ext_Walls_Glass_and_Steel_Curtain
        {
            get { return _Ext_Walls_Glass_and_Steel_Curtain; }
            set { _Ext_Walls_Glass_and_Steel_Curtain = value; }
        }


        /// <summary> 
        /// Gets or sets the Ext_Walls_Wood_Frame value.
        /// </summary>
        public bool Ext_Walls_Wood_Frame
        {
            get { return _Ext_Walls_Wood_Frame; }
            set { _Ext_Walls_Wood_Frame = value; }
        }


        /// <summary> 
        /// Gets or sets the Int_Walls_Masonry_With_Fire_Doors value.
        /// </summary>
        public bool Int_Walls_Masonry_With_Fire_Doors
        {
            get { return _Int_Walls_Masonry_With_Fire_Doors; }
            set { _Int_Walls_Masonry_With_Fire_Doors = value; }
        }


        /// <summary> 
        /// Gets or sets the Int_Walls_Masonry_with_Openings value.
        /// </summary>
        public bool Int_Walls_Masonry_with_Openings
        {
            get { return _Int_Walls_Masonry_with_Openings; }
            set { _Int_Walls_Masonry_with_Openings = value; }
        }


        /// <summary> 
        /// Gets or sets the Int_Walls_No_Interior_Walls value.
        /// </summary>
        public bool Int_Walls_No_Interior_Walls
        {
            get { return _Int_Walls_No_Interior_Walls; }
            set { _Int_Walls_No_Interior_Walls = value; }
        }


        /// <summary> 
        /// Gets or sets the Int_Walls_Masonry value.
        /// </summary>
        public bool Int_Walls_Masonry
        {
            get { return _Int_Walls_Masonry; }
            set { _Int_Walls_Masonry = value; }
        }


        /// <summary> 
        /// Gets or sets the Int_Walls_Gypsum_Board value.
        /// </summary>
        public bool Int_Walls_Gypsum_Board
        {
            get { return _Int_Walls_Gypsum_Board; }
            set { _Int_Walls_Gypsum_Board = value; }
        }


        /// <summary> 
        /// Gets or sets the Int_wall_extend_above_roof value.
        /// </summary>
        public Nullable<bool> Int_wall_extend_above_roof
        {
            get { return _Int_wall_extend_above_roof; }
            set { _Int_wall_extend_above_roof = value; }
        }


        /// <summary> 
        /// Gets or sets the Number_of_Paint_Booths value.
        /// </summary>
        public int Number_of_Paint_Booths
        {
            get { return _Number_of_Paint_Booths; }
            set { _Number_of_Paint_Booths = value; }
        }


        /// <summary> 
        /// Gets or sets the Number_of_Lifts value.
        /// </summary>
        public int Number_of_Lifts
        {
            get { return _Number_of_Lifts; }
            set { _Number_of_Lifts = value; }
        }


        /// <summary> 
        /// Gets or sets the Sales_New_Sprinklered value.
        /// </summary>
        public Double Sales_New_Sprinklered
        {
            get { return _Sales_New_Sprinklered; }
            set { _Sales_New_Sprinklered = value; }
        }


        /// <summary> 
        /// Gets or sets the Sales_Used_Sprinklered value.
        /// </summary>
        public Double Sales_Used_Sprinklered
        {
            get { return _Sales_Used_Sprinklered; }
            set { _Sales_Used_Sprinklered = value; }
        }


        /// <summary> 
        /// Gets or sets the Service_Sprinklered value.
        /// </summary>
        public Double Service_Sprinklered
        {
            get { return _Service_Sprinklered; }
            set { _Service_Sprinklered = value; }
        }


        /// <summary> 
        /// Gets or sets the Body_Shop_Sprinklered value.
        /// </summary>
        public Double Body_Shop_Sprinklered
        {
            get { return _Body_Shop_Sprinklered; }
            set { _Body_Shop_Sprinklered = value; }
        }


        /// <summary> 
        /// Gets or sets the Parts_Sprinklered value.
        /// </summary>
        public Double Parts_Sprinklered
        {
            get { return _Parts_Sprinklered; }
            set { _Parts_Sprinklered = value; }
        }


        /// <summary> 
        /// Gets or sets the Office_Sprinklered value.
        /// </summary>
        public Double Office_Sprinklered
        {
            get { return _Office_Sprinklered; }
            set { _Office_Sprinklered = value; }
        }


        /// <summary> 
        /// Gets or sets the Water_Public value.
        /// </summary>
        public bool Water_Public
        {
            get { return _Water_Public; }
            set { _Water_Public = value; }
        }


        /// <summary> 
        /// Gets or sets the Water_Private value.
        /// </summary>
        public bool Water_Private
        {
            get { return _Water_Private; }
            set { _Water_Private = value; }
        }


        /// <summary> 
        /// Gets or sets the Water_Boosted value.
        /// </summary>
        public bool Water_Boosted
        {
            get { return _Water_Boosted; }
            set { _Water_Boosted = value; }
        }


        /// <summary> 
        /// Gets or sets the Design_Densities_for_each_area value.
        /// </summary>
        public string Design_Densities_for_each_area
        {
            get { return _Design_Densities_for_each_area; }
            set { _Design_Densities_for_each_area = value; }
        }


        /// <summary> 
        /// Gets or sets the Hydrants_within_500_ft value.
        /// </summary>
        public Nullable<bool> Hydrants_within_500_ft
        {
            get { return _Hydrants_within_500_ft; }
            set { _Hydrants_within_500_ft = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_UL_Central_Station value.
        /// </summary>
        public bool Alarm_UL_Central_Station
        {
            get { return _Alarm_UL_Central_Station; }
            set { _Alarm_UL_Central_Station = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Constant_Attended value.
        /// </summary>
        public bool Alarm_Constant_Attended
        {
            get { return _Alarm_Constant_Attended; }
            set { _Alarm_Constant_Attended = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Sprinkler_Valve_Tamper value.
        /// </summary>
        public bool Alarm_Sprinkler_Valve_Tamper
        {
            get { return _Alarm_Sprinkler_Valve_Tamper; }
            set { _Alarm_Sprinkler_Valve_Tamper = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Non_UL_Central_Station value.
        /// </summary>
        public bool Alarm_Non_UL_Central_Station
        {
            get { return _Alarm_Non_UL_Central_Station; }
            set { _Alarm_Non_UL_Central_Station = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Local value.
        /// </summary>
        public bool Alarm_Local
        {
            get { return _Alarm_Local; }
            set { _Alarm_Local = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Smoke_Detectors value.
        /// </summary>
        public bool Alarm_Smoke_Detectors
        {
            get { return _Alarm_Smoke_Detectors; }
            set { _Alarm_Smoke_Detectors = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Proprietary value.
        /// </summary>
        public bool Alarm_Proprietary
        {
            get { return _Alarm_Proprietary; }
            set { _Alarm_Proprietary = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Sprinkler_Waterflow value.
        /// </summary>
        public bool Alarm_Sprinkler_Waterflow
        {
            get { return _Alarm_Sprinkler_Waterflow; }
            set { _Alarm_Sprinkler_Waterflow = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Dry_Pipe_Air value.
        /// </summary>
        public bool Alarm_Dry_Pipe_Air
        {
            get { return _Alarm_Dry_Pipe_Air; }
            set { _Alarm_Dry_Pipe_Air = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Remote value.
        /// </summary>
        public bool Alarm_Remote
        {
            get { return _Alarm_Remote; }
            set { _Alarm_Remote = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Fire_Pump_Alarms value.
        /// </summary>
        public bool Alarm_Fire_Pump_Alarms
        {
            get { return _Alarm_Fire_Pump_Alarms; }
            set { _Alarm_Fire_Pump_Alarms = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Auto_Fire_Alarms value.
        /// </summary>
        public Nullable<bool> Alarm_Auto_Fire_Alarms
        {
            get { return _Alarm_Auto_Fire_Alarms; }
            set { _Alarm_Auto_Fire_Alarms = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm_Security_Cameras value.
        /// </summary>
        public Nullable<bool> Alarm_Security_Cameras
        {
            get { return _Alarm_Security_Cameras; }
            set { _Alarm_Security_Cameras = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }
        /// <summary>
        /// Gets or sets the Number_of_Bays value.
        /// </summary>
        public int? Number_of_Bays
        {
            get { return _Number_of_Bays; }
            set { _Number_of_Bays = value; }
        }

        /// <summary>
        /// Gets or sets the Number_of_Lifts_SC value.
        /// </summary>
        public int? Number_of_Lifts_SC
        {
            get { return _Number_of_Lifts_SC; }
            set { _Number_of_Lifts_SC = value; }
        }

        /// <summary>
        /// Gets or sets the Number_of_Prep_Areas value.
        /// </summary>
        public int? Number_of_Prep_Areas
        {
            get { return _Number_of_Prep_Areas; }
            set { _Number_of_Prep_Areas = value; }
        }

        /// <summary>
        /// Gets or sets the Number_of_Car_Wash_Stations value.
        /// </summary>
        public int? Number_of_Car_Wash_Stations
        {
            get { return _Number_of_Car_Wash_Stations; }
            set { _Number_of_Car_Wash_Stations = value; }
        }


        /// <summary> 
        /// Gets or sets the RS_Means_Building_Value value.
        /// </summary>
        public Nullable<decimal> RS_Means_Building_Value
        {
            get { return _RS_Means_Building_Value; }
            set { _RS_Means_Building_Value = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Contact_Name value.
        /// </summary>
        public string Fire_Contact_Name
        {
            get { return _Fire_Contact_Name; }
            set { _Fire_Contact_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Vendor_Name value.
        /// </summary>
        public string Fire_Vendor_Name
        {
            get { return _Fire_Vendor_Name; }
            set { _Fire_Vendor_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Contact_Expiration_Date value.
        /// </summary>
        public DateTime? Fire_Contact_Expiration_Date
        {
            get { return _Fire_Contact_Expiration_Date; }
            set { _Fire_Contact_Expiration_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Address_1 value.
        /// </summary>
        public string Fire_Address_1
        {
            get { return _Fire_Address_1; }
            set { _Fire_Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Address_2 value.
        /// </summary>
        public string Fire_Address_2
        {
            get { return _Fire_Address_2; }
            set { _Fire_Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_City value.
        /// </summary>
        public string Fire_City
        {
            get { return _Fire_City; }
            set { _Fire_City = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_State value.
        /// </summary>
        public string Fire_State
        {
            get { return _Fire_State; }
            set { _Fire_State = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Zip value.
        /// </summary>
        public string Fire_Zip
        {
            get { return _Fire_Zip; }
            set { _Fire_Zip = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Telephone_Number value.
        /// </summary>
        public string Fire_Telephone_Number
        {
            get { return _Fire_Telephone_Number; }
            set { _Fire_Telephone_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Alternate_Number value.
        /// </summary>
        public string Fire_Alternate_Number
        {
            get { return _Fire_Alternate_Number; }
            set { _Fire_Alternate_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Email value.
        /// </summary>
        public string Fire_Email
        {
            get { return _Fire_Email; }
            set { _Fire_Email = value; }
        }

        /// <summary>
        /// Gets or sets the Fire_Comments value.
        /// </summary>
        public string Fire_Comments
        {
            get { return _Fire_Comments; }
            set { _Fire_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the location_Status value.
        /// </summary>
        public string Location_Status
        {
            get { return _Location_Status; }
            set { _Location_Status = value; }
        }

        public string Liability
        {
            get { return _Liability; }
            set { _Liability = value; }
        }


        public int? Number_Of_Parking_Spaces
        {
            get { return _Number_Of_Parking_Spaces; }
            set { _Number_Of_Parking_Spaces = value; }
        }

        public decimal? Acreage
        {
            get { return _Acreage; }
            set { _Acreage = value; }
        }

        public bool Occupancy_Car_Wash
        {
            get { return _Occupancy_Car_Wash; }
            set { _Occupancy_Car_Wash = value; }
        }

        public bool Occupancy_Photo_Booth
        {
            get { return _Occupancy_Photo_Booth; }
            set { _Occupancy_Photo_Booth = value; }
        }
        public decimal? FK_LU_Voltage_Security
        {
            get { return _FK_LU_Voltage_Security; }
            set { _FK_LU_Voltage_Security = value; }
        }
        public decimal? FK_LU_Power_Service
        {
            get { return _FK_LU_Power_Service; }
            set { _FK_LU_Power_Service = value; }
        }
        public decimal? FK_LU_Phase_Power	
        {
            get { return _FK_LU_Phase_Power; }
            set { _FK_LU_Phase_Power = value; }
        }
        public decimal? FK_LU_Cable_Length
        {
            get { return _FK_LU_Cable_Length; }
            set { _FK_LU_Cable_Length = value; }
        }

        public string Voltage_Security_Other
        {
            get { return _Voltage_Security_Other; }
            set { _Voltage_Security_Other = value; }
        }

        public string Power_Service_Other	
        {
            get { return _Power_Service_Other; }
            set { _Power_Service_Other = value; }
        }

        public string Cable_Length_Other	
        {
            get { return _Cable_Length_Other; }
            set { _Cable_Length_Other = value; }
        }

        public string Total_Amperage_Required	
        {
            get { return _Total_Amperage_Required; }
            set { _Total_Amperage_Required = value; }
        }

        public bool Occupancy_Main
        {
            get { return _Occupancy_Main; }
            set { _Occupancy_Main = value; }
        }
        
        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Building class. with the default value.

        /// </summary>
        public Building()
        {

            this._PK_Building_ID = -1;
            this._FK_LU_Location_ID = -1;
            this._SecuCam_System = "";
            this._SecuCam_Contact_Name = "";
            this._SecuCam_Vendor_Name = "";
            this._SecuCam_Contact_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._SecuCam_Address_1 = "";
            this._SecuCam_Address_2 = "";
            this._SecuCam_City = "";
            this._SecuCam_State = "";
            this._SecuCam_Zip = "";
            this._SecuCam_Telephone_Number = "";
            this._SecuCam_Alternate_Number = "";
            this._SecuCam_Email = "";
            this._SecuCam_Comments = "";
            this._Guard_System = null;
            this._Guard_System_Name = "";
            this._Guard_Contact_Name = "";
            this._Guard_Vendor_Name = "";
            this._Guard_Contact_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Guard_Address_1 = "";
            this._Guard_Address_2 = "";
            this._Guard_City = "";
            this._Guard_State = "";
            this._Guard_Zip = "";
            this._Guard_Telephone_Number = "";
            this._Guard_Alternate_Number = "";
            this._Guard_Email = "";
            this._Guard_Comments = "";
            this._Intru_System = null;
            this._Intru_System_Name = "";
            this._Intru_Contact_Name = "";
            this._Intru_Vendor_Name = "";
            this._Intru_Contact_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Intru_Address_1 = "";
            this._Intru_Address_2 = "";
            this._Intru_City = "";
            this._Intru_State = "";
            this._Intru_Zip = "";
            this._Intru_Telephone_Number = "";
            this._Intru_Alternate_Number = "";
            this._Intru_Email = "";
            this._Intru_Comments = "";
            this._Intru_Contact_Alarm_Type = "";
            this._Fence = null;
            this._Fence_Razor_Wire = false;
            this._Fence_Electrified = false;
            this._Generator = null;
            this._Generator_Make = "";
            this._Generator_Model = "";
            this._Generator_Size = "";
            this._Fire_Department_Type = "";
            this._Fire_Department_Distance = "";
            this._Tier_1_County = null;
            this._Earthquake_Zone_Fault_Line = null;
            this._Neighboring_Buildings_within_100_ft = null;
            this._Neighbor_Occupancy = "";
            this._Distance_from_body_of_water = "";
            this._Prior_Flood_History = null;
            this._Flood_History_Descr = "";
            this._Lowest_finish_floor_elevation = -1;
            this._Property_Damage_Losses_in_the_Past_5_years = null;
            this._Property_Loss_Descr = "";
            this._Flood_Zone = "";
            this._National_Flood_Policy = null;
            this._Flood_Carrier = "";
            this._Flood_Policy_Number = "";
            this._Flood_Premium = null;
            this._Flood_Polciy_Limits_Contents = null;
            this._Flood_Policy_Inception_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Flood_Policy_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Flood_Deductible = null;
            this._Flood_Policy_Limits_Building = null;
            this._Comments = "";
            this._Building_Number = "";
            this._Ownership = "";
            this._Occupancy_Sales_New = false;
            this._Occupancy_Body_Shop = false;
            this._Occupancy_Parking_Lot = false;
            this._Occupancy_Sales_Used = false;
            this._Occupancy_Parts = false;
            this._Occupancy_Raw_Land = false;
            this._Occupancy_Service = false;
            this._Occupancy_Ofifce = false;
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._State = "";
            this._Zip = "";
            this._Building_Limit = null;
            this._Leasehold_Interests_Limit_Betterment = null;
            this._Betterment_Date_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Leasehold_Interests_Limit_Expansion = null;
            this._Expansion_Date_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Associate_Tools_Limit = null;
            this._Contents_Limit = null;
            this._Parts_Limit = null;
            this._Inventory_Levels = null;
            this._Year_Built = "";
            this._Square_Footage = "";
            this._Number_of_Stories = 0.0;
            this._Roof_Reinforced_Concrete = false;
            this._Roof_Concrete_Panels = false;
            this._Roof_Steel_Deck_with_Fasteners = false;
            this._Roof_Poured_Concrete = false;
            this._Roof_Steel_Deck = false;
            this._Roof_Wood_Joists = false;
            this._Floors_Reinforced_Concrete = false;
            this._Floors_Poured_Concrete = false;
            this._Floors_Wood_Timber = false;
            this._Ext_Walls_Reinforced_Concrete = false;
            this._Ext_Walls_Masonry = false;
            this._Ext_Walls_Corrugated_Metal_Panels = false;
            this._Ext_Walls_Tilt_up_Concrete = false;
            this._Ext_Walls_Glass_and_Steel_Curtain = false;
            this._Ext_Walls_Wood_Frame = false;
            this._Int_Walls_Masonry_With_Fire_Doors = false;
            this._Int_Walls_Masonry_with_Openings = false;
            this._Int_Walls_No_Interior_Walls = false;
            this._Int_Walls_Masonry = false;
            this._Int_Walls_Gypsum_Board = false;
            this._Int_wall_extend_above_roof = null;
            this._Number_of_Paint_Booths = 0;
            this._Number_of_Lifts = 0;
            this._Sales_New_Sprinklered = 0.0;
            this._Sales_Used_Sprinklered = 0.0;
            this._Service_Sprinklered = 0.0;
            this._Body_Shop_Sprinklered = 0.0;
            this._Parts_Sprinklered = 0.0;
            this._Office_Sprinklered = 0.0;
            this._Water_Public = false;
            this._Water_Private = false;
            this._Water_Boosted = false;
            this._Design_Densities_for_each_area = "";
            this._Hydrants_within_500_ft = null;
            this._Alarm_UL_Central_Station = false;
            this._Alarm_Constant_Attended = false;
            this._Alarm_Sprinkler_Valve_Tamper = false;
            this._Alarm_Non_UL_Central_Station = false;
            this._Alarm_Local = false;
            this._Alarm_Smoke_Detectors = false;
            this._Alarm_Proprietary = false;
            this._Alarm_Sprinkler_Waterflow = false;
            this._Alarm_Dry_Pipe_Air = false;
            this._Alarm_Remote = false;
            this._Alarm_Fire_Pump_Alarms = false;
            this._Alarm_Auto_Fire_Alarms = null;
            this._Alarm_Security_Cameras = null;
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Number_of_Bays = null;
            this._Number_of_Lifts_SC = null;
            this._Number_of_Prep_Areas = null;
            this._Number_of_Car_Wash_Stations = null;
            this._RS_Means_Building_Value = null;
            this._Fire_Contact_Name = null;
            this._Fire_Vendor_Name = null;
            this._Fire_Contact_Expiration_Date = null;
            this._Fire_Address_1 = null;
            this._Fire_Address_2 = null;
            this._Fire_City = null;
            this._Fire_State = null;
            this._Fire_Zip = null;
            this._Fire_Telephone_Number = null;
            this._Fire_Alternate_Number = null;
            this._Fire_Email = null;
            this._Fire_Comments = null;
            this._Location_Status = null;
            this._Liability = null;
            this._Number_Of_Parking_Spaces = null;
            this._Acreage = null;
            this._Occupancy_Car_Wash = false;
            this._Occupancy_Photo_Booth = false;
            this._FK_LU_Voltage_Security = null;	
            this._Voltage_Security_Other = null;	
            this._FK_LU_Power_Service = null;	
            this._Power_Service_Other = null;
            this._FK_LU_Phase_Power = null;
            this._FK_LU_Cable_Length = null;	
            this._Cable_Length_Other = null;
            this._Total_Amperage_Required = null;
            this._Occupancy_Main = false;
        }



        /// <summary> 
        /// Initializes a new instance of the Building class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Building(int PK)
        {

            DataTable dtBuilding = SelectByPK(PK).Tables[0];

            if (dtBuilding.Rows.Count > 0)
            {

                DataRow drBuilding = dtBuilding.Rows[0];

                this._PK_Building_ID = drBuilding["PK_Building_ID"] != DBNull.Value ? Convert.ToInt32(drBuilding["PK_Building_ID"]) : 0;
                this._FK_LU_Location_ID = drBuilding["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToInt32(drBuilding["FK_LU_Location_ID"]) : 0;
                this._SecuCam_System = Convert.ToString(drBuilding["SecuCam_System"]);
                this._SecuCam_Contact_Name = Convert.ToString(drBuilding["SecuCam_Contact_Name"]);
                this._SecuCam_Vendor_Name = Convert.ToString(drBuilding["SecuCam_Vendor_Name"]);
                this._SecuCam_Contact_Expiration_Date = drBuilding["SecuCam_Contact_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding["SecuCam_Contact_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._SecuCam_Address_1 = Convert.ToString(drBuilding["SecuCam_Address_1"]);
                this._SecuCam_Address_2 = Convert.ToString(drBuilding["SecuCam_Address_2"]);
                this._SecuCam_City = Convert.ToString(drBuilding["SecuCam_City"]);
                this._SecuCam_State = Convert.ToString(drBuilding["SecuCam_State"]);
                this._SecuCam_Zip = Convert.ToString(drBuilding["SecuCam_Zip"]);
                this._SecuCam_Telephone_Number = Convert.ToString(drBuilding["SecuCam_Telephone_Number"]);
                this._SecuCam_Alternate_Number = Convert.ToString(drBuilding["SecuCam_Alternate_Number"]);
                this._SecuCam_Email = Convert.ToString(drBuilding["SecuCam_Email"]);
                this._SecuCam_Comments = Convert.ToString(drBuilding["SecuCam_Comments"]);
                if (drBuilding["Guard_System"] != DBNull.Value) this._Guard_System = Convert.ToBoolean(drBuilding["Guard_System"]);
                this._Guard_System_Name = Convert.ToString(drBuilding["Guard_System_Name"]);
                this._Guard_Contact_Name = Convert.ToString(drBuilding["Guard_Contact_Name"]);
                this._Guard_Vendor_Name = Convert.ToString(drBuilding["Guard_Vendor_Name"]);
                this._Guard_Contact_Expiration_Date = drBuilding["Guard_Contact_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding["Guard_Contact_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Guard_Address_1 = Convert.ToString(drBuilding["Guard_Address_1"]);
                this._Guard_Address_2 = Convert.ToString(drBuilding["Guard_Address_2"]);
                this._Guard_City = Convert.ToString(drBuilding["Guard_City"]);
                this._Guard_State = Convert.ToString(drBuilding["Guard_State"]);
                this._Guard_Zip = Convert.ToString(drBuilding["Guard_Zip"]);
                this._Guard_Telephone_Number = Convert.ToString(drBuilding["Guard_Telephone_Number"]);
                this._Guard_Alternate_Number = Convert.ToString(drBuilding["Guard_Alternate_Number"]);
                this._Guard_Email = Convert.ToString(drBuilding["Guard_Email"]);
                this._Guard_Comments = Convert.ToString(drBuilding["Guard_Comments"]);
                if (drBuilding["Intru_System"] != DBNull.Value) this._Intru_System = Convert.ToBoolean(drBuilding["Intru_System"]);
                this._Intru_System_Name = Convert.ToString(drBuilding["Intru_System_Name"]);
                this._Intru_Contact_Name = Convert.ToString(drBuilding["Intru_Contact_Name"]);
                this._Intru_Vendor_Name = Convert.ToString(drBuilding["Intru_Vendor_Name"]);
                this._Intru_Contact_Expiration_Date = drBuilding["Intru_Contact_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding["Intru_Contact_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Intru_Address_1 = Convert.ToString(drBuilding["Intru_Address_1"]);
                this._Intru_Address_2 = Convert.ToString(drBuilding["Intru_Address_2"]);
                this._Intru_City = Convert.ToString(drBuilding["Intru_City"]);
                this._Intru_State = Convert.ToString(drBuilding["Intru_State"]);
                this._Intru_Zip = Convert.ToString(drBuilding["Intru_Zip"]);
                this._Intru_Telephone_Number = Convert.ToString(drBuilding["Intru_Telephone_Number"]);
                this._Intru_Alternate_Number = Convert.ToString(drBuilding["Intru_Alternate_Number"]);
                this._Intru_Email = Convert.ToString(drBuilding["Intru_Email"]);
                this._Intru_Comments = Convert.ToString(drBuilding["Intru_Comments"]);
                this._Intru_Contact_Alarm_Type = Convert.ToString(drBuilding["Intru_Contact_Alarm_Type"]);
                if (drBuilding["Fence"] != DBNull.Value) this._Fence = Convert.ToBoolean(drBuilding["Fence"]);
                this._Fence_Razor_Wire = drBuilding["Fence_Razor_Wire"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Fence_Razor_Wire"]) : false;
                this._Fence_Electrified = drBuilding["Fence_Electrified"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Fence_Electrified"]) : false;
                if (drBuilding["Generator"] != DBNull.Value) this._Generator = Convert.ToBoolean(drBuilding["Generator"]);
                this._Generator_Make = Convert.ToString(drBuilding["Generator_Make"]);
                this._Generator_Model = Convert.ToString(drBuilding["Generator_Model"]);
                this._Generator_Size = Convert.ToString(drBuilding["Generator_Size"]);
                this._Fire_Department_Type = Convert.ToString(drBuilding["Fire_Department_Type"]);
                this._Fire_Department_Distance = Convert.ToString(drBuilding["Fire_Department_Distance"]);
                if (drBuilding["Tier_1_County"] != DBNull.Value) this._Tier_1_County = Convert.ToBoolean(drBuilding["Tier_1_County"]);
                if (drBuilding["Earthquake_Zone_Fault_Line"] != DBNull.Value) this._Earthquake_Zone_Fault_Line = Convert.ToBoolean(drBuilding["Earthquake_Zone_Fault_Line"]);
                if (drBuilding["Neighboring_Buildings_within_100_ft"] != DBNull.Value) this._Neighboring_Buildings_within_100_ft = Convert.ToBoolean(drBuilding["Neighboring_Buildings_within_100_ft"]);
                this._Neighbor_Occupancy = Convert.ToString(drBuilding["Neighbor_Occupancy"]);
                this._Distance_from_body_of_water = Convert.ToString(drBuilding["Distance_from_body_of_water"]);
                if (drBuilding["Prior_Flood_History"] != DBNull.Value) this._Prior_Flood_History = Convert.ToBoolean(drBuilding["Prior_Flood_History"]);
                this._Flood_History_Descr = Convert.ToString(drBuilding["Flood_History_Descr"]);
                this._Lowest_finish_floor_elevation = drBuilding["Lowest_finish_floor_elevation"] != DBNull.Value ? Convert.ToInt32(drBuilding["Lowest_finish_floor_elevation"]) : 0;
                if (drBuilding["Property_Damage_Losses_in_the_Past_5_years"] != DBNull.Value) this._Property_Damage_Losses_in_the_Past_5_years = Convert.ToBoolean(drBuilding["Property_Damage_Losses_in_the_Past_5_years"]);
                this._Property_Loss_Descr = Convert.ToString(drBuilding["Property_Loss_Descr"]);
                this._Flood_Zone = Convert.ToString(drBuilding["Flood_Zone"]);
                if (drBuilding["National_Flood_Policy"] != DBNull.Value) this._National_Flood_Policy = Convert.ToBoolean(drBuilding["National_Flood_Policy"]);
                this._Flood_Carrier = Convert.ToString(drBuilding["Flood_Carrier"]);
                this._Flood_Policy_Number = Convert.ToString(drBuilding["Flood_Policy_Number"]);
                if (drBuilding["Flood_Premium"] != DBNull.Value) this._Flood_Premium = Convert.ToDecimal(drBuilding["Flood_Premium"]);
                if (drBuilding["Flood_Polciy_Limits_Contents"] != DBNull.Value) this._Flood_Polciy_Limits_Contents = Convert.ToDecimal(drBuilding["Flood_Polciy_Limits_Contents"]);
                this._Flood_Policy_Inception_Date = drBuilding["Flood_Policy_Inception_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding["Flood_Policy_Inception_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Flood_Policy_Expiration_Date = drBuilding["Flood_Policy_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding["Flood_Policy_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drBuilding["Flood_Deductible"] != DBNull.Value) this._Flood_Deductible = Convert.ToDecimal(drBuilding["Flood_Deductible"]);
                if (drBuilding["Flood_Policy_Limits_Building"] != DBNull.Value) this._Flood_Policy_Limits_Building = Convert.ToDecimal(drBuilding["Flood_Policy_Limits_Building"]);
                this._Comments = Convert.ToString(drBuilding["Comments"]);
                this._Building_Number = Convert.ToString(drBuilding["Building_Number"]);
                this._Ownership = Convert.ToString(drBuilding["Ownership"]);
                this._Occupancy_Sales_New = drBuilding["Occupancy_Sales_New"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Sales_New"]) : false;
                this._Occupancy_Body_Shop = drBuilding["Occupancy_Body_Shop"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Body_Shop"]) : false;
                this._Occupancy_Parking_Lot = drBuilding["Occupancy_Parking_Lot"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Parking_Lot"]) : false;
                this._Occupancy_Sales_Used = drBuilding["Occupancy_Sales_Used"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Sales_Used"]) : false;
                this._Occupancy_Parts = drBuilding["Occupancy_Parts"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Parts"]) : false;
                this._Occupancy_Raw_Land = drBuilding["Occupancy_Raw_Land"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Raw_Land"]) : false;
                this._Occupancy_Service = drBuilding["Occupancy_Service"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Service"]) : false;
                this._Occupancy_Ofifce = drBuilding["Occupancy_Ofifce"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Ofifce"]) : false;
                this._Address_1 = Convert.ToString(drBuilding["Address_1"]);
                this._Address_2 = Convert.ToString(drBuilding["Address_2"]);
                this._City = Convert.ToString(drBuilding["City"]);
                this._State = Convert.ToString(drBuilding["State"]);
                this._Zip = Convert.ToString(drBuilding["Zip"]);
                if (drBuilding["Building_Limit"] != DBNull.Value) this._Building_Limit = Convert.ToDecimal(drBuilding["Building_Limit"]);
                if (drBuilding["Leasehold_Interests_Limit_Betterment"] != DBNull.Value) this._Leasehold_Interests_Limit_Betterment = Convert.ToDecimal(drBuilding["Leasehold_Interests_Limit_Betterment"]);
                this._Betterment_Date_Complete = drBuilding["Betterment_Date_Complete"] != DBNull.Value ? Convert.ToDateTime(drBuilding["Betterment_Date_Complete"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drBuilding["Leasehold_Interests_Limit_Expansion"] != DBNull.Value) this._Leasehold_Interests_Limit_Expansion = Convert.ToDecimal(drBuilding["Leasehold_Interests_Limit_Expansion"]);
                this._Expansion_Date_Complete = drBuilding["Expansion_Date_Complete"] != DBNull.Value ? Convert.ToDateTime(drBuilding["Expansion_Date_Complete"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drBuilding["Associate_Tools_Limit"] != DBNull.Value) this._Associate_Tools_Limit = Convert.ToDecimal(drBuilding["Associate_Tools_Limit"]);
                if (drBuilding["Contents_Limit"] != DBNull.Value) this._Contents_Limit = Convert.ToDecimal(drBuilding["Contents_Limit"]);
                if (drBuilding["Parts_Limit"] != DBNull.Value) this._Parts_Limit = Convert.ToDecimal(drBuilding["Parts_Limit"]);
                if (drBuilding["Inventory_Levels"] != DBNull.Value) this._Inventory_Levels = Convert.ToDecimal(drBuilding["Inventory_Levels"]);
                this._Year_Built = Convert.ToString(drBuilding["Year_Built"]);
                this._Square_Footage = Convert.ToString(drBuilding["Square_Footage"]);
                this._Number_of_Stories = drBuilding["Number_of_Stories"] != DBNull.Value ? Convert.ToDouble(drBuilding["Number_of_Stories"]) : 0.0;
                this._Roof_Reinforced_Concrete = drBuilding["Roof_Reinforced_Concrete"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Roof_Reinforced_Concrete"]) : false;
                this._Roof_Concrete_Panels = drBuilding["Roof_Concrete_Panels"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Roof_Concrete_Panels"]) : false;
                this._Roof_Steel_Deck_with_Fasteners = drBuilding["Roof_Steel_Deck_with_Fasteners"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Roof_Steel_Deck_with_Fasteners"]) : false;
                this._Roof_Poured_Concrete = drBuilding["Roof_Poured_Concrete"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Roof_Poured_Concrete"]) : false;
                this._Roof_Steel_Deck = drBuilding["Roof_Steel_Deck"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Roof_Steel_Deck"]) : false;
                this._Roof_Wood_Joists = drBuilding["Roof_Wood_Joists"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Roof_Wood_Joists"]) : false;
                this._Floors_Reinforced_Concrete = drBuilding["Floors_Reinforced_Concrete"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Floors_Reinforced_Concrete"]) : false;
                this._Floors_Poured_Concrete = drBuilding["Floors_Poured_Concrete"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Floors_Poured_Concrete"]) : false;
                this._Floors_Wood_Timber = drBuilding["Floors_Wood_Timber"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Floors_Wood_Timber"]) : false;
                this._Ext_Walls_Reinforced_Concrete = drBuilding["Ext_Walls_Reinforced_Concrete"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Ext_Walls_Reinforced_Concrete"]) : false;
                this._Ext_Walls_Masonry = drBuilding["Ext_Walls_Masonry"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Ext_Walls_Masonry"]) : false;
                this._Ext_Walls_Corrugated_Metal_Panels = drBuilding["Ext_Walls_Corrugated_Metal_Panels"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Ext_Walls_Corrugated_Metal_Panels"]) : false;
                this._Ext_Walls_Tilt_up_Concrete = drBuilding["Ext_Walls_Tilt_up_Concrete"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Ext_Walls_Tilt_up_Concrete"]) : false;
                this._Ext_Walls_Glass_and_Steel_Curtain = drBuilding["Ext_Walls_Glass_and_Steel_Curtain"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Ext_Walls_Glass_and_Steel_Curtain"]) : false;
                this._Ext_Walls_Wood_Frame = drBuilding["Ext_Walls_Wood_Frame"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Ext_Walls_Wood_Frame"]) : false;
                this._Int_Walls_Masonry_With_Fire_Doors = drBuilding["Int_Walls_Masonry_With_Fire_Doors"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Int_Walls_Masonry_With_Fire_Doors"]) : false;
                this._Int_Walls_Masonry_with_Openings = drBuilding["Int_Walls_Masonry_with_Openings"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Int_Walls_Masonry_with_Openings"]) : false;
                this._Int_Walls_No_Interior_Walls = drBuilding["Int_Walls_No_Interior_Walls"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Int_Walls_No_Interior_Walls"]) : false;
                this._Int_Walls_Masonry = drBuilding["Int_Walls_Masonry"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Int_Walls_Masonry"]) : false;
                this._Int_Walls_Gypsum_Board = drBuilding["Int_Walls_Gypsum_Board"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Int_Walls_Gypsum_Board"]) : false;
                if (drBuilding["Int_wall_extend_above_roof"] != DBNull.Value) this._Int_wall_extend_above_roof = Convert.ToBoolean(drBuilding["Int_wall_extend_above_roof"]);
                this._Number_of_Paint_Booths = drBuilding["Number_of_Paint_Booths"] != DBNull.Value ? Convert.ToInt32(drBuilding["Number_of_Paint_Booths"]) : 0;
                this._Number_of_Lifts = drBuilding["Number_of_Lifts"] != DBNull.Value ? Convert.ToInt32(drBuilding["Number_of_Lifts"]) : 0;
                this._Sales_New_Sprinklered = drBuilding["Sales_New_Sprinklered"] != DBNull.Value ? Convert.ToDouble(drBuilding["Sales_New_Sprinklered"]) : 0.0;
                this._Sales_Used_Sprinklered = drBuilding["Sales_Used_Sprinklered"] != DBNull.Value ? Convert.ToDouble(drBuilding["Sales_Used_Sprinklered"]) : 0.0;
                this._Service_Sprinklered = drBuilding["Service_Sprinklered"] != DBNull.Value ? Convert.ToDouble(drBuilding["Service_Sprinklered"]) : 0.0;
                this._Body_Shop_Sprinklered = drBuilding["Body_Shop_Sprinklered"] != DBNull.Value ? Convert.ToDouble(drBuilding["Body_Shop_Sprinklered"]) : 0.0;
                this._Parts_Sprinklered = drBuilding["Parts_Sprinklered"] != DBNull.Value ? Convert.ToDouble(drBuilding["Parts_Sprinklered"]) : 0.0;
                this._Office_Sprinklered = drBuilding["Office_Sprinklered"] != DBNull.Value ? Convert.ToDouble(drBuilding["Office_Sprinklered"]) : 0.0;
                this._Water_Public = drBuilding["Water_Public"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Water_Public"]) : false;
                this._Water_Private = drBuilding["Water_Private"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Water_Private"]) : false;
                this._Water_Boosted = drBuilding["Water_Boosted"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Water_Boosted"]) : false;
                this._Design_Densities_for_each_area = Convert.ToString(drBuilding["Design_Densities_for_each_area"]);
                if (drBuilding["Hydrants_within_500_ft"] != DBNull.Value) this._Hydrants_within_500_ft = Convert.ToBoolean(drBuilding["Hydrants_within_500_ft"]);
                this._Alarm_UL_Central_Station = drBuilding["Alarm_UL_Central_Station"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_UL_Central_Station"]) : false;
                this._Alarm_Constant_Attended = drBuilding["Alarm_Constant_Attended"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Constant_Attended"]) : false;
                this._Alarm_Sprinkler_Valve_Tamper = drBuilding["Alarm_Sprinkler_Valve_Tamper"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Sprinkler_Valve_Tamper"]) : false;
                this._Alarm_Non_UL_Central_Station = drBuilding["Alarm_Non_UL_Central_Station"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Non_UL_Central_Station"]) : false;
                this._Alarm_Local = drBuilding["Alarm_Local"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Local"]) : false;
                this._Alarm_Smoke_Detectors = drBuilding["Alarm_Smoke_Detectors"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Smoke_Detectors"]) : false;
                this._Alarm_Proprietary = drBuilding["Alarm_Proprietary"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Proprietary"]) : false;
                this._Alarm_Sprinkler_Waterflow = drBuilding["Alarm_Sprinkler_Waterflow"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Sprinkler_Waterflow"]) : false;
                this._Alarm_Dry_Pipe_Air = drBuilding["Alarm_Dry_Pipe_Air"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Dry_Pipe_Air"]) : false;
                this._Alarm_Remote = drBuilding["Alarm_Remote"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Remote"]) : false;
                this._Alarm_Fire_Pump_Alarms = drBuilding["Alarm_Fire_Pump_Alarms"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Alarm_Fire_Pump_Alarms"]) : false;
                if (drBuilding["Alarm_Auto_Fire_Alarms"] != DBNull.Value) this._Alarm_Auto_Fire_Alarms = Convert.ToBoolean(drBuilding["Alarm_Auto_Fire_Alarms"]);
                if (drBuilding["Alarm_Security_Cameras"] != DBNull.Value) this._Alarm_Security_Cameras = Convert.ToBoolean(drBuilding["Alarm_Security_Cameras"]);
                this._Updated_By = drBuilding["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drBuilding["Updated_By"]) : 0;
                this._Updated_Date = drBuilding["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

                if (drBuilding["RS_Means_Building_Value"] != DBNull.Value)
                    this._RS_Means_Building_Value = Convert.ToDecimal(drBuilding["RS_Means_Building_Value"]);

                if (drBuilding["Number_of_Bays"] == DBNull.Value)
                    this._Number_of_Bays = null;
                else
                    this._Number_of_Bays = (int?)drBuilding["Number_of_Bays"];

                if (drBuilding["Number_of_Lifts_SC"] == DBNull.Value)
                    this._Number_of_Lifts_SC = null;
                else
                    this._Number_of_Lifts_SC = (int?)drBuilding["Number_of_Lifts_SC"];

                if (drBuilding["Number_of_Prep_Areas"] == DBNull.Value)
                    this._Number_of_Prep_Areas = null;
                else
                    this._Number_of_Prep_Areas = (int?)drBuilding["Number_of_Prep_Areas"];

                if (drBuilding["Number_of_Car_Wash_Stations"] == DBNull.Value)
                    this._Number_of_Car_Wash_Stations = null;
                else
                    this._Number_of_Car_Wash_Stations = (int?)drBuilding["Number_of_Car_Wash_Stations"];


                if (drBuilding["Fire_Contact_Name"] == DBNull.Value)
                    this._Fire_Contact_Name = null;
                else
                    this._Fire_Contact_Name = (string)drBuilding["Fire_Contact_Name"];

                if (drBuilding["Fire_Vendor_Name"] == DBNull.Value)
                    this._Fire_Vendor_Name = null;
                else
                    this._Fire_Vendor_Name = (string)drBuilding["Fire_Vendor_Name"];

                if (drBuilding["Fire_Contact_Expiration_Date"] == DBNull.Value)
                    this._Fire_Contact_Expiration_Date = null;
                else
                    this._Fire_Contact_Expiration_Date = (DateTime?)drBuilding["Fire_Contact_Expiration_Date"];

                if (drBuilding["Fire_Address_1"] == DBNull.Value)
                    this._Fire_Address_1 = null;
                else
                    this._Fire_Address_1 = (string)drBuilding["Fire_Address_1"];

                if (drBuilding["Fire_Address_2"] == DBNull.Value)
                    this._Fire_Address_2 = null;
                else
                    this._Fire_Address_2 = (string)drBuilding["Fire_Address_2"];

                if (drBuilding["Fire_City"] == DBNull.Value)
                    this._Fire_City = null;
                else
                    this._Fire_City = (string)drBuilding["Fire_City"];

                if (drBuilding["Fire_State"] == DBNull.Value)
                    this._Fire_State = null;
                else
                    this._Fire_State = (string)drBuilding["Fire_State"];

                if (drBuilding["Fire_Zip"] == DBNull.Value)
                    this._Fire_Zip = null;
                else
                    this._Fire_Zip = (string)drBuilding["Fire_Zip"];

                if (drBuilding["Fire_Telephone_Number"] == DBNull.Value)
                    this._Fire_Telephone_Number = null;
                else
                    this._Fire_Telephone_Number = (string)drBuilding["Fire_Telephone_Number"];

                if (drBuilding["Fire_Alternate_Number"] == DBNull.Value)
                    this._Fire_Alternate_Number = null;
                else
                    this._Fire_Alternate_Number = (string)drBuilding["Fire_Alternate_Number"];

                if (drBuilding["Fire_Email"] == DBNull.Value)
                    this._Fire_Email = null;
                else
                    this._Fire_Email = (string)drBuilding["Fire_Email"];

                if (drBuilding["Fire_Comments"] == DBNull.Value)
                    this._Fire_Comments = null;
                else
                    this._Fire_Comments = (string)drBuilding["Fire_Comments"];

                if (drBuilding["Location_Status"] == DBNull.Value)
                    this._Location_Status = null;
                else
                    this._Location_Status = (string)drBuilding["Location_Status"];

                if (drBuilding["Liability"] == DBNull.Value)
                    this._Liability = null;
                else
                    this._Liability = (string)drBuilding["Liability"];

                if (drBuilding["Number_Of_Parking_Spaces"] == DBNull.Value)
                    this._Number_Of_Parking_Spaces = null;
                else
                    this._Number_Of_Parking_Spaces = (int?)drBuilding["Number_Of_Parking_Spaces"];
                if (drBuilding["Acreage"] == DBNull.Value)
                    this._Acreage = null;
                else
                    this._Acreage = (decimal?)drBuilding["Acreage"];

                this._Occupancy_Car_Wash = drBuilding["Occupancy_Car_Wash"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Car_Wash"]) : false;
                this._Occupancy_Photo_Booth = drBuilding["Occupancy_Photo_Booth"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Photo_Booth"]) : false;
                this._FK_LU_Voltage_Security = clsGeneral.GetDecimal(drBuilding["FK_LU_Voltage_Security"]);
                this._FK_LU_Power_Service = clsGeneral.GetDecimal(drBuilding["FK_LU_Power_Service"]);
                this._FK_LU_Phase_Power = clsGeneral.GetDecimal(drBuilding["FK_LU_Phase_Power"]);
                this._FK_LU_Cable_Length = clsGeneral.GetDecimal(drBuilding["FK_LU_Cable_Length"]);
                this._Voltage_Security_Other = Convert.ToString(drBuilding["Voltage_Security_Other"]);
                this._Power_Service_Other = Convert.ToString(drBuilding["Power_Service_Other"]);
                this._Cable_Length_Other = Convert.ToString(drBuilding["Cable_Length_Other"]);
                this._Total_Amperage_Required = Convert.ToString(drBuilding["Total_Amperage_Required"]);
                this._Occupancy_Main = drBuilding["Occupancy_Main"] != DBNull.Value ? Convert.ToBoolean(drBuilding["Occupancy_Main"]) : false;
            }
            else
            {
                this._PK_Building_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._SecuCam_System = "";
                this._SecuCam_Contact_Name = "";
                this._SecuCam_Vendor_Name = "";
                this._SecuCam_Contact_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._SecuCam_Address_1 = "";
                this._SecuCam_Address_2 = "";
                this._SecuCam_City = "";
                this._SecuCam_State = "";
                this._SecuCam_Zip = "";
                this._SecuCam_Telephone_Number = "";
                this._SecuCam_Alternate_Number = "";
                this._SecuCam_Email = "";
                this._SecuCam_Comments = "";
                this._Guard_System = null;
                this._Guard_System_Name = "";
                this._Guard_Contact_Name = "";
                this._Guard_Vendor_Name = "";
                this._Guard_Contact_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Guard_Address_1 = "";
                this._Guard_Address_2 = "";
                this._Guard_City = "";
                this._Guard_State = "";
                this._Guard_Zip = "";
                this._Guard_Telephone_Number = "";
                this._Guard_Alternate_Number = "";
                this._Guard_Email = "";
                this._Guard_Comments = "";
                this._Intru_System = null;
                this._Intru_System_Name = "";
                this._Intru_Contact_Name = "";
                this._Intru_Vendor_Name = "";
                this._Intru_Contact_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Intru_Address_1 = "";
                this._Intru_Address_2 = "";
                this._Intru_City = "";
                this._Intru_State = "";
                this._Intru_Zip = "";
                this._Intru_Telephone_Number = "";
                this._Intru_Alternate_Number = "";
                this._Intru_Email = "";
                this._Intru_Comments = "";
                this._Intru_Contact_Alarm_Type = "";
                this._Fence = null;
                this._Fence_Razor_Wire = false;
                this._Fence_Electrified = false;
                this._Generator = null;
                this._Generator_Make = "";
                this._Generator_Model = "";
                this._Generator_Size = "";
                this._Fire_Department_Type = "";
                this._Fire_Department_Distance = "";
                this._Tier_1_County = null;
                this._Earthquake_Zone_Fault_Line = null;
                this._Neighboring_Buildings_within_100_ft = null;
                this._Neighbor_Occupancy = "";
                this._Distance_from_body_of_water = "";
                this._Prior_Flood_History = null;
                this._Flood_History_Descr = "";
                this._Lowest_finish_floor_elevation = -1;
                this._Property_Damage_Losses_in_the_Past_5_years = null;
                this._Property_Loss_Descr = "";
                this._Flood_Zone = "";
                this._National_Flood_Policy = null;
                this._Flood_Carrier = "";
                this._Flood_Policy_Number = "";
                this._Flood_Premium = -1;
                this._Flood_Polciy_Limits_Contents = -1;
                this._Flood_Policy_Inception_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Flood_Policy_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Flood_Deductible = null;
                this._Flood_Policy_Limits_Building = null;
                this._Comments = "";
                this._Building_Number = "";
                this._Ownership = "";
                this._Occupancy_Sales_New = false;
                this._Occupancy_Body_Shop = false;
                this._Occupancy_Parking_Lot = false;
                this._Occupancy_Sales_Used = false;
                this._Occupancy_Parts = false;
                this._Occupancy_Raw_Land = false;
                this._Occupancy_Service = false;
                this._Occupancy_Ofifce = false;
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._State = "";
                this._Zip = "";
                this._Building_Limit = null;
                this._Leasehold_Interests_Limit_Betterment = null;
                this._Betterment_Date_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Leasehold_Interests_Limit_Expansion = -1;
                this._Expansion_Date_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Associate_Tools_Limit = null;
                this._Contents_Limit = null;
                this._Parts_Limit = null;
                this._Inventory_Levels = null;
                this._Year_Built = "";
                this._Square_Footage = "";
                this._Number_of_Stories = 0.0;
                this._Roof_Reinforced_Concrete = false;
                this._Roof_Concrete_Panels = false;
                this._Roof_Steel_Deck_with_Fasteners = false;
                this._Roof_Poured_Concrete = false;
                this._Roof_Steel_Deck = false;
                this._Roof_Wood_Joists = false;
                this._Floors_Reinforced_Concrete = false;
                this._Floors_Poured_Concrete = false;
                this._Floors_Wood_Timber = false;
                this._Ext_Walls_Reinforced_Concrete = false;
                this._Ext_Walls_Masonry = false;
                this._Ext_Walls_Corrugated_Metal_Panels = false;
                this._Ext_Walls_Tilt_up_Concrete = false;
                this._Ext_Walls_Glass_and_Steel_Curtain = false;
                this._Ext_Walls_Wood_Frame = false;
                this._Int_Walls_Masonry_With_Fire_Doors = false;
                this._Int_Walls_Masonry_with_Openings = false;
                this._Int_Walls_No_Interior_Walls = false;
                this._Int_Walls_Masonry = false;
                this._Int_Walls_Gypsum_Board = false;
                this._Int_wall_extend_above_roof = null;
                this._Number_of_Paint_Booths = 0;
                this._Number_of_Lifts = 0;
                this._Sales_New_Sprinklered = 0.0;
                this._Sales_Used_Sprinklered = 0.0;
                this._Service_Sprinklered = 0.0;
                this._Body_Shop_Sprinklered = 0.0;
                this._Parts_Sprinklered = 0.0;
                this._Office_Sprinklered = 0.0;
                this._Water_Public = false;
                this._Water_Private = false;
                this._Water_Boosted = false;
                this._Design_Densities_for_each_area = "";
                this._Hydrants_within_500_ft = null;
                this._Alarm_UL_Central_Station = false;
                this._Alarm_Constant_Attended = false;
                this._Alarm_Sprinkler_Valve_Tamper = false;
                this._Alarm_Non_UL_Central_Station = false;
                this._Alarm_Local = false;
                this._Alarm_Smoke_Detectors = false;
                this._Alarm_Proprietary = false;
                this._Alarm_Sprinkler_Waterflow = false;
                this._Alarm_Dry_Pipe_Air = false;
                this._Alarm_Remote = false;
                this._Alarm_Fire_Pump_Alarms = false;
                this._Alarm_Auto_Fire_Alarms = null;
                this._Alarm_Security_Cameras = null;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Number_of_Bays = null;
                this._Number_of_Lifts_SC = null;
                this._Number_of_Prep_Areas = null;
                this._Number_of_Car_Wash_Stations = null;
                this._RS_Means_Building_Value = null;
                this._Fire_Contact_Name = null;
                this._Fire_Vendor_Name = null;
                this._Fire_Contact_Expiration_Date = null;
                this._Fire_Address_1 = null;
                this._Fire_Address_2 = null;
                this._Fire_City = null;
                this._Fire_State = null;
                this._Fire_Zip = null;
                this._Fire_Telephone_Number = null;
                this._Fire_Alternate_Number = null;
                this._Fire_Email = null;
                this._Fire_Comments = null;
                this._Location_Status = null;
                this._Liability = null;
                this._Number_Of_Parking_Spaces = null;
                this._Acreage = null;
                this._Occupancy_Car_Wash = false;
                this._Occupancy_Photo_Booth = false;
                this._FK_LU_Voltage_Security = null;
                this._Voltage_Security_Other = null;
                this._FK_LU_Power_Service = null;
                this._Power_Service_Other = null;
                this._FK_LU_Phase_Power = null;
                this._FK_LU_Cable_Length = null;
                this._Cable_Length_Other = null;
                this._Total_Amperage_Required = null;
                this._Occupancy_Main = false;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Building table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingInsert");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "SecuCam_System", DbType.String, this._SecuCam_System);
            db.AddInParameter(dbCommand, "SecuCam_Contact_Name", DbType.String, this._SecuCam_Contact_Name);
            db.AddInParameter(dbCommand, "SecuCam_Vendor_Name", DbType.String, this._SecuCam_Vendor_Name);

            if (this._SecuCam_Contact_Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "SecuCam_Contact_Expiration_Date", DbType.DateTime, this._SecuCam_Contact_Expiration_Date);
            else
                db.AddInParameter(dbCommand, "SecuCam_Contact_Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "SecuCam_Address_1", DbType.String, this._SecuCam_Address_1);
            db.AddInParameter(dbCommand, "SecuCam_Address_2", DbType.String, this._SecuCam_Address_2);
            db.AddInParameter(dbCommand, "SecuCam_City", DbType.String, this._SecuCam_City);
            db.AddInParameter(dbCommand, "SecuCam_State", DbType.String, this._SecuCam_State);
            db.AddInParameter(dbCommand, "SecuCam_Zip", DbType.String, this._SecuCam_Zip);
            db.AddInParameter(dbCommand, "SecuCam_Telephone_Number", DbType.String, this._SecuCam_Telephone_Number);
            db.AddInParameter(dbCommand, "SecuCam_Alternate_Number", DbType.String, this._SecuCam_Alternate_Number);
            db.AddInParameter(dbCommand, "SecuCam_Email", DbType.String, this._SecuCam_Email);
            db.AddInParameter(dbCommand, "SecuCam_Comments", DbType.String, this._SecuCam_Comments);
            db.AddInParameter(dbCommand, "Guard_System", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Guard_System));
            db.AddInParameter(dbCommand, "Guard_System_Name", DbType.String, this._Guard_System_Name);
            db.AddInParameter(dbCommand, "Guard_Contact_Name", DbType.String, this._Guard_Contact_Name);
            db.AddInParameter(dbCommand, "Guard_Vendor_Name", DbType.String, this._Guard_Vendor_Name);

            if (this._Guard_Contact_Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Guard_Contact_Expiration_Date", DbType.DateTime, this._Guard_Contact_Expiration_Date);
            else
                db.AddInParameter(dbCommand, "Guard_Contact_Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Guard_Address_1", DbType.String, this._Guard_Address_1);
            db.AddInParameter(dbCommand, "Guard_Address_2", DbType.String, this._Guard_Address_2);
            db.AddInParameter(dbCommand, "Guard_City", DbType.String, this._Guard_City);
            db.AddInParameter(dbCommand, "Guard_State", DbType.String, this._Guard_State);
            db.AddInParameter(dbCommand, "Guard_Zip", DbType.String, this._Guard_Zip);
            db.AddInParameter(dbCommand, "Guard_Telephone_Number", DbType.String, this._Guard_Telephone_Number);
            db.AddInParameter(dbCommand, "Guard_Alternate_Number", DbType.String, this._Guard_Alternate_Number);
            db.AddInParameter(dbCommand, "Guard_Email", DbType.String, this._Guard_Email);
            db.AddInParameter(dbCommand, "Guard_Comments", DbType.String, this._Guard_Comments);
            db.AddInParameter(dbCommand, "Intru_System", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Intru_System));
            db.AddInParameter(dbCommand, "Intru_System_Name", DbType.String, this._Intru_System_Name);
            db.AddInParameter(dbCommand, "Intru_Contact_Name", DbType.String, this._Intru_Contact_Name);
            db.AddInParameter(dbCommand, "Intru_Vendor_Name", DbType.String, this._Intru_Vendor_Name);

            if (this._Intru_Contact_Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Intru_Contact_Expiration_Date", DbType.DateTime, this._Intru_Contact_Expiration_Date);
            else
                db.AddInParameter(dbCommand, "Intru_Contact_Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Intru_Address_1", DbType.String, this._Intru_Address_1);
            db.AddInParameter(dbCommand, "Intru_Address_2", DbType.String, this._Intru_Address_2);
            db.AddInParameter(dbCommand, "Intru_City", DbType.String, this._Intru_City);
            db.AddInParameter(dbCommand, "Intru_State", DbType.String, this._Intru_State);
            db.AddInParameter(dbCommand, "Intru_Zip", DbType.String, this._Intru_Zip);
            db.AddInParameter(dbCommand, "Intru_Telephone_Number", DbType.String, this._Intru_Telephone_Number);
            db.AddInParameter(dbCommand, "Intru_Alternate_Number", DbType.String, this._Intru_Alternate_Number);
            db.AddInParameter(dbCommand, "Intru_Email", DbType.String, this._Intru_Email);
            db.AddInParameter(dbCommand, "Intru_Comments", DbType.String, this._Intru_Comments);
            db.AddInParameter(dbCommand, "Intru_Contact_Alarm_Type", DbType.String, this._Intru_Contact_Alarm_Type);
            db.AddInParameter(dbCommand, "Fence", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Fence));
            db.AddInParameter(dbCommand, "Fence_Razor_Wire", DbType.Boolean, this._Fence_Razor_Wire);
            db.AddInParameter(dbCommand, "Fence_Electrified", DbType.Boolean, this._Fence_Electrified);
            db.AddInParameter(dbCommand, "Generator", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Generator));
            db.AddInParameter(dbCommand, "Generator_Make", DbType.String, this._Generator_Make);
            db.AddInParameter(dbCommand, "Generator_Model", DbType.String, this._Generator_Model);
            db.AddInParameter(dbCommand, "Generator_Size", DbType.String, this._Generator_Size);
            db.AddInParameter(dbCommand, "Fire_Department_Type", DbType.String, this._Fire_Department_Type);
            db.AddInParameter(dbCommand, "Fire_Department_Distance", DbType.String, this._Fire_Department_Distance);
            db.AddInParameter(dbCommand, "Tier_1_County", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Tier_1_County));
            db.AddInParameter(dbCommand, "Earthquake_Zone_Fault_Line", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Earthquake_Zone_Fault_Line));
            db.AddInParameter(dbCommand, "Neighboring_Buildings_within_100_ft", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Neighboring_Buildings_within_100_ft));
            db.AddInParameter(dbCommand, "Neighbor_Occupancy", DbType.String, this._Neighbor_Occupancy);
            db.AddInParameter(dbCommand, "Distance_from_body_of_water", DbType.String, this._Distance_from_body_of_water);
            db.AddInParameter(dbCommand, "Prior_Flood_History", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Prior_Flood_History));
            db.AddInParameter(dbCommand, "Flood_History_Descr", DbType.String, this._Flood_History_Descr);
            db.AddInParameter(dbCommand, "Lowest_finish_floor_elevation", DbType.Int32, this._Lowest_finish_floor_elevation);
            db.AddInParameter(dbCommand, "Property_Damage_Losses_in_the_Past_5_years", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Property_Damage_Losses_in_the_Past_5_years));
            db.AddInParameter(dbCommand, "Property_Loss_Descr", DbType.String, this._Property_Loss_Descr);
            db.AddInParameter(dbCommand, "Flood_Zone", DbType.String, this._Flood_Zone);
            db.AddInParameter(dbCommand, "National_Flood_Policy", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._National_Flood_Policy));
            db.AddInParameter(dbCommand, "Flood_Carrier", DbType.String, this._Flood_Carrier);
            db.AddInParameter(dbCommand, "Flood_Policy_Number", DbType.String, this._Flood_Policy_Number);
            db.AddInParameter(dbCommand, "Flood_Premium", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Flood_Premium));
            db.AddInParameter(dbCommand, "Flood_Polciy_Limits_Contents", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Flood_Polciy_Limits_Contents));

            if (this._Flood_Policy_Inception_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Flood_Policy_Inception_Date", DbType.DateTime, this._Flood_Policy_Inception_Date);
            else
                db.AddInParameter(dbCommand, "Flood_Policy_Inception_Date", DbType.DateTime, DBNull.Value);

            if (this._Flood_Policy_Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Flood_Policy_Expiration_Date", DbType.DateTime, this._Flood_Policy_Expiration_Date);
            else
                db.AddInParameter(dbCommand, "Flood_Policy_Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Flood_Deductible", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Flood_Deductible));
            db.AddInParameter(dbCommand, "Flood_Policy_Limits_Building", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Flood_Policy_Limits_Building));
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Building_Number", DbType.String, this._Building_Number);
            db.AddInParameter(dbCommand, "Ownership", DbType.String, this._Ownership);
            db.AddInParameter(dbCommand, "Occupancy_Sales_New", DbType.Boolean, this._Occupancy_Sales_New);
            db.AddInParameter(dbCommand, "Occupancy_Body_Shop", DbType.Boolean, this._Occupancy_Body_Shop);
            db.AddInParameter(dbCommand, "Occupancy_Parking_Lot", DbType.Boolean, this._Occupancy_Parking_Lot);
            db.AddInParameter(dbCommand, "Occupancy_Sales_Used", DbType.Boolean, this._Occupancy_Sales_Used);
            db.AddInParameter(dbCommand, "Occupancy_Parts", DbType.Boolean, this._Occupancy_Parts);
            db.AddInParameter(dbCommand, "Occupancy_Raw_Land", DbType.Boolean, this._Occupancy_Raw_Land);
            db.AddInParameter(dbCommand, "Occupancy_Service", DbType.Boolean, this._Occupancy_Service);
            db.AddInParameter(dbCommand, "Occupancy_Ofifce", DbType.Boolean, this._Occupancy_Ofifce);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, this._City);
            db.AddInParameter(dbCommand, "State", DbType.String, this._State);
            db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
            db.AddInParameter(dbCommand, "Building_Limit", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Building_Limit));
            db.AddInParameter(dbCommand, "Leasehold_Interests_Limit_Betterment", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Leasehold_Interests_Limit_Betterment));

            if (this._Betterment_Date_Complete != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Betterment_Date_Complete", DbType.DateTime, this._Betterment_Date_Complete);
            else
                db.AddInParameter(dbCommand, "Betterment_Date_Complete", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Leasehold_Interests_Limit_Expansion", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Leasehold_Interests_Limit_Expansion));
            db.AddInParameter(dbCommand, "RS_Means_Building_Value", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._RS_Means_Building_Value));

            if (this._Expansion_Date_Complete != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Expansion_Date_Complete", DbType.DateTime, this._Expansion_Date_Complete);
            else
                db.AddInParameter(dbCommand, "Expansion_Date_Complete", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Associate_Tools_Limit", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Associate_Tools_Limit));
            db.AddInParameter(dbCommand, "Contents_Limit", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Contents_Limit));
            db.AddInParameter(dbCommand, "Parts_Limit", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Parts_Limit));
            db.AddInParameter(dbCommand, "Inventory_Levels", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Inventory_Levels));
            db.AddInParameter(dbCommand, "Year_Built", DbType.String, this._Year_Built);
            db.AddInParameter(dbCommand, "Square_Footage", DbType.String, this._Square_Footage);
            db.AddInParameter(dbCommand, "Number_of_Stories", DbType.Double, this._Number_of_Stories);
            db.AddInParameter(dbCommand, "Roof_Reinforced_Concrete", DbType.Boolean, this._Roof_Reinforced_Concrete);
            db.AddInParameter(dbCommand, "Roof_Concrete_Panels", DbType.Boolean, this._Roof_Concrete_Panels);
            db.AddInParameter(dbCommand, "Roof_Steel_Deck_with_Fasteners", DbType.Boolean, this._Roof_Steel_Deck_with_Fasteners);
            db.AddInParameter(dbCommand, "Roof_Poured_Concrete", DbType.Boolean, this._Roof_Poured_Concrete);
            db.AddInParameter(dbCommand, "Roof_Steel_Deck", DbType.Boolean, this._Roof_Steel_Deck);
            db.AddInParameter(dbCommand, "Roof_Wood_Joists", DbType.Boolean, this._Roof_Wood_Joists);
            db.AddInParameter(dbCommand, "Floors_Reinforced_Concrete", DbType.Boolean, this._Floors_Reinforced_Concrete);
            db.AddInParameter(dbCommand, "Floors_Poured_Concrete", DbType.Boolean, this._Floors_Poured_Concrete);
            db.AddInParameter(dbCommand, "Floors_Wood_Timber", DbType.Boolean, this._Floors_Wood_Timber);
            db.AddInParameter(dbCommand, "Ext_Walls_Reinforced_Concrete", DbType.Boolean, this._Ext_Walls_Reinforced_Concrete);
            db.AddInParameter(dbCommand, "Ext_Walls_Masonry", DbType.Boolean, this._Ext_Walls_Masonry);
            db.AddInParameter(dbCommand, "Ext_Walls_Corrugated_Metal_Panels", DbType.Boolean, this._Ext_Walls_Corrugated_Metal_Panels);
            db.AddInParameter(dbCommand, "Ext_Walls_Tilt_up_Concrete", DbType.Boolean, this._Ext_Walls_Tilt_up_Concrete);
            db.AddInParameter(dbCommand, "Ext_Walls_Glass_and_Steel_Curtain", DbType.Boolean, this._Ext_Walls_Glass_and_Steel_Curtain);
            db.AddInParameter(dbCommand, "Ext_Walls_Wood_Frame", DbType.Boolean, this._Ext_Walls_Wood_Frame);
            db.AddInParameter(dbCommand, "Int_Walls_Masonry_With_Fire_Doors", DbType.Boolean, this._Int_Walls_Masonry_With_Fire_Doors);
            db.AddInParameter(dbCommand, "Int_Walls_Masonry_with_Openings", DbType.Boolean, this._Int_Walls_Masonry_with_Openings);
            db.AddInParameter(dbCommand, "Int_Walls_No_Interior_Walls", DbType.Boolean, this._Int_Walls_No_Interior_Walls);
            db.AddInParameter(dbCommand, "Int_Walls_Masonry", DbType.Boolean, this._Int_Walls_Masonry);
            db.AddInParameter(dbCommand, "Int_Walls_Gypsum_Board", DbType.Boolean, this._Int_Walls_Gypsum_Board);
            db.AddInParameter(dbCommand, "Int_wall_extend_above_roof", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Int_wall_extend_above_roof));
            db.AddInParameter(dbCommand, "Number_of_Paint_Booths", DbType.Int32, this._Number_of_Paint_Booths);
            db.AddInParameter(dbCommand, "Number_of_Lifts", DbType.Int32, this._Number_of_Lifts);
            db.AddInParameter(dbCommand, "Sales_New_Sprinklered", DbType.Double, this._Sales_New_Sprinklered);
            db.AddInParameter(dbCommand, "Sales_Used_Sprinklered", DbType.Double, this._Sales_Used_Sprinklered);
            db.AddInParameter(dbCommand, "Service_Sprinklered", DbType.Double, this._Service_Sprinklered);
            db.AddInParameter(dbCommand, "Body_Shop_Sprinklered", DbType.Double, this._Body_Shop_Sprinklered);
            db.AddInParameter(dbCommand, "Parts_Sprinklered", DbType.Double, this._Parts_Sprinklered);
            db.AddInParameter(dbCommand, "Office_Sprinklered", DbType.Double, this._Office_Sprinklered);
            db.AddInParameter(dbCommand, "Water_Public", DbType.Boolean, this._Water_Public);
            db.AddInParameter(dbCommand, "Water_Private", DbType.Boolean, this._Water_Private);
            db.AddInParameter(dbCommand, "Water_Boosted", DbType.Boolean, this._Water_Boosted);
            db.AddInParameter(dbCommand, "Design_Densities_for_each_area", DbType.String, this._Design_Densities_for_each_area);
            db.AddInParameter(dbCommand, "Hydrants_within_500_ft", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Hydrants_within_500_ft));
            db.AddInParameter(dbCommand, "Alarm_UL_Central_Station", DbType.Boolean, this._Alarm_UL_Central_Station);
            db.AddInParameter(dbCommand, "Alarm_Constant_Attended", DbType.Boolean, this._Alarm_Constant_Attended);
            db.AddInParameter(dbCommand, "Alarm_Sprinkler_Valve_Tamper", DbType.Boolean, this._Alarm_Sprinkler_Valve_Tamper);
            db.AddInParameter(dbCommand, "Alarm_Non_UL_Central_Station", DbType.Boolean, this._Alarm_Non_UL_Central_Station);
            db.AddInParameter(dbCommand, "Alarm_Local", DbType.Boolean, this._Alarm_Local);
            db.AddInParameter(dbCommand, "Alarm_Smoke_Detectors", DbType.Boolean, this._Alarm_Smoke_Detectors);
            db.AddInParameter(dbCommand, "Alarm_Proprietary", DbType.Boolean, this._Alarm_Proprietary);
            db.AddInParameter(dbCommand, "Alarm_Sprinkler_Waterflow", DbType.Boolean, this._Alarm_Sprinkler_Waterflow);
            db.AddInParameter(dbCommand, "Alarm_Dry_Pipe_Air", DbType.Boolean, this._Alarm_Dry_Pipe_Air);
            db.AddInParameter(dbCommand, "Alarm_Remote", DbType.Boolean, this._Alarm_Remote);
            db.AddInParameter(dbCommand, "Alarm_Fire_Pump_Alarms", DbType.Boolean, this._Alarm_Fire_Pump_Alarms);
            db.AddInParameter(dbCommand, "Alarm_Auto_Fire_Alarms", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Alarm_Auto_Fire_Alarms));
            db.AddInParameter(dbCommand, "Alarm_Security_Cameras", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Alarm_Security_Cameras));
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            db.AddInParameter(dbCommand, "Number_of_Bays", DbType.Int32, this._Number_of_Bays);

            db.AddInParameter(dbCommand, "Number_of_Lifts_SC", DbType.Int32, this._Number_of_Lifts_SC);

            db.AddInParameter(dbCommand, "Number_of_Prep_Areas", DbType.Int32, this._Number_of_Prep_Areas);

            db.AddInParameter(dbCommand, "Number_of_Car_Wash_Stations", DbType.Int32, this._Number_of_Car_Wash_Stations);

            if (string.IsNullOrEmpty(this._Fire_Contact_Name))
                db.AddInParameter(dbCommand, "Fire_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Contact_Name", DbType.String, this._Fire_Contact_Name);

            if (string.IsNullOrEmpty(this._Fire_Vendor_Name))
                db.AddInParameter(dbCommand, "Fire_Vendor_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Vendor_Name", DbType.String, this._Fire_Vendor_Name);

            db.AddInParameter(dbCommand, "Fire_Contact_Expiration_Date", DbType.DateTime, this._Fire_Contact_Expiration_Date);

            if (string.IsNullOrEmpty(this._Fire_Address_1))
                db.AddInParameter(dbCommand, "Fire_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Address_1", DbType.String, this._Fire_Address_1);

            if (string.IsNullOrEmpty(this._Fire_Address_2))
                db.AddInParameter(dbCommand, "Fire_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Address_2", DbType.String, this._Fire_Address_2);

            if (string.IsNullOrEmpty(this._Fire_City))
                db.AddInParameter(dbCommand, "Fire_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_City", DbType.String, this._Fire_City);

            if (string.IsNullOrEmpty(this._Fire_State))
                db.AddInParameter(dbCommand, "Fire_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_State", DbType.String, this._Fire_State);

            if (string.IsNullOrEmpty(this._Fire_Zip))
                db.AddInParameter(dbCommand, "Fire_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Zip", DbType.String, this._Fire_Zip);

            if (string.IsNullOrEmpty(this._Fire_Telephone_Number))
                db.AddInParameter(dbCommand, "Fire_Telephone_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Telephone_Number", DbType.String, this._Fire_Telephone_Number);

            if (string.IsNullOrEmpty(this._Fire_Alternate_Number))
                db.AddInParameter(dbCommand, "Fire_Alternate_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Alternate_Number", DbType.String, this._Fire_Alternate_Number);

            if (string.IsNullOrEmpty(this._Fire_Email))
                db.AddInParameter(dbCommand, "Fire_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Email", DbType.String, this._Fire_Email);

            if (string.IsNullOrEmpty(this._Fire_Comments))
                db.AddInParameter(dbCommand, "Fire_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Comments", DbType.String, this._Fire_Comments);

            if (string.IsNullOrEmpty(this._Location_Status))
                db.AddInParameter(dbCommand, "Location_Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location_Status", DbType.String, this._Location_Status);

            db.AddInParameter(dbCommand, "Liability", DbType.String, this._Liability);
            db.AddInParameter(dbCommand, "Number_Of_Parking_Spaces", DbType.Int32, this._Number_Of_Parking_Spaces);
            db.AddInParameter(dbCommand, "Acreage", DbType.Decimal, this._Acreage);
            db.AddInParameter(dbCommand, "Occupancy_Car_Wash", DbType.Boolean, this._Occupancy_Service);
            db.AddInParameter(dbCommand, "Occupancy_Photo_Booth", DbType.Boolean, this._Occupancy_Service);
            
            db.AddInParameter(dbCommand, "FK_LU_Voltage_Security", DbType.Decimal, this._FK_LU_Voltage_Security);
            db.AddInParameter(dbCommand, "FK_LU_Power_Service", DbType.Decimal, this._FK_LU_Power_Service);
            db.AddInParameter(dbCommand, "FK_LU_Cable_Length", DbType.Decimal, this._FK_LU_Cable_Length);
            db.AddInParameter(dbCommand, "FK_LU_Phase_Power", DbType.Decimal, this._FK_LU_Phase_Power);
            

            if (string.IsNullOrEmpty(this._Voltage_Security_Other))
                db.AddInParameter(dbCommand, "Voltage_Security_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Voltage_Security_Other", DbType.String, this._Voltage_Security_Other);

            if (string.IsNullOrEmpty(this._Power_Service_Other))
                db.AddInParameter(dbCommand, "Power_Service_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Power_Service_Other", DbType.String, this._Power_Service_Other);

            if (string.IsNullOrEmpty(this._Cable_Length_Other))
                db.AddInParameter(dbCommand, "Cable_Length_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cable_Length_Other", DbType.String, this._Cable_Length_Other);

            if (string.IsNullOrEmpty(this._Total_Amperage_Required))
                db.AddInParameter(dbCommand, "Total_Amperage_Required", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Total_Amperage_Required", DbType.String, this._Total_Amperage_Required);

            db.AddInParameter(dbCommand, "Occupancy_Main", DbType.Boolean, this._Occupancy_Main);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Building table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectByPK");

            db.AddInParameter(dbCommand, "PK_Building_ID", DbType.Int32, pK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Building table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Building table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllOwnership()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectBuildingOwnership");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Building table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllLocationStatus()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectBuildingLocationStatus");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Building table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingUpdate");

            db.AddInParameter(dbCommand, "PK_Building_ID", DbType.Int32, this._PK_Building_ID);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "SecuCam_System", DbType.String, this._SecuCam_System);
            db.AddInParameter(dbCommand, "SecuCam_Contact_Name", DbType.String, this._SecuCam_Contact_Name);
            db.AddInParameter(dbCommand, "SecuCam_Vendor_Name", DbType.String, this._SecuCam_Vendor_Name);

            if (this._SecuCam_Contact_Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "SecuCam_Contact_Expiration_Date", DbType.DateTime, this._SecuCam_Contact_Expiration_Date);
            else
                db.AddInParameter(dbCommand, "SecuCam_Contact_Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "SecuCam_Address_1", DbType.String, this._SecuCam_Address_1);
            db.AddInParameter(dbCommand, "SecuCam_Address_2", DbType.String, this._SecuCam_Address_2);
            db.AddInParameter(dbCommand, "SecuCam_City", DbType.String, this._SecuCam_City);
            db.AddInParameter(dbCommand, "SecuCam_State", DbType.String, this._SecuCam_State);
            db.AddInParameter(dbCommand, "SecuCam_Zip", DbType.String, this._SecuCam_Zip);
            db.AddInParameter(dbCommand, "SecuCam_Telephone_Number", DbType.String, this._SecuCam_Telephone_Number);
            db.AddInParameter(dbCommand, "SecuCam_Alternate_Number", DbType.String, this._SecuCam_Alternate_Number);
            db.AddInParameter(dbCommand, "SecuCam_Email", DbType.String, this._SecuCam_Email);
            db.AddInParameter(dbCommand, "SecuCam_Comments", DbType.String, this._SecuCam_Comments);
            db.AddInParameter(dbCommand, "Guard_System", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Guard_System));
            db.AddInParameter(dbCommand, "Guard_System_Name", DbType.String, this._Guard_System_Name);
            db.AddInParameter(dbCommand, "Guard_Contact_Name", DbType.String, this._Guard_Contact_Name);
            db.AddInParameter(dbCommand, "Guard_Vendor_Name", DbType.String, this._Guard_Vendor_Name);

            if (this._Guard_Contact_Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Guard_Contact_Expiration_Date", DbType.DateTime, this._Guard_Contact_Expiration_Date);
            else
                db.AddInParameter(dbCommand, "Guard_Contact_Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Guard_Address_1", DbType.String, this._Guard_Address_1);
            db.AddInParameter(dbCommand, "Guard_Address_2", DbType.String, this._Guard_Address_2);
            db.AddInParameter(dbCommand, "Guard_City", DbType.String, this._Guard_City);
            db.AddInParameter(dbCommand, "Guard_State", DbType.String, this._Guard_State);
            db.AddInParameter(dbCommand, "Guard_Zip", DbType.String, this._Guard_Zip);
            db.AddInParameter(dbCommand, "Guard_Telephone_Number", DbType.String, this._Guard_Telephone_Number);
            db.AddInParameter(dbCommand, "Guard_Alternate_Number", DbType.String, this._Guard_Alternate_Number);
            db.AddInParameter(dbCommand, "Guard_Email", DbType.String, this._Guard_Email);
            db.AddInParameter(dbCommand, "Guard_Comments", DbType.String, this._Guard_Comments);
            db.AddInParameter(dbCommand, "Intru_System", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Intru_System));
            db.AddInParameter(dbCommand, "Intru_System_Name", DbType.String, this._Intru_System_Name);
            db.AddInParameter(dbCommand, "Intru_Contact_Name", DbType.String, this._Intru_Contact_Name);
            db.AddInParameter(dbCommand, "Intru_Vendor_Name", DbType.String, this._Intru_Vendor_Name);

            if (this._Intru_Contact_Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Intru_Contact_Expiration_Date", DbType.DateTime, this._Intru_Contact_Expiration_Date);
            else
                db.AddInParameter(dbCommand, "Intru_Contact_Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Intru_Address_1", DbType.String, this._Intru_Address_1);
            db.AddInParameter(dbCommand, "Intru_Address_2", DbType.String, this._Intru_Address_2);
            db.AddInParameter(dbCommand, "Intru_City", DbType.String, this._Intru_City);
            db.AddInParameter(dbCommand, "Intru_State", DbType.String, this._Intru_State);
            db.AddInParameter(dbCommand, "Intru_Zip", DbType.String, this._Intru_Zip);
            db.AddInParameter(dbCommand, "Intru_Telephone_Number", DbType.String, this._Intru_Telephone_Number);
            db.AddInParameter(dbCommand, "Intru_Alternate_Number", DbType.String, this._Intru_Alternate_Number);
            db.AddInParameter(dbCommand, "Intru_Email", DbType.String, this._Intru_Email);
            db.AddInParameter(dbCommand, "Intru_Comments", DbType.String, this._Intru_Comments);
            db.AddInParameter(dbCommand, "Intru_Contact_Alarm_Type", DbType.String, this._Intru_Contact_Alarm_Type);
            db.AddInParameter(dbCommand, "Fence", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Fence));
            db.AddInParameter(dbCommand, "Fence_Razor_Wire", DbType.Boolean, this._Fence_Razor_Wire);
            db.AddInParameter(dbCommand, "Fence_Electrified", DbType.Boolean, this._Fence_Electrified);
            db.AddInParameter(dbCommand, "Generator", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Generator));
            db.AddInParameter(dbCommand, "Generator_Make", DbType.String, this._Generator_Make);
            db.AddInParameter(dbCommand, "Generator_Model", DbType.String, this._Generator_Model);
            db.AddInParameter(dbCommand, "Generator_Size", DbType.String, this._Generator_Size);
            db.AddInParameter(dbCommand, "Fire_Department_Type", DbType.String, this._Fire_Department_Type);
            db.AddInParameter(dbCommand, "Fire_Department_Distance", DbType.String, this._Fire_Department_Distance);
            db.AddInParameter(dbCommand, "Tier_1_County", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Tier_1_County));
            db.AddInParameter(dbCommand, "Earthquake_Zone_Fault_Line", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Earthquake_Zone_Fault_Line));
            db.AddInParameter(dbCommand, "Neighboring_Buildings_within_100_ft", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Neighboring_Buildings_within_100_ft));
            db.AddInParameter(dbCommand, "Neighbor_Occupancy", DbType.String, this._Neighbor_Occupancy);
            db.AddInParameter(dbCommand, "Distance_from_body_of_water", DbType.String, this._Distance_from_body_of_water);
            db.AddInParameter(dbCommand, "Prior_Flood_History", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Prior_Flood_History));
            db.AddInParameter(dbCommand, "Flood_History_Descr", DbType.String, this._Flood_History_Descr);
            db.AddInParameter(dbCommand, "Lowest_finish_floor_elevation", DbType.Int32, this._Lowest_finish_floor_elevation);
            db.AddInParameter(dbCommand, "Property_Damage_Losses_in_the_Past_5_years", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Property_Damage_Losses_in_the_Past_5_years));
            db.AddInParameter(dbCommand, "Property_Loss_Descr", DbType.String, this._Property_Loss_Descr);
            db.AddInParameter(dbCommand, "Flood_Zone", DbType.String, this._Flood_Zone);
            db.AddInParameter(dbCommand, "National_Flood_Policy", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._National_Flood_Policy));
            db.AddInParameter(dbCommand, "Flood_Carrier", DbType.String, this._Flood_Carrier);
            db.AddInParameter(dbCommand, "Flood_Policy_Number", DbType.String, this._Flood_Policy_Number);
            db.AddInParameter(dbCommand, "Flood_Premium", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Flood_Premium));
            db.AddInParameter(dbCommand, "Flood_Polciy_Limits_Contents", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Flood_Polciy_Limits_Contents));

            if (this._Flood_Policy_Inception_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Flood_Policy_Inception_Date", DbType.DateTime, this._Flood_Policy_Inception_Date);
            else
                db.AddInParameter(dbCommand, "Flood_Policy_Inception_Date", DbType.DateTime, DBNull.Value);

            if (this._Flood_Policy_Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Flood_Policy_Expiration_Date", DbType.DateTime, this._Flood_Policy_Expiration_Date);
            else
                db.AddInParameter(dbCommand, "Flood_Policy_Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Flood_Deductible", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Flood_Deductible));
            db.AddInParameter(dbCommand, "Flood_Policy_Limits_Building", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Flood_Policy_Limits_Building));
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Building_Number", DbType.String, this._Building_Number);
            db.AddInParameter(dbCommand, "Ownership", DbType.String, this._Ownership);
            db.AddInParameter(dbCommand, "Occupancy_Sales_New", DbType.Boolean, this._Occupancy_Sales_New);
            db.AddInParameter(dbCommand, "Occupancy_Body_Shop", DbType.Boolean, this._Occupancy_Body_Shop);
            db.AddInParameter(dbCommand, "Occupancy_Parking_Lot", DbType.Boolean, this._Occupancy_Parking_Lot);
            db.AddInParameter(dbCommand, "Occupancy_Sales_Used", DbType.Boolean, this._Occupancy_Sales_Used);
            db.AddInParameter(dbCommand, "Occupancy_Parts", DbType.Boolean, this._Occupancy_Parts);
            db.AddInParameter(dbCommand, "Occupancy_Raw_Land", DbType.Boolean, this._Occupancy_Raw_Land);
            db.AddInParameter(dbCommand, "Occupancy_Service", DbType.Boolean, this._Occupancy_Service);
            db.AddInParameter(dbCommand, "Occupancy_Ofifce", DbType.Boolean, this._Occupancy_Ofifce);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, this._City);
            db.AddInParameter(dbCommand, "State", DbType.String, this._State);
            db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
            db.AddInParameter(dbCommand, "Building_Limit", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Building_Limit));
            db.AddInParameter(dbCommand, "Leasehold_Interests_Limit_Betterment", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Leasehold_Interests_Limit_Betterment));

            if (this._Betterment_Date_Complete != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Betterment_Date_Complete", DbType.DateTime, this._Betterment_Date_Complete);
            else
                db.AddInParameter(dbCommand, "Betterment_Date_Complete", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Leasehold_Interests_Limit_Expansion", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Leasehold_Interests_Limit_Expansion));
            db.AddInParameter(dbCommand, "RS_Means_Building_Value", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._RS_Means_Building_Value));

            if (this._Expansion_Date_Complete != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Expansion_Date_Complete", DbType.DateTime, this._Expansion_Date_Complete);
            else
                db.AddInParameter(dbCommand, "Expansion_Date_Complete", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Associate_Tools_Limit", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Associate_Tools_Limit));
            db.AddInParameter(dbCommand, "Contents_Limit", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Contents_Limit));
            db.AddInParameter(dbCommand, "Parts_Limit", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Parts_Limit));
            db.AddInParameter(dbCommand, "Inventory_Levels", DbType.Decimal, clsGeneral.FormatDecimalToStoreInDB(this._Inventory_Levels));
            db.AddInParameter(dbCommand, "Year_Built", DbType.String, this._Year_Built);
            db.AddInParameter(dbCommand, "Square_Footage", DbType.String, this._Square_Footage);
            db.AddInParameter(dbCommand, "Number_of_Stories", DbType.Double, this._Number_of_Stories);
            db.AddInParameter(dbCommand, "Roof_Reinforced_Concrete", DbType.Boolean, this._Roof_Reinforced_Concrete);
            db.AddInParameter(dbCommand, "Roof_Concrete_Panels", DbType.Boolean, this._Roof_Concrete_Panels);
            db.AddInParameter(dbCommand, "Roof_Steel_Deck_with_Fasteners", DbType.Boolean, this._Roof_Steel_Deck_with_Fasteners);
            db.AddInParameter(dbCommand, "Roof_Poured_Concrete", DbType.Boolean, this._Roof_Poured_Concrete);
            db.AddInParameter(dbCommand, "Roof_Steel_Deck", DbType.Boolean, this._Roof_Steel_Deck);
            db.AddInParameter(dbCommand, "Roof_Wood_Joists", DbType.Boolean, this._Roof_Wood_Joists);
            db.AddInParameter(dbCommand, "Floors_Reinforced_Concrete", DbType.Boolean, this._Floors_Reinforced_Concrete);
            db.AddInParameter(dbCommand, "Floors_Poured_Concrete", DbType.Boolean, this._Floors_Poured_Concrete);
            db.AddInParameter(dbCommand, "Floors_Wood_Timber", DbType.Boolean, this._Floors_Wood_Timber);
            db.AddInParameter(dbCommand, "Ext_Walls_Reinforced_Concrete", DbType.Boolean, this._Ext_Walls_Reinforced_Concrete);
            db.AddInParameter(dbCommand, "Ext_Walls_Masonry", DbType.Boolean, this._Ext_Walls_Masonry);
            db.AddInParameter(dbCommand, "Ext_Walls_Corrugated_Metal_Panels", DbType.Boolean, this._Ext_Walls_Corrugated_Metal_Panels);
            db.AddInParameter(dbCommand, "Ext_Walls_Tilt_up_Concrete", DbType.Boolean, this._Ext_Walls_Tilt_up_Concrete);
            db.AddInParameter(dbCommand, "Ext_Walls_Glass_and_Steel_Curtain", DbType.Boolean, this._Ext_Walls_Glass_and_Steel_Curtain);
            db.AddInParameter(dbCommand, "Ext_Walls_Wood_Frame", DbType.Boolean, this._Ext_Walls_Wood_Frame);
            db.AddInParameter(dbCommand, "Int_Walls_Masonry_With_Fire_Doors", DbType.Boolean, this._Int_Walls_Masonry_With_Fire_Doors);
            db.AddInParameter(dbCommand, "Int_Walls_Masonry_with_Openings", DbType.Boolean, this._Int_Walls_Masonry_with_Openings);
            db.AddInParameter(dbCommand, "Int_Walls_No_Interior_Walls", DbType.Boolean, this._Int_Walls_No_Interior_Walls);
            db.AddInParameter(dbCommand, "Int_Walls_Masonry", DbType.Boolean, this._Int_Walls_Masonry);
            db.AddInParameter(dbCommand, "Int_Walls_Gypsum_Board", DbType.Boolean, this._Int_Walls_Gypsum_Board);
            db.AddInParameter(dbCommand, "Int_wall_extend_above_roof", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Int_wall_extend_above_roof));
            db.AddInParameter(dbCommand, "Number_of_Paint_Booths", DbType.Int32, this._Number_of_Paint_Booths);
            db.AddInParameter(dbCommand, "Number_of_Lifts", DbType.Int32, this._Number_of_Lifts);
            db.AddInParameter(dbCommand, "Sales_New_Sprinklered", DbType.Double, this._Sales_New_Sprinklered);
            db.AddInParameter(dbCommand, "Sales_Used_Sprinklered", DbType.Double, this._Sales_Used_Sprinklered);
            db.AddInParameter(dbCommand, "Service_Sprinklered", DbType.Double, this._Service_Sprinklered);
            db.AddInParameter(dbCommand, "Body_Shop_Sprinklered", DbType.Double, this._Body_Shop_Sprinklered);
            db.AddInParameter(dbCommand, "Parts_Sprinklered", DbType.Double, this._Parts_Sprinklered);
            db.AddInParameter(dbCommand, "Office_Sprinklered", DbType.Double, this._Office_Sprinklered);
            db.AddInParameter(dbCommand, "Water_Public", DbType.Boolean, this._Water_Public);
            db.AddInParameter(dbCommand, "Water_Private", DbType.Boolean, this._Water_Private);
            db.AddInParameter(dbCommand, "Water_Boosted", DbType.Boolean, this._Water_Boosted);
            db.AddInParameter(dbCommand, "Design_Densities_for_each_area", DbType.String, this._Design_Densities_for_each_area);
            db.AddInParameter(dbCommand, "Hydrants_within_500_ft", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Hydrants_within_500_ft));
            db.AddInParameter(dbCommand, "Alarm_UL_Central_Station", DbType.Boolean, this._Alarm_UL_Central_Station);
            db.AddInParameter(dbCommand, "Alarm_Constant_Attended", DbType.Boolean, this._Alarm_Constant_Attended);
            db.AddInParameter(dbCommand, "Alarm_Sprinkler_Valve_Tamper", DbType.Boolean, this._Alarm_Sprinkler_Valve_Tamper);
            db.AddInParameter(dbCommand, "Alarm_Non_UL_Central_Station", DbType.Boolean, this._Alarm_Non_UL_Central_Station);
            db.AddInParameter(dbCommand, "Alarm_Local", DbType.Boolean, this._Alarm_Local);
            db.AddInParameter(dbCommand, "Alarm_Smoke_Detectors", DbType.Boolean, this._Alarm_Smoke_Detectors);
            db.AddInParameter(dbCommand, "Alarm_Proprietary", DbType.Boolean, this._Alarm_Proprietary);
            db.AddInParameter(dbCommand, "Alarm_Sprinkler_Waterflow", DbType.Boolean, this._Alarm_Sprinkler_Waterflow);
            db.AddInParameter(dbCommand, "Alarm_Dry_Pipe_Air", DbType.Boolean, this._Alarm_Dry_Pipe_Air);
            db.AddInParameter(dbCommand, "Alarm_Remote", DbType.Boolean, this._Alarm_Remote);
            db.AddInParameter(dbCommand, "Alarm_Fire_Pump_Alarms", DbType.Boolean, this._Alarm_Fire_Pump_Alarms);
            db.AddInParameter(dbCommand, "Alarm_Auto_Fire_Alarms", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Alarm_Auto_Fire_Alarms));
            db.AddInParameter(dbCommand, "Alarm_Security_Cameras", DbType.Boolean, clsGeneral.FormatYesNoToStoreInDB(this._Alarm_Security_Cameras));
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            db.AddInParameter(dbCommand, "Number_of_Bays", DbType.Int32, this._Number_of_Bays);

            db.AddInParameter(dbCommand, "Number_of_Lifts_SC", DbType.Int32, this._Number_of_Lifts_SC);

            db.AddInParameter(dbCommand, "Number_of_Prep_Areas", DbType.Int32, this._Number_of_Prep_Areas);

            db.AddInParameter(dbCommand, "Number_of_Car_Wash_Stations", DbType.Int32, this._Number_of_Car_Wash_Stations);

            if (string.IsNullOrEmpty(this._Fire_Contact_Name))
                db.AddInParameter(dbCommand, "Fire_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Contact_Name", DbType.String, this._Fire_Contact_Name);

            if (string.IsNullOrEmpty(this._Fire_Vendor_Name))
                db.AddInParameter(dbCommand, "Fire_Vendor_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Vendor_Name", DbType.String, this._Fire_Vendor_Name);

            db.AddInParameter(dbCommand, "Fire_Contact_Expiration_Date", DbType.DateTime, this._Fire_Contact_Expiration_Date);

            if (string.IsNullOrEmpty(this._Fire_Address_1))
                db.AddInParameter(dbCommand, "Fire_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Address_1", DbType.String, this._Fire_Address_1);

            if (string.IsNullOrEmpty(this._Fire_Address_2))
                db.AddInParameter(dbCommand, "Fire_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Address_2", DbType.String, this._Fire_Address_2);

            if (string.IsNullOrEmpty(this._Fire_City))
                db.AddInParameter(dbCommand, "Fire_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_City", DbType.String, this._Fire_City);

            if (string.IsNullOrEmpty(this._Fire_State))
                db.AddInParameter(dbCommand, "Fire_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_State", DbType.String, this._Fire_State);

            if (string.IsNullOrEmpty(this._Fire_Zip))
                db.AddInParameter(dbCommand, "Fire_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Zip", DbType.String, this._Fire_Zip);

            if (string.IsNullOrEmpty(this._Fire_Telephone_Number))
                db.AddInParameter(dbCommand, "Fire_Telephone_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Telephone_Number", DbType.String, this._Fire_Telephone_Number);

            if (string.IsNullOrEmpty(this._Fire_Alternate_Number))
                db.AddInParameter(dbCommand, "Fire_Alternate_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Alternate_Number", DbType.String, this._Fire_Alternate_Number);

            if (string.IsNullOrEmpty(this._Fire_Email))
                db.AddInParameter(dbCommand, "Fire_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Email", DbType.String, this._Fire_Email);

            if (string.IsNullOrEmpty(this._Fire_Comments))
                db.AddInParameter(dbCommand, "Fire_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fire_Comments", DbType.String, this._Fire_Comments);

            if (string.IsNullOrEmpty(this._Location_Status))
                db.AddInParameter(dbCommand, "Location_Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location_Status", DbType.String, this._Location_Status);

            db.AddInParameter(dbCommand, "Liability", DbType.String, this._Liability);
            db.AddInParameter(dbCommand, "Number_Of_Parking_Spaces", DbType.Int32, this._Number_Of_Parking_Spaces);
            db.AddInParameter(dbCommand, "Acreage", DbType.Decimal, this._Acreage);
            db.AddInParameter(dbCommand, "Occupancy_Car_Wash", DbType.Decimal, this._Occupancy_Car_Wash);
            db.AddInParameter(dbCommand, "Occupancy_Photo_Booth", DbType.Decimal, this._Occupancy_Photo_Booth);
            
            db.AddInParameter(dbCommand, "FK_LU_Voltage_Security", DbType.Decimal, this._FK_LU_Voltage_Security);
            db.AddInParameter(dbCommand, "FK_LU_Power_Service", DbType.Decimal, this._FK_LU_Power_Service);
            db.AddInParameter(dbCommand, "FK_LU_Phase_Power", DbType.Decimal, this._FK_LU_Phase_Power);
            db.AddInParameter(dbCommand, "FK_LU_Cable_Length", DbType.Decimal, this._FK_LU_Cable_Length);

            if (string.IsNullOrEmpty(this._Voltage_Security_Other))
                db.AddInParameter(dbCommand, "Voltage_Security_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Voltage_Security_Other", DbType.String, this._Voltage_Security_Other);

            if (string.IsNullOrEmpty(this._Power_Service_Other))
                db.AddInParameter(dbCommand, "Power_Service_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Power_Service_Other", DbType.String, this._Power_Service_Other);

            if (string.IsNullOrEmpty(this._Cable_Length_Other))
                db.AddInParameter(dbCommand, "Cable_Length_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cable_Length_Other", DbType.String, this._Cable_Length_Other);

            if (string.IsNullOrEmpty(this._Total_Amperage_Required))
                db.AddInParameter(dbCommand, "Total_Amperage_Required", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Total_Amperage_Required", DbType.String, this._Total_Amperage_Required);

            db.AddInParameter(dbCommand, "Occupancy_Main", DbType.Boolean, this._Occupancy_Main);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Building table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Building_ID", DbType.Int32, pK_Building_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFKLocation(int fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectByFKLocation");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFKEvent(decimal fK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectByFKEvent");

            db.AddInParameter(dbCommand, "PK_Event", DbType.Decimal, fK_Event);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByACILocation(decimal PK_ACI_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectByACI_LU_Location");

            db.AddInParameter(dbCommand, "PK_ACI_LU_Location", DbType.Decimal, PK_ACI_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }


        public static DataSet BuildingByFKLocation(int fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectByFK");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectFinancialLimitsByLocation(int fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectFinancialLimitsByLocation");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectBuildingOwnerships(int fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Leases_SelectBuildingOwnerships");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByPaging(int fK_LU_Location_ID, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_SelectByPaging");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        public static void BuildingInsuranceCOPEInsertUpdate(string strXml, int FK_Building, string Updated_By)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingInsuranceCOPE_InsertUpdate");

            db.AddInParameter(dbCommand, "strXml", DbType.String, strXml);
            db.AddInParameter(dbCommand, "FK_Building", DbType.Int32, FK_Building);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, Updated_By);
            db.ExecuteNonQuery(dbCommand);            
        }

        public static DataSet BuildingInsuranceCOPESelect(int FK_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingInsuranceCOPESelect");
                        
            db.AddInParameter(dbCommand, "FK_Building", DbType.Int32, FK_Building);            
            return db.ExecuteDataSet(dbCommand);            
        }

        /// <summary>
        /// Selects Building For Building Improvements by Location ID
        /// </summary>
        /// <param name="fK_LU_Location_ID"></param>
        /// <returns></returns>
        public static DataSet SelectBuildingForBuildingImprovements(int fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectBuildingForBuildingImprovements");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects Building By Project Id
        /// </summary>
        /// <param name="fK_Facility_Construction_Project"></param>
        /// <returns></returns>
        public static DataSet SelectBuildingByProjectNumber(Int32 fK_Facility_Construction_Project)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectByProjectNumberForDropDown");
            db.AddInParameter(dbCommand, "FK_Facility_Construction_PM", DbType.Int32, fK_Facility_Construction_Project);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects Building For Facility Inspection By Location ID and PK_Facility_Construction_Inspection
        /// </summary>
        /// <param name="fK_LU_Location_ID"></param>
        /// <param name="pK_Facility_Construction_Inspection"></param>
        /// <returns></returns>
        public static DataSet SelectBuildingForFacilityInspection(Int32 fK_LU_Location_ID, Int32 pK_Facility_Construction_Inspection)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectBuildingForFacilityInspection");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);
            db.AddInParameter(dbCommand, "PK_Facility_Construction_Inspection", DbType.Int32, pK_Facility_Construction_Inspection);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Building table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPKLookUp(int pK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectByPKLookUp");

            db.AddInParameter(dbCommand, "PK_Building_ID", DbType.Int32, pK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByPagingBuildingNumber(int fK_LU_Location_ID, string Building_Number, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_SelectByPagingBuildingNumber");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Building_Number", DbType.String, Building_Number);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a  record from the Building table by Loction ID and Occupancy main.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFKLocationOccupancyMain(int fK_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectByFKLocationOccupancyMain");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectOccupancyByFKLocation(decimal fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BindBuildingByFK_LU_Location");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFKLocationAP(int fK_LU_Location_ID, string Building_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingAPSelectByFKLocation");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Building_Number", DbType.String, Building_Number);

            return db.ExecuteDataSet(dbCommand);
        }

        public int BuildingByFKLocationInsertUpdate(int PK_AP_Property_Security, string FK_Building_IdFrom, string FK_Building_IdTo, string UpdatedBy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingByFKLocationInsertUpdate");

            db.AddInParameter(dbCommand, "PK_AP_Property_Security", DbType.Int32, PK_AP_Property_Security);            
            db.AddInParameter(dbCommand, "FK_Building_IdFrom", DbType.String, FK_Building_IdFrom);
            db.AddInParameter(dbCommand, "FK_Building_IdTo", DbType.String, FK_Building_IdTo);
            db.AddInParameter(dbCommand, "UserId", DbType.String, UpdatedBy);
        

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
        #endregion
    }
}
