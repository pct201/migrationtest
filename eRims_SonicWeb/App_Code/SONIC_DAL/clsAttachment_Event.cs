using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Attachment_Event table.
	/// </summary>
	public sealed class clsAttachment_Event
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Attachment_Event;
		private string _Attachment_Table;
		private decimal? _FK_Table;
		private decimal? _FK_Attachment_Type;
		private string _Attachment_Description;
		private string _Attachment_Name;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private DateTime? _Attach_Date;
		private string _Thumbnail_File_Name;
		private int? _Page_Count;
		private decimal? _FK_Virtual_Folder;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Attachment_Event value.
		/// </summary>
		public decimal? PK_Attachment_Event
		{
			get { return _PK_Attachment_Event; }
			set { _PK_Attachment_Event = value; }
		}

		/// <summary>
		/// Gets or sets the Attachment_Table value.
		/// </summary>
		public string Attachment_Table
		{
			get { return _Attachment_Table; }
			set { _Attachment_Table = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Table value.
		/// </summary>
		public decimal? FK_Table
		{
			get { return _FK_Table; }
			set { _FK_Table = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Attachment_Type value.
		/// </summary>
		public decimal? FK_Attachment_Type
		{
			get { return _FK_Attachment_Type; }
			set { _FK_Attachment_Type = value; }
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
		/// Gets or sets the Attachment_Name value.
		/// </summary>
		public string Attachment_Name
		{
			get { return _Attachment_Name; }
			set { _Attachment_Name = value; }
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
		/// Gets or sets the Attach_Date value.
		/// </summary>
		public DateTime? Attach_Date
		{
			get { return _Attach_Date; }
			set { _Attach_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Thumbnail_File_Name value.
		/// </summary>
		public string Thumbnail_File_Name
		{
			get { return _Thumbnail_File_Name; }
			set { _Thumbnail_File_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Page_Count value.
		/// </summary>
		public int? Page_Count
		{
			get { return _Page_Count; }
			set { _Page_Count = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Virtual_Folder value.
		/// </summary>
		public decimal? FK_Virtual_Folder
		{
			get { return _FK_Virtual_Folder; }
			set { _FK_Virtual_Folder = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsAttachment_Event class with default value.
		/// </summary>
		public clsAttachment_Event() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAttachment_Event class based on Primary Key.
		/// </summary>
		public clsAttachment_Event(decimal pK_Attachment_Event) 
		{
			DataTable dtAttachment_Event = SelectByPK(pK_Attachment_Event).Tables[0];

			if (dtAttachment_Event.Rows.Count == 1)
			{
				 SetValue(dtAttachment_Event.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAttachment_Event class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAttachment_Event) 
		{
				if (drAttachment_Event["PK_Attachment_Event"] == DBNull.Value)
					this._PK_Attachment_Event = null;
				else
					this._PK_Attachment_Event = (decimal?)drAttachment_Event["PK_Attachment_Event"];

				if (drAttachment_Event["Attachment_Table"] == DBNull.Value)
					this._Attachment_Table = null;
				else
					this._Attachment_Table = (string)drAttachment_Event["Attachment_Table"];

				if (drAttachment_Event["FK_Table"] == DBNull.Value)
					this._FK_Table = null;
				else
					this._FK_Table = (decimal?)drAttachment_Event["FK_Table"];

				if (drAttachment_Event["FK_Attachment_Type"] == DBNull.Value)
					this._FK_Attachment_Type = null;
				else
					this._FK_Attachment_Type = (decimal?)drAttachment_Event["FK_Attachment_Type"];

				if (drAttachment_Event["Attachment_Description"] == DBNull.Value)
					this._Attachment_Description = null;
				else
					this._Attachment_Description = (string)drAttachment_Event["Attachment_Description"];

				if (drAttachment_Event["Attachment_Name"] == DBNull.Value)
					this._Attachment_Name = null;
				else
					this._Attachment_Name = (string)drAttachment_Event["Attachment_Name"];

				if (drAttachment_Event["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drAttachment_Event["Updated_By"];

				if (drAttachment_Event["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drAttachment_Event["Update_Date"];

				if (drAttachment_Event["Attach_Date"] == DBNull.Value)
					this._Attach_Date = null;
				else
					this._Attach_Date = (DateTime?)drAttachment_Event["Attach_Date"];

				if (drAttachment_Event["Thumbnail_File_Name"] == DBNull.Value)
					this._Thumbnail_File_Name = null;
				else
					this._Thumbnail_File_Name = (string)drAttachment_Event["Thumbnail_File_Name"];

				if (drAttachment_Event["Page_Count"] == DBNull.Value)
					this._Page_Count = null;
				else
					this._Page_Count = (int?)drAttachment_Event["Page_Count"];

				if (drAttachment_Event["FK_Virtual_Folder"] == DBNull.Value)
					this._FK_Virtual_Folder = null;
				else
					this._FK_Virtual_Folder = (decimal?)drAttachment_Event["FK_Virtual_Folder"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Attachment_Event table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_EventInsert");

			
			if (string.IsNullOrEmpty(this._Attachment_Table))
				db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, this._Attachment_Table);
			
			db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, this._FK_Table);
			
			db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.Decimal, this._FK_Attachment_Type);
			
			if (string.IsNullOrEmpty(this._Attachment_Description))
				db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, this._Attachment_Description);
			
			if (string.IsNullOrEmpty(this._Attachment_Name))
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Attachment_Name);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "Attach_Date", DbType.DateTime, this._Attach_Date);
			
			if (string.IsNullOrEmpty(this._Thumbnail_File_Name))
				db.AddInParameter(dbCommand, "Thumbnail_File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Thumbnail_File_Name", DbType.String, this._Thumbnail_File_Name);
			
			db.AddInParameter(dbCommand, "Page_Count", DbType.Int32, this._Page_Count);
			
			db.AddInParameter(dbCommand, "FK_Virtual_Folder", DbType.Decimal, this._FK_Virtual_Folder);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Attachment_Event table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Attachment_Event)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_EventSelectByPK");

			db.AddInParameter(dbCommand, "PK_Attachment_Event", DbType.Decimal, pK_Attachment_Event);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Attachment_Event table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_EventSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Attachment_Event table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_EventUpdate");

			
			db.AddInParameter(dbCommand, "PK_Attachment_Event", DbType.Decimal, this._PK_Attachment_Event);
			
			if (string.IsNullOrEmpty(this._Attachment_Table))
				db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, this._Attachment_Table);
			
			db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, this._FK_Table);
			
			db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.Decimal, this._FK_Attachment_Type);
			
			if (string.IsNullOrEmpty(this._Attachment_Description))
				db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, this._Attachment_Description);
			
			if (string.IsNullOrEmpty(this._Attachment_Name))
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Attachment_Name);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "Attach_Date", DbType.DateTime, this._Attach_Date);
			
			if (string.IsNullOrEmpty(this._Thumbnail_File_Name))
				db.AddInParameter(dbCommand, "Thumbnail_File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Thumbnail_File_Name", DbType.String, this._Thumbnail_File_Name);
			
			db.AddInParameter(dbCommand, "Page_Count", DbType.Int32, this._Page_Count);
			
			db.AddInParameter(dbCommand, "FK_Virtual_Folder", DbType.Decimal, this._FK_Virtual_Folder);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Attachment_Event table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Attachment_Event)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_EventDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Attachment_Event", DbType.Decimal, pK_Attachment_Event);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectForClaim(decimal fK_Table, string FK_Virtual_Folders, string attachment_table, decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_EventSelectForClaim");

            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, fK_Table);
            db.AddInParameter(dbCommand, "FK_Virtual_Folders", DbType.String, FK_Virtual_Folders);
            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, attachment_table);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectPDFs(string pK_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_EventSelectPDFs");

            db.AddInParameter(dbCommand, "Attachment_IDs", DbType.String, pK_Attachments);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFK_Table(string Attachment_Table, string FK_Table)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_EventSelectByFK_Table");

            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, Attachment_Table);
            db.AddInParameter(dbCommand, "FK_Table", DbType.String, FK_Table);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectAttachmentBy_ID(string pK_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_EventSelectBy_Attachement_ID");

            db.AddInParameter(dbCommand, "Attachment_IDs", DbType.String, pK_Attachments);

            return db.ExecuteDataSet(dbCommand);
        }

        public static int GetVirtulFolderforCopyMove(decimal PK_Virtual_Folder, string MajorCoverage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetVirtulFolderforCopyMove");

            db.AddInParameter(dbCommand, "PK_Virtual_Folder", DbType.Decimal, PK_Virtual_Folder);
            db.AddInParameter(dbCommand, "MajorCoverage", DbType.String, MajorCoverage);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        public static int GetVirtulFolderforCopyMovePolicy(decimal PK_Virtual_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetVirtulFolderforCopyMovePolicy");

            db.AddInParameter(dbCommand, "PK_Virtual_Folder", DbType.Decimal, PK_Virtual_Folder);


            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Updates a record in the Attachment table.
        /// </summary>
        public void UpdateAttachmentdate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateAttachmentdate");


            db.AddInParameter(dbCommand, "PK_Attachment", DbType.Decimal, this._PK_Attachment_Event);

            db.AddInParameter(dbCommand, "Attach_Date", DbType.DateTime, this._Attach_Date);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
