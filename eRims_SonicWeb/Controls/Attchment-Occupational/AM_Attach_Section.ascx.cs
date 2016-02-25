using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Attachment_AssetProtection_AM_Attach_Section : System.Web.UI.UserControl
{
    public int AttachmentPanel
    {
        get { return ViewState["AttachmentPanel" + this.ID] != null ? Convert.ToInt32(ViewState["AttachmentPanel" + this.ID]) : 1; }
        set { ViewState["AttachmentPanel" + this.ID] = value; }
    }

    public string Table_Name
    {
        get { return ViewState["Table_Name" + this.ID] != null ? Convert.ToString(ViewState["Table_Name" + this.ID]) : ""; }
        set { ViewState["Table_Name" + this.ID] = value; }
    }

    public TextBox TextBoxAttachmentName
    {
        get { return this.txtAttachmentNameAdd; }
    }

    public FileUpload FileBrowser
    {
        get { return this.fpFile; }
    }

    public TextBox TextBoxFiletoAttach
    {
        get { return this.txtFilePath; }
    }

    public delegate void dlgTagClicked();
    public event dlgTagClicked onTagClicked;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Table_Name == "PM_Respiratory_Protection_Attachments")
                lbl.Text = "Attachment Name";
        }
    }
}