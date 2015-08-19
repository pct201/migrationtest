using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.IO;

public partial class UserAccessRequestForm : System.Web.UI.Page
{
    private int saveCount;

    private string strTick = "data:image/gif;base64,R0lGODlhDQANAHAAACH5BAEAAPwALAAAAAANAA0AhwAAAAAAMwAAZgAAmQAAzAAA/wArAAArMwArZgArmQArzAAr/wBVAABVMwBVZgBVmQBVzABV/wCAAACAMwCAZgCAmQCAzACA/wCqAACqMwCqZgCqmQCqzACq/wDVAADVMwDVZgDVmQDVzADV/wD/AAD/MwD/ZgD/mQD/zAD//zMAADMAMzMAZjMAmTMAzDMA/zMrADMrMzMrZjMrmTMrzDMr/zNVADNVMzNVZjNVmTNVzDNV/zOAADOAMzOAZjOAmTOAzDOA/zOqADOqMzOqZjOqmTOqzDOq/zPVADPVMzPVZjPVmTPVzDPV/zP/ADP/MzP/ZjP/mTP/zDP//2YAAGYAM2YAZmYAmWYAzGYA/2YrAGYrM2YrZmYrmWYrzGYr/2ZVAGZVM2ZVZmZVmWZVzGZV/2aAAGaAM2aAZmaAmWaAzGaA/2aqAGaqM2aqZmaqmWaqzGaq/2bVAGbVM2bVZmbVmWbVzGbV/2b/AGb/M2b/Zmb/mWb/zGb//5kAAJkAM5kAZpkAmZkAzJkA/5krAJkrM5krZpkrmZkrzJkr/5lVAJlVM5lVZplVmZlVzJlV/5mAAJmAM5mAZpmAmZmAzJmA/5mqAJmqM5mqZpmqmZmqzJmq/5nVAJnVM5nVZpnVmZnVzJnV/5n/AJn/M5n/Zpn/mZn/zJn//8wAAMwAM8wAZswAmcwAzMwA/8wrAMwrM8wrZswrmcwrzMwr/8xVAMxVM8xVZsxVmcxVzMxV/8yAAMyAM8yAZsyAmcyAzMyA/8yqAMyqM8yqZsyqmcyqzMyq/8zVAMzVM8zVZszVmczVzMzV/8z/AMz/M8z/Zsz/mcz/zMz///8AAP8AM/8AZv8Amf8AzP8A//8rAP8rM/8rZv8rmf8rzP8r//9VAP9VM/9VZv9Vmf9VzP9V//+AAP+AM/+AZv+Amf+AzP+A//+qAP+qM/+qZv+qmf+qzP+q///VAP/VM//VZv/Vmf/VzP/V////AP//M///Zv//mf//zP///wAAAAAAAAAAAAAAAAh0APcJHEhwHzFlMWIAUMjQgEIAygCgUZaJWCZlFhWK2QeAWEGEkwDc4JiJYL0bMfbFGNkRmsd9KD3G2NgxU4xMmQBMEriSZMSEI3mm7LgvJICSPFmWJAZg48AVLJUJhFZwJsemN8QkXClmoUGckzKFFStWakAAOw==";
    private string strClose = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA8AAAAMCAYAAAC9QufkAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAE/SURBVChTjVJNisJQDE7/wK0HcO+uF6gn6DG8j97AlYvCFGfZnTs3IwhCwQMIKqWCxf7S1sz74ujGjjMfpMn7ku8lvEZrmoYNwyBgv9+TrusSd+F2u9FgMCBmllhr25YhcF2XNpsNWZYlyS6UZUmjkUOLxaeI8WFcoHIcx7HS3VEUBed5Lgag5nA4SB00MBEDIKuq4vX6i33fF+4Bz/N4u92y6sxqMuFexGmacl3XEs/nc+Fns5mcgev1+rs4SRKJ4XEej8fiH6NfLpe/xQA6g/P9jx/mn+LJZMK9Xo+Px6MUT6dT4d+K8WBBEEh8Pp+FP51Ocl4uly8PpskNCvjXikP4FqZpklosqX0uSb/fJ9u2SY1Lmqbdk8oDyMOyLKMwDCmKIkxMz/Xc7Xa0Wq1kw4CuKdDRcRwaDofUti19A4ZTotVg3vxNAAAAAElFTkSuQmCC";

    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_U_A_Request
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_U_A_Request"]);
        }
        set { ViewState["PK_U_A_Request"] = value; }
    }
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

    ///// <summary>
    ///// Get and Set Security ID
    ///// </summary>
    //private Int32 SecurityID
    //{
    //    get { return (!clsGeneral.IsNull(ViewState["SecurityID"]) ? Convert.ToInt32(ViewState["SecurityID"]) : 0); }
    //    set { ViewState["SecurityID"] = value; }
    //}

    ///// <summary>
    ///// Contains Dairy related Right id
    ///// </summary>
    //private Int32 DiaryRightId
    //{
    //    get { return (!clsGeneral.IsNull(ViewState["DiaryRightId"]) ? Convert.ToInt32(ViewState["DiaryRightId"]) : 0); }
    //    set { ViewState["DiaryRightId"] = value; }
    //}

    #endregion

    #region "Main Events"

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["Requester"] != null)
        {
            this.MasterPageFile = "~/UserAccessRequestForm.master";
        }
        else
        {
            this.MasterPageFile = "~/Default.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Requester"] != null)
            {
                DivViewAccessUser.Style.Add("display", "none");
                divViewAccessUserList.Style.Add("display", "none");
                DivEditAccessUser.Style.Add("display", "block");
                divModifyAccessUser.Style.Add("display", "block");
                BindLocations(false, null);
                FillDropdown();
                HdnEmployeeID.Value = "0";
                PK_U_A_Request = 0;
                btnSave.Text = "Submit";
                btnCancel.Text = "Return";
            }
            else
            {
                if (!string.IsNullOrEmpty(clsSession.UserID))
                {
                    divViewAccessUserList.Style.Add("display", "block");
                    divModifyAccessUser.Style.Add("display", "none");           
                 
                }
                else
                {
                    string str = "<script>window.location = '" + AppConfig.SiteURL + "SignIn.aspx'</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
                }
            }

            FillDropdown();
            txtFirstName.Focus();
            ClearControlValues();
            // set the default sort field and sort order
            SortBy = "S.[Created_Date]";
            SortOrder = "DESC";

            //Bind Admin Grid
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);



        }
        //Set ListBox ToolTip
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstLocationsAvailable, lstSelectedFields });


    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Add new User
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    ///     
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        DivViewAccessUser.Style.Add("display", "none");
        divViewAccessUserList.Style.Add("display", "none");
        DivEditAccessUser.Style.Add("display", "block");
        divModifyAccessUser.Style.Add("display", "block");
        BindLocations(false, null);
        FillDropdown();
        HdnEmployeeID.Value = "0";

        ClearControlValues();

    }


    /// <summary>
    /// Save User
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    ///     
    protected void btnSave_Click(object sender, EventArgs e)
    {
        saveCount = 1;

        U_A_Request u_a_request = new U_A_Request(PK_U_A_Request);

        u_a_request.PK_U_A_Request = PK_U_A_Request;
        u_a_request.First_Name = txtFirstName.Text.Trim().Replace("'", "\'");
        u_a_request.Last_Name = txtLastName.Text.Trim().Replace("'", "\'");
        u_a_request.Email = txtEmail.Text.Trim().Replace("'", "\'");
        u_a_request.Telephone = txtTelephone.Text.ToString();

        if (ddlDealership.SelectedIndex > 0)
            u_a_request.FK_LU_Location = Convert.ToInt32(ddlDealership.SelectedValue);
        else
            u_a_request.FK_LU_Location = null;


        if (rdlSA_EA_Associate.SelectedValue == "1")
            u_a_request.SA_EA_Associate = true;
        else if (rdlSA_EA_Associate.SelectedValue == "")
            u_a_request.SA_EA_Associate = false;

        u_a_request.FK_Employee = (HdnEmployeeID.Value.ToString() != string.Empty) ? Convert.ToDecimal(HdnEmployeeID.Value) : 0;

        if (chkGeneral_Manager.Checked)
            u_a_request.General_Manager = true;
        else
            u_a_request.General_Manager = false;

        if (chkController.Checked)
            u_a_request.Controller = true;
        else
            u_a_request.Controller = false;

        if (chkService.Checked)
            u_a_request.Service = true;
        else
            u_a_request.Service = false;

        if (chkSales.Checked)
            u_a_request.Sales = true;
        else
            u_a_request.Sales = false;

        if (chkParts.Checked)
            u_a_request.Parts = true;
        else
            u_a_request.Parts = false;

        if (chkBusiness_Office.Checked)
            u_a_request.Business_Office = true;

        else
            u_a_request.Business_Office = false;

        if (chkHome_Office.Checked)
        {
            u_a_request.Home_Office = true;
            u_a_request.Home_Office_Text = txtHome_Office_Text.Text;
        }
        else
        {
            u_a_request.Home_Office = false;
            u_a_request.Home_Office_Text = string.Empty;
        }
        if (chkField_Operastions.Checked)
        {
            u_a_request.Field_Operastions = true;
            u_a_request.Field_Operations_Text = txtField_Operations_Text.Text;
        }
        else
        {
            u_a_request.Field_Operastions = false;
            u_a_request.Field_Operations_Text = string.Empty;
        }

        u_a_request.Reason_For_Access = ctrlReason_For_Access.Text;

        if (rdlRegional_Market_Area_Associate.SelectedValue == "1")
            u_a_request.Regional_Market_Area_Associate = true;
        else
            u_a_request.Regional_Market_Area_Associate = false;

        if (rdlMultiple_Locations.SelectedValue == "1")
            u_a_request.Multiple_Locations = true;
        else
            u_a_request.Multiple_Locations = false;

        if (rdlBuilding_Access.SelectedValue == "1")
            u_a_request.Building_Access = true;
        else
            u_a_request.Building_Access = false;

        if (rdlE_S_H_Access.SelectedValue == "1")
            u_a_request.E_S_H_Access = true;
        else
            u_a_request.E_S_H_Access = false;

        if (rdlClaim_Report_Access.SelectedValue == "1")
            u_a_request.Claim_Report_Access = true;
        else
            u_a_request.Claim_Report_Access = false;

        if (rdlClaim_View_Access.SelectedValue == "1")
            u_a_request.Claim_View_Access = true;
        else
            u_a_request.Claim_View_Access = false;

        if (rdlSecurity_Access.SelectedValue == "1")
            u_a_request.Security_Access = true;
        else
            u_a_request.Security_Access = false;

        if (rdlSLT_Access.SelectedValue == "1")
            u_a_request.SLT_Access = true;
        else
            u_a_request.SLT_Access = false;

        if (rdlFacilities_Construction_Access.SelectedValue == "1")
            u_a_request.Facilities_Construction_Access = true;
        else
            u_a_request.Facilities_Construction_Access = false;

        if (!string.IsNullOrEmpty(clsSession.UserID))
            u_a_request.Updated_By = clsSession.UserID;
        else
            u_a_request.Updated_By = "New User";

        u_a_request.Update_Date = DateTime.Now;

        if (PK_U_A_Request == 0)
            u_a_request.Created_Date = DateTime.Now;


        //u_a_request.Deny = null;

        if (PK_U_A_Request > 0)
        {
            PK_U_A_Request = u_a_request.Update();
            if (PK_U_A_Request == -2)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "NameExists", "alert('FirstName and LastName Already Exists.');", true);
                return;
            }

        }
        else
        {
            PK_U_A_Request = u_a_request.Insert();

            if (PK_U_A_Request == -2)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "NameExists", "alert('FirstName and LastName Already Exists.');", true);
                return;
            }

        }


        if (PK_U_A_Request > 0)
        {
            //Loop for inserting Locations Available

            U_A_Request_Locations.DeleteByUser(PK_U_A_Request);

            foreach (ListItem Li in lstSelectedFields.Items)
            {
                U_A_Request_Locations objU_A_Request_Locations = new U_A_Request_Locations();
                objU_A_Request_Locations.FK_U_A_Request = PK_U_A_Request;
                objU_A_Request_Locations.FK_LU_Location = Convert.ToInt32(Li.Value);
                objU_A_Request_Locations.Insert();
            }


            if (Request.QueryString["Requester"] != null)
            {
                if (SendUserRequestMail())
                {                    
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Report Submitted successfully but due to technical problem Mail can not be send at this time, Please try to resend.'); window.location='UserAccessRequestForm.aspx';", true);
                }
            }
        }

        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        btnCancel_Click(sender, e);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Requester"] != null)
        {
            if (saveCount == 1)
            {
                saveCount = 0;
                string str = "<script>alert(\"Your request has been submitted successfully.\"); window.location = '" + AppConfig.SiteURL + "SignIn.aspx'</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
            }
            else
            {
                string str = "<script>window.location = '" + AppConfig.SiteURL + "SignIn.aspx'</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
            }
        }
        else
        {
            divViewAccessUserList.Style.Add("display", "block");
            divModifyAccessUser.Style.Add("display", "none");
            ClearControlValues();
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControlValues();
    }

    protected void btnPromote_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("FirstName");
        dt.Columns.Add("LastName");
        dt.Columns.Add("EMail");
        dt.Columns.Add("Telephone");
        dt.Columns.Add("EmployeeId");
        dt.Columns.Add("EmployeeName");
        dt.Columns.Add("PK_U_A_Request");
        dt.Rows.Add(lblFirstName.Text, lblLastName.Text, lblEmail.Text, lblTelephone.Text, lblEmployeeId.Text, lblAssociateName.Text, PK_U_A_Request);
        Session["dtPromote"] = dt;
        Response.Redirect(AppConfig.SiteURL + "Administrator/security.aspx");
    }
    protected void btnDeny_Click(object sender, EventArgs e)
    {
        U_A_Request u_a_request = new U_A_Request(PK_U_A_Request);
        u_a_request.Deny = true;
        u_a_request.Update_Date = DateTime.Now;
        if (!string.IsNullOrEmpty(clsSession.UserID))
            u_a_request.Updated_By = clsSession.UserID;
        else
            u_a_request.Updated_By = "New User";

        if (PK_U_A_Request > 0)
        {
            u_a_request.Update();
            DenyAccessMail();
        }

        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);


        btnCancel_Click(sender, e);

    }


    #endregion

    #region "Methods"
    private void ClearControlValues()
    {
        txtFirstName.Text = txtLastName.Text = txtEmail.Text = txtTelephone.Text = ctrlReason_For_Access.Text = txtHome_Office_Text.Text = txtField_Operations_Text.Text = "";
        ddlDealership.SelectedIndex = -1;
        rdlSA_EA_Associate.SelectedIndex = -1;
        chkGeneral_Manager.Checked = chkService.Checked = chkHome_Office.Checked = chkParts.Checked = false;
        chkController.Checked = chkSales.Checked = chkBusiness_Office.Checked = chkField_Operastions.Checked = false;

        rdlRegional_Market_Area_Associate.SelectedIndex = rdlMultiple_Locations.SelectedIndex = rdlBuilding_Access.SelectedIndex =
        rdlE_S_H_Access.SelectedIndex = rdlClaim_Report_Access.SelectedIndex = rdlSecurity_Access.SelectedIndex = rdlSLT_Access.SelectedIndex =
        rdlClaim_View_Access.SelectedIndex = -1;

    }

    private void ShowHideHomeOffice()
    {
        if (chkHome_Office.Checked)
        {
            tdHomeOffice.Style["display"] = "";
        }
        else
            tdHomeOffice.Style["display"] = "none";

        if (chkHome_OfficeView.Checked)
            tdHome_Office_TextView.Style["display"] = "";
        else
            tdHome_Office_TextView.Style["display"] = "none";
    }

    private void ShowHideFieldOperation()
    {
        if (chkField_Operastions.Checked)
        {
            tdFieldOperations.Style["display"] = "";
        }
        else
            tdFieldOperations.Style["display"] = "none";

        if (chkField_OperastionsView.Checked)
            tdFieldOperationsView.Style["display"] = "";
        else
            tdFieldOperationsView.Style["display"] = "none";
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly
        if (SortDirection.Ascending.ToString() == strSortOrder)
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

    /// <summary>
    /// Returns the index of the column which contains particular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvUserAccess.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvUserAccess.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {

        DataSet dsAdmin = U_A_Request.SelectAll(txtSearch.Text.Trim().Replace("'", "''"), SortBy, SortOrder, PageNumber, PageSize);
        DataTable dtAdminData = dsAdmin.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[2].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dtAdminData.Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        // bind the grid.
        gvUserAccess.DataSource = dtAdminData;
        gvUserAccess.DataBind();

        // set record numbers retrieved
        lblNumber.Text = (dsAdmin.Tables.Count >= 3) ? Convert.ToString(dsAdmin.Tables[1].Rows[0][0]) : "0";
    }

    /// <summary>
    /// Used to Populate values to controls for Editing
    /// </summary>
    private void EditRecord()
    {
        btnSave.Enabled = true;
        DivViewAccessUser.Style.Add("display", "none");
        DivEditAccessUser.Style.Add("display", "block");
        btnSave.Visible = true;

        // Create an Object
        U_A_Request objU_A_Request = new U_A_Request(PK_U_A_Request);

        txtFirstName.Text = Convert.ToString(objU_A_Request.First_Name);
        txtLastName.Text = Convert.ToString(objU_A_Request.Last_Name);
        txtEmail.Text = Convert.ToString(objU_A_Request.Email);
        txtTelephone.Text = Convert.ToString(objU_A_Request.Telephone);
        if (!string.IsNullOrEmpty(objU_A_Request.FK_LU_Location.ToString()))
        {
            ddlDealership.SelectedValue = Convert.ToString(objU_A_Request.FK_LU_Location);
            DataSet ds = LU_Location.SelectStateMarketByLocationID(Convert.ToDecimal(objU_A_Request.FK_LU_Location));
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                lblMarketEdit.Text = Convert.ToString(dt.Rows[0]["Market"]);
                lblStateEdit.Text = Convert.ToString(dt.Rows[0]["State"]);
            }
        }
        else
        {
            ddlDealership.SelectedIndex = -1;
            lblMarketEdit.Text = "";
            lblStateEdit.Text = "";
        }

        //chkAllowClaimInfo.Checked = objSecurity.Allow_ViewClaim;
        if (objU_A_Request.FK_Employee != null)
        {
            if (Convert.ToDecimal(objU_A_Request.FK_Employee) > 0)
            {

                Employee objEmp = new Employee(Convert.ToDecimal(objU_A_Request.FK_Employee));
                string emp_name = string.Empty;

                if (objEmp.First_Name != null)
                    emp_name = Convert.ToString(objEmp.First_Name).Trim() + ", ";

                if (objEmp.Middle_Name != null)
                    emp_name += Convert.ToString(objEmp.Middle_Name).Trim() + " ";

                if (objEmp.Last_Name != null)
                    emp_name += Convert.ToString(objEmp.Last_Name).Trim();

                if (Convert.ToDecimal(objEmp.PK_Employee_ID) > 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "AssignValue('" + emp_name.ToString() + "','" + objSecurity.Employee_Id + "');", true);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "AssignValue('" + emp_name.ToString().Replace("'", "\\'").Trim() + "','" + objU_A_Request.FK_Employee + "');", true);
                }

            }
            rdlSA_EA_Associate.SelectedValue = objU_A_Request.SA_EA_Associate == true ? "1" : "0";
            chkGeneral_Manager.Checked = Convert.ToBoolean(objU_A_Request.General_Manager);
            chkController.Checked = Convert.ToBoolean(objU_A_Request.Controller);
            chkService.Checked = Convert.ToBoolean(objU_A_Request.Service);
            chkSales.Checked = Convert.ToBoolean(objU_A_Request.Sales);
            chkParts.Checked = Convert.ToBoolean(objU_A_Request.Parts);
            chkBusiness_Office.Checked = Convert.ToBoolean(objU_A_Request.Business_Office);
            chkHome_Office.Checked = Convert.ToBoolean(objU_A_Request.Home_Office);
            chkField_Operastions.Checked = Convert.ToBoolean(objU_A_Request.Field_Operastions);
            txtHome_Office_Text.Text = objU_A_Request.Home_Office_Text;

            txtField_Operations_Text.Text = objU_A_Request.Field_Operations_Text;
            ctrlReason_For_Access.Text = objU_A_Request.Reason_For_Access;
            rdlRegional_Market_Area_Associate.SelectedValue = objU_A_Request.Regional_Market_Area_Associate == true ? "1" : "0";
            rdlMultiple_Locations.SelectedValue = objU_A_Request.Multiple_Locations == true ? "1" : "0";
            rdlBuilding_Access.SelectedValue = objU_A_Request.Building_Access == true ? "1" : "0";
            rdlE_S_H_Access.SelectedValue = objU_A_Request.E_S_H_Access == true ? "1" : "0";
            rdlClaim_Report_Access.SelectedValue = objU_A_Request.Claim_Report_Access == true ? "1" : "0";
            rdlClaim_View_Access.SelectedValue = objU_A_Request.Claim_View_Access == true ? "1" : "0";
            rdlSecurity_Access.SelectedValue = objU_A_Request.Security_Access == true ? "1" : "0";
            rdlSLT_Access.SelectedValue = objU_A_Request.SLT_Access == true ? "1" : "0";
            rdlFacilities_Construction_Access.SelectedValue = objU_A_Request.Facilities_Construction_Access == true ? "1" : "0";

            ShowHideHomeOffice();
            ShowHideFieldOperation();

            BindLocations(true, null);

        }

    }

    /// <summary>
    /// used to populate value to controls for View
    /// </summary>
    private void ViewRecord()
    {
        DivViewAccessUser.Style.Add("display", "block");
        DivEditAccessUser.Style.Add("display", "none");
        btnSave.Visible = false;
        U_A_Request objU_A_Request = new U_A_Request(PK_U_A_Request);

        lblFirstName.Text = Convert.ToString(objU_A_Request.First_Name);
        lblLastName.Text = Convert.ToString(objU_A_Request.Last_Name);
        lblEmail.Text = Convert.ToString(objU_A_Request.Email);
        lblTelephone.Text = Convert.ToString(objU_A_Request.Telephone);
        if (objU_A_Request.FK_Employee != null)
        {
            lblEmployeeId.Text = Convert.ToString(objU_A_Request.FK_Employee);
            if (Convert.ToDecimal(objU_A_Request.FK_Employee) > 0)
            {
                Employee objEmp = new Employee(Convert.ToDecimal(objU_A_Request.FK_Employee));
                string emp_name = string.Empty;
                if (objEmp.First_Name != null)
                    emp_name = Convert.ToString(objEmp.First_Name).Trim() + ", ";
                if (objEmp.Middle_Name != null)
                    emp_name += Convert.ToString(objEmp.Middle_Name).Trim() + " ";
                if (objEmp.Last_Name != null)
                    emp_name += Convert.ToString(objEmp.Last_Name).Trim();

                lblAssociateName.Text = emp_name;
            }
            else
            {
                lblAssociateName.Text = "";
            }
        }

        if (!string.IsNullOrEmpty(objU_A_Request.FK_LU_Location.ToString()))
        {
            DataSet ds = LU_Location.SelectStateMarketByLocationID(Convert.ToDecimal(objU_A_Request.FK_LU_Location));
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                lblMarket.Text = Convert.ToString(dt.Rows[0]["Market"]);
                lblState.Text = Convert.ToString(dt.Rows[0]["State"]);
            }
            else
            {
                lblMarket.Text = "";
                lblState.Text = "";
            }
        }

        if (objU_A_Request.FK_LU_Location.ToString() != "")
        {
            DataSet ds = LU_Location.SelectAllDealershipByUserAndLocationId(Convert.ToDecimal(objU_A_Request.FK_LU_Location));
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblDealership.Text = Convert.ToString(dt.Rows[0]["Dealership"]);
            }
        }
        else
        {
            lblDealership.Text = "";
        }

        lblSA_EA_Associate.Text = objU_A_Request.SA_EA_Associate == true ? "Yes" : "No";
        chkGeneral_ManagerView.Checked = Convert.ToBoolean(objU_A_Request.General_Manager);
        chkControllerView.Checked = Convert.ToBoolean(objU_A_Request.Controller);
        chkServiceView.Checked = Convert.ToBoolean(objU_A_Request.Service);
        chkSalesView.Checked = Convert.ToBoolean(objU_A_Request.Sales);
        chkPartsView.Checked = Convert.ToBoolean(objU_A_Request.Parts);
        chkBusiness_OfficeView.Checked = Convert.ToBoolean(objU_A_Request.Business_Office);
        chkHome_OfficeView.Checked = Convert.ToBoolean(objU_A_Request.Home_Office);
        lblHome_Office_Text.Text = objU_A_Request.Home_Office_Text;
        lblField_Operations_Text.Text = objU_A_Request.Field_Operations_Text;
        chkField_OperastionsView.Checked = Convert.ToBoolean(objU_A_Request.Field_Operastions);
        ctrlReason_For_AccessView.Text = objU_A_Request.Reason_For_Access;
        lblRegional_Market_Area_Associate.Text = objU_A_Request.Regional_Market_Area_Associate == true ? "Yes" : "No";
        lblMultiple_Locations.Text = objU_A_Request.Multiple_Locations == true ? "Yes" : "No";
        lblBuilding_Access.Text = objU_A_Request.Building_Access == true ? "Yes" : "No";
        lblE_S_H_Access.Text = objU_A_Request.E_S_H_Access == true ? "Yes" : "No";
        lblClaim_Report_Access.Text = objU_A_Request.Claim_Report_Access == true ? "Yes" : "No";
        lblClaim_View_Access.Text = objU_A_Request.Claim_View_Access == true ? "Yes" : "No";
        lblSecurity_Access.Text = objU_A_Request.Security_Access == true ? "Yes" : "No";
        lblSLT_Access.Text = objU_A_Request.SLT_Access == true ? "Yes" : "No";
        lblFacilities_Construction_Access.Text = objU_A_Request.Facilities_Construction_Access == true ? "Yes" : "No";

        ShowHideHomeOffice();
        ShowHideFieldOperation();
        BindLocationsView();
    }

    public static DataSet Denyit(string firstName, string lastName, string PK_U_A_Request)
    {
        DataSet ds = U_A_Request.SetDenyvalues(firstName, lastName, Convert.ToDecimal(PK_U_A_Request));
        return ds;
    }


    /// <summary>
    /// User Access Request Mail Send Method
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool SendUserRequestMail()
    {
        bool flag = false;
        System.Collections.Generic.List<string> lstMail = new System.Collections.Generic.List<string>();

        //get recipient Id for Database
        //DataTable dtRecipient = Email_Settings.SelectByModuleName("WC").Tables[0];
        DataSet ds = U_A_Request_Admin.SelectAll();
        DataTable dtRecipient = ds.Tables[0];

        int intToMailCount = 0;
        if (dtRecipient.Rows.Count > 0)
        {
            foreach (DataRow drRecipient in dtRecipient.Rows)
            {
                lstMail.Insert(intToMailCount, drRecipient["Admin_EMail"].ToString());
                intToMailCount++;
            }
        }

        string[] EmailTo = lstMail.ToArray();

        //used to send Email
        if (PK_U_A_Request > 0)
        {

            string HtmlBody = GenerateEMailBody();

            //generate FIle and store it on disk
            StreamWriter sWriter = null;
            clsGeneral.CreateDirectory(AppConfig.SitePath + "SONIC-Email/" + "FN" + "_" + "LN" + "/U_A_request/" + DateTime.Today.ToString("MM-dd-yyyy"));
            string strName = AppConfig.SitePath + "SONIC-Email/" + "FN" + "_" + "LN" + "/U_A_request/" + DateTime.Today.ToString("MM-dd-yyyy") + "/U_A_request_Email_" + PK_U_A_Request.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            string strFName = strName + ".html";

            try
            {
                FileStream FS = new FileStream(strFName, FileMode.Create, FileAccess.ReadWrite);
                sWriter = new StreamWriter(FS);
                sWriter.Write(HtmlBody);
            }
            finally
            {
                if (sWriter != null)
                {
                    sWriter.Close();
                }
            }


            if (EmailTo.Length > 0)
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));

                objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "New eRIMS2 User Access Request", HtmlBody, true, new string[] { }, string.Empty);

                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }
        else
            return false;

    }

    /// <summary>
    /// User Access Request Mail Send Method
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool DenyAccessMail()
    {
        bool flag = false;

        //used to send Email
        if (PK_U_A_Request > 0)
        {
            U_A_Request objU_A_Request = new U_A_Request(PK_U_A_Request);
            string[] EmailTo = { objU_A_Request.Email };

            string HtmlBody = "At this time, it was not deemed appropriate to grant you access to Sonic’s eRIMS2.";

            //generate FIle and store it on disk
            clsGeneral.CreateDirectory(AppConfig.SitePath + "SONIC-Email/" + "FN" + "_" + "LN" + "/U_A_request/" + DateTime.Today.ToString("MM-dd-yyyy"));



            if (EmailTo.Length > 0)
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));

                objEmail.SendMailMessage(AppConfig.MailFrom, "Admin", EmailTo, "eRIMS2 Access", HtmlBody, false, null, string.Empty);

                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }
        else
            return false;

    }


    #endregion

    #region Mover Events and Methods - FROI E-Mail Recipients

    /// <summary>
    /// Event to handle Select output fields
    /// </summary>
    protected void btnSelectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstLocationsAvailable, lstSelectedFields, true, true, false);
    }

    /// <summary>
    /// Event to handle Deselect Fields
    /// </summary>
    protected void btnDeselectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSelectedFields, lstLocationsAvailable, true, false, true);
    }

    /// <summary>
    /// Event to Handle select All output fields.
    /// </summary>
    protected void btnSelectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstLocationsAvailable, lstSelectedFields, false, true, false);
    }

    /// <summary>
    /// Event to handle DeSelect All Output Fields.
    /// </summary>
    protected void btnDeselectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstSelectedFields, lstLocationsAvailable, false, false, true);
    }




    /// <summary>
    /// Move Output Fields from One List to Another List and add/Remove From Sort and group by DropDown
    /// </summary>
    /// <param name="lstFrom"></param>
    /// <param name="lstTo"></param>
    /// <param name="OnlySelected"></param>
    /// <param name="IsSelect"></param>
    private void MoveListBoxItems(ListBox lstFrom, ListBox lstTo, bool OnlySelected, bool IsSelect, bool bSort)
    {
        List<ListItem> lstSelected = new List<ListItem>();
        foreach (ListItem liSelcted in lstFrom.Items)
        {
            // If List item is selected then move it to Selected Output field list and add to list objects
            if ((OnlySelected && liSelcted.Selected) || (!OnlySelected))
            {
                liSelcted.Selected = false;
                lstTo.Items.Add(liSelcted);
                lstSelected.Add(liSelcted);
            }
        }

        // remove all selected list items from output fields
        for (int i = 0; i < lstSelected.Count; i++)
        {
            lstFrom.Items.Remove(lstSelected[i] as ListItem);
        }
        // sort Location Field
        if (bSort == true && lstLocationsAvailable.Items.Count > 0)
        {
            DataTable dtFields = new DataTable();
            dtFields.Columns.Add(new DataColumn("PK_LU_Location_ID", typeof(decimal)));
            dtFields.Columns.Add(new DataColumn("dba", typeof(string)));

            foreach (ListItem itmField in lstLocationsAvailable.Items)
            {
                DataRow drField = dtFields.NewRow();
                drField["PK_LU_Location_ID"] = itmField.Value;
                drField["dba"] = itmField.Text;
                dtFields.Rows.Add(drField);
            }
            dtFields.DefaultView.Sort = "dba ASC";
            lstLocationsAvailable.Items.Clear();
            lstLocationsAvailable.DataSource = dtFields.DefaultView;
            lstLocationsAvailable.DataTextField = "dba";
            lstLocationsAvailable.DataValueField = "PK_LU_Location_ID";
            lstLocationsAvailable.DataBind();
        }
        // If Selected output list is empty then Disable Moving buttons and Up-Down images
        if (lstSelectedFields.Items.Count <= 0)
        {
            btnDeselectFields.Enabled = false;
            btnDeselectAllFields.Enabled = false;//imgUp.Enabled = imgDown.Enabled = 
        }
        else
        {
            btnDeselectFields.Enabled = true;
            btnDeselectAllFields.Enabled = true;//imgUp.Enabled = imgDown.Enabled = 
        }
        // IF output Fields is Empty
        if (lstLocationsAvailable.Items.Count <= 0)
        {
            btnSelectFields.Enabled = false;
            btnSelectAllFields.Enabled = false;
        }
        else
        {
            btnSelectFields.Enabled = true;
            btnSelectAllFields.Enabled = true;
        }

    }

    /// <summary>
    /// Bind FROI E-Mail Recipients List
    /// </summary>
    private void BindLocations(bool _EditFlag, Nullable<decimal> _Employee_Id)
    {
        //clear list box
        lstLocationsAvailable.Items.Clear();
        lstSelectedFields.Items.Clear();

           
        //Get all Locations as per CurrentEmployee and Regional
        DataSet dsData = LU_Location.SelectAllDealershipByUser();
        lstLocationsAvailable.DataSource = dsData.Tables[0].DefaultView;
        lstLocationsAvailable.DataTextField = "Dealership";
        lstLocationsAvailable.DataValueField = "PK_LU_Location_ID";
        lstLocationsAvailable.DataBind();
        //if opened in Edit mode, Move Selected data to right (From lstlocations to lstSelectedFields)
        if (_EditFlag)
        {
            DataSet dsSelectedData = U_A_Request_Locations.SelectByUser(PK_U_A_Request);
            foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            {
                if (lstLocationsAvailable.Items.FindByValue(dr["FK_LU_Location"].ToString().Trim()) != null)
                {
                    // 3315 : Sonic - Security FROI Recipients Issue : Solved Issue of Left side items are not removed from list
                    int index = lstLocationsAvailable.Items.IndexOf(lstLocationsAvailable.Items.FindByValue(dr["FK_LU_Location"].ToString().Trim()));
                    lstLocationsAvailable.Items.RemoveAt(index);
                    // lstFROIeMailRecipients.Items.Remove(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location_ID"].ToString()));
                    lstSelectedFields.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location"].ToString()));
                }
            }
        }
        //Enable/Disable buttons
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = lstSelectedFields.Items.Count > 0; //imgUp.Enabled = imgDown.Enabled = 
        btnSelectAllFields.Enabled = btnSelectFields.Enabled = lstLocationsAvailable.Items.Count > 0;
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstLocationsAvailable, lstSelectedFields });
    }

    /// <summary>
    /// Bind FROI E-Mail Recipients List
    /// </summary>
    private void BindLocationsView()
    {
        lstSelectedFieldsView.Items.Clear();
        //Move Selected data to right (From lstSelectedFieldsView to lstSelectedFields)
        DataSet dsSelectedData = U_A_Request_Locations.SelectByUser(PK_U_A_Request);
        foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            lstSelectedFieldsView.Items.Add(new ListItem(dr["dba"].ToString(), dr["FK_LU_Location"].ToString()));
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstLocationsAvailable });
    }

    /// <summary>
    /// Handles changes of Location Lists when Employee name changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAssName_OnClick(object sender, EventArgs e)
    {
        BindLocations(true, Convert.ToInt32(HdnEmployeeID.Value));
        //tdEmployee.Style["display"] = "";
        //tdRigionalOfficer.Style["display"] = "";
        lnkAssName.InnerText = HdnEmployeeName.Value;
    }

    private void FillDropdown()
    {

        //Dealership
        ddlDealership.DataSource = LU_Location.SelectAllDealershipByUser();
        ddlDealership.DataTextField = "Dealership";
        ddlDealership.DataValueField = "PK_LU_Location_ID";
        ddlDealership.DataBind();

        ddlDealership.Items.Insert(0, new ListItem("--Select--", "0"));
    }



    #endregion

    #region "grid Events"
    protected void gvUserAccess_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy)
            {
                // update sort image beside the column header
                AddSortImage(e.Row);
            }
            else
            {
                // add sort image beside the column header
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }
    protected void gvUserAccess_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);

    }
    protected void gvUserAccess_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            divViewAccessUserList.Style.Add("display", "none");
            divModifyAccessUser.Style.Add("display", "block");
            btnCancel.Text = "Cancel";
            // Hide password controls while editing.
            PK_U_A_Request = Convert.ToInt32(e.CommandArgument.ToString());
            btnPromote.Visible = btnDeny.Visible = false;
            EditRecord();
        }
        else if (e.CommandName == "View")
        {
            divViewAccessUserList.Style.Add("display", "none");
            divModifyAccessUser.Style.Add("display", "block");
            PK_U_A_Request = Convert.ToInt32(e.CommandArgument.ToString());
            int rowIndex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
            string imgPath = ((Image)gvUserAccess.Rows[rowIndex].FindControl("imgAccessGranted")).ImageUrl;
            btnCancel.Text = "Return";
            if (imgPath == strClose)
            {
                btnPromote.Visible = true;
                btnDeny.Visible = false;
            }
            else if (imgPath == strTick)
            {
                btnPromote.Visible = false;
                btnDeny.Visible = false;
            }
            else
            {
                btnDeny.Visible = btnPromote.Visible = true;
            }
            ViewRecord();
        }
    }
    protected void gvUserAccess_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string count = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Deny"));
            if (count == "True")
            {
                Image imgAccessGranted = e.Row.FindControl("imgAccessGranted") as Image;
                imgAccessGranted.ImageUrl = strClose;
            }
            else if (count == "False")
            {
                Image imgAccessGranted = e.Row.FindControl("imgAccessGranted") as Image;
                imgAccessGranted.ImageUrl = strTick;


                Button btnEdit = e.Row.FindControl("btnEdit") as Button;
                btnEdit.Visible = false;
                //btnAccessGranted.Text = ((char)0x221A).ToString();
             
            }
            else
            {
                Image imgAccessGranted = e.Row.FindControl("imgAccessGranted") as Image;
                imgAccessGranted.Visible = false;

                Button btnEdit = e.Row.FindControl("btnEdit") as Button;
                btnEdit.Visible = true;
            }
        }
    }


    #endregion

    #region Email Body Generator
    /// <summary>
    /// Used to Create Email Body
    /// </summary>
    /// <returns></returns>
    public string GenerateEMailBody()
    {
        string strFilePath = HttpContext.Current.Server.MapPath("~/EmailTemplate/U_A_Request.html");
        string strEbdy = clsGeneral.ReadTextFile(strFilePath);
        if (string.IsNullOrEmpty(strEbdy))
        {
            return "";
        }
        else
        {
            //Check User Access Request Wizard ID. if Greater than Zero than update data in User Access Request Wizard table.
            if (PK_U_A_Request > 0)
            {

                //Declare Object of U_A_Request table
                U_A_Request objU_A_Request = new U_A_Request(PK_U_A_Request);

                #region Fill Details

                if (objU_A_Request.FK_Employee != null)
                {
                    lblEmployeeId.Text = Convert.ToString(objU_A_Request.FK_Employee);
                    if (Convert.ToDecimal(objU_A_Request.FK_Employee) > 0)
                    {
                        Employee objEmp = new Employee(Convert.ToDecimal(objU_A_Request.FK_Employee));
                        string emp_name = string.Empty;
                        if (objEmp.First_Name != null)
                            emp_name = Convert.ToString(objEmp.First_Name).Trim() + ", ";
                        if (objEmp.Middle_Name != null)
                            emp_name += Convert.ToString(objEmp.Middle_Name).Trim() + " ";
                        if (objEmp.Last_Name != null)
                            emp_name += Convert.ToString(objEmp.Last_Name).Trim();

                        strEbdy = strEbdy.Replace("[lblFK_Employee]", Convert.ToString(emp_name));
                    }
                    else
                    {
                        strEbdy = strEbdy.Replace("[lblFK_Employee]", string.Empty);
                    }
                }
                else
                {
                    strEbdy = strEbdy.Replace("[lblFK_Employee]", string.Empty);
                }

                if (!string.IsNullOrEmpty(objU_A_Request.FK_LU_Location.ToString()))
                {
                    DataSet ds = LU_Location.SelectStateMarketByLocationID(Convert.ToDecimal(objU_A_Request.FK_LU_Location));
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        strEbdy = strEbdy.Replace("[lblMarket]", Convert.ToString(dt.Rows[0]["Market"]));
                        strEbdy = strEbdy.Replace("[lblState]", Convert.ToString(dt.Rows[0]["State"]));
                    }
                }
                else
                {
                    strEbdy = strEbdy.Replace("[lblMarket]", "");
                    strEbdy = strEbdy.Replace("[lblState]", "");
                }

                if (objU_A_Request.FK_LU_Location.ToString() != "")
                {
                    DataSet ds = LU_Location.SelectAllDealershipByUserAndLocationId(Convert.ToDecimal(objU_A_Request.FK_LU_Location));
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        strEbdy = strEbdy.Replace("[lblFK_LU_Location]", Convert.ToString(dt.Rows[0]["Dealership"]));
                    }
                }
                else
                {
                    strEbdy = strEbdy.Replace("[lblFK_LU_Location]", "");
                }

                DataSet dsSelectedData = U_A_Request_Locations.SelectByUser(PK_U_A_Request);
                string strUARequestLocations = string.Empty;
                int count = 0;
                foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
                {
                    count++;
                    strUARequestLocations = strUARequestLocations + ", " + Convert.ToString(dr["dba"]);
                    //if (count % 7 == 0)
                    //    strUARequestLocations = strUARequestLocations + "<br />";
                }

                //byte[] imageChecked = System.IO.File.ReadAllBytes(AppConfig.SiteURL + "images//Checkbox-checked.bmp");
                //string base64Checked = Convert.ToBase64String(imageChecked);

                //byte[] imageClose = System.IO.File.ReadAllBytes(AppConfig.SiteURL + "images//mages//checkboxclose.png");
                //string base64Close = Convert.ToBase64String(imageClose);

                strEbdy = strEbdy.Replace("[lblFirst_Name]", Convert.ToString(objU_A_Request.First_Name));
                strEbdy = strEbdy.Replace("[lblLast_Name]", Convert.ToString(objU_A_Request.Last_Name));
                strEbdy = strEbdy.Replace("[lblEmail]", Convert.ToString(objU_A_Request.Email));
                strEbdy = strEbdy.Replace("[lblTelephone]", Convert.ToString(objU_A_Request.Telephone));
                strEbdy = strEbdy.Replace("[lblLocation]", strUARequestLocations.TrimEnd(',').TrimStart(','));
                strEbdy = strEbdy.Replace("[lblSA_EA_Associate]", Convert.ToString(objU_A_Request.SA_EA_Associate) == "True" ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblGeneral_Manager]", Convert.ToString(objU_A_Request.General_Manager) == "True" ? strTick : strClose);
                strEbdy = strEbdy.Replace("[lblController]", Convert.ToString(objU_A_Request.Controller) == "True" ? strTick : strClose);
                strEbdy = strEbdy.Replace("[lblService]", Convert.ToString(objU_A_Request.Service) == "True" ? strTick : strClose);
                strEbdy = strEbdy.Replace("[lblSales]", Convert.ToString(objU_A_Request.Sales) == "True" ? strTick : strClose);
                strEbdy = strEbdy.Replace("[lblParts]", Convert.ToString(objU_A_Request.Parts) == "True" ? strTick : strClose);
                strEbdy = strEbdy.Replace("[lblBusiness_Office]", Convert.ToString(objU_A_Request.Business_Office) == "True" ? strTick : strClose);
                strEbdy = strEbdy.Replace("[lblHome_Office]", Convert.ToString(objU_A_Request.Home_Office) == "True" ? strTick : strClose);
                strEbdy = strEbdy.Replace("[lblField_Operastions]", Convert.ToString(objU_A_Request.Field_Operastions) == "True" ? strTick : strClose);
                strEbdy = strEbdy.Replace("[lblHome_Office_Text]", Convert.ToString(objU_A_Request.Home_Office_Text));
                strEbdy = strEbdy.Replace("[lblField_Operations_Text]", Convert.ToString(objU_A_Request.Field_Operations_Text));
                strEbdy = strEbdy.Replace("[lblReason_For_Access]", Convert.ToString(objU_A_Request.Reason_For_Access));
                strEbdy = strEbdy.Replace("[lblRegional_Market_Area_Associate]", Convert.ToString(objU_A_Request.Regional_Market_Area_Associate) == "True" ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblMultiple_Locations]", Convert.ToString(objU_A_Request.Multiple_Locations) == "True" ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblBuilding_Access]", Convert.ToString(objU_A_Request.Building_Access) == "True" ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblE_S_H_Access]", Convert.ToString(objU_A_Request.E_S_H_Access) == "True" ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblClaim_Report_Access]", Convert.ToString(objU_A_Request.Claim_Report_Access) == "True" ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblClaim_View_Access]", Convert.ToString(objU_A_Request.Claim_View_Access) == "True" ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblSecurity_Access]", Convert.ToString(objU_A_Request.Security_Access) == "True" ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblSLT_Access]", Convert.ToString(objU_A_Request.SLT_Access) == "True" ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblFacilities_Construction_Access]", Convert.ToString(objU_A_Request.Facilities_Construction_Access) == "True" ? "Yes" : "No");



                #endregion

                return strEbdy;
            }
            else
            {
                return "";
            }
        }

    }
    #endregion
   
}