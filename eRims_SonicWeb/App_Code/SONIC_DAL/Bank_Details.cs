using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Bank_Details table.
    /// </summary>
    public sealed class Bank_Details
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Bank_Details_ID;
        private string _Fld_Bank_Name;
        private string _Fld_Address_1;
        private string _Fld_Address_2;
        private string _Fld_City;
        private string _Fld_State;
        private string _Fld_Zip;
        private string _Fld_AccountNo;
        private string _Fld_RoutingNo;
        private string _Fld_Bank_State;
        private string _Fld_Bank_No1;
        private string _Fld_Bank_No2;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Bank_Details_ID value.
        /// </summary>
        public decimal? PK_Bank_Details_ID
        {
            get { return _PK_Bank_Details_ID; }
            set { _PK_Bank_Details_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Bank_Name value.
        /// </summary>
        public string Fld_Bank_Name
        {
            get { return _Fld_Bank_Name; }
            set { _Fld_Bank_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Address_1 value.
        /// </summary>
        public string Fld_Address_1
        {
            get { return _Fld_Address_1; }
            set { _Fld_Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Address_2 value.
        /// </summary>
        public string Fld_Address_2
        {
            get { return _Fld_Address_2; }
            set { _Fld_Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_City value.
        /// </summary>
        public string Fld_City
        {
            get { return _Fld_City; }
            set { _Fld_City = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_State value.
        /// </summary>
        public string Fld_State
        {
            get { return _Fld_State; }
            set { _Fld_State = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Zip value.
        /// </summary>
        public string Fld_Zip
        {
            get { return _Fld_Zip; }
            set { _Fld_Zip = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_AccountNo value.
        /// </summary>
        public string Fld_AccountNo
        {
            get { return _Fld_AccountNo; }
            set { _Fld_AccountNo = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_RoutingNo value.
        /// </summary>
        public string Fld_RoutingNo
        {
            get { return _Fld_RoutingNo; }
            set { _Fld_RoutingNo = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Bank_State value.
        /// </summary>
        public string Fld_Bank_State
        {
            get { return _Fld_Bank_State; }
            set { _Fld_Bank_State = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Bank_No1 value.
        /// </summary>
        public string Fld_Bank_No1
        {
            get { return _Fld_Bank_No1; }
            set { _Fld_Bank_No1 = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Bank_No2 value.
        /// </summary>
        public string Fld_Bank_No2
        {
            get { return _Fld_Bank_No2; }
            set { _Fld_Bank_No2 = value; }
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


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Bank_Details class with default value.
        /// </summary>
        public Bank_Details()
        {

            this._PK_Bank_Details_ID = null;
            this._Fld_Bank_Name = null;
            this._Fld_Address_1 = null;
            this._Fld_Address_2 = null;
            this._Fld_City = null;
            this._Fld_State = null;
            this._Fld_Zip = null;
            this._Fld_AccountNo = null;
            this._Fld_RoutingNo = null;
            this._Fld_Bank_State = null;
            this._Fld_Bank_No1 = null;
            this._Fld_Bank_No2 = null;
            this._Updated_By = null;
            this._Update_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Bank_Details class based on Primary Key.
        /// </summary>
        public Bank_Details(decimal pK_Bank_Details_ID)
        {
            DataTable dtBank_Details = SelectByPK(pK_Bank_Details_ID).Tables[0];

            if (dtBank_Details.Rows.Count == 1)
            {
                DataRow drBank_Details = dtBank_Details.Rows[0];
                if (drBank_Details["PK_Bank_Details_ID"] == DBNull.Value)
                    this._PK_Bank_Details_ID = null;
                else
                    this._PK_Bank_Details_ID = (decimal?)drBank_Details["PK_Bank_Details_ID"];

                if (drBank_Details["Fld_Bank_Name"] == DBNull.Value)
                    this._Fld_Bank_Name = null;
                else
                    this._Fld_Bank_Name = (string)drBank_Details["Fld_Bank_Name"];

                if (drBank_Details["Fld_Address_1"] == DBNull.Value)
                    this._Fld_Address_1 = null;
                else
                    this._Fld_Address_1 = (string)drBank_Details["Fld_Address_1"];

                if (drBank_Details["Fld_Address_2"] == DBNull.Value)
                    this._Fld_Address_2 = null;
                else
                    this._Fld_Address_2 = (string)drBank_Details["Fld_Address_2"];

                if (drBank_Details["Fld_City"] == DBNull.Value)
                    this._Fld_City = null;
                else
                    this._Fld_City = (string)drBank_Details["Fld_City"];

                if (drBank_Details["Fld_State"] == DBNull.Value)
                    this._Fld_State = null;
                else
                    this._Fld_State = (string)drBank_Details["Fld_State"];

                if (drBank_Details["Fld_Zip"] == DBNull.Value)
                    this._Fld_Zip = null;
                else
                    this._Fld_Zip = (string)drBank_Details["Fld_Zip"];

                if (drBank_Details["Fld_AccountNo"] == DBNull.Value)
                    this._Fld_AccountNo = null;
                else
                    this._Fld_AccountNo = (string)drBank_Details["Fld_AccountNo"];

                if (drBank_Details["Fld_RoutingNo"] == DBNull.Value)
                    this._Fld_RoutingNo = null;
                else
                    this._Fld_RoutingNo = (string)drBank_Details["Fld_RoutingNo"];

                if (drBank_Details["Fld_Bank_State"] == DBNull.Value)
                    this._Fld_Bank_State = null;
                else
                    this._Fld_Bank_State = (string)drBank_Details["Fld_Bank_State"];

                if (drBank_Details["Fld_Bank_No1"] == DBNull.Value)
                    this._Fld_Bank_No1 = null;
                else
                    this._Fld_Bank_No1 = (string)drBank_Details["Fld_Bank_No1"];

                if (drBank_Details["Fld_Bank_No2"] == DBNull.Value)
                    this._Fld_Bank_No2 = null;
                else
                    this._Fld_Bank_No2 = (string)drBank_Details["Fld_Bank_No2"];

                if (drBank_Details["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drBank_Details["Updated_By"];

                if (drBank_Details["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drBank_Details["Update_Date"];

            }
            else
            {
                this._PK_Bank_Details_ID = null;
                this._Fld_Bank_Name = null;
                this._Fld_Address_1 = null;
                this._Fld_Address_2 = null;
                this._Fld_City = null;
                this._Fld_State = null;
                this._Fld_Zip = null;
                this._Fld_AccountNo = null;
                this._Fld_RoutingNo = null;
                this._Fld_Bank_State = null;
                this._Fld_Bank_No1 = null;
                this._Fld_Bank_No2 = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Bank_Details table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Bank_DetailsInsert");


            if (string.IsNullOrEmpty(this._Fld_Bank_Name))
                db.AddInParameter(dbCommand, "Fld_Bank_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Bank_Name", DbType.String, this._Fld_Bank_Name);

            if (string.IsNullOrEmpty(this._Fld_Address_1))
                db.AddInParameter(dbCommand, "Fld_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Address_1", DbType.String, this._Fld_Address_1);

            if (string.IsNullOrEmpty(this._Fld_Address_2))
                db.AddInParameter(dbCommand, "Fld_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Address_2", DbType.String, this._Fld_Address_2);

            if (string.IsNullOrEmpty(this._Fld_City))
                db.AddInParameter(dbCommand, "Fld_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_City", DbType.String, this._Fld_City);

            if (string.IsNullOrEmpty(this._Fld_State))
                db.AddInParameter(dbCommand, "Fld_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_State", DbType.String, this._Fld_State);

            if (string.IsNullOrEmpty(this._Fld_Zip))
                db.AddInParameter(dbCommand, "Fld_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Zip", DbType.String, this._Fld_Zip);

            if (string.IsNullOrEmpty(this._Fld_AccountNo))
                db.AddInParameter(dbCommand, "Fld_AccountNo", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_AccountNo", DbType.String, this._Fld_AccountNo);

            if (string.IsNullOrEmpty(this._Fld_RoutingNo))
                db.AddInParameter(dbCommand, "Fld_RoutingNo", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_RoutingNo", DbType.String, this._Fld_RoutingNo);

            if (string.IsNullOrEmpty(this._Fld_Bank_State))
                db.AddInParameter(dbCommand, "Fld_Bank_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Bank_State", DbType.String, this._Fld_Bank_State);

            if (string.IsNullOrEmpty(this._Fld_Bank_No1))
                db.AddInParameter(dbCommand, "Fld_Bank_No1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Bank_No1", DbType.String, this._Fld_Bank_No1);

            if (string.IsNullOrEmpty(this._Fld_Bank_No2))
                db.AddInParameter(dbCommand, "Fld_Bank_No2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Bank_No2", DbType.String, this._Fld_Bank_No2);

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
        /// Selects a single record from the Bank_Details table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_Bank_Details_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Bank_DetailsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Bank_Details_ID", DbType.Decimal, pK_Bank_Details_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Bank_Details table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Bank_DetailsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Bank_Details table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Bank_DetailsUpdate");


            db.AddInParameter(dbCommand, "PK_Bank_Details_ID", DbType.Decimal, this._PK_Bank_Details_ID);

            if (string.IsNullOrEmpty(this._Fld_Bank_Name))
                db.AddInParameter(dbCommand, "Fld_Bank_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Bank_Name", DbType.String, this._Fld_Bank_Name);

            if (string.IsNullOrEmpty(this._Fld_Address_1))
                db.AddInParameter(dbCommand, "Fld_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Address_1", DbType.String, this._Fld_Address_1);

            if (string.IsNullOrEmpty(this._Fld_Address_2))
                db.AddInParameter(dbCommand, "Fld_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Address_2", DbType.String, this._Fld_Address_2);

            if (string.IsNullOrEmpty(this._Fld_City))
                db.AddInParameter(dbCommand, "Fld_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_City", DbType.String, this._Fld_City);

            if (string.IsNullOrEmpty(this._Fld_State))
                db.AddInParameter(dbCommand, "Fld_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_State", DbType.String, this._Fld_State);

            if (string.IsNullOrEmpty(this._Fld_Zip))
                db.AddInParameter(dbCommand, "Fld_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Zip", DbType.String, this._Fld_Zip);

            if (string.IsNullOrEmpty(this._Fld_AccountNo))
                db.AddInParameter(dbCommand, "Fld_AccountNo", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_AccountNo", DbType.String, this._Fld_AccountNo);

            if (string.IsNullOrEmpty(this._Fld_RoutingNo))
                db.AddInParameter(dbCommand, "Fld_RoutingNo", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_RoutingNo", DbType.String, this._Fld_RoutingNo);

            if (string.IsNullOrEmpty(this._Fld_Bank_State))
                db.AddInParameter(dbCommand, "Fld_Bank_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Bank_State", DbType.String, this._Fld_Bank_State);

            if (string.IsNullOrEmpty(this._Fld_Bank_No1))
                db.AddInParameter(dbCommand, "Fld_Bank_No1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Bank_No1", DbType.String, this._Fld_Bank_No1);

            if (string.IsNullOrEmpty(this._Fld_Bank_No2))
                db.AddInParameter(dbCommand, "Fld_Bank_No2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Bank_No2", DbType.String, this._Fld_Bank_No2);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Bank_Details table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Bank_Details_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Bank_DetailsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Bank_Details_ID", DbType.Decimal, pK_Bank_Details_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
