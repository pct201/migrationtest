using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_EPM_ExistingDocuments : clsBasePage
{
    #region " Properties "

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_EPM_ExistingDocuments
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_EPM_ExistingDocuments"]);
        }
        set { ViewState["PK_LU_EPM_ExistingDocuments"] = value; }
    }

    #endregion

    #region " Page Event "
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
        }
    }

    #endregion

    #region " Event "

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        _PK_LU_EPM_ExistingDocuments = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        rdblActive.SelectedValue = "Y";
        txtDescription.Text = "";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trStatusAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtDescription.Text = "";
        rdblActive.SelectedValue = "Y";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        clsLU_EPM_ExistingDocuments objLU_EPM_ExistingDocuments = new clsLU_EPM_ExistingDocuments();
        objLU_EPM_ExistingDocuments.Fld_Desc = txtDescription.Text.Trim();
        objLU_EPM_ExistingDocuments.PK_LU_EPM_ExistingDocuments = _PK_LU_EPM_ExistingDocuments;
        objLU_EPM_ExistingDocuments.Active = rdblActive.SelectedValue;

        if (_PK_LU_EPM_ExistingDocuments > 0)
        {
            _retVal = objLU_EPM_ExistingDocuments.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to Update already exists in the Existing Documents table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_EPM_ExistingDocuments.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Existing Documents table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_EPM_ExistingDocuments = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region " Grid Event "
    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExisting_Documents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvExisting_Documents.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExisting_Documents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_EPM_ExistingDocuments = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            clsLU_EPM_ExistingDocuments objLU_EPM_PurposeOfProject = new clsLU_EPM_ExistingDocuments(_PK_LU_EPM_ExistingDocuments);
            txtDescription.Text = objLU_EPM_PurposeOfProject.Fld_Desc.ToString();
            if (objLU_EPM_PurposeOfProject.Active != null)
                rdblActive.SelectedValue = objLU_EPM_PurposeOfProject.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
    }

    #endregion

    #region " Methods "
    /// <summary>
    /// Bind CRM Department Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsLU_EPM_ExistingDocuments = clsLU_EPM_ExistingDocuments.SelectAll();
        //Apply Dataset to Grid
        gvExisting_Documents.DataSource = dsLU_EPM_ExistingDocuments;
        gvExisting_Documents.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_EPM_ExistingDocuments = 0;
    }

    #endregion
}