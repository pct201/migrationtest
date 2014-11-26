#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityCoverageMaster
{

	#region Constructor
    public CLiabilityCoverageMaster()
	{
		this._pK_ID = -1;
		this._liability_Coverage_text = string.Empty;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_ID;
	private System.String _liability_Coverage_text;
	#endregion

	#region Public Properties
	public System.Decimal PK_ID
	{
		get { return  _pK_ID; }
		set { _pK_ID = value; }
	}

	public System.String Liability_Coverage_text
	{
		get { return  _liability_Coverage_text; }
		set { _liability_Coverage_text = value; }
	}

	#endregion

	#region Abstract Methods
	public abstract List<CLiabilityCoverageMaster> GetAll(Boolean blnIsActive);
	public abstract CLiabilityCoverageMaster Getility_Coverage_MasterByID(System.Decimal lPK_ID);
	public abstract int InsertUpdateility_Coverage_Master(RIMS_Base.CLiabilityCoverageMaster obj);
	public abstract int Deleteility_Coverage_Master(System.Decimal lPK_ID);
	public abstract string ActivateInactivateility_Coverage_Master(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
