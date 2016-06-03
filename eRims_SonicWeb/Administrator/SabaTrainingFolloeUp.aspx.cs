using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using ERIMS.DAL;
using System.Text;

public partial class Administrator_SabaTrainingFolloeUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["total"] != null)
            {
                long intTotalCount = Convert.ToInt64(Request.QueryString["total"]);
                long intNotImported = clsSession.Tbl_SabaTraining_Not_Imported.Rows.Count;
                long intTotalImported = intTotalCount - intNotImported;
                lblImported.Text = string.Format("{0:N0}", intTotalImported);
                lblTotal.Text = string.Format("{0:N0}", intTotalCount);
                lblDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
                lblTime.Text = string.Format("{0:t}", DateTime.Now);

                if (intTotalCount > intTotalImported)
                    tblExceptions.Style["display"] = "block";
            }
        }
    }


    protected void lnkExceptions_Click(object sender, EventArgs e)
    {
        hdnExcelLinkClicked.Value = "1";
        if (Request.QueryString["fPath"] != null && Request.QueryString["fUrl"] != null)
        {
            string strFilePath = Encryption.Decrypt(Request.QueryString["fPath"]);
            string strFileURL = Encryption.Decrypt(Request.QueryString["fUrl"]);
            if (File.Exists(strFilePath))
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "window.open('" + strFileURL + "')", true);
            }
        }
    }

    protected void lnkNotImported_Click(object sender, EventArgs e)
    {
        if (clsSession.Tbl_SabaTraining_Not_Imported.Rows.Count > 0)
        {
            // get Property Values data having the entered multiplier value applied to export 
            DataTable dtSabaTrainingData = clsSession.Tbl_SabaTraining_Not_Imported;
            gvSabaTraining.DataSource = dtSabaTrainingData;
            gvSabaTraining.DataBind();
            GridViewExportUtil.ExportGrid("SabaTraining_Data_Spreadsheet.xlsx", gvSabaTraining,true);
        }
        hdnExcelLinkClicked.Value = "1";
    }


    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["fPath"] != null && clsSession.Tbl_SabaTraining_Not_Imported.Rows.Count > 0)
        {
            string strExceptionFilePath = Encryption.Decrypt(Request.QueryString["fPath"]);
            string strXLSFilePath = AppConfig.SabaTrainingDocPath + "PolicyNotImported.xls";

            String strMailFrom = new Security(Convert.ToDecimal(clsSession.UserID)).Email;

            string strBody = "<br/><br/>Please find the attached file for the list of exceptions and Saba Training not imported into the system.";
            strBody = strBody + "<br/>The Text file lists exceptions with the Location, PK_Property_Cope_Id and description of exception for the record.";
            strBody = strBody + "<br/>The Excel file contains all saba training records that are not imported.";

            #region " Create XLS file for records not imported "

            DataTable dt = clsSession.Tbl_SabaTraining_Not_Imported;

            if (dt.Rows.Count > 0)
            {
                gvSabaTraining.DataSource = dt;
                gvSabaTraining.DataBind();

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                //PrepareControlForExport(gvReportGrid.HeaderRow);

                gvSabaTraining.RenderControl(htmlWrite);

                MemoryStream memorystream = new MemoryStream();
                byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString());
                memorystream.Write(_bytes, 0, _bytes.Length);
                memorystream.Seek(0, SeekOrigin.Begin);
                FileStream outStream = File.OpenWrite(strXLSFilePath);
                memorystream.WriteTo(outStream);
                outStream.Flush();
                outStream.Close();

                string[] strAttachments = new string[2];
                strAttachments[0] = strExceptionFilePath;
                strAttachments[1] = strXLSFilePath;

                clsGeneral.SendMailMessage(AppConfig.MailFrom, txtEmail.Text.Trim(), "", "", "eRIMS - Sonic Saba Training Import", strBody, true, strAttachments);

            }
            #endregion


            if (File.Exists(strXLSFilePath))
                File.Delete(strXLSFilePath);
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "window.close();", true);
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
