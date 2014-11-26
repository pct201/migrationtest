using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace BAL
{
	/// <summary>
	/// Data access class for table LU_Sedgwick_Field_Office_State
	/// </summary>
	public sealed class LU_Sedgwick_Field_Office_State
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Sedgwick_Field_Office_State;
		private decimal? _FK_LU_Sedgwick_Field_Office;
		private string _Fld_Desc;
		private decimal? _State_PK_Id;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Sedgwick_Field_Office_State value.
		/// </summary>
		public decimal? PK_LU_Sedgwick_Field_Office_State
		{
			get { return _PK_LU_Sedgwick_Field_Office_State; }
			set { _PK_LU_Sedgwick_Field_Office_State = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Sedgwick_Field_Office value.
		/// </summary>
		public decimal? FK_LU_Sedgwick_Field_Office
		{
			get { return _FK_LU_Sedgwick_Field_Office; }
			set { _FK_LU_Sedgwick_Field_Office = value; }
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
		/// Gets or sets the State_PK_Id value.
		/// </summary>
		public decimal? State_PK_Id
		{
			get { return _State_PK_Id; }
			set { _State_PK_Id = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Field_Office_State class with default value.
		/// </summary>
		public LU_Sedgwick_Field_Office_State() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Field_Office_State class based on Primary Key.
		/// </summary>
		public LU_Sedgwick_Field_Office_State(decimal pK_LU_Sedgwick_Field_Office_State) 
		{
			DataTable dtLU_Sedgwick_Field_Office_State = Select(pK_LU_Sedgwick_Field_Office_State).Tables[0];

			if (dtLU_Sedgwick_Field_Office_State.Rows.Count == 1)
			{
				 SetValue(dtLU_Sedgwick_Field_Office_State.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Field_Office_State class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Sedgwick_Field_Office_State) 
		{
				if (drLU_Sedgwick_Field_Office_State["PK_LU_Sedgwick_Field_Office_State"] == DBNull.Value)
					this._PK_LU_Sedgwick_Field_Office_State = null;
				else
					this._PK_LU_Sedgwick_Field_Office_State = (decimal?)drLU_Sedgwick_Field_Office_State["PK_LU_Sedgwick_Field_Office_State"];

				if (drLU_Sedgwick_Field_Office_State["FK_LU_Sedgwick_Field_Office"] == DBNull.Value)
					this._FK_LU_Sedgwick_Field_Office = null;
				else
					this._FK_LU_Sedgwick_Field_Office = (decimal?)drLU_Sedgwick_Field_Office_State["FK_LU_Sedgwick_Field_Office"];

				if (drLU_Sedgwick_Field_Office_State["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Sedgwick_Field_Office_State["Fld_Desc"];

				if (drLU_Sedgwick_Field_Office_State["State_PK_Id"] == DBNull.Value)
					this._State_PK_Id = null;
				else
					this._State_PK_Id = (decimal?)drLU_Sedgwick_Field_Office_State["State_PK_Id"];

				if (drLU_Sedgwick_Field_Office_State["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Sedgwick_Field_Office_State["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Sedgwick_Field_Office_State table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_Office_StateInsert");

			
			db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Field_Office", DbType.Decimal, this._FK_LU_Sedgwick_Field_Office);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			db.AddInParameter(dbCommand, "State_PK_Id", DbType.Decimal, this._State_PK_Id);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Sedgwick_Field_Office_State table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Sedgwick_Field_Office_State)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_Office_StateSelect");

			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Field_Office_State", DbType.Decimal, pK_LU_Sedgwick_Field_Office_State);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Sedgwick_Field_Office_State table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_Office_StateSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Sedgwick_Field_Office_State table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_Office_StateUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Field_Office_State", DbType.Decimal, this._PK_LU_Sedgwick_Field_Office_State);
			
			db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Field_Office", DbType.Decimal, this._FK_LU_Sedgwick_Field_Office);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			db.AddInParameter(dbCommand, "State_PK_Id", DbType.Decimal, this._State_PK_Id);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Sedgwick_Field_Office_State table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Sedgwick_Field_Office_State)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Field_Office_StateDelete");

			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Field_Office_State", DbType.Decimal, pK_LU_Sedgwick_Field_Office_State);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the LU_Sedgwick_Field_Office table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllStateByFK_LU_Sedgwick_Field_Office(decimal? FK_LU_Sedgwick_Field_Office)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("State_SelectBy_FK_LU_Sedgwick_Field_Office");
            db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Field_Office", DbType.Decimal, FK_LU_Sedgwick_Field_Office);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
