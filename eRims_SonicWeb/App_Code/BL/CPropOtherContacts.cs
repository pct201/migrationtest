#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropOtherContacts : RIMS_Base.CPropOtherContacts
    {
        #region Private Declarations
        RIMS_Base.CPropOtherContacts mObjr_Contacts;
        #endregion

        #region Constructor
        public CPropOtherContacts()
        {
            mObjr_Contacts = new RIMS_Base.Dal.CPropOtherContacts();
        }
        #endregion

        #region Public Methods
        public override int PropOtherContacts_InsertUpdate(RIMS_Base.CPropOtherContacts Objr_Contacts)
        {
            return mObjr_Contacts.PropOtherContacts_InsertUpdate(Objr_Contacts);
        }

        public override int PropOtherContacts_Delete(System.String lPK_Other_Contacts)
        {
            return mObjr_Contacts.PropOtherContacts_Delete(lPK_Other_Contacts);
        }


        public override DataSet PropOtherContacts_GetByID(System.Decimal lPK_Other_Contacts)
        {
            return mObjr_Contacts.PropOtherContacts_GetByID(lPK_Other_Contacts);
        }

        public override DataSet GetAll( )
        {
            return mObjr_Contacts.GetAll();
        }
        public override DataSet OtherContacts_ByContactID(System.Decimal PK_Contacts)
        {
            return mObjr_Contacts.OtherContacts_ByContactID(PK_Contacts);
        }
        #endregion

    }

}