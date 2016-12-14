using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Administrator_ACI_Link_Lu_location : System.Web.UI.Page
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
            BindDropDownList();
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
        txtGroup_ID.Text = "";
        drpFK_LU_Location.SelectedIndex = 0;
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(drpFK_LU_Location);
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
        txtGroup_ID.Text = "";
        drpFK_LU_Location.SelectedIndex = 0;
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsACI_Link_LU_Location objLU_Location = new clsACI_Link_LU_Location();
        
        decimal _retVal;

        objLU_Location.PK_ACI_Link_LU_Location = _PK_ID;
        if (txtGroup_ID.Text.Trim() != string.Empty)
            objLU_Location.Group_ID = Convert.ToDecimal(txtGroup_ID.Text.Trim());
        if (drpFK_LU_Location.SelectedIndex > 0)
            objLU_Location.FK_LU_Location = Convert.ToDecimal(drpFK_LU_Location.SelectedValue);

        if (_PK_ID > 0)
        {
            _retVal = objLU_Location.Update();
        }
        else
        {
            _retVal = objLU_Location.Insert();
        }
        if (_retVal < 0)
        {
            if (_retVal == -2)
            {
                lblError.Text = "The Group ID you are trying to enter already exists";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtGroup_ID);
            }
            else if (_retVal == -3)
            {
                lblError.Text = "The Location you are trying to enter already exists";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(drpFK_LU_Location);
            }
            return;
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

            clsACI_Link_LU_Location objLocation = new clsACI_Link_LU_Location(_PK_ID);

            txtGroup_ID.Text = Convert.ToString(objLocation.Group_ID);
            clsGeneral.SetDropdownValue(drpFK_LU_Location, objLocation.FK_LU_Location, true);

            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtGroup_ID);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Bind Drop Down Items
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.FillLocationDBA_All(new DropDownList[] { drpFK_LU_Location }, 0, true);
    }

    /// <summary>
    /// Bind Manufacturer Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Grid
        gvEvent_Description.DataSource = clsACI_Link_LU_Location.SelectAll();
        gvEvent_Description.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_ID = 0;
        txtGroup_ID.Text = string.Empty;
        drpFK_LU_Location.SelectedIndex = 0;
    }
    #endregion
}