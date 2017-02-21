using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAccessRequest_SafetyTraining_NewUserAccessRequest : System.Web.UI.Page
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>

    public decimal PK_Employee_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Employee_ID"]);
        }
        set { ViewState["PK_Employee_ID"] = value; }
    }


    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public string PK_LU_Location_ID
    {
        get
        {
            return clsGeneral.GetStringValue(ViewState["PK_LU_Location_ID"]);
        }
        set { ViewState["PK_LU_Location_ID"] = value; }
    }

    public string strMoodleURL;

    #endregion

    # region Page Events

    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCurrentDate.Text = DateTime.Now.ToShortDateString().ToString();
        strMoodleURL = WebConfigurationManager.AppSettings["MoodleURL"];
        if (!IsPostBack)
        {
            DivViewAccessUser.Style.Add("display", "none");
            DivEditAccessUser.Style.Add("display", "block");
            FillDropdown();
        }
    }

    /// <summary>
    /// Button Save Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Store the Data into temp table
        DataTable dt = new DataTable();
        dt.Columns.Add("FirstName");
        dt.Columns.Add("LastName");
        dt.Columns.Add("EMail");
        dt.Columns.Add("SocialSecurityNumber");
        dt.Columns.Add("Location");
        dt.Columns.Add("Department");
        dt.Columns.Add("JobTitle");
        dt.Columns.Add("DateofHire");
        dt.Columns.Add("LocationID");

        dt.Rows.Add(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtSocialSecurityNumber.Text, ddlLocation.SelectedItem.Text, ddlDepartment.SelectedItem.Value, ddlJobTitle.SelectedItem.Value, txtDateOfHire.Text, ddlLocation.SelectedItem.Value);
        //store data into session
        Session["dtEmployeeData"] = dt;

        DivEditAccessUser.Style.Add("display", "none");
        DivViewAccessUser.Style.Add("display", "block");

        DataTable dtEmployeeData = (DataTable)Session["dtEmployeeData"];
        lblDateOfHire.Text = Convert.ToString(dtEmployeeData.Rows[0]["DateofHire"]);
        lblFirstName.Text = Convert.ToString(dtEmployeeData.Rows[0]["FirstName"]);
        lblLastName.Text = Convert.ToString(dtEmployeeData.Rows[0]["LastName"]);
        lblLocation.Text = Convert.ToString(dtEmployeeData.Rows[0]["Location"]);
        lblSocialSecurityNumber.Text = Convert.ToString(dtEmployeeData.Rows[0]["SocialSecurityNumber"]);
        lblDepartment.Text = Convert.ToString(dtEmployeeData.Rows[0]["Department"]);
        lblEmail.Text = Convert.ToString(dtEmployeeData.Rows[0]["EMail"]);
        lblJobTitle.Text = Convert.ToString(dtEmployeeData.Rows[0]["JobTitle"]);
        lblDateOfHire.Text = Convert.ToString(dtEmployeeData.Rows[0]["DateofHire"]);
        PK_LU_Location_ID = hdnLocationID.Value = Convert.ToString(dtEmployeeData.Rows[0]["LocationID"]);
    }

    /// <summary>
    /// button Edit Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        DivEditAccessUser.Style.Add("display", "block");
        DivViewAccessUser.Style.Add("display", "none");

        DataTable dtEmployeeData = (DataTable)Session["dtEmployeeData"];
        txtDateOfHire.Text = Convert.ToString(dtEmployeeData.Rows[0]["DateofHire"]);
        txtFirstName.Text = Convert.ToString(dtEmployeeData.Rows[0]["FirstName"]);
        txtLastName.Text = Convert.ToString(dtEmployeeData.Rows[0]["LastName"]);
        txtSocialSecurityNumber.Text = Convert.ToString(dtEmployeeData.Rows[0]["SocialSecurityNumber"]);
        txtEmail.Text = Convert.ToString(dtEmployeeData.Rows[0]["EMail"]);
        txtDateOfHire.Text = Convert.ToString(dtEmployeeData.Rows[0]["DateofHire"]);
        clsGeneral.SetDropdownValue(ddlLocation, Convert.ToString(dtEmployeeData.Rows[0]["Location"]), false);
        clsGeneral.SetDropdownValue(ddlDepartment, Convert.ToString(dtEmployeeData.Rows[0]["Department"]), true);
        clsGeneral.SetDropdownValue(ddlJobTitle, Convert.ToString(dtEmployeeData.Rows[0]["JobTitle"]), true);
        PK_LU_Location_ID = hdnLocationID.Value = Convert.ToString(dtEmployeeData.Rows[0]["LocationID"]);
    }

    /// <summary>
    /// button Submit Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool IsSave = false;
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The information has been submitted to create a Safety Training catalogue for " + lblFirstName.Text + " " + lblLastName.Text + ". An e-mail containing this information has been sent to " + lblEmail.Text + " and the system administrator.');", true);
        btnSubmit.OnClientClick = "javascript:alert('The information has been submitted to create a Safety Training catalogue for " + lblFirstName.Text + " " + lblLastName.Text + ". An e-mail containing this information has been sent to " + lblEmail.Text + " and the system administrator.');";


        Employee objEmployee = new Employee();
        objEmployee.First_Name = lblFirstName.Text;
        objEmployee.Last_Name = lblLastName.Text;
        objEmployee.Email = lblEmail.Text;
        objEmployee.Job_Title = lblJobTitle.Text;
        objEmployee.Social_Security_Number = lblSocialSecurityNumber.Text;

        if (!string.IsNullOrEmpty(Convert.ToString(LU_Location.SelectFKCostCenterByLocation(Convert.ToDecimal(PK_LU_Location_ID)))))
        {
            objEmployee.FK_Cost_Center = LU_Location.SelectFKCostCenterByLocation(Convert.ToDecimal(PK_LU_Location_ID));
        }

        objEmployee.Department = lblDepartment.Text;
        objEmployee.Last_Hire_Date = Convert.ToDateTime(lblDateOfHire.Text);
        objEmployee.Active_Inactive_Leave = "Active";
        objEmployee.Update_Date = DateTime.Now;
        PK_Employee_ID = objEmployee.Insert();

        if (PK_Employee_ID > 0)
        {
            //insert record in Employee_Codes
            Employee_Codes objEmployee_Codes = new Employee_Codes();
            if (!string.IsNullOrEmpty(Convert.ToString(Sonic_U_Training_Required_Classes.SelectCodeByPosition(lblJobTitle.Text).Tables[0].Rows[0]["Code"])))
            {
                objEmployee_Codes.Code = Convert.ToString(Sonic_U_Training_Required_Classes.SelectCodeByPosition(lblJobTitle.Text).Tables[0].Rows[0]["Code"]);
            }
            objEmployee_Codes.FK_Employee_Id = PK_Employee_ID;
            objEmployee_Codes.Insert();
            IsSave = true;
        }

        try
        {
            Sonic_U_Training.Import_Sonic_U_Training_Associate_Base();
        }
        catch (Exception)
        {

        }

        if (IsSave)
        {
            DataSet dsAdmin = Security.SelectByUserName("brady.lamp", 0);
            //send email here
            Response.Redirect(strMoodleURL);
        }

    }

    /// <summary>
    /// button Cancel CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtFirstName.Text = txtLastName.Text = txtEmail.Text = txtDateOfHire.Text = txtSocialSecurityNumber.Text = "";
        ddlDepartment.SelectedIndex = ddlJobTitle.SelectedIndex = ddlLocation.SelectedIndex = -1;
        Response.Redirect(strMoodleURL);
    }

    #endregion

    #region Page Methods
    /// <summary>
    /// Bind DropDowns
    /// </summary>
    private void FillDropdown()
    {
        //Bind Drop Down for Location
        ComboHelper.FillLocationByRLCM(new DropDownList[] { ddlLocation }, null, true, true);

        //Bind Drop Down for Job Title
        ddlJobTitle.DataSource = Employee.SelectAllJobTitles();
        ddlJobTitle.DataTextField = "Job_Title";
        ddlJobTitle.DataValueField = "Job_Title";
        ddlJobTitle.DataBind();

        ddlJobTitle.Items.Insert(0, new ListItem("-- Select --", "0"));

        //Bind Drop Down for Department
        ddlDepartment.DataSource = Employee.SelectAllDepartments();
        ddlDepartment.DataTextField = "Department";
        ddlDepartment.DataValueField = "Department";
        ddlDepartment.DataBind();

        ddlDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    #endregion

}