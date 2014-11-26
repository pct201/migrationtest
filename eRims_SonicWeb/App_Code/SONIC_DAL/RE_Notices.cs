using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RE_Notices table.
	/// </summary>
	public sealed class RE_Notices
	{

		#region Private variables used to hold the property values

		private decimal? _PK_RE_Notices;
		private decimal? _FK_RE_Information;
		private string _Landlord_Company;
		private string _Landlord_Contact;
		private string _Landlord_Address1;
		private string _Landlord_Address2;
		private string _Landlord_City;
		private decimal? _FK_State_Landlord;
		private string _Landlord_Zip_Code;
		private string _Landlord_Telephone;
		private string _Landlord_Facsimile;
		private string _Landlord_Email;
		private string _Landlord_Copy_Company;
		private string _Landlord_Copy_Contact;
		private string _Landlord_Copy_Address1;
		private string _Landlord_Copy_Address2;
		private string _Landlord_Copy_City;
		private decimal? _FK_State_Landlord_Copy;
		private string _Landlord_Copy_Zip_Code;
		private string _Landlord_Copy_Telephone;
		private string _Landlord_Copy_Facsimile;
		private string _Landlord_Copy_Email;
		private string _Tenant_Company;
		private string _Tenant_Contact;
		private string _Tenant_Address1;
		private string _Tenant_Address2;
		private string _Tenant_City;
		private decimal? _FK_State_Tenant;
		private string _Tenant_Zip_Code;
		private string _Tenant_Telephone;
		private string _Tenant_Facsimile;
		private string _Tenant_Email;
		private string _Tenant_Copy_Company;
		private string _Tenant_Copy_Contact;
		private string _Tenant_Copy_Address1;
		private string _Tenant_Copy_Address2;
		private string _Tenant_Copy_City;
		private decimal? _FK_State_Tenant_Copy;
		private string _Tenant_Copy_Zip_Code;
		private string _Tenant_Copy_Telephone;
		private string _Tenant_Copy_Facsimile;
		private string _Tenant_Copy_Email;
		private string _Subtenant_Company;
		private string _Subtenant_Contact;
		private string _Subtenant_Address1;
		private string _Subtenant_Address2;
		private string _Subtenant_City;
		private decimal? _FK_State_Subtenant;
		private string _Subtenant_Zip_Code;
		private string _Subtenant_Telephone;
		private string _Subtenant_Facsimile;
		private string _Subtenant_Email;
		private string _Subtenant_Copy_Company;
		private string _Subtenant_Copy_Contact;
		private string _Subtenant_Copy_Address1;
		private string _Subtenant_Copy_Address2;
		private string _Subtenant_Copy_City;
		private decimal? _FK_State_Subtenant_Copy;
		private string _Subtenant_Copy_Zip_Code;
		private string _Subtenant_Copy_Telephone;
		private string _Subtenant_Copy_Facsimile;
		private string _Subtenant_Copy_Email;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_RE_Notices value.
		/// </summary>
		public decimal? PK_RE_Notices
		{
			get { return _PK_RE_Notices; }
			set { _PK_RE_Notices = value; }
		}

		/// <summary>
		/// Gets or sets the FK_RE_Information value.
		/// </summary>
		public decimal? FK_RE_Information
		{
			get { return _FK_RE_Information; }
			set { _FK_RE_Information = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Company value.
		/// </summary>
		public string Landlord_Company
		{
			get { return _Landlord_Company; }
			set { _Landlord_Company = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Contact value.
		/// </summary>
		public string Landlord_Contact
		{
			get { return _Landlord_Contact; }
			set { _Landlord_Contact = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Address1 value.
		/// </summary>
		public string Landlord_Address1
		{
			get { return _Landlord_Address1; }
			set { _Landlord_Address1 = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Address2 value.
		/// </summary>
		public string Landlord_Address2
		{
			get { return _Landlord_Address2; }
			set { _Landlord_Address2 = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_City value.
		/// </summary>
		public string Landlord_City
		{
			get { return _Landlord_City; }
			set { _Landlord_City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_State_Landlord value.
		/// </summary>
		public decimal? FK_State_Landlord
		{
			get { return _FK_State_Landlord; }
			set { _FK_State_Landlord = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Zip_Code value.
		/// </summary>
		public string Landlord_Zip_Code
		{
			get { return _Landlord_Zip_Code; }
			set { _Landlord_Zip_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Telephone value.
		/// </summary>
		public string Landlord_Telephone
		{
			get { return _Landlord_Telephone; }
			set { _Landlord_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Facsimile value.
		/// </summary>
		public string Landlord_Facsimile
		{
			get { return _Landlord_Facsimile; }
			set { _Landlord_Facsimile = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Email value.
		/// </summary>
		public string Landlord_Email
		{
			get { return _Landlord_Email; }
			set { _Landlord_Email = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Copy_Company value.
		/// </summary>
		public string Landlord_Copy_Company
		{
			get { return _Landlord_Copy_Company; }
			set { _Landlord_Copy_Company = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Copy_Contact value.
		/// </summary>
		public string Landlord_Copy_Contact
		{
			get { return _Landlord_Copy_Contact; }
			set { _Landlord_Copy_Contact = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Copy_Address1 value.
		/// </summary>
		public string Landlord_Copy_Address1
		{
			get { return _Landlord_Copy_Address1; }
			set { _Landlord_Copy_Address1 = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Copy_Address2 value.
		/// </summary>
		public string Landlord_Copy_Address2
		{
			get { return _Landlord_Copy_Address2; }
			set { _Landlord_Copy_Address2 = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Copy_City value.
		/// </summary>
		public string Landlord_Copy_City
		{
			get { return _Landlord_Copy_City; }
			set { _Landlord_Copy_City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_State_Landlord_Copy value.
		/// </summary>
		public decimal? FK_State_Landlord_Copy
		{
			get { return _FK_State_Landlord_Copy; }
			set { _FK_State_Landlord_Copy = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Copy_Zip_Code value.
		/// </summary>
		public string Landlord_Copy_Zip_Code
		{
			get { return _Landlord_Copy_Zip_Code; }
			set { _Landlord_Copy_Zip_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Copy_Telephone value.
		/// </summary>
		public string Landlord_Copy_Telephone
		{
			get { return _Landlord_Copy_Telephone; }
			set { _Landlord_Copy_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Copy_Facsimile value.
		/// </summary>
		public string Landlord_Copy_Facsimile
		{
			get { return _Landlord_Copy_Facsimile; }
			set { _Landlord_Copy_Facsimile = value; }
		}

		/// <summary>
		/// Gets or sets the Landlord_Copy_Email value.
		/// </summary>
		public string Landlord_Copy_Email
		{
			get { return _Landlord_Copy_Email; }
			set { _Landlord_Copy_Email = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Company value.
		/// </summary>
		public string Tenant_Company
		{
			get { return _Tenant_Company; }
			set { _Tenant_Company = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Contact value.
		/// </summary>
		public string Tenant_Contact
		{
			get { return _Tenant_Contact; }
			set { _Tenant_Contact = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Address1 value.
		/// </summary>
		public string Tenant_Address1
		{
			get { return _Tenant_Address1; }
			set { _Tenant_Address1 = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Address2 value.
		/// </summary>
		public string Tenant_Address2
		{
			get { return _Tenant_Address2; }
			set { _Tenant_Address2 = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_City value.
		/// </summary>
		public string Tenant_City
		{
			get { return _Tenant_City; }
			set { _Tenant_City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_State_Tenant value.
		/// </summary>
		public decimal? FK_State_Tenant
		{
			get { return _FK_State_Tenant; }
			set { _FK_State_Tenant = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Zip_Code value.
		/// </summary>
		public string Tenant_Zip_Code
		{
			get { return _Tenant_Zip_Code; }
			set { _Tenant_Zip_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Telephone value.
		/// </summary>
		public string Tenant_Telephone
		{
			get { return _Tenant_Telephone; }
			set { _Tenant_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Facsimile value.
		/// </summary>
		public string Tenant_Facsimile
		{
			get { return _Tenant_Facsimile; }
			set { _Tenant_Facsimile = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Email value.
		/// </summary>
		public string Tenant_Email
		{
			get { return _Tenant_Email; }
			set { _Tenant_Email = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Copy_Company value.
		/// </summary>
		public string Tenant_Copy_Company
		{
			get { return _Tenant_Copy_Company; }
			set { _Tenant_Copy_Company = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Copy_Contact value.
		/// </summary>
		public string Tenant_Copy_Contact
		{
			get { return _Tenant_Copy_Contact; }
			set { _Tenant_Copy_Contact = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Copy_Address1 value.
		/// </summary>
		public string Tenant_Copy_Address1
		{
			get { return _Tenant_Copy_Address1; }
			set { _Tenant_Copy_Address1 = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Copy_Address2 value.
		/// </summary>
		public string Tenant_Copy_Address2
		{
			get { return _Tenant_Copy_Address2; }
			set { _Tenant_Copy_Address2 = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Copy_City value.
		/// </summary>
		public string Tenant_Copy_City
		{
			get { return _Tenant_Copy_City; }
			set { _Tenant_Copy_City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_State_Tenant_Copy value.
		/// </summary>
		public decimal? FK_State_Tenant_Copy
		{
			get { return _FK_State_Tenant_Copy; }
			set { _FK_State_Tenant_Copy = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Copy_Zip_Code value.
		/// </summary>
		public string Tenant_Copy_Zip_Code
		{
			get { return _Tenant_Copy_Zip_Code; }
			set { _Tenant_Copy_Zip_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Copy_Telephone value.
		/// </summary>
		public string Tenant_Copy_Telephone
		{
			get { return _Tenant_Copy_Telephone; }
			set { _Tenant_Copy_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Copy_Facsimile value.
		/// </summary>
		public string Tenant_Copy_Facsimile
		{
			get { return _Tenant_Copy_Facsimile; }
			set { _Tenant_Copy_Facsimile = value; }
		}

		/// <summary>
		/// Gets or sets the Tenant_Copy_Email value.
		/// </summary>
		public string Tenant_Copy_Email
		{
			get { return _Tenant_Copy_Email; }
			set { _Tenant_Copy_Email = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Company value.
		/// </summary>
		public string Subtenant_Company
		{
			get { return _Subtenant_Company; }
			set { _Subtenant_Company = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Contact value.
		/// </summary>
		public string Subtenant_Contact
		{
			get { return _Subtenant_Contact; }
			set { _Subtenant_Contact = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Address1 value.
		/// </summary>
		public string Subtenant_Address1
		{
			get { return _Subtenant_Address1; }
			set { _Subtenant_Address1 = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Address2 value.
		/// </summary>
		public string Subtenant_Address2
		{
			get { return _Subtenant_Address2; }
			set { _Subtenant_Address2 = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_City value.
		/// </summary>
		public string Subtenant_City
		{
			get { return _Subtenant_City; }
			set { _Subtenant_City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_State_Subtenant value.
		/// </summary>
		public decimal? FK_State_Subtenant
		{
			get { return _FK_State_Subtenant; }
			set { _FK_State_Subtenant = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Zip_Code value.
		/// </summary>
		public string Subtenant_Zip_Code
		{
			get { return _Subtenant_Zip_Code; }
			set { _Subtenant_Zip_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Telephone value.
		/// </summary>
		public string Subtenant_Telephone
		{
			get { return _Subtenant_Telephone; }
			set { _Subtenant_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Facsimile value.
		/// </summary>
		public string Subtenant_Facsimile
		{
			get { return _Subtenant_Facsimile; }
			set { _Subtenant_Facsimile = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Email value.
		/// </summary>
		public string Subtenant_Email
		{
			get { return _Subtenant_Email; }
			set { _Subtenant_Email = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Copy_Company value.
		/// </summary>
		public string Subtenant_Copy_Company
		{
			get { return _Subtenant_Copy_Company; }
			set { _Subtenant_Copy_Company = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Copy_Contact value.
		/// </summary>
		public string Subtenant_Copy_Contact
		{
			get { return _Subtenant_Copy_Contact; }
			set { _Subtenant_Copy_Contact = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Copy_Address1 value.
		/// </summary>
		public string Subtenant_Copy_Address1
		{
			get { return _Subtenant_Copy_Address1; }
			set { _Subtenant_Copy_Address1 = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Copy_Address2 value.
		/// </summary>
		public string Subtenant_Copy_Address2
		{
			get { return _Subtenant_Copy_Address2; }
			set { _Subtenant_Copy_Address2 = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Copy_City value.
		/// </summary>
		public string Subtenant_Copy_City
		{
			get { return _Subtenant_Copy_City; }
			set { _Subtenant_Copy_City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_State_Subtenant_Copy value.
		/// </summary>
		public decimal? FK_State_Subtenant_Copy
		{
			get { return _FK_State_Subtenant_Copy; }
			set { _FK_State_Subtenant_Copy = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Copy_Zip_Code value.
		/// </summary>
		public string Subtenant_Copy_Zip_Code
		{
			get { return _Subtenant_Copy_Zip_Code; }
			set { _Subtenant_Copy_Zip_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Copy_Telephone value.
		/// </summary>
		public string Subtenant_Copy_Telephone
		{
			get { return _Subtenant_Copy_Telephone; }
			set { _Subtenant_Copy_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Copy_Facsimile value.
		/// </summary>
		public string Subtenant_Copy_Facsimile
		{
			get { return _Subtenant_Copy_Facsimile; }
			set { _Subtenant_Copy_Facsimile = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Copy_Email value.
		/// </summary>
		public string Subtenant_Copy_Email
		{
			get { return _Subtenant_Copy_Email; }
			set { _Subtenant_Copy_Email = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the RE_Notices class with default value.
		/// </summary>
		public RE_Notices() 
		{
            setDefaultValues();
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the RE_Notices class based on Primary Key.
		/// </summary>
		public RE_Notices(decimal pK_RE_Notices) 
		{
			DataTable dtRE_Notices = SelectByPK(pK_RE_Notices).Tables[0];

			if (dtRE_Notices.Rows.Count == 1)
			{
				DataRow drRE_Notices = dtRE_Notices.Rows[0];
				if (drRE_Notices["PK_RE_Notices"] == DBNull.Value)
					this._PK_RE_Notices = null;
				else
					this._PK_RE_Notices = (decimal?)drRE_Notices["PK_RE_Notices"];

				if (drRE_Notices["FK_RE_Information"] == DBNull.Value)
					this._FK_RE_Information = null;
				else
					this._FK_RE_Information = (decimal?)drRE_Notices["FK_RE_Information"];

				if (drRE_Notices["Landlord_Company"] == DBNull.Value)
					this._Landlord_Company = null;
				else
					this._Landlord_Company = (string)drRE_Notices["Landlord_Company"];

				if (drRE_Notices["Landlord_Contact"] == DBNull.Value)
					this._Landlord_Contact = null;
				else
					this._Landlord_Contact = (string)drRE_Notices["Landlord_Contact"];

				if (drRE_Notices["Landlord_Address1"] == DBNull.Value)
					this._Landlord_Address1 = null;
				else
					this._Landlord_Address1 = (string)drRE_Notices["Landlord_Address1"];

				if (drRE_Notices["Landlord_Address2"] == DBNull.Value)
					this._Landlord_Address2 = null;
				else
					this._Landlord_Address2 = (string)drRE_Notices["Landlord_Address2"];

				if (drRE_Notices["Landlord_City"] == DBNull.Value)
					this._Landlord_City = null;
				else
					this._Landlord_City = (string)drRE_Notices["Landlord_City"];

				if (drRE_Notices["FK_State_Landlord"] == DBNull.Value)
					this._FK_State_Landlord = null;
				else
					this._FK_State_Landlord = (decimal?)drRE_Notices["FK_State_Landlord"];

				if (drRE_Notices["Landlord_Zip_Code"] == DBNull.Value)
					this._Landlord_Zip_Code = null;
				else
					this._Landlord_Zip_Code = (string)drRE_Notices["Landlord_Zip_Code"];

				if (drRE_Notices["Landlord_Telephone"] == DBNull.Value)
					this._Landlord_Telephone = null;
				else
					this._Landlord_Telephone = (string)drRE_Notices["Landlord_Telephone"];

				if (drRE_Notices["Landlord_Facsimile"] == DBNull.Value)
					this._Landlord_Facsimile = null;
				else
					this._Landlord_Facsimile = (string)drRE_Notices["Landlord_Facsimile"];

				if (drRE_Notices["Landlord_Email"] == DBNull.Value)
					this._Landlord_Email = null;
				else
					this._Landlord_Email = (string)drRE_Notices["Landlord_Email"];

				if (drRE_Notices["Landlord_Copy_Company"] == DBNull.Value)
					this._Landlord_Copy_Company = null;
				else
					this._Landlord_Copy_Company = (string)drRE_Notices["Landlord_Copy_Company"];

				if (drRE_Notices["Landlord_Copy_Contact"] == DBNull.Value)
					this._Landlord_Copy_Contact = null;
				else
					this._Landlord_Copy_Contact = (string)drRE_Notices["Landlord_Copy_Contact"];

				if (drRE_Notices["Landlord_Copy_Address1"] == DBNull.Value)
					this._Landlord_Copy_Address1 = null;
				else
					this._Landlord_Copy_Address1 = (string)drRE_Notices["Landlord_Copy_Address1"];

				if (drRE_Notices["Landlord_Copy_Address2"] == DBNull.Value)
					this._Landlord_Copy_Address2 = null;
				else
					this._Landlord_Copy_Address2 = (string)drRE_Notices["Landlord_Copy_Address2"];

				if (drRE_Notices["Landlord_Copy_City"] == DBNull.Value)
					this._Landlord_Copy_City = null;
				else
					this._Landlord_Copy_City = (string)drRE_Notices["Landlord_Copy_City"];

				if (drRE_Notices["FK_State_Landlord_Copy"] == DBNull.Value)
					this._FK_State_Landlord_Copy = null;
				else
					this._FK_State_Landlord_Copy = (decimal?)drRE_Notices["FK_State_Landlord_Copy"];

				if (drRE_Notices["Landlord_Copy_Zip_Code"] == DBNull.Value)
					this._Landlord_Copy_Zip_Code = null;
				else
					this._Landlord_Copy_Zip_Code = (string)drRE_Notices["Landlord_Copy_Zip_Code"];

				if (drRE_Notices["Landlord_Copy_Telephone"] == DBNull.Value)
					this._Landlord_Copy_Telephone = null;
				else
					this._Landlord_Copy_Telephone = (string)drRE_Notices["Landlord_Copy_Telephone"];

				if (drRE_Notices["Landlord_Copy_Facsimile"] == DBNull.Value)
					this._Landlord_Copy_Facsimile = null;
				else
					this._Landlord_Copy_Facsimile = (string)drRE_Notices["Landlord_Copy_Facsimile"];

				if (drRE_Notices["Landlord_Copy_Email"] == DBNull.Value)
					this._Landlord_Copy_Email = null;
				else
					this._Landlord_Copy_Email = (string)drRE_Notices["Landlord_Copy_Email"];

				if (drRE_Notices["Tenant_Company"] == DBNull.Value)
					this._Tenant_Company = null;
				else
					this._Tenant_Company = (string)drRE_Notices["Tenant_Company"];

				if (drRE_Notices["Tenant_Contact"] == DBNull.Value)
					this._Tenant_Contact = null;
				else
					this._Tenant_Contact = (string)drRE_Notices["Tenant_Contact"];

				if (drRE_Notices["Tenant_Address1"] == DBNull.Value)
					this._Tenant_Address1 = null;
				else
					this._Tenant_Address1 = (string)drRE_Notices["Tenant_Address1"];

				if (drRE_Notices["Tenant_Address2"] == DBNull.Value)
					this._Tenant_Address2 = null;
				else
					this._Tenant_Address2 = (string)drRE_Notices["Tenant_Address2"];

				if (drRE_Notices["Tenant_City"] == DBNull.Value)
					this._Tenant_City = null;
				else
					this._Tenant_City = (string)drRE_Notices["Tenant_City"];

				if (drRE_Notices["FK_State_Tenant"] == DBNull.Value)
					this._FK_State_Tenant = null;
				else
					this._FK_State_Tenant = (decimal?)drRE_Notices["FK_State_Tenant"];

				if (drRE_Notices["Tenant_Zip_Code"] == DBNull.Value)
					this._Tenant_Zip_Code = null;
				else
					this._Tenant_Zip_Code = (string)drRE_Notices["Tenant_Zip_Code"];

				if (drRE_Notices["Tenant_Telephone"] == DBNull.Value)
					this._Tenant_Telephone = null;
				else
					this._Tenant_Telephone = (string)drRE_Notices["Tenant_Telephone"];

				if (drRE_Notices["Tenant_Facsimile"] == DBNull.Value)
					this._Tenant_Facsimile = null;
				else
					this._Tenant_Facsimile = (string)drRE_Notices["Tenant_Facsimile"];

				if (drRE_Notices["Tenant_Email"] == DBNull.Value)
					this._Tenant_Email = null;
				else
					this._Tenant_Email = (string)drRE_Notices["Tenant_Email"];

				if (drRE_Notices["Tenant_Copy_Company"] == DBNull.Value)
					this._Tenant_Copy_Company = null;
				else
					this._Tenant_Copy_Company = (string)drRE_Notices["Tenant_Copy_Company"];

				if (drRE_Notices["Tenant_Copy_Contact"] == DBNull.Value)
					this._Tenant_Copy_Contact = null;
				else
					this._Tenant_Copy_Contact = (string)drRE_Notices["Tenant_Copy_Contact"];

				if (drRE_Notices["Tenant_Copy_Address1"] == DBNull.Value)
					this._Tenant_Copy_Address1 = null;
				else
					this._Tenant_Copy_Address1 = (string)drRE_Notices["Tenant_Copy_Address1"];

				if (drRE_Notices["Tenant_Copy_Address2"] == DBNull.Value)
					this._Tenant_Copy_Address2 = null;
				else
					this._Tenant_Copy_Address2 = (string)drRE_Notices["Tenant_Copy_Address2"];

				if (drRE_Notices["Tenant_Copy_City"] == DBNull.Value)
					this._Tenant_Copy_City = null;
				else
					this._Tenant_Copy_City = (string)drRE_Notices["Tenant_Copy_City"];

				if (drRE_Notices["FK_State_Tenant_Copy"] == DBNull.Value)
					this._FK_State_Tenant_Copy = null;
				else
					this._FK_State_Tenant_Copy = (decimal?)drRE_Notices["FK_State_Tenant_Copy"];

				if (drRE_Notices["Tenant_Copy_Zip_Code"] == DBNull.Value)
					this._Tenant_Copy_Zip_Code = null;
				else
					this._Tenant_Copy_Zip_Code = (string)drRE_Notices["Tenant_Copy_Zip_Code"];

				if (drRE_Notices["Tenant_Copy_Telephone"] == DBNull.Value)
					this._Tenant_Copy_Telephone = null;
				else
					this._Tenant_Copy_Telephone = (string)drRE_Notices["Tenant_Copy_Telephone"];

				if (drRE_Notices["Tenant_Copy_Facsimile"] == DBNull.Value)
					this._Tenant_Copy_Facsimile = null;
				else
					this._Tenant_Copy_Facsimile = (string)drRE_Notices["Tenant_Copy_Facsimile"];

				if (drRE_Notices["Tenant_Copy_Email"] == DBNull.Value)
					this._Tenant_Copy_Email = null;
				else
					this._Tenant_Copy_Email = (string)drRE_Notices["Tenant_Copy_Email"];

				if (drRE_Notices["Subtenant_Company"] == DBNull.Value)
					this._Subtenant_Company = null;
				else
					this._Subtenant_Company = (string)drRE_Notices["Subtenant_Company"];

				if (drRE_Notices["Subtenant_Contact"] == DBNull.Value)
					this._Subtenant_Contact = null;
				else
					this._Subtenant_Contact = (string)drRE_Notices["Subtenant_Contact"];

				if (drRE_Notices["Subtenant_Address1"] == DBNull.Value)
					this._Subtenant_Address1 = null;
				else
					this._Subtenant_Address1 = (string)drRE_Notices["Subtenant_Address1"];

				if (drRE_Notices["Subtenant_Address2"] == DBNull.Value)
					this._Subtenant_Address2 = null;
				else
					this._Subtenant_Address2 = (string)drRE_Notices["Subtenant_Address2"];

				if (drRE_Notices["Subtenant_City"] == DBNull.Value)
					this._Subtenant_City = null;
				else
					this._Subtenant_City = (string)drRE_Notices["Subtenant_City"];

				if (drRE_Notices["FK_State_Subtenant"] == DBNull.Value)
					this._FK_State_Subtenant = null;
				else
					this._FK_State_Subtenant = (decimal?)drRE_Notices["FK_State_Subtenant"];

				if (drRE_Notices["Subtenant_Zip_Code"] == DBNull.Value)
					this._Subtenant_Zip_Code = null;
				else
					this._Subtenant_Zip_Code = (string)drRE_Notices["Subtenant_Zip_Code"];

				if (drRE_Notices["Subtenant_Telephone"] == DBNull.Value)
					this._Subtenant_Telephone = null;
				else
					this._Subtenant_Telephone = (string)drRE_Notices["Subtenant_Telephone"];

				if (drRE_Notices["Subtenant_Facsimile"] == DBNull.Value)
					this._Subtenant_Facsimile = null;
				else
					this._Subtenant_Facsimile = (string)drRE_Notices["Subtenant_Facsimile"];

				if (drRE_Notices["Subtenant_Email"] == DBNull.Value)
					this._Subtenant_Email = null;
				else
					this._Subtenant_Email = (string)drRE_Notices["Subtenant_Email"];

				if (drRE_Notices["Subtenant_Copy_Company"] == DBNull.Value)
					this._Subtenant_Copy_Company = null;
				else
					this._Subtenant_Copy_Company = (string)drRE_Notices["Subtenant_Copy_Company"];

				if (drRE_Notices["Subtenant_Copy_Contact"] == DBNull.Value)
					this._Subtenant_Copy_Contact = null;
				else
					this._Subtenant_Copy_Contact = (string)drRE_Notices["Subtenant_Copy_Contact"];

				if (drRE_Notices["Subtenant_Copy_Address1"] == DBNull.Value)
					this._Subtenant_Copy_Address1 = null;
				else
					this._Subtenant_Copy_Address1 = (string)drRE_Notices["Subtenant_Copy_Address1"];

				if (drRE_Notices["Subtenant_Copy_Address2"] == DBNull.Value)
					this._Subtenant_Copy_Address2 = null;
				else
					this._Subtenant_Copy_Address2 = (string)drRE_Notices["Subtenant_Copy_Address2"];

				if (drRE_Notices["Subtenant_Copy_City"] == DBNull.Value)
					this._Subtenant_Copy_City = null;
				else
					this._Subtenant_Copy_City = (string)drRE_Notices["Subtenant_Copy_City"];

				if (drRE_Notices["FK_State_Subtenant_Copy"] == DBNull.Value)
					this._FK_State_Subtenant_Copy = null;
				else
					this._FK_State_Subtenant_Copy = (decimal?)drRE_Notices["FK_State_Subtenant_Copy"];

				if (drRE_Notices["Subtenant_Copy_Zip_Code"] == DBNull.Value)
					this._Subtenant_Copy_Zip_Code = null;
				else
					this._Subtenant_Copy_Zip_Code = (string)drRE_Notices["Subtenant_Copy_Zip_Code"];

				if (drRE_Notices["Subtenant_Copy_Telephone"] == DBNull.Value)
					this._Subtenant_Copy_Telephone = null;
				else
					this._Subtenant_Copy_Telephone = (string)drRE_Notices["Subtenant_Copy_Telephone"];

				if (drRE_Notices["Subtenant_Copy_Facsimile"] == DBNull.Value)
					this._Subtenant_Copy_Facsimile = null;
				else
					this._Subtenant_Copy_Facsimile = (string)drRE_Notices["Subtenant_Copy_Facsimile"];

				if (drRE_Notices["Subtenant_Copy_Email"] == DBNull.Value)
					this._Subtenant_Copy_Email = null;
				else
					this._Subtenant_Copy_Email = (string)drRE_Notices["Subtenant_Copy_Email"];

				if (drRE_Notices["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drRE_Notices["Updated_By"];

				if (drRE_Notices["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drRE_Notices["Update_Date"];

			}
			else
			{
                setDefaultValues();
			}

		}

        /// <summary>
        /// Initializes a new instance of the RE_Notices class based on FK.
        /// </summary>
        public RE_Notices(decimal _FK_RE_Information,bool isFK)
        {
            DataTable dtRE_Notices = SelectByFK(_FK_RE_Information).Tables[0];

            if (dtRE_Notices.Rows.Count == 1)
            {
                DataRow drRE_Notices = dtRE_Notices.Rows[0];
                if (drRE_Notices["PK_RE_Notices"] == DBNull.Value)
                    this._PK_RE_Notices = null;
                else
                    this._PK_RE_Notices = (decimal?)drRE_Notices["PK_RE_Notices"];

                if (drRE_Notices["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Notices["FK_RE_Information"];

                if (drRE_Notices["Landlord_Company"] == DBNull.Value)
                    this._Landlord_Company = null;
                else
                    this._Landlord_Company = (string)drRE_Notices["Landlord_Company"];

                if (drRE_Notices["Landlord_Contact"] == DBNull.Value)
                    this._Landlord_Contact = null;
                else
                    this._Landlord_Contact = (string)drRE_Notices["Landlord_Contact"];

                if (drRE_Notices["Landlord_Address1"] == DBNull.Value)
                    this._Landlord_Address1 = null;
                else
                    this._Landlord_Address1 = (string)drRE_Notices["Landlord_Address1"];

                if (drRE_Notices["Landlord_Address2"] == DBNull.Value)
                    this._Landlord_Address2 = null;
                else
                    this._Landlord_Address2 = (string)drRE_Notices["Landlord_Address2"];

                if (drRE_Notices["Landlord_City"] == DBNull.Value)
                    this._Landlord_City = null;
                else
                    this._Landlord_City = (string)drRE_Notices["Landlord_City"];

                if (drRE_Notices["FK_State_Landlord"] == DBNull.Value)
                    this._FK_State_Landlord = null;
                else
                    this._FK_State_Landlord = (decimal?)drRE_Notices["FK_State_Landlord"];

                if (drRE_Notices["Landlord_Zip_Code"] == DBNull.Value)
                    this._Landlord_Zip_Code = null;
                else
                    this._Landlord_Zip_Code = (string)drRE_Notices["Landlord_Zip_Code"];

                if (drRE_Notices["Landlord_Telephone"] == DBNull.Value)
                    this._Landlord_Telephone = null;
                else
                    this._Landlord_Telephone = (string)drRE_Notices["Landlord_Telephone"];

                if (drRE_Notices["Landlord_Facsimile"] == DBNull.Value)
                    this._Landlord_Facsimile = null;
                else
                    this._Landlord_Facsimile = (string)drRE_Notices["Landlord_Facsimile"];

                if (drRE_Notices["Landlord_Email"] == DBNull.Value)
                    this._Landlord_Email = null;
                else
                    this._Landlord_Email = (string)drRE_Notices["Landlord_Email"];

                if (drRE_Notices["Landlord_Copy_Company"] == DBNull.Value)
                    this._Landlord_Copy_Company = null;
                else
                    this._Landlord_Copy_Company = (string)drRE_Notices["Landlord_Copy_Company"];

                if (drRE_Notices["Landlord_Copy_Contact"] == DBNull.Value)
                    this._Landlord_Copy_Contact = null;
                else
                    this._Landlord_Copy_Contact = (string)drRE_Notices["Landlord_Copy_Contact"];

                if (drRE_Notices["Landlord_Copy_Address1"] == DBNull.Value)
                    this._Landlord_Copy_Address1 = null;
                else
                    this._Landlord_Copy_Address1 = (string)drRE_Notices["Landlord_Copy_Address1"];

                if (drRE_Notices["Landlord_Copy_Address2"] == DBNull.Value)
                    this._Landlord_Copy_Address2 = null;
                else
                    this._Landlord_Copy_Address2 = (string)drRE_Notices["Landlord_Copy_Address2"];

                if (drRE_Notices["Landlord_Copy_City"] == DBNull.Value)
                    this._Landlord_Copy_City = null;
                else
                    this._Landlord_Copy_City = (string)drRE_Notices["Landlord_Copy_City"];

                if (drRE_Notices["FK_State_Landlord_Copy"] == DBNull.Value)
                    this._FK_State_Landlord_Copy = null;
                else
                    this._FK_State_Landlord_Copy = (decimal?)drRE_Notices["FK_State_Landlord_Copy"];

                if (drRE_Notices["Landlord_Copy_Zip_Code"] == DBNull.Value)
                    this._Landlord_Copy_Zip_Code = null;
                else
                    this._Landlord_Copy_Zip_Code = (string)drRE_Notices["Landlord_Copy_Zip_Code"];

                if (drRE_Notices["Landlord_Copy_Telephone"] == DBNull.Value)
                    this._Landlord_Copy_Telephone = null;
                else
                    this._Landlord_Copy_Telephone = (string)drRE_Notices["Landlord_Copy_Telephone"];

                if (drRE_Notices["Landlord_Copy_Facsimile"] == DBNull.Value)
                    this._Landlord_Copy_Facsimile = null;
                else
                    this._Landlord_Copy_Facsimile = (string)drRE_Notices["Landlord_Copy_Facsimile"];

                if (drRE_Notices["Landlord_Copy_Email"] == DBNull.Value)
                    this._Landlord_Copy_Email = null;
                else
                    this._Landlord_Copy_Email = (string)drRE_Notices["Landlord_Copy_Email"];

                if (drRE_Notices["Tenant_Company"] == DBNull.Value)
                    this._Tenant_Company = null;
                else
                    this._Tenant_Company = (string)drRE_Notices["Tenant_Company"];

                if (drRE_Notices["Tenant_Contact"] == DBNull.Value)
                    this._Tenant_Contact = null;
                else
                    this._Tenant_Contact = (string)drRE_Notices["Tenant_Contact"];

                if (drRE_Notices["Tenant_Address1"] == DBNull.Value)
                    this._Tenant_Address1 = null;
                else
                    this._Tenant_Address1 = (string)drRE_Notices["Tenant_Address1"];

                if (drRE_Notices["Tenant_Address2"] == DBNull.Value)
                    this._Tenant_Address2 = null;
                else
                    this._Tenant_Address2 = (string)drRE_Notices["Tenant_Address2"];

                if (drRE_Notices["Tenant_City"] == DBNull.Value)
                    this._Tenant_City = null;
                else
                    this._Tenant_City = (string)drRE_Notices["Tenant_City"];

                if (drRE_Notices["FK_State_Tenant"] == DBNull.Value)
                    this._FK_State_Tenant = null;
                else
                    this._FK_State_Tenant = (decimal?)drRE_Notices["FK_State_Tenant"];

                if (drRE_Notices["Tenant_Zip_Code"] == DBNull.Value)
                    this._Tenant_Zip_Code = null;
                else
                    this._Tenant_Zip_Code = (string)drRE_Notices["Tenant_Zip_Code"];

                if (drRE_Notices["Tenant_Telephone"] == DBNull.Value)
                    this._Tenant_Telephone = null;
                else
                    this._Tenant_Telephone = (string)drRE_Notices["Tenant_Telephone"];

                if (drRE_Notices["Tenant_Facsimile"] == DBNull.Value)
                    this._Tenant_Facsimile = null;
                else
                    this._Tenant_Facsimile = (string)drRE_Notices["Tenant_Facsimile"];

                if (drRE_Notices["Tenant_Email"] == DBNull.Value)
                    this._Tenant_Email = null;
                else
                    this._Tenant_Email = (string)drRE_Notices["Tenant_Email"];

                if (drRE_Notices["Tenant_Copy_Company"] == DBNull.Value)
                    this._Tenant_Copy_Company = null;
                else
                    this._Tenant_Copy_Company = (string)drRE_Notices["Tenant_Copy_Company"];

                if (drRE_Notices["Tenant_Copy_Contact"] == DBNull.Value)
                    this._Tenant_Copy_Contact = null;
                else
                    this._Tenant_Copy_Contact = (string)drRE_Notices["Tenant_Copy_Contact"];

                if (drRE_Notices["Tenant_Copy_Address1"] == DBNull.Value)
                    this._Tenant_Copy_Address1 = null;
                else
                    this._Tenant_Copy_Address1 = (string)drRE_Notices["Tenant_Copy_Address1"];

                if (drRE_Notices["Tenant_Copy_Address2"] == DBNull.Value)
                    this._Tenant_Copy_Address2 = null;
                else
                    this._Tenant_Copy_Address2 = (string)drRE_Notices["Tenant_Copy_Address2"];

                if (drRE_Notices["Tenant_Copy_City"] == DBNull.Value)
                    this._Tenant_Copy_City = null;
                else
                    this._Tenant_Copy_City = (string)drRE_Notices["Tenant_Copy_City"];

                if (drRE_Notices["FK_State_Tenant_Copy"] == DBNull.Value)
                    this._FK_State_Tenant_Copy = null;
                else
                    this._FK_State_Tenant_Copy = (decimal?)drRE_Notices["FK_State_Tenant_Copy"];

                if (drRE_Notices["Tenant_Copy_Zip_Code"] == DBNull.Value)
                    this._Tenant_Copy_Zip_Code = null;
                else
                    this._Tenant_Copy_Zip_Code = (string)drRE_Notices["Tenant_Copy_Zip_Code"];

                if (drRE_Notices["Tenant_Copy_Telephone"] == DBNull.Value)
                    this._Tenant_Copy_Telephone = null;
                else
                    this._Tenant_Copy_Telephone = (string)drRE_Notices["Tenant_Copy_Telephone"];

                if (drRE_Notices["Tenant_Copy_Facsimile"] == DBNull.Value)
                    this._Tenant_Copy_Facsimile = null;
                else
                    this._Tenant_Copy_Facsimile = (string)drRE_Notices["Tenant_Copy_Facsimile"];

                if (drRE_Notices["Tenant_Copy_Email"] == DBNull.Value)
                    this._Tenant_Copy_Email = null;
                else
                    this._Tenant_Copy_Email = (string)drRE_Notices["Tenant_Copy_Email"];

                if (drRE_Notices["Subtenant_Company"] == DBNull.Value)
                    this._Subtenant_Company = null;
                else
                    this._Subtenant_Company = (string)drRE_Notices["Subtenant_Company"];

                if (drRE_Notices["Subtenant_Contact"] == DBNull.Value)
                    this._Subtenant_Contact = null;
                else
                    this._Subtenant_Contact = (string)drRE_Notices["Subtenant_Contact"];

                if (drRE_Notices["Subtenant_Address1"] == DBNull.Value)
                    this._Subtenant_Address1 = null;
                else
                    this._Subtenant_Address1 = (string)drRE_Notices["Subtenant_Address1"];

                if (drRE_Notices["Subtenant_Address2"] == DBNull.Value)
                    this._Subtenant_Address2 = null;
                else
                    this._Subtenant_Address2 = (string)drRE_Notices["Subtenant_Address2"];

                if (drRE_Notices["Subtenant_City"] == DBNull.Value)
                    this._Subtenant_City = null;
                else
                    this._Subtenant_City = (string)drRE_Notices["Subtenant_City"];

                if (drRE_Notices["FK_State_Subtenant"] == DBNull.Value)
                    this._FK_State_Subtenant = null;
                else
                    this._FK_State_Subtenant = (decimal?)drRE_Notices["FK_State_Subtenant"];

                if (drRE_Notices["Subtenant_Zip_Code"] == DBNull.Value)
                    this._Subtenant_Zip_Code = null;
                else
                    this._Subtenant_Zip_Code = (string)drRE_Notices["Subtenant_Zip_Code"];

                if (drRE_Notices["Subtenant_Telephone"] == DBNull.Value)
                    this._Subtenant_Telephone = null;
                else
                    this._Subtenant_Telephone = (string)drRE_Notices["Subtenant_Telephone"];

                if (drRE_Notices["Subtenant_Facsimile"] == DBNull.Value)
                    this._Subtenant_Facsimile = null;
                else
                    this._Subtenant_Facsimile = (string)drRE_Notices["Subtenant_Facsimile"];

                if (drRE_Notices["Subtenant_Email"] == DBNull.Value)
                    this._Subtenant_Email = null;
                else
                    this._Subtenant_Email = (string)drRE_Notices["Subtenant_Email"];

                if (drRE_Notices["Subtenant_Copy_Company"] == DBNull.Value)
                    this._Subtenant_Copy_Company = null;
                else
                    this._Subtenant_Copy_Company = (string)drRE_Notices["Subtenant_Copy_Company"];

                if (drRE_Notices["Subtenant_Copy_Contact"] == DBNull.Value)
                    this._Subtenant_Copy_Contact = null;
                else
                    this._Subtenant_Copy_Contact = (string)drRE_Notices["Subtenant_Copy_Contact"];

                if (drRE_Notices["Subtenant_Copy_Address1"] == DBNull.Value)
                    this._Subtenant_Copy_Address1 = null;
                else
                    this._Subtenant_Copy_Address1 = (string)drRE_Notices["Subtenant_Copy_Address1"];

                if (drRE_Notices["Subtenant_Copy_Address2"] == DBNull.Value)
                    this._Subtenant_Copy_Address2 = null;
                else
                    this._Subtenant_Copy_Address2 = (string)drRE_Notices["Subtenant_Copy_Address2"];

                if (drRE_Notices["Subtenant_Copy_City"] == DBNull.Value)
                    this._Subtenant_Copy_City = null;
                else
                    this._Subtenant_Copy_City = (string)drRE_Notices["Subtenant_Copy_City"];

                if (drRE_Notices["FK_State_Subtenant_Copy"] == DBNull.Value)
                    this._FK_State_Subtenant_Copy = null;
                else
                    this._FK_State_Subtenant_Copy = (decimal?)drRE_Notices["FK_State_Subtenant_Copy"];

                if (drRE_Notices["Subtenant_Copy_Zip_Code"] == DBNull.Value)
                    this._Subtenant_Copy_Zip_Code = null;
                else
                    this._Subtenant_Copy_Zip_Code = (string)drRE_Notices["Subtenant_Copy_Zip_Code"];

                if (drRE_Notices["Subtenant_Copy_Telephone"] == DBNull.Value)
                    this._Subtenant_Copy_Telephone = null;
                else
                    this._Subtenant_Copy_Telephone = (string)drRE_Notices["Subtenant_Copy_Telephone"];

                if (drRE_Notices["Subtenant_Copy_Facsimile"] == DBNull.Value)
                    this._Subtenant_Copy_Facsimile = null;
                else
                    this._Subtenant_Copy_Facsimile = (string)drRE_Notices["Subtenant_Copy_Facsimile"];

                if (drRE_Notices["Subtenant_Copy_Email"] == DBNull.Value)
                    this._Subtenant_Copy_Email = null;
                else
                    this._Subtenant_Copy_Email = (string)drRE_Notices["Subtenant_Copy_Email"];

                if (drRE_Notices["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Notices["Updated_By"];

                if (drRE_Notices["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Notices["Update_Date"];

            }
            else
            {
                setDefaultValues();
            }

        }

		#endregion

        private void setDefaultValues()
        {
            this._PK_RE_Notices = null;
            this._FK_RE_Information = null;
            this._Landlord_Company = null;
            this._Landlord_Contact = null;
            this._Landlord_Address1 = null;
            this._Landlord_Address2 = null;
            this._Landlord_City = null;
            this._FK_State_Landlord = null;
            this._Landlord_Zip_Code = null;
            this._Landlord_Telephone = null;
            this._Landlord_Facsimile = null;
            this._Landlord_Email = null;
            this._Landlord_Copy_Company = null;
            this._Landlord_Copy_Contact = null;
            this._Landlord_Copy_Address1 = null;
            this._Landlord_Copy_Address2 = null;
            this._Landlord_Copy_City = null;
            this._FK_State_Landlord_Copy = null;
            this._Landlord_Copy_Zip_Code = null;
            this._Landlord_Copy_Telephone = null;
            this._Landlord_Copy_Facsimile = null;
            this._Landlord_Copy_Email = null;
            this._Tenant_Company = null;
            this._Tenant_Contact = null;
            this._Tenant_Address1 = null;
            this._Tenant_Address2 = null;
            this._Tenant_City = null;
            this._FK_State_Tenant = null;
            this._Tenant_Zip_Code = null;
            this._Tenant_Telephone = null;
            this._Tenant_Facsimile = null;
            this._Tenant_Email = null;
            this._Tenant_Copy_Company = null;
            this._Tenant_Copy_Contact = null;
            this._Tenant_Copy_Address1 = null;
            this._Tenant_Copy_Address2 = null;
            this._Tenant_Copy_City = null;
            this._FK_State_Tenant_Copy = null;
            this._Tenant_Copy_Zip_Code = null;
            this._Tenant_Copy_Telephone = null;
            this._Tenant_Copy_Facsimile = null;
            this._Tenant_Copy_Email = null;
            this._Subtenant_Company = null;
            this._Subtenant_Contact = null;
            this._Subtenant_Address1 = null;
            this._Subtenant_Address2 = null;
            this._Subtenant_City = null;
            this._FK_State_Subtenant = null;
            this._Subtenant_Zip_Code = null;
            this._Subtenant_Telephone = null;
            this._Subtenant_Facsimile = null;
            this._Subtenant_Email = null;
            this._Subtenant_Copy_Company = null;
            this._Subtenant_Copy_Contact = null;
            this._Subtenant_Copy_Address1 = null;
            this._Subtenant_Copy_Address2 = null;
            this._Subtenant_Copy_City = null;
            this._FK_State_Subtenant_Copy = null;
            this._Subtenant_Copy_Zip_Code = null;
            this._Subtenant_Copy_Telephone = null;
            this._Subtenant_Copy_Facsimile = null;
            this._Subtenant_Copy_Email = null;
            this._Updated_By = null;
            this._Update_Date = null;
        }

		/// <summary>
		/// Inserts a record into the RE_Notices table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NoticesInsert");

			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			if (string.IsNullOrEmpty(this._Landlord_Company))
				db.AddInParameter(dbCommand, "Landlord_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Company", DbType.String, this._Landlord_Company);
			
			if (string.IsNullOrEmpty(this._Landlord_Contact))
				db.AddInParameter(dbCommand, "Landlord_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Contact", DbType.String, this._Landlord_Contact);
			
			if (string.IsNullOrEmpty(this._Landlord_Address1))
				db.AddInParameter(dbCommand, "Landlord_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Address1", DbType.String, this._Landlord_Address1);
			
			if (string.IsNullOrEmpty(this._Landlord_Address2))
				db.AddInParameter(dbCommand, "Landlord_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Address2", DbType.String, this._Landlord_Address2);
			
			if (string.IsNullOrEmpty(this._Landlord_City))
				db.AddInParameter(dbCommand, "Landlord_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_City", DbType.String, this._Landlord_City);
			
			db.AddInParameter(dbCommand, "FK_State_Landlord", DbType.Decimal, this._FK_State_Landlord);
			
			if (string.IsNullOrEmpty(this._Landlord_Zip_Code))
				db.AddInParameter(dbCommand, "Landlord_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Zip_Code", DbType.String, this._Landlord_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Landlord_Telephone))
				db.AddInParameter(dbCommand, "Landlord_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Telephone", DbType.String, this._Landlord_Telephone);
			
			if (string.IsNullOrEmpty(this._Landlord_Facsimile))
				db.AddInParameter(dbCommand, "Landlord_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Facsimile", DbType.String, this._Landlord_Facsimile);
			
			if (string.IsNullOrEmpty(this._Landlord_Email))
				db.AddInParameter(dbCommand, "Landlord_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Email", DbType.String, this._Landlord_Email);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Company))
				db.AddInParameter(dbCommand, "Landlord_Copy_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Company", DbType.String, this._Landlord_Copy_Company);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Contact))
				db.AddInParameter(dbCommand, "Landlord_Copy_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Contact", DbType.String, this._Landlord_Copy_Contact);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Address1))
				db.AddInParameter(dbCommand, "Landlord_Copy_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Address1", DbType.String, this._Landlord_Copy_Address1);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Address2))
				db.AddInParameter(dbCommand, "Landlord_Copy_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Address2", DbType.String, this._Landlord_Copy_Address2);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_City))
				db.AddInParameter(dbCommand, "Landlord_Copy_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_City", DbType.String, this._Landlord_Copy_City);
			
			db.AddInParameter(dbCommand, "FK_State_Landlord_Copy", DbType.Decimal, this._FK_State_Landlord_Copy);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Zip_Code))
				db.AddInParameter(dbCommand, "Landlord_Copy_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Zip_Code", DbType.String, this._Landlord_Copy_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Telephone))
				db.AddInParameter(dbCommand, "Landlord_Copy_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Telephone", DbType.String, this._Landlord_Copy_Telephone);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Facsimile))
				db.AddInParameter(dbCommand, "Landlord_Copy_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Facsimile", DbType.String, this._Landlord_Copy_Facsimile);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Email))
				db.AddInParameter(dbCommand, "Landlord_Copy_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Email", DbType.String, this._Landlord_Copy_Email);
			
			if (string.IsNullOrEmpty(this._Tenant_Company))
				db.AddInParameter(dbCommand, "Tenant_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Company", DbType.String, this._Tenant_Company);
			
			if (string.IsNullOrEmpty(this._Tenant_Contact))
				db.AddInParameter(dbCommand, "Tenant_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Contact", DbType.String, this._Tenant_Contact);
			
			if (string.IsNullOrEmpty(this._Tenant_Address1))
				db.AddInParameter(dbCommand, "Tenant_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Address1", DbType.String, this._Tenant_Address1);
			
			if (string.IsNullOrEmpty(this._Tenant_Address2))
				db.AddInParameter(dbCommand, "Tenant_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Address2", DbType.String, this._Tenant_Address2);
			
			if (string.IsNullOrEmpty(this._Tenant_City))
				db.AddInParameter(dbCommand, "Tenant_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_City", DbType.String, this._Tenant_City);
			
			db.AddInParameter(dbCommand, "FK_State_Tenant", DbType.Decimal, this._FK_State_Tenant);
			
			if (string.IsNullOrEmpty(this._Tenant_Zip_Code))
				db.AddInParameter(dbCommand, "Tenant_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Zip_Code", DbType.String, this._Tenant_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Tenant_Telephone))
				db.AddInParameter(dbCommand, "Tenant_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Telephone", DbType.String, this._Tenant_Telephone);
			
			if (string.IsNullOrEmpty(this._Tenant_Facsimile))
				db.AddInParameter(dbCommand, "Tenant_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Facsimile", DbType.String, this._Tenant_Facsimile);
			
			if (string.IsNullOrEmpty(this._Tenant_Email))
				db.AddInParameter(dbCommand, "Tenant_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Email", DbType.String, this._Tenant_Email);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Company))
				db.AddInParameter(dbCommand, "Tenant_Copy_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Company", DbType.String, this._Tenant_Copy_Company);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Contact))
				db.AddInParameter(dbCommand, "Tenant_Copy_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Contact", DbType.String, this._Tenant_Copy_Contact);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Address1))
				db.AddInParameter(dbCommand, "Tenant_Copy_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Address1", DbType.String, this._Tenant_Copy_Address1);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Address2))
				db.AddInParameter(dbCommand, "Tenant_Copy_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Address2", DbType.String, this._Tenant_Copy_Address2);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_City))
				db.AddInParameter(dbCommand, "Tenant_Copy_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_City", DbType.String, this._Tenant_Copy_City);
			
			db.AddInParameter(dbCommand, "FK_State_Tenant_Copy", DbType.Decimal, this._FK_State_Tenant_Copy);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Zip_Code))
				db.AddInParameter(dbCommand, "Tenant_Copy_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Zip_Code", DbType.String, this._Tenant_Copy_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Telephone))
				db.AddInParameter(dbCommand, "Tenant_Copy_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Telephone", DbType.String, this._Tenant_Copy_Telephone);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Facsimile))
				db.AddInParameter(dbCommand, "Tenant_Copy_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Facsimile", DbType.String, this._Tenant_Copy_Facsimile);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Email))
				db.AddInParameter(dbCommand, "Tenant_Copy_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Email", DbType.String, this._Tenant_Copy_Email);
			
			if (string.IsNullOrEmpty(this._Subtenant_Company))
				db.AddInParameter(dbCommand, "Subtenant_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Company", DbType.String, this._Subtenant_Company);
			
			if (string.IsNullOrEmpty(this._Subtenant_Contact))
				db.AddInParameter(dbCommand, "Subtenant_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Contact", DbType.String, this._Subtenant_Contact);
			
			if (string.IsNullOrEmpty(this._Subtenant_Address1))
				db.AddInParameter(dbCommand, "Subtenant_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Address1", DbType.String, this._Subtenant_Address1);
			
			if (string.IsNullOrEmpty(this._Subtenant_Address2))
				db.AddInParameter(dbCommand, "Subtenant_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Address2", DbType.String, this._Subtenant_Address2);
			
			if (string.IsNullOrEmpty(this._Subtenant_City))
				db.AddInParameter(dbCommand, "Subtenant_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_City", DbType.String, this._Subtenant_City);
			
			db.AddInParameter(dbCommand, "FK_State_Subtenant", DbType.Decimal, this._FK_State_Subtenant);
			
			if (string.IsNullOrEmpty(this._Subtenant_Zip_Code))
				db.AddInParameter(dbCommand, "Subtenant_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Zip_Code", DbType.String, this._Subtenant_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Subtenant_Telephone))
				db.AddInParameter(dbCommand, "Subtenant_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Telephone", DbType.String, this._Subtenant_Telephone);
			
			if (string.IsNullOrEmpty(this._Subtenant_Facsimile))
				db.AddInParameter(dbCommand, "Subtenant_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Facsimile", DbType.String, this._Subtenant_Facsimile);
			
			if (string.IsNullOrEmpty(this._Subtenant_Email))
				db.AddInParameter(dbCommand, "Subtenant_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Email", DbType.String, this._Subtenant_Email);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Company))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Company", DbType.String, this._Subtenant_Copy_Company);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Contact))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Contact", DbType.String, this._Subtenant_Copy_Contact);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Address1))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Address1", DbType.String, this._Subtenant_Copy_Address1);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Address2))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Address2", DbType.String, this._Subtenant_Copy_Address2);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_City))
				db.AddInParameter(dbCommand, "Subtenant_Copy_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_City", DbType.String, this._Subtenant_Copy_City);
			
			db.AddInParameter(dbCommand, "FK_State_Subtenant_Copy", DbType.Decimal, this._FK_State_Subtenant_Copy);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Zip_Code))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Zip_Code", DbType.String, this._Subtenant_Copy_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Telephone))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Telephone", DbType.String, this._Subtenant_Copy_Telephone);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Facsimile))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Facsimile", DbType.String, this._Subtenant_Copy_Facsimile);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Email))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Email", DbType.String, this._Subtenant_Copy_Email);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the RE_Notices table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_RE_Notices)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NoticesSelectByPK");

			db.AddInParameter(dbCommand, "PK_RE_Notices", DbType.Decimal, pK_RE_Notices);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the RE_Notices table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByFK(decimal FK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_NoticesSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, FK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the RE_Notices table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NoticesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the RE_Notices table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NoticesUpdate");

			
			db.AddInParameter(dbCommand, "PK_RE_Notices", DbType.Decimal, this._PK_RE_Notices);
			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			if (string.IsNullOrEmpty(this._Landlord_Company))
				db.AddInParameter(dbCommand, "Landlord_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Company", DbType.String, this._Landlord_Company);
			
			if (string.IsNullOrEmpty(this._Landlord_Contact))
				db.AddInParameter(dbCommand, "Landlord_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Contact", DbType.String, this._Landlord_Contact);
			
			if (string.IsNullOrEmpty(this._Landlord_Address1))
				db.AddInParameter(dbCommand, "Landlord_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Address1", DbType.String, this._Landlord_Address1);
			
			if (string.IsNullOrEmpty(this._Landlord_Address2))
				db.AddInParameter(dbCommand, "Landlord_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Address2", DbType.String, this._Landlord_Address2);
			
			if (string.IsNullOrEmpty(this._Landlord_City))
				db.AddInParameter(dbCommand, "Landlord_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_City", DbType.String, this._Landlord_City);
			
			db.AddInParameter(dbCommand, "FK_State_Landlord", DbType.Decimal, this._FK_State_Landlord);
			
			if (string.IsNullOrEmpty(this._Landlord_Zip_Code))
				db.AddInParameter(dbCommand, "Landlord_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Zip_Code", DbType.String, this._Landlord_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Landlord_Telephone))
				db.AddInParameter(dbCommand, "Landlord_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Telephone", DbType.String, this._Landlord_Telephone);
			
			if (string.IsNullOrEmpty(this._Landlord_Facsimile))
				db.AddInParameter(dbCommand, "Landlord_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Facsimile", DbType.String, this._Landlord_Facsimile);
			
			if (string.IsNullOrEmpty(this._Landlord_Email))
				db.AddInParameter(dbCommand, "Landlord_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Email", DbType.String, this._Landlord_Email);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Company))
				db.AddInParameter(dbCommand, "Landlord_Copy_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Company", DbType.String, this._Landlord_Copy_Company);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Contact))
				db.AddInParameter(dbCommand, "Landlord_Copy_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Contact", DbType.String, this._Landlord_Copy_Contact);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Address1))
				db.AddInParameter(dbCommand, "Landlord_Copy_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Address1", DbType.String, this._Landlord_Copy_Address1);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Address2))
				db.AddInParameter(dbCommand, "Landlord_Copy_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Address2", DbType.String, this._Landlord_Copy_Address2);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_City))
				db.AddInParameter(dbCommand, "Landlord_Copy_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_City", DbType.String, this._Landlord_Copy_City);
			
			db.AddInParameter(dbCommand, "FK_State_Landlord_Copy", DbType.Decimal, this._FK_State_Landlord_Copy);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Zip_Code))
				db.AddInParameter(dbCommand, "Landlord_Copy_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Zip_Code", DbType.String, this._Landlord_Copy_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Telephone))
				db.AddInParameter(dbCommand, "Landlord_Copy_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Telephone", DbType.String, this._Landlord_Copy_Telephone);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Facsimile))
				db.AddInParameter(dbCommand, "Landlord_Copy_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Facsimile", DbType.String, this._Landlord_Copy_Facsimile);
			
			if (string.IsNullOrEmpty(this._Landlord_Copy_Email))
				db.AddInParameter(dbCommand, "Landlord_Copy_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Landlord_Copy_Email", DbType.String, this._Landlord_Copy_Email);
			
			if (string.IsNullOrEmpty(this._Tenant_Company))
				db.AddInParameter(dbCommand, "Tenant_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Company", DbType.String, this._Tenant_Company);
			
			if (string.IsNullOrEmpty(this._Tenant_Contact))
				db.AddInParameter(dbCommand, "Tenant_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Contact", DbType.String, this._Tenant_Contact);
			
			if (string.IsNullOrEmpty(this._Tenant_Address1))
				db.AddInParameter(dbCommand, "Tenant_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Address1", DbType.String, this._Tenant_Address1);
			
			if (string.IsNullOrEmpty(this._Tenant_Address2))
				db.AddInParameter(dbCommand, "Tenant_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Address2", DbType.String, this._Tenant_Address2);
			
			if (string.IsNullOrEmpty(this._Tenant_City))
				db.AddInParameter(dbCommand, "Tenant_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_City", DbType.String, this._Tenant_City);
			
			db.AddInParameter(dbCommand, "FK_State_Tenant", DbType.Decimal, this._FK_State_Tenant);
			
			if (string.IsNullOrEmpty(this._Tenant_Zip_Code))
				db.AddInParameter(dbCommand, "Tenant_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Zip_Code", DbType.String, this._Tenant_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Tenant_Telephone))
				db.AddInParameter(dbCommand, "Tenant_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Telephone", DbType.String, this._Tenant_Telephone);
			
			if (string.IsNullOrEmpty(this._Tenant_Facsimile))
				db.AddInParameter(dbCommand, "Tenant_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Facsimile", DbType.String, this._Tenant_Facsimile);
			
			if (string.IsNullOrEmpty(this._Tenant_Email))
				db.AddInParameter(dbCommand, "Tenant_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Email", DbType.String, this._Tenant_Email);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Company))
				db.AddInParameter(dbCommand, "Tenant_Copy_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Company", DbType.String, this._Tenant_Copy_Company);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Contact))
				db.AddInParameter(dbCommand, "Tenant_Copy_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Contact", DbType.String, this._Tenant_Copy_Contact);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Address1))
				db.AddInParameter(dbCommand, "Tenant_Copy_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Address1", DbType.String, this._Tenant_Copy_Address1);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Address2))
				db.AddInParameter(dbCommand, "Tenant_Copy_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Address2", DbType.String, this._Tenant_Copy_Address2);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_City))
				db.AddInParameter(dbCommand, "Tenant_Copy_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_City", DbType.String, this._Tenant_Copy_City);
			
			db.AddInParameter(dbCommand, "FK_State_Tenant_Copy", DbType.Decimal, this._FK_State_Tenant_Copy);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Zip_Code))
				db.AddInParameter(dbCommand, "Tenant_Copy_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Zip_Code", DbType.String, this._Tenant_Copy_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Telephone))
				db.AddInParameter(dbCommand, "Tenant_Copy_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Telephone", DbType.String, this._Tenant_Copy_Telephone);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Facsimile))
				db.AddInParameter(dbCommand, "Tenant_Copy_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Facsimile", DbType.String, this._Tenant_Copy_Facsimile);
			
			if (string.IsNullOrEmpty(this._Tenant_Copy_Email))
				db.AddInParameter(dbCommand, "Tenant_Copy_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tenant_Copy_Email", DbType.String, this._Tenant_Copy_Email);
			
			if (string.IsNullOrEmpty(this._Subtenant_Company))
				db.AddInParameter(dbCommand, "Subtenant_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Company", DbType.String, this._Subtenant_Company);
			
			if (string.IsNullOrEmpty(this._Subtenant_Contact))
				db.AddInParameter(dbCommand, "Subtenant_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Contact", DbType.String, this._Subtenant_Contact);
			
			if (string.IsNullOrEmpty(this._Subtenant_Address1))
				db.AddInParameter(dbCommand, "Subtenant_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Address1", DbType.String, this._Subtenant_Address1);
			
			if (string.IsNullOrEmpty(this._Subtenant_Address2))
				db.AddInParameter(dbCommand, "Subtenant_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Address2", DbType.String, this._Subtenant_Address2);
			
			if (string.IsNullOrEmpty(this._Subtenant_City))
				db.AddInParameter(dbCommand, "Subtenant_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_City", DbType.String, this._Subtenant_City);
			
			db.AddInParameter(dbCommand, "FK_State_Subtenant", DbType.Decimal, this._FK_State_Subtenant);
			
			if (string.IsNullOrEmpty(this._Subtenant_Zip_Code))
				db.AddInParameter(dbCommand, "Subtenant_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Zip_Code", DbType.String, this._Subtenant_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Subtenant_Telephone))
				db.AddInParameter(dbCommand, "Subtenant_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Telephone", DbType.String, this._Subtenant_Telephone);
			
			if (string.IsNullOrEmpty(this._Subtenant_Facsimile))
				db.AddInParameter(dbCommand, "Subtenant_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Facsimile", DbType.String, this._Subtenant_Facsimile);
			
			if (string.IsNullOrEmpty(this._Subtenant_Email))
				db.AddInParameter(dbCommand, "Subtenant_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Email", DbType.String, this._Subtenant_Email);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Company))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Company", DbType.String, this._Subtenant_Copy_Company);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Contact))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Contact", DbType.String, this._Subtenant_Copy_Contact);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Address1))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Address1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Address1", DbType.String, this._Subtenant_Copy_Address1);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Address2))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Address2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Address2", DbType.String, this._Subtenant_Copy_Address2);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_City))
				db.AddInParameter(dbCommand, "Subtenant_Copy_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_City", DbType.String, this._Subtenant_Copy_City);
			
			db.AddInParameter(dbCommand, "FK_State_Subtenant_Copy", DbType.Decimal, this._FK_State_Subtenant_Copy);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Zip_Code))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Zip_Code", DbType.String, this._Subtenant_Copy_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Telephone))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Telephone", DbType.String, this._Subtenant_Copy_Telephone);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Facsimile))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Facsimile", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Facsimile", DbType.String, this._Subtenant_Copy_Facsimile);
			
			if (string.IsNullOrEmpty(this._Subtenant_Copy_Email))
				db.AddInParameter(dbCommand, "Subtenant_Copy_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subtenant_Copy_Email", DbType.String, this._Subtenant_Copy_Email);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the RE_Notices table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_RE_Notices)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NoticesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_RE_Notices", DbType.Decimal, pK_RE_Notices);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
