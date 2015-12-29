﻿using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_LU_Roof_Repairs : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Roof_Repairs
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Roof_Repairs"]);
        }
        set { ViewState["PK_LU_Roof_Repairs"] = value; }
    }

    #endregion

    #region "Page Event"

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

    #region "Event"

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        _PK_LU_Roof_Repairs = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
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
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        LU_Roof_Repairs objLU_Roof_Repairs = new LU_Roof_Repairs();
        objLU_Roof_Repairs.Description = txtDescription.Text.Trim();
        objLU_Roof_Repairs.PK_LU_Roof_Repairs = _PK_LU_Roof_Repairs;


        if (_PK_LU_Roof_Repairs > 0)
        {
            _retVal = objLU_Roof_Repairs.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Roof Repairs table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Roof_Repairs.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Roof Repairs table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_Roof_Repairs = _retVal;
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
    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRepairs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRepairs.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRepairs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Roof_Repairs = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Roof_Repairs objLU_Roof_Repairs = new LU_Roof_Repairs(_PK_LU_Roof_Repairs);
            txtDescription.Text = objLU_Roof_Repairs.Description.ToString();
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Facility Inspection Focus Area Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Roof_Repairs.SelectAll();
        //Apply Dataset to Grid
        gvRepairs.DataSource = dsGroup;
        gvRepairs.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Roof_Repairs = 0;
    }

    #endregion
}