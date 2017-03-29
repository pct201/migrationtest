using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table Contractor_Job_Security
	/// </summary>
	public sealed class Contractor_Job_Security
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Contractor_Job_Security;
		private decimal? _FK_Contractor_Security;
		private decimal? _FK_Facility_Construction_Project;
        private decimal? _FK_LU_Location_ID;
		private string _Access;
        private string _Project_Number;
        private decimal? _LU_Location_ID;
        private string _Locationdba;
        private DateTime? _Estimated_Start_Date;
        private string _Project_Description;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Contractor_Job_Security value.
		/// </summary>
		public decimal? PK_Contractor_Job_Security
		{
			get { return _PK_Contractor_Job_Security; }
			set { _PK_Contractor_Job_Security = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Contractor_Security value.
		/// </summary>
		public decimal? FK_Contractor_Security
		{
			get { return _FK_Contractor_Security; }
			set { _FK_Contractor_Security = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Facility_Construction_Project value.
		/// </summary>
		public decimal? FK_Facility_Construction_Project
		{
			get { return _FK_Facility_Construction_Project; }
			set { _FK_Facility_Construction_Project = value; }
		}

        /// <summary>
        /// Gets or sets the FK_Facility_Construction_Project value.
        /// </summary>
        public decimal? FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }

		/// <summary>
		/// Gets or sets the Access value.
		/// </summary>
		public string Access
		{
			get { return _Access; }
			set { _Access = value; }
		}
                
        ///<summary>
        /// Gets or sets the Project Number value.
        ///</summary>
        public string Project_Number
        {
            get { return _Project_Number; }
            set { _Project_Number = value; }
        }
        
        ///<summary>
        /// Gets or sets the Estimated Start Date value.
        ///</summary>
        public DateTime? Estimated_Start_Date
        {
            get { return _Estimated_Start_Date; }
            set { _Estimated_Start_Date = value; }
        }
        ///<summary>
        /// Gets or sets the Project Description value.
        ///</summary>
        public string Project_Description
        {
            get { return _Project_Description; }
            set { _Project_Description = value; }
        }
        ///<summary>
        /// Gets or sets the Project Description value.
        ///</summary>
        public decimal? LU_Location_ID
        {
            get { return _LU_Location_ID; }
            set { _LU_Location_ID = value; }
        }
        ///<summary>
        /// Gets or sets the Locationdba value.
        ///</summary>
        public string Locationdba
        {
            get { return _Locationdba; }
            set { _Locationdba = value; }
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
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Contractor_Job_Security class with default value.
		/// </summary>
		public Contractor_Job_Security() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Contractor_Job_Security class based on Primary Key.
		/// </summary>
		public Contractor_Job_Security(decimal pK_Contractor_Job_Security) 
		{
			DataTable dtContractor_Job_Security = Select(pK_Contractor_Job_Security).Tables[0];

			if (dtContractor_Job_Security.Rows.Count == 1)
			{
				 SetValue(dtContractor_Job_Security.Rows[0]);

			}

		}

        ///// <summary>
        ///// Initializes a new instance of the Contractor_Job_Security class based on Primary Key And Contracor_Security Primary key.
        ///// </summary>
        //public Contractor_Job_Security(decimal fK_Contractor_Security, decimal fk_Facility_Construction_Project)
        //{
        //    DataTable dtContractor_Job_Security = SelectByFK(fK_Contractor_Security, fk_Facility_Construction_Project).Tables[0];

        //    if (dtContractor_Job_Security.Rows.Count == 1)
        //    {
        //        SetValue(dtContractor_Job_Security.Rows[0]);

        //    }

        //}


		/// <summary>
		/// Initializes a new instance of the Contractor_Job_Security class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drContractor_Job_Security) 
		{
				if (drContractor_Job_Security["PK_Contractor_Job_Security"] == DBNull.Value)
					this._PK_Contractor_Job_Security = null;
				else
					this._PK_Contractor_Job_Security = (decimal?)drContractor_Job_Security["PK_Contractor_Job_Security"];

				if (drContractor_Job_Security["FK_Contractor_Security"] == DBNull.Value)
					this._FK_Contractor_Security = null;
				else
					this._FK_Contractor_Security = (decimal?)drContractor_Job_Security["FK_Contractor_Security"];

				if (drContractor_Job_Security["FK_Facility_Construction_Project"] == DBNull.Value)
					this._FK_Facility_Construction_Project = null;
				else
					this._FK_Facility_Construction_Project = (decimal?)drContractor_Job_Security["FK_Facility_Construction_Project"];

                if (drContractor_Job_Security["Project_Number"] == DBNull.Value)
                    this._Project_Number = null;
                else
                    this._Project_Number = (string)drContractor_Job_Security["Project_Number"];

                if (drContractor_Job_Security["Project_Description"] == DBNull.Value)
                    this._Project_Description = null;
                else
                    this._Project_Description = (string)drContractor_Job_Security["Project_Description"];

                if (drContractor_Job_Security["Estimated_Start_Date"] == DBNull.Value)
                    this._Estimated_Start_Date = null;
                else
                    this._Estimated_Start_Date = (DateTime?)drContractor_Job_Security["Estimated_Start_Date"];

                if (drContractor_Job_Security["PK_LU_Location_ID"] == DBNull.Value)
                    this._LU_Location_ID = null;
                else
                    this._LU_Location_ID = (decimal?)drContractor_Job_Security["PK_LU_Location_ID"];

                if (drContractor_Job_Security["dba"] == DBNull.Value)
                    this._Locationdba = null;
                else
                    this._Locationdba = (string)drContractor_Job_Security["dba"];


				if (drContractor_Job_Security["Access"] == DBNull.Value)
					this._Access = null;
				else
					this._Access = (string)drContractor_Job_Security["Access"];

                
				if (drContractor_Job_Security["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drContractor_Job_Security["Update_Date"];

				if (drContractor_Job_Security["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drContractor_Job_Security["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Contractor_Job_Security table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Contractor_Job_SecurityInsert");

			
			db.AddInParameter(dbCommand, "FK_Contractor_Security", DbType.Decimal, this._FK_Contractor_Security);

            if (this._FK_Facility_Construction_Project==null)
                db.AddInParameter(dbCommand, "FK_Facility_Construction_Project", DbType.Decimal, DBNull.Value);
            else
			    db.AddInParameter(dbCommand, "FK_Facility_Construction_Project", DbType.Decimal, this._FK_Facility_Construction_Project);

            if (this._FK_LU_Location_ID == null)
                db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			
			if (string.IsNullOrEmpty(this._Access))
				db.AddInParameter(dbCommand, "Access", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Access", DbType.String, this._Access);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Contractor_Job_Security table.
		/// </summary>
		/// <returns>DataSet</returns>
        public DataSet Select(decimal pK_Contractor_Job_Security)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_Job_SecuritySelectBYPK");

			db.AddInParameter(dbCommand, "PK_Contractor_Job_Security", DbType.Decimal, pK_Contractor_Job_Security);

			return db.ExecuteDataSet(dbCommand);
		}

        ///// <summary>
        ///// Selects a single record from the Contractor_Job_Security table.
        ///// </summary>
        ///// <returns>DataSet</returns>
        //public DataSet SelectByFK(decimal fK_Contractor_Security,decimal FK_Facility_Construction_Project)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("Contractor_Job_SecuritySelectBYPKFK");

        //    db.AddInParameter(dbCommand, "FK_Facility_Construction_Project", DbType.Decimal, FK_Facility_Construction_Project);
        //    db.AddInParameter(dbCommand, "FK_Contractor_Security", DbType.Decimal, fK_Contractor_Security);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        /// <summary>
        /// Selects a single record from the Facility_construction_Project table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByProjectNoFacility_construction_Project(decimal PK_Facility_construction_Project)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_ProjectSelect");

            db.AddInParameter(dbCommand, "PK_Facility_construction_Project", DbType.Decimal, PK_Facility_construction_Project);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects list of project which not access to user from Facility_construction_Project table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByProjectNotAccess(decimal PK_Contractor_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_ProjectSelectNotAccess");

            db.AddInParameter(dbCommand, "PK_Contractor_Security", DbType.Decimal, PK_Contractor_Security);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects list of project which not access to user from Facility_construction_Project table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByLocationNotAccess(decimal PK_Contractor_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectNotAccess");

            db.AddInParameter(dbCommand, "PK_Contractor_Security", DbType.Decimal, PK_Contractor_Security);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Contractor_Job_Security table by FK_Contactor_Security.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFKContactorSecurity(decimal FK_Contactor_Security, string orderBy, string direction)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_Job_SecuritySelectByFKCS");

            db.AddInParameter(dbCommand, "FK_Contactor_Security", DbType.Decimal, FK_Contactor_Security);

            if(string.IsNullOrEmpty(orderBy))
                db.AddInParameter(dbCommand, "OrderBy", DbType.String, "Location_Number,Project_Number ASC");
            else
                db.AddInParameter(dbCommand, "OrderBy", DbType.String, orderBy + " " + direction);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a All ProjectNumber record from the Facility_Construction_Project table by FK_Location.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByLocationFacility_Construction_Project(decimal FK_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_ProjectSelectByLocationForCS");

            db.AddInParameter(dbCommand, "FK_Location", DbType.Decimal, FK_Location);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the Contractor_Job_Security table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Contractor_Job_SecuritySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Contractor_Job_Security table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Contractor_Job_SecurityUpdate");

			
			db.AddInParameter(dbCommand, "PK_Contractor_Job_Security", DbType.Decimal, this._PK_Contractor_Job_Security);
			
			db.AddInParameter(dbCommand, "FK_Contractor_Security", DbType.Decimal, this._FK_Contractor_Security);
			
			db.AddInParameter(dbCommand, "FK_Facility_Construction_Project", DbType.Decimal, this._FK_Facility_Construction_Project);
			
			if (string.IsNullOrEmpty(this._Access))
				db.AddInParameter(dbCommand, "Access", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Access", DbType.String, this._Access);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
             int res;
             res = Convert.ToInt32(db.ExecuteScalar(dbCommand));
             return res;
		}

		/// <summary>
		/// Deletes a record from the Contractor_Job_Security table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Contractor_Job_Security)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Contractor_Job_SecurityDelete");

			db.AddInParameter(dbCommand, "PK_Contractor_Job_Security", DbType.Decimal, pK_Contractor_Job_Security);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Contractor_Job_Security_Audit table by a  Contractor_Job_Security primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetAuditView(decimal PK_Contractor_Job_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_Job_Security_AuditView");

            db.AddInParameter(dbCommand, "PK_Contractor_Job_Security", DbType.Decimal, PK_Contractor_Job_Security);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
