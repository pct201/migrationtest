using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_PL_Loss_Category : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_PL_Loss_Category
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_PL_Loss_Category"]);
        }
        set { ViewState["PK_LU_PL_Loss_Category"] = value; }
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
        _PK_LU_PL_Loss_Category = 0;
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
        LU_PL_Loss_Category objLU_PL_Loss_Category = new LU_PL_Loss_Category();
        objLU_PL_Loss_Category.Description = txtDescription.Text.Trim();
        objLU_PL_Loss_Category.PK_LU_PL_Loss_Category = _PK_LU_PL_Loss_Category;
        objLU_PL_Loss_Category.Active = rdblActive.SelectedValue;

        if (_PK_LU_PL_Loss_Category > 0)
        {
            _retVal = objLU_PL_Loss_Category.Update();
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
            _retVal = objLU_PL_Loss_Category.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Description that you are trying to add already exists in the Equipment Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_PL_Loss_Category = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    /// <summary>
    /// link Save Reorder List Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSaveReorderList_Click(object sender, EventArgs e)
    {
        string strSortNew, strHiddenPK;
        strHiddenPK = hdnPKId.Value;
        string[] strSortOrderArray = strHiddenPK.Split(',');
        string strXmlFinal = "<LU_PL_Loss_Category>";
        int lengthSortOrder = strSortOrderArray.Length;

        for (int count = 0; count < lengthSortOrder; count++)
        {
            strXmlFinal = strXmlFinal + "<so><PK_LU_PL_Loss_Category>" + strSortOrderArray[count] + "</PK_LU_PL_Loss_Category><Sort_Order>" + (count + 1) + "</Sort_Order></so>";
        }
        strXmlFinal = strXmlFinal + "</LU_PL_Loss_Category>";
        LU_PL_Loss_Category.UpdateLU_PL_Loss_CategorySortOrder(strXmlFinal);

        BindGrid();
    }

    #endregion

    #region "Grid Event"

    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLossCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLossCategory.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLossCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_PL_Loss_Category = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            LU_PL_Loss_Category objLU_PL_Loss_Category = new LU_PL_Loss_Category(_PK_LU_PL_Loss_Category);
            txtDescription.Text = objLU_PL_Loss_Category.Description.ToString();
            if (objLU_PL_Loss_Category.Active != null)
                rdblActive.SelectedValue = objLU_PL_Loss_Category.Active;
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
        DataSet dsLU_PL_Loss_Category = LU_PL_Loss_Category.SelectAll();
        //Apply Dataset to Grid
        gvLossCategory.DataSource = dsLU_PL_Loss_Category;
        gvLossCategory.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_PL_Loss_Category = 0;
    }

    #endregion
}