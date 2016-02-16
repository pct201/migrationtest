using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_EPM_Project_Cost : clsBasePage
{
    #region " Properties "
    /// <summary>
    /// denotes Primary Key of EPM_Project_Cost table
    /// </summary>
    public decimal PK_EPM_Project_Cost
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Project_Cost"]); }
        set { ViewState["PK_EPM_Project_Cost"] = value; }
    }

    /// <summary>
    /// denotes Foreign Key of EPM_Identification table
    /// </summary>
    public decimal FK_EPM_Identification
    {
        get { return Convert.ToDecimal(ViewState["FK_EPM_Identification"]); }
        set { ViewState["FK_EPM_Identification"] = value; }
    }

    /// <summary>
    /// Denote Location ID for Environmental Project Management Data
    /// </summary>
    public int LocationID
    {
        get { return Convert.ToInt32(ViewState["LocationID"]); }
        set { ViewState["LocationID"] = value; }
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

    /// <summary>
    /// denotes Primary Key of Epm_identification table
    /// </summary>
    public decimal Identification_ID
    {
        get { return Convert.ToDecimal(ViewState["Identification_ID"]); }
        set { ViewState["Identification_ID"] = value; }
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
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.ProjectManagement);

        if (!IsPostBack)
        {
            LocationID = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["loc"].ToString()));
            FK_EPM_Identification = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["Cid"].ToString()));
            PK_EPM_Project_Cost = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["PCI"].ToString()));
            Identification_ID = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"].ToString()));
            StrOperation = Request.QueryString["op"].ToString();
            PanelNum = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();

            ComboHelper.FillEPM_Project_Phase(new DropDownList[] { drpProject_Phase }, true);
            BindHeaderInfo();

            DataTable dt = clsEPM_Identification.GetProjectDescrption(Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["Cid"].ToString()))).Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                txtCommentsOrDesc.Text = Convert.ToString(dt.Rows[0][0]);   
            }

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
            SetValidations();
            // store the location id in session
            Session["ExposureLocation"] = LocationID;
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
        clsEPM_Project_Cost ObjEPM_Project_Cost = new clsEPM_Project_Cost();
        ObjEPM_Project_Cost.PK_EPM_Project_Cost = PK_EPM_Project_Cost;
        ObjEPM_Project_Cost.FK_EPM_Identification = Identification_ID == 0 ? FK_EPM_Identification : Identification_ID;
        if (drpProject_Phase.SelectedIndex > 0) ObjEPM_Project_Cost.FK_LU_EPM_Project_Phase = Convert.ToDecimal(drpProject_Phase.SelectedValue);
        if (txtCommentsOrDesc.Text != "") ObjEPM_Project_Cost.Comments_Description = txtCommentsOrDesc.Text.Trim();
        if (txtBudget.Text != "") ObjEPM_Project_Cost.Budget = Convert.ToDecimal(txtBudget.Text);
        if (txtDate_Budget_Established.Text != "") ObjEPM_Project_Cost.Date_Budget_Established = clsGeneral.FormatDateToStore(txtDate_Budget_Established.Text);
        if (txtEstimated_Cost.Text != "") ObjEPM_Project_Cost.Estimated_Cost = Convert.ToDecimal(txtEstimated_Cost.Text);
        if (txtDate_Estimated_Cost_Derived.Text != "") ObjEPM_Project_Cost.Date_Estimated_Cost_Derived = clsGeneral.FormatDateToStore(txtDate_Estimated_Cost_Derived.Text);
        if (txtOriginal_Estimated_Cost.Text != "") ObjEPM_Project_Cost.Original_Estimated_Cost = Convert.ToDecimal(txtOriginal_Estimated_Cost.Text);
        if (txtDate_Original_Estimated_Cost_Derived.Text != "") ObjEPM_Project_Cost.Date_Original_Estimated_Cost_Derived = clsGeneral.FormatDateToStore(txtDate_Original_Estimated_Cost_Derived.Text);
        if (txtActual_Cost.Text != "") ObjEPM_Project_Cost.Actual_Cost = Convert.ToDecimal(txtActual_Cost.Text);
        if (txtDate_Actual_Cost_Incurred.Text != "") ObjEPM_Project_Cost.Date_Actual_Cost_Incurred = clsGeneral.FormatDateToStore(txtDate_Actual_Cost_Incurred.Text);
        ObjEPM_Project_Cost.Updated_By = clsSession.UserName;
        ObjEPM_Project_Cost.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

        if (PK_EPM_Project_Cost > 0)
            ObjEPM_Project_Cost.Update();
        else
            PK_EPM_Project_Cost = ObjEPM_Project_Cost.Insert();

        int CostPercentage = clsEPM_Project_Cost.GetCostPercentage(PK_EPM_Project_Cost);
        if (CostPercentage > 1)
        {
            clsEPM_Identification objEPM_Identification = new clsEPM_Identification(FK_EPM_Identification);
            string EmailBody = "";
            string EmailTo = AppConfig.EPM_MaiTo;
            string EmailSubject = "eRIMS2 Project Management Project Cost Alert - Environmental Project Number " + objEPM_Identification.Project_Number + "";

            EmailBody = "This e-mail is to provide an alert that the subject referenced project number's Actual Cost has exceeded the Original Estimated Cost by 10%.";
            clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, "", EmailSubject, EmailBody.Trim().Replace("\r\n", "<br/>"), true, new string[] { });
        }

        Response.Redirect("EPM_Project_Cost.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&Cid=" + Encryption.Encrypt(FK_EPM_Identification.ToString()) + "&id=" + Encryption.Encrypt(Identification_ID.ToString()) + "&PCI=" + Encryption.Encrypt(PK_EPM_Project_Cost.ToString()) + "&pnl=" + PanelNum + "&op=edit", true);
    }

    /// <summary>
    /// Handels Cancel Click of Cancel button and Redirect page to Project_Management's Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() == "add")
            StrOperation = "edit";
        Response.Redirect("Project_Management.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(FK_EPM_Identification.ToString()) + "&pnl=" + PanelNum + "&op=" + StrOperation, true);
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

        clsEPM_Project_Cost ObjEPM_Project_Cost = new clsEPM_Project_Cost(PK_EPM_Project_Cost);
        if (ObjEPM_Project_Cost.FK_LU_EPM_Project_Phase != null) lblProject_Phase.Text = new LU_EPM_Project_Phase((decimal)ObjEPM_Project_Cost.FK_LU_EPM_Project_Phase).Fld_Desc;
        if (ObjEPM_Project_Cost.Comments_Description != null) lblCommentsOrDesc.Text = ObjEPM_Project_Cost.Comments_Description;
        if (ObjEPM_Project_Cost.Budget != null) lblBudget.Text = clsGeneral.GetStringValue(ObjEPM_Project_Cost.Budget);
        if (ObjEPM_Project_Cost.Date_Budget_Established != null) lblDate_Budget_Established.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Project_Cost.Date_Budget_Established);
        if (ObjEPM_Project_Cost.Estimated_Cost != null) lblEstimated_Cost.Text = clsGeneral.GetStringValue(ObjEPM_Project_Cost.Estimated_Cost);
        if (ObjEPM_Project_Cost.Date_Estimated_Cost_Derived != null) lblDate_Estimated_Cost_Derived.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Project_Cost.Date_Estimated_Cost_Derived);
        if (ObjEPM_Project_Cost.Original_Estimated_Cost != null) lblOriginal_Estimated_Cost.Text = clsGeneral.GetStringValue(ObjEPM_Project_Cost.Original_Estimated_Cost);
        if (ObjEPM_Project_Cost.Date_Original_Estimated_Cost_Derived != null) lblDate_Original_Estimated_Cost_Derived.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Project_Cost.Date_Original_Estimated_Cost_Derived);
        if (ObjEPM_Project_Cost.Actual_Cost != null) lblActual_Cost.Text = clsGeneral.GetStringValue(ObjEPM_Project_Cost.Actual_Cost);
        if (ObjEPM_Project_Cost.Date_Actual_Cost_Incurred != null) lblDate_Actual_Cost_Incurred.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Project_Cost.Date_Actual_Cost_Incurred);
    }

    /// <summary>
    /// bind Project Cost detail for edit mode
    /// </summary>
    private void BindProjectCostDetailsForEdit()
    {
        btnProjectCost_Audit.Visible = true;
        btnCancel.Text = btnCancel.Text.Replace("Cancel", "Back");
        clsEPM_Project_Cost ObjEPM_Project_Cost = new clsEPM_Project_Cost(PK_EPM_Project_Cost);
        if (ObjEPM_Project_Cost.FK_LU_EPM_Project_Phase != null) drpProject_Phase.SelectedValue = ObjEPM_Project_Cost.FK_LU_EPM_Project_Phase.ToString();
        if (ObjEPM_Project_Cost.Comments_Description != null) txtCommentsOrDesc.Text = ObjEPM_Project_Cost.Comments_Description;
        if (ObjEPM_Project_Cost.Budget != null) txtBudget.Text = clsGeneral.GetStringValue(ObjEPM_Project_Cost.Budget);
        if (ObjEPM_Project_Cost.Date_Budget_Established != null) txtDate_Budget_Established.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Project_Cost.Date_Budget_Established);
        if (ObjEPM_Project_Cost.Estimated_Cost != null) txtEstimated_Cost.Text = clsGeneral.GetStringValue(ObjEPM_Project_Cost.Estimated_Cost);
        if (ObjEPM_Project_Cost.Date_Estimated_Cost_Derived != null) txtDate_Estimated_Cost_Derived.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Project_Cost.Date_Estimated_Cost_Derived);
        if (ObjEPM_Project_Cost.Original_Estimated_Cost != null) txtOriginal_Estimated_Cost.Text = clsGeneral.GetStringValue(ObjEPM_Project_Cost.Original_Estimated_Cost);
        if (ObjEPM_Project_Cost.Date_Original_Estimated_Cost_Derived != null) txtDate_Original_Estimated_Cost_Derived.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Project_Cost.Date_Original_Estimated_Cost_Derived);
        if (ObjEPM_Project_Cost.Actual_Cost != null) txtActual_Cost.Text = clsGeneral.GetStringValue(ObjEPM_Project_Cost.Actual_Cost);
        if (ObjEPM_Project_Cost.Date_Actual_Cost_Incurred != null) txtDate_Actual_Cost_Incurred.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Project_Cost.Date_Actual_Cost_Incurred);
    }

    /// <summary>
    /// Bind Header Info
    /// </summary>
    private void BindHeaderInfo()
    {
        DataTable dtLocationInfo = LU_Location.SelectByPK(LocationID).Tables[0];
        if (dtLocationInfo != null && dtLocationInfo.Rows.Count > 0)
        {
            lblLocation_Number.Text = (dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() : "";
            lblLocationdba.Text = (dtLocationInfo.Rows[0]["dba"].ToString() != "") ? dtLocationInfo.Rows[0]["dba"].ToString() : "";
            lblAddress.Text = (dtLocationInfo.Rows[0]["Address"].ToString() != "") ? dtLocationInfo.Rows[0]["Address"].ToString() : "";
            lblCity.Text = (dtLocationInfo.Rows[0]["City"].ToString() != "") ? dtLocationInfo.Rows[0]["City"].ToString() : "";
            lblState.Text = (dtLocationInfo.Rows[0]["StateName"].ToString() != "") ? dtLocationInfo.Rows[0]["StateName"].ToString() : "";
            lblZip.Text = (dtLocationInfo.Rows[0]["Zip_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Zip_Code"].ToString() : "";
        }
        DataTable dtProjectNumber = clsEPM_Identification.GetProjectNumber(LocationID, Identification_ID == 0 ? FK_EPM_Identification : Identification_ID).Tables[0];
        if (dtProjectNumber != null && dtProjectNumber.Rows.Count > 0)
        {
            lblHeaderProject_Number.Text = (dtProjectNumber.Rows[0]["Project_Number"].ToString() != "") ? dtProjectNumber.Rows[0]["Project_Number"].ToString() : "";
            lblHeaderProject_Type.Text = (dtProjectNumber.Rows[0]["Project_Type"].ToString() != "") ? dtProjectNumber.Rows[0]["Project_Type"].ToString() : "";
            tdProjectNum.Style["display"] = "block"; tdHeaderPro_Num.Style["display"] = "block"; tdHeaderProType.Style["display"] = "block"; tdProjectType.Style["display"] = "block";
        }
    }
    #endregion

    #region " Dynamic validations "
    private void SetValidations()
    {
        #region " Identification"
        string strCtrlsIDsProjectCost = "";
        string strMessagesProjectCost = "";
        DataTable dtFieldsProjectCost = clsScreen_Validators.SelectByScreen(196).Tables[0];
        dtFieldsProjectCost.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsProjectCost = dtFieldsProjectCost.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFieldsProjectCost.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drFieldsProjectCost in dtFieldsProjectCost.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldsProjectCost["Field_Name"]))
            {
                case "Project Phase": strCtrlsIDsProjectCost += drpProject_Phase.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost]/Project Phase" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Comments/Description": strCtrlsIDsProjectCost += txtCommentsOrDesc.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Comments/Description" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Budget": strCtrlsIDsProjectCost += txtBudget.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Budget" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Date Budget Established ": strCtrlsIDsProjectCost += txtDate_Budget_Established.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Date Budget Established " + ","; Span4.Style["display"] = "inline-block"; break;
                case "Estimated Cost": strCtrlsIDsProjectCost += txtEstimated_Cost.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Estimated Cost" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Date Estimated Cost Derived ": strCtrlsIDsProjectCost += txtDate_Estimated_Cost_Derived.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Date Estimated Cost Derived " + ","; Span6.Style["display"] = "inline-block"; break;
                case "Original Estimated Cost": strCtrlsIDsProjectCost += txtOriginal_Estimated_Cost.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Original Estimated Cost" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Date Original Estimated Cost Derived ": strCtrlsIDsProjectCost += txtDate_Original_Estimated_Cost_Derived.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Date Original Estimated Cost Derived " + ","; Span8.Style["display"] = "inline-block"; break;
                case "Actual Cost": strCtrlsIDsProjectCost += txtActual_Cost.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Actual Cost" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Date Actual Cost Incurred": strCtrlsIDsProjectCost += txtDate_Actual_Cost_Incurred.ClientID + ","; strMessagesProjectCost += "Please enter [Project Cost]/Date Actual Cost Incurred" + ","; Span10.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsProjectCost = strCtrlsIDsProjectCost.TrimEnd(',');
        strMessagesProjectCost = strMessagesProjectCost.TrimEnd(',');

        hdnControlIDsProjectCost.Value = strCtrlsIDsProjectCost;
        hdnErrorMsgsProjectCost.Value = strMessagesProjectCost;

        #endregion
    }
    #endregion
}