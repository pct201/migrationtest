using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for AP_Cal_Atlantic table.
    /// </summary>
    public sealed class clsAP_Cal_Atlantic
    {

        #region Private variables used to hold the property values

        private decimal? _PK_AP_Cal_Atlantic;
        private decimal? _FK_LU_Location;
        private decimal? _FK_Event;
        private string _Potential_Risk;
        private string _Action_Taken;
        private string _Was_Law_Enforcement_Notified;
        private string _Officer_Name;
        private string _Phone_Number;
        private string _EMail;
        private string _Law_Enforcement_Agency;
        private string _Location;
        private string _Police_Report_Number;
        private string _Notes;
        private string _Auto_Liability;
        private string _DPD;
        private string _Premises_Liability;
        private string _Property_Damage;
        private string _Associated_FROI_Number;
        private string _Associated_Claim_Number;
        private string _Root_Cause;
        private string _Event_Prevention;
        private string _Person_Tasked;
        private DateTime? _Target_Date_of_Completion;
        private DateTime? _Status_Due_On;
        private string _Comments;
        private decimal? _Financial_Loss;
        private decimal? _Recovery;
        private string _Item_Status;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_AP_Cal_Atlantic value.
        /// </summary>
        public decimal? PK_AP_Cal_Atlantic
        {
            get { return _PK_AP_Cal_Atlantic; }
            set { _PK_AP_Cal_Atlantic = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal? FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
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
        /// Gets or sets the Potential_Risk value.
        /// </summary>
        public string Potential_Risk
        {
            get { return _Potential_Risk; }
            set { _Potential_Risk = value; }
        }

        /// <summary>
        /// Gets or sets the Action_Taken value.
        /// </summary>
        public string Action_Taken
        {
            get { return _Action_Taken; }
            set { _Action_Taken = value; }
        }

        /// <summary>
        /// Gets or sets the Was_Law_Enforcement_Notified value.
        /// </summary>
        public string Was_Law_Enforcement_Notified
        {
            get { return _Was_Law_Enforcement_Notified; }
            set { _Was_Law_Enforcement_Notified = value; }
        }

        /// <summary>
        /// Gets or sets the Officer_Name value.
        /// </summary>
        public string Officer_Name
        {
            get { return _Officer_Name; }
            set { _Officer_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Phone_Number value.
        /// </summary>
        public string Phone_Number
        {
            get { return _Phone_Number; }
            set { _Phone_Number = value; }
        }

        /// <summary>
        /// Gets or sets the EMail value.
        /// </summary>
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        /// <summary>
        /// Gets or sets the Law_Enforcement_Agency value.
        /// </summary>
        public string Law_Enforcement_Agency
        {
            get { return _Law_Enforcement_Agency; }
            set { _Law_Enforcement_Agency = value; }
        }

        /// <summary>
        /// Gets or sets the Location value.
        /// </summary>
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Report_Number value.
        /// </summary>
        public string Police_Report_Number
        {
            get { return _Police_Report_Number; }
            set { _Police_Report_Number = value; }
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
        /// Gets or sets the Auto_Liability value.
        /// </summary>
        public string Auto_Liability
        {
            get { return _Auto_Liability; }
            set { _Auto_Liability = value; }
        }

        /// <summary>
        /// Gets or sets the DPD value.
        /// </summary>
        public string DPD
        {
            get { return _DPD; }
            set { _DPD = value; }
        }

        /// <summary>
        /// Gets or sets the Premises_Liability value.
        /// </summary>
        public string Premises_Liability
        {
            get { return _Premises_Liability; }
            set { _Premises_Liability = value; }
        }

        /// <summary>
        /// Gets or sets the Property_Damage value.
        /// </summary>
        public string Property_Damage
        {
            get { return _Property_Damage; }
            set { _Property_Damage = value; }
        }

        /// <summary>
        /// Gets or sets the Associated_FROI_Number value.
        /// </summary>
        public string Associated_FROI_Number
        {
            get { return _Associated_FROI_Number; }
            set { _Associated_FROI_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Associated_Claim_Number value.
        /// </summary>
        public string Associated_Claim_Number
        {
            get { return _Associated_Claim_Number; }
            set { _Associated_Claim_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Root_Cause value.
        /// </summary>
        public string Root_Cause
        {
            get { return _Root_Cause; }
            set { _Root_Cause = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Prevention value.
        /// </summary>
        public string Event_Prevention
        {
            get { return _Event_Prevention; }
            set { _Event_Prevention = value; }
        }

        /// <summary>
        /// Gets or sets the Person_Tasked value.
        /// </summary>
        public string Person_Tasked
        {
            get { return _Person_Tasked; }
            set { _Person_Tasked = value; }
        }

        /// <summary>
        /// Gets or sets the Target_Date_of_Completion value.
        /// </summary>
        public DateTime? Target_Date_of_Completion
        {
            get { return _Target_Date_of_Completion; }
            set { _Target_Date_of_Completion = value; }
        }

        /// <summary>
        /// Gets or sets the Status_Due_On value.
        /// </summary>
        public DateTime? Status_Due_On
        {
            get { return _Status_Due_On; }
            set { _Status_Due_On = value; }
        }

        /// <summary>
        /// Gets or sets the Comments value.
        /// </summary>
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Financial_Loss value.
        /// </summary>
        public decimal? Financial_Loss
        {
            get { return _Financial_Loss; }
            set { _Financial_Loss = value; }
        }

        /// <summary>
        /// Gets or sets the Recovery value.
        /// </summary>
        public decimal? Recovery
        {
            get { return _Recovery; }
            set { _Recovery = value; }
        }

        /// <summary>
        /// Gets or sets the Item_Status value.
        /// </summary>
        public string Item_Status
        {
            get { return _Item_Status; }
            set { _Item_Status = value; }
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
        /// Initializes a new instance of the clsAP_Cal_Atlantic class with default value.
        /// </summary>
        public clsAP_Cal_Atlantic()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsAP_Cal_Atlantic class based on Primary Key.
        /// </summary>
        public clsAP_Cal_Atlantic(decimal pK_AP_Cal_Atlantic)
        {
            DataTable dtAP_Cal_Atlantic = SelectByPK(pK_AP_Cal_Atlantic).Tables[0];

            if (dtAP_Cal_Atlantic.Rows.Count == 1)
            {
                SetValue(dtAP_Cal_Atlantic.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsAP_Cal_Atlantic class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drAP_Cal_Atlantic)
        {
            if (drAP_Cal_Atlantic["PK_AP_Cal_Atlantic"] == DBNull.Value)
                this._PK_AP_Cal_Atlantic = null;
            else
                this._PK_AP_Cal_Atlantic = (decimal?)drAP_Cal_Atlantic["PK_AP_Cal_Atlantic"];

            if (drAP_Cal_Atlantic["FK_LU_Location"] == DBNull.Value)
                this._FK_LU_Location = null;
            else
                this._FK_LU_Location = (decimal?)drAP_Cal_Atlantic["FK_LU_Location"];

            if (drAP_Cal_Atlantic["FK_Event"] == DBNull.Value)
                this._FK_Event = null;
            else
                this._FK_Event = (decimal?)drAP_Cal_Atlantic["FK_Event"];

            if (drAP_Cal_Atlantic["Potential_Risk"] == DBNull.Value)
                this._Potential_Risk = null;
            else
                this._Potential_Risk = (string)drAP_Cal_Atlantic["Potential_Risk"];

            if (drAP_Cal_Atlantic["Action_Taken"] == DBNull.Value)
                this._Action_Taken = null;
            else
                this._Action_Taken = (string)drAP_Cal_Atlantic["Action_Taken"];

            if (drAP_Cal_Atlantic["Was_Law_Enforcement_Notified"] == DBNull.Value)
                this._Was_Law_Enforcement_Notified = null;
            else
                this._Was_Law_Enforcement_Notified = (string)drAP_Cal_Atlantic["Was_Law_Enforcement_Notified"];

            if (drAP_Cal_Atlantic["Officer_Name"] == DBNull.Value)
                this._Officer_Name = null;
            else
                this._Officer_Name = (string)drAP_Cal_Atlantic["Officer_Name"];

            if (drAP_Cal_Atlantic["Phone_Number"] == DBNull.Value)
                this._Phone_Number = null;
            else
                this._Phone_Number = (string)drAP_Cal_Atlantic["Phone_Number"];

            if (drAP_Cal_Atlantic["EMail"] == DBNull.Value)
                this._EMail = null;
            else
                this._EMail = (string)drAP_Cal_Atlantic["EMail"];

            if (drAP_Cal_Atlantic["Law_Enforcement_Agency"] == DBNull.Value)
                this._Law_Enforcement_Agency = null;
            else
                this._Law_Enforcement_Agency = (string)drAP_Cal_Atlantic["Law_Enforcement_Agency"];

            if (drAP_Cal_Atlantic["Location"] == DBNull.Value)
                this._Location = null;
            else
                this._Location = (string)drAP_Cal_Atlantic["Location"];

            if (drAP_Cal_Atlantic["Police_Report_Number"] == DBNull.Value)
                this._Police_Report_Number = null;
            else
                this._Police_Report_Number = (string)drAP_Cal_Atlantic["Police_Report_Number"];

            if (drAP_Cal_Atlantic["Notes"] == DBNull.Value)
                this._Notes = null;
            else
                this._Notes = (string)drAP_Cal_Atlantic["Notes"];

            if (drAP_Cal_Atlantic["Auto_Liability"] == DBNull.Value)
                this._Auto_Liability = null;
            else
                this._Auto_Liability = (string)drAP_Cal_Atlantic["Auto_Liability"];

            if (drAP_Cal_Atlantic["DPD"] == DBNull.Value)
                this._DPD = null;
            else
                this._DPD = (string)drAP_Cal_Atlantic["DPD"];

            if (drAP_Cal_Atlantic["Premises_Liability"] == DBNull.Value)
                this._Premises_Liability = null;
            else
                this._Premises_Liability = (string)drAP_Cal_Atlantic["Premises_Liability"];

            if (drAP_Cal_Atlantic["Property_Damage"] == DBNull.Value)
                this._Property_Damage = null;
            else
                this._Property_Damage = (string)drAP_Cal_Atlantic["Property_Damage"];

            if (drAP_Cal_Atlantic["Associated_FROI_Number"] == DBNull.Value)
                this._Associated_FROI_Number = null;
            else
                this._Associated_FROI_Number = (string)drAP_Cal_Atlantic["Associated_FROI_Number"];

            if (drAP_Cal_Atlantic["Associated_Claim_Number"] == DBNull.Value)
                this._Associated_Claim_Number = null;
            else
                this._Associated_Claim_Number = (string)drAP_Cal_Atlantic["Associated_Claim_Number"];

            if (drAP_Cal_Atlantic["Root_Cause"] == DBNull.Value)
                this._Root_Cause = null;
            else
                this._Root_Cause = (string)drAP_Cal_Atlantic["Root_Cause"];

            if (drAP_Cal_Atlantic["Event_Prevention"] == DBNull.Value)
                this._Event_Prevention = null;
            else
                this._Event_Prevention = (string)drAP_Cal_Atlantic["Event_Prevention"];

            if (drAP_Cal_Atlantic["Person_Tasked"] == DBNull.Value)
                this._Person_Tasked = null;
            else
                this._Person_Tasked = (string)drAP_Cal_Atlantic["Person_Tasked"];

            if (drAP_Cal_Atlantic["Target_Date_of_Completion"] == DBNull.Value)
                this._Target_Date_of_Completion = null;
            else
                this._Target_Date_of_Completion = (DateTime?)drAP_Cal_Atlantic["Target_Date_of_Completion"];

            if (drAP_Cal_Atlantic["Status_Due_On"] == DBNull.Value)
                this._Status_Due_On = null;
            else
                this._Status_Due_On = (DateTime?)drAP_Cal_Atlantic["Status_Due_On"];

            if (drAP_Cal_Atlantic["Comments"] == DBNull.Value)
                this._Comments = null;
            else
                this._Comments = (string)drAP_Cal_Atlantic["Comments"];

            if (drAP_Cal_Atlantic["Financial_Loss"] == DBNull.Value)
                this._Financial_Loss = null;
            else
                this._Financial_Loss = (decimal?)drAP_Cal_Atlantic["Financial_Loss"];

            if (drAP_Cal_Atlantic["Recovery"] == DBNull.Value)
                this._Recovery = null;
            else
                this._Recovery = (decimal?)drAP_Cal_Atlantic["Recovery"];

            if (drAP_Cal_Atlantic["Item_Status"] == DBNull.Value)
                this._Item_Status = null;
            else
                this._Item_Status = (string)drAP_Cal_Atlantic["Item_Status"];

            if (drAP_Cal_Atlantic["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drAP_Cal_Atlantic["Updated_By"];

            if (drAP_Cal_Atlantic["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drAP_Cal_Atlantic["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the AP_Cal_Atlantic table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Cal_AtlanticInsert");


            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            if (string.IsNullOrEmpty(this._Potential_Risk))
                db.AddInParameter(dbCommand, "Potential_Risk", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Potential_Risk", DbType.String, this._Potential_Risk);

            if (string.IsNullOrEmpty(this._Action_Taken))
                db.AddInParameter(dbCommand, "Action_Taken", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action_Taken", DbType.String, this._Action_Taken);

            if (string.IsNullOrEmpty(this._Was_Law_Enforcement_Notified))
                db.AddInParameter(dbCommand, "Was_Law_Enforcement_Notified", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Was_Law_Enforcement_Notified", DbType.String, this._Was_Law_Enforcement_Notified);

            if (string.IsNullOrEmpty(this._Officer_Name))
                db.AddInParameter(dbCommand, "Officer_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Officer_Name", DbType.String, this._Officer_Name);

            if (string.IsNullOrEmpty(this._Phone_Number))
                db.AddInParameter(dbCommand, "Phone_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Phone_Number", DbType.String, this._Phone_Number);

            if (string.IsNullOrEmpty(this._EMail))
                db.AddInParameter(dbCommand, "EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EMail", DbType.String, this._EMail);

            if (string.IsNullOrEmpty(this._Law_Enforcement_Agency))
                db.AddInParameter(dbCommand, "Law_Enforcement_Agency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Law_Enforcement_Agency", DbType.String, this._Law_Enforcement_Agency);

            if (string.IsNullOrEmpty(this._Location))
                db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            if (string.IsNullOrEmpty(this._Police_Report_Number))
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, this._Police_Report_Number);

            if (string.IsNullOrEmpty(this._Notes))
                db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);

            if (string.IsNullOrEmpty(this._Auto_Liability))
                db.AddInParameter(dbCommand, "Auto_Liability", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Auto_Liability", DbType.String, this._Auto_Liability);

            if (string.IsNullOrEmpty(this._DPD))
                db.AddInParameter(dbCommand, "DPD", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DPD", DbType.String, this._DPD);

            if (string.IsNullOrEmpty(this._Premises_Liability))
                db.AddInParameter(dbCommand, "Premises_Liability", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Premises_Liability", DbType.String, this._Premises_Liability);

            if (string.IsNullOrEmpty(this._Property_Damage))
                db.AddInParameter(dbCommand, "Property_Damage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Property_Damage", DbType.String, this._Property_Damage);

            if (string.IsNullOrEmpty(this._Associated_FROI_Number))
                db.AddInParameter(dbCommand, "Associated_FROI_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associated_FROI_Number", DbType.String, this._Associated_FROI_Number);

            if (string.IsNullOrEmpty(this._Associated_Claim_Number))
                db.AddInParameter(dbCommand, "Associated_Claim_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associated_Claim_Number", DbType.String, this._Associated_Claim_Number);

            if (string.IsNullOrEmpty(this._Root_Cause))
                db.AddInParameter(dbCommand, "Root_Cause", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Root_Cause", DbType.String, this._Root_Cause);

            if (string.IsNullOrEmpty(this._Event_Prevention))
                db.AddInParameter(dbCommand, "Event_Prevention", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Prevention", DbType.String, this._Event_Prevention);

            if (string.IsNullOrEmpty(this._Person_Tasked))
                db.AddInParameter(dbCommand, "Person_Tasked", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Person_Tasked", DbType.String, this._Person_Tasked);

            db.AddInParameter(dbCommand, "Target_Date_of_Completion", DbType.DateTime, this._Target_Date_of_Completion);

            db.AddInParameter(dbCommand, "Status_Due_On", DbType.DateTime, this._Status_Due_On);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            db.AddInParameter(dbCommand, "Financial_Loss", DbType.Decimal, this._Financial_Loss);

            db.AddInParameter(dbCommand, "Recovery", DbType.Decimal, this._Recovery);

            if (string.IsNullOrEmpty(this._Item_Status))
                db.AddInParameter(dbCommand, "Item_Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_Status", DbType.String, this._Item_Status);

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
        /// Selects a single record from the AP_Cal_Atlantic table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_AP_Cal_Atlantic)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Cal_AtlanticSelectByPK");

            db.AddInParameter(dbCommand, "PK_AP_Cal_Atlantic", DbType.Decimal, pK_AP_Cal_Atlantic);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the AP_Cal_Atlantic table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Cal_AtlanticSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the AP_Cal_Atlantic table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Cal_AtlanticUpdate");


            db.AddInParameter(dbCommand, "PK_AP_Cal_Atlantic", DbType.Decimal, this._PK_AP_Cal_Atlantic);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            if (string.IsNullOrEmpty(this._Potential_Risk))
                db.AddInParameter(dbCommand, "Potential_Risk", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Potential_Risk", DbType.String, this._Potential_Risk);

            if (string.IsNullOrEmpty(this._Action_Taken))
                db.AddInParameter(dbCommand, "Action_Taken", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action_Taken", DbType.String, this._Action_Taken);

            if (string.IsNullOrEmpty(this._Was_Law_Enforcement_Notified))
                db.AddInParameter(dbCommand, "Was_Law_Enforcement_Notified", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Was_Law_Enforcement_Notified", DbType.String, this._Was_Law_Enforcement_Notified);

            if (string.IsNullOrEmpty(this._Officer_Name))
                db.AddInParameter(dbCommand, "Officer_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Officer_Name", DbType.String, this._Officer_Name);

            if (string.IsNullOrEmpty(this._Phone_Number))
                db.AddInParameter(dbCommand, "Phone_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Phone_Number", DbType.String, this._Phone_Number);

            if (string.IsNullOrEmpty(this._EMail))
                db.AddInParameter(dbCommand, "EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EMail", DbType.String, this._EMail);

            if (string.IsNullOrEmpty(this._Law_Enforcement_Agency))
                db.AddInParameter(dbCommand, "Law_Enforcement_Agency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Law_Enforcement_Agency", DbType.String, this._Law_Enforcement_Agency);

            if (string.IsNullOrEmpty(this._Location))
                db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            if (string.IsNullOrEmpty(this._Police_Report_Number))
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, this._Police_Report_Number);

            if (string.IsNullOrEmpty(this._Notes))
                db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);

            if (string.IsNullOrEmpty(this._Auto_Liability))
                db.AddInParameter(dbCommand, "Auto_Liability", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Auto_Liability", DbType.String, this._Auto_Liability);

            if (string.IsNullOrEmpty(this._DPD))
                db.AddInParameter(dbCommand, "DPD", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DPD", DbType.String, this._DPD);

            if (string.IsNullOrEmpty(this._Premises_Liability))
                db.AddInParameter(dbCommand, "Premises_Liability", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Premises_Liability", DbType.String, this._Premises_Liability);

            if (string.IsNullOrEmpty(this._Property_Damage))
                db.AddInParameter(dbCommand, "Property_Damage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Property_Damage", DbType.String, this._Property_Damage);

            if (string.IsNullOrEmpty(this._Associated_FROI_Number))
                db.AddInParameter(dbCommand, "Associated_FROI_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associated_FROI_Number", DbType.String, this._Associated_FROI_Number);

            if (string.IsNullOrEmpty(this._Associated_Claim_Number))
                db.AddInParameter(dbCommand, "Associated_Claim_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associated_Claim_Number", DbType.String, this._Associated_Claim_Number);

            if (string.IsNullOrEmpty(this._Root_Cause))
                db.AddInParameter(dbCommand, "Root_Cause", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Root_Cause", DbType.String, this._Root_Cause);

            if (string.IsNullOrEmpty(this._Event_Prevention))
                db.AddInParameter(dbCommand, "Event_Prevention", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Prevention", DbType.String, this._Event_Prevention);

            if (string.IsNullOrEmpty(this._Person_Tasked))
                db.AddInParameter(dbCommand, "Person_Tasked", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Person_Tasked", DbType.String, this._Person_Tasked);

            db.AddInParameter(dbCommand, "Target_Date_of_Completion", DbType.DateTime, this._Target_Date_of_Completion);

            db.AddInParameter(dbCommand, "Status_Due_On", DbType.DateTime, this._Status_Due_On);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            db.AddInParameter(dbCommand, "Financial_Loss", DbType.Decimal, this._Financial_Loss);

            db.AddInParameter(dbCommand, "Recovery", DbType.Decimal, this._Recovery);

            if (string.IsNullOrEmpty(this._Item_Status))
                db.AddInParameter(dbCommand, "Item_Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_Status", DbType.String, this._Item_Status);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the AP_Cal_Atlantic table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_AP_Cal_Atlantic)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Cal_AtlanticDeleteByPK");

            db.AddInParameter(dbCommand, "PK_AP_Cal_Atlantic", DbType.Decimal, pK_AP_Cal_Atlantic);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the AP_Cal_Atlantic table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectEventForCalAtlantic(string FROIsToInclude, decimal fK_Lu_Location, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectEventForCalAtlantic");
            db.AddInParameter(dbCommand, "FROIsToInclude", DbType.String, FROIsToInclude);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, fK_Lu_Location);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);


            return db.ExecuteDataSet(dbCommand);
        }

        public static decimal SelectPKByFKLoc(decimal fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_CalAtlanticSelectPKByFKLoc");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);
            db.AddOutParameter(dbCommand, "PK_AP_Cal_Atlantic", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["@PK_AP_Cal_Atlantic"].Value);
        }


        /// <summary>
        /// Selects a single record from the AP_Cal_Atlantic table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFROIFromInsuranceClaimType(string strtable, DateTime dtDatePeriod)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectFROIFromInsuranceClaimType");

            db.AddInParameter(dbCommand, "table", DbType.String, strtable);
            db.AddInParameter(dbCommand, "Date", DbType.DateTime, dtDatePeriod);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the AP_Cal_Atlantic table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectClaimNoInsuranceClaimType(string strtable, DateTime dtDatePeriod)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectClaimNoInsuranceClaimType");

            db.AddInParameter(dbCommand, "table", DbType.String, strtable);
            db.AddInParameter(dbCommand, "Date", DbType.DateTime, dtDatePeriod);

            return db.ExecuteDataSet(dbCommand);
        }

        
        /// <summary>
        /// Selects a single record from the AP_Cal_Atlantic table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAP_CalAtlanticPKByFKEvent(decimal fK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_CalAtlanticSelectPKByFKEvent");

            db.AddInParameter(dbCommand, "FK_LU_Event", DbType.Decimal, fK_Event);
            

            return db.ExecuteDataSet(dbCommand);
        }

    }
}
