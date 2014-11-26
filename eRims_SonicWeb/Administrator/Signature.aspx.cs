using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.IO;

public partial class Administrator_Signature : clsBasePage
{
    #region "Enums"
    private enum Signature_Operation
    {
        Add = 1,
        Edit = 2,
        List = 3,
        View = 4
    }
    #endregion

    #region "Properties"
    /// <summary>
    /// Denotes the primary key for the signature
    /// </summary>
    public decimal PK_COI_Signature
    {
        get { return Convert.ToDecimal(ViewState["PK_COI_Signature"]); }
        set { ViewState["PK_COI_Signature"] = value; }
    }
    public string strGetImage
    {
        get { return Convert.ToString(ViewState["strGetImage"]); }
        set { ViewState["strGetImage"] = value; }
    }
    #endregion

    #region "Page Events"
    /// <summary>
    /// Handles the event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // bind the grid
            BindGrid();
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Binds the signature grid to list the records
    /// </summary>
    private void BindGrid()
    {
        // get all signature records
        DataTable dtSign = COI_Signature.SelectAll().Tables[0];

        // sort by description
        dtSign.DefaultView.Sort = "Fld_Desc";
        dtSign = dtSign.DefaultView.ToTable();

        // bind the gridview
        gvSignatures.DataSource = dtSign;
        gvSignatures.DataBind();

        // hide other page controls
        ShowHideControls(Signature_Operation.List);
    }

    /// <summary>
    /// Clear page controls 
    /// </summary>
    private void ClearControls()
    {
        txtDesc.Focus();
        txtDesc.Text = "";
        txtDepartmentTitle.Text = "";
        txtEmail.Text = "";
        txtFacsimile.Text = "";
        txtPhone.Text = "";
        txtClosing.Text = "";
        lnkViewImage_Edit.Style["display"] = "none";
        strGetImage = "";
    }

    /// <summary>
    /// Displays the page controls as per the page operation (Add/Edit/List/View)
    /// </summary>
    /// <param name="objOperation"></param>
    private void ShowHideControls(Signature_Operation objOperation)
    {
        // check the passed operation 
        // and show page controls according to that
        if (objOperation == Signature_Operation.Add || objOperation == Signature_Operation.Edit)
        {
            tdGrid.Style["display"] = "none";
            tdEdit.Style["display"] = "block";
            tdView.Style["display"] = "none";
        }
        else if (objOperation == Signature_Operation.List)
        {
            tdGrid.Style["display"] = "block";
            tdEdit.Style["display"] = "none";
            tdView.Style["display"] = "none";
        }
        else if (objOperation == Signature_Operation.View)
        {
            tdGrid.Style["display"] = "none";
            tdEdit.Style["display"] = "none";
            tdView.Style["display"] = "block";
        }
    }
    
   
    /// <summary>
    /// Binds data in page controls in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // create object for signature record
        COI_Signature objSignature = new COI_Signature(PK_COI_Signature);

        // set values in page controls
        txtDesc.Focus();
        txtDesc.Text = objSignature.Fld_Desc;
        txtClosing.Text = objSignature.Closing;
        txtPhone.Text = objSignature.Phone;
        txtFacsimile.Text = objSignature.Facsimile;
        txtEmail.Text = objSignature.EMail;
        txtDepartmentTitle.Text = objSignature.Title_Department;
        strGetImage = objSignature.ImageName;
        // hide view image link
        if( objSignature.ImageName !="")
            lnkViewImage_Edit.Style["display"] = "block";
        else
            lnkViewImage_Edit.Style["display"] = "none";       
        ShowHideControls(Signature_Operation.Edit);
    }

    /// <summary>
    /// Binds the data in page controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        // create the object for signature record
        COI_Signature objSignature = new COI_Signature(PK_COI_Signature);

        // set values in page controls
        lblDesc.Text = objSignature.Fld_Desc;
        lblClosing.Text = objSignature.Closing;
        lblPhone.Text = objSignature.Phone;
        lblFacsimile.Text = objSignature.Facsimile;
        lblEmail.Text = objSignature.EMail;
        lblDepartmentTitle.Text = objSignature.Title_Department;
        if (objSignature.ImageName != "")
            lnkViewImage_View.Style["display"] = "block";
        else
            lnkViewImage_View.Style["display"] = "none";
      
        ShowHideControls(Signature_Operation.View);

    }

    #endregion

    #region "Control Events"

    /// <summary>
    /// Handles add new button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        // set PK to zero
        PK_COI_Signature = 0;
        // clear page controls
        ClearControls();        
        // display controls for adding the data
        ShowHideControls(Signature_Operation.Add);
    }

    /// <summary>
    /// Handles Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // clear the page controls
        ClearControls();

        // display grid and hide other controls
        ShowHideControls(Signature_Operation.List);
    }

    /// <summary>
    /// Handles Back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // display grid 
        ShowHideControls(Signature_Operation.List);
    }

    /// <summary>
    /// Handles Save button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // create object for the signature record
        COI_Signature objSignature = new COI_Signature(PK_COI_Signature);

        // get values from page controls
        objSignature.PK_COI_Signature = PK_COI_Signature;
        objSignature.Fld_Desc = txtDesc.Text.Trim();
        objSignature.Closing = txtClosing.Text.Trim();
        objSignature.Phone = txtPhone.Text.Trim();
        objSignature.Facsimile = txtFacsimile.Text.Trim();
        objSignature.EMail = txtEmail.Text.Trim();
        objSignature.Title_Department = txtDepartmentTitle.Text.Trim();

        // if file is uploaded then get the byte array of the selected file    
        if (!string.IsNullOrEmpty(fpImage.PostedFile.FileName))
        {
            objSignature.ImageName = fpImage.PostedFile.FileName.Substring(fpImage.PostedFile.FileName.LastIndexOf("\\") + 1);          
        }
        else
        {
            objSignature.ImageName = strGetImage;
        }

        // if primary key is available then update the record else insert the record
        decimal _retVal;
        if (PK_COI_Signature > 0)
        {

            _retVal = objSignature.Update();
            if (_retVal == -2)
            {
                lblError.Text = "The Signature Text that you are trying to Update already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDesc);
                return;
            }
            //Find Folder Path in Server   
            if (!string.IsNullOrEmpty(fpImage.PostedFile.FileName))
            {
                string strFolderPath = Server.MapPath(Request.ApplicationPath) + "\\Documents\\Signatures\\" + PK_COI_Signature + "\\";
                string strFileNameDelete = strFolderPath + strGetImage;
                try
                {
                    if (File.Exists(strFileNameDelete))
                        File.Delete(strFileNameDelete);
                }
                catch
                {
                }
                if (!string.IsNullOrEmpty(fpImage.PostedFile.FileName))
                {
                    string strFileName = clsGeneral.UploadFile(fpImage, AppConfig.SitePath + "Documents/Signatures/" + PK_COI_Signature + "", false, true);
                }
            }
        }
        else
        {
            _retVal = objSignature.Insert();

            if (_retVal == -2)
            {
                lblError.Text = "The Signature that you are trying to Add already exists in the Signature table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDesc);
                return;
            }
            if (!string.IsNullOrEmpty(fpImage.PostedFile.FileName))
            {

                string strFileName = clsGeneral.UploadFile(fpImage, AppConfig.SitePath + "Documents/Signatures/" + _retVal + "", false, true);
            }

        }

        // bind the grid to show inserted or updated record
        BindGrid();
    }
    #endregion

    #region "GridView Events"

    /// <summary>
    /// Handles event when page is selected in grdview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSignatures_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // set the new page index and bind the grid
        gvSignatures.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    /// <summary>
    /// Handles event when command is given in gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSignatures_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditSignature") // if the commandname is for editing the signature
        {
            // set PK and bind details for editing the record
            PK_COI_Signature = Convert.ToDecimal(e.CommandArgument);
            BindDetailsForEdit();
        }
        else if (e.CommandName == "ViewSignature") // if the commandname is for viewing the signature
        {
            // set PK and bind details for viewing the record
            PK_COI_Signature = Convert.ToDecimal(e.CommandArgument);
            BindDetailsForView();
        }
        else if (e.CommandName == "DeleteSignature") // if the commandname is for deleting the signature
        {
            // delete the record for passed PK in command argument and bind the grid
          
            PK_COI_Signature =  Convert.ToDecimal(e.CommandArgument);
           
            COI_Signature objSignature = new COI_Signature(PK_COI_Signature);
            string strImagename = objSignature.ImageName;
            string strFolderPath = AppConfig.SitePath + "Documents\\Signatures\\" + PK_COI_Signature + "\\";
            string strFileNameDelete = strFolderPath + strImagename;
            try
            {
                if (File.Exists(strFileNameDelete))
                    File.Delete(strFileNameDelete);
            }
            catch
            {
            }

            COI_Signature.Delete(PK_COI_Signature);
            BindGrid();
        }
    }

    #endregion
}