using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Executive_Risk_Expenses table.
	/// </summary>
	public sealed class Executive_Risk_Expenses
    {

        #region Fields


        private decimal _PK_Executive_Risk_Expenses;
        private decimal _FK_Executive_Risk;
        private string _Company;
        private string _Invoice;
        private decimal _Amount;
        private DateTime _Date;
        private string _Notes;
        private string _Updated_By;
        private DateTime _Update_Date;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Executive_Risk_Expenses value.
        /// </summary>
        public decimal PK_Executive_Risk_Expenses
        {
            get { return _PK_Executive_Risk_Expenses; }
            set { _PK_Executive_Risk_Expenses = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Executive_Risk value.
        /// </summary>
        public decimal FK_Executive_Risk
        {
            get { return _FK_Executive_Risk; }
            set { _FK_Executive_Risk = value; }
        }


        /// <summary> 
        /// Gets or sets the Company value.
        /// </summary>
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }


        /// <summary> 
        /// Gets or sets the Invoice value.
        /// </summary>
        public string Invoice
        {
            get { return _Invoice; }
            set { _Invoice = value; }
        }


        /// <summary> 
        /// Gets or sets the Amount value.
        /// </summary>
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Date value.
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
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
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Executive_Risk_Expenses class. with the default value.

        /// </summary>
        public Executive_Risk_Expenses()
        {

            this._PK_Executive_Risk_Expenses = -1;
            this._FK_Executive_Risk = -1;
            this._Company = "";
            this._Invoice = "";
            this._Amount = -1;
            this._Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Notes = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 

        /// Initializes a new instance of the Executive_Risk_Expenses class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Executive_Risk_Expenses(decimal PK)
        {

            DataTable dtExecutive_Risk_Expenses = SelectByPK(PK).Tables[0];

            if (dtExecutive_Risk_Expenses.Rows.Count > 0)
            {

                DataRow drExecutive_Risk_Expenses = dtExecutive_Risk_Expenses.Rows[0];

                this._PK_Executive_Risk_Expenses = drExecutive_Risk_Expenses["PK_Executive_Risk_Expenses"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Expenses["PK_Executive_Risk_Expenses"]) : 0;
                this._FK_Executive_Risk = drExecutive_Risk_Expenses["FK_Executive_Risk"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Expenses["FK_Executive_Risk"]) : 0;
                this._Company = Convert.ToString(drExecutive_Risk_Expenses["Company"]);
                this._Invoice = Convert.ToString(drExecutive_Risk_Expenses["Invoice"]);
                this._Amount = drExecutive_Risk_Expenses["Amount"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Expenses["Amount"]) : 0;
                this._Date = drExecutive_Risk_Expenses["Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk_Expenses["Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Notes = Convert.ToString(drExecutive_Risk_Expenses["Notes"]);
                this._Updated_By = Convert.ToString(drExecutive_Risk_Expenses["Updated_By"]);
                this._Update_Date = drExecutive_Risk_Expenses["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk_Expenses["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_Executive_Risk_Expenses = -1;
                this._FK_Executive_Risk = -1;
                this._Company = "";
                this._Invoice = "";
                this._Amount = -1;
                this._Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Notes = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion


        #region "Methods"
        /// <summary>
		/// Inserts a record into the Executive_Risk_Expenses table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ExpensesInsert");

			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			db.AddInParameter(dbCommand, "Company", DbType.String, this._Company);
			db.AddInParameter(dbCommand, "Invoice", DbType.String, this._Invoice);
			db.AddInParameter(dbCommand, "Amount", DbType.Decimal, this._Amount);
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Executive_Risk_Expenses table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Executive_Risk_Expenses)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ExpensesSelectByPK");

			db.AddInParameter(dbCommand, "PK_Executive_Risk_Expenses", DbType.Decimal, pK_Executive_Risk_Expenses);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Executive_Risk_Expenses table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ExpensesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Executive_Risk_Expenses table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ExpensesUpdate");

			db.AddInParameter(dbCommand, "PK_Executive_Risk_Expenses", DbType.Decimal, this._PK_Executive_Risk_Expenses);
			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			db.AddInParameter(dbCommand, "Company", DbType.String, this._Company);
			db.AddInParameter(dbCommand, "Invoice", DbType.String, this._Invoice);
			db.AddInParameter(dbCommand, "Amount", DbType.Decimal, this._Amount);
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Executive_Risk_Expenses table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Executive_Risk_Expenses)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ExpensesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Executive_Risk_Expenses", DbType.Decimal, pK_Executive_Risk_Expenses);

			db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects records from the Defense_Attorney table by a foreign key.
        /// </summary>
        /// <param name="fK_Executive_Risk"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Executive_Risk(decimal fK_Executive_Risk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ExpensesSelectByFK_Executive_Risk");

            db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, fK_Executive_Risk);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
