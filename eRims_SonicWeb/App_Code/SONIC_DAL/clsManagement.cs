using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Management table.
	/// </summary>
	public sealed class clsManagement
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Management_ID;
		private string _Company;
		private string _Company_Phone;
		private decimal? _FK_LU_Location;
		private decimal? _FK_LU_State;
		private string _City;
		private decimal? _FK_LU_Region;
		private string _County;
		private string _Camera_Number;
		private decimal? _FK_LU_Camera_Type;
		private string _FK_LU_Client_Issue;
		private string _FK_LU_Facilities_Issue;
		private decimal? _Cost;
		private DateTime? _Date_Scheduled;
		private DateTime? _Date_Complete;
		private DateTime? _CR_Approved;
		private string _Camera_Concern;
		private string _Recommendation;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _Location_Code;
        private bool? _Task_Complete;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Management_ID value.
		/// </summary>
		public decimal? PK_Management_ID
		{
			get { return _PK_Management_ID; }
			set { _PK_Management_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Company value.
		/// </summary>
		public string Company
		{
			get { return _Company; }
			set { _Company = value; }
		}

		/// <summary>
		/// Gets or sets the Company_Phone value.
		/// </summary>
		public string Company_Phone
		{
			get { return _Company_Phone; }
			set { _Company_Phone = value; }
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
		/// Gets or sets the FK_LU_State value.
		/// </summary>
		public decimal? FK_LU_State
		{
			get { return _FK_LU_State; }
			set { _FK_LU_State = value; }
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
		/// Gets or sets the FK_LU_Region value.
		/// </summary>
		public decimal? FK_LU_Region
		{
			get { return _FK_LU_Region; }
			set { _FK_LU_Region = value; }
		}

		/// <summary>
		/// Gets or sets the County value.
		/// </summary>
		public string County
		{
			get { return _County; }
			set { _County = value; }
		}

		/// <summary>
		/// Gets or sets the Camera_Number value.
		/// </summary>
		public string Camera_Number
		{
			get { return _Camera_Number; }
			set { _Camera_Number = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Camera_Type value.
		/// </summary>
		public decimal? FK_LU_Camera_Type
		{
			get { return _FK_LU_Camera_Type; }
			set { _FK_LU_Camera_Type = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Client_Issue value.
		/// </summary>
		public string FK_LU_Client_Issue
		{
			get { return _FK_LU_Client_Issue; }
			set { _FK_LU_Client_Issue = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Facilities_Issue value.
		/// </summary>
		public string FK_LU_Facilities_Issue
		{
			get { return _FK_LU_Facilities_Issue; }
			set { _FK_LU_Facilities_Issue = value; }
		}

		/// <summary>
		/// Gets or sets the Cost value.
		/// </summary>
		public decimal? Cost
		{
			get { return _Cost; }
			set { _Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Scheduled value.
		/// </summary>
		public DateTime? Date_Scheduled
		{
			get { return _Date_Scheduled; }
			set { _Date_Scheduled = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Complete value.
		/// </summary>
		public DateTime? Date_Complete
		{
			get { return _Date_Complete; }
			set { _Date_Complete = value; }
		}

		/// <summary>
		/// Gets or sets the CR_Approved value.
		/// </summary>
		public DateTime? CR_Approved
		{
			get { return _CR_Approved; }
			set { _CR_Approved = value; }
		}

		/// <summary>
		/// Gets or sets the Camera_Concern value.
		/// </summary>
		public string Camera_Concern
		{
			get { return _Camera_Concern; }
			set { _Camera_Concern = value; }
		}

		/// <summary>
		/// Gets or sets the Recommendation value.
		/// </summary>
		public string Recommendation
		{
			get { return _Recommendation; }
			set { _Recommendation = value; }
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
        /// Gets or sets the Location_Code value.
        /// </summary>
        public decimal? Location_Code
        {
            get { return _Location_Code; }
            set { _Location_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Task_Complete value.
        /// </summary>
        public bool? Task_Complete
        {
            get { return _Task_Complete; }
            set { _Task_Complete = value; }
        }


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsManagement class with default value.
		/// </summary>
		public clsManagement() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsManagement class based on Primary Key.
		/// </summary>
		public clsManagement(decimal pK_Management_ID) 
		{
			DataTable dtManagement = SelectByPK(pK_Management_ID).Tables[0];

			if (dtManagement.Rows.Count == 1)
			{
				 SetValue(dtManagement.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsManagement class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drManagement) 
		{
				if (drManagement["PK_Management_ID"] == DBNull.Value)
					this._PK_Management_ID = null;
				else
					this._PK_Management_ID = (decimal?)drManagement["PK_Management_ID"];

				if (drManagement["Company"] == DBNull.Value)
					this._Company = null;
				else
					this._Company = (string)drManagement["Company"];

				if (drManagement["Company_Phone"] == DBNull.Value)
					this._Company_Phone = null;
				else
					this._Company_Phone = (string)drManagement["Company_Phone"];

				if (drManagement["FK_LU_Location"] == DBNull.Value)
					this._FK_LU_Location = null;
				else
					this._FK_LU_Location = (decimal?)drManagement["FK_LU_Location"];

				if (drManagement["FK_LU_State"] == DBNull.Value)
					this._FK_LU_State = null;
				else
					this._FK_LU_State = (decimal?)drManagement["FK_LU_State"];

				if (drManagement["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drManagement["City"];

				if (drManagement["FK_LU_Region"] == DBNull.Value)
					this._FK_LU_Region = null;
				else
					this._FK_LU_Region = (decimal?)drManagement["FK_LU_Region"];

				if (drManagement["County"] == DBNull.Value)
					this._County = null;
				else
					this._County = (string)drManagement["County"];

				if (drManagement["Camera_Number"] == DBNull.Value)
					this._Camera_Number = null;
				else
					this._Camera_Number = (string)drManagement["Camera_Number"];

				if (drManagement["FK_LU_Camera_Type"] == DBNull.Value)
					this._FK_LU_Camera_Type = null;
				else
					this._FK_LU_Camera_Type = (decimal?)drManagement["FK_LU_Camera_Type"];

				if (drManagement["FK_LU_Client_Issue"] == DBNull.Value)
					this._FK_LU_Client_Issue = null;
				else
					this._FK_LU_Client_Issue = (string)drManagement["FK_LU_Client_Issue"];

				if (drManagement["FK_LU_Facilities_Issue"] == DBNull.Value)
					this._FK_LU_Facilities_Issue = null;
				else
					this._FK_LU_Facilities_Issue = (string)drManagement["FK_LU_Facilities_Issue"];

				if (drManagement["Cost"] == DBNull.Value)
					this._Cost = null;
				else
					this._Cost = (decimal?)drManagement["Cost"];

				if (drManagement["Date_Scheduled"] == DBNull.Value)
					this._Date_Scheduled = null;
				else
					this._Date_Scheduled = (DateTime?)drManagement["Date_Scheduled"];

				if (drManagement["Date_Complete"] == DBNull.Value)
					this._Date_Complete = null;
				else
					this._Date_Complete = (DateTime?)drManagement["Date_Complete"];

				if (drManagement["CR_Approved"] == DBNull.Value)
					this._CR_Approved = null;
				else
					this._CR_Approved = (DateTime?)drManagement["CR_Approved"];

				if (drManagement["Camera_Concern"] == DBNull.Value)
					this._Camera_Concern = null;
				else
					this._Camera_Concern = (string)drManagement["Camera_Concern"];

				if (drManagement["Recommendation"] == DBNull.Value)
					this._Recommendation = null;
				else
					this._Recommendation = (string)drManagement["Recommendation"];

				if (drManagement["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drManagement["Updated_By"];

				if (drManagement["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drManagement["Update_Date"];

                if (drManagement["Location_Code"] == DBNull.Value)
                    this._Location_Code = null;
                else
                    this._Location_Code = (decimal?)drManagement["Location_Code"];

                if (drManagement["Task_Complete"] == DBNull.Value)
                    this._Task_Complete = null;
                else
                    this._Task_Complete = (bool?)drManagement["Task_Complete"];



		}

		#endregion

		/// <summary>
		/// Inserts a record into the Management table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ManagementInsert");

			
			if (string.IsNullOrEmpty(this._Company))
				db.AddInParameter(dbCommand, "Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Company", DbType.String, this._Company);
			
			if (string.IsNullOrEmpty(this._Company_Phone))
				db.AddInParameter(dbCommand, "Company_Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Company_Phone", DbType.String, this._Company_Phone);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, this._FK_LU_State);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_LU_Region", DbType.Decimal, this._FK_LU_Region);
			
			if (string.IsNullOrEmpty(this._County))
				db.AddInParameter(dbCommand, "County", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "County", DbType.String, this._County);
			
			if (string.IsNullOrEmpty(this._Camera_Number))
				db.AddInParameter(dbCommand, "Camera_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Camera_Number", DbType.String, this._Camera_Number);
			
			db.AddInParameter(dbCommand, "FK_LU_Camera_Type", DbType.Decimal, this._FK_LU_Camera_Type);
			
			if (string.IsNullOrEmpty(this._FK_LU_Client_Issue))
				db.AddInParameter(dbCommand, "FK_LU_Client_Issue", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_LU_Client_Issue", DbType.String, this._FK_LU_Client_Issue);
			
			if (string.IsNullOrEmpty(this._FK_LU_Facilities_Issue))
				db.AddInParameter(dbCommand, "FK_LU_Facilities_Issue", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_LU_Facilities_Issue", DbType.String, this._FK_LU_Facilities_Issue);
			
			db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);
			
			db.AddInParameter(dbCommand, "Date_Scheduled", DbType.DateTime, this._Date_Scheduled);
			
			db.AddInParameter(dbCommand, "Date_Complete", DbType.DateTime, this._Date_Complete);
			
			db.AddInParameter(dbCommand, "CR_Approved", DbType.DateTime, this._CR_Approved);
			
			if (string.IsNullOrEmpty(this._Camera_Concern))
				db.AddInParameter(dbCommand, "Camera_Concern", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Camera_Concern", DbType.String, this._Camera_Concern);
			
			if (string.IsNullOrEmpty(this._Recommendation))
				db.AddInParameter(dbCommand, "Recommendation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recommendation", DbType.String, this._Recommendation);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "Location_Code", DbType.Decimal, this._Location_Code);

            db.AddInParameter(dbCommand, "Task_Complete", DbType.Boolean, this._Task_Complete);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Management table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Management_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ManagementSelectByPK");

			db.AddInParameter(dbCommand, "PK_Management_ID", DbType.Decimal, pK_Management_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Management table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ManagementSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Management table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ManagementUpdate");

			
			db.AddInParameter(dbCommand, "PK_Management_ID", DbType.Decimal, this._PK_Management_ID);
			
			if (string.IsNullOrEmpty(this._Company))
				db.AddInParameter(dbCommand, "Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Company", DbType.String, this._Company);
			
			if (string.IsNullOrEmpty(this._Company_Phone))
				db.AddInParameter(dbCommand, "Company_Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Company_Phone", DbType.String, this._Company_Phone);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, this._FK_LU_State);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_LU_Region", DbType.Decimal, this._FK_LU_Region);
			
			if (string.IsNullOrEmpty(this._County))
				db.AddInParameter(dbCommand, "County", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "County", DbType.String, this._County);
			
			if (string.IsNullOrEmpty(this._Camera_Number))
				db.AddInParameter(dbCommand, "Camera_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Camera_Number", DbType.String, this._Camera_Number);
			
			db.AddInParameter(dbCommand, "FK_LU_Camera_Type", DbType.Decimal, this._FK_LU_Camera_Type);
			
			if (string.IsNullOrEmpty(this._FK_LU_Client_Issue))
				db.AddInParameter(dbCommand, "FK_LU_Client_Issue", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_LU_Client_Issue", DbType.String, this._FK_LU_Client_Issue);
			
			if (string.IsNullOrEmpty(this._FK_LU_Facilities_Issue))
				db.AddInParameter(dbCommand, "FK_LU_Facilities_Issue", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_LU_Facilities_Issue", DbType.String, this._FK_LU_Facilities_Issue);
			
			db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);
			
			db.AddInParameter(dbCommand, "Date_Scheduled", DbType.DateTime, this._Date_Scheduled);
			
			db.AddInParameter(dbCommand, "Date_Complete", DbType.DateTime, this._Date_Complete);
			
			db.AddInParameter(dbCommand, "CR_Approved", DbType.DateTime, this._CR_Approved);
			
			if (string.IsNullOrEmpty(this._Camera_Concern))
				db.AddInParameter(dbCommand, "Camera_Concern", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Camera_Concern", DbType.String, this._Camera_Concern);
			
			if (string.IsNullOrEmpty(this._Recommendation))
				db.AddInParameter(dbCommand, "Recommendation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recommendation", DbType.String, this._Recommendation);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "Location_Code", DbType.Decimal, this._Location_Code);

            db.AddInParameter(dbCommand, "Task_Complete", DbType.Boolean, this._Task_Complete);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Management table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Management_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ManagementDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Management_ID", DbType.Decimal, pK_Management_ID);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet ManagementSearch(string Company, string City, string County, string Camera_Number, decimal? Cost, decimal? FK_LU_Location, decimal? FK_LU_State,
            decimal? FK_LU_Region, decimal? FK_LU_Camera_Type, string FK_LU_Client_Issue, string FK_LU_Facilities_Issue, DateTime? Date_Scheduled_From, DateTime? Date_Scheduled_To,
            DateTime? Date_Complete_From, DateTime? Date_Complete_To, DateTime? CR_Approved_From, DateTime? CR_Approved_To, decimal? Location_Code, string strOrderBy, string strOrder, int intPageNo, int intPageSize,bool? Task_Complete)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ManagementSearch");

            db.AddInParameter(dbCommand, "Company", DbType.String, Company);
            db.AddInParameter(dbCommand, "City", DbType.String, City);
            db.AddInParameter(dbCommand, "County", DbType.String, County);
            db.AddInParameter(dbCommand, "Camera_Number", DbType.String, Camera_Number);
            db.AddInParameter(dbCommand, "Cost", DbType.Decimal, Cost);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, FK_LU_State);
            db.AddInParameter(dbCommand, "FK_LU_Region", DbType.Decimal, FK_LU_Region);
            db.AddInParameter(dbCommand, "FK_LU_Camera_Type", DbType.Decimal, FK_LU_Camera_Type);
            db.AddInParameter(dbCommand, "FK_LU_Client_Issue", DbType.String, FK_LU_Client_Issue);
            db.AddInParameter(dbCommand, "FK_LU_Facilities_Issue", DbType.String, FK_LU_Facilities_Issue);
            db.AddInParameter(dbCommand, "Date_Scheduled_From", DbType.DateTime, Date_Scheduled_From);
            db.AddInParameter(dbCommand, "Date_Scheduled_To", DbType.DateTime, Date_Scheduled_To);
            db.AddInParameter(dbCommand, "Date_Complete_From", DbType.DateTime, Date_Complete_From);
            db.AddInParameter(dbCommand, "Date_Complete_To", DbType.DateTime, Date_Complete_To);
            db.AddInParameter(dbCommand, "CR_Approved_From", DbType.DateTime, CR_Approved_From);
            db.AddInParameter(dbCommand, "CR_Approved_To", DbType.DateTime, CR_Approved_To);
            db.AddInParameter(dbCommand, "Location_Code", DbType.Decimal, Location_Code);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);
            db.AddInParameter(dbCommand, "Task_Complete", DbType.Boolean, Task_Complete);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, Convert.ToInt32(clsSession.UserID));

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
