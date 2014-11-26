#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class cSubrogation : RIMS_Base.cSubrogation
    {
        #region Private Declarations
        RIMS_Base.cSubrogation mObjSubrogation;
        #endregion

        #region Constructor
        public cSubrogation()
        {
            mObjSubrogation = new RIMS_Base.Dal.cSubrogation();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateSubrogation(RIMS_Base.cSubrogation ObjSubrogation)
        {
            return mObjSubrogation.InsertUpdateSubrogation(ObjSubrogation);
        }

        public override int DeleteSubrogation(System.String lPK_Subrogation)
        {
            return mObjSubrogation.DeleteSubrogation(lPK_Subrogation);
        }

        public override string ActivateInactivateSubrogation(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjSubrogation.ActivateInactivateSubrogation(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.cSubrogation> GetSubrogationByID(System.Int32 lPK_Subrogation)
        {
            return mObjSubrogation.GetSubrogationByID(lPK_Subrogation);
        }
        public override List<RIMS_Base.cSubrogation> GetAll(Decimal Fk_Table_Name, string Table_Name)
        {
            return mObjSubrogation.GetAll(Fk_Table_Name, Table_Name);
        }
        public override List<RIMS_Base.cSubrogation> SearchSubrogationData(string FieldName, string FieldVal, decimal Fk_Table_Name, string Table_Name)
        {
            return mObjSubrogation.SearchSubrogationData(FieldName, FieldVal, Fk_Table_Name, Table_Name);
        }
        public override List<RIMS_Base.cSubrogation> GetProvider(System.Decimal Pk_ProviderID)
        {
            return mObjSubrogation.GetProvider(Pk_ProviderID);
        }
        public override System.Data.DataSet GetSubrogationLabel()
        {
            return mObjSubrogation.GetSubrogationLabel();
        }
        #endregion

    }

}
