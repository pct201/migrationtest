#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class Diary : RIMS_Base.CDiary
    {
        #region Private Declarations
        RIMS_Base.CDiary mObjDiary;
        #endregion

        #region Constructor
        public Diary()
        {
            mObjDiary = new RIMS_Base.Dal.CDiary();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateDiary(RIMS_Base.CDiary ObjDiary)
        {
            return mObjDiary.InsertUpdateDiary(ObjDiary);
        }

        public override int DeleteDiary(System.String lPK_Diary_ID)
        {
            return mObjDiary.DeleteDiary(lPK_Diary_ID);
        }

        public override string ActivateInactivateDiary(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjDiary.ActivateInactivateDiary(strIDs, intModifiedBy, bIsActive);
        }

        public override List<CDiary> GetyByID(System.Decimal lPK_Diary_ID)
        {
            return mObjDiary.GetyByID(lPK_Diary_ID);
        }

        public override List<CDiary> GetyByID(System.Decimal lPK_Diary_ID,System.Boolean isView)
        {
            return mObjDiary.GetyByID(lPK_Diary_ID,isView);
        }

        public override List<RIMS_Base.CDiary> GetAll()
        {
            return mObjDiary.GetAll();
        }

        public override List<CDiary> Search_DiaryData(string ColumnName, string Value, decimal Fk_Table_Name, string Table_Name,string LocationIds)
        {
            return mObjDiary.Search_DiaryData(ColumnName, Value, Fk_Table_Name, Table_Name, LocationIds);
        }

        public override List<CDiary> Search_DiaryData(string ColumnName, string Value, decimal Fk_Table_Name, string Table_Name)
        {
            return mObjDiary.Search_DiaryData(ColumnName, Value, Fk_Table_Name, Table_Name);
        }

        public override DataSet GetClaimToAssign(decimal pK_Security_Id)
        {
            return mObjDiary.GetClaimToAssign(pK_Security_Id);
        }
        public override DataSet GetUserToAssign(System.String m_strCostCenter)
        {
            return mObjDiary.GetUserToAssign(m_strCostCenter);
        }
        public override int InsertClaimAssign(RIMS_Base.CDiary ObjDiary)
        {
            return mObjDiary.InsertClaimAssign(ObjDiary);
        }
        public override List<CDiary> Search_DiaryData(string Value, decimal pK_Security_Id)
        {
            return mObjDiary.Search_DiaryData(Value, pK_Security_Id);
        }
        public override int UpdateClaimAssign(RIMS_Base.CDiary obj)
        {
            return mObjDiary.UpdateClaimAssign(obj);
        }
        public override DataSet GetAssignToUser(string m_strCostCenter)
        {
            return mObjDiary.GetAssignToUser(m_strCostCenter);
        }
        public override DataSet GetDiaryLabel()
        {
            return mObjDiary.GetDiaryLabel();
        }
        public override DataSet GetDiaryModule()
        {
            return mObjDiary.GetDiaryModule();  
        }
        public override DataSet GetDiaryIdentificationField(int PK_Diary_Module, int PK_LU_Location_ID,int FK_Table_Name)
        {
            return mObjDiary.GetDiaryIdentificationField(PK_Diary_Module, PK_LU_Location_ID,FK_Table_Name);                  
        }
        public override void UpdateDiaryStatus(string Pk_Diary_Id)
        {
            mObjDiary.UpdateDiaryStatus(Pk_Diary_Id);
        }
        
        #endregion
    }
}