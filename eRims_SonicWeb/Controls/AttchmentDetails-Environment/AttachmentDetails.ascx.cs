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
using System.IO;
using ERIMS.DAL;
/// <summary>
/// Date : 8-Oct-2008
/// 
/// By : Ravi Patel
/// 
/// Purpose: 
/// To list attachment documents, remove the selected attachment documets
/// 
/// Functionality:
/// Listing the attachment documents depending on the table name and table's primary key
/// Removing the document as well as the record from attachment table as per the selection by user
/// Mail process handling
/// </summary>
public partial class Controls_AttachmentDetails_AttachmentDetails : System.Web.UI.UserControl
{

    # region " Private Property That Needed To be Set Before Binding the Grid "

    /// <summary>
    /// Table to be used to fetch attachment data.
    /// </summary>
    private clsGeneral.Exposure_Enviroment_Table AttachmentTable
    {
        get { return (clsGeneral.Exposure_Enviroment_Table)this.ViewState["AttachmentTable"]; }
        set { ViewState["AttachmentTable"] = value; }
    }

    /// <summary>
    /// FK to be used to fetc attachment data.
    /// </summary>
    private int AttachmentFK
    {
        get { return clsGeneral.GetInt(ViewState["AttachmentFK"]); }
        set { ViewState["AttachmentFK"] = value; }
    }

    /// <summary>
    /// if true, remove button and check box column will be visible else not.
    /// </summary>
    private bool AllowRemove
    {
        get
        {
            if (ViewState["AllowRemove"] == null)
                return false;
            else
                return Convert.ToBoolean(ViewState["AllowRemove"]);
        }
        set { ViewState["AllowRemove"] = value; }
    }

    /// <summary>
    /// Denotes the Panel number for attachment in page 
    /// which can be set after the remove or mail button click
    /// </summary>
    public int IntAttachmentPanel
    {
        get { return Convert.ToInt32(ViewState["IntAttachmentPanel"]); }
        set { ViewState["IntAttachmentPanel"] = value; }
    }

    /// <summary>
    /// if true, remove button and check box column will be visible else not.
    /// </summary>
    public bool ShowAttachmentType
    {
        get
        {
            if (ViewState["ShowAttachmentType"] == null)
                return false;
            else
                return Convert.ToBoolean(ViewState["ShowAttachmentType"]);
        }
        set { ViewState["ShowAttachmentType"] = value; }
    }

    # endregion

    # region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    # endregion

    # region " Control Events "

    protected void btnRemoveAttachment_Click(object sender, EventArgs e)
    {
        // generate comma seperated string of ids of records in Attachment Tables,
        // use those id to delete selected records.
        string strIDs = "0"; //will have the comma seperated IDs 

        //loop through all the records in grid
        for (int i = 0; i < gvAttachment.Rows.Count; i++)
        {
            // if check box is checked for this item. append id to remove.
            CheckBox chkSelect = (CheckBox)gvAttachment.Rows[i].FindControl("chkSelect");
            if (chkSelect.Checked)
            {

                HtmlInputHidden hdnID = (HtmlInputHidden)gvAttachment.Rows[i].FindControl("hdnID");
                HtmlInputHidden hdnFileName = (HtmlInputHidden)gvAttachment.Rows[i].FindControl("hdnFileName");
                Label lblFolder = (Label)gvAttachment.Rows[i].FindControl("lblFolderName");
                if (strIDs == "0")
                    strIDs = hdnID.Value;
                else
                    strIDs = strIDs + "," + hdnID.Value;


                // delete the uploaded document
                string strUploadPath = clsGeneral.GetEnvironment_AttachmentDocPath(lblFolder.Text);
                string strDocName = strUploadPath + hdnFileName.Value.Trim();
                if (File.Exists(strDocName))
                    File.Delete(strDocName);
            }
        }

        //// delete record from database

        Enviro_Attachments.DeleteByMultipleIDs(strIDs);
        Bind();

        if (IntAttachmentPanel > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(" + IntAttachmentPanel + ");", true);
        }
    }

    # endregion

    #region "Attachment Grid Events"

    protected void gvAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row is datarow, set icon as per attachment type.
        // if attachemetn is an image,show image else show icon.
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Hide Attachment Type Column
            if (ShowAttachmentType == false)
            {
                gvAttachment.Columns[1].Visible = false;
            }

            HtmlGenericControl dvDocIcon = (HtmlGenericControl)e.Row.FindControl("dvDocIcon");
            HtmlGenericControl dvImage = (HtmlGenericControl)e.Row.FindControl("dvImage");

            // get the imagebutton for view and set the javascript function on its onClientClick event 
            // which displays the attached document
            ImageButton imgDownloadImg = (ImageButton)e.Row.FindControl("imgDownloadDoc");
            string strFileName = AppConfig.EnvirontmentURL + DataBinder.Eval(e.Row.DataItem, "path").ToString().Replace("#", "%23");
            //strFileName = clsGeneral.GetAttachmentImageURL(clsGeneral.TableNames[(int)AttachmentTable]) + strFileName;
           // imgDownloadImg.OnClientClick = "javascript:return openWindow('" + strFileName + "');";

            // set the file path and call the JS function
            string strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)AttachmentTable]) + strFileName;
            strFilePath = Encryption.Encrypt(strFilePath).Replace("'", "\\'");
            imgDownloadImg.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "');";
        }
    }

    #endregion

    # region " Public Methods "

    /// <summary>
    /// before using this user control's bind method,3 properties must be initialized using this methods.
    /// 1) table to be used
    /// 2) FK
    /// 3) Allow Remove operation or not.
    /// </summary>
    /// <param name="tbl"></param>
    /// <param name="FK"></param>
    /// <param name="AllowRemove"></param>
    public void InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table tbl, int FK, bool AllowRemove, int intAttachmentPanelNumber)
    {
        this.AttachmentTable = tbl;
        this.AttachmentFK = FK;
        this.AllowRemove = AllowRemove;
        this.IntAttachmentPanel = intAttachmentPanelNumber;
        if (!AppConfig.AllowMailSending)
            btnMail.OnClientClick = "javascript:alert('Attachment cannot be sent as mailing option is disabled');return false;";
        else
            btnMail.OnClientClick = "javascript:ShowMailPage" + this.ID + "('" + tbl.ToString() + "');return false;";
        btnRemoveAttachment.OnClientClick = "return CheckSelected" + this.ID + "();";
    }

    /// <summary>
    /// Bind the Grid with the Attachment details.
    /// </summary>
    public void Bind()
    {
        if (AttachmentFK > 0)
        {
            //check Atrtchment table according to the table select the Data and fill the Grid

            DataTable dtAtt = Enviro_Attachments.SelectByForeignTable(AttachmentTable.ToString(), AttachmentFK).Tables[0];
            gvAttachment.DataSource = dtAtt;
            gvAttachment.DataBind();
            btnRemoveAttachment.Visible = (AllowRemove && dtAtt.Rows.Count > 0) ? true : false;
            btnMail.Visible = (AllowRemove && dtAtt.Rows.Count > 0) ? true : false;
            gvAttachment.Columns[0].Visible = AllowRemove;
        }
        else
        {
            gvAttachment.DataSource = null;
            gvAttachment.DataBind();
            btnRemoveAttachment.Visible = false;
            btnMail.Visible = false;
            gvAttachment.Columns[0].Visible = false;
        }
    }

    #endregion
}
