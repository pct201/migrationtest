#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class cSettlement : RIMS_Base.cSettlement
    {
        #region Private Declarations
        RIMS_Base.cSettlement mObjsettlement;
        #endregion

        #region Constructor
        public cSettlement()
        {
            mObjsettlement = new RIMS_Base.Dal.cSettlement();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_settlement(RIMS_Base.cSettlement Objlement)
        {
            return mObjsettlement.InsertUpdate_settlement(Objlement);
        }

        public override int Delete_settlement(System.Decimal lPk_Settlement)
        {
            return mObjsettlement.Delete_settlement(lPk_Settlement);
        }

        public override string ActivateInactivate_settlement(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjsettlement.ActivateInactivate_settlement(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.cSettlement> GetsettlementByID(System.Decimal lPk_Settlement)
        {
            return mObjsettlement.GetsettlementByID(lPk_Settlement);
        }

        public override List<RIMS_Base.cSettlement> GetAll(Boolean blnIsActive)
        {
            return mObjsettlement.GetAll(blnIsActive);
        }
        public override System.Data.DataSet GetSettlementLabel()
        {
            return mObjsettlement.GetSettlementLabel();
        }
        #endregion

    }

}