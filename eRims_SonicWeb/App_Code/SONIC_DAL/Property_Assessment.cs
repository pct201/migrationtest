using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Property_Assessment table.
    /// </summary>
    public sealed class Property_Assessment
    {
        #region Fields


        private int _PK_Property_Assessment_ID;
        private int _FK_LU_Location_ID;
        private DateTime _Date;
        private string _Assessor;
        private string _Contact_Name;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private string _State;
        private string _Zip;
        private string _Telephone;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Property_Assessment_ID value.
        /// </summary>
        public int PK_Property_Assessment_ID
        {
            get { return _PK_Property_Assessment_ID; }
            set { _PK_Property_Assessment_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public int FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Date value.
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Assessor value.
        /// </summary>
        public string Assessor
        {
            get { return _Assessor; }
            set { _Assessor = value; }
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
        /// Gets or sets the Telephone value.
        /// </summary>
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
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

        /// Initializes a new instance of the Property_Assessment class. with the default value.

        /// </summary>
        public Property_Assessment()
        {

            this._PK_Property_Assessment_ID = -1;
            this._FK_LU_Location_ID = -1;
            this._Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Assessor = "";
            this._Contact_Name = "";
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._State = "";
            this._Zip = "";
            this._Telephone = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 

        /// Initializes a new instance of the Property_Assessment class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Property_Assessment(int PK)
        {

            DataTable dtProperty_Assessment = SelectByPK(PK).Tables[0];

            if (dtProperty_Assessment.Rows.Count > 0)
            {

                DataRow drProperty_Assessment = dtProperty_Assessment.Rows[0];

                this._PK_Property_Assessment_ID = drProperty_Assessment["PK_Property_Assessment_ID"] != DBNull.Value ? Convert.ToInt32(drProperty_Assessment["PK_Property_Assessment_ID"]) : 0;
                this._FK_LU_Location_ID = drProperty_Assessment["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToInt32(drProperty_Assessment["FK_LU_Location_ID"]) : 0;
                this._Date = drProperty_Assessment["Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_Assessment["Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Assessor = Convert.ToString(drProperty_Assessment["Assessor"]);
                this._Contact_Name = Convert.ToString(drProperty_Assessment["Contact_Name"]);
                this._Address_1 = Convert.ToString(drProperty_Assessment["Address_1"]);
                this._Address_2 = Convert.ToString(drProperty_Assessment["Address_2"]);
                this._City = Convert.ToString(drProperty_Assessment["City"]);
                this._State = Convert.ToString(drProperty_Assessment["State"]);
                this._Zip = Convert.ToString(drProperty_Assessment["Zip"]);
                this._Telephone = Convert.ToString(drProperty_Assessment["Telephone"]);
                this._Updated_By = drProperty_Assessment["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drProperty_Assessment["Updated_By"]) : 0;
                this._Updated_Date = drProperty_Assessment["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_Assessment["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

            else
            {

                this._PK_Property_Assessment_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Assessor = "";
                this._Contact_Name = "";
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._State = "";
                this._Zip = "";
                this._Telephone = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }



        #endregion

        #region Methods

        /// <summary>
        /// Inserts a record into the Property_Assessment table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AssessmentInsert");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);

            if (this._Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
            else
                db.AddInParameter(dbCommand, "Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Assessor", DbType.String, this._Assessor);
            db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, this._City);
            db.AddInParameter(dbCommand, "State", DbType.String, this._State);
            db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
            db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Property_Assessment table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Property_Assessment_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AssessmentSelectByPK");

            db.AddInParameter(dbCommand, "PK_Property_Assessment_ID", DbType.Int32, pK_Property_Assessment_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Property_Assessment table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AssessmentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Property_Assessment table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AssessmentUpdate");

            db.AddInParameter(dbCommand, "PK_Property_Assessment_ID", DbType.Int32, this._PK_Property_Assessment_ID);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);

            if (this._Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
            else
                db.AddInParameter(dbCommand, "Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Assessor", DbType.String, this._Assessor);
            db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
            db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
            db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
            db.AddInParameter(dbCommand, "City", DbType.String, this._City);
            db.AddInParameter(dbCommand, "State", DbType.String, this._State);
            db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
            db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Property_Assessment table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Property_Assessment_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AssessmentDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Property_Assessment_ID", DbType.Int32, pK_Property_Assessment_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFK(int fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AssessmentSelectByFK");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);

        }

        #endregion
    }
}
