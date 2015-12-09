using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_LU_Facility_Inspection_Item : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_ID"]);
        }
        set { ViewState["PK_ID"] = value; }
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
        /// Clear Error Message on postback
        lblError.Text = "";
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
        BindDropDowns();
        btnAdd.Text = "Add";
        _PK_ID = 0;
        trStatusAdd.Style.Remove("display");
        lnkCancel.Style.Add("display", "inline");
        txtDescription.Text = "";
        ddlFocusArea.SelectedIndex = -1;
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
        ddlFocusArea.SelectedIndex = -1;
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        LU_Facility_Inspection_Item objLU_Facility_Inspection_Item = new LU_Facility_Inspection_Item();
        decimal _retVal;

        objLU_Facility_Inspection_Item.PK_LU_Facility_Inspection_Item = _PK_ID;
        objLU_Facility_Inspection_Item.Description = txtDescription.Text.Trim();
        objLU_Facility_Inspection_Item.FK_Facility_Inspection_Focus_Area = Convert.ToDecimal(ddlFocusArea.SelectedValue);

        if (_PK_ID > 0)
        {
            _retVal = objLU_Facility_Inspection_Item.Update();
        }
        else
        {
            _retVal = objLU_Facility_Inspection_Item.Insert();
        }


        if (_retVal == -2)
        {
            lblError.Text = "The Description you are trying to enter already exists";
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
        else
        {
            _PK_ID = _retVal;
        }

        //clear Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region "Grid Event"

    /// <summary>
    /// Event for paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInspection_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInspection.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    /// <summary>
    /// Row command event for Edit and update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInspection_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            BindDropDowns();
            _PK_ID = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Remove("display");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Facility_Inspection_Item objLU_Facility_Inspection_Item = new LU_Facility_Inspection_Item(_PK_ID);
            txtDescription.Text = objLU_Facility_Inspection_Item.Description.ToString();            
            clsGeneral.SetDropdownValue(ddlFocusArea, objLU_Facility_Inspection_Item.FK_Facility_Inspection_Focus_Area, true);
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
        //Get Record into Grid
        gvInspection.DataSource = LU_Facility_Inspection_Item.SelectAll();
        gvInspection.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_ID = 0;
        txtDescription.Text = "";        
        ddlFocusArea.SelectedIndex = -1;
    }

    /// <summary>
    /// Bind All DropDowns
    /// </summary>
    private void BindDropDowns()
    {
        ComboHelper.FillInspectionArea(new DropDownList[] { ddlFocusArea }, true);
    }

    #endregion
}