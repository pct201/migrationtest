using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_NAICS table.
	/// </summary>
	public sealed class LU_NAICS
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_NAICS;
		private string _Fld_Code;
		private string _Fld_Desc_1;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_NAICS value.
		/// </summary>
		public decimal? PK_LU_NAICS
		{
			get { return _PK_LU_NAICS; }
			set { _PK_LU_NAICS = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_NAICS class with default value.
		/// </summary>
		public LU_NAICS() 
		{

			this._PK_LU_NAICS = null;
			this._Fld_Code = null;
			this._Fld_Desc_1 = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_NAICS class based on Primary Key.
		/// </summary>
		public LU_NAICS(decimal pK_LU_NAICS) 
		{
			DataTable dtLU_NAICS = SelectByPK(pK_LU_NAICS).Tables[0];

			if (dtLU_NAICS.Rows.Count == 1)
			{
				DataRow drLU_NAICS = dtLU_NAICS.Rows[0];
				if (drLU_NAICS["PK_LU_NAICS"] == DBNull.Value)
					this._PK_LU_NAICS = null;
				else
					this._PK_LU_NAICS = (decimal?)drLU_NAICS["PK_LU_NAICS"];

				if (drLU_NAICS["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_NAICS["Fld_Code"];

				if (drLU_NAICS["Fld_Desc_1"] == DBNull.Value)
					this._Fld_Desc_1 = null;
				else
					this._Fld_Desc_1 = (string)drLU_NAICS["Fld_Desc_1"];

			}
			else
			{
				this._PK_LU_NAICS = null;
				this._Fld_Code = null;
				this._Fld_Desc_1 = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_NAICS table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NAICSInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc_1))
				db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, this._Fld_Desc_1);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_NAICS table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_LU_NAICS)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NAICSSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_NAICS", DbType.Decimal, pK_LU_NAICS);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_NAICS table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NAICSSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_NAICS table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NAICSUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_NAICS", DbType.Decimal, this._PK_LU_NAICS);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc_1))
				db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, this._Fld_Desc_1);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the LU_NAICS table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_NAICS)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NAICSDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_NAICS", DbType.Decimal, pK_LU_NAICS);

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
            DbCommand dbCommand = db.GetStoredProcCommand("LU_NAICSSelectByPaging");

            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all level descriptions by PK
        /// </summary>
        /// <param name="pK_LU_NAICS"></param>
        /// <returns></returns>
        public static DataSet SelectDescriptionsByPK(decimal pK_LU_NAICS)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_NAICS_SelectDescriptionsByPK");
            db.AddInParameter(dbCommand, "PK_LU_NAICS", DbType.Decimal, pK_LU_NAICS);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_NISC table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetLevelDesc(decimal decPKID, int intlength )
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_NAICS_GetLevelDesc");
            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, decPKID);
            db.AddInParameter(dbCommand, "fld_Length", DbType.Int32, intlength);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectByFld_Desc2(string strFld_Desc_2)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SIC_Distinct_fld_Desc_2");
            db.AddInParameter(dbCommand, "Fld_Desc_1", DbType.String, strFld_Desc_2);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectByFldCode(string strfld_Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_NAICS_SelectBy_FldCode");
            db.AddInParameter(dbCommand, "fld_Code", DbType.String, strfld_Code);
            return db.ExecuteDataSet(dbCommand);
        }


    }
}
