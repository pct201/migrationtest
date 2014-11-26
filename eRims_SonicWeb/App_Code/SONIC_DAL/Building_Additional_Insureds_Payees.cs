using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Building_Additional_Insureds_Payees table.
    /// </summary>
    public sealed class Building_Additional_Insureds_Payees
    {
        #region Fields


        private int _PK_Building_Additional_Insureds_Payees_ID;
        private int _FK_Building_ID;
        private string _Insured_Payee;
        private string _Named;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private string _State;
        private string _Zip;
        private string _Type;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Building_Additional_Insureds_Payees_ID value.
        /// </summary>
        public int PK_Building_Additional_Insureds_Payees_ID
        {
            get { return _PK_Building_Additional_Insureds_Payees_ID; }
            set { _PK_Building_Additional_Insureds_Payees_ID = value; }
        }
        /// <summary> 
        /// Gets or sets the FK_Building_ID value.
        /// </summary>
        public int FK_Building_ID
        {
            get { return _FK_Building_ID; }
            set { _FK_Building_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Insured_Payee value.
        /// </summary>
        public string Insured_Payee
        {
            get { return _Insured_Payee; }
            set { _Insured_Payee = value; }
        }


        /// <summary> 
        /// Gets or sets the Named value.
        /// </summary>
        public string Named
        {
            get { return _Named; }
            set { _Named = value; }
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
        /// Gets or sets the Type value.
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }


        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Building_Additional_Insureds_Payees class. with the default value.

        /// </summary>
        public Building_Additional_Insureds_Payees()
        {

            this._PK_Building_Additional_Insureds_Payees_ID = -1;
            this._FK_Building_ID = -1;
            this._Insured_Payee = "";
            this._Named = "";
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._State = "";
            this._Zip = "";
            this._Type = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }



        /// <summary> 

        /// Initializes a new instance of the Building_Additional_Insureds_Payees class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Building_Additional_Insureds_Payees(int PK)
        {

            DataTable dtBuilding_Additional_Insureds_Payees = SelectByPK(PK).Tables[0];

            if (dtBuilding_Additional_Insureds_Payees.Rows.Count > 0)
            {

                DataRow drBuilding_Additional_Insureds_Payees = dtBuilding_Additional_Insureds_Payees.Rows[0];

                this._PK_Building_Additional_Insureds_Payees_ID = drBuilding_Additional_Insureds_Payees["PK_Building_Additional_Insureds_Payees_ID"] != DBNull.Value ? Convert.ToInt32(drBuilding_Additional_Insureds_Payees["PK_Building_Additional_Insureds_Payees_ID"]) :
                this._FK_Building_ID = drBuilding_Additional_Insureds_Payees["FK_Building_ID"] != DBNull.Value ? Convert.ToInt32(drBuilding_Additional_Insureds_Payees["FK_Building_ID"]) : 0;
                this._Insured_Payee = Convert.ToString(drBuilding_Additional_Insureds_Payees["Insured_Payee"]);
                this._Named = Convert.ToString(drBuilding_Additional_Insureds_Payees["Named"]);
                this._Address_1 = Convert.ToString(drBuilding_Additional_Insureds_Payees["Address_1"]);
                this._Address_2 = Convert.ToString(drBuilding_Additional_Insureds_Payees["Address_2"]);
                this._City = Convert.ToString(drBuilding_Additional_Insureds_Payees["City"]);
                this._State = Convert.ToString(drBuilding_Additional_Insureds_Payees["State"]);
                this._Zip = Convert.ToString(drBuilding_Additional_Insureds_Payees["Zip"]);
                this._Type = Convert.ToString(drBuilding_Additional_Insureds_Payees["Type"]);
                this._Updated_By = drBuilding_Additional_Insureds_Payees["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drBuilding_Additional_Insureds_Payees["Updated_By"]) : 0;
                this._Updated_Date = drBuilding_Additional_Insureds_Payees["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Additional_Insureds_Payees["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

            else
            {

                this._PK_Building_Additional_Insureds_Payees_ID = -1;
                this._FK_Building_ID = -1;
                this._Insured_Payee = "";
                this._Named = "";
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._State = "";
                this._Zip = "";
                this._Type = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the Building_Additional_Insureds_Payees table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Additional_Insureds_PayeesInsert");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, this._FK_Building_ID);
            db.AddInParameter(dbCommand, "Insured_Payee", DbType.String, this._Insured_Payee);
            db.AddInParameter(dbCommand, "Named", DbType.String, this._Named);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, this._City);
            db.AddInParameter(dbCommand, "State", DbType.String, this._State);
            db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Building_Additional_Insureds_Payees table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Building_Additional_Insureds_Payees_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Additional_Insureds_PayeesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Building_Additional_Insureds_Payees_ID", DbType.Int32, pK_Building_Additional_Insureds_Payees_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Building_Additional_Insureds_Payees table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Additional_Insureds_PayeesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Building_Additional_Insureds_Payees table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Additional_Insureds_PayeesUpdate");

            db.AddInParameter(dbCommand, "PK_Building_Additional_Insureds_Payees_ID", DbType.Int32, this._PK_Building_Additional_Insureds_Payees_ID);
            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, this._FK_Building_ID);
            db.AddInParameter(dbCommand, "Insured_Payee", DbType.String, this._Insured_Payee);
            db.AddInParameter(dbCommand, "Named", DbType.String, this._Named);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, this._City);
            db.AddInParameter(dbCommand, "State", DbType.String, this._State);
            db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Building_Additional_Insureds_Payees table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Building_Additional_Insureds_Payees_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Additional_Insureds_PayeesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Building_Additional_Insureds_Payees_ID", DbType.Int32, pK_Building_Additional_Insureds_Payees_ID);

            db.ExecuteNonQuery(dbCommand);
        }



        public static DataSet SelectInsureds(int fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Additional_Insureds_PayeesSelectInsureds");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectPayees(int fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Additional_Insureds_PayeesSelectPayees");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }


        #endregion
    }
}
