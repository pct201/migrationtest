using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL
{
	/// <summary>
	/// Data access class for Building_Ownership_Sublease table.
	/// </summary>
	public sealed class clsBuilding_Ownership_Sublease
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Building_Ownership_Sublease;
		private decimal? _FK_Building_Ownership;
		private string _Sublease_Name;
		private string _Sublease_Address_1;
		private string _Sublease_Address_2;
		private string _Sublease_City;
		private string _Sublease_State;
		private string _Sublease_Zip;
		private string _SubLease_Landlord;
		private string _Sublease_FirstName;
		private string _Sublease_LastName;
		private string _Sublease_Title;
		private string _Sublease_Phone;
		private string _Sublease_Fax;
		private string _Sublease_Email;
        private decimal? _Updated_By;
        private DateTime? _Updated_Date;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Building_Ownership_Sublease value.
		/// </summary>
		public decimal? PK_Building_Ownership_Sublease
		{
			get { return _PK_Building_Ownership_Sublease; }
			set { _PK_Building_Ownership_Sublease = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Building_Ownership value.
		/// </summary>
		public decimal? FK_Building_Ownership
		{
			get { return _FK_Building_Ownership; }
			set { _FK_Building_Ownership = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_Name value.
		/// </summary>
		public string Sublease_Name
		{
			get { return _Sublease_Name; }
			set { _Sublease_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_Address_1 value.
		/// </summary>
		public string Sublease_Address_1
		{
			get { return _Sublease_Address_1; }
			set { _Sublease_Address_1 = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_Address_2 value.
		/// </summary>
		public string Sublease_Address_2
		{
			get { return _Sublease_Address_2; }
			set { _Sublease_Address_2 = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_City value.
		/// </summary>
		public string Sublease_City
		{
			get { return _Sublease_City; }
			set { _Sublease_City = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_State value.
		/// </summary>
		public string Sublease_State
		{
			get { return _Sublease_State; }
			set { _Sublease_State = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_Zip value.
		/// </summary>
		public string Sublease_Zip
		{
			get { return _Sublease_Zip; }
			set { _Sublease_Zip = value; }
		}

		/// <summary>
		/// Gets or sets the SubLease_Landlord value.
		/// </summary>
		public string SubLease_Landlord
		{
			get { return _SubLease_Landlord; }
			set { _SubLease_Landlord = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_FirstName value.
		/// </summary>
		public string Sublease_FirstName
		{
			get { return _Sublease_FirstName; }
			set { _Sublease_FirstName = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_LastName value.
		/// </summary>
		public string Sublease_LastName
		{
			get { return _Sublease_LastName; }
			set { _Sublease_LastName = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_Title value.
		/// </summary>
		public string Sublease_Title
		{
			get { return _Sublease_Title; }
			set { _Sublease_Title = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_Phone value.
		/// </summary>
		public string Sublease_Phone
		{
			get { return _Sublease_Phone; }
			set { _Sublease_Phone = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_Fax value.
		/// </summary>
		public string Sublease_Fax
		{
			get { return _Sublease_Fax; }
			set { _Sublease_Fax = value; }
		}

		/// <summary>
		/// Gets or sets the Sublease_Email value.
		/// </summary>
		public string Sublease_Email
		{
			get { return _Sublease_Email; }
			set { _Sublease_Email = value; }
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
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime? Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsBuilding_Ownership_Sublease class with default value.
		/// </summary>
		public clsBuilding_Ownership_Sublease() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsBuilding_Ownership_Sublease class based on Primary Key.
		/// </summary>
		public clsBuilding_Ownership_Sublease(decimal pK_Building_Ownership_Sublease) 
		{
			DataTable dtBuilding_Ownership_Sublease = SelectByPK(pK_Building_Ownership_Sublease).Tables[0];

			if (dtBuilding_Ownership_Sublease.Rows.Count == 1)
			{
				 SetValue(dtBuilding_Ownership_Sublease.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsBuilding_Ownership_Sublease class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drBuilding_Ownership_Sublease) 
		{
				if (drBuilding_Ownership_Sublease["PK_Building_Ownership_Sublease"] == DBNull.Value)
					this._PK_Building_Ownership_Sublease = null;
				else
					this._PK_Building_Ownership_Sublease = (decimal?)drBuilding_Ownership_Sublease["PK_Building_Ownership_Sublease"];

				if (drBuilding_Ownership_Sublease["FK_Building_Ownership"] == DBNull.Value)
					this._FK_Building_Ownership = null;
				else
					this._FK_Building_Ownership = (decimal?)drBuilding_Ownership_Sublease["FK_Building_Ownership"];

				if (drBuilding_Ownership_Sublease["Sublease_Name"] == DBNull.Value)
					this._Sublease_Name = null;
				else
					this._Sublease_Name = (string)drBuilding_Ownership_Sublease["Sublease_Name"];

				if (drBuilding_Ownership_Sublease["Sublease_Address_1"] == DBNull.Value)
					this._Sublease_Address_1 = null;
				else
					this._Sublease_Address_1 = (string)drBuilding_Ownership_Sublease["Sublease_Address_1"];

				if (drBuilding_Ownership_Sublease["Sublease_Address_2"] == DBNull.Value)
					this._Sublease_Address_2 = null;
				else
					this._Sublease_Address_2 = (string)drBuilding_Ownership_Sublease["Sublease_Address_2"];

				if (drBuilding_Ownership_Sublease["Sublease_City"] == DBNull.Value)
					this._Sublease_City = null;
				else
					this._Sublease_City = (string)drBuilding_Ownership_Sublease["Sublease_City"];

				if (drBuilding_Ownership_Sublease["Sublease_State"] == DBNull.Value)
					this._Sublease_State = null;
				else
					this._Sublease_State = (string)drBuilding_Ownership_Sublease["Sublease_State"];

				if (drBuilding_Ownership_Sublease["Sublease_Zip"] == DBNull.Value)
					this._Sublease_Zip = null;
				else
					this._Sublease_Zip = (string)drBuilding_Ownership_Sublease["Sublease_Zip"];

				if (drBuilding_Ownership_Sublease["SubLease_Landlord"] == DBNull.Value)
					this._SubLease_Landlord = null;
				else
					this._SubLease_Landlord = (string)drBuilding_Ownership_Sublease["SubLease_Landlord"];

				if (drBuilding_Ownership_Sublease["Sublease_FirstName"] == DBNull.Value)
					this._Sublease_FirstName = null;
				else
					this._Sublease_FirstName = (string)drBuilding_Ownership_Sublease["Sublease_FirstName"];

				if (drBuilding_Ownership_Sublease["Sublease_LastName"] == DBNull.Value)
					this._Sublease_LastName = null;
				else
					this._Sublease_LastName = (string)drBuilding_Ownership_Sublease["Sublease_LastName"];

				if (drBuilding_Ownership_Sublease["Sublease_Title"] == DBNull.Value)
					this._Sublease_Title = null;
				else
					this._Sublease_Title = (string)drBuilding_Ownership_Sublease["Sublease_Title"];

				if (drBuilding_Ownership_Sublease["Sublease_Phone"] == DBNull.Value)
					this._Sublease_Phone = null;
				else
					this._Sublease_Phone = (string)drBuilding_Ownership_Sublease["Sublease_Phone"];

				if (drBuilding_Ownership_Sublease["Sublease_Fax"] == DBNull.Value)
					this._Sublease_Fax = null;
				else
					this._Sublease_Fax = (string)drBuilding_Ownership_Sublease["Sublease_Fax"];

				if (drBuilding_Ownership_Sublease["Sublease_Email"] == DBNull.Value)
					this._Sublease_Email = null;
				else
					this._Sublease_Email = (string)drBuilding_Ownership_Sublease["Sublease_Email"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Building_Ownership_Sublease table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Ownership_SubleaseInsert");

			
			db.AddInParameter(dbCommand, "FK_Building_Ownership", DbType.Decimal, this._FK_Building_Ownership);
			
			if (string.IsNullOrEmpty(this._Sublease_Name))
				db.AddInParameter(dbCommand, "Sublease_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Name", DbType.String, this._Sublease_Name);
			
			if (string.IsNullOrEmpty(this._Sublease_Address_1))
				db.AddInParameter(dbCommand, "Sublease_Address_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Address_1", DbType.String, this._Sublease_Address_1);
			
			if (string.IsNullOrEmpty(this._Sublease_Address_2))
				db.AddInParameter(dbCommand, "Sublease_Address_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Address_2", DbType.String, this._Sublease_Address_2);
			
			if (string.IsNullOrEmpty(this._Sublease_City))
				db.AddInParameter(dbCommand, "Sublease_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_City", DbType.String, this._Sublease_City);
			
			if (string.IsNullOrEmpty(this._Sublease_State))
				db.AddInParameter(dbCommand, "Sublease_State", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_State", DbType.String, this._Sublease_State);
			
			if (string.IsNullOrEmpty(this._Sublease_Zip))
				db.AddInParameter(dbCommand, "Sublease_Zip", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Zip", DbType.String, this._Sublease_Zip);
			
			if (string.IsNullOrEmpty(this._SubLease_Landlord))
				db.AddInParameter(dbCommand, "SubLease_Landlord", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SubLease_Landlord", DbType.String, this._SubLease_Landlord);
			
			if (string.IsNullOrEmpty(this._Sublease_FirstName))
				db.AddInParameter(dbCommand, "Sublease_FirstName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_FirstName", DbType.String, this._Sublease_FirstName);
			
			if (string.IsNullOrEmpty(this._Sublease_LastName))
				db.AddInParameter(dbCommand, "Sublease_LastName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_LastName", DbType.String, this._Sublease_LastName);
			
			if (string.IsNullOrEmpty(this._Sublease_Title))
				db.AddInParameter(dbCommand, "Sublease_Title", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Title", DbType.String, this._Sublease_Title);
			
			if (string.IsNullOrEmpty(this._Sublease_Phone))
				db.AddInParameter(dbCommand, "Sublease_Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Phone", DbType.String, this._Sublease_Phone);
			
			if (string.IsNullOrEmpty(this._Sublease_Fax))
				db.AddInParameter(dbCommand, "Sublease_Fax", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Fax", DbType.String, this._Sublease_Fax);
			
			if (string.IsNullOrEmpty(this._Sublease_Email))
				db.AddInParameter(dbCommand, "Sublease_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Email", DbType.String, this._Sublease_Email);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);

            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Building_Ownership_Sublease table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Building_Ownership_Sublease)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Ownership_SubleaseSelectByPK");

			db.AddInParameter(dbCommand, "PK_Building_Ownership_Sublease", DbType.Decimal, pK_Building_Ownership_Sublease);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Building_Ownership_Sublease table.
		/// </summary>
		/// <returns>DataSet</returns>
        public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Ownership_SubleaseSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Building_Ownership_Sublease table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Ownership_SubleaseUpdate");

			
			db.AddInParameter(dbCommand, "PK_Building_Ownership_Sublease", DbType.Decimal, this._PK_Building_Ownership_Sublease);
			
			db.AddInParameter(dbCommand, "FK_Building_Ownership", DbType.Decimal, this._FK_Building_Ownership);
			
			if (string.IsNullOrEmpty(this._Sublease_Name))
				db.AddInParameter(dbCommand, "Sublease_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Name", DbType.String, this._Sublease_Name);
			
			if (string.IsNullOrEmpty(this._Sublease_Address_1))
				db.AddInParameter(dbCommand, "Sublease_Address_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Address_1", DbType.String, this._Sublease_Address_1);
			
			if (string.IsNullOrEmpty(this._Sublease_Address_2))
				db.AddInParameter(dbCommand, "Sublease_Address_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Address_2", DbType.String, this._Sublease_Address_2);
			
			if (string.IsNullOrEmpty(this._Sublease_City))
				db.AddInParameter(dbCommand, "Sublease_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_City", DbType.String, this._Sublease_City);
			
			if (string.IsNullOrEmpty(this._Sublease_State))
				db.AddInParameter(dbCommand, "Sublease_State", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_State", DbType.String, this._Sublease_State);
			
			if (string.IsNullOrEmpty(this._Sublease_Zip))
				db.AddInParameter(dbCommand, "Sublease_Zip", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Zip", DbType.String, this._Sublease_Zip);
			
			if (string.IsNullOrEmpty(this._SubLease_Landlord))
				db.AddInParameter(dbCommand, "SubLease_Landlord", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SubLease_Landlord", DbType.String, this._SubLease_Landlord);
			
			if (string.IsNullOrEmpty(this._Sublease_FirstName))
				db.AddInParameter(dbCommand, "Sublease_FirstName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_FirstName", DbType.String, this._Sublease_FirstName);
			
			if (string.IsNullOrEmpty(this._Sublease_LastName))
				db.AddInParameter(dbCommand, "Sublease_LastName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_LastName", DbType.String, this._Sublease_LastName);
			
			if (string.IsNullOrEmpty(this._Sublease_Title))
				db.AddInParameter(dbCommand, "Sublease_Title", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Title", DbType.String, this._Sublease_Title);
			
			if (string.IsNullOrEmpty(this._Sublease_Phone))
				db.AddInParameter(dbCommand, "Sublease_Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Phone", DbType.String, this._Sublease_Phone);
			
			if (string.IsNullOrEmpty(this._Sublease_Fax))
				db.AddInParameter(dbCommand, "Sublease_Fax", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Fax", DbType.String, this._Sublease_Fax);
			
			if (string.IsNullOrEmpty(this._Sublease_Email))
				db.AddInParameter(dbCommand, "Sublease_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sublease_Email", DbType.String, this._Sublease_Email);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);

            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Building_Ownership_Sublease table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Building_Ownership_Sublease)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Ownership_SubleaseDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Building_Ownership_Sublease", DbType.Decimal, pK_Building_Ownership_Sublease);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK(decimal fk_Building_Ownership)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Ownership_Sublease_SelectBy_BuildingOwnershipID");

            db.AddInParameter(dbCommand, "FK_Building_Ownership", DbType.Decimal, fk_Building_Ownership);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetSubLeaseByBuilding(decimal Pk_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAllSubLeaseByBulidingID");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, Pk_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
