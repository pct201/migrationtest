using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;


public partial class Administrator_U_A_Request_Admin : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_U_A_Request_Admin
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_U_A_Request_Admin"]);
        }
        set { ViewState["PK_U_A_Request_Admin"] = value; }
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
        _PK_U_A_Request_Admin = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtName.Text = "";
        txtEmail.Text = "";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtName);
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
        txtEmail.Text = "";
        txtName.Text = "";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        U_A_Request_Admin objU_A_Request_Admin = new U_A_Request_Admin();
        objU_A_Request_Admin.Admin_EMail = txtEmail.Text.Trim();
        objU_A_Request_Admin.PK_U_A_Request_Admin = _PK_U_A_Request_Admin;
        objU_A_Request_Admin.Name = txtName.Text;

        if (_PK_U_A_Request_Admin > 0)
        {
            _retVal = objU_A_Request_Admin.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Name and Email that you are trying to add already exists in the U_A_Request_Admin table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtEmail);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objU_A_Request_Admin.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Name and Email that you are trying to add already exists in the U_A_Request_Admin table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtEmail);
                return;
            }
            _PK_U_A_Request_Admin = _retVal;
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
    protected void gvU_A_Request_Admin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvU_A_Request_Admin.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvU_A_Request_Admin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_U_A_Request_Admin = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            U_A_Request_Admin objU_A_Request_Admin = new U_A_Request_Admin(_PK_U_A_Request_Admin);
            txtEmail.Text = objU_A_Request_Admin.Admin_EMail.ToString();
            if (objU_A_Request_Admin.Name != null)
                txtName.Text = objU_A_Request_Admin.Name;
            else
                txtName.Text = "";
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtName);
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
        DataSet dsU_A_Request_Admin = U_A_Request_Admin.SelectAll();
        //Apply Dataset to Grid
        gvU_A_Request_Admin.DataSource = dsU_A_Request_Admin;
        gvU_A_Request_Admin.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_U_A_Request_Admin = 0;
    }
    #endregion
}