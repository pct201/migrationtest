using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Event_Video_Tracking_Request table.
	/// </summary>
	public sealed class clsEvent_Video_Tracking_Request
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Event_Video_Tracking_Request;
		private string _Request_Number;
		private string _Request_Type;
		private decimal? _FK_Event;
		private decimal? _FK_LU_Location;
		private decimal? _FK_LU_Type_of_Activity;
		private decimal? _Status;
		private DateTime? _Date_Of_Event;
		private DateTime? _Date_Of_Request;
		private decimal? _FK_Security;
		private string _Full_Name;
		private string _Work_Phone;
		private string _Location;
		private string _Alternate_Phone;
		private string _Reason_Request;
		private string _Camera_Name;
		private string _Event_Start_Time;
		private string _Event_End_Time;
		private string _Video_Link_Email;
		private string _Still_Shots_Email;
		private decimal? _No_DVD_Copy;
		private string _Urgent_Need;
		private string _Mailing_Address;
		private string _Shipping_Method;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private string _Created_By;
		private DateTime? _Create_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Event_Video_Tracking_Request value.
		/// </summary>
		public decimal? PK_Event_Video_Tracking_Request
		{
			get { return _PK_Event_Video_Tracking_Request; }
			set { _PK_Event_Video_Tracking_Request = value; }
		}

		/// <summary>
		/// Gets or sets the Request_Number value.
		/// </summary>
		public string Request_Number
		{
			get { return _Request_Number; }
			set { _Request_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Request_Type value.
		/// </summary>
		public string Request_Type
		{
			get { return _Request_Type; }
			set { _Request_Type = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Event value.
		/// </summary>
		public decimal? FK_Event
		{
			get { return _FK_Event; }
			set { _FK_Event = value; }
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
		/// Gets or sets the FK_LU_Type_of_Activity value.
		/// </summary>
		public decimal? FK_LU_Type_of_Activity
		{
			get { return _FK_LU_Type_of_Activity; }
			set { _FK_LU_Type_of_Activity = value; }
		}

		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public decimal? Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Of_Event value.
		/// </summary>
		public DateTime? Date_Of_Event
		{
			get { return _Date_Of_Event; }
			set { _Date_Of_Event = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Of_Request value.
		/// </summary>
		public DateTime? Date_Of_Request
		{
			get { return _Date_Of_Request; }
			set { _Date_Of_Request = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Security value.
		/// </summary>
		public decimal? FK_Security
		{
			get { return _FK_Security; }
			set { _FK_Security = value; }
		}

		/// <summary>
		/// Gets or sets the Full_Name value.
		/// </summary>
		public string Full_Name
		{
			get { return _Full_Name; }
			set { _Full_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Work_Phone value.
		/// </summary>
		public string Work_Phone
		{
			get { return _Work_Phone; }
			set { _Work_Phone = value; }
		}

		/// <summary>
		/// Gets or sets the Location value.
		/// </summary>
		public string Location
		{
			get { return _Location; }
			set { _Location = value; }
		}

		/// <summary>
		/// Gets or sets the Alternate_Phone value.
		/// </summary>
		public string Alternate_Phone
		{
			get { return _Alternate_Phone; }
			set { _Alternate_Phone = value; }
		}

		/// <summary>
		/// Gets or sets the Reason_Request value.
		/// </summary>
		public string Reason_Request
		{
			get { return _Reason_Request; }
			set { _Reason_Request = value; }
		}

		/// <summary>
		/// Gets or sets the Camera_Name value.
		/// </summary>
		public string Camera_Name
		{
			get { return _Camera_Name; }
			set { _Camera_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Event_Start_Time value.
		/// </summary>
		public string Event_Start_Time
		{
			get { return _Event_Start_Time; }
			set { _Event_Start_Time = value; }
		}

		/// <summary>
		/// Gets or sets the Event_End_Time value.
		/// </summary>
		public string Event_End_Time
		{
			get { return _Event_End_Time; }
			set { _Event_End_Time = value; }
		}

		/// <summary>
		/// Gets or sets the Video_Link_Email value.
		/// </summary>
		public string Video_Link_Email
		{
			get { return _Video_Link_Email; }
			set { _Video_Link_Email = value; }
		}

		/// <summary>
		/// Gets or sets the Still_Shots_Email value.
		/// </summary>
		public string Still_Shots_Email
		{
			get { return _Still_Shots_Email; }
			set { _Still_Shots_Email = value; }
		}

		/// <summary>
		/// Gets or sets the No_DVD_Copy value.
		/// </summary>
		public decimal? No_DVD_Copy
		{
			get { return _No_DVD_Copy; }
			set { _No_DVD_Copy = value; }
		}

		/// <summary>
		/// Gets or sets the Urgent_Need value.
		/// </summary>
		public string Urgent_Need
		{
			get { return _Urgent_Need; }
			set { _Urgent_Need = value; }
		}

		/// <summary>
		/// Gets or sets the Mailing_Address value.
		/// </summary>
		public string Mailing_Address
		{
			get { return _Mailing_Address; }
			set { _Mailing_Address = value; }
		}

		/// <summary>
		/// Gets or sets the Shipping_Method value.
		/// </summary>
		public string Shipping_Method
		{
			get { return _Shipping_Method; }
			set { _Shipping_Method = value; }
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
		/// Gets or sets the Created_By value.
		/// </summary>
		public string Created_By
		{
			get { return _Created_By; }
			set { _Created_By = value; }
		}

		/// <summary>
		/// Gets or sets the Create_Date value.
		/// </summary>
		public DateTime? Create_Date
		{
			get { return _Create_Date; }
			set { _Create_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsEvent_Video_Tracking_Request class with default value.
		/// </summary>
		public clsEvent_Video_Tracking_Request() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsEvent_Video_Tracking_Request class based on Primary Key.
		/// </summary>
		public clsEvent_Video_Tracking_Request(decimal pK_Event_Video_Tracking_Request) 
		{
			DataTable dtEvent_Video_Tracking_Request = SelectByPK(pK_Event_Video_Tracking_Request).Tables[0];

			if (dtEvent_Video_Tracking_Request.Rows.Count == 1)
			{
				 SetValue(dtEvent_Video_Tracking_Request.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsEvent_Video_Tracking_Request class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drEvent_Video_Tracking_Request) 
		{
				if (drEvent_Video_Tracking_Request["PK_Event_Video_Tracking_Request"] == DBNull.Value)
					this._PK_Event_Video_Tracking_Request = null;
				else
					this._PK_Event_Video_Tracking_Request = (decimal?)drEvent_Video_Tracking_Request["PK_Event_Video_Tracking_Request"];

				if (drEvent_Video_Tracking_Request["Request_Number"] == DBNull.Value)
					this._Request_Number = null;
				else
					this._Request_Number = (string)drEvent_Video_Tracking_Request["Request_Number"];

				if (drEvent_Video_Tracking_Request["Request_Type"] == DBNull.Value)
					this._Request_Type = null;
				else
					this._Request_Type = (string)drEvent_Video_Tracking_Request["Request_Type"];

				if (drEvent_Video_Tracking_Request["FK_Event"] == DBNull.Value)
					this._FK_Event = null;
				else
					this._FK_Event = (decimal?)drEvent_Video_Tracking_Request["FK_Event"];

				if (drEvent_Video_Tracking_Request["FK_LU_Location"] == DBNull.Value)
					this._FK_LU_Location = null;
				else
					this._FK_LU_Location = (decimal?)drEvent_Video_Tracking_Request["FK_LU_Location"];

				if (drEvent_Video_Tracking_Request["FK_LU_Type_of_Activity"] == DBNull.Value)
					this._FK_LU_Type_of_Activity = null;
				else
					this._FK_LU_Type_of_Activity = (decimal?)drEvent_Video_Tracking_Request["FK_LU_Type_of_Activity"];

				if (drEvent_Video_Tracking_Request["Status"] == DBNull.Value)
					this._Status = null;
				else
					this._Status = (decimal?)drEvent_Video_Tracking_Request["Status"];

				if (drEvent_Video_Tracking_Request["Date_Of_Event"] == DBNull.Value)
					this._Date_Of_Event = null;
				else
					this._Date_Of_Event = (DateTime?)drEvent_Video_Tracking_Request["Date_Of_Event"];

				if (drEvent_Video_Tracking_Request["Date_Of_Request"] == DBNull.Value)
					this._Date_Of_Request = null;
				else
					this._Date_Of_Request = (DateTime?)drEvent_Video_Tracking_Request["Date_Of_Request"];

				if (drEvent_Video_Tracking_Request["FK_Security"] == DBNull.Value)
					this._FK_Security = null;
				else
					this._FK_Security = (decimal?)drEvent_Video_Tracking_Request["FK_Security"];

				if (drEvent_Video_Tracking_Request["Full_Name"] == DBNull.Value)
					this._Full_Name = null;
				else
					this._Full_Name = (string)drEvent_Video_Tracking_Request["Full_Name"];

				if (drEvent_Video_Tracking_Request["Work_Phone"] == DBNull.Value)
					this._Work_Phone = null;
				else
					this._Work_Phone = (string)drEvent_Video_Tracking_Request["Work_Phone"];

				if (drEvent_Video_Tracking_Request["Location"] == DBNull.Value)
					this._Location = null;
				else
					this._Location = (string)drEvent_Video_Tracking_Request["Location"];

				if (drEvent_Video_Tracking_Request["Alternate_Phone"] == DBNull.Value)
					this._Alternate_Phone = null;
				else
					this._Alternate_Phone = (string)drEvent_Video_Tracking_Request["Alternate_Phone"];

				if (drEvent_Video_Tracking_Request["Reason_Request"] == DBNull.Value)
					this._Reason_Request = null;
				else
					this._Reason_Request = (string)drEvent_Video_Tracking_Request["Reason_Request"];

				if (drEvent_Video_Tracking_Request["Camera_Name"] == DBNull.Value)
					this._Camera_Name = null;
				else
					this._Camera_Name = (string)drEvent_Video_Tracking_Request["Camera_Name"];

				if (drEvent_Video_Tracking_Request["Event_Start_Time"] == DBNull.Value)
					this._Event_Start_Time = null;
				else
					this._Event_Start_Time = (string)drEvent_Video_Tracking_Request["Event_Start_Time"];

				if (drEvent_Video_Tracking_Request["Event_End_Time"] == DBNull.Value)
					this._Event_End_Time = null;
				else
					this._Event_End_Time = (string)drEvent_Video_Tracking_Request["Event_End_Time"];

				if (drEvent_Video_Tracking_Request["Video_Link_Email"] == DBNull.Value)
					this._Video_Link_Email = null;
				else
					this._Video_Link_Email = (string)drEvent_Video_Tracking_Request["Video_Link_Email"];

				if (drEvent_Video_Tracking_Request["Still_Shots_Email"] == DBNull.Value)
					this._Still_Shots_Email = null;
				else
					this._Still_Shots_Email = (string)drEvent_Video_Tracking_Request["Still_Shots_Email"];

				if (drEvent_Video_Tracking_Request["No_DVD_Copy"] == DBNull.Value)
					this._No_DVD_Copy = null;
				else
					this._No_DVD_Copy = (decimal?)drEvent_Video_Tracking_Request["No_DVD_Copy"];

				if (drEvent_Video_Tracking_Request["Urgent_Need"] == DBNull.Value)
					this._Urgent_Need = null;
				else
					this._Urgent_Need = (string)drEvent_Video_Tracking_Request["Urgent_Need"];

				if (drEvent_Video_Tracking_Request["Mailing_Address"] == DBNull.Value)
					this._Mailing_Address = null;
				else
					this._Mailing_Address = (string)drEvent_Video_Tracking_Request["Mailing_Address"];

				if (drEvent_Video_Tracking_Request["Shipping_Method"] == DBNull.Value)
					this._Shipping_Method = null;
				else
					this._Shipping_Method = (string)drEvent_Video_Tracking_Request["Shipping_Method"];

				if (drEvent_Video_Tracking_Request["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drEvent_Video_Tracking_Request["Updated_By"];

				if (drEvent_Video_Tracking_Request["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drEvent_Video_Tracking_Request["Update_Date"];

				if (drEvent_Video_Tracking_Request["Created_By"] == DBNull.Value)
					this._Created_By = null;
				else
					this._Created_By = (string)drEvent_Video_Tracking_Request["Created_By"];

				if (drEvent_Video_Tracking_Request["Create_Date"] == DBNull.Value)
					this._Create_Date = null;
				else
					this._Create_Date = (DateTime?)drEvent_Video_Tracking_Request["Create_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Event_Video_Tracking_Request table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_Video_Tracking_RequestInsert");

			
			if (string.IsNullOrEmpty(this._Request_Number))
				db.AddInParameter(dbCommand, "Request_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Request_Number", DbType.String, this._Request_Number);
			
			if (string.IsNullOrEmpty(this._Request_Type))
				db.AddInParameter(dbCommand, "Request_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Request_Type", DbType.String, this._Request_Type);
			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			db.AddInParameter(dbCommand, "FK_LU_Type_of_Activity", DbType.Decimal, this._FK_LU_Type_of_Activity);
			
			db.AddInParameter(dbCommand, "Status", DbType.Decimal, this._Status);
			
			db.AddInParameter(dbCommand, "Date_Of_Event", DbType.DateTime, this._Date_Of_Event);
			
			db.AddInParameter(dbCommand, "Date_Of_Request", DbType.DateTime, this._Date_Of_Request);
			
			db.AddInParameter(dbCommand, "FK_Security", DbType.Decimal, this._FK_Security);
			
			if (string.IsNullOrEmpty(this._Full_Name))
				db.AddInParameter(dbCommand, "Full_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Full_Name", DbType.String, this._Full_Name);
			
			if (string.IsNullOrEmpty(this._Work_Phone))
				db.AddInParameter(dbCommand, "Work_Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Work_Phone", DbType.String, this._Work_Phone);
			
			if (string.IsNullOrEmpty(this._Location))
				db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
			
			if (string.IsNullOrEmpty(this._Alternate_Phone))
				db.AddInParameter(dbCommand, "Alternate_Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Alternate_Phone", DbType.String, this._Alternate_Phone);
			
			if (string.IsNullOrEmpty(this._Reason_Request))
				db.AddInParameter(dbCommand, "Reason_Request", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reason_Request", DbType.String, this._Reason_Request);
			
			if (string.IsNullOrEmpty(this._Camera_Name))
				db.AddInParameter(dbCommand, "Camera_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Camera_Name", DbType.String, this._Camera_Name);
			
			if (string.IsNullOrEmpty(this._Event_Start_Time))
				db.AddInParameter(dbCommand, "Event_Start_Time", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Event_Start_Time", DbType.String, this._Event_Start_Time);
			
			if (string.IsNullOrEmpty(this._Event_End_Time))
				db.AddInParameter(dbCommand, "Event_End_Time", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Event_End_Time", DbType.String, this._Event_End_Time);
			
			if (string.IsNullOrEmpty(this._Video_Link_Email))
				db.AddInParameter(dbCommand, "Video_Link_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Video_Link_Email", DbType.String, this._Video_Link_Email);
			
			if (string.IsNullOrEmpty(this._Still_Shots_Email))
				db.AddInParameter(dbCommand, "Still_Shots_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Still_Shots_Email", DbType.String, this._Still_Shots_Email);
			
			db.AddInParameter(dbCommand, "No_DVD_Copy", DbType.Decimal, this._No_DVD_Copy);
			
			if (string.IsNullOrEmpty(this._Urgent_Need))
				db.AddInParameter(dbCommand, "Urgent_Need", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Urgent_Need", DbType.String, this._Urgent_Need);
			
			if (string.IsNullOrEmpty(this._Mailing_Address))
				db.AddInParameter(dbCommand, "Mailing_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Mailing_Address", DbType.String, this._Mailing_Address);
			
			if (string.IsNullOrEmpty(this._Shipping_Method))
				db.AddInParameter(dbCommand, "Shipping_Method", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Shipping_Method", DbType.String, this._Shipping_Method);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Created_By))
				db.AddInParameter(dbCommand, "Created_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Created_By", DbType.String, this._Created_By);
			
			db.AddInParameter(dbCommand, "Create_Date", DbType.DateTime, this._Create_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Event_Video_Tracking_Request table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Event_Video_Tracking_Request)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_Video_Tracking_RequestSelectByPK");

			db.AddInParameter(dbCommand, "PK_Event_Video_Tracking_Request", DbType.Decimal, pK_Event_Video_Tracking_Request);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Event_Video_Tracking_Request table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_Video_Tracking_RequestSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Event_Video_Tracking_Request table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_Video_Tracking_RequestUpdate");

			
			db.AddInParameter(dbCommand, "PK_Event_Video_Tracking_Request", DbType.Decimal, this._PK_Event_Video_Tracking_Request);
			
			if (string.IsNullOrEmpty(this._Request_Number))
				db.AddInParameter(dbCommand, "Request_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Request_Number", DbType.String, this._Request_Number);
			
			if (string.IsNullOrEmpty(this._Request_Type))
				db.AddInParameter(dbCommand, "Request_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Request_Type", DbType.String, this._Request_Type);
			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			db.AddInParameter(dbCommand, "FK_LU_Type_of_Activity", DbType.Decimal, this._FK_LU_Type_of_Activity);
			
			db.AddInParameter(dbCommand, "Status", DbType.Decimal, this._Status);
			
			db.AddInParameter(dbCommand, "Date_Of_Event", DbType.DateTime, this._Date_Of_Event);
			
			db.AddInParameter(dbCommand, "Date_Of_Request", DbType.DateTime, this._Date_Of_Request);
			
			db.AddInParameter(dbCommand, "FK_Security", DbType.Decimal, this._FK_Security);
			
			if (string.IsNullOrEmpty(this._Full_Name))
				db.AddInParameter(dbCommand, "Full_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Full_Name", DbType.String, this._Full_Name);
			
			if (string.IsNullOrEmpty(this._Work_Phone))
				db.AddInParameter(dbCommand, "Work_Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Work_Phone", DbType.String, this._Work_Phone);
			
			if (string.IsNullOrEmpty(this._Location))
				db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
			
			if (string.IsNullOrEmpty(this._Alternate_Phone))
				db.AddInParameter(dbCommand, "Alternate_Phone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Alternate_Phone", DbType.String, this._Alternate_Phone);
			
			if (string.IsNullOrEmpty(this._Reason_Request))
				db.AddInParameter(dbCommand, "Reason_Request", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reason_Request", DbType.String, this._Reason_Request);
			
			if (string.IsNullOrEmpty(this._Camera_Name))
				db.AddInParameter(dbCommand, "Camera_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Camera_Name", DbType.String, this._Camera_Name);
			
			if (string.IsNullOrEmpty(this._Event_Start_Time))
				db.AddInParameter(dbCommand, "Event_Start_Time", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Event_Start_Time", DbType.String, this._Event_Start_Time);
			
			if (string.IsNullOrEmpty(this._Event_End_Time))
				db.AddInParameter(dbCommand, "Event_End_Time", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Event_End_Time", DbType.String, this._Event_End_Time);
			
			if (string.IsNullOrEmpty(this._Video_Link_Email))
				db.AddInParameter(dbCommand, "Video_Link_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Video_Link_Email", DbType.String, this._Video_Link_Email);
			
			if (string.IsNullOrEmpty(this._Still_Shots_Email))
				db.AddInParameter(dbCommand, "Still_Shots_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Still_Shots_Email", DbType.String, this._Still_Shots_Email);
			
			db.AddInParameter(dbCommand, "No_DVD_Copy", DbType.Decimal, this._No_DVD_Copy);
			
			if (string.IsNullOrEmpty(this._Urgent_Need))
				db.AddInParameter(dbCommand, "Urgent_Need", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Urgent_Need", DbType.String, this._Urgent_Need);
			
			if (string.IsNullOrEmpty(this._Mailing_Address))
				db.AddInParameter(dbCommand, "Mailing_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Mailing_Address", DbType.String, this._Mailing_Address);
			
			if (string.IsNullOrEmpty(this._Shipping_Method))
				db.AddInParameter(dbCommand, "Shipping_Method", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Shipping_Method", DbType.String, this._Shipping_Method);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Created_By))
				db.AddInParameter(dbCommand, "Created_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Created_By", DbType.String, this._Created_By);
			
			db.AddInParameter(dbCommand, "Create_Date", DbType.DateTime, this._Create_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Event_Video_Tracking_Request table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Event_Video_Tracking_Request)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_Video_Tracking_RequestDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Event_Video_Tracking_Request", DbType.Decimal, pK_Event_Video_Tracking_Request);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Get Event_Video_Tracking_Request Data
        /// </summary>
        /// <param name="strSelectedEvents"></param>
        /// <returns></returns>
        public static DataSet GetVideoRequestData(decimal PK_Event_Video_Tracking_Request)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetVideoRequestData");

            db.AddInParameter(dbCommand, "PK_Event_Video_Tracking_Request", DbType.Decimal, PK_Event_Video_Tracking_Request);
            dbCommand.CommandTimeout = 10000;

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetVideoRequestUser()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetVideoRequestUser");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetVideoTrackingDataByFK_Event(decimal FK_Event, decimal PK_Event_Video_Tracking_Request)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetVideoTrackingDataByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);
            db.AddInParameter(dbCommand, "PK_Event_Video_Tracking_Request", DbType.Decimal, PK_Event_Video_Tracking_Request);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Event_Video_Tracking_RequestSearch(string RequestNumber, string Request_Type, decimal? FK_LU_Location, decimal? Status, 
                DateTime? Event_Date_From, DateTime? Event_Date_To, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Video_Tracking_RequestSearch");

            db.AddInParameter(dbCommand, "RequestNumber", DbType.String, RequestNumber);
            db.AddInParameter(dbCommand, "Request_Type", DbType.String, Request_Type);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "Status", DbType.Decimal, Status);
            db.AddInParameter(dbCommand, "Event_Date_From", DbType.DateTime, Event_Date_From);
            db.AddInParameter(dbCommand, "Event_Date_To", DbType.DateTime, Event_Date_To);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, Convert.ToInt32(clsSession.UserID));
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetUserDetailForVideoRequest()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetUserDetailForVideoRequest");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, Convert.ToInt32(clsSession.UserID));

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Update Status.
        /// </summary>
        public static void Event_Video_Tracking_RequestUpdateStatus(decimal PK_Event_Video_Tracking_Request, string Status, decimal Updated_By)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Video_Tracking_RequestUpdateStatus");

            db.AddInParameter(dbCommand, "PK_Event_Video_Tracking_Request", DbType.Decimal, PK_Event_Video_Tracking_Request);
            db.AddInParameter(dbCommand, "Status", DbType.String, Status);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Int32, Updated_By);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet GetAttachmentfolderforVideoRequest(string Folder_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAttachmentfolderforVideoRequest");

            db.AddInParameter(dbCommand, "Folder_Name", DbType.String, Folder_Name);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetEmailDetailsforVideoRequest(string Folder_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetEmailDetailsforVideoRequest");

            db.AddInParameter(dbCommand, "Folder_Name", DbType.String, Folder_Name);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Event_Video_Tracking_Request table by FK_Event.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Video_Tracking_RequestSelectByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
