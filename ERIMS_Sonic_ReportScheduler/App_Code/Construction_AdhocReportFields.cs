using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Globalization;

namespace ERIMS_DAL
{
	/// <summary>
	/// Data access class for table Construction_AdhocReportFields
	/// </summary>
	public sealed class Construction_AdhocReportFields
	{

		#region Private variables used to hold the property values

		private decimal? _Pk_AdhocReportFields;
		private string _Table_Name;
		private string _Field_Name;
		private string _Field_Header;
		private string _WhereField;
		private decimal? _Fk_ControlType;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the Pk_AdhocReportFields value.
		/// </summary>
		public decimal? Pk_AdhocReportFields
		{
			get { return _Pk_AdhocReportFields; }
			set { _Pk_AdhocReportFields = value; }
		}

		/// <summary>
		/// Gets or sets the Table_Name value.
		/// </summary>
		public string Table_Name
		{
			get { return _Table_Name; }
			set { _Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Field_Name value.
		/// </summary>
		public string Field_Name
		{
			get { return _Field_Name; }
			set { _Field_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Field_Header value.
		/// </summary>
		public string Field_Header
		{
			get { return _Field_Header; }
			set { _Field_Header = value; }
		}

		/// <summary>
		/// Gets or sets the WhereField value.
		/// </summary>
		public string WhereField
		{
			get { return _WhereField; }
			set { _WhereField = value; }
		}

		/// <summary>
		/// Gets or sets the Fk_ControlType value.
		/// </summary>
		public decimal? Fk_ControlType
		{
			get { return _Fk_ControlType; }
			set { _Fk_ControlType = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Construction_AdhocReportFields class with default value.
		/// </summary>
		public Construction_AdhocReportFields() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Construction_AdhocReportFields class based on Primary Key.
		/// </summary>
		public Construction_AdhocReportFields(decimal pk_AdhocReportFields) 
		{
			DataTable dtConstruction_AdhocReportFields = Select(pk_AdhocReportFields).Tables[0];

			if (dtConstruction_AdhocReportFields.Rows.Count == 1)
			{
				 SetValue(dtConstruction_AdhocReportFields.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Construction_AdhocReportFields class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drConstruction_AdhocReportFields) 
		{
				if (drConstruction_AdhocReportFields["Pk_AdhocReportFields"] == DBNull.Value)
					this._Pk_AdhocReportFields = null;
				else
					this._Pk_AdhocReportFields = (decimal?)drConstruction_AdhocReportFields["Pk_AdhocReportFields"];

				if (drConstruction_AdhocReportFields["Table_Name"] == DBNull.Value)
					this._Table_Name = null;
				else
					this._Table_Name = (string)drConstruction_AdhocReportFields["Table_Name"];

				if (drConstruction_AdhocReportFields["Field_Name"] == DBNull.Value)
					this._Field_Name = null;
				else
					this._Field_Name = (string)drConstruction_AdhocReportFields["Field_Name"];

				if (drConstruction_AdhocReportFields["Field_Header"] == DBNull.Value)
					this._Field_Header = null;
				else
					this._Field_Header = (string)drConstruction_AdhocReportFields["Field_Header"];

				if (drConstruction_AdhocReportFields["WhereField"] == DBNull.Value)
					this._WhereField = null;
				else
					this._WhereField = (string)drConstruction_AdhocReportFields["WhereField"];

				if (drConstruction_AdhocReportFields["Fk_ControlType"] == DBNull.Value)
					this._Fk_ControlType = null;
				else
					this._Fk_ControlType = (decimal?)drConstruction_AdhocReportFields["Fk_ControlType"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Construction_AdhocReportFields table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdhocReportFieldsInsert");

			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			if (string.IsNullOrEmpty(this._Field_Name))
				db.AddInParameter(dbCommand, "Field_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Field_Name", DbType.String, this._Field_Name);
			
			if (string.IsNullOrEmpty(this._Field_Header))
				db.AddInParameter(dbCommand, "Field_Header", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Field_Header", DbType.String, this._Field_Header);
			
			if (string.IsNullOrEmpty(this._WhereField))
				db.AddInParameter(dbCommand, "WhereField", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "WhereField", DbType.String, this._WhereField);
			
			db.AddInParameter(dbCommand, "Fk_ControlType", DbType.Decimal, this._Fk_ControlType);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Construction_AdhocReportFields table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pk_AdhocReportFields)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdhocReportFieldsSelect");

			db.AddInParameter(dbCommand, "Pk_AdhocReportFields", DbType.Decimal, pk_AdhocReportFields);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Construction_AdhocReportFields table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdhocReportFieldsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Construction_AdhocReportFields table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdhocReportFieldsUpdate");

			
			db.AddInParameter(dbCommand, "Pk_AdhocReportFields", DbType.Decimal, this._Pk_AdhocReportFields);
			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			if (string.IsNullOrEmpty(this._Field_Name))
				db.AddInParameter(dbCommand, "Field_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Field_Name", DbType.String, this._Field_Name);
			
			if (string.IsNullOrEmpty(this._Field_Header))
				db.AddInParameter(dbCommand, "Field_Header", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Field_Header", DbType.String, this._Field_Header);
			
			if (string.IsNullOrEmpty(this._WhereField))
				db.AddInParameter(dbCommand, "WhereField", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "WhereField", DbType.String, this._WhereField);
			
			db.AddInParameter(dbCommand, "Fk_ControlType", DbType.Decimal, this._Fk_ControlType);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Construction_AdhocReportFields table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pk_AdhocReportFields)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdhocReportFieldsDelete");

			db.AddInParameter(dbCommand, "Pk_AdhocReportFields", DbType.Decimal, pk_AdhocReportFields);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Get Ad Hoc Field Name Based on Coverage Type
        /// </summary>
        /// <param name="strCoverage"></param>        
        /// <returns></returns>
        public static DataSet GetAdHocFilterFields(string strFieldType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectConstructionAdHocFilterFields");

            db.AddInParameter(dbCommand, "FieldType", DbType.String, strFieldType);            

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Gets Ad-Hoc report fields by selected filter ids
        /// </summary>
        /// <param name="pk_AdhocReportFields"></param>
        /// <returns></returns>
        public static DataSet GetAdHocReportFieldByMultipleID(string pk_AdhocReportFields)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_SelectAdHocReportWhereFileld");

            db.AddInParameter(dbCommand, "Pk_AdhocReportFields", DbType.String, pk_AdhocReportFields);

            return db.ExecuteDataSet(dbCommand);
        }        

        /// <summary>
        /// Convert Dataset to list
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<Construction_AdhocReportFields> SelectList(DataSet ds)
        {
            List<Construction_AdhocReportFields> lstConstruction_AdhocReportFields = new List<Construction_AdhocReportFields>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Construction_AdhocReportFields objConstruction_AdhocReportFields = new Construction_AdhocReportFields();
                    objConstruction_AdhocReportFields.SetValue(dr);
                    lstConstruction_AdhocReportFields.Add(objConstruction_AdhocReportFields);
                }
            }
            return lstConstruction_AdhocReportFields;
        }
	}
}
