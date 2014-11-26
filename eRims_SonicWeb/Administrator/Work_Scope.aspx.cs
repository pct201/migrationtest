using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;

/************************************************************************************************************************************
 * 
 * Developer Name : Ravi Patel
 * 
 * File Name      :	Work_Scope.aspx
 *
 * Description    :	This page provide facility to Add-Edit Work Scop Look-up Table.
 *
 *************************************************************************************************************************************/
public partial class Administrator_Work_Scope : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Work_Scope
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Work_Scope"]);
        }
        set { ViewState["PK_LU_Work_Scope"] = value; }
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

    #region "Grid Event"

    /// <summary>
    /// Manufacturer row command event in edit,view or remove mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWork_Scope_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Work_Scope = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trWork_ScopeAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Work_Scope objHeld = new LU_Work_Scope(PK_LU_Work_Scope);
            txtWork_Scope.Text = objHeld.Fld_Desc.ToString();

            // check Active flag for record
            if (objHeld.Active != null)
                rdblActive.SelectedValue = objHeld.Active;
            else
                rdblActive.SelectedIndex = 0;

            // set focus to first data field of screen
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtWork_Scope);
        }
    }

    /// <summary>
    /// Page index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWork_Scope_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvWork_Scope.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid(); //Bind Grid Function
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
        // set controls in add mode
        btnAdd.Text = "Add";
        PK_LU_Work_Scope = 0;        
        trWork_ScopeAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        // clear control
        txtWork_Scope.Text = "";
        rdblActive.SelectedValue = "Y";
        // set focus to first data field of screen
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtWork_Scope);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        // hide controls
        trWork_ScopeAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        // clear control
        txtWork_Scope.Text = "";
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
        LU_Work_Scope objWork_Scope = new LU_Work_Scope();
        objWork_Scope.Fld_Desc = txtWork_Scope.Text.Trim();
        objWork_Scope.PK_LU_Work_Scope = PK_LU_Work_Scope;
        objWork_Scope.Active = rdblActive.SelectedValue;

        // check if record is editing or in add mode.
        if (PK_LU_Work_Scope > 0)
        {
            // update records
            _retVal = objWork_Scope.Update();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Scope of Work that you are trying to add already exists in the Scope of Work table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtWork_Scope);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            // Insert records
            _retVal = objWork_Scope.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Scope of Work that you are trying to add already exists in the Scope of Work table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtWork_Scope);
                return;
            }
            PK_LU_Work_Scope = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Manufacturer Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Work_Scope.SelectAll();
        //Apply Dataset to Grid
        gvWork_Scope.DataSource = dsGroup;
        gvWork_Scope.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Work_Scope = 0;
    }
    #endregion
}
