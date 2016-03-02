using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_LU_Responsible_Party : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Responsible_Party
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Responsible_Party"]);
        }
        set { ViewState["PK_LU_Responsible_Party"] = value; }
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
        _PK_LU_Responsible_Party = 0;
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
        LU_Responsible_Party objLU_Responsible_Party = new LU_Responsible_Party();
        objLU_Responsible_Party.Description = txtDescription.Text.Trim();
        objLU_Responsible_Party.PK_LU_Responsible_Party = _PK_LU_Responsible_Party;
        objLU_Responsible_Party.Active = rdblActive.SelectedValue;

        if (_PK_LU_Responsible_Party > 0)
        {
            _retVal = objLU_Responsible_Party.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Responsible Party table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Responsible_Party.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Responsible Party table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_Responsible_Party = _retVal;
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
    protected void gvResponsibleParty_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvResponsibleParty.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvResponsibleParty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Responsible_Party = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";

            // get record from database
            LU_Responsible_Party objLU_Responsible_Party = new LU_Responsible_Party(_PK_LU_Responsible_Party);
            txtDescription.Text = objLU_Responsible_Party.Description.ToString();
            if (objLU_Responsible_Party.Active != null)
                rdblActive.SelectedValue = objLU_Responsible_Party.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Responsible Party Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsLU_Responsible_Party = LU_Responsible_Party.SelectAll();
        //Apply Dataset to Grid
        gvResponsibleParty.DataSource = dsLU_Responsible_Party;
        gvResponsibleParty.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Responsible_Party = 0;
    }

    #endregion
}