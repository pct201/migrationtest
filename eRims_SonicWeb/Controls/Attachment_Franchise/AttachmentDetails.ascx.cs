using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using ERIMS.DAL;
public partial class Franchise_AttachmentDetails : System.Web.UI.UserControl
{
    # region " Private Property That Needed To be Set Before Binding the Grid "


    /// <summary>
    /// FK to be used to fetc attachment data.
    /// </summary>
    private decimal FK_Franchise
    {
        get { return clsGeneral.GetInt(ViewState["FK_Franchise"]); }
        set { ViewState["FK_Franchise"] = value; }
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

                if (strIDs == "0")
                    strIDs = hdnID.Value;
                else
                    strIDs = strIDs + "," + hdnID.Value;


                // delete the uploaded document
                string strDocPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Franchise]) + "\\" + hdnFileName.Value;
                if (File.Exists(strDocPath))
                    File.Delete(strDocPath);
            }
        }

        //// delete record from database
        Franchise_Attachments.DeleteByIDs(strIDs);
        Bind();

        if (IntAttachmentPanel > 0)
        { Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + IntAttachmentPanel + ");", true); }
    }

    # endregion

    #region "Attachment Grid Events"

    protected void gvAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row is datarow, set icon as per attachment type.
        // if attachemetn is an image,show image else show icon.
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlGenericControl dvDocIcon = (HtmlGenericControl)e.Row.FindControl("dvDocIcon");
            HtmlGenericControl dvImage = (HtmlGenericControl)e.Row.FindControl("dvImage");

            // get the imagebutton for view and set the javascript function on its onClientClick event 
            // which displays the attached document
            ImageButton imgDownloadImg = (ImageButton)e.Row.FindControl("imgDownloadDoc");
            string strFileName = DataBinder.Eval(e.Row.DataItem, "Path").ToString();
           // string Encoded_FileName = Encode_Url(strFileName);
           // strFileName = clsGeneral.GetAttachmentImageURL(clsGeneral.TableNames[(int)clsGeneral.Tables.Franchise]) + Encoded_FileName;
           // imgDownloadImg.OnClientClick = "javascript:return openWindow('" + strFileName + "');";

            // set the file path and call the JS function
            string strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Franchise]) + strFileName;
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
    public void InitializeAttachmentDetails(decimal FK, bool AllowRemove, int intAttachmentPanelNumber)
    {
        this.FK_Franchise = FK;
        this.AllowRemove = AllowRemove;
        this.IntAttachmentPanel = intAttachmentPanelNumber;
        if (!AppConfig.AllowMailSending)
            btnMail.OnClientClick = "javascript:alert('Attachment cannot be sent as mailing option is disabled');return false;";
        else
            btnMail.OnClientClick = "javascript:ShowMailPage('" + clsGeneral.Tables.Franchise.ToString() + "');return false;";
        
    }

    /// <summary>
    /// Bind the Grid with the Attachment details.
    /// </summary>
    public void Bind()
    {
        if (FK_Franchise > 0)
        {
            //check Atrtchment table according to the table select the Data and fill the Grid
            DataTable dtAtt = Franchise_Attachments.SelectByFkFranchise(FK_Franchise).Tables[0];
            gvAttachment.DataSource = dtAtt;
            gvAttachment.DataBind();
            btnRemoveAttachment.Visible = (AllowRemove && dtAtt.Rows.Count > 0) ? true : false;
            btnMail.Visible = (AllowRemove && dtAtt.Rows.Count > 0) ? true : false;
            gvAttachment.Columns[0].Visible = AllowRemove;
        }
        else
            gvAttachment.DataBind();
    }

    ///<summary>
    ///method for encoding url in attachment grid
    ///</summary>
    protected string Encode_Url(string StrFilename)
    {
        string Result;
        Result = StrFilename;
        Result = Result.Replace("<", "%3C");
        Result = Result.Replace(">", "%3E");
        Result = Result.Replace("#", "%23");
        // Result = Result.Replace("%", "%25") ;
        Result = Result.Replace("{", "%7B");
        Result = Result.Replace("}", "%7D");
        Result = Result.Replace("|", "%7C");
        //Result = Result.Replace("\\","%5C") ;     
        Result = Result.Replace("^", "%5E");
        Result = Result.Replace("~", "%7E");
        Result = Result.Replace("[", "%5B");
        Result = Result.Replace("]", "%5D");
        Result = Result.Replace("`", "%60");
        Result = Result.Replace(";", "%3B");
        Result = Result.Replace("/", "%2F");
        Result = Result.Replace("?", "%3F");
        Result = Result.Replace(":", "%3A");
        Result = Result.Replace("@", "%40");
        Result = Result.Replace("=", "%3D");
        Result = Result.Replace("&", "%26");
        Result = Result.Replace("$", "%24");
        Result = Result.Replace("-", "%2D");
        Result = Result.Replace("+", "%2B");
        return Result;

    }
    #endregion
}
