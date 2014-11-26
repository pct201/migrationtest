using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for COI_Letter_History table.
    /// </summary>
    public sealed class COI_Letter_History
    {
         

        #region Fields

        private decimal _PK_COI_Letter_History;
        private decimal _FK_COIs;
        private DateTime _Date_Letter_Sent;
        private string _Sent_By_EMail;
        private decimal _FK_COI_Noncompliance_Level;
        private decimal _FK_COI_Coverage_Status_General;
        private decimal _FK_COI_Coverage_Status_Automobile;
        private decimal _FK_COI_Coverage_Status_Excess;
        private decimal _FK_COI_Coverage_Status_WC;
        private decimal _FK_COI_Coverage_Status_Property;
        private decimal _FK_COI_Coverage_Status_Prfessional;
        private string _Signed_Certificate_Received;
        private string _Primary_Provided;
        private string _Cancellation_Notice;
        private string _All_Locations;
        private string _AM_Best;
        private string _Ordinance_Law;
        private string _Subrogation_Waiver;
        private string _Perils_Insured_Form;
        private string _Property_On_Acord;
        private string _Replacement_Cost;
        private string _Insured_Perils;
        private string _Insured_Name_Same;
        private string _Additional_Insured_Not_Provided;
        private string _LeveL_1_Text;
        private string _LeveL_2_Text;
        private string _LeveL_3_Text;
        private string _LeveL_4_Text;
        private DateTime _Update_Date;
        private string _Updated_By;
        private string _Letter;
        private string _Envelopes;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Letter_History value.
        /// </summary>
        public decimal PK_COI_Letter_History
        {
            get { return _PK_COI_Letter_History; }
            set { _PK_COI_Letter_History = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COIs value.
        /// </summary>
        public decimal FK_COIs
        {
            get { return _FK_COIs; }
            set { _FK_COIs = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Letter_Sent value.
        /// </summary>
        public DateTime Date_Letter_Sent
        {
            get { return _Date_Letter_Sent; }
            set { _Date_Letter_Sent = value; }
        }


        /// <summary> 
        /// Gets or sets the Sent_By_EMail value.
        /// </summary>
        public string Sent_By_EMail
        {
            get { return _Sent_By_EMail; }
            set { _Sent_By_EMail = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Noncompliance_Level value.
        /// </summary>
        public decimal FK_COI_Noncompliance_Level
        {
            get { return _FK_COI_Noncompliance_Level; }
            set { _FK_COI_Noncompliance_Level = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Coverage_Status_General value.
        /// </summary>
        public decimal FK_COI_Coverage_Status_General
        {
            get { return _FK_COI_Coverage_Status_General; }
            set { _FK_COI_Coverage_Status_General = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Coverage_Status_Automobile value.
        /// </summary>
        public decimal FK_COI_Coverage_Status_Automobile
        {
            get { return _FK_COI_Coverage_Status_Automobile; }
            set { _FK_COI_Coverage_Status_Automobile = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Coverage_Status_Excess value.
        /// </summary>
        public decimal FK_COI_Coverage_Status_Excess
        {
            get { return _FK_COI_Coverage_Status_Excess; }
            set { _FK_COI_Coverage_Status_Excess = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Coverage_Status_WC value.
        /// </summary>
        public decimal FK_COI_Coverage_Status_WC
        {
            get { return _FK_COI_Coverage_Status_WC; }
            set { _FK_COI_Coverage_Status_WC = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Coverage_Status_Property value.
        /// </summary>
        public decimal FK_COI_Coverage_Status_Property
        {
            get { return _FK_COI_Coverage_Status_Property; }
            set { _FK_COI_Coverage_Status_Property = value; }
        }

        public decimal FK_COI_Coverage_Status_Prfessional
        {
            get { return _FK_COI_Coverage_Status_Prfessional; }
            set { _FK_COI_Coverage_Status_Prfessional = value; }
        }

        /// <summary> 
        /// Gets or sets the Signed_Certificate_Received value.
        /// </summary>
        public string Signed_Certificate_Received
        {
            get { return _Signed_Certificate_Received; }
            set { _Signed_Certificate_Received = value; }
        }


        /// <summary> 
        /// Gets or sets the Primary_Provided value.
        /// </summary>
        public string Primary_Provided
        {
            get { return _Primary_Provided; }
            set { _Primary_Provided = value; }
        }


        /// <summary> 
        /// Gets or sets the Cancellation_Notice value.
        /// </summary>
        public string Cancellation_Notice
        {
            get { return _Cancellation_Notice; }
            set { _Cancellation_Notice = value; }
        }


        /// <summary> 
        /// Gets or sets the All_Locations value.
        /// </summary>
        public string All_Locations
        {
            get { return _All_Locations; }
            set { _All_Locations = value; }
        }


        /// <summary> 
        /// Gets or sets the AM_Best value.
        /// </summary>
        public string AM_Best
        {
            get { return _AM_Best; }
            set { _AM_Best = value; }
        }


        /// <summary> 
        /// Gets or sets the Ordinance_Law value.
        /// </summary>
        public string Ordinance_Law
        {
            get { return _Ordinance_Law; }
            set { _Ordinance_Law = value; }
        }


        /// <summary> 
        /// Gets or sets the Subrogation_Waiver value.
        /// </summary>
        public string Subrogation_Waiver
        {
            get { return _Subrogation_Waiver; }
            set { _Subrogation_Waiver = value; }
        }


        /// <summary> 
        /// Gets or sets the Perils_Insured_Form value.
        /// </summary>
        public string Perils_Insured_Form
        {
            get { return _Perils_Insured_Form; }
            set { _Perils_Insured_Form = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_On_Acord value.
        /// </summary>
        public string Property_On_Acord
        {
            get { return _Property_On_Acord; }
            set { _Property_On_Acord = value; }
        }


        /// <summary> 
        /// Gets or sets the Replacement_Cost value.
        /// </summary>
        public string Replacement_Cost
        {
            get { return _Replacement_Cost; }
            set { _Replacement_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Insured_Perils value.
        /// </summary>
        public string Insured_Perils
        {
            get { return _Insured_Perils; }
            set { _Insured_Perils = value; }
        }


        /// <summary> 
        /// Gets or sets the Insured_Name_Same value.
        /// </summary>
        public string Insured_Name_Same
        {
            get { return _Insured_Name_Same; }
            set { _Insured_Name_Same = value; }
        }


        /// <summary> 
        /// Gets or sets the Additional_Insured_Not_Provided value.
        /// </summary>
        public string Additional_Insured_Not_Provided
        {
            get { return _Additional_Insured_Not_Provided; }
            set { _Additional_Insured_Not_Provided = value; }
        }


        /// <summary> 
        /// Gets or sets the LeveL_1_Text value.
        /// </summary>
        public string LeveL_1_Text
        {
            get { return _LeveL_1_Text; }
            set { _LeveL_1_Text = value; }
        }


        /// <summary> 
        /// Gets or sets the LeveL_2_Text value.
        /// </summary>
        public string LeveL_2_Text
        {
            get { return _LeveL_2_Text; }
            set { _LeveL_2_Text = value; }
        }


        /// <summary> 
        /// Gets or sets the LeveL_3_Text value.
        /// </summary>
        public string LeveL_3_Text
        {
            get { return _LeveL_3_Text; }
            set { _LeveL_3_Text = value; }
        }


        /// <summary> 
        /// Gets or sets the LeveL_4_Text value.
        /// </summary>
        public string LeveL_4_Text
        {
            get { return _LeveL_4_Text; }
            set { _LeveL_4_Text = value; }
        }


        /// <summary> 
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
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
        /// Gets or sets the Letter value.
        /// </summary>
        public string Letter
        {
            get { return _Letter; }
            set { _Letter = value; }
        }

        /// <summary> 
        /// Gets or sets the Envelopes value.
        /// </summary>
        public string Envelopes
        {
            get { return _Envelopes; }
            set { _Envelopes = value; }
        }


        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_Letter_History class. with the default value.

        /// </summary>
        public COI_Letter_History()
        {

            this._PK_COI_Letter_History = -1;
            this._FK_COIs = -1;
            this._Date_Letter_Sent = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Sent_By_EMail = "";
            this._FK_COI_Noncompliance_Level = -1;
            this._FK_COI_Coverage_Status_General = -1;
            this._FK_COI_Coverage_Status_Automobile = -1;
            this._FK_COI_Coverage_Status_Excess = -1;
            this._FK_COI_Coverage_Status_WC = -1;
            this._FK_COI_Coverage_Status_Property = -1;
            this._FK_COI_Coverage_Status_Prfessional = -1;
            this._Signed_Certificate_Received = "";
            this._Primary_Provided = "";
            this._Cancellation_Notice = "";
            this._All_Locations = "";
            this._AM_Best = "";
            this._Ordinance_Law = "";
            this._Subrogation_Waiver = "";
            this._Perils_Insured_Form = "";
            this._Property_On_Acord = "";
            this._Replacement_Cost = "";
            this._Insured_Perils = "";
            this._Insured_Name_Same = "";
            this._Additional_Insured_Not_Provided = "";
            this._LeveL_1_Text = "";
            this._LeveL_2_Text = "";
            this._LeveL_3_Text = "";
            this._LeveL_4_Text = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Updated_By = "";
            this._Letter = "";
            this._Envelopes = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Letter_History class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Letter_History(decimal PK)
        {
            DataTable dtCOI_Letter_History = Select(PK).Tables[0];

            if (dtCOI_Letter_History.Rows.Count > 0)
            {

                DataRow drCOI_Letter_History = dtCOI_Letter_History.Rows[0];
                this._PK_COI_Letter_History = drCOI_Letter_History["PK_COI_Letter_History"] != DBNull.Value ? Convert.ToDecimal(drCOI_Letter_History["PK_COI_Letter_History"]) : 0;
                this._FK_COIs = drCOI_Letter_History["FK_COIs"] != DBNull.Value ? Convert.ToDecimal(drCOI_Letter_History["FK_COIs"]) : 0;
                this._Date_Letter_Sent = drCOI_Letter_History["Date_Letter_Sent"] != DBNull.Value ? Convert.ToDateTime(drCOI_Letter_History["Date_Letter_Sent"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Sent_By_EMail = Convert.ToString(drCOI_Letter_History["Sent_By_EMail"]);
                this._FK_COI_Noncompliance_Level = drCOI_Letter_History["FK_COI_Noncompliance_Level"] != DBNull.Value ? Convert.ToDecimal(drCOI_Letter_History["FK_COI_Noncompliance_Level"]) : 0;
                this._FK_COI_Coverage_Status_General = drCOI_Letter_History["FK_COI_Coverage_Status_General"] != DBNull.Value ? Convert.ToDecimal(drCOI_Letter_History["FK_COI_Coverage_Status_General"]) : 0;
                this._FK_COI_Coverage_Status_Automobile = drCOI_Letter_History["FK_COI_Coverage_Status_Automobile"] != DBNull.Value ? Convert.ToDecimal(drCOI_Letter_History["FK_COI_Coverage_Status_Automobile"]) : 0;
                this._FK_COI_Coverage_Status_Excess = drCOI_Letter_History["FK_COI_Coverage_Status_Excess"] != DBNull.Value ? Convert.ToDecimal(drCOI_Letter_History["FK_COI_Coverage_Status_Excess"]) : 0;
                this._FK_COI_Coverage_Status_WC = drCOI_Letter_History["FK_COI_Coverage_Status_WC"] != DBNull.Value ? Convert.ToDecimal(drCOI_Letter_History["FK_COI_Coverage_Status_WC"]) : 0;
                this._FK_COI_Coverage_Status_Property = drCOI_Letter_History["FK_COI_Coverage_Status_Property"] != DBNull.Value ? Convert.ToDecimal(drCOI_Letter_History["FK_COI_Coverage_Status_Property"]) : 0;
                this._FK_COI_Coverage_Status_Prfessional = drCOI_Letter_History["FK_COI_Coverage_Status_Prfessional"] != DBNull.Value ? Convert.ToDecimal(drCOI_Letter_History["FK_COI_Coverage_Status_Prfessional"]) : 0;
                this._Signed_Certificate_Received = Convert.ToString(drCOI_Letter_History["Signed_Certificate_Received"]);
                this._Primary_Provided = Convert.ToString(drCOI_Letter_History["Primary_Provided"]);
                this._Cancellation_Notice = Convert.ToString(drCOI_Letter_History["Cancellation_Notice"]);
                this._All_Locations = Convert.ToString(drCOI_Letter_History["All_Locations"]);
                this._AM_Best = Convert.ToString(drCOI_Letter_History["AM_Best"]);
                this._Ordinance_Law = Convert.ToString(drCOI_Letter_History["Ordinance_Law"]);
                this._Subrogation_Waiver = Convert.ToString(drCOI_Letter_History["Subrogation_Waiver"]);
                this._Perils_Insured_Form = Convert.ToString(drCOI_Letter_History["Perils_Insured_Form"]);
                this._Property_On_Acord = Convert.ToString(drCOI_Letter_History["Property_On_Acord"]);
                this._Replacement_Cost = Convert.ToString(drCOI_Letter_History["Replacement_Cost"]);
                this._Insured_Perils = Convert.ToString(drCOI_Letter_History["Insured_Perils"]);
                this._Insured_Name_Same = Convert.ToString(drCOI_Letter_History["Insured_Name_Same"]);
                this._Additional_Insured_Not_Provided = Convert.ToString(drCOI_Letter_History["Additional_Insured_Not_Provided"]);
                this._LeveL_1_Text = Convert.ToString(drCOI_Letter_History["LeveL_1_Text"]);
                this._LeveL_2_Text = Convert.ToString(drCOI_Letter_History["LeveL_2_Text"]);
                this._LeveL_3_Text = Convert.ToString(drCOI_Letter_History["LeveL_3_Text"]);
                this._LeveL_4_Text = Convert.ToString(drCOI_Letter_History["LeveL_4_Text"]);
                this._Update_Date = drCOI_Letter_History["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Letter_History["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Updated_By = Convert.ToString(drCOI_Letter_History["Updated_By"]);
                this._Letter = clsGeneral.DecompressString(Convert.ToString(drCOI_Letter_History["Letter"])); // string for letter is stored in compresssed format
                this._Envelopes = clsGeneral.DecompressString(Convert.ToString(drCOI_Letter_History["Envelopes"])); // string for envelopes is stroed in compressed format

            }
            else
            {

                this._PK_COI_Letter_History = -1;
                this._FK_COIs = -1;
                this._Date_Letter_Sent = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Sent_By_EMail = "";
                this._FK_COI_Noncompliance_Level = -1;
                this._FK_COI_Coverage_Status_General = -1;
                this._FK_COI_Coverage_Status_Automobile = -1;
                this._FK_COI_Coverage_Status_Excess = -1;
                this._FK_COI_Coverage_Status_WC = -1;
                this._FK_COI_Coverage_Status_Property = -1;
                this._FK_COI_Coverage_Status_Prfessional = -1;
                this._Signed_Certificate_Received = "";
                this._Primary_Provided = "";
                this._Cancellation_Notice = "";
                this._All_Locations = "";
                this._AM_Best = "";
                this._Ordinance_Law = "";
                this._Subrogation_Waiver = "";
                this._Perils_Insured_Form = "";
                this._Property_On_Acord = "";
                this._Replacement_Cost = "";
                this._Insured_Perils = "";
                this._Insured_Name_Same = "";
                this._Additional_Insured_Not_Provided = "";
                this._LeveL_1_Text = "";
                this._LeveL_2_Text = "";
                this._LeveL_3_Text = "";
                this._LeveL_4_Text = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = "";
                this._Letter = "";
                this._Envelopes = "";
            }

        }



        #endregion

        #region "Methods"
        /// <summary>
        /// Inserts a record into the COI_Letter_History table.
        /// <summary>
        /// <param name="fK_COIs"></param>
        /// <param name="date_Letter_Sent"></param>
        /// <param name="sent_By_EMail"></param>
        /// <param name="fK_COI_Noncompliance_Level"></param>
        /// <param name="fK_COI_Coverage_Status_General"></param>
        /// <param name="fK_COI_Coverage_Status_Automobile"></param>
        /// <param name="fK_COI_Coverage_Status_Excess"></param>
        /// <param name="fK_COI_Coverage_Status_WC"></param>
        /// <param name="fK_COI_Coverage_Status_Property"></param>
        /// <param name="signed_Certificate_Received"></param>
        /// <param name="primary_Provided"></param>
        /// <param name="cancellation_Notice"></param>
        /// <param name="all_Locations"></param>
        /// <param name="aM_Best"></param>
        /// <param name="ordinance_Law"></param>
        /// <param name="subrogation_Waiver"></param>
        /// <param name="perils_Insured_Form"></param>
        /// <param name="property_On_Acord"></param>
        /// <param name="replacement_Cost"></param>
        /// <param name="insured_Perils"></param>
        /// <param name="insured_Name_Same"></param>
        /// <param name="additional_Insured_Not_Provided"></param>
        /// <param name="leveL_1_Text"></param>
        /// <param name="leveL_2_Text"></param>
        /// <param name="leveL_3_Text"></param>
        /// <param name="leveL_4_Text"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        /// <returns></returns>
        public static int Insert(decimal fK_COIs, DateTime date_Letter_Sent, string sent_By_EMail, decimal fK_COI_Noncompliance_Level, decimal fK_COI_Coverage_Status_General, decimal fK_COI_Coverage_Status_Automobile, decimal fK_COI_Coverage_Status_Excess, decimal fK_COI_Coverage_Status_WC, decimal fK_COI_Coverage_Status_Property,decimal fK_COI_Coverage_Status_Prfessional, string signed_Certificate_Received, string primary_Provided, string cancellation_Notice, string all_Locations, string aM_Best, string ordinance_Law, string subrogation_Waiver, string perils_Insured_Form, string property_On_Acord, string replacement_Cost, string insured_Perils, string insured_Name_Same, string additional_Insured_Not_Provided, string leveL_1_Text, string leveL_2_Text, string leveL_3_Text, string leveL_4_Text, DateTime update_Date, string updated_By,string letter,string envelopes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryInsert");

            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
            db.AddInParameter(dbCommand, "Date_Letter_Sent", DbType.DateTime, date_Letter_Sent);
            db.AddInParameter(dbCommand, "Sent_By_EMail", DbType.String, sent_By_EMail);
            db.AddInParameter(dbCommand, "FK_COI_Noncompliance_Level", DbType.Decimal, fK_COI_Noncompliance_Level);
            db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_General", DbType.Decimal, fK_COI_Coverage_Status_General);
            db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Automobile", DbType.Decimal, fK_COI_Coverage_Status_Automobile);
            db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Excess", DbType.Decimal, fK_COI_Coverage_Status_Excess);
            db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_WC", DbType.Decimal, fK_COI_Coverage_Status_WC);
            db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Property", DbType.Decimal, fK_COI_Coverage_Status_Property);
            db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Prfessional", DbType.Decimal, fK_COI_Coverage_Status_Prfessional);  
            db.AddInParameter(dbCommand, "Signed_Certificate_Received", DbType.String, signed_Certificate_Received);
            db.AddInParameter(dbCommand, "Primary_Provided", DbType.String, primary_Provided);
            db.AddInParameter(dbCommand, "Cancellation_Notice", DbType.String, cancellation_Notice);
            db.AddInParameter(dbCommand, "All_Locations", DbType.String, all_Locations);
            db.AddInParameter(dbCommand, "AM_Best", DbType.String, aM_Best);
            db.AddInParameter(dbCommand, "Ordinance_Law", DbType.String, ordinance_Law);
            db.AddInParameter(dbCommand, "Subrogation_Waiver", DbType.String, subrogation_Waiver);
            db.AddInParameter(dbCommand, "Perils_Insured_Form", DbType.String, perils_Insured_Form);
            db.AddInParameter(dbCommand, "Property_On_Acord", DbType.String, property_On_Acord);
            db.AddInParameter(dbCommand, "Replacement_Cost", DbType.String, replacement_Cost);
            db.AddInParameter(dbCommand, "Insured_Perils", DbType.String, insured_Perils);
            db.AddInParameter(dbCommand, "Insured_Name_Same", DbType.String, insured_Name_Same);
            db.AddInParameter(dbCommand, "Additional_Insured_Not_Provided", DbType.String, additional_Insured_Not_Provided);
            db.AddInParameter(dbCommand, "LeveL_1_Text", DbType.String, leveL_1_Text);
            db.AddInParameter(dbCommand, "LeveL_2_Text", DbType.String, leveL_2_Text);
            db.AddInParameter(dbCommand, "LeveL_3_Text", DbType.String, leveL_3_Text);
            db.AddInParameter(dbCommand, "LeveL_4_Text", DbType.String, leveL_4_Text);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Letter", DbType.String,clsGeneral.CompressString(letter)); // as it's a large text,it's stored in compressed format in the db
            db.AddInParameter(dbCommand, "Envelopes", DbType.String,clsGeneral.CompressString(envelopes)); // as it's a large text,it's stored in compressed format in the db

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the COI_Letter_History table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pK_COI_Letter_History)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistorySelect");

            db.AddInParameter(dbCommand, "PK_COI_Letter_History", DbType.Decimal, pK_COI_Letter_History);

            return db.ExecuteDataSet(dbCommand);
        }

       

        /// <summary>
        /// Selects records from the COI_Letter_History table by a foreign key.
        /// <summary>
        /// <param name="fK_COIs"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_COIs(decimal fK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistorySelectByFK_COIs");

            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

            return db.ExecuteDataSet(dbCommand);
        }

        ///// <summary>
        ///// Selects records from the COI_Letter_History table by a foreign key.
        ///// <summary>
        ///// <param name="fK_COI_Coverage_Status_Excess"></param>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectByFK_COI_Coverage_Status_Excess(decimal fK_COI_Coverage_Status_Excess)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistorySelectByFK_COI_Coverage_Status_Excess");

        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Excess", DbType.Decimal, fK_COI_Coverage_Status_Excess);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        ///// <summary>
        ///// Selects records from the COI_Letter_History table by a foreign key.
        ///// <summary>
        ///// <param name="fK_COI_Coverage_Status_WC"></param>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectByFK_COI_Coverage_Status_WC(decimal fK_COI_Coverage_Status_WC)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistorySelectByFK_COI_Coverage_Status_WC");

        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_WC", DbType.Decimal, fK_COI_Coverage_Status_WC);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        ///// <summary>
        ///// Selects records from the COI_Letter_History table by a foreign key.
        ///// <summary>
        ///// <param name="fK_COI_Coverage_Status_Automobile"></param>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectByFK_COI_Coverage_Status_Automobile(decimal fK_COI_Coverage_Status_Automobile)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistorySelectByFK_COI_Coverage_Status_Automobile");

        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Automobile", DbType.Decimal, fK_COI_Coverage_Status_Automobile);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        /// <summary>
        /// Selects all records from the COI_Letter_History table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistorySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        ///// <summary>
        ///// Updates a record in the COI_Letter_History table.
        ///// <summary>
        ///// <param name="pK_COI_Letter_History"></param>
        ///// <param name="fK_COIs"></param>
        ///// <param name="date_Letter_Sent"></param>
        ///// <param name="sent_By_EMail"></param>
        ///// <param name="fK_COI_Noncompliance_Level"></param>
        ///// <param name="fK_COI_Coverage_Status_General"></param>
        ///// <param name="fK_COI_Coverage_Status_Automobile"></param>
        ///// <param name="fK_COI_Coverage_Status_Excess"></param>
        ///// <param name="fK_COI_Coverage_Status_WC"></param>
        ///// <param name="fK_COI_Coverage_Status_Property"></param>
        ///// <param name="signed_Certificate_Received"></param>
        ///// <param name="primary_Provided"></param>
        ///// <param name="cancellation_Notice"></param>
        ///// <param name="all_Locations"></param>
        ///// <param name="aM_Best"></param>
        ///// <param name="ordinance_Law"></param>
        ///// <param name="subrogation_Waiver"></param>
        ///// <param name="perils_Insured_Form"></param>
        ///// <param name="property_On_Acord"></param>
        ///// <param name="replacement_Cost"></param>
        ///// <param name="insured_Perils"></param>
        ///// <param name="insured_Name_Same"></param>
        ///// <param name="additional_Insured_Not_Provided"></param>
        ///// <param name="leveL_1_Text"></param>
        ///// <param name="leveL_2_Text"></param>
        ///// <param name="leveL_3_Text"></param>
        ///// <param name="leveL_4_Text"></param>
        ///// <param name="update_Date"></param>
        ///// <param name="updated_By"></param>
        //public static void Update(decimal pK_COI_Letter_History, decimal fK_COIs, DateTime date_Letter_Sent, string sent_By_EMail, decimal fK_COI_Noncompliance_Level, decimal fK_COI_Coverage_Status_General, decimal fK_COI_Coverage_Status_Automobile, decimal fK_COI_Coverage_Status_Excess, decimal fK_COI_Coverage_Status_WC, decimal fK_COI_Coverage_Status_Property,decimal fK_COI_Coverage_Status_Prfessional, string signed_Certificate_Received, string primary_Provided, string cancellation_Notice, string all_Locations, string aM_Best, string ordinance_Law, string subrogation_Waiver, string perils_Insured_Form, string property_On_Acord, string replacement_Cost, string insured_Perils, string insured_Name_Same, string additional_Insured_Not_Provided, string leveL_1_Text, string leveL_2_Text, string leveL_3_Text, string leveL_4_Text, DateTime update_Date, string updated_By)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryUpdate");

        //    db.AddInParameter(dbCommand, "PK_COI_Letter_History", DbType.Decimal, pK_COI_Letter_History);
        //    db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
        //    db.AddInParameter(dbCommand, "Date_Letter_Sent", DbType.DateTime, date_Letter_Sent);
        //    db.AddInParameter(dbCommand, "Sent_By_EMail", DbType.String, sent_By_EMail);
        //    db.AddInParameter(dbCommand, "FK_COI_Noncompliance_Level", DbType.Decimal, fK_COI_Noncompliance_Level);
        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_General", DbType.Decimal, fK_COI_Coverage_Status_General);
        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Automobile", DbType.Decimal, fK_COI_Coverage_Status_Automobile);
        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Excess", DbType.Decimal, fK_COI_Coverage_Status_Excess);
        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_WC", DbType.Decimal, fK_COI_Coverage_Status_WC);
        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Property", DbType.Decimal, fK_COI_Coverage_Status_Property);
        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Prfessional", DbType.Decimal, fK_COI_Coverage_Status_Prfessional); 
        //    db.AddInParameter(dbCommand, "Signed_Certificate_Received", DbType.String, signed_Certificate_Received);
        //    db.AddInParameter(dbCommand, "Primary_Provided", DbType.String, primary_Provided);
        //    db.AddInParameter(dbCommand, "Cancellation_Notice", DbType.String, cancellation_Notice);
        //    db.AddInParameter(dbCommand, "All_Locations", DbType.String, all_Locations);
        //    db.AddInParameter(dbCommand, "AM_Best", DbType.String, aM_Best);
        //    db.AddInParameter(dbCommand, "Ordinance_Law", DbType.String, ordinance_Law);
        //    db.AddInParameter(dbCommand, "Subrogation_Waiver", DbType.String, subrogation_Waiver);
        //    db.AddInParameter(dbCommand, "Perils_Insured_Form", DbType.String, perils_Insured_Form);
        //    db.AddInParameter(dbCommand, "Property_On_Acord", DbType.String, property_On_Acord);
        //    db.AddInParameter(dbCommand, "Replacement_Cost", DbType.String, replacement_Cost);
        //    db.AddInParameter(dbCommand, "Insured_Perils", DbType.String, insured_Perils);
        //    db.AddInParameter(dbCommand, "Insured_Name_Same", DbType.String, insured_Name_Same);
        //    db.AddInParameter(dbCommand, "Additional_Insured_Not_Provided", DbType.String, additional_Insured_Not_Provided);
        //    db.AddInParameter(dbCommand, "LeveL_1_Text", DbType.String, leveL_1_Text);
        //    db.AddInParameter(dbCommand, "LeveL_2_Text", DbType.String, leveL_2_Text);
        //    db.AddInParameter(dbCommand, "LeveL_3_Text", DbType.String, leveL_3_Text);
        //    db.AddInParameter(dbCommand, "LeveL_4_Text", DbType.String, leveL_4_Text);
        //    db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
        //    db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        /// <summary>
        /// Deletes a record from the COI_Letter_History table by a composite primary key.
        /// <summary>
        public static void Delete(decimal pK_COI_Letter_History)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryDelete");

            db.AddInParameter(dbCommand, "PK_COI_Letter_History", DbType.Decimal, pK_COI_Letter_History);

            db.ExecuteNonQuery(dbCommand);
        }

        ///// <summary>
        ///// Deletes a record from the COI_Letter_History table by a foreign key.
        ///// <summary>
        //public static void DeleteByFK_COI_Coverage_Status_General(decimal fK_COI_Coverage_Status_General)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryDeleteByFK_COI_Coverage_Status_General");

        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_General", DbType.Decimal, fK_COI_Coverage_Status_General);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        ///// <summary>
        ///// Deletes a record from the COI_Letter_History table by a foreign key.
        ///// <summary>
        //public static void DeleteByFK_COI_Noncompliance_Level(decimal fK_COI_Noncompliance_Level)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryDeleteByFK_COI_Noncompliance_Level");

        //    db.AddInParameter(dbCommand, "FK_COI_Noncompliance_Level", DbType.Decimal, fK_COI_Noncompliance_Level);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        ///// <summary>
        ///// Deletes a record from the COI_Letter_History table by a foreign key.
        ///// <summary>
        //public static void DeleteByFK_COI_Coverage_Status_Property(decimal fK_COI_Coverage_Status_Property)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryDeleteByFK_COI_Coverage_Status_Property");

        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Property", DbType.Decimal, fK_COI_Coverage_Status_Property);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        /// <summary>
        /// Deletes a record from the COI_Letter_History table by a foreign key.
        /// <summary>
        public static void DeleteByFK_COIs(decimal fK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryDeleteByFK_COIs");

            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

            db.ExecuteNonQuery(dbCommand);
        }

        ///// <summary>
        ///// Deletes a record from the COI_Letter_History table by a foreign key.
        ///// <summary>
        //public static void DeleteByFK_COI_Coverage_Status_Excess(decimal fK_COI_Coverage_Status_Excess)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryDeleteByFK_COI_Coverage_Status_Excess");

        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Excess", DbType.Decimal, fK_COI_Coverage_Status_Excess);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        ///// <summary>
        ///// Deletes a record from the COI_Letter_History table by a foreign key.
        ///// <summary>
        //public static void DeleteByFK_COI_Coverage_Status_WC(decimal fK_COI_Coverage_Status_WC)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryDeleteByFK_COI_Coverage_Status_WC");

        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_WC", DbType.Decimal, fK_COI_Coverage_Status_WC);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        ///// <summary>
        ///// Deletes a record from the COI_Letter_History table by a foreign key.
        ///// <summary>
        //public static void DeleteByFK_COI_Coverage_Status_Automobile(decimal fK_COI_Coverage_Status_Automobile)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistoryDeleteByFK_COI_Coverage_Status_Automobile");

        //    db.AddInParameter(dbCommand, "FK_COI_Coverage_Status_Automobile", DbType.Decimal, fK_COI_Coverage_Status_Automobile);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        /// <summary>
        /// Returns all records by page number and page size that matches the search crieteria 
        /// </summary>
        /// <param name="strInsured_Name"></param>
        /// <param name="strIssue_Date_From"></param>
        /// <param name="strIssue_Date_To"></param>
        /// <param name="Date_Letter_Sent_From"></param>
        /// <param name="Date_Letter_Sent_To"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns>DataSet</returns>
        public static DataSet SearchByPaging(string strInsured_Name, string strIssue_Date_From, string strIssue_Date_To, string Date_Letter_Sent_From, string Date_Letter_Sent_To, int intPageNo, int intPageSize, string strOrderBy, string strOrder, int fk_coi_signature)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Letter_HistorySearch");

            db.AddInParameter(dbCommand, "Insured_Name", DbType.String, strInsured_Name);
            db.AddInParameter(dbCommand, "Issue_Date_From", DbType.String, strIssue_Date_From);
            db.AddInParameter(dbCommand, "Issue_Date_To", DbType.String, strIssue_Date_To);
            db.AddInParameter(dbCommand, "Date_Letter_Sent_From", DbType.String, Date_Letter_Sent_From);
            db.AddInParameter(dbCommand, "Date_Letter_Sent_To", DbType.String, Date_Letter_Sent_To);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "FK_COI_Signature", DbType.Int32, fk_coi_signature);
            
            return db.ExecuteDataSet(dbCommand);
        }

        public void Insert()
        {
            Insert(_FK_COIs, _Date_Letter_Sent, _Sent_By_EMail, _FK_COI_Noncompliance_Level, _FK_COI_Coverage_Status_General
                , _FK_COI_Coverage_Status_Automobile, _FK_COI_Coverage_Status_Excess, _FK_COI_Coverage_Status_WC
                , _FK_COI_Coverage_Status_Property, _FK_COI_Coverage_Status_Prfessional, _Signed_Certificate_Received, _Primary_Provided, _Cancellation_Notice
                , _All_Locations, _AM_Best, _Ordinance_Law, _Subrogation_Waiver, _Perils_Insured_Form, _Property_On_Acord
                , _Replacement_Cost, _Insured_Perils, _Insured_Name_Same, _Additional_Insured_Not_Provided, _LeveL_1_Text
                , _LeveL_2_Text, _LeveL_3_Text, _LeveL_4_Text, _Update_Date, _Updated_By,_Letter,_Envelopes);
        }


        
        #endregion
    }
}
