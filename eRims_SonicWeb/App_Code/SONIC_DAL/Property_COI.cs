using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Property_COI table.
	/// </summary>
	public sealed class Property_COI
	{
		private Property_COI() {}

        ///// <summary>
        ///// Inserts a record into the Property_COI table.
        ///// </summary>
        ///// <returns></returns>
        //public int Insert()
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("Property_COIInsert");

        //    db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
        //    db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
        //    db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
        //    db.AddInParameter(dbCommand, "Path", DbType.String, this._Path);
        //    db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);

        //    // Execute the query and return the new identity value
        //    int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

        //    return returnValue;
        //}

		/// <summary>
		/// Selects a single record from the Property_COI table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Property_COI_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COISelectByPK");

			db.AddInParameter(dbCommand, "PK_Property_COI_ID", DbType.Decimal, pK_Property_COI_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Property_COI table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COISelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        ///// <summary>
        ///// Updates a record in the Property_COI table.
        ///// </summary>
        //public void Update()
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("Property_COIUpdate");

        //    db.AddInParameter(dbCommand, "PK_Property_COI_ID", DbType.Decimal, this._PK_Property_COI_ID);
        //    db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
        //    db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
        //    db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
        //    db.AddInParameter(dbCommand, "Path", DbType.String, this._Path);
        //    db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);

        //    db.ExecuteNonQuery(dbCommand);
        //}

		/// <summary>
		/// Deletes a record from the Property_COI table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Property_COI_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COIDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Property_COI_ID", DbType.Decimal, pK_Property_COI_ID);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByLocation(int fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COISelectByLocation");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectYears(int fK_LU_Location_ID, string strType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COISelectYear");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Type", DbType.String, strType);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
