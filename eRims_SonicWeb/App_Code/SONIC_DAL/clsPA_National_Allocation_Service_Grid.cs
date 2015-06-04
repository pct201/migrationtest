using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PA_National_Allocation_Service_Grid table.
	/// </summary>
	public sealed class clsPA_National_Allocation_Service_Grid
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PA_National_Allocation_Service_Grid;
		private decimal? _FK_PA_National_Allocation;
		private decimal? _FK_LU_NPA_Service;
		private decimal? _Service_Amount;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PA_National_Allocation_Service_Grid value.
		/// </summary>
		public decimal? PK_PA_National_Allocation_Service_Grid
		{
			get { return _PK_PA_National_Allocation_Service_Grid; }
			set { _PK_PA_National_Allocation_Service_Grid = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PA_National_Allocation value.
		/// </summary>
		public decimal? FK_PA_National_Allocation
		{
			get { return _FK_PA_National_Allocation; }
			set { _FK_PA_National_Allocation = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_NPA_Service value.
		/// </summary>
		public decimal? FK_LU_NPA_Service
		{
			get { return _FK_LU_NPA_Service; }
			set { _FK_LU_NPA_Service = value; }
		}

		/// <summary>
		/// Gets or sets the Service_Amount value.
		/// </summary>
		public decimal? Service_Amount
		{
			get { return _Service_Amount; }
			set { _Service_Amount = value; }
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
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}

        private string _FieldDescription;

        public string FieldDescription
        {
            get { return _FieldDescription; }
            set { _FieldDescription = value; }
        }
        

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPA_National_Allocation_Service_Grid class with default value.
		/// </summary>
		public clsPA_National_Allocation_Service_Grid() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPA_National_Allocation_Service_Grid class based on Primary Key.
		/// </summary>
		public clsPA_National_Allocation_Service_Grid(decimal pK_PA_National_Allocation_Service_Grid) 
		{
			DataTable dtPA_National_Allocation_Service_Grid = SelectByPK(pK_PA_National_Allocation_Service_Grid).Tables[0];

			if (dtPA_National_Allocation_Service_Grid.Rows.Count == 1)
			{
				 SetValue(dtPA_National_Allocation_Service_Grid.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPA_National_Allocation_Service_Grid class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPA_National_Allocation_Service_Grid) 
		{
				if (drPA_National_Allocation_Service_Grid["PK_PA_National_Allocation_Service_Grid"] == DBNull.Value)
					this._PK_PA_National_Allocation_Service_Grid = null;
				else
					this._PK_PA_National_Allocation_Service_Grid = (decimal?)drPA_National_Allocation_Service_Grid["PK_PA_National_Allocation_Service_Grid"];

				if (drPA_National_Allocation_Service_Grid["FK_PA_National_Allocation"] == DBNull.Value)
					this._FK_PA_National_Allocation = null;
				else
					this._FK_PA_National_Allocation = (decimal?)drPA_National_Allocation_Service_Grid["FK_PA_National_Allocation"];

				if (drPA_National_Allocation_Service_Grid["FK_LU_NPA_Service"] == DBNull.Value)
					this._FK_LU_NPA_Service = null;
				else
					this._FK_LU_NPA_Service = (decimal?)drPA_National_Allocation_Service_Grid["FK_LU_NPA_Service"];

				if (drPA_National_Allocation_Service_Grid["Service_Amount"] == DBNull.Value)
					this._Service_Amount = null;
				else
					this._Service_Amount = (decimal?)drPA_National_Allocation_Service_Grid["Service_Amount"];

				if (drPA_National_Allocation_Service_Grid["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPA_National_Allocation_Service_Grid["Update_Date"];

				if (drPA_National_Allocation_Service_Grid["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPA_National_Allocation_Service_Grid["Updated_By"];

                if (drPA_National_Allocation_Service_Grid["Field_Description"] == DBNull.Value)
                    this._FieldDescription = null;
                else
                    this._FieldDescription = (string)drPA_National_Allocation_Service_Grid["Field_Description"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the PA_National_Allocation_Service_Grid table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_Allocation_Service_GridInsert");

			
			db.AddInParameter(dbCommand, "FK_PA_National_Allocation", DbType.Decimal, this._FK_PA_National_Allocation);
			
			db.AddInParameter(dbCommand, "FK_LU_NPA_Service", DbType.Decimal, this._FK_LU_NPA_Service);
			
			db.AddInParameter(dbCommand, "Service_Amount", DbType.Decimal, this._Service_Amount);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PA_National_Allocation_Service_Grid table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PA_National_Allocation_Service_Grid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_Allocation_Service_GridSelectByPK");

			db.AddInParameter(dbCommand, "PK_PA_National_Allocation_Service_Grid", DbType.Decimal, pK_PA_National_Allocation_Service_Grid);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PA_National_Allocation_Service_Grid table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_Allocation_Service_GridSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PA_National_Allocation_Service_Grid table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_Allocation_Service_GridUpdate");

			
			db.AddInParameter(dbCommand, "PK_PA_National_Allocation_Service_Grid", DbType.Decimal, this._PK_PA_National_Allocation_Service_Grid);
			
			db.AddInParameter(dbCommand, "FK_PA_National_Allocation", DbType.Decimal, this._FK_PA_National_Allocation);
			
			db.AddInParameter(dbCommand, "FK_LU_NPA_Service", DbType.Decimal, this._FK_LU_NPA_Service);
			
			db.AddInParameter(dbCommand, "Service_Amount", DbType.Decimal, this._Service_Amount);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PA_National_Allocation_Service_Grid table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PA_National_Allocation_Service_Grid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_Allocation_Service_GridDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PA_National_Allocation_Service_Grid", DbType.Decimal, pK_PA_National_Allocation_Service_Grid);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the PA_National_Allocation_Service_Grid table by a composite primary key.
        /// </summary>
        public static DataSet LU_NPA_Service()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_NPA_ServiceSelectByActive");

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
