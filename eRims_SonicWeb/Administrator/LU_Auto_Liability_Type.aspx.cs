using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_Auto_Liability_Type : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Auto_Liability_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Auto_Liability_Type"]);
        }
        set { ViewState["PK_LU_Auto_Liability_Type"] = value; }
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
        _PK_LU_Auto_Liability_Type = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtLU_Auto_Liability_Type.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtLU_Auto_Liability_Type);
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
        txtLU_Auto_Liability_Type.Text = "";
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
        clsLU_Auto_Liability_Type objAuto_Liability_Type = new clsLU_Auto_Liability_Type();
        objAuto_Liability_Type.Fld_Desc = txtLU_Auto_Liability_Type.Text.Trim();
        objAuto_Liability_Type.PK_LU_Auto_Liability_Type = _PK_LU_Auto_Liability_Type;
        objAuto_Liability_Type.Active = rdblActive.SelectedValue;

        if (_PK_LU_Auto_Liability_Type > 0)
        {
            _retVal = objAuto_Liability_Type.Update();
            // Used to Check Duplicate Auto Liability -Type ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Auto Liability - Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtLU_Auto_Liability_Type);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objAuto_Liability_Type.Insert();
            // Used to Check Duplicate Auto Liability - Type ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Auto Liability - Type that you are trying to add already exists in the Auto Liability - Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtLU_Auto_Liability_Type);
                return;
            }
            _PK_LU_Auto_Liability_Type = _retVal;
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

    protected void gvAuto_Liability_Type_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAuto_Liability_Type.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    protected void gvAuto_Liability_Type_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Auto_Liability_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            clsLU_Auto_Liability_Type objStatus = new clsLU_Auto_Liability_Type(_PK_LU_Auto_Liability_Type);
            txtLU_Auto_Liability_Type.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtLU_Auto_Liability_Type);
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
        DataSet dsGroup = clsLU_Auto_Liability_Type.SelectAll();
        //Apply Dataset to Grid
        gvAuto_Liability_Type.DataSource = dsGroup;
        gvAuto_Liability_Type.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Auto_Liability_Type = 0;
    }
    #endregion
}