using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for COI_Risk_Profiles table.
    /// </summary>
    public sealed class COI_Risk_Profiles
    {
        #region Fields


        private decimal _PK_COI_Risk_Profile;
        private string _Name;
        private DateTime _DateOfProfile;
        private Nullable<decimal> _Aggregate_Minimum;
        private Nullable<decimal> _Umbrella_Minimum;
        private Nullable<decimal> _General_Occurence_Coverage;
        private Nullable<decimal> _General_Fire_Damage;
        private Nullable<decimal> _General_Medical_Expense;
        private Nullable<decimal> _General_Personal_Advertising_Inju;
        private Nullable<decimal> _General_General_Aggregate;
        private Nullable<decimal> _General_Products_Operations_Produ;
        private Nullable<decimal> _General_Stop_Gap_Coverage;
        private Nullable<decimal> _General_Auto_Coverage;
        private Nullable<decimal> _Auto_Combined_Single_Limit;
        private Nullable<decimal> _Auto_Bodily_Injury_Person;
        private Nullable<decimal> _Auto_Bodily_Injury_Accident;
        private Nullable<decimal> _Auto_Property_Damage;
        private Nullable<decimal> _Excess_Occurrence_Coverage;
        private Nullable<decimal> _Excess_Aggregate_Coverage;
        private Nullable<decimal> _Excess_Retention_Amount;
        private Nullable<decimal> _Excess_Accept_Limits_Coverage;
        private Nullable<decimal> _Excess_Special_Umbrella_Coverage;
        private Nullable<decimal> _WC_Accident;
        private Nullable<decimal> _WC_Disease_Each;
        private Nullable<decimal> _WC_Disease_Limit;
        private Nullable<decimal> _Property_Deductible;
        private Nullable<decimal> _Property_Flood_Coverage;
        private Nullable<decimal> _Property_Wind_Hail_Coverage;
        private Nullable<decimal> _Property_Earth_Movement_Coverage;
        private Nullable<decimal> _Property_BI_Occurrence;
        private Nullable<decimal> _Property_BI_Aggregate;
        private Nullable<decimal> _Property_Building_Occurrence;
        private Nullable<decimal> _Property_Building_Aggregate;
        private Nullable<decimal> _Property_Equipment_Occurrence;
        private Nullable<decimal> _Property_Equipment_Aggregate;
        private Nullable<decimal> _Property_Sign_Occurrence;
        private Nullable<decimal> _Property_SIgn_Aggregate;
        private Nullable<decimal> _Property_Glass_Occurrence;
        private Nullable<decimal> _Property_Glass_Aggregate;
        private Nullable<decimal> _Professional_Occurence;
        private Nullable<decimal> _Professional_Aggregate;
        private Nullable<decimal> _Liquor_Occurence;
        private Nullable<decimal> _Liquor_Aggregate;
        private DateTime _Update_Date;
        private string _Updated_By;
        private string _Boiler_And_Machinery_Required;
        private string _Flood_Required;
        private string _Earthquake_Required;
        #endregion

        #region Properties

       
        /// <summary> 
        /// Gets or sets the PK_COI_Risk_Profile value.
        /// </summary>
        public decimal PK_COI_Risk_Profile
        {
            get { return _PK_COI_Risk_Profile; }
            set { _PK_COI_Risk_Profile = value; }
        }


        /// <summary> 
        /// Gets or sets the Name value.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Gets or sets the DateOfProfile value.
        /// </summary>
        public DateTime DateOfProfile
        {
            get { return _DateOfProfile; }
            set { _DateOfProfile = value; }
        }
        /// <summary> 
        /// Gets or sets the Aggregate_Minimum value.
        /// </summary>
        public Nullable<decimal> Aggregate_Minimum
        {
            get { return _Aggregate_Minimum; }
            set { _Aggregate_Minimum = value; }
        }


        /// <summary> 
        /// Gets or sets the Umbrella_Minimum value.
        /// </summary>
        public Nullable<decimal> Umbrella_Minimum
        {
            get { return _Umbrella_Minimum; }
            set { _Umbrella_Minimum = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Occurence_Coverage value.
        /// </summary>
        public Nullable<decimal> General_Occurence_Coverage
        {
            get { return _General_Occurence_Coverage; }
            set { _General_Occurence_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Fire_Damage value.
        /// </summary>
        public Nullable<decimal> General_Fire_Damage
        {
            get { return _General_Fire_Damage; }
            set { _General_Fire_Damage = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Medical_Expense value.
        /// </summary>
        public Nullable<decimal> General_Medical_Expense
        {
            get { return _General_Medical_Expense; }
            set { _General_Medical_Expense = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Personal_Advertising_Inju value.
        /// </summary>
        public Nullable<decimal> General_Personal_Advertising_Inju
        {
            get { return _General_Personal_Advertising_Inju; }
            set { _General_Personal_Advertising_Inju = value; }
        }


        /// <summary> 
        /// Gets or sets the General_General_Aggregate value.
        /// </summary>
        public Nullable<decimal> General_General_Aggregate
        {
            get { return _General_General_Aggregate; }
            set { _General_General_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Products_Operations_Produ value.
        /// </summary>
        public Nullable<decimal> General_Products_Operations_Produ
        {
            get { return _General_Products_Operations_Produ; }
            set { _General_Products_Operations_Produ = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Stop_Gap_Coverage value.
        /// </summary>
        public Nullable<decimal> General_Stop_Gap_Coverage
        {
            get { return _General_Stop_Gap_Coverage; }
            set { _General_Stop_Gap_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Auto_Coverage value.
        /// </summary>
        public Nullable<decimal> General_Auto_Coverage
        {
            get { return _General_Auto_Coverage; }
            set { _General_Auto_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Auto_Combined_Single_Limit value.
        /// </summary>
        public Nullable<decimal> Auto_Combined_Single_Limit
        {
            get { return _Auto_Combined_Single_Limit; }
            set { _Auto_Combined_Single_Limit = value; }
        }


        /// <summary> 
        /// Gets or sets the Auto_Bodily_Injury_Person value.
        /// </summary>
        public Nullable<decimal> Auto_Bodily_Injury_Person
        {
            get { return _Auto_Bodily_Injury_Person; }
            set { _Auto_Bodily_Injury_Person = value; }
        }


        /// <summary> 
        /// Gets or sets the Auto_Bodily_Injury_Accident value.
        /// </summary>
        public Nullable<decimal> Auto_Bodily_Injury_Accident
        {
            get { return _Auto_Bodily_Injury_Accident; }
            set { _Auto_Bodily_Injury_Accident = value; }
        }


        /// <summary> 
        /// Gets or sets the Auto_Property_Damage value.
        /// </summary>
        public Nullable<decimal> Auto_Property_Damage
        {
            get { return _Auto_Property_Damage; }
            set { _Auto_Property_Damage = value; }
        }


        /// <summary> 
        /// Gets or sets the Excess_Occurrence_Coverage value.
        /// </summary>
        public Nullable<decimal> Excess_Occurrence_Coverage
        {
            get { return _Excess_Occurrence_Coverage; }
            set { _Excess_Occurrence_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Excess_Aggregate_Coverage value.
        /// </summary>
        public Nullable<decimal> Excess_Aggregate_Coverage
        {
            get { return _Excess_Aggregate_Coverage; }
            set { _Excess_Aggregate_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Excess_Retention_Amount value.
        /// </summary>
        public Nullable<decimal> Excess_Retention_Amount
        {
            get { return _Excess_Retention_Amount; }
            set { _Excess_Retention_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Excess_Accept_Limits_Coverage value.
        /// </summary>
        public Nullable<decimal> Excess_Accept_Limits_Coverage
        {
            get { return _Excess_Accept_Limits_Coverage; }
            set { _Excess_Accept_Limits_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Excess_Special_Umbrella_Coverage value.
        /// </summary>
        public Nullable<decimal> Excess_Special_Umbrella_Coverage
        {
            get { return _Excess_Special_Umbrella_Coverage; }
            set { _Excess_Special_Umbrella_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the WC_Accident value.
        /// </summary>
        public Nullable<decimal> WC_Accident
        {
            get { return _WC_Accident; }
            set { _WC_Accident = value; }
        }


        /// <summary> 
        /// Gets or sets the WC_Disease_Each value.
        /// </summary>
        public Nullable<decimal> WC_Disease_Each
        {
            get { return _WC_Disease_Each; }
            set { _WC_Disease_Each = value; }
        }


        /// <summary> 
        /// Gets or sets the WC_Disease_Limit value.
        /// </summary>
        public Nullable<decimal> WC_Disease_Limit
        {
            get { return _WC_Disease_Limit; }
            set { _WC_Disease_Limit = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Deductible value.
        /// </summary>
        public Nullable<decimal> Property_Deductible
        {
            get { return _Property_Deductible; }
            set { _Property_Deductible = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Flood_Coverage value.
        /// </summary>
        public Nullable<decimal> Property_Flood_Coverage
        {
            get { return _Property_Flood_Coverage; }
            set { _Property_Flood_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Wind_Hail_Coverage value.
        /// </summary>
        public Nullable<decimal> Property_Wind_Hail_Coverage
        {
            get { return _Property_Wind_Hail_Coverage; }
            set { _Property_Wind_Hail_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Earth_Movement_Coverage value.
        /// </summary>
        public Nullable<decimal> Property_Earth_Movement_Coverage
        {
            get { return _Property_Earth_Movement_Coverage; }
            set { _Property_Earth_Movement_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_BI_Occurrence value.
        /// </summary>
        public Nullable<decimal> Property_BI_Occurrence
        {
            get { return _Property_BI_Occurrence; }
            set { _Property_BI_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_BI_Aggregate value.
        /// </summary>
        public Nullable<decimal> Property_BI_Aggregate
        {
            get { return _Property_BI_Aggregate; }
            set { _Property_BI_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Building_Occurrence value.
        /// </summary>
        public Nullable<decimal> Property_Building_Occurrence
        {
            get { return _Property_Building_Occurrence; }
            set { _Property_Building_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Building_Aggregate value.
        /// </summary>
        public Nullable<decimal> Property_Building_Aggregate
        {
            get { return _Property_Building_Aggregate; }
            set { _Property_Building_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Equipment_Occurrence value.
        /// </summary>
        public Nullable<decimal> Property_Equipment_Occurrence
        {
            get { return _Property_Equipment_Occurrence; }
            set { _Property_Equipment_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Equipment_Aggregate value.
        /// </summary>
        public Nullable<decimal> Property_Equipment_Aggregate
        {
            get { return _Property_Equipment_Aggregate; }
            set { _Property_Equipment_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Sign_Occurrence value.
        /// </summary>
        public Nullable<decimal> Property_Sign_Occurrence
        {
            get { return _Property_Sign_Occurrence; }
            set { _Property_Sign_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_SIgn_Aggregate value.
        /// </summary>
        public Nullable<decimal> Property_SIgn_Aggregate
        {
            get { return _Property_SIgn_Aggregate; }
            set { _Property_SIgn_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Glass_Occurrence value.
        /// </summary>
        public Nullable<decimal> Property_Glass_Occurrence
        {
            get { return _Property_Glass_Occurrence; }
            set { _Property_Glass_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Glass_Aggregate value.
        /// </summary>
        public Nullable<decimal> Property_Glass_Aggregate
        {
            get { return _Property_Glass_Aggregate; }
            set { _Property_Glass_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Professional_Occurence value.
        /// </summary>
        public Nullable<decimal> Professional_Occurence
        {
            get { return _Professional_Occurence; }
            set { _Professional_Occurence = value; }
        }


        /// <summary> 
        /// Gets or sets the Professional_Aggregate value.
        /// </summary>
        public Nullable<decimal> Professional_Aggregate
        {
            get { return _Professional_Aggregate; }
            set { _Professional_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        public Nullable<decimal> Liquor_Occurence
        {
            get { return _Liquor_Occurence; }
            set { _Liquor_Occurence = value; }
        }

        public Nullable<decimal> Liquor_Aggregate
        {
            get { return _Liquor_Aggregate; }
            set { _Liquor_Aggregate = value; }
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
        /// Gets or sets the Boiler_And_Machinery_Required value.
        /// </summary>
        public string Boiler_And_Machinery_Required
        {
            get { return _Boiler_And_Machinery_Required; }
            set { _Boiler_And_Machinery_Required = value; }
        }

        /// <summary> 
        /// Gets or sets the Flood_Required value.
        /// </summary>
        public string Flood_Required
        {
            get { return _Flood_Required; }
            set { _Flood_Required = value; }
        }

        /// <summary> 
        /// Gets or sets the Earthquake_Required value.
        /// </summary>
        public string Earthquake_Required
        {
            get { return _Earthquake_Required; }
            set { _Earthquake_Required = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_Risk_Profiles class. with the default value.

        /// </summary>
        public COI_Risk_Profiles()
        {

            this._PK_COI_Risk_Profile = -1;
            this._Name = "";
            this._Aggregate_Minimum = null;
            this._Umbrella_Minimum = null;
            this._General_Occurence_Coverage = null;
            this._General_Fire_Damage = null;
            this._General_Medical_Expense = null;
            this._General_Personal_Advertising_Inju = null;
            this._General_General_Aggregate = null;
            this._General_Products_Operations_Produ = null;
            this._General_Stop_Gap_Coverage = null;
            this._General_Auto_Coverage = null;
            this._Auto_Combined_Single_Limit = null;
            this._Auto_Bodily_Injury_Person = null;
            this._Auto_Bodily_Injury_Accident = null;
            this._Auto_Property_Damage = null;
            this._Excess_Occurrence_Coverage = null;
            this._Excess_Aggregate_Coverage = null;
            this._Excess_Retention_Amount = null;
            this._Excess_Accept_Limits_Coverage = null;
            this._Excess_Special_Umbrella_Coverage = null;
            this._WC_Accident = null;
            this._WC_Disease_Each = null;
            this._WC_Disease_Limit = null;
            this._Property_Deductible = null;
            this._Property_Flood_Coverage = null;
            this._Property_Wind_Hail_Coverage = null;
            this._Property_Earth_Movement_Coverage = null;
            this._Property_BI_Occurrence = null;
            this._Property_BI_Aggregate = null;
            this._Property_Building_Occurrence = null;
            this._Property_Building_Aggregate = null;
            this._Property_Equipment_Occurrence = null;
            this._Property_Equipment_Aggregate = null;
            this._Property_Sign_Occurrence = null;
            this._Property_SIgn_Aggregate = null;
            this._Property_Glass_Occurrence = null;
            this._Property_Glass_Aggregate = null;
            this._Professional_Occurence = null;
            this._Professional_Aggregate = null;
            this._Liquor_Occurence = null;
            this._Liquor_Aggregate = null;
            this._Update_Date = DateTime.Today;
            this._Updated_By = "";
            this._Boiler_And_Machinery_Required = "";
            this._Earthquake_Required = "";
            this._Flood_Required = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Risk_Profiles class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Risk_Profiles(decimal PK)
        {
            DataTable dtCOI_Risk_Profiles = Select(PK).Tables[0];

            if (dtCOI_Risk_Profiles.Rows.Count > 0)
            {

                DataRow drCOI_Risk_Profiles = dtCOI_Risk_Profiles.Rows[0];

                this._PK_COI_Risk_Profile = drCOI_Risk_Profiles["PK_COI_Risk_Profile"] != DBNull.Value ? Convert.ToDecimal(drCOI_Risk_Profiles["PK_COI_Risk_Profile"]) : 0;
                this._Name = Convert.ToString(drCOI_Risk_Profiles["Name"]);
                this._DateOfProfile = drCOI_Risk_Profiles["DateOfProfile"] != DBNull.Value ? Convert.ToDateTime(drCOI_Risk_Profiles["DateOfProfile"]) : DateTime.MinValue;
                if (drCOI_Risk_Profiles["Aggregate_Minimum"] != DBNull.Value) this._Aggregate_Minimum = Convert.ToDecimal(drCOI_Risk_Profiles["Aggregate_Minimum"]);
                if (drCOI_Risk_Profiles["Umbrella_Minimum"] != DBNull.Value) this._Umbrella_Minimum = Convert.ToDecimal(drCOI_Risk_Profiles["Umbrella_Minimum"]);
                if (drCOI_Risk_Profiles["General_Occurence_Coverage"] != DBNull.Value) this._General_Occurence_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["General_Occurence_Coverage"]);
                if (drCOI_Risk_Profiles["General_Fire_Damage"] != DBNull.Value) this._General_Fire_Damage = Convert.ToDecimal(drCOI_Risk_Profiles["General_Fire_Damage"]);
                if (drCOI_Risk_Profiles["General_Medical_Expense"] != DBNull.Value) this._General_Medical_Expense = Convert.ToDecimal(drCOI_Risk_Profiles["General_Medical_Expense"]);
                if (drCOI_Risk_Profiles["General_Personal_Advertising_Inju"] != DBNull.Value) this._General_Personal_Advertising_Inju = Convert.ToDecimal(drCOI_Risk_Profiles["General_Personal_Advertising_Inju"]);
                if (drCOI_Risk_Profiles["General_General_Aggregate"] != DBNull.Value) this._General_General_Aggregate = Convert.ToDecimal(drCOI_Risk_Profiles["General_General_Aggregate"]);
                if (drCOI_Risk_Profiles["General_Products_Operations_Produ"] != DBNull.Value) this._General_Products_Operations_Produ = Convert.ToDecimal(drCOI_Risk_Profiles["General_Products_Operations_Produ"]);
                if (drCOI_Risk_Profiles["General_Stop_Gap_Coverage"] != DBNull.Value) this._General_Stop_Gap_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["General_Stop_Gap_Coverage"]);
                if (drCOI_Risk_Profiles["General_Auto_Coverage"] != DBNull.Value) this._General_Auto_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["General_Auto_Coverage"]);
                if (drCOI_Risk_Profiles["Auto_Combined_Single_Limit"] != DBNull.Value) this._Auto_Combined_Single_Limit = Convert.ToDecimal(drCOI_Risk_Profiles["Auto_Combined_Single_Limit"]);
                if (drCOI_Risk_Profiles["Auto_Bodily_Injury_Person"] != DBNull.Value) this._Auto_Bodily_Injury_Person = Convert.ToDecimal(drCOI_Risk_Profiles["Auto_Bodily_Injury_Person"]);
                if (drCOI_Risk_Profiles["Auto_Bodily_Injury_Accident"] != DBNull.Value) this._Auto_Bodily_Injury_Accident = Convert.ToDecimal(drCOI_Risk_Profiles["Auto_Bodily_Injury_Accident"]);
                if (drCOI_Risk_Profiles["Auto_Property_Damage"] != DBNull.Value) this._Auto_Property_Damage = Convert.ToDecimal(drCOI_Risk_Profiles["Auto_Property_Damage"]);
                if (drCOI_Risk_Profiles["Excess_Occurrence_Coverage"] != DBNull.Value) this._Excess_Occurrence_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["Excess_Occurrence_Coverage"]);
                if (drCOI_Risk_Profiles["Excess_Aggregate_Coverage"] != DBNull.Value) this._Excess_Aggregate_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["Excess_Aggregate_Coverage"]);
                if (drCOI_Risk_Profiles["Excess_Retention_Amount"] != DBNull.Value) this._Excess_Retention_Amount = Convert.ToDecimal(drCOI_Risk_Profiles["Excess_Retention_Amount"]);
                if (drCOI_Risk_Profiles["Excess_Accept_Limits_Coverage"] != DBNull.Value) this._Excess_Accept_Limits_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["Excess_Accept_Limits_Coverage"]);
                if (drCOI_Risk_Profiles["Excess_Special_Umbrella_Coverage"] != DBNull.Value) this._Excess_Special_Umbrella_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["Excess_Special_Umbrella_Coverage"]);
                if (drCOI_Risk_Profiles["WC_Accident"] != DBNull.Value) this._WC_Accident = Convert.ToDecimal(drCOI_Risk_Profiles["WC_Accident"]);
                if (drCOI_Risk_Profiles["WC_Disease_Each"] != DBNull.Value) this._WC_Disease_Each = Convert.ToDecimal(drCOI_Risk_Profiles["WC_Disease_Each"]);
                if (drCOI_Risk_Profiles["WC_Disease_Limit"] != DBNull.Value) this._WC_Disease_Limit = Convert.ToDecimal(drCOI_Risk_Profiles["WC_Disease_Limit"]);
                if (drCOI_Risk_Profiles["Property_Deductible"] != DBNull.Value) this._Property_Deductible = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Deductible"]);
                if (drCOI_Risk_Profiles["Property_Flood_Coverage"] != DBNull.Value) this._Property_Flood_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Flood_Coverage"]);
                if (drCOI_Risk_Profiles["Property_Wind_Hail_Coverage"] != DBNull.Value) this._Property_Wind_Hail_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Wind_Hail_Coverage"]);
                if (drCOI_Risk_Profiles["Property_Earth_Movement_Coverage"] != DBNull.Value) this._Property_Earth_Movement_Coverage = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Earth_Movement_Coverage"]);
                if (drCOI_Risk_Profiles["Property_BI_Occurrence"] != DBNull.Value) this._Property_BI_Occurrence = Convert.ToDecimal(drCOI_Risk_Profiles["Property_BI_Occurrence"]);
                if (drCOI_Risk_Profiles["Property_BI_Aggregate"] != DBNull.Value) this._Property_BI_Aggregate = Convert.ToDecimal(drCOI_Risk_Profiles["Property_BI_Aggregate"]);
                if (drCOI_Risk_Profiles["Property_Building_Occurrence"] != DBNull.Value) this._Property_Building_Occurrence = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Building_Occurrence"]);
                if (drCOI_Risk_Profiles["Property_Building_Aggregate"] != DBNull.Value) this._Property_Building_Aggregate = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Building_Aggregate"]);
                if (drCOI_Risk_Profiles["Property_Equipment_Occurrence"] != DBNull.Value) this._Property_Equipment_Occurrence = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Equipment_Occurrence"]);
                if (drCOI_Risk_Profiles["Property_Equipment_Aggregate"] != DBNull.Value) this._Property_Equipment_Aggregate = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Equipment_Aggregate"]);
                if (drCOI_Risk_Profiles["Property_Sign_Occurrence"] != DBNull.Value) this._Property_Sign_Occurrence = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Sign_Occurrence"]);
                if (drCOI_Risk_Profiles["Property_SIgn_Aggregate"] != DBNull.Value) this._Property_SIgn_Aggregate = Convert.ToDecimal(drCOI_Risk_Profiles["Property_SIgn_Aggregate"]);
                if (drCOI_Risk_Profiles["Property_Glass_Occurrence"] != DBNull.Value) this._Property_Glass_Occurrence = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Glass_Occurrence"]);
                if (drCOI_Risk_Profiles["Property_Glass_Aggregate"] != DBNull.Value) this._Property_Glass_Aggregate = Convert.ToDecimal(drCOI_Risk_Profiles["Property_Glass_Aggregate"]);
                if (drCOI_Risk_Profiles["Professional_Occurence"] != DBNull.Value) this._Professional_Occurence = Convert.ToDecimal(drCOI_Risk_Profiles["Professional_Occurence"]);
                if (drCOI_Risk_Profiles["Professional_Aggregate"] != DBNull.Value) this._Professional_Aggregate = Convert.ToDecimal(drCOI_Risk_Profiles["Professional_Aggregate"]);
                if (drCOI_Risk_Profiles["Liquor_Occurence"] != DBNull.Value) this._Liquor_Occurence = Convert.ToDecimal(drCOI_Risk_Profiles["Liquor_Occurence"]);
                if (drCOI_Risk_Profiles["Liquor_Aggregate"] != DBNull.Value) this._Liquor_Aggregate = Convert.ToDecimal(drCOI_Risk_Profiles["Liquor_Aggregate"]);

                this._Boiler_And_Machinery_Required = Convert.ToString(drCOI_Risk_Profiles["Boiler_And_Machinery_Required"]);
                this._Earthquake_Required = Convert.ToString(drCOI_Risk_Profiles["Earthquake_Required"]);
                this._Flood_Required = Convert.ToString(drCOI_Risk_Profiles["Flood_Required"]);
                this._Update_Date = drCOI_Risk_Profiles["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Risk_Profiles["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Updated_By = Convert.ToString(drCOI_Risk_Profiles["Updated_By"]);

            }

            else
            {

                new COI_Risk_Profiles();
            }

        }



        #endregion

        #region "Methods"
        /// <summary>
        /// Inserts a record into the COI_Risk_Profiles table.
        /// <summary>
        /// <param name="name"></param>
        /// <param name="aggregate_Minimum"></param>
        /// <param name="umbrella_Minimum"></param>
        /// <param name="general_Occurence_Coverage"></param>
        /// <param name="general_Fire_Damage"></param>
        /// <param name="general_Medical_Expense"></param>
        /// <param name="general_Personal_Advertising_Inju"></param>
        /// <param name="general_General_Aggregate"></param>
        /// <param name="general_Products_Operations_Produ"></param>
        /// <param name="general_Stop_Gap_Coverage"></param>
        /// <param name="general_Auto_Coverage"></param>
        /// <param name="auto_Combined_Single_Limit"></param>
        /// <param name="auto_Bodily_Injury_Person"></param>
        /// <param name="auto_Bodily_Injury_Accident"></param>
        /// <param name="auto_Property_Damage"></param>
        /// <param name="excess_Occurrence_Coverage"></param>
        /// <param name="excess_Aggregate_Coverage"></param>
        /// <param name="excess_Retention_Amount"></param>
        /// <param name="excess_Accept_Limits_Coverage"></param>
        /// <param name="excess_Special_Umbrella_Coverage"></param>
        /// <param name="wC_Accident"></param>
        /// <param name="wC_Disease_Each"></param>
        /// <param name="wC_Disease_Limit"></param>
        /// <param name="property_Deductible"></param>
        /// <param name="property_Flood_Coverage"></param>
        /// <param name="property_Wind_Hail_Coverage"></param>
        /// <param name="property_Earth_Movement_Coverage"></param>
        /// <param name="property_BI_Occurrence"></param>
        /// <param name="property_BI_Aggregate"></param>
        /// <param name="property_Building_Occurrence"></param>
        /// <param name="property_Building_Aggregate"></param>
        /// <param name="property_Equipment_Occurrence"></param>
        /// <param name="property_Equipment_Aggregate"></param>
        /// <param name="property_Sign_Occurrence"></param>
        /// <param name="property_SIgn_Aggregate"></param>
        /// <param name="property_Glass_Occurrence"></param>
        /// <param name="property_Glass_Aggregate"></param>
        /// <param name="professional_Occurence"></param>
        /// <param name="professional_Aggregate"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        /// <returns></returns>
        public static int Insert(string name, DateTime dateOfProfile, Nullable<decimal> aggregate_Minimum, Nullable<decimal> umbrella_Minimum, Nullable<decimal> general_Occurence_Coverage, Nullable<decimal> general_Fire_Damage, Nullable<decimal> general_Medical_Expense, Nullable<decimal> general_Personal_Advertising_Inju, Nullable<decimal> general_General_Aggregate, Nullable<decimal> general_Products_Operations_Produ, Nullable<decimal> general_Stop_Gap_Coverage, Nullable<decimal> general_Auto_Coverage, Nullable<decimal> auto_Combined_Single_Limit, Nullable<decimal> auto_Bodily_Injury_Person, Nullable<decimal> auto_Bodily_Injury_Accident, Nullable<decimal> auto_Property_Damage, Nullable<decimal> excess_Occurrence_Coverage, Nullable<decimal> excess_Aggregate_Coverage, Nullable<decimal> excess_Retention_Amount, Nullable<decimal> excess_Accept_Limits_Coverage, Nullable<decimal> excess_Special_Umbrella_Coverage, Nullable<decimal> wC_Accident, Nullable<decimal> wC_Disease_Each, Nullable<decimal> wC_Disease_Limit, Nullable<decimal> property_Deductible, Nullable<decimal> property_Flood_Coverage, Nullable<decimal> property_Wind_Hail_Coverage, Nullable<decimal> property_Earth_Movement_Coverage, Nullable<decimal> property_BI_Occurrence, Nullable<decimal> property_BI_Aggregate, Nullable<decimal> property_Building_Occurrence, Nullable<decimal> property_Building_Aggregate, Nullable<decimal> property_Equipment_Occurrence, Nullable<decimal> property_Equipment_Aggregate, Nullable<decimal> property_Sign_Occurrence, Nullable<decimal> property_SIgn_Aggregate, Nullable<decimal> property_Glass_Occurrence, Nullable<decimal> property_Glass_Aggregate, Nullable<decimal> professional_Occurence, Nullable<decimal> professional_Aggregate, Nullable<decimal> liquor_Occurence, Nullable<decimal> liquor_Aggregate, DateTime update_Date, string updated_By, string boiler_And_Machinery_Required, string earthquake_Required, string flood_Required)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Risk_ProfilesInsert");

            db.AddInParameter(dbCommand, "Name", DbType.String, name);
            db.AddInParameter(dbCommand, "DateOfProfile", DbType.DateTime, dateOfProfile);
            db.AddInParameter(dbCommand, "Aggregate_Minimum", DbType.Decimal, aggregate_Minimum);
            db.AddInParameter(dbCommand, "Umbrella_Minimum", DbType.Decimal, umbrella_Minimum);
            db.AddInParameter(dbCommand, "General_Occurence_Coverage", DbType.Decimal, general_Occurence_Coverage);
            db.AddInParameter(dbCommand, "General_Fire_Damage", DbType.Decimal, general_Fire_Damage);
            db.AddInParameter(dbCommand, "General_Medical_Expense", DbType.Decimal, general_Medical_Expense);
            db.AddInParameter(dbCommand, "General_Personal_Advertising_Inju", DbType.Decimal, general_Personal_Advertising_Inju);
            db.AddInParameter(dbCommand, "General_General_Aggregate", DbType.Decimal, general_General_Aggregate);
            db.AddInParameter(dbCommand, "General_Products_Operations_Produ", DbType.Decimal, general_Products_Operations_Produ);
            db.AddInParameter(dbCommand, "General_Stop_Gap_Coverage", DbType.Decimal, general_Stop_Gap_Coverage);
            db.AddInParameter(dbCommand, "General_Auto_Coverage", DbType.Decimal, general_Auto_Coverage);
            db.AddInParameter(dbCommand, "Auto_Combined_Single_Limit", DbType.Decimal, auto_Combined_Single_Limit);
            db.AddInParameter(dbCommand, "Auto_Bodily_Injury_Person", DbType.Decimal, auto_Bodily_Injury_Person);
            db.AddInParameter(dbCommand, "Auto_Bodily_Injury_Accident", DbType.Decimal, auto_Bodily_Injury_Accident);
            db.AddInParameter(dbCommand, "Auto_Property_Damage", DbType.Decimal, auto_Property_Damage);
            db.AddInParameter(dbCommand, "Excess_Occurrence_Coverage", DbType.Decimal, excess_Occurrence_Coverage);
            db.AddInParameter(dbCommand, "Excess_Aggregate_Coverage", DbType.Decimal, excess_Aggregate_Coverage);
            db.AddInParameter(dbCommand, "Excess_Retention_Amount", DbType.Decimal, excess_Retention_Amount);
            db.AddInParameter(dbCommand, "Excess_Accept_Limits_Coverage", DbType.Decimal, excess_Accept_Limits_Coverage);
            db.AddInParameter(dbCommand, "Excess_Special_Umbrella_Coverage", DbType.Decimal, excess_Special_Umbrella_Coverage);
            db.AddInParameter(dbCommand, "WC_Accident", DbType.Decimal, wC_Accident);
            db.AddInParameter(dbCommand, "WC_Disease_Each", DbType.Decimal, wC_Disease_Each);
            db.AddInParameter(dbCommand, "WC_Disease_Limit", DbType.Decimal, wC_Disease_Limit);
            db.AddInParameter(dbCommand, "Property_Deductible", DbType.Decimal, property_Deductible);
            db.AddInParameter(dbCommand, "Property_Flood_Coverage", DbType.Decimal, property_Flood_Coverage);
            db.AddInParameter(dbCommand, "Property_Wind_Hail_Coverage", DbType.Decimal, property_Wind_Hail_Coverage);
            db.AddInParameter(dbCommand, "Property_Earth_Movement_Coverage", DbType.Decimal, property_Earth_Movement_Coverage);
            db.AddInParameter(dbCommand, "Property_BI_Occurrence", DbType.Decimal, property_BI_Occurrence);
            db.AddInParameter(dbCommand, "Property_BI_Aggregate", DbType.Decimal, property_BI_Aggregate);
            db.AddInParameter(dbCommand, "Property_Building_Occurrence", DbType.Decimal, property_Building_Occurrence);
            db.AddInParameter(dbCommand, "Property_Building_Aggregate", DbType.Decimal, property_Building_Aggregate);
            db.AddInParameter(dbCommand, "Property_Equipment_Occurrence", DbType.Decimal, property_Equipment_Occurrence);
            db.AddInParameter(dbCommand, "Property_Equipment_Aggregate", DbType.Decimal, property_Equipment_Aggregate);
            db.AddInParameter(dbCommand, "Property_Sign_Occurrence", DbType.Decimal, property_Sign_Occurrence);
            db.AddInParameter(dbCommand, "Property_SIgn_Aggregate", DbType.Decimal, property_SIgn_Aggregate);
            db.AddInParameter(dbCommand, "Property_Glass_Occurrence", DbType.Decimal, property_Glass_Occurrence);
            db.AddInParameter(dbCommand, "Property_Glass_Aggregate", DbType.Decimal, property_Glass_Aggregate);
            db.AddInParameter(dbCommand, "Professional_Occurence", DbType.Decimal, professional_Occurence);
            db.AddInParameter(dbCommand, "Professional_Aggregate", DbType.Decimal, professional_Aggregate);
            db.AddInParameter(dbCommand, "Liquor_Occurence", DbType.Decimal, liquor_Occurence);
            db.AddInParameter(dbCommand, "Liquor_Aggregate", DbType.Decimal, liquor_Aggregate);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Boiler_And_Machinery_Required", DbType.String, boiler_And_Machinery_Required);
            db.AddInParameter(dbCommand, "Earthquake_Required", DbType.String, earthquake_Required);
            db.AddInParameter(dbCommand, "Flood_Required", DbType.String, flood_Required);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the COI_Risk_Profiles table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pK_COI_Risk_Profile)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Risk_ProfilesSelect");

            db.AddInParameter(dbCommand, "PK_COI_Risk_Profile", DbType.Decimal, pK_COI_Risk_Profile);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the COI_Risk_Profiles table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Risk_ProfilesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the COI_Risk_Profiles table.
        /// <summary>
        /// <param name="pK_COI_Risk_Profile"></param>
        /// <param name="name"></param>
        /// <param name="aggregate_Minimum"></param>
        /// <param name="umbrella_Minimum"></param>
        /// <param name="general_Occurence_Coverage"></param>
        /// <param name="general_Fire_Damage"></param>
        /// <param name="general_Medical_Expense"></param>
        /// <param name="general_Personal_Advertising_Inju"></param>
        /// <param name="general_General_Aggregate"></param>
        /// <param name="general_Products_Operations_Produ"></param>
        /// <param name="general_Stop_Gap_Coverage"></param>
        /// <param name="general_Auto_Coverage"></param>
        /// <param name="auto_Combined_Single_Limit"></param>
        /// <param name="auto_Bodily_Injury_Person"></param>
        /// <param name="auto_Bodily_Injury_Accident"></param>
        /// <param name="auto_Property_Damage"></param>
        /// <param name="excess_Occurrence_Coverage"></param>
        /// <param name="excess_Aggregate_Coverage"></param>
        /// <param name="excess_Retention_Amount"></param>
        /// <param name="excess_Accept_Limits_Coverage"></param>
        /// <param name="excess_Special_Umbrella_Coverage"></param>
        /// <param name="wC_Accident"></param>
        /// <param name="wC_Disease_Each"></param>
        /// <param name="wC_Disease_Limit"></param>
        /// <param name="property_Deductible"></param>
        /// <param name="property_Flood_Coverage"></param>
        /// <param name="property_Wind_Hail_Coverage"></param>
        /// <param name="property_Earth_Movement_Coverage"></param>
        /// <param name="property_BI_Occurrence"></param>
        /// <param name="property_BI_Aggregate"></param>
        /// <param name="property_Building_Occurrence"></param>
        /// <param name="property_Building_Aggregate"></param>
        /// <param name="property_Equipment_Occurrence"></param>
        /// <param name="property_Equipment_Aggregate"></param>
        /// <param name="property_Sign_Occurrence"></param>
        /// <param name="property_SIgn_Aggregate"></param>
        /// <param name="property_Glass_Occurrence"></param>
        /// <param name="property_Glass_Aggregate"></param>
        /// <param name="professional_Occurence"></param>
        /// <param name="professional_Aggregate"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        public static void Update(decimal pK_COI_Risk_Profile, string name, DateTime dateofProfile, Nullable<decimal> aggregate_Minimum, Nullable<decimal> umbrella_Minimum, Nullable<decimal> general_Occurence_Coverage, Nullable<decimal> general_Fire_Damage, Nullable<decimal> general_Medical_Expense, Nullable<decimal> general_Personal_Advertising_Inju, Nullable<decimal> general_General_Aggregate, Nullable<decimal> general_Products_Operations_Produ, Nullable<decimal> general_Stop_Gap_Coverage, Nullable<decimal> general_Auto_Coverage, Nullable<decimal> auto_Combined_Single_Limit, Nullable<decimal> auto_Bodily_Injury_Person, Nullable<decimal> auto_Bodily_Injury_Accident, Nullable<decimal> auto_Property_Damage, Nullable<decimal> excess_Occurrence_Coverage, Nullable<decimal> excess_Aggregate_Coverage, Nullable<decimal> excess_Retention_Amount, Nullable<decimal> excess_Accept_Limits_Coverage, Nullable<decimal> excess_Special_Umbrella_Coverage, Nullable<decimal> wC_Accident, Nullable<decimal> wC_Disease_Each, Nullable<decimal> wC_Disease_Limit, Nullable<decimal> property_Deductible, Nullable<decimal> property_Flood_Coverage, Nullable<decimal> property_Wind_Hail_Coverage, Nullable<decimal> property_Earth_Movement_Coverage, Nullable<decimal> property_BI_Occurrence, Nullable<decimal> property_BI_Aggregate, Nullable<decimal> property_Building_Occurrence, Nullable<decimal> property_Building_Aggregate, Nullable<decimal> property_Equipment_Occurrence, Nullable<decimal> property_Equipment_Aggregate, Nullable<decimal> property_Sign_Occurrence, Nullable<decimal> property_SIgn_Aggregate, Nullable<decimal> property_Glass_Occurrence, Nullable<decimal> property_Glass_Aggregate, Nullable<decimal> professional_Occurence, Nullable<decimal> professional_Aggregate, Nullable<decimal> liquor_Occurence, Nullable<decimal> liquor_Aggregate, DateTime update_Date, string updated_By, string boiler_And_Machinery_Required, string earthquake_Required, string flood_Required)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Risk_ProfilesUpdate");

            db.AddInParameter(dbCommand, "PK_COI_Risk_Profile", DbType.Decimal, pK_COI_Risk_Profile);
            db.AddInParameter(dbCommand, "Name", DbType.String, name);
            db.AddInParameter(dbCommand, "DateOfProfile", DbType.DateTime, dateofProfile);
            db.AddInParameter(dbCommand, "Aggregate_Minimum", DbType.Decimal, aggregate_Minimum);
            db.AddInParameter(dbCommand, "Umbrella_Minimum", DbType.Decimal, umbrella_Minimum);
            db.AddInParameter(dbCommand, "General_Occurence_Coverage", DbType.Decimal, general_Occurence_Coverage);
            db.AddInParameter(dbCommand, "General_Fire_Damage", DbType.Decimal, general_Fire_Damage);
            db.AddInParameter(dbCommand, "General_Medical_Expense", DbType.Decimal, general_Medical_Expense);
            db.AddInParameter(dbCommand, "General_Personal_Advertising_Inju", DbType.Decimal, general_Personal_Advertising_Inju);
            db.AddInParameter(dbCommand, "General_General_Aggregate", DbType.Decimal, general_General_Aggregate);
            db.AddInParameter(dbCommand, "General_Products_Operations_Produ", DbType.Decimal, general_Products_Operations_Produ);
            db.AddInParameter(dbCommand, "General_Stop_Gap_Coverage", DbType.Decimal, general_Stop_Gap_Coverage);
            db.AddInParameter(dbCommand, "General_Auto_Coverage", DbType.Decimal, general_Auto_Coverage);
            db.AddInParameter(dbCommand, "Auto_Combined_Single_Limit", DbType.Decimal, auto_Combined_Single_Limit);
            db.AddInParameter(dbCommand, "Auto_Bodily_Injury_Person", DbType.Decimal, auto_Bodily_Injury_Person);
            db.AddInParameter(dbCommand, "Auto_Bodily_Injury_Accident", DbType.Decimal, auto_Bodily_Injury_Accident);
            db.AddInParameter(dbCommand, "Auto_Property_Damage", DbType.Decimal, auto_Property_Damage);
            db.AddInParameter(dbCommand, "Excess_Occurrence_Coverage", DbType.Decimal, excess_Occurrence_Coverage);
            db.AddInParameter(dbCommand, "Excess_Aggregate_Coverage", DbType.Decimal, excess_Aggregate_Coverage);
            db.AddInParameter(dbCommand, "Excess_Retention_Amount", DbType.Decimal, excess_Retention_Amount);
            db.AddInParameter(dbCommand, "Excess_Accept_Limits_Coverage", DbType.Decimal, excess_Accept_Limits_Coverage);
            db.AddInParameter(dbCommand, "Excess_Special_Umbrella_Coverage", DbType.Decimal, excess_Special_Umbrella_Coverage);
            db.AddInParameter(dbCommand, "WC_Accident", DbType.Decimal, wC_Accident);
            db.AddInParameter(dbCommand, "WC_Disease_Each", DbType.Decimal, wC_Disease_Each);
            db.AddInParameter(dbCommand, "WC_Disease_Limit", DbType.Decimal, wC_Disease_Limit);
            db.AddInParameter(dbCommand, "Property_Deductible", DbType.Decimal, property_Deductible);
            db.AddInParameter(dbCommand, "Property_Flood_Coverage", DbType.Decimal, property_Flood_Coverage);
            db.AddInParameter(dbCommand, "Property_Wind_Hail_Coverage", DbType.Decimal, property_Wind_Hail_Coverage);
            db.AddInParameter(dbCommand, "Property_Earth_Movement_Coverage", DbType.Decimal, property_Earth_Movement_Coverage);
            db.AddInParameter(dbCommand, "Property_BI_Occurrence", DbType.Decimal, property_BI_Occurrence);
            db.AddInParameter(dbCommand, "Property_BI_Aggregate", DbType.Decimal, property_BI_Aggregate);
            db.AddInParameter(dbCommand, "Property_Building_Occurrence", DbType.Decimal, property_Building_Occurrence);
            db.AddInParameter(dbCommand, "Property_Building_Aggregate", DbType.Decimal, property_Building_Aggregate);
            db.AddInParameter(dbCommand, "Property_Equipment_Occurrence", DbType.Decimal, property_Equipment_Occurrence);
            db.AddInParameter(dbCommand, "Property_Equipment_Aggregate", DbType.Decimal, property_Equipment_Aggregate);
            db.AddInParameter(dbCommand, "Property_Sign_Occurrence", DbType.Decimal, property_Sign_Occurrence);
            db.AddInParameter(dbCommand, "Property_SIgn_Aggregate", DbType.Decimal, property_SIgn_Aggregate);
            db.AddInParameter(dbCommand, "Property_Glass_Occurrence", DbType.Decimal, property_Glass_Occurrence);
            db.AddInParameter(dbCommand, "Property_Glass_Aggregate", DbType.Decimal, property_Glass_Aggregate);
            db.AddInParameter(dbCommand, "Professional_Occurence", DbType.Decimal, professional_Occurence);
            db.AddInParameter(dbCommand, "Professional_Aggregate", DbType.Decimal, professional_Aggregate);
            db.AddInParameter(dbCommand, "Liquor_Occurence", DbType.Decimal, liquor_Occurence);
            db.AddInParameter(dbCommand, "Liquor_Aggregate", DbType.Decimal, liquor_Aggregate);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Boiler_And_Machinery_Required", DbType.String, boiler_And_Machinery_Required);
            db.AddInParameter(dbCommand, "Earthquake_Required", DbType.String, earthquake_Required);
            db.AddInParameter(dbCommand, "Flood_Required", DbType.String, flood_Required);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the COI_Risk_Profiles table by a composite primary key.
        /// <summary>
        public static void Delete(decimal pK_COI_Risk_Profile)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Risk_ProfilesDelete");

            db.AddInParameter(dbCommand, "PK_COI_Risk_Profile", DbType.Decimal, pK_COI_Risk_Profile);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects the records by page number and page size
        /// </summary>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public static DataSet SelectByPaging(int intPageNo, int intPageSize, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Risk_ProfileSelectByPaging_New");
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
            return Insert(_Name, _DateOfProfile, _Aggregate_Minimum, _Umbrella_Minimum, _General_Occurence_Coverage,
                _General_Fire_Damage, _General_Medical_Expense, _General_Personal_Advertising_Inju, _General_General_Aggregate,
                _General_Products_Operations_Produ, _General_Stop_Gap_Coverage, _General_Auto_Coverage, _Auto_Combined_Single_Limit,
                _Auto_Bodily_Injury_Person, _Auto_Bodily_Injury_Accident, _Auto_Property_Damage, _Excess_Occurrence_Coverage, _Excess_Aggregate_Coverage,
                _Excess_Retention_Amount, _Excess_Accept_Limits_Coverage, _Excess_Special_Umbrella_Coverage, _WC_Accident, _WC_Disease_Each,
                _WC_Disease_Limit, _Property_Deductible, _Property_Flood_Coverage, _Property_Wind_Hail_Coverage, _Property_Earth_Movement_Coverage,
                _Property_BI_Occurrence, _Property_BI_Aggregate, _Property_Building_Occurrence, _Property_Building_Aggregate, _Property_Equipment_Occurrence,
                _Property_Equipment_Aggregate, _Property_Sign_Occurrence, _Property_SIgn_Aggregate, _Property_Glass_Occurrence, _Property_Glass_Aggregate,
                _Professional_Occurence, _Professional_Aggregate, _Liquor_Occurence, _Liquor_Aggregate, _Update_Date, _Updated_By, _Boiler_And_Machinery_Required,_Earthquake_Required,_Flood_Required);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_Risk_Profile, _Name, _DateOfProfile, _Aggregate_Minimum, _Umbrella_Minimum, _General_Occurence_Coverage,
                _General_Fire_Damage, _General_Medical_Expense, _General_Personal_Advertising_Inju, _General_General_Aggregate,
                _General_Products_Operations_Produ, _General_Stop_Gap_Coverage, _General_Auto_Coverage, _Auto_Combined_Single_Limit,
                _Auto_Bodily_Injury_Person, _Auto_Bodily_Injury_Accident, _Auto_Property_Damage, _Excess_Occurrence_Coverage, _Excess_Aggregate_Coverage,
                _Excess_Retention_Amount, _Excess_Accept_Limits_Coverage, _Excess_Special_Umbrella_Coverage, _WC_Accident, _WC_Disease_Each,
                _WC_Disease_Limit, _Property_Deductible, _Property_Flood_Coverage, _Property_Wind_Hail_Coverage, _Property_Earth_Movement_Coverage,
                _Property_BI_Occurrence, _Property_BI_Aggregate, _Property_Building_Occurrence, _Property_Building_Aggregate, _Property_Equipment_Occurrence,
                _Property_Equipment_Aggregate, _Property_Sign_Occurrence, _Property_SIgn_Aggregate, _Property_Glass_Occurrence, _Property_Glass_Aggregate,
                _Professional_Occurence, _Professional_Aggregate, _Liquor_Occurence, _Liquor_Aggregate, _Update_Date, _Updated_By, _Boiler_And_Machinery_Required,_Earthquake_Required,_Flood_Required);
        }

        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="strName"></param>
        /// <returns>DataSet</returns>
        public static DataSet Search(string strName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Risk_ProfilesSearch");
            db.AddInParameter(dbCommand, "Name", DbType.String, strName);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
