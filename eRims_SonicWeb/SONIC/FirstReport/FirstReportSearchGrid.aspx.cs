using System;
using System.Net;
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
using System.IO;

/// <summary>
/// Date           : 18-07-08
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : Used to display all the searched record that are retirved from search criteria passed.
///                  
/// 
/// </summary>
public partial class SONIC_FirstReportSearchGrid : clsBasePage
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

    #region "Page Events"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check page is post back or not
        if (!IsPostBack)
        {
            // set the default sort field and sort order
            SortBy = "FR_Number";
            SortOrder = "Desc";

            // Bind Grid
            BindGrid(1, 10);

            // clear the session variable for property as new record to be inserted
            clsSession.First_Report_Wizard_ID = 0;

            //check User Access Type if it View Only than display Add Button        
            if (App_Access == AccessType.View_Only)
            {
                btnAddNew.Visible = false;
            }
        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Search BUtton CLIck Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("FirstReportSearch.aspx", true);
    }
  
    /// <summary>
    /// Add new Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("FirstReportAddWizard.aspx", true);
    }

    #endregion

    #region Methods
    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        // check for session containing all search values if it is null or not
        // if null then  redirect to search page
        if (Session["dtReportSearch"] != null)
        {
            //get the data table from session
            DataTable dtSearch = (DataTable)Session["dtReportSearch"];
            //check datatable have atleast one row
            if (dtSearch.Rows.Count > 0)
            {
                DataRow drSearch = dtSearch.Rows[0];
                Nullable<DateTime> DateOfIncident;
                //get the values from each column of row
                decimal LocationNumber = Convert.ToDecimal(drSearch["LocationNumber"]);
                decimal EmployeeID = Convert.ToDecimal(drSearch["EmployeeID"]);
                if (Convert.ToDateTime(drSearch["DateOfIncident"]) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    DateOfIncident = clsGeneral.FormatDateToStore(drSearch["DateOfIncident"]);
                else
                    DateOfIncident = null;
                decimal FirstReportNumber = Convert.ToDecimal(drSearch["FirstReportNumber"]);
                decimal ClaimNumber = Convert.ToDecimal(drSearch["ClaimNumber"]);

                string strIncidentStartDate = Convert.ToString(drSearch["IncidentStartDate"]);
                string strIncidentEndDate = Convert.ToString(drSearch["IncidentEndDate"]);
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

                if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
                    CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
                else
                    CurrentEmployee = 0;

                // selects records depending on paging criteria and search values.
                DataSet dsFirstReport = First_Report_Wizard.GetSearchResults(LocationNumber, DateOfIncident,strIncidentStartDate,strIncidentEndDate, FirstReportNumber, EmployeeID, SortBy, SortOrder, PageNumber, PageSize, Regional.ToString().TrimEnd(Convert.ToChar(",")), CurrentEmployee, drSearch["ClaimType"].ToString());
                                
                DataTable dtFRData = dsFirstReport.Tables[0];
                //// set values for paging control,so it shows values as needed.
                ctrlPageFirstReport.TotalRecords = (dsFirstReport.Tables.Count >= 3) ? Convert.ToInt32(dsFirstReport.Tables[1].Rows[0][0]) : 0;
                ctrlPageFirstReport.CurrentPage = (dsFirstReport.Tables.Count >= 3) ? Convert.ToInt32(dsFirstReport.Tables[2].Rows[0][2]) : 0;
                ctrlPageFirstReport.RecordsToBeDisplayed = dtFRData.Rows.Count;
                ctrlPageFirstReport.SetPageNumbers();

                // bind the grid.
                gvFirstReportSearchGrid.DataSource = dtFRData;
                gvFirstReportSearchGrid.DataBind();

                if (string.IsNullOrEmpty(drSearch["ClaimType"].ToString()) || drSearch["ClaimType"].ToString() == "WC" || drSearch["ClaimType"].ToString() == "NS")
                    gvFirstReportSearchGrid.Columns[4].Visible = true;

                // set record numbers retrieved
                lblNumber.Text = (dsFirstReport.Tables.Count >= 3) ? Convert.ToString(dsFirstReport.Tables[1].Rows[0][0]) : "0";

            }
        }
        else
            Response.Redirect("FirstReportSearch.aspx");

    }
    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageFirstReport.CurrentPage, ctrlPageFirstReport.PageSize);
    }

    /// <summary>
    /// Used to Delete File from Physical Locaiton
    /// </summary>
    /// <param name="tbl"></param>
    /// <param name="PK_ID"></param>
    public void DeletePhysicalFile(First_Report_Wizard.Tables tbl, int PK_ID)
    {
        switch (tbl)
        {
            //check Table is name is WC_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.WC_FR):
                {
                    //Get Attchment Details
                    DataTable dtAtt = WC_FR_Attacments.SelectByFROI_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[0]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
                }
            //check Table is name is AL_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.AL_FR):
                {
                    //Get Attchment Details
                    DataTable dtAtt = AL_FR_Attacments.SelectByFROL_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[1]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
                }
            //check Table is name is DPD_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.DPD_FR):
                {
                    //Get Attchment Details
                    DataTable dtAtt = DPD_FR_Attacments.SelectByFROL_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[2]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
                }
            //check Table is name is PROPERTY_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.Property_FR):
                {
                    //Get Attchment Details
                    DataTable dtAtt = Property_FR_Attacments.SelectByFR_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[3]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
                }
            //check Table is name is PL_FR than delete attachment for this First Report
            case (First_Report_Wizard.Tables.PL_FR):
                {
                    //Get Attchment Details
                    DataTable dtAtt = PL_FR_Attachments.SelectByFR_ID(PK_ID).Tables[0];
                    string[] strAtt = new string[dtAtt.Rows.Count];
                    //check datatable have atleast 1 row
                    if (dtAtt.Rows.Count > 0)
                    {
                        foreach (DataRow drAtt in dtAtt.Rows)
                        {
                            string strFilePath = drAtt["Attachment_Path"].ToString();
                            strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[4]) + "\\" + strFilePath;
                            // if Exists than Delete file from physical location.
                            if (File.Exists(strFilePath))
                                File.Delete(strFilePath);
                        }
                    }
                    break;
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
                if (drTab["First_Report_Table"].ToString() == "WC_FR" || drTab["First_Report_Table"].ToString() == "NS_FR")
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
        foreach (DataControlField field in gvFirstReportSearchGrid.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvFirstReportSearchGrid.Columns.IndexOf(field);
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

    #endregion

    #region Grid View Events
   
    /// <summary>
    /// First Report Grid View Row Creatred Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFirstReportSearchGrid_RowCreated(object sender, GridViewRowEventArgs e)
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnView = (LinkButton)e.Row.FindControl("lnkView");
            Button btnDelete = (Button)e.Row.FindControl("lnkDelete");
            btnView.CommandArgument = Convert.ToString(e.Row.RowIndex);
            btnDelete.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
   
    /// <summary>
    /// Grid View Data RowBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFirstReportSearchGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Rowtype
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDateIncident = (Label)e.Row.FindControl("lblDateOfIncident");
            //check Date_Of_Incident value from datset. if it is not null than display it.
            if (DataBinder.Eval(e.Row.DataItem, "Date_Of_Incident") != DBNull.Value)
                lblDateIncident.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Date_Of_Incident")));
            CheckBox chkComplete = (CheckBox)e.Row.FindControl("chkComplete");
            //check Complete value from dataset. if it is true than check complete checkbox else remains uncheck
            if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Complete")) == true)
                chkComplete.Checked = true;
            else
                chkComplete.Checked = false;
            //check User Access type if it is View Only than Hide Delete Button
            if (UserAccessType == AccessType.View_Only)
            {
                gvFirstReportSearchGrid.Columns[6].Visible = false;
            }

        }
    }
    
    /// <summary>
    /// GridView RowDeleting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFirstReportSearchGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    /// <summary>
    /// First Report Gridview sortig event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFirstReportSearchGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageFirstReport.CurrentPage, ctrlPageFirstReport.PageSize);
    }
   
    /// <summary>
    /// Gridview Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFirstReportSearchGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvFirstReportSearchGrid.DataKeys[Index].Values["PK_ID"] != null) ? Convert.ToInt32(gvFirstReportSearchGrid.DataKeys[Index].Values["PK_ID"]) : 0;
            string url = (gvFirstReportSearchGrid.DataKeys[Index].Values["Url"] != null) ? gvFirstReportSearchGrid.DataKeys[Index].Values["Url"].ToString() : "";
            // update current First Report Wizard ID
            clsSession.First_Report_Wizard_ID = (gvFirstReportSearchGrid.DataKeys[Index].Values["Wizard_ID"] != null) ? Convert.ToInt32(gvFirstReportSearchGrid.DataKeys[Index].Values["Wizard_ID"]) : 0;
            // show First Reports in view mode
            //check if Url is blank than it redirect to search page
            if (url != string.Empty)
            {
                //used to set Tab 
                setTab(clsSession.First_Report_Wizard_ID);
                Response.Redirect(url + "?id=" + Encryption.Encrypt(PK_ID.ToString()));
            }
            else
                Response.Redirect("FirstReportSearch.aspx");
        }
        else if (e.CommandName == "Delete")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvFirstReportSearchGrid.DataKeys[Index].Values["PK_ID"] != null) ? Convert.ToInt32(gvFirstReportSearchGrid.DataKeys[Index].Values["PK_ID"]) : 0;
            string Prefix = (gvFirstReportSearchGrid.DataKeys[Index].Values["Prefix"] != null) ? gvFirstReportSearchGrid.DataKeys[Index].Values["Prefix"].ToString() : "";
            //check Prefix.according to Prefix physical file is removed
            if (!string.IsNullOrEmpty(Prefix))
            {
                //as per Prfix name delete the physical fiels and also records from db
                switch (Prefix.ToUpper())
                {
                    case "NS":
                        DeletePhysicalFile(First_Report_Wizard.Tables.WC_FR, PK_ID);
                        First_Report_Wizard.DeleteFirstReport(PK_ID, First_Report_Wizard.Tables.WC_FR);
                        break;
                    case "WC":
                        DeletePhysicalFile(First_Report_Wizard.Tables.WC_FR, PK_ID);
                        First_Report_Wizard.DeleteFirstReport(PK_ID, First_Report_Wizard.Tables.WC_FR);
                        break;
                    case "AL":
                        DeletePhysicalFile(First_Report_Wizard.Tables.AL_FR, PK_ID);
                        First_Report_Wizard.DeleteFirstReport(PK_ID, First_Report_Wizard.Tables.AL_FR);
                        break;
                    case "DPD":
                        DeletePhysicalFile(First_Report_Wizard.Tables.DPD_FR, PK_ID);
                        First_Report_Wizard.DeleteFirstReport(PK_ID, First_Report_Wizard.Tables.DPD_FR);
                        break;
                    case "PROPERTY":
                        DeletePhysicalFile(First_Report_Wizard.Tables.Property_FR, PK_ID);
                        First_Report_Wizard.DeleteFirstReport(PK_ID, First_Report_Wizard.Tables.Property_FR);
                        break;
                    case "PL":
                        DeletePhysicalFile(First_Report_Wizard.Tables.PL_FR, PK_ID);
                        First_Report_Wizard.DeleteFirstReport(PK_ID, First_Report_Wizard.Tables.PL_FR);
                        break;
                }
                //Bind Grid
                BindGrid(ctrlPageFirstReport.CurrentPage, ctrlPageFirstReport.PageSize);
            }
        }
        else if (e.CommandName == "GoToClaim")
        {
            string[] args = e.CommandArgument.ToString().Split(':');
            int PK_ID = !string.IsNullOrEmpty(args[0]) ? Convert.ToInt32(args[0]) : 0;
            string Prefix = args[1];
            string url = "";
            //check Prefix.according to Prefix physical file is removed
            if (!string.IsNullOrEmpty(Prefix))
            {
                if (Prefix.ToUpper() == "WC" || Prefix.ToUpper() == "NS") { url = "WCClaimInfo.aspx"; clsSession.AllowedTab = "1"; }
                else if (Prefix.ToUpper() == "AL") { url = "ALClaimInfo.aspx"; clsSession.AllowedTab = "2"; }
                else if (Prefix.ToUpper() == "DPD") { url = "DPDClaimInfo.aspx"; clsSession.AllowedTab = "3"; }
                else if (Prefix.ToUpper() == "PROPERTY") { url = "PropertyClaimInfo.aspx"; clsSession.AllowedTab = "4"; }
                else if (Prefix.ToUpper() == "PL") { url = "PLClaimInfo.aspx"; clsSession.AllowedTab = "5"; }
            }

            // show First Reports in view mode
            //check if Url is blank than it redirect to search page
            if (PK_ID > 0 && url != "")
            {
                Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/" + url + "?id=" + Encryption.Encrypt(PK_ID.ToString()));
            }
        }
        else if (e.CommandName == "GoToInvestigation")
        {
              
            string[] args = e.CommandArgument.ToString().Split(':');
            int PK = Convert.ToInt32(args[0]);
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(args[1]);

            bool bLocInfoComplete = new Investigation(PK).Location_Information_Complete;
            //used to set Tab 
            setTab(clsSession.First_Report_Wizard_ID);
            // set flag for whether user is regional officer or not
            bool bIsUserRegOfficer = new Security(Convert.ToDecimal(clsSession.UserID)).IsRegionalOfficer;                      
            Response.Redirect("Investigation.aspx?id=" + Encryption.Encrypt(PK.ToString()) + "&op=view&fsearch=1");
        }
    }

    #endregion   
}
