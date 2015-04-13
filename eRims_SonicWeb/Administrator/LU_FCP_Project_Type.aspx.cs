using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_FCP_Project_Type : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_FCP_Project_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_FCP_Project_Type"]);
        }
        set { ViewState["PK_LU_FCP_Project_Type"] = value; }
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
        _PK_LU_FCP_Project_Type = 0;
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
        LU_Facility_Project_Type objProjectType = new LU_Facility_Project_Type();
        objProjectType.Type_Description = txtDescription.Text.Trim();
        objProjectType.PK_LU_Facility_Project_Type = _PK_LU_FCP_Project_Type;
        objProjectType.Active = rdblActive.SelectedValue;

        if (objProjectType.CheckTypeDescriptionDuplication(_PK_LU_FCP_Project_Type, txtDescription.Text.Trim()) == 0)
        {
            if (_PK_LU_FCP_Project_Type > 0)
            {
                objProjectType.Update();
                btnAdd.Text = "Add";
            }
            else
            {
                _PK_LU_FCP_Project_Type = objProjectType.Insert();
            }
        }
        else
        {
            lblError.Text = "The Description that you are trying to add already exists in the Facility Project Type table.";
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
            return;
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
    protected void gvEPMProjectType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEPMProjectType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEPMProjectType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_FCP_Project_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Facility_Project_Type objProjectType = new LU_Facility_Project_Type(_PK_LU_FCP_Project_Type);
            txtDescription.Text = objProjectType.Type_Description.ToString();
            if (objProjectType.Active != null)
                rdblActive.SelectedValue = objProjectType.Active;
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
        DataSet dsProjectType = LU_Facility_Project_Type.SelectAll(string.Empty);    // "Y" for Active, "N" for InActive, and "" for All
        //Apply Dataset to Grid
        gvEPMProjectType.DataSource = dsProjectType;
        gvEPMProjectType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_FCP_Project_Type = 0;
    }

    #endregion
}