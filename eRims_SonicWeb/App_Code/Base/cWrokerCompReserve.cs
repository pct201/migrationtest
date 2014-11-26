/**
#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace  RIMS_Base
{

[Serializable]
public abstract class cWrokerCompReserve
{

	#region Constructor
    public cWrokerCompReserve()
	{
		this._pK_Workers_Comp_RW_ID = -1;
		this._fK_Workers_Comp = -1;
		this._transaction_Date = DateTime.Now;
		this._hospital = -1;
		this._physician = -1;
		this._radiology = -1;
		this._pharmacy = -1;
		this._iME = -1;
		this._anesthesiologist = -1;
		this._nursing_Care = -1;
		this._transportation = -1;
		this._medical_Report = -1;
		this._medical_Total = -1;
		this._tTD_Payment = -1;
		this._tTD_Weeks = -1;
		this._tTD_Total = -1;
		this._tPD_Payment = -1;
		this._tPD_Weeks = -1;
		this._tPD_Total = -1;
		this._estimated_Award = -1;
		this._death_Benefit = -1;
		this._vocational_Rehab = -1;
		this._funeral_Expense = -1;
		this._disability_Total = -1;
		this._defense_Cost = -1;
		this._medical_Case_Management = -1;
		this._surveillance = -1;
		this._court_Costs = -1;
		this._depositions = -1;
		this._expense_Other_1_Description = string.Empty;
		this._expense_Other_1 = -1;
		this._expense_Other_2_Description = string.Empty;
		this._expense_Other_2 = -1;
		this._expense_Other_3_Description = string.Empty;
		this._expense_Other_3 = -1;
		this._expenses_Total = -1;
		this._bill_Review = -1;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Workers_Comp_RW_ID;
	private System.Decimal _fK_Workers_Comp;
	private System.DateTime _transaction_Date;
	private System.Decimal _hospital;
	private System.Decimal _physician;
	private System.Decimal _radiology;
	private System.Decimal _pharmacy;
	private System.Decimal _iME;
	private System.Decimal _anesthesiologist;
	private System.Decimal _nursing_Care;
	private System.Decimal _transportation;
	private System.Decimal _medical_Report;
	private System.Decimal _medical_Total;
	private System.Decimal _tTD_Payment;
	private System.Decimal _tTD_Weeks;
	private System.Decimal _tTD_Total;
	private System.Decimal _tPD_Payment;
	private System.Decimal _tPD_Weeks;
	private System.Decimal _tPD_Total;
	private System.Decimal _estimated_Award;
	private System.Decimal _death_Benefit;
	private System.Decimal _vocational_Rehab;
	private System.Decimal _funeral_Expense;
	private System.Decimal _disability_Total;
	private System.Decimal _defense_Cost;
	private System.Decimal _medical_Case_Management;
	private System.Decimal _surveillance;
	private System.Decimal _court_Costs;
	private System.Decimal _depositions;
	private System.String _expense_Other_1_Description;
	private System.Decimal _expense_Other_1;
	private System.String _expense_Other_2_Description;
	private System.Decimal _expense_Other_2;
	private System.String _expense_Other_3_Description;
	private System.Decimal _expense_Other_3;
	private System.Decimal _expenses_Total;
	private System.Decimal _bill_Review;
	private System.String _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Decimal PK_Workers_Comp_RW_ID
	{
		get { return  _pK_Workers_Comp_RW_ID; }
		set { _pK_Workers_Comp_RW_ID = value; }
	}

	public System.Decimal FK_Workers_Comp
	{
		get { return  _fK_Workers_Comp; }
		set { _fK_Workers_Comp = value; }
	}

	public System.DateTime Transaction_Date
	{
		get { return  _transaction_Date; }
		set { _transaction_Date = value; }
	}

	public System.Decimal Hospital
	{
		get { return  _hospital; }
		set { _hospital = value; }
	}

	public System.Decimal Physician
	{
		get { return  _physician; }
		set { _physician = value; }
	}

	public System.Decimal Radiology
	{
		get { return  _radiology; }
		set { _radiology = value; }
	}

	public System.Decimal Pharmacy
	{
		get { return  _pharmacy; }
		set { _pharmacy = value; }
	}

	public System.Decimal IME
	{
		get { return  _iME; }
		set { _iME = value; }
	}

	public System.Decimal Anesthesiologist
	{
		get { return  _anesthesiologist; }
		set { _anesthesiologist = value; }
	}

	public System.Decimal Nursing_Care
	{
		get { return  _nursing_Care; }
		set { _nursing_Care = value; }
	}

	public System.Decimal Transportation
	{
		get { return  _transportation; }
		set { _transportation = value; }
	}

	public System.Decimal Medical_Report
	{
		get { return  _medical_Report; }
		set { _medical_Report = value; }
	}

	public System.Decimal Medical_Total
	{
		get { return  _medical_Total; }
		set { _medical_Total = value; }
	}

	public System.Decimal TTD_Payment
	{
		get { return  _tTD_Payment; }
		set { _tTD_Payment = value; }
	}

	public System.Decimal TTD_Weeks
	{
		get { return  _tTD_Weeks; }
		set { _tTD_Weeks = value; }
	}

	public System.Decimal TTD_Total
	{
		get { return  _tTD_Total; }
		set { _tTD_Total = value; }
	}

	public System.Decimal TPD_Payment
	{
		get { return  _tPD_Payment; }
		set { _tPD_Payment = value; }
	}

	public System.Decimal TPD_Weeks
	{
		get { return  _tPD_Weeks; }
		set { _tPD_Weeks = value; }
	}

	public System.Decimal TPD_Total
	{
		get { return  _tPD_Total; }
		set { _tPD_Total = value; }
	}

	public System.Decimal Estimated_Award
	{
		get { return  _estimated_Award; }
		set { _estimated_Award = value; }
	}

	public System.Decimal Death_Benefit
	{
		get { return  _death_Benefit; }
		set { _death_Benefit = value; }
	}

	public System.Decimal Vocational_Rehab
	{
		get { return  _vocational_Rehab; }
		set { _vocational_Rehab = value; }
	}

	public System.Decimal Funeral_Expense
	{
		get { return  _funeral_Expense; }
		set { _funeral_Expense = value; }
	}

	public System.Decimal Disability_Total
	{
		get { return  _disability_Total; }
		set { _disability_Total = value; }
	}

	public System.Decimal Defense_Cost
	{
		get { return  _defense_Cost; }
		set { _defense_Cost = value; }
	}

	public System.Decimal Medical_Case_Management
	{
		get { return  _medical_Case_Management; }
		set { _medical_Case_Management = value; }
	}

	public System.Decimal Surveillance
	{
		get { return  _surveillance; }
		set { _surveillance = value; }
	}

	public System.Decimal Court_Costs
	{
		get { return  _court_Costs; }
		set { _court_Costs = value; }
	}

	public System.Decimal Depositions
	{
		get { return  _depositions; }
		set { _depositions = value; }
	}

	public System.String Expense_Other_1_Description
	{
		get { return  _expense_Other_1_Description; }
		set { _expense_Other_1_Description = value; }
	}

	public System.Decimal Expense_Other_1
	{
		get { return  _expense_Other_1; }
		set { _expense_Other_1 = value; }
	}

	public System.String Expense_Other_2_Description
	{
		get { return  _expense_Other_2_Description; }
		set { _expense_Other_2_Description = value; }
	}

	public System.Decimal Expense_Other_2
	{
		get { return  _expense_Other_2; }
		set { _expense_Other_2 = value; }
	}

	public System.String Expense_Other_3_Description
	{
		get { return  _expense_Other_3_Description; }
		set { _expense_Other_3_Description = value; }
	}

	public System.Decimal Expense_Other_3
	{
		get { return  _expense_Other_3; }
		set { _expense_Other_3 = value; }
	}

	public System.Decimal Expenses_Total
	{
		get { return  _expenses_Total; }
		set { _expenses_Total = value; }
	}

	public System.Decimal Bill_Review
	{
		get { return  _bill_Review; }
		set { _bill_Review = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Update_Date
	{
		get { return  _update_Date; }
		set { _update_Date = value; }
	}

	#endregion

	#region Abstract Methods
	public abstract List<cWrokerCompReserve> GetAll(Boolean blnIsActive);
	public abstract cWrokerCompReserve Get_WorderCompReserveByID(System.Decimal lPK_Workers_Comp_RW_ID);
	public abstract int InsertUpdate_WorkerCompReserve(RIMS_Base.cWrokerCompReserve obj);
	public abstract int Delete_WorkerCompReserve(System.Decimal lPK_Workers_Comp_RW_ID);
	public abstract string ActivateInactivate_WorkerCompReserve(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}*/
