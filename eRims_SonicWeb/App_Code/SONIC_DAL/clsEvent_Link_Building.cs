using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Event_Link_Building table.
	/// </summary>
	public sealed class clsEvent_Link_Building
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Event_Link_Building;
		private decimal? _FK_Event;
		private decimal? _Fk_Building;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Event_Link_Building value.
		/// </summary>
		public decimal? PK_Event_Link_Building
		{
			get { return _PK_Event_Link_Building; }
			set { _PK_Event_Link_Building = value; }
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
		/// Gets or sets the Fk_Building value.
		/// </summary>
		public decimal? Fk_Building
		{
			get { return _Fk_Building; }
			set { _Fk_Building = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsEvent_Link_Building class with default value.
		/// </summary>
		public clsEvent_Link_Building() 
		{


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Event_Link_Building table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Event_Link_BuildingInsert");//if record exist then not inserted

			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);
			
			db.AddInParameter(dbCommand, "Fk_Building", DbType.Decimal, this._Fk_Building);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

        /// <summary>
        /// Deletes a record from the Event_Link_Building table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Event_Link_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Link_BuildingDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Event_Link_Building", DbType.Int32, pK_Event_Link_Building);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
