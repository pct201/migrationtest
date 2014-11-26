#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropEnvWaste : RIMS_Base.CPropEnvWaste
    {
        #region Private Declarations
        RIMS_Base.CPropEnvWaste mObjronmental_Waste;
        #endregion

        #region Constructor
        public CPropEnvWaste()
        {
            mObjronmental_Waste = new RIMS_Base.Dal.CPropEnvWaste();
        }
        #endregion

        #region Public Methods
        public override int PropEnvWaste_InsertUpdate(RIMS_Base.CPropEnvWaste Objronmental_Waste)
        {
            return mObjronmental_Waste.PropEnvWaste_InsertUpdate(Objronmental_Waste);
        }

        public override int PropEnvWaste_Delete(System.String lPK_Environmental_Waste)
        {
            return mObjronmental_Waste.PropEnvWaste_Delete(lPK_Environmental_Waste);
        }


        public override DataSet GetPropEnvWasteByID(System.Decimal lPK_Environmental_Waste)
        {
            return mObjronmental_Waste.GetPropEnvWasteByID(lPK_Environmental_Waste);
        }

        public override DataSet GetAll()
        {
            return mObjronmental_Waste.GetAll();
        }

        public override DataSet GetOEType()
        {
            return mObjronmental_Waste.GetOEType();
        }

        public override DataSet PropEnvWaste_GetByEnvID(decimal EnvID)
        {
            return mObjronmental_Waste.PropEnvWaste_GetByEnvID(EnvID);
        }
        #endregion

    }

}