using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Facility_Construction_Action_Item_Category table.
	/// </summary>
	public sealed class clsLU_Facility_Construction_Action_Item_Category
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Construction_Action_Item_Category;
		private string _Type;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Construction_Action_Item_Category value.
		/// </summary>
		public decimal? PK_LU_Facility_Construction_Action_Item_Category
		{
			get { return _PK_LU_Facility_Construction_Action_Item_Category; }
			set { _PK_LU_Facility_Construction_Action_Item_Category = value; }
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
		/// Initializes a new instance of the clsLU_Facility_Construction_Action_Item_Category class with default value.
		/// </summary>
		public clsLU_Facility_Construction_Action_Item_Category() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Construction_Action_Item_Category class based on Primary Key.
		/// </summary>
		public clsLU_Facility_Construction_Action_Item_Category(decimal pK_LU_Facility_Construction_Action_Item_Category) 
		{
			DataTable dtLU_Facility_Construction_Action_Item_Category = SelectByPK(pK_LU_Facility_Construction_Action_Item_Category).Tables[0];

			if (dtLU_Facility_Construction_Action_Item_Category.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Construction_Action_Item_Category.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Construction_Action_Item_Category class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Construction_Action_Item_Category) 
		{
				if (drLU_Facility_Construction_Action_Item_Category["PK_LU_Facility_Construction_Action_Item_Category"] == DBNull.Value)
					this._PK_LU_Facility_Construction_Action_Item_Category = null;
				else
					this._PK_LU_Facility_Construction_Action_Item_Category = (decimal?)drLU_Facility_Construction_Action_Item_Category["PK_LU_Facility_Construction_Action_Item_Category"];

				if (drLU_Facility_Construction_Action_Item_Category["Type"] == DBNull.Value)
					this._Type = null;
				else
					this._Type = (string)drLU_Facility_Construction_Action_Item_Category["Type"];

				if (drLU_Facility_Construction_Action_Item_Category["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Facility_Construction_Action_Item_Category["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Construction_Action_Item_Category table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Action_Item_CategoryInsert");

			
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
		/// Selects a single record from the LU_Facility_Construction_Action_Item_Category table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Facility_Construction_Action_Item_Category)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Action_Item_CategorySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Construction_Action_Item_Category", DbType.Decimal, pK_LU_Facility_Construction_Action_Item_Category);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Construction_Action_Item_Category table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Action_Item_CategorySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Construction_Action_Item_Category table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Action_Item_CategoryUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Facility_Construction_Action_Item_Category", DbType.Decimal, this._PK_LU_Facility_Construction_Action_Item_Category);
			
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
