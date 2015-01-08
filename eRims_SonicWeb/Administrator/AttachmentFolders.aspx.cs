using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_AttachmentFolders : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }
    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal? PK_Attachment_Folder
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Attachment_Folder"]);
        }
        set { ViewState["PK_Attachment_Folder"] = value; }
    }
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SortOrder = "asc";
            SortBy = "Folder_Name";
            BindGrid(1, 25);
        }
    }
    #endregion

    #region Control Events
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        PK_Attachment_Folder = 0;
        txtFolderName.Text = "";
        foreach (ListItem lst in chkMajorCoverage.Items)
        {
            lst.Selected = false;
        }
        pnlGrid.Visible = false;
        pnlAddEdit.Visible = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (clsAttachment_Folder.SelectByFolder_Name(txtFolderName.Text, Convert.ToDecimal(PK_Attachment_Folder)) <= 0)
        {
            int Flag = 0;
            if (PK_Attachment_Folder > 0)
            {
                for (int i = 0; i < chkMajorCoverage.Items.Count; i++)
                {
                    clsVirtual_Folder objVirtual_Folder = new clsVirtual_Folder();
                    objVirtual_Folder.FK_Attachment_Folder = PK_Attachment_Folder;
                    objVirtual_Folder.Major_Coverage = chkMajorCoverage.Items[i].Value;
                    if (objVirtual_Folder.IsValid() == 1)
                    {
                        if (chkMajorCoverage.Items[i].Selected == false)
                        {
                            Flag = 1;
                            break;
                        }
                    }
                }
            }
            if (Flag == 1)//if entry exist with selected (Major_Coverage and Attachment_Folder) in Virtual_Folder and if yes check if it exist in Attachments
            {
                lblError.Text = "There exist attachments for the virtual folder, please remove the attachments first";
            }
            else
            {
                SaveData();
                pnlGrid.Visible = true;
                pnlAddEdit.Visible = false;
                BindGrid(ctrlPageSecurity.CurrentPage, ctrlPageSecurity.PageSize);
            }
        }
        else
        {
            lblError.Text = "Folder Name already exists";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlGrid.Visible = true;
        pnlAddEdit.Visible = false;
    }

    protected void gvFolders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditDetails")
        {
            clsAttachment_Folder objAttachment_Folder = new clsAttachment_Folder(Convert.ToDecimal(e.CommandArgument));
            txtFolderName.Text = objAttachment_Folder.Folder_Name;
            PK_Attachment_Folder = Convert.ToDecimal(e.CommandArgument);
            clsVirtual_Folder objVirtual_Folder = new clsVirtual_Folder();
            DataSet dsVirtual_Folder = objVirtual_Folder.SelectByFK(Convert.ToDecimal(e.CommandArgument));
            chkMajorCoverage.ClearSelection();
            foreach (DataRow dr in dsVirtual_Folder.Tables[0].Rows)
            {
                for (int i = 0; i < chkMajorCoverage.Items.Count; i++)
                {
                    if (chkMajorCoverage.Items[i].Value == dr["Major_Coverage"].ToString())
                    {
                        chkMajorCoverage.Items[i].Selected = true;
                        break;
                    }
                }
            }
            pnlGrid.Visible = false;
            pnlAddEdit.Visible = true;
        }
        else if (e.CommandName == "DeleteDetails")
        {
            int Flag = 0;
            if (Convert.ToDecimal(e.CommandArgument) > 0)
            {
                clsVirtual_Folder objVirtual_Folder = new clsVirtual_Folder();
                clsVirtual_Folder objValues = new clsVirtual_Folder(Convert.ToDecimal(e.CommandArgument));
                objVirtual_Folder.FK_Attachment_Folder = objValues.FK_Attachment_Folder;
                objVirtual_Folder.Major_Coverage =  objValues.Major_Coverage;
                Flag = objVirtual_Folder.IsValid();
            }
            if (Flag == 1)//if entry exist with selected (Major_Coverage and Attachment_Folder) in Virtual_Folder and if yes check if it exist in Attachments
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "alert('There exist attachments for the virtual folder, please remove the attachments first.');", true);
            }
            else
            {
                //clsAttachment_Folder.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                clsVirtual_Folder.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGrid(ctrlPageSecurity.CurrentPage, ctrlPageSecurity.PageSize);
            }
        }
    }
    #endregion

    #region "Sorting"

    protected void gvFolders_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageSecurity.CurrentPage, ctrlPageSecurity.PageSize);
    }
    protected void gvFolders_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy)
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
                e.Row.Cells[0].Controls.Add(sortImage);
            }
        }
    }
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 intCol = GetSortColumnIndex(SortBy);
        if (intCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

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
        headerRow.Cells[intCol].Controls.Add(sortImage);
    }
    private int GetSortColumnIndex(object strSortExp)
    {
        int intRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvFolders.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {
                intRet = gvFolders.Columns.IndexOf(field);
            }
        }
        return intRet;
    }
    #endregion

    #region Methods
    private void SaveData()
    {
        decimal decPK_Virtual_Folder = 0;
        clsAttachment_Folder objAttachment_Folder = new clsAttachment_Folder();
        objAttachment_Folder.Folder_Name = txtFolderName.Text;
        objAttachment_Folder.PK_Attachment_Folder = PK_Attachment_Folder;
        if (PK_Attachment_Folder <= 0)
        {
            PK_Attachment_Folder = objAttachment_Folder.Insert();
        }
        else
        {
            objAttachment_Folder.Update();
            /*clsVirtual_Folder.DeleteByFK(Convert.ToDecimal(PK_Attachment_Folder));*/
        }
        for (int i = 0; i < chkMajorCoverage.Items.Count; i++)
        {
            if (chkMajorCoverage.Items[i].Selected == true)
            {
                clsVirtual_Folder objVirtual_Folder = new clsVirtual_Folder();
                objVirtual_Folder.FK_Attachment_Folder = PK_Attachment_Folder;
                objVirtual_Folder.Major_Coverage = chkMajorCoverage.Items[i].Value;
                if (objVirtual_Folder.isExist() == 0)
                {
                    #region "Insert values in Virtual Folder"
                    decPK_Virtual_Folder = objVirtual_Folder.Insert();
                    #endregion                    
                }
                else
                {
                    #region "get decPK_Virtual_Folder"
                    DataSet dsVirtualFolder = objVirtual_Folder.SelectByObj();                    
                    foreach (DataRow dr in dsVirtualFolder.Tables[0].Rows)
                    {
                        decPK_Virtual_Folder = Convert.ToDecimal(dr["PK_Virtual_Folder"]);
                    }
                    #endregion
                }
                #region "Insert/Update values in Attachment Rights"
                /*clsAttachment_Rights.DeleteByFK(PK_Virtual_Folder);*/

                clsAttachment_Rights objAttachment_Rights = new clsAttachment_Rights();
                objAttachment_Rights.FK_Module = Convert.ToDecimal(chkMajorCoverage.Items[i].Value);
                objAttachment_Rights.FK_Virtual_Folder = decPK_Virtual_Folder;
                objAttachment_Rights.Right_Name = chkMajorCoverage.Items[i].Text + " - " + txtFolderName.Text + " - View";
                objAttachment_Rights.RightType_ID = 5;
                objAttachment_Rights.InsertUpdate();

                objAttachment_Rights = new clsAttachment_Rights();
                objAttachment_Rights.FK_Module = Convert.ToDecimal(chkMajorCoverage.Items[i].Value);
                objAttachment_Rights.FK_Virtual_Folder = decPK_Virtual_Folder;
                objAttachment_Rights.Right_Name = chkMajorCoverage.Items[i].Text + " - " + txtFolderName.Text + " - Edit";
                objAttachment_Rights.RightType_ID = 4;
                objAttachment_Rights.InsertUpdate();

                objAttachment_Rights = new clsAttachment_Rights();
                objAttachment_Rights.FK_Module = Convert.ToDecimal(chkMajorCoverage.Items[i].Value);
                objAttachment_Rights.FK_Virtual_Folder = decPK_Virtual_Folder;
                objAttachment_Rights.Right_Name = chkMajorCoverage.Items[i].Text + " - " + txtFolderName.Text + " - Add";
                objAttachment_Rights.RightType_ID = 3;
                objAttachment_Rights.InsertUpdate();

                objAttachment_Rights = new clsAttachment_Rights();
                objAttachment_Rights.FK_Module = Convert.ToDecimal(chkMajorCoverage.Items[i].Value);
                objAttachment_Rights.FK_Virtual_Folder = decPK_Virtual_Folder;
                objAttachment_Rights.Right_Name = chkMajorCoverage.Items[i].Text + " - " + txtFolderName.Text + " - Delete";
                objAttachment_Rights.RightType_ID = 2;
                objAttachment_Rights.InsertUpdate();
                #endregion
            }
        }
        for (int i = 0; i < chkMajorCoverage.Items.Count; i++)
        {
            if (chkMajorCoverage.Items[i].Selected == false)
            {
                clsVirtual_Folder objVirtual_Folder = new clsVirtual_Folder();
                objVirtual_Folder.FK_Attachment_Folder = PK_Attachment_Folder;
                objVirtual_Folder.Major_Coverage = chkMajorCoverage.Items[i].Value;
                if (objVirtual_Folder.isExist() == 1)
                {
                    #region "delete records"
                    DataSet dsVirtualFolder = objVirtual_Folder.SelectByObj();
                    foreach (DataRow dr in dsVirtualFolder.Tables[0].Rows)
                    {
                        decPK_Virtual_Folder = Convert.ToDecimal(dr["PK_Virtual_Folder"]);
                        //clsAttachment_Rights.DeleteByFK(decPK_Virtual_Folder);
                        clsVirtual_Folder.DeleteByPK(decPK_Virtual_Folder);
                    }
                    #endregion
                }
                else
                {
                    #region "do nothing"
                    #endregion
                }
            }
        }
    }

    private void BindGrid(int PageNumber, int PageSize)
    {
        // selects records depending on paging criteria.
        DataSet dsAttachment_Folder = clsAttachment_Folder.SelectAll(PageNumber, SortBy, SortOrder, PageSize);
        DataTable dtAttachment_Folder = dsAttachment_Folder.Tables[0];

        // set values for paging control
        ctrlPageSecurity.TotalRecords = (dsAttachment_Folder.Tables.Count > 1) ? Convert.ToInt32(dsAttachment_Folder.Tables[1].Rows[0][0]) : 0;
        ctrlPageSecurity.CurrentPage = (dsAttachment_Folder.Tables.Count > 2) ? Convert.ToInt32(dsAttachment_Folder.Tables[2].Rows[0][2]) : 0;
        ctrlPageSecurity.RecordsToBeDisplayed = dtAttachment_Folder.Rows.Count;

        // bind the grid.
        gvFolders.DataSource = dsAttachment_Folder;
        gvFolders.DataBind();
        ctrlPageSecurity.SetPageNumbers();
        // set record numbers retrieved
        lblNumber.Text = ctrlPageSecurity.TotalRecords.ToString();
    }
    protected void GetPage()
    {
        BindGrid(ctrlPageSecurity.CurrentPage, ctrlPageSecurity.PageSize);
    }
    #endregion
}