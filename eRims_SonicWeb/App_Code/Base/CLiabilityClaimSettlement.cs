#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimSettlement
{

	#region Constructor
    public CLiabilityClaimSettlement()
	{
		this._fK_Liability_Claim = -1;
        //this._settlement_Date_Offered = DateTime.Now;
       // this._amnt_Of_Settlement = -1;
        //this._release_Date = DateTime.Now;
        //this._settlement_ChkMail_Date = DateTime.Now;
		this._updated_By = string.Empty;
		//this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _fK_Liability_Claim;
	private System.DateTime? _settlement_Date_Offered;
	private System.Decimal _amnt_Of_Settlement;
	private System.DateTime? _release_Date;
	private System.DateTime? _settlement_ChkMail_Date;
	private System.String _updated_By;
	private System.DateTime? _updated_Date;
	#endregion

	#region Public Properties
	public System.Decimal FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.DateTime? Settlement_Date_Offered
	{
		get { return  _settlement_Date_Offered; }
		set { _settlement_Date_Offered = value; }
	}

	public System.Decimal Amnt_Of_Settlement
	{
		get { return  _amnt_Of_Settlement; }
		set { _amnt_Of_Settlement = value; }
	}

	public System.DateTime? Release_Date
	{
		get { return  _release_Date; }
		set { _release_Date = value; }
	}

	public System.DateTime? Settlement_ChkMail_Date
	{
		get { return  _settlement_ChkMail_Date; }
		set { _settlement_ChkMail_Date = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime? Updated_Date
	{
		get { return  _updated_Date; }
		set { _updated_Date = value; }
	}

	#endregion

	#region Abstract Methods
    public abstract List<CLiabilityClaimSettlement> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimSettlement> GetGL_Claim_SettlementByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_Settlement(RIMS_Base.CLiabilityClaimSettlement obj);
	public abstract int Deleteility_Claim_Settlement(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_Settlement(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
