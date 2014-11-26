using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_LU_SLT_Safety_Walk_Department : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_SLT_Safety_Walk_Department
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_SLT_Safety_Walk_Department"]);
        }
        set { ViewState["PK_LU_SLT_Safety_Walk_Department"] = value; }
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
        _PK_LU_SLT_Safety_Walk_Department = 0;
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
        LU_SLT_Safety_Walk_Department objSLTDepartment = new LU_SLT_Safety_Walk_Department();
        objSLTDepartment.PK_LU_SLT_Safety_Walk_Department = _PK_LU_SLT_Safety_Walk_Department;
        objSLTDepartment.Department = txtDepartment.Text.Trim();
        objSLTDepartment.Active = rdblActive.SelectedValue;

        if (_PK_LU_SLT_Safety_Walk_Department > 0)
        {
            _retVal = objSLTDepartment.Update();
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
            _retVal = objSLTDepartment.Insert();
            // Used to Check Duplicate Department?
            if (_retVal == -2)
            {
                lblError.Text = "The Department that you are trying to add already exists in the SLT Safety Walk Department table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDepartment);
                return;
            }
            _PK_LU_SLT_Safety_Walk_Department = _retVal;
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

    protected void gvSLTSafetyWalk_Department_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSLTSafetyWalk_Department.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvSLTSafetyWalk_Department_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_SLT_Safety_Walk_Department = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_SLT_Safety_Walk_Department objStatus = new LU_SLT_Safety_Walk_Department(_PK_LU_SLT_Safety_Walk_Department);
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
    /// Bind Sedgewick Scoring Brand Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_SLT_Safety_Walk_Department.SelectAll();
        //Apply Dataset to Grid
        gvSLTSafetyWalk_Department.DataSource = dsGroup;
        gvSLTSafetyWalk_Department.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_SLT_Safety_Walk_Department = 0;
    }

    #endregion
}