using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for ACI_Link_LU_Location table.
    /// </summary>
    public sealed class clsACI_Link_LU_Location
    {

        #region Private variables used to hold the property values

        private decimal? _PK_ACI_Link_LU_Location;
        private decimal? _Group_ID;
        private decimal? _FK_LU_Location;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_ACI_Link_LU_Location value.
        /// </summary>
        public decimal? PK_ACI_Link_LU_Location
        {
            get { return _PK_ACI_Link_LU_Location; }
            set { _PK_ACI_Link_LU_Location = value; }
        }

        /// <summary>
        /// Gets or sets the Group_ID value.
        /// </summary>
        public decimal? Group_ID
        {
            get { return _Group_ID; }
            set { _Group_ID = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal? FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsACI_Link_LU_Location class with default value.
        /// </summary>
        public clsACI_Link_LU_Location()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsACI_Link_LU_Location class based on Primary Key.
        /// </summary>
        public clsACI_Link_LU_Location(decimal pK_ACI_Link_LU_Location)
        {
            DataTable dtACI_Link_LU_Location = SelectByPK(pK_ACI_Link_LU_Location).Tables[0];

            if (dtACI_Link_LU_Location.Rows.Count == 1)
            {
                SetValue(dtACI_Link_LU_Location.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsACI_Link_LU_Location class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drACI_Link_LU_Location)
        {
            if (drACI_Link_LU_Location["PK_ACI_Link_LU_Location"] == DBNull.Value)
                this._PK_ACI_Link_LU_Location = null;
            else
                this._PK_ACI_Link_LU_Location = (decimal?)drACI_Link_LU_Location["PK_ACI_Link_LU_Location"];

            if (drACI_Link_LU_Location["Group_ID"] == DBNull.Value)
                this._Group_ID = null;
            else
                this._Group_ID = (decimal?)drACI_Link_LU_Location["Group_ID"];

            if (drACI_Link_LU_Location["FK_LU_Location"] == DBNull.Value)
                this._FK_LU_Location = null;
            else
                this._FK_LU_Location = (decimal?)drACI_Link_LU_Location["FK_LU_Location"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the ACI_Link_LU_Location table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Link_LU_LocationInsert");


            db.AddInParameter(dbCommand, "Group_ID", DbType.Decimal, this._Group_ID);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the ACI_Link_LU_Location table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_ACI_Link_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Link_LU_LocationSelectByPK");

            db.AddInParameter(dbCommand, "PK_ACI_Link_LU_Location", DbType.Decimal, pK_ACI_Link_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the ACI_Link_LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Link_LU_LocationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the ACI_Link_LU_Location table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Link_LU_LocationUpdate");


            db.AddInParameter(dbCommand, "PK_ACI_Link_LU_Location", DbType.Decimal, this._PK_ACI_Link_LU_Location);

            db.AddInParameter(dbCommand, "Group_ID", DbType.Decimal, this._Group_ID);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Deletes a record from the ACI_Link_LU_Location table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ACI_Link_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Link_LU_LocationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ACI_Link_LU_Location", DbType.Decimal, pK_ACI_Link_LU_Location);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects records from the ACI_Link_LU_Location table by FK_LU_Location.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet ACI_Link_LU_LocationSelectByFK_LU_Location(decimal FK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Link_LU_LocationSelectByFK_LU_Location");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
