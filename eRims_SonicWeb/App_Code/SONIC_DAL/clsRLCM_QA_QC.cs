using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RLCM_QA_QC table.
	/// </summary>
	public sealed class clsRLCM_QA_QC
	{

		#region Private variables used to hold the property values

		private decimal? _PK_RLCM_QA_QC;
		private int? _Year;
		private int? _Month;
		private decimal? _FK_Employee;
		private string _Module;
		private string _System;
		private string _Task;
		private string _Category;
		private string _Number;
		private string _Hyperlink;
		private bool? _Status;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_RLCM_QA_QC value.
		/// </summary>
		public decimal? PK_RLCM_QA_QC
		{
			get { return _PK_RLCM_QA_QC; }
			set { _PK_RLCM_QA_QC = value; }
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
		/// Gets or sets the FK_Employee value.
		/// </summary>
		public decimal? FK_Employee
		{
			get { return _FK_Employee; }
			set { _FK_Employee = value; }
		}

		/// <summary>
		/// Gets or sets the Module value.
		/// </summary>
		public string Module
		{
			get { return _Module; }
			set { _Module = value; }
		}

		/// <summary>
		/// Gets or sets the System value.
		/// </summary>
		public string System
		{
			get { return _System; }
			set { _System = value; }
		}

		/// <summary>
		/// Gets or sets the Task value.
		/// </summary>
		public string Task
		{
			get { return _Task; }
			set { _Task = value; }
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
		/// Gets or sets the Number value.
		/// </summary>
		public string Number
		{
			get { return _Number; }
			set { _Number = value; }
		}

		/// <summary>
		/// Gets or sets the Hyperlink value.
		/// </summary>
		public string Hyperlink
		{
			get { return _Hyperlink; }
			set { _Hyperlink = value; }
		}

		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public bool? Status
		{
			get { return _Status; }
			set { _Status = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsRLCM_QA_QC class with default value.
		/// </summary>
		public clsRLCM_QA_QC() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsRLCM_QA_QC class based on Primary Key.
		/// </summary>
		public clsRLCM_QA_QC(decimal pK_RLCM_QA_QC) 
		{
			DataTable dtRLCM_QA_QC = SelectByPK(pK_RLCM_QA_QC).Tables[0];

			if (dtRLCM_QA_QC.Rows.Count == 1)
			{
				 SetValue(dtRLCM_QA_QC.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsRLCM_QA_QC class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drRLCM_QA_QC) 
		{
				if (drRLCM_QA_QC["PK_RLCM_QA_QC"] == DBNull.Value)
					this._PK_RLCM_QA_QC = null;
				else
					this._PK_RLCM_QA_QC = (decimal?)drRLCM_QA_QC["PK_RLCM_QA_QC"];

				if (drRLCM_QA_QC["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drRLCM_QA_QC["Year"];

				if (drRLCM_QA_QC["Month"] == DBNull.Value)
					this._Month = null;
				else
					this._Month = (int?)drRLCM_QA_QC["Month"];

				if (drRLCM_QA_QC["FK_Employee"] == DBNull.Value)
					this._FK_Employee = null;
				else
					this._FK_Employee = (decimal?)drRLCM_QA_QC["FK_Employee"];

				if (drRLCM_QA_QC["Module"] == DBNull.Value)
					this._Module = null;
				else
					this._Module = (string)drRLCM_QA_QC["Module"];

				if (drRLCM_QA_QC["System"] == DBNull.Value)
					this._System = null;
				else
					this._System = (string)drRLCM_QA_QC["System"];

				if (drRLCM_QA_QC["Task"] == DBNull.Value)
					this._Task = null;
				else
					this._Task = (string)drRLCM_QA_QC["Task"];

				if (drRLCM_QA_QC["Category"] == DBNull.Value)
					this._Category = null;
				else
					this._Category = (string)drRLCM_QA_QC["Category"];

				if (drRLCM_QA_QC["Number"] == DBNull.Value)
					this._Number = null;
				else
					this._Number = (string)drRLCM_QA_QC["Number"];

				if (drRLCM_QA_QC["Hyperlink"] == DBNull.Value)
					this._Hyperlink = null;
				else
					this._Hyperlink = (string)drRLCM_QA_QC["Hyperlink"];

				if (drRLCM_QA_QC["Status"] == DBNull.Value)
					this._Status = null;
				else
					this._Status = (bool?)drRLCM_QA_QC["Status"];

				if (drRLCM_QA_QC["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drRLCM_QA_QC["Update_Date"];

				if (drRLCM_QA_QC["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drRLCM_QA_QC["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the RLCM_QA_QC table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QCInsert");

			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Month", DbType.Int32, this._Month);
			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);
			
			if (string.IsNullOrEmpty(this._Module))
				db.AddInParameter(dbCommand, "Module", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Module", DbType.String, this._Module);
			
			if (string.IsNullOrEmpty(this._System))
				db.AddInParameter(dbCommand, "System", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "System", DbType.String, this._System);
			
			if (string.IsNullOrEmpty(this._Task))
				db.AddInParameter(dbCommand, "Task", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Task", DbType.String, this._Task);
			
			if (string.IsNullOrEmpty(this._Category))
				db.AddInParameter(dbCommand, "Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Category", DbType.String, this._Category);
			
			if (string.IsNullOrEmpty(this._Number))
				db.AddInParameter(dbCommand, "Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Number", DbType.String, this._Number);
			
			if (string.IsNullOrEmpty(this._Hyperlink))
				db.AddInParameter(dbCommand, "Hyperlink", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Hyperlink", DbType.String, this._Hyperlink);
			
			db.AddInParameter(dbCommand, "Status", DbType.Boolean, this._Status);
			
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
		/// Selects a single record from the RLCM_QA_QC table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_RLCM_QA_QC)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QCSelectByPK");

			db.AddInParameter(dbCommand, "PK_RLCM_QA_QC", DbType.Decimal, pK_RLCM_QA_QC);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the RLCM_QA_QC table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QCSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the RLCM_QA_QC table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QCUpdate");

			
			db.AddInParameter(dbCommand, "PK_RLCM_QA_QC", DbType.Decimal, this._PK_RLCM_QA_QC);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Month", DbType.Int32, this._Month);
			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);
			
			if (string.IsNullOrEmpty(this._Module))
				db.AddInParameter(dbCommand, "Module", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Module", DbType.String, this._Module);
			
			if (string.IsNullOrEmpty(this._System))
				db.AddInParameter(dbCommand, "System", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "System", DbType.String, this._System);
			
			if (string.IsNullOrEmpty(this._Task))
				db.AddInParameter(dbCommand, "Task", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Task", DbType.String, this._Task);
			
			if (string.IsNullOrEmpty(this._Category))
				db.AddInParameter(dbCommand, "Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Category", DbType.String, this._Category);
			
			if (string.IsNullOrEmpty(this._Number))
				db.AddInParameter(dbCommand, "Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Number", DbType.String, this._Number);
			
			if (string.IsNullOrEmpty(this._Hyperlink))
				db.AddInParameter(dbCommand, "Hyperlink", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Hyperlink", DbType.String, this._Hyperlink);
			
			db.AddInParameter(dbCommand, "Status", DbType.Boolean, this._Status);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the RLCM_QA_QC table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_RLCM_QA_QC)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QCDeleteByPK");

			db.AddInParameter(dbCommand, "PK_RLCM_QA_QC", DbType.Decimal, pK_RLCM_QA_QC);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// select by serach criteria
        /// </summary>
        /// <returns></returns>
        public static DataSet RLCM_Search(decimal rlcm,decimal year,decimal month, string strOrderBy, string strOrder,string task)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QC_Search");
            db.AddInParameter(dbCommand, "RLCM", DbType.Decimal, rlcm);
            db.AddInParameter(dbCommand, "Year", DbType.Decimal, year);
            db.AddInParameter(dbCommand, "Month", DbType.Decimal, month);
            db.AddInParameter(dbCommand, "Task", DbType.String, task);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
           
            return db.ExecuteDataSet(dbCommand);
        }

        public static void UpdateStatus(string strPK_RLCM_QA_QC_Checked, string strPK_RLCM_QA_QC_UnChecked, string Updated_By)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QCUpdateStatus");

            db.AddInParameter(dbCommand, "strPK_RLCM_QA_QC_Checked", DbType.String, strPK_RLCM_QA_QC_Checked);
            db.AddInParameter(dbCommand, "strPK_RLCM_QA_QC_UnChecked", DbType.String, strPK_RLCM_QA_QC_UnChecked);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, Updated_By);

            db.ExecuteNonQuery(dbCommand);
        }

        public static void RequestUpdateStatus(decimal rlcm, string strPK_RLCM_QA_QC_Checked, string Updated_By)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QCRequestUpdateStatus");

            db.AddInParameter(dbCommand, "RLCM", DbType.Decimal, rlcm);
            db.AddInParameter(dbCommand, "strPK_RLCM_QA_QC_Checked", DbType.String, strPK_RLCM_QA_QC_Checked);            
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, Updated_By);

            db.ExecuteNonQuery(dbCommand);
        }

        public static void RLCM_QA_QC_CompleteInsertUpdateStatus(decimal rlcm, decimal year, decimal month, bool status, string Updated_By)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RLCM_QA_QC_CompleteInsertUpdateStatus");
            db.AddInParameter(dbCommand, "RLCM", DbType.Decimal, rlcm);
            db.AddInParameter(dbCommand, "Year", DbType.Decimal, year);
            db.AddInParameter(dbCommand, "Month", DbType.Decimal, month);
            db.AddInParameter(dbCommand, "status", DbType.Boolean, status);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, Updated_By);
            db.ExecuteNonQuery(dbCommand);
        }

	}
}
