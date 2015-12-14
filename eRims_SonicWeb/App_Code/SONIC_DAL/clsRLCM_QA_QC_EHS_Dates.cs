using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RLCM_QA_QC_EHS_Dates table.
	/// </summary>
	public sealed class clsRLCM_QA_QC_EHS_Dates
	{

		#region Private variables used to hold the property values

		private decimal? _PK_RLCM_QA_QC_EHS_Dates;
		private decimal? _FK_RLCM_QA_QC;
		private decimal? _FK_LU_Location;
		private string _Category;
		private string _Type;
		private DateTime? _Date;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_RLCM_QA_QC_EHS_Dates value.
		/// </summary>
		public decimal? PK_RLCM_QA_QC_EHS_Dates
		{
			get { return _PK_RLCM_QA_QC_EHS_Dates; }
			set { _PK_RLCM_QA_QC_EHS_Dates = value; }
		}

		/// <summary>
		/// Gets or sets the FK_RLCM_QA_QC value.
		/// </summary>
		public decimal? FK_RLCM_QA_QC
		{
			get { return _FK_RLCM_QA_QC; }
			set { _FK_RLCM_QA_QC = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Location value.
		/// </summary>
		public decimal? FK_LU_Location
		{
			get { return _FK_LU_Location; }
			set { _FK_LU_Location = value; }
		}

		/// <summary>
		/// Gets or sets the Category value.
		/// </summary>
		public string Category
		{
			get { return _Category; }
			set { _Category = value; }
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
		/// Gets or sets the Date value.
		/// </summary>
		public DateTime? Date
		{
			get { return _Date; }
			set { _Date = value; }
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
		/// Initializes a new instance of the clsRLCM_QA_QC_EHS_Dates class with default value.
		/// </summary>
		public clsRLCM_QA_QC_EHS_Dates() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsRLCM_QA_QC_EHS_Dates class based on Primary Key.
		/// </summary>
		public clsRLCM_QA_QC_EHS_Dates(decimal pK_RLCM_QA_QC_EHS_Dates) 
		{
			DataTable dtRLCM_QA_QC_EHS_Dates = SelectByPK(pK_RLCM_QA_QC_EHS_Dates).Tables[0];

			if (dtRLCM_QA_QC_EHS_Dates.Rows.Count == 1)
			{
				 SetValue(dtRLCM_QA_QC_EHS_Dates.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsRLCM_QA_QC_EHS_Dates class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drRLCM_QA_QC_EHS_Dates) 
		{
				if (drRLCM_QA_QC_EHS_Dates["PK_RLCM_QA_QC_EHS_Dates"] == DBNull.Value)
					this._PK_RLCM_QA_QC_EHS_Dates = null;
				else
					this._PK_RLCM_QA_QC_EHS_Dates = (decimal?)drRLCM_QA_QC_EHS_Dates["PK_RLCM_QA_QC_EHS_Dates"];

				if (drRLCM_QA_QC_EHS_Dates["FK_RLCM_QA_QC"] == DBNull.Value)
					this._FK_RLCM_QA_QC = null;
				else
					this._FK_RLCM_QA_QC = (decimal?)drRLCM_QA_QC_EHS_Dates["FK_RLCM_QA_QC"];

				if (drRLCM_QA_QC_EHS_Dates["FK_LU_Location"] == DBNull.Value)
					this._FK_LU_Location = null;
				else
					this._FK_LU_Location = (decimal?)drRLCM_QA_QC_EHS_Dates["FK_LU_Location"];

				if (drRLCM_QA_QC_EHS_Dates["Category"] == DBNull.Value)
					this._Category = null;
				else
					this._Category = (string)drRLCM_QA_QC_EHS_Dates["Category"];

				if (drRLCM_QA_QC_EHS_Dates["Type"] == DBNull.Value)
					this._Type = null;
				else
					this._Type = (string)drRLCM_QA_QC_EHS_Dates["Type"];

				if (drRLCM_QA_QC_EHS_Dates["Date"] == DBNull.Value)
					this._Date = null;
				else
					this._Date = (DateTime?)drRLCM_QA_QC_EHS_Dates["Date"];

				if (drRLCM_QA_QC_EHS_Dates["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drRLCM_QA_QC_EHS_Dates["Updated_By"];

				if (drRLCM_QA_QC_EHS_Dates["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drRLCM_QA_QC_EHS_Dates["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the RLCM_QA_QC_EHS_Dates table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QC_EHS_DatesInsert");

			
			db.AddInParameter(dbCommand, "FK_RLCM_QA_QC", DbType.Decimal, this._FK_RLCM_QA_QC);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			if (string.IsNullOrEmpty(this._Category))
				db.AddInParameter(dbCommand, "Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Category", DbType.String, this._Category);
			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
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
		/// Selects a single record from the RLCM_QA_QC_EHS_Dates table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_RLCM_QA_QC_EHS_Dates)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QC_EHS_DatesSelectByPK");

			db.AddInParameter(dbCommand, "PK_RLCM_QA_QC_EHS_Dates", DbType.Decimal, pK_RLCM_QA_QC_EHS_Dates);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the RLCM_QA_QC_EHS_Dates table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QC_EHS_DatesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the RLCM_QA_QC_EHS_Dates table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QC_EHS_DatesUpdate");

			
			db.AddInParameter(dbCommand, "PK_RLCM_QA_QC_EHS_Dates", DbType.Decimal, this._PK_RLCM_QA_QC_EHS_Dates);
			
			db.AddInParameter(dbCommand, "FK_RLCM_QA_QC", DbType.Decimal, this._FK_RLCM_QA_QC);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			if (string.IsNullOrEmpty(this._Category))
				db.AddInParameter(dbCommand, "Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Category", DbType.String, this._Category);
			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the RLCM_QA_QC_EHS_Dates table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_RLCM_QA_QC_EHS_Dates)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QC_EHS_DatesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_RLCM_QA_QC_EHS_Dates", DbType.Decimal, pK_RLCM_QA_QC_EHS_Dates);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
