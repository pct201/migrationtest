using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Building_Edit table.
	/// </summary>
	public sealed class clsPM_Building_Edit
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Building_Edit;
		private decimal? _FK_Building;
		private decimal? _FK_Security_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Building_Edit value.
		/// </summary>
		public decimal? PK_PM_Building_Edit
		{
			get { return _PK_PM_Building_Edit; }
			set { _PK_PM_Building_Edit = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Building value.
		/// </summary>
		public decimal? FK_Building
		{
			get { return _FK_Building; }
			set { _FK_Building = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Security_ID value.
		/// </summary>
		public decimal? FK_Security_ID
		{
			get { return _FK_Security_ID; }
			set { _FK_Security_ID = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Building_Edit class with default value.
		/// </summary>
		public clsPM_Building_Edit() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Building_Edit class based on Primary Key.
		/// </summary>
		public clsPM_Building_Edit(decimal pK_PM_Building_Edit) 
		{
			DataTable dtPM_Building_Edit = SelectByPK(pK_PM_Building_Edit).Tables[0];

			if (dtPM_Building_Edit.Rows.Count == 1)
			{
				 SetValue(dtPM_Building_Edit.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Building_Edit class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Building_Edit) 
		{
				if (drPM_Building_Edit["PK_PM_Building_Edit"] == DBNull.Value)
					this._PK_PM_Building_Edit = null;
				else
					this._PK_PM_Building_Edit = (decimal?)drPM_Building_Edit["PK_PM_Building_Edit"];

				if (drPM_Building_Edit["FK_Building"] == DBNull.Value)
					this._FK_Building = null;
				else
					this._FK_Building = (decimal?)drPM_Building_Edit["FK_Building"];

				if (drPM_Building_Edit["FK_Security_ID"] == DBNull.Value)
					this._FK_Security_ID = null;
				else
					this._FK_Security_ID = (decimal?)drPM_Building_Edit["FK_Security_ID"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Building_Edit table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Building_EditInsert");

			
			db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);
			
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Building_Edit table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Building_Edit)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Building_EditSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Building_Edit", DbType.Decimal, pK_PM_Building_Edit);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Building_Edit table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Building_EditSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Building_Edit table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Building_EditUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Building_Edit", DbType.Decimal, this._PK_PM_Building_Edit);
			
			db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);
			
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Building_Edit table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Building_Edit)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Building_EditDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Building_Edit", DbType.Decimal, pK_PM_Building_Edit);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet CheckAccess(decimal fK_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Building_EditGetAccess");
            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, fK_Building);

            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }

        public static void DeleteAccess(decimal fK_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Building_EditDeleteAccess");

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, fK_Building);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectForUnlock()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Building_EditSelectForUnlock");

            return db.ExecuteDataSet(dbCommand); 
        }
	}
}
