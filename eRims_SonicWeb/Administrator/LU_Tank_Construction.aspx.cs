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

public partial class Administrator_LU_Tank_Construction : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Tank_Construction
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Tank_Construction"]);
        }
        set { ViewState["PK_LU_Tank_Construction"] = value; }
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
        _PK_LU_Tank_Construction = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtTankConstruction.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtTankConstruction);
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
        txtTankConstruction.Text = "";
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
        LU_Tank_Construction objTankConstruction = new LU_Tank_Construction();
        objTankConstruction.Fld_Desc = txtTankConstruction.Text.Trim();
        objTankConstruction.PK_LU_Tank_Construction = _PK_LU_Tank_Construction;
        objTankConstruction.Active = rdblActive.SelectedValue;

        if (_PK_LU_Tank_Construction > 0)
        {
            _retVal = objTankConstruction.Update();
            // Used to Check Duplicate Tank Construction ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Tank Construction that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtTankConstruction);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objTankConstruction.Insert();
            // Used to Check Duplicate Tank Construction ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Tank Construction that you are trying to add already exists in the Tank Construction table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtTankConstruction);
                return;
            }
            _PK_LU_Tank_Construction = _retVal;
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

    protected void gvTankConstruction_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTankConstruction.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvTankConstruction_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Tank_Construction = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Tank_Construction objStatus = new LU_Tank_Construction(_PK_LU_Tank_Construction);
            txtTankConstruction.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtTankConstruction);
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
        DataSet dsGroup = LU_Tank_Construction.SelectAll();
        //Apply Dataset to Grid
        gvTankConstruction.DataSource = dsGroup;
        gvTankConstruction.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Tank_Construction = 0;
    }
    #endregion
}
