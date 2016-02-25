using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;


public partial class Administrator_LU_PM_Hearing_Conservation : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_Hearing_Conservation_Test_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Hearing_Conservation_Test_Type"]);
        }
        set { ViewState["PK_Hearing_Conservation_Test_Type"] = value; }
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
        _PK_Hearing_Conservation_Test_Type = 0;
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
        LU_Hearing_Conservation_Test_Type objLU_Hearing_Conservation_Test_Type = new LU_Hearing_Conservation_Test_Type();
        objLU_Hearing_Conservation_Test_Type.Fld_Desc = txtDescription.Text.Trim();
        objLU_Hearing_Conservation_Test_Type.PK_LU_Hearing_Conservation_Test_Type = _PK_Hearing_Conservation_Test_Type;
        objLU_Hearing_Conservation_Test_Type.Active = rdblActive.SelectedValue;

        if (_PK_Hearing_Conservation_Test_Type > 0)
        {
            _retVal = objLU_Hearing_Conservation_Test_Type.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Hearing Test Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Hearing_Conservation_Test_Type.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Hearing Test table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_Hearing_Conservation_Test_Type = _retVal;
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
    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHearingConservationTestType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHearingConservationTestType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHearingConservationTestType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_Hearing_Conservation_Test_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            LU_Hearing_Conservation_Test_Type objLU_Hearing_Conservation_Test_Type = new LU_Hearing_Conservation_Test_Type(_PK_Hearing_Conservation_Test_Type);
            txtDescription.Text = objLU_Hearing_Conservation_Test_Type.Fld_Desc.ToString();
            if (objLU_Hearing_Conservation_Test_Type.Active != null)
                rdblActive.SelectedValue = objLU_Hearing_Conservation_Test_Type.Active;
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
        //Get Record into Dataset
        DataSet dsLU_Hearing_Conservation_Test_Type = LU_Hearing_Conservation_Test_Type.SelectAll();
        //Apply Dataset to Grid
        gvHearingConservationTestType.DataSource = dsLU_Hearing_Conservation_Test_Type;
        gvHearingConservationTestType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_Hearing_Conservation_Test_Type = 0;
    }

    #endregion
}