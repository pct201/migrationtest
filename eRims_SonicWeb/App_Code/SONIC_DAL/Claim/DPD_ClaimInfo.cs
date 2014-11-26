using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for DPD_ClaimInfo
    /// </summary>
    public class DPD_ClaimInfo
    {
        #region Fields

        private Int64 _PK_DPD_Claims_ID;
        private int _DPD_FR_Number;
        private decimal _FK_Loss_Location;
        private decimal _FK_Contact;
        private string _Loss_Address_1;
        private string _Loss_Address_2;
        private string _Loss_City;
        private string _Loss_State;
        private string _Loss_Zip_Code;
        private string _Time_of_Loss;
        private DateTime _Date_Reported_To_Sonic;
        private DateTime _Date_Of_Loss;
        private bool _On_Company_Property;
        private bool _Theft;
        private string _Theft_Make;
        private string _Theft_Model;
        private decimal _Theft_Year;
        private string _Theft_VIN;
        private decimal _Vehicle_Invoice_Value;
        private bool _Vehicle_Recovered;
        private decimal _Theft_Vehicle_Damage_Amount;
        private bool _Theft_Dealership_Wish_To_Take_Possession;
        private bool _Partial_Theft;
        private decimal _Partial_Theft_Number_of_Vehicles_Damaged;
        private decimal _Parial_Theft_Damage_Estimate;
        private bool _Vandalism;
        private decimal _Vandalism_Number_of_Vehicles_Damaged;
        private decimal _Vandalism_Total_Estimate_of_Damages;
        private bool _MVA_Single;
        private bool _MVA_Multiple;
        private bool _Hail;
        private decimal _Hail_Number_Of_Vehicles_Damaged;
        private decimal _Hail_Damage_Estimate;
        private bool _Flood;
        private decimal _Flood_Number_Of_Vehicles_Damaged;
        private decimal _Flood_Damage_Estimate;
        private bool _Fire;
        private decimal _Fire_Number_Of_Vehicles_Damaged;
        private decimal _Fire_Damage_Estimate;
        private bool _Wind;
        private decimal _Wind_Number_Of_Vehicles_Damaged;
        private decimal _Wind_Damage_Estimate;
        private bool _Fraud;
        private string _Comments;
        private Int32 _Associated_First_Report;
        private DateTime _Date_Of_Update;
        private String _Claim_Number;
        private String _DataSource;
        #endregion

        #region Properties
        /// <summary> 
        /// Gets or sets the PK_DPD_Claims_ID value.
        /// </summary> 
        public Int64 PK_DPD_Claims_ID
        {
            get { return _PK_DPD_Claims_ID; }
            set { _PK_DPD_Claims_ID = value; }
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
        /// Gets or sets the DPD_FR_Number value.
        /// </summary> 
        public int DPD_FR_Number
        {
            get { return _DPD_FR_Number; }
            set { _DPD_FR_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Loss_Location value.
        /// </summary> 
        public decimal FK_Loss_Location
        {
            get { return _FK_Loss_Location; }
            set { _FK_Loss_Location = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Address_1 value.
        /// </summary> 
        public string Loss_Address_1
        {
            get { return _Loss_Address_1; }
            set { _Loss_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Address_2 value.
        /// </summary> 
        public string Loss_Address_2
        {
            get { return _Loss_Address_2; }
            set { _Loss_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_City value.
        /// </summary> 
        public string Loss_City
        {
            get { return _Loss_City; }
            set { _Loss_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_State value.
        /// </summary> 
        public string Loss_State
        {
            get { return _Loss_State; }
            set { _Loss_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Zip_Code value.
        /// </summary> 
        public string Loss_Zip_Code
        {
            get { return _Loss_Zip_Code; }
            set { _Loss_Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Time_of_Loss value.
        /// </summary> 
        public string Time_of_Loss
        {
            get { return _Time_of_Loss; }
            set { _Time_of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Reported_To_Sonic value.
        /// </summary> 
        public DateTime Date_Reported_To_Sonic
        {
            get { return _Date_Reported_To_Sonic; }
            set { _Date_Reported_To_Sonic = value; }
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
        /// Gets or sets the On_Company_Property value.
        /// </summary> 
        public bool On_Company_Property
        {
            get { return _On_Company_Property; }
            set { _On_Company_Property = value; }
        }


        /// <summary> 
        /// Gets or sets the Theft value.
        /// </summary> 
        public bool Theft
        {
            get { return _Theft; }
            set { _Theft = value; }
        }


        /// <summary> 
        /// Gets or sets the Theft_Make value.
        /// </summary> 
        public string Theft_Make
        {
            get { return _Theft_Make; }
            set { _Theft_Make = value; }
        }


        /// <summary> 
        /// Gets or sets the Theft_Model value.
        /// </summary> 
        public string Theft_Model
        {
            get { return _Theft_Model; }
            set { _Theft_Model = value; }
        }


        /// <summary> 
        /// Gets or sets the Theft_Year value.
        /// </summary> 
        public decimal Theft_Year
        {
            get { return _Theft_Year; }
            set { _Theft_Year = value; }
        }


        /// <summary> 
        /// Gets or sets the Theft_VIN value.
        /// </summary> 
        public string Theft_VIN
        {
            get { return _Theft_VIN; }
            set { _Theft_VIN = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Invoice_Value value.
        /// </summary> 
        public decimal Vehicle_Invoice_Value
        {
            get { return _Vehicle_Invoice_Value; }
            set { _Vehicle_Invoice_Value = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Recovered value.
        /// </summary> 
        public bool Vehicle_Recovered
        {
            get { return _Vehicle_Recovered; }
            set { _Vehicle_Recovered = value; }
        }


        /// <summary> 
        /// Gets or sets the Theft_Vehicle_Damage_Amount value.
        /// </summary> 
        public decimal Theft_Vehicle_Damage_Amount
        {
            get { return _Theft_Vehicle_Damage_Amount; }
            set { _Theft_Vehicle_Damage_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Theft_Dealership_Wish_To_Take_Possession value.
        /// </summary> 
        public bool Theft_Dealership_Wish_To_Take_Possession
        {
            get { return _Theft_Dealership_Wish_To_Take_Possession; }
            set { _Theft_Dealership_Wish_To_Take_Possession = value; }
        }


        /// <summary> 
        /// Gets or sets the Partial_Theft value.
        /// </summary> 
        public bool Partial_Theft
        {
            get { return _Partial_Theft; }
            set { _Partial_Theft = value; }
        }


        /// <summary> 
        /// Gets or sets the Partial_Theft_Number_of_Vehicles_Damaged value.
        /// </summary> 
        public decimal Partial_Theft_Number_of_Vehicles_Damaged
        {
            get { return _Partial_Theft_Number_of_Vehicles_Damaged; }
            set { _Partial_Theft_Number_of_Vehicles_Damaged = value; }
        }


        /// <summary> 
        /// Gets or sets the Parial_Theft_Damage_Estimate value.
        /// </summary> 
        public decimal Parial_Theft_Damage_Estimate
        {
            get { return _Parial_Theft_Damage_Estimate; }
            set { _Parial_Theft_Damage_Estimate = value; }
        }


        /// <summary> 
        /// Gets or sets the Vandalism value.
        /// </summary> 
        public bool Vandalism
        {
            get { return _Vandalism; }
            set { _Vandalism = value; }
        }


        /// <summary> 
        /// Gets or sets the Vandalism_Number_of_Vehicles_Damaged value.
        /// </summary> 
        public decimal Vandalism_Number_of_Vehicles_Damaged
        {
            get { return _Vandalism_Number_of_Vehicles_Damaged; }
            set { _Vandalism_Number_of_Vehicles_Damaged = value; }
        }


        /// <summary> 
        /// Gets or sets the Vandalism_Total_Estimate_of_Damages value.
        /// </summary> 
        public decimal Vandalism_Total_Estimate_of_Damages
        {
            get { return _Vandalism_Total_Estimate_of_Damages; }
            set { _Vandalism_Total_Estimate_of_Damages = value; }
        }


        /// <summary> 
        /// Gets or sets the MVA_Single value.
        /// </summary> 
        public bool MVA_Single
        {
            get { return _MVA_Single; }
            set { _MVA_Single = value; }
        }


        /// <summary> 
        /// Gets or sets the MVA_Multiple value.
        /// </summary> 
        public bool MVA_Multiple
        {
            get { return _MVA_Multiple; }
            set { _MVA_Multiple = value; }
        }


        /// <summary> 
        /// Gets or sets the Hail value.
        /// </summary> 
        public bool Hail
        {
            get { return _Hail; }
            set { _Hail = value; }
        }


        /// <summary> 
        /// Gets or sets the Hail_Number_Of_Vehicles_Damaged value.
        /// </summary> 
        public decimal Hail_Number_Of_Vehicles_Damaged
        {
            get { return _Hail_Number_Of_Vehicles_Damaged; }
            set { _Hail_Number_Of_Vehicles_Damaged = value; }
        }


        /// <summary> 
        /// Gets or sets the Hail_Damage_Estimate value.
        /// </summary> 
        public decimal Hail_Damage_Estimate
        {
            get { return _Hail_Damage_Estimate; }
            set { _Hail_Damage_Estimate = value; }
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
        /// Gets or sets the Flood_Number_Of_Vehicles_Damaged value.
        /// </summary> 
        public decimal Flood_Number_Of_Vehicles_Damaged
        {
            get { return _Flood_Number_Of_Vehicles_Damaged; }
            set { _Flood_Number_Of_Vehicles_Damaged = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Damage_Estimate value.
        /// </summary> 
        public decimal Flood_Damage_Estimate
        {
            get { return _Flood_Damage_Estimate; }
            set { _Flood_Damage_Estimate = value; }
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
        /// Gets or sets the Fire_Number_Of_Vehicles_Damaged value.
        /// </summary> 
        public decimal Fire_Number_Of_Vehicles_Damaged
        {
            get { return _Fire_Number_Of_Vehicles_Damaged; }
            set { _Fire_Number_Of_Vehicles_Damaged = value; }
        }


        /// <summary> 
        /// Gets or sets the Fire_Damage_Estimate value.
        /// </summary> 
        public decimal Fire_Damage_Estimate
        {
            get { return _Fire_Damage_Estimate; }
            set { _Fire_Damage_Estimate = value; }
        }


        /// <summary> 
        /// Gets or sets the Wind value.
        /// </summary> 
        public bool Wind
        {
            get { return _Wind; }
            set { _Wind = value; }
        }


        /// <summary> 
        /// Gets or sets the Wind_Number_Of_Vehicles_Damaged value.
        /// </summary> 
        public decimal Wind_Number_Of_Vehicles_Damaged
        {
            get { return _Wind_Number_Of_Vehicles_Damaged; }
            set { _Wind_Number_Of_Vehicles_Damaged = value; }
        }


        /// <summary> 
        /// Gets or sets the Wind_Damage_Estimate value.
        /// </summary> 
        public decimal Wind_Damage_Estimate
        {
            get { return _Wind_Damage_Estimate; }
            set { _Wind_Damage_Estimate = value; }
        }


        /// <summary> 
        /// Gets or sets the Fraud value.
        /// </summary> 
        public bool Fraud
        {
            get { return _Fraud; }
            set { _Fraud = value; }
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
        /// Gets or sets the Associated_First_Report value.
        /// </summary> 
        public Int32 Associated_First_Report
        {
            get { return _Associated_First_Report; }
            set { _Associated_First_Report = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Of_Update value.
        /// </summary> 
        public DateTime Date_Of_Update
        {
            get { return _Date_Of_Update; }
            set { _Date_Of_Update = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Number value.
        /// </summary> 
        public string Claim_Number
        {
            get { return _Claim_Number; }
            set { _Claim_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the DataSource value.
        /// </summary> 
        public string DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the DPD_Claims class. with the default value.

        /// </summary>
        public DPD_ClaimInfo()
        {
            this._PK_DPD_Claims_ID = -1;
            this._DPD_FR_Number = -1;
            this._FK_Loss_Location = -1;
            this._FK_Contact = -1;
            this._Loss_Address_1 = "";
            this._Loss_Address_2 = "";
            this._Loss_City = "";
            this._Loss_State = "";
            this._Loss_Zip_Code = "";
            this._Time_of_Loss = "";
            this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._On_Company_Property = false;
            this._Theft = false;
            this._Theft_Make = "";
            this._Theft_Model = "";
            this._Theft_Year = -1;
            this._Theft_VIN = "";
            this._Vehicle_Invoice_Value = -1;
            this._Vehicle_Recovered = false;
            this._Theft_Vehicle_Damage_Amount = -1;
            this._Theft_Dealership_Wish_To_Take_Possession = false;
            this._Partial_Theft = false;
            this._Partial_Theft_Number_of_Vehicles_Damaged = -1;
            this._Parial_Theft_Damage_Estimate = -1;
            this._Vandalism = false;
            this._Vandalism_Number_of_Vehicles_Damaged = -1;
            this._Vandalism_Total_Estimate_of_Damages = -1;
            this._MVA_Single = false;
            this._MVA_Multiple = false;
            this._Hail = false;
            this._Hail_Number_Of_Vehicles_Damaged = -1;
            this._Hail_Damage_Estimate = -1;
            this._Flood = false;
            this._Flood_Number_Of_Vehicles_Damaged = -1;
            this._Flood_Damage_Estimate = -1;
            this._Fire = false;
            this._Fire_Number_Of_Vehicles_Damaged = -1;
            this._Fire_Damage_Estimate = -1;
            this._Wind = false;
            this._Wind_Number_Of_Vehicles_Damaged = -1;
            this._Wind_Damage_Estimate = -1;
            this._Fraud = false;
            this._Comments = "";
            this._Associated_First_Report = 0;
            this._Date_Of_Update = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Claim_Number = "";
            this.DataSource = "";
        }



        /// <summary> 

        /// Initializes a new instance of the DPD_Claims class for passed PrimaryKey with the values set from Database.

        ///</summary> 
        public DPD_ClaimInfo(int PK)
        {
            DataTable dtDPD_Claims = SelectByPK(PK).Tables[0];

            if (dtDPD_Claims.Rows.Count > 0)
            {
                DataRow drDPD_Claims = dtDPD_Claims.Rows[0];
                this._PK_DPD_Claims_ID = drDPD_Claims["PK_DPD_Claims_ID"] != DBNull.Value ? Convert.ToInt32(drDPD_Claims["PK_DPD_Claims_ID"]) : 0;
                this._DPD_FR_Number = drDPD_Claims["DPD_FR_Number"] != DBNull.Value ? Convert.ToInt32(drDPD_Claims["DPD_FR_Number"]) : 0;
                this._FK_Loss_Location = drDPD_Claims["FK_Loss_Location"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["FK_Loss_Location"]) : 0;
                this._FK_Contact = drDPD_Claims["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["FK_Contact"]) : 0;
                this._Loss_Address_1 = Convert.ToString(drDPD_Claims["Loss_Address_1"]);
                this._Loss_Address_2 = Convert.ToString(drDPD_Claims["Loss_Address_2"]);
                this._Loss_City = Convert.ToString(drDPD_Claims["Loss_City"]);
                this._Loss_State = Convert.ToString(drDPD_Claims["Loss_State"]);
                this._Loss_Zip_Code = Convert.ToString(drDPD_Claims["Loss_Zip_Code"]);
                this._Time_of_Loss = Convert.ToString(drDPD_Claims["Time_of_Loss"]);
                this._Date_Reported_To_Sonic = drDPD_Claims["Date_Reported_To_Sonic"] != DBNull.Value ? Convert.ToDateTime(drDPD_Claims["Date_Reported_To_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Of_Loss = drDPD_Claims["Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._On_Company_Property = drDPD_Claims["On_Company_Property"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["On_Company_Property"]) : false;
                this._Theft = drDPD_Claims["Theft"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Theft"]) : false;
                this._Theft_Make = Convert.ToString(drDPD_Claims["Theft_Make"]);
                this._Theft_Model = Convert.ToString(drDPD_Claims["Theft_Model"]);
                this._Theft_Year = drDPD_Claims["Theft_Year"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Theft_Year"]) : 0;
                this._Theft_VIN = Convert.ToString(drDPD_Claims["Theft_VIN"]);
                this._Vehicle_Invoice_Value = drDPD_Claims["Vehicle_Invoice_Value"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Vehicle_Invoice_Value"]) : 0;
                this._Vehicle_Recovered = drDPD_Claims["Vehicle_Recovered"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Vehicle_Recovered"]) : false;
                this._Theft_Vehicle_Damage_Amount = drDPD_Claims["Theft_Vehicle_Damage_Amount"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Theft_Vehicle_Damage_Amount"]) : 0;
                this._Theft_Dealership_Wish_To_Take_Possession = drDPD_Claims["Theft_Dealership_Wish_To_Take_Possession"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Theft_Dealership_Wish_To_Take_Possession"]) : false;
                this._Partial_Theft = drDPD_Claims["Partial_Theft"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Partial_Theft"]) : false;
                this._Partial_Theft_Number_of_Vehicles_Damaged = drDPD_Claims["Partial_Theft_Number_of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Partial_Theft_Number_of_Vehicles_Damaged"]) : 0;
                this._Parial_Theft_Damage_Estimate = drDPD_Claims["Parial_Theft_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Parial_Theft_Damage_Estimate"]) : 0;
                this._Vandalism = drDPD_Claims["Vandalism"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Vandalism"]) : false;
                this._Vandalism_Number_of_Vehicles_Damaged = drDPD_Claims["Vandalism_Number_of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Vandalism_Number_of_Vehicles_Damaged"]) : 0;
                this._Vandalism_Total_Estimate_of_Damages = drDPD_Claims["Vandalism_Total_Estimate_of_Damages"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Vandalism_Total_Estimate_of_Damages"]) : 0;
                this._MVA_Single = drDPD_Claims["MVA_Single"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["MVA_Single"]) : false;
                this._MVA_Multiple = drDPD_Claims["MVA_Multiple"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["MVA_Multiple"]) : false;
                this._Hail = drDPD_Claims["Hail"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Hail"]) : false;
                this._Hail_Number_Of_Vehicles_Damaged = drDPD_Claims["Hail_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Hail_Number_Of_Vehicles_Damaged"]) : 0;
                this._Hail_Damage_Estimate = drDPD_Claims["Hail_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Hail_Damage_Estimate"]) : 0;
                this._Flood = drDPD_Claims["Flood"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Flood"]) : false;
                this._Flood_Number_Of_Vehicles_Damaged = drDPD_Claims["Flood_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Flood_Number_Of_Vehicles_Damaged"]) : 0;
                this._Flood_Damage_Estimate = drDPD_Claims["Flood_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Flood_Damage_Estimate"]) : 0;
                this._Fire = drDPD_Claims["Fire"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Fire"]) : false;
                this._Fire_Number_Of_Vehicles_Damaged = drDPD_Claims["Fire_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Fire_Number_Of_Vehicles_Damaged"]) : 0;
                this._Fire_Damage_Estimate = drDPD_Claims["Fire_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Fire_Damage_Estimate"]) : 0;
                this._Wind = drDPD_Claims["Wind"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Wind"]) : false;
                this._Wind_Number_Of_Vehicles_Damaged = drDPD_Claims["Wind_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Wind_Number_Of_Vehicles_Damaged"]) : 0;
                this._Wind_Damage_Estimate = drDPD_Claims["Wind_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_Claims["Wind_Damage_Estimate"]) : 0;
                this._Fraud = drDPD_Claims["Fraud"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["Fraud"]) : false;
                this._Comments = Convert.ToString(drDPD_Claims["Comments"]);
                this._Associated_First_Report = drDPD_Claims["Associated_First_Report"] != DBNull.Value ? Convert.ToInt32(drDPD_Claims["Associated_First_Report"]) : 0;
                this._Date_Of_Update = drDPD_Claims["Date_Of_Update"] != DBNull.Value ? Convert.ToDateTime(drDPD_Claims["Date_Of_Update"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claim_Number = Convert.ToString(drDPD_Claims["Claim_Number"]);
                this._DataSource = Convert.ToString(drDPD_Claims["Claim_Number"]);
            }

            else
            {
                this._PK_DPD_Claims_ID = -1;
                this._DPD_FR_Number = -1;
                this._FK_Loss_Location = -1;
                this._FK_Contact = -1;
                this._Loss_Address_1 = "";
                this._Loss_Address_2 = "";
                this._Loss_City = "";
                this._Loss_State = "";
                this._Loss_Zip_Code = "";
                this._Time_of_Loss = "";
                this._Date_Reported_To_Sonic = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._On_Company_Property = false;
                this._Theft = false;
                this._Theft_Make = "";
                this._Theft_Model = "";
                this._Theft_Year = -1;
                this._Theft_VIN = "";
                this._Vehicle_Invoice_Value = -1;
                this._Vehicle_Recovered = false;
                this._Theft_Vehicle_Damage_Amount = -1;
                this._Theft_Dealership_Wish_To_Take_Possession = false;
                this._Partial_Theft = false;
                this._Partial_Theft_Number_of_Vehicles_Damaged = -1;
                this._Parial_Theft_Damage_Estimate = -1;
                this._Vandalism = false;
                this._Vandalism_Number_of_Vehicles_Damaged = -1;
                this._Vandalism_Total_Estimate_of_Damages = -1;
                this._MVA_Single = false;
                this._MVA_Multiple = false;
                this._Hail = false;
                this._Hail_Number_Of_Vehicles_Damaged = -1;
                this._Hail_Damage_Estimate = -1;
                this._Flood = false;
                this._Flood_Number_Of_Vehicles_Damaged = -1;
                this._Flood_Damage_Estimate = -1;
                this._Fire = false;
                this._Fire_Number_Of_Vehicles_Damaged = -1;
                this._Fire_Damage_Estimate = -1;
                this._Wind = false;
                this._Wind_Number_Of_Vehicles_Damaged = -1;
                this._Wind_Damage_Estimate = -1;
                this._Fraud = false;
                this._Comments = "";
                this._Associated_First_Report = 0;
                this._Date_Of_Update = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claim_Number = "";
                this._DataSource = "";
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// Selects a single record from the Workers_Comp_Claims table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(Int64 pK_DPD_Claims_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_ClaimsSelectByPK");

            db.AddInParameter(dbCommand, "PK_DPD_Claims_ID", DbType.Int64, pK_DPD_Claims_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectViewClaim(Int64 pK_DPD_Claims_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_ViewClaim");

            db.AddInParameter(dbCommand, "PK_DPD_Claims_ID", DbType.Int64, pK_DPD_Claims_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
