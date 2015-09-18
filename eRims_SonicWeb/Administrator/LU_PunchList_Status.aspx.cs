using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_LU_PunchList_Status : System.Web.UI.Page
{
    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_PunchList_Status
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_PunchList_Status"]);
        }
        set { ViewState["PK_LU_PunchList_Status"] = value; }
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
        PK_LU_PunchList_Status = 0;
        trStatusAdd.Style.Add("display", "");
        lnkCancel.Style.Add("display", "");
        txtStatus.Text = "";

        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStatus);
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
        txtStatus.Text = "";

    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        LU_PunchList_Status objLU_PunchList_Status = new LU_PunchList_Status();
        objLU_PunchList_Status.Descr = txtStatus.Text.Trim();
        objLU_PunchList_Status.PK_LU_PunchList_Status = PK_LU_PunchList_Status;


        if (PK_LU_PunchList_Status > 0)
        {
            _retVal = objLU_PunchList_Status.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Punch List Status that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStatus);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_PunchList_Status.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Punch List Status that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStatus);
                return;
            }
            PK_LU_PunchList_Status = _retVal;
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

    protected void gvPunchListStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPunchListStatus.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    protected void gvPunchListStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_PunchList_Status = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_PunchList_Status objLU_PunchList_Status = new LU_PunchList_Status(PK_LU_PunchList_Status);
            txtStatus.Text = Convert.ToString(objLU_PunchList_Status.Descr);

            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStatus);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Contract Type Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_PunchList_Status.SelectAll();
        //Apply Dataset to Grid
        gvPunchListStatus.DataSource = dsGroup;
        gvPunchListStatus.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_PunchList_Status = 0;
    }

    #endregion
}