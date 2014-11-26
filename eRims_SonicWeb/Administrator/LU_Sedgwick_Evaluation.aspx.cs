using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class Administrator_LU_Sedgwick_Evaluation : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Sedgwick_Evaluation
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Sedgwick_Evaluation"]);
        }
        set { ViewState["PK_LU_Sedgwick_Evaluation"] = value; }
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
        _PK_LU_Sedgwick_Evaluation = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtDescription.Text = "";
        drpManagement_Section.SelectedIndex = 0;
        txtSort_Order.Text = "";
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
        drpManagement_Section.SelectedIndex = 0;
        txtSort_Order.Text = "";
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
        LU_Sedgwick_Evaluation objSedgwickEvaluation = new LU_Sedgwick_Evaluation();
        objSedgwickEvaluation.PK_LU_Sedgwick_Evaluation = _PK_LU_Sedgwick_Evaluation;
        objSedgwickEvaluation.Evaluation = txtDescription.Text.Trim();
        objSedgwickEvaluation.Sort_Order = Convert.ToDecimal(txtSort_Order.Text);
        objSedgwickEvaluation.Active = rdblActive.SelectedValue;
        if (drpManagement_Section.SelectedItem.Value != "")
            objSedgwickEvaluation.Management_Section = drpManagement_Section.SelectedItem.Value;
        else
            objSedgwickEvaluation.Management_Section = null;

        if (_PK_LU_Sedgwick_Evaluation > 0)
        {
            _retVal = objSedgwickEvaluation.Update();
            // Used to Check Duplicate Sedgewick Evaluation ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Evaluation that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objSedgwickEvaluation.Insert();
            // Used to Check Duplicate Sedgewick Evaluation ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Evaluation that you are trying to add already exists in the Sedgewick Evaluation table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_Sedgwick_Evaluation = _retVal;
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

    protected void gvSedgwick_Evaluation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSedgwick_Evaluation.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvSedgwick_Evaluation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Sedgwick_Evaluation = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Sedgwick_Evaluation objStatus = new LU_Sedgwick_Evaluation(_PK_LU_Sedgwick_Evaluation);
            txtDescription.Text = objStatus.Evaluation.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ListItem liManagement_Section = drpManagement_Section.Items.FindByText(objStatus.Management_Section);
            if (liManagement_Section != null)
            {
                drpManagement_Section.ClearSelection();
                drpManagement_Section.Items.FindByText(objStatus.Management_Section).Selected = true;
            }
            else
            {
                drpManagement_Section.SelectedIndex = 0;
            }
            txtSort_Order.Text = Convert.ToString(objStatus.Sort_Order);
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(drpManagement_Section);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Sedgewick Evaluation Brand Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Sedgwick_Evaluation.SelectAll();
        //Apply Dataset to Grid
        gvSedgwick_Evaluation.DataSource = dsGroup;
        gvSedgwick_Evaluation.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Sedgwick_Evaluation = 0;
    }

    #endregion
}