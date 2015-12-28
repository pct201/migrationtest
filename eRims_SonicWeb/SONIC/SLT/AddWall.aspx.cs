using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_SLT_AddWall : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Wall Page Functionality is Add New Record in strtype Main and Comments wise in Main_Wall table.
    /// Save Attachment in Main_Wall_Attachment Table and Upload Images in Bulletin_Board folder in Documents sub folder
    /// </summary>
    /// <summary>
    /// primary key for Main_Wall record
    /// </summary>
    public int PK_Main_Wall
    {
        get
        {
            if (!clsGeneral.IsNull(ViewState["PK_Main_Wall"]))
                return Convert.ToInt32(ViewState["PK_Main_Wall"]);
            else
                return 0;
        }
        set { ViewState["PK_Main_Wall"] = value; }
    }
    /// <summary>
    /// Type for Main and Comment 
    /// </summary>
    public string strType
    {
        get
        {
            if (!clsGeneral.IsNull(ViewState["strType"]))
                return Convert.ToString(ViewState["strType"]);
            else
                return "";
        }
        set { ViewState["strType"] = value; }
    }
    #endregion

    #region "Page Event"
    /// <summary>
    /// Page Load Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblPoster.Text = clsSession.LastName + ", " + clsSession.FirstName;
            lblDate.Text = DateTime.Now.ToString();
            if (!clsGeneral.IsNull(Request.QueryString["type"]))
                strType = Request.QueryString["type"];

            // if id is passed in querystring.
            if (!clsGeneral.IsNull(Request.QueryString["id"]))
            {
                // set PK_Main_Wall id.
                PK_Main_Wall = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
            }
            //is strType 2 is Comments then set Topic TextBox value and Heading Title Change
            if (strType == "2")
            {
                clsMain_Wall objMailWall = new clsMain_Wall(PK_Main_Wall);
                txtTopic.Text = objMailWall.Topic;
                txtTopic.Enabled = false;
                lblHeadingMessage.Text = "Wall Post – Comment Message";
                lblTopic.Text = "Topic Thread";
                lblType.Text = "Comment";
            }
        }
    }
    #endregion

    #region "Event"
    /// <summary>
    /// Handle Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsMain_Wall objMailWall = new clsMain_Wall();
        //Check strType is 1 or 2 if strType 1 is set Main otherwise Comment
        if (strType == "1")
        {
            objMailWall.Type = "Main";
            objMailWall.FK_Main_Wall = null;
            objMailWall.Comment_Sequence = null;
        }
        else
        {
            objMailWall.PK_Main_Wall = PK_Main_Wall;
            objMailWall.Type = "Comment";
            objMailWall.FK_Main_Wall = PK_Main_Wall;
        }
        objMailWall.Last_Name = clsSession.LastName;
        objMailWall.First_Name = clsSession.FirstName;
        objMailWall.Topic = Convert.ToString(txtTopic.Text);
        objMailWall.Message = Convert.ToString(txtMessage.Text);
        objMailWall.Update_Date = DateTime.Now;
        objMailWall.Updated_By = clsSession.UserName;
        PK_Main_Wall = objMailWall.Insert();

        // if file is uploaded then get the byte array of the selected file    
        if (!string.IsNullOrEmpty(fpImage.PostedFile.FileName))
        {
            clsMain_Wall_Attachment objMain_Wall_Attachment = new clsMain_Wall_Attachment();
            objMain_Wall_Attachment.FK_Main_Wall = PK_Main_Wall;
            //get file name
            objMain_Wall_Attachment.Input_File_Name = fpImage.PostedFile.FileName.Substring(fpImage.PostedFile.FileName.LastIndexOf("\\") + 1);

            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath("Main_Wall_Attachment");
            string DocPath = string.Concat(strUploadPath, "\\");

            // upload and set the filename.
            objMain_Wall_Attachment.Stored_File_Name = clsGeneral.UploadFile(fpImage, DocPath, false, false);

            // get full image path of uploaded file
            string strOriginalFile = DocPath + objMain_Wall_Attachment.Stored_File_Name;

            // if uploaded file is an image/picture file then resize the image and save thumbnail
            if (strOriginalFile.ToLower().EndsWith(".jpg") || strOriginalFile.ToLower().EndsWith(".jpeg") || strOriginalFile.ToLower().EndsWith(".gif") ||
                strOriginalFile.ToLower().EndsWith(".png") || strOriginalFile.ToLower().EndsWith(".tif") || strOriginalFile.ToLower().EndsWith(".tiff"))
            {
                string strThumbnailName = objMain_Wall_Attachment.Stored_File_Name.Substring(0, objMain_Wall_Attachment.Stored_File_Name.LastIndexOf(".") - 1) + "_Thumb";
                string strExtenstion = objMain_Wall_Attachment.Stored_File_Name.Substring(objMain_Wall_Attachment.Stored_File_Name.LastIndexOf("."));
                string strNewFile = DocPath + strThumbnailName + strExtenstion;
                clsGeneral.ResizeImage(strOriginalFile, strNewFile, 150, 150, true);
            }

            //Insert the attachment record
            objMain_Wall_Attachment.Insert();
        }
        Response.Redirect("SLT_Wall.aspx");
    }
    /// <summary>
    /// Handle Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SLT_Wall.aspx");//Wall.aspx
    }
    #endregion
}