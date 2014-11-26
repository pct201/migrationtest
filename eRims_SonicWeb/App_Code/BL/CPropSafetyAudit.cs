#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropSafetyAudit : RIMS_Base.CPropSafetyAudit
    {
        #region Private Declarations
        RIMS_Base.CPropSafetyAudit mObjty_Audit;
        #endregion

        #region Constructor
        public CPropSafetyAudit()
        {
            mObjty_Audit = new RIMS_Base.Dal.CPropSafetyAudit();
        }
        #endregion

        #region Public Methods
        public override int PropSafetyAudit_InsertUpdate(RIMS_Base.CPropSafetyAudit Objty_Audit)
        {
            return mObjty_Audit.PropSafetyAudit_InsertUpdate(Objty_Audit);
        }

        public override int PropSafetyAudit__Delete(System.String lPK_Safety_Audit)
        {
            return mObjty_Audit.PropSafetyAudit__Delete(lPK_Safety_Audit);
        }

        public override DataSet PropSafetyAudit_GetByID(System.Decimal lPK_Safety_Audit)
        {
            return mObjty_Audit.PropSafetyAudit_GetByID(lPK_Safety_Audit);
        }

        public override DataSet GetAll( )
        {
            return mObjty_Audit.GetAll();
        }
        public override DataSet PropSafetyAudit_BYCOPEId(System.Decimal PK_COPE_Id)
        {
            return mObjty_Audit.PropSafetyAudit_BYCOPEId(PK_COPE_Id);
        }
        #endregion

    }

}