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
using System.Text;
using BAL;

public partial class Admin_SendEmail : System.Web.UI.Page
{

    private int EmailType
    {
        get { return clsGeneral.GetInt(ViewState["Type"]); }
        set { ViewState["Type"] = value; }
    }

    /// <summary>
    /// Sedgwick field Office Id
    /// </summary>
    private int FK_LU_Sedgwick_Field_Office
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["SedgwickFieldOffice"]))
            {
                return Convert.ToInt32(Request.QueryString["SedgwickFieldOffice"]);
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Year for Claim Reveiw
    /// </summary>
    private int Year
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Year"]))
            {
                return Convert.ToInt32(Request.QueryString["Year"]);
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Quarter for Claim Review
    /// </summary>
    private int Quarter
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Quarter"]))
            {
                return Convert.ToInt32(Request.QueryString["Quarter"]);
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["SortBy"]))
            {
                return Convert.ToString(Request.QueryString["SortBy"]);
            }
            else
            {
                return "";
            }
        }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["SortOrder"]))
            {
                return Convert.ToString(Request.QueryString["SortOrder"]);
            }
            else
            {
                return "";
            }
        }
    }

    # region " Page EVents "

    protected void Page_Load(object sender, EventArgs e)
    {
        // to use this page , user must pass EmailType in querystring.
        //EmailType = clsGeneral.GetInt(Request.QueryString["EmailType"]);
        //if (EmailType == 0)
        //{
        //    ClosePage();
        //}
        //else
        //{
        //    // code to show layout of page as per selected email type.
        //    switch (EmailType)
        //    {
        //        case (int)clsGeneral.EmailTYpe.Attachment:
        //            int intAttachmentId = clsGeneral.GetInt(Request.QueryString["AttachmentId"]);
        //            if (intAttachmentId == 0)
        //            {
        //                // if attachment id is not passed.
        //                lblMsg.Text = "Attachment Not Found";
        //            }
        //            else
        //            {

        //                // if attachment is pased
        //                //ERIMSAttachment objAttach = new ERIMSAttachment(Convert.ToDecimal(intAttachmentId));
        //                //lblAttachment.Text = objAttach.Attachment_Name; 
        //                //this.Page.Title = " Email Attachment - " + objAttach.Attachment_Name;

        //            }
        //            break;
        //        default:
        //            lblMsg.Text = "No Email Type Found";
        //            break;
        //    }
        //}        
    }

    #endregion

    protected void btnSend_Click(object sender, EventArgs e)
    {
        //int intAttachmentId = clsGeneral.GetInt(Request.QueryString["AttachmentId"]);
        // ERIMSAttachment objAttachment = new ERIMSAttachment(Convert.ToDecimal(intAttachmentId));
        // string strAttachment = clsGeneral.GetAttachmentDocPath(objAttachment.Attachment_Table) + objAttachment.Foreign_Key.ToString() + "\\" + objAttachment.Attachment_Name;
        // string[] arrAttachments = new string[] { strAttachment };
        
        StringBuilder strBody = new StringBuilder();
        strBody.Append("<table cellpadding=\"0\" cellspacing=\"0\" width=\"99%\" align=\"center\">");
        strBody.Append("<tr>");
        strBody.Append("<td width=\"100%\" class=\"Spacer\" style=\"height: 20px;\"></td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td align=\"left\">");
        strBody.Append("<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
        strBody.Append("<tr>");
        strBody.Append("<td width=\"45%\">");
        strBody.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
        strBody.Append("<tr>");
        strBody.Append("<td align=\"left\"><span class=\"heading\">Claim Review Worksheet Group</span> </td>");
        strBody.Append("</tr>");
        strBody.Append("</table>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("</table>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td class=\"Spacer\" style=\"height: 10px;\"></td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td class=\"groupHeaderBar\">&nbsp; </td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td class=\"Spacer\" style=\"height: 20px;\"></td>");
        strBody.Append("</tr>");

        int PageSize = 0;
        DataSet dsClaimInfo = Sedgwick_Claim_Group.SelectAll();
        if (dsClaimInfo != null && dsClaimInfo.Tables.Count > 0 && dsClaimInfo.Tables[0].Rows.Count > 0)
            PageSize = dsClaimInfo.Tables[0].Rows.Count;

        dsClaimInfo = new DataSet();
        dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search_New(FK_LU_Sedgwick_Field_Office, Year, Quarter, SortBy, SortOrder, 1, PageSize, clsSession.CurrentLoginEmployeeId);
        if (dsClaimInfo!=null)  //(Session["dtClaimReviewGroupSearch"] != null)
        {
            //get the data table from session
            //DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
           // DataTable dtSearch = dsClaimInfo.Tables[0];
            //check datatable have atleast one row
            if (dsClaimInfo.Tables.Count>0 && dsClaimInfo.Tables[0].Rows.Count>0)
            {
                ////DataRow drSearch = dtSearch.Rows[0];

                //get the values from each column of row
                //decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
                //decimal State_PK_ID = Convert.ToDecimal(drSearch["State_PK_ID"]);
                //decimal WC_FR_Number = 0; //Convert.ToDecimal(drSearch["WC_FR_Number"]);
                //string Origin_Claim_Number = Convert.ToString(drSearch["Origin_Claim_Number"]);
                //Int32 AssociatedFirstReport = Convert.ToInt32(drSearch["AssociatedFirstReport"]);
                //string ClaimType = Convert.ToString(drSearch["ClaimType"]);
                //string ClaimStatus = Convert.ToString(drSearch["ClaimStatus"]);
                //decimal LocationNumber = Convert.ToDecimal(drSearch["LocationNumber"]);
                ////decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
                ////int Year = Convert.ToInt32(drSearch["Year"].ToString());
                ////int Quarter = Convert.ToInt32(drSearch["Quarter"].ToString());
                // selects records depending on paging criteria and search values.
                 ////dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search_New(FK_LU_Sedgwick_Field_Office, Year, Quarter, "Origin_Claim_Number", "ASC", 1, 10, clsSession.CurrentLoginEmployeeId);

                DataTable dtFRData = dsClaimInfo.Tables[0];

                LU_Sedgwick_Field_Office objLU_Sedgwick_Field_Office = new LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office);
                if (objLU_Sedgwick_Field_Office!=null)
                {
                    strBody.Append("<tr>");
                    strBody.Append("<td>");
                    strBody.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
                    strBody.Append("<tr>");
                    strBody.Append("<td width=\"100%\" colspan=\"7\" valign=\"top\">");
                    strBody.Append("<div>");
                    strBody.Append("<table cellspacing=\"0\" cellpadding=\"4\" border=\"0\" style=\"color: #333333; font-family: Tahoma; font-size: 8pt; width: 100%; border-collapse: collapse;\">");
                    strBody.Append("<tr align=\"left\" style=\"color: White; background-color: #7F7F7F; font-family: Tahoma; font-size: 8pt; font-weight: bold;\">");
                    strBody.Append("<th align=\"left\"  scope=\"col\">");
                    strBody.Append("Sedgwick Field Office");
                    strBody.Append("</th>");
                    strBody.Append("<th align=\"left\"  scope=\"col\">");
                    strBody.Append("Year");
                    strBody.Append("</th>");
                    strBody.Append("<th align=\"left\"  scope=\"col\">");
                    strBody.Append("Quarter");
                    strBody.Append("</th>");
                    strBody.Append("</tr>");
                    strBody.Append("<tr valign=\"top\" style=\"background-color: #EAEAEA; font-family: Tahoma; font-size: 8pt;\">");
                    strBody.Append("<td align=\"left\" style=\"width: 15%;\"> " + Convert.ToString(objLU_Sedgwick_Field_Office.Fld_Desc) + " </td>");
                    strBody.Append("<td align=\"left\" style=\"width: 20%;\">" + Year.ToString() + " </td>");
                    strBody.Append("<td align=\"left\" style=\"width: 15%;\">" + Quarter.ToString() + " </td>");
                    strBody.Append("</tr>");
                    strBody.Append("</table>");
                    strBody.Append("</div>");
                    strBody.Append("</td>");
                    strBody.Append("</tr>");
                    strBody.Append("</table>");
                    strBody.Append("</td>");
                    strBody.Append("</tr>");

                    //gvSedgwickOffice.DataSource = dsClaimInfo.Tables[3];
                    //gvSedgwickOffice.DataBind();
                }
                // bind the grid.

                strBody.Append("<tr>");
                strBody.Append("<td class=\"Spacer\" style=\"height: 20px;\"></td>");
                strBody.Append("</tr>");
                strBody.Append("<tr>");
                strBody.Append("<td>");
                strBody.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
                strBody.Append("<tr>");
                strBody.Append("<td width=\"100%\" colspan=\"7\" valign=\"top\">");
                strBody.Append("<div>");
                strBody.Append("<table cellspacing=\"0\" cellpadding=\"4\" border=\"0\" style=\"color: #333333; font-family: Tahoma; font-size: 8pt; width: 100%; border-collapse: collapse;\">");
                strBody.Append("<tr align=\"left\" style=\"color: White; background-color: #7F7F7F; font-family: Tahoma; font-size: 8pt; font-weight: bold;\">");
                strBody.Append("<th align=\"left\"  scope=\"col\"> RLCM </th>");
                strBody.Append("<th align=\"left\"  scope=\"col\"> Claim Number </th>");
                strBody.Append("<th align=\"left\"  scope=\"col\"> Associate Name </th>");
                strBody.Append("<th align=\"left\"  scope=\"col\"> d/b/a </th>");
                strBody.Append("<th align=\"left\"  scope=\"col\"> Location Number </th>");
                strBody.Append("<th align=\"left\"  scope=\"col\"> Date of Loss </th>");
                strBody.Append("<th align=\"left\"  scope=\"col\"> Claim Indicator </th>");
                strBody.Append("<th align=\"left\"  scope=\"col\"> Review Complete? </th>");
                strBody.Append("</tr>");
                foreach (DataRow item in dtFRData.Rows)
                {
                    strBody.Append("<tr valign=\"top\" style=\"background-color: #EAEAEA; font-family: Tahoma; font-size: 8pt;\">");
                    strBody.Append("<td align=\"left\" style=\"width: 10%;\">" + Convert.ToString(item["RLCM"]) + " </td>");
                    strBody.Append("<td align=\"left\" style=\"width: 10%;\">" + Convert.ToString(item["Origin_Claim_Number"]) + " </td>");
                    strBody.Append("<td align=\"left\" style=\"width: 15%;\">" + Convert.ToString(item["Employee_Name"]) + " </td>");
                    strBody.Append("<td align=\"left\" style=\"width: 15%;\">" + Convert.ToString(item["dba"]) + " </td>");
                    strBody.Append("<td align=\"left\" style=\"width: 10%;\">" + Convert.ToString(item["Sonic_Location_Code"]) + " </td>");
                    strBody.Append("<td align=\"left\" style=\"width: 10%;\">" + clsGeneral.FormatDBNullDateToDisplay_Claim(item["Date_of_Accident"].ToString()) + " </td>");
                    strBody.Append("<td align=\"left\" style=\"width: 10%;\">" + Convert.ToString(item["ClaimIndicator"]) + " </td>");
                    strBody.Append("<td align=\"left\" style=\"width: 10%;\">" + Convert.ToString(item["Review_Complete"]) + " </td>");
                    strBody.Append("</tr>");
                }
                strBody.Append("</table></div></td></tr></table></td></tr><tr><td class=\"Spacer\" style=\"height: 20px;\"></td></tr></table>");


                //gvClaimReviewGroupSearchGrid.DataSource = dtFRData;
                //gvClaimReviewGroupSearchGrid.DataBind();

                // set record numbers retrieved
                //lblNumber.Text = (dsClaimInfo.Tables.Count >= 3) ? Convert.ToString(dsClaimInfo.Tables[1].Rows[0][0]) : "0"; //dsClaimInfo.Tables[0].Rows.Count.ToString(); 
            }
        }


        clsGeneral.SendMailMessage(AppConfig.MailFrom, txtTo.Text, "", "", txtSubject.Text, strBody.ToString(), true);
        ClosePage();
    }

    private void ClosePage()
    {
        Page.ClientScript.RegisterStartupScript(typeof(string), "keyclosewindow", "window.close();", true);
    }

}
