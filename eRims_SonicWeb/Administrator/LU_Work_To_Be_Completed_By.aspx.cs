using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_Work_To_Be_Completed_By : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Work_To_Be_Completed_By
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Work_To_Be_Completed_By"]);
        }
        set { ViewState["PK_LU_Work_To_Be_Completed_By"] = value; }
    }

    #endregion

    #region "Page Event"
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        PK_LU_Work_To_Be_Completed_By = 0;
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

        LU_Work_To_Be_Completed_By objclsLU_Work_Completed = new LU_Work_To_Be_Completed_By();

        objclsLU_Work_Completed.Fld_Desc = txtDescription.Text.Trim();
        objclsLU_Work_Completed.PK_LU_Work_To_Be_Completed_By = PK_LU_Work_To_Be_Completed_By;
        objclsLU_Work_Completed.Active = rdblActive.SelectedValue;

        if (PK_LU_Work_To_Be_Completed_By > 0)
        {
            _retVal = objclsLU_Work_Completed.Update();
            // Used to Check Duplicate Media ID?
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
            _retVal = objclsLU_Work_Completed.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add is already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            PK_LU_Work_To_Be_Completed_By = _retVal;
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
    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWorkCompleted_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvWorkCompleted.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWorkCompleted_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Work_To_Be_Completed_By = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";

            LU_Work_To_Be_Completed_By objLU_Work_Completed = new LU_Work_To_Be_Completed_By(PK_LU_Work_To_Be_Completed_By);
            txtDescription.Text = objLU_Work_Completed.Fld_Desc.ToString();
            if (objLU_Work_Completed.Active != null)
                rdblActive.SelectedValue = objLU_Work_Completed.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind CRM Department Grid
    /// </summary>
    private void BindGrid()
    {
        DataSet dsLU_Work_Completed = LU_Work_To_Be_Completed_By.SelectAll();
        gvWorkCompleted.DataSource = dsLU_Work_Completed;
        gvWorkCompleted.DataBind();
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Work_To_Be_Completed_By = 0;
    }

    #endregion
}