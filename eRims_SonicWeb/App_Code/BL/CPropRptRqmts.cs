#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropRptRqmts : RIMS_Base.CPropRptRqmts
    {
        #region Private Declarations
        RIMS_Base.CPropRptRqmts mObjs_Other_Reporting_Rqmts;
        #endregion

        #region Constructor
        public CPropRptRqmts()
        {
            mObjs_Other_Reporting_Rqmts = new RIMS_Base.Dal.CPropRptRqmts();
        }
        #endregion

        #region Public Methods
        public override int PropRptRqmts_InsertUpdate(RIMS_Base.CPropRptRqmts Objs_Other_Reporting_Rqmts)
        {
            return mObjs_Other_Reporting_Rqmts.PropRptRqmts_InsertUpdate(Objs_Other_Reporting_Rqmts);
        }

        public override int PropRptRqmts_Delete(System.String lPK_Tanks_Other_Reporting_Rqmts)
        {
            return mObjs_Other_Reporting_Rqmts.PropRptRqmts_Delete(lPK_Tanks_Other_Reporting_Rqmts);
        }

        public override DataSet PropRptRqmts_GetByID(System.Decimal lPK_Tanks_Other_Reporting_Rqmts)
        {
            return mObjs_Other_Reporting_Rqmts.PropRptRqmts_GetByID(lPK_Tanks_Other_Reporting_Rqmts);
        }

        public override DataSet GetAll()
        {
            return mObjs_Other_Reporting_Rqmts.GetAll();
        }
        #endregion

    }

}