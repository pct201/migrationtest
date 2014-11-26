using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Consultant table.
    /// </summary>
    public sealed class clsEPM_Consultant
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Consultant;
        private decimal? _FK_EPM_Identification;
        private bool? _HH_Or_Other;
        private string _Consultant_Company;
        private string _Consultant_Address_1;
        private string _Consultant_Address_2;
        private string _Consultant_City;
        private decimal? _FK_State;
        private string _Consultant_Zip_Code;
        private string _Consultant_Contact_Name;
        private string _Consutlant_Telephone;
        private string _Constulant_Email;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _Unique_Val;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Consultant value.
        /// </summary>
        public decimal? PK_EPM_Consultant
        {
            get { return _PK_EPM_Consultant; }
            set { _PK_EPM_Consultant = value; }
        }

        /// <summary>
        /// Gets or sets the FK_EPM_Identification value.
        /// </summary>
        public decimal? FK_EPM_Identification
        {
            get { return _FK_EPM_Identification; }
            set { _FK_EPM_Identification = value; }
        }

        /// <summary>
        /// Gets or sets the HH_Or_Other value.
        /// </summary>
        public bool? HH_Or_Other
        {
            get { return _HH_Or_Other; }
            set { _HH_Or_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Consultant_Company value.
        /// </summary>
        public string Consultant_Company
        {
            get { return _Consultant_Company; }
            set { _Consultant_Company = value; }
        }

        /// <summary>
        /// Gets or sets the Consultant_Address_1 value.
        /// </summary>
        public string Consultant_Address_1
        {
            get { return _Consultant_Address_1; }
            set { _Consultant_Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Consultant_Address_2 value.
        /// </summary>
        public string Consultant_Address_2
        {
            get { return _Consultant_Address_2; }
            set { _Consultant_Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Consultant_City value.
        /// </summary>
        public string Consultant_City
        {
            get { return _Consultant_City; }
            set { _Consultant_City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_State value.
        /// </summary>
        public decimal? FK_State
        {
            get { return _FK_State; }
            set { _FK_State = value; }
        }

        /// <summary>
        /// Gets or sets the Consultant_Zip_Code value.
        /// </summary>
        public string Consultant_Zip_Code
        {
            get { return _Consultant_Zip_Code; }
            set { _Consultant_Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Consultant_Contact_Name value.
        /// </summary>
        public string Consultant_Contact_Name
        {
            get { return _Consultant_Contact_Name; }
            set { _Consultant_Contact_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Consutlant_Telephone value.
        /// </summary>
        public string Consutlant_Telephone
        {
            get { return _Consutlant_Telephone; }
            set { _Consutlant_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Constulant_Email value.
        /// </summary>
        public string Constulant_Email
        {
            get { return _Constulant_Email; }
            set { _Constulant_Email = value; }
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
        /// Gets or sets the Unique_Val value.
        /// </summary>
        public string Unique_Val
        {
            get { return _Unique_Val; }
            set { _Unique_Val = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Consultant class with default value.
        /// </summary>
        public clsEPM_Consultant()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Consultant class based on Primary Key.
        /// </summary>
        public clsEPM_Consultant(decimal pK_EPM_Consultant)
        {
            DataTable dtEPM_Consultant = SelectByPK(pK_EPM_Consultant).Tables[0];

            if (dtEPM_Consultant.Rows.Count == 1)
            {
                SetValue(dtEPM_Consultant.Rows[0]);

            }
        }

        /// <summary>
        /// Initializes a new instance of the clsEPM_Consultant class based on Foreign Key.
        /// </summary>
        public clsEPM_Consultant(int FK_EPM_Identification)
        {
            DataTable dtEPM_Consultant = SelectByFK(FK_EPM_Identification).Tables[0];

            if (dtEPM_Consultant.Rows.Count == 1)
            {
                SetValue(dtEPM_Consultant.Rows[0]);

            }
        }

        /// <summary>
        /// Initializes a new instance of the clsEPM_Consultant class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Consultant)
        {
            if (drEPM_Consultant["PK_EPM_Consultant"] == DBNull.Value)
                this._PK_EPM_Consultant = null;
            else
                this._PK_EPM_Consultant = (decimal?)drEPM_Consultant["PK_EPM_Consultant"];

            if (drEPM_Consultant["FK_EPM_Identification"] == DBNull.Value)
                this._FK_EPM_Identification = null;
            else
                this._FK_EPM_Identification = (decimal?)drEPM_Consultant["FK_EPM_Identification"];

            if (drEPM_Consultant["HH_Or_Other"] == DBNull.Value)
                this._HH_Or_Other = null;
            else
                this._HH_Or_Other = (bool?)drEPM_Consultant["HH_Or_Other"];

            if (drEPM_Consultant["Consultant_Company"] == DBNull.Value)
                this._Consultant_Company = null;
            else
                this._Consultant_Company = (string)drEPM_Consultant["Consultant_Company"];

            if (drEPM_Consultant["Consultant_Address_1"] == DBNull.Value)
                this._Consultant_Address_1 = null;
            else
                this._Consultant_Address_1 = (string)drEPM_Consultant["Consultant_Address_1"];

            if (drEPM_Consultant["Consultant_Address_2"] == DBNull.Value)
                this._Consultant_Address_2 = null;
            else
                this._Consultant_Address_2 = (string)drEPM_Consultant["Consultant_Address_2"];

            if (drEPM_Consultant["Consultant_City"] == DBNull.Value)
                this._Consultant_City = null;
            else
                this._Consultant_City = (string)drEPM_Consultant["Consultant_City"];

            if (drEPM_Consultant["FK_State"] == DBNull.Value)
                this._FK_State = null;
            else
                this._FK_State = (decimal?)drEPM_Consultant["FK_State"];

            if (drEPM_Consultant["Consultant_Zip_Code"] == DBNull.Value)
                this._Consultant_Zip_Code = null;
            else
                this._Consultant_Zip_Code = (string)drEPM_Consultant["Consultant_Zip_Code"];

            if (drEPM_Consultant["Consultant_Contact_Name"] == DBNull.Value)
                this._Consultant_Contact_Name = null;
            else
                this._Consultant_Contact_Name = (string)drEPM_Consultant["Consultant_Contact_Name"];

            if (drEPM_Consultant["Consutlant_Telephone"] == DBNull.Value)
                this._Consutlant_Telephone = null;
            else
                this._Consutlant_Telephone = (string)drEPM_Consultant["Consutlant_Telephone"];

            if (drEPM_Consultant["Constulant_Email"] == DBNull.Value)
                this._Constulant_Email = null;
            else
                this._Constulant_Email = (string)drEPM_Consultant["Constulant_Email"];

            if (drEPM_Consultant["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Consultant["Updated_By"];

            if (drEPM_Consultant["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Consultant["Update_Date"];
        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Consultant table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ConsultantInsert");


            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "HH_Or_Other", DbType.Boolean, this._HH_Or_Other);

            if (string.IsNullOrEmpty(this._Consultant_Company))
                db.AddInParameter(dbCommand, "Consultant_Company", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Company", DbType.String, this._Consultant_Company);

            if (string.IsNullOrEmpty(this._Consultant_Address_1))
                db.AddInParameter(dbCommand, "Consultant_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Address_1", DbType.String, this._Consultant_Address_1);

            if (string.IsNullOrEmpty(this._Consultant_Address_2))
                db.AddInParameter(dbCommand, "Consultant_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Address_2", DbType.String, this._Consultant_Address_2);

            if (string.IsNullOrEmpty(this._Consultant_City))
                db.AddInParameter(dbCommand, "Consultant_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_City", DbType.String, this._Consultant_City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Consultant_Zip_Code))
                db.AddInParameter(dbCommand, "Consultant_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Zip_Code", DbType.String, this._Consultant_Zip_Code);

            if (string.IsNullOrEmpty(this._Consultant_Contact_Name))
                db.AddInParameter(dbCommand, "Consultant_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Contact_Name", DbType.String, this._Consultant_Contact_Name);

            if (string.IsNullOrEmpty(this._Consutlant_Telephone))
                db.AddInParameter(dbCommand, "Consutlant_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consutlant_Telephone", DbType.String, this._Consutlant_Telephone);

            if (string.IsNullOrEmpty(this._Constulant_Email))
                db.AddInParameter(dbCommand, "Constulant_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Constulant_Email", DbType.String, this._Constulant_Email);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the EPM_Consultant table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_EPM_Consultant)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ConsultantSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Consultant", DbType.Decimal, pK_EPM_Consultant);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Consultant table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ConsultantSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Consultant table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ConsultantUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Consultant", DbType.Decimal, this._PK_EPM_Consultant);

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "HH_Or_Other", DbType.Boolean, this._HH_Or_Other);

            if (string.IsNullOrEmpty(this._Consultant_Company))
                db.AddInParameter(dbCommand, "Consultant_Company", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Company", DbType.String, this._Consultant_Company);

            if (string.IsNullOrEmpty(this._Consultant_Address_1))
                db.AddInParameter(dbCommand, "Consultant_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Address_1", DbType.String, this._Consultant_Address_1);

            if (string.IsNullOrEmpty(this._Consultant_Address_2))
                db.AddInParameter(dbCommand, "Consultant_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Address_2", DbType.String, this._Consultant_Address_2);

            if (string.IsNullOrEmpty(this._Consultant_City))
                db.AddInParameter(dbCommand, "Consultant_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_City", DbType.String, this._Consultant_City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Consultant_Zip_Code))
                db.AddInParameter(dbCommand, "Consultant_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Zip_Code", DbType.String, this._Consultant_Zip_Code);

            if (string.IsNullOrEmpty(this._Consultant_Contact_Name))
                db.AddInParameter(dbCommand, "Consultant_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consultant_Contact_Name", DbType.String, this._Consultant_Contact_Name);

            if (string.IsNullOrEmpty(this._Consutlant_Telephone))
                db.AddInParameter(dbCommand, "Consutlant_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Consutlant_Telephone", DbType.String, this._Consutlant_Telephone);

            if (string.IsNullOrEmpty(this._Constulant_Email))
                db.AddInParameter(dbCommand, "Constulant_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Constulant_Email", DbType.String, this._Constulant_Email);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the EPM_Consultant table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Consultant)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ConsultantDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Consultant", DbType.Decimal, pK_EPM_Consultant);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Consultant table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByFK(int FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ConsultantSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Int64, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }


        public static DataSet GetBuildingsForJobRequestForm(decimal PK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Consultant_GetBuildingsForJobRequestForm");

            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Int64, PK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

    }
}
