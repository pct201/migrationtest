using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for COI_Locations table.
    /// </summary>
    public sealed class COI_Locations
    {
        #region Fields


        private decimal _PK_COI_Locations;
        private decimal _FK_Table_Name;
        private string _Table_Name;
        private string _Sprinkler;
        private string _Alarm;
        private DateTime _Lease_Expiration_Tenant;
        private DateTime _Lease_Expiration_SubTenant;
        private DateTime _Date_Purchased;
        private DateTime _Date_Leased;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;
        private string _Name;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private decimal _FK_State;
        private string _Zip_Code;
        private string _Contact_Last_Name;
        private string _Contact_First_Name;
        private string _Contact_Title;
        private string _Contact_Phone;
        private string _Contact_Fax;
        private string _Contact_EMail;
        private decimal _FK_County;
        private string _Location_Number;
        private Nullable<decimal> _Square_Feet;
        private DateTime _Open_Date;
        private DateTime _Close_Date;
        private DateTime _Assign_Date;
        private string _Service_Manager;
        private string _Building_Type;
        private decimal _FK_COI_Region;
        private decimal _FK_COI_District;
        private decimal _FK_COI_Division;
        private decimal _FK_COI_Tier;
        private string _Blanket_Coverage;
        private Nullable<decimal> _Building_Value;
        private Nullable<decimal> _Equipment_Value;
        private Nullable<decimal> _Signage_Value;
        private Nullable<decimal> _Glass_Value;
        private Nullable<decimal> _Deductible;
        private string _Loss_Of_Income_ALS;
        private Nullable<decimal> _Loss_Of_Income_Months;
        private Nullable<decimal> _Percentage;
        private Nullable<decimal> _Flood_Coverage;
        private Nullable<decimal> _Wind_Hail_Coverage;
        private Nullable<decimal> _Earth_Movement_Coverage;
        private Nullable<decimal> _BI_Occurrence;
        private Nullable<decimal> _BI_Aggregate;
        private Nullable<decimal> _Building_Occurrence;
        private Nullable<decimal> _Building_Aggregate;
        private Nullable<decimal> _Building_Deductible;
        private Nullable<decimal> _Equipment_Occurrence;
        private Nullable<decimal> _Equipment_Aggregate;
        private Nullable<decimal> _Equipment_Deductible;
        private Nullable<decimal> _Sign_Occurrence;
        private Nullable<decimal> _SIgn_Aggregate;
        private Nullable<decimal> _Glass_Occurrence;
        private Nullable<decimal> _Glass_Aggregate;
        private string _Ordinance_Law;
        private string _Subrogation_Waiver;
        private string _Perils_Insured_Form;
        private string _Property_On_Acord;
        private string _Certificate_Received;
        private string _Replacement_Costs;
        private string _Earthquake_Zone;
        private string _Glass_ACV;
        private string _Leased_Property;
        private string _Leased_Building_Limit_Accepted;
        private string _B_I_Included_In_Verification;
        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Locations value.
        /// </summary>
        public decimal PK_COI_Locations
        {
            get { return _PK_COI_Locations; }
            set { _PK_COI_Locations = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Table_Name value.
        /// </summary>
        public decimal FK_Table_Name
        {
            get { return _FK_Table_Name; }
            set { _FK_Table_Name = value; }
        }

        /// <summary> 
        /// Gets or sets the FK_Table_Name value.
        /// </summary>
        public string Table_Name
        {
            get { return _Table_Name; }
            set { _Table_Name = value; }
        }
        /// <summary> 
        /// Gets or sets the Sprinkler value.
        /// </summary>
        public string Sprinkler
        {
            get { return _Sprinkler; }
            set { _Sprinkler = value; }
        }


        /// <summary> 
        /// Gets or sets the Alarm value.
        /// </summary>
        public string Alarm
        {
            get { return _Alarm; }
            set { _Alarm = value; }
        }


        /// <summary> 
        /// Gets or sets the Lease_Expiration_Tenant value.
        /// </summary>
        public DateTime Lease_Expiration_Tenant
        {
            get { return _Lease_Expiration_Tenant; }
            set { _Lease_Expiration_Tenant = value; }
        }


        /// <summary> 
        /// Gets or sets the Lease_Expiration_SubTenant value.
        /// </summary>
        public DateTime Lease_Expiration_SubTenant
        {
            get { return _Lease_Expiration_SubTenant; }
            set { _Lease_Expiration_SubTenant = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Purchased value.
        /// </summary>
        public DateTime Date_Purchased
        {
            get { return _Date_Purchased; }
            set { _Date_Purchased = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Leased value.
        /// </summary>
        public DateTime Date_Leased
        {
            get { return _Date_Leased; }
            set { _Date_Leased = value; }
        }


        /// <summary> 
        /// Gets or sets the Notes value.
        /// </summary>
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }


        /// <summary> 
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
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
        /// Gets or sets the Name value.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
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
        /// Gets or sets the FK_State value.
        /// </summary>
        public decimal FK_State
        {
            get { return _FK_State; }
            set { _FK_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Zip_Code value.
        /// </summary>
        public string Zip_Code
        {
            get { return _Zip_Code; }
            set { _Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Last_Name value.
        /// </summary>
        public string Contact_Last_Name
        {
            get { return _Contact_Last_Name; }
            set { _Contact_Last_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_First_Name value.
        /// </summary>
        public string Contact_First_Name
        {
            get { return _Contact_First_Name; }
            set { _Contact_First_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Title value.
        /// </summary>
        public string Contact_Title
        {
            get { return _Contact_Title; }
            set { _Contact_Title = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Phone value.
        /// </summary>
        public string Contact_Phone
        {
            get { return _Contact_Phone; }
            set { _Contact_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Fax value.
        /// </summary>
        public string Contact_Fax
        {
            get { return _Contact_Fax; }
            set { _Contact_Fax = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_EMail value.
        /// </summary>
        public string Contact_EMail
        {
            get { return _Contact_EMail; }
            set { _Contact_EMail = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_County value.
        /// </summary>
        public decimal FK_County
        {
            get { return _FK_County; }
            set { _FK_County = value; }
        }


        /// <summary> 
        /// Gets or sets the Location_Number value.
        /// </summary>
        public string Location_Number
        {
            get { return _Location_Number; }
            set { _Location_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Square_Feet value.
        /// </summary>
        public Nullable<decimal> Square_Feet
        {
            get { return _Square_Feet; }
            set { _Square_Feet = value; }
        }


        /// <summary> 
        /// Gets or sets the Open_Date value.
        /// </summary>
        public DateTime Open_Date
        {
            get { return _Open_Date; }
            set { _Open_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Close_Date value.
        /// </summary>
        public DateTime Close_Date
        {
            get { return _Close_Date; }
            set { _Close_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Assign_Date value.
        /// </summary>
        public DateTime Assign_Date
        {
            get { return _Assign_Date; }
            set { _Assign_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Service_Manager value.
        /// </summary>
        public string Service_Manager
        {
            get { return _Service_Manager; }
            set { _Service_Manager = value; }
        }


        /// <summary> 
        /// Gets or sets the Building_Type value.
        /// </summary>
        public string Building_Type
        {
            get { return _Building_Type; }
            set { _Building_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Region value.
        /// </summary>
        public decimal FK_COI_Region
        {
            get { return _FK_COI_Region; }
            set { _FK_COI_Region = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_District value.
        /// </summary>
        public decimal FK_COI_District
        {
            get { return _FK_COI_District; }
            set { _FK_COI_District = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Division value.
        /// </summary>
        public decimal FK_COI_Division
        {
            get { return _FK_COI_Division; }
            set { _FK_COI_Division = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Tier value.
        /// </summary>
        public decimal FK_COI_Tier
        {
            get { return _FK_COI_Tier; }
            set { _FK_COI_Tier = value; }
        }


        /// <summary> 
        /// Gets or sets the Blanket_Coverage value.
        /// </summary>
        public string Blanket_Coverage
        {
            get { return _Blanket_Coverage; }
            set { _Blanket_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Building_Value value.
        /// </summary>
        public Nullable<decimal> Building_Value
        {
            get { return _Building_Value; }
            set { _Building_Value = value; }
        }


        /// <summary> 
        /// Gets or sets the Equipment_Value value.
        /// </summary>
        public Nullable<decimal> Equipment_Value
        {
            get { return _Equipment_Value; }
            set { _Equipment_Value = value; }
        }


        /// <summary> 
        /// Gets or sets the Signage_Value value.
        /// </summary>
        public Nullable<decimal> Signage_Value
        {
            get { return _Signage_Value; }
            set { _Signage_Value = value; }
        }


        /// <summary> 
        /// Gets or sets the Glass_Value value.
        /// </summary>
        public Nullable<decimal> Glass_Value
        {
            get { return _Glass_Value; }
            set { _Glass_Value = value; }
        }


        /// <summary> 
        /// Gets or sets the Deductible value.
        /// </summary>
        public Nullable<decimal> Deductible
        {
            get { return _Deductible; }
            set { _Deductible = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Of_Income_ALS value.
        /// </summary>
        public string Loss_Of_Income_ALS
        {
            get { return _Loss_Of_Income_ALS; }
            set { _Loss_Of_Income_ALS = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Of_Income_Months value.
        /// </summary>
        public Nullable<decimal> Loss_Of_Income_Months
        {
            get { return _Loss_Of_Income_Months; }
            set { _Loss_Of_Income_Months = value; }
        }


        /// <summary> 
        /// Gets or sets the Percentage value.
        /// </summary>
        public Nullable<decimal> Percentage
        {
            get { return _Percentage; }
            set { _Percentage = value; }
        }


        /// <summary> 
        /// Gets or sets the Flood_Coverage value.
        /// </summary>
        public Nullable<decimal> Flood_Coverage
        {
            get { return _Flood_Coverage; }
            set { _Flood_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Wind_Hail_Coverage value.
        /// </summary>
        public Nullable<decimal> Wind_Hail_Coverage
        {
            get { return _Wind_Hail_Coverage; }
            set { _Wind_Hail_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Earth_Movement_Coverage value.
        /// </summary>
        public Nullable<decimal> Earth_Movement_Coverage
        {
            get { return _Earth_Movement_Coverage; }
            set { _Earth_Movement_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the BI_Occurrence value.
        /// </summary>
        public Nullable<decimal> BI_Occurrence
        {
            get { return _BI_Occurrence; }
            set { _BI_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the BI_Aggregate value.
        /// </summary>
        public Nullable<decimal> BI_Aggregate
        {
            get { return _BI_Aggregate; }
            set { _BI_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Building_Occurrence value.
        /// </summary>
        public Nullable<decimal> Building_Occurrence
        {
            get { return _Building_Occurrence; }
            set { _Building_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the Building_Aggregate value.
        /// </summary>
        public Nullable<decimal> Building_Aggregate
        {
            get { return _Building_Aggregate; }
            set { _Building_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Building_Deductible value.
        /// </summary>
        public Nullable<decimal> Building_Deductible
        {
            get { return _Building_Deductible; }
            set { _Building_Deductible = value; }
        }


        /// <summary> 
        /// Gets or sets the Equipment_Occurrence value.
        /// </summary>
        public Nullable<decimal> Equipment_Occurrence
        {
            get { return _Equipment_Occurrence; }
            set { _Equipment_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the Equipment_Aggregate value.
        /// </summary>
        public Nullable<decimal> Equipment_Aggregate
        {
            get { return _Equipment_Aggregate; }
            set { _Equipment_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Equipment_Deductible value.
        /// </summary>
        public Nullable<decimal> Equipment_Deductible
        {
            get { return _Equipment_Deductible; }
            set { _Equipment_Deductible = value; }
        }


        /// <summary> 
        /// Gets or sets the Sign_Occurrence value.
        /// </summary>
        public Nullable<decimal> Sign_Occurrence
        {
            get { return _Sign_Occurrence; }
            set { _Sign_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the SIgn_Aggregate value.
        /// </summary>
        public Nullable<decimal> SIgn_Aggregate
        {
            get { return _SIgn_Aggregate; }
            set { _SIgn_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Glass_Occurrence value.
        /// </summary>
        public Nullable<decimal> Glass_Occurrence
        {
            get { return _Glass_Occurrence; }
            set { _Glass_Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the Glass_Aggregate value.
        /// </summary>
        public Nullable<decimal> Glass_Aggregate
        {
            get { return _Glass_Aggregate; }
            set { _Glass_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Ordinance_Law value.
        /// </summary>
        public string Ordinance_Law
        {
            get { return _Ordinance_Law; }
            set { _Ordinance_Law = value; }
        }


        /// <summary> 
        /// Gets or sets the Subrogation_Waiver value.
        /// </summary>
        public string Subrogation_Waiver
        {
            get { return _Subrogation_Waiver; }
            set { _Subrogation_Waiver = value; }
        }


        /// <summary> 
        /// Gets or sets the Perils_Insured_Form value.
        /// </summary>
        public string Perils_Insured_Form
        {
            get { return _Perils_Insured_Form; }
            set { _Perils_Insured_Form = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_On_Acord value.
        /// </summary>
        public string Property_On_Acord
        {
            get { return _Property_On_Acord; }
            set { _Property_On_Acord = value; }
        }


        /// <summary> 
        /// Gets or sets the Certificate_Received value.
        /// </summary>
        public string Certificate_Received
        {
            get { return _Certificate_Received; }
            set { _Certificate_Received = value; }
        }


        /// <summary> 
        /// Gets or sets the Replacement_Costs value.
        /// </summary>
        public string Replacement_Costs
        {
            get { return _Replacement_Costs; }
            set { _Replacement_Costs = value; }
        }


        /// <summary> 
        /// Gets or sets the Earthquake_Zone value.
        /// </summary>
        public string Earthquake_Zone
        {
            get { return _Earthquake_Zone; }
            set { _Earthquake_Zone = value; }
        }

        public string Glass_ACV
        {
            get { return _Glass_ACV; }
            set { _Glass_ACV = value; }
        }

        public string Leased_Property
        {
            get { return _Leased_Property; }
            set { _Leased_Property = value; }
        }

        public string Leased_Building_Limit_Accepted
        {
            get { return _Leased_Building_Limit_Accepted; }
            set { _Leased_Building_Limit_Accepted = value; }
        }

        public string B_I_Included_In_Verification
        {
            get { return _B_I_Included_In_Verification; }
            set { _B_I_Included_In_Verification = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_Locations class. with the default value.

        /// </summary>
        public COI_Locations()
        {

            this._PK_COI_Locations = -1;
            this._FK_Table_Name = -1;
            this._Table_Name = "";
            this._Sprinkler = "";
            this._Alarm = "";
            this._Lease_Expiration_Tenant = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Lease_Expiration_SubTenant = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Date_Purchased = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Date_Leased = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Notes = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Updated_By = "";
            this._Name = "";
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._FK_State = -1;
            this._Zip_Code = "";
            this._Contact_Last_Name = "";
            this._Contact_First_Name = "";
            this._Contact_Title = "";
            this._Contact_Phone = "";
            this._Contact_Fax = "";
            this._Contact_EMail = "";
            this._FK_County = -1;
            this._Location_Number = "";
            this._Square_Feet = null;
            this._Open_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Close_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Assign_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Service_Manager = "";
            this._Building_Type = "";
            this._FK_COI_Region = -1;
            this._FK_COI_District = -1;
            this._FK_COI_Division = -1;
            this._FK_COI_Tier = -1;
            this._Blanket_Coverage = "";
            this._Building_Value = null;
            this._Equipment_Value = null;
            this._Signage_Value = null;
            this._Glass_Value = null;
            this._Deductible = null;
            this._Loss_Of_Income_ALS = "";
            this._Loss_Of_Income_Months = null;
            this._Percentage = null;
            this._Flood_Coverage = null;
            this._Wind_Hail_Coverage = null;
            this._Earth_Movement_Coverage = null;
            this._BI_Occurrence = null;
            this._BI_Aggregate = null;
            this._Building_Occurrence = null;
            this._Building_Aggregate = null;
            this._Building_Deductible = null;
            this._Equipment_Occurrence = null;
            this._Equipment_Aggregate = null;
            this._Equipment_Deductible = null;
            this._Sign_Occurrence = null;
            this._SIgn_Aggregate = null;
            this._Glass_Occurrence = null;
            this._Glass_Aggregate = null;
            this._Ordinance_Law = "";
            this._Subrogation_Waiver = "";
            this._Perils_Insured_Form = "";
            this._Property_On_Acord = "";
            this._Certificate_Received = "";
            this._Replacement_Costs = "";
            this._Earthquake_Zone = "";
            this._Glass_ACV = "";
            this._Leased_Property = "";
            this._Leased_Building_Limit_Accepted = "";
            this._B_I_Included_In_Verification = "";
        }



        /// <summary> 

        /// Initializes a new instance of the COI_Locations class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Locations(decimal PK)
        {
            DataTable dtCOI_Locations = Select(PK).Tables[0];

            if (dtCOI_Locations.Rows.Count > 0)
            {

                DataRow drCOI_Locations = dtCOI_Locations.Rows[0];

                this._PK_COI_Locations = drCOI_Locations["PK_COI_Locations"] != DBNull.Value ? Convert.ToDecimal(drCOI_Locations["PK_COI_Locations"]) : 0;
                this._FK_Table_Name = drCOI_Locations["FK_Table_Name"] != DBNull.Value ? Convert.ToDecimal(drCOI_Locations["FK_Table_Name"]) : 0;
                this._Table_Name = Convert.ToString(drCOI_Locations["Table_Name"]);
                this._Sprinkler = Convert.ToString(drCOI_Locations["Sprinkler"]);
                this._Alarm = Convert.ToString(drCOI_Locations["Alarm"]);
                this._Lease_Expiration_Tenant = drCOI_Locations["Lease_Expiration_Tenant"] != DBNull.Value ? Convert.ToDateTime(drCOI_Locations["Lease_Expiration_Tenant"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Lease_Expiration_SubTenant = drCOI_Locations["Lease_Expiration_SubTenant"] != DBNull.Value ? Convert.ToDateTime(drCOI_Locations["Lease_Expiration_SubTenant"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Date_Purchased = drCOI_Locations["Date_Purchased"] != DBNull.Value ? Convert.ToDateTime(drCOI_Locations["Date_Purchased"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Date_Leased = drCOI_Locations["Date_Leased"] != DBNull.Value ? Convert.ToDateTime(drCOI_Locations["Date_Leased"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Notes = Convert.ToString(drCOI_Locations["Notes"]);
                this._Update_Date = drCOI_Locations["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Locations["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Updated_By = Convert.ToString(drCOI_Locations["Updated_By"]);
                this._Name = Convert.ToString(drCOI_Locations["Name"]);
                this._Address_1 = Convert.ToString(drCOI_Locations["Address_1"]);
                this._Address_2 = Convert.ToString(drCOI_Locations["Address_2"]);
                this._City = Convert.ToString(drCOI_Locations["City"]);
                this._FK_State = drCOI_Locations["FK_State"] != DBNull.Value ? Convert.ToDecimal(drCOI_Locations["FK_State"]) : 0;
                this._Zip_Code = Convert.ToString(drCOI_Locations["Zip_Code"]);
                this._Contact_Last_Name = Convert.ToString(drCOI_Locations["Contact_Last_Name"]);
                this._Contact_First_Name = Convert.ToString(drCOI_Locations["Contact_First_Name"]);
                this._Contact_Title = Convert.ToString(drCOI_Locations["Contact_Title"]);
                this._Contact_Phone = Convert.ToString(drCOI_Locations["Contact_Phone"]);
                this._Contact_Fax = Convert.ToString(drCOI_Locations["Contact_Fax"]);
                this._Contact_EMail = Convert.ToString(drCOI_Locations["Contact_EMail"]);
                this._FK_County = drCOI_Locations["FK_County"] != DBNull.Value ? Convert.ToDecimal(drCOI_Locations["FK_County"]) : 0;
                this._Location_Number = Convert.ToString(drCOI_Locations["Location_Number"]);
                if (drCOI_Locations["Square_Feet"] != DBNull.Value) this._Square_Feet = Convert.ToDecimal(drCOI_Locations["Square_Feet"]);
                this._Open_Date = drCOI_Locations["Open_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Locations["Open_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Close_Date = drCOI_Locations["Close_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Locations["Close_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Assign_Date = drCOI_Locations["Assign_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Locations["Assign_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Service_Manager = Convert.ToString(drCOI_Locations["Service_Manager"]);
                this._Building_Type = Convert.ToString(drCOI_Locations["Building_Type"]);
                this._FK_COI_Region = drCOI_Locations["FK_COI_Region"] != DBNull.Value ? Convert.ToDecimal(drCOI_Locations["FK_COI_Region"]) : 0;
                this._FK_COI_District = drCOI_Locations["FK_COI_District"] != DBNull.Value ? Convert.ToDecimal(drCOI_Locations["FK_COI_District"]) : 0;
                this._FK_COI_Division = drCOI_Locations["FK_COI_Division"] != DBNull.Value ? Convert.ToDecimal(drCOI_Locations["FK_COI_Division"]) : 0;
                this._FK_COI_Tier = drCOI_Locations["FK_COI_Tier"] != DBNull.Value ? Convert.ToDecimal(drCOI_Locations["FK_COI_Tier"]) : 0;
                this._Blanket_Coverage = Convert.ToString(drCOI_Locations["Blanket_Coverage"]);
                if (drCOI_Locations["Building_Value"] != DBNull.Value) this._Building_Value = Convert.ToDecimal(drCOI_Locations["Building_Value"]);
                if (drCOI_Locations["Equipment_Value"] != DBNull.Value) this._Equipment_Value = Convert.ToDecimal(drCOI_Locations["Equipment_Value"]);
                if (drCOI_Locations["Signage_Value"] != DBNull.Value) this._Signage_Value = Convert.ToDecimal(drCOI_Locations["Signage_Value"]);
                if (drCOI_Locations["Glass_Value"] != DBNull.Value) this._Glass_Value = Convert.ToDecimal(drCOI_Locations["Glass_Value"]);
                if (drCOI_Locations["Deductible"] != DBNull.Value) this._Deductible = Convert.ToDecimal(drCOI_Locations["Deductible"]);
                this._Loss_Of_Income_ALS = Convert.ToString(drCOI_Locations["Loss_Of_Income_ALS"]);
                if (drCOI_Locations["Loss_Of_Income_Months"] != DBNull.Value) this._Loss_Of_Income_Months = Convert.ToDecimal(drCOI_Locations["Loss_Of_Income_Months"]);
                if (drCOI_Locations["Percentage"] != DBNull.Value) this._Percentage = Convert.ToDecimal(drCOI_Locations["Percentage"]);
                if (drCOI_Locations["Flood_Coverage"] != DBNull.Value) this._Flood_Coverage = Convert.ToDecimal(drCOI_Locations["Flood_Coverage"]);
                if (drCOI_Locations["Wind_Hail_Coverage"] != DBNull.Value) this._Wind_Hail_Coverage = Convert.ToDecimal(drCOI_Locations["Wind_Hail_Coverage"]);
                if (drCOI_Locations["Earth_Movement_Coverage"] != DBNull.Value) this._Earth_Movement_Coverage = Convert.ToDecimal(drCOI_Locations["Earth_Movement_Coverage"]);
                if (drCOI_Locations["BI_Occurrence"] != DBNull.Value) this._BI_Occurrence = Convert.ToDecimal(drCOI_Locations["BI_Occurrence"]);
                if (drCOI_Locations["BI_Aggregate"] != DBNull.Value) this._BI_Aggregate = Convert.ToDecimal(drCOI_Locations["BI_Aggregate"]);
                if (drCOI_Locations["Building_Occurrence"] != DBNull.Value) this._Building_Occurrence = Convert.ToDecimal(drCOI_Locations["Building_Occurrence"]);
                if (drCOI_Locations["Building_Aggregate"] != DBNull.Value) this._Building_Aggregate = Convert.ToDecimal(drCOI_Locations["Building_Aggregate"]);
                if (drCOI_Locations["Building_Deductible"] != DBNull.Value) this._Building_Deductible = Convert.ToDecimal(drCOI_Locations["Building_Deductible"]);
                if (drCOI_Locations["Equipment_Occurrence"] != DBNull.Value) this._Equipment_Occurrence = Convert.ToDecimal(drCOI_Locations["Equipment_Occurrence"]);
                if (drCOI_Locations["Equipment_Aggregate"] != DBNull.Value) this._Equipment_Aggregate = Convert.ToDecimal(drCOI_Locations["Equipment_Aggregate"]);
                if (drCOI_Locations["Equipment_Deductible"] != DBNull.Value) this._Equipment_Deductible = Convert.ToDecimal(drCOI_Locations["Equipment_Deductible"]);
                if (drCOI_Locations["Sign_Occurrence"] != DBNull.Value) this._Sign_Occurrence = Convert.ToDecimal(drCOI_Locations["Sign_Occurrence"]);
                if (drCOI_Locations["SIgn_Aggregate"] != DBNull.Value) this._SIgn_Aggregate = Convert.ToDecimal(drCOI_Locations["SIgn_Aggregate"]);
                if (drCOI_Locations["Glass_Occurrence"] != DBNull.Value) this._Glass_Occurrence = Convert.ToDecimal(drCOI_Locations["Glass_Occurrence"]);
                if (drCOI_Locations["Glass_Aggregate"] != DBNull.Value) this._Glass_Aggregate = Convert.ToDecimal(drCOI_Locations["Glass_Aggregate"]);
                this._Ordinance_Law = Convert.ToString(drCOI_Locations["Ordinance_Law"]);
                this._Subrogation_Waiver = Convert.ToString(drCOI_Locations["Subrogation_Waiver"]);
                this._Perils_Insured_Form = Convert.ToString(drCOI_Locations["Perils_Insured_Form"]);
                this._Property_On_Acord = Convert.ToString(drCOI_Locations["Property_On_Acord"]);
                this._Certificate_Received = Convert.ToString(drCOI_Locations["Certificate_Received"]);
                this._Replacement_Costs = Convert.ToString(drCOI_Locations["Replacement_Costs"]);
                this._Earthquake_Zone = Convert.ToString(drCOI_Locations["Earthquake_Zone"]);
                this._Glass_ACV = Convert.ToString(drCOI_Locations["Glass_ACV"]);
                this._Leased_Property = Convert.ToString(drCOI_Locations["Leased_Property"]);
                this._Leased_Building_Limit_Accepted = Convert.ToString(drCOI_Locations["Leased_Building_Limit_Accepted"]);
                this._B_I_Included_In_Verification = Convert.ToString(drCOI_Locations["B_I_Included_In_Verification"]);

            }

            else
            {

                new COI_Locations();
            }

        }



        #endregion


        #region "Methods"
        /// <summary>
        /// Inserts a record into the COI_Locations table.
        /// <summary>
        /// <param name="fK_Table_Name"></param>
        /// <param name="name"></param>
        /// <param name="address_1"></param>
        /// <param name="address_2"></param>
        /// <param name="city"></param>
        /// <param name="fK_State"></param>
        /// <param name="zip_Code"></param>
        /// <param name="contact_Last_Name"></param>
        /// <param name="contact_First_Name"></param>
        /// <param name="contact_Title"></param>
        /// <param name="contact_Phone"></param>
        /// <param name="contact_Fax"></param>
        /// <param name="contact_EMail"></param>
        /// <param name="fK_County"></param>
        /// <param name="location_Number"></param>
        /// <param name="square_Feet"></param>
        /// <param name="open_Date"></param>
        /// <param name="close_Date"></param>
        /// <param name="assign_Date"></param>
        /// <param name="service_Manager"></param>
        /// <param name="building_Type"></param>
        /// <param name="fK_COI_Region"></param>
        /// <param name="fK_COI_District"></param>
        /// <param name="fK_COI_Division"></param>
        /// <param name="fK_COI_Tier"></param>
        /// <param name="blanket_Coverage"></param>
        /// <param name="building_Value"></param>
        /// <param name="equipment_Value"></param>
        /// <param name="signage_Value"></param>
        /// <param name="glass_Value"></param>
        /// <param name="deductible"></param>
        /// <param name="loss_Of_Income_ALS"></param>
        /// <param name="loss_Of_Income_Months"></param>
        /// <param name="percentage"></param>
        /// <param name="flood_Coverage"></param>
        /// <param name="wind_Hail_Coverage"></param>
        /// <param name="earth_Movement_Coverage"></param>
        /// <param name="bI_Occurrence"></param>
        /// <param name="bI_Aggregate"></param>
        /// <param name="building_Occurrence"></param>
        /// <param name="building_Aggregate"></param>
        /// <param name="building_Deductible"></param>
        /// <param name="equipment_Occurrence"></param>
        /// <param name="equipment_Aggregate"></param>
        /// <param name="equipment_Deductible"></param>
        /// <param name="sign_Occurrence"></param>
        /// <param name="sIgn_Aggregate"></param>
        /// <param name="glass_Occurrence"></param>
        /// <param name="glass_Aggregate"></param>
        /// <param name="ordinance_Law"></param>
        /// <param name="subrogation_Waiver"></param>
        /// <param name="perils_Insured_Form"></param>
        /// <param name="property_On_Acord"></param>
        /// <param name="certificate_Received"></param>
        /// <param name="replacement_Costs"></param>
        /// <param name="earthquake_Zone"></param>
        /// <param name="sprinkler"></param>
        /// <param name="alarm"></param>
        /// <param name="lease_Expiration_Tenant"></param>
        /// <param name="lease_Expiration_SubTenant"></param>
        /// <param name="date_Purchased"></param>
        /// <param name="date_Leased"></param>
        /// <param name="notes"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        /// <returns></returns>
        public static int Insert(decimal fK_Table_Name, string tablename, string name, string address_1, string address_2, string city, Nullable<decimal> fK_State, string zip_Code, string contact_Last_Name, string contact_First_Name, string contact_Title, string contact_Phone, string contact_Fax, string contact_EMail, Nullable<decimal> fK_County, string location_Number, Nullable<decimal> square_Feet, DateTime open_Date, DateTime close_Date, DateTime assign_Date, string service_Manager, string building_Type, Nullable<decimal> fK_COI_Region, Nullable<decimal> fK_COI_District, Nullable<decimal> fK_COI_Division, Nullable<decimal> fK_COI_Tier, string blanket_Coverage, Nullable<decimal> building_Value, Nullable<decimal> equipment_Value, Nullable<decimal> signage_Value, Nullable<decimal> glass_Value, Nullable<decimal> deductible, string loss_Of_Income_ALS, Nullable<decimal> loss_Of_Income_Months, Nullable<decimal> percentage, Nullable<decimal> flood_Coverage, Nullable<decimal> wind_Hail_Coverage, Nullable<decimal> earth_Movement_Coverage, Nullable<decimal> bI_Occurrence, Nullable<decimal> bI_Aggregate, Nullable<decimal> building_Occurrence, Nullable<decimal> building_Aggregate, Nullable<decimal> building_Deductible, Nullable<decimal> equipment_Occurrence, Nullable<decimal> equipment_Aggregate, Nullable<decimal> equipment_Deductible, Nullable<decimal> sign_Occurrence, Nullable<decimal> sIgn_Aggregate, Nullable<decimal> glass_Occurrence, Nullable<decimal> glass_Aggregate, string ordinance_Law, string subrogation_Waiver, string perils_Insured_Form, string property_On_Acord, string certificate_Received, string replacement_Costs, string earthquake_Zone, string sprinkler, string alarm, DateTime lease_Expiration_Tenant, DateTime lease_Expiration_SubTenant, DateTime date_Purchased, DateTime date_Leased, string notes, DateTime update_Date, string updated_By, string glass_ACV, string leased_Property, string leased_Building_Limit_Accepted, string b_I_Included_In_Verification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsInsert");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, tablename);
            db.AddInParameter(dbCommand, "Name", DbType.String, name);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, city);
            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, fK_State);
            db.AddInParameter(dbCommand, "Zip_Code", DbType.String, zip_Code);
            db.AddInParameter(dbCommand, "Contact_Last_Name", DbType.String, contact_Last_Name);
            db.AddInParameter(dbCommand, "Contact_First_Name", DbType.String, contact_First_Name);
            db.AddInParameter(dbCommand, "Contact_Title", DbType.String, contact_Title);
            db.AddInParameter(dbCommand, "Contact_Phone", DbType.String, contact_Phone);
            db.AddInParameter(dbCommand, "Contact_Fax", DbType.String, contact_Fax);
            db.AddInParameter(dbCommand, "Contact_EMail", DbType.String, contact_EMail);
            db.AddInParameter(dbCommand, "FK_County", DbType.Decimal, fK_County);
            db.AddInParameter(dbCommand, "Location_Number", DbType.String, location_Number);
            db.AddInParameter(dbCommand, "Square_Feet", DbType.Decimal, square_Feet);
            db.AddInParameter(dbCommand, "Open_Date", DbType.DateTime, open_Date);
            db.AddInParameter(dbCommand, "Close_Date", DbType.DateTime, close_Date);
            db.AddInParameter(dbCommand, "Assign_Date", DbType.DateTime, assign_Date);
            db.AddInParameter(dbCommand, "Service_Manager", DbType.String, service_Manager);
            db.AddInParameter(dbCommand, "Building_Type", DbType.String, building_Type);
            db.AddInParameter(dbCommand, "FK_COI_Region", DbType.Decimal, fK_COI_Region);
            db.AddInParameter(dbCommand, "FK_COI_District", DbType.Decimal, fK_COI_District);
            db.AddInParameter(dbCommand, "FK_COI_Division", DbType.Decimal, fK_COI_Division);
            db.AddInParameter(dbCommand, "FK_COI_Tier", DbType.Decimal, fK_COI_Tier);
            db.AddInParameter(dbCommand, "Blanket_Coverage", DbType.String, blanket_Coverage);
            db.AddInParameter(dbCommand, "Building_Value", DbType.Decimal, building_Value);
            db.AddInParameter(dbCommand, "Equipment_Value", DbType.Decimal, equipment_Value);
            db.AddInParameter(dbCommand, "Signage_Value", DbType.Decimal, signage_Value);
            db.AddInParameter(dbCommand, "Glass_Value", DbType.Decimal, glass_Value);
            db.AddInParameter(dbCommand, "Deductible", DbType.Decimal, deductible);
            db.AddInParameter(dbCommand, "Loss_Of_Income_ALS", DbType.String, loss_Of_Income_ALS);
            db.AddInParameter(dbCommand, "Loss_Of_Income_Months", DbType.Decimal, loss_Of_Income_Months);
            db.AddInParameter(dbCommand, "Percentage", DbType.Decimal, percentage);
            db.AddInParameter(dbCommand, "Flood_Coverage", DbType.Decimal, flood_Coverage);
            db.AddInParameter(dbCommand, "Wind_Hail_Coverage", DbType.Decimal, wind_Hail_Coverage);
            db.AddInParameter(dbCommand, "Earth_Movement_Coverage", DbType.Decimal, earth_Movement_Coverage);
            db.AddInParameter(dbCommand, "BI_Occurrence", DbType.Decimal, bI_Occurrence);
            db.AddInParameter(dbCommand, "BI_Aggregate", DbType.Decimal, bI_Aggregate);
            db.AddInParameter(dbCommand, "Building_Occurrence", DbType.Decimal, building_Occurrence);
            db.AddInParameter(dbCommand, "Building_Aggregate", DbType.Decimal, building_Aggregate);
            db.AddInParameter(dbCommand, "Building_Deductible", DbType.Decimal, building_Deductible);
            db.AddInParameter(dbCommand, "Equipment_Occurrence", DbType.Decimal, equipment_Occurrence);
            db.AddInParameter(dbCommand, "Equipment_Aggregate", DbType.Decimal, equipment_Aggregate);
            db.AddInParameter(dbCommand, "Equipment_Deductible", DbType.Decimal, equipment_Deductible);
            db.AddInParameter(dbCommand, "Sign_Occurrence", DbType.Decimal, sign_Occurrence);
            db.AddInParameter(dbCommand, "SIgn_Aggregate", DbType.Decimal, sIgn_Aggregate);
            db.AddInParameter(dbCommand, "Glass_Occurrence", DbType.Decimal, glass_Occurrence);
            db.AddInParameter(dbCommand, "Glass_Aggregate", DbType.Decimal, glass_Aggregate);
            db.AddInParameter(dbCommand, "Ordinance_Law", DbType.String, ordinance_Law);
            db.AddInParameter(dbCommand, "Subrogation_Waiver", DbType.String, subrogation_Waiver);
            db.AddInParameter(dbCommand, "Perils_Insured_Form", DbType.String, perils_Insured_Form);
            db.AddInParameter(dbCommand, "Property_On_Acord", DbType.String, property_On_Acord);
            db.AddInParameter(dbCommand, "Certificate_Received", DbType.String, certificate_Received);
            db.AddInParameter(dbCommand, "Replacement_Costs", DbType.String, replacement_Costs);
            db.AddInParameter(dbCommand, "Earthquake_Zone", DbType.String, earthquake_Zone);
            db.AddInParameter(dbCommand, "Sprinkler", DbType.String, sprinkler);
            db.AddInParameter(dbCommand, "Alarm", DbType.String, alarm);
            db.AddInParameter(dbCommand, "Lease_Expiration_Tenant", DbType.DateTime, lease_Expiration_Tenant);
            db.AddInParameter(dbCommand, "Lease_Expiration_SubTenant", DbType.DateTime, lease_Expiration_SubTenant);
            db.AddInParameter(dbCommand, "Date_Purchased", DbType.DateTime, date_Purchased);
            db.AddInParameter(dbCommand, "Date_Leased", DbType.DateTime, date_Leased);
            db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Glass_ACV", DbType.String, glass_ACV);
            db.AddInParameter(dbCommand, "Leased_Property", DbType.String, leased_Property);
            db.AddInParameter(dbCommand, "Leased_Building_Limit_Accepted", DbType.String, leased_Building_Limit_Accepted);
            db.AddInParameter(dbCommand, "B_I_Included_In_Verification", DbType.String, b_I_Included_In_Verification);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the COI_Locations table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pK_COI_Locations)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsSelect");

            db.AddInParameter(dbCommand, "PK_COI_Locations", DbType.Decimal, pK_COI_Locations);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFK_COIs(decimal fK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsSelectByFK_COIs");

            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

            return db.ExecuteDataSet(dbCommand);
        }
        ///// <summary>
        ///// Selects records from the COI_Locations table by a foreign key.
        ///// <summary>
        ///// <param name="fK_COI_Region"></param>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectByFK_COI_Region(decimal fK_COI_Region)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsSelectByFK_COI_Region");

        //    db.AddInParameter(dbCommand, "FK_COI_Region", DbType.Decimal, fK_COI_Region);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        ///// <summary>
        ///// Selects records from the COI_Locations table by a foreign key.
        ///// <summary>
        ///// <param name="fK_State"></param>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectByFK_State(decimal fK_State)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsSelectByFK_State");

        //    db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, fK_State);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        ///// <summary>
        ///// Selects records from the COI_Locations table by a foreign key.
        ///// <summary>
        ///// <param name="fK_County"></param>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectByFK_County(decimal fK_County)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsSelectByFK_County");

        //    db.AddInParameter(dbCommand, "FK_County", DbType.Decimal, fK_County);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        ///// <summary>
        ///// Selects records from the COI_Locations table by a foreign key.
        ///// <summary>
        ///// <param name="fK_COI_District"></param>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectByFK_COI_District(decimal fK_COI_District)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsSelectByFK_COI_District");

        //    db.AddInParameter(dbCommand, "FK_COI_District", DbType.Decimal, fK_COI_District);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        /// <summary>
        /// Selects records from the COI_Locations table by a foreign key.
        /// <summary>
        /// <param name="fK_Table_Name"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_COI_Property_Policies(decimal fK_Table_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsSelectByFK_COI_Property_Policies");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);

            return db.ExecuteDataSet(dbCommand);
        }



        /// <summary>
        /// Updates a record in the COI_Locations table.
        /// <summary>
        /// <param name="pK_COI_Locations"></param>
        /// <param name="fK_Table_Name"></param>
        /// <param name="name"></param>
        /// <param name="address_1"></param>
        /// <param name="address_2"></param>
        /// <param name="city"></param>
        /// <param name="fK_State"></param>
        /// <param name="zip_Code"></param>
        /// <param name="contact_Last_Name"></param>
        /// <param name="contact_First_Name"></param>
        /// <param name="contact_Title"></param>
        /// <param name="contact_Phone"></param>
        /// <param name="contact_Fax"></param>
        /// <param name="contact_EMail"></param>
        /// <param name="fK_County"></param>
        /// <param name="location_Number"></param>
        /// <param name="square_Feet"></param>
        /// <param name="open_Date"></param>
        /// <param name="close_Date"></param>
        /// <param name="assign_Date"></param>
        /// <param name="service_Manager"></param>
        /// <param name="building_Type"></param>
        /// <param name="fK_COI_Region"></param>
        /// <param name="fK_COI_District"></param>
        /// <param name="fK_COI_Division"></param>
        /// <param name="fK_COI_Tier"></param>
        /// <param name="blanket_Coverage"></param>
        /// <param name="building_Value"></param>
        /// <param name="equipment_Value"></param>
        /// <param name="signage_Value"></param>
        /// <param name="glass_Value"></param>
        /// <param name="deductible"></param>
        /// <param name="loss_Of_Income_ALS"></param>
        /// <param name="loss_Of_Income_Months"></param>
        /// <param name="percentage"></param>
        /// <param name="flood_Coverage"></param>
        /// <param name="wind_Hail_Coverage"></param>
        /// <param name="earth_Movement_Coverage"></param>
        /// <param name="bI_Occurrence"></param>
        /// <param name="bI_Aggregate"></param>
        /// <param name="building_Occurrence"></param>
        /// <param name="building_Aggregate"></param>
        /// <param name="building_Deductible"></param>
        /// <param name="equipment_Occurrence"></param>
        /// <param name="equipment_Aggregate"></param>
        /// <param name="equipment_Deductible"></param>
        /// <param name="sign_Occurrence"></param>
        /// <param name="sIgn_Aggregate"></param>
        /// <param name="glass_Occurrence"></param>
        /// <param name="glass_Aggregate"></param>
        /// <param name="ordinance_Law"></param>
        /// <param name="subrogation_Waiver"></param>
        /// <param name="perils_Insured_Form"></param>
        /// <param name="property_On_Acord"></param>
        /// <param name="certificate_Received"></param>
        /// <param name="replacement_Costs"></param>
        /// <param name="earthquake_Zone"></param>
        /// <param name="sprinkler"></param>
        /// <param name="alarm"></param>
        /// <param name="lease_Expiration_Tenant"></param>
        /// <param name="lease_Expiration_SubTenant"></param>
        /// <param name="date_Purchased"></param>
        /// <param name="date_Leased"></param>
        /// <param name="notes"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        public static void Update(decimal pK_COI_Locations, Nullable<decimal> fK_Table_Name, string tablename, string name, string address_1, string address_2, string city, Nullable<decimal> fK_State, string zip_Code, string contact_Last_Name, string contact_First_Name, string contact_Title, string contact_Phone, string contact_Fax, string contact_EMail, Nullable<decimal> fK_County, string location_Number, Nullable<decimal> square_Feet, DateTime open_Date, DateTime close_Date, DateTime assign_Date, string service_Manager, string building_Type, Nullable<decimal> fK_COI_Region, Nullable<decimal> fK_COI_District, Nullable<decimal> fK_COI_Division, Nullable<decimal> fK_COI_Tier, string blanket_Coverage, Nullable<decimal> building_Value, Nullable<decimal> equipment_Value, Nullable<decimal> signage_Value, Nullable<decimal> glass_Value, Nullable<decimal> deductible, string loss_Of_Income_ALS, Nullable<decimal> loss_Of_Income_Months, Nullable<decimal> percentage, Nullable<decimal> flood_Coverage, Nullable<decimal> wind_Hail_Coverage, Nullable<decimal> earth_Movement_Coverage, Nullable<decimal> bI_Occurrence, Nullable<decimal> bI_Aggregate, Nullable<decimal> building_Occurrence, Nullable<decimal> building_Aggregate, Nullable<decimal> building_Deductible, Nullable<decimal> equipment_Occurrence, Nullable<decimal> equipment_Aggregate, Nullable<decimal> equipment_Deductible, Nullable<decimal> sign_Occurrence, Nullable<decimal> sIgn_Aggregate, Nullable<decimal> glass_Occurrence, Nullable<decimal> glass_Aggregate, string ordinance_Law, string subrogation_Waiver, string perils_Insured_Form, string property_On_Acord, string certificate_Received, string replacement_Costs, string earthquake_Zone, string sprinkler, string alarm, DateTime lease_Expiration_Tenant, DateTime lease_Expiration_SubTenant, DateTime date_Purchased, DateTime date_Leased, string notes, DateTime update_Date, string updated_By, string glass_ACV, string leased_Property, string leased_Building_Limit_Accepted, string b_I_Included_In_Verification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsUpdate");

            db.AddInParameter(dbCommand, "PK_COI_Locations", DbType.Decimal, pK_COI_Locations);
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, tablename);
            db.AddInParameter(dbCommand, "Name", DbType.String, name);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, city);
            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, fK_State);
            db.AddInParameter(dbCommand, "Zip_Code", DbType.String, zip_Code);
            db.AddInParameter(dbCommand, "Contact_Last_Name", DbType.String, contact_Last_Name);
            db.AddInParameter(dbCommand, "Contact_First_Name", DbType.String, contact_First_Name);
            db.AddInParameter(dbCommand, "Contact_Title", DbType.String, contact_Title);
            db.AddInParameter(dbCommand, "Contact_Phone", DbType.String, contact_Phone);
            db.AddInParameter(dbCommand, "Contact_Fax", DbType.String, contact_Fax);
            db.AddInParameter(dbCommand, "Contact_EMail", DbType.String, contact_EMail);
            db.AddInParameter(dbCommand, "FK_County", DbType.Decimal, fK_County);
            db.AddInParameter(dbCommand, "Location_Number", DbType.String, location_Number);
            db.AddInParameter(dbCommand, "Square_Feet", DbType.Decimal, square_Feet);
            db.AddInParameter(dbCommand, "Open_Date", DbType.DateTime, open_Date);
            db.AddInParameter(dbCommand, "Close_Date", DbType.DateTime, close_Date);
            db.AddInParameter(dbCommand, "Assign_Date", DbType.DateTime, assign_Date);
            db.AddInParameter(dbCommand, "Service_Manager", DbType.String, service_Manager);
            db.AddInParameter(dbCommand, "Building_Type", DbType.String, building_Type);
            db.AddInParameter(dbCommand, "FK_COI_Region", DbType.Decimal, fK_COI_Region);
            db.AddInParameter(dbCommand, "FK_COI_District", DbType.Decimal, fK_COI_District);
            db.AddInParameter(dbCommand, "FK_COI_Division", DbType.Decimal, fK_COI_Division);
            db.AddInParameter(dbCommand, "FK_COI_Tier", DbType.Decimal, fK_COI_Tier);
            db.AddInParameter(dbCommand, "Blanket_Coverage", DbType.String, blanket_Coverage);
            db.AddInParameter(dbCommand, "Building_Value", DbType.Decimal, building_Value);
            db.AddInParameter(dbCommand, "Equipment_Value", DbType.Decimal, equipment_Value);
            db.AddInParameter(dbCommand, "Signage_Value", DbType.Decimal, signage_Value);
            db.AddInParameter(dbCommand, "Glass_Value", DbType.Decimal, glass_Value);
            db.AddInParameter(dbCommand, "Deductible", DbType.Decimal, deductible);
            db.AddInParameter(dbCommand, "Loss_Of_Income_ALS", DbType.String, loss_Of_Income_ALS);
            db.AddInParameter(dbCommand, "Loss_Of_Income_Months", DbType.Decimal, loss_Of_Income_Months);
            db.AddInParameter(dbCommand, "Percentage", DbType.Decimal, percentage);
            db.AddInParameter(dbCommand, "Flood_Coverage", DbType.Decimal, flood_Coverage);
            db.AddInParameter(dbCommand, "Wind_Hail_Coverage", DbType.Decimal, wind_Hail_Coverage);
            db.AddInParameter(dbCommand, "Earth_Movement_Coverage", DbType.Decimal, earth_Movement_Coverage);
            db.AddInParameter(dbCommand, "BI_Occurrence", DbType.Decimal, bI_Occurrence);
            db.AddInParameter(dbCommand, "BI_Aggregate", DbType.Decimal, bI_Aggregate);
            db.AddInParameter(dbCommand, "Building_Occurrence", DbType.Decimal, building_Occurrence);
            db.AddInParameter(dbCommand, "Building_Aggregate", DbType.Decimal, building_Aggregate);
            db.AddInParameter(dbCommand, "Building_Deductible", DbType.Decimal, building_Deductible);
            db.AddInParameter(dbCommand, "Equipment_Occurrence", DbType.Decimal, equipment_Occurrence);
            db.AddInParameter(dbCommand, "Equipment_Aggregate", DbType.Decimal, equipment_Aggregate);
            db.AddInParameter(dbCommand, "Equipment_Deductible", DbType.Decimal, equipment_Deductible);
            db.AddInParameter(dbCommand, "Sign_Occurrence", DbType.Decimal, sign_Occurrence);
            db.AddInParameter(dbCommand, "SIgn_Aggregate", DbType.Decimal, sIgn_Aggregate);
            db.AddInParameter(dbCommand, "Glass_Occurrence", DbType.Decimal, glass_Occurrence);
            db.AddInParameter(dbCommand, "Glass_Aggregate", DbType.Decimal, glass_Aggregate);
            db.AddInParameter(dbCommand, "Ordinance_Law", DbType.String, ordinance_Law);
            db.AddInParameter(dbCommand, "Subrogation_Waiver", DbType.String, subrogation_Waiver);
            db.AddInParameter(dbCommand, "Perils_Insured_Form", DbType.String, perils_Insured_Form);
            db.AddInParameter(dbCommand, "Property_On_Acord", DbType.String, property_On_Acord);
            db.AddInParameter(dbCommand, "Certificate_Received", DbType.String, certificate_Received);
            db.AddInParameter(dbCommand, "Replacement_Costs", DbType.String, replacement_Costs);
            db.AddInParameter(dbCommand, "Earthquake_Zone", DbType.String, earthquake_Zone);
            db.AddInParameter(dbCommand, "Sprinkler", DbType.String, sprinkler);
            db.AddInParameter(dbCommand, "Alarm", DbType.String, alarm);
            db.AddInParameter(dbCommand, "Lease_Expiration_Tenant", DbType.DateTime, lease_Expiration_Tenant);
            db.AddInParameter(dbCommand, "Lease_Expiration_SubTenant", DbType.DateTime, lease_Expiration_SubTenant);
            db.AddInParameter(dbCommand, "Date_Purchased", DbType.DateTime, date_Purchased);
            db.AddInParameter(dbCommand, "Date_Leased", DbType.DateTime, date_Leased);
            db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Glass_ACV", DbType.String, glass_ACV);
            db.AddInParameter(dbCommand, "Leased_Property", DbType.String, leased_Property);
            db.AddInParameter(dbCommand, "Leased_Building_Limit_Accepted", DbType.String, leased_Building_Limit_Accepted);
            db.AddInParameter(dbCommand, "B_I_Included_In_Verification", DbType.String, b_I_Included_In_Verification);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the COI_Locations table by a composite primary key.
        /// <summary>
        public static void Delete(decimal pK_COI_Locations)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsDelete");

            db.AddInParameter(dbCommand, "PK_COI_Locations", DbType.Decimal, pK_COI_Locations);

            db.ExecuteNonQuery(dbCommand);
        }



        /// <summary>
        /// Deletes a record from the COI_Locations table by a foreign key.
        /// <summary>
        public static void DeleteByFK_COI_Property_Policies(decimal fK_Table_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsDeleteByFK_COI_Property_Policies");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);

            db.ExecuteNonQuery(dbCommand);
        }



        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
            return Insert(_FK_Table_Name,_Table_Name, _Name, _Address_1, _Address_2, _City, _FK_State, _Zip_Code, _Contact_Last_Name,
                _Contact_First_Name, _Contact_Title, _Contact_Phone, _Contact_Fax, _Contact_EMail, _FK_County, _Location_Number,
                _Square_Feet, _Open_Date, _Close_Date, _Assign_Date, _Service_Manager, _Building_Type, _FK_COI_Region, _FK_COI_District,
                _FK_COI_Division, _FK_COI_Tier, _Blanket_Coverage, _Building_Value, _Equipment_Value, _Signage_Value, _Glass_Value,
                _Deductible, _Loss_Of_Income_ALS, _Loss_Of_Income_Months, _Percentage, _Flood_Coverage, _Wind_Hail_Coverage, _Earth_Movement_Coverage,
                _BI_Occurrence, _BI_Aggregate, _Building_Occurrence, _Building_Aggregate, _Building_Deductible, _Equipment_Occurrence,
                _Equipment_Aggregate, _Equipment_Deductible, _Sign_Occurrence, _SIgn_Aggregate, _Glass_Occurrence, _Glass_Aggregate,
                _Ordinance_Law, _Subrogation_Waiver, _Perils_Insured_Form, _Property_On_Acord, _Certificate_Received,
                _Replacement_Costs, _Earthquake_Zone, _Sprinkler, _Alarm, _Lease_Expiration_Tenant, _Lease_Expiration_SubTenant,
                _Date_Purchased, _Date_Leased, _Notes, _Update_Date, _Updated_By, _Glass_ACV, _Leased_Property, _Leased_Building_Limit_Accepted, _B_I_Included_In_Verification);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_Locations, _FK_Table_Name, _Table_Name, _Name, _Address_1, _Address_2, _City, _FK_State, _Zip_Code, _Contact_Last_Name,
                _Contact_First_Name, _Contact_Title, _Contact_Phone, _Contact_Fax, _Contact_EMail, _FK_County, _Location_Number,
                _Square_Feet, _Open_Date, _Close_Date, _Assign_Date, _Service_Manager, _Building_Type, _FK_COI_Region, _FK_COI_District,
                _FK_COI_Division, _FK_COI_Tier, _Blanket_Coverage, _Building_Value, _Equipment_Value, _Signage_Value, _Glass_Value,
                _Deductible, _Loss_Of_Income_ALS, _Loss_Of_Income_Months, _Percentage, _Flood_Coverage, _Wind_Hail_Coverage, _Earth_Movement_Coverage,
                _BI_Occurrence, _BI_Aggregate, _Building_Occurrence, _Building_Aggregate, _Building_Deductible, _Equipment_Occurrence,
                _Equipment_Aggregate, _Equipment_Deductible, _Sign_Occurrence, _SIgn_Aggregate, _Glass_Occurrence, _Glass_Aggregate,
                _Ordinance_Law, _Subrogation_Waiver, _Perils_Insured_Form, _Property_On_Acord, _Certificate_Received,
                _Replacement_Costs, _Earthquake_Zone, _Sprinkler, _Alarm, _Lease_Expiration_Tenant, _Lease_Expiration_SubTenant,
                _Date_Purchased, _Date_Leased, _Notes, _Update_Date, _Updated_By, _Glass_ACV, _Leased_Property, _Leased_Building_Limit_Accepted, _B_I_Included_In_Verification);
        }

        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="fK_Table_Name"></param>
        /// <param name="name"></param>
        /// <param name="last_name"></param>
        /// <param name="first_name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipcode"></param>
        /// <returns>DataSet</returns>
        public static DataSet Search(int fK_Table_Name, string name, string last_name, string first_name, string address, string city, int state, string zipcode)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsSearch");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Int32, fK_Table_Name);
            db.AddInParameter(dbCommand, "Name", DbType.String, name);
            db.AddInParameter(dbCommand, "LastName", DbType.String, last_name);
            db.AddInParameter(dbCommand, "FirstName", DbType.String, first_name);
            db.AddInParameter(dbCommand, "Address", DbType.String, address);
            db.AddInParameter(dbCommand, "City", DbType.String, city);
            db.AddInParameter(dbCommand, "State", DbType.Int32, state);
            db.AddInParameter(dbCommand, "ZipCode", DbType.String, zipcode);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects the record having properties with limits and risks
        /// </summary>
        /// <param name="FK_COIs">Perticular COI for which to find the records</param>
        /// <param name="FK_Table_Name">Property Policy for which to find the records,set 0 for all properties.</param>
        /// <returns></returns>
        public static DataSet SelectWithRiskInfo(decimal fK_Table_Name, string table_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_LocationsSelectWithRiskInfo");
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, table_Name);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
