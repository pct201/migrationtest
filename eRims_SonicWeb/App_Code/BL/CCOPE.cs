#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CCOPE : RIMS_Base.CCOPE
    {
        #region Private Declarations
        RIMS_Base.CCOPE mObjerty_COPE;
        #endregion

        #region Constructor
        public CCOPE()
        {
            mObjerty_COPE = new RIMS_Base.Dal.CCOPE();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_COPE(RIMS_Base.CCOPE Objerty_COPE)
        {
            return mObjerty_COPE.InsertUpdate_COPE(Objerty_COPE);
        }

        public override int Delete_COPE(System.Decimal lPK_Property_COPE)
        {
            return mObjerty_COPE.Delete_COPE(lPK_Property_COPE);
        }

        

        public override DataSet Get_COPEByID(System.Decimal lPK_Property_COPE)
        {
            return mObjerty_COPE.Get_COPEByID(lPK_Property_COPE);
        }

        public override List<RIMS_Base.CCOPE> GetAll( )
        {
            return mObjerty_COPE.GetAll();
        }
        #endregion

    }

}