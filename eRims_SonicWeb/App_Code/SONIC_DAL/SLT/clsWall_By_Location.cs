using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Wall_By_Location table.
	/// </summary>
	public sealed class clsWall_By_Location
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Wall_By_Location;
		private string _Type;
		private decimal? _FK_Wall_By_Location;
		private decimal? _Comment_Sequence;
		private string _Last_Name;
		private string _First_Name;
		private string _Topic;
		private string _Message;
		private string _Filter_By;
		private string _Filter_Value;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Wall_By_Location value.
		/// </summary>
		public decimal? PK_Wall_By_Location
		{
			get { return _PK_Wall_By_Location; }
			set { _PK_Wall_By_Location = value; }
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
		/// Gets or sets the FK_Wall_By_Location value.
		/// </summary>
		public decimal? FK_Wall_By_Location
		{
			get { return _FK_Wall_By_Location; }
			set { _FK_Wall_By_Location = value; }
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
		/// Gets or sets the Filter_By value.
		/// </summary>
		public string Filter_By
		{
			get { return _Filter_By; }
			set { _Filter_By = value; }
		}

		/// <summary>
		/// Gets or sets the Filter_Value value.
		/// </summary>
		public string Filter_Value
		{
			get { return _Filter_Value; }
			set { _Filter_Value = value; }
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
		/// Initializes a new instance of the clsWall_By_Location class with default value.
		/// </summary>
		public clsWall_By_Location() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsWall_By_Location class based on Primary Key.
		/// </summary>
		public clsWall_By_Location(decimal pK_Wall_By_Location) 
		{
			DataTable dtWall_By_Location = SelectByPK(pK_Wall_By_Location).Tables[0];

			if (dtWall_By_Location.Rows.Count == 1)
			{
				 SetValue(dtWall_By_Location.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsWall_By_Location class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drWall_By_Location) 
		{
				if (drWall_By_Location["PK_Wall_By_Location"] == DBNull.Value)
					this._PK_Wall_By_Location = null;
				else
					this._PK_Wall_By_Location = (decimal?)drWall_By_Location["PK_Wall_By_Location"];

				if (drWall_By_Location["Type"] == DBNull.Value)
					this._Type = null;
				else
					this._Type = (string)drWall_By_Location["Type"];

				if (drWall_By_Location["FK_Wall_By_Location"] == DBNull.Value)
					this._FK_Wall_By_Location = null;
				else
					this._FK_Wall_By_Location = (decimal?)drWall_By_Location["FK_Wall_By_Location"];

				if (drWall_By_Location["Comment_Sequence"] == DBNull.Value)
					this._Comment_Sequence = null;
				else
					this._Comment_Sequence = (decimal?)drWall_By_Location["Comment_Sequence"];

				if (drWall_By_Location["Last_Name"] == DBNull.Value)
					this._Last_Name = null;
				else
					this._Last_Name = (string)drWall_By_Location["Last_Name"];

				if (drWall_By_Location["First_Name"] == DBNull.Value)
					this._First_Name = null;
				else
					this._First_Name = (string)drWall_By_Location["First_Name"];

				if (drWall_By_Location["Topic"] == DBNull.Value)
					this._Topic = null;
				else
					this._Topic = (string)drWall_By_Location["Topic"];

				if (drWall_By_Location["Message"] == DBNull.Value)
					this._Message = null;
				else
					this._Message = (string)drWall_By_Location["Message"];

				if (drWall_By_Location["Filter_By"] == DBNull.Value)
					this._Filter_By = null;
				else
					this._Filter_By = (string)drWall_By_Location["Filter_By"];

				if (drWall_By_Location["Filter_Value"] == DBNull.Value)
					this._Filter_Value = null;
				else
					this._Filter_Value = (string)drWall_By_Location["Filter_Value"];

				if (drWall_By_Location["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drWall_By_Location["Updated_By"];

				if (drWall_By_Location["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drWall_By_Location["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Wall_By_Location table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_LocationInsert");

			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			db.AddInParameter(dbCommand, "FK_Wall_By_Location", DbType.Decimal, this._FK_Wall_By_Location);
			
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
			
			if (string.IsNullOrEmpty(this._Filter_By))
				db.AddInParameter(dbCommand, "Filter_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Filter_By", DbType.String, this._Filter_By);
			
			if (string.IsNullOrEmpty(this._Filter_Value))
				db.AddInParameter(dbCommand, "Filter_Value", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Filter_Value", DbType.String, this._Filter_Value);
			
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
		/// Selects a single record from the Wall_By_Location table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Wall_By_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_LocationSelectByPK");

			db.AddInParameter(dbCommand, "PK_Wall_By_Location", DbType.Decimal, pK_Wall_By_Location);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Wall_By_Location table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_LocationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Wall_By_Location table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_LocationUpdate");

			
			db.AddInParameter(dbCommand, "PK_Wall_By_Location", DbType.Decimal, this._PK_Wall_By_Location);
			
            //if (string.IsNullOrEmpty(this._Type))
            //    db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
            //db.AddInParameter(dbCommand, "FK_Wall_By_Location", DbType.Decimal, this._FK_Wall_By_Location);
			
            //db.AddInParameter(dbCommand, "Comment_Sequence", DbType.Decimal, this._Comment_Sequence);
			
            //if (string.IsNullOrEmpty(this._Last_Name))
            //    db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);
			
            //if (string.IsNullOrEmpty(this._First_Name))
            //    db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);
			
			if (string.IsNullOrEmpty(this._Topic))
				db.AddInParameter(dbCommand, "Topic", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Topic", DbType.String, this._Topic);
			
			if (string.IsNullOrEmpty(this._Message))
				db.AddInParameter(dbCommand, "Message", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Message", DbType.String, this._Message);
			
			if (string.IsNullOrEmpty(this._Filter_By))
				db.AddInParameter(dbCommand, "Filter_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Filter_By", DbType.String, this._Filter_By);
			
			if (string.IsNullOrEmpty(this._Filter_Value))
				db.AddInParameter(dbCommand, "Filter_Value", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Filter_Value", DbType.String, this._Filter_Value);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Wall_By_Location table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Wall_By_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Wall_By_LocationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Wall_By_Location", DbType.Decimal, pK_Wall_By_Location);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the Main_Wall table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SearchWallPostsByLocation(int intPageNo, int intPageSize, string strLastName, string strFirstName, DateTime? dtPostDateFrom, DateTime? dtPostDateTo, string strPostText, string strTopic,
                            decimal PK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchWallPostsByLocation");

            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            db.AddInParameter(dbCommand, "@strLastName", DbType.String, strLastName);
            db.AddInParameter(dbCommand, "@strFirstName", DbType.String, strFirstName);
            db.AddInParameter(dbCommand, "@dtPostDateFrom", DbType.DateTime, dtPostDateFrom);
            db.AddInParameter(dbCommand, "@dtPostDateTo", DbType.DateTime, dtPostDateTo);
            db.AddInParameter(dbCommand, "@strPostText", DbType.String, strPostText);
            db.AddInParameter(dbCommand, "@strTopic", DbType.String, strTopic);
            db.AddInParameter(dbCommand, "@FK_LU_Location_ID", DbType.String, PK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Wall_By_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SearchWallPostsByLocationAdmin(int intPageNo, int intPageSize, string strLastName, string strFirstName, DateTime? dtPostDateFrom, DateTime? dtPostDateTo, string strPostText, string strTopic, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchWallPostsByLocationAdmin");

            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            db.AddInParameter(dbCommand, "@strLastName", DbType.String, strLastName);
            db.AddInParameter(dbCommand, "@strFirstName", DbType.String, strFirstName);
            db.AddInParameter(dbCommand, "@dtPostDateFrom", DbType.DateTime, dtPostDateFrom);
            db.AddInParameter(dbCommand, "@dtPostDateTo", DbType.DateTime, dtPostDateTo);
            db.AddInParameter(dbCommand, "@strPostText", DbType.String, strPostText);
            db.AddInParameter(dbCommand, "@strTopic", DbType.String, strTopic);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Wall_By_Location table by a composite primary key.
        /// </summary>
        public static DataSet DeleteByPKs(string strPK_Wall_By_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WallByLocationDeleteByPKs");

            db.AddInParameter(dbCommand, "strPK_Wall_By_Location", DbType.String, strPK_Wall_By_Location);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
