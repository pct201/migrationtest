using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Video_Request_Notes table.
	/// </summary>
	public sealed class clsVideo_Request_Notes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Video_Request_Notes;
		private decimal? _FK_Event_Video_Tracking_Request;
		private DateTime? _Note_Date;
		private string _Note;
		private decimal? _Updated_by;
		private DateTime? _Updated_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Video_Request_Notes value.
		/// </summary>
		public decimal? PK_Video_Request_Notes
		{
			get { return _PK_Video_Request_Notes; }
			set { _PK_Video_Request_Notes = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Event_Video_Tracking_Request value.
		/// </summary>
		public decimal? FK_Event_Video_Tracking_Request
		{
			get { return _FK_Event_Video_Tracking_Request; }
			set { _FK_Event_Video_Tracking_Request = value; }
		}

		/// <summary>
		/// Gets or sets the Note_Date value.
		/// </summary>
		public DateTime? Note_Date
		{
			get { return _Note_Date; }
			set { _Note_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Note value.
		/// </summary>
		public string Note
		{
			get { return _Note; }
			set { _Note = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_by value.
		/// </summary>
		public decimal? Updated_by
		{
			get { return _Updated_by; }
			set { _Updated_by = value; }
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
		/// Initializes a new instance of the clsVideo_Request_Notes class with default value.
		/// </summary>
		public clsVideo_Request_Notes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsVideo_Request_Notes class based on Primary Key.
		/// </summary>
		public clsVideo_Request_Notes(decimal pK_Video_Request_Notes) 
		{
			DataTable dtVideo_Request_Notes = SelectByPK(pK_Video_Request_Notes).Tables[0];

			if (dtVideo_Request_Notes.Rows.Count == 1)
			{
				 SetValue(dtVideo_Request_Notes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsVideo_Request_Notes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drVideo_Request_Notes) 
		{
				if (drVideo_Request_Notes["PK_Video_Request_Notes"] == DBNull.Value)
					this._PK_Video_Request_Notes = null;
				else
					this._PK_Video_Request_Notes = (decimal?)drVideo_Request_Notes["PK_Video_Request_Notes"];

				if (drVideo_Request_Notes["FK_Event_Video_Tracking_Request"] == DBNull.Value)
					this._FK_Event_Video_Tracking_Request = null;
				else
					this._FK_Event_Video_Tracking_Request = (decimal?)drVideo_Request_Notes["FK_Event_Video_Tracking_Request"];

				if (drVideo_Request_Notes["Note_Date"] == DBNull.Value)
					this._Note_Date = null;
				else
					this._Note_Date = (DateTime?)drVideo_Request_Notes["Note_Date"];

				if (drVideo_Request_Notes["Note"] == DBNull.Value)
					this._Note = null;
				else
					this._Note = (string)drVideo_Request_Notes["Note"];

				if (drVideo_Request_Notes["Updated_by"] == DBNull.Value)
					this._Updated_by = null;
				else
					this._Updated_by = (decimal?)drVideo_Request_Notes["Updated_by"];

				if (drVideo_Request_Notes["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drVideo_Request_Notes["Updated_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Video_Request_Notes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Video_Request_NotesInsert");

			
			db.AddInParameter(dbCommand, "FK_Event_Video_Tracking_Request", DbType.Decimal, this._FK_Event_Video_Tracking_Request);
			
			db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
			
			if (string.IsNullOrEmpty(this._Note))
				db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
			
			db.AddInParameter(dbCommand, "Updated_by", DbType.Decimal, this._Updated_by);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Video_Request_Notes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Video_Request_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Video_Request_NotesSelectByPK");

			db.AddInParameter(dbCommand, "PK_Video_Request_Notes", DbType.Decimal, pK_Video_Request_Notes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Video_Request_Notes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Video_Request_NotesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Video_Request_Notes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Video_Request_NotesUpdate");

			
			db.AddInParameter(dbCommand, "PK_Video_Request_Notes", DbType.Decimal, this._PK_Video_Request_Notes);
			
			db.AddInParameter(dbCommand, "FK_Event_Video_Tracking_Request", DbType.Decimal, this._FK_Event_Video_Tracking_Request);
			
			db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
			
			if (string.IsNullOrEmpty(this._Note))
				db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
			
			db.AddInParameter(dbCommand, "Updated_by", DbType.Decimal, this._Updated_by);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Video_Request_Notes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Video_Request_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Video_Request_NotesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Video_Request_Notes", DbType.Decimal, pK_Video_Request_Notes);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects record from the Video_Request_Notes table by FK_Management.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event_Video_Tracking_Request_WithPaging(decimal FK_Management, int intPageNo, int intPageSize, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Video_Request_NotesSelectPagingByFK_Management");

            db.AddInParameter(dbCommand, "FK_Event_Video_Tracking_Request", DbType.Decimal, FK_Management);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Video_Request_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Video_Request_NotesSelectByIDs");

            db.AddInParameter(dbCommand, "PK_Video_Request_Notes", DbType.String, strIDs);

            return db.ExecuteDataSet(dbCommand);
        }

        // <summary>
        // Selects record from the Video_Request_Notes table by FK_Event.
        // </summary>
        // <returns>DataSet</returns>
        public static DataSet SelectByFK_Event_Video_Tracking_Request(decimal FK_Event_Video_Tracking_Request)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Video_Request_NotesSelectByFK_Event_Video_Tracking_Request");

            db.AddInParameter(dbCommand, "FK_Event_Video_Tracking_Request", DbType.Decimal, FK_Event_Video_Tracking_Request);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
