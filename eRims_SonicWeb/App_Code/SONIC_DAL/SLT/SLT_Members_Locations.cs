using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_Members_Locations table.
	/// </summary>
	public sealed class SLT_Members_Locations
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_Members_Locations;
		private decimal? _FK_SLT_Members;
		private decimal? _FK_Location_ID;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_Members_Locations value.
		/// </summary>
		public decimal? PK_SLT_Members_Locations
		{
			get { return _PK_SLT_Members_Locations; }
			set { _PK_SLT_Members_Locations = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_Members value.
		/// </summary>
		public decimal? FK_SLT_Members
		{
			get { return _FK_SLT_Members; }
			set { _FK_SLT_Members = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Location_ID value.
		/// </summary>
		public decimal? FK_Location_ID
		{
			get { return _FK_Location_ID; }
			set { _FK_Location_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
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
		/// Initializes a new instance of the clsSLT_Members_Locations class with default value.
		/// </summary>
		public SLT_Members_Locations() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Members_Locations class based on Primary Key.
		/// </summary>
		public SLT_Members_Locations(decimal pK_SLT_Members_Locations) 
		{
			DataTable dtSLT_Members_Locations = SelectByPK(pK_SLT_Members_Locations).Tables[0];

			if (dtSLT_Members_Locations.Rows.Count == 1)
			{
				 SetValue(dtSLT_Members_Locations.Rows[0]);

			}

		}

        /// <summary>
        /// Initializes a new instance of the clsSLT_Members_Locations class based on Foreign Key.
        /// </summary>
        public SLT_Members_Locations(decimal FK_SLT_Members,bool Status)
        {
            DataTable dtSLT_Members_Locations = SelectbyFk(FK_SLT_Members).Tables[0];

            if (dtSLT_Members_Locations.Rows.Count == 1)
            {
                SetValue(dtSLT_Members_Locations.Rows[0]);

            }

        }


		/// <summary>
		/// Initializes a new instance of the clsSLT_Members_Locations class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_Members_Locations) 
		{
				if (drSLT_Members_Locations["PK_SLT_Members_Locations"] == DBNull.Value)
					this._PK_SLT_Members_Locations = null;
				else
					this._PK_SLT_Members_Locations = (decimal?)drSLT_Members_Locations["PK_SLT_Members_Locations"];

				if (drSLT_Members_Locations["FK_SLT_Members"] == DBNull.Value)
					this._FK_SLT_Members = null;
				else
					this._FK_SLT_Members = (decimal?)drSLT_Members_Locations["FK_SLT_Members"];

				if (drSLT_Members_Locations["FK_Location_ID"] == DBNull.Value)
					this._FK_Location_ID = null;
				else
					this._FK_Location_ID = (decimal?)drSLT_Members_Locations["FK_Location_ID"];

                if (drSLT_Members_Locations["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
                    this._Updated_By = (string)drSLT_Members_Locations["Updated_By"];

				if (drSLT_Members_Locations["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSLT_Members_Locations["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_Members_Locations table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Members_LocationsInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);
			
			db.AddInParameter(dbCommand, "FK_Location_ID", DbType.Decimal, this._FK_Location_ID);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_Members_Locations table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_Members_Locations)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Members_LocationsSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Members_Locations", DbType.Decimal, pK_SLT_Members_Locations);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_Members_Locations table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Members_LocationsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_Members_Locations table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Members_LocationsUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_Members_Locations", DbType.Decimal, this._PK_SLT_Members_Locations);
			
			db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);
			
			db.AddInParameter(dbCommand, "FK_Location_ID", DbType.Decimal, this._FK_Location_ID);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_Members_Locations table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_Members_Locations)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Members_LocationsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Members_Locations", DbType.Decimal, pK_SLT_Members_Locations);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the SLT_Members_Locations table by a FK_SLT_Members.
        /// </summary>
        public static void DeleteByFK(decimal FK_SLT_Members)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Members_LocationsDeleteByFK");

            db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, FK_SLT_Members);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Selects all records from the SLT_Members_Locations table by FK_SLT_Members
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectbyFk(decimal FK_SLT_Members)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Members_LocationsSelectbyFk");
            db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, FK_SLT_Members);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
