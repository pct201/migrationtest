using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Find_it_Fix_it table.
	/// </summary>
	public sealed class clsFind_it_Fix_it
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Find_it_Fix_it;
		private decimal? _FK_Lu_Category;
		private decimal? _FK_Lu_Department;
		private decimal? _FK_Members;
		private string _Find_It_Description;
		private string _Fixt_it_Description;
		private string _RCLM_Comments;
		private decimal? _FK_SLT_Meeting;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Find_it_Fix_it value.
		/// </summary>
		public decimal? PK_Find_it_Fix_it
		{
			get { return _PK_Find_it_Fix_it; }
			set { _PK_Find_it_Fix_it = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Lu_Category value.
		/// </summary>
		public decimal? FK_Lu_Category
		{
			get { return _FK_Lu_Category; }
			set { _FK_Lu_Category = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Lu_Department value.
		/// </summary>
		public decimal? FK_Lu_Department
		{
			get { return _FK_Lu_Department; }
			set { _FK_Lu_Department = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Members value.
		/// </summary>
		public decimal? FK_Members
		{
			get { return _FK_Members; }
			set { _FK_Members = value; }
		}

		/// <summary>
		/// Gets or sets the Find_It_Description value.
		/// </summary>
		public string Find_It_Description
		{
			get { return _Find_It_Description; }
			set { _Find_It_Description = value; }
		}

		/// <summary>
		/// Gets or sets the Fixt_it_Description value.
		/// </summary>
		public string Fixt_it_Description
		{
			get { return _Fixt_it_Description; }
			set { _Fixt_it_Description = value; }
		}

		/// <summary>
		/// Gets or sets the RCLM_Comments value.
		/// </summary>
		public string RCLM_Comments
		{
			get { return _RCLM_Comments; }
			set { _RCLM_Comments = value; }
		}

        /// <summary>
        /// Gets or sets the FK_SLT_Meeting value.
        /// </summary>
        public decimal? FK_SLT_Meeting
        {
			get { return _FK_SLT_Meeting; }
			set { _FK_SLT_Meeting = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsFind_it_Fix_it class with default value.
		/// </summary>
		public clsFind_it_Fix_it() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsFind_it_Fix_it class based on Primary Key.
		/// </summary>
		public clsFind_it_Fix_it(decimal pK_Find_it_Fix_it) 
		{
			DataTable dtFind_it_Fix_it = SelectByPK(pK_Find_it_Fix_it).Tables[0];

			if (dtFind_it_Fix_it.Rows.Count == 1)
			{
				 SetValue(dtFind_it_Fix_it.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsFind_it_Fix_it class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drFind_it_Fix_it) 
		{
				if (drFind_it_Fix_it["PK_Find_it_Fix_it"] == DBNull.Value)
					this._PK_Find_it_Fix_it = null;
				else
					this._PK_Find_it_Fix_it = (decimal?)drFind_it_Fix_it["PK_Find_it_Fix_it"];

				if (drFind_it_Fix_it["FK_Lu_Category"] == DBNull.Value)
					this._FK_Lu_Category = null;
				else
					this._FK_Lu_Category = (decimal?)drFind_it_Fix_it["FK_Lu_Category"];

				if (drFind_it_Fix_it["FK_Lu_Department"] == DBNull.Value)
					this._FK_Lu_Department = null;
				else
					this._FK_Lu_Department = (decimal?)drFind_it_Fix_it["FK_Lu_Department"];

				if (drFind_it_Fix_it["FK_Members"] == DBNull.Value)
					this._FK_Members = null;
				else
					this._FK_Members = (decimal?)drFind_it_Fix_it["FK_Members"];

				if (drFind_it_Fix_it["Find_It_Description"] == DBNull.Value)
					this._Find_It_Description = null;
				else
					this._Find_It_Description = (string)drFind_it_Fix_it["Find_It_Description"];

				if (drFind_it_Fix_it["Fixt_it_Description"] == DBNull.Value)
					this._Fixt_it_Description = null;
				else
					this._Fixt_it_Description = (string)drFind_it_Fix_it["Fixt_it_Description"];

				if (drFind_it_Fix_it["RCLM_Comments"] == DBNull.Value)
					this._RCLM_Comments = null;
				else
					this._RCLM_Comments = (string)drFind_it_Fix_it["RCLM_Comments"];

				if (drFind_it_Fix_it["FK_SLT_Meeting"] == DBNull.Value)
					this._FK_SLT_Meeting = null;
				else
					this._FK_SLT_Meeting = (decimal?)drFind_it_Fix_it["FK_SLT_Meeting"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Find_it_Fix_it table.
		/// </summary>
		/// <returns></returns>
		public void Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_itInsert");

			
			db.AddInParameter(dbCommand, "FK_Lu_Category", DbType.Decimal, this._FK_Lu_Category);
			
			db.AddInParameter(dbCommand, "FK_Lu_Department", DbType.Decimal, this._FK_Lu_Department);
			
			db.AddInParameter(dbCommand, "FK_Members", DbType.Decimal, this._FK_Members);
			
			if (string.IsNullOrEmpty(this._Find_It_Description))
				db.AddInParameter(dbCommand, "Find_It_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Find_It_Description", DbType.String, this._Find_It_Description);
			
			if (string.IsNullOrEmpty(this._Fixt_it_Description))
				db.AddInParameter(dbCommand, "Fixt_it_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fixt_it_Description", DbType.String, this._Fixt_it_Description);
			
			if (string.IsNullOrEmpty(this._RCLM_Comments))
				db.AddInParameter(dbCommand, "RCLM_Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "RCLM_Comments", DbType.String, this._RCLM_Comments);
			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

			// Execute the query and return the new identity value
			db.ExecuteNonQuery(dbCommand);
            
		}

		/// <summary>
		/// Selects a single record from the Find_it_Fix_it table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Find_it_Fix_it)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_itSelectByPK");

			db.AddInParameter(dbCommand, "PK_Find_it_Fix_it", DbType.Decimal, pK_Find_it_Fix_it);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Find_it_Fix_it table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_itSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Find_it_Fix_it table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_itUpdate");

			
			db.AddInParameter(dbCommand, "PK_Find_it_Fix_it", DbType.Decimal, this._PK_Find_it_Fix_it);
			
			db.AddInParameter(dbCommand, "FK_Lu_Category", DbType.Decimal, this._FK_Lu_Category);
			
			db.AddInParameter(dbCommand, "FK_Lu_Department", DbType.Decimal, this._FK_Lu_Department);
			
			db.AddInParameter(dbCommand, "FK_Members", DbType.Decimal, this._FK_Members);
			
			if (string.IsNullOrEmpty(this._Find_It_Description))
				db.AddInParameter(dbCommand, "Find_It_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Find_It_Description", DbType.String, this._Find_It_Description);
			
			if (string.IsNullOrEmpty(this._Fixt_it_Description))
				db.AddInParameter(dbCommand, "Fixt_it_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fixt_it_Description", DbType.String, this._Fixt_it_Description);
			
			if (string.IsNullOrEmpty(this._RCLM_Comments))
				db.AddInParameter(dbCommand, "RCLM_Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "RCLM_Comments", DbType.String, this._RCLM_Comments);
			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Find_it_Fix_it table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Find_it_Fix_it)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_itDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Find_it_Fix_it", DbType.Decimal, pK_Find_it_Fix_it);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet Find_it_Fix_itSelectByFK_SLT_Meeting(decimal FK_SLT_Meeting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Find_it_Fix_itSelectByFK_SLT_Meeting");

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
