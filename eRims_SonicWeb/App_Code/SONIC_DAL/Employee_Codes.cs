using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Employee_Codes table.
	/// </summary>
	public sealed class Employee_Codes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Employee_Codes;
		private string _Employee_Id;
		private string _Code;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Employee_Codes value.
		/// </summary>
		public decimal? PK_Employee_Codes
		{
			get { return _PK_Employee_Codes; }
			set { _PK_Employee_Codes = value; }
		}

		/// <summary>
		/// Gets or sets the Employee_Id value.
		/// </summary>
		public string Employee_Id
		{
			get { return _Employee_Id; }
			set { _Employee_Id = value; }
		}

		/// <summary>
		/// Gets or sets the Code value.
		/// </summary>
		public string Code
		{
			get { return _Code; }
			set { _Code = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsEmployee_Codes class with default value.
		/// </summary>
		public Employee_Codes() 
		{
            this._PK_Employee_Codes = -1;
            this._Employee_Id = null;
            this.Code = null;         
		}

         /// <summary> 
        /// Initializes a new instance of the Employee class for passed PrimaryKey with the values set from Database.
        /// </summary>
        //public Employee_Codes(decimal PK)
        //{
        //    DataTable dtEmployee_Codes = SelectByPK(PK).Tables[0];

        //    if (dtEmployee_Codes.Rows.Count > 0)
        //    {
        //        DataRow drEmployee = dtEmployee_Codes.Rows[0];

        //        this._PK_Employee_Codes = (decimal)drEmployee["PK_Employee_Codes"];

        //        if (drEmployee["Employee_Id"] == DBNull.Value)
        //            this._Employee_Id = null;
        //        else
        //            this._Employee_Id = (string)drEmployee["Employee_Id"];

        //        if (drEmployee["Code"] == DBNull.Value)
        //            this.Code = null;
        //        else
        //            this.Code = (string)drEmployee["Code"];
        //    }
        //    else
        //    {
        //        this._PK_Employee_Codes = -1;
        //        this._Employee_Id = null;
        //        this.Code = null;                
        //    }

        //}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsEmployee_Codes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drEmployee_Codes) 
		{
				if (drEmployee_Codes["PK_Employee_Codes"] == DBNull.Value)
					this._PK_Employee_Codes = null;
				else
					this._PK_Employee_Codes = (decimal?)drEmployee_Codes["PK_Employee_Codes"];

				if (drEmployee_Codes["Employee_Id"] == DBNull.Value)
					this._Employee_Id = null;
				else
					this._Employee_Id = (string)drEmployee_Codes["Employee_Id"];

				if (drEmployee_Codes["Code"] == DBNull.Value)
					this._Code = null;
				else
					this._Code = (string)drEmployee_Codes["Code"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Employee_Codes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Employee_CodesInsert");

			
			if (string.IsNullOrEmpty(this._Employee_Id))
				db.AddInParameter(dbCommand, "Employee_Id", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Employee_Id", DbType.String, this._Employee_Id);
			
			if (string.IsNullOrEmpty(this._Code))
				db.AddInParameter(dbCommand, "Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

        /// <summary>
        /// Inserts a record into the Employee_Codes table.
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Employee_CodesUpdate");


            if (string.IsNullOrEmpty(this._Employee_Id))
                db.AddInParameter(dbCommand, "Employee_Id", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Id", DbType.String, this._Employee_Id);

            if (string.IsNullOrEmpty(this._Code))
                db.AddInParameter(dbCommand, "Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }


		/// <summary>
		/// Selects all records from the Employee_Codes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Employee_CodesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Employee table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByEmployeeCodes(string Employee_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Employee_CodesSelectByEmployeeId");

            db.AddInParameter(dbCommand, "Employee_Id", DbType.String, Employee_Id);

            return db.ExecuteDataSet(dbCommand);
        }

	}
}
