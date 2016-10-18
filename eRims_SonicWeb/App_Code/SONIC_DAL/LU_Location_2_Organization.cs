using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Location_2_Organization table.
    /// </summary>
    public sealed class LU_Location_2_Organization
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Location_2_Organization_Id;
        private int? _Sonic_Location_Code;
        private string _ADP_DMS;
        private string _Organization_Code;
        private string _Organization_Name;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Location_2_Organization_Id value.
        /// </summary>
        public decimal? PK_LU_Location_2_Organization_Id
        {
            get { return _PK_LU_Location_2_Organization_Id; }
            set { _PK_LU_Location_2_Organization_Id = value; }
        }

        /// <summary>
        /// Gets or sets the Sonic_Location_Code value.
        /// </summary>
        public int? Sonic_Location_Code
        {
            get { return _Sonic_Location_Code; }
            set { _Sonic_Location_Code = value; }
        }

        /// <summary>
        /// Gets or sets the ADP_DMS value.
        /// </summary>
        public string ADP_DMS
        {
            get { return _ADP_DMS; }
            set { _ADP_DMS = value; }
        }

        /// <summary>
        /// Gets or sets the Organization_Code value.
        /// </summary>
        public string Organization_Code
        {
            get { return _Organization_Code; }
            set { _Organization_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Organization_Name value.
        /// </summary>
        public string Organization_Name
        {
            get { return _Organization_Name; }
            set { _Organization_Name = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Location_2_Organization class with default value.
        /// </summary>
        public LU_Location_2_Organization()
        {
            this._ADP_DMS = null;
            this._Organization_Code = null;
            this._PK_LU_Location_2_Organization_Id = null;
            this._Sonic_Location_Code = null;
            this._Organization_Name = null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Location_2_Organization class based on Primary Key.
        /// </summary>
        public LU_Location_2_Organization(decimal pk_LU_Location_2_Organization)
        {
            DataTable dtLU_Location_2_Organization = SelectByPK(pk_LU_Location_2_Organization).Tables[0];

            if (dtLU_Location_2_Organization.Rows.Count == 1)
            {
                DataRow drLU_Location_2_Organization = dtLU_Location_2_Organization.Rows[0];

                if (drLU_Location_2_Organization["PK_LU_Location_2_Organization_Id"] == DBNull.Value)
                    this._PK_LU_Location_2_Organization_Id = null;
                else
                    this._PK_LU_Location_2_Organization_Id = (decimal?)drLU_Location_2_Organization["PK_LU_Location_2_Organization_Id"];

                if (drLU_Location_2_Organization["Sonic_Location_Code"] == DBNull.Value)
                    this._Sonic_Location_Code = null;
                else
                    this._Sonic_Location_Code = (int?)drLU_Location_2_Organization["Sonic_Location_Code"];

                if (drLU_Location_2_Organization["ADP_DMS"] == DBNull.Value)
                    this._ADP_DMS = null;
                else
                    this._ADP_DMS = (string)drLU_Location_2_Organization["ADP_DMS"];

                if (drLU_Location_2_Organization["Organization_Code"] == DBNull.Value)
                    this._Organization_Code = null;
                else
                    this._Organization_Code = (string)drLU_Location_2_Organization["Organization_Code"];

                if (drLU_Location_2_Organization["Organization_Name"] == DBNull.Value)
                    this._Organization_Name = null;
                else
                    this._Organization_Name = (string)drLU_Location_2_Organization["Organization_Name"];
            }
            else
            {
                this._ADP_DMS = null;
                this._Organization_Code = null;
                this._PK_LU_Location_2_Organization_Id = null;
                this._Sonic_Location_Code = null;
                this._Organization_Name = null;
            }
        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Location_2_Organization table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_2_OrganizationInsert");


            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, this._Sonic_Location_Code);

            if (string.IsNullOrEmpty(this._ADP_DMS))
                db.AddInParameter(dbCommand, "ADP_DMS", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ADP_DMS", DbType.String, this._ADP_DMS);

            if (string.IsNullOrEmpty(this._Organization_Code))
                db.AddInParameter(dbCommand, "Organization_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Organization_Code", DbType.String, this._Organization_Code);

            if (string.IsNullOrEmpty(this._Organization_Name))
                db.AddInParameter(dbCommand, "Organization_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Organization_Name", DbType.String, this._Organization_Name);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Location_2_Organization table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pk_LU_Location_2_Organization_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_2_OrganizationSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Location_2_Organization_Id", DbType.Decimal, pk_LU_Location_2_Organization_Id);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Inserts a record into the LU_Location_2_Organization table.
        /// </summary>
        /// <returns></returns>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_2_OrganizationUpdate");


            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, this._Sonic_Location_Code);

            if (string.IsNullOrEmpty(this._ADP_DMS))
                db.AddInParameter(dbCommand, "ADP_DMS", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ADP_DMS", DbType.String, this._ADP_DMS);

            if (string.IsNullOrEmpty(this._Organization_Code))
                db.AddInParameter(dbCommand, "Organization_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Organization_Code", DbType.String, this._Organization_Code);

            if (string.IsNullOrEmpty(this._Organization_Name))
                db.AddInParameter(dbCommand, "Organization_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Organization_Name", DbType.String, this._Organization_Name);

            db.AddInParameter(dbCommand, "PK_LU_Location_2_Organization_Id", DbType.Decimal, _PK_LU_Location_2_Organization_Id);

            // Execute the query and return the new identity value
            db.ExecuteNonQuery(dbCommand);

            
        }

        /// <summary>
        /// Selects all records from the LU_Location_2_Organization table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_2_OrganizationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Location_2_Organization table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pk_LU_Location_2_Organization)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_2_OrganizationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Location_2_Organization_Id", DbType.Decimal, pk_LU_Location_2_Organization);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
