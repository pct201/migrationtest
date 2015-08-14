using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Administrator_LU_Incident_Type : clsBasePage
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
        txtCode.Text = txtEvent_Outcome.Text = string.Empty;
        ddlEventLevel.SelectedIndex = -1;
        rdblActive.SelectedValue = "Y";
        rdblIs_Actionable.SelectedValue = "Y";
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
        txtCode.Text = txtEvent_Outcome.Text = string.Empty;
        ddlEventLevel.SelectedIndex = -1;
        rdblActive.SelectedValue = "Y";
        rdblIs_Actionable.SelectedValue = "Y";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsLU_Event_Type objEventType = new clsLU_Event_Type();
        decimal _retVal;

        objEventType.PK_LU_Event_Type = _PK_ID;
        objEventType.Fld_Desc = txtDescription.Text.Trim();
        objEventType.Fld_Code = txtCode.Text.Trim();

        if (!string.IsNullOrEmpty(ddlEventLevel.SelectedValue))
        {
            objEventType.FK_LU_Event_Level = Convert.ToDecimal(ddlEventLevel.SelectedValue);
        }

        objEventType.Active = rdblActive.SelectedValue;
        objEventType.Is_Actionable = rdblIs_Actionable.SelectedValue;
        if (!string.IsNullOrEmpty(txtEvent_Outcome.Text))
            objEventType.Event_Outcome = Convert.ToInt32(txtEvent_Outcome.Text.Trim());

        if (_PK_ID > 0)
        {
            _retVal = objEventType.Update();
        }
        else
        {
            _retVal = objEventType.Insert();
        }
        if (_retVal < 0)
        {
            if (_retVal == -2)
            {
                lblError.Text = "The Description you are trying to enter already exists";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
            }
            else if (_retVal == -3)
            {
                lblError.Text = "The Code you are trying to enter already exists";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCode);
            }
            return;
        }
        else
        {
            _PK_ID = _retVal;
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
    /// Event for paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvIncidentType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvIncidentType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    /// <summary>
    /// Row command event for Edit and update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvIncidentType_RowCommand(object sender, GridViewCommandEventArgs e)
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
            clsLU_Event_Type objStatus = new clsLU_Event_Type(_PK_ID);
            txtDescription.Text = objStatus.Fld_Desc.ToString();
            txtCode.Text = objStatus.Fld_Code.ToString();
            clsGeneral.SetDropdownValue(ddlEventLevel, objStatus.FK_LU_Event_Level, true);
            txtEvent_Outcome.Text = Convert.ToString(objStatus.Event_Outcome);
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;

            if (objStatus.Is_Actionable != null)
                rdblIs_Actionable.SelectedValue = objStatus.Is_Actionable;
            else
                rdblIs_Actionable.SelectedIndex = 0;

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
        gvIncidentType.DataSource = clsLU_Event_Type.SelectAllEventTypes();
        gvIncidentType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_ID = 0;
        txtDescription.Text = "";
        txtCode.Text = txtEvent_Outcome.Text = string.Empty;
        rdblActive.SelectedIndex = 0;
        rdblIs_Actionable.SelectedIndex = 0;
        ddlEventLevel.SelectedIndex = -1;
    }

    /// <summary>
    /// Bind All DropDowns
    /// </summary>
    private void BindDropDowns()
    {
        ComboHelper.FillEventLevel(new DropDownList[] { ddlEventLevel }, true);
    }
    #endregion
}