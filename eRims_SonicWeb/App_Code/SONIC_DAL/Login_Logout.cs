using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Login_Logout table.
	/// </summary>
	public sealed class Login_Logout
	{

		#region Private variables used to hold the property values

		private string _IP_Address;
		private DateTime? _Login_Date;
		private DateTime? _Logout_Date;
		private decimal? _PK_Login_Logout;
		private decimal? _PK_Security;
		private string _Session_Id;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the IP_Address value.
		/// </summary>
		public string IP_Address
		{
			get { return _IP_Address; }
			set { _IP_Address = value; }
		}

		/// <summary>
		/// Gets or sets the Login_Date value.
		/// </summary>
		public DateTime? Login_Date
		{
			get { return _Login_Date; }
			set { _Login_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Logout_Date value.
		/// </summary>
		public DateTime? Logout_Date
		{
			get { return _Logout_Date; }
			set { _Logout_Date = value; }
		}

		/// <summary>
		/// Gets or sets the PK_Login_Logout value.
		/// </summary>
		public decimal? PK_Login_Logout
		{
			get { return _PK_Login_Logout; }
			set { _PK_Login_Logout = value; }
		}

		/// <summary>
		/// Gets or sets the PK_Security value.
		/// </summary>
		public decimal? PK_Security
		{
			get { return _PK_Security; }
			set { _PK_Security = value; }
		}

		/// <summary>
		/// Gets or sets the Session_Id value.
		/// </summary>
		public string Session_Id
		{
			get { return _Session_Id; }
			set { _Session_Id = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLogin_Logout class with default value.
		/// </summary>
		public Login_Logout() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLogin_Logout class based on Primary Key.
		/// </summary>
		public Login_Logout(decimal pK_Login_Logout) 
		{
			DataTable dtLogin_Logout = SelectByPK(pK_Login_Logout).Tables[0];

			if (dtLogin_Logout.Rows.Count == 1)
			{
				 SetValue(dtLogin_Logout.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLogin_Logout class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLogin_Logout) 
		{
				if (drLogin_Logout["IP_Address"] == DBNull.Value)
					this._IP_Address = null;
				else
					this._IP_Address = (string)drLogin_Logout["IP_Address"];

				if (drLogin_Logout["Login_Date"] == DBNull.Value)
					this._Login_Date = null;
				else
					this._Login_Date = (DateTime?)drLogin_Logout["Login_Date"];

				if (drLogin_Logout["Logout_Date"] == DBNull.Value)
					this._Logout_Date = null;
				else
					this._Logout_Date = (DateTime?)drLogin_Logout["Logout_Date"];

				if (drLogin_Logout["PK_Login_Logout"] == DBNull.Value)
					this._PK_Login_Logout = null;
				else
					this._PK_Login_Logout = (decimal?)drLogin_Logout["PK_Login_Logout"];

				if (drLogin_Logout["PK_Security"] == DBNull.Value)
					this._PK_Security = null;
				else
					this._PK_Security = (decimal?)drLogin_Logout["PK_Security"];

				if (drLogin_Logout["Session_Id"] == DBNull.Value)
					this._Session_Id = null;
				else
					this._Session_Id = (string)drLogin_Logout["Session_Id"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Login_Logout table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Login_LogoutInsert");

			
			if (string.IsNullOrEmpty(this._IP_Address))
				db.AddInParameter(dbCommand, "IP_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "IP_Address", DbType.String, this._IP_Address);
			
			db.AddInParameter(dbCommand, "Login_Date", DbType.DateTime, this._Login_Date);
			
			db.AddInParameter(dbCommand, "Logout_Date", DbType.DateTime, this._Logout_Date);
			
			db.AddInParameter(dbCommand, "PK_Security", DbType.Decimal, this._PK_Security);
			
			if (string.IsNullOrEmpty(this._Session_Id))
				db.AddInParameter(dbCommand, "Session_Id", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Session_Id", DbType.String, this._Session_Id);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Login_Logout table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Login_Logout)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Login_LogoutSelectByPK");

			db.AddInParameter(dbCommand, "PK_Login_Logout", DbType.Decimal, pK_Login_Logout);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Login_Logout table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Login_LogoutSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects all records from the Login_Logout table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SearchLogAudit(string pK_Security_ID,DateTime Begin_Date,DateTime End_Date)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Login_LogoutReport");

            if(Begin_Date==DateTime.MinValue)
                db.AddInParameter(dbCommand, "Begin_Date", DbType.DateTime, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Begin_Date", DbType.DateTime, Begin_Date);

            if (End_Date == DateTime.MinValue)
                db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, End_Date);

            if (string.IsNullOrEmpty(pK_Security_ID))
                db.AddInParameter(dbCommand, "PK_Security_ID", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "PK_Security_ID", DbType.String, pK_Security_ID);
            //db.AddInParameter(dbCommand, "PK_Security_ID", DbType.String, pK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Login_Logout table.
        /// </summary>
        public void UpdateLogout()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Login_LogoutUpdateLogout");

            db.AddInParameter(dbCommand, "Logout_Date", DbType.DateTime, this._Logout_Date);

            db.AddInParameter(dbCommand, "PK_Login_Logout", DbType.Decimal, this._PK_Login_Logout);

            db.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// Updates a record in the Login_Logout table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Login_LogoutUpdate");

			
			if (string.IsNullOrEmpty(this._IP_Address))
				db.AddInParameter(dbCommand, "IP_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "IP_Address", DbType.String, this._IP_Address);
			
			db.AddInParameter(dbCommand, "Login_Date", DbType.DateTime, this._Login_Date);
			
			db.AddInParameter(dbCommand, "Logout_Date", DbType.DateTime, this._Logout_Date);
			
			db.AddInParameter(dbCommand, "PK_Login_Logout", DbType.Decimal, this._PK_Login_Logout);
			
			db.AddInParameter(dbCommand, "PK_Security", DbType.Decimal, this._PK_Security);
			
			if (string.IsNullOrEmpty(this._Session_Id))
				db.AddInParameter(dbCommand, "Session_Id", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Session_Id", DbType.String, this._Session_Id);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Login_Logout table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Login_Logout)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Login_LogoutDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Login_Logout", DbType.Decimal, pK_Login_Logout);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the Login_Logout table by a composite primary key.
        /// </summary>
        public static DataSet  SecuritySelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_SelectAll");

            return db.ExecuteDataSet(dbCommand);
        }
        
	}
}
