#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropMain : RIMS_Base.CPropMain
    {
        #region Private Declarations
        RIMS_Base.CPropMain mObjerty_Maintenance;
        #endregion

        #region Constructor
        public CPropMain()
        {
            mObjerty_Maintenance = new RIMS_Base.Dal.CPropMain();
        }
        #endregion

        #region Public Methods
        public override int PropMain_InsertUpdate(RIMS_Base.CPropMain Objerty_Maintenance)
        {
            return mObjerty_Maintenance.PropMain_InsertUpdate(Objerty_Maintenance);
        }

        public override int PropMain_Delete(System.String lPK_Property_Maintenance_ID)
        {
            return mObjerty_Maintenance.PropMain_Delete(lPK_Property_Maintenance_ID);
        }

        public override string ActivateInactivateerty_Maintenance(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjerty_Maintenance.ActivateInactivateerty_Maintenance(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CPropMain> PropMain_GetByID(System.Decimal lPK_Property_Maintenance_ID)
        {
            return mObjerty_Maintenance.PropMain_GetByID(lPK_Property_Maintenance_ID);
        }

        public override List<RIMS_Base.CPropMain> GetAll()
        {
            return mObjerty_Maintenance.GetAll();
        }
        public override List<RIMS_Base.CPropMain> Get_Search_Data(string m_strColumn, string m_strCriteria)
        {
            return mObjerty_Maintenance.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.CPropMain> GetMType()
        {
            return mObjerty_Maintenance.GetMType();
        }
        public override List<RIMS_Base.CPropMain> GetPO()
        {
            return mObjerty_Maintenance.GetPO();
        }
        public override List<RIMS_Base.CPropMain> GetSeverity()
        {
            return mObjerty_Maintenance.GetSeverity();
        }
        #endregion

    }

}