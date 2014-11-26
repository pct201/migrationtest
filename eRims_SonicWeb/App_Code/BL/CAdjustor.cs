#region Includes
using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CAdjustor : RIMS_Base.CAdjustor
    {
        #region Private Declarations
        RIMS_Base.CAdjustor mObjStor_Notes;
        #endregion

        #region Constructor
        public CAdjustor()
        {
            mObjStor_Notes = new RIMS_Base.Dal.CAdjustor();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateAdjustor(RIMS_Base.CAdjustor Objstor_Notes)
        {
            return mObjStor_Notes.InsertUpdateAdjustor(Objstor_Notes);
        }
        public override int DeleteAdjustor(System.String lPK_Adjustor_Notes_ID)
        {
            return mObjStor_Notes.DeleteAdjustor(lPK_Adjustor_Notes_ID);
        }
        public override string ActivateInactivAdjustor(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjStor_Notes.ActivateInactivAdjustor(strIDs, intModifiedBy, bIsActive);
        }
        public override List<RIMS_Base.CAdjustor> GetAdjustorByID(System.Int32 lPK_Adjustor_Notes_ID)
        {
            return mObjStor_Notes.GetAdjustorByID(lPK_Adjustor_Notes_ID);
        }
        public override List<RIMS_Base.CAdjustor> GetAll()
        {
            return mObjStor_Notes.GetAll();
        }
        public override List<RIMS_Base.CAdjustor> SearchAdjustorData(string FieldName, string FieldVal, decimal Fk_Table_Name, string Table_Name)
        {
            return mObjStor_Notes.SearchAdjustorData(FieldName, FieldVal, Fk_Table_Name, Table_Name);
        }
        public override System.Data.DataSet GetAdjustorLabel()
        {
            return mObjStor_Notes.GetAdjustorLabel();
        }
        #endregion

    }

}