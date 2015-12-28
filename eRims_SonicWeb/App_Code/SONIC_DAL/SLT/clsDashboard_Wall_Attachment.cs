using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Dashboard_Wall_Attachment table.
	/// </summary>
	public sealed class clsDashboard_Wall_Attachment
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Dashboard_Wall_Attachment;
		private decimal? _FK_Dashboard_Wall;
		private string _Input_File_Name;
		private string _Stored_File_Name;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Dashboard_Wall_Attachment value.
		/// </summary>
		public decimal? PK_Dashboard_Wall_Attachment
		{
			get { return _PK_Dashboard_Wall_Attachment; }
			set { _PK_Dashboard_Wall_Attachment = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Dashboard_Wall value.
		/// </summary>
		public decimal? FK_Dashboard_Wall
		{
			get { return _FK_Dashboard_Wall; }
			set { _FK_Dashboard_Wall = value; }
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
		/// Initializes a new instance of the clsDashboard_Wall_Attachment class with default value.
		/// </summary>
		public clsDashboard_Wall_Attachment() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsDashboard_Wall_Attachment class based on Primary Key.
		/// </summary>
		public clsDashboard_Wall_Attachment(decimal pK_Dashboard_Wall_Attachment) 
		{
			DataTable dtDashboard_Wall_Attachment = SelectByPK(pK_Dashboard_Wall_Attachment).Tables[0];

			if (dtDashboard_Wall_Attachment.Rows.Count == 1)
			{
				 SetValue(dtDashboard_Wall_Attachment.Rows[0]);

			}

		}

        /// <summary>
        /// Initializes a new instance of the Dashboard_Wall_Attachment class based on Primary Key.
        /// </summary>
        public clsDashboard_Wall_Attachment(decimal FK_Dashboard_Wall, bool isFK)
        {
            DataTable dtDashboard_Wall_Attachment = SelectByFK(FK_Dashboard_Wall).Tables[0];

            if (dtDashboard_Wall_Attachment.Rows.Count == 1)
            {
                DataRow drDashboard_Wall_Attachment = dtDashboard_Wall_Attachment.Rows[0];
                SetValue(drDashboard_Wall_Attachment);
            }
            else
            {
                this._PK_Dashboard_Wall_Attachment = null;
                this._FK_Dashboard_Wall = null;
                this._Input_File_Name = null;
                this._Stored_File_Name = null;
            }

        }

		/// <summary>
		/// Initializes a new instance of the clsDashboard_Wall_Attachment class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drDashboard_Wall_Attachment) 
		{
				if (drDashboard_Wall_Attachment["PK_Dashboard_Wall_Attachment"] == DBNull.Value)
					this._PK_Dashboard_Wall_Attachment = null;
				else
					this._PK_Dashboard_Wall_Attachment = (decimal?)drDashboard_Wall_Attachment["PK_Dashboard_Wall_Attachment"];

				if (drDashboard_Wall_Attachment["FK_Dashboard_Wall"] == DBNull.Value)
					this._FK_Dashboard_Wall = null;
				else
					this._FK_Dashboard_Wall = (decimal?)drDashboard_Wall_Attachment["FK_Dashboard_Wall"];

				if (drDashboard_Wall_Attachment["Input_File_Name"] == DBNull.Value)
					this._Input_File_Name = null;
				else
					this._Input_File_Name = (string)drDashboard_Wall_Attachment["Input_File_Name"];

				if (drDashboard_Wall_Attachment["Stored_File_Name"] == DBNull.Value)
					this._Stored_File_Name = null;
				else
					this._Stored_File_Name = (string)drDashboard_Wall_Attachment["Stored_File_Name"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Dashboard_Wall_Attachment table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_Wall_AttachmentInsert");

			
			db.AddInParameter(dbCommand, "FK_Dashboard_Wall", DbType.Decimal, this._FK_Dashboard_Wall);
			
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
		/// Selects a single record from the Dashboard_Wall_Attachment table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Dashboard_Wall_Attachment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_Wall_AttachmentSelectByPK");

			db.AddInParameter(dbCommand, "PK_Dashboard_Wall_Attachment", DbType.Decimal, pK_Dashboard_Wall_Attachment);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Dashboard_Wall_Attachment table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_Wall_AttachmentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Dashboard_Wall_Attachment table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_Wall_AttachmentUpdate");

			
			db.AddInParameter(dbCommand, "PK_Dashboard_Wall_Attachment", DbType.Decimal, this._PK_Dashboard_Wall_Attachment);
			
			db.AddInParameter(dbCommand, "FK_Dashboard_Wall", DbType.Decimal, this._FK_Dashboard_Wall);
			
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
		/// Deletes a record from the Dashboard_Wall_Attachment table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Dashboard_Wall_Attachment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_Wall_AttachmentDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Dashboard_Wall_Attachment", DbType.Decimal, pK_Dashboard_Wall_Attachment);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Dashboard_Wall_Attachment table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByFK(decimal FK_Dashboard_Wall)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_Wall_AttachmentSelectByFK");

            db.AddInParameter(dbCommand, "FK_Dashboard_Wall", DbType.Decimal, FK_Dashboard_Wall);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
