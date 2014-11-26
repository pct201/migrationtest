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

public partial class Administrator_ProjectType : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Project_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Project_Type"]);
        }
        set { ViewState["PK_LU_Project_Type"] = value; }
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
        _PK_LU_Project_Type = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtProjectType.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtProjectType);
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
        txtProjectType.Text = "";
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
        LU_Project_Type objProjectType = new LU_Project_Type();
        objProjectType.Fld_Desc = txtProjectType.Text.Trim();
        objProjectType.Active = rdblActive.SelectedValue;
        objProjectType.PK_LU_Project_Type = _PK_LU_Project_Type;

        if (_PK_LU_Project_Type > 0)
        {
            _retVal = objProjectType.Update();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Project Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtProjectType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objProjectType.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Project Type that you are trying to add already exists in the Project Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtProjectType);
                return;
            }
            _PK_LU_Project_Type = _retVal;
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

    protected void gvProjectType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProjectType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvProjectType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Project_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Project_Type objStatus = new LU_Project_Type(_PK_LU_Project_Type);
            txtProjectType.Text = objStatus.Fld_Desc.ToString();

            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;

            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtProjectType);
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
        DataSet dsGroup = LU_Project_Type.SelectAll();
        //Apply Dataset to Grid
        gvProjectType.DataSource = dsGroup;
        gvProjectType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Project_Type = 0;
    }
    #endregion
}
