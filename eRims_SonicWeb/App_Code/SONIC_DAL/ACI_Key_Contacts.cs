using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for ACI_Key_Contacts table.
    /// </summary>
    public sealed class ACI_Key_Contacts
    {

        #region Private variables used to hold the property values

        private decimal? _PK_ACI_Key_Contacts;
        private string _First_Name;
        private string _Last_Name;
        private string _Job_Title;
        private string _Email;
        private decimal? _FK_Building_ID;
        private string _Cell_Phone;
        private string _Work_Phone;
        private DateTime? _Update_Date;
        private string _Updated_By;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_ACI_Key_Contacts value.
        /// </summary>
        public decimal? PK_ACI_Key_Contacts
        {
            get { return _PK_ACI_Key_Contacts; }
            set { _PK_ACI_Key_Contacts = value; }
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
        /// Gets or sets the Last_Name value.
        /// </summary>
        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Job_Title value.
        /// </summary>
        public string Job_Title
        {
            get { return _Job_Title; }
            set { _Job_Title = value; }
        }

        /// <summary>
        /// Gets or sets the Email value.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Building_ID value.
        /// </summary>
        public decimal? FK_Building_ID
        {
            get { return _FK_Building_ID; }
            set { _FK_Building_ID = value; }
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
        /// Gets or sets the Work_Phone value.
        /// </summary>
        public string Work_Phone
        {
            get { return _Work_Phone; }
            set { _Work_Phone = value; }
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
        /// Initializes a new instance of the ACI_Key_Contacts class with default value.
        /// </summary>
        public ACI_Key_Contacts()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the ACI_Key_Contacts class based on Primary Key.
        /// </summary>
        public ACI_Key_Contacts(decimal pK_ACI_Key_Contacts)
        {
            DataTable dtACI_Key_Contacts = SelectByPK(pK_ACI_Key_Contacts).Tables[0];

            if (dtACI_Key_Contacts.Rows.Count == 1)
            {
                SetValue(dtACI_Key_Contacts.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the ACI_Key_Contacts class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drACI_Key_Contacts)
        {
            if (drACI_Key_Contacts["PK_ACI_Key_Contacts"] == DBNull.Value)
                this._PK_ACI_Key_Contacts = null;
            else
                this._PK_ACI_Key_Contacts = (decimal?)drACI_Key_Contacts["PK_ACI_Key_Contacts"];

            if (drACI_Key_Contacts["First_Name"] == DBNull.Value)
                this._First_Name = null;
            else
                this._First_Name = (string)drACI_Key_Contacts["First_Name"];

            if (drACI_Key_Contacts["Last_Name"] == DBNull.Value)
                this._Last_Name = null;
            else
                this._Last_Name = (string)drACI_Key_Contacts["Last_Name"];

            if (drACI_Key_Contacts["Job_Title"] == DBNull.Value)
                this._Job_Title = null;
            else
                this._Job_Title = (string)drACI_Key_Contacts["Job_Title"];

            if (drACI_Key_Contacts["Email"] == DBNull.Value)
                this._Email = null;
            else
                this._Email = (string)drACI_Key_Contacts["Email"];

            if (drACI_Key_Contacts["FK_Building_ID"] == DBNull.Value)
                this._FK_Building_ID = null;
            else
                this._FK_Building_ID = (decimal?)drACI_Key_Contacts["FK_Building_ID"];

            if (drACI_Key_Contacts["Cell_Phone"] == DBNull.Value)
                this._Cell_Phone = null;
            else
                this._Cell_Phone = (string)drACI_Key_Contacts["Cell_Phone"];

            if (drACI_Key_Contacts["Work_Phone"] == DBNull.Value)
                this._Work_Phone = null;
            else
                this._Work_Phone = (string)drACI_Key_Contacts["Work_Phone"];

            if (drACI_Key_Contacts["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drACI_Key_Contacts["Update_Date"];

            if (drACI_Key_Contacts["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drACI_Key_Contacts["Updated_By"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the ACI_Key_Contacts table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Key_ContactsInsert");


            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Job_Title))
                db.AddInParameter(dbCommand, "Job_Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Job_Title", DbType.String, this._Job_Title);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, this._FK_Building_ID);

            if (string.IsNullOrEmpty(this._Cell_Phone))
                db.AddInParameter(dbCommand, "Cell_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Phone", DbType.String, this._Cell_Phone);

            if (string.IsNullOrEmpty(this._Work_Phone))
                db.AddInParameter(dbCommand, "Work_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Phone", DbType.String, this._Work_Phone);

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
        /// Selects a single record from the ACI_Key_Contacts table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ACI_Key_Contacts)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Key_ContactsSelectByPK");

            db.AddInParameter(dbCommand, "PK_ACI_Key_Contacts", DbType.Decimal, pK_ACI_Key_Contacts);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the ACI_Key_Contacts table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Key_ContactsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the ACI_Key_Contacts table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Key_ContactsUpdate");


            db.AddInParameter(dbCommand, "PK_ACI_Key_Contacts", DbType.Decimal, this._PK_ACI_Key_Contacts);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Job_Title))
                db.AddInParameter(dbCommand, "Job_Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Job_Title", DbType.String, this._Job_Title);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, this._FK_Building_ID);

            if (string.IsNullOrEmpty(this._Cell_Phone))
                db.AddInParameter(dbCommand, "Cell_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Phone", DbType.String, this._Cell_Phone);

            if (string.IsNullOrEmpty(this._Work_Phone))
                db.AddInParameter(dbCommand, "Work_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Phone", DbType.String, this._Work_Phone);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the ACI_Key_Contacts table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ACI_Key_Contacts)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Key_ContactsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ACI_Key_Contacts", DbType.Decimal, pK_ACI_Key_Contacts);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the ACI_Key_Contacts table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPKBuilding(decimal pK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Key_ContactsSelectByPKBuilding");

            db.AddInParameter(dbCommand, "PK_Building_ID", DbType.Decimal, pK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
