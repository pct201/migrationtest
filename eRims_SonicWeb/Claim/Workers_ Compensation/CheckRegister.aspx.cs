using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;


public partial class WorkerCompensation_CheckRegister : System.Web.UI.Page
{
    #region public variable

    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;
    List<RIMS_Base.CCheckRegister> lstCheckRegister = null;
    public RIMS_Base.Biz.CCheckRegister objCheckRegister;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserRoleId"] != null)
            {
                if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
                {
                    RIMS_Base.Biz.cWorkerComp objWorkerComp = new RIMS_Base.Biz.cWorkerComp();
                    List<RIMS_Base.cWorkerComp> lstWorkerComp = new List<RIMS_Base.cWorkerComp>();
                    try
                    {
                        lstWorkerComp = objWorkerComp.GetWorkerCompByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
                        string Claim_No = lstWorkerComp[0].Claim_Number;
                        DisplayEmployeeInfo(Claim_No);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        objWorkerComp = null;
                        lstWorkerComp = null;
                    }

                    if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                        ViewAllFromSearchGrid();
                    else
                        DispalayCheckRegisterData();

                }
            }
        }
        else
        {
            Response.Redirect("../Signin.aspx", false);
        }
    }
    // --- Display Check Register Information
    private void DispalayCheckRegisterData()
    {
        objCheckRegister = new RIMS_Base.Biz.CCheckRegister();
        if (ViewState["TableFK"] != null && ViewState["TableName"] != null)
        {
            // Commented by Mayuri on  04-Mar-2008
			lstCheckRegister = objCheckRegister.GetCheckRegisterByID(Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            // Commented by Alpesh on  03-Mar-2008
			//lstCheckRegister = objCheckRegister.GetCheckRegisterByID(Convert.ToDecimal(Session["WorkerCompID"].ToString()), ViewState["TableName"].ToString());
           
        }
        if (lstCheckRegister.Count != 0)
        {
            tblDetail.Style["display"] = "block";
            if (lstCheckRegister[0].Indemnity_Incurred != null)
                lblIndemIncurred.Text = lstCheckRegister[0].Indemnity_Incurred.ToString();
            else
                lblIndemIncurred.Text = "0.0";
            if (lstCheckRegister[0].Indemnity_Paid != null)
                lblIndemPaid.Text = lstCheckRegister[0].Indemnity_Paid.ToString();
            else
                lblIndemPaid.Text = "0.0";
            //if (lstCheckRegister[0].Indemnity_Outstanding != null)
            if (lstCheckRegister[0].Indemnity_Incurred != null && lstCheckRegister[0].Indemnity_Paid != null)
            {
                decimal? Temp =lstCheckRegister[0].Indemnity_Incurred - lstCheckRegister[0].Indemnity_Paid;
                lblIndemOutStanding.Text = Temp.ToString();
            }
            else if(lstCheckRegister[0].Indemnity_Incurred != null && lstCheckRegister[0].Indemnity_Paid == null)
            {
                lblIndemOutStanding.Text = lstCheckRegister[0].Indemnity_Incurred.ToString();
            }
            else if (lstCheckRegister[0].Indemnity_Incurred == null && lstCheckRegister[0].Indemnity_Paid == null)
            {
                lblIndemOutStanding.Text = "0.0";
            }
            if (lstCheckRegister[0].Indemnity_Current_Month != null)
                lblIndemCurrentMonth.Text = lstCheckRegister[0].Indemnity_Current_Month.ToString();
            else
                lblIndemCurrentMonth.Text = "0.0";
            if (lstCheckRegister[0].Medical_Incurred != null)
                lblMediIncured.Text = lstCheckRegister[0].Medical_Incurred.ToString();
            else
                lblMediIncured.Text = "0.0";
            if (lstCheckRegister[0].Medical_Paid != null)
                lblMediPaid.Text = lstCheckRegister[0].Medical_Paid.ToString();
            else
                lblMediPaid.Text = "0.0";
            //if (lstCheckRegister[0].Medical_Outstanding != null)
            if (lstCheckRegister[0].Medical_Incurred != null && lstCheckRegister[0].Medical_Paid != null)
            {
                decimal? Temp = lstCheckRegister[0].Medical_Incurred - lstCheckRegister[0].Medical_Paid;
                lblMediOutStand.Text = Temp.ToString();
            }
            else if (lstCheckRegister[0].Medical_Incurred != null && lstCheckRegister[0].Medical_Paid == null)
            {
                lblMediOutStand.Text = lstCheckRegister[0].Medical_Incurred.ToString();
            }
            else if (lstCheckRegister[0].Medical_Incurred == null && lstCheckRegister[0].Medical_Paid == null)
            {
                lblMediOutStand.Text = "0.0";
            }
            if (lstCheckRegister[0].Medical_Current_Month != null)
                lblMediCurrentMonth.Text = lstCheckRegister[0].Medical_Current_Month.ToString();
            else
                lblMediCurrentMonth.Text = "0.0";
            if (lstCheckRegister[0].Expense_Incurred != null)
                lblExpIncurred.Text = lstCheckRegister[0].Expense_Incurred.ToString();
            else
                lblExpIncurred.Text = "0.0";
            if (lstCheckRegister[0].Expense_Paid != null)
                lblExpIndemPaid.Text = lstCheckRegister[0].Expense_Paid.ToString();
            else
                lblExpIndemPaid.Text = "0.0";
            //if (lstCheckRegister[0].Expense_Outstanding != null)
            if (lstCheckRegister[0].Expense_Incurred != null && lstCheckRegister[0].Expense_Paid != null)
            {
                decimal? Temp = lstCheckRegister[0].Expense_Incurred - lstCheckRegister[0].Expense_Paid;
                lblExpOutStand.Text = Temp.ToString();
            }
            else if (lstCheckRegister[0].Expense_Incurred != null && lstCheckRegister[0].Expense_Paid == null)
            {
                lblExpOutStand.Text = lstCheckRegister[0].Expense_Incurred.ToString();
            }
            else if (lstCheckRegister[0].Expense_Incurred == null && lstCheckRegister[0].Expense_Paid == null)
            {
                lblExpOutStand.Text = "0.0";
            }
            if (lstCheckRegister[0].Expense_Current_Month != null)
                lblExpCurrentMonth.Text = lstCheckRegister[0].Expense_Current_Month.ToString();
            else
                lblExpCurrentMonth.Text = "0.0";
        }
        else
        {
            tblDetail.Style["display"] = "none";
            tblNoData.Style["display"] = "block";
        }
    }
    // --- Display Employee Information
    private void DisplayEmployeeInfo(string claimNO)
    {
        m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
        lstClaimReservesInfo = new List<RIMS_Base.CCheckWriting>();
        lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(claimNO);
        lblClaimNum.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
        ViewState["TableName"] = lstClaimReservesInfo[0].TableName.ToString();
        ViewState["TableFK"] = lstClaimReservesInfo[0].TableFK.ToString();
        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
        {
            rbtnEmployee.Items[0].Selected = true;
            lblEmployee.Text = "Yes";
        }
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
        {
            rbtnEmployee.Items[1].Selected = true;
            lblEmployee.Text = "No";
        }
        lblLName.Text = lstClaimReservesInfo[0].LastName.ToString();
        lblFName.Text = lstClaimReservesInfo[0].FirstName.ToString();
        lblMName.Text = lstClaimReservesInfo[0].MiddleName.ToString();
        lblDateIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
      
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainDiary.aspx");
    }
    private void ViewAllFromSearchGrid()
    {
        leftDiv.Style["display"] = "none";
        mainContent.Style["width"] = "95%";
        mainContent.Style["align"] = "left";
        divsecond.Style["display"] = "block";
        dvViewEmp.Style["display"] = "block";
        dvEditEmp.Style["display"] = "none";
        DispalayCheckRegisterData();
    }
    
}

