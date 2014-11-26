using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for SLT_Additional_Recipients table.
    /// </summary>
    public sealed class SLT_Additional_Recipients
    {

        #region Private variables used to hold the property values

        private decimal? _PK_SLT_Additional_Recipients;
        private decimal? _FK_SLT_Meeting;
        private string _First_Name;
        private string _Last_Name;
        private string _Email;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_SLT_Additional_Recipients value.
        /// </summary>
        public decimal? PK_SLT_Additional_Recipients
        {
            get { return _PK_SLT_Additional_Recipients; }
            set { _PK_SLT_Additional_Recipients = value; }
        }

        /// <summary>
        /// Gets or sets the FK_SLT_Meeting value.
        /// </summary>
        public decimal? FK_SLT_Meeting
        {
            get { return _FK_SLT_Meeting; }
            set { _FK_SLT_Meeting = value; }
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
        /// Initializes a new instance of the clsSLT_Additional_Recipients class with default value.
        /// </summary>
        public SLT_Additional_Recipients()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_Additional_Recipients class based on Primary Key.
        /// </summary>
        public SLT_Additional_Recipients(decimal pK_SLT_Additional_Recipients)
        {
            DataTable dtSLT_Additional_Recipients = SelectByPK(pK_SLT_Additional_Recipients).Tables[0];

            if (dtSLT_Additional_Recipients.Rows.Count == 1)
            {
                SetValue(dtSLT_Additional_Recipients.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsSLT_Additional_Recipients class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drSLT_Additional_Recipients)
        {
            if (drSLT_Additional_Recipients["PK_SLT_Additional_Recipients"] == DBNull.Value)
                this._PK_SLT_Additional_Recipients = null;
            else
                this._PK_SLT_Additional_Recipients = (decimal?)drSLT_Additional_Recipients["PK_SLT_Additional_Recipients"];

            if (drSLT_Additional_Recipients["FK_SLT_Meeting"] == DBNull.Value)
                this._FK_SLT_Meeting = null;
            else
                this._FK_SLT_Meeting = (decimal?)drSLT_Additional_Recipients["FK_SLT_Meeting"];

            if (drSLT_Additional_Recipients["First_Name"] == DBNull.Value)
                this._First_Name = null;
            else
                this._First_Name = (string)drSLT_Additional_Recipients["First_Name"];

            if (drSLT_Additional_Recipients["Last_Name"] == DBNull.Value)
                this._Last_Name = null;
            else
                this._Last_Name = (string)drSLT_Additional_Recipients["Last_Name"];

            if (drSLT_Additional_Recipients["Email"] == DBNull.Value)
                this._Email = null;
            else
                this._Email = (string)drSLT_Additional_Recipients["Email"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the SLT_Additional_Recipients table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Additional_RecipientsInsert");


            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the SLT_Additional_Recipients table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_SLT_Additional_Recipients)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Additional_RecipientsSelectByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Additional_Recipients", DbType.Decimal, pK_SLT_Additional_Recipients);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the SLT_Additional_Recipients table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Additional_RecipientsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the SLT_Additional_Recipients table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Additional_RecipientsUpdate");


            db.AddInParameter(dbCommand, "PK_SLT_Additional_Recipients", DbType.Decimal, this._PK_SLT_Additional_Recipients);

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Selects a single record from the SLT_Additional_Recipients table by a foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_SLT_Meeting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Additional_RecipientsSelectByFK");

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Deletes a record from the SLT_Additional_Recipients table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_SLT_Additional_Recipients)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Additional_RecipientsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Additional_Recipients", DbType.Decimal, pK_SLT_Additional_Recipients);

            db.ExecuteNonQuery(dbCommand);
        }


    }
}
