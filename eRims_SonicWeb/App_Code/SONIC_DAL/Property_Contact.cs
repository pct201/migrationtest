using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Property_Contact table.
	/// </summary>
	public sealed class Property_Contact
    {
        #region Fields
        private int _PK_Property_Contact_ID;
        private int _FK_Building_ID;
        private string _Type;
        private string _Name;
        private string _Phone;
        private string _Cell_Phone;
        private string _After_Hours_Contact_Name;
        private string _After_Hours_Contact_Phone;
        private string _After_Hours_Contact_Cell_Phone;
        private string _Organization;
        private string _email;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_Property_Contact_ID value.
        /// </summary>
        public int PK_Property_Contact_ID
        {
            get { return _PK_Property_Contact_ID; }
            set { _PK_Property_Contact_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Building_ID value.
        /// </summary>
        public int FK_Building_ID
        {
            get { return _FK_Building_ID; }
            set { _FK_Building_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Type value.
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
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
        /// Gets or sets the Phone value.
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Cell_Phone value.
        /// </summary>
        public string Cell_Phone
        {
            get { return _Cell_Phone; }
            set { _Cell_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the After_Hours_Contact_Name value.
        /// </summary>
        public string After_Hours_Contact_Name
        {
            get { return _After_Hours_Contact_Name; }
            set { _After_Hours_Contact_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the After_Hours_Contact_Phone value.
        /// </summary>
        public string After_Hours_Contact_Phone
        {
            get { return _After_Hours_Contact_Phone; }
            set { _After_Hours_Contact_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the After_Hours_Contact_Cell_Phone value.
        /// </summary>
        public string After_Hours_Contact_Cell_Phone
        {
            get { return _After_Hours_Contact_Cell_Phone; }
            set { _After_Hours_Contact_Cell_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Organization value.
        /// </summary>
        public string Organization
        {
            get { return _Organization; }
            set { _Organization = value; }
        }


        /// <summary> 
        /// Gets or sets the email value.
        /// </summary>
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Property_Contact class. with the default value.

        /// </summary>
        public Property_Contact()
        {
            this._PK_Property_Contact_ID = -1;
            this._FK_Building_ID = -1;
            this._Type = "";
            this._Name = "";
            this._Phone = "";
            this._Cell_Phone = "";
            this._After_Hours_Contact_Name = "";
            this._After_Hours_Contact_Phone = "";
            this._After_Hours_Contact_Cell_Phone = "";
            this._Organization = "";
            this._email = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }


        /// <summary> 
        /// Initializes a new instance of the Property_Contact class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Property_Contact(int PK)
        {

            DataTable dtProperty_Contact = SelectByPK(PK).Tables[0];

            if (dtProperty_Contact.Rows.Count > 0)
            {

                DataRow drProperty_Contact = dtProperty_Contact.Rows[0];

                this._PK_Property_Contact_ID = drProperty_Contact["PK_Property_Contact_ID"] != DBNull.Value ? Convert.ToInt32(drProperty_Contact["PK_Property_Contact_ID"]) : 0;
                this._FK_Building_ID = drProperty_Contact["FK_Building_ID"] != DBNull.Value ? Convert.ToInt32(drProperty_Contact["FK_Building_ID"]) : 0;
                this._Type = Convert.ToString(drProperty_Contact["Type"]);
                this._Name = Convert.ToString(drProperty_Contact["Name"]);
                this._Phone = Convert.ToString(drProperty_Contact["Phone"]);
                this._Cell_Phone = Convert.ToString(drProperty_Contact["Cell_Phone"]);
                this._After_Hours_Contact_Name = Convert.ToString(drProperty_Contact["After_Hours_Contact_Name"]);
                this._After_Hours_Contact_Phone = Convert.ToString(drProperty_Contact["After_Hours_Contact_Phone"]);
                this._After_Hours_Contact_Cell_Phone = Convert.ToString(drProperty_Contact["After_Hours_Contact_Cell_Phone"]);
                this._Organization = Convert.ToString(drProperty_Contact["Organization"]);
                this._email = Convert.ToString(drProperty_Contact["email"]);
                this._Updated_By = drProperty_Contact["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drProperty_Contact["Updated_By"]) : 0;
                this._Updated_Date = drProperty_Contact["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_Contact["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
            else
            {

                this._PK_Property_Contact_ID = -1;
                this._FK_Building_ID = -1;
                this._Type = "";
                this._Name = "";
                this._Phone = "";
                this._Cell_Phone = "";
                this._After_Hours_Contact_Name = "";
                this._After_Hours_Contact_Phone = "";
                this._After_Hours_Contact_Cell_Phone = "";
                this._Organization = "";
                this._email = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }

        #endregion



        #region Methods

        /// <summary>
        /// Inserts a record into the Property_Contact table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactInsert");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, this._FK_Building_ID);
            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
            db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
            db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
            db.AddInParameter(dbCommand, "Cell_Phone", DbType.String, this._Cell_Phone);
            db.AddInParameter(dbCommand, "After_Hours_Contact_Name", DbType.String, this._After_Hours_Contact_Name);
            db.AddInParameter(dbCommand, "After_Hours_Contact_Phone", DbType.String, this._After_Hours_Contact_Phone);
            db.AddInParameter(dbCommand, "After_Hours_Contact_Cell_Phone", DbType.String, this._After_Hours_Contact_Cell_Phone);
            db.AddInParameter(dbCommand, "Organization", DbType.String, this._Organization);
            db.AddInParameter(dbCommand, "email", DbType.String, this._email);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Property_Contact table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Property_Contact_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactSelectByPK");

            db.AddInParameter(dbCommand, "PK_Property_Contact_ID", DbType.Int32, pK_Property_Contact_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Property_Contact table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Property_Contact table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactUpdate");

            db.AddInParameter(dbCommand, "PK_Property_Contact_ID", DbType.Int32, this._PK_Property_Contact_ID);
            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, this._FK_Building_ID);
            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
            db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
            db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
            db.AddInParameter(dbCommand, "Cell_Phone", DbType.String, this._Cell_Phone);
            db.AddInParameter(dbCommand, "After_Hours_Contact_Name", DbType.String, this._After_Hours_Contact_Name);
            db.AddInParameter(dbCommand, "After_Hours_Contact_Phone", DbType.String, this._After_Hours_Contact_Phone);
            db.AddInParameter(dbCommand, "After_Hours_Contact_Cell_Phone", DbType.String, this._After_Hours_Contact_Cell_Phone);
            db.AddInParameter(dbCommand, "Organization", DbType.String, this._Organization);
            db.AddInParameter(dbCommand, "email", DbType.String, this._email);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Property_Contact table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Property_Contact_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Property_Contact_ID", DbType.Int32, pK_Property_Contact_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectFacilityContact(int fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactSelectFacilityContact");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectEmergencyContact(int fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactSelectEmergencyContact");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectUtilityContact(int fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactSelectUtilityContact");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectOtherContact(int fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactSelectOtherContact");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static int SelectPKByBuilding_ID(int fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ContactSelectPKByBuilding_ID");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);
            db.AddOutParameter(dbCommand, "PK_Property_Contact_ID", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["@PK_Property_Contact_ID"].Value);
        }

        public static bool IsDuplicateType(int pK_Property_Contact_ID, int fK_Building_ID,string strType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Proeprty_ContactIsDuplicateType");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);
            db.AddInParameter(dbCommand, "PK_Property_Contact_ID", DbType.Int32, pK_Property_Contact_ID);
            db.AddInParameter(dbCommand, "Type", DbType.String, strType);
            db.AddOutParameter(dbCommand, "bDuplicate", DbType.Boolean, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToBoolean(dbCommand.Parameters["@bDuplicate"].Value);
        }
        #endregion
    }
}
