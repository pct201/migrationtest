#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropEnvTanks : RIMS_Base.CPropEnvTanks
    {
        #region Private Declarations
        RIMS_Base.CPropEnvTanks mObjronmental_Tanks;
        #endregion

        #region Constructor
        public CPropEnvTanks()
        {
            mObjronmental_Tanks = new RIMS_Base.Dal.CPropEnvTanks();
        }
        #endregion

        #region Public Methods
        public override int PropEnvTanks_InsertUpdate(RIMS_Base.CPropEnvTanks Objronmental_Tanks)
        {
            return mObjronmental_Tanks.PropEnvTanks_InsertUpdate(Objronmental_Tanks);
        }

        public override int PropEnvTanks_Delete(System.String lPK_Environmental_Tanks)
        {
            return mObjronmental_Tanks.PropEnvTanks_Delete(lPK_Environmental_Tanks);
        }

        public override DataSet PropEnvTanks_GetByID(System.Decimal lPK_Environmental_Tanks)
        {
            return mObjronmental_Tanks.PropEnvTanks_GetByID(lPK_Environmental_Tanks);
        }

        public override DataSet GetAll()
        {
            return mObjronmental_Tanks.GetAll();
        }
        public override DataSet GetAllCombo()
        {
            return mObjronmental_Tanks.GetAllCombo();
        }
        public override DataSet GetOtherReportingReq(decimal Pk_Environmental_Tanks)
        {
            return mObjronmental_Tanks.GetOtherReportingReq(Pk_Environmental_Tanks);
        }
        #endregion

    }

}