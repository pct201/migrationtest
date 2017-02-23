using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Document_Type table.
	/// </summary>
	public sealed class LU_Document_Type
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Document_Type;
		private string _Document_Type;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Document_Type value.
		/// </summary>
		public decimal? PK_Document_Type
		{
			get { return _PK_Document_Type; }
			set { _PK_Document_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Document_Type value.
		/// </summary>
		public string Document_Type
		{
			get { return _Document_Type; }
			set { _Document_Type = value; }
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
		/// Initializes a new instance of the LU_Document_Type class with default value.
		/// </summary>
		public LU_Document_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Document_Type class based on Primary Key.
		/// </summary>
		public LU_Document_Type(decimal pK_Document_Type) 
		{
			DataTable dtLU_Document_Type = SelectByPK(pK_Document_Type).Tables[0];

			if (dtLU_Document_Type.Rows.Count == 1)
			{
				 SetValue(dtLU_Document_Type.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Document_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Document_Type) 
		{
				if (drLU_Document_Type["PK_Document_Type"] == DBNull.Value)
					this._PK_Document_Type = null;
				else
					this._PK_Document_Type = (decimal?)drLU_Document_Type["PK_Document_Type"];

				if (drLU_Document_Type["Document_Type"] == DBNull.Value)
					this._Document_Type = null;
				else
					this._Document_Type = (string)drLU_Document_Type["Document_Type"];

				if (drLU_Document_Type["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Document_Type["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Document_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Document_TypeInsert");

			
			if (string.IsNullOrEmpty(this._Document_Type))
				db.AddInParameter(dbCommand, "Document_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Document_Type", DbType.String, this._Document_Type);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Document_Type table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Document_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Document_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_Document_Type", DbType.Decimal, pK_Document_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Document_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Document_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Document_Type table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Document_TypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_Document_Type", DbType.Decimal, this._PK_Document_Type);
			
			if (string.IsNullOrEmpty(this._Document_Type))
				db.AddInParameter(dbCommand, "Document_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Document_Type", DbType.String, this._Document_Type);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Document_Type table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Document_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Document_TypeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Document_Type", DbType.Decimal, pK_Document_Type);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
