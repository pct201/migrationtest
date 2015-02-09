using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;

/************************************************************************************************************************************
 * File Name      :	PromoteCauseCode.aspx
 *
 * Description    :	This screen will allow the user to adjust any of the charges, and provide explanation, 
 *                  recording the user login that adjusted the charges; and write same to the database on save.  
 *                  Once the charge is adjusted, it cannot be adjusted again. Track this using the change field
 *
 *************************************************************************************************************************************/


public partial class Administrator_WC_AllocationCharges_ByMarket : clsBasePage
{
    #region "Property"

    /// <summary>
    /// PK for WC_Allocation_Charges Table
    /// </summary>
    public decimal PK_WC_Allocation_Charges_ByMarket
    {
        get
        {
            return (!clsGeneral.IsNull(ViewState["id"]) ? Convert.ToDecimal(ViewState["id"]) : -1);
        }
        set { ViewState["id"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if parameter ID and Mode is passed in query string and Mode is eighter Edit ro View
            // if any parameter is missing then redirect to search page

            if (clsSession.FK_WC_FR_ID > 0)
            {
                // check if parameter mode and id is passed or not
                if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request.QueryString["mode"]) && (Request.QueryString["mode"] == "edit" || Request.QueryString["mode"] == "view"))
                {
                    decimal _decId = -1;

                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out _decId))
                    {
                        PK_WC_Allocation_Charges_ByMarket = _decId;

                        // set page in edit or view as per parameter pass
                        if (Request.QueryString["mode"] == "edit")
                            LoadRecordByID();
                        else
                            ViewRecordByID();
                    }
                    else
                        Response.Redirect("AdjustPastCharge_ByMarket.aspx");
                }
                else
                    AddRecord();
            }
            else
                Response.Redirect("AdjustPastCharge_ByMarket.aspx");
        }
    }

    #region "Events"
    /// <summary>
    /// Save Button click event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        //Response.Redirect("AdjustPastCharge.aspx");
        Response.Redirect("WC_AllocationCharges_ByMarket.aspx?mode=view&id=" + Encryption.Encrypt(PK_WC_Allocation_Charges_ByMarket.ToString()));
    }

    /// <summary>
    /// back Button click event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBackSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdjustPastCharge_ByMarket.aspx");
    }

    /// <summary>
    /// back Button click event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdjustPastCharge_ByMarket.aspx?mode=result");
    }

    /// <summary>
    /// Edit Button click event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("WC_AllocationCharges_ByMarket.aspx?mode=edit&id=" + Encryption.Encrypt(PK_WC_Allocation_Charges_ByMarket.ToString()));
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// this function is used to Save record to WC Allocation Chages Table
    /// </summary>
    private void SaveRecord()
    {
        // assign values to object 
        WC_Allocation_Charges_ByMarket objAllocation = new WC_Allocation_Charges_ByMarket(PK_WC_Allocation_Charges_ByMarket);

        if (txtCharge.Text.Trim() != "")
            objAllocation.Charge = Convert.ToDecimal(txtCharge.Text.Replace(",", "").Trim());

        objAllocation.Change_login = clsSession.UserID;
        objAllocation.Change_Explanation = txtChange_Explanation.Text.Trim();

        if (PK_WC_Allocation_Charges_ByMarket <= 0)
        {
            objAllocation.FK_WC_FR_ID = clsSession.FK_WC_FR_ID;
            objAllocation.Charge_Type = ddlChargeType.SelectedItem.Text.Trim();
            objAllocation.Changed = false;
            objAllocation.ChargeDate = clsGeneral.FormatDateToStore(txtChargeDate.Text);
            PK_WC_Allocation_Charges_ByMarket = objAllocation.Insert();
        }
        else
        {
            objAllocation.Changed = true;
            // update record
            objAllocation.Update();
        }
    }

    /// <summary>
    /// this function is used when page in edit mode.
    /// </summary>
    private void LoadRecordByID()
    {
        WC_Allocation_Charges_ByMarket objAllocation = new WC_Allocation_Charges_ByMarket(PK_WC_Allocation_Charges_ByMarket);
        // check if record is edit previously then only view record 
        //if (objAllocation.Changed == false)
        //{
        // Hide view panel and show edit Panel
        pnlEditWC_Allocation.Visible = true;
        pnlViewWC_Allocation.Visible = false;
        lblFirstReportNumber.Text = new WC_FR((decimal)objAllocation.FK_WC_FR_ID).WC_FR_Number.ToString();
        lblChargeType.Text = objAllocation.Charge_Type.ToString();
        lblChargeDate.Text = clsGeneral.FormatDBNullDateToDisplay(objAllocation.ChargeDate);
        txtChange_Explanation.Text = objAllocation.Change_Explanation;
        txtCharge.Focus();
        //show User Name from Security Table
        lblChange_login.Text = (new Security(Convert.ToDecimal(objAllocation.Change_login)).USER_NAME);

        if (objAllocation.Charge != null)
            txtCharge.Text = string.Format("{0:N2}", objAllocation.Charge);
        else
            txtCharge.Text = "";

        ddlChargeType.Visible = false;
        lblChargeType.Visible = true;
        //}
        //else
        //    ViewRecordByID();
    }

    /// <summary>
    /// this function is used when page in view mode.
    /// </summary>
    private void ViewRecordByID()
    {
        // Load value in object
        WC_Allocation_Charges_ByMarket objAllocation = new WC_Allocation_Charges_ByMarket(PK_WC_Allocation_Charges_ByMarket);

        // Hide edit panel and show View Panel
        pnlEditWC_Allocation.Visible = false;
        pnlViewWC_Allocation.Visible = true;

        // assign value to lable
        lblvFirstReportNumber.Text = new WC_FR((decimal)objAllocation.FK_WC_FR_ID).WC_FR_Number.ToString();
        lblvChargeType.Text = objAllocation.Charge_Type.ToString();
        lblvChargeDate.Text = clsGeneral.FormatDBNullDateToDisplay(objAllocation.ChargeDate);
        lblChange_Explanation.Text = objAllocation.Change_Explanation;
        lblvChange_login.Text = objAllocation.Change_login;
        btnEdit.Visible = objAllocation.Changed;
        // show User Name from Security Table
        lblvChange_login.Text = (new Security(Convert.ToDecimal(objAllocation.Change_login)).USER_NAME);

        if (objAllocation.Charge != null)
            lblvCharge.Text = string.Format("{0:c}", objAllocation.Charge);
        else
            lblvCharge.Text = "";

    }

    /// <summary>
    /// Bind control for add Mode
    /// </summary>
    private void AddRecord()
    {
        lblFirstReportNumber.Text = new WC_FR(clsSession.FK_WC_FR_ID).WC_FR_Number.ToString();
        ddlChargeType.Focus();
        btnAudit.Visible = false;
        ddlChargeType.Visible = true;
        lblChargeType.Visible = false;
        pnlViewWC_Allocation.Visible = false;
        pnlChargeDate.Visible = true;
        lblChargeDate.Visible = false;
    }

    #endregion
}
