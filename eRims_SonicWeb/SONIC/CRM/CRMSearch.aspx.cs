using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_CRM_CRMSearch : clsBasePage
{
    #region "Properties"
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

    /// <summary>
    /// Incident Type
    /// </summary>
    private string IncidentType
    {
        get { return (!clsGeneral.IsNull(ViewState["IncidentType"]) ? ViewState["IncidentType"].ToString() : string.Empty); }
        set { ViewState["IncidentType"] = value; }
    }

    #endregion

    #region "Page Evebts"

    /// <summary>
    /// Page laod Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SortOrder = "Asc";
            SortBy = "Incident_Type,PK_CRM_Customer,LocationDBA,Record_Date";
            BindDropDownLists();
            int count = drpLocationDBA_Cust.Items.Count;
            if (App_Access == AccessType.View_Only)
                btnAdd_Cust.Visible = btnAdd_NonCust.Visible = btnAddNew.Visible = false;

            if (Request.QueryString["typ"] != null)
            {
                int intType = 0;
                if (int.TryParse(Request.QueryString["typ"], out intType))
                {
                    drpIncidentType.SelectedIndex = intType;
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), DateTime.Now.ToString(), "onIncidentTypeChange();", true);
                }
                else
                    drpIncidentType.Focus();
            }
            else
                drpIncidentType.Focus();
           
        }
        clsGeneral.SetDropDownToolTip(new DropDownList[] { drpCategory_NonCust, drpDepartment_Cust, drpIncidentType, drpLocationDBA_Cust, drpLocationDBA_NonCust, drpSoruce_NonCust, drpSource_Cust });
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind Drop Down List
    /// </summary>
    private void BindDropDownLists()
    {
        ComboHelper.FillCRM_Source(new DropDownList[] { drpSource_Cust, drpSoruce_NonCust }, true);
        ComboHelper.FillCRM_Department(new DropDownList[] { drpDepartment_Cust }, true);
        ComboHelper.FillLocationDBA_All(new DropDownList[] { drpLocationDBA_Cust, drpLocationDBA_NonCust }, 0, true);
        drpLocationDBA_Cust.Style.Remove("font-size");
        drpLocationDBA_NonCust.Style.Remove("font-size");
        ComboHelper.FillCRM_Category(new DropDownList[] { drpCategory_NonCust }, true);
    }

    /// <summary>
    /// Search and Bind Grid for Customer Incident Type
    /// </summary>
    private void BindCustomerGrid(int PageNumber, int PageSize)
    {
        decimal ComplaintNumber = 0;
        if (txtComplaintNumber_Cust.Text.Trim() != "")
            ComplaintNumber = clsGeneral.GetDecimalValue(txtComplaintNumber_Cust);
        DateTime? dtIncidentFrom = clsGeneral.FormatNullDateToStore(txtIncidentDateFrom_Cust.Text.Trim());
        DateTime? dtIncidentTo = clsGeneral.FormatNullDateToStore(txtIncidentDateTo_Cust.Text.Trim());

        DataSet dsSearchResult = CRM_Customer.CRM_Customer_Search(ComplaintNumber, dtIncidentFrom, dtIncidentTo, Convert.ToDecimal(drpSource_Cust.SelectedValue), txtLastName_Cust.Text.Trim().Replace("'", "''"),
            txtFirstName_Cust.Text.Trim().Replace("'", "''"), Convert.ToDecimal(drpDepartment_Cust.SelectedValue), Convert.ToDecimal(drpLocationDBA_Cust.SelectedValue), clsGeneral.FormatNullDateToStore(txtLastUpdateFrom_Cust.Text.Trim()),
            clsGeneral.FormatNullDateToStore(txtLastUpdateTo_Cust.Text.Trim()), txtLastAction_Cust.Text.Trim().Replace("'", "''"), Convert.ToString(rdbComplete_Cust.SelectedValue), clsGeneral.FormatNullDateToStore(txtCloseDateFrom_Cust.Text.Trim()),
            clsGeneral.FormatNullDateToStore(txtCloseDateTo_Cust.Text.Trim()), Convert.ToString(rdbResolutionLetter_Cust.SelectedValue), clsGeneral.FormatNullDateToStore(txtDateResolutionLetterFrom_Cust.Text.Trim()),
             clsGeneral.FormatNullDateToStore(txtDateResolutionLetterTo_Cust.Text.Trim()), Convert.ToString(rdbLetterNA_Cust.SelectedValue), SortBy, SortOrder, PageNumber, PageSize);
        gvIncident.DataSource = dsSearchResult.Tables[0];
        gvIncident.DataBind();

        //// set values for paging control,so it shows values as needed.
        ctrlPageIncident.TotalRecords = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][0]) : 0;
        ctrlPageIncident.CurrentPage = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][2]) : 0;
        ctrlPageIncident.RecordsToBeDisplayed = dsSearchResult.Tables[0].Rows.Count;
        ctrlPageIncident.SetPageNumbers();

        // set record numbers retrieved
        lblNumber.Text = ((dsSearchResult.Tables.Count >= 2) ? Convert.ToString(dsSearchResult.Tables[1].Rows[0][0]) : "0");
    }

    /// <summary>
    /// Search and Bind Grid for Customer Incident Type
    /// </summary>
    private void BindNonCustomerGrid(int PageNumber, int PageSize)
    {
        decimal ContactNumber = 0;
        if (txtContactNumber_NonCust.Text.Trim() != "")
            ContactNumber = clsGeneral.GetDecimalValue(txtContactNumber_NonCust);
        DateTime? dtContactFrom = clsGeneral.FormatNullDateToStore(txtContactDateFrom_NonCust.Text.Trim());
        DateTime? dtContactTo = clsGeneral.FormatNullDateToStore(txtContactDateTo_NonCust.Text.Trim());

        DataSet dsSearchResult = CRM_Customer.CRM_NonCustomer_Search(ContactNumber, dtContactFrom, dtContactTo, Convert.ToDecimal(drpSoruce_NonCust.SelectedValue), txtLastName_NonCust.Text.Trim().Replace("'", "''"),
            Convert.ToDecimal(drpLocationDBA_NonCust.SelectedValue), Convert.ToDecimal(drpCategory_NonCust.SelectedValue), Convert.ToString(rdbReponseSent_NonCust.SelectedValue), clsGeneral.FormatNullDateToStore(txtResponseDateFrom_NonCust.Text.Trim()),
            clsGeneral.FormatNullDateToStore(txtResponseDateTo_NonCust.Text.Trim()), Convert.ToString(rdbReponseNA_NonCust.SelectedValue), txtCompany_name.Text, SortBy, SortOrder, PageNumber, PageSize);
        gvIncident.DataSource = dsSearchResult.Tables[0];
        gvIncident.DataBind();

        //// set values for paging control,so it shows values as needed.
        ctrlPageIncident.TotalRecords = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][0]) : 0;
        ctrlPageIncident.CurrentPage = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][2]) : 0;
        ctrlPageIncident.RecordsToBeDisplayed = dsSearchResult.Tables[0].Rows.Count;
        ctrlPageIncident.SetPageNumbers();

        // set record numbers retrieved
        lblNumber.Text = ((dsSearchResult.Tables.Count >= 2) ? Convert.ToString(dsSearchResult.Tables[1].Rows[0][0]) : "0");
    }

    private void BindGrid(int PageNumber, int PageSize)
    {
        if (IncidentType == "Customer")
            BindCustomerGrid(PageNumber, PageSize);
        else
            BindNonCustomerGrid(PageNumber, PageSize);
    }

    // event for page controls go button.
    protected void GetPage()
    {
        BindGrid(ctrlPageIncident.CurrentPage, ctrlPageIncident.PageSize);
    }

    /// <summary>
    /// Add in Column Sort Image
    /// </summary>
    /// <param name="headerRow"></param>
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

    //Set Sort Column Image set
    private int GetSortColumnIndex(object strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvIncident.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {
                nRet = gvIncident.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    #endregion

    #region "Evetns"

    /// <summary>
    /// Search Again
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = true;
        dvSearchResult.Visible = false;
        if (IncidentType == "Customer")
            drpIncidentType.SelectedIndex = 1;
        else
            drpIncidentType.SelectedIndex = 2;
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "", "onIncidentTypeChange();");   
        ScriptManager.RegisterStartupScript(Page, this.GetType(), DateTime.Now.ToString(), "onIncidentTypeChange();", true);
    }

    /// <summary>
    /// Click to Add New Record -Redirect to Add screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        if (IncidentType == "Customer")
            Response.Redirect("CRM_Customer.aspx", true);
        else
            Response.Redirect("CRM_NonCustomer.aspx", true);
    }

    /// <summary>
    /// Button Add Custom Incident record -Click to redirect on Add Screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Cust_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRM_Customer.aspx", true);
    }

    /// <summary>
    /// Button Add Non-Custom Incident record -Click to redirect on Add Screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_NonCust_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRM_NonCustomer.aspx", true);
    }

    /// <summary>
    /// Search non-Customer Records
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_NonCust_Click(object sender, EventArgs e)
    {
        SortOrder = "Asc";
        SortBy = "Incident_Type,PK_CRM_Customer,LocationDBA,Record_Date";
        IncidentType = "NonCustomer";
        dvSearch.Visible = false;
        dvSearchResult.Visible = true;
        BindGrid(1, 10);
    }

    /// <summary>
    /// Search Customer Records
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Cust_Click(object sender, EventArgs e)
    {
        SortOrder = "Asc";
        SortBy = "Incident_Type,PK_CRM_Customer,LocationDBA,Record_Date";
        IncidentType = "Customer";
        dvSearch.Visible = false;
        dvSearchResult.Visible = true;
        BindGrid(1, 10);
    }

    #endregion

    # region " Grid Events "
    /// <summary>
    /// GridView Row Data Command Event handles in Edit and View Mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvIncident_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (IncidentType == "Customer")
        {
            if (e.CommandName == "ViewIncident")
            {
                //View Record
                decimal PK_CRM_Customer = Convert.ToDecimal(e.CommandArgument);
                Response.Redirect("CRM_Customer.aspx?op=view&id=" + Encryption.Encrypt(PK_CRM_Customer.ToString()), true);
            }
            else if (e.CommandName == "EditIncident")
            {
                //Edit Record
                decimal PK_CRM_Customer = Convert.ToDecimal(e.CommandArgument);
                Response.Redirect("CRM_Customer.aspx?op=edit&id=" + Encryption.Encrypt(PK_CRM_Customer.ToString()), true);
            }
            else if (e.CommandName == "DeleteIncident")
            {
                //Delete Record
                decimal PK_CRM_Customer = Convert.ToDecimal(e.CommandArgument);
                CRM_Customer.DeleteByPK(PK_CRM_Customer);
                BindGrid(ctrlPageIncident.CurrentPage, ctrlPageIncident.PageSize);
            }
        }
        else
        {
            if (e.CommandName == "ViewIncident")
            {
                //View Record
                decimal PK_CRM_Non_Customer = Convert.ToDecimal(e.CommandArgument);
                Response.Redirect("CRM_NonCustomer.aspx?op=view&id=" + Encryption.Encrypt(PK_CRM_Non_Customer.ToString()), true);
            }
            else if (e.CommandName == "EditIncident")
            {
                //Edit Record
                decimal PK_CRM_Non_Customer = Convert.ToDecimal(e.CommandArgument);
                Response.Redirect("CRM_NonCustomer.aspx?op=edit&id=" + Encryption.Encrypt(PK_CRM_Non_Customer.ToString()), true);
            }
            else if (e.CommandName == "DeleteIncident")
            {
                //Delete Record
                decimal PK_CRM_Non_Customer = Convert.ToDecimal(e.CommandArgument);
                CRM_Non_Customer.DeleteByPK(PK_CRM_Non_Customer);
                BindGrid(ctrlPageIncident.CurrentPage, ctrlPageIncident.PageSize);
            }
        }
    }
    /// <summary>
    /// GridView Row Data Bound Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvIncident_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button lnkEdit = (Button)e.Row.FindControl("lnkEdit");
            Button lnkDelete = (Button)e.Row.FindControl("lnkDelete");
            lnkEdit.Visible = (App_Access != AccessType.View_Only);
            lnkDelete.Visible = !(App_Access == AccessType.View_Only || App_Access == AccessType.CRM_Add);
        }
    }


    /// <summary>
    /// Handles GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvIncident_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageIncident.CurrentPage, ctrlPageIncident.PageSize);
    }
    /// <summary>
    /// Handles Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvIncident_RowCreated(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[0].Controls.Add(sortImage);
            }
        }
    }

    #endregion
}