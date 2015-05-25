using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_NPA_Service table.
	/// </summary>
	public sealed class clsLU_NPA_Service
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_NPA_Service;
		private string _Field_Description;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_NPA_Service value.
		/// </summary>
		public decimal? PK_LU_NPA_Service
		{
			get { return _PK_LU_NPA_Service; }
			set { _PK_LU_NPA_Service = value; }
		}

		/// <summary>
		/// Gets or sets the Field_Description value.
		/// </summary>
		public string Field_Description
		{
			get { return _Field_Description; }
			set { _Field_Description = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_NPA_Service class with default value.
		/// </summary>
		public clsLU_NPA_Service() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_NPA_Service class based on Primary Key.
		/// </summary>
		public clsLU_NPA_Service(decimal pK_LU_NPA_Service) 
		{
			DataTable dtLU_NPA_Service = SelectByPK(pK_LU_NPA_Service).Tables[0];

			if (dtLU_NPA_Service.Rows.Count == 1)
			{
				 SetValue(dtLU_NPA_Service.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_NPA_Service class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_NPA_Service) 
		{
				if (drLU_NPA_Service["PK_LU_NPA_Service"] == DBNull.Value)
					this._PK_LU_NPA_Service = null;
				else
					this._PK_LU_NPA_Service = (decimal?)drLU_NPA_Service["PK_LU_NPA_Service"];

				if (drLU_NPA_Service["Field_Description"] == DBNull.Value)
					this._Field_Description = null;
				else
					this._Field_Description = (string)drLU_NPA_Service["Field_Description"];

				if (drLU_NPA_Service["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_NPA_Service["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_NPA_Service table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NPA_ServiceInsert");

			
			if (string.IsNullOrEmpty(this._Field_Description))
				db.AddInParameter(dbCommand, "Field_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Field_Description", DbType.String, this._Field_Description);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_NPA_Service table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_NPA_Service)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NPA_ServiceSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_NPA_Service", DbType.Decimal, pK_LU_NPA_Service);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_NPA_Service table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NPA_ServiceSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_NPA_Service table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NPA_ServiceUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_NPA_Service", DbType.Decimal, this._PK_LU_NPA_Service);
			
			if (string.IsNullOrEmpty(this._Field_Description))
				db.AddInParameter(dbCommand, "Field_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Field_Description", DbType.String, this._Field_Description);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}
	}
}
