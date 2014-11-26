using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RE_Subtenant table.
	/// </summary>
	public sealed class RE_Subtenant
	{

        #region Private variables used to hold the property values

        private decimal? _PK_RE_Subtenant;
        private decimal? _FK_RE_Information;
        private string _Subtenant_DBA;
        private string _Subtenant_Mailing_Address1;
        private string _Subtenant_Mailing_Address2;
        private string _Subtenant_Mailing_City;
        private decimal? _PK_Subtenant_Mailing_State;
        private string _Subtenant_Mailing_Zip_Code;
        private string _Subtenant_Telephone;
        private string _Cancel_Options;
        private string _Renew_Options;
        private string _Option_Notification;
        private DateTime? _Notification_Due_Date;
        private decimal? _Subtenant_Base_Rent;
        private decimal? _Subtenant_Monthly_Rent;
        private decimal? _FK_LU_Escalation;
        private decimal? _Percentage_Rate;
        private decimal? _Increase;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private DateTime? _Sublease_Commencement_Date;
        private DateTime? _Sublease_Expiration_Date;
        private string _Other_Requirements;
        private decimal? _Security_Deposit;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_RE_Subtenant value.
        /// </summary>
        public decimal? PK_RE_Subtenant
        {
            get { return _PK_RE_Subtenant; }
            set { _PK_RE_Subtenant = value; }
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
        /// Gets or sets the Subtenant_DBA value.
        /// </summary>
        public string Subtenant_DBA
        {
            get { return _Subtenant_DBA; }
            set { _Subtenant_DBA = value; }
        }

        /// <summary>
        /// Gets or sets the Subtenant_Mailing_Address1 value.
        /// </summary>
        public string Subtenant_Mailing_Address1
        {
            get { return _Subtenant_Mailing_Address1; }
            set { _Subtenant_Mailing_Address1 = value; }
        }

        /// <summary>
        /// Gets or sets the Subtenant_Mailing_Address2 value.
        /// </summary>
        public string Subtenant_Mailing_Address2
        {
            get { return _Subtenant_Mailing_Address2; }
            set { _Subtenant_Mailing_Address2 = value; }
        }

        /// <summary>
        /// Gets or sets the Subtenant_Mailing_City value.
        /// </summary>
        public string Subtenant_Mailing_City
        {
            get { return _Subtenant_Mailing_City; }
            set { _Subtenant_Mailing_City = value; }
        }

        /// <summary>
        /// Gets or sets the PK_Subtenant_Mailing_State value.
        /// </summary>
        public decimal? PK_Subtenant_Mailing_State
        {
            get { return _PK_Subtenant_Mailing_State; }
            set { _PK_Subtenant_Mailing_State = value; }
        }

        /// <summary>
        /// Gets or sets the Subtenant_Mailing_Zip_Code value.
        /// </summary>
        public string Subtenant_Mailing_Zip_Code
        {
            get { return _Subtenant_Mailing_Zip_Code; }
            set { _Subtenant_Mailing_Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Subtenant_Telephone value.
        /// </summary>
        public string Subtenant_Telephone
        {
            get { return _Subtenant_Telephone; }
            set { _Subtenant_Telephone = value; }
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
        /// Gets or sets the Option_Notification value.
        /// </summary>
        public string Option_Notification
        {
            get { return _Option_Notification; }
            set { _Option_Notification = value; }
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

        /// <summary>
        /// Gets or sets the Sublease_Commencement_Date value.
        /// </summary>
        public DateTime? Sublease_Commencement_Date
        {
            get { return _Sublease_Commencement_Date; }
            set { _Sublease_Commencement_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Sublease_Expiration_Date value.
        /// </summary>
        public DateTime? Sublease_Expiration_Date
        {
            get { return _Sublease_Expiration_Date; }
            set { _Sublease_Expiration_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Requirements value.
        /// </summary>
        public string Other_Requirements
        {
            get { return _Other_Requirements; }
            set { _Other_Requirements = value; }
        }
        /// <summary>
        /// Gets or sets the Increase value.
        /// </summary>
        public decimal? Security_Deposit
        {
            get { return _Security_Deposit; }
            set { _Security_Deposit = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Subtenant class with default value.
        /// </summary>
        public RE_Subtenant()
        {
            setDefaultValues();
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Subtenant class based on Primary Key.
        /// </summary>
        public RE_Subtenant(decimal pK_RE_Subtenant)
        {
            DataTable dtRE_Subtenant = SelectByPK(pK_RE_Subtenant).Tables[0];

            if (dtRE_Subtenant.Rows.Count == 1)
            {
                DataRow drRE_Subtenant = dtRE_Subtenant.Rows[0];
                if (drRE_Subtenant["PK_RE_Subtenant"] == DBNull.Value)
                    this._PK_RE_Subtenant = null;
                else
                    this._PK_RE_Subtenant = (decimal?)drRE_Subtenant["PK_RE_Subtenant"];

                if (drRE_Subtenant["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Subtenant["FK_RE_Information"];

                if (drRE_Subtenant["Subtenant_DBA"] == DBNull.Value)
                    this._Subtenant_DBA = null;
                else
                    this._Subtenant_DBA = (string)drRE_Subtenant["Subtenant_DBA"];

                if (drRE_Subtenant["Subtenant_Mailing_Address1"] == DBNull.Value)
                    this._Subtenant_Mailing_Address1 = null;
                else
                    this._Subtenant_Mailing_Address1 = (string)drRE_Subtenant["Subtenant_Mailing_Address1"];

                if (drRE_Subtenant["Subtenant_Mailing_Address2"] == DBNull.Value)
                    this._Subtenant_Mailing_Address2 = null;
                else
                    this._Subtenant_Mailing_Address2 = (string)drRE_Subtenant["Subtenant_Mailing_Address2"];

                if (drRE_Subtenant["Subtenant_Mailing_City"] == DBNull.Value)
                    this._Subtenant_Mailing_City = null;
                else
                    this._Subtenant_Mailing_City = (string)drRE_Subtenant["Subtenant_Mailing_City"];

                if (drRE_Subtenant["PK_Subtenant_Mailing_State"] == DBNull.Value)
                    this._PK_Subtenant_Mailing_State = null;
                else
                    this._PK_Subtenant_Mailing_State = (decimal?)drRE_Subtenant["PK_Subtenant_Mailing_State"];

                if (drRE_Subtenant["Subtenant_Mailing_Zip_Code"] == DBNull.Value)
                    this._Subtenant_Mailing_Zip_Code = null;
                else
                    this._Subtenant_Mailing_Zip_Code = (string)drRE_Subtenant["Subtenant_Mailing_Zip_Code"];

                if (drRE_Subtenant["Subtenant_Telephone"] == DBNull.Value)
                    this._Subtenant_Telephone = null;
                else
                    this._Subtenant_Telephone = (string)drRE_Subtenant["Subtenant_Telephone"];

                if (drRE_Subtenant["Cancel_Options"] == DBNull.Value)
                    this._Cancel_Options = null;
                else
                    this._Cancel_Options = (string)drRE_Subtenant["Cancel_Options"];

                if (drRE_Subtenant["Renew_Options"] == DBNull.Value)
                    this._Renew_Options = null;
                else
                    this._Renew_Options = (string)drRE_Subtenant["Renew_Options"];

                if (drRE_Subtenant["Option_Notification"] == DBNull.Value)
                    this._Option_Notification = null;
                else
                    this._Option_Notification = (string)drRE_Subtenant["Option_Notification"];

                if (drRE_Subtenant["Notification_Due_Date"] == DBNull.Value)
                    this._Notification_Due_Date = null;
                else
                    this._Notification_Due_Date = (DateTime?)drRE_Subtenant["Notification_Due_Date"];

                if (drRE_Subtenant["Subtenant_Base_Rent"] == DBNull.Value)
                    this._Subtenant_Base_Rent = null;
                else
                    this._Subtenant_Base_Rent = (decimal?)drRE_Subtenant["Subtenant_Base_Rent"];

                if (drRE_Subtenant["Subtenant_Monthly_Rent"] == DBNull.Value)
                    this._Subtenant_Monthly_Rent = null;
                else
                    this._Subtenant_Monthly_Rent = (decimal?)drRE_Subtenant["Subtenant_Monthly_Rent"];

                if (drRE_Subtenant["FK_LU_Escalation"] == DBNull.Value)
                    this._FK_LU_Escalation = null;
                else
                    this._FK_LU_Escalation = (decimal?)drRE_Subtenant["FK_LU_Escalation"];

                if (drRE_Subtenant["Percentage_Rate"] == DBNull.Value)
                    this._Percentage_Rate = null;
                else
                    this._Percentage_Rate = (decimal?)drRE_Subtenant["Percentage_Rate"];

                if (drRE_Subtenant["Increase"] == DBNull.Value)
                    this._Increase = null;
                else
                    this._Increase = (decimal?)drRE_Subtenant["Increase"];

                if (drRE_Subtenant["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Subtenant["Updated_By"];

                if (drRE_Subtenant["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Subtenant["Update_Date"];

                if (drRE_Subtenant["Sublease_Commencement_Date"] == DBNull.Value)
                    this._Sublease_Commencement_Date = null;
                else
                    this._Sublease_Commencement_Date = (DateTime?)drRE_Subtenant["Sublease_Commencement_Date"];

                if (drRE_Subtenant["Sublease_Expiration_Date"] == DBNull.Value)
                    this._Sublease_Expiration_Date = null;
                else
                    this._Sublease_Expiration_Date = (DateTime?)drRE_Subtenant["Sublease_Expiration_Date"];

                if (drRE_Subtenant["Other_Requirements"] == DBNull.Value)
                    this._Other_Requirements = null;
                else
                    this._Other_Requirements = (string)drRE_Subtenant["Other_Requirements"];

                if (drRE_Subtenant["Security_Deposit"] == DBNull.Value)
                    this._Security_Deposit = null;
                else
                    this._Security_Deposit = (decimal?)drRE_Subtenant["Security_Deposit"];


            }
            else
            {
                setDefaultValues();
            }

        }

        /// <summary>
        /// Initializes a new instance of the RE_Subtenant class based on Primary Key.
        /// </summary>
        public RE_Subtenant(decimal FK_RE_Information,bool status)
        {
            DataTable dtRE_Subtenant = SelectByFK(FK_RE_Information).Tables[0];

            if (dtRE_Subtenant.Rows.Count == 1)
            {
                DataRow drRE_Subtenant = dtRE_Subtenant.Rows[0];
                if (drRE_Subtenant["PK_RE_Subtenant"] == DBNull.Value)
                    this._PK_RE_Subtenant = null;
                else
                    this._PK_RE_Subtenant = (decimal?)drRE_Subtenant["PK_RE_Subtenant"];

                if (drRE_Subtenant["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Subtenant["FK_RE_Information"];

                if (drRE_Subtenant["Subtenant_DBA"] == DBNull.Value)
                    this._Subtenant_DBA = null;
                else
                    this._Subtenant_DBA = (string)drRE_Subtenant["Subtenant_DBA"];

                if (drRE_Subtenant["Subtenant_Mailing_Address1"] == DBNull.Value)
                    this._Subtenant_Mailing_Address1 = null;
                else
                    this._Subtenant_Mailing_Address1 = (string)drRE_Subtenant["Subtenant_Mailing_Address1"];

                if (drRE_Subtenant["Subtenant_Mailing_Address2"] == DBNull.Value)
                    this._Subtenant_Mailing_Address2 = null;
                else
                    this._Subtenant_Mailing_Address2 = (string)drRE_Subtenant["Subtenant_Mailing_Address2"];

                if (drRE_Subtenant["Subtenant_Mailing_City"] == DBNull.Value)
                    this._Subtenant_Mailing_City = null;
                else
                    this._Subtenant_Mailing_City = (string)drRE_Subtenant["Subtenant_Mailing_City"];

                if (drRE_Subtenant["PK_Subtenant_Mailing_State"] == DBNull.Value)
                    this._PK_Subtenant_Mailing_State = null;
                else
                    this._PK_Subtenant_Mailing_State = (decimal?)drRE_Subtenant["PK_Subtenant_Mailing_State"];

                if (drRE_Subtenant["Subtenant_Mailing_Zip_Code"] == DBNull.Value)
                    this._Subtenant_Mailing_Zip_Code = null;
                else
                    this._Subtenant_Mailing_Zip_Code = (string)drRE_Subtenant["Subtenant_Mailing_Zip_Code"];

                if (drRE_Subtenant["Subtenant_Telephone"] == DBNull.Value)
                    this._Subtenant_Telephone = null;
                else
                    this._Subtenant_Telephone = (string)drRE_Subtenant["Subtenant_Telephone"];

                if (drRE_Subtenant["Cancel_Options"] == DBNull.Value)
                    this._Cancel_Options = null;
                else
                    this._Cancel_Options = (string)drRE_Subtenant["Cancel_Options"];

                if (drRE_Subtenant["Renew_Options"] == DBNull.Value)
                    this._Renew_Options = null;
                else
                    this._Renew_Options = (string)drRE_Subtenant["Renew_Options"];

                if (drRE_Subtenant["Option_Notification"] == DBNull.Value)
                    this._Option_Notification = null;
                else
                    this._Option_Notification = (string)drRE_Subtenant["Option_Notification"];

                if (drRE_Subtenant["Notification_Due_Date"] == DBNull.Value)
                    this._Notification_Due_Date = null;
                else
                    this._Notification_Due_Date = (DateTime?)drRE_Subtenant["Notification_Due_Date"];

                if (drRE_Subtenant["Subtenant_Base_Rent"] == DBNull.Value)
                    this._Subtenant_Base_Rent = null;
                else
                    this._Subtenant_Base_Rent = (decimal?)drRE_Subtenant["Subtenant_Base_Rent"];

                if (drRE_Subtenant["Subtenant_Monthly_Rent"] == DBNull.Value)
                    this._Subtenant_Monthly_Rent = null;
                else
                    this._Subtenant_Monthly_Rent = (decimal?)drRE_Subtenant["Subtenant_Monthly_Rent"];

                if (drRE_Subtenant["FK_LU_Escalation"] == DBNull.Value)
                    this._FK_LU_Escalation = null;
                else
                    this._FK_LU_Escalation = (decimal?)drRE_Subtenant["FK_LU_Escalation"];

                if (drRE_Subtenant["Percentage_Rate"] == DBNull.Value)
                    this._Percentage_Rate = null;
                else
                    this._Percentage_Rate = (decimal?)drRE_Subtenant["Percentage_Rate"];

                if (drRE_Subtenant["Increase"] == DBNull.Value)
                    this._Increase = null;
                else
                    this._Increase = (decimal?)drRE_Subtenant["Increase"];

                if (drRE_Subtenant["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Subtenant["Updated_By"];

                if (drRE_Subtenant["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Subtenant["Update_Date"];

                if (drRE_Subtenant["Sublease_Commencement_Date"] == DBNull.Value)
                    this._Sublease_Commencement_Date = null;
                else
                    this._Sublease_Commencement_Date = (DateTime?)drRE_Subtenant["Sublease_Commencement_Date"];

                if (drRE_Subtenant["Sublease_Expiration_Date"] == DBNull.Value)
                    this._Sublease_Expiration_Date = null;
                else
                    this._Sublease_Expiration_Date = (DateTime?)drRE_Subtenant["Sublease_Expiration_Date"];

                if (drRE_Subtenant["Other_Requirements"] == DBNull.Value)
                    this._Other_Requirements = null;
                else
                    this._Other_Requirements = (string)drRE_Subtenant["Other_Requirements"];

                if (drRE_Subtenant["Security_Deposit"] == DBNull.Value)
                    this._Security_Deposit = null;
                else
                    this._Security_Deposit = (decimal?)drRE_Subtenant["Security_Deposit"];
            }
            else
            {
                setDefaultValues();
            }
        }

        private void setDefaultValues()
        {
            this._PK_RE_Subtenant = null;
            this._FK_RE_Information = null;
            this._Subtenant_DBA = null;
            this._Subtenant_Mailing_Address1 = null;
            this._Subtenant_Mailing_Address2 = null;
            this._Subtenant_Mailing_City = null;
            this._PK_Subtenant_Mailing_State = null;
            this._Subtenant_Mailing_Zip_Code = null;
            this._Subtenant_Telephone = null;
            this._Cancel_Options = null;
            this._Renew_Options = null;
            this._Option_Notification = null;
            this._Notification_Due_Date = null;
            this._Subtenant_Base_Rent = null;
            this._Subtenant_Monthly_Rent = null;
            this._FK_LU_Escalation = null;
            this._Percentage_Rate = null;
            this._Increase = null;
            this._Updated_By = null;
            this._Update_Date = null;
            this._Sublease_Commencement_Date = null;
            this._Sublease_Expiration_Date = null;
            this._Other_Requirements = null;
            this._Security_Deposit = null;
        }

        #endregion

        /// <summary>
        /// Inserts a record into the RE_Subtenant table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubtenantInsert");


            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);

            if (string.IsNullOrEmpty(this._Subtenant_DBA))
                db.AddInParameter(dbCommand, "Subtenant_DBA", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_DBA", DbType.String, this._Subtenant_DBA);

            if (string.IsNullOrEmpty(this._Subtenant_Mailing_Address1))
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Address1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Address1", DbType.String, this._Subtenant_Mailing_Address1);

            if (string.IsNullOrEmpty(this._Subtenant_Mailing_Address2))
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Address2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Address2", DbType.String, this._Subtenant_Mailing_Address2);

            if (string.IsNullOrEmpty(this._Subtenant_Mailing_City))
                db.AddInParameter(dbCommand, "Subtenant_Mailing_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Mailing_City", DbType.String, this._Subtenant_Mailing_City);

            db.AddInParameter(dbCommand, "PK_Subtenant_Mailing_State", DbType.Decimal, this._PK_Subtenant_Mailing_State);

            if (string.IsNullOrEmpty(this._Subtenant_Mailing_Zip_Code))
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Zip_Code", DbType.String, this._Subtenant_Mailing_Zip_Code);

            if (string.IsNullOrEmpty(this._Subtenant_Telephone))
                db.AddInParameter(dbCommand, "Subtenant_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Telephone", DbType.String, this._Subtenant_Telephone);

            if (string.IsNullOrEmpty(this._Cancel_Options))
                db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, this._Cancel_Options);

            if (string.IsNullOrEmpty(this._Renew_Options))
                db.AddInParameter(dbCommand, "Renew_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Renew_Options", DbType.String, this._Renew_Options);

            if (string.IsNullOrEmpty(this._Option_Notification))
                db.AddInParameter(dbCommand, "Option_Notification", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Option_Notification", DbType.String, this._Option_Notification);

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

            db.AddInParameter(dbCommand, "Sublease_Commencement_Date", DbType.DateTime, this._Sublease_Commencement_Date);

            db.AddInParameter(dbCommand, "Sublease_Expiration_Date", DbType.DateTime, this._Sublease_Expiration_Date);

            if (string.IsNullOrEmpty(this._Other_Requirements))
                db.AddInParameter(dbCommand, "Other_Requirements", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Requirements", DbType.String, this._Other_Requirements);

            db.AddInParameter(dbCommand, "Security_Deposit", DbType.Decimal, this._Security_Deposit);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the RE_Subtenant table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_RE_Subtenant)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubtenantSelectByPK");

            db.AddInParameter(dbCommand, "PK_RE_Subtenant", DbType.Decimal, pK_RE_Subtenant);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the RE_Subtenant table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubtenantSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, FK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RE_Subtenant table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubtenantSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the RE_Subtenant table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubtenantUpdate");


            db.AddInParameter(dbCommand, "PK_RE_Subtenant", DbType.Decimal, this._PK_RE_Subtenant);

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);

            if (string.IsNullOrEmpty(this._Subtenant_DBA))
                db.AddInParameter(dbCommand, "Subtenant_DBA", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_DBA", DbType.String, this._Subtenant_DBA);

            if (string.IsNullOrEmpty(this._Subtenant_Mailing_Address1))
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Address1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Address1", DbType.String, this._Subtenant_Mailing_Address1);

            if (string.IsNullOrEmpty(this._Subtenant_Mailing_Address2))
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Address2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Address2", DbType.String, this._Subtenant_Mailing_Address2);

            if (string.IsNullOrEmpty(this._Subtenant_Mailing_City))
                db.AddInParameter(dbCommand, "Subtenant_Mailing_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Mailing_City", DbType.String, this._Subtenant_Mailing_City);

            db.AddInParameter(dbCommand, "PK_Subtenant_Mailing_State", DbType.Decimal, this._PK_Subtenant_Mailing_State);

            if (string.IsNullOrEmpty(this._Subtenant_Mailing_Zip_Code))
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Mailing_Zip_Code", DbType.String, this._Subtenant_Mailing_Zip_Code);

            if (string.IsNullOrEmpty(this._Subtenant_Telephone))
                db.AddInParameter(dbCommand, "Subtenant_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subtenant_Telephone", DbType.String, this._Subtenant_Telephone);

            if (string.IsNullOrEmpty(this._Cancel_Options))
                db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, this._Cancel_Options);

            if (string.IsNullOrEmpty(this._Renew_Options))
                db.AddInParameter(dbCommand, "Renew_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Renew_Options", DbType.String, this._Renew_Options);

            if (string.IsNullOrEmpty(this._Option_Notification))
                db.AddInParameter(dbCommand, "Option_Notification", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Option_Notification", DbType.String, this._Option_Notification);

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

            db.AddInParameter(dbCommand, "Sublease_Commencement_Date", DbType.DateTime, this._Sublease_Commencement_Date);

            db.AddInParameter(dbCommand, "Sublease_Expiration_Date", DbType.DateTime, this._Sublease_Expiration_Date);

            if (string.IsNullOrEmpty(this._Other_Requirements))
                db.AddInParameter(dbCommand, "Other_Requirements", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Requirements", DbType.String, this._Other_Requirements);
            db.AddInParameter(dbCommand, "Security_Deposit", DbType.Decimal, this._Security_Deposit);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the RE_Subtenant table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_RE_Subtenant)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubtenantDeleteByPK");

            db.AddInParameter(dbCommand, "PK_RE_Subtenant", DbType.Decimal, pK_RE_Subtenant);

            db.ExecuteNonQuery(dbCommand);
        }


        public static decimal GetInflation_RateByYear(decimal year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Inflation_RateGetPercentageByYear");

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, year);
            DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
            if (dt.Rows.Count > 0)
                return Convert.ToDecimal(dt.Rows[0][0]);
            else
                return 0;

        }

        public static DataSet SelectByInformationID(decimal fk_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_SelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, fk_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }

	}
}
