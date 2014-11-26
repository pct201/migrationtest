using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table COI_CertificateType_Additional_Detail
	/// </summary>
	public sealed class COI_CertificateType_Additional_Detail
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Certificate_Additional_ID;
		private decimal? _FK_Additional_ID;
		private decimal? _FK_COI_Certificate_Detail_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Certificate_Additional_ID value.
		/// </summary>
		public decimal? PK_Certificate_Additional_ID
		{
			get { return _PK_Certificate_Additional_ID; }
			set { _PK_Certificate_Additional_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Additional_ID value.
		/// </summary>
		public decimal? FK_Additional_ID
		{
			get { return _FK_Additional_ID; }
			set { _FK_Additional_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_COI_Certificate_Detail_ID value.
		/// </summary>
		public decimal? FK_COI_Certificate_Detail_ID
		{
			get { return _FK_COI_Certificate_Detail_ID; }
			set { _FK_COI_Certificate_Detail_ID = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the COI_CertificateType_Additional_Detail class with default value.
		/// </summary>
		public COI_CertificateType_Additional_Detail() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the COI_CertificateType_Additional_Detail class based on Primary Key.
		/// </summary>
		public COI_CertificateType_Additional_Detail(decimal pK_Certificate_Additional_ID) 
		{
			DataTable dtCOI_CertificateType_Additional_Detail = Select(pK_Certificate_Additional_ID).Tables[0];

			if (dtCOI_CertificateType_Additional_Detail.Rows.Count == 1)
			{
				 SetValue(dtCOI_CertificateType_Additional_Detail.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the COI_CertificateType_Additional_Detail class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drCOI_CertificateType_Additional_Detail) 
		{
				if (drCOI_CertificateType_Additional_Detail["PK_Certificate_Additional_ID"] == DBNull.Value)
					this._PK_Certificate_Additional_ID = null;
				else
					this._PK_Certificate_Additional_ID = (decimal?)drCOI_CertificateType_Additional_Detail["PK_Certificate_Additional_ID"];

				if (drCOI_CertificateType_Additional_Detail["FK_Additional_ID"] == DBNull.Value)
					this._FK_Additional_ID = null;
				else
					this._FK_Additional_ID = (decimal?)drCOI_CertificateType_Additional_Detail["FK_Additional_ID"];

				if (drCOI_CertificateType_Additional_Detail["FK_COI_Certificate_Detail_ID"] == DBNull.Value)
					this._FK_COI_Certificate_Detail_ID = null;
				else
					this._FK_COI_Certificate_Detail_ID = (decimal?)drCOI_CertificateType_Additional_Detail["FK_COI_Certificate_Detail_ID"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the COI_CertificateType_Additional_Detail table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_Additional_DetailInsert");

			
			db.AddInParameter(dbCommand, "FK_Additional_ID", DbType.Decimal, this._FK_Additional_ID);
			
			db.AddInParameter(dbCommand, "FK_COI_Certificate_Detail_ID", DbType.Decimal, this._FK_COI_Certificate_Detail_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_CertificateType_Additional_Detail table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Certificate_Additional_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_Additional_DetailSelect");

			db.AddInParameter(dbCommand, "PK_Certificate_Additional_ID", DbType.Decimal, pK_Certificate_Additional_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_CertificateType_Additional_Detail table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_Additional_DetailSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the COI_CertificateType_Additional_Detail table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_Additional_DetailUpdate");

			
			db.AddInParameter(dbCommand, "PK_Certificate_Additional_ID", DbType.Decimal, this._PK_Certificate_Additional_ID);
			
			db.AddInParameter(dbCommand, "FK_Additional_ID", DbType.Decimal, this._FK_Additional_ID);
			
			db.AddInParameter(dbCommand, "FK_COI_Certificate_Detail_ID", DbType.Decimal, this._FK_COI_Certificate_Detail_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_CertificateType_Additional_Detail table by a composite primary key.
		/// </summary>
        public static void Delete(decimal FK_COI_Certificate_Detail_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_CertificateType_Additional_DetailDelete");

            db.AddInParameter(dbCommand, "FK_COI_Certificate_Detail_ID", DbType.Decimal, FK_COI_Certificate_Detail_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
