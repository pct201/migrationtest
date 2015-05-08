using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Facility_Construction_Action_Item_Type table.
	/// </summary>
	public sealed class clsLU_Facility_Construction_Action_Item_Type
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Construction_Action_Item_Type;
		private string _Type;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Construction_Action_Item_Type value.
		/// </summary>
		public decimal? PK_LU_Facility_Construction_Action_Item_Type
		{
			get { return _PK_LU_Facility_Construction_Action_Item_Type; }
			set { _PK_LU_Facility_Construction_Action_Item_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Type value.
		/// </summary>
		public string Type
		{
			get { return _Type; }
			set { _Type = value; }
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
		/// Initializes a new instance of the clsLU_Facility_Construction_Action_Item_Type class with default value.
		/// </summary>
		public clsLU_Facility_Construction_Action_Item_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Construction_Action_Item_Type class based on Primary Key.
		/// </summary>
		public clsLU_Facility_Construction_Action_Item_Type(decimal pK_LU_Facility_Construction_Action_Item_Type) 
		{
			DataTable dtLU_Facility_Construction_Action_Item_Type = SelectByPK(pK_LU_Facility_Construction_Action_Item_Type).Tables[0];

			if (dtLU_Facility_Construction_Action_Item_Type.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Construction_Action_Item_Type.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Construction_Action_Item_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Construction_Action_Item_Type) 
		{
				if (drLU_Facility_Construction_Action_Item_Type["PK_LU_Facility_Construction_Action_Item_Type"] == DBNull.Value)
					this._PK_LU_Facility_Construction_Action_Item_Type = null;
				else
					this._PK_LU_Facility_Construction_Action_Item_Type = (decimal?)drLU_Facility_Construction_Action_Item_Type["PK_LU_Facility_Construction_Action_Item_Type"];

				if (drLU_Facility_Construction_Action_Item_Type["Type"] == DBNull.Value)
					this._Type = null;
				else
					this._Type = (string)drLU_Facility_Construction_Action_Item_Type["Type"];

				if (drLU_Facility_Construction_Action_Item_Type["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Facility_Construction_Action_Item_Type["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Construction_Action_Item_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Action_Item_TypeInsert");

			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Construction_Action_Item_Type table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Facility_Construction_Action_Item_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Action_Item_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Construction_Action_Item_Type", DbType.Decimal, pK_LU_Facility_Construction_Action_Item_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Construction_Action_Item_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Action_Item_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Construction_Action_Item_Type table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Action_Item_TypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Facility_Construction_Action_Item_Type", DbType.Decimal, this._PK_LU_Facility_Construction_Action_Item_Type);
			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}
	}
}
