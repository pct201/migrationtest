#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CCarrier : RIMS_Base.CCarrier
    {
        #region Private Declarations
        RIMS_Base.CCarrier mObjCarrier;
        #endregion

        #region Constructor
        public CCarrier()
        {
            mObjCarrier = new RIMS_Base.Dal.CCarrier();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateCarrier(RIMS_Base.CCarrier Objier)
        {
            return mObjCarrier.InsertUpdateCarrier(Objier);
        }

        public override int DeleteCarrier(System.Decimal lPK_Carrier)
        {
            return mObjCarrier.DeleteCarrier(lPK_Carrier);
        }

        public override string ActivateInactivCarrier(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjCarrier.ActivateInactivCarrier(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CCarrier> GetCarrierByID(System.Decimal FK_Table_Name, System.String Table_Name)
        {
            return mObjCarrier.GetCarrierByID(FK_Table_Name, Table_Name);
        }

        public override List<RIMS_Base.CCarrier> GetAll()
        {
            return mObjCarrier.GetAll();
        }
        public override System.Data.DataSet GetCarrierLabel()
        {
            return mObjCarrier.GetCarrierLabel();
        }
        #endregion

    }

}