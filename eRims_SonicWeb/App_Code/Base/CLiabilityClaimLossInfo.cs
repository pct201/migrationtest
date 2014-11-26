#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimLossInfo
{

	#region Constructor
    public CLiabilityClaimLossInfo()
	{
		this._fK_Liability_Claim = -1;
		this._full_Desc_loss = string.Empty;
		this._police_Notified = string.Empty;
		this._name_Of_Agency = string.Empty;
		this._officer_Name = string.Empty;
		this._officer_BadgeNo = string.Empty;
		this._ticket_Issued = string.Empty;
		this._injury_To_Cmp_Emps = string.Empty;
		this._injury_Desc_Emps = string.Empty;
		this._injury_To_Others = string.Empty;
		this._injury_Desc_Others = string.Empty;
		this._accident_Prev_Less_10k = string.Empty;
		this._accident_Prev_Greater_10k = string.Empty;
		this._accident_NonPrev = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _fK_Liability_Claim;
	private System.String _full_Desc_loss;
	private System.String _police_Notified;
	private System.String _name_Of_Agency;
	private System.String _officer_Name;
	private System.String _officer_BadgeNo;
	private System.String _ticket_Issued;
	private System.String _injury_To_Cmp_Emps;
	private System.String _injury_Desc_Emps;
	private System.String _injury_To_Others;
	private System.String _injury_Desc_Others;
	private System.String _accident_Prev_Less_10k;
	private System.String _accident_Prev_Greater_10k;
	private System.String _accident_NonPrev;
	private System.String _updated_By;
	private System.DateTime _updated_Date;
	#endregion

	#region Public Properties
    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Full_Desc_loss
	{
		get { return  _full_Desc_loss; }
		set { _full_Desc_loss = value; }
	}

	public System.String Police_Notified
	{
		get { return  _police_Notified; }
		set { _police_Notified = value; }
	}

	public System.String Name_Of_Agency
	{
		get { return  _name_Of_Agency; }
		set { _name_Of_Agency = value; }
	}

	public System.String Officer_Name
	{
		get { return  _officer_Name; }
		set { _officer_Name = value; }
	}

	public System.String Officer_BadgeNo
	{
		get { return  _officer_BadgeNo; }
		set { _officer_BadgeNo = value; }
	}

	public System.String Ticket_Issued
	{
		get { return  _ticket_Issued; }
		set { _ticket_Issued = value; }
	}

	public System.String Injury_To_Cmp_Emps
	{
		get { return  _injury_To_Cmp_Emps; }
		set { _injury_To_Cmp_Emps = value; }
	}

	public System.String Injury_Desc_Emps
	{
		get { return  _injury_Desc_Emps; }
		set { _injury_Desc_Emps = value; }
	}

	public System.String Injury_To_Others
	{
		get { return  _injury_To_Others; }
		set { _injury_To_Others = value; }
	}

	public System.String Injury_Desc_Others
	{
		get { return  _injury_Desc_Others; }
		set { _injury_Desc_Others = value; }
	}

	public System.String Accident_Prev_Less_10k
	{
		get { return  _accident_Prev_Less_10k; }
		set { _accident_Prev_Less_10k = value; }
	}

	public System.String Accident_Prev_Greater_10k
	{
		get { return  _accident_Prev_Greater_10k; }
		set { _accident_Prev_Greater_10k = value; }
	}

	public System.String Accident_NonPrev
	{
		get { return  _accident_NonPrev; }
		set { _accident_NonPrev = value; }
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
    public abstract List<CLiabilityClaimLossInfo> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimLossInfo> GetAL_Claim_LossInfoByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_LossInfo(RIMS_Base.CLiabilityClaimLossInfo obj);
	public abstract int Deleteility_Claim_LossInfo(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_LossInfo(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
