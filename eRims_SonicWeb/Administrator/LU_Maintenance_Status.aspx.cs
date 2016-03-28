using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_LU_Maintenance_Status : System.Web.UI.Page
{
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Maintenance_Status
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Maintenance_Status"]);
        }
        set { ViewState["PK_LU_Maintenance_Status"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
        }
    }

    #region Methods
    /// <summary>
    /// Bind CRM Department Grid
    /// </summary>
    private void BindGrid()
    {
        DataSet dsLU_Maintenance_Status = LU_Maintenance_Status.SelectAll();
        gvMaintenanceStatus.DataSource = dsLU_Maintenance_Status;
        gvMaintenanceStatus.DataBind();
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Maintenance_Status = 0;
    }

    #endregion

    #region "Grid Event"
    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMaintenanceStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMaintenanceStatus.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMaintenanceStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Maintenance_Status = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";

            LU_Maintenance_Status objLU_Maintenance_Status = new LU_Maintenance_Status(PK_LU_Maintenance_Status);
            txtDescription.Text = objLU_Maintenance_Status.Fld_Desc.ToString();
            if (objLU_Maintenance_Status.Active != null)
                rdblActive.SelectedValue = objLU_Maintenance_Status.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
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
        PK_LU_Maintenance_Status = 0;
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

        LU_Maintenance_Status objLU_Maintenance_Status = new LU_Maintenance_Status();
        objLU_Maintenance_Status.Fld_Desc = txtDescription.Text.Trim();
        objLU_Maintenance_Status.PK_LU_Maintenance_Status = PK_LU_Maintenance_Status;
        objLU_Maintenance_Status.Active = rdblActive.SelectedValue;

        if (PK_LU_Maintenance_Status > 0)
        {
            _retVal = objLU_Maintenance_Status.Update();
            // Used to Check Duplicate ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add is already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Maintenance_Status.Insert();
            // Used to Check Duplicate  ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add is already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            PK_LU_Maintenance_Status = _retVal;
        }
        //clear Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion
}