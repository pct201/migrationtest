using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_ACI_Management_Project_Cost : clsBasePage
{
    #region " Properties "
    /// <summary>
    /// denotes Primary Key of EPM_Project_Cost table
    /// </summary>
    public decimal PK_ACIManagement_ProjectCost
    {
        get { return Convert.ToDecimal(ViewState["PK_ACIManagement_ProjectCost"]); }
        set { ViewState["PK_ACIManagement_ProjectCost"] = value; }
    }

    /// <summary>
    /// denotes Foreign Key of EPM_Identification table
    /// </summary>
    public decimal FK_Management
    {
        get { return Convert.ToDecimal(ViewState["FK_Management"]); }
        set { ViewState["FK_Management"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    /// <summary>
    /// Denote PanelNum 
    /// </summary>
    public string PanelNum
    {
        get { return Convert.ToString(ViewState["PanelNum"]); }
        set { ViewState["PanelNum"] = value; }
    }

    
    #endregion

    #region " page Event "
    /// <summary>
    /// Handles Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            FK_Management = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"].ToString()));
            PK_ACIManagement_ProjectCost = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["PCI"].ToString()));
            StrOperation = Request.QueryString["op"].ToString();
            PanelNum = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();

            ComboHelper.FillEPM_Project_Phase(new DropDownList[] { drpProject_Phase }, true);

            if (StrOperation.ToLower() == "add")
            {
                btnProjectCost_Audit.Visible = false;
            }

            if (StrOperation.ToLower() == "edit")
            {
                BindProjectCostDetailsForEdit();
            }
            else if (StrOperation.ToLower() == "view")
            {
                BindProjectCostDetailsForView();
            }
        }
        txtDateToday.Text = DateTime.Today.ToString("MM/dd/yyyy");
    }
    #endregion

    #region " Page Events "
    /// <summary>
    /// Handles save Click Of Project Cost
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveProject_Cost_OnClick(object sender, EventArgs e)
    {
        clsACIManagement_ProjectCost objACIManagement_ProjectCost = new clsACIManagement_ProjectCost();
        objACIManagement_ProjectCost.PK_ACIManagement_ProjectCost = PK_ACIManagement_ProjectCost;
        objACIManagement_ProjectCost.FK_Management = FK_Management;
        objACIManagement_ProjectCost.FK_LU_EPM_Project_Phase = clsGeneral.GetDecimal(drpProject_Phase.SelectedValue);
        if (txtCommentsOrDesc.Text != string.Empty) objACIManagement_ProjectCost.Comments_Description = Convert.ToString(txtCommentsOrDesc.Text);
        if (txtBudget.Text != "") objACIManagement_ProjectCost.Budget = Convert.ToDecimal(txtBudget.Text);
        if (txtDate_Budget_Established.Text != "") objACIManagement_ProjectCost.Date_Budget_Established = clsGeneral.FormatDateToStore(txtDate_Budget_Established.Text);
        if (txtEstimated_Cost.Text != "") objACIManagement_ProjectCost.Estimated_Cost = Convert.ToDecimal(txtEstimated_Cost.Text);
        if (txtDate_Estimated_Cost_Derived.Text != "") objACIManagement_ProjectCost.Date_Estimated_Cost_Derived = clsGeneral.FormatDateToStore(txtDate_Estimated_Cost_Derived.Text);
        if (txtOriginal_Estimated_Cost.Text != "") objACIManagement_ProjectCost.Original_Estimated_Cost = Convert.ToDecimal(txtOriginal_Estimated_Cost.Text);
        if (txtDate_Original_Estimated_Cost_Derived.Text != "") objACIManagement_ProjectCost.Date_Original_Estimated_Cost_Derived = clsGeneral.FormatDateToStore(txtDate_Original_Estimated_Cost_Derived.Text);
        if (txtActual_Cost.Text != "") objACIManagement_ProjectCost.Actual_Cost = Convert.ToDecimal(txtActual_Cost.Text);
        if (txtDate_Actual_Cost_Incurred.Text != "") objACIManagement_ProjectCost.Date_Actual_Cost_Incurred = clsGeneral.FormatDateToStore(txtDate_Actual_Cost_Incurred.Text);
        objACIManagement_ProjectCost.Updated_By = clsSession.UserName;
        objACIManagement_ProjectCost.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

        if (PK_ACIManagement_ProjectCost > 0)
            objACIManagement_ProjectCost.Update();
        else
            PK_ACIManagement_ProjectCost = objACIManagement_ProjectCost.Insert();

        int CostPercentage = clsACIManagement_ProjectCost.GetCostPercentage(PK_ACIManagement_ProjectCost);
        if (CostPercentage > 1)
        {
            //clsManagement objManagement = new clsManagement(FK_Management);
            string EmailBody = "";
            string EmailTo = AppConfig.ACI_Management_MaiTo;
            string EmailSubject = "eRIMS2 Project Management Project Cost Alert - ACI Management ";// +objManagement.Company + "";

            EmailBody = "This e-mail is to provide an alert that the subject referenced project number's Actual Cost has exceeded the Original Estimated Cost by 10%.";
            clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, "", EmailSubject, EmailBody.Trim().Replace("\r\n", "<br/>"), true, new string[] { });
        }

        Response.Redirect("ACI_Management_Project_Cost.aspx?id=" + Encryption.Encrypt(FK_Management.ToString()) + "&PCI=" + Encryption.Encrypt(PK_ACIManagement_ProjectCost.ToString()) + "&pnl=" + PanelNum + "&op=edit", true);
    }

    /// <summary>
    /// Cancel Click of Cancel button and Redirect page to Project_Management's Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() == "add")
            StrOperation = "edit";
        Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(Convert.ToString(FK_Management)) + "&mode=" + StrOperation + "&pnl=" + PanelNum, true);
    }
    #endregion

    #region " Private Method "
    /// <summary>
    /// bind Project Cost detail for view mode
    /// </summary>
    private void BindProjectCostDetailsForView()
    {
        btnProjectCost_Audit.Visible = true;
        btnSaveProject_Cost.Visible = false;
        dvEdit.Style["display"] = "none";
        divView.Style["display"] = "";
        btnCancel.Text = btnCancel.Text.Replace("Cancel", "Back");

        clsACIManagement_ProjectCost objACIManagement_ProjectCost = new clsACIManagement_ProjectCost(PK_ACIManagement_ProjectCost);
        if (objACIManagement_ProjectCost.FK_LU_EPM_Project_Phase != null) lblProject_Phase.Text = new LU_EPM_Project_Phase((decimal)objACIManagement_ProjectCost.FK_LU_EPM_Project_Phase).Fld_Desc;
        if (objACIManagement_ProjectCost.Comments_Description != null) lblCommentsOrDesc.Text = objACIManagement_ProjectCost.Comments_Description;
        if (objACIManagement_ProjectCost.Budget != null) lblBudget.Text = clsGeneral.GetStringValue(objACIManagement_ProjectCost.Budget);
        if (objACIManagement_ProjectCost.Date_Budget_Established != null) lblDate_Budget_Established.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost.Date_Budget_Established);
        if (objACIManagement_ProjectCost.Estimated_Cost != null) lblEstimated_Cost.Text = clsGeneral.GetStringValue(objACIManagement_ProjectCost.Estimated_Cost);
        if (objACIManagement_ProjectCost.Date_Estimated_Cost_Derived != null) lblDate_Estimated_Cost_Derived.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost.Date_Estimated_Cost_Derived);
        if (objACIManagement_ProjectCost.Original_Estimated_Cost != null) lblOriginal_Estimated_Cost.Text = clsGeneral.GetStringValue(objACIManagement_ProjectCost.Original_Estimated_Cost);
        if (objACIManagement_ProjectCost.Date_Original_Estimated_Cost_Derived != null) lblDate_Original_Estimated_Cost_Derived.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost.Date_Original_Estimated_Cost_Derived);
        if (objACIManagement_ProjectCost.Actual_Cost != null) lblActual_Cost.Text = clsGeneral.GetStringValue(objACIManagement_ProjectCost.Actual_Cost);
        if (objACIManagement_ProjectCost.Date_Actual_Cost_Incurred != null) lblDate_Actual_Cost_Incurred.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost.Date_Actual_Cost_Incurred);
    }

    /// <summary>
    /// bind Project Cost detail for edit mode
    /// </summary>
    private void BindProjectCostDetailsForEdit()
    {
        btnProjectCost_Audit.Visible = true;
        btnCancel.Text = btnCancel.Text.Replace("Cancel", "Back");
        clsACIManagement_ProjectCost objACIManagement_ProjectCost = new clsACIManagement_ProjectCost(PK_ACIManagement_ProjectCost);
        if (objACIManagement_ProjectCost.FK_LU_EPM_Project_Phase != null) drpProject_Phase.SelectedValue = objACIManagement_ProjectCost.FK_LU_EPM_Project_Phase.ToString();
        if (objACIManagement_ProjectCost.Comments_Description != null) txtCommentsOrDesc.Text = objACIManagement_ProjectCost.Comments_Description;
        if (objACIManagement_ProjectCost.Budget != null) txtBudget.Text = clsGeneral.GetStringValue(objACIManagement_ProjectCost.Budget);
        if (objACIManagement_ProjectCost.Date_Budget_Established != null) txtDate_Budget_Established.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost.Date_Budget_Established);
        if (objACIManagement_ProjectCost.Estimated_Cost != null) txtEstimated_Cost.Text = clsGeneral.GetStringValue(objACIManagement_ProjectCost.Estimated_Cost);
        if (objACIManagement_ProjectCost.Date_Estimated_Cost_Derived != null) txtDate_Estimated_Cost_Derived.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost.Date_Estimated_Cost_Derived);
        if (objACIManagement_ProjectCost.Original_Estimated_Cost != null) txtOriginal_Estimated_Cost.Text = clsGeneral.GetStringValue(objACIManagement_ProjectCost.Original_Estimated_Cost);
        if (objACIManagement_ProjectCost.Date_Original_Estimated_Cost_Derived != null) txtDate_Original_Estimated_Cost_Derived.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost.Date_Original_Estimated_Cost_Derived);
        if (objACIManagement_ProjectCost.Actual_Cost != null) txtActual_Cost.Text = clsGeneral.GetStringValue(objACIManagement_ProjectCost.Actual_Cost);
        if (objACIManagement_ProjectCost.Date_Actual_Cost_Incurred != null) txtDate_Actual_Cost_Incurred.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost.Date_Actual_Cost_Incurred);
    }

    #endregion

    #region " Dynamic validations "
    private void SetValidations()
    {
        #region " Identification"
        //string strCtrlsIDsProjectCost = "";
        //string strMessagesProjectCost = "";
        //DataTable dtFieldsProjectCost = clsScreen_Validators.SelectByScreen(196).Tables[0];
        //dtFieldsProjectCost.DefaultView.RowFilter = "IsRequired = '1'";
        //dtFieldsProjectCost = dtFieldsProjectCost.DefaultView.ToTable();
        //MenuAsterisk1.Style["display"] = (dtFieldsProjectCost.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";
        //foreach (DataRow drFieldsProjectCost in dtFieldsProjectCost.Rows)
        //{
        //    #region " set validation control IDs and messages "
        //    switch (Convert.ToString(drFieldsProjectCost["Field_Name"]))
        //    {
        //        case "Project Phase": strCtrlsIDsProjectCost += drpProject_Phase.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost]/Project Phase" + ","; Span1.Style["display"] = "inline-block"; break;
        //        case "Comments/Description": strCtrlsIDsProjectCost += txtCommentsOrDesc.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Comments/Description" + ","; Span2.Style["display"] = "inline-block"; break;
        //        case "Budget": strCtrlsIDsProjectCost += txtBudget.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Budget" + ","; Span3.Style["display"] = "inline-block"; break;
        //        case "Date Budget Established ": strCtrlsIDsProjectCost += txtDate_Budget_Established.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Date Budget Established " + ","; Span4.Style["display"] = "inline-block"; break;
        //        case "Estimated Cost": strCtrlsIDsProjectCost += txtEstimated_Cost.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Estimated Cost" + ","; Span5.Style["display"] = "inline-block"; break;
        //        case "Date Estimated Cost Derived ": strCtrlsIDsProjectCost += txtDate_Estimated_Cost_Derived.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Date Estimated Cost Derived " + ","; Span6.Style["display"] = "inline-block"; break;
        //        case "Original Estimated Cost": strCtrlsIDsProjectCost += txtOriginal_Estimated_Cost.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Original Estimated Cost" + ","; Span7.Style["display"] = "inline-block"; break;
        //        case "Date Original Estimated Cost Derived ": strCtrlsIDsProjectCost += txtDate_Original_Estimated_Cost_Derived.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Date Original Estimated Cost Derived " + ","; Span8.Style["display"] = "inline-block"; break;
        //        case "Actual Cost": strCtrlsIDsProjectCost += txtActual_Cost.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Actual Cost" + ","; Span9.Style["display"] = "inline-block"; break;
        //        case "Date Actual Cost Incurred": strCtrlsIDsProjectCost += txtDate_Actual_Cost_Incurred.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Date Actual Cost Incurred" + ","; Span10.Style["display"] = "inline-block"; break;
        //    }
        //    #endregion
        //}
        //strCtrlsIDsProjectCost = strCtrlsIDsProjectCost.TrimEnd(',');
        //strMessagesProjectCost = strMessagesProjectCost.TrimEnd(',');

        //hdnControlIDsProjectCost.Value = strCtrlsIDsProjectCost;
        //hdnErrorMsgsProjectCost.Value = strMessagesProjectCost;

        #endregion
    }
    #endregion
}