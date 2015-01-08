using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using ERIMS.DAL;
//using iTextSharp.text.pdf;

public partial class Controls_Attachments_AttachmentEvent : System.Web.UI.UserControl
{
    #region " Properties "
    /// <summary>
    /// Denotes primary key for Attachment 
    /// </summary>
    public decimal PK_Attachment_Event
    {
        get { return Convert.ToDecimal(ViewState["PK_Attachment_Event" + this.ID]); }
        set { ViewState["PK_Attachment_Event" + this.ID] = value; }
    }

    /// <summary>
    /// Denotes major coverage of the claim
    /// </summary>
    public int MajorCoverage
    {
        get { return 18; }
        set { ViewState["AttachMajCov" + this.ID] = value; }
    }

    /// <summary>
    /// Denotes the name of the Attachment table 
    /// </summary>
    public clsGeneral.Tables Attachment_Table
    {
        get { return (clsGeneral.Tables)Enum.Parse(typeof(clsGeneral.Tables), Convert.ToString(ViewState["Attachment_Table" + this.ID])); }
        set { ViewState["Attachment_Table" + this.ID] = value; }
    }

    /// <summary>
    /// Denotes PK of the claim for which the attachment is to be added
    /// </summary>
    public decimal FK_Table
    {
        get { return Convert.ToDecimal(ViewState["FK_Table" + this.ID]); }
        set { ViewState["FK_Table" + this.ID] = value; }
    }

    /// <summary>
    /// Denotes panel number on which attachment control is added
    /// </summary>
    public int AttathmentPanelNumber
    {
        get { return ViewState["AttathmentPanelNumber" + this.ID] != null ? Convert.ToInt32(ViewState["AttathmentPanelNumber" + this.ID]) : 0; }
        set { ViewState["AttathmentPanelNumber" + this.ID] = value; }
    }

    /// <summary>
    /// Denotes whether to allow add/edit for attachment or not
    /// </summary>
    public bool ReadOnly
    {
        get { return ViewState["ReadOnlyAttach" + this.ID] == null ? true : Convert.ToBoolean(ViewState["ReadOnlyAttach" + this.ID]); }
        set { ViewState["ReadOnlyAttach" + this.ID] = value; }
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
    #endregion

    #region " Page Events "

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // bind folder grid and other required dropdowns
            BindGridFolders();
            BindDropdowns();
        }
    }

    #endregion

    #region " Folders "

    /// <summary>
    /// Binds dropdowns used for adding/editing attachment
    /// </summary>
    private void BindDropdowns()
    {
        // virtual folder dropdown
        DataTable dtFolder = clsVirtual_Folder.SelectForAddAttachment(((int)MajorCoverage).ToString(), Attachment_Table.ToString(), FK_Table, Convert.ToDecimal(clsSession.UserID)).Tables[0];
        dtFolder.DefaultView.Sort = "Folder_Name";
        drpFolder.DataSource = dtFolder.DefaultView;
        drpFolder.DataTextField = "Folder_Name";
        drpFolder.DataValueField = "PK_Virtual_Folder";
        drpFolder.DataBind();
        drpFolder.Items.Insert(0, new ListItem("--Select--", "0"));

        // tags dropdown
        //DataTable dtTags = clsLU_Tag.SelectAll().Tables[0];
        //dtTags.DefaultView.Sort = "Tag_Name";
        //drpTag.DataSource = dtTags.DefaultView;
        //drpTag.DataTextField = "Tag_Name";
        //drpTag.DataValueField = "PK_LU_Tag";
        //drpTag.DataBind();
        //drpTag.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// Binds grid for folder list
    /// </summary>
    public void BindGridFolders()
    {
        // select virtual folder records by major coverage, claim ID and currently logged in user id
        DataTable dtFolder = clsVirtual_Folder.SelectForAddAttachment(((int)MajorCoverage).ToString(), Attachment_Table.ToString(), FK_Table, Convert.ToDecimal(clsSession.UserID)).Tables[0];
        gvFolders.DataSource = dtFolder;
        gvFolders.DataBind();

        // set control states
        btnViewSelection.Visible = (dtFolder.Rows.Count > 0);
        SetControlsByAccess();
    }

    /// <summary>
    /// Handles event when View Selection button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        ShowPanel();
    }

    /// <summary>
    /// Handles event when Add Document button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddDocument_Click(object sender, EventArgs e)
    {
        // if claim id is available
        if (FK_Table > 0)
        {
            // set controls in add mode
            PK_Attachment_Event = 0;
            drpFolder.SelectedIndex = 0;
            fpFile.Enabled = true;
            rfvFile.Enabled = true;
            txtNewFileName.Text = "";
            //drpTag.SelectedIndex = 0;
            //drpTag.Enabled = false;
            //gvTags.DataBind();
            btnAddAttachment.Text = btnAddAttachment.Text.Replace("Edit", "Add");
            lblAttachHeader.Text = lblAttachHeader.Text.Replace("Edit", "Add");
            lblAttachHeader.Visible = true;
            lblAttachHeaderView.Visible = false;
            hdnBackTo.Value = "0";
            tblAddEditAttachment.Visible = true;
            tblFolderList.Visible = tblFileList.Visible = false;
            btnAddAttachment.Visible = true;// btnAddTag.Visible = btnDeleteTag.Visible = true;
            //btnAddTag.Enabled = btnDeleteTag.Visible = false;
            drpFolder.Enabled = txtNewFileName.Enabled = fpFile.Enabled = rfvFile.Enabled = true;
            ShowPanel();
        }
        else
        {
            // set the attachment table name from enum
            string strTableName = "";
            if (Attachment_Table == clsGeneral.Tables.Event) strTableName = "Event";
            else strTableName = "";

            // show message to the user to save the claim record
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "alert('Please first save the " + strTableName + " Information');", true);
        }
    }

    #endregion

    #region " Files "

    /// <summary>
    /// Binds the grid for file list
    /// </summary>
    private void BindGridFiles()
    {
        // if claim id is avaialble
        if (FK_Table > 0)
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
            DataTable dtAttachment = clsAttachment_Event.SelectForClaim(FK_Table, strFK_IDs, Attachment_Table.ToString(), Convert.ToDecimal(clsSession.UserID)).Tables[0];

            // set the sort properties
            if (_SortBy == "" || _SortOrder == "")
            {
                _SortBy = "Attach_Date";
                _SortOrder = "asc";
            }
            // bind the grid
            dtAttachment.DefaultView.Sort = _SortBy + " " + _SortOrder;
            gvFiles.DataSource = dtAttachment;
            gvFiles.DataBind();
            btnViewPDF.Visible = false; //(dtAttachment.Rows.Count > 0);
            btnEmail.Visible = dtAttachment.Rows.Count > 0;
            // show/hide the edit, view, delete linkbutton in grid as per the user rights
            foreach (GridViewRow gRow in gvFiles.Rows)
            {
                bool bView = Convert.ToBoolean(Convert.ToInt32(((HtmlInputHidden)gRow.FindControl("hdnView")).Value));
                bool bEdit = Convert.ToBoolean(Convert.ToInt32(((HtmlInputHidden)gRow.FindControl("hdnEdit")).Value));
                bool bAdd = Convert.ToBoolean(Convert.ToInt32(((HtmlInputHidden)gRow.FindControl("hdnAdd")).Value));
                bool bDelete = Convert.ToBoolean(Convert.ToInt32(((HtmlInputHidden)gRow.FindControl("hdnDelete")).Value));
                ((LinkButton)gRow.FindControl("lnkEdit")).Visible = !ReadOnly && (bDelete || bAdd || bEdit);
                ((LinkButton)gRow.FindControl("lnkView")).Visible = ReadOnly || (bDelete || bAdd || bEdit || bView);
                ((LinkButton)gRow.FindControl("lnkDelete")).Visible = !ReadOnly && bDelete;
            }
            gvFiles.Columns[5].Visible = !ReadOnly;
            SetControlsByAccess();
        }
        else
        {
            gvFiles.DataSource = null;
            gvFiles.DataBind();
            btnViewPDF.Visible = false;
        }
    }

    /// <summary>
    /// Binds the grid for tags list
    /// </summary>
    //private void BindGridTags()
    //{
    //    // select tags records for attachment and bind the grid
    //    DataTable dtTags = clsAttachment_Tag.SelectByFK(PK_Attachment).Tables[0];
    //    gvTags.DataSource = dtTags;
    //    gvTags.DataBind();

    //    // show delete tag if records are available
    //    btnDeleteTag.Visible = dtTags.Rows.Count > 0;
    //}

    /// <summary>
    /// Handles View PDF(s) button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        // loop through each row in gridview and get count for rows having PDF docs selected
        int pdfCount = 0;
        string strIDs = "";
        foreach (GridViewRow gRow in gvFiles.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkFile")).Checked)
            {
                if (((Label)gRow.FindControl("lblType")).Text.ToLower() == "pdf")
                {
                    strIDs = strIDs + ((HtmlInputHidden)gRow.FindControl("hdnID")).Value + ",";
                    pdfCount++;
                }
            }
        }
        strIDs = strIDs.TrimEnd(',');

        // if no PDFs selected then show message else show PDFViewer page
        if (pdfCount > 0)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "window.open('" + AppConfig.SiteURL + "AttachmentViewer.aspx?id=" + Encryption.Encrypt(strIDs) + "');", true);
        else
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "alert('Please select at least one PDF file');", true);
    }

    /// <summary>
    /// Handles View PDF(s) button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowMailPage('" + strIDs + "');", true);
        else
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "alert('Please select at least one file');", true);
    }
    /// <summary>
    /// Handles event when files grid row is bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // set code for download link for each row in gridview
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDocName = (LinkButton)e.Row.FindControl("lnkDocName");
            string strURL = AppConfig.SiteURL + "/Download.aspx?ID=" + Encryption.Encrypt(DataBinder.Eval(e.Row.DataItem, "PK_Attachment").ToString()) + "&claimtbl=1";
            lnkDocName.OnClientClick = "javascript:return openWindow('" + strURL + "');";
            //((LinkButton)e.Row.FindControl("lnkEdit")).Style.Add("display", "none");
            //((LinkButton)e.Row.FindControl("lnkView")).Style.Add("display", "none");
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
            PK_Attachment_Event = Convert.ToDecimal(e.CommandArgument);

            // bind the controls in edit mode
            // also set the controls required in edit mode
            clsAttachment_Event objAttachment = new clsAttachment_Event(PK_Attachment_Event);
            drpFolder.ClearSelection();
            //drpTag.ClearSelection();
            drpFolder.SelectedValue = objAttachment.FK_Virtual_Folder.ToString();
            txtNewFileName.Text = objAttachment.Attachment_Description;
            fpFile.Enabled = false;
            rfvFile.Enabled = false;
            btnAddAttachment.Text = btnAddAttachment.Text.Replace("Add", "Edit");
            lblAttachHeader.Text = lblAttachHeader.Text.Replace("Add", "Edit");
            lblAttachHeader.Visible = true;
            lblAttachHeaderView.Visible = false;
            tblAddEditAttachment.Visible = true;
            //BindGridTags();
            hdnBackTo.Value = "1";
            //btnAddTag.Enabled = true;
            tblFolderList.Visible = tblFileList.Visible = false;
            drpFolder.Enabled = txtNewFileName.Enabled = true;// drpTag.Enabled = true;
            fpFile.Enabled = rfvFile.Enabled = false;
            btnAddAttachment.Visible = true;// btnAddTag.Visible = btnDeleteTag.Visible = true;
            SetControlsByAccess();
            ShowPanel();
        }
        else if (e.CommandName == "ViewAttachment") // if command is for view
        {
            // get PK
            PK_Attachment_Event = Convert.ToDecimal(e.CommandArgument);

            // bind the controls in view mode
            // also set the controls required for view mode
            clsAttachment_Event objAttachment = new clsAttachment_Event(PK_Attachment_Event);
            drpFolder.ClearSelection();
            drpFolder.SelectedValue = objAttachment.FK_Virtual_Folder.ToString();
            txtNewFileName.Text = objAttachment.Attachment_Description;
            fpFile.Enabled = false;
            rfvFile.Enabled = false;
            lblAttachHeader.Visible = false;
            lblAttachHeaderView.Visible = true;
            tblAddEditAttachment.Visible = true;
            //BindGridTags();
            hdnBackTo.Value = "1";
            drpFolder.Enabled = txtNewFileName.Enabled = fpFile.Enabled = rfvFile.Enabled = false;// drpTag.Enabled = false;
            tblFolderList.Visible = tblFileList.Visible = false;
            btnAddAttachment.Visible = true;// btnDeleteTag.Visible = btnAddTag.Visible = false;
            //gvTags.Columns[0].Visible = false;
            ShowPanel();
        }
        if (e.CommandName == "DeleteAttachment")    // if command is for delete
        {
            // get the attachment ID
            string[] strArgs = e.CommandArgument.ToString().Split(':');

            // delete record from DB, delete attachment file as well as the pdf thumbnail
            clsAttachment_Event.DeleteByPK(Convert.ToDecimal(strArgs[0]));
            if (File.Exists(AppConfig.DocumentsPath + "Attach\\" + strArgs[1]))
                File.Delete(AppConfig.DocumentsPath + "Attach\\" + strArgs[1]);
            if (File.Exists(AppConfig.DocumentsPath + "Attach\\" + strArgs[1] + "_Thumb.jpg"))
                File.Delete(AppConfig.DocumentsPath + "Attach\\" + strArgs[1] + "_Thumb.jpg");

            //re-bind the grid
            BindGridFiles();
            ShowPanel();
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

    //protected void btnRemoveAttachment_Click(object sender, EventArgs e)
    //{
    //    // generate comma seperated string of ids of records in Attachment Tables,
    //    // use those id to delete selected records.
    //    string strIDs = "0", strDeletedFiles = string.Empty, strFiles = string.Empty; //will have the comma seperated IDs 

    //    //loop through all the records in grid
    //    for (int i = 0; i < gvFiles.Rows.Count; i++)
    //    {
    //        // if check box is checked for this item. append id to remove.
    //        CheckBox chkSelect = (CheckBox)gvFiles.Rows[i].FindControl("chkFile");
    //        if (chkSelect.Checked)
    //        {
    //            string strFileName = string.Empty, strExtension = string.Empty;

    //            HtmlInputHidden hdnID = (HtmlInputHidden)gvFiles.Rows[i].FindControl("hdnID");
    //            strFileName = ((HtmlInputHidden)gvFiles.Rows[i].FindControl("hdnFileName")).Value;
    //            strExtension = clsGeneral.GetExtension(strFileName);

    //            if (strIDs == "0")
    //                strIDs = hdnID.Value;
    //            else
    //                strIDs = strIDs + "," + hdnID.Value;

    //            // delete the uploaded document
    //            string strDocPath = AppConfig.DocumentsPath + "Attach\\" + strFileName;

    //            if (File.Exists(strDocPath))
    //                File.Delete(strDocPath);
    //        }
    //    }

    //    //// delete record from database
    //    Attachment.DeleteByID(strIDs);
    //    BindGridFiles();

    //    tblFileList.Visible = true;
    //    tblFolderList.Visible = tblAddEditAttachment.Visible = false;
    //    ShowPanel();
    //}

    /// <summary>
    /// Handles event when Cancel button below the file list is clicked 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelFile_Click(object sender, EventArgs e)
    {
        // bind folders grid and show/hide required controls
        BindGridFolders();
        tblFolderList.Visible = true;
        tblFileList.Visible = tblAddEditAttachment.Visible = false;
        ShowPanel();
    }

    /// <summary>
    /// Handles Add tag button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddTag_Click(object sender, EventArgs e)
    //{
    //    // if attachment ID is available
    //    if (PK_Attachment > 0)
    //    {
    //        // insert tag record with the values in page controls
    //        clsAttachment_Tag objTag = new clsAttachment_Tag();
    //        objTag.FK_Attachment = PK_Attachment;
    //        objTag.FK_LU_Tag = Convert.ToDecimal(drpTag.SelectedValue);
    //        objTag.Insert();
    //    }

    //    // bind tags list
    //    //BindGridTags();
    //    SetControlsByAccess();
    //    ShowPanel();
    //}

    /// <summary>
    /// Handles Delete tag button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnDeleteTag_Click(object sender, EventArgs e)
    //{
    //    // get IDs of selected tag records
    //    string strIDs = "";
    //    foreach (GridViewRow gRow in gvTags.Rows)
    //    {
    //        if (((CheckBox)gRow.FindControl("chkTag")).Checked)
    //        {
    //            strIDs += ((HtmlInputHidden)gRow.FindControl("hdnID")).Value + ",";
    //        }
    //    }
    //    strIDs = strIDs.TrimEnd(',');

    //    // delete records from DB
    //    clsAttachment_Tag.DeleteByIDs(strIDs);

    //    // re-bind the grid
    //    //BindGridTags();
    //    ShowPanel();
    //}

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

    #endregion

    #region " Add/Edit Attachment "

    /// <summary>
    /// Handles Add Attachment button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        // if claim PK is available
        if (FK_Table > 0)
        {
            // show error message if file name is not valid
            if (!clsGeneral.IsValidFilename(txtNewFileName.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "alert('Please provide proper file name');", true);
            }
            else
            {
                ////set values to store in database
                clsAttachment_Event objAttachment;

                if (PK_Attachment_Event > 0)
                    objAttachment = new clsAttachment_Event(PK_Attachment_Event);
                else
                    objAttachment = new clsAttachment_Event();

                bool bValid = true;
                string strExtension;

                // check file Extensions for new file name provided by user
                if (txtNewFileName.Text.Trim() != "")
                {
                    if (!clsGeneral.IsNull(fpFile.PostedFile))
                        strExtension = fpFile.PostedFile.FileName.Substring(fpFile.PostedFile.FileName.LastIndexOf("."));
                    else
                        strExtension = objAttachment.Attachment_Name.Substring(objAttachment.Attachment_Name.LastIndexOf(".")); ;

                    // if extensions are not same then set flag
                    if (!txtNewFileName.Text.ToLower().EndsWith(strExtension.ToLower()))
                    {
                        bValid = false;
                    }
                }

                // show error message if extensions are not same
                if (!bValid)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "alert('The extension for the new file name must be same as the old file name.');", true);
                }
                else
                {
                    // set properties from page controls
                    objAttachment.FK_Virtual_Folder = Convert.ToDecimal(drpFolder.SelectedValue);
                    objAttachment.Attachment_Table = Attachment_Table.ToString();
                    objAttachment.FK_Table = FK_Table;
                    objAttachment.FK_Attachment_Type = 0;
                    objAttachment.Updated_By = clsSession.UserID;
                    objAttachment.Update_Date = DateTime.Now;
                    objAttachment.Attach_Date = DateTime.Now;

                    // if PK is available then update the record
                    if (PK_Attachment_Event > 0)
                    {
                        objAttachment.Attachment_Description = (txtNewFileName.Text.Trim() != string.Empty) ? txtNewFileName.Text.Trim() : objAttachment.Attachment_Name.Substring(12);
                        objAttachment.Update();
                    }
                    else
                    {
                        if (!clsGeneral.IsNull(fpFile.PostedFile.FileName))
                        {
                            objAttachment.Attachment_Description = (txtNewFileName.Text.Trim() != string.Empty) ? txtNewFileName.Text.Trim() : fpFile.PostedFile.FileName.Substring(fpFile.PostedFile.FileName.LastIndexOf("\\") + 1);
                            // upload the document
                            string strUploadPath = AppConfig.DocumentsPath + "Attach\\";
                            // upload and set the filename.
                            objAttachment.Attachment_Name = clsGeneral.UploadFile(fpFile, strUploadPath, false, false);
                            objAttachment.Thumbnail_File_Name = GetThumbnailImagePath(AppConfig.DocumentsPath + "Attach\\" + objAttachment.Attachment_Name);
                            objAttachment.Page_Count = null;//GetPDFPageCount(AppConfig.DocumentsPath + "Attach\\" + objAttachment.Attachment_Name);
                            //Insert the attachment record
                            PK_Attachment_Event = objAttachment.Insert();
                        }
                    }

                    // show/hide the required controls
                    if (txtNewFileName.Text == string.Empty)
                        txtNewFileName.Text = objAttachment.Attachment_Description;
                    btnAddAttachment.Text = btnAddAttachment.Text.Replace("Add", "Edit");
                    lblAttachHeader.Text = lblAttachHeader.Text.Replace("Add", "Edit");
                    fpFile.Enabled = rfvFile.Enabled = false;
                    drpFolder.Enabled = true;
                    //drpTag.Enabled = true;
                    //btnAddTag.Enabled = true;
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "alert('Attachment saved successfully');", true);
                }
            }
        }
        else
        {
            // get attachment table name from enum
            string strTableName = "";
            if (Attachment_Table == clsGeneral.Tables.Event) strTableName = "Event";
            else strTableName = "";
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:" + (AttathmentPanelNumber > 0 ? "ShowPanel(" + AttathmentPanelNumber + ");" : "") + "alert('Please first save the " + strTableName + " Information');", true);
        }

    }

    /// <summary>
    /// Handles event when cancel button is clicked for attachment
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelAttachment_Click(object sender, EventArgs e)
    {
        // if hidden value is set to 1 then show file list
        // else show folder list
        if (hdnBackTo.Value == "1")
        {
            BindGridFiles();
            tblFileList.Visible = true;
            tblFolderList.Visible = tblAddEditAttachment.Visible = false;
        }
        else
        {
            BindGridFolders();
            tblFolderList.Visible = true;
            tblFileList.Visible = tblAddEditAttachment.Visible = false;
        }
        ShowPanel();
    }

    #endregion

    #region " PDF Manipulations "

    /// <summary>
    /// Used to get count of pages in a PDF
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    //private int? GetPDFPageCount(string filepath)
    //{
    //    int? page_count = null;
    //    //check for the extension                 
    //    string extension = System.IO.Path.GetExtension(filepath);
    //    if (extension == ".PDF" || extension == ".pdf")
    //    {
    //        try
    //        {
    //            //Create instance for the PDF reader                    
    //            PdfReader pdf_fie = new PdfReader(filepath);
    //            //read it's pagecount                    
    //            page_count = pdf_fie.NumberOfPages;
    //            //close the file                    
    //            pdf_fie.Close();
    //        }
    //        catch (Exception e)
    //        {
    //            page_count = 0;
    //        }
    //    }
    //    return page_count;
    //}

    /// <summary>
    /// Used to generate the thumbnail image of PDF
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    private string GetThumbnailImagePath(string filepath)
    {
        // get extension of a file
        string strFileName = "";
        string extension = System.IO.Path.GetExtension(filepath);

        // if extension is .pdf
        if (extension == ".PDF" || extension == ".pdf")
        {
            // generate thumbnail file name
            strFileName = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            strFileName = strFileName.Replace(".pdf", "").Replace(".PDF", "");
            strFileName = strFileName + "_Thumb.jpg";

            // get the bytes of pdf
            FileStream fs = new FileStream(filepath, FileMode.Open);
            byte[] pdf = new byte[fs.Length];
            fs.Read(pdf, 0, (int)fs.Length);

            // save the thumbnail image
            //PDFParser.Parse parser = new PDFParser.Parse();
            //List<System.Drawing.Image> images = parser.Split(pdf);
            //if (images.Count > 0)
            //{
            //    images[0].Save(AppConfig.DocumentsPath + "Attach\\" + strFileName);
            //    images[0].Dispose();
            //}
            fs.Close();
            fs.Dispose();
        }
        return strFileName;
    }

    #endregion

    #region " Other functions "

    /// <summary>
    /// Used to show the panel on claim page
    /// </summary>
    private void ShowPanel()
    {
        if (AttathmentPanelNumber > 0)
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + AttathmentPanelNumber + ");", true);
    }

    /// <summary>
    /// Used to show/hide the controls as per the access
    /// </summary>
    public void SetControlsByAccess()
    {
        btnAddAttachment.Visible = !ReadOnly;
        btnAddDocument.Visible = !ReadOnly && gvFolders.Rows.Count > 0;
        //btnAddTag.Visible = !ReadOnly;
        //btnDeleteTag.Visible = !ReadOnly && gvTags.Rows.Count > 0;
        //if (gvTags.Rows.Count > 0)
        //    gvTags.Columns[0].Visible = btnDeleteTag.Visible;
    }

    /// <summary>
    /// Used to show attachment details
    /// </summary>
    public void ShowAttachmentDetails()
    {
        // create object for attachment 
        clsAttachment_Event objAttachment = new clsAttachment_Event(PK_Attachment_Event);
        drpFolder.ClearSelection();
        drpFolder.SelectedValue = objAttachment.FK_Virtual_Folder.ToString();
        txtNewFileName.Text = objAttachment.Attachment_Description;

        // show/hide the controls
        fpFile.Enabled = false;
        rfvFile.Enabled = false;
        lblAttachHeaderView.Visible = true;
        lblAttachHeader.Visible = false;
        tblAddEditAttachment.Visible = true;
        //BindGridTags();
        drpFolder.Enabled = txtNewFileName.Enabled = fpFile.Enabled = rfvFile.Enabled = false;// drpTag.Enabled = false;
        tblFolderList.Visible = tblFileList.Visible = false;
        btnAddAttachment.Visible = false;// btnDeleteTag.Visible = btnAddTag.Visible = false;
        //gvTags.Columns[0].Visible = false;
        hdnVirtualFolderID.Value = objAttachment.FK_Virtual_Folder.ToString();
        hdnBackTo.Value = "1";
        ShowPanel();
    }

    /// <summary>
    /// Used to list all attachments for Adjuster note record of a claim
    /// </summary>
    public void ShowAllAttachments()
    {
        //check Attachment table according to the table select the Data and fill the Grid
        DataTable dtAttachment = clsAttachment_Event.SelectForClaim(FK_Table, "", Attachment_Table.ToString(), Convert.ToDecimal(clsSession.UserID)).Tables[0];
        if (_SortBy == "" || _SortOrder == "")
        {
            _SortBy = "Attach_Date";
            _SortOrder = "asc";
        }
        dtAttachment.DefaultView.Sort = _SortBy + " " + _SortOrder;
        gvFiles.DataSource = dtAttachment;
        gvFiles.DataBind();
        btnViewPDF.Visible = (dtAttachment.Rows.Count > 0);
        btnCancelFile.Visible = false;
        gvFiles.Columns[0].Visible = false;
        gvFiles.Columns[gvFiles.Columns.Count - 1].Visible = false;
        btnViewPDF.Visible = false;
        tblFileList.Visible = true;
        tblFolderList.Visible = tblAddEditAttachment.Visible = false;
    }

    #endregion
}