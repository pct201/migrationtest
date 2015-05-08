using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_Facility_Construction_Action_Item_Category : clsBasePage
{
    
    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Facility_Construction_Action_Item_Category
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Facility_Construction_Action_Item_Category"]);
        }
        set { ViewState["PK_LU_Facility_Construction_Action_Item_Category"] = value; }
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

    #region "Event"

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        PK_LU_Facility_Construction_Action_Item_Category = 0;
        trStatusAdd.Style.Add("display", "");
        lnkCancel.Style.Add("display", "");
        txtType.Text = "";
        rdblActive.SelectedValue = "Y";
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
        clsLU_Facility_Construction_Action_Item_Category objLU_Facility_Construction_Action_Item_Category = new clsLU_Facility_Construction_Action_Item_Category();
        objLU_Facility_Construction_Action_Item_Category.Type = txtType.Text.Trim();
        objLU_Facility_Construction_Action_Item_Category.PK_LU_Facility_Construction_Action_Item_Category = PK_LU_Facility_Construction_Action_Item_Category;
        objLU_Facility_Construction_Action_Item_Category.Active = rdblActive.SelectedValue;

        if (PK_LU_Facility_Construction_Action_Item_Category > 0)
        {
            _retVal = objLU_Facility_Construction_Action_Item_Category.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Facility_Construction_Action_Item_Category.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtType);
                return;
            }
            PK_LU_Facility_Construction_Action_Item_Category = _retVal;
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

    protected void gvType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Facility_Construction_Action_Item_Category = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            clsLU_Facility_Construction_Action_Item_Category objType = new clsLU_Facility_Construction_Action_Item_Category(PK_LU_Facility_Construction_Action_Item_Category);
            txtType.Text = Convert.ToString(objType.Type);
            if (objType.Active != null)
                rdblActive.SelectedValue = objType.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtType);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind CRM Brand Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = clsLU_Facility_Construction_Action_Item_Category.SelectAll();
        //Apply Dataset to Grid
        gvType.DataSource = dsGroup;
        gvType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Facility_Construction_Action_Item_Category = 0;
    }

    #endregion
}