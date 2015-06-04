using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Management_Email_Recipients table.
	/// </summary>
	public sealed class clsManagement_Email_Recipients
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Management_Email_Recipients;
		private decimal? _FK_LU_Location_ID;
		private decimal? _FK_Security_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Management_Email_Recipients value.
		/// </summary>
		public decimal? PK_Management_Email_Recipients
		{
			get { return _PK_Management_Email_Recipients; }
			set { _PK_Management_Email_Recipients = value; }
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
		/// Initializes a new instance of the clsManagement_Email_Recipients class with default value.
		/// </summary>
		public clsManagement_Email_Recipients() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsManagement_Email_Recipients class based on Primary Key.
		/// </summary>
		public clsManagement_Email_Recipients(decimal pK_Management_Email_Recipients) 
		{
			DataTable dtManagement_Email_Recipients = SelectByPK(pK_Management_Email_Recipients).Tables[0];

			if (dtManagement_Email_Recipients.Rows.Count == 1)
			{
				 SetValue(dtManagement_Email_Recipients.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsManagement_Email_Recipients class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drManagement_Email_Recipients) 
		{
				if (drManagement_Email_Recipients["PK_Management_Email_Recipients"] == DBNull.Value)
					this._PK_Management_Email_Recipients = null;
				else
					this._PK_Management_Email_Recipients = (decimal?)drManagement_Email_Recipients["PK_Management_Email_Recipients"];

				if (drManagement_Email_Recipients["FK_LU_Location_ID"] == DBNull.Value)
					this._FK_LU_Location_ID = null;
				else
					this._FK_LU_Location_ID = (decimal?)drManagement_Email_Recipients["FK_LU_Location_ID"];

				if (drManagement_Email_Recipients["FK_Security_ID"] == DBNull.Value)
					this._FK_Security_ID = null;
				else
					this._FK_Security_ID = (decimal?)drManagement_Email_Recipients["FK_Security_ID"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Management_Email_Recipients table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Email_RecipientsInsert");

			
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Management_Email_Recipients table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Management_Email_Recipients)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Email_RecipientsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Management_Email_Recipients", DbType.Decimal, pK_Management_Email_Recipients);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Management_Email_Recipients table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Email_RecipientsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Management_Email_Recipients table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Email_RecipientsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Management_Email_Recipients", DbType.Decimal, this._PK_Management_Email_Recipients);
			
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Management_Email_Recipients table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Management_Email_Recipients)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Management_Email_RecipientsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Management_Email_Recipients", DbType.Decimal, pK_Management_Email_Recipients);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the ACI_Event_Email_Recipients table by User (FK_Security_ID)
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUser(decimal FK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_Email_RecipientsSelectByUser");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, FK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the ACI_Event_Email_Recipients table by User (FK_Security_ID)
        /// </summary>
        public static void DeleteByUser(decimal fK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_Email_RecipientsDeleteByUser");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, fK_Security_ID);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
