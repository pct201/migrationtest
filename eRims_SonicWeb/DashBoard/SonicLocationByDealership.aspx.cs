using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class DashBoard_SonicLocationByDealership : clsBasePage
{
    #region ViewState
    private decimal Pk_State
    {
        get { return Convert.ToDecimal(ViewState["Pk_State"]); }
        set { ViewState["Pk_State"] = value; }
    }

    private decimal FIPS_county
    {
        get { return Convert.ToDecimal(ViewState["FIPS_county"]); }
        set { ViewState["FIPS_county"] = value; }
    }
    #endregion

    #region PageLoad
    /// <summary>
    /// Handles page load Event of Sonic Location Dealership
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["state"]))
            {
                Pk_State = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["state"]));
            }
            if (!string.IsNullOrEmpty(Request.QueryString["county"]))
            {
                FIPS_county = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["county"]));
            }
            if (!string.IsNullOrEmpty(Request.QueryString["Sname"]) && !string.IsNullOrEmpty(Request.QueryString["Cname"]))
            {
                lblState.Text = Encryption.Decrypt(Request.QueryString["Sname"]).ToString() + ", " + Encryption.Decrypt(Request.QueryString["Cname"]).ToString();
            }
            BindSonicLocationGrid();
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// bind Grid For Sonic Location
    /// </summary>
    private void BindSonicLocationGrid()
    {
        DataTable dtSonicLocation = Maps.GetSonicLocationsByState(Pk_State, FIPS_county);
        gvSonicLocation.DataSource = dtSonicLocation;
        gvSonicLocation.DataBind();
    }
    #endregion

    #region Grid Events
    /// <summary>
    /// handles row data bound event of grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSonicLocation_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string[] strBuilding, FROIsLast, FROIsCurr, OpenClaim, LastInspectionDate, LastMeetingDate;
            string BuildingAppend = "", FROIsLastAppend = "", FROIsCurrAppend = "", OpenClaimAppend = "";
            string[] Splitter = { "<br/>" };

            DataRowView drv = (DataRowView)e.Row.DataItem;
            // Split <br/> from the data row
            strBuilding = drv["Building"].ToString().Split(Splitter, StringSplitOptions.None);
            FROIsLast = drv["FROIsLastMonth"].ToString().Split(Splitter, StringSplitOptions.None);
            FROIsCurr = drv["FROIsCurrMonth"].ToString().Split(Splitter, StringSplitOptions.None);
            OpenClaim = drv["OpenClaim"].ToString().Split(Splitter, StringSplitOptions.None);
            LastInspectionDate = drv["LastInspectionDate"].ToString().Split(Splitter, StringSplitOptions.None);
            LastMeetingDate = drv["LastSLTDateMeeting"].ToString().Split(Splitter, StringSplitOptions.None);

            //for loop to get building's data
            for (int i = 0; i < strBuilding.Length; i++)
            {
                //Spit data from strBuilding by "|" and genereate hyperlink
                string[] PK_Building;
                PK_Building = strBuilding[i].Split('|');
                if (PK_Building[0] != "" && PK_Building[1] != "" && PK_Building[2] != "" && PK_Building[3] != "")
                {
                    if (Convert.ToInt32(PK_Building[3]) > 0)
                    {
                        BuildingAppend += "<a href=\"javascript:OpenBuildingRelatedinforPopup('" + Encryption.Encrypt(PK_Building[0].ToString()) + "','" + Encryption.Encrypt(PK_Building[1].ToString()) + "','" + Encryption.Encrypt(PK_Building[3].ToString()) + " ');\">" + PK_Building[2].ToString() + "</a><br/>";
                    }
                    else
                    {
                        BuildingAppend += "<a href=\"javascript:OpenBuilding_Number('" + Encryption.Encrypt(PK_Building[0].ToString()) + "','" + Encryption.Encrypt(PK_Building[1].ToString()) + " ');\">" + PK_Building[2].ToString() + "</a><br/>";
                    }
                    HtmlGenericControl dvmainBuilding = (HtmlGenericControl)e.Row.FindControl("dvBuilding");
                    dvmainBuilding.InnerHtml = BuildingAppend;
                }
            }
            //for loop to get FROIsLast Month's data
            for (int j = 0; j < FROIsLast.Length; j++)
            {
                //Spit data from FROIsLast by "|" and make url for appropriate First report type and genereate hyperlink
                string strFROILasturl = "";
                string[] PK_FROIsLast;
                PK_FROIsLast = FROIsLast[j].Split('|');
                if (PK_FROIsLast[0] != "" && PK_FROIsLast[1] != "" && PK_FROIsLast[2] != "" && PK_FROIsLast[3] != "")
                {
                    switch (PK_FROIsLast[0])
                    {
                        case "NS": strFROILasturl = "WCFirstReport.aspx"; break;
                        case "WC": strFROILasturl = "WCFirstReport.aspx"; break;
                        case "AL": strFROILasturl = "ALFirstReport.aspx"; break;
                        case "DPD": strFROILasturl = "DPDFirstReport.aspx"; break;
                        case "PL": strFROILasturl = "PLFirstReport.aspx"; break;
                        case "Property": strFROILasturl = "PropertyFirstReport.aspx"; break;
                    }
                    strFROILasturl = strFROILasturl + "?id=" + Encryption.Encrypt(PK_FROIsLast[1].ToString()) + "&WZ_ID=" + Encryption.Encrypt(PK_FROIsLast[3].ToString());
                    HtmlGenericControl dvFROILastMonth = (HtmlGenericControl)e.Row.FindControl("dvFROILastMonth");
                    FROIsLastAppend += "<a href=\"javascript:OpenFROIsLastMonth('" + strFROILasturl + "');\">" + PK_FROIsLast[2].ToString() + "</a>" + "<br/>";
                    dvFROILastMonth.InnerHtml = FROIsLastAppend;
                }
            }
            //for loop to get FROIsCurr Month's data
            for (int k = 0; k < FROIsCurr.Length; k++)
            {
                //Spit data from OpenClaim by "|" and make url for appropriate First Report type and genereate hyperlink
                string strFROIsThisurl = "";
                string[] PK_FROIsThis;
                PK_FROIsThis = FROIsCurr[k].Split('|');
                if (PK_FROIsThis[0] != "" && PK_FROIsThis[1] != "" && PK_FROIsThis[2] != "" && PK_FROIsThis[3] != "")
                {
                    switch (PK_FROIsThis[0])
                    {
                        case "NS": strFROIsThisurl = "WCFirstReport.aspx"; break;
                        case "WC": strFROIsThisurl = "WCFirstReport.aspx"; break;
                        case "AL": strFROIsThisurl = "ALFirstReport.aspx"; break;
                        case "DPD": strFROIsThisurl = "DPDFirstReport.aspx"; break;
                        case "PL": strFROIsThisurl = "PLFirstReport.aspx"; break;
                        case "Property": strFROIsThisurl = "PropertyFirstReport.aspx"; break;
                    }
                    strFROIsThisurl = strFROIsThisurl + "?id=" + Encryption.Encrypt(PK_FROIsThis[1].ToString()) + "&WZ_ID=" + Encryption.Encrypt(PK_FROIsThis[3].ToString());
                    HtmlGenericControl dvFROIThisMonth = (HtmlGenericControl)e.Row.FindControl("dvFROIThisMonth");
                    FROIsCurrAppend += "<a href=\"javascript:OpenFROIsCurrMonth('" + strFROIsThisurl + "');\">" + PK_FROIsThis[2].ToString() + "</a>" + "<br/>";
                    dvFROIThisMonth.InnerHtml = FROIsCurrAppend;
                }
            }
            //for loop to get Open claims data
            for (int l = 0; l < OpenClaim.Length; l++)
            {
                //Spit data from FROIsCurr by "|" and make url for appropriate claim report type and genereate hyperlink
                string strOpenClaimurl = "";
                string[] PK_OpenClaim;
                PK_OpenClaim = OpenClaim[l].Split('|');
                if (PK_OpenClaim[0] != "" && PK_OpenClaim[1] != "" && PK_OpenClaim[2] != "")
                {
                    switch (PK_OpenClaim[0])
                    {
                        case "NS": strOpenClaimurl = "WCClaimInfo.aspx"; break;
                        case "WC": strOpenClaimurl = "WCClaimInfo.aspx"; break;
                        case "AL": strOpenClaimurl = "ALClaimInfo.aspx"; break;
                        case "DPD": strOpenClaimurl = "DPDClaimInfo.aspx"; break;
                        case "PL": strOpenClaimurl = "PLClaimInfo.aspx"; break;
                        case "Property": strOpenClaimurl = "PropertyClaimInfo.aspx"; break;
                    }
                    strOpenClaimurl = strOpenClaimurl + "?id=" + Encryption.Encrypt(PK_OpenClaim[1].ToString());
                    HtmlGenericControl dvOpenClaims = (HtmlGenericControl)e.Row.FindControl("dvOpenClaims");
                    OpenClaimAppend += "<a href=\"javascript:OpenClaim('" + strOpenClaimurl + "');\">" + PK_OpenClaim[2].ToString() + "</a>" + "<br/>";
                    dvOpenClaims.InnerHtml = OpenClaimAppend;
                }
            }
            //for loop to get inspection date
            for (int m = 0; m < LastInspectionDate.Length; m++)
            {
                //Spit data from LastInspectionDate by "|" and generates hyperlink
                string[] PK_LastInspectionDate;
                PK_LastInspectionDate = LastInspectionDate[m].Split('|');
                if (PK_LastInspectionDate[0] != "" && PK_LastInspectionDate[1] != "")
                {
                    HtmlGenericControl dvLastInspectionDate = (HtmlGenericControl)e.Row.FindControl("dvLastInspectionDate");
                    dvLastInspectionDate.InnerHtml = "<a href=\"javascript:OpenInspection('" + Encryption.Encrypt(PK_LastInspectionDate[0].ToString()) + "');\">" + PK_LastInspectionDate[1].ToString() + "</a>";
                }
            }
            //for loop to get Last Meeting date
            for (int n = 0; n < LastMeetingDate.Length; n++)
            {
                //Spit data from LastMeetingDate by "|" and generates hyperlink
                string[] PK_LastMeetingDate;
                PK_LastMeetingDate = LastMeetingDate[n].Split('|');
                if (PK_LastMeetingDate[0] != "" && PK_LastMeetingDate[1] != "" && PK_LastMeetingDate[2] != "")
                {
                    HtmlGenericControl dvLastSLTMeetingDate = (HtmlGenericControl)e.Row.FindControl("dvLastSLTMeetingDate");
                    dvLastSLTMeetingDate.InnerHtml = "<a href=\"javascript:OpenLastSLTMeeting('" + Encryption.Encrypt(PK_LastMeetingDate[0].ToString()) + "','" + Encryption.Encrypt(PK_LastMeetingDate[1].ToString()) + "', 'edit');\">" + PK_LastMeetingDate[2].ToString() + "</a>";
                }
            }

        }
    }
    #endregion
}