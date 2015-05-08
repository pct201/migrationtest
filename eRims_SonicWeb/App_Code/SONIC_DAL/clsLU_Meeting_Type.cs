using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Meeting_Type table.
	/// </summary>
	public sealed class clsLU_Meeting_Type
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Meeting_Type;
		private string _Meeting_Type;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Meeting_Type value.
		/// </summary>
		public decimal? PK_LU_Meeting_Type
		{
			get { return _PK_LU_Meeting_Type; }
			set { _PK_LU_Meeting_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Meeting_Type value.
		/// </summary>
		public string Meeting_Type
		{
			get { return _Meeting_Type; }
			set { _Meeting_Type = value; }
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
		/// Initializes a new instance of the clsLU_Meeting_Type class with default value.
		/// </summary>
		public clsLU_Meeting_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Meeting_Type class based on Primary Key.
		/// </summary>
		public clsLU_Meeting_Type(decimal pK_LU_Meeting_Type) 
		{
			DataTable dtLU_Meeting_Type = SelectByPK(pK_LU_Meeting_Type).Tables[0];

			if (dtLU_Meeting_Type.Rows.Count == 1)
			{
				 SetValue(dtLU_Meeting_Type.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Meeting_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Meeting_Type) 
		{
				if (drLU_Meeting_Type["PK_LU_Meeting_Type"] == DBNull.Value)
					this._PK_LU_Meeting_Type = null;
				else
					this._PK_LU_Meeting_Type = (decimal?)drLU_Meeting_Type["PK_LU_Meeting_Type"];

				if (drLU_Meeting_Type["Meeting_Type"] == DBNull.Value)
					this._Meeting_Type = null;
				else
					this._Meeting_Type = (string)drLU_Meeting_Type["Meeting_Type"];

				if (drLU_Meeting_Type["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Meeting_Type["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Meeting_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Meeting_TypeInsert");

			
			if (string.IsNullOrEmpty(this._Meeting_Type))
				db.AddInParameter(dbCommand, "Meeting_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Meeting_Type", DbType.String, this._Meeting_Type);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Meeting_Type table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Meeting_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Meeting_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Meeting_Type", DbType.Decimal, pK_LU_Meeting_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Meeting_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Meeting_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Meeting_Type table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Meeting_TypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Meeting_Type", DbType.Decimal, this._PK_LU_Meeting_Type);
			
			if (string.IsNullOrEmpty(this._Meeting_Type))
				db.AddInParameter(dbCommand, "Meeting_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Meeting_Type", DbType.String, this._Meeting_Type);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}
	}
}
