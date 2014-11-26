using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Assoc_Event_Description table.
	/// </summary>
	public sealed class clsAssoc_Event_Description
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Assoc_Event_Description;
		private decimal? _FK_Event;
		private decimal? _FK_LU_Event_Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Assoc_Event_Description value.
		/// </summary>
		public decimal? PK_Assoc_Event_Description
		{
			get { return _PK_Assoc_Event_Description; }
			set { _PK_Assoc_Event_Description = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Event value.
		/// </summary>
		public decimal? FK_Event
		{
			get { return _FK_Event; }
			set { _FK_Event = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Event_Description value.
		/// </summary>
		public decimal? FK_LU_Event_Description
		{
			get { return _FK_LU_Event_Description; }
			set { _FK_LU_Event_Description = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsAssoc_Event_Description class with default value.
		/// </summary>
		public clsAssoc_Event_Description() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAssoc_Event_Description class based on Primary Key.
		/// </summary>
		public clsAssoc_Event_Description(decimal pK_Assoc_Event_Description) 
		{
			DataTable dtAssoc_Event_Description = SelectByPK(pK_Assoc_Event_Description).Tables[0];

			if (dtAssoc_Event_Description.Rows.Count == 1)
			{
				 SetValue(dtAssoc_Event_Description.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAssoc_Event_Description class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAssoc_Event_Description) 
		{
				if (drAssoc_Event_Description["PK_Assoc_Event_Description"] == DBNull.Value)
					this._PK_Assoc_Event_Description = null;
				else
					this._PK_Assoc_Event_Description = (decimal?)drAssoc_Event_Description["PK_Assoc_Event_Description"];

				if (drAssoc_Event_Description["FK_Event"] == DBNull.Value)
					this._FK_Event = null;
				else
					this._FK_Event = (decimal?)drAssoc_Event_Description["FK_Event"];

				if (drAssoc_Event_Description["FK_LU_Event_Description"] == DBNull.Value)
					this._FK_LU_Event_Description = null;
				else
					this._FK_LU_Event_Description = (decimal?)drAssoc_Event_Description["FK_LU_Event_Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Assoc_Event_Description table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_DescriptionInsert");

			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);
			
			db.AddInParameter(dbCommand, "FK_LU_Event_Description", DbType.Decimal, this._FK_LU_Event_Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Assoc_Event_Description table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Assoc_Event_Description)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_DescriptionSelectByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_Event_Description", DbType.Decimal, pK_Assoc_Event_Description);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Assoc_Event_Description table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_DescriptionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Assoc_Event_Description table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_DescriptionUpdate");

			
			db.AddInParameter(dbCommand, "PK_Assoc_Event_Description", DbType.Decimal, this._PK_Assoc_Event_Description);
			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);
			
			db.AddInParameter(dbCommand, "FK_LU_Event_Description", DbType.Decimal, this._FK_LU_Event_Description);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Assoc_Event_Description table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Assoc_Event_Description)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_DescriptionDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_Event_Description", DbType.Decimal, pK_Assoc_Event_Description);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the Assoc_Event_Description table by a FK_Event.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_DescriptionSelectByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Show Event Description in view mode
        /// </summary>
        /// <param name="FK_Event"></param>
        /// <returns></returns>
        public static DataSet SelectEventDescriptionByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_DescriptionSelectByFK_EventforView");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Assoc_Event_Description table by a composite primary key.
        /// </summary>
        public static void DeleteByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_DescriptionDeleteByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
