using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Premises_Loss_RMW table.
	/// </summary>
	public sealed class Premises_Loss_RMW
    {
        #region Fields


        private decimal _PK_Premises_Loss_RMW;
        private decimal _FK_Premises_Loss_Claims;
        private DateTime _Update_Date;
        private string _Updated_By;
        private Nullable<bool> _Claimant_Customer;
        private Nullable<bool> _Claimant_Third_Party;
        private string _Liability_Analysis;
        private Nullable<bool> _Demand;
        private string _Claimant_Counsel_Name;
        private string _Plantiff_Counsel_Name;
        private Nullable<bool> _Property_Damaged;
        private string _Property_Damages_Description;
        private decimal _Damage_Amount;
        private Nullable<bool> _Bodily_injury;
        private string _Injury_Description;
        private string _Medical_Treatment_Description;
        private decimal _Medical_Cost;
        private decimal _Requested_Amount;
        private decimal _Potential_Total_Exposure;
        private Nullable<bool> _Settled;
        private decimal _Settled_Amount;
        private string _GM_Email_To;
        private Nullable<bool> _GM_Decision;
        private DateTime _GM_Last_Email_Date;
        private DateTime _GM_Response_Date;
        private string _CRM_Email_To;
        private Nullable<bool> _CRM_Decision;
        private DateTime _CRM_Last_Email_Date;
        private DateTime _CRM_Response_Date;
        private string _RVP_Email_To;
        private Nullable<bool> _RVP_Decision;
        private DateTime _RVP_Last_Email_Date;
        private DateTime _RVP_Response_Date;
        private string _AGC_Email_To;
        private Nullable<bool> _AGC_Decision;
        private DateTime _AGC_Last_Email_Date;
        private DateTime _AGC_Response_Date;
        private string _DRM_Email_To;
        private Nullable<bool> _DRM_Decision;
        private DateTime _DRM_Last_Email_Date;
        private DateTime _DRM_Response_Date;
        private string _CFO_Email_To;
        private Nullable<bool> _CFO_Decision;
        private DateTime _CFO_Last_Email_Date;
        private DateTime _CFO_Response_Date;
        private string _COO_Email_To;
        private Nullable<bool> _COO_Decision;
        private DateTime _COO_Last_Email_Date;
        private DateTime _COO_Response_Date;
        private string _President_Email_To;
        private Nullable<bool> _President_Decision;
        private DateTime _President_Last_Email_Date;
        private DateTime _President_Response_Date;
        private string _Comments;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Premises_Loss_RMW value.
        /// </summary>
        public decimal PK_Premises_Loss_RMW
        {
            get { return _PK_Premises_Loss_RMW; }
            set { _PK_Premises_Loss_RMW = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Premises_Loss_Claims value.
        /// </summary>
        public decimal FK_Premises_Loss_Claims
        {
            get { return _FK_Premises_Loss_Claims; }
            set { _FK_Premises_Loss_Claims = value; }
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
        /// Gets or sets the Claimant_Customer value.
        /// </summary>
        public Nullable<bool> Claimant_Customer
        {
            get { return _Claimant_Customer; }
            set { _Claimant_Customer = value; }
        }


        /// <summary> 
        /// Gets or sets the Claimant_Third_Party value.
        /// </summary>
        public Nullable<bool> Claimant_Third_Party
        {
            get { return _Claimant_Third_Party; }
            set { _Claimant_Third_Party = value; }
        }


        /// <summary> 
        /// Gets or sets the Liability_Analysis value.
        /// </summary>
        public string Liability_Analysis
        {
            get { return _Liability_Analysis; }
            set { _Liability_Analysis = value; }
        }


        /// <summary> 
        /// Gets or sets the Demand value.
        /// </summary>
        public Nullable<bool> Demand
        {
            get { return _Demand; }
            set { _Demand = value; }
        }


        /// <summary> 
        /// Gets or sets the Claimant_Counsel_Name value.
        /// </summary>
        public string Claimant_Counsel_Name
        {
            get { return _Claimant_Counsel_Name; }
            set { _Claimant_Counsel_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Plantiff_Counsel_Name value.
        /// </summary>
        public string Plantiff_Counsel_Name
        {
            get { return _Plantiff_Counsel_Name; }
            set { _Plantiff_Counsel_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Damaged value.
        /// </summary>
        public Nullable<bool> Property_Damaged
        {
            get { return _Property_Damaged; }
            set { _Property_Damaged = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Damages_Description value.
        /// </summary>
        public string Property_Damages_Description
        {
            get { return _Property_Damages_Description; }
            set { _Property_Damages_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Damage_Amount value.
        /// </summary>
        public decimal Damage_Amount
        {
            get { return _Damage_Amount; }
            set { _Damage_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Bodily_injury value.
        /// </summary>
        public Nullable<bool> Bodily_injury
        {
            get { return _Bodily_injury; }
            set { _Bodily_injury = value; }
        }


        /// <summary> 
        /// Gets or sets the Injury_Description value.
        /// </summary>
        public string Injury_Description
        {
            get { return _Injury_Description; }
            set { _Injury_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Treatment_Description value.
        /// </summary>
        public string Medical_Treatment_Description
        {
            get { return _Medical_Treatment_Description; }
            set { _Medical_Treatment_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Cost value.
        /// </summary>
        public decimal Medical_Cost
        {
            get { return _Medical_Cost; }
            set { _Medical_Cost = value; }
        }


        /// <summary> 
        /// Gets or sets the Requested_Amount value.
        /// </summary>
        public decimal Requested_Amount
        {
            get { return _Requested_Amount; }
            set { _Requested_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Potential_Total_Exposure value.
        /// </summary>
        public decimal Potential_Total_Exposure
        {
            get { return _Potential_Total_Exposure; }
            set { _Potential_Total_Exposure = value; }
        }


        /// <summary> 
        /// Gets or sets the Settled value.
        /// </summary>
        public Nullable<bool> Settled
        {
            get { return _Settled; }
            set { _Settled = value; }
        }


        /// <summary> 
        /// Gets or sets the Settled_Amount value.
        /// </summary>
        public decimal Settled_Amount
        {
            get { return _Settled_Amount; }
            set { _Settled_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the GM_Email_To value.
        /// </summary>
        public string GM_Email_To
        {
            get { return _GM_Email_To; }
            set { _GM_Email_To = value; }
        }


        /// <summary> 
        /// Gets or sets the GM_Decision value.
        /// </summary>
        public Nullable<bool> GM_Decision
        {
            get { return _GM_Decision; }
            set { _GM_Decision = value; }
        }


        /// <summary> 
        /// Gets or sets the GM_Last_Email_Date value.
        /// </summary>
        public DateTime GM_Last_Email_Date
        {
            get { return _GM_Last_Email_Date; }
            set { _GM_Last_Email_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the GM_Response_Date value.
        /// </summary>
        public DateTime GM_Response_Date
        {
            get { return _GM_Response_Date; }
            set { _GM_Response_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the CRM_Email_To value.
        /// </summary>
        public string CRM_Email_To
        {
            get { return _CRM_Email_To; }
            set { _CRM_Email_To = value; }
        }


        /// <summary> 
        /// Gets or sets the CRM_Decision value.
        /// </summary>
        public Nullable<bool> CRM_Decision
        {
            get { return _CRM_Decision; }
            set { _CRM_Decision = value; }
        }


        /// <summary> 
        /// Gets or sets the CRM_Last_Email_Date value.
        /// </summary>
        public DateTime CRM_Last_Email_Date
        {
            get { return _CRM_Last_Email_Date; }
            set { _CRM_Last_Email_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the CRM_Response_Date value.
        /// </summary>
        public DateTime CRM_Response_Date
        {
            get { return _CRM_Response_Date; }
            set { _CRM_Response_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the RVP_Email_To value.
        /// </summary>
        public string RVP_Email_To
        {
            get { return _RVP_Email_To; }
            set { _RVP_Email_To = value; }
        }


        /// <summary> 
        /// Gets or sets the RVP_Decision value.
        /// </summary>
        public Nullable<bool> RVP_Decision
        {
            get { return _RVP_Decision; }
            set { _RVP_Decision = value; }
        }


        /// <summary> 
        /// Gets or sets the RVP_Last_Email_Date value.
        /// </summary>
        public DateTime RVP_Last_Email_Date
        {
            get { return _RVP_Last_Email_Date; }
            set { _RVP_Last_Email_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the RVP_Response_Date value.
        /// </summary>
        public DateTime RVP_Response_Date
        {
            get { return _RVP_Response_Date; }
            set { _RVP_Response_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the AGC_Email_To value.
        /// </summary>
        public string AGC_Email_To
        {
            get { return _AGC_Email_To; }
            set { _AGC_Email_To = value; }
        }


        /// <summary> 
        /// Gets or sets the AGC_Decision value.
        /// </summary>
        public Nullable<bool> AGC_Decision
        {
            get { return _AGC_Decision; }
            set { _AGC_Decision = value; }
        }


        /// <summary> 
        /// Gets or sets the AGC_Last_Email_Date value.
        /// </summary>
        public DateTime AGC_Last_Email_Date
        {
            get { return _AGC_Last_Email_Date; }
            set { _AGC_Last_Email_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the AGC_Response_Date value.
        /// </summary>
        public DateTime AGC_Response_Date
        {
            get { return _AGC_Response_Date; }
            set { _AGC_Response_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the DRM_Email_To value.
        /// </summary>
        public string DRM_Email_To
        {
            get { return _DRM_Email_To; }
            set { _DRM_Email_To = value; }
        }


        /// <summary> 
        /// Gets or sets the DRM_Decision value.
        /// </summary>
        public Nullable<bool> DRM_Decision
        {
            get { return _DRM_Decision; }
            set { _DRM_Decision = value; }
        }


        /// <summary> 
        /// Gets or sets the DRM_Last_Email_Date value.
        /// </summary>
        public DateTime DRM_Last_Email_Date
        {
            get { return _DRM_Last_Email_Date; }
            set { _DRM_Last_Email_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the DRM_Response_Date value.
        /// </summary>
        public DateTime DRM_Response_Date
        {
            get { return _DRM_Response_Date; }
            set { _DRM_Response_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the CFO_Email_To value.
        /// </summary>
        public string CFO_Email_To
        {
            get { return _CFO_Email_To; }
            set { _CFO_Email_To = value; }
        }


        /// <summary> 
        /// Gets or sets the CFO_Decision value.
        /// </summary>
        public Nullable<bool> CFO_Decision
        {
            get { return _CFO_Decision; }
            set { _CFO_Decision = value; }
        }


        /// <summary> 
        /// Gets or sets the CFO_Last_Email_Date value.
        /// </summary>
        public DateTime CFO_Last_Email_Date
        {
            get { return _CFO_Last_Email_Date; }
            set { _CFO_Last_Email_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the CFO_Response_Date value.
        /// </summary>
        public DateTime CFO_Response_Date
        {
            get { return _CFO_Response_Date; }
            set { _CFO_Response_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the COO_Email_To value.
        /// </summary>
        public string COO_Email_To
        {
            get { return _COO_Email_To; }
            set { _COO_Email_To = value; }
        }


        /// <summary> 
        /// Gets or sets the COO_Decision value.
        /// </summary>
        public Nullable<bool> COO_Decision
        {
            get { return _COO_Decision; }
            set { _COO_Decision = value; }
        }


        /// <summary> 
        /// Gets or sets the COO_Last_Email_Date value.
        /// </summary>
        public DateTime COO_Last_Email_Date
        {
            get { return _COO_Last_Email_Date; }
            set { _COO_Last_Email_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the COO_Response_Date value.
        /// </summary>
        public DateTime COO_Response_Date
        {
            get { return _COO_Response_Date; }
            set { _COO_Response_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the President_Email_To value.
        /// </summary>
        public string President_Email_To
        {
            get { return _President_Email_To; }
            set { _President_Email_To = value; }
        }


        /// <summary> 
        /// Gets or sets the President_Decision value.
        /// </summary>
        public Nullable<bool> President_Decision
        {
            get { return _President_Decision; }
            set { _President_Decision = value; }
        }


        /// <summary> 
        /// Gets or sets the President_Last_Email_Date value.
        /// </summary>
        public DateTime President_Last_Email_Date
        {
            get { return _President_Last_Email_Date; }
            set { _President_Last_Email_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the President_Response_Date value.
        /// </summary>
        public DateTime President_Response_Date
        {
            get { return _President_Response_Date; }
            set { _President_Response_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Comments value.
        /// </summary>
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Premises_Loss_RMW class. with the default value.

        /// </summary>
        public Premises_Loss_RMW()
        {

            this._PK_Premises_Loss_RMW = -1;
            this._FK_Premises_Loss_Claims = -1;
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Updated_By = "";
            this._Claimant_Customer = false;
            this._Claimant_Third_Party = false;
            this._Liability_Analysis = "";
            this._Demand = false;
            this._Claimant_Counsel_Name = "";
            this._Plantiff_Counsel_Name = "";
            this._Property_Damaged = false;
            this._Property_Damages_Description = "";
            this._Damage_Amount = -1;
            this._Bodily_injury = false;
            this._Injury_Description = "";
            this._Medical_Treatment_Description = "";
            this._Medical_Cost = -1;
            this._Requested_Amount = -1;
            this._Potential_Total_Exposure = -1;
            this._Settled = false;
            this._Settled_Amount = -1;
            this._GM_Email_To = "";
            this._GM_Decision = false;
            this._GM_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._GM_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._CRM_Email_To = "";
            this._CRM_Decision = false;
            this._CRM_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._CRM_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._RVP_Email_To = "";
            this._RVP_Decision = false;
            this._RVP_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._RVP_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._AGC_Email_To = "";
            this._AGC_Decision = false;
            this._AGC_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._AGC_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._DRM_Email_To = "";
            this._DRM_Decision = false;
            this._DRM_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._DRM_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._CFO_Email_To = "";
            this._CFO_Decision = false;
            this._CFO_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._CFO_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COO_Email_To = "";
            this._COO_Decision = false;
            this._COO_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COO_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._President_Email_To = "";
            this._President_Decision = false;
            this._President_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._President_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Comments = "";

        }



        /// <summary> 
        /// Initializes a new instance of the Premises_Loss_RMW class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Premises_Loss_RMW(decimal PK)
        {

            DataTable dtPremises_Loss_RMW = SelectByPK(PK).Tables[0];

            if (dtPremises_Loss_RMW.Rows.Count > 0)
            {

                DataRow drPremises_Loss_RMW = dtPremises_Loss_RMW.Rows[0];

                this._PK_Premises_Loss_RMW = drPremises_Loss_RMW["PK_Premises_Loss_RMW"] != DBNull.Value ? Convert.ToDecimal(drPremises_Loss_RMW["PK_Premises_Loss_RMW"]) : 0;
                this._FK_Premises_Loss_Claims = drPremises_Loss_RMW["FK_Premises_Loss_Claims"] != DBNull.Value ? Convert.ToDecimal(drPremises_Loss_RMW["FK_Premises_Loss_Claims"]) : 0;
                this._Update_Date = drPremises_Loss_RMW["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = Convert.ToString(drPremises_Loss_RMW["Updated_By"]);
                if(drPremises_Loss_RMW["Claimant_Customer"] != DBNull.Value)
                    this._Claimant_Customer =  Convert.ToBoolean(drPremises_Loss_RMW["Claimant_Customer"]);
                if( drPremises_Loss_RMW["Claimant_Third_Party"] != DBNull.Value)
                    this._Claimant_Third_Party = Convert.ToBoolean(drPremises_Loss_RMW["Claimant_Third_Party"]);
                this._Liability_Analysis = Convert.ToString(drPremises_Loss_RMW["Liability_Analysis"]);
                if(drPremises_Loss_RMW["Demand"] != DBNull.Value)
                    this._Demand = Convert.ToBoolean(drPremises_Loss_RMW["Demand"]);
                this._Claimant_Counsel_Name = Convert.ToString(drPremises_Loss_RMW["Claimant_Counsel_Name"]);
                this._Plantiff_Counsel_Name = Convert.ToString(drPremises_Loss_RMW["Plantiff_Counsel_Name"]);
                if(drPremises_Loss_RMW["Property_Damaged"] != DBNull.Value)
                    this._Property_Damaged =  Convert.ToBoolean(drPremises_Loss_RMW["Property_Damaged"]);
                this._Property_Damages_Description = Convert.ToString(drPremises_Loss_RMW["Property_Damages_Description"]);
                this._Damage_Amount = drPremises_Loss_RMW["Damage_Amount"] != DBNull.Value ? Convert.ToDecimal(drPremises_Loss_RMW["Damage_Amount"]) : 0;
                if(drPremises_Loss_RMW["Bodily_injury"] != DBNull.Value)
                    this._Bodily_injury = Convert.ToBoolean(drPremises_Loss_RMW["Bodily_injury"]);
                this._Injury_Description = Convert.ToString(drPremises_Loss_RMW["Injury_Description"]);
                this._Medical_Treatment_Description = Convert.ToString(drPremises_Loss_RMW["Medical_Treatment_Description"]);
                this._Medical_Cost = drPremises_Loss_RMW["Medical_Cost"] != DBNull.Value ? Convert.ToDecimal(drPremises_Loss_RMW["Medical_Cost"]) : 0;
                this._Requested_Amount = drPremises_Loss_RMW["Requested_Amount"] != DBNull.Value ? Convert.ToDecimal(drPremises_Loss_RMW["Requested_Amount"]) : 0;
                this._Potential_Total_Exposure = drPremises_Loss_RMW["Potential_Total_Exposure"] != DBNull.Value ? Convert.ToDecimal(drPremises_Loss_RMW["Potential_Total_Exposure"]) : 0;
                if(drPremises_Loss_RMW["Settled"] != DBNull.Value)
                    this._Settled =  Convert.ToBoolean(drPremises_Loss_RMW["Settled"]);
                this._Settled_Amount = drPremises_Loss_RMW["Settled_Amount"] != DBNull.Value ? Convert.ToDecimal(drPremises_Loss_RMW["Settled_Amount"]) : 0;
                this._GM_Email_To = Convert.ToString(drPremises_Loss_RMW["GM_Email_To"]);
                if(drPremises_Loss_RMW["GM_Decision"] != DBNull.Value )
                    this._GM_Decision = Convert.ToBoolean(drPremises_Loss_RMW["GM_Decision"]);
                this._GM_Last_Email_Date = drPremises_Loss_RMW["GM_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["GM_Last_Email_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._GM_Response_Date = drPremises_Loss_RMW["GM_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["GM_Response_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._CRM_Email_To = Convert.ToString(drPremises_Loss_RMW["CRM_Email_To"]);
                if(drPremises_Loss_RMW["CRM_Decision"] != DBNull.Value)
                    this._CRM_Decision =  Convert.ToBoolean(drPremises_Loss_RMW["CRM_Decision"]);
                this._CRM_Last_Email_Date = drPremises_Loss_RMW["CRM_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["CRM_Last_Email_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._CRM_Response_Date = drPremises_Loss_RMW["CRM_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["CRM_Response_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._RVP_Email_To = Convert.ToString(drPremises_Loss_RMW["RVP_Email_To"]);
                if(drPremises_Loss_RMW["RVP_Decision"] != DBNull.Value )
                    this._RVP_Decision = Convert.ToBoolean(drPremises_Loss_RMW["RVP_Decision"]);
                this._RVP_Last_Email_Date = drPremises_Loss_RMW["RVP_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["RVP_Last_Email_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._RVP_Response_Date = drPremises_Loss_RMW["RVP_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["RVP_Response_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._AGC_Email_To = Convert.ToString(drPremises_Loss_RMW["AGC_Email_To"]);
                if( drPremises_Loss_RMW["AGC_Decision"] != DBNull.Value)
                    this._AGC_Decision = Convert.ToBoolean(drPremises_Loss_RMW["AGC_Decision"]);
                this._AGC_Last_Email_Date = drPremises_Loss_RMW["AGC_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["AGC_Last_Email_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._AGC_Response_Date = drPremises_Loss_RMW["AGC_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["AGC_Response_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._DRM_Email_To = Convert.ToString(drPremises_Loss_RMW["DRM_Email_To"]);
                if(drPremises_Loss_RMW["DRM_Decision"] != DBNull.Value)
                    this._DRM_Decision = Convert.ToBoolean(drPremises_Loss_RMW["DRM_Decision"]);
                this._DRM_Last_Email_Date = drPremises_Loss_RMW["DRM_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["DRM_Last_Email_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._DRM_Response_Date = drPremises_Loss_RMW["DRM_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["DRM_Response_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._CFO_Email_To = Convert.ToString(drPremises_Loss_RMW["CFO_Email_To"]);
                if(drPremises_Loss_RMW["CFO_Decision"] != DBNull.Value)
                    this._CFO_Decision =  Convert.ToBoolean(drPremises_Loss_RMW["CFO_Decision"]);
                this._CFO_Last_Email_Date = drPremises_Loss_RMW["CFO_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["CFO_Last_Email_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._CFO_Response_Date = drPremises_Loss_RMW["CFO_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["CFO_Response_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COO_Email_To = Convert.ToString(drPremises_Loss_RMW["COO_Email_To"]);
                if(drPremises_Loss_RMW["COO_Decision"] != DBNull.Value)
                    this._COO_Decision =  Convert.ToBoolean(drPremises_Loss_RMW["COO_Decision"]);
                this._COO_Last_Email_Date = drPremises_Loss_RMW["COO_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["COO_Last_Email_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COO_Response_Date = drPremises_Loss_RMW["COO_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["COO_Response_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._President_Email_To = Convert.ToString(drPremises_Loss_RMW["President_Email_To"]);
                if(drPremises_Loss_RMW["President_Decision"] != DBNull.Value)
                    this._President_Decision =  Convert.ToBoolean(drPremises_Loss_RMW["President_Decision"]);
                this._President_Last_Email_Date = drPremises_Loss_RMW["President_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["President_Last_Email_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._President_Response_Date = drPremises_Loss_RMW["President_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drPremises_Loss_RMW["President_Response_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Comments = Convert.ToString(drPremises_Loss_RMW["Comments"]);

            }

            else
            {

                this._PK_Premises_Loss_RMW = -1;
                this._FK_Premises_Loss_Claims = -1;
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = "";
                this._Claimant_Customer = false;
                this._Claimant_Third_Party = false;
                this._Liability_Analysis = "";
                this._Demand = false;
                this._Claimant_Counsel_Name = "";
                this._Plantiff_Counsel_Name = "";
                this._Property_Damaged = false;
                this._Property_Damages_Description = "";
                this._Damage_Amount = -1;
                this._Bodily_injury = false;
                this._Injury_Description = "";
                this._Medical_Treatment_Description = "";
                this._Medical_Cost = -1;
                this._Requested_Amount = -1;
                this._Potential_Total_Exposure = -1;
                this._Settled = false;
                this._Settled_Amount = -1;
                this._GM_Email_To = "";
                this._GM_Decision = false;
                this._GM_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._GM_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._CRM_Email_To = "";
                this._CRM_Decision = false;
                this._CRM_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._CRM_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._RVP_Email_To = "";
                this._RVP_Decision = false;
                this._RVP_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._RVP_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._AGC_Email_To = "";
                this._AGC_Decision = false;
                this._AGC_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._AGC_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._DRM_Email_To = "";
                this._DRM_Decision = false;
                this._DRM_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._DRM_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._CFO_Email_To = "";
                this._CFO_Decision = false;
                this._CFO_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._CFO_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COO_Email_To = "";
                this._COO_Decision = false;
                this._COO_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COO_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._President_Email_To = "";
                this._President_Decision = false;
                this._President_Last_Email_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._President_Response_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Comments = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
		/// Inserts a record into the Premises_Loss_RMW table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Premises_Loss_RMWInsert");

			db.AddInParameter(dbCommand, "FK_Premises_Loss_Claims", DbType.Decimal, this._FK_Premises_Loss_Claims);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            if( this._Claimant_Customer!= true && this._Claimant_Customer!= false)
			    db.AddInParameter(dbCommand, "Claimant_Customer", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claimant_Customer", DbType.Boolean, this._Claimant_Customer);
            if( this._Claimant_Third_Party!= true && this._Claimant_Third_Party!= false)
			    db.AddInParameter(dbCommand, "Claimant_Third_Party", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claimant_Third_Party", DbType.Boolean, this._Claimant_Third_Party);
			db.AddInParameter(dbCommand, "Liability_Analysis", DbType.String, this._Liability_Analysis);
            if( this._Demand!= true && this._Demand!= false)
			    db.AddInParameter(dbCommand, "Demand", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Demand", DbType.Boolean, this._Demand);
			db.AddInParameter(dbCommand, "Claimant_Counsel_Name", DbType.String, this._Claimant_Counsel_Name);
			db.AddInParameter(dbCommand, "Plantiff_Counsel_Name", DbType.String, this._Plantiff_Counsel_Name);
            if( this._Property_Damaged!= true && this._Property_Damaged!= false)
			    db.AddInParameter(dbCommand, "Property_Damaged", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Property_Damaged", DbType.Boolean, this._Property_Damaged);
			db.AddInParameter(dbCommand, "Property_Damages_Description", DbType.String, this._Property_Damages_Description);
			db.AddInParameter(dbCommand, "Damage_Amount", DbType.Decimal, this._Damage_Amount);
            if( this._Bodily_injury!= true && this._Bodily_injury!= false)
			    db.AddInParameter(dbCommand, "Bodily_injury", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Bodily_injury", DbType.Boolean, this._Bodily_injury);
			db.AddInParameter(dbCommand, "Injury_Description", DbType.String, this._Injury_Description);
			db.AddInParameter(dbCommand, "Medical_Treatment_Description", DbType.String, this._Medical_Treatment_Description);
			db.AddInParameter(dbCommand, "Medical_Cost", DbType.Decimal, this._Medical_Cost);
			db.AddInParameter(dbCommand, "Requested_Amount", DbType.Decimal, this._Requested_Amount);
			db.AddInParameter(dbCommand, "Potential_Total_Exposure", DbType.Decimal, this._Potential_Total_Exposure);
            if( this._Settled!= true && this._Settled!= false)
			    db.AddInParameter(dbCommand, "Settled", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, this._Settled);
			db.AddInParameter(dbCommand, "Settled_Amount", DbType.Decimal, this._Settled_Amount);
			db.AddInParameter(dbCommand, "GM_Email_To", DbType.String, this._GM_Email_To);
            if( this._GM_Decision!= true && this._GM_Decision!= false)
			    db.AddInParameter(dbCommand, "GM_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "GM_Decision", DbType.Boolean, this._GM_Decision);
			db.AddInParameter(dbCommand, "GM_Last_Email_Date", DbType.DateTime, this._GM_Last_Email_Date);
			db.AddInParameter(dbCommand, "GM_Response_Date", DbType.DateTime, this._GM_Response_Date);
			db.AddInParameter(dbCommand, "CRM_Email_To", DbType.String, this._CRM_Email_To);
            if( this._CRM_Decision!= true && this._CRM_Decision!= false)
			    db.AddInParameter(dbCommand, "CRM_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CRM_Decision", DbType.Boolean, this._CRM_Decision);
			db.AddInParameter(dbCommand, "CRM_Last_Email_Date", DbType.DateTime, this._CRM_Last_Email_Date);
			db.AddInParameter(dbCommand, "CRM_Response_Date", DbType.DateTime, this._CRM_Response_Date);
			db.AddInParameter(dbCommand, "RVP_Email_To", DbType.String, this._RVP_Email_To);
            if( this._RVP_Decision!= true && this._RVP_Decision!= false)
			    db.AddInParameter(dbCommand, "RVP_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RVP_Decision", DbType.Boolean, this._RVP_Decision);
			db.AddInParameter(dbCommand, "RVP_Last_Email_Date", DbType.DateTime, this._RVP_Last_Email_Date);
			db.AddInParameter(dbCommand, "RVP_Response_Date", DbType.DateTime, this._RVP_Response_Date);
			db.AddInParameter(dbCommand, "AGC_Email_To", DbType.String, this._AGC_Email_To);
            if( this._AGC_Decision!= true && this._AGC_Decision!= false)
			    db.AddInParameter(dbCommand, "AGC_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AGC_Decision", DbType.Boolean, this._AGC_Decision);
			db.AddInParameter(dbCommand, "AGC_Last_Email_Date", DbType.DateTime, this._AGC_Last_Email_Date);
			db.AddInParameter(dbCommand, "AGC_Response_Date", DbType.DateTime, this._AGC_Response_Date);
			db.AddInParameter(dbCommand, "DRM_Email_To", DbType.String, this._DRM_Email_To);
            if( this._DRM_Decision!= true && this._DRM_Decision!= false)
			    db.AddInParameter(dbCommand, "DRM_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DRM_Decision", DbType.Boolean, this._DRM_Decision);
			db.AddInParameter(dbCommand, "DRM_Last_Email_Date", DbType.DateTime, this._DRM_Last_Email_Date);
			db.AddInParameter(dbCommand, "DRM_Response_Date", DbType.DateTime, this._DRM_Response_Date);
			db.AddInParameter(dbCommand, "CFO_Email_To", DbType.String, this._CFO_Email_To);
            if( this._CFO_Decision!= true && this._CFO_Decision!= false)
			    db.AddInParameter(dbCommand, "CFO_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CFO_Decision", DbType.Boolean, this._CFO_Decision);
			db.AddInParameter(dbCommand, "CFO_Last_Email_Date", DbType.DateTime, this._CFO_Last_Email_Date);
			db.AddInParameter(dbCommand, "CFO_Response_Date", DbType.DateTime, this._CFO_Response_Date);
			db.AddInParameter(dbCommand, "COO_Email_To", DbType.String, this._COO_Email_To);
            if(this._COO_Decision!= true && this._COO_Decision!= false)
			    db.AddInParameter(dbCommand, "COO_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "COO_Decision", DbType.Boolean, this._COO_Decision);
			db.AddInParameter(dbCommand, "COO_Last_Email_Date", DbType.DateTime, this._COO_Last_Email_Date);
			db.AddInParameter(dbCommand, "COO_Response_Date", DbType.DateTime, this._COO_Response_Date);
			db.AddInParameter(dbCommand, "President_Email_To", DbType.String, this._President_Email_To);
            if (this._President_Decision != true && this._President_Decision != false)
			    db.AddInParameter(dbCommand, "President_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "President_Decision", DbType.Boolean, this._President_Decision);
			db.AddInParameter(dbCommand, "President_Last_Email_Date", DbType.DateTime, this._President_Last_Email_Date);
			db.AddInParameter(dbCommand, "President_Response_Date", DbType.DateTime, this._President_Response_Date);
			db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Premises_Loss_RMW table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Premises_Loss_RMW)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Premises_Loss_RMWSelectByPK");

			db.AddInParameter(dbCommand, "PK_Premises_Loss_RMW", DbType.Decimal, pK_Premises_Loss_RMW);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Premises_Loss_RMW table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_Premises_Loss_Claims)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Premises_Loss_RMWSelectByFK");

            db.AddInParameter(dbCommand, "FK_Premises_Loss_Claims", DbType.Decimal, FK_Premises_Loss_Claims);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the Premises_Loss_RMW table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Premises_Loss_RMWSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Premises_Loss_RMW table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Premises_Loss_RMWUpdate");

			db.AddInParameter(dbCommand, "PK_Premises_Loss_RMW", DbType.Decimal, this._PK_Premises_Loss_RMW);
            db.AddInParameter(dbCommand, "FK_Premises_Loss_Claims", DbType.Decimal, this._FK_Premises_Loss_Claims);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            if (this._Claimant_Customer != true && this._Claimant_Customer != false)
                db.AddInParameter(dbCommand, "Claimant_Customer", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claimant_Customer", DbType.Boolean, this._Claimant_Customer);
            if (this._Claimant_Third_Party != true && this._Claimant_Third_Party != false)
                db.AddInParameter(dbCommand, "Claimant_Third_Party", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claimant_Third_Party", DbType.Boolean, this._Claimant_Third_Party);
            db.AddInParameter(dbCommand, "Liability_Analysis", DbType.String, this._Liability_Analysis);
            if (this._Demand != true && this._Demand != false)
                db.AddInParameter(dbCommand, "Demand", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Demand", DbType.Boolean, this._Demand);
            db.AddInParameter(dbCommand, "Claimant_Counsel_Name", DbType.String, this._Claimant_Counsel_Name);
            db.AddInParameter(dbCommand, "Plantiff_Counsel_Name", DbType.String, this._Plantiff_Counsel_Name);
            if (this._Property_Damaged != true && this._Property_Damaged != false)
                db.AddInParameter(dbCommand, "Property_Damaged", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Property_Damaged", DbType.Boolean, this._Property_Damaged);
            db.AddInParameter(dbCommand, "Property_Damages_Description", DbType.String, this._Property_Damages_Description);
            db.AddInParameter(dbCommand, "Damage_Amount", DbType.Decimal, this._Damage_Amount);
            if (this._Bodily_injury != true && this._Bodily_injury != false)
                db.AddInParameter(dbCommand, "Bodily_injury", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Bodily_injury", DbType.Boolean, this._Bodily_injury);
            db.AddInParameter(dbCommand, "Injury_Description", DbType.String, this._Injury_Description);
            db.AddInParameter(dbCommand, "Medical_Treatment_Description", DbType.String, this._Medical_Treatment_Description);
            db.AddInParameter(dbCommand, "Medical_Cost", DbType.Decimal, this._Medical_Cost);
            db.AddInParameter(dbCommand, "Requested_Amount", DbType.Decimal, this._Requested_Amount);
            db.AddInParameter(dbCommand, "Potential_Total_Exposure", DbType.Decimal, this._Potential_Total_Exposure);
            if (this._Settled != true && this._Settled != false)
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, this._Settled);
            db.AddInParameter(dbCommand, "Settled_Amount", DbType.Decimal, this._Settled_Amount);
            db.AddInParameter(dbCommand, "GM_Email_To", DbType.String, this._GM_Email_To);
            if (this._GM_Decision != true && this._GM_Decision != false)
                db.AddInParameter(dbCommand, "GM_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "GM_Decision", DbType.Boolean, this._GM_Decision);
            db.AddInParameter(dbCommand, "GM_Last_Email_Date", DbType.DateTime, this._GM_Last_Email_Date);
            db.AddInParameter(dbCommand, "GM_Response_Date", DbType.DateTime, this._GM_Response_Date);
            db.AddInParameter(dbCommand, "CRM_Email_To", DbType.String, this._CRM_Email_To);
            if (this._CRM_Decision != true && this._CRM_Decision != false)
                db.AddInParameter(dbCommand, "CRM_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CRM_Decision", DbType.Boolean, this._CRM_Decision);
            db.AddInParameter(dbCommand, "CRM_Last_Email_Date", DbType.DateTime, this._CRM_Last_Email_Date);
            db.AddInParameter(dbCommand, "CRM_Response_Date", DbType.DateTime, this._CRM_Response_Date);
            db.AddInParameter(dbCommand, "RVP_Email_To", DbType.String, this._RVP_Email_To);
            if (this._RVP_Decision != true && this._RVP_Decision != false)
                db.AddInParameter(dbCommand, "RVP_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RVP_Decision", DbType.Boolean, this._RVP_Decision);
            db.AddInParameter(dbCommand, "RVP_Last_Email_Date", DbType.DateTime, this._RVP_Last_Email_Date);
            db.AddInParameter(dbCommand, "RVP_Response_Date", DbType.DateTime, this._RVP_Response_Date);
            db.AddInParameter(dbCommand, "AGC_Email_To", DbType.String, this._AGC_Email_To);
            if (this._AGC_Decision != true && this._AGC_Decision != false)
                db.AddInParameter(dbCommand, "AGC_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AGC_Decision", DbType.Boolean, this._AGC_Decision);
            db.AddInParameter(dbCommand, "AGC_Last_Email_Date", DbType.DateTime, this._AGC_Last_Email_Date);
            db.AddInParameter(dbCommand, "AGC_Response_Date", DbType.DateTime, this._AGC_Response_Date);
            db.AddInParameter(dbCommand, "DRM_Email_To", DbType.String, this._DRM_Email_To);
            if (this._DRM_Decision != true && this._DRM_Decision != false)
                db.AddInParameter(dbCommand, "DRM_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DRM_Decision", DbType.Boolean, this._DRM_Decision);
            db.AddInParameter(dbCommand, "DRM_Last_Email_Date", DbType.DateTime, this._DRM_Last_Email_Date);
            db.AddInParameter(dbCommand, "DRM_Response_Date", DbType.DateTime, this._DRM_Response_Date);
            db.AddInParameter(dbCommand, "CFO_Email_To", DbType.String, this._CFO_Email_To);
            if (this._CFO_Decision != true && this._CFO_Decision != false)
                db.AddInParameter(dbCommand, "CFO_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CFO_Decision", DbType.Boolean, this._CFO_Decision);
            db.AddInParameter(dbCommand, "CFO_Last_Email_Date", DbType.DateTime, this._CFO_Last_Email_Date);
            db.AddInParameter(dbCommand, "CFO_Response_Date", DbType.DateTime, this._CFO_Response_Date);
            db.AddInParameter(dbCommand, "COO_Email_To", DbType.String, this._COO_Email_To);
            if (this._COO_Decision != true && this._COO_Decision != false)
                db.AddInParameter(dbCommand, "COO_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "COO_Decision", DbType.Boolean, this._COO_Decision);
            db.AddInParameter(dbCommand, "COO_Last_Email_Date", DbType.DateTime, this._COO_Last_Email_Date);
            db.AddInParameter(dbCommand, "COO_Response_Date", DbType.DateTime, this._COO_Response_Date);
            db.AddInParameter(dbCommand, "President_Email_To", DbType.String, this._President_Email_To);
            if (this._President_Decision != true && this._President_Decision != false)
                db.AddInParameter(dbCommand, "President_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "President_Decision", DbType.Boolean, this._President_Decision);
            db.AddInParameter(dbCommand, "President_Last_Email_Date", DbType.DateTime, this._President_Last_Email_Date);
            db.AddInParameter(dbCommand, "President_Response_Date", DbType.DateTime, this._President_Response_Date);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Updates a record in the Premises_Loss_RMW table.
        /// </summary>
        public void UpdateByFK()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Premises_Loss_RMWUpdateByFK");

            db.AddInParameter(dbCommand, "PK_Premises_Loss_RMW", DbType.Decimal, this._PK_Premises_Loss_RMW);
            db.AddInParameter(dbCommand, "FK_Premises_Loss_Claims", DbType.Decimal, this._FK_Premises_Loss_Claims);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            if (this._Claimant_Customer != true && this._Claimant_Customer != false)
                db.AddInParameter(dbCommand, "Claimant_Customer", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claimant_Customer", DbType.Boolean, this._Claimant_Customer);
            if (this._Claimant_Third_Party != true && this._Claimant_Third_Party != false)
                db.AddInParameter(dbCommand, "Claimant_Third_Party", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claimant_Third_Party", DbType.Boolean, this._Claimant_Third_Party);
            db.AddInParameter(dbCommand, "Liability_Analysis", DbType.String, this._Liability_Analysis);
            if (this._Demand != true && this._Demand != false)
                db.AddInParameter(dbCommand, "Demand", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Demand", DbType.Boolean, this._Demand);
            db.AddInParameter(dbCommand, "Claimant_Counsel_Name", DbType.String, this._Claimant_Counsel_Name);
            db.AddInParameter(dbCommand, "Plantiff_Counsel_Name", DbType.String, this._Plantiff_Counsel_Name);
            if (this._Property_Damaged != true && this._Property_Damaged != false)
                db.AddInParameter(dbCommand, "Property_Damaged", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Property_Damaged", DbType.Boolean, this._Property_Damaged);
            db.AddInParameter(dbCommand, "Property_Damages_Description", DbType.String, this._Property_Damages_Description);
            db.AddInParameter(dbCommand, "Damage_Amount", DbType.Decimal, this._Damage_Amount);
            if (this._Bodily_injury != true && this._Bodily_injury != false)
                db.AddInParameter(dbCommand, "Bodily_injury", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Bodily_injury", DbType.Boolean, this._Bodily_injury);
            db.AddInParameter(dbCommand, "Injury_Description", DbType.String, this._Injury_Description);
            db.AddInParameter(dbCommand, "Medical_Treatment_Description", DbType.String, this._Medical_Treatment_Description);
            db.AddInParameter(dbCommand, "Medical_Cost", DbType.Decimal, this._Medical_Cost);
            db.AddInParameter(dbCommand, "Requested_Amount", DbType.Decimal, this._Requested_Amount);
            db.AddInParameter(dbCommand, "Potential_Total_Exposure", DbType.Decimal, this._Potential_Total_Exposure);
            if (this._Settled != true && this._Settled != false)
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, this._Settled);
            db.AddInParameter(dbCommand, "Settled_Amount", DbType.Decimal, this._Settled_Amount);
            db.AddInParameter(dbCommand, "GM_Email_To", DbType.String, this._GM_Email_To);
            if (this._GM_Decision != true && this._GM_Decision != false)
                db.AddInParameter(dbCommand, "GM_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "GM_Decision", DbType.Boolean, this._GM_Decision);
            db.AddInParameter(dbCommand, "GM_Last_Email_Date", DbType.DateTime, this._GM_Last_Email_Date);
            db.AddInParameter(dbCommand, "GM_Response_Date", DbType.DateTime, this._GM_Response_Date);
            db.AddInParameter(dbCommand, "CRM_Email_To", DbType.String, this._CRM_Email_To);
            if (this._CRM_Decision != true && this._CRM_Decision != false)
                db.AddInParameter(dbCommand, "CRM_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CRM_Decision", DbType.Boolean, this._CRM_Decision);
            db.AddInParameter(dbCommand, "CRM_Last_Email_Date", DbType.DateTime, this._CRM_Last_Email_Date);
            db.AddInParameter(dbCommand, "CRM_Response_Date", DbType.DateTime, this._CRM_Response_Date);
            db.AddInParameter(dbCommand, "RVP_Email_To", DbType.String, this._RVP_Email_To);
            if (this._RVP_Decision != true && this._RVP_Decision != false)
                db.AddInParameter(dbCommand, "RVP_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RVP_Decision", DbType.Boolean, this._RVP_Decision);
            db.AddInParameter(dbCommand, "RVP_Last_Email_Date", DbType.DateTime, this._RVP_Last_Email_Date);
            db.AddInParameter(dbCommand, "RVP_Response_Date", DbType.DateTime, this._RVP_Response_Date);
            db.AddInParameter(dbCommand, "AGC_Email_To", DbType.String, this._AGC_Email_To);
            if (this._AGC_Decision != true && this._AGC_Decision != false)
                db.AddInParameter(dbCommand, "AGC_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "AGC_Decision", DbType.Boolean, this._AGC_Decision);
            db.AddInParameter(dbCommand, "AGC_Last_Email_Date", DbType.DateTime, this._AGC_Last_Email_Date);
            db.AddInParameter(dbCommand, "AGC_Response_Date", DbType.DateTime, this._AGC_Response_Date);
            db.AddInParameter(dbCommand, "DRM_Email_To", DbType.String, this._DRM_Email_To);
            if (this._DRM_Decision != true && this._DRM_Decision != false)
                db.AddInParameter(dbCommand, "DRM_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DRM_Decision", DbType.Boolean, this._DRM_Decision);
            db.AddInParameter(dbCommand, "DRM_Last_Email_Date", DbType.DateTime, this._DRM_Last_Email_Date);
            db.AddInParameter(dbCommand, "DRM_Response_Date", DbType.DateTime, this._DRM_Response_Date);
            db.AddInParameter(dbCommand, "CFO_Email_To", DbType.String, this._CFO_Email_To);
            if (this._CFO_Decision != true && this._CFO_Decision != false)
                db.AddInParameter(dbCommand, "CFO_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CFO_Decision", DbType.Boolean, this._CFO_Decision);
            db.AddInParameter(dbCommand, "CFO_Last_Email_Date", DbType.DateTime, this._CFO_Last_Email_Date);
            db.AddInParameter(dbCommand, "CFO_Response_Date", DbType.DateTime, this._CFO_Response_Date);
            db.AddInParameter(dbCommand, "COO_Email_To", DbType.String, this._COO_Email_To);
            if (this._COO_Decision != true && this._COO_Decision != false)
                db.AddInParameter(dbCommand, "COO_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "COO_Decision", DbType.Boolean, this._COO_Decision);
            db.AddInParameter(dbCommand, "COO_Last_Email_Date", DbType.DateTime, this._COO_Last_Email_Date);
            db.AddInParameter(dbCommand, "COO_Response_Date", DbType.DateTime, this._COO_Response_Date);
            db.AddInParameter(dbCommand, "President_Email_To", DbType.String, this._President_Email_To);
            if (this._President_Decision != true && this._President_Decision != false)
                db.AddInParameter(dbCommand, "President_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "President_Decision", DbType.Boolean, this._President_Decision);
            db.AddInParameter(dbCommand, "President_Last_Email_Date", DbType.DateTime, this._President_Last_Email_Date);
            db.AddInParameter(dbCommand, "President_Response_Date", DbType.DateTime, this._President_Response_Date);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            db.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// Deletes a record from the Premises_Loss_RMW table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Premises_Loss_RMW)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Premises_Loss_RMWDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Premises_Loss_RMW", DbType.Decimal, pK_Premises_Loss_RMW);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}

