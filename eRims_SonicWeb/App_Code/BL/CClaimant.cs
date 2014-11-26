#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CClaimant : RIMS_Base.CClaimant
    {
        #region Private Declarations
        RIMS_Base.CClaimant mObjmant;
        #endregion

        #region Constructor
        public CClaimant()
        {
            mObjmant = new RIMS_Base.Dal.CClaimant();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateClaimant(RIMS_Base.CClaimant Objmant)
        {
            return mObjmant.InsertUpdateClaimant(Objmant);
        }

        public override int DeleteClaimant(System.String lPK_Claimant_Id)
        {
            return mObjmant.DeleteClaimant(lPK_Claimant_Id);
        }

        public override string ActivateInactivateClaimant(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjmant.ActivateInactivateClaimant(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CClaimant> GetClaimantByID(System.Decimal lPK_Claimant_Id)
        {
            return mObjmant.GetClaimantByID(lPK_Claimant_Id);
        }

        public override List<RIMS_Base.CClaimant> GetAll()
        {
            return mObjmant.GetAll();
        }
        public override List<RIMS_Base.CClaimant> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjmant.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.CClaimant> Get_AdvanceSearch_Data(string LastName, string FirstName, string Address, string City, string State, string Zipcode)
        {
            return mObjmant.Get_AdvanceSearch_Data(LastName, FirstName, Address, City, State, Zipcode);
        }

        public override List<RIMS_Base.CClaimant> GetClaimantAutopopulate()
        {
            return mObjmant.GetClaimantAutopopulate();
        }
        #endregion

    }

}