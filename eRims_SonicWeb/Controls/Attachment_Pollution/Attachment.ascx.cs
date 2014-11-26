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

public partial class Hudson_Attachment : System.Web.UI.UserControl
{

    #region "Public Properties"  
 
    /// <summary>
    /// Denotes the Panel number for attachment in page 
    /// which can be set after the remove or mail button click
    /// </summary>
    public int IntAttachmentPanel
    {
        get { return Convert.ToInt32(ViewState["IntAttachmentPanel"]); }
        set { ViewState["IntAttachmentPanel"] = value; }
    }
   

    public bool ShowAttachmentButton
    {
        set
        {
            if (value == true)
            {
                btnAddAttachment.Visible = true;
            }
            else
            {
                btnAddAttachment.Visible = false;
            }
        }
    }
   
    #endregion

    # region " Page Events "

    // Delegate declaration
    public delegate void OnButtonClick(string strValue);

    // Event declaration
    public event OnButtonClick btnHandler;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetAddAttachmentLink();
        if (!IsPostBack)
        {

        }
    }

    # endregion

    # region " Public Methods "

    /// <summary>
    /// Add Attachment.
    /// saves attachment at physical path depending on table used.
    /// also inser record in database.
    /// </summary>
    /// <param name="AttachemtnTable"></param>
    /// <param name="AttachmentPK"></param>
    public void Add(clsGeneral.Tables AttachemtnTable, int AttachmentPK)
    {
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile1);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile2);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile3);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile4);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile5);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile6);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile7);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile8);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile9);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile10);

        txtAttachDesc.Text = "";      
        if (IntAttachmentPanel > 0)
        {
            //alert('" + strFiles + "');
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + IntAttachmentPanel + ");", true);
        }
    }

    private void SaveAttachmentDetails(clsGeneral.Tables AttachemtnTable, int AttachmentPK, FileUpload fpFile)
    {
        
        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        if (AttachmentPK != 0 && !clsGeneral.IsNull(AttachemtnTable) && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
        {
            //used to check Attchment Table Type. according to that Data is added to related table            

            ////set values to store in database
            CRM_Attachments objAttachment = new CRM_Attachments();        
          
            objAttachment.Description = txtAttachDesc.Text.Trim();
            objAttachment.FK_Table_Name = AttachmentPK;
            objAttachment.Table_Name = clsGeneral.TableNames[(int)AttachemtnTable].ToString();
            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)AttachemtnTable]);
            string DocPath = string.Concat(strUploadPath, "\\");

            // upload and set the filename.
            objAttachment.FileName = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            //Insert the attachment record
            objAttachment.Insert();

        }
    }

    /// <summary>
    /// Show Attachment and Remove Link
    /// </summary>
    private void SetAddAttachmentLink()
    {
        int _intNoOfAttachment = Convert.ToInt32(hdnAttachmentCount.Value);

        trAttachment1.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 1 ? "block" : "none");
        lbtAdd1.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 1 ? "block" : "none");

        trAttachment2.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 2 ? "block" : "none");
        lbtAdd2.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 2 ? "block" : "none");
        lbtRemove2.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 2 ? "block" : "none");

        trAttachment3.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 3 ? "block" : "none");
        lbtAdd3.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 3 ? "block" : "none");
        lbtRemove3.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 3 ? "block" : "none");

        trAttachment4.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 4 ? "block" : "none");
        lbtAdd4.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 4 ? "block" : "none");
        lbtRemove4.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 4 ? "block" : "none");

        trAttachment5.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 5 ? "block" : "none");
        lbtAdd5.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 5 ? "block" : "none");
        lbtRemove5.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 5 ? "block" : "none");

        trAttachment6.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 6 ? "block" : "none");
        lbtAdd6.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 6 ? "block" : "none");
        lbtRemove6.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 6 ? "block" : "none");

        trAttachment7.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 7 ? "block" : "none");
        lbtAdd7.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 7 ? "block" : "none");
        lbtRemove7.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 7 ? "block" : "none");

        trAttachment8.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 8 ? "block" : "none");
        lbtAdd8.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 8 ? "block" : "none");
        lbtRemove8.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 8 ? "block" : "none");

        trAttachment9.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 9 ? "block" : "none");
        lbtAdd9.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 9 ? "block" : "none");
        lbtRemove9.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 9 ? "block" : "none");

        trAttachment10.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment >= 10 ? "block" : "none");
        lbtRemove9.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 10 ? "block" : "none");
        //lbtAdd1.Style.Add(HtmlTextWriterStyle.Display, _intNoOfAttachment == 1 ? "block" : "none");

    }

    # endregion

    /// <summary>
    /// btnHdn click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnHdn_Click(object sender, EventArgs e)
    {
        //check null value
        if (btnHandler != null)
            btnHandler(string.Empty);
    }

    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        btnHdn_Click(null, null);
    }    
}
