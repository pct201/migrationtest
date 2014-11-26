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

        Employee objEmployee = new Employee();

        objEmployee.Employee_Id = txtEmployeeID.Text;
        objEmployee.First_Name = txtFirstName.Text;
        objEmployee.Last_Name = txtLastName.Text;
        objEmployee.Middle_Name = txtMIddleName.Text;
        objEmployee.Sex = rblGender.SelectedValue;
        objEmployee.Employee_Address_1 = txtAddress_1.Text;
        objEmployee.Employee_Address_2 = Convert.ToString(txtAddress_2.Text);
        objEmployee.Employee_City = Convert.ToString(txtCity.Text);
        objEmployee.Employee_Zip_Code = Convert.ToString(txtZip_code.Text);
        objEmployee.Employee_Home_Phone = Convert.ToString(txtHome_Phone.Text);
        objEmployee.Employee_Cell_Phone = Convert.ToString(txtCell_phone.Text);
        objEmployee.Social_Security_Number = Convert.ToString(txtSocial_Security_Number.Text);
        objEmployee.Drivers_License_Class = Convert.ToString(txtDriver_License_Class.Text);
        objEmployee.Drivers_License_Number = Convert.ToString(txtDriver_License_Number.Text);
        objEmployee.Drivers_License_Type = Convert.ToString(txtDriver_License_Type.Text);
        objEmployee.Drivers_License_Endorsements = Convert.ToString(txtDrivers_License_Endorsements.Text);
        objEmployee.Drivers_License_Restrictions = Convert.ToString(txtDrivers_License_Restrictions.Text);
        objEmployee.Department = Convert.ToString(txtDepartment.Text);
        objEmployee.Email = Convert.ToString(txtemail.Text);
        objEmployee.Inactive = Convert.ToString(txtInactive.Text);
        objEmployee.Job_Title = Convert.ToString(txtJob_Title.Text);
        objEmployee.Occupation_Description = Convert.ToString(txtOccupation_description.Text);
        objEmployee.Frequency = Convert.ToString(txtSalary_Frequency.Text);
        objEmployee.Supervisor = Convert.ToString(txtSupervisor_Name.Text);
        objEmployee.Work_Phone = Convert.ToString(txtWork_Phone.Text);
        objEmployee.Active_Inactive_Leave = Convert.ToString(txtActive_Inactive_Leave.Text);

        if (ddlJobClassification.SelectedIndex > 0)
            objEmployee.FK_Job_Classification = Convert.ToDecimal(ddlJobClassification.SelectedValue);

        if (ddlBankNumber.SelectedIndex > 0)
            objEmployee.FK_Bank_Number = Convert.ToDecimal(ddlBankNumber.SelectedValue);

        if (!string.IsNullOrEmpty(txtDrivers_License_Expires.Text.Trim()))
            objEmployee.Drivers_License_Expires = Convert.ToDateTime(txtDrivers_License_Expires.Text);

        if (!string.IsNullOrEmpty(txtDrivers_License_Issued.Text.Trim()))
            objEmployee.Drivers_License_Issued = Convert.ToDateTime(txtDrivers_License_Issued.Text);

        if (!string.IsNullOrEmpty(txtDate_of_Hire.Text.Trim()))
            objEmployee.Hire_Date = Convert.ToDateTime(txtDate_of_Hire.Text);

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

        if (PK_Employee_ID > 0)
        {
            objEmployee.PK_Employee_ID = PK_Employee_ID;
            objEmployee.Update();
        }
        else
        {
            PK_Employee_ID = objEmployee.Insert();
        }

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
        ComboHelper.FillBank_Detail(new DropDownList[] { ddlBankNumber }, true);

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
        lblDate_Of_Birth.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Birth);
        lblDate_of_Death.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Death);

        if (objEmployee.FK_Job_Classification != null)
            lblJobClassification.Text = new Job_Classification(Convert.ToDecimal(objEmployee.FK_Job_Classification)).Fld_Desc;

        if (objEmployee.FK_Bank_Number != null)
            lblBankNumber.Text = new Bank_Details(Convert.ToDecimal(objEmployee.FK_Bank_Number)).Fld_AccountNo;

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
            lblCostCenter.Text = objEmployee.FK_Cost_Center.ToString();
    }

    private void BindControlForEdit()
    {
        pnlEdit.Visible = true;
        pnlView.Visible = false;

        Employee objEmployee = new Employee(PK_Employee_ID);

        txtEmployeeID.Text = Convert.ToString(objEmployee.Employee_Id);
        txtFirstName.Text = Convert.ToString(objEmployee.First_Name);
        txtLastName.Text = Convert.ToString(objEmployee.Last_Name);
        txtMIddleName.Text = Convert.ToString(objEmployee.Middle_Name);
        rblGender.SelectedIndex = objEmployee.Sex == "F" ? 1 : 0;
        txtAddress_1.Text = Convert.ToString(objEmployee.Employee_Address_1);
        txtAddress_2.Text = Convert.ToString(objEmployee.Employee_Address_2);
        txtCity.Text = Convert.ToString(objEmployee.Employee_City);
        txtZip_code.Text = Convert.ToString(objEmployee.Employee_Zip_Code);
        txtHome_Phone.Text = Convert.ToString(objEmployee.Employee_Home_Phone);
        txtCell_phone.Text = Convert.ToString(objEmployee.Employee_Cell_Phone);
        txtSocial_Security_Number.Text = Convert.ToString(objEmployee.Social_Security_Number);
        txtDriver_License_Class.Text = Convert.ToString(objEmployee.Drivers_License_Class);
        txtDriver_License_Number.Text = Convert.ToString(objEmployee.Drivers_License_Number);
        txtDriver_License_Type.Text = Convert.ToString(objEmployee.Drivers_License_Type);
        txtDrivers_License_Endorsements.Text = Convert.ToString(objEmployee.Drivers_License_Endorsements);
        txtDrivers_License_Restrictions.Text = Convert.ToString(objEmployee.Drivers_License_Restrictions);
        txtDepartment.Text = Convert.ToString(objEmployee.Department);
        txtemail.Text = Convert.ToString(objEmployee.Email);
        txtInactive.Text = Convert.ToString(objEmployee.Inactive);
        txtJob_Title.Text = Convert.ToString(objEmployee.Job_Title);
        txtOccupation_description.Text = Convert.ToString(objEmployee.Occupation_Description);
        txtSalary_Frequency.Text = Convert.ToString(objEmployee.Frequency);
        txtSupervisor_Name.Text = Convert.ToString(objEmployee.Supervisor);
        txtWork_Phone.Text = Convert.ToString(objEmployee.Work_Phone);

        txtDrivers_License_Expires.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Drivers_License_Expires);
        txtDrivers_License_Issued.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Drivers_License_Issued);
        txtDate_of_Hire.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Hire_Date);
        txtDate_Of_Birth.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Birth);
        txtDate_of_Death.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Death);
        txtActive_Inactive_Leave.Text = Convert.ToString(objEmployee.Active_Inactive_Leave);

        if (objEmployee.FK_Job_Classification != null)
            ddlJobClassification.SelectedValue = objEmployee.FK_Job_Classification.ToString();

        if (objEmployee.FK_Bank_Number != null)
            ddlBankNumber.SelectedValue = objEmployee.FK_Bank_Number.ToString();

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
            ddlCostCenter.SelectedValue = objEmployee.FK_Cost_Center.ToString();
    }

    #endregion

}
