using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_Contributing_Factor : System.Web.UI.Page
{
    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Contributing_Factor
    {
        get { return clsGeneral.GetInt(ViewState["PK_LU_Contributing_Factor"]); }
        set { ViewState["PK_LU_Contributing_Factor"] = value; }
    }

    #endregion

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
        }
    }
    #endregion

    #region "Control Event"

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        PK_LU_Contributing_Factor = 0;
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
        clsLU_Contributing_Factor objCont = new clsLU_Contributing_Factor();
        objCont.Field_Description = txtDescription.Text.Trim();
        objCont.PK_LU_Contributing_Factor = PK_LU_Contributing_Factor;
        objCont.Active = rdblActive.SelectedValue;

        if (PK_LU_Contributing_Factor > 0)
        {
            _retVal = objCont.Update();
            // Used to Check Duplicate Contributing factor Description
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
            _retVal = objCont.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the CRM Brand table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            PK_LU_Contributing_Factor = _retVal;
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

    protected void gvContriFactPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvContributingFact.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvContriFactRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Contributing_Factor = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            clsLU_Contributing_Factor obj = new clsLU_Contributing_Factor(PK_LU_Contributing_Factor);
            txtDescription.Text = obj.Field_Description.ToString();
            if (obj.Active != null)
                rdblActive.SelectedValue = obj.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Contributing Factor Grid
    /// </summary>
    private void BindGrid()
    { 
        //Get Record into Dataset
        DataSet ds = clsLU_Contributing_Factor.SelectAll();
        //Apply Dataset to Grid
        gvContributingFact.DataSource = ds;
        gvContributingFact.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Contributing_Factor = 0;
    }

    #endregion
}