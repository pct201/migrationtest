using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for AP_Property_Security_Financials table.
	/// </summary>
	public sealed class clsAP_Property_Security_Financials
	{

		#region Private variables used to hold the property values

		private decimal? _PK_AP_Property_Security_Financials;
		private decimal? _FK_AP_Property_Security;
		private string _Category;
		private decimal? _Total_Capex;
		private decimal? _Total_Monthly_Charge;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_AP_Property_Security_Financials value.
		/// </summary>
		public decimal? PK_AP_Property_Security_Financials
		{
			get { return _PK_AP_Property_Security_Financials; }
			set { _PK_AP_Property_Security_Financials = value; }
		}

		/// <summary>
		/// Gets or sets the FK_AP_Property_Security value.
		/// </summary>
		public decimal? FK_AP_Property_Security
		{
			get { return _FK_AP_Property_Security; }
			set { _FK_AP_Property_Security = value; }
		}

		/// <summary>
		/// Gets or sets the Category value.
		/// </summary>
		public string Category
		{
			get { return _Category; }
			set { _Category = value; }
		}

		/// <summary>
		/// Gets or sets the Total_Capex value.
		/// </summary>
		public decimal? Total_Capex
		{
			get { return _Total_Capex; }
			set { _Total_Capex = value; }
		}

		/// <summary>
		/// Gets or sets the Total_Monthly_Charge value.
		/// </summary>
		public decimal? Total_Monthly_Charge
		{
			get { return _Total_Monthly_Charge; }
			set { _Total_Monthly_Charge = value; }
		}

		/// <summary>
		/// Gets or sets the Update_Date value.
		/// </summary>
		public DateTime? Update_Date
		{
			get { return _Update_Date; }
			set { _Update_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsAP_Property_Security_Financials class with default value.
		/// </summary>
		public clsAP_Property_Security_Financials() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAP_Property_Security_Financials class based on Primary Key.
		/// </summary>
		public clsAP_Property_Security_Financials(decimal pK_AP_Property_Security_Financials) 
		{
			DataTable dtAP_Property_Security_Financials = SelectByPK(pK_AP_Property_Security_Financials).Tables[0];

			if (dtAP_Property_Security_Financials.Rows.Count == 1)
			{
				 SetValue(dtAP_Property_Security_Financials.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAP_Property_Security_Financials class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAP_Property_Security_Financials) 
		{
				if (drAP_Property_Security_Financials["PK_AP_Property_Security_Financials"] == DBNull.Value)
					this._PK_AP_Property_Security_Financials = null;
				else
					this._PK_AP_Property_Security_Financials = (decimal?)drAP_Property_Security_Financials["PK_AP_Property_Security_Financials"];

				if (drAP_Property_Security_Financials["FK_AP_Property_Security"] == DBNull.Value)
					this._FK_AP_Property_Security = null;
				else
					this._FK_AP_Property_Security = (decimal?)drAP_Property_Security_Financials["FK_AP_Property_Security"];

				if (drAP_Property_Security_Financials["Category"] == DBNull.Value)
					this._Category = null;
				else
					this._Category = (string)drAP_Property_Security_Financials["Category"];

				if (drAP_Property_Security_Financials["Total_Capex"] == DBNull.Value)
					this._Total_Capex = null;
				else
					this._Total_Capex = (decimal?)drAP_Property_Security_Financials["Total_Capex"];

				if (drAP_Property_Security_Financials["Total_Monthly_Charge"] == DBNull.Value)
					this._Total_Monthly_Charge = null;
				else
					this._Total_Monthly_Charge = (decimal?)drAP_Property_Security_Financials["Total_Monthly_Charge"];

				if (drAP_Property_Security_Financials["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drAP_Property_Security_Financials["Update_Date"];

				if (drAP_Property_Security_Financials["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drAP_Property_Security_Financials["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the AP_Property_Security_Financials table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_FinancialsInsert");

			
			db.AddInParameter(dbCommand, "FK_AP_Property_Security", DbType.Decimal, this._FK_AP_Property_Security);
			
			if (string.IsNullOrEmpty(this._Category))
				db.AddInParameter(dbCommand, "Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Category", DbType.String, this._Category);
			
			db.AddInParameter(dbCommand, "Total_Capex", DbType.Decimal, this._Total_Capex);
			
			db.AddInParameter(dbCommand, "Total_Monthly_Charge", DbType.Decimal, this._Total_Monthly_Charge);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;

		}

		/// <summary>
		/// Selects a single record from the AP_Property_Security_Financials table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_AP_Property_Security_Financials)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_FinancialsSelectByPK");

			db.AddInParameter(dbCommand, "PK_AP_Property_Security_Financials", DbType.Decimal, pK_AP_Property_Security_Financials);

			return db.ExecuteDataSet(dbCommand);


		}

		/// <summary>
		/// Selects all records from the AP_Property_Security_Financials table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_FinancialsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the AP_Property_Security_Financials table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_FinancialsUpdate");

			
			db.AddInParameter(dbCommand, "PK_AP_Property_Security_Financials", DbType.Decimal, this._PK_AP_Property_Security_Financials);
			
			db.AddInParameter(dbCommand, "FK_AP_Property_Security", DbType.Decimal, this._FK_AP_Property_Security);
			
			if (string.IsNullOrEmpty(this._Category))
				db.AddInParameter(dbCommand, "Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Category", DbType.String, this._Category);
			
			db.AddInParameter(dbCommand, "Total_Capex", DbType.Decimal, this._Total_Capex);
			
			db.AddInParameter(dbCommand, "Total_Monthly_Charge", DbType.Decimal, this._Total_Monthly_Charge);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the AP_Property_Security_Financials table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_AP_Property_Security_Financials)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_FinancialsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_AP_Property_Security_Financials", DbType.Decimal, pK_AP_Property_Security_Financials);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the AP_Property_Security_Financials table.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetAPPropertySecurityFinancialsFromCategory()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAPPropertySecurityFinancialsFromCategory");


            db.AddInParameter(dbCommand, "FK_AP_Property_Security", DbType.Decimal, this._FK_AP_Property_Security);

            if (string.IsNullOrEmpty(this._Category))
                db.AddInParameter(dbCommand, "Category", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Category", DbType.String, this._Category);

            // Execute the query and return the new identity value
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the AP_Property_Security_Financials table.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetAPPropertySecurityFinancialsFromFK()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAPPropertySecurityFinancialsFromFK");


            db.AddInParameter(dbCommand, "FK_AP_Property_Security", DbType.Decimal, this._FK_AP_Property_Security);
           
            // Execute the query and return the new identity value
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
