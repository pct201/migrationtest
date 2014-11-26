using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for AP_FE_Transactions table.
	/// </summary>
	public sealed class clsAP_FE_Transactions
	{

		#region Private variables used to hold the property values

		private decimal? _PK_AP_FE_Transactions;
		private decimal? _FK_AP_Fraud_Events;
		private decimal? _FK_LU_Transaction_Type;
		private decimal? _FK_LU_Transaction_Category;
		private DateTime? _Transaction_Date;
		private decimal? _Transaction_Amount;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_AP_FE_Transactions value.
		/// </summary>
		public decimal? PK_AP_FE_Transactions
		{
			get { return _PK_AP_FE_Transactions; }
			set { _PK_AP_FE_Transactions = value; }
		}

		/// <summary>
		/// Gets or sets the FK_AP_Fraud_Events value.
		/// </summary>
		public decimal? FK_AP_Fraud_Events
		{
			get { return _FK_AP_Fraud_Events; }
			set { _FK_AP_Fraud_Events = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Transaction_Type value.
		/// </summary>
		public decimal? FK_LU_Transaction_Type
		{
			get { return _FK_LU_Transaction_Type; }
			set { _FK_LU_Transaction_Type = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Transaction_Category value.
		/// </summary>
		public decimal? FK_LU_Transaction_Category
		{
			get { return _FK_LU_Transaction_Category; }
			set { _FK_LU_Transaction_Category = value; }
		}

		/// <summary>
		/// Gets or sets the Transaction_Date value.
		/// </summary>
		public DateTime? Transaction_Date
		{
			get { return _Transaction_Date; }
			set { _Transaction_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Transaction_Amount value.
		/// </summary>
		public decimal? Transaction_Amount
		{
			get { return _Transaction_Amount; }
			set { _Transaction_Amount = value; }
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
		/// Initializes a new instance of the clsAP_FE_Transactions class with default value.
		/// </summary>
		public clsAP_FE_Transactions() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAP_FE_Transactions class based on Primary Key.
		/// </summary>
		public clsAP_FE_Transactions(decimal pK_AP_FE_Transactions) 
		{
			DataTable dtAP_FE_Transactions = SelectByPK(pK_AP_FE_Transactions).Tables[0];

			if (dtAP_FE_Transactions.Rows.Count == 1)
			{
				 SetValue(dtAP_FE_Transactions.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAP_FE_Transactions class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAP_FE_Transactions) 
		{
				if (drAP_FE_Transactions["PK_AP_FE_Transactions"] == DBNull.Value)
					this._PK_AP_FE_Transactions = null;
				else
					this._PK_AP_FE_Transactions = (decimal?)drAP_FE_Transactions["PK_AP_FE_Transactions"];

				if (drAP_FE_Transactions["FK_AP_Fraud_Events"] == DBNull.Value)
					this._FK_AP_Fraud_Events = null;
				else
					this._FK_AP_Fraud_Events = (decimal?)drAP_FE_Transactions["FK_AP_Fraud_Events"];

				if (drAP_FE_Transactions["FK_LU_Transaction_Type"] == DBNull.Value)
					this._FK_LU_Transaction_Type = null;
				else
					this._FK_LU_Transaction_Type = (decimal?)drAP_FE_Transactions["FK_LU_Transaction_Type"];

				if (drAP_FE_Transactions["FK_LU_Transaction_Category"] == DBNull.Value)
					this._FK_LU_Transaction_Category = null;
				else
					this._FK_LU_Transaction_Category = (decimal?)drAP_FE_Transactions["FK_LU_Transaction_Category"];

				if (drAP_FE_Transactions["Transaction_Date"] == DBNull.Value)
					this._Transaction_Date = null;
				else
					this._Transaction_Date = (DateTime?)drAP_FE_Transactions["Transaction_Date"];

				if (drAP_FE_Transactions["Transaction_Amount"] == DBNull.Value)
					this._Transaction_Amount = null;
				else
					this._Transaction_Amount = (decimal?)drAP_FE_Transactions["Transaction_Amount"];

				if (drAP_FE_Transactions["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drAP_FE_Transactions["Updated_By"];

				if (drAP_FE_Transactions["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drAP_FE_Transactions["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the AP_FE_Transactions table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_TransactionsInsert");

			
			db.AddInParameter(dbCommand, "FK_AP_Fraud_Events", DbType.Decimal, this._FK_AP_Fraud_Events);
			
			db.AddInParameter(dbCommand, "FK_LU_Transaction_Type", DbType.Decimal, this._FK_LU_Transaction_Type);
			
			db.AddInParameter(dbCommand, "FK_LU_Transaction_Category", DbType.Decimal, this._FK_LU_Transaction_Category);
			
			db.AddInParameter(dbCommand, "Transaction_Date", DbType.DateTime, this._Transaction_Date);
			
			db.AddInParameter(dbCommand, "Transaction_Amount", DbType.Decimal, this._Transaction_Amount);
			
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
		/// Selects a single record from the AP_FE_Transactions table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_AP_FE_Transactions)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_TransactionsSelectByPK");

			db.AddInParameter(dbCommand, "PK_AP_FE_Transactions", DbType.Decimal, pK_AP_FE_Transactions);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the AP_FE_Transactions table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_TransactionsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the AP_FE_Transactions table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_TransactionsUpdate");

			
			db.AddInParameter(dbCommand, "PK_AP_FE_Transactions", DbType.Decimal, this._PK_AP_FE_Transactions);
			
			db.AddInParameter(dbCommand, "FK_AP_Fraud_Events", DbType.Decimal, this._FK_AP_Fraud_Events);
			
			db.AddInParameter(dbCommand, "FK_LU_Transaction_Type", DbType.Decimal, this._FK_LU_Transaction_Type);
			
			db.AddInParameter(dbCommand, "FK_LU_Transaction_Category", DbType.Decimal, this._FK_LU_Transaction_Category);
			
			db.AddInParameter(dbCommand, "Transaction_Date", DbType.DateTime, this._Transaction_Date);
			
			db.AddInParameter(dbCommand, "Transaction_Amount", DbType.Decimal, this._Transaction_Amount);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the AP_FE_Transactions table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_AP_FE_Transactions)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_TransactionsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_AP_FE_Transactions", DbType.Decimal, pK_AP_FE_Transactions);

			db.ExecuteNonQuery(dbCommand);
		}


        /// <summary>
        /// Select Transaction Record by FK_FraudEvent
        /// </summary>
        public static DataSet SelectTransactionByFKFraudEvent(decimal fK_AP_Fraud_Events)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectTransactionByFKFraudEvent");

            db.AddInParameter(dbCommand, "FK_AP_Fraud_Events", DbType.Decimal, fK_AP_Fraud_Events);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Transaction Record by FK_FraudEvent
        /// </summary>
        public static DataSet SelectFinancialMatrixValue(decimal pK_AP_Fraud_Events)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectFinancialMatrixValue");

            db.AddInParameter(dbCommand, "PK_AP_Fraud_Events", DbType.Decimal, pK_AP_Fraud_Events);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
