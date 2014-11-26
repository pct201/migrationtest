using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table Claim_CST
	/// </summary>
	public sealed class Claim_CST
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Claim_CST;
		private string _Origin_Claim_Number;
		private string _Processing_Office;
		private DateTime? _Status_Date_Change;
		private string _Status;
		private string _Sub_Status;
		private string _Reopen_Flag;
		private decimal? _FK_LU_Reason_For_Denial_1;
		private decimal? _FK_LU_Reason_For_Denial_2;
		private decimal? _FK_LU_Reason_For_Denial_3;
		private decimal? _FK_LU_Reason_For_Denial_4;
		private decimal? _FK_LU_Reason_For_Denial_5;
		private DateTime? _Updated_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Claim_CST value.
		/// </summary>
		public decimal? PK_Claim_CST
		{
			get { return _PK_Claim_CST; }
			set { _PK_Claim_CST = value; }
		}

		/// <summary>
		/// Gets or sets the Origin_Claim_Number value.
		/// </summary>
		public string Origin_Claim_Number
		{
			get { return _Origin_Claim_Number; }
			set { _Origin_Claim_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Processing_Office value.
		/// </summary>
		public string Processing_Office
		{
			get { return _Processing_Office; }
			set { _Processing_Office = value; }
		}

		/// <summary>
		/// Gets or sets the Status_Date_Change value.
		/// </summary>
		public DateTime? Status_Date_Change
		{
			get { return _Status_Date_Change; }
			set { _Status_Date_Change = value; }
		}

		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public string Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		/// <summary>
		/// Gets or sets the Sub_Status value.
		/// </summary>
		public string Sub_Status
		{
			get { return _Sub_Status; }
			set { _Sub_Status = value; }
		}

		/// <summary>
		/// Gets or sets the Reopen_Flag value.
		/// </summary>
		public string Reopen_Flag
		{
			get { return _Reopen_Flag; }
			set { _Reopen_Flag = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Reason_For_Denial_1 value.
		/// </summary>
		public decimal? FK_LU_Reason_For_Denial_1
		{
			get { return _FK_LU_Reason_For_Denial_1; }
			set { _FK_LU_Reason_For_Denial_1 = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Reason_For_Denial_2 value.
		/// </summary>
		public decimal? FK_LU_Reason_For_Denial_2
		{
			get { return _FK_LU_Reason_For_Denial_2; }
			set { _FK_LU_Reason_For_Denial_2 = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Reason_For_Denial_3 value.
		/// </summary>
		public decimal? FK_LU_Reason_For_Denial_3
		{
			get { return _FK_LU_Reason_For_Denial_3; }
			set { _FK_LU_Reason_For_Denial_3 = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Reason_For_Denial_4 value.
		/// </summary>
		public decimal? FK_LU_Reason_For_Denial_4
		{
			get { return _FK_LU_Reason_For_Denial_4; }
			set { _FK_LU_Reason_For_Denial_4 = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Reason_For_Denial_5 value.
		/// </summary>
		public decimal? FK_LU_Reason_For_Denial_5
		{
			get { return _FK_LU_Reason_For_Denial_5; }
			set { _FK_LU_Reason_For_Denial_5 = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_Date value.
		/// </summary>
		public DateTime? Updated_Date
		{
			get { return _Updated_Date; }
			set { _Updated_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Claim_CST class with default value.
		/// </summary>
		public Claim_CST() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Claim_CST class based on Primary Key.
		/// </summary>
		public Claim_CST(decimal pK_Claim_CST) 
		{
			DataTable dtClaim_CST = Select(pK_Claim_CST).Tables[0];

			if (dtClaim_CST.Rows.Count == 1)
			{
				 SetValue(dtClaim_CST.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Claim_CST class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drClaim_CST) 
		{
				if (drClaim_CST["PK_Claim_CST"] == DBNull.Value)
					this._PK_Claim_CST = null;
				else
					this._PK_Claim_CST = (decimal?)drClaim_CST["PK_Claim_CST"];

				if (drClaim_CST["Origin_Claim_Number"] == DBNull.Value)
					this._Origin_Claim_Number = null;
				else
					this._Origin_Claim_Number = (string)drClaim_CST["Origin_Claim_Number"];

				if (drClaim_CST["Processing_Office"] == DBNull.Value)
					this._Processing_Office = null;
				else
					this._Processing_Office = (string)drClaim_CST["Processing_Office"];

				if (drClaim_CST["Status_Date_Change"] == DBNull.Value)
					this._Status_Date_Change = null;
				else
					this._Status_Date_Change = (DateTime?)drClaim_CST["Status_Date_Change"];

				if (drClaim_CST["Status"] == DBNull.Value)
					this._Status = null;
				else
					this._Status = (string)drClaim_CST["Status"];

				if (drClaim_CST["Sub_Status"] == DBNull.Value)
					this._Sub_Status = null;
				else
					this._Sub_Status = (string)drClaim_CST["Sub_Status"];

				if (drClaim_CST["Reopen_Flag"] == DBNull.Value)
					this._Reopen_Flag = null;
				else
					this._Reopen_Flag = (string)drClaim_CST["Reopen_Flag"];

				if (drClaim_CST["FK_LU_Reason_For_Denial_1"] == DBNull.Value)
					this._FK_LU_Reason_For_Denial_1 = null;
				else
					this._FK_LU_Reason_For_Denial_1 = (decimal?)drClaim_CST["FK_LU_Reason_For_Denial_1"];

				if (drClaim_CST["FK_LU_Reason_For_Denial_2"] == DBNull.Value)
					this._FK_LU_Reason_For_Denial_2 = null;
				else
					this._FK_LU_Reason_For_Denial_2 = (decimal?)drClaim_CST["FK_LU_Reason_For_Denial_2"];

				if (drClaim_CST["FK_LU_Reason_For_Denial_3"] == DBNull.Value)
					this._FK_LU_Reason_For_Denial_3 = null;
				else
					this._FK_LU_Reason_For_Denial_3 = (decimal?)drClaim_CST["FK_LU_Reason_For_Denial_3"];

				if (drClaim_CST["FK_LU_Reason_For_Denial_4"] == DBNull.Value)
					this._FK_LU_Reason_For_Denial_4 = null;
				else
					this._FK_LU_Reason_For_Denial_4 = (decimal?)drClaim_CST["FK_LU_Reason_For_Denial_4"];

				if (drClaim_CST["FK_LU_Reason_For_Denial_5"] == DBNull.Value)
					this._FK_LU_Reason_For_Denial_5 = null;
				else
					this._FK_LU_Reason_For_Denial_5 = (decimal?)drClaim_CST["FK_LU_Reason_For_Denial_5"];

				if (drClaim_CST["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drClaim_CST["Updated_Date"];

				if (drClaim_CST["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drClaim_CST["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Claim_CST table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_CSTInsert");

			
			if (string.IsNullOrEmpty(this._Origin_Claim_Number))
				db.AddInParameter(dbCommand, "Origin_Claim_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Origin_Claim_Number", DbType.String, this._Origin_Claim_Number);
			
			if (string.IsNullOrEmpty(this._Processing_Office))
				db.AddInParameter(dbCommand, "Processing_Office", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Processing_Office", DbType.String, this._Processing_Office);
			
			db.AddInParameter(dbCommand, "Status_Date_Change", DbType.DateTime, this._Status_Date_Change);
			
			if (string.IsNullOrEmpty(this._Status))
				db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);
			
			if (string.IsNullOrEmpty(this._Sub_Status))
				db.AddInParameter(dbCommand, "Sub_Status", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sub_Status", DbType.String, this._Sub_Status);
			
			if (string.IsNullOrEmpty(this._Reopen_Flag))
				db.AddInParameter(dbCommand, "Reopen_Flag", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reopen_Flag", DbType.String, this._Reopen_Flag);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_1", DbType.Decimal, this._FK_LU_Reason_For_Denial_1);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_2", DbType.Decimal, this._FK_LU_Reason_For_Denial_2);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_3", DbType.Decimal, this._FK_LU_Reason_For_Denial_3);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_4", DbType.Decimal, this._FK_LU_Reason_For_Denial_4);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_5", DbType.Decimal, this._FK_LU_Reason_For_Denial_5);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Claim_CST table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Claim_CST)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_CSTSelect");

			db.AddInParameter(dbCommand, "PK_Claim_CST", DbType.Decimal, pK_Claim_CST);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Claim_CST table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_CSTSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Claim_CST table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_CSTUpdate");

			
			db.AddInParameter(dbCommand, "PK_Claim_CST", DbType.Decimal, this._PK_Claim_CST);
			
			if (string.IsNullOrEmpty(this._Origin_Claim_Number))
				db.AddInParameter(dbCommand, "Origin_Claim_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Origin_Claim_Number", DbType.String, this._Origin_Claim_Number);
			
			if (string.IsNullOrEmpty(this._Processing_Office))
				db.AddInParameter(dbCommand, "Processing_Office", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Processing_Office", DbType.String, this._Processing_Office);
			
			db.AddInParameter(dbCommand, "Status_Date_Change", DbType.DateTime, this._Status_Date_Change);
			
			if (string.IsNullOrEmpty(this._Status))
				db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);
			
			if (string.IsNullOrEmpty(this._Sub_Status))
				db.AddInParameter(dbCommand, "Sub_Status", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sub_Status", DbType.String, this._Sub_Status);
			
			if (string.IsNullOrEmpty(this._Reopen_Flag))
				db.AddInParameter(dbCommand, "Reopen_Flag", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reopen_Flag", DbType.String, this._Reopen_Flag);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_1", DbType.Decimal, this._FK_LU_Reason_For_Denial_1);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_2", DbType.Decimal, this._FK_LU_Reason_For_Denial_2);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_3", DbType.Decimal, this._FK_LU_Reason_For_Denial_3);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_4", DbType.Decimal, this._FK_LU_Reason_For_Denial_4);
			
			db.AddInParameter(dbCommand, "FK_LU_Reason_For_Denial_5", DbType.Decimal, this._FK_LU_Reason_For_Denial_5);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Claim_CST table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Claim_CST)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_CSTDelete");

			db.AddInParameter(dbCommand, "PK_Claim_CST", DbType.Decimal, pK_Claim_CST);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Select claim cst detail by origin claim number
        /// </summary>
        /// <param name="Origin_Claim_Number"></param>
        /// <returns></returns>
        public static DataSet Claim_CSTSelectByOriginClaimNumber(string Origin_Claim_Number)
        {
            DataSet objDs = new DataSet();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claim_CSTSelectByOriginClaimNumber");

            db.AddInParameter(dbCommand, "Origin_Claim_Number", DbType.String, Origin_Claim_Number);
            objDs = db.ExecuteDataSet(dbCommand);

            return objDs;
        }
	}
}
