#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropRec : RIMS_Base.CPropRec
    {
        #region Private Declarations
        RIMS_Base.CPropRec mObjerty_Recommendations;
        #endregion

        #region Constructor
        public CPropRec()
        {
            mObjerty_Recommendations = new RIMS_Base.Dal.CPropRec();
        }
        #endregion

        #region Public Methods
        public override int PropRecommend_InsertUpdate(RIMS_Base.CPropRec Objerty_Recommendations)
        {
            return mObjerty_Recommendations.PropRecommend_InsertUpdate(Objerty_Recommendations);
        }


        public override DataSet PropRecommend_ById(System.Decimal Pk_Property_Cope)
        {
            return mObjerty_Recommendations.PropRecommend_ById( Pk_Property_Cope);
        }

        public override DataSet GetAll()
        {
            return mObjerty_Recommendations.GetAll();
        }
        #endregion

    }

}