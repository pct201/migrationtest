#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CEmployeeTraining : RIMS_Base.CEmployeeTraining
    {
        #region Private Declarations
        RIMS_Base.CEmployeeTraining mObjoyee_Training;
        #endregion

        #region Constructor
        public CEmployeeTraining()
        {
            mObjoyee_Training = new RIMS_Base.Dal.CEmployeeTraining();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_Employee_Training(RIMS_Base.CEmployeeTraining Objoyee_Training)
        {
            return mObjoyee_Training.InsertUpdate_Employee_Training(Objoyee_Training);
        }

        public override int DeleteEmployee_Training(System.String lPK_Employee_Training_Id)
        {
            return mObjoyee_Training.DeleteEmployee_Training(lPK_Employee_Training_Id);
        }

        public override string ActivateInactivateEmployee_Training(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjoyee_Training.ActivateInactivateEmployee_Training(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CEmployeeTraining> GetEmployee_TrainingByID(System.Decimal lPK_Employee_Training_Id)
        {
            return mObjoyee_Training.GetEmployee_TrainingByID(lPK_Employee_Training_Id);
        }

        public override List<RIMS_Base.CEmployeeTraining> GetAll()
        {
            return mObjoyee_Training.GetAll();
        }
        public override List<RIMS_Base.CEmployeeTraining> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjoyee_Training.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.CEmployeeTraining> GetTrainingGrade()
        {
            return mObjoyee_Training.GetTrainingGrade();
        }
        public override List<RIMS_Base.CEmployeeTraining> GetTrainingStatus()
        {
            return mObjoyee_Training.GetTrainingStatus();
        }
        public override List<RIMS_Base.CEmployeeTraining> GetTrainingType()
        {
            return mObjoyee_Training.GetTrainingType();
        }
        #endregion

    }

}