using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Security_ACI_LU_Location table.
    /// </summary>
    public sealed class clsSecurity_ACI_LU_Location
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Security_ACI_LU_Location;
        private decimal? _FK_ACI_LU_Location_ID;
        private decimal? _FK_Security_ID;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Security_ACI_LU_Location value.
        /// </summary>
        public decimal? PK_Security_ACI_LU_Location
        {
            get { return _PK_Security_ACI_LU_Location; }
            set { _PK_Security_ACI_LU_Location = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public decimal? FK_ACI_LU_Location_ID
        {
            get { return _FK_ACI_LU_Location_ID; }
            set { _FK_ACI_LU_Location_ID = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Security_ID value.
        /// </summary>
        public decimal? FK_Security_ID
        {
            get { return _FK_Security_ID; }
            set { _FK_Security_ID = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsSecurity_ACI_LU_Location class with default value.
        /// </summary>
        public clsSecurity_ACI_LU_Location()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsSecurity_ACI_LU_Location class based on Primary Key.
        /// </summary>
        public clsSecurity_ACI_LU_Location(decimal PK_Security_ACI_LU_Location)
        {
            DataTable dtSecurity_ACI_LU_Location = SelectByPK(PK_Security_ACI_LU_Location).Tables[0];

            if (dtSecurity_ACI_LU_Location.Rows.Count == 1)
            {
                SetValue(dtSecurity_ACI_LU_Location.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsSecurity_ACI_LU_Location class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drSecurity_ACI_LU_Location)
        {
            if (drSecurity_ACI_LU_Location["PK_Security_ACI_LU_Location"] == DBNull.Value)
                this._PK_Security_ACI_LU_Location = null;
            else
                this._PK_Security_ACI_LU_Location = (decimal?)drSecurity_ACI_LU_Location["PK_Security_ACI_LU_Location"];

            if (drSecurity_ACI_LU_Location["FK_ACI_LU_Location_ID"] == DBNull.Value)
                this._FK_ACI_LU_Location_ID = null;
            else
                this._FK_ACI_LU_Location_ID = (decimal?)drSecurity_ACI_LU_Location["FK_ACILU_Location_ID"];

            if (drSecurity_ACI_LU_Location["FK_Security_ID"] == DBNull.Value)
                this._FK_Security_ID = null;
            else
                this._FK_Security_ID = (decimal?)drSecurity_ACI_LU_Location["FK_Security_ID"];
        }

        #endregion

        /// <summary>
        /// Inserts a record into the Security_ACI_LU_Location table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_LocationInsert");


            db.AddInParameter(dbCommand, "FK_ACI_LU_Location_ID", DbType.Decimal, this._FK_ACI_LU_Location_ID);

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Security_ACI_LU_Location table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal PK_Security_ACI_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_LocationSelectByPK");

            db.AddInParameter(dbCommand, "PK_Security_ACI_LU_Location", DbType.Decimal, PK_Security_ACI_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Security_ACI_LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_LocationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Security_ACI_LU_Location table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_LocationUpdate");


            db.AddInParameter(dbCommand, "PK_Security_ACI_LU_Location", DbType.Decimal, this._PK_Security_ACI_LU_Location);

            db.AddInParameter(dbCommand, "FK_ACI_LU_Location_ID", DbType.Decimal, this._FK_ACI_LU_Location_ID);

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Security_ACI_LU_Location table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal PK_Security_ACI_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_LocationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Security_ACI_LU_Location", DbType.Decimal, PK_Security_ACI_LU_Location);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Security_ACI_LU_Location table by User (FK_Security_ID)
        /// </summary>
        public static void DeleteByUser(decimal fK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_LocationDeleteByUser");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, fK_Security_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Security_ACI_LU_Location table by User (FK_Security_ID)
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUser(decimal FK_Security_ID, bool bSelectAll)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_LocationSelectByUser");
            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, FK_Security_ID);
            db.AddInParameter(dbCommand, "bSelectAll", DbType.Decimal, bSelectAll);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
