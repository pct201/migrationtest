using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_LU_Event_Description : System.Web.UI.Page
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
        btnAdd.Text = "Add";
        _PK_ID = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtDescription.Text = "";
        txtCode.Text = "";
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
        txtCode.Text = "";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsLU_Event_Description objEvent_Desc = new clsLU_Event_Description();
        decimal _retVal;

        objEvent_Desc.PK_LU_Event_Description = _PK_ID;
        objEvent_Desc.Fld_Desc = txtDescription.Text.Trim();
        objEvent_Desc.Fld_code = txtCode.Text.Trim();

        if (_PK_ID > 0)
        {
            _retVal = objEvent_Desc.Update();
        }
        else
        {
            _retVal = objEvent_Desc.Insert();
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
    protected void gvEvent_Description_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEvent_Description.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    /// <summary>
    /// Row command event for Edit and update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_Description_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_ID = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            clsLU_Event_Description objStatus = new clsLU_Event_Description(_PK_ID);

            txtDescription.Text = objStatus.Fld_Desc.ToString();
            txtCode.Text = objStatus.Fld_code.ToString();

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
        gvEvent_Description.DataSource = clsLU_Event_Description.SelectAll();
        gvEvent_Description.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_ID = 0;
        txtDescription.Text = "";
        txtCode.Text = "";
    }
    #endregion
}