using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for clsLU_Facility_Area table.
	/// </summary>
	public sealed class clsLU_Origin_Type
	{
        #region Private variables used to hold the property values

		private decimal? _PK_LU_Origin_Type;
		private string _Descriptoin;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Origin_Type value.
		/// </summary>
		public decimal? PK_LU_Origin_Type
		{
			get { return _PK_LU_Origin_Type; }
			set { _PK_LU_Origin_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Descriptoin value.
		/// </summary>
		public string Descriptoin
		{
			get { return _Descriptoin; }
			set { _Descriptoin = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Origin_Type class with default value.
		/// </summary>
		public clsLU_Origin_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Origin_Type class based on Primary Key.
		/// </summary>
        public clsLU_Origin_Type(decimal pK_LU_Origin_Type) 
		{
			DataTable dtLU_Origin_Type = Select(pK_LU_Origin_Type).Tables[0];

			if (dtLU_Origin_Type.Rows.Count == 1)
			{
				 SetValue(dtLU_Origin_Type.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Origin_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Origin_Type) 
		{
				if (drLU_Origin_Type["PK_LU_Origin_Type"] == DBNull.Value)
					this._PK_LU_Origin_Type = null;
				else
					this._PK_LU_Origin_Type = (decimal?)drLU_Origin_Type["PK_LU_Origin_Type"];

				if (drLU_Origin_Type["Descriptoin"] == DBNull.Value)
					this._Descriptoin = null;
				else
					this._Descriptoin = (string)drLU_Origin_Type["Descriptoin"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Origin_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Origin_TypeInsert");

			
			if (string.IsNullOrEmpty(this._Descriptoin))
				db.AddInParameter(dbCommand, "Descriptoin", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Descriptoin", DbType.String, this._Descriptoin);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Origin_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Origin_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Origin_TypeSelect");

			db.AddInParameter(dbCommand, "PK_LU_Origin_Type", DbType.Decimal, pK_LU_Origin_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Origin_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Origin_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Origin_Type table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Origin_TypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Origin_Type", DbType.Decimal, this._PK_LU_Origin_Type);
			
			if (string.IsNullOrEmpty(this._Descriptoin))
				db.AddInParameter(dbCommand, "Descriptoin", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Descriptoin", DbType.String, this._Descriptoin);

			return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Origin_Type table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Origin_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Origin_TypeDelete");

			db.AddInParameter(dbCommand, "PK_LU_Origin_Type", DbType.Decimal, pK_LU_Origin_Type);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
