using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_AP_Cap_Index_Risk_Category : clsBasePage
{
    #region " Properties "

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_AP_Cap_Index_Risk_Category
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_AP_Cap_Index_Risk_Category"]);
        }
        set { ViewState["PK_LU_AP_Cap_Index_Risk_Category"] = value; }
    }

    #endregion

    #region " Page Event "
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

    #region " Event "

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        _PK_LU_AP_Cap_Index_Risk_Category = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        rdblActive.SelectedValue = "Y";
        txtDescription.Text = "";
        drpSort_Order.SelectedIndex = 1;
        txtMaximum_Score.Text = "";
        txtMinimum_Score.Text = "";
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
        drpSort_Order.SelectedIndex = 1;
        txtMaximum_Score.Text = "";
        txtMinimum_Score.Text = "";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        clsLU_AP_Cap_Index_Risk_Category objLU_AP_Cap_Index_Risk_Category = new clsLU_AP_Cap_Index_Risk_Category();
        objLU_AP_Cap_Index_Risk_Category.Fld_Desc = txtDescription.Text.Trim();
        objLU_AP_Cap_Index_Risk_Category.PK_LU_AP_Cap_Index_Risk_Category = _PK_LU_AP_Cap_Index_Risk_Category;
        objLU_AP_Cap_Index_Risk_Category.Sort_Order = Convert.ToDecimal(drpSort_Order.SelectedValue);
        objLU_AP_Cap_Index_Risk_Category.Maximum_Score = Convert.ToInt32(txtMaximum_Score.Text);
        objLU_AP_Cap_Index_Risk_Category.Minimum_Score = Convert.ToInt32(txtMinimum_Score.Text);
        objLU_AP_Cap_Index_Risk_Category.Active = rdblActive.SelectedValue;
        objLU_AP_Cap_Index_Risk_Category.Update_Date = DateTime.Now;
        objLU_AP_Cap_Index_Risk_Category.Updated_By = clsSession.UserID;

        if (_PK_LU_AP_Cap_Index_Risk_Category > 0)
        {
            _retVal = objLU_AP_Cap_Index_Risk_Category.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to Update already exists in the Cap Index Risk Category table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_AP_Cap_Index_Risk_Category.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Cap Index Risk Category table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_AP_Cap_Index_Risk_Category = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region " Grid Event "
    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAP_Cap_Index_Risk_Category_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAP_Cap_Index_Risk_Category.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAP_Cap_Index_Risk_Category_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_AP_Cap_Index_Risk_Category = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            clsLU_AP_Cap_Index_Risk_Category objLU_AP_Cap_Index_Risk_Category = new clsLU_AP_Cap_Index_Risk_Category(_PK_LU_AP_Cap_Index_Risk_Category);
            txtDescription.Text = objLU_AP_Cap_Index_Risk_Category.Fld_Desc.ToString();
            if (objLU_AP_Cap_Index_Risk_Category.Sort_Order != null) drpSort_Order.SelectedValue = Convert.ToString(objLU_AP_Cap_Index_Risk_Category.Sort_Order);
            if (objLU_AP_Cap_Index_Risk_Category.Maximum_Score != null) txtMaximum_Score.Text = Convert.ToString(objLU_AP_Cap_Index_Risk_Category.Maximum_Score);
            if (objLU_AP_Cap_Index_Risk_Category.Minimum_Score != null) txtMinimum_Score.Text = Convert.ToString(objLU_AP_Cap_Index_Risk_Category.Minimum_Score);
            if (objLU_AP_Cap_Index_Risk_Category.Active != null)
                rdblActive.SelectedValue = objLU_AP_Cap_Index_Risk_Category.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
    }

    #endregion

    #region " Methods "
    /// <summary>
    /// Bind CRM Department Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsLU_AP_Cap_Index_Risk_Category = clsLU_AP_Cap_Index_Risk_Category.SelectAll(0);
        //Apply Dataset to Grid
        gvAP_Cap_Index_Risk_Category.DataSource = dsLU_AP_Cap_Index_Risk_Category;
        gvAP_Cap_Index_Risk_Category.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_AP_Cap_Index_Risk_Category = 0;
    }

    #endregion
}