using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Text;
using ERIMS.DAL;


public partial class SONIC_Exposures_COIMail : System.Web.UI.Page
{
    public static string[] arrAttachments;

    private int EmailType
    {
        get { return clsGeneral.GetInt(ViewState["Type"]); }
        set { ViewState["Type"] = value; }
    }

    private string TableName
    {
        get { return Convert.ToString(ViewState["TableName"]); }
        set { ViewState["TableName"] = value; }
    }

    # region " Page EVents "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // to use this page , user must pass EmailType in querystring.
            EmailType = clsGeneral.GetInt(Request.QueryString["EmailType"]);
            TableName = Request.QueryString["Tab"];
            if (EmailType == 0)
            {
                trAttachment.Visible = false;
                if (TableName == "APNOTES")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["PK_Fields"]) && !string.IsNullOrEmpty(Request.QueryString["Table_Name"]) && !string.IsNullOrEmpty(Request.QueryString["Claim_ID"]))
                    {
                        DataTable dtNotes = null;
                        string PK_Fields = Request.QueryString["PK_Fields"];
                        string FK_Table_Name = Request.QueryString["Table_Name"];
                        string Claim_ID = Request.QueryString["Claim_ID"];

                        string[] AttachmentIds = Request.QueryString["PK_Fields"].Split(',');
                        arrAttachments = new string[AttachmentIds.Length];


                        DataTable dtClaim = null;
                        if (FK_Table_Name == "COIs")
                            dtClaim = clsCOI_Notes.SelectCOIByPK(Convert.ToDecimal(Claim_ID)).Tables[0];

                        if (FK_Table_Name == "COIs")
                        {
                            dtNotes = clsCOI_Notes.SelectByIDs(PK_Fields).Tables[0];
                        }
                        
                        StringBuilder sbHTML = new StringBuilder();

                        #region " Generate HTML Text "

                        string strClaimNumber = "";
                        string strDBA = "";
                        string strNotes = "Selected COI Notes";
                        string strDocName = "COINotes.doc";
                        string strSonicLocationNumber = "";
                        string strLocationName = "";
                        string strInsuredName = "";
                        string strIssueDate = "";
                        string strEffectiveDate = "";
                        COIs objCOI = new COIs(Convert.ToDecimal(Claim_ID));
                        LU_Location objLocation = new LU_Location(Convert.ToDecimal(objCOI.FK_LU_Location_ID));
                        COI_Insureds objInsured = new COI_Insureds(objCOI.FK_COI_Insureds);


                        strClaimNumber = Convert.ToString(objCOI.PK_COIs);
                        strDBA = Convert.ToString(objLocation.dba);
                        strLocationName = Convert.ToString(objLocation.dba);
                        if (objLocation.Sonic_Location_Code < 0)
                        {
                            strLocationName = "";
                        }
                        else
                            strLocationName = Convert.ToString(objLocation.Sonic_Location_Code);
                            strInsuredName = Convert.ToString(objInsured.Insured_Name);
                            strIssueDate = clsGeneral.FormatDate(objCOI.Issue_Date);
                            strEffectiveDate = clsGeneral.FormatDate(objInsured.Date_Closed);
                            strSonicLocationNumber = Convert.ToString(objLocation.Sonic_Location_Code);


                        //strEmployeeName = Convert.ToString(dtClaim.Rows[0]["Employee_Name"]);

                        string strTDBlue = "style='background-color:#95B3D7;border-top:black 1px solid;border-left:black 1px solid;'";
                        string strTDWhite = "style='border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;'";
                        sbHTML.Append("<HTML><Body>");
                        sbHTML.Append("<b>" + strNotes + "</b>");
                        sbHTML.Append("<br /></br />");
                        sbHTML.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%'>");
                        sbHTML.Append("<tr>");
                        sbHTML.Append("<td width='20%' align='left' " + strTDBlue + ">");
                        sbHTML.Append("<span style='color:white'><b>COI Number</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='20%' align='left' " + strTDBlue + ">");
                        sbHTML.Append("<span style='color:white'><b>D/B/A Location Name</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='15%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
                        sbHTML.Append("<span style='color:white'><b>Sonic Location Number</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='15%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
                        sbHTML.Append("<span style='color:white'><b>Insured Name</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='15%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
                        sbHTML.Append("<span style='color:white'><b>Issue Date</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='15%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
                        sbHTML.Append("<span style='color:white'><b>Effective Date</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("</tr>");
                        sbHTML.Append("<tr>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + "COI - " + strClaimNumber + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strDBA + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strSonicLocationNumber + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strInsuredName + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strIssueDate + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite.TrimEnd('\'') + "border-right:black 1px solid;'>" + strEffectiveDate + "</td>");
                        sbHTML.Append("</tr>");
                        sbHTML.Append("</table>");
                        sbHTML.Append("<br />");

                        sbHTML.Append("<table cellpadding='3' cellspacing='1' width='100%'>");
                        int i = 0;
                        foreach (DataRow drClaims_Adjustor_Notes in dtNotes.Rows)
                        {
                            sbHTML.Append("<tr>");
                            sbHTML.Append("<td width='18%' align='left' valign='top'>Date of Note</td>");
                            sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                            sbHTML.Append("<td align='left' valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(drClaims_Adjustor_Notes["Note_Date"])) + "</td>");
                            sbHTML.Append("</tr>");
                            sbHTML.Append("<tr>");
                            sbHTML.Append("<td align='left' valign='top'>Notes</td>");
                            sbHTML.Append("<td align='center' valign='top'>:</td>");
                            sbHTML.Append("<td align='left' valign='top'>");
                            sbHTML.Append(Convert.ToString(drClaims_Adjustor_Notes["Note"]));
                            sbHTML.Append("</td>");
                            sbHTML.Append("</tr>");

                            if (i < dtNotes.Rows.Count - 1)
                            {
                                sbHTML.Append("<tr style='height:30px'>");
                                sbHTML.Append("<td colspan='6' style='vertical-align:middle'><hr size='1' color='Black' /></td>");
                                sbHTML.Append("</tr>");
                            }

                            i++;
                        }

                        sbHTML.Append("</table>");
                        sbHTML.Append("</Body></HTML>");

                        #endregion

                        string strFileName = strDocName;
                        string strFilepath = clsGeneral.SaveFile(sbHTML.ToString(), AppConfig.strAPDocumentPath, strFileName);
                        string[] strAttachments = new string[1];
                        string strAttachment = AppConfig.strAPDocumentPath + strFilepath;
                        arrAttachments[0] = strAttachment;
                    }
                }
                else
                    ClosePage();
            }
            else
            {
                // code to show layout of page as per selected email type.
                switch (EmailType)
                {
                    case (int)clsGeneral.EmailTYpe.Attachment:
                        trAttachment.Visible = true;
                        string[] AttachmentIds = Request.QueryString["AttachmentId"].Split(',');
                        arrAttachments = new string[AttachmentIds.Length];
                        string PK_Field_Name = Convert.ToString(Request.QueryString["PK_Field_Name"]);
                        for (int i = 0; i < AttachmentIds.Length; i++)
                        {
                            int intAttachmentId = clsGeneral.GetInt(AttachmentIds[i]);

                            if (intAttachmentId == 0)
                            {
                                // if attachment id is not passed.
                                //lblMsg.Text = "Attachment Not Found";
                            }
                            else
                            {
                                string strSQL = "";
                                strSQL = strSQL + "SELECT Atachment_Name_On_Disk";
                                strSQL = strSQL + " FROM " + "AP_Attachments" + Environment.NewLine;
                                strSQL = strSQL + " WHERE " + PK_Field_Name + " = " + intAttachmentId;

                                Database db = DatabaseFactory.CreateDatabase();
                                DataSet ds = db.ExecuteDataSet(System.Data.CommandType.Text, strSQL);

                                string Attachment_Name = Convert.ToString(ds.Tables[0].Rows[0]["Atachment_Name_On_Disk"]);
                                lblAttachment.Text += " " + Attachment_Name.Substring(12) + ",";
                                this.Page.Title = " Email Attachment ";
                                string strAttachment = AppConfig.strAPDocumentPath + Attachment_Name;
                                arrAttachments[i] = strAttachment;

                            }
                        }
                        lblAttachment.Text = lblAttachment.Text.TrimEnd(',');


                        break;
                    default:
                        //lblMsg.Text = "No Email Type Found";
                        break;
                }

                if (arrAttachments.Length > 0)
                {
                    decimal FileSize = clsGeneral.GetMailAttachmentSize(arrAttachments);
                    if (FileSize > 9.5M)
                        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('The e-mailing of the selected attachments exceeds 10 megabytes, which does not conform to Sonic Corporate e-mail policy. Please reduce the attachment size or number of attachments before trying to send e-mail through eRIMS2.');window.close();", true);

                }
            }


        }
    }

    #endregion

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (EmailType == 0)
        {
            clsGeneral.SendMailMessage(AppConfig.MailFrom, txtTo.Text.Trim(), string.Empty, string.Empty, "Selected COI Notes", txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, arrAttachments);
        }
        else
            clsGeneral.SendMailMessage(AppConfig.MailFrom, txtTo.Text, "", "", txtSubject.Text, txtBody.Text, true, arrAttachments);
        ClosePage();
    }

    private void ClosePage()
    {
        Page.ClientScript.RegisterStartupScript(typeof(string), "keyclosewindow", "alert('Mail Sent Successfully');window.close();", true);
    }
}