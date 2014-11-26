using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Executive_Risk_Carrier table.
    /// </summary>
    public sealed class Executive_Risk_Carrier
    {

        #region Fields


        private decimal _PK_Executive_Risk_Carrier;
        private decimal _FK_Executive_Risk;
        private string _Carrier;
        private decimal _FK_Layer;
        private decimal _Limit;
        private string _Contact_Name;
        private string _Contact_Number;
        private string _Claim_Number;
        private string _Notes;
        private string _Updated_By;
        private DateTime _Update_Date;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Executive_Risk_Carrier value.
        /// </summary>
        public decimal PK_Executive_Risk_Carrier
        {
            get { return _PK_Executive_Risk_Carrier; }
            set { _PK_Executive_Risk_Carrier = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Executive_Risk value.
        /// </summary>
        public decimal FK_Executive_Risk
        {
            get { return _FK_Executive_Risk; }
            set { _FK_Executive_Risk = value; }
        }


        /// <summary> 
        /// Gets or sets the Carrier value.
        /// </summary>
        public string Carrier
        {
            get { return _Carrier; }
            set { _Carrier = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Layer value.
        /// </summary>
        public decimal FK_Layer
        {
            get { return _FK_Layer; }
            set { _FK_Layer = value; }
        }


        /// <summary> 
        /// Gets or sets the Limit value.
        /// </summary>
        public decimal Limit
        {
            get { return _Limit; }
            set { _Limit = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Name value.
        /// </summary>
        public string Contact_Name
        {
            get { return _Contact_Name; }
            set { _Contact_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Number value.
        /// </summary>
        public string Contact_Number
        {
            get { return _Contact_Number; }
            set { _Contact_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Number value.
        /// </summary>
        public string Claim_Number
        {
            get { return _Claim_Number; }
            set { _Claim_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Notes value.
        /// </summary>
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Executive_Risk_Carrier class. with the default value.

        /// </summary>
        public Executive_Risk_Carrier()
        {

            this._PK_Executive_Risk_Carrier = -1;
            this._FK_Executive_Risk = -1;
            this._Carrier = "";
            this._FK_Layer = -1;
            this._Limit = -1;
            this._Contact_Name = "";
            this._Contact_Number = "";
            this._Claim_Number = "";
            this._Notes = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 

        /// Initializes a new instance of the Executive_Risk_Carrier class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Executive_Risk_Carrier(decimal PK)
        {

            DataTable dtExecutive_Risk_Carrier = SelectByPK(PK).Tables[0];

            if (dtExecutive_Risk_Carrier.Rows.Count > 0)
            {

                DataRow drExecutive_Risk_Carrier = dtExecutive_Risk_Carrier.Rows[0];

                this._PK_Executive_Risk_Carrier = drExecutive_Risk_Carrier["PK_Executive_Risk_Carrier"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Carrier["PK_Executive_Risk_Carrier"]) : 0;
                this._FK_Executive_Risk = drExecutive_Risk_Carrier["FK_Executive_Risk"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Carrier["FK_Executive_Risk"]) : 0;
                this._Carrier = Convert.ToString(drExecutive_Risk_Carrier["Carrier"]);
                this._FK_Layer = drExecutive_Risk_Carrier["FK_Layer"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Carrier["FK_Layer"]) : 0;
                this._Limit = drExecutive_Risk_Carrier["Limit"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Carrier["Limit"]) : 0;
                this._Contact_Name = Convert.ToString(drExecutive_Risk_Carrier["Contact_Name"]);
                this._Contact_Number = Convert.ToString(drExecutive_Risk_Carrier["Contact_Number"]);
                this._Claim_Number = Convert.ToString(drExecutive_Risk_Carrier["Claim_Number"]);
                this._Notes = Convert.ToString(drExecutive_Risk_Carrier["Notes"]);
                this._Updated_By = Convert.ToString(drExecutive_Risk_Carrier["Updated_By"]);
                this._Update_Date = drExecutive_Risk_Carrier["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk_Carrier["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_Executive_Risk_Carrier = -1;
                this._FK_Executive_Risk = -1;
                this._Carrier = "";
                this._FK_Layer = -1;
                this._Limit = -1;
                this._Contact_Name = "";
                this._Contact_Number = "";
                this._Claim_Number = "";
                this._Notes = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion


        #region "Methods"
        /// <summary>
        /// Inserts a record into the Executive_Risk_Carrier table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_CarrierInsert");

            db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
            db.AddInParameter(dbCommand, "Carrier", DbType.String, this._Carrier);

            if (this._FK_Layer > 0)
                db.AddInParameter(dbCommand, "FK_Layer", DbType.Decimal, this._FK_Layer);
            else
                db.AddInParameter(dbCommand, "FK_Layer", DbType.Decimal, DBNull.Value);

            db.AddInParameter(dbCommand, "Limit", DbType.Decimal, this._Limit);
            db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
            db.AddInParameter(dbCommand, "Contact_Number", DbType.String, this._Contact_Number);
            db.AddInParameter(dbCommand, "Claim_Number", DbType.String, this._Claim_Number);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Executive_Risk_Carrier table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Executive_Risk_Carrier)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_CarrierSelectByPK");

            db.AddInParameter(dbCommand, "PK_Executive_Risk_Carrier", DbType.Decimal, pK_Executive_Risk_Carrier);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Executive_Risk_Carrier table by a foreign key.
        /// </summary>
        /// <param name="fK_Layer"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Layer(decimal fK_Layer)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_CarrierSelectByFK_Layer");

            db.AddInParameter(dbCommand, "FK_Layer", DbType.Decimal, fK_Layer);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Executive_Risk_Carrier table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_CarrierSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Executive_Risk_Carrier table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_CarrierUpdate");

            db.AddInParameter(dbCommand, "PK_Executive_Risk_Carrier", DbType.Decimal, this._PK_Executive_Risk_Carrier);
            db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
            db.AddInParameter(dbCommand, "Carrier", DbType.String, this._Carrier);

            if (this._FK_Layer == -1)
                db.AddInParameter(dbCommand, "FK_Layer", DbType.Decimal, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_Layer", DbType.Decimal, this._FK_Layer);	
           
            db.AddInParameter(dbCommand, "Limit", DbType.Decimal, this._Limit);
            db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
            db.AddInParameter(dbCommand, "Contact_Number", DbType.String, this._Contact_Number);
            db.AddInParameter(dbCommand, "Claim_Number", DbType.String, this._Claim_Number);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Executive_Risk_Carrier table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Executive_Risk_Carrier)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_CarrierDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Executive_Risk_Carrier", DbType.Decimal, pK_Executive_Risk_Carrier);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Executive_Risk_Carrier table by a foreign key.
        /// </summary>
        public static void DeleteByFK_Layer(decimal fK_Layer)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_CarrierDeleteByFK_Layer");

            db.AddInParameter(dbCommand, "FK_Layer", DbType.Decimal, fK_Layer);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Selects records from the Defense_Attorney table by a foreign key.
        /// </summary>
        /// <param name="fK_Executive_Risk"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Executive_Risk(decimal fK_Executive_Risk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_CarrierSelectByFK_Executive_Risk");

            db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, fK_Executive_Risk);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
