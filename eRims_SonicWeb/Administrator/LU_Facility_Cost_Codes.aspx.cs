using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_LU_Facility_Cost_Codes : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Facility_Cost_Codes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Facility_Cost_Codes"]);
        }
        set { ViewState["PK_LU_Facility_Cost_Codes"] = value; }
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
        _PK_LU_Facility_Cost_Codes = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtCode.Text = "";
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
        txtCode.Text = "";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        clsLU_Facility_Cost_Codes objLU_Facility_Cost_Codes = new clsLU_Facility_Cost_Codes();
        objLU_Facility_Cost_Codes.Description = txtDescription.Text.Trim();
        objLU_Facility_Cost_Codes.PK_LU_Facility_Cost_Codes = _PK_LU_Facility_Cost_Codes;
        objLU_Facility_Cost_Codes.Code = txtCode.Text;

        if (_PK_LU_Facility_Cost_Codes > 0)
        {
            _retVal = objLU_Facility_Cost_Codes.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Equipment Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Facility_Cost_Codes.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Equipment Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_Facility_Cost_Codes = _retVal;
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
    protected void gvFacilityCostCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFacilityCostCodes.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFacilityCostCodes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Facility_Cost_Codes = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            clsLU_Facility_Cost_Codes objLU_Facility_Cost_Codes = new clsLU_Facility_Cost_Codes(_PK_LU_Facility_Cost_Codes);
            txtDescription.Text = objLU_Facility_Cost_Codes.Description.ToString();
            if (objLU_Facility_Cost_Codes.Code != null)
                txtCode.Text = objLU_Facility_Cost_Codes.Code.ToString();
            else
                txtCode.Text = "";
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
        DataSet dsLU_Facility_Cost_Codes = clsLU_Facility_Cost_Codes.SelectAll();
        //Apply Dataset to Grid
        gvFacilityCostCodes.DataSource = dsLU_Facility_Cost_Codes;
        gvFacilityCostCodes.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Facility_Cost_Codes = 0;
    }

    #endregion
}