using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_FirstRepose_AEDEquipment_Attachments table.
	/// </summary>
	public sealed class clsPM_FirstRepose_AEDEquipment_Attachments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_FirstRepose_AEDEquipment_Attachments;
		private decimal? _FK_PM_FirstRepose_AEDEquipment;
		private string _Attachment_Name;
		private string _File_Name;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_FirstRepose_AEDEquipment_Attachments value.
		/// </summary>
		public decimal? PK_PM_FirstRepose_AEDEquipment_Attachments
		{
			get { return _PK_PM_FirstRepose_AEDEquipment_Attachments; }
			set { _PK_PM_FirstRepose_AEDEquipment_Attachments = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_FirstRepose_AEDEquipment value.
		/// </summary>
		public decimal? FK_PM_FirstRepose_AEDEquipment
		{
			get { return _FK_PM_FirstRepose_AEDEquipment; }
			set { _FK_PM_FirstRepose_AEDEquipment = value; }
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
		/// Initializes a new instance of the clsPM_FirstRepose_AEDEquipment_Attachments class with default value.
		/// </summary>
		public clsPM_FirstRepose_AEDEquipment_Attachments() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_FirstRepose_AEDEquipment_Attachments class based on Primary Key.
		/// </summary>
		public clsPM_FirstRepose_AEDEquipment_Attachments(decimal pK_PM_FirstRepose_AEDEquipment_Attachments) 
		{
			DataTable dtPM_FirstRepose_AEDEquipment_Attachments = SelectByPK(pK_PM_FirstRepose_AEDEquipment_Attachments).Tables[0];

			if (dtPM_FirstRepose_AEDEquipment_Attachments.Rows.Count == 1)
			{
				 SetValue(dtPM_FirstRepose_AEDEquipment_Attachments.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_FirstRepose_AEDEquipment_Attachments class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_FirstRepose_AEDEquipment_Attachments) 
		{
				if (drPM_FirstRepose_AEDEquipment_Attachments["PK_PM_FirstRepose_AEDEquipment_Attachments"] == DBNull.Value)
					this._PK_PM_FirstRepose_AEDEquipment_Attachments = null;
				else
					this._PK_PM_FirstRepose_AEDEquipment_Attachments = (decimal?)drPM_FirstRepose_AEDEquipment_Attachments["PK_PM_FirstRepose_AEDEquipment_Attachments"];

				if (drPM_FirstRepose_AEDEquipment_Attachments["FK_PM_FirstRepose_AEDEquipment"] == DBNull.Value)
					this._FK_PM_FirstRepose_AEDEquipment = null;
				else
					this._FK_PM_FirstRepose_AEDEquipment = (decimal?)drPM_FirstRepose_AEDEquipment_Attachments["FK_PM_FirstRepose_AEDEquipment"];

				if (drPM_FirstRepose_AEDEquipment_Attachments["Attachment_Name"] == DBNull.Value)
					this._Attachment_Name = null;
				else
					this._Attachment_Name = (string)drPM_FirstRepose_AEDEquipment_Attachments["Attachment_Name"];

				if (drPM_FirstRepose_AEDEquipment_Attachments["File_Name"] == DBNull.Value)
					this._File_Name = null;
				else
					this._File_Name = (string)drPM_FirstRepose_AEDEquipment_Attachments["File_Name"];

				if (drPM_FirstRepose_AEDEquipment_Attachments["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_FirstRepose_AEDEquipment_Attachments["Update_Date"];

				if (drPM_FirstRepose_AEDEquipment_Attachments["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_FirstRepose_AEDEquipment_Attachments["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_FirstRepose_AEDEquipment_Attachments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipment_AttachmentsInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_FirstRepose_AEDEquipment", DbType.Decimal, this._FK_PM_FirstRepose_AEDEquipment);
			
			if (string.IsNullOrEmpty(this._Attachment_Name))
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Attachment_Name);
			
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
		/// Selects a single record from the PM_FirstRepose_AEDEquipment_Attachments table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet SelectByPK(decimal pK_PM_FirstRepose_AEDEquipment_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipment_AttachmentsSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_FirstRepose_AEDEquipment_Attachments", DbType.Decimal, pK_PM_FirstRepose_AEDEquipment_Attachments);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_FirstRepose_AEDEquipment_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipment_AttachmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_FirstRepose_AEDEquipment_Attachments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipment_AttachmentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_FirstRepose_AEDEquipment_Attachments", DbType.Decimal, this._PK_PM_FirstRepose_AEDEquipment_Attachments);
			
			db.AddInParameter(dbCommand, "FK_PM_FirstRepose_AEDEquipment", DbType.Decimal, this._FK_PM_FirstRepose_AEDEquipment);
			
			if (string.IsNullOrEmpty(this._Attachment_Name))
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Attachment_Name);
			
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
		/// Deletes a record from the PM_FirstRepose_AEDEquipment_Attachments table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_FirstRepose_AEDEquipment_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipment_AttachmentsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_FirstRepose_AEDEquipment_Attachments", DbType.Decimal, pK_PM_FirstRepose_AEDEquipment_Attachments);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK(decimal FK_PM_FirstRepose_AEDEquipment)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipment_AttachmentsSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_FirstRepose_AEDEquipment", DbType.Decimal, FK_PM_FirstRepose_AEDEquipment);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
