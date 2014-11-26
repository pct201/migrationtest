using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Assoc_Event_Type table.
	/// </summary>
	public sealed class clsAssoc_Event_Type
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Assoc_Event_Type;
		private decimal? _FK_Event;
		private decimal? _FK_LU_Event_Type;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Assoc_Event_Type value.
		/// </summary>
		public decimal? PK_Assoc_Event_Type
		{
			get { return _PK_Assoc_Event_Type; }
			set { _PK_Assoc_Event_Type = value; }
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
		/// Gets or sets the FK_LU_Event_Type value.
		/// </summary>
		public decimal? FK_LU_Event_Type
		{
			get { return _FK_LU_Event_Type; }
			set { _FK_LU_Event_Type = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsAssoc_Event_Type class with default value.
		/// </summary>
		public clsAssoc_Event_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAssoc_Event_Type class based on Primary Key.
		/// </summary>
		public clsAssoc_Event_Type(decimal pK_Assoc_Event_Type) 
		{
			DataTable dtAssoc_Event_Type = SelectByPK(pK_Assoc_Event_Type).Tables[0];

			if (dtAssoc_Event_Type.Rows.Count == 1)
			{
				 SetValue(dtAssoc_Event_Type.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAssoc_Event_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAssoc_Event_Type) 
		{
				if (drAssoc_Event_Type["PK_Assoc_Event_Type"] == DBNull.Value)
					this._PK_Assoc_Event_Type = null;
				else
					this._PK_Assoc_Event_Type = (decimal?)drAssoc_Event_Type["PK_Assoc_Event_Type"];

				if (drAssoc_Event_Type["FK_Event"] == DBNull.Value)
					this._FK_Event = null;
				else
					this._FK_Event = (decimal?)drAssoc_Event_Type["FK_Event"];

				if (drAssoc_Event_Type["FK_LU_Event_Type"] == DBNull.Value)
					this._FK_LU_Event_Type = null;
				else
					this._FK_LU_Event_Type = (decimal?)drAssoc_Event_Type["FK_LU_Event_Type"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Assoc_Event_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_TypeInsert");

			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);
			
			db.AddInParameter(dbCommand, "FK_LU_Event_Type", DbType.Decimal, this._FK_LU_Event_Type);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Assoc_Event_Type table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Assoc_Event_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_Event_Type", DbType.Decimal, pK_Assoc_Event_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Assoc_Event_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Assoc_Event_Type table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_TypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_Assoc_Event_Type", DbType.Decimal, this._PK_Assoc_Event_Type);
			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);
			
			db.AddInParameter(dbCommand, "FK_LU_Event_Type", DbType.Decimal, this._FK_LU_Event_Type);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Assoc_Event_Type table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Assoc_Event_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_TypeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_Event_Type", DbType.Decimal, pK_Assoc_Event_Type);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the Assoc_Event_Type table by a FK_Event.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_TypeSelectByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectEventTypeByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_TypeSelectByFK_EventforView");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Assoc_Event_Type table by a FK_Event.
        /// </summary>
        public static void DeleteByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Event_TypeDeleteByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
