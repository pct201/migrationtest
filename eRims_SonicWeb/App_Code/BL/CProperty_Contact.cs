using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace RIMS_Base.Biz
{
    [Serializable]
    public class CProperty_Contact : RIMS_Base.CProperty_Contact
    {
        #region Private Declarations
        RIMS_Base.CProperty_Contact mObjerty_Contacts;
        #endregion

        #region Constructor
        public CProperty_Contact()
        {
            mObjerty_Contacts = new RIMS_Base.Dal.CProperty_Contact();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateP_Contacts(RIMS_Base.CProperty_Contact Objerty_Contacts)
        {
            return mObjerty_Contacts.InsertUpdateP_Contacts(Objerty_Contacts);
        }

        public override int DeleteP_Contacts(System.Decimal lPK_Property_Contacts)
        {
            return mObjerty_Contacts.DeleteP_Contacts(lPK_Property_Contacts);
        }

        public override DataSet GetP_ContactsByID(System.Decimal lPK_Property_Contacts)
        {
            return mObjerty_Contacts.GetP_ContactsByID(lPK_Property_Contacts);
        }

        public override DataSet GetAll()
        {
            return mObjerty_Contacts.GetAll();
        }
        #endregion

    }
}
