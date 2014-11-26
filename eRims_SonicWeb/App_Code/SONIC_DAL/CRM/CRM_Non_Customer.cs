using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for CRM_Non_Customer table.
	/// </summary>
	public sealed class CRM_Non_Customer
	{

		#region Private variables used to hold the property values

		private decimal? _PK_CRM_Non_Customer;
		private DateTime? _Record_Date;
		private decimal? _FK_LU_CRM_Source;
		private decimal? _FK_LU_Location;
		private string _Company_Name;
		private string _Last_Name;
		private string _First_Name;
		private string _City;
		private decimal? _FK_State;
		private string _Zip_Code;
		private string _Email;
		private string _Home_Telephone;
		private string _Cell_Telephone;
		private string _Work_Telephone;
		private string _Work_Telephone_Extension;
		private string _Comment_Call_Inquiry_Summary;
		private string _Media_Call_Response_Summary;
		private string _Action_Summary;
		private decimal? _FK_LU_CRM_Category;
		private string _Response_Sent;
		private decimal? _FK_LU_CRM_Response_Method;
		private DateTime? _Response_Date;
		private string _Response_NA;
		private decimal? _Days_To_Close;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_CRM_Non_Customer value.
		/// </summary>
		public decimal? PK_CRM_Non_Customer
		{
			get { return _PK_CRM_Non_Customer; }
			set { _PK_CRM_Non_Customer = value; }
		}

		/// <summary>
		/// Gets or sets the Record_Date value.
		/// </summary>
		public DateTime? Record_Date
		{
			get { return _Record_Date; }
			set { _Record_Date = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_CRM_Source value.
		/// </summary>
		public decimal? FK_LU_CRM_Source
		{
			get { return _FK_LU_CRM_Source; }
			set { _FK_LU_CRM_Source = value; }
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
		/// Gets or sets the Company_Name value.
		/// </summary>
		public string Company_Name
		{
			get { return _Company_Name; }
			set { _Company_Name = value; }
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
		/// Gets or sets the First_Name value.
		/// </summary>
		public string First_Name
		{
			get { return _First_Name; }
			set { _First_Name = value; }
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
		/// Gets or sets the Email value.
		/// </summary>
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}

		/// <summary>
		/// Gets or sets the Home_Telephone value.
		/// </summary>
		public string Home_Telephone
		{
			get { return _Home_Telephone; }
			set { _Home_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Cell_Telephone value.
		/// </summary>
		public string Cell_Telephone
		{
			get { return _Cell_Telephone; }
			set { _Cell_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Work_Telephone value.
		/// </summary>
		public string Work_Telephone
		{
			get { return _Work_Telephone; }
			set { _Work_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Work_Telephone_Extension value.
		/// </summary>
		public string Work_Telephone_Extension
		{
			get { return _Work_Telephone_Extension; }
			set { _Work_Telephone_Extension = value; }
		}

		/// <summary>
		/// Gets or sets the Comment_Call_Inquiry_Summary value.
		/// </summary>
		public string Comment_Call_Inquiry_Summary
		{
			get { return _Comment_Call_Inquiry_Summary; }
			set { _Comment_Call_Inquiry_Summary = value; }
		}

		/// <summary>
		/// Gets or sets the Media_Call_Response_Summary value.
		/// </summary>
		public string Media_Call_Response_Summary
		{
			get { return _Media_Call_Response_Summary; }
			set { _Media_Call_Response_Summary = value; }
		}

		/// <summary>
		/// Gets or sets the Action_Summary value.
		/// </summary>
		public string Action_Summary
		{
			get { return _Action_Summary; }
			set { _Action_Summary = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_CRM_Category value.
		/// </summary>
		public decimal? FK_LU_CRM_Category
		{
			get { return _FK_LU_CRM_Category; }
			set { _FK_LU_CRM_Category = value; }
		}

		/// <summary>
		/// Gets or sets the Response_Sent value.
		/// </summary>
		public string Response_Sent
		{
			get { return _Response_Sent; }
			set { _Response_Sent = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_CRM_Response_Method value.
		/// </summary>
		public decimal? FK_LU_CRM_Response_Method
		{
			get { return _FK_LU_CRM_Response_Method; }
			set { _FK_LU_CRM_Response_Method = value; }
		}

		/// <summary>
		/// Gets or sets the Response_Date value.
		/// </summary>
		public DateTime? Response_Date
		{
			get { return _Response_Date; }
			set { _Response_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Response_NA value.
		/// </summary>
		public string Response_NA
		{
			get { return _Response_NA; }
			set { _Response_NA = value; }
		}

		/// <summary>
		/// Gets or sets the Days_To_Close value.
		/// </summary>
		public decimal? Days_To_Close
		{
			get { return _Days_To_Close; }
			set { _Days_To_Close = value; }
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
		/// Initializes a new instance of the CRM_Non_Customer class with default value.
		/// </summary>
		public CRM_Non_Customer() 
		{

			this._PK_CRM_Non_Customer = null;
			this._Record_Date = null;
			this._FK_LU_CRM_Source = null;
			this._FK_LU_Location = null;
			this._Company_Name = null;
			this._Last_Name = null;
			this._First_Name = null;
			this._City = null;
			this._FK_State = null;
			this._Zip_Code = null;
			this._Email = null;
			this._Home_Telephone = null;
			this._Cell_Telephone = null;
			this._Work_Telephone = null;
			this._Work_Telephone_Extension = null;
			this._Comment_Call_Inquiry_Summary = null;
			this._Media_Call_Response_Summary = null;
			this._Action_Summary = null;
			this._FK_LU_CRM_Category = null;
			this._Response_Sent = null;
			this._FK_LU_CRM_Response_Method = null;
			this._Response_Date = null;
			this._Response_NA = null;
			this._Days_To_Close = null;
			this._Update_Date = null;
			this._Updated_By = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the CRM_Non_Customer class based on Primary Key.
		/// </summary>
		public CRM_Non_Customer(decimal pK_CRM_Non_Customer) 
		{
			DataTable dtCRM_Non_Customer = SelectByPK(pK_CRM_Non_Customer).Tables[0];

			if (dtCRM_Non_Customer.Rows.Count == 1)
			{
				DataRow drCRM_Non_Customer = dtCRM_Non_Customer.Rows[0];
				if (drCRM_Non_Customer["PK_CRM_Non_Customer"] == DBNull.Value)
					this._PK_CRM_Non_Customer = null;
				else
					this._PK_CRM_Non_Customer = (decimal?)drCRM_Non_Customer["PK_CRM_Non_Customer"];

				if (drCRM_Non_Customer["Record_Date"] == DBNull.Value)
					this._Record_Date = null;
				else
					this._Record_Date = (DateTime?)drCRM_Non_Customer["Record_Date"];

				if (drCRM_Non_Customer["FK_LU_CRM_Source"] == DBNull.Value)
					this._FK_LU_CRM_Source = null;
				else
					this._FK_LU_CRM_Source = (decimal?)drCRM_Non_Customer["FK_LU_CRM_Source"];

				if (drCRM_Non_Customer["FK_LU_Location"] == DBNull.Value)
					this._FK_LU_Location = null;
				else
					this._FK_LU_Location = (decimal?)drCRM_Non_Customer["FK_LU_Location"];

				if (drCRM_Non_Customer["Company_Name"] == DBNull.Value)
					this._Company_Name = null;
				else
					this._Company_Name = (string)drCRM_Non_Customer["Company_Name"];

				if (drCRM_Non_Customer["Last_Name"] == DBNull.Value)
					this._Last_Name = null;
				else
					this._Last_Name = (string)drCRM_Non_Customer["Last_Name"];

				if (drCRM_Non_Customer["First_Name"] == DBNull.Value)
					this._First_Name = null;
				else
					this._First_Name = (string)drCRM_Non_Customer["First_Name"];

				if (drCRM_Non_Customer["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drCRM_Non_Customer["City"];

				if (drCRM_Non_Customer["FK_State"] == DBNull.Value)
					this._FK_State = null;
				else
					this._FK_State = (decimal?)drCRM_Non_Customer["FK_State"];

				if (drCRM_Non_Customer["Zip_Code"] == DBNull.Value)
					this._Zip_Code = null;
				else
					this._Zip_Code = (string)drCRM_Non_Customer["Zip_Code"];

				if (drCRM_Non_Customer["Email"] == DBNull.Value)
					this._Email = null;
				else
					this._Email = (string)drCRM_Non_Customer["Email"];

				if (drCRM_Non_Customer["Home_Telephone"] == DBNull.Value)
					this._Home_Telephone = null;
				else
					this._Home_Telephone = (string)drCRM_Non_Customer["Home_Telephone"];

				if (drCRM_Non_Customer["Cell_Telephone"] == DBNull.Value)
					this._Cell_Telephone = null;
				else
					this._Cell_Telephone = (string)drCRM_Non_Customer["Cell_Telephone"];

				if (drCRM_Non_Customer["Work_Telephone"] == DBNull.Value)
					this._Work_Telephone = null;
				else
					this._Work_Telephone = (string)drCRM_Non_Customer["Work_Telephone"];

				if (drCRM_Non_Customer["Work_Telephone_Extension"] == DBNull.Value)
					this._Work_Telephone_Extension = null;
				else
					this._Work_Telephone_Extension = (string)drCRM_Non_Customer["Work_Telephone_Extension"];

				if (drCRM_Non_Customer["Comment_Call_Inquiry_Summary"] == DBNull.Value)
					this._Comment_Call_Inquiry_Summary = null;
				else
					this._Comment_Call_Inquiry_Summary = (string)drCRM_Non_Customer["Comment_Call_Inquiry_Summary"];

				if (drCRM_Non_Customer["Media_Call_Response_Summary"] == DBNull.Value)
					this._Media_Call_Response_Summary = null;
				else
					this._Media_Call_Response_Summary = (string)drCRM_Non_Customer["Media_Call_Response_Summary"];

				if (drCRM_Non_Customer["Action_Summary"] == DBNull.Value)
					this._Action_Summary = null;
				else
					this._Action_Summary = (string)drCRM_Non_Customer["Action_Summary"];

				if (drCRM_Non_Customer["FK_LU_CRM_Category"] == DBNull.Value)
					this._FK_LU_CRM_Category = null;
				else
					this._FK_LU_CRM_Category = (decimal?)drCRM_Non_Customer["FK_LU_CRM_Category"];

				if (drCRM_Non_Customer["Response_Sent"] == DBNull.Value)
					this._Response_Sent = null;
				else
					this._Response_Sent = (string)drCRM_Non_Customer["Response_Sent"];

				if (drCRM_Non_Customer["FK_LU_CRM_Response_Method"] == DBNull.Value)
					this._FK_LU_CRM_Response_Method = null;
				else
					this._FK_LU_CRM_Response_Method = (decimal?)drCRM_Non_Customer["FK_LU_CRM_Response_Method"];

				if (drCRM_Non_Customer["Response_Date"] == DBNull.Value)
					this._Response_Date = null;
				else
					this._Response_Date = (DateTime?)drCRM_Non_Customer["Response_Date"];

				if (drCRM_Non_Customer["Response_NA"] == DBNull.Value)
					this._Response_NA = null;
				else
					this._Response_NA = (string)drCRM_Non_Customer["Response_NA"];

				if (drCRM_Non_Customer["Days_To_Close"] == DBNull.Value)
					this._Days_To_Close = null;
				else
					this._Days_To_Close = (decimal?)drCRM_Non_Customer["Days_To_Close"];

				if (drCRM_Non_Customer["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drCRM_Non_Customer["Update_Date"];

				if (drCRM_Non_Customer["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drCRM_Non_Customer["Updated_By"];

			}
			else
			{
				this._PK_CRM_Non_Customer = null;
				this._Record_Date = null;
				this._FK_LU_CRM_Source = null;
				this._FK_LU_Location = null;
				this._Company_Name = null;
				this._Last_Name = null;
				this._First_Name = null;
				this._City = null;
				this._FK_State = null;
				this._Zip_Code = null;
				this._Email = null;
				this._Home_Telephone = null;
				this._Cell_Telephone = null;
				this._Work_Telephone = null;
				this._Work_Telephone_Extension = null;
				this._Comment_Call_Inquiry_Summary = null;
				this._Media_Call_Response_Summary = null;
				this._Action_Summary = null;
				this._FK_LU_CRM_Category = null;
				this._Response_Sent = null;
				this._FK_LU_CRM_Response_Method = null;
				this._Response_Date = null;
				this._Response_NA = null;
				this._Days_To_Close = null;
				this._Update_Date = null;
				this._Updated_By = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the CRM_Non_Customer table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Non_CustomerInsert");

			
			db.AddInParameter(dbCommand, "Record_Date", DbType.DateTime, this._Record_Date);
			
			db.AddInParameter(dbCommand, "FK_LU_CRM_Source", DbType.Decimal, this._FK_LU_CRM_Source);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			if (string.IsNullOrEmpty(this._Company_Name))
				db.AddInParameter(dbCommand, "Company_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Company_Name", DbType.String, this._Company_Name);
			
			if (string.IsNullOrEmpty(this._Last_Name))
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);
			
			if (string.IsNullOrEmpty(this._First_Name))
				db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			
			if (string.IsNullOrEmpty(this._Zip_Code))
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			
			if (string.IsNullOrEmpty(this._Email))
				db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
			
			if (string.IsNullOrEmpty(this._Home_Telephone))
				db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, this._Home_Telephone);
			
			if (string.IsNullOrEmpty(this._Cell_Telephone))
				db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);
			
			if (string.IsNullOrEmpty(this._Work_Telephone))
				db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, this._Work_Telephone);
			
			if (string.IsNullOrEmpty(this._Work_Telephone_Extension))
				db.AddInParameter(dbCommand, "Work_Telephone_Extension", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Work_Telephone_Extension", DbType.String, this._Work_Telephone_Extension);
			
			if (string.IsNullOrEmpty(this._Comment_Call_Inquiry_Summary))
				db.AddInParameter(dbCommand, "Comment_Call_Inquiry_Summary", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comment_Call_Inquiry_Summary", DbType.String, this._Comment_Call_Inquiry_Summary);
			
			if (string.IsNullOrEmpty(this._Media_Call_Response_Summary))
				db.AddInParameter(dbCommand, "Media_Call_Response_Summary", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Media_Call_Response_Summary", DbType.String, this._Media_Call_Response_Summary);
			
			if (string.IsNullOrEmpty(this._Action_Summary))
				db.AddInParameter(dbCommand, "Action_Summary", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Action_Summary", DbType.String, this._Action_Summary);
			
			db.AddInParameter(dbCommand, "FK_LU_CRM_Category", DbType.Decimal, this._FK_LU_CRM_Category);
			
			if (string.IsNullOrEmpty(this._Response_Sent))
				db.AddInParameter(dbCommand, "Response_Sent", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Response_Sent", DbType.String, this._Response_Sent);
			
			db.AddInParameter(dbCommand, "FK_LU_CRM_Response_Method", DbType.Decimal, this._FK_LU_CRM_Response_Method);
			
			db.AddInParameter(dbCommand, "Response_Date", DbType.DateTime, this._Response_Date);
			
			if (string.IsNullOrEmpty(this._Response_NA))
				db.AddInParameter(dbCommand, "Response_NA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Response_NA", DbType.String, this._Response_NA);
			
			db.AddInParameter(dbCommand, "Days_To_Close", DbType.Decimal, this._Days_To_Close);
			
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
		/// Selects a single record from the CRM_Non_Customer table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_CRM_Non_Customer)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Non_CustomerSelectByPK");

			db.AddInParameter(dbCommand, "PK_CRM_Non_Customer", DbType.Decimal, pK_CRM_Non_Customer);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the CRM_Non_Customer table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Non_CustomerSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the CRM_Non_Customer table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Non_CustomerUpdate");

			
			db.AddInParameter(dbCommand, "PK_CRM_Non_Customer", DbType.Decimal, this._PK_CRM_Non_Customer);
			
			db.AddInParameter(dbCommand, "Record_Date", DbType.DateTime, this._Record_Date);
			
			db.AddInParameter(dbCommand, "FK_LU_CRM_Source", DbType.Decimal, this._FK_LU_CRM_Source);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			if (string.IsNullOrEmpty(this._Company_Name))
				db.AddInParameter(dbCommand, "Company_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Company_Name", DbType.String, this._Company_Name);
			
			if (string.IsNullOrEmpty(this._Last_Name))
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);
			
			if (string.IsNullOrEmpty(this._First_Name))
				db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			
			if (string.IsNullOrEmpty(this._Zip_Code))
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			
			if (string.IsNullOrEmpty(this._Email))
				db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
			
			if (string.IsNullOrEmpty(this._Home_Telephone))
				db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Home_Telephone", DbType.String, this._Home_Telephone);
			
			if (string.IsNullOrEmpty(this._Cell_Telephone))
				db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);
			
			if (string.IsNullOrEmpty(this._Work_Telephone))
				db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, this._Work_Telephone);
			
			if (string.IsNullOrEmpty(this._Work_Telephone_Extension))
				db.AddInParameter(dbCommand, "Work_Telephone_Extension", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Work_Telephone_Extension", DbType.String, this._Work_Telephone_Extension);
			
			if (string.IsNullOrEmpty(this._Comment_Call_Inquiry_Summary))
				db.AddInParameter(dbCommand, "Comment_Call_Inquiry_Summary", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comment_Call_Inquiry_Summary", DbType.String, this._Comment_Call_Inquiry_Summary);
			
			if (string.IsNullOrEmpty(this._Media_Call_Response_Summary))
				db.AddInParameter(dbCommand, "Media_Call_Response_Summary", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Media_Call_Response_Summary", DbType.String, this._Media_Call_Response_Summary);
			
			if (string.IsNullOrEmpty(this._Action_Summary))
				db.AddInParameter(dbCommand, "Action_Summary", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Action_Summary", DbType.String, this._Action_Summary);
			
			db.AddInParameter(dbCommand, "FK_LU_CRM_Category", DbType.Decimal, this._FK_LU_CRM_Category);
			
			if (string.IsNullOrEmpty(this._Response_Sent))
				db.AddInParameter(dbCommand, "Response_Sent", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Response_Sent", DbType.String, this._Response_Sent);
			
			db.AddInParameter(dbCommand, "FK_LU_CRM_Response_Method", DbType.Decimal, this._FK_LU_CRM_Response_Method);
			
			db.AddInParameter(dbCommand, "Response_Date", DbType.DateTime, this._Response_Date);
			
			if (string.IsNullOrEmpty(this._Response_NA))
				db.AddInParameter(dbCommand, "Response_NA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Response_NA", DbType.String, this._Response_NA);
			
			db.AddInParameter(dbCommand, "Days_To_Close", DbType.Decimal, this._Days_To_Close);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the CRM_Non_Customer table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_CRM_Non_Customer)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Non_CustomerDeleteByPK");

			db.AddInParameter(dbCommand, "PK_CRM_Non_Customer", DbType.Decimal, pK_CRM_Non_Customer);

			db.ExecuteNonQuery(dbCommand);
		}
       
	}
}
