using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Email_Settings table.
	/// </summary>
	public sealed class Email_Settings
    {
        #region Fields


        private decimal _Email_Settings_Id;
        private string _Module;
        private string _email_recipient;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the Email_Settings_Id value.
        /// </summary>
        public decimal Email_Settings_Id
        {
            get { return _Email_Settings_Id; }
            set { _Email_Settings_Id = value; }
        }


        /// <summary> 
        /// Gets or sets the Module value.
        /// </summary>
        public string Module
        {
            get { return _Module; }
            set { _Module = value; }
        }


        /// <summary> 
        /// Gets or sets the email_recipient value.
        /// </summary>
        public string email_recipient
        {
            get { return _email_recipient; }
            set { _email_recipient = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Email_Settings class. with the default value.

        /// </summary>
        public Email_Settings()
        {

            this._Email_Settings_Id = -1;
            this._Module = "";
            this._email_recipient = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Email_Settings class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Email_Settings(decimal PK)
        {

            DataTable dtEmail_Settings = SelectByPK(PK).Tables[0];

            if (dtEmail_Settings.Rows.Count > 0)
            {

                DataRow drEmail_Settings = dtEmail_Settings.Rows[0];

                this._Email_Settings_Id = drEmail_Settings["Email_Settings_Id"] != DBNull.Value ? Convert.ToDecimal(drEmail_Settings["Email_Settings_Id"]) : 0;
                this._Module = Convert.ToString(drEmail_Settings["Module"]);
                this._email_recipient = Convert.ToString(drEmail_Settings["email_recipient"]);

            }

            else
            {

                this._Email_Settings_Id = -1;
                this._Module = "";
                this._email_recipient = "";

            }

        }



        #endregion

        #region Methods
        /// <summary>
		/// Inserts a record into the Email_Settings table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Email_SettingsInsert");

			db.AddInParameter(dbCommand, "Module", DbType.String, this._Module);
			db.AddInParameter(dbCommand, "email_recipient", DbType.String, this._email_recipient);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Email_Settings table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal email_Settings_Id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Email_SettingsSelectByPK");

			db.AddInParameter(dbCommand, "Email_Settings_Id", DbType.Decimal, email_Settings_Id);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Email_Settings table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Email_SettingsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Email_Settings table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Email_SettingsUpdate");

			db.AddInParameter(dbCommand, "Email_Settings_Id", DbType.Decimal, this._Email_Settings_Id);
			db.AddInParameter(dbCommand, "Module", DbType.String, this._Module);
			db.AddInParameter(dbCommand, "email_recipient", DbType.String, this._email_recipient);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Email_Settings table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal email_Settings_Id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Email_SettingsDeleteByPK");

			db.AddInParameter(dbCommand, "Email_Settings_Id", DbType.Decimal, email_Settings_Id);

			db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Email_Settings table by a Module Name.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByModuleName(string ModuleName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectByModuleName");

            db.AddInParameter(dbCommand, "ModuleName", DbType.String, ModuleName);

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}
