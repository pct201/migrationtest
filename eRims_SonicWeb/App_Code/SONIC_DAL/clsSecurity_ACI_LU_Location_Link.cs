using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Security_ACI_LU_Location_Link table.
	/// </summary>
	public sealed class clsSecurity_ACI_LU_Location_Link
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Security_ACI_LU_Location_Link;
		private decimal? _FK_LU_Location_ID;
		private decimal? _FK_Security_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Security_ACI_LU_Location_Link value.
		/// </summary>
		public decimal? PK_Security_ACI_LU_Location_Link
		{
			get { return _PK_Security_ACI_LU_Location_Link; }
			set { _PK_Security_ACI_LU_Location_Link = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Location_ID value.
		/// </summary>
		public decimal? FK_LU_Location_ID
		{
			get { return _FK_LU_Location_ID; }
			set { _FK_LU_Location_ID = value; }
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
		/// Initializes a new instance of the clsSecurity_ACI_LU_Location_Link class with default value.
		/// </summary>
		public clsSecurity_ACI_LU_Location_Link() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSecurity_ACI_LU_Location_Link class based on Primary Key.
		/// </summary>
		public clsSecurity_ACI_LU_Location_Link(decimal pK_Security_ACI_LU_Location_Link) 
		{
			DataTable dtSecurity_ACI_LU_Location_Link = SelectByPK(pK_Security_ACI_LU_Location_Link).Tables[0];

			if (dtSecurity_ACI_LU_Location_Link.Rows.Count == 1)
			{
				 SetValue(dtSecurity_ACI_LU_Location_Link.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSecurity_ACI_LU_Location_Link class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSecurity_ACI_LU_Location_Link) 
		{
				if (drSecurity_ACI_LU_Location_Link["PK_Security_ACI_LU_Location_Link"] == DBNull.Value)
					this._PK_Security_ACI_LU_Location_Link = null;
				else
					this._PK_Security_ACI_LU_Location_Link = (decimal?)drSecurity_ACI_LU_Location_Link["PK_Security_ACI_LU_Location_Link"];

				if (drSecurity_ACI_LU_Location_Link["FK_LU_Location_ID"] == DBNull.Value)
					this._FK_LU_Location_ID = null;
				else
					this._FK_LU_Location_ID = (decimal?)drSecurity_ACI_LU_Location_Link["FK_LU_Location_ID"];

				if (drSecurity_ACI_LU_Location_Link["FK_Security_ID"] == DBNull.Value)
					this._FK_Security_ID = null;
				else
					this._FK_Security_ID = (decimal?)drSecurity_ACI_LU_Location_Link["FK_Security_ID"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Security_ACI_LU_Location_Link table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_Location_LinkInsert");

			
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Security_ACI_LU_Location_Link table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Security_ACI_LU_Location_Link)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_Location_LinkSelectByPK");

			db.AddInParameter(dbCommand, "PK_Security_ACI_LU_Location_Link", DbType.Decimal, pK_Security_ACI_LU_Location_Link);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Security_ACI_LU_Location_Link table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_Location_LinkSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Security_ACI_LU_Location_Link table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_Location_LinkUpdate");

			
			db.AddInParameter(dbCommand, "PK_Security_ACI_LU_Location_Link", DbType.Decimal, this._PK_Security_ACI_LU_Location_Link);
			
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Security_ACI_LU_Location_Link table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Security_ACI_LU_Location_Link)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_Location_LinkDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Security_ACI_LU_Location_Link", DbType.Decimal, pK_Security_ACI_LU_Location_Link);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the Security_ACI_LU_Location_Link table by User (FK_Security_ID)
        /// </summary>
        public static void DeleteByUser(decimal fK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_Location_LinkDeleteByUser");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, fK_Security_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Security_ACI_LU_Location_Link table by User (FK_Security_ID)
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUser(decimal FK_Security_ID, bool bSelectAll)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ACI_LU_Location_LinkSelectByUser");
            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, FK_Security_ID);
            db.AddInParameter(dbCommand, "bSelectAll", DbType.Decimal, bSelectAll);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
