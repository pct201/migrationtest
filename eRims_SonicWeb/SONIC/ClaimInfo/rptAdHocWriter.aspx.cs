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
using ERIMS.DAL;

public partial class SONIC_ClaimInfo_rptAdHocWriter : clsBasePage
{
    #region Variables
    ArrayList arColumnList = new ArrayList();

    #endregion

    #region Properties

    public string Claim_Type
    {
        get { return ViewState["Claim_Type"].ToString(); }
        set { ViewState["Claim_Type"] = value; }
    }

    public string Regional
    {
        get { return clsGeneral.IsNull(ViewState["Regional"]) ? string.Empty : ViewState["Regional"].ToString(); }
        set { ViewState["Regional"] = value; }
    }

    public decimal CurrentEmployee
    {
        get { return clsGeneral.IsNull(ViewState["CurrentEmployee"]) ? 0 : Convert.ToDecimal(ViewState["CurrentEmployee"]); }
        set { ViewState["CurrentEmployee"] = value; }
    }

    #endregion

    #region Page Events

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //lstClaimOpened.Attributes.Add("onclick", "javascript:CheckList('" + lstClaimOpened.ClientID.Replace('_', '$') + "','" + lblDateOpenedFrom.ClientID + "','" + lblDateOpenedTo.ClientID + "','" + txtDate_Opened_To.ClientID + "','" + imgDate_Opened_To.ClientID + "');");
        //lstClaimClosed.Attributes.Add("onclick", "javascript:CheckList('" + lstClaimClosed.ClientID.Replace('_', '$') + "','" + lblDateClosedFrom.ClientID + "','" + lblDateClosedTo.ClientID + "','" + txtDateClosedTo.ClientID + "','" + imgDate_Closed_To.ClientID + "');");
        //lstClaimIncident.Attributes.Add("onclick", "javascript:CheckList('" + lstClaimIncident.ClientID.Replace('_', '$') + "','" + lblDateIncidentFrom.ClientID + "','" + lblDateIncidentTo.ClientID + "','" + txtDate_Incident_To.ClientID + "','" + imgDate_Incident_To.ClientID + "');");
        //lstClaimValued.Attributes.Add("onclick", "javascript:CheckList('" + lstClaimValued.ClientID.Replace('_', '$') + "','" + lblDateValuedFrom.ClientID + "','" + lblDateValuedTo.ClientID + "','" + txtDateValuedTo.ClientID + "','" + imgDate_Valued_To.ClientID + "');");
        //lstClaimReserve.Attributes.Add("onclick", "javascript:CheckList('" + lstClaimReserve.ClientID.Replace('_', '$') + "','" + lblDateReserveFrom.ClientID + "','" + lblDateReserveTo.ClientID + "','" + txtDate_Reserve_To.ClientID + "','" + imgDate_Reserve_To.ClientID + "');");
        //lstClaimPayment.Attributes.Add("onclick", "javascript:CheckList('" + lstClaimPayment.ClientID.Replace('_', '$') + "','" + lblDatePaymentFrom.ClientID + "','" + lblDatePaymentTo.ClientID + "','" + txtDatePaymentTo.ClientID + "','" + imgDate_Payment_To.ClientID + "');");

        chkNatureofInjury.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstNatureofInjury.ClientID + "');");
        chkCoverageState.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstCoverageState.ClientID + "');");
        chkBodypart.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstBodyPart.ClientID + "');");
        chkCause.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstCause.ClientID + "');");
        chkLocation.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstLocation.ClientID + "');");
        chkClaimStatus.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstClaimStatus.ClientID + "');");
        chkRegion.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstRegion.ClientID + "');");
        chkMarket.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstMarket.ClientID + "');");
        chkSelUnSelFields.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstOutputFields.ClientID + "');");
        chkSonicCauseCode.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstSonicCauseCode.ClientID + "');");
        chkClaimSubStatus.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstClaimSubStatus.ClientID + "');");

        btnSubmit.Attributes.Add("onclick", "return Validate('S');");
        btnExportExcel.Attributes.Add("onclick", "return Validate('E');");

        if (!IsPostBack)
        {
            this.Claim_Type = "ALL";

            FillCriteria();
            setLocationSelected();
            FillFields();
            SetDefaults();
            ShowReportCriteria();
            BindReports();
            //Fill Market
            ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
        }
        else
        {
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

            // if postback by Confirmation dialog then save record
            if (eventTarget == "UserConfirmationPostBack")
            {
                if (eventArgument == "true")
                    SaveReport();
                else
                    hdnReportId.Value = "0";
            }

        }
    }

    #endregion

    #region Control Events

    /// <summary>
    ///  Hanlde claim type changed event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkClaimType_CheckedChanged(object sender, EventArgs e)
    {
        // show and hide criteria as per Claim Type is selected
        ShowReportCriteria();
        String strClaimType = string.Empty;

        // set Claim Type
        if (chkWC.Checked)
            strClaimType += "WC";
        if (chkAL.Checked)
            strClaimType += "AL";
        if (chkNS.Checked)
            strClaimType += "NS";
        if (chkPL.Checked)
            strClaimType += "PL";

        if (strClaimType == "")
            this.Claim_Type = "ALL";
        else
            this.Claim_Type = strClaimType;

        // Fill all listboxes
        FillFields();

        // Bind report drop down
        BindReports();
        // reset filter criteria
        Reset();
        setLocationSelected();
    }

    /// <summary>
    /// Handle Save report Click event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Fetch record by report Name 
        DataTable dtreport = AdhocReport.IsReportNameExists(txtReportName.Text.Trim(), Convert.ToDecimal(ddlReports.SelectedItem.Value), this.Claim_Type).Tables[0];

        // check if same report name is exists or not.
        if (dtreport.Rows.Count > 0)
        {
            // Save Report ID for overwrite
            hdnReportId.Value = dtreport.Rows[0]["ReportId"].ToString();
            String confirmMessage = "Are you sure you want to overwrite the existing report " + txtReportName.Text.Trim() + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", "__doPostBack('UserConfirmationPostBack', window.confirm('" + confirmMessage + "'));", true);
        }
        else
            SaveReport();
    }

    /// <summary>
    /// Save Record for Ad-Report Name
    /// </summary>
    private void SaveReport()
    {
        //Sort Fields
        String strOrderBy = string.Empty;
        //Sort Fields
        if (Request.Form[lstFirstSort.UniqueID] != null)
        {
            if (strOrderBy == string.Empty)
                strOrderBy = Request.Form[lstFirstSort.UniqueID].ToString();
            else
                strOrderBy = strOrderBy + "," + Request.Form[lstFirstSort.UniqueID].ToString();
        }
        if (Request.Form[lstSecondSort.UniqueID] != null)
        {
            if (strOrderBy == string.Empty)
                strOrderBy = Request.Form[lstSecondSort.UniqueID].ToString();
            else
                strOrderBy = strOrderBy + "," + Request.Form[lstSecondSort.UniqueID].ToString();
        }
        if (Request.Form[lstThirdSort.UniqueID] != null)
        {
            if (strOrderBy == string.Empty)
                strOrderBy = Request.Form[lstThirdSort.UniqueID].ToString();
            else
                strOrderBy = strOrderBy + "," + Request.Form[lstThirdSort.UniqueID].ToString();
        }

        //Output Fields
        String strShowFields = "";
        if (Request.Form[lstOutputFields.UniqueID] != null)
            strShowFields = Request.Form[lstOutputFields.UniqueID].ToString();

        AdhocReport objAdhocReport = new AdhocReport();
        objAdhocReport.ClaimOpenCriteria = lstClaimOpened.SelectedValue;
        if (txtDate_Opened_From.Text != string.Empty)
            objAdhocReport.ClaimOpenStartDate = Convert.ToDateTime(txtDate_Opened_From.Text);
        if (txtDate_Opened_To.Text != string.Empty)
            objAdhocReport.ClaimOpenEndDate = Convert.ToDateTime(txtDate_Opened_To.Text);

        objAdhocReport.ClaimCloseCriteria = lstClaimClosed.SelectedValue;
        if (txtDateClosedFrom.Text != string.Empty)
            objAdhocReport.ClaimCloseStartDate = Convert.ToDateTime(txtDateClosedFrom.Text);
        if (txtDateClosedTo.Text != string.Empty)
            objAdhocReport.ClaimCloseEndDate = Convert.ToDateTime(txtDateClosedTo.Text);

        objAdhocReport.DOICriteria = lstClaimIncident.SelectedValue;
        if (txtDate_Incident_From.Text != string.Empty)
            objAdhocReport.DOIStart = Convert.ToDateTime(txtDate_Incident_From.Text);
        if (txtDate_Incident_To.Text != string.Empty)
            objAdhocReport.DOIEnd = Convert.ToDateTime(txtDate_Incident_To.Text);

        objAdhocReport.ValueAsOfDateCriteria = lstClaimValued.SelectedValue;
        if (txtDateValuedFrom.Text != string.Empty)
            objAdhocReport.ValueAsOfDateStartDate = Convert.ToDateTime(txtDateValuedFrom.Text);
        //if (txtDateValuedTo.Text != string.Empty)
        //    objAdhocReport.ValueAsOfDateEndDate = Convert.ToDateTime(txtDateValuedTo.Text);

        objAdhocReport.ClaimReserveCriteria = lstClaimReserve.SelectedValue;
        if (txtDate_Reserve_From.Text != string.Empty)
            objAdhocReport.ClaimReserveStartDate = Convert.ToDateTime(txtDate_Reserve_From.Text);
        if (txtDate_Reserve_To.Text != string.Empty)
            objAdhocReport.ClaimReserveEndDate = Convert.ToDateTime(txtDate_Reserve_To.Text);

        objAdhocReport.ClaimPaymentCriteria = lstClaimPayment.SelectedValue;
        if (txtDatePaymentFrom.Text != string.Empty)
            objAdhocReport.ClaimPaymentStartDate = Convert.ToDateTime(txtDatePaymentFrom.Text);
        if (txtDatePaymentTo.Text != string.Empty)
            objAdhocReport.ClaimPaymentEndDate = Convert.ToDateTime(txtDatePaymentTo.Text);

        objAdhocReport.DateRestrictedBeginCriteria = lstDateWorkBegin.SelectedValue;
        if (txtRestricted_BeginFrom.Text != string.Empty)
            objAdhocReport.DateRestrictedBeginStartDate = Convert.ToDateTime(txtRestricted_BeginFrom.Text);
        if (txtRestricted_BeginTo.Text != string.Empty)
            objAdhocReport.DateRestrictedBeginEndDate = Convert.ToDateTime(txtRestricted_BeginTo.Text);

        objAdhocReport.DateRestrictedEndCriteria = lstDateWorkEnd.SelectedValue;
        if (txtRestricted_EndFrom.Text != string.Empty)
            objAdhocReport.DateRestrictedEndStartDate = Convert.ToDateTime(txtRestricted_EndFrom.Text);
        if (txtRestricted_EndTo.Text != string.Empty)
            objAdhocReport.DateRestrictedEndEndDate = Convert.ToDateTime(txtRestricted_EndTo.Text);

        objAdhocReport.OStatus = Request.Form[lstClaimStatus.UniqueID];
        objAdhocReport.CoverageState = Request.Form[lstCoverageState.UniqueID];
        objAdhocReport.Location = Request.Form[lstLocation.UniqueID];
        objAdhocReport.Region = Request.Form[lstRegion.UniqueID];
        objAdhocReport.Market = Request.Form[lstMarket.UniqueID];
        objAdhocReport.BodyPart = Request.Form[lstBodyPart.UniqueID];
        objAdhocReport.Cause = Request.Form[lstCause.UniqueID];
        objAdhocReport.NatureOfInjury = Request.Form[lstNatureofInjury.UniqueID];
        objAdhocReport.SonicCauseCode = Request.Form[lstSonicCauseCode.UniqueID];
        objAdhocReport.ClaimSubStaus = Request.Form[lstClaimSubStatus.UniqueID];
        objAdhocReport.MPCriteria = rdbLstMP.SelectedValue;
        if (txtMP1.Text != string.Empty)
            objAdhocReport.MPStartAmount = Convert.ToDecimal(txtMP1.Text);
        if (txtMP2.Text != string.Empty)
            objAdhocReport.MPEndAmount = Convert.ToDecimal(txtMP2.Text);

        objAdhocReport.MICriteria = rdbLstMI.SelectedValue;
        if (txtMI1.Text != string.Empty)
            objAdhocReport.MIStartAmount = Convert.ToDecimal(txtMI1.Text);
        if (txtMI2.Text != string.Empty)
            objAdhocReport.MIEndAmount = Convert.ToDecimal(txtMI2.Text);

        objAdhocReport.EPCriteria = rdbLstEP.SelectedValue;
        if (txtEP1.Text != string.Empty)
            objAdhocReport.EPStartAmount = Convert.ToDecimal(txtEP1.Text);
        if (txtEP2.Text != string.Empty)
            objAdhocReport.EPEndAmount = Convert.ToDecimal(txtEP2.Text);

        objAdhocReport.EICriteria = rdbLstEI.SelectedValue;
        if (txtEI1.Text != string.Empty)
            objAdhocReport.EIStartAmount = Convert.ToDecimal(txtEI1.Text);
        if (txtEI2.Text != string.Empty)
            objAdhocReport.EIEndAmount = Convert.ToDecimal(txtEI2.Text);

        objAdhocReport.IPCriteria = rdbLstIP.SelectedValue;
        if (txtIP1.Text != string.Empty)
            objAdhocReport.IPStartAmount = Convert.ToDecimal(txtIP1.Text);
        if (txtIP2.Text != string.Empty)
            objAdhocReport.IPEndAmount = Convert.ToDecimal(txtIP2.Text);

        objAdhocReport.IICriteria = rdbLstII.SelectedValue;
        if (txtII1.Text != string.Empty)
            objAdhocReport.IIStartAmount = Convert.ToDecimal(txtII1.Text);
        if (txtII2.Text != string.Empty)
            objAdhocReport.IIEndAmount = Convert.ToDecimal(txtII2.Text);

        objAdhocReport.TPCriteria = rdbLstTP.SelectedValue;
        if (txtTP1.Text != string.Empty)
            objAdhocReport.TPStartAmount = Convert.ToDecimal(txtTP1.Text);
        if (txtTP2.Text != string.Empty)
            objAdhocReport.TPEndAmount = Convert.ToDecimal(txtTP2.Text);

        objAdhocReport.TICriteria = rdbLstTI.SelectedValue;
        if (txtTI1.Text != string.Empty)
            objAdhocReport.TIStartAmount = Convert.ToDecimal(txtTI1.Text);
        if (txtTI2.Text != string.Empty)
            objAdhocReport.TIEndAmount = Convert.ToDecimal(txtTI2.Text);

        objAdhocReport.TOCriteria = rdbLstTO.SelectedValue;
        if (txtTO1.Text != string.Empty)
            objAdhocReport.TOStartAmount = Convert.ToDecimal(txtTO1.Text);
        if (txtTO2.Text != string.Empty)
            objAdhocReport.TOEndAmount = Convert.ToDecimal(txtTO2.Text);

        objAdhocReport.MOCriteria = rdbLstMO.SelectedValue;
        if (txtMO1.Text != string.Empty)
            objAdhocReport.MOStartAmount = Convert.ToDecimal(txtMO1.Text);
        if (txtMO2.Text != string.Empty)
            objAdhocReport.MOEndAmount = Convert.ToDecimal(txtMO2.Text);

        objAdhocReport.EOCriteria = rdbLstEO.SelectedValue;
        if (txtEO1.Text != string.Empty)
            objAdhocReport.EOStartAmount = Convert.ToDecimal(txtEO1.Text);
        if (txtEO2.Text != string.Empty)
            objAdhocReport.EOEndAmount = Convert.ToDecimal(txtEO2.Text);

        objAdhocReport.IOCriteria = rdbLstIO.SelectedValue;
        if (txtIO1.Text != string.Empty)
            objAdhocReport.IOStartAmount = Convert.ToDecimal(txtIO1.Text);
        if (txtII2.Text != string.Empty)
            objAdhocReport.IOEndAmount = Convert.ToDecimal(txtIO2.Text);

        //if (rdoALClaimOrigin.SelectedIndex > -1)
        //{
        //    objAdhocReport.AL_Claim_Origin = rdoALClaimOrigin.SelectedValue;
        //}

        // code done by hiren
        string strgetClaimorgin = "";
        if (rdoALClaimOrigin.SelectedIndex > -1)
        {
            for (int i = 0; i < rdoALClaimOrigin.Items.Count; i++)
            {
                if (rdoALClaimOrigin.Items[i].Selected == true)
                {
                    strgetClaimorgin += rdoALClaimOrigin.Items[i].Value + ",";
                }
            }
            strgetClaimorgin = strgetClaimorgin.TrimEnd(',');

        }
        objAdhocReport.AL_Claim_Origin = Convert.ToString(strgetClaimorgin);
        objAdhocReport.SortFields = strOrderBy;
        objAdhocReport.OutputFields = strShowFields;
        objAdhocReport.ShowGrandTotal = chkGrand.Checked ? "Y" : "N";
        objAdhocReport.ShowSubTotal = "N";
        objAdhocReport.Claim_Type = this.Claim_Type;

        objAdhocReport.OutputFieldsOrder = hdnOutputList.Value;
        objAdhocReport.ReportName = txtReportName.Text.Trim();
        objAdhocReport.ReportId = hdnReportId.Value == string.Empty ? 0 : Convert.ToInt32(hdnReportId.Value);
        objAdhocReport.UpdatedDate = DateTime.Now;
        objAdhocReport.Indicator = lstIndicator.SelectedValue;
        objAdhocReport.FullFinalClincher = rdoFull_Final_Clincher.SelectedValue;
        objAdhocReport.LineofCoverage = "";
        if (rbnAL.Checked == true)
            objAdhocReport.LineofCoverage = "AL";
        if (rbnAU.Checked == true)
            objAdhocReport.LineofCoverage = objAdhocReport.LineofCoverage == "" ? "AU" : objAdhocReport.LineofCoverage + ",AU";
        if (rbnGK.Checked == true)
            objAdhocReport.LineofCoverage = objAdhocReport.LineofCoverage == "" ? "GK" : objAdhocReport.LineofCoverage + ",GK";

        hdnReportId.Value = objAdhocReport.InsertUpdate().ToString();

        // Fill report dropdown
        BindReports();
        setOutputfiedls(hdnOutputList.Value);

        // get list item for Report Name
        ListItem liReport = ddlReports.Items.FindByValue(hdnReportId.Value.ToString());

        // Set Selected Report Name in drop-down
        if (liReport != null)
        {
            liReport.Selected = true;
        }

    }

    /// <summary>
    /// Handle Clear button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        // reset all filter criteria
        Reset();
        // Bind report Name drop-down
        BindReports();
        ddlReports.SelectedIndex = 0;
    }

    /// <summary>
    /// Hanlde report Name Drop-down selected index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlReports_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if Report Name is selected or not
        if (ddlReports.SelectedIndex > 0)
        {
            // reset all filter criteria
            Reset();
            // Bind all filter criteria as per Report Type is selected
            BindAllData();
            btnDeleteReport.Enabled = true;
        }
        else
            btnDeleteReport.Enabled = false;
    }

    /// <summary>
    /// Handle export To excel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        String strShowFields = "";
        String strOrderBy = string.Empty;

        //Sort Fields
        if (Request.Form[lstFirstSort.UniqueID] != null)
        {
            if (strOrderBy == string.Empty)
                strOrderBy = Request.Form[lstFirstSort.UniqueID].ToString();
            else
                strOrderBy = strOrderBy + "," + Request.Form[lstFirstSort.UniqueID].ToString();
        }
        if (Request.Form[lstSecondSort.UniqueID] != null)
        {
            if (strOrderBy == string.Empty)
                strOrderBy = Request.Form[lstSecondSort.UniqueID].ToString();
            else
                strOrderBy = strOrderBy + "," + Request.Form[lstSecondSort.UniqueID].ToString();
        }
        if (Request.Form[lstThirdSort.UniqueID] != null)
        {
            if (strOrderBy == string.Empty)
                strOrderBy = Request.Form[lstThirdSort.UniqueID].ToString();
            else
                strOrderBy = strOrderBy + "," + Request.Form[lstThirdSort.UniqueID].ToString();
        }


        // Concant all output fields selected by user
        for (int i = 0; i < lstOutputFields.Items.Count; i++)
        {
            strShowFields += lstOutputFields.Items[i].Value + ",";
        }
        strShowFields = strShowFields.TrimEnd(new char[] { ',' });
        //}



        AdhocReport objAdhocReport = new AdhocReport();
        objAdhocReport.ClaimOpenCriteria = lstClaimOpened.SelectedValue;
        if (txtDate_Opened_From.Text != string.Empty)
            objAdhocReport.ClaimOpenStartDate = Convert.ToDateTime(txtDate_Opened_From.Text);
        if (txtDate_Opened_To.Text != string.Empty)
            objAdhocReport.ClaimOpenEndDate = Convert.ToDateTime(txtDate_Opened_To.Text);

        objAdhocReport.ClaimCloseCriteria = lstClaimClosed.SelectedValue;
        if (txtDateClosedFrom.Text != string.Empty)
            objAdhocReport.ClaimCloseStartDate = Convert.ToDateTime(txtDateClosedFrom.Text);
        if (txtDateClosedTo.Text != string.Empty)
            objAdhocReport.ClaimCloseEndDate = Convert.ToDateTime(txtDateClosedTo.Text);

        objAdhocReport.DOICriteria = lstClaimIncident.SelectedValue;
        if (txtDate_Incident_From.Text != string.Empty)
            objAdhocReport.DOIStart = Convert.ToDateTime(txtDate_Incident_From.Text);
        if (txtDate_Incident_To.Text != string.Empty)
            objAdhocReport.DOIEnd = Convert.ToDateTime(txtDate_Incident_To.Text);

        objAdhocReport.ValueAsOfDateCriteria = lstClaimValued.SelectedValue;
        if (txtDateValuedFrom.Text != string.Empty)
            objAdhocReport.ValueAsOfDateStartDate = Convert.ToDateTime(txtDateValuedFrom.Text);
        //if (txtDateValuedTo.Text != string.Empty)
        //    objAdhocReport.ValueAsOfDateEndDate = Convert.ToDateTime(txtDateValuedTo.Text);

        objAdhocReport.ClaimReserveCriteria = lstClaimReserve.SelectedValue;
        if (txtDate_Reserve_From.Text != string.Empty)
            objAdhocReport.ClaimReserveStartDate = Convert.ToDateTime(txtDate_Reserve_From.Text);
        if (txtDate_Reserve_To.Text != string.Empty)
            objAdhocReport.ClaimReserveEndDate = Convert.ToDateTime(txtDate_Reserve_To.Text);

        objAdhocReport.ClaimPaymentCriteria = lstClaimPayment.SelectedValue;
        if (txtDatePaymentFrom.Text != string.Empty)
            objAdhocReport.ClaimPaymentStartDate = Convert.ToDateTime(txtDatePaymentFrom.Text);
        if (txtDatePaymentTo.Text != string.Empty)
            objAdhocReport.ClaimPaymentEndDate = Convert.ToDateTime(txtDatePaymentTo.Text);

        objAdhocReport.DateRestrictedBeginCriteria = lstDateWorkBegin.SelectedValue;
        if (txtRestricted_BeginFrom.Text != string.Empty)
            objAdhocReport.DateRestrictedBeginStartDate = Convert.ToDateTime(txtRestricted_BeginFrom.Text);
        if (txtRestricted_BeginTo.Text != string.Empty)
            objAdhocReport.DateRestrictedBeginEndDate = Convert.ToDateTime(txtRestricted_BeginTo.Text);

        objAdhocReport.DateRestrictedEndCriteria = lstDateWorkEnd.SelectedValue;
        if (txtRestricted_EndFrom.Text != string.Empty)
            objAdhocReport.DateRestrictedEndStartDate = Convert.ToDateTime(txtRestricted_EndFrom.Text);
        if (txtRestricted_EndTo.Text != string.Empty)
            objAdhocReport.DateRestrictedEndEndDate = Convert.ToDateTime(txtRestricted_EndTo.Text);

        if(Request.Form[lstClaimStatus.UniqueID] != null)
            objAdhocReport.OStatus = "'" + Request.Form[lstClaimStatus.UniqueID].Replace(",", "','") + "'";
        if (Request.Form[lstCoverageState.UniqueID] != null)
            objAdhocReport.CoverageState = "'" + Request.Form[lstCoverageState.UniqueID].Replace(",", "','") + "'";

        objAdhocReport.Location = Request.Form[lstLocation.UniqueID];

        if (Request.Form[lstRegion.UniqueID] != null)
            objAdhocReport.Region = "'" + Request.Form[lstRegion.UniqueID].Replace(",", "','") + "'";

        if (Request.Form[lstMarket.UniqueID] != null)
            objAdhocReport.Market = "'" + Request.Form[lstMarket.UniqueID].Replace(",", "','") + "'";

        if (Request.Form[lstBodyPart.UniqueID] != null)
            objAdhocReport.BodyPart = "'" + Request.Form[lstBodyPart.UniqueID].Replace(",", "','") + "'";
        if (Request.Form[lstCause.UniqueID] != null)
            objAdhocReport.Cause = "'" + Request.Form[lstCause.UniqueID].Replace(",", "','") + "'";
        if (Request.Form[lstNatureofInjury.UniqueID] != null)
            objAdhocReport.NatureOfInjury = "'" + Request.Form[lstNatureofInjury.UniqueID].Replace(",", "','") + "'";

        if (Request.Form[lstSonicCauseCode.UniqueID] != null)
            objAdhocReport.SonicCauseCode = "'" + Request.Form[lstSonicCauseCode.UniqueID].Replace(",", "','") + "'";

        objAdhocReport.MPCriteria = rdbLstMP.SelectedValue;
        if (txtMP1.Text != string.Empty)
            objAdhocReport.MPStartAmount = Convert.ToDecimal(txtMP1.Text);
        if (txtMP2.Text != string.Empty)
            objAdhocReport.MPEndAmount = Convert.ToDecimal(txtMP2.Text);

        objAdhocReport.MICriteria = rdbLstMI.SelectedValue;
        if (txtMI1.Text != string.Empty)
            objAdhocReport.MIStartAmount = Convert.ToDecimal(txtMI1.Text);
        if (txtMI2.Text != string.Empty)
            objAdhocReport.MIEndAmount = Convert.ToDecimal(txtMI2.Text);

        objAdhocReport.MOCriteria = rdbLstMO.SelectedValue;
        if (txtMO1.Text != string.Empty)
            objAdhocReport.MOStartAmount = Convert.ToDecimal(txtMO1.Text);
        if (txtMO2.Text != string.Empty)
            objAdhocReport.MOEndAmount = Convert.ToDecimal(txtMO2.Text);

        objAdhocReport.EPCriteria = rdbLstEP.SelectedValue;
        if (txtEP1.Text != string.Empty)
            objAdhocReport.EPStartAmount = Convert.ToDecimal(txtEP1.Text);
        if (txtEP2.Text != string.Empty)
            objAdhocReport.EPEndAmount = Convert.ToDecimal(txtEP2.Text);

        objAdhocReport.EICriteria = rdbLstEI.SelectedValue;
        if (txtEI1.Text != string.Empty)
            objAdhocReport.EIStartAmount = Convert.ToDecimal(txtEI1.Text);
        if (txtEI2.Text != string.Empty)
            objAdhocReport.EIEndAmount = Convert.ToDecimal(txtEI2.Text);

        objAdhocReport.EOCriteria = rdbLstEO.SelectedValue;
        if (txtEO1.Text != string.Empty)
            objAdhocReport.EOStartAmount = Convert.ToDecimal(txtEO1.Text);
        if (txtEO2.Text != string.Empty)
            objAdhocReport.EOEndAmount = Convert.ToDecimal(txtEO2.Text);

        objAdhocReport.IPCriteria = rdbLstIP.SelectedValue;
        if (txtIP1.Text != string.Empty)
            objAdhocReport.IPStartAmount = Convert.ToDecimal(txtIP1.Text);
        if (txtIP2.Text != string.Empty)
            objAdhocReport.IPEndAmount = Convert.ToDecimal(txtIP2.Text);

        objAdhocReport.IICriteria = rdbLstII.SelectedValue;
        if (txtII1.Text != string.Empty)
            objAdhocReport.IIStartAmount = Convert.ToDecimal(txtII1.Text);
        if (txtII2.Text != string.Empty)
            objAdhocReport.IIEndAmount = Convert.ToDecimal(txtII2.Text);

        objAdhocReport.IOCriteria = rdbLstIO.SelectedValue;
        if (txtIO1.Text != string.Empty)
            objAdhocReport.IOStartAmount = Convert.ToDecimal(txtIO1.Text);
        if (txtII2.Text != string.Empty)
            objAdhocReport.IOEndAmount = Convert.ToDecimal(txtIO2.Text);

        objAdhocReport.TPCriteria = rdbLstTP.SelectedValue;
        if (txtTP1.Text != string.Empty)
            objAdhocReport.TPStartAmount = Convert.ToDecimal(txtTP1.Text);
        if (txtTP2.Text != string.Empty)
            objAdhocReport.TPEndAmount = Convert.ToDecimal(txtTP2.Text);

        objAdhocReport.TICriteria = rdbLstTI.SelectedValue;
        if (txtTI1.Text != string.Empty)
            objAdhocReport.TIStartAmount = Convert.ToDecimal(txtTI1.Text);
        if (txtTI2.Text != string.Empty)
            objAdhocReport.TIEndAmount = Convert.ToDecimal(txtTI2.Text);

        objAdhocReport.TOCriteria = rdbLstTO.SelectedValue;
        if (txtTO1.Text != string.Empty)
            objAdhocReport.TOStartAmount = Convert.ToDecimal(txtTO1.Text);
        if (txtTO2.Text != string.Empty)
            objAdhocReport.TOEndAmount = Convert.ToDecimal(txtTO2.Text);

        //objAdhocReport.SortFields = strOrderBy;
        objAdhocReport.OutputFields = strShowFields;
        objAdhocReport.ShowGrandTotal = chkGrand.Checked ? "Y" : "N";
        objAdhocReport.ShowSubTotal = "N";
        objAdhocReport.Claim_Type = this.Claim_Type;
        objAdhocReport.Indicator = lstIndicator.SelectedValue;
        objAdhocReport.FullFinalClincher = rdoFull_Final_Clincher.SelectedValue;
        objAdhocReport.ClaimSubStaus = Request.Form[lstClaimSubStatus.UniqueID];
        //if (rdoALClaimOrigin.SelectedIndex > -1)
        //    objAdhocReport.AL_Claim_Origin = rdoALClaimOrigin.SelectedValue;

        string strgetClaimorgin = "";
        if (rdoALClaimOrigin.SelectedIndex > -1)
        {
            for (int i = 0; i < rdoALClaimOrigin.Items.Count; i++)
            {
                if (rdoALClaimOrigin.Items[i].Selected == true)
                {
                    strgetClaimorgin += "'" +rdoALClaimOrigin.Items[i].Value + "'" + ",";
                }
            }
            strgetClaimorgin = strgetClaimorgin.TrimEnd(',');

        }
        objAdhocReport.AL_Claim_Origin = strgetClaimorgin;
        

        objAdhocReport.LineofCoverage = "";

        if (rbnAL.Checked == true)
            objAdhocReport.LineofCoverage = "AL";
        if (rbnAU.Checked == true)
            objAdhocReport.LineofCoverage = objAdhocReport.LineofCoverage == "" ? "AU" : objAdhocReport.LineofCoverage + "','AU";
        if (rbnGK.Checked == true)
            objAdhocReport.LineofCoverage = objAdhocReport.LineofCoverage == "" ? "GK" : objAdhocReport.LineofCoverage + "','GK";
        
            

        DataSet dsReport = null;

        // Merge dataset if All or multiple report Type is selected
        if (this.Claim_Type == "ALL" || this.Claim_Type.Contains("WC"))
            dsReport = objAdhocReport.GetReportWC(DateTime.Today);

        if (this.Claim_Type == "ALL" || this.Claim_Type.Contains("NS"))
            if(dsReport == null)
                dsReport = objAdhocReport.GetReportNS(DateTime.Today);
            else
                dsReport.Merge(objAdhocReport.GetReportNS(DateTime.Today));

        if (this.Claim_Type == "ALL" || this.Claim_Type.Contains("AL"))
            if (dsReport == null)
                dsReport = objAdhocReport.GetReportAL(DateTime.Today);
            else
                dsReport.Merge(objAdhocReport.GetReportAL(DateTime.Today));

        if (this.Claim_Type == "ALL" || this.Claim_Type.Contains("PL"))
            if (dsReport == null)
                dsReport = objAdhocReport.GetReportPL(DateTime.Today);
            else
                dsReport.Merge(objAdhocReport.GetReportPL(DateTime.Today));

        // Add Total field to array List, So Check if User selects field for grand total
        arColumnList.Add("Medical Paid");
        arColumnList.Add("Medical Net Paid");
        arColumnList.Add("Medical Net Recovered");
        arColumnList.Add("Medical Incurred");
        arColumnList.Add("Medical Outstanding");
        arColumnList.Add("Medical Net Outstanding");
        arColumnList.Add("Expense Paid");
        arColumnList.Add("Expense Net Paid");
        arColumnList.Add("Expense Net Recovered");
        arColumnList.Add("Expense Incurred");
        arColumnList.Add("Expense Outstanding");
        arColumnList.Add("Expense Net Outstanding");
        arColumnList.Add("Indemnity Paid");
        arColumnList.Add("Indemnity Net Paid");
        arColumnList.Add("Indemnity Net Recovered");
        arColumnList.Add("Indemnity Incurred");
        arColumnList.Add("Indemnity Outstanding");
        arColumnList.Add("Indemnity Net Outstanding");
        arColumnList.Add("Total Paid");
        arColumnList.Add("Total Net Paid");
        arColumnList.Add("Total Net Outstanding");
        arColumnList.Add("Total Net Recovered");
        arColumnList.Add("Total Incurred");
        arColumnList.Add("Total Net Incurred");
        arColumnList.Add("Total Outstanding");
        arColumnList.Add("Total Recovered");

        DataTable dt = new DataTable();

        // check if user selects Sort by Fields then Sort Datatable field accordinglly 
        if (!string.IsNullOrEmpty(strOrderBy))
        {
            // Sort Dataview
            DataView dvReport = dsReport.Tables[0].DefaultView;
            dvReport.Sort = strOrderBy;
            dt = dvReport.ToTable();
            dsReport.Tables.Clear();
            dsReport.Tables.Add(dt);
            dt.Dispose();
        }

        {
            //Output Fields 
            if (Request.Form[lstOutputFields.UniqueID] != null)
                strShowFields = Request.Form[lstOutputFields.UniqueID].ToString();

            // get Final Output list colmn Name
            string[] strFinalOutput = strShowFields.Split(',');
            for (int i = 0; i < strFinalOutput.Length; i++)
            {
                int _intStrart = strFinalOutput[i].ToString().LastIndexOf('[') + 1;
                int _intEnd = strFinalOutput[i].ToString().LastIndexOf(']');
                strFinalOutput[i] = strFinalOutput[i].ToString().Substring(_intStrart, _intEnd - _intStrart);
            }

            // Bit Array for flag to remove column or not
            BitArray arry = new BitArray(dsReport.Tables[0].Columns.Count, false);
            int iColumn, jColumn;

            // set Flag for Output fields
            for (iColumn = 0; iColumn < strFinalOutput.Length; iColumn++)
            {
                for (jColumn = 0; jColumn < dsReport.Tables[0].Columns.Count; jColumn++)
                {
                    if (strFinalOutput[iColumn].ToUpper() == dsReport.Tables[0].Columns[jColumn].ToString().ToUpper())
                    {
                        arry[jColumn] = true;
                        break;
                    }
                }
            }

            // remove extra columns from Dataset
            for (iColumn = arry.Length - 1; iColumn >= 0; iColumn--)
            {
                if (arry[iColumn] == false)
                    dsReport.Tables[0].Columns.RemoveAt(iColumn);
            }

        }

        // Check if Grand total is selected or not
        if (chkGrand.Checked)
        {
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                DataTable dtReport = dsReport.Tables[0];
                DataRow drTotal = dtReport.NewRow();

                // loop for all columns to output fields
                for (int i = 0; i < dtReport.Columns.Count; i++)
                {
                    // compare column name in datatable and Arralist for include this Column in output field for not
                    if (arColumnList.Contains(dtReport.Columns[i].ColumnName))
                    {
                        // Calculate total for ith column in datatable
                        CalculateTotal(ref drTotal, ref dtReport, i);
                    }
                    else
                    {
                        drTotal[i] = DBNull.Value;
                    }
                }
                // add calculated total row To data table 
                dtReport.Rows.Add(drTotal);
                gvAdHoc.DataSource = dtReport;
            }
        }
        else
        {
            gvAdHoc.DataSource = dsReport;
        }

        // bind gridview
        gvAdHoc.DataBind();
        // show popup with message if repord not found else export grid to excel
        if (gvAdHoc.Rows.Count > 0)
        {
            GridViewExportUtil.ExportAdHoc("AdHocReport" + this.Claim_Type + ".xls", this.gvAdHoc);
        }
        else
        {
            string m_strScript = "alert('No Data Available For Selected Criteria.');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "NoRecords", m_strScript, true);
        }
    }

    /// <summary>
    /// Calculate Sum for the perticular column in passed datatable.
    /// </summary>
    /// <param name="drTotalRow"></param>
    /// <param name="dtReportData"></param>
    /// <param name="intColumnIndex"></param>
    private void CalculateTotal(ref DataRow drTotalRow, ref DataTable dtReportData, Int32 intColumnIndex)
    {
        decimal decTotal = 0;
        for (int i = 0; i < dtReportData.Rows.Count; i++)
        {
            // Check if value is exist for the column then add to total
            if (dtReportData.Rows[i][intColumnIndex] != DBNull.Value)
            {
                decTotal += Convert.ToDecimal(dtReportData.Rows[i][intColumnIndex]);
            }
        }
        drTotalRow[intColumnIndex] = decTotal;
    }

    /// <summary>
    /// handle row data bound event for Adhoc gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAdHoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Check Row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int iCell;
            // set vertical alignment for row.
            e.Row.Style.Add(HtmlTextWriterStyle.VerticalAlign, "top");

            // Check field header title if its contains  numerical fiels then format it into 2 point decimal
            for (iCell = 0; iCell < gvAdHoc.HeaderRow.Cells.Count; iCell++)
            {
                if (arColumnList.Contains(gvAdHoc.HeaderRow.Cells[iCell].Text))
                {
                    // Check if Its don't contains "&nbsp" means empty value
                    if (!string.IsNullOrEmpty(Server.HtmlDecode(e.Row.Cells[iCell].Text).Trim()))
                        e.Row.Cells[iCell].Text = string.Format("{0:C}", Convert.ToDouble(e.Row.Cells[iCell].Text));
                }

                // check header row title if it contains Date value then format date value
                if (gvAdHoc.HeaderRow.Cells[iCell].Text.Contains("Date"))
                {
                    // Check if Its don't contains "&nbsp" means empty value
                    if (!string.IsNullOrEmpty(Server.HtmlDecode(e.Row.Cells[iCell].Text).Trim()))
                        e.Row.Cells[iCell].Text = clsGeneral.FormatDBNullDateToDisplay(e.Row.Cells[iCell].Text);
                }
            }
        }
    }

    /// <summary>
    /// Handle Data bound event for gvAdhoc
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAdhoc_DataBound(object sender, EventArgs e)
    {
        // check if grand total is display then change the backgroud color and font
        if (chkGrand.Checked && gvAdHoc.Rows.Count > 0)
        {
            gvAdHoc.Rows[gvAdHoc.Rows.Count - 1].Font.Bold = true;
            gvAdHoc.Rows[gvAdHoc.Rows.Count - 1].ForeColor = System.Drawing.Color.WhiteSmoke;
            for (int i = 0; i < gvAdHoc.Rows[gvAdHoc.Rows.Count - 1].Cells.Count; i++)
            {
                gvAdHoc.Rows[gvAdHoc.Rows.Count - 1].Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#507CD1");
            }

        }
    }

    #endregion

    #region Radiobutton Events

    protected void rdbLstTP_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstTP.SelectedValue == "B")
        {
            lblTP2.Visible = true;
            txtTP2.Visible = true;

            lblTP2.Text = "To :$";
            lblTP1.Text = "From :$";
        }
        else
        {
            lblTP2.Visible = false;
            txtTP2.Visible = false;

            lblTP1.Text = rdbLstTP.SelectedItem.Text + ":$";
        }
    }
    protected void rdbLstTI_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstTI.SelectedValue == "B")
        {
            lblTI2.Visible = true;
            txtTI2.Visible = true;

            lblTI2.Text = "To :$";
            lblTI1.Text = "From :$";
        }
        else
        {
            lblTI2.Visible = false;
            txtTI2.Visible = false;

            lblTI1.Text = rdbLstTI.SelectedItem.Text + ":$";
        }
    }
    protected void rdbLstTO_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstTO.SelectedValue == "B")
        {
            lblTO2.Visible = true;
            txtTO2.Visible = true;

            lblTO2.Text = "To :$";
            lblTO1.Text = "From :$";
        }
        else
        {
            lblTO2.Visible = false;
            txtTO2.Visible = false;

            lblTO1.Text = rdbLstTO.SelectedItem.Text + ":$";
        }
    }

    protected void rdbLstMP_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstMP.SelectedValue == "B")
        {
            lblMP2.Visible = true;
            txtMP2.Visible = true;

            lblMP2.Text = "To :$";
            lblMP1.Text = "From :$";
        }
        else
        {
            lblMP2.Visible = false;
            txtMP2.Visible = false;

            lblMP1.Text = rdbLstMP.SelectedItem.Text + ":$";
        }
    }
    protected void rdbLstMI_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstMI.SelectedValue == "B")
        {
            lblMI2.Visible = true;
            txtMI2.Visible = true;

            lblMI2.Text = "To :$";
            lblMI1.Text = "From :$";
        }
        else
        {
            lblMI2.Visible = false;
            txtMI2.Visible = false;

            lblMI1.Text = rdbLstMI.SelectedItem.Text + ":$";
        }
    }

    protected void rdbLstEP_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstEP.SelectedValue == "B")
        {
            lblEP2.Visible = true;
            txtEP2.Visible = true;

            lblEP2.Text = "To :$";
            lblEP1.Text = "From :$";
        }
        else
        {
            lblEP2.Visible = false;
            txtEP2.Visible = false;

            lblEP1.Text = rdbLstEP.SelectedItem.Text + ":$";
        }
    }

    protected void rdbLstEO_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstEO.SelectedValue == "B")
        {
            lblEO2.Visible = true;
            txtEO2.Visible = true;

            lblEO2.Text = "To :$";
            lblEO1.Text = "From :$";
        }
        else
        {
            lblEO2.Visible = false;
            txtEO2.Visible = false;

            lblEO1.Text = rdbLstEO.SelectedItem.Text + ":$";
        }
    }

    protected void rdbLstEI_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstEI.SelectedValue == "B")
        {
            lblEI2.Visible = true;
            txtEI2.Visible = true;

            lblEI2.Text = "To :$";
            lblEI1.Text = "From :$";
        }
        else
        {
            lblEI2.Visible = false;
            txtEI2.Visible = false;

            lblEI1.Text = rdbLstEI.SelectedItem.Text + ":$";
        }
    }

    protected void rdbLstIP_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstIP.SelectedValue == "B")
        {
            lblIP2.Visible = true;
            txtIP2.Visible = true;

            lblIP2.Text = "To :$";
            lblIP1.Text = "From :$";
        }
        else
        {
            lblIP2.Visible = false;
            txtIP2.Visible = false;

            lblIP1.Text = rdbLstIP.SelectedItem.Text + ":$";
        }
    }
    protected void rdbLstIO_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstIO.SelectedValue == "B")
        {
            lblIO2.Visible = true;
            txtIO2.Visible = true;

            lblIO2.Text = "To :$";
            lblIO1.Text = "From :$";
        }
        else
        {
            lblIO2.Visible = false;
            txtIO2.Visible = false;

            lblIO1.Text = rdbLstIO.SelectedItem.Text + ":$";
        }
    }
    protected void rdbLstII_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstII.SelectedValue == "B")
        {
            lblII2.Visible = true;
            txtII2.Visible = true;

            lblII2.Text = "To :$";
            lblII1.Text = "From :$";
        }
        else
        {
            lblII2.Visible = false;
            txtII2.Visible = false;

            lblII1.Text = rdbLstII.SelectedItem.Text + ":$";
        }
    }

    protected void rdbLstMO_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstMO.SelectedValue == "B")
        {
            lblMO2.Visible = true;
            txtMO2.Visible = true;

            lblMO2.Text = "To :$";
            lblMO1.Text = "From :$";
        }
        else
        {
            lblMO2.Visible = false;
            txtMO2.Visible = false;

            lblMO1.Text = rdbLstMO.SelectedItem.Text + ":$";
        }
    }

    /// <summary>
    /// Handle Radio button list Change event for all date criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdbLstDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (((RadioButtonList)sender).ID)
        {
            case "lstClaimOpened":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstClaimOpened, lblDateOpenedFrom, lblDateOpenedTo, txtDate_Opened_From, txtDate_Opened_To, imgDate_Opened_To);
                imgDate_Opened_To.Attributes.Add("onclick", "return showCalendar('" + txtDate_Opened_To.ClientID + "', 'mm/dd/y','','')");
                break;
            case "lstClaimClosed":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstClaimClosed, lblDateClosedFrom, lblDateClosedTo, txtDateClosedFrom, txtDateClosedTo, imgDate_Closed_To);
                imgDate_Closed_To.Attributes.Add("onclick", "return showCalendar('" + txtDateClosedTo.ClientID + "', 'mm/dd/y','','')");
                break;
            case "lstClaimIncident":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstClaimIncident, lblDateIncidentFrom, lblDateIncidentTo, txtDate_Incident_From, txtDate_Incident_To, imgDate_Incident_To);
                imgDate_Incident_To.Attributes.Add("onclick", "return showCalendar('" + txtDate_Incident_To.ClientID + "', 'mm/dd/y','','')");
                break;
            case "lstClaimValued":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                //SetDateControls(lstClaimValued, lblDateValuedFrom, lblDateValuedTo, txtDateValuedFrom, txtDateValuedTo, imgDate_Valued_To);
                //imgDate_Valued_To.Attributes.Add("onclick", "return showCalendar('" + txtDateValuedTo.ClientID + "', 'mm/dd/y','','')");
                break;
            case "lstClaimReserve":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstClaimReserve, lblDateReserveFrom, lblDateReserveTo, txtDate_Reserve_From, txtDate_Reserve_To, imgDate_Reserve_To);
                imgDate_Reserve_To.Attributes.Add("onclick", "return showCalendar('" + txtDate_Reserve_To.ClientID + "', 'mm/dd/y','','')");
                break;
            case "lstClaimPayment":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstClaimPayment, lblDatePaymentFrom, lblDatePaymentTo, txtDatePaymentFrom, txtDatePaymentTo, imgDate_Payment_To);
                imgDate_Payment_To.Attributes.Add("onclick", "return showCalendar('" + txtDatePaymentTo.ClientID + "', 'mm/dd/y','','')");
                break;
            case "lstDateWorkBegin":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstDateWorkBegin, lblRestrictedBeginFrom, lblRestrictedBeginTo, txtRestricted_BeginFrom, txtRestricted_BeginTo, imgRestricted_Begin_To);
                imgRestricted_Begin_To.Attributes.Add("onclick", "return showCalendar('" + txtRestricted_BeginTo.ClientID + "', 'mm/dd/y','','')");
                break;
            case "lstDateWorkEnd":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstDateWorkEnd, lblRestrictedEndFrom, lblRestrictedEndTo, txtRestricted_EndFrom, txtRestricted_EndTo, imgRestricted_End_To);
                imgRestricted_End_To.Attributes.Add("onclick", "return showCalendar('" + txtRestricted_EndTo.ClientID + "', 'mm/dd/y','','')");
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Set Date control Text and show-hide Date textbox as per selected criteria
    /// </summary>
    /// <param name="rdbCommon"></param>
    /// <param name="lbl1"></param>
    /// <param name="lbl2"></param>
    /// <param name="txt1"></param>
    /// <param name="txt2"></param>
    /// <param name="img2"></param>
    private void SetDateControls(RadioButtonList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2, HtmlImage img2)
    {
        lbl1.Text = rdbCommon.SelectedItem.Text + " Date:";
        if (rdbCommon.SelectedValue == "B")
        {
            img2.Visible = true;
            txt2.Visible = true;
            lbl2.Visible = true;
            lbl1.Text = "Start Date:";
            lbl2.Text = "End Date:";
        }

        else
        {
            img2.Visible = txt2.Visible = lbl2.Visible = false;
            txt2.Text = "";
            lbl2.Text = "";
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// this method is set Selected Output field arrengment
    /// </summary>
    /// <param name="strOutputValue"></param>
    private void setOutputfiedls(string strOutputValue)
    {
        ListItemCollection liColl = lstOutputFields.Items;

        // check if comma seperated value is passed or not
        if (!string.IsNullOrEmpty(strOutputValue))
        {
            string[] strOutPutArray = strOutputValue.Split(',');

            for (int i = 0; i < strOutPutArray.Length; i++)
            {
                ListItem li = lstOutputFields.Items.FindByValue(strOutPutArray[i]);
                // check if output field is exist in lstoutputfild
                if (li != null)
                {
                    // remove list item and insert at new arranged index.
                    lstOutputFields.Items.Remove(li);
                    lstOutputFields.Items.Insert(i, li);
                }
            }
        }
    }

    /// <summary>
    ///  set All lable and textbox to default values.
    /// </summary>
    private void SetDefaults()
    {
        // Hide Incident Date TO criteria
        lblDateIncidentTo.Visible = false;
        txtDate_Incident_To.Visible = false;
        imgDate_Incident_To.Visible = false;
        lblDateIncidentFrom.Text = lstClaimIncident.SelectedItem.Text + " Date:";

        // Hide Opened Date TO criteria
        lblDateOpenedTo.Visible = false;
        txtDate_Opened_To.Visible = false;
        imgDate_Opened_To.Visible = false;
        lblDateOpenedFrom.Text = lstClaimOpened.SelectedItem.Text + " Date:";

        // Hide Closed Date TO criteria
        lblDateClosedTo.Visible = false;
        txtDateClosedTo.Visible = false;
        imgDate_Closed_To.Visible = false;
        lblDateClosedFrom.Text = lstClaimClosed.SelectedItem.Text + " Date:";

        // Hide Value as of Date TO criteria
        //lblDateValuedTo.Visible = false;
        //txtDateValuedTo.Visible = false;
        //imgDate_Valued_To.Visible = false;
        lblDateValuedFrom.Text = lstClaimValued.SelectedItem.Text + " Date:";

        // Hide Reserve Date TO criteria
        lblDateReserveTo.Visible = false;
        txtDate_Reserve_To.Visible = false;
        imgDate_Reserve_To.Visible = false;
        lblDateReserveFrom.Text = lstClaimReserve.SelectedItem.Text + " Date:";

        // Hide Payment Date TO criteria
        lblDatePaymentTo.Visible = false;
        txtDatePaymentTo.Visible = false;
        imgDate_Payment_To.Visible = false;
        lblDatePaymentFrom.Text = lstClaimPayment.SelectedItem.Text + " Date:";

        // Hide Date Restricted Work Begin TO criteria
        lblRestrictedBeginTo.Visible = false;
        txtRestricted_BeginTo.Visible = false;
        imgRestricted_Begin_To.Visible = false;
        lblRestrictedBeginTo.Text = lstDateWorkBegin.SelectedItem.Text + " Date:";

        // Hide Date Restricted Work End TO criteria
        lblRestrictedEndTo.Visible = false;
        txtRestricted_EndTo.Visible = false;
        imgRestricted_End_To.Visible = false;
        lblRestrictedEndTo.Text = lstDateWorkEnd.SelectedItem.Text + " Date:";

        lblTP2.Visible = false;
        txtTP2.Visible = false;
        lblTP1.Text = rdbLstTP.SelectedItem.Text + " :$";

        lblTI2.Visible = false;
        txtTI2.Visible = false;
        lblTI1.Text = rdbLstTI.SelectedItem.Text + " :$";

        lblTO2.Visible = false;
        txtTO2.Visible = false;
        lblTO1.Text = rdbLstTP.SelectedItem.Text + " :$";

        lblMP2.Visible = false;
        txtMP2.Visible = false;
        lblMP1.Text = rdbLstMP.SelectedItem.Text + " :$";

        lblMO2.Visible = false;
        txtMO2.Visible = false;
        lblMO1.Text = rdbLstMO.SelectedItem.Text + " :$";

        lblMI2.Visible = false;
        txtMI2.Visible = false;
        lblMI1.Text = rdbLstMI.SelectedItem.Text + " :$";

        lblEP2.Visible = false;
        txtEP2.Visible = false;
        lblEP1.Text = rdbLstEP.SelectedItem.Text + " :$";

        lblEO2.Visible = false;
        txtEO2.Visible = false;
        lblEO1.Text = rdbLstEO.SelectedItem.Text + " :$";

        lblEI2.Visible = false;
        txtEI2.Visible = false;
        lblEI1.Text = rdbLstEI.SelectedItem.Text + " :$";

        lblIP2.Visible = false;
        txtIP2.Visible = false;
        lblIP1.Text = rdbLstEP.SelectedItem.Text + " :$";

        lblIO2.Visible = false;
        txtIO2.Visible = false;
        lblIO1.Text = rdbLstEO.SelectedItem.Text + " :$";

        lblII2.Visible = false;
        txtII2.Visible = false;
        lblII1.Text = rdbLstEI.SelectedItem.Text + " :$";
    }

    /// <summary>
    /// Show and hide Filter criteria as per claim type selection
    /// </summary>
    private void ShowReportCriteria()
    {
        if ((chkWC.Checked || chkNS.Checked) && !chkPL.Checked && !chkAL.Checked)
        {
            pnlBodyPart.Visible = true;
            pnlCause.Visible = true;
            pnlNOI.Visible = true;
            pnlMedicalPaid.Visible = true;
            pnlMedicalInc.Visible = true;
            pnlMedicalOutStanding.Visible = true;
            pnlIndicator.Visible = true;
            pnlSonicCauseCode.Visible = true;
            pnlDateRestictedtext.Visible = true;
            pnlDateRestricted.Visible = true;
        }
        else
        {
            pnlBodyPart.Visible = false;
            pnlCause.Visible = false;
            pnlNOI.Visible = false;
            pnlMedicalPaid.Visible = false;
            pnlMedicalOutStanding.Visible = false;
            pnlMedicalInc.Visible = false;
            pnlIndicator.Visible = false;
            pnlSonicCauseCode.Visible = false;
            pnlDateRestictedtext.Visible = false;
            pnlDateRestricted.Visible = false;
        }
        pnlLineofCoverage.Visible = (!chkWC.Checked && !chkNS.Checked && !chkPL.Checked && chkAL.Checked);
        rbnAL.Checked = false;
        rbnAU.Checked = false;
        rbnGK.Checked = false;
        rbnCoverage.Checked = true;
        pnlALClaimOrigin.Visible = (!chkWC.Checked && !chkNS.Checked && !chkPL.Checked && chkAL.Checked);
    }

    /// <summary>
    /// Fill all report criteria for Ad-hoc report
    /// </summary>
    private void FillCriteria()
    {
        //Fill Nature Of Injury
        DataTable dtData = ERIMS.DAL.LU_Nature_of_Injury.SelectAll().Tables[0];
        lstNatureofInjury.Items.Clear();
        lstNatureofInjury.DataTextField = "Description";
        lstNatureofInjury.DataValueField = "Code";
        lstNatureofInjury.DataSource = dtData;
        lstNatureofInjury.DataBind();

        // Fill claim status
        dtData = new DataTable();
        dtData = AdhocReport.FillClaimStatus();
        lstClaimStatus.DataTextField = "Description";
        lstClaimStatus.DataValueField = "Code";
        lstClaimStatus.DataSource = dtData;
        lstClaimStatus.DataBind();

        //Fill Coverage State             
        dtData = new DataTable();
        dtData = ERIMS.DAL.State.SelectAll().Tables[0];
        lstCoverageState.Items.Clear();
        lstCoverageState.DataTextField = "FLD_state";
        lstCoverageState.DataValueField = "FLD_abbreviation";
        lstCoverageState.DataSource = dtData;
        lstCoverageState.DataBind();

        //Fill Body Part
        dtData = new DataTable();
        dtData = ERIMS.DAL.LU_Part_of_Body_Code.SelectAll().Tables[0];
        lstBodyPart.Items.Clear();
        lstBodyPart.DataTextField = "Description";
        lstBodyPart.DataValueField = "Code";
        lstBodyPart.DataSource = dtData;
        lstBodyPart.DataBind();

        //Fill Cause
        dtData = new DataTable();
        dtData = LU_Cause_of_Injury.SelectAll().Tables[0];
        lstCause.DataTextField = "Description";
        lstCause.DataValueField = "Code";
        lstCause.DataSource = dtData;
        lstCause.DataBind();

        dtData = new DataTable();
        dtData = Claim_Sub_Status.SelectAll().Tables[0];
        lstClaimSubStatus.DataTextField = "Fld_Desc";
        lstClaimSubStatus.DataValueField = "PK_Claim_Sub_Status";
        lstClaimSubStatus.DataSource = dtData;
        lstClaimSubStatus.DataBind();

        //Fill Region
        dtData = new DataTable();
        Nullable<decimal> CEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CEmployee.ToString() != string.Empty && CEmployee.ToString() != "0")
            CEmployee = Convert.ToDecimal(CEmployee);
        else
            CEmployee = 0;

        CurrentEmployee = CEmployee.HasValue ? CEmployee.Value : 0;

        // select region as per login user
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        lstRegion.Items.Clear();
        lstRegion.DataTextField = "Region";
        lstRegion.DataValueField = "Region";
        lstRegion.DataSource = dsRegion;
        lstRegion.DataBind();

        // Append region in comma seperated string value
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                Regional += drRegion["Region"].ToString() + ",";
        }
        else
            Regional = string.Empty;

        //Fill Location
        DataSet dsLocation = ERIMS.DAL.LU_Location.SelectAllForAdhoc(CEmployee, Regional.ToString().TrimEnd(Convert.ToChar(",")));
        lstLocation.Items.Clear();

        dsLocation.Tables[0].DefaultView.Sort = "Sonic_Location_Code";
        lstLocation.DataTextField = "dba1";
        lstLocation.DataValueField = Convert.ToString(dsLocation.Tables[0].Columns["PK_LU_Location_ID"]);
        lstLocation.DataSource = dsLocation.Tables[0].DefaultView.ToTable();
        lstLocation.DataBind();

    }

    /// <summary>
    /// Fill all listboxes for filter criteria
    /// </summary>
    protected void FillFields()
    {
        //Fill Output Fields
        lstOutputFields.DataSource = AdHocReportWriter.SelectOutputFieldsByClaimType(this.Claim_Type);
        lstOutputFields.DataTextField = "AdhocFieldName";
        lstOutputFields.DataValueField = "AdhocOutputField";
        lstOutputFields.DataBind();

        //Fill Sorting Fields
        DataSet dsSortFields = AdHocReportWriter.SelectSortFieldsByClaimType(this.Claim_Type);

        lstFirstSort.DataSource = dsSortFields;
        lstFirstSort.DataTextField = dsSortFields.Tables[0].Columns["AdhocFieldName"].ToString();
        lstFirstSort.DataValueField = "AdhocOrderByField";
        //lstFirstSort.DataValueField = "AdhocSortField";
        lstFirstSort.DataBind();

        lstSecondSort.DataSource = dsSortFields;
        lstSecondSort.DataTextField = "AdhocFieldName";
        lstSecondSort.DataValueField = "AdhocOrderByField";
        //lstSecondSort.DataValueField = "AdhocSortField";
        lstSecondSort.DataBind();

        lstThirdSort.DataSource = dsSortFields;
        lstThirdSort.DataTextField = "AdhocFieldName";
        lstThirdSort.DataValueField = "AdhocOrderByField";
        //lstThirdSort.DataValueField = "AdhocSortField";
        lstThirdSort.DataBind();
    }

    /// <summary>
    /// Clear all report filter  criteria
    /// </summary>
    private void Reset()
    {
        //Set AlClaimOrigin
        rdoALClaimOrigin.SelectedIndex = -1;
        chkBodypart.Checked = false;
        chkCause.Checked = false;
        chkCoverageState.Checked = false;
        chkLocation.Checked = false;
        chkRegion.Checked = false;
        chkMarket.Checked = false;
        chkNatureofInjury.Checked = false;
        chkSonicCauseCode.Checked = false;

        chkSelUnSelFields.Checked = false;
        chkGrand.Checked = false;
        //chkNS.Checked = false;


        // set date criteria to Default value
        UnBindDateData(lstClaimOpened, lblDateOpenedFrom, lblDateOpenedTo, txtDate_Opened_From, txtDate_Opened_To, imgDate_Opened_To);
        UnBindDateData(lstClaimClosed, lblDateClosedFrom, lblDateClosedTo, txtDateClosedFrom, txtDateClosedTo, imgDate_Closed_To);
        UnBindDateData(lstClaimIncident, lblDateIncidentFrom, lblDateIncidentTo, txtDate_Incident_From, txtDate_Incident_To, imgDate_Incident_To);
        //UnBindDateData(lstClaimValued, lblDateValuedFrom, lblDateValuedTo, txtDateValuedFrom, txtDateValuedTo, imgDate_Valued_To);
        UnBindDateData(lstClaimReserve, lblDateReserveFrom, lblDateReserveTo, txtDate_Reserve_From, txtDate_Reserve_To, imgDate_Reserve_To);
        UnBindDateData(lstClaimPayment, lblDatePaymentFrom, lblDatePaymentTo, txtDatePaymentFrom, txtDatePaymentTo, imgDate_Payment_To);
        UnBindDateData(lstDateWorkBegin, lblRestrictedBeginFrom, lblRestrictedBeginTo, txtRestricted_BeginFrom, txtRestricted_BeginTo, imgRestricted_Begin_To);
        UnBindDateData(lstDateWorkEnd, lblRestrictedEndFrom, lblRestrictedEndTo, txtRestricted_EndFrom, txtRestricted_EndTo, imgRestricted_End_To);

        txtDateValuedFrom.Text = "";

        lstClaimStatus.SelectedIndex = -1;
        lstCoverageState.SelectedIndex = -1;
        lstLocation.SelectedIndex = -1;
        lstRegion.SelectedIndex = -1;
        lstMarket.SelectedIndex = -1;
        lstBodyPart.SelectedIndex = -1;
        lstCause.SelectedIndex = -1;
        lstNatureofInjury.SelectedIndex = -1;
        lstSonicCauseCode.SelectedIndex = -1;
        lstClaimSubStatus.SelectedIndex = -1;

        // set Amount criteria to Default value
        UnBindAmountData(rdbLstMO, lblMP1, lblMO2, txtMO1, txtMO2);
        UnBindAmountData(rdbLstMP, lblMP1, lblMP2, txtMP1, txtMP2);
        UnBindAmountData(rdbLstMI, lblMI1, lblMI2, txtMI1, txtMI2);
        UnBindAmountData(rdbLstEP, lblEP1, lblEP2, txtEP1, txtEP2);
        UnBindAmountData(rdbLstEO, lblEO1, lblEO2, txtEO1, txtEO2);
        UnBindAmountData(rdbLstEI, lblEI1, lblEI2, txtEI1, txtEI2);
        UnBindAmountData(rdbLstIP, lblIP1, lblIP2, txtIP1, txtIP2);
        UnBindAmountData(rdbLstIO, lblIO1, lblIO2, txtIO1, txtIO2);
        UnBindAmountData(rdbLstII, lblII1, lblII2, txtII1, txtII2);
        UnBindAmountData(rdbLstTP, lblTP1, lblTP2, txtTP1, txtTP2);
        UnBindAmountData(rdbLstTI, lblTI1, lblTI2, txtTI1, txtTI2);
        UnBindAmountData(rdbLstTO, lblTO1, lblTO2, txtTO1, txtTO2);

        lstOutputFields.SelectedIndex = -1;
        lstFirstSort.SelectedIndex = -1;
        lstSecondSort.SelectedIndex = -1;
        lstThirdSort.SelectedIndex = -1;
        rdoALClaimOrigin.ClearSelection();

        txtReportName.Text = string.Empty;
        hdnReportName.Value = string.Empty;
        hdnReportId.Value = string.Empty;
        btnDeleteReport.Enabled = false;
        lstIndicator.SelectedIndex = 3;
        rdoFull_Final_Clincher.ClearSelection();
        setLocationSelected();
    }

    /// <summary>
    /// reset date criteria to default value
    /// </summary>
    /// <param name="rdbCommon"></param>
    /// <param name="lbl1"></param>
    /// <param name="lbl2"></param>
    /// <param name="txt1"></param>
    /// <param name="txt2"></param>
    /// <param name="img2"></param>
    private void UnBindDateData(RadioButtonList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2, HtmlImage img2)
    {
        rdbCommon.SelectedValue = "O";
        lbl2.Visible = false;
        txt2.Visible = false;
        txt2.Text = string.Empty;
        txt1.Text = string.Empty;
        img2.Visible = false;
        lbl1.Text = rdbCommon.SelectedItem.Text + " Date:";
    }

    /// <summary>
    /// reset Amount criteria to default value
    /// </summary>
    /// <param name="rdbCommon"></param>
    /// <param name="lbl1"></param>
    /// <param name="lbl2"></param>
    /// <param name="txt1"></param>
    /// <param name="txt2"></param>
    private void UnBindAmountData(RadioButtonList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2)
    {
        rdbCommon.SelectedValue = "G";
        lbl1.Text = rdbCommon.SelectedItem.Text + ":$";
        txt1.Text = string.Empty;
        txt2.Text = string.Empty;
        txt2.Visible = false;
        lbl2.Text = "To :$";
        lbl2.Visible = false;
    }

    /// <summary>
    /// Set Report filter criteria as per Report Name selection
    /// </summary>
    private void BindAllData()
    {
        decimal m_intReportId = Convert.ToDecimal(ddlReports.SelectedValue);

        // Get Report Filter criteria for report name
        AdhocReport objAdhocReport = new AdhocReport(m_intReportId);
        hdnReportId.Value = (objAdhocReport.ReportId == null) ? "0" : objAdhocReport.ReportId.Value.ToString();
        hdnReportName.Value = txtReportName.Text = objAdhocReport.ReportName;
        this.Claim_Type = objAdhocReport.Claim_Type;

        //Set AlClaimOrigin
        if (!string.IsNullOrEmpty(objAdhocReport.AL_Claim_Origin))
        {
            string[] strorgin = objAdhocReport.AL_Claim_Origin.ToString().Split(',');
            for (int i = 0; i < rdoALClaimOrigin.Items.Count; i++)
            {

                for (int j = 0; j < strorgin.Length; j++)
                {
                    if (Convert.ToString(rdoALClaimOrigin.Items[i].Value) == strorgin[j])
                    {

                        rdoALClaimOrigin.Items[i].Selected = true;
                    }
                }
            }

        }
        //Fill Output Fields
        lstOutputFields.DataSource = AdHocReportWriter.SelectOutputFieldsByClaimType(this.Claim_Type);
        lstOutputFields.DataTextField = "AdhocFieldName";
        lstOutputFields.DataValueField = "AdhocOutputField";
        lstOutputFields.DataBind();
        setOutputfiedls(objAdhocReport.OutputFieldsOrder);

        if (!string.IsNullOrEmpty(objAdhocReport.OutputFields))
            BinListData(objAdhocReport.OutputFields, lstOutputFields);

        // set sort fields if sort fiels as saved for report
        if (!String.IsNullOrEmpty(objAdhocReport.SortFields))
        {
            string[] m_strArrIds = new string[3];

            m_strArrIds = objAdhocReport.SortFields.ToString().Trim().Split(',');

            // set First, second and third level Sort fiels 
            for (int m_inCounter = 0; m_inCounter < m_strArrIds.Length; m_inCounter++)
            {
                if (m_inCounter == 0)
                    lstFirstSort.Items.FindByValue(m_strArrIds[0].ToString()).Selected = true;

                if (m_inCounter == 1)
                    lstSecondSort.Items.FindByValue(m_strArrIds[1].ToString()).Selected = true;

                if (m_inCounter == 2)
                    lstThirdSort.Items.FindByValue(m_strArrIds[2].ToString()).Selected = true;
            }
        }
        if (!string.IsNullOrEmpty(objAdhocReport.ShowGrandTotal))
        {
            if (objAdhocReport.ShowGrandTotal == "Y")
                chkGrand.Checked = true;
            else
                chkGrand.Checked = false;
        }

        //Claim Open/Close Data.
        BindDateData(lstClaimOpened, lblDateOpenedFrom, lblDateOpenedTo, txtDate_Opened_From, txtDate_Opened_To, imgDate_Opened_To,
                        objAdhocReport.ClaimOpenCriteria,
                        objAdhocReport.ClaimOpenStartDate,
                        objAdhocReport.ClaimOpenEndDate);

        BindDateData(lstClaimClosed, lblDateClosedFrom, lblDateClosedTo, txtDateClosedFrom, txtDateClosedTo, imgDate_Closed_To,
                        objAdhocReport.ClaimCloseCriteria,
                        objAdhocReport.ClaimCloseStartDate,
                        objAdhocReport.ClaimCloseEndDate);
        //Date of incident
        BindDateData(lstClaimIncident, lblDateIncidentFrom, lblDateIncidentTo, txtDate_Incident_From, txtDate_Incident_To, imgDate_Incident_To,
                        objAdhocReport.DOICriteria,
                        objAdhocReport.DOIStart,
                        objAdhocReport.DOIEnd);
        //Valued as of Date
        //BindDateData(lstClaimValued, lblDateValuedFrom, lblDateValuedTo, txtDateValuedFrom, txtDateValuedTo, imgDate_Valued_To,
        //                objAdhocReport.ValueAsOfDateCriteria,
        //                objAdhocReport.ValueAsOfDateStartDate,
        //                objAdhocReport.ValueAsOfDateEndDate);

        if (objAdhocReport.ValueAsOfDateStartDate.ToString() != "1/1/1753 12:00:00 AM" && objAdhocReport.ValueAsOfDateStartDate.ToString() != string.Empty)
            txtDateValuedFrom.Text = Convert.ToDateTime(objAdhocReport.ValueAsOfDateStartDate).ToShortDateString();

        //Reserve/Payment Date.
        BindDateData(lstClaimReserve, lblDateReserveFrom, lblDateReserveTo, txtDate_Reserve_From, txtDate_Reserve_To, imgDate_Reserve_To,
                        objAdhocReport.ClaimReserveCriteria,
                        objAdhocReport.ClaimReserveStartDate,
                        objAdhocReport.ClaimReserveEndDate);
        BindDateData(lstClaimPayment, lblDatePaymentFrom, lblDatePaymentTo, txtDatePaymentFrom, txtDatePaymentTo, imgDate_Payment_To,
                        objAdhocReport.ClaimPaymentCriteria,
                        objAdhocReport.ClaimPaymentStartDate,
                        objAdhocReport.ClaimPaymentEndDate);

        if (!string.IsNullOrEmpty(objAdhocReport.DateRestrictedBeginCriteria))
        {
            BindDateData(lstDateWorkBegin, lblRestrictedBeginFrom, lblRestrictedBeginTo, txtRestricted_BeginFrom, txtRestricted_BeginTo, imgRestricted_Begin_To,
                          objAdhocReport.DateRestrictedBeginCriteria,
                          objAdhocReport.DateRestrictedBeginStartDate,
                          objAdhocReport.DateRestrictedBeginEndDate);
        }

        if (!string.IsNullOrEmpty(objAdhocReport.DateRestrictedEndCriteria))
        {
            BindDateData(lstDateWorkEnd, lblRestrictedEndTo, lblRestrictedEndTo, txtRestricted_EndFrom, txtRestricted_EndTo, imgRestricted_End_To,
                          objAdhocReport.DateRestrictedEndCriteria,
                          objAdhocReport.DateRestrictedEndStartDate,
                          objAdhocReport.DateRestrictedEndEndDate);
        }

        //Status of Claim
        //if (!String.IsNullOrEmpty(objAdhocReport.OStatus))
        //    cblClaimStatus.Items.FindByValue(objAdhocReport.OStatus).Selected = true;
        //if (!String.IsNullOrEmpty(objAdhocReport.CStatus))
        //    cblClaimStatus.Items.FindByValue(objAdhocReport.CStatus).Selected = true;
        //if (!String.IsNullOrEmpty(objAdhocReport.ROStatus))
        //    cblClaimStatus.Items.FindByValue(objAdhocReport.ROStatus).Selected = true;

        //Bind All List Box Control.
        if (!String.IsNullOrEmpty(objAdhocReport.OStatus))
            BinListData(objAdhocReport.OStatus, lstClaimStatus);

        if (!String.IsNullOrEmpty(objAdhocReport.CoverageState))
            BinListData(objAdhocReport.CoverageState, lstCoverageState);
        if (!String.IsNullOrEmpty(objAdhocReport.Location))
            BinListData(objAdhocReport.Location, lstLocation);
        if (!String.IsNullOrEmpty(objAdhocReport.BodyPart))
            BinListData(objAdhocReport.BodyPart, lstBodyPart);
        if (!String.IsNullOrEmpty(objAdhocReport.Region))
            BinListData(objAdhocReport.Region, lstRegion);
        if (!String.IsNullOrEmpty(objAdhocReport.Market))
            BinListData(objAdhocReport.Market, lstMarket);
        if (!String.IsNullOrEmpty(objAdhocReport.ClaimSubStaus))
            BinListData(objAdhocReport.ClaimSubStaus, lstClaimSubStatus);
        if (!String.IsNullOrEmpty(objAdhocReport.Cause))
            BinListData(objAdhocReport.Cause, lstCause);
        if (!String.IsNullOrEmpty(objAdhocReport.NatureOfInjury))
            BinListData(objAdhocReport.NatureOfInjury, lstNatureofInjury);
        if (!String.IsNullOrEmpty(objAdhocReport.Indicator))
        {
            if (objAdhocReport.Indicator != "B" && objAdhocReport.Indicator != "L")
                lstIndicator.SelectedValue = objAdhocReport.Indicator;
        }
        if(!string.IsNullOrEmpty(objAdhocReport.FullFinalClincher))
            rdoFull_Final_Clincher.SelectedValue = objAdhocReport.FullFinalClincher;
        if (!String.IsNullOrEmpty(objAdhocReport.SonicCauseCode))
            BinListData(objAdhocReport.SonicCauseCode, lstSonicCauseCode);

        //Medical Paid & Incurred.
        BindAmountData(rdbLstMP, lblMP1, lblMP2, txtMP1, txtMP2,
                        objAdhocReport.MPCriteria,
                        objAdhocReport.MPStartAmount,
                        objAdhocReport.MPEndAmount);

        BindAmountData(rdbLstMI, lblMI1, lblMI2, txtMI1, txtMI2,
                        objAdhocReport.MICriteria,
                        objAdhocReport.MIStartAmount,
                        objAdhocReport.MIEndAmount);
        //Expense Paid & Incurred.
        BindAmountData(rdbLstEP, lblEP1, lblEP2, txtEP1, txtEP2,
                        objAdhocReport.EPCriteria,
                        objAdhocReport.EPStartAmount,
                        objAdhocReport.EPEndAmount);
        BindAmountData(rdbLstEI, lblEI1, lblEI2, txtEI1, txtEI2,
                        objAdhocReport.EICriteria,
                        objAdhocReport.EIStartAmount,
                        objAdhocReport.EIEndAmount);
        //Indemnity Paid & Incurred.
        BindAmountData(rdbLstIP, lblIP1, lblIP2, txtIP1, txtIP2,
                        objAdhocReport.IPCriteria,
                        objAdhocReport.IPStartAmount,
                        objAdhocReport.IPEndAmount);
        BindAmountData(rdbLstII, lblII1, lblII2, txtII1, txtII2,
                        objAdhocReport.IICriteria,
                        objAdhocReport.IIStartAmount,
                        objAdhocReport.IIEndAmount);
        //Total Paid & Incurred.
        BindAmountData(rdbLstTP, lblTP1, lblTP2, txtTP1, txtTP2,
                        objAdhocReport.TPCriteria,
                        objAdhocReport.TPStartAmount,
                        objAdhocReport.TPEndAmount);
        BindAmountData(rdbLstTI, lblTI1, lblTI2, txtTI1, txtTI2,
                        objAdhocReport.TICriteria,
                        objAdhocReport.TIStartAmount,
                        objAdhocReport.TIEndAmount);
        //Total Out Standing.
        BindAmountData(rdbLstTO, lblTO1, lblTO2, txtTO1, txtTO2,
                        objAdhocReport.TOCriteria,
                        objAdhocReport.TOStartAmount,
                        objAdhocReport.TOEndAmount);

        if (!string.IsNullOrEmpty(objAdhocReport.LineofCoverage))
        {
            string[] strCoverageType = objAdhocReport.LineofCoverage.Split(',');

            if (strCoverageType.Length > 0)
            {
                for (int i = 0; i < strCoverageType.Length; i++)
                {
                    if (strCoverageType[i].Trim() == "AL")
                        rbnAL.Checked = true;
                    else if (strCoverageType[i].Trim() == "AU")
                        rbnAU.Checked = true;
                    else if (strCoverageType[i].Trim() == "GK")
                        rbnGK.Checked = true;
                }
            }
        }
        else
        {
            rbnCoverage.Checked = true;
        }
    }

    /// <summary>
    /// set Date fields as per critaria
    /// </summary>
    /// <param name="rdbCommon"></param>
    private void BindDateData(RadioButtonList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2, HtmlImage img2, string m_strCriteria, DateTime? value1, DateTime? value2)
    {
        rdbCommon.Items.FindByValue(m_strCriteria).Selected = true;
        lbl1.Text = rdbCommon.Items.FindByValue(m_strCriteria).Text + " Date:";
        if (value1.ToString() != "1/1/1753 12:00:00 AM" && value1.ToString() != string.Empty)
            txt1.Text = Convert.ToDateTime(value1).ToShortDateString();
        if (value2.ToString() != "1/1/1753 12:00:00 AM" && value2.ToString() != string.Empty)
        {
            img2.Visible = true;
            txt2.Text = value2.Value.ToShortDateString();
            txt2.Visible = true;
            lbl2.Text = "End Date:";
            lbl2.Visible = true;
            lbl1.Text = "Start Date:";
        }
    }

    /// <summary>
    /// Bind Listbox as per comma seperated string value
    /// </summary>
    /// <param name="m_strIDs"></param>
    /// <param name="lstCommon"></param>
    private void BinListData(string m_strIDs, ListBox lstCommon)
    {
        string[] m_strSplitIds = new string[m_strIDs.Length];
        m_strSplitIds = m_strIDs.Split(',');
        for (int m_intCounter = 0; m_intCounter < m_strSplitIds.Length; m_intCounter++)
        {
            if (lstCommon.Items.FindByValue(m_strSplitIds[m_intCounter]) != null)
                lstCommon.Items.FindByValue(m_strSplitIds[m_intCounter]).Selected = true;
        }
    }

    /// <summary>
    /// set Amount fields to filter Criteria 
    /// </summary>    
    private void BindAmountData(RadioButtonList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2, string m_strCriteria, decimal? value1, decimal? value2)
    {
        rdbCommon.Items.FindByValue(m_strCriteria).Selected = true;
        lbl1.Text = rdbCommon.Items.FindByValue(m_strCriteria).Text + ":$";
        if (value1.ToString() != string.Empty && value1 != null)
            txt1.Text = value1.ToString();
        if (value2.ToString() != string.Empty && value2 != null)
        {
            txt2.Text = value2.ToString();
            txt2.Visible = true;
            lbl2.Text = "From:$";
            lbl2.Visible = true;
            lbl1.Text = "To:$";
        }
    }

    /// <summary>
    /// Bind Saved report Drop-down 
    /// </summary>
    private void BindReports()
    {
        ddlReports.Items.Clear();
        DataSet dsReports = AdhocReport.SelectByClaimType(this.Claim_Type);
        ddlReports.DataSource = dsReports;
        ddlReports.DataTextField = "ReportName";
        ddlReports.DataValueField = "ReportId";
        ddlReports.DataBind();

        ListItem lstCommon = new ListItem("---Select Report--", "0");
        ddlReports.Items.Insert(0, lstCommon);
    }

    private void setLocationSelected()
    {
        if (CurrentEmployee > 0 && string.IsNullOrEmpty(Regional))
        {
            chkLocation.Checked = true;
            chkLocation.Enabled = false;
            chkLocation.Attributes.Add("onclick", "return false");

            foreach (ListItem li in lstLocation.Items)
            {
                li.Selected = true;
                li.Attributes.Add("onclick", "return false");
            }
        }
    }

    #endregion

    protected void btnDeleteReport_Click(object sender, EventArgs e)
    {
        if (ddlReports.SelectedIndex > 0)
        {
            AdhocReport.DeleteByPK(Convert.ToDecimal(ddlReports.SelectedValue));
            ddlReports.Items.Remove(ddlReports.Items.FindByValue(ddlReports.SelectedValue));
            // reset all filter criteria
            Reset();
        }
    }

    protected void rbnCoverage_CheckedChanged(object sender, EventArgs e)
    {
        string ctrlID = ((RadioButton)sender).ID;

        if (ctrlID == "rbnAL" || ctrlID == "rbnAU" || ctrlID == "rbnGK")
            rbnCoverage.Checked = false;
        else if (ctrlID == "rbnCoverage")
        {
            rbnAL.Checked = false;
            rbnAU.Checked = false;
            rbnGK.Checked = false;
        }            
    }
}
