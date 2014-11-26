#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CFCIPolicy
    {

        #region Constructor
        public CFCIPolicy()
        {
            this._pK_Policy_Id = 0;
            //this._fK_Policy_Type = -1;
            //this._policy_Number = string.Empty;
            //this._carrier = string.Empty;
            //this._underwriter = string.Empty;
            //this._policy_Begin_Date = DateTime.Now;
            //this._policy_Expiration_Date = DateTime.Now;
            //this._policy_Year = -1;
            //this._fK_Entity = -1;
            //this._annual_Premium = -1;
            //this._surplus_Lines_Fees = -1;
            //this._deductible = string.Empty;
            //this._deductible_Amount = -1;
            //this._coverage_Form = string.Empty;
            //this._per_Occurrence_Limit = -1;
            //this._aggregate_Limit = -1;
            //this._layered_Program = string.Empty;
            //this._fK_Layer = -1;
            //this._underlying_Limit = -1;
            //this._quota_Share = string.Empty;

            this._update_Date = DateTime.Now;
            //this._share_Precentage = -1;
            //this._share_Limit = -1;
            //this._retroactive = string.Empty;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_Policy_Id;
        private System.Decimal _fK_Policy_Type;
        private System.String _policy_Number;
        private System.String _carrier;
        private System.String _underwriter;
        private System.DateTime? _policy_Begin_Date;
        private System.DateTime? _policy_Expiration_Date;
        private System.Int32? _policy_Year;
        private System.Decimal? _fK_Entity;
        private System.Decimal? _annual_Premium;
        private System.Decimal? _surplus_Lines_Fees;
        private System.String _deductible;
        private System.Decimal? _deductible_Amount;
        private System.String _coverage_Form;
        private System.Decimal? _per_Occurrence_Limit;
        private System.Decimal? _aggregate_Limit;
        private System.String _layered_Program;
        private System.Decimal? _fK_Layer;
        private System.Decimal? _underlying_Limit;
        private System.String _quota_Share;
        private System.Decimal _updated_By;
        private System.DateTime _update_Date;
        private System.Decimal? _share_Precentage;
        private System.Decimal? _share_Limit;
        private System.String _retroactive;
        private System.Decimal? _ProgramID;
        private System.String _TPA;
        private System.Decimal? _Store_Deductible;
        private System.String _Financial_Security_Required;
        private System.Decimal? _FK_Financial_Security_Type;
        private System.String _Policy_Notes;
        private System.Decimal? _Original_Amount;
        private System.DateTime? _Original_Amount_Date;
        private System.Decimal? _Change_Amount_1;
        private System.DateTime? _Change_Amount_1_Date;
        private System.Decimal? _Change_Amount_2;
        private System.DateTime? _Change_Amount_2_Date;
        private System.Decimal? _Change_Amount_3;
        private System.DateTime? _Change_Amount_3_Date;
        private System.Decimal? _Change_Amount_4;
        private System.DateTime? _Change_Amount_4_Date;
        #endregion

        #region Public Properties
        public System.Int32 PK_Policy_Id
        {
            get { return _pK_Policy_Id; }
            set { _pK_Policy_Id = value; }
        }

        public System.Decimal FK_Policy_Type
        {
            get { return _fK_Policy_Type; }
            set { _fK_Policy_Type = value; }
        }

        public System.String Policy_Number
        {
            get { return _policy_Number; }
            set { _policy_Number = value; }
        }

        public System.String Carrier
        {
            get { return _carrier; }
            set { _carrier = value; }
        }

        public System.String Underwriter
        {
            get { return _underwriter; }
            set { _underwriter = value; }
        }

        public System.DateTime? Policy_Begin_Date
        {
            get { return _policy_Begin_Date; }
            set { _policy_Begin_Date = value; }
        }

        public System.DateTime? Policy_Expiration_Date
        {
            get { return _policy_Expiration_Date; }
            set { _policy_Expiration_Date = value; }
        }

        public System.Int32? Policy_Year
        {
            get { return _policy_Year; }
            set { _policy_Year = value; }
        }

        public System.Decimal? FK_Entity
        {
            get { return _fK_Entity; }
            set { _fK_Entity = value; }
        }

        public System.Decimal? Annual_Premium
        {
            get { return _annual_Premium; }
            set { _annual_Premium = value; }
        }

        public System.Decimal? Surplus_Lines_Fees
        {
            get { return _surplus_Lines_Fees; }
            set { _surplus_Lines_Fees = value; }
        }

        public System.String Deductible
        {
            get { return _deductible; }
            set { _deductible = value; }
        }

        public System.Decimal? Deductible_Amount
        {
            get { return _deductible_Amount; }
            set { _deductible_Amount = value; }
        }

        public System.String Coverage_Form
        {
            get { return _coverage_Form; }
            set { _coverage_Form = value; }
        }

        public System.Decimal? Per_Occurrence_Limit
        {
            get { return _per_Occurrence_Limit; }
            set { _per_Occurrence_Limit = value; }
        }

        public System.Decimal? Aggregate_Limit
        {
            get { return _aggregate_Limit; }
            set { _aggregate_Limit = value; }
        }

        public System.String Layered_Program
        {
            get { return _layered_Program; }
            set { _layered_Program = value; }
        }

        public System.Decimal? FK_Layer
        {
            get { return _fK_Layer; }
            set { _fK_Layer = value; }
        }

        public System.Decimal? Underlying_Limit
        {
            get { return _underlying_Limit; }
            set { _underlying_Limit = value; }
        }

        public System.String Quota_Share
        {
            get { return _quota_Share; }
            set { _quota_Share = value; }
        }

        public System.Decimal Updated_By
        {
            get { return _updated_By; }
            set { _updated_By = value; }
        }

        public System.DateTime Update_Date
        {
            get { return _update_Date; }
            set { _update_Date = value; }
        }

        public System.Decimal? Share_Precentage
        {
            get { return _share_Precentage; }
            set { _share_Precentage = value; }
        }

        public System.Decimal? Share_Limit
        {
            get { return _share_Limit; }
            set { _share_Limit = value; }
        }

        public System.String Retroactive
        {
            get { return _retroactive; }
            set { _retroactive = value; }
        }

        /// <summary> 
        /// Gets or sets the ProgramID value.
        /// </summary>
        public System.Decimal? ProgramID
        {
	        get { return _ProgramID; }
	        set { _ProgramID = value; }
        }


        /// <summary> 
        /// Gets or sets the TPA value.
        /// </summary>
        public System.String TPA
        {
	        get { return _TPA; }
	        set { _TPA = value; }
        }


        /// <summary> 
        /// Gets or sets the Store_Deductible value.
        /// </summary>
        public System.Decimal? Store_Deductible
        {
	        get { return _Store_Deductible; }
	        set { _Store_Deductible = value; }
        }


        /// <summary> 
        /// Gets or sets the Financial_Security_Required value.
        /// </summary>
        public System.String Financial_Security_Required
        {
	        get { return _Financial_Security_Required; }
	        set { _Financial_Security_Required = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Financial_Security_Type value.
        /// </summary>
        public System.Decimal? FK_Financial_Security_Type
        {
	        get { return _FK_Financial_Security_Type; }
	        set { _FK_Financial_Security_Type = value; }
        }

        
        /// <summary> 
        /// Gets or sets the Policy_Notes value.
        /// </summary>
        public System.String Policy_Notes
        {
            get { return _Policy_Notes; }
            set { _Policy_Notes = value; }
        }

        /// <summary> 
        /// Gets or sets the Original_Amount value.
        /// </summary>
        public System.Decimal? Original_Amount
        {
	        get { return _Original_Amount; }
	        set { _Original_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Original_Amount_Date value.
        /// </summary>
        public System.DateTime? Original_Amount_Date
        {
	        get { return _Original_Amount_Date; }
	        set { _Original_Amount_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Change_Amount_1 value.
        /// </summary>
        public System.Decimal? Change_Amount_1
        {
	        get { return _Change_Amount_1; }
	        set { _Change_Amount_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Change_Amount_1_Date value.
        /// </summary>
        public System.DateTime? Change_Amount_1_Date
        {
	        get { return _Change_Amount_1_Date; }
	        set { _Change_Amount_1_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Change_Amount_2 value.
        /// </summary>
        public System.Decimal? Change_Amount_2
        {
	        get { return _Change_Amount_2; }
	        set { _Change_Amount_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Change_Amount_2_Date value.
        /// </summary>
        public System.DateTime? Change_Amount_2_Date
        {
	        get { return _Change_Amount_2_Date; }
	        set { _Change_Amount_2_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Change_Amount_3 value.
        /// </summary>
        public System.Decimal? Change_Amount_3
        {
	        get { return _Change_Amount_3; }
	        set { _Change_Amount_3 = value; }
        }


        /// <summary> 
        /// Gets or sets the Change_Amount_3_Date value.
        /// </summary>
        public System.DateTime? Change_Amount_3_Date
        {
	        get { return _Change_Amount_3_Date; }
	        set { _Change_Amount_3_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Change_Amount_4 value.
        /// </summary>
        public System.Decimal? Change_Amount_4
        {
	        get { return _Change_Amount_4; }
	        set { _Change_Amount_4 = value; }
        }


        /// <summary> 
        /// Gets or sets the Change_Amount_4_Date value.
        /// </summary>
        public System.DateTime? Change_Amount_4_Date
        {
            get { return _Change_Amount_4_Date; }
            set { _Change_Amount_4_Date = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract DataSet GetAll();
        public abstract DataSet Policy_GetByID(System.Decimal lPK_Policy_Id);
        public abstract int Policy_InsertUpdate(RIMS_Base.CFCIPolicy obj);
        public abstract int Policy_Delete(System.Decimal lPK_Policy_Id);
        public abstract DataSet GetPolicySearch(System.Decimal FK_Policy_Type, System.String Carrier, System.Int32 Policy_Year, Decimal pK_Security_Id, Decimal ProgramID, Decimal LocationID);
        public abstract DataSet GetPolicy_Popup_Search(System.String m_strColumn, System.String m_strCriteria);
        public abstract int DeletePolicy(System.Decimal PK_Policy_ID);
        public abstract DataSet GetPolicyLayer();
        public abstract int PolicyDuplicateCheck(RIMS_Base.CFCIPolicy obj);
        public abstract int CheckSharedPercentagePolicy(RIMS_Base.CFCIPolicy obj);
        #endregion

    }

}
