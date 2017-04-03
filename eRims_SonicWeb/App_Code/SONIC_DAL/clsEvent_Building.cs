using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Event_Building table.
	/// </summary>
	public sealed class clsEvent_Building
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Event_Building;
		private decimal? _FK_Event;
		private string _Building_Description;
		private string _Restricted;
		private string _Exterior_Interior;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Event_Building value.
		/// </summary>
		public decimal? PK_Event_Building
		{
			get { return _PK_Event_Building; }
			set { _PK_Event_Building = value; }
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
		/// Gets or sets the Building_Description value.
		/// </summary>
		public string Building_Description
		{
			get { return _Building_Description; }
			set { _Building_Description = value; }
		}

		/// <summary>
		/// Gets or sets the Restricted value.
		/// </summary>
		public string Restricted
		{
			get { return _Restricted; }
			set { _Restricted = value; }
		}

		/// <summary>
		/// Gets or sets the Exterior_Interior value.
		/// </summary>
		public string Exterior_Interior
		{
			get { return _Exterior_Interior; }
			set { _Exterior_Interior = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsEvent_Building class with default value.
		/// </summary>
		public clsEvent_Building() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsEvent_Building class based on Primary Key.
		/// </summary>
		public clsEvent_Building(decimal pK_Event_Building) 
		{
			DataTable dtEvent_Building = SelectByPK(pK_Event_Building).Tables[0];

			if (dtEvent_Building.Rows.Count == 1)
			{
				 SetValue(dtEvent_Building.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsEvent_Building class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drEvent_Building) 
		{
				if (drEvent_Building["PK_Event_Building"] == DBNull.Value)
					this._PK_Event_Building = null;
				else
					this._PK_Event_Building = (decimal?)drEvent_Building["PK_Event_Building"];

				if (drEvent_Building["FK_Event"] == DBNull.Value)
					this._FK_Event = null;
				else
					this._FK_Event = (decimal?)drEvent_Building["FK_Event"];

				if (drEvent_Building["Building_Description"] == DBNull.Value)
					this._Building_Description = null;
				else
					this._Building_Description = (string)drEvent_Building["Building_Description"];

				if (drEvent_Building["Restricted"] == DBNull.Value)
					this._Restricted = null;
				else
					this._Restricted = (string)drEvent_Building["Restricted"];

				if (drEvent_Building["Exterior_Interior"] == DBNull.Value)
					this._Exterior_Interior = null;
				else
					this._Exterior_Interior = (string)drEvent_Building["Exterior_Interior"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Event_Building table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_BuildingInsert");

			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);
			
			if (string.IsNullOrEmpty(this._Building_Description))
				db.AddInParameter(dbCommand, "Building_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Building_Description", DbType.String, this._Building_Description);
			
			if (string.IsNullOrEmpty(this._Restricted))
				db.AddInParameter(dbCommand, "Restricted", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Restricted", DbType.String, this._Restricted);
			
			if (string.IsNullOrEmpty(this._Exterior_Interior))
				db.AddInParameter(dbCommand, "Exterior_Interior", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Exterior_Interior", DbType.String, this._Exterior_Interior);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Event_Building table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Event_Building)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_BuildingSelectByPK");

			db.AddInParameter(dbCommand, "PK_Event_Building", DbType.Decimal, pK_Event_Building);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Event_Building table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_BuildingSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Event_Building table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_BuildingUpdate");

			
			db.AddInParameter(dbCommand, "PK_Event_Building", DbType.Decimal, this._PK_Event_Building);
			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);
			
			if (string.IsNullOrEmpty(this._Building_Description))
				db.AddInParameter(dbCommand, "Building_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Building_Description", DbType.String, this._Building_Description);
			
			if (string.IsNullOrEmpty(this._Restricted))
				db.AddInParameter(dbCommand, "Restricted", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Restricted", DbType.String, this._Restricted);
			
			if (string.IsNullOrEmpty(this._Exterior_Interior))
				db.AddInParameter(dbCommand, "Exterior_Interior", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Exterior_Interior", DbType.String, this._Exterior_Interior);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Event_Building table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Event_Building)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_BuildingDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Event_Building", DbType.Decimal, pK_Event_Building);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingSelectByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
