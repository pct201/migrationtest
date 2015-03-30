using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Identification table.
    /// </summary>
    public sealed class clsEPM_Identification
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Identification;
        private decimal? _FK_LU_Location_Id;
        private decimal? _FK_EPM_Identification;
        private string _Project_Number;
        private decimal? _FK_LU_EPM_Project_Type;
        private string _Project_Description;
        private decimal? _FK_LU_EPM_Requesting_Entity;
        private string _Other_Requesting_Entity;
        private string _Other_Target_Area;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _Other_PurposeOfProject;

        private string _Person_Requesting_Work;
        private string _Title_of_Person_Requesting_Work;

        private string _Site_Contact_Name;
        private string _Site_Contact_Telephone;
        private string _Site_Contact_Email;      
        
        
        
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Identification value.
        /// </summary>
        public decimal? PK_EPM_Identification
        {
            get { return _PK_EPM_Identification; }
            set { _PK_EPM_Identification = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location_Id value.
        /// </summary>
        public decimal? FK_LU_Location_Id
        {
            get { return _FK_LU_Location_Id; }
            set { _FK_LU_Location_Id = value; }
        }

        /// <summary>
        /// Gets or sets the FK_EPM_Identification value.
        /// </summary>
        public decimal? FK_EPM_Identification
        {
            get { return _FK_EPM_Identification; }
            set { _FK_EPM_Identification = value; }
        }

        /// <summary>
        /// Gets or sets the Project_Number value.
        /// </summary>
        public string Project_Number
        {
            get { return _Project_Number; }
            set { _Project_Number = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_EPM_Project_Type value.
        /// </summary>
        public decimal? FK_LU_EPM_Project_Type
        {
            get { return _FK_LU_EPM_Project_Type; }
            set { _FK_LU_EPM_Project_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Project_Description value.
        /// </summary>
        public string Project_Description
        {
            get { return _Project_Description; }
            set { _Project_Description = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_EPM_Requesting_Entity value.
        /// </summary>
        public decimal? FK_LU_EPM_Requesting_Entity
        {
            get { return _FK_LU_EPM_Requesting_Entity; }
            set { _FK_LU_EPM_Requesting_Entity = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Requesting_Entity value.
        /// </summary>
        public string Other_Requesting_Entity
        {
            get { return _Other_Requesting_Entity; }
            set { _Other_Requesting_Entity = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Target_Area value.
        /// </summary>
        public string Other_Target_Area
        {
            get { return _Other_Target_Area; }
            set { _Other_Target_Area = value; }
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
        /// Gets or sets the Other_PurposeOfProject value.
        /// </summary>
        public string Other_PurposeOfProject
        {
            get { return _Other_PurposeOfProject; }
            set { _Other_PurposeOfProject = value; }
        }

        /// <summary>
        /// Gets or sets the Person_Requesting_Work value.
        /// </summary>
        public string Person_Requesting_Work
        {
            get { return _Person_Requesting_Work; }
            set { _Person_Requesting_Work = value; }
        }

        /// <summary>
        /// Gets or sets the Title_of_Person_Requesting_Work value.
        /// </summary>
        public string Title_of_Person_Requesting_Work
        {
            get { return _Title_of_Person_Requesting_Work; }
            set { _Title_of_Person_Requesting_Work = value; }
        }

        public string Site_Contact_Name
        {
            get { return _Site_Contact_Name; }
            set { _Site_Contact_Name = value; }
        }


        public string Site_Contact_Telephone
        {
            get { return _Site_Contact_Telephone; }
            set { _Site_Contact_Telephone = value; }
        }



        public string Site_Contact_Email
        {
            get { return _Site_Contact_Email; }
            set { _Site_Contact_Email = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Identification class with default value.
        /// </summary>
        public clsEPM_Identification()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Identification class based on Primary Key.
        /// </summary>
        public clsEPM_Identification(decimal pK_EPM_Identification)
        {
            DataTable dtEPM_Identification = SelectByPK(pK_EPM_Identification).Tables[0];

            if (dtEPM_Identification.Rows.Count == 1)
            {
                SetValue(dtEPM_Identification.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_Identification class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Identification)
        {
            if (drEPM_Identification["PK_EPM_Identification"] == DBNull.Value)
                this._PK_EPM_Identification = null;
            else
                this._PK_EPM_Identification = (decimal?)drEPM_Identification["PK_EPM_Identification"];

            if (drEPM_Identification["FK_LU_Location_Id"] == DBNull.Value)
                this._FK_LU_Location_Id = null;
            else
                this._FK_LU_Location_Id = (decimal?)drEPM_Identification["FK_LU_Location_Id"];

            if (drEPM_Identification["FK_EPM_Identification"] == DBNull.Value)
                this._FK_EPM_Identification = null;
            else
                this._FK_EPM_Identification = (decimal?)drEPM_Identification["FK_EPM_Identification"];

            if (drEPM_Identification["Project_Number"] == DBNull.Value)
                this._Project_Number = null;
            else
                this._Project_Number = (string)drEPM_Identification["Project_Number"];

            if (drEPM_Identification["FK_LU_EPM_Project_Type"] == DBNull.Value)
                this._FK_LU_EPM_Project_Type = null;
            else
                this._FK_LU_EPM_Project_Type = (decimal?)drEPM_Identification["FK_LU_EPM_Project_Type"];

            if (drEPM_Identification["Project_Description"] == DBNull.Value)
                this._Project_Description = null;
            else
                this._Project_Description = (string)drEPM_Identification["Project_Description"];

            if (drEPM_Identification["FK_LU_EPM_Requesting_Entity"] == DBNull.Value)
                this._FK_LU_EPM_Requesting_Entity = null;
            else
                this._FK_LU_EPM_Requesting_Entity = (decimal?)drEPM_Identification["FK_LU_EPM_Requesting_Entity"];

            if (drEPM_Identification["Other_Requesting_Entity"] == DBNull.Value)
                this._Other_Requesting_Entity = null;
            else
                this._Other_Requesting_Entity = (string)drEPM_Identification["Other_Requesting_Entity"];

            if (drEPM_Identification["Other_Target_Area"] == DBNull.Value)
                this._Other_Target_Area = null;
            else
                this._Other_Target_Area = (string)drEPM_Identification["Other_Target_Area"];

            if (drEPM_Identification["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Identification["Updated_By"];

            if (drEPM_Identification["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Identification["Update_Date"];

            if (drEPM_Identification["Other_PurposeOfProject"] == DBNull.Value)
                this._Other_PurposeOfProject = null;
            else
                this._Other_PurposeOfProject = (string)drEPM_Identification["Other_PurposeOfProject"];

            if (drEPM_Identification["Person_Requesting_Work"] == DBNull.Value)
                this._Person_Requesting_Work = null;
            else
                this._Person_Requesting_Work = (string)drEPM_Identification["Person_Requesting_Work"];

            if (drEPM_Identification["Title_of_Person_Requesting_Work"] == DBNull.Value)
                this._Title_of_Person_Requesting_Work = null;
            else
                this._Title_of_Person_Requesting_Work = (string)drEPM_Identification["Title_of_Person_Requesting_Work"];

            if (drEPM_Identification["Title_of_Person_Requesting_Work"] == DBNull.Value)
                this._Title_of_Person_Requesting_Work = null;
            else
                this._Title_of_Person_Requesting_Work = (string)drEPM_Identification["Title_of_Person_Requesting_Work"];

            if (drEPM_Identification["Title_of_Person_Requesting_Work"] == DBNull.Value)
                this._Title_of_Person_Requesting_Work = null;
            else
                this._Title_of_Person_Requesting_Work = (string)drEPM_Identification["Title_of_Person_Requesting_Work"];

            if (drEPM_Identification["Site_Contact_Name"] == DBNull.Value)
                this._Site_Contact_Name = null;
            else
                this._Site_Contact_Name = (string)drEPM_Identification["Site_Contact_Name"];

            if (drEPM_Identification["Site_Contact_Telephone"] == DBNull.Value)
                this._Site_Contact_Telephone = null;
            else
                this._Site_Contact_Telephone = (string)drEPM_Identification["Site_Contact_Telephone"];

            if (drEPM_Identification["Site_Contact_Email"] == DBNull.Value)
                this._Site_Contact_Email = null;
            else
                this._Site_Contact_Email = (string)drEPM_Identification["Site_Contact_Email"];

        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Identification table.
        /// </summary>
        /// <returns></returns>
        public decimal Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_IdentificationInsert");

            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, this._PK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, this._FK_LU_Location_Id);

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            //if (string.IsNullOrEmpty(this._Project_Number))
            //    db.AddInParameter(dbCommand, "Project_Number", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Project_Number", DbType.String, this._Project_Number);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Project_Type", DbType.Decimal, this._FK_LU_EPM_Project_Type);

            if (string.IsNullOrEmpty(this._Project_Description))
                db.AddInParameter(dbCommand, "Project_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Project_Description", DbType.String, this._Project_Description);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Requesting_Entity", DbType.Decimal, this._FK_LU_EPM_Requesting_Entity);

            if (string.IsNullOrEmpty(this._Other_Requesting_Entity))
                db.AddInParameter(dbCommand, "Other_Requesting_Entity", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Requesting_Entity", DbType.String, this._Other_Requesting_Entity);

            if (string.IsNullOrEmpty(this._Other_Target_Area))
                db.AddInParameter(dbCommand, "Other_Target_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Target_Area", DbType.String, this._Other_Target_Area);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Other_PurposeOfProject))
                db.AddInParameter(dbCommand, "Other_PurposeOfProject", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_PurposeOfProject", DbType.String, this._Other_PurposeOfProject);

            if (string.IsNullOrEmpty(this._Person_Requesting_Work))
                db.AddInParameter(dbCommand, "Person_Requesting_Work", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Person_Requesting_Work", DbType.String, this._Person_Requesting_Work);

            if (string.IsNullOrEmpty(this._Title_of_Person_Requesting_Work))
                db.AddInParameter(dbCommand, "Title_of_Person_Requesting_Work", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Title_of_Person_Requesting_Work", DbType.String, this._Title_of_Person_Requesting_Work);

            if (string.IsNullOrEmpty(this._Site_Contact_Name))
                db.AddInParameter(dbCommand, "Site_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Site_Contact_Name", DbType.String, this._Site_Contact_Name);

            if (string.IsNullOrEmpty(this._Site_Contact_Telephone))
                db.AddInParameter(dbCommand, "Site_Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Site_Contact_Telephone", DbType.String, this._Site_Contact_Telephone);

            if (string.IsNullOrEmpty(this._Site_Contact_Email))
                db.AddInParameter(dbCommand, "Site_Contact_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Site_Contact_Email", DbType.String, this._Site_Contact_Email);


            // Execute the query and return the new identity value
            decimal returnValue = Convert.ToDecimal(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the EPM_Identification table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_IdentificationSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, pK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Identification table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(decimal Fk_LU_Location, int intPageNo, int intPageSize, string strOrder, string strOrderBy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_IdentificationSelectAll");

            db.AddInParameter(dbCommand, "Fk_LU_Location", DbType.Decimal, Fk_LU_Location);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Identification table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_IdentificationUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, this._PK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, this._FK_LU_Location_Id);

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            if (string.IsNullOrEmpty(this._Project_Number))
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, this._Project_Number);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Project_Type", DbType.Decimal, this._FK_LU_EPM_Project_Type);

            if (string.IsNullOrEmpty(this._Project_Description))
                db.AddInParameter(dbCommand, "Project_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Project_Description", DbType.String, this._Project_Description);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Requesting_Entity", DbType.Decimal, this._FK_LU_EPM_Requesting_Entity);

            if (string.IsNullOrEmpty(this._Other_Requesting_Entity))
                db.AddInParameter(dbCommand, "Other_Requesting_Entity", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Requesting_Entity", DbType.String, this._Other_Requesting_Entity);

            if (string.IsNullOrEmpty(this._Other_Target_Area))
                db.AddInParameter(dbCommand, "Other_Target_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Target_Area", DbType.String, this._Other_Target_Area);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Other_PurposeOfProject))
                db.AddInParameter(dbCommand, "Other_PurposeOfProject", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_PurposeOfProject", DbType.String, this._Other_PurposeOfProject);

            if (string.IsNullOrEmpty(this._Person_Requesting_Work))
                db.AddInParameter(dbCommand, "Person_Requesting_Work", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Person_Requesting_Work", DbType.String, this._Person_Requesting_Work);

            if (string.IsNullOrEmpty(this._Title_of_Person_Requesting_Work))
                db.AddInParameter(dbCommand, "Title_of_Person_Requesting_Work", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Title_of_Person_Requesting_Work", DbType.String, this._Title_of_Person_Requesting_Work);

            if (string.IsNullOrEmpty(this._Site_Contact_Name))
                db.AddInParameter(dbCommand, "Site_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Site_Contact_Name", DbType.String, this._Site_Contact_Name);

            if (string.IsNullOrEmpty(this._Site_Contact_Telephone))
                db.AddInParameter(dbCommand, "Site_Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Site_Contact_Telephone", DbType.String, this._Site_Contact_Telephone);

            if (string.IsNullOrEmpty(this._Site_Contact_Email))
                db.AddInParameter(dbCommand, "Site_Contact_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Site_Contact_Email", DbType.String, this._Site_Contact_Email);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the EPM_Identification table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_IdentificationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, pK_EPM_Identification);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Identification table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectCompanionToProject(decimal FK_Location_ID, decimal PK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_IdentificationCompanionProjectByLocation");

            db.AddInParameter(dbCommand, "FK_Location_ID", DbType.Decimal, FK_Location_ID);
            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, PK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Identification table by a foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_IdentificationSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Data For Scheduler By passed Location Id
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetEPMSchedule(int intMonth, int intYear, decimal LocationID, decimal PK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ProjectManagements_Schedule");

            db.AddInParameter(dbCommand, "Month", DbType.Int32, intMonth);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "LocationID", DbType.Decimal, LocationID);
            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, PK_EPM_Identification);


            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Get Project Number and project Type by Location Id and PK_EPM_Identification
        /// </summary>
        /// <param name="FK_LU_Location_Id"></param>
        /// <param name="PK_EPM_Identification"></param>
        /// <returns></returns>
        public static DataSet GetProjectNumber(decimal FK_LU_Location_Id, decimal PK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_IdentificationGetProjectNum");

            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, FK_LU_Location_Id);
            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, PK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Data For Scheduler By passed Location Id
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetEPMScheduleByLocation(int intMonth, int intYear, string LocationID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ProjectManagements_ScheduleByLocation");

            db.AddInParameter(dbCommand, "Month", DbType.Int32, intMonth);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "LocationID", DbType.String, LocationID);

            return db.ExecuteDataSet(dbCommand);
        }

        ///// <summary>
        ///// Get Data For Scheduler By passed Regoin
        ///// </summary>
        ///// <returns>DataSet</returns>
        //public static DataSet GetEPMScheduleByRegion(int intMonth, int intYear, string Region)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("ProjectManagements_ScheduleByRegion");

        //    db.AddInParameter(dbCommand, "Month", DbType.Int32, intMonth);
        //    db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
        //    db.AddInParameter(dbCommand, "Region", DbType.String, Region);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        /// <summary>
        /// Get Pk of PM_Site_Information For Insert data in PM_Attachment from Attachment
        /// </summary>
        /// <param name="FK_Building"></param>
        /// <returns></returns>
        public static DataSet GetPK_PM_SiteInfoForIdentification(string FK_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetPK_PM_SiteInfoForIdentification");

            db.AddInParameter(dbCommand, "FK_Building", DbType.String, FK_Building);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}
