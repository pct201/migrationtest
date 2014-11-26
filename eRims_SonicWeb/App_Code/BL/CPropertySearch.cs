using System;
using System.Collections.Generic;
using System.Text;

namespace RIMS_Base.Biz
{
    [Serializable]
    public class CPropertySearch:RIMS_Base.CPropertySearch
    {
         #region Private Declarations
        RIMS_Base.CPropertySearch mObjPropertySearch;
        #endregion

        #region Constructor
        public CPropertySearch()
        {
            mObjPropertySearch = new RIMS_Base.Dal.CPropertySearch();
        }
        #endregion

        public override List<RIMS_Base.CPropertySearch> GetAll(RIMS_Base.CPropertySearch objPropertySearch)
        {
            return mObjPropertySearch.GetAll(objPropertySearch);
        }
        public override int DeleteProperty(decimal PK_PropertyID)
        {
            return mObjPropertySearch.DeleteProperty(PK_PropertyID);
        }
    }
}
