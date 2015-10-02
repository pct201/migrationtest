using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_PL_Loss_Category
	/// </summary>
	public sealed class LU_PL_Loss_Category
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_PL_Loss_Category;
		private string _Description;
		private int? _Sort_Order;
		private string _Active;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_PL_Loss_Category value.
		/// </summary>
		public decimal? PK_LU_PL_Loss_Category
		{
			get { return _PK_LU_PL_Loss_Category; }
			set { _PK_LU_PL_Loss_Category = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		/// <summary>
		/// Gets or sets the Sort_Order value.
		/// </summary>
		public int? Sort_Order
		{
			get { return _Sort_Order; }
			set { _Sort_Order = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_PL_Loss_Category class with default value.
		/// </summary>
		public LU_PL_Loss_Category() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_PL_Loss_Category class based on Primary Key.
		/// </summary>
		public LU_PL_Loss_Category(decimal pK_LU_PL_Loss_Category) 
		{
			DataTable dtLU_PL_Loss_Category = Select(pK_LU_PL_Loss_Category).Tables[0];

			if (dtLU_PL_Loss_Category.Rows.Count == 1)
			{
				 SetValue(dtLU_PL_Loss_Category.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_PL_Loss_Category class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_PL_Loss_Category) 
		{
				if (drLU_PL_Loss_Category["PK_LU_PL_Loss_Category"] == DBNull.Value)
					this._PK_LU_PL_Loss_Category = null;
				else
					this._PK_LU_PL_Loss_Category = (decimal?)drLU_PL_Loss_Category["PK_LU_PL_Loss_Category"];

				if (drLU_PL_Loss_Category["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_PL_Loss_Category["Description"];

				if (drLU_PL_Loss_Category["Sort_Order"] == DBNull.Value)
					this._Sort_Order = null;
				else
					this._Sort_Order = (int?)drLU_PL_Loss_Category["Sort_Order"];

				if (drLU_PL_Loss_Category["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_PL_Loss_Category["Active"];

				if (drLU_PL_Loss_Category["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drLU_PL_Loss_Category["Update_Date"];

				if (drLU_PL_Loss_Category["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drLU_PL_Loss_Category["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_PL_Loss_Category table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_Loss_CategoryInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_PL_Loss_Category table.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet Select(decimal pK_LU_PL_Loss_Category)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_Loss_CategorySelect");

			db.AddInParameter(dbCommand, "PK_LU_PL_Loss_Category", DbType.Decimal, pK_LU_PL_Loss_Category);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_PL_Loss_Category table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_Loss_CategorySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects all records from the LU_PL_Loss_Category table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllActive()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_Loss_CategorySelectAllActive");

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the LU_PL_Loss_Category table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_Loss_CategoryUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_PL_Loss_Category", DbType.Decimal, this._PK_LU_PL_Loss_Category);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_PL_Loss_Category table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_PL_Loss_Category)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_Loss_CategoryDelete");

			db.AddInParameter(dbCommand, "PK_LU_PL_Loss_Category", DbType.Decimal, pK_LU_PL_Loss_Category);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Update Sort_Order in LU_Cause_Code_Information table.
        /// </summary>
        public static void UpdateLU_PL_Loss_CategorySortOrder(string xml)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_Loss_CategoryUpdateSortOrder");

            db.AddInParameter(dbCommand, "xmlData", DbType.Xml, xml);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
