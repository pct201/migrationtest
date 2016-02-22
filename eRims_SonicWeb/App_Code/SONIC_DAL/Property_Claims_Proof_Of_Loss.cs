using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table Property_Claims_Proof_Of_Loss
	/// </summary>
	public sealed class Property_Claims_Proof_Of_Loss
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Property_Claims_Proof_Of_Loss;
		private decimal? _FK_Property_Claims_Id;
		private DateTime? _Date;
		private decimal? _FK_LU_Partial_Final;
		private decimal? _Amount;
		private DateTime? _UpdateDate;
		private string _UpdatedBy;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Property_Claims_Proof_Of_Loss value.
		/// </summary>
		public decimal? PK_Property_Claims_Proof_Of_Loss
		{
			get { return _PK_Property_Claims_Proof_Of_Loss; }
			set { _PK_Property_Claims_Proof_Of_Loss = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Property_Claims_Id value.
		/// </summary>
		public decimal? FK_Property_Claims_Id
		{
			get { return _FK_Property_Claims_Id; }
			set { _FK_Property_Claims_Id = value; }
		}

		/// <summary>
		/// Gets or sets the Date value.
		/// </summary>
		public DateTime? Date
		{
			get { return _Date; }
			set { _Date = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Partial_Final value.
		/// </summary>
		public decimal? FK_LU_Partial_Final
		{
			get { return _FK_LU_Partial_Final; }
			set { _FK_LU_Partial_Final = value; }
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
		/// Gets or sets the UpdateDate value.
		/// </summary>
		public DateTime? UpdateDate
		{
			get { return _UpdateDate; }
			set { _UpdateDate = value; }
		}

		/// <summary>
		/// Gets or sets the UpdatedBy value.
		/// </summary>
		public string UpdatedBy
		{
			get { return _UpdatedBy; }
			set { _UpdatedBy = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims_Proof_Of_Loss class with default value.
		/// </summary>
		public Property_Claims_Proof_Of_Loss() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims_Proof_Of_Loss class based on Primary Key.
		/// </summary>
		public Property_Claims_Proof_Of_Loss(decimal pK_Property_Claims_Proof_Of_Loss) 
		{
			DataTable dtProperty_Claims_Proof_Of_Loss = Select(pK_Property_Claims_Proof_Of_Loss).Tables[0];

			if (dtProperty_Claims_Proof_Of_Loss.Rows.Count == 1)
			{
				 SetValue(dtProperty_Claims_Proof_Of_Loss.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Property_Claims_Proof_Of_Loss class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drProperty_Claims_Proof_Of_Loss) 
		{
				if (drProperty_Claims_Proof_Of_Loss["PK_Property_Claims_Proof_Of_Loss"] == DBNull.Value)
					this._PK_Property_Claims_Proof_Of_Loss = null;
				else
					this._PK_Property_Claims_Proof_Of_Loss = (decimal?)drProperty_Claims_Proof_Of_Loss["PK_Property_Claims_Proof_Of_Loss"];

				if (drProperty_Claims_Proof_Of_Loss["FK_Property_Claims_Id"] == DBNull.Value)
					this._FK_Property_Claims_Id = null;
				else
					this._FK_Property_Claims_Id = (decimal?)drProperty_Claims_Proof_Of_Loss["FK_Property_Claims_Id"];

				if (drProperty_Claims_Proof_Of_Loss["Date"] == DBNull.Value)
					this._Date = null;
				else
					this._Date = (DateTime?)drProperty_Claims_Proof_Of_Loss["Date"];

				if (drProperty_Claims_Proof_Of_Loss["FK_LU_Partial_Final"] == DBNull.Value)
					this._FK_LU_Partial_Final = null;
				else
					this._FK_LU_Partial_Final = (decimal?)drProperty_Claims_Proof_Of_Loss["FK_LU_Partial_Final"];

				if (drProperty_Claims_Proof_Of_Loss["Amount"] == DBNull.Value)
					this._Amount = null;
				else
					this._Amount = (decimal?)drProperty_Claims_Proof_Of_Loss["Amount"];

				if (drProperty_Claims_Proof_Of_Loss["UpdateDate"] == DBNull.Value)
					this._UpdateDate = null;
				else
					this._UpdateDate = (DateTime?)drProperty_Claims_Proof_Of_Loss["UpdateDate"];

				if (drProperty_Claims_Proof_Of_Loss["UpdatedBy"] == DBNull.Value)
					this._UpdatedBy = null;
				else
					this._UpdatedBy = (string)drProperty_Claims_Proof_Of_Loss["UpdatedBy"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Property_Claims_Proof_Of_Loss table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_Proof_Of_LossInsert");

			
			db.AddInParameter(dbCommand, "FK_Property_Claims_Id", DbType.Decimal, this._FK_Property_Claims_Id);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			db.AddInParameter(dbCommand, "FK_LU_Partial_Final", DbType.Decimal, this._FK_LU_Partial_Final);
			
			db.AddInParameter(dbCommand, "Amount", DbType.Decimal, this._Amount);
			
			db.AddInParameter(dbCommand, "UpdateDate", DbType.DateTime, this._UpdateDate);
			
			if (string.IsNullOrEmpty(this._UpdatedBy))
				db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, this._UpdatedBy);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Property_Claims_Proof_Of_Loss table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Property_Claims_Proof_Of_Loss)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_Proof_Of_LossSelect");

			db.AddInParameter(dbCommand, "PK_Property_Claims_Proof_Of_Loss", DbType.Decimal, pK_Property_Claims_Proof_Of_Loss);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Property_Claims_Proof_Of_Loss table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_Proof_Of_LossSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Property_Claims_Proof_Of_Loss table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_Proof_Of_LossUpdate");

			
			db.AddInParameter(dbCommand, "PK_Property_Claims_Proof_Of_Loss", DbType.Decimal, this._PK_Property_Claims_Proof_Of_Loss);
			
			db.AddInParameter(dbCommand, "FK_Property_Claims_Id", DbType.Decimal, this._FK_Property_Claims_Id);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			db.AddInParameter(dbCommand, "FK_LU_Partial_Final", DbType.Decimal, this._FK_LU_Partial_Final);
			
			db.AddInParameter(dbCommand, "Amount", DbType.Decimal, this._Amount);
			
			db.AddInParameter(dbCommand, "UpdateDate", DbType.DateTime, this._UpdateDate);
			
			if (string.IsNullOrEmpty(this._UpdatedBy))
				db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, this._UpdatedBy);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Property_Claims_Proof_Of_Loss table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Property_Claims_Proof_Of_Loss)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_Proof_Of_LossDelete");

			db.AddInParameter(dbCommand, "PK_Property_Claims_Proof_Of_Loss", DbType.Decimal, pK_Property_Claims_Proof_Of_Loss);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a All record from the Property_Claims_Proof_Of_Loss table by a FK Property ID
        /// </summary>
        /// <returns>Datatable</returns>
        public static DataTable GetProofOfLossResultByPropertyID(decimal fK_Property_Claims_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_Proof_Of_LossSelectByPropertyID");

            db.AddInParameter(dbCommand, "FK_Property_Claims_ID", DbType.Decimal, fK_Property_Claims_ID);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
	}
}
