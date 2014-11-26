#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropMonitoring : RIMS_Base.CPropMonitoring
    {
        #region Private Declarations
        RIMS_Base.CPropMonitoring mObjerty_Monitoring;
        #endregion

        #region Constructor
        public CPropMonitoring()
        {
            mObjerty_Monitoring = new RIMS_Base.Dal.CPropMonitoring();
        }
        #endregion

        #region Public Methods
        public override int PropMonitoring_InsertUpdate(RIMS_Base.CPropMonitoring Objerty_Monitoring)
        {
            return mObjerty_Monitoring.PropMonitoring_InsertUpdate(Objerty_Monitoring);
        }

        public override int PropMonitoring_Delete(System.String lPK_Property_Monitoring)
        {
            return mObjerty_Monitoring.PropMonitoring_Delete(lPK_Property_Monitoring);
        }

        public override DataSet PropMonitoring_GetByID(System.Decimal lPK_Property_Monitoring)
        {
            return mObjerty_Monitoring.PropMonitoring_GetByID(lPK_Property_Monitoring);
        }

        public override DataSet GetAll()
        {
            return mObjerty_Monitoring.GetAll();
        }
        #endregion

    }

}