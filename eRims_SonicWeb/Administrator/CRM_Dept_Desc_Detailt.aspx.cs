using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_CRM_Dept_Desc_Detailt : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_CRM_Dept_Desc_Detail
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_CRM_Dept_Desc_Detail"]);
        }
        set { ViewState["PK_LU_CRM_Dept_Desc_Detail"] = value; }
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
        _PK_LU_CRM_Dept_Desc_Detail = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtDescription.Text = "";
        rdblActive.SelectedValue = "Y";
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
        LU_CRM_Dept_Desc_Detail objCRMDepartment = new LU_CRM_Dept_Desc_Detail();
        objCRMDepartment.Fld_Desc = txtDescription.Text.Trim();
        objCRMDepartment.PK_LU_CRM_Dept_Desc_Detail = _PK_LU_CRM_Dept_Desc_Detail;
        objCRMDepartment.Active = rdblActive.SelectedValue;

        if (_PK_LU_CRM_Dept_Desc_Detail > 0)
        {
            _retVal = objCRMDepartment.Update();
            // Used to Check Duplicate CRM Department Description ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objCRMDepartment.Insert();
            // Used to Check Duplicate CRM Department Description ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the CRM Department Description Detail table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_CRM_Dept_Desc_Detail = _retVal;
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

    protected void gvCRM_Desc_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCRM_Desc_Detail.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvCRM_Desc_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_CRM_Dept_Desc_Detail = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_CRM_Dept_Desc_Detail objStatus = new LU_CRM_Dept_Desc_Detail(_PK_LU_CRM_Dept_Desc_Detail);
            txtDescription.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind CRM Department Description Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_CRM_Dept_Desc_Detail.SelectAll();
        //Apply Dataset to Grid
        gvCRM_Desc_Detail.DataSource = dsGroup;
        gvCRM_Desc_Detail.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_CRM_Dept_Desc_Detail = 0;
    }

    #endregion
}