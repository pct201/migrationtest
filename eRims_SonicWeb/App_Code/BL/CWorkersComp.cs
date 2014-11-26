#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{
    public class CWorkersComp : RIMS_Base.CWorkersComp
    {

    #region Private Declarations
	RIMS_Base.CWorkersComp mObjErs_Compensation;
	#endregion

	#region Constructor
        public CWorkersComp()
	{
		mObjErs_Compensation = new RIMS_Base.Dal.CWorkersComp();
	}
	#endregion

	#region Public Methods
        public override int InsertUpdateers_Compensation(RIMS_Base.CWorkersComp Objers_Compensation)
	{
		return mObjErs_Compensation.InsertUpdateers_Compensation(Objers_Compensation);
	}

        public override int Deleteers_Compensation(System.Int32 lPK_Workers_Comp)
	{
        return mObjErs_Compensation.Deleteers_Compensation(lPK_Workers_Comp);
	} 

	public override string ActivateInactivateers_Compensation(string strIDs, int intModifiedBy, bool bIsActive)
	{
        return mObjErs_Compensation.ActivateInactivateers_Compensation(strIDs, intModifiedBy, bIsActive);
	}

        public override List<RIMS_Base.CWorkersComp> Get_Worker_CompensationByID(System.Int32 lPK_Workers_Comp)
	{
        return mObjErs_Compensation.Get_Worker_CompensationByID(lPK_Workers_Comp);
	}

        public override List<RIMS_Base.CWorkersComp> GetAll(Boolean blnIsActive)
	{
        return mObjErs_Compensation.GetAll(blnIsActive);
	}

        public override List<RIMS_Base.CWorkersComp> GetCliamant_ByID(System.Int32 pK_Workers_Comp, System.Decimal pK_Claimant_Id)
        {
            return mObjErs_Compensation.GetCliamant_ByID(pK_Workers_Comp, pK_Claimant_Id);
        }

        public override List<RIMS_Base.CWorkersComp> GetCarrier_ByID(System.Int32 pK_Workers_Comp, System.Decimal pK_Policy_Id)
        {
            return mObjErs_Compensation.GetCarrier_ByID(pK_Workers_Comp, pK_Policy_Id);
        }
	#endregion

    }
}
