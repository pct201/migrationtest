using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RE_Security_Deposit table.
	/// </summary>
	public sealed class RE_Security_Deposit
	{

		#region Private variables used to hold the property values

		private decimal? _PK_RE_Security_Deposit;
		private decimal? _FK_RE_Information;
		private decimal? _Amount;
		private DateTime? _Date_Of_Security_Deposit;
		private decimal? _FK_LU_Tender_Type;
		private string _Received_By;
		private string _Bank_Name;
		private decimal? _Check_Number;
		private string _Name_On_Check;
		private decimal? _Account_Number;
		private decimal? _FK_LU_Security_Deposit_Held;
		private string _Security_Deposit_Returned;
		private DateTime? _Date_Security_Deposit_Returned;
		private string _Security_Deposit_Reduced;
		private string _Security_Deposit_Reduction_Reason;
		private string _Interest_On_Security_Deposit;
		private decimal? _Interest_Amount;
		private decimal? _Amount_Security_Deposit_Returned;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_RE_Security_Deposit value.
		/// </summary>
		public decimal? PK_RE_Security_Deposit
		{
			get { return _PK_RE_Security_Deposit; }
			set { _PK_RE_Security_Deposit = value; }
		}

		/// <summary>
		/// Gets or sets the FK_RE_Information value.
		/// </summary>
		public decimal? FK_RE_Information
		{
			get { return _FK_RE_Information; }
			set { _FK_RE_Information = value; }
		}

		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal? Amount
		{
			get { return _Amount; }
			set { _Amount = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Of_Security_Deposit value.
		/// </summary>
		public DateTime? Date_Of_Security_Deposit
		{
			get { return _Date_Of_Security_Deposit; }
			set { _Date_Of_Security_Deposit = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Tender_Type value.
		/// </summary>
		public decimal? FK_LU_Tender_Type
		{
			get { return _FK_LU_Tender_Type; }
			set { _FK_LU_Tender_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Received_By value.
		/// </summary>
		public string Received_By
		{
			get { return _Received_By; }
			set { _Received_By = value; }
		}

		/// <summary>
		/// Gets or sets the Bank_Name value.
		/// </summary>
		public string Bank_Name
		{
			get { return _Bank_Name; }
			set { _Bank_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Check_Number value.
		/// </summary>
		public decimal? Check_Number
		{
			get { return _Check_Number; }
			set { _Check_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Name_On_Check value.
		/// </summary>
		public string Name_On_Check
		{
			get { return _Name_On_Check; }
			set { _Name_On_Check = value; }
		}

		/// <summary>
		/// Gets or sets the Account_Number value.
		/// </summary>
		public decimal? Account_Number
		{
			get { return _Account_Number; }
			set { _Account_Number = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Security_Deposit_Held value.
		/// </summary>
		public decimal? FK_LU_Security_Deposit_Held
		{
			get { return _FK_LU_Security_Deposit_Held; }
			set { _FK_LU_Security_Deposit_Held = value; }
		}

		/// <summary>
		/// Gets or sets the Security_Deposit_Returned value.
		/// </summary>
		public string Security_Deposit_Returned
		{
			get { return _Security_Deposit_Returned; }
			set { _Security_Deposit_Returned = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Security_Deposit_Returned value.
		/// </summary>
		public DateTime? Date_Security_Deposit_Returned
		{
			get { return _Date_Security_Deposit_Returned; }
			set { _Date_Security_Deposit_Returned = value; }
		}

		/// <summary>
		/// Gets or sets the Security_Deposit_Reduced value.
		/// </summary>
		public string Security_Deposit_Reduced
		{
			get { return _Security_Deposit_Reduced; }
			set { _Security_Deposit_Reduced = value; }
		}

		/// <summary>
		/// Gets or sets the Security_Deposit_Reduction_Reason value.
		/// </summary>
		public string Security_Deposit_Reduction_Reason
		{
			get { return _Security_Deposit_Reduction_Reason; }
			set { _Security_Deposit_Reduction_Reason = value; }
		}

		/// <summary>
		/// Gets or sets the Interest_On_Security_Deposit value.
		/// </summary>
		public string Interest_On_Security_Deposit
		{
			get { return _Interest_On_Security_Deposit; }
			set { _Interest_On_Security_Deposit = value; }
		}

		/// <summary>
		/// Gets or sets the Interest_Amount value.
		/// </summary>
		public decimal? Interest_Amount
		{
			get { return _Interest_Amount; }
			set { _Interest_Amount = value; }
		}

		/// <summary>
		/// Gets or sets the Amount_Security_Deposit_Returned value.
		/// </summary>
		public decimal? Amount_Security_Deposit_Returned
		{
			get { return _Amount_Security_Deposit_Returned; }
			set { _Amount_Security_Deposit_Returned = value; }
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
		/// Initializes a new instance of the RE_Security_Deposit class with default value.
		/// </summary>
		public RE_Security_Deposit() 
		{
            setDefaultValues();
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the RE_Security_Deposit class based on FK.
		/// </summary>
		public RE_Security_Deposit(decimal pK_RE_Security_Deposit) 
		{
			DataTable dtRE_Security_Deposit = SelectByPK(pK_RE_Security_Deposit).Tables[0];

			if (dtRE_Security_Deposit.Rows.Count == 1)
			{
				DataRow drRE_Security_Deposit = dtRE_Security_Deposit.Rows[0];
				if (drRE_Security_Deposit["PK_RE_Security_Deposit"] == DBNull.Value)
					this._PK_RE_Security_Deposit = null;
				else
					this._PK_RE_Security_Deposit = (decimal?)drRE_Security_Deposit["PK_RE_Security_Deposit"];

				if (drRE_Security_Deposit["FK_RE_Information"] == DBNull.Value)
					this._FK_RE_Information = null;
				else
					this._FK_RE_Information = (decimal?)drRE_Security_Deposit["FK_RE_Information"];

				if (drRE_Security_Deposit["Amount"] == DBNull.Value)
					this._Amount = null;
				else
					this._Amount = (decimal?)drRE_Security_Deposit["Amount"];

				if (drRE_Security_Deposit["Date_Of_Security_Deposit"] == DBNull.Value)
					this._Date_Of_Security_Deposit = null;
				else
					this._Date_Of_Security_Deposit = (DateTime?)drRE_Security_Deposit["Date_Of_Security_Deposit"];

				if (drRE_Security_Deposit["FK_LU_Tender_Type"] == DBNull.Value)
					this._FK_LU_Tender_Type = null;
				else
					this._FK_LU_Tender_Type = (decimal?)drRE_Security_Deposit["FK_LU_Tender_Type"];

				if (drRE_Security_Deposit["Received_By"] == DBNull.Value)
					this._Received_By = null;
				else
					this._Received_By = (string)drRE_Security_Deposit["Received_By"];

				if (drRE_Security_Deposit["Bank_Name"] == DBNull.Value)
					this._Bank_Name = null;
				else
					this._Bank_Name = (string)drRE_Security_Deposit["Bank_Name"];

				if (drRE_Security_Deposit["Check_Number"] == DBNull.Value)
					this._Check_Number = null;
				else
					this._Check_Number = (decimal?)drRE_Security_Deposit["Check_Number"];

				if (drRE_Security_Deposit["Name_On_Check"] == DBNull.Value)
					this._Name_On_Check = null;
				else
					this._Name_On_Check = (string)drRE_Security_Deposit["Name_On_Check"];

				if (drRE_Security_Deposit["Account_Number"] == DBNull.Value)
					this._Account_Number = null;
				else
					this._Account_Number = (decimal?)drRE_Security_Deposit["Account_Number"];

				if (drRE_Security_Deposit["FK_LU_Security_Deposit_Held"] == DBNull.Value)
					this._FK_LU_Security_Deposit_Held = null;
				else
					this._FK_LU_Security_Deposit_Held = (decimal?)drRE_Security_Deposit["FK_LU_Security_Deposit_Held"];

				if (drRE_Security_Deposit["Security_Deposit_Returned"] == DBNull.Value)
					this._Security_Deposit_Returned = null;
				else
					this._Security_Deposit_Returned = (string)drRE_Security_Deposit["Security_Deposit_Returned"];

				if (drRE_Security_Deposit["Date_Security_Deposit_Returned"] == DBNull.Value)
					this._Date_Security_Deposit_Returned = null;
				else
					this._Date_Security_Deposit_Returned = (DateTime?)drRE_Security_Deposit["Date_Security_Deposit_Returned"];

				if (drRE_Security_Deposit["Security_Deposit_Reduced"] == DBNull.Value)
					this._Security_Deposit_Reduced = null;
				else
					this._Security_Deposit_Reduced = (string)drRE_Security_Deposit["Security_Deposit_Reduced"];

				if (drRE_Security_Deposit["Security_Deposit_Reduction_Reason"] == DBNull.Value)
					this._Security_Deposit_Reduction_Reason = null;
				else
					this._Security_Deposit_Reduction_Reason = (string)drRE_Security_Deposit["Security_Deposit_Reduction_Reason"];

				if (drRE_Security_Deposit["Interest_On_Security_Deposit"] == DBNull.Value)
					this._Interest_On_Security_Deposit = null;
				else
					this._Interest_On_Security_Deposit = (string)drRE_Security_Deposit["Interest_On_Security_Deposit"];

				if (drRE_Security_Deposit["Interest_Amount"] == DBNull.Value)
					this._Interest_Amount = null;
				else
					this._Interest_Amount = (decimal?)drRE_Security_Deposit["Interest_Amount"];

				if (drRE_Security_Deposit["Amount_Security_Deposit_Returned"] == DBNull.Value)
					this._Amount_Security_Deposit_Returned = null;
				else
					this._Amount_Security_Deposit_Returned = (decimal?)drRE_Security_Deposit["Amount_Security_Deposit_Returned"];

				if (drRE_Security_Deposit["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drRE_Security_Deposit["Updated_By"];

				if (drRE_Security_Deposit["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drRE_Security_Deposit["Update_Date"];

			}
			else
			{
                setDefaultValues();
			}

		}

        /// <summary>
        /// Initializes a new instance of the RE_Security_Deposit class based on Primary Key.
        /// </summary>
        public RE_Security_Deposit(decimal _FK_RE_Information,bool isStatus)
        {
            DataTable dtRE_Security_Deposit = SelectByFK(_FK_RE_Information).Tables[0];

            if (dtRE_Security_Deposit.Rows.Count == 1)
            {
                DataRow drRE_Security_Deposit = dtRE_Security_Deposit.Rows[0];
                if (drRE_Security_Deposit["PK_RE_Security_Deposit"] == DBNull.Value)
                    this._PK_RE_Security_Deposit = null;
                else
                    this._PK_RE_Security_Deposit = (decimal?)drRE_Security_Deposit["PK_RE_Security_Deposit"];

                if (drRE_Security_Deposit["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Security_Deposit["FK_RE_Information"];

                if (drRE_Security_Deposit["Amount"] == DBNull.Value)
                    this._Amount = null;
                else
                    this._Amount = (decimal?)drRE_Security_Deposit["Amount"];

                if (drRE_Security_Deposit["Date_Of_Security_Deposit"] == DBNull.Value)
                    this._Date_Of_Security_Deposit = null;
                else
                    this._Date_Of_Security_Deposit = (DateTime?)drRE_Security_Deposit["Date_Of_Security_Deposit"];

                if (drRE_Security_Deposit["FK_LU_Tender_Type"] == DBNull.Value)
                    this._FK_LU_Tender_Type = null;
                else
                    this._FK_LU_Tender_Type = (decimal?)drRE_Security_Deposit["FK_LU_Tender_Type"];

                if (drRE_Security_Deposit["Received_By"] == DBNull.Value)
                    this._Received_By = null;
                else
                    this._Received_By = (string)drRE_Security_Deposit["Received_By"];

                if (drRE_Security_Deposit["Bank_Name"] == DBNull.Value)
                    this._Bank_Name = null;
                else
                    this._Bank_Name = (string)drRE_Security_Deposit["Bank_Name"];

                if (drRE_Security_Deposit["Check_Number"] == DBNull.Value)
                    this._Check_Number = null;
                else
                    this._Check_Number = (decimal?)drRE_Security_Deposit["Check_Number"];

                if (drRE_Security_Deposit["Name_On_Check"] == DBNull.Value)
                    this._Name_On_Check = null;
                else
                    this._Name_On_Check = (string)drRE_Security_Deposit["Name_On_Check"];

                if (drRE_Security_Deposit["Account_Number"] == DBNull.Value)
                    this._Account_Number = null;
                else
                    this._Account_Number = (decimal?)drRE_Security_Deposit["Account_Number"];

                if (drRE_Security_Deposit["FK_LU_Security_Deposit_Held"] == DBNull.Value)
                    this._FK_LU_Security_Deposit_Held = null;
                else
                    this._FK_LU_Security_Deposit_Held = (decimal?)drRE_Security_Deposit["FK_LU_Security_Deposit_Held"];

                if (drRE_Security_Deposit["Security_Deposit_Returned"] == DBNull.Value)
                    this._Security_Deposit_Returned = null;
                else
                    this._Security_Deposit_Returned = (string)drRE_Security_Deposit["Security_Deposit_Returned"];

                if (drRE_Security_Deposit["Date_Security_Deposit_Returned"] == DBNull.Value)
                    this._Date_Security_Deposit_Returned = null;
                else
                    this._Date_Security_Deposit_Returned = (DateTime?)drRE_Security_Deposit["Date_Security_Deposit_Returned"];

                if (drRE_Security_Deposit["Security_Deposit_Reduced"] == DBNull.Value)
                    this._Security_Deposit_Reduced = null;
                else
                    this._Security_Deposit_Reduced = (string)drRE_Security_Deposit["Security_Deposit_Reduced"];

                if (drRE_Security_Deposit["Security_Deposit_Reduction_Reason"] == DBNull.Value)
                    this._Security_Deposit_Reduction_Reason = null;
                else
                    this._Security_Deposit_Reduction_Reason = (string)drRE_Security_Deposit["Security_Deposit_Reduction_Reason"];

                if (drRE_Security_Deposit["Interest_On_Security_Deposit"] == DBNull.Value)
                    this._Interest_On_Security_Deposit = null;
                else
                    this._Interest_On_Security_Deposit = (string)drRE_Security_Deposit["Interest_On_Security_Deposit"];

                if (drRE_Security_Deposit["Interest_Amount"] == DBNull.Value)
                    this._Interest_Amount = null;
                else
                    this._Interest_Amount = (decimal?)drRE_Security_Deposit["Interest_Amount"];

                if (drRE_Security_Deposit["Amount_Security_Deposit_Returned"] == DBNull.Value)
                    this._Amount_Security_Deposit_Returned = null;
                else
                    this._Amount_Security_Deposit_Returned = (decimal?)drRE_Security_Deposit["Amount_Security_Deposit_Returned"];

                if (drRE_Security_Deposit["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Security_Deposit["Updated_By"];

                if (drRE_Security_Deposit["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Security_Deposit["Update_Date"];

            }
            else
            {
                setDefaultValues();
            }

        }

		#endregion

        private void setDefaultValues()
        {
            this._PK_RE_Security_Deposit = null;
            this._FK_RE_Information = null;
            this._Amount = null;
            this._Date_Of_Security_Deposit = null;
            this._FK_LU_Tender_Type = null;
            this._Received_By = null;
            this._Bank_Name = null;
            this._Check_Number = null;
            this._Name_On_Check = null;
            this._Account_Number = null;
            this._FK_LU_Security_Deposit_Held = null;
            this._Security_Deposit_Returned = null;
            this._Date_Security_Deposit_Returned = null;
            this._Security_Deposit_Reduced = null;
            this._Security_Deposit_Reduction_Reason = null;
            this._Interest_On_Security_Deposit = null;
            this._Interest_Amount = null;
            this._Amount_Security_Deposit_Returned = null;
            this._Updated_By = null;
            this._Update_Date = null;
        }

		/// <summary>
		/// Inserts a record into the RE_Security_Deposit table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Security_DepositInsert");

			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			db.AddInParameter(dbCommand, "Amount", DbType.Decimal, this._Amount);
			
			db.AddInParameter(dbCommand, "Date_Of_Security_Deposit", DbType.DateTime, this._Date_Of_Security_Deposit);
			
			db.AddInParameter(dbCommand, "FK_LU_Tender_Type", DbType.Decimal, this._FK_LU_Tender_Type);
			
			if (string.IsNullOrEmpty(this._Received_By))
				db.AddInParameter(dbCommand, "Received_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Received_By", DbType.String, this._Received_By);
			
			if (string.IsNullOrEmpty(this._Bank_Name))
				db.AddInParameter(dbCommand, "Bank_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Bank_Name", DbType.String, this._Bank_Name);
			
			db.AddInParameter(dbCommand, "Check_Number", DbType.Decimal, this._Check_Number);
			
			if (string.IsNullOrEmpty(this._Name_On_Check))
				db.AddInParameter(dbCommand, "Name_On_Check", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Name_On_Check", DbType.String, this._Name_On_Check);
			
			db.AddInParameter(dbCommand, "Account_Number", DbType.Decimal, this._Account_Number);
			
			db.AddInParameter(dbCommand, "FK_LU_Security_Deposit_Held", DbType.Decimal, this._FK_LU_Security_Deposit_Held);
			
			if (string.IsNullOrEmpty(this._Security_Deposit_Returned))
				db.AddInParameter(dbCommand, "Security_Deposit_Returned", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Security_Deposit_Returned", DbType.String, this._Security_Deposit_Returned);
			
			db.AddInParameter(dbCommand, "Date_Security_Deposit_Returned", DbType.DateTime, this._Date_Security_Deposit_Returned);
			
			if (string.IsNullOrEmpty(this._Security_Deposit_Reduced))
				db.AddInParameter(dbCommand, "Security_Deposit_Reduced", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Security_Deposit_Reduced", DbType.String, this._Security_Deposit_Reduced);
			
			if (string.IsNullOrEmpty(this._Security_Deposit_Reduction_Reason))
				db.AddInParameter(dbCommand, "Security_Deposit_Reduction_Reason", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Security_Deposit_Reduction_Reason", DbType.String, this._Security_Deposit_Reduction_Reason);
			
			if (string.IsNullOrEmpty(this._Interest_On_Security_Deposit))
				db.AddInParameter(dbCommand, "Interest_On_Security_Deposit", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Interest_On_Security_Deposit", DbType.String, this._Interest_On_Security_Deposit);
			
			db.AddInParameter(dbCommand, "Interest_Amount", DbType.Decimal, this._Interest_Amount);
			
			db.AddInParameter(dbCommand, "Amount_Security_Deposit_Returned", DbType.Decimal, this._Amount_Security_Deposit_Returned);
			
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
		/// Selects a single record from the RE_Security_Deposit table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_RE_Security_Deposit)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Security_DepositSelectByPK");

			db.AddInParameter(dbCommand, "PK_RE_Security_Deposit", DbType.Decimal, pK_RE_Security_Deposit);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the RE_Security_Deposit table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByFK(decimal _FK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Security_DepositSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, _FK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the RE_Security_Deposit table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Security_DepositSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the RE_Security_Deposit table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Security_DepositUpdate");

			
			db.AddInParameter(dbCommand, "PK_RE_Security_Deposit", DbType.Decimal, this._PK_RE_Security_Deposit);
			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			db.AddInParameter(dbCommand, "Amount", DbType.Decimal, this._Amount);
			
			db.AddInParameter(dbCommand, "Date_Of_Security_Deposit", DbType.DateTime, this._Date_Of_Security_Deposit);
			
			db.AddInParameter(dbCommand, "FK_LU_Tender_Type", DbType.Decimal, this._FK_LU_Tender_Type);
			
			if (string.IsNullOrEmpty(this._Received_By))
				db.AddInParameter(dbCommand, "Received_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Received_By", DbType.String, this._Received_By);
			
			if (string.IsNullOrEmpty(this._Bank_Name))
				db.AddInParameter(dbCommand, "Bank_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Bank_Name", DbType.String, this._Bank_Name);
			
			db.AddInParameter(dbCommand, "Check_Number", DbType.Decimal, this._Check_Number);
			
			if (string.IsNullOrEmpty(this._Name_On_Check))
				db.AddInParameter(dbCommand, "Name_On_Check", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Name_On_Check", DbType.String, this._Name_On_Check);
			
			db.AddInParameter(dbCommand, "Account_Number", DbType.Decimal, this._Account_Number);
			
			db.AddInParameter(dbCommand, "FK_LU_Security_Deposit_Held", DbType.Decimal, this._FK_LU_Security_Deposit_Held);
			
			if (string.IsNullOrEmpty(this._Security_Deposit_Returned))
				db.AddInParameter(dbCommand, "Security_Deposit_Returned", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Security_Deposit_Returned", DbType.String, this._Security_Deposit_Returned);
			
			db.AddInParameter(dbCommand, "Date_Security_Deposit_Returned", DbType.DateTime, this._Date_Security_Deposit_Returned);
			
			if (string.IsNullOrEmpty(this._Security_Deposit_Reduced))
				db.AddInParameter(dbCommand, "Security_Deposit_Reduced", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Security_Deposit_Reduced", DbType.String, this._Security_Deposit_Reduced);
			
			if (string.IsNullOrEmpty(this._Security_Deposit_Reduction_Reason))
				db.AddInParameter(dbCommand, "Security_Deposit_Reduction_Reason", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Security_Deposit_Reduction_Reason", DbType.String, this._Security_Deposit_Reduction_Reason);
			
			if (string.IsNullOrEmpty(this._Interest_On_Security_Deposit))
				db.AddInParameter(dbCommand, "Interest_On_Security_Deposit", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Interest_On_Security_Deposit", DbType.String, this._Interest_On_Security_Deposit);
			
			db.AddInParameter(dbCommand, "Interest_Amount", DbType.Decimal, this._Interest_Amount);
			
			db.AddInParameter(dbCommand, "Amount_Security_Deposit_Returned", DbType.Decimal, this._Amount_Security_Deposit_Returned);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the RE_Security_Deposit table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_RE_Security_Deposit)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Security_DepositDeleteByPK");

			db.AddInParameter(dbCommand, "PK_RE_Security_Deposit", DbType.Decimal, pK_RE_Security_Deposit);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
