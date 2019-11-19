using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Find_it_Fix_it_Attachments table.
	/// </summary>
	public sealed class clsFind_it_Fix_it_Attachments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Find_it_Fix_it_Attachments;
		private decimal? _FK_Find_it_Fix_it;
		private string _Attachment_Name;
		private string _File_Name;
		private string _Attachment_Type;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Find_it_Fix_it_Attachments value.
		/// </summary>
		public decimal? PK_Find_it_Fix_it_Attachments
		{
			get { return _PK_Find_it_Fix_it_Attachments; }
			set { _PK_Find_it_Fix_it_Attachments = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Find_it_Fix_it value.
		/// </summary>
		public decimal? FK_Find_it_Fix_it
		{
			get { return _FK_Find_it_Fix_it; }
			set { _FK_Find_it_Fix_it = value; }
		}

		/// <summary>
		/// Gets or sets the Attachment_Name value.
		/// </summary>
		public string Attachment_Name
		{
			get { return _Attachment_Name; }
			set { _Attachment_Name = value; }
		}

		/// <summary>
		/// Gets or sets the File_Name value.
		/// </summary>
		public string File_Name
		{
			get { return _File_Name; }
			set { _File_Name = value; }
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
		/// Initializes a new instance of the clsFind_it_Fix_it_Attachments class with default value.
		/// </summary>
		public clsFind_it_Fix_it_Attachments() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsFind_it_Fix_it_Attachments class based on Primary Key.
		/// </summary>
		public clsFind_it_Fix_it_Attachments(decimal pK_Find_it_Fix_it_Attachments) 
		{
			DataTable dtFind_it_Fix_it_Attachments = SelectByPK(pK_Find_it_Fix_it_Attachments).Tables[0];

			if (dtFind_it_Fix_it_Attachments.Rows.Count == 1)
			{
				 SetValue(dtFind_it_Fix_it_Attachments.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsFind_it_Fix_it_Attachments class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drFind_it_Fix_it_Attachments) 
		{
				if (drFind_it_Fix_it_Attachments["PK_Find_it_Fix_it_Attachments"] == DBNull.Value)
					this._PK_Find_it_Fix_it_Attachments = null;
				else
					this._PK_Find_it_Fix_it_Attachments = (decimal?)drFind_it_Fix_it_Attachments["PK_Find_it_Fix_it_Attachments"];

				if (drFind_it_Fix_it_Attachments["FK_Find_it_Fix_it"] == DBNull.Value)
					this._FK_Find_it_Fix_it = null;
				else
					this._FK_Find_it_Fix_it = (decimal?)drFind_it_Fix_it_Attachments["FK_Find_it_Fix_it"];

				if (drFind_it_Fix_it_Attachments["Attachment_Name"] == DBNull.Value)
					this._Attachment_Name = null;
				else
					this._Attachment_Name = (string)drFind_it_Fix_it_Attachments["Attachment_Name"];

				if (drFind_it_Fix_it_Attachments["File_Name"] == DBNull.Value)
					this._File_Name = null;
				else
					this._File_Name = (string)drFind_it_Fix_it_Attachments["File_Name"];

				if (drFind_it_Fix_it_Attachments["Attachment_Type"] == DBNull.Value)
					this._Attachment_Type = null;
				else
					this._Attachment_Type = (string)drFind_it_Fix_it_Attachments["Attachment_Type"];

				if (drFind_it_Fix_it_Attachments["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drFind_it_Fix_it_Attachments["Update_Date"];

				if (drFind_it_Fix_it_Attachments["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drFind_it_Fix_it_Attachments["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Find_it_Fix_it_Attachments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_it_AttachmentsInsert");

			
			db.AddInParameter(dbCommand, "FK_Find_it_Fix_it", DbType.Decimal, this._FK_Find_it_Fix_it);
			
			if (string.IsNullOrEmpty(this._Attachment_Name))
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Attachment_Name);
			
			if (string.IsNullOrEmpty(this._File_Name))
				db.AddInParameter(dbCommand, "File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "File_Name", DbType.String, this._File_Name);
			
			if (string.IsNullOrEmpty(this._Attachment_Type))
				db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
			
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
		/// Selects a single record from the Find_it_Fix_it_Attachments table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Find_it_Fix_it_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_it_AttachmentsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Find_it_Fix_it_Attachments", DbType.Decimal, pK_Find_it_Fix_it_Attachments);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Find_it_Fix_it_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_it_AttachmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Find_it_Fix_it_Attachments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_it_AttachmentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Find_it_Fix_it_Attachments", DbType.Decimal, this._PK_Find_it_Fix_it_Attachments);
			
			db.AddInParameter(dbCommand, "FK_Find_it_Fix_it", DbType.Decimal, this._FK_Find_it_Fix_it);
			
			if (string.IsNullOrEmpty(this._Attachment_Name))
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Attachment_Name);
			
			if (string.IsNullOrEmpty(this._File_Name))
				db.AddInParameter(dbCommand, "File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "File_Name", DbType.String, this._File_Name);
			
			if (string.IsNullOrEmpty(this._Attachment_Type))
				db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Find_it_Fix_it_Attachments table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Find_it_Fix_it_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_it_AttachmentsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Find_it_Fix_it_Attachments", DbType.Decimal, pK_Find_it_Fix_it_Attachments);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK_Find_It_Fix_It(decimal FK_Find_it_Fix_it)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_SelectByFK_Find_It_Fix_It");

            db.AddInParameter(dbCommand, "FK_Find_it_Fix_it", DbType.Decimal, FK_Find_it_Fix_it);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
