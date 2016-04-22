using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_Members table.
	/// </summary>
	public sealed class SLT_Members
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_Members;
		private decimal? _FK_SLT_Meeting;
		private DateTime? _Start_Date;
		private DateTime? _End_Date;
		private decimal? _FK_Employee;
		private decimal? _FK_LU_Department;
		private decimal? _FK_LU_SLT_Role;
		private string _Current_Member;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _FK_LU_Location_ID;
        private string _First_Name;
        private string _Middle_Name;
        private string _Last_Name;
        private string _Email;        
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_Members value.
		/// </summary>
		public decimal? PK_SLT_Members
		{
			get { return _PK_SLT_Members; }
			set { _PK_SLT_Members = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_Meeting value.
		/// </summary>
		public decimal? FK_SLT_Meeting
		{
			get { return _FK_SLT_Meeting; }
			set { _FK_SLT_Meeting = value; }
		}

		/// <summary>
		/// Gets or sets the Start_Date value.
		/// </summary>
		public DateTime? Start_Date
		{
			get { return _Start_Date; }
			set { _Start_Date = value; }
		}

		/// <summary>
		/// Gets or sets the End_Date value.
		/// </summary>
		public DateTime? End_Date
		{
			get { return _End_Date; }
			set { _End_Date = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Employee value.
		/// </summary>
		public decimal? FK_Employee
		{
			get { return _FK_Employee; }
			set { _FK_Employee = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Department value.
		/// </summary>
		public decimal? FK_LU_Department
		{
			get { return _FK_LU_Department; }
			set { _FK_LU_Department = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_SLT_Role value.
		/// </summary>
		public decimal? FK_LU_SLT_Role
		{
			get { return _FK_LU_SLT_Role; }
			set { _FK_LU_SLT_Role = value; }
		}

		/// <summary>
		/// Gets or sets the Current_Member value.
		/// </summary>
		public string Current_Member
		{
			get { return _Current_Member; }
			set { _Current_Member = value; }
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
        /// gets or Sets FK_LU_Location_ID value
        /// </summary>
        public decimal? FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }
        /// <summary>
        /// gets or sets First_Name value
        /// </summary>
        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }
        /// <summary>
        /// gets or sets Middle_Name value
        /// </summary>
        public string Middle_Name
        {
            get { return _Middle_Name; }
            set { _Middle_Name = value; }
        }
        /// <summary>
        /// gets or sets Last_Name value
        /// </summary>
        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }
        /// <summary>
        /// gets or sets Email value
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Members class with default value.
		/// </summary>
		public SLT_Members() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Members class based on Primary Key.
		/// </summary>
		public SLT_Members(decimal pK_SLT_Members) 
		{
			DataTable dtSLT_Members = SelectByPK(pK_SLT_Members).Tables[0];

			if (dtSLT_Members.Rows.Count == 1)
			{
				 SetValue(dtSLT_Members.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSLT_Members class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_Members) 
		{
				if (drSLT_Members["PK_SLT_Members"] == DBNull.Value)
					this._PK_SLT_Members = null;
				else
					this._PK_SLT_Members = (decimal?)drSLT_Members["PK_SLT_Members"];

				if (drSLT_Members["FK_SLT_Meeting"] == DBNull.Value)
					this._FK_SLT_Meeting = null;
				else
					this._FK_SLT_Meeting = (decimal?)drSLT_Members["FK_SLT_Meeting"];

				if (drSLT_Members["Start_Date"] == DBNull.Value)
					this._Start_Date = null;
				else
					this._Start_Date = (DateTime?)drSLT_Members["Start_Date"];

				if (drSLT_Members["End_Date"] == DBNull.Value)
					this._End_Date = null;
				else
					this._End_Date = (DateTime?)drSLT_Members["End_Date"];

				if (drSLT_Members["FK_Employee"] == DBNull.Value)
					this._FK_Employee = null;
				else
					this._FK_Employee = (decimal?)drSLT_Members["FK_Employee"];

				if (drSLT_Members["FK_LU_Department"] == DBNull.Value)
					this._FK_LU_Department = null;
				else
					this._FK_LU_Department = (decimal?)drSLT_Members["FK_LU_Department"];

				if (drSLT_Members["FK_LU_SLT_Role"] == DBNull.Value)
					this._FK_LU_SLT_Role = null;
				else
					this._FK_LU_SLT_Role = (decimal?)drSLT_Members["FK_LU_SLT_Role"];

				if (drSLT_Members["Current_Member"] == DBNull.Value)
					this._Current_Member = null;
				else
					this._Current_Member = (string)drSLT_Members["Current_Member"];

				if (drSLT_Members["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSLT_Members["Updated_By"];

				if (drSLT_Members["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSLT_Members["Update_Date"];

                if (drSLT_Members["FK_LU_Location_ID"] == DBNull.Value)
                    this._FK_LU_Location_ID = null;
                else
                    this._FK_LU_Location_ID = (decimal?)drSLT_Members["FK_LU_Location_ID"];

                if (drSLT_Members["First_Name"] == DBNull.Value)
                    this._First_Name = null;
                else
                    this._First_Name = (string)drSLT_Members["First_Name"];

                if (drSLT_Members["Middle_Name"] == DBNull.Value)
                    this._Middle_Name = null;
                else
                    this._Middle_Name = (string)drSLT_Members["Middle_Name"];

                if (drSLT_Members["Last_Name"] == DBNull.Value)
                this._Last_Name = null;
            else
                    this._Last_Name = (string)drSLT_Members["Last_Name"];

                if (drSLT_Members["Email"] == DBNull.Value)
                this._Email = null;
            else
                    this._Email = (string)drSLT_Members["Email"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_Members table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MembersInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);
			
			db.AddInParameter(dbCommand, "FK_LU_Department", DbType.Decimal, this._FK_LU_Department);
			
			db.AddInParameter(dbCommand, "FK_LU_SLT_Role", DbType.Decimal, this._FK_LU_SLT_Role);
			
			if (string.IsNullOrEmpty(this._Current_Member))
				db.AddInParameter(dbCommand, "Current_Member", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Current_Member", DbType.String, this._Current_Member);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Middle_Name))
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, this._Middle_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_Members table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_Members)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MembersSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Members", DbType.Decimal, pK_SLT_Members);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_Members table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MembersSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_Members table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MembersUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_Members", DbType.Decimal, this._PK_SLT_Members);
			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);
			
			db.AddInParameter(dbCommand, "FK_LU_Department", DbType.Decimal, this._FK_LU_Department);
			
			db.AddInParameter(dbCommand, "FK_LU_SLT_Role", DbType.Decimal, this._FK_LU_SLT_Role);
			
			if (string.IsNullOrEmpty(this._Current_Member))
				db.AddInParameter(dbCommand, "Current_Member", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Current_Member", DbType.String, this._Current_Member);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Middle_Name))
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, this._Middle_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

        /// <summary>
        /// Updates a record in the SLT_Members table.
        /// </summary>
        public int InsertUpdate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_MembersInsertUpdate");


            db.AddInParameter(dbCommand, "PK_SLT_Members", DbType.Decimal, this._PK_SLT_Members);

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);

            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);

            db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);

            db.AddInParameter(dbCommand, "FK_LU_Department", DbType.Decimal, this._FK_LU_Department);

            db.AddInParameter(dbCommand, "FK_LU_SLT_Role", DbType.Decimal, this._FK_LU_SLT_Role);

            if (string.IsNullOrEmpty(this._Current_Member))
                db.AddInParameter(dbCommand, "Current_Member", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Current_Member", DbType.String, this._Current_Member);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
           
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
           
            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Middle_Name))
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, this._Middle_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

		/// <summary>
		/// Deletes a record from the SLT_Members table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_Members)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MembersDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Members", DbType.Decimal, pK_SLT_Members);

			db.ExecuteNonQuery(dbCommand);
		}
        /// <summary>
        /// Selects  from the SLT_Members table by a FK_SLT_Meeting.
        /// </summary>
        public static DataSet SLT_MembersSelectByFk(decimal FK_SLT_Meeting, int Year,decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_MembersSelectByFk");

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            return(db.ExecuteDataSet(dbCommand));
        }

        public static bool IsDuplicate(decimal PK_SLT_Members, decimal FK_SLT_Meeting, decimal FK_Employee)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_MembersCheckDuplicate");

            db.AddInParameter(dbCommand, "PK_SLT_Members", DbType.Decimal, PK_SLT_Members);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, FK_Employee);
            bool bDuplicate = false;
            DataSet ds = db.ExecuteDataSet(dbCommand);
            if(ds.Tables[0].Rows.Count > 0)
                bDuplicate = Convert.ToString(ds.Tables[0].Rows[0][0]) == "Y";
            return bDuplicate;
        }

        /// <summary>
        /// Selects all records from the SLT_Members table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBY_FK_SLT_Safety_Walk(decimal FK_SLT_Safety_Walk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Members_SelectBy_FK_SLT_Meeting");
            db.AddInParameter(dbCommand, "FK_SLT_Safety_Walk", DbType.Decimal, FK_SLT_Safety_Walk);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects  from the SLT_Safety_Walk_Members table by a FK_SLT_Meeting.
        /// </summary>
        public static DataSet SLT_Safety_Walk_MembersSelectByPK_SLT_Meeting(decimal FK_SLT_Meeting, decimal FK_SLT_Safety_Walk, int Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_Walk_MembersSelectByPK_SLT_Meeting");

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "FK_SLT_Safety_Walk", DbType.Decimal, FK_SLT_Safety_Walk);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            return (db.ExecuteDataSet(dbCommand));
        }

        /// <summary>
        /// Selects  from the SLT_BT_Security_Walk_Members table by a FK_SLT_Meeting.
        /// </summary>
        public static DataSet SLT_BT_Security_Walk_MembersSelectByPK_SLT_Meeting(decimal FK_SLT_Meeting, decimal FK_SLT_BT_Security_Walk, int Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_MembersSelectByPK_SLT_Meeting");

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk", DbType.Decimal, FK_SLT_BT_Security_Walk);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            return (db.ExecuteDataSet(dbCommand));
        }

        ////change Reverted for sonic u training. ticket #3503/////
        //public static DataSet SelectSignedupEmployeeByLocation(int Year, string DBA, string Sonic_Location_Code)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("EmployeesSignedByLocation_New");
        //    db.AddInParameter(dbCommand, "@Year", DbType.Int32, Year);
        //    db.AddInParameter(dbCommand, "@DBA", DbType.String, DBA);
        //    db.AddInParameter(dbCommand, "@Sonic_Location_Code", DbType.String, Sonic_Location_Code);
        //    return db.ExecuteDataSet(dbCommand);
        //}

        /// <summary>
        /// Selects  from the SLT_Members table by a FK_SLT_Meeting.
        /// </summary>
        public static DataSet SLT_MembersSelectByFK_SLT_Meeting(decimal FK_SLT_Meeting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_MembersSelectByFK_SLT_Meeting");
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            return (db.ExecuteDataSet(dbCommand));
        }
	}
}
