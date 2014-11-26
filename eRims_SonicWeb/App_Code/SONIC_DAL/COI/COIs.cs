using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for COIs table.
    /// </summary>
    public sealed class COIs
    {
        #region Fields


        private decimal _PK_COIs;
        private DateTime _Issue_Date;
        private decimal _FK_COI_Insureds;
        private decimal _FK_COI_Risk_Profile;
        private decimal _Aggregate_Minimum;
        private decimal _Umbrella_Minimum;
        private string _Profle_Notes;
        private string _General_Required;
        private string _Automobile_Required;
        private string _Excess_Required;
        private string _WC_Required;
        private string _Property_Required;
        private string _Professional_Required;
        private string _Liquor_Required;
        private string _Signed_Certificate_Received;
        private string _Primary_Provided;
        private decimal _Cancellation_Notice;
        private string _All_Locations;
        private string _Insured_Name_Same;
        private string _Replacement_Cost;
        private string _Endorsement_1;
        private string _Endorsement_2;
        private string _COI_Active;
        private decimal _FK_COI_Signature;
        private string _Send_By_Email;
        private string _LeveL_1_Text;
        private string _LeveL_2_Text;
        private string _LeveL_3_Text;
        private string _LeveL_4_Text;
        private DateTime _Update_Date;
        private string _Updated_By;
        private string _Insured_Compliant;
        private string _Compliance_01;
        private string _Compliance_02;
        private string _Compliance_03;
        private string _Compliance_04;
        private string _Compliance_05;
        private string _Compliance_06;
        private string _Compliance_07;
        private string _Compliance_08;
        private string _Compliance_09;
        private string _Compliance_10;
        private decimal _FK_LU_Location_ID;
        private decimal? _Building_TIV;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_COIs value.
        /// </summary>
        public decimal PK_COIs
        {
            get { return _PK_COIs; }
            set { _PK_COIs = value; }
        }


        /// <summary> 
        /// Gets or sets the Issue_Date value.
        /// </summary>
        public DateTime Issue_Date
        {
            get { return _Issue_Date; }
            set { _Issue_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Insureds value.
        /// </summary>
        public decimal FK_COI_Insureds
        {
            get { return _FK_COI_Insureds; }
            set { _FK_COI_Insureds = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Risk_Profile value.
        /// </summary>
        public decimal FK_COI_Risk_Profile
        {
            get { return _FK_COI_Risk_Profile; }
            set { _FK_COI_Risk_Profile = value; }
        }


        /// <summary> 
        /// Gets or sets the Aggregate_Minimum value.
        /// </summary>
        public decimal Aggregate_Minimum
        {
            get { return _Aggregate_Minimum; }
            set { _Aggregate_Minimum = value; }
        }


        /// <summary> 
        /// Gets or sets the Umbrella_Minimum value.
        /// </summary>
        public decimal Umbrella_Minimum
        {
            get { return _Umbrella_Minimum; }
            set { _Umbrella_Minimum = value; }
        }


        /// <summary> 
        /// Gets or sets the Profle_Notes value.
        /// </summary>
        public string Profle_Notes
        {
            get { return _Profle_Notes; }
            set { _Profle_Notes = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Required value.
        /// </summary>
        public string General_Required
        {
            get { return _General_Required; }
            set { _General_Required = value; }
        }


        /// <summary> 
        /// Gets or sets the Automobile_Required value.
        /// </summary>
        public string Automobile_Required
        {
            get { return _Automobile_Required; }
            set { _Automobile_Required = value; }
        }


        /// <summary> 
        /// Gets or sets the Excess_Required value.
        /// </summary>
        public string Excess_Required
        {
            get { return _Excess_Required; }
            set { _Excess_Required = value; }
        }


        /// <summary> 
        /// Gets or sets the WC_Required value.
        /// </summary>
        public string WC_Required
        {
            get { return _WC_Required; }
            set { _WC_Required = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Required value.
        /// </summary>
        public string Property_Required
        {
            get { return _Property_Required; }
            set { _Property_Required = value; }
        }


        /// <summary> 
        /// Gets or sets the Professional_Required value.
        /// </summary>
        public string Professional_Required
        {
            get { return _Professional_Required; }
            set { _Professional_Required = value; }
        }

        public string Liquor_Required
        {
            get { return _Liquor_Required; }
            set { _Liquor_Required = value; }
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
        public decimal Cancellation_Notice
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
        /// Gets or sets the Insured_Name_Same value.
        /// </summary>
        public string Insured_Name_Same
        {
            get { return _Insured_Name_Same; }
            set { _Insured_Name_Same = value; }
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
        /// Gets or sets the Endorsement_1 value.
        /// </summary>
        public string Endorsement_1
        {
            get { return _Endorsement_1; }
            set { _Endorsement_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Endorsement_2 value.
        /// </summary>
        public string Endorsement_2
        {
            get { return _Endorsement_2; }
            set { _Endorsement_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_Active value.
        /// </summary>
        public string COI_Active
        {
            get { return _COI_Active; }
            set { _COI_Active = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Signature value.
        /// </summary>
        public decimal FK_COI_Signature
        {
            get { return _FK_COI_Signature; }
            set { _FK_COI_Signature = value; }
        }


        /// <summary> 
        /// Gets or sets the Send_By_Email value.
        /// </summary>
        public string Send_By_Email
        {
            get { return _Send_By_Email; }
            set { _Send_By_Email = value; }
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

        public string Insured_Compliant
        {
            get { return _Insured_Compliant; }
            set { _Insured_Compliant = value; }
        }

        public decimal? Building_TIV
        {
            get { return _Building_TIV; }
            set { _Building_TIV = value; }
        }

        /// <summary>  /// Gets or sets the Compliance_01 value. /// </summary> 
        public string Compliance_01 { get { return _Compliance_01; } set { _Compliance_01 = value; } }
        /// <summary>  /// Gets or sets the Compliance_02 value. /// </summary> 
        public string Compliance_02 {  get { return _Compliance_02; }  set { _Compliance_02 = value; } }  
        /// <summary>  /// Gets or sets the Compliance_03 value. /// </summary> 
        public string Compliance_03 {  get { return _Compliance_03; }  set { _Compliance_03 = value; } }  
        /// <summary>  /// Gets or sets the Compliance_04 value. /// </summary> 
        public string Compliance_04 {  get { return _Compliance_04; }  set { _Compliance_04 = value; } }  
        /// <summary>  /// Gets or sets the Compliance_05 value. /// </summary> 
        public string Compliance_05 {  get { return _Compliance_05; }  set { _Compliance_05 = value; } }  
        /// <summary>  /// Gets or sets the Compliance_06 value. /// </summary> 
        public string Compliance_06 {  get { return _Compliance_06; }  set { _Compliance_06 = value; } }  
        /// <summary>  /// Gets or sets the Compliance_07 value. /// </summary> 
        public string Compliance_07 {  get { return _Compliance_07; }  set { _Compliance_07 = value; } }  
        /// <summary>  /// Gets or sets the Compliance_08 value. /// </summary> 
        public string Compliance_08 {  get { return _Compliance_08; }  set { _Compliance_08 = value; } }  
        /// <summary>  /// Gets or sets the Compliance_09 value. /// </summary> 
        public string Compliance_09 {  get { return _Compliance_09; }  set { _Compliance_09 = value; } }  
        /// <summary>  /// Gets or sets the Compliance_10 value. /// </summary> 
        public string Compliance_10 {  get { return _Compliance_10; }  set { _Compliance_10 = value; } }

        public decimal FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }
        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COIs class. with the default value.

        /// </summary>
        public COIs()
        {

            this._PK_COIs = -1;
            this._Issue_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._FK_COI_Insureds = -1;
            this._FK_COI_Risk_Profile = -1;
            this._Aggregate_Minimum = -1;
            this._Umbrella_Minimum = -1;
            this._Profle_Notes = "";
            this._General_Required = "";
            this._Automobile_Required = "";
            this._Excess_Required = "";
            this._WC_Required = "";
            this._Property_Required = "";
            this._Professional_Required = "";
            this._Liquor_Required = "";
            this._Signed_Certificate_Received = "";
            this._Primary_Provided = "";
            this._Cancellation_Notice = -1;
            this._All_Locations = "";
            this._Insured_Name_Same = "";
            this._Replacement_Cost = "";
            this._Endorsement_1 = "";
            this._Endorsement_2 = "";
            this._COI_Active = "";
            this._FK_COI_Signature = -1;
            this._Send_By_Email = "";
            this._LeveL_1_Text = "";
            this._LeveL_2_Text = "";
            this._LeveL_3_Text = "";
            this._LeveL_4_Text = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; 
            this._Updated_By = "";
            this._Insured_Compliant = "";
            this._Compliance_01 = "";
            this._Compliance_02 = "";
            this._Compliance_03 = "";
            this._Compliance_04 = "";
            this._Compliance_05 = "";
            this._Compliance_06 = "";
            this._Compliance_07 = "";
            this._Compliance_08 = "";
            this._Compliance_09 = "";
            this._Compliance_10 = "";
            this._FK_LU_Location_ID = -1;
        }



        /// <summary> 

        /// Initializes a new instance of the COIs class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COIs(decimal PK)
        {
            DataTable dtCOIs = Select(PK).Tables[0];

            if (dtCOIs.Rows.Count > 0)
            {

                DataRow drCOIs = dtCOIs.Rows[0];
                this._PK_COIs = drCOIs["PK_COIs"] != DBNull.Value ? Convert.ToDecimal(drCOIs["PK_COIs"]) : 0;
                this._Issue_Date = drCOIs["Issue_Date"] != DBNull.Value ? Convert.ToDateTime(drCOIs["Issue_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._FK_COI_Insureds = drCOIs["FK_COI_Insureds"] != DBNull.Value ? Convert.ToDecimal(drCOIs["FK_COI_Insureds"]) : 0;
                this._FK_COI_Risk_Profile = drCOIs["FK_COI_Risk_Profile"] != DBNull.Value ? Convert.ToDecimal(drCOIs["FK_COI_Risk_Profile"]) : 0;
                this._Aggregate_Minimum = drCOIs["Aggregate_Minimum"] != DBNull.Value ? Convert.ToDecimal(drCOIs["Aggregate_Minimum"]) : 0;
                this._Umbrella_Minimum = drCOIs["Umbrella_Minimum"] != DBNull.Value ? Convert.ToDecimal(drCOIs["Umbrella_Minimum"]) : 0;
                this._Profle_Notes = Convert.ToString(drCOIs["Profle_Notes"]);
                this._General_Required = Convert.ToString(drCOIs["General_Required"]);
                this._Automobile_Required = Convert.ToString(drCOIs["Automobile_Required"]);
                this._Excess_Required = Convert.ToString(drCOIs["Excess_Required"]);
                this._WC_Required = Convert.ToString(drCOIs["WC_Required"]);
                this._Property_Required = Convert.ToString(drCOIs["Property_Required"]);
                this._Professional_Required = Convert.ToString(drCOIs["Professional_Required"]);
                this._Liquor_Required = Convert.ToString(drCOIs["Liquor_Required"]);
                this._Signed_Certificate_Received = Convert.ToString(drCOIs["Signed_Certificate_Received"]);
                this._Primary_Provided = Convert.ToString(drCOIs["Primary_Provided"]);
                this._Cancellation_Notice = drCOIs["Cancellation_Notice"] != DBNull.Value ? Convert.ToDecimal(drCOIs["Cancellation_Notice"]) : 0;
                this._All_Locations = Convert.ToString(drCOIs["All_Locations"]);
                this._Insured_Name_Same = Convert.ToString(drCOIs["Insured_Name_Same"]);
                this._Replacement_Cost = Convert.ToString(drCOIs["Replacement_Cost"]);
                this._Endorsement_1 = Convert.ToString(drCOIs["Endorsement_1"]);
                this._Endorsement_2 = Convert.ToString(drCOIs["Endorsement_2"]);
                this._COI_Active = Convert.ToString(drCOIs["COI_Active"]);
                this._FK_COI_Signature = drCOIs["FK_COI_Signature"] != DBNull.Value ? Convert.ToDecimal(drCOIs["FK_COI_Signature"]) : 0;
                this._Send_By_Email = Convert.ToString(drCOIs["Send_By_Email"]);
                this._LeveL_1_Text = Convert.ToString(drCOIs["LeveL_1_Text"]);
                this._LeveL_2_Text = Convert.ToString(drCOIs["LeveL_2_Text"]);
                this._LeveL_3_Text = Convert.ToString(drCOIs["LeveL_3_Text"]);
                this._LeveL_4_Text = Convert.ToString(drCOIs["LeveL_4_Text"]);
                this._Update_Date = drCOIs["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOIs["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Updated_By = Convert.ToString(drCOIs["Updated_By"]);
                this._Insured_Compliant = Convert.ToString(drCOIs["Insured_Compliant"]);
                this._Compliance_01 = Convert.ToString(drCOIs["Compliance_01"]);
                this._Compliance_02 = Convert.ToString(drCOIs["Compliance_02"]);
                this._Compliance_03 = Convert.ToString(drCOIs["Compliance_03"]);
                this._Compliance_04 = Convert.ToString(drCOIs["Compliance_04"]);
                this._Compliance_05 = Convert.ToString(drCOIs["Compliance_05"]);
                this._Compliance_06 = Convert.ToString(drCOIs["Compliance_06"]);
                this._Compliance_07 = Convert.ToString(drCOIs["Compliance_07"]);
                this._Compliance_08 = Convert.ToString(drCOIs["Compliance_08"]);
                this._Compliance_09 = Convert.ToString(drCOIs["Compliance_09"]);
                this._Compliance_10 = Convert.ToString(drCOIs["Compliance_10"]);
                this._FK_LU_Location_ID = drCOIs["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToDecimal(drCOIs["FK_LU_Location_ID"]) : 0;
                if (drCOIs["Building_TIV"] != DBNull.Value) this._Building_TIV = Convert.ToDecimal(drCOIs["Building_TIV"]); 
            }

            else
            {
                new COIs();
            }

        }



        #endregion


        #region "Methods"

        /// <summary>
        /// Inserts a record into the COIs table.
        /// <summary>
        /// <param name="issue_Date"></param>
        /// <param name="fK_COI_Insureds"></param>
        /// <param name="fK_COI_Risk_Profile"></param>
        /// <param name="aggregate_Minimum"></param>
        /// <param name="umbrella_Minimum"></param>
        /// <param name="profle_Notes"></param>
        /// <param name="general_Required"></param>
        /// <param name="automobile_Required"></param>
        /// <param name="excess_Required"></param>
        /// <param name="wC_Required"></param>
        /// <param name="property_Required"></param>
        /// <param name="professional_Required"></param>
        /// <param name="signed_Certificate_Received"></param>
        /// <param name="primary_Provided"></param>
        /// <param name="cancellation_Notice"></param>
        /// <param name="all_Locations"></param>
        /// <param name="insured_Name_Same"></param>
        /// <param name="replacement_Cost"></param>
        /// <param name="endorsement_1"></param>
        /// <param name="endorsement_2"></param>
        /// <param name="cOI_Active"></param>
        /// <param name="fK_COI_Signature"></param>
        /// <param name="send_By_Email"></param>
        /// <param name="leveL_1_Text"></param>
        /// <param name="leveL_2_Text"></param>
        /// <param name="leveL_3_Text"></param>
        /// <param name="leveL_4_Text"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        /// <returns></returns>
        public static int Insert(DateTime issue_Date, decimal fK_COI_Insureds, decimal fK_COI_Risk_Profile, decimal aggregate_Minimum, decimal umbrella_Minimum, string profle_Notes, string general_Required, string automobile_Required, string excess_Required, string wC_Required, string property_Required, string professional_Required, string liquor_Required, string signed_Certificate_Received, string primary_Provided, decimal cancellation_Notice, string all_Locations, string insured_Name_Same, string replacement_Cost, string endorsement_1, string endorsement_2, string cOI_Active, decimal fK_COI_Signature, string send_By_Email, string leveL_1_Text, string leveL_2_Text, string leveL_3_Text, string leveL_4_Text, DateTime update_Date, string updated_By, string insured_Compliant, string compliance_01, string compliance_02, string compliance_03, string compliance_04, string compliance_05, string compliance_06, string compliance_07, string compliance_08, string compliance_09, string compliance_10, decimal FK_LU_Location_ID, decimal? building_TIV)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsInsert");

            db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
            db.AddInParameter(dbCommand, "FK_COI_Insureds", DbType.Decimal, fK_COI_Insureds);
            db.AddInParameter(dbCommand, "FK_COI_Risk_Profile", DbType.Decimal, fK_COI_Risk_Profile);
            db.AddInParameter(dbCommand, "Aggregate_Minimum", DbType.Decimal, aggregate_Minimum);
            db.AddInParameter(dbCommand, "Umbrella_Minimum", DbType.Decimal, umbrella_Minimum);
            db.AddInParameter(dbCommand, "Profle_Notes", DbType.String, profle_Notes);
            db.AddInParameter(dbCommand, "General_Required", DbType.String, general_Required);
            db.AddInParameter(dbCommand, "Automobile_Required", DbType.String, automobile_Required);
            db.AddInParameter(dbCommand, "Excess_Required", DbType.String, excess_Required);
            db.AddInParameter(dbCommand, "WC_Required", DbType.String, wC_Required);
            db.AddInParameter(dbCommand, "Property_Required", DbType.String, property_Required);
            db.AddInParameter(dbCommand, "Professional_Required", DbType.String, professional_Required);
            db.AddInParameter(dbCommand, "Liquor_Required", DbType.String, liquor_Required);
            db.AddInParameter(dbCommand, "Signed_Certificate_Received", DbType.String, signed_Certificate_Received);
            //db.AddInParameter(dbCommand, "Primary_Provided", DbType.String, primary_Provided);
            db.AddInParameter(dbCommand, "Primary_Provided", DbType.String, "Y");
            db.AddInParameter(dbCommand, "Cancellation_Notice", DbType.Decimal, cancellation_Notice);
            //db.AddInParameter(dbCommand, "All_Locations", DbType.String, all_Locations);
            db.AddInParameter(dbCommand, "All_Locations", DbType.String, "Y");
            //db.AddInParameter(dbCommand, "Insured_Name_Same", DbType.String, insured_Name_Same);
            db.AddInParameter(dbCommand, "Insured_Name_Same", DbType.String, "Y");
            db.AddInParameter(dbCommand, "Replacement_Cost", DbType.String, replacement_Cost);
            db.AddInParameter(dbCommand, "Endorsement_1", DbType.String, endorsement_1);
            db.AddInParameter(dbCommand, "Endorsement_2", DbType.String, endorsement_2);
            db.AddInParameter(dbCommand, "COI_Active", DbType.String, cOI_Active);
            db.AddInParameter(dbCommand, "FK_COI_Signature", DbType.Decimal, fK_COI_Signature);
            db.AddInParameter(dbCommand, "Send_By_Email", DbType.String, send_By_Email);
            db.AddInParameter(dbCommand, "LeveL_1_Text", DbType.String, leveL_1_Text);
            db.AddInParameter(dbCommand, "LeveL_2_Text", DbType.String, leveL_2_Text);
            db.AddInParameter(dbCommand, "LeveL_3_Text", DbType.String, leveL_3_Text);
            db.AddInParameter(dbCommand, "LeveL_4_Text", DbType.String, leveL_4_Text);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            //db.AddInParameter(dbCommand, "Insured_Compliant", DbType.String, insured_Compliant);
            db.AddInParameter(dbCommand, "Insured_Compliant", DbType.String, "Y");
            db.AddInParameter(dbCommand, "Compliance_01", DbType.String, compliance_01);
            db.AddInParameter(dbCommand, "Compliance_02", DbType.String, compliance_02);
            db.AddInParameter(dbCommand, "Compliance_03", DbType.String, compliance_03);
            db.AddInParameter(dbCommand, "Compliance_04", DbType.String, compliance_04);
            db.AddInParameter(dbCommand, "Compliance_05", DbType.String, compliance_05);
            db.AddInParameter(dbCommand, "Compliance_06", DbType.String, compliance_06);
            db.AddInParameter(dbCommand, "Compliance_07", DbType.String, compliance_07);
            db.AddInParameter(dbCommand, "Compliance_08", DbType.String, compliance_08);
            db.AddInParameter(dbCommand, "Compliance_09", DbType.String, compliance_09);
            db.AddInParameter(dbCommand, "Compliance_10", DbType.String, compliance_10);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Building_TIV", DbType.Decimal, building_TIV);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the COIs table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsSelect");

            db.AddInParameter(dbCommand, "PK_COIs", DbType.Decimal, pK_COIs);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the COIs table by a foreign key.
        /// <summary>
        /// <param name="fK_COI_Signature"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_COI_Signature(decimal fK_COI_Signature)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsSelectByFK_COI_Signature");

            db.AddInParameter(dbCommand, "FK_COI_Signature", DbType.Decimal, fK_COI_Signature);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the COIs table by a foreign key.
        /// <summary>
        /// <param name="fK_COI_Risk_Profile"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_COI_Risk_Profile(decimal fK_COI_Risk_Profile)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsSelectByFK_COI_Risk_Profile");

            db.AddInParameter(dbCommand, "FK_COI_Risk_Profile", DbType.Decimal, fK_COI_Risk_Profile);

            return db.ExecuteDataSet(dbCommand);
        }

        

        /// <summary>
        /// Updates a record in the COIs table.
        /// <summary>
        /// <param name="pK_COIs"></param>
        /// <param name="issue_Date"></param>
        /// <param name="fK_COI_Insureds"></param>
        /// <param name="fK_COI_Risk_Profile"></param>
        /// <param name="aggregate_Minimum"></param>
        /// <param name="umbrella_Minimum"></param>
        /// <param name="profle_Notes"></param>
        /// <param name="general_Required"></param>
        /// <param name="automobile_Required"></param>
        /// <param name="excess_Required"></param>
        /// <param name="wC_Required"></param>
        /// <param name="property_Required"></param>
        /// <param name="professional_Required"></param>
        /// <param name="signed_Certificate_Received"></param>
        /// <param name="primary_Provided"></param>
        /// <param name="cancellation_Notice"></param>
        /// <param name="all_Locations"></param>
        /// <param name="insured_Name_Same"></param>
        /// <param name="replacement_Cost"></param>
        /// <param name="endorsement_1"></param>
        /// <param name="endorsement_2"></param>
        /// <param name="cOI_Active"></param>
        /// <param name="fK_COI_Signature"></param>
        /// <param name="send_By_Email"></param>
        /// <param name="leveL_1_Text"></param>
        /// <param name="leveL_2_Text"></param>
        /// <param name="leveL_3_Text"></param>
        /// <param name="leveL_4_Text"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        public static void Update(decimal pK_COIs, DateTime issue_Date, decimal fK_COI_Insureds, decimal fK_COI_Risk_Profile, decimal aggregate_Minimum, decimal umbrella_Minimum, string profle_Notes, string general_Required, string automobile_Required, string excess_Required, string wC_Required, string property_Required, string professional_Required, string liquor_Required, string signed_Certificate_Received, string primary_Provided, decimal cancellation_Notice, string all_Locations, string insured_Name_Same, string replacement_Cost, string endorsement_1, string endorsement_2, string cOI_Active, decimal fK_COI_Signature, string send_By_Email, string leveL_1_Text, string leveL_2_Text, string leveL_3_Text, string leveL_4_Text, DateTime update_Date, string updated_By, string insured_Compliant, string compliance_01, string compliance_02, string compliance_03, string compliance_04, string compliance_05, string compliance_06, string compliance_07, string compliance_08, string compliance_09, string compliance_10, decimal FK_LU_Location_ID, decimal? building_TIV)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsUpdate");

            db.AddInParameter(dbCommand, "PK_COIs", DbType.Decimal, pK_COIs);
            db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
            db.AddInParameter(dbCommand, "FK_COI_Insureds", DbType.Decimal, fK_COI_Insureds);
            db.AddInParameter(dbCommand, "FK_COI_Risk_Profile", DbType.Decimal, fK_COI_Risk_Profile);
            db.AddInParameter(dbCommand, "Aggregate_Minimum", DbType.Decimal, aggregate_Minimum);
            db.AddInParameter(dbCommand, "Umbrella_Minimum", DbType.Decimal, umbrella_Minimum);
            db.AddInParameter(dbCommand, "Profle_Notes", DbType.String, profle_Notes);
            db.AddInParameter(dbCommand, "General_Required", DbType.String, general_Required);
            db.AddInParameter(dbCommand, "Automobile_Required", DbType.String, automobile_Required);
            db.AddInParameter(dbCommand, "Excess_Required", DbType.String, excess_Required);
            db.AddInParameter(dbCommand, "WC_Required", DbType.String, wC_Required);
            db.AddInParameter(dbCommand, "Property_Required", DbType.String, property_Required);
            db.AddInParameter(dbCommand, "Professional_Required", DbType.String, professional_Required);
            db.AddInParameter(dbCommand, "Liquor_Required", DbType.String, liquor_Required);
            db.AddInParameter(dbCommand, "Signed_Certificate_Received", DbType.String, signed_Certificate_Received);
            //db.AddInParameter(dbCommand, "Primary_Provided", DbType.String, primary_Provided);
            db.AddInParameter(dbCommand, "Primary_Provided", DbType.String, "Y");
            db.AddInParameter(dbCommand, "Cancellation_Notice", DbType.Decimal, cancellation_Notice);
            //db.AddInParameter(dbCommand, "All_Locations", DbType.String, all_Locations);
            db.AddInParameter(dbCommand, "All_Locations", DbType.String, "Y");
            //db.AddInParameter(dbCommand, "Insured_Name_Same", DbType.String, insured_Name_Same);
            db.AddInParameter(dbCommand, "Insured_Name_Same", DbType.String, "Y");
            db.AddInParameter(dbCommand, "Replacement_Cost", DbType.String, replacement_Cost);
            db.AddInParameter(dbCommand, "Endorsement_1", DbType.String, endorsement_1);
            db.AddInParameter(dbCommand, "Endorsement_2", DbType.String, endorsement_2);
            db.AddInParameter(dbCommand, "COI_Active", DbType.String, cOI_Active);
            db.AddInParameter(dbCommand, "FK_COI_Signature", DbType.Decimal, fK_COI_Signature);
            db.AddInParameter(dbCommand, "Send_By_Email", DbType.String, send_By_Email);
            db.AddInParameter(dbCommand, "LeveL_1_Text", DbType.String, leveL_1_Text);
            db.AddInParameter(dbCommand, "LeveL_2_Text", DbType.String, leveL_2_Text);
            db.AddInParameter(dbCommand, "LeveL_3_Text", DbType.String, leveL_3_Text);
            db.AddInParameter(dbCommand, "LeveL_4_Text", DbType.String, leveL_4_Text);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            //db.AddInParameter(dbCommand, "Insured_Compliant", DbType.String, insured_Compliant);
            db.AddInParameter(dbCommand, "Insured_Compliant", DbType.String, "Y");
            db.AddInParameter(dbCommand, "Compliance_01", DbType.String, compliance_01);
            db.AddInParameter(dbCommand, "Compliance_02", DbType.String, compliance_02);
            db.AddInParameter(dbCommand, "Compliance_03", DbType.String, compliance_03);
            db.AddInParameter(dbCommand, "Compliance_04", DbType.String, compliance_04);
            db.AddInParameter(dbCommand, "Compliance_05", DbType.String, compliance_05);
            db.AddInParameter(dbCommand, "Compliance_06", DbType.String, compliance_06);
            db.AddInParameter(dbCommand, "Compliance_07", DbType.String, compliance_07);
            db.AddInParameter(dbCommand, "Compliance_08", DbType.String, compliance_08);
            db.AddInParameter(dbCommand, "Compliance_09", DbType.String, compliance_09);
            db.AddInParameter(dbCommand, "Compliance_10", DbType.String, compliance_10);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Building_TIV", DbType.Decimal, building_TIV);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Deletes a record from the COIs table by a composite primary key.
        /// <summary>
        public static void Delete(decimal pK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsDelete");

            db.AddInParameter(dbCommand, "PK_COIs", DbType.Decimal, pK_COIs);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the COIs table by a foreign key.
        /// <summary>
        public static void DeleteByFK_COI_Signature(decimal fK_COI_Signature)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsDeleteByFK_COI_Signature");

            db.AddInParameter(dbCommand, "FK_COI_Signature", DbType.Decimal, fK_COI_Signature);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the COIs table by a foreign key.
        /// <summary>
        public static void DeleteByFK_COI_Risk_Profile(decimal fK_COI_Risk_Profile)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsDeleteByFK_COI_Risk_Profile");

            db.AddInParameter(dbCommand, "FK_COI_Risk_Profile", DbType.Decimal, fK_COI_Risk_Profile);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
            return Insert(_Issue_Date, _FK_COI_Insureds, _FK_COI_Risk_Profile, _Aggregate_Minimum, _Umbrella_Minimum, _Profle_Notes, _General_Required, _Automobile_Required, _Excess_Required, _WC_Required, _Property_Required, _Professional_Required, _Liquor_Required, _Signed_Certificate_Received, _Primary_Provided, _Cancellation_Notice, _All_Locations, _Insured_Name_Same, _Replacement_Cost, _Endorsement_1, _Endorsement_2, _COI_Active, _FK_COI_Signature, _Send_By_Email, _LeveL_1_Text, _LeveL_2_Text, _LeveL_3_Text, _LeveL_4_Text, _Update_Date, _Updated_By, _Insured_Compliant, _Compliance_01, _Compliance_02, _Compliance_03, _Compliance_04, _Compliance_05, _Compliance_06, _Compliance_07, _Compliance_08, _Compliance_09, _Compliance_10, _FK_LU_Location_ID, _Building_TIV);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COIs, _Issue_Date, _FK_COI_Insureds, _FK_COI_Risk_Profile, _Aggregate_Minimum, _Umbrella_Minimum, _Profle_Notes, _General_Required, _Automobile_Required, _Excess_Required, _WC_Required, _Property_Required, _Professional_Required, _Liquor_Required, _Signed_Certificate_Received, _Primary_Provided, _Cancellation_Notice, _All_Locations, _Insured_Name_Same, _Replacement_Cost, _Endorsement_1, _Endorsement_2, _COI_Active, _FK_COI_Signature, _Send_By_Email, _LeveL_1_Text, _LeveL_2_Text, _LeveL_3_Text, _LeveL_4_Text, _Update_Date, _Updated_By, _Insured_Compliant, _Compliance_01, _Compliance_02, _Compliance_03, _Compliance_04, _Compliance_05, _Compliance_06, _Compliance_07, _Compliance_08, _Compliance_09, _Compliance_10, _FK_LU_Location_ID, _Building_TIV);
        }

        /// <summary>
        /// Returns the records by Page number and Page size that matches the search crieteria
        /// </summary>
        /// <param name="Insured_Name"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="strIssue_Date_From"></param>
        /// <param name="strIssue_Date_To"></param>
        /// <param name="General_Policy_Number"></param>
        /// <param name="Automobile_Policy_Number"></param>
        /// <param name="Excess_Policy_Number"></param>
        /// <param name="WC_Policy_Number"></param>
        /// <param name="Property_Policy_Number"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public static DataSet SearchByPaging(string Insured_Name, string Address, string City, int State, string strIssue_Date_From, string strIssue_Date_To, string Location_Number, 
            string General_Policy_Number, string Automobile_Policy_Number, string Excess_Policy_Number, string WC_Policy_Number, string Property_Policy_Number,string strLocationdba, 
            string strLocationCode, int intPageNo, int intPageSize, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsSearch");

            db.AddInParameter(dbCommand, "Insured_Name", DbType.String, Insured_Name);
            db.AddInParameter(dbCommand, "Address", DbType.String, Address);
            db.AddInParameter(dbCommand, "City", DbType.String, City);
            db.AddInParameter(dbCommand, "State", DbType.Int32, State);
            db.AddInParameter(dbCommand, "Issue_Date_From", DbType.String, strIssue_Date_From);
            db.AddInParameter(dbCommand, "Issue_Date_To", DbType.String, strIssue_Date_To);
            db.AddInParameter(dbCommand, "Location_Number", DbType.String, Location_Number);
            db.AddInParameter(dbCommand, "General_Policy_Number", DbType.String, General_Policy_Number);
            db.AddInParameter(dbCommand, "Automobile_Policy_Number", DbType.String, Automobile_Policy_Number);
            db.AddInParameter(dbCommand, "Excess_Policy_Number", DbType.String, Excess_Policy_Number);
            db.AddInParameter(dbCommand, "WC_Policy_Number", DbType.String, WC_Policy_Number);
            db.AddInParameter(dbCommand, "Property_Policy_Number", DbType.String, Property_Policy_Number);
            db.AddInParameter(dbCommand, "Locationdba", DbType.String, strLocationdba);
            db.AddInParameter(dbCommand, "LocationCode", DbType.String, strLocationCode);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }

}
