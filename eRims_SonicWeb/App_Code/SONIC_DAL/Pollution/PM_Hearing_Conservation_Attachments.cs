using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table PM_Hearing_Conservation_Attachments
	/// </summary>
	public sealed class PM_Hearing_Conservation_Attachments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Hearing_Conservation_Attachments;
		private decimal? _FK_PM_Hearing_Conservation;
		private string _Document_Name;
		private string _File_Name;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Hearing_Conservation_Attachments value.
		/// </summary>
		public decimal? PK_PM_Hearing_Conservation_Attachments
		{
			get { return _PK_PM_Hearing_Conservation_Attachments; }
			set { _PK_PM_Hearing_Conservation_Attachments = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Hearing_Conservation value.
		/// </summary>
		public decimal? FK_PM_Hearing_Conservation
		{
			get { return _FK_PM_Hearing_Conservation; }
			set { _FK_PM_Hearing_Conservation = value; }
		}

		/// <summary>
		/// Gets or sets the Document_Name value.
		/// </summary>
		public string Document_Name
		{
			get { return _Document_Name; }
			set { _Document_Name = value; }
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
		/// Initializes a new instance of the PM_Hearing_Conservation_Attachments class with default value.
		/// </summary>
		public PM_Hearing_Conservation_Attachments() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the PM_Hearing_Conservation_Attachments class based on Primary Key.
		/// </summary>
		public PM_Hearing_Conservation_Attachments(decimal pK_PM_Hearing_Conservation_Attachments) 
		{
			DataTable dtPM_Hearing_Conservation_Attachments = Select(pK_PM_Hearing_Conservation_Attachments).Tables[0];

			if (dtPM_Hearing_Conservation_Attachments.Rows.Count == 1)
			{
				 SetValue(dtPM_Hearing_Conservation_Attachments.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the PM_Hearing_Conservation_Attachments class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Hearing_Conservation_Attachments) 
		{
				if (drPM_Hearing_Conservation_Attachments["PK_PM_Hearing_Conservation_Attachments"] == DBNull.Value)
					this._PK_PM_Hearing_Conservation_Attachments = null;
				else
					this._PK_PM_Hearing_Conservation_Attachments = (decimal?)drPM_Hearing_Conservation_Attachments["PK_PM_Hearing_Conservation_Attachments"];

				if (drPM_Hearing_Conservation_Attachments["FK_PM_Hearing_Conservation"] == DBNull.Value)
					this._FK_PM_Hearing_Conservation = null;
				else
					this._FK_PM_Hearing_Conservation = (decimal?)drPM_Hearing_Conservation_Attachments["FK_PM_Hearing_Conservation"];

				if (drPM_Hearing_Conservation_Attachments["Document_Name"] == DBNull.Value)
					this._Document_Name = null;
				else
					this._Document_Name = (string)drPM_Hearing_Conservation_Attachments["Document_Name"];

				if (drPM_Hearing_Conservation_Attachments["File_Name"] == DBNull.Value)
					this._File_Name = null;
				else
					this._File_Name = (string)drPM_Hearing_Conservation_Attachments["File_Name"];

				if (drPM_Hearing_Conservation_Attachments["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Hearing_Conservation_Attachments["Update_Date"];

				if (drPM_Hearing_Conservation_Attachments["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Hearing_Conservation_Attachments["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Hearing_Conservation_Attachments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_Conservation_AttachmentsInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Hearing_Conservation", DbType.Decimal, this._FK_PM_Hearing_Conservation);
			
			if (string.IsNullOrEmpty(this._Document_Name))
                db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, DBNull.Value);
			else
                db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Document_Name);
			
			if (string.IsNullOrEmpty(this._File_Name))
				db.AddInParameter(dbCommand, "File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "File_Name", DbType.String, this._File_Name);
			
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
		/// Selects a single record from the PM_Hearing_Conservation_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_PM_Hearing_Conservation_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_Conservation_AttachmentsSelect");

			db.AddInParameter(dbCommand, "PK_PM_Hearing_Conservation_Attachments", DbType.Decimal, pK_PM_Hearing_Conservation_Attachments);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Hearing_Conservation_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_Conservation_AttachmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Hearing_Conservation_Attachments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_Conservation_AttachmentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Hearing_Conservation_Attachments", DbType.Decimal, this._PK_PM_Hearing_Conservation_Attachments);
			
			db.AddInParameter(dbCommand, "FK_PM_Hearing_Conservation", DbType.Decimal, this._FK_PM_Hearing_Conservation);
			
			if (string.IsNullOrEmpty(this._Document_Name))
                db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, DBNull.Value);
			else
                db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Document_Name);
			
			if (string.IsNullOrEmpty(this._File_Name))
				db.AddInParameter(dbCommand, "File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "File_Name", DbType.String, this._File_Name);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Hearing_Conservation_Attachments table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_PM_Hearing_Conservation_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_Conservation_AttachmentsDelete");

			db.AddInParameter(dbCommand, "PK_PM_Hearing_Conservation_Attachments", DbType.Decimal, pK_PM_Hearing_Conservation_Attachments);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the PM_Respiratory_Protection_Attachments by FK_PM_Respiratory_Protection.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_PM_Respiratory_Protection)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_Conservation_AttachmentsSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Hearing_Conservation", DbType.Decimal, FK_PM_Respiratory_Protection);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
