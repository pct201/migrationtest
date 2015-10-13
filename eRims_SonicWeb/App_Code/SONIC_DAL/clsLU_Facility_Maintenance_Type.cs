using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Facility_Maintenance_Type table.
	/// </summary>
	public sealed class clsLU_Facility_Maintenance_Type
	{
		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Maintenance_Type;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Maintenance_Type value.
		/// </summary>
		public decimal? PK_LU_Facility_Maintenance_Type
		{
			get { return _PK_LU_Facility_Maintenance_Type; }
			set { _PK_LU_Facility_Maintenance_Type = value; }
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
		/// Initializes a new instance of the clsLU_Facility_Maintenance_Type class with default value.
		/// </summary>
		public clsLU_Facility_Maintenance_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Maintenance_Type class based on Primary Key.
		/// </summary>
		public clsLU_Facility_Maintenance_Type(decimal pK_LU_Facility_Maintenance_Type) 
		{
			DataTable dtLU_Facility_Maintenance_Type = SelectByPK(pK_LU_Facility_Maintenance_Type).Tables[0];

			if (dtLU_Facility_Maintenance_Type.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Maintenance_Type.Rows[0]);
			}
		}

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Maintenance_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Maintenance_Type) 
		{
				if (drLU_Facility_Maintenance_Type["PK_LU_Facility_Maintenance_Type"] == DBNull.Value)
					this._PK_LU_Facility_Maintenance_Type = null;
				else
					this._PK_LU_Facility_Maintenance_Type = (decimal?)drLU_Facility_Maintenance_Type["PK_LU_Facility_Maintenance_Type"];

				if (drLU_Facility_Maintenance_Type["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Facility_Maintenance_Type["Description"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Maintenance_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_TypeInsert");

			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Maintenance_Type table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Facility_Maintenance_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Maintenance_Type", DbType.Decimal, pK_LU_Facility_Maintenance_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Maintenance_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Maintenance_Type table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_TypeUpdate");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Maintenance_Type", DbType.Decimal, this._PK_LU_Facility_Maintenance_Type);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Facility_Maintenance_Type table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Facility_Maintenance_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_TypeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Maintenance_Type", DbType.Decimal, pK_LU_Facility_Maintenance_Type);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
