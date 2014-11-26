#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CCheckRegister : RIMS_Base.CCheckRegister
    {
        #region Private Declarations
        RIMS_Base.CCheckRegister mObjK_Register;
        #endregion

        #region Constructor
        public CCheckRegister()
        {
            mObjK_Register = new RIMS_Base.Dal.CCheckRegister();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateCheckRegister(RIMS_Base.CCheckRegister Objk_Register)
        {
            return mObjK_Register.InsertUpdateCheckRegister(Objk_Register);
        }

        public override int DeleteCheckRegister(System.Decimal lPK_Check_Register)
        {
            return mObjK_Register.DeleteCheckRegister(lPK_Check_Register);
        }

        public override string ActivateInactivCheckRegister(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjK_Register.ActivateInactivCheckRegister(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CCheckRegister> GetCheckRegisterByID(System.Decimal Fk_Table_Name, System.String Table_Name)
        {
            return mObjK_Register.GetCheckRegisterByID(Fk_Table_Name, Table_Name);
        }

        public override List<RIMS_Base.CCheckRegister> GetAll()
        {
            return mObjK_Register.GetAll();
        }
        #endregion

    }

}