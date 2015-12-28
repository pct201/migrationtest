using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_LU_SLT_BT_Security_Walk_Department : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_SLT_BT_Security_Walk_Department
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_SLT_BT_Security_Walk_Department"]);
        }
        set { ViewState["PK_LU_SLT_BT_Security_Walk_Department"] = value; }
    }

    #endregion

    #region "Page Event"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
        _PK_LU_SLT_BT_Security_Walk_Department = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtDepartment.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDepartment);
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
        txtDepartment.Text = "";
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
        clsLU_SLT_BT_Security_Walk_Department objBTSecDep = new clsLU_SLT_BT_Security_Walk_Department();
        objBTSecDep.PK_LU_SLT_BT_Security_Walk_Department = _PK_LU_SLT_BT_Security_Walk_Department;
        objBTSecDep.Department = txtDepartment.Text.Trim();
        objBTSecDep.Active = rdblActive.SelectedValue;

        if (_PK_LU_SLT_BT_Security_Walk_Department > 0)
        {
            _retVal = objBTSecDep.Update();
            // Used to Check Duplicate Department?
            if (_retVal == -2)
            {
                lblError.Text = "The Department that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDepartment);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objBTSecDep.Insert();
            // Used to Check Duplicate Department?
            if (_retVal == -2)
            {
                lblError.Text = "The Department that you are trying to add already exists in the SLT BT Security Walk Department table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDepartment);
                return;
            }
            _PK_LU_SLT_BT_Security_Walk_Department = _retVal;
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

    protected void gvSLTBTSecWalk_Department_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSLTBTSecWalk_Department.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvSLTBTSecWalk_Department_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_SLT_BT_Security_Walk_Department = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            clsLU_SLT_BT_Security_Walk_Department objStatus = new clsLU_SLT_BT_Security_Walk_Department(_PK_LU_SLT_BT_Security_Walk_Department);
            txtDepartment.Text = objStatus.Department.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Grid
    /// </summary>
    private void BindGrid()
    {
        DataSet dsGroup = clsLU_SLT_BT_Security_Walk_Department.SelectAll();
        gvSLTBTSecWalk_Department.DataSource = dsGroup;
        gvSLTBTSecWalk_Department.DataBind();
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_SLT_BT_Security_Walk_Department = 0;
    }

    #endregion
}