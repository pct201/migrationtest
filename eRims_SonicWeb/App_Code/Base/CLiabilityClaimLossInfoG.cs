#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimLossInfoG
{

	#region Constructor
    public CLiabilityClaimLossInfoG()
	{
		this._fK_Liability_Claim = -1;
		this._desc_Loss = string.Empty;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _fK_Liability_Claim;
	private System.String _desc_Loss;
	#endregion

	#region Public Properties
	public System.Decimal FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Desc_Loss
	{
		get { return  _desc_Loss; }
		set { _desc_Loss = value; }
	}

	#endregion

	#region Abstract Methods
    public abstract List<CLiabilityClaimLossInfoG> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimLossInfoG> GetGL_Claim_LossInfo_GByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_LossInfo_G(RIMS_Base.CLiabilityClaimLossInfoG obj);
	public abstract int Deleteility_Claim_LossInfo_G(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_LossInfo_G(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
