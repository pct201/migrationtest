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

public partial class Administrator_LU_Hazard_Type : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Hazard_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Hazard_Type"]);
        }
        set { ViewState["PK_LU_Hazard_Type"] = value; }
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
        _PK_LU_Hazard_Type = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtHazardType.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtHazardType);
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
        txtHazardType.Text = "";
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
        LU_Hazard_Type objHazardType = new LU_Hazard_Type();
        objHazardType.Fld_Desc = txtHazardType.Text.Trim();
        objHazardType.PK_LU_Hazard_Type = _PK_LU_Hazard_Type;
        objHazardType.Active = rdblActive.SelectedValue;

        if (_PK_LU_Hazard_Type > 0)
        {
            _retVal = objHazardType.Update();
            // Used to Check Duplicate Hazard Type ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Hazard Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtHazardType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objHazardType.Insert();
            // Used to Check Duplicate Hazard Type ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Hazard Type that you are trying to add already exists in the Hazard Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtHazardType);
                return;
            }
            _PK_LU_Hazard_Type = _retVal;
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

    protected void gvHazardType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHazardType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvHazardType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Hazard_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Hazard_Type objStatus = new LU_Hazard_Type(_PK_LU_Hazard_Type);
            txtHazardType.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtHazardType);
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
        DataSet dsGroup = LU_Hazard_Type.SelectAll();
        //Apply Dataset to Grid
        gvHazardType.DataSource = dsGroup;
        gvHazardType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Hazard_Type = 0;
    }
    #endregion
}
