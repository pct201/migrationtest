using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Administrator_LU_Respirator_Type : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Respirator_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Respirator_Type"]);
        }
        set { ViewState["PK_LU_Respirator_Type"] = value; }
    }

    #endregion

    #region "Page Event"

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
        _PK_LU_Respirator_Type = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtRespiratorType.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtRespiratorType);
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
        txtRespiratorType.Text = "";
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
        clsLU_Respirator_Type objRespirator_Type = new clsLU_Respirator_Type();
        objRespirator_Type.Fld_Desc = txtRespiratorType.Text.Trim();
        objRespirator_Type.PK_LU_Respirator_Type = _PK_LU_Respirator_Type;
        objRespirator_Type.Active = rdblActive.SelectedValue;

        if (_PK_LU_Respirator_Type > 0)
        {
            _retVal = objRespirator_Type.Update();
            // Used to Check Duplicate Respirator Type ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Respirator Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtRespiratorType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objRespirator_Type.Insert();
            // Used to Check Duplicate Respirator Type ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Respirator Type that you are trying to add already exists in the Respirator Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtRespiratorType);
                return;
            }
            _PK_LU_Respirator_Type = _retVal;
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

    protected void gvRespiratorType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRespiratorType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvRespiratorType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Respirator_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            clsLU_Respirator_Type objRespirator_Type = new clsLU_Respirator_Type(_PK_LU_Respirator_Type);
            txtRespiratorType.Text = objRespirator_Type.Fld_Desc.ToString();
            if (objRespirator_Type.Active != null)
                rdblActive.SelectedValue = objRespirator_Type.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtRespiratorType);
        }
    }

    #endregion
    
    #region Methods
    /// <summary>
    /// Bind Manufacturer Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsRespirator_Type = clsLU_Respirator_Type.SelectAll();
        //Apply Dataset to Grid
        gvRespiratorType.DataSource = dsRespirator_Type;
        gvRespiratorType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Respirator_Type = 0;
    }
    #endregion
}
