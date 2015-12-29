using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Contractor_Firm table.
	/// </summary>
	public sealed class Contractor_Firm
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Contractor_Firm;
		private string _Contractor_Firm_Name;
		private string _Address_1;
		private string _Address_2;
		private string _City;
		private decimal? _FK_State;
		private string _Office_Telephone;
		private string _Cell_Telephone;
		private string _Pager;
		private string _Email;
        private string _Zip_Code;
        private DateTime? _Update_Date;
        private string _Updated_By;
        private decimal? _FK_LU_Firm_type;
        private string _Contact_Name;
        private string _Facsimile_Number;
        

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Contractor_Firm value.
		/// </summary>
		public decimal? PK_Contractor_Firm
		{
			get { return _PK_Contractor_Firm; }
			set { _PK_Contractor_Firm = value; }
		}

		/// <summary>
		/// Gets or sets the Contractor_Firm_Name value.
		/// </summary>
		public string Contractor_Firm_Name
		{
			get { return _Contractor_Firm_Name; }
			set { _Contractor_Firm_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Address_1 value.
		/// </summary>
		public string Address_1
		{
			get { return _Address_1; }
			set { _Address_1 = value; }
		}

		/// <summary>
		/// Gets or sets the Address_2 value.
		/// </summary>
		public string Address_2
		{
			get { return _Address_2; }
			set { _Address_2 = value; }
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
		/// Gets or sets the Office_Telephone value.
		/// </summary>
		public string Office_Telephone
		{
			get { return _Office_Telephone; }
			set { _Office_Telephone = value; }
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
		/// Gets or sets the Pager value.
		/// </summary>
		public string Pager
		{
			get { return _Pager; }
			set { _Pager = value; }
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
        /// Gets or sets the Zip Code.
        /// </summary>
        public string Zip_Code
        {
            get { return _Zip_Code; }
            set { _Zip_Code = value; }
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
        /// Gets or sets the FK_LU_Firm_type value.
        /// </summary>
        public decimal? FK_LU_Firm_type
        {
            get { return _FK_LU_Firm_type; }
            set { _FK_LU_Firm_type = value; }
        }

        /// <summary>
        /// Gets or sets the Contact_Name value.
        /// </summary>
        public string Contact_Name
        {
            get { return _Contact_Name; }
            set { _Contact_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Facsimile_Number value.
        /// </summary>
        public string Facsimile_Number
        {
            get { return _Facsimile_Number; }
            set { _Facsimile_Number = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Contractor_Firm class with default value.
		/// </summary>
		public Contractor_Firm() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Contractor_Firm class based on Primary Key.
		/// </summary>
		public Contractor_Firm(decimal pK_Contractor_Firm) 
		{
			DataTable dtContractor_Firm = SelectByPK(pK_Contractor_Firm).Tables[0];

			if (dtContractor_Firm.Rows.Count == 1)
			{
				 SetValue(dtContractor_Firm.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Contractor_Firm class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drContractor_Firm) 
		{
				if (drContractor_Firm["PK_Contractor_Firm"] == DBNull.Value)
					this._PK_Contractor_Firm = null;
				else
					this._PK_Contractor_Firm = (decimal?)drContractor_Firm["PK_Contractor_Firm"];

				if (drContractor_Firm["Contractor_Firm_Name"] == DBNull.Value)
					this._Contractor_Firm_Name = null;
				else
					this._Contractor_Firm_Name = (string)drContractor_Firm["Contractor_Firm_Name"];

				if (drContractor_Firm["Address_1"] == DBNull.Value)
					this._Address_1 = null;
				else
					this._Address_1 = (string)drContractor_Firm["Address_1"];

				if (drContractor_Firm["Address_2"] == DBNull.Value)
					this._Address_2 = null;
				else
					this._Address_2 = (string)drContractor_Firm["Address_2"];

				if (drContractor_Firm["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drContractor_Firm["City"];

				if (drContractor_Firm["FK_State"] == DBNull.Value)
					this._FK_State = null;
				else
					this._FK_State = (decimal?)drContractor_Firm["FK_State"];

				if (drContractor_Firm["Office_Telephone"] == DBNull.Value)
					this._Office_Telephone = null;
				else
					this._Office_Telephone = (string)drContractor_Firm["Office_Telephone"];

				if (drContractor_Firm["Cell_Telephone"] == DBNull.Value)
					this._Cell_Telephone = null;
				else
					this._Cell_Telephone = (string)drContractor_Firm["Cell_Telephone"];

				if (drContractor_Firm["Pager"] == DBNull.Value)
					this._Pager = null;
				else
					this._Pager = (string)drContractor_Firm["Pager"];

				if (drContractor_Firm["Email"] == DBNull.Value)
					this._Email = null;
				else
					this._Email = (string)drContractor_Firm["Email"];

                if (drContractor_Firm["Zip_Code"] == DBNull.Value)
                    this._Zip_Code = null;
                else
                    this._Zip_Code = (string)drContractor_Firm["Zip_Code"];

                if (drContractor_Firm["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drContractor_Firm["Update_Date"];

                if (drContractor_Firm["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drContractor_Firm["Updated_By"];

                if (drContractor_Firm["FK_LU_Firm_type"] == DBNull.Value)
                    this._FK_LU_Firm_type = null;
                else
                    this._FK_LU_Firm_type = (decimal?)drContractor_Firm["FK_LU_Firm_type"];

                if (drContractor_Firm["Contact_Name"] == DBNull.Value)
                    this._Contact_Name = null;
                else
                    this._Contact_Name = (string)drContractor_Firm["Contact_Name"];

                if (drContractor_Firm["Facsimile_Number"] == DBNull.Value)
                    this._Facsimile_Number = null;
                else
                    this._Facsimile_Number = (string)drContractor_Firm["Facsimile_Number"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Contractor_Firm table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Contractor_FirmInsert");

			
			if (string.IsNullOrEmpty(this._Contractor_Firm_Name))
				db.AddInParameter(dbCommand, "Contractor_Firm_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contractor_Firm_Name", DbType.String, this._Contractor_Firm_Name);
			
			if (string.IsNullOrEmpty(this._Address_1))
				db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			
			if (string.IsNullOrEmpty(this._Address_2))
				db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			
			if (string.IsNullOrEmpty(this._Office_Telephone))
				db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, this._Office_Telephone);
			
			if (string.IsNullOrEmpty(this._Cell_Telephone))
				db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);
			
			if (string.IsNullOrEmpty(this._Pager))
				db.AddInParameter(dbCommand, "Pager", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Pager", DbType.String, this._Pager);
			
			if (string.IsNullOrEmpty(this._Email))
				db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "FK_LU_Firm_type", DbType.Decimal, this._FK_LU_Firm_type);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._Facsimile_Number))
                db.AddInParameter(dbCommand, "Facsimile_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Facsimile_Number", DbType.String, this._Facsimile_Number);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Contractor_Firm table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Contractor_Firm)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Contractor_FirmSelectByPK");

			db.AddInParameter(dbCommand, "PK_Contractor_Firm", DbType.Decimal, pK_Contractor_Firm);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Contractor_Firm table.
		/// </summary>
		/// <returns>DataSet</returns>
        public static DataSet SelectAll(string SearchString, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Contractor_FirmSelectAll");
            db.AddInParameter(dbCommand, "@SearchString", DbType.String, SearchString);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Contractor_Firm table By UserID.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUserId(decimal fK_Contractor_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_FirmByUserID");

            db.AddInParameter(dbCommand, "FK_Contractor_Security", DbType.Decimal, fK_Contractor_Security);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the Contractor_Firm table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Contractor_FirmUpdate");

			
			db.AddInParameter(dbCommand, "PK_Contractor_Firm", DbType.Decimal, this._PK_Contractor_Firm);
			
			if (string.IsNullOrEmpty(this._Contractor_Firm_Name))
				db.AddInParameter(dbCommand, "Contractor_Firm_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contractor_Firm_Name", DbType.String, this._Contractor_Firm_Name);
			
			if (string.IsNullOrEmpty(this._Address_1))
				db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			
			if (string.IsNullOrEmpty(this._Address_2))
				db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			
			if (string.IsNullOrEmpty(this._Office_Telephone))
				db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, this._Office_Telephone);
			
			if (string.IsNullOrEmpty(this._Cell_Telephone))
				db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);
			
			if (string.IsNullOrEmpty(this._Pager))
				db.AddInParameter(dbCommand, "Pager", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Pager", DbType.String, this._Pager);
			
			if (string.IsNullOrEmpty(this._Email))
				db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "FK_LU_Firm_type", DbType.Decimal, this._FK_LU_Firm_type);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._Facsimile_Number))
                db.AddInParameter(dbCommand, "Facsimile_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Facsimile_Number", DbType.String, this._Facsimile_Number);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
		}

		/// <summary>
		/// Deletes multiple record from the Contractor_Firm table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(string pK_Contractor_Firm)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Contractor_FirmDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Contractor_Firm", DbType.String, pK_Contractor_Firm);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the Contractor_Firm table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFirmName()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_FirmNameList");


            return db.ExecuteDataSet(dbCommand);
        }
	}
}
