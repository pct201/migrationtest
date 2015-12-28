using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Main_Wall_Attachment table.
	/// </summary>
	public sealed class clsMain_Wall_Attachment
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Main_Wall_Attachment;
		private decimal? _FK_Main_Wall;
		private string _Input_File_Name;
		private string _Stored_File_Name;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Main_Wall_Attachment value.
		/// </summary>
		public decimal? PK_Main_Wall_Attachment
		{
			get { return _PK_Main_Wall_Attachment; }
			set { _PK_Main_Wall_Attachment = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Main_Wall value.
		/// </summary>
		public decimal? FK_Main_Wall
		{
			get { return _FK_Main_Wall; }
			set { _FK_Main_Wall = value; }
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
		/// Initializes a new instance of the clsMain_Wall_Attachment class with default value.
		/// </summary>
		public clsMain_Wall_Attachment() 
		{


		}

        
		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsMain_Wall_Attachment class based on Primary Key.
		/// </summary>
		public clsMain_Wall_Attachment(decimal pK_Main_Wall_Attachment) 
		{
			DataTable dtMain_Wall_Attachment = SelectByPK(pK_Main_Wall_Attachment).Tables[0];

			if (dtMain_Wall_Attachment.Rows.Count == 1)
			{
				 SetValue(dtMain_Wall_Attachment.Rows[0]);

			}

		}

        /// <summary>
        /// Initializes a new instance of the Main_Wall_Attachment class based on Primary Key.
        /// </summary>
        public clsMain_Wall_Attachment(decimal FK_Main_Wall, bool isFK)
        {
            DataTable dtMain_Wall_Attachment = SelectByFK(FK_Main_Wall).Tables[0];

            if (dtMain_Wall_Attachment.Rows.Count == 1)
            {
                DataRow drMain_Wall_Attachment = dtMain_Wall_Attachment.Rows[0];
                SetValue(drMain_Wall_Attachment);
            }
            else
            {
                this._PK_Main_Wall_Attachment = null;
                this._FK_Main_Wall = null;
                this._Input_File_Name = null;
                this._Stored_File_Name = null;
            }

        }

		/// <summary>
		/// Initializes a new instance of the clsMain_Wall_Attachment class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drMain_Wall_Attachment) 
		{
				if (drMain_Wall_Attachment["PK_Main_Wall_Attachment"] == DBNull.Value)
					this._PK_Main_Wall_Attachment = null;
				else
					this._PK_Main_Wall_Attachment = (decimal?)drMain_Wall_Attachment["PK_Main_Wall_Attachment"];

				if (drMain_Wall_Attachment["FK_Main_Wall"] == DBNull.Value)
					this._FK_Main_Wall = null;
				else
					this._FK_Main_Wall = (decimal?)drMain_Wall_Attachment["FK_Main_Wall"];

				if (drMain_Wall_Attachment["Input_File_Name"] == DBNull.Value)
					this._Input_File_Name = null;
				else
					this._Input_File_Name = (string)drMain_Wall_Attachment["Input_File_Name"];

				if (drMain_Wall_Attachment["Stored_File_Name"] == DBNull.Value)
					this._Stored_File_Name = null;
				else
					this._Stored_File_Name = (string)drMain_Wall_Attachment["Stored_File_Name"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Main_Wall_Attachment table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Main_Wall_AttachmentInsert");

			
			db.AddInParameter(dbCommand, "FK_Main_Wall", DbType.Decimal, this._FK_Main_Wall);
			
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
		/// Selects a single record from the Main_Wall_Attachment table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Main_Wall_Attachment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Main_Wall_AttachmentSelectByPK");

			db.AddInParameter(dbCommand, "PK_Main_Wall_Attachment", DbType.Decimal, pK_Main_Wall_Attachment);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Main_Wall_Attachment table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Main_Wall_AttachmentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Main_Wall_Attachment table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Main_Wall_AttachmentUpdate");

			
			db.AddInParameter(dbCommand, "PK_Main_Wall_Attachment", DbType.Decimal, this._PK_Main_Wall_Attachment);
			
			db.AddInParameter(dbCommand, "FK_Main_Wall", DbType.Decimal, this._FK_Main_Wall);
			
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
		/// Deletes a record from the Main_Wall_Attachment table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Main_Wall_Attachment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Main_Wall_AttachmentDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Main_Wall_Attachment", DbType.Decimal, pK_Main_Wall_Attachment);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Main_Wall_Attachment table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByFK(decimal FK_Main_Wall)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Main_Wall_AttachmentSelectByFK");

            db.AddInParameter(dbCommand, "FK_Main_Wall", DbType.Decimal, FK_Main_Wall);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
