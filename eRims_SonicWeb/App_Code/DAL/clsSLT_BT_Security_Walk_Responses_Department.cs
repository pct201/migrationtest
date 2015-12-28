using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_BT_Security_Walk_Responses_Department table.
	/// </summary>
	public sealed class clsSLT_BT_Security_Walk_Responses_Department
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_BT_Security_Walk_Responses_Department;
		private decimal? _FK_SLT_BT_Security_Walk_Responses;
		private decimal? _FK_LU_SLT_BT_Security_Walk_Department;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_BT_Security_Walk_Responses_Department value.
		/// </summary>
		public decimal? PK_SLT_BT_Security_Walk_Responses_Department
		{
			get { return _PK_SLT_BT_Security_Walk_Responses_Department; }
			set { _PK_SLT_BT_Security_Walk_Responses_Department = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_BT_Security_Walk_Responses value.
		/// </summary>
		public decimal? FK_SLT_BT_Security_Walk_Responses
		{
			get { return _FK_SLT_BT_Security_Walk_Responses; }
			set { _FK_SLT_BT_Security_Walk_Responses = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_SLT_BT_Security_Walk_Department value.
		/// </summary>
		public decimal? FK_LU_SLT_BT_Security_Walk_Department
		{
			get { return _FK_LU_SLT_BT_Security_Walk_Department; }
			set { _FK_LU_SLT_BT_Security_Walk_Department = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Responses_Department class with default value.
		/// </summary>
		public clsSLT_BT_Security_Walk_Responses_Department() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Responses_Department class based on Primary Key.
		/// </summary>
		public clsSLT_BT_Security_Walk_Responses_Department(decimal pK_SLT_BT_Security_Walk_Responses_Department) 
		{
			DataTable dtSLT_BT_Security_Walk_Responses_Department = SelectByPK(pK_SLT_BT_Security_Walk_Responses_Department).Tables[0];

			if (dtSLT_BT_Security_Walk_Responses_Department.Rows.Count == 1)
			{
				 SetValue(dtSLT_BT_Security_Walk_Responses_Department.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSLT_BT_Security_Walk_Responses_Department class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_BT_Security_Walk_Responses_Department) 
		{
				if (drSLT_BT_Security_Walk_Responses_Department["PK_SLT_BT_Security_Walk_Responses_Department"] == DBNull.Value)
					this._PK_SLT_BT_Security_Walk_Responses_Department = null;
				else
					this._PK_SLT_BT_Security_Walk_Responses_Department = (decimal?)drSLT_BT_Security_Walk_Responses_Department["PK_SLT_BT_Security_Walk_Responses_Department"];

				if (drSLT_BT_Security_Walk_Responses_Department["FK_SLT_BT_Security_Walk_Responses"] == DBNull.Value)
					this._FK_SLT_BT_Security_Walk_Responses = null;
				else
					this._FK_SLT_BT_Security_Walk_Responses = (decimal?)drSLT_BT_Security_Walk_Responses_Department["FK_SLT_BT_Security_Walk_Responses"];

				if (drSLT_BT_Security_Walk_Responses_Department["FK_LU_SLT_BT_Security_Walk_Department"] == DBNull.Value)
					this._FK_LU_SLT_BT_Security_Walk_Department = null;
				else
					this._FK_LU_SLT_BT_Security_Walk_Department = (decimal?)drSLT_BT_Security_Walk_Responses_Department["FK_LU_SLT_BT_Security_Walk_Department"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_BT_Security_Walk_Responses_Department table.
		/// </summary>
		/// <returns></returns>
        public int Insert(decimal FK_SLT_BT_Security_Walk_Responses, string FK_LU_SLT_BT_Security_Walk_Departments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_Responses_DepartmentInsert");


            db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk_Responses", DbType.Decimal, FK_SLT_BT_Security_Walk_Responses);

            db.AddInParameter(dbCommand, "FK_LU_SLT_BT_Security_Walk_Department", DbType.Decimal, FK_LU_SLT_BT_Security_Walk_Departments);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_BT_Security_Walk_Responses_Department table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_BT_Security_Walk_Responses_Department)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_Responses_DepartmentSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Responses_Department", DbType.Decimal, pK_SLT_BT_Security_Walk_Responses_Department);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_BT_Security_Walk_Responses_Department table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_Responses_DepartmentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_BT_Security_Walk_Responses_Department table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_Responses_DepartmentUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Responses_Department", DbType.Decimal, this._PK_SLT_BT_Security_Walk_Responses_Department);
			
			db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk_Responses", DbType.Decimal, this._FK_SLT_BT_Security_Walk_Responses);
			
			db.AddInParameter(dbCommand, "FK_LU_SLT_BT_Security_Walk_Department", DbType.Decimal, this._FK_LU_SLT_BT_Security_Walk_Department);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_BT_Security_Walk_Responses_Department table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_BT_Security_Walk_Responses_Department)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_Responses_DepartmentDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_BT_Security_Walk_Responses_Department", DbType.Decimal, pK_SLT_BT_Security_Walk_Responses_Department);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the SLT_BT_Security_Walk_Responses_Departments table By FK_SLT_Safety_Walk_Responses.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBy_FK_SLT_BT_Security_Walk_Responses(decimal FK_SLT_BT_Security_Walk_Responses)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_BT_Security_Walk_Responses_Departments_SelectByFK");

            db.AddInParameter(dbCommand, "FK_SLT_BT_Security_Walk_Responses", DbType.Decimal, FK_SLT_BT_Security_Walk_Responses);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
