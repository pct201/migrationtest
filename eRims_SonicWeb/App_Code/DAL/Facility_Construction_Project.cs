using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table Facility_Construction_Project
    /// </summary>
    public sealed class Facility_Construction_Project
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Facility_construction_Project;
        private string _Project_Number;
        private decimal? _FK_Location;
        private decimal? _FK_LU_Facility_Project_Type;
        private DateTime? _Estimated_Start_Date;
        private DateTime? _Estimated_Completion_Date;
        private string _Project_Description;
        private string _Type_Description;
        private string _Building_Number;
        private string _UpdatedBy;
        private DateTime? _UpdatedDate;
        private string _Sonic_Location_Code;
        private string _Title;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Facility_construction_Project value.
        /// </summary>
        public decimal? PK_Facility_construction_Project
        {
            get { return _PK_Facility_construction_Project; }
            set { _PK_Facility_construction_Project = value; }
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
        /// Gets or sets the FK_Location value.
        /// </summary>
        public decimal? FK_Location
        {
            get { return _FK_Location; }
            set { _FK_Location = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Facility_Project_Type value.
        /// </summary>
        public decimal? FK_LU_Facility_Project_Type
        {
            get { return _FK_LU_Facility_Project_Type; }
            set { _FK_LU_Facility_Project_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Estimated_Start_Date value.
        /// </summary>
        public DateTime? Estimated_Start_Date
        {
            get { return _Estimated_Start_Date; }
            set { _Estimated_Start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Estimated_Completion_Date value.
        /// </summary>
        public DateTime? Estimated_Completion_Date
        {
            get { return _Estimated_Completion_Date; }
            set { _Estimated_Completion_Date = value; }
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
        /// Gets or sets the Project_Type_Description value.
        /// </summary>
        public string Type_Description
        {
            get { return _Type_Description; }
            set { _Type_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Building_Number value.
        /// </summary>
        public string Building_Number
        {
            get { return _Building_Number; }
            set { _Building_Number = value; }
        }

        /// <summary>
        /// Gets or sets the UpdatedBy value.
        /// </summary>
        public string UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }

        /// <summary>
        /// Gets or sets the UpdatedDate value.
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }

        /// <summary>
        /// Gets or Sets Sonic_Location_Code Value
        /// </summary>
        public string Sonic_Location_Code
        {
            get { return _Sonic_Location_Code; }
            set { _Sonic_Location_Code = value; }
        }

        /// <summary>
        /// Gets or Sets Project_Title Value
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Project class with default value.
        /// </summary>
        public Facility_Construction_Project()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Project class based on Primary Key.
        /// </summary>
        public Facility_Construction_Project(decimal pK_Facility_construction_Project)
        {
            DataTable dtFacility_Construction_Project = Select(pK_Facility_construction_Project).Tables[0];

            if (dtFacility_Construction_Project.Rows.Count == 1)
            {
                SetValue(dtFacility_Construction_Project.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Project class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drFacility_Construction_Project)
        {
            if (drFacility_Construction_Project["PK_Facility_construction_Project"] == DBNull.Value)
                this._PK_Facility_construction_Project = null;
            else
                this._PK_Facility_construction_Project = (decimal?)drFacility_Construction_Project["PK_Facility_construction_Project"];

            if (drFacility_Construction_Project["Project_Number"] == DBNull.Value)
                this._Project_Number = null;
            else
                this._Project_Number = (string)drFacility_Construction_Project["Project_Number"];

            if (drFacility_Construction_Project["FK_Location"] == DBNull.Value)
                this._FK_Location = null;
            else
                this._FK_Location = (decimal?)drFacility_Construction_Project["FK_Location"];

            if (drFacility_Construction_Project["FK_LU_Facility_Project_Type"] == DBNull.Value)
                this._FK_LU_Facility_Project_Type = null;
            else
                this._FK_LU_Facility_Project_Type = (decimal?)drFacility_Construction_Project["FK_LU_Facility_Project_Type"];

            if (drFacility_Construction_Project["Estimated_Start_Date"] == DBNull.Value)
                this._Estimated_Start_Date = null;
            else
                this._Estimated_Start_Date = (DateTime?)drFacility_Construction_Project["Estimated_Start_Date"];

            if (drFacility_Construction_Project["Estimated_Completion_Date"] == DBNull.Value)
                this._Estimated_Completion_Date = null;
            else
                this._Estimated_Completion_Date = (DateTime?)drFacility_Construction_Project["Estimated_Completion_Date"];

            if (drFacility_Construction_Project["Project_Description"] == DBNull.Value)
                this._Project_Description = null;
            else
                this._Project_Description = (string)drFacility_Construction_Project["Project_Description"];

            if (drFacility_Construction_Project["UpdatedBy"] == DBNull.Value)
                this._UpdatedBy = null;
            else
                this._UpdatedBy = (string)drFacility_Construction_Project["UpdatedBy"];

            if (drFacility_Construction_Project["UpdatedDate"] == DBNull.Value)
                this._UpdatedDate = null;
            else
                this._UpdatedDate = (DateTime?)drFacility_Construction_Project["UpdatedDate"];

            if (drFacility_Construction_Project["Title"] == DBNull.Value)
                this._Title = null;
            else
                this._Title = Convert.ToString(drFacility_Construction_Project["Title"]);
        }

        #endregion

        /// <summary>
        /// Inserts a record into the Facility_Construction_Project table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_ProjectInsert");


            if (string.IsNullOrEmpty(this._Project_Number))
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, this._Project_Number);

            db.AddInParameter(dbCommand, "FK_Location", DbType.Decimal, this._FK_Location);

            db.AddInParameter(dbCommand, "FK_LU_Facility_Project_Type", DbType.Decimal, this._FK_LU_Facility_Project_Type);

            db.AddInParameter(dbCommand, "Estimated_Start_Date", DbType.DateTime, this._Estimated_Start_Date);

            db.AddInParameter(dbCommand, "Estimated_Completion_Date", DbType.DateTime, this._Estimated_Completion_Date);

            if (string.IsNullOrEmpty(this._Project_Description))
                db.AddInParameter(dbCommand, "Project_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Project_Description", DbType.String, this._Project_Description);

            db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, this._UpdatedBy);

            db.AddInParameter(dbCommand, "UpdatedDate", DbType.DateTime, this._UpdatedDate);

            if (string.IsNullOrEmpty(this._Title))
                db.AddInParameter(dbCommand, "Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Title", DbType.String, this._Title);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Facility_Construction_Project table.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet Select(decimal pK_Facility_construction_Project)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_ProjectSelect");

            db.AddInParameter(dbCommand, "PK_Facility_construction_Project", DbType.Decimal, pK_Facility_construction_Project);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Facility_Construction_Project table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_ProjectSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Facility_Construction_Project table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_ProjectUpdate");


            db.AddInParameter(dbCommand, "PK_Facility_construction_Project", DbType.Decimal, this._PK_Facility_construction_Project);

            if (string.IsNullOrEmpty(this._Project_Number))
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, this._Project_Number);

            db.AddInParameter(dbCommand, "FK_Location", DbType.Decimal, this._FK_Location);

            db.AddInParameter(dbCommand, "FK_LU_Facility_Project_Type", DbType.Decimal, this._FK_LU_Facility_Project_Type);

            db.AddInParameter(dbCommand, "Estimated_Start_Date", DbType.DateTime, this._Estimated_Start_Date);

            db.AddInParameter(dbCommand, "Estimated_Completion_Date", DbType.DateTime, this._Estimated_Completion_Date);

            if (string.IsNullOrEmpty(this._Project_Description))
                db.AddInParameter(dbCommand, "Project_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Project_Description", DbType.String, this._Project_Description);

            if (string.IsNullOrEmpty(this._Title))
                db.AddInParameter(dbCommand, "Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Title", DbType.String, this._Title);

            db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, this._UpdatedBy);

            db.AddInParameter(dbCommand, "UpdatedDate", DbType.DateTime, this._UpdatedDate);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Facility_Construction_Project table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pK_Facility_construction_Project)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_ProjectDelete");

            db.AddInParameter(dbCommand, "PK_Facility_construction_Project", DbType.Decimal, pK_Facility_construction_Project);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Select records from the Facility Construction table by a Location Id.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectConstructionProjectsByLoction(decimal FK_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectConstructionProjectsByLoction");

            db.AddInParameter(dbCommand, "FK_Location", DbType.Decimal, FK_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select records from the Facility Construction table by a Location Id.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectConstructionProjectsAudit(decimal PK_Facility_construction_Project)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectConstructionProjectsAudit");

            db.AddInParameter(dbCommand, "PK_Facility_construction_Project", DbType.Decimal, PK_Facility_construction_Project);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all Facility Construction Project By Location Id
        /// </summary>
        /// <param name="fk_location"></param>
        /// <returns></returns>
        public static DataSet SelectFacilityConstructionProjectByLocation(decimal fk_location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_ProjectSelectByLocation");
            db.AddInParameter(dbCommand, "FK_Location", DbType.Decimal, fk_location);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Gets Facility Construction Search Result By Search Values
        /// </summary>
        /// <param name="strLocationId"></param>
        /// <param name="strProjectNumberId"></param>
        /// <param name="strAssignedById"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strAssignedToId"></param>
        /// <param name="strCompletedBy"></param>
        /// <param name="strStatus"></param>
        /// <param name="strActionItemType"></param>
        /// <param name="strDateDueFrom"></param>
        /// <param name="strDateDueTo"></param>
        /// <param name="strDateAssignedFrom"></param>
        /// <param name="strDateAssignedTo"></param>
        /// <param name="strDateCompletedFrom"></param>
        /// <param name="strDateCompletedTo"></param>
        /// <returns></returns>
        public static DataSet GetFacilityConstructionSearchResult(string strLocationId, string strProjectNumberId, string strAssignedById, string strOrderBy, int intPageNo, int intPageSize,
                        string strAssignedToId, string strCompletedBy, string strStatus, string strActionItemType, string strDateDueFrom, string strDateDueTo,
                        string strDateAssignedFrom, string strDateAssignedTo, string strDateCompletedFrom, string strDateCompletedTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Action_ItemsSearch");

            db.AddInParameter(dbCommand, "LocationID", DbType.String, strLocationId);
            db.AddInParameter(dbCommand, "@ProjectNumberID", DbType.String, strProjectNumberId);
            db.AddInParameter(dbCommand, "@AssignedByID", DbType.String, strAssignedById);
            db.AddInParameter(dbCommand, "@AssignedToID", DbType.String, strAssignedToId);
            db.AddInParameter(dbCommand, "@CompletedBy", DbType.String, strCompletedBy);
            db.AddInParameter(dbCommand, "@ActionItemType", DbType.String, strActionItemType);
            db.AddInParameter(dbCommand, "@DateDueFrom", DbType.String, strDateDueFrom);
            db.AddInParameter(dbCommand, "@DateDueTo", DbType.String, strDateDueTo);
            db.AddInParameter(dbCommand, "@DateAssignedFrom", DbType.String, strDateAssignedFrom);
            db.AddInParameter(dbCommand, "@DateAssignedTo", DbType.String, strDateAssignedTo);
            db.AddInParameter(dbCommand, "@DateCompletedFrom", DbType.String, strDateCompletedFrom);
            db.AddInParameter(dbCommand, "@DateCompletedTo", DbType.String, strDateCompletedTo);
            db.AddInParameter(dbCommand, "@Status", DbType.String, strStatus);
            db.AddInParameter(dbCommand, "@PageSize", DbType.Int32, intPageSize);
            db.AddInParameter(dbCommand, "@PageNumber", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "@OrderBy", DbType.String, strOrderBy);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}
