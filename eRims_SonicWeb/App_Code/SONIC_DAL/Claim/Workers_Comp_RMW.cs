using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Workers_Comp_RMW table.
	/// </summary>
	public sealed class Workers_Comp_RMW
    {
    #region Fields
    private decimal _PK_Workers_Comp_RMW;
    private decimal _FK_Workers_Comp_Claims;
    private DateTime _Update_Date;
    private string _Updated_By;
    private string _Settlement_Method;
    private decimal _Policy_Deductible;
    private Nullable<bool> _Compensation_Originally_Denied;
    private Nullable<bool> _Waive_Subrogation;
    private Nullable<bool> _Confidentiality_Clause;
    private Nullable<bool> _Settlement_of_Permanent_Total;
    private Nullable<bool> _Other_Classification;
    private Nullable<bool> _LS_Reimbursement_Of_Cost;
    private Nullable<bool> _Close_Medicals;
    private Nullable<bool> _Other_Medicals;
    private Nullable<bool> _Resignation;
    private DateTime _Resignation_Date;
    private string _Defense_Council_Name;
    private string _Claimant_Attorney;
    private DateTime _Trial_Date;
    private string _Defense_Council_Telephone;
    private string _Claimant_Attorney_Telephone;
    private DateTime _Mediation_Date;
    private decimal _Demand_Amount;
    private decimal _RM_Requested_Amount;
    private decimal _Potential_Total_Exposure;
    private Nullable<bool> _Settled;
    private decimal _ADJ_Requested_Amount;
    private decimal _Authorized_Amount;
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
    private string _CC_Email_To;
    private Nullable<bool> _CC_Decision;
    private DateTime _CC_Last_Email_Date;
    private DateTime _CC_Response_Date;
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
    private string _Comments;
    private string _Full_Final_Clincher;

    #endregion
     
     
     #region Properties 
     

    /// <summary> 
    /// Gets or sets the PK_Workers_Comp_RMW value.
    /// </summary>
    public decimal PK_Workers_Comp_RMW
    {
	    get { return _PK_Workers_Comp_RMW; }
	    set { _PK_Workers_Comp_RMW = value; }
    }


    /// <summary> 
    /// Gets or sets the FK_Workers_Comp_Claims value.
    /// </summary>
    public decimal FK_Workers_Comp_Claims
    {
	    get { return _FK_Workers_Comp_Claims; }
	    set { _FK_Workers_Comp_Claims = value; }
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
    /// Gets or sets the Settlement_Method value.
    /// </summary>
    public string Settlement_Method
    {
	    get { return _Settlement_Method; }
	    set { _Settlement_Method = value; }
    }


    /// <summary> 
    /// Gets or sets the Policy_Deductible value.
    /// </summary>
    public decimal Policy_Deductible
    {
	    get { return _Policy_Deductible; }
	    set { _Policy_Deductible = value; }
    }


    /// <summary> 
    /// Gets or sets the Compensation_Originally_Denied value.
    /// </summary>
    public Nullable<bool> Compensation_Originally_Denied
    {
	    get { return _Compensation_Originally_Denied; }
	    set { _Compensation_Originally_Denied = value; }
    }


    /// <summary> 
    /// Gets or sets the Waive_Subrogation value.
    /// </summary>
    public Nullable<bool> Waive_Subrogation
    {
	    get { return _Waive_Subrogation; }
	    set { _Waive_Subrogation = value; }
    }


    /// <summary> 
    /// Gets or sets the Confidentiality_Clause value.
    /// </summary>
    public Nullable<bool> Confidentiality_Clause
    {
	    get { return _Confidentiality_Clause; }
	    set { _Confidentiality_Clause = value; }
    }


    /// <summary> 
    /// Gets or sets the Settlement_of_Permanent_Total value.
    /// </summary>
    public Nullable<bool> Settlement_of_Permanent_Total
    {
	    get { return _Settlement_of_Permanent_Total; }
	    set { _Settlement_of_Permanent_Total = value; }
    }


    /// <summary> 
    /// Gets or sets the Other_Classification value.
    /// </summary>
    public Nullable<bool> Other_Classification
    {
	    get { return _Other_Classification; }
	    set { _Other_Classification = value; }
    }


    /// <summary> 
    /// Gets or sets the LS_Reimbursement_Of_Cost value.
    /// </summary>
    public Nullable<bool> LS_Reimbursement_Of_Cost
    {
	    get { return _LS_Reimbursement_Of_Cost; }
	    set { _LS_Reimbursement_Of_Cost = value; }
    }


    /// <summary> 
    /// Gets or sets the Close_Medicals value.
    /// </summary>
    public Nullable<bool> Close_Medicals
    {
	    get { return _Close_Medicals; }
	    set { _Close_Medicals = value; }
    }


    /// <summary> 
    /// Gets or sets the Other_Medicals value.
    /// </summary>
    public Nullable<bool> Other_Medicals
    {
	    get { return _Other_Medicals; }
	    set { _Other_Medicals = value; }
    }


    /// <summary> 
    /// Gets or sets the Resignation value.
    /// </summary>
    public Nullable<bool> Resignation
    {
	    get { return _Resignation; }
	    set { _Resignation = value; }
    }


    /// <summary> 
    /// Gets or sets the Resignation_Date value.
    /// </summary>
    public DateTime Resignation_Date
    {
	    get { return _Resignation_Date; }
	    set { _Resignation_Date = value; }
    }


    /// <summary> 
    /// Gets or sets the Defense_Council_Name value.
    /// </summary>
    public string Defense_Council_Name
    {
	    get { return _Defense_Council_Name; }
	    set { _Defense_Council_Name = value; }
    }


    /// <summary> 
    /// Gets or sets the Claimant_Attorney value.
    /// </summary>
    public string Claimant_Attorney
    {
	    get { return _Claimant_Attorney; }
	    set { _Claimant_Attorney = value; }
    }


    /// <summary> 
    /// Gets or sets the Trial_Date value.
    /// </summary>
    public DateTime Trial_Date
    {
	    get { return _Trial_Date; }
	    set { _Trial_Date = value; }
    }


    /// <summary> 
    /// Gets or sets the Defense_Council_Telephone value.
    /// </summary>
    public string Defense_Council_Telephone
    {
	    get { return _Defense_Council_Telephone; }
	    set { _Defense_Council_Telephone = value; }
    }


    /// <summary> 
    /// Gets or sets the Claimant_Attorney_Telephone value.
    /// </summary>
    public string Claimant_Attorney_Telephone
    {
	    get { return _Claimant_Attorney_Telephone; }
	    set { _Claimant_Attorney_Telephone = value; }
    }


    /// <summary> 
    /// Gets or sets the Mediation_Date value.
    /// </summary>
    public DateTime Mediation_Date
    {
	    get { return _Mediation_Date; }
	    set { _Mediation_Date = value; }
    }


    /// <summary> 
    /// Gets or sets the Demand_Amount value.
    /// </summary>
    public decimal Demand_Amount
    {
	    get { return _Demand_Amount; }
	    set { _Demand_Amount = value; }
    }


    /// <summary> 
    /// Gets or sets the RM_Requested_Amount value.
    /// </summary>
    public decimal RM_Requested_Amount
    {
	    get { return _RM_Requested_Amount; }
	    set { _RM_Requested_Amount = value; }
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
    /// Gets or sets the ADJ_Requested_Amount value.
    /// </summary>
    public decimal ADJ_Requested_Amount
    {
	    get { return _ADJ_Requested_Amount; }
	    set { _ADJ_Requested_Amount = value; }
    }


    /// <summary> 
    /// Gets or sets the Authorized_Amount value.
    /// </summary>
    public decimal Authorized_Amount
    {
	    get { return _Authorized_Amount; }
	    set { _Authorized_Amount = value; }
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
    /// Gets or sets the CC_Email_To value.
    /// </summary>
    public string CC_Email_To
    {
	    get { return _CC_Email_To; }
	    set { _CC_Email_To = value; }
    }


    /// <summary> 
    /// Gets or sets the CC_Decision value.
    /// </summary>
    public Nullable<bool> CC_Decision
    {
	    get { return _CC_Decision; }
	    set { _CC_Decision = value; }
    }


    /// <summary> 
    /// Gets or sets the CC_Last_Email_Date value.
    /// </summary>
    public DateTime CC_Last_Email_Date
    {
	    get { return _CC_Last_Email_Date; }
	    set { _CC_Last_Email_Date = value; }
    }


    /// <summary> 
    /// Gets or sets the CC_Response_Date value.
    /// </summary>
    public DateTime CC_Response_Date
    {
	    get { return _CC_Response_Date; }
	    set { _CC_Response_Date = value; }
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
    /// Gets or sets the Comments value.
    /// </summary>
    public string Comments
    {
	    get { return _Comments; }
	    set { _Comments = value; }
    }

    public string Full_Final_Clincher
    {
        get { return _Full_Final_Clincher; }
        set { _Full_Final_Clincher = value; }
    }

    #endregion
     
     
     #region Constructors 
     
    /// <summary> 

    /// Initializes a new instance of the Workers_Comp_RMW class. with the default value.

    /// </summary>
    public Workers_Comp_RMW()
    {

	    this._PK_Workers_Comp_RMW = -1;
	    this._FK_Workers_Comp_Claims = -1;
	    this._Update_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._Updated_By = "";
	    this._Settlement_Method = "";
	    this._Policy_Deductible = -1;
	    this._Compensation_Originally_Denied = false;
	    this._Waive_Subrogation = false;
	    this._Confidentiality_Clause = false;
	    this._Settlement_of_Permanent_Total = false;
	    this._Other_Classification = false;
	    this._LS_Reimbursement_Of_Cost = false;
	    this._Close_Medicals = false;
	    this._Other_Medicals = false;
	    this._Resignation = false;
	    this._Resignation_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._Defense_Council_Name = "";
	    this._Claimant_Attorney = "";
	    this._Trial_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._Defense_Council_Telephone = "";
	    this._Claimant_Attorney_Telephone = "";
	    this._Mediation_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._Demand_Amount = -1;
	    this._RM_Requested_Amount = -1;
	    this._Potential_Total_Exposure = -1;
	    this._Settled = false;
	    this._ADJ_Requested_Amount = -1;
	    this._Authorized_Amount = -1;
	    this._Settled_Amount = -1;
	    this._GM_Email_To = "";
	    this._GM_Decision = false;
	    this._GM_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._GM_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._CRM_Email_To = "";
	    this._CRM_Decision = false;
	    this._CRM_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._CRM_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._RVP_Email_To = "";
	    this._RVP_Decision = false;
	    this._RVP_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._RVP_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._CC_Email_To = "";
	    this._CC_Decision = false;
	    this._CC_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._CC_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._DRM_Email_To = "";
	    this._DRM_Decision = false;
	    this._DRM_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._DRM_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._CFO_Email_To = "";
	    this._CFO_Decision = false;
	    this._CFO_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._CFO_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._COO_Email_To = "";
	    this._COO_Decision = false;
	    this._COO_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._COO_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
	    this._Comments = "";
        this._Full_Final_Clincher = "";

    }
 


/// <summary> 
/// Initializes a new instance of the Workers_Comp_RMW class for passed PrimaryKey with the values set from Database.
/// </summary>
public Workers_Comp_RMW(decimal PK)
{

	DataTable dtWorkers_Comp_RMW = SelectByPK(PK).Tables[0];

	if (dtWorkers_Comp_RMW.Rows.Count > 0)

	{

		DataRow drWorkers_Comp_RMW = dtWorkers_Comp_RMW.Rows[0];

		this._PK_Workers_Comp_RMW = drWorkers_Comp_RMW["PK_Workers_Comp_RMW"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_RMW["PK_Workers_Comp_RMW"]) : 0;
		this._FK_Workers_Comp_Claims = drWorkers_Comp_RMW["FK_Workers_Comp_Claims"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_RMW["FK_Workers_Comp_Claims"]) : 0;
		this._Update_Date = drWorkers_Comp_RMW["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Updated_By = Convert.ToString(drWorkers_Comp_RMW["Updated_By"]);
		this._Settlement_Method = Convert.ToString(drWorkers_Comp_RMW["Settlement_Method"]);
		this._Policy_Deductible = drWorkers_Comp_RMW["Policy_Deductible"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_RMW["Policy_Deductible"]) : 0;
		this._Compensation_Originally_Denied = drWorkers_Comp_RMW["Compensation_Originally_Denied"] != DBNull.Value ? Convert.ToBoolean(drWorkers_Comp_RMW["Compensation_Originally_Denied"]) : false;
        if (drWorkers_Comp_RMW["Waive_Subrogation"] != DBNull.Value)
            this._Waive_Subrogation = Convert.ToBoolean(drWorkers_Comp_RMW["Waive_Subrogation"]);
        if (drWorkers_Comp_RMW["Confidentiality_Clause"] != DBNull.Value)
            this._Confidentiality_Clause = Convert.ToBoolean(drWorkers_Comp_RMW["Confidentiality_Clause"]);
		this._Settlement_of_Permanent_Total = drWorkers_Comp_RMW["Settlement_of_Permanent_Total"] != DBNull.Value ? Convert.ToBoolean(drWorkers_Comp_RMW["Settlement_of_Permanent_Total"]) : false;
        if (drWorkers_Comp_RMW["Other_Classification"] != DBNull.Value)
            this._Other_Classification = Convert.ToBoolean(drWorkers_Comp_RMW["Other_Classification"]);
		this._LS_Reimbursement_Of_Cost = drWorkers_Comp_RMW["LS_Reimbursement_Of_Cost"] != DBNull.Value ? Convert.ToBoolean(drWorkers_Comp_RMW["LS_Reimbursement_Of_Cost"]) : false;
		if(drWorkers_Comp_RMW["Close_Medicals"] != DBNull.Value)
            this._Close_Medicals =  Convert.ToBoolean(drWorkers_Comp_RMW["Close_Medicals"]);
        if(drWorkers_Comp_RMW["Other_Medicals"] != DBNull.Value)
            this._Other_Medicals =  Convert.ToBoolean(drWorkers_Comp_RMW["Other_Medicals"]);
        if(drWorkers_Comp_RMW["Resignation"] != DBNull.Value)
            this._Resignation =  Convert.ToBoolean(drWorkers_Comp_RMW["Resignation"]);
		this._Resignation_Date = drWorkers_Comp_RMW["Resignation_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["Resignation_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Defense_Council_Name = Convert.ToString(drWorkers_Comp_RMW["Defense_Council_Name"]);
		this._Claimant_Attorney = Convert.ToString(drWorkers_Comp_RMW["Claimant_Attorney"]);
		this._Trial_Date = drWorkers_Comp_RMW["Trial_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["Trial_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Defense_Council_Telephone = Convert.ToString(drWorkers_Comp_RMW["Defense_Council_Telephone"]);
		this._Claimant_Attorney_Telephone = Convert.ToString(drWorkers_Comp_RMW["Claimant_Attorney_Telephone"]);
		this._Mediation_Date = drWorkers_Comp_RMW["Mediation_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["Mediation_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Demand_Amount = drWorkers_Comp_RMW["Demand_Amount"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_RMW["Demand_Amount"]) : 0;
		this._RM_Requested_Amount = drWorkers_Comp_RMW["RM_Requested_Amount"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_RMW["RM_Requested_Amount"]) : 0;
		this._Potential_Total_Exposure = drWorkers_Comp_RMW["Potential_Total_Exposure"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_RMW["Potential_Total_Exposure"]) : 0;
		if(drWorkers_Comp_RMW["Settled"] != DBNull.Value)
            this._Settled =  Convert.ToBoolean(drWorkers_Comp_RMW["Settled"]);
		this._ADJ_Requested_Amount = drWorkers_Comp_RMW["ADJ_Requested_Amount"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_RMW["ADJ_Requested_Amount"]) : 0;
		this._Authorized_Amount = drWorkers_Comp_RMW["Authorized_Amount"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_RMW["Authorized_Amount"]) : 0;
		this._Settled_Amount = drWorkers_Comp_RMW["Settled_Amount"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_RMW["Settled_Amount"]) : 0;
		this._GM_Email_To = Convert.ToString(drWorkers_Comp_RMW["GM_Email_To"]);
        if (drWorkers_Comp_RMW["GM_Decision"] != DBNull.Value)
            this._GM_Decision = Convert.ToBoolean(drWorkers_Comp_RMW["GM_Decision"]);
		this._GM_Last_Email_Date = drWorkers_Comp_RMW["GM_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["GM_Last_Email_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._GM_Response_Date = drWorkers_Comp_RMW["GM_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["GM_Response_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CRM_Email_To = Convert.ToString(drWorkers_Comp_RMW["CRM_Email_To"]);
        if(drWorkers_Comp_RMW["CRM_Decision"] != DBNull.Value)
            this._CRM_Decision =  Convert.ToBoolean(drWorkers_Comp_RMW["CRM_Decision"]);
		this._CRM_Last_Email_Date = drWorkers_Comp_RMW["CRM_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["CRM_Last_Email_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CRM_Response_Date = drWorkers_Comp_RMW["CRM_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["CRM_Response_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._RVP_Email_To = Convert.ToString(drWorkers_Comp_RMW["RVP_Email_To"]);
        if( drWorkers_Comp_RMW["RVP_Decision"] != DBNull.Value)
            this._RVP_Decision = Convert.ToBoolean(drWorkers_Comp_RMW["RVP_Decision"]);
		this._RVP_Last_Email_Date = drWorkers_Comp_RMW["RVP_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["RVP_Last_Email_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._RVP_Response_Date = drWorkers_Comp_RMW["RVP_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["RVP_Response_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CC_Email_To = Convert.ToString(drWorkers_Comp_RMW["CC_Email_To"]);
        if(drWorkers_Comp_RMW["CC_Decision"] != DBNull.Value)
            this._CC_Decision =  Convert.ToBoolean(drWorkers_Comp_RMW["CC_Decision"]);
		this._CC_Last_Email_Date = drWorkers_Comp_RMW["CC_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["CC_Last_Email_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CC_Response_Date = drWorkers_Comp_RMW["CC_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["CC_Response_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._DRM_Email_To = Convert.ToString(drWorkers_Comp_RMW["DRM_Email_To"]);
        if(drWorkers_Comp_RMW["DRM_Decision"] != DBNull.Value)
            this._DRM_Decision =  Convert.ToBoolean(drWorkers_Comp_RMW["DRM_Decision"]);
		this._DRM_Last_Email_Date = drWorkers_Comp_RMW["DRM_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["DRM_Last_Email_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._DRM_Response_Date = drWorkers_Comp_RMW["DRM_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["DRM_Response_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CFO_Email_To = Convert.ToString(drWorkers_Comp_RMW["CFO_Email_To"]);
        if(drWorkers_Comp_RMW["CFO_Decision"] != DBNull.Value)
            this._CFO_Decision =  Convert.ToBoolean(drWorkers_Comp_RMW["CFO_Decision"]);
		this._CFO_Last_Email_Date = drWorkers_Comp_RMW["CFO_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["CFO_Last_Email_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CFO_Response_Date = drWorkers_Comp_RMW["CFO_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["CFO_Response_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._COO_Email_To = Convert.ToString(drWorkers_Comp_RMW["COO_Email_To"]);
        if(drWorkers_Comp_RMW["COO_Decision"] != DBNull.Value)
            this._COO_Decision =  Convert.ToBoolean(drWorkers_Comp_RMW["COO_Decision"]);
		this._COO_Last_Email_Date = drWorkers_Comp_RMW["COO_Last_Email_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["COO_Last_Email_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._COO_Response_Date = drWorkers_Comp_RMW["COO_Response_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_RMW["COO_Response_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Comments = Convert.ToString(drWorkers_Comp_RMW["Comments"]);
        this._Full_Final_Clincher = Convert.ToString(drWorkers_Comp_RMW["Full_Final_Clincher"]);

	}

	else

	{

		this._PK_Workers_Comp_RMW = -1;
		this._FK_Workers_Comp_Claims = -1;
		this._Update_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Updated_By = "";
		this._Settlement_Method = "";
		this._Policy_Deductible = -1;
		this._Compensation_Originally_Denied = false;
		this._Waive_Subrogation = false;
		this._Confidentiality_Clause = false;
		this._Settlement_of_Permanent_Total = false;
		this._Other_Classification = false;
		this._LS_Reimbursement_Of_Cost = false;
		this._Close_Medicals = false;
		this._Other_Medicals = false;
		this._Resignation = false;
		this._Resignation_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Defense_Council_Name = "";
		this._Claimant_Attorney = "";
		this._Trial_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Defense_Council_Telephone = "";
		this._Claimant_Attorney_Telephone = "";
		this._Mediation_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Demand_Amount = -1;
		this._RM_Requested_Amount = -1;
		this._Potential_Total_Exposure = -1;
		this._Settled = false;
		this._ADJ_Requested_Amount = -1;
		this._Authorized_Amount = -1;
		this._Settled_Amount = -1;
		this._GM_Email_To = "";
		this._GM_Decision = false;
		this._GM_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._GM_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CRM_Email_To = "";
		this._CRM_Decision = false;
		this._CRM_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CRM_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._RVP_Email_To = "";
		this._RVP_Decision = false;
		this._RVP_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._RVP_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CC_Email_To = "";
		this._CC_Decision = false;
		this._CC_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CC_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._DRM_Email_To = "";
		this._DRM_Decision = false;
		this._DRM_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._DRM_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CFO_Email_To = "";
		this._CFO_Decision = false;
		this._CFO_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._CFO_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._COO_Email_To = "";
		this._COO_Decision = false;
		this._COO_Last_Email_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._COO_Response_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;
		this._Comments = "";
        this._Full_Final_Clincher = "";

	}

}

#endregion

        #region Methods
    
        /// <summary>
		/// Inserts a record into the Workers_Comp_RMW table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_RMWInsert");

            db.AddInParameter(dbCommand, "FK_Workers_Comp_Claims", DbType.Decimal, this._FK_Workers_Comp_Claims);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Settlement_Method", DbType.String, this._Settlement_Method);
            db.AddInParameter(dbCommand, "Policy_Deductible", DbType.Decimal, this._Policy_Deductible);
            if (this._Compensation_Originally_Denied != true && this._Compensation_Originally_Denied != false)
                db.AddInParameter(dbCommand, "Compensation_Originally_Denied", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Compensation_Originally_Denied", DbType.Boolean, this._Compensation_Originally_Denied);
            if (this._Waive_Subrogation != true && this._Waive_Subrogation != false)
                db.AddInParameter(dbCommand, "Waive_Subrogation", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Waive_Subrogation", DbType.Boolean, this._Waive_Subrogation);
            if (this._Confidentiality_Clause != true && this._Confidentiality_Clause != false)
                db.AddInParameter(dbCommand, "Confidentiality_Clause", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Confidentiality_Clause", DbType.Boolean, this._Confidentiality_Clause);
            if (this._Settlement_of_Permanent_Total != true && this._Settlement_of_Permanent_Total != false)
                db.AddInParameter(dbCommand, "Settlement_of_Permanent_Total", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Settlement_of_Permanent_Total", DbType.Boolean, this._Settlement_of_Permanent_Total);
            if (this._Other_Classification != true && this._Other_Classification != false)
                db.AddInParameter(dbCommand, "Other_Classification", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Classification", DbType.Boolean, this._Other_Classification);
            if (this._LS_Reimbursement_Of_Cost != true && this._LS_Reimbursement_Of_Cost != false)
                db.AddInParameter(dbCommand, "LS_Reimbursement_Of_Cost", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LS_Reimbursement_Of_Cost", DbType.Boolean, this._LS_Reimbursement_Of_Cost);
            if (this._Close_Medicals != true && this._Close_Medicals != false)
                db.AddInParameter(dbCommand, "Close_Medicals", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Close_Medicals", DbType.Boolean, this._Close_Medicals);
            if (this._Other_Medicals != true && this._Other_Medicals != false)
                db.AddInParameter(dbCommand, "Other_Medicals", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Medicals", DbType.Boolean, this._Other_Medicals);
            if (this._Resignation != true && this._Resignation != false)
                db.AddInParameter(dbCommand, "Resignation", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resignation", DbType.Boolean, this._Resignation);
            db.AddInParameter(dbCommand, "Resignation_Date", DbType.DateTime, this._Resignation_Date);
            db.AddInParameter(dbCommand, "Defense_Council_Name", DbType.String, this._Defense_Council_Name);
            db.AddInParameter(dbCommand, "Claimant_Attorney", DbType.String, this._Claimant_Attorney);
            db.AddInParameter(dbCommand, "Trial_Date", DbType.DateTime, this._Trial_Date);
            db.AddInParameter(dbCommand, "Defense_Council_Telephone", DbType.String, this._Defense_Council_Telephone);
            db.AddInParameter(dbCommand, "Claimant_Attorney_Telephone", DbType.String, this._Claimant_Attorney_Telephone);
            db.AddInParameter(dbCommand, "Mediation_Date", DbType.DateTime, this._Mediation_Date);
            db.AddInParameter(dbCommand, "Demand_Amount", DbType.Decimal, this._Demand_Amount);
            db.AddInParameter(dbCommand, "RM_Requested_Amount", DbType.Decimal, this._RM_Requested_Amount);
            db.AddInParameter(dbCommand, "Potential_Total_Exposure", DbType.Decimal, this._Potential_Total_Exposure);
            if (this._Settled != true && this._Settled != false)
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, this._Settled);
            db.AddInParameter(dbCommand, "ADJ_Requested_Amount", DbType.Decimal, this._ADJ_Requested_Amount);
            db.AddInParameter(dbCommand, "Authorized_Amount", DbType.Decimal, this._Authorized_Amount);
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
            db.AddInParameter(dbCommand, "CC_Email_To", DbType.String, this._CC_Email_To);
            if (this._CC_Decision != true && this._CC_Decision != false)
                db.AddInParameter(dbCommand, "CC_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CC_Decision", DbType.Boolean, this._CC_Decision);
            db.AddInParameter(dbCommand, "CC_Last_Email_Date", DbType.DateTime, this._CC_Last_Email_Date);
            db.AddInParameter(dbCommand, "CC_Response_Date", DbType.DateTime, this._CC_Response_Date);
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
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Full_Final_Clincher", DbType.String, this._Full_Final_Clincher);
            

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Workers_Comp_RMW table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Workers_Comp_RMW)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_RMWSelectByPK");

			db.AddInParameter(dbCommand, "PK_Workers_Comp_RMW", DbType.Decimal, pK_Workers_Comp_RMW);

			return db.ExecuteDataSet(dbCommand);
		}
        

        /// <summary>
		/// Selects a single record from the Workers_Comp_RMW table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_Workers_Comp_Claims)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_RMWSelectByFK");

            db.AddInParameter(dbCommand, "FK_Workers_Comp_Claims", DbType.Decimal, FK_Workers_Comp_Claims);

			return db.ExecuteDataSet(dbCommand);
		} 

		/// <summary>
		/// Selects all records from the Workers_Comp_RMW table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_RMWSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Workers_Comp_RMW table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_RMWUpdate");

			db.AddInParameter(dbCommand, "PK_Workers_Comp_RMW", DbType.Decimal, this._PK_Workers_Comp_RMW);
			db.AddInParameter(dbCommand, "FK_Workers_Comp_Claims", DbType.Decimal, this._FK_Workers_Comp_Claims);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			db.AddInParameter(dbCommand, "Settlement_Method", DbType.String, this._Settlement_Method);
			db.AddInParameter(dbCommand, "Policy_Deductible", DbType.Decimal, this._Policy_Deductible);
            if(this._Compensation_Originally_Denied != true && this._Compensation_Originally_Denied != false)
                db.AddInParameter(dbCommand, "Compensation_Originally_Denied", DbType.Boolean, DBNull.Value);
            else
			    db.AddInParameter(dbCommand, "Compensation_Originally_Denied", DbType.Boolean, this._Compensation_Originally_Denied);
            if (this._Waive_Subrogation != true && this._Waive_Subrogation != false)
            	db.AddInParameter(dbCommand, "Waive_Subrogation", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Waive_Subrogation", DbType.Boolean, this._Waive_Subrogation);
            if( this._Confidentiality_Clause!= true && this._Confidentiality_Clause!= false)
			    db.AddInParameter(dbCommand, "Confidentiality_Clause", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Confidentiality_Clause", DbType.Boolean, this._Confidentiality_Clause);
            if( this._Settlement_of_Permanent_Total!= true && this._Settlement_of_Permanent_Total!= false)
    			db.AddInParameter(dbCommand, "Settlement_of_Permanent_Total", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Settlement_of_Permanent_Total", DbType.Boolean, this._Settlement_of_Permanent_Total);
            if( this._Other_Classification!= true && this._Other_Classification!= false)
			    db.AddInParameter(dbCommand, "Other_Classification", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Classification", DbType.Boolean, this._Other_Classification);
            if( this._LS_Reimbursement_Of_Cost!= true && this._LS_Reimbursement_Of_Cost!= false)
			    db.AddInParameter(dbCommand, "LS_Reimbursement_Of_Cost", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LS_Reimbursement_Of_Cost", DbType.Boolean, this._LS_Reimbursement_Of_Cost);
            if( this._Close_Medicals!= true && this._Close_Medicals!= false)
			    db.AddInParameter(dbCommand, "Close_Medicals", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Close_Medicals", DbType.Boolean, this._Close_Medicals);
            if( this._Other_Medicals!= true && this._Other_Medicals!= false)
			    db.AddInParameter(dbCommand, "Other_Medicals", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Medicals", DbType.Boolean, this._Other_Medicals);
            if( this._Resignation!= true && this._Resignation!= false)
			    db.AddInParameter(dbCommand, "Resignation", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resignation", DbType.Boolean, this._Resignation);
			db.AddInParameter(dbCommand, "Resignation_Date", DbType.DateTime, this._Resignation_Date);
			db.AddInParameter(dbCommand, "Defense_Council_Name", DbType.String, this._Defense_Council_Name);
			db.AddInParameter(dbCommand, "Claimant_Attorney", DbType.String, this._Claimant_Attorney);
			db.AddInParameter(dbCommand, "Trial_Date", DbType.DateTime, this._Trial_Date);
			db.AddInParameter(dbCommand, "Defense_Council_Telephone", DbType.String, this._Defense_Council_Telephone);
			db.AddInParameter(dbCommand, "Claimant_Attorney_Telephone", DbType.String, this._Claimant_Attorney_Telephone);
			db.AddInParameter(dbCommand, "Mediation_Date", DbType.DateTime, this._Mediation_Date);
			db.AddInParameter(dbCommand, "Demand_Amount", DbType.Decimal, this._Demand_Amount);
			db.AddInParameter(dbCommand, "RM_Requested_Amount", DbType.Decimal, this._RM_Requested_Amount);
			db.AddInParameter(dbCommand, "Potential_Total_Exposure", DbType.Decimal, this._Potential_Total_Exposure);
            if( this._Settled!= true && this._Settled!= false)
			    db.AddInParameter(dbCommand, "Settled", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, this._Settled);
			db.AddInParameter(dbCommand, "ADJ_Requested_Amount", DbType.Decimal, this._ADJ_Requested_Amount);
			db.AddInParameter(dbCommand, "Authorized_Amount", DbType.Decimal, this._Authorized_Amount);
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
			db.AddInParameter(dbCommand, "CC_Email_To", DbType.String, this._CC_Email_To);
            if( this._CC_Decision!= true && this._CC_Decision!= false)
			    db.AddInParameter(dbCommand, "CC_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CC_Decision", DbType.Boolean, this._CC_Decision);
			db.AddInParameter(dbCommand, "CC_Last_Email_Date", DbType.DateTime, this._CC_Last_Email_Date);
			db.AddInParameter(dbCommand, "CC_Response_Date", DbType.DateTime, this._CC_Response_Date);
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
            if( this._COO_Decision!= true && this._COO_Decision!= false)
			    db.AddInParameter(dbCommand, "COO_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "COO_Decision", DbType.Boolean, this._COO_Decision);
			db.AddInParameter(dbCommand, "COO_Last_Email_Date", DbType.DateTime, this._COO_Last_Email_Date);
			db.AddInParameter(dbCommand, "COO_Response_Date", DbType.DateTime, this._COO_Response_Date);
			db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Full_Final_Clincher", DbType.String, this._Full_Final_Clincher);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Updates a record in the Workers_Comp_RMW table.
        /// </summary>
        public void UpdateByFK()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_RMWUpdateByFK");

            db.AddInParameter(dbCommand, "FK_Workers_Comp_Claims", DbType.Decimal, this._FK_Workers_Comp_Claims);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Settlement_Method", DbType.String, this._Settlement_Method);
            db.AddInParameter(dbCommand, "Policy_Deductible", DbType.Decimal, this._Policy_Deductible);
            if (this._Compensation_Originally_Denied != true && this._Compensation_Originally_Denied != false)
                db.AddInParameter(dbCommand, "Compensation_Originally_Denied", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Compensation_Originally_Denied", DbType.Boolean, this._Compensation_Originally_Denied);
            if (this._Waive_Subrogation != true && this._Waive_Subrogation != false)
                db.AddInParameter(dbCommand, "Waive_Subrogation", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Waive_Subrogation", DbType.Boolean, this._Waive_Subrogation);
            if (this._Confidentiality_Clause != true && this._Confidentiality_Clause != false)
                db.AddInParameter(dbCommand, "Confidentiality_Clause", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Confidentiality_Clause", DbType.Boolean, this._Confidentiality_Clause);
            if (this._Settlement_of_Permanent_Total != true && this._Settlement_of_Permanent_Total != false)
                db.AddInParameter(dbCommand, "Settlement_of_Permanent_Total", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Settlement_of_Permanent_Total", DbType.Boolean, this._Settlement_of_Permanent_Total);
            if (this._Other_Classification != true && this._Other_Classification != false)
                db.AddInParameter(dbCommand, "Other_Classification", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Classification", DbType.Boolean, this._Other_Classification);
            if (this._LS_Reimbursement_Of_Cost != true && this._LS_Reimbursement_Of_Cost != false)
                db.AddInParameter(dbCommand, "LS_Reimbursement_Of_Cost", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LS_Reimbursement_Of_Cost", DbType.Boolean, this._LS_Reimbursement_Of_Cost);
            if (this._Close_Medicals != true && this._Close_Medicals != false)
                db.AddInParameter(dbCommand, "Close_Medicals", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Close_Medicals", DbType.Boolean, this._Close_Medicals);
            if (this._Other_Medicals != true && this._Other_Medicals != false)
                db.AddInParameter(dbCommand, "Other_Medicals", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Medicals", DbType.Boolean, this._Other_Medicals);
            if (this._Resignation != true && this._Resignation != false)
                db.AddInParameter(dbCommand, "Resignation", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Resignation", DbType.Boolean, this._Resignation);
            db.AddInParameter(dbCommand, "Resignation_Date", DbType.DateTime, this._Resignation_Date);
            db.AddInParameter(dbCommand, "Defense_Council_Name", DbType.String, this._Defense_Council_Name);
            db.AddInParameter(dbCommand, "Claimant_Attorney", DbType.String, this._Claimant_Attorney);
            db.AddInParameter(dbCommand, "Trial_Date", DbType.DateTime, this._Trial_Date);
            db.AddInParameter(dbCommand, "Defense_Council_Telephone", DbType.String, this._Defense_Council_Telephone);
            db.AddInParameter(dbCommand, "Claimant_Attorney_Telephone", DbType.String, this._Claimant_Attorney_Telephone);
            db.AddInParameter(dbCommand, "Mediation_Date", DbType.DateTime, this._Mediation_Date);
            db.AddInParameter(dbCommand, "Demand_Amount", DbType.Decimal, this._Demand_Amount);
            db.AddInParameter(dbCommand, "RM_Requested_Amount", DbType.Decimal, this._RM_Requested_Amount);
            db.AddInParameter(dbCommand, "Potential_Total_Exposure", DbType.Decimal, this._Potential_Total_Exposure);
            if (this._Settled != true && this._Settled != false)
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Settled", DbType.Boolean, this._Settled);
            db.AddInParameter(dbCommand, "ADJ_Requested_Amount", DbType.Decimal, this._ADJ_Requested_Amount);
            db.AddInParameter(dbCommand, "Authorized_Amount", DbType.Decimal, this._Authorized_Amount);
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
            db.AddInParameter(dbCommand, "CC_Email_To", DbType.String, this._CC_Email_To);
            if (this._CC_Decision != true && this._CC_Decision != false)
                db.AddInParameter(dbCommand, "CC_Decision", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CC_Decision", DbType.Boolean, this._CC_Decision);
            db.AddInParameter(dbCommand, "CC_Last_Email_Date", DbType.DateTime, this._CC_Last_Email_Date);
            db.AddInParameter(dbCommand, "CC_Response_Date", DbType.DateTime, this._CC_Response_Date);
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
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Full_Final_Clincher", DbType.String, this._Full_Final_Clincher);
            db.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// Deletes a record from the Workers_Comp_RMW table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Workers_Comp_RMW)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_RMWDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Workers_Comp_RMW", DbType.Decimal, pK_Workers_Comp_RMW);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
