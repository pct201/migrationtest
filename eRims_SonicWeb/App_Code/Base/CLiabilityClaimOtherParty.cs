#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimOtherParty
{

	#region Constructor
    public CLiabilityClaimOtherParty()
	{
		this._fK_Liability_Claim = -1;
		this._name = string.Empty;
		this._email = string.Empty;
		this._telePhone = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _fK_Liability_Claim;
	private System.String _name;
	private System.String _email;
	private System.String _telePhone;
	private System.String _updated_By;
	private System.DateTime _updated_Date;
	#endregion

	#region Public Properties
    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Name
	{
		get { return  _name; }
		set { _name = value; }
	}

	public System.String Email
	{
		get { return  _email; }
		set { _email = value; }
	}

	public System.String TelePhone
	{
		get { return  _telePhone; }
		set { _telePhone = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Updated_Date
	{
		get { return  _updated_Date; }
		set { _updated_Date = value; }
	}

	#endregion

	#region Abstract Methods
    public abstract List<CLiabilityClaimOtherParty> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimOtherParty> GetAL_Claim_OtherPartyByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_OtherParty(RIMS_Base.CLiabilityClaimOtherParty obj);
	public abstract int Deleteility_Claim_OtherParty(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_OtherParty(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
