using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_EPM_Project_Phase table.
	/// </summary>
	public sealed class LU_EPM_Project_Phase
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_EPM_Project_Phase;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_EPM_Project_Phase value.
		/// </summary>
		public decimal? PK_LU_EPM_Project_Phase
		{
			get { return _PK_LU_EPM_Project_Phase; }
			set { _PK_LU_EPM_Project_Phase = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc value.
		/// </summary>
		public string Fld_Desc
		{
			get { return _Fld_Desc; }
			set { _Fld_Desc = value; }
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
		/// Initializes a new instance of the clsLU_EPM_Project_Phase class with default value.
		/// </summary>
		public LU_EPM_Project_Phase() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_EPM_Project_Phase class based on Primary Key.
		/// </summary>
		public LU_EPM_Project_Phase(decimal pK_LU_EPM_Project_Phase) 
		{
			DataTable dtLU_EPM_Project_Phase = SelectByPK(pK_LU_EPM_Project_Phase).Tables[0];

			if (dtLU_EPM_Project_Phase.Rows.Count == 1)
			{
				 SetValue(dtLU_EPM_Project_Phase.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_EPM_Project_Phase class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_EPM_Project_Phase) 
		{
				if (drLU_EPM_Project_Phase["PK_LU_EPM_Project_Phase"] == DBNull.Value)
					this._PK_LU_EPM_Project_Phase = null;
				else
					this._PK_LU_EPM_Project_Phase = (decimal?)drLU_EPM_Project_Phase["PK_LU_EPM_Project_Phase"];

				if (drLU_EPM_Project_Phase["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_EPM_Project_Phase["Fld_Desc"];

				if (drLU_EPM_Project_Phase["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_EPM_Project_Phase["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_EPM_Project_Phase table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Project_PhaseInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_EPM_Project_Phase table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_EPM_Project_Phase)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Project_PhaseSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPM_Project_Phase", DbType.Decimal, pK_LU_EPM_Project_Phase);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_EPM_Project_Phase table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Project_PhaseSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_EPM_Project_Phase table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Project_PhaseUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_EPM_Project_Phase", DbType.Decimal, this._PK_LU_EPM_Project_Phase);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_EPM_Project_Phase table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_EPM_Project_Phase)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Project_PhaseDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPM_Project_Phase", DbType.Decimal, pK_LU_EPM_Project_Phase);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
