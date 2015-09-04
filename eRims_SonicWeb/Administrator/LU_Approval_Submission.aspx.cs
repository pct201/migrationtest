using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_LU_Approval_Submission : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Approval_Submission
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Approval_Submission"]);
        }
        set { ViewState["PK_LU_Approval_Submission"] = value; }
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
        PK_LU_Approval_Submission = 0;
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

        clsLU_Approval_Submission objLU_Approval_Submission = new clsLU_Approval_Submission();
        objLU_Approval_Submission.Fld_Desc = txtDescription.Text.Trim();
        objLU_Approval_Submission.PK_LU_Approval_Submission = PK_LU_Approval_Submission;
        objLU_Approval_Submission.Active = rdblActive.SelectedValue;

        if (PK_LU_Approval_Submission > 0)
        {
            _retVal = objLU_Approval_Submission.Update();
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
            _retVal = objLU_Approval_Submission.Insert();
            // Used to Check Duplicate  ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add is already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            PK_LU_Approval_Submission = _retVal;
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
    protected void gvApprovalSubmission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvApprovalSubmission.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvApprovalSubmission_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Approval_Submission = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";

            clsLU_Approval_Submission objLU_Approval_Submission = new clsLU_Approval_Submission(PK_LU_Approval_Submission);
            txtDescription.Text = objLU_Approval_Submission.Fld_Desc.ToString();
            if (objLU_Approval_Submission.Active != null)
                rdblActive.SelectedValue = objLU_Approval_Submission.Active;
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
        DataSet dsLU_Approval_Submission = clsLU_Approval_Submission.SelectAll();
        gvApprovalSubmission.DataSource = dsLU_Approval_Submission;
        gvApprovalSubmission.DataBind();
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Approval_Submission = 0;
    }

    #endregion
}