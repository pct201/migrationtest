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

public partial class Administrator_LU_Chemical_Family : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Chemical_Family
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Chemical_Family"]);
        }
        set { ViewState["PK_LU_Chemical_Family"] = value; }
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
        _PK_LU_Chemical_Family = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtChemicalFamily.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtChemicalFamily);
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
        txtChemicalFamily.Text = "";
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
        LU_Chemical_Family objChemicalFamily = new LU_Chemical_Family();
        objChemicalFamily.Fld_Desc = txtChemicalFamily.Text.Trim();
        objChemicalFamily.PK_LU_Chemical_Family = _PK_LU_Chemical_Family;
        objChemicalFamily.Active = rdblActive.SelectedValue;

        if (_PK_LU_Chemical_Family > 0)
        {
            _retVal = objChemicalFamily.Update();
            // Used to Check Duplicate Chemical Family ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Chemical Family that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtChemicalFamily);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objChemicalFamily.Insert();
            // Used to Check Duplicate Chemical Family ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Chemical Family that you are trying to add already exists in the Chemical Family table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtChemicalFamily);
                return;
            }
            _PK_LU_Chemical_Family = _retVal;
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

    protected void gvChemicalFamily_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvChemicalFamily.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvChemicalFamily_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Chemical_Family = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Chemical_Family objStatus = new LU_Chemical_Family(_PK_LU_Chemical_Family);
            txtChemicalFamily.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtChemicalFamily);
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
        DataSet dsGroup = LU_Chemical_Family.SelectAll();
        //Apply Dataset to Grid
        gvChemicalFamily.DataSource = dsGroup;
        gvChemicalFamily.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Chemical_Family = 0;
    }
    #endregion
}
