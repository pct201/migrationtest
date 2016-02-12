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
    private int SLTRLCMTableRows
    {
        get { return ViewState["SLTRLCMTableRows"] != null ? Convert.ToInt32(ViewState["SLTRLCMTableRows"]) : 0; }
        set { ViewState["SLTRLCMTableRows"] = value; }
    }
    private int ExposureRLCMTableRows
    {
        get { return ViewState["ExposureRLCMTableRows"] != null ? Convert.ToInt32(ViewState["ExposureRLCMTableRows"]) : 0; }
        set { ViewState["ExposureRLCMTableRows"] = value; }
    }
    private int ACIRLCMTableRows
    {
        get { return ViewState["ACIRLCMTableRows"] != null ? Convert.ToInt32(ViewState["ACIRLCMTableRows"]) : 0; }
        set { ViewState["ACIRLCMTableRows"] = value; }
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
            
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
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
        DataTable dtClaimRLCM, dtClaimInfo, dtClaimInc, dtSLTRLCM, dtExposureRLCM, dtExposurePropSecRLCM, dtExposureDPDRLCM, dtExposureCustomerRLCM, dtACIManagementRLCM;
        DataView dvTemp;
        dvTemp = dsSearchResult.Tables[0].DefaultView;

        dvTemp.RowFilter = "Module = 'Claims' and System = 'FROI'"; dtClaimRLCM = dvTemp.ToTable();
        dvTemp.RowFilter = "Module = 'Claims' and System = 'Claim Information'"; dtClaimInfo = dvTemp.ToTable();
        dvTemp.RowFilter = "Module = 'Claims' and System = 'Incident Investigation'"; dtClaimInc = dvTemp.ToTable();
        dvTemp.RowFilter = "Module = 'SLT'"; dtSLTRLCM = dvTemp.ToTable();
        dvTemp.RowFilter = "Module = 'Exposure' and System = 'EHS'"; dtExposureRLCM = dvTemp.ToTable();
        dvTemp.RowFilter = "Module = 'Exposure' and Task = 'Any changes needed to be made (updates in the Property Security)?'"; dtExposurePropSecRLCM = dvTemp.ToTable();
        dvTemp.RowFilter = "Module = 'Exposure' and Task = 'New/Updates/Changes – DPD Thefts'"; dtExposureDPDRLCM = dvTemp.ToTable();
        dvTemp.RowFilter = "Module = 'Exposure' and Task = 'New/Updates/Changes – Customer Vehicle Thefts'"; dtExposureCustomerRLCM = dvTemp.ToTable();

        dvTemp.RowFilter = "Module = 'ACI' or Module = ''";
        dvTemp.Sort = "Module DESC";
        dtACIManagementRLCM = dvTemp.ToTable();
        
        //dtClaimRLCM = dvClaimRLCM.ToTable();
        //dtSLTRLCM = dvSLTRLCM.ToTable();
        //dtExposureRLCM = dvExposureRLCM.ToTable();
        //dtACIManagementRLCM = dvACIManagementRLCM.ToTable();

        if (dsSearchResult.Tables.Count > 0)
        {
            RLCMTableRows = dtClaimRLCM.Rows.Count;
            SLTRLCMTableRows = dtSLTRLCM.Rows.Count;
            ExposureRLCMTableRows = dtExposureRLCM.Rows.Count;
            ACIRLCMTableRows = dtACIManagementRLCM.Rows.Count;
        }

        gvClaimRLCM.DataSource = dtClaimRLCM;
        gvClaimRLCM.DataBind();
        gvClaimInfo.DataSource = dtClaimInfo;
        gvClaimInfo.DataBind();
        gvClaimIncident.DataSource = dtClaimInc;
        gvClaimIncident.DataBind();

        gvSLTRLCM.DataSource = dtSLTRLCM;
        gvSLTRLCM.DataBind();

        gvExposureRLCM.DataSource = dtExposureRLCM;
        gvExposureRLCM.DataBind();
        gvExposurePropSec.DataSource = dtExposurePropSecRLCM;
        gvExposurePropSec.DataBind();
        gvExposureDPD.DataSource = dtExposureDPDRLCM;
        gvExposureDPD.DataBind();
        gvExposureCustomer.DataSource = dtExposureCustomerRLCM;
        gvExposureCustomer.DataBind();

        gvACIManagementRLCM.DataSource = dtACIManagementRLCM;
        gvACIManagementRLCM.DataBind();

        pnlSearch.Visible = false;
        pnlGrid.Visible = true;

        btnSave.Visible = (dtClaimRLCM.Rows.Count > 0);
        btnClaimInfoSave.Visible = (dtClaimInfo.Rows.Count > 0);
        btnClaimIncidentSave.Visible = (dtClaimInc.Rows.Count > 0);
        btnSLTSave.Visible = (dtSLTRLCM.Rows.Count > 0);
        btnExposureSave.Visible = (dtExposureRLCM.Rows.Count > 0);
        btnExposurePropSecSave.Visible = (dtExposurePropSecRLCM.Rows.Count > 0);
        btnExposureDPDSave.Visible = (dtExposureDPDRLCM.Rows.Count > 0);
        btnExposureCustomerSave.Visible = (dtExposureCustomerRLCM.Rows.Count > 0);
        btnACISave.Visible = (dtACIManagementRLCM.Rows.Count > 0);

        if (rlcm == clsSession.CurrentLoginEmployeeId)
        {
            btnSave.Visible = btnClaimInfoSave.Visible = btnClaimIncidentSave.Visible = btnSLTSave.Visible = btnExposureSave.Visible = btnExposurePropSecSave.Visible = btnExposureDPDSave.Visible = btnExposureCustomerSave.Visible = btnACISave.Visible = true;
            hdnISRLCMUser.Value = "1";
        }
        else
        {
            btnSave.Visible = btnClaimInfoSave.Visible = btnClaimIncidentSave.Visible = btnSLTSave.Visible = btnExposureSave.Visible = btnExposurePropSecSave.Visible = btnExposureDPDSave.Visible = btnExposureCustomerSave.Visible = btnACISave.Visible = false;
            hdnISRLCMUser.Value = "0";
        }
    }

    #endregion

    #region"Grid View Events"

    /// <summary>
    /// Grid View RLCM Data RowBound Event :: Here claim and it's submenu grid's data rowbound
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
                string strGridId = ((GridView)sender).ID;
                string strChaildGridId = string.Empty, strTaskID =string.Empty;

                switch (strGridId)
                {
                    case "gvClaimInfo":
                        strChaildGridId = "gvClaimInfoChildGrid";
                        strTaskID = "lblClaimInfoTask";
                        break;
                    case "gvClaimRLCM":
                        strChaildGridId = "gvChildGrid";
                        strTaskID = "lblTask";
                        break;
                    case "gvClaimIncident":
                        strChaildGridId = "gvClaimIncidentChildGrid";
                        strTaskID = "lblClaimIncidentTask";
                        break;
                }

                GridView gvChild = (GridView)e.Row.FindControl(strChaildGridId);
                Label lblTask;
                lblTask = (Label)e.Row.FindControl(strTaskID);
                string strTask = lblTask.Text;
                //if (e.Row.RowIndex != (RLCMTableRows - 1))
                //{
                    gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, strTask);
                    gvChild.DataBind();
                //}
                //else
                //{
                //    gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, "Monthly Review Complete");
                //    gvChild.DataBind();
                //}
            }
        }
    }

    /// <summary>
    /// Grid View SLT RLCM Data RowBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSLTRLCM_RowDataBound(object sender, GridViewRowEventArgs e)
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
                GridView gvChild = (GridView)e.Row.FindControl("gvSLTChildGrid");

                Label lblTask;
                lblTask = (Label)e.Row.FindControl("lblSLTTask");
                string strTask = lblTask.Text;
                //if (e.Row.RowIndex != (SLTRLCMTableRows - 1))
                //{
                    gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, strTask);
                    gvChild.DataBind();
                //}
                //else
                //{
                //    gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, "Monthly Review Complete");
                //    gvChild.DataBind();
                //}
            }
        }
    }

    /// <summary>
    /// Grid View Exposure RLCM Data RowBound Event :: Here Exposure and it's submenu grid's data rowbound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExposureRLCM_RowDataBound(object sender, GridViewRowEventArgs e)
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
                string strGridId = ((GridView)sender).ID;
                string strChaildGridId = string.Empty, strTaskID = string.Empty;

                switch (strGridId)
                {
                    case "gvExposureRLCM":
                        strChaildGridId = "gvExposureChildGrid";
                        strTaskID = "lblExposureTask";
                        break;
                    case "gvExposurePropSec":
                        strChaildGridId = "gvExposurePropSecChildGrid";
                        strTaskID = "lblExposurePropSecTask";
                        break;
                    case "gvExposureDPD":
                        strChaildGridId = "gvExposureDPDChildGrid";
                        strTaskID = "lblExposureDPDTask";
                        break;
                    case "gvExposureCustomer":
                        strChaildGridId = "gvExposureCustomerChildGrid";
                        strTaskID = "lblExposureCustomerTask";
                        break;
                   
                }

                GridView gvChild = (GridView)e.Row.FindControl(strChaildGridId);
                Label lblTask;
                lblTask = (Label)e.Row.FindControl(strTaskID);
                string strTask = lblTask.Text;
                //if (e.Row.RowIndex != (ExposureRLCMTableRows - 1))
                //{
                    gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, strTask);
                    gvChild.DataBind();
                //}
                //else
                //{
                //    gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, "Monthly Review Complete");
                //    gvChild.DataBind();
                //}
            }
        }
    }

    /// <summary>
    /// Grid View ACI Management RLCM Data RowBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACIManagementRLCM_RowDataBound(object sender, GridViewRowEventArgs e)
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
                GridView gvChild = (GridView)e.Row.FindControl("gvACIChildGrid");

                Label lblTask;
                lblTask = (Label)e.Row.FindControl("lblACITask");
                string strTask = lblTask.Text;
                if (e.Row.RowIndex != (ACIRLCMTableRows - 1))
                {
                    gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, "Change Request/Service Request");
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
        //used for "gvChildGrid", "gvClaimInfoChildGrid" so DO NOT CHANGE controls ID
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkStatus = (CheckBox)e.Row.FindControl("chkStatus");
            chkStatus.Checked = DataBinder.Eval(e.Row.DataItem, "Status") == DBNull.Value ? false : Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Status"));

            if (((GridView)sender).ID == "gvChildGrid")
            {
                CheckBox chkRequest_Deleted = (CheckBox)e.Row.FindControl("chkRequest_Deleted");
                chkRequest_Deleted.Checked = DataBinder.Eval(e.Row.DataItem, "Request_Deleted").ToString() == "" ? false : true;
            }

            if (e.Row.FindControl("lnkIdentifier") != null)
            {
                System.Web.UI.HtmlControls.HtmlAnchor a1 = (System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("lnkIdentifier");
            }
        }
    }

    /// <summary>
    /// SLT Child Grid Data RowBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSLTChildGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkStatus = (CheckBox)e.Row.FindControl("chkSLTStatus");
            chkStatus.Checked = DataBinder.Eval(e.Row.DataItem, "Status") == DBNull.Value ? false : Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Status"));
            if (e.Row.FindControl("lnkIdentifier") != null)
            {
                System.Web.UI.HtmlControls.HtmlAnchor a1 = (System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("lnkIdentifier");
            }
        }
    }

    /// <summary>
    /// Exposure Child Grid Data RowBound Event :: Here Exposure and it's submenu child grid's data rowbound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExposureChildGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkStatus = (CheckBox)e.Row.FindControl("chkExposureStatus");
            chkStatus.Checked = DataBinder.Eval(e.Row.DataItem, "Status") == DBNull.Value ? false : Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Status"));
            if (e.Row.FindControl("lnkIdentifier") != null)
            {
                System.Web.UI.HtmlControls.HtmlAnchor a1 = (System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("lnkIdentifier");
            }
        }
    }

    /// <summary>
    /// ACI Management Child Grid Data RowBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACIChildGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkStatus = (CheckBox)e.Row.FindControl("chkACIStatus");
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
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = true;
        pnlGrid.Visible = false;
    }

    /// <summary>
    /// Handles Save click of Claim submenu's save click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string checkedIDs = string.Empty, uncheckedIDs = string.Empty, strChildGridID = string.Empty, strPanel=string.Empty, strRequestChecked = string.Empty;
        bool chkMonthlyReviewChecked = false;
        string strSenderButtonId = ((Button)sender).ID;
        GridView gvTemp = null;

        switch (strSenderButtonId)
        {
            case "btnClaimInfoSave":
                strChildGridID = "gvClaimInfoChildGrid";
                strPanel = "2";
                gvTemp = gvClaimInfo;
                break;
            case "btnSave":
                strChildGridID = "gvChildGrid";
                strPanel = "1";
                gvTemp = gvClaimRLCM;
                break;
            case "btnClaimIncidentSave":
                strChildGridID = "gvClaimIncidentChildGrid";
                strPanel = "3";
                gvTemp = gvClaimIncident;
                break;
        }

        if (gvTemp != null)
        {
            foreach (GridViewRow gvRLCMRow in gvTemp.Rows)
            {
                if (gvRLCMRow.RowType == DataControlRowType.DataRow)
                {
                    GridView gvChild = (GridView)gvRLCMRow.FindControl(strChildGridID);
                    if (gvChild != null)
                        foreach (GridViewRow gvChildRow in gvChild.Rows)
                        {
                            CheckBox chkStatus = (CheckBox)gvChildRow.FindControl("chkStatus");
                            CheckBox chkRequest_Deleted = (CheckBox)gvChildRow.FindControl("chkRequest_Deleted");
                            //if(chkStatus.Checked)
                            //{
                            HiddenField hdnStatus = (HiddenField)gvChildRow.FindControl("hdnStatus");
                            Control c = gvChildRow.Cells[0].FindControl("lnkIdentifier");

                            //if (gvChildRow.Cells.Count > 0 && gvChildRow.Cells[0].Controls.Count > 0)
                            //{
                            //    DataBoundLiteralControl lnkIdentifier = (DataBoundLiteralControl)gvChildRow.Cells[0].Controls[0];
                            //    if (lnkIdentifier.Text.Contains("Monthly Review Complete"))
                            //        chkMonthlyReviewChecked = chkStatus.Checked;
                            //}

                            if (hdnStatus != null)
                            {
                                if (chkStatus.Checked)
                                    checkedIDs += hdnStatus.Value + ",";
                                else
                                    uncheckedIDs += hdnStatus.Value + ",";

                                if (chkRequest_Deleted.Checked)
                                    strRequestChecked += hdnStatus.Value + ",";                                
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
        clsRLCM_QA_QC.RequestUpdateStatus(strRequestChecked, Convert.ToString(clsSession.UserID));
        clsRLCM_QA_QC.RLCM_QA_QC_CompleteInsertUpdateStatus(rlcm, year, month, chkMonthlyReviewChecked, Convert.ToString(clsSession.UserID));
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + strPanel + ");", true);
    }

    /// <summary>
    /// Handles SLT menu screen save click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSLTSave_Click(object sender, EventArgs e)
    {
        string checkedIDs = string.Empty, uncheckedIDs = string.Empty;
        bool chkMonthlyReviewChecked = false;
        foreach (GridViewRow gvRLCMRow in gvSLTRLCM.Rows)
        {
            if (gvRLCMRow.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = (GridView)gvRLCMRow.FindControl("gvSLTChildGrid");
                if (gvChild != null)
                    foreach (GridViewRow gvChildRow in gvChild.Rows)
                    {
                        CheckBox chkStatus = (CheckBox)gvChildRow.FindControl("chkSLTStatus");
                        //if(chkStatus.Checked)
                        //{
                        HiddenField hdnStatus = (HiddenField)gvChildRow.FindControl("hdnSLTStatus");
                        Control c = gvChildRow.Cells[0].FindControl("lnkIdentifier");

                        //if (gvChildRow.Cells.Count > 0 && gvChildRow.Cells[0].Controls.Count > 0)
                        //{
                        //    DataBoundLiteralControl lnkIdentifier = (DataBoundLiteralControl)gvChildRow.Cells[0].Controls[0];
                        //    if (lnkIdentifier.Text.Contains("Monthly Review Complete"))
                        //        chkMonthlyReviewChecked = chkStatus.Checked;
                        //}

                        if (hdnStatus != null)
                        {
                            if (chkStatus.Checked)
                                checkedIDs += hdnStatus.Value + ",";
                            else
                                uncheckedIDs += hdnStatus.Value + ",";
                        }
                        //}
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
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
    }

    /// <summary>
    /// Handles Save click of Exposure submenu's save click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExposureSave_Click(object sender, EventArgs e)
    {
        string checkedIDs = string.Empty, uncheckedIDs = string.Empty, strChildGridID = string.Empty, strPanel = string.Empty; ;
        bool chkMonthlyReviewChecked = false;
        string strSenderButtonId = ((Button)sender).ID;
        GridView gvTemp = null;

        switch (strSenderButtonId)
        {
            case "btnExposureSave":
                strChildGridID = "gvExposureChildGrid";
                strPanel = "5";
                gvTemp = gvExposureRLCM;
                break;
            case "btnExposurePropSecSave":
                strChildGridID = "gvExposurePropSecChildGrid";
                strPanel = "6";
                gvTemp = gvExposurePropSec;
                break;
            case "btnExposureDPDSave":
                strChildGridID = "gvExposureDPDChildGrid";
                strPanel = "7";
                gvTemp = gvExposureDPD;
                break;
            case "btnExposureCustomerSave":
                strChildGridID = "gvExposureCustomerChildGrid";
                strPanel = "8";
                gvTemp = gvExposureCustomer;
                break;
        }

        if (gvTemp != null)
        {
            foreach (GridViewRow gvRLCMRow in gvTemp.Rows)
            {
                if (gvRLCMRow.RowType == DataControlRowType.DataRow)
                {
                    GridView gvChild = (GridView)gvRLCMRow.FindControl(strChildGridID);
                    if (gvChild != null)
                        foreach (GridViewRow gvChildRow in gvChild.Rows)
                        {
                            CheckBox chkStatus = (CheckBox)gvChildRow.FindControl("chkExposureStatus");
                            //if(chkStatus.Checked)
                            //{
                            HiddenField hdnStatus = (HiddenField)gvChildRow.FindControl("hdnExposureStatus");
                            Control c = gvChildRow.Cells[0].FindControl("lnkIdentifier");

                            //if (gvChildRow.Cells.Count > 0 && gvChildRow.Cells[0].Controls.Count > 0)
                            //{
                            //    DataBoundLiteralControl lnkIdentifier = (DataBoundLiteralControl)gvChildRow.Cells[0].Controls[0];
                            //    if (lnkIdentifier.Text.Contains("Monthly Review Complete"))
                            //        chkMonthlyReviewChecked = chkStatus.Checked;
                            //}

                            if (hdnStatus != null)
                            {
                                if (chkStatus.Checked)
                                    checkedIDs += hdnStatus.Value + ",";
                                else
                                    uncheckedIDs += hdnStatus.Value + ",";
                            }
                            //}
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
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel("+strPanel+");", true);
    }

    protected void btnACISave_Click(object sender, EventArgs e)
    {
        string checkedIDs = string.Empty, uncheckedIDs = string.Empty;
        bool chkMonthlyReviewChecked = false;
        foreach (GridViewRow gvRLCMRow in gvACIManagementRLCM.Rows)
        {
            if (gvRLCMRow.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = (GridView)gvRLCMRow.FindControl("gvACIChildGrid");
                if (gvChild != null)
                    foreach (GridViewRow gvChildRow in gvChild.Rows)
                    {
                        CheckBox chkStatus = (CheckBox)gvChildRow.FindControl("chkACIStatus");
                        //if(chkStatus.Checked)
                        //{
                        HiddenField hdnStatus = (HiddenField)gvChildRow.FindControl("hdnACIStatus");
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
                        //}
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
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
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

}