using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for Purchasing_Asset
    /// </summary>    
    public sealed class Purchasing_Asset
    {
        #region Fields

        private decimal _PK_Purchasing_Asset;
        private string _Type;
        private decimal _FK_LU_Manufacturer;
        private decimal _FK_LU_Dealership_Department;
        private string _Serial_Number;
        private string _Model_Number;
        private string _Supplier;
        private DateTime _Acquisition_Date;
        private decimal _Useful_Life;
        private decimal _Acquisition_Cost;
        private decimal _FK_LU_Location;
        private string _Notes;
        private string _Updated_By;
        private DateTime _Update_Date;

        #endregion

        #region Properties
        // <summary> 
        /// Gets or sets the PK_Purchasing_Asset value.
        /// </summary>
        public decimal PK_Purchasing_Asset
        {
            get { return _PK_Purchasing_Asset; }
            set { _PK_Purchasing_Asset = value; }
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
        /// Gets or sets the FK_LU_Manufacturer value.
        /// </summary>
        public decimal FK_LU_Manufacturer
        {
            get { return _FK_LU_Manufacturer; }
            set { _FK_LU_Manufacturer = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Dealership_Department value.
        /// </summary>
        public decimal FK_LU_Dealership_Department
        {
            get { return _FK_LU_Dealership_Department; }
            set { _FK_LU_Dealership_Department = value; }
        }


        /// <summary> 
        /// Gets or sets the Serial_Number value.
        /// </summary>
        public string Serial_Number
        {
            get { return _Serial_Number; }
            set { _Serial_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Model_Number value.
        /// </summary>
        public string Model_Number
        {
            get { return _Model_Number; }
            set { _Model_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Supplier value.
        /// </summary>
        public string Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        }


        /// <summary> 
        /// Gets or sets the Acquisition_Date value.
        /// </summary>
        public DateTime Acquisition_Date
        {
            get { return _Acquisition_Date; }
            set { _Acquisition_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Useful_Life value.
        /// </summary>
        public decimal Useful_Life
        {
            get { return _Useful_Life; }
            set { _Useful_Life = value; }
        }


        /// <summary> 
        /// Gets or sets the Acquisition_Cost value.
        /// </summary>
        public decimal Acquisition_Cost
        {
            get { return _Acquisition_Cost; }
            set { _Acquisition_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
        }


        /// <summary> 
        /// Gets or sets the Notes value.
        /// </summary>
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
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
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }



        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Purchasing_Asset class. with the default value.

        /// </summary>
        public Purchasing_Asset()
        {

            this._PK_Purchasing_Asset = -1;
            this._Type = "";
            this._FK_LU_Manufacturer = -1;
            this._FK_LU_Dealership_Department = -1;
            this._Serial_Number = "";
            this._Model_Number = "";
            this._Supplier = "";
            this._Acquisition_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Useful_Life = 0;
            this._Acquisition_Cost = -1;
            this._FK_LU_Location = -1;
            this._Notes = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }


        /// <summary>
        /// Initializes a new instance of the Purchasing_Asset class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Purchasing_Asset(decimal PK)
        {

            DataTable dtPurchasing_Asset = SelectByPK(PK).Tables[0];

            if (dtPurchasing_Asset.Rows.Count > 0)
            {

                DataRow drPurchasing_Asset = dtPurchasing_Asset.Rows[0];
                this._PK_Purchasing_Asset = drPurchasing_Asset["PK_Purchasing_Asset"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["PK_Purchasing_Asset"]) : 0;
                this._Type = Convert.ToString(drPurchasing_Asset["Type"]);
                this._FK_LU_Manufacturer = drPurchasing_Asset["FK_LU_Manufacturer"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["FK_LU_Manufacturer"]) : 0;
                this._FK_LU_Dealership_Department = drPurchasing_Asset["FK_LU_Dealership_Department"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["FK_LU_Dealership_Department"]) : 0;
                this._Serial_Number = Convert.ToString(drPurchasing_Asset["Serial_Number"]);
                this._Model_Number = Convert.ToString(drPurchasing_Asset["Model_Number"]);
                this._Supplier = Convert.ToString(drPurchasing_Asset["Supplier"]);
                this._Acquisition_Date = drPurchasing_Asset["Acquisition_Date"] != DBNull.Value ? Convert.ToDateTime(drPurchasing_Asset["Acquisition_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Useful_Life = drPurchasing_Asset["Useful_Life"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["Useful_Life"]) : 0;
                this._Acquisition_Cost = drPurchasing_Asset["Acquisition_Cost"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["Acquisition_Cost"]) : 0;
                this._FK_LU_Location = drPurchasing_Asset["FK_LU_Location"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["FK_LU_Location"]) : 0;
                this._Notes = Convert.ToString(drPurchasing_Asset["Notes"]);
                this._Updated_By = Convert.ToString(drPurchasing_Asset["Updated_By"]);
                this._Update_Date = drPurchasing_Asset["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drPurchasing_Asset["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }
            else
            {
                this._PK_Purchasing_Asset = -1;
                this._Type = "";
                this._FK_LU_Manufacturer = -1;
                this._FK_LU_Dealership_Department = -1;
                this._Serial_Number = "";
                this._Model_Number = "";
                this._Supplier = "";
                this._Acquisition_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Useful_Life = 0;
                this._Acquisition_Cost = -1;
                this._FK_LU_Location = -1;
                this._Notes = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }
        }

        /// <summary>
        /// set properties
        /// </summary>
        /// <param name="_pK_Purchasing_Service_Contract"></param>
        /// <returns></returns>
        public bool View(int _PK_Purchasing_Asset)
        {
            try
            {
                DataTable dtPurchasing_Asset = Purchasing_AssetSelect(_PK_Purchasing_Asset);
                if (dtPurchasing_Asset != null && dtPurchasing_Asset.Rows.Count > 0)
                {
                    DataRow drPurchasing_Asset = dtPurchasing_Asset.Rows[0];

                    this._PK_Purchasing_Asset = drPurchasing_Asset["PK_Purchasing_Asset"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["PK_Purchasing_Asset"]) : 0;
                    this._Type = Convert.ToString(drPurchasing_Asset["Type"]);
                    this._FK_LU_Manufacturer = drPurchasing_Asset["FK_LU_Manufacturer"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["FK_LU_Manufacturer"]) : 0;
                    this._FK_LU_Dealership_Department = drPurchasing_Asset["FK_LU_Dealership_Department"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["FK_LU_Dealership_Department"]) : 0;
                    this._Serial_Number = Convert.ToString(drPurchasing_Asset["Serial_Number"]);
                    this._Model_Number = Convert.ToString(drPurchasing_Asset["Model_Number"]);
                    this._Supplier = Convert.ToString(drPurchasing_Asset["Supplier"]);
                    this._Acquisition_Date = drPurchasing_Asset["Acquisition_Date"] != DBNull.Value ? Convert.ToDateTime(drPurchasing_Asset["Acquisition_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    this._Useful_Life = drPurchasing_Asset["Useful_Life"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["Useful_Life"]) : 0;
                    this._Acquisition_Cost = drPurchasing_Asset["Acquisition_Cost"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["Acquisition_Cost"]) : 0;
                    this._FK_LU_Location = drPurchasing_Asset["FK_LU_Location"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset["FK_LU_Location"]) : 0;
                    this._Notes = Convert.ToString(drPurchasing_Asset["Notes"]);
                    this._Updated_By = Convert.ToString(drPurchasing_Asset["Updated_By"]);
                    this._Update_Date = drPurchasing_Asset["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drPurchasing_Asset["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;


                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataTable Purchasing_AssetSelect(int pK_Purchasing_Asset)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_AssetSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset", DbType.Decimal, pK_Purchasing_Asset);
            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        /// <summary>
        /// Inserts a record into the Purchasing_Asset table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_AssetInsert");

            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
            db.AddInParameter(dbCommand, "FK_LU_Manufacturer", DbType.Decimal, this._FK_LU_Manufacturer);
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, this._FK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "Serial_Number", DbType.String, this._Serial_Number);
            db.AddInParameter(dbCommand, "Model_Number", DbType.String, this._Model_Number);
            db.AddInParameter(dbCommand, "Supplier", DbType.String, this._Supplier);
            db.AddInParameter(dbCommand, "Acquisition_Date", DbType.DateTime, this._Acquisition_Date);
            db.AddInParameter(dbCommand, "Useful_Life", DbType.Decimal, this._Useful_Life);
            db.AddInParameter(dbCommand, "Acquisition_Cost", DbType.Decimal, this._Acquisition_Cost);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Purchasing_Asset table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Purchasing_Asset)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_AssetSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset", DbType.Decimal, pK_Purchasing_Asset);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Purchasing_Asset table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_AssetSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Purchasing_Asset table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_AssetUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset", DbType.Decimal, this._PK_Purchasing_Asset);
            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
            db.AddInParameter(dbCommand, "FK_LU_Manufacturer", DbType.Decimal, this._FK_LU_Manufacturer);
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, this._FK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "Serial_Number", DbType.String, this._Serial_Number);
            db.AddInParameter(dbCommand, "Model_Number", DbType.String, this._Model_Number);
            db.AddInParameter(dbCommand, "Supplier", DbType.String, this._Supplier);
            db.AddInParameter(dbCommand, "Acquisition_Date", DbType.DateTime, this._Acquisition_Date);
            db.AddInParameter(dbCommand, "Useful_Life", DbType.Decimal, this._Useful_Life);
            db.AddInParameter(dbCommand, "Acquisition_Cost", DbType.Decimal, this._Acquisition_Cost);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_Asset table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_Asset)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_AssetDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset", DbType.Decimal, pK_Purchasing_Asset);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Purchasing_Asset table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll_SC_Assets(decimal FK_Purchasing_Asset, decimal FK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_AssetSelectAll_SC_Asset");
            db.AddInParameter(dbCommand, "FK_Purchasing_Asset", DbType.Decimal, FK_Purchasing_Asset);
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, FK_Purchasing_Service_Contract);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Purchasing_Asset table for Lr Agreement.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll_LR_Assets(decimal FK_Purchasing_Asset, decimal PK_Purchasing_LR_Agreement)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_AssetSelectAll_LR_Asset");
            db.AddInParameter(dbCommand, "FK_Purchasing_Asset", DbType.Decimal, FK_Purchasing_Asset);
            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Agreement", DbType.Decimal, PK_Purchasing_LR_Agreement);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Purchasing_SC_Department table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllByPurchasingAsset(int _FK_Purchasing_Asset)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_DepartmentSelect");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset", DbType.Decimal, _FK_Purchasing_Asset);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Purchasing_Asset table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllByPurchasingAssetLocation(int _FK_Purchasing_Asset)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_LocationSelect");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset", DbType.Decimal, _FK_Purchasing_Asset);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects all records from the Purchasing_Asset table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllByPurchasingAssetManufacturer(int _FK_Purchasing_Asset)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_ManufacturerSelect");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset", DbType.Decimal, _FK_Purchasing_Asset);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataTable Purchasing_LRAggrementSelectByFK(int pK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LR_SelectBy_FKPurchasing_Asset");
            db.AddInParameter(dbCommand, "FK_Purchasing_Asset", DbType.Decimal, pK_Purchasing_Service_Contract);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataTable Purchasing_ServiceContractSelectByFK(int pK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SC_SelectBy_FKPurchasing_Asset");
            db.AddInParameter(dbCommand, "FK_Purchasing_Asset", DbType.Decimal, pK_Purchasing_Service_Contract);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataTable Purchasing_AssetSelectByLocationFK(int pK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_FKASelectAllLocationByPK");
            db.AddInParameter(dbCommand, "PK_Purchasing_Asset", DbType.Decimal, pK_Purchasing_Service_Contract);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataTable Purchasing_Asset_Select_SC(decimal FK_Purchasing_Asset, string SortOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_Select_SC");
            db.AddInParameter(dbCommand, "FK_Purchasing_Asset", DbType.Decimal, FK_Purchasing_Asset);
            db.AddInParameter(dbCommand, "SortOrder", DbType.String, SortOrder);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// select Lr Agreement by id
        /// </summary>
        /// <returns></returns>
        public static DataTable Purchasing_Asset_Select_LR(decimal FK_Purchasing_Asset, string SortOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_Select_LR");
            db.AddInParameter(dbCommand, "FK_Purchasing_Asset", DbType.Decimal, FK_Purchasing_Asset);
            db.AddInParameter(dbCommand, "SortOrder", DbType.String, SortOrder);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }


        /// <summary>
        /// select by serach criteria
        /// </summary>
        /// <returns></returns>
        public static DataSet Purchasing_Asset_Search(Nullable<DateTime> dtStartDateFrom, Nullable<DateTime> dtStartDateTo, string Region, string Market, decimal FK_LU_Location_Id, decimal FK_LU_Dealership_Department,
            string Type, string Manufacturer,string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Assets_Search");
            db.AddInParameter(dbCommand, "dtStartDateFrom", DbType.DateTime, dtStartDateFrom);
            db.AddInParameter(dbCommand, "dtStartDateTo", DbType.DateTime, dtStartDateTo);
            db.AddInParameter(dbCommand, "Region", DbType.String, Region);
            db.AddInParameter(dbCommand, "Market", DbType.String, Market);
            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, FK_LU_Location_Id);
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, FK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "Type", DbType.String, Type);
            db.AddInParameter(dbCommand, "Manufacturer", DbType.String, Manufacturer);          
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Region List
        /// </summary>
        /// <returns></returns>
        public static DataSet GetLocationList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RptPurchasing_Asset_LocationSelect");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Region List
        /// </summary>
        /// <returns></returns>
        public static DataSet GetRegionList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RptPurchasing_Asset_RegionAndLocationSelect");
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Select Manufacturer List
        /// </summary>
        /// <returns></returns>
        public static DataSet GetManufacturerList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RptPurchasing_Asset_ManufacturerSelect");
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Select Type List
        /// </summary>
        /// <returns></returns>
        public static DataSet GetTypeList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RptPurchasing_Asset_TypeSelect");
            return db.ExecuteDataSet(dbCommand);
        }
       // public static DataSet Get_Purchase_Report(int FK_LU_Location_Id,string Type,string strRegion,string Manufacturer)
        public static DataSet Get_Purchase_Report(string strRegion, string strMarket, string Manufacturer, string Type, string Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_Report");

            //db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Int32, FK_LU_Location_Id);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            db.AddInParameter(dbCommand, "Manufacturer", DbType.String, Manufacturer);
            db.AddInParameter(dbCommand, "Type", DbType.String, Type);        
            db.AddInParameter(dbCommand, "Location", DbType.String, Location);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}