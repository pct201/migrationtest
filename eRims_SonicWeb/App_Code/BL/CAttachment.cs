#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CAttachment : RIMS_Base.CAttachment
    {
        #region Private Declarations
        RIMS_Base.CAttachment mObjChment;
        #endregion

        #region Constructor
        public CAttachment()
        {
            mObjChment = new RIMS_Base.Dal.CAttachment();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateAttachment(RIMS_Base.CAttachment Objchment)
        {
            return mObjChment.InsertUpdateAttachment(Objchment);
        }

        public override int DeleteAttachment(System.String lPK_Attachment_Id)
        {
            return mObjChment.DeleteAttachment(lPK_Attachment_Id);
        }

        public override string ActivateInactivateAttachment(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjChment.ActivateInactivateAttachment(strIDs, intModifiedBy, bIsActive);
        }

        public override RIMS_Base.CAttachment GetchmentByID(System.Decimal lPK_Attachment_Id)
        {
            return mObjChment.GetchmentByID(lPK_Attachment_Id);
        }

        public override List<RIMS_Base.CAttachment> GetAll(Int32 pK_Attachment_Id, Int32 Foreign_Key, System.String Table_Name)
        {
            return mObjChment.GetAll(pK_Attachment_Id, Foreign_Key,Table_Name);
        }
        public override List<RIMS_Base.CAttachment> GetAllAttachmentGroup(System.String lPK_Attachment_Id, System.String Table_Name)
        {
            return mObjChment.GetAllAttachmentGroup(lPK_Attachment_Id, Table_Name);
        }
        public override List<RIMS_Base.CAttachment> GetAttachMentMail(System.String Attachment_Ids)
        {
            return mObjChment.GetAttachMentMail(Attachment_Ids);
        }
        #endregion

    }

}