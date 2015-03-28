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

/// <summary>
/// Date : 23 OCT 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To save or view the contact details for a Building information for property
/// 
/// Functionality:
/// Displays information in Edit mode when any contact record in edit mode is selected on property page
/// Gets information from page controls when page is in edit or add mode
/// Displays information in View mode when any contact record in view mode is selected on property page
/// </summary>
public partial class SONIC_Exposures_PropertyContactDetails : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Denotes PK for Contact information
    /// </summary>
    private int PK_Property_Contact_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Proeprty_Contact_ID"]); }
        set { ViewState["PK_Proeprty_Contact_ID"] = value; }
    }

    /// <summary>
    /// Denotes FK for Building information
    /// </summary>
    private int FK_Building_ID
    {
        get { return Convert.ToInt32(ViewState["FK_Building_ID"]); }
        set { ViewState["FK_Building_ID"] = value; }
    }

    /// <summary>
    /// Denotes operation either edit or view for the page
    /// </summary>
    private string strOperation
    {
        get
        {
            if (Request.QueryString["op"] != null)
                return Convert.ToString(Request.QueryString["op"]);
            else
                return "";
        }
    }

    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // set PK and FK for the record
            PK_Property_Contact_ID = Convert.ToInt32(Request.QueryString["PK"]);
            FK_Building_ID = Convert.ToInt32(Request.QueryString["FK"]);

            // if operation (edit or view) is available
            if (strOperation != "")
            {
                // set page in edit or view mode depending on the operation passed
                if (strOperation == "view")
                    BindDetailsForView();
                else
                {
                    SetValidationsContact();
                    BindDetailsForEdit();
                }
            }
            else
            {
                SetValidationsContact();
                dvEdit.Style["display"] = "block";
                ComboHelper.FillPropertyContactType(new DropDownList[] {drpType }, true);
            }
        }

        drpType.Attributes.Add("onchange", "javascript:CheckContactType(this.value,'" + trOtherContactType.ClientID + "','" + revOtherType.ClientID + "');");
    }
    #endregion

    #region "Control Events"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (drpType.SelectedIndex > 0)
        {
            // get the type of the contact selected
            string strType = drpType.SelectedItem.Text == "Other Contact" ? txtType.Text.Trim() : drpType.SelectedItem.Text;

            // if the contact is already available then show error message
            // else save the information
            if (!Property_Contact.IsDuplicateType(PK_Property_Contact_ID, FK_Building_ID, strType))
            {
                // create object for the contact
                Property_Contact objContact = new Property_Contact();

                // get values from page controls
                objContact.PK_Property_Contact_ID = PK_Property_Contact_ID;
                objContact.FK_Building_ID = FK_Building_ID;
                objContact.Type = strType;
                objContact.Name = txtContactName.Text.Trim();
                objContact.Phone = txtPhone.Text.Trim();
                objContact.Organization = txtOrganization.Text.Trim();
                objContact.email = txtEmail.Text.Trim();
                objContact.Updated_By = Convert.ToDecimal(clsSession.UserID);
                objContact.Updated_Date = DateTime.Now;

                // insert or update the record depending on the PK available
                if (PK_Property_Contact_ID > 0)
                    objContact.Update();
                else
                    objContact.Insert();

                ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "CloseWindow();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "alert('Contact Type Already Exists');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "alert('Please select proper Contact Type');", true);
        }
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Binds details for edit 
    /// </summary>
    private void BindDetailsForEdit()
    {
        ComboHelper.FillPropertyContactType(new DropDownList[] { drpType }, true);

        // create object for property contact
        Property_Contact objContact = new Property_Contact(PK_Property_Contact_ID);

        // set values in page controls
        if (drpType.Items.FindByText(objContact.Type) == null)
            drpType.Items[drpType.Items.Count - 1].Selected = true;
        else
            drpType.Items.FindByText(objContact.Type).Selected = true;

        if (drpType.SelectedItem.Text == "Other Contact")
        {
            txtType.Text = objContact.Type;
            trOtherContactType.Style["display"] = "block";
        }
        txtContactName.Text = objContact.Name;
        txtPhone.Text = objContact.Phone;
        txtOrganization.Text = objContact.Organization;
        txtEmail.Text = objContact.email;
        dvEdit.Style["display"] = "block";
    }

    /// <summary>
    /// Binds details for view
    /// </summary>
    private void BindDetailsForView()
    {
        // create object for property contact
        Property_Contact objContact = new Property_Contact(PK_Property_Contact_ID);

        // set values in page controls
        lblType.Text = objContact.Type;
        lblContactName.Text = objContact.Name;
        lblPhone.Text = objContact.Phone;
        lblOrganization.Text = objContact.Organization;
        lblEmail.Text = objContact.email;
        dvView.Style["display"] = "block";
    }

    /// <summary>
    /// Set all Validations-Ownership Details
    /// </summary>
    private void SetValidationsContact()
    {
        string strCtrlsIDsContact = "";
        string strMessagesContact = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(57).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Property Contact - Type": strCtrlsIDsContact += drpType.ClientID + ","; strMessagesContact += "Please select Property Contact - Type" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Property Contact - Organization": strCtrlsIDsContact += txtOrganization.ClientID + ","; strMessagesContact += "Please enter Property Contact - Organization" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Property Contact - Contact Name": strCtrlsIDsContact += txtContactName.ClientID + ","; strMessagesContact += "Please enter Property Contact - Contact Name" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Property Contact - Phone": strCtrlsIDsContact += txtPhone.ClientID + ","; strMessagesContact += "Please enter Property Contact - Phone" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Property Contact - Email": strCtrlsIDsContact += txtEmail.ClientID + ","; strMessagesContact += "Please enter Property Contact - Email" + ","; Span5.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsContact = strCtrlsIDsContact.TrimEnd(',');
        strMessagesContact = strMessagesContact.TrimEnd(',');

        hdnControlIDsContact.Value = strCtrlsIDsContact;
        hdnErrorMsgsContact.Value = strMessagesContact;
    }

    #endregion
}
