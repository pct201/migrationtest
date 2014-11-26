using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Building_Financial_Limits table.
	/// </summary>
	public sealed class Building_Financial_Limits
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Building_Financial_Limits;
		private decimal? _FK_Building_Id;
		private DateTime? _Property_Valuation_Date;
		private decimal? _Building_Limit;
		private decimal? _Associate_Tools_Limit;
		private decimal? _Contents_Limit;
		private decimal? _Parts_Limit;
		private decimal? _Business_Interruption;
		private decimal? _Total;
		private decimal? _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Building_Financial_Limits value.
		/// </summary>
		public decimal? PK_Building_Financial_Limits
		{
			get { return _PK_Building_Financial_Limits; }
			set { _PK_Building_Financial_Limits = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Building_Id value.
		/// </summary>
		public decimal? FK_Building_Id
		{
			get { return _FK_Building_Id; }
			set { _FK_Building_Id = value; }
		}

		/// <summary>
		/// Gets or sets the Property_Valuation_Date value.
		/// </summary>
		public DateTime? Property_Valuation_Date
		{
			get { return _Property_Valuation_Date; }
			set { _Property_Valuation_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Building_Limit value.
		/// </summary>
		public decimal? Building_Limit
		{
			get { return _Building_Limit; }
			set { _Building_Limit = value; }
		}

		/// <summary>
		/// Gets or sets the Associate_Tools_Limit value.
		/// </summary>
		public decimal? Associate_Tools_Limit
		{
			get { return _Associate_Tools_Limit; }
			set { _Associate_Tools_Limit = value; }
		}

		/// <summary>
		/// Gets or sets the Contents_Limit value.
		/// </summary>
		public decimal? Contents_Limit
		{
			get { return _Contents_Limit; }
			set { _Contents_Limit = value; }
		}

		/// <summary>
		/// Gets or sets the Parts_Limit value.
		/// </summary>
		public decimal? Parts_Limit
		{
			get { return _Parts_Limit; }
			set { _Parts_Limit = value; }
		}

		/// <summary>
		/// Gets or sets the Business_Interruption value.
		/// </summary>
		public decimal? Business_Interruption
		{
			get { return _Business_Interruption; }
			set { _Business_Interruption = value; }
		}

		/// <summary>
		/// Gets or sets the Total value.
		/// </summary>
		public decimal? Total
		{
			get { return _Total; }
			set { _Total = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public decimal? Updated_By
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
		/// Initializes a new instance of the Building_Financial_Limits class with default value.
		/// </summary>
		public Building_Financial_Limits() 
		{

			this._PK_Building_Financial_Limits = null;
			this._FK_Building_Id = null;
			this._Property_Valuation_Date = null;
			this._Building_Limit = null;
			this._Associate_Tools_Limit = null;
			this._Contents_Limit = null;
			this._Parts_Limit = null;
			this._Business_Interruption = null;
			this._Total = null;
			this._Updated_By = null;
			this._Update_Date = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Building_Financial_Limits class based on Primary Key.
		/// </summary>
		public Building_Financial_Limits(decimal pK_Building_Financial_Limits) 
		{
			DataTable dtBuilding_Financial_Limits = SelectByPK(pK_Building_Financial_Limits).Tables[0];

			if (dtBuilding_Financial_Limits.Rows.Count == 1)
			{
				DataRow drBuilding_Financial_Limits = dtBuilding_Financial_Limits.Rows[0];
				if (drBuilding_Financial_Limits["PK_Building_Financial_Limits"] == DBNull.Value)
					this._PK_Building_Financial_Limits = null;
				else
					this._PK_Building_Financial_Limits = (decimal?)drBuilding_Financial_Limits["PK_Building_Financial_Limits"];

				if (drBuilding_Financial_Limits["FK_Building_Id"] == DBNull.Value)
					this._FK_Building_Id = null;
				else
					this._FK_Building_Id = (decimal?)drBuilding_Financial_Limits["FK_Building_Id"];

				if (drBuilding_Financial_Limits["Property_Valuation_Date"] == DBNull.Value)
					this._Property_Valuation_Date = null;
				else
					this._Property_Valuation_Date = (DateTime?)drBuilding_Financial_Limits["Property_Valuation_Date"];

				if (drBuilding_Financial_Limits["Building_Limit"] == DBNull.Value)
					this._Building_Limit = null;
				else
					this._Building_Limit = (decimal?)drBuilding_Financial_Limits["Building_Limit"];

				if (drBuilding_Financial_Limits["Associate_Tools_Limit"] == DBNull.Value)
					this._Associate_Tools_Limit = null;
				else
					this._Associate_Tools_Limit = (decimal?)drBuilding_Financial_Limits["Associate_Tools_Limit"];

				if (drBuilding_Financial_Limits["Contents_Limit"] == DBNull.Value)
					this._Contents_Limit = null;
				else
					this._Contents_Limit = (decimal?)drBuilding_Financial_Limits["Contents_Limit"];

				if (drBuilding_Financial_Limits["Parts_Limit"] == DBNull.Value)
					this._Parts_Limit = null;
				else
					this._Parts_Limit = (decimal?)drBuilding_Financial_Limits["Parts_Limit"];

				if (drBuilding_Financial_Limits["Business_Interruption"] == DBNull.Value)
					this._Business_Interruption = null;
				else
					this._Business_Interruption = (decimal?)drBuilding_Financial_Limits["Business_Interruption"];

				if (drBuilding_Financial_Limits["Total"] == DBNull.Value)
					this._Total = null;
				else
					this._Total = (decimal?)drBuilding_Financial_Limits["Total"];

				if (drBuilding_Financial_Limits["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (decimal?)drBuilding_Financial_Limits["Updated_By"];

				if (drBuilding_Financial_Limits["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drBuilding_Financial_Limits["Update_Date"];

			}
			else
			{
				this._PK_Building_Financial_Limits = null;
				this._FK_Building_Id = null;
				this._Property_Valuation_Date = null;
				this._Building_Limit = null;
				this._Associate_Tools_Limit = null;
				this._Contents_Limit = null;
				this._Parts_Limit = null;
				this._Business_Interruption = null;
				this._Total = null;
				this._Updated_By = null;
				this._Update_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Building_Financial_Limits table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Financial_LimitsInsert");

			
			db.AddInParameter(dbCommand, "FK_Building_Id", DbType.Decimal, this._FK_Building_Id);
			
			db.AddInParameter(dbCommand, "Property_Valuation_Date", DbType.DateTime, this._Property_Valuation_Date);
			
			db.AddInParameter(dbCommand, "Building_Limit", DbType.Decimal, this._Building_Limit);
			
			db.AddInParameter(dbCommand, "Associate_Tools_Limit", DbType.Decimal, this._Associate_Tools_Limit);
			
			db.AddInParameter(dbCommand, "Contents_Limit", DbType.Decimal, this._Contents_Limit);
			
			db.AddInParameter(dbCommand, "Parts_Limit", DbType.Decimal, this._Parts_Limit);
			
			db.AddInParameter(dbCommand, "Business_Interruption", DbType.Decimal, this._Business_Interruption);
			
			db.AddInParameter(dbCommand, "Total", DbType.Decimal, this._Total);
			
			db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Building_Financial_Limits table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_Building_Financial_Limits)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Financial_LimitsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Building_Financial_Limits", DbType.Decimal, pK_Building_Financial_Limits);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Building_Financial_Limits table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Financial_LimitsSelectByFK");

            db.AddInParameter(dbCommand, "fK_Building_ID", DbType.Decimal, fK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }


		/// <summary>
		/// Selects all records from the Building_Financial_Limits table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Financial_LimitsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Building_Financial_Limits table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Financial_LimitsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Building_Financial_Limits", DbType.Decimal, this._PK_Building_Financial_Limits);
			
			db.AddInParameter(dbCommand, "FK_Building_Id", DbType.Decimal, this._FK_Building_Id);
			
			db.AddInParameter(dbCommand, "Property_Valuation_Date", DbType.DateTime, this._Property_Valuation_Date);
			
			db.AddInParameter(dbCommand, "Building_Limit", DbType.Decimal, this._Building_Limit);
			
			db.AddInParameter(dbCommand, "Associate_Tools_Limit", DbType.Decimal, this._Associate_Tools_Limit);
			
			db.AddInParameter(dbCommand, "Contents_Limit", DbType.Decimal, this._Contents_Limit);
			
			db.AddInParameter(dbCommand, "Parts_Limit", DbType.Decimal, this._Parts_Limit);
			
			db.AddInParameter(dbCommand, "Business_Interruption", DbType.Decimal, this._Business_Interruption);
			
			db.AddInParameter(dbCommand, "Total", DbType.Decimal, this._Total);
			
			db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Building_Financial_Limits table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Building_Financial_Limits)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Financial_LimitsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Building_Financial_Limits", DbType.Decimal, pK_Building_Financial_Limits);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectForExport(decimal decMultiplier)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingsSelectForExport");

            db.AddInParameter(dbCommand, "Multiplier", DbType.Decimal, decMultiplier);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataTable ImportData(string strFileName)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + @";Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""";
            OleDbConnection objConn = new OleDbConnection(strConn);
            try
            {
                objConn.Open();

                DataTable dtSheets = objConn.GetSchema("Tables");

                OleDbCommand objCommand = new OleDbCommand("Select * from [" + dtSheets.Rows[0]["Table_name"] + "]", objConn);

                OleDbDataAdapter da = new OleDbDataAdapter(objCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (objConn.State == ConnectionState.Open) objConn.Close();
                objConn.Dispose();

                return ds.Tables[0];
            }
            catch
            {
                if (objConn.State == ConnectionState.Open) objConn.Close();
                objConn.Dispose();
                return null;
            }
        }

        public static bool ExistsKeyValues(decimal? pK_Building_Financial_Limits, decimal? fK_Building_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Financial_LimitsCheckKeyValues");

            db.AddInParameter(dbCommand, "PK_Building_Financial_Limits", DbType.Decimal, pK_Building_Financial_Limits);
            db.AddInParameter(dbCommand, "FK_Building_Id", DbType.Decimal, fK_Building_Id);
            db.AddOutParameter(dbCommand, "bValid", DbType.Decimal, 1);

            db.ExecuteNonQuery(dbCommand);

            return Convert.ToBoolean(dbCommand.Parameters["@bValid"].Value);
        }
	}
}
