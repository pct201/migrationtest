#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropUtilContacts : RIMS_Base.CPropUtilContacts
    {
        #region Private Declarations
        RIMS_Base.CPropUtilContacts mObjity_Contacts;
        #endregion

        #region Constructor
        public CPropUtilContacts()
        {
            mObjity_Contacts = new RIMS_Base.Dal.CPropUtilContacts();
        }
        #endregion

        #region Public Methods
        public override int PropUtilContacts_InsertUpdate(RIMS_Base.CPropUtilContacts Objity_Contacts)
        {
            return mObjity_Contacts.PropUtilContacts_InsertUpdate(Objity_Contacts);
        }

        public override int PropUtilContacts_Delete(System.String lPK_Utility_Contacts)
        {
            return mObjity_Contacts.PropUtilContacts_Delete(lPK_Utility_Contacts);
        }

        public override DataSet PropUtilContacts_GetByID(System.Decimal lPK_Utility_Contacts)
        {
            return mObjity_Contacts.PropUtilContacts_GetByID(lPK_Utility_Contacts);
        }

        public override DataSet GetAll( )
        {
            return mObjity_Contacts.GetAll();
        }
        public override DataSet UtilContacts_ByContactID(System.Decimal PK_Contacts)
        {
            return mObjity_Contacts.UtilContacts_ByContactID(PK_Contacts);
        }
        #endregion

    }

}