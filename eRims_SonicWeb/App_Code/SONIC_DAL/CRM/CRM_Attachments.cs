using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for CRM_Attachments table.
	/// </summary>
	public sealed class CRM_Attachments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_CRM_Attachments;
		private string _Table_Name;
		private decimal? _FK_Table_Name;
		private string _Description;
		private string _FileName;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_CRM_Attachments value.
		/// </summary>
		public decimal? PK_CRM_Attachments
		{
			get { return _PK_CRM_Attachments; }
			set { _PK_CRM_Attachments = value; }
		}

		/// <summary>
		/// Gets or sets the Table_Name value.
		/// </summary>
		public string Table_Name
		{
			get { return _Table_Name; }
			set { _Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Table_Name value.
		/// </summary>
		public decimal? FK_Table_Name
		{
			get { return _FK_Table_Name; }
			set { _FK_Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		/// <summary>
		/// Gets or sets the FileName value.
		/// </summary>
		public string FileName
		{
			get { return _FileName; }
			set { _FileName = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the CRM_Attachments class with default value.
		/// </summary>
		public CRM_Attachments() 
		{

			this._PK_CRM_Attachments = null;
			this._Table_Name = null;
			this._FK_Table_Name = null;
			this._Description = null;
			this._FileName = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the CRM_Attachments class based on Primary Key.
		/// </summary>
		public CRM_Attachments(decimal pK_CRM_Attachments) 
		{
			DataTable dtCRM_Attachments = SelectByPK(pK_CRM_Attachments).Tables[0];

			if (dtCRM_Attachments.Rows.Count == 1)
			{
				DataRow drCRM_Attachments = dtCRM_Attachments.Rows[0];
				if (drCRM_Attachments["PK_CRM_Attachments"] == DBNull.Value)
					this._PK_CRM_Attachments = null;
				else
					this._PK_CRM_Attachments = (decimal?)drCRM_Attachments["PK_CRM_Attachments"];

				if (drCRM_Attachments["Table_Name"] == DBNull.Value)
					this._Table_Name = null;
				else
					this._Table_Name = (string)drCRM_Attachments["Table_Name"];

				if (drCRM_Attachments["FK_Table_Name"] == DBNull.Value)
					this._FK_Table_Name = null;
				else
					this._FK_Table_Name = (decimal?)drCRM_Attachments["FK_Table_Name"];

				if (drCRM_Attachments["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drCRM_Attachments["Description"];

				if (drCRM_Attachments["FileName"] == DBNull.Value)
					this._FileName = null;
				else
					this._FileName = (string)drCRM_Attachments["FileName"];

			}
			else
			{
				this._PK_CRM_Attachments = null;
				this._Table_Name = null;
				this._FK_Table_Name = null;
				this._Description = null;
				this._FileName = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the CRM_Attachments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_AttachmentsInsert");

			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, this._FK_Table_Name);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._FileName))
				db.AddInParameter(dbCommand, "FileName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FileName", DbType.String, this._FileName);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the CRM_Attachments table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_CRM_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_AttachmentsSelectByPK");

			db.AddInParameter(dbCommand, "PK_CRM_Attachments", DbType.Decimal, pK_CRM_Attachments);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the CRM_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_AttachmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the CRM_Attachments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_AttachmentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_CRM_Attachments", DbType.Decimal, this._PK_CRM_Attachments);
			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, this._FK_Table_Name);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._FileName))
				db.AddInParameter(dbCommand, "FileName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FileName", DbType.String, this._FileName);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the CRM_Attachments table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_CRM_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_AttachmentsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_CRM_Attachments", DbType.Decimal, pK_CRM_Attachments);

			db.ExecuteNonQuery(dbCommand);
		}
        /// <summary>
        /// Deletes a record from the Attachment table by a composite primary key.
        /// </summary>
        public static void DeleteByID(String strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_AttachmentsDeleteByIDs");

            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Selects a record depending on table name and related foreign key for the table
        /// </summary>
        /// <param name="Attachment_Table">Table name for which to store the record</param>
        /// <param name="FK_Table">Primary key value of the table</param>
        /// <returns></returns>
        public static DataSet SelectByTableName(string Attachment_Table, int FK_Table)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_AttachmentsSelectByTableName");

            db.AddInParameter(dbCommand, "Table_Name", DbType.String, Attachment_Table);
            db.AddInParameter(dbCommand, "FK_Table_Name ", DbType.Int32, FK_Table);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByIDs(string IDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_AttachmentsSelectByIDs");

            db.AddInParameter(dbCommand, "AttIds", DbType.String, IDs);
            
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
