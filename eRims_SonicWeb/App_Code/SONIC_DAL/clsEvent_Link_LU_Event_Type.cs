using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Event_Link_LU_Event_Type table.
    /// </summary>
    public sealed class clsEvent_Link_LU_Event_Type
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Event_Link_LU_Event_Type;
        private decimal? _FK_Event;
        private decimal? _FK_LU_Event_Type;
        private string _Description;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Event_Link_LU_Event_Type value.
        /// </summary>
        public decimal? PK_Event_Link_LU_Event_Type
        {
            get { return _PK_Event_Link_LU_Event_Type; }
            set { _PK_Event_Link_LU_Event_Type = value; }
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

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsEvent_Link_LU_Event_Type class with default value.
        /// </summary>
        public clsEvent_Link_LU_Event_Type()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEvent_Link_LU_Event_Type class based on Primary Key.
        /// </summary>
        public clsEvent_Link_LU_Event_Type(decimal pK_Event_Link_LU_Event_Type)
        {
            DataTable dtEvent_Link_LU_Event_Type = SelectByPK(pK_Event_Link_LU_Event_Type).Tables[0];

            if (dtEvent_Link_LU_Event_Type.Rows.Count == 1)
            {
                SetValue(dtEvent_Link_LU_Event_Type.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEvent_Link_LU_Event_Type class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEvent_Link_LU_Event_Type)
        {
            if (drEvent_Link_LU_Event_Type["PK_Event_Link_LU_Event_Type"] == DBNull.Value)
                this._PK_Event_Link_LU_Event_Type = null;
            else
                this._PK_Event_Link_LU_Event_Type = (decimal?)drEvent_Link_LU_Event_Type["PK_Event_Link_LU_Event_Type"];

            if (drEvent_Link_LU_Event_Type["FK_Event"] == DBNull.Value)
                this._FK_Event = null;
            else
                this._FK_Event = (decimal?)drEvent_Link_LU_Event_Type["FK_Event"];

            if (drEvent_Link_LU_Event_Type["FK_LU_Event_Type"] == DBNull.Value)
                this._FK_LU_Event_Type = null;
            else
                this._FK_LU_Event_Type = (decimal?)drEvent_Link_LU_Event_Type["FK_LU_Event_Type"];

            if (drEvent_Link_LU_Event_Type["Description"] == DBNull.Value)
                this._Description = null;
            else
                this._Description = (string)drEvent_Link_LU_Event_Type["Description"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Event_Link_LU_Event_Type table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Link_LU_Event_TypeInsert");


            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            db.AddInParameter(dbCommand, "FK_LU_Event_Type", DbType.Decimal, this._FK_LU_Event_Type);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
            dbCommand.CommandTimeout = 50000;
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Event_Link_LU_Event_Type table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Event_Link_LU_Event_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Link_LU_Event_TypeSelectByPK");

            db.AddInParameter(dbCommand, "PK_Event_Link_LU_Event_Type", DbType.Decimal, pK_Event_Link_LU_Event_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Event_Link_LU_Event_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Link_LU_Event_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Event_Link_LU_Event_Type table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Link_LU_Event_TypeUpdate");


            db.AddInParameter(dbCommand, "PK_Event_Link_LU_Event_Type", DbType.Decimal, this._PK_Event_Link_LU_Event_Type);

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            db.AddInParameter(dbCommand, "FK_LU_Event_Type", DbType.Decimal, this._FK_LU_Event_Type);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            dbCommand.CommandTimeout = 50000;
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Event_Link_LU_Event_Type table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Event_Link_LU_Event_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Link_LU_Event_TypeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Event_Link_LU_Event_Type", DbType.Decimal, pK_Event_Link_LU_Event_Type);

            dbCommand.CommandTimeout = 50000;
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Event_Link_LU_Event_Type table by FK_Event.
        /// </summary>
        public static void DeleteByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Link_LU_Event_TypeDeleteByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Event_Link_LU_Event_Type table by a FK_Event.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_Link_LU_Event_TypeSelectByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
