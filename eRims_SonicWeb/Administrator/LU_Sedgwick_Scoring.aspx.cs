using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class Administrator_LU_Sedgwick_Scoring : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Sedgwick_Scoring
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Sedgwick_Scoring"]);
        }
        set { ViewState["PK_LU_Sedgwick_Scoring"] = value; }
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
        _PK_LU_Sedgwick_Scoring = 0;
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
        txtDescription.Text = "";
        drpManagement_Section.SelectedIndex = 0;
        txtSort_Order.Text = "";
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
        LU_Sedgwick_Scoring objSedgwickScoring = new LU_Sedgwick_Scoring();
        objSedgwickScoring.PK_LU_Sedgwick_Scoring = _PK_LU_Sedgwick_Scoring;
        objSedgwickScoring.Scoring_Note = txtDescription.Text.Trim();
        objSedgwickScoring.Sort_Order =Convert.ToDecimal(txtSort_Order.Text);
        objSedgwickScoring.Active = rdblActive.SelectedValue;
        if (drpManagement_Section.SelectedItem.Value != "")
            objSedgwickScoring.Management_Section = drpManagement_Section.SelectedItem.Value;
        else
            objSedgwickScoring.Management_Section = null;

        if (_PK_LU_Sedgwick_Scoring > 0)
        {
            _retVal = objSedgwickScoring.Update();
            // Used to Check Duplicate Sedgwick Scoring ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Scoring Note that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objSedgwickScoring.Insert();
            // Used to Check Duplicate Sedgwick Scoring ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Scoring Note that you are trying to add already exists in the Sedgwick Scoring table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_Sedgwick_Scoring = _retVal;
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

    protected void gvSedgwick_Scoring_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSedgwick_Scoring.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvSedgwick_Scoring_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Sedgwick_Scoring = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Sedgwick_Scoring objStatus = new LU_Sedgwick_Scoring(_PK_LU_Sedgwick_Scoring);
            txtDescription.Text = objStatus.Scoring_Note.ToString();
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
            txtSort_Order.Text =Convert.ToString(objStatus.Sort_Order);
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(drpManagement_Section);
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
        DataSet dsGroup = LU_Sedgwick_Scoring.SelectAll();
        //Apply Dataset to Grid
        gvSedgwick_Scoring.DataSource = dsGroup;
        gvSedgwick_Scoring.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Sedgwick_Scoring = 0;
    }

    #endregion
}