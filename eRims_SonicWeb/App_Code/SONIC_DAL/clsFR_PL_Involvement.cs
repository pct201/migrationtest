using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for FR_PL_Involvement table.
    /// </summary>
    public sealed class clsFR_PL_Involvement
    {

        #region Private variables used to hold the property values

        private decimal? _PK_FR_PL_Involvement;
        private decimal? _FK_PL_FR_ID;
        private decimal? _FK_LU_PL_Involvement;
        private string _Name;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private decimal? _FK_State;
        private string _Zip_Code;
        private string _Home_Telephone;
        private string _Work_Telephone;
        private string _Cell_Telephone;
        private string _Email;
        private DateTime? _Update_Date;
        private string _Updated_By;
        private string _Gender;
        private string _Medical_Attention_Required;
        private string _Medical_Attention_Declined;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_FR_PL_Involvement value.
        /// </summary>
        public decimal? PK_FR_PL_Involvement
        {
            get { return _PK_FR_PL_Involvement; }
            set { _PK_FR_PL_Involvement = value; }
        }

        /// <summary>
        /// Gets or sets the FK_PL_FR_ID value.
        /// </summary>
        public decimal? FK_PL_FR_ID
        {
            get { return _FK_PL_FR_ID; }
            set { _FK_PL_FR_ID = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_PL_Involvement value.
        /// </summary>
        public decimal? FK_LU_PL_Involvement
        {
            get { return _FK_LU_PL_Involvement; }
            set { _FK_LU_PL_Involvement = value; }
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
        public decimal? FK_State
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
        /// Gets or sets the Home_Telephone value.
        /// </summary>
        public string Home_Telephone
        {
            get { return _Home_Telephone; }
            set { _Home_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Work_Telephone value.
        /// </summary>
        public string Work_Telephone
        {
            get { return _Work_Telephone; }
            set { _Work_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Cell_Telephone value.
        /// </summary>
        public string Cell_Telephone
        {
            get { return _Cell_Telephone; }
            set { _Cell_Telephone = value; }
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

        /// <summary>
        /// Gets or sets the Gender value.
        /// </summary>
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        /// <summary>
        /// Gets or sets the Medical_Attention_Required value.
        /// </summary>
        public string Medical_Attention_Required
        {
            get { return _Medical_Attention_Required; }
            set { _Medical_Attention_Required = value; }
        }

        /// <summary>
        /// Gets or sets the Medical_Attention_Declined value.
        /// </summary>
        public string Medical_Attention_Declined
        {
            get { return _Medical_Attention_Declined; }
            set { _Medical_Attention_Declined = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsFR_PL_Involvement class with default value.
        /// </summary>
        public clsFR_PL_Involvement()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsFR_PL_Involvement class based on Primary Key.
        /// </summary>
        public clsFR_PL_Involvement(decimal pK_FR_PL_Involvement)
        {
            DataTable dtFR_PL_Involvement = SelectByPK(pK_FR_PL_Involvement).Tables[0];

            if (dtFR_PL_Involvement.Rows.Count == 1)
            {
                SetValue(dtFR_PL_Involvement.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsFR_PL_Involvement class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drFR_PL_Involvement)
        {
            if (drFR_PL_Involvement["PK_FR_PL_Involvement"] == DBNull.Value)
                this._PK_FR_PL_Involvement = null;
            else
                this._PK_FR_PL_Involvement = (decimal?)drFR_PL_Involvement["PK_FR_PL_Involvement"];

            if (drFR_PL_Involvement["FK_PL_FR_ID"] == DBNull.Value)
                this._FK_PL_FR_ID = null;
            else
                this._FK_PL_FR_ID = (decimal?)drFR_PL_Involvement["FK_PL_FR_ID"];

            if (drFR_PL_Involvement["FK_LU_PL_Involvement"] == DBNull.Value)
                this._FK_LU_PL_Involvement = null;
            else
                this._FK_LU_PL_Involvement = (decimal?)drFR_PL_Involvement["FK_LU_PL_Involvement"];

            if (drFR_PL_Involvement["Name"] == DBNull.Value)
                this._Name = null;
            else
                this._Name = (string)drFR_PL_Involvement["Name"];

            if (drFR_PL_Involvement["Address_1"] == DBNull.Value)
                this._Address_1 = null;
            else
                this._Address_1 = (string)drFR_PL_Involvement["Address_1"];

            if (drFR_PL_Involvement["Address_2"] == DBNull.Value)
                this._Address_2 = null;
            else
                this._Address_2 = (string)drFR_PL_Involvement["Address_2"];

            if (drFR_PL_Involvement["City"] == DBNull.Value)
                this._City = null;
            else
                this._City = (string)drFR_PL_Involvement["City"];

            if (drFR_PL_Involvement["FK_State"] == DBNull.Value)
                this._FK_State = null;
            else
                this._FK_State = (decimal?)drFR_PL_Involvement["FK_State"];

            if (drFR_PL_Involvement["Zip_Code"] == DBNull.Value)
                this._Zip_Code = null;
            else
                this._Zip_Code = (string)drFR_PL_Involvement["Zip_Code"];

            if (drFR_PL_Involvement["Home_Telephone"] == DBNull.Value)
                this._Home_Telephone = null;
            else
                this._Home_Telephone = (string)drFR_PL_Involvement["Home_Telephone"];

            if (drFR_PL_Involvement["Work_Telephone"] == DBNull.Value)
                this._Work_Telephone = null;
            else
                this._Work_Telephone = (string)drFR_PL_Involvement["Work_Telephone"];

            if (drFR_PL_Involvement["Cell_Telephone"] == DBNull.Value)
                this._Cell_Telephone = null;
            else
                this._Cell_Telephone = (string)drFR_PL_Involvement["Cell_Telephone"];

            if (drFR_PL_Involvement["Email"] == DBNull.Value)
                this._Email = null;
            else
                this._Email = (string)drFR_PL_Involvement["Email"];

            if (drFR_PL_Involvement["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drFR_PL_Involvement["Update_Date"];

            if (drFR_PL_Involvement["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drFR_PL_Involvement["Updated_By"];

            if (drFR_PL_Involvement["Gender"] == DBNull.Value)
                this._Gender = null;
            else
                this._Gender = (string)drFR_PL_Involvement["Gender"];

            if (drFR_PL_Involvement["Medical_Attention_Required"] == DBNull.Value)
                this._Medical_Attention_Required = null;
            else
                this._Medical_Attention_Required = (string)drFR_PL_Involvement["Medical_Attention_Required"];

            if (drFR_PL_Involvement["Medical_Attention_Declined"] == DBNull.Value)
                this._Medical_Attention_Declined = null;
            else
                this._Medical_Attention_Declined = (string)drFR_PL_Involvement["Medical_Attention_Declined"];

        }

        #endregion

        /// <summary>
        /// Inserts a record into the FR_PL_Involvement table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FR_PL_InvolvementInsert");


            db.AddInParameter(dbCommand, "FK_PL_FR_ID", DbType.Decimal, this._FK_PL_FR_ID);

            db.AddInParameter(dbCommand, "FK_LU_PL_Involvement", DbType.Decimal, this._FK_LU_PL_Involvement);

            if (string.IsNullOrEmpty(this._Name))
                db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            if (string.IsNullOrEmpty(this._Home_Telephone))
                db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, this._Home_Telephone);

            if (string.IsNullOrEmpty(this._Work_Telephone))
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, this._Work_Telephone);

            if (string.IsNullOrEmpty(this._Cell_Telephone))
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            if (string.IsNullOrEmpty(this._Gender))
                db.AddInParameter(dbCommand, "Gender", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Gender", DbType.String, this._Gender);

            if (string.IsNullOrEmpty(this._Medical_Attention_Required))
                db.AddInParameter(dbCommand, "Medical_Attention_Required", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Medical_Attention_Required", DbType.String, this._Medical_Attention_Required);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Medical_Attention_Declined", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Medical_Attention_Declined", DbType.String, this._Medical_Attention_Declined);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the FR_PL_Involvement table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_FR_PL_Involvement)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FR_PL_InvolvementSelectByPK");

            db.AddInParameter(dbCommand, "PK_FR_PL_Involvement", DbType.Decimal, pK_FR_PL_Involvement);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the FR_PL_Involvement table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal fK_PL_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FR_PL_InvolvementSelectByFK");

            db.AddInParameter(dbCommand, "FK_PL_FR_ID", DbType.Decimal, fK_PL_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the FR_PL_Involvement table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FR_PL_InvolvementSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the FR_PL_Involvement table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FR_PL_InvolvementUpdate");


            db.AddInParameter(dbCommand, "PK_FR_PL_Involvement", DbType.Decimal, this._PK_FR_PL_Involvement);

            db.AddInParameter(dbCommand, "FK_PL_FR_ID", DbType.Decimal, this._FK_PL_FR_ID);

            db.AddInParameter(dbCommand, "FK_LU_PL_Involvement", DbType.Decimal, this._FK_LU_PL_Involvement);

            if (string.IsNullOrEmpty(this._Name))
                db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            if (string.IsNullOrEmpty(this._Home_Telephone))
                db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, this._Home_Telephone);

            if (string.IsNullOrEmpty(this._Work_Telephone))
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, this._Work_Telephone);

            if (string.IsNullOrEmpty(this._Cell_Telephone))
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            if (string.IsNullOrEmpty(this._Gender))
                db.AddInParameter(dbCommand, "Gender", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Gender", DbType.String, this._Gender);

            if (string.IsNullOrEmpty(this._Medical_Attention_Required))
                db.AddInParameter(dbCommand, "Medical_Attention_Required", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Medical_Attention_Required", DbType.String, this._Medical_Attention_Required);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Medical_Attention_Declined", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Medical_Attention_Declined", DbType.String, this._Medical_Attention_Declined);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the FR_PL_Involvement table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_FR_PL_Involvement)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FR_PL_InvolvementDeleteByPK");

            db.AddInParameter(dbCommand, "PK_FR_PL_Involvement", DbType.Decimal, pK_FR_PL_Involvement);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
