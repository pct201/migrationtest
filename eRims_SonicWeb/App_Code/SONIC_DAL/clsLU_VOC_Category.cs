using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_VOC_Category table.
	/// </summary>
	public sealed class clsLU_VOC_Category
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_VOC_Category;
		private string _Category;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_VOC_Category value.
		/// </summary>
		public decimal? PK_LU_VOC_Category
		{
			get { return _PK_LU_VOC_Category; }
			set { _PK_LU_VOC_Category = value; }
		}

		/// <summary>
		/// Gets or sets the Category value.
		/// </summary>
		public string Category
		{
			get { return _Category; }
			set { _Category = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_VOC_Category class with default value.
		/// </summary>
		public clsLU_VOC_Category() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_VOC_Category class based on Primary Key.
		/// </summary>
		public clsLU_VOC_Category(decimal pK_LU_VOC_Category) 
		{
			DataTable dtLU_VOC_Category = SelectByPK(pK_LU_VOC_Category).Tables[0];

			if (dtLU_VOC_Category.Rows.Count == 1)
			{
				 SetValue(dtLU_VOC_Category.Rows[0]);

			}
		}

		/// <summary>
		/// Initializes a new instance of the clsLU_VOC_Category class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_VOC_Category) 
		{
				if (drLU_VOC_Category["PK_LU_VOC_Category"] == DBNull.Value)
					this._PK_LU_VOC_Category = null;
				else
					this._PK_LU_VOC_Category = (decimal?)drLU_VOC_Category["PK_LU_VOC_Category"];

				if (drLU_VOC_Category["Category"] == DBNull.Value)
					this._Category = null;
				else
					this._Category = (string)drLU_VOC_Category["Category"];

				if (drLU_VOC_Category["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_VOC_Category["Active"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_VOC_Category table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_VOC_CategoryInsert");

			if (string.IsNullOrEmpty(this._Category))
				db.AddInParameter(dbCommand, "Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Category", DbType.String, this._Category);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_VOC_Category table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_VOC_Category)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_VOC_CategorySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_VOC_Category", DbType.Decimal, pK_LU_VOC_Category);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_VOC_Category table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_VOC_CategorySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_VOC_Category table.
		/// </summary>
        public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_VOC_CategoryUpdate");

			db.AddInParameter(dbCommand, "PK_LU_VOC_Category", DbType.Decimal, this._PK_LU_VOC_Category);
			
			if (string.IsNullOrEmpty(this._Category))
				db.AddInParameter(dbCommand, "Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Category", DbType.String, this._Category);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_VOC_Category table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_VOC_Category)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_VOC_CategoryDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_VOC_Category", DbType.Decimal, pK_LU_VOC_Category);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the LU_VOC_Category table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static int SelectByCategory(string category)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_VOC_SelectByCategory");

            db.AddInParameter(dbCommand, "Category", DbType.String, category);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_VOC_Category table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static int SelectPKByCategory(string category)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_VOC_SelectPKByCategory");

            db.AddInParameter(dbCommand, "Category", DbType.String, category);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
	}
}
