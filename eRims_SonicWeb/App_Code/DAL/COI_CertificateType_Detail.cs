using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table COI_CertificateType_Detail
	/// </summary>
	public sealed class COI_CertificateType_Detail
	{

		#region Private variables used to hold the property values

		private decimal? _PK_COI_Certificate_Detail_ID;
		private decimal? _FK_COIs;
		private decimal? _FK_CertificateType_ID;
		private DateTime? _Date_Issued;
		private bool? _Is_Certificate_Signed;
		private bool? _Is_Waver_Of_Subrogation;
		private bool? _Is_Certificate_Include_NOC;
		private int? _Number_of_Days;
		private bool? _Is_MasterClause_Required;
		private bool? _Is_Loss_Payee_Required;
        private string _FK_Additional_IDs;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_COI_Certificate_Detail_ID value.
		/// </summary>
		public decimal? PK_COI_Certificate_Detail_ID
		{
			get { return _PK_COI_Certificate_Detail_ID; }
			set { _PK_COI_Certificate_Detail_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_COIs value.
		/// </summary>
		public decimal? FK_COIs
		{
			get { return _FK_COIs; }
			set { _FK_COIs = value; }
		}

		/// <summary>
		/// Gets or sets the FK_CertificateType_ID value.
		/// </summary>
		public decimal? FK_CertificateType_ID
		{
			get { return _FK_CertificateType_ID; }
			set { _FK_CertificateType_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Issued value.
		/// </summary>
		public DateTime? Date_Issued
		{
			get { return _Date_Issued; }
			set { _Date_Issued = value; }
		}

		/// <summary>
		/// Gets or sets the Is_Certificate_Signed value.
		/// </summary>
		public bool? Is_Certificate_Signed
		{
			get { return _Is_Certificate_Signed; }
			set { _Is_Certificate_Signed = value; }
		}

		/// <summary>
		/// Gets or sets the Is_Waver_Of_Subrogation value.
		/// </summary>
		public bool? Is_Waver_Of_Subrogation
		{
			get { return _Is_Waver_Of_Subrogation; }
			set { _Is_Waver_Of_Subrogation = value; }
		}

		/// <summary>
		/// Gets or sets the Is_Certificate_Include_NOC value.
		/// </summary>
		public bool? Is_Certificate_Include_NOC
		{
			get { return _Is_Certificate_Include_NOC; }
			set { _Is_Certificate_Include_NOC = value; }
		}

		/// <summary>
		/// Gets or sets the Number_of_Days value.
		/// </summary>
		public int? Number_of_Days
		{
			get { return _Number_of_Days; }
			set { _Number_of_Days = value; }
		}

		/// <summary>
		/// Gets or sets the Is_MasterClause_Required value.
		/// </summary>
		public bool? Is_MasterClause_Required
		{
			get { return _Is_MasterClause_Required; }
			set { _Is_MasterClause_Required = value; }
		}

        /// <summary>
        /// Gets or sets the Is_Certificate_Signed value.
        /// </summary>
        public bool? Is_Loss_Payee_Required
        {
            get { return _Is_Loss_Payee_Required; }
            set { _Is_Loss_Payee_Required = value; }
        }

		/// <summary>
        /// Gets or sets the FK_Additional_IDs value.
		/// </summary>
        public string FK_Additional_IDs
		{
            get { return _FK_Additional_IDs; }
            set { _FK_Additional_IDs = value; }
		}

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the COI_CertificateType_Detail class with default value.
		/// </summary>
		public COI_CertificateType_Detail() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the COI_CertificateType_Detail class based on Primary Key.
		/// </summary>
		public COI_CertificateType_Detail(decimal pK_COI_Certificate_Detail_ID) 
		{
			DataTable dtCOI_CertificateType_Detail = Select(pK_COI_Certificate_Detail_ID).Tables[0];

			if (dtCOI_CertificateType_Detail.Rows.Count == 1)
			{
				 SetValue(dtCOI_CertificateType_Detail.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the COI_CertificateType_Detail class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drCOI_CertificateType_Detail) 
		{
				if (drCOI_CertificateType_Detail["PK_COI_Certificate_Detail_ID"] == DBNull.Value)
					this._PK_COI_Certificate_Detail_ID = null;
				else
					this._PK_COI_Certificate_Detail_ID = (decimal?)drCOI_CertificateType_Detail["PK_COI_Certificate_Detail_ID"];

				if (drCOI_CertificateType_Detail["FK_COIs"] == DBNull.Value)
					this._FK_COIs = null;
				else
					this._FK_COIs = (decimal?)drCOI_CertificateType_Detail["FK_COIs"];

				if (drCOI_CertificateType_Detail["FK_CertificateType_ID"] == DBNull.Value)
					this._FK_CertificateType_ID = null;
				else
					this._FK_CertificateType_ID = (decimal?)drCOI_CertificateType_Detail["FK_CertificateType_ID"];

				if (drCOI_CertificateType_Detail["Date_Issued"] == DBNull.Value)
					this._Date_Issued = null;
				else
					this._Date_Issued = (DateTime?)drCOI_CertificateType_Detail["Date_Issued"];

				if (drCOI_CertificateType_Detail["Is_Certificate_Signed"] == DBNull.Value)
					this._Is_Certificate_Signed = null;
				else
					this._Is_Certificate_Signed = (bool?)drCOI_CertificateType_Detail["Is_Certificate_Signed"];

				if (drCOI_CertificateType_Detail["Is_Waver_Of_Subrogation"] == DBNull.Value)
					this._Is_Waver_Of_Subrogation = null;
				else
					this._Is_Waver_Of_Subrogation = (bool?)drCOI_CertificateType_Detail["Is_Waver_Of_Subrogation"];

				if (drCOI_CertificateType_Detail["Is_Certificate_Include_NOC"] == DBNull.Value)
					this._Is_Certificate_Include_NOC = null;
				else
					this._Is_Certificate_Include_NOC = (bool?)drCOI_CertificateType_Detail["Is_Certificate_Include_NOC"];

				if (drCOI_CertificateType_Detail["Number_of_Days"] == DBNull.Value)
					this._Number_of_Days = null;
				else
					this._Number_of_Days = (int?)drCOI_CertificateType_Detail["Number_of_Days"];

				if (drCOI_CertificateType_Detail["Is_MasterClause_Required"] == DBNull.Value)
					this._Is_MasterClause_Required = null;
				else
					this._Is_MasterClause_Required = (bool?)drCOI_CertificateType_Detail["Is_MasterClause_Required"];

				if (drCOI_CertificateType_Detail["Is_Loss_Payee_Required"] == DBNull.Value)
					this._Is_Loss_Payee_Required = null;
				else
					this._Is_Loss_Payee_Required = (bool?)drCOI_CertificateType_Detail["Is_Loss_Payee_Required"];

                if (drCOI_CertificateType_Detail["FK_Additional_IDs"] == DBNull.Value)
                    this._FK_Additional_IDs = null;
				else
                    this._FK_Additional_IDs = (string)drCOI_CertificateType_Detail["FK_Additional_IDs"];
            

		}

		#endregion

		/// <summary>
		/// Inserts a record into the COI_CertificateType_Detail table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_DetailInsert");

			
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, this._FK_COIs);
			
			db.AddInParameter(dbCommand, "FK_CertificateType_ID", DbType.Decimal, this._FK_CertificateType_ID);
			
			db.AddInParameter(dbCommand, "Date_Issued", DbType.DateTime, this._Date_Issued);
			
			db.AddInParameter(dbCommand, "Is_Certificate_Signed", DbType.Boolean, this._Is_Certificate_Signed);
			
			db.AddInParameter(dbCommand, "Is_Waver_Of_Subrogation", DbType.Boolean, this._Is_Waver_Of_Subrogation);
			
			db.AddInParameter(dbCommand, "Is_Certificate_Include_NOC", DbType.Boolean, this._Is_Certificate_Include_NOC);
			
			db.AddInParameter(dbCommand, "Number_of_Days", DbType.Int32, this._Number_of_Days);
			
			db.AddInParameter(dbCommand, "Is_MasterClause_Required", DbType.Boolean, this._Is_MasterClause_Required);
			
			db.AddInParameter(dbCommand, "Is_Loss_Payee_Required", DbType.Boolean, this._Is_Loss_Payee_Required);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_CertificateType_Detail table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_COI_Certificate_Detail_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_DetailSelect");

			db.AddInParameter(dbCommand, "PK_COI_Certificate_Detail_ID", DbType.Decimal, pK_COI_Certificate_Detail_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_CertificateType_Detail table.
		/// </summary>
		/// <returns>DataSet</returns>
        public static DataSet SelectAll(decimal FK_COIs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_DetailSelectAll");
            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, FK_COIs);
			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the COI_CertificateType_Detail table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_DetailUpdate");

			
			db.AddInParameter(dbCommand, "PK_COI_Certificate_Detail_ID", DbType.Decimal, this._PK_COI_Certificate_Detail_ID);
			
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, this._FK_COIs);
			
			db.AddInParameter(dbCommand, "FK_CertificateType_ID", DbType.Decimal, this._FK_CertificateType_ID);
			
			db.AddInParameter(dbCommand, "Date_Issued", DbType.DateTime, this._Date_Issued);
			
			db.AddInParameter(dbCommand, "Is_Certificate_Signed", DbType.Boolean, this._Is_Certificate_Signed);
			
			db.AddInParameter(dbCommand, "Is_Waver_Of_Subrogation", DbType.Boolean, this._Is_Waver_Of_Subrogation);
			
			db.AddInParameter(dbCommand, "Is_Certificate_Include_NOC", DbType.Boolean, this._Is_Certificate_Include_NOC);
			
			db.AddInParameter(dbCommand, "Number_of_Days", DbType.Int32, this._Number_of_Days);
			
			db.AddInParameter(dbCommand, "Is_MasterClause_Required", DbType.Boolean, this._Is_MasterClause_Required);
			
			db.AddInParameter(dbCommand, "Is_Loss_Payee_Required", DbType.Boolean, this._Is_Loss_Payee_Required);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_CertificateType_Detail table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_COI_Certificate_Detail_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_DetailDelete");

			db.AddInParameter(dbCommand, "PK_COI_Certificate_Detail_ID", DbType.Decimal, pK_COI_Certificate_Detail_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
