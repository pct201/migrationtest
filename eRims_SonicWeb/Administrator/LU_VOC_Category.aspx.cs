using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Administrator_LU_VOC_Category : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_VOC_Category
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_VOC_Category"]);
        }
        set { ViewState["PK_LU_VOC_Category"] = value; }
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
        _PK_LU_VOC_Category = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        rdblActive.SelectedValue = "Y";
        txtCategory.Text = "";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCategory);
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
        txtCategory.Text = "";
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
        clsLU_VOC_Category objLU_VOC_Category = new clsLU_VOC_Category();
        objLU_VOC_Category.Category = txtCategory.Text.Trim();
        objLU_VOC_Category.PK_LU_VOC_Category = _PK_LU_VOC_Category;
        objLU_VOC_Category.Active = rdblActive.SelectedValue;

        if (_PK_LU_VOC_Category > 0)
        {
            _retVal = objLU_VOC_Category.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Category that you are trying to add already exists in the VOC Category table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCategory);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_VOC_Category.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Category that you are trying to add already exists in the VOC Category table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCategory);
                return;
            }
            _PK_LU_VOC_Category = _retVal;
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
    protected void gvVOCCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVOCCategory.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvVOCCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_VOC_Category = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";

            // get record from database
            clsLU_VOC_Category objLU_VOC_Category = new clsLU_VOC_Category(_PK_LU_VOC_Category);
            txtCategory.Text = objLU_VOC_Category.Category.ToString();
            if (objLU_VOC_Category.Active != null)
                rdblActive.SelectedValue = objLU_VOC_Category.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCategory);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Bind VOC Category Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsLU_VOC_Category = clsLU_VOC_Category.SelectAll();
        //Apply Dataset to Grid
        gvVOCCategory.DataSource = dsLU_VOC_Category;
        gvVOCCategory.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_VOC_Category = 0;
    }

    #endregion
}