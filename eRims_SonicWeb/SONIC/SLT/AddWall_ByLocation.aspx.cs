using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_SLT_AddWall_ByLocation : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Wall Page Functionality is Add New Record in strtype Main and Comments wise in Main_Wall table.
    /// Save Attachment in Main_Wall_Attachment Table and Upload Images in Bulletin_Board folder in Documents sub folder
    /// </summary>
    /// <summary>
    /// primary key for Main_Wall record
    /// </summary>
    public int PK_Wall_By_Location
    {
        get
        {
            if (!clsGeneral.IsNull(ViewState["PK_Wall_By_Location"]))
                return Convert.ToInt32(ViewState["PK_Wall_By_Location"]);
            else
                return 0;
        }
        set { ViewState["PK_Wall_By_Location"] = value; }
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
                // set PK_Wall_By_Location id.
                PK_Wall_By_Location = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
            }
            //is strType 2 is Comments then set Topic TextBox value and Heading Title Change
            if (strType == "2")
            {
                clsWall_By_Location objWall_By_Location = new clsWall_By_Location(PK_Wall_By_Location);
                txtTopic.Text = objWall_By_Location.Topic;
                txtTopic.Enabled = false;
                lblHeadingMessage.Text = "Wall Post – Comment Message";
                lblTopic.Text = "Topic Thread";
                lblType.Text = "Comment";
            }

            BindDropdowns();
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
        clsWall_By_Location objWall_By_Location = new clsWall_By_Location();
        //Check strType is 1 or 2 if strType 1 is set Main otherwise Comment
        if (strType == "1")
        {
            objWall_By_Location.Type = "Main";
            objWall_By_Location.FK_Wall_By_Location = null;
            objWall_By_Location.Comment_Sequence = null;
        }
        else
        {
            objWall_By_Location.PK_Wall_By_Location = PK_Wall_By_Location;
            objWall_By_Location.Type = "Comment";
            objWall_By_Location.PK_Wall_By_Location = PK_Wall_By_Location;
        }
        objWall_By_Location.Last_Name = clsSession.LastName;
        objWall_By_Location.First_Name = clsSession.FirstName;
        objWall_By_Location.Topic = Convert.ToString(txtTopic.Text);
        objWall_By_Location.Message = Convert.ToString(txtMessage.Text);
        objWall_By_Location.Filter_By = rdoFilter_By.SelectedValue;

        if (rdoFilter_By.SelectedValue == "Region")
            objWall_By_Location.Filter_Value = ddlRegion.SelectedValue;
        else if (rdoFilter_By.SelectedValue == "Market")
            objWall_By_Location.Filter_Value = ddlMarket.SelectedValue;
        
        objWall_By_Location.Update_Date = DateTime.Now;
        objWall_By_Location.Updated_By = clsSession.UserName;
        PK_Wall_By_Location = objWall_By_Location.Insert();

        // if file is uploaded then get the byte array of the selected file    
        if (!string.IsNullOrEmpty(fpImage.PostedFile.FileName))
        {
            clsWall_By_Location_Attachment objWall_By_Location_Attachment = new clsWall_By_Location_Attachment();
            objWall_By_Location_Attachment.FK_Wall_By_Location = PK_Wall_By_Location;
            //get file name
            objWall_By_Location_Attachment.Input_File_Name = fpImage.PostedFile.FileName.Substring(fpImage.PostedFile.FileName.LastIndexOf("\\") + 1);

            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath("Main_Wall_Attachment");
            string DocPath = string.Concat(strUploadPath, "\\");

            // upload and set the filename.
            objWall_By_Location_Attachment.Stored_File_Name = clsGeneral.UploadFile(fpImage, DocPath, false, false);

            // get full image path of uploaded file
            string strOriginalFile = DocPath + objWall_By_Location_Attachment.Stored_File_Name;

            // if uploaded file is an image/picture file then resize the image and save thumbnail
            if (strOriginalFile.ToLower().EndsWith(".jpg") || strOriginalFile.ToLower().EndsWith(".jpeg") || strOriginalFile.ToLower().EndsWith(".gif") ||
                strOriginalFile.ToLower().EndsWith(".png") || strOriginalFile.ToLower().EndsWith(".tif") || strOriginalFile.ToLower().EndsWith(".tiff"))
            {
                string strThumbnailName = objWall_By_Location_Attachment.Stored_File_Name.Substring(0, objWall_By_Location_Attachment.Stored_File_Name.LastIndexOf(".") - 1) + "_Thumb";
                string strExtenstion = objWall_By_Location_Attachment.Stored_File_Name.Substring(objWall_By_Location_Attachment.Stored_File_Name.LastIndexOf("."));
                string strNewFile = DocPath + strThumbnailName + strExtenstion;
                clsGeneral.ResizeImage(strOriginalFile, strNewFile, 150, 150, true);
            }

            //Insert the attachment record
            objWall_By_Location_Attachment.Insert();
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

    #region " Method "

    private void BindDropdowns()
    {
        //region       
        ddlRegion.DataSource = LU_Location.GetRegionListByUser(Convert.ToDecimal(clsSession.UserID)).Tables[0]; ;
        ddlRegion.DataTextField = "region";
        ddlRegion.DataValueField = "region";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("--All Regions--", ""));

        ComboHelper.FillMarket(new DropDownList[] { ddlMarket }, true);
    } 
    #endregion
}