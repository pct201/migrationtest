using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Alarm_Location table.
	/// </summary>
	public sealed class clsAlarm_Location
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Alarm_Location;
		private decimal? _FK_LU_Company;
		private string _MAC_Address;
		private string _Name;
		private string _Address_1;
		private string _Address_2;
		private string _City;
		private decimal? _FK_LU_State;
		private string _ZIP;
		private string _Country;
		private string _Building;
		private string _Contact_Name;
		private string _Contact_Telephone;
		private string _Contact_Email;
		private string _Site_Code;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Alarm_Location value.
		/// </summary>
		public decimal? PK_Alarm_Location
		{
			get { return _PK_Alarm_Location; }
			set { _PK_Alarm_Location = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Company value.
		/// </summary>
		public decimal? FK_LU_Company
		{
			get { return _FK_LU_Company; }
			set { _FK_LU_Company = value; }
		}

		/// <summary>
		/// Gets or sets the MAC_Address value.
		/// </summary>
		public string MAC_Address
		{
			get { return _MAC_Address; }
			set { _MAC_Address = value; }
		}

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
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
		/// Gets or sets the FK_LU_State value.
		/// </summary>
		public decimal? FK_LU_State
		{
			get { return _FK_LU_State; }
			set { _FK_LU_State = value; }
		}

		/// <summary>
		/// Gets or sets the ZIP value.
		/// </summary>
		public string ZIP
		{
			get { return _ZIP; }
			set { _ZIP = value; }
		}

		/// <summary>
		/// Gets or sets the Country value.
		/// </summary>
		public string Country
		{
			get { return _Country; }
			set { _Country = value; }
		}

		/// <summary>
		/// Gets or sets the Building value.
		/// </summary>
		public string Building
		{
			get { return _Building; }
			set { _Building = value; }
		}

		/// <summary>
		/// Gets or sets the Contact_Name value.
		/// </summary>
		public string Contact_Name
		{
			get { return _Contact_Name; }
			set { _Contact_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Contact_Telephone value.
		/// </summary>
		public string Contact_Telephone
		{
			get { return _Contact_Telephone; }
			set { _Contact_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Contact_Email value.
		/// </summary>
		public string Contact_Email
		{
			get { return _Contact_Email; }
			set { _Contact_Email = value; }
		}

		/// <summary>
		/// Gets or sets the Site_Code value.
		/// </summary>
		public string Site_Code
		{
			get { return _Site_Code; }
			set { _Site_Code = value; }
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
		/// Initializes a new instance of the clsAlarm_Location class with default value.
		/// </summary>
		public clsAlarm_Location() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAlarm_Location class based on Primary Key.
		/// </summary>
		public clsAlarm_Location(decimal pK_Alarm_Location) 
		{
			DataTable dtAlarm_Location = SelectByPK(pK_Alarm_Location).Tables[0];

			if (dtAlarm_Location.Rows.Count == 1)
			{
				 SetValue(dtAlarm_Location.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAlarm_Location class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAlarm_Location) 
		{
				if (drAlarm_Location["PK_Alarm_Location"] == DBNull.Value)
					this._PK_Alarm_Location = null;
				else
					this._PK_Alarm_Location = (decimal?)drAlarm_Location["PK_Alarm_Location"];

				if (drAlarm_Location["FK_LU_Company"] == DBNull.Value)
					this._FK_LU_Company = null;
				else
					this._FK_LU_Company = (decimal?)drAlarm_Location["FK_LU_Company"];

				if (drAlarm_Location["MAC_Address"] == DBNull.Value)
					this._MAC_Address = null;
				else
					this._MAC_Address = (string)drAlarm_Location["MAC_Address"];

				if (drAlarm_Location["Name"] == DBNull.Value)
					this._Name = null;
				else
					this._Name = (string)drAlarm_Location["Name"];

				if (drAlarm_Location["Address_1"] == DBNull.Value)
					this._Address_1 = null;
				else
					this._Address_1 = (string)drAlarm_Location["Address_1"];

				if (drAlarm_Location["Address_2"] == DBNull.Value)
					this._Address_2 = null;
				else
					this._Address_2 = (string)drAlarm_Location["Address_2"];

				if (drAlarm_Location["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drAlarm_Location["City"];

				if (drAlarm_Location["FK_LU_State"] == DBNull.Value)
					this._FK_LU_State = null;
				else
					this._FK_LU_State = (decimal?)drAlarm_Location["FK_LU_State"];

				if (drAlarm_Location["ZIP"] == DBNull.Value)
					this._ZIP = null;
				else
					this._ZIP = (string)drAlarm_Location["ZIP"];

				if (drAlarm_Location["Country"] == DBNull.Value)
					this._Country = null;
				else
					this._Country = (string)drAlarm_Location["Country"];

				if (drAlarm_Location["Building"] == DBNull.Value)
					this._Building = null;
				else
					this._Building = (string)drAlarm_Location["Building"];

				if (drAlarm_Location["Contact_Name"] == DBNull.Value)
					this._Contact_Name = null;
				else
					this._Contact_Name = (string)drAlarm_Location["Contact_Name"];

				if (drAlarm_Location["Contact_Telephone"] == DBNull.Value)
					this._Contact_Telephone = null;
				else
					this._Contact_Telephone = (string)drAlarm_Location["Contact_Telephone"];

				if (drAlarm_Location["Contact_Email"] == DBNull.Value)
					this._Contact_Email = null;
				else
					this._Contact_Email = (string)drAlarm_Location["Contact_Email"];

				if (drAlarm_Location["Site_Code"] == DBNull.Value)
					this._Site_Code = null;
				else
					this._Site_Code = (string)drAlarm_Location["Site_Code"];

				if (drAlarm_Location["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drAlarm_Location["Updated_By"];

				if (drAlarm_Location["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drAlarm_Location["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Alarm_Location table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Alarm_LocationInsert");

			
			db.AddInParameter(dbCommand, "FK_LU_Company", DbType.Decimal, this._FK_LU_Company);
			
			if (string.IsNullOrEmpty(this._MAC_Address))
				db.AddInParameter(dbCommand, "MAC_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "MAC_Address", DbType.String, this._MAC_Address);
			
			if (string.IsNullOrEmpty(this._Name))
				db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
			
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
			
			db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, this._FK_LU_State);
			
			if (string.IsNullOrEmpty(this._ZIP))
				db.AddInParameter(dbCommand, "ZIP", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ZIP", DbType.String, this._ZIP);
			
			if (string.IsNullOrEmpty(this._Country))
				db.AddInParameter(dbCommand, "Country", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Country", DbType.String, this._Country);
			
			if (string.IsNullOrEmpty(this._Building))
				db.AddInParameter(dbCommand, "Building", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Building", DbType.String, this._Building);
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
			if (string.IsNullOrEmpty(this._Contact_Telephone))
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Contact_Email))
				db.AddInParameter(dbCommand, "Contact_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Email", DbType.String, this._Contact_Email);
			
			if (string.IsNullOrEmpty(this._Site_Code))
				db.AddInParameter(dbCommand, "Site_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Site_Code", DbType.String, this._Site_Code);
			
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
		/// Selects a single record from the Alarm_Location table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Alarm_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Alarm_LocationSelectByPK");

			db.AddInParameter(dbCommand, "PK_Alarm_Location", DbType.Decimal, pK_Alarm_Location);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Alarm_Location table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Alarm_LocationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Alarm_Location table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Alarm_LocationUpdate");

			
			db.AddInParameter(dbCommand, "PK_Alarm_Location", DbType.Decimal, this._PK_Alarm_Location);
			
			db.AddInParameter(dbCommand, "FK_LU_Company", DbType.Decimal, this._FK_LU_Company);
			
			if (string.IsNullOrEmpty(this._MAC_Address))
				db.AddInParameter(dbCommand, "MAC_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "MAC_Address", DbType.String, this._MAC_Address);
			
			if (string.IsNullOrEmpty(this._Name))
				db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
			
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
			
			db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, this._FK_LU_State);
			
			if (string.IsNullOrEmpty(this._ZIP))
				db.AddInParameter(dbCommand, "ZIP", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ZIP", DbType.String, this._ZIP);
			
			if (string.IsNullOrEmpty(this._Country))
				db.AddInParameter(dbCommand, "Country", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Country", DbType.String, this._Country);
			
			if (string.IsNullOrEmpty(this._Building))
				db.AddInParameter(dbCommand, "Building", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Building", DbType.String, this._Building);
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
			if (string.IsNullOrEmpty(this._Contact_Telephone))
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Contact_Email))
				db.AddInParameter(dbCommand, "Contact_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Email", DbType.String, this._Contact_Email);
			
			if (string.IsNullOrEmpty(this._Site_Code))
				db.AddInParameter(dbCommand, "Site_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Site_Code", DbType.String, this._Site_Code);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Alarm_Location table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Alarm_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Alarm_LocationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Alarm_Location", DbType.Decimal, pK_Alarm_Location);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
