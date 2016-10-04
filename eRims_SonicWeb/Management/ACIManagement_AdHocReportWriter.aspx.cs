using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using ERIMS.DAL;

public partial class Management_ACIManagement_AdHocReportWriter : clsBasePage
{
    public enum ReportOutputType : int
    {
        ExportToExcel = 0,
        ExportToPDF = 1,
        ExportAsMail = 2,
    }

    #region "Property"
    private string strAccessibleClaimTypes
    {
        get { return ViewState["strAccessibleClaimTypes"] == null ? "None" : Convert.ToString(ViewState["strAccessibleClaimTypes"]); }
        set { ViewState["strAccessibleClaimTypes"] = value; }
    }
    public int ReportId
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["RID"]) ? Convert.ToInt32(Request.QueryString["RID"]) : -1); }
    }

    public decimal PK_Schedule
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["PKID"]) ? Convert.ToInt32(Request.QueryString["PKID"]) : -1); }
    }

    public string strMode
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["mode"]) ? Convert.ToString(Request.QueryString["mode"]) : ""); }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_SID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SID"]);
        }
        set { ViewState["PK_SID"] = value; }
    }
    #endregion

    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCoverage();
            // Hide Opened Date TO criteria
            string strType = "999";//GetSelectedCoverage();
            SetDefaults(strType);
            ClearAllFilterPanel();
            // Reset Scroll Position
            ResetScrollPosition();
            //Recipient List
            ComboHelper.GetRecipientList(ddlRecipientList);
            //Hide Hidden Button
            btnHdnScheduling.Style["display"] = "none";

            //clsGeneral.SetDropdownValue(drpFilter1, "Is Actionable", false);
            //chkNotCriteria1.Visible = true;
            //LoadFilterControlDropDown("Is Actionable", "Y", lst_F1);

            if (ReportId > 0 && PK_Schedule > 0 && strMode == "edit")
            {
                //GetdrpFilterChange();              
                BindAdHocReportEdit();
            }
        }
        else
        {
            // This condition is execute when User Enter reprot name which is already exists & User Confirm overwrite existing report
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

            #region "Maintain Attribute"

            //Maintain Attribute of Textbox after PostBack
            if (drpFilter1.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F1, lblAmountText1_F1, txtAmount1_F1, lblAmountText2_F1, txtAmount2_F1, cvAmount1);
            if (drpFilter2.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F2, lblAmountText1_F2, txtAmount1_F2, lblAmountText2_F2, txtAmount2_F2, cvAmount2);
            if (drpFilter3.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F3, lblAmountText1_F3, txtAmount1_F3, lblAmountText2_F3, txtAmount2_F3, cvAmount3);
            if (drpFilter4.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F4, lblAmountText1_F4, txtAmount1_F4, lblAmountText2_F4, txtAmount2_F4, cvAmount4);
            if (drpFilter5.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F5, lblAmountText1_F5, txtAmount1_F5, lblAmountText2_F5, txtAmount2_F5, cvAmount5);
            if (drpFilter6.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F6, lblAmountText1_F6, txtAmount1_F6, lblAmountText2_F6, txtAmount2_F6, cvAmount6);
            if (drpFilter7.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F7, lblAmountText1_F7, txtAmount1_F7, lblAmountText2_F7, txtAmount2_F7, cvAmount7);
            if (drpFilter8.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F8, lblAmountText1_F8, txtAmount1_F8, lblAmountText2_F8, txtAmount2_F8, cvAmount8);
            if (drpFilter9.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F9, lblAmountText1_F9, txtAmount1_F9, lblAmountText2_F9, txtAmount2_F9, cvAmount9);
            if (drpFilter10.SelectedItem.Text == "Operator Age")
                drpAmount_Changed(false, drpAmount_F10, lblAmountText1_F10, txtAmount1_F10, lblAmountText2_F10, txtAmount2_F10, cvAmount10);

            #endregion
        }

        rblCoverage.Focus();
        //clsGeneral.SetDropDownToolTip(new DropDownList[] { ddlRecipientList, ddlReports });
        // Set Column Name to PDF control
        //CtrlDistribution._NumberofColumn = lstSelectedFields.Items.Count;
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Event to Handle Export to Excel click event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        //Bind Report
        StringBuilder sbRecord = new StringBuilder();
        string strFilePath = BindReport(ref sbRecord, ReportOutputType.ExportToExcel);
          string outputFiles=string.Empty;
          bool blnHTML2Excel=false;
        if(File.Exists(strFilePath))
        {
        string data = File.ReadAllText(strFilePath);
        data = data.Trim();
        HTML2Excel objHtml2Excel = new HTML2Excel(data);
       outputFiles = Path.GetFullPath(strFilePath) + ".xlsx";
        blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);
        }
        //If records found
        //if (File.Exists(strFilePath))
        if (blnHTML2Excel)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + "Ad Hoc Report.xlsx" + "\""));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.TransmitFile(outputFiles);
                HttpContext.Current.Response.Flush();
            }
            finally
            {
                if (File.Exists(outputFiles))
                    File.Delete(outputFiles);
                if (File.Exists(strFilePath))
                    File.Delete(strFilePath);

                HttpContext.Current.Response.End();
            }
        }
    }

    /// <summary>
    /// send Email for all selected receipients
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSendEmail_Click(object sender, EventArgs e)
    {
        //Bind Report
        StringBuilder sbRecord = new StringBuilder();
        string strFilePath = BindReport(ref sbRecord, ReportOutputType.ExportAsMail);
        bool blnHTML2Excel = false;
        string outputFiles = string.Empty;
        if (File.Exists(strFilePath))
        {
            string data = File.ReadAllText(strFilePath);
            data = data.Trim();
            HTML2Excel objHtml2Excel = new HTML2Excel(data);
            outputFiles = Path.GetFullPath(strFilePath) + ".xlsx";
            blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);
        }
        //If records found
        if (blnHTML2Excel)
        {
            if (clsGeneral.SendAdHocReport("Ad Hoc Report", outputFiles, "Management Ad-Hoc Report.xlsx", Convert.ToDecimal(ddlRecipientList.SelectedItem.Value)))
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Email Sent Successfully')", true);
                File.Delete(strFilePath);
            }

            else
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Error occured while sending email.Please contact administrator')", true);
        }
    }

    ///// <summary>
    ///// Handle Distribution Folder Save button click events
    ///// </summary>
    //protected void ReportDistributionSaveClick()
    //{
    //    //Bind and Export to Excel Report
    //    StringBuilder sbRecord = new StringBuilder();
    //    string strPath = BindReport(ref sbRecord, ReportOutputType.ExportToPDF);

    //    //If records found then save records
    //    if (File.Exists(strPath))
    //        CtrlDistribution.SaveReportForDistribution(strPath);
    //}

    /// <summary>
    /// handle Submit button Click events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strType = GetSelectedCoverage();

        DataTable dtAdHocReport = ERIMS.DAL.Management_AdHocReport.ExistsReportName(strType, txtReportName.Text, (ddlReports.SelectedIndex > 0) ? Convert.ToDecimal(ddlReports.SelectedValue) : 0);

        if (dtAdHocReport.Rows.Count > 0)
        {
            hdnReportId.Value = Convert.ToString(dtAdHocReport.Rows[0]["PK_Management_AdHocReport"]);
            String confirmMessage = "Are you sure you want to overwrite the existing report " + txtReportName.Text.Trim().Replace(@"\", @"\\").Replace("\"", "\\\"") + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", "__doPostBack('UserConfirmationPostBack',  window.confirm(\"" + confirmMessage + "\"));", true);
        }
        else
            SaveReport();
    }

    //Call from Schedule Page
    protected void btnHdnScheduling_Click(object sender, EventArgs e)
    {
        //Set Report id To null so , New Report is created with new Schedule.
        // hdnReportId.Value = string.Empty;
        SaveReport();
        if (hdnScheduleID.Value != "0")
            PK_SID = Convert.ToDecimal(hdnScheduleID.Value);
    }

    /// <summary>
    /// Handle Delete report Button click events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteReport_Click(object sender, EventArgs e)
    {
        if (ddlReports.SelectedIndex > 0)
        {
            // Delete Report and all Filter Criteria
            ERIMS.DAL.Management_AdHocReport.DeleteByPK(Convert.ToDecimal(ddlReports.SelectedItem.Value));
            hdnReportId.Value = "0";
            txtReportName.Text = "";
            string strType = GetSelectedCoverage();
            SetDefaults(strType);
            ClearAllFilterPanel();
            ClearControls();
            ResetScrollPosition();
        }
    }

    /// <summary>
    /// Event to Handle Clear all COntrol
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        // Clear Coverages
        rblCoverage.ClearSelection();
        string strType = GetSelectedCoverage();

        SetDefaults(strType);
        ClearAllFilterPanel();
        ClearControls();
        ClearNotCheckCriteria();
        // maintain Scroll Bar Possition on Post Back
        ResetScrollPosition();
        if (strMode == "edit")
        {
            PK_SID = -1;
            hdnReportId.Value = string.Empty;
        }
    }

    /// <summary>
    /// Event to handle Select output fileds
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstOutputFields, lstSelectedFields, true, true, false);
    }

    /// <summary>
    /// Event to Handle select All output fileds.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstOutputFields, lstSelectedFields, false, true, false);
    }

    /// <summary>
    /// Event to handle Desect Fields
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeselectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSelectedFields, lstOutputFields, true, false, true);
    }

    /// <summary>
    /// Event to handle DeSelect All Output Fileds.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeselectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSelectedFields, lstOutputFields, false, false, true);
    }

    /// <summary>
    /// Move to Up Selected fields
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgUp_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < lstSelectedFields.Items.Count; i++)
        {
            if (lstSelectedFields.Items[i].Selected)//identify the selected item
            {
                //swap with the top item(move up)
                if (i > 0 && !lstSelectedFields.Items[i - 1].Selected)
                {
                    ListItem bottom = lstSelectedFields.Items[i];
                    lstSelectedFields.Items.Remove(bottom);
                    lstSelectedFields.Items.Insert(i - 1, bottom);
                    lstSelectedFields.Items[i - 1].Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Move to Down Selected fields
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgDown_Click(object sender, ImageClickEventArgs e)
    {
        int startindex = lstSelectedFields.Items.Count - 1;
        for (int i = startindex; i > -1; i--)
        {
            if (lstSelectedFields.Items[i].Selected)//identify the selected item
            {
                //swap with the lower item(move down)
                if (i < startindex && !lstSelectedFields.Items[i + 1].Selected)
                {
                    ListItem bottom = lstSelectedFields.Items[i];
                    lstSelectedFields.Items.Remove(bottom);
                    lstSelectedFields.Items.Insert(i + 1, bottom);
                    lstSelectedFields.Items[i + 1].Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Select Relative Date
    /// </summary>
    protected void RaltiveDatesSaveClick(string senderID)
    {
        //Set Relative Date TextBox , Date image and Manage Enable,Disable
        switch (senderID)
        {
            case "ucRelativeDatesFrom_1":
                if (ucRelativeDatesFrom_1.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From1, imgDate_Opened_From1, true);
                    txtDate_From1.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_1.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From1, imgDate_Opened_From1, false);
                break;
            case "ucRelativeDatesTo_1":
                if (ucRelativeDatesTo_1.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To1, imgDate_To1, true);
                    txtDate_To1.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_1.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To1, imgDate_To1, true);
                break;
            case "ucRelativeDatesFrom_2":
                if (ucRelativeDatesFrom_2.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From2, imgDate_Opened_From2, true);
                    txtDate_From2.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_2.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From2, imgDate_Opened_From2, false);
                break;
            case "ucRelativeDatesTo_2":
                if (ucRelativeDatesTo_2.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDateTo2, imgDate_To2, true);
                    txtDateTo2.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_2.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDateTo2, imgDate_To2, false);
                break;
            case "ucRelativeDatesFrom_3":
                if (ucRelativeDatesFrom_3.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    txtDate_From3.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_3.RelativeDate).ToString("MM/dd/yyyy");
                    SetRelativeDateControl(txtDate_From3, imgDate_Opened_From3, true);
                }
                else SetRelativeDateControl(txtDate_From3, imgDate_Opened_From3, false);
                break;
            case "ucRelativeDatesTo_3":
                if (ucRelativeDatesTo_3.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To3, imgDate_To3, true);
                    txtDate_To3.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_3.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To3, imgDate_To3, false);

                break;
            case "ucRelativeDatesFrom_4":
                if (ucRelativeDatesFrom_4.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From4, imgDate_Opened_From4, true);
                    txtDate_From4.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_4.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From4, imgDate_Opened_From4, false);
                break;
            case "ucRelativeDatesTo_4":
                if (ucRelativeDatesTo_4.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To4, imgDate_To4, true);
                    txtDate_To4.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_4.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To4, imgDate_To4, false);
                break;
            case "ucRelativeDatesFrom_5":
                if (ucRelativeDatesFrom_5.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From5, imgDate_Opened_From5, true);
                    txtDate_From5.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_5.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From5, imgDate_Opened_From5, false);
                break;
            case "ucRelativeDatesTo_5":
                if (ucRelativeDatesTo_5.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To5, imgDate_To5, true);
                    txtDate_To5.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_5.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To5, imgDate_To5, false);
                break;
            case "ucRelativeDatesFrom_6":
                if (ucRelativeDatesFrom_6.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From6, imgDate_Opened_From6, true);
                    txtDate_From6.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_6.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From6, imgDate_Opened_From6, false);
                break;
            case "ucRelativeDatesTo_6":
                if (ucRelativeDatesTo_6.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To6, imgDate_To6, true);
                    txtDate_To6.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_6.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To6, imgDate_To6, false);
                break;
            case "ucRelativeDatesFrom_7":
                if (ucRelativeDatesFrom_7.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From7, imgDate_Opened_From7, true);
                    txtDate_From7.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_7.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From7, imgDate_Opened_From7, false);
                break;
            case "ucRelativeDatesTo_7":
                if (ucRelativeDatesTo_7.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To7, imgDate_To7, true);
                    txtDate_To7.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_7.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To7, imgDate_To7, false);
                break;
            case "ucRelativeDatesFrom_8":
                if (ucRelativeDatesFrom_8.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From8, imgDate_Opened_From8, true);
                    txtDate_From8.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_8.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From8, imgDate_Opened_From8, false);
                break;
            case "ucRelativeDatesTo_8":
                if (ucRelativeDatesTo_8.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To8, imgDate_To8, true);
                    txtDate_To8.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_8.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To8, imgDate_To8, false);
                break;
            case "ucRelativeDatesFrom_9":
                if (ucRelativeDatesFrom_9.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From9, imgDate_Opened_From9, true);
                    txtDate_From9.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_9.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From9, imgDate_Opened_From9, false);
                break;
            case "ucRelativeDatesTo_9":
                if (ucRelativeDatesTo_9.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To9, imgDate_To9, true);
                    txtDate_To9.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_9.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To9, imgDate_To9, false);
                break;
            case "ucRelativeDatesFrom_10":
                if (ucRelativeDatesFrom_10.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_From10, imgDate_Opened_From10, true);
                    txtDate_From10.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesFrom_10.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_From10, imgDate_Opened_From10, false);
                break;
            case "ucRelativeDatesTo_10":
                if (ucRelativeDatesTo_10.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtDate_To10, imgDate_To10, true);
                    txtDate_To10.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDatesTo_10.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtDate_To10, imgDate_To10, false);
                break;
            case "ucRelativeDates_PriorVal":
                if (ucRelativeDates_PriorVal.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
                {
                    SetRelativeDateControl(txtPriorDate, imgPriorValuationDate, true);
                    txtPriorDate.Text = AdHocReportHelper.GetRelativeDate(ucRelativeDates_PriorVal.RelativeDate).ToString("MM/dd/yyyy");
                }
                else SetRelativeDateControl(txtPriorDate, imgPriorValuationDate, false);
                break;
            default:

                break;
        }
    }


    #endregion

    #region "Selected Index Change"

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrator/ReportScheduleList.aspx");
    }

    /// <summary>
    /// Handle Radio button list Change event for all date criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdbLstDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (((DropDownList)sender).ID)
        {
            case "lstDate1":
                // Set Date control Text and show-hide Date textbox as per selected criteria
                SetDateControls(lstDate1, lblDateFrom1, lblDateTo1, txtDate_From1, txtDate_To1, imgDate_To1, revtxtDate_From1, ucRelativeDatesTo_1);
                txtDate_To1.Text = string.Empty; break;
            case "lstDate2":
                SetDateControls(lstDate2, lblDateFrom2, lblDateTo2, txtDate_From2, txtDateTo2, imgDate_To2, revtxtDate_From2, ucRelativeDatesTo_2);
                txtDateTo2.Text = string.Empty;
                break;
            case "lstDate3":
                SetDateControls(lstDate3, lblDateFrom3, lblDateTo3, txtDate_From3, txtDate_To3, imgDate_To3, revtxtDate_From3, ucRelativeDatesTo_3);
                txtDate_To3.Text = string.Empty; break;
            case "lstDate4":
                SetDateControls(lstDate4, lblDateFrom4, lblDateTo4, txtDate_From4, txtDate_To4, imgDate_To4, revtxtDate_From4, ucRelativeDatesTo_4);
                txtDate_To4.Text = string.Empty; break;
            case "lstDate5":
                SetDateControls(lstDate5, lblDateFrom5, lblDateTo5, txtDate_From5, txtDate_To5, imgDate_To5, revtxtDate_From5, ucRelativeDatesTo_5);
                txtDate_To5.Text = string.Empty; break;
            case "lstDate6":
                SetDateControls(lstDate6, lblDateFrom6, lblDateTo6, txtDate_From6, txtDate_To6, imgDate_To6, revtxtDate_From6, ucRelativeDatesTo_6);
                txtDate_To6.Text = string.Empty; break;
            case "lstDate7":
                SetDateControls(lstDate7, lblDateFrom7, lblDateTo7, txtDate_From7, txtDate_To7, imgDate_To7, revtxtDate_From7, ucRelativeDatesTo_7);
                txtDate_To7.Text = string.Empty; break;
            case "lstDate8":
                SetDateControls(lstDate8, lblDateFrom8, lblDateTo8, txtDate_From8, txtDate_To8, imgDate_To8, revtxtDate_From8, ucRelativeDatesTo_8);
                txtDate_To8.Text = string.Empty; break;
            case "lstDate9":
                SetDateControls(lstDate9, lblDateFrom9, lblDateTo9, txtDate_From9, txtDate_To9, imgDate_To9, revtxtDate_From9, ucRelativeDatesTo_9);
                txtDate_To9.Text = string.Empty; break;
            case "lstDate10":
                SetDateControls(lstDate10, lblDateFrom10, lblDateTo10, txtDate_From10, txtDate_To10, imgDate_To10, revtxtDate_From10, ucRelativeDatesTo_10);
                txtDate_To10.Text = string.Empty; break;
            default:
                break;
        }
    }

    /// <summary>
    /// Event to handle radio Button Selected Index Change.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rblCoverage_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strType = GetSelectedCoverage();

        SetDefaults(strType);
        ClearAllFilterPanel();
        ClearControls();
        // Reset Scroll Position
        ResetScrollPosition();
        ClearNotCheckCriteria();
    }

    /// <summary>
    /// EVent to handle Dropdown filter change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (((DropDownList)sender).ID)
        {
            case "drpFilter1":
                drpFilterChange(drpFilter1, pnlText_F1, pnlAmount_F1, pnlDate_F1, lst_F1, chkNotCriteria1);
                break;
            case "drpFilter2":
                drpFilterChange(drpFilter2, pnlText_F2, pnlAmount_F2, pnlDate_F2, lst_F2, chkNotCriteria2);
                break;
            case "drpFilter3":
                drpFilterChange(drpFilter3, pnlText_F3, pnlAmount_F3, pnlDate_F3, lst_F3, chkNotCriteria3);
                break;
            case "drpFilter4":
                drpFilterChange(drpFilter4, pnlText_F4, pnlAmount_F4, pnlDate_F4, lst_F4, chkNotCriteria4);
                break;
            case "drpFilter5":
                drpFilterChange(drpFilter5, pnlText_F5, pnlAmount_F5, pnlDate_F5, lst_F5, chkNotCriteria5);
                break;
            case "drpFilter6":
                drpFilterChange(drpFilter6, pnlText_F6, pnlAmount_F6, pnlDate_F6, lst_F6, chkNotCriteria6);
                break;
            case "drpFilter7":
                drpFilterChange(drpFilter7, pnlText_F7, pnlAmount_F7, pnlDate_F7, lst_F7, chkNotCriteria7);
                break;
            case "drpFilter8":
                drpFilterChange(drpFilter8, pnlText_F8, pnlAmount_F8, pnlDate_F8, lst_F8, chkNotCriteria8);
                break;
            case "drpFilter9":
                drpFilterChange(drpFilter9, pnlText_F9, pnlAmount_F9, pnlDate_F9, lst_F9, chkNotCriteria9);
                break;
            case "drpFilter10":
                drpFilterChange(drpFilter10, pnlText_F10, pnlAmount_F10, pnlDate_F10, lst_F10, chkNotCriteria10);
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// Event to handle Amout dropdown change.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpAmount_F_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool isDollar = true;
        string strSelText = "";
        switch (((DropDownList)sender).ID)
        {
            case "drpAmount_F1":
                if (drpFilter1.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F1, lblAmountText1_F1, txtAmount1_F1, lblAmountText2_F1, txtAmount2_F1, cvAmount1);
                break;
            case "drpAmount_F2":
                if (drpFilter2.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F2, lblAmountText1_F2, txtAmount1_F2, lblAmountText2_F2, txtAmount2_F2, cvAmount2);
                break;
            case "drpAmount_F3":
                if (drpFilter3.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F3, lblAmountText1_F3, txtAmount1_F3, lblAmountText2_F3, txtAmount2_F3, cvAmount3);
                break;
            case "drpAmount_F4":
                if (drpFilter4.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F4, lblAmountText1_F4, txtAmount1_F4, lblAmountText2_F4, txtAmount2_F4, cvAmount4);
                break;
            case "drpAmount_F5":
                if (drpFilter5.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F5, lblAmountText1_F5, txtAmount1_F5, lblAmountText2_F5, txtAmount2_F5, cvAmount5);
                break;
            case "drpAmount_F6":
                if (drpFilter6.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F6, lblAmountText1_F6, txtAmount1_F6, lblAmountText2_F6, txtAmount2_F6, cvAmount6);
                break;
            case "drpAmount_F7":
                if (drpFilter7.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F7, lblAmountText1_F7, txtAmount1_F7, lblAmountText2_F7, txtAmount2_F7, cvAmount7);
                break;
            case "drpAmount_F8":
                if (drpFilter8.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F8, lblAmountText1_F8, txtAmount1_F8, lblAmountText2_F8, txtAmount2_F8, cvAmount8);
                break;
            case "drpAmount_F9":
                if (drpFilter9.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F9, lblAmountText1_F9, txtAmount1_F9, lblAmountText2_F9, txtAmount2_F9, cvAmount9);
                break;
            case "drpAmount_F10":
                if (drpFilter10.SelectedItem.Text == "Operator Age")
                    isDollar = false;
                drpAmount_Changed(isDollar, drpAmount_F10, lblAmountText1_F10, txtAmount1_F10, lblAmountText2_F10, txtAmount2_F10, cvAmount10);
                break;
            default:
                break;
            // drpAmount_Changed
        }
    }

    /// <summary>
    /// Handle Report Name dropdown Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlReports_SelectedIndexChanged(object sender, EventArgs e)
    {
        decimal? _dcSelectedReport = null;
        // Check if Report Name is selected or not
        if (ddlReports.SelectedIndex > 0)
        {
            // Set Report PK
            _dcSelectedReport = 0;

            List<ERIMS.DAL.Management_AdHocFilter> lstFilter = new List<Management_AdHocFilter>();

            _dcSelectedReport = Convert.ToDecimal(ddlReports.SelectedItem.Value);
            lstFilter = new ERIMS.DAL.Management_AdHocFilter().GetAdHocReportFieldByPk(_dcSelectedReport.Value);

            ERIMS.DAL.Management_AdHocReport ObjAdHocReport = new ERIMS.DAL.Management_AdHocReport(_dcSelectedReport.Value);

            // Clear All Panels to bank
            ClearAllFilterPanel();

            // Clear All Control
            ClearControls();

            ClearNotCheckCriteria();


            // Bind Output fileds
            BindOutpuFields(GetSelectedCoverage());

            // Remove Selected Output fields from Report Ouput List
            RemoveSelectedItem(ObjAdHocReport.OutputFields);

            // Set Control from database
            if (!string.IsNullOrEmpty(ObjAdHocReport.PriorValuation_RelativeDate))
            {
                // set Relative Date From criteria
                AdHocReportHelper.RaltiveDates RelType = (AdHocReportHelper.RaltiveDates)Enum.Parse(typeof(AdHocReportHelper.RaltiveDates), ObjAdHocReport.PriorValuation_RelativeDate);
                txtPriorDate.Text = AdHocReportHelper.GetRelativeDate(RelType).ToString(AppConfig.DisplayDateFormat);
            }
            else
                txtPriorDate.Text = clsGeneral.FormatDBNullDateToDisplay(ObjAdHocReport.PriorValuationDate);

            chkGrandTotal.Checked = ObjAdHocReport.GrandTotal == "Y";

            SetGroupFilterByControl(ObjAdHocReport.FirstGroupBy, drpGroupByFirst, rdblGroupSortByFirst, ObjAdHocReport.FirstGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.SecondGroupBy, drpGroupBySecond, rdblGroupSortBySecond, ObjAdHocReport.SecondGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.FirstSortBy, drpSortingFirst, rdbSort1, ObjAdHocReport.FirstSortByOrder);
            SetGroupFilterByControl(ObjAdHocReport.SecondSortBy, drpSortingSecond, rdbSort2, ObjAdHocReport.SecondSortByOrder);
            SetGroupFilterByControl(ObjAdHocReport.ThirdSortBy, drpSortingThird, rdbSort3, ObjAdHocReport.ThirdSortByOrder);
            //Add New GroupBY
            SetGroupFilterByControl(ObjAdHocReport.ThirdGroupBy, drpGroupByThird, rdblGroupSortByThird, ObjAdHocReport.ThirdGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.FourthGroupBy, drpGroupByFourth, rdblGroupSortByFourth, ObjAdHocReport.FourthGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.FifthGroupBy, drpGroupByFifth, rdblGroupSortByFifth, ObjAdHocReport.FifthGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.FourthSortBy, drpSortingFourth, rdbSort4, ObjAdHocReport.FourthSortByOrder);
            SetGroupFilterByControl(ObjAdHocReport.FifthSortBy, drpSortingFifth, rdbSort5, ObjAdHocReport.FifthSortByOrder);

            txtReportName.Text = ddlReports.SelectedItem.Text.Trim();
            btnDeleteReport.Enabled = true;


            // Chekc if AdHoc Filter Criteria is exists or not
            if (lstFilter.Count > 0)
            {
                for (int i = 0; i < lstFilter.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            // Set Filter Drop Down
                            LoadFilterCriteria(lstFilter[i], drpFilter1);
                            chkNotCriteria1.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria1);
                            // Set Text value Criteria
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F1, txtFilter1, drpText_F1);
                            // Set Multi Selection listBox Criteria
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F1);
                            // Set Amount field Criteria
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F1, drpAmount_F1, txtAmount1_F1, txtAmount2_F1, lblAmountText1_F1, lblAmountText2_F1, cvAmount1);
                            // Set Date Control Filter Criteria
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F1, lstDate1, lblDateFrom1, lblDateTo1, txtDate_From1, txtDate_To1, imgDate_To1, revtxtDate_From1, ucRelativeDatesFrom_1, ucRelativeDatesTo_1, imgDate_Opened_From1);
                            break;
                        case 1:
                            LoadFilterCriteria(lstFilter[i], drpFilter2);
                            chkNotCriteria2.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria2);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F2, txtFilter2, drpText_F2);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F2);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F2, drpAmount_F2, txtAmount1_F2, txtAmount2_F2, lblAmountText1_F2, lblAmountText2_F2, cvAmount2);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F2, lstDate2, lblDateFrom2, lblDateTo2, txtDate_From2, txtDateTo2, imgDate_To2, revtxtDate_From2, ucRelativeDatesFrom_2, ucRelativeDatesTo_2, imgDate_Opened_From2);
                            break;
                        case 2:
                            LoadFilterCriteria(lstFilter[i], drpFilter3);
                            chkNotCriteria3.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria3);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F3, txtFilter3, drpText_F3);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F3);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F3, drpAmount_F3, txtAmount1_F3, txtAmount2_F3, lblAmountText1_F3, lblAmountText2_F3, cvAmount3);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F3, lstDate3, lblDateFrom3, lblDateTo3, txtDate_From3, txtDate_To3, imgDate_To3, revtxtDate_From3, ucRelativeDatesFrom_3, ucRelativeDatesTo_3, imgDate_Opened_From3);
                            break;
                        case 3:
                            LoadFilterCriteria(lstFilter[i], drpFilter4);
                            chkNotCriteria4.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria4);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F4, txtFilter4, drpText_F4);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F4);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F4, drpAmount_F4, txtAmount1_F4, txtAmount2_F4, lblAmountText1_F4, lblAmountText2_F4, cvAmount4);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F4, lstDate4, lblDateFrom4, lblDateTo4, txtDate_From4, txtDate_To4, imgDate_To4, revtxtDate_From4, ucRelativeDatesFrom_4, ucRelativeDatesTo_4, imgDate_Opened_From4);
                            break;
                        case 4:
                            LoadFilterCriteria(lstFilter[i], drpFilter5);
                            chkNotCriteria5.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria5);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F5, txtFilter5, drpText_F5);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F5);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F5, drpAmount_F5, txtAmount1_F5, txtAmount2_F5, lblAmountText1_F5, lblAmountText2_F5, cvAmount5);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F5, lstDate5, lblDateFrom5, lblDateTo5, txtDate_From5, txtDate_To5, imgDate_To5, revtxtDate_From5, ucRelativeDatesFrom_5, ucRelativeDatesTo_5, imgDate_Opened_From5);
                            break;
                        case 5:
                            LoadFilterCriteria(lstFilter[i], drpFilter6);
                            chkNotCriteria6.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria6);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F6, txtFilter6, drpText_F6);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F6);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F6, drpAmount_F6, txtAmount1_F6, txtAmount2_F6, lblAmountText1_F6, lblAmountText2_F6, cvAmount6);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F6, lstDate6, lblDateFrom6, lblDateTo6, txtDate_From6, txtDate_To6, imgDate_To6, revtxtDate_From6, ucRelativeDatesFrom_6, ucRelativeDatesTo_6, imgDate_Opened_From6);
                            break;
                        case 6:
                            LoadFilterCriteria(lstFilter[i], drpFilter7);
                            chkNotCriteria7.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria7);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F7, txtFilter7, drpText_F7);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F7);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F7, drpAmount_F7, txtAmount1_F7, txtAmount2_F7, lblAmountText1_F7, lblAmountText2_F7, cvAmount7);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F7, lstDate7, lblDateFrom7, lblDateTo7, txtDate_From7, txtDate_To7, imgDate_To7, revtxtDate_From7, ucRelativeDatesFrom_7, ucRelativeDatesTo_7, imgDate_Opened_From7);
                            break;
                        case 7:
                            LoadFilterCriteria(lstFilter[i], drpFilter8);
                            chkNotCriteria8.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria8);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F8, txtFilter8, drpText_F8);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F8);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F8, drpAmount_F8, txtAmount1_F8, txtAmount2_F8, lblAmountText1_F8, lblAmountText2_F8, cvAmount8);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F8, lstDate8, lblDateFrom8, lblDateTo8, txtDate_From8, txtDate_To8, imgDate_To8, revtxtDate_From8, ucRelativeDatesFrom_8, ucRelativeDatesTo_8, imgDate_Opened_From8);
                            break;
                        case 8:
                            LoadFilterCriteria(lstFilter[i], drpFilter9);
                            chkNotCriteria9.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria9);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F9, txtFilter9, drpText_F9);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F9);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F9, drpAmount_F9, txtAmount1_F9, txtAmount2_F9, lblAmountText1_F9, lblAmountText2_F9, cvAmount9);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F9, lstDate9, lblDateFrom9, lblDateTo9, txtDate_From9, txtDate_To9, imgDate_To9, revtxtDate_From9, ucRelativeDatesFrom_9, ucRelativeDatesTo_9, imgDate_Opened_From9);
                            break;
                        case 9:
                            chkNotCriteria10.Visible = true;
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria10);
                            LoadFilterCriteria(lstFilter[i], drpFilter10);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F10, txtFilter10, drpText_F10);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F10);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F10, drpAmount_F10, txtAmount1_F10, txtAmount2_F10, lblAmountText1_F10, lblAmountText2_F10, cvAmount10);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F10, lstDate10, lblDateFrom10, lblDateTo10, txtDate_From10, txtDate_To10, imgDate_To10, revtxtDate_From10, ucRelativeDatesFrom_10, ucRelativeDatesTo_10, imgDate_Opened_From10);
                            break;
                        default: break;
                    }

                }
                //Set Relative Date and it's Control
                SetRelativeDateControl();
            }
        }
        else
        {
            txtReportName.Text = "";
            btnDeleteReport.Enabled = false;
            //Get Major Coverage IDs Before Clear it
            string strType = GetSelectedCoverage();
            SetDefaults(strType);
            ClearAllFilterPanel();
            ClearControls();
            ClearNotCheckCriteria();
        }
        //Enable Disable Output Field Button.
        btnDeselectFields.Enabled = lstSelectedFields.Items.Count > 0;
        imgUp.Enabled = imgDown.Enabled = btnDeselectAllFields.Enabled = lstSelectedFields.Items.Count > 0;
        btnSelectAllFields.Enabled = btnSelectFields.Enabled = lstOutputFields.Items.Count > 0;

        hdnReportId.Value = (_dcSelectedReport == null) ? "0" : _dcSelectedReport.Value.ToString();
        // Reset Scroll Position
        ResetScrollPosition();
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Generate Filter Criteria
    /// </summary>
    /// <returns></returns>
    private string GenerateFilterCriteria()
    {
        StringBuilder strExport = new StringBuilder();

        strExport.Append("<table style='font-size:10pt;'>");
        strExport.Append("<tr><td>&nbsp;</td></tr>");
        strExport.Append("<tr>");
        strExport.Append("<td colspan='4'><b>Report Title : Management Ad-Hoc Report</b></td>");
        strExport.Append("</tr>");
        strExport.Append("<tr><td>&nbsp;</td></tr>");
        if (drpGroupByFirst.SelectedIndex > 0)
            strExport.Append("<tr><td nowrap='nowrap' colspan='4'><b> First Group By : </b> &nbsp;" + Convert.ToString(drpGroupByFirst.SelectedItem.Text) + " &nbsp; <b>Sorting : </b>&nbsp; " + Convert.ToString(rdblGroupSortByFirst.SelectedItem.Text).ToUpper() + " </td></tr>");
        else
            strExport.Append("<tr><td ><b> First Group By : </b> &nbsp; </td></tr>");

        if (drpGroupBySecond.SelectedIndex > 0)
            strExport.Append("<tr><td nowrap='nowrap' colspan='4'><b> Second Group By : </b>&nbsp;" + Convert.ToString(drpGroupBySecond.SelectedItem.Text) + " &nbsp; <b>Sorting : </b>&nbsp; " + Convert.ToString(rdblGroupSortBySecond.SelectedItem.Text).ToUpper() + " </td></tr>");
        else
            strExport.Append("<tr><td ><b> Second Group By : </b> &nbsp; </td></tr>");

        if (drpGroupByThird.SelectedIndex > 0)
            strExport.Append("<tr><td nowrap='nowrap' colspan='4'><b> Third Group By : </b>&nbsp;" + Convert.ToString(drpGroupByThird.SelectedItem.Text) + " &nbsp; <b>Sorting : </b> &nbsp;" + Convert.ToString(rdblGroupSortByThird.SelectedItem.Text).ToUpper() + " </td></tr>");
        else
            strExport.Append("<tr><td ><b> Third Group By : </b> &nbsp; </td></tr>");

        if (drpGroupByFourth.SelectedIndex > 0)
            strExport.Append("<tr><td nowrap='nowrap' colspan='4'><b> Fourth Group By : </b>&nbsp;" + Convert.ToString(drpGroupByFourth.SelectedItem.Text) + " &nbsp; <b>Sorting : </b>&nbsp; " + Convert.ToString(rdblGroupSortByFourth.SelectedItem.Text).ToUpper() + " </td></tr>");
        else
            strExport.Append("<tr><td ><b> Fourth Group By : </b> &nbsp; </td></tr>");

        if (drpGroupByFifth.SelectedIndex > 0)
            strExport.Append("<tr><td nowrap='nowrap' colspan='4'><b> Fifth Group By : </b>&nbsp;" + Convert.ToString(drpGroupByFifth.SelectedItem.Text) + " &nbsp; <b>Sorting : </b>&nbsp; " + Convert.ToString(rdblGroupSortByFifth.SelectedItem.Text).ToUpper() + " </td></tr>");
        else
            strExport.Append("<tr><td ><b> Fifth Group By : </b> &nbsp; </td></tr>");

        //strExport.Append("<tr><td ><b> Prior Valuation Date : </b>" + clsGeneral.FormatDBNullDateToDisplay(txtPriorDate.Text) + "</td></tr>");

        strExport.Append(GetClaimSummaryFiltersDetails());
        strExport.Append("<tr><td>&nbsp;</td></tr>");
        strExport.Append("</table>");

        return strExport.ToString();
    }

    /// <summary>
    /// Get Claim Summary Filters
    /// </summary>
    /// <returns></returns>
    private string GetClaimSummaryFiltersDetails()
    {
        StringBuilder strWhere = new StringBuilder();

        strWhere.Append(GetSelectedFilters(drpFilter1, drpText_F1, txtFilter1, lst_F1, lstDate1, txtDate_From1, txtDate_To1, drpAmount_F1, txtAmount1_F1, txtAmount2_F1, chkNotCriteria1));
        strWhere.Append(GetSelectedFilters(drpFilter2, drpText_F2, txtFilter2, lst_F2, lstDate2, txtDate_From2, txtDateTo2, drpAmount_F2, txtAmount1_F2, txtAmount2_F2, chkNotCriteria2));
        strWhere.Append(GetSelectedFilters(drpFilter3, drpText_F3, txtFilter3, lst_F3, lstDate3, txtDate_From3, txtDate_To3, drpAmount_F3, txtAmount1_F3, txtAmount2_F3, chkNotCriteria3));
        strWhere.Append(GetSelectedFilters(drpFilter4, drpText_F4, txtFilter4, lst_F4, lstDate4, txtDate_From4, txtDate_To4, drpAmount_F4, txtAmount1_F4, txtAmount2_F4, chkNotCriteria4));
        strWhere.Append(GetSelectedFilters(drpFilter5, drpText_F5, txtFilter5, lst_F5, lstDate5, txtDate_From5, txtDate_To5, drpAmount_F5, txtAmount1_F5, txtAmount2_F5, chkNotCriteria5));
        strWhere.Append(GetSelectedFilters(drpFilter6, drpText_F6, txtFilter6, lst_F6, lstDate6, txtDate_From6, txtDate_To6, drpAmount_F6, txtAmount1_F6, txtAmount2_F6, chkNotCriteria6));
        strWhere.Append(GetSelectedFilters(drpFilter7, drpText_F7, txtFilter7, lst_F7, lstDate7, txtDate_From7, txtDate_To7, drpAmount_F7, txtAmount1_F7, txtAmount2_F7, chkNotCriteria7));
        strWhere.Append(GetSelectedFilters(drpFilter8, drpText_F8, txtFilter8, lst_F8, lstDate8, txtDate_From8, txtDate_To8, drpAmount_F8, txtAmount1_F8, txtAmount2_F8, chkNotCriteria8));
        strWhere.Append(GetSelectedFilters(drpFilter9, drpText_F9, txtFilter9, lst_F9, lstDate9, txtDate_From9, txtDate_To9, drpAmount_F9, txtAmount1_F9, txtAmount2_F9, chkNotCriteria9));
        strWhere.Append(GetSelectedFilters(drpFilter10, drpText_F10, txtFilter10, lst_F10, lstDate10, txtDate_From10, txtDate_To10, drpAmount_F10, txtAmount1_F10, txtAmount2_F10, chkNotCriteria10));

        return strWhere.ToString();
    }

    /// <summary>
    /// Search List ITem from list object
    /// </summary>
    /// <param name="decValue"></param>
    /// <param name="lstSearch"></param>
    /// <returns></returns>
    private int SearchList(decimal decValue, List<Management_AdhocReportFields> lstSearch)
    {
        int i;

        for (i = 0; i < lstSearch.Count; i++)
        {
            if (lstSearch[i].PK_Management_AdhocReportFields.Value == decValue)
                return i;
        }

        return 0;
    }

    /// <summary>
    /// Bind Coverage Check Box List
    /// </summary>
    private void BindCoverage()
    {
        ////Select Only Accasible COverage.
        //rblCoverage.DataSource = LU_Coverage.SelectByCodeIDs(strAccessibleClaimTypes);
        //rblCoverage.DataTextField = "Description";
        //rblCoverage.DataValueField = "major_coverage";
        //rblCoverage.DataBind();

    }

    /// <summary>
    /// Set Default Control value
    /// </summary>
    private void SetDefaults(string strType)
    {
        BindReportNameDropDown(strType);
        BindFilterCombo(strType);
        BindOutpuFields(strType);
        //Enable Select Button
        btnSelectFields.Enabled = true;
        btnSelectAllFields.Enabled = true;
        ddlRecipientList.ClearSelection();
    }

    /// <summary>
    /// Set Filter Control Panel Visibility
    /// </summary>
    private void ClearAllFilterPanel()
    {
        lstSelectedFields.Items.Clear();
        pnlAmount_F1.Visible = pnlAmount_F2.Visible = pnlAmount_F3.Visible = pnlAmount_F4.Visible = pnlAmount_F5.Visible = false;
        pnlAmount_F6.Visible = pnlAmount_F7.Visible = pnlAmount_F8.Visible = pnlAmount_F9.Visible = pnlAmount_F10.Visible = false;

        pnlDate_F1.Visible = pnlDate_F2.Visible = pnlDate_F3.Visible = pnlDate_F4.Visible = pnlDate_F5.Visible = false;
        pnlDate_F6.Visible = pnlDate_F7.Visible = pnlDate_F8.Visible = pnlDate_F9.Visible = pnlDate_F10.Visible = false;

        pnlText_F1.Visible = pnlText_F2.Visible = pnlText_F3.Visible = pnlText_F4.Visible = pnlText_F5.Visible = false;
        pnlText_F6.Visible = pnlText_F7.Visible = pnlText_F8.Visible = pnlText_F9.Visible = pnlText_F10.Visible = false;

        lst_F1.Visible = lst_F2.Visible = lst_F3.Visible = lst_F4.Visible = lst_F5.Visible = false;
        lst_F6.Visible = lst_F7.Visible = lst_F8.Visible = lst_F9.Visible = lst_F10.Visible = false;

        lblDateTo1.Visible = lblDateTo2.Visible = lblDateTo3.Visible = lblDateTo4.Visible = lblDateTo5.Visible = false;
        lblDateTo10.Visible = lblDateTo9.Visible = lblDateTo8.Visible = lblDateTo7.Visible = lblDateTo6.Visible = false;

        txtDate_To1.Visible = txtDateTo2.Visible = txtDate_To3.Visible = txtDate_To4.Visible = txtDate_To5.Visible = false;
        txtDate_To6.Visible = txtDate_To7.Visible = txtDate_To8.Visible = txtDate_To9.Visible = txtDate_To10.Visible = false;

        imgDate_To1.Visible = imgDate_To2.Visible = imgDate_To3.Visible = imgDate_To4.Visible = imgDate_To5.Visible = false;
        imgDate_To6.Visible = imgDate_To7.Visible = imgDate_To8.Visible = imgDate_To9.Visible = imgDate_To10.Visible = false;

        lblDateFrom1.Text = lstDate1.SelectedItem.Text + " Date:";

        imgDate_To1.Src = imgDate_To2.Src = imgDate_To3.Src = imgDate_To4.Src = imgDate_To5.Src = AppConfig.ImageURL + "/iconPicDate.gif";
        imgDate_To6.Src = imgDate_To7.Src = imgDate_To8.Src = imgDate_To9.Src = imgDate_To10.Src = AppConfig.ImageURL + "/iconPicDate.gif";
        imgDate_Opened_From1.Src = imgDate_Opened_From2.Src = imgDate_Opened_From3.Src = imgDate_Opened_From4.Src = imgDate_Opened_From5.Src = AppConfig.ImageURL + "/iconPicDate.gif";
        imgDate_Opened_From6.Src = imgDate_Opened_From7.Src = imgDate_Opened_From8.Src = imgDate_Opened_From9.Src = imgDate_Opened_From10.Src = AppConfig.ImageURL + "/iconPicDate.gif";

    }

    /// <summary>
    /// Clear Filter Control and Display it as initial mode
    /// </summary>
    private void ClearControls()
    {
        txtDate_To1.Text = txtDateTo2.Text = txtDate_To3.Text = txtDate_To4.Text = txtDate_To5.Text = string.Empty;
        txtDate_To6.Text = txtDate_To7.Text = txtDate_To8.Text = txtDate_To9.Text = txtDate_To10.Text = string.Empty;
        txtDate_From1.Text = txtDate_From2.Text = txtDate_From3.Text = txtDate_From4.Text = txtDate_From5.Text = string.Empty;
        txtDate_From6.Text = txtDate_From7.Text = txtDate_From8.Text = txtDate_From9.Text = txtDate_From10.Text = string.Empty;
        txtAmount1_F1.Text = txtAmount1_F2.Text = txtAmount1_F3.Text = txtAmount1_F4.Text = txtAmount1_F5.Text = string.Empty;
        txtAmount1_F6.Text = txtAmount1_F7.Text = txtAmount1_F8.Text = txtAmount1_F9.Text = txtAmount1_F10.Text = string.Empty;
        txtAmount2_F1.Text = txtAmount2_F2.Text = txtAmount2_F3.Text = txtAmount2_F4.Text = txtAmount2_F5.Text = string.Empty;
        txtAmount2_F6.Text = txtAmount2_F7.Text = txtAmount2_F8.Text = txtAmount2_F9.Text = txtAmount2_F10.Text = string.Empty;
        txtFilter1.Text = txtFilter2.Text = txtFilter3.Text = txtFilter4.Text = txtFilter5.Text = string.Empty;
        txtFilter6.Text = txtFilter7.Text = txtFilter8.Text = txtFilter9.Text = txtFilter10.Text = string.Empty;
        txtReportName.Text = string.Empty; chkGrandTotal.Checked = false;
        txtPriorDate.Text = txtReportName.Text = string.Empty;
        ucRelativeDates_PriorVal.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        SetRelativeDateControl(txtPriorDate, imgPriorValuationDate, false);

        ///Default Date Criteria
        lstDate1.SelectedValue = lstDate2.SelectedValue = lstDate3.SelectedValue = lstDate4.SelectedValue = lstDate5.SelectedValue = "O";
        lstDate6.SelectedValue = lstDate7.SelectedValue = lstDate8.SelectedValue = lstDate9.SelectedValue = lstDate10.SelectedValue = "O";

        rdbLstDate_SelectedIndexChanged(lstDate1, null);
        rdbLstDate_SelectedIndexChanged(lstDate2, null);
        rdbLstDate_SelectedIndexChanged(lstDate3, null);
        rdbLstDate_SelectedIndexChanged(lstDate4, null);
        rdbLstDate_SelectedIndexChanged(lstDate5, null);
        rdbLstDate_SelectedIndexChanged(lstDate6, null);
        rdbLstDate_SelectedIndexChanged(lstDate7, null);
        rdbLstDate_SelectedIndexChanged(lstDate8, null);
        rdbLstDate_SelectedIndexChanged(lstDate9, null);
        rdbLstDate_SelectedIndexChanged(lstDate10, null);
        //Amount Default
        drpAmount_F1.SelectedValue = drpAmount_F2.SelectedValue = drpAmount_F3.SelectedValue = drpAmount_F4.SelectedValue = drpAmount_F5.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
        drpAmount_F6.SelectedValue = drpAmount_F7.SelectedValue = drpAmount_F8.SelectedValue = drpAmount_F9.SelectedValue = drpAmount_F10.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
        drpAmount_F_SelectedIndexChanged(drpAmount_F1, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F2, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F3, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F4, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F5, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F6, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F7, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F8, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F9, null);
        drpAmount_F_SelectedIndexChanged(drpAmount_F10, null);

        //Clear All Filter
        drpFilter1.ClearSelection();
        drpFilter2.ClearSelection();
        drpFilter3.ClearSelection();
        drpFilter4.ClearSelection();
        drpFilter5.ClearSelection();
        drpFilter6.ClearSelection();
        drpFilter7.ClearSelection();
        drpFilter8.ClearSelection();
        drpFilter9.ClearSelection();
        drpFilter10.ClearSelection();

        //Didable button
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = imgUp.Enabled = imgDown.Enabled = false;

        //Clear Dropdown list
        rdblGroupSortByFirst.SelectedValue = rdblGroupSortBySecond.SelectedValue = rdblGroupSortByThird.SelectedValue = rdblGroupSortByFourth.SelectedValue = rdblGroupSortByFifth.SelectedValue = rdbSort1.SelectedValue = rdbSort2.SelectedValue = rdbSort3.SelectedValue = rdbSort4.SelectedValue = rdbSort5.SelectedValue = "ASC";

        // Clear Drop down list and Insert SElect Tag 
        drpSortingFirst.Items.Clear();
        drpSortingSecond.Items.Clear();
        drpSortingThird.Items.Clear();
        drpGroupByFirst.Items.Clear();
        drpGroupBySecond.Items.Clear();
        drpGroupByFirst.Items.Insert(0, new ListItem("--Select--", "0"));
        drpGroupBySecond.Items.Insert(0, new ListItem("--Select--", "-1"));
        drpSortingFirst.Items.Insert(0, new ListItem("--Select--", "0"));
        drpSortingSecond.Items.Insert(0, new ListItem("--Select--", "-1"));
        drpSortingThird.Items.Insert(0, new ListItem("--Select--", "-2"));


        drpGroupByThird.Items.Clear();
        drpGroupByFourth.Items.Clear();
        drpGroupByFifth.Items.Clear();
        drpSortingFourth.Items.Clear();
        drpSortingFifth.Items.Clear();
        drpGroupByThird.Items.Insert(0, new ListItem("--Select--", "-2"));
        drpGroupByFourth.Items.Insert(0, new ListItem("--Select--", "-3"));
        drpGroupByFifth.Items.Insert(0, new ListItem("--Select--", "-4"));
        drpSortingFourth.Items.Insert(0, new ListItem("--Select--", "-3"));
        drpSortingFifth.Items.Insert(0, new ListItem("--Select--", "-4"));
    }

    private void ClearNotCheckCriteria()
    {
        chkNotCriteria1.Visible = false;
        chkNotCriteria1.Checked = false;
        chkNotCriteria2.Visible = false;
        chkNotCriteria2.Checked = false;
        chkNotCriteria3.Visible = false;
        chkNotCriteria3.Checked = false;
        chkNotCriteria4.Visible = false;
        chkNotCriteria4.Checked = false;
        chkNotCriteria5.Visible = false;
        chkNotCriteria5.Checked = false;
        chkNotCriteria6.Visible = false;
        chkNotCriteria6.Checked = false;
        chkNotCriteria7.Visible = false;
        chkNotCriteria7.Checked = false;
        chkNotCriteria8.Visible = false;
        chkNotCriteria8.Checked = false;
        chkNotCriteria9.Visible = false;
        chkNotCriteria9.Checked = false;
        chkNotCriteria10.Visible = false;
        chkNotCriteria10.Checked = false;
    }

    /// <summary>
    /// Bind Report Name Drop Down with Coverage Type
    /// </summary>
    /// <param name="strType"></param>
    private void BindReportNameDropDown(string strType)
    {
        ddlReports.Items.Clear();
        DataTable dtReprot = ERIMS.DAL.Management_AdHocReport.SelectReportName(strType).Tables[0];
        ddlReports.DataSource = dtReprot;
        ddlReports.DataTextField = "ReportName";
        ddlReports.DataValueField = "PK_Management_AdHocReport";
        ddlReports.DataBind();
        ddlReports.Items.Insert(0, new ListItem("---Select---", "0"));
        //clsGeneral.SetDropDownToolTip(new DropDownList[] { ddlReports });
        btnDeleteReport.Enabled = ddlReports.SelectedIndex > 0;
    }

    /// <summary>
    /// Move Output Fields from One List to Another List and add/Remove From Sort and group by DropDown
    /// </summary>
    /// <param name="lstFrom"></param>
    /// <param name="lstTo"></param>
    /// <param name="OnlySelected"></param>
    /// <param name="IsSelect"></param>
    private void MoveListBoxItems(ListBox lstFrom, ListBox lstTo, bool OnlySelected, bool IsSelect, bool bSort)
    {
        List<ListItem> lstSelected = new List<ListItem>();

        foreach (ListItem liSelcted in lstFrom.Items)
        {
            // If List itme is selected then move it to Selected Output field list and add to list objects
            if ((OnlySelected && liSelcted.Selected) || (!OnlySelected))
            {
                liSelcted.Selected = false;
                lstTo.Items.Add(liSelcted);
                lstSelected.Add(liSelcted);

                //Remove From Dropdown when Output is De-Selected.
                drpGroupByFirst.Items.Remove(liSelcted);
                drpGroupBySecond.Items.Remove(liSelcted);
                drpGroupByThird.Items.Remove(liSelcted);
                drpGroupByFourth.Items.Remove(liSelcted);
                drpGroupByFifth.Items.Remove(liSelcted);

                drpSortingFirst.Items.Remove(liSelcted);
                drpSortingSecond.Items.Remove(liSelcted);
                drpSortingThird.Items.Remove(liSelcted);
                drpSortingFourth.Items.Remove(liSelcted);
                drpSortingFifth.Items.Remove(liSelcted);

                //if (liSelcted.Text == "Date of Loss")
                //{
                //    drpGroupByFirst.Items.Remove(drpGroupByFirst.Items.FindByText("Accident Year"));
                //    drpGroupBySecond.Items.Remove(drpGroupBySecond.Items.FindByText("Accident Year"));
                //    drpGroupByThird.Items.Remove(drpGroupByThird.Items.FindByText("Accident Year"));
                //    drpGroupByFourth.Items.Remove(drpGroupByFourth.Items.FindByText("Accident Year"));
                //    drpGroupByFifth.Items.Remove(drpGroupByFifth.Items.FindByText("Accident Year"));

                //}
            }
        }

        // remove all selected list items from output fields
        for (int i = 0; i < lstSelected.Count; i++)
        {
            lstFrom.Items.Remove(lstSelected[i] as ListItem);

            if (IsSelect)
            {
                drpGroupByFirst.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpGroupBySecond.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpGroupByThird.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpGroupByFourth.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpGroupByFifth.Items.Insert(i + 1, lstSelected[i] as ListItem);


                drpSortingFirst.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpSortingSecond.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpSortingThird.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpSortingFourth.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpSortingFifth.Items.Insert(i + 1, lstSelected[i] as ListItem);

                //if (lstSelected[i].Text == "Date of Loss")
                //{
                //    drpGroupByFirst.Items.Insert(i + 1, new ListItem("Accident Year", "-2"));
                //    drpGroupBySecond.Items.Insert(i + 1, new ListItem("Accident Year", "-3"));
                //    drpGroupByThird.Items.Insert(i + 1, new ListItem("Accident Year", "-4"));
                //    drpGroupByFourth.Items.Insert(i + 1, new ListItem("Accident Year", "-5"));
                //    drpGroupByFifth.Items.Insert(i + 1, new ListItem("Accident Year", "-6"));
                //}
            }
        }

        // sort output fields
        if (bSort == true && lstOutputFields.Items.Count > 0)
        {
            DataTable dtFields = new DataTable();
            dtFields.Columns.Add(new DataColumn("PK_Management_AdhocReportFields", typeof(decimal)));
            dtFields.Columns.Add(new DataColumn("Field_Header", typeof(string)));

            foreach (ListItem itmField in lstOutputFields.Items)
            {
                DataRow drField = dtFields.NewRow();
                drField["PK_Management_AdhocReportFields"] = itmField.Value;
                drField["Field_Header"] = itmField.Text;
                dtFields.Rows.Add(drField);
            }
            dtFields.DefaultView.Sort = "Field_Header ASC";
            lstOutputFields.Items.Clear();
            lstOutputFields.DataSource = dtFields.DefaultView;
            lstOutputFields.DataTextField = "Field_Header";
            lstOutputFields.DataValueField = "PK_Management_AdhocReportFields";
            lstOutputFields.DataBind();
        }


        // If Selected output list is empty then Disable Moving buttons and Up-Down images
        if (lstSelectedFields.Items.Count <= 0)
        {
            btnDeselectFields.Enabled = false;
            imgUp.Enabled = imgDown.Enabled = btnDeselectAllFields.Enabled = false;
        }
        else
        {
            btnDeselectFields.Enabled = true;
            imgUp.Enabled = imgDown.Enabled = btnDeselectAllFields.Enabled = true;
        }

        // IF output Fields is Empty
        if (lstOutputFields.Items.Count <= 0)
        {
            btnSelectFields.Enabled = false;
            btnSelectAllFields.Enabled = false;
        }
        else
        {
            btnSelectFields.Enabled = true;
            btnSelectAllFields.Enabled = true;
        }
        /*
        SortListItem(ref lstOutputFields);
        SortDDL(ref drpGroupByFirst, new DropDownList[] { drpGroupBySecond, drpSortingFirst, drpSortingSecond, drpSortingThird });
         * */
    }

    /// <summary>
    /// Set Date control Text and show-hide Date textbox as per selected criteria
    /// </summary>    
    private void SetDateControls(DropDownList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2, HtmlImage img2, RegularExpressionValidator revDateTo, Controls_RelativeDate_RelativeDate ucToDate)
    {
        //Set Validation Massage and Label Text
        string strFilterTxt = "Filter Criteria " + lbl1.ID.Replace("lblDateFrom", "") + " - ";
        lbl1.Text = rdbCommon.SelectedItem.Text + " Date:";
        revDateTo.ErrorMessage = strFilterTxt + rdbCommon.SelectedItem.Text + " Date is not valid date";

        txt1.Visible = lbl1.Visible = true;
        HtmlImage imgdateopenfrom = (HtmlImage)pnl_Container.FindControl("imgDate_Opened_From" + lbl1.ID.Replace("lblDateFrom", ""));
        imgdateopenfrom.Visible = true;
        UserControl ctrlucRelativedatefrom = (UserControl)pnl_Container.FindControl("ucRelativeDatesFrom_" + lbl1.ID.Replace("lblDateFrom", ""));
        ctrlucRelativedatefrom.Visible = true;

        if (rdbCommon.SelectedValue == "B")
        {
            img2.Visible = true;
            txt2.Visible = true;
            ucToDate.Visible = lbl2.Visible = true;
            lbl1.Text = "Start Date:";
            lbl2.Text = "End Date:";
            revDateTo.ErrorMessage = strFilterTxt + "Start Date is not valid date";
        }
        else if (rdbCommon.SelectedValue == "IN")
        {
            ucToDate.Visible = img2.Visible = txt2.Visible = lbl2.Visible = false;
            lbl2.Text = "";

            txt1.Visible = false;
            lbl1.Visible = false;
            imgdateopenfrom.Visible = false;
            ctrlucRelativedatefrom.Visible = false;
        }
        else
        {
            ucToDate.Visible = img2.Visible = txt2.Visible = lbl2.Visible = false;
            lbl2.Text = "";
        }
        // Set image to display calander Control
        img2.Attributes.Add("onclick", "return showCalendar('" + txt2.ClientID + "', 'mm/dd/y','','')");

    }

    /// <summary>
    /// Set Control when filter Change
    /// </summary>
    /// <param name="drpFilter"></param>
    /// <param name="pnlText_F"></param>
    /// <param name="pnlAmoun_F"></param>
    /// <param name="pnlDate_F"></param>
    /// <param name="lst_F"></param>
    /// <returns></returns>
    protected string drpFilterChange(DropDownList drpFilter, Panel pnlText_F, Panel pnlAmoun_F, Panel pnlDate_F, ListBox lst_F, CheckBox chkNotCriteria)
    {
        if (drpFilter.SelectedValue == "0" || drpFilter.Items.Count <= 0)
        {
            pnlText_F.Visible = false;
            pnlAmoun_F.Visible = false;
            pnlDate_F.Visible = false;
            lst_F.Visible = false;
            chkNotCriteria.Visible = false;
        }

        decimal decSelectedValue = 0;
        if (drpFilter.Items.Count > 0 && drpFilter.SelectedIndex > 0)
            decSelectedValue = Convert.ToDecimal(drpFilter.SelectedItem.Value);
        List<ERIMS.DAL.Management_AdhocReportFields> lstAdHoc = null;

        if (decSelectedValue > 0)
            lstAdHoc = new ERIMS.DAL.Management_AdhocReportFields().GetAdHocReportFieldByPk(decSelectedValue);

        if (lstAdHoc != null && lstAdHoc.Count > 0)
        {
            chkNotCriteria.Visible = true;
            chkNotCriteria.Checked = false;
            switch (lstAdHoc[0].Fk_ControlType.Value)
            {
                case (int)AdHocReportHelper.AdHocControlType.TextBox:
                    pnlText_F.Visible = true;
                    pnlAmoun_F.Visible = false;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = false;
                    SetDefaultTExtBox(pnlText_F.ID);
                    break;
                case (int)AdHocReportHelper.AdHocControlType.MultiSelectList:

                    if (lstAdHoc[0].Field_Header == "DBA")
                    {
                        //ComboHelper.FillLocation(new ListBox[] { lst_F }, false);
                        ComboHelper.FillLocationDBA_All(new ListBox[] { lst_F }, 0, false);
                    }
                    else if (lstAdHoc[0].Field_Header == "Work to Be Completed")
                    {
                        ComboHelper.FillWork_Completed(new ListBox[] { lst_F }, 0, false);
                    }
                    else if (lstAdHoc[0].Field_Header == "Work to Be Completed By")
                    {
                        ComboHelper.FillWork_Completed_By(new ListBox[] { lst_F },0, false);
                    }
                    else if (lstAdHoc[0].Field_Header == "Task Complete")
                    {
                        ComboHelper.FillTaskComplete(new ListBox[] { lst_F }, false);
                    }
                    else if (lstAdHoc[0].Field_Header == "Record Type")
                    {
                        ComboHelper.FillRecord_Type(new ListBox[] { lst_F }, 0, false);
                    }
                    else if (lstAdHoc[0].Field_Header == "Project Phase")
                    {
                        ComboHelper.FillEPM_Project_Phase(new ListBox[] { lst_F }, 0, false);
                    }
                    else if (lstAdHoc[0].Field_Header == "GM Decision" || lstAdHoc[0].Field_Header == "RLCM Decision" || lstAdHoc[0].Field_Header == "NAPM Decision" || lstAdHoc[0].Field_Header == "DRM Decision")
                    {
                        ComboHelper.FillManagementByDecision(new ListBox[] { lst_F }, false);
                    }
                    else if (lstAdHoc[0].Field_Header == "Vendor State")
                    {
                        ComboHelper.FillStateList(new ListBox[] { lst_F }, false);
                    }
                    else if (lstAdHoc[0].Field_Header.ToUpper() == "APPROVAL SUBMISSION")
                    {
                        ComboHelper.FillApproval_Submission(new ListBox[] { lst_F }, false);
                        #region " To check Null value #Issue 3420 "
                        List<ListItem> liItem = new List<ListItem>();
                        liItem.Add(new ListItem("None", "0"));
                        for (int i = 0; i < liItem.Count; i++)
                        {
                            lst_F.Items.Add((ListItem)liItem[i]);
                        } 
                        #endregion
                    }
                    else if (lstAdHoc[0].Field_Header.ToUpper() == "RPM APPROVAL" || lstAdHoc[0].Field_Header.ToUpper() == "NO APPROVAL NEEDED" || lstAdHoc[0].Field_Header.ToUpper() == "APPROVAL NEEDED")
                    {
                        ComboHelper.FillTaskComplete(new ListBox[] { lst_F }, false);
                    }
                    else if (lstAdHoc[0].Field_Header.ToUpper() == "STATUS")
                    {
                        ComboHelper.FillMaintenanceStatusList(new ListBox[] { lst_F }, false);
                    }
                    else
                    {
                        AdHocReportHelper.FillFilterDropDown(lstAdHoc[0].Field_Header, new ListBox[] { lst_F }, false, GetSelectedCoverage());
                    }
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = false;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = true;
                    //Set ListBox ToolTip
                    clsGeneral.SetListBoxToolTip(new ListBox[] { lst_F });
                    break;
                case (int)AdHocReportHelper.AdHocControlType.DateControl:
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = false;
                    pnlDate_F.Visible = true;
                    lst_F.Visible = false;
                    SetDefaultDate(pnlDate_F.ID);
                    break;
                case (int)AdHocReportHelper.AdHocControlType.AmountControl:
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = true;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = false;
                    SetDefaultAmount(pnlAmoun_F.ID);
                    break;
                default:
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = false;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = false;
                    break;
            }
        }
        return string.Empty;
    }

    /// <summary>
    /// Amout Dropdown Changed.
    /// </summary>
    /// <param name="drpAmount_F"></param>
    /// <param name="lblAmountText1_F"></param>
    /// <param name="txtAmount1_F"></param>
    /// <param name="lblAmountText2_F"></param>
    /// <param name="txtAmount2_F"></param>
    protected void drpAmount_Changed(bool isDollarSign, DropDownList drpAmount_F, Label lblAmountText1_F, TextBox txtAmount1_F, Label lblAmountText2_F, TextBox txtAmount2_F, CompareValidator cvAmount)
    {
        string strAmountValue = drpAmount_F.SelectedValue;

        switch (strAmountValue)
        {
            case "0":
                lblAmountText1_F.Text = "$ ";
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = false;
                txtAmount2_F.Visible = false;
                break;
            case "1":
                lblAmountText1_F.Text = "$ ";
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = false;
                txtAmount2_F.Visible = false;
                break;
            case "2":
                lblAmountText1_F.Text = "From $ ";
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = true;
                lblAmountText2_F.Text = "To $ ";
                txtAmount2_F.Visible = true;
                break;
            case "3":
                lblAmountText1_F.Text = "$ ";
                lblAmountText1_F.Visible = true;
                txtAmount1_F.Visible = true;
                lblAmountText2_F.Visible = false;
                txtAmount2_F.Visible = false;
                break;
        }
        /*
         * It will set TextBox and Lable of associate Textbox,when filed is numeric but it is not Amount filed
         * */
        //First Remove Attribute
        txtAmount1_F.Attributes.Remove("onkeypress");
        txtAmount2_F.Attributes.Remove("onkeypress");
        txtAmount1_F.Attributes.Remove("onblur");
        txtAmount2_F.Attributes.Remove("onblur");
        if (!isDollarSign)
        {
            lblAmountText1_F.Text = lblAmountText1_F.Text.Replace("$", "");
            lblAmountText2_F.Text = lblAmountText2_F.Text.Replace("$", "");
            txtAmount1_F.Attributes.Add("onkeypress", "return FormatInteger(event,this.id);");
            txtAmount2_F.Attributes.Add("onkeypress", "return FormatInteger(event,this.id);");
            txtAmount2_F.MaxLength = txtAmount1_F.MaxLength = 3;
            cvAmount.ErrorMessage = cvAmount.ErrorMessage.Replace("Amount", "Value");
        }
        else
        {
            txtAmount1_F.Attributes.Add("onkeypress", "return FormatNumber(event,this.id,12,false,false);");
            txtAmount2_F.Attributes.Add("onkeypress", "return FormatNumber(event,this.id,12,false,false);");
            txtAmount1_F.Attributes.Add("onblur", "return formatCurrencyOnBlur(this,12);");
            txtAmount2_F.Attributes.Add("onblur", "return formatCurrencyOnBlur(this,12);");
            txtAmount1_F.MaxLength = txtAmount2_F.MaxLength = 17;
            cvAmount.ErrorMessage = cvAmount.ErrorMessage.Replace("Value", "Amount");
        }
    }

    /// <summary>
    /// return Comma saperated list of all selected item in listbox
    /// </summary>
    /// <param name="lstBox"></param>
    /// <returns></returns>
    public string GetSelectedItemString(ListBox lstBox, bool isStringValue)
    {
        string strValues = "";
        foreach (ListItem lstBoxItem in lstBox.Items)
        {
            if (lstBoxItem.Selected)
            {
                if (isStringValue)
                    strValues = strValues + "'" + lstBoxItem.Value.Replace("'", "''") + "',";
                else
                    strValues = strValues + lstBoxItem.Value.Replace("'", "''") + ",";
            }

        }
        return strValues.TrimEnd(',');
    }

    /// <summary>
    /// return Comma saperated list of all selected item in listbox
    /// </summary>
    /// <param name="lstBox"></param>
    /// <returns></returns>
    public string GetAllItemString(ListBox lstBox, bool isStringValue)
    {
        string strValues = "";
        foreach (ListItem lstBoxItem in lstBox.Items)
        {
            if (isStringValue)
                strValues = strValues + "'" + lstBoxItem.Value.Replace("'", "''") + "',";
            else
                strValues = strValues + lstBoxItem.Value.Replace("'", "''") + ",";

        }
        return strValues.TrimEnd(',');
    }

    /// <summary>
    /// Get Where condition when Type is Listbox
    /// </summary>
    /// <param name="lstWhereFiels"></param>
    /// <param name="strCondition"></param>
    /// <returns></returns>
    public string GetListBoxWhereCondition(string lstWhereFiels, string strCondition, bool IsNotSelected)
    {
        string strNewList = string.Empty;
        string strWhere = string.Empty;
        string[] arrwhere = strCondition.Split(',');
        //When Match with Char like [filed_name] in ('O,C')
        if (!string.IsNullOrEmpty(lstWhereFiels) && (lstWhereFiels == "[Policy].Policy_Type" || lstWhereFiels == "[CM].Routine_Job" || lstWhereFiels == "[CM].Wearing_PPE" ||
            lstWhereFiels == "[CM].Paid" || lstWhereFiels == "[CM].Agree" || lstWhereFiels == "[CM].Medical_Attention"
            || lstWhereFiels == "[CM].Approved" || lstWhereFiels == "[CM].First_Aid") && !string.IsNullOrEmpty(strCondition))
        {
            strWhere = " And ";
            for (int intI = 0; intI < arrwhere.Length; intI++)
            {
                strNewList += "'" + arrwhere[intI] + "',";
            }
            if (IsNotSelected == true)
                strWhere = " And " + lstWhereFiels + " NOT IN (" + strNewList.TrimEnd(',') + ") ";
            else
                strWhere = " And " + lstWhereFiels + " IN (" + strNewList.TrimEnd(',') + ") ";
        }
        else if (!string.IsNullOrEmpty(lstWhereFiels) && !string.IsNullOrEmpty(strCondition))
        {
            if (IsNotSelected == true)
            {
                if (lstWhereFiels == "[C].Fk_LU_Police_Report_Audit")
                    strWhere = " And (" + lstWhereFiels + " NOT IN (" + strCondition + ") OR " + lstWhereFiels + " Is Null)";
                else if (lstWhereFiels == "[LAS].PK_LU_Approval_Submission" && strCondition == "0")
                    strWhere = " And " + lstWhereFiels + " IS NOT NULL ";
                else if (lstWhereFiels == "[LAS].PK_LU_Approval_Submission" && strCondition.Contains("0"))
                    strWhere = " And (" + lstWhereFiels + " IS NOT NULL " + " AND " + lstWhereFiels + " NOT IN (" + strCondition + ") )";
                else if (lstWhereFiels == "[LAS].PK_LU_Approval_Submission" && !strCondition.Contains("0"))
                    strWhere = " And (" + lstWhereFiels + " IS NULL " + " OR " + lstWhereFiels + " NOT IN (" + strCondition + ") )";
                else
                    strWhere = " And " + lstWhereFiels + " NOT IN (" + strCondition + ") ";
            }
            else if (lstWhereFiels == "[LAS].PK_LU_Approval_Submission" && strCondition == "0")
                strWhere = " And " + lstWhereFiels + " IS NULL ";
            else if (lstWhereFiels == "[LAS].PK_LU_Approval_Submission" && strCondition.Contains("0"))
                strWhere = " And ( " + lstWhereFiels + " IS NULL " + " OR " + lstWhereFiels + " IN (" + strCondition + ")) ";
            else
                strWhere = " And " + lstWhereFiels + " IN (" + strCondition + ") ";
        }

        return strWhere;
    }

    /// <summary>
    ///  Get Where condition when Type is TextBox
    /// </summary>
    /// <param name="strFieldName"></param>
    /// <param name="strText"></param>
    /// <param name="drpIndex"></param>
    /// <returns></returns>
    public string GetTextWhereCondition(string strFieldName, string strText, int drpIndex, bool IsNotSelected)
    {
        string strWhere = string.Empty;
        string strFilter = string.Empty;

        if (!string.IsNullOrEmpty(strText))
        {
            if (strFieldName.Contains("Comments_Description"))
                strWhere = " And (CONVERT(VARCHAR," + strFieldName + " ,108))";
            else strWhere = " And " + strFieldName;
            if (IsNotSelected == true)
            {
                if (drpIndex == 1)
                    strWhere += " NOT LIKE  '%" + strText.Trim().Replace("'", "''") + "%' ";
                else if (drpIndex == 2)
                    strWhere += " NOT LIKE '" + strText.Trim().Replace("'", "''") + "%'";
                else if (drpIndex == 3)
                    strWhere += " NOT LIKE '%" + strText.Trim().Replace("'", "''") + "'";
            }
            else
            {
                if (drpIndex == 1)
                    strWhere += " LIKE  '%" + strText.Trim().Replace("'", "''") + "%' ";
                else if (drpIndex == 2)
                    strWhere += " LIKE '" + strText.Trim().Replace("'", "''") + "%'";
                else if (drpIndex == 3)
                    strWhere += " LIKE '%" + strText.Trim().Replace("'", "''") + "'";
            }
        }
        return strWhere;
    }

    /// <summary>
    ///  Get Where condition when Type is DateTime
    /// </summary>
    /// <param name="strFieldName"></param>
    /// <param name="strDatefrom"></param>
    /// <param name="strDateTo"></param>
    /// <param name="cblDateCriteria"></param>
    /// <returns></returns>
    public string GetDateWhereCondtion(string strFieldName, string strDatefrom, string strDateTo, string cblDateCriteria, bool IsNotSelected)
    {
        string strWhere = string.Empty;

        DateTime? dtFrom = null, dtTo = null;


        dtFrom = clsGeneral.FormatNullDateToStore(strDatefrom);

        dtTo = clsGeneral.FormatNullDateToStore(strDateTo);

        AdHocReportHelper.DateCriteria DtType = AdHocReportHelper.DateCriteria.On;

        if (cblDateCriteria == "O")
            DtType = AdHocReportHelper.DateCriteria.On;
        else if (cblDateCriteria == "BF")
            DtType = AdHocReportHelper.DateCriteria.Before;
        else if (cblDateCriteria == "A")
            DtType = AdHocReportHelper.DateCriteria.After;
        else if (cblDateCriteria == "B")
            DtType = AdHocReportHelper.DateCriteria.Between;
        else if (cblDateCriteria == "IN")
        {
            DtType = AdHocReportHelper.DateCriteria.Is_Null;
            dtFrom = null;
            dtTo = null;
            
            if(IsNotSelected)
                strWhere = " AND " + strFieldName + " IS NOT NULL";
            else
                strWhere = " AND " + strFieldName + " IS NULL";
        }

        if (dtFrom.HasValue)
            strWhere = AdHocReportHelper.GetDateWhereAbsolute(strFieldName, dtFrom, dtTo, DtType, IsNotSelected);

        else if (dtTo.HasValue)
            strWhere = AdHocReportHelper.GetDateWhereAbsolute(strFieldName, dtFrom, dtTo, DtType, IsNotSelected);

        return strWhere;
    }

    /// <summary>
    ///  Get Where condition when Type is Amount
    /// </summary>
    /// <param name="strField_Header"></param>
    /// <param name="strAmtfrom"></param>
    /// <param name="strAmtTo"></param>
    /// <param name="drpAmtCriteria"></param>
    /// <returns></returns>
    public string GetDateAmountCondtion(string strField_Header, string strAmtfrom, string strAmtTo, string drpAmtCriteria, bool IsNotSelected)
    {
        string strWhere = string.Empty;
        AdHocReportHelper.AmountCriteria AmtType = AdHocReportHelper.AmountCriteria.Equal;

        decimal? dFrom = null;
        decimal? dTo = null;

        if (!string.IsNullOrEmpty(strAmtfrom))
            dFrom = Convert.ToDecimal(strAmtfrom);

        if (!string.IsNullOrEmpty(strAmtTo))
            dTo = Convert.ToDecimal(strAmtTo);

        if (Convert.ToInt16(drpAmtCriteria) == (int)AdHocReportHelper.AmountCriteria.Equal)
            AmtType = AdHocReportHelper.AmountCriteria.Equal;
        else if (Convert.ToInt16(drpAmtCriteria) == (int)AdHocReportHelper.AmountCriteria.GreaterThan)
            AmtType = AdHocReportHelper.AmountCriteria.GreaterThan;
        else if (Convert.ToInt16(drpAmtCriteria) == (int)AdHocReportHelper.AmountCriteria.Between)
            AmtType = AdHocReportHelper.AmountCriteria.Between;
        else if (Convert.ToInt16(drpAmtCriteria) == (int)AdHocReportHelper.AmountCriteria.LessThan)
            AmtType = AdHocReportHelper.AmountCriteria.LessThan;

        if (dFrom.HasValue)
            strWhere = AdHocReportHelper.GetAmountWhere(strField_Header.Trim(), dFrom, dTo, AmtType, IsNotSelected);
        else if (dTo.HasValue)
            strWhere = AdHocReportHelper.GetAmountWhere(strField_Header.Trim(), dFrom, dTo, AmtType, IsNotSelected);

        return strWhere;
    }



    /// <summary>
    /// Bind Fileter Combo By COverage
    /// </summary>
    /// <param name="strTypes"></param>
    private void BindFilterCombo(string strTypes)
    {
        for (int intI = 1; intI <= 10; intI++)
        {
            DropDownList drpFilter = (DropDownList)pnl_Container.FindControl("drpFilter" + intI.ToString());
            if (drpFilter != null)
            {
                drpFilter.Items.Clear();
                drpFilter.DataSource = ERIMS.DAL.Management_AdhocReportFields.GetAdHocFilterFields(strTypes, "F");
                drpFilter.DataTextField = "Field_Header";
                drpFilter.DataValueField = "PK_Management_AdhocReportFields";
                drpFilter.DataBind();
                drpFilter.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        ClearAllFilterPanel();
    }

    /// <summary>
    /// Get Filter IDs from DropdownList.
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <returns></returns>
    public string GetFilterIDs(DropDownList[] dropDowns)
    {
        string strIDs = string.Empty;
        foreach (DropDownList ddlToFill in dropDowns)
        {
            if (ddlToFill.SelectedIndex > 0)
                strIDs = strIDs += ddlToFill.SelectedItem.Value.Replace("'", "''") + ",";
        }
        return strIDs.TrimEnd(',');
    }

    /// <summary>
    /// Set Relative Date TexBox Control
    /// </summary>
    private void SetRelativeDateControl(TextBox txtDate, HtmlImage Img1, bool isEnable)
    {
        txtDate.Enabled = (!isEnable);
        Img1.Disabled = (isEnable);
    }

    /// <summary>
    /// Set All Relative Date 
    /// </summary>
    private void SetRelativeDateControl()
    {
        AdHocReportHelper.RaltiveDates NotSet = AdHocReportHelper.RaltiveDates.NotSet;
        txtDate_From1.Enabled = (ucRelativeDatesFrom_1.RelativeDate == NotSet);
        imgDate_Opened_From1.Disabled = ucRelativeDatesFrom_1.RelativeDate != NotSet;
        txtDate_To1.Enabled = (ucRelativeDatesTo_1.RelativeDate == NotSet);
        imgDate_To1.Disabled = ucRelativeDatesTo_1.RelativeDate != NotSet;
        txtDate_From2.Enabled = (ucRelativeDatesFrom_2.RelativeDate == NotSet);
        imgDate_Opened_From2.Disabled = ucRelativeDatesFrom_2.RelativeDate != NotSet;
        txtDateTo2.Enabled = (ucRelativeDatesTo_2.RelativeDate == NotSet);
        imgDate_To2.Disabled = ucRelativeDatesTo_2.RelativeDate != NotSet;
        txtDate_From3.Enabled = (ucRelativeDatesFrom_3.RelativeDate == NotSet);
        imgDate_Opened_From3.Disabled = ucRelativeDatesFrom_3.RelativeDate != NotSet;
        txtDate_To3.Enabled = (ucRelativeDatesTo_3.RelativeDate == NotSet);
        imgDate_To3.Disabled = ucRelativeDatesTo_3.RelativeDate != NotSet;
        txtDate_From4.Enabled = (ucRelativeDatesFrom_4.RelativeDate == NotSet);
        imgDate_Opened_From4.Disabled = ucRelativeDatesFrom_4.RelativeDate != NotSet;
        txtDate_To4.Enabled = (ucRelativeDatesTo_4.RelativeDate == NotSet);
        imgDate_To4.Disabled = ucRelativeDatesTo_4.RelativeDate != NotSet;
        txtDate_From5.Enabled = (ucRelativeDatesFrom_5.RelativeDate == NotSet);
        imgDate_Opened_From5.Disabled = ucRelativeDatesFrom_5.RelativeDate != NotSet;
        txtDate_To5.Enabled = (ucRelativeDatesTo_5.RelativeDate == NotSet);
        imgDate_To5.Disabled = ucRelativeDatesTo_5.RelativeDate != NotSet;
        txtDate_From6.Enabled = (ucRelativeDatesFrom_6.RelativeDate == NotSet);
        imgDate_Opened_From6.Disabled = ucRelativeDatesFrom_6.RelativeDate != NotSet;
        txtDate_To6.Enabled = (ucRelativeDatesTo_6.RelativeDate == NotSet);
        imgDate_To6.Disabled = ucRelativeDatesTo_6.RelativeDate != NotSet;
        txtDate_From7.Enabled = (ucRelativeDatesFrom_7.RelativeDate == NotSet);
        imgDate_Opened_From7.Disabled = ucRelativeDatesFrom_7.RelativeDate != NotSet;
        txtDate_To7.Enabled = (ucRelativeDatesTo_7.RelativeDate == NotSet);
        imgDate_To7.Disabled = ucRelativeDatesTo_7.RelativeDate != NotSet;
        txtDate_From8.Enabled = (ucRelativeDatesFrom_8.RelativeDate == NotSet);
        imgDate_Opened_From8.Disabled = ucRelativeDatesFrom_8.RelativeDate != NotSet;
        txtDate_To8.Enabled = (ucRelativeDatesTo_8.RelativeDate == NotSet);
        imgDate_To8.Disabled = ucRelativeDatesTo_8.RelativeDate != NotSet;
        txtDate_From9.Enabled = (ucRelativeDatesFrom_9.RelativeDate == NotSet);
        imgDate_Opened_From9.Disabled = ucRelativeDatesFrom_9.RelativeDate != NotSet;
        txtDate_To9.Enabled = (ucRelativeDatesTo_9.RelativeDate == NotSet);
        imgDate_To9.Disabled = ucRelativeDatesTo_9.RelativeDate != NotSet;
        txtDate_From10.Enabled = (ucRelativeDatesFrom_10.RelativeDate == NotSet);
        imgDate_Opened_From10.Disabled = ucRelativeDatesFrom_10.RelativeDate != NotSet;
        txtDate_To10.Enabled = (ucRelativeDatesTo_10.RelativeDate == NotSet);
        imgDate_To10.Disabled = ucRelativeDatesTo_10.RelativeDate != NotSet;

    }
    /// <summary>
    /// Set Attribute to Date Image.
    /// </summary>
    /// <param name="pnlDate_FID">Panel ID</param>
    private void SetDefaultDate(string pnlDate_FID)
    {
        //Set Default Date selected Criteria,Relative date,
        if (pnlDate_FID == "pnlDate_F1")
        {
            imgDate_Opened_From1.Attributes.Add("onclick", "return showCalendar('" + txtDate_From1.ClientID + "', 'mm/dd/y','','')");
            txtDate_To1.Text = txtDate_From1.Text = string.Empty;
            lstDate1.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate1, null);
            ucRelativeDatesFrom_1.RelativeDate = ucRelativeDatesTo_1.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F2")
        {
            imgDate_Opened_From2.Attributes.Add("onclick", "return showCalendar('" + txtDate_From2.ClientID + "', 'mm/dd/y','','')");
            txtDateTo2.Text = txtDate_From2.Text = string.Empty;
            lstDate2.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate2, null);
            ucRelativeDatesFrom_2.RelativeDate = ucRelativeDatesTo_2.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F3")
        {
            imgDate_Opened_From3.Attributes.Add("onclick", "return showCalendar('" + txtDate_From3.ClientID + "', 'mm/dd/y','','')");
            txtDate_To3.Text = txtDate_From3.Text = string.Empty;
            lstDate3.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate3, null);
            ucRelativeDatesFrom_3.RelativeDate = ucRelativeDatesTo_3.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F4")
        {
            imgDate_Opened_From4.Attributes.Add("onclick", "return showCalendar('" + txtDate_From4.ClientID + "', 'mm/dd/y','','')");
            txtDate_To4.Text = txtDate_From4.Text = string.Empty;
            lstDate4.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate4, null);
            ucRelativeDatesFrom_4.RelativeDate = ucRelativeDatesTo_4.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F5")
        {
            imgDate_Opened_From5.Attributes.Add("onclick", "return showCalendar('" + txtDate_From5.ClientID + "', 'mm/dd/y','','')");
            txtDate_To5.Text = txtDate_From5.Text = string.Empty;
            lstDate5.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate5, null);
            ucRelativeDatesFrom_5.RelativeDate = ucRelativeDatesTo_5.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F6")
        {
            imgDate_Opened_From6.Attributes.Add("onclick", "return showCalendar('" + txtDate_From6.ClientID + "', 'mm/dd/y','','')");
            txtDate_To6.Text = txtDate_From6.Text = string.Empty;
            lstDate6.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate6, null);
            ucRelativeDatesFrom_6.RelativeDate = ucRelativeDatesTo_6.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F7")
        {
            imgDate_Opened_From7.Attributes.Add("onclick", "return showCalendar('" + txtDate_From7.ClientID + "', 'mm/dd/y','','')");
            txtDate_To7.Text = txtDate_From7.Text = string.Empty;
            lstDate7.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate7, null);
            ucRelativeDatesFrom_7.RelativeDate = ucRelativeDatesTo_7.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F8")
        {
            imgDate_Opened_From8.Attributes.Add("onclick", "return showCalendar('" + txtDate_From8.ClientID + "', 'mm/dd/y','','')");
            txtDate_To8.Text = txtDate_From8.Text = string.Empty;
            lstDate8.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate8, null);
            ucRelativeDatesFrom_8.RelativeDate = ucRelativeDatesTo_8.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F9")
        {
            imgDate_Opened_From9.Attributes.Add("onclick", "return showCalendar('" + txtDate_From9.ClientID + "', 'mm/dd/y','','')");
            txtDate_To9.Text = txtDate_From9.Text = string.Empty;
            lstDate9.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate9, null);
            ucRelativeDatesFrom_9.RelativeDate = ucRelativeDatesTo_9.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        else if (pnlDate_FID == "pnlDate_F10")
        {
            imgDate_Opened_From10.Attributes.Add("onclick", "return showCalendar('" + txtDate_From10.ClientID + "', 'mm/dd/y','','')");
            txtDate_To10.Text = txtDate_From10.Text = string.Empty;
            lstDate10.SelectedValue = "O";
            rdbLstDate_SelectedIndexChanged(lstDate10, null);
            ucRelativeDatesFrom_10.RelativeDate = ucRelativeDatesTo_10.RelativeDate = AdHocReportHelper.RaltiveDates.NotSet;
        }
        SetRelativeDateControl();
    }

    /// <summary>
    /// Set Default Amount
    /// </summary>
    /// <param name="pnmAmount"></param>
    private void SetDefaultAmount(string pnlAmount_F_ID)
    {
        // Set Default Amount,Filter Option and Value
        if (pnlAmount_F_ID == "pnlAmount_F1")
        {
            txtAmount1_F1.Text = txtAmount2_F1.Text = string.Empty;
            drpAmount_F1.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F1, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F2")
        {
            txtAmount1_F2.Text = txtAmount2_F2.Text = string.Empty;
            drpAmount_F2.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F2, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F3")
        {
            txtAmount1_F3.Text = txtAmount2_F3.Text = string.Empty;
            drpAmount_F3.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F3, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F4")
        {
            txtAmount1_F4.Text = txtAmount2_F4.Text = string.Empty;
            drpAmount_F4.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F4, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F5")
        {
            txtAmount1_F5.Text = txtAmount2_F5.Text = string.Empty;
            drpAmount_F5.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F5, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F6")
        {
            txtAmount1_F6.Text = txtAmount2_F6.Text = string.Empty;
            drpAmount_F6.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F6, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F7")
        {
            txtAmount1_F7.Text = txtAmount2_F7.Text = string.Empty;
            drpAmount_F7.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F7, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F8")
        {
            txtAmount1_F7.Text = txtAmount2_F7.Text = string.Empty;
            drpAmount_F7.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F7, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F9")
        {
            txtAmount1_F9.Text = txtAmount2_F9.Text = string.Empty;
            drpAmount_F9.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F9, null);

        }
        else if (pnlAmount_F_ID == "pnlAmount_F10")
        {
            txtAmount1_F10.Text = txtAmount2_F10.Text = string.Empty;
            drpAmount_F10.SelectedValue = Convert.ToString((int)AdHocReportHelper.AmountCriteria.Equal);
            drpAmount_F_SelectedIndexChanged(drpAmount_F10, null);

        }
    }

    /// <summary>
    /// Set Default TextBox
    /// </summary>
    /// <param name="pnlText_F"></param>
    private void SetDefaultTExtBox(string pnlText_F)
    {
        //Set Default Textbox value,Filter option
        if (pnlText_F == "pnlText_F1")
        {
            txtFilter1.Text = string.Empty;
            drpText_F1.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F2")
        {
            txtFilter2.Text = string.Empty;
            drpText_F2.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F3")
        {
            txtFilter3.Text = string.Empty;
            drpText_F3.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F4")
        {
            txtFilter4.Text = string.Empty;
            drpText_F4.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F5")
        {
            txtFilter5.Text = string.Empty;
            drpText_F5.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F6")
        {
            txtFilter6.Text = string.Empty;
            drpText_F7.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F7")
        {
            txtFilter7.Text = string.Empty;
            drpText_F7.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F8")
        {
            txtFilter8.Text = string.Empty;
            drpText_F8.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F9")
        {
            txtFilter9.Text = string.Empty;
            drpText_F9.SelectedValue = "1";
        }
        else if (pnlText_F == "pnlText_F10")
        {
            txtFilter10.Text = string.Empty;
            drpText_F10.SelectedValue = "1";
        }
    }

    /// <summary>
    /// Bind Output Fields Dropdown
    /// </summary>
    /// <param name="strType"></param>
    private void BindOutpuFields(string strType)
    {
        lstOutputFields.Items.Clear();
        DataSet dsData = ERIMS.DAL.Management_AdhocReportFields.GetAdHocFields(strType, "O");
        dsData.Tables[0].DefaultView.Sort = "Field_Header asc";

        //lstOutputFields.DataSource = ERIMS.DAL.ACI_AdhocReportFields.GetAdHocFields(strType, "O");
        lstOutputFields.DataSource = dsData.Tables[0].DefaultView;
        lstOutputFields.DataTextField = "Field_Header";
        lstOutputFields.DataValueField = "PK_Management_AdhocReportFields";
        lstOutputFields.DataBind();
        //Didable button
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = imgUp.Enabled = imgDown.Enabled = false;
    }

    /// <summary>
    /// Bind Report Data.
    /// </summary>
    /// <param name="dsReport">Report Dataset</param>
    private string BindReport_old(ref StringBuilder sbRecord, ReportOutputType ReportType)
    {
        IDataReader Reader = null;
        List<ERIMS.DAL.Management_AdhocReportFields> lstAdhoc = null;
        DataTable dtSchema = null, dtHeader = null;

        try
        {
            decimal decValue;
            int iSelected;
            string strWhere = string.Empty, strFilterIds = string.Empty, strGroupBy = string.Empty, strOrderBy = string.Empty, strCriteria = string.Empty, strPath = string.Empty;
            DateTime? PVD = null;

            #region "Group By and Filter By"

            if (drpGroupByFirst.SelectedIndex > 0)
                strGroupBy = "[" + drpGroupByFirst.SelectedItem.Text + "]" + rdblGroupSortByFirst.SelectedItem.Value;

            if (drpGroupBySecond.SelectedIndex > 0)
                strGroupBy += (string.IsNullOrEmpty(strGroupBy) ? "" : ",") + " [" + drpGroupBySecond.SelectedItem.Text + "]" + rdblGroupSortBySecond.SelectedItem.Value;

            if (drpGroupByThird.SelectedIndex > 0)
                strGroupBy += (string.IsNullOrEmpty(strGroupBy) ? "" : ",") + "[" + drpGroupByThird.SelectedItem.Text + "]" + rdblGroupSortByThird.SelectedItem.Value;

            if (drpGroupByFourth.SelectedIndex > 0)
                strGroupBy += (string.IsNullOrEmpty(strGroupBy) ? "" : ",") + "[" + drpGroupByFourth.SelectedItem.Text + "]" + rdblGroupSortByFourth.SelectedItem.Value;

            if (drpGroupByFifth.SelectedIndex > 0)
                strGroupBy += (string.IsNullOrEmpty(strGroupBy) ? "" : ",") + "[" + drpGroupByFifth.SelectedItem.Text + "]" + rdblGroupSortByFifth.SelectedItem.Value;

            if (drpSortingFirst.SelectedIndex > 0)
                strOrderBy = "[" + drpSortingFirst.SelectedItem.Text + "] " + rdbSort1.SelectedItem.Value;

            if (drpSortingSecond.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingSecond.SelectedItem.Text + "] " + rdbSort2.SelectedItem.Value;

            if (drpSortingThird.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingThird.SelectedItem.Text + "] " + rdbSort3.SelectedItem.Value;

            if (drpSortingFourth.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingFourth.SelectedItem.Text + "] " + rdbSort4.SelectedItem.Value;

            if (drpSortingFifth.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingFifth.SelectedItem.Text + "] " + rdbSort5.SelectedItem.Value;

            #endregion

            strCriteria = GetFilterIDs(new DropDownList[] { drpFilter1, drpFilter2, drpFilter3, drpFilter4, drpFilter5, drpFilter6, drpFilter7, drpFilter8, drpFilter9, drpFilter10, });

            if (!string.IsNullOrEmpty(strCriteria))
                lstAdhoc = new ERIMS.DAL.Management_AdhocReportFields().GetAdHocReportFieldByMultipleID(strCriteria);

            #region "Get Where condtion"
            //Prior Valuation Date.            
            if (!string.IsNullOrEmpty(txtPriorDate.Text))
                PVD = clsGeneral.FormatNullDateToStore(txtPriorDate.Text);
            //    strPVD = GetDateWhereCondtion("Issue_Date", txtPriorDate.Text, string.Empty, "BF");

            //Get Coverage By Assigned USer Right
            strWhere = strWhere + GetCoverage();
            #region Filter Criteria
            //If iflter 1 is selected.
            if (drpFilter1.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter1.SelectedItem.Value);
                strFilterIds += decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter1.Text, Convert.ToInt16(drpText_F1.SelectedItem.Value), chkNotCriteria1.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F1, false), chkNotCriteria1.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From1.Text, txtDate_To1.Text, lstDate1.SelectedItem.Value, chkNotCriteria1.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    // It takes Filed Header when Table is Transaction otherwist it take Filed Name.
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F1.Text, txtAmount2_F1.Text, drpAmount_F1.SelectedItem.Value, chkNotCriteria1.Checked);
                    else
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F1.Text, txtAmount2_F1.Text, drpAmount_F1.SelectedItem.Value, chkNotCriteria1.Checked);
                }

            }
            if (drpFilter2.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter2.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter2.Text, Convert.ToInt16(drpText_F2.SelectedItem.Value), chkNotCriteria2.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F2, false), chkNotCriteria2.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From2.Text, txtDateTo2.Text, lstDate2.SelectedItem.Value, chkNotCriteria2.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F2.Text, txtAmount2_F2.Text, drpAmount_F2.SelectedItem.Value, chkNotCriteria2.Checked);
                    else
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F2.Text, txtAmount2_F2.Text, drpAmount_F2.SelectedItem.Value, chkNotCriteria2.Checked);
                }

            }
            if (drpFilter3.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter3.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter3.Text, Convert.ToInt16(drpText_F3.SelectedItem.Value), chkNotCriteria3.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F3, false), chkNotCriteria3.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From3.Text, txtDate_To3.Text, lstDate3.SelectedItem.Value, chkNotCriteria3.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F3.Text, txtAmount2_F3.Text, drpAmount_F3.SelectedItem.Value, chkNotCriteria3.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F3.Text, txtAmount2_F3.Text, drpAmount_F3.SelectedItem.Value, chkNotCriteria3.Checked);
                }

            }
            if (drpFilter4.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter4.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter4.Text, Convert.ToInt16(drpText_F4.SelectedItem.Value), chkNotCriteria4.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F4, false), chkNotCriteria4.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From4.Text, txtDate_To4.Text, lstDate4.SelectedItem.Value, chkNotCriteria4.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F4.Text, txtAmount2_F4.Text, drpAmount_F4.SelectedItem.Value, chkNotCriteria4.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F4.Text, txtAmount2_F4.Text, drpAmount_F4.SelectedItem.Value, chkNotCriteria4.Checked);
                }
            }
            if (drpFilter5.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter5.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter5.Text, Convert.ToInt16(drpText_F5.SelectedItem.Value), chkNotCriteria5.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F5, false), chkNotCriteria5.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From5.Text, txtDate_To5.Text, lstDate5.SelectedItem.Value, chkNotCriteria5.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F5.Text, txtAmount2_F5.Text, drpAmount_F5.SelectedItem.Value, chkNotCriteria5.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F5.Text, txtAmount2_F5.Text, drpAmount_F5.SelectedItem.Value, chkNotCriteria5.Checked);
                }
            }
            if (drpFilter6.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter6.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter6.Text, Convert.ToInt16(drpText_F6.SelectedItem.Value), chkNotCriteria6.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F6, false), chkNotCriteria6.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From6.Text, txtDate_To6.Text, lstDate6.SelectedItem.Value, chkNotCriteria6.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F6.Text, txtAmount2_F6.Text, drpAmount_F6.SelectedItem.Value, chkNotCriteria6.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F6.Text, txtAmount2_F6.Text, drpAmount_F6.SelectedItem.Value, chkNotCriteria6.Checked);
                }
            }
            if (drpFilter7.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter7.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter7.Text, Convert.ToInt16(drpText_F7.SelectedItem.Value), chkNotCriteria7.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F7, false), chkNotCriteria7.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From7.Text, txtDate_To7.Text, lstDate7.SelectedItem.Value, chkNotCriteria7.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F7.Text, txtAmount2_F7.Text, drpAmount_F7.SelectedItem.Value, chkNotCriteria7.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F7.Text, txtAmount2_F7.Text, drpAmount_F7.SelectedItem.Value, chkNotCriteria7.Checked);
                }

            }
            if (drpFilter8.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter8.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter8.Text, Convert.ToInt16(drpText_F8.SelectedItem.Value), chkNotCriteria8.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F8, false), chkNotCriteria8.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From8.Text, txtDate_To8.Text, lstDate8.SelectedItem.Value, chkNotCriteria8.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F8.Text, txtAmount2_F8.Text, drpAmount_F8.SelectedItem.Value, chkNotCriteria8.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F8.Text, txtAmount2_F8.Text, drpAmount_F8.SelectedItem.Value, chkNotCriteria8.Checked);
                }

            }
            if (drpFilter9.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter9.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);

                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter9.Text, Convert.ToInt16(drpText_F9.SelectedItem.Value), chkNotCriteria9.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F9, false), chkNotCriteria9.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From9.Text, txtDate_To9.Text, lstDate9.SelectedItem.Value, chkNotCriteria9.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F9.Text, txtAmount2_F9.Text, drpAmount_F9.SelectedItem.Value, chkNotCriteria9.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F9.Text, txtAmount2_F9.Text, drpAmount_F9.SelectedItem.Value, chkNotCriteria9.Checked);
                }

            }
            if (drpFilter10.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter10.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter10.Text, Convert.ToInt16(drpText_F10.SelectedItem.Value), chkNotCriteria10.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F10, false), chkNotCriteria10.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From10.Text, txtDate_To10.Text, lstDate10.SelectedItem.Value, chkNotCriteria10.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F10.Text, txtAmount2_F10.Text, drpAmount_F10.SelectedItem.Value, chkNotCriteria10.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F10.Text, txtAmount2_F10.Text, drpAmount_F10.SelectedItem.Value, chkNotCriteria10.Checked);
                }
            }
            #endregion
            #endregion

            clsGeneral.DisposeOf(lstAdhoc);
            try
            {
                //Reader = AdHocReportHelper.GetAdHocReportACI(GetAllItemString(lstSelectedFields, false), strGroupBy, PVD, strWhere, strOrderBy, strFilterIds, Convert.ToBoolean(Convert.ToInt32(rdbEvent.SelectedValue)));
                Reader = AdHocReportHelper.GetAdHocReportForManagement(GetAllItemString(lstSelectedFields, false), strGroupBy, PVD, strWhere, strOrderBy, strFilterIds);//Always set as Management

            }
            catch (Exception ex)
            {
                throw ex;
            }

            dtSchema = Reader.GetSchemaTable();
            if (dtSchema.Rows[dtSchema.Rows.Count - 1][0].ToString() == "FK_Claim")
            {
                dtSchema.Rows.RemoveAt(dtSchema.Rows.Count - 1);
            }

            // Check if Any record is exists or not
            if (Reader.Read())
            {
                string strFirstGroupBy = null, strSecGroupBy = null, strThirdGroupBy = null, strFourthGroupBy = null, strFifthGroupBy = null;//change

                if (drpGroupByFirst.SelectedIndex > 0)
                    strFirstGroupBy = drpGroupByFirst.SelectedItem.Text;

                if (drpGroupBySecond.SelectedIndex > 0)
                    strSecGroupBy = drpGroupBySecond.SelectedItem.Text;
                if (drpGroupByThird.SelectedIndex > 0)
                    strThirdGroupBy = drpGroupByThird.SelectedItem.Text;
                if (drpGroupByFourth.SelectedIndex > 0)
                    strFourthGroupBy = drpGroupByFourth.SelectedItem.Text;
                if (drpGroupByFifth.SelectedIndex > 0)
                    strFifthGroupBy = drpGroupByFifth.SelectedItem.Text;
                //iF Frist Group By is Not  selected then second Group by will be set as first Group By
                //if (string.IsNullOrEmpty(strFirstGroupBy) && !string.IsNullOrEmpty(strGroupBy))
                //{
                //    strFirstGroupBy = strSecGroupBy;
                //    strSecGroupBy = string.Empty;
                //}



                //dtSchema.Rows[dtSchema.Rows.Count - 1].Delete();

                // width='" + (110 * _NumberofColumn).ToString() + "'
                //Table Start
                if (ReportType == ReportOutputType.ExportAsMail)
                {
                    sbRecord.Append("<br />");
                    sbRecord.Append("<b>Report Title : Management Ad Hoc Report </b>");
                    sbRecord.Append("<br />");
                }

                sbRecord.Append(GenerateFilterCriteria());

                sbRecord.Append("<table border='1' cellpadding='0' cellspacing='0' width='" + (150 * lstSelectedFields.Items.Count).ToString() + "' style='font-size:10pt'>");

                #region "Header"
                // If reader found a records 
                sbRecord.Append("<tr>");
                sbRecord.Append("<td>&nbsp;</td>");
                dtHeader = new DataTable();
                string strFormatFirstGroupBy = string.Empty, strFormatSecGroupBy = string.Empty, strFormatThirdGroupBy = string.Empty, strFormatFourthGroupBy = string.Empty, strFormatFifthGroupBy = string.Empty;

                foreach (DataRow drHeader in dtSchema.Rows)
                {

                    //Remove Group By 
                    if (strFirstGroupBy != Convert.ToString(drHeader["ColumnName"]) && strSecGroupBy != Convert.ToString(drHeader["ColumnName"]) && strThirdGroupBy != Convert.ToString(drHeader["ColumnName"]) && strFourthGroupBy != Convert.ToString(drHeader["ColumnName"]) && strFifthGroupBy != Convert.ToString(drHeader["ColumnName"]))
                        sbRecord.Append("<td><b>" + drHeader["ColumnName"] + "</b></td>");

                    //IF Grand Total Option is Selected.
                    if (chkGrandTotal.Checked && CheckTotalField(drHeader["ColumnName"].ToString()))
                        dtHeader.Columns.Add(new DataColumn(drHeader["ColumnName"].ToString(), Type.GetType("System.Decimal")));

                    //Get First and Second Group By Field's Data Type
                    if (strFirstGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatFirstGroupBy = drHeader["DataTypeName"].ToString();
                    if (strSecGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatSecGroupBy = drHeader["DataTypeName"].ToString();
                    if (strThirdGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatThirdGroupBy = drHeader["DataTypeName"].ToString();
                    if (strFourthGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatFourthGroupBy = drHeader["DataTypeName"].ToString();
                    if (strFifthGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatFifthGroupBy = drHeader["DataTypeName"].ToString();

                }
                //When Header have records
                if (dtHeader.Columns.Count > 0)
                {
                    DataRow drHerder = dtHeader.NewRow();

                    for (int i = 0; i < dtHeader.Columns.Count; i++)
                        drHerder[i] = 0;

                    dtHeader.Rows.Add(drHerder);
                    dtHeader.AcceptChanges();
                }

                sbRecord.Append("</tr>");

                #endregion

                strPath = AppConfig.SitePath + @"temp\" + Session.SessionID.ToString();

                if (!File.Exists(strPath))
                {
                    if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
                        Directory.CreateDirectory(AppConfig.SitePath + @"temp\");
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(strPath))
                    {
                        sw.Write(sbRecord.ToString());
                        sbRecord = new StringBuilder(string.Empty);
                    }
                }

                #region "Item Template"

                DataTable dtSubTotalFirstGroup = dtHeader.Clone();
                DataTable dtSubTotalSecondGroup = dtHeader.Clone();
                DataTable dtSubTotalThirdGroup = dtHeader.Clone();
                DataTable dtSubTotalFourthGroup = dtHeader.Clone();
                DataTable dtSubTotalFifthGroup = dtHeader.Clone();

                string strGroupByValue_1 = null, strGroupByValue_2 = null, strNOGroup1 = string.Empty, strNOGroup2 = string.Empty;
                string strGroupByValue_3 = null, strGroupByValue_4 = null, strNOGroup3 = string.Empty, strNOGroup4 = string.Empty;
                string strGroupByValue_5 = null, strNOGroup5 = string.Empty;
                do
                {
                    string strFormat = string.Empty;
                    string strCurrValue1 = strFirstGroupBy != null ? (Reader[strFirstGroupBy] != DBNull.Value ? Convert.ToString(Reader[strFirstGroupBy]) : null) : null;
                    string strCurrValue2 = strSecGroupBy != null ? (Reader[strSecGroupBy] != DBNull.Value ? Convert.ToString(Reader[strSecGroupBy]) : null) : null;
                    string strCurrValue3 = strThirdGroupBy != null ? (Reader[strThirdGroupBy] != DBNull.Value ? Convert.ToString(Reader[strThirdGroupBy]) : null) : null;
                    string strCurrValue4 = strFourthGroupBy != null ? (Reader[strFourthGroupBy] != DBNull.Value ? Convert.ToString(Reader[strFourthGroupBy]) : null) : null;
                    string strCurrValue5 = strFifthGroupBy != null ? (Reader[strFifthGroupBy] != DBNull.Value ? Convert.ToString(Reader[strFifthGroupBy]) : null) : null;

                    #region "SUBTOTALS"
                    #region Fifth

                    // print subtotal for 5th group by when the value is changed
                    if (!(strGroupByValue_1 == strCurrValue1 && strGroupByValue_2 == strCurrValue2 && strGroupByValue_3 == strCurrValue3 && strGroupByValue_4 == strCurrValue4 && strGroupByValue_5 == strCurrValue5))
                    {
                        if (dtSubTotalFifthGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalFifthGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFifthGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                        sbRecord.Append("<td><b>Sub Total For " + strFifthGroupBy + "</b></td>");
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalFifthGroup.Clear();
                        }
                    }
                    #endregion
                    #region Fourth
                    // print subtotal for 4th group by when the value is changed
                    if (!(strGroupByValue_1 == strCurrValue1 && strGroupByValue_2 == strCurrValue2 && strGroupByValue_3 == strCurrValue3 && strGroupByValue_4 == strCurrValue4))
                    {
                        if (dtSubTotalFourthGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalFourthGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFourthGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                        sbRecord.Append("<td><b>Sub Total For " + strFourthGroupBy + "</b></td>");
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalFourthGroup.Clear();
                        }
                    }
                    #endregion
                    #region Third
                    // print subtotal for 3rd group by when the value is changed
                    if (!(strGroupByValue_1 == strCurrValue1 && strGroupByValue_2 == strCurrValue2 && strGroupByValue_3 == strCurrValue3))
                    {
                        if (dtSubTotalThirdGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalThirdGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalThirdGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                        sbRecord.Append("<td><b>Sub Total For " + strThirdGroupBy + "</b></td>");
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalThirdGroup.Clear();
                        }
                    }
                    #endregion
                    #region Second
                    // print subtotal for 2nd group by when the value is changed
                    if (!(strGroupByValue_1 == strCurrValue1 && strGroupByValue_2 == strCurrValue2))
                    {
                        if (dtSubTotalSecondGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalSecondGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalSecondGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                        sbRecord.Append("<td><b>Sub Total For " + strSecGroupBy + "</b></td>");
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalSecondGroup.Clear();
                        }
                    }
                    #endregion
                    #region First
                    // print subtotal for 1st group by when the value is changed
                    if ((strFirstGroupBy != null) && (strGroupByValue_1 != null) && strGroupByValue_1 != strCurrValue1)
                    {
                        if (dtSubTotalFirstGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalFirstGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFirstGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                        sbRecord.Append("<td><b>Sub Total For " + strFirstGroupBy + "</b></td>");
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalFirstGroup.Clear();
                        }
                    }
                    #endregion

                    #endregion


                    //First Group By
                    #region First GroupBy
                    if (!string.IsNullOrEmpty(strFirstGroupBy))
                    {
                        if (strGroupByValue_1 != strCurrValue1)
                        {
                            strGroupByValue_1 = strCurrValue1;
                            if (strFormatFirstGroupBy == "decimal")
                                sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;' align='right'>&nbsp;" + strFirstGroupBy + ": " + string.Format("{0:c2}", strGroupByValue_1) + "</td><td>&nbsp;</td></tr>");
                            else if (strFormatFirstGroupBy == "datetime")
                                sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;'>&nbsp;" + strFirstGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_1) + "</td><td>&nbsp;</td></tr>");
                            else
                                sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;'>&nbsp;" + strFirstGroupBy + ": " + strGroupByValue_1 + "</td><td>&nbsp;</td></tr>");
                            //Change Second Group By when First Groupby is Change
                            strGroupByValue_2 = strGroupByValue_3 = strGroupByValue_4 = strGroupByValue_5 = null;
                        }
                    }
                    #endregion
                    //Second Group By
                    #region Second GroupBY
                    if (!string.IsNullOrEmpty(strSecGroupBy))
                    {
                        if (strGroupByValue_2 != strCurrValue2)
                        {
                            strGroupByValue_2 = strCurrValue2;
                            if (strFormatSecGroupBy == "decimal")
                                sbRecord.Append("<tr><td style='font-weight: bold;color: #276692;' align='right' >&nbsp;" + strSecGroupBy + ": " + string.Format("{0:c2}", strGroupByValue_2) + "</td></tr>");
                            else if (strFormatSecGroupBy == "datetime")
                            {
                                // it display only Time
                                if (strSecGroupBy == "Time Theft Reported")
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #276692;'>&nbsp;" + strSecGroupBy + ": " + string.Format("{0:HH:mm}", Reader[strSecGroupBy]) + "</td></tr>");
                                else sbRecord.Append("<tr><td style='font-weight: bold;color: #276692;' >&nbsp;" + strSecGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_2) + "</td></tr>");
                            }
                            else sbRecord.Append("<tr><td style='font-weight: bold;color: #276692;' >&nbsp;" + strSecGroupBy + ": " + strGroupByValue_2 + "</td></tr>");
                            strGroupByValue_3 = strGroupByValue_4 = strGroupByValue_5 = null;
                        }
                    }
                    #endregion
                    #region Third GroupBY
                    if (!string.IsNullOrEmpty(strThirdGroupBy))
                    {
                        if (strGroupByValue_3 != strCurrValue3)
                        {
                            strGroupByValue_3 = strCurrValue3;
                            if (strFormatThirdGroupBy == "decimal")
                                sbRecord.Append("<tr><td style='font-weight: bold;color: #603311;' align='right' >&nbsp;" + strThirdGroupBy + ": " + string.Format("{0:c2}", strGroupByValue_3) + "</td></tr>");
                            else if (strFormatThirdGroupBy == "datetime")
                            {
                                // it display only Time
                                if (strThirdGroupBy == "Time Theft Reported")
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #603311;'>&nbsp;" + strThirdGroupBy + ": " + string.Format("{0:HH:mm}", Reader[strThirdGroupBy]) + "</td></tr>");
                                else sbRecord.Append("<tr><td style='font-weight: bold;color: #603311;' >&nbsp;" + strThirdGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_3) + "</td></tr>");
                            }
                            else sbRecord.Append("<tr><td style='font-weight: bold;color: #603311;' >&nbsp;" + strThirdGroupBy + ": " + strGroupByValue_3 + "</td></tr>");
                            strGroupByValue_4 = strGroupByValue_5 = null;
                        }
                    }
                    #endregion
                    #region Fourth GroupBY
                    if (!string.IsNullOrEmpty(strFourthGroupBy))
                    {
                        if (strGroupByValue_4 != strCurrValue4)
                        {
                            strGroupByValue_4 = strCurrValue4;
                            if (strFormatFourthGroupBy == "decimal")
                                sbRecord.Append("<tr><td style='font-weight: bold;color: green;' align='right' >&nbsp;" + strFourthGroupBy + ": " + string.Format("{0:c2}", strGroupByValue_4) + "</td></tr>");
                            else if (strFormatFourthGroupBy == "datetime")
                            {
                                // it display only Time
                                if (strFourthGroupBy == "Time Theft Reported")
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: green;'>&nbsp;" + strFourthGroupBy + ": " + string.Format("{0:HH:mm}", Reader[strFourthGroupBy]) + "</td></tr>");
                                else sbRecord.Append("<tr><td style='font-weight: bold;color: green;' >&nbsp;" + strFourthGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_4) + "</td></tr>");
                            }
                            else sbRecord.Append("<tr><td style='font-weight: bold;color: green;' >&nbsp;" + strFourthGroupBy + ": " + strGroupByValue_4 + "</td></tr>");
                            strGroupByValue_5 = null;
                        }
                    }
                    #endregion
                    #region Fifth GroupBY
                    if (!string.IsNullOrEmpty(strFifthGroupBy))
                    {
                        if (strGroupByValue_5 != strCurrValue5)
                        {
                            strGroupByValue_5 = strCurrValue5;
                            if (strFormatFifthGroupBy == "decimal")
                                sbRecord.Append("<tr><td style='font-weight: bold;' align='right' >&nbsp;" + strFifthGroupBy + ": " + string.Format("{0:c2}", strGroupByValue_5) + "</td></tr>");
                            else if (strFormatFifthGroupBy == "datetime")
                            {
                                // it display only Time
                                if (strFifthGroupBy == "Time Theft Reported")
                                    sbRecord.Append("<tr><td style='font-weight: bold;'>&nbsp;" + strFifthGroupBy + ": " + string.Format("{0:HH:mm}", Reader[strFifthGroupBy]) + "</td></tr>");
                                else sbRecord.Append("<tr><td style='font-weight: bold;' >&nbsp;" + strFifthGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_5) + "</td></tr>");
                            }
                            else sbRecord.Append("<tr><td style='font-weight: bold;' >&nbsp;" + strFifthGroupBy + ": " + strGroupByValue_5 + "</td></tr>");
                        }
                    }
                    #endregion
                    string strColumnName = string.Empty;
                    sbRecord.Append("<tr>");
                    sbRecord.Append("<td>&nbsp;</td>");
                    ///Print Records
                    #region Print Records
                    for (int intColumn = 0; intColumn < dtSchema.Rows.Count; intColumn++)
                    {
                        #region " Count Sub Totals"
                        #region First : 1st
                        // if (!string.IsNullOrEmpty(strFirstGroupBy) && !string.IsNullOrEmpty(strGroupByValue_1))
                        if ((strFirstGroupBy != null) && (strGroupByValue_1 != null))
                        {
                            if (dtSubTotalFirstGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue1 == strGroupByValue_1)
                            {
                                if (dtSubTotalFirstGroup.Rows.Count == 0)
                                {
                                    dtSubTotalFirstGroup.Rows.Add(dtSubTotalFirstGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalFirstGroup.Columns)
                                        dtSubTotalFirstGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalFirstGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalFirstGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #region Second : 2nd
                        //if (!string.IsNullOrEmpty(strSecGroupBy) && !string.IsNullOrEmpty(strGroupByValue_2))
                        if ((strSecGroupBy != null) && (strGroupByValue_2 != null))
                        {
                            if (dtSubTotalSecondGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue2 == strGroupByValue_2)
                            {
                                if (dtSubTotalSecondGroup.Rows.Count == 0)
                                {
                                    dtSubTotalSecondGroup.Rows.Add(dtSubTotalSecondGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalSecondGroup.Columns)
                                        dtSubTotalSecondGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalSecondGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalSecondGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #region Third : 3nd
                        //if (!string.IsNullOrEmpty(strThirdGroupBy) && !string.IsNullOrEmpty(strGroupByValue_3))
                        if ((strThirdGroupBy != null) && (strGroupByValue_3 != null))
                        {
                            if (dtSubTotalThirdGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue3 == strGroupByValue_3)
                            {
                                if (dtSubTotalThirdGroup.Rows.Count == 0)
                                {
                                    dtSubTotalThirdGroup.Rows.Add(dtSubTotalThirdGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalThirdGroup.Columns)
                                        dtSubTotalThirdGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalThirdGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalThirdGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #region Fourth : 4th
                        //if (!string.IsNullOrEmpty(strFourthGroupBy) && !string.IsNullOrEmpty(strGroupByValue_4))
                        if ((strFourthGroupBy != null) && (strGroupByValue_4 != null))
                        {
                            if (dtSubTotalFourthGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue4 == strGroupByValue_4)
                            {
                                if (dtSubTotalFourthGroup.Rows.Count == 0)
                                {
                                    dtSubTotalFourthGroup.Rows.Add(dtSubTotalFourthGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalFourthGroup.Columns)
                                        dtSubTotalFourthGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalFourthGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalFourthGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #region Fifth : 5th
                        //if (!string.IsNullOrEmpty(strFifthGroupBy) && !string.IsNullOrEmpty(strGroupByValue_5))
                        if ((strFifthGroupBy != null) && (strGroupByValue_5 != null))
                        {
                            if (dtSubTotalFifthGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue5 == strGroupByValue_5)
                            {
                                if (dtSubTotalFifthGroup.Rows.Count == 0)
                                {
                                    dtSubTotalFifthGroup.Rows.Add(dtSubTotalFifthGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalFifthGroup.Columns)
                                        dtSubTotalFifthGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalFifthGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalFifthGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #endregion
                        //Remove Group By Column
                        #region
                        if (strFirstGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) && strSecGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) && strThirdGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) && strFourthGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) && strFifthGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]))
                        {
                            strFormat = dtSchema.Rows[intColumn]["DataTypeName"].ToString();

                            if (strFormat == "decimal")
                            {

                                // If dataType is Numeric but it is not Currency field.
                                if (CheckISdisplayCurrencyFormat(dtSchema.Rows[intColumn][0].ToString()))
                                    sbRecord.Append("<td align='right'>" + string.Format("{0:c2}", Reader[intColumn]) + "</td>");
                                else
                                    sbRecord.Append("<td align='right'>" + Convert.ToString(Reader[intColumn]) + "</td>");
                            }
                            else if (strFormat == "datetime")
                            {
                                // it display only Time
                                if (Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Time Theft Reported")
                                    sbRecord.Append("<td>" + string.Format("{0:HH:mm}", Reader[intColumn]) + "</td>");
                                else sbRecord.Append("<td>" + string.Format("{0:MM/dd/yyyy}", Reader[intColumn]) + "</td>");
                            }
                            else
                            {
                                //sbRecord.Append(@"<td style='mso-number-format:\@;'>&nbsp;" + Convert.ToString(Reader[intColumn]) + "</td>");
                                sbRecord.Append(@"><td>" + Convert.ToString(Reader[intColumn]) + "</td>");
                            }
                        }
                        #endregion
                        #region "Grand Total"
                        //IF Grand Total Option is Selected and Have Field for SUM.
                        if (chkGrandTotal.Checked && dtHeader.Columns.Count > 0)
                        {
                            if (dtHeader.Columns.Contains(Reader.GetName(intColumn)))
                            {
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtHeader.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtHeader.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                    }
                    sbRecord.Append("</tr>");
                    #endregion


                    using (StreamWriter sw = File.AppendText(strPath))
                    {
                        sw.Write(sbRecord);
                        sbRecord = new StringBuilder(string.Empty);
                    }

                } while (Reader.Read());

                #region " SUBTOAL FOR Last groups "
                if (dtSubTotalFifthGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {
                        if (dtSubTotalFifthGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFifthGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                                sbRecord.Append("<td align='left'><b>Sub Total For " + strFifthGroupBy + "</b></td>");
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalFifthGroup.Clear();
                }
                if (dtSubTotalFourthGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {
                        if (dtSubTotalFourthGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFourthGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                                sbRecord.Append("<td align='left'><b>Sub Total For " + strFourthGroupBy + "</b></td>");
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalFourthGroup.Clear();
                }
                if (dtSubTotalThirdGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {
                        if (dtSubTotalThirdGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalThirdGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                                sbRecord.Append("<td align='left'><b>Sub Total For " + strThirdGroupBy + "</b></td>");
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalThirdGroup.Clear();
                }
                if (dtSubTotalSecondGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {
                        if (dtSubTotalSecondGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalSecondGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                                sbRecord.Append("<td align='left'><b>Sub Total For " + strSecGroupBy + "</b></td>");
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalSecondGroup.Clear();
                }
                if (dtSubTotalFirstGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {

                        if (dtSubTotalFirstGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFirstGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                                sbRecord.Append("<td align='left'><b>Sub Total For " + strFirstGroupBy + "</b></td>");
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalFirstGroup.Clear();
                }

                #endregion

                #endregion

                //Table End
                sbRecord.Append("</table>");

                #region "Footer Template"
                // IF Grand Total Option is Checked and Have record from Transaction Table to SUM
                if ((chkGrandTotal.Checked) && dtHeader.Columns.Count > 0)
                {
                    string strStyle = "'font-weight: bold;background-color: #507CD1;color: White;'";
                    sbRecord.Append("<br />");
                    sbRecord.Append("<table border='1' cellpadding='0' cellspacing='0'><tr align='right'>");
                    sbRecord.Append("<td style='font-weight: bold;' align='left'>Grand Totals</td>");

                    for (int intColumn = 0; intColumn < dtHeader.Columns.Count; intColumn++)
                        sbRecord.Append("<td style='font-weight: bold;'>" + Convert.ToString(dtHeader.Columns[intColumn]) + "</td>");

                    sbRecord.Append("</tr>");

                    sbRecord.Append("<tr align='right'>");
                    sbRecord.Append("<td style=" + strStyle + ">&nbsp;</td>");

                    for (int intColumn = 0; intColumn < dtHeader.Columns.Count; intColumn++)
                        sbRecord.Append("<td style=" + strStyle + ">" + string.Format("{0:c2}", dtHeader.Rows[0][intColumn]) + "</td>");

                    sbRecord.Append("</tr><table>");
                }
                #endregion
                //Remove White Space.
                //sbRecord.Replace("<tr></tr>", "");
                using (StreamWriter sw = File.AppendText(strPath))
                {
                    sw.Write(sbRecord);
                    sbRecord = new StringBuilder(string.Empty);
                }
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('No Data available for Selected Criteria');", true);

            if (!Reader.IsClosed)
                Reader.Close();
            return strPath;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (Reader != null)
            {
                Reader.Close();
                clsGeneral.DisposeOf(Reader);
            }
            clsGeneral.DisposeOf(lstAdhoc);
            clsGeneral.DisposeOf(dtSchema);
            clsGeneral.DisposeOf(dtHeader);
        }
    }

    /// <summary>
    /// Bind Report Data.
    /// </summary>
    /// <param name="dsReport">Report Dataset</param>
    private string BindReport(ref StringBuilder sbRecord, ReportOutputType ReportType)
    {
        IDataReader Reader = null;
        List<ERIMS.DAL.Management_AdhocReportFields> lstAdhoc = null;
        DataTable dtSchema = null, dtHeader = null;
        bool IsGroupBySelected = false;
        try
        {
            decimal decValue;
            int iSelected;
            string strWhere = string.Empty, strFilterIds = string.Empty, strGroupBy = string.Empty, strOrderBy = string.Empty, strCriteria = string.Empty, strPath = string.Empty;
            DateTime? PVD = null;
            if (drpGroupByFirst.SelectedIndex > 0 || drpGroupBySecond.SelectedIndex > 0 || drpGroupByThird.SelectedIndex > 0 || drpGroupByFourth.SelectedIndex > 0 || drpGroupByFifth.SelectedIndex > 0)
                IsGroupBySelected = true;
            #region "Group By and Filter By"

            if (drpGroupByFirst.SelectedIndex > 0)
                strGroupBy = "[" + drpGroupByFirst.SelectedItem.Text + "]" + rdblGroupSortByFirst.SelectedItem.Value;

            if (drpGroupBySecond.SelectedIndex > 0)
                strGroupBy += (string.IsNullOrEmpty(strGroupBy) ? "" : ",") + " [" + drpGroupBySecond.SelectedItem.Text + "]" + rdblGroupSortBySecond.SelectedItem.Value;

            if (drpGroupByThird.SelectedIndex > 0)
                strGroupBy += (string.IsNullOrEmpty(strGroupBy) ? "" : ",") + "[" + drpGroupByThird.SelectedItem.Text + "]" + rdblGroupSortByThird.SelectedItem.Value;

            if (drpGroupByFourth.SelectedIndex > 0)
                strGroupBy += (string.IsNullOrEmpty(strGroupBy) ? "" : ",") + "[" + drpGroupByFourth.SelectedItem.Text + "]" + rdblGroupSortByFourth.SelectedItem.Value;

            if (drpGroupByFifth.SelectedIndex > 0)
                strGroupBy += (string.IsNullOrEmpty(strGroupBy) ? "" : ",") + "[" + drpGroupByFifth.SelectedItem.Text + "]" + rdblGroupSortByFifth.SelectedItem.Value;

            if (drpSortingFirst.SelectedIndex > 0)
                strOrderBy = "[" + drpSortingFirst.SelectedItem.Text + "] " + rdbSort1.SelectedItem.Value;

            if (drpSortingSecond.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingSecond.SelectedItem.Text + "] " + rdbSort2.SelectedItem.Value;

            if (drpSortingThird.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingThird.SelectedItem.Text + "] " + rdbSort3.SelectedItem.Value;

            if (drpSortingFourth.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingFourth.SelectedItem.Text + "] " + rdbSort4.SelectedItem.Value;

            if (drpSortingFifth.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingFifth.SelectedItem.Text + "] " + rdbSort5.SelectedItem.Value;

            #endregion

            strCriteria = GetFilterIDs(new DropDownList[] { drpFilter1, drpFilter2, drpFilter3, drpFilter4, drpFilter5, drpFilter6, drpFilter7, drpFilter8, drpFilter9, drpFilter10, });

            if (!string.IsNullOrEmpty(strCriteria))
                lstAdhoc = new ERIMS.DAL.Management_AdhocReportFields().GetAdHocReportFieldByMultipleID(strCriteria);

            #region "Get Where condition"
            //Prior Valuation Date.            
            if (!string.IsNullOrEmpty(txtPriorDate.Text))
                PVD = clsGeneral.FormatNullDateToStore(txtPriorDate.Text);
            //    strPVD = GetDateWhereCondtion("Issue_Date", txtPriorDate.Text, string.Empty, "BF");

            //Get Coverage By Assigned USer Right
            strWhere = strWhere + GetCoverage();
            #region Filter Criteria
            //If iflter 1 is selected.
            if (drpFilter1.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter1.SelectedItem.Value);
                strFilterIds += decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter1.Text, Convert.ToInt16(drpText_F1.SelectedItem.Value), chkNotCriteria1.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal = lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F1, bStringVal), chkNotCriteria1.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From1.Text, txtDate_To1.Text, lstDate1.SelectedItem.Value, chkNotCriteria1.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    // It takes Filed Header when Table is Transaction otherwist it take Filed Name.
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F1.Text, txtAmount2_F1.Text, drpAmount_F1.SelectedItem.Value, chkNotCriteria1.Checked);
                    else
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F1.Text, txtAmount2_F1.Text, drpAmount_F1.SelectedItem.Value, chkNotCriteria1.Checked);
                }

            }
            if (drpFilter2.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter2.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter2.Text, Convert.ToInt16(drpText_F2.SelectedItem.Value), chkNotCriteria2.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal = lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F2, bStringVal), chkNotCriteria2.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From2.Text, txtDateTo2.Text, lstDate2.SelectedItem.Value, chkNotCriteria2.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F2.Text, txtAmount2_F2.Text, drpAmount_F2.SelectedItem.Value, chkNotCriteria2.Checked);
                    else
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F2.Text, txtAmount2_F2.Text, drpAmount_F2.SelectedItem.Value, chkNotCriteria2.Checked);
                }

            }
            if (drpFilter3.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter3.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter3.Text, Convert.ToInt16(drpText_F3.SelectedItem.Value), chkNotCriteria3.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal = lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F3, bStringVal), chkNotCriteria3.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From3.Text, txtDate_To3.Text, lstDate3.SelectedItem.Value, chkNotCriteria3.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F3.Text, txtAmount2_F3.Text, drpAmount_F3.SelectedItem.Value, chkNotCriteria3.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F3.Text, txtAmount2_F3.Text, drpAmount_F3.SelectedItem.Value, chkNotCriteria3.Checked);
                }

            }
            if (drpFilter4.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter4.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter4.Text, Convert.ToInt16(drpText_F4.SelectedItem.Value), chkNotCriteria4.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal = lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F4, bStringVal), chkNotCriteria4.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From4.Text, txtDate_To4.Text, lstDate4.SelectedItem.Value, chkNotCriteria4.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F4.Text, txtAmount2_F4.Text, drpAmount_F4.SelectedItem.Value, chkNotCriteria4.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F4.Text, txtAmount2_F4.Text, drpAmount_F4.SelectedItem.Value, chkNotCriteria4.Checked);
                }
            }
            if (drpFilter5.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter5.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter5.Text, Convert.ToInt16(drpText_F5.SelectedItem.Value), chkNotCriteria5.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal = lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F5, bStringVal), chkNotCriteria5.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                {
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From5.Text, txtDate_To5.Text, lstDate5.SelectedItem.Value, chkNotCriteria5.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F5.Text, txtAmount2_F5.Text, drpAmount_F5.SelectedItem.Value, chkNotCriteria5.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F5.Text, txtAmount2_F5.Text, drpAmount_F5.SelectedItem.Value, chkNotCriteria5.Checked);
                }
            }
            if (drpFilter6.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter6.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter6.Text, Convert.ToInt16(drpText_F6.SelectedItem.Value), chkNotCriteria6.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal = lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F6, bStringVal), chkNotCriteria6.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From6.Text, txtDate_To6.Text, lstDate6.SelectedItem.Value, chkNotCriteria6.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F6.Text, txtAmount2_F6.Text, drpAmount_F6.SelectedItem.Value, chkNotCriteria6.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F6.Text, txtAmount2_F6.Text, drpAmount_F6.SelectedItem.Value, chkNotCriteria6.Checked);
                }
            }
            if (drpFilter7.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter7.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter7.Text, Convert.ToInt16(drpText_F7.SelectedItem.Value), chkNotCriteria7.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal =  lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F7, bStringVal), chkNotCriteria7.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From7.Text, txtDate_To7.Text, lstDate7.SelectedItem.Value, chkNotCriteria7.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F7.Text, txtAmount2_F7.Text, drpAmount_F7.SelectedItem.Value, chkNotCriteria7.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F7.Text, txtAmount2_F7.Text, drpAmount_F7.SelectedItem.Value, chkNotCriteria7.Checked);
                }

            }
            if (drpFilter8.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter8.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter8.Text, Convert.ToInt16(drpText_F8.SelectedItem.Value), chkNotCriteria8.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal = lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F8, bStringVal), chkNotCriteria8.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From8.Text, txtDate_To8.Text, lstDate8.SelectedItem.Value, chkNotCriteria8.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F8.Text, txtAmount2_F8.Text, drpAmount_F8.SelectedItem.Value, chkNotCriteria8.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F8.Text, txtAmount2_F8.Text, drpAmount_F8.SelectedItem.Value, chkNotCriteria8.Checked);
                }

            }
            if (drpFilter9.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter9.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);

                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter9.Text, Convert.ToInt16(drpText_F9.SelectedItem.Value), chkNotCriteria9.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal =  lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F9, bStringVal), chkNotCriteria9.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From9.Text, txtDate_To9.Text, lstDate9.SelectedItem.Value, chkNotCriteria9.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F9.Text, txtAmount2_F9.Text, drpAmount_F9.SelectedItem.Value, chkNotCriteria9.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F9.Text, txtAmount2_F9.Text, drpAmount_F9.SelectedItem.Value, chkNotCriteria9.Checked);
                }

            }
            if (drpFilter10.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter10.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter10.Text, Convert.ToInt16(drpText_F10.SelectedItem.Value), chkNotCriteria10.Checked);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                {
                    bool bStringVal = lstAdhoc[iSelected].Field_Header.Contains("Task Complete") || lstAdhoc[iSelected].Field_Header.Contains("GM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision") || lstAdhoc[iSelected].Field_Header.Contains("NAPM Decision") || lstAdhoc[iSelected].Field_Header.Contains("DRM Decision") || lstAdhoc[iSelected].Field_Header.Contains("RLCM Decision");
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F10, bStringVal), chkNotCriteria10.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                {
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From10.Text, txtDate_To10.Text, lstDate10.SelectedItem.Value, chkNotCriteria10.Checked);
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F10.Text, txtAmount2_F10.Text, drpAmount_F10.SelectedItem.Value, chkNotCriteria10.Checked);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F10.Text, txtAmount2_F10.Text, drpAmount_F10.SelectedItem.Value, chkNotCriteria10.Checked);
                }
            }
            #endregion
            #endregion

            clsGeneral.DisposeOf(lstAdhoc);
            try
            {
                //Reader = AdHocReportHelper.GetAdHocReportACI(GetAllItemString(lstSelectedFields, false), strGroupBy, PVD, strWhere, strOrderBy, strFilterIds, Convert.ToBoolean(Convert.ToInt32(rdbEvent.SelectedValue)));
                Reader = AdHocReportHelper.GetAdHocReportForManagement(GetAllItemString(lstSelectedFields, false), strGroupBy, PVD, strWhere, strOrderBy, strFilterIds);//Always set as Management

            }
            catch (Exception ex)
            {
                throw ex;
            }

            dtSchema = Reader.GetSchemaTable();
            if (dtSchema.Rows[dtSchema.Rows.Count - 1][0].ToString() == "FK_Claim")
            {
                dtSchema.Rows.RemoveAt(dtSchema.Rows.Count - 1);
            }

            // Check if Any record is exists or not
            if (Reader.Read())
            {
                string strFirstGroupBy = null, strSecGroupBy = null, strThirdGroupBy = null, strFourthGroupBy = null, strFifthGroupBy = null;//change

                if (drpGroupByFirst.SelectedIndex > 0)
                    strFirstGroupBy = drpGroupByFirst.SelectedItem.Text;

                if (drpGroupBySecond.SelectedIndex > 0)
                    strSecGroupBy = drpGroupBySecond.SelectedItem.Text;
                if (drpGroupByThird.SelectedIndex > 0)
                    strThirdGroupBy = drpGroupByThird.SelectedItem.Text;
                if (drpGroupByFourth.SelectedIndex > 0)
                    strFourthGroupBy = drpGroupByFourth.SelectedItem.Text;
                if (drpGroupByFifth.SelectedIndex > 0)
                    strFifthGroupBy = drpGroupByFifth.SelectedItem.Text;
                //iF Frist Group By is Not  selected then second Group by will be set as first Group By
                //if (string.IsNullOrEmpty(strFirstGroupBy) && !string.IsNullOrEmpty(strGroupBy))
                //{
                //    strFirstGroupBy = strSecGroupBy;
                //    strSecGroupBy = string.Empty;
                //}



                //dtSchema.Rows[dtSchema.Rows.Count - 1].Delete();

                // width='" + (110 * _NumberofColumn).ToString() + "'
                //Table Start
                if (ReportType == ReportOutputType.ExportAsMail)
                {
                    sbRecord.Append("<br />");
                    sbRecord.Append("<b>Report Title : Management Ad Hoc Report </b>");
                    sbRecord.Append("<br />");
                }

                sbRecord.Append(GenerateFilterCriteria());

                if (ReportType == ReportOutputType.ExportAsMail)
                {
                    sbRecord.Replace("<tr><td><b>Report Title : Management Ad-Hoc Report</b></td></tr>", "");
                }

                sbRecord.Append("<table border='1' cellpadding='0' cellspacing='0' width='" + (150 * lstSelectedFields.Items.Count).ToString() + "' style='font-size:10pt;border-right:black 0.5px solid;'>");

                #region "Header"
                // If reader found a records 
                sbRecord.Append("<tr >");
                if (IsGroupBySelected)
                    sbRecord.Append("<td>&nbsp;</td>");
                dtHeader = new DataTable();
                string strFormatFirstGroupBy = string.Empty, strFormatSecGroupBy = string.Empty, strFormatThirdGroupBy = string.Empty, strFormatFourthGroupBy = string.Empty, strFormatFifthGroupBy = string.Empty;

                foreach (DataRow drHeader in dtSchema.Rows)
                {

                    //Remove Group By 
                    if (strFirstGroupBy != Convert.ToString(drHeader["ColumnName"]) && strSecGroupBy != Convert.ToString(drHeader["ColumnName"]) && strThirdGroupBy != Convert.ToString(drHeader["ColumnName"]) && strFourthGroupBy != Convert.ToString(drHeader["ColumnName"]) && strFifthGroupBy != Convert.ToString(drHeader["ColumnName"]))
                        sbRecord.Append("<td><b>" + drHeader["ColumnName"] + "</b></td>");

                    //IF Grand Total Option is Selected.
                    if (chkGrandTotal.Checked && CheckTotalField(drHeader["ColumnName"].ToString()))
                    {
                        if (strFirstGroupBy != Convert.ToString(drHeader["ColumnName"]) && strSecGroupBy != Convert.ToString(drHeader["ColumnName"]) && strThirdGroupBy != Convert.ToString(drHeader["ColumnName"]) && strFourthGroupBy != Convert.ToString(drHeader["ColumnName"]) && strFifthGroupBy != Convert.ToString(drHeader["ColumnName"]))
                            dtHeader.Columns.Add(new DataColumn(drHeader["ColumnName"].ToString(), Type.GetType("System.Decimal")));
                    }

                    //Get First and Second Group By Field's Data Type
                    if (strFirstGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatFirstGroupBy = drHeader["DataTypeName"].ToString();
                    if (strSecGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatSecGroupBy = drHeader["DataTypeName"].ToString();
                    if (strThirdGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatThirdGroupBy = drHeader["DataTypeName"].ToString();
                    if (strFourthGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatFourthGroupBy = drHeader["DataTypeName"].ToString();
                    if (strFifthGroupBy == Convert.ToString(drHeader["ColumnName"]))
                        strFormatFifthGroupBy = drHeader["DataTypeName"].ToString();

                }
                //When Header have records
                if (dtHeader.Columns.Count > 0)
                {
                    DataRow drHerder = dtHeader.NewRow();

                    for (int i = 0; i < dtHeader.Columns.Count; i++)
                        drHerder[i] = 0;

                    dtHeader.Rows.Add(drHerder);
                    dtHeader.AcceptChanges();
                }

                sbRecord.Append("</tr>");

                #endregion

                strPath = AppConfig.SitePath + @"temp\" + Session.SessionID.ToString();

                if (!File.Exists(strPath))
                {
                    if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
                        Directory.CreateDirectory(AppConfig.SitePath + @"temp\");
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(strPath))
                    {
                        sw.Write(sbRecord.ToString());
                        sbRecord = new StringBuilder(string.Empty);
                    }
                }

                #region "Item Template"

                DataTable dtSubTotalFirstGroup = dtHeader.Clone();
                DataTable dtSubTotalSecondGroup = dtHeader.Clone();
                DataTable dtSubTotalThirdGroup = dtHeader.Clone();
                DataTable dtSubTotalFourthGroup = dtHeader.Clone();
                DataTable dtSubTotalFifthGroup = dtHeader.Clone();

                string strGroupByValue_1 = null, strGroupByValue_2 = null, strNOGroup1 = string.Empty, strNOGroup2 = string.Empty;
                string strGroupByValue_3 = null, strGroupByValue_4 = null, strNOGroup3 = string.Empty, strNOGroup4 = string.Empty;
                string strGroupByValue_5 = null, strNOGroup5 = string.Empty;
                do
                {
                    string strFormat = string.Empty;
                    string strCurrValue1 = strFirstGroupBy != null ? (Reader[strFirstGroupBy] != DBNull.Value ? Convert.ToString(Reader[strFirstGroupBy]) : "") : null;
                    string strCurrValue2 = strSecGroupBy != null ? (Reader[strSecGroupBy] != DBNull.Value ? Convert.ToString(Reader[strSecGroupBy]) : "") : null;
                    string strCurrValue3 = strThirdGroupBy != null ? (Reader[strThirdGroupBy] != DBNull.Value ? Convert.ToString(Reader[strThirdGroupBy]) : "") : null;
                    string strCurrValue4 = strFourthGroupBy != null ? (Reader[strFourthGroupBy] != DBNull.Value ? Convert.ToString(Reader[strFourthGroupBy]) : "") : null;
                    string strCurrValue5 = strFifthGroupBy != null ? (Reader[strFifthGroupBy] != DBNull.Value ? Convert.ToString(Reader[strFifthGroupBy]) : "") : null;
                    //string strCurrValue1 = strFirstGroupBy != null ? (Reader[strFirstGroupBy] != DBNull.Value ? Convert.ToString(Reader[strFirstGroupBy]) : null) : null;
                    //string strCurrValue2 = strSecGroupBy != null ? (Reader[strSecGroupBy] != DBNull.Value ? Convert.ToString(Reader[strSecGroupBy]) : null) : null;
                    //string strCurrValue3 = strThirdGroupBy != null ? (Reader[strThirdGroupBy] != DBNull.Value ? Convert.ToString(Reader[strThirdGroupBy]) : null) : null;
                    //string strCurrValue4 = strFourthGroupBy != null ? (Reader[strFourthGroupBy] != DBNull.Value ? Convert.ToString(Reader[strFourthGroupBy]) : null) : null;
                    //string strCurrValue5 = strFifthGroupBy != null ? (Reader[strFifthGroupBy] != DBNull.Value ? Convert.ToString(Reader[strFifthGroupBy]) : null) : null;

                    #region "SUBTOTALS"
                    #region Fifth

                    // print subtotal for 5th group by when the value is changed
                    if (!(strGroupByValue_1 == strCurrValue1 && strGroupByValue_2 == strCurrValue2 && strGroupByValue_3 == strCurrValue3 && strGroupByValue_4 == strCurrValue4 && strGroupByValue_5 == strCurrValue5))
                    {
                        if (dtSubTotalFifthGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            //if (IsGroupBySelected)
                            //    sbRecord.Append("<td>&nbsp;</td>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalFifthGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFifthGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                        {
                                            sbRecord.Append("<td><b>Sub Total For " + strFifthGroupBy + "</b></td><td>&nbsp;</td>");
                                        }
                                        else
                                            sbRecord.Append("<td><b>Sub Total For " + strFifthGroupBy + "</b></td>");
                                    }
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalFifthGroup.Clear();
                        }
                    }
                    #endregion
                    #region Fourth
                    // print subtotal for 4th group by when the value is changed
                    if (!(strGroupByValue_1 == strCurrValue1 && strGroupByValue_2 == strCurrValue2 && strGroupByValue_3 == strCurrValue3 && strGroupByValue_4 == strCurrValue4))
                    {
                        if (dtSubTotalFourthGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            //if (IsGroupBySelected)
                            //    sbRecord.Append("<td>&nbsp;</td>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalFourthGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFourthGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                        {
                                            sbRecord.Append("<td><b>Sub Total For " + strFourthGroupBy + "</b></td><td>&nbsp;</td>");
                                        }
                                        else
                                            sbRecord.Append("<td><b>Sub Total For " + strFourthGroupBy + "</b></td>");
                                    }
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalFourthGroup.Clear();
                        }
                    }
                    #endregion
                    #region Third
                    // print subtotal for 3rd group by when the value is changed
                    if (!(strGroupByValue_1 == strCurrValue1 && strGroupByValue_2 == strCurrValue2 && strGroupByValue_3 == strCurrValue3))
                    {
                        if (dtSubTotalThirdGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            //if (IsGroupBySelected)
                            //    sbRecord.Append("<td>&nbsp;</td>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalThirdGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalThirdGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                        {
                                            sbRecord.Append("<td><b>Sub Total For " + strThirdGroupBy + "</b></td><td>&nbsp;</td>");
                                        }
                                        else
                                            sbRecord.Append("<td><b>Sub Total For " + strThirdGroupBy + "</b></td>");
                                    }
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalThirdGroup.Clear();
                        }
                    }
                    #endregion
                    #region Second
                    // print subtotal for 2nd group by when the value is changed
                    if (!(strGroupByValue_1 == strCurrValue1 && strGroupByValue_2 == strCurrValue2))
                    {
                        if (dtSubTotalSecondGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            //if (IsGroupBySelected)
                            //    sbRecord.Append("<td>&nbsp;</td>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalSecondGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalSecondGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                        {
                                            sbRecord.Append("<td><b>Sub Total For " + strSecGroupBy + "</b></td><td>&nbsp;</td>");
                                        }
                                        else
                                            sbRecord.Append("<td><b>Sub Total For " + strSecGroupBy + "</b></td>");
                                    }
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalSecondGroup.Clear();
                        }
                    }
                    #endregion
                    #region First
                    // print subtotal for 1st group by when the value is changed
                    if ((strFirstGroupBy != null) && (strGroupByValue_1 != null) && strGroupByValue_1 != strCurrValue1)
                    {
                        if (dtSubTotalFirstGroup.Rows.Count > 0)
                        {
                            sbRecord.Append("<tr>");
                            //if (IsGroupBySelected)
                            //    sbRecord.Append("<td>&nbsp;</td>");
                            int intCol = 1;
                            foreach (DataRow drSchema in dtSchema.Rows)
                            {
                                if (dtSubTotalFirstGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                                    sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFirstGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                                else
                                {
                                    if (intCol == 1)
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                        {
                                            sbRecord.Append("<td><b>Sub Total For " + strFirstGroupBy + "</b></td><td>&nbsp;</td>");
                                        }
                                        else
                                            sbRecord.Append("<td><b>Sub Total For " + strFirstGroupBy + "</b></td>");
                                    }
                                    else
                                    {
                                        if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                            sbRecord.Append("<td>&nbsp;</td>");
                                    }
                                }
                                intCol++;
                            }

                            sbRecord.Append("</tr>");
                            dtSubTotalFirstGroup.Clear();
                        }
                    }
                    #endregion

                    #endregion


                    //Added Condition to Remove $ sign from Fields which are not needed(Auto Liability - FROI #,DPD - FROI #,Premises Liability - FROI #,Property Damage -FROI #) : #3155
                    //First Group By
                    int groupByColumnCount = 0;
                    if (!string.IsNullOrEmpty(strFirstGroupBy))
                        groupByColumnCount++;
                    if (!string.IsNullOrEmpty(strSecGroupBy))
                        groupByColumnCount++;
                    if (!string.IsNullOrEmpty(strThirdGroupBy))
                        groupByColumnCount++;
                    if (!string.IsNullOrEmpty(strFourthGroupBy))
                        groupByColumnCount++;
                    if (!string.IsNullOrEmpty(strFifthGroupBy))
                        groupByColumnCount++;

                    #region First GroupBy
                    if (!string.IsNullOrEmpty(strFirstGroupBy))
                    {
                        int colcount = Reader.FieldCount;
                        if (strGroupByValue_1 != strCurrValue1)
                        {
                            strGroupByValue_1 = strCurrValue1;
                            if (strFormatFirstGroupBy == "decimal")
                            {
                                decimal decVal;
                                decimal.TryParse(strGroupByValue_1, out decVal);
                                if (strFirstGroupBy == "Auto Liability - FROI #" || strFirstGroupBy == "DPD - FROI #" || strFirstGroupBy == "Premises Liability - FROI #" || strFirstGroupBy == "Property Damage -FROI #")
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;' >&nbsp;" + strFirstGroupBy + ": " + strGroupByValue_1 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                                else
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;' align='right' >&nbsp;" + strFirstGroupBy + ": " + string.Format("{0:c2}", decVal) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                            }
                            else if (strFormatFirstGroupBy == "datetime")
                                sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;' >&nbsp;" + strFirstGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_1) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                            else
                                sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;' >&nbsp;" + strFirstGroupBy + ": " + strGroupByValue_1 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                            //Change Second Group By when First Groupby is Change
                            strGroupByValue_2 = strGroupByValue_3 = strGroupByValue_4 = strGroupByValue_5 = null;
                        }
                    }
                    #endregion
                    //Second Group By
                    #region Second GroupBY
                    if (!string.IsNullOrEmpty(strSecGroupBy))
                    {
                        int colcount = Reader.FieldCount;
                        if (strGroupByValue_2 != strCurrValue2)
                        {
                            strGroupByValue_2 = strCurrValue2;
                            if (strFormatSecGroupBy == "decimal")
                            {
                                decimal decVal;
                                decimal.TryParse(strGroupByValue_2, out decVal);
                                if (strSecGroupBy == "Auto Liability - FROI #" || strSecGroupBy == "DPD - FROI #" || strSecGroupBy == "Premises Liability - FROI #" || strSecGroupBy == "Property Damage -FROI #")
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;' >&nbsp;" + strSecGroupBy + ": " + strGroupByValue_2 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                                else
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #276692;' align='right' >&nbsp;" + strSecGroupBy + ": " + string.Format("{0:c2}", decVal) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                            }
                            else if (strFormatSecGroupBy == "datetime")
                            {
                                // it display only Time
                                if (strSecGroupBy == "Time Theft Reported")
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #276692;' >&nbsp;" + strSecGroupBy + ": " + string.Format("{0:HH:mm}", Reader[strSecGroupBy]) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                else sbRecord.Append("<tr><td style='font-weight: bold;color: #276692;' >&nbsp;" + strSecGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_2) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                            }
                            else sbRecord.Append("<tr><td style='font-weight: bold;color: #276692;' >&nbsp;" + strSecGroupBy + ": " + strGroupByValue_2 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                            strGroupByValue_3 = strGroupByValue_4 = strGroupByValue_5 = null;
                        }
                    }
                    #endregion
                    #region Third GroupBY
                    if (!string.IsNullOrEmpty(strThirdGroupBy))
                    {
                        int colcount = Reader.FieldCount;
                        if (strGroupByValue_3 != strCurrValue3)
                        {
                            strGroupByValue_3 = strCurrValue3;
                            if (strFormatThirdGroupBy == "decimal")
                            {
                                decimal decVal;
                                decimal.TryParse(strGroupByValue_3, out decVal);
                                if (strThirdGroupBy == "Auto Liability - FROI #" || strThirdGroupBy == "DPD - FROI #" || strThirdGroupBy == "Premises Liability - FROI #" || strThirdGroupBy == "Property Damage -FROI #")
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;' >&nbsp;" + strThirdGroupBy + ": " + strGroupByValue_3 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                                else
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #603311;' align='right' >&nbsp;" + strThirdGroupBy + ": " + string.Format("{0:c2}", decVal) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                            }
                            else if (strFormatThirdGroupBy == "datetime")
                            {
                                // it display only Time
                                if (strThirdGroupBy == "Time Theft Reported")
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #603311;' >&nbsp;" + strThirdGroupBy + ": " + string.Format("{0:HH:mm}", Reader[strThirdGroupBy]) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                else sbRecord.Append("<tr><td style='font-weight: bold;color: #603311;' >&nbsp;" + strThirdGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_3) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                            }
                            else sbRecord.Append("<tr><td style='font-weight: bold;color: #603311;' >&nbsp;" + strThirdGroupBy + ": " + strGroupByValue_3 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                            strGroupByValue_4 = strGroupByValue_5 = null;
                        }
                    }
                    #endregion
                    #region Fourth GroupBY
                    if (!string.IsNullOrEmpty(strFourthGroupBy))
                    {
                        int colcount = Reader.FieldCount;
                        if (strGroupByValue_4 != strCurrValue4)
                        {
                            strGroupByValue_4 = strCurrValue4;
                            if (strFormatFourthGroupBy == "decimal")
                            {
                                decimal decVal;
                                decimal.TryParse(strGroupByValue_4, out decVal);
                                if (strFourthGroupBy == "Auto Liability - FROI #" || strFourthGroupBy == "DPD - FROI #" || strFourthGroupBy == "Premises Liability - FROI #" || strFourthGroupBy == "Property Damage -FROI #")
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;' >&nbsp;" + strFourthGroupBy + ": " + strGroupByValue_4 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                                else
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: green;' align='right'>&nbsp;" + strFourthGroupBy + ": " + string.Format("{0:c2}", decVal) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                            }
                            else if (strFormatFourthGroupBy == "datetime")
                            {
                                // it display only Time
                                if (strFourthGroupBy == "Time Theft Reported")
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: green;' >&nbsp;" + strFourthGroupBy + ": " + string.Format("{0:HH:mm}", Reader[strFourthGroupBy]) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                else sbRecord.Append("<tr><td style='font-weight: bold;color: green;' >&nbsp;" + strFourthGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_4) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                            }
                            else sbRecord.Append("<tr><td style='font-weight: bold;color: green;' >&nbsp;" + strFourthGroupBy + ": " + strGroupByValue_4 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                            strGroupByValue_5 = null;
                        }
                    }
                    #endregion
                    #region Fifth GroupBY
                    if (!string.IsNullOrEmpty(strFifthGroupBy))
                    {
                        int colcount = Reader.FieldCount;
                        if (strGroupByValue_5 != strCurrValue5)
                        {
                            strGroupByValue_5 = strCurrValue5;
                            if (strFormatFifthGroupBy == "decimal")
                            {
                                decimal decVal;
                                decimal.TryParse(strGroupByValue_5, out decVal);
                                if (strFifthGroupBy == "Auto Liability - FROI #" || strFifthGroupBy == "DPD - FROI #" || strFifthGroupBy == "Premises Liability - FROI #" || strFifthGroupBy == "Property Damage -FROI #")
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;color: #FF9C09;' >&nbsp;" + strFifthGroupBy + ": " + strGroupByValue_5 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                                else
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;' align='right' >&nbsp;" + strFifthGroupBy + ": " + string.Format("{0:c2}", decVal) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                }
                            }
                            else if (strFormatFifthGroupBy == "datetime")
                            {
                                // it display only Time
                                if (strFifthGroupBy == "Time Theft Reported")
                                    sbRecord.Append("<tr><td style='font-weight: bold;' >&nbsp;" + strFifthGroupBy + ": " + string.Format("{0:HH:mm}", Reader[strFifthGroupBy]) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                                else sbRecord.Append("<tr><td style='font-weight: bold;' >&nbsp;" + strFifthGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_5) + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                            }
                            else sbRecord.Append("<tr><td style='font-weight: bold;' >&nbsp;" + strFifthGroupBy + ": " + strGroupByValue_5 + "</td><td colspan='" + (colcount - groupByColumnCount) + "'></td></tr>");
                        }
                    }
                    #endregion
                    string strColumnName = string.Empty;
                    sbRecord.Append("<tr>");
                    if (IsGroupBySelected)
                        sbRecord.Append("<td>&nbsp;</td>");
                    ///Print Records
                    #region Print Records
                    for (int intColumn = 0; intColumn < dtSchema.Rows.Count; intColumn++)
                    {

                        #region " Count Sub Totals"
                        #region First : 1st
                        // if (!string.IsNullOrEmpty(strFirstGroupBy) && !string.IsNullOrEmpty(strGroupByValue_1))
                        if ((strFirstGroupBy != null) && (strGroupByValue_1 != null))
                        {
                            if (dtSubTotalFirstGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue1 == strGroupByValue_1)
                            {
                                if (dtSubTotalFirstGroup.Rows.Count == 0)
                                {
                                    dtSubTotalFirstGroup.Rows.Add(dtSubTotalFirstGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalFirstGroup.Columns)
                                        dtSubTotalFirstGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalFirstGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalFirstGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #region Second : 2nd
                        //if (!string.IsNullOrEmpty(strSecGroupBy) && !string.IsNullOrEmpty(strGroupByValue_2))
                        if ((strSecGroupBy != null) && (strGroupByValue_2 != null))
                        {
                            if (dtSubTotalSecondGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue2 == strGroupByValue_2)
                            {
                                if (dtSubTotalSecondGroup.Rows.Count == 0)
                                {
                                    dtSubTotalSecondGroup.Rows.Add(dtSubTotalSecondGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalSecondGroup.Columns)
                                        dtSubTotalSecondGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalSecondGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalSecondGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #region Third : 3nd
                        //if (!string.IsNullOrEmpty(strThirdGroupBy) && !string.IsNullOrEmpty(strGroupByValue_3))
                        if ((strThirdGroupBy != null) && (strGroupByValue_3 != null))
                        {
                            if (dtSubTotalThirdGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue3 == strGroupByValue_3)
                            {
                                if (dtSubTotalThirdGroup.Rows.Count == 0)
                                {
                                    dtSubTotalThirdGroup.Rows.Add(dtSubTotalThirdGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalThirdGroup.Columns)
                                        dtSubTotalThirdGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalThirdGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalThirdGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #region Fourth : 4th
                        //if (!string.IsNullOrEmpty(strFourthGroupBy) && !string.IsNullOrEmpty(strGroupByValue_4))
                        if ((strFourthGroupBy != null) && (strGroupByValue_4 != null))
                        {
                            if (dtSubTotalFourthGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue4 == strGroupByValue_4)
                            {
                                if (dtSubTotalFourthGroup.Rows.Count == 0)
                                {
                                    dtSubTotalFourthGroup.Rows.Add(dtSubTotalFourthGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalFourthGroup.Columns)
                                        dtSubTotalFourthGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalFourthGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalFourthGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #region Fifth : 5th
                        //if (!string.IsNullOrEmpty(strFifthGroupBy) && !string.IsNullOrEmpty(strGroupByValue_5))
                        if ((strFifthGroupBy != null) && (strGroupByValue_5 != null))
                        {
                            if (dtSubTotalFifthGroup.Columns.Contains(Reader.GetName(intColumn)) && strCurrValue5 == strGroupByValue_5)
                            {
                                if (dtSubTotalFifthGroup.Rows.Count == 0)
                                {
                                    dtSubTotalFifthGroup.Rows.Add(dtSubTotalFifthGroup.NewRow());
                                    foreach (DataColumn dcTotal in dtSubTotalFifthGroup.Columns)
                                        dtSubTotalFifthGroup.Rows[0][dcTotal] = 0;
                                }
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtSubTotalFifthGroup.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtSubTotalFifthGroup.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                        #endregion
                        //Remove Group By Column
                        #region
                        if (strFirstGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) && strSecGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) && strThirdGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) && strFourthGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) && strFifthGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]))
                        {
                            strFormat = dtSchema.Rows[intColumn]["DataTypeName"].ToString();

                            if (strFormat == "decimal")
                            {
                                // If dataType is Numeric but it is not Currency field.
                                if (CheckISdisplayCurrencyFormat(dtSchema.Rows[intColumn][0].ToString()))
                                {
                                    if (Reader[intColumn] != DBNull.Value)
                                    {
                                        sbRecord.Append("<td align='right'>" + string.Format("{0:c2}", Reader[intColumn]) + "</td>");
                                    }
                                    else sbRecord.Append("<td align='right'>" + string.Format("{0:c2}", 0) + "</td>");

                                }
                                else
                                    sbRecord.Append("<td align='right'>" + Convert.ToString(Reader[intColumn]) + "</td>");
                            }
                            else if (strFormat == "datetime")
                            {
                                // it display only Time
                                if (Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Time Theft Reported")
                                    sbRecord.Append("<td align='left'>" + string.Format("{0:HH:mm}", Reader[intColumn]) + "</td>");
                                else sbRecord.Append("<td align='left'>" + string.Format("{0:MM/dd/yyyy}", Reader[intColumn]) + "</td>");
                            }
                            else
                            {

                                sbRecord.Append(@"<td style='mso-number-format:\@;'>&nbsp;" + Convert.ToString(Reader[intColumn]) + "</td>");
                                //sbRecord.Append(@"<td>" + Convert.ToString(Reader[intColumn]) + "</td>");
                            }
                        }
                        #endregion
                        #region "Grand Total"
                        //IF Grand Total Option is Selected and Have Field for SUM.
                        if (chkGrandTotal.Checked && dtHeader.Columns.Count > 0)
                        {
                            if (dtHeader.Columns.Contains(Reader.GetName(intColumn)))
                            {
                                decimal decTotal = 0;
                                decTotal = Convert.ToDecimal(dtHeader.Rows[0][Reader.GetName(intColumn)]);
                                decTotal += Reader.IsDBNull(intColumn) ? 0 : Convert.ToDecimal(Reader[intColumn]);
                                dtHeader.Rows[0][Reader.GetName(intColumn)] = decTotal;
                            }
                        }
                        #endregion
                    }
                    sbRecord.Append("</tr>");
                    #endregion


                    using (StreamWriter sw = File.AppendText(strPath))
                    {
                        sw.Write(sbRecord);
                        sbRecord = new StringBuilder(string.Empty);
                    }

                } while (Reader.Read());

                #region " SUBTOAL FOR Last groups "
                if (dtSubTotalFifthGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    //if (IsGroupBySelected)
                    //    sbRecord.Append("<td>&nbsp;</td>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {
                        if (dtSubTotalFifthGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFifthGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                {
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strFifthGroupBy + "</b></td><td>&nbsp;</td>");
                                }
                                else
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strFifthGroupBy + "</b></td>");
                            }
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalFifthGroup.Clear();
                }
                if (dtSubTotalFourthGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    //if (IsGroupBySelected)
                    //    sbRecord.Append("<td>&nbsp;</td>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {
                        if (dtSubTotalFourthGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFourthGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                {
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strFourthGroupBy + "</b></td><td>&nbsp;</td>");
                                }
                                else
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strFourthGroupBy + "</b></td>");
                            }
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalFourthGroup.Clear();
                }
                if (dtSubTotalThirdGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    //if (IsGroupBySelected)
                    //    sbRecord.Append("<td>&nbsp;</td>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {
                        if (dtSubTotalThirdGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalThirdGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                {
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strThirdGroupBy + "</b></td><td>&nbsp;</td>");
                                }
                                else
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strThirdGroupBy + "</b></td>");
                            }
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalThirdGroup.Clear();
                }
                if (dtSubTotalSecondGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    //if (IsGroupBySelected)
                    //    sbRecord.Append("<td>&nbsp;</td>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {
                        if (dtSubTotalSecondGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalSecondGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                {
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strSecGroupBy + "</b></td><td>&nbsp;</td>");
                                }
                                else
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strSecGroupBy + "</b></td>");
                            }
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalSecondGroup.Clear();
                }
                if (dtSubTotalFirstGroup.Rows.Count > 0)
                {
                    sbRecord.Append("<tr>");
                    //if (IsGroupBySelected)
                    //    sbRecord.Append("<td>&nbsp;</td>");
                    int intCol = 1;
                    foreach (DataRow drSchema in dtSchema.Rows)
                    {
                        if (dtSubTotalFirstGroup.Columns.Contains(Convert.ToString(drSchema["ColumnName"])))
                            sbRecord.Append("<td align='right'><b>" + string.Format("{0:c2}", dtSubTotalFirstGroup.Rows[0][Convert.ToString(drSchema["ColumnName"])]) + "</b></td>");
                        else
                        {
                            if (intCol == 1)
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                {
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strFirstGroupBy + "</b></td><td>&nbsp;</td>");
                                }
                                else
                                    sbRecord.Append("<td align='left'><b>Sub Total For " + strFirstGroupBy + "</b></td>");
                            }
                            else
                            {
                                if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy && Convert.ToString(drSchema["ColumnName"]) != strThirdGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFourthGroupBy && Convert.ToString(drSchema["ColumnName"]) != strFifthGroupBy)
                                    sbRecord.Append("<td>&nbsp;</td>");
                            }
                        }
                        intCol++;
                    }
                    sbRecord.Append("</tr>");
                    dtSubTotalFirstGroup.Clear();
                }

                #endregion

                #endregion

                //Table End
                sbRecord.Append("</table>");

                #region "Footer Template"
                // IF Grand Total Option is Checked and Have record from Transaction Table to SUM
                if ((chkGrandTotal.Checked) && dtHeader.Columns.Count > 0)
                {
                    string strStyle = "'font-weight: bold;background-color: #507CD1;color: White;'";
                    sbRecord.Append("<br />");
                    sbRecord.Append("<table border='1' cellpadding='0' cellspacing='0'><tr align='right'>");
                    sbRecord.Append("<td style='font-weight: bold;' align='left'>Grand Totals</td>");

                    for (int intColumn = 0; intColumn < dtHeader.Columns.Count; intColumn++)
                        sbRecord.Append("<td style='font-weight: bold;'>" + Convert.ToString(dtHeader.Columns[intColumn]) + "</td>");

                    sbRecord.Append("</tr>");

                    sbRecord.Append("<tr align='right'>");
                    sbRecord.Append("<td style=" + strStyle + ">&nbsp;</td>");

                    for (int intColumn = 0; intColumn < dtHeader.Columns.Count; intColumn++)
                        sbRecord.Append("<td style=" + strStyle + ">" + string.Format("{0:c2}", dtHeader.Rows[0][intColumn]) + "</td>");

                    sbRecord.Append("</tr><table>");
                }
                #endregion
                //Remove White Space.
                //sbRecord.Replace("<tr></tr>", "");
                using (StreamWriter sw = File.AppendText(strPath))
                {
                    sw.Write(sbRecord);
                    sbRecord = new StringBuilder(string.Empty);
                }
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('No Data available for Selected Criteria');", true);

            if (!Reader.IsClosed)
                Reader.Close();
            return strPath;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (Reader != null)
            {
                Reader.Close();
                clsGeneral.DisposeOf(Reader);
            }
            clsGeneral.DisposeOf(lstAdhoc);
            clsGeneral.DisposeOf(dtSchema);
            clsGeneral.DisposeOf(dtHeader);
        }
    }

    /// <summary>
    /// Check This Header should be display in Currency format.
    /// </summary>
    /// <param name="strHeader"></param>
    /// <returns></returns>
    private bool CheckISdisplayCurrencyFormat(string strHeader)
    {
        //Array contains value have numeric field but should not display with $ sign,
        string strNumericField = "Location Code";
        string[] arrNumericField = strNumericField.Split(',');

        // if header is defiend numeric filed it return false
        for (int intI = 0; intI < arrNumericField.Length; intI++)
        {
            if (strHeader == arrNumericField[intI])
                return false;
        }
        return true;
    }

    /// <summary>
    /// Check Whether it is Grand TOtal FIeld or Not.
    /// </summary>
    /// <param name="strColumnName"></param>
    /// <returns></returns>
    private bool CheckTotalField(string strColumnName)
    {
        if ((strColumnName.Contains("Total Incurred") || strColumnName.Contains("Total Recovery") || strColumnName.Contains("Total Paid") || strColumnName.Contains("Total Reserve") ||
            strColumnName.Contains("Total Payment") || strColumnName.Contains("Total Outstanding")) || strColumnName.EndsWith("Paid")
            || (strColumnName.EndsWith("Payment") || strColumnName.EndsWith("Recovery") || strColumnName.EndsWith("Outstanding") || strColumnName.EndsWith("Reserve") ||
            strColumnName.EndsWith("Incurred"))
             &&
            (strColumnName.StartsWith("Claim") || strColumnName.StartsWith("Expense") || strColumnName.StartsWith("Medical")
            || strColumnName.StartsWith("Legal") || strColumnName.IndexOf("Indemnity") > -1 || strColumnName.IndexOf("Other Paid") > -1)
            || (strColumnName.ToUpper().Equals("AMOUNT DEMANDED") || strColumnName.ToUpper().Equals("FINE AMOUNT") || strColumnName.ToUpper().Equals("CLAIM OFFER 1")
            || strColumnName.ToUpper().Equals("CLAIM OFFER 2") || strColumnName.ToUpper().Equals("CLAIM OFFER 3") || strColumnName.ToUpper().Equals("CLAIM OFFER 4") || strColumnName.ToUpper().Equals("CLAIM OFFER 5")))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Get MajorCoverage By Assigned User Rights.
    /// </summary>
    /// <returns></returns>
    private string GetCoverage()
    {
        //string strWhere = string.Empty;
        //string strCov = GetSelectedCoverage();
        //string[] strCovA = strCov.Split(',');
        ////GetSelectedCoverage();

        ///*
        //* Logic to Bind Where condition only when User Right are set to Both (if is_Claim or Not)
        //*/

        //// Get User Rights from database based on Coverage Type
        //string strModulesHavingReports = "Auto Claims,Cargo Claims,PD Claims,Custom Bond Claims,Legal Claims,WC Claims,Security Incidents,Safety Incidents";
        //DataSet dsRight = Security.GetUserAccessForReportDistribution(Convert.ToDecimal(clsSession.UserID), strModulesHavingReports);
        //DataTable dtAccess = Security.GetUserAccessForAdHocReport(Convert.ToDecimal(clsSession.UserID)).Tables[0];
        //DataRow[] drFullAccess = dtAccess.Select("ModuleName = 'All'");

        ////if Have All Coverage Access
        //if (drFullAccess.Length > 0)
        //    strWhere = " And C.Major_Coverage in (" + strCov + ")";
        //else
        //{
        //    //Start Coverage Condition
        //    string strOp = string.Empty;
        //    for (int intI = 0; intI < strCovA.Length; intI++)
        //    {
        //        //Set "OR" Operator
        //        if (string.IsNullOrEmpty(strWhere))
        //            strOp = string.Empty;
        //        else
        //            strOp = " OR ";

        //        if (strCovA[intI].ToString() == ((int)clsGeneral.Claim_Major_Coverage.Auto).ToString())
        //        {
        //            if (dsRight.Tables[0].Rows.Count > 0)
        //            {
        //                bool IsRightClaim = dsRight.Tables[0].Select("Module_ID=1").Length > 0;
        //                bool IsRightSafety = dsRight.Tables[0].Select("Module_ID=9").Length > 0;

        //                //Have Auto and Safety Both Rights
        //                if (IsRightClaim && IsRightSafety)
        //                    strWhere += strOp + " (C.Major_Coverage = 30) ";
        //                // Have Auto Right But Not Safety
        //                else if (IsRightClaim)
        //                    strWhere += strOp + " (C.Major_Coverage = 30 And C.IS_Claim=1) ";
        //                //Have Safety Right but not Auto
        //                else if (IsRightSafety)
        //                    strWhere += strOp + " (C.Major_Coverage = 30 And C.IS_Claim=0) ";
        //            }
        //        }
        //        else if (strCovA[intI].ToString() == ((int)clsGeneral.Claim_Major_Coverage.Cargo).ToString())
        //        {
        //            bool IsClaim = dsRight.Tables[0].Select("Module_ID=2").Length > 0;
        //            bool IsSecurity = dsRight.Tables[0].Select("Module_ID=8").Length > 0;

        //            //Have Cargo and Security Both Rights
        //            if (IsClaim && IsSecurity)
        //                strWhere += strOp + " (C.Major_Coverage = 50) ";
        //            // Have Cargo Right But Not Security
        //            else if (IsClaim)
        //                strWhere += strOp + " (C.Major_Coverage = 50 And C.IS_Claim=1) ";
        //            //Have Security Right but not Cargo
        //            else if (IsSecurity)
        //                strWhere += strOp + " (C.Major_Coverage = 50 And C.IS_Claim=0) ";
        //        }
        //        else
        //            strWhere += strOp + " (C.Major_Coverage =" + strCovA[intI].ToString() + " ) ";
        //    }
        //    //End Coverage Condition
        //    strWhere = "And (" + strWhere + " )";
        //}
        //return strWhere;
        return "";
    }

    /***
    /// <summary>
    /// Sort Drop Down List Items
    /// </summary>
    /// <param name="objDDL"></param>
    private void SortListItem(ref ListBox objListItem)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();

        // Create List Item for Text value
        foreach (ListItem li in objListItem.Items)
        {
            textList.Add(li.Text);
        }
        // Sort Text Fields
        textList.Sort();

        // Create List Box based on sorted Text
        foreach (object item in textList)
        {
            string value = objListItem.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objListItem.Items.Clear();

        // Add Sorted Array to List Item
        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objListItem.Items.Add(objItem);
        }
    }

    /// <summary>
    /// Sort By Drop Down Values
    /// </summary>
    /// <param name="objDDL"></param>
    /// <param name="drps"></param>
    private void SortDDL(ref DropDownList objDDL, DropDownList[] drps)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


        foreach (ListItem li in objDDL.Items)
        {
            textList.Add(li.Text);
        }

        textList.Sort();


        foreach (object item in textList)
        {
            string value = objDDL.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objDDL.Items.Clear();

        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);

            foreach (DropDownList ddlFill in drps)
            {
                ddlFill.Items.Add(objItem);
            }
        }
    }
    **/



    #endregion

    #region "Save Report & Reload Report"

    /// <summary>
    /// Save AdHoc Report into database
    /// </summary>
    private void SaveReport()
    {
        string strType = GetSelectedCoverage();

        ERIMS.DAL.Management_AdHocReport objAdHocReport = new ERIMS.DAL.Management_AdHocReport();
        objAdHocReport.ReportName = txtReportName.Text.Trim();
        objAdHocReport.CoverageType = strType;

        if (drpGroupByFirst.SelectedIndex > 0)
        {
            objAdHocReport.FirstGroupBy = Convert.ToDecimal(drpGroupByFirst.SelectedValue);
            objAdHocReport.FirstGroupByOrder = rdblGroupSortByFirst.SelectedValue;
        }

        if (drpGroupBySecond.SelectedIndex > 0)
        {
            objAdHocReport.SecondGroupBy = Convert.ToDecimal(drpGroupBySecond.SelectedValue);
            objAdHocReport.SecondGroupByOrder = rdblGroupSortBySecond.SelectedValue;
        }

        if (drpGroupByThird.SelectedIndex > 0)
        {
            objAdHocReport.ThirdGroupBy = Convert.ToDecimal(drpGroupByThird.SelectedValue);
            objAdHocReport.ThirdGroupByOrder = rdblGroupSortByThird.SelectedValue;
        }

        if (drpGroupByFourth.SelectedIndex > 0)
        {
            objAdHocReport.FourthGroupBy = Convert.ToDecimal(drpGroupByFourth.SelectedValue);
            objAdHocReport.FourthGroupByOrder = rdblGroupSortByFourth.SelectedValue;
        }

        if (drpGroupByFifth.SelectedIndex > 0)
        {
            objAdHocReport.FifthGroupBy = Convert.ToDecimal(drpGroupByFifth.SelectedValue);
            objAdHocReport.FifthGroupByOrder = rdblGroupSortByFifth.SelectedValue;
        }

        if (drpSortingFirst.SelectedIndex > 0)
        {
            objAdHocReport.FirstSortBy = Convert.ToDecimal(drpSortingFirst.SelectedValue);
            objAdHocReport.FirstSortByOrder = rdbSort1.SelectedValue;
        }

        if (drpSortingSecond.SelectedIndex > 0)
        {
            objAdHocReport.SecondSortBy = Convert.ToDecimal(drpSortingSecond.SelectedValue);
            objAdHocReport.SecondSortByOrder = rdbSort2.SelectedValue;
        }

        if (drpSortingThird.SelectedIndex > 0)
        {
            objAdHocReport.ThirdSortBy = Convert.ToDecimal(drpSortingThird.SelectedValue);
            objAdHocReport.ThirdSortByOrder = rdbSort3.SelectedValue;
        }
        if (drpSortingFourth.SelectedIndex > 0)
        {
            objAdHocReport.FourthSortBy = Convert.ToDecimal(drpSortingFourth.SelectedValue);
            objAdHocReport.FourthSortByOrder = rdbSort4.SelectedValue;
        }
        if (drpSortingFifth.SelectedIndex > 0)
        {
            objAdHocReport.FifthSortBy = Convert.ToDecimal(drpSortingFifth.SelectedValue);
            objAdHocReport.FifthSortByOrder = rdbSort5.SelectedValue;
        }

        objAdHocReport.OutputFields = this.GetAllItemString(lstSelectedFields, false);

        if (ucRelativeDates_PriorVal.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
            objAdHocReport.PriorValuation_RelativeDate = Convert.ToString((int)(ucRelativeDates_PriorVal.RelativeDate));
        else
            objAdHocReport.PriorValuationDate = clsGeneral.FormatNullDateToStore(txtPriorDate.Text);

        objAdHocReport.GrandTotal = (chkGrandTotal.Checked) ? "Y" : "N";
        objAdHocReport.Updated_By = clsSession.UserName;
        objAdHocReport.Update_Date = System.DateTime.Now;
        decimal Pk_AdHocReport = 0;
        objAdHocReport.PK_Management_AdHocReport = hdnReportId.Value == string.Empty ? 0 : Convert.ToInt32(hdnReportId.Value);
        Pk_AdHocReport = objAdHocReport.PK_Management_AdHocReport.Value;

        if (hdnScheduleID.Value != "0")
            objAdHocReport.FK_Schedule = Convert.ToDecimal(hdnScheduleID.Value);

        if (objAdHocReport.PK_Management_AdHocReport.Value <= 0)
        {
            Pk_AdHocReport = objAdHocReport.Insert();
            hdnReportId.Value = Pk_AdHocReport.ToString();
        }
        else
            objAdHocReport.Update();

        // Bind Report Drop Down
        BindReportNameDropDown(strType);

        // get list item for Report Name
        ListItem liReport = ddlReports.Items.FindByValue(Pk_AdHocReport.ToString());

        // Set Selected Report Name in drop-down
        if (liReport != null)
        {
            ddlReports.ClearSelection();
            liReport.Selected = true;
            btnDeleteReport.Enabled = true;
        }

        if (Pk_AdHocReport > 0)
        {
            // Delete 
            ERIMS.DAL.Management_AdHocFilter.DeleteByFk_AdHocReport(Pk_AdHocReport);

            string strCriteria = string.Empty;
            strCriteria = GetFilterIDs(new DropDownList[] { drpFilter1, drpFilter2, drpFilter3, drpFilter4, drpFilter5, drpFilter6, drpFilter7, drpFilter8, drpFilter9, drpFilter10, });
            List<ERIMS.DAL.Management_AdhocReportFields> lstAdhoc = new List<Management_AdhocReportFields>();

            if (!string.IsNullOrEmpty(strCriteria))
                lstAdhoc = new ERIMS.DAL.Management_AdhocReportFields().GetAdHocReportFieldByMultipleID(strCriteria);

            decimal decValue;
            int iSelected;

            if (drpFilter1.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter1.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F1.SelectedValue, txtFilter1.Text, GetSelectedItemString(lst_F1, false), lstDate1.SelectedValue, txtDate_From1.Text, txtDate_To1.Text, drpAmount_F1.SelectedValue, txtAmount1_F1.Text, txtAmount2_F1.Text, ucRelativeDatesFrom_1.RelativeDate, ucRelativeDatesTo_1.RelativeDate, chkNotCriteria1);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter2.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter2.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F2.SelectedValue, txtFilter2.Text, GetSelectedItemString(lst_F2, false), lstDate2.SelectedValue, txtDate_From2.Text, txtDateTo2.Text, drpAmount_F2.SelectedValue, txtAmount1_F2.Text, txtAmount2_F2.Text, ucRelativeDatesFrom_2.RelativeDate, ucRelativeDatesTo_2.RelativeDate, chkNotCriteria2);
                // lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter3.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter3.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F3.SelectedValue, txtFilter3.Text, GetSelectedItemString(lst_F3, false), lstDate3.SelectedValue, txtDate_From3.Text, txtDate_To3.Text, drpAmount_F3.SelectedValue, txtAmount1_F3.Text, txtAmount2_F3.Text, ucRelativeDatesFrom_3.RelativeDate, ucRelativeDatesTo_3.RelativeDate, chkNotCriteria3);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter4.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter4.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F4.SelectedValue, txtFilter4.Text, GetSelectedItemString(lst_F4, false), lstDate4.SelectedValue, txtDate_From4.Text, txtDate_To4.Text, drpAmount_F4.SelectedValue, txtAmount1_F4.Text, txtAmount2_F4.Text, ucRelativeDatesFrom_4.RelativeDate, ucRelativeDatesTo_4.RelativeDate, chkNotCriteria4);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter5.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter5.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F5.SelectedValue, txtFilter5.Text, GetSelectedItemString(lst_F5, false), lstDate5.SelectedValue, txtDate_From5.Text, txtDate_To5.Text, drpAmount_F5.SelectedValue, txtAmount1_F5.Text, txtAmount2_F5.Text, ucRelativeDatesFrom_5.RelativeDate, ucRelativeDatesTo_5.RelativeDate, chkNotCriteria5);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter6.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter6.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F6.SelectedValue, txtFilter6.Text, GetSelectedItemString(lst_F6, false), lstDate6.SelectedValue, txtDate_From6.Text, txtDate_To6.Text, drpAmount_F6.SelectedValue, txtAmount1_F6.Text, txtAmount2_F6.Text, ucRelativeDatesFrom_6.RelativeDate, ucRelativeDatesTo_6.RelativeDate, chkNotCriteria6);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter7.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter7.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F7.SelectedValue, txtFilter7.Text, GetSelectedItemString(lst_F7, false), lstDate7.SelectedValue, txtDate_From7.Text, txtDate_To7.Text, txtAmount1_F7.Text, drpAmount_F7.SelectedValue, txtAmount2_F7.Text, ucRelativeDatesFrom_7.RelativeDate, ucRelativeDatesTo_7.RelativeDate, chkNotCriteria7);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter8.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter8.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F8.SelectedValue, txtFilter8.Text, GetSelectedItemString(lst_F8, false), lstDate8.SelectedValue, txtDate_From8.Text, txtDate_To8.Text, drpAmount_F8.SelectedValue, txtAmount1_F8.Text, txtAmount2_F8.Text, ucRelativeDatesFrom_8.RelativeDate, ucRelativeDatesTo_8.RelativeDate, chkNotCriteria8);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter9.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter9.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F9.SelectedValue, txtFilter9.Text, GetSelectedItemString(lst_F9, false), lstDate9.SelectedValue, txtDate_From9.Text, txtDate_To9.Text, drpAmount_F9.SelectedValue, txtAmount1_F9.Text, txtAmount2_F9.Text, ucRelativeDatesFrom_9.RelativeDate, ucRelativeDatesTo_9.RelativeDate, chkNotCriteria9);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter10.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter10.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].PK_Management_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F10.SelectedValue, txtFilter10.Text, GetSelectedItemString(lst_F10, false), lstDate10.SelectedValue, txtDate_From10.Text, txtDate_To10.Text, drpAmount_F10.SelectedValue, txtAmount1_F10.Text, txtAmount2_F10.Text, ucRelativeDatesFrom_10.RelativeDate, ucRelativeDatesTo_10.RelativeDate, chkNotCriteria10);
                //lstAdhoc.RemoveAt(iSelected);
            }
        }

        // Reset Scroll Position
        ResetScrollPosition();
    }

    /// <summary>
    /// save individual filter criteria for Saved AdHoc Report
    /// </summary>
    public void SaveFilterCriteria(decimal Fk_AdHocReport, decimal FK_AdHocReportFields, decimal Fk_ControlType, string FitlerText, string TextWhere, string ListFilterWhere,
                                         string ListDate, string Date_From, string Date_To, string AmountWhere, string Amount1, string Amount2, AdHocReportHelper.RaltiveDates relativeFrom, AdHocReportHelper.RaltiveDates relativeTo, CheckBox chkNotSelected)
    {
        ERIMS.DAL.Management_AdHocFilter objFilter = new Management_AdHocFilter();
        objFilter.FK_Management_AdHocReport = Fk_AdHocReport;
        objFilter.FK_Management_AdhocReportFields = FK_AdHocReportFields;

        ///Relative Date
        if (Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
        {
            objFilter.ConditionType = FitlerText;
            objFilter.ConditionValue = TextWhere.Trim();
        }

        else if (Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
        {
            objFilter.ConditionValue = ListFilterWhere;
        }

        else if (Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
        {
            objFilter.ConditionType = ListDate;

            if (relativeFrom == AdHocReportHelper.RaltiveDates.NotSet)
                objFilter.FromDate = clsGeneral.FormatNullDateToStore(Date_From);
            else objFilter.FromRelativeCriteria = Convert.ToString((int)(relativeFrom));
            if (ListDate == "B")
            {
                if (relativeTo == AdHocReportHelper.RaltiveDates.NotSet)
                    objFilter.ToDate = clsGeneral.FormatNullDateToStore(Date_To);
                else objFilter.ToRelativeCriteria = Convert.ToString((int)(relativeTo));
            }
        }

        else if (Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
        {
            objFilter.ConditionType = AmountWhere;

            if (Amount1 != string.Empty)
                objFilter.AmountFrom = Convert.ToDecimal(Amount1);

            if (Amount2 != string.Empty && AmountWhere == ((int)AdHocReportHelper.AmountCriteria.Between).ToString())
                objFilter.AmountTo = Convert.ToDecimal(Amount2);
        }
        objFilter.IsNotSelected = chkNotSelected.Checked;
        objFilter.Insert();
    }

    /// <summary>
    /// Set Selected Value for AdHoc Report Filter
    /// </summary>
    /// <param name="objFilter"></param>
    /// <param name="drpFilter"></param>
    private void LoadFilterCriteria(ERIMS.DAL.Management_AdHocFilter objFilter, DropDownList drpFilter)
    {
        ListItem liSelected;

        // Check if Fk is not null
        if (objFilter.FK_Management_AdhocReportFields.HasValue)
        {
            drpFilter.ClearSelection();
            // Find a value and then set it to selected
            liSelected = drpFilter.Items.FindByValue(objFilter.FK_Management_AdhocReportFields.ToString());

            if (liSelected != null)
                liSelected.Selected = true;
        }
    }

    private void LoadCheckBoxNotCriteria(ERIMS.DAL.Management_AdHocFilter objFilter, CheckBox chkNotSelectd)
    {
        chkNotSelectd.Checked = objFilter.IsNotSelected;
    }


    /// <summary>
    /// Fill Drop Down based on selected Filter Criteria
    /// </summary>
    private void LoadFilterControlDropDown(string Field_Header, string ConditionValue, ListBox lst_F)
    {
        lst_F.Items.Clear();

        if (Field_Header == "DBA")
        {
            //ComboHelper.FillLocation(new ListBox[] { lst_F }, false);
            ComboHelper.FillLocationDBA_All(new ListBox[] { lst_F }, 0, false);
        }
        else if (Field_Header == "Work to Be Completed")
        {
            ComboHelper.FillWork_Completed(new ListBox[] { lst_F }, 0, false);
        }
        else if (Field_Header == "Work to Be Completed By")
        {
            ComboHelper.FillWork_Completed_By(new ListBox[] { lst_F },0, false);
        }
        else if (Field_Header == "Task Complete")
        {
            ComboHelper.FillTaskComplete(new ListBox[] { lst_F }, false);
        }
        else if (Field_Header == "Record Type")
        {
            ComboHelper.FillRecord_Type(new ListBox[] { lst_F }, 0, false);
        }
        else if (Field_Header == "Project Phase")
        {
            ComboHelper.FillEPM_Project_Phase(new ListBox[] { lst_F }, 0, false);
        }
        else if (Field_Header == "GM Decision" || Field_Header == "RLCM Decision" || Field_Header == "NAPM Decision" || Field_Header == "DRM Decision")
        {
            ComboHelper.FillManagementByDecision(new ListBox[] { lst_F }, false);
        }
        else if (Field_Header == "Vendor State")
        {
            ComboHelper.FillStateList(new ListBox[] { lst_F }, false);
        }
        else if (Field_Header.ToUpper() == "APPROVAL SUBMISSION")
        {
            ComboHelper.FillApproval_Submission(new ListBox[] { lst_F }, false);
            #region " To check Null value #Issue 3420 "
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("None", "0"));
            for (int i = 0; i < liItem.Count; i++)
            {
                lst_F.Items.Add((ListItem)liItem[i]);
            }
            #endregion
        }
        else if (Field_Header.ToUpper() == "RPM APPROVAL")
        {
            ComboHelper.FillTaskComplete(new ListBox[] { lst_F }, false);
        }
        else if (Field_Header.ToUpper() == "STATUS")
        {
            ComboHelper.FillMaintenanceStatusList(new ListBox[] {lst_F},false);
        }
        else
        {
            AdHocReportHelper.FillFilterDropDown(Field_Header, new ListBox[] { lst_F }, false, GetSelectedCoverage());
        }

        //Set ListBox ToolTip
        clsGeneral.SetListBoxToolTip(new ListBox[] { lst_F });
        // Set Selected Value for Filter Criteria
        SetSelectedValueFromString(ConditionValue, lst_F);
        lst_F.Visible = true;
    }

    /// <summary>
    /// Bind Textbox Control From Database
    /// </summary>
    /// <param name="ConditionType"></param>
    /// <param name="ConditionValue"></param>
    /// <param name="pnlText_F"></param>
    /// <param name="txtFilter"></param>
    /// <param name="drpText"></param>
    private void LoadFilterControlText(string ConditionType, string ConditionValue, Panel pnlText_F, TextBox txtFilter, DropDownList drpText)
    {
        ListItem liSelected;
        // Show Textbox panel
        pnlText_F.Visible = true;
        txtFilter.Text = ConditionValue;

        // find textbox Drop Down Value
        if (!string.IsNullOrEmpty(ConditionType))
        {
            drpText.ClearSelection();
            liSelected = drpText.Items.FindByValue(ConditionType);

            if (liSelected != null)
                liSelected.Selected = true;
        }
    }

    /// <summary>
    /// Bind Amount Fields from database
    /// </summary>
    private void LoadFilterControlAmount(ERIMS.DAL.Management_AdHocFilter objFilter, Panel pnlAmount_F, DropDownList drpAmount_F, TextBox txtAmount1_F, TextBox txtAmount2_F, Label lblAmountText1_F, Label lblAmountText2_F, CompareValidator cvAmount)
    {
        ListItem liSelected = drpAmount_F.Items.FindByValue(objFilter.ConditionType);
        // Show Amount Panel
        pnlAmount_F.Visible = true;

        if (liSelected != null)
        {
            drpAmount_F.ClearSelection();
            liSelected.Selected = true;
        }

        // Set Drop Down value and Text values
        drpAmount_Changed(true, drpAmount_F, lblAmountText1_F, txtAmount1_F, lblAmountText2_F, txtAmount2_F, cvAmount);
        txtAmount1_F.Text = string.Format("{0:N2}", objFilter.AmountFrom);
        txtAmount2_F.Text = string.Format("{0:N2}", objFilter.AmountTo);
    }

    /// <summary>
    /// Bind Date Filter Criteria from database
    /// </summary>
    private void LoadFilterControlDate(ERIMS.DAL.Management_AdHocFilter objFilter, Panel pnlDate_F, DropDownList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2, HtmlImage img2, RegularExpressionValidator revDateTo, ASP.controls_relativedate_relativedate_ascx ucRelativeDatesFrom, ASP.controls_relativedate_relativedate_ascx ucRelativeDatesTo, HtmlImage img1)
    {

        ListItem liSelected = rdbCommon.Items.FindByValue(objFilter.ConditionType);
        // Show date Criteria
        pnlDate_F.Visible = true;

        if (liSelected != null)
        {
            rdbCommon.ClearSelection();
            liSelected.Selected = true;
            rdbLstDate_SelectedIndexChanged(rdbCommon, null);//Set Date Selected Dropdown
        }

        // Set Relative or Absulute Date criteria
        if (string.IsNullOrEmpty(objFilter.FromRelativeCriteria))
            txt1.Text = clsGeneral.FormatDBNullDateToDisplay(objFilter.FromDate);
        else
        {
            // set Relative Date From criteria
            AdHocReportHelper.RaltiveDates RelType = (AdHocReportHelper.RaltiveDates)Enum.Parse(typeof(AdHocReportHelper.RaltiveDates), objFilter.FromRelativeCriteria);
            txt1.Text = AdHocReportHelper.GetRelativeDate(RelType).ToString(AppConfig.DisplayDateFormat);
            ucRelativeDatesFrom.RelativeDate = RelType;
            ucRelativeDatesFrom.strDateClientID = txt1.ClientID;
        }
        if (string.IsNullOrEmpty(objFilter.ToRelativeCriteria))
            txt2.Text = clsGeneral.FormatDBNullDateToDisplay(objFilter.ToDate);
        else
        {
            // set Relative Date To criteria
            AdHocReportHelper.RaltiveDates RelType = (AdHocReportHelper.RaltiveDates)Enum.Parse(typeof(AdHocReportHelper.RaltiveDates), objFilter.ToRelativeCriteria);
            txt2.Text = AdHocReportHelper.GetRelativeDate(RelType).ToString(AppConfig.DisplayDateFormat);
            ucRelativeDatesTo.RelativeDate = RelType;
            ucRelativeDatesTo.strDateClientID = txt2.ClientID;
        }
        img1.Attributes.Add("onclick", "return showCalendar('" + txt1.ClientID + "', 'mm/dd/y','','')");//Set From Image Attribute
        SetDateControls(lstDate1, lblDateFrom1, lblDateTo1, txtDate_From1, txtDate_To1, imgDate_To1, revtxtDate_From1, ucRelativeDatesTo_1);
    }

    /// <summary>
    /// Set Selected Values in ListBox 
    /// </summary>
    /// <param name="CSValue"></param>
    /// <param name="lstSelect"></param>
    private void SetSelectedValueFromString(string CSValue, ListBox lstSelect)
    {
        if (!string.IsNullOrEmpty(CSValue))
        {
            string[] strSelectedValues = CSValue.Split(',');

            ListItem li;

            foreach (string strSelect in strSelectedValues)
            {
                li = lstSelect.Items.FindByValue(strSelect);

                if (li != null)
                    li.Selected = true;
            }
        }
    }


    /// <summary>
    /// Remove Selected Values from ListBox 
    /// </summary>
    /// <param name="CSValue"></param>
    /// <param name="lstSelect"></param>
    private void RemoveSelectedItem(string CSValue)
    {
        if (!string.IsNullOrEmpty(CSValue))
        {
            string[] strSelectedValues = CSValue.Split(',');

            ListItem li = null;

            // Loop for Selected Output list
            foreach (string strSelect in strSelectedValues)
            {
                li = lstOutputFields.Items.FindByValue(strSelect);

                if (li != null)
                {
                    // remove List item from  Output List
                    lstOutputFields.Items.Remove(new ListItem(li.Text, li.Value));
                    // Add List item To Selected Output List, Filter Criteria and Sort Criteria
                    lstSelectedFields.Items.Add(new ListItem(li.Text, li.Value));
                    drpGroupByFirst.Items.Add(new ListItem(li.Text, li.Value));
                    drpGroupBySecond.Items.Add(new ListItem(li.Text, li.Value));

                    drpGroupByThird.Items.Add(new ListItem(li.Text, li.Value));
                    drpGroupByFourth.Items.Add(new ListItem(li.Text, li.Value));
                    drpGroupByFifth.Items.Add(new ListItem(li.Text, li.Value));

                    drpSortingFirst.Items.Add(new ListItem(li.Text, li.Value));
                    drpSortingSecond.Items.Add(new ListItem(li.Text, li.Value));
                    drpSortingThird.Items.Add(new ListItem(li.Text, li.Value));

                    drpSortingFourth.Items.Add(new ListItem(li.Text, li.Value));
                    drpSortingFifth.Items.Add(new ListItem(li.Text, li.Value));

                    if (li.Value == "10")
                    {
                        //Accident Year Add
                        //  drpGroupByFirst.Items.Add(new ListItem("Accident Year", "-2"));
                        //  drpGroupBySecond.Items.Add(new ListItem("Accident Year", "-3"));
                    }
                }
            }

            //// Add First Element as --Select--
            //drpGroupByFirst.Items.Insert(0, new ListItem("--Select--", "0"));
            //drpGroupBySecond.Items.Insert(0, new ListItem("--Select--", "-1"));
            //drpSortingFirst.Items.Insert(0, new ListItem("--Select--", "0"));
            //drpSortingSecond.Items.Insert(0, new ListItem("--Select--", "-1"));
            //drpSortingThird.Items.Insert(0, new ListItem("--Select--", "-2"));

            // Clear all Filter and Sort By Drop Down
            drpGroupByFirst.ClearSelection();
            drpGroupBySecond.ClearSelection();

            drpGroupByThird.ClearSelection();
            drpGroupByFourth.ClearSelection();
            drpGroupByFifth.ClearSelection();

            drpSortingFirst.ClearSelection();
            drpSortingSecond.ClearSelection();
            drpSortingThird.ClearSelection();
            drpSortingFourth.ClearSelection();
            drpSortingFifth.ClearSelection();
        }
    }

    /// <summary>
    /// Set Group By and filter By options
    /// </summary>
    /// <param name="SelectedValue"></param>
    /// <param name="drpGroupBy"></param>
    /// <param name="rdblSortBy"></param>
    /// <param name="SortByOrder"></param>
    private void SetGroupFilterByControl(decimal? SelectedValue, DropDownList drpGroupBy, RadioButtonList rdblSortBy, string SortByOrder)
    {
        ListItem liSelected = null;

        // set First Group By Option
        if (SelectedValue.HasValue)
        {
            liSelected = drpGroupBy.Items.FindByValue(Convert.ToString(SelectedValue));

            if (liSelected != null)
            {
                drpGroupBy.ClearSelection();
                liSelected.Selected = true;
                rdblSortBy.ClearSelection();
                rdblSortBy.SelectedValue = SortByOrder;
            }
        }
    }

    /// <summary>
    ///  Get Coverage Values for Adhoc Reprot Criteria
    /// </summary>
    /// <returns></returns>
    private string GetSelectedCoverage()
    {
        /*
         * Get Comma saperated Selected Coverage Values
         * If none of coverage is selected then return all coverage         
         */

        string strCoverage = string.Empty;
        // get selected Coverage
        foreach (ListItem li in rblCoverage.Items)
        {
            if (li.Selected)
                strCoverage += li.Value + ",";
        }

        // if Coverage is not selected then return All coverages
        if (strCoverage == string.Empty)
        {
            foreach (ListItem listitem in rblCoverage.Items)
                strCoverage = strCoverage + "," + listitem.Value;
        }

        if (strCoverage.EndsWith(","))
            strCoverage = strCoverage.TrimEnd(',');

        if (strCoverage.StartsWith(","))
            strCoverage = strCoverage.TrimStart(',');

        return strCoverage;
    }

    /// <summary>
    /// Reset Scroll Position
    /// </summary>
    private void ResetScrollPosition()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "CreateResetScrollPosition"))
        {

            //Create the ResetScrollPosition() function
            ClientScript.RegisterClientScriptBlock(this.GetType(), "CreateResetScrollPosition", "function ResetScrollPosition() {" + System.Environment.NewLine +
                " var scrollX = document.getElementById('__SCROLLPOSITIONX');" + System.Environment.NewLine +
                " var scrollY = document.getElementById('__SCROLLPOSITIONY');" + System.Environment.NewLine +
                " if (scrollX && scrollY) {" + System.Environment.NewLine +
                //" scrollX.value = 0;" + System.Environment.NewLine + 
                //" scrollY.value = 0;" + System.Environment.NewLine + 
                " scrollTo(scrollX.value,scrollY.value) " + System.Environment.NewLine +
                " }" + System.Environment.NewLine
                + "}", true);

            //Add the call to the ResetScrollPosition() function
            ClientScript.RegisterStartupScript(this.GetType(), "CallResetScrollPosition", "ResetScrollPosition();", true);
        }
    }

    #endregion

    #region " Filters "

    /// <summary>
    /// Bind and Return Where Condition for Display filters in Header
    /// </summary>
    /// <returns></returns>
    public string GetSelectedFilters(DropDownList drpFilter, DropDownList drpText_F, TextBox txtFilter, ListBox lst_F, DropDownList lstDate, TextBox txtDate_From, TextBox txtDate_To, DropDownList drpAmount_F, TextBox txtAmount1_F, TextBox txtAmount2_F, CheckBox chkNotCriteria)
    {
        List<ERIMS.DAL.Management_AdhocReportFields> lstAdhoc = null;
        decimal decValue;
        int iSelected;
        string strWhere = string.Empty, strFilterIds = string.Empty, strGroupBy = string.Empty, strOrderBy = string.Empty, strCriteria = string.Empty, strPath = string.Empty;

        strCriteria = GetFilterIDs(new DropDownList[] { drpFilter });

        if (!string.IsNullOrEmpty(strCriteria))
            lstAdhoc = new ERIMS.DAL.Management_AdhocReportFields().GetAdHocReportFieldByMultipleID(strCriteria);

        if (drpFilter.SelectedIndex > 0)
        {
            decValue = Convert.ToDecimal(drpFilter.SelectedItem.Value);
            strFilterIds = Convert.ToString(drpFilter.SelectedItem.Text);
            iSelected = SearchList(decValue, lstAdhoc);
            if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
            {
                int drpIndex = Convert.ToInt16(drpText_F.SelectedItem.Value);
                if (chkNotCriteria.Checked == true)
                    strWhere = (drpIndex == 1) ? " Not Contains " : (drpIndex == 2 ? " Not Start With " : " Not End With ");
                else
                    strWhere = (drpIndex == 1) ? " Contains " : (drpIndex == 2 ? " Start With " : " End With ");
                strWhere = "<b>" + strFilterIds + " :</b>  " + strWhere + txtFilter.Text.Trim();
            }
            else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
            {
                if (chkNotCriteria.Checked == true)
                    strWhere = "<b>" + strFilterIds + " (Not In) :</b>  " + GetSelectedItemTextString(lst_F);
                else
                    strWhere = "<b>" + strFilterIds + " (In) :</b>  " + GetSelectedItemTextString(lst_F);
            }
            else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
            {
                string strConditionType = lstDate.SelectedItem.Value;
                strWhere = (strConditionType == "O") ? " On " : (strConditionType == "B" ? " Between " : (strConditionType == "BF" ? "On or Before " : (strConditionType == "IN" ? " IS NULL " : "On or  After ")));
                string dtFrom = null, dtTo = null;
                dtFrom = clsGeneral.FormatDBNullDateToDisplay(txtDate_From.Text);
                dtTo = clsGeneral.FormatDBNullDateToDisplay(txtDate_To.Text);

                if (chkNotCriteria.Checked == true)
                    strWhere = "Not" + strWhere;

                if (strWhere.Trim() != "Between" && strWhere.Trim() != "Not Between" && strConditionType == "IN")
                    strWhere = "<b>" + strFilterIds + " : </b>" + strWhere ;
                else if (strWhere.Trim() != "Between" && strWhere.Trim() != "Not Between")
                    strWhere = "<b>" + strFilterIds + " : </b>" + strWhere + "  " + dtFrom;
                else
                    strWhere = "<b>" + strFilterIds + " : </b>" + strWhere + " " + dtFrom + " And " + dtTo;

            }
            else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
            {
                string strConditionType = drpAmount_F.SelectedItem.Value;
                strWhere = (strConditionType == "0") ? " Equal " : (strConditionType == "1" ? " Greater Than " : (strConditionType == "2" ? " Between " : " Less Than "));

                if (chkNotCriteria.Checked == true)
                    strWhere = "Not" + strWhere;

                if (strWhere.Trim() != "Between" && strWhere.Trim() != "Not Between")
                    strWhere = "<b>" + strFilterIds + " : </b>" + strWhere + " " + Convert.ToString(txtAmount1_F.Text);
                else
                    strWhere = "<b>" + strFilterIds + " : </b>" + strWhere + " " + Convert.ToString(txtAmount1_F.Text) + " And " + Convert.ToString(txtAmount2_F.Text);
            }

            strWhere = "<tr><td >" + strWhere + "</td></tr>";
        }
        return strWhere;
    }

    /// <summary>
    /// return Comma saperated list of all selected item in listbox
    /// </summary>
    /// <param name="lstBox"></param>
    /// <returns></returns>
    public string GetSelectedItemTextString(ListBox lstBox)
    {
        string strValues = "";
        foreach (ListItem lstBoxItem in lstBox.Items)
        {
            if (lstBoxItem.Selected)
            {
                strValues = strValues + lstBoxItem.Text.Replace("'", "''") + ", ";
            }
        }
        return strValues.Trim().TrimEnd(',');
    }

    ///// <summary>
    ///// Search List ITem from list object
    ///// </summary>
    ///// <param name="decValue"></param>
    ///// <param name="lstSearch"></param>
    ///// <returns></returns>
    //private int SearchList(decimal decValue, List<ERIMS.DAL.ClaimReportFields> lstSearch)
    //{
    //    int i;
    //    for (i = 0; i < lstSearch.Count; i++)
    //    {
    //        if (lstSearch[i].Pk_ClaimReportFields.Value == decValue)
    //            return i;
    //    }
    //    return 0;
    //}

    //Bind AdHoc Report Edit Mode
    private void BindAdHocReportEdit()
    {
        DataSet dsScheduler = ERIMS.DAL.Management_AdHocFilter.SelectByAdHocReportScheduler(PK_Schedule, ReportId);
        if (dsScheduler != null && dsScheduler.Tables.Count > 0 && dsScheduler.Tables[0].Rows.Count > 0)
        {
            DataRow drScheduler = dsScheduler.Tables[0].Rows[0];
            if (drScheduler["PK_Management_AdHocReport"] == DBNull.Value)
                hdnScheduleID.Value = "0";
            else
                hdnScheduleID.Value = Convert.ToString(drScheduler["FK_Schedule"]);

            if (drScheduler["CoverageType"] == DBNull.Value)
                strAccessibleClaimTypes = "10,20,30,40,50,70,100";
            else
                strAccessibleClaimTypes = (Convert.ToString(drScheduler["CoverageType"]));
            //Get Selected Claim Type
            if (strAccessibleClaimTypes == "30,50,100,20,70,40,10") { }
            else
            {
                SetSelectedValueFromString(strAccessibleClaimTypes, rblCoverage);
            }
            decimal Pk_AdHocReport;
            decimal? _dcSelectedReport = null;
            if (drScheduler["PK_Management_AdHocReport"] == DBNull.Value)
                Pk_AdHocReport = -1;
            else
                Pk_AdHocReport = Convert.ToDecimal(drScheduler["PK_Management_AdHocReport"]);
            string strType = GetSelectedCoverage();
            SetDefaults(strType);
            BindReportNameDropDown(strType);
            // get list item for Report Name
            ListItem liReport = ddlReports.Items.FindByValue(Pk_AdHocReport.ToString());
            // Set Selected Report Name in drop-down
            if (liReport != null)
            {
                ddlReports.ClearSelection();
                liReport.Selected = true;
                btnDeleteReport.Enabled = true;
            }
            if (drScheduler["Fk_RecipientList"] == DBNull.Value)
            {
                ddlRecipientList.SelectedIndex = 0;
            }
            else
            {
                ddlRecipientList.SelectedValue = Convert.ToString(drScheduler["Fk_RecipientList"]);
            }
            _dcSelectedReport = 0;
            List<ERIMS.DAL.Management_AdHocFilter> lstFilter = new List<Management_AdHocFilter>();
            _dcSelectedReport = Pk_AdHocReport;
            lstFilter = new ERIMS.DAL.Management_AdHocFilter().GetAdHocReportFieldByPk(Pk_AdHocReport);
            ERIMS.DAL.Management_AdHocReport ObjAdHocReport = new ERIMS.DAL.Management_AdHocReport(Pk_AdHocReport);
            // Clear All Panels to bank
            ClearAllFilterPanel();
            // Clear All Control
            ClearControls();
            // Reset Scroll Position
            ResetScrollPosition();
            // Bind Output fileds
            BindOutpuFields(GetSelectedCoverage());
            // Remove Selected Output fields from Report Ouput List
            RemoveSelectedItem(ObjAdHocReport.OutputFields);
            // Set Control from database
            if (!string.IsNullOrEmpty(ObjAdHocReport.PriorValuation_RelativeDate))
            {
                // set Relative Date From criteria
                AdHocReportHelper.RaltiveDates RelType = (AdHocReportHelper.RaltiveDates)Enum.Parse(typeof(AdHocReportHelper.RaltiveDates), ObjAdHocReport.PriorValuation_RelativeDate);
                txtPriorDate.Text = AdHocReportHelper.GetRelativeDate(RelType).ToString(AppConfig.DisplayDateFormat);
                ucRelativeDates_PriorVal.RelativeDate = RelType;
                ucRelativeDates_PriorVal.strDateClientID = txtPriorDate.ClientID;
                SetRelativeDateControl(txtPriorDate, imgPriorValuationDate, true);
            }
            else
                txtPriorDate.Text = clsGeneral.FormatDBNullDateToDisplay(ObjAdHocReport.PriorValuationDate);
            chkGrandTotal.Checked = ObjAdHocReport.GrandTotal == "Y";
            SetGroupFilterByControl(ObjAdHocReport.FirstGroupBy, drpGroupByFirst, rdblGroupSortByFirst, ObjAdHocReport.FirstGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.SecondGroupBy, drpGroupBySecond, rdblGroupSortBySecond, ObjAdHocReport.SecondGroupByOrder);

            SetGroupFilterByControl(ObjAdHocReport.ThirdGroupBy, drpGroupByThird, rdblGroupSortByThird, ObjAdHocReport.ThirdGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.FourthGroupBy, drpGroupByFourth, rdblGroupSortByFourth, ObjAdHocReport.FourthGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.FifthGroupBy, drpGroupByFifth, rdblGroupSortByFifth, ObjAdHocReport.FifthGroupByOrder);


            SetGroupFilterByControl(ObjAdHocReport.FirstSortBy, drpSortingFirst, rdbSort1, ObjAdHocReport.FirstSortByOrder);
            SetGroupFilterByControl(ObjAdHocReport.SecondSortBy, drpSortingSecond, rdbSort2, ObjAdHocReport.SecondSortByOrder);
            SetGroupFilterByControl(ObjAdHocReport.ThirdSortBy, drpSortingThird, rdbSort3, ObjAdHocReport.ThirdSortByOrder);

            SetGroupFilterByControl(ObjAdHocReport.FourthSortBy, drpSortingFourth, rdbSort4, ObjAdHocReport.FourthSortByOrder);
            SetGroupFilterByControl(ObjAdHocReport.FifthSortBy, drpSortingFifth, rdbSort5, ObjAdHocReport.FifthSortByOrder);

            if (ddlReports.SelectedItem.Text.Trim() == "---Select---")
            {
                txtReportName.Text = "";
            }
            else
            {
                txtReportName.Text = ddlReports.SelectedItem.Text.Trim();
            }
            btnDeleteReport.Enabled = true;

            // Chekc if AdHoc Filter Criteria is exists or not
            if (lstFilter.Count > 0)
            {
                for (int i = 0; i < lstFilter.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            // Set Filter Drop Down
                            chkNotCriteria1.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter1);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria1);
                            // Set Text value Criteria
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F1, txtFilter1, drpText_F1);
                            // Set Multi Selection listBox Criteria
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F1);
                            // Set Amount field Criteria
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F1, drpAmount_F1, txtAmount1_F1, txtAmount2_F1, lblAmountText1_F1, lblAmountText2_F1, cvAmount1);
                            // Set Date Control Filter Criteria
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F1, lstDate1, lblDateFrom1, lblDateTo1, txtDate_From1, txtDate_To1, imgDate_To1, revtxtDate_From1, ucRelativeDatesFrom_1, ucRelativeDatesTo_1, imgDate_Opened_From1);
                            break;
                        case 1:
                            chkNotCriteria2.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter2);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria2);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F2, txtFilter2, drpText_F2);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F2);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F2, drpAmount_F2, txtAmount1_F2, txtAmount2_F2, lblAmountText1_F2, lblAmountText2_F2, cvAmount2);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F2, lstDate2, lblDateFrom2, lblDateTo2, txtDate_From2, txtDateTo2, imgDate_To2, revtxtDate_From2, ucRelativeDatesFrom_2, ucRelativeDatesTo_2, imgDate_Opened_From2);
                            break;
                        case 2:
                            chkNotCriteria3.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter3);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria3);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F3, txtFilter3, drpText_F3);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F3);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F3, drpAmount_F3, txtAmount1_F3, txtAmount2_F3, lblAmountText1_F3, lblAmountText2_F3, cvAmount3);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F3, lstDate3, lblDateFrom3, lblDateTo3, txtDate_From3, txtDate_To3, imgDate_To3, revtxtDate_From3, ucRelativeDatesFrom_3, ucRelativeDatesTo_3, imgDate_Opened_From3);
                            break;
                        case 3:
                            chkNotCriteria4.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter4);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria4);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F4, txtFilter4, drpText_F4);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F4);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F4, drpAmount_F4, txtAmount1_F4, txtAmount2_F4, lblAmountText1_F4, lblAmountText2_F4, cvAmount4);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F4, lstDate4, lblDateFrom4, lblDateTo4, txtDate_From4, txtDate_To4, imgDate_To4, revtxtDate_From4, ucRelativeDatesFrom_4, ucRelativeDatesTo_4, imgDate_Opened_From4);
                            break;
                        case 4:
                            chkNotCriteria5.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter5);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria5);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F5, txtFilter5, drpText_F5);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F5);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F5, drpAmount_F5, txtAmount1_F5, txtAmount2_F5, lblAmountText1_F5, lblAmountText2_F5, cvAmount5);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F5, lstDate5, lblDateFrom5, lblDateTo5, txtDate_From5, txtDate_To5, imgDate_To5, revtxtDate_From5, ucRelativeDatesFrom_5, ucRelativeDatesTo_5, imgDate_Opened_From5);
                            break;
                        case 5:
                            chkNotCriteria6.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter6);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria6);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F6, txtFilter6, drpText_F6);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F6);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F6, drpAmount_F6, txtAmount1_F6, txtAmount2_F6, lblAmountText1_F6, lblAmountText2_F6, cvAmount6);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F6, lstDate6, lblDateFrom6, lblDateTo6, txtDate_From6, txtDate_To6, imgDate_To6, revtxtDate_From6, ucRelativeDatesFrom_6, ucRelativeDatesTo_6, imgDate_Opened_From6);
                            break;
                        case 6:
                            chkNotCriteria7.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter7);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria7);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F7, txtFilter7, drpText_F7);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F7);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F7, drpAmount_F7, txtAmount1_F7, txtAmount2_F7, lblAmountText1_F7, lblAmountText2_F7, cvAmount7);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F7, lstDate7, lblDateFrom7, lblDateTo7, txtDate_From7, txtDate_To7, imgDate_To7, revtxtDate_From7, ucRelativeDatesFrom_7, ucRelativeDatesTo_7, imgDate_Opened_From7);
                            break;
                        case 7:
                            chkNotCriteria8.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter8);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria8);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F8, txtFilter8, drpText_F8);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F8);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F8, drpAmount_F8, txtAmount1_F8, txtAmount2_F8, lblAmountText1_F8, lblAmountText2_F8, cvAmount8);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F8, lstDate8, lblDateFrom8, lblDateTo8, txtDate_From8, txtDate_To8, imgDate_To8, revtxtDate_From8, ucRelativeDatesFrom_8, ucRelativeDatesTo_8, imgDate_Opened_From8);
                            break;
                        case 8:
                            chkNotCriteria9.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter9);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria9);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F9, txtFilter9, drpText_F9);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F9);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F9, drpAmount_F9, txtAmount1_F9, txtAmount2_F9, lblAmountText1_F9, lblAmountText2_F9, cvAmount9);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F9, lstDate9, lblDateFrom9, lblDateTo9, txtDate_From9, txtDate_To9, imgDate_To9, revtxtDate_From9, ucRelativeDatesFrom_9, ucRelativeDatesTo_9, imgDate_Opened_From9);
                            break;
                        case 9:
                            chkNotCriteria10.Visible = true;
                            LoadFilterCriteria(lstFilter[i], drpFilter10);
                            LoadCheckBoxNotCriteria(lstFilter[i], chkNotCriteria10);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F10, txtFilter10, drpText_F10);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F10);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F10, drpAmount_F10, txtAmount1_F10, txtAmount2_F10, lblAmountText1_F10, lblAmountText2_F10, cvAmount10);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F10, lstDate10, lblDateFrom10, lblDateTo10, txtDate_From10, txtDate_To10, imgDate_To10, revtxtDate_From10, ucRelativeDatesFrom_10, ucRelativeDatesTo_10, imgDate_Opened_From10);
                            break;
                        default: break;
                    }

                }
                //Set Relative Date and it's Control
                SetRelativeDateControl();
            }
            //Enable Desable Output Field Button.
            btnDeselectFields.Enabled = lstSelectedFields.Items.Count > 0;
            imgUp.Enabled = imgDown.Enabled = btnDeselectAllFields.Enabled = lstSelectedFields.Items.Count > 0;
            btnSelectAllFields.Enabled = btnSelectFields.Enabled = lstOutputFields.Items.Count > 0;

            hdnReportId.Value = Pk_AdHocReport.ToString();
            PK_SID = PK_Schedule;
            // Reset Scroll Position
            ResetScrollPosition();
            btnCancel.Visible = true;
        }
    }

    private void SetSelectedValueFromString(string CSValue, CheckBoxList chkList)
    {
        if (!string.IsNullOrEmpty(CSValue))
        {
            string[] strSelectedValues = CSValue.Split(',');

            ListItem li;
            foreach (string strSelect in strSelectedValues)
            {
                li = chkList.Items.FindByValue(strSelect.Replace(" ", ""));

                if (li != null)
                    li.Selected = true;
            }
        }
    }
    #endregion



}
