#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimRepresentative
{

	#region Constructor
    public CLiabilityClaimRepresentative()
	{
        //this._fK_Liability_Claim = -1;
        //this._fairPoint_Name = string.Empty;
        //this._email = string.Empty;
        //this._telephone = string.Empty;
        //this._updated_By = string.Empty;
        //this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _fK_Liability_Claim;
	private System.String _fairPoint_Name;
	private System.String _email;
	private System.String _telephone;
	private System.String _updated_By;
	private System.DateTime? _updated_Date;
	#endregion

	#region Public Properties
    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String FairPoint_Name
	{
		get { return  _fairPoint_Name; }
		set { _fairPoint_Name = value; }
	}

	public System.String Email
	{
		get { return  _email; }
		set { _email = value; }
	}

	public System.String Telephone
	{
		get { return  _telephone; }
		set { _telephone = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime ? Updated_Date
	{
		get { return  _updated_Date; }
		set { _updated_Date = value; }
	}

	#endregion

	#region Abstract Methods
    public abstract List<CLiabilityClaimRepresentative> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimRepresentative> GetAL_Claim_RepresentativeByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_Representative(RIMS_Base.CLiabilityClaimRepresentative obj);
	public abstract int Deleteility_Claim_Representative(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_Representative(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
