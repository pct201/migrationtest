using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Insureds_Buildings table.
	/// </summary>
	public sealed class clsCOI_Insureds_Buildings
	{

		#region Private variables used to hold the property values

		private decimal? _PK_COI_Insureds_Buildings;
		private decimal? _FK_COI_Insureds;
		private string _Building_Number;
		private string _Address_1;
		private string _Address_2;
		private string _City;
		private decimal? _FK_State;
		private string _Zip;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_COI_Insureds_Buildings value.
		/// </summary>
		public decimal? PK_COI_Insureds_Buildings
		{
			get { return _PK_COI_Insureds_Buildings; }
			set { _PK_COI_Insureds_Buildings = value; }
		}

		/// <summary>
		/// Gets or sets the FK_COI_Insureds value.
		/// </summary>
		public decimal? FK_COI_Insureds
		{
			get { return _FK_COI_Insureds; }
			set { _FK_COI_Insureds = value; }
		}

		/// <summary>
		/// Gets or sets the Building_Number value.
		/// </summary>
		public string Building_Number
		{
			get { return _Building_Number; }
			set { _Building_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Address_1 value.
		/// </summary>
		public string Address_1
		{
			get { return _Address_1; }
			set { _Address_1 = value; }
		}

		/// <summary>
		/// Gets or sets the Address_2 value.
		/// </summary>
		public string Address_2
		{
			get { return _Address_2; }
			set { _Address_2 = value; }
		}

		/// <summary>
		/// Gets or sets the City value.
		/// </summary>
		public string City
		{
			get { return _City; }
			set { _City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_State value.
		/// </summary>
		public decimal? FK_State
		{
			get { return _FK_State; }
			set { _FK_State = value; }
		}

		/// <summary>
		/// Gets or sets the Zip value.
		/// </summary>
		public string Zip
		{
			get { return _Zip; }
			set { _Zip = value; }
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
		/// Initializes a new instance of the clsCOI_Insureds_Buildings class with default value.
		/// </summary>
		public clsCOI_Insureds_Buildings() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsCOI_Insureds_Buildings class based on Primary Key.
		/// </summary>
		public clsCOI_Insureds_Buildings(decimal pK_COI_Insureds_Buildings) 
		{
			DataTable dtCOI_Insureds_Buildings = SelectByPK(pK_COI_Insureds_Buildings).Tables[0];

			if (dtCOI_Insureds_Buildings.Rows.Count == 1)
			{
				 SetValue(dtCOI_Insureds_Buildings.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsCOI_Insureds_Buildings class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drCOI_Insureds_Buildings) 
		{
				if (drCOI_Insureds_Buildings["PK_COI_Insureds_Buildings"] == DBNull.Value)
					this._PK_COI_Insureds_Buildings = null;
				else
					this._PK_COI_Insureds_Buildings = (decimal?)drCOI_Insureds_Buildings["PK_COI_Insureds_Buildings"];

				if (drCOI_Insureds_Buildings["FK_COI_Insureds"] == DBNull.Value)
					this._FK_COI_Insureds = null;
				else
					this._FK_COI_Insureds = (decimal?)drCOI_Insureds_Buildings["FK_COI_Insureds"];

				if (drCOI_Insureds_Buildings["Building_Number"] == DBNull.Value)
					this._Building_Number = null;
				else
					this._Building_Number = (string)drCOI_Insureds_Buildings["Building_Number"];

				if (drCOI_Insureds_Buildings["Address_1"] == DBNull.Value)
					this._Address_1 = null;
				else
					this._Address_1 = (string)drCOI_Insureds_Buildings["Address_1"];

				if (drCOI_Insureds_Buildings["Address_2"] == DBNull.Value)
					this._Address_2 = null;
				else
					this._Address_2 = (string)drCOI_Insureds_Buildings["Address_2"];

				if (drCOI_Insureds_Buildings["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drCOI_Insureds_Buildings["City"];

				if (drCOI_Insureds_Buildings["FK_State"] == DBNull.Value)
					this._FK_State = null;
				else
					this._FK_State = (decimal?)drCOI_Insureds_Buildings["FK_State"];

				if (drCOI_Insureds_Buildings["Zip"] == DBNull.Value)
					this._Zip = null;
				else
					this._Zip = (string)drCOI_Insureds_Buildings["Zip"];

				if (drCOI_Insureds_Buildings["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drCOI_Insureds_Buildings["Update_Date"];

				if (drCOI_Insureds_Buildings["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drCOI_Insureds_Buildings["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the COI_Insureds_Buildings table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Insureds_BuildingsInsert");

			
			db.AddInParameter(dbCommand, "FK_COI_Insureds", DbType.Decimal, this._FK_COI_Insureds);
			
			if (string.IsNullOrEmpty(this._Building_Number))
				db.AddInParameter(dbCommand, "Building_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Building_Number", DbType.String, this._Building_Number);
			
			if (string.IsNullOrEmpty(this._Address_1))
				db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			
			if (string.IsNullOrEmpty(this._Address_2))
				db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			
			if (string.IsNullOrEmpty(this._Zip))
				db.AddInParameter(dbCommand, "Zip", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
			
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
		/// Selects a single record from the COI_Insureds_Buildings table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_COI_Insureds_Buildings)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Insureds_BuildingsSelectByPK");

			db.AddInParameter(dbCommand, "PK_COI_Insureds_Buildings", DbType.Decimal, pK_COI_Insureds_Buildings);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Insureds_Buildings table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Insureds_BuildingsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the COI_Insureds_Buildings table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Insureds_BuildingsUpdate");

			
			db.AddInParameter(dbCommand, "PK_COI_Insureds_Buildings", DbType.Decimal, this._PK_COI_Insureds_Buildings);
			
			db.AddInParameter(dbCommand, "FK_COI_Insureds", DbType.Decimal, this._FK_COI_Insureds);
			
			if (string.IsNullOrEmpty(this._Building_Number))
				db.AddInParameter(dbCommand, "Building_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Building_Number", DbType.String, this._Building_Number);
			
			if (string.IsNullOrEmpty(this._Address_1))
				db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			
			if (string.IsNullOrEmpty(this._Address_2))
				db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			
			if (string.IsNullOrEmpty(this._Zip))
				db.AddInParameter(dbCommand, "Zip", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the COI_Insureds_Buildings table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_COI_Insureds_Buildings)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Insureds_BuildingsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_COI_Insureds_Buildings", DbType.Decimal, pK_COI_Insureds_Buildings);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the COI_Insureds_Buildings table by a composite primary key.
        /// </summary>
        public static void DeleteByFK(decimal FK_COI_Insureds)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Insureds_BuildingsDeleteByFK");

            db.AddInParameter(dbCommand, "FK_COI_Insureds", DbType.Decimal, FK_COI_Insureds);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Selects records from the COI_Insureds_Buildings table by a foreign key.
        /// <summary>
        /// <param name="fK_COIs"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_COI_Insureds(decimal fK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Insureds_BuildingsSelectByFK_COI_Insureds");
            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Buildings table by a Location_ID key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet Select_Building_By_Location_ID(decimal PK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_SelectByPK_LU_Location_ID");
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, PK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Buildings table by a Location_ID key AND LandLord.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet Select_Building_SelectByPK_LU_Location_IDANDLandLord(decimal PK_LU_Location_ID, string Landlord_Name, string Sublease_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_SelectByPK_LU_Location_IDANDLandLord");
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, PK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Landlord_Name", DbType.String, Landlord_Name);
            db.AddInParameter(dbCommand, "Sublease_Name", DbType.String, Sublease_Name);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
