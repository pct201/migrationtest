using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Vehicle_Information table.
    /// </summary>
    public sealed class clsVehicle_Information
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Vehicle_Information;
        private string _Make;
        private string _Model;
        private string _Color;
        private string _License;
        private decimal? _FK_LU_State;
        private string _Suspect_Vehicle;
        private decimal? _FK_Event;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Vehicle_Information value.
        /// </summary>
        public decimal? PK_Vehicle_Information
        {
            get { return _PK_Vehicle_Information; }
            set { _PK_Vehicle_Information = value; }
        }

        /// <summary>
        /// Gets or sets the Make value.
        /// </summary>
        public string Make
        {
            get { return _Make; }
            set { _Make = value; }
        }

        /// <summary>
        /// Gets or sets the Model value.
        /// </summary>
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        /// <summary>
        /// Gets or sets the Color value.
        /// </summary>
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        /// <summary>
        /// Gets or sets the License value.
        /// </summary>
        public string License
        {
            get { return _License; }
            set { _License = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_State value.
        /// </summary>
        public decimal? FK_LU_State
        {
            get { return _FK_LU_State; }
            set { _FK_LU_State = value; }
        }

        /// <summary>
        /// Gets or sets the Suspect_Vehicle value.
        /// </summary>
        public string Suspect_Vehicle
        {
            get { return _Suspect_Vehicle; }
            set { _Suspect_Vehicle = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Event value.
        /// </summary>
        public decimal? FK_Event
        {
            get { return _FK_Event; }
            set { _FK_Event = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsVehicle_Information class with default value.
        /// </summary>
        public clsVehicle_Information()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsVehicle_Information class based on Primary Key.
        /// </summary>
        public clsVehicle_Information(decimal pK_Vehicle_Information)
        {
            DataTable dtVehicle_Information = SelectByPK(pK_Vehicle_Information).Tables[0];

            if (dtVehicle_Information.Rows.Count == 1)
            {
                SetValue(dtVehicle_Information.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsVehicle_Information class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drVehicle_Information)
        {
            if (drVehicle_Information["PK_Vehicle_Information"] == DBNull.Value)
                this._PK_Vehicle_Information = null;
            else
                this._PK_Vehicle_Information = (decimal?)drVehicle_Information["PK_Vehicle_Information"];

            if (drVehicle_Information["Make"] == DBNull.Value)
                this._Make = null;
            else
                this._Make = (string)drVehicle_Information["Make"];

            if (drVehicle_Information["Model"] == DBNull.Value)
                this._Model = null;
            else
                this._Model = (string)drVehicle_Information["Model"];

            if (drVehicle_Information["Color"] == DBNull.Value)
                this._Color = null;
            else
                this._Color = (string)drVehicle_Information["Color"];

            if (drVehicle_Information["License"] == DBNull.Value)
                this._License = null;
            else
                this._License = (string)drVehicle_Information["License"];

            if (drVehicle_Information["FK_LU_State"] == DBNull.Value)
                this._FK_LU_State = null;
            else
                this._FK_LU_State = (decimal?)drVehicle_Information["FK_LU_State"];

            if (drVehicle_Information["Suspect_Vehicle"] == DBNull.Value)
                this._Suspect_Vehicle = null;
            else
                this._Suspect_Vehicle = (string)drVehicle_Information["Suspect_Vehicle"];

            if (drVehicle_Information["FK_Event"] == DBNull.Value)
                this._FK_Event = null;
            else
                this._FK_Event = (decimal?)drVehicle_Information["FK_Event"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Vehicle_Information table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_InformationInsert");


            if (string.IsNullOrEmpty(this._Make))
                db.AddInParameter(dbCommand, "Make", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Make", DbType.String, this._Make);

            if (string.IsNullOrEmpty(this._Model))
                db.AddInParameter(dbCommand, "Model", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);

            if (string.IsNullOrEmpty(this._Color))
                db.AddInParameter(dbCommand, "Color", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Color", DbType.String, this._Color);

            if (string.IsNullOrEmpty(this._License))
                db.AddInParameter(dbCommand, "License", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "License", DbType.String, this._License);

            db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, this._FK_LU_State);

            if (string.IsNullOrEmpty(this._Suspect_Vehicle))
                db.AddInParameter(dbCommand, "Suspect_Vehicle", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Suspect_Vehicle", DbType.String, this._Suspect_Vehicle);

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Vehicle_Information table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Vehicle_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_InformationSelectByPK");

            db.AddInParameter(dbCommand, "PK_Vehicle_Information", DbType.Decimal, pK_Vehicle_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Vehicle_Information table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_InformationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Vehicle_Information table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_InformationUpdate");


            db.AddInParameter(dbCommand, "PK_Vehicle_Information", DbType.Decimal, this._PK_Vehicle_Information);

            if (string.IsNullOrEmpty(this._Make))
                db.AddInParameter(dbCommand, "Make", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Make", DbType.String, this._Make);

            if (string.IsNullOrEmpty(this._Model))
                db.AddInParameter(dbCommand, "Model", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);

            if (string.IsNullOrEmpty(this._Color))
                db.AddInParameter(dbCommand, "Color", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Color", DbType.String, this._Color);

            if (string.IsNullOrEmpty(this._License))
                db.AddInParameter(dbCommand, "License", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "License", DbType.String, this._License);

            db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, this._FK_LU_State);

            if (string.IsNullOrEmpty(this._Suspect_Vehicle))
                db.AddInParameter(dbCommand, "Suspect_Vehicle", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Suspect_Vehicle", DbType.String, this._Suspect_Vehicle);

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Vehicle_Information table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Vehicle_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_InformationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Vehicle_Information", DbType.Decimal, pK_Vehicle_Information);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects record from the Vehicle_Information table by FK_Event.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_InformationSelectByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
