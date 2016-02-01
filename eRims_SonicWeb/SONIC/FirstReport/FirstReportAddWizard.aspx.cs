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
/// Date           : 21-07-08
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : Used to Create New First Report Wizard.here user have to select a First Report Type that
///                  wnat to add in new created wizard.
/// 
/// </summary>
public partial class SONIC_FirstReportAddWizard : clsBasePage
{
    private string AllowTab = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Module_Access_Mode == AccessType.View_Only)
        //if (UserAccessType == AccessType.View_Only)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
        }
        if (!IsPostBack)
        {
            //set onclick event for Radio button selected change
            rdoInvolve_Vehicle.Attributes.Add("onclick", "ChangeVehicleValue()");
            //fill Sonic Location Number
            ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true);
            //Fill Location dba Dropdown
            ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocationdba }, 0, true);
            //Fill Location Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
            //Fill Location FKA Dropdown
            ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
            //Fill NameDropdown
            //ComboHelper.FillAssociateName(new DropDownList[] { ddlName }, 0, true);
        }
    }
    /// <summary>
    /// Continue Click.Added New FIrst Report wizard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnContiune_Click(object sender, EventArgs e)
    {
        int PK_First_Report_Wizard_ID = 0;
        //Create Object
        First_Report_Wizard objFRW = new First_Report_Wizard();
        objFRW.FK_Location_ID = (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0;
        objFRW.FK_Employee_ID = (ddlName.SelectedIndex > 0) ? Convert.ToInt32(ddlName.SelectedValue) : 0;
        objFRW.TelephoneNumber1 = txtTelephoneNumber1.Text.ToString();
        objFRW.TelephoneNumber2 = txtTelephoneNumber2.Text.ToString();
        objFRW.TelephoneNumber1 = txtTelephoneNumber1.Text.ToString();
        objFRW.Email = txtEmailAddress.Text.Trim();
        //check selected value if it is "Y" than set related object value to true. and add 1 to allow tab value.
        if (rdoInjured_Employee.SelectedValue == "Y")
        {
            objFRW.Injured_Employee = true;
            AllowTab += "1";
        }
        else
        {
            objFRW.Injured_Employee = false;
        }
        objFRW.Injured_Employee = (rdoInjured_Employee.SelectedValue == "Y") ? true : false;
        //check selected value if it is "Y" than set related object value to true. and add 3 to allow tab value.
        if (chkInventoried_Vehicle.Checked == true)
        {
            objFRW.Inventoried_Vehicle = true;
            if (AllowTab != string.Empty)
                AllowTab += ",3";
            else
                AllowTab += "3";
        }
        else
        {
            objFRW.Inventoried_Vehicle = false;
        }
        //check selected value if it is "Y" than set related object value to true. and add 2 to allow tab value.
        if (chkCustomer_Vehicle.Checked == true)
        {
            objFRW.Customer_Vehicle = true;
            if (AllowTab != string.Empty)
                AllowTab += ",2";
            else
                AllowTab += "2";
        }
        else
        {
            objFRW.Customer_Vehicle = false;
        }
        //check selected value if it is "Y" than set related object value to true. and add 2 to allow tab value.
        if (chkOther_Vehicle.Checked == true)
        {
            objFRW.Other_Vehicle = true;
            if (AllowTab != string.Empty)
                AllowTab += ",2";
            else
                AllowTab += "2";
        }
        else
        {
            objFRW.Other_Vehicle = false;
        }
        //objFRW.Other_Vehicle = (chkOther_Vehicle.Checked == true) ? true : false;
        //check selected value if it is "Y" than set related object value to true. and add 5 to allow tab value.
        if (rdoGeneral_Claim.SelectedValue == "Y")
        {
            objFRW.General_Claim = true;
            if (AllowTab != string.Empty)
                AllowTab += ",5";
            else
                AllowTab += "5";
        }
        else
        {
            objFRW.General_Claim = false;
        }
        //check selected value if it is "Y" than set related object value to true. and add 4 to allow tab value.
        if (rdoProperty_Claim.SelectedValue == "Y")
        {
            objFRW.Property_Claim = true;
            if (AllowTab != string.Empty)
                AllowTab += ",4";
            else
                AllowTab += "4";
        }
        else
        {
            objFRW.Property_Claim = false;
        }
        //objFRW.Contact_Fax = txtFaxNumber.Text;
        clsSession.AllowedTab = AllowTab;
        PK_First_Report_Wizard_ID = objFRW.Insert();
        clsSession.First_Report_Wizard_ID = PK_First_Report_Wizard_ID;
        Response.Redirect("FirstReportStatus.aspx", true);
    }

    #region Dropdown's Selcted Value change Events

    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRMLocationNumber.SelectedIndex > 0)
        {
            //// fill Location dba DropDown
            //ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0, true);
            ////fill Location Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0, true);
            ////fill Location FKA dropdown
            //ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0, true);
            ////Fill All Information From Location Table
            //UpdateLocationInformation();
            ////used to get default situation of step 3
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeVehicleValue();", true);
            //////fill Associate Information Dropdown
            ////ComboHelper.FillAssociateByContact(new DropDownList[] { ddlName }, true, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0);
            //////call ddlname selected index change
            ////ddlName_SelectedIndexChanged(null, null);
            //ddlLegalEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
            ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;
            ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlRMLocationNumber.SelectedValue);
            if (lstItm != null)
                ddlLocationfka.SelectedValue = ddlRMLocationNumber.SelectedValue;
            else
                ddlLocationfka.SelectedValue = "0";
            //fill Associate Information Dropdown
            //string[] strCostCenter = ddlRMLocationNumber.SelectedItem.ToString().Split(Convert.ToChar("."));
            LU_Location lu = new LU_Location(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
            int Sonic_Location_Code = Convert.ToInt32(lu.Sonic_Location_Code);

            ComboHelper.FillAssociateByContact(new DropDownList[] { ddlName }, true, (ddlRMLocationNumber.SelectedIndex > 0) ? Sonic_Location_Code : 0);
            UpdateLocationInformation();
            //call ddlname selected index change
            ddlName_SelectedIndexChanged(null, null);
        }
        else
        {
            ddlLocationdba.SelectedValue = "0";
            //ddlLegalEntity.SelectedValue = "0";
            ddlLocationfka.SelectedValue = "0";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipcode.Text = "";
            //clear step 2 information
            ddlName.Items.Clear();
            txtTitle.Text = "";
            txtTelephoneNumber1.Text = "";
            txtTelephoneNumber2.Text = "";
            txtEmailAddress.Text = "";
        }
    }
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocationdba.SelectedIndex > 0)
        {
            ////fill Sonic Location Number Dropdown
            //ComboHelper.FillSonicLocationNumber(new DropDownList[] { ddlRMLocationNumber }, (ddlLocationdba.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationdba.SelectedValue) : 0, true);
            ////fill Location Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, (ddlLocationdba.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationdba.SelectedValue) : 0, true);
            ////fill Location FKA dropdown
            //ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (ddlLocationdba.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationdba.SelectedValue) : 0, true);
            ////Fill All Information From Location Table
            //UpdateLocationInformation();
            ////used to get default situation of step 3
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeVehicleValue();", true);
            //////fill Associate Information Dropdown
            ////ComboHelper.FillAssociateByContact(new DropDownList[] { ddlName }, true, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0);
            //////call ddlname selected index change
            ////ddlName_SelectedIndexChanged(null, null);
            ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
            //ddlLegalEntity.SelectedValue = ddlLocationdba.SelectedValue;

            ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLocationdba.SelectedValue);
            if (lstItm != null)
                ddlLocationfka.SelectedValue = ddlLocationdba.SelectedValue;
            else
                ddlLocationfka.SelectedValue = "0";
            //fill Associate Information Dropdown
            //string[] strCostCenter = ddlRMLocationNumber.SelectedItem.ToString().Split(Convert.ToChar("."));
            LU_Location lu = new LU_Location(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
            int Sonic_Location_Code = Convert.ToInt32(lu.Sonic_Location_Code);

            ComboHelper.FillAssociateByContact(new DropDownList[] { ddlName }, true, (ddlRMLocationNumber.SelectedIndex > 0) ? Sonic_Location_Code : 0);
            UpdateLocationInformation();
            //call ddlname selected index change
            ddlName_SelectedIndexChanged(null, null);
        }
        else
        {
            ddlRMLocationNumber.SelectedValue = "0";
            //ddlLegalEntity.SelectedValue = "0";
            ddlLocationfka.SelectedValue = "0";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipcode.Text = "";
            //clear step 2 information
            ddlName.Items.Clear();
            txtTitle.Text = "";
            txtTelephoneNumber1.Text = "";
            txtTelephoneNumber2.Text = "";
            txtEmailAddress.Text = "";
        }
    }
    //protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlLegalEntity.SelectedIndex > 0)
    //    {
    //        //// fill Location dba DropDown
    //        //ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, (ddlLegalEntity.SelectedIndex > 0) ? Convert.ToInt32(ddlLegalEntity.SelectedValue) : 0, true);
    //        ////fill Sonic Location Number Dropdown
    //        //ComboHelper.FillSonicLocationNumber(new DropDownList[] { ddlRMLocationNumber }, (ddlLegalEntity.SelectedIndex > 0) ? Convert.ToInt32(ddlLegalEntity.SelectedValue) : 0, true);
    //        ////fill Location FKA dropdown
    //        //ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (ddlLegalEntity.SelectedIndex > 0) ? Convert.ToInt32(ddlLegalEntity.SelectedValue) : 0, true);
    //        ////Fill All Information From Location Table
    //        //UpdateLocationInformation();
    //        ////used to get default situation of step 3
    //        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeVehicleValue();", true);
    //        //////fill Associate Information Dropdown
    //        ////ComboHelper.FillAssociateByContact(new DropDownList[] { ddlName }, true, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0);
    //        //////call ddlname selected index change
    //        ////ddlName_SelectedIndexChanged(null, null);
    //        ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
    //        ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;
    //        ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLegalEntity.SelectedValue);
    //        if (lstItm != null)
    //            ddlLocationfka.SelectedValue = ddlLegalEntity.SelectedValue;
    //        else
    //            ddlLocationfka.SelectedValue = "0";
    //        //fill Associate Information Dropdown
    //        //string[] strCostCenter = ddlRMLocationNumber.SelectedItem.ToString().Split(Convert.ToChar("."));
    //        LU_Location lu = new LU_Location(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
    //        int Sonic_Location_Code = Convert.ToInt32(lu.Sonic_Location_Code);
    //        ComboHelper.FillAssociateByContact(new DropDownList[] { ddlName }, true, (ddlRMLocationNumber.SelectedIndex > 0) ? Sonic_Location_Code : 0);
    //        UpdateLocationInformation();
    //        //call ddlname selected index change
    //        ddlName_SelectedIndexChanged(null, null);
    //    }
    //    else
    //    {
    //        ddlRMLocationNumber.SelectedValue = "0";
    //        ddlLocationdba.SelectedValue = "0";
    //        ddlLocationfka.SelectedValue = "0";
    //        txtAddress1.Text = "";
    //        txtAddress2.Text = "";
    //        txtCity.Text = "";
    //        txtState.Text = "";
    //        txtZipcode.Text = "";
    //        //clear step 2 information
    //        ddlName.Items.Clear();
    //        txtTitle.Text = "";
    //        txtTelephoneNumber1.Text = "";
    //        txtTelephoneNumber2.Text = "";
    //        txtEmailAddress.Text = "";
    //    }
    //}
    protected void ddlLocationfka_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocationfka.SelectedIndex > 0)
        {
            //// fill Location dba DropDown
            //ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, (ddlLocationfka.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationfka.SelectedValue) : 0, true);
            ////fill Location Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, (ddlLocationfka.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationfka.SelectedValue) : 0, true);
            ////fill Sonic Location Number Dropdown
            //ComboHelper.FillSonicLocationNumber(new DropDownList[] { ddlRMLocationNumber }, (ddlLocationfka.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationfka.SelectedValue) : 0, true);
            ////Fill All Information From Location Table
            //UpdateLocationInformation();
            ////used to get default situation of step 3
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeVehicleValue();", true);
            //////fill Associate Information Dropdown
            ////ComboHelper.FillAssociateByContact(new DropDownList[] { ddlName }, true, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0);
            //////call ddlname selected index change
            ////ddlName_SelectedIndexChanged(null, null);
            ddlRMLocationNumber.SelectedValue = ddlLocationfka.SelectedValue;
            //ddlLegalEntity.SelectedValue = ddlLocationfka.SelectedValue;
            ddlLocationdba.SelectedValue = ddlLocationfka.SelectedValue;
            //fill Associate Information Dropdown
            //string[] strCostCenter = ddlRMLocationNumber.SelectedItem.ToString().Split(Convert.ToChar("."));
            LU_Location lu = new LU_Location(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
            int Sonic_Location_Code = Convert.ToInt32(lu.Sonic_Location_Code);

            ComboHelper.FillAssociateByContact(new DropDownList[] { ddlName }, true, (ddlRMLocationNumber.SelectedIndex > 0) ? Sonic_Location_Code : 0);
            UpdateLocationInformation();
            //call ddlname selected index change
            ddlName_SelectedIndexChanged(null, null);
        }
        else
        {
            ddlRMLocationNumber.SelectedValue = "0";
            ddlLocationdba.SelectedValue = "0";
            //ddlLegalEntity.SelectedValue = "0";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipcode.Text = "";
            //clear step 2 information
            ddlName.Items.Clear();
            txtTitle.Text = "";
            txtTelephoneNumber1.Text = "";
            txtTelephoneNumber2.Text = "";
            txtEmailAddress.Text = "";
        }
    }
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlName.SelectedIndex > 0)
        {
            // Fill Controls From Employee Table
            UpdateEmployeeInformation();
            //used to get default situation of step 3
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeVehicleValue();", true);
        }
        else
        {
            txtTitle.Text = "";
            txtTelephoneNumber1.Text = "";
            txtTelephoneNumber2.Text = "";
            txtEmailAddress.Text = "";
        }
    }
    #endregion

    #region Methods
    //Used to Update Location Information as Per RM NUmber,Legal Entity,Location d/b/a,Location f/k/a selction
    private void UpdateLocationInformation()
    {
        LU_Location objLocaiton = new LU_Location(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
        txtAddress1.Text = objLocaiton.Address_1;
        txtAddress2.Text = objLocaiton.Address_2;
        txtCity.Text = objLocaiton.City;
        txtState.Text = new State(string.IsNullOrEmpty(objLocaiton.State) ? 0 : Convert.ToDecimal(objLocaiton.State)).FLD_state;
        txtZipcode.Text = objLocaiton.Zip_Code;
    }

    //Used to Fill Employee Information as Employee Selected
    private void UpdateEmployeeInformation()
    {
        Employee objEmployee = new Employee(Convert.ToDecimal(ddlName.SelectedValue));

        if (objEmployee.Job_Title != null)
            txtTitle.Text = Convert.ToString(objEmployee.Job_Title).Trim();
        else
            txtTitle.Text = "";

        if (objEmployee.Employee_Home_Phone != null)
            txtTelephoneNumber1.Text = Convert.ToString(objEmployee.Employee_Home_Phone).Trim();
        else
            txtTelephoneNumber1.Text = "";

        if (objEmployee.Employee_Cell_Phone != null)
            txtTelephoneNumber2.Text = Convert.ToString(objEmployee.Employee_Cell_Phone).Trim();
        else
            txtTelephoneNumber2.Text = "";

        if (objEmployee.Email != null)
            txtEmailAddress.Text = Convert.ToString(objEmployee.Email).Trim();
        else
            txtEmailAddress.Text = "";

    }
    #endregion
}
