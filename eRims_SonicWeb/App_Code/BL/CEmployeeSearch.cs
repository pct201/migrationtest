#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{
    [Serializable]

    public class CEmployeeSearch : RIMS_Base.CEmployeeSearch
    {
        #region Private Declarations
        RIMS_Base.CEmployeeSearch mObjEmpSearch;
        #endregion

        #region Constructor
        public CEmployeeSearch()
        {
            mObjEmpSearch = new RIMS_Base.Dal.CEmployeeSearch();
        }
        #endregion

        public override List<RIMS_Base.CEmployeeSearch> GetAll(RIMS_Base.CEmployeeSearch objEmpSearch, decimal pK_Security_Id)
        {
            return mObjEmpSearch.GetAll(objEmpSearch, pK_Security_Id);
        }
        public override int DeleteClaim(string ClaimType, decimal PK_ClaimID)
        {
            return mObjEmpSearch.DeleteClaim(ClaimType, PK_ClaimID);
        }
    }
}
