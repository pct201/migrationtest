using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_Contract_Type
	/// </summary>
	public sealed class LU_Contract_Type
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Contract_Type;
		private string _Descr;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Contract_Type value.
		/// </summary>
		public decimal? PK_LU_Contract_Type
		{
			get { return _PK_LU_Contract_Type; }
			set { _PK_LU_Contract_Type = value; }
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
		/// Initializes a new instance of the LU_Contract_Type class with default value.
		/// </summary>
		public LU_Contract_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Contract_Type class based on Primary Key.
		/// </summary>
		public LU_Contract_Type(decimal pK_LU_Contract_Type) 
		{
			DataTable dtLU_Contract_Type = Select(pK_LU_Contract_Type).Tables[0];

			if (dtLU_Contract_Type.Rows.Count == 1)
			{
				 SetValue(dtLU_Contract_Type.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Contract_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Contract_Type) 
		{
				if (drLU_Contract_Type["PK_LU_Contract_Type"] == DBNull.Value)
					this._PK_LU_Contract_Type = null;
				else
					this._PK_LU_Contract_Type = (decimal?)drLU_Contract_Type["PK_LU_Contract_Type"];

				if (drLU_Contract_Type["Descr"] == DBNull.Value)
					this._Descr = null;
				else
					this._Descr = (string)drLU_Contract_Type["Descr"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Contract_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Contract_TypeInsert");

			
			if (string.IsNullOrEmpty(this._Descr))
				db.AddInParameter(dbCommand, "Descr", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Descr", DbType.String, this._Descr);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Contract_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Contract_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Contract_TypeSelect");

			db.AddInParameter(dbCommand, "PK_LU_Contract_Type", DbType.Decimal, pK_LU_Contract_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Contract_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Contract_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Contract_Type table.
		/// </summary>
        public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Contract_TypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Contract_Type", DbType.Decimal, this._PK_LU_Contract_Type);
			
			if (string.IsNullOrEmpty(this._Descr))
				db.AddInParameter(dbCommand, "Descr", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Descr", DbType.String, this._Descr);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Contract_Type table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Contract_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Contract_TypeDelete");

			db.AddInParameter(dbCommand, "PK_LU_Contract_Type", DbType.Decimal, pK_LU_Contract_Type);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
