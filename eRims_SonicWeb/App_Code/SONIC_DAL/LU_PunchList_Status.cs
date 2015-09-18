using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_PunchList_Status
	/// </summary>
	public sealed class LU_PunchList_Status
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_PunchList_Status;
		private string _Descr;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_PunchList_Status value.
		/// </summary>
		public decimal? PK_LU_PunchList_Status
		{
			get { return _PK_LU_PunchList_Status; }
			set { _PK_LU_PunchList_Status = value; }
		}

		/// <summary>
		/// Gets or sets the Descr value.
		/// </summary>
		public string Descr
		{
			get { return _Descr; }
			set { _Descr = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_PunchList_Status class with default value.
		/// </summary>
		public LU_PunchList_Status() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_PunchList_Status class based on Primary Key.
		/// </summary>
		public LU_PunchList_Status(decimal pK_LU_PunchList_Status) 
		{
			DataTable dtLU_PunchList_Status = Select(pK_LU_PunchList_Status).Tables[0];

			if (dtLU_PunchList_Status.Rows.Count == 1)
			{
				 SetValue(dtLU_PunchList_Status.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_PunchList_Status class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_PunchList_Status) 
		{
				if (drLU_PunchList_Status["PK_LU_PunchList_Status"] == DBNull.Value)
					this._PK_LU_PunchList_Status = null;
				else
					this._PK_LU_PunchList_Status = (decimal?)drLU_PunchList_Status["PK_LU_PunchList_Status"];

				if (drLU_PunchList_Status["Descr"] == DBNull.Value)
					this._Descr = null;
				else
					this._Descr = (string)drLU_PunchList_Status["Descr"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_PunchList_Status table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PunchList_StatusInsert");

			
			if (string.IsNullOrEmpty(this._Descr))
				db.AddInParameter(dbCommand, "Descr", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Descr", DbType.String, this._Descr);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_PunchList_Status table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_PunchList_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PunchList_StatusSelect");

			db.AddInParameter(dbCommand, "PK_LU_PunchList_Status", DbType.Decimal, pK_LU_PunchList_Status);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_PunchList_Status table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PunchList_StatusSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_PunchList_Status table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PunchList_StatusUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_PunchList_Status", DbType.Decimal, this._PK_LU_PunchList_Status);
			
			if (string.IsNullOrEmpty(this._Descr))
				db.AddInParameter(dbCommand, "Descr", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Descr", DbType.String, this._Descr);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_PunchList_Status table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_PunchList_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PunchList_StatusDelete");

			db.AddInParameter(dbCommand, "PK_LU_PunchList_Status", DbType.Decimal, pK_LU_PunchList_Status);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
