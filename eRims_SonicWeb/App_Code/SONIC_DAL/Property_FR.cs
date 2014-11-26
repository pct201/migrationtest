using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Property_FR table.
    /// </summary>
    public sealed class Property_FR
    {
        #region Fields


        private decimal _PK_Property_FR_ID;
        private decimal _Property_FR_Number;
        private decimal _FK_Location_Code;
        private decimal _FK_Contact;
        private DateTime _Date_Reported_to_Sonic;
        private bool _Fire;
        private bool _Wind_Damage;
        private bool _Hail_Damage;
        private bool _Earth_Movement;
        private bool _Flood;
        private bool _Third_Party_Property_Damage;
        private bool _Property_Damage_by_Sonic_Associate;
        private bool _Environmental_Loss;
        private bool _Vandalism_To_The_Property;
        private bool _Theft_Associate_Tools;
        private bool _Theft_All_Other;
        private bool _Other;
        private DateTime _Date_Of_Loss;
        private string _Time_Of_Loss;
        private string _Description_of_Loss;
        private decimal _Damage_Building_Facilities_Est_Cost;
        private decimal _Damage_Building_Facilities_Actual_Cost;
        private decimal _Damage_Equipment_Est_Cost;
        private decimal _Damage_Equipment_Actual_Cost;
        private decimal _Damage_Product_Damage_Est_Cost;
        private decimal _Damage_Product_Damage_Actual_Cost;
        private decimal _Damage_Parts_Est_Cost;
        private decimal _Damage_Parts_Actual_Cost;
        private decimal _Damage_Salvage_Cleanup_Est_Cost;
        private decimal _Damage_Salvage_Cleanup_Actual_Cost;
        private decimal _Damage_Decontamination_Est_Cost;
        private decimal _Damage_Decontamination_Actual_Cost;
        private decimal _Damage_Electronic_Data_Est_Cost;
        private decimal _Damage_Electronic_Data_Actual_Cost;
        private decimal _Damage_Service_Interruption_Est_Cost;
        private decimal _Damage_Service_Interruption_Actual_Cost;
        private decimal _Damage_Payroll_Est_Cost;
        private decimal _Damage_Payroll_Actual_Cost;
        private decimal _Damage_Loss_of_Sales_Est_Cost;
        private decimal _Damage_Loss_of_Sales_Actual_Cost;
        private DateTime _Date_Cleanup_Complete;
        private DateTime _Date_Repairs_Complete;
        private DateTime _Date_Full_Service_Resumed;
        private DateTime _Date_Fire_Protection_Services_Resumed;
        private string _Comments;
        private string _Date_Report_Complete;
        private string _Date_Claim_Closed;
        private bool _Complete;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        private decimal _FK_SLT_Incident_Review;
        private Nullable<bool> _Security_Video_Surveillance;
        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Property_FR_ID value.
        /// </summary>
        public decimal PK_Property_FR_ID
        {
            get { return _PK_Property_FR_ID; }
            set { _PK_Property_FR_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_FR_Number value.
        /// </summary>
        public decimal Property_FR_Number
        {
            get { return _Property_FR_Number; }
            set { _Property_FR_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Location_Code value.
        /// </summary>
        public decimal FK_Location_Code
        {
            get { return _FK_Location_Code; }
            set { _FK_Location_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Contact value.
        /// </summary>
        public decimal FK_Contact
        {
            get { return _FK_Contact; }
            set { _FK_Contact = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Reported_to_Sonic value.
        /// </summary>
        public DateTime Date_Reported_to_Sonic
        {
            get { return _Date_Reported_to_Sonic; }
            set { _Date_Reported_to_Sonic = value; }
        }


        /// <summary> 
        /// Gets or sets the Fire value.
        /// </summary>
        public bool Fire
        {
            get { return _Fire; }
            set { _Fire = value; }
        }


        /// <summary> 
        /// Gets or sets the Wind_Damage value.
        /// </summary>
        public bool Wind_Damage
        {
            get { return _Wind_Damage; }
            set { _Wind_Damage = value; }
        }


        /// <summary> 
        /// Gets or sets the Hail_Damage value.
        /// </summary>
        public bool Hail_Damage
        {
            get { return _Hail_Damage; }
            set { _Hail_Damage = value; }
        }


        /// <summary> 
        /// Gets or sets the Earth_Movement value.
        /// </summary>
        public bool Earth_Movement
        {
            get { return _Earth_Movement; }
            set { _Earth_Movement = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood value.
        /// </summary>
        public bool Flood
        {
            get { return _Flood; }
            set { _Flood = value; }
        }


        /// <summary> 
        /// Gets or sets the Third_Party_Property_Damage value.
        /// </summary>
        public bool Third_Party_Property_Damage
        {
            get { return _Third_Party_Property_Damage; }
            set { _Third_Party_Property_Damage = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Damage_by_Sonic_Associate value.
        /// </summary>
        public bool Property_Damage_by_Sonic_Associate
        {
            get { return _Property_Damage_by_Sonic_Associate; }
            set { _Property_Damage_by_Sonic_Associate = value; }
        }


        /// <summary> 
        /// Gets or sets the Environmental_Loss value.
        /// </summary>
        public bool Environmental_Loss
        {
            get { return _Environmental_Loss; }
            set { _Environmental_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Vandalism_To_The_Property value.
        /// </summary>
        public bool Vandalism_To_The_Property
        {
            get { return _Vandalism_To_The_Property; }
            set { _Vandalism_To_The_Property = value; }
        }


        /// <summary> 
        /// Gets or sets the Theft_Associate_Tools value.
        /// </summary>
        public bool Theft_Associate_Tools
        {
            get { return _Theft_Associate_Tools; }
            set { _Theft_Associate_Tools = value; }
        }


        /// <summary> 
        /// Gets or sets the Theft_All_Other value.
        /// </summary>
        public bool Theft_All_Other
        {
            get { return _Theft_All_Other; }
            set { _Theft_All_Other = value; }
        }


        /// <summary> 
        /// Gets or sets the Other value.
        /// </summary>
        public bool Other
        {
            get { return _Other; }
            set { _Other = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Of_Loss value.
        /// </summary>
        public DateTime Date_Of_Loss
        {
            get { return _Date_Of_Loss; }
            set { _Date_Of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Time_Of_Loss value.
        /// </summary>
        public string Time_Of_Loss
        {
            get { return _Time_Of_Loss; }
            set { _Time_Of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Description_of_Loss value.
        /// </summary>
        public string Description_of_Loss
        {
            get { return _Description_of_Loss; }
            set { _Description_of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Building_Facilities_Est_Cost value.
        /// </summary>
        public decimal Damage_Building_Facilities_Est_Cost
        {
            get { return _Damage_Building_Facilities_Est_Cost; }
            set { _Damage_Building_Facilities_Est_Cost = value; }
        }
        /// <summary> 
        /// Gets or sets the Damage_Building_Facilities_Actual_Cost value.
        /// </summary>
        public decimal Damage_Building_Facilities_Actual_Cost
        {
            get { return _Damage_Building_Facilities_Actual_Cost; }
            set { _Damage_Building_Facilities_Actual_Cost = value; }
        }
        /// <summary> 
        /// Gets or sets the Damage_Equipment_Est_Cost value.
        /// </summary>
        public decimal Damage_Equipment_Est_Cost
        {
            get { return _Damage_Equipment_Est_Cost; }
            set { _Damage_Equipment_Est_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Equipment_Actual_Cost value.
        /// </summary>
        public decimal Damage_Equipment_Actual_Cost
        {
            get { return _Damage_Equipment_Actual_Cost; }
            set { _Damage_Equipment_Actual_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Product_Damage_Est_Cost value.
        /// </summary>
        public decimal Damage_Product_Damage_Est_Cost
        {
            get { return _Damage_Product_Damage_Est_Cost; }
            set { _Damage_Product_Damage_Est_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Product_Damage_Actual_Cost value.
        /// </summary>
        public decimal Damage_Product_Damage_Actual_Cost
        {
            get { return _Damage_Product_Damage_Actual_Cost; }
            set { _Damage_Product_Damage_Actual_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Parts_Est_Cost value.
        /// </summary>
        public decimal Damage_Parts_Est_Cost
        {
            get { return _Damage_Parts_Est_Cost; }
            set { _Damage_Parts_Est_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Parts_Actual_Cost value.
        /// </summary>
        public decimal Damage_Parts_Actual_Cost
        {
            get { return _Damage_Parts_Actual_Cost; }
            set { _Damage_Parts_Actual_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Salvage_Cleanup_Est_Cost value.
        /// </summary>
        public decimal Damage_Salvage_Cleanup_Est_Cost
        {
            get { return _Damage_Salvage_Cleanup_Est_Cost; }
            set { _Damage_Salvage_Cleanup_Est_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Salvage_Cleanup_Actual_Cost value.
        /// </summary>
        public decimal Damage_Salvage_Cleanup_Actual_Cost
        {
            get { return _Damage_Salvage_Cleanup_Actual_Cost; }
            set { _Damage_Salvage_Cleanup_Actual_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Decontamination_Est_Cost value.
        /// </summary>
        public decimal Damage_Decontamination_Est_Cost
        {
            get { return _Damage_Decontamination_Est_Cost; }
            set { _Damage_Decontamination_Est_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Decontamination_Actual_Cost value.
        /// </summary>
        public decimal Damage_Decontamination_Actual_Cost
        {
            get { return _Damage_Decontamination_Actual_Cost; }
            set { _Damage_Decontamination_Actual_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Electronic_Data_Est_Cost value.
        /// </summary>
        public decimal Damage_Electronic_Data_Est_Cost
        {
            get { return _Damage_Electronic_Data_Est_Cost; }
            set { _Damage_Electronic_Data_Est_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Electronic_Data_Actual_Cost value.
        /// </summary>
        public decimal Damage_Electronic_Data_Actual_Cost
        {
            get { return _Damage_Electronic_Data_Actual_Cost; }
            set { _Damage_Electronic_Data_Actual_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Service_Interruption_Est_Cost value.
        /// </summary>
        public decimal Damage_Service_Interruption_Est_Cost
        {
            get { return _Damage_Service_Interruption_Est_Cost; }
            set { _Damage_Service_Interruption_Est_Cost = value; }
        }
        /// <summary> 
        /// Gets or sets the Damage_Service_Interruption_Actual_Cost value.
        /// </summary>
        public decimal Damage_Service_Interruption_Actual_Cost
        {
            get { return _Damage_Service_Interruption_Actual_Cost; }
            set { _Damage_Service_Interruption_Actual_Cost = value; }
        }
        /// <summary> 
        /// Gets or sets the Damage_Payroll_Est_Cost value.
        /// </summary>
        public decimal Damage_Payroll_Est_Cost
        {
            get { return _Damage_Payroll_Est_Cost; }
            set { _Damage_Payroll_Est_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Payroll_Actual_Cost value.
        /// </summary>
        public decimal Damage_Payroll_Actual_Cost
        {
            get { return _Damage_Payroll_Actual_Cost; }
            set { _Damage_Payroll_Actual_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Loss_of_Sales_Est_Cost value.
        /// </summary>
        public decimal Damage_Loss_of_Sales_Est_Cost
        {
            get { return _Damage_Loss_of_Sales_Est_Cost; }
            set { _Damage_Loss_of_Sales_Est_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Loss_of_Sales_Actual_Cost value.
        /// </summary>
        public decimal Damage_Loss_of_Sales_Actual_Cost
        {
            get { return _Damage_Loss_of_Sales_Actual_Cost; }
            set { _Damage_Loss_of_Sales_Actual_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Cleanup_Complete value.
        /// </summary>
        public DateTime Date_Cleanup_Complete
        {
            get { return _Date_Cleanup_Complete; }
            set { _Date_Cleanup_Complete = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Repairs_Complete value.
        /// </summary>
        public DateTime Date_Repairs_Complete
        {
            get { return _Date_Repairs_Complete; }
            set { _Date_Repairs_Complete = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Full_Service_Resumed value.
        /// </summary>
        public DateTime Date_Full_Service_Resumed
        {
            get { return _Date_Full_Service_Resumed; }
            set { _Date_Full_Service_Resumed = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Fire_Protection_Services_Resumed value.
        /// </summary>
        public DateTime Date_Fire_Protection_Services_Resumed
        {
            get { return _Date_Fire_Protection_Services_Resumed; }
            set { _Date_Fire_Protection_Services_Resumed = value; }
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
        /// Gets or sets the Date_Report_Complete value.
        /// </summary>
        public string Date_Report_Complete
        {
            get { return _Date_Report_Complete; }
            set { _Date_Report_Complete = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Claim_Closed value.
        /// </summary>
        public string Date_Claim_Closed
        {
            get { return _Date_Claim_Closed; }
            set { _Date_Claim_Closed = value; }
        }


        /// <summary> 
        /// Gets or sets the Complete value.
        /// </summary>
        public bool Complete
        {
            get { return _Complete; }
            set { _Complete = value; }
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

        ///<summary>
        ///get or sets FK_SLT_Incident_Review value
        /// </summary>
        public decimal FK_SLT_Incident_Review
        {
            get { return _FK_SLT_Incident_Review; }
            set { _FK_SLT_Incident_Review = value; }
        }

        /// <summary> 
        /// Gets or sets the Security_Video_Surveillance value.
        /// </summary>
        public Nullable<bool> Security_Video_Surveillance
        {
            get { return _Security_Video_Surveillance; }
            set { _Security_Video_Surveillance = value; }
        }
        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Property_FR class. with the default value.
        /// </summary>
        public Property_FR()
        {

            this._PK_Property_FR_ID = -1;
            this._Property_FR_Number = -1;
            this._FK_Location_Code = -1;
            this._FK_Contact = -1;
            this._Date_Reported_to_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Fire = false;
            this._Wind_Damage = false;
            this._Hail_Damage = false;
            this._Earth_Movement = false;
            this._Flood = false;
            this._Third_Party_Property_Damage = false;
            this._Property_Damage_by_Sonic_Associate = false;
            this._Environmental_Loss = false;
            this._Vandalism_To_The_Property = false;
            this._Theft_Associate_Tools = false;
            this._Theft_All_Other = false;
            this._Other = false;
            this._Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Time_Of_Loss = "";
            this._Description_of_Loss = "";
            this._Damage_Building_Facilities_Est_Cost = -1;
            this._Damage_Building_Facilities_Actual_Cost = -1;
            this._Damage_Equipment_Est_Cost = -1;
            this._Damage_Equipment_Actual_Cost = -1;
            this._Damage_Product_Damage_Est_Cost = -1;
            this._Damage_Product_Damage_Actual_Cost = -1;
            this._Damage_Parts_Est_Cost = -1;
            this._Damage_Parts_Actual_Cost = -1;
            this._Damage_Salvage_Cleanup_Est_Cost = -1;
            this._Damage_Salvage_Cleanup_Actual_Cost = -1;
            this._Damage_Decontamination_Est_Cost = -1;
            this._Damage_Decontamination_Actual_Cost = -1;
            this._Damage_Electronic_Data_Est_Cost = -1;
            this._Damage_Electronic_Data_Actual_Cost = -1;
            this._Damage_Service_Interruption_Est_Cost = -1;
            this._Damage_Service_Interruption_Actual_Cost = -1;
            this._Damage_Payroll_Est_Cost = -1;
            this._Damage_Payroll_Actual_Cost = -1;
            this._Damage_Loss_of_Sales_Est_Cost = -1;
            this._Damage_Loss_of_Sales_Actual_Cost = -1;
            this._Date_Cleanup_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Repairs_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Full_Service_Resumed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Fire_Protection_Services_Resumed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Comments = "";
            this._Date_Report_Complete = "";
            this._Date_Claim_Closed = "";
            this._Complete = false;
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._FK_SLT_Incident_Review = -1;
            this._Security_Video_Surveillance = null;
        }



        /// <summary> 
        /// Initializes a new instance of the Property_FR class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Property_FR(decimal PK)
        {

            DataTable dtProperty_FR = SelectByPK(PK).Tables[0];

            if (dtProperty_FR.Rows.Count > 0)
            {

                DataRow drProperty_FR = dtProperty_FR.Rows[0];

                this._PK_Property_FR_ID = drProperty_FR["PK_Property_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["PK_Property_FR_ID"]) : 0;
                this._Property_FR_Number = drProperty_FR["Property_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Property_FR_Number"]) : 0;
                this._FK_Location_Code = drProperty_FR["FK_Location_Code"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["FK_Location_Code"]) : 0;
                this._FK_Contact = drProperty_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["FK_Contact"]) : 0;
                this._Date_Reported_to_Sonic = drProperty_FR["Date_Reported_to_Sonic"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Reported_to_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Fire = drProperty_FR["Fire"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Fire"]) : false;
                this._Wind_Damage = drProperty_FR["Wind_Damage"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Wind_Damage"]) : false;
                this._Hail_Damage = drProperty_FR["Hail_Damage"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Hail_Damage"]) : false;
                this._Earth_Movement = drProperty_FR["Earth_Movement"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Earth_Movement"]) : false;
                this._Flood = drProperty_FR["Flood"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Flood"]) : false;
                this._Third_Party_Property_Damage = drProperty_FR["Third_Party_Property_Damage"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Third_Party_Property_Damage"]) : false;
                this._Property_Damage_by_Sonic_Associate = drProperty_FR["Property_Damage_by_Sonic_Associate"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Property_Damage_by_Sonic_Associate"]) : false;
                this._Environmental_Loss = drProperty_FR["Environmental_Loss"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Environmental_Loss"]) : false;
                this._Vandalism_To_The_Property = drProperty_FR["Vandalism_To_The_Property"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Vandalism_To_The_Property"]) : false;
                this._Theft_Associate_Tools = drProperty_FR["Theft_Associate_Tools"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Theft_Associate_Tools"]) : false;
                this._Theft_All_Other = drProperty_FR["Theft_All_Other"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Theft_All_Other"]) : false;
                this._Other = drProperty_FR["Other"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Other"]) : false;
                this._Date_Of_Loss = drProperty_FR["Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_Of_Loss = Convert.ToString(drProperty_FR["Time_Of_Loss"]);
                this._Description_of_Loss = Convert.ToString(drProperty_FR["Description_of_Loss"]);
                this._Damage_Building_Facilities_Est_Cost = drProperty_FR["Damage_Building_Facilities_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Building_Facilities_Est_Cost"]) : 0;
                this._Damage_Building_Facilities_Actual_Cost = drProperty_FR["Damage_Building_Facilities_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Building_Facilities_Actual_Cost"]) : 0;
                this._Damage_Equipment_Est_Cost = drProperty_FR["Damage_Equipment_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Equipment_Est_Cost"]) : 0;
                this._Damage_Equipment_Actual_Cost = drProperty_FR["Damage_Equipment_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Equipment_Actual_Cost"]) : 0;
                this._Damage_Product_Damage_Est_Cost = drProperty_FR["Damage_Product_Damage_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Product_Damage_Est_Cost"]) : 0;
                this._Damage_Product_Damage_Actual_Cost = drProperty_FR["Damage_Product_Damage_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Product_Damage_Actual_Cost"]) : 0;
                this._Damage_Parts_Est_Cost = drProperty_FR["Damage_Parts_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Parts_Est_Cost"]) : 0;
                this._Damage_Parts_Actual_Cost = drProperty_FR["Damage_Parts_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Parts_Actual_Cost"]) : 0;
                this._Damage_Salvage_Cleanup_Est_Cost = drProperty_FR["Damage_Salvage_Cleanup_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Salvage_Cleanup_Est_Cost"]) : 0;
                this._Damage_Salvage_Cleanup_Actual_Cost = drProperty_FR["Damage_Salvage_Cleanup_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Salvage_Cleanup_Actual_Cost"]) : 0;
                this._Damage_Decontamination_Est_Cost = drProperty_FR["Damage_Decontamination_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Decontamination_Est_Cost"]) : 0;
                this._Damage_Decontamination_Actual_Cost = drProperty_FR["Damage_Decontamination_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Decontamination_Actual_Cost"]) : 0;
                this._Damage_Electronic_Data_Est_Cost = drProperty_FR["Damage_Electronic_Data_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Electronic_Data_Est_Cost"]) : 0;
                this._Damage_Electronic_Data_Actual_Cost = drProperty_FR["Damage_Electronic_Data_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Electronic_Data_Actual_Cost"]) : 0;
                this._Damage_Service_Interruption_Est_Cost = drProperty_FR["Damage_Service_Interruption_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Service_Interruption_Est_Cost"]) : 0;
                this._Damage_Service_Interruption_Actual_Cost = drProperty_FR["Damage_Service_Interruption_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Service_Interruption_Actual_Cost"]) : 0;
                this._Damage_Payroll_Est_Cost = drProperty_FR["Damage_Payroll_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Payroll_Est_Cost"]) : 0;
                this._Damage_Payroll_Actual_Cost = drProperty_FR["Damage_Payroll_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Payroll_Actual_Cost"]) : 0;
                this._Damage_Loss_of_Sales_Est_Cost = drProperty_FR["Damage_Loss_of_Sales_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Loss_of_Sales_Est_Cost"]) : 0;
                this._Damage_Loss_of_Sales_Actual_Cost = drProperty_FR["Damage_Loss_of_Sales_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Loss_of_Sales_Actual_Cost"]) : 0;
                this._Date_Cleanup_Complete = drProperty_FR["Date_Cleanup_Complete"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Cleanup_Complete"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Repairs_Complete = drProperty_FR["Date_Repairs_Complete"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Repairs_Complete"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Full_Service_Resumed = drProperty_FR["Date_Full_Service_Resumed"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Full_Service_Resumed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Fire_Protection_Services_Resumed = drProperty_FR["Date_Fire_Protection_Services_Resumed"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Fire_Protection_Services_Resumed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Comments = Convert.ToString(drProperty_FR["Comments"]);
                this._Date_Report_Complete = Convert.ToString(drProperty_FR["Date_Report_Complete"]);
                this._Date_Claim_Closed = Convert.ToString(drProperty_FR["Date_Claim_Closed"]);
                this._Complete = drProperty_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Complete"]) : false;
                this._Updated_By = drProperty_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Updated_By"]) : 0;
                this._Updated_Date = drProperty_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = drProperty_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["FK_SLT_Incident_Review"]) : 0;

                if (drProperty_FR["Security_Video_Surveillance"] != DBNull.Value)
                    this._Security_Video_Surveillance = Convert.ToBoolean(drProperty_FR["Security_Video_Surveillance"]);
            }

            else
            {

                this._PK_Property_FR_ID = -1;
                this._Property_FR_Number = -1;
                this._FK_Location_Code = -1;
                this._FK_Contact = -1;
                this._Date_Reported_to_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Fire = false;
                this._Wind_Damage = false;
                this._Hail_Damage = false;
                this._Earth_Movement = false;
                this._Flood = false;
                this._Third_Party_Property_Damage = false;
                this._Property_Damage_by_Sonic_Associate = false;
                this._Environmental_Loss = false;
                this._Vandalism_To_The_Property = false;
                this._Theft_Associate_Tools = false;
                this._Theft_All_Other = false;
                this._Other = false;
                this._Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_Of_Loss = "";
                this._Description_of_Loss = "";
                this._Damage_Building_Facilities_Est_Cost = -1;
                this._Damage_Building_Facilities_Actual_Cost = -1;
                this._Damage_Equipment_Est_Cost = -1;
                this._Damage_Equipment_Actual_Cost = -1;
                this._Damage_Product_Damage_Est_Cost = -1;
                this._Damage_Product_Damage_Actual_Cost = -1;
                this._Damage_Parts_Est_Cost = -1;
                this._Damage_Parts_Actual_Cost = -1;
                this._Damage_Salvage_Cleanup_Est_Cost = -1;
                this._Damage_Salvage_Cleanup_Actual_Cost = -1;
                this._Damage_Decontamination_Est_Cost = -1;
                this._Damage_Decontamination_Actual_Cost = -1;
                this._Damage_Electronic_Data_Est_Cost = -1;
                this._Damage_Electronic_Data_Actual_Cost = -1;
                this._Damage_Service_Interruption_Est_Cost = -1;
                this._Damage_Service_Interruption_Actual_Cost = -1;
                this._Damage_Payroll_Est_Cost = -1;
                this._Damage_Payroll_Actual_Cost = -1;
                this._Damage_Loss_of_Sales_Est_Cost = -1;
                this._Damage_Loss_of_Sales_Actual_Cost = -1;
                this._Date_Cleanup_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Repairs_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Full_Service_Resumed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Fire_Protection_Services_Resumed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Comments = "";
                this._Date_Report_Complete = "";
                this._Date_Claim_Closed = "";
                this._Complete = false;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = -1;
                this.Security_Video_Surveillance = null;
            }

        }
        
        /// <summary> 
        /// Initializes a new instance of the Property_FR class for passed Property_FR_NUMber with the values set from Database.
        /// </summary>
        public Property_FR(decimal PK,bool temp)
        {

            DataTable dtProperty_FR = SelectByProperty_FR_Number(PK).Tables[0];

            if (dtProperty_FR.Rows.Count > 0)
            {

                DataRow drProperty_FR = dtProperty_FR.Rows[0];

                this._PK_Property_FR_ID = drProperty_FR["PK_Property_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["PK_Property_FR_ID"]) : 0;
                this._Property_FR_Number = drProperty_FR["Property_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Property_FR_Number"]) : 0;
                this._FK_Location_Code = drProperty_FR["FK_Location_Code"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["FK_Location_Code"]) : 0;
                this._FK_Contact = drProperty_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["FK_Contact"]) : 0;
                this._Date_Reported_to_Sonic = drProperty_FR["Date_Reported_to_Sonic"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Reported_to_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Fire = drProperty_FR["Fire"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Fire"]) : false;
                this._Wind_Damage = drProperty_FR["Wind_Damage"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Wind_Damage"]) : false;
                this._Hail_Damage = drProperty_FR["Hail_Damage"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Hail_Damage"]) : false;
                this._Earth_Movement = drProperty_FR["Earth_Movement"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Earth_Movement"]) : false;
                this._Flood = drProperty_FR["Flood"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Flood"]) : false;
                this._Third_Party_Property_Damage = drProperty_FR["Third_Party_Property_Damage"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Third_Party_Property_Damage"]) : false;
                this._Property_Damage_by_Sonic_Associate = drProperty_FR["Property_Damage_by_Sonic_Associate"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Property_Damage_by_Sonic_Associate"]) : false;
                this._Environmental_Loss = drProperty_FR["Environmental_Loss"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Environmental_Loss"]) : false;
                this._Vandalism_To_The_Property = drProperty_FR["Vandalism_To_The_Property"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Vandalism_To_The_Property"]) : false;
                this._Theft_Associate_Tools = drProperty_FR["Theft_Associate_Tools"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Theft_Associate_Tools"]) : false;
                this._Theft_All_Other = drProperty_FR["Theft_All_Other"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Theft_All_Other"]) : false;
                this._Other = drProperty_FR["Other"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Other"]) : false;
                this._Date_Of_Loss = drProperty_FR["Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_Of_Loss = Convert.ToString(drProperty_FR["Time_Of_Loss"]);
                this._Description_of_Loss = Convert.ToString(drProperty_FR["Description_of_Loss"]);
                this._Damage_Building_Facilities_Est_Cost = drProperty_FR["Damage_Building_Facilities_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Building_Facilities_Est_Cost"]) : 0;
                this._Damage_Building_Facilities_Actual_Cost = drProperty_FR["Damage_Building_Facilities_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Building_Facilities_Actual_Cost"]) : 0;
                this._Damage_Equipment_Est_Cost = drProperty_FR["Damage_Equipment_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Equipment_Est_Cost"]) : 0;
                this._Damage_Equipment_Actual_Cost = drProperty_FR["Damage_Equipment_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Equipment_Actual_Cost"]) : 0;
                this._Damage_Product_Damage_Est_Cost = drProperty_FR["Damage_Product_Damage_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Product_Damage_Est_Cost"]) : 0;
                this._Damage_Product_Damage_Actual_Cost = drProperty_FR["Damage_Product_Damage_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Product_Damage_Actual_Cost"]) : 0;
                this._Damage_Parts_Est_Cost = drProperty_FR["Damage_Parts_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Parts_Est_Cost"]) : 0;
                this._Damage_Parts_Actual_Cost = drProperty_FR["Damage_Parts_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Parts_Actual_Cost"]) : 0;
                this._Damage_Salvage_Cleanup_Est_Cost = drProperty_FR["Damage_Salvage_Cleanup_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Salvage_Cleanup_Est_Cost"]) : 0;
                this._Damage_Salvage_Cleanup_Actual_Cost = drProperty_FR["Damage_Salvage_Cleanup_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Salvage_Cleanup_Actual_Cost"]) : 0;
                this._Damage_Decontamination_Est_Cost = drProperty_FR["Damage_Decontamination_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Decontamination_Est_Cost"]) : 0;
                this._Damage_Decontamination_Actual_Cost = drProperty_FR["Damage_Decontamination_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Decontamination_Actual_Cost"]) : 0;
                this._Damage_Electronic_Data_Est_Cost = drProperty_FR["Damage_Electronic_Data_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Electronic_Data_Est_Cost"]) : 0;
                this._Damage_Electronic_Data_Actual_Cost = drProperty_FR["Damage_Electronic_Data_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Electronic_Data_Actual_Cost"]) : 0;
                this._Damage_Service_Interruption_Est_Cost = drProperty_FR["Damage_Service_Interruption_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Service_Interruption_Est_Cost"]) : 0;
                this._Damage_Service_Interruption_Actual_Cost = drProperty_FR["Damage_Service_Interruption_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Service_Interruption_Actual_Cost"]) : 0;
                this._Damage_Payroll_Est_Cost = drProperty_FR["Damage_Payroll_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Payroll_Est_Cost"]) : 0;
                this._Damage_Payroll_Actual_Cost = drProperty_FR["Damage_Payroll_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Payroll_Actual_Cost"]) : 0;
                this._Damage_Loss_of_Sales_Est_Cost = drProperty_FR["Damage_Loss_of_Sales_Est_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Loss_of_Sales_Est_Cost"]) : 0;
                this._Damage_Loss_of_Sales_Actual_Cost = drProperty_FR["Damage_Loss_of_Sales_Actual_Cost"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Damage_Loss_of_Sales_Actual_Cost"]) : 0;
                this._Date_Cleanup_Complete = drProperty_FR["Date_Cleanup_Complete"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Cleanup_Complete"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Repairs_Complete = drProperty_FR["Date_Repairs_Complete"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Repairs_Complete"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Full_Service_Resumed = drProperty_FR["Date_Full_Service_Resumed"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Full_Service_Resumed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Fire_Protection_Services_Resumed = drProperty_FR["Date_Fire_Protection_Services_Resumed"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Date_Fire_Protection_Services_Resumed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Comments = Convert.ToString(drProperty_FR["Comments"]);
                this._Date_Report_Complete = Convert.ToString(drProperty_FR["Date_Report_Complete"]);
                this._Date_Claim_Closed = Convert.ToString(drProperty_FR["Date_Claim_Closed"]);
                this._Complete = drProperty_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drProperty_FR["Complete"]) : false;
                this._Updated_By = drProperty_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["Updated_By"]) : 0;
                this._Updated_Date = drProperty_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = drProperty_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR["FK_SLT_Incident_Review"]) : 0;

            }

            else
            {

                this._PK_Property_FR_ID = -1;
                this._Property_FR_Number = -1;
                this._FK_Location_Code = -1;
                this._FK_Contact = -1;
                this._Date_Reported_to_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Fire = false;
                this._Wind_Damage = false;
                this._Hail_Damage = false;
                this._Earth_Movement = false;
                this._Flood = false;
                this._Third_Party_Property_Damage = false;
                this._Property_Damage_by_Sonic_Associate = false;
                this._Environmental_Loss = false;
                this._Vandalism_To_The_Property = false;
                this._Theft_Associate_Tools = false;
                this._Theft_All_Other = false;
                this._Other = false;
                this._Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_Of_Loss = "";
                this._Description_of_Loss = "";
                this._Damage_Building_Facilities_Est_Cost = -1;
                this._Damage_Building_Facilities_Actual_Cost = -1;
                this._Damage_Equipment_Est_Cost = -1;
                this._Damage_Equipment_Actual_Cost = -1;
                this._Damage_Product_Damage_Est_Cost = -1;
                this._Damage_Product_Damage_Actual_Cost = -1;
                this._Damage_Parts_Est_Cost = -1;
                this._Damage_Parts_Actual_Cost = -1;
                this._Damage_Salvage_Cleanup_Est_Cost = -1;
                this._Damage_Salvage_Cleanup_Actual_Cost = -1;
                this._Damage_Decontamination_Est_Cost = -1;
                this._Damage_Decontamination_Actual_Cost = -1;
                this._Damage_Electronic_Data_Est_Cost = -1;
                this._Damage_Electronic_Data_Actual_Cost = -1;
                this._Damage_Service_Interruption_Est_Cost = -1;
                this._Damage_Service_Interruption_Actual_Cost = -1;
                this._Damage_Payroll_Est_Cost = -1;
                this._Damage_Payroll_Actual_Cost = -1;
                this._Damage_Loss_of_Sales_Est_Cost = -1;
                this._Damage_Loss_of_Sales_Actual_Cost = -1;
                this._Date_Cleanup_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Repairs_Complete = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Full_Service_Resumed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Fire_Protection_Services_Resumed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Comments = "";
                this._Date_Report_Complete = "";
                this._Date_Claim_Closed = "";
                this._Complete = false;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = -1;
            }

        }

        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Property_FR table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FRInsert");

            db.AddInParameter(dbCommand, "Property_FR_Number", DbType.Decimal, this._Property_FR_Number);
            db.AddInParameter(dbCommand, "FK_Location_Code", DbType.Decimal, this._FK_Location_Code);
            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "Date_Reported_to_Sonic", DbType.DateTime, this._Date_Reported_to_Sonic);
            db.AddInParameter(dbCommand, "Fire", DbType.Boolean, this._Fire);
            db.AddInParameter(dbCommand, "Wind_Damage", DbType.Boolean, this._Wind_Damage);
            db.AddInParameter(dbCommand, "Hail_Damage", DbType.Boolean, this._Hail_Damage);
            db.AddInParameter(dbCommand, "Earth_Movement", DbType.Boolean, this._Earth_Movement);
            db.AddInParameter(dbCommand, "Flood", DbType.Boolean, this._Flood);
            db.AddInParameter(dbCommand, "Third_Party_Property_Damage", DbType.Boolean, this._Third_Party_Property_Damage);
            db.AddInParameter(dbCommand, "Property_Damage_by_Sonic_Associate", DbType.Boolean, this._Property_Damage_by_Sonic_Associate);
            db.AddInParameter(dbCommand, "Environmental_Loss", DbType.Boolean, this._Environmental_Loss);
            db.AddInParameter(dbCommand, "Vandalism_To_The_Property", DbType.Boolean, this._Vandalism_To_The_Property);
            db.AddInParameter(dbCommand, "Theft_Associate_Tools", DbType.Boolean, this._Theft_Associate_Tools);
            db.AddInParameter(dbCommand, "Theft_All_Other", DbType.Boolean, this._Theft_All_Other);
            db.AddInParameter(dbCommand, "Other", DbType.Boolean, this._Other);
            db.AddInParameter(dbCommand, "Date_Of_Loss", DbType.DateTime, this._Date_Of_Loss);
            db.AddInParameter(dbCommand, "Time_Of_Loss", DbType.String, this._Time_Of_Loss);
            db.AddInParameter(dbCommand, "Description_of_Loss", DbType.String, this._Description_of_Loss);
            db.AddInParameter(dbCommand, "Damage_Building_Facilities_Est_Cost", DbType.Decimal, this._Damage_Building_Facilities_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Building_Facilities_Actual_Cost", DbType.Decimal, this._Damage_Building_Facilities_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Equipment_Est_Cost", DbType.Decimal, this._Damage_Equipment_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Equipment_Actual_Cost", DbType.Decimal, this._Damage_Equipment_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Product_Damage_Est_Cost", DbType.Decimal, this._Damage_Product_Damage_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Product_Damage_Actual_Cost", DbType.Decimal, this._Damage_Product_Damage_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Parts_Est_Cost", DbType.Decimal, this._Damage_Parts_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Parts_Actual_Cost", DbType.Decimal, this._Damage_Parts_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Salvage_Cleanup_Est_Cost", DbType.Decimal, this._Damage_Salvage_Cleanup_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Salvage_Cleanup_Actual_Cost", DbType.Decimal, this._Damage_Salvage_Cleanup_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Decontamination_Est_Cost", DbType.Decimal, this._Damage_Decontamination_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Decontamination_Actual_Cost", DbType.Decimal, this._Damage_Decontamination_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Electronic_Data_Est_Cost", DbType.Decimal, this._Damage_Electronic_Data_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Electronic_Data_Actual_Cost", DbType.Decimal, this._Damage_Electronic_Data_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Service_Interruption_Est_Cost", DbType.Decimal, this._Damage_Service_Interruption_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Service_Interruption_Actual_Cost", DbType.Decimal, this._Damage_Service_Interruption_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Payroll_Est_Cost", DbType.Decimal, this._Damage_Payroll_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Payroll_Actual_Cost", DbType.Decimal, this._Damage_Payroll_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Loss_of_Sales_Est_Cost", DbType.Decimal, this._Damage_Loss_of_Sales_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Loss_of_Sales_Actual_Cost", DbType.Decimal, this._Damage_Loss_of_Sales_Actual_Cost);
            db.AddInParameter(dbCommand, "Date_Cleanup_Complete", DbType.DateTime, this._Date_Cleanup_Complete);
            db.AddInParameter(dbCommand, "Date_Repairs_Complete", DbType.DateTime, this._Date_Repairs_Complete);
            db.AddInParameter(dbCommand, "Date_Full_Service_Resumed", DbType.DateTime, this._Date_Full_Service_Resumed);
            db.AddInParameter(dbCommand, "Date_Fire_Protection_Services_Resumed", DbType.DateTime, this._Date_Fire_Protection_Services_Resumed);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Date_Report_Complete", DbType.String, this._Date_Report_Complete);
            db.AddInParameter(dbCommand, "Date_Claim_Closed", DbType.String, this._Date_Claim_Closed);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Security_Video_Surveillance", DbType.Boolean, _Security_Video_Surveillance);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Property_FR table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Property_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FRSelectByPK");

            db.AddInParameter(dbCommand, "PK_Property_FR_ID", DbType.Decimal, pK_Property_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Property_FR table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FRSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Property_FR table by a Property_FR_Number.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByProperty_FR_Number(decimal property_FR_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FRSelectByProperty_FR_Number");

            db.AddInParameter(dbCommand, "Property_FR_Number", DbType.Decimal, property_FR_Number);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Property_FR table by a Property_FR_Number.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPKForClaim(decimal PK_Property_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FRSelectByPKForClaim");

            db.AddInParameter(dbCommand, "PK_Property_FR_ID", DbType.Decimal, PK_Property_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Updates a record in the Property_FR table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FRUpdate");

            db.AddInParameter(dbCommand, "PK_Property_FR_ID", DbType.Decimal, this._PK_Property_FR_ID);
            db.AddInParameter(dbCommand, "Property_FR_Number", DbType.Decimal, this._Property_FR_Number);
            db.AddInParameter(dbCommand, "FK_Location_Code", DbType.Decimal, this._FK_Location_Code);
            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "Date_Reported_to_Sonic", DbType.DateTime, this._Date_Reported_to_Sonic);
            db.AddInParameter(dbCommand, "Fire", DbType.Boolean, this._Fire);
            db.AddInParameter(dbCommand, "Wind_Damage", DbType.Boolean, this._Wind_Damage);
            db.AddInParameter(dbCommand, "Hail_Damage", DbType.Boolean, this._Hail_Damage);
            db.AddInParameter(dbCommand, "Earth_Movement", DbType.Boolean, this._Earth_Movement);
            db.AddInParameter(dbCommand, "Flood", DbType.Boolean, this._Flood);
            db.AddInParameter(dbCommand, "Third_Party_Property_Damage", DbType.Boolean, this._Third_Party_Property_Damage);
            db.AddInParameter(dbCommand, "Property_Damage_by_Sonic_Associate", DbType.Boolean, this._Property_Damage_by_Sonic_Associate);
            db.AddInParameter(dbCommand, "Environmental_Loss", DbType.Boolean, this._Environmental_Loss);
            db.AddInParameter(dbCommand, "Vandalism_To_The_Property", DbType.Boolean, this._Vandalism_To_The_Property);
            db.AddInParameter(dbCommand, "Theft_Associate_Tools", DbType.Boolean, this._Theft_Associate_Tools);
            db.AddInParameter(dbCommand, "Theft_All_Other", DbType.Boolean, this._Theft_All_Other);
            db.AddInParameter(dbCommand, "Other", DbType.Boolean, this._Other);
            db.AddInParameter(dbCommand, "Date_Of_Loss", DbType.DateTime, this._Date_Of_Loss);
            db.AddInParameter(dbCommand, "Time_Of_Loss", DbType.String, this._Time_Of_Loss);
            db.AddInParameter(dbCommand, "Description_of_Loss", DbType.String, this._Description_of_Loss);
            db.AddInParameter(dbCommand, "Damage_Building_Facilities_Est_Cost", DbType.Decimal, this._Damage_Building_Facilities_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Building_Facilities_Actual_Cost", DbType.Decimal, this._Damage_Building_Facilities_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Equipment_Est_Cost", DbType.Decimal, this._Damage_Equipment_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Equipment_Actual_Cost", DbType.Decimal, this._Damage_Equipment_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Product_Damage_Est_Cost", DbType.Decimal, this._Damage_Product_Damage_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Product_Damage_Actual_Cost", DbType.Decimal, this._Damage_Product_Damage_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Parts_Est_Cost", DbType.Decimal, this._Damage_Parts_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Parts_Actual_Cost", DbType.Decimal, this._Damage_Parts_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Salvage_Cleanup_Est_Cost", DbType.Decimal, this._Damage_Salvage_Cleanup_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Salvage_Cleanup_Actual_Cost", DbType.Decimal, this._Damage_Salvage_Cleanup_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Decontamination_Est_Cost", DbType.Decimal, this._Damage_Decontamination_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Decontamination_Actual_Cost", DbType.Decimal, this._Damage_Decontamination_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Electronic_Data_Est_Cost", DbType.Decimal, this._Damage_Electronic_Data_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Electronic_Data_Actual_Cost", DbType.Decimal, this._Damage_Electronic_Data_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Service_Interruption_Est_Cost", DbType.Decimal, this._Damage_Service_Interruption_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Service_Interruption_Actual_Cost", DbType.Decimal, this._Damage_Service_Interruption_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Payroll_Est_Cost", DbType.Decimal, this._Damage_Payroll_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Payroll_Actual_Cost", DbType.Decimal, this._Damage_Payroll_Actual_Cost);
            db.AddInParameter(dbCommand, "Damage_Loss_of_Sales_Est_Cost", DbType.Decimal, this._Damage_Loss_of_Sales_Est_Cost);
            db.AddInParameter(dbCommand, "Damage_Loss_of_Sales_Actual_Cost", DbType.Decimal, this._Damage_Loss_of_Sales_Actual_Cost);
            db.AddInParameter(dbCommand, "Date_Cleanup_Complete", DbType.DateTime, this._Date_Cleanup_Complete);
            db.AddInParameter(dbCommand, "Date_Repairs_Complete", DbType.DateTime, this._Date_Repairs_Complete);
            db.AddInParameter(dbCommand, "Date_Full_Service_Resumed", DbType.DateTime, this._Date_Full_Service_Resumed);
            db.AddInParameter(dbCommand, "Date_Fire_Protection_Services_Resumed", DbType.DateTime, this._Date_Fire_Protection_Services_Resumed);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Date_Report_Complete", DbType.String, this._Date_Report_Complete);
            db.AddInParameter(dbCommand, "Date_Claim_Closed", DbType.String, this._Date_Claim_Closed);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Security_Video_Surveillance", DbType.Boolean, _Security_Video_Surveillance);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Property_FR table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Property_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FRDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Property_FR_ID", DbType.Decimal, pK_Property_FR_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
