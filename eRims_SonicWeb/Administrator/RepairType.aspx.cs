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
 * File Name      :	RepairType.aspx
 *
 * Description    :	This page provide facility to Add-Edit Repair Type Look-up Table.
 *
 *************************************************************************************************************************************/

public partial class Administrator_RepairType : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Repair_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Repair_Type"]);
        }
        set { ViewState["PK_LU_Repair_Type"] = value; }
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
    protected void gvRepairType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Repair_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trRepairTypeAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Repair_Type objHeld = new LU_Repair_Type(PK_LU_Repair_Type);
            txtRepairType.Text = objHeld.Fld_Desc.ToString();
            
            // check Active Flag for record
            if (objHeld.Active != null)
                rdblActive.SelectedValue = objHeld.Active;
            else
                rdblActive.SelectedIndex = 0;

            // set focus on first datacontrol of screen
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtRepairType);
        }
    }

    /// <summary>
    /// Page index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRepairType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRepairType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid(); //Bind Grid Function
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
        // set control for Add mode
        btnAdd.Text = "Add";
        PK_LU_Repair_Type = 0;
        trRepairTypeAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        //clears control
        txtRepairType.Text = "";
        rdblActive.SelectedValue = "Y";
        // set focus on first datacontrol of screen
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtRepairType);

    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        // set controls for edit mode
        trRepairTypeAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        //clear controls
        txtRepairType.Text = "";
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
        LU_Repair_Type objRepair_Type = new LU_Repair_Type();
        objRepair_Type.Fld_Desc = txtRepairType.Text.Trim();
        objRepair_Type.PK_LU_Repair_Type = PK_LU_Repair_Type;
        objRepair_Type.Active = rdblActive.SelectedValue;

        // check if record is editing or add new records
        if (PK_LU_Repair_Type > 0)
        {
            // Update record
            _retVal = objRepair_Type.Update();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Repair Type that you are trying to add already exists in the Repair Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtRepairType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            // insert record
            _retVal = objRepair_Type.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Repair Type that you are trying to add already exists in the Repair Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtRepairType);
                return;
            }
            PK_LU_Repair_Type = _retVal;
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
        DataSet dsGroup = LU_Repair_Type.SelectAll();
        //Apply Dataset to Grid
        gvRepairType.DataSource = dsGroup;
        gvRepairType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Repair_Type = 0;
    }
    #endregion
}
