#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropEnvironmental : RIMS_Base.CPropEnvironmental
    {
        #region Private Declarations
        RIMS_Base.CPropEnvironmental mObjerty_Environmental;
        #endregion

        #region Constructor
        public CPropEnvironmental()
        {
            mObjerty_Environmental = new RIMS_Base.Dal.CPropEnvironmental();
        }
        #endregion

        #region Public Methods
        public override int PropEnvironmental_InsertUpdate(RIMS_Base.CPropEnvironmental Objerty_Environmental)
        {
            return mObjerty_Environmental.PropEnvironmental_InsertUpdate(Objerty_Environmental);
        }


        public override DataSet PropEnvironmental_GetByID(System.Decimal lPK_Property_Environmental)
        {
            return mObjerty_Environmental.PropEnvironmental_GetByID(lPK_Property_Environmental);
        }

        public override DataSet GetAll( )
        {
            return mObjerty_Environmental.GetAll();
        }
        #endregion

    }

}