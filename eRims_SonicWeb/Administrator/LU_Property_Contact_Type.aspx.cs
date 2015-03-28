using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class LU_Property_Contact_Type : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Property_Contact_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Property_Contact_Type"]);
        }
        set { ViewState["PK_LU_Property_Contact_Type"] = value; }
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
        _PK_LU_Property_Contact_Type = 0;
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
        drpCategory.SelectedValue = "0";
        rdblActive.SelectedValue = "Y";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int _retVal;
        clsLU_Property_Contact_Type objLU_Cable_Length = new clsLU_Property_Contact_Type();
        objLU_Cable_Length.Fld_Desc = txtDescription.Text.Trim();
        objLU_Cable_Length.PK_LU_Property_Contact_Type = _PK_LU_Property_Contact_Type;
        objLU_Cable_Length.Category = drpCategory.SelectedValue;
        objLU_Cable_Length.Active = rdblActive.SelectedValue;

        if (_PK_LU_Property_Contact_Type > 0)
        {
            _retVal = objLU_Cable_Length.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Cable Length table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Cable_Length.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Cable Length table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_Property_Contact_Type = _retVal;
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
    protected void gvPropertyContactType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPropertyContactType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPropertyContactType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Property_Contact_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            clsLU_Property_Contact_Type objLU_Property_Contact_Type = new clsLU_Property_Contact_Type(_PK_LU_Property_Contact_Type);
            txtDescription.Text = objLU_Property_Contact_Type.Fld_Desc.ToString();
            if (drpCategory.Items.FindByValue(objLU_Property_Contact_Type.Category) != null)
                drpCategory.SelectedValue = objLU_Property_Contact_Type.Category;

            if (objLU_Property_Contact_Type.Active != null)
                rdblActive.SelectedValue = objLU_Property_Contact_Type.Active;
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
        DataSet dsLU_Property_Contact_Type = clsLU_Property_Contact_Type.SelectAll();
        //Apply Dataset to Grid
        gvPropertyContactType.DataSource = dsLU_Property_Contact_Type;
        gvPropertyContactType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Property_Contact_Type = 0;
    }

    #endregion
}