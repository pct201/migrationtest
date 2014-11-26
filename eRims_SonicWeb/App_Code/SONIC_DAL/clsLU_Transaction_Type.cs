using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Transaction_Type table.
	/// </summary>
	public sealed class clsLU_Transaction_Type
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Transaction_Type;
		private string _Fld_Desc;
		private string _ACTIVE;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Transaction_Type value.
		/// </summary>
		public decimal? PK_LU_Transaction_Type
		{
			get { return _PK_LU_Transaction_Type; }
			set { _PK_LU_Transaction_Type = value; }
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
		/// Gets or sets the ACTIVE value.
		/// </summary>
		public string ACTIVE
		{
			get { return _ACTIVE; }
			set { _ACTIVE = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Transaction_Type class with default value.
		/// </summary>
		public clsLU_Transaction_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Transaction_Type class based on Primary Key.
		/// </summary>
		public clsLU_Transaction_Type(decimal pK_LU_Transaction_Type) 
		{
			DataTable dtLU_Transaction_Type = SelectByPK(pK_LU_Transaction_Type).Tables[0];

			if (dtLU_Transaction_Type.Rows.Count == 1)
			{
				 SetValue(dtLU_Transaction_Type.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Transaction_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Transaction_Type) 
		{
				if (drLU_Transaction_Type["PK_LU_Transaction_Type"] == DBNull.Value)
					this._PK_LU_Transaction_Type = null;
				else
					this._PK_LU_Transaction_Type = (decimal?)drLU_Transaction_Type["PK_LU_Transaction_Type"];

				if (drLU_Transaction_Type["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Transaction_Type["Fld_Desc"];

				if (drLU_Transaction_Type["ACTIVE"] == DBNull.Value)
					this._ACTIVE = null;
				else
					this._ACTIVE = (string)drLU_Transaction_Type["ACTIVE"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Transaction_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_TypeInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._ACTIVE))
				db.AddInParameter(dbCommand, "ACTIVE", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ACTIVE", DbType.String, this._ACTIVE);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Transaction_Type table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Transaction_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Transaction_Type", DbType.Decimal, pK_LU_Transaction_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Transaction_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Transaction_Type table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_TypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Transaction_Type", DbType.Decimal, this._PK_LU_Transaction_Type);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._ACTIVE))
				db.AddInParameter(dbCommand, "ACTIVE", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ACTIVE", DbType.String, this._ACTIVE);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Transaction_Type table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Transaction_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_TypeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Transaction_Type", DbType.Decimal, pK_LU_Transaction_Type);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
