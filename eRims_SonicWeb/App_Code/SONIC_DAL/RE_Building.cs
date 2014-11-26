using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RE_Building table.
	/// </summary>
	public sealed class RE_Building
	{

		#region Private variables used to hold the property values

		private decimal? _PK_RE_Building;
		private decimal? _FK_RE_Information;
		private decimal? _FK_Building_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_RE_Building value.
		/// </summary>
		public decimal? PK_RE_Building
		{
			get { return _PK_RE_Building; }
			set { _PK_RE_Building = value; }
		}

		/// <summary>
		/// Gets or sets the FK_RE_Information value.
		/// </summary>
		public decimal? FK_RE_Information
		{
			get { return _FK_RE_Information; }
			set { _FK_RE_Information = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Building_ID value.
		/// </summary>
		public decimal? FK_Building_ID
		{
			get { return _FK_Building_ID; }
			set { _FK_Building_ID = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the RE_Building class with default value.
		/// </summary>
		public RE_Building() 
		{

			this._PK_RE_Building = null;
			this._FK_RE_Information = null;
			this._FK_Building_ID = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the RE_Building class based on Primary Key.
		/// </summary>
		public RE_Building(decimal pK_RE_Building) 
		{
			DataTable dtRE_Building = SelectByPK(pK_RE_Building).Tables[0];

			if (dtRE_Building.Rows.Count == 1)
			{
				DataRow drRE_Building = dtRE_Building.Rows[0];
				if (drRE_Building["PK_RE_Building"] == DBNull.Value)
					this._PK_RE_Building = null;
				else
					this._PK_RE_Building = (decimal?)drRE_Building["PK_RE_Building"];

				if (drRE_Building["FK_RE_Information"] == DBNull.Value)
					this._FK_RE_Information = null;
				else
					this._FK_RE_Information = (decimal?)drRE_Building["FK_RE_Information"];

				if (drRE_Building["FK_Building_ID"] == DBNull.Value)
					this._FK_Building_ID = null;
				else
					this._FK_Building_ID = (decimal?)drRE_Building["FK_Building_ID"];

			}
			else
			{
				this._PK_RE_Building = null;
				this._FK_RE_Information = null;
				this._FK_Building_ID = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the RE_Building table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_BuildingInsert");

			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, this._FK_Building_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the RE_Building table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_RE_Building)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_BuildingSelectByPK");

			db.AddInParameter(dbCommand, "PK_RE_Building", DbType.Decimal, pK_RE_Building);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the RE_Building table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_BuildingSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the RE_Building table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_BuildingUpdate");

			
			db.AddInParameter(dbCommand, "PK_RE_Building", DbType.Decimal, this._PK_RE_Building);
			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, this._FK_Building_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the RE_Building table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_RE_Building)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_BuildingDeleteByPK");

			db.AddInParameter(dbCommand, "PK_RE_Building", DbType.Decimal, pK_RE_Building);

			db.ExecuteNonQuery(dbCommand);
		}
        
        public static DataSet SelectByFK_RE_Information(decimal fK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_BuildingSelectByRE");
            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, fK_RE_Information);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
