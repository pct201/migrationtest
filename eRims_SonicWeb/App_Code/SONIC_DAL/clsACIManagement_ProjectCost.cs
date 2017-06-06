using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for ACIManagement_ProjectCost table.
	/// </summary>
	public sealed class clsACIManagement_ProjectCost
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ACIManagement_ProjectCost;
		private decimal? _FK_Management;
		private decimal? _FK_LU_EPM_Project_Phase;
		private string _Comments_Description;
		private decimal? _Budget;
		private DateTime? _Date_Budget_Established;
		private decimal? _Estimated_Cost;
		private DateTime? _Date_Estimated_Cost_Derived;
		private decimal? _Original_Estimated_Cost;
		private DateTime? _Date_Original_Estimated_Cost_Derived;
		private decimal? _Actual_Cost;
		private DateTime? _Date_Actual_Cost_Incurred;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private string _Unique_Val;
		private DateTime? _Created_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_ACIManagement_ProjectCost value.
		/// </summary>
		public decimal? PK_ACIManagement_ProjectCost
		{
			get { return _PK_ACIManagement_ProjectCost; }
			set { _PK_ACIManagement_ProjectCost = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Management value.
		/// </summary>
		public decimal? FK_Management
		{
			get { return _FK_Management; }
			set { _FK_Management = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_EPM_Project_Phase value.
		/// </summary>
		public decimal? FK_LU_EPM_Project_Phase
		{
			get { return _FK_LU_EPM_Project_Phase; }
			set { _FK_LU_EPM_Project_Phase = value; }
		}

		/// <summary>
		/// Gets or sets the Comments_Description value.
		/// </summary>
		public string Comments_Description
		{
			get { return _Comments_Description; }
			set { _Comments_Description = value; }
		}

		/// <summary>
		/// Gets or sets the Budget value.
		/// </summary>
		public decimal? Budget
		{
			get { return _Budget; }
			set { _Budget = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Budget_Established value.
		/// </summary>
		public DateTime? Date_Budget_Established
		{
			get { return _Date_Budget_Established; }
			set { _Date_Budget_Established = value; }
		}

		/// <summary>
		/// Gets or sets the Estimated_Cost value.
		/// </summary>
		public decimal? Estimated_Cost
		{
			get { return _Estimated_Cost; }
			set { _Estimated_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Estimated_Cost_Derived value.
		/// </summary>
		public DateTime? Date_Estimated_Cost_Derived
		{
			get { return _Date_Estimated_Cost_Derived; }
			set { _Date_Estimated_Cost_Derived = value; }
		}

		/// <summary>
		/// Gets or sets the Original_Estimated_Cost value.
		/// </summary>
		public decimal? Original_Estimated_Cost
		{
			get { return _Original_Estimated_Cost; }
			set { _Original_Estimated_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Original_Estimated_Cost_Derived value.
		/// </summary>
		public DateTime? Date_Original_Estimated_Cost_Derived
		{
			get { return _Date_Original_Estimated_Cost_Derived; }
			set { _Date_Original_Estimated_Cost_Derived = value; }
		}

		/// <summary>
		/// Gets or sets the Actual_Cost value.
		/// </summary>
		public decimal? Actual_Cost
		{
			get { return _Actual_Cost; }
			set { _Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Actual_Cost_Incurred value.
		/// </summary>
		public DateTime? Date_Actual_Cost_Incurred
		{
			get { return _Date_Actual_Cost_Incurred; }
			set { _Date_Actual_Cost_Incurred = value; }
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

		/// <summary>
		/// Gets or sets the Unique_Val value.
		/// </summary>
		public string Unique_Val
		{
			get { return _Unique_Val; }
			set { _Unique_Val = value; }
		}

		/// <summary>
		/// Gets or sets the Created_Date value.
		/// </summary>
		public DateTime? Created_Date
		{
			get { return _Created_Date; }
			set { _Created_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsACIManagement_ProjectCost class with default value.
		/// </summary>
		public clsACIManagement_ProjectCost() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsACIManagement_ProjectCost class based on Primary Key.
		/// </summary>
		public clsACIManagement_ProjectCost(decimal pK_ACIManagement_ProjectCost) 
		{
			DataTable dtACIManagement_ProjectCost = SelectByPK(pK_ACIManagement_ProjectCost).Tables[0];

			if (dtACIManagement_ProjectCost.Rows.Count == 1)
			{
				 SetValue(dtACIManagement_ProjectCost.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsACIManagement_ProjectCost class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drACIManagement_ProjectCost) 
		{
				if (drACIManagement_ProjectCost["PK_ACIManagement_ProjectCost"] == DBNull.Value)
					this._PK_ACIManagement_ProjectCost = null;
				else
					this._PK_ACIManagement_ProjectCost = (decimal?)drACIManagement_ProjectCost["PK_ACIManagement_ProjectCost"];

				if (drACIManagement_ProjectCost["FK_Management"] == DBNull.Value)
					this._FK_Management = null;
				else
					this._FK_Management = (decimal?)drACIManagement_ProjectCost["FK_Management"];

				if (drACIManagement_ProjectCost["FK_LU_EPM_Project_Phase"] == DBNull.Value)
					this._FK_LU_EPM_Project_Phase = null;
				else
					this._FK_LU_EPM_Project_Phase = (decimal?)drACIManagement_ProjectCost["FK_LU_EPM_Project_Phase"];

				if (drACIManagement_ProjectCost["Comments_Description"] == DBNull.Value)
					this._Comments_Description = null;
				else
					this._Comments_Description = (string)drACIManagement_ProjectCost["Comments_Description"];

				if (drACIManagement_ProjectCost["Budget"] == DBNull.Value)
					this._Budget = null;
				else
					this._Budget = (decimal?)drACIManagement_ProjectCost["Budget"];

				if (drACIManagement_ProjectCost["Date_Budget_Established"] == DBNull.Value)
					this._Date_Budget_Established = null;
				else
					this._Date_Budget_Established = (DateTime?)drACIManagement_ProjectCost["Date_Budget_Established"];

				if (drACIManagement_ProjectCost["Estimated_Cost"] == DBNull.Value)
					this._Estimated_Cost = null;
				else
					this._Estimated_Cost = (decimal?)drACIManagement_ProjectCost["Estimated_Cost"];

				if (drACIManagement_ProjectCost["Date_Estimated_Cost_Derived"] == DBNull.Value)
					this._Date_Estimated_Cost_Derived = null;
				else
					this._Date_Estimated_Cost_Derived = (DateTime?)drACIManagement_ProjectCost["Date_Estimated_Cost_Derived"];

				if (drACIManagement_ProjectCost["Original_Estimated_Cost"] == DBNull.Value)
					this._Original_Estimated_Cost = null;
				else
					this._Original_Estimated_Cost = (decimal?)drACIManagement_ProjectCost["Original_Estimated_Cost"];

				if (drACIManagement_ProjectCost["Date_Original_Estimated_Cost_Derived"] == DBNull.Value)
					this._Date_Original_Estimated_Cost_Derived = null;
				else
					this._Date_Original_Estimated_Cost_Derived = (DateTime?)drACIManagement_ProjectCost["Date_Original_Estimated_Cost_Derived"];

				if (drACIManagement_ProjectCost["Actual_Cost"] == DBNull.Value)
					this._Actual_Cost = null;
				else
					this._Actual_Cost = (decimal?)drACIManagement_ProjectCost["Actual_Cost"];

				if (drACIManagement_ProjectCost["Date_Actual_Cost_Incurred"] == DBNull.Value)
					this._Date_Actual_Cost_Incurred = null;
				else
					this._Date_Actual_Cost_Incurred = (DateTime?)drACIManagement_ProjectCost["Date_Actual_Cost_Incurred"];

				if (drACIManagement_ProjectCost["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drACIManagement_ProjectCost["Updated_By"];

				if (drACIManagement_ProjectCost["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drACIManagement_ProjectCost["Update_Date"];

                //if (drACIManagement_ProjectCost["Unique_Val"] == DBNull.Value)
                //    this._Unique_Val = null;
                //else
                //    this._Unique_Val = (string)drACIManagement_ProjectCost["Unique_Val"];

				if (drACIManagement_ProjectCost["Created_Date"] == DBNull.Value)
					this._Created_Date = null;
				else
					this._Created_Date = (DateTime?)drACIManagement_ProjectCost["Created_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the ACIManagement_ProjectCost table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ACIManagement_ProjectCostInsert");

			
			db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, this._FK_Management);
			
			db.AddInParameter(dbCommand, "FK_LU_EPM_Project_Phase", DbType.Decimal, this._FK_LU_EPM_Project_Phase);
			
			if (string.IsNullOrEmpty(this._Comments_Description))
				db.AddInParameter(dbCommand, "Comments_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments_Description", DbType.String, this._Comments_Description);
			
			db.AddInParameter(dbCommand, "Budget", DbType.Decimal, this._Budget);
			
			db.AddInParameter(dbCommand, "Date_Budget_Established", DbType.DateTime, this._Date_Budget_Established);
			
			db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, this._Estimated_Cost);
			
			db.AddInParameter(dbCommand, "Date_Estimated_Cost_Derived", DbType.DateTime, this._Date_Estimated_Cost_Derived);
			
			db.AddInParameter(dbCommand, "Original_Estimated_Cost", DbType.Decimal, this._Original_Estimated_Cost);
			
			db.AddInParameter(dbCommand, "Date_Original_Estimated_Cost_Derived", DbType.DateTime, this._Date_Original_Estimated_Cost_Derived);
			
			db.AddInParameter(dbCommand, "Actual_Cost", DbType.Decimal, this._Actual_Cost);
			
			db.AddInParameter(dbCommand, "Date_Actual_Cost_Incurred", DbType.DateTime, this._Date_Actual_Cost_Incurred);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
            //if (string.IsNullOrEmpty(this._Unique_Val))
            //    db.AddInParameter(dbCommand, "Unique_Val", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Unique_Val", DbType.String, this._Unique_Val);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the ACIManagement_ProjectCost table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_ACIManagement_ProjectCost)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ACIManagement_ProjectCostSelectByPK");

			db.AddInParameter(dbCommand, "PK_ACIManagement_ProjectCost", DbType.Decimal, pK_ACIManagement_ProjectCost);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ACIManagement_ProjectCost table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ACIManagement_ProjectCostSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the ACIManagement_ProjectCost table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ACIManagement_ProjectCostUpdate");

			
			db.AddInParameter(dbCommand, "PK_ACIManagement_ProjectCost", DbType.Decimal, this._PK_ACIManagement_ProjectCost);
			
			db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, this._FK_Management);
			
			db.AddInParameter(dbCommand, "FK_LU_EPM_Project_Phase", DbType.Decimal, this._FK_LU_EPM_Project_Phase);
			
			if (string.IsNullOrEmpty(this._Comments_Description))
				db.AddInParameter(dbCommand, "Comments_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments_Description", DbType.String, this._Comments_Description);
			
			db.AddInParameter(dbCommand, "Budget", DbType.Decimal, this._Budget);
			
			db.AddInParameter(dbCommand, "Date_Budget_Established", DbType.DateTime, this._Date_Budget_Established);
			
			db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, this._Estimated_Cost);
			
			db.AddInParameter(dbCommand, "Date_Estimated_Cost_Derived", DbType.DateTime, this._Date_Estimated_Cost_Derived);
			
			db.AddInParameter(dbCommand, "Original_Estimated_Cost", DbType.Decimal, this._Original_Estimated_Cost);
			
			db.AddInParameter(dbCommand, "Date_Original_Estimated_Cost_Derived", DbType.DateTime, this._Date_Original_Estimated_Cost_Derived);
			
			db.AddInParameter(dbCommand, "Actual_Cost", DbType.Decimal, this._Actual_Cost);
			
			db.AddInParameter(dbCommand, "Date_Actual_Cost_Incurred", DbType.DateTime, this._Date_Actual_Cost_Incurred);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
            //if (string.IsNullOrEmpty(this._Unique_Val))
            //    db.AddInParameter(dbCommand, "Unique_Val", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Unique_Val", DbType.String, this._Unique_Val);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the ACIManagement_ProjectCost table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ACIManagement_ProjectCost)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ACIManagement_ProjectCostDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ACIManagement_ProjectCost", DbType.Decimal, pK_ACIManagement_ProjectCost);

			db.ExecuteNonQuery(dbCommand);
		}

        public static int GetCostPercentage(decimal PK_ACIManagement_ProjectCost)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACIManagement_Project_Cost_GetCostPercentage");

            db.AddInParameter(dbCommand, "PK_ACIManagement_ProjectCost", DbType.Decimal, PK_ACIManagement_ProjectCost);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }

        public static DataSet SelectByFK(decimal FK_Management)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACIManagemen_ProjectCostSelectByFK");

            db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, FK_Management);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
