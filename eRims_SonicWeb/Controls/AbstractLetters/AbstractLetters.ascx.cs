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
using System.Text;
using System.IO;
using Winnovative.WnvHtmlConvert;
using System.Text.RegularExpressions;

public partial class Controls_AbstractLetters_AbstractLetters : System.Web.UI.UserControl
{

    #region " Properties "

    /// <summary>
    /// Denotes ID for claim
    /// </summary>
    public decimal FK_Event
    {
        get { return Convert.ToDecimal(ViewState["AbstractLetter"]); }
        set { ViewState["AbstractLetter"] = value; }
    }

    /// <summary>
    /// Denotes major coverage for claim
    /// </summary>
    public clsGeneral.Major_Coverage Major_Coverage
    {
        get { return (clsGeneral.Major_Coverage)ViewState["AbstractLetterMajorCoverage"]; }
        set { ViewState["AbstractLetterMajorCoverage"] = value; }
    }

    /// <summary>
    /// Number of panel that contains the Abstract & Letters grid
    /// </summary>
    public int PanelNumber
    {
        get { return Convert.ToInt32(ViewState["PanelNumber"]); }
        set { ViewState["PanelNumber"] = value; }
    }

    public string AttachmentGridUpdateButtonID
    {
        get { return Convert.ToString(ViewState["GridUpdateButtonID"]); }
        set { ViewState["GridUpdateButtonID"] = value; }
    }

    /// <summary>
    /// Displays or hides Mail button as per the value set
    /// </summary>
    public bool ShowMailButton
    {
        set
        {
            if (value == false)
                btnAbstractletterMail.Visible = false;
            else
                btnAbstractletterMail.Visible = true;
        }
    }

    /// <summary>
    /// Displays or hides Print button as per the value set
    /// </summary>
    public bool ShowPrintButton
    {
        set
        {
            if (value == false)
                btnAbstractletterPrint.Visible = false;
            else
                btnAbstractletterPrint.Visible = true;
        }
    }

    public bool ShowAttachments
    {
        get
        {
           return false;
        }
    }

    /// <summary>
    /// No any letters are print or mail
    /// </summary>
    public bool HideGenerateLetters
    {
        get { return Convert.ToBoolean(ViewState["GenerateLetters"]); }
        set { ViewState["GenerateLetters"] = value; }
    }

    #endregion

    #region " Page Events "

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            Major_Coverage = clsGeneral.Major_Coverage.Event;

            btnAbstractletterPrint.Visible = true;
            btnAbstractletterMail.Visible = true;
          
            // bind grid for letters
            BindGrid();

            if (HideGenerateLetters)
            {
                btnAbstractletterPrint.Visible = false;
                btnAbstractletterMail.Visible = false;
            }

        }
    }
    #endregion

    #region " Methods "

    /// <summary>
    /// Binds letters available for major claim
    /// </summary>
    private void BindGrid()
    {
        /// get all records for abstract letters for the claim coverage and bind the grid
        gvAbstractsLetters.DataSource = Abstracts_Letters.SelectAll(999);
        gvAbstractsLetters.DataBind();

        if (gvAbstractsLetters.Rows.Count > 0)
        {
            foreach (GridViewRow gRow in gvAbstractsLetters.Rows)
            {
                ((CheckBox)gRow.FindControl("chkSelLetter")).Attributes.Add("onclick", "CheckAllUncheckedLetters('" + gvAbstractsLetters.ClientID + "')");
            }
        }
    }

    /// <summary>
    /// Generates letter text as per the document name passed
    /// </summary>
    /// <param name="strDocumentName"></param>
    /// <returns></returns>
    private string GetLetterText(string strDocumentName)
    {
        string strLetterText = string.Empty;
        
        return strLetterText;
    }

    private void GenerateEventAbstractPDF()
    {
        
        
        string strFileName = "Event Abstract Letter.pdf";
        PdfConverter objPdf = new PdfConverter();
        objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;

        objPdf.PdfDocumentOptions.TopMargin = 20;
        objPdf.PdfDocumentOptions.LeftMargin = 20;
        objPdf.PdfDocumentOptions.RightMargin = 20;
        objPdf.PdfDocumentOptions.BottomMargin = 20;
        objPdf.PdfDocumentOptions.ShowHeader = false;
        objPdf.PdfDocumentOptions.ShowFooter = false;
        objPdf.PdfDocumentOptions.EmbedFonts = false;

        objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
        objPdf.RightToLeftEnabled = false;
        objPdf.PdfSecurityOptions.CanPrint = true;
        objPdf.PdfSecurityOptions.CanEditContent = true;
        objPdf.PdfSecurityOptions.UserPassword = "";
        objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Landscape;
        objPdf.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
        objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;

        objPdf.AvoidTextBreak = false;

        StringBuilder sbHtml = new StringBuilder();
        objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";
        Byte[] pdfByte = null;

        sbHtml = AbstractLetters.Event_AbstactReport(FK_Event, false,clsGeneral.Major_Coverage.Event);

        pdfByte = objPdf.GetPdfBytesFromHtmlString(sbHtml.ToString());

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
        HttpContext.Current.Response.AddHeader("Content-Disposition", ("attachment; filename=" + strFileName + "; size=") + pdfByte.Length.ToString());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.BinaryWrite(pdfByte);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
    
    #endregion

    #region " Control Events "

    /// <summary>
    /// Handles Print button click event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAbstractletterPrint_Click(object sender, EventArgs e)
    {
        if (FK_Event > 0)
        {
            string strPageBreak = "<br style=\"page-break-before: always\" />"; // used to set page break for multiple letters
            //Create string object to set letter text
            StringBuilder strHTML = new StringBuilder();
            // loop through each row in grid

            ArrayList arrNewDocArray = new ArrayList();
            foreach (GridViewRow gRow in gvAbstractsLetters.Rows)
            {
                string strDocumentName = ((HiddenField)gRow.FindControl("hdnDocumentName")).Value;
                if (((CheckBox)gRow.FindControl("chkSelLetter")).Checked)
                {
                    arrNewDocArray.Add(strDocumentName);
                }
            }

            if (arrNewDocArray.Count == 1)
            {
                foreach (GridViewRow gRow in gvAbstractsLetters.Rows)
                {
                    string strDocumentName = ((HiddenField)gRow.FindControl("hdnDocumentName")).Value;
                    // if checkbox is selected in the row
                    if (((CheckBox)gRow.FindControl("chkSelLetter")).Checked)
                    {
                        // Check Only Abstract letter is generated 
                        if (Convert.ToString(gRow.Cells[2].Text) == "PDF")
                        {
                            //string strDocumentName = ((HiddenField)gRow.FindControl("hdnDocumentName")).Value;
                            if (strDocumentName.Trim().ToLower() == "event abstract letter") //check PDF file name
                            {
                                GenerateEventAbstractPDF();
                            }
                            
                            return;
                        }
                    }
                }
            }
            
            // if letter text is available then generate word doc to print 
            if (strHTML.Length > 0)
            {
                string strDocumentPath = clsGeneral.GetAttachmentDocPath(Major_Coverage.ToString());
                string strFileName = clsGeneral.SaveFileLandscape(strHTML.ToString(), strDocumentPath, "AbstractLetters.doc");
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:openWindowAbstract('" + AppConfig.SiteURL + "/Download.aspx?fname=" + Encryption.Encrypt(strFileName) + "&OSHA_DOC=1" + "');", true);
                //GenerateOSHA301Doc("AbstractLetters.doc", strHTML.ToString(), Response);
            }
        }

        // show abstract & letters panel after post back
        if (PanelNumber > 0)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber.ToString() + ");", true);
    }

    /// <summary>
    /// Handles Mail button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAbstractletterMail_Click(object sender, EventArgs e)
    {
        if (FK_Event > 0)
        {

            string strLetterTypes = "", strDocType = string.Empty; // stores comma separated document names   

            ArrayList arrNewDocArray = new ArrayList();
            foreach (GridViewRow gRow in gvAbstractsLetters.Rows)
            {
                string strDocumentName = ((HiddenField)gRow.FindControl("hdnDocumentName")).Value;
                if (((CheckBox)gRow.FindControl("chkSelLetter")).Checked)
                {
                    arrNewDocArray.Add(strDocumentName);
                }
            }

            if (arrNewDocArray.Count == 1)
            {

                // loop through each row in grid
                foreach (GridViewRow gRow in gvAbstractsLetters.Rows)
                {
                    // if checkbox is selected
                    if (((CheckBox)gRow.FindControl("chkSelLetter")).Checked)
                    {
                        string strDocumentName = ((HiddenField)gRow.FindControl("hdnDocumentName")).Value;
                        // Check Only Abstract letter is generated 
                        if (Convert.ToString(gRow.Cells[2].Text) == "PDF")
                        {
                            if (strDocumentName.Trim().ToLower() == "event abstract letter")
                            {
                                strDocType = "PDF";
                                ViewState["strDocType"] = "PDF";
                                ViewState["strLetterTypes"] = strLetterTypes + strDocumentName;
                            }

                        }

                        strLetterTypes = strLetterTypes + strDocumentName + ",";
                        strLetterTypes = strLetterTypes.TrimEnd(',');

                        // show mail page for abstract letter
                        if (PanelNumber > 0)
                            //Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber.ToString() + "); ShowAbstractMailPage('" + Encryption.Encrypt(strLetterTypes) + "','" + Encryption.Encrypt(FK_Event.ToString()) + "','" + Major_Coverage.ToString() + "','" + strDocType + "','" + ShowAttachments.ToString() + "','" + hdnPK_Entity.Value + "');", true);
                            ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber.ToString() + "); CheckAllUncheckedLetters('" + gvAbstractsLetters.ClientID + "'); ShowAbstractMailPage('" + Encryption.Encrypt(strLetterTypes) + "','" + Encryption.Encrypt(FK_Event.ToString()) + "','" + Major_Coverage.ToString() + "','" + strDocType + "','" + ShowAttachments.ToString() + "','" + hdnPK_Entity.Value + "');", true);
                        else
                            //Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowAbstractMailPage('" + Encryption.Encrypt(strLetterTypes) + "','" + Encryption.Encrypt(FK_Event.ToString()) + "','" + Major_Coverage.ToString() + "','" + strDocType + "','" + ShowAttachments.ToString() + "','" + hdnPK_Entity.Value + "');", true);
                            ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber.ToString() + "); ShowAbstractMailPage('" + Encryption.Encrypt(strLetterTypes) + "','" + Encryption.Encrypt(FK_Event.ToString()) + "','" + Major_Coverage.ToString() + "','" + strDocType + "','" + ShowAttachments.ToString() + "','" + hdnPK_Entity.Value + "');", true);
                        }
                    
                }
            }
            else
            {
                string strLetterTypesMail = "";

                if (PanelNumber > 0)
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber.ToString() + ");ShowAbstractMailPage('" + Encryption.Encrypt(strLetterTypesMail) + "','" + Encryption.Encrypt(FK_Event.ToString()) + "','" + Major_Coverage.ToString() + "','" + strDocType + "','" + ShowAttachments.ToString() + "','" + hdnPK_Entity.Value + "');", true); //ShowAdjusterNote.ToString() + 
                else
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowAbstractMailPage('" + Encryption.Encrypt(strLetterTypesMail) + "','" + Encryption.Encrypt(FK_Event.ToString()) + "','" + Major_Coverage.ToString() + "','" + strDocType + "','" + ShowAttachments.ToString() + "','" + hdnPK_Entity.Value + "');", true);//+ "','" + ShowAdjusterNote.ToString()
            }
        }

    }

    #endregion

    #region " Gridview Events "

    /// <summary>
    /// Handles event when row command is generated
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAbstractsLetters_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is for viewing a letter
        if (e.CommandName == "ViewLetter")
        {
            // get document name for letter and get letter text according to that 
            string[] strDocumentName = e.CommandArgument.ToString().Split(',');
            string strPDFDocumentName = strDocumentName[0];
            // Check Only Abstract letter is generated 
            if (strDocumentName[1].ToUpper() == "PDF")
            {
                // Show Selection for Attachment
                if (strPDFDocumentName.ToLower() == "event abstract letter")
                {
                    GenerateEventAbstractPDF();
                }
                return;
            }
            else
            {
                string strLetterText = GetLetterText(strDocumentName[0]);
                if (strLetterText.Length > 0)
                    clsGeneral.GenerateWordDoc(strDocumentName + ".doc", strLetterText, Response);

                // show abstract & letters panel after post back
                if (PanelNumber > 0)
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber.ToString() + ");", true);
            }
        }
    }


    #endregion
}