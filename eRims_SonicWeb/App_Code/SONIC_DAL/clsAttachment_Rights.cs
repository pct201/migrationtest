using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Attachment_Rights table.
	/// </summary>
	public sealed class clsAttachment_Rights
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Attachment_Rights;
		private decimal? _FK_Module;
		private decimal? _FK_Virtual_Folder;
		private string _Right_Name;
		private decimal? _RightType_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Attachment_Rights value.
		/// </summary>
		public decimal? PK_Attachment_Rights
		{
			get { return _PK_Attachment_Rights; }
			set { _PK_Attachment_Rights = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Module value.
		/// </summary>
		public decimal? FK_Module
		{
			get { return _FK_Module; }
			set { _FK_Module = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Virtual_Folder value.
		/// </summary>
		public decimal? FK_Virtual_Folder
		{
			get { return _FK_Virtual_Folder; }
			set { _FK_Virtual_Folder = value; }
		}

		/// <summary>
		/// Gets or sets the Right_Name value.
		/// </summary>
		public string Right_Name
		{
			get { return _Right_Name; }
			set { _Right_Name = value; }
		}

		/// <summary>
		/// Gets or sets the RightType_ID value.
		/// </summary>
		public decimal? RightType_ID
		{
			get { return _RightType_ID; }
			set { _RightType_ID = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsAttachment_Rights class with default value.
		/// </summary>
		public clsAttachment_Rights() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAttachment_Rights class based on Primary Key.
		/// </summary>
		public clsAttachment_Rights(decimal pK_Attachment_Rights) 
		{
			DataTable dtAttachment_Rights = SelectByPK(pK_Attachment_Rights).Tables[0];

			if (dtAttachment_Rights.Rows.Count == 1)
			{
				 SetValue(dtAttachment_Rights.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAttachment_Rights class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAttachment_Rights) 
		{
				if (drAttachment_Rights["PK_Attachment_Rights"] == DBNull.Value)
					this._PK_Attachment_Rights = null;
				else
					this._PK_Attachment_Rights = (decimal?)drAttachment_Rights["PK_Attachment_Rights"];

				if (drAttachment_Rights["FK_Module"] == DBNull.Value)
					this._FK_Module = null;
				else
					this._FK_Module = (decimal?)drAttachment_Rights["FK_Module"];

				if (drAttachment_Rights["FK_Virtual_Folder"] == DBNull.Value)
					this._FK_Virtual_Folder = null;
				else
					this._FK_Virtual_Folder = (decimal?)drAttachment_Rights["FK_Virtual_Folder"];

				if (drAttachment_Rights["Right_Name"] == DBNull.Value)
					this._Right_Name = null;
				else
					this._Right_Name = (string)drAttachment_Rights["Right_Name"];

				if (drAttachment_Rights["RightType_ID"] == DBNull.Value)
					this._RightType_ID = null;
				else
					this._RightType_ID = (decimal?)drAttachment_Rights["RightType_ID"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Attachment_Rights table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_RightsInsert");

			
			db.AddInParameter(dbCommand, "FK_Module", DbType.Decimal, this._FK_Module);
			
			db.AddInParameter(dbCommand, "FK_Virtual_Folder", DbType.Decimal, this._FK_Virtual_Folder);
			
			if (string.IsNullOrEmpty(this._Right_Name))
				db.AddInParameter(dbCommand, "Right_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Right_Name", DbType.String, this._Right_Name);
			
			db.AddInParameter(dbCommand, "RightType_ID", DbType.Decimal, this._RightType_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Attachment_Rights table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Attachment_Rights)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_RightsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Attachment_Rights", DbType.Decimal, pK_Attachment_Rights);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Attachment_Rights table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_RightsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Attachment_Rights table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_RightsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Attachment_Rights", DbType.Decimal, this._PK_Attachment_Rights);
			
			db.AddInParameter(dbCommand, "FK_Module", DbType.Decimal, this._FK_Module);
			
			db.AddInParameter(dbCommand, "FK_Virtual_Folder", DbType.Decimal, this._FK_Virtual_Folder);
			
			if (string.IsNullOrEmpty(this._Right_Name))
				db.AddInParameter(dbCommand, "Right_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Right_Name", DbType.String, this._Right_Name);
			
			db.AddInParameter(dbCommand, "RightType_ID", DbType.Decimal, this._RightType_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Attachment_Rights table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Attachment_Rights)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_RightsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Attachment_Rights", DbType.Decimal, pK_Attachment_Rights);

			db.ExecuteNonQuery(dbCommand);
		}

        public static void DeleteByFK(decimal FK_Virtual_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_RightsDeleteByFK");

            db.AddInParameter(dbCommand, "FK_Virtual_Folder", DbType.Decimal, FK_Virtual_Folder);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Inserts / Updates a record into the Attachment_Rights table.
        /// </summary>
        /// <returns></returns>
        public int InsertUpdate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_RightsInsertUpdate");

            db.AddInParameter(dbCommand, "PK_Attachment_Rights", DbType.Decimal, this._PK_Attachment_Rights);
            db.AddInParameter(dbCommand, "FK_Module", DbType.Decimal, this._FK_Module);
            db.AddInParameter(dbCommand, "FK_Virtual_Folder", DbType.Decimal, this._FK_Virtual_Folder);
            if (string.IsNullOrEmpty(this._Right_Name))
                db.AddInParameter(dbCommand, "Right_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Right_Name", DbType.String, this._Right_Name);
            db.AddInParameter(dbCommand, "RightType_ID", DbType.Decimal, this._RightType_ID);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        public static DataSet SelectByModuleID(decimal ModuleId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_RightsSelectByModuleID");

            db.AddInParameter(dbCommand, "ModuleId", DbType.Decimal, ModuleId);

            return db.ExecuteDataSet(dbCommand);
        }

        
	}
}
