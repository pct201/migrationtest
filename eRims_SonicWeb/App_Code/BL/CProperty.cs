#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CProperty : RIMS_Base.CProperty
    {
        #region Private Declarations
        RIMS_Base.CProperty mObjerty;
        #endregion

        #region Constructor
        public CProperty()
        {
            mObjerty = new RIMS_Base.Dal.CProperty();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateProperty(RIMS_Base.CProperty Objerty)
        {
            return mObjerty.InsertUpdateProperty(Objerty);
        }

        public override int DeleteProperty(System.String lPK_Property_ID)
        {
            return mObjerty.DeleteProperty(lPK_Property_ID);
        }

        public override string ActivateInactivateProperty(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjerty.ActivateInactivateProperty(strIDs, intModifiedBy, bIsActive);
        }

        public override DataSet GetPropertyByID(System.Decimal lPK_Property_ID)
        {
            return mObjerty.GetPropertyByID(lPK_Property_ID);
        }

        public override List<RIMS_Base.CProperty> GetAll()
        {
            return mObjerty.GetAll();
        }
        public override List<RIMS_Base.CProperty> GetPropertyGridData()
        {
            return mObjerty.GetPropertyGridData();
        }
        public override List<RIMS_Base.CProperty> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjerty.Get_Search_Data(m_strColumn, m_strCriteria);    
        }
        #endregion

    }

}