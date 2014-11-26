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
 * File Name      :	SecurityDeposit.aspx
 *
 * Description    :	This page provide facility to Add-Edit Security Deposit Held At Look-up Table.
 *
 *************************************************************************************************************************************/
public partial class Administrator_SecurityDeposit : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Security_Deposit_Held
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Security_Deposit_Held"]);
        }
        set { ViewState["PK_LU_Security_Deposit_Held"] = value; }
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
    protected void gvSecurityDeposit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Security_Deposit_Held = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trSecurityDepositAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Security_Deposit_Held objHeld = new LU_Security_Deposit_Held(PK_LU_Security_Deposit_Held);
            txtSecurityDeposit.Text = objHeld.Fld_Desc.ToString();

            // Check Active flag 
            if (objHeld.Active != null)
                rdblActive.SelectedValue = objHeld.Active;
            else
                rdblActive.SelectedIndex = 0;
            // set focus on first datacontrol of screen
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSecurityDeposit);
        }
    }

    /// <summary>
    /// Page index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSecurityDeposit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSecurityDeposit.PageIndex = e.NewPageIndex; //Page new index call
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
        // set control For Add Mode
        btnAdd.Text = "Add";
        PK_LU_Security_Deposit_Held = 0;
        trSecurityDepositAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        // clear control
        txtSecurityDeposit.Text = "";
        rdblActive.SelectedValue = "Y";
        // set focus on first datacontrol of screen
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSecurityDeposit);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        // Hide edit-add controls
        trSecurityDepositAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        // clear control
        txtSecurityDeposit.Text = "";
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
        LU_Security_Deposit_Held objSecurity_Deposit = new LU_Security_Deposit_Held();
        objSecurity_Deposit.Fld_Desc = txtSecurityDeposit.Text.Trim();
        objSecurity_Deposit.Active = rdblActive.SelectedValue;

        objSecurity_Deposit.PK_LU_Security_Deposit_Held = PK_LU_Security_Deposit_Held;

        // Check if record in edit or add new record
        if (PK_LU_Security_Deposit_Held > 0)
        {
            // update record
            _retVal = objSecurity_Deposit.Update();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Security Deposit Held that you are trying to add already exists in the Security Deposit Held table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSecurityDeposit);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            // insert record
            _retVal = objSecurity_Deposit.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Security Deposit Held that you are trying to add already exists in the Security Deposit Held table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSecurityDeposit);
                return;
            }
            PK_LU_Security_Deposit_Held = _retVal;
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
        DataSet dsGroup = LU_Security_Deposit_Held.SelectAll();
        //Apply Dataset to Grid
        gvSecurityDeposit.DataSource = dsGroup;
        gvSecurityDeposit.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Security_Deposit_Held = 0;
    }
    #endregion
}
