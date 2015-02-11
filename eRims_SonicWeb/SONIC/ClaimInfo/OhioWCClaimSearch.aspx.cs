using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
public partial class SONIC_ClaimInfo_OhioWCClaimSearch : clsBasePage
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

    #region Page Load Events

    /// <summary>
    /// Bind required dropdown list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        //check Page is Postback or not
        if (!IsPostBack)
        {
            //FIll Sonic Locaition Number Dropdown
            ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true);
            ddlRMLocationNumber.Style.Remove("font-size");
            //fill Location dba Dropdown
            ComboHelper.FillGetSonicLocationdbaList(new DropDownList[] { ddlLocationdba },true);

            //fill Legal entity Dropdown
            ComboHelper.FillGetSonicLocationlegalentityList(new DropDownList[] { ddlLegalEntity }, true);

            //fill Associate Dropdown
            ComboHelper.FillAssociate(new DropDownList[] { ddlAssociateName }, true);

            //fill Claimant Name
            //ComboHelper.FillClaimantNameForOhioWCClaim(new DropDownList[] { ddlClaimantName }, true);

            //fill Claimant Number
            ComboHelper.FillClaimantNumberFormOhioWCClaim(new DropDownList[] { ddlClaimNumber }, true);

            SortBy = "Origin_Claim_Number";
            SortOrder = "Desc";

            ctrlPageClaimInfo.CurrentPage = 1;
            ctrlPageClaimInfo.PageSize = 10;

            ComboHelper.FillGetClaimStatusList(new DropDownList[] { ddlClaimStatus }, true);
            if (Session["Search"] == "Y")
            {
                pnlSearchOhioWCClaim.Visible = false;
                pnlSearchResult.Visible = true;
                BindGrid();
                Session["Y"] = null;
            }
            else
            {
                pnlSearchOhioWCClaim.Visible = true;
                pnlSearchResult.Visible = false;
            }
        }
    }

    #endregion

    #region Dropdown's Selcted Value change Events

    /// <summary>
    /// Set LegalEntity and Locationdba value
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        /// update all other dropdown according to RM location number selected
        ddlLegalEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;

    }

    /// <summary>
    /// Set LegalEntity and RMLocation value
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
        ddlLegalEntity.SelectedValue = ddlLocationdba.SelectedValue;

    }

    /// <summary>
    /// Set LegalEntity and Locationdba value
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to entity selected
        ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
        ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;

    }

    #endregion

    #region Search Button Click Event

    /// <summary>
    /// Call Bind grid method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["OhioClaimcriteria"] = null;
        BindGrid();
    }

    /// <summary>
    /// Set Search criteria Panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        pnlSearchOhioWCClaim.Visible = true;
        ddlRMLocationNumber.SelectedIndex = 0;
        ddlLocationdba.SelectedIndex = 0;
        txtIncidentDate.Text = string.Empty;
        ddlAssociateName.SelectedIndex = 0;
        txtFirstReportNumber.Text = string.Empty;
        ddlLocationdba.SelectedIndex = 0;
        ddlLegalEntity.SelectedIndex = 0;
        ddlClaimNumber.SelectedIndex = 0;
        ddlClaimStatus.SelectedIndex = 0;
        pnlSearchResult.Visible = false;
        Session["OhioClaimCriteria"] = null;
        SortBy = "Origin_Claim_Number";
        SortOrder = "Desc";
        ctrlPageClaimInfo.CurrentPage = 1;
        ctrlPageClaimInfo.PageSize = 10;
    }

    /// <summary>
    /// Reset control value
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlRMLocationNumber.SelectedIndex = 0;
        ddlLocationdba.SelectedIndex = 0;
        txtIncidentDate.Text = string.Empty;
        ddlAssociateName.SelectedIndex = 0;
        txtFirstReportNumber.Text = string.Empty;
        ddlLocationdba.SelectedIndex = 0;
        ddlLegalEntity.SelectedIndex = 0;
        ddlClaimNumber.SelectedIndex = 0;
        ddlClaimStatus.SelectedIndex = 0;
        //ddlClaimantName.SelectedIndex = 0;
    }

    /// <summary>
    /// Redirect OhioWCClaim page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["OhioClaimSearch"] = null;
        Response.Redirect("OhioWCClaim.aspx");
    }


    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid();
    }

    #endregion

    #region "Grid Events"

    /// <summary>
    /// GridView Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimInfoSearchGrid_RowCreated(object sender, GridViewRowEventArgs e)
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
        //check for Data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Find view button and set command argument to find redirect page from Datakey Collection of gridview.
            LinkButton btnView = (LinkButton)e.Row.FindControl("lnkView");
            btnView.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    /// <summary>
    /// GridView Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimInfoSearchGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Rowtype
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDate_of_Accident = (Label)e.Row.FindControl("lblDate_of_Accident");
            //check Date_Of_Incident value from datset. if it is not null than display it in proper format.
            if (DataBinder.Eval(e.Row.DataItem, "Date_of_Accident") != DBNull.Value)
                lblDate_of_Accident.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Date_of_Accident")));
        }
    }

    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimInfoSearchGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid();
    }

    /// <summary>
    /// GridView Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimInfoSearchGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvClaimInfoSearchGrid.DataKeys[Index].Values["PK_ID"] != null) ? Convert.ToInt32(gvClaimInfoSearchGrid.DataKeys[Index].Values["PK_ID"]) : 0;
            string Claim_Type = (gvClaimInfoSearchGrid.DataKeys[Index].Values["Claim_Type"] != null) ? gvClaimInfoSearchGrid.DataKeys[Index].Values["Claim_Type"].ToString() : "";
            string url = (gvClaimInfoSearchGrid.DataKeys[Index].Values["Url"] != null) ? gvClaimInfoSearchGrid.DataKeys[Index].Values["Url"].ToString() : "";
            string IsImported = (gvClaimInfoSearchGrid.DataKeys[Index].Values["Imported"] != null) ? Convert.ToString(gvClaimInfoSearchGrid.DataKeys[Index].Values["Imported"]) : "";

            if (IsImported.ToUpper() == "Y".ToUpper())
               Response.Redirect("OhioWCClaim.aspx?id=" + Encryption.Encrypt(PK_ID.ToString()) + "&op=view");            
            else
                Response.Redirect("OhioWCClaim.aspx?id=" + Encryption.Encrypt(PK_ID.ToString()) + "&op=edit");
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind Claim info into grid
    /// </summary>
    private void BindGrid()
    {
        DataSet objDs = new DataSet();
        DateTime? Date_of_Accident;
        decimal FirstReportNumber = 0, LocationNumber = 0;
        string Active_Inactive = string.Empty, AssociateName = string.Empty, dba = string.Empty, legalentity = string.Empty;
        string ClaimNumber = string.Empty;

        if (Session["OhioClaimcriteria"] != null)
        {
            DataTable dtcriteria = (DataTable)Session["OhioClaimcriteria"];
            DataRow drCriteria = dtcriteria.Rows[0];

            LocationNumber = Convert.ToDecimal(drCriteria["LocationNumber"]);


            if (Convert.ToString(drCriteria["Date_of_Accident"]) == string.Empty)
                    Date_of_Accident = null;
            else
                    Date_of_Accident = clsGeneral.FormatDBNullDateToDate(drCriteria["Date_of_Accident"]);
         
            FirstReportNumber = Convert.ToDecimal(drCriteria["FirstReportNumber"]);
            if (Convert.ToString(drCriteria["Active_Inactive"]) == string.Empty)
                Active_Inactive = null;
            else
                Active_Inactive = Convert.ToString(drCriteria["Active_Inactive"]);
            AssociateName = Convert.ToString(drCriteria["AssociateName"]);
            dba = Convert.ToString(drCriteria["dba"]);
            legalentity = Convert.ToString(drCriteria["legalentity"]);
            ClaimNumber = Convert.ToString(drCriteria["ClaimNumber"]);
            
            Session["OhioClaimcriteria"] = null;
        }

        else
        {
            LocationNumber = Convert.ToDecimal(ddlRMLocationNumber.SelectedValue);

            if (!string.IsNullOrEmpty(txtIncidentDate.Text))
                Date_of_Accident = clsGeneral.FormatDBNullDateToDate(txtIncidentDate.Text);
            else
                Date_of_Accident = null;

            if (!string.IsNullOrEmpty(txtFirstReportNumber.Text))
                FirstReportNumber = Convert.ToDecimal(txtFirstReportNumber.Text);

            AssociateName = ddlAssociateName.SelectedValue;
            dba = ddlLocationdba.SelectedValue;
            legalentity = ddlLegalEntity.SelectedValue;
            ClaimNumber = ddlClaimNumber.SelectedValue;
            if (ddlClaimStatus.SelectedIndex == 0)
                Active_Inactive = null;
            else
                Active_Inactive = ddlClaimStatus.SelectedValue;
        }


        objDs = Workers_Comp_Claims_OH.GetWorkersCompClaimsBySearchCriteria(LocationNumber, Date_of_Accident,
                FirstReportNumber, AssociateName, dba, legalentity, ClaimNumber, Active_Inactive , SortBy, SortOrder, ctrlPageClaimInfo.CurrentPage, ctrlPageClaimInfo.PageSize);
        if (objDs != null && objDs.Tables.Count > 0)
        {
            DataTable dtFRData = objDs.Tables[0];
            //// set values for paging control,so it shows values as needed.
            ctrlPageClaimInfo.TotalRecords = (objDs.Tables.Count >= 3) ? Convert.ToInt32(objDs.Tables[1].Rows[0][0]) : 0;
            ctrlPageClaimInfo.CurrentPage = (objDs.Tables.Count >= 3) ? Convert.ToInt32(objDs.Tables[2].Rows[0][2]) : 0;
            ctrlPageClaimInfo.RecordsToBeDisplayed = dtFRData.Rows.Count;
            ctrlPageClaimInfo.SetPageNumbers();
           

            gvClaimInfoSearchGrid.DataSource = objDs.Tables[0];
            gvClaimInfoSearchGrid.DataBind();

            lblNumber.Text = (objDs.Tables.Count >= 3) ? Convert.ToString(objDs.Tables[1].Rows[0][0]) : "0"; //dsClaimInfo.Tables[0].Rows.Count.ToString(); 

            DataTable dtCriteria = new DataTable();
            dtCriteria.Columns.Add("LocationNumber", typeof(decimal));
            dtCriteria.Columns.Add("Date_of_Accident", typeof(string));
            dtCriteria.Columns.Add("FirstReportNumber", typeof(decimal));
            dtCriteria.Columns.Add("AssociateName", typeof(string));
            dtCriteria.Columns.Add("dba", typeof(string));
            dtCriteria.Columns.Add("legalentity", typeof(string));
            dtCriteria.Columns.Add("ClaimNumber", typeof(string));
            dtCriteria.Columns.Add("Active_Inactive", typeof(string));
            


            DataRow drCriteria = dtCriteria.NewRow();
            drCriteria["LocationNumber"] = LocationNumber;
            drCriteria["Date_of_Accident"] = Date_of_Accident;
            drCriteria["FirstReportNumber"] = FirstReportNumber;
            drCriteria["AssociateName"] = AssociateName;
            drCriteria["dba"] = dba;
            drCriteria["legalentity"] = legalentity;
            drCriteria["ClaimNumber"] = ClaimNumber;
            drCriteria["Active_Inactive"] = Active_Inactive;

            dtCriteria.Rows.Add(drCriteria);
            Session["OhioClaimcriteria"] = dtCriteria;
        }
        else
        {
            gvClaimInfoSearchGrid.DataSource = null;
            gvClaimInfoSearchGrid.DataBind();
            // set record numbers retrieved
            lblNumber.Text = "0";
        }
        pnlSearchOhioWCClaim.Visible = false;
        pnlSearchResult.Visible = true;
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
        foreach (DataControlField field in gvClaimInfoSearchGrid.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvClaimInfoSearchGrid.Columns.IndexOf(field);
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
}