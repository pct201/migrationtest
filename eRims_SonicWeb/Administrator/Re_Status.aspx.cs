using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;

/************************************************************************************************************************************
 * 
 * Developer Name : Ravi Patel
 * 
 * File Name      :	Re_Status.aspx
 *
 * Description    :	This page provide facility to Add-Edit Re_Status Look-up Table.
 *
 *************************************************************************************************************************************/

public partial class Administrator_Re_Status : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Status
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Status"]);
        }
        set { ViewState["PK_LU_Status"] = value; }
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

    #region "Grid Event"

    /// <summary>
    /// Manufacturer row command event in edit,view or remove mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Status = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Status objStatus = new LU_Status(PK_LU_Status);
            txtStatus.Text = objStatus.Fld_Desc.ToString();
            if (objStatus.Active != null)
                rdblActive.SelectedValue = objStatus.Active;
            else
                rdblActive.SelectedIndex = 0;
            // set focus to control
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStatus);
        }
    }

    /// <summary>
    /// Page index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Page new index call
        gvStatus.PageIndex = e.NewPageIndex;
        //Bind Grid Function
        BindGrid(); 
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
        PK_LU_Status = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtStatus.Text = "";
        rdblActive.SelectedValue = "Y";
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
        LU_Status objStatus = new LU_Status();
        objStatus.Fld_Desc = txtStatus.Text.Trim();
        objStatus.PK_LU_Status = PK_LU_Status;
        objStatus.Active = rdblActive.SelectedValue;

        if (PK_LU_Status > 0)
        {
            _retVal = objStatus.Update();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Status that you are trying to add already exists in the Status table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStatus);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objStatus.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Status that you are trying to add already exists in the Status table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStatus);
                return;
            }
            PK_LU_Status = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Manufacturer Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Status.SelectAll();
        //Apply Dataset to Grid
        gvStatus.DataSource = dsGroup;
        gvStatus.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Status = 0;
    }
    #endregion
}
