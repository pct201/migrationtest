using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table U_A_Request_Locations
	/// </summary>
	public sealed class U_A_Request_Locations
	{

		#region Private variables used to hold the property values

		private decimal? _PK_U_A_Request_Locations;
		private decimal? _FK_U_A_Request;
		private decimal? _FK_LU_Location;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_U_A_Request_Locations value.
		/// </summary>
		public decimal? PK_U_A_Request_Locations
		{
			get { return _PK_U_A_Request_Locations; }
			set { _PK_U_A_Request_Locations = value; }
		}

		/// <summary>
		/// Gets or sets the FK_U_A_Request value.
		/// </summary>
		public decimal? FK_U_A_Request
		{
			get { return _FK_U_A_Request; }
			set { _FK_U_A_Request = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Location value.
		/// </summary>
		public decimal? FK_LU_Location
		{
			get { return _FK_LU_Location; }
			set { _FK_LU_Location = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the U_A_Request_Locations class with default value.
		/// </summary>
		public U_A_Request_Locations() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the U_A_Request_Locations class based on Primary Key.
		/// </summary>
		public U_A_Request_Locations(decimal pK_U_A_Request_Locations) 
		{
			DataTable dtU_A_Request_Locations = Select(pK_U_A_Request_Locations).Tables[0];

			if (dtU_A_Request_Locations.Rows.Count == 1)
			{
				 SetValue(dtU_A_Request_Locations.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the U_A_Request_Locations class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drU_A_Request_Locations) 
		{
				if (drU_A_Request_Locations["PK_U_A_Request_Locations"] == DBNull.Value)
					this._PK_U_A_Request_Locations = null;
				else
					this._PK_U_A_Request_Locations = (decimal?)drU_A_Request_Locations["PK_U_A_Request_Locations"];

				if (drU_A_Request_Locations["FK_U_A_Request"] == DBNull.Value)
					this._FK_U_A_Request = null;
				else
					this._FK_U_A_Request = (decimal?)drU_A_Request_Locations["FK_U_A_Request"];

				if (drU_A_Request_Locations["FK_LU_Location"] == DBNull.Value)
					this._FK_LU_Location = null;
				else
					this._FK_LU_Location = (decimal?)drU_A_Request_Locations["FK_LU_Location"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the U_A_Request_Locations table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_LocationsInsert");

			
			db.AddInParameter(dbCommand, "FK_U_A_Request", DbType.Decimal, this._FK_U_A_Request);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the U_A_Request_Locations table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_U_A_Request_Locations)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_LocationsSelect");

			db.AddInParameter(dbCommand, "PK_U_A_Request_Locations", DbType.Decimal, pK_U_A_Request_Locations);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the U_A_Request_Locations table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_LocationsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the U_A_Request_Locations table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_LocationsUpdate");

			
			db.AddInParameter(dbCommand, "PK_U_A_Request_Locations", DbType.Decimal, this._PK_U_A_Request_Locations);
			
			db.AddInParameter(dbCommand, "FK_U_A_Request", DbType.Decimal, this._FK_U_A_Request);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the U_A_Request_Locations table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_U_A_Request_Locations)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_LocationsDelete");

			db.AddInParameter(dbCommand, "PK_U_A_Request_Locations", DbType.Decimal, pK_U_A_Request_Locations);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the FROI_EMail_Recipients table by User (FK_Security_ID)
        /// </summary>
        public static void DeleteByUser(decimal fK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_LocationsDeleteByUser");

            db.AddInParameter(dbCommand, "FK_U_A_Request", DbType.Decimal, fK_Security_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the U_A_Request_Locations table by User (FK_U_A_Request)
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUser(decimal FK_U_A_Request)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_LocationsSelectByUser");

            db.AddInParameter(dbCommand, "FK_U_A_Request", DbType.Decimal, FK_U_A_Request);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
