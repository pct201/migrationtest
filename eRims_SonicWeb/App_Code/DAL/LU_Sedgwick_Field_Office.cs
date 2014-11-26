using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace BAL
{
	/// <summary>
	/// Data access class for table LU_Sedgwick_Field_Office
	/// </summary>
	public sealed class LU_Sedgwick_Field_Office
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Sedgwick_Field_Office;
		private string _Fld_Desc;
		private string _Active;
        private DateTime? _Date_Of_Last_Review;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Sedgwick_Field_Office value.
		/// </summary>
		public decimal? PK_LU_Sedgwick_Field_Office
		{
			get { return _PK_LU_Sedgwick_Field_Office; }
			set { _PK_LU_Sedgwick_Field_Office = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc value.
		/// </summary>
		public string Fld_Desc
		{
			get { return _Fld_Desc; }
			set { _Fld_Desc = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

        /// <summary>
        /// Gets or sets the Date_Of_Last_Review value.
		/// </summary>
        public DateTime? Date_Of_Last_Review
		{
            get { return _Date_Of_Last_Review; }
            set { _Date_Of_Last_Review = value; }
		}
        
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Field_Office class with default value.
		/// </summary>
		public LU_Sedgwick_Field_Office() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Field_Office class based on Primary Key.
		/// </summary>
		public LU_Sedgwick_Field_Office(decimal pK_LU_Sedgwick_Field_Office) 
		{
			DataTable dtLU_Sedgwick_Field_Office = Select(pK_LU_Sedgwick_Field_Office).Tables[0];

			if (dtLU_Sedgwick_Field_Office.Rows.Count == 1)
			{
				 SetValue(dtLU_Sedgwick_Field_Office.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Field_Office class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Sedgwick_Field_Office) 
		{
				if (drLU_Sedgwick_Field_Office["PK_LU_Sedgwick_Field_Office"] == DBNull.Value)
					this._PK_LU_Sedgwick_Field_Office = null;
				else
					this._PK_LU_Sedgwick_Field_Office = (decimal?)drLU_Sedgwick_Field_Office["PK_LU_Sedgwick_Field_Office"];

				if (drLU_Sedgwick_Field_Office["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Sedgwick_Field_Office["Fld_Desc"];

				if (drLU_Sedgwick_Field_Office["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Sedgwick_Field_Office["Active"];

                if (drLU_Sedgwick_Field_Office["Date_Of_Last_Review"] == DBNull.Value)
                    this._Date_Of_Last_Review = null;
                else
                    this._Date_Of_Last_Review = (DateTime?)drLU_Sedgwick_Field_Office["Date_Of_Last_Review"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Sedgwick_Field_Office table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_OfficeInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Sedgwick_Field_Office table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Sedgwick_Field_Office)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_OfficeSelect");

			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Field_Office", DbType.Decimal, pK_LU_Sedgwick_Field_Office);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Sedgwick_Field_Office table.
		/// </summary>
		/// <returns>DataSet</returns>
        public static DataSet SelectAll(decimal FK_Security_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_OfficeSelectAll");
            db.AddInParameter(dbCommand, "@FK_Security_ID", DbType.Decimal, FK_Security_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Sedgwick_Field_Office table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_OfficeUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Field_Office", DbType.Decimal, this._PK_LU_Sedgwick_Field_Office);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Sedgwick_Field_Office table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Sedgwick_Field_Office)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_OfficeDelete");

			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Field_Office", DbType.Decimal, pK_LU_Sedgwick_Field_Office);

			db.ExecuteNonQuery(dbCommand);
		}

        
	}
}
