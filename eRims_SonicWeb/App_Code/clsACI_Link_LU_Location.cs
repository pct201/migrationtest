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
        private decimal? _FK_Building_ID;
        private string _STATUS;
        private DateTime? _Est_Live_Monitoring_Date;
        private DateTime? _Act_Live_Monitoring_Date;
        private string _Updated_By;
        private DateTime? _Update_Date;

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

        /// <summary>
        /// Gets or sets the FK_Building_ID value.
        /// </summary>
        public decimal? FK_Building_ID
        {
            get { return _FK_Building_ID; }
            set { _FK_Building_ID = value; }
        }

        /// <summary>
        /// Gets or sets the STATUS value.
        /// </summary>
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }

        /// <summary>
        /// Gets or sets the Est_Live_Monitoring_Date value.
        /// </summary>
        public DateTime? Est_Live_Monitoring_Date
        {
            get { return _Est_Live_Monitoring_Date; }
            set { _Est_Live_Monitoring_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Act_Live_Monitoring_Date value.
        /// </summary>
        public DateTime? Act_Live_Monitoring_Date
        {
            get { return _Act_Live_Monitoring_Date; }
            set { _Act_Live_Monitoring_Date = value; }
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

            if (drACI_Link_LU_Location["FK_Building_ID"] == DBNull.Value)
                this._FK_Building_ID = null;
            else
                this._FK_Building_ID = (decimal?)drACI_Link_LU_Location["FK_Building_ID"];

            if (drACI_Link_LU_Location["STATUS"] == DBNull.Value)
                this._STATUS = null;
            else
                this._STATUS = (string)drACI_Link_LU_Location["STATUS"];

            if (drACI_Link_LU_Location["Est_Live_Monitoring_Date"] == DBNull.Value)
                this._Est_Live_Monitoring_Date = null;
            else
                this._Est_Live_Monitoring_Date = (DateTime?)drACI_Link_LU_Location["Est_Live_Monitoring_Date"];

            if (drACI_Link_LU_Location["Act_Live_Monitoring_Date"] == DBNull.Value)
                this._Act_Live_Monitoring_Date = null;
            else
                this._Act_Live_Monitoring_Date = (DateTime?)drACI_Link_LU_Location["Act_Live_Monitoring_Date"];

            if (drACI_Link_LU_Location["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drACI_Link_LU_Location["Updated_By"];

            if (drACI_Link_LU_Location["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drACI_Link_LU_Location["Update_Date"];


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

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, this._FK_Building_ID);

            if (string.IsNullOrEmpty(this._STATUS))
                db.AddInParameter(dbCommand, "STATUS", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "STATUS", DbType.String, this._STATUS);

            db.AddInParameter(dbCommand, "Est_Live_Monitoring_Date", DbType.DateTime, this._Est_Live_Monitoring_Date);

            db.AddInParameter(dbCommand, "Act_Live_Monitoring_Date", DbType.DateTime, this._Act_Live_Monitoring_Date);

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

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, this._FK_Building_ID);

            if (string.IsNullOrEmpty(this._STATUS))
                db.AddInParameter(dbCommand, "STATUS", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "STATUS", DbType.String, this._STATUS);

            db.AddInParameter(dbCommand, "Est_Live_Monitoring_Date", DbType.DateTime, this._Est_Live_Monitoring_Date);

            db.AddInParameter(dbCommand, "Act_Live_Monitoring_Date", DbType.DateTime, this._Act_Live_Monitoring_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

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

        public static DataSet SearchByPaging(string strDesc, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_Link_LU_LocationSearch");
            db.AddInParameter(dbCommand, "Description", DbType.String, strDesc);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Building table by FK_LU_Location_ID.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetBuildingByFK_LU_Location_ID(decimal FK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetBuildingByFK_LU_Location_ID");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
