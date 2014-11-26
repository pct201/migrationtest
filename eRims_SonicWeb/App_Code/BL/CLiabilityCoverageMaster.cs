#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityCoverageMaster : RIMS_Base.CLiabilityCoverageMaster
{
	#region Private Declarations
	RIMS_Base.CLiabilityCoverageMaster mObjIlity_Coverage_Master;
	#endregion

	#region Constructor
	public CLiabilityCoverageMaster()
	{
		mObjIlity_Coverage_Master = new RIMS_Base.Dal.CLiabilityCoverageMaster();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Coverage_Master(RIMS_Base.CLiabilityCoverageMaster Objility_Coverage_Master)
	{
		return mObjIlity_Coverage_Master.InsertUpdateility_Coverage_Master(Objility_Coverage_Master);
	}

	public override int Deleteility_Coverage_Master(System.Decimal lPK_ID)
	{
		return mObjIlity_Coverage_Master.Deleteility_Coverage_Master(lPK_ID);
	} 

	public override string ActivateInactivateility_Coverage_Master(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Coverage_Master.ActivateInactivateility_Coverage_Master(strIDs, intModifiedBy, bIsActive);
	} 

	public override RIMS_Base.CLiabilityCoverageMaster Getility_Coverage_MasterByID(System.Decimal lPK_ID)
	{
		return mObjIlity_Coverage_Master.Getility_Coverage_MasterByID(lPK_ID);
	}

	public override List<RIMS_Base.CLiabilityCoverageMaster> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Coverage_Master.GetAll(blnIsActive);
	}
	#endregion

}

}