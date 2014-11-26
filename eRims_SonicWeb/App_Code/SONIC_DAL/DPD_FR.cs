using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for DPD_FR table.
    /// </summary>
    public sealed class DPD_FR
    {
        #region Fields


        private decimal _PK_DPD_FR_ID;
        private decimal _FK_Contact;
        private decimal _DPD_FR_Number;
        private decimal _FK_Loss_Location;
        private string _Loss_Address_1;
        private string _Loss_Address_2;
        private string _Loss_City;
        private string _Loss_State;
        private string _Loss_ZipCode;
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
        private bool _Complete;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        private decimal _FK_SLT_Incident_Review;
        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_DPD_FR_ID value.
        /// </summary>
        public decimal PK_DPD_FR_ID
        {
            get { return _PK_DPD_FR_ID; }
            set { _PK_DPD_FR_ID = value; }
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
        public decimal DPD_FR_Number
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
        /// Gets or sets the Loss_ZipCode value.
        /// </summary>
        public string Loss_ZipCode
        {
            get { return _Loss_ZipCode; }
            set { _Loss_ZipCode = value; }
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
        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the DPD_FR class. with the default value.

        /// </summary>
        public DPD_FR()
        {

            this._PK_DPD_FR_ID = -1;
            this._FK_Contact = -1;
            this._DPD_FR_Number = -1;
            this._FK_Loss_Location = -1;
            this._Loss_Address_1 = "";
            this._Loss_Address_2 = "";
            this._Loss_City = "";
            this._Loss_State = "";
            this._Loss_ZipCode = "";
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
            this._Complete = false;
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._FK_SLT_Incident_Review = -1;
        }



        /// <summary> 
        /// Initializes a new instance of the DPD_FR class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public DPD_FR(decimal PK)
        {

            DataTable dtDPD_FR = SelectByPK(PK).Tables[0];

            if (dtDPD_FR.Rows.Count > 0)
            {

                DataRow drDPD_FR = dtDPD_FR.Rows[0];

                this._PK_DPD_FR_ID = drDPD_FR["PK_DPD_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["PK_DPD_FR_ID"]) : 0;
                this._FK_Contact = drDPD_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["FK_Contact"]) : 0;
                this._DPD_FR_Number = drDPD_FR["DPD_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["DPD_FR_Number"]) : 0;
                this._FK_Loss_Location = drDPD_FR["FK_Loss_Location"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["FK_Loss_Location"]) : 0;
                this._Loss_Address_1 = Convert.ToString(drDPD_FR["Loss_Address_1"]);
                this._Loss_Address_2 = Convert.ToString(drDPD_FR["Loss_Address_2"]);
                this._Loss_City = Convert.ToString(drDPD_FR["Loss_City"]);
                this._Loss_State = Convert.ToString(drDPD_FR["Loss_State"]);
                this._Loss_ZipCode = Convert.ToString(drDPD_FR["Loss_ZipCode"]);
                this._Time_of_Loss = Convert.ToString(drDPD_FR["Time_of_Loss"]);
                this._Date_Reported_To_Sonic = drDPD_FR["Date_Reported_To_Sonic"] != DBNull.Value ? Convert.ToDateTime(drDPD_FR["Date_Reported_To_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Of_Loss = drDPD_FR["Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drDPD_FR["Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._On_Company_Property = drDPD_FR["On_Company_Property"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["On_Company_Property"]) : false;
                this._Theft = drDPD_FR["Theft"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Theft"]) : false;
                this._Theft_Make = Convert.ToString(drDPD_FR["Theft_Make"]);
                this._Theft_Model = Convert.ToString(drDPD_FR["Theft_Model"]);
                this._Theft_Year = drDPD_FR["Theft_Year"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Theft_Year"]) : 0;
                this._Theft_VIN = Convert.ToString(drDPD_FR["Theft_VIN"]);
                this._Vehicle_Invoice_Value = drDPD_FR["Vehicle_Invoice_Value"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Vehicle_Invoice_Value"]) : 0;
                this._Vehicle_Recovered = drDPD_FR["Vehicle_Recovered"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Vehicle_Recovered"]) : false;
                this._Theft_Vehicle_Damage_Amount = drDPD_FR["Theft_Vehicle_Damage_Amount"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Theft_Vehicle_Damage_Amount"]) : 0;
                this._Theft_Dealership_Wish_To_Take_Possession = drDPD_FR["Theft_Dealership_Wish_To_Take_Possession"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Theft_Dealership_Wish_To_Take_Possession"]) : false;
                this._Partial_Theft = drDPD_FR["Partial_Theft"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Partial_Theft"]) : false;
                this._Partial_Theft_Number_of_Vehicles_Damaged = drDPD_FR["Partial_Theft_Number_of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Partial_Theft_Number_of_Vehicles_Damaged"]) : 0;
                this._Parial_Theft_Damage_Estimate = drDPD_FR["Parial_Theft_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Parial_Theft_Damage_Estimate"]) : 0;
                this._Vandalism = drDPD_FR["Vandalism"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Vandalism"]) : false;
                this._Vandalism_Number_of_Vehicles_Damaged = drDPD_FR["Vandalism_Number_of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Vandalism_Number_of_Vehicles_Damaged"]) : 0;
                this._Vandalism_Total_Estimate_of_Damages = drDPD_FR["Vandalism_Total_Estimate_of_Damages"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Vandalism_Total_Estimate_of_Damages"]) : 0;
                this._MVA_Single = drDPD_FR["MVA_Single"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["MVA_Single"]) : false;
                this._MVA_Multiple = drDPD_FR["MVA_Multiple"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["MVA_Multiple"]) : false;
                this._Hail = drDPD_FR["Hail"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Hail"]) : false;
                this._Hail_Number_Of_Vehicles_Damaged = drDPD_FR["Hail_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Hail_Number_Of_Vehicles_Damaged"]) : 0;
                this._Hail_Damage_Estimate = drDPD_FR["Hail_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Hail_Damage_Estimate"]) : 0;
                this._Flood = drDPD_FR["Flood"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Flood"]) : false;
                this._Flood_Number_Of_Vehicles_Damaged = drDPD_FR["Flood_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Flood_Number_Of_Vehicles_Damaged"]) : 0;
                this._Flood_Damage_Estimate = drDPD_FR["Flood_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Flood_Damage_Estimate"]) : 0;
                this._Fire = drDPD_FR["Fire"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Fire"]) : false;
                this._Fire_Number_Of_Vehicles_Damaged = drDPD_FR["Fire_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Fire_Number_Of_Vehicles_Damaged"]) : 0;
                this._Fire_Damage_Estimate = drDPD_FR["Fire_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Fire_Damage_Estimate"]) : 0;
                this._Wind = drDPD_FR["Wind"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Wind"]) : false;
                this._Wind_Number_Of_Vehicles_Damaged = drDPD_FR["Wind_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Wind_Number_Of_Vehicles_Damaged"]) : 0;
                this._Wind_Damage_Estimate = drDPD_FR["Wind_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Wind_Damage_Estimate"]) : 0;
                this._Fraud = drDPD_FR["Fraud"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Fraud"]) : false;
                this._Comments = Convert.ToString(drDPD_FR["Comments"]);
                this._Complete = drDPD_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Complete"]) : false;
                this._Updated_By = drDPD_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Updated_By"]) : 0;
                this._Updated_Date = drDPD_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drDPD_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = drDPD_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["FK_SLT_Incident_Review"]) : 0;
            }

            else
            {

                this._PK_DPD_FR_ID = -1;
                this._FK_Contact = -1;
                this._DPD_FR_Number = -1;
                this._FK_Loss_Location = -1;
                this._Loss_Address_1 = "";
                this._Loss_Address_2 = "";
                this._Loss_City = "";
                this._Loss_State = "";
                this._Loss_ZipCode = "";
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
                this._Complete = false;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = -1;
            }

        }


        /// <summary> 
        /// Initializes a new instance of the DPD_FR class for passed DPD_FR_Number with the values set from Database.
        /// </summary>
        public DPD_FR(decimal DPD_FR_Number,bool temp)
        {

            DataTable dtDPD_FR = SelectByDPD_FR_Number(DPD_FR_Number).Tables[0];

            if (dtDPD_FR.Rows.Count > 0)
            {

                DataRow drDPD_FR = dtDPD_FR.Rows[0];

                this._PK_DPD_FR_ID = drDPD_FR["PK_DPD_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["PK_DPD_FR_ID"]) : 0;
                this._FK_Contact = drDPD_FR["FK_Contact"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["FK_Contact"]) : 0;
                this._DPD_FR_Number = drDPD_FR["DPD_FR_Number"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["DPD_FR_Number"]) : 0;
                this._FK_Loss_Location = drDPD_FR["FK_Loss_Location"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["FK_Loss_Location"]) : 0;
                this._Loss_Address_1 = Convert.ToString(drDPD_FR["Loss_Address_1"]);
                this._Loss_Address_2 = Convert.ToString(drDPD_FR["Loss_Address_2"]);
                this._Loss_City = Convert.ToString(drDPD_FR["Loss_City"]);
                this._Loss_State = Convert.ToString(drDPD_FR["Loss_State"]);
                this._Loss_ZipCode = Convert.ToString(drDPD_FR["Loss_ZipCode"]);
                this._Time_of_Loss = Convert.ToString(drDPD_FR["Time_of_Loss"]);
                this._Date_Reported_To_Sonic = drDPD_FR["Date_Reported_To_Sonic"] != DBNull.Value ? Convert.ToDateTime(drDPD_FR["Date_Reported_To_Sonic"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Of_Loss = drDPD_FR["Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drDPD_FR["Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._On_Company_Property = drDPD_FR["On_Company_Property"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["On_Company_Property"]) : false;
                this._Theft = drDPD_FR["Theft"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Theft"]) : false;
                this._Theft_Make = Convert.ToString(drDPD_FR["Theft_Make"]);
                this._Theft_Model = Convert.ToString(drDPD_FR["Theft_Model"]);
                this._Theft_Year = drDPD_FR["Theft_Year"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Theft_Year"]) : 0;
                this._Theft_VIN = Convert.ToString(drDPD_FR["Theft_VIN"]);
                this._Vehicle_Invoice_Value = drDPD_FR["Vehicle_Invoice_Value"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Vehicle_Invoice_Value"]) : 0;
                this._Vehicle_Recovered = drDPD_FR["Vehicle_Recovered"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Vehicle_Recovered"]) : false;
                this._Theft_Vehicle_Damage_Amount = drDPD_FR["Theft_Vehicle_Damage_Amount"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Theft_Vehicle_Damage_Amount"]) : 0;
                this._Theft_Dealership_Wish_To_Take_Possession = drDPD_FR["Theft_Dealership_Wish_To_Take_Possession"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Theft_Dealership_Wish_To_Take_Possession"]) : false;
                this._Partial_Theft = drDPD_FR["Partial_Theft"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Partial_Theft"]) : false;
                this._Partial_Theft_Number_of_Vehicles_Damaged = drDPD_FR["Partial_Theft_Number_of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Partial_Theft_Number_of_Vehicles_Damaged"]) : 0;
                this._Parial_Theft_Damage_Estimate = drDPD_FR["Parial_Theft_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Parial_Theft_Damage_Estimate"]) : 0;
                this._Vandalism = drDPD_FR["Vandalism"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Vandalism"]) : false;
                this._Vandalism_Number_of_Vehicles_Damaged = drDPD_FR["Vandalism_Number_of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Vandalism_Number_of_Vehicles_Damaged"]) : 0;
                this._Vandalism_Total_Estimate_of_Damages = drDPD_FR["Vandalism_Total_Estimate_of_Damages"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Vandalism_Total_Estimate_of_Damages"]) : 0;
                this._MVA_Single = drDPD_FR["MVA_Single"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["MVA_Single"]) : false;
                this._MVA_Multiple = drDPD_FR["MVA_Multiple"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["MVA_Multiple"]) : false;
                this._Hail = drDPD_FR["Hail"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Hail"]) : false;
                this._Hail_Number_Of_Vehicles_Damaged = drDPD_FR["Hail_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Hail_Number_Of_Vehicles_Damaged"]) : 0;
                this._Hail_Damage_Estimate = drDPD_FR["Hail_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Hail_Damage_Estimate"]) : 0;
                this._Flood = drDPD_FR["Flood"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Flood"]) : false;
                this._Flood_Number_Of_Vehicles_Damaged = drDPD_FR["Flood_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Flood_Number_Of_Vehicles_Damaged"]) : 0;
                this._Flood_Damage_Estimate = drDPD_FR["Flood_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Flood_Damage_Estimate"]) : 0;
                this._Fire = drDPD_FR["Fire"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Fire"]) : false;
                this._Fire_Number_Of_Vehicles_Damaged = drDPD_FR["Fire_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Fire_Number_Of_Vehicles_Damaged"]) : 0;
                this._Fire_Damage_Estimate = drDPD_FR["Fire_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Fire_Damage_Estimate"]) : 0;
                this._Wind = drDPD_FR["Wind"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Wind"]) : false;
                this._Wind_Number_Of_Vehicles_Damaged = drDPD_FR["Wind_Number_Of_Vehicles_Damaged"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Wind_Number_Of_Vehicles_Damaged"]) : 0;
                this._Wind_Damage_Estimate = drDPD_FR["Wind_Damage_Estimate"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Wind_Damage_Estimate"]) : 0;
                this._Fraud = drDPD_FR["Fraud"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Fraud"]) : false;
                this._Comments = Convert.ToString(drDPD_FR["Comments"]);
                this._Complete = drDPD_FR["Complete"] != DBNull.Value ? Convert.ToBoolean(drDPD_FR["Complete"]) : false;
                this._Updated_By = drDPD_FR["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["Updated_By"]) : 0;
                this._Updated_Date = drDPD_FR["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drDPD_FR["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = drDPD_FR["FK_SLT_Incident_Review"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR["FK_SLT_Incident_Review"]) : 0;
            }

            else
            {

                this._PK_DPD_FR_ID = -1;
                this._FK_Contact = -1;
                this._DPD_FR_Number = -1;
                this._FK_Loss_Location = -1;
                this._Loss_Address_1 = "";
                this._Loss_Address_2 = "";
                this._Loss_City = "";
                this._Loss_State = "";
                this._Loss_ZipCode = "";
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
                this._Complete = false;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_SLT_Incident_Review = -1;
            }

        }


        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the DPD_FR table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FRInsert");

            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "DPD_FR_Number", DbType.Decimal, this._DPD_FR_Number);
            db.AddInParameter(dbCommand, "FK_Loss_Location", DbType.Decimal, this._FK_Loss_Location);
            db.AddInParameter(dbCommand, "Loss_Address_1", DbType.String, this._Loss_Address_1);
            db.AddInParameter(dbCommand, "Loss_Address_2", DbType.String, this._Loss_Address_2);
            db.AddInParameter(dbCommand, "Loss_City", DbType.String, this._Loss_City);
            db.AddInParameter(dbCommand, "Loss_State", DbType.String, this._Loss_State);
            db.AddInParameter(dbCommand, "Loss_ZipCode", DbType.String, this._Loss_ZipCode);
            db.AddInParameter(dbCommand, "Time_of_Loss", DbType.String, this._Time_of_Loss);
            db.AddInParameter(dbCommand, "Date_Reported_To_Sonic", DbType.DateTime, this._Date_Reported_To_Sonic);
            db.AddInParameter(dbCommand, "Date_Of_Loss", DbType.DateTime, this._Date_Of_Loss);
            db.AddInParameter(dbCommand, "On_Company_Property", DbType.Boolean, this._On_Company_Property);
            db.AddInParameter(dbCommand, "Theft", DbType.Boolean, this._Theft);
            db.AddInParameter(dbCommand, "Theft_Make", DbType.String, this._Theft_Make);
            db.AddInParameter(dbCommand, "Theft_Model", DbType.String, this._Theft_Model);
            db.AddInParameter(dbCommand, "Theft_Year", DbType.Decimal, this._Theft_Year);
            db.AddInParameter(dbCommand, "Theft_VIN", DbType.String, this._Theft_VIN);
            db.AddInParameter(dbCommand, "Vehicle_Invoice_Value", DbType.Decimal, this._Vehicle_Invoice_Value);
            db.AddInParameter(dbCommand, "Vehicle_Recovered", DbType.Boolean, this._Vehicle_Recovered);
            db.AddInParameter(dbCommand, "Theft_Vehicle_Damage_Amount", DbType.Decimal, this._Theft_Vehicle_Damage_Amount);
            db.AddInParameter(dbCommand, "Theft_Dealership_Wish_To_Take_Possession", DbType.Boolean, this._Theft_Dealership_Wish_To_Take_Possession);
            db.AddInParameter(dbCommand, "Partial_Theft", DbType.Boolean, this._Partial_Theft);
            db.AddInParameter(dbCommand, "Partial_Theft_Number_of_Vehicles_Damaged", DbType.Decimal, this._Partial_Theft_Number_of_Vehicles_Damaged);
            db.AddInParameter(dbCommand, "Parial_Theft_Damage_Estimate", DbType.Decimal, this._Parial_Theft_Damage_Estimate);
            db.AddInParameter(dbCommand, "Vandalism", DbType.Boolean, this._Vandalism);
            db.AddInParameter(dbCommand, "Vandalism_Number_of_Vehicles_Damaged", DbType.Decimal, this._Vandalism_Number_of_Vehicles_Damaged);
            db.AddInParameter(dbCommand, "Vandalism_Total_Estimate_of_Damages", DbType.Decimal, this._Vandalism_Total_Estimate_of_Damages);
            db.AddInParameter(dbCommand, "MVA_Single", DbType.Boolean, this._MVA_Single);
            db.AddInParameter(dbCommand, "MVA_Multiple", DbType.Boolean, this._MVA_Multiple);
            db.AddInParameter(dbCommand, "Hail", DbType.Boolean, this._Hail);
            db.AddInParameter(dbCommand, "Hail_Number_Of_Vehicles_Damaged", DbType.Decimal, this._Hail_Number_Of_Vehicles_Damaged);
            db.AddInParameter(dbCommand, "Hail_Damage_Estimate", DbType.Decimal, this._Hail_Damage_Estimate);
            db.AddInParameter(dbCommand, "Flood", DbType.Boolean, this._Flood);
            db.AddInParameter(dbCommand, "Flood_Number_Of_Vehicles_Damaged", DbType.Decimal, this._Flood_Number_Of_Vehicles_Damaged);
            db.AddInParameter(dbCommand, "Flood_Damage_Estimate", DbType.Decimal, this._Flood_Damage_Estimate);
            db.AddInParameter(dbCommand, "Fire", DbType.Boolean, this._Fire);
            db.AddInParameter(dbCommand, "Fire_Number_Of_Vehicles_Damaged", DbType.Decimal, this._Fire_Number_Of_Vehicles_Damaged);
            db.AddInParameter(dbCommand, "Fire_Damage_Estimate", DbType.Decimal, this._Fire_Damage_Estimate);
            db.AddInParameter(dbCommand, "Wind", DbType.Boolean, this._Wind);
            db.AddInParameter(dbCommand, "Wind_Number_Of_Vehicles_Damaged", DbType.Decimal, this._Wind_Number_Of_Vehicles_Damaged);
            db.AddInParameter(dbCommand, "Wind_Damage_Estimate", DbType.Decimal, this._Wind_Damage_Estimate);
            db.AddInParameter(dbCommand, "Fraud", DbType.Boolean, this._Fraud);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the DPD_FR table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_DPD_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FRSelectByPK");

            db.AddInParameter(dbCommand, "PK_DPD_FR_ID", DbType.Decimal, pK_DPD_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the DPD_FR table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FRSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the DPD_FR table by a DPD_FR_Number
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByDPD_FR_Number(decimal dPD_FR_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FRSelectByDPD_FR_Number");

            db.AddInParameter(dbCommand, "DPD_FR_Number", DbType.Decimal, dPD_FR_Number);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the DPD_FR table by a DPD_FR_Number
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPKForClaim(decimal PK_DPD_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FRSelectByPKForClaim");

            db.AddInParameter(dbCommand, "PK_DPD_FR_ID", DbType.Decimal, PK_DPD_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Updates a record in the DPD_FR table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FRUpdate");

            db.AddInParameter(dbCommand, "PK_DPD_FR_ID", DbType.Decimal, this._PK_DPD_FR_ID);
            db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
            db.AddInParameter(dbCommand, "DPD_FR_Number", DbType.Decimal, this._DPD_FR_Number);
            db.AddInParameter(dbCommand, "FK_Loss_Location", DbType.Decimal, this._FK_Loss_Location);
            db.AddInParameter(dbCommand, "Loss_Address_1", DbType.String, this._Loss_Address_1);
            db.AddInParameter(dbCommand, "Loss_Address_2", DbType.String, this._Loss_Address_2);
            db.AddInParameter(dbCommand, "Loss_City", DbType.String, this._Loss_City);
            db.AddInParameter(dbCommand, "Loss_State", DbType.String, this._Loss_State);
            db.AddInParameter(dbCommand, "Loss_ZipCode", DbType.String, this._Loss_ZipCode);
            db.AddInParameter(dbCommand, "Time_of_Loss", DbType.String, this._Time_of_Loss);
            db.AddInParameter(dbCommand, "Date_Reported_To_Sonic", DbType.DateTime, this._Date_Reported_To_Sonic);
            db.AddInParameter(dbCommand, "Date_Of_Loss", DbType.DateTime, this._Date_Of_Loss);
            db.AddInParameter(dbCommand, "On_Company_Property", DbType.Boolean, this._On_Company_Property);
            db.AddInParameter(dbCommand, "Theft", DbType.Boolean, this._Theft);
            if (this._Theft == true)
            {
                db.AddInParameter(dbCommand, "Theft_Make", DbType.String, this._Theft_Make);
                db.AddInParameter(dbCommand, "Theft_Model", DbType.String, this._Theft_Model);
                db.AddInParameter(dbCommand, "Theft_Year", DbType.Decimal, this._Theft_Year);
                db.AddInParameter(dbCommand, "Theft_VIN", DbType.String, this._Theft_VIN);
                db.AddInParameter(dbCommand, "Vehicle_Invoice_Value", DbType.Decimal, this._Vehicle_Invoice_Value);
                db.AddInParameter(dbCommand, "Vehicle_Recovered", DbType.Boolean, this._Vehicle_Recovered);
                db.AddInParameter(dbCommand, "Theft_Vehicle_Damage_Amount", DbType.Decimal, this._Theft_Vehicle_Damage_Amount);
                db.AddInParameter(dbCommand, "Theft_Dealership_Wish_To_Take_Possession", DbType.Boolean, this._Theft_Dealership_Wish_To_Take_Possession);
            }
            else
            {
                db.AddInParameter(dbCommand, "Theft_Make", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "Theft_Model", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "Theft_Year", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "Theft_VIN", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "Vehicle_Invoice_Value", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "Vehicle_Recovered", DbType.Boolean, DBNull.Value);
                db.AddInParameter(dbCommand, "Theft_Vehicle_Damage_Amount", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "Theft_Dealership_Wish_To_Take_Possession", DbType.Boolean, DBNull.Value);
            }
            db.AddInParameter(dbCommand, "Partial_Theft", DbType.Boolean, this._Partial_Theft);
            if (this._Partial_Theft == true)
            {
                db.AddInParameter(dbCommand, "Partial_Theft_Number_of_Vehicles_Damaged", DbType.Decimal, this._Partial_Theft_Number_of_Vehicles_Damaged);
                db.AddInParameter(dbCommand, "Parial_Theft_Damage_Estimate", DbType.Decimal, this._Parial_Theft_Damage_Estimate);
            }
            else
            {
                db.AddInParameter(dbCommand, "Partial_Theft_Number_of_Vehicles_Damaged", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "Parial_Theft_Damage_Estimate", DbType.Decimal, DBNull.Value);
            }
            
            db.AddInParameter(dbCommand, "Vandalism", DbType.Boolean, this._Vandalism);
            if (this._Vandalism == true)
            {
                db.AddInParameter(dbCommand, "Vandalism_Number_of_Vehicles_Damaged", DbType.Decimal, this._Vandalism_Number_of_Vehicles_Damaged);
                db.AddInParameter(dbCommand, "Vandalism_Total_Estimate_of_Damages", DbType.Decimal, this._Vandalism_Total_Estimate_of_Damages);
            }
            else
            {
                db.AddInParameter(dbCommand, "Vandalism_Number_of_Vehicles_Damaged", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "Vandalism_Total_Estimate_of_Damages", DbType.Decimal, DBNull.Value);
            }
            
            db.AddInParameter(dbCommand, "MVA_Single", DbType.Boolean, this._MVA_Single);
            db.AddInParameter(dbCommand, "MVA_Multiple", DbType.Boolean, this._MVA_Multiple);
            db.AddInParameter(dbCommand, "Hail", DbType.Boolean, this._Hail);
            if (this._Hail == true)
            {
                db.AddInParameter(dbCommand, "Hail_Number_Of_Vehicles_Damaged", DbType.Decimal, this._Hail_Number_Of_Vehicles_Damaged);
                db.AddInParameter(dbCommand, "Hail_Damage_Estimate", DbType.Decimal, this._Hail_Damage_Estimate);
            }
            else
            {
                db.AddInParameter(dbCommand, "Hail_Number_Of_Vehicles_Damaged", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "Hail_Damage_Estimate", DbType.Decimal, DBNull.Value);
            }
            
            db.AddInParameter(dbCommand, "Flood", DbType.Boolean, this._Flood);
            if (this._Flood == true)
            {
                db.AddInParameter(dbCommand, "Flood_Number_Of_Vehicles_Damaged", DbType.Decimal, this._Flood_Number_Of_Vehicles_Damaged);
                db.AddInParameter(dbCommand, "Flood_Damage_Estimate", DbType.Decimal, this._Flood_Damage_Estimate);
            }
            else
            {
                db.AddInParameter(dbCommand, "Flood_Number_Of_Vehicles_Damaged", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "Flood_Damage_Estimate", DbType.Decimal, DBNull.Value);
            }
            
            db.AddInParameter(dbCommand, "Fire", DbType.Boolean, this._Fire);
            if (this._Fire == true)
            {
                db.AddInParameter(dbCommand, "Fire_Number_Of_Vehicles_Damaged", DbType.Decimal, this._Fire_Number_Of_Vehicles_Damaged);
                db.AddInParameter(dbCommand, "Fire_Damage_Estimate", DbType.Decimal, this._Fire_Damage_Estimate);
            }
            else
            {
                db.AddInParameter(dbCommand, "Fire_Number_Of_Vehicles_Damaged", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "Fire_Damage_Estimate", DbType.Decimal, DBNull.Value);
            }
            
            db.AddInParameter(dbCommand, "Wind", DbType.Boolean, this._Wind);
            if (this._Wind == true)
            {
                db.AddInParameter(dbCommand, "Wind_Number_Of_Vehicles_Damaged", DbType.Decimal, this._Wind_Number_Of_Vehicles_Damaged);
                db.AddInParameter(dbCommand, "Wind_Damage_Estimate", DbType.Decimal, this._Wind_Damage_Estimate);
            }
            else
            {
                db.AddInParameter(dbCommand, "Wind_Number_Of_Vehicles_Damaged", DbType.Decimal, DBNull.Value);
                db.AddInParameter(dbCommand, "Wind_Damage_Estimate", DbType.Decimal, DBNull.Value);
            }
            
            db.AddInParameter(dbCommand, "Fraud", DbType.Boolean, this._Fraud);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the DPD_FR table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_DPD_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FRDeleteByPK");

            db.AddInParameter(dbCommand, "PK_DPD_FR_ID", DbType.Decimal, pK_DPD_FR_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
