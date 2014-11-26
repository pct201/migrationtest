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

public partial class Administrator_LeaseType : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Lease_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Lease_Type"]);
        }
        set { ViewState["PK_LU_Lease_Type"] = value; }
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
        _PK_LU_Lease_Type = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtLeaseType.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtLeaseType);
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
        txtLeaseType.Text = "";
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
        LU_Lease_Type objLeaseType = new LU_Lease_Type();
        objLeaseType.Fld_Desc = txtLeaseType.Text.Trim();
        objLeaseType.PK_LU_Lease_Type = _PK_LU_Lease_Type;
        objLeaseType.Active = rdblActive.SelectedValue;

        if (_PK_LU_Lease_Type > 0)
        {
            _retVal = objLeaseType.Update();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Lease Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtLeaseType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLeaseType.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Lease Type that you are trying to add already exists in the Lease Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtLeaseType);
                return;
            }
            _PK_LU_Lease_Type = _retVal;
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

    protected void gvLeaseType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLeaseType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvLeaseType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Lease_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Lease_Type objStatus = new LU_Lease_Type(_PK_LU_Lease_Type);
            txtLeaseType.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtLeaseType);
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
        DataSet dsGroup = LU_Lease_Type.SelectAll();
        //Apply Dataset to Grid
        gvLeaseType.DataSource = dsGroup;
        gvLeaseType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Lease_Type = 0;
    }
    #endregion
}
