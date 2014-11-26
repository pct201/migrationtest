#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CAdjustor
    {

        #region Constructor
        public CAdjustor()
        {
            this._pK_Adjustor_Notes_ID = -1;
            //this._table_Name = string.Empty;
            //this._fK_Table_Name = -1;
            //this._activity_Date = DateTime.Now;
            //this._date_Of_Note = DateTime.Now;
            //this._author_Of_Note = string.Empty;
            //this._note_Type = string.Empty;
            //this._update_By = string.Empty;
            //this._notes = string.Empty;
            //this._updated_By = string.Empty;
            //this._update_Date = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_Adjustor_Notes_ID;
        private System.String _table_Name;
        private System.Decimal _fK_Table_Name;
        private System.DateTime? _activity_Date;
        private System.DateTime? _date_Of_Note;
        private System.String _author_Of_Note;
        private System.String _note_Type;
        private System.String _update_By;
        private System.String _notes;
        private System.String _updated_By;
        private System.DateTime? _update_Date;
        #endregion

        #region Public Properties
        public System.Int32 PK_Adjustor_Notes_ID
        {
            get { return _pK_Adjustor_Notes_ID; }
            set { _pK_Adjustor_Notes_ID = value; }
        }

        public System.String Table_Name
        {
            get { return _table_Name; }
            set { _table_Name = value; }
        }

        public System.Decimal FK_Table_Name
        {
            get { return _fK_Table_Name; }
            set { _fK_Table_Name = value; }
        }

        public System.DateTime? Activity_Date
        {
            get { return _activity_Date; }
            set { _activity_Date = value; }
        }

        public System.DateTime? Date_Of_Note
        {
            get { return _date_Of_Note; }
            set { _date_Of_Note = value; }
        }

        public System.String Author_Of_Note
        {
            get { return _author_Of_Note; }
            set { _author_Of_Note = value; }
        }

        public System.String Note_Type
        {
            get { return _note_Type; }
            set { _note_Type = value; }
        }

        public System.String Update_By
        {
            get { return _update_By; }
            set { _update_By = value; }
        }

        public System.String Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public System.String Updated_By
        {
            get { return _updated_By; }
            set { _updated_By = value; }
        }

        public System.DateTime? Update_Date
        {
            get { return _update_Date; }
            set { _update_Date = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<CAdjustor> GetAll();
        public abstract List<CAdjustor> GetAdjustorByID(System.Int32 lPK_Adjustor_Notes_ID);
        public abstract int InsertUpdateAdjustor(RIMS_Base.CAdjustor obj);
        public abstract int DeleteAdjustor(System.String lPK_Adjustor_Notes_ID);
        public abstract string ActivateInactivAdjustor(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract List<CAdjustor> SearchAdjustorData(string FieldName, string FieldVal, Decimal Fk_Table_Name, string Table_Name);
        public abstract DataSet GetAdjustorLabel();
        #endregion

    }

}
