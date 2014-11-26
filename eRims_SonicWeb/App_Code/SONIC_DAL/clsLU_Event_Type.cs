using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Incident_Type  table.
	/// </summary>
	public sealed class clsLU_Event_Type
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Event_Type;
		private string _Fld_Code;
		private string _Fld_Desc;
		private string _Active;
        private decimal? _Event_Outcome;
        private string _Is_Actionable;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Event_Type value.
		/// </summary>
		public decimal? PK_LU_Event_Type
		{
			get { return _PK_LU_Event_Type; }
			set { _PK_LU_Event_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Code value.
		/// </summary>
		public string Fld_Code
		{
			get { return _Fld_Code; }
			set { _Fld_Code = value; }
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
        /// Gets or sets the Event_Outcome value.
        /// </summary>
        public decimal? Event_Outcome
        {
            get { return _Event_Outcome; }
            set { _Event_Outcome = value; }
        }

        /// <summary>
        /// Gets or sets the Is_Actionable value.
        /// </summary>
        public string Is_Actionable
        {
            get { return _Is_Actionable; }
            set { _Is_Actionable = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
        /// Initializes a new instance of the clsLU_Event_Type class with default value.
		/// </summary>
		public clsLU_Event_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
        /// Initializes a new instance of the clsLU_Event_Type class based on Primary Key.
		/// </summary>
		public clsLU_Event_Type(decimal pK_LU_Event_Type) 
		{
			DataTable dtLU_Event_Type  = SelectByPK(pK_LU_Event_Type).Tables[0];

			if (dtLU_Event_Type .Rows.Count == 1)
			{
				 SetValue(dtLU_Event_Type .Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Event_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Event_Type ) 
		{
				if (drLU_Event_Type ["PK_LU_Event_Type"] == DBNull.Value)
					this._PK_LU_Event_Type = null;
				else
                    this._PK_LU_Event_Type = (decimal?)drLU_Event_Type["PK_LU_Event_Type"];

				if (drLU_Event_Type ["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Event_Type ["Fld_Code"];

				if (drLU_Event_Type ["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Event_Type ["Fld_Desc"];

				if (drLU_Event_Type ["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Event_Type ["Active"];

                if (drLU_Event_Type["Event_Outcome"] == DBNull.Value)
                    this._Event_Outcome = null;
                else
                    this._Event_Outcome = (decimal?)drLU_Event_Type["Event_Outcome"];

                if (drLU_Event_Type["Is_Actionable"] == DBNull.Value)
                    this._Is_Actionable = null;
                else
                    this._Is_Actionable = (string)drLU_Event_Type["Is_Actionable"];


		}

		#endregion

		/// <summary>
        /// Inserts a record into the LU_Event_Type  table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_TypeInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            db.AddInParameter(dbCommand, "Event_Outcome", DbType.Decimal, this._Event_Outcome);

            if (string.IsNullOrEmpty(this._Is_Actionable))
                db.AddInParameter(dbCommand, "Is_Actionable", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Is_Actionable", DbType.String, this._Is_Actionable);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Event_Type  table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Event_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Event_Type", DbType.Decimal, pK_LU_Event_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
        /// Selects all records from the LU_Event_Type  table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
        /// Updates a record in the LU_Event_Type  table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_TypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Event_Type", DbType.Decimal, this._PK_LU_Event_Type);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            db.AddInParameter(dbCommand, "Event_Outcome", DbType.Decimal, this._Event_Outcome);

            if (string.IsNullOrEmpty(this._Is_Actionable))
                db.AddInParameter(dbCommand, "Is_Actionable", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Is_Actionable", DbType.String, this._Is_Actionable);


            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
		}

		/// <summary>
        /// Deletes a record from the LU_Event_Type  table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Event_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_TypeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Event_Type", DbType.Decimal, pK_LU_Event_Type);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
