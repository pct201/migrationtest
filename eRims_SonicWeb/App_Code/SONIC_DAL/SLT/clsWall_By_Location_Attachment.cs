using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Wall_By_Location_Attachment table.
	/// </summary>
	public sealed class clsWall_By_Location_Attachment
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Wall_By_Location_Attachment;
		private decimal? _FK_Wall_By_Location;
		private string _Input_File_Name;
		private string _Stored_File_Name;
        private decimal _PK_Wall_By_Location;
        private bool p;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Wall_By_Location_Attachment value.
		/// </summary>
		public decimal? PK_Wall_By_Location_Attachment
		{
			get { return _PK_Wall_By_Location_Attachment; }
			set { _PK_Wall_By_Location_Attachment = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Wall_By_Location value.
		/// </summary>
		public decimal? FK_Wall_By_Location
		{
			get { return _FK_Wall_By_Location; }
			set { _FK_Wall_By_Location = value; }
		}

		/// <summary>
		/// Gets or sets the Input_File_Name value.
		/// </summary>
		public string Input_File_Name
		{
			get { return _Input_File_Name; }
			set { _Input_File_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Stored_File_Name value.
		/// </summary>
		public string Stored_File_Name
		{
			get { return _Stored_File_Name; }
			set { _Stored_File_Name = value; }
		}

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsWall_By_Location_Attachment class with default value.
		/// </summary>
		public clsWall_By_Location_Attachment() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsWall_By_Location_Attachment class based on Primary Key.
		/// </summary>
		public clsWall_By_Location_Attachment(decimal pK_Wall_By_Location_Attachment) 
		{
			DataTable dtWall_By_Location_Attachment = SelectByPK(pK_Wall_By_Location_Attachment).Tables[0];

			if (dtWall_By_Location_Attachment.Rows.Count == 1)
			{
				 SetValue(dtWall_By_Location_Attachment.Rows[0]);

			}

		}

        /// <summary>
        /// Initializes a new instance of the Main_Wall_Attachment class based on Primary Key.
        /// </summary>
        public clsWall_By_Location_Attachment(decimal FK_Main_Wall, bool isFK)
        {
            DataTable dtWall_By_Location_Attachment = SelectByFK(FK_Main_Wall).Tables[0];

            if (dtWall_By_Location_Attachment.Rows.Count == 1)
            {
                DataRow drWall_By_Location_Attachment = dtWall_By_Location_Attachment.Rows[0];
                SetValue(drWall_By_Location_Attachment);
            }
            else
            {
                this._PK_Wall_By_Location_Attachment = null;
                this._FK_Wall_By_Location = null;
                this._Input_File_Name = null;
                this._Stored_File_Name = null;
            }

        }


		/// <summary>
		/// Initializes a new instance of the clsWall_By_Location_Attachment class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drWall_By_Location_Attachment) 
		{
				if (drWall_By_Location_Attachment["PK_Wall_By_Location_Attachment"] == DBNull.Value)
					this._PK_Wall_By_Location_Attachment = null;
				else
					this._PK_Wall_By_Location_Attachment = (decimal?)drWall_By_Location_Attachment["PK_Wall_By_Location_Attachment"];

				if (drWall_By_Location_Attachment["FK_Wall_By_Location"] == DBNull.Value)
					this._FK_Wall_By_Location = null;
				else
					this._FK_Wall_By_Location = (decimal?)drWall_By_Location_Attachment["FK_Wall_By_Location"];

				if (drWall_By_Location_Attachment["Input_File_Name"] == DBNull.Value)
					this._Input_File_Name = null;
				else
					this._Input_File_Name = (string)drWall_By_Location_Attachment["Input_File_Name"];

				if (drWall_By_Location_Attachment["Stored_File_Name"] == DBNull.Value)
					this._Stored_File_Name = null;
				else
					this._Stored_File_Name = (string)drWall_By_Location_Attachment["Stored_File_Name"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Wall_By_Location_Attachment table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_Location_AttachmentInsert");

			
			db.AddInParameter(dbCommand, "FK_Wall_By_Location", DbType.Decimal, this._FK_Wall_By_Location);
			
			if (string.IsNullOrEmpty(this._Input_File_Name))
				db.AddInParameter(dbCommand, "Input_File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Input_File_Name", DbType.String, this._Input_File_Name);
			
			if (string.IsNullOrEmpty(this._Stored_File_Name))
				db.AddInParameter(dbCommand, "Stored_File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Stored_File_Name", DbType.String, this._Stored_File_Name);
			
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Wall_By_Location_Attachment table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Wall_By_Location_Attachment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_Location_AttachmentSelectByPK");

			db.AddInParameter(dbCommand, "PK_Wall_By_Location_Attachment", DbType.Decimal, pK_Wall_By_Location_Attachment);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Wall_By_Location_Attachment table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_Location_AttachmentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Wall_By_Location_Attachment table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_Location_AttachmentUpdate");

			
			db.AddInParameter(dbCommand, "PK_Wall_By_Location_Attachment", DbType.Decimal, this._PK_Wall_By_Location_Attachment);
			
			db.AddInParameter(dbCommand, "FK_Wall_By_Location", DbType.Decimal, this._FK_Wall_By_Location);
			
			if (string.IsNullOrEmpty(this._Input_File_Name))
				db.AddInParameter(dbCommand, "Input_File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Input_File_Name", DbType.String, this._Input_File_Name);
			
			if (string.IsNullOrEmpty(this._Stored_File_Name))
				db.AddInParameter(dbCommand, "Stored_File_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Stored_File_Name", DbType.String, this._Stored_File_Name);
			
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Wall_By_Location_Attachment table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Wall_By_Location_Attachment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_Location_AttachmentDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Wall_By_Location_Attachment", DbType.Decimal, pK_Wall_By_Location_Attachment);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Main_Wall_Attachment table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByFK(decimal FK_Main_Wall)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_Location_AttachmentSelectByFK");

            db.AddInParameter(dbCommand, "FK_Wall_By_Location", DbType.Decimal, FK_Main_Wall);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
