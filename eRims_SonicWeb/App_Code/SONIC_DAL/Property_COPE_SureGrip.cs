using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Property_COPE_SureGrip table.
	/// </summary>
	public sealed class Property_COPE_SureGrip
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Property_COPE_SureGrip;
		private decimal? _FK_Property_COPE;
		private int? _Year;
		private int? _SureGripPercent;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Property_COPE_SureGrip value.
		/// </summary>
		public decimal? PK_Property_COPE_SureGrip
		{
			get { return _PK_Property_COPE_SureGrip; }
			set { _PK_Property_COPE_SureGrip = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Property_COPE value.
		/// </summary>
		public decimal? FK_Property_COPE
		{
			get { return _FK_Property_COPE; }
			set { _FK_Property_COPE = value; }
		}

		/// <summary>
		/// Gets or sets the Year value.
		/// </summary>
		public int? Year
		{
			get { return _Year; }
			set { _Year = value; }
		}

		/// <summary>
		/// Gets or sets the SureGripPercent value.
		/// </summary>
		public int? SureGripPercent
		{
			get { return _SureGripPercent; }
			set { _SureGripPercent = value; }
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
		/// Initializes a new instance of the Property_COPE_SureGrip class with default value.
		/// </summary>
		public Property_COPE_SureGrip() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Property_COPE_SureGrip class based on Primary Key.
		/// </summary>
		public Property_COPE_SureGrip(decimal pK_Property_COPE_SureGrip) 
		{
			DataTable dtProperty_COPE_SureGrip = SelectByPK(pK_Property_COPE_SureGrip).Tables[0];

			if (dtProperty_COPE_SureGrip.Rows.Count == 1)
			{
				 SetValue(dtProperty_COPE_SureGrip.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Property_COPE_SureGrip class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drProperty_COPE_SureGrip) 
		{
				if (drProperty_COPE_SureGrip["PK_Property_COPE_SureGrip"] == DBNull.Value)
					this._PK_Property_COPE_SureGrip = null;
				else
					this._PK_Property_COPE_SureGrip = (decimal?)drProperty_COPE_SureGrip["PK_Property_COPE_SureGrip"];

				if (drProperty_COPE_SureGrip["FK_Property_COPE"] == DBNull.Value)
					this._FK_Property_COPE = null;
				else
					this._FK_Property_COPE = (decimal?)drProperty_COPE_SureGrip["FK_Property_COPE"];

				if (drProperty_COPE_SureGrip["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drProperty_COPE_SureGrip["Year"];

				if (drProperty_COPE_SureGrip["SureGripPercent"] == DBNull.Value)
					this._SureGripPercent = null;
				else
					this._SureGripPercent = (int?)drProperty_COPE_SureGrip["SureGripPercent"];

				if (drProperty_COPE_SureGrip["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drProperty_COPE_SureGrip["Update_Date"];

				if (drProperty_COPE_SureGrip["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drProperty_COPE_SureGrip["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Property_COPE_SureGrip table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_SureGripInsert");

			
			db.AddInParameter(dbCommand, "FK_Property_COPE", DbType.Decimal, this._FK_Property_COPE);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "SureGripPercent", DbType.Int32, this._SureGripPercent);
			
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
		/// Selects a single record from the Property_COPE_SureGrip table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Property_COPE_SureGrip)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_SureGripSelectByPK");

			db.AddInParameter(dbCommand, "PK_Property_COPE_SureGrip", DbType.Decimal, pK_Property_COPE_SureGrip);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Property_COPE_SureGrip table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_SureGripSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Property_COPE_SureGrip table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_SureGripUpdate");

			
			db.AddInParameter(dbCommand, "PK_Property_COPE_SureGrip", DbType.Decimal, this._PK_Property_COPE_SureGrip);
			
			db.AddInParameter(dbCommand, "FK_Property_COPE", DbType.Decimal, this._FK_Property_COPE);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "SureGripPercent", DbType.Int32, this._SureGripPercent);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Property_COPE_SureGrip table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Property_COPE_SureGrip)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_SureGripDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Property_COPE_SureGrip", DbType.Decimal, pK_Property_COPE_SureGrip);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the Property_COPE_Saba_Training table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByProperty_Cope(decimal FK_Property_COPE)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_SureGrip_SelectByProperty_Cope");
            db.AddInParameter(dbCommand, "FK_Property_COPE", DbType.Decimal, FK_Property_COPE);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Property_COPE_Saba_Training table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByYear(decimal FK_Property_COPE,int Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_SureGrip_SelectByYear");
            db.AddInParameter(dbCommand, "FK_Property_COPE", DbType.Decimal, FK_Property_COPE);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
