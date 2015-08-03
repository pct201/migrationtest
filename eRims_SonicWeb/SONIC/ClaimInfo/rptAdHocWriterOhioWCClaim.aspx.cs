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
using System.IO;

public partial class SONIC_ClaimInfo_rptAdHocWriterOhioWCClaim : clsBasePage
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


        chkLocation.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstLocation.ClientID + "');");
        chkSelUnSelFields.Attributes.Add("onclick", "javascript:CheckALL(this,'" + lstOutputFields.ClientID + "');");


        btnSubmit.Attributes.Add("onclick", "return Validate('S');");
        btnExportExcel.Attributes.Add("onclick", "return Validate('E');");

        if (!IsPostBack)
        {
            ddlStatus.Items.Insert(0, new ListItem("-- Select --", "0"));

            this.Claim_Type = "WCOH";

            FillCriteria();
            setLocationSelected();
            FillFields();
            SetDefaults();
            ShowReportCriteria();
            BindReports();
            ComboHelper.FillGetClaimStatusList(new DropDownList[] { ddlStatus }, true);
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
        objAdhocReport.ClaimOpenCriteria = lstClaimEntered.SelectedValue;
        if (txtDate_Entered_From.Text != string.Empty)
            objAdhocReport.ClaimOpenStartDate = Convert.ToDateTime(txtDate_Entered_From.Text);
        if (txtDate_Entered_To.Text != string.Empty)
            objAdhocReport.ClaimOpenEndDate = Convert.ToDateTime(txtDate_Entered_To.Text);

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



        objAdhocReport.ClaimReserveCriteria = lstClaimReOpened.SelectedValue;
        if (txtDateOfClaimReopenedFrom.Text != string.Empty)
            objAdhocReport.ClaimReserveStartDate = Convert.ToDateTime(txtDateOfClaimReopenedFrom.Text);
        if (txtDateofClaimReopenedTo.Text != string.Empty)
            objAdhocReport.ClaimReserveEndDate = Convert.ToDateTime(txtDateofClaimReopenedTo.Text);



        objAdhocReport.Location = Request.Form[lstLocation.UniqueID];
        objAdhocReport.OStatus = ddlStatus.SelectedValue;
        //objAdhocReport.MPCriteria = rdbLstMP.SelectedValue;
        //if (txtMP1.Text != string.Empty)
        //    objAdhocReport.MPStartAmount = Convert.ToDecimal(txtMP1.Text);
        //if (txtMP2.Text != string.Empty)
        //    objAdhocReport.MPEndAmount = Convert.ToDecimal(txtMP2.Text);

        //objAdhocReport.TCompCriteria = rdbLstComp.SelectedValue;
        //if (txtTotalComp1.Text != string.Empty)
        //    objAdhocReport.TCompStartAmount = Convert.ToDecimal(txtTotalComp1.Text);
        //if (txtTotalComp2.Text != string.Empty)
        //    objAdhocReport.TCompEndAmount = Convert.ToDecimal(txtTotalComp2.Text);

        //objAdhocReport.TReserveCriteria = rdbLstTotalReserve.SelectedValue;
        //if (txtTotalRes1.Text != string.Empty)
        //    objAdhocReport.TReserveStartAmount = Convert.ToDecimal(txtTotalRes1.Text);
        //if (txtTotalRes2.Text != string.Empty)
        //    objAdhocReport.TReserveEndAmount = Convert.ToDecimal(txtTotalRes2.Text);

        //objAdhocReport.UCostCriteria = rdbLstUnlimitedCost.SelectedValue;
        //if (txtUnlimitedCost1.Text != string.Empty)
        //    objAdhocReport.UCostStartAmount = Convert.ToDecimal(txtUnlimitedCost1.Text);
        //if (txtUnlimitedCost2.Text != string.Empty)
        //    objAdhocReport.UCostEndAmount = Convert.ToDecimal(txtUnlimitedCost2.Text);

        //objAdhocReport.LMVCriteria = rdbLstLimitedToMV.SelectedValue;
        //if (txtLimitedToMV1.Text != string.Empty)
        //    objAdhocReport.LMVStartAmount = Convert.ToDecimal(txtLimitedToMV1.Text);
        //if (txtLimitedToMV2.Text != string.Empty)
        //    objAdhocReport.LMVEndAmount = Convert.ToDecimal(txtLimitedToMV2.Text);

        //objAdhocReport.HCPCriteria = rdbLstHCP.SelectedValue;
        //if (txtHCP1.Text != string.Empty)
        //    objAdhocReport.HCPStartAmount = Convert.ToDecimal(txtHCP1.Text);
        //if (txtHCP2.Text != string.Empty)
        //    objAdhocReport.HCPEndAmount = Convert.ToDecimal(txtHCP2.Text);

        //objAdhocReport.HCRCriteria = rdbLstHCRelief.SelectedValue;
        //if (txtHCRelief1.Text != string.Empty)
        //    objAdhocReport.HCRStartAmount = Convert.ToDecimal(txtHCRelief1.Text);
        //if (txtHCRelief2.Text != string.Empty)
        //    objAdhocReport.HCREndAmount = Convert.ToDecimal(txtHCRelief2.Text);

        //objAdhocReport.SColledtedCriteria = rdbLstCollected.SelectedValue;
        //if (txtCollected1.Text != string.Empty)
        //    objAdhocReport.SColledtedStartAmount = Convert.ToDecimal(txtCollected1.Text);
        //if (txtCollected2.Text != string.Empty)
        //    objAdhocReport.SColledtedEndAmount = Convert.ToDecimal(txtCollected2.Text);

        objAdhocReport.TTotalPaidCriteria = rdbLstTotalCharged.SelectedValue;
        if (txtTotalCharged1.Text != string.Empty)
            objAdhocReport.TTotalPaidStartAmount = Convert.ToDecimal(txtTotalCharged1.Text);
        if (txtTotalCharged2.Text != string.Empty)
            objAdhocReport.TTotalPaidEndAmount = Convert.ToDecimal(txtTotalCharged2.Text);


        //objAdhocReport.AL_Claim_Origin = Convert.ToString(strgetClaimorgin);
        objAdhocReport.SortFields = strOrderBy;
        objAdhocReport.OutputFields = strShowFields;
        objAdhocReport.ShowGrandTotal = chkGrand.Checked ? "Y" : "N";
        objAdhocReport.ShowSubTotal = "N";
        objAdhocReport.Claim_Type = this.Claim_Type;

        objAdhocReport.OutputFieldsOrder = hdnOutputList.Value;
        objAdhocReport.ReportName = txtReportName.Text.Trim();
        objAdhocReport.ReportId = hdnReportId.Value == string.Empty ? 0 : Convert.ToInt32(hdnReportId.Value);
        objAdhocReport.UpdatedDate = DateTime.Now;


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
        objAdhocReport.ClaimOpenCriteria = lstClaimEntered.SelectedValue;
        if (txtDate_Entered_From.Text != string.Empty)
            objAdhocReport.ClaimOpenStartDate = Convert.ToDateTime(txtDate_Entered_From.Text);
        if (txtDate_Entered_To.Text != string.Empty)
            objAdhocReport.ClaimOpenEndDate = Convert.ToDateTime(txtDate_Entered_To.Text);

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

        objAdhocReport.ClaimReserveCriteria = lstClaimReOpened.SelectedValue;
        if (txtDateOfClaimReopenedFrom.Text != string.Empty)
            objAdhocReport.ClaimReserveStartDate = Convert.ToDateTime(txtDateOfClaimReopenedFrom.Text);
        if (txtDateofClaimReopenedTo.Text != string.Empty)
            objAdhocReport.ClaimReserveEndDate = Convert.ToDateTime(txtDateofClaimReopenedTo.Text);



        objAdhocReport.Location = Request.Form[lstLocation.UniqueID];
        objAdhocReport.OStatus = ddlStatus.SelectedValue;

        //objAdhocReport.MPCriteria = rdbLstMP.SelectedValue;
        //if (txtMP1.Text != string.Empty)
        //    objAdhocReport.MPStartAmount = Convert.ToDecimal(txtMP1.Text);
        //if (txtMP2.Text != string.Empty)
        //    objAdhocReport.MPEndAmount = Convert.ToDecimal(txtMP2.Text);

        //objAdhocReport.TCompCriteria= rdbLstComp.SelectedValue;
        //if (txtTotalComp1.Text != string.Empty)
        //    objAdhocReport.TCompStartAmount = Convert.ToDecimal(txtTotalComp1.Text);
        //if (txtTotalComp2.Text != string.Empty)
        //    objAdhocReport.TCompEndAmount = Convert.ToDecimal(txtTotalComp2.Text);

        //objAdhocReport.TReserveCriteria = rdbLstTotalReserve.SelectedValue;
        //if (txtTotalRes1.Text != string.Empty)
        //    objAdhocReport.TReserveStartAmount = Convert.ToDecimal(txtTotalRes1.Text);
        //if (txtTotalRes2.Text != string.Empty)
        //    objAdhocReport.TReserveEndAmount = Convert.ToDecimal(txtTotalRes2.Text);

        //objAdhocReport.UCostCriteria = rdbLstUnlimitedCost.SelectedValue;
        //if (txtUnlimitedCost1.Text != string.Empty)
        //    objAdhocReport.UCostStartAmount = Convert.ToDecimal(txtUnlimitedCost1.Text);
        //if (txtUnlimitedCost2.Text != string.Empty)
        //    objAdhocReport.UCostEndAmount = Convert.ToDecimal(txtUnlimitedCost2.Text);

        //objAdhocReport.LMVCriteria = rdbLstLimitedToMV.SelectedValue;
        //if (txtLimitedToMV1.Text != string.Empty)
        //    objAdhocReport.LMVStartAmount = Convert.ToDecimal(txtLimitedToMV1.Text);
        //if (txtLimitedToMV2.Text != string.Empty)
        //    objAdhocReport.LMVEndAmount = Convert.ToDecimal(txtLimitedToMV2.Text);

        //objAdhocReport.HCPCriteria = rdbLstHCP.SelectedValue;
        //if (txtHCP1.Text != string.Empty)
        //    objAdhocReport.HCPStartAmount = Convert.ToDecimal(txtHCP1.Text);
        //if (txtHCP2.Text != string.Empty)
        //    objAdhocReport.HCPEndAmount = Convert.ToDecimal(txtHCP2.Text);


        //objAdhocReport.HCRCriteria = rdbLstHCRelief.SelectedValue;
        //if (txtHCRelief1.Text != string.Empty)
        //    objAdhocReport.HCRStartAmount = Convert.ToDecimal(txtHCRelief1.Text);
        //if (txtHCRelief2.Text != string.Empty)
        //    objAdhocReport.HCREndAmount = Convert.ToDecimal(txtHCRelief2.Text);

        //objAdhocReport.SColledtedCriteria = rdbLstCollected.SelectedValue;
        //if (txtCollected1.Text != string.Empty)
        //    objAdhocReport.SColledtedStartAmount = Convert.ToDecimal(txtCollected1.Text);
        //if (txtCollected2.Text != string.Empty)
        //    objAdhocReport.SColledtedEndAmount = Convert.ToDecimal(txtCollected2.Text);

        objAdhocReport.TTotalPaidCriteria = rdbLstTotalCharged.SelectedValue;
        if (txtTotalCharged1.Text != string.Empty)
            objAdhocReport.TTotalPaidStartAmount = Convert.ToDecimal(txtTotalCharged1.Text);
        if (txtTotalCharged2.Text != string.Empty)
            objAdhocReport.TTotalPaidEndAmount = Convert.ToDecimal(txtTotalCharged2.Text);



        objAdhocReport.SortFields = strOrderBy;
        objAdhocReport.OutputFields = strShowFields;
        objAdhocReport.ShowGrandTotal = chkGrand.Checked ? "Y" : "N";
        objAdhocReport.ShowSubTotal = "N";
        objAdhocReport.Claim_Type = this.Claim_Type;

        //if (rdoALClaimOrigin.SelectedIndex > -1)
        //    objAdhocReport.AL_Claim_Origin = rdoALClaimOrigin.SelectedValue;


        DataSet dsReport = null;
        dsReport = objAdhocReport.GetWCOhioAdhocReport();



        // Add Total field to array List, So Check if User selects field for grand total
        arColumnList.Add("Total Medical");
        arColumnList.Add("Total Comp");
        arColumnList.Add("Total Reserve");
        arColumnList.Add("Unlimited Cost");
        arColumnList.Add("Limited to MV");
        arColumnList.Add("HC Percent");
        arColumnList.Add("HC Relief");
        arColumnList.Add("Subrogation Collected");
        arColumnList.Add("Total Charged");
        arColumnList.Add("Total Paid To Date");


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
            string data = GridViewExportUtil.ExportAdHoc_New(this.gvAdHoc);
            data = data.Trim();
            HTML2Excel objHtml2Excel = new HTML2Excel(data);
            string strPath = AppConfig.SitePath + @"temp\";
            string fileName = "AdHocReport" + this.Claim_Type + ".xlsx";
            string outputFiles = Path.GetFullPath(strPath + fileName);
            bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);
            if (blnHTML2Excel)
            {
                try
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    HttpContext.Current.Response.TransmitFile(outputFiles);
                    HttpContext.Current.Response.Flush();
                }
                finally
                {
                    if (File.Exists(outputFiles))
                        File.Delete(outputFiles);
                    HttpContext.Current.Response.End();
                }

            }
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
                if (iCell != gvAdHoc.HeaderRow.Cells.Count)
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
                        if (gvAdHoc.HeaderRow.Cells[iCell].Text == "Total Paid To Date")
                        {
                            // Check if Its don't contains "&nbsp" means empty value
                            //if (!string.IsNullOrEmpty(Server.HtmlDecode(e.Row.Cells[iCell].Text).Trim()))
                            //    e.Row.Cells[iCell].Text = string.Format("{0:C}", Convert.ToDouble(e.Row.Cells[iCell].Text));
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(Server.HtmlDecode(e.Row.Cells[iCell].Text).Trim()))
                                e.Row.Cells[iCell].Text = clsGeneral.FormatDBNullDateToDisplay(e.Row.Cells[iCell].Text);
                        }
                    }
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

    //protected void rdbLstMP_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // check if between filter criteria is selected then display two textbox and change lable text
    //    if (rdbLstMP.SelectedValue == "B")
    //    {
    //        lblMP2.Visible = true;
    //        txtMP2.Visible = true;

    //        lblMP2.Text = "To :$";
    //        lblMP1.Text = "From :$";
    //    }
    //    else
    //    {
    //        lblMP2.Visible = false;
    //        txtMP2.Visible = false;

    //        lblMP1.Text = rdbLstMP.SelectedItem.Text + ":$";
    //    }
    //}

    //protected void rdbLstComp_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // check if between filter criteria is selected then display two textbox and change lable text
    //    if (rdbLstComp.SelectedValue == "B")
    //    {
    //        lblTotalComp2.Visible = true;
    //        txtTotalComp2.Visible = true;

    //        lblTotalComp2.Text = "To :$";
    //        lblTotalComp1.Text = "From :$";
    //    }
    //    else
    //    {
    //        lblTotalComp2.Visible = false;
    //        txtTotalComp2.Visible = false;

    //        lblTotalComp1.Text = rdbLstComp.SelectedItem.Text + ":$";
    //    }
    //}

    //protected void rdbLstTotalReserve_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // check if between filter criteria is selected then display two textbox and change lable text
    //    if (rdbLstTotalReserve.SelectedValue == "B")
    //    {
    //        lblTotalRes2.Visible = true;
    //        txtTotalRes2.Visible = true;

    //        lblTotalRes2.Text = "To :$";
    //        lblTotalRes1.Text = "From :$";
    //    }
    //    else
    //    {
    //        lblTotalRes2.Visible = false;
    //        txtTotalRes2.Visible = false;

    //        lblTotalRes1.Text = rdbLstTotalReserve.SelectedItem.Text + ":$";
    //    }
    //}

    //protected void rdbLstUnlimitedCost_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // check if between filter criteria is selected then display two textbox and change lable text
    //    if (rdbLstUnlimitedCost.SelectedValue == "B")
    //    {
    //        lblUnlimitedCost2.Visible = true;
    //        txtUnlimitedCost2.Visible = true;

    //        lblUnlimitedCost2.Text = "To :$";
    //        lblUnlimitedCost1.Text = "From :$";
    //    }
    //    else
    //    {
    //        lblUnlimitedCost2.Visible = false;
    //        txtUnlimitedCost2.Visible = false;

    //        lblUnlimitedCost1.Text = rdbLstUnlimitedCost.SelectedItem.Text + ":$";
    //    }
    //}

    //protected void rdbLstLimitedToMV_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // check if between filter criteria is selected then display two textbox and change lable text
    //    if (rdbLstLimitedToMV.SelectedValue == "B")
    //    {
    //        lblLimitedToMV2.Visible = true;
    //        txtLimitedToMV2.Visible = true;

    //        lblLimitedToMV2.Text = "To :$";
    //        lblLimitedToMV1.Text = "From :$";
    //    }
    //    else
    //    {
    //        lblLimitedToMV2.Visible = false;
    //        txtLimitedToMV2.Visible = false;

    //        lblLimitedToMV1.Text = rdbLstLimitedToMV.SelectedItem.Text + ":$";
    //    }
    //}

    //protected void rdbLstHCP_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // check if between filter criteria is selected then display two textbox and change lable text
    //    if (rdbLstHCP.SelectedValue == "B")
    //    {
    //        lblHCP2.Visible = true;
    //        txtHCP2.Visible = true;

    //        lblHCP2.Text = "To :$";
    //        lblHCP1.Text = "From :$";
    //    }
    //    else
    //    {
    //        lblHCP2.Visible = false;
    //        txtHCP2.Visible = false;

    //        lblHCP1.Text = rdbLstHCP.SelectedItem.Text + ":$";
    //    }
    //}

    //protected void rdbLstHCRelief_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // check if between filter criteria is selected then display two textbox and change lable text
    //    if (rdbLstHCRelief.SelectedValue == "B")
    //    {
    //        lblHCRelief2.Visible = true;
    //        txtHCRelief2.Visible = true;

    //        lblHCRelief2.Text = "To :$";
    //        lblHCRelief1.Text = "From :$";
    //    }
    //    else
    //    {
    //        lblHCRelief2.Visible = false;
    //        txtHCRelief2.Visible = false;

    //        lblHCRelief1.Text = rdbLstHCRelief.SelectedItem.Text + ":$";
    //    }
    //}

    //protected void rdbLstCollected_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // check if between filter criteria is selected then display two textbox and change lable text
    //    if (rdbLstCollected.SelectedValue == "B")
    //    {
    //        lblCollected2.Visible = true;
    //        txtCollected2.Visible = true;

    //        lblCollected2.Text = "To :$";
    //        lblCollected1.Text = "From :$";
    //    }
    //    else
    //    {
    //        lblCollected2.Visible = false;
    //        txtCollected2.Visible = false;

    //        lblCollected1.Text = rdbLstCollected.SelectedItem.Text + ":$";
    //    }
    //}

    protected void rdbLstTotalCharged_SelectedIndexChanged(object sender, EventArgs e)
    {
        // check if between filter criteria is selected then display two textbox and change lable text
        if (rdbLstTotalCharged.SelectedValue == "B")
        {
            lblTotalCharged2.Visible = true;
            txtTotalCharged2.Visible = true;

            lblTotalCharged2.Text = "To :$";
            lblTotalCharged1.Text = "From :$";
        }
        else
        {
            lblTotalCharged2.Visible = false;
            txtTotalCharged2.Visible = false;

            lblTotalCharged1.Text = rdbLstTotalCharged.SelectedItem.Text + ":$";
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
            case "lstClaimEntered":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstClaimEntered, lblDateEnteredFrom, lblDateEnteredTo, txtDate_Entered_From, txtDate_Entered_To, imgDate_Entered_To);
                imgDate_Entered_To.Attributes.Add("onclick", "return showCalendar('" + txtDate_Entered_To.ClientID + "', 'mm/dd/y','','')");
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
            case "lstClaimReOpened":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstClaimReOpened, lblDateOfClaimReopenedFrom, lblDateOfClaimReopenedTo, txtDateOfClaimReopenedFrom, txtDateofClaimReopenedTo, imgDate_ClaimReopend_To);
                imgDate_ClaimReopend_To.Attributes.Add("onclick", "return showCalendar('" + txtDateofClaimReopenedTo.ClientID + "', 'mm/dd/y','','')");
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

        lblDateEnteredTo.Visible = false;
        txtDate_Entered_To.Visible = false;
        imgDate_Entered_To.Visible = false;
        lblDateEnteredFrom.Text = lstClaimEntered.SelectedItem.Text + " Date:";

        lblDateClosedTo.Visible = false;
        txtDateClosedTo.Visible = false;
        imgDate_Closed_To.Visible = false;
        lblDateClosedFrom.Text = lstClaimClosed.SelectedItem.Text + " Date:";

        lblDateIncidentTo.Visible = false;
        txtDate_Incident_To.Visible = false;
        imgDate_Incident_To.Visible = false;
        lblDateIncidentFrom.Text = lstClaimIncident.SelectedItem.Text + " Date:";

        lblDateOfClaimReopenedTo.Visible = false;
        txtDateofClaimReopenedTo.Visible = false;
        imgDate_ClaimReopend_To.Visible = false;
        lblDateOfClaimReopenedFrom.Text = lstClaimReOpened.SelectedItem.Text + " Date:";


        //lblMP2.Visible = false;
        //txtMP2.Visible = false;
        //lblMP1.Text = rdbLstMP.SelectedItem.Text + " :$";

        //lblTotalComp2.Visible = false;
        //txtTotalComp2.Visible = false;
        //lblTotalComp1.Text = rdbLstComp.SelectedItem.Text + " :$";

        //lblTotalRes2.Visible = false;
        //txtTotalRes2.Visible = false;
        //lblTotalRes1.Text = rdbLstTotalReserve.SelectedItem.Text + " :$";

        //lblUnlimitedCost2.Visible = false;
        //txtUnlimitedCost2.Visible = false;
        //lblUnlimitedCost1.Text = rdbLstUnlimitedCost.SelectedItem.Text + " :$";

        //lblLimitedToMV2.Visible = false;
        //txtLimitedToMV2.Visible = false;
        //lblLimitedToMV1.Text = rdbLstLimitedToMV.SelectedItem.Text + " :$";

        //lblHCP2.Visible = false;
        //txtHCP2.Visible = false;
        //lblHCP1.Text = rdbLstHCP.SelectedItem.Text + " :$";

        //lblHCRelief2.Visible = false;
        //txtHCRelief2.Visible = false;
        //lblHCRelief1.Text = rdbLstHCRelief.SelectedItem.Text + " :$";

        //lblCollected2.Visible = false;
        //txtCollected2.Visible = false;
        //lblCollected1.Text = rdbLstCollected.SelectedItem.Text + " :$";

        lblTotalCharged2.Visible = false;
        txtTotalCharged2.Visible = false;
        lblTotalCharged1.Text = rdbLstTotalCharged.SelectedItem.Text + " :$";


    }

    /// <summary>
    /// Show and hide Filter criteria as per claim type selection
    /// </summary>
    private void ShowReportCriteria()
    {
        //if ((chkWC.Checked || chkNS.Checked) && !chkPL.Checked && !chkAL.Checked)
        //{
        //    pnlBodyPart.Visible = true;
        //    pnlCause.Visible = true;
        //    pnlNOI.Visible = true;
        //    pnlMedicalPaid.Visible = true;
        //    pnlMedicalInc.Visible = true;
        //    pnlMedicalOutStanding.Visible = true;
        //    pnlIndicator.Visible = true;
        //    pnlSonicCauseCode.Visible = true;
        //}
        //else
        //{
        //    pnlBodyPart.Visible = false;
        //    pnlCause.Visible = false;
        //    pnlNOI.Visible = false;
        //    pnlMedicalPaid.Visible = false;
        //    pnlMedicalOutStanding.Visible = false;
        //    pnlMedicalInc.Visible = false;
        //    pnlIndicator.Visible = false;
        //    pnlSonicCauseCode.Visible = false;
        //}

        //pnlALClaimOrigin.Visible = (!chkWC.Checked && !chkNS.Checked && !chkPL.Checked && chkAL.Checked);
    }

    /// <summary>
    /// Fill all report criteria for Ad-hoc report
    /// </summary>
    private void FillCriteria()
    {

        //Fill Region
        //dtData = new DataTable();
        Nullable<decimal> CEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CEmployee.ToString() != string.Empty && CEmployee.ToString() != "0")
            CEmployee = Convert.ToDecimal(CEmployee);
        else
            CEmployee = 0;

        CurrentEmployee = CEmployee.HasValue ? CEmployee.Value : 0;

        // select region as per login user
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        ////lstRegion.Items.Clear();
        ////lstRegion.DataTextField = "Region";
        ////lstRegion.DataValueField = "Region";
        ////lstRegion.DataSource = dsRegion;
        ////lstRegion.DataBind();

        // Append region in comma seperated string value
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                Regional += drRegion["Region"].ToString() + ",";
        }
        else
            Regional = string.Empty;

        //Fill Location
        DataSet dsLocation = ERIMS.DAL.LU_Location.SelectAllForAdhoc(CEmployee, Regional.TrimEnd(Convert.ToChar(",")));
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
        //rdoALClaimOrigin.SelectedIndex = -1;
        //chkBodypart.Checked = false;
        //chkCause.Checked = false;
        //chkCoverageState.Checked = false;
        chkLocation.Checked = false;
        //chkRegion.Checked = false;
        //chkNatureofInjury.Checked = false;
        //chkSonicCauseCode.Checked = false;

        chkSelUnSelFields.Checked = false;
        chkGrand.Checked = false;
        ddlStatus.SelectedIndex = -1;
        //chkNS.Checked = false;


        // set date criteria to Default value
        UnBindDateData(lstClaimEntered, lblDateEnteredFrom, lblDateEnteredTo, txtDate_Entered_From, txtDate_Entered_To, imgDate_Entered_To);
        UnBindDateData(lstClaimClosed, lblDateClosedFrom, lblDateClosedTo, txtDateClosedFrom, txtDateClosedTo, imgDate_Closed_To);
        UnBindDateData(lstClaimIncident, lblDateIncidentFrom, lblDateIncidentTo, txtDate_Incident_From, txtDate_Incident_To, imgDate_Incident_To);
        //UnBindDateData(lstClaimValued, lblDateValuedFrom, lblDateValuedTo, txtDateValuedFrom, txtDateValuedTo, imgDate_Valued_To);
        UnBindDateData(lstClaimReOpened, lblDateOfClaimReopenedFrom, lblDateOfClaimReopenedTo, txtDateOfClaimReopenedFrom, txtDateofClaimReopenedTo, imgDate_ClaimReopend_To);

        lstLocation.SelectedIndex = -1;

        // set Amount criteria to Default value        
        //UnBindAmountData(rdbLstMP, lblMP1, lblMP2, txtMP1, txtMP2);
        //UnBindAmountData(rdbLstComp, lblTotalComp1, lblTotalComp2, txtTotalComp1, txtTotalComp2);
        //UnBindAmountData(rdbLstTotalReserve, lblTotalRes1, lblTotalRes2, txtTotalRes1, txtTotalRes2);
        //UnBindAmountData(rdbLstUnlimitedCost, lblUnlimitedCost1, lblUnlimitedCost2, txtUnlimitedCost1, txtUnlimitedCost2);
        //UnBindAmountData(rdbLstLimitedToMV, lblLimitedToMV1, lblLimitedToMV2, txtLimitedToMV1, txtLimitedToMV2);
        //UnBindAmountData(rdbLstHCP, lblHCP1, lblHCP2, txtHCP1, txtHCP2);
        //UnBindAmountData(rdbLstHCRelief, lblHCRelief1, lblHCRelief2, txtHCRelief1, txtHCRelief2);
        //UnBindAmountData(rdbLstCollected, lblCollected1, lblCollected2, txtCollected1, txtCollected2);
        UnBindAmountData(rdbLstTotalCharged, lblTotalCharged1, lblTotalCharged2, txtTotalCharged1, txtTotalCharged2);

        lstOutputFields.SelectedIndex = -1;
        lstFirstSort.SelectedIndex = -1;
        lstSecondSort.SelectedIndex = -1;
        lstThirdSort.SelectedIndex = -1;

        txtReportName.Text = string.Empty;
        hdnReportName.Value = string.Empty;
        hdnReportId.Value = string.Empty;
        btnDeleteReport.Enabled = false;
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
        BindDateData(lstClaimEntered, lblDateEnteredFrom, lblDateEnteredTo, txtDate_Entered_From, txtDate_Entered_To, imgDate_Entered_To,
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
        BindDateData(lstClaimReOpened, lblDateOfClaimReopenedFrom, lblDateOfClaimReopenedTo, txtDateOfClaimReopenedFrom, txtDateofClaimReopenedTo, imgDate_ClaimReopend_To,
                        objAdhocReport.ClaimReserveCriteria,
                        objAdhocReport.ClaimReserveStartDate,
                        objAdhocReport.ClaimReserveEndDate);

        //if (objAdhocReport.ValueAsOfDateStartDate.ToString() != "1/1/1753 12:00:00 AM" && objAdhocReport.ValueAsOfDateStartDate.ToString() != string.Empty)
        //    txtDateofClaimReopnedFrom.Text = Convert.ToDateTime(objAdhocReport.ValueAsOfDateStartDate).ToShortDateString();



        //Status of Claim
        //if (!String.IsNullOrEmpty(objAdhocReport.OStatus))
        //    cblClaimStatus.Items.FindByValue(objAdhocReport.OStatus).Selected = true;
        //if (!String.IsNullOrEmpty(objAdhocReport.CStatus))
        //    cblClaimStatus.Items.FindByValue(objAdhocReport.CStatus).Selected = true;
        //if (!String.IsNullOrEmpty(objAdhocReport.ROStatus))
        //    cblClaimStatus.Items.FindByValue(objAdhocReport.ROStatus).Selected = true;

        //Bind All List Box Control.

        if (!String.IsNullOrEmpty(objAdhocReport.Location))
            BinListData(objAdhocReport.Location, lstLocation);


        ////Medical Paid 
        //BindAmountData(rdbLstMP, lblMP1, lblMP2, txtMP1, txtMP2,
        //                objAdhocReport.MPCriteria,
        //                objAdhocReport.MPStartAmount,
        //                objAdhocReport.MPEndAmount);
        ////Total Claim
        //BindAmountData(rdbLstComp, lblTotalComp1, lblTotalComp2, txtTotalComp1, txtTotalComp2,
        //                objAdhocReport.TCompCriteria,
        //                objAdhocReport.TCompStartAmount,
        //                objAdhocReport.TCompEndAmount);

        ////Total Reserve
        //BindAmountData(rdbLstTotalReserve, lblTotalRes1, lblTotalRes2, txtTotalRes1, txtTotalRes2,
        //                objAdhocReport.TReserveCriteria,
        //                objAdhocReport.TReserveStartAmount,
        //                objAdhocReport.TReserveEndAmount);

        ////Unlimited Cost
        //BindAmountData(rdbLstUnlimitedCost, lblUnlimitedCost1, lblUnlimitedCost2, txtUnlimitedCost1, txtUnlimitedCost2,
        //                objAdhocReport.UCostCriteria,
        //                objAdhocReport.UCostStartAmount,
        //                objAdhocReport.UCostEndAmount);

        ////Limited to MV
        //BindAmountData(rdbLstLimitedToMV, lblLimitedToMV1, lblLimitedToMV2, txtLimitedToMV1, txtLimitedToMV2,
        //                objAdhocReport.LMVCriteria,
        //                objAdhocReport.LMVStartAmount,
        //                objAdhocReport.LMVEndAmount);

        ////HCP Percent
        //BindAmountData(rdbLstHCP, lblHCP1, lblHCP2, txtHCP1, txtHCP2,
        //                objAdhocReport.HCPCriteria,
        //                objAdhocReport.HCPStartAmount,
        //                objAdhocReport.HCPEndAmount);

        ////HC Relief
        //BindAmountData(rdbLstHCRelief, lblHCRelief1, lblHCRelief2, txtHCRelief1, txtHCRelief2,
        //                objAdhocReport.HCRCriteria,
        //                objAdhocReport.HCRStartAmount,
        //                objAdhocReport.HCREndAmount);

        ////Subrogation Collected
        //BindAmountData(rdbLstCollected, lblCollected1, lblCollected2, txtCollected1, txtCollected2,
        //                objAdhocReport.SColledtedCriteria,
        //                objAdhocReport.SColledtedStartAmount,
        //                objAdhocReport.SColledtedEndAmount);


        //Total Paid To Date
        if (!String.IsNullOrEmpty(objAdhocReport.TTotalPaidCriteria))
        {
            BindAmountData(rdbLstTotalCharged, lblTotalCharged1, lblTotalCharged2, txtTotalCharged1, txtTotalCharged2,
                            objAdhocReport.TTotalPaidCriteria,
                            objAdhocReport.TTotalPaidStartAmount,
                            objAdhocReport.TTotalPaidEndAmount);
        }
        ddlStatus.SelectedValue = objAdhocReport.OStatus;
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
}
