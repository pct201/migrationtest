using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_BT_Security_Walk_Attachments table.
	/// </summary>
	public sealed class clsSLT_BT_Security_Walk_Attachments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_BT_Security_Walk_Attachments;
		private decimal? _FK_SLT_BT_Security_Walk_Responses;
		private string _Attachment_Description;
		private string _Attachment_Filename;
		private string _Updated_By;
		private DateTime? _Updated_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_BT_Security_Walk_Attachments value.
		/// </summary>
		public decimal? PK_SLT_BT_Security_Walk_Attachments
		{
			get { return _PK_SLT_BT_Security_Walk_Attachments; }
			set { _PK_SLT_BT_Security_Walk_Attachments = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_BT_Security_Walk_Responses value.
		/// </summary>
		public decimal? FK_SLT_BT_Security_Walk_Responses
		{
			get { return _FK_SLT_BT_Security_Walk_Responses; }
			set { _FK_SLT_BT_Security_Walk_Responses = value; }
		}

		/// <summary>
		/// Gets or sets the Attachment_Description value.
		/// </summary>
		public string Attachment_Description
		{
			get { return _Attachment_Description; }
			set { _Attachment_Description = value; }
		}

		/// <summary>
		/// Gets or sets the Attachment_Filename value.
		/// </summary>
		public string Attachment_Filename
		{
			get { return _Attachment_Filename; }
			set { _Attachment_Filename = value; }
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
		/// Gets or sets the Updated_Date value.
		/// </summary>
		public DateTime? Updated_Date
		{
			get { return _Updated_Date; }
			set { _Updated_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Attachments class with default value.
		/// </summary>
		public clsSLT_BT_Security_Walk_Attachments() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Attachments class based on Primary Key.
		/// </summary>
		public clsSLT_BT_Security_Walk_Attachments(decimal pK_SLT_BT_Security_Walk_Attachments) 
		{
			DataTable dtSLT_BT_Security_Walk_Attachments = SelectByPK(pK_SLT_BT_Security_Walk_Attachments).Tables[0];

			if (dtSLT_BT_Security_Walk_Attachments.Rows.Count == 1)
			{
				 SetValue(dtSLT_BT_Security_Walk_Attachments.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Attachments class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_BT_Security_Walk_Attachments) 
		{
				if (drSLT_BT_Security_Walk_Attachments["PK_SLT_BT_Security_Walk_Attachments"] == DBNull.Value)
					this._PK_SLT_BT_Security_Walk_Attachments = null;
				else
					this._PK_SLT_BT_Security_Walk_Attachments = (decimal?)drSLT_BT_Security_Walk_Attachments["PK_SLT_BT_Security_Walk_Attachments"];

				if (drSLT_BT_Security_Walk_Attachments["FK_SLT_BT_Security_Walk_Responses"] == DBNull.Value)
					this._FK_SLT_BT_Security_Walk_Responses = null;
				else
					this._FK_SLT_BT_Security_Walk_Responses = (decimal?)drSLT_BT_Security_Walk_Attachments["FK_SLT_BT_Security_Walk_Responses"];

				if (drSLT_BT_Security_Walk_Attachments["Attachment_Description"] == DBNull.Value)
					this._Attachment_Description = null;
				else
					this._Attachment_Description = (string)drSLT_BT_Security_Walk_Attachments["Attachment_Description"];

				if (drSLT_BT_Security_Walk_Attachments["Attachment_Filename"] == DBNull.Value)
					this._Attachment_Filename = null;
				else
					this._Attachment_Filename = (string)drSLT_BT_Security_Walk_Attachments["Attachment_Filename"];

				if (drSLT_BT_Security_Walk_Attachments["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSLT_BT_Security_Walk_Attachments["Updated_By"];

				if (drSLT_BT_Security_Walk_Attachments["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drSLT_BT_Security_Walk_Attachments["Updated_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_BT_Security_Walk_Attachments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_AttachmentsInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk_Responses", DbType.Decimal, this._FK_SLT_BT_Security_Walk_Responses);
			
			if (string.IsNullOrEmpty(this._Attachment_Description))
				db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, this._Attachment_Description);
			
			if (string.IsNullOrEmpty(this._Attachment_Filename))
				db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, this._Attachment_Filename);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_BT_Security_Walk_Attachments table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_BT_Security_Walk_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_AttachmentsSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Attachments", DbType.Decimal, pK_SLT_BT_Security_Walk_Attachments);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_BT_Security_Walk_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_AttachmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_BT_Security_Walk_Attachments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_AttachmentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Attachments", DbType.Decimal, this._PK_SLT_BT_Security_Walk_Attachments);
			
			db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk_Responses", DbType.Decimal, this._FK_SLT_BT_Security_Walk_Responses);
			
			if (string.IsNullOrEmpty(this._Attachment_Description))
				db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, this._Attachment_Description);
			
			if (string.IsNullOrEmpty(this._Attachment_Filename))
				db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, this._Attachment_Filename);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_BT_Security_Walk_Attachments table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_BT_Security_Walk_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_AttachmentsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Attachments", DbType.Decimal, pK_SLT_BT_Security_Walk_Attachments);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK(decimal FK_SLT_BT_Security_Walk_Responses)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_Attachments_SelectByFK");

            db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk_Responses", DbType.Decimal, FK_SLT_BT_Security_Walk_Responses);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
