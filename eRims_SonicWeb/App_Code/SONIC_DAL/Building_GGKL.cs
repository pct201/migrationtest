using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Building_GGKL table.
	/// </summary>
	public sealed class Building_GGKL
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Building_GGKL;
		private decimal? _FK_Building_Id;
		private DateTime? _Date;
		private int? _Operators_With_Demos;
		private int? _Operators_Without_Demos;
		private int? _Non_Employee_Demos;
		private int? _All_Other_Associates;
		private int? _Dealer_Plates;
		private int? _Associates_Work_On_Vehicles;
		private string _Notes;
		private int? _Total;
		private decimal? _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Building_GGKL value.
		/// </summary>
		public decimal? PK_Building_GGKL
		{
			get { return _PK_Building_GGKL; }
			set { _PK_Building_GGKL = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Building_Id value.
		/// </summary>
		public decimal? FK_Building_Id
		{
			get { return _FK_Building_Id; }
			set { _FK_Building_Id = value; }
		}

		/// <summary>
		/// Gets or sets the Date value.
		/// </summary>
		public DateTime? Date
		{
			get { return _Date; }
			set { _Date = value; }
		}

		/// <summary>
		/// Gets or sets the Operators_With_Demos value.
		/// </summary>
		public int? Operators_With_Demos
		{
			get { return _Operators_With_Demos; }
			set { _Operators_With_Demos = value; }
		}

		/// <summary>
		/// Gets or sets the Operators_Without_Demos value.
		/// </summary>
		public int? Operators_Without_Demos
		{
			get { return _Operators_Without_Demos; }
			set { _Operators_Without_Demos = value; }
		}

		/// <summary>
		/// Gets or sets the Non_Employee_Demos value.
		/// </summary>
		public int? Non_Employee_Demos
		{
			get { return _Non_Employee_Demos; }
			set { _Non_Employee_Demos = value; }
		}

		/// <summary>
		/// Gets or sets the All_Other_Associates value.
		/// </summary>
		public int? All_Other_Associates
		{
			get { return _All_Other_Associates; }
			set { _All_Other_Associates = value; }
		}

		/// <summary>
		/// Gets or sets the Dealer_Plates value.
		/// </summary>
		public int? Dealer_Plates
		{
			get { return _Dealer_Plates; }
			set { _Dealer_Plates = value; }
		}

		/// <summary>
		/// Gets or sets the Associates_Work_On_Vehicles value.
		/// </summary>
		public int? Associates_Work_On_Vehicles
		{
			get { return _Associates_Work_On_Vehicles; }
			set { _Associates_Work_On_Vehicles = value; }
		}

		/// <summary>
		/// Gets or sets the Notes value.
		/// </summary>
		public string Notes
		{
			get { return _Notes; }
			set { _Notes = value; }
		}

		/// <summary>
		/// Gets or sets the Total value.
		/// </summary>
		public int? Total
		{
			get { return _Total; }
			set { _Total = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public decimal? Updated_By
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
		/// Initializes a new instance of the Building_GGKL class with default value.
		/// </summary>
		public Building_GGKL() 
		{

			this._PK_Building_GGKL = null;
			this._FK_Building_Id = null;
			this._Date = null;
			this._Operators_With_Demos = null;
			this._Operators_Without_Demos = null;
			this._Non_Employee_Demos = null;
			this._All_Other_Associates = null;
			this._Dealer_Plates = null;
			this._Associates_Work_On_Vehicles = null;
			this._Notes = null;
			this._Total = null;
			this._Updated_By = null;
			this._Update_Date = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Building_GGKL class based on Primary Key.
		/// </summary>
		public Building_GGKL(decimal pK_Building_GGKL) 
		{
			DataTable dtBuilding_GGKL = SelectByPK(pK_Building_GGKL).Tables[0];

			if (dtBuilding_GGKL.Rows.Count == 1)
			{
				DataRow drBuilding_GGKL = dtBuilding_GGKL.Rows[0];
				if (drBuilding_GGKL["PK_Building_GGKL"] == DBNull.Value)
					this._PK_Building_GGKL = null;
				else
					this._PK_Building_GGKL = (decimal?)drBuilding_GGKL["PK_Building_GGKL"];

				if (drBuilding_GGKL["FK_Building_Id"] == DBNull.Value)
					this._FK_Building_Id = null;
				else
					this._FK_Building_Id = (decimal?)drBuilding_GGKL["FK_Building_Id"];

				if (drBuilding_GGKL["Date"] == DBNull.Value)
					this._Date = null;
				else
					this._Date = (DateTime?)drBuilding_GGKL["Date"];

				if (drBuilding_GGKL["Operators_With_Demos"] == DBNull.Value)
					this._Operators_With_Demos = null;
				else
					this._Operators_With_Demos = (int?)drBuilding_GGKL["Operators_With_Demos"];

				if (drBuilding_GGKL["Operators_Without_Demos"] == DBNull.Value)
					this._Operators_Without_Demos = null;
				else
					this._Operators_Without_Demos = (int?)drBuilding_GGKL["Operators_Without_Demos"];

				if (drBuilding_GGKL["Non_Employee_Demos"] == DBNull.Value)
					this._Non_Employee_Demos = null;
				else
					this._Non_Employee_Demos = (int?)drBuilding_GGKL["Non_Employee_Demos"];

				if (drBuilding_GGKL["All_Other_Associates"] == DBNull.Value)
					this._All_Other_Associates = null;
				else
					this._All_Other_Associates = (int?)drBuilding_GGKL["All_Other_Associates"];

				if (drBuilding_GGKL["Dealer_Plates"] == DBNull.Value)
					this._Dealer_Plates = null;
				else
					this._Dealer_Plates = (int?)drBuilding_GGKL["Dealer_Plates"];

				if (drBuilding_GGKL["Associates_Work_On_Vehicles"] == DBNull.Value)
					this._Associates_Work_On_Vehicles = null;
				else
					this._Associates_Work_On_Vehicles = (int?)drBuilding_GGKL["Associates_Work_On_Vehicles"];

				if (drBuilding_GGKL["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drBuilding_GGKL["Notes"];

				if (drBuilding_GGKL["Total"] == DBNull.Value)
					this._Total = null;
				else
					this._Total = (int?)drBuilding_GGKL["Total"];

				if (drBuilding_GGKL["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (decimal?)drBuilding_GGKL["Updated_By"];

				if (drBuilding_GGKL["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drBuilding_GGKL["Update_Date"];

			}
			else
			{
				this._PK_Building_GGKL = null;
				this._FK_Building_Id = null;
				this._Date = null;
				this._Operators_With_Demos = null;
				this._Operators_Without_Demos = null;
				this._Non_Employee_Demos = null;
				this._All_Other_Associates = null;
				this._Dealer_Plates = null;
				this._Associates_Work_On_Vehicles = null;
				this._Notes = null;
				this._Total = null;
				this._Updated_By = null;
				this._Update_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Building_GGKL table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_GGKLInsert");

			
			db.AddInParameter(dbCommand, "FK_Building_Id", DbType.Decimal, this._FK_Building_Id);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			db.AddInParameter(dbCommand, "Operators_With_Demos", DbType.Int32, this._Operators_With_Demos);
			
			db.AddInParameter(dbCommand, "Operators_Without_Demos", DbType.Int32, this._Operators_Without_Demos);
			
			db.AddInParameter(dbCommand, "Non_Employee_Demos", DbType.Int32, this._Non_Employee_Demos);
			
			db.AddInParameter(dbCommand, "All_Other_Associates", DbType.Int32, this._All_Other_Associates);
			
			db.AddInParameter(dbCommand, "Dealer_Plates", DbType.Int32, this._Dealer_Plates);
			
			db.AddInParameter(dbCommand, "Associates_Work_On_Vehicles", DbType.Int32, this._Associates_Work_On_Vehicles);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			db.AddInParameter(dbCommand, "Total", DbType.Int32, this._Total);
			
			db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Building_GGKL table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_Building_GGKL)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_GGKLSelectByPK");

			db.AddInParameter(dbCommand, "PK_Building_GGKL", DbType.Decimal, pK_Building_GGKL);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Building_GGKL table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_GGKLSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Building_GGKL table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_GGKLUpdate");

			
			db.AddInParameter(dbCommand, "PK_Building_GGKL", DbType.Decimal, this._PK_Building_GGKL);
			
			db.AddInParameter(dbCommand, "FK_Building_Id", DbType.Decimal, this._FK_Building_Id);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			db.AddInParameter(dbCommand, "Operators_With_Demos", DbType.Int32, this._Operators_With_Demos);
			
			db.AddInParameter(dbCommand, "Operators_Without_Demos", DbType.Int32, this._Operators_Without_Demos);
			
			db.AddInParameter(dbCommand, "Non_Employee_Demos", DbType.Int32, this._Non_Employee_Demos);
			
			db.AddInParameter(dbCommand, "All_Other_Associates", DbType.Int32, this._All_Other_Associates);
			
			db.AddInParameter(dbCommand, "Dealer_Plates", DbType.Int32, this._Dealer_Plates);
			
			db.AddInParameter(dbCommand, "Associates_Work_On_Vehicles", DbType.Int32, this._Associates_Work_On_Vehicles);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			db.AddInParameter(dbCommand, "Total", DbType.Int32, this._Total);
			
			db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Building_GGKL table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Building_GGKL)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_GGKLDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Building_GGKL", DbType.Decimal, pK_Building_GGKL);

			db.ExecuteNonQuery(dbCommand);
		}


        public static DataSet SelectByFK(decimal fK_Building_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_GGKLSelectByBuildingID");

            db.AddInParameter(dbCommand, "FK_Building_Id", DbType.Decimal, fK_Building_Id);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
