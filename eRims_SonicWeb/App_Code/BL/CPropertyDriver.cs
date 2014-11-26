using System;
using System.Collections.Generic;
using System.Text;

namespace RIMS_Base.Biz
{
    [Serializable]
    public class CPropertyDriver : RIMS_Base.CPropertyDriver
    {
        #region Private Declarations
        RIMS_Base.CPropertyDriver mObjPropertyDriver;
        #endregion

        #region Constructor
        public CPropertyDriver()
        {
            mObjPropertyDriver = new RIMS_Base.Dal.CPropertyDriver();
        }
        #endregion

        #region Public Methods
        public override List<RIMS_Base.CPropertyDriver> GetAll()
        {
            return mObjPropertyDriver.GetAll();
        }
        public override List<RIMS_Base.CPropertyDriver> Get_Search_Data(string m_strColumn, string m_strCriteria)
        {
            return mObjPropertyDriver.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.CPropertyDriver> Get_AdvanceSearch_Data(string LastName, string FirstName, string Address, string City, string State, string Zipcode)
        {
            return mObjPropertyDriver.Get_AdvanceSearch_Data(LastName, FirstName, Address, City, State, Zipcode);
        }
        public override List<RIMS_Base.CPropertyDriver> GetPropertyDriverByID(decimal lPK_PropertyDriver_ID)
        {
            return mObjPropertyDriver.GetPropertyDriverByID(lPK_PropertyDriver_ID);
        }
        public override int PropertyDriver_Delete(string lPK_PropertyDriver_ID)
        {
            return mObjPropertyDriver.PropertyDriver_Delete(lPK_PropertyDriver_ID);
        }
        public override int PropertyDriver_InsertUpdate(RIMS_Base.CPropertyDriver Objerty_Drivers)
        {
            return mObjPropertyDriver.PropertyDriver_InsertUpdate(Objerty_Drivers);
        }        
        #endregion

    }
}
