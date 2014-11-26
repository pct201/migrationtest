using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Administrator_LU_Units : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Units
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Units"]);
        }
        set { ViewState["PK_LU_Units"] = value; }
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
        _PK_LU_Units = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtUnits.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtUnits);
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
        txtUnits.Text = "";
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
        LU_Units objUnits = new LU_Units();
        objUnits.Fld_Desc = txtUnits.Text.Trim();
        objUnits.PK_LU_Units = _PK_LU_Units;
        objUnits.Active = rdblActive.SelectedValue;

        if (_PK_LU_Units > 0)
        {
            _retVal = objUnits.Update();
            // Used to Check Duplicate Unit ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Unit that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtUnits);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objUnits.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Unit that you are trying to add already exists in the Unit table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtUnits);
                return;
            }
            _PK_LU_Units = _retVal;
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

    protected void gvUnits_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUnits.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvUnits_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Units = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Units objStatus = new LU_Units(_PK_LU_Units);
            txtUnits.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtUnits);
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
        DataSet dsGroup = LU_Units.SelectAll();
        //Apply Dataset to Grid
        gvUnits.DataSource = dsGroup;
        gvUnits.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Units = 0;
    }
    #endregion
}
