using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for FROI_EMail_Recipients table.
	/// </summary>
	public sealed class clsFROI_EMail_Recipients
	{

		#region Private variables used to hold the property values

		private decimal? _PK_FROI_EMail_Recipients;
		private decimal? _FK_LU_Location_ID;
		private decimal? _FK_Security_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_FROI_EMail_Recipients value.
		/// </summary>
		public decimal? PK_FROI_EMail_Recipients
		{
			get { return _PK_FROI_EMail_Recipients; }
			set { _PK_FROI_EMail_Recipients = value; }
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
		/// Initializes a new instance of the clsFROI_EMail_Recipients class with default value.
		/// </summary>
		public clsFROI_EMail_Recipients() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsFROI_EMail_Recipients class based on Primary Key.
		/// </summary>
		public clsFROI_EMail_Recipients(decimal pK_FROI_EMail_Recipients) 
		{
			DataTable dtFROI_EMail_Recipients = SelectByPK(pK_FROI_EMail_Recipients).Tables[0];

			if (dtFROI_EMail_Recipients.Rows.Count == 1)
			{
				 SetValue(dtFROI_EMail_Recipients.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsFROI_EMail_Recipients class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drFROI_EMail_Recipients) 
		{
				if (drFROI_EMail_Recipients["PK_FROI_EMail_Recipients"] == DBNull.Value)
					this._PK_FROI_EMail_Recipients = null;
				else
					this._PK_FROI_EMail_Recipients = (decimal?)drFROI_EMail_Recipients["PK_FROI_EMail_Recipients"];

				if (drFROI_EMail_Recipients["FK_LU_Location_ID"] == DBNull.Value)
					this._FK_LU_Location_ID = null;
				else
					this._FK_LU_Location_ID = (decimal?)drFROI_EMail_Recipients["FK_LU_Location_ID"];

				if (drFROI_EMail_Recipients["FK_Security_ID"] == DBNull.Value)
					this._FK_Security_ID = null;
				else
					this._FK_Security_ID = (decimal?)drFROI_EMail_Recipients["FK_Security_ID"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the FROI_EMail_Recipients table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_EMail_RecipientsInsert");

			
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the FROI_EMail_Recipients table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_FROI_EMail_Recipients)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_EMail_RecipientsSelectByPK");

			db.AddInParameter(dbCommand, "PK_FROI_EMail_Recipients", DbType.Decimal, pK_FROI_EMail_Recipients);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the FROI_EMail_Recipients table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_EMail_RecipientsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the FROI_EMail_Recipients table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_EMail_RecipientsUpdate");

			
			db.AddInParameter(dbCommand, "PK_FROI_EMail_Recipients", DbType.Decimal, this._PK_FROI_EMail_Recipients);
			
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the FROI_EMail_Recipients table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_FROI_EMail_Recipients)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("FROI_EMail_RecipientsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_FROI_EMail_Recipients", DbType.Decimal, pK_FROI_EMail_Recipients);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the FROI_EMail_Recipients table by User (FK_Security_ID)
        /// </summary>
        public static void DeleteByUser(decimal fK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FROI_EMail_RecipientsDeleteByUser");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, fK_Security_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the FROI_EMail_Recipients table by User (FK_Security_ID)
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUser(decimal FK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FROI_EMail_RecipientsSelectByUser");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, FK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
