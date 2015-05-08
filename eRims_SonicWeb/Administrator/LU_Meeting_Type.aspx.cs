using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_Meeting_Type : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Meeting_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Meeting_Type"]);
        }
        set { ViewState["PK_LU_Meeting_Type"] = value; }
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
        PK_LU_Meeting_Type = 0;
        trStatusAdd.Style.Add("display", "");
        lnkCancel.Style.Add("display", "");
        txtMeeting_Type.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtMeeting_Type);
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
        txtMeeting_Type.Text = "";
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
        clsLU_Meeting_Type objLU_Meeting_Type = new clsLU_Meeting_Type();
        objLU_Meeting_Type.Meeting_Type = txtMeeting_Type.Text.Trim();
        objLU_Meeting_Type.PK_LU_Meeting_Type = PK_LU_Meeting_Type;
        objLU_Meeting_Type.Active = rdblActive.SelectedValue;

        if (PK_LU_Meeting_Type > 0)
        {
            _retVal = objLU_Meeting_Type.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Meeting Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtMeeting_Type);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Meeting_Type.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Meeting Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtMeeting_Type);
                return;
            }
            PK_LU_Meeting_Type = _retVal;
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

    protected void gvMeeting_Type_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMeeting_Type.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvMeeting_Type_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Meeting_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            clsLU_Meeting_Type objMeeting_Type = new clsLU_Meeting_Type(PK_LU_Meeting_Type);
            txtMeeting_Type.Text = Convert.ToString(objMeeting_Type.Meeting_Type);
            if (objMeeting_Type.Active != null)
                rdblActive.SelectedValue = objMeeting_Type.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtMeeting_Type);
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
        DataSet dsGroup = clsLU_Meeting_Type.SelectAll();
        //Apply Dataset to Grid
        gvMeeting_Type.DataSource = dsGroup;
        gvMeeting_Type.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Meeting_Type = 0;
    }

    #endregion
}