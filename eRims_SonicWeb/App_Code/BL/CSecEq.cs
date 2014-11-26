#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CSecEq : RIMS_Base.CSecEq
    {
        #region Private Declarations
        RIMS_Base.CSecEq mObjrity_Equipment;
        #endregion

        #region Constructor
        public CSecEq()
        {
            mObjrity_Equipment = new RIMS_Base.Dal.CSecEq();
        }
        #endregion

        #region Public Methods
        public override int Sec_Equipment_InsertUpdate(RIMS_Base.CSecEq Objrity_Equipment)
        {
            return mObjrity_Equipment.Sec_Equipment_InsertUpdate(Objrity_Equipment);
        }

        public override int Sec_Equipment_Delete(System.String lPK_Security_Equipment_ID)
        {
            return mObjrity_Equipment.Sec_Equipment_Delete(lPK_Security_Equipment_ID);
        }

        public override string ActivateInactivaterity_Equipment(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjrity_Equipment.ActivateInactivaterity_Equipment(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CSecEq> GetSec_EquipmentByID(System.Decimal lPK_Security_Equipment_ID)
        {
            return mObjrity_Equipment.GetSec_EquipmentByID(lPK_Security_Equipment_ID);
        }

        public override List<RIMS_Base.CSecEq> GetAll()
        {
            return mObjrity_Equipment.GetAll();
        }
        public override List<RIMS_Base.CSecEq> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjrity_Equipment.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.CSecEq> GetBSA()
        {
            return mObjrity_Equipment.GetBSA();
        }
        public override List<RIMS_Base.CSecEq> GetEqType()
        {
            return mObjrity_Equipment.GetEqType();
        }
        public override List<RIMS_Base.CSecEq> GetLocation()
        {
            return mObjrity_Equipment.GetLocation();
        }
        public override List<RIMS_Base.CSecEq> GetColor()
        {
            return mObjrity_Equipment.GetColor();
        }
        public override List<RIMS_Base.CSecEq> GetUsage()
        {
            return mObjrity_Equipment.GetUsage();
        }
        #endregion

    }

}