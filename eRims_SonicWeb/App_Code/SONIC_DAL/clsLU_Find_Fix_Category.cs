using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Find_Fix_Category table.
	/// </summary>
	public sealed class clsLU_Find_Fix_Category
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Find_Fix_Category;
		private string _Description;
		private int? _Sort_Order;
		private string _Active;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Find_Fix_Category value.
		/// </summary>
		public decimal? PK_LU_Find_Fix_Category
		{
			get { return _PK_LU_Find_Fix_Category; }
			set { _PK_LU_Find_Fix_Category = value; }
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
		/// Initializes a new instance of the clsLU_Find_Fix_Category class with default value.
		/// </summary>
		public clsLU_Find_Fix_Category() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Find_Fix_Category class based on Primary Key.
		/// </summary>
		public clsLU_Find_Fix_Category(decimal pK_LU_Find_Fix_Category) 
		{
			DataTable dtLU_Find_Fix_Category = SelectByPK(pK_LU_Find_Fix_Category).Tables[0];

			if (dtLU_Find_Fix_Category.Rows.Count == 1)
			{
				 SetValue(dtLU_Find_Fix_Category.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Find_Fix_Category class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Find_Fix_Category) 
		{
				if (drLU_Find_Fix_Category["PK_LU_Find_Fix_Category"] == DBNull.Value)
					this._PK_LU_Find_Fix_Category = null;
				else
					this._PK_LU_Find_Fix_Category = (decimal?)drLU_Find_Fix_Category["PK_LU_Find_Fix_Category"];

				if (drLU_Find_Fix_Category["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Find_Fix_Category["Description"];

				if (drLU_Find_Fix_Category["Sort_Order"] == DBNull.Value)
					this._Sort_Order = null;
				else
					this._Sort_Order = (int?)drLU_Find_Fix_Category["Sort_Order"];

				if (drLU_Find_Fix_Category["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Find_Fix_Category["Active"];

				if (drLU_Find_Fix_Category["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drLU_Find_Fix_Category["Update_Date"];

				if (drLU_Find_Fix_Category["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drLU_Find_Fix_Category["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Find_Fix_Category table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Find_Fix_CategoryInsert");

			
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
		/// Selects a single record from the LU_Find_Fix_Category table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_LU_Find_Fix_Category)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Find_Fix_CategorySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Find_Fix_Category", DbType.Decimal, pK_LU_Find_Fix_Category);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Find_Fix_Category table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Find_Fix_CategorySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Find_Fix_Category table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Find_Fix_CategoryUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Find_Fix_Category", DbType.Decimal, this._PK_LU_Find_Fix_Category);
			
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
		/// Deletes a record from the LU_Find_Fix_Category table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Find_Fix_Category)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Find_Fix_CategoryDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Find_Fix_Category", DbType.Decimal, pK_LU_Find_Fix_Category);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Update Sort_Order in LU_Find_Fix_Category table.
        /// </summary>
        public static void UpdateLU_Find_Fix_CategorySortOrder(string xml)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Find_Fix_CategoryUpdateSortOrder");

            db.AddInParameter(dbCommand, "xmlData", DbType.Xml, xml);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
