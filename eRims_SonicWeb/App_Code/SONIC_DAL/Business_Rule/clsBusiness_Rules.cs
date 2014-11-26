using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Business_Rules table.
    /// </summary>
    public sealed class clsBusiness_Rules
    {
        #region " Enums "
        public enum Screen
        {
            //Auto_Claim_Info = 1,
            //Auto_Financials = 2,
            //Cargo_Claim_Info = 3,
            //Cargo_Financials = 4

            Policies = 1,
            Policy_Feature = 2,
            FWCP_Policy_Info = 3,
            Policy_Notes = 4,
            COI = 5,
            Insurance_Companies = 6,
            Copies = 7,
            COI_Risk_Profile = 8,
            Auto_Claim_Info = 9,
            Auto_Legal = 10,
            Auto_Freight_Bill = 11,
            Auto_Contacts_Info = 12,
            Auto_Diary = 13,
            Auto_Financials = 14,
            Auto_Adjuster_Notes = 15,
            Cargo_Claim_Info = 16,
            Cargo_Legal = 17,
            Cargo_Freight_Bill = 18,
            Cargo_Contacts_Info = 19,
            Cargo_Diary = 20,
            Cargo_Financials = 21,
            Cargo_Adjuster_Notes = 22,
            HVL_Policy = 23,
            Unladen_Liability_Policies = 24,
            Workers_Compensation_Policies = 25,
            Occupational_Accident_Policies = 26,
            PD_Claim = 27,
            PD_Contacts = 28,
            PD_Diary = 29,
            PD_Financial = 30,
            PD_Adjuster_Notes = 31,
            Custom_Bond_Claim = 32,
            Custom_Bond_Contacts = 33,
            Custom_Bond_Diary = 34,
            Custom_Bond_Financial = 35,
            Custom_Bond_Adjuster_Notes = 36,
            Legal_Claim = 37,
            Legal_Legal = 38,
            Legal_Contacts = 39,
            Legal_Diary = 40,
            Legal_Financial = 41,
            Legal_Adjuster_Notes = 42,
            WC_Claim = 43,
            WC_Contacts = 44,
            WC_Diary = 45,
            WC_Financial = 46,
            WC_Adjuster_Notes = 47,
            Cargo_Security_Claim = 48,
            Cargo_Security_Legal = 49,
            Cargo_Security_Freight_Bill = 50,
            Cargo_Security_Contacts = 51,
            Cargo_Security_Diary = 52,
            Cargo_Security_Adjuster_Notes = 53,
            Auto_Safety_Claim = 54,
            Auto_Safety_Legal = 55,
            Auto_Safety_Freight_Bill = 56,
            Auto_Safety_Contacts = 57,
            Auto_Safety_Diary = 58,
            Auto_Safety_Adjuster_Notes = 59,
            Contact = 60,
            GL_Claim = 61,
            GL_Legal = 62,
            GL_Contacts = 63,
            GL_Diary = 64,
            GL_Financial = 65,
            GL_Adjuster_Notes = 66,
            Auto_Legal_Grid = 67,
            Cargo_Legal_Grid = 68,
            Auto_Safety_Legal_Grid = 69,
            Cargo_Security_Legal_Grid = 70,
            GL_Legal_Grid = 71,
            Legal_Claim_Legal_Grid = 72

        }
        #endregion

        #region Private variables used to hold the property values

        private decimal? _PK_Business_Rules;
        private string _Rule_Name;
        private string _Rule_Description;
        private decimal? _FK_Business_Rules_Modules;
        private decimal? _FK_Business_Rules_Screens;
        private string _Table_Name;
        private string _Field;
        private string _Evaluation_Criteria;
        private string _Action_Type;
        private string _Action_Timing;
        private string _EMail_Subject;
        private string _EMail_Body;
        private string _Field_To_Update;
        private decimal? _FK_Field_To_Update;
        private string _New_Value;
        private string _Diary_Note;
        private string _Diary_Assigned_To;
        private int? _Diary_Date_Value;
        private string _Recipient_IDs;
        private string _Email_Recipient_Fields;
        private DateTime? _Update_Date;
        private string _Updated_By;
        private bool _Overwrite;
        private bool _IsDirectValue;
        private decimal? _FK_Derived_Field;
        private bool? _Diary_To_Current_User;
        private string _Diary_Assign_To_Contact;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Business_Rules value.
        /// </summary>
        public decimal? PK_Business_Rules
        {
            get { return _PK_Business_Rules; }
            set { _PK_Business_Rules = value; }
        }

        /// <summary>
        /// Gets or sets the Rule_Name value.
        /// </summary>
        public string Rule_Name
        {
            get { return _Rule_Name; }
            set { _Rule_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Rule_Description value.
        /// </summary>
        public string Rule_Description
        {
            get { return _Rule_Description; }
            set { _Rule_Description = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Business_Rules_Modules value.
        /// </summary>
        public decimal? FK_Business_Rules_Modules
        {
            get { return _FK_Business_Rules_Modules; }
            set { _FK_Business_Rules_Modules = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Business_Rules_Screens value.
        /// </summary>
        public decimal? FK_Business_Rules_Screens
        {
            get { return _FK_Business_Rules_Screens; }
            set { _FK_Business_Rules_Screens = value; }
        }

        /// <summary>
        /// Gets or sets the Table_Name value.
        /// </summary>
        public string Table_Name
        {
            get { return _Table_Name; }
            set { _Table_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Field value.
        /// </summary>
        public string Field
        {
            get { return _Field; }
            set { _Field = value; }
        }

        /// <summary>
        /// Gets or sets the Evaluation_Criteria value.
        /// </summary>
        public string Evaluation_Criteria
        {
            get { return _Evaluation_Criteria; }
            set { _Evaluation_Criteria = value; }
        }

        /// <summary>
        /// Gets or sets the Action_Type value.
        /// </summary>
        public string Action_Type
        {
            get { return _Action_Type; }
            set { _Action_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Action_Timing value.
        /// </summary>
        public string Action_Timing
        {
            get { return _Action_Timing; }
            set { _Action_Timing = value; }
        }

        /// <summary>
        /// Gets or sets the EMail_Subject value.
        /// </summary>
        public string EMail_Subject
        {
            get { return _EMail_Subject; }
            set { _EMail_Subject = value; }
        }

        /// <summary>
        /// Gets or sets the EMail_Body value.
        /// </summary>
        public string EMail_Body
        {
            get { return _EMail_Body; }
            set { _EMail_Body = value; }
        }

        /// <summary>
        /// Gets or sets the Field_To_Update value.
        /// </summary>
        public string Field_To_Update
        {
            get { return _Field_To_Update; }
            set { _Field_To_Update = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Field_To_Update value.
        /// </summary>
        public decimal? FK_Field_To_Update
        {
            get { return _FK_Field_To_Update; }
            set { _FK_Field_To_Update = value; }
        }

        /// <summary>
        /// Gets or sets the New_Value value.
        /// </summary>
        public string New_Value
        {
            get { return _New_Value; }
            set { _New_Value = value; }
        }

        /// <summary>
        /// Gets or sets the Diary_Note value.
        /// </summary>
        public string Diary_Note
        {
            get { return _Diary_Note; }
            set { _Diary_Note = value; }
        }

        /// <summary>
        /// Gets or sets the Diary_Assigned_To value.
        /// </summary>
        public string Diary_Assigned_To
        {
            get { return _Diary_Assigned_To; }
            set { _Diary_Assigned_To = value; }
        }

        /// <summary>
        /// Gets or sets the Diary_Date_Value value.
        /// </summary>
        public int? Diary_Date_Value
        {
            get { return _Diary_Date_Value; }
            set { _Diary_Date_Value = value; }
        }

        /// <summary>
        /// Gets or sets the Recipient_IDs value.
        /// </summary>
        public string Recipient_IDs
        {
            get { return _Recipient_IDs; }
            set { _Recipient_IDs = value; }
        }

        /// <summary>
        /// Gets or sets the Recipient_IDs value.
        /// </summary>
        public string Email_Recipient_Fields
        {
            get { return _Email_Recipient_Fields; }
            set { _Email_Recipient_Fields = value; }
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
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public bool Overwrite
        {
            get { return _Overwrite; }
            set { _Overwrite = value; }
        }

        /// <summary>
        /// Gets or sets the IsDirectValue value.
        /// </summary>
        public bool IsDirectValue
        {
            get { return _IsDirectValue; }
            set { _IsDirectValue = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Derived_Field value.
        /// </summary>
        public decimal? FK_Derived_Field
        {
            get { return _FK_Derived_Field; }
            set { _FK_Derived_Field = value; }
        }

        public bool? Diary_To_Current_User
        {
            get { return _Diary_To_Current_User; }
            set { _Diary_To_Current_User = value; }
        }

        public string Diary_Assign_To_Contact
        {
            get { return _Diary_Assign_To_Contact; }
            set { _Diary_Assign_To_Contact = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsBusiness_Rules class with default value.
        /// </summary>
        public clsBusiness_Rules()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsBusiness_Rules class based on Primary Key.
        /// </summary>
        public clsBusiness_Rules(decimal pK_Business_Rules)
        {
            DataTable dtBusiness_Rules = SelectByPK(pK_Business_Rules).Tables[0];

            if (dtBusiness_Rules.Rows.Count == 1)
            {
                SetValue(dtBusiness_Rules.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsBusiness_Rules class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drBusiness_Rules)
        {
            if (drBusiness_Rules["PK_Business_Rules"] == DBNull.Value)
                this._PK_Business_Rules = null;
            else
                this._PK_Business_Rules = (decimal?)drBusiness_Rules["PK_Business_Rules"];

            if (drBusiness_Rules["Rule_Name"] == DBNull.Value)
                this._Rule_Name = null;
            else
                this._Rule_Name = (string)drBusiness_Rules["Rule_Name"];

            if (drBusiness_Rules["Rule_Description"] == DBNull.Value)
                this._Rule_Description = null;
            else
                this._Rule_Description = (string)drBusiness_Rules["Rule_Description"];

            if (drBusiness_Rules["FK_Business_Rules_Modules"] == DBNull.Value)
                this._FK_Business_Rules_Modules = null;
            else
                this._FK_Business_Rules_Modules = (decimal?)drBusiness_Rules["FK_Business_Rules_Modules"];

            if (drBusiness_Rules["FK_Business_Rules_Screens"] == DBNull.Value)
                this._FK_Business_Rules_Screens = null;
            else
                this._FK_Business_Rules_Screens = (decimal?)drBusiness_Rules["FK_Business_Rules_Screens"];

            if (drBusiness_Rules["Table_Name"] == DBNull.Value)
                this._Table_Name = null;
            else
                this._Table_Name = (string)drBusiness_Rules["Table_Name"];

            if (drBusiness_Rules["Field"] == DBNull.Value)
                this._Field = null;
            else
                this._Field = (string)drBusiness_Rules["Field"];

            if (drBusiness_Rules["Evaluation_Criteria"] == DBNull.Value)
                this._Evaluation_Criteria = null;
            else
                this._Evaluation_Criteria = (string)drBusiness_Rules["Evaluation_Criteria"];

            if (drBusiness_Rules["Action_Type"] == DBNull.Value)
                this._Action_Type = null;
            else
                this._Action_Type = (string)drBusiness_Rules["Action_Type"];

            if (drBusiness_Rules["Action_Timing"] == DBNull.Value)
                this._Action_Timing = null;
            else
                this._Action_Timing = (string)drBusiness_Rules["Action_Timing"];

            if (drBusiness_Rules["EMail_Subject"] == DBNull.Value)
                this._EMail_Subject = null;
            else
                this._EMail_Subject = (string)drBusiness_Rules["EMail_Subject"];

            if (drBusiness_Rules["EMail_Body"] == DBNull.Value)
                this._EMail_Body = null;
            else
                this._EMail_Body = (string)drBusiness_Rules["EMail_Body"];

            if (drBusiness_Rules["Field_To_Update"] == DBNull.Value)
                this._Field_To_Update = null;
            else
                this._Field_To_Update = (string)drBusiness_Rules["Field_To_Update"];

            if (drBusiness_Rules["FK_Field_To_Update"] == DBNull.Value)
                this._FK_Field_To_Update = null;
            else
                this._FK_Field_To_Update = (decimal?)drBusiness_Rules["FK_Field_To_Update"];

            if (drBusiness_Rules["New_Value"] == DBNull.Value)
                this._New_Value = null;
            else
                this._New_Value = (string)drBusiness_Rules["New_Value"];

            if (drBusiness_Rules["Diary_Note"] == DBNull.Value)
                this._Diary_Note = null;
            else
                this._Diary_Note = (string)drBusiness_Rules["Diary_Note"];

            if (drBusiness_Rules["Diary_Assigned_To"] == DBNull.Value)
                this._Diary_Assigned_To = null;
            else
                this._Diary_Assigned_To = (string)drBusiness_Rules["Diary_Assigned_To"];

            if (drBusiness_Rules["Diary_Date_Value"] == DBNull.Value)
                this._Diary_Date_Value = null;
            else
                this._Diary_Date_Value = (int?)drBusiness_Rules["Diary_Date_Value"];

            if (drBusiness_Rules["Recipient_IDs"] == DBNull.Value)
                this._Recipient_IDs = null;
            else
                this._Recipient_IDs = (string)drBusiness_Rules["Recipient_IDs"];

            if (drBusiness_Rules["Email_Recipient_Fields"] == DBNull.Value)
                this._Email_Recipient_Fields = null;
            else
                this._Email_Recipient_Fields = (string)drBusiness_Rules["Email_Recipient_Fields"];

            if (drBusiness_Rules["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drBusiness_Rules["Update_Date"];

            if (drBusiness_Rules["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drBusiness_Rules["Updated_By"];

            if (drBusiness_Rules["IsDirectValue"] == DBNull.Value)
                this._IsDirectValue = true;
            else
                this._IsDirectValue = (bool)drBusiness_Rules["IsDirectValue"];

            if (drBusiness_Rules["FK_Derived_Field"] == DBNull.Value)
                this._FK_Derived_Field = null;
            else
                this._FK_Derived_Field = (decimal?)drBusiness_Rules["FK_Derived_Field"];
            
            if (drBusiness_Rules["Diary_To_Current_User"] == DBNull.Value)
                this._Diary_To_Current_User = null;
            else
                this._Diary_To_Current_User = (bool?)drBusiness_Rules["Diary_To_Current_User"];

            if (drBusiness_Rules["Diary_Assign_To_Contact"] == DBNull.Value)
                this._Diary_Assign_To_Contact = null;
            else
                this._Diary_Assign_To_Contact = (string)drBusiness_Rules["Diary_Assign_To_Contact"];

            this._Overwrite = false;



        }

        #endregion

        /// <summary>
        /// Inserts a record into the Business_Rules table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_RulesInsert");


            if (string.IsNullOrEmpty(this._Rule_Name))
                db.AddInParameter(dbCommand, "Rule_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Rule_Name", DbType.String, this._Rule_Name);

            if (string.IsNullOrEmpty(this._Rule_Description))
                db.AddInParameter(dbCommand, "Rule_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Rule_Description", DbType.String, this._Rule_Description);

            db.AddInParameter(dbCommand, "FK_Business_Rules_Modules", DbType.Decimal, this._FK_Business_Rules_Modules);

            db.AddInParameter(dbCommand, "FK_Business_Rules_Screens", DbType.Decimal, this._FK_Business_Rules_Screens);

            if (string.IsNullOrEmpty(this._Table_Name))
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);

            if (string.IsNullOrEmpty(this._Field))
                db.AddInParameter(dbCommand, "Field", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field", DbType.String, this._Field);

            if (string.IsNullOrEmpty(this._Evaluation_Criteria))
                db.AddInParameter(dbCommand, "Evaluation_Criteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Evaluation_Criteria", DbType.String, this._Evaluation_Criteria);

            if (string.IsNullOrEmpty(this._Action_Type))
                db.AddInParameter(dbCommand, "Action_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action_Type", DbType.String, this._Action_Type);

            if (string.IsNullOrEmpty(this._Action_Timing))
                db.AddInParameter(dbCommand, "Action_Timing", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action_Timing", DbType.String, this._Action_Timing);

            if (string.IsNullOrEmpty(this._EMail_Subject))
                db.AddInParameter(dbCommand, "EMail_Subject", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EMail_Subject", DbType.String, this._EMail_Subject);

            if (string.IsNullOrEmpty(this._EMail_Body))
                db.AddInParameter(dbCommand, "EMail_Body", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EMail_Body", DbType.String, this._EMail_Body);

            if (string.IsNullOrEmpty(this._Field_To_Update))
                db.AddInParameter(dbCommand, "Field_To_Update", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field_To_Update", DbType.String, this._Field_To_Update);

            db.AddInParameter(dbCommand, "FK_Field_To_Update", DbType.Decimal, this._FK_Field_To_Update);

            if (string.IsNullOrEmpty(this._New_Value))
                db.AddInParameter(dbCommand, "New_Value", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "New_Value", DbType.String, this._New_Value);

            if (string.IsNullOrEmpty(this._Diary_Note))
                db.AddInParameter(dbCommand, "Diary_Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Diary_Note", DbType.String, this._Diary_Note);

            if (string.IsNullOrEmpty(this._Diary_Assigned_To))
                db.AddInParameter(dbCommand, "Diary_Assigned_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Diary_Assigned_To", DbType.String, this._Diary_Assigned_To);

            db.AddInParameter(dbCommand, "Diary_Date_Value", DbType.Int32, this._Diary_Date_Value);

            if (string.IsNullOrEmpty(this._Recipient_IDs))
                db.AddInParameter(dbCommand, "Recipient_IDs", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Recipient_IDs", DbType.String, this._Recipient_IDs);

            if (string.IsNullOrEmpty(this._Email_Recipient_Fields))
                db.AddInParameter(dbCommand, "Email_Recipient_Fields", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email_Recipient_Fields", DbType.String, this._Email_Recipient_Fields);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            if (this._Overwrite == null)
                db.AddInParameter(dbCommand, "Overwrite", DbType.Boolean, false);
            else
                db.AddInParameter(dbCommand, "Overwrite", DbType.Boolean, this._Overwrite);

            if (this._IsDirectValue == null)
                db.AddInParameter(dbCommand, "IsDirectValue", DbType.Boolean, false);
            else
                db.AddInParameter(dbCommand, "IsDirectValue", DbType.Boolean, this._IsDirectValue);

            db.AddInParameter(dbCommand, "FK_Derived_Field", DbType.Decimal, this._FK_Derived_Field);

            db.AddInParameter(dbCommand, "Diary_To_Current_User", DbType.Boolean, this._Diary_To_Current_User);
            db.AddInParameter(dbCommand, "Diary_Assign_To_Contact", DbType.String, this._Diary_Assign_To_Contact);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Auto claim Search
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet BusinessRuleSearch(decimal fK_Module, decimal fK_Screen, string Rule_Name, string Action_Type, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BusinessRuleSearch");

            db.AddInParameter(dbCommand, "FK_Module", DbType.Int32, fK_Module);
            db.AddInParameter(dbCommand, "FK_Screen", DbType.Int32, fK_Screen);
            db.AddInParameter(dbCommand, "Rule_Name", DbType.String, Rule_Name);
            db.AddInParameter(dbCommand, "Action_Type", DbType.String, Action_Type);

            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            dbCommand.CommandTimeout = 10000;

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Business_Rules table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Business_Rules)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_RulesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Business_Rules", DbType.Decimal, pK_Business_Rules);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Business_Rules table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_RulesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Business_Rules table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_RulesUpdate");


            db.AddInParameter(dbCommand, "PK_Business_Rules", DbType.Decimal, this._PK_Business_Rules);

            if (string.IsNullOrEmpty(this._Rule_Name))
                db.AddInParameter(dbCommand, "Rule_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Rule_Name", DbType.String, this._Rule_Name);

            if (string.IsNullOrEmpty(this._Rule_Description))
                db.AddInParameter(dbCommand, "Rule_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Rule_Description", DbType.String, this._Rule_Description);

            db.AddInParameter(dbCommand, "FK_Business_Rules_Modules", DbType.Decimal, this._FK_Business_Rules_Modules);

            db.AddInParameter(dbCommand, "FK_Business_Rules_Screens", DbType.Decimal, this._FK_Business_Rules_Screens);

            if (string.IsNullOrEmpty(this._Table_Name))
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);

            if (string.IsNullOrEmpty(this._Field))
                db.AddInParameter(dbCommand, "Field", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field", DbType.String, this._Field);

            if (string.IsNullOrEmpty(this._Evaluation_Criteria))
                db.AddInParameter(dbCommand, "Evaluation_Criteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Evaluation_Criteria", DbType.String, this._Evaluation_Criteria);

            if (string.IsNullOrEmpty(this._Action_Type))
                db.AddInParameter(dbCommand, "Action_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action_Type", DbType.String, this._Action_Type);

            if (string.IsNullOrEmpty(this._Action_Timing))
                db.AddInParameter(dbCommand, "Action_Timing", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action_Timing", DbType.String, this._Action_Timing);

            if (string.IsNullOrEmpty(this._EMail_Subject))
                db.AddInParameter(dbCommand, "EMail_Subject", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EMail_Subject", DbType.String, this._EMail_Subject);

            if (string.IsNullOrEmpty(this._EMail_Body))
                db.AddInParameter(dbCommand, "EMail_Body", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EMail_Body", DbType.String, this._EMail_Body);

            if (string.IsNullOrEmpty(this._Field_To_Update))
                db.AddInParameter(dbCommand, "Field_To_Update", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field_To_Update", DbType.String, this._Field_To_Update);

            db.AddInParameter(dbCommand, "FK_Field_To_Update", DbType.Decimal, this._FK_Field_To_Update);

            if (string.IsNullOrEmpty(this._New_Value))
                db.AddInParameter(dbCommand, "New_Value", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "New_Value", DbType.String, this._New_Value);

            if (string.IsNullOrEmpty(this._Diary_Note))
                db.AddInParameter(dbCommand, "Diary_Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Diary_Note", DbType.String, this._Diary_Note);

            if (string.IsNullOrEmpty(this._Diary_Assigned_To))
                db.AddInParameter(dbCommand, "Diary_Assigned_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Diary_Assigned_To", DbType.String, this._Diary_Assigned_To);

            db.AddInParameter(dbCommand, "Diary_Date_Value", DbType.Int32, this._Diary_Date_Value);

            if (string.IsNullOrEmpty(this._Recipient_IDs))
                db.AddInParameter(dbCommand, "Recipient_IDs", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Recipient_IDs", DbType.String, this._Recipient_IDs);

            if (string.IsNullOrEmpty(this._Email_Recipient_Fields))
                db.AddInParameter(dbCommand, "Email_Recipient_Fields", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email_Recipient_Fields", DbType.String, this._Email_Recipient_Fields);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            if (this._Overwrite == null)
                db.AddInParameter(dbCommand, "Overwrite", DbType.Boolean, false);
            else
                db.AddInParameter(dbCommand, "Overwrite", DbType.Boolean, this._Overwrite);

            if (this._IsDirectValue == null)
                db.AddInParameter(dbCommand, "IsDirectValue", DbType.Boolean, true);
            else
                db.AddInParameter(dbCommand, "IsDirectValue", DbType.Boolean, this._IsDirectValue);

            db.AddInParameter(dbCommand, "FK_Derived_Field", DbType.Decimal, this._FK_Derived_Field);
            db.AddInParameter(dbCommand, "Diary_To_Current_User", DbType.Boolean, this._Diary_To_Current_User);
            db.AddInParameter(dbCommand, "Diary_Assign_To_Contact", DbType.String, this._Diary_Assign_To_Contact);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));

        }

        ///// <summary>
        ///// Updates a record in the Business_Rules table.
        ///// </summary>
        //public int UpdateOverwrite()
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("Business_RulesUpdate_Overwrite");


        //    db.AddInParameter(dbCommand, "PK_Business_Rules", DbType.Decimal, this._PK_Business_Rules);

        //    if (string.IsNullOrEmpty(this._Rule_Name))
        //        db.AddInParameter(dbCommand, "Rule_Name", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Rule_Name", DbType.String, this._Rule_Name);

        //    if (string.IsNullOrEmpty(this._Rule_Description))
        //        db.AddInParameter(dbCommand, "Rule_Description", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Rule_Description", DbType.String, this._Rule_Description);

        //    db.AddInParameter(dbCommand, "FK_Business_Rules_Modules", DbType.Decimal, this._FK_Business_Rules_Modules);

        //    db.AddInParameter(dbCommand, "FK_Business_Rules_Screens", DbType.Decimal, this._FK_Business_Rules_Screens);

        //    if (string.IsNullOrEmpty(this._Table_Name))
        //        db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);

        //    if (string.IsNullOrEmpty(this._Field))
        //        db.AddInParameter(dbCommand, "Field", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Field", DbType.String, this._Field);

        //    if (string.IsNullOrEmpty(this._Evaluation_Criteria))
        //        db.AddInParameter(dbCommand, "Evaluation_Criteria", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Evaluation_Criteria", DbType.String, this._Evaluation_Criteria);

        //    if (string.IsNullOrEmpty(this._Action_Type))
        //        db.AddInParameter(dbCommand, "Action_Type", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Action_Type", DbType.String, this._Action_Type);

        //    if (string.IsNullOrEmpty(this._Action_Timing))
        //        db.AddInParameter(dbCommand, "Action_Timing", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Action_Timing", DbType.String, this._Action_Timing);

        //    if (string.IsNullOrEmpty(this._EMail_Subject))
        //        db.AddInParameter(dbCommand, "EMail_Subject", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "EMail_Subject", DbType.String, this._EMail_Subject);

        //    if (string.IsNullOrEmpty(this._EMail_Body))
        //        db.AddInParameter(dbCommand, "EMail_Body", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "EMail_Body", DbType.String, this._EMail_Body);

        //    if (string.IsNullOrEmpty(this._Field_To_Update))
        //        db.AddInParameter(dbCommand, "Field_To_Update", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Field_To_Update", DbType.String, this._Field_To_Update);

        //    if (string.IsNullOrEmpty(this._New_Value))
        //        db.AddInParameter(dbCommand, "New_Value", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "New_Value", DbType.String, this._New_Value);

        //    if (string.IsNullOrEmpty(this._Diary_Note))
        //        db.AddInParameter(dbCommand, "Diary_Note", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Diary_Note", DbType.String, this._Diary_Note);

        //    if (string.IsNullOrEmpty(this._Diary_Assigned_To))
        //        db.AddInParameter(dbCommand, "Diary_Assigned_To", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Diary_Assigned_To", DbType.String, this._Diary_Assigned_To);

        //    db.AddInParameter(dbCommand, "Diary_Date_Value", DbType.DateTime, this._Diary_Date_Value);

        //    if (string.IsNullOrEmpty(this._Recipient_IDs))
        //        db.AddInParameter(dbCommand, "Recipient_IDs", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Recipient_IDs", DbType.String, this._Recipient_IDs);

        //    db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

        //    if (string.IsNullOrEmpty(this._Updated_By))
        //        db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
        //    else
        //        db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

        //    return Convert.ToInt32(db.ExecuteScalar(dbCommand));

        //}

        /// <summary>
        /// Deletes a record from the Business_Rules table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Business_Rules)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_RulesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Business_Rules", DbType.Decimal, pK_Business_Rules);

            db.ExecuteNonQuery(dbCommand);
        }
        public static void ExecuteBusinessRules(Screen ScreenID, string strPK_Column_Name, decimal decPK_Table, string strFK_Column_Name, decimal decFK_Table, string strCurr_Transaction, string strUpdated_By, string strModuleName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Run_Business_Rule_Action");

            db.AddInParameter(dbCommand, "FK_Rules_Screens", DbType.Int32, (Int32)ScreenID);
            db.AddInParameter(dbCommand, "PK_Column_Name", DbType.String, strPK_Column_Name);
            db.AddInParameter(dbCommand, "PK_Table", DbType.Decimal, decPK_Table);
            db.AddInParameter(dbCommand, "FK_Column_Name", DbType.String, strFK_Column_Name);
            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, decFK_Table);
            db.AddInParameter(dbCommand, "Curr_Transaction", DbType.String, strCurr_Transaction);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, strUpdated_By);
            db.AddInParameter(dbCommand, "ModuleName", DbType.String, strModuleName);

            db.ExecuteNonQuery(dbCommand);
        }

    }
}
