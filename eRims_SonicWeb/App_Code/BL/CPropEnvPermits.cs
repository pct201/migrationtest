#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropEnvPermits : RIMS_Base.CPropEnvPermits
    {
        #region Private Declarations
        RIMS_Base.CPropEnvPermits mObjr_Environmental_Permits;
        #endregion

        #region Constructor
        public CPropEnvPermits()
        {
            mObjr_Environmental_Permits = new RIMS_Base.Dal.CPropEnvPermits();
        }
        #endregion

        #region Public Methods
        public override int PropEnvPermits_InsertUpdate(RIMS_Base.CPropEnvPermits Objr_Environmental_Permits)
        {
            return mObjr_Environmental_Permits.PropEnvPermits_InsertUpdate(Objr_Environmental_Permits);
        }

        public override DataSet PropEnvPermits_GetByID(System.Decimal lPK_Other_Environmental_Permits)
        {
            return mObjr_Environmental_Permits.PropEnvPermits_GetByID(lPK_Other_Environmental_Permits);
        }

        public override DataSet GetAll()
        {
            return mObjr_Environmental_Permits.GetAll();
        }
        public override int PropEnvPermits_Delete(System.String lPK_Other_Environmental_Permits)
        {
            return mObjr_Environmental_Permits.PropEnvPermits_Delete(lPK_Other_Environmental_Permits);
        }

        public override DataSet GetOEType()
        {
            return mObjr_Environmental_Permits.GetOEType();
        }

        public override DataSet PropEnvPermits_GetByEnvID(decimal EnvID)
        {
            return mObjr_Environmental_Permits.PropEnvPermits_GetByEnvID(EnvID);
        }

        #endregion

    }

}