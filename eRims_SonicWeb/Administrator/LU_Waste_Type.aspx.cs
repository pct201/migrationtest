﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_Waste_Type : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Waste_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Waste_Type"]);
        }
        set { ViewState["PK_LU_Waste_Type"] = value; }
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
        _PK_LU_Waste_Type = 0;
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
        LU_Waste_Type objLU_Waste_Type = new LU_Waste_Type();
        objLU_Waste_Type.Fld_Desc = txtDescription.Text.Trim();
        objLU_Waste_Type.PK_LU_Waste_Type = _PK_LU_Waste_Type;
        objLU_Waste_Type.Active = rdblActive.SelectedValue;

        if (_PK_LU_Waste_Type > 0)
        {
            _retVal = objLU_Waste_Type.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Waste_Type.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Waste Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_Waste_Type = _retVal;
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

    protected void gvWasteType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvWasteType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvWasteType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Waste_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Waste_Type objStatus = new LU_Waste_Type(_PK_LU_Waste_Type);
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
    /// Bind CRM Brand Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Waste_Type.SelectAll();
        //Apply Dataset to Grid
        gvWasteType.DataSource = dsGroup;
        gvWasteType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Waste_Type = 0;
    }

    #endregion
}