using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Facility_Maintenance_Status table.
	/// </summary>
	public sealed class clsLU_Facility_Maintenance_Status
	{
		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Maintenance_Status;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Maintenance_Status value.
		/// </summary>
		public decimal? PK_LU_Facility_Maintenance_Status
		{
			get { return _PK_LU_Facility_Maintenance_Status; }
			set { _PK_LU_Facility_Maintenance_Status = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Maintenance_Status class with default value.
		/// </summary>
		public clsLU_Facility_Maintenance_Status() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Maintenance_Status class based on Primary Key.
		/// </summary>
		public clsLU_Facility_Maintenance_Status(decimal pK_LU_Facility_Maintenance_Status) 
		{
			DataTable dtLU_Facility_Maintenance_Status = SelectByPK(pK_LU_Facility_Maintenance_Status).Tables[0];

			if (dtLU_Facility_Maintenance_Status.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Maintenance_Status.Rows[0]);

			}

		}

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Maintenance_Status class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Maintenance_Status) 
		{
				if (drLU_Facility_Maintenance_Status["PK_LU_Facility_Maintenance_Status"] == DBNull.Value)
					this._PK_LU_Facility_Maintenance_Status = null;
				else
					this._PK_LU_Facility_Maintenance_Status = (decimal?)drLU_Facility_Maintenance_Status["PK_LU_Facility_Maintenance_Status"];

				if (drLU_Facility_Maintenance_Status["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Facility_Maintenance_Status["Description"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Maintenance_Status table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_StatusInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Maintenance_Status table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Facility_Maintenance_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_StatusSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Maintenance_Status", DbType.Decimal, pK_LU_Facility_Maintenance_Status);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Maintenance_Status table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_StatusSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Maintenance_Status table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_StatusUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Facility_Maintenance_Status", DbType.Decimal, this._PK_LU_Facility_Maintenance_Status);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

        /// <summary>
        /// Selects a single record from the LU_Facility_Maintenance_Status table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByDescription(string description)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_StatusSelectByDescription");

            db.AddInParameter(dbCommand, "Description", DbType.String, description);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Deletes a record from the LU_Facility_Maintenance_Status table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Facility_Maintenance_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_StatusDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Maintenance_Status", DbType.Decimal, pK_LU_Facility_Maintenance_Status);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
