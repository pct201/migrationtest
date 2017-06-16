using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_Employee : clsBasePage
{

    #region Properties

    /// <summary>
    /// Denotes the Primary Key for RE_Information
    /// </summary>
    public decimal PK_Employee_ID
    {
        get { return (!clsGeneral.IsNull(ViewState["PK_Employee_ID"]) ? Convert.ToDecimal(ViewState["PK_Employee_ID"]) : -1); }
        set { ViewState["PK_Employee_ID"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for Employee_Codes
    /// </summary>
    public string PK_Employee_Codes;


    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtWages_YTD.Attributes.Add("onkeypress", "javascript:return FormatNumber(event,'" + this.txtWages_YTD.ClientID + "',13,false);");
            this.txtNumber_of_Dependents.Attributes.Add("onkeypress", "javascript:return FormatNumber(event,'" + this.txtNumber_of_Dependents.ClientID + "',5,false);");

            // Check whether Parameter ID is passed or not.
            if (Request.QueryString["id"] != null)
            {
                decimal _id;

                // Encrypt Employee ID
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"].ToString()), out _id))
                {
                    PK_Employee_ID = _id;

                    // Check Page Mode
                    if (clsSession.Str_Employee_Operation == "Edit")
                    {
                        FillDropDown();
                        BindControlForEdit();
                    }
                    else
                    {
                        BindControlForView();
                    }

                }
                else
                {
                    // redirect to Search Page
                    Response.Redirect("EmployeeSearchResult.aspx");
                }
            }
            else
            {
                // Page in Add Mode
                FillDropDown();
                pnlEdit.Visible = true;
                pnlView.Visible = false;
            }


        }
    }

    #region "Events"

    protected void btnAssociateSave_Click(object sender, EventArgs e)
    {

        if (Employee.CheckEmployee_IDExists(PK_Employee_ID, txtEmployeeID.Text.Trim()))
        {
            lblError.Text = "Employee ID is already Exists. Please enter another Employee ID.";
            lblError.Visible = true;
            return;
        }

        bool jobcodeChanged = false;

        DataSet ds = Employee_Codes.SelectDataByEmployeeCodes(PK_Employee_ID);

        if (ds.Tables[0].Rows.Count > 0 && Convert.ToString(ds.Tables[0].Rows[0]["Code"]) != ddlJobCode.SelectedValue && PK_Employee_ID > 0)
            jobcodeChanged = true;

        Employee objEmployee = new Employee();

        objEmployee.Employee_Id = txtEmployeeID.Text.Trim();
        objEmployee.First_Name = txtFirstName.Text.Trim();
        objEmployee.Last_Name = txtLastName.Text.Trim();
        objEmployee.Middle_Name = txtMIddleName.Text.Trim();
        objEmployee.Sex = rblGender.SelectedValue;
        objEmployee.Employee_Address_1 = txtAddress_1.Text.Trim();
        objEmployee.Employee_Address_2 = Convert.ToString(txtAddress_2.Text.Trim());
        objEmployee.Employee_City = Convert.ToString(txtCity.Text.Trim());
        objEmployee.Employee_Zip_Code = Convert.ToString(txtZip_code.Text.Trim());
        objEmployee.Employee_Home_Phone = Convert.ToString(txtHome_Phone.Text.Trim());
        objEmployee.Employee_Cell_Phone = Convert.ToString(txtCell_phone.Text.Trim());
        objEmployee.Social_Security_Number = Convert.ToString(txtSocial_Security_Number.Text.Trim());
        objEmployee.Drivers_License_Class = Convert.ToString(txtDriver_License_Class.Text.Trim());
        objEmployee.Drivers_License_Number = Convert.ToString(txtDriver_License_Number.Text.Trim());
        objEmployee.Drivers_License_Type = Convert.ToString(txtDriver_License_Type.Text.Trim());
        objEmployee.Drivers_License_Endorsements = Convert.ToString(txtDrivers_License_Endorsements.Text.Trim());
        objEmployee.Drivers_License_Restrictions = Convert.ToString(txtDrivers_License_Restrictions.Text.Trim());
        objEmployee.Department = Convert.ToString(txtDepartment.Text.Trim());
        objEmployee.Email = Convert.ToString(txtemail.Text.Trim());
        objEmployee.Inactive = Convert.ToString(txtInactive.Text.Trim());
        objEmployee.Job_Title = Convert.ToString(txtJob_Title.Text.Trim());
        objEmployee.Occupation_Description = Convert.ToString(txtOccupation_description.Text.Trim());
        objEmployee.Frequency = Convert.ToString(txtSalary_Frequency.Text.Trim());
        objEmployee.Supervisor = Convert.ToString(txtSupervisor_Name.Text.Trim());
        objEmployee.Work_Phone = Convert.ToString(txtWork_Phone.Text.Trim());
        objEmployee.Active_Inactive_Leave = Convert.ToString(txtActive_Inactive_Leave.Text.Trim());
        //objEmployee.Secondary_Cost_Center = txtSecondary_Cost_Center.Text.Trim();

        if (ddlJobClassification.SelectedIndex > 0)
            objEmployee.FK_Job_Classification = Convert.ToDecimal(ddlJobClassification.SelectedValue);

        //if (ddlBankNumber.SelectedIndex > 0)
        //    objEmployee.FK_Bank_Number = Convert.ToDecimal(ddlBankNumber.SelectedValue);

        if (!string.IsNullOrEmpty(txtDrivers_License_Expires.Text.Trim()))
            objEmployee.Drivers_License_Expires = Convert.ToDateTime(txtDrivers_License_Expires.Text);

        if (!string.IsNullOrEmpty(txtDrivers_License_Issued.Text.Trim()))
            objEmployee.Drivers_License_Issued = Convert.ToDateTime(txtDrivers_License_Issued.Text);

        if (!string.IsNullOrEmpty(txtDate_of_Hire.Text.Trim()))
            objEmployee.Hire_Date = Convert.ToDateTime(txtDate_of_Hire.Text);

        if (!string.IsNullOrEmpty(txtLast_Date_Of_Hire.Text.Trim()))
            objEmployee.Last_Hire_Date = Convert.ToDateTime(txtLast_Date_Of_Hire.Text);

        if (!string.IsNullOrEmpty(txtDate_Of_Birth.Text.Trim()))
            objEmployee.Date_Of_Birth = Convert.ToDateTime(txtDate_Of_Birth.Text);

        if (!string.IsNullOrEmpty(txtDate_of_Death.Text.Trim()))
            objEmployee.Date_Of_Death = Convert.ToDateTime(txtDate_of_Death.Text);

        if (!string.IsNullOrEmpty(txtDate_of_Death.Text.Trim()))
            objEmployee.Date_Of_Death = Convert.ToDateTime(txtDate_of_Death.Text);

        if (!string.IsNullOrEmpty(txtNumber_of_Dependents.Text))
            objEmployee.Number_Of_Dependents = Convert.ToDecimal(txtNumber_of_Dependents.Text);

        if (ddlState.SelectedIndex > 0)
            objEmployee.Employee_State = Convert.ToDecimal(ddlState.SelectedValue);

        if (ddlMaritalStatus.SelectedIndex > 0)
            objEmployee.FK_Marital_Status = Convert.ToDecimal(ddlMaritalStatus.SelectedValue);

        if (ddlDriver_License_state.SelectedIndex > 0)
            objEmployee.Drivers_License_State = Convert.ToString(ddlDriver_License_state.SelectedValue);

        if (ddlCostCenter.SelectedIndex > 0)
            objEmployee.FK_Cost_Center = Convert.ToDecimal(ddlCostCenter.SelectedValue);

        if (!string.IsNullOrEmpty(txtSalary.Text))
            objEmployee.Salary = Convert.ToDecimal(txtSalary.Text);

        if (!string.IsNullOrEmpty(txtWages_YTD.Text))
            objEmployee.Wages_YTD = Convert.ToDecimal(txtWages_YTD.Text);

        objEmployee.Updated_By = clsSession.UserID;
        objEmployee.Update_Date = System.DateTime.Now;

        Employee objOldEmployee = new Employee(PK_Employee_ID);
        bool loginDetailchanged = false;

        if (objOldEmployee.Social_Security_Number != objEmployee.Social_Security_Number || objOldEmployee.FK_Cost_Center != objEmployee.FK_Cost_Center || objOldEmployee.Last_Name != objEmployee.Last_Name)
        {
            loginDetailchanged = true;
        }


        if(ddlJobCode.SelectedValue != "0")
        {
            objEmployee.FK_LU_Job_Code = Convert.ToDecimal(ddlJobCode.SelectedValue);
        }

        if (PK_Employee_ID > 0)
        {
            objEmployee.PK_Employee_ID = PK_Employee_ID;
            objEmployee.Update();
        }
        else
        {
            PK_Employee_ID = objEmployee.Insert();
            Sonic_U_Training.Import_Sonic_U_Training_Associate_Base_New(PK_Employee_ID);
        }
        //if (txtEmployeeID.Text.Length > 0) commented as per ticket 3698 comment 38348  point 4
        //{

        Employee_Codes objEmployee_Codes = new Employee_Codes();

        ds = Employee_Codes.SelectDataByEmployeeCodes(PK_Employee_ID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            objEmployee_Codes.Code = ddlJobCode.SelectedValue;
            objEmployee_Codes.Employee_Id = txtEmployeeID.Text;
            objEmployee_Codes.FK_Employee_Id = PK_Employee_ID;
            objEmployee_Codes.Update();

        }
        else
        {
            objEmployee_Codes.Code = ddlJobCode.SelectedValue;
            objEmployee_Codes.Employee_Id = txtEmployeeID.Text;
            objEmployee_Codes.FK_Employee_Id = PK_Employee_ID;
            objEmployee_Codes.Insert();
        }
        //try
        //{
        //    if (jobcodeChanged)
        //    {
        //        Sonic_U_Training.Import_Sonic_U_Training_Associate_Base();
        //        Sonic_U_Training.SCORM_handle_ChangedLocation_Users();

        //    }

        //    if (loginDetailchanged)
        //    {
        //        Sonic_U_Training.SCORM_handle_LastNameChange_Users();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        // }

        clsSession.Str_Employee_Operation = "view";
        Response.Redirect("Employee.aspx?id=" + Encryption.Encrypt(PK_Employee_ID.ToString()));
    }

    protected void btnBackToEdit_Click(object sender, EventArgs e)
    {
        clsSession.Str_Employee_Operation = "Edit";
        // Change Page mode To Edit
        Response.Redirect("Employee.aspx?id=" + Encryption.Encrypt(PK_Employee_ID.ToString()));
    }

    protected void btnBackToSearch_Click(object sender, EventArgs e)
    {
        // redirect to Search Page
        Response.Redirect("EmployeeSearchResult.aspx");
    }

    #endregion

    #region Methods

    private void FillDropDown()
    {
        ComboHelper.FillMaritalStatus(new DropDownList[] { ddlMaritalStatus }, 0, true);
        ComboHelper.FillState(new DropDownList[] { ddlState }, 0, true);
        ComboHelper.FillCostCenter(new DropDownList[] { ddlCostCenter }, true);
        ComboHelper.FillJobCode_New(new DropDownList[] { ddlJobCode }, true);


        DataSet dsData = State.SelectAll();
        ddlDriver_License_state.DataValueField = "FLD_abbreviation";
        ddlDriver_License_state.DataTextField = "FLD_state";
        ddlDriver_License_state.DataSource = dsData;
        ddlDriver_License_state.DataBind();
        ddlDriver_License_state.Items.Insert(0, new ListItem("--- Select ---", "0"));
        dsData.Clear();

        dsData = Job_Classification.SelectAll();
        ddlJobClassification.DataValueField = "PK_Id";
        ddlJobClassification.DataTextField = "Fld_Desc";
        ddlJobClassification.DataSource = dsData;
        ddlJobClassification.DataBind();
        ddlJobClassification.Items.Insert(0, new ListItem("--- Select ---", "0"));
        clsGeneral.DisposeOf(dsData);

    }

    private void BindControlForView()
    {
        pnlEdit.Visible = false;
        pnlView.Visible = true;

        Employee objEmployee = new Employee(PK_Employee_ID);

        lblEmployeeID.Text = Convert.ToString(objEmployee.Employee_Id);
        lblFirstName.Text = Convert.ToString(objEmployee.First_Name);
        lblLastName.Text = Convert.ToString(objEmployee.Last_Name);
        lblMIddleName.Text = Convert.ToString(objEmployee.Middle_Name);
        lblGender.Text = objEmployee.Sex == "F" ? "Female" : "Male";
        lblAddress_1.Text = Convert.ToString(objEmployee.Employee_Address_1);
        lblAddress_2.Text = Convert.ToString(objEmployee.Employee_Address_2);
        lblCity.Text = Convert.ToString(objEmployee.Employee_City);
        lblZip_code.Text = Convert.ToString(objEmployee.Employee_Zip_Code);
        lblHome_Phone.Text = Convert.ToString(objEmployee.Employee_Home_Phone);
        lblCell_phone.Text = Convert.ToString(objEmployee.Employee_Cell_Phone);
        lblSocial_Security_Number.Text = Convert.ToString(objEmployee.Social_Security_Number);
        lblDriver_License_Class.Text = Convert.ToString(objEmployee.Drivers_License_Class);
        lblDriver_License_Number.Text = Convert.ToString(objEmployee.Drivers_License_Number);
        lblDriver_License_Type.Text = Convert.ToString(objEmployee.Drivers_License_Type);
        lblDrivers_License_Endorsements.Text = Convert.ToString(objEmployee.Drivers_License_Endorsements);
        lblDrivers_License_Restrictions.Text = Convert.ToString(objEmployee.Drivers_License_Restrictions);
        lblDepartment.Text = Convert.ToString(objEmployee.Department);
        lblemail.Text = Convert.ToString(objEmployee.Email);
        lblInactive.Text = Convert.ToString(objEmployee.Inactive);
        lblJob_Title.Text = Convert.ToString(objEmployee.Job_Title);
        lblOccupation_description.Text = Convert.ToString(objEmployee.Occupation_Description);
        lblSalary_Frequency.Text = Convert.ToString(objEmployee.Frequency);
        lblSupervisor_Name.Text = Convert.ToString(objEmployee.Supervisor);
        lblWork_Phone.Text = Convert.ToString(objEmployee.Work_Phone);
        lblActive_Inactive_Leave.Text = Convert.ToString(objEmployee.Active_Inactive_Leave);
        lblDrivers_License_Expires.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Drivers_License_Expires);
        lblDrivers_License_Issued.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Drivers_License_Issued);
        lblDate_of_Hire.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Hire_Date);
        lblLast_date_of_hire.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Last_Hire_Date);
        lblDate_Of_Birth.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Birth);
        lblDate_of_Death.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Death);
        if (objEmployee.FK_Job_Classification != null)
            lblJobClassification.Text = new Job_Classification(Convert.ToDecimal(objEmployee.FK_Job_Classification)).Fld_Desc;
       // lblSecondary_Cost_Center.Text = Convert.ToString(objEmployee.Secondary_Cost_Center);

        //if (objEmployee.FK_Bank_Number != null)
        //    lblBankNumber.Text = new Bank_Details(Convert.ToDecimal(objEmployee.FK_Bank_Number)).Fld_AccountNo;

        #region Old Logic for Job code
        //DataSet ds = Employee_Codes.SelectDataByEmployeeCodes(PK_Employee_ID);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    PK_Employee_Codes = ds.Tables[0].Rows[0]["Code"].ToString();
        //    Sonic_U_Training_Required_Classes objSonic_U_Training_Required_Classes = new Sonic_U_Training_Required_Classes();
        //    ds = objSonic_U_Training_Required_Classes.SelectByCode(PK_Employee_Codes);
        //    if (ds.Tables[0].Rows.Count > 0)
        //        lblJobCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["JobDescription"]);
        //}
        #endregion

        #region new Logic for Job Code LU_Job_Code
        if(objEmployee.FK_LU_Job_Code.HasValue)
        {
            clsLU_Job_Code objLU_Job_Code = new clsLU_Job_Code(objEmployee.FK_LU_Job_Code.Value);
            lblJobCode.Text = objLU_Job_Code.Code;
        }
        #endregion

        if (objEmployee.Number_Of_Dependents != null)
            lblNumber_of_Dependents.Text = string.Format("{0:N0}", objEmployee.Number_Of_Dependents);

        if (objEmployee.Employee_State != null)
            lblState.Text = new State(Convert.ToDecimal(objEmployee.Employee_State)).FLD_state;

        if (objEmployee.FK_Marital_Status != null)
            lblMaritalStatus.Text = new Marital_Status(Convert.ToDecimal(objEmployee.FK_Marital_Status)).FLD_desc;

        if (!string.IsNullOrEmpty(objEmployee.Drivers_License_State))
        {
            DataTable dtDriverState = State.SelectByAbbreviation(objEmployee.Drivers_License_State).Tables[0];

            if (dtDriverState.Rows.Count > 0)
                lblDriver_License_state.Text = dtDriverState.Rows[0]["FLD_state"].ToString();

            clsGeneral.DisposeOf(dtDriverState);
        }

        if (objEmployee.Salary != null)
            lblSalary.Text = string.Format("{0:N2}", objEmployee.Salary);

        if (objEmployee.Wages_YTD != null)
            lblWages_YTD.Text = string.Format("{0:N0}", objEmployee.Wages_YTD);

        if (objEmployee.FK_Cost_Center != null)
            lblCostCenter.Text = objEmployee.FK_Cost_Center.ToString().PadLeft(4, '0');
    }

    private void BindControlForEdit()
    {
        pnlEdit.Visible = true;
        pnlView.Visible = false;

        Employee objEmployee = new Employee(PK_Employee_ID);

        if (objEmployee.Employee_Id != null)
            txtEmployeeID.Text = Convert.ToString(objEmployee.Employee_Id.Trim());
        else
            txtEmployeeID.Text = Convert.ToString(objEmployee.Employee_Id);

        if (objEmployee.First_Name != null)
            txtFirstName.Text = Convert.ToString(objEmployee.First_Name.Trim());
        else
            txtFirstName.Text = Convert.ToString(objEmployee.First_Name);

        if (objEmployee.Last_Name != null)
            txtLastName.Text = Convert.ToString(objEmployee.Last_Name.Trim());
        else
            txtLastName.Text = Convert.ToString(objEmployee.Last_Name);

        if (objEmployee.Middle_Name != null)
            txtMIddleName.Text = Convert.ToString(objEmployee.Middle_Name.Trim());
        else
            txtMIddleName.Text = Convert.ToString(objEmployee.Middle_Name);

        rblGender.SelectedIndex = objEmployee.Sex == "F" ? 1 : 0;

        if (objEmployee.Employee_Address_1 != null)
            txtAddress_1.Text = Convert.ToString(objEmployee.Employee_Address_1.Trim());
        else
            txtAddress_1.Text = Convert.ToString(objEmployee.Employee_Address_1);

        if (objEmployee.Employee_Address_2 != null)
            txtAddress_2.Text = Convert.ToString(objEmployee.Employee_Address_2.Trim());
        else
            txtAddress_2.Text = Convert.ToString(objEmployee.Employee_Address_2);

        if (objEmployee.Employee_City != null)
            txtCity.Text = Convert.ToString(objEmployee.Employee_City.Trim());
        else
            txtCity.Text = Convert.ToString(objEmployee.Employee_City);

        if (objEmployee.Employee_Zip_Code != null)
            txtZip_code.Text = Convert.ToString(objEmployee.Employee_Zip_Code.Trim());
        else
            txtZip_code.Text = Convert.ToString(objEmployee.Employee_Zip_Code);

        if (objEmployee.Employee_Home_Phone != null)
            txtHome_Phone.Text = Convert.ToString(objEmployee.Employee_Home_Phone.Trim());
        else
            txtHome_Phone.Text = Convert.ToString(objEmployee.Employee_Home_Phone);

        if (objEmployee.Employee_Cell_Phone != null)
            txtCell_phone.Text = Convert.ToString(objEmployee.Employee_Cell_Phone.Trim());
        else
            txtCell_phone.Text = Convert.ToString(objEmployee.Employee_Cell_Phone);

        if (objEmployee.Social_Security_Number != null)
            txtSocial_Security_Number.Text = Convert.ToString(objEmployee.Social_Security_Number.Trim());
        else
            txtSocial_Security_Number.Text = Convert.ToString(objEmployee.Social_Security_Number);

        if (objEmployee.Drivers_License_Class != null)
            txtDriver_License_Class.Text = Convert.ToString(objEmployee.Drivers_License_Class.Trim());
        else
            txtDriver_License_Class.Text = Convert.ToString(objEmployee.Drivers_License_Class);

        if (objEmployee.Drivers_License_Number != null)
            txtDriver_License_Number.Text = Convert.ToString(objEmployee.Drivers_License_Number.Trim());
        else
            txtDriver_License_Number.Text = Convert.ToString(objEmployee.Drivers_License_Number);

        if (objEmployee.Drivers_License_Type != null)
            txtDriver_License_Type.Text = Convert.ToString(objEmployee.Drivers_License_Type.Trim());
        else
            txtDriver_License_Type.Text = Convert.ToString(objEmployee.Drivers_License_Type);

        if (objEmployee.Drivers_License_Endorsements != null)
            txtDrivers_License_Endorsements.Text = Convert.ToString(objEmployee.Drivers_License_Endorsements.Trim());
        else
            txtDrivers_License_Endorsements.Text = Convert.ToString(objEmployee.Drivers_License_Endorsements);

        if (objEmployee.Drivers_License_Restrictions != null)
            txtDrivers_License_Restrictions.Text = Convert.ToString(objEmployee.Drivers_License_Restrictions.Trim());
        else
            txtDrivers_License_Restrictions.Text = Convert.ToString(objEmployee.Drivers_License_Restrictions);

        if (objEmployee.Department != null)
            txtDepartment.Text = Convert.ToString(objEmployee.Department.Trim());
        else
            txtDepartment.Text = Convert.ToString(objEmployee.Department);

        if (objEmployee.Email != null)
            txtemail.Text = Convert.ToString(objEmployee.Email.Trim());
        else
            txtemail.Text = Convert.ToString(objEmployee.Email);

        if (objEmployee.Inactive != null)
            txtInactive.Text = Convert.ToString(objEmployee.Inactive.Trim());
        else
            txtInactive.Text = Convert.ToString(objEmployee.Inactive);

        if (objEmployee.Job_Title != null)
            txtJob_Title.Text = Convert.ToString(objEmployee.Job_Title.Trim());
        else
            txtJob_Title.Text = Convert.ToString(objEmployee.Job_Title);

        if (objEmployee.Occupation_Description != null)
            txtOccupation_description.Text = Convert.ToString(objEmployee.Occupation_Description.Trim());
        else
            txtOccupation_description.Text = Convert.ToString(objEmployee.Occupation_Description);

        if (objEmployee.Frequency != null)
            txtSalary_Frequency.Text = Convert.ToString(objEmployee.Frequency.Trim());
        else
            txtSalary_Frequency.Text = Convert.ToString(objEmployee.Frequency);

        if (objEmployee.Supervisor != null)
            txtSupervisor_Name.Text = Convert.ToString(objEmployee.Supervisor.Trim());
        else
            txtSupervisor_Name.Text = Convert.ToString(objEmployee.Supervisor);

        if (objEmployee.Work_Phone != null)
            txtWork_Phone.Text = Convert.ToString(objEmployee.Work_Phone.Trim());
        else
            txtWork_Phone.Text = Convert.ToString(objEmployee.Work_Phone);

        txtDrivers_License_Expires.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Drivers_License_Expires);
        txtDrivers_License_Issued.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Drivers_License_Issued);
        txtDate_of_Hire.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Hire_Date);
        txtLast_Date_Of_Hire.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Last_Hire_Date);
        txtDate_Of_Birth.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Birth);
        txtDate_of_Death.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Death);
        txtActive_Inactive_Leave.Text = Convert.ToString(objEmployee.Active_Inactive_Leave);

        //if (!string.IsNullOrEmpty(objEmployee.Secondary_Cost_Center))
        //{
        //    txtSecondary_Cost_Center.Text = objEmployee.Secondary_Cost_Center.Trim();
        //}

        if (objEmployee.FK_Job_Classification != null)
            ddlJobClassification.SelectedValue = objEmployee.FK_Job_Classification.ToString();

        //if (objEmployee.FK_Bank_Number != null)
        //    ddlBankNumber.SelectedValue = objEmployee.FK_Bank_Number.ToString();

        //Employee_Codes objEmployee_Codes = new Employee_Codes(objEmployee.Employee_Id);
        //DataSet ds = Employee_Codes.SelectDataByEmployeeCodes(PK_Employee_ID);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    ddlJobCode.SelectedValue = ds.Tables[0].Rows[0]["Code"].ToString();
        //    PK_Employee_Codes = ds.Tables[0].Rows[0]["Code"].ToString();
        //}

        #region new Logic for Job Code LU_Job_Code
        if (objEmployee.FK_LU_Job_Code.HasValue)
        {
            ddlJobCode.SelectedValue = Convert.ToString(objEmployee.FK_LU_Job_Code.Value);
        }
        #endregion


        if (objEmployee.Number_Of_Dependents != null)
            txtNumber_of_Dependents.Text = string.Format("{0:N0}", objEmployee.Number_Of_Dependents);

        if (objEmployee.Employee_State != null)
            ddlState.SelectedValue = objEmployee.Employee_State.ToString();

        if (objEmployee.FK_Marital_Status != null)
            ddlMaritalStatus.SelectedValue = objEmployee.FK_Marital_Status.ToString();

        if (!string.IsNullOrEmpty(objEmployee.Drivers_License_State))
            ddlDriver_License_state.SelectedValue = objEmployee.Drivers_License_State.ToString();

        if (objEmployee.Salary != null)
            txtSalary.Text = string.Format("{0:N2}", objEmployee.Salary);

        if (objEmployee.Wages_YTD != null)
            txtWages_YTD.Text = string.Format("{0:N0}", objEmployee.Wages_YTD);

        if (objEmployee.FK_Cost_Center != null)
            ddlCostCenter.SelectedValue = objEmployee.FK_Cost_Center.ToString().PadLeft(4, '0');
    }

    #endregion

}
