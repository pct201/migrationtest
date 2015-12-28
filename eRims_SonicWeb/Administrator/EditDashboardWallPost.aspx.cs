using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
public partial class Administrator_EditDashboardWallPost : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Hold Primary Key value
    /// </summary>
    public decimal _PK_Dashboard_Wall
    {
        get
        {
            if (ViewState["PK_Dashboard_Wall"] != null)
                return Convert.ToDecimal(ViewState["PK_Dashboard_Wall"]);
            else
                return 0;
        }
        set { ViewState["PK_Dashboard_Wall"] = value; }
    }

    /// <summary>
    /// Hold Primary Key value for Attachment
    /// </summary>
    public decimal _PK_Dashboard_Wall_Attachment
    {
        get
        {
            if (ViewState["PK_Dashboard_Wall_Attachment"] != null)
                return Convert.ToDecimal(ViewState["PK_Dashboard_Wall_Attachment"]);
            else
                return 0;
        }
        set { ViewState["PK_Dashboard_Wall_Attachment"] = value; }
    }

    #endregion

    #region "Page Events"

    /// <summary>
    /// page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                decimal decPK;
                if (decimal.TryParse(Convert.ToString(Encryption.Decrypt(Request.QueryString["id"])), out decPK))
                    _PK_Dashboard_Wall = decPK;
                else
                    _PK_Dashboard_Wall = 0;

                if (_PK_Dashboard_Wall > 0)
                    BindForEdit();
                else
                    Response.Redirect("DashboardWallSearch.aspx", true);
            }
            else
                Response.Redirect("DashboardWallSearch.aspx", true);
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind record for Edit
    /// </summary>
    private void BindForEdit()
    {
        clsDashboard_Wall objDashboardWall = new clsDashboard_Wall(_PK_Dashboard_Wall);
        lblPoster.Text = Convert.ToString(objDashboardWall.Last_Name) + ", " + Convert.ToString(objDashboardWall.First_Name);
        lblDate.Text = clsGeneral.FormatDBNullDateTimeToDisplay(objDashboardWall.Update_Date);
        txtTopic.Text = Convert.ToString(objDashboardWall.Topic);
        txtMessage.Text = Convert.ToString(objDashboardWall.Message);
        lblType.Text = Convert.ToString(objDashboardWall.Type);

        if (lblType.Text.Trim().ToLower() == "comment")
        {
            lblTopic.Text = "Topic Thread";
            lblHeadingMessage.Text = "Wall Post - Edit Comment";
            txtTopic.Enabled = false;
        }
        else
        {
            txtTopic.Enabled = true;
            lblHeadingMessage.Text = "Wall Post - Edit";
            lblTopic.Text = "Topic";
        }

        clsDashboard_Wall_Attachment objAttachment = new clsDashboard_Wall_Attachment(_PK_Dashboard_Wall, true);
        if (objAttachment.Input_File_Name != null && objAttachment.Stored_File_Name != null)
        {
            _PK_Dashboard_Wall_Attachment = Convert.ToDecimal(objAttachment.PK_Dashboard_Wall_Attachment);
            lnkFileAttached.Text = Convert.ToString(objAttachment.Input_File_Name);
            hdFileNameStored.Value = Convert.ToString(objAttachment.Stored_File_Name);

            lnkFileAttached.Visible = true;
            lnkDelet.Visible = true;
            lnkFileAttached.Style.Add("cursor", "hand");
            lnkFileAttached.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Dashboard_Wall_Attachment/" + Convert.ToString(objAttachment.Stored_File_Name) + "');";
        }
        else
        {
            _PK_Dashboard_Wall_Attachment = 0;
            lnkFileAttached.Visible = false;
            lnkDelet.Visible = false;
        }
    }

    #endregion

    #region "Control Events"

    /// <summary>
    /// Handle Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsDashboard_Wall objDashboard_Wall = new clsDashboard_Wall();
        objDashboard_Wall.PK_Dashboard_Wall = _PK_Dashboard_Wall;
        objDashboard_Wall.Message = Convert.ToString(txtMessage.Text);
        objDashboard_Wall.Topic = Convert.ToString(txtTopic.Text.Trim());

        objDashboard_Wall.Update();

        FileUploadProcess();

        Response.Redirect("DashboardWallSearch.aspx", true);
    }

    /// <summary>
    /// handle Cancel button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DashboardWallSearch.aspx", true);
    }

    /// <summary>
    /// Handle Remove Attachment Link Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkDelet_Click(object sender, EventArgs e)
    {
        hdFileNameStored.Value = "";
        lnkFileAttached.Text = "";
        lnkDelet.Visible = false;
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// File upload Process
    /// </summary>
    private void FileUploadProcess()
    {
        if (fludAttschment.HasFile)
        {
            clsDashboard_Wall_Attachment objDashboard_Wall_Attachment = new clsDashboard_Wall_Attachment();

            objDashboard_Wall_Attachment.PK_Dashboard_Wall_Attachment = _PK_Dashboard_Wall_Attachment;
            objDashboard_Wall_Attachment.FK_Dashboard_Wall = _PK_Dashboard_Wall;
            //get file name
            objDashboard_Wall_Attachment.Input_File_Name = fludAttschment.PostedFile.FileName.Substring(fludAttschment.PostedFile.FileName.LastIndexOf("\\") + 1);
            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath("Dashboard_Wall_Attachment");
            string DocPath = string.Concat(strUploadPath, "\\");
            // upload and set the filename.
            objDashboard_Wall_Attachment.Stored_File_Name = clsGeneral.UploadFile(fludAttschment, DocPath, false, false);

            // get full image path of uploaded file
            string strOriginalFile = DocPath + objDashboard_Wall_Attachment.Stored_File_Name;

            // if uploaded file is an image/picture file then resize the image and save thumbnail
            if (strOriginalFile.ToLower().EndsWith(".jpg") || strOriginalFile.ToLower().EndsWith(".jpeg") || strOriginalFile.ToLower().EndsWith(".gif") ||
                strOriginalFile.ToLower().EndsWith(".png") || strOriginalFile.ToLower().EndsWith(".tif") || strOriginalFile.ToLower().EndsWith(".tiff"))
            {
                string strThumbnailName = objDashboard_Wall_Attachment.Stored_File_Name.Substring(0, objDashboard_Wall_Attachment.Stored_File_Name.LastIndexOf(".") - 1) + "_Thumb";
                string strExtenstion = objDashboard_Wall_Attachment.Stored_File_Name.Substring(objDashboard_Wall_Attachment.Stored_File_Name.LastIndexOf("."));
                string strNewFile = DocPath + strThumbnailName + strExtenstion;
                clsGeneral.ResizeImage(strOriginalFile, strNewFile, 150, 150, true);
            }

            if (_PK_Dashboard_Wall_Attachment > 0)
                objDashboard_Wall_Attachment.Update();
            else
                objDashboard_Wall_Attachment.Insert();
        }
        else
        {
            if (_PK_Dashboard_Wall_Attachment > 0 && lnkFileAttached.Text.Trim() == "")
                clsDashboard_Wall_Attachment.DeleteByPK(_PK_Dashboard_Wall_Attachment);
        }
    }

    #endregion
}