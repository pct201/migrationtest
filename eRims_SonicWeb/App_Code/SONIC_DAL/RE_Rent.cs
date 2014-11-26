using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for RE_Rent table.
    /// </summary>
    public sealed class RE_Rent
    {

        #region Private variables used to hold the property values

        private decimal? _PK_RE_Rent;
        private decimal? _FK_RE_Information;
        private string _Responsible_Party;
        private string _Cancel_Options;
        private string _Renew_Options;
        private string _Rent_Adjustments;
        private DateTime? _Notification_Due_Date;
        private decimal? _Subtenant_Base_Rent;
        private decimal? _Subtenant_Monthly_Rent;
        private decimal? _FK_LU_Escalation;
        private decimal? _Percentage_Rate;
        private decimal? _Increase;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _Rent_Details;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_RE_Rent value.
        /// </summary>
        public decimal? PK_RE_Rent
        {
            get { return _PK_RE_Rent; }
            set { _PK_RE_Rent = value; }
        }

        /// <summary>
        /// Gets or sets the FK_RE_Information value.
        /// </summary>
        public decimal? FK_RE_Information
        {
            get { return _FK_RE_Information; }
            set { _FK_RE_Information = value; }
        }

        /// <summary>
        /// Gets or sets the Responsible_Party value.
        /// </summary>
        public string Responsible_Party
        {
            get { return _Responsible_Party; }
            set { _Responsible_Party = value; }
        }

        /// <summary>
        /// Gets or sets the Responsible_Party value.
        /// </summary>
        public string Rent_Details
        {
            get { return _Rent_Details ; }
            set { _Rent_Details = value; }
        }

        /// <summary>
        /// Gets or sets the Cancel_Options value.
        /// </summary>
        public string Cancel_Options
        {
            get { return _Cancel_Options; }
            set { _Cancel_Options = value; }
        }

        /// <summary>
        /// Gets or sets the Renew_Options value.
        /// </summary>
        public string Renew_Options
        {
            get { return _Renew_Options; }
            set { _Renew_Options = value; }
        }

        /// <summary>
        /// Gets or sets the Rent_Adjustments value.
        /// </summary>
        public string Rent_Adjustments
        {
            get { return _Rent_Adjustments; }
            set { _Rent_Adjustments = value; }
        }

        /// <summary>
        /// Gets or sets the Notification_Due_Date value.
        /// </summary>
        public DateTime? Notification_Due_Date
        {
            get { return _Notification_Due_Date; }
            set { _Notification_Due_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Subtenant_Base_Rent value.
        /// </summary>
        public decimal? Subtenant_Base_Rent
        {
            get { return _Subtenant_Base_Rent; }
            set { _Subtenant_Base_Rent = value; }
        }

        /// <summary>
        /// Gets or sets the Subtenant_Monthly_Rent value.
        /// </summary>
        public decimal? Subtenant_Monthly_Rent
        {
            get { return _Subtenant_Monthly_Rent; }
            set { _Subtenant_Monthly_Rent = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Escalation value.
        /// </summary>
        public decimal? FK_LU_Escalation
        {
            get { return _FK_LU_Escalation; }
            set { _FK_LU_Escalation = value; }
        }

        /// <summary>
        /// Gets or sets the Percentage_Rate value.
        /// </summary>
        public decimal? Percentage_Rate
        {
            get { return _Percentage_Rate; }
            set { _Percentage_Rate = value; }
        }

        /// <summary>
        /// Gets or sets the Increase value.
        /// </summary>
        public decimal? Increase
        {
            get { return _Increase; }
            set { _Increase = value; }
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
        /// Initializes a new instance of the RE_Rent class with default value.
        /// </summary>
        public RE_Rent()
        {

            this._PK_RE_Rent = null;
            this._FK_RE_Information = null;
            this._Responsible_Party = null;
            this._Cancel_Options = null;
            this._Renew_Options = null;
            this._Rent_Adjustments = null;
            this._Notification_Due_Date = null;
            this._Subtenant_Base_Rent = null;
            this._Subtenant_Monthly_Rent = null;
            this._FK_LU_Escalation = null;
            this._Percentage_Rate = null;
            this._Increase = null;
            this._Updated_By = null;
            this._Update_Date = null;
            this._Rent_Details = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Rent class based on Primary Key.
        /// </summary>
        public RE_Rent(decimal pK_RE_Rent)
        {
            DataTable dtRE_Rent = SelectByPK(pK_RE_Rent).Tables[0];

            if (dtRE_Rent.Rows.Count == 1)
            {
                DataRow drRE_Rent = dtRE_Rent.Rows[0];
                if (drRE_Rent["PK_RE_Rent"] == DBNull.Value)
                    this._PK_RE_Rent = null;
                else
                    this._PK_RE_Rent = (decimal?)drRE_Rent["PK_RE_Rent"];

                if (drRE_Rent["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Rent["FK_RE_Information"];

                if (drRE_Rent["Responsible_Party"] == DBNull.Value)
                    this._Responsible_Party = null;
                else
                    this._Responsible_Party = (string)drRE_Rent["Responsible_Party"];

                if (drRE_Rent["Cancel_Options"] == DBNull.Value)
                    this._Cancel_Options = null;
                else
                    this._Cancel_Options = (string)drRE_Rent["Cancel_Options"];

                if (drRE_Rent["Renew_Options"] == DBNull.Value)
                    this._Renew_Options = null;
                else
                    this._Renew_Options = (string)drRE_Rent["Renew_Options"];

                if (drRE_Rent["Rent_Details"] == DBNull.Value)
                    this._Rent_Details  = null;
                else
                    this._Rent_Details = (string)drRE_Rent["Rent_Details"];

                if (drRE_Rent["Rent_Adjustments"] == DBNull.Value)
                    this._Rent_Adjustments = null;
                else
                    this._Rent_Adjustments = (string)drRE_Rent["Rent_Adjustments"];

                if (drRE_Rent["Notification_Due_Date"] == DBNull.Value)
                    this._Notification_Due_Date = null;
                else
                    this._Notification_Due_Date = (DateTime?)drRE_Rent["Notification_Due_Date"];

                if (drRE_Rent["Subtenant_Base_Rent"] == DBNull.Value)
                    this._Subtenant_Base_Rent = null;
                else
                    this._Subtenant_Base_Rent = (decimal?)drRE_Rent["Subtenant_Base_Rent"];

                if (drRE_Rent["Subtenant_Monthly_Rent"] == DBNull.Value)
                    this._Subtenant_Monthly_Rent = null;
                else
                    this._Subtenant_Monthly_Rent = (decimal?)drRE_Rent["Subtenant_Monthly_Rent"];

                if (drRE_Rent["FK_LU_Escalation"] == DBNull.Value)
                    this._FK_LU_Escalation = null;
                else
                    this._FK_LU_Escalation = (decimal?)drRE_Rent["FK_LU_Escalation"];

                if (drRE_Rent["Percentage_Rate"] == DBNull.Value)
                    this._Percentage_Rate = null;
                else
                    this._Percentage_Rate = (decimal?)drRE_Rent["Percentage_Rate"];

                if (drRE_Rent["Increase"] == DBNull.Value)
                    this._Increase = null;
                else
                    this._Increase = (decimal?)drRE_Rent["Increase"];

                if (drRE_Rent["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Rent["Updated_By"];

                if (drRE_Rent["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Rent["Update_Date"];

            }
            else
            {
                this._PK_RE_Rent = null;
                this._FK_RE_Information = null;
                this._Responsible_Party = null;
                this._Cancel_Options = null;
                this._Renew_Options = null;
                this._Rent_Adjustments = null;
                this._Notification_Due_Date = null;
                this._Subtenant_Base_Rent = null;
                this._Subtenant_Monthly_Rent = null;
                this._FK_LU_Escalation = null;
                this._Percentage_Rate = null;
                this._Increase = null;
                this._Updated_By = null;
                this._Update_Date = null;
                this._Rent_Details = null;
            }

        }

        /// <summary>
        /// Initializes a new instance of the RE_Rent class based on Primary Key.
        /// </summary>
        public RE_Rent(decimal FK_RE_Information, bool status)
        {
            DataTable dtRE_Rent = SelectByFK(FK_RE_Information).Tables[0];

            if (dtRE_Rent.Rows.Count == 1)
            {
                DataRow drRE_Rent = dtRE_Rent.Rows[0];
                if (drRE_Rent["PK_RE_Rent"] == DBNull.Value)
                    this._PK_RE_Rent = null;
                else
                    this._PK_RE_Rent = (decimal?)drRE_Rent["PK_RE_Rent"];

                if (drRE_Rent["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Rent["FK_RE_Information"];

                if (drRE_Rent["Responsible_Party"] == DBNull.Value)
                    this._Responsible_Party = null;
                else
                    this._Responsible_Party = (string)drRE_Rent["Responsible_Party"];

                if (drRE_Rent["Cancel_Options"] == DBNull.Value)
                    this._Cancel_Options = null;
                else
                    this._Cancel_Options = (string)drRE_Rent["Cancel_Options"];

                if (drRE_Rent["Renew_Options"] == DBNull.Value)
                    this._Renew_Options = null;
                else
                    this._Renew_Options = (string)drRE_Rent["Renew_Options"];

                if (drRE_Rent["Rent_Details"] == DBNull.Value)
                    this._Rent_Details = null;
                else
                    this._Rent_Details = (string)drRE_Rent["Rent_Details"];

                if (drRE_Rent["Rent_Adjustments"] == DBNull.Value)
                    this._Rent_Adjustments = null;
                else
                    this._Rent_Adjustments = (string)drRE_Rent["Rent_Adjustments"];

                if (drRE_Rent["Notification_Due_Date"] == DBNull.Value)
                    this._Notification_Due_Date = null;
                else
                    this._Notification_Due_Date = (DateTime?)drRE_Rent["Notification_Due_Date"];

                if (drRE_Rent["Subtenant_Base_Rent"] == DBNull.Value)
                    this._Subtenant_Base_Rent = null;
                else
                    this._Subtenant_Base_Rent = (decimal?)drRE_Rent["Subtenant_Base_Rent"];

                if (drRE_Rent["Subtenant_Monthly_Rent"] == DBNull.Value)
                    this._Subtenant_Monthly_Rent = null;
                else
                    this._Subtenant_Monthly_Rent = (decimal?)drRE_Rent["Subtenant_Monthly_Rent"];

                if (drRE_Rent["FK_LU_Escalation"] == DBNull.Value)
                    this._FK_LU_Escalation = null;
                else
                    this._FK_LU_Escalation = (decimal?)drRE_Rent["FK_LU_Escalation"];

                if (drRE_Rent["Percentage_Rate"] == DBNull.Value)
                    this._Percentage_Rate = null;
                else
                    this._Percentage_Rate = (decimal?)drRE_Rent["Percentage_Rate"];

                if (drRE_Rent["Increase"] == DBNull.Value)
                    this._Increase = null;
                else
                    this._Increase = (decimal?)drRE_Rent["Increase"];

                if (drRE_Rent["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Rent["Updated_By"];

                if (drRE_Rent["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Rent["Update_Date"];

            }
            else
            {
                this._PK_RE_Rent = null;
                this._FK_RE_Information = null;
                this._Responsible_Party = null;
                this._Cancel_Options = null;
                this._Renew_Options = null;
                this._Rent_Adjustments = null;
                this._Notification_Due_Date = null;
                this._Subtenant_Base_Rent = null;
                this._Subtenant_Monthly_Rent = null;
                this._FK_LU_Escalation = null;
                this._Percentage_Rate = null;
                this._Increase = null;
                this._Updated_By = null;
                this._Update_Date = null;
                this._Rent_Details = null; 
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the RE_Rent table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_RentInsert");


            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);

            if (string.IsNullOrEmpty(this._Responsible_Party))
                db.AddInParameter(dbCommand, "Responsible_Party", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Responsible_Party", DbType.String, this._Responsible_Party);

            if (string.IsNullOrEmpty(this._Cancel_Options))
                db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, this._Cancel_Options);

            if (string.IsNullOrEmpty(this._Renew_Options))
                db.AddInParameter(dbCommand, "Renew_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Renew_Options", DbType.String, this._Renew_Options);

            if (string.IsNullOrEmpty(this._Rent_Adjustments))
                db.AddInParameter(dbCommand, "Rent_Adjustments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Rent_Adjustments", DbType.String, this._Rent_Adjustments);

            db.AddInParameter(dbCommand, "Notification_Due_Date", DbType.DateTime, this._Notification_Due_Date);

            db.AddInParameter(dbCommand, "Subtenant_Base_Rent", DbType.Decimal, this._Subtenant_Base_Rent);

            db.AddInParameter(dbCommand, "Subtenant_Monthly_Rent", DbType.Decimal, this._Subtenant_Monthly_Rent);

            db.AddInParameter(dbCommand, "FK_LU_Escalation", DbType.Decimal, this._FK_LU_Escalation);

            db.AddInParameter(dbCommand, "Percentage_Rate", DbType.Decimal, this._Percentage_Rate);

            db.AddInParameter(dbCommand, "Increase", DbType.Decimal, this._Increase);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Rent_Details ))
                db.AddInParameter(dbCommand, "Rent_Details", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Rent_Details", DbType.String, this._Rent_Details);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the RE_Rent table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_RE_Rent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_RentSelectByPK");

            db.AddInParameter(dbCommand, "PK_RE_Rent", DbType.Decimal, pK_RE_Rent);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RE_Rent table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_RentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the RE_Rent table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_RentUpdate");


            db.AddInParameter(dbCommand, "PK_RE_Rent", DbType.Decimal, this._PK_RE_Rent);

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);

            if (string.IsNullOrEmpty(this._Responsible_Party))
                db.AddInParameter(dbCommand, "Responsible_Party", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Responsible_Party", DbType.String, this._Responsible_Party);

            if (string.IsNullOrEmpty(this._Cancel_Options))
                db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, this._Cancel_Options);

            if (string.IsNullOrEmpty(this._Renew_Options))
                db.AddInParameter(dbCommand, "Renew_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Renew_Options", DbType.String, this._Renew_Options);

            if (string.IsNullOrEmpty(this._Rent_Adjustments))
                db.AddInParameter(dbCommand, "Rent_Adjustments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Rent_Adjustments", DbType.String, this._Rent_Adjustments);

            db.AddInParameter(dbCommand, "Notification_Due_Date", DbType.DateTime, this._Notification_Due_Date);

            db.AddInParameter(dbCommand, "Subtenant_Base_Rent", DbType.Decimal, this._Subtenant_Base_Rent);

            db.AddInParameter(dbCommand, "Subtenant_Monthly_Rent", DbType.Decimal, this._Subtenant_Monthly_Rent);

            db.AddInParameter(dbCommand, "FK_LU_Escalation", DbType.Decimal, this._FK_LU_Escalation);

            db.AddInParameter(dbCommand, "Percentage_Rate", DbType.Decimal, this._Percentage_Rate);

            db.AddInParameter(dbCommand, "Increase", DbType.Decimal, this._Increase);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Rent_Details))
                db.AddInParameter(dbCommand, "Rent_Details", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Rent_Details", DbType.String, this._Rent_Details);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the RE_Rent table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_RE_Rent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_RentDeleteByPK");

            db.AddInParameter(dbCommand, "PK_RE_Rent", DbType.Decimal, pK_RE_Rent);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the RE_Rent_Projections table by a foriegn key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByFK(decimal fK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_RentSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, fK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
