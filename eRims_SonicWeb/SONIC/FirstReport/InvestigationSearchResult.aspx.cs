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

public partial class SONIC_FirstReport_InvestigationSearchResult : clsBasePage
{
    #region Properties
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

    #endregion

    #region "Control Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // set the default sort field and sort order
            SortBy = "PK_Investigation_ID";
            SortOrder = "asc";

            // Bind Grid
            BindGrid(1, 10);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("InvestigationSearch.aspx", true);
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        // check for session containing all search values if it is null or not
        // if null then  redirect to search page
        if (Session["dtInvSearchTable"] != null)
        {
            //get the data table from session
            DataTable dtSearch = (DataTable)Session["dtInvSearchTable"];
            //check datatable have atleast one row
            if (dtSearch.Rows.Count > 0)
            {
                DataRow drSearch = dtSearch.Rows[0];
                //get the values from each column of row
                string strLocationIDs = drSearch["LocationIDs"].ToString();
                string strFromDate = drSearch["FromDate"].ToString();
                string strToDate = drSearch["ToDate"].ToString();
                decimal decFRNumber = Convert.ToDecimal(drSearch["FR_Number"]);
                string strIncidentDate = drSearch["IncidentDate"].ToString();
                string Regional = string.Empty;
                Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
                DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
                if (dsRegion.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                    {
                        Regional += drRegion["Region"].ToString() + ",";
                    }
                }
                else
                    Regional = string.Empty;

                Regional = Regional.TrimEnd(',');
                if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
                    CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
                else
                    CurrentEmployee = 0;

                // selects records depending on paging criteria and search values.
                DataSet dsSearchResult = Investigation.SearchByPaging(strLocationIDs, decFRNumber, strIncidentDate, strFromDate, strToDate, Regional, CurrentEmployee, SortBy, SortOrder, PageNumber, PageSize);
                DataTable dtSearchResult = dsSearchResult.Tables[0];

                //// set values for paging control,so it shows values as needed.
                ctrlPageExposure.TotalRecords = (dsSearchResult.Tables.Count >= 3) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][0]) : 0;
                ctrlPageExposure.CurrentPage = (dsSearchResult.Tables.Count >= 3) ? Convert.ToInt32(dsSearchResult.Tables[2].Rows[0][2]) : 0;
                ctrlPageExposure.RecordsToBeDisplayed = dtSearchResult.Rows.Count;
                ctrlPageExposure.SetPageNumbers();

                // bind the grid.
                gvExposure.DataSource = dtSearchResult;
                gvExposure.DataBind();
                // set record numbers retrieved
                lblNumber.Text = (dsSearchResult.Tables.Count >= 3) ? Convert.ToString(dsSearchResult.Tables[1].Rows[0][0]) : "0";
            }
        }
        else
            Response.Redirect("InvestigationSearch.aspx");

    }

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvExposure.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvExposure.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
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

    protected void GetPage()
    {
        BindGrid(ctrlPageExposure.CurrentPage, ctrlPageExposure.PageSize);
    }
    #endregion

    #region "GridView Events"

    /// <summary>
    /// Handles event when Grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExposure_RowCreated(object sender, GridViewRowEventArgs e)
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

    /// <summary>
    /// Handles event for search result grid sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExposure_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageExposure.CurrentPage, ctrlPageExposure.PageSize);
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExposure_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditInvestigation")
        {
            string[] args = e.CommandArgument.ToString().Split(':');
            int PK = Convert.ToInt32(args[0]);
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(args[1]);

            //bool bLocInfoComplete = new Investigation(PK).Location_Information_Complete;
            //used to set Tab 
            setTab(clsSession.First_Report_Wizard_ID);
            // set flag for whether user is regional officer or not
            //bool bIsUserRegOfficer = new Security(Convert.ToDecimal(clsSession.UserID)).IsRegionalOfficer;

            //if ((!bIsUserRegOfficer && bLocInfoComplete) || Module_Access_Mode == AccessType.View_Only)
            //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
            //else
            if (Module_Access_Mode == AccessType.View_Only)
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
            else
                Response.Redirect("Investigation.aspx?id=" + Encryption.Encrypt(PK.ToString()) + "&op=edit&search=1");

        }
        else if (e.CommandName == "ViewInvestigation")
        {
            string[] args = e.CommandArgument.ToString().Split(':');
            int PK = Convert.ToInt32(args[0]);
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(args[1]);
            //used to set Tab 
            setTab(clsSession.First_Report_Wizard_ID);
            Response.Redirect("Investigation.aspx?id=" + Encryption.Encrypt(PK.ToString()) + "&op=view&search=1");
        }
        else if (e.CommandName == "DeleteInvestigation")
        {
            int PK = Convert.ToInt32(e.CommandArgument);
            Investigation.DeleteByPK(PK);
            BindGrid(ctrlPageExposure.CurrentPage, ctrlPageExposure.PageSize);
        }
    }
    /// <summary>
    /// Handles event when search result grid row data is bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExposure_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Chekc Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkRLCMComp = (CheckBox)e.Row.FindControl("chkRLCMComp");
            CheckBox chkLocInfoComp = (CheckBox)e.Row.FindControl("chkLocInfoComp");

            chkLocInfoComp.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Location_Information_Complete"));
            chkRLCMComp.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "RLCM_Complete"));

            if (chkLocInfoComp.Checked)
            {
                if (App_Access != AccessType.Administrative_Access)
                {
                    if (!clsSession.IsUserRegionalOfficer)
                        ((LinkButton)e.Row.FindControl("lnkEdit")).Attributes.Add("onclick", "alert('You do not have rights to edit the information');return false;");
                }
            }
        }
    }

    /// <summary>
    /// Used to set Tabing Control values
    /// </summary>
    /// <param name="WizardID"></param>
    public void setTab(int WizardID)
    {
        string AllowTab = "";
        DataSet dstab = Constituent_First_Report.SelectConstituentDetails_byFirstReportID(WizardID);
        //check dataset having table hase atleast one row.
        if (dstab.Tables[0].Rows.Count > 0)
        {
            DataTable dtTab = dstab.Tables[0];
            foreach (DataRow drTab in dtTab.Rows)
            {
                //check First_report_Table field of datarow in equal to WC_FR
                if (drTab["First_Report_Table"].ToString() == "WC_FR")
                {
                    AllowTab += "1";
                }
                //check First_report_Table field of datarow in equal to DPD_FR
                else if (drTab["First_Report_Table"].ToString() == "DPD_FR")
                {
                    //check if allowedTab string is empty than add value without comma ahead. else add comma at starting 
                    if (AllowTab != string.Empty)
                        AllowTab += ",3";
                    else
                        AllowTab += "3";
                }
                //check First_report_Table field of datarow in equal to AL_FR
                else if (drTab["First_Report_Table"].ToString() == "AL_FR")
                {
                    //check if allowedTab string is empty than add value without comma ahead. else add comma at starting
                    if (AllowTab != string.Empty)
                        AllowTab += ",2";
                    else
                        AllowTab += "2";
                }
                //check First_report_Table field of datarow in equal to PL_FR
                else if (drTab["First_Report_Table"].ToString() == "PL_FR")
                {
                    //check if allowedTab string is empty than add value without comma ahead. else add comma at starting
                    if (AllowTab != string.Empty)
                        AllowTab += ",5";
                    else
                        AllowTab += "5";
                }
                //check First_report_Table field of datarow in equal to PROPERTY_FR
                else if (drTab["First_Report_Table"].ToString().ToUpper() == "PROPERTY_FR")
                {
                    //check if allowedTab string is empty than add value without comma ahead. else add comma at starting
                    if (AllowTab != string.Empty)
                        AllowTab += ",4";
                    else
                        AllowTab += "4";
                }
            }
            clsSession.AllowedTab = AllowTab;
        }
    }
    #endregion
}
