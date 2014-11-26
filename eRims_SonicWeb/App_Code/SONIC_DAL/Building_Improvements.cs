using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Building_Improvements table.
	/// </summary>
	public sealed class Building_Improvements
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Building_Improvements;
		private decimal? _FK_Building;
		private string _Improvement_Description;
		private string _Service_Capacity_Increase;
		private decimal? _Revised_Square_Footage_Sales;
		private decimal? _Revised_Square_Footage_Service;
		private decimal? _Revised_Square_Footage_Parts;
		private decimal? _Revised_Square_Footage_Other;
		private decimal? _Improvement_Value;
		private DateTime? _Completion_Date;
		private string _Updated_By;
		private DateTime? _Updated_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Building_Improvements value.
		/// </summary>
		public decimal? PK_Building_Improvements
		{
			get { return _PK_Building_Improvements; }
			set { _PK_Building_Improvements = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Building value.
		/// </summary>
		public decimal? FK_Building
		{
			get { return _FK_Building; }
			set { _FK_Building = value; }
		}

		/// <summary>
		/// Gets or sets the Improvement_Description value.
		/// </summary>
		public string Improvement_Description
		{
			get { return _Improvement_Description; }
			set { _Improvement_Description = value; }
		}

		/// <summary>
		/// Gets or sets the Service_Capacity_Increase value.
		/// </summary>
		public string Service_Capacity_Increase
		{
			get { return _Service_Capacity_Increase; }
			set { _Service_Capacity_Increase = value; }
		}

		/// <summary>
		/// Gets or sets the Revised_Square_Footage_Sales value.
		/// </summary>
		public decimal? Revised_Square_Footage_Sales
		{
			get { return _Revised_Square_Footage_Sales; }
			set { _Revised_Square_Footage_Sales = value; }
		}

		/// <summary>
		/// Gets or sets the Revised_Square_Footage_Service value.
		/// </summary>
		public decimal? Revised_Square_Footage_Service
		{
			get { return _Revised_Square_Footage_Service; }
			set { _Revised_Square_Footage_Service = value; }
		}

		/// <summary>
		/// Gets or sets the Revised_Square_Footage_Parts value.
		/// </summary>
		public decimal? Revised_Square_Footage_Parts
		{
			get { return _Revised_Square_Footage_Parts; }
			set { _Revised_Square_Footage_Parts = value; }
		}

		/// <summary>
		/// Gets or sets the Revised_Square_Footage_Other value.
		/// </summary>
		public decimal? Revised_Square_Footage_Other
		{
			get { return _Revised_Square_Footage_Other; }
			set { _Revised_Square_Footage_Other = value; }
		}

		/// <summary>
		/// Gets or sets the Improvement_Value value.
		/// </summary>
		public decimal? Improvement_Value
		{
			get { return _Improvement_Value; }
			set { _Improvement_Value = value; }
		}

		/// <summary>
		/// Gets or sets the Completion_Date value.
		/// </summary>
		public DateTime? Completion_Date
		{
			get { return _Completion_Date; }
			set { _Completion_Date = value; }
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
		/// Initializes a new instance of the Building_Improvements class with default value.
		/// </summary>
		public Building_Improvements() 
		{

			this._PK_Building_Improvements = null;
			this._FK_Building = null;
			this._Improvement_Description = null;
			this._Service_Capacity_Increase = null;
			this._Revised_Square_Footage_Sales = null;
			this._Revised_Square_Footage_Service = null;
			this._Revised_Square_Footage_Parts = null;
			this._Revised_Square_Footage_Other = null;
			this._Improvement_Value = null;
			this._Completion_Date = null;
			this._Updated_By = null;
			this._Updated_Date = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Building_Improvements class based on Primary Key.
		/// </summary>
		public Building_Improvements(decimal pK_Building_Improvements) 
		{
			DataTable dtBuilding_Improvements = SelectByPK(pK_Building_Improvements).Tables[0];

			if (dtBuilding_Improvements.Rows.Count == 1)
			{
				DataRow drBuilding_Improvements = dtBuilding_Improvements.Rows[0];
				if (drBuilding_Improvements["PK_Building_Improvements"] == DBNull.Value)
					this._PK_Building_Improvements = null;
				else
					this._PK_Building_Improvements = (decimal?)drBuilding_Improvements["PK_Building_Improvements"];

				if (drBuilding_Improvements["FK_Building"] == DBNull.Value)
					this._FK_Building = null;
				else
					this._FK_Building = (decimal?)drBuilding_Improvements["FK_Building"];

				if (drBuilding_Improvements["Improvement_Description"] == DBNull.Value)
					this._Improvement_Description = null;
				else
					this._Improvement_Description = (string)drBuilding_Improvements["Improvement_Description"];

				if (drBuilding_Improvements["Service_Capacity_Increase"] == DBNull.Value)
					this._Service_Capacity_Increase = null;
				else
					this._Service_Capacity_Increase = (string)drBuilding_Improvements["Service_Capacity_Increase"];

				if (drBuilding_Improvements["Revised_Square_Footage_Sales"] == DBNull.Value)
					this._Revised_Square_Footage_Sales = null;
				else
					this._Revised_Square_Footage_Sales = (decimal?)drBuilding_Improvements["Revised_Square_Footage_Sales"];

				if (drBuilding_Improvements["Revised_Square_Footage_Service"] == DBNull.Value)
					this._Revised_Square_Footage_Service = null;
				else
					this._Revised_Square_Footage_Service = (decimal?)drBuilding_Improvements["Revised_Square_Footage_Service"];

				if (drBuilding_Improvements["Revised_Square_Footage_Parts"] == DBNull.Value)
					this._Revised_Square_Footage_Parts = null;
				else
					this._Revised_Square_Footage_Parts = (decimal?)drBuilding_Improvements["Revised_Square_Footage_Parts"];

				if (drBuilding_Improvements["Revised_Square_Footage_Other"] == DBNull.Value)
					this._Revised_Square_Footage_Other = null;
				else
					this._Revised_Square_Footage_Other = (decimal?)drBuilding_Improvements["Revised_Square_Footage_Other"];

				if (drBuilding_Improvements["Improvement_Value"] == DBNull.Value)
					this._Improvement_Value = null;
				else
					this._Improvement_Value = (decimal?)drBuilding_Improvements["Improvement_Value"];

				if (drBuilding_Improvements["Completion_Date"] == DBNull.Value)
					this._Completion_Date = null;
				else
					this._Completion_Date = (DateTime?)drBuilding_Improvements["Completion_Date"];

				if (drBuilding_Improvements["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drBuilding_Improvements["Updated_By"];

				if (drBuilding_Improvements["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drBuilding_Improvements["Updated_Date"];

			}
			else
			{
				this._PK_Building_Improvements = null;
				this._FK_Building = null;
				this._Improvement_Description = null;
				this._Service_Capacity_Increase = null;
				this._Revised_Square_Footage_Sales = null;
				this._Revised_Square_Footage_Service = null;
				this._Revised_Square_Footage_Parts = null;
				this._Revised_Square_Footage_Other = null;
				this._Improvement_Value = null;
				this._Completion_Date = null;
				this._Updated_By = null;
				this._Updated_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Building_Improvements table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsInsert");

			
			db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);
			
			if (string.IsNullOrEmpty(this._Improvement_Description))
				db.AddInParameter(dbCommand, "Improvement_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Improvement_Description", DbType.String, this._Improvement_Description);
			
			if (string.IsNullOrEmpty(this._Service_Capacity_Increase))
				db.AddInParameter(dbCommand, "Service_Capacity_Increase", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Service_Capacity_Increase", DbType.String, this._Service_Capacity_Increase);
			
			db.AddInParameter(dbCommand, "Revised_Square_Footage_Sales", DbType.Decimal, this._Revised_Square_Footage_Sales);
			
			db.AddInParameter(dbCommand, "Revised_Square_Footage_Service", DbType.Decimal, this._Revised_Square_Footage_Service);
			
			db.AddInParameter(dbCommand, "Revised_Square_Footage_Parts", DbType.Decimal, this._Revised_Square_Footage_Parts);
			
			db.AddInParameter(dbCommand, "Revised_Square_Footage_Other", DbType.Decimal, this._Revised_Square_Footage_Other);
			
			db.AddInParameter(dbCommand, "Improvement_Value", DbType.Decimal, this._Improvement_Value);
			
			db.AddInParameter(dbCommand, "Completion_Date", DbType.DateTime, this._Completion_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Building_Improvements table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_Building_Improvements)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Building_Improvements", DbType.Decimal, pK_Building_Improvements);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Building_Improvements table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Building_Improvements table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Building_Improvements", DbType.Decimal, this._PK_Building_Improvements);
			
			db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);
			
			if (string.IsNullOrEmpty(this._Improvement_Description))
				db.AddInParameter(dbCommand, "Improvement_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Improvement_Description", DbType.String, this._Improvement_Description);
			
			if (string.IsNullOrEmpty(this._Service_Capacity_Increase))
				db.AddInParameter(dbCommand, "Service_Capacity_Increase", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Service_Capacity_Increase", DbType.String, this._Service_Capacity_Increase);
			
			db.AddInParameter(dbCommand, "Revised_Square_Footage_Sales", DbType.Decimal, this._Revised_Square_Footage_Sales);
			
			db.AddInParameter(dbCommand, "Revised_Square_Footage_Service", DbType.Decimal, this._Revised_Square_Footage_Service);
			
			db.AddInParameter(dbCommand, "Revised_Square_Footage_Parts", DbType.Decimal, this._Revised_Square_Footage_Parts);
			
			db.AddInParameter(dbCommand, "Revised_Square_Footage_Other", DbType.Decimal, this._Revised_Square_Footage_Other);
			
			db.AddInParameter(dbCommand, "Improvement_Value", DbType.Decimal, this._Improvement_Value);
			
			db.AddInParameter(dbCommand, "Completion_Date", DbType.DateTime, this._Completion_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Building_Improvements table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Building_Improvements)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Building_Improvements", DbType.Decimal, pK_Building_Improvements);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK(decimal fk_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, fk_Building);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
