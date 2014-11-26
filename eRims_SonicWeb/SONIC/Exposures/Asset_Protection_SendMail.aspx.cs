using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Text;
using ERIMS.DAL;

public partial class SONIC_Exposures_Asset_Protection_SendMail : System.Web.UI.Page
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
                if (TableName == "DPD")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["PK_Fields"]) && !string.IsNullOrEmpty(Request.QueryString["Table_Name"]) && !string.IsNullOrEmpty(Request.QueryString["Claim_ID"]))
                    {
                        string PK_Fields = Request.QueryString["PK_Fields"];
                        string FK_Table_Name = Request.QueryString["Table_Name"];
                        string Claim_ID = Request.QueryString["Claim_ID"];

                        string[] AttachmentIds = Request.QueryString["PK_Fields"].Split(',');
                        arrAttachments = new string[AttachmentIds.Length];

                        DataTable dtClaim = null;
                        if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.ALClaim.ToString().ToLower())
                            dtClaim = AL_ClaimInfo.SelectByPK(Convert.ToInt64(Claim_ID)).Tables[0];
                        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PLClaim.ToString().ToLower())
                            dtClaim = PL_ClaimInfo.SelectByPK(Convert.ToInt64(Claim_ID)).Tables[0];
                        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.DPDClaim.ToString().ToLower())
                            dtClaim = DPD_ClaimInfo.SelectViewClaim(Convert.ToInt64(Claim_ID)).Tables[0];
                        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PropertyClaim.ToString().ToLower())
                            dtClaim = Property_ClaimInfo.SelectByPK(Convert.ToInt64(Claim_ID)).Tables[0];
                        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.WCClaim.ToString().ToLower())
                            dtClaim = WC_ClaimInfo.SelectByPK(Convert.ToInt64(Claim_ID)).Tables[0];
                        DataTable dtNotes = Claim_Notes.SelectByIDs(PK_Fields).Tables[0];
                        StringBuilder sbHTML = new StringBuilder();

                        #region " Generate HTML Text "

                        string strClaimNumber = "";
                        string strDBA = "";
                        string strEmployeeName = "";
                        string strDateOfIncident = "";


                        if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.DPDClaim.ToString().ToLower())
                        {
                            strClaimNumber = Convert.ToString(dtClaim.Rows[0]["Claim_Number"]);
                            strDateOfIncident = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Of_Loss"]);
                        }
                        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PropertyClaim.ToString().ToLower())
                        {
                            strClaimNumber = Convert.ToString(dtClaim.Rows[0]["Property_FR_Number"]);
                            strDateOfIncident = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Of_Loss"]);
                        }
                        else
                        {
                            strClaimNumber = Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"]);
                            strDateOfIncident = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Of_Accident"]);
                        }
                        strDBA = Convert.ToString(dtClaim.Rows[0]["dba1"]);
                        strEmployeeName = Convert.ToString(dtClaim.Rows[0]["Employee_Name"]);

                        string strTDBlue = "style='background-color:#95B3D7;border-top:black 1px solid;border-left:black 1px solid;'";
                        string strTDWhite = "style='border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;'";
                        sbHTML.Append("<HTML><Body>");
                        sbHTML.Append("<b>eRIMS2 Sonic - Selected Sonic Claim Notes</b>");
                        sbHTML.Append("<br /></br />");
                        sbHTML.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%'>");
                        sbHTML.Append("<tr>");
                        sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
                        sbHTML.Append("<span style='color:white'><b>Claim Number</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
                        sbHTML.Append("<span style='color:white'><b>Sonic Location d/b/a</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
                        sbHTML.Append("<span style='color:white'><b>Name</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='25%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
                        sbHTML.Append("<span style='color:white'><b>Date of Incident</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("</tr>");
                        sbHTML.Append("<tr>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strClaimNumber + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strDBA + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strEmployeeName + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite.TrimEnd('\'') + "border-right:black 1px solid;'>" + strDateOfIncident + "</td>");
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

                        string strFileName = "Selected Claim Notes.doc";
                        string strFilepath = clsGeneral.SaveFile(sbHTML.ToString(), AppConfig.strAPDocumentPath, strFileName);
                        string[] strAttachments = new string[1];
                        string strAttachment = AppConfig.strAPDocumentPath + strFilepath;
                        arrAttachments[0] = strAttachment;
                    }
                }
                else if (TableName == "AL")
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["PK_Fields"]) && !string.IsNullOrEmpty(Request.QueryString["Table_Name"]) && !string.IsNullOrEmpty(Request.QueryString["Claim_ID"]))
                    {
                        string PK_Fields = Request.QueryString["PK_Fields"];
                        string FK_Table_Name = Request.QueryString["Table_Name"];
                        string Claim_ID = Request.QueryString["Claim_ID"];

                        string[] AttachmentIds = Request.QueryString["PK_Fields"].Split(',');
                        arrAttachments = new string[AttachmentIds.Length];

                        DataTable dtClaim = null;
                        if (FK_Table_Name == "AL")
                            dtClaim = AL_ClaimInfo.SelectByPK(Convert.ToInt64(Claim_ID)).Tables[0];

                        DataTable dtNotes = Claims_Adjustor_Notes.SelectByPK(PK_Fields).Tables[0];
                        StringBuilder sbHTML = new StringBuilder();

                        #region " Generate HTML Text "

                        string strTDBlue = "style='background-color:#95B3D7;border-top:black 1px solid;border-left:black 1px solid;'";
                        string strTDWhite = "style='border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;'";
                        sbHTML.Append("<HTML><Body>");
                        sbHTML.Append("<b>eRIMS2 Sonic - Selected Claim Notes</b>");
                        sbHTML.Append("<br /></br />");
                        sbHTML.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%'>");
                        sbHTML.Append("<tr>");
                        sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
                        sbHTML.Append("<span style='color:white'><b>Claim Number</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
                        sbHTML.Append("<span style='color:white'><b>Sonic Location d/b/a</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
                        sbHTML.Append("<span style='color:white'><b>Name</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("<td width='25%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
                        sbHTML.Append("<span style='color:white'><b>Date of Incident</b></span>");
                        sbHTML.Append("</td>");
                        sbHTML.Append("</tr>");
                        sbHTML.Append("<tr>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"]) + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + Convert.ToString(dtClaim.Rows[0]["dba1"]) + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite + ">" + Convert.ToString(dtClaim.Rows[0]["Employee_Name"]) + "</td>");
                        sbHTML.Append("<td align='left' " + strTDWhite.TrimEnd('\'') + "border-right:black 1px solid;'>" + clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Of_Accident"]) + "</td>");
                        sbHTML.Append("</tr>");
                        sbHTML.Append("</table>");
                        sbHTML.Append("<br />");

                        sbHTML.Append("<table cellpadding='3' cellspacing='1' width='100%'>");
                        int i = 0;
                        foreach (DataRow drClaims_Adjustor_Notes in dtNotes.Rows)
                        {
                            sbHTML.Append("<tr>");
                            sbHTML.Append("<td width='18%' align='left' valign='top'>Data Entry Date</td>");
                            sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                            sbHTML.Append("<td width='28%' align='left' valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(drClaims_Adjustor_Notes["Data_Entry_Date"])) + "</td>");
                            sbHTML.Append("<td width='18%' align='left' valign='top'>Activity Type</td>");
                            sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                            sbHTML.Append("<td width='28%' align='left' valign='top'>" + Convert.ToString(drClaims_Adjustor_Notes["Activity_Type_Description"]) + "</td>");
                            sbHTML.Append("</tr>");
                            sbHTML.Append("<tr>");
                            sbHTML.Append("<td align='left' valign='top'>Note Text</td>");
                            sbHTML.Append("<td align='center' valign='top'>:</td>");
                            sbHTML.Append("<td align='left' colspan='4' valign='top'>");
                            sbHTML.Append(Convert.ToString(drClaims_Adjustor_Notes["Note_Text"]));
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

                        string strFileName = "Selected Claim Notes.doc";
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
            clsGeneral.SendMailMessage(AppConfig.MailFrom, txtTo.Text.Trim(), string.Empty, string.Empty, "Selected Claim Notes", txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, arrAttachments);
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