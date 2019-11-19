using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public partial class Controls_Attachment_OC_Attachment : System.Web.UI.UserControl
{
    #region " Properties "

    /// <summary>
    /// Denote PanelNumber
    /// </summary>
    public int PanelNumber
    {
        get { return ViewState["PanelNumber"] != null ? Convert.ToInt32(ViewState["PanelNumber"]) : 0; }
        set { ViewState["PanelNumber"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Attchments table
    /// </summary>
    public decimal PK_AM_Attachments
    {
        get { return Convert.ToDecimal(ViewState["PK_AM_Attachments"]); }
        set { ViewState["PK_AM_Attachments"] = value; }
    }

    /// <summary>
    /// Denotes the sort field for file list grid
    /// </summary>
    private string _SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy" + this.ID]) ? ViewState["SortBy" + this.ID].ToString() : string.Empty); }
        set { ViewState["SortBy" + this.ID] = value; }
    }

    /// <summary>
    /// Denotes the sort order of the field in file list grid
    /// </summary>
    private string _SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder" + this.ID]) ? ViewState["SortOrder" + this.ID].ToString() : string.Empty); }
        set { ViewState["SortOrder" + this.ID] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    public bool Is_AttachmentExists
    {
        get { return ViewState["Is_AttachmentExists"] == null ? false : Convert.ToBoolean(ViewState["Is_AttachmentExists"]); }
        set { ViewState["Is_AttachmentExists"] = value; }
    }

    public string Building_IDs
    {
        get { return Convert.ToString(ViewState["Building_IDs"]); }
        set { ViewState["Building_IDs"] = value; }
    }

    public int Location_ID
    {
        get { return ViewState["Location_ID"] != null ? Convert.ToInt32(ViewState["Location_ID"]) : 0; }
        set { ViewState["Location_ID"] = value; }
    }

    public string AttachmentTable
    {
        get { return Convert.ToString(ViewState["AttachmentTable"]); }
        set { ViewState["AttachmentTable"] = value; }
    }

    public decimal PK_ID
    {
        get { return clsGeneral.GetDecimal(ViewState["PK_ID"]); }
        set { ViewState["PK_ID"] = value; }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridFiles();
            if (StrOperation.ToLower() == "view")
            {
                tblAddEditAttachment.Visible = false;
            }
            if (AttachmentTable == "Find_it_Fix_it_Attachments")
            {
                Attachment1.Table_Name = Attachment2.Table_Name = Attachment3.Table_Name = Attachment4.Table_Name = "Find_it_Fix_it_Attachments";
                Attachment5.Table_Name = Attachment6.Table_Name = Attachment7.Table_Name = Attachment8.Table_Name = "Find_it_Fix_it_Attachments";
                Attachment9.Table_Name = Attachment10.Table_Name = "Find_it_Fix_it_Attachments";
            }
        }
    }
    #region " Grid Events"

    /// <summary>
    /// Handles event when files grid row is bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (StrOperation == "view")
            {
                gvFiles.Columns[gvFiles.Columns.Count - 1].Visible = false;
            }

            string strFileName = DataBinder.Eval(e.Row.DataItem, "File_Name").ToString();
            string strPK_ID = DataBinder.Eval(e.Row.DataItem, "PK_Find_it_Fix_it_Attachments").ToString();

            LinkButton lnkDocName = (LinkButton)e.Row.FindControl("lnkDocName");
            lnkDocName.OnClientClick = "javascript:openWindow('../../Download.aspx?FindFix_Attch_Id=" + Encryption.Encrypt(strPK_ID) + "&tbl=" + AttachmentTable + "');return false;";

            LinkButton lnkDocNewName = (LinkButton)e.Row.FindControl("lnkDocNewName");
            lnkDocNewName.OnClientClick = "javascript:openWindow('../../Download.aspx?FindFix_Attch_Id=" + Encryption.Encrypt(strPK_ID) + "&tbl=" + AttachmentTable + "');return false;";

            LinkButton lnkDocType = (LinkButton)e.Row.FindControl("lnkDocType");
            lnkDocType.OnClientClick = "javascript:openWindow('../../Download.aspx?FindFix_Attch_Id=" + Encryption.Encrypt(strPK_ID) + "&tbl=" + AttachmentTable + "');return false;";

            LinkButton lnkEmail = (LinkButton)e.Row.FindControl("lnkEmail");
            lnkEmail.OnClientClick = "javascript:ShowDialog('" + AppConfig.SiteURL + "SONIC/Exposures/AM_Attachment_Mail.aspx?FindFix_Attch_Id=" + Encryption.Encrypt(strPK_ID) + "&tbl=" + AttachmentTable + "');return false;";
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (AttachmentTable == "Find_it_Fix_it_Attachments")
                e.Row.Cells[0].Text = "";
            else
                e.Row.Cells[0].Text = "Document";
        }
    }

    /// <summary>
    /// Handles files grid command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // when command is for editing the attachment
        if (e.CommandName == "EditAttachment")
        {

        }
        else if (e.CommandName == "ViewAttachment") // if command is for view
        {

        }
        if (e.CommandName == "DeleteAttachment")    // if command is for delete
        {
            // get the attachment ID
            string[] strArgs = e.CommandArgument.ToString().Split(':');

            if (PK_ID > 0)
            {
                if (AttachmentTable == "Find_it_Fix_it_Attachments")
                {
                    clsFind_it_Fix_it_Attachments.DeleteByPK(clsGeneral.GetDecimal(strArgs[0]));
                    if (File.Exists(AppConfig.Find_it_Fix_it_AttachmentsDocPath + strArgs[1]))
                        File.Delete(AppConfig.Find_it_Fix_it_AttachmentsDocPath + strArgs[1]);
                }
                BindGridFiles();
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
            }
        }
    }

    /// <summary>
    /// Handles event when grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFiles_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy)
            {
                // update sort image beside the column header 
                AddSortImage(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[1].Controls.Add(sortImage);
            }
        }
    }

    public void BindGridFiles()
    {
        if (PK_ID > 0)
        {
            if (AttachmentTable == "Find_it_Fix_it_Attachments")
            {
                lblAttachHeader.Text = lblAttachHeaderView.Text = "Add Attachment";
                DataTable dtAttachment = clsFind_it_Fix_it_Attachments.SelectByFK_Find_It_Fix_It(PK_ID).Tables[0];
                gvFiles.DataSource = dtAttachment;
                gvFiles.DataBind();

                //btnViewPDF.Visible =(dtAttachment.Rows.Count > 0);
                //btnEmail.Visible = (dtAttachment.Rows.Count > 0);
            }
            //Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
        }
        else
        {
            gvFiles.DataSource = null;
            gvFiles.DataBind();
            //btnEmail.Visible = btnViewPDF.Visible = false;
        }
    }

    #endregion

    #region " Private Methods "
    /// <summary>
    /// Used to add image beside the grid column on which sorting is done
    /// </summary>
    /// <param name="headerRow"></param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(_SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = _SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == strSortOrder)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }

    /// <summary>
    /// Used to get column index on which sorting is done
    /// </summary>
    /// <param name="strSortExp"></param>
    /// <returns></returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 1;
        // Iterate through the Columns collection to determine the index of the column being sorted.        
        foreach (DataControlField field in gvFiles.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvFiles.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    #endregion

    #region " Control Events "

    protected void btnAddDocument_Click(object sender, EventArgs e)
    {
        if (Location_ID > 0)
        {
            //tblAddEditAttachment.Visible = true;
            fpFile.Enabled = true;
            //drpFolder.SelectedIndex = 0;
            PK_AM_Attachments = 0;
            btnAddAttachment.Text = btnAddAttachment.Text.Replace("Edit", "Add");
            lblAttachHeader.Text = lblAttachHeader.Text.Replace("Edit", "Add");
            lblAttachHeader.Visible = true;
            lblAttachHeaderView.Visible = false;
            hdnBackTo.Value = "0";
            //tblAddEditAttachment.Visible = true;
            btnAddAttachment.Visible = true;
            //drpFolder.Enabled = fpFile.Enabled = true;
            //tblAddAttachment.Visible = true;
            //tblEditAttachment.Visible = false;
            SetDefaultsForAttachment(Attachment1);
            SetDefaultsForAttachment(Attachment2);
            SetDefaultsForAttachment(Attachment3);
            SetDefaultsForAttachment(Attachment4);
            SetDefaultsForAttachment(Attachment5);
            SetDefaultsForAttachment(Attachment6);
            SetDefaultsForAttachment(Attachment7);
            SetDefaultsForAttachment(Attachment8);
            SetDefaultsForAttachment(Attachment9);
            SetDefaultsForAttachment(Attachment10);
        }
        if (PanelNumber > 0)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
    }

    protected void btnCancelAttachment_Click(object sender, EventArgs e)
    {
        if (hdnBackTo.Value == "1")
        {
            BindGridFiles();
            tblFileList.Visible = true;
        }
        else
        {
            //tblFileList.Visible = tblAddEditAttachment.Visible = false;
        }
        if (PanelNumber > 0)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
    }

    /// <summary>
    /// Handles Add Attachment button click event "Edit Mode"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        // if claim PK is available
        if (Location_ID > 0)
        {
            {
                ////set values to store in database
                clsAM_Attachments objAMAttachment;

                if (PK_AM_Attachments > 0)
                    objAMAttachment = new clsAM_Attachments(PK_AM_Attachments);
                else
                    objAMAttachment = new clsAM_Attachments();

                bool bValid = true;
                string strExtension;

                // check file Extensions for new file name provided by user

                if (!clsGeneral.IsNull(fpFile.PostedFile))
                    strExtension = fpFile.PostedFile.FileName.Substring(fpFile.PostedFile.FileName.LastIndexOf("."));
                else
                    strExtension = objAMAttachment.Attachment_Filename.Substring(objAMAttachment.Attachment_Filename.LastIndexOf("."));


                // show error message if extensions are not same
                if (!bValid)
                {
                    //Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "alert('The extension for the new file name must be same as the old file name.');", true);
                }
                else
                {
                    // set properties from page controls
                    objAMAttachment.FK_LU_Location = Location_ID;
                    //objAMAttachment.Attachment_Type = Convert.ToDecimal(drpFolder.SelectedValue);
                    objAMAttachment.Updated_By = clsSession.UserID;
                    objAMAttachment.Updated_Date = DateTime.Now;
                    objAMAttachment.Attach_Date = DateTime.Now;

                    // if PK is available then update the record
                    if (PK_AM_Attachments > 0)
                    {
                        objAMAttachment.Attachment_Description = objAMAttachment.Attachment_Filename.ToString();
                        objAMAttachment.Update();
                    }
                    else
                    {
                        if (!clsGeneral.IsNull(fpFile.PostedFile.FileName))
                        {
                            objAMAttachment.Attachment_Description = fpFile.PostedFile.FileName.Substring(fpFile.PostedFile.FileName.LastIndexOf("\\") + 1);
                            // upload the document
                            string strUploadPath = AppConfig.strEPMDocumentPath;
                            // upload and set the filename.
                            objAMAttachment.Attachment_Filename = clsGeneral.UploadFile(fpFile, strUploadPath, false, false);
                            //Insert the attachment record
                            PK_AM_Attachments = objAMAttachment.Insert();
                        }
                    }

                    // show/hide the required controls                    
                    btnAddAttachment.Text = btnAddAttachment.Text.Replace("Add", "Edit");
                    lblAttachHeader.Text = lblAttachHeader.Text.Replace("Add", "Edit");
                    fpFile.Enabled = false;
                    //drpFolder.Enabled = true;
                }
                if (PanelNumber > 0)
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
            }
        }
    }

    protected void btnCancelFile_Click(object sender, EventArgs e)
    {
        //tblFileList.Visible = tblAddEditAttachment.Visible = false;
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
    }

    protected void btnEmail_Click(object sender, EventArgs e)
    {
        // loop through each row in gridview and get count for rows having PDF docs selected
        int pdfCount = 0;
        string strIDs = "";
        foreach (GridViewRow gRow in gvFiles.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkFile")).Checked)
            {
                //if (((Label)gRow.FindControl("lblType")).Text.ToLower() == "pdf")
                {
                    strIDs = strIDs + ((HtmlInputHidden)gRow.FindControl("hdnID")).Value + ",";
                    pdfCount++;
                }
            }
        }
        strIDs = strIDs.TrimEnd(',');

        // if no PDFs selected then show message else show PDFViewer page
        if (pdfCount > 0)
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowMailPage('" + strIDs + "');", true);
        }
        else
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (PanelNumber > 0 ? "ShowPanel(" + PanelNumber + ");" : "") + "alert('Please select at least one file');", true);
    }

    protected void btnViewSelection_Click(object sender, EventArgs e)
    {
        // set sorting properties and bind the file list grid
        _SortBy = "Attach_Date";
        _SortOrder = "asc";
        BindGridFiles();

        // show/hide required controls
        tblFileList.Visible = true;
        hdnVirtualFolderID.Value = "";
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
    }

    protected void btnSaveAttachments_Click(object sender, EventArgs e)
    {
        string tbl = string.Empty;
        if (PK_ID == 0)
        {
            if (AttachmentTable == "Find_it_Fix_it_Attachments")
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Please Save Find it And Fix It Details First');ShowPanel(5);", true);
            }

            return;
        }

        Is_AttachmentExists = false;
        SaveAttachment(Attachment1);
        SaveAttachment(Attachment2);
        SaveAttachment(Attachment3);
        SaveAttachment(Attachment4);
        SaveAttachment(Attachment5);
        SaveAttachment(Attachment6);
        SaveAttachment(Attachment7);
        SaveAttachment(Attachment8);
        SaveAttachment(Attachment9);
        SaveAttachment(Attachment10);
        BindGridFiles();
        if (Is_AttachmentExists)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Attachment saved successfully');ShowPanel(" + PanelNumber + ");", true);
        //tblAddAttachment.Visible = false;
        //tblFileList.Visible = tblAddEditAttachment.Visible = false;
    }


    private void SaveAttachment(controls_attachment_find_it_fix_it_am_attach_section_ascx obj)
    {
        if (obj.FileBrowser.HasFile)
        {
            if (AttachmentTable == "Find_it_Fix_it_Attachments")
            {
                clsFind_it_Fix_it_Attachments objFindItFixItAttachments = new clsFind_it_Fix_it_Attachments();

                objFindItFixItAttachments.Updated_By = clsSession.UserID;
                objFindItFixItAttachments.Update_Date = DateTime.Now;
                objFindItFixItAttachments.FK_Find_it_Fix_it = PK_ID;

                if (!string.IsNullOrEmpty(obj.FileBrowser.PostedFile.FileName))
                {
                    TextBox txtAttachmentNameAdd = (TextBox)obj.FindControl("txtAttachmentNameAdd");
                    if (txtAttachmentNameAdd != null)
                        objFindItFixItAttachments.Attachment_Name = txtAttachmentNameAdd.Text;

                    RadioButtonList rblAttachmentType = (RadioButtonList)obj.FindControl("rblAttachmentType");
                    if (rblAttachmentType != null)
                        objFindItFixItAttachments.Attachment_Type = rblAttachmentType.Text == "1" ? "Find It" : "Fix It";

                    string strUploadPath = AppConfig.Find_it_Fix_it_AttachmentsDocPath;
                    objFindItFixItAttachments.File_Name = clsGeneral.UploadFile(obj.FileBrowser, strUploadPath, false, false);

                    PK_AM_Attachments = objFindItFixItAttachments.Insert();
                    Is_AttachmentExists = true;
                    txtAttachmentNameAdd.Text = string.Empty;
                }
            }

            string strFolder = string.Empty; //strNewFileName = string.Empty;// strFileToAttach = string.Empty;

            //clsAM_Attachments objAM_Attachments = new clsAM_Attachments();
            //bool bValid = true;
            //string strExtension;
            //// check file Extensions for new file name provided by user

            //if (!string.IsNullOrEmpty(obj.FileBrowser.PostedFile.FileName))
            //    strExtension = obj.FileBrowser.PostedFile.FileName.Substring(obj.FileBrowser.PostedFile.FileName.LastIndexOf("."));
            //else
            //    strExtension = objAM_Attachments.Attachment_Filename.Substring(objAM_Attachments.Attachment_Filename.LastIndexOf("."));


            // show error message if extensions are not same
            //if (!bValid)
            //{
            //    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (PanelNumber > 0 ? "ShowPanel(" + PanelNumber + ");" : "") + "alert('The extension for the new file name must be same as the old file name.');", true);
            //}
            //else
            //{
            //    // set properties from page controls
            //    objAM_Attachments.FK_LU_Location = Location_ID;
            //    //objAM_Attachments.Attachment_Type = Convert.ToDecimal(obj.DropdownFolder.SelectedValue);
            //    objAM_Attachments.Updated_By = clsSession.UserID;
            //    objAM_Attachments.Updated_Date = DateTime.Now;
            //    objAM_Attachments.Attach_Date = DateTime.Now;

            //    if (!string.IsNullOrEmpty(obj.FileBrowser.PostedFile.FileName))
            //    {
            //        objAM_Attachments.Attachment_Description = obj.FileBrowser.PostedFile.FileName.Substring(obj.FileBrowser.PostedFile.FileName.LastIndexOf("\\") + 1);
            //        // upload the document
            //        string strUploadPath = AppConfig.strAPDocumentPath;
            //        // upload and set the filename.
            //        objAM_Attachments.Attachment_Filename = clsGeneral.UploadFile(obj.FileBrowser, strUploadPath, false, false);

            //        //Insert the attachment record
            //        PK_AM_Attachments = objAM_Attachments.Insert();
            //        Is_AttachmentExists = true;
            //    }
            //}
        }
    }

    //protected void btnCancelAttachment_Add_Click(object sender, EventArgs e)
    //{
    //    //tblFileList.Visible = tblAddEditAttachment.Visible = false;
    //    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
    //}

    private void SetDefaultsForAttachment(Controls_Attachment_AssetProtection_AM_Attach_Section objAttachemnt)
    {
        objAttachemnt.TextBoxFiletoAttach.Text = "";
        //objAttachemnt.DropdownFolder.SelectedIndex = -1;
    }

    #endregion
}