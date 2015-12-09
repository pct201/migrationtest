using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_Facility_Inspection_Item
	/// </summary>
	public sealed class LU_Facility_Inspection_Item
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Inspection_Item;
		private string _Description;
		private decimal? _FK_Facility_Inspection_Focus_Area;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Inspection_Item value.
		/// </summary>
		public decimal? PK_LU_Facility_Inspection_Item
		{
			get { return _PK_LU_Facility_Inspection_Item; }
			set { _PK_LU_Facility_Inspection_Item = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Facility_Inspection_Focus_Area value.
		/// </summary>
		public decimal? FK_Facility_Inspection_Focus_Area
		{
			get { return _FK_Facility_Inspection_Focus_Area; }
			set { _FK_Facility_Inspection_Focus_Area = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Facility_Inspection_Item class with default value.
		/// </summary>
		public LU_Facility_Inspection_Item() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Facility_Inspection_Item class based on Primary Key.
		/// </summary>
		public LU_Facility_Inspection_Item(decimal pK_LU_Facility_Inspection_Item) 
		{
			DataTable dtLU_Facility_Inspection_Item = Select(pK_LU_Facility_Inspection_Item).Tables[0];

			if (dtLU_Facility_Inspection_Item.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Inspection_Item.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Facility_Inspection_Item class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Inspection_Item) 
		{
				if (drLU_Facility_Inspection_Item["PK_LU_Facility_Inspection_Item"] == DBNull.Value)
					this._PK_LU_Facility_Inspection_Item = null;
				else
					this._PK_LU_Facility_Inspection_Item = (decimal?)drLU_Facility_Inspection_Item["PK_LU_Facility_Inspection_Item"];

				if (drLU_Facility_Inspection_Item["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Facility_Inspection_Item["Description"];

				if (drLU_Facility_Inspection_Item["FK_Facility_Inspection_Focus_Area"] == DBNull.Value)
					this._FK_Facility_Inspection_Focus_Area = null;
				else
					this._FK_Facility_Inspection_Focus_Area = (decimal?)drLU_Facility_Inspection_Item["FK_Facility_Inspection_Focus_Area"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Inspection_Item table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ItemInsert");
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			db.AddInParameter(dbCommand, "FK_Facility_Inspection_Focus_Area", DbType.Decimal, this._FK_Facility_Inspection_Focus_Area);

			// Execute the query and return the new identity value
			return Convert.ToInt32(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Inspection_Item table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Facility_Inspection_Item)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ItemSelect");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Inspection_Item", DbType.Decimal, pK_LU_Facility_Inspection_Item);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Inspection_Item table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ItemSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects records based on Focus Area
        /// </summary>
        /// <param name="fK_Facility_Inspection_Focus_Area"></param>
        /// <returns></returns>
        public static DataSet SelectByFKFocusArea(Int32 fK_Facility_Inspection_Focus_Area)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ItemSelectByFKFocusArea");

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Focus_Area", DbType.Decimal, fK_Facility_Inspection_Focus_Area);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the LU_Facility_Inspection_Item table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ItemUpdate");
			
			db.AddInParameter(dbCommand, "PK_LU_Facility_Inspection_Item", DbType.Decimal, this._PK_LU_Facility_Inspection_Item);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			db.AddInParameter(dbCommand, "FK_Facility_Inspection_Focus_Area", DbType.Decimal, this._FK_Facility_Inspection_Focus_Area);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_Facility_Inspection_Item table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Facility_Inspection_Item)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ItemDelete");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Inspection_Item", DbType.Decimal, pK_LU_Facility_Inspection_Item);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
