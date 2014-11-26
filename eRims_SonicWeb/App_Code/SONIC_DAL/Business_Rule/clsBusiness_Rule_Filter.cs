using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Globalization;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Business_Rule_Filter table.
	/// </summary>
	public sealed class clsBusiness_Rule_Filter
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Business_Rule_Filter;
		private decimal? _FK_Business_Rules;
		private decimal? _FK_Business_Rules_Fields;
		private string _ConditionType;
		private string _ConditionValue;
		private decimal? _AmountFrom;
		private decimal? _AmountTo;
		private DateTime? _FromDate;
		private string _FromRelativeCriteria;
		private DateTime? _ToDate;
		private string _ToRelativeCriteria;
		private bool? _IsNotSelected;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Business_Rule_Filter value.
		/// </summary>
		public decimal? PK_Business_Rule_Filter
		{
			get { return _PK_Business_Rule_Filter; }
			set { _PK_Business_Rule_Filter = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Business_Rules value.
		/// </summary>
		public decimal? FK_Business_Rules
		{
			get { return _FK_Business_Rules; }
			set { _FK_Business_Rules = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Business_Rules_Fields value.
		/// </summary>
		public decimal? FK_Business_Rules_Fields
		{
			get { return _FK_Business_Rules_Fields; }
			set { _FK_Business_Rules_Fields = value; }
		}

		/// <summary>
		/// Gets or sets the ConditionType value.
		/// </summary>
		public string ConditionType
		{
			get { return _ConditionType; }
			set { _ConditionType = value; }
		}

		/// <summary>
		/// Gets or sets the ConditionValue value.
		/// </summary>
		public string ConditionValue
		{
			get { return _ConditionValue; }
			set { _ConditionValue = value; }
		}

		/// <summary>
		/// Gets or sets the AmountFrom value.
		/// </summary>
		public decimal? AmountFrom
		{
			get { return _AmountFrom; }
			set { _AmountFrom = value; }
		}

		/// <summary>
		/// Gets or sets the AmountTo value.
		/// </summary>
		public decimal? AmountTo
		{
			get { return _AmountTo; }
			set { _AmountTo = value; }
		}

		/// <summary>
		/// Gets or sets the FromDate value.
		/// </summary>
		public DateTime? FromDate
		{
			get { return _FromDate; }
			set { _FromDate = value; }
		}

		/// <summary>
		/// Gets or sets the FromRelativeCriteria value.
		/// </summary>
		public string FromRelativeCriteria
		{
			get { return _FromRelativeCriteria; }
			set { _FromRelativeCriteria = value; }
		}

		/// <summary>
		/// Gets or sets the ToDate value.
		/// </summary>
		public DateTime? ToDate
		{
			get { return _ToDate; }
			set { _ToDate = value; }
		}

		/// <summary>
		/// Gets or sets the ToRelativeCriteria value.
		/// </summary>
		public string ToRelativeCriteria
		{
			get { return _ToRelativeCriteria; }
			set { _ToRelativeCriteria = value; }
		}

		/// <summary>
		/// Gets or sets the IsNotSelected value.
		/// </summary>
		public bool? IsNotSelected
		{
			get { return _IsNotSelected; }
			set { _IsNotSelected = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rule_Filter class with default value.
		/// </summary>
		public clsBusiness_Rule_Filter() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rule_Filter class based on Primary Key.
		/// </summary>
		public clsBusiness_Rule_Filter(decimal pK_Business_Rule_Filter) 
		{
			DataTable dtBusiness_Rule_Filter = SelectByPK(pK_Business_Rule_Filter).Tables[0];

			if (dtBusiness_Rule_Filter.Rows.Count == 1)
			{
				 SetValue(dtBusiness_Rule_Filter.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rule_Filter class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drBusiness_Rule_Filter) 
		{
				if (drBusiness_Rule_Filter["PK_Business_Rule_Filter"] == DBNull.Value)
					this._PK_Business_Rule_Filter = null;
				else
					this._PK_Business_Rule_Filter = (decimal?)drBusiness_Rule_Filter["PK_Business_Rule_Filter"];

				if (drBusiness_Rule_Filter["FK_Business_Rules"] == DBNull.Value)
					this._FK_Business_Rules = null;
				else
					this._FK_Business_Rules = (decimal?)drBusiness_Rule_Filter["FK_Business_Rules"];

				if (drBusiness_Rule_Filter["FK_Business_Rules_Fields"] == DBNull.Value)
					this._FK_Business_Rules_Fields = null;
				else
					this._FK_Business_Rules_Fields = (decimal?)drBusiness_Rule_Filter["FK_Business_Rules_Fields"];

				if (drBusiness_Rule_Filter["ConditionType"] == DBNull.Value)
					this._ConditionType = null;
				else
					this._ConditionType = (string)drBusiness_Rule_Filter["ConditionType"];

				if (drBusiness_Rule_Filter["ConditionValue"] == DBNull.Value)
					this._ConditionValue = null;
				else
					this._ConditionValue = (string)drBusiness_Rule_Filter["ConditionValue"];

				if (drBusiness_Rule_Filter["AmountFrom"] == DBNull.Value)
					this._AmountFrom = null;
				else
					this._AmountFrom = (decimal?)drBusiness_Rule_Filter["AmountFrom"];

				if (drBusiness_Rule_Filter["AmountTo"] == DBNull.Value)
					this._AmountTo = null;
				else
					this._AmountTo = (decimal?)drBusiness_Rule_Filter["AmountTo"];

				if (drBusiness_Rule_Filter["FromDate"] == DBNull.Value)
					this._FromDate = null;
				else
					this._FromDate = (DateTime?)drBusiness_Rule_Filter["FromDate"];

				if (drBusiness_Rule_Filter["FromRelativeCriteria"] == DBNull.Value)
					this._FromRelativeCriteria = null;
				else
					this._FromRelativeCriteria = (string)drBusiness_Rule_Filter["FromRelativeCriteria"];

				if (drBusiness_Rule_Filter["ToDate"] == DBNull.Value)
					this._ToDate = null;
				else
					this._ToDate = (DateTime?)drBusiness_Rule_Filter["ToDate"];

				if (drBusiness_Rule_Filter["ToRelativeCriteria"] == DBNull.Value)
					this._ToRelativeCriteria = null;
				else
					this._ToRelativeCriteria = (string)drBusiness_Rule_Filter["ToRelativeCriteria"];

				if (drBusiness_Rule_Filter["IsNotSelected"] == DBNull.Value)
					this._IsNotSelected = null;
				else
					this._IsNotSelected = (bool?)drBusiness_Rule_Filter["IsNotSelected"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Business_Rule_Filter table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rule_FilterInsert");

			
			db.AddInParameter(dbCommand, "FK_Business_Rules", DbType.Decimal, this._FK_Business_Rules);
			
			db.AddInParameter(dbCommand, "FK_Business_Rules_Fields", DbType.Decimal, this._FK_Business_Rules_Fields);
			
			if (string.IsNullOrEmpty(this._ConditionType))
				db.AddInParameter(dbCommand, "ConditionType", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ConditionType", DbType.String, this._ConditionType);
			
			if (string.IsNullOrEmpty(this._ConditionValue))
				db.AddInParameter(dbCommand, "ConditionValue", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ConditionValue", DbType.String, this._ConditionValue);
			
			db.AddInParameter(dbCommand, "AmountFrom", DbType.Decimal, this._AmountFrom);
			
			db.AddInParameter(dbCommand, "AmountTo", DbType.Decimal, this._AmountTo);
			
			db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, this._FromDate);
			
			if (string.IsNullOrEmpty(this._FromRelativeCriteria))
				db.AddInParameter(dbCommand, "FromRelativeCriteria", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FromRelativeCriteria", DbType.String, this._FromRelativeCriteria);
			
			db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, this._ToDate);
			
			if (string.IsNullOrEmpty(this._ToRelativeCriteria))
				db.AddInParameter(dbCommand, "ToRelativeCriteria", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ToRelativeCriteria", DbType.String, this._ToRelativeCriteria);
			
			db.AddInParameter(dbCommand, "IsNotSelected", DbType.Boolean, this._IsNotSelected);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Business_Rule_Filter table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Business_Rule_Filter)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rule_FilterSelectByPK");

			db.AddInParameter(dbCommand, "PK_Business_Rule_Filter", DbType.Decimal, pK_Business_Rule_Filter);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Business_Rules_Fields table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public List<ERIMS.DAL.clsBusiness_Rule_Filter> SelectByFK(decimal fK_Business_Rules)
        {

            Database dbHelper = null;
            DbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                List<ERIMS.DAL.clsBusiness_Rule_Filter> results = new List<ERIMS.DAL.clsBusiness_Rule_Filter>();
                ERIMS.DAL.clsBusiness_Rule_Filter objFilter;

                cmd = dbHelper.GetStoredProcCommand("Business_Rule_FilterSelectByFK");
                dbHelper.AddInParameter(cmd, "FK_Business_Rules", DbType.Decimal, fK_Business_Rules);
                reader = dbHelper.ExecuteReader(cmd);
                while (reader.Read())
                {
                    objFilter = MapFrom(reader);
                    results.Add(objFilter);
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
                reader = null;
                cmd = null;
                dbHelper = null;
            }

            //Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetStoredProcCommand("Business_Rule_FilterSelectByFK");

            //db.AddInParameter(dbCommand, "FK_Business_Rules", DbType.Decimal, fK_Business_Rules);

            //return db.ExecuteDataSet(dbCommand);
         
        }

        ///// <summary>
        ///// Selects a single record from the Business_Rule_Filter table by a foreign key.
        ///// </summary>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectByFK(decimal fK_Business_Rules)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("Business_Rule_FilterSelectByFK");

        //    db.AddInParameter(dbCommand, "FK_Business_Rules", DbType.Decimal, fK_Business_Rules);

        //    return db.ExecuteDataSet(dbCommand);
        //}

		/// <summary>
		/// Selects all records from the Business_Rule_Filter table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rule_FilterSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Business_Rule_Filter table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rule_FilterUpdate");

			
			db.AddInParameter(dbCommand, "PK_Business_Rule_Filter", DbType.Decimal, this._PK_Business_Rule_Filter);
			
			db.AddInParameter(dbCommand, "FK_Business_Rules", DbType.Decimal, this._FK_Business_Rules);
			
			db.AddInParameter(dbCommand, "FK_Business_Rules_Fields", DbType.Decimal, this._FK_Business_Rules_Fields);
			
			if (string.IsNullOrEmpty(this._ConditionType))
				db.AddInParameter(dbCommand, "ConditionType", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ConditionType", DbType.String, this._ConditionType);
			
			if (string.IsNullOrEmpty(this._ConditionValue))
				db.AddInParameter(dbCommand, "ConditionValue", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ConditionValue", DbType.String, this._ConditionValue);
			
			db.AddInParameter(dbCommand, "AmountFrom", DbType.Decimal, this._AmountFrom);
			
			db.AddInParameter(dbCommand, "AmountTo", DbType.Decimal, this._AmountTo);
			
			db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, this._FromDate);
			
			if (string.IsNullOrEmpty(this._FromRelativeCriteria))
				db.AddInParameter(dbCommand, "FromRelativeCriteria", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FromRelativeCriteria", DbType.String, this._FromRelativeCriteria);
			
			db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, this._ToDate);
			
			if (string.IsNullOrEmpty(this._ToRelativeCriteria))
				db.AddInParameter(dbCommand, "ToRelativeCriteria", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ToRelativeCriteria", DbType.String, this._ToRelativeCriteria);
			
			db.AddInParameter(dbCommand, "IsNotSelected", DbType.Boolean, this._IsNotSelected);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Business_Rule_Filter table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Business_Rule_Filter)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rule_FilterDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Business_Rule_Filter", DbType.Decimal, pK_Business_Rule_Filter);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the Business_Rule_Filter table by a composite foreign key.
        /// </summary>
        public static void DeleteByFK(decimal fK_Business_Rules)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_Rule_FilterDeleteByFK");

            db.AddInParameter(dbCommand, "FK_Business_Rules", DbType.Decimal, fK_Business_Rules);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Map Reader Value to AdHiocReportFields 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected ERIMS.DAL.clsBusiness_Rule_Filter MapFrom(IDataReader reader)
        {
            ERIMS.DAL.clsBusiness_Rule_Filter objFilter = new ERIMS.DAL.clsBusiness_Rule_Filter();
            if (!Convert.IsDBNull(reader["PK_Business_Rule_Filter"])) { objFilter.PK_Business_Rule_Filter = Convert.ToDecimal(reader["PK_Business_Rule_Filter"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Business_Rules"])) { objFilter.FK_Business_Rules = Convert.ToInt32(reader["FK_Business_Rules"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Business_Rules_Fields"])) { objFilter.FK_Business_Rules_Fields = Convert.ToInt32(reader["FK_Business_Rules_Fields"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ConditionType"])) { objFilter.ConditionType = Convert.ToString(reader["ConditionType"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ConditionValue"])) { objFilter.ConditionValue = Convert.ToString(reader["ConditionValue"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AmountFrom"])) { objFilter.AmountFrom = Convert.ToDecimal(reader["AmountFrom"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AmountTo"])) { objFilter.AmountTo = Convert.ToDecimal(reader["AmountTo"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FromDate"])) { objFilter.FromDate = Convert.ToDateTime(reader["FromDate"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FromRelativeCriteria"])) { objFilter.FromRelativeCriteria = Convert.ToString(reader["FromRelativeCriteria"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ToDate"])) { objFilter.ToDate = Convert.ToDateTime(reader["ToDate"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ToRelativeCriteria"])) { objFilter.ToRelativeCriteria = Convert.ToString(reader["ToRelativeCriteria"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["IsNotSelected"])) { objFilter.IsNotSelected = Convert.ToBoolean(reader["IsNotSelected"], CultureInfo.InvariantCulture); }
            return objFilter;
        }
	}
}
