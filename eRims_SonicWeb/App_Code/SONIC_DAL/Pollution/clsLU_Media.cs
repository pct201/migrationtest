using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Media table.
	/// </summary>
	public sealed class clsLU_Media
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Media;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Media value.
		/// </summary>
		public decimal? PK_LU_Media
		{
			get { return _PK_LU_Media; }
			set { _PK_LU_Media = value; }
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
		/// Initializes a new instance of the clsLU_Media class with default value.
		/// </summary>
		public clsLU_Media() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Media class based on Primary Key.
		/// </summary>
		public clsLU_Media(decimal pK_LU_Media) 
		{
			DataTable dtLU_Media = SelectByPK(pK_LU_Media).Tables[0];

			if (dtLU_Media.Rows.Count == 1)
			{
				 SetValue(dtLU_Media.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Media class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Media) 
		{
				if (drLU_Media["PK_LU_Media"] == DBNull.Value)
					this._PK_LU_Media = null;
				else
					this._PK_LU_Media = (decimal?)drLU_Media["PK_LU_Media"];

				if (drLU_Media["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Media["Fld_Desc"];

				if (drLU_Media["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Media["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Media table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MediaInsert");

			
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
		/// Selects a single record from the LU_Media table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Media)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MediaSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Media", DbType.Decimal, pK_LU_Media);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Media table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MediaSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Media table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MediaUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Media", DbType.Decimal, this._PK_LU_Media);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Media table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Media)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MediaDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Media", DbType.Decimal, pK_LU_Media);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
