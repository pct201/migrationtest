using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Respiratory_Protection table.
	/// </summary>
	public sealed class clsPM_Respiratory_Protection
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Respiratory_Protection;
        private decimal? _FK_PM_Site_Information;
		private decimal? _FK_LU_Location;
		private decimal? _FK_Employee;
		private DateTime? _Date;
		private string _Event_Type;
		private string _Medical_Evaluation;
		private string _Restrictions_Applied;
		private string _Restrictions;
		private string _Reevaluation_Required;
		private DateTime? _Reevaluation_Date;
		private string _Training_Completed;
		private DateTime? _Training_Completion_Date;
		private string _Fit_Test;
		private DateTime? _Fit_Test_Date;
		private string _Pass_Fail;
		private decimal? _FK_LU_Respirator_Type;
		private string _Vendor;
		private string _Vendor_Representative;
		private string _Vendor_Address;
		private string _Vendor_City;
		private decimal? _FK_Vendor_State;
		private string _Vendor_Zip_Code;
		private string _Vendor_Telephone;
		private string _Vendor_EMail;
		private string _Notes_Comments;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Respiratory_Protection value.
		/// </summary>
		public decimal? PK_PM_Respiratory_Protection
		{
			get { return _PK_PM_Respiratory_Protection; }
			set { _PK_PM_Respiratory_Protection = value; }
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
		/// Gets or sets the FK_LU_Location value.
		/// </summary>
		public decimal? FK_LU_Location
		{
			get { return _FK_LU_Location; }
			set { _FK_LU_Location = value; }
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
		/// Gets or sets the Date value.
		/// </summary>
		public DateTime? Date
		{
			get { return _Date; }
			set { _Date = value; }
		}

		/// <summary>
		/// Gets or sets the Event_Type value.
		/// </summary>
		public string Event_Type
		{
			get { return _Event_Type; }
			set { _Event_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Medical_Evaluation value.
		/// </summary>
		public string Medical_Evaluation
		{
			get { return _Medical_Evaluation; }
			set { _Medical_Evaluation = value; }
		}

		/// <summary>
		/// Gets or sets the Restrictions_Applied value.
		/// </summary>
		public string Restrictions_Applied
		{
			get { return _Restrictions_Applied; }
			set { _Restrictions_Applied = value; }
		}

		/// <summary>
		/// Gets or sets the Restrictions value.
		/// </summary>
		public string Restrictions
		{
			get { return _Restrictions; }
			set { _Restrictions = value; }
		}

		/// <summary>
		/// Gets or sets the Reevaluation_Required value.
		/// </summary>
		public string Reevaluation_Required
		{
			get { return _Reevaluation_Required; }
			set { _Reevaluation_Required = value; }
		}

		/// <summary>
		/// Gets or sets the Reevaluation_Date value.
		/// </summary>
		public DateTime? Reevaluation_Date
		{
			get { return _Reevaluation_Date; }
			set { _Reevaluation_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Training_Completed value.
		/// </summary>
		public string Training_Completed
		{
			get { return _Training_Completed; }
			set { _Training_Completed = value; }
		}

		/// <summary>
		/// Gets or sets the Training_Completion_Date value.
		/// </summary>
		public DateTime? Training_Completion_Date
		{
			get { return _Training_Completion_Date; }
			set { _Training_Completion_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Fit_Test value.
		/// </summary>
		public string Fit_Test
		{
			get { return _Fit_Test; }
			set { _Fit_Test = value; }
		}

		/// <summary>
		/// Gets or sets the Fit_Test_Date value.
		/// </summary>
		public DateTime? Fit_Test_Date
		{
			get { return _Fit_Test_Date; }
			set { _Fit_Test_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Pass_Fail value.
		/// </summary>
		public string Pass_Fail
		{
			get { return _Pass_Fail; }
			set { _Pass_Fail = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Respirator_Type value.
		/// </summary>
		public decimal? FK_LU_Respirator_Type
		{
			get { return _FK_LU_Respirator_Type; }
			set { _FK_LU_Respirator_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor value.
		/// </summary>
		public string Vendor
		{
			get { return _Vendor; }
			set { _Vendor = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Representative value.
		/// </summary>
		public string Vendor_Representative
		{
			get { return _Vendor_Representative; }
			set { _Vendor_Representative = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Address value.
		/// </summary>
		public string Vendor_Address
		{
			get { return _Vendor_Address; }
			set { _Vendor_Address = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_City value.
		/// </summary>
		public string Vendor_City
		{
			get { return _Vendor_City; }
			set { _Vendor_City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Vendor_State value.
		/// </summary>
		public decimal? FK_Vendor_State
		{
			get { return _FK_Vendor_State; }
			set { _FK_Vendor_State = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Zip_Code value.
		/// </summary>
		public string Vendor_Zip_Code
		{
			get { return _Vendor_Zip_Code; }
			set { _Vendor_Zip_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Telephone value.
		/// </summary>
		public string Vendor_Telephone
		{
			get { return _Vendor_Telephone; }
			set { _Vendor_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_EMail value.
		/// </summary>
		public string Vendor_EMail
		{
			get { return _Vendor_EMail; }
			set { _Vendor_EMail = value; }
		}

		/// <summary>
		/// Gets or sets the Notes_Comments value.
		/// </summary>
		public string Notes_Comments
		{
			get { return _Notes_Comments; }
			set { _Notes_Comments = value; }
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
		/// Initializes a new instance of the clsPM_Respiratory_Protection class with default value.
		/// </summary>
		public clsPM_Respiratory_Protection() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Respiratory_Protection class based on Primary Key.
		/// </summary>
		public clsPM_Respiratory_Protection(decimal pK_PM_Respiratory_Protection) 
		{
			DataTable dtPM_Respiratory_Protection = SelectByPK(pK_PM_Respiratory_Protection).Tables[0];

			if (dtPM_Respiratory_Protection.Rows.Count == 1)
			{
				 SetValue(dtPM_Respiratory_Protection.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Respiratory_Protection class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Respiratory_Protection) 
		{
				if (drPM_Respiratory_Protection["PK_PM_Respiratory_Protection"] == DBNull.Value)
					this._PK_PM_Respiratory_Protection = null;
				else
					this._PK_PM_Respiratory_Protection = (decimal?)drPM_Respiratory_Protection["PK_PM_Respiratory_Protection"];

                if (drPM_Respiratory_Protection["FK_PM_Site_Information"] == DBNull.Value)
                    this._FK_PM_Site_Information = null;
                else
                    this._FK_PM_Site_Information = (decimal?)drPM_Respiratory_Protection["FK_PM_Site_Information"];

				if (drPM_Respiratory_Protection["FK_LU_Location"] == DBNull.Value)
					this._FK_LU_Location = null;
				else
					this._FK_LU_Location = (decimal?)drPM_Respiratory_Protection["FK_LU_Location"];

				if (drPM_Respiratory_Protection["FK_Employee"] == DBNull.Value)
					this._FK_Employee = null;
				else
					this._FK_Employee = (decimal?)drPM_Respiratory_Protection["FK_Employee"];

				if (drPM_Respiratory_Protection["Date"] == DBNull.Value)
					this._Date = null;
				else
					this._Date = (DateTime?)drPM_Respiratory_Protection["Date"];

				if (drPM_Respiratory_Protection["Event_Type"] == DBNull.Value)
					this._Event_Type = null;
				else
					this._Event_Type = (string)drPM_Respiratory_Protection["Event_Type"];

				if (drPM_Respiratory_Protection["Medical_Evaluation"] == DBNull.Value)
					this._Medical_Evaluation = null;
				else
					this._Medical_Evaluation = (string)drPM_Respiratory_Protection["Medical_Evaluation"];

				if (drPM_Respiratory_Protection["Restrictions_Applied"] == DBNull.Value)
					this._Restrictions_Applied = null;
				else
					this._Restrictions_Applied = (string)drPM_Respiratory_Protection["Restrictions_Applied"];

				if (drPM_Respiratory_Protection["Restrictions"] == DBNull.Value)
					this._Restrictions = null;
				else
					this._Restrictions = (string)drPM_Respiratory_Protection["Restrictions"];

				if (drPM_Respiratory_Protection["Reevaluation_Required"] == DBNull.Value)
					this._Reevaluation_Required = null;
				else
					this._Reevaluation_Required = (string)drPM_Respiratory_Protection["Reevaluation_Required"];

				if (drPM_Respiratory_Protection["Reevaluation_Date"] == DBNull.Value)
					this._Reevaluation_Date = null;
				else
					this._Reevaluation_Date = (DateTime?)drPM_Respiratory_Protection["Reevaluation_Date"];

				if (drPM_Respiratory_Protection["Training_Completed"] == DBNull.Value)
					this._Training_Completed = null;
				else
					this._Training_Completed = (string)drPM_Respiratory_Protection["Training_Completed"];

				if (drPM_Respiratory_Protection["Training_Completion_Date"] == DBNull.Value)
					this._Training_Completion_Date = null;
				else
					this._Training_Completion_Date = (DateTime?)drPM_Respiratory_Protection["Training_Completion_Date"];

				if (drPM_Respiratory_Protection["Fit_Test"] == DBNull.Value)
					this._Fit_Test = null;
				else
					this._Fit_Test = (string)drPM_Respiratory_Protection["Fit_Test"];

				if (drPM_Respiratory_Protection["Fit_Test_Date"] == DBNull.Value)
					this._Fit_Test_Date = null;
				else
					this._Fit_Test_Date = (DateTime?)drPM_Respiratory_Protection["Fit_Test_Date"];

				if (drPM_Respiratory_Protection["Pass_Fail"] == DBNull.Value)
					this._Pass_Fail = null;
				else
					this._Pass_Fail = (string)drPM_Respiratory_Protection["Pass_Fail"];

				if (drPM_Respiratory_Protection["FK_LU_Respirator_Type"] == DBNull.Value)
					this._FK_LU_Respirator_Type = null;
				else
					this._FK_LU_Respirator_Type = (decimal?)drPM_Respiratory_Protection["FK_LU_Respirator_Type"];

				if (drPM_Respiratory_Protection["Vendor"] == DBNull.Value)
					this._Vendor = null;
				else
					this._Vendor = (string)drPM_Respiratory_Protection["Vendor"];

				if (drPM_Respiratory_Protection["Vendor_Representative"] == DBNull.Value)
					this._Vendor_Representative = null;
				else
					this._Vendor_Representative = (string)drPM_Respiratory_Protection["Vendor_Representative"];

				if (drPM_Respiratory_Protection["Vendor_Address"] == DBNull.Value)
					this._Vendor_Address = null;
				else
					this._Vendor_Address = (string)drPM_Respiratory_Protection["Vendor_Address"];

				if (drPM_Respiratory_Protection["Vendor_City"] == DBNull.Value)
					this._Vendor_City = null;
				else
					this._Vendor_City = (string)drPM_Respiratory_Protection["Vendor_City"];

				if (drPM_Respiratory_Protection["FK_Vendor_State"] == DBNull.Value)
					this._FK_Vendor_State = null;
				else
					this._FK_Vendor_State = (decimal?)drPM_Respiratory_Protection["FK_Vendor_State"];

				if (drPM_Respiratory_Protection["Vendor_Zip_Code"] == DBNull.Value)
					this._Vendor_Zip_Code = null;
				else
					this._Vendor_Zip_Code = (string)drPM_Respiratory_Protection["Vendor_Zip_Code"];

				if (drPM_Respiratory_Protection["Vendor_Telephone"] == DBNull.Value)
					this._Vendor_Telephone = null;
				else
					this._Vendor_Telephone = (string)drPM_Respiratory_Protection["Vendor_Telephone"];

				if (drPM_Respiratory_Protection["Vendor_EMail"] == DBNull.Value)
					this._Vendor_EMail = null;
				else
					this._Vendor_EMail = (string)drPM_Respiratory_Protection["Vendor_EMail"];

				if (drPM_Respiratory_Protection["Notes_Comments"] == DBNull.Value)
					this._Notes_Comments = null;
				else
					this._Notes_Comments = (string)drPM_Respiratory_Protection["Notes_Comments"];

				if (drPM_Respiratory_Protection["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Respiratory_Protection["Update_Date"];

				if (drPM_Respiratory_Protection["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Respiratory_Protection["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Respiratory_Protection table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Respiratory_ProtectionInsert");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);

			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			if (string.IsNullOrEmpty(this._Event_Type))
				db.AddInParameter(dbCommand, "Event_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Event_Type", DbType.String, this._Event_Type);
			
			if (string.IsNullOrEmpty(this._Medical_Evaluation))
				db.AddInParameter(dbCommand, "Medical_Evaluation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Medical_Evaluation", DbType.String, this._Medical_Evaluation);
			
			if (string.IsNullOrEmpty(this._Restrictions_Applied))
				db.AddInParameter(dbCommand, "Restrictions_Applied", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Restrictions_Applied", DbType.String, this._Restrictions_Applied);
			
			if (string.IsNullOrEmpty(this._Restrictions))
				db.AddInParameter(dbCommand, "Restrictions", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Restrictions", DbType.String, this._Restrictions);
			
			if (string.IsNullOrEmpty(this._Reevaluation_Required))
				db.AddInParameter(dbCommand, "Reevaluation_Required", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reevaluation_Required", DbType.String, this._Reevaluation_Required);
			
			db.AddInParameter(dbCommand, "Reevaluation_Date", DbType.DateTime, this._Reevaluation_Date);
			
			if (string.IsNullOrEmpty(this._Training_Completed))
				db.AddInParameter(dbCommand, "Training_Completed", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Training_Completed", DbType.String, this._Training_Completed);
			
			db.AddInParameter(dbCommand, "Training_Completion_Date", DbType.DateTime, this._Training_Completion_Date);
			
			if (string.IsNullOrEmpty(this._Fit_Test))
				db.AddInParameter(dbCommand, "Fit_Test", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fit_Test", DbType.String, this._Fit_Test);
			
			db.AddInParameter(dbCommand, "Fit_Test_Date", DbType.DateTime, this._Fit_Test_Date);
			
			if (string.IsNullOrEmpty(this._Pass_Fail))
				db.AddInParameter(dbCommand, "Pass_Fail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Pass_Fail", DbType.String, this._Pass_Fail);
			
			db.AddInParameter(dbCommand, "FK_LU_Respirator_Type", DbType.Decimal, this._FK_LU_Respirator_Type);
			
			if (string.IsNullOrEmpty(this._Vendor))
				db.AddInParameter(dbCommand, "Vendor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor", DbType.String, this._Vendor);
			
			if (string.IsNullOrEmpty(this._Vendor_Representative))
				db.AddInParameter(dbCommand, "Vendor_Representative", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Representative", DbType.String, this._Vendor_Representative);
			
			if (string.IsNullOrEmpty(this._Vendor_Address))
				db.AddInParameter(dbCommand, "Vendor_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Address", DbType.String, this._Vendor_Address);
			
			if (string.IsNullOrEmpty(this._Vendor_City))
				db.AddInParameter(dbCommand, "Vendor_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_City", DbType.String, this._Vendor_City);
			
			db.AddInParameter(dbCommand, "FK_Vendor_State", DbType.Decimal, this._FK_Vendor_State);
			
			if (string.IsNullOrEmpty(this._Vendor_Zip_Code))
				db.AddInParameter(dbCommand, "Vendor_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Zip_Code", DbType.String, this._Vendor_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Vendor_Telephone))
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, this._Vendor_Telephone);
			
			if (string.IsNullOrEmpty(this._Vendor_EMail))
				db.AddInParameter(dbCommand, "Vendor_EMail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_EMail", DbType.String, this._Vendor_EMail);
			
			if (string.IsNullOrEmpty(this._Notes_Comments))
				db.AddInParameter(dbCommand, "Notes_Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes_Comments", DbType.String, this._Notes_Comments);
			
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
		/// Selects a single record from the PM_Respiratory_Protection table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Respiratory_Protection)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Respiratory_ProtectionSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Respiratory_Protection", DbType.Decimal, pK_PM_Respiratory_Protection);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Respiratory_Protection table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Respiratory_ProtectionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Respiratory_Protection table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Respiratory_ProtectionUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Respiratory_Protection", DbType.Decimal, this._PK_PM_Respiratory_Protection);

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			if (string.IsNullOrEmpty(this._Event_Type))
				db.AddInParameter(dbCommand, "Event_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Event_Type", DbType.String, this._Event_Type);
			
			if (string.IsNullOrEmpty(this._Medical_Evaluation))
				db.AddInParameter(dbCommand, "Medical_Evaluation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Medical_Evaluation", DbType.String, this._Medical_Evaluation);
			
			if (string.IsNullOrEmpty(this._Restrictions_Applied))
				db.AddInParameter(dbCommand, "Restrictions_Applied", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Restrictions_Applied", DbType.String, this._Restrictions_Applied);
			
			if (string.IsNullOrEmpty(this._Restrictions))
				db.AddInParameter(dbCommand, "Restrictions", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Restrictions", DbType.String, this._Restrictions);
			
			if (string.IsNullOrEmpty(this._Reevaluation_Required))
				db.AddInParameter(dbCommand, "Reevaluation_Required", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reevaluation_Required", DbType.String, this._Reevaluation_Required);
			
			db.AddInParameter(dbCommand, "Reevaluation_Date", DbType.DateTime, this._Reevaluation_Date);
			
			if (string.IsNullOrEmpty(this._Training_Completed))
				db.AddInParameter(dbCommand, "Training_Completed", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Training_Completed", DbType.String, this._Training_Completed);
			
			db.AddInParameter(dbCommand, "Training_Completion_Date", DbType.DateTime, this._Training_Completion_Date);
			
			if (string.IsNullOrEmpty(this._Fit_Test))
				db.AddInParameter(dbCommand, "Fit_Test", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fit_Test", DbType.String, this._Fit_Test);
			
			db.AddInParameter(dbCommand, "Fit_Test_Date", DbType.DateTime, this._Fit_Test_Date);
			
			if (string.IsNullOrEmpty(this._Pass_Fail))
				db.AddInParameter(dbCommand, "Pass_Fail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Pass_Fail", DbType.String, this._Pass_Fail);
			
			db.AddInParameter(dbCommand, "FK_LU_Respirator_Type", DbType.Decimal, this._FK_LU_Respirator_Type);
			
			if (string.IsNullOrEmpty(this._Vendor))
				db.AddInParameter(dbCommand, "Vendor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor", DbType.String, this._Vendor);
			
			if (string.IsNullOrEmpty(this._Vendor_Representative))
				db.AddInParameter(dbCommand, "Vendor_Representative", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Representative", DbType.String, this._Vendor_Representative);
			
			if (string.IsNullOrEmpty(this._Vendor_Address))
				db.AddInParameter(dbCommand, "Vendor_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Address", DbType.String, this._Vendor_Address);
			
			if (string.IsNullOrEmpty(this._Vendor_City))
				db.AddInParameter(dbCommand, "Vendor_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_City", DbType.String, this._Vendor_City);
			
			db.AddInParameter(dbCommand, "FK_Vendor_State", DbType.Decimal, this._FK_Vendor_State);
			
			if (string.IsNullOrEmpty(this._Vendor_Zip_Code))
				db.AddInParameter(dbCommand, "Vendor_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Zip_Code", DbType.String, this._Vendor_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Vendor_Telephone))
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, this._Vendor_Telephone);
			
			if (string.IsNullOrEmpty(this._Vendor_EMail))
				db.AddInParameter(dbCommand, "Vendor_EMail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_EMail", DbType.String, this._Vendor_EMail);
			
			if (string.IsNullOrEmpty(this._Notes_Comments))
				db.AddInParameter(dbCommand, "Notes_Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes_Comments", DbType.String, this._Notes_Comments);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Respiratory_Protection table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Respiratory_Protection)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Respiratory_ProtectionDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Respiratory_Protection", DbType.Decimal, pK_PM_Respiratory_Protection);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Bind vendor lookup by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectVendorLookUpByPK(decimal PK_PM_Respiratory_Protection)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Respiratory_VendorLookUpByPK");

            db.AddInParameter(dbCommand, "PK_PM_Respiratory_Protection", DbType.Decimal, PK_PM_Respiratory_Protection);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Respiratory_ProtectionSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
