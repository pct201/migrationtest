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

public partial class Administrator_LU_Paint_Type : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Paint_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Paint_Type"]);
        }
        set { ViewState["PK_LU_Paint_Type"] = value; }
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
        _PK_LU_Paint_Type = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtPaintType.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtPaintType);
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
        txtPaintType.Text = "";
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
        LU_Paint_Type objPaintType = new LU_Paint_Type();
        objPaintType.Fld_Desc = txtPaintType.Text.Trim();
        objPaintType.PK_LU_Paint_Type = _PK_LU_Paint_Type;
        objPaintType.Active = rdblActive.SelectedValue;

        if (_PK_LU_Paint_Type > 0)
        {
            _retVal = objPaintType.Update();
            // Used to Check Duplicate Paint Type ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Paint Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtPaintType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objPaintType.Insert();
            // Used to Check Duplicate Paint Type ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Paint Type that you are trying to add already exists in the Paint Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtPaintType);
                return;
            }
            _PK_LU_Paint_Type = _retVal;
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

    protected void gvPaintType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPaintType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvPaintType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Paint_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Paint_Type objStatus = new LU_Paint_Type(_PK_LU_Paint_Type);
            txtPaintType.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtPaintType);
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
        DataSet dsGroup = LU_Paint_Type.SelectAll();
        //Apply Dataset to Grid
        gvPaintType.DataSource = dsGroup;
        gvPaintType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Paint_Type = 0;
    }
    #endregion
}
