#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CAIGInfo
    {

        #region Constructor
        public CAIGInfo()
        {
            this._pK_AIG_Info_ID = -1;
            this._aIGRM_Contract_Number = string.Empty;
            //this._aIGRM_Start_Date = DateTime.Now;
            //this._aIGRM_End_Date = DateTime.Now;
            this._updated_By = string.Empty;
            this._update_Date = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_AIG_Info_ID;
        private System.String _aIGRM_Contract_Number;
        private System.DateTime? _aIGRM_Start_Date;
        private System.DateTime? _aIGRM_End_Date;
        private System.String _updated_By;
        private System.DateTime _update_Date;
        #endregion

        #region Public Properties
        public System.Int32 PK_AIG_Info_ID
        {
            get { return _pK_AIG_Info_ID; }
            set { _pK_AIG_Info_ID = value; }
        }

        public System.String AIGRM_Contract_Number
        {
            get { return _aIGRM_Contract_Number; }
            set { _aIGRM_Contract_Number = value; }
        }

        public System.DateTime? AIGRM_Start_Date
        {
            get { return _aIGRM_Start_Date; }
            set { _aIGRM_Start_Date = value; }
        }

        public System.DateTime? AIGRM_End_Date
        {
            get { return _aIGRM_End_Date; }
            set { _aIGRM_End_Date = value; }
        }

        public System.String Updated_By
        {
            get { return _updated_By; }
            set { _updated_By = value; }
        }

        public System.DateTime Update_Date
        {
            get { return _update_Date; }
            set { _update_Date = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<CAIGInfo> GetAll();
        public abstract List<CAIGInfo> AIGInfo_GetByID(System.Decimal lPK_AIG_Info_ID);
        public abstract int AIGInfo_InsertUpdate(RIMS_Base.CAIGInfo obj);
        public abstract int AIG_Info_Delete(System.String lPK_AIG_Info_ID);
        public abstract string ActivateInactivateInfo(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract List<RIMS_Base.CAIGInfo> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
        #endregion

    }

}
