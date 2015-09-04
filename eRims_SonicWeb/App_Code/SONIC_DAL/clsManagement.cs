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
        private string _Record_Type_Other;
        private string _Work_To_Complete_Other;
        private decimal? _FK_LU_Work_Completed;
        private bool? _Work_Completed_By;
        private decimal? _Service_Repair_Cost;
        private decimal? _FK_LU_Record_Type;
        private string _Job;
        private DateTime? _Order_Date;
        private string _Requested_By;
        private string _Created_By;
        private decimal? _Previous_Contract_Amount;
        private decimal? _Revised_Contract_Amount;
        private string _Reason_for_Request;
        private string _Order;
        private string _GM_Email_To;
        private bool? _GM_Decision;
        private DateTime? _GM_Last_Email_Date;
        private DateTime? _GM_Response_Date;
        private string _RLCM_Email_To;
        private bool? _RLCM_Decision;
        private DateTime? _RLCM_Last_Email_Date;
        private DateTime? _RLCM_Response_Date;
        private string _NAPM_Email_To;
        private bool? _NAPM_Decision;
        private DateTime? _NAPM_Last_Email_Date;
        private DateTime? _NAPM_Response_Date;
        private string _DRM_Email_To;
        private bool? _DRM_Decision;
        private DateTime? _DRM_Last_Email_Date;
        private DateTime? _DRM_Response_Date;
        private string _Comment;
        private string _Reference_Number;
        private decimal? _FK_LU_Approval_Submission;

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

        /// <summary>
        /// Gets or sets the Record_Type_Other value.
        /// </summary>
        public string Record_Type_Other
        {
            get { return _Record_Type_Other; }
            set { _Record_Type_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Work_To_Complete_Other value.
        /// </summary>
        public string Work_To_Complete_Other
        {
            get { return _Work_To_Complete_Other; }
            set { _Work_To_Complete_Other = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Work_Completed value.
        /// </summary>
        public decimal? FK_LU_Work_Completed
        {
            get { return _FK_LU_Work_Completed; }
            set { _FK_LU_Work_Completed = value; }
        }

        /// <summary>
        /// Gets or sets the Work_Completed_By value.
        /// </summary>
        public bool? Work_Completed_By
        {
            get { return _Work_Completed_By; }
            set { _Work_Completed_By = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Repair_Cost value.
        /// </summary>
        public decimal? Service_Repair_Cost
        {
            get { return _Service_Repair_Cost; }
            set { _Service_Repair_Cost = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Record_Type value.
        /// </summary>
        public decimal? FK_LU_Record_Type
        {
            get { return _FK_LU_Record_Type; }
            set { _FK_LU_Record_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Job value.
        /// </summary>
        public string Job
        {
            get { return _Job; }
            set { _Job = value; }
        }

        /// <summary>
        /// Gets or sets the Order_Date value.
        /// </summary>
        public DateTime? Order_Date
        {
            get { return _Order_Date; }
            set { _Order_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Requested_By value.
        /// </summary>
        public string Requested_By
        {
            get { return _Requested_By; }
            set { _Requested_By = value; }
        }

        /// <summary>
        /// Gets or sets the Created_By value.
        /// </summary>
        public string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }

        /// <summary>
        /// Gets or sets the Previous_Contract_Amount value.
        /// </summary>
        public decimal? Previous_Contract_Amount
        {
            get { return _Previous_Contract_Amount; }
            set { _Previous_Contract_Amount = value; }
        }

        /// <summary>
        /// Gets or sets the Revised_Contract_Amount value.
        /// </summary>
        public decimal? Revised_Contract_Amount
        {
            get { return _Revised_Contract_Amount; }
            set { _Revised_Contract_Amount = value; }
        }

        /// <summary>
        /// Gets or sets the Reason_for_Request value.
        /// </summary>
        public string Reason_for_Request
        {
            get { return _Reason_for_Request; }
            set { _Reason_for_Request = value; }
        }

        /// <summary>
        /// Gets or sets the Order value.
        /// </summary>
        public string Order
        {
            get { return _Order; }
            set { _Order = value; }
        }

        /// <summary>
        /// Gets or sets the GM_Email_To value.
        /// </summary>
        public string GM_Email_To
        {
            get { return _GM_Email_To; }
            set { _GM_Email_To = value; }
        }

        /// <summary>
        /// Gets or sets the GM_Decision value.
        /// </summary>
        public bool? GM_Decision
        {
            get { return _GM_Decision; }
            set { _GM_Decision = value; }
        }

        /// <summary>
        /// Gets or sets the GM_Last_Email_Date value.
        /// </summary>
        public DateTime? GM_Last_Email_Date
        {
            get { return _GM_Last_Email_Date; }
            set { _GM_Last_Email_Date = value; }
        }

        /// <summary>
        /// Gets or sets the GM_Response_Date value.
        /// </summary>
        public DateTime? GM_Response_Date
        {
            get { return _GM_Response_Date; }
            set { _GM_Response_Date = value; }
        }

        /// <summary>
        /// Gets or sets the RLCM_Email_To value.
        /// </summary>
        public string RLCM_Email_To
        {
            get { return _RLCM_Email_To; }
            set { _RLCM_Email_To = value; }
        }

        /// <summary>
        /// Gets or sets the RLCM_Decision value.
        /// </summary>
        public bool? RLCM_Decision
        {
            get { return _RLCM_Decision; }
            set { _RLCM_Decision = value; }
        }

        /// <summary>
        /// Gets or sets the RLCM_Last_Email_Date value.
        /// </summary>
        public DateTime? RLCM_Last_Email_Date
        {
            get { return _RLCM_Last_Email_Date; }
            set { _RLCM_Last_Email_Date = value; }
        }

        /// <summary>
        /// Gets or sets the RLCM_Response_Date value.
        /// </summary>
        public DateTime? RLCM_Response_Date
        {
            get { return _RLCM_Response_Date; }
            set { _RLCM_Response_Date = value; }
        }

        /// <summary>
        /// Gets or sets the NAPM_Email_To value.
        /// </summary>
        public string NAPM_Email_To
        {
            get { return _NAPM_Email_To; }
            set { _NAPM_Email_To = value; }
        }

        /// <summary>
        /// Gets or sets the NAPM_Decision value.
        /// </summary>
        public bool? NAPM_Decision
        {
            get { return _NAPM_Decision; }
            set { _NAPM_Decision = value; }
        }

        /// <summary>
        /// Gets or sets the NAPM_Last_Email_Date value.
        /// </summary>
        public DateTime? NAPM_Last_Email_Date
        {
            get { return _NAPM_Last_Email_Date; }
            set { _NAPM_Last_Email_Date = value; }
        }

        /// <summary>
        /// Gets or sets the NAPM_Response_Date value.
        /// </summary>
        public DateTime? NAPM_Response_Date
        {
            get { return _NAPM_Response_Date; }
            set { _NAPM_Response_Date = value; }
        }

        /// <summary>
        /// Gets or sets the DRM_Email_To value.
        /// </summary>
        public string DRM_Email_To
        {
            get { return _DRM_Email_To; }
            set { _DRM_Email_To = value; }
        }

        /// <summary>
        /// Gets or sets the DRM_Decision value.
        /// </summary>
        public bool? DRM_Decision
        {
            get { return _DRM_Decision; }
            set { _DRM_Decision = value; }
        }

        /// <summary>
        /// Gets or sets the DRM_Last_Email_Date value.
        /// </summary>
        public DateTime? DRM_Last_Email_Date
        {
            get { return _DRM_Last_Email_Date; }
            set { _DRM_Last_Email_Date = value; }
        }

        /// <summary>
        /// Gets or sets the DRM_Response_Date value.
        /// </summary>
        public DateTime? DRM_Response_Date
        {
            get { return _DRM_Response_Date; }
            set { _DRM_Response_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Comment value.
        /// </summary>
        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }

        /// <summary>
        /// Gets or sets the Reference_Number value.
        /// </summary>
        public string Reference_Number
        {
            get { return _Reference_Number; }
            set { _Reference_Number = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Approval_Submission value.
        /// </summary>
        public decimal? FK_LU_Approval_Submission
        {
            get { return _FK_LU_Approval_Submission; }
            set { _FK_LU_Approval_Submission = value; }
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

                if (drManagement["Record_Type_Other"] == DBNull.Value)
                    this._Record_Type_Other = null;
                else
                    this._Record_Type_Other = (string)drManagement["Record_Type_Other"];

                if (drManagement["Work_To_Complete_Other"] == DBNull.Value)
                    this._Work_To_Complete_Other = null;
                else
                    this._Work_To_Complete_Other = (string)drManagement["Work_To_Complete_Other"];

                if (drManagement["FK_LU_Work_Completed"] == DBNull.Value)
                    this._FK_LU_Work_Completed = null;
                else
                    this._FK_LU_Work_Completed = (decimal?)drManagement["FK_LU_Work_Completed"];

                if (drManagement["Work_Completed_By"] == DBNull.Value)
                    this._Work_Completed_By = null;
                else
                    this._Work_Completed_By = (bool?)drManagement["Work_Completed_By"];

                if (drManagement["Service_Repair_Cost"] == DBNull.Value)
                    this._Service_Repair_Cost = null;
                else
                    this._Service_Repair_Cost = (decimal?)drManagement["Service_Repair_Cost"];

                if (drManagement["FK_LU_Record_Type"] == DBNull.Value)
                    this._FK_LU_Record_Type = null;
                else
                    this._FK_LU_Record_Type = (decimal?)drManagement["FK_LU_Record_Type"];

                if (drManagement["Job"] == DBNull.Value)
                    this._Job = null;
                else
                    this._Job = (string)drManagement["Job"];

                if (drManagement["Order_Date"] == DBNull.Value)
                    this._Order_Date = null;
                else
                    this._Order_Date = (DateTime?)drManagement["Order_Date"];

                if (drManagement["Requested_By"] == DBNull.Value)
                    this._Requested_By = null;
                else
                    this._Requested_By = (string)drManagement["Requested_By"];

                if (drManagement["Created_By"] == DBNull.Value)
                    this._Created_By = null;
                else
                    this._Created_By = (string)drManagement["Created_By"];

                if (drManagement["Previous_Contract_Amount"] == DBNull.Value)
                    this._Previous_Contract_Amount = null;
                else
                    this._Previous_Contract_Amount = (decimal?)drManagement["Previous_Contract_Amount"];

                if (drManagement["Revised_Contract_Amount"] == DBNull.Value)
                    this._Revised_Contract_Amount = null;
                else
                    this._Revised_Contract_Amount = (decimal?)drManagement["Revised_Contract_Amount"];

                if (drManagement["Reason_for_Request"] == DBNull.Value)
                    this._Reason_for_Request = null;
                else
                    this._Reason_for_Request = (string)drManagement["Reason_for_Request"];

                if (drManagement["Order"] == DBNull.Value)
                    this._Order = null;
                else
                    this._Order = (string)drManagement["Order"];

                if (drManagement["GM_Email_To"] == DBNull.Value)
                    this._GM_Email_To = null;
                else
                    this._GM_Email_To = (string)drManagement["GM_Email_To"];

                if (drManagement["GM_Decision"] == DBNull.Value)
                    this._GM_Decision = null;
                else
                    this._GM_Decision = (bool?)drManagement["GM_Decision"];

                if (drManagement["GM_Last_Email_Date"] == DBNull.Value)
                    this._GM_Last_Email_Date = null;
                else
                    this._GM_Last_Email_Date = (DateTime?)drManagement["GM_Last_Email_Date"];

                if (drManagement["GM_Response_Date"] == DBNull.Value)
                    this._GM_Response_Date = null;
                else
                    this._GM_Response_Date = (DateTime?)drManagement["GM_Response_Date"];

                if (drManagement["RLCM_Email_To"] == DBNull.Value)
                    this._RLCM_Email_To = null;
                else
                    this._RLCM_Email_To = (string)drManagement["RLCM_Email_To"];

                if (drManagement["RLCM_Decision"] == DBNull.Value)
                    this._RLCM_Decision = null;
                else
                    this._RLCM_Decision = (bool?)drManagement["RLCM_Decision"];

                if (drManagement["RLCM_Last_Email_Date"] == DBNull.Value)
                    this._RLCM_Last_Email_Date = null;
                else
                    this._RLCM_Last_Email_Date = (DateTime?)drManagement["RLCM_Last_Email_Date"];

                if (drManagement["RLCM_Response_Date"] == DBNull.Value)
                    this._RLCM_Response_Date = null;
                else
                    this._RLCM_Response_Date = (DateTime?)drManagement["RLCM_Response_Date"];

                if (drManagement["NAPM_Email_To"] == DBNull.Value)
                    this._NAPM_Email_To = null;
                else
                    this._NAPM_Email_To = (string)drManagement["NAPM_Email_To"];

                if (drManagement["NAPM_Decision"] == DBNull.Value)
                    this._NAPM_Decision = null;
                else
                    this._NAPM_Decision = (bool?)drManagement["NAPM_Decision"];

                if (drManagement["NAPM_Last_Email_Date"] == DBNull.Value)
                    this._NAPM_Last_Email_Date = null;
                else
                    this._NAPM_Last_Email_Date = (DateTime?)drManagement["NAPM_Last_Email_Date"];

                if (drManagement["NAPM_Response_Date"] == DBNull.Value)
                    this._NAPM_Response_Date = null;
                else
                    this._NAPM_Response_Date = (DateTime?)drManagement["NAPM_Response_Date"];

                if (drManagement["DRM_Email_To"] == DBNull.Value)
                    this._DRM_Email_To = null;
                else
                    this._DRM_Email_To = (string)drManagement["DRM_Email_To"];

                if (drManagement["DRM_Decision"] == DBNull.Value)
                    this._DRM_Decision = null;
                else
                    this._DRM_Decision = (bool?)drManagement["DRM_Decision"];

                if (drManagement["DRM_Last_Email_Date"] == DBNull.Value)
                    this._DRM_Last_Email_Date = null;
                else
                    this._DRM_Last_Email_Date = (DateTime?)drManagement["DRM_Last_Email_Date"];

                if (drManagement["DRM_Response_Date"] == DBNull.Value)
                    this._DRM_Response_Date = null;
                else
                    this._DRM_Response_Date = (DateTime?)drManagement["DRM_Response_Date"];

                if (drManagement["Comment"] == DBNull.Value)
                    this._Comment = null;
                else
                    this._Comment = (string)drManagement["Comment"];

                if (drManagement["Reference_Number"] == DBNull.Value)
                    this._Reference_Number = null;
                else
                    this._Reference_Number = (string)drManagement["Reference_Number"];

                if (drManagement["FK_LU_Approval_Submission"] == DBNull.Value)
                    this._FK_LU_Approval_Submission = null;
                else
                    this._FK_LU_Approval_Submission = (decimal?)drManagement["FK_LU_Approval_Submission"];
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

            if (string.IsNullOrEmpty(this._Record_Type_Other))
                db.AddInParameter(dbCommand, "Record_Type_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Record_Type_Other", DbType.String, this._Record_Type_Other);

            if (string.IsNullOrEmpty(this._Work_To_Complete_Other))
                db.AddInParameter(dbCommand, "Work_To_Complete_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_To_Complete_Other", DbType.String, this._Work_To_Complete_Other);

            db.AddInParameter(dbCommand, "FK_LU_Work_Completed", DbType.Decimal, this._FK_LU_Work_Completed);

            db.AddInParameter(dbCommand, "Work_Completed_By", DbType.Boolean, this._Work_Completed_By);

            db.AddInParameter(dbCommand, "Service_Repair_Cost", DbType.Decimal, this._Service_Repair_Cost);

            db.AddInParameter(dbCommand, "FK_LU_Record_Type", DbType.Decimal, this._FK_LU_Record_Type);

            if (string.IsNullOrEmpty(this._Job))
                db.AddInParameter(dbCommand, "Job", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Job", DbType.String, this._Job);

            db.AddInParameter(dbCommand, "Order_Date", DbType.DateTime, this._Order_Date);

            if (string.IsNullOrEmpty(this._Requested_By))
                db.AddInParameter(dbCommand, "Requested_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requested_By", DbType.String, this._Requested_By);

            if (string.IsNullOrEmpty(this._Created_By))
                db.AddInParameter(dbCommand, "Created_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Created_By", DbType.String, this._Created_By);

            db.AddInParameter(dbCommand, "Previous_Contract_Amount", DbType.Decimal, this._Previous_Contract_Amount);

            db.AddInParameter(dbCommand, "Revised_Contract_Amount", DbType.Decimal, this._Revised_Contract_Amount);

            if (string.IsNullOrEmpty(this._Reason_for_Request))
                db.AddInParameter(dbCommand, "Reason_for_Request", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reason_for_Request", DbType.String, this._Reason_for_Request);

            if (string.IsNullOrEmpty(this._Order))
                db.AddInParameter(dbCommand, "order", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "order", DbType.String, this._Order);

            if (string.IsNullOrEmpty(this._GM_Email_To))
                db.AddInParameter(dbCommand, "GM_Email_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "GM_Email_To", DbType.String, this._GM_Email_To);

            db.AddInParameter(dbCommand, "GM_Decision", DbType.Boolean, this._GM_Decision);

            db.AddInParameter(dbCommand, "GM_Last_Email_Date", DbType.DateTime, this._GM_Last_Email_Date);

            db.AddInParameter(dbCommand, "GM_Response_Date", DbType.DateTime, this._GM_Response_Date);

            if (string.IsNullOrEmpty(this._RLCM_Email_To))
                db.AddInParameter(dbCommand, "RLCM_Email_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Email_To", DbType.String, this._RLCM_Email_To);

            db.AddInParameter(dbCommand, "RLCM_Decision", DbType.Boolean, this._RLCM_Decision);

            db.AddInParameter(dbCommand, "RLCM_Last_Email_Date", DbType.DateTime, this._RLCM_Last_Email_Date);

            db.AddInParameter(dbCommand, "RLCM_Response_Date", DbType.DateTime, this._RLCM_Response_Date);

            if (string.IsNullOrEmpty(this._NAPM_Email_To))
                db.AddInParameter(dbCommand, "NAPM_Email_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "NAPM_Email_To", DbType.String, this._NAPM_Email_To);

            db.AddInParameter(dbCommand, "NAPM_Decision", DbType.Boolean, this._NAPM_Decision);

            db.AddInParameter(dbCommand, "NAPM_Last_Email_Date", DbType.DateTime, this._NAPM_Last_Email_Date);

            db.AddInParameter(dbCommand, "NAPM_Response_Date", DbType.DateTime, this._NAPM_Response_Date);

            if (string.IsNullOrEmpty(this._DRM_Email_To))
                db.AddInParameter(dbCommand, "DRM_Email_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DRM_Email_To", DbType.String, this._DRM_Email_To);

            db.AddInParameter(dbCommand, "DRM_Decision", DbType.Boolean, this._DRM_Decision);

            db.AddInParameter(dbCommand, "DRM_Last_Email_Date", DbType.DateTime, this._DRM_Last_Email_Date);

            db.AddInParameter(dbCommand, "DRM_Response_Date", DbType.DateTime, this._DRM_Response_Date);

            if (string.IsNullOrEmpty(this._Comment))
                db.AddInParameter(dbCommand, "Comment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comment", DbType.String, this._Comment);

            db.AddInParameter(dbCommand, "FK_LU_Approval_Submission", DbType.Decimal, this._FK_LU_Approval_Submission);

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

            if (string.IsNullOrEmpty(this._Record_Type_Other))
                db.AddInParameter(dbCommand, "Record_Type_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Record_Type_Other", DbType.String, this._Record_Type_Other);

            if (string.IsNullOrEmpty(this._Work_To_Complete_Other))
                db.AddInParameter(dbCommand, "Work_To_Complete_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_To_Complete_Other", DbType.String, this._Work_To_Complete_Other);

            db.AddInParameter(dbCommand, "FK_LU_Work_Completed", DbType.Decimal, this._FK_LU_Work_Completed);

            db.AddInParameter(dbCommand, "Work_Completed_By", DbType.Boolean, this._Work_Completed_By);

            db.AddInParameter(dbCommand, "Service_Repair_Cost", DbType.Decimal, this._Service_Repair_Cost);

            db.AddInParameter(dbCommand, "FK_LU_Record_Type", DbType.Decimal, this._FK_LU_Record_Type);

            if (string.IsNullOrEmpty(this._Job))
                db.AddInParameter(dbCommand, "Job", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Job", DbType.String, this._Job);

            db.AddInParameter(dbCommand, "Order_Date", DbType.DateTime, this._Order_Date);

            if (string.IsNullOrEmpty(this._Requested_By))
                db.AddInParameter(dbCommand, "Requested_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requested_By", DbType.String, this._Requested_By);

            if (string.IsNullOrEmpty(this._Created_By))
                db.AddInParameter(dbCommand, "Created_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Created_By", DbType.String, this._Created_By);

            db.AddInParameter(dbCommand, "Previous_Contract_Amount", DbType.Decimal, this._Previous_Contract_Amount);

            db.AddInParameter(dbCommand, "Revised_Contract_Amount", DbType.Decimal, this._Revised_Contract_Amount);

            if (string.IsNullOrEmpty(this._Reason_for_Request))
                db.AddInParameter(dbCommand, "Reason_for_Request", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reason_for_Request", DbType.String, this._Reason_for_Request);

            if (string.IsNullOrEmpty(this._Order))
                db.AddInParameter(dbCommand, "Order", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Order", DbType.String, this._Order);

            if (string.IsNullOrEmpty(this._GM_Email_To))
                db.AddInParameter(dbCommand, "GM_Email_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "GM_Email_To", DbType.String, this._GM_Email_To);

            db.AddInParameter(dbCommand, "GM_Decision", DbType.Boolean, this._GM_Decision);

            db.AddInParameter(dbCommand, "GM_Last_Email_Date", DbType.DateTime, this._GM_Last_Email_Date);

            db.AddInParameter(dbCommand, "GM_Response_Date", DbType.DateTime, this._GM_Response_Date);

            if (string.IsNullOrEmpty(this._RLCM_Email_To))
                db.AddInParameter(dbCommand, "RLCM_Email_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Email_To", DbType.String, this._RLCM_Email_To);

            db.AddInParameter(dbCommand, "RLCM_Decision", DbType.Boolean, this._RLCM_Decision);

            db.AddInParameter(dbCommand, "RLCM_Last_Email_Date", DbType.DateTime, this._RLCM_Last_Email_Date);

            db.AddInParameter(dbCommand, "RLCM_Response_Date", DbType.DateTime, this._RLCM_Response_Date);

            if (string.IsNullOrEmpty(this._NAPM_Email_To))
                db.AddInParameter(dbCommand, "NAPM_Email_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "NAPM_Email_To", DbType.String, this._NAPM_Email_To);

            db.AddInParameter(dbCommand, "NAPM_Decision", DbType.Boolean, this._NAPM_Decision);

            db.AddInParameter(dbCommand, "NAPM_Last_Email_Date", DbType.DateTime, this._NAPM_Last_Email_Date);

            db.AddInParameter(dbCommand, "NAPM_Response_Date", DbType.DateTime, this._NAPM_Response_Date);

            if (string.IsNullOrEmpty(this._DRM_Email_To))
                db.AddInParameter(dbCommand, "DRM_Email_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DRM_Email_To", DbType.String, this._DRM_Email_To);

            db.AddInParameter(dbCommand, "DRM_Decision", DbType.Boolean, this._DRM_Decision);

            db.AddInParameter(dbCommand, "DRM_Last_Email_Date", DbType.DateTime, this._DRM_Last_Email_Date);

            db.AddInParameter(dbCommand, "DRM_Response_Date", DbType.DateTime, this._DRM_Response_Date);

            if (string.IsNullOrEmpty(this._Comment))
                db.AddInParameter(dbCommand, "Comment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comment", DbType.String, this._Comment);

            db.AddInParameter(dbCommand, "FK_LU_Approval_Submission", DbType.Decimal, this._FK_LU_Approval_Submission);

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

        public static DataSet ManagementSearch(decimal? FK_LU_Location, decimal? FK_LU_Work_Completed, string Work_To_Complete_Other, decimal? FK_LU_Record_Type, string Record_Type_Other, string Created_By, string Job, string Order, DateTime? Date_Scheduled_From, DateTime? Date_Scheduled_To,
            DateTime? Date_Complete_From, DateTime? Date_Complete_To, DateTime? CR_Approved_From, DateTime? CR_Approved_To, decimal? Location_Code, bool? Work_Completed_By, bool? Task_Complete, string strOrderBy, string strOrder, int intPageNo, int intPageSize, string ReferenceNumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ManagementSearch");

            //db.AddInParameter(dbCommand, "Company", DbType.String, Company);
            //db.AddInParameter(dbCommand, "City", DbType.String, City);
            //db.AddInParameter(dbCommand, "County", DbType.String, County);
            //db.AddInParameter(dbCommand, "Camera_Number", DbType.String, Camera_Number);
            //db.AddInParameter(dbCommand, "Cost", DbType.Decimal, Cost);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            //db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, FK_LU_State);
            //db.AddInParameter(dbCommand, "FK_LU_Region", DbType.Decimal, FK_LU_Region);
            //db.AddInParameter(dbCommand, "FK_LU_Camera_Type", DbType.Decimal, FK_LU_Camera_Type);
            //db.AddInParameter(dbCommand, "FK_LU_Client_Issue", DbType.String, FK_LU_Client_Issue);
            //db.AddInParameter(dbCommand, "FK_LU_Facilities_Issue", DbType.String, FK_LU_Facilities_Issue);
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

            db.AddInParameter(dbCommand, "FK_LU_Work_Completed", DbType.Decimal, FK_LU_Work_Completed);
            db.AddInParameter(dbCommand, "FK_LU_Record_Type", DbType.Decimal, FK_LU_Record_Type);
            db.AddInParameter(dbCommand, "Work_To_Complete_Other", DbType.String, Work_To_Complete_Other);
            db.AddInParameter(dbCommand, "Record_Type_Other", DbType.String, Record_Type_Other);
            db.AddInParameter(dbCommand, "Created_By", DbType.String, Created_By);
            db.AddInParameter(dbCommand, "Job", DbType.String, Job);
            db.AddInParameter(dbCommand, "Order", DbType.String, Order);
            db.AddInParameter(dbCommand, "Work_Completed_By", DbType.Boolean, Work_Completed_By);
            db.AddInParameter(dbCommand, "ReferenceNumber", DbType.String, ReferenceNumber);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Management table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetManagementAbstractLetterData(decimal pK_Management_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ManagementAbstractLetterData");

            db.AddInParameter(dbCommand, "PK_Management_ID", DbType.Decimal, pK_Management_ID);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
