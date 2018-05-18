using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;

public partial class SONIC_RealEstate_rptDefault : clsBasePage
{
    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {
            DataTable dt = Tatva_Report.SelectByReportType("RE", clsSession.IsACIUser).Tables[0];

            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add(new DataColumn("PK_ReportID", typeof(int)));
            dtTemp.Columns.Add(new DataColumn("Report_Name", typeof(string)));
            dtTemp.Columns.Add(new DataColumn("Report_Description", typeof(string)));           
            dtTemp.Columns.Add(new DataColumn("ReportType", typeof(string)));
            dtTemp.Columns.Add(new DataColumn("ReportOrder", typeof(string)));

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dtTemp.NewRow();
                    dr["PK_ReportID"] = Convert.ToString(dt.Rows[i]["PK_ReportID"]);
                    dr["Report_Name"] = Convert.ToString(dt.Rows[i]["Report_Name"]);
                    dr["Report_Description"] = Convert.ToString(dt.Rows[i]["Report_Description"]);
                    dr["ReportType"] = Convert.ToString(dt.Rows[i]["ReportType"]);

                    if (Convert.ToString(dt.Rows[i]["Report_Name"]) != "")
                    {
                        if (Convert.ToString(dt.Rows[i]["Report_Name"]) == "Lease Report")
                        {
                            dr["ReportOrder"] = "1";
                        }
                        else if (Convert.ToString(dt.Rows[i]["Report_Name"]) == "Critical Dates")
                        {
                            dr["ReportOrder"] = "2";
                        }
                        else if (Convert.ToString(dt.Rows[i]["Report_Name"]) == "Master Dealership List")
                        {
                            dr["ReportOrder"] = "3";
                        }
                        else if (Convert.ToString(dt.Rows[i]["Report_Name"]) == "Landlord Report")
                        {
                            dr["ReportOrder"] = "4";
                        }
                        else
                        {
                            dr["ReportOrder"] = Convert.ToString(i);
                        }                       
                    }
                    dtTemp.Rows.Add(dr);
                }
            }

            dtTemp.DefaultView.Sort = "ReportOrder asc";
            dtTemp = dtTemp.DefaultView.ToTable();
            //DataTable dtTemp = new DataTable();
            //dtTemp = dt.Clone();
            //DataRow[] dr;
            //if (dt.Rows.Count > 0)
            //{
            //    dr = dt.Select("PK_ReportID =38");
            //    for (int i = 0; i < dr.Length; i++)
            //    {
            //        dtTemp.ImportRow(dr[i]);
            //    }
            //    dr = dt.Select("PK_ReportID =51");
            //    for (int i = 0; i < dr.Length; i++)
            //    {
            //        dtTemp.ImportRow(dr[i]);
            //    }
            //    dr = dt.Select("PK_ReportID =39");
            //    for (int i = 0; i < dr.Length; i++)
            //    {
            //        dtTemp.ImportRow(dr[i]);
            //    }
            //    dr = dt.Select("PK_ReportID =40");
            //    for (int i = 0; i < dr.Length; i++)
            //    {
            //        dtTemp.ImportRow(dr[i]);
            //    }
            //}

            gvReports.DataSource = dtTemp;
            gvReports.DataBind();

        }
    }

    # region Grid Events
    protected void gvReportList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlAnchor rptLink = (HtmlAnchor)e.Row.FindControl("rptLink");
            Int32 Report_ID = Convert.ToInt32(((Label)e.Row.FindControl("lblPrimaryID")).Text);
            if (Report_ID == 27)
                rptLink.HRef = "rptLeaseDetailReport.aspx";
            else if (Report_ID == 28)
                rptLink.HRef = "rptRentProjectionsHistory.aspx";
            else if (Report_ID == 29)
                rptLink.HRef = "rptLeaseTerm.aspx";
            else if (Report_ID == 30)
                rptLink.HRef = "rptSubspacesByLocation.aspx";
            else if (Report_ID == 31)
                rptLink.HRef = "rptRentableAreaByExpirationDate.aspx";
            else if (Report_ID == 32)
                rptLink.HRef = "rptMonthlyExpenseByLocation.aspx";
            else if (Report_ID == 33)
                rptLink.HRef = "rptLeasesWithSecurityDeposits.aspx";
            else if (Report_ID == 34)
                rptLink.HRef = "rptLandlord.aspx";
            else if (Report_ID == 35)
                rptLink.HRef = "rptMaintenance.aspx";
            else if (Report_ID == 38)
                rptLink.HRef = "LeaseReport.aspx";
            else if (Report_ID == 39)
                rptLink.HRef = "rptMasterDealership.aspx";
            else if (Report_ID == 40)
                rptLink.HRef = "rptlandlordInformation.aspx";
            else if (Report_ID == 51)
                rptLink.HRef = "rptCriticalDates.aspx";
            else if (Report_ID == 52)
                rptLink.HRef = "rptSubleaseReport.aspx";
            else if (Report_ID == 55)
                rptLink.HRef = "rptLandlordNotifyDate.aspx"; 
        }
    }
    #endregion  
}
