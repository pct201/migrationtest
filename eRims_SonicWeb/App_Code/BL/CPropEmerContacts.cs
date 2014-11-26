#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropEmerContacts : RIMS_Base.CPropEmerContacts
    {
        #region Private Declarations
        RIMS_Base.CPropEmerContacts mObjgency_Contacts;
        #endregion

        #region Constructor
        public CPropEmerContacts()
        {
            mObjgency_Contacts = new RIMS_Base.Dal.CPropEmerContacts();
        }
        #endregion

        #region Public Methods
        public override int PropEmerContacts_InsertUpdate(RIMS_Base.CPropEmerContacts Objgency_Contacts)
        {
            return mObjgency_Contacts.PropEmerContacts_InsertUpdate(Objgency_Contacts);
        }

        public override int PropEmerContacts_Delete(System.String lPK_Emergency_Contacts)
        {
            return mObjgency_Contacts.PropEmerContacts_Delete(lPK_Emergency_Contacts);
        }


        public override DataSet PropEmerContacts_GetByID(System.Decimal lPK_Emergency_Contacts)
        {
            return mObjgency_Contacts.PropEmerContacts_GetByID(lPK_Emergency_Contacts);
        }

        public override DataSet GetAll( )
        {
            return mObjgency_Contacts.GetAll();
        }
        public override DataSet EmerContacts_ByContactID(System.Decimal PK_Contacts)
        {
            return mObjgency_Contacts.EmerContacts_ByContactID(PK_Contacts);
        }
        public override int EContacts_Master_InsertUpdate(RIMS_Base.CPropEmerContacts Objgency_Contacts)
        {
            return mObjgency_Contacts.EContacts_Master_InsertUpdate(Objgency_Contacts);
        }
        public override DataSet ContactId_ByCOPE(System.Decimal m_dCOPEId)
        {
            return mObjgency_Contacts.ContactId_ByCOPE(m_dCOPEId);
        }
        #endregion

    }

}