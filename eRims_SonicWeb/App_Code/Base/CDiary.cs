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
    public abstract class CDiary
    {

        #region Constructor
        public CDiary()
        {
            this._pK_Diary_ID = -1;
            //this._table_Name = string.Empty;
            //this._fK_Table_Name = -1;
            //this._dateOfNoteEntry = DateTime.Now;
            //this._userDiary = string.Empty;
            //this._file_Number = string.Empty;
            //this._note = string.Empty;
            //this._clear = string.Empty;
            //this._updated_By = string.Empty;
            //this._update_Date = DateTime.Now;
            //this._assigned_To = string.Empty;
            //this._diary_Date = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_Diary_ID;
        private System.String _table_Name;
        private System.Decimal _fK_Table_Name;
        private System.DateTime? _dateOfNoteEntry;
        private System.String _userDiary;
        private System.String _file_Number;
        private System.String _note;
        private System.String _clear;
        private System.String _updated_By;
        private System.DateTime? _update_Date;
        private System.String _assigned_To;
        private System.DateTime? _diary_Date;

        private System.String _Claim_Number;
        private System.String _Claim_Type;
        private System.String Assigned_By;
        private System.Int32 _Pk_Assign_Id;
        private System.Decimal _fk_Diary_Id;        
        private System.Int32? _FK_Diary_Module;
        private System.Int32? _FK_LU_Location_ID;
        private System.String _Module_Name;
        private System.String _Location;
        private System.Int32? _FK_LU_Task_Type;
        private System.String _Task_Type;
        private System.String _Region;
        private System.Boolean _isEdit;
        private System.Boolean _isView;
        private System.String _identification_Field;
        private System.Int32? _First_Report_Wizard_ID;

        #endregion

        #region Public Properties
        public System.Decimal Fk_Diary_Id
        {
            get { return _fk_Diary_Id; }
            set { _fk_Diary_Id = value; }
        }
        public System.Int32 Pk_Assign_Id
        {
            get { return _Pk_Assign_Id; }
            set { _Pk_Assign_Id = value; }
        }
        public System.String ClaimNo
        {
            get { return _Claim_Number; }
            set { _Claim_Number = value; }
        }
        public System.String ClaimType
        {
            get { return _Claim_Type; }
            set { _Claim_Type = value; }
        }
        public System.String AssignBy
        {
            get { return Assigned_By; }
            set { Assigned_By = value; }
        }
                                           
        public System.Int32 PK_Diary_ID
        {
            get { return _pK_Diary_ID; }
            set { _pK_Diary_ID = value; }
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

        public System.DateTime? DateOfNoteEntry
        {
            get { return _dateOfNoteEntry; }
            set { _dateOfNoteEntry = value; }
        }

        public System.String UserDiary
        {
            get { return _userDiary; }
            set { _userDiary = value; }
        }

        public System.String File_Number
        {
            get { return _file_Number; }
            set { _file_Number = value; }
        }

        public System.String Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public System.String Clear
        {
            get { return _clear; }
            set { _clear = value; }
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

        public System.String Assigned_To
        {
            get { return _assigned_To; }
            set { _assigned_To = value; }
        }

        public System.DateTime? Diary_Date
        {
            get { return _diary_Date; }
            set { _diary_Date = value; }
        }

        public System.Int32? FK_Diary_Module
        {
            get { return _FK_Diary_Module; }
            set { _FK_Diary_Module = value; }
        }

        public System.Int32? FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }

        public System.String Module_Name
        {
            get { return _Module_Name; }
            set { _Module_Name = value; }
        }

        public System.String Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        public System.Int32? FK_LU_Task_Type
        {
            get { return _FK_LU_Task_Type; }
            set { _FK_LU_Task_Type = value; }
        }

        public System.String Task_Type
        {
            get { return _Task_Type; }
            set { _Task_Type = value; }
        }

        public System.String Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        public bool isEdit
        {
            get { return _isEdit; }
            set { _isEdit = value; }
        }

        public bool isView
        {
            get { return _isView; }
            set { _isView = value; }
        }

        public System.String Identification_Field
        {
            get { return _identification_Field; }
            set { _identification_Field = value; }
        }

        public System.Int32? First_Report_Wizard_ID
        {
            get { return _First_Report_Wizard_ID; }
            set { _First_Report_Wizard_ID = value; }
        }
        
        #endregion

        #region Abstract Methods
        public abstract List<CDiary> GetAll();
        public abstract List<CDiary> GetyByID(System.Decimal lPK_Diary_ID);
        public abstract List<CDiary> GetyByID(System.Decimal lPK_Diary_ID,System.Boolean isView);
        public abstract int InsertUpdateDiary(RIMS_Base.CDiary obj);
        public abstract int DeleteDiary(System.String lPK_Diary_ID);
        public abstract string ActivateInactivateDiary(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract List<CDiary> Search_DiaryData(string ColumnName, string Value, decimal Fk_Table_Name, string Table_Name,string LocationIds);
        public abstract List<CDiary> Search_DiaryData(string ColumnName, string Value, decimal Fk_Table_Name, string Table_Name);
        public abstract DataSet GetClaimToAssign(decimal pK_Security_Id);
        public abstract DataSet GetUserToAssign(System.String m_strCostCenter);
        public abstract int InsertClaimAssign(RIMS_Base.CDiary obj);
        public abstract List<CDiary> Search_DiaryData(string Value, decimal pK_Security_Id);
        public abstract int UpdateClaimAssign(RIMS_Base.CDiary obj);
        public abstract DataSet GetAssignToUser(System.String m_strCostCenter);
        public abstract DataSet GetDiaryLabel();
        public abstract DataSet GetDiaryModule();
        public abstract DataSet GetDiaryIdentificationField(int PK_Diary_Module, int PK_LU_Location_ID, int FK_Table_Name);
        public abstract void UpdateDiaryStatus(string Pk_Diary_Id);        
        #endregion
    }
}
