#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CVendor : RIMS_Base.CVendor
    {
        #region Private Declarations
        RIMS_Base.CVendor mObjCVendor;
        #endregion

        #region Constructor
        public CVendor()
        {
            mObjCVendor = new RIMS_Base.Dal.CVendor();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateVendor(RIMS_Base.CVendor ObjCVendor)
        {
            return mObjCVendor.InsertUpdateVendor(ObjCVendor);
        }

        public override int DeleteVendor(System.String lPK_Vendor_ID)
        {
            return mObjCVendor.DeleteVendor(lPK_Vendor_ID);
        }

        public override string ActivateInactivateVendor(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjCVendor.ActivateInactivateVendor(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CVendor> GetorByID(System.Decimal lPK_Vendor_ID)
        {
            return mObjCVendor.GetorByID(lPK_Vendor_ID);
        }

        public override List<RIMS_Base.CVendor> GetAll()
        {
            return mObjCVendor.GetAll();
        }
        public override List<RIMS_Base.CVendor> GetAllVendorType()
        {
            return mObjCVendor.GetAllVendorType();
        }

        public override List<RIMS_Base.CVendor> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjCVendor.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        #endregion

    }

}