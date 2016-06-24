using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Text;
using System.IO;

public partial class SONIC_ClaimInfo_rptFROIRecap : clsBasePage
{
    #region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDown();
            lblDate.Text = DateTime.Now.ToShortDateString();
        }
    }

    #endregion

    #region " Methods "

    private void BindDropDown()
    {
        ComboHelper.FillRegionListBox(new ListBox[] { lstRegions }, false);
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
        ComboHelper.FillLocationdba(new ListBox[] { lstRMLocationNumber }, 0, false);
    }

    #endregion

    #region " Events "

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection
        Response.Redirect("rptFROIRecap.aspx", false);
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        pnlReport.Visible = true;
        pnlReportCriteria.Visible = false;
        string strRegion = "";
        // get selected regions
        foreach (ListItem itmRegion in lstRegions.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + "'" + itmRegion.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        string strMarket = "";
        string strMarketText = "";
        // get selected Markets
        foreach (ListItem itmMarket in lstMarket.Items)
        {
            if (itmMarket.Selected)
                strMarket = strMarket + "" + itmMarket.Value + ",";
                strMarketText = strMarketText + "" + itmMarket.Text + ",";
        }
        strMarket = strMarket.TrimEnd(',');
        strMarketText = strMarketText.TrimEnd(',');

        string strDBA = "";
        // get selected regions
        foreach (ListItem itmdba in lstRMLocationNumber.Items)
        {
            if (itmdba.Selected)
                strDBA = strDBA + "'" + itmdba.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[0] + "',";
        }
        strDBA = strDBA.TrimEnd(',');

        string strCategory = "";
        // get selected regions
        foreach (ListItem itmCat in lstCategory.Items)
        {
            if (itmCat.Selected)
                strCategory = strCategory + itmCat.Value + ",";
        }
        strCategory = strCategory.TrimEnd(',');

        if (string.IsNullOrEmpty(strCategory))
        {
            strCategory = "AL,DPD,NS,PL,Property,WC";
            lblFirstRepotCategory.Text = "All";
        }
        else
        {
            lblFirstRepotCategory.Text = strCategory;
        }

        if (string.IsNullOrEmpty(strRegion))
            lblRegion.Text = "All";
        else
            lblRegion.Text = strRegion.Replace("'", "");

        if (string.IsNullOrEmpty(strMarket))
            lblMarket.Text = "All";
        else
            lblMarket.Text = strMarketText;

        if (string.IsNullOrEmpty(strDBA))
            lblLocationDBA.Text = "All";
        else
            lblLocationDBA.Text = strDBA.Replace("'", "");


        DateTime? IncidentBeginDate = null, IncidentEndDate = null;
        if (!string.IsNullOrEmpty(txtIncidentBeginDate.Text) && !string.IsNullOrEmpty(txtIncidentEndDate.Text))
        {
            IncidentBeginDate = clsGeneral.FormatNullDateToStore(txtIncidentBeginDate.Text);
            IncidentEndDate = clsGeneral.FormatNullDateToStore(txtIncidentEndDate.Text);
            lblIncidentBeginDate.Text = txtIncidentBeginDate.Text;
            lblIncidentEndDate.Text = txtIncidentEndDate.Text;
        }
        else
        {
            lblIncidentBeginDate.Text = string.Empty;
            lblIncidentEndDate.Text = string.Empty;
        }
        DataSet ds = clsClaimReports.GetFroiRecapReport(strRegion, strMarket, strDBA, IncidentBeginDate, IncidentEndDate, strCategory);
        Session["dsFROIRecap"]= ds;
        for (int i = 0; i < ds.Tables.Count; i = i + 2)
        {
            string strReportType = ds.Tables[i].Rows[0][0].ToString();
            switch (strReportType)
            {
                case "AL":
                    pnlAL_FR.Visible = true;
                    gvAL_FR.DataSource = ds.Tables[i + 1];
                    gvAL_FR.DataBind();
                    if (ds.Tables[i + 1].Rows.Count > 0)
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "AL_MakeStaticHeader", "<script>MakeStaticHeader('" + gvAL_FR.ClientID + "','AL_DivHeaderRow','AL_DivMainContent', 440, 990 , 60 ,false); </script>", false);
                    else
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "AL_MakeStaticHeader", "<script>MakeStaticHeader('" + gvAL_FR.ClientID + "','AL_DivHeaderRow','AL_DivMainContent', 50, 990 , 60 ,false); </script>", false);

                    break;
                case "DPD":
                    pnlDPD_FR.Visible = true;
                    gvDPD_FR.DataSource = ds.Tables[i + 1];
                    gvDPD_FR.DataBind();
                    if (ds.Tables[i + 1].Rows.Count > 0)
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "DPD_MakeStaticHeader", "<script>MakeStaticHeader('" + gvDPD_FR.ClientID + "','DPD_DivHeaderRow','DPD_DivMainContent',440, 990 , 61 ,false); </script>", false);
                    else
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "DPD_MakeStaticHeader", "<script>MakeStaticHeader('" + gvDPD_FR.ClientID + "','DPD_DivHeaderRow','DPD_DivMainContent',50, 990 , 61 ,false); </script>", false);


                    if (ds.Tables[i].Rows[0][1].ToString() == "Yes")
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "DPD_ALERT", "alert('This report is not configured to run on the DPD FROI data structure prior to September 15, 2014.');", true);
                    break;
                case "NS":
                    pnlNS_FR.Visible = true;
                    gvNS_FR.DataSource = ds.Tables[i + 1];
                    gvNS_FR.DataBind();
                    if (ds.Tables[i + 1].Rows.Count > 0)
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "NS_MakeStaticHeader", "<script>MakeStaticHeader('" + gvNS_FR.ClientID + "','NS_DivHeaderRow','NS_DivMainContent', 440, 990 , 48 ,false); </script>", false);
                    else
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "NS_MakeStaticHeader", "<script>MakeStaticHeader('" + gvNS_FR.ClientID + "','NS_DivHeaderRow','NS_DivMainContent', 50, 990 , 48 ,false); </script>", false);
                    break;
                case "PL":
                    pnlPL_FR.Visible = true;
                    gvPL_FR.DataSource = ds.Tables[i + 1];
                    gvPL_FR.DataBind();
                    if (ds.Tables[i + 1].Rows.Count > 0)
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "PL_MakeStaticHeader", "<script>MakeStaticHeader('" + gvPL_FR.ClientID + "','PL_DivHeaderRow','PL_DivMainContent', 440, 990 , 35 ,false); </script>", false);
                    else
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "PL_MakeStaticHeader", "<script>MakeStaticHeader('" + gvPL_FR.ClientID + "','PL_DivHeaderRow','PL_DivMainContent', 50, 990 , 35 ,false); </script>", false);
                    break;
                case "Property":
                    pnlProperty_FR.Visible = true;
                    gvProperty_FR.DataSource = ds.Tables[i + 1];
                    gvProperty_FR.DataBind();
                    if (ds.Tables[i + 1].Rows.Count > 0)
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Property_MakeStaticHeader", "<script>MakeStaticHeader('" + gvProperty_FR.ClientID + "','Property_DivHeaderRow','Property_DivMainContent', 440, 990 , 60 ,false); </script>", false);
                    else
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Property_MakeStaticHeader", "<script>MakeStaticHeader('" + gvProperty_FR.ClientID + "','Property_DivHeaderRow','Property_DivMainContent', 50, 990 , 60 ,false); </script>", false);
                    break;
                case "WC":
                    pnlWC_FR.Visible = true;
                    gvWC_FR.DataSource = ds.Tables[i + 1];
                    gvWC_FR.DataBind();
                    if (ds.Tables[i + 1].Rows.Count > 0)
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "WC_MakeStaticHeader", "<script>MakeStaticHeader('" + gvWC_FR.ClientID + "','WC_DivHeaderRow','WC_DivMainContent', 440, 990 , 48 ,false); </script>", false);
                    else
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "WC_MakeStaticHeader", "<script>MakeStaticHeader('" + gvWC_FR.ClientID + "','WC_DivHeaderRow','WC_DivMainContent', 50, 990 , 48 ,false); </script>", false);
                    break;
            }


        }


        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key1", "<script>MakeStaticHeader('" + GridView1.ClientID + "', 400, 990 , 60 ,false); </script>", false);
    }

    protected void lstRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strRegion = string.Empty;
        foreach (ListItem li in lstRegions.Items)
        {
            if (li.Selected)
                strRegion = strRegion + li.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');
        ComboHelper.FillLocationdbaByRegion(new ListBox[] { lstRMLocationNumber }, 0, false, strRegion);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlReport.Visible = false;
        pnlReportCriteria.Visible = true;

        pnlAL_FR.Visible = false;
        gvAL_FR.DataSource = null;
        gvAL_FR.DataBind();

        pnlDPD_FR.Visible = false;
        gvDPD_FR.DataSource = null;
        gvDPD_FR.DataBind();

        pnlNS_FR.Visible = false;
        gvNS_FR.DataSource = null;
        gvNS_FR.DataBind();

        pnlPL_FR.Visible = false;
        gvPL_FR.DataSource = null;
        gvPL_FR.DataBind();

        pnlProperty_FR.Visible = false;
        gvProperty_FR.DataSource = null;
        gvProperty_FR.DataBind();

        pnlWC_FR.Visible = false;
        gvWC_FR.DataSource = null;
        gvWC_FR.DataBind();
    }

    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        if (Session["dsFROIRecap"] != null)
        {
            DataSet dsResult = (DataSet)Session["dsFROIRecap"];

            StringBuilder strHTML = new StringBuilder();
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

            #region "Report Title"

            strHTML.Append("<br />");
            strHTML.Append("<b>Report Title : FROI Recap Report</b>");
            strHTML.Append("<br /><br />");

            //Add Report Filter Criteria 
            strHTML.Append("<br /><br />");
            strHTML.Append("<b>Report Filters </b>");
            strHTML.Append("<br /><table> <tr> <td colspan='11'>");
            strHTML.Append("Date   : " + lblDate.Text);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='11'>");
            strHTML.Append("Region   : " + lblRegion.Text);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='11'>");
            strHTML.Append("Market   : " + lblMarket.Text);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='11'>");
            strHTML.Append("Location D/B/A   : " + lblLocationDBA.Text);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='11'>");
            strHTML.Append("Date of Incident From   : " + lblIncidentBeginDate.Text);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='11'>");
            strHTML.Append("Date of Incident To   : " + lblIncidentEndDate.Text);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='11'>");
            strHTML.Append("First Report Category   : " + lblFirstRepotCategory.Text);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='11'>");
            strHTML.Append("</td></tr></table> ");

            #endregion

            #region "Report Grid header"
            //Top Header
            strHTML.Append("<table border='1'>");
            strHTML.Append("<tr style='font-weight: bold;' valign='bottom' align='left'>");
            strHTML.Append("<td align='left' >Sonic Automotive</td>");
            strHTML.Append("<td align='center' colspan='9'>FROI Recap Report</td>");
            strHTML.Append("<td align='right' > " + DateTime.Now.ToString() + " </td>");
            strHTML.Append("</tr>");
            strHTML.Append("</table>");




            for (int i = 0; i < dsResult.Tables.Count; i = i + 2)
            {
                string strReportType = dsResult.Tables[i].Rows[0][0].ToString();
                DataTable dtTemp = new DataTable();
                switch (strReportType)
                {
                    case "AL":
                        #region Generate AL region
                        strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td><b>AL FROI</b></td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("</table>");
                        //Sub Header
                        strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td width='150'>Location</td>");
                        strHTML.Append("<td width='100'>Location Number</td>");
                        strHTML.Append("<td width='120'>FROI Number</td>");
                        strHTML.Append("<td width='100'>Date Of Loss</td>");
                        strHTML.Append("<td width='250'>Description of Loss</td>");
                        strHTML.Append("<td width='50' align='center'>Vehicle SubType<br style=\"mso-data-placement:same-cell;\">Vehicle Make<br style=\"mso-data-placement:same-cell;\">Vehicle Model<br style=\"mso-data-placement:same-cell;\">Vehicle Year</td>");
                        strHTML.Append("<td width='50'>Were Policed Notified?</td>");
                        strHTML.Append("<td width='50'>Is there a Security Video<br style=\"mso-data-placement:same-cell;\">Surveillance System?</td>");
                        strHTML.Append("<td width='250'>Comments</td>");
                        strHTML.Append("</tr>");
                        dtTemp = dsResult.Tables[i + 1];
                        if (dtTemp.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtTemp.Rows)
                            {
                                strHTML.Append("<tr valign='top'>");
                                strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["AL_FR_Number"]) + "</td>");
                                strHTML.Append("<td >" + clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Loss"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Description_Of_Loss"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Vehicle"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Were_Police_Notified"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Security_Video_System"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                strHTML.Append("</tr>");
                            }
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        #endregion
                        break;
                    case "DPD":
                        #region Generate DPD region
                        strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td><b>DPD FROI</b></td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("</table>");
                        //Sub Header

                        strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td width='150'>Location</td>");
                        strHTML.Append("<td width='100'>Location Number</td>");
                        strHTML.Append("<td width='120'>FROI Number</td>");
                        strHTML.Append("<td width='100'>Date Of Loss</td>");
                        strHTML.Append("<td width='100'>Cause Of Loss</td>");
                        strHTML.Append("<td width='250'>Loss Description</td>");
                        strHTML.Append("<td width='80' align='center'>Vehicle Make<br style=\"mso-data-placement:same-cell;\">Vehicle Model<br style=\"mso-data-placement:same-cell;\">Vehicle Year<br style=\"mso-data-placement:same-cell;\">Invoice Value</td>");
                        strHTML.Append("<td width='80'>Were Policed Notified?</td>");
                        strHTML.Append("<td width='80'>Is there a Security Video<br style=\"mso-data-placement:same-cell;\">Surveillance System?</td>");
                        strHTML.Append("<td width='100'>Recovered<br style=\"mso-data-placement:same-cell;\">Damage Amount<br style=\"mso-data-placement:same-cell;\">Recovered Amount</td>");
                        strHTML.Append("<td width='250'>Comments</td>");
                        strHTML.Append("</tr>");
                        dtTemp = dsResult.Tables[i + 1];
                        if (dtTemp.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtTemp.Rows)
                            {
                                strHTML.Append("<tr valign='top'>");
                                strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["DPD_FR_Number"]) + "</td>");
                                strHTML.Append("<td >" + clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Loss"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Cause_Of_Loss"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Loss_Description"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Vehicle"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Were_Police_Notified"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Security_Video_System"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Recovered"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                strHTML.Append("</tr>");
                            }
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");
                        #endregion
                        break;
                    case "NS":
                        #region Generate NS region

                        strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td><b>NS FROI</b></td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("</table>");
                        //Sub Header

                        strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td width='150'>Location</td>");
                        strHTML.Append("<td width='100'>Location Number</td>");
                        strHTML.Append("<td width='120'>FROI Number</td>");
                        strHTML.Append("<td width='120'>Associate Name</td>");
                        strHTML.Append("<td width='100'>Date Of Loss</td>");
                        strHTML.Append("<td width='300'>Description Of Incident</td>");
                        strHTML.Append("<td width='100'>Taken By Emergency Transportation?</td>");
                        strHTML.Append("<td width='250'>Comments</td>");
                        strHTML.Append("</tr>");
                        dtTemp = dsResult.Tables[i + 1];
                        if (dtTemp.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtTemp.Rows)
                            {
                                strHTML.Append("<tr valign='top'>");
                                strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["WC_FR_Number"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Associate_Name"]) + "</td>");
                                strHTML.Append("<td >" + clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Incident"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Description_Of_Incident"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Taken_By_Emergency_Transportation"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                strHTML.Append("</tr>");
                            }
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        #endregion
                        break;
                    case "PL":
                        #region Generate PL region

                        strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td><b>PL FROI</b></td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("</table>");
                        //Sub Header
                        strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td width='150'>Location</td>");
                        strHTML.Append("<td width='100'>Location Number</td>");
                        strHTML.Append("<td width='120'>FROI Number</td>");
                        strHTML.Append("<td width='100'>Date Of Loss</td>");
                        strHTML.Append("<td width='300'>Description Of Loss</td>");
                        strHTML.Append("<td width='80'>Were Policed Notified?</td>");
                        strHTML.Append("<td width='250'>Comments</td>");
                        strHTML.Append("</tr>");
                        dtTemp = dsResult.Tables[i + 1];
                        if (dtTemp.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtTemp.Rows)
                            {
                                strHTML.Append("<tr valign='top'>");
                                strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["PL_FR_Number"]) + "</td>");
                                strHTML.Append("<td >" + clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Loss"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Description_of_Loss"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Were_Police_Notified"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                strHTML.Append("</tr>");
                            }
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        #endregion
                        break;
                    case "Property":
                        #region Generate Property region

                        strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td><b>Property FROI</b></td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("</table>");
                        //Sub Header
                        strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td width='150'>Location</td>");
                        strHTML.Append("<td width='100'>Location Number</td>");
                        strHTML.Append("<td width='120'>FROI Number</td>");
                        strHTML.Append("<td width='100'>Date Of Loss</td>");
                        strHTML.Append("<td width='120'>Type Of Loss</td>");
                        strHTML.Append("<td width='300'>Description Of Loss</td>");
                        strHTML.Append("<td width='120'>Total Estimated Cost</td>");
                        strHTML.Append("<td width='100'>Is there a Security Video<br style=\"mso-data-placement:same-cell;\">Surveillance System?</td>");
                        strHTML.Append("<td width='250'>Comments</td>");
                        strHTML.Append("</tr>");
                        dtTemp = dsResult.Tables[i + 1];
                        if (dtTemp.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtTemp.Rows)
                            {
                                strHTML.Append("<tr valign='top'>");
                                strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Property_FR_Number"]) + "</td>");
                                strHTML.Append("<td >" + clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Loss"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Type_of_Loss"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Description_of_Loss"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Estimated_Cost"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Security_Video_Surveillance"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                strHTML.Append("</tr>");
                            }
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        #endregion
                        break;
                    case "WC":
                        #region Generate WC region

                        strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("<tr><td><b>WC FROI</b></td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td></tr>");
                        strHTML.Append("</table>");
                        //Sub Header
                        strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td width='150'>Location</td>");
                        strHTML.Append("<td width='100'>Location Number</td>");
                        strHTML.Append("<td width='120'>FROI Number</td>");
                        strHTML.Append("<td width='120'>Associate Name</td>");
                        strHTML.Append("<td width='100'>Date Of Loss</td>");
                        strHTML.Append("<td width='300'>Description Of Incident</td>");
                        strHTML.Append("<td width='100'>Taken By Emergency<br style=\"mso-data-placement:same-cell;\">Transportation?</td>");
                        strHTML.Append("<td width='250'>Comments</td>");
                        strHTML.Append("</tr>");
                        dtTemp = dsResult.Tables[i + 1];
                        if (dtTemp.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtTemp.Rows)
                            {
                                strHTML.Append("<tr valign='top'>");
                                strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["WC_FR_Number"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Associate_Name"]) + "</td>");
                                strHTML.Append("<td >" + clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Incident"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Description_Of_Incident"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Taken_By_Emergency_Transportation"]) + "</td>");
                                strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                strHTML.Append("</tr>");
                            }
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        #endregion
                        break;
                }


            }


            #endregion

            //Write HTML in to HtmlWriter
            htmlWrite.WriteLine(strHTML.ToString());

            MemoryStream memorystream = new MemoryStream();
            byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString());
            memorystream.Write(_bytes, 0, _bytes.Length);
            memorystream.Seek(0, SeekOrigin.Begin);
            
            String strPath = String.Empty, data = String.Empty, outputFiles = String.Empty;
            strPath = AppConfig.SitePath + @"temp\" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            if (!File.Exists(strPath))
            {
                if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
                    Directory.CreateDirectory(AppConfig.SitePath + @"temp\");
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(strPath))
                {
                    sw.Write(stringWrite.ToString());
                }
            }

            data = File.ReadAllText(strPath);
            data = data.Trim();
            HTML2Excel objHtml2Excel = new HTML2Excel(data);
            outputFiles = Path.GetFullPath(strPath) + ".xlsx";
            bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);

            if (blnHTML2Excel)
            {
                try
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"FROI_Recap_Report.xlsx\""));
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    HttpContext.Current.Response.TransmitFile(outputFiles);
                    HttpContext.Current.Response.Flush();
                }
                finally
                {
                    if (File.Exists(outputFiles))
                        File.Delete(outputFiles);
                    if (File.Exists(strPath))
                       File.Delete(strPath);
                    HttpContext.Current.Response.End();
                }
            }
        }
    }
    #endregion
}