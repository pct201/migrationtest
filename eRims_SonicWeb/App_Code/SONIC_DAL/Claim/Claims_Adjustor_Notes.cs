using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for Claims_Adjustor_Notes
    /// </summary>
    public class Claims_Adjustor_Notes
    {

        #region Fields

        private Int64 _PK_Adjustor_Notes_RO_ID;
        private string _Data_Source;
        private string _Source_Unique_Claim_Number;
        private string _Claimant_Name;
        private DateTime _Accident_Date;
        private string _Claimant_SSN;
        private DateTime _Data_Entry_Date;
        private string _Activity_Type;
        private string _Initials;
        private DateTime _Data_Received_Date;
        private string _Note_Text;
        private string _MultiNote_Indicator;

        #endregion

        #region Properties
        /// <summary> /// Gets or sets the PK_Adjustor_Notes_RO_ID value./// </summary>public Int64 PK_Adjustor_Notes_RO_ID{ get { return _PK_Adjustor_Notes_RO_ID; } set { _PK_Adjustor_Notes_RO_ID = value; }}
        /// <summary> /// Gets or sets the Data_Source value./// </summary>public string Data_Source{ get { return _Data_Source; } set { _Data_Source = value; }}
        /// <summary> /// Gets or sets the Source_Unique_Claim_Number value./// </summary>public string Source_Unique_Claim_Number{ get { return _Source_Unique_Claim_Number; } set { _Source_Unique_Claim_Number = value; }}
        /// <summary> /// Gets or sets the Claimant_Name value./// </summary>public string Claimant_Name{ get { return _Claimant_Name; } set { _Claimant_Name = value; }}
        /// <summary> /// Gets or sets the Accident_Date value./// </summary>public DateTime Accident_Date{ get { return _Accident_Date; } set { _Accident_Date = value; }}
        /// <summary> /// Gets or sets the Claimant_SSN value./// </summary>public string Claimant_SSN{ get { return _Claimant_SSN; } set { _Claimant_SSN = value; }}
        /// <summary> /// Gets or sets the Data_Entry_Date value./// </summary>public DateTime Data_Entry_Date{ get { return _Data_Entry_Date; } set { _Data_Entry_Date = value; }}
        /// <summary> /// Gets or sets the Activity_Type value./// </summary>public string Activity_Type{ get { return _Activity_Type; } set { _Activity_Type = value; }}
        /// <summary> /// Gets or sets the Initials value./// </summary>public string Initials{ get { return _Initials; } set { _Initials = value; }}
        /// <summary> /// Gets or sets the Data_Received_Date value./// </summary>public DateTime Data_Received_Date{ get { return _Data_Received_Date; } set { _Data_Received_Date = value; }}
        /// <summary> /// Gets or sets the Note_Text value./// </summary>public string Note_Text{ get { return _Note_Text; } set { _Note_Text = value; }}
        /// <summary> /// Gets or sets the MultiNote_Indicator value./// </summary>public string MultiNote_Indicator{ get { return _MultiNote_Indicator; } set { _MultiNote_Indicator = value; }}
        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Claims_Adjustor_Notes class. with the default value.
        /// </summary>
        public Claims_Adjustor_Notes()
        {
            this._PK_Adjustor_Notes_RO_ID = 0;
            this._Data_Source = "";
            this._Source_Unique_Claim_Number = "";
            this._Claimant_Name = "";
            this._Accident_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Claimant_SSN = "";
            this._Data_Entry_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Activity_Type = "";
            this._Initials = "";
            this._Data_Received_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Note_Text = "";
            this._MultiNote_Indicator = "";
        }

        /// <summary> 
        /// Initializes a new instance of the Claims_Adjustor_Notes class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Claims_Adjustor_Notes(Int64 PK)
        {
            DataTable dtClaims_Adjustor_Notes = SelectByPK(PK.ToString()).Tables[0];
            if (dtClaims_Adjustor_Notes.Rows.Count > 0)
            {
                DataRow drClaims_Adjustor_Notes = dtClaims_Adjustor_Notes.Rows[0];
                this._PK_Adjustor_Notes_RO_ID = drClaims_Adjustor_Notes["PK_Adjustor_Notes_RO_ID"] != DBNull.Value ? Convert.ToInt64(drClaims_Adjustor_Notes["PK_Adjustor_Notes_RO_ID"]) : 0;
                this._Data_Source = Convert.ToString(drClaims_Adjustor_Notes["Data_Source"]);
                this._Source_Unique_Claim_Number = Convert.ToString(drClaims_Adjustor_Notes["Source_Unique_Claim_Number"]);
                this._Claimant_Name = Convert.ToString(drClaims_Adjustor_Notes["Claimant_Name"]);
                this._Accident_Date = drClaims_Adjustor_Notes["Accident_Date"] != DBNull.Value ? Convert.ToDateTime(drClaims_Adjustor_Notes["Accident_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claimant_SSN = Convert.ToString(drClaims_Adjustor_Notes["Claimant_SSN"]);
                this._Data_Entry_Date = drClaims_Adjustor_Notes["Data_Entry_Date"] != DBNull.Value ? Convert.ToDateTime(drClaims_Adjustor_Notes["Data_Entry_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Activity_Type = Convert.ToString(drClaims_Adjustor_Notes["Activity_Type"]);
                this._Initials = Convert.ToString(drClaims_Adjustor_Notes["Initials"]);
                this._Data_Received_Date = drClaims_Adjustor_Notes["Data_Received_Date"] != DBNull.Value ? Convert.ToDateTime(drClaims_Adjustor_Notes["Data_Received_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Note_Text = Convert.ToString(drClaims_Adjustor_Notes["Note_Text"]);
                this._MultiNote_Indicator = Convert.ToString(drClaims_Adjustor_Notes["MultiNote_Indicator"]);
            }
            else
            {
                this._PK_Adjustor_Notes_RO_ID = 0;
                this._Data_Source = "";
                this._Source_Unique_Claim_Number = "";
                this._Claimant_Name = "";
                this._Accident_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claimant_SSN = "";
                this._Data_Entry_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Activity_Type = "";
                this._Initials = "";
                this._Data_Received_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Note_Text = "";
                this._MultiNote_Indicator = "";
            }
        }
        #endregion

        public static DataSet SelectByPK(string pK_Adjustor_Notes_RO_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claims_Adjustor_NotesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Adjustor_Notes_RO_ID", DbType.String, pK_Adjustor_Notes_RO_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectBySourceUniqueClaimNumber(String source_Unique_Claim_Number, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claims_Adjustor_NotesSelectBySource_Unique_Claim_Number");

            db.AddInParameter(dbCommand, "Source_Unique_Claim_Number", DbType.String, source_Unique_Claim_Number);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);
            dbCommand.CommandTimeout = 10000000;
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectBySourceUniqueClaimNumber(String source_Unique_Claim_Number, int intPageNo, int intPageSize, string strOrder, bool isShowAPEVNotesOnly, string strClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claims_Adjustor_NotesSelectBySource_Unique_Claim_Number");

            db.AddInParameter(dbCommand, "Source_Unique_Claim_Number", DbType.String, source_Unique_Claim_Number);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);
            db.AddInParameter(dbCommand, "DateOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "isShowAPEVNotesOnly", DbType.Boolean, isShowAPEVNotesOnly);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, strClaimType);

            dbCommand.CommandTimeout = 10000000;
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectBySourceUniqueClaimNumberAndDate(String source_Unique_Claim_Number,String activityCode)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claims_Adjustor_NotesSelectByClaim_NumberAndActivity");

            db.AddInParameter(dbCommand, "Source_Unique_Claim_Number", DbType.String, source_Unique_Claim_Number);
            db.AddInParameter(dbCommand, "Activity_Type", DbType.String, activityCode);
         
            return db.ExecuteDataSet(dbCommand);
        }
    }
}