#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPropValues : RIMS_Base.CPropValues
    {
        #region Private Declarations
        RIMS_Base.CPropValues mObjerty_Values;
        #endregion

        #region Constructor
        public CPropValues()
        {
            mObjerty_Values = new RIMS_Base.Dal.CPropValues();
        }
        #endregion

        #region Public Methods
        public override int PropValues_InsertUpdate(RIMS_Base.CPropValues Objerty_Values)
        {
            return mObjerty_Values.PropValues_InsertUpdate(Objerty_Values);
        }

        public override DataSet PropValues_GetById(System.Decimal lPK_Property_Values)
        {
            return mObjerty_Values.PropValues_GetById(lPK_Property_Values);
        }

        public override DataSet GetAll()
        {
            return mObjerty_Values.GetAll();
        }
        #endregion

    }

}