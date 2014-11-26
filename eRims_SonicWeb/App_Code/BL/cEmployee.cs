#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class cEmployee : RIMS_Base.cEmployee
    {
        #region Private Declarations
        RIMS_Base.cEmployee mObjEmployee;
        #endregion

        #region Constructor
        public cEmployee()
        {
            mObjEmployee = new RIMS_Base.Dal.cEmployee();
        }
        #endregion

        #region Public Methods
        public override int Employee_InsertUpdate(RIMS_Base.cEmployee Objoyee)
        {
            return mObjEmployee.Employee_InsertUpdate(Objoyee);
        }

        public override int Employee_Delete(System.String lPK_Employee_ID)
        {
            return mObjEmployee.Employee_Delete(lPK_Employee_ID);
        }

        public override string ActivateInactivateoyee(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjEmployee.ActivateInactivateoyee(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.cEmployee> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjEmployee.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.cEmployee> Get_Search_Data_State(string m_strColumn, string m_strCriteria)
        {
            return mObjEmployee.Get_Search_Data_State(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.cEmployee> GetAll()
        {
            return mObjEmployee.GetAll();
        }
        public override List<RIMS_Base.cEmployee> GetAll_State()
        {
            return mObjEmployee.GetAll_State();
        }
        public override List<RIMS_Base.cEmployee> Get_AdvanceSearch_Data(string LastName, string FirstName, string Address, string City, string State, string Zipcode, decimal Entity)
        {
            return mObjEmployee.Get_AdvanceSearch_Data(LastName, FirstName, Address, City, State, Zipcode, Entity);
        }       
        public override List<RIMS_Base.cEmployee> GetEmployeeByID(decimal lPK_Claimant_Id)
        {
            return mObjEmployee.GetEmployeeByID(lPK_Claimant_Id);
        }     
        public override List<RIMS_Base.cEmployee> GetMaritalStatus()
        {
            return mObjEmployee.GetMaritalStatus();
        }
        public override List<RIMS_Base.cEmployee> GetJobClassfication()
        {
            return mObjEmployee.GetJobClassfication();
        }
        public override List<RIMS_Base.cEmployee> GetLicenseType()
        {
            return mObjEmployee.GetLicenseType();
        }

        public override List<RIMS_Base.cEmployee> GetAutoPopulateEmployeeId()
        {
            return mObjEmployee.GetAutoPopulateEmployeeId();
        }

        #endregion

    }

}