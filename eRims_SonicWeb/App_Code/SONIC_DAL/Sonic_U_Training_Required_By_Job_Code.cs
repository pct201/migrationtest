using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Sonic_U_Training_Required_By_Job_Code table.
	/// </summary>
	public sealed class Sonic_U_Training_Required_By_Job_Code
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Sonic_U_Training_Required_By_Job_Code;
		private decimal? _FK_Sonic_U_Training_Classes;
		private decimal? _FK_lu_job_code;
		private decimal? _FK_LU_Training_Requirement_Type;
		private string _Active;
		private string _Old_Class;
		private string _Old_Requirement;
		private string _Old_Code;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Sonic_U_Training_Required_By_Job_Code value.
		/// </summary>
		public decimal? PK_Sonic_U_Training_Required_By_Job_Code
		{
			get { return _PK_Sonic_U_Training_Required_By_Job_Code; }
			set { _PK_Sonic_U_Training_Required_By_Job_Code = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Sonic_U_Training_Classes value.
		/// </summary>
		public decimal? FK_Sonic_U_Training_Classes
		{
			get { return _FK_Sonic_U_Training_Classes; }
			set { _FK_Sonic_U_Training_Classes = value; }
		}

		/// <summary>
		/// Gets or sets the FK_lu_job_code value.
		/// </summary>
		public decimal? FK_lu_job_code
		{
			get { return _FK_lu_job_code; }
			set { _FK_lu_job_code = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Training_Requirement_Type value.
		/// </summary>
		public decimal? FK_LU_Training_Requirement_Type
		{
			get { return _FK_LU_Training_Requirement_Type; }
			set { _FK_LU_Training_Requirement_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

		/// <summary>
		/// Gets or sets the Old_Class value.
		/// </summary>
		public string Old_Class
		{
			get { return _Old_Class; }
			set { _Old_Class = value; }
		}

		/// <summary>
		/// Gets or sets the Old_Requirement value.
		/// </summary>
		public string Old_Requirement
		{
			get { return _Old_Requirement; }
			set { _Old_Requirement = value; }
		}

		/// <summary>
		/// Gets or sets the Old_Code value.
		/// </summary>
		public string Old_Code
		{
			get { return _Old_Code; }
			set { _Old_Code = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Sonic_U_Training_Required_By_Job_Code class with default value.
		/// </summary>
		public Sonic_U_Training_Required_By_Job_Code() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Sonic_U_Training_Required_By_Job_Code class based on Primary Key.
		/// </summary>
		public Sonic_U_Training_Required_By_Job_Code(decimal pK_Sonic_U_Training_Required_By_Job_Code) 
		{
			DataTable dtSonic_U_Training_Required_By_Job_Code = SelectByPK(pK_Sonic_U_Training_Required_By_Job_Code).Tables[0];

			if (dtSonic_U_Training_Required_By_Job_Code.Rows.Count == 1)
			{
				 SetValue(dtSonic_U_Training_Required_By_Job_Code.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Sonic_U_Training_Required_By_Job_Code class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSonic_U_Training_Required_By_Job_Code) 
		{
				if (drSonic_U_Training_Required_By_Job_Code["PK_Sonic_U_Training_Required_By_Job_Code"] == DBNull.Value)
					this._PK_Sonic_U_Training_Required_By_Job_Code = null;
				else
					this._PK_Sonic_U_Training_Required_By_Job_Code = (decimal?)drSonic_U_Training_Required_By_Job_Code["PK_Sonic_U_Training_Required_By_Job_Code"];

				if (drSonic_U_Training_Required_By_Job_Code["FK_Sonic_U_Training_Classes"] == DBNull.Value)
					this._FK_Sonic_U_Training_Classes = null;
				else
					this._FK_Sonic_U_Training_Classes = (decimal?)drSonic_U_Training_Required_By_Job_Code["FK_Sonic_U_Training_Classes"];

				if (drSonic_U_Training_Required_By_Job_Code["FK_lu_job_code"] == DBNull.Value)
					this._FK_lu_job_code = null;
				else
					this._FK_lu_job_code = (decimal?)drSonic_U_Training_Required_By_Job_Code["FK_lu_job_code"];

				if (drSonic_U_Training_Required_By_Job_Code["FK_LU_Training_Requirement_Type"] == DBNull.Value)
					this._FK_LU_Training_Requirement_Type = null;
				else
					this._FK_LU_Training_Requirement_Type = (decimal?)drSonic_U_Training_Required_By_Job_Code["FK_LU_Training_Requirement_Type"];

				if (drSonic_U_Training_Required_By_Job_Code["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drSonic_U_Training_Required_By_Job_Code["Active"];

				if (drSonic_U_Training_Required_By_Job_Code["Old_Class"] == DBNull.Value)
					this._Old_Class = null;
				else
					this._Old_Class = (string)drSonic_U_Training_Required_By_Job_Code["Old_Class"];

				if (drSonic_U_Training_Required_By_Job_Code["Old_Requirement"] == DBNull.Value)
					this._Old_Requirement = null;
				else
					this._Old_Requirement = (string)drSonic_U_Training_Required_By_Job_Code["Old_Requirement"];

				if (drSonic_U_Training_Required_By_Job_Code["Old_Code"] == DBNull.Value)
					this._Old_Code = null;
				else
					this._Old_Code = (string)drSonic_U_Training_Required_By_Job_Code["Old_Code"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Sonic_U_Training_Required_By_Job_Code table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_By_Job_CodeInsert");

			
			db.AddInParameter(dbCommand, "FK_Sonic_U_Training_Classes", DbType.Decimal, this._FK_Sonic_U_Training_Classes);
			
			db.AddInParameter(dbCommand, "FK_lu_job_code", DbType.Decimal, this._FK_lu_job_code);
			
			db.AddInParameter(dbCommand, "FK_LU_Training_Requirement_Type", DbType.Decimal, this._FK_LU_Training_Requirement_Type);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			if (string.IsNullOrEmpty(this._Old_Class))
				db.AddInParameter(dbCommand, "Old_Class", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Old_Class", DbType.String, this._Old_Class);
			
			if (string.IsNullOrEmpty(this._Old_Requirement))
				db.AddInParameter(dbCommand, "Old_Requirement", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Old_Requirement", DbType.String, this._Old_Requirement);
			
			if (string.IsNullOrEmpty(this._Old_Code))
				db.AddInParameter(dbCommand, "Old_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Old_Code", DbType.String, this._Old_Code);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Sonic_U_Training_Required_By_Job_Code table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet SelectByPK(decimal pK_Sonic_U_Training_Required_By_Job_Code)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_By_Job_CodeSelectByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_U_Training_Required_By_Job_Code", DbType.Decimal, pK_Sonic_U_Training_Required_By_Job_Code);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Sonic_U_Training_Required_By_Job_Code table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_By_Job_CodeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Sonic_U_Training_Required_By_Job_Code table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_By_Job_CodeUpdate");

			
			db.AddInParameter(dbCommand, "PK_Sonic_U_Training_Required_By_Job_Code", DbType.Decimal, this._PK_Sonic_U_Training_Required_By_Job_Code);
			
			db.AddInParameter(dbCommand, "FK_Sonic_U_Training_Classes", DbType.Decimal, this._FK_Sonic_U_Training_Classes);
			
			db.AddInParameter(dbCommand, "FK_lu_job_code", DbType.Decimal, this._FK_lu_job_code);
			
			db.AddInParameter(dbCommand, "FK_LU_Training_Requirement_Type", DbType.Decimal, this._FK_LU_Training_Requirement_Type);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			if (string.IsNullOrEmpty(this._Old_Class))
				db.AddInParameter(dbCommand, "Old_Class", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Old_Class", DbType.String, this._Old_Class);
			
			if (string.IsNullOrEmpty(this._Old_Requirement))
				db.AddInParameter(dbCommand, "Old_Requirement", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Old_Requirement", DbType.String, this._Old_Requirement);
			
			if (string.IsNullOrEmpty(this._Old_Code))
				db.AddInParameter(dbCommand, "Old_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Old_Code", DbType.String, this._Old_Code);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Sonic_U_Training_Required_By_Job_Code table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Sonic_U_Training_Required_By_Job_Code)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_By_Job_CodeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_U_Training_Required_By_Job_Code", DbType.Decimal, pK_Sonic_U_Training_Required_By_Job_Code);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the Sonic_U_Training_Required_By_Job_Code table by a composite primary key.
        /// </summary>
        public static DataSet Search(decimal? fk_LU_Job_Code, decimal? fK_Sonic_U_Training_Classes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_By_Job_Search");

            db.AddInParameter(dbCommand, "FK_LU_Job_Code", DbType.Decimal, fk_LU_Job_Code);
            
            db.AddInParameter(dbCommand, "FK_Sonic_U_Training_Classes", DbType.Decimal, fK_Sonic_U_Training_Classes);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects record from the Sonic_U_Training_Required_By_Job_Code table by a job code
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByJobCode(decimal fk_LU_Job_Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_By_Job_CodeSelectByJobCode");

            db.AddInParameter(dbCommand, "FK_LU_Job_Code", DbType.Decimal, fk_LU_Job_Code);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all Requirement_Type
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllRequirement_Type()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Training_Requirement_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Job_Code table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllJobCode()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_CodeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Job_Code table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectJobCode()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_CodeSelect");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Import XML 
        /// </summary>
        /// <param name="xml"></param>
        public static void ImportXML(string xmlInsert, string xmlUpdate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_By_Job_CodeInsertXML");

            db.AddInParameter(dbCommand, "xmlInsert", DbType.Xml, xmlInsert);
            db.AddInParameter(dbCommand, "xmlUpdate", DbType.Xml, xmlUpdate);

            dbCommand.CommandTimeout = 10000;
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Import XML 
        /// </summary>
        /// <param name="xml"></param>
        public static DataSet SelectRecords()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_By_Job_CodeSelectRecords");
            
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
