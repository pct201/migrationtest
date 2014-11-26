using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for RE_Contractor table.
    /// </summary>
    public sealed class RE_Contractor
    {

        #region Private variables used to hold the property values

        private decimal? _PK_RE_Contractor;
        private string _Contractor_Company;
        private string _Contractor_Contact;
        private string _Contractor_Address1;
        private string _Contractor_Address2;
        private string _Contractor_City;
        private decimal? _FK_State_Contractor;
        private string _Contractor_Zip_Code;
        private string _Contractor_Telephone;
        private string _Contractor_Facsimile;
        private string _Contractor_Email;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _Active;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_RE_Contractor value.
        /// </summary>
        public decimal? PK_RE_Contractor
        {
            get { return _PK_RE_Contractor; }
            set { _PK_RE_Contractor = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_Company value.
        /// </summary>
        public string Contractor_Company
        {
            get { return _Contractor_Company; }
            set { _Contractor_Company = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_Contact value.
        /// </summary>
        public string Contractor_Contact
        {
            get { return _Contractor_Contact; }
            set { _Contractor_Contact = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_Address1 value.
        /// </summary>
        public string Contractor_Address1
        {
            get { return _Contractor_Address1; }
            set { _Contractor_Address1 = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_Address2 value.
        /// </summary>
        public string Contractor_Address2
        {
            get { return _Contractor_Address2; }
            set { _Contractor_Address2 = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_City value.
        /// </summary>
        public string Contractor_City
        {
            get { return _Contractor_City; }
            set { _Contractor_City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_State_Contractor value.
        /// </summary>
        public decimal? FK_State_Contractor
        {
            get { return _FK_State_Contractor; }
            set { _FK_State_Contractor = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_Zip_Code value.
        /// </summary>
        public string Contractor_Zip_Code
        {
            get { return _Contractor_Zip_Code; }
            set { _Contractor_Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_Telephone value.
        /// </summary>
        public string Contractor_Telephone
        {
            get { return _Contractor_Telephone; }
            set { _Contractor_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_Facsimile value.
        /// </summary>
        public string Contractor_Facsimile
        {
            get { return _Contractor_Facsimile; }
            set { _Contractor_Facsimile = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_Email value.
        /// </summary>
        public string Contractor_Email
        {
            get { return _Contractor_Email; }
            set { _Contractor_Email = value; }
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
        /// Gets or sets the Active value.
        /// </summary>
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Contractor class with default value.
        /// </summary>
        public RE_Contractor()
        {

            this._PK_RE_Contractor = null;
            this._Contractor_Company = null;
            this._Contractor_Contact = null;
            this._Contractor_Address1 = null;
            this._Contractor_Address2 = null;
            this._Contractor_City = null;
            this._FK_State_Contractor = null;
            this._Contractor_Zip_Code = null;
            this._Contractor_Telephone = null;
            this._Contractor_Facsimile = null;
            this._Contractor_Email = null;
            this._Updated_By = null;
            this._Update_Date = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Contractor class based on Primary Key.
        /// </summary>
        public RE_Contractor(decimal pK_RE_Contractor)
        {
            DataTable dtRE_Contractor = SelectByPK(pK_RE_Contractor).Tables[0];

            if (dtRE_Contractor.Rows.Count == 1)
            {
                DataRow drRE_Contractor = dtRE_Contractor.Rows[0];
                if (drRE_Contractor["PK_RE_Contractor"] == DBNull.Value)
                    this._PK_RE_Contractor = null;
                else
                    this._PK_RE_Contractor = (decimal?)drRE_Contractor["PK_RE_Contractor"];

                if (drRE_Contractor["Contractor_Company"] == DBNull.Value)
                    this._Contractor_Company = null;
                else
                    this._Contractor_Company = (string)drRE_Contractor["Contractor_Company"];

                if (drRE_Contractor["Contractor_Contact"] == DBNull.Value)
                    this._Contractor_Contact = null;
                else
                    this._Contractor_Contact = (string)drRE_Contractor["Contractor_Contact"];

                if (drRE_Contractor["Contractor_Address1"] == DBNull.Value)
                    this._Contractor_Address1 = null;
                else
                    this._Contractor_Address1 = (string)drRE_Contractor["Contractor_Address1"];

                if (drRE_Contractor["Contractor_Address2"] == DBNull.Value)
                    this._Contractor_Address2 = null;
                else
                    this._Contractor_Address2 = (string)drRE_Contractor["Contractor_Address2"];

                if (drRE_Contractor["Contractor_City"] == DBNull.Value)
                    this._Contractor_City = null;
                else
                    this._Contractor_City = (string)drRE_Contractor["Contractor_City"];

                if (drRE_Contractor["FK_State_Contractor"] == DBNull.Value)
                    this._FK_State_Contractor = null;
                else
                    this._FK_State_Contractor = (decimal?)drRE_Contractor["FK_State_Contractor"];

                if (drRE_Contractor["Contractor_Zip_Code"] == DBNull.Value)
                    this._Contractor_Zip_Code = null;
                else
                    this._Contractor_Zip_Code = (string)drRE_Contractor["Contractor_Zip_Code"];

                if (drRE_Contractor["Contractor_Telephone"] == DBNull.Value)
                    this._Contractor_Telephone = null;
                else
                    this._Contractor_Telephone = (string)drRE_Contractor["Contractor_Telephone"];

                if (drRE_Contractor["Contractor_Facsimile"] == DBNull.Value)
                    this._Contractor_Facsimile = null;
                else
                    this._Contractor_Facsimile = (string)drRE_Contractor["Contractor_Facsimile"];

                if (drRE_Contractor["Contractor_Email"] == DBNull.Value)
                    this._Contractor_Email = null;
                else
                    this._Contractor_Email = (string)drRE_Contractor["Contractor_Email"];

                if (drRE_Contractor["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Contractor["Updated_By"];

                if (drRE_Contractor["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Contractor["Update_Date"];

                if (drRE_Contractor["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drRE_Contractor["Active"];
            }
            else
            {
                this._PK_RE_Contractor = null;
                this._Contractor_Company = null;
                this._Contractor_Contact = null;
                this._Contractor_Address1 = null;
                this._Contractor_Address2 = null;
                this._Contractor_City = null;
                this._FK_State_Contractor = null;
                this._Contractor_Zip_Code = null;
                this._Contractor_Telephone = null;
                this._Contractor_Facsimile = null;
                this._Contractor_Email = null;
                this._Updated_By = null;
                this._Update_Date = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the RE_Contractor table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_ContractorInsert");


            if (string.IsNullOrEmpty(this._Contractor_Company))
                db.AddInParameter(dbCommand, "Contractor_Company", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Company", DbType.String, this._Contractor_Company);

            if (string.IsNullOrEmpty(this._Contractor_Contact))
                db.AddInParameter(dbCommand, "Contractor_Contact", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Contact", DbType.String, this._Contractor_Contact);

            if (string.IsNullOrEmpty(this._Contractor_Address1))
                db.AddInParameter(dbCommand, "Contractor_Address1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Address1", DbType.String, this._Contractor_Address1);

            if (string.IsNullOrEmpty(this._Contractor_Address2))
                db.AddInParameter(dbCommand, "Contractor_Address2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Address2", DbType.String, this._Contractor_Address2);

            if (string.IsNullOrEmpty(this._Contractor_City))
                db.AddInParameter(dbCommand, "Contractor_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_City", DbType.String, this._Contractor_City);

            db.AddInParameter(dbCommand, "FK_State_Contractor", DbType.Decimal, this._FK_State_Contractor);

            if (string.IsNullOrEmpty(this._Contractor_Zip_Code))
                db.AddInParameter(dbCommand, "Contractor_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Zip_Code", DbType.String, this._Contractor_Zip_Code);

            if (string.IsNullOrEmpty(this._Contractor_Telephone))
                db.AddInParameter(dbCommand, "Contractor_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Telephone", DbType.String, this._Contractor_Telephone);

            if (string.IsNullOrEmpty(this._Contractor_Facsimile))
                db.AddInParameter(dbCommand, "Contractor_Facsimile", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Facsimile", DbType.String, this._Contractor_Facsimile);

            if (string.IsNullOrEmpty(this._Contractor_Email))
                db.AddInParameter(dbCommand, "Contractor_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Email", DbType.String, this._Contractor_Email);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the RE_Contractor table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_RE_Contractor)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_ContractorSelectByPK");

            db.AddInParameter(dbCommand, "PK_RE_Contractor", DbType.Decimal, pK_RE_Contractor);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RE_Contractor table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_ContractorSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the RE_Contractor table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_ContractorUpdate");


            db.AddInParameter(dbCommand, "PK_RE_Contractor", DbType.Decimal, this._PK_RE_Contractor);

            if (string.IsNullOrEmpty(this._Contractor_Company))
                db.AddInParameter(dbCommand, "Contractor_Company", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Company", DbType.String, this._Contractor_Company);

            if (string.IsNullOrEmpty(this._Contractor_Contact))
                db.AddInParameter(dbCommand, "Contractor_Contact", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Contact", DbType.String, this._Contractor_Contact);

            if (string.IsNullOrEmpty(this._Contractor_Address1))
                db.AddInParameter(dbCommand, "Contractor_Address1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Address1", DbType.String, this._Contractor_Address1);

            if (string.IsNullOrEmpty(this._Contractor_Address2))
                db.AddInParameter(dbCommand, "Contractor_Address2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Address2", DbType.String, this._Contractor_Address2);

            if (string.IsNullOrEmpty(this._Contractor_City))
                db.AddInParameter(dbCommand, "Contractor_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_City", DbType.String, this._Contractor_City);

            db.AddInParameter(dbCommand, "FK_State_Contractor", DbType.Decimal, this._FK_State_Contractor);

            if (string.IsNullOrEmpty(this._Contractor_Zip_Code))
                db.AddInParameter(dbCommand, "Contractor_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Zip_Code", DbType.String, this._Contractor_Zip_Code);

            if (string.IsNullOrEmpty(this._Contractor_Telephone))
                db.AddInParameter(dbCommand, "Contractor_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Telephone", DbType.String, this._Contractor_Telephone);

            if (string.IsNullOrEmpty(this._Contractor_Facsimile))
                db.AddInParameter(dbCommand, "Contractor_Facsimile", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Facsimile", DbType.String, this._Contractor_Facsimile);

            if (string.IsNullOrEmpty(this._Contractor_Email))
                db.AddInParameter(dbCommand, "Contractor_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Email", DbType.String, this._Contractor_Email);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the RE_Contractor table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_RE_Contractor)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_ContractorDeleteByPK");

            db.AddInParameter(dbCommand, "PK_RE_Contractor", DbType.Decimal, pK_RE_Contractor);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RE_Contractor table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllContractor()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Contractor_SelectContractor");

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
