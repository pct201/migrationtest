using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table Property_Claims_Attachments
	/// </summary>
	public sealed class Property_Claims_Attachments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Property_Claims_Attacments_ID;
		private decimal? _FK_Property_Claims_ID;
		private string _Attachment_Type;
		private string _Description;
		private string _Attachment_Path;
        private decimal? _FK_Virtual_Folder;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Property_Claims_Attacments_ID value.
		/// </summary>
		public decimal? PK_Property_Claims_Attacments_ID
		{
			get { return _PK_Property_Claims_Attacments_ID; }
			set { _PK_Property_Claims_Attacments_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Property_Claims_ID value.
		/// </summary>
		public decimal? FK_Property_Claims_ID
		{
			get { return _FK_Property_Claims_ID; }
			set { _FK_Property_Claims_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Attachment_Type value.
		/// </summary>
		public string Attachment_Type
		{
			get { return _Attachment_Type; }
			set { _Attachment_Type = value; }
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
		/// Gets or sets the Attachment_Path value.
		/// </summary>
		public string Attachment_Path
		{
			get { return _Attachment_Path; }
			set { _Attachment_Path = value; }
		}

        public decimal? FK_Virtual_Folder
        {
            get { return _FK_Virtual_Folder; }
            set { _FK_Virtual_Folder = value; }
        }


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims_Attachments class with default value.
		/// </summary>
		public Property_Claims_Attachments() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims_Attachments class based on Primary Key.
		/// </summary>
		public Property_Claims_Attachments(decimal pK_Property_Claims_Attacments_ID) 
		{
			DataTable dtProperty_Claims_Attachments = Select(pK_Property_Claims_Attacments_ID).Tables[0];

			if (dtProperty_Claims_Attachments.Rows.Count == 1)
			{
				 SetValue(dtProperty_Claims_Attachments.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Property_Claims_Attachments class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drProperty_Claims_Attachments) 
		{
				if (drProperty_Claims_Attachments["PK_Property_Claims_Attacments_ID"] == DBNull.Value)
					this._PK_Property_Claims_Attacments_ID = null;
				else
					this._PK_Property_Claims_Attacments_ID = (decimal?)drProperty_Claims_Attachments["PK_Property_Claims_Attacments_ID"];

				if (drProperty_Claims_Attachments["FK_Property_Claims_ID"] == DBNull.Value)
					this._FK_Property_Claims_ID = null;
				else
					this._FK_Property_Claims_ID = (decimal?)drProperty_Claims_Attachments["FK_Property_Claims_ID"];

				if (drProperty_Claims_Attachments["Attachment_Type"] == DBNull.Value)
					this._Attachment_Type = null;
				else
					this._Attachment_Type = (string)drProperty_Claims_Attachments["Attachment_Type"];

				if (drProperty_Claims_Attachments["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drProperty_Claims_Attachments["Description"];

				if (drProperty_Claims_Attachments["Attachment_Path"] == DBNull.Value)
					this._Attachment_Path = null;
				else
					this._Attachment_Path = (string)drProperty_Claims_Attachments["Attachment_Path"];

                if (drProperty_Claims_Attachments["FK_Virtual_Folder"] == DBNull.Value)
                    this._FK_Virtual_Folder = null;
                else
                    this._FK_Virtual_Folder = (decimal?)drProperty_Claims_Attachments["FK_Virtual_Folder"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Property_Claims_Attachments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AttachmentsInsert");

			
			db.AddInParameter(dbCommand, "FK_Property_Claims_ID", DbType.Decimal, this._FK_Property_Claims_ID);
			
			if (string.IsNullOrEmpty(this._Attachment_Type))
				db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Attachment_Path))
				db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, this._Attachment_Path);

            db.AddInParameter(dbCommand, "FK_Virtual_Folder", DbType.Decimal, this._FK_Virtual_Folder);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Property_Claims_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Property_Claims_Attacments_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AttachmentsSelect");

			db.AddInParameter(dbCommand, "PK_Property_Claims_Attacments_ID", DbType.Decimal, pK_Property_Claims_Attacments_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Property_Claims_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AttachmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Property_Claims_Attachments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AttachmentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Property_Claims_Attacments_ID", DbType.Decimal, this._PK_Property_Claims_Attacments_ID);
			
			db.AddInParameter(dbCommand, "FK_Property_Claims_ID", DbType.Decimal, this._FK_Property_Claims_ID);
			
			if (string.IsNullOrEmpty(this._Attachment_Type))
				db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Attachment_Path))
				db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, this._Attachment_Path);

            db.AddInParameter(dbCommand, "FK_Virtual_Folder", DbType.Decimal, this._FK_Virtual_Folder);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Property_Claims_Attachments table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Property_Claims_Attacments_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AttachmentsDelete");

			db.AddInParameter(dbCommand, "PK_Property_Claims_Attacments_ID", DbType.Decimal, pK_Property_Claims_Attacments_ID);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Property_Claims_Attacments table by a Claim ID
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByClaim_ID(decimal fK_Property_Claim_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AttacmentsSelectByCLaim_ID");

            db.AddInParameter(dbCommand, "FK_Property_Claim_ID", DbType.Decimal, fK_Property_Claim_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a Multiple record from the Property_Claims_Attacments table by a composite primary key.
        /// </summary>
        public static void DeleteByMultiIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AttachmentDeleteByIDs");

            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Select data of files for virtual folders
        /// </summary>
        /// <param name="fK_Table"></param>
        /// <param name="FK_Virtual_Folders"></param>
        /// <param name="PK_Security_ID"></param>
        /// <returns></returns>
        public static DataSet SelectForClaim(decimal fK_Table, string FK_Virtual_Folders, decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AttachmentsSelectForClaim");

            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, fK_Table);
            db.AddInParameter(dbCommand, "FK_Virtual_Folders", DbType.String, FK_Virtual_Folders);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAttachmentBy_ID(string pK_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AttachmentsSelectBy_Attachement_ID");

            db.AddInParameter(dbCommand, "Attachment_IDs", DbType.String, pK_Attachments);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
