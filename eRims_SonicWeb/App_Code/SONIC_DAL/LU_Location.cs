using System;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;


namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Location table.
    /// </summary>
    public sealed class LU_Location
    {
        #region Enum
        public enum SonicReportType
        {
            WC = 0,
            AL = 1,
            DPD = 2,
            Property = 3,
            PL = 4,
        }
        #endregion

        #region Fields


        private decimal _PK_LU_Location_ID;
        private string _RM_Location_Number;
        private string _Location_Description;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private string _State;
        private string _Zip_Code;
        private string _Dealership_Telephone;
        private string _Year_of_Acquisition;
        private string _County;
        private string _Web_site;
        private string _dba;
        private string _legal_entity;
        private decimal _FK_Regional_Loss_Control_ID;
        private string _ADP_DMS;
        private string _Region;
        private int _Sonic_Location_Code;
        private string _Active;
        private string _Show_On_Dashboard;
        private decimal? _FK_Employee_Id;
        private decimal? _FK_LU_Market;
        private string _Payroll_Codes;
        private string _Parent_Company_LE;
        private string _Parent_Company_LE_FEIN;
        private string _LE_Operations;
        private string _LE_Operations_FEIN;
        private string _LE_Properties;
        private string _LE_Properties_FEIN;

        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_LU_Location_ID value.
        /// </summary>
        public decimal PK_LU_Location_ID
        {
            get { return _PK_LU_Location_ID; }
            set { _PK_LU_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the RM_Location_Number value.
        /// </summary>
        public string RM_Location_Number
        {
            get { return _RM_Location_Number; }
            set { _RM_Location_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Location_Description value.
        /// </summary>
        public string Location_Description
        {
            get { return _Location_Description; }
            set { _Location_Description = value; }
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
        /// Gets or sets the Zip_Code value.
        /// </summary>
        public string Zip_Code
        {
            get { return _Zip_Code; }
            set { _Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Dealership_Telephone value.
        /// </summary>
        public string Dealership_Telephone
        {
            get { return _Dealership_Telephone; }
            set { _Dealership_Telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the Year_of_Acquisition value.
        /// </summary>
        public string Year_of_Acquisition
        {
            get { return _Year_of_Acquisition; }
            set { _Year_of_Acquisition = value; }
        }


        /// <summary> 
        /// Gets or sets the County value.
        /// </summary>
        public string County
        {
            get { return _County; }
            set { _County = value; }
        }


        /// <summary> 
        /// Gets or sets the Web_site value.
        /// </summary>
        public string Web_site
        {
            get { return _Web_site; }
            set { _Web_site = value; }
        }


        /// <summary> 
        /// Gets or sets the dba value.
        /// </summary>
        public string dba
        {
            get { return _dba; }
            set { _dba = value; }
        }


        /// <summary> 
        /// Gets or sets the legal_entity value.
        /// </summary>
        public string legal_entity
        {
            get { return _legal_entity; }
            set { _legal_entity = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Regional_Loss_Control_ID value.
        /// </summary>
        public decimal FK_Regional_Loss_Control_ID
        {
            get { return _FK_Regional_Loss_Control_ID; }
            set { _FK_Regional_Loss_Control_ID = value; }
        }

        /// <summary> 
        /// Gets or sets the ADP_DMS value.
        /// </summary>
        public string ADP_DMS
        {
            get { return _ADP_DMS; }
            set { _ADP_DMS = value; }
        }


        /// <summary> 
        /// Gets or sets the Region value.
        /// </summary>
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        public int Sonic_Location_Code
        {
            get { return _Sonic_Location_Code; }
            set { _Sonic_Location_Code = value; }
        }

        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public string Show_On_Dashboard
        {
            get { return _Show_On_Dashboard; }
            set { _Show_On_Dashboard = value; }
        }

        public decimal? FK_Employee_Id
        {
            get { return _FK_Employee_Id; }
            set { _FK_Employee_Id = value; }
        }

        public decimal? FK_LU_Market
        {
            get { return _FK_LU_Market; }
            set { _FK_LU_Market = value; }
        }

        public string Payroll_Codes
        {
            get { return _Payroll_Codes; }
            set { _Payroll_Codes = value; }
        }

        /// <summary>
        /// Gets or sets Parent_Company_LE value.
        /// </summary>
        public string Parent_Company_LE
        {
            get { return _Parent_Company_LE; }
            set { _Parent_Company_LE = value; }
        }

        /// <summary>
        /// Gets or sets Parent_Company_LE_FEIN value.
        /// </summary>
        public string Parent_Company_LE_FEIN
        {
            get { return _Parent_Company_LE_FEIN; }
            set { _Parent_Company_LE_FEIN = value; }
        }

        /// <summary>
        /// Gets or  Sets LE_Operations value.
        /// </summary>
        public string LE_Operations
        {
            get { return _LE_Operations; }
            set { _LE_Operations = value; }
        }

        /// <summary>
        /// Gets or Sets LE_Operations_FEIN value.
        /// </summary>
        public string LE_Operations_FEIN
        {
            get { return _LE_Operations_FEIN; }
            set { _LE_Operations_FEIN = value; }
        }

        /// <summary>
        /// Gets or Sets LE_Properties value.
        /// </summary>
        public string LE_Properties
        {
            get { return _LE_Properties; }
            set { _LE_Properties = value; }
        }

        /// <summary>
        /// Gets or Sets LE_Properties_FEIN value.
        /// </summary>
        public string LE_Properties_FEIN
        {
            get { return _LE_Properties_FEIN; }
            set { _LE_Properties_FEIN = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the LU_Location class. with the default value.
        /// </summary>
        public LU_Location()
        {

            this._PK_LU_Location_ID = -1;
            this._RM_Location_Number = "";
            this._Location_Description = "";
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._State = "";
            this._Zip_Code = "";
            this._Dealership_Telephone = "";
            this._Year_of_Acquisition = "";
            this._County = "";
            this._Web_site = "";
            this._dba = "";
            this._legal_entity = "";
            this._FK_Regional_Loss_Control_ID = -1;
            this._ADP_DMS = "";
            this._Region = "";
            this._Sonic_Location_Code = -1;
            this._Active = "Y";
            this._Show_On_Dashboard = "";
            this._FK_Employee_Id = null;
            this._Parent_Company_LE="";
            this._Parent_Company_LE_FEIN="";
            this._LE_Operations="";
            this._LE_Operations_FEIN="";
            this._LE_Properties="";
            this._LE_Properties_FEIN="";
        }

        /// <summary> 
        /// Initializes a new instance of the LU_Location class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public LU_Location(decimal PK)
        {
            DataTable dtLU_Location = SelectByPK(PK).Tables[0];

            if (dtLU_Location.Rows.Count > 0)
            {
                DataRow drLU_Location = dtLU_Location.Rows[0];

                this._PK_LU_Location_ID = drLU_Location["PK_LU_Location_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Location["PK_LU_Location_ID"]) : 0;
                this._RM_Location_Number = Convert.ToString(drLU_Location["RM_Location_Number"]);
                this._Location_Description = Convert.ToString(drLU_Location["Location_Description"]);
                this._Address_1 = Convert.ToString(drLU_Location["Address_1"]);
                this._Address_2 = Convert.ToString(drLU_Location["Address_2"]);
                this._City = Convert.ToString(drLU_Location["City"]);
                this._State = Convert.ToString(drLU_Location["State"]);
                this._Zip_Code = Convert.ToString(drLU_Location["Zip_Code"]);
                this._Dealership_Telephone = Convert.ToString(drLU_Location["Dealership_Telephone"]);
                this._Year_of_Acquisition = Convert.ToString(drLU_Location["Year_of_Acquisition"]);
                this._County = Convert.ToString(drLU_Location["County"]);
                this._Web_site = Convert.ToString(drLU_Location["Web_site"]);
                this._dba = Convert.ToString(drLU_Location["dba"]);
                this._legal_entity = Convert.ToString(drLU_Location["legal_entity"]);
                this._FK_Regional_Loss_Control_ID = drLU_Location["FK_Regional_Loss_Control_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Location["FK_Regional_Loss_Control_ID"]) : 0;
                this._ADP_DMS = Convert.ToString(drLU_Location["ADP_DMS"]);
                this.Region = Convert.ToString(drLU_Location["Region"]);
                this._Sonic_Location_Code = drLU_Location["Sonic_Location_Code"] != DBNull.Value ? Convert.ToInt32(drLU_Location["Sonic_Location_Code"]) : 0;
                this._Active = drLU_Location["Active"] != DBNull.Value ? Convert.ToString(drLU_Location["Active"]) : "Y";
                this._Show_On_Dashboard = Convert.ToString(drLU_Location["Show_On_Dashboard"]);
                if (drLU_Location["FK_Employee_Id"] != DBNull.Value) this._FK_Employee_Id = Convert.ToDecimal(drLU_Location["FK_Employee_Id"]);
                this._FK_LU_Market = drLU_Location["FK_LU_Market"] != DBNull.Value ? Convert.ToDecimal(drLU_Location["FK_LU_Market"]) : 0;
                this._Parent_Company_LE = Convert.ToString(drLU_Location["Parent_Company_LE"]);
                this._Parent_Company_LE_FEIN = Convert.ToString(drLU_Location["Parent_Company_LE_FEIN"]);
                this._LE_Operations = Convert.ToString(drLU_Location["LE_Operations"]);
                this._LE_Operations_FEIN = Convert.ToString(drLU_Location["LE_Operations_FEIN"]);
                this._LE_Properties = Convert.ToString(drLU_Location["LE_Properties"]);
                this._LE_Properties_FEIN = Convert.ToString(drLU_Location["LE_Properties_FEIN"]);
            }

            else
            {
                this._PK_LU_Location_ID = -1;
                this._RM_Location_Number = "";
                this._Location_Description = "";
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._State = "";
                this._Zip_Code = "";
                this._Dealership_Telephone = "";
                this._Year_of_Acquisition = "";
                this._County = "";
                this._Web_site = "";
                this._dba = "";
                this._legal_entity = "";
                this._FK_Regional_Loss_Control_ID = -1;
                this._ADP_DMS = "";
                this._Region = "";
                this._Sonic_Location_Code = -1;
                this._Active = "Y";
                this._Show_On_Dashboard = "";
                this._FK_Employee_Id = null;
                this._FK_LU_Market = null;
                this._Parent_Company_LE = "";
                this._Parent_Company_LE_FEIN = "";
                this._LE_Operations = "";
                this._LE_Operations_FEIN = "";
                this._LE_Properties = "";
                this._LE_Properties_FEIN = "";
            }
        }

        /// <summary> 
        /// Initializes a new instance of the LU_Location class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public LU_Location(int Sonic_Location_Code)
        {
            DataTable dtLU_Location = SelectBySonicLocationCode(Sonic_Location_Code).Tables[0];

            if (dtLU_Location.Rows.Count > 0)
            {
                DataRow drLU_Location = dtLU_Location.Rows[0];

                this._PK_LU_Location_ID = drLU_Location["PK_LU_Location_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Location["PK_LU_Location_ID"]) : 0;
                this._RM_Location_Number = Convert.ToString(drLU_Location["RM_Location_Number"]);
                this._Location_Description = Convert.ToString(drLU_Location["Location_Description"]);
                this._Address_1 = Convert.ToString(drLU_Location["Address_1"]);
                this._Address_2 = Convert.ToString(drLU_Location["Address_2"]);
                this._City = Convert.ToString(drLU_Location["City"]);
                this._State = Convert.ToString(drLU_Location["State"]);
                this._Zip_Code = Convert.ToString(drLU_Location["Zip_Code"]);
                this._Dealership_Telephone = Convert.ToString(drLU_Location["Dealership_Telephone"]);
                this._Year_of_Acquisition = Convert.ToString(drLU_Location["Year_of_Acquisition"]);
                this._County = Convert.ToString(drLU_Location["County"]);
                this._Web_site = Convert.ToString(drLU_Location["Web_site"]);
                this._dba = Convert.ToString(drLU_Location["dba"]);
                this._legal_entity = Convert.ToString(drLU_Location["legal_entity"]);
                this._FK_Regional_Loss_Control_ID = drLU_Location["FK_Regional_Loss_Control_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Location["FK_Regional_Loss_Control_ID"]) : 0;
                this._ADP_DMS = Convert.ToString(drLU_Location["ADP_DMS"]);
                this.Region = Convert.ToString(drLU_Location["Region"]);
                this._Sonic_Location_Code = drLU_Location["Sonic_Location_Code"] != DBNull.Value ? Convert.ToInt32(drLU_Location["Sonic_Location_Code"]) : 0;
                this._Active = drLU_Location["Active"] != DBNull.Value ? Convert.ToString(drLU_Location["Active"]) : "Y";
                this._Show_On_Dashboard = Convert.ToString(drLU_Location["Show_On_Dashboard"]);
                if (drLU_Location["FK_Employee_Id"] != DBNull.Value) this._FK_Employee_Id = Convert.ToDecimal(drLU_Location["FK_Employee_Id"]);
                this._Parent_Company_LE = Convert.ToString(drLU_Location["Parent_Company_LE"]);
                this._Parent_Company_LE_FEIN = Convert.ToString(drLU_Location["Parent_Company_LE_FEIN"]);
                this._LE_Operations = Convert.ToString(drLU_Location["LE_Operations"]);
                this._LE_Operations_FEIN = Convert.ToString(drLU_Location["LE_Operations_FEIN"]);
                this._LE_Properties = Convert.ToString(drLU_Location["LE_Properties"]);
                this._LE_Properties_FEIN = Convert.ToString(drLU_Location["LE_Properties_FEIN"]);
            }
            else
            {

                this._PK_LU_Location_ID = -1;
                this._RM_Location_Number = "";
                this._Location_Description = "";
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._State = "";
                this._Zip_Code = "";
                this._Dealership_Telephone = "";
                this._Year_of_Acquisition = "";
                this._County = "";
                this._Web_site = "";
                this._dba = "";
                this._legal_entity = "";
                this._FK_Regional_Loss_Control_ID = -1;
                this._ADP_DMS = "";
                this._Region = "";
                this._Sonic_Location_Code = -1;
                this._Active = "Y";
                this._Show_On_Dashboard = "";
                this._FK_Employee_Id = null;
                this._Parent_Company_LE = "";
                this._Parent_Company_LE_FEIN = "";
                this._LE_Operations = "";
                this._LE_Operations_FEIN = "";
                this._LE_Properties = "";
                this._LE_Properties_FEIN = "";
            }

        }

        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the LU_Location table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationInsert");

            db.AddInParameter(dbCommand, "RM_Location_Number", DbType.String, this._RM_Location_Number);
            db.AddInParameter(dbCommand, "Location_Description", DbType.String, this._Location_Description);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, this._City);
            db.AddInParameter(dbCommand, "State", DbType.String, this._State);
            db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
            db.AddInParameter(dbCommand, "Dealership_Telephone", DbType.String, this._Dealership_Telephone);
            db.AddInParameter(dbCommand, "Year_of_Acquisition", DbType.String, this._Year_of_Acquisition);
            db.AddInParameter(dbCommand, "County", DbType.String, this._County);
            db.AddInParameter(dbCommand, "Web_site", DbType.String, this._Web_site);
            db.AddInParameter(dbCommand, "dba", DbType.String, this._dba);
            db.AddInParameter(dbCommand, "legal_entity", DbType.String, this._legal_entity);
            db.AddInParameter(dbCommand, "ADP_DMS", DbType.String, this._ADP_DMS);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, this._Sonic_Location_Code);
            db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
            db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, clsSession.UserName);
            db.AddInParameter(dbCommand, "UpdatedDate", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Show_On_Dashboard", DbType.String, this._Show_On_Dashboard);

            if (this._FK_Employee_Id != null)
                db.AddInParameter(dbCommand, "FK_Employee_Id", DbType.Decimal, this._FK_Employee_Id);
            else
                db.AddInParameter(dbCommand, "FK_Employee_Id", DbType.Decimal, DBNull.Value);

            db.AddInParameter(dbCommand, "FK_LU_Market", DbType.Decimal, this._FK_LU_Market);

            db.AddInParameter(dbCommand, "Parent_Company_LE", DbType.String, this._Parent_Company_LE);
            db.AddInParameter(dbCommand, "Parent_Company_LE_FEIN", DbType.String, this._Parent_Company_LE_FEIN);
            db.AddInParameter(dbCommand, "LE_Operations", DbType.String, this._LE_Operations);
            db.AddInParameter(dbCommand, "LE_Operations_FEIN", DbType.String, this._LE_Operations_FEIN);
            db.AddInParameter(dbCommand, "LE_Properties", DbType.String, this._LE_Properties);
            db.AddInParameter(dbCommand, "LE_Properties_FEIN", DbType.String, this._LE_Properties_FEIN);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Location table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a records from the LU_Location table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAuditByPK(decimal pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_AuditTrial_SelectALL");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(Nullable<decimal> CurrentEmployee, string Regional)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectAll");
            db.AddInParameter(dbCommand, "CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "Regional", DbType.String, Regional);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table for SLT Module Page.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll_SLT(Nullable<decimal> CurrentEmployee, string Regional)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectAll_SLT");
            db.AddInParameter(dbCommand, "CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "Regional", DbType.String, Regional);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByRegion(Nullable<decimal> CurrentEmployee, string Regional)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_SelectByRegoin");
            db.AddInParameter(dbCommand, "CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "Regional", DbType.String, Regional);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table. for event search screen
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectAllforEvent");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllForExposures(Nullable<decimal> CurrentEmployee, string Regional)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectAllForExposures");
            db.AddInParameter(dbCommand, "CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "Regional", DbType.String, Regional);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllForAdhoc(Nullable<decimal> CurrentEmployee, string Regional)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectAllForAdhoc");
            db.AddInParameter(dbCommand, "CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "Regional", DbType.String, Regional);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllDealership(string Region)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_SelectAllDealership");
            db.AddInParameter(dbCommand, "Region", DbType.String, Region);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByRegionForDashboard(string Region)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select dba, Sonic_Location_Code,Region from LU_Location where Region = '" + Region + "' and Show_On_Dashboard = 'Y'");
            return db.ExecuteDataSet(dbCommand);
        }
        
        public static DataSet SelectAllDealershipByUser()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectDealershipByLocation");
            //db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }
        
        public static DataSet SelectAllDealershipByUser(decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_SelectAllDealershipBySecurityID");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            //db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectDealershipDBA(string DBA, string City, string State, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DealershipSearch");
            db.AddInParameter(dbCommand, "DBA", DbType.String, DBA);
            db.AddInParameter(dbCommand, "City", DbType.String, City);
            db.AddInParameter(dbCommand, "State", DbType.String, State);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table for dealership
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllDealership(decimal FK_LU_Location_Id, decimal FK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_SelectAllDealer");
            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, FK_LU_Location_Id);
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, FK_Purchasing_Service_Contract);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet LegalEntity()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetLegalEntity");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet LegalEntityForFranchiseReport(decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetLegalEntityForFranchiseReport");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet LegalEntityForFranchiseReportByPK_Location(decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_GetLegalEntityForFranchiseReport");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet DealershipDBAEntity(decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetDistinctDBAEntity");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SonicLocationCode(decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetDistinctSonic_Location_CodeEntity");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Location table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, this._PK_LU_Location_ID);
            db.AddInParameter(dbCommand, "RM_Location_Number", DbType.String, this._RM_Location_Number);
            db.AddInParameter(dbCommand, "Location_Description", DbType.String, this._Location_Description);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, this._City);
            db.AddInParameter(dbCommand, "State", DbType.String, this._State);
            db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
            db.AddInParameter(dbCommand, "Dealership_Telephone", DbType.String, this._Dealership_Telephone);
            db.AddInParameter(dbCommand, "Year_of_Acquisition", DbType.String, this._Year_of_Acquisition);
            db.AddInParameter(dbCommand, "County", DbType.String, this._County);
            db.AddInParameter(dbCommand, "Web_site", DbType.String, this._Web_site);
            db.AddInParameter(dbCommand, "dba", DbType.String, this._dba);
            db.AddInParameter(dbCommand, "legal_entity", DbType.String, this._legal_entity);
            db.AddInParameter(dbCommand, "ADP_DMS", DbType.String, this._ADP_DMS);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, this._Sonic_Location_Code);
            db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, clsSession.UserName);

            db.AddInParameter(dbCommand, "UpdatedDate", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Show_On_Dashboard", DbType.String, this._Show_On_Dashboard);
            if (this._FK_Employee_Id != null)
                db.AddInParameter(dbCommand, "FK_Employee_Id", DbType.Decimal, this._FK_Employee_Id);
            else
                db.AddInParameter(dbCommand, "FK_Employee_Id", DbType.Decimal, DBNull.Value);

            db.AddInParameter(dbCommand, "FK_LU_Market", DbType.Decimal, this._FK_LU_Market);

            db.AddInParameter(dbCommand, "Parent_Company_LE", DbType.String, this._Parent_Company_LE);
            db.AddInParameter(dbCommand, "Parent_Company_LE_FEIN", DbType.String, this._Parent_Company_LE_FEIN);
            db.AddInParameter(dbCommand, "LE_Operations", DbType.String, this._LE_Operations);
            db.AddInParameter(dbCommand, "LE_Operations_FEIN", DbType.String, this._LE_Operations_FEIN);
            db.AddInParameter(dbCommand, "LE_Properties", DbType.String, this._LE_Properties);
            db.AddInParameter(dbCommand, "LE_Properties_FEIN", DbType.String, this._LE_Properties_FEIN);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Location table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByRMLocationNumber(string rmLocationNumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectByRMLocationNumber");

            db.AddInParameter(dbCommand, "RM_Location_Number", DbType.String, rmLocationNumber);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetRecipientEmailID(decimal Lu_Location_ID, SonicReportType ReportType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetRecipientEmailID");

            db.AddInParameter(dbCommand, "Lu_Location_ID", DbType.Decimal, Lu_Location_ID);
            db.AddInParameter(dbCommand, "ReportType", DbType.String, ReportType);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetRegionList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetLu_Location_RegionList");

            return db.ExecuteDataSet(dbCommand); 
        }

        public static DataSet GetRegionListByUser(decimal pk_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select * from [dbo].GetRegionsForClaimReports(" + pk_Security_ID.ToString() + ")");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectBySonicLocationCode(Int32 Sonic_Location_Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectBySonicLocationCode");

            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, Sonic_Location_Code);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAllLocation()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_FKASelectAllLocation");

            return db.ExecuteDataSet(dbCommand);
        }

        public static bool CheckEnvironmentRecord(decimal pk_Lu_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Lu_Location_CheckEnviromentExist");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, pk_Lu_Location_ID);

            return Convert.ToInt16(db.ExecuteScalar(dbCommand)) > 0;
        }

        public static DataSet SelectCost_Center()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Lu_LocationFillCost_Center");

            return db.ExecuteDataSet(dbCommand);
        }


        public static DataSet SelectAllLocationOnPropertyCope()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_SelectAllLocationOnPropertyCope");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAllDBA()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT PK_LU_Location_ID, dba FROM LU_Location order by dba");

            return db.ExecuteDataSet(dbCommand);
        }


        public static DataSet SelectSonicLocationDBA()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SonicLocationDBA");

            return db.ExecuteDataSet(dbCommand);
        }



        public static DataSet SelectSonicLocationCode()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SonicLocationCode");

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectNewLocationForPremiumAllocation(Nullable<decimal> CurrentEmployee, string Regional, int? Year, string Action)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectNewLocationForPremiumAllocation");
            db.AddInParameter(dbCommand, "CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "Regional", DbType.String, Regional);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Action", DbType.String, Action);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetAllRlcm()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAllRlcm");
            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// For Premium Allocation Worksheet Template Export 
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllActiveLocation()//For Premium Allocation Worksheet Template Export 
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectAllLocation");
            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectPayrollByLocation(decimal pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Lu_Location_SelectPayrollByLocation");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }
              
        public void InsertUpdatePayrollByLocation()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_InsertUpdatePayroll");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._PK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Payroll_Codes", DbType.String, this._Payroll_Codes);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectStateMarketByLocationID(decimal pk_Lu_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectStateMarketByLocationID");
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pk_Lu_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }


        public static DataSet SelectAllDealershipByUserAndLocationId(decimal PK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectDealershipByLocationAndId");
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, PK_LU_Location_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectLocation_By_RLCM(decimal? fK_Employee_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Location_By_RLCM");

            db.AddInParameter(dbCommand, "FK_Employee_Id", DbType.Decimal, fK_Employee_Id);
            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

      /// <summary>
      /// get dataset by location and phone number
      /// </summary>
      /// <param name="location"></param>
      /// <param name="phoneNumber"></param>
      /// <returns></returns>
        public static DataSet SelectByPhoneNumberAndLocation(string location, string phoneNumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_MappingSelectPK");

            db.AddInParameter(dbCommand, "Building_Location_Conjuction", DbType.String, location);
            db.AddInParameter(dbCommand, "Phone_Number", DbType.String, phoneNumber);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetActiveRegionList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetActive_RegionList");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByRegionandMarket(string Regional, string MarketPKs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ActiveLocationByRegoin");
            db.AddInParameter(dbCommand, "Regional", DbType.String, Regional);
            db.AddInParameter(dbCommand, "MarketPKs", DbType.String, MarketPKs);
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}
