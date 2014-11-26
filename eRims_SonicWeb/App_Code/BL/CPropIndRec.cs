#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropIndRec : RIMS_Base.CPropIndRec
    {
        #region Private Declarations
        RIMS_Base.CPropIndRec mObjvidual_Recommendations;
        #endregion

        #region Constructor
        public CPropIndRec()
        {
            mObjvidual_Recommendations = new RIMS_Base.Dal.CPropIndRec();
        }
        #endregion

        #region Public Methods
        public override int PropIndRec_InsertUpdate(RIMS_Base.CPropIndRec Objvidual_Recommendations)
        {
            return mObjvidual_Recommendations.PropIndRec_InsertUpdate(Objvidual_Recommendations);
        }

        public override int PropIndRec_Delete(System.String lPK_Individual_Recommendations)
        {
            return mObjvidual_Recommendations.PropIndRec_Delete(lPK_Individual_Recommendations);
        }


        public override DataSet PropIndRec_GetByID(System.Decimal lPK_Individual_Recommendations)
        {
            return mObjvidual_Recommendations.PropIndRec_GetByID(lPK_Individual_Recommendations);
        }

        public override DataSet GetAll()
        {
            return mObjvidual_Recommendations.GetAll();
        }
        public override DataSet GetRecBy()
        {
            return mObjvidual_Recommendations.GetRecBy();
        }
        public override DataSet GetAssignedTo()
        {

            return mObjvidual_Recommendations.GetAssignedTo();
        }
        public override DataSet GetRecStatus()
        {
            return mObjvidual_Recommendations.GetRecStatus();
        }
        public override DataSet GetRecType()
        {
            return mObjvidual_Recommendations.GetRecType();
        }
        public override DataSet GetDataAssignTo(decimal UserID)
        {
            return mObjvidual_Recommendations.GetDataAssignTo(UserID);
        }
        public override DataSet PropIndRec_GetByRecID(decimal RecID)
        {
            return mObjvidual_Recommendations.PropIndRec_GetByRecID(RecID);
        }
        #endregion

    }

}