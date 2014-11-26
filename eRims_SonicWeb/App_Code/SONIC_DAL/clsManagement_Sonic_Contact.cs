using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Management_Sonic_Contact table.
	/// </summary>
	public sealed class clsManagement_Sonic_Contact
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Management_Sonic_Contact;
		private decimal? _FK_Management;
		private string _First_Name;
		private string _Last_name;
		private string _Phone;
		private string _Email;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Management_Sonic_Contact value.
		/// </summary>
		public decimal? PK_Management_Sonic_Contact
		{
			get { return _PK_Management_Sonic_Contact; }
			set { _PK_Management_Sonic_Contact = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Management value.
		/// </summary>
		public decimal? FK_Management
		{
			get { return _FK_Management; }
			set { _FK_Management = value; }
		}

		/// <summary>
		/// Gets or sets the First_Name value.
		/// </summary>
		public string First_Name
		{
			get { return _First_Name; }
			set { _First_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Last_name value.
		/// </summary>
		public string Last_name
		{
			get { return _Last_name; }
			set { _Last_name = value; }
		}

		/// <summary>
		/// Gets or sets the Phone value.
		/// </summary>
		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsManagement_Sonic_Contact class with default value.
		/// </summary>
		public clsManagement_Sonic_Contact() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsManagement_Sonic_Contact class based on Primary Key.
		/// </summary>
		public clsManagement_Sonic_Contact(decimal pK_Management_Sonic_Contact) 
		{
			DataTable dtManagement_Sonic_Contact = SelectByPK(pK_Management_Sonic_Contact).Tables[0];

			if (dtManagement_Sonic_Contact.Rows.Count == 1)
			{
				 SetValue(dtManagement_Sonic_Contact.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsManagement_Sonic_Contact class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drManagement_Sonic_Contact) 
		{
				if (drManagement_Sonic_Contact["PK_Management_Sonic_Contact"] == DBNull.Value)
					this._PK_Management_Sonic_Contact = null;
				else
					this._PK_Management_Sonic_Contact = (decimal?)drManagement_Sonic_Contact["PK_Management_Sonic_Contact"];

				if (drManagement_Sonic_Contact["FK_Management"] == DBNull.Value)
					this._FK_Management = null;
				else
					this._FK_Management = (decimal?)drManagement_Sonic_Contact["FK_Management"];

				if (drManagement_Sonic_Contact["First_Name"] == DBNull.Value)
					this._First_Name = null;
				else
					this._First_Name = (string)drManagement_Sonic_Contact["First_Name"];

				if (drManagement_Sonic_Contact["Last_name"] == DBNull.Value)
					this._Last_name = null;
				else
					this._Last_name = (string)drManagement_Sonic_Contact["Last_name"];

				if (drManagement_Sonic_Contact["Phone"] == DBNull.Value)
					this._Phone = null;
				else
					this._Phone = (string)drManagement_Sonic_Contact["Phone"];

				if (drManagement_Sonic_Contact["Email"] == DBNull.Value)
					this._Email = null;
				else
					this._Email = (string)drManagement_Sonic_Contact["Email"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Management_Sonic_Contact table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Sonic_ContactInsert");

			
			db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, this._FK_Management);
			
			if (string.IsNullOrEmpty(this._First_Name))
				db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);
			
			if (string.IsNullOrEmpty(this._Last_name))
				db.AddInParameter(dbCommand, "Last_name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Last_name", DbType.String, this._Last_name);
			
			if (string.IsNullOrEmpty(this._Phone))
				db.AddInParameter(dbCommand, "Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
			
			if (string.IsNullOrEmpty(this._Email))
				db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Management_Sonic_Contact table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Management_Sonic_Contact)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Sonic_ContactSelectByPK");

			db.AddInParameter(dbCommand, "PK_Management_Sonic_Contact", DbType.Decimal, pK_Management_Sonic_Contact);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Management_Sonic_Contact table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Sonic_ContactSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Management_Sonic_Contact table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Sonic_ContactUpdate");

			
			db.AddInParameter(dbCommand, "PK_Management_Sonic_Contact", DbType.Decimal, this._PK_Management_Sonic_Contact);
			
			db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, this._FK_Management);
			
			if (string.IsNullOrEmpty(this._First_Name))
				db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);
			
			if (string.IsNullOrEmpty(this._Last_name))
				db.AddInParameter(dbCommand, "Last_name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Last_name", DbType.String, this._Last_name);
			
			if (string.IsNullOrEmpty(this._Phone))
				db.AddInParameter(dbCommand, "Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
			
			if (string.IsNullOrEmpty(this._Email))
				db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Management_Sonic_Contact table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Management_Sonic_Contact)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Sonic_ContactDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Management_Sonic_Contact", DbType.Decimal, pK_Management_Sonic_Contact);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a record from the Management_Sonic_Contact table by a FK_Management.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Management(decimal FK_Management)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_Sonic_ContactSelectByFK_Management");

            db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, FK_Management);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
