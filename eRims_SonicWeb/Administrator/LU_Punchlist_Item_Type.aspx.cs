using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_LU_Punchlist_Item_Type : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Punchlist_Item_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Punchlist_Item_Type"]);
        }
        set { ViewState["PK_LU_Punchlist_Item_Type"] = value; }
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
        _PK_LU_Punchlist_Item_Type = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        rdblActive.SelectedValue = "Y";
        txtType.Text = "";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtType);
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
        txtType.Text = "";
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
        LU_Punchlist_Item_Type objLU_Punchlist_Item_Type = new LU_Punchlist_Item_Type();
        objLU_Punchlist_Item_Type.Type = txtType.Text.Trim();
        objLU_Punchlist_Item_Type.PK_LU_Punchlist_Item_Type = _PK_LU_Punchlist_Item_Type;
        objLU_Punchlist_Item_Type.Active = rdblActive.SelectedValue;

        if (_PK_LU_Punchlist_Item_Type > 0)
        {
            _retVal = objLU_Punchlist_Item_Type.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Type that you are trying to add already exists in the Equipment Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Punchlist_Item_Type.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Type that you are trying to add already exists in the Equipment Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtType);
                return;
            }
            _PK_LU_Punchlist_Item_Type = _retVal;
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
    protected void gvLU_Punchlist_Item_Type_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLU_Punchlist_Item_Type.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLU_Punchlist_Item_Type_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Punchlist_Item_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            LU_Punchlist_Item_Type objLU_Punchlist_Item_Type = new LU_Punchlist_Item_Type(_PK_LU_Punchlist_Item_Type);
            txtType.Text = objLU_Punchlist_Item_Type.Type.ToString();
            if (objLU_Punchlist_Item_Type.Active != null)
                rdblActive.SelectedValue = objLU_Punchlist_Item_Type.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtType);
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
        DataSet dsLU_Punchlist_Item_Type = LU_Punchlist_Item_Type.SelectAll();
        //Apply Dataset to Grid
        gvLU_Punchlist_Item_Type.DataSource = dsLU_Punchlist_Item_Type;
        gvLU_Punchlist_Item_Type.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Punchlist_Item_Type = 0;
    }

    #endregion
}