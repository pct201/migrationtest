using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Business_Rules_Email_Fields table.
	/// </summary>
	public sealed class Business_Rules_Email_Fields
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Business_Rules_Email_Fields;
		private decimal? _FK_Business_Rules;
		private string _Email_Fields;
        private decimal? _FK_Business_Rules_Fields;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Business_Rules_Email_Fields value.
		/// </summary>
		public decimal? PK_Business_Rules_Email_Fields
		{
			get { return _PK_Business_Rules_Email_Fields; }
			set { _PK_Business_Rules_Email_Fields = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Business_Rules value.
		/// </summary>
		public decimal? FK_Business_Rules
		{
			get { return _FK_Business_Rules; }
			set { _FK_Business_Rules = value; }
		}

		/// <summary>
		/// Gets or sets the Email_Fields value.
		/// </summary>
		public string Email_Fields
		{
			get { return _Email_Fields; }
			set { _Email_Fields = value; }
		}

        /// <summary>
        /// Gets or sets the FK_Business_Rules_Fields value.
        /// </summary>
        public decimal? FK_Business_Rules_Fields
        {
            get { return _FK_Business_Rules_Fields; }
            set { _FK_Business_Rules_Fields = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rules_Email_Fields class with default value.
		/// </summary>
		public Business_Rules_Email_Fields() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rules_Email_Fields class based on Primary Key.
		/// </summary>
		public Business_Rules_Email_Fields(decimal pK_Business_Rules_Email_Fields) 
		{
			DataTable dtBusiness_Rules_Email_Fields = SelectByPK(pK_Business_Rules_Email_Fields).Tables[0];

			if (dtBusiness_Rules_Email_Fields.Rows.Count == 1)
			{
				 SetValue(dtBusiness_Rules_Email_Fields.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rules_Email_Fields class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drBusiness_Rules_Email_Fields) 
		{
				if (drBusiness_Rules_Email_Fields["PK_Business_Rules_Email_Fields"] == DBNull.Value)
					this._PK_Business_Rules_Email_Fields = null;
				else
					this._PK_Business_Rules_Email_Fields = (decimal?)drBusiness_Rules_Email_Fields["PK_Business_Rules_Email_Fields"];

				if (drBusiness_Rules_Email_Fields["FK_Business_Rules"] == DBNull.Value)
					this._FK_Business_Rules = null;
				else
					this._FK_Business_Rules = (decimal?)drBusiness_Rules_Email_Fields["FK_Business_Rules"];

				if (drBusiness_Rules_Email_Fields["Email_Fields"] == DBNull.Value)
					this._Email_Fields = null;
				else
					this._Email_Fields = (string)drBusiness_Rules_Email_Fields["Email_Fields"];

                if (drBusiness_Rules_Email_Fields["FK_Business_Rules_Fields"] == DBNull.Value)
                    this._FK_Business_Rules_Fields = null;
                else
                    this._FK_Business_Rules_Fields = (decimal?)drBusiness_Rules_Email_Fields["FK_Business_Rules_Fields"];
		}

		#endregion

        
		/// <summary>
		/// Inserts a record into the Business_Rules_Email_Fields table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_Email_FieldsInsert");
			
			db.AddInParameter(dbCommand, "FK_Business_Rules", DbType.Decimal, this._FK_Business_Rules);
			
			if (string.IsNullOrEmpty(this._Email_Fields))
				db.AddInParameter(dbCommand, "Email_Fields", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email_Fields", DbType.String, this._Email_Fields);

            db.AddInParameter(dbCommand, "FK_Business_Rules_Fields", DbType.Decimal, this._FK_Business_Rules_Fields);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Business_Rules_Email_Fields table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Business_Rules_Email_Fields)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_Email_FieldsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Business_Rules_Email_Fields", DbType.Decimal, pK_Business_Rules_Email_Fields);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Business_Rules_Email_Fields table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal fK_Business_Rules)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_Email_FieldsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Business_Rules", DbType.Decimal, fK_Business_Rules);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the Business_Rules_Email_Fields table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_Email_FieldsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Business_Rules_Email_Fields table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_Email_FieldsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Business_Rules_Email_Fields", DbType.Decimal, this._PK_Business_Rules_Email_Fields);
			
			db.AddInParameter(dbCommand, "FK_Business_Rules", DbType.Decimal, this._FK_Business_Rules);
			
			if (string.IsNullOrEmpty(this._Email_Fields))
				db.AddInParameter(dbCommand, "Email_Fields", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email_Fields", DbType.String, this._Email_Fields);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Business_Rules_Email_Fields table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Business_Rules_Email_Fields)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_Email_FieldsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Business_Rules_Email_Fields", DbType.Decimal, pK_Business_Rules_Email_Fields);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the Business_Rules_Email_Fields table by a foreign key.
        /// </summary>
        public static void DeleteByFK(decimal fK_Business_Rules)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_Email_FieldsDeleteByFK");

            db.AddInParameter(dbCommand, "FK_Business_Rules", DbType.Decimal, fK_Business_Rules);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
