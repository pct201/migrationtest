using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table Property_Claims_Witness
	/// </summary>
	public sealed class Property_Claims_Witness
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Property_Claims_Witness_ID;
		private decimal? _FK_Property_Claims_ID;
		private string _Address_1;
		private string _Address_2;
		private string _City;
		private string _State;
		private string _Zip;
		private string _Name;
		private decimal? _Updated_By;
		private DateTime? _Updated_Date;
		private DateTime? _Created_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Property_Claims_Witness_ID value.
		/// </summary>
		public decimal? PK_Property_Claims_Witness_ID
		{
			get { return _PK_Property_Claims_Witness_ID; }
			set { _PK_Property_Claims_Witness_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Property_Claims_ID value.
		/// </summary>
		public decimal? FK_Property_Claims_ID
		{
			get { return _FK_Property_Claims_ID; }
			set { _FK_Property_Claims_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Address_1 value.
		/// </summary>
		public string Address_1
		{
			get { return _Address_1; }
			set { _Address_1 = value; }
		}

		/// <summary>
		/// Gets or sets the Address_2 value.
		/// </summary>
		public string Address_2
		{
			get { return _Address_2; }
			set { _Address_2 = value; }
		}

		/// <summary>
		/// Gets or sets the City value.
		/// </summary>
		public string City
		{
			get { return _City; }
			set { _City = value; }
		}

		/// <summary>
		/// Gets or sets the State value.
		/// </summary>
		public string State
		{
			get { return _State; }
			set { _State = value; }
		}

		/// <summary>
		/// Gets or sets the Zip value.
		/// </summary>
		public string Zip
		{
			get { return _Zip; }
			set { _Zip = value; }
		}

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public decimal? Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_Date value.
		/// </summary>
		public DateTime? Updated_Date
		{
			get { return _Updated_Date; }
			set { _Updated_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Created_Date value.
		/// </summary>
		public DateTime? Created_Date
		{
			get { return _Created_Date; }
			set { _Created_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims_Witness class with default value.
		/// </summary>
		public Property_Claims_Witness() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims_Witness class based on Primary Key.
		/// </summary>
		public Property_Claims_Witness(decimal pK_Property_Claims_Witness_ID) 
		{
			DataTable dtProperty_Claims_Witness = Select(pK_Property_Claims_Witness_ID).Tables[0];

			if (dtProperty_Claims_Witness.Rows.Count == 1)
			{
				 SetValue(dtProperty_Claims_Witness.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Property_Claims_Witness class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drProperty_Claims_Witness) 
		{
				if (drProperty_Claims_Witness["PK_Property_Claims_Witness_ID"] == DBNull.Value)
					this._PK_Property_Claims_Witness_ID = null;
				else
					this._PK_Property_Claims_Witness_ID = (decimal?)drProperty_Claims_Witness["PK_Property_Claims_Witness_ID"];

				if (drProperty_Claims_Witness["FK_Property_Claims_ID"] == DBNull.Value)
					this._FK_Property_Claims_ID = null;
				else
					this._FK_Property_Claims_ID = (decimal?)drProperty_Claims_Witness["FK_Property_Claims_ID"];

				if (drProperty_Claims_Witness["Address_1"] == DBNull.Value)
					this._Address_1 = null;
				else
					this._Address_1 = (string)drProperty_Claims_Witness["Address_1"];

				if (drProperty_Claims_Witness["Address_2"] == DBNull.Value)
					this._Address_2 = null;
				else
					this._Address_2 = (string)drProperty_Claims_Witness["Address_2"];

				if (drProperty_Claims_Witness["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drProperty_Claims_Witness["City"];

				if (drProperty_Claims_Witness["State"] == DBNull.Value)
					this._State = null;
				else
					this._State = (string)drProperty_Claims_Witness["State"];

				if (drProperty_Claims_Witness["Zip"] == DBNull.Value)
					this._Zip = null;
				else
					this._Zip = (string)drProperty_Claims_Witness["Zip"];

				if (drProperty_Claims_Witness["Name"] == DBNull.Value)
					this._Name = null;
				else
					this._Name = (string)drProperty_Claims_Witness["Name"];

				if (drProperty_Claims_Witness["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (decimal?)drProperty_Claims_Witness["Updated_By"];

				if (drProperty_Claims_Witness["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drProperty_Claims_Witness["Updated_Date"];

				if (drProperty_Claims_Witness["Created_Date"] == DBNull.Value)
					this._Created_Date = null;
				else
					this._Created_Date = (DateTime?)drProperty_Claims_Witness["Created_Date"];


		}

		#endregion

		/// <summary>
		/// Selects a single record from the Property_Claims_Witness table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Property_Claims_Witness_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_WitnessSelect");

			db.AddInParameter(dbCommand, "PK_Property_Claims_Witness_ID", DbType.Decimal, pK_Property_Claims_Witness_ID);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Inserts a record into the Property_Claims_Witness table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_WitnessInsert");


            db.AddInParameter(dbCommand, "FK_Property_Claims_ID", DbType.Decimal, this._FK_Property_Claims_ID);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            if (string.IsNullOrEmpty(this._State))
                db.AddInParameter(dbCommand, "State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "State", DbType.String, this._State);

            if (string.IsNullOrEmpty(this._Zip))
                db.AddInParameter(dbCommand, "Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);

            if (string.IsNullOrEmpty(this._Name))
                db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);

            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);

            db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, DateTime.Now);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

		/// <summary>
		/// Updates a record in the Property_Claims_Witness table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_WitnessUpdate");

			
			db.AddInParameter(dbCommand, "PK_Property_Claims_Witness_ID", DbType.Decimal, this._PK_Property_Claims_Witness_ID);
			
			db.AddInParameter(dbCommand, "FK_Property_Claims_ID", DbType.Decimal, this._FK_Property_Claims_ID);
			
			if (string.IsNullOrEmpty(this._Address_1))
				db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			
			if (string.IsNullOrEmpty(this._Address_2))
				db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			if (string.IsNullOrEmpty(this._State))
				db.AddInParameter(dbCommand, "State", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "State", DbType.String, this._State);
			
			if (string.IsNullOrEmpty(this._Zip))
				db.AddInParameter(dbCommand, "Zip", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
			
			if (string.IsNullOrEmpty(this._Name))
				db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);

            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);

			db.ExecuteNonQuery(dbCommand);
		}
        
        /// <summary>
        /// Deletes a record from the Property_Claims_Witness table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Property_Claims_Witness_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_WitnessDelete");

            db.AddInParameter(dbCommand, "PK_Property_Claims_Witness_ID", DbType.Decimal, pK_Property_Claims_Witness_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a All record from the Property_Building_Witness table by a FK Property ID
        /// </summary>
        /// <returns>Datatable</returns>
        public static DataTable GetWitnessResultByPropertyID(decimal fK_Property_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_WitnessSelectByPropertyID");

            db.AddInParameter(dbCommand, "FK_Property_Claims_ID", DbType.Decimal, fK_Property_FR_ID);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
	}
}
