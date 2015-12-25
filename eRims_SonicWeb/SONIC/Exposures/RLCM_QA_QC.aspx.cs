using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Exposures_RLCM_QA_QC : clsBasePage
{

    private int RLCMTableRows
    {
        get { return ViewState["RLCMTableRows"] != null ? Convert.ToInt32(ViewState["RLCMTableRows"]) : 0; }
        set { ViewState["RLCMTableRows"] = value; }
    }

    #region "Page Events"

    /// <summary>
    /// Handles Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
            //clsSession.AllowedTab = "1,2,3,4,5";
            clsSession.AllowedTab = "";            
        }
    }

    #endregion

    #region "Method"

    /// <summary>
    /// Bind Drop Downs
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.BindMonth(ddlMonth);
        ddlMonth.Items.Insert(0, new ListItem("-- Select --", "0"));
        ComboHelper.FillYear(new DropDownList[] { ddlYear }, true);
        ComboHelper.FillRlcmDropDownList(new DropDownList[] { ddlRLCM }, true);
    }

    /// <summary>
    /// Bind Search Result
    /// </summary>
    private void BindSearchResult()
    {
        decimal rlcm = 0, year = 0, month = 0;
        string strOrderBy = string.Empty, strOrder = string.Empty;

        if (ddlRLCM.SelectedIndex > 0) rlcm = Convert.ToDecimal(ddlRLCM.SelectedValue);
        if (ddlMonth.SelectedIndex > 0) month = Convert.ToDecimal(ddlMonth.SelectedValue);
        if (ddlYear.SelectedIndex > 0) year = Convert.ToDecimal(ddlYear.SelectedValue);
        strOrderBy = "PK_RLCM";
        strOrder = "asc";
        lblMonth.Text = ddlMonth.SelectedItem.Text;
        lblYear.Text = Convert.ToString(year);
        lblRLCM.Text = ddlRLCM.SelectedItem.Text;


        DataSet dsSearchResult = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, string.Empty);

        if (dsSearchResult.Tables.Count > 0)
            RLCMTableRows = dsSearchResult.Tables[0].Rows.Count;

        gvRLCM.DataSource = dsSearchResult.Tables[0];
        gvRLCM.DataBind();

        pnlSearch.Visible = false;
        pnlGrid.Visible = true;

        if (rlcm == clsSession.CurrentLoginEmployeeId)
            btnSave.Visible = true;
        else
            btnSave.Visible = false;
    }

    #endregion

    #region"Grid View Events"

    /// <summary>
    /// Grid View RLCM Data RowBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRLCM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rlcm = 0, year = 0, month = 0;
            string strOrderBy = string.Empty, strOrder = string.Empty;
            if (ddlRLCM.SelectedIndex > 0) rlcm = Convert.ToDecimal(ddlRLCM.SelectedValue);
            if (ddlMonth.SelectedIndex > 0) month = Convert.ToDecimal(ddlMonth.SelectedValue);
            if (ddlYear.SelectedIndex > 0) year = Convert.ToDecimal(ddlYear.SelectedValue);
            strOrderBy = "PK_RLCM";
            strOrder = "asc";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = (GridView)e.Row.FindControl("gvChildGrid");

                Label lblTask;
                lblTask = (Label)e.Row.FindControl("lblTask");
                string strTask = lblTask.Text;
                if (e.Row.RowIndex != (RLCMTableRows - 1))
                {
                    gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, strTask);
                    gvChild.DataBind();
                }
                else
                {
                    gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, "Monthly Review Complete");
                    gvChild.DataBind();
                }
            }
        }
    }

    /// <summary>
    /// Child Grid Data RowBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvChildGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkStatus = (CheckBox)e.Row.FindControl("chkStatus");
            chkStatus.Checked = DataBinder.Eval(e.Row.DataItem, "Status") == DBNull.Value ? false : Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Status"));
            if (e.Row.FindControl("lnkIdentifier") != null)
            {
                System.Web.UI.HtmlControls.HtmlAnchor a1 = (System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("lnkIdentifier");
            }
        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Button Submit Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindSearchResult();
        pnlSearch.Visible = false;
        pnlGrid.Visible = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = true;
        pnlGrid.Visible = false;
    }

    #endregion



    //[System.Web.Services.WebMethod]
    //public static void SetSessionTab(string Prefix)
    //{

    //    if (Prefix.ToUpper() == "WC" || Prefix.ToUpper() == "NS") { clsSession.AllowedTab = "1"; }
    //    else if (Prefix.ToUpper() == "AL") { clsSession.AllowedTab = "2"; }
    //    else if (Prefix.ToUpper() == "DPD") { clsSession.AllowedTab = "3"; }
    //    else if (Prefix.ToUpper() == "PROPERTY") { clsSession.AllowedTab = "4"; }
    //    else if (Prefix.ToUpper() == "PL") { clsSession.AllowedTab = "5"; }

    //}

    [System.Web.Services.WebMethod]
    public static void SetSessionTab(string Hyperlink, string Type, string ClaimType)
    {
        string AllowTab = "", strWizardID = Hyperlink;
        if (Type.Contains("FirstReport"))
        {
            #region First Report
            int WizardID = Convert.ToInt32(Encryption.Decrypt(strWizardID));
            DataSet dstab = Constituent_First_Report.SelectConstituentDetails_byFirstReportID(WizardID);
            //check dataset having table hase atleast one row.
            if (dstab.Tables[0].Rows.Count > 0)
            {
                DataTable dtTab = dstab.Tables[0];
                foreach (DataRow drTab in dtTab.Rows)
                {
                    //check First_report_Table field of datarow in equal to WC_FR
                    if (drTab["First_Report_Table"].ToString() == "WC_FR" || drTab["First_Report_Table"].ToString() == "NS_FR")
                    {
                        AllowTab += "1";
                    }
                    //check First_report_Table field of datarow in equal to DPD_FR
                    else if (drTab["First_Report_Table"].ToString() == "DPD_FR")
                    {
                        //check if allowedTab string is empty than add value without comma ahead. else add comma at starting 
                        if (AllowTab != string.Empty)
                            AllowTab += ",3";
                        else
                            AllowTab += "3";
                    }
                    //check First_report_Table field of datarow in equal to AL_FR
                    else if (drTab["First_Report_Table"].ToString() == "AL_FR")
                    {
                        //check if allowedTab string is empty than add value without comma ahead. else add comma at starting
                        if (AllowTab != string.Empty)
                            AllowTab += ",2";
                        else
                            AllowTab += "2";
                    }
                    //check First_report_Table field of datarow in equal to PL_FR
                    else if (drTab["First_Report_Table"].ToString() == "PL_FR")
                    {
                        //check if allowedTab string is empty than add value without comma ahead. else add comma at starting
                        if (AllowTab != string.Empty)
                            AllowTab += ",5";
                        else
                            AllowTab += "5";
                    }
                    //check First_report_Table field of datarow in equal to PROPERTY_FR
                    else if (drTab["First_Report_Table"].ToString().ToUpper() == "PROPERTY_FR")
                    {
                        //check if allowedTab string is empty than add value without comma ahead. else add comma at starting
                        if (AllowTab != string.Empty)
                            AllowTab += ",4";
                        else
                            AllowTab += "4";
                    }
                }
                clsSession.AllowedTab = AllowTab;
            }
            #endregion
        }
        else if (Type.Contains("Claim"))
        {
            #region Claim Information
            switch (ClaimType)
            {
                case "WCClaimInfo.aspx":
                    AllowTab = "1";
                    break;
                case "ALClaimInfo.aspx":
                    AllowTab = "2";
                    break;
                case "DPDClaimInfo.aspx":
                    AllowTab = "3";
                    break;
                case "PROPERTY":
                    AllowTab = "4";
                    break;
                case "PL":
                    AllowTab = "5";
                    break;
            }
            clsSession.AllowedTab = AllowTab;
            #endregion
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string checkedIDs = string.Empty, uncheckedIDs = string.Empty;
        bool chkMonthlyReviewChecked = false;
        foreach (GridViewRow gvRLCMRow in gvRLCM.Rows)
        {
            if (gvRLCMRow.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = (GridView)gvRLCMRow.FindControl("gvChildGrid");
                if (gvChild != null)
                    foreach (GridViewRow gvChildRow in gvChild.Rows)
                    {
                        CheckBox chkStatus = (CheckBox)gvChildRow.FindControl("chkStatus");
                        //if(chkStatus.Checked)
                        {
                            HiddenField hdnStatus = (HiddenField)gvChildRow.FindControl("hdnStatus");
                            Control c = gvChildRow.Cells[0].FindControl("lnkIdentifier");

                            if (gvChildRow.Cells.Count > 0 && gvChildRow.Cells[0].Controls.Count > 0)
                            {
                                DataBoundLiteralControl lnkIdentifier = (DataBoundLiteralControl)gvChildRow.Cells[0].Controls[0];
                                if (lnkIdentifier.Text.Contains("Monthly Review Complete"))
                                    chkMonthlyReviewChecked = chkStatus.Checked;
                            }

                            if (hdnStatus != null)
                            {
                                if (chkStatus.Checked)
                                    checkedIDs += hdnStatus.Value + ",";
                                else
                                    uncheckedIDs += hdnStatus.Value + ",";
                            }
                        }
                    }
            }
        }

        decimal rlcm = 0, year = 0, month = 0;
        string strOrderBy = string.Empty, strOrder = string.Empty;
        if (ddlRLCM.SelectedIndex > 0) rlcm = Convert.ToDecimal(ddlRLCM.SelectedValue);
        if (ddlMonth.SelectedIndex > 0) month = Convert.ToDecimal(ddlMonth.SelectedValue);
        if (ddlYear.SelectedIndex > 0) year = Convert.ToDecimal(ddlYear.SelectedValue);


        clsRLCM_QA_QC.UpdateStatus(checkedIDs, uncheckedIDs, Convert.ToString(clsSession.UserID));
        clsRLCM_QA_QC.RLCM_QA_QC_CompleteInsertUpdateStatus(rlcm, year, month, chkMonthlyReviewChecked, Convert.ToString(clsSession.UserID));

    }
}