using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for PM_Receiving_TSDF table.
    /// </summary>
    public sealed class PM_Receiving_TSDF
    {

        #region Private variables used to hold the property values

        private decimal? _PK_PM_Receiving_TSDF;
        private decimal? _FK_PM_Site_Information;
        private string _Receiving_TSDF_Name;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private decimal? _FK_State;
        private string _Zip_Code;
        private string _Contact_Name;
        private string _Contact_Telephone;
        private string _EPA_ID_Number;
        private string _COI_ON_File;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _Hazardous_Waste_Method;
        private decimal? _FK_LU_HW_Method;
        private string _TDSF_Distance;
        private string _Apply_To_Location;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_PM_Receiving_TSDF value.
        /// </summary>
        public decimal? PK_PM_Receiving_TSDF
        {
            get { return _PK_PM_Receiving_TSDF; }
            set { _PK_PM_Receiving_TSDF = value; }
        }

        /// <summary>
        /// Gets or sets the FK_PM_Site_Information value.
        /// </summary>
        public decimal? FK_PM_Site_Information
        {
            get { return _FK_PM_Site_Information; }
            set { _FK_PM_Site_Information = value; }
        }

        /// <summary>
        /// Gets or sets the Receiving_TSDF_Name value.
        /// </summary>
        public string Receiving_TSDF_Name
        {
            get { return _Receiving_TSDF_Name; }
            set { _Receiving_TSDF_Name = value; }
        }

        public string Hazardous_Waste_Method
        {
            get { return _Hazardous_Waste_Method; }
            set { _Hazardous_Waste_Method = value; }
        }

        /// <summary>
        /// Gets or sets the Address_1 value.
        /// </summary>
        public string Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Address_2 value.
        /// </summary>
        public string Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the City value.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_State value.
        /// </summary>
        public decimal? FK_State
        {
            get { return _FK_State; }
            set { _FK_State = value; }
        }

        /// <summary>
        /// Gets or sets the Zip_Code value.
        /// </summary>
        public string Zip_Code
        {
            get { return _Zip_Code; }
            set { _Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Contact_Name value.
        /// </summary>
        public string Contact_Name
        {
            get { return _Contact_Name; }
            set { _Contact_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Contact_Telephone value.
        /// </summary>
        public string Contact_Telephone
        {
            get { return _Contact_Telephone; }
            set { _Contact_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the EPA_ID_Number value.
        /// </summary>
        public string EPA_ID_Number
        {
            get { return _EPA_ID_Number; }
            set { _EPA_ID_Number = value; }
        }

        /// <summary>
        /// Gets or sets the COI_ON_File value.
        /// </summary>
        public string COI_ON_File
        {
            get { return _COI_ON_File; }
            set { _COI_ON_File = value; }
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

        /// <summary>
        /// _FK_LU_HW_Method
        /// </summary>
        public decimal? FK_LU_HW_Method
        {
            get { return _FK_LU_HW_Method; }
            set { _FK_LU_HW_Method = value; }
        }

        public string TDSF_Distance
        {
            get { return _TDSF_Distance; }
            set { _TDSF_Distance = value; }
        }

        public string Apply_To_Location
        {
            get { return _Apply_To_Location; }
            set { _Apply_To_Location = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsPM_Receiving_TSDF class with default value.
        /// </summary>
        public PM_Receiving_TSDF()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsPM_Receiving_TSDF class based on Primary Key.
        /// </summary>
        public PM_Receiving_TSDF(decimal pK_PM_Receiving_TSDF)
        {
            DataTable dtPM_Receiving_TSDF = SelectByPK(pK_PM_Receiving_TSDF).Tables[0];

            if (dtPM_Receiving_TSDF.Rows.Count == 1)
            {
                SetValue(dtPM_Receiving_TSDF.Rows[0]);
            }
        }


        /// <summary>
        /// Initializes a new instance of the clsPM_Receiving_TSDF class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drPM_Receiving_TSDF)
        {
            if (drPM_Receiving_TSDF["PK_PM_Receiving_TSDF"] == DBNull.Value)
                this._PK_PM_Receiving_TSDF = null;
            else
                this._PK_PM_Receiving_TSDF = (decimal?)drPM_Receiving_TSDF["PK_PM_Receiving_TSDF"];

            if (drPM_Receiving_TSDF["FK_LU_HW_Method"] == DBNull.Value)
                this._FK_LU_HW_Method = null;
            else
                this._FK_LU_HW_Method = (decimal?)drPM_Receiving_TSDF["FK_LU_HW_Method"];

            if (drPM_Receiving_TSDF["FK_PM_Site_Information"] == DBNull.Value)
                this._FK_PM_Site_Information = null;
            else
                this._FK_PM_Site_Information = (decimal?)drPM_Receiving_TSDF["FK_PM_Site_Information"];

            if (drPM_Receiving_TSDF["Receiving_TSDF_Name"] == DBNull.Value)
                this._Receiving_TSDF_Name = null;
            else
                this._Receiving_TSDF_Name = (string)drPM_Receiving_TSDF["Receiving_TSDF_Name"];

            if (drPM_Receiving_TSDF["Address_1"] == DBNull.Value)
                this._Address_1 = null;
            else
                this._Address_1 = (string)drPM_Receiving_TSDF["Address_1"];

            if (drPM_Receiving_TSDF["Address_2"] == DBNull.Value)
                this._Address_2 = null;
            else
                this._Address_2 = (string)drPM_Receiving_TSDF["Address_2"];

            if (drPM_Receiving_TSDF["City"] == DBNull.Value)
                this._City = null;
            else
                this._City = (string)drPM_Receiving_TSDF["City"];

            if (drPM_Receiving_TSDF["FK_State"] == DBNull.Value)
                this._FK_State = null;
            else
                this._FK_State = (decimal?)drPM_Receiving_TSDF["FK_State"];

            if (drPM_Receiving_TSDF["Zip_Code"] == DBNull.Value)
                this._Zip_Code = null;
            else
                this._Zip_Code = (string)drPM_Receiving_TSDF["Zip_Code"];

            if (drPM_Receiving_TSDF["Contact_Name"] == DBNull.Value)
                this._Contact_Name = null;
            else
                this._Contact_Name = (string)drPM_Receiving_TSDF["Contact_Name"];

            if (drPM_Receiving_TSDF["Contact_Telephone"] == DBNull.Value)
                this._Contact_Telephone = null;
            else
                this._Contact_Telephone = (string)drPM_Receiving_TSDF["Contact_Telephone"];

            if (drPM_Receiving_TSDF["EPA_ID_Number"] == DBNull.Value)
                this._EPA_ID_Number = null;
            else
                this._EPA_ID_Number = (string)drPM_Receiving_TSDF["EPA_ID_Number"];

            if (drPM_Receiving_TSDF["COI_ON_File"] == DBNull.Value)
                this._COI_ON_File = null;
            else
                this._COI_ON_File = (string)drPM_Receiving_TSDF["COI_ON_File"];

            if (drPM_Receiving_TSDF["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drPM_Receiving_TSDF["Updated_By"];

            if (drPM_Receiving_TSDF["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drPM_Receiving_TSDF["Update_Date"];

            if (drPM_Receiving_TSDF["Hazardous_Waste_Method"] == DBNull.Value)
                this._Hazardous_Waste_Method = null;
            else
                this._Hazardous_Waste_Method = (string)drPM_Receiving_TSDF["Hazardous_Waste_Method"];

            if (drPM_Receiving_TSDF["TDSF_Distance"] == DBNull.Value)
                this._TDSF_Distance = null;
            else
                this._TDSF_Distance = (string)drPM_Receiving_TSDF["TDSF_Distance"];

            if (drPM_Receiving_TSDF["Apply_To_Location"] == DBNull.Value)
                this._Apply_To_Location = null;
            else
                this._Apply_To_Location = (string)drPM_Receiving_TSDF["Apply_To_Location"];
        }

        #endregion

        /// <summary>
        /// Inserts a record into the PM_Receiving_TSDF table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Receiving_TSDFInsert");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);

            if (string.IsNullOrEmpty(this._Receiving_TSDF_Name))
                db.AddInParameter(dbCommand, "Receiving_TSDF_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Receiving_TSDF_Name", DbType.String, this._Receiving_TSDF_Name);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._Contact_Telephone))
                db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);

            if (string.IsNullOrEmpty(this._EPA_ID_Number))
                db.AddInParameter(dbCommand, "EPA_ID_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EPA_ID_Number", DbType.String, this._EPA_ID_Number);

            if (string.IsNullOrEmpty(this._COI_ON_File))
                db.AddInParameter(dbCommand, "COI_ON_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "COI_ON_File", DbType.String, this._COI_ON_File);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Hazardous_Waste_Method))
                db.AddInParameter(dbCommand, "Hazardous_Waste_Method", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Hazardous_Waste_Method", DbType.String, this._Hazardous_Waste_Method);

            db.AddInParameter(dbCommand, "FK_LU_HW_Method", DbType.Decimal, this._FK_LU_HW_Method);

            if (string.IsNullOrEmpty(this._TDSF_Distance))
                db.AddInParameter(dbCommand, "TDSF_Distance", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TDSF_Distance", DbType.String, this._TDSF_Distance);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the PM_Receiving_TSDF table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_PM_Receiving_TSDF)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Receiving_TSDFSelectByPK");

            db.AddInParameter(dbCommand, "PK_PM_Receiving_TSDF", DbType.Decimal, pK_PM_Receiving_TSDF);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Receiving_TSDFSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the PM_Receiving_TSDF table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Receiving_TSDFSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the PM_Receiving_TSDF table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Receiving_TSDFUpdate");

            db.AddInParameter(dbCommand, "PK_PM_Receiving_TSDF", DbType.Decimal, this._PK_PM_Receiving_TSDF);

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);

            if (string.IsNullOrEmpty(this._Receiving_TSDF_Name))
                db.AddInParameter(dbCommand, "Receiving_TSDF_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Receiving_TSDF_Name", DbType.String, this._Receiving_TSDF_Name);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._Contact_Telephone))
                db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);

            if (string.IsNullOrEmpty(this._EPA_ID_Number))
                db.AddInParameter(dbCommand, "EPA_ID_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EPA_ID_Number", DbType.String, this._EPA_ID_Number);

            if (string.IsNullOrEmpty(this._COI_ON_File))
                db.AddInParameter(dbCommand, "COI_ON_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "COI_ON_File", DbType.String, this._COI_ON_File);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Hazardous_Waste_Method))
                db.AddInParameter(dbCommand, "Hazardous_Waste_Method", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Hazardous_Waste_Method", DbType.String, this._Hazardous_Waste_Method);

            db.AddInParameter(dbCommand, "FK_LU_HW_Method", DbType.Decimal, this._FK_LU_HW_Method);

            if (string.IsNullOrEmpty(this._TDSF_Distance))
                db.AddInParameter(dbCommand, "TDSF_Distance", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TDSF_Distance", DbType.String, this._TDSF_Distance);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the PM_Receiving_TSDF table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_PM_Receiving_TSDF)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Receiving_TSDFDeleteByPK");

            db.AddInParameter(dbCommand, "PK_PM_Receiving_TSDF", DbType.Decimal, pK_PM_Receiving_TSDF);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Receiving_TSDF)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Receiving_TSDF_AuditView");

            db.AddInParameter(dbCommand, "pK_PM_Receiving_TSDF", DbType.Decimal, pK_PM_Receiving_TSDF);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
