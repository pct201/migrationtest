using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for EPM_Project_Cost_Invoice table.
	/// </summary>
	public sealed class clsEPM_Project_Cost_Invoice
	{

		#region Private variables used to hold the property values

		private decimal? _PK_EPM_Project_Cost_Invoice;
		private decimal? _FK_EPM_Identification;
		private string _Invoice_Number;
		private DateTime? _Invoice_Date;
		private decimal? _Invoice_Amount;
		private decimal? _Invoice_Charges_RM;
		private decimal? _Invoice_Charges_CD_RE;
		private decimal? _Invoice_Charges_Store;
		private string _Vendor;
		private string _Vendor_Address;
		private string _Vendor_City;
		private decimal? _FK_Vendor_State;
		private string _Vendor_Zip_Code;
		private string _Vendor_Contact;
		private string _Vendor_Telephone;
		private string _Vendor_Email;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_EPM_Project_Cost_Invoice value.
		/// </summary>
		public decimal? PK_EPM_Project_Cost_Invoice
		{
			get { return _PK_EPM_Project_Cost_Invoice; }
			set { _PK_EPM_Project_Cost_Invoice = value; }
		}

		/// <summary>
		/// Gets or sets the FK_EPM_Identification value.
		/// </summary>
		public decimal? FK_EPM_Identification
		{
			get { return _FK_EPM_Identification; }
			set { _FK_EPM_Identification = value; }
		}

		/// <summary>
		/// Gets or sets the Invoice_Number value.
		/// </summary>
		public string Invoice_Number
		{
			get { return _Invoice_Number; }
			set { _Invoice_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Invoice_Date value.
		/// </summary>
		public DateTime? Invoice_Date
		{
			get { return _Invoice_Date; }
			set { _Invoice_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Invoice_Amount value.
		/// </summary>
		public decimal? Invoice_Amount
		{
			get { return _Invoice_Amount; }
			set { _Invoice_Amount = value; }
		}

		/// <summary>
		/// Gets or sets the Invoice_Charges_RM value.
		/// </summary>
		public decimal? Invoice_Charges_RM
		{
			get { return _Invoice_Charges_RM; }
			set { _Invoice_Charges_RM = value; }
		}

		/// <summary>
		/// Gets or sets the Invoice_Charges_CD_RE value.
		/// </summary>
		public decimal? Invoice_Charges_CD_RE
		{
			get { return _Invoice_Charges_CD_RE; }
			set { _Invoice_Charges_CD_RE = value; }
		}

		/// <summary>
		/// Gets or sets the Invoice_Charges_Store value.
		/// </summary>
		public decimal? Invoice_Charges_Store
		{
			get { return _Invoice_Charges_Store; }
			set { _Invoice_Charges_Store = value; }
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
		/// Gets or sets the Vendor_Contact value.
		/// </summary>
		public string Vendor_Contact
		{
			get { return _Vendor_Contact; }
			set { _Vendor_Contact = value; }
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
		/// Gets or sets the Vendor_Email value.
		/// </summary>
		public string Vendor_Email
		{
			get { return _Vendor_Email; }
			set { _Vendor_Email = value; }
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
		/// Initializes a new instance of the clsEPM_Project_Cost_Invoice class with default value.
		/// </summary>
		public clsEPM_Project_Cost_Invoice() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsEPM_Project_Cost_Invoice class based on Primary Key.
		/// </summary>
		public clsEPM_Project_Cost_Invoice(decimal pK_EPM_Project_Cost_Invoice) 
		{
			DataTable dtEPM_Project_Cost_Invoice = SelectByPK(pK_EPM_Project_Cost_Invoice).Tables[0];

			if (dtEPM_Project_Cost_Invoice.Rows.Count == 1)
			{
				 SetValue(dtEPM_Project_Cost_Invoice.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsEPM_Project_Cost_Invoice class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drEPM_Project_Cost_Invoice) 
		{
				if (drEPM_Project_Cost_Invoice["PK_EPM_Project_Cost_Invoice"] == DBNull.Value)
					this._PK_EPM_Project_Cost_Invoice = null;
				else
					this._PK_EPM_Project_Cost_Invoice = (decimal?)drEPM_Project_Cost_Invoice["PK_EPM_Project_Cost_Invoice"];

				if (drEPM_Project_Cost_Invoice["FK_EPM_Identification"] == DBNull.Value)
					this._FK_EPM_Identification = null;
				else
					this._FK_EPM_Identification = (decimal?)drEPM_Project_Cost_Invoice["FK_EPM_Identification"];

				if (drEPM_Project_Cost_Invoice["Invoice_Number"] == DBNull.Value)
					this._Invoice_Number = null;
				else
					this._Invoice_Number = (string)drEPM_Project_Cost_Invoice["Invoice_Number"];

				if (drEPM_Project_Cost_Invoice["Invoice_Date"] == DBNull.Value)
					this._Invoice_Date = null;
				else
					this._Invoice_Date = (DateTime?)drEPM_Project_Cost_Invoice["Invoice_Date"];

				if (drEPM_Project_Cost_Invoice["Invoice_Amount"] == DBNull.Value)
					this._Invoice_Amount = null;
				else
					this._Invoice_Amount = (decimal?)drEPM_Project_Cost_Invoice["Invoice_Amount"];

				if (drEPM_Project_Cost_Invoice["Invoice_Charges_RM"] == DBNull.Value)
					this._Invoice_Charges_RM = null;
				else
					this._Invoice_Charges_RM = (decimal?)drEPM_Project_Cost_Invoice["Invoice_Charges_RM"];

				if (drEPM_Project_Cost_Invoice["Invoice_Charges_CD_RE"] == DBNull.Value)
					this._Invoice_Charges_CD_RE = null;
				else
					this._Invoice_Charges_CD_RE = (decimal?)drEPM_Project_Cost_Invoice["Invoice_Charges_CD_RE"];

				if (drEPM_Project_Cost_Invoice["Invoice_Charges_Store"] == DBNull.Value)
					this._Invoice_Charges_Store = null;
				else
					this._Invoice_Charges_Store = (decimal?)drEPM_Project_Cost_Invoice["Invoice_Charges_Store"];

				if (drEPM_Project_Cost_Invoice["Vendor"] == DBNull.Value)
					this._Vendor = null;
				else
					this._Vendor = (string)drEPM_Project_Cost_Invoice["Vendor"];

				if (drEPM_Project_Cost_Invoice["Vendor_Address"] == DBNull.Value)
					this._Vendor_Address = null;
				else
					this._Vendor_Address = (string)drEPM_Project_Cost_Invoice["Vendor_Address"];

				if (drEPM_Project_Cost_Invoice["Vendor_City"] == DBNull.Value)
					this._Vendor_City = null;
				else
					this._Vendor_City = (string)drEPM_Project_Cost_Invoice["Vendor_City"];

				if (drEPM_Project_Cost_Invoice["FK_Vendor_State"] == DBNull.Value)
					this._FK_Vendor_State = null;
				else
					this._FK_Vendor_State = (decimal?)drEPM_Project_Cost_Invoice["FK_Vendor_State"];

				if (drEPM_Project_Cost_Invoice["Vendor_Zip_Code"] == DBNull.Value)
					this._Vendor_Zip_Code = null;
				else
					this._Vendor_Zip_Code = (string)drEPM_Project_Cost_Invoice["Vendor_Zip_Code"];

				if (drEPM_Project_Cost_Invoice["Vendor_Contact"] == DBNull.Value)
					this._Vendor_Contact = null;
				else
					this._Vendor_Contact = (string)drEPM_Project_Cost_Invoice["Vendor_Contact"];

				if (drEPM_Project_Cost_Invoice["Vendor_Telephone"] == DBNull.Value)
					this._Vendor_Telephone = null;
				else
					this._Vendor_Telephone = (string)drEPM_Project_Cost_Invoice["Vendor_Telephone"];

				if (drEPM_Project_Cost_Invoice["Vendor_Email"] == DBNull.Value)
					this._Vendor_Email = null;
				else
					this._Vendor_Email = (string)drEPM_Project_Cost_Invoice["Vendor_Email"];

				if (drEPM_Project_Cost_Invoice["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drEPM_Project_Cost_Invoice["Updated_By"];

				if (drEPM_Project_Cost_Invoice["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drEPM_Project_Cost_Invoice["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the EPM_Project_Cost_Invoice table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_Cost_InvoiceInsert");

			
			db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);
			
			if (string.IsNullOrEmpty(this._Invoice_Number))
				db.AddInParameter(dbCommand, "Invoice_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Invoice_Number", DbType.String, this._Invoice_Number);
			
			db.AddInParameter(dbCommand, "Invoice_Date", DbType.DateTime, this._Invoice_Date);
			
			db.AddInParameter(dbCommand, "Invoice_Amount", DbType.Decimal, this._Invoice_Amount);
			
			db.AddInParameter(dbCommand, "Invoice_Charges_RM", DbType.Decimal, this._Invoice_Charges_RM);
			
			db.AddInParameter(dbCommand, "Invoice_Charges_CD_RE", DbType.Decimal, this._Invoice_Charges_CD_RE);
			
			db.AddInParameter(dbCommand, "Invoice_Charges_Store", DbType.Decimal, this._Invoice_Charges_Store);
			
			if (string.IsNullOrEmpty(this._Vendor))
				db.AddInParameter(dbCommand, "Vendor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor", DbType.String, this._Vendor);
			
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
			
			if (string.IsNullOrEmpty(this._Vendor_Contact))
				db.AddInParameter(dbCommand, "Vendor_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Contact", DbType.String, this._Vendor_Contact);
			
			if (string.IsNullOrEmpty(this._Vendor_Telephone))
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, this._Vendor_Telephone);
			
			if (string.IsNullOrEmpty(this._Vendor_Email))
				db.AddInParameter(dbCommand, "Vendor_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Email", DbType.String, this._Vendor_Email);
			
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
		/// Selects a single record from the EPM_Project_Cost_Invoice table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet SelectByPK(decimal pK_EPM_Project_Cost_Invoice)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_Cost_InvoiceSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Project_Cost_Invoice", DbType.Decimal, pK_EPM_Project_Cost_Invoice);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the EPM_Project_Cost_Invoice table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_Cost_InvoiceSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the EPM_Project_Cost_Invoice table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_Cost_InvoiceUpdate");

			
			db.AddInParameter(dbCommand, "PK_EPM_Project_Cost_Invoice", DbType.Decimal, this._PK_EPM_Project_Cost_Invoice);
			
			db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);
			
			if (string.IsNullOrEmpty(this._Invoice_Number))
				db.AddInParameter(dbCommand, "Invoice_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Invoice_Number", DbType.String, this._Invoice_Number);
			
			db.AddInParameter(dbCommand, "Invoice_Date", DbType.DateTime, this._Invoice_Date);
			
			db.AddInParameter(dbCommand, "Invoice_Amount", DbType.Decimal, this._Invoice_Amount);
			
			db.AddInParameter(dbCommand, "Invoice_Charges_RM", DbType.Decimal, this._Invoice_Charges_RM);
			
			db.AddInParameter(dbCommand, "Invoice_Charges_CD_RE", DbType.Decimal, this._Invoice_Charges_CD_RE);
			
			db.AddInParameter(dbCommand, "Invoice_Charges_Store", DbType.Decimal, this._Invoice_Charges_Store);
			
			if (string.IsNullOrEmpty(this._Vendor))
				db.AddInParameter(dbCommand, "Vendor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor", DbType.String, this._Vendor);
			
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
			
			if (string.IsNullOrEmpty(this._Vendor_Contact))
				db.AddInParameter(dbCommand, "Vendor_Contact", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Contact", DbType.String, this._Vendor_Contact);
			
			if (string.IsNullOrEmpty(this._Vendor_Telephone))
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, this._Vendor_Telephone);
			
			if (string.IsNullOrEmpty(this._Vendor_Email))
				db.AddInParameter(dbCommand, "Vendor_Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Email", DbType.String, this._Vendor_Email);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the EPM_Project_Cost_Invoice table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_EPM_Project_Cost_Invoice)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_Cost_InvoiceDeleteByPK");

			db.AddInParameter(dbCommand, "PK_EPM_Project_Cost_Invoice", DbType.Decimal, pK_EPM_Project_Cost_Invoice);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the EPM_Project_Cost_Invoice table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet SelectByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_Cost_InvoiceSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
