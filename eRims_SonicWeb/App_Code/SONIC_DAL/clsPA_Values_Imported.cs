using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace ERIMS_DAL
{
    /// <summary>
    /// Data access class for PA_Values_Imported table.
    /// </summary>
    public sealed class clsPA_Values_Imported
    {

        #region Private variables used to hold the property values

        private decimal? _PK_PA_Values_Imported;
        private int? _Sonic_Location_Code;
        private int? _Year;
        private decimal? _Non_Texas_Payroll;
        private decimal? _Texas_Payroll;
        private int? _Number_Of_Employees;
        private DateTime? _Update_Date;
        private string _Updated_By;
        private string _SonicLocationdba;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_PA_Values_Imported value.
        /// </summary>
        public decimal? PK_PA_Values_Imported
        {
            get { return _PK_PA_Values_Imported; }
            set { _PK_PA_Values_Imported = value; }
        }

        /// <summary>
        /// Gets or sets the Sonic_Location_Code value.
        /// </summary>
        public int? Sonic_Location_Code
        {
            get { return _Sonic_Location_Code; }
            set { _Sonic_Location_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Year value.
        /// </summary>
        public int? Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        /// <summary>
        /// Gets or sets the Non_Texas_Payroll value.
        /// </summary>
        public decimal? Non_Texas_Payroll
        {
            get { return _Non_Texas_Payroll; }
            set { _Non_Texas_Payroll = value; }
        }

        /// <summary>
        /// Gets or sets the Texas_Payroll value.
        /// </summary>
        public decimal? Texas_Payroll
        {
            get { return _Texas_Payroll; }
            set { _Texas_Payroll = value; }
        }

        /// <summary>
        /// Gets or sets the Number_Of_Employees value.
        /// </summary>
        public int? Number_Of_Employees
        {
            get { return _Number_Of_Employees; }
            set { _Number_Of_Employees = value; }
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
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        public string SonicLocationdba
        {
            get { return _SonicLocationdba; }
            set { _SonicLocationdba = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsPA_Values_Imported class with default value.
        /// </summary>
        public clsPA_Values_Imported()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsPA_Values_Imported class based on Primary Key.
        /// </summary>
        public clsPA_Values_Imported(decimal pK_PA_Values_Imported)
        {
            DataTable dtPA_Values_Imported = SelectByPK(pK_PA_Values_Imported).Tables[0];

            if (dtPA_Values_Imported.Rows.Count == 1)
            {
                SetValue(dtPA_Values_Imported.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsPA_Values_Imported class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drPA_Values_Imported)
        {
            if (drPA_Values_Imported["PK_PA_Values_Imported"] == DBNull.Value)
                this._PK_PA_Values_Imported = null;
            else
                this._PK_PA_Values_Imported = (decimal?)drPA_Values_Imported["PK_PA_Values_Imported"];

            if (drPA_Values_Imported["Sonic_Location_Code"] == DBNull.Value)
                this._Sonic_Location_Code = null;
            else
                this._Sonic_Location_Code = (int?)drPA_Values_Imported["Sonic_Location_Code"];

            if (drPA_Values_Imported["dba"] == DBNull.Value)
                this._SonicLocationdba = null;
            else
                this._SonicLocationdba = (string)drPA_Values_Imported["dba"];


            if (drPA_Values_Imported["Year"] == DBNull.Value)
                this._Year = null;
            else
                this._Year = (int?)drPA_Values_Imported["Year"];

            if (drPA_Values_Imported["Non_Texas_Payroll"] == DBNull.Value)
                this._Non_Texas_Payroll = null;
            else
                this._Non_Texas_Payroll = (decimal?)drPA_Values_Imported["Non_Texas_Payroll"];

            if (drPA_Values_Imported["Texas_Payroll"] == DBNull.Value)
                this._Texas_Payroll = null;
            else
                this._Texas_Payroll = (decimal?)drPA_Values_Imported["Texas_Payroll"];

            if (drPA_Values_Imported["Number_Of_Employees"] == DBNull.Value)
                this._Number_Of_Employees = null;
            else
                this._Number_Of_Employees = (int?)drPA_Values_Imported["Number_Of_Employees"];

            if (drPA_Values_Imported["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drPA_Values_Imported["Update_Date"];

            if (drPA_Values_Imported["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drPA_Values_Imported["Updated_By"];


        }

        #endregion

        /// <summary>
        /// Selects a single record from the PA_Values_Imported table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_PA_Values_Imported)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_Values_ImportedSelectByPK");

            db.AddInParameter(dbCommand, "PK_PA_Values_Imported", DbType.Decimal, pK_PA_Values_Imported);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the PA_Values_Imported table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_Values_ImportedSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects all records from the PA_Values_Imported table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBySearchCriteria(int SonicLocationCode, int Year, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_Values_ImportedSearchNew");

            db.AddInParameter(dbCommand, "@SonicLocationCode", DbType.Int32, SonicLocationCode);
            db.AddInParameter(dbCommand, "@Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Int32, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the PA_Values_Imported table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_Values_ImportedUpdate");


            db.AddInParameter(dbCommand, "PK_PA_Values_Imported", DbType.Decimal, this._PK_PA_Values_Imported);

            db.AddInParameter(dbCommand, "Non_Texas_Payroll", DbType.Decimal, this._Non_Texas_Payroll);

            db.AddInParameter(dbCommand, "Texas_Payroll", DbType.Decimal, this._Texas_Payroll);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            db.AddInParameter(dbCommand, "Number_Of_Employees", DbType.Int32, this._Number_Of_Employees);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            return db.ExecuteNonQuery(dbCommand);
        }

        public static DataTable GetDataToImport(string strFileName)
        {
            //Check the following registry settings for the *machine*: 
            //Hkey_Local_Machine/Software/Microsoft/Jet/4.0/Engines/Excel/TypeGuessRows 
            //Hkey_Local_Machine/Software/Microsoft/Jet/4.0/Engines/Excel/ImportMixedType­s 
            //TypeGuessRows: setting the value to 0 (zero) will force ADO to scan all column values before choosing the appropriate data type. 
            //ImportMixedTypes: should be set to value 'Text' i.e. import mixed-type columns as text: 


            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + @";Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""";
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + @";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;""";
            OleDbConnection objConn = new OleDbConnection(strConn);
            try
            {
                objConn.Open();

                DataTable dtSheets = objConn.GetSchema("Tables");

                OleDbCommand objCommand = new OleDbCommand("Select * from [" + dtSheets.Rows[0]["Table_name"] + "]", objConn);

                OleDbDataAdapter da = new OleDbDataAdapter(objCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (objConn.State == ConnectionState.Open) objConn.Close();
                objConn.Dispose();

                return ds.Tables[0];

            }
            catch
            {
                if (objConn.State == ConnectionState.Open) objConn.Close();
                objConn.Dispose();
                return null;
            }
        }

        /// <summary>
        /// Inserts a record into the PA_Values_Imported table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_Values_ImportedInsert");


            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, this._Sonic_Location_Code);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            db.AddInParameter(dbCommand, "Non_Texas_Payroll", DbType.Decimal, this._Non_Texas_Payroll);

            db.AddInParameter(dbCommand, "Texas_Payroll", DbType.Decimal, this._Texas_Payroll);

            db.AddInParameter(dbCommand, "Number_Of_Employees", DbType.Int32, this._Number_Of_Employees);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
    }
}
