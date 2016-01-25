using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
public partial class Administrator_EditWallPostByLocation : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Hold Primary Key value
    /// </summary>
    public decimal _PK_Wall_By_Location
    {
        get
        {
            if (ViewState["PK_Wall_By_Location"] != null)
                return Convert.ToDecimal(ViewState["PK_Wall_By_Location"]);
            else
                return 0;
        }
        set { ViewState["PK_Wall_By_Location"] = value; }
    }

    /// <summary>
    /// Hold Primary Key value for Attachment
    /// </summary>
    public decimal _PK_Wall_By_Location_Attachment
    {
        get
        {
            if (ViewState["PK_Wall_By_Location_Attachment"] != null)
                return Convert.ToDecimal(ViewState["PK_Wall_By_Location_Attachment"]);
            else
                return 0;
        }
        set { ViewState["PK_Wall_By_Location_Attachment"] = value; }
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
            BindDropdowns();
            if (Request.QueryString["id"] != null)
            {
                decimal decPK;
                if (decimal.TryParse(Convert.ToString(Encryption.Decrypt(Request.QueryString["id"])), out decPK))
                    _PK_Wall_By_Location = decPK;
                else
                    _PK_Wall_By_Location = 0;

                if (_PK_Wall_By_Location > 0)
                    BindForEdit();
                else
                    Response.Redirect("WallSearchByLocation.aspx", true);
            }
            else
                Response.Redirect("WallSearchByLocation.aspx", true);

        }
    }

    #endregion

    #region "Methods"

    private void BindDropdowns()
    {
        //region  
        if(clsSession.UserID == "")
            Response.Redirect("../Signin.aspx", false);
        else
            ddlRegion.DataSource = LU_Location.GetRegionListByUser(Convert.ToDecimal(clsSession.UserID)).Tables[0]; ;

        ddlRegion.DataTextField = "region";
        ddlRegion.DataValueField = "region";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("--All Regions--", ""));

        ComboHelper.FillMarket(new DropDownList[] { ddlMarket }, true);
        ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocationdba }, 0, true, true);
    } 

    /// <summary>
    /// Bind record for Edit
    /// </summary>
    private void BindForEdit()
    {
        clsWall_By_Location objWall_By_Location = new clsWall_By_Location(_PK_Wall_By_Location);
        lblPoster.Text = Convert.ToString(objWall_By_Location.Last_Name) + ", " + Convert.ToString(objWall_By_Location.First_Name);
        lblDate.Text = clsGeneral.FormatDBNullDateTimeToDisplay(objWall_By_Location.Update_Date);
        txtTopic.Text = Convert.ToString(objWall_By_Location.Topic);
        txtMessage.Text = Convert.ToString(objWall_By_Location.Message);
        lblType.Text = Convert.ToString(objWall_By_Location.Type);
        rdoFilter_By.SelectedValue = objWall_By_Location.Filter_By;

        if (objWall_By_Location.Filter_By == "Region")
            ddlRegion.SelectedValue = objWall_By_Location.Filter_Value;
        else if (objWall_By_Location.Filter_By == "Market")
            ddlMarket.SelectedValue = objWall_By_Location.Filter_Value;
        else if (objWall_By_Location.Filter_By == "Location")
            ddlLocationdba.SelectedValue = objWall_By_Location.Filter_Value; 
        
        if (lblType.Text.Trim().ToLower() == "comment")
        {
            lblTopic.Text = "Topic Thread";
            lblHeadingMessage.Text = "Wall Post By Location - Edit Comment";
            txtTopic.Enabled = false;
        }
        else
        {
            txtTopic.Enabled = true;
            lblHeadingMessage.Text = "Wall Post By Location - Edit";
            lblTopic.Text = "Topic";
        }
        
        clsWall_By_Location_Attachment objAttachment = new clsWall_By_Location_Attachment(_PK_Wall_By_Location, true);
        if (objAttachment.Input_File_Name != null && objAttachment.Stored_File_Name != null)
        {
            _PK_Wall_By_Location_Attachment = Convert.ToDecimal(objAttachment.PK_Wall_By_Location_Attachment);
            lnkFileAttached.Text = Convert.ToString(objAttachment.Input_File_Name);
            hdFileNameStored.Value = Convert.ToString(objAttachment.Stored_File_Name);

            lnkFileAttached.Visible = true;
            lnkDelet.Visible = true;
            lnkFileAttached.Style.Add("cursor", "hand");
            lnkFileAttached.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + Convert.ToString(objAttachment.Stored_File_Name) + "');";
        }
        else
        {
            _PK_Wall_By_Location_Attachment = 0;
            lnkFileAttached.Visible = false;
            lnkDelet.Visible = false;
        }

        ClientScript.RegisterStartupScript(this.GetType(), "ShowHideRegionMarketRow", "ShowHideRow();", true);
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
        clsWall_By_Location objWall_By_Location = new clsWall_By_Location();
        objWall_By_Location.PK_Wall_By_Location = _PK_Wall_By_Location;
        objWall_By_Location.Message = Convert.ToString(txtMessage.Text);
        objWall_By_Location.Topic = Convert.ToString(txtTopic.Text.Trim());
        objWall_By_Location.Filter_By = rdoFilter_By.SelectedValue;

        if (rdoFilter_By.SelectedValue == "Region")
            objWall_By_Location.Filter_Value = ddlRegion.SelectedValue;
        else if (rdoFilter_By.SelectedValue == "Market")
            objWall_By_Location.Filter_Value = ddlMarket.SelectedValue;
        else if (rdoFilter_By.SelectedValue == "Location")
            objWall_By_Location.Filter_Value = ddlLocationdba.SelectedValue;

        objWall_By_Location.Update_Date = DateTime.Now;
        objWall_By_Location.Updated_By = clsSession.UserName;

        objWall_By_Location.Update();

        FileUploadProcess();

        Response.Redirect("WallSearchByLocation.aspx", true);
    }

    /// <summary>
    /// handle Cancel button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("WallSearchByLocation.aspx", true);
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
            clsWall_By_Location_Attachment objWall_By_Location_Attachment = new clsWall_By_Location_Attachment();

            objWall_By_Location_Attachment.PK_Wall_By_Location_Attachment = _PK_Wall_By_Location_Attachment;
            objWall_By_Location_Attachment.FK_Wall_By_Location = _PK_Wall_By_Location;
            //get file name
            objWall_By_Location_Attachment.Input_File_Name = fludAttschment.PostedFile.FileName.Substring(fludAttschment.PostedFile.FileName.LastIndexOf("\\") + 1);
            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath("Main_Wall_Attachment");
            string DocPath = string.Concat(strUploadPath, "\\");
            // upload and set the filename.
            objWall_By_Location_Attachment.Stored_File_Name = clsGeneral.UploadFile(fludAttschment, DocPath, false, false);

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

            if (_PK_Wall_By_Location_Attachment > 0)
                objWall_By_Location_Attachment.Update();
            else
                objWall_By_Location_Attachment.Insert();
        }
        else
        {
            if (_PK_Wall_By_Location_Attachment > 0 && lnkFileAttached.Text.Trim() == "")
                clsMain_Wall_Attachment.DeleteByPK(_PK_Wall_By_Location_Attachment);
        }
    }

    #endregion
}