﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_Franchise_Plans_Submitted : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Franchise_Plans_Submitted
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Franchise_Plans_Submitted"]);
        }
        set { ViewState["PK_LU_Franchise_Plans_Submitted"] = value; }
    }

    #endregion

    #region "Page Event"

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

    #region "Event"

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        _PK_LU_Franchise_Plans_Submitted = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtDescription.Text = "";
        rdblActive.SelectedValue = "Y";
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
        LU_Franchise_Plans_Submitted objFranchisePlansSubmitted = new LU_Franchise_Plans_Submitted();
        objFranchisePlansSubmitted.Fld_Desc = txtDescription.Text.Trim();
        objFranchisePlansSubmitted.PK_LU_Franchise_Plans_Submitted = _PK_LU_Franchise_Plans_Submitted;
        objFranchisePlansSubmitted.Active = rdblActive.SelectedValue;

        if (_PK_LU_Franchise_Plans_Submitted > 0)
        {
            _retVal = objFranchisePlansSubmitted.Update();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Lease Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objFranchisePlansSubmitted.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Lease Type that you are trying to add already exists in the Lease Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_Franchise_Plans_Submitted = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region "Grid Event"

    protected void gvFranchisePlansSubmitted_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFranchisePlansSubmitted.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvFranchisePlansSubmitted_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Franchise_Plans_Submitted = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Franchise_Plans_Submitted objStatus = new LU_Franchise_Plans_Submitted(_PK_LU_Franchise_Plans_Submitted);
            txtDescription.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Manufacturer Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Franchise_Plans_Submitted.SelectAll();
        //Apply Dataset to Grid
        gvFranchisePlansSubmitted.DataSource = dsGroup;
        gvFranchisePlansSubmitted.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Franchise_Plans_Submitted = 0;
    }

    #endregion
}
