using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Property_COPE_Saba_Training table.
	/// </summary>
	public sealed class Property_COPE_Saba_Training
	{

        #region Private variables used to hold the property values

        private decimal? _PK_Property_COPE_Saba_Training;
        private decimal? _FK_Property_COPE;
        private DateTime? _Date;
        private int? _Year;
        private int? _Quarter;
        private decimal? _Number_of_Employees;
        private decimal? _Number_Trained;
        private decimal? _Percent_Trained;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Property_COPE_Saba_Training value.
        /// </summary>
        public decimal? PK_Property_COPE_Saba_Training
        {
            get { return _PK_Property_COPE_Saba_Training; }
            set { _PK_Property_COPE_Saba_Training = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Property_COPE value.
        /// </summary>
        public decimal? FK_Property_COPE
        {
            get { return _FK_Property_COPE; }
            set { _FK_Property_COPE = value; }
        }

        /// <summary>
        /// Gets or sets the Date value.
        /// </summary>
        public DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        /// <summary>
        /// Gets or sets the Year value.
        /// </summary>
        public int? Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        /// <summary>
        /// Gets or sets the Quarter value.
        /// </summary>
        public int? Quarter
        {
            get { return _Quarter; }
            set { _Quarter = value; }
        }

        /// <summary>
        /// Gets or sets the Number_of_Employees value.
        /// </summary>
        public decimal? Number_of_Employees
        {
            get { return _Number_of_Employees; }
            set { _Number_of_Employees = value; }
        }

        /// <summary>
        /// Gets or sets the Number_Trained value.
        /// </summary>
        public decimal? Number_Trained
        {
            get { return _Number_Trained; }
            set { _Number_Trained = value; }
        }

        /// <summary>
        /// Gets or sets the Percent_Trained value.
        /// </summary>
        public decimal? Percent_Trained
        {
            get { return _Percent_Trained; }
            set { _Percent_Trained = value; }
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
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Property_COPE_Saba_Training class with default value.
        /// </summary>
        public Property_COPE_Saba_Training()
        {

            this._PK_Property_COPE_Saba_Training = null;
            this._FK_Property_COPE = null;
            this._Date = null;
            this._Year = null;
            this._Quarter = null;
            this._Number_of_Employees = null;
            this._Number_Trained = null;
            this._Percent_Trained = null;
            this._Updated_By = null;
            this._Update_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Property_COPE_Saba_Training class based on Primary Key.
        /// </summary>
        public Property_COPE_Saba_Training(decimal pK_Property_COPE_Saba_Training)
        {
            DataTable dtProperty_COPE_Saba_Training = SelectByPK(pK_Property_COPE_Saba_Training).Tables[0];

            if (dtProperty_COPE_Saba_Training.Rows.Count == 1)
            {
                DataRow drProperty_COPE_Saba_Training = dtProperty_COPE_Saba_Training.Rows[0];
                if (drProperty_COPE_Saba_Training["PK_Property_COPE_Saba_Training"] == DBNull.Value)
                    this._PK_Property_COPE_Saba_Training = null;
                else
                    this._PK_Property_COPE_Saba_Training = (decimal?)drProperty_COPE_Saba_Training["PK_Property_COPE_Saba_Training"];

                if (drProperty_COPE_Saba_Training["FK_Property_COPE"] == DBNull.Value)
                    this._FK_Property_COPE = null;
                else
                    this._FK_Property_COPE = (decimal?)drProperty_COPE_Saba_Training["FK_Property_COPE"];

                if (drProperty_COPE_Saba_Training["Date"] == DBNull.Value)
                    this._Date = null;
                else
                    this._Date = (DateTime?)drProperty_COPE_Saba_Training["Date"];

                if (drProperty_COPE_Saba_Training["Year"] == DBNull.Value)
                    this._Year = null;
                else
                    this._Year = (int?)drProperty_COPE_Saba_Training["Year"];

                if (drProperty_COPE_Saba_Training["Quarter"] == DBNull.Value)
                    this._Quarter = null;
                else
                    this._Quarter = (int?)drProperty_COPE_Saba_Training["Quarter"];

                if (drProperty_COPE_Saba_Training["Number_of_Employees"] == DBNull.Value)
                    this._Number_of_Employees = null;
                else
                    this._Number_of_Employees = (decimal?)drProperty_COPE_Saba_Training["Number_of_Employees"];

                if (drProperty_COPE_Saba_Training["Number_Trained"] == DBNull.Value)
                    this._Number_Trained = null;
                else
                    this._Number_Trained = (decimal?)drProperty_COPE_Saba_Training["Number_Trained"];

                if (drProperty_COPE_Saba_Training["Percent_Trained"] == DBNull.Value)
                    this._Percent_Trained = null;
                else
                    this._Percent_Trained = (decimal?)drProperty_COPE_Saba_Training["Percent_Trained"];

                if (drProperty_COPE_Saba_Training["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drProperty_COPE_Saba_Training["Updated_By"];

                if (drProperty_COPE_Saba_Training["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drProperty_COPE_Saba_Training["Update_Date"];

            }
            else
            {
                this._PK_Property_COPE_Saba_Training = null;
                this._FK_Property_COPE = null;
                this._Date = null;
                this._Year = null;
                this._Quarter = null;
                this._Number_of_Employees = null;
                this._Number_Trained = null;
                this._Percent_Trained = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Property_COPE_Saba_Training table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_Saba_TrainingInsert");


            db.AddInParameter(dbCommand, "FK_Property_COPE", DbType.Decimal, this._FK_Property_COPE);

            db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, this._Quarter);

            db.AddInParameter(dbCommand, "Number_of_Employees", DbType.Decimal, this._Number_of_Employees);

            db.AddInParameter(dbCommand, "Number_Trained", DbType.Decimal, this._Number_Trained);

            db.AddInParameter(dbCommand, "Percent_Trained", DbType.Decimal, this._Percent_Trained);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Property_COPE_Saba_Training table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_Property_COPE_Saba_Training)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_Saba_TrainingSelectByPK");

            db.AddInParameter(dbCommand, "PK_Property_COPE_Saba_Training", DbType.Decimal, pK_Property_COPE_Saba_Training);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Property_COPE_Saba_Training table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_Saba_TrainingSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Property_COPE_Saba_Training table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_Saba_TrainingUpdate");


            db.AddInParameter(dbCommand, "PK_Property_COPE_Saba_Training", DbType.Decimal, this._PK_Property_COPE_Saba_Training);

            db.AddInParameter(dbCommand, "FK_Property_COPE", DbType.Decimal, this._FK_Property_COPE);

            db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, this._Quarter);

            db.AddInParameter(dbCommand, "Number_of_Employees", DbType.Decimal, this._Number_of_Employees);

            db.AddInParameter(dbCommand, "Number_Trained", DbType.Decimal, this._Number_Trained);

            db.AddInParameter(dbCommand, "Percent_Trained", DbType.Decimal, this._Percent_Trained);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the Property_COPE_Saba_Training table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Property_COPE_Saba_Training)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_Saba_TrainingDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Property_COPE_Saba_Training", DbType.Decimal, pK_Property_COPE_Saba_Training);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Property_COPE_Saba_Training table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByProperty_Cope(decimal FK_Property_COPE)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_Saba_TrainingSelectByProperty_Cope");
            db.AddInParameter(dbCommand, "FK_Property_COPE", DbType.Decimal, FK_Property_COPE);
            return db.ExecuteDataSet(dbCommand);
        }

        public Decimal IsDateDuplicate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Saba_Training_Is_DuplicateDate");
            db.AddInParameter(dbCommand, "FK_Property_COPE", DbType.Decimal,this._FK_Property_COPE);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, this._Quarter);
            db.AddInParameter(dbCommand, "PK_Property_COPE_Saba_Training", DbType.Decimal, this._PK_Property_COPE_Saba_Training);
            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }
	}
}
