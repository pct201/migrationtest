using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table Facility_Construction_Inspection_Item
    /// </summary>
    public sealed class Facility_Construction_Inspection_Item
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Facility_Construction_Inspection_Item;
        private decimal? _FK_Facility_Construction_Inspection;
        private decimal? _FK_Facility_Inspection_Area;
        private decimal? _FK_Facility_Inspection_Item;
        private decimal? _FK_Facility_Inspection_Condition;
        private decimal? _Estimated_Cost;
        private DateTime? _Estimate_Start_Date;
        private decimal? _FK_Assigned_To;
        private string _Assigned_To_Table;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Facility_Construction_Inspection_Item value.
        /// </summary>
        public decimal? PK_Facility_Construction_Inspection_Item
        {
            get { return _PK_Facility_Construction_Inspection_Item; }
            set { _PK_Facility_Construction_Inspection_Item = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Construction_Inspection value.
        /// </summary>
        public decimal? FK_Facility_Construction_Inspection
        {
            get { return _FK_Facility_Construction_Inspection; }
            set { _FK_Facility_Construction_Inspection = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Inspection_Area value.
        /// </summary>
        public decimal? FK_Facility_Inspection_Area
        {
            get { return _FK_Facility_Inspection_Area; }
            set { _FK_Facility_Inspection_Area = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Inspection_Item value.
        /// </summary>
        public decimal? FK_Facility_Inspection_Item
        {
            get { return _FK_Facility_Inspection_Item; }
            set { _FK_Facility_Inspection_Item = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Inspection_Condition value.
        /// </summary>
        public decimal? FK_Facility_Inspection_Condition
        {
            get { return _FK_Facility_Inspection_Condition; }
            set { _FK_Facility_Inspection_Condition = value; }
        }

        /// <summary>
        /// Gets or sets the Estimated_Cost value.
        /// </summary>
        public decimal? Estimated_Cost
        {
            get { return _Estimated_Cost; }
            set { _Estimated_Cost = value; }
        }

        /// <summary>
        /// Gets or sets the Estimate_Start_Date value.
        /// </summary>
        public DateTime? Estimate_Start_Date
        {
            get { return _Estimate_Start_Date; }
            set { _Estimate_Start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Assigned_To value.
        /// </summary>
        public decimal? FK_Assigned_To
        {
            get { return _FK_Assigned_To; }
            set { _FK_Assigned_To = value; }
        }

        /// <summary>
        /// Gets or sets the Assigned_To_Table value.
        /// </summary>
        public string Assigned_To_Table
        {
            get { return _Assigned_To_Table; }
            set { _Assigned_To_Table = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Inspection_Item class with default value.
        /// </summary>
        public Facility_Construction_Inspection_Item()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Inspection_Item class based on Primary Key.
        /// </summary>
        public Facility_Construction_Inspection_Item(decimal pK_Facility_Construction_Inspection_Item)
        {
            DataTable dtFacility_Construction_Inspection_Item = Select(pK_Facility_Construction_Inspection_Item).Tables[0];

            if (dtFacility_Construction_Inspection_Item.Rows.Count == 1)
            {
                SetValue(dtFacility_Construction_Inspection_Item.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Inspection_Item class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drFacility_Construction_Inspection_Item)
        {
            if (drFacility_Construction_Inspection_Item["PK_Facility_Construction_Inspection_Item"] == DBNull.Value)
                this._PK_Facility_Construction_Inspection_Item = null;
            else
                this._PK_Facility_Construction_Inspection_Item = (decimal?)drFacility_Construction_Inspection_Item["PK_Facility_Construction_Inspection_Item"];

            if (drFacility_Construction_Inspection_Item["FK_Facility_Construction_Inspection"] == DBNull.Value)
                this._FK_Facility_Construction_Inspection = null;
            else
                this._FK_Facility_Construction_Inspection = (decimal?)drFacility_Construction_Inspection_Item["FK_Facility_Construction_Inspection"];

            if (drFacility_Construction_Inspection_Item["FK_Facility_Inspection_Area"] == DBNull.Value)
                this._FK_Facility_Inspection_Area = null;
            else
                this._FK_Facility_Inspection_Area = (decimal?)drFacility_Construction_Inspection_Item["FK_Facility_Inspection_Area"];

            if (drFacility_Construction_Inspection_Item["FK_Facility_Inspection_Item"] == DBNull.Value)
                this._FK_Facility_Inspection_Item = null;
            else
                this._FK_Facility_Inspection_Item = (decimal?)drFacility_Construction_Inspection_Item["FK_Facility_Inspection_Item"];

            if (drFacility_Construction_Inspection_Item["FK_Facility_Inspection_Condition"] == DBNull.Value)
                this._FK_Facility_Inspection_Condition = null;
            else
                this._FK_Facility_Inspection_Condition = (decimal?)drFacility_Construction_Inspection_Item["FK_Facility_Inspection_Condition"];

            if (drFacility_Construction_Inspection_Item["Estimated_Cost"] == DBNull.Value)
                this._Estimated_Cost = null;
            else
                this._Estimated_Cost = (decimal?)drFacility_Construction_Inspection_Item["Estimated_Cost"];

            if (drFacility_Construction_Inspection_Item["Estimate_Start_Date"] == DBNull.Value)
                this._Estimate_Start_Date = null;
            else
                this._Estimate_Start_Date = (DateTime?)drFacility_Construction_Inspection_Item["Estimate_Start_Date"];

            if (drFacility_Construction_Inspection_Item["FK_Assigned_To"] == DBNull.Value)
                this._FK_Assigned_To = null;
            else
                this._FK_Assigned_To = (decimal?)drFacility_Construction_Inspection_Item["FK_Assigned_To"];

            if (drFacility_Construction_Inspection_Item["Assigned_To_Table"] == DBNull.Value)
                this._Assigned_To_Table = null;
            else
                this._Assigned_To_Table = (string)drFacility_Construction_Inspection_Item["Assigned_To_Table"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Facility_Construction_Inspection_Item table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Inspection_ItemInsert");


            db.AddInParameter(dbCommand, "FK_Facility_Construction_Inspection", DbType.Decimal, this._FK_Facility_Construction_Inspection);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Area", DbType.Decimal, this._FK_Facility_Inspection_Area);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Item", DbType.Decimal, this._FK_Facility_Inspection_Item);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Condition", DbType.Decimal, this._FK_Facility_Inspection_Condition);

            if (this._Estimated_Cost > -1)
            {
                db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, this._Estimated_Cost);
            }
            else
            {
                db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, DBNull.Value);
            }

            if (this._Estimate_Start_Date != DateTime.MinValue)
            {
                db.AddInParameter(dbCommand, "Estimate_Start_Date", DbType.DateTime, this._Estimate_Start_Date);
            }
            else
            {
                db.AddInParameter(dbCommand, "Estimate_Start_Date", DbType.DateTime, DBNull.Value);
            }

            db.AddInParameter(dbCommand, "FK_Assigned_To", DbType.Decimal, this._FK_Assigned_To);

            if (string.IsNullOrEmpty(this._Assigned_To_Table))
                db.AddInParameter(dbCommand, "Assigned_To_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Assigned_To_Table", DbType.String, this._Assigned_To_Table);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Facility_Construction_Inspection_Item table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_Facility_Construction_Inspection_Item)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Inspection_ItemSelect");

            db.AddInParameter(dbCommand, "PK_Facility_Construction_Inspection_Item", DbType.Decimal, pK_Facility_Construction_Inspection_Item);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Facility_Construction_Inspection_Item table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Inspection_ItemSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Facility_Construction_Inspection_Item table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Inspection_ItemUpdate");


            db.AddInParameter(dbCommand, "PK_Facility_Construction_Inspection_Item", DbType.Decimal, this._PK_Facility_Construction_Inspection_Item);

            db.AddInParameter(dbCommand, "FK_Facility_Construction_Inspection", DbType.Decimal, this._FK_Facility_Construction_Inspection);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Area", DbType.Decimal, this._FK_Facility_Inspection_Area);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Item", DbType.Decimal, this._FK_Facility_Inspection_Item);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Condition", DbType.Decimal, this._FK_Facility_Inspection_Condition);

            if (this._Estimated_Cost > -1)
            {
                db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, this._Estimated_Cost);
            }
            else
            {
                db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, DBNull.Value);
            }

            if (this._Estimate_Start_Date != DateTime.MinValue)
            {
                db.AddInParameter(dbCommand, "Estimate_Start_Date", DbType.DateTime, this._Estimate_Start_Date);
            }
            else
            {
                db.AddInParameter(dbCommand, "Estimate_Start_Date", DbType.DateTime, DBNull.Value);
            }

            db.AddInParameter(dbCommand, "FK_Assigned_To", DbType.Decimal, this._FK_Assigned_To);

            if (string.IsNullOrEmpty(this._Assigned_To_Table))
                db.AddInParameter(dbCommand, "Assigned_To_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Assigned_To_Table", DbType.String, this._Assigned_To_Table);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Facility_Construction_Inspection_Item table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pK_Facility_Construction_Inspection_Item)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Inspection_ItemDelete");

            db.AddInParameter(dbCommand, "PK_Facility_Construction_Inspection_Item", DbType.Decimal, pK_Facility_Construction_Inspection_Item);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Facility_Construction_Inspection_Item table by a foreign key.
        /// </summary>
        public static void DeleteByFKInspection(decimal fK_Facility_Construction_Inspection)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Inspection_ItemDeleteByFKInspection");

            db.AddInParameter(dbCommand, "FK_Facility_Construction_Inspection", DbType.Decimal, fK_Facility_Construction_Inspection);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
