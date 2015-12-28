using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_BT_Security_Walk_Responses table.
	/// </summary>
	public sealed class clsSLT_BT_Security_Walk_Responses
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_BT_Security_Walk_Responses;
		private decimal? _FK_SLT_BT_Security_Walk;
		private int? _Year;
		private int? _Month;
		private decimal? _FK_LU_SLT_BT_Security_Walk_Focus_Area;
		private string _Observation_Acceptable;
		private string _What_Needs_To_Be_Done;
		private decimal? _FK_SLT_Members;
		private DateTime? _To_Be_Completed_By;
		private DateTime? _Completed_Date;
		private string _Updated_By;
		private DateTime? _Updated_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_BT_Security_Walk_Responses value.
		/// </summary>
		public decimal? PK_SLT_BT_Security_Walk_Responses
		{
			get { return _PK_SLT_BT_Security_Walk_Responses; }
			set { _PK_SLT_BT_Security_Walk_Responses = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_BT_Security_Walk value.
		/// </summary>
		public decimal? FK_SLT_BT_Security_Walk
		{
			get { return _FK_SLT_BT_Security_Walk; }
			set { _FK_SLT_BT_Security_Walk = value; }
		}

		/// <summary>
		/// Gets or sets the Year value.
		/// </summary>
		public int? Year
		{
			get { return _Year; }
			set { _Year = value; }
		}

		/// <summary>
		/// Gets or sets the Month value.
		/// </summary>
		public int? Month
		{
			get { return _Month; }
			set { _Month = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_SLT_BT_Security_Walk_Focus_Area value.
		/// </summary>
		public decimal? FK_LU_SLT_BT_Security_Walk_Focus_Area
		{
			get { return _FK_LU_SLT_BT_Security_Walk_Focus_Area; }
			set { _FK_LU_SLT_BT_Security_Walk_Focus_Area = value; }
		}

		/// <summary>
		/// Gets or sets the Observation_Acceptable value.
		/// </summary>
		public string Observation_Acceptable
		{
			get { return _Observation_Acceptable; }
			set { _Observation_Acceptable = value; }
		}

		/// <summary>
		/// Gets or sets the What_Needs_To_Be_Done value.
		/// </summary>
		public string What_Needs_To_Be_Done
		{
			get { return _What_Needs_To_Be_Done; }
			set { _What_Needs_To_Be_Done = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_Members value.
		/// </summary>
		public decimal? FK_SLT_Members
		{
			get { return _FK_SLT_Members; }
			set { _FK_SLT_Members = value; }
		}

		/// <summary>
		/// Gets or sets the To_Be_Completed_By value.
		/// </summary>
		public DateTime? To_Be_Completed_By
		{
			get { return _To_Be_Completed_By; }
			set { _To_Be_Completed_By = value; }
		}

		/// <summary>
		/// Gets or sets the Completed_Date value.
		/// </summary>
		public DateTime? Completed_Date
		{
			get { return _Completed_Date; }
			set { _Completed_Date = value; }
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
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Responses class with default value.
		/// </summary>
		public clsSLT_BT_Security_Walk_Responses() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Responses class based on Primary Key.
		/// </summary>
		public clsSLT_BT_Security_Walk_Responses(decimal pK_SLT_BT_Security_Walk_Responses) 
		{
			DataTable dtSLT_BT_Security_Walk_Responses = SelectByPK(pK_SLT_BT_Security_Walk_Responses).Tables[0];

			if (dtSLT_BT_Security_Walk_Responses.Rows.Count == 1)
			{
				 SetValue(dtSLT_BT_Security_Walk_Responses.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Responses class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_BT_Security_Walk_Responses) 
		{
				if (drSLT_BT_Security_Walk_Responses["PK_SLT_BT_Security_Walk_Responses"] == DBNull.Value)
					this._PK_SLT_BT_Security_Walk_Responses = null;
				else
					this._PK_SLT_BT_Security_Walk_Responses = (decimal?)drSLT_BT_Security_Walk_Responses["PK_SLT_BT_Security_Walk_Responses"];

				if (drSLT_BT_Security_Walk_Responses["FK_SLT_BT_Security_Walk"] == DBNull.Value)
					this._FK_SLT_BT_Security_Walk = null;
				else
					this._FK_SLT_BT_Security_Walk = (decimal?)drSLT_BT_Security_Walk_Responses["FK_SLT_BT_Security_Walk"];

				if (drSLT_BT_Security_Walk_Responses["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drSLT_BT_Security_Walk_Responses["Year"];

				if (drSLT_BT_Security_Walk_Responses["Month"] == DBNull.Value)
					this._Month = null;
				else
					this._Month = (int?)drSLT_BT_Security_Walk_Responses["Month"];

				if (drSLT_BT_Security_Walk_Responses["FK_LU_SLT_BT_Security_Walk_Focus_Area"] == DBNull.Value)
					this._FK_LU_SLT_BT_Security_Walk_Focus_Area = null;
				else
					this._FK_LU_SLT_BT_Security_Walk_Focus_Area = (decimal?)drSLT_BT_Security_Walk_Responses["FK_LU_SLT_BT_Security_Walk_Focus_Area"];

				if (drSLT_BT_Security_Walk_Responses["Observation_Acceptable"] == DBNull.Value)
					this._Observation_Acceptable = null;
				else
					this._Observation_Acceptable = (string)drSLT_BT_Security_Walk_Responses["Observation_Acceptable"];

				if (drSLT_BT_Security_Walk_Responses["What_Needs_To_Be_Done"] == DBNull.Value)
					this._What_Needs_To_Be_Done = null;
				else
					this._What_Needs_To_Be_Done = (string)drSLT_BT_Security_Walk_Responses["What_Needs_To_Be_Done"];

				if (drSLT_BT_Security_Walk_Responses["FK_SLT_Members"] == DBNull.Value)
					this._FK_SLT_Members = null;
				else
					this._FK_SLT_Members = (decimal?)drSLT_BT_Security_Walk_Responses["FK_SLT_Members"];

				if (drSLT_BT_Security_Walk_Responses["To_Be_Completed_By"] == DBNull.Value)
					this._To_Be_Completed_By = null;
				else
					this._To_Be_Completed_By = (DateTime?)drSLT_BT_Security_Walk_Responses["To_Be_Completed_By"];

				if (drSLT_BT_Security_Walk_Responses["Completed_Date"] == DBNull.Value)
					this._Completed_Date = null;
				else
					this._Completed_Date = (DateTime?)drSLT_BT_Security_Walk_Responses["Completed_Date"];

				if (drSLT_BT_Security_Walk_Responses["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSLT_BT_Security_Walk_Responses["Updated_By"];

				if (drSLT_BT_Security_Walk_Responses["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drSLT_BT_Security_Walk_Responses["Updated_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_BT_Security_Walk_Responses table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_ResponsesInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk", DbType.Decimal, this._FK_SLT_BT_Security_Walk);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Month", DbType.Int32, this._Month);
			
			db.AddInParameter(dbCommand, "FK_LU_SLT_BT_Security_Walk_Focus_Area", DbType.Decimal, this._FK_LU_SLT_BT_Security_Walk_Focus_Area);
			
			if (string.IsNullOrEmpty(this._Observation_Acceptable))
				db.AddInParameter(dbCommand, "Observation_Acceptable", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Observation_Acceptable", DbType.String, this._Observation_Acceptable);
			
			if (string.IsNullOrEmpty(this._What_Needs_To_Be_Done))
				db.AddInParameter(dbCommand, "What_Needs_To_Be_Done", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "What_Needs_To_Be_Done", DbType.String, this._What_Needs_To_Be_Done);
			
			db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);
			
			db.AddInParameter(dbCommand, "To_Be_Completed_By", DbType.DateTime, this._To_Be_Completed_By);
			
			db.AddInParameter(dbCommand, "Completed_Date", DbType.DateTime, this._Completed_Date);
			
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
		/// Selects a single record from the SLT_BT_Security_Walk_Responses table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_BT_Security_Walk_Responses)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_ResponsesSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Responses", DbType.Decimal, pK_SLT_BT_Security_Walk_Responses);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_BT_Security_Walk_Responses table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_ResponsesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_BT_Security_Walk_Responses table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_ResponsesUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Responses", DbType.Decimal, this._PK_SLT_BT_Security_Walk_Responses);
			
			db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk", DbType.Decimal, this._FK_SLT_BT_Security_Walk);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Month", DbType.Int32, this._Month);
			
			db.AddInParameter(dbCommand, "FK_LU_SLT_BT_Security_Walk_Focus_Area", DbType.Decimal, this._FK_LU_SLT_BT_Security_Walk_Focus_Area);
			
			if (string.IsNullOrEmpty(this._Observation_Acceptable))
				db.AddInParameter(dbCommand, "Observation_Acceptable", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Observation_Acceptable", DbType.String, this._Observation_Acceptable);
			
			if (string.IsNullOrEmpty(this._What_Needs_To_Be_Done))
				db.AddInParameter(dbCommand, "What_Needs_To_Be_Done", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "What_Needs_To_Be_Done", DbType.String, this._What_Needs_To_Be_Done);
			
			db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);
			
			db.AddInParameter(dbCommand, "To_Be_Completed_By", DbType.DateTime, this._To_Be_Completed_By);
			
			db.AddInParameter(dbCommand, "Completed_Date", DbType.DateTime, this._Completed_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_BT_Security_Walk_Responses table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_BT_Security_Walk_Responses)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_ResponsesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Responses", DbType.Decimal, pK_SLT_BT_Security_Walk_Responses);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
