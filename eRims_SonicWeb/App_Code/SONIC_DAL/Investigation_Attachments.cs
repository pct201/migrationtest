using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Investigation_Attachments table.
	/// </summary>
	public sealed class Investigation_Attachments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Investigation_Attachments;
		private decimal? _FK_Investigation;
		private string _Attachment_Type;
		private string _Description;
		private string _Attachment_Path;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Investigation_Attachments value.
		/// </summary>
		public decimal? PK_Investigation_Attachments
		{
			get { return _PK_Investigation_Attachments; }
			set { _PK_Investigation_Attachments = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Investigation value.
		/// </summary>
		public decimal? FK_Investigation
		{
			get { return _FK_Investigation; }
			set { _FK_Investigation = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsInvestigation_Attachments class with default value.
		/// </summary>
		public Investigation_Attachments() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsInvestigation_Attachments class based on Primary Key.
		/// </summary>
		public Investigation_Attachments(decimal pK_Investigation_Attachments) 
		{
			DataTable dtInvestigation_Attachments = SelectByPK(pK_Investigation_Attachments).Tables[0];

			if (dtInvestigation_Attachments.Rows.Count == 1)
			{
				 SetValue(dtInvestigation_Attachments.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsInvestigation_Attachments class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drInvestigation_Attachments) 
		{
				if (drInvestigation_Attachments["PK_Investigation_Attachments"] == DBNull.Value)
					this._PK_Investigation_Attachments = null;
				else
					this._PK_Investigation_Attachments = (decimal?)drInvestigation_Attachments["PK_Investigation_Attachments"];

				if (drInvestigation_Attachments["FK_Investigation"] == DBNull.Value)
					this._FK_Investigation = null;
				else
					this._FK_Investigation = (decimal?)drInvestigation_Attachments["FK_Investigation"];

				if (drInvestigation_Attachments["Attachment_Type"] == DBNull.Value)
					this._Attachment_Type = null;
				else
					this._Attachment_Type = (string)drInvestigation_Attachments["Attachment_Type"];

				if (drInvestigation_Attachments["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drInvestigation_Attachments["Description"];

				if (drInvestigation_Attachments["Attachment_Path"] == DBNull.Value)
					this._Attachment_Path = null;
				else
					this._Attachment_Path = (string)drInvestigation_Attachments["Attachment_Path"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Investigation_Attachments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_AttachmentsInsert");

			
			db.AddInParameter(dbCommand, "FK_Investigation", DbType.Decimal, this._FK_Investigation);
			
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

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Investigation_Attachments table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Investigation_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_AttachmentsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Investigation_Attachments", DbType.Decimal, pK_Investigation_Attachments);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Investigation_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_AttachmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Investigation_Attachments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_AttachmentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Investigation_Attachments", DbType.Decimal, this._PK_Investigation_Attachments);
			
			db.AddInParameter(dbCommand, "FK_Investigation", DbType.Decimal, this._FK_Investigation);
			
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

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByInvestigation_ID(decimal FK_Investigation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Investigation_AttacmentsSelectByID");

            db.AddInParameter(dbCommand, "FK_Investigation", DbType.Decimal, FK_Investigation);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Deletes a record from the Investigation_Attachments table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Investigation_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_AttachmentsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Investigation_Attachments", DbType.Decimal, pK_Investigation_Attachments);

			db.ExecuteNonQuery(dbCommand);
		}


        /// <summary>
        /// Deletes multiple record from the Investigation_Attachments table by multiple ids.
        /// </summary>
        public static void DeleteByMultiIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Investigation_AttachmentDeleteByIDs");

            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
