using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Security table.
    /// </summary>
    public sealed class Security
    {
        #region Fields

        private decimal _PK_Security_ID;
        private string _FIRST_NAME;
        private string _LAST_NAME;
        private string _USER_NAME;
        private string _PASSWORD;
        private decimal _USER_ROLE;
        private string _UPDATED_BY;
        private DateTime _UPDATE_DATE;
        private string _Cost_Center;
        private string _Email;
        private string _Phone;
        private bool _Allow_ViewClaim;
        private Nullable<decimal> _Employee_Id;
        private bool _IsRegionalOfficer;
        private string _AllowedReportType;
        private string _Region;
        private string _Corporate_User;
        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Security_ID value.
        /// </summary>
        public decimal PK_Security_ID
        {
            get { return _PK_Security_ID; }
            set { _PK_Security_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FIRST_NAME value.
        /// </summary>
        public string FIRST_NAME
        {
            get { return _FIRST_NAME; }
            set { _FIRST_NAME = value; }
        }


        /// <summary> 
        /// Gets or sets the LAST_NAME value.
        /// </summary>
        public string LAST_NAME
        {
            get { return _LAST_NAME; }
            set { _LAST_NAME = value; }
        }


        /// <summary> 
        /// Gets or sets the USER_NAME value.
        /// </summary>
        public string USER_NAME
        {
            get { return _USER_NAME; }
            set { _USER_NAME = value; }
        }


        /// <summary> 
        /// Gets or sets the PASSWORD value.
        /// </summary>
        public string PASSWORD
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; }
        }


        /// <summary> 
        /// Gets or sets the USER_ROLE value.
        /// </summary>
        public decimal USER_ROLE
        {
            get { return _USER_ROLE; }
            set { _USER_ROLE = value; }
        }


        /// <summary> 
        /// Gets or sets the UPDATED_BY value.
        /// </summary>
        public string UPDATED_BY
        {
            get { return _UPDATED_BY; }
            set { _UPDATED_BY = value; }
        }


        /// <summary> 
        /// Gets or sets the UPDATE_DATE value.
        /// </summary>
        public DateTime UPDATE_DATE
        {
            get { return _UPDATE_DATE; }
            set { _UPDATE_DATE = value; }
        }


        /// <summary> 
        /// Gets or sets the Cost_Center value.
        /// </summary>
        public string Cost_Center
        {
            get { return _Cost_Center; }
            set { _Cost_Center = value; }
        }


        /// <summary> 
        /// Gets or sets the Email value.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        /// <summary> 
        /// Gets or sets the Phone value.
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        /// <summary> 
        /// Gets or sets the Allow_ViewClaim value.
        /// </summary>
        public Boolean Allow_ViewClaim
        {
            get { return _Allow_ViewClaim; }
            set { _Allow_ViewClaim = value; }
        }

        /// <summary>
        /// Gets  or Sets the EMployee Value 
        /// </summary>
        public Nullable<decimal> Employee_Id
        {
            get { return _Employee_Id; }
            set { _Employee_Id = value; }
        }

        /// <summary>
        /// get and set Is Regional Officer
        /// </summary>
        public Boolean IsRegionalOfficer
        {
            get { return _IsRegionalOfficer; }
            set { _IsRegionalOfficer = value; }
        }


        /// <summary> 
        /// Gets or sets the Report Type Allowed for User.
        /// </summary>
        public string AllowedReportType
        {
            get { return _AllowedReportType; }
            set { _AllowedReportType = value; }
        }

        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        public string Corporate_User
        {
            get { return _Corporate_User; }
            set { _Corporate_User = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Security class. with the default value.
        /// </summary>
        public Security()
        {
            setDefaultValues();
        }

        /// <summary> 
        /// Initializes a new instance of the Security class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Security(decimal PK)
        {
            DataTable dtSecurity = SelectByPK(PK).Tables[0];
            if (dtSecurity.Rows.Count > 0)
            {
                DataRow drSecurity = dtSecurity.Rows[0];

                this._PK_Security_ID = drSecurity["PK_Security_ID"] != DBNull.Value ? Convert.ToDecimal(drSecurity["PK_Security_ID"]) : 0;
                this._FIRST_NAME = Convert.ToString(drSecurity["FIRST_NAME"]);
                this._LAST_NAME = Convert.ToString(drSecurity["LAST_NAME"]);
                this._USER_NAME = Convert.ToString(drSecurity["USER_NAME"]);
                this._PASSWORD = Convert.ToString(drSecurity["PASSWORD"]);
                this._USER_ROLE = drSecurity["USER_ROLE"] != DBNull.Value ? Convert.ToDecimal(drSecurity["USER_ROLE"]) : 0;
                this._UPDATED_BY = Convert.ToString(drSecurity["UPDATED_BY"]);
                this._UPDATE_DATE = drSecurity["UPDATE_DATE"] != DBNull.Value ? Convert.ToDateTime(drSecurity["UPDATE_DATE"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Cost_Center = Convert.ToString(drSecurity["Cost_Center"]);
                this._Email = Convert.ToString(drSecurity["Email"]);
                this._Phone = Convert.ToString(drSecurity["Phone"]);
                this._Allow_ViewClaim = Convert.ToBoolean(drSecurity["Allow_ViewClaim"]);
                if (drSecurity["Employee_Id"] != DBNull.Value)
                    this._Employee_Id = Convert.ToDecimal(drSecurity["Employee_Id"]);
                if (drSecurity["IsRegionalOfficer"] != DBNull.Value)
                    this._IsRegionalOfficer = Convert.ToBoolean(drSecurity["IsRegionalOfficer"]);
                this._AllowedReportType = Convert.ToString(drSecurity["AllowedReportType"]);
                this._Region = Convert.ToString(drSecurity["Region"]);
                this._Corporate_User = Convert.ToString(drSecurity["Corporate_User"]);
            }
            else
            {
                setDefaultValues();
            }
        }

        /// <summary> 
        /// Initializes a new instance of the Security class for passed User Name with the values set from Database.
        /// </summary>
        public Security(string pUSER_NAME,bool IsUserID)
        {
            DataTable dtSecurity = SelectByUserName(pUSER_NAME,PK_Security_ID).Tables[0];
            if (dtSecurity.Rows.Count > 0)
            {
                DataRow drSecurity = dtSecurity.Rows[0];

                this._PK_Security_ID = drSecurity["PK_Security_ID"] != DBNull.Value ? Convert.ToDecimal(drSecurity["PK_Security_ID"]) : 0;
                this._FIRST_NAME = Convert.ToString(drSecurity["FIRST_NAME"]);
                this._LAST_NAME = Convert.ToString(drSecurity["LAST_NAME"]);
                this._USER_NAME = Convert.ToString(drSecurity["USER_NAME"]);
                this._PASSWORD = Convert.ToString(drSecurity["PASSWORD"]);
                this._USER_ROLE = drSecurity["USER_ROLE"] != DBNull.Value ? Convert.ToDecimal(drSecurity["USER_ROLE"]) : 0;
                this._UPDATED_BY = Convert.ToString(drSecurity["UPDATED_BY"]);
                this._UPDATE_DATE = drSecurity["UPDATE_DATE"] != DBNull.Value ? Convert.ToDateTime(drSecurity["UPDATE_DATE"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Cost_Center = Convert.ToString(drSecurity["Cost_Center"]);
                this._Email = Convert.ToString(drSecurity["Email"]);
                this._Phone = Convert.ToString(drSecurity["Phone"]);
                this._Allow_ViewClaim = Convert.ToBoolean(drSecurity["Allow_ViewClaim"]);
                if (drSecurity["Employee_Id"] != DBNull.Value)
                    this._Employee_Id = Convert.ToDecimal(drSecurity["Employee_Id"]);
                if (drSecurity["IsRegionalOfficer"] != DBNull.Value)
                    this._IsRegionalOfficer = Convert.ToBoolean(drSecurity["IsRegionalOfficer"]);
                this._AllowedReportType = Convert.ToString(drSecurity["AllowedReportType"]);
                this._Corporate_User = Convert.ToString(drSecurity["Corporate_User"]);
            }
            else
            {
                setDefaultValues();
            }
        }

        #endregion

        #region Methods

        private void setDefaultValues()
        {
            this._PK_Security_ID = -1;
            this._FIRST_NAME = "";
            this._LAST_NAME = "";
            this._USER_NAME = "";
            this._PASSWORD = "";
            this._USER_ROLE = -1;
            this._UPDATED_BY = "";
            this._UPDATE_DATE = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Cost_Center = "";
            this._Email = "";
            this._Phone = "";
            this._Allow_ViewClaim = false;
            this.Employee_Id = -1;
            this._IsRegionalOfficer = false;
            this._AllowedReportType = "";
            this._Region = "";
            this._Corporate_User = "";
        }

        /// <summary>
        /// Inserts a record into the Security table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SecurityInsert");

            db.AddInParameter(dbCommand, "FIRST_NAME", DbType.String, this._FIRST_NAME);
            db.AddInParameter(dbCommand, "LAST_NAME", DbType.String, this._LAST_NAME);
            db.AddInParameter(dbCommand, "USER_NAME", DbType.String, this._USER_NAME);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, this._PASSWORD);
            db.AddInParameter(dbCommand, "USER_ROLE", DbType.Decimal, this._USER_ROLE);
            db.AddInParameter(dbCommand, "UPDATED_BY", DbType.String, this._UPDATED_BY);
            db.AddInParameter(dbCommand, "UPDATE_DATE", DbType.DateTime, this._UPDATE_DATE);
            db.AddInParameter(dbCommand, "Cost_Center", DbType.String, this._Cost_Center);
            db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
            db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
            db.AddInParameter(dbCommand, "Allow_ViewClaim", DbType.Boolean, this._Allow_ViewClaim);
            if (this._Employee_Id != null)
                db.AddInParameter(dbCommand, "Employee_Id", DbType.Decimal, this._Employee_Id);
            else
                db.AddInParameter(dbCommand, "Employee_Id", DbType.Decimal, System.DBNull.Value);
            db.AddInParameter(dbCommand, "IsRegionalOfficer", DbType.Boolean, this._IsRegionalOfficer);
            db.AddInParameter(dbCommand, "AllowedReportType", DbType.String, this._AllowedReportType);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Corporate_User", DbType.String, this._Corporate_User);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Security table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SecuritySelectByPK");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Security table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUserName(string pUser_Name, decimal pkSecurityID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SecuritySelectByUserName");

            db.AddInParameter(dbCommand, "User_Name", DbType.String, pUser_Name);

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pkSecurityID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_SelectAll");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByModuleRights(string ModuleName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_SelectByModuleRights");
            db.AddInParameter(dbCommand, "@ModuleName", DbType.String, ModuleName);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Security table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(string SearchString, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SecuritySelectAll");
            db.AddInParameter(dbCommand, "@SearchString", DbType.String, SearchString);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Security table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SecurityUpdate");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, this._PK_Security_ID);
            db.AddInParameter(dbCommand, "FIRST_NAME", DbType.String, this._FIRST_NAME);
            db.AddInParameter(dbCommand, "LAST_NAME", DbType.String, this._LAST_NAME);
            db.AddInParameter(dbCommand, "USER_NAME", DbType.String, this._USER_NAME);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, this._PASSWORD);
            db.AddInParameter(dbCommand, "USER_ROLE", DbType.Decimal, this._USER_ROLE);
            db.AddInParameter(dbCommand, "UPDATED_BY", DbType.String, this._UPDATED_BY);
            db.AddInParameter(dbCommand, "UPDATE_DATE", DbType.DateTime, this._UPDATE_DATE);
            db.AddInParameter(dbCommand, "Cost_Center", DbType.String, this._Cost_Center);
            db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
            db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
            db.AddInParameter(dbCommand, "Allow_ViewClaim", DbType.Boolean, this._Allow_ViewClaim);
            if (this._Employee_Id != null)
                db.AddInParameter(dbCommand, "Employee_Id", DbType.Decimal, this._Employee_Id);
            else
                db.AddInParameter(dbCommand, "Employee_Id", DbType.Decimal, System.DBNull.Value);
            db.AddInParameter(dbCommand, "IsRegionalOfficer", DbType.Boolean, this._IsRegionalOfficer);
            db.AddInParameter(dbCommand, "AllowedReportType", DbType.String, this._AllowedReportType);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Corporate_User", DbType.String, this._Corporate_User);
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the Security table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SecurityDeleteByPK");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pK_Security_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Security table by a composite primary key.
        /// </summary>
        public static void DeleteByPKs(string pK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SecurityDeleteByPKs");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.String, pK_Security_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static int GetLoginID(string strUserName, string strPassword)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SecurityGetLoginID");

            db.AddInParameter(dbCommand, "strUserID", DbType.String, strUserName);
            db.AddInParameter(dbCommand, "strPassword", DbType.String, strPassword);
            db.AddOutParameter(dbCommand, "intUserID", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["@intUserID"].Value);
        }

        /// <summary>
        /// Get Data BY username and pwd
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static DataSet GetLoginData(string strUserName, string strPassword)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetSecurityDataByLoginID");

            db.AddInParameter(dbCommand, "strUserID", DbType.String, strUserName);
            db.AddInParameter(dbCommand, "strPassword", DbType.String, strPassword);
            db.ExecuteNonQuery(dbCommand);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// select user rights by user id
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectRightsByUserID(decimal UserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetUserAccess");

            db.AddInParameter(dbCommand, "User_ID", DbType.Decimal, UserID);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// select user rights by user id
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectGroupByUserID(decimal UserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetGroupUserAccess");

            db.AddInParameter(dbCommand, "User_ID", DbType.Decimal, UserID);

            return db.ExecuteDataSet(dbCommand);
        }
        
        /// <summary>
        /// Updates a record in the Security table.
        /// </summary>
        public static void UpdatePassword(decimal PK_Security_ID, string PASSWORD, DateTime UPDATE_DATE)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SecurityPasswordUpdate");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, PASSWORD);
            db.AddInParameter(dbCommand, "UPDATE_DATE", DbType.DateTime, UPDATE_DATE);
            db.ExecuteScalar(dbCommand);
        }

        public static DataSet GetRegionalOfficerRegions(decimal decPKSecurity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select Region from Regional_Access where FK_Security_ID = " + decPKSecurity.ToString());
            //dbCommand.
            //    //db.("GetRegionsForClaimReports");

            //db.AddInParameter(dbCommand, "@PK_Security_ID", DbType.Decimal, decPKSecurity);

            return db.ExecuteDataSet(dbCommand);

        }
        public static DataSet GetSecurityByEmployee_ID(decimal decPKEmployee_id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select top 1 * from security where Employee_Id = " + decPKEmployee_id.ToString());
            //dbCommand.
            //    //db.("GetRegionsForClaimReports");

            //db.AddInParameter(dbCommand, "@PK_Security_ID", DbType.Decimal, decPKSecurity);

            return db.ExecuteDataSet(dbCommand);

        }

        public static bool ValidateUserDiary(int Pk_Security_Id)
        {
            bool bReturn = false;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ValidateUserDiary");

            db.AddInParameter(dbCommand, "Pk_Security_Id", DbType.Int32, Pk_Security_Id);
            DataSet ds = db.ExecuteDataSet(dbCommand);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                bReturn = Convert.ToBoolean(ds.Tables[0].Rows[0]["isValidate"]);
            }
            return bReturn; 
        }

        public static bool IsUserPurchasingAdmin(decimal PK_Security_ID)
        {
            bool bReturn = false;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetPurchasingUserGroups");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            DataSet dsGroups = db.ExecuteDataSet(dbCommand);

            if (dsGroups.Tables[0] != null)
            {
                if (dsGroups.Tables[0].Rows.Count > 0)
                {
                    string strGroups = Convert.ToString(dsGroups.Tables[0].Rows[0][0]);
                    if (strGroups.IndexOf("Purchasing Administrator") > -1 && strGroups.IndexOf("Administrative") == -1)
                        bReturn = true;
                    else
                        bReturn = false;
                }
            }

            return bReturn;
        }

        public static DataSet GetEmailsByLocation(decimal? FK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetEmailsByLocation");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetEmailsByLocationForEvent(decimal? FK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetEmailsByLocationForEvent");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}
