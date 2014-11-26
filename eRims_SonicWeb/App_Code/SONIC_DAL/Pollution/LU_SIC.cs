using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_SIC table.
	/// </summary>
	public sealed class LU_SIC
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_SIC;
		private string _Fld_Code;
		private string _Fld_Desc_1;
		private string _Fld_Desc_2;
		private string _Fld_Desc_3;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_SIC value.
		/// </summary>
		public decimal? PK_LU_SIC
		{
			get { return _PK_LU_SIC; }
			set { _PK_LU_SIC = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Code value.
		/// </summary>
		public string Fld_Code
		{
			get { return _Fld_Code; }
			set { _Fld_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc_1 value.
		/// </summary>
		public string Fld_Desc_1
		{
			get { return _Fld_Desc_1; }
			set { _Fld_Desc_1 = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc_2 value.
		/// </summary>
		public string Fld_Desc_2
		{
			get { return _Fld_Desc_2; }
			set { _Fld_Desc_2 = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc_3 value.
		/// </summary>
		public string Fld_Desc_3
		{
			get { return _Fld_Desc_3; }
			set { _Fld_Desc_3 = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_SIC class with default value.
		/// </summary>
		public LU_SIC() 
		{

			this._PK_LU_SIC = null;
			this._Fld_Code = null;
			this._Fld_Desc_1 = null;
			this._Fld_Desc_2 = null;
			this._Fld_Desc_3 = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_SIC class based on Primary Key.
		/// </summary>
		public LU_SIC(decimal pK_LU_SIC) 
		{
			DataTable dtLU_SIC = SelectByPK(pK_LU_SIC).Tables[0];

			if (dtLU_SIC.Rows.Count == 1)
			{
				DataRow drLU_SIC = dtLU_SIC.Rows[0];
				if (drLU_SIC["PK_LU_SIC"] == DBNull.Value)
					this._PK_LU_SIC = null;
				else
					this._PK_LU_SIC = (decimal?)drLU_SIC["PK_LU_SIC"];

				if (drLU_SIC["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_SIC["Fld_Code"];

				if (drLU_SIC["Fld_Desc_1"] == DBNull.Value)
					this._Fld_Desc_1 = null;
				else
					this._Fld_Desc_1 = (string)drLU_SIC["Fld_Desc_1"];

				if (drLU_SIC["Fld_Desc_2"] == DBNull.Value)
					this._Fld_Desc_2 = null;
				else
					this._Fld_Desc_2 = (string)drLU_SIC["Fld_Desc_2"];

				if (drLU_SIC["Fld_Desc_3"] == DBNull.Value)
					this._Fld_Desc_3 = null;
				else
					this._Fld_Desc_3 = (string)drLU_SIC["Fld_Desc_3"];

			}
			else
			{
				this._PK_LU_SIC = null;
				this._Fld_Code = null;
				this._Fld_Desc_1 = null;
				this._Fld_Desc_2 = null;
				this._Fld_Desc_3 = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_SIC table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SICInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc_1))
				db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, this._Fld_Desc_1);
			
			if (string.IsNullOrEmpty(this._Fld_Desc_2))
				db.AddInParameter(dbCommand, "Fld_Desc_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc_2", DbType.String, this._Fld_Desc_2);
			
			if (string.IsNullOrEmpty(this._Fld_Desc_3))
				db.AddInParameter(dbCommand, "Fld_Desc_3", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc_3", DbType.String, this._Fld_Desc_3);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_SIC table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_LU_SIC)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SICSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_SIC", DbType.Decimal, pK_LU_SIC);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_SIC table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SICSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_SIC table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SICUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_SIC", DbType.Decimal, this._PK_LU_SIC);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc_1))
				db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, this._Fld_Desc_1);
			
			if (string.IsNullOrEmpty(this._Fld_Desc_2))
				db.AddInParameter(dbCommand, "Fld_Desc_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc_2", DbType.String, this._Fld_Desc_2);
			
			if (string.IsNullOrEmpty(this._Fld_Desc_3))
				db.AddInParameter(dbCommand, "Fld_Desc_3", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc_3", DbType.String, this._Fld_Desc_3);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the LU_SIC table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_SIC)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SICDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_SIC", DbType.Decimal, pK_LU_SIC);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects records by paging
        /// </summary>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public static DataSet SelectByPaging(int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SICSelectByPaging");

            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects all records from the LU_SIC table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllDistinct()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SIC_Distinct_fld_Desc_1");

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectByFld_Desc2(string strFld_Desc_2)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SIC_Distinct_fld_Desc_2");
            db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, strFld_Desc_2);  
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectByFld_Desc3(string strFld_Desc_3)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SIC_Distinct_fld_Desc_3");
            db.AddInParameter(dbCommand, "Fld_Desc_2", DbType.String, strFld_Desc_3);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectByFldCode(string strFld_Desc_1, string strFld_Desc_2, string strFld_Desc_3)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SIC_SelectALL_By_Fld_Desc");
            db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, strFld_Desc_1);
            db.AddInParameter(dbCommand, "Fld_Desc_2", DbType.String, strFld_Desc_2);
            db.AddInParameter(dbCommand, "Fld_Desc_3", DbType.String, strFld_Desc_3);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
