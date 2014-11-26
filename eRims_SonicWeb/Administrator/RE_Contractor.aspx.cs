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
 * Description    :	This screen is used for Add-edit contractor loop Up. 
 *                  To edit Controactor, User first select Contractor from Drop down.
 *
 *************************************************************************************************************************************/

public partial class Administrator_RE_Contractor : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// set Primary Key for RE_Contract
    /// </summary>
    public decimal Pk_Contractor
    {
        get { return clsGeneral.IsNull(ViewState["Pk_Contractor"]) ? -1 : Convert.ToDecimal(ViewState["Pk_Contractor"]); }
        set { ViewState["Pk_Contractor"] = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // check if parameter is passed or not 
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]))
            {
                // Check if page mode is Add or edit
                if (Request.QueryString["mode"].ToString().ToUpper() == "ADD")
                    // Bind contrl for Add
                    BindControlForAdd();
                else
                    // Bind contrl for edit
                    BindControlForEdit();
            }
            else
            {
                // Bind contrl for edit
                BindControlForEdit();
            }
        }
    }

    #region "Events"
    /// <summary>
    /// Handle Next Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        // Bind control for add
        BindControlForAdd();        
        // set pK for contractor
        Pk_Contractor = Convert.ToDecimal(ddlContractor.SelectedValue);

        // get RE_Controactor records
        RE_Contractor objContract = new RE_Contractor(Pk_Contractor);

        // set value from database
        txtCompany.Text = objContract.Contractor_Company.Trim();
        txtContact.Text = string.IsNullOrEmpty(objContract.Contractor_Contact) ? string.Empty : objContract.Contractor_Contact.Trim();
        txtAddress1.Text = string.IsNullOrEmpty(objContract.Contractor_Address1) ? string.Empty : objContract.Contractor_Address1.Trim();
        txtAddress2.Text = string.IsNullOrEmpty(objContract.Contractor_Address2) ? string.Empty : objContract.Contractor_Address2.Trim();
        txtCity.Text = string.IsNullOrEmpty(objContract.Contractor_City) ? string.Empty : objContract.Contractor_City.Trim();
        txtEmail.Text = string.IsNullOrEmpty(objContract.Contractor_Email) ? string.Empty : objContract.Contractor_Email.Trim();
        
        // check record is active or Not
        if (objContract.Active != null)
            rdblActive.SelectedValue = objContract.Active;
        else
            rdblActive.SelectedValue = "Y";
        txtFacsimile.Text = string.IsNullOrEmpty(objContract.Contractor_Facsimile) ? string.Empty : objContract.Contractor_Facsimile.ToString();
        txtTelephone.Text = string.IsNullOrEmpty(objContract.Contractor_Telephone) ? string.Empty : objContract.Contractor_Telephone.Trim();
        txtZipCode.Text = string.IsNullOrEmpty(objContract.Contractor_Zip_Code) ? string.Empty : objContract.Contractor_Zip_Code.Trim();
        if (objContract.FK_State_Contractor != null)
            ddlState.Items.FindByValue(objContract.FK_State_Contractor.ToString()).Selected = true;

    }

    /// <summary>
    /// Handle Add New button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        BindControlForAdd();
    }

    /// <summary>
    /// Handle Save button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // create RE_Contractor Object
        RE_Contractor objContractor = new RE_Contractor();

        // set value
        objContractor.Contractor_Company = txtCompany.Text.Trim();
        objContractor.Contractor_Contact = txtContact.Text.Trim();
        objContractor.Contractor_Contact = txtContact.Text.Trim();
        objContractor.Contractor_Email = txtEmail.Text.Trim();
        objContractor.Contractor_Facsimile = txtFacsimile.Text.Trim();
        objContractor.Contractor_Telephone = txtTelephone.Text.Trim();
        objContractor.Contractor_Zip_Code = txtZipCode.Text.Trim();
        objContractor.Contractor_Address1 = txtAddress1.Text.Trim();
        objContractor.Contractor_Address2 = txtAddress2.Text.Trim();
        objContractor.Contractor_City = txtCity.Text.Trim();
        objContractor.Active = rdblActive.SelectedValue;
        if (ddlState.SelectedIndex > 0)
            objContractor.FK_State_Contractor = Convert.ToDecimal(ddlState.SelectedValue);

        // check if Pk_Contractor is exist or not
        if (Pk_Contractor > 0)
        {
            objContractor.PK_RE_Contractor = Pk_Contractor;
            objContractor.Update();
        }
        else
            Pk_Contractor = objContractor.Insert();

        // bind control for edit
        BindControlForEdit();
    }

    /// <summary>
    /// Handle Cancel Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RE_Contractor.aspx");
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Fill contractor drop down 
    /// </summary>
    private void FillContractor()
    {
        DataSet ds = new DataSet();
        ds = RE_Contractor.SelectAllContractor();
        ddlContractor.DataSource = ds;
        ddlContractor.DataTextField = "Contractor";
        ddlContractor.DataValueField = "PK_RE_Contractor";
        ddlContractor.DataBind();
        ddlContractor.Items.Insert(0, new ListItem("--- Select ---", "0"));

        clsGeneral.DisposeOf(ds);

    }

    /// <summary>
    /// Bind control for Edit mode
    /// </summary>
    private void BindControlForEdit()
    {
        // Show Edit control panel
        pnlAddEdit.Visible = false;
        pnlContractor.Visible = true;
        ddlContractor.Focus();
        // Fill Contractor Drop down
        FillContractor();
        lblPageHeader.Text = "Administrator :: Contractor Select";
    }

    /// <summary>
    /// Bind Control for Add Mode
    /// </summary>
    private void BindControlForAdd()
    {
        // set controls for Add Mode
        ComboHelper.FillState(new DropDownList[] { ddlState }, 0, true);        
        pnlAddEdit.Visible = true;
        pnlContractor.Visible = false;
        // set focus
        txtCompany.Focus();
        lblPageHeader.Text = "Administrator :: Contractor";
    }

    #endregion
}
