using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Video_Tracking_Status table.
	/// </summary>
	public sealed class clsLU_Video_Tracking_Status
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Video_Tracking_Status;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Video_Tracking_Status value.
		/// </summary>
		public decimal? PK_LU_Video_Tracking_Status
		{
			get { return _PK_LU_Video_Tracking_Status; }
			set { _PK_LU_Video_Tracking_Status = value; }
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
		/// Initializes a new instance of the clsLU_Video_Tracking_Status class with default value.
		/// </summary>
		public clsLU_Video_Tracking_Status() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Video_Tracking_Status class based on Primary Key.
		/// </summary>
		public clsLU_Video_Tracking_Status(decimal pK_LU_Video_Tracking_Status) 
		{
			DataTable dtLU_Video_Tracking_Status = SelectByPK(pK_LU_Video_Tracking_Status).Tables[0];

			if (dtLU_Video_Tracking_Status.Rows.Count == 1)
			{
				 SetValue(dtLU_Video_Tracking_Status.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Video_Tracking_Status class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Video_Tracking_Status) 
		{
				if (drLU_Video_Tracking_Status["PK_LU_Video_Tracking_Status"] == DBNull.Value)
					this._PK_LU_Video_Tracking_Status = null;
				else
					this._PK_LU_Video_Tracking_Status = (decimal?)drLU_Video_Tracking_Status["PK_LU_Video_Tracking_Status"];

				if (drLU_Video_Tracking_Status["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Video_Tracking_Status["Fld_Desc"];

				if (drLU_Video_Tracking_Status["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Video_Tracking_Status["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Video_Tracking_Status table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Video_Tracking_StatusInsert");

			
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
		/// Selects a single record from the LU_Video_Tracking_Status table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Video_Tracking_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Video_Tracking_StatusSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Video_Tracking_Status", DbType.Decimal, pK_LU_Video_Tracking_Status);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Video_Tracking_Status table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Video_Tracking_StatusSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Video_Tracking_Status table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Video_Tracking_StatusUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Video_Tracking_Status", DbType.Decimal, this._PK_LU_Video_Tracking_Status);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Video_Tracking_Status table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Video_Tracking_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Video_Tracking_StatusDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Video_Tracking_Status", DbType.Decimal, pK_LU_Video_Tracking_Status);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet GetVideoStatusbydesc(string Fld_Desc)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetVideoStatusbydesc");

            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, Fld_Desc);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
