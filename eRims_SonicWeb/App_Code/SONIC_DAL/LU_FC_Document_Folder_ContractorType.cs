using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table LU_FC_Document_Folder_ContractorType
    /// </summary>
    public sealed class LU_FC_Document_Folder_ContractorType
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_FC_Document_Folder_ContractorType;
        private decimal? _FK_LU_FC_Document_Folder;
        private decimal? _FK_LU_Contractor_Type;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_FC_Document_Folder_ContractorType value.
        /// </summary>
        public decimal? PK_LU_FC_Document_Folder_ContractorType
        {
            get { return _PK_LU_FC_Document_Folder_ContractorType; }
            set { _PK_LU_FC_Document_Folder_ContractorType = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_FC_Document_Folder value.
        /// </summary>
        public decimal? FK_LU_FC_Document_Folder
        {
            get { return _FK_LU_FC_Document_Folder; }
            set { _FK_LU_FC_Document_Folder = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Contractor_Type value.
        /// </summary>
        public decimal? FK_LU_Contractor_Type
        {
            get { return _FK_LU_Contractor_Type; }
            set { _FK_LU_Contractor_Type = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the LU_FC_Document_Folder_ContractorType class with default value.
        /// </summary>
        public LU_FC_Document_Folder_ContractorType()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_FC_Document_Folder_ContractorType class based on Primary Key.
        /// </summary>
        public LU_FC_Document_Folder_ContractorType(decimal pK_LU_FC_Document_Folder_ContractorType)
        {
            DataTable dtLU_FC_Document_Folder_ContractorType = Select(pK_LU_FC_Document_Folder_ContractorType).Tables[0];

            if (dtLU_FC_Document_Folder_ContractorType.Rows.Count == 1)
            {
                SetValue(dtLU_FC_Document_Folder_ContractorType.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the LU_FC_Document_Folder_ContractorType class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_FC_Document_Folder_ContractorType)
        {
            if (drLU_FC_Document_Folder_ContractorType["PK_LU_FC_Document_Folder_ContractorType"] == DBNull.Value)
                this._PK_LU_FC_Document_Folder_ContractorType = null;
            else
                this._PK_LU_FC_Document_Folder_ContractorType = (decimal?)drLU_FC_Document_Folder_ContractorType["PK_LU_FC_Document_Folder_ContractorType"];

            if (drLU_FC_Document_Folder_ContractorType["FK_LU_FC_Document_Folder"] == DBNull.Value)
                this._FK_LU_FC_Document_Folder = null;
            else
                this._FK_LU_FC_Document_Folder = (decimal?)drLU_FC_Document_Folder_ContractorType["FK_LU_FC_Document_Folder"];

            if (drLU_FC_Document_Folder_ContractorType["FK_LU_Contractor_Type"] == DBNull.Value)
                this._FK_LU_Contractor_Type = null;
            else
                this._FK_LU_Contractor_Type = (decimal?)drLU_FC_Document_Folder_ContractorType["FK_LU_Contractor_Type"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_FC_Document_Folder_ContractorType table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_Folder_ContractorTypeInsert");


            db.AddInParameter(dbCommand, "FK_LU_FC_Document_Folder", DbType.Decimal, this._FK_LU_FC_Document_Folder);

            db.AddInParameter(dbCommand, "FK_LU_Contractor_Type", DbType.Decimal, this._FK_LU_Contractor_Type);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_FC_Document_Folder_ContractorType table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_LU_FC_Document_Folder_ContractorType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_Folder_ContractorTypeSelect");

            db.AddInParameter(dbCommand, "PK_LU_FC_Document_Folder_ContractorType", DbType.Decimal, pK_LU_FC_Document_Folder_ContractorType);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the LU_FC_Document_Folder_ContractorType table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_LU_FC_Document_Folder(decimal FK_LU_FC_Document_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_Folder_ContractorTypeSelectByFK");

            db.AddInParameter(dbCommand, "FK_LU_FC_Document_Folder", DbType.Decimal, FK_LU_FC_Document_Folder);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_FC_Document_Folder_ContractorType table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_Folder_ContractorTypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_FC_Document_Folder_ContractorType table by a composite primary key.
        /// </summary>
        public static void Delete(decimal FK_LU_FC_Document_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_Folder_ContractorTypeDelete");

            db.AddInParameter(dbCommand, "FK_LU_FC_Document_Folder", DbType.Decimal, FK_LU_FC_Document_Folder);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
