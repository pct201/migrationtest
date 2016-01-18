using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Dashboard_Wall table.
	/// </summary>
	public sealed class clsDashboard_Wall
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Dashboard_Wall;
		private string _Type;
		private decimal? _FK_Dashboard_Wall;
		private decimal? _Comment_Sequence;
		private string _Last_Name;
		private string _First_Name;
		private string _Topic;
		private string _Message;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Dashboard_Wall value.
		/// </summary>
		public decimal? PK_Dashboard_Wall
		{
			get { return _PK_Dashboard_Wall; }
			set { _PK_Dashboard_Wall = value; }
		}

		/// <summary>
		/// Gets or sets the Type value.
		/// </summary>
		public string Type
		{
			get { return _Type; }
			set { _Type = value; }
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
		/// Gets or sets the Comment_Sequence value.
		/// </summary>
		public decimal? Comment_Sequence
		{
			get { return _Comment_Sequence; }
			set { _Comment_Sequence = value; }
		}

		/// <summary>
		/// Gets or sets the Last_Name value.
		/// </summary>
		public string Last_Name
		{
			get { return _Last_Name; }
			set { _Last_Name = value; }
		}

		/// <summary>
		/// Gets or sets the First_Name value.
		/// </summary>
		public string First_Name
		{
			get { return _First_Name; }
			set { _First_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Topic value.
		/// </summary>
		public string Topic
		{
			get { return _Topic; }
			set { _Topic = value; }
		}

		/// <summary>
		/// Gets or sets the Message value.
		/// </summary>
		public string Message
		{
			get { return _Message; }
			set { _Message = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsDashboard_Wall class with default value.
		/// </summary>
		public clsDashboard_Wall() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsDashboard_Wall class based on Primary Key.
		/// </summary>
		public clsDashboard_Wall(decimal pK_Dashboard_Wall) 
		{
			DataTable dtDashboard_Wall = SelectByPK(pK_Dashboard_Wall).Tables[0];

			if (dtDashboard_Wall.Rows.Count == 1)
			{
				 SetValue(dtDashboard_Wall.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsDashboard_Wall class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drDashboard_Wall) 
		{
				if (drDashboard_Wall["PK_Dashboard_Wall"] == DBNull.Value)
					this._PK_Dashboard_Wall = null;
				else
					this._PK_Dashboard_Wall = (decimal?)drDashboard_Wall["PK_Dashboard_Wall"];

				if (drDashboard_Wall["Type"] == DBNull.Value)
					this._Type = null;
				else
					this._Type = (string)drDashboard_Wall["Type"];

				if (drDashboard_Wall["FK_Dashboard_Wall"] == DBNull.Value)
					this._FK_Dashboard_Wall = null;
				else
					this._FK_Dashboard_Wall = (decimal?)drDashboard_Wall["FK_Dashboard_Wall"];

				if (drDashboard_Wall["Comment_Sequence"] == DBNull.Value)
					this._Comment_Sequence = null;
				else
					this._Comment_Sequence = (decimal?)drDashboard_Wall["Comment_Sequence"];

				if (drDashboard_Wall["Last_Name"] == DBNull.Value)
					this._Last_Name = null;
				else
					this._Last_Name = (string)drDashboard_Wall["Last_Name"];

				if (drDashboard_Wall["First_Name"] == DBNull.Value)
					this._First_Name = null;
				else
					this._First_Name = (string)drDashboard_Wall["First_Name"];

				if (drDashboard_Wall["Topic"] == DBNull.Value)
					this._Topic = null;
				else
					this._Topic = (string)drDashboard_Wall["Topic"];

				if (drDashboard_Wall["Message"] == DBNull.Value)
					this._Message = null;
				else
					this._Message = (string)drDashboard_Wall["Message"];

				if (drDashboard_Wall["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drDashboard_Wall["Updated_By"];

				if (drDashboard_Wall["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drDashboard_Wall["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Dashboard_Wall table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_WallInsert");

			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			db.AddInParameter(dbCommand, "FK_Dashboard_Wall", DbType.Decimal, this._FK_Dashboard_Wall);
			
			db.AddInParameter(dbCommand, "Comment_Sequence", DbType.Decimal, this._Comment_Sequence);
			
			if (string.IsNullOrEmpty(this._Last_Name))
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);
			
			if (string.IsNullOrEmpty(this._First_Name))
				db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);
			
			if (string.IsNullOrEmpty(this._Topic))
				db.AddInParameter(dbCommand, "Topic", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Topic", DbType.String, this._Topic);
			
			if (string.IsNullOrEmpty(this._Message))
				db.AddInParameter(dbCommand, "Message", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Message", DbType.String, this._Message);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Dashboard_Wall table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Dashboard_Wall)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_WallSelectByPK");

			db.AddInParameter(dbCommand, "PK_Dashboard_Wall", DbType.Decimal, pK_Dashboard_Wall);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Dashboard_Wall table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_WallSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Dashboard_Wall table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_WallUpdate");

			
			db.AddInParameter(dbCommand, "PK_Dashboard_Wall", DbType.Decimal, this._PK_Dashboard_Wall);
			
			if (string.IsNullOrEmpty(this._Topic))
				db.AddInParameter(dbCommand, "Topic", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Topic", DbType.String, this._Topic);
			
			if (string.IsNullOrEmpty(this._Message))
				db.AddInParameter(dbCommand, "Message", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Message", DbType.String, this._Message);
		
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Dashboard_Wall table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Dashboard_Wall)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_WallDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Dashboard_Wall", DbType.Decimal, pK_Dashboard_Wall);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the Main_Wall table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SearchWallPosts(int intPageNo, int intPageSize, string strLastName, string strFirstName, DateTime? dtPostDateFrom, DateTime? dtPostDateTo, string strPostText, string strTopic)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchDashboardWallPosts");

            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            db.AddInParameter(dbCommand, "@strLastName", DbType.String, strLastName);
            db.AddInParameter(dbCommand, "@strFirstName", DbType.String, strFirstName);
            db.AddInParameter(dbCommand, "@dtPostDateFrom", DbType.DateTime, dtPostDateFrom);
            db.AddInParameter(dbCommand, "@dtPostDateTo", DbType.DateTime, dtPostDateTo);
            db.AddInParameter(dbCommand, "@strPostText", DbType.String, strPostText);
            db.AddInParameter(dbCommand, "@strTopic", DbType.String, strTopic);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Main_Wall table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SearchWallPostsAdmin(int intPageNo, int intPageSize, string strLastName, string strFirstName, string strPostDateFrom, string strPostDateTo, string strPostText, string strTopic, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchDashboardWallPostsAdmin");

            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            db.AddInParameter(dbCommand, "@strLastName", DbType.String, strLastName);
            db.AddInParameter(dbCommand, "@strFirstName", DbType.String, strFirstName);
            db.AddInParameter(dbCommand, "@dtPostDateFrom", DbType.String, strPostDateFrom);
            db.AddInParameter(dbCommand, "@dtPostDateTo", DbType.String, strPostDateTo);
            db.AddInParameter(dbCommand, "@strPostText", DbType.String, strPostText);
            db.AddInParameter(dbCommand, "@strTopic", DbType.String, strTopic);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Main_Wall table by a composite primary key.
        /// </summary>
        public static DataSet DeleteByPKs(string strPK_Dashboard_Wall)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Dashboard_WallDeleteByPKs");

            db.AddInParameter(dbCommand, "strPK_Dashboard_Wall", DbType.String, strPK_Dashboard_Wall);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
