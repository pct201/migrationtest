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
using System.Collections.Generic;
using System.IO;
using RIMS_Base.Biz;
public partial class Employee_Employee : System.Web.UI.Page
{
    #region Private Variables
    int m_intEmployeeId = 0;
    int m_intRetval = -1;
    public int m_intPreventAdd = 0;
    public RIMS_Base.Biz.cEmployee m_objEmployee;
    List<RIMS_Base.cEmployee> lstEmployee = null;
    List<RIMS_Base.cEmployee> lstautoEmployeeID = null;
    
    public RIMS_Base.Biz.CGeneral m_objState;
    List<RIMS_Base.CGeneral> lstState = null;
    public RIMS_Base.Biz.CGeneral m_objDState;
    List<RIMS_Base.CGeneral> lstDState = null;
    public RIMS_Base.Biz.cEmployee m_objMaritalStatus;
    List<RIMS_Base.cEmployee> lstMaritalStatus = null;
    public RIMS_Base.Biz.cEmployee m_objLicType;
    List<RIMS_Base.cEmployee> lstLicType = null;
    public RIMS_Base.Biz.cEmployee m_objJobCls;
    List<RIMS_Base.cEmployee> lstJobCls = null;
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    public RIMS_Base.Biz.CGeneral m_objAttachmentType;
    List<RIMS_Base.CGeneral> lstAttachmentType = null;
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    ListItem m_lstCommon;
    string strSortExp = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "Employee";
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Employee/");
            dvSearch.Visible = true;
            dvAttachDetails.Visible = false;
            if (!IsPostBack)
            {
                if (SetUserRights() == true)
                {
                    btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvEmployee','Delete');");
                    btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");
                    mvEmployee.ActiveViewIndex = 0;

                    gvEmployee.PageSize = 10;
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                    gvEmployee.DataSource = BindEmployee();
                    gvEmployee.DataBind();

                    ddlPage.DataBind();
                    ddlPage.SelectedValue = "10";
                    if (gvEmployee.PageCount == 0)
                    { lblPageInfo.Text = "Page 0 of 0"; }
                    else
                    {
                        lblPageInfo.Text = "Page 1 of " + gvEmployee.PageCount.ToString();
                    }
                    txtPageNo.Text = "1";
                    ViewState["PreventAdd"] = "N";
                }
            }



        }
        catch (Exception ex)
        {
          //  throw ex;
        }
    }
    protected bool SetUserRights()
    {
        try
        {

            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(25, Convert.ToInt32(Session["UserRoleId"].ToString()));
                ViewState["Add"] = lstRightDetails[0].PAdd.ToString();
                ViewState["Edit"] = lstRightDetails[0].PEdit.ToString();
                ViewState["Delete"] = lstRightDetails[0].PDelete.ToString();
                ViewState["View"] = lstRightDetails[0].PView.ToString();
                if (ViewState["Add"].ToString() == "True")
                {
                    btnAddNew.Enabled = true;
                }
                else
                {
                    btnAddNew.Enabled = false;
                }
                if (ViewState["Delete"].ToString() == "True")
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
                return true;
            }
            else
            {
                Response.Redirect("../Signin.aspx", false);
                return false;
            }

        }
        catch (Exception ex)
        {
            throw;
        }

    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvEmployee.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvEmployee.PageCount)
            {
                gvEmployee.PageIndex = gvEmployee.PageCount;
                txtPageNo.Text = gvEmployee.PageCount.ToString();
            }
            else
            {
                gvEmployee.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvEmployee.PageCount.ToString();
            gvEmployee.DataSource = BindEmployee();
            gvEmployee.DataBind();
            lblEmployeeTotal.Text = "Total Employee : " + lstEmployee.Count.ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvEmployee.PageIndex <= gvEmployee.PageCount)
            {
                gvEmployee.PageIndex = gvEmployee.PageIndex + 1;
                GeneralSorting();

                lblPageInfo.Text = "Page " + Convert.ToString(gvEmployee.PageIndex + 1) + " of " + gvEmployee.PageCount.ToString();
                lblEmployeeTotal.Text = "Total Employee : " + lstEmployee.Count.ToString();
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvEmployee.PageIndex <= gvEmployee.PageCount)
            {
                gvEmployee.PageIndex = gvEmployee.PageIndex - 1;
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvEmployee.PageIndex + 1) + " of " + gvEmployee.PageCount.ToString();
                lblEmployeeTotal.Text = "Total Employee : " + lstEmployee.Count.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            m_objEmployee = new RIMS_Base.Biz.cEmployee();
            m_intRetval = m_objEmployee.Employee_Delete(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                mvEmployee.ActiveViewIndex = 0;
                gvEmployee.DataSource = BindEmployee();
                gvEmployee.DataBind();
            }
            lblEmployeeTotal.Text = "Total Employee : " + lstEmployee.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            dvSearch.Visible = false;
            mvEmployee.ActiveViewIndex = 1;
            Bindfv(FormViewMode.Insert);

            m_objEmployee = new RIMS_Base.Biz.cEmployee();
            lstautoEmployeeID = new List<RIMS_Base.cEmployee>();

            lstautoEmployeeID = m_objEmployee.GetAutoPopulateEmployeeId();
            ((TextBox)fvEmployee.FindControl("txtEmployeeId")).Text = lstautoEmployeeID[0].Employee_Id;


            btnRemove.Visible = false;
            btnMail.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            m_objEmployee = new RIMS_Base.Biz.cEmployee();
            lstEmployee = new List<RIMS_Base.cEmployee>();
            lstEmployee = m_objEmployee.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            gvEmployee.DataSource = lstEmployee;
            gvEmployee.DataBind();
            if (gvEmployee.PageCount == 0)
            { lblPageInfo.Text = "Page 0 of 0"; }
            else
            {
                lblPageInfo.Text = "Page 1 of " + gvEmployee.PageCount.ToString();
            }
            lblEmployeeTotal.Text = "Total Employee : " + lstEmployee.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            dvSearch.Visible = false;
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objEmployee = new RIMS_Base.Biz.cEmployee();
                if (fvEmployee.CurrentMode == FormViewMode.Insert)
                {
                    m_objEmployee.PK_Employee_ID = 0;
                }
                else
                {
                    m_objEmployee.PK_Employee_ID = Convert.ToInt32(((Label)fvEmployee.FindControl("lblPkEmployeeId")).Text);
                }
                m_objEmployee.Employee_Id = Convert.ToString(((TextBox)fvEmployee.FindControl("txtEmployeeId")).Text);
                m_objEmployee.First_Name = Convert.ToString(((TextBox)fvEmployee.FindControl("txtFirstName")).Text).Replace("'", "''");
                m_objEmployee.Employee_Address_1 = Convert.ToString(((TextBox)fvEmployee.FindControl("txtAddress1")).Text);
                m_objEmployee.Employee_City = Convert.ToString(((TextBox)fvEmployee.FindControl("txtCity")).Text);
                m_objEmployee.Employee_Zip_Code = Convert.ToString(((TextBox)fvEmployee.FindControl("txtZip")).Text);
                m_objEmployee.Employee_Cell_Phone = Convert.ToString(((TextBox)fvEmployee.FindControl("txtCellTeleNo")).Text);
                m_objEmployee.FK_Marital_Status = Convert.ToDecimal(((DropDownList)fvEmployee.FindControl("ddlMaritalStatus")).SelectedValue);
                if (((TextBox)fvEmployee.FindControl("txtNoOfDependents")).Text != string.Empty)
                    m_objEmployee.Number_Of_Dependents = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtNoOfDependents")).Text);
                if (((TextBox)fvEmployee.FindControl("txtDeathDate")).Text != string.Empty)
                    m_objEmployee.Date_Of_Death = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDeathDate")).Text);
                m_objEmployee.Last_Name = Convert.ToString(((TextBox)fvEmployee.FindControl("txtLastName")).Text).Replace("'", "''");
                m_objEmployee.Middle_Name = Convert.ToString(((TextBox)fvEmployee.FindControl("txtMiddleName")).Text).Replace("'", "''");
                m_objEmployee.Employee_Address_2 = Convert.ToString(((TextBox)fvEmployee.FindControl("txtAddress2")).Text);
                m_objEmployee.Employee_State = Convert.ToDecimal(((DropDownList)fvEmployee.FindControl("ddlState")).SelectedValue);
                m_objEmployee.Employee_Home_Phone = Convert.ToString(((TextBox)fvEmployee.FindControl("txtHomeTeleNo")).Text);
                m_objEmployee.Social_Security_Number = RIMS_Base.Biz.CGeneral.Encrypt(Convert.ToString(((TextBox)fvEmployee.FindControl("txtSSN")).Text), true);
                m_objEmployee.Sex = Convert.ToString(((RadioButtonList)fvEmployee.FindControl("rdlSex")).SelectedValue);
                if (((TextBox)fvEmployee.FindControl("txtDOB")).Text != string.Empty)
                    m_objEmployee.Date_Of_Birth = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDOB")).Text);
                if ((((DropDownList)fvEmployee.FindControl("ddlDLState")).SelectedValue) != "0")
                    m_objEmployee.Drivers_License_State = Convert.ToString(((DropDownList)fvEmployee.FindControl("ddlDLState")).SelectedItem.Text);
                if ((((DropDownList)fvEmployee.FindControl("ddlDLType")).SelectedValue) != "0")
                    m_objEmployee.Drivers_License_Type = Convert.ToString(((DropDownList)fvEmployee.FindControl("ddlDLType")).SelectedItem.Text);
                m_objEmployee.Drivers_License_Restrictions = Convert.ToString(((TextBox)fvEmployee.FindControl("txtRDS")).Text);
                if (((TextBox)fvEmployee.FindControl("txtDateIssued")).Text != string.Empty)
                    m_objEmployee.Drivers_License_Issued = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDateIssued")).Text);
                m_objEmployee.Drivers_License_Number = Convert.ToString(((TextBox)fvEmployee.FindControl("txtDLN")).Text);
                m_objEmployee.Drivers_License_Class = Convert.ToString(((TextBox)fvEmployee.FindControl("txtDLC")).Text);
                m_objEmployee.Drivers_License_Endorsements = Convert.ToString(((TextBox)fvEmployee.FindControl("txtDLE")).Text);
                if (((TextBox)fvEmployee.FindControl("txtDateExpired")).Text != string.Empty)
                    m_objEmployee.Drivers_License_Expires = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDateExpired")).Text);
                m_objEmployee.Job_Title = Convert.ToString(((TextBox)fvEmployee.FindControl("txtJobtitle")).Text);
                if (((TextBox)fvEmployee.FindControl("txtSalary")).Text != string.Empty)
                    m_objEmployee.Salary = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtSalary")).Text);
                if (((TextBox)fvEmployee.FindControl("txtSupId")).Text != string.Empty)
                    m_objEmployee.Supervisor = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtSupId")).Text);
                if (((TextBox)fvEmployee.FindControl("txtHireDate")).Text != string.Empty)
                    m_objEmployee.Hire_Date = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtHireDate")).Text);
                m_objEmployee.Inactive = Convert.ToString(((TextBox)fvEmployee.FindControl("txtActive")).Text);
                if (((TextBox)fvEmployee.FindControl("txtCCId")).Text != string.Empty)
                    m_objEmployee.FK_Cost_Center = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtCCId")).Text);
                m_objEmployee.Occupation_Description = Convert.ToString(((TextBox)fvEmployee.FindControl("txtOccuDesc")).Text);
                m_objEmployee.Work_Phone = Convert.ToString(((TextBox)fvEmployee.FindControl("txtWorkTeleNo")).Text);
                if ((((DropDownList)fvEmployee.FindControl("ddlJobClassification")).SelectedValue) != "0")
                    m_objEmployee.FK_Job_Classification = Convert.ToDecimal(((DropDownList)fvEmployee.FindControl("ddlJobClassification")).SelectedValue);
                m_objEmployee.Email = Convert.ToString(((TextBox)fvEmployee.FindControl("txtEmail")).Text);
                m_objEmployee.Update_Date = System.DateTime.Now;
                m_objEmployee.Updated_By = Session["UserID"].ToString();

                m_intRetval = m_objEmployee.Employee_InsertUpdate(m_objEmployee);
                if (m_intRetval >= 0)
                {
                    mvEmployee.ActiveViewIndex = 0;
                    gvEmployee.DataSource = BindEmployee();
                    gvEmployee.DataBind();
                }

            }
            else
            {
                ViewState["PreventAdd"] = "N";
                mvEmployee.ActiveViewIndex = 0;
                gvEmployee.DataSource = BindEmployee();
                gvEmployee.DataBind();
            }
            dvSearch.Visible = true;

        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {

            mvEmployee.ActiveViewIndex = 0;
            gvEmployee.DataSource = BindEmployee();
            gvEmployee.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
                dvSearch.Visible = false;
                mvEmployee.ActiveViewIndex = 1;
                m_intEmployeeId = Convert.ToInt32(e.CommandArgument.ToString());
            }
            if (e.CommandName == "EditItem")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.Edit);
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }

            }
            else if (e.CommandName == "View")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.ReadOnly);
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                btnRemove.Visible = false;
                btnMail.Visible = false;
            }
        }
        catch (Exception ex)
        {
          //  throw ex;
        }
    }
    protected void gvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["Edit"].ToString() == "True")
            {
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = true;
            }
            else
            {
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = false;
            }
            if (ViewState["View"].ToString() == "True")
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = true;
            }
            else
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = false;
            }
        }
    }
    protected void gvEmployee_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstEmployee = new List<RIMS_Base.cEmployee>();
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            // Changes the sort direction 
            else
            {
                if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                    ViewState["sortDirection"] = SortDirection.Descending;
                else
                    ViewState["sortDirection"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = strSortExp = e.SortExpression;

            lstEmployee = BindEmployee();
            if (ViewState["SortExp"] != null)
                lstEmployee.Sort(new RIMS_Base.GenericComparer<RIMS_Base.cEmployee>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvEmployee.DataSource = lstEmployee;
            gvEmployee.DataBind();
        }
        catch (Exception ex)
        {
           // throw ex;
        }
    }
    protected void fvEmployee_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvEmployee.CurrentMode != FormViewMode.ReadOnly)
            {
                ((TextBox)fvEmployee.FindControl("txtCurrentDate")).Text = DateTime.Now.ToShortDateString();
                ((DropDownList)fvEmployee.FindControl("ddlMaritalStatus")).DataSource = GetMaritalStatus();
                ((DropDownList)fvEmployee.FindControl("ddlMaritalStatus")).DataTextField = "MaritalStatus";
                ((DropDownList)fvEmployee.FindControl("ddlMaritalStatus")).DataValueField = "FK_Marital_Status";
                ((DropDownList)fvEmployee.FindControl("ddlMaritalStatus")).DataBind();
                m_lstCommon = new ListItem("--Select Marital Status--", "0");
                ((DropDownList)fvEmployee.FindControl("ddlMaritalStatus")).Items.Insert(0, m_lstCommon);


                ((DropDownList)fvEmployee.FindControl("ddlState")).DataSource = GetState();
                ((DropDownList)fvEmployee.FindControl("ddlState")).DataTextField = "FLD_state";
                ((DropDownList)fvEmployee.FindControl("ddlState")).DataValueField = "PK_ID";
                ((DropDownList)fvEmployee.FindControl("ddlState")).DataBind();
                m_lstCommon = new ListItem("--Select State--", "0");
                ((DropDownList)fvEmployee.FindControl("ddlState")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvEmployee.FindControl("ddlDLState")).DataSource = GetDState();
                ((DropDownList)fvEmployee.FindControl("ddlDLState")).DataTextField = "FLD_state";
                ((DropDownList)fvEmployee.FindControl("ddlDLState")).DataValueField = "FLD_state";
                ((DropDownList)fvEmployee.FindControl("ddlDLState")).DataBind();
                m_lstCommon = new ListItem("--Select License State--", "0");
                ((DropDownList)fvEmployee.FindControl("ddlDLState")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvEmployee.FindControl("ddlDLType")).DataSource = GetLicenseType();
                ((DropDownList)fvEmployee.FindControl("ddlDLType")).DataTextField = "LicenseType";
                ((DropDownList)fvEmployee.FindControl("ddlDLType")).DataValueField = "LicenseType";
                ((DropDownList)fvEmployee.FindControl("ddlDLType")).DataBind();
                m_lstCommon = new ListItem("--Select License Type--", "0");
                ((DropDownList)fvEmployee.FindControl("ddlDLType")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvEmployee.FindControl("ddlJobClassification")).DataSource = GetJobClassification();
                ((DropDownList)fvEmployee.FindControl("ddlJobClassification")).DataTextField = "JobClassfication";
                ((DropDownList)fvEmployee.FindControl("ddlJobClassification")).DataValueField = "FK_Job_Classification";
                ((DropDownList)fvEmployee.FindControl("ddlJobClassification")).DataBind();
                m_lstCommon = new ListItem("--Select Job Classification--", "0");
                ((DropDownList)fvEmployee.FindControl("ddlJobClassification")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvEmployee.FindControl("ddlAttachType")).DataSource = GetAttachmentType();
                ((DropDownList)fvEmployee.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvEmployee.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
                ((DropDownList)fvEmployee.FindControl("ddlAttachType")).DataBind();
                m_lstCommon = new ListItem("--Select Attachment Type--", "0");
                ((DropDownList)fvEmployee.FindControl("ddlAttachType")).Items.Insert(0, m_lstCommon);
                ((DropDownList)fvEmployee.FindControl("ddlAttachType")).SelectedValue = "1";


            }

            if (fvEmployee.CurrentMode == FormViewMode.Edit)
            {
                ((DropDownList)fvEmployee.FindControl("ddlMaritalStatus")).SelectedValue = lstEmployee[0].FK_Marital_Status.ToString();
                ((DropDownList)fvEmployee.FindControl("ddlState")).SelectedValue = lstEmployee[0].Employee_State.ToString();
                if (lstEmployee[0].Drivers_License_Type.ToString() != string.Empty)
                    ((DropDownList)fvEmployee.FindControl("ddlDLType")).SelectedValue = lstEmployee[0].Drivers_License_Type.ToString();

                if (lstEmployee[0].FK_Job_Classification.ToString() != string.Empty)
                    ((DropDownList)fvEmployee.FindControl("ddlJobClassification")).SelectedValue = lstEmployee[0].FK_Job_Classification.ToString();
                if (lstEmployee[0].Drivers_License_State.ToString() != string.Empty)
                    ((DropDownList)fvEmployee.FindControl("ddlDLState")).SelectedValue = lstEmployee[0].Drivers_License_State.ToString();
                ((RadioButtonList)fvEmployee.FindControl("rdlSex")).SelectedValue = lstEmployee[0].Sex;

            }
            if (fvEmployee.CurrentMode == FormViewMode.ReadOnly)
            {
                gvAttachmentDetails.Columns[0].Visible = false;
            }
            else
            {
                gvAttachmentDetails.Columns[0].Visible = true;
            }
            if (fvEmployee.CurrentMode == FormViewMode.ReadOnly)
            {
                ((Label)fvEmployee.FindControl("lblSSN")).Text = RIMS_Base.Biz.CGeneral.Decrypt(lstEmployee[0].Social_Security_Number, true);
            }
            if (fvEmployee.CurrentMode == FormViewMode.Edit)
            {
                ((TextBox)fvEmployee.FindControl("txtSSN")).Text = RIMS_Base.Biz.CGeneral.Decrypt(lstEmployee[0].Social_Security_Number, true);
            }
        }
        catch (Exception ex)
        {
          //  throw ex;
        }
    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvEmployee.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvEmployee.DataSource = BindEmployee();
            gvEmployee.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvEmployee.PageCount.ToString();
            txtPageNo.Text = "1";
            lblEmployeeTotal.Text = "Total Employee Details :" + lstEmployee.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = false;
        if (fvEmployee.CurrentMode == FormViewMode.Insert)
        {
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objEmployee = new RIMS_Base.Biz.cEmployee();
                if (fvEmployee.CurrentMode == FormViewMode.Insert)
                {
                    m_objEmployee.PK_Employee_ID = 0;
                }
                else
                {
                    m_objEmployee.PK_Employee_ID = Convert.ToInt32(((Label)fvEmployee.FindControl("lblPkEmployeeId")).Text);
                }
                m_objEmployee.Employee_Id = Convert.ToString(((TextBox)fvEmployee.FindControl("txtEmployeeId")).Text);
                m_objEmployee.First_Name = Convert.ToString(((TextBox)fvEmployee.FindControl("txtFirstName")).Text);
                m_objEmployee.Employee_Address_1 = Convert.ToString(((TextBox)fvEmployee.FindControl("txtAddress1")).Text);
                m_objEmployee.Employee_City = Convert.ToString(((TextBox)fvEmployee.FindControl("txtCity")).Text);
                m_objEmployee.Employee_Zip_Code = Convert.ToString(((TextBox)fvEmployee.FindControl("txtZip")).Text);
                m_objEmployee.Employee_Cell_Phone = Convert.ToString(((TextBox)fvEmployee.FindControl("txtCellTeleNo")).Text);
                m_objEmployee.FK_Marital_Status = Convert.ToDecimal(((DropDownList)fvEmployee.FindControl("ddlMaritalStatus")).SelectedValue);
                if (((TextBox)fvEmployee.FindControl("txtNoOfDependents")).Text != string.Empty)
                    m_objEmployee.Number_Of_Dependents = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtNoOfDependents")).Text);
                if (((TextBox)fvEmployee.FindControl("txtDeathDate")).Text != string.Empty)
                    m_objEmployee.Date_Of_Death = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDeathDate")).Text);
                m_objEmployee.Last_Name = Convert.ToString(((TextBox)fvEmployee.FindControl("txtLastName")).Text);
                m_objEmployee.Middle_Name = Convert.ToString(((TextBox)fvEmployee.FindControl("txtMiddleName")).Text);
                m_objEmployee.Employee_Address_2 = Convert.ToString(((TextBox)fvEmployee.FindControl("txtAddress2")).Text);
                m_objEmployee.Employee_State = Convert.ToDecimal(((DropDownList)fvEmployee.FindControl("ddlState")).SelectedValue);
                m_objEmployee.Employee_Home_Phone = Convert.ToString(((TextBox)fvEmployee.FindControl("txtHomeTeleNo")).Text);
                m_objEmployee.Social_Security_Number = RIMS_Base.Biz.CGeneral.Encrypt(Convert.ToString(((TextBox)fvEmployee.FindControl("txtSSN")).Text), true);
                m_objEmployee.Sex = Convert.ToString(((RadioButtonList)fvEmployee.FindControl("rdlSex")).SelectedValue);
                if (((TextBox)fvEmployee.FindControl("txtDOB")).Text != string.Empty)
                    m_objEmployee.Date_Of_Birth = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDOB")).Text);
                if ((((DropDownList)fvEmployee.FindControl("ddlDLState")).SelectedValue) != "0")
                    m_objEmployee.Drivers_License_State = Convert.ToString(((DropDownList)fvEmployee.FindControl("ddlDLState")).SelectedItem.Text);
                if ((((DropDownList)fvEmployee.FindControl("ddlDLType")).SelectedValue) != "0")
                    m_objEmployee.Drivers_License_Type = Convert.ToString(((DropDownList)fvEmployee.FindControl("ddlDLType")).SelectedItem.Text);
                m_objEmployee.Drivers_License_Restrictions = Convert.ToString(((TextBox)fvEmployee.FindControl("txtRDS")).Text);
                if (((TextBox)fvEmployee.FindControl("txtDateIssued")).Text != string.Empty)
                    m_objEmployee.Drivers_License_Issued = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDateIssued")).Text);
                m_objEmployee.Drivers_License_Number = Convert.ToString(((TextBox)fvEmployee.FindControl("txtDLN")).Text);
                m_objEmployee.Drivers_License_Class = Convert.ToString(((TextBox)fvEmployee.FindControl("txtDLC")).Text);
                m_objEmployee.Drivers_License_Endorsements = Convert.ToString(((TextBox)fvEmployee.FindControl("txtDLE")).Text);
                if (((TextBox)fvEmployee.FindControl("txtDateExpired")).Text != string.Empty)
                    m_objEmployee.Drivers_License_Expires = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDateExpired")).Text);
                m_objEmployee.Job_Title = Convert.ToString(((TextBox)fvEmployee.FindControl("txtJobtitle")).Text);
                if (((TextBox)fvEmployee.FindControl("txtSalary")).Text != string.Empty)
                    m_objEmployee.Salary = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtSalary")).Text);
                if (((TextBox)fvEmployee.FindControl("txtSupId")).Text != string.Empty)
                    m_objEmployee.Supervisor = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtSupId")).Text);
                if (((TextBox)fvEmployee.FindControl("txtHireDate")).Text != string.Empty)
                    m_objEmployee.Hire_Date = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtHireDate")).Text);
                m_objEmployee.Inactive = Convert.ToString(((TextBox)fvEmployee.FindControl("txtActive")).Text);
                if (((TextBox)fvEmployee.FindControl("txtCCId")).Text != string.Empty)
                    m_objEmployee.FK_Cost_Center = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtCCId")).Text);
                m_objEmployee.Occupation_Description = Convert.ToString(((TextBox)fvEmployee.FindControl("txtOccuDesc")).Text);
                m_objEmployee.Work_Phone = Convert.ToString(((TextBox)fvEmployee.FindControl("txtWorkTeleNo")).Text);
                if ((((DropDownList)fvEmployee.FindControl("ddlJobClassification")).SelectedValue) != "0")
                    m_objEmployee.FK_Job_Classification = Convert.ToDecimal(((DropDownList)fvEmployee.FindControl("ddlJobClassification")).SelectedValue);
                m_objEmployee.Email = Convert.ToString(((TextBox)fvEmployee.FindControl("txtEmail")).Text);
                m_objEmployee.Update_Date = System.DateTime.Now;
                m_objEmployee.Updated_By = Session["UserID"].ToString();
                m_intRetval = m_objEmployee.Employee_InsertUpdate(m_objEmployee);
                ((Label)fvEmployee.FindControl("lblPkEmployeeId")).Text = m_intRetval.ToString();
                ViewState["PreventAdd"] = "Y";
            }
            if (m_intRetval >= 0 || ViewState["PreventAdd"].ToString() == "Y")
            {
                dvAttachDetails.Visible = true;

                AddAttachment();
                if (m_intRetval >= 0)
                {
                    gvAttachmentDetails.DataSource = BindAttachmentDetails();
                    gvAttachmentDetails.DataBind();
                    if (lstAttachment.Count > 0)
                    {
                        btnRemove.Visible = true;
                        btnMail.Visible = true;
                    }
                    else
                    {
                        btnRemove.Visible = false;
                        btnMail.Visible = false;
                    }
                }
            }
        }
        else
        {
            dvAttachDetails.Visible = true;
            AddAttachment();
            if (m_intRetval >= 0)
            {
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }
            }
        }



    }
    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                // ((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Employee&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_intRetval = m_objAttachment.DeleteAttachment(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }
            }
            dvAttachDetails.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
        }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvEmployee.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvEmployee.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 iCol = GetSortColumnIndex(strSortExp);
        if (-1 == iCol)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();

        if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }
    #endregion
    #region Private Methods
    /// <summary>
    /// Get the All Vendor's Details
    /// </summary>
    private List<RIMS_Base.cEmployee> BindEmployee()
    {
        m_objEmployee = new RIMS_Base.Biz.cEmployee();
        lstEmployee = new List<RIMS_Base.cEmployee>();
        try
        {
            
            lstEmployee = null;
            if (txtSearch.Text != string.Empty)
            {
                lstEmployee = m_objEmployee.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstEmployee = m_objEmployee.GetAll();
            }
            lblEmployeeTotal.Text = "Total Employee : " + lstEmployee.Count.ToString();
            return lstEmployee;
        }
        catch (Exception ex)
        {
           // throw ex;
            return lstEmployee;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Bind The Attachment Details.
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(((Label)fvEmployee.FindControl("lblPkEmployeeId")).Text), "Employee");
            return lstAttachment;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Get All State.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetState()
    {
        try
        {
            m_objState = new RIMS_Base.Biz.CGeneral();
            lstState = new List<RIMS_Base.CGeneral>();
            lstState = m_objState.GetAllState();
            return lstState;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    private List<RIMS_Base.CGeneral> GetDState()
    {
        try
        {
            m_objDState = new RIMS_Base.Biz.CGeneral();
            lstDState = new List<RIMS_Base.CGeneral>();
            lstDState = m_objDState.GetAllState();
            return lstDState;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    private List<RIMS_Base.cEmployee> GetMaritalStatus()
    {
        try
        {
            m_objMaritalStatus = new RIMS_Base.Biz.cEmployee();
            lstMaritalStatus = new List<RIMS_Base.cEmployee>();
            lstMaritalStatus = m_objMaritalStatus.GetMaritalStatus();
            return lstMaritalStatus;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    private List<RIMS_Base.cEmployee> GetJobClassification()
    {
        try
        {
            m_objJobCls = new RIMS_Base.Biz.cEmployee();
            lstJobCls = new List<RIMS_Base.cEmployee>();
            lstJobCls = m_objJobCls.GetJobClassfication();
            return lstJobCls;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    private List<RIMS_Base.cEmployee> GetLicenseType()
    {
        try
        {
            m_objLicType = new RIMS_Base.Biz.cEmployee();
            lstLicType = new List<RIMS_Base.cEmployee>();
            lstLicType = m_objLicType.GetLicenseType();
            return lstLicType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Get All Attachment Type.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetAttachmentType()
    {
        try
        {
            m_objAttachmentType = new RIMS_Base.Biz.CGeneral();
            lstAttachmentType = new List<RIMS_Base.CGeneral>();
            lstAttachmentType = m_objAttachmentType.GetAttachamentType();
            return lstAttachmentType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    /// <summary>
    /// Bind the Formview Templates.
    /// </summary>
    /// <param name="fvMode"></param>
    private void Bindfv(FormViewMode fvMode)
    {
        try
        {

            if (fvMode == FormViewMode.Insert)
                fvEmployee.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
                fvEmployee.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvEmployee.ChangeMode(FormViewMode.ReadOnly);
            if (fvMode != FormViewMode.Insert)
            {
                dvAttachDetails.Visible = true;
                m_objEmployee = new RIMS_Base.Biz.cEmployee();
                lstEmployee = new List<RIMS_Base.cEmployee>();
                lstEmployee = m_objEmployee.GetEmployeeByID(m_intEmployeeId);
                fvEmployee.DataSource = lstEmployee;

            }
            fvEmployee.DataBind();
        }
        catch (Exception ex)
        {
       //     throw ex;
        }
        finally
        {
        }

    }
    /// <summary>
    /// Upload Documents
    /// </summary>
    private void UploadDocuments()
    {
        try
        {
            m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

            if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
            {
                Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
            }
            m_strFileName = GetCustomFileName() + ((FileUpload)fvEmployee.FindControl("uplCommon")).FileName.ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
            ((FileUpload)fvEmployee.FindControl("uplCommon")).SaveAs(m_strPath);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Get Custom File Name.
    /// </summary>
    /// <returns></returns>
    private string GetCustomFileName()
    {
        try
        {
            m_strCustomFileName = System.DateTime.Now.ToString("MMddyyhhmmss");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_strCustomFileName;
    }
    /// <summary>
    /// Insert Attachment in Database.
    /// </summary>
    /// <returns>Integer</returns>
    private int AddAttachment()
    {
        try
        {
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "Employee";
            m_objAttachment.Foreign_Key = Convert.ToInt32(((Label)fvEmployee.FindControl("lblPkEmployeeId")).Text);
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvEmployee.FindControl("ddlAttachType")).SelectedValue);
            m_objAttachment.Attachment_Description = ((TextBox)fvEmployee.FindControl("txtDescription")).Text;
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = Session["UserID"].ToString();
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            m_intRetval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);
            ((TextBox)fvEmployee.FindControl("txtDescription")).Text = string.Empty;
            ((DropDownList)fvEmployee.FindControl("ddlAttachType")).SelectedValue = "1";

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_intRetval;
    }
    private void GeneralSorting()
    {
        try
        {
            lstEmployee = new List<RIMS_Base.cEmployee>();
            lstEmployee = BindEmployee();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
                lstEmployee.Sort(new RIMS_Base.GenericComparer<RIMS_Base.cEmployee>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvEmployee.DataSource = lstEmployee;
            gvEmployee.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    #endregion
}
