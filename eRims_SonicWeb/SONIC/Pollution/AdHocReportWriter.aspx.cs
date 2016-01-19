using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;

public partial class Pollution_AdHocReportWriter : clsBasePage
{
    #region "Enum"

    /// <summary>
    /// Report Output Type
    /// </summary>
    public enum ReportOutputType : int
    {
        ExportToExcel = 0,
        ExportToPDF = 1,
        ExportAsMail = 2,
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
            SetDefaults();
            ClearAllFilterPanel();
            // Reset Scroll Position
            ResetScrollPosition();
            //Receoipient List
            ComboHelper.GetRecipientList(ddlRecipientList);
            //Hide Hidden Button
            btnHdnScheduling.Style["display"] = "none";
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
        }
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
        // if (File.Exists(strFilePath))
        if (blnHTML2Excel)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + "EHS Ad-Hoc Report.xlsx" + "\""));
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
            if (clsGeneral.SendAdHocReport("Ad Hoc Report", outputFiles, "Environmental Ad-Hoc Report.xlsx", Convert.ToDecimal(ddlRecipientList.SelectedItem.Value)))
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Email Sent Successfully')", true);
                File.Delete(strFilePath);
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Error occured while sending email.Please contact administrator')", true);
        }
    }

    /// <summary>
    /// handle Submit button Click events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dtAdHocReport = Pollution_AdHocReport.ExistsReportName(txtReportName.Text, (ddlReports.SelectedIndex > 0) ? Convert.ToDecimal(ddlReports.SelectedValue) : 0);

        if (dtAdHocReport.Rows.Count > 0)
        {
            hdnReportId.Value = Convert.ToString(dtAdHocReport.Rows[0]["Pk_AdHocReport"]);
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
        hdnReportId.Value = string.Empty;
        SaveReport();
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
            Pollution_AdHocReport.DeleteByPK(Convert.ToDecimal(ddlReports.SelectedItem.Value));
            hdnReportId.Value = "0";
            txtReportName.Text = "";
            SetDefaults();
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
        SetDefaults();
        ClearAllFilterPanel();
        ClearControls();
        // maintain Scroll Bar Possition on Post Back
        ResetScrollPosition();
        txtReportName.Text = "";
    }

    /// <summary>
    /// Event to handle Select output fileds
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstOutputFields, lstSelectedFields, true, true);
    }

    /// <summary>
    /// Event to Handle select All output fileds.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstOutputFields, lstSelectedFields, false, true);
    }

    /// <summary>
    /// Event to handle Desect Fields
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeselectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSelectedFields, lstOutputFields, true, false);
    }

    /// <summary>
    /// Event to handle DeSelect All Output Fileds.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeselectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSelectedFields, lstOutputFields, false, false);
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
            default:

                break;
        }
    }

    #endregion

    #region "Selected Index Change"

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
    /// EVent to handle Dropdown filter change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (((DropDownList)sender).ID)
        {
            case "drpFilter1":
                drpFilterChange(drpFilter1, pnlText_F1, pnlAmount_F1, pnlDate_F1, lst_F1);
                break;
            case "drpFilter2":
                drpFilterChange(drpFilter2, pnlText_F2, pnlAmount_F2, pnlDate_F2, lst_F2);
                break;
            case "drpFilter3":
                drpFilterChange(drpFilter3, pnlText_F3, pnlAmount_F3, pnlDate_F3, lst_F3);
                break;
            case "drpFilter4":
                drpFilterChange(drpFilter4, pnlText_F4, pnlAmount_F4, pnlDate_F4, lst_F4);
                break;
            case "drpFilter5":
                drpFilterChange(drpFilter5, pnlText_F5, pnlAmount_F5, pnlDate_F5, lst_F5);
                break;
            case "drpFilter6":
                drpFilterChange(drpFilter6, pnlText_F6, pnlAmount_F6, pnlDate_F6, lst_F6);
                break;
            case "drpFilter7":
                drpFilterChange(drpFilter7, pnlText_F7, pnlAmount_F7, pnlDate_F7, lst_F7);
                break;
            case "drpFilter8":
                drpFilterChange(drpFilter8, pnlText_F8, pnlAmount_F8, pnlDate_F8, lst_F8);
                break;
            case "drpFilter9":
                drpFilterChange(drpFilter9, pnlText_F9, pnlAmount_F9, pnlDate_F9, lst_F9);
                break;
            case "drpFilter10":
                drpFilterChange(drpFilter10, pnlText_F10, pnlAmount_F10, pnlDate_F10, lst_F10);
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
        switch (((DropDownList)sender).ID)
        {
            case "drpAmount_F1":
                drpAmount_Changed(isDollar, drpAmount_F1, lblAmountText1_F1, txtAmount1_F1, lblAmountText2_F1, txtAmount2_F1, cvAmount1, drpFilter1);
                break;
            case "drpAmount_F2":
                drpAmount_Changed(isDollar, drpAmount_F2, lblAmountText1_F2, txtAmount1_F2, lblAmountText2_F2, txtAmount2_F2, cvAmount2, drpFilter2);
                break;
            case "drpAmount_F3":
                drpAmount_Changed(isDollar, drpAmount_F3, lblAmountText1_F3, txtAmount1_F3, lblAmountText2_F3, txtAmount2_F3, cvAmount3, drpFilter3);
                break;
            case "drpAmount_F4":
                drpAmount_Changed(isDollar, drpAmount_F4, lblAmountText1_F4, txtAmount1_F4, lblAmountText2_F4, txtAmount2_F4, cvAmount4, drpFilter4);
                break;
            case "drpAmount_F5":
                drpAmount_Changed(isDollar, drpAmount_F5, lblAmountText1_F5, txtAmount1_F5, lblAmountText2_F5, txtAmount2_F5, cvAmount5, drpFilter5);
                break;
            case "drpAmount_F6":
                drpAmount_Changed(isDollar, drpAmount_F6, lblAmountText1_F6, txtAmount1_F6, lblAmountText2_F6, txtAmount2_F6, cvAmount6, drpFilter6);
                break;
            case "drpAmount_F7":
                drpAmount_Changed(isDollar, drpAmount_F7, lblAmountText1_F7, txtAmount1_F7, lblAmountText2_F7, txtAmount2_F7, cvAmount7, drpFilter7);
                break;
            case "drpAmount_F8":
                drpAmount_Changed(isDollar, drpAmount_F8, lblAmountText1_F8, txtAmount1_F8, lblAmountText2_F8, txtAmount2_F8, cvAmount8, drpFilter8);
                break;
            case "drpAmount_F9":
                drpAmount_Changed(isDollar, drpAmount_F9, lblAmountText1_F9, txtAmount1_F9, lblAmountText2_F9, txtAmount2_F9, cvAmount9, drpFilter9);
                break;
            case "drpAmount_F10":
                drpAmount_Changed(isDollar, drpAmount_F10, lblAmountText1_F10, txtAmount1_F10, lblAmountText2_F10, txtAmount2_F10, cvAmount10, drpFilter10);
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
            List<Pollution_AdHocFilter> lstFilter = new List<Pollution_AdHocFilter>();

            _dcSelectedReport = Convert.ToDecimal(ddlReports.SelectedItem.Value);
            lstFilter = new Pollution_AdHocFilter().GetAdHocReportFieldByPk(_dcSelectedReport.Value);

            Pollution_AdHocReport ObjAdHocReport = new Pollution_AdHocReport(_dcSelectedReport.Value);

            // Clear All Panels to bank
            ClearAllFilterPanel();
            // Clear All Control
            ClearControls();
            // Bind Output fileds
            BindOutpuFields();

            // Remove Selected Output fields from Report Ouput List
            RemoveSelectedItem(ObjAdHocReport.OutputFields);

            SetGroupFilterByControl(ObjAdHocReport.FirstGroupBy, drpGroupByFirst, rdblGroupSortByFirst, ObjAdHocReport.FirstGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.SecondGroupBy, drpGroupBySecond, rdblGroupSortBySecond, ObjAdHocReport.SecondGroupByOrder);
            SetGroupFilterByControl(ObjAdHocReport.FirstSortBy, drpSortingFirst, rdbSort1, ObjAdHocReport.FirstSortByOrder);
            SetGroupFilterByControl(ObjAdHocReport.SecondSortBy, drpSortingSecond, rdbSort2, ObjAdHocReport.SecondSortByOrder);
            SetGroupFilterByControl(ObjAdHocReport.ThirdSortBy, drpSortingThird, rdbSort3, ObjAdHocReport.ThirdSortByOrder);

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
                            // Set Text value Criteria
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F1, txtFilter1, drpText_F1);
                            // Set Multi Selection listBox Criteria
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F1);
                            // Set Amount field Criteria
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F1, drpAmount_F1, txtAmount1_F1, txtAmount2_F1, lblAmountText1_F1, lblAmountText2_F1, cvAmount1, drpFilter1);
                            // Set Date Control Filter Criteria
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F1, lstDate1, lblDateFrom1, lblDateTo1, txtDate_From1, txtDate_To1, imgDate_To1, revtxtDate_From1, ucRelativeDatesFrom_1, ucRelativeDatesTo_1, imgDate_Opened_From1);
                            break;
                        case 1:
                            LoadFilterCriteria(lstFilter[i], drpFilter2);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F2, txtFilter2, drpText_F2);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F2);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F2, drpAmount_F2, txtAmount1_F1, txtAmount2_F2, lblAmountText1_F2, lblAmountText2_F2, cvAmount2, drpFilter2);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F2, lstDate2, lblDateFrom2, lblDateTo2, txtDate_From2, txtDateTo2, imgDate_To2, revtxtDate_From2, ucRelativeDatesFrom_2, ucRelativeDatesTo_2, imgDate_Opened_From2);
                            break;
                        case 2:
                            LoadFilterCriteria(lstFilter[i], drpFilter3);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F3, txtFilter3, drpText_F3);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F3);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F3, drpAmount_F3, txtAmount1_F3, txtAmount2_F3, lblAmountText1_F3, lblAmountText2_F3, cvAmount3, drpFilter3);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F3, lstDate3, lblDateFrom3, lblDateTo3, txtDate_From3, txtDate_To3, imgDate_To3, revtxtDate_From3, ucRelativeDatesFrom_3, ucRelativeDatesTo_3, imgDate_Opened_From3);
                            break;
                        case 3:
                            LoadFilterCriteria(lstFilter[i], drpFilter4);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F4, txtFilter4, drpText_F4);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F4);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F4, drpAmount_F4, txtAmount1_F4, txtAmount2_F4, lblAmountText1_F4, lblAmountText2_F4, cvAmount4, drpFilter4);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F4, lstDate4, lblDateFrom4, lblDateTo4, txtDate_From4, txtDate_To4, imgDate_To4, revtxtDate_From4, ucRelativeDatesFrom_4, ucRelativeDatesTo_4, imgDate_Opened_From4);
                            break;
                        case 4:
                            LoadFilterCriteria(lstFilter[i], drpFilter5);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F5, txtFilter5, drpText_F5);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F5);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F5, drpAmount_F5, txtAmount1_F5, txtAmount2_F5, lblAmountText1_F5, lblAmountText2_F5, cvAmount5, drpFilter5);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F5, lstDate5, lblDateFrom5, lblDateTo5, txtDate_From5, txtDate_To5, imgDate_To5, revtxtDate_From5, ucRelativeDatesFrom_5, ucRelativeDatesTo_5, imgDate_Opened_From5);
                            break;
                        case 5:
                            LoadFilterCriteria(lstFilter[i], drpFilter6);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F6, txtFilter6, drpText_F6);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F6);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F6, drpAmount_F6, txtAmount1_F6, txtAmount2_F6, lblAmountText1_F6, lblAmountText2_F6, cvAmount6, drpFilter6);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F6, lstDate6, lblDateFrom6, lblDateTo6, txtDate_From6, txtDate_To6, imgDate_To6, revtxtDate_From6, ucRelativeDatesFrom_6, ucRelativeDatesTo_6, imgDate_Opened_From6);
                            break;
                        case 6:
                            LoadFilterCriteria(lstFilter[i], drpFilter7);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F7, txtFilter7, drpText_F7);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F7);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F7, drpAmount_F7, txtAmount1_F7, txtAmount2_F7, lblAmountText1_F7, lblAmountText2_F7, cvAmount7, drpFilter7);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F7, lstDate7, lblDateFrom7, lblDateTo7, txtDate_From7, txtDate_To7, imgDate_To7, revtxtDate_From7, ucRelativeDatesFrom_7, ucRelativeDatesTo_7, imgDate_Opened_From7);
                            break;
                        case 7:
                            LoadFilterCriteria(lstFilter[i], drpFilter8);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F8, txtFilter8, drpText_F8);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F8);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F8, drpAmount_F8, txtAmount1_F8, txtAmount2_F8, lblAmountText1_F8, lblAmountText2_F8, cvAmount8, drpFilter8);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F8, lstDate8, lblDateFrom8, lblDateTo8, txtDate_From8, txtDate_To8, imgDate_To8, revtxtDate_From8, ucRelativeDatesFrom_8, ucRelativeDatesTo_8, imgDate_Opened_From8);
                            break;
                        case 8:
                            LoadFilterCriteria(lstFilter[i], drpFilter9);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F9, txtFilter9, drpText_F9);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F9);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F9, drpAmount_F9, txtAmount1_F9, txtAmount2_F9, lblAmountText1_F9, lblAmountText2_F9, cvAmount9, drpFilter9);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.DateControl)
                                LoadFilterControlDate(lstFilter[i], pnlDate_F9, lstDate9, lblDateFrom9, lblDateTo9, txtDate_From9, txtDate_To9, imgDate_To9, revtxtDate_From9, ucRelativeDatesFrom_9, ucRelativeDatesTo_9, imgDate_Opened_From9);
                            break;
                        case 9:
                            LoadFilterCriteria(lstFilter[i], drpFilter10);
                            if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.TextBox)
                                LoadFilterControlText(lstFilter[i].ConditionType, lstFilter[i].ConditionValue, pnlText_F10, txtFilter10, drpText_F10);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                                LoadFilterControlDropDown(lstFilter[i].Field_Header, lstFilter[i].ConditionValue, lst_F10);
                            else if (lstFilter[i].Fk_ControlType.Value == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                                LoadFilterControlAmount(lstFilter[i], pnlAmount_F10, drpAmount_F10, txtAmount1_F10, txtAmount2_F10, lblAmountText1_F10, lblAmountText2_F10, cvAmount10, drpFilter10);
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
            SetDefaults();
            ClearAllFilterPanel();
            ClearControls();
        }
        //Enable Desable Output Field Button.
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
    /// Search List ITem from list object
    /// </summary>
    /// <param name="decValue"></param>
    /// <param name="lstSearch"></param>
    /// <returns></returns>
    private int SearchList(decimal decValue, List<Pollution_AdhocReportFields> lstSearch)
    {
        int i;
        for (i = 0; i < lstSearch.Count; i++)
        {
            if (lstSearch[i].Pk_AdhocReportFields.Value == decValue)
                return i;
        }
        return 0;
    }

    /// <summary>
    /// Set Default Control value
    /// </summary>
    private void SetDefaults()
    {
        BindReportNameDropDown();
        BindFilterCombo();
        BindOutpuFields();
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
        rdblGroupSortByFirst.SelectedValue = rdblGroupSortBySecond.SelectedValue = rdbSort1.SelectedValue = rdbSort2.SelectedValue = rdbSort3.SelectedValue = "ASC";

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
    }

    /// <summary>
    /// Bind Report Name Drop Down with Coverage Type
    /// </summary>
    /// <param name="strType"></param>
    private void BindReportNameDropDown()
    {
        ddlReports.Items.Clear();
        DataTable dtReprot = Pollution_AdHocReport.SelectReportName().Tables[0];
        ddlReports.DataSource = dtReprot;
        ddlReports.DataTextField = "ReportName";
        ddlReports.DataValueField = "Pk_AdHocReport";
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
    private void MoveListBoxItems(ListBox lstFrom, ListBox lstTo, bool OnlySelected, bool IsSelect)
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
                drpSortingFirst.Items.Remove(liSelcted);
                drpSortingSecond.Items.Remove(liSelcted);
                drpSortingThird.Items.Remove(liSelcted);

                if (liSelcted.Text == "Date of Loss")
                {
                    drpGroupByFirst.Items.Remove(drpGroupByFirst.Items.FindByText("Accident Year"));
                    drpGroupBySecond.Items.Remove(drpGroupBySecond.Items.FindByText("Accident Year"));
                }
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
                drpSortingFirst.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpSortingSecond.Items.Insert(i + 1, lstSelected[i] as ListItem);
                drpSortingThird.Items.Insert(i + 1, lstSelected[i] as ListItem);

                if (lstSelected[i].Text == "Date of Loss")
                {
                    drpGroupByFirst.Items.Insert(i + 1, new ListItem("Accident Year", "Accident Year"));
                    drpGroupBySecond.Items.Insert(i + 1, new ListItem("Accident Year", "Accident Year"));
                }
            }
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

        if (rdbCommon.SelectedValue == "B")
        {
            img2.Visible = true;
            txt2.Visible = true;
            ucToDate.Visible = lbl2.Visible = true;
            lbl1.Text = "Start Date:";
            lbl2.Text = "End Date:";
            revDateTo.ErrorMessage = strFilterTxt + "Start Date is not valid date";
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
    protected string drpFilterChange(DropDownList drpFilter, Panel pnlText_F, Panel pnlAmoun_F, Panel pnlDate_F, ListBox lst_F)
    {
        if (drpFilter.SelectedValue == "0" || drpFilter.Items.Count <= 0)
        {
            pnlText_F.Visible = false;
            pnlAmoun_F.Visible = false;
            pnlDate_F.Visible = false;
            lst_F.Visible = false;
        }

        decimal decSelectedValue = 0;
        if (drpFilter.Items.Count > 0 && drpFilter.SelectedIndex > 0)
            decSelectedValue = Convert.ToDecimal(drpFilter.SelectedItem.Value);
        List<Pollution_AdhocReportFields> lstAdHoc = null;

        if (decSelectedValue > 0)
            lstAdHoc = new Pollution_AdhocReportFields().GetAdHocReportFieldByPk(decSelectedValue);

        if (lstAdHoc != null && lstAdHoc.Count > 0)
        {
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
                case (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList:
                    if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "dealership dba")
                    {
                        ComboHelper.FillLocationdbaFranchiseReport(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "legal entity")
                    {
                        ComboHelper.FillDistinctLocationLegal_EntityList(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "sonic location code")
                    {
                        ComboHelper.FillLocationLocationCodeFranchiseReport(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "building state")
                    {
                        ComboHelper.FillStateByDesc(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "state (waste hauler)" || Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "state(receiving tsdf)"
                        || Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "state(facility id)" || Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "state(utility provider)")
                    {
                        ComboHelper.FillStateList(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "building ownership")
                    {
                        ComboHelper.FillBuildingOwnerShip(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "building status")
                    {
                        ComboHelper.FillBuildingLocationStatus(new ListBox[] { lst_F }, false);
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "agency(facility id)")
                    {
                        ComboHelper.FillAgency(new ListBox[] { lst_F });
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "i.d type(facility id)")
                    {
                        ComboHelper.FillMedia(new ListBox[] { lst_F });
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "utility type(utility provider)")
                    {
                        ComboHelper.FillUtilityType(new ListBox[] { lst_F });
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "regulatory/notifying agency")
                    {
                        DataSet dsRA = LU_Regulatory_Notifying_Agency.SelectAll();
                        dsRA.Tables[0].DefaultView.RowFilter = "Active='Y'";
                        lst_F.Items.Clear();
                        lst_F.DataSource = dsRA.Tables[0].DefaultView;
                        lst_F.DataTextField = "Fld_Desc";
                        lst_F.DataValueField = "PK_LU_Regulatory_Notifying_Agency";
                        lst_F.DataBind();
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "hazardous waste codes")
                    {
                        DataSet dsHWCodes = LU_PM_Hazardous_Waste_Codes.SelectAll();
                        dsHWCodes.Tables[0].DefaultView.RowFilter = "Active='Y'";
                        lst_F.Items.Clear();
                        lst_F.DataSource = dsHWCodes.Tables[0].DefaultView;
                        lst_F.DataTextField = "Fld_Code";
                        lst_F.DataValueField = "PK_LU_PM_Hazardous_Waste_Codes";
                        lst_F.DataBind();
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "waste hauler (waste removal)")
                    {
                        DataSet dsWaste_Hauler = PM_Waste_Hauler.SelectAll();
                        lst_F.DataSource = dsWaste_Hauler.Tables[0];
                        lst_F.DataTextField = "Waste_Hauler_Name";
                        lst_F.DataValueField = "PK_PM_Waste_Hauler";
                        lst_F.DataBind();
                        lst_F.Items.Insert(0, new ListItem("-- select --", "0"));
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "receiving tsdf (waste removal)")
                    {
                        DataSet dsReceiving = PM_Receiving_TSDF.SelectAll();
                        lst_F.DataSource = dsReceiving.Tables[0];
                        lst_F.DataTextField = "Receiving_TSDF_Name";
                        lst_F.DataValueField = "PK_PM_Receiving_TSDF";
                        lst_F.DataBind();
                        lst_F.Items.Insert(0, new ListItem("-- select --", "0"));
                    }
                    else if (!string.IsNullOrEmpty(Convert.ToString(lstAdHoc[0].WhereField)) && Convert.ToString(lstAdHoc[0].WhereField).ToLower().Trim() == "pure_mixture")
                    {
                        List<ListItem> liItem = new List<ListItem>();

                        liItem.Add(new ListItem("Pure", "P"));
                        liItem.Add(new ListItem("Mixture", "M"));

                        lst_F.Items.Clear();
                        for (int i = 0; i < liItem.Count; i++)
                        {
                            lst_F.Items.Add((ListItem)liItem[i]);
                        }
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "physical state")
                    {
                        List<ListItem> liItem = new List<ListItem>();

                        liItem.Add(new ListItem("Solid", "S"));
                        liItem.Add(new ListItem("Liquid", "L"));
                        liItem.Add(new ListItem("Gas", "G"));

                        lst_F.Items.Clear();
                        for (int i = 0; i < liItem.Count; i++)
                        {
                            lst_F.Items.Add((ListItem)liItem[i]);
                        }
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "direct or indirect burners?(paint booth)" || Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "direct or indirect burners? (prep station)")
                    {
                        List<ListItem> liItem = new List<ListItem>();

                        liItem.Add(new ListItem("Direct", "D"));
                        liItem.Add(new ListItem("Indirect", "I"));

                        lst_F.Items.Clear();
                        for (int i = 0; i < liItem.Count; i++)
                        {
                            lst_F.Items.Add((ListItem)liItem[i]);
                        }
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "ground location?")
                    {
                        List<ListItem> liItem = new List<ListItem>();

                        liItem.Add(new ListItem("On Surface", "S"));
                        liItem.Add(new ListItem("Underground", "U"));

                        lst_F.Items.Clear();
                        for (int i = 0; i < liItem.Count; i++)
                        {
                            lst_F.Items.Add((ListItem)liItem[i]);
                        }
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).Trim() == "Status(Hydraulic Lift)" || Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "status(tank)")
                    {
                        List<ListItem> liItem = new List<ListItem>();

                        liItem.Add(new ListItem("Active", "A"));
                        liItem.Add(new ListItem("Non-Active", "N"));
                        liItem.Add(new ListItem("Removed", "R"));

                        lst_F.Items.Clear();
                        for (int i = 0; i < liItem.Count; i++)
                        {
                            lst_F.Items.Add((ListItem)liItem[i]);
                        }
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "voc year")
                    {
                        ComboHelper.FillSedgwickYear(new ListBox[] { lst_F });
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "voc month")
                    {
                        ComboHelper.BindMonth(lst_F);
                    }
                    else if (Convert.ToString(lstAdHoc[0].Field_Header).ToLower().Trim() == "voc paint category")
                    {
                        // ComboHelper.FillPaintCategory(lst_F, false);
                        DataTable dtData = ERIMS.DAL.clsLU_VOC_Category.SelectAll().Tables[0];
                        dtData.DefaultView.RowFilter = " Active = 'Y' ";
                        dtData = dtData.DefaultView.ToTable();
                        lst_F.Items.Clear();
                        lst_F.DataSource = dtData;
                        lst_F.DataTextField = "Category";
                        lst_F.DataValueField = "PK_LU_VOC_Category";
                        lst_F.DataBind();
                    }
                    else
                        AdHocReportHelper.FillFilterDropDown(lstAdHoc[0].Field_Header, new ListBox[] { lst_F }, false, "Pollution");
                    pnlText_F.Visible = false;
                    pnlAmoun_F.Visible = false;
                    pnlDate_F.Visible = false;
                    lst_F.Visible = true;
                    //Set ListBox ToolTip
                    //clsGeneral.SetListBoxToolTip(new ListBox[] { lst_F });
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
    protected void drpAmount_Changed(bool isDollarSign, DropDownList drpAmount_F, Label lblAmountText1_F, TextBox txtAmount1_F, Label lblAmountText2_F, TextBox txtAmount2_F, CompareValidator cvAmount, DropDownList drpFilter)
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

        if (drpFilter.SelectedItem.Text == "Number of Employees" || drpFilter.SelectedItem.Text == "Number of Shift" || drpFilter.SelectedItem.Text == "Days Per Week" || drpFilter.SelectedItem.Text == "Weeks Per Year" || drpFilter.SelectedItem.Text == "Number of Lifts At Location")
            isDollarSign = false;

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
            txtAmount1_F.Attributes.Add("onblur", "return formatCurrencyOnBlur(this);");
            txtAmount2_F.Attributes.Add("onblur", "return formatCurrencyOnBlur(this);");

            txtAmount1_F.MaxLength = txtAmount2_F.MaxLength = 17;
            cvAmount.ErrorMessage = cvAmount.ErrorMessage.Replace("Value", "Amount");

            //if (drpFilter.SelectedItem.Text == "Amount Purchased" || drpFilter.SelectedItem.Text == "Amount HW Generated Per Month" || drpFilter.SelectedItem.Text == "Capcity(Tank)" || drpFilter.SelectedItem.Text == "Capture Efficiency"
            //    || drpFilter.SelectedItem.Text == "Single Event Coverage" || drpFilter.SelectedItem.Text == "Multiple Event Total Coverage" || drpFilter.SelectedItem.Text == "Exit Temperature High"
            //    || drpFilter.SelectedItem.Text == "Exit Temperature Low" || drpFilter.SelectedItem.Text == "Exit Flow Rate CFM" || drpFilter.SelectedItem.Text == "Stack Height In Feet" || drpFilter.SelectedItem.Text == "Control Efficiency")
            if (!(Convert.ToString(drpFilter.SelectedItem.Text).Contains("Cost") || drpFilter.SelectedItem.Text == "Discharge Limits" || drpFilter.SelectedItem.Text == "Ending Inventory" || drpFilter.SelectedItem.Text == "Amount Used" || drpFilter.SelectedItem.Text == "State Local Fees"))
            {
                lblAmountText1_F.Text = lblAmountText1_F.Text.Replace("$", "");
                lblAmountText2_F.Text = lblAmountText2_F.Text.Replace("$", "");
            }
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
                    strValues = strValues + "'" + lstBoxItem.Value.Replace("'", "''").Replace(",", "^") + "',";
                else
                    strValues = strValues + lstBoxItem.Value.Replace("'", "''").Replace(",", "^") + ",";
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
    public string GetListBoxWhereCondition(string lstWhereFiels, string strCondition)
    {
        string strNewList = string.Empty;
        string strWhere = string.Empty;
        string[] arrwhere = strCondition.Split(',');
        //When Match with Char like [filed_name] in ('O,C')
        if (!string.IsNullOrEmpty(lstWhereFiels) && !string.IsNullOrEmpty(strCondition))
            strWhere = " And " + lstWhereFiels + " IN (" + strCondition + ") ";

        return strWhere;
    }

    /// <summary>
    /// Get Where condition when Type is Listbox
    /// </summary>
    /// <param name="lstWhereFiels"></param>
    /// <param name="strCondition"></param>
    /// <returns></returns>
    public string GetListBoxWhereConditionByText(string lstWhereFiels, string strCondition)
    {
        string strNewList = string.Empty;
        string strWhere = string.Empty;
        string[] arrwhere = strCondition.Split(',');
        //When Match with Char like [filed_name] in ('O,C')
        if (!string.IsNullOrEmpty(lstWhereFiels) && !string.IsNullOrEmpty(strCondition))
        {
            strWhere = " And ";
            for (int intI = 0; intI < arrwhere.Length; intI++)
            {
                strNewList += "'" + arrwhere[intI] + "',";
            }
            strWhere = " And " + lstWhereFiels + " IN (" + strNewList.TrimEnd(',').Replace("^", ",") + ") ";
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
    public string GetTextWhereCondition(string strFieldName, string strText, int drpIndex)
    {
        string strWhere = string.Empty;
        string strFilter = string.Empty;

        if (!string.IsNullOrEmpty(strText))
        {
            if (strFieldName.Contains("Date_Theft_Reported"))
                strWhere = " And (CONVERT(VARCHAR," + strFieldName + " ,108))";
            else strWhere = " And " + strFieldName;

            if (drpIndex == 1)
                strWhere += " LIKE  '%" + strText.Trim().Replace("'", "''") + "%' ";
            else if (drpIndex == 2)
                strWhere += " LIKE '" + strText.Trim().Replace("'", "''") + "%'";
            else if (drpIndex == 3)
                strWhere += " LIKE '%" + strText.Trim().Replace("'", "''") + "'";
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
    public string GetDateWhereCondtion(string strFieldName, string strDatefrom, string strDateTo, string cblDateCriteria)
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

        if (dtFrom.HasValue)
            strWhere = AdHocReportHelper.GetDateWhereAbsolute(strFieldName, dtFrom, dtTo, DtType);

        else if (dtTo.HasValue)
            strWhere = AdHocReportHelper.GetDateWhereAbsolute(strFieldName, dtFrom, dtTo, DtType);

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
    public string GetDateAmountCondtion(string strField_Header, string strAmtfrom, string strAmtTo, string drpAmtCriteria)
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
            strWhere = AdHocReportHelper.GetAmountWhere(strField_Header.Trim(), dFrom, dTo, AmtType);
        else if (dTo.HasValue)
            strWhere = AdHocReportHelper.GetAmountWhere(strField_Header.Trim(), dFrom, dTo, AmtType);

        return strWhere;
    }

    /// <summary>
    /// Bind Fileter Combo By COverage
    /// </summary>
    /// <param name="strTypes"></param>
    private void BindFilterCombo()
    {
        for (int intI = 1; intI <= 10; intI++)
        {
            DropDownList drpFilter = (DropDownList)pnl_Container.FindControl("drpFilter" + intI.ToString());
            if (drpFilter != null)
            {
                drpFilter.Items.Clear();
                drpFilter.DataSource = Pollution_AdhocReportFields.GetAdHocFilterFields("F");
                drpFilter.DataTextField = "Field_Header";
                drpFilter.DataValueField = "Pk_AdhocReportFields";
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
    private void BindOutpuFields()
    {
        lstOutputFields.Items.Clear();
        lstOutputFields.DataSource = Pollution_AdhocReportFields.GetAdHocFilterFields("O");
        lstOutputFields.DataTextField = "Field_Header";
        lstOutputFields.DataValueField = "Pk_AdhocReportFields";
        lstOutputFields.DataBind();
        //Didable button
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = imgUp.Enabled = imgDown.Enabled = false;
    }

    /// <summary>
    /// Bind Report Data.
    /// </summary>
    /// <param name="dsReport">Report Dataset</param>
    private string BindReport(ref StringBuilder sbRecord, ReportOutputType ReportType)
    {
        IDataReader Reader = null;
        List<Pollution_AdhocReportFields> lstAdhoc = null;
        DataTable dtSchema = null, dtHeader = null;
        try
        {
            decimal decValue;
            int iSelected;
            string strWhere = string.Empty, strFilterIds = string.Empty, strGroupBy = string.Empty, strOrderBy = string.Empty, strCriteria = string.Empty, strPath = string.Empty;

            #region "Group By and Filter By"

            if (drpGroupByFirst.SelectedIndex > 0)
                strGroupBy = "[" + drpGroupByFirst.SelectedItem.Text + "] " + rdblGroupSortByFirst.SelectedItem.Value;

            if (drpGroupBySecond.SelectedIndex > 0)
                strGroupBy += (string.IsNullOrEmpty(strGroupBy) ? "" : ",") + " [" + drpGroupBySecond.SelectedItem.Text + "] " + rdblGroupSortBySecond.SelectedItem.Value;

            if (drpSortingFirst.SelectedIndex > 0)
                strOrderBy = "[" + drpSortingFirst.SelectedItem.Text + "] " + rdbSort1.SelectedItem.Value;

            if (drpSortingSecond.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingSecond.SelectedItem.Text + "] " + rdbSort2.SelectedItem.Value;

            if (drpSortingThird.SelectedIndex > 0)
                strOrderBy += (string.IsNullOrEmpty(strOrderBy) ? "" : ",") + " [" + drpSortingThird.SelectedItem.Text + "] " + rdbSort3.SelectedItem.Value;

            #endregion

            strCriteria = GetFilterIDs(new DropDownList[] { drpFilter1, drpFilter2, drpFilter3, drpFilter4, drpFilter5, drpFilter6, drpFilter7, drpFilter8, drpFilter9, drpFilter10, });
            if (!string.IsNullOrEmpty(strCriteria))
                lstAdhoc = new Pollution_AdhocReportFields().GetAdHocReportFieldByMultipleID(strCriteria);

            #region "Get Where condition"

            if (drpFilter1.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter1.SelectedItem.Value);
                strFilterIds += decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                {
                    if (lstAdhoc[iSelected].Field_Header.ToLower().Trim() == "contact name" || lstAdhoc[iSelected].Field_Header.ToLower().Trim() == "complex number")
                        strWhere += GetTextWhereCondition(lstAdhoc[iSelected].Field_Name, txtFilter1.Text, Convert.ToInt16(drpText_F1.SelectedItem.Value));
                    else
                        strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter1.Text, Convert.ToInt16(drpText_F1.SelectedItem.Value));
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F1, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F1, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                {
                    if (lstAdhoc[iSelected].Field_Name.ToUpper() == "VOC_EMMISSION_DATE")
                    {
                        int fromYear = 1990; int toYear = 1990;
                        int fromMonth = 1; int toMonth = 1;
                        string fromWhere = string.Empty;
                        string toWhere = string.Empty;
                        switch (lstDate1.SelectedItem.Value)
                        {
                            case "O":
                                fromYear = Convert.ToDateTime(txtDate_From1.Text).Year;
                                fromMonth = Convert.ToDateTime(txtDate_From1.Text).Month;
                                strWhere = " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Year=" + fromYear + " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Month=" + fromMonth; 
                                break;
                            case "B":
                                fromYear = Convert.ToDateTime(txtDate_From1.Text).Year;
                                fromMonth = Convert.ToDateTime(txtDate_From1.Text).Month;
                                toYear = Convert.ToDateTime(txtDate_To1.Text).Year;
                                toMonth = Convert.ToDateTime(txtDate_To1.Text).Month;
                                strWhere = " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Year>=" + fromYear + " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Month>=" + fromMonth + " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Year<=" + toYear + " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Month<=" + toMonth; 
                                break;
                            case "A":
                                toYear = Convert.ToDateTime(txtDate_From1.Text).Year;
                                toMonth = Convert.ToDateTime(txtDate_From1.Text).Month;
                                strWhere = " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Year>" + fromYear + " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Month>" + fromMonth;
                                break;
                            case "BF":
                                fromYear = Convert.ToDateTime(txtDate_From1.Text).Year;
                                fromMonth = Convert.ToDateTime(txtDate_From1.Text).Month;
                                strWhere = " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Year<" + toYear + " AND " + "[" + lstAdhoc[iSelected].Table_Name + "].Month<" + toMonth; 
                                break;
                        }  
                    }
                    else
                    {
                        strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From1.Text, txtDate_To1.Text, lstDate1.SelectedItem.Value);
                    }
                }
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    // It takes Filed Header when Table is Transaction otherwist it take Filed Name.
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F1.Text, txtAmount2_F1.Text, drpAmount_F1.SelectedItem.Value);
                    else
                    {
                        string fieldName = lstAdhoc[iSelected].Field_Name;
                        if (fieldName.ToUpper() == "QUANTITY" || fieldName.ToUpper() == "UNIT" || fieldName.ToUpper() == "GALLONS" || fieldName.ToUpper() == "VOC EMISSIONS")
                        {
                            string caseCondition = " Cast([" + lstAdhoc[iSelected].Table_Name + "]." + fieldName + " AS Numeric)";
                            strWhere += GetDateAmountCondtion(caseCondition, txtAmount1_F1.Text, txtAmount2_F1.Text, drpAmount_F1.SelectedItem.Value);
                        }
                        else
                            strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F1.Text, txtAmount2_F1.Text, drpAmount_F1.SelectedItem.Value);
                    }
                }
            }
            if (drpFilter2.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter2.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter2.Text, Convert.ToInt16(drpText_F2.SelectedItem.Value));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F2, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F2, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From2.Text, txtDateTo2.Text, lstDate2.SelectedItem.Value);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F2.Text, txtAmount2_F2.Text, drpAmount_F2.SelectedItem.Value);
                    else
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F2.Text, txtAmount2_F2.Text, drpAmount_F2.SelectedItem.Value);
                }
            }
            if (drpFilter3.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter3.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter3.Text, Convert.ToInt16(drpText_F3.SelectedItem.Value));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F3, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F3, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From3.Text, txtDate_To3.Text, lstDate3.SelectedItem.Value);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F3.Text, txtAmount2_F3.Text, drpAmount_F3.SelectedItem.Value);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F3.Text, txtAmount2_F3.Text, drpAmount_F3.SelectedItem.Value);
                }
            }
            if (drpFilter4.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter4.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter4.Text, Convert.ToInt16(drpText_F4.SelectedItem.Value));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F4, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F4, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From4.Text, txtDate_To4.Text, lstDate4.SelectedItem.Value);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F4.Text, txtAmount2_F4.Text, drpAmount_F4.SelectedItem.Value);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F4.Text, txtAmount2_F4.Text, drpAmount_F4.SelectedItem.Value);
                }
            }
            if (drpFilter5.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter5.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter5.Text, Convert.ToInt16(drpText_F5.SelectedItem.Value));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F5, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F5, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From5.Text, txtDate_To5.Text, lstDate5.SelectedItem.Value);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F5.Text, txtAmount2_F5.Text, drpAmount_F5.SelectedItem.Value);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F5.Text, txtAmount2_F5.Text, drpAmount_F5.SelectedItem.Value);
                }
            }
            if (drpFilter6.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter6.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter6.Text, Convert.ToInt16(drpText_F6.SelectedItem.Value));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F6, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F6, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From6.Text, txtDate_To6.Text, lstDate6.SelectedItem.Value);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F6.Text, txtAmount2_F6.Text, drpAmount_F6.SelectedItem.Value);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F6.Text, txtAmount2_F6.Text, drpAmount_F6.SelectedItem.Value);
                }
            }
            if (drpFilter7.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter7.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter7.Text, Convert.ToInt16(drpText_F7.SelectedItem.Value));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F7, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F7, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From7.Text, txtDate_To7.Text, lstDate7.SelectedItem.Value);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F7.Text, txtAmount2_F7.Text, drpAmount_F7.SelectedItem.Value);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F7.Text, txtAmount2_F7.Text, drpAmount_F7.SelectedItem.Value);
                }
            }
            if (drpFilter8.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter8.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter8.Text, Convert.ToInt16(drpText_F8.SelectedItem.Value));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F8, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F8, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From8.Text, txtDate_To8.Text, lstDate8.SelectedItem.Value);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F8.Text, txtAmount2_F8.Text, drpAmount_F8.SelectedItem.Value);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F8.Text, txtAmount2_F8.Text, drpAmount_F8.SelectedItem.Value);
                }
            }
            if (drpFilter9.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter9.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);

                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter9.Text, Convert.ToInt16(drpText_F9.SelectedItem.Value));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F9, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F9, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From9.Text, txtDate_To9.Text, lstDate9.SelectedItem.Value);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F9.Text, txtAmount2_F9.Text, drpAmount_F9.SelectedItem.Value);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F9.Text, txtAmount2_F9.Text, drpAmount_F9.SelectedItem.Value);
                }
            }
            if (drpFilter10.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter10.SelectedItem.Value);
                strFilterIds += (string.IsNullOrEmpty(strFilterIds) ? "" : ",") + decValue.ToString();
                iSelected = SearchList(decValue, lstAdhoc);
                if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.TextBox)
                    strWhere += GetTextWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtFilter10.Text, Convert.ToInt16(drpText_F10.SelectedItem.Value));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectList)
                    strWhere += GetListBoxWhereCondition("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F10, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.MultiSelectTextList)
                    strWhere += GetListBoxWhereConditionByText("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].WhereField, GetSelectedItemString(lst_F10, false));
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.DateControl)
                    strWhere += GetDateWhereCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtDate_From10.Text, txtDate_To10.Text, lstDate10.SelectedItem.Value);
                else if (lstAdhoc[iSelected].Fk_ControlType == (int)AdHocReportHelper.AdHocControlType.AmountControl)
                {
                    if (lstAdhoc[iSelected].Table_Name == "T")
                        strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Field_Header + "]", txtAmount1_F10.Text, txtAmount2_F10.Text, drpAmount_F10.SelectedItem.Value);
                    else strWhere += GetDateAmountCondtion("[" + lstAdhoc[iSelected].Table_Name + "]." + lstAdhoc[iSelected].Field_Name, txtAmount1_F10.Text, txtAmount2_F10.Text, drpAmount_F10.SelectedItem.Value);
                }
            }

            #endregion

            clsGeneral.DisposeOf(lstAdhoc);
            bool IsSuccess = true;
            Reader = AdHocReportHelper.GetAdHocReportPollution(GetAllItemString(lstSelectedFields, false), strGroupBy, strWhere, strOrderBy, strFilterIds, Convert.ToDecimal(clsSession.UserID), out IsSuccess);
            if (IsSuccess == true)
            {
                // Check if Any record is exists or not
                if (Reader.Read())
                {
                    string strFirstGroupBy = string.Empty, strSecGroupBy = string.Empty;

                    if (drpGroupByFirst.SelectedIndex > 0)
                        strFirstGroupBy = drpGroupByFirst.SelectedItem.Text;

                    if (drpGroupBySecond.SelectedIndex > 0)
                        strSecGroupBy = drpGroupBySecond.SelectedItem.Text;

                    //iF Frist Group By is Not  selected then second Group by will be set as first Group By
                    if (string.IsNullOrEmpty(strFirstGroupBy) && !string.IsNullOrEmpty(strGroupBy))
                    {
                        strFirstGroupBy = strSecGroupBy;
                        strSecGroupBy = string.Empty;
                    }
                    dtSchema = Reader.GetSchemaTable();
                    //Table Start
                    if (ReportType == ReportOutputType.ExportAsMail)
                    {
                        sbRecord.Append("<br />");
                        sbRecord.Append("<b>Report Title : Environmental Ad-Hoc Report </b>");
                        sbRecord.Append("<br /><br />");
                    }

                    sbRecord.Append("<table border='1' cellpadding='0' cellspacing='0' width='" + (150 * lstSelectedFields.Items.Count).ToString() + "' style='font-size:10pt'>");

                    #region "Header"
                    // If reader found a records 
                    sbRecord.Append("<tr>");

                    dtHeader = new DataTable();
                    string strFormatFirstGroupBy = string.Empty, strFormatSecGroupBy = string.Empty;
                    foreach (DataRow drHeader in dtSchema.Rows)
                    {
                        //Remove Group By 
                        if (strFirstGroupBy != Convert.ToString(drHeader["ColumnName"]) && strSecGroupBy != Convert.ToString(drHeader["ColumnName"]))
                            sbRecord.Append("<td><b>" + drHeader["ColumnName"] + "</b></td>");
                        //Get First and Second Group By Field's Data Type
                        if (strFirstGroupBy == Convert.ToString(drHeader["ColumnName"]))
                            strFormatFirstGroupBy = drHeader["DataTypeName"].ToString();
                        if (strSecGroupBy == Convert.ToString(drHeader["ColumnName"]))
                            strFormatSecGroupBy = drHeader["DataTypeName"].ToString();
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
                    string strGroupByValue_1 = string.Empty, strGroupByValue_2 = string.Empty, strNOGroup1 = string.Empty, strNOGroup2 = string.Empty;
                    do
                    {
                        string strFormat = string.Empty;

                        #region "SUBTOTALS"
                        if (!string.IsNullOrEmpty(strSecGroupBy) && !string.IsNullOrEmpty(strGroupByValue_2) && strGroupByValue_2 != Convert.ToString(Reader[strSecGroupBy]))
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
                                            if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy)
                                                sbRecord.Append("<td>&nbsp;</td>");
                                        }
                                    }
                                    intCol++;
                                }

                                sbRecord.Append("</tr>");
                                dtSubTotalSecondGroup.Clear();
                            }
                        }
                        if (!string.IsNullOrEmpty(strFirstGroupBy) && !string.IsNullOrEmpty(strGroupByValue_1) && strGroupByValue_1 != Convert.ToString(Reader[strFirstGroupBy]))
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
                                            if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy)
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

                        //First Group By
                        if (!string.IsNullOrEmpty(strFirstGroupBy))
                        {
                            if (strGroupByValue_1 != Convert.ToString(Reader[strFirstGroupBy]))
                            {
                                strGroupByValue_1 = Convert.ToString(Reader[strFirstGroupBy]);
                                if (strFormatFirstGroupBy == "decimal")
                                {
                                    //if (strFirstGroupBy == "Amount Purchased" || strFirstGroupBy == "Amount HW Generated Per Month" || strFirstGroupBy == "Capcity(Tank)" || strFirstGroupBy == "Single Event Coverage" || strFirstGroupBy == "Control Efficiency"
                                    //    || strFirstGroupBy == "Multiple Event Total Coverage" || strFirstGroupBy == "Exit Temperature High" || strFirstGroupBy == "Exit Temperature Low" || strFirstGroupBy == "Exit Flow Rate CFM" || strFirstGroupBy == "Capture Efficiency"
                                    //    || strFirstGroupBy == "Stack Height In Feet")
                                    if (Convert.ToString(strFirstGroupBy).Contains("Cost") || strFirstGroupBy == "Discharge Limits" || strFirstGroupBy == "Ending Inventory" || strFirstGroupBy == "Amount Used" || strFirstGroupBy == "State Local Fees")
                                        sbRecord.Append("<tr><td style='font-weight: bold;' align='right' >" + strFirstGroupBy + ": " + string.Format("{0:C2}", strGroupByValue_1) + "</td></tr>");
                                    else
                                    {
                                        if (strFirstGroupBy == "Number of Employees" || strFirstGroupBy == "Number of Shift" || strFirstGroupBy == "Days Per Week" || strFirstGroupBy == "Weeks Per Year" || strFirstGroupBy == "Number of Lifts At Location")
                                            sbRecord.Append("<tr><td style='font-weight: bold;' align='right'>" + strFirstGroupBy + ": " + string.Format("{0:N0}", strGroupByValue_1) + "</td></tr>");
                                        else
                                            sbRecord.Append("<tr><td style='font-weight: bold;' align='right'>" + strFirstGroupBy + ": " + string.Format("{0:N2}", strGroupByValue_1) + "</td></tr>");
                                    }
                                }
                                else if (strFormatFirstGroupBy == "datetime")
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;'>" + strFirstGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_1) + "</td></tr>");
                                }
                                else sbRecord.Append("<tr><td style='font-weight: bold;'>&nbsp;" + strFirstGroupBy + ": " + strGroupByValue_1 + "</td></tr>");
                                //Change Second Group By when First Groupby is Change
                                strGroupByValue_2 = string.Empty;
                            }
                            // it will set No : [First Group By] when it is null
                            else if ((Reader[strFirstGroupBy] == DBNull.Value || string.IsNullOrEmpty(Convert.ToString(Reader[strFirstGroupBy]))) && strNOGroup1 == string.Empty)
                            {
                                strNOGroup1 = "No " + strFirstGroupBy;
                                sbRecord.Append("<tr><td style='font-weight: bold;' >&nbsp;" + strFirstGroupBy + ": " + strNOGroup1 + "</td></tr>");
                                // When Group by 1 value find as Null
                                strNOGroup1 = strFirstGroupBy;
                                //Change Second Group By when First Groupby is Change
                                strGroupByValue_2 = string.Empty;
                            }
                        }
                        //Second Group By
                        if (!string.IsNullOrEmpty(strSecGroupBy))
                        {
                            if (strGroupByValue_2 != Convert.ToString(Reader[strSecGroupBy]))
                            {
                                strGroupByValue_2 = Convert.ToString(Reader[strSecGroupBy]);
                                if (strFormatSecGroupBy == "decimal")
                                {
                                    //if (strSecGroupBy == "Amount Purchased" || strSecGroupBy == "Amount HW Generated Per Month" || strSecGroupBy == "Capcity(Tank)" || strSecGroupBy == "Single Event Coverage" || strSecGroupBy == "Control Efficiency"
                                    //    || strSecGroupBy == "Multiple Event Total Coverage" || strSecGroupBy == "Exit Temperature High" || strSecGroupBy == "Exit Temperature Low" || strSecGroupBy == "Exit Flow Rate CFM" || strSecGroupBy == "Stack Height In Feet"
                                    //    || strSecGroupBy == "Capture Efficiency")
                                    if (Convert.ToString(strSecGroupBy).Contains("Cost") || strSecGroupBy == "Discharge Limits" || strSecGroupBy == "Ending Inventory" || strSecGroupBy == "Amount Used" || strSecGroupBy == "State Local Fees")
                                    {
                                        sbRecord.Append("<tr><td style='font-weight: bold;' align='right' >" + strSecGroupBy + ": " + string.Format("{0:C2}", strGroupByValue_2) + "</td></tr>");
                                    }
                                    else
                                    {
                                        if (strSecGroupBy == "Number of Employees" || strSecGroupBy == "Number of Shift" || strSecGroupBy == "Days Per Week" || strSecGroupBy == "Weeks Per Year" || strSecGroupBy == "Number of Lifts At Location")
                                            sbRecord.Append("<tr><td style='font-weight: bold;' align='right' >" + strSecGroupBy + ": " + string.Format("{0:N0}", strGroupByValue_2) + "</td></tr>");
                                        else
                                            sbRecord.Append("<tr><td style='font-weight: bold;' align='right' >" + strSecGroupBy + ": " + string.Format("{0:N2}", strGroupByValue_2) + "</td></tr>");
                                    }
                                }
                                else if (strFormatSecGroupBy == "datetime")
                                {
                                    sbRecord.Append("<tr><td style='font-weight: bold;' >" + strSecGroupBy + ": " + clsGeneral.FormatDBNullDateToDisplay(strGroupByValue_2) + "</td></tr>");
                                }
                                else sbRecord.Append("<tr><td style='font-weight: bold;' >&nbsp;" + strSecGroupBy + ": " + strGroupByValue_2 + "</td></tr>");
                            }
                            else if (Reader[strSecGroupBy] == DBNull.Value && strNOGroup2 == string.Empty)
                            {
                                strNOGroup2 = "No " + strSecGroupBy;
                                sbRecord.Append("<tr><td style='font-weight: bold;' >&nbsp;" + strSecGroupBy + ": " + strNOGroup2 + "</td></tr>");
                                //No Group by assign
                                strNOGroup2 = strGroupByValue_2;
                            }
                        }
                        string strColumnName = string.Empty;

                        ///Print Records
                        ///
                        bool IsAllNull = true;
                        //If All First Row is blank then not display in Export To Excel Data column
                        for (int intColumn = 0; intColumn < Reader.FieldCount; intColumn++)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(Reader[intColumn])))
                                IsAllNull = false;
                        }

                        if (IsAllNull == false)
                        {
                            sbRecord.Append("<tr>");
                            for (int intColumn = 0; intColumn < Reader.FieldCount; intColumn++)
                            {
                                #region " Count Sub Totals"
                                if (!string.IsNullOrEmpty(strFirstGroupBy) && !string.IsNullOrEmpty(strGroupByValue_1))
                                {
                                    if (dtSubTotalFirstGroup.Columns.Contains(Reader.GetName(intColumn)) && Convert.ToString(Reader[strFirstGroupBy]) == strGroupByValue_1)
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

                                if (!string.IsNullOrEmpty(strSecGroupBy) && !string.IsNullOrEmpty(strGroupByValue_2))
                                {
                                    if (dtSubTotalSecondGroup.Columns.Contains(Reader.GetName(intColumn)) && Convert.ToString(Reader[strSecGroupBy]) == strGroupByValue_2)
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
                                //Remove Group By Column
                                if (strFirstGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) && strSecGroupBy != Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]))
                                {
                                    strFormat = dtSchema.Rows[intColumn]["DataTypeName"].ToString();
                                    if (strFormat == "decimal")
                                    {
                                        // it display only Time
                                        //if (Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Amount Purchased" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Amount HW Generated Per Month" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Capcity(Tank)" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Capture Efficiency"
                                        //     || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Single Event Coverage" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Multiple Event Total Coverage" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Exit Temperature High"
                                        //    || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Exit Temperature Low" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Exit Flow Rate CFM" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Stack Height In Feet" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Control Efficiency")
                                        if (Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]).Contains("Cost") || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Discharge Limits" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Ending Inventory"
                                            || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Amount Used" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "State Local Fees")
                                        {
                                            sbRecord.Append("<td align='right'>" + string.Format("{0:C2}", Reader[intColumn]) + "</td>");
                                        }
                                        else
                                        {
                                            if (Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Number of Employees" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Number of Shift" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Days Per Week"
                                                || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Weeks Per Year" || Convert.ToString(dtSchema.Rows[intColumn]["ColumnName"]) == "Number of Lifts At Location")
                                                sbRecord.Append("<td align='right'>" + string.Format("{0:N0}", Reader[intColumn]) + "</td>");
                                            else
                                                sbRecord.Append("<td align='right'>" + string.Format("{0:N2}", Reader[intColumn]) + "</td>");
                                        }

                                    }
                                    else if (strFormat == "datetime")
                                    {
                                        sbRecord.Append("<td>" + string.Format("{0:MM/dd/yyyy}", Reader[intColumn]) + "</td>");
                                    }
                                    else
                                    {
                                        sbRecord.Append(@"<td style='mso-number-format:\@;'>" + Convert.ToString(Reader[intColumn]) + "</td>");
                                    }
                                }

                            }
                            sbRecord.Append("</tr>");
                        }

                        using (StreamWriter sw = File.AppendText(strPath))
                        {
                            sw.Write(sbRecord);
                            sbRecord = new StringBuilder(string.Empty);
                        }
                    } while (Reader.Read());

                    #region " SUBTOAL FOR Last groups "
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
                                    if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy)
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
                                    if (Convert.ToString(drSchema["ColumnName"]) != strFirstGroupBy && Convert.ToString(drSchema["ColumnName"]) != strSecGroupBy)
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
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Too Many Fields Are Selected As Output Field,Please Select Limited Number of Fields And Try Again');", true);

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
    /// Check Whether it is Grand TOtal FIeld or Not.
    /// </summary>
    /// <param name="strColumnName"></param>
    /// <returns></returns>
    private bool CheckTotalField(string strColumnName)
    {
        if ((strColumnName.Contains("Total Incurred") || strColumnName.Contains("Total Paid") || strColumnName.Contains("Total Outstanding")) || (strColumnName.EndsWith("Paid") || strColumnName.EndsWith("Recovery") || strColumnName.EndsWith("Reserve") || strColumnName.EndsWith("Incurred"))
             &&
            (strColumnName.StartsWith("Med/BI/Comp") || strColumnName.StartsWith("Expense") || strColumnName.StartsWith("Ind/PD/Coll") || strColumnName.StartsWith("Legal")))
        {
            return true;
        }

        return false;
    }

    #endregion

    #region "Save Report & Reload Report"

    /// <summary>
    /// Save AdHoc Report into database
    /// </summary>
    private void SaveReport()
    {
        Pollution_AdHocReport objAdHocReport = new Pollution_AdHocReport();
        objAdHocReport.ReportName = txtReportName.Text.Trim();

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

        objAdHocReport.OutputFields = this.GetAllItemString(lstSelectedFields, false);

        //if (ucRelativeDates_PriorVal.RelativeDate != AdHocReportHelper.RaltiveDates.NotSet)
        //    objAdHocReport.PriorValuation_RelativeDate = Convert.ToString((int)(ucRelativeDates_PriorVal.RelativeDate));
        //else
        // objAdHocReport.PriorValuationDate = clsGeneral.FormatNullDateToStore(txtPriorDate.Text);

        // objAdHocReport.GrandTotal = (chkGrandTotal.Checked) ? "Y" : "N";
        objAdHocReport.Updated_By = clsSession.UserName;
        objAdHocReport.Update_Date = System.DateTime.Now;
        decimal Pk_AdHocReport = 0;
        objAdHocReport.Pk_AdHocReport = hdnReportId.Value == string.Empty ? 0 : Convert.ToInt32(hdnReportId.Value);
        Pk_AdHocReport = objAdHocReport.Pk_AdHocReport.Value;

        if (hdnScheduleID.Value != "0")
            objAdHocReport.FK_Schedule = Convert.ToDecimal(hdnScheduleID.Value);

        if (objAdHocReport.Pk_AdHocReport.Value <= 0)
        {
            Pk_AdHocReport = objAdHocReport.Insert();
            hdnReportId.Value = Pk_AdHocReport.ToString();
        }
        else
            objAdHocReport.Update();

        // Bind Report Drop Down
        BindReportNameDropDown();

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
            Pollution_AdHocFilter.DeleteByFk_AdHocReport(Pk_AdHocReport);

            string strCriteria = string.Empty;
            strCriteria = GetFilterIDs(new DropDownList[] { drpFilter1, drpFilter2, drpFilter3, drpFilter4, drpFilter5, drpFilter6, drpFilter7, drpFilter8, drpFilter9, drpFilter10, });
            List<Pollution_AdhocReportFields> lstAdhoc = new List<Pollution_AdhocReportFields>();

            if (!string.IsNullOrEmpty(strCriteria))
                lstAdhoc = new Pollution_AdhocReportFields().GetAdHocReportFieldByMultipleID(strCriteria);

            decimal decValue;
            int iSelected;

            if (drpFilter1.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter1.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F1.SelectedValue, txtFilter1.Text, GetSelectedItemString(lst_F1, false), lstDate1.SelectedValue, txtDate_From1.Text, txtDate_To1.Text, drpAmount_F1.SelectedValue, txtAmount1_F1.Text, txtAmount2_F1.Text, ucRelativeDatesFrom_1.RelativeDate, ucRelativeDatesTo_1.RelativeDate);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter2.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter2.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F2.SelectedValue, txtFilter2.Text, GetSelectedItemString(lst_F2, false), lstDate2.SelectedValue, txtDate_From2.Text, txtDateTo2.Text, drpAmount_F2.SelectedValue, txtAmount1_F2.Text, txtAmount2_F2.Text, ucRelativeDatesFrom_2.RelativeDate, ucRelativeDatesTo_2.RelativeDate);
                // lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter3.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter3.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F3.SelectedValue, txtFilter3.Text, GetSelectedItemString(lst_F3, false), lstDate3.SelectedValue, txtDate_From3.Text, txtDate_To3.Text, drpAmount_F3.SelectedValue, txtAmount1_F3.Text, txtAmount2_F3.Text, ucRelativeDatesFrom_3.RelativeDate, ucRelativeDatesTo_3.RelativeDate);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter4.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter4.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F4.SelectedValue, txtFilter4.Text, GetSelectedItemString(lst_F4, false), lstDate4.SelectedValue, txtDate_From4.Text, txtDate_To4.Text, drpAmount_F4.SelectedValue, txtAmount1_F4.Text, txtAmount2_F4.Text, ucRelativeDatesFrom_4.RelativeDate, ucRelativeDatesTo_4.RelativeDate);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter5.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter5.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F5.SelectedValue, txtFilter5.Text, GetSelectedItemString(lst_F5, false), lstDate5.SelectedValue, txtDate_From5.Text, txtDate_To5.Text, drpAmount_F5.SelectedValue, txtAmount1_F5.Text, txtAmount2_F5.Text, ucRelativeDatesFrom_5.RelativeDate, ucRelativeDatesTo_5.RelativeDate);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter6.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter6.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F6.SelectedValue, txtFilter6.Text, GetSelectedItemString(lst_F6, false), lstDate6.SelectedValue, txtDate_From6.Text, txtDate_To6.Text, drpAmount_F6.SelectedValue, txtAmount1_F6.Text, txtAmount2_F6.Text, ucRelativeDatesFrom_6.RelativeDate, ucRelativeDatesTo_6.RelativeDate);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter7.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter7.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F7.SelectedValue, txtFilter7.Text, GetSelectedItemString(lst_F7, false), lstDate7.SelectedValue, txtDate_From7.Text, txtDate_To7.Text, txtAmount1_F7.Text, drpAmount_F7.SelectedValue, txtAmount2_F7.Text, ucRelativeDatesFrom_7.RelativeDate, ucRelativeDatesTo_7.RelativeDate);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter8.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter8.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F8.SelectedValue, txtFilter8.Text, GetSelectedItemString(lst_F8, false), lstDate8.SelectedValue, txtDate_From8.Text, txtDate_To8.Text, drpAmount_F8.SelectedValue, txtAmount1_F8.Text, txtAmount2_F8.Text, ucRelativeDatesFrom_8.RelativeDate, ucRelativeDatesTo_8.RelativeDate);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter9.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter9.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F9.SelectedValue, txtFilter9.Text, GetSelectedItemString(lst_F9, false), lstDate9.SelectedValue, txtDate_From9.Text, txtDate_To9.Text, drpAmount_F9.SelectedValue, txtAmount1_F9.Text, txtAmount2_F9.Text, ucRelativeDatesFrom_9.RelativeDate, ucRelativeDatesTo_9.RelativeDate);
                //lstAdhoc.RemoveAt(iSelected);
            }

            if (drpFilter10.SelectedIndex > 0)
            {
                decValue = Convert.ToDecimal(drpFilter10.SelectedItem.Value);
                iSelected = SearchList(decValue, lstAdhoc);
                SaveFilterCriteria(Pk_AdHocReport, lstAdhoc[iSelected].Pk_AdhocReportFields.Value, lstAdhoc[iSelected].Fk_ControlType.Value, drpText_F10.SelectedValue, txtFilter10.Text, GetSelectedItemString(lst_F10, false), lstDate10.SelectedValue, txtDate_From10.Text, txtDate_To10.Text, drpAmount_F10.SelectedValue, txtAmount1_F10.Text, txtAmount2_F10.Text, ucRelativeDatesFrom_10.RelativeDate, ucRelativeDatesTo_10.RelativeDate);
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
                                         string ListDate, string Date_From, string Date_To, string AmountWhere, string Amount1, string Amount2, AdHocReportHelper.RaltiveDates relativeFrom, AdHocReportHelper.RaltiveDates relativeTo)
    {
        Pollution_AdHocFilter objFilter = new Pollution_AdHocFilter();
        objFilter.FK_AdHocReport = Fk_AdHocReport;
        objFilter.FK_AdHocReportFields = FK_AdHocReportFields;

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
        objFilter.Insert();
    }

    /// <summary>
    /// Set Selected Value for AdHoc Report Filter
    /// </summary>
    /// <param name="objFilter"></param>
    /// <param name="drpFilter"></param>
    private void LoadFilterCriteria(Pollution_AdHocFilter objFilter, DropDownList drpFilter)
    {
        ListItem liSelected;

        // Check if Fk is not null
        if (objFilter.FK_AdHocReportFields.HasValue)
        {
            drpFilter.ClearSelection();
            // Find a value and then set it to selected
            liSelected = drpFilter.Items.FindByValue(objFilter.FK_AdHocReportFields.ToString());

            if (liSelected != null)
                liSelected.Selected = true;
        }
    }

    /// <summary>
    /// Fill Drop Down based on selected Filter Criteria
    /// </summary>
    private void LoadFilterControlDropDown(string Field_Header, string ConditionValue, ListBox lst_F)
    {
        lst_F.Items.Clear();
        if (Convert.ToString(Field_Header).ToLower().Trim() == "dealership dba")
        {
            ComboHelper.FillLocationdbaFranchiseReport(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "legal entity")
        {
            ComboHelper.FillDistinctLocationLegal_EntityList(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "sonic location code")
        {
            ComboHelper.FillLocationLocationCodeFranchiseReport(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "building state")
        {
            ComboHelper.FillStateByDesc(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "state (waste hauler)" || Convert.ToString(Field_Header).ToLower().Trim() == "state (receiving tsdf)"
             || Convert.ToString(Field_Header).ToLower().Trim() == "state(facility id)" || Convert.ToString(Field_Header).ToLower().Trim() == "state(utility provider)")
        {
            ComboHelper.FillStateList(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "building ownership")
        {
            ComboHelper.FillBuildingOwnerShip(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "building status")
        {
            ComboHelper.FillBuildingLocationStatus(new ListBox[] { lst_F }, false);
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "agency(facility id)")
        {
            ComboHelper.FillAgency(new ListBox[] { lst_F });
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "i.d type(facility id)")
        {
            ComboHelper.FillMedia(new ListBox[] { lst_F });
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "utility type(utility provider)")
        {
            ComboHelper.FillUtilityType(new ListBox[] { lst_F });
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "regulatory/notifying agency")
        {
            DataSet dsRA = LU_Regulatory_Notifying_Agency.SelectAll();
            dsRA.Tables[0].DefaultView.RowFilter = "Active='Y'";
            lst_F.Items.Clear();
            lst_F.DataSource = dsRA.Tables[0].DefaultView;
            lst_F.DataTextField = "Fld_Desc";
            lst_F.DataValueField = "PK_LU_Regulatory_Notifying_Agency";
            lst_F.DataBind();
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "hazardous waste codes")
        {
            DataSet dsHWCodes = LU_PM_Hazardous_Waste_Codes.SelectAll();
            dsHWCodes.Tables[0].DefaultView.RowFilter = "Active='Y'";
            lst_F.Items.Clear();
            lst_F.DataSource = dsHWCodes.Tables[0].DefaultView;
            lst_F.DataTextField = "Fld_Code";
            lst_F.DataValueField = "PK_LU_PM_Hazardous_Waste_Codes";
            lst_F.DataBind();
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "waste hauler (waste removal)")
        {
            DataSet dsWaste_Hauler = PM_Waste_Hauler.SelectAll();
            lst_F.DataSource = dsWaste_Hauler.Tables[0];
            lst_F.DataTextField = "Waste_Hauler_Name";
            lst_F.DataValueField = "PK_PM_Waste_Hauler";
            lst_F.DataBind();
            lst_F.Items.Insert(0, new ListItem("-- select --", "0"));
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "receiving tsdf (waste removal)")
        {
            DataSet dsReceiving = PM_Receiving_TSDF.SelectAll();
            lst_F.DataSource = dsReceiving.Tables[0];
            lst_F.DataTextField = "Receiving_TSDF_Name";
            lst_F.DataValueField = "PK_PM_Receiving_TSDF";
            lst_F.DataBind();
            lst_F.Items.Insert(0, new ListItem("-- select --", "0"));
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "pure mixture(chemical)" || Convert.ToString(Field_Header).ToLower().Trim() == "pure mixture(paint)")
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Pure", "P"));
            liItem.Add(new ListItem("Mixture", "M"));

            lst_F.Items.Clear();
            for (int i = 0; i < liItem.Count; i++)
            {
                lst_F.Items.Add((ListItem)liItem[i]);
            }
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "physical state")
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Solid", "S"));
            liItem.Add(new ListItem("Liquid", "L"));
            liItem.Add(new ListItem("Gas", "G"));

            lst_F.Items.Clear();
            for (int i = 0; i < liItem.Count; i++)
            {
                lst_F.Items.Add((ListItem)liItem[i]);
            }
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "direct or indirect burners?(paint booth)" || Convert.ToString(Field_Header).ToLower().Trim() == "direct or indirect burners? (prep station)")
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Direct", "D"));
            liItem.Add(new ListItem("Indirect", "I"));

            lst_F.Items.Clear();
            for (int i = 0; i < liItem.Count; i++)
            {
                lst_F.Items.Add((ListItem)liItem[i]);
            }
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "ground location?")
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("On Surface", "S"));
            liItem.Add(new ListItem("Underground", "U"));

            lst_F.Items.Clear();
            for (int i = 0; i < liItem.Count; i++)
            {
                lst_F.Items.Add((ListItem)liItem[i]);
            }
        }
        else if (Convert.ToString(Field_Header).Trim() == "Status(Hydraulic Lift)" || Convert.ToString(Field_Header).ToLower().Trim() == "status(tank)")
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Active", "A"));
            liItem.Add(new ListItem("Non-Active", "N"));
            liItem.Add(new ListItem("Removed", "R"));

            lst_F.Items.Clear();
            for (int i = 0; i < liItem.Count; i++)
            {
                lst_F.Items.Add((ListItem)liItem[i]);
            }
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "voc month")
        {
            ComboHelper.BindMonth(lst_F);
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "voc year")
        {
            ComboHelper.FillSedgwickYear(new ListBox[] { lst_F });
        }
        else if (Convert.ToString(Field_Header).ToLower().Trim() == "voc paint category")
        {
            // ComboHelper.FillPaintCategory(lst_F, false);
            DataTable dtData = ERIMS.DAL.clsLU_VOC_Category.SelectAll().Tables[0];
            dtData.DefaultView.RowFilter = " Active = 'Y' ";
            dtData = dtData.DefaultView.ToTable();
            lst_F.Items.Clear();
            lst_F.DataSource = dtData;
            lst_F.DataTextField = "Category";
            lst_F.DataValueField = "PK_LU_VOC_Category";
            lst_F.DataBind();
        }
        else
            AdHocReportHelper.FillFilterDropDown(Field_Header, new ListBox[] { lst_F }, false, "Polluton");

        //Set ListBox ToolTip
        //clsGeneral.SetListBoxToolTip(new ListBox[] { lst_F });
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
    private void LoadFilterControlAmount(Pollution_AdHocFilter objFilter, Panel pnlAmount_F, DropDownList drpAmount_F, TextBox txtAmount1_F, TextBox txtAmount2_F, Label lblAmountText1_F, Label lblAmountText2_F, CompareValidator cvAmount, DropDownList drpFilter)
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
        drpAmount_Changed(true, drpAmount_F, lblAmountText1_F, txtAmount1_F, lblAmountText2_F, txtAmount2_F, cvAmount, drpFilter);
        txtAmount1_F.Text = string.Format("{0:N2}", objFilter.AmountFrom);
        txtAmount2_F.Text = string.Format("{0:N2}", objFilter.AmountTo);
    }

    /// <summary>
    /// Bind Date Filter Criteria from database
    /// </summary>
    private void LoadFilterControlDate(Pollution_AdHocFilter objFilter, Panel pnlDate_F, DropDownList rdbCommon, Label lbl1, Label lbl2, TextBox txt1, TextBox txt2, HtmlImage img2, RegularExpressionValidator revDateTo, ASP.controls_relativedate_relativedate_ascx ucRelativeDatesFrom, ASP.controls_relativedate_relativedate_ascx ucRelativeDatesTo, HtmlImage img1)
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
                    drpSortingFirst.Items.Add(new ListItem(li.Text, li.Value));
                    drpSortingSecond.Items.Add(new ListItem(li.Text, li.Value));
                    drpSortingThird.Items.Add(new ListItem(li.Text, li.Value));
                }
            }

            // Clear all Filter and Sort By Drop Down
            drpGroupByFirst.ClearSelection();
            drpGroupBySecond.ClearSelection();
            drpSortingFirst.ClearSelection();
            drpSortingSecond.ClearSelection();
            drpSortingThird.ClearSelection();
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
    protected void lnkGenerateReport_Click(object sender, EventArgs e)
    {
        Response.Redirect(AppConfig.SiteURL + "UserAccessRequest/rptVOCEmissions.aspx");
    }
}
