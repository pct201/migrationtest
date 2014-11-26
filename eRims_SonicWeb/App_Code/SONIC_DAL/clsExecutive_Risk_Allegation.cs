using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Executive_Risk_Allegation table.
	/// </summary>
	public sealed class clsExecutive_Risk_Allegation
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Executive_Risk_Allegation;
		private decimal? _FK_Executive_Risk;
		private decimal? _FK_Type_Of_ER_Allegation;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Executive_Risk_Allegation value.
		/// </summary>
		public decimal? PK_Executive_Risk_Allegation
		{
			get { return _PK_Executive_Risk_Allegation; }
			set { _PK_Executive_Risk_Allegation = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Executive_Risk value.
		/// </summary>
		public decimal? FK_Executive_Risk
		{
			get { return _FK_Executive_Risk; }
			set { _FK_Executive_Risk = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Type_Of_ER_Allegation value.
		/// </summary>
		public decimal? FK_Type_Of_ER_Allegation
		{
			get { return _FK_Type_Of_ER_Allegation; }
			set { _FK_Type_Of_ER_Allegation = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsExecutive_Risk_Allegation class with default value.
		/// </summary>
		public clsExecutive_Risk_Allegation() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsExecutive_Risk_Allegation class based on Primary Key.
		/// </summary>
		public clsExecutive_Risk_Allegation(decimal pK_Executive_Risk_Allegation) 
		{
			DataTable dtExecutive_Risk_Allegation = SelectByPK(pK_Executive_Risk_Allegation).Tables[0];

			if (dtExecutive_Risk_Allegation.Rows.Count == 1)
			{
				 SetValue(dtExecutive_Risk_Allegation.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsExecutive_Risk_Allegation class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drExecutive_Risk_Allegation) 
		{
				if (drExecutive_Risk_Allegation["PK_Executive_Risk_Allegation"] == DBNull.Value)
					this._PK_Executive_Risk_Allegation = null;
				else
					this._PK_Executive_Risk_Allegation = (decimal?)drExecutive_Risk_Allegation["PK_Executive_Risk_Allegation"];

				if (drExecutive_Risk_Allegation["FK_Executive_Risk"] == DBNull.Value)
					this._FK_Executive_Risk = null;
				else
					this._FK_Executive_Risk = (decimal?)drExecutive_Risk_Allegation["FK_Executive_Risk"];

				if (drExecutive_Risk_Allegation["FK_Type_Of_ER_Allegation"] == DBNull.Value)
					this._FK_Type_Of_ER_Allegation = null;
				else
					this._FK_Type_Of_ER_Allegation = (decimal?)drExecutive_Risk_Allegation["FK_Type_Of_ER_Allegation"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Executive_Risk_Allegation table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_AllegationInsert");

			
			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			
			db.AddInParameter(dbCommand, "FK_Type_Of_ER_Allegation", DbType.Decimal, this._FK_Type_Of_ER_Allegation);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Executive_Risk_Allegation table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Executive_Risk_Allegation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_AllegationSelectByPK");

			db.AddInParameter(dbCommand, "PK_Executive_Risk_Allegation", DbType.Decimal, pK_Executive_Risk_Allegation);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Executive_Risk_Allegation table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_AllegationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Executive_Risk_Allegation table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_AllegationUpdate");

			
			db.AddInParameter(dbCommand, "PK_Executive_Risk_Allegation", DbType.Decimal, this._PK_Executive_Risk_Allegation);
			
			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			
			db.AddInParameter(dbCommand, "FK_Type_Of_ER_Allegation", DbType.Decimal, this._FK_Type_Of_ER_Allegation);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Executive_Risk_Allegation table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Executive_Risk_Allegation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_AllegationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Executive_Risk_Allegation", DbType.Decimal, pK_Executive_Risk_Allegation);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Executive_Risk_Allegation table by a FK_Executive_Risk.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Executive_Risk(decimal FK_Executive_Risk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_AllegationSelectByFK_Executive_Risk");

            db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, FK_Executive_Risk);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Risk Allegation by Executive Risk
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectType_ER_AllegationByFK_Executive_Risk(decimal FK_Executive_Risk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectType_ER_AllegationByFK_Executive_Risk");

            db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, FK_Executive_Risk);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Deletes a record from the Executive_Risk_Allegation table by a FK_Executive_Risk.
        /// </summary>
        public static void DeleteByFK_Executive_Risk(decimal FK_Executive_Risk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_AllegationDeleteByFK_Executive_Risk");

            db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, FK_Executive_Risk);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
