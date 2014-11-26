#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimCmpDriverInfo
{

	#region Constructor
    public CLiabilityClaimCmpDriverInfo()
	{
		this._fK_Liability_Claim = -1;
		this._name = string.Empty;
		this._supervisor = string.Empty;
		this._telephone_No = string.Empty;
		this._supervisor_TeleNo = string.Empty;
		this._list_Company_Passengers = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _fK_Liability_Claim;
	private System.String _name;
	private System.String _supervisor;
	private System.String _telephone_No;
	private System.String _supervisor_TeleNo;
	private System.String _list_Company_Passengers;
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

	public System.String Supervisor
	{
		get { return  _supervisor; }
		set { _supervisor = value; }
	}

	public System.String Telephone_No
	{
		get { return  _telephone_No; }
		set { _telephone_No = value; }
	}

	public System.String Supervisor_TeleNo
	{
		get { return  _supervisor_TeleNo; }
		set { _supervisor_TeleNo = value; }
	}

	public System.String List_Company_Passengers
	{
		get { return  _list_Company_Passengers; }
		set { _list_Company_Passengers = value; }
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
    public abstract List<CLiabilityClaimCmpDriverInfo> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimCmpDriverInfo> GetAL_Claim_CmpDriverInfoByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdatelility_Claim_CmpDriverInfo(RIMS_Base.CLiabilityClaimCmpDriverInfo obj);
	public abstract int Deletelility_Claim_CmpDriverInfo(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivatelility_Claim_CmpDriverInfo(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
