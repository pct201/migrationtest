using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for ClaimsTransaction
    /// </summary>
    public class Claims_Transaction
    {
        #region Fields
        private Int64 _PK_Claims_Transactions_ID;
        private string _Data_Origin;
        private string _Origin_Claim_Number;
        private string _Origin_Key_Claim_Number;
        private string _Claimant_Sequence_Number;
        private string _Policy_Number;
        private string _Carrier_policy_number;
        private DateTime _Transaction_Entry_date;
        private decimal _Transaction_Amount;
        private int _Transaction_Sequence_Number;
        private string _Claim_Status;
        private string _Entry_Code_Modifier;
        private string _Entry_Code;
        private string _Nature_of_Benefit_Code;
        private string _Nature_of_Payment_Statement;
        private string _Transaction_Nature_of_Benefit;
        private string _Check_Number;
        private DateTime _Check_Issue_Date;
        private string _Payee_Name1;
        private string _Payee_Name2;
        private string _Payee_Name3;
        private string _Payee_Street_Address;
        private string _Payee_City;
        private string _Payee_State;
        private string _Payee_Zip;
        private string _Payee_SSN_FEIN;
        private int _Payee_Tax_Number;
        private string _SRS_Recovery_Office_Code;
        private string _SRS_Draft_Issue_Office_Code;
        private string _Recovery_Sequence_Number;
        #endregion

        #region Properties
        /// <summary> /// Gets or sets the PK_Claims_Transactions_ID value./// </summary>public Int64 PK_Claims_Transactions_ID{ get { return _PK_Claims_Transactions_ID; } set { _PK_Claims_Transactions_ID = value; }}
        /// <summary> /// Gets or sets the Data_Origin value./// </summary>public string Data_Origin{ get { return _Data_Origin; } set { _Data_Origin = value; }}
        /// <summary> /// Gets or sets the Origin_Claim_Number value./// </summary>public string Origin_Claim_Number{ get { return _Origin_Claim_Number; } set { _Origin_Claim_Number = value; }}
        /// <summary> /// Gets or sets the Origin_Key_Claim_Number value./// </summary>public string Origin_Key_Claim_Number{ get { return _Origin_Key_Claim_Number; } set { _Origin_Key_Claim_Number = value; }}
        /// <summary> /// Gets or sets the Claimant_Sequence_Number value./// </summary>public string Claimant_Sequence_Number{ get { return _Claimant_Sequence_Number; } set { _Claimant_Sequence_Number = value; }}
        /// <summary> /// Gets or sets the Policy_Number value./// </summary>public string Policy_Number{ get { return _Policy_Number; } set { _Policy_Number = value; }}
        /// <summary> /// Gets or sets the Carrier_policy_number value./// </summary>public string Carrier_policy_number{ get { return _Carrier_policy_number; } set { _Carrier_policy_number = value; }}
        /// <summary> /// Gets or sets the Transaction_Entry_date value./// </summary>public DateTime Transaction_Entry_date{ get { return _Transaction_Entry_date; } set { _Transaction_Entry_date = value; }}
        /// <summary> /// Gets or sets the Transaction_Amount value./// </summary>public decimal Transaction_Amount{ get { return _Transaction_Amount; } set { _Transaction_Amount = value; }}
        /// <summary> /// Gets or sets the Transaction_Sequence_Number value./// </summary>public int Transaction_Sequence_Number{ get { return _Transaction_Sequence_Number; } set { _Transaction_Sequence_Number = value; }}
        /// <summary> /// Gets or sets the Claim_Status value./// </summary>public string Claim_Status{ get { return _Claim_Status; } set { _Claim_Status = value; }}
        /// <summary> /// Gets or sets the Entry_Code_Modifier value./// </summary>public string Entry_Code_Modifier{ get { return _Entry_Code_Modifier; } set { _Entry_Code_Modifier = value; }}
        /// <summary> /// Gets or sets the Entry_Code value./// </summary>public string Entry_Code{ get { return _Entry_Code; } set { _Entry_Code = value; }}
        /// <summary> /// Gets or sets the Nature_of_Benefit_Code value./// </summary>public string Nature_of_Benefit_Code{ get { return _Nature_of_Benefit_Code; } set { _Nature_of_Benefit_Code = value; }}
        /// <summary> /// Gets or sets the Nature_of_Payment_Statement value./// </summary>public string Nature_of_Payment_Statement{ get { return _Nature_of_Payment_Statement; } set { _Nature_of_Payment_Statement = value; }}
        /// <summary> /// Gets or sets the Transaction_Nature_of_Benefit value./// </summary>public string Transaction_Nature_of_Benefit{ get { return _Transaction_Nature_of_Benefit; } set { _Transaction_Nature_of_Benefit = value; }}
        /// <summary> /// Gets or sets the Check_Number value./// </summary>public string Check_Number{ get { return _Check_Number; } set { _Check_Number = value; }}
        /// <summary> /// Gets or sets the Check_Issue_Date value./// </summary>public DateTime Check_Issue_Date{ get { return _Check_Issue_Date; } set { _Check_Issue_Date = value; }}
        /// <summary> /// Gets or sets the Payee_Name1 value./// </summary>public string Payee_Name1{ get { return _Payee_Name1; } set { _Payee_Name1 = value; }}
        /// <summary> /// Gets or sets the Payee_Name2 value./// </summary>public string Payee_Name2{ get { return _Payee_Name2; } set { _Payee_Name2 = value; }}
        /// <summary> /// Gets or sets the Payee_Name3 value./// </summary>public string Payee_Name3{ get { return _Payee_Name3; } set { _Payee_Name3 = value; }}
        /// <summary> /// Gets or sets the Payee_Street_Address value./// </summary>public string Payee_Street_Address{ get { return _Payee_Street_Address; } set { _Payee_Street_Address = value; }}
        /// <summary> /// Gets or sets the Payee_City value./// </summary>public string Payee_City{ get { return _Payee_City; } set { _Payee_City = value; }}
        /// <summary> /// Gets or sets the Payee_State value./// </summary>public string Payee_State{ get { return _Payee_State; } set { _Payee_State = value; }}
        /// <summary> /// Gets or sets the Payee_Zip value./// </summary>public string Payee_Zip{ get { return _Payee_Zip; } set { _Payee_Zip = value; }}
        /// <summary> /// Gets or sets the Payee_SSN_FEIN value./// </summary>public string Payee_SSN_FEIN{ get { return _Payee_SSN_FEIN; } set { _Payee_SSN_FEIN = value; }}
        /// <summary> /// Gets or sets the Payee_Tax_Number value./// </summary>public int Payee_Tax_Number{ get { return _Payee_Tax_Number; } set { _Payee_Tax_Number = value; }}
        /// <summary> /// Gets or sets the SRS_Recovery_Office_Code value./// </summary>public string SRS_Recovery_Office_Code{ get { return _SRS_Recovery_Office_Code; } set { _SRS_Recovery_Office_Code = value; }}
        /// <summary> /// Gets or sets the SRS_Draft_Issue_Office_Code value./// </summary>public string SRS_Draft_Issue_Office_Code{ get { return _SRS_Draft_Issue_Office_Code; } set { _SRS_Draft_Issue_Office_Code = value; }}
        /// <summary> /// Gets or sets the Recovery_Sequence_Number value./// </summary>public string Recovery_Sequence_Number{ get { return _Recovery_Sequence_Number; } set { _Recovery_Sequence_Number = value; }}
        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Claims_Transactions class. with the default value.
        /// </summary>
        public Claims_Transaction()
        {
            this._PK_Claims_Transactions_ID = 0;
            this._Data_Origin = "";
            this._Origin_Claim_Number = "";
            this._Origin_Key_Claim_Number = "";
            this._Claimant_Sequence_Number = "";
            this._Policy_Number = "";
            this._Carrier_policy_number = "";
            this._Transaction_Entry_date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Transaction_Amount = -1;
            this._Transaction_Sequence_Number = -1;
            this._Claim_Status = "";
            this._Entry_Code_Modifier = "";
            this._Entry_Code = "";
            this._Nature_of_Benefit_Code = "";
            this._Nature_of_Payment_Statement = "";
            this._Transaction_Nature_of_Benefit = "";
            this._Check_Number = "";
            this._Check_Issue_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Payee_Name1 = "";
            this._Payee_Name2 = "";
            this._Payee_Name3 = "";
            this._Payee_Street_Address = "";
            this._Payee_City = "";
            this._Payee_State = "";
            this._Payee_Zip = "";
            this._Payee_SSN_FEIN = "";
            this._Payee_Tax_Number = -1;
            this._SRS_Recovery_Office_Code = "";
            this._SRS_Draft_Issue_Office_Code = "";
            this._Recovery_Sequence_Number = "";
        }

        /// <summary> 
        /// Initializes a new instance of the Claims_Transactions class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Claims_Transaction(Int64 PK)
        {
            DataTable dtClaims_Transactions = SelectByPK(PK).Tables[0];
            if (dtClaims_Transactions.Rows.Count > 0)
            {
                DataRow drClaims_Transactions = dtClaims_Transactions.Rows[0];
                this._PK_Claims_Transactions_ID = drClaims_Transactions["PK_Claims_Transactions_ID"] != DBNull.Value ? Convert.ToInt64(drClaims_Transactions["PK_Claims_Transactions_ID"]) : 0;
                this._Data_Origin = Convert.ToString(drClaims_Transactions["Data_Origin"]);
                this._Origin_Claim_Number = Convert.ToString(drClaims_Transactions["Origin_Claim_Number"]);
                this._Origin_Key_Claim_Number = Convert.ToString(drClaims_Transactions["Origin_Key_Claim_Number"]);
                this._Claimant_Sequence_Number = Convert.ToString(drClaims_Transactions["Claimant_Sequence_Number"]);
                this._Policy_Number = Convert.ToString(drClaims_Transactions["Policy_Number"]);
                this._Carrier_policy_number = Convert.ToString(drClaims_Transactions["Carrier_policy_number"]);
                this._Transaction_Entry_date = drClaims_Transactions["Transaction_Entry_date"] != DBNull.Value ? Convert.ToDateTime(drClaims_Transactions["Transaction_Entry_date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Transaction_Amount = drClaims_Transactions["Transaction_Amount"] != DBNull.Value ? Convert.ToDecimal(drClaims_Transactions["Transaction_Amount"]) : 0;
                this._Transaction_Sequence_Number = drClaims_Transactions["Transaction_Sequence_Number"] != DBNull.Value ? Convert.ToInt32(drClaims_Transactions["Transaction_Sequence_Number"]) : 0;
                this._Claim_Status = Convert.ToString(drClaims_Transactions["Claim_Status"]);
                this._Entry_Code_Modifier = Convert.ToString(drClaims_Transactions["Entry_Code_Modifier"]);
                this._Entry_Code = Convert.ToString(drClaims_Transactions["Entry_Code"]);
                this._Nature_of_Benefit_Code = Convert.ToString(drClaims_Transactions["Nature_of_Benefit_Code"]);
                this._Nature_of_Payment_Statement = Convert.ToString(drClaims_Transactions["Nature_of_Payment_Statement"]);
                this._Transaction_Nature_of_Benefit = Convert.ToString(drClaims_Transactions["Transaction_Nature_of_Benefit"]);
                this._Check_Number = Convert.ToString(drClaims_Transactions["Check_Number"]);
                this._Check_Issue_Date = drClaims_Transactions["Check_Issue_Date"] != DBNull.Value ? Convert.ToDateTime(drClaims_Transactions["Check_Issue_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Payee_Name1 = Convert.ToString(drClaims_Transactions["Payee_Name1"]);
                this._Payee_Name2 = Convert.ToString(drClaims_Transactions["Payee_Name2"]);
                this._Payee_Name3 = Convert.ToString(drClaims_Transactions["Payee_Name3"]);
                this._Payee_Street_Address = Convert.ToString(drClaims_Transactions["Payee_Street_Address"]);
                this._Payee_City = Convert.ToString(drClaims_Transactions["Payee_City"]);
                this._Payee_State = Convert.ToString(drClaims_Transactions["Payee_State"]);
                this._Payee_Zip = Convert.ToString(drClaims_Transactions["Payee_Zip"]);
                this._Payee_SSN_FEIN = Convert.ToString(drClaims_Transactions["Payee_SSN_FEIN"]);
                this._Payee_Tax_Number = drClaims_Transactions["Payee_Tax_Number"] != DBNull.Value ? Convert.ToInt32(drClaims_Transactions["Payee_Tax_Number"]) : 0;
                this._SRS_Recovery_Office_Code = Convert.ToString(drClaims_Transactions["SRS_Recovery_Office_Code"]);
                this._SRS_Draft_Issue_Office_Code = Convert.ToString(drClaims_Transactions["SRS_Draft_Issue_Office_Code"]);
                this._Recovery_Sequence_Number = Convert.ToString(drClaims_Transactions["Recovery_Sequence_Number"]);
            }
            else
            {
                this._PK_Claims_Transactions_ID = 0;
                this._Data_Origin = "";
                this._Origin_Claim_Number = "";
                this._Origin_Key_Claim_Number = "";
                this._Claimant_Sequence_Number = "";
                this._Policy_Number = "";
                this._Carrier_policy_number = "";
                this._Transaction_Entry_date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Transaction_Amount = -1;
                this._Transaction_Sequence_Number = -1;
                this._Claim_Status = "";
                this._Entry_Code_Modifier = "";
                this._Entry_Code = "";
                this._Nature_of_Benefit_Code = "";
                this._Nature_of_Payment_Statement = "";
                this._Transaction_Nature_of_Benefit = "";
                this._Check_Number = "";
                this._Check_Issue_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Payee_Name1 = "";
                this._Payee_Name2 = "";
                this._Payee_Name3 = "";
                this._Payee_Street_Address = "";
                this._Payee_City = "";
                this._Payee_State = "";
                this._Payee_Zip = "";
                this._Payee_SSN_FEIN = "";
                this._Payee_Tax_Number = -1;
                this._SRS_Recovery_Office_Code = "";
                this._SRS_Draft_Issue_Office_Code = "";
                this._Recovery_Sequence_Number = "";
            }
        }

        #endregion

        public static DataSet SelectByPK(Int64 pK_Claims_Transactions_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claims_TransactionsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Claims_Transactions_ID", DbType.Int64, pK_Claims_Transactions_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByPKIDs(string PKIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claims_TransactionsSelectByPKIDs");

            db.AddInParameter(dbCommand, "PKIDs", DbType.String, PKIDs);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByOriginClaimNumber(String origin_Claim_Number, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claims_TransactionsSelectByOriginClaimNumber");

            db.AddInParameter(dbCommand, "Origin_Claim_Number", DbType.String, origin_Claim_Number);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
