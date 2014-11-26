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
    public abstract class CCarrier
    {

        #region Constructor
        public CCarrier()
        {
            this._pK_Carrier = -1;
            //this._table_Name = string.Empty;
            //this._fK_Table_Name = -1;
            //this._claims_Made_Indicator = string.Empty; ;
            //this._defense_Medical_Eval_PTD;
            //this._employer_Legal_Expense_To_Date = -1;
            //this._fK_Employer_Payroll_Table = -1;
            //this._employer_Liability = -1;
            //this._employer_Liability_PTD = -1;
            //this._expert_Witness_PTD = -1;
            //this._funeral_Expense_PTD = -1;
            //this._hospital_Cost_PTD = -1;
            //this._independent_Subcontractor_No = string.Empty;
            //this._fK_Major_Class_Code = -1;
            //this._producer_Code = -1;
            //this._product_Liability_Recovery = -1;
            //this._product_Name = string.Empty;
            //this._fK_Loss_Conditions_Act = -1;
            //this._fK_Loss_Conditions_Recovery = -1;
            //this._fK_Loss_Coverage_Code = -1;
            //this._lump_Sum_Remarriage_Payment = -1;
            //this._incurred_Loss = -1;
            //this._other_Benefit_Offset = string.Empty;
            //this._other_Medical_PTD = -1;
            //this._other_Voc_Rehab_PTD = -1;
            //this._penalties_PTD = -1;
            //this._pension_Indem_PTVD = -1;
            //this._pension_Reserved = -1;
            //this._pension_Offset = string.Empty;
            //this._fK_State_Garage = -1;
            //this._fK_Injury_Code = -1;
            //this._fK_Property_Damage = -1;
            //this._recovery_Current_Month = -1;
            //this._recovery_To_Date = -1;
            //this._reserve_Type_Code = -1;
            //this._single_Sum_Paid_Date = DateTime.Now;
            //this._single_Sum_Paid = -1;
            //this._sS_Benefit_Offset = string.Empty;
            //this._sS_Other_Amount = -1;
            //this._special_Fund_Offset = string.Empty;
            //this._symbol = -1;
            //this._fK_State_Tax = -1;
            //this._tPA_Internal_Claim_Code = string.Empty;
            //this._temp_Indem_Incurred = -1;
            //this._temp_Indem_No_Weeks = -1;
            //this._t_E_Current_Month = -1;
            //this._t_E_To_Date = -1;
            //this._total_Gross_Incurred = -1;
            //this._total_Incurred_Voc_Rehab = -1;
            //this._total_Incurred_Voc_Rehab_Edu = -1;
            //this._total_Incurred_Voc_Rehab_Eval = -1;
            //this._total_Incurred_Voc_Rehab_Main = -1;
            //this._total_Payments_Phys = -1;
            //this._trans_Type = -1;
            //this._unemp_Benefit_Offset = string.Empty;
            //this._unique_Occur_Claim = string.Empty;
            //this._lump_Sum_Settlement = -1;
            //this._other_Recovery = -1;
            //this._other_Weekly_Pymnts = -1;
            //this._updated_By = string.Empty;
            //this._update_Date = DateTime.Now;
            //this._wC_Cat_Number = -1;
            //this._wC_Indemnity_Payment = -1;
            //this._indemnity_Incurred = -1;
            //this._indemnity_Paid_Current = -1;
            //this._indemnity_PTD = -1;
            //this._medical_Incurred = -1;
            //this._medical_Paid_Current = -1;
            //this._medical_PTD = -1;
            //this._expense_Incurred = -1;
            //this._expense_Paid_Current = -1;
            //this._expense_PTD = -1;
            //this._controverted_Case = string.Empty;
            //this._deductible_Indicator = string.Empty;
            //this._aIG_Policy_Prefix = string.Empty;
            //this._fK_AIG_Policy_Number = -1;
            //this._fK_Loss_Conditions_Loss = -1;
            //this._fK_Loss_Conditions_Settlement = -1;
            //this._fK_Settlement_Method = -1;
            //this._legal_Representation = string.Empty;
            //this._fK_Attorney_Form = -1;
            //this._deductible_Reimbursement = -1;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_Carrier;
        private System.String _table_Name;
        private System.Decimal _fK_Table_Name;
        private System.String _claims_Made_Indicator;
        private System.Decimal? _defense_Medical_Eval_PTD;
        private System.Decimal? _employer_Legal_Expense_To_Date;
        private System.Decimal? _fK_Employer_Payroll_Table;
        private System.Decimal? _employer_Liability;
        private System.Decimal? _employer_Liability_PTD;
        private System.Decimal? _expert_Witness_PTD;
        private System.Decimal? _funeral_Expense_PTD;
        private System.Decimal? _hospital_Cost_PTD;
        private System.String _independent_Subcontractor_No;
        private System.Decimal? _fK_Major_Class_Code;
        private System.Decimal? _producer_Code;
        private System.Decimal? _product_Liability_Recovery;
        private System.String _product_Name;
        private System.Decimal? _fK_Loss_Conditions_Act;
        private System.Decimal? _fK_Loss_Conditions_Recovery;
        private System.Decimal? _fK_Loss_Coverage_Code;
        private System.Decimal? _lump_Sum_Remarriage_Payment;
        private System.Decimal? _incurred_Loss;
        private System.String _other_Benefit_Offset;
        private System.Decimal? _other_Medical_PTD;
        private System.Decimal? _other_Voc_Rehab_PTD;
        private System.Decimal? _penalties_PTD;
        private System.Decimal? _pension_Indem_PTVD;
        private System.Decimal? _pension_Reserved;
        private System.String _pension_Offset;
        private System.Decimal? _fK_State_Garage;
        private System.Decimal? _fK_Injury_Code;
        private System.Decimal? _fK_Property_Damage;
        private System.Decimal? _recovery_Current_Month;
        private System.Decimal? _recovery_To_Date;
        private System.Decimal? _reserve_Type_Code;
        private System.DateTime? _single_Sum_Paid_Date;
        private System.Decimal? _single_Sum_Paid;
        private System.String _sS_Benefit_Offset;
        private System.Decimal? _sS_Other_Amount;
        private System.String _special_Fund_Offset;
        private System.Decimal? _symbol;
        private System.Decimal? _fK_State_Tax;
        private System.String _tPA_Internal_Claim_Code;
        private System.Decimal? _temp_Indem_Incurred;
        private System.Decimal? _temp_Indem_No_Weeks;
        private System.Decimal? _t_E_Current_Month;
        private System.Decimal? _t_E_To_Date;
        private System.Decimal? _total_Gross_Incurred;
        private System.Decimal? _total_Incurred_Voc_Rehab;
        private System.Decimal? _total_Incurred_Voc_Rehab_Edu;
        private System.Decimal? _total_Incurred_Voc_Rehab_Eval;
        private System.Decimal? _total_Incurred_Voc_Rehab_Main;
        private System.Decimal? _total_Payments_Phys;
        private System.Decimal? _trans_Type;
        private System.String _unemp_Benefit_Offset;
        private System.String _unique_Occur_Claim;
        private System.Decimal? _lump_Sum_Settlement;
        private System.Decimal? _other_Recovery;
        private System.Decimal? _other_Weekly_Pymnts;
        private System.String _updated_By;
        private System.DateTime? _update_Date;
        private System.Decimal? _wC_Cat_Number;
        private System.Decimal? _wC_Indemnity_Payment;
        private System.Decimal? _indemnity_Incurred;
        private System.Decimal? _indemnity_Paid_Current;
        private System.Decimal? _indemnity_PTD;
        private System.Decimal? _medical_Incurred;
        private System.Decimal? _medical_Paid_Current;
        private System.Decimal? _medical_PTD;
        private System.Decimal? _expense_Incurred;
        private System.Decimal? _expense_Paid_Current;
        private System.Decimal? _expense_PTD;
        private System.String _controverted_Case;
        private System.String _deductible_Indicator;
        private System.String _aIG_Policy_Prefix;
        private System.Decimal? _fK_AIG_Policy_Number;
        private System.Decimal? _fK_Loss_Conditions_Loss;
        private System.Decimal? _fK_Loss_Conditions_Settlement;
        private System.Decimal? _fK_Settlement_Method;
        private System.String _legal_Representation;
        private System.Decimal? _fK_Attorney_Form;
        private System.Decimal? _deductible_Reimbursement;
        private System.String _insurer_Reimbursed_Benifi_Payable_Claimant;
        #endregion

        #region Public Properties

        public System.Int32 PK_Carrier
        {
            get { return _pK_Carrier; }
            set { _pK_Carrier = value; }
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

        public System.String Claims_Made_Indicator
        {
            get { return _claims_Made_Indicator; }
            set { _claims_Made_Indicator = value; }
        }

        public System.Decimal? Defense_Medical_Eval_PTD
        {
            get { return _defense_Medical_Eval_PTD; }
            set { _defense_Medical_Eval_PTD = value; }
        }

        public System.Decimal? Employer_Legal_Expense_To_Date
        {
            get { return _employer_Legal_Expense_To_Date; }
            set { _employer_Legal_Expense_To_Date = value; }
        }

        public System.Decimal? FK_Employer_Payroll_Table
        {
            get { return _fK_Employer_Payroll_Table; }
            set { _fK_Employer_Payroll_Table = value; }
        }

        public System.Decimal? Employer_Liability
        {
            get { return _employer_Liability; }
            set { _employer_Liability = value; }
        }

        public System.Decimal? Employer_Liability_PTD
        {
            get { return _employer_Liability_PTD; }
            set { _employer_Liability_PTD = value; }
        }

        public System.Decimal? Expert_Witness_PTD
        {
            get { return _expert_Witness_PTD; }
            set { _expert_Witness_PTD = value; }
        }

        public System.Decimal? Funeral_Expense_PTD
        {
            get { return _funeral_Expense_PTD; }
            set { _funeral_Expense_PTD = value; }
        }

        public System.Decimal? Hospital_Cost_PTD
        {
            get { return _hospital_Cost_PTD; }
            set { _hospital_Cost_PTD = value; }
        }

        public System.String Independent_Subcontractor_No
        {
            get { return _independent_Subcontractor_No; }
            set { _independent_Subcontractor_No = value; }
        }

        public System.Decimal? FK_Major_Class_Code
        {
            get { return _fK_Major_Class_Code; }
            set { _fK_Major_Class_Code = value; }
        }

        public System.Decimal? Producer_Code
        {
            get { return _producer_Code; }
            set { _producer_Code = value; }
        }

        public System.Decimal? Product_Liability_Recovery
        {
            get { return _product_Liability_Recovery; }
            set { _product_Liability_Recovery = value; }
        }

        public System.String Product_Name
        {
            get { return _product_Name; }
            set { _product_Name = value; }
        }

        public System.Decimal? FK_Loss_Conditions_Act
        {
            get { return _fK_Loss_Conditions_Act; }
            set { _fK_Loss_Conditions_Act = value; }
        }

        public System.Decimal? FK_Loss_Conditions_Recovery
        {
            get { return _fK_Loss_Conditions_Recovery; }
            set { _fK_Loss_Conditions_Recovery = value; }
        }

        public System.Decimal? FK_Loss_Coverage_Code
        {
            get { return _fK_Loss_Coverage_Code; }
            set { _fK_Loss_Coverage_Code = value; }
        }

        public System.Decimal? Lump_Sum_Remarriage_Payment
        {
            get { return _lump_Sum_Remarriage_Payment; }
            set { _lump_Sum_Remarriage_Payment = value; }
        }

        public System.Decimal? Incurred_Loss
        {
            get { return _incurred_Loss; }
            set { _incurred_Loss = value; }
        }

        public System.String Other_Benefit_Offset
        {
            get { return _other_Benefit_Offset; }
            set { _other_Benefit_Offset = value; }
        }

        public System.Decimal? Other_Medical_PTD
        {
            get { return _other_Medical_PTD; }
            set { _other_Medical_PTD = value; }
        }

        public System.Decimal? Other_Voc_Rehab_PTD
        {
            get { return _other_Voc_Rehab_PTD; }
            set { _other_Voc_Rehab_PTD = value; }
        }

        public System.Decimal? Penalties_PTD
        {
            get { return _penalties_PTD; }
            set { _penalties_PTD = value; }
        }

        public System.Decimal? Pension_Indem_PTVD
        {
            get { return _pension_Indem_PTVD; }
            set { _pension_Indem_PTVD = value; }
        }

        public System.Decimal? Pension_Reserved
        {
            get { return _pension_Reserved; }
            set { _pension_Reserved = value; }
        }

        public System.String Pension_Offset
        {
            get { return _pension_Offset; }
            set { _pension_Offset = value; }
        }

        public System.Decimal? FK_State_Garage
        {
            get { return _fK_State_Garage; }
            set { _fK_State_Garage = value; }
        }

        public System.Decimal? FK_Injury_Code
        {
            get { return _fK_Injury_Code; }
            set { _fK_Injury_Code = value; }
        }

        public System.Decimal? FK_Property_Damage
        {
            get { return _fK_Property_Damage; }
            set { _fK_Property_Damage = value; }
        }

        public System.Decimal? Recovery_Current_Month
        {
            get { return _recovery_Current_Month; }
            set { _recovery_Current_Month = value; }
        }

        public System.Decimal? Recovery_To_Date
        {
            get { return _recovery_To_Date; }
            set { _recovery_To_Date = value; }
        }

        public System.Decimal? Reserve_Type_Code
        {
            get { return _reserve_Type_Code; }
            set { _reserve_Type_Code = value; }
        }

        public System.DateTime? Single_Sum_Paid_Date
        {
            get { return _single_Sum_Paid_Date; }
            set { _single_Sum_Paid_Date = value; }
        }

        public System.Decimal? Single_Sum_Paid
        {
            get { return _single_Sum_Paid; }
            set { _single_Sum_Paid = value; }
        }

        public System.String SS_Benefit_Offset
        {
            get { return _sS_Benefit_Offset; }
            set { _sS_Benefit_Offset = value; }
        }

        public System.Decimal? SS_Other_Amount
        {
            get { return _sS_Other_Amount; }
            set { _sS_Other_Amount = value; }
        }

        public System.String Special_Fund_Offset
        {
            get { return _special_Fund_Offset; }
            set { _special_Fund_Offset = value; }
        }

        public System.Decimal? Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public System.Decimal? FK_State_Tax
        {
            get { return _fK_State_Tax; }
            set { _fK_State_Tax = value; }
        }

        public System.String TPA_Internal_Claim_Code
        {
            get { return _tPA_Internal_Claim_Code; }
            set { _tPA_Internal_Claim_Code = value; }
        }

        public System.Decimal? Temp_Indem_Incurred
        {
            get { return _temp_Indem_Incurred; }
            set { _temp_Indem_Incurred = value; }
        }

        public System.Decimal? Temp_Indem_No_Weeks
        {
            get { return _temp_Indem_No_Weeks; }
            set { _temp_Indem_No_Weeks = value; }
        }

        public System.Decimal? T_E_Current_Month
        {
            get { return _t_E_Current_Month; }
            set { _t_E_Current_Month = value; }
        }

        public System.Decimal? T_E_To_Date
        {
            get { return _t_E_To_Date; }
            set { _t_E_To_Date = value; }
        }

        public System.Decimal? Total_Gross_Incurred
        {
            get { return _total_Gross_Incurred; }
            set { _total_Gross_Incurred = value; }
        }

        public System.Decimal? Total_Incurred_Voc_Rehab
        {
            get { return _total_Incurred_Voc_Rehab; }
            set { _total_Incurred_Voc_Rehab = value; }
        }

        public System.Decimal? Total_Incurred_Voc_Rehab_Edu
        {
            get { return _total_Incurred_Voc_Rehab_Edu; }
            set { _total_Incurred_Voc_Rehab_Edu = value; }
        }

        public System.Decimal? Total_Incurred_Voc_Rehab_Eval
        {
            get { return _total_Incurred_Voc_Rehab_Eval; }
            set { _total_Incurred_Voc_Rehab_Eval = value; }
        }

        public System.Decimal? Total_Incurred_Voc_Rehab_Main
        {
            get { return _total_Incurred_Voc_Rehab_Main; }
            set { _total_Incurred_Voc_Rehab_Main = value; }
        }

        public System.Decimal? Total_Payments_Phys
        {
            get { return _total_Payments_Phys; }
            set { _total_Payments_Phys = value; }
        }

        public System.Decimal? Trans_Type
        {
            get { return _trans_Type; }
            set { _trans_Type = value; }
        }

        public System.String Unemp_Benefit_Offset
        {
            get { return _unemp_Benefit_Offset; }
            set { _unemp_Benefit_Offset = value; }
        }

        public System.String Unique_Occur_Claim
        {
            get { return _unique_Occur_Claim; }
            set { _unique_Occur_Claim = value; }
        }

        public System.Decimal? Lump_Sum_Settlement
        {
            get { return _lump_Sum_Settlement; }
            set { _lump_Sum_Settlement = value; }
        }

        public System.Decimal? Other_Recovery
        {
            get { return _other_Recovery; }
            set { _other_Recovery = value; }
        }

        public System.Decimal? Other_Weekly_Pymnts
        {
            get { return _other_Weekly_Pymnts; }
            set { _other_Weekly_Pymnts = value; }
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

        public System.Decimal? WC_Cat_Number
        {
            get { return _wC_Cat_Number; }
            set { _wC_Cat_Number = value; }
        }

        public System.Decimal? WC_Indemnity_Payment
        {
            get { return _wC_Indemnity_Payment; }
            set { _wC_Indemnity_Payment = value; }
        }

        public System.Decimal? Indemnity_Incurred
        {
            get { return _indemnity_Incurred; }
            set { _indemnity_Incurred = value; }
        }

        public System.Decimal? Indemnity_Paid_Current
        {
            get { return _indemnity_Paid_Current; }
            set { _indemnity_Paid_Current = value; }
        }

        public System.Decimal? Indemnity_PTD
        {
            get { return _indemnity_PTD; }
            set { _indemnity_PTD = value; }
        }

        public System.Decimal? Medical_Incurred
        {
            get { return _medical_Incurred; }
            set { _medical_Incurred = value; }
        }

        public System.Decimal? Medical_Paid_Current
        {
            get { return _medical_Paid_Current; }
            set { _medical_Paid_Current = value; }
        }

        public System.Decimal? Medical_PTD
        {
            get { return _medical_PTD; }
            set { _medical_PTD = value; }
        }

        public System.Decimal? Expense_Incurred
        {
            get { return _expense_Incurred; }
            set { _expense_Incurred = value; }
        }

        public System.Decimal? Expense_Paid_Current
        {
            get { return _expense_Paid_Current; }
            set { _expense_Paid_Current = value; }
        }

        public System.Decimal? Expense_PTD
        {
            get { return _expense_PTD; }
            set { _expense_PTD = value; }
        }

        public System.String Controverted_Case
        {
            get { return _controverted_Case; }
            set { _controverted_Case = value; }
        }

        public System.String Deductible_Indicator
        {
            get { return _deductible_Indicator; }
            set { _deductible_Indicator = value; }
        }

        public System.String AIG_Policy_Prefix
        {
            get { return _aIG_Policy_Prefix; }
            set { _aIG_Policy_Prefix = value; }
        }

        public System.Decimal? FK_AIG_Policy_Number
        {
            get { return _fK_AIG_Policy_Number; }
            set { _fK_AIG_Policy_Number = value; }
        }

        public System.Decimal? FK_Loss_Conditions_Loss
        {
            get { return _fK_Loss_Conditions_Loss; }
            set { _fK_Loss_Conditions_Loss = value; }
        }

        public System.Decimal? FK_Loss_Conditions_Settlement
        {
            get { return _fK_Loss_Conditions_Settlement; }
            set { _fK_Loss_Conditions_Settlement = value; }
        }

        public System.Decimal? FK_Settlement_Method
        {
            get { return _fK_Settlement_Method; }
            set { _fK_Settlement_Method = value; }
        }

        public System.String Legal_Representation
        {
            get { return _legal_Representation; }
            set { _legal_Representation = value; }
        }

        public System.Decimal? FK_Attorney_Form
        {
            get { return _fK_Attorney_Form; }
            set { _fK_Attorney_Form = value; }
        }

        public System.Decimal? Deductible_Reimbursement
        {
            get { return _deductible_Reimbursement; }
            set { _deductible_Reimbursement = value; }
        }

        public System.String Insurer_Reimbursed_Benifi_Payable_Claimant
        {
            get { return _insurer_Reimbursed_Benifi_Payable_Claimant; }
            set { _insurer_Reimbursed_Benifi_Payable_Claimant = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<CCarrier> GetAll();
        public abstract List<CCarrier> GetCarrierByID(System.Decimal FK_Table_Name, System.String Table_Name);
        public abstract int InsertUpdateCarrier(RIMS_Base.CCarrier obj);
        public abstract int DeleteCarrier(System.Decimal lPK_Carrier);
        public abstract string ActivateInactivCarrier(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract DataSet GetCarrierLabel();
        #endregion

    }

}
