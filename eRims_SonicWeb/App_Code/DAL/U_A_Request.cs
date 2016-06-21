using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for U_A_Request table.
	/// </summary>
	public sealed class U_A_Request
	{

		#region Private variables used to hold the property values

		private decimal? _PK_U_A_Request;
		private string _First_Name;
		private string _Last_Name;
		private string _Email;
		private string _Telephone;
		private decimal? _FK_LU_Location;
		private bool? _SA_EA_Associate;
		private decimal? _FK_Employee;
		private bool? _General_Manager;
		private bool? _Controller;
		private bool? _Service;
		private bool? _Sales;
		private bool? _Parts;
		private bool? _Business_Office;
		private bool? _Home_Office;
		private string _Home_Office_Text;
		private bool? _Field_Operastions;
		private string _Field_Operations_Text;
		private string _Reason_For_Access;
		private bool? _Regional_Market_Area_Associate;
		private bool? _Multiple_Locations;
		private bool? _Building_Access;
		private bool? _E_S_H_Access;
		private bool? _Claim_Report_Access;
		private bool? _Claim_View_Access;
		private bool? _Security_Access;
		private bool? _SLT_Access;
		private DateTime? _Update_Date;
		private string _Updated_By;
		private DateTime? _Created_Date;
		private bool? _Deny;
		private bool? _Facilities_Construction_Access;
        private string _Cell_Phone_Number;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_U_A_Request value.
		/// </summary>
		public decimal? PK_U_A_Request
		{
			get { return _PK_U_A_Request; }
			set { _PK_U_A_Request = value; }
		}

		/// <summary>
		/// Gets or sets the First_Name value.
		/// </summary>
		public string First_Name
		{
			get { return _First_Name; }
			set { _First_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Last_Name value.
		/// </summary>
		public string Last_Name
		{
			get { return _Last_Name; }
			set { _Last_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}

		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone
		{
			get { return _Telephone; }
			set { _Telephone = value; }
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
		/// Gets or sets the SA_EA_Associate value.
		/// </summary>
		public bool? SA_EA_Associate
		{
			get { return _SA_EA_Associate; }
			set { _SA_EA_Associate = value; }
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
		/// Gets or sets the General_Manager value.
		/// </summary>
		public bool? General_Manager
		{
			get { return _General_Manager; }
			set { _General_Manager = value; }
		}

		/// <summary>
		/// Gets or sets the Controller value.
		/// </summary>
		public bool? Controller
		{
			get { return _Controller; }
			set { _Controller = value; }
		}

		/// <summary>
		/// Gets or sets the Service value.
		/// </summary>
		public bool? Service
		{
			get { return _Service; }
			set { _Service = value; }
		}

		/// <summary>
		/// Gets or sets the Sales value.
		/// </summary>
		public bool? Sales
		{
			get { return _Sales; }
			set { _Sales = value; }
		}

		/// <summary>
		/// Gets or sets the Parts value.
		/// </summary>
		public bool? Parts
		{
			get { return _Parts; }
			set { _Parts = value; }
		}

		/// <summary>
		/// Gets or sets the Business_Office value.
		/// </summary>
		public bool? Business_Office
		{
			get { return _Business_Office; }
			set { _Business_Office = value; }
		}

		/// <summary>
		/// Gets or sets the Home_Office value.
		/// </summary>
		public bool? Home_Office
		{
			get { return _Home_Office; }
			set { _Home_Office = value; }
		}

		/// <summary>
		/// Gets or sets the Home_Office_Text value.
		/// </summary>
		public string Home_Office_Text
		{
			get { return _Home_Office_Text; }
			set { _Home_Office_Text = value; }
		}

		/// <summary>
		/// Gets or sets the Field_Operastions value.
		/// </summary>
		public bool? Field_Operastions
		{
			get { return _Field_Operastions; }
			set { _Field_Operastions = value; }
		}

		/// <summary>
		/// Gets or sets the Field_Operations_Text value.
		/// </summary>
		public string Field_Operations_Text
		{
			get { return _Field_Operations_Text; }
			set { _Field_Operations_Text = value; }
		}

		/// <summary>
		/// Gets or sets the Reason_For_Access value.
		/// </summary>
		public string Reason_For_Access
		{
			get { return _Reason_For_Access; }
			set { _Reason_For_Access = value; }
		}

		/// <summary>
		/// Gets or sets the Regional_Market_Area_Associate value.
		/// </summary>
		public bool? Regional_Market_Area_Associate
		{
			get { return _Regional_Market_Area_Associate; }
			set { _Regional_Market_Area_Associate = value; }
		}

		/// <summary>
		/// Gets or sets the Multiple_Locations value.
		/// </summary>
		public bool? Multiple_Locations
		{
			get { return _Multiple_Locations; }
			set { _Multiple_Locations = value; }
		}

		/// <summary>
		/// Gets or sets the Building_Access value.
		/// </summary>
		public bool? Building_Access
		{
			get { return _Building_Access; }
			set { _Building_Access = value; }
		}

		/// <summary>
		/// Gets or sets the E_S_H_Access value.
		/// </summary>
		public bool? E_S_H_Access
		{
			get { return _E_S_H_Access; }
			set { _E_S_H_Access = value; }
		}

		/// <summary>
		/// Gets or sets the Claim_Report_Access value.
		/// </summary>
		public bool? Claim_Report_Access
		{
			get { return _Claim_Report_Access; }
			set { _Claim_Report_Access = value; }
		}

		/// <summary>
		/// Gets or sets the Claim_View_Access value.
		/// </summary>
		public bool? Claim_View_Access
		{
			get { return _Claim_View_Access; }
			set { _Claim_View_Access = value; }
		}

		/// <summary>
		/// Gets or sets the Security_Access value.
		/// </summary>
		public bool? Security_Access
		{
			get { return _Security_Access; }
			set { _Security_Access = value; }
		}

		/// <summary>
		/// Gets or sets the SLT_Access value.
		/// </summary>
		public bool? SLT_Access
		{
			get { return _SLT_Access; }
			set { _SLT_Access = value; }
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

		/// <summary>
		/// Gets or sets the Created_Date value.
		/// </summary>
		public DateTime? Created_Date
		{
			get { return _Created_Date; }
			set { _Created_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Deny value.
		/// </summary>
		public bool? Deny
		{
			get { return _Deny; }
			set { _Deny = value; }
		}

		/// <summary>
		/// Gets or sets the Facilities_Construction_Access value.
		/// </summary>
		public bool? Facilities_Construction_Access
		{
			get { return _Facilities_Construction_Access; }
			set { _Facilities_Construction_Access = value; }
		}

        /// <summary>
        /// Gets or sets the Cell Phone Number value.
        /// </summary>
        public string Cell_Phone_Number
        {
            get { return _Cell_Phone_Number; }
            set { _Cell_Phone_Number = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the U_A_Request class with default value.
		/// </summary>
		public U_A_Request() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the U_A_Request class based on Primary Key.
		/// </summary>
		public U_A_Request(decimal pK_U_A_Request) 
		{
			DataTable dtU_A_Request = SelectByPK(pK_U_A_Request).Tables[0];

			if (dtU_A_Request.Rows.Count == 1)
			{
				 SetValue(dtU_A_Request.Rows[0]);

			}

            else
            {
                
            }

		}


		/// <summary>
		/// Initializes a new instance of the U_A_Request class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drU_A_Request) 
		{
				if (drU_A_Request["PK_U_A_Request"] == DBNull.Value)
					this._PK_U_A_Request = null;
				else
					this._PK_U_A_Request = (decimal?)drU_A_Request["PK_U_A_Request"];

				if (drU_A_Request["First_Name"] == DBNull.Value)
					this._First_Name = null;
				else
					this._First_Name = (string)drU_A_Request["First_Name"];

				if (drU_A_Request["Last_Name"] == DBNull.Value)
					this._Last_Name = null;
				else
					this._Last_Name = (string)drU_A_Request["Last_Name"];

				if (drU_A_Request["Email"] == DBNull.Value)
					this._Email = null;
				else
					this._Email = (string)drU_A_Request["Email"];

				if (drU_A_Request["Telephone"] == DBNull.Value)
					this._Telephone = null;
				else
					this._Telephone = (string)drU_A_Request["Telephone"];

				if (drU_A_Request["FK_LU_Location"] == DBNull.Value)
					this._FK_LU_Location = null;
				else
					this._FK_LU_Location = (decimal?)drU_A_Request["FK_LU_Location"];

				if (drU_A_Request["SA_EA_Associate"] == DBNull.Value)
					this._SA_EA_Associate = null;
				else
					this._SA_EA_Associate = (bool?)drU_A_Request["SA_EA_Associate"];

				if (drU_A_Request["FK_Employee"] == DBNull.Value)
					this._FK_Employee = null;
				else
					this._FK_Employee = (decimal?)drU_A_Request["FK_Employee"];

				if (drU_A_Request["General_Manager"] == DBNull.Value)
					this._General_Manager = null;
				else
					this._General_Manager = (bool?)drU_A_Request["General_Manager"];

				if (drU_A_Request["Controller"] == DBNull.Value)
					this._Controller = null;
				else
					this._Controller = (bool?)drU_A_Request["Controller"];

				if (drU_A_Request["Service"] == DBNull.Value)
					this._Service = null;
				else
					this._Service = (bool?)drU_A_Request["Service"];

				if (drU_A_Request["Sales"] == DBNull.Value)
					this._Sales = null;
				else
					this._Sales = (bool?)drU_A_Request["Sales"];

				if (drU_A_Request["Parts"] == DBNull.Value)
					this._Parts = null;
				else
					this._Parts = (bool?)drU_A_Request["Parts"];

				if (drU_A_Request["Business_Office"] == DBNull.Value)
					this._Business_Office = null;
				else
					this._Business_Office = (bool?)drU_A_Request["Business_Office"];

				if (drU_A_Request["Home_Office"] == DBNull.Value)
					this._Home_Office = null;
				else
					this._Home_Office = (bool?)drU_A_Request["Home_Office"];

				if (drU_A_Request["Home_Office_Text"] == DBNull.Value)
					this._Home_Office_Text = null;
				else
					this._Home_Office_Text = (string)drU_A_Request["Home_Office_Text"];

				if (drU_A_Request["Field_Operastions"] == DBNull.Value)
					this._Field_Operastions = null;
				else
					this._Field_Operastions = (bool?)drU_A_Request["Field_Operastions"];

				if (drU_A_Request["Field_Operations_Text"] == DBNull.Value)
					this._Field_Operations_Text = null;
				else
					this._Field_Operations_Text = (string)drU_A_Request["Field_Operations_Text"];

				if (drU_A_Request["Reason_For_Access"] == DBNull.Value)
					this._Reason_For_Access = null;
				else
					this._Reason_For_Access = (string)drU_A_Request["Reason_For_Access"];

				if (drU_A_Request["Regional_Market_Area_Associate"] == DBNull.Value)
					this._Regional_Market_Area_Associate = null;
				else
					this._Regional_Market_Area_Associate = (bool?)drU_A_Request["Regional_Market_Area_Associate"];

				if (drU_A_Request["Multiple_Locations"] == DBNull.Value)
					this._Multiple_Locations = null;
				else
					this._Multiple_Locations = (bool?)drU_A_Request["Multiple_Locations"];

				if (drU_A_Request["Building_Access"] == DBNull.Value)
					this._Building_Access = null;
				else
					this._Building_Access = (bool?)drU_A_Request["Building_Access"];

				if (drU_A_Request["E_S_H_Access"] == DBNull.Value)
					this._E_S_H_Access = null;
				else
					this._E_S_H_Access = (bool?)drU_A_Request["E_S_H_Access"];

				if (drU_A_Request["Claim_Report_Access"] == DBNull.Value)
					this._Claim_Report_Access = null;
				else
					this._Claim_Report_Access = (bool?)drU_A_Request["Claim_Report_Access"];

				if (drU_A_Request["Claim_View_Access"] == DBNull.Value)
					this._Claim_View_Access = null;
				else
					this._Claim_View_Access = (bool?)drU_A_Request["Claim_View_Access"];

				if (drU_A_Request["Security_Access"] == DBNull.Value)
					this._Security_Access = null;
				else
					this._Security_Access = (bool?)drU_A_Request["Security_Access"];

				if (drU_A_Request["SLT_Access"] == DBNull.Value)
					this._SLT_Access = null;
				else
					this._SLT_Access = (bool?)drU_A_Request["SLT_Access"];

				if (drU_A_Request["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drU_A_Request["Update_Date"];

				if (drU_A_Request["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drU_A_Request["Updated_By"];

				if (drU_A_Request["Created_Date"] == DBNull.Value)
					this._Created_Date = null;
				else
					this._Created_Date = (DateTime?)drU_A_Request["Created_Date"];

				if (drU_A_Request["Deny"] == DBNull.Value)
					this._Deny = null;
				else
					this._Deny = (bool?)drU_A_Request["Deny"];

				if (drU_A_Request["Facilities_Construction_Access"] == DBNull.Value)
					this._Facilities_Construction_Access = null;
				else
					this._Facilities_Construction_Access = (bool?)drU_A_Request["Facilities_Construction_Access"];

                if (drU_A_Request["Cell_Phone_Number"] == DBNull.Value)
                    this._Cell_Phone_Number = null;
                else
                    this._Cell_Phone_Number = (string)drU_A_Request["Cell_Phone_Number"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the U_A_Request table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_RequestInsert");

			
			if (string.IsNullOrEmpty(this._First_Name))
				db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);
			
			if (string.IsNullOrEmpty(this._Last_Name))
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);
			
			if (string.IsNullOrEmpty(this._Email))
				db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
			
			if (string.IsNullOrEmpty(this._Telephone))
				db.AddInParameter(dbCommand, "Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			db.AddInParameter(dbCommand, "SA_EA_Associate", DbType.Boolean, this._SA_EA_Associate);
			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);
			
			db.AddInParameter(dbCommand, "General_Manager", DbType.Boolean, this._General_Manager);
			
			db.AddInParameter(dbCommand, "Controller", DbType.Boolean, this._Controller);
			
			db.AddInParameter(dbCommand, "Service", DbType.Boolean, this._Service);
			
			db.AddInParameter(dbCommand, "Sales", DbType.Boolean, this._Sales);
			
			db.AddInParameter(dbCommand, "Parts", DbType.Boolean, this._Parts);
			
			db.AddInParameter(dbCommand, "Business_Office", DbType.Boolean, this._Business_Office);
			
			db.AddInParameter(dbCommand, "Home_Office", DbType.Boolean, this._Home_Office);
			
			if (string.IsNullOrEmpty(this._Home_Office_Text))
				db.AddInParameter(dbCommand, "Home_Office_Text", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Home_Office_Text", DbType.String, this._Home_Office_Text);
			
			db.AddInParameter(dbCommand, "Field_Operastions", DbType.Boolean, this._Field_Operastions);
			
			if (string.IsNullOrEmpty(this._Field_Operations_Text))
				db.AddInParameter(dbCommand, "Field_Operations_Text", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Field_Operations_Text", DbType.String, this._Field_Operations_Text);
			
			if (string.IsNullOrEmpty(this._Reason_For_Access))
				db.AddInParameter(dbCommand, "Reason_For_Access", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reason_For_Access", DbType.String, this._Reason_For_Access);
			
			db.AddInParameter(dbCommand, "Regional_Market_Area_Associate", DbType.Boolean, this._Regional_Market_Area_Associate);
			
			db.AddInParameter(dbCommand, "Multiple_Locations", DbType.Boolean, this._Multiple_Locations);
			
			db.AddInParameter(dbCommand, "Building_Access", DbType.Boolean, this._Building_Access);
			
			db.AddInParameter(dbCommand, "E_S_H_Access", DbType.Boolean, this._E_S_H_Access);
			
			db.AddInParameter(dbCommand, "Claim_Report_Access", DbType.Boolean, this._Claim_Report_Access);
			
			db.AddInParameter(dbCommand, "Claim_View_Access", DbType.Boolean, this._Claim_View_Access);
			
			db.AddInParameter(dbCommand, "Security_Access", DbType.Boolean, this._Security_Access);
			
			db.AddInParameter(dbCommand, "SLT_Access", DbType.Boolean, this._SLT_Access);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);
			
			db.AddInParameter(dbCommand, "Deny", DbType.Boolean, this._Deny);
			
			db.AddInParameter(dbCommand, "Facilities_Construction_Access", DbType.Boolean, this._Facilities_Construction_Access);

            if (string.IsNullOrEmpty(this._Cell_Phone_Number))
                db.AddInParameter(dbCommand, "Cell_Phone_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Phone_Number", DbType.String, this._Cell_Phone_Number);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the U_A_Request table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_U_A_Request)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_RequestSelectByPK");

			db.AddInParameter(dbCommand, "PK_U_A_Request", DbType.Decimal, pK_U_A_Request);

			return db.ExecuteDataSet(dbCommand);
		}

	
        /// <summary>
        /// Selects all records from the Security table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(string SearchString, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("U_A_RequestSelectAll");
            db.AddInParameter(dbCommand, "@SearchString", DbType.String, SearchString);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the U_A_Request table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_RequestUpdate");

			
			db.AddInParameter(dbCommand, "PK_U_A_Request", DbType.Decimal, this._PK_U_A_Request);
			
			if (string.IsNullOrEmpty(this._First_Name))
				db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);
			
			if (string.IsNullOrEmpty(this._Last_Name))
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);
			
			if (string.IsNullOrEmpty(this._Email))
				db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
			
			if (string.IsNullOrEmpty(this._Telephone))
				db.AddInParameter(dbCommand, "Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			db.AddInParameter(dbCommand, "SA_EA_Associate", DbType.Boolean, this._SA_EA_Associate);
			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);
			
			db.AddInParameter(dbCommand, "General_Manager", DbType.Boolean, this._General_Manager);
			
			db.AddInParameter(dbCommand, "Controller", DbType.Boolean, this._Controller);
			
			db.AddInParameter(dbCommand, "Service", DbType.Boolean, this._Service);
			
			db.AddInParameter(dbCommand, "Sales", DbType.Boolean, this._Sales);
			
			db.AddInParameter(dbCommand, "Parts", DbType.Boolean, this._Parts);
			
			db.AddInParameter(dbCommand, "Business_Office", DbType.Boolean, this._Business_Office);
			
			db.AddInParameter(dbCommand, "Home_Office", DbType.Boolean, this._Home_Office);
			
			if (string.IsNullOrEmpty(this._Home_Office_Text))
				db.AddInParameter(dbCommand, "Home_Office_Text", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Home_Office_Text", DbType.String, this._Home_Office_Text);
			
			db.AddInParameter(dbCommand, "Field_Operastions", DbType.Boolean, this._Field_Operastions);
			
			if (string.IsNullOrEmpty(this._Field_Operations_Text))
				db.AddInParameter(dbCommand, "Field_Operations_Text", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Field_Operations_Text", DbType.String, this._Field_Operations_Text);
			
			if (string.IsNullOrEmpty(this._Reason_For_Access))
				db.AddInParameter(dbCommand, "Reason_For_Access", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reason_For_Access", DbType.String, this._Reason_For_Access);
			
			db.AddInParameter(dbCommand, "Regional_Market_Area_Associate", DbType.Boolean, this._Regional_Market_Area_Associate);
			
			db.AddInParameter(dbCommand, "Multiple_Locations", DbType.Boolean, this._Multiple_Locations);
			
			db.AddInParameter(dbCommand, "Building_Access", DbType.Boolean, this._Building_Access);
			
			db.AddInParameter(dbCommand, "E_S_H_Access", DbType.Boolean, this._E_S_H_Access);
			
			db.AddInParameter(dbCommand, "Claim_Report_Access", DbType.Boolean, this._Claim_Report_Access);
			
			db.AddInParameter(dbCommand, "Claim_View_Access", DbType.Boolean, this._Claim_View_Access);
			
			db.AddInParameter(dbCommand, "Security_Access", DbType.Boolean, this._Security_Access);
			
			db.AddInParameter(dbCommand, "SLT_Access", DbType.Boolean, this._SLT_Access);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);
			
			db.AddInParameter(dbCommand, "Deny", DbType.Boolean, this._Deny);
			
			db.AddInParameter(dbCommand, "Facilities_Construction_Access", DbType.Boolean, this._Facilities_Construction_Access);

            if (string.IsNullOrEmpty(this._Cell_Phone_Number))
                db.AddInParameter(dbCommand, "Cell_Phone_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Phone_Number", DbType.String, this._Cell_Phone_Number);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}



        public static DataSet SetDenyvalues(string FirstName, string LastName, decimal PK_U_A_Request)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("U_A_RequestDeny");
            db.AddInParameter(dbCommand, "@First_Name", DbType.String, FirstName);
            db.AddInParameter(dbCommand, "@Last_Name", DbType.String, LastName);
            db.AddInParameter(dbCommand, "@PK_U_A_Request", DbType.Decimal, PK_U_A_Request);
            return db.ExecuteDataSet(dbCommand);
        }
      
	}
}
