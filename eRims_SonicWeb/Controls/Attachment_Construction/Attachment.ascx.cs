using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.IO;
using System.Web.UI.HtmlControls;
using ASP;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class Controls_Attachment_Construction_Attachment : System.Web.UI.UserControl
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
    /// denotes Foreign Key of EPM_Identification table
    /// </summary>
    public decimal ConstructionProjectId
    {
        get { return Convert.ToDecimal(Session["ConstructionProjectId"]); }
        set { Session["ConstructionProjectId"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Attchments table
    /// </summary>
    public decimal PK_FCP_Attchments
    {
        get { return Convert.ToDecimal(ViewState["PK_FCP_Attchments"]); }
        set { ViewState["PK_FCP_Attchments"] = value; }
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

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridFolder();
            BindDropDown();

            if (StrOperation.ToLower() == "view")
            {
                btnAddDocument.Visible = false;
            }
        }
    }

    private void BindDropDown()
    {
        ComboHelper.FillLU_FCP_Attachment_Type(new DropDownList[] { drpFolder,Attachment1.DropdownFolder, Attachment2.DropdownFolder, Attachment3.DropdownFolder, Attachment4.DropdownFolder, 
            Attachment5.DropdownFolder, Attachment6.DropdownFolder,Attachment7.DropdownFolder,Attachment8.DropdownFolder,Attachment9.DropdownFolder,Attachment10.DropdownFolder }, true);
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
            LinkButton lnkDocName = (LinkButton)e.Row.FindControl("lnkDocName");

            string strFileName = DataBinder.Eval(e.Row.DataItem, "Attachment_Filename").ToString();

            lnkDocName.OnClientClick = "javascript:openWindow('../../Download.aspx?fname=" + Encryption.Encrypt(strFileName) + "&SLT=FCP_Docs');return false;";
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
            // get PK
            PK_FCP_Attchments = Convert.ToDecimal(e.CommandArgument);

            // bind the controls in edit mode
            // also set the controls required in edit mode
            FCP_Attachments objFCP_Attachment = new FCP_Attachments(PK_FCP_Attchments);
            tblEditAttachment.Visible = true;
            drpFolder.ClearSelection();
            drpFolder.SelectedValue = objFCP_Attachment.PK_LU_FC_Document_Folder.ToString();
            fpFile.Enabled = false;
            btnAddAttachment.Text = btnAddAttachment.Text.Replace("Add", "Edit");
            lblAttachHeader.Text = lblAttachHeader.Text.Replace("Add", "Edit");
            lblAttachHeader.Visible = true;
            lblAttachHeaderView.Visible = false;
            tblAddEditAttachment.Visible = true;
            hdnBackTo.Value = "1";
            tblFolderList.Visible = tblFileList.Visible = false;
            drpFolder.Enabled = true;
            fpFile.Enabled = false;
            btnAddAttachment.Visible = true;
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);

        }
        else if (e.CommandName == "ViewAttachment") // if command is for view
        {
            // get PK
            PK_FCP_Attchments = Convert.ToDecimal(e.CommandArgument);

            // bind the controls in view mode
            // also set the controls required for view mode
            FCP_Attachments objFCP_Attachment = new FCP_Attachments(PK_FCP_Attchments);
            tblEditAttachment.Visible = true;
            drpFolder.ClearSelection();
            drpFolder.SelectedValue = objFCP_Attachment.PK_LU_FC_Document_Folder.ToString();
            fpFile.Enabled = false;
            lblAttachHeader.Visible = false;
            lblAttachHeaderView.Visible = true;
            tblAddEditAttachment.Visible = true;
            hdnBackTo.Value = "1";
            drpFolder.Enabled = fpFile.Enabled = false;
            tblFolderList.Visible = tblFileList.Visible = false;
            btnAddAttachment.Visible = false;
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
        }
        if (e.CommandName == "DeleteAttachment")    // if command is for delete
        {
            // get the attachment ID
            string[] strArgs = e.CommandArgument.ToString().Split(':');

            // delete record from DB, delete attachment file as well as the pdf thumbnail
            FCP_Attachments.Delete(Convert.ToDecimal(strArgs[0]));
            if (File.Exists(AppConfig.strFCPDocumentPath + strArgs[1]))
                File.Delete(AppConfig.strFCPDocumentPath + strArgs[1]);
            if (File.Exists(AppConfig.strFCPDocumentPath + strArgs[1] + "_Thumb.jpg"))
                File.Delete(AppConfig.strFCPDocumentPath + strArgs[1] + "_Thumb.jpg");

            //re-bind the grid
            BindGridFiles();
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
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

    /// <summary>
    /// Handles event when sorting is performed in Files list grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFiles_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";
        _SortBy = e.SortExpression;
        BindGridFiles();
    }

    private void BindGridFolder()
    {
        DataTable dtFolder = FCP_Attachments.GetAttchmentFolderAndCount(ConstructionProjectId).Tables[0];
        gvFolders.DataSource = dtFolder;
        gvFolders.DataBind();
    }

    private void BindGridFiles()
    {
        // if claim id is avaialble
        if (ConstructionProjectId > 0)
        {
            // get the selected virtual folder IDs in comma seperated format
            string strFK_IDs = "";
            foreach (GridViewRow gRow in gvFolders.Rows)
            {
                if (((CheckBox)gRow.FindControl("chkFolder")).Checked)
                {
                    strFK_IDs += ((HtmlInputHidden)gRow.FindControl("hdnID")).Value + ",";
                }
            }
            strFK_IDs = strFK_IDs.TrimEnd(',');

            if (strFK_IDs == string.Empty)
                strFK_IDs = hdnVirtualFolderID.Value;

            // select the Data for selected virtual folders of the claim and fill the Grid
            DataTable dtFCP_Attachment = FCP_Attachments.SelectFilesByAttachmentType(strFK_IDs, ConstructionProjectId).Tables[0];

            // set the sort properties
            if (_SortBy == "" || _SortOrder == "")
            {
                _SortBy = "Attach_Date";
                _SortOrder = "asc";
            }
            // bind the grid
            dtFCP_Attachment.DefaultView.Sort = _SortBy + " " + _SortOrder;
            gvFiles.DataSource = dtFCP_Attachment;
            gvFiles.DataBind();
            btnViewPDF.Visible = false; //(dtAttachment.Rows.Count > 0);
            btnEmail.Visible = (dtFCP_Attachment.Rows.Count > 0);

            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
        }
        else
        {
            gvFiles.DataSource = null;
            gvFiles.DataBind();
            btnEmail.Visible = btnViewPDF.Visible = false;
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
        if (ConstructionProjectId > 0)
        {
            tblFolderList.Visible = false;
            tblAddEditAttachment.Visible = true;
            fpFile.Enabled = true;
            //drpFolder.SelectedIndex = 0;
            PK_FCP_Attchments = 0;
            btnAddAttachment.Text = btnAddAttachment.Text.Replace("Edit", "Add");
            lblAttachHeader.Text = lblAttachHeader.Text.Replace("Edit", "Add");
            lblAttachHeader.Visible = true;
            lblAttachHeaderView.Visible = false;
            hdnBackTo.Value = "0";
            tblAddEditAttachment.Visible = true;
            tblFolderList.Visible = tblFileList.Visible = false;
            btnAddAttachment.Visible = true;
            drpFolder.Enabled = fpFile.Enabled = true;
            tblAddAttachment.Visible = true;
            tblEditAttachment.Visible = false;
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
            tblFolderList.Visible = tblAddEditAttachment.Visible = false;
        }
        else
        {
            BindGridFolder();
            tblFolderList.Visible = true;
            tblFileList.Visible = tblAddEditAttachment.Visible = false;
        }
        if (PanelNumber > 0)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
    }

    /// <summary>
    /// Handles Add Attachment button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        // if claim PK is available
        if (ConstructionProjectId > 0)
        {
            {
                ////set values to store in database
                FCP_Attachments objFCPAttachment;

                if (PK_FCP_Attchments > 0)
                    objFCPAttachment = new FCP_Attachments(PK_FCP_Attchments);
                else
                    objFCPAttachment = new FCP_Attachments();

                bool bValid = true;
                string strExtension;

                // check file Extensions for new file name provided by user

                if (!clsGeneral.IsNull(fpFile.PostedFile))
                    strExtension = fpFile.PostedFile.FileName.Substring(fpFile.PostedFile.FileName.LastIndexOf("."));
                else
                    strExtension = objFCPAttachment.Attachment_Filename.Substring(objFCPAttachment.Attachment_Filename.LastIndexOf("."));


                // show error message if extensions are not same
                if (!bValid)
                {
                    //Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "alert('The extension for the new file name must be same as the old file name.');", true);
                }
                else
                {
                    // set properties from page controls
                    objFCPAttachment.FK_FCP_Identification = ConstructionProjectId;
                    objFCPAttachment.PK_LU_FC_Document_Folder = Convert.ToDecimal(drpFolder.SelectedValue);
                    objFCPAttachment.Updated_By = clsSession.UserID;
                    objFCPAttachment.Update_Date = DateTime.Now;
                    objFCPAttachment.Attach_Date = DateTime.Now;

                    // if PK is available then update the record
                    if (PK_FCP_Attchments > 0)
                    {
                        objFCPAttachment.Attachment_Description = objFCPAttachment.Attachment_Filename.Substring(12);
                        objFCPAttachment.Update();
                    }
                    else
                    {
                        if (!clsGeneral.IsNull(fpFile.PostedFile.FileName))
                        {
                            objFCPAttachment.Attachment_Description = fpFile.PostedFile.FileName.Substring(fpFile.PostedFile.FileName.LastIndexOf("\\") + 1);
                            // upload the document
                            string strUploadPath = AppConfig.strFCPDocumentPath;
                            // upload and set the filename.
                            objFCPAttachment.Attachment_Filename = clsGeneral.UploadFile(fpFile, strUploadPath, false, false);
                            //Insert the attachment record
                            PK_FCP_Attchments = objFCPAttachment.Insert();
                        }
                    }

                    // show/hide the required controls                    
                    btnAddAttachment.Text = btnAddAttachment.Text.Replace("Add", "Edit");
                    lblAttachHeader.Text = lblAttachHeader.Text.Replace("Add", "Edit");
                    fpFile.Enabled = false;
                    drpFolder.Enabled = true;
                }
                if (PanelNumber > 0)
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
            }
        }
    }

    protected void btnViewPDF_Click(object sender, EventArgs e)
    {

    }

    protected void btnCancelFile_Click(object sender, EventArgs e)
    {
        BindGridFolder();
        tblFolderList.Visible = true;
        tblFileList.Visible = tblAddEditAttachment.Visible = false;
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
        tblFolderList.Visible = tblAddEditAttachment.Visible = false;
        hdnVirtualFolderID.Value = "";
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
    }

    protected void btnSaveAttachments_Click(object sender, EventArgs e)
    {
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
        if (Is_AttachmentExists)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (PanelNumber > 0 ? "ShowPanel(" + PanelNumber + ");" : "") + "alert('Attachment saved successfully');", true);
        BindGridFolder();
        tblFolderList.Visible = true;
        tblAddAttachment.Visible = false;
        tblFileList.Visible = tblAddEditAttachment.Visible = false;
    }

    private void SaveAttachment(Controls_Attachment_Construction_EPM_Attach_Section obj)
    {
        if (obj.FileBrowser.HasFile && (obj.DropdownFolder.SelectedIndex > 0))
        {
            string strFolder = string.Empty; //strNewFileName = string.Empty;// strFileToAttach = string.Empty;
            if (obj.DropdownFolder.SelectedIndex > 0) strFolder = obj.DropdownFolder.SelectedValue;
            // strFileToAttach = obj.TextBoxFiletoAttach.Text;// Request.Form[obj.TextBoxFiletoAttach.UniqueID];
            ////set values to store in database
            FCP_Attachments objFCP_Attachments = new FCP_Attachments();
            bool bValid = true;
            string strExtension;
            // check file Extensions for new file name provided by user

            if (!string.IsNullOrEmpty(obj.FileBrowser.PostedFile.FileName))
                strExtension = obj.FileBrowser.PostedFile.FileName.Substring(obj.FileBrowser.PostedFile.FileName.LastIndexOf("."));
            else
                strExtension = objFCP_Attachments.Attachment_Filename.Substring(objFCP_Attachments.Attachment_Filename.LastIndexOf("."));


            // show error message if extensions are not same
            if (!bValid)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (PanelNumber > 0 ? "ShowPanel(" + PanelNumber + ");" : "") + "alert('The extension for the new file name must be same as the old file name.');", true);
            }
            else
            {
                // set properties from page controls
                objFCP_Attachments.FK_FCP_Identification = ConstructionProjectId;
                objFCP_Attachments.PK_LU_FC_Document_Folder = Convert.ToDecimal(obj.DropdownFolder.SelectedValue);
                objFCP_Attachments.Updated_By = clsSession.UserID;
                objFCP_Attachments.Update_Date = DateTime.Now;
                objFCP_Attachments.Attach_Date = DateTime.Now;
                objFCP_Attachments.Updated_By_Table = "Security";

                if (!string.IsNullOrEmpty(obj.FileBrowser.PostedFile.FileName))
                {
                    objFCP_Attachments.Attachment_Description = obj.FileBrowser.PostedFile.FileName.Substring(obj.FileBrowser.PostedFile.FileName.LastIndexOf("\\") + 1);
                    // upload the document
                    string strUploadPath = AppConfig.strFCPDocumentPath;
                    // upload and set the filename.
                    objFCP_Attachments.Attachment_Filename = clsGeneral.UploadFile(obj.FileBrowser, strUploadPath, false, false);

                    //Insert the attachment record
                    PK_FCP_Attchments = objFCP_Attachments.Insert();
                    Is_AttachmentExists = true;
                }
            }
        }
        if ((obj.DropdownFolder.SelectedItem.Text == "Audit/Inspections: Inspections" || obj.DropdownFolder.SelectedItem.Text == "Audit/Inspections: Phase I" ||
            obj.DropdownFolder.SelectedItem.Text == "Audit/Inspections: Phase II" || obj.DropdownFolder.SelectedItem.Text == "Audit/Inspections: Regulatory" ||
            obj.DropdownFolder.SelectedItem.Text == "Remediations") && Building_IDs != string.Empty)
        {
            DataTable dtFCP_Identification = clsEPM_Identification.GetPK_PM_SiteInfoForIdentification(Building_IDs).Tables[0];
            if (dtFCP_Identification != null && dtFCP_Identification.Rows.Count > 0)
            {
                for (int i = 0; i < dtFCP_Identification.Rows.Count; i++)
                {
                    string strPM_AttachUploadPath = AppConfig.Site_Info_AttachmentDocPath;
                    string name = clsGeneral.UploadFile(obj.FileBrowser, strPM_AttachUploadPath, false, false);

                    string strSQL = "";
                    strSQL = strSQL + "INSERT INTO " + "PM_Attachments" + Environment.NewLine;
                    strSQL = strSQL + "(" + "FK_PM_Site_Information" + "," + Environment.NewLine;
                    strSQL = strSQL + "FK_Attachment_Type" + "," + Environment.NewLine;
                    strSQL = strSQL + "Description" + "," + Environment.NewLine;
                    strSQL = strSQL + "Attachment_Path" + "," + Environment.NewLine;
                    strSQL = strSQL + "Updated_By" + "," + Environment.NewLine;
                    strSQL = strSQL + "Update_Date)" + Environment.NewLine;
                    strSQL = strSQL + "VALUES(" + Convert.ToString(dtFCP_Identification.Rows[i]["PK_PM_Site_Information"]) + "," + Environment.NewLine;
                    strSQL = strSQL + Convert.ToString(obj.DropdownFolder.SelectedValue) + "," + Environment.NewLine;
                    strSQL = strSQL + "'" + "" + "'," + Environment.NewLine;
                    strSQL = strSQL + "'" + name.Trim().Replace("'", "''") + "'," + Environment.NewLine;
                    strSQL = strSQL + (string.IsNullOrEmpty(clsSession.UserID) ? "''" : clsSession.UserID) + "," + Environment.NewLine;
                    strSQL = strSQL + "'" + Convert.ToString(DateTime.Now) + "')";

                    Database db = DatabaseFactory.CreateDatabase();
                    db.ExecuteNonQuery(System.Data.CommandType.Text, strSQL);
                }
            }
        }

    }

    protected void btnCancelAttachment_Add_Click(object sender, EventArgs e)
    {
        BindGridFolder();
        tblFolderList.Visible = true;
        tblFileList.Visible = tblAddEditAttachment.Visible = false;
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + PanelNumber + ");", true);
    }

    private void SetDefaultsForAttachment(Controls_Attachment_Construction_EPM_Attach_Section objAttachemnt)
    {
        objAttachemnt.TextBoxFiletoAttach.Text = "";
        objAttachemnt.DropdownFolder.SelectedIndex = -1;
    }

    #endregion
}
