using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table SLT_Safety_Walk_Responses_Departments
	/// </summary>
	public sealed class SLT_Safety_Walk_Responses_Departments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_Safety_Walk_Responses_Department;
		private decimal? _FK_SLT_Safety_Walk_Responses;
		private decimal? _FK_LU_SLT_Safety_Walk_Department;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_Safety_Walk_Responses_Department value.
		/// </summary>
		public decimal? PK_SLT_Safety_Walk_Responses_Department
		{
			get { return _PK_SLT_Safety_Walk_Responses_Department; }
			set { _PK_SLT_Safety_Walk_Responses_Department = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_Safety_Walk_Responses value.
		/// </summary>
		public decimal? FK_SLT_Safety_Walk_Responses
		{
			get { return _FK_SLT_Safety_Walk_Responses; }
			set { _FK_SLT_Safety_Walk_Responses = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_SLT_Safety_Walk_Department value.
		/// </summary>
		public decimal? FK_LU_SLT_Safety_Walk_Department
		{
			get { return _FK_LU_SLT_Safety_Walk_Department; }
			set { _FK_LU_SLT_Safety_Walk_Department = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the SLT_Safety_Walk_Responses_Departments class with default value.
		/// </summary>
		public SLT_Safety_Walk_Responses_Departments() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the SLT_Safety_Walk_Responses_Departments class based on Primary Key.
		/// </summary>
		public SLT_Safety_Walk_Responses_Departments(decimal pK_SLT_Safety_Walk_Responses_Department) 
		{
			DataTable dtSLT_Safety_Walk_Responses_Departments = Select(pK_SLT_Safety_Walk_Responses_Department).Tables[0];

			if (dtSLT_Safety_Walk_Responses_Departments.Rows.Count == 1)
			{
				 SetValue(dtSLT_Safety_Walk_Responses_Departments.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the SLT_Safety_Walk_Responses_Departments class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_Safety_Walk_Responses_Departments) 
		{
				if (drSLT_Safety_Walk_Responses_Departments["PK_SLT_Safety_Walk_Responses_Department"] == DBNull.Value)
					this._PK_SLT_Safety_Walk_Responses_Department = null;
				else
					this._PK_SLT_Safety_Walk_Responses_Department = (decimal?)drSLT_Safety_Walk_Responses_Departments["PK_SLT_Safety_Walk_Responses_Department"];

				if (drSLT_Safety_Walk_Responses_Departments["FK_SLT_Safety_Walk_Responses"] == DBNull.Value)
					this._FK_SLT_Safety_Walk_Responses = null;
				else
					this._FK_SLT_Safety_Walk_Responses = (decimal?)drSLT_Safety_Walk_Responses_Departments["FK_SLT_Safety_Walk_Responses"];

				if (drSLT_Safety_Walk_Responses_Departments["FK_LU_SLT_Safety_Walk_Department"] == DBNull.Value)
					this._FK_LU_SLT_Safety_Walk_Department = null;
				else
					this._FK_LU_SLT_Safety_Walk_Department = (decimal?)drSLT_Safety_Walk_Responses_Departments["FK_LU_SLT_Safety_Walk_Department"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_Safety_Walk_Responses_Departments table.
		/// </summary>
		/// <returns></returns>
        public int Insert(decimal FK_SLT_Safety_Walk_Responses, string FK_LU_SLT_Safety_Walk_Departments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_Walk_Responses_DepartmentsInsert");


            db.AddInParameter(dbCommand, "FK_SLT_Safety_Walk_Responses", DbType.Decimal, FK_SLT_Safety_Walk_Responses);

            db.AddInParameter(dbCommand, "FK_LU_SLT_Safety_Walk_Departments", DbType.String, FK_LU_SLT_Safety_Walk_Departments);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_Safety_Walk_Responses_Departments table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_SLT_Safety_Walk_Responses_Department)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_Walk_Responses_DepartmentsSelect");

			db.AddInParameter(dbCommand, "PK_SLT_Safety_Walk_Responses_Department", DbType.Decimal, pK_SLT_Safety_Walk_Responses_Department);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_Safety_Walk_Responses_Departments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_Walk_Responses_DepartmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_Safety_Walk_Responses_Departments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_Walk_Responses_DepartmentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_Safety_Walk_Responses_Department", DbType.Decimal, this._PK_SLT_Safety_Walk_Responses_Department);
			
			db.AddInParameter(dbCommand, "FK_SLT_Safety_Walk_Responses", DbType.Decimal, this._FK_SLT_Safety_Walk_Responses);
			
			db.AddInParameter(dbCommand, "FK_LU_SLT_Safety_Walk_Department", DbType.Decimal, this._FK_LU_SLT_Safety_Walk_Department);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_Safety_Walk_Responses_Departments table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_SLT_Safety_Walk_Responses_Department)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_Walk_Responses_DepartmentsDelete");

			db.AddInParameter(dbCommand, "PK_SLT_Safety_Walk_Responses_Department", DbType.Decimal, pK_SLT_Safety_Walk_Responses_Department);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the SLT_Safety_Walk_Responses_Departments table By FK_SLT_Safety_Walk_Responses.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBy_FK_SLT_Safety_Walk_Responses(decimal FK_SLT_Safety_Walk_Responses)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_Walk_Responses_Departments_SelectByFK");

            db.AddInParameter(dbCommand, "FK_SLT_Safety_Walk_Responses", DbType.Decimal, FK_SLT_Safety_Walk_Responses);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
