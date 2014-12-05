using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.IO;
using System.Data;
using BAL;

public partial class SONIC_Sedgwick_ClaimSearchGrid : clsBasePage
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

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string PreviousGridSortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["PreviousGridSortBy"]) ? ViewState["PreviousGridSortBy"].ToString() : string.Empty); }
        set { ViewState["PreviousGridSortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string PreviousGridSortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["PreviousGridSortOrder"]) ? ViewState["PreviousGridSortOrder"].ToString() : string.Empty); }
        set { ViewState["PreviousGridSortOrder"] = value; }
    }
    /// <summary>
    /// Sedgwick field Office Id
    /// </summary>
    private int FK_LU_Sedgwick_Field_Office
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                return Convert.ToInt32(Encryption.Decrypt(Request.QueryString["Id"]));
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Year for Claim Reveiw
    /// </summary>
    private int Year
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Year"]))
            {
                return Convert.ToInt32(Encryption.Decrypt(Request.QueryString["Year"]));
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Quarter for Claim Review
    /// </summary>
    private int Quarter
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Quarter"]))
            {
                return Convert.ToInt32(Encryption.Decrypt(Request.QueryString["Quarter"]));
            }
            else
            {
                return 0;
            }
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // set the default sort field and sort order
            SortBy = "RLCM , Origin_Claim_Number";
            SortOrder = "ASC";

            PreviousGridSortBy = "RLCM , Origin_Claim_Number";
            PreviousGridSortOrder = "ASC";
            ////get the data table from session
            //DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
            ////check datatable have atleast one row
            //if (dtSearch.Rows.Count > 0)
            //{
            //    DataRow drSearch = dtSearch.Rows[0];

            //    //get the values from each column of row
            //    decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
            //    lblYear.Text = drSearch["Year"].ToString();
            //    lblQuarter.Text = drSearch["Quarter"].ToString();
            //    lblSedgwickOffice.Text = FK_LU_Sedgwick_Field_Office.ToString();
            //}
            hdnYear.Value = Year.ToString();
            hdnQuarter.Value = Quarter.ToString();
            hdnFKLUSedgwickFieldOffice.Value = FK_LU_Sedgwick_Field_Office.ToString();
            hdnSortBy.Value = SortBy;
            hdnSortOrder.Value = SortOrder;

            // Bind Grid
            BindGrid(1, 50);
            BindPreviousGrid();
            if (App_Access == AccessType.View_Only)
            {
                AttachDetails.isViewOnly = true;
                btnAdd.Visible = false;
                btnSendEmail.Visible = false;
            }
        }
    }

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
        //if (Session["dtClaimReviewWorkSheetGroupSearch"] != null)
        //{
        //get the data table from session
        //DataTable dtSearch = (DataTable)Session["dtClaimReviewWorkSheetGroupSearch"];
        ////check datatable have atleast one row
        //if (dtSearch.Rows.Count > 0)
        //{
        //DataRow drSearch = dtSearch.Rows[0];

        ////get the values from each column of row
        //decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
        //decimal State_PK_ID = Convert.ToDecimal(drSearch["State_PK_ID"]);
        //decimal WC_FR_Number = 0; //Convert.ToDecimal(drSearch["WC_FR_Number"]);
        //string Origin_Claim_Number = Convert.ToString(drSearch["Origin_Claim_Number"]);
        //Int32 AssociatedFirstReport = Convert.ToInt32(drSearch["AssociatedFirstReport"]);
        //string ClaimType = Convert.ToString(drSearch["ClaimType"]);
        //string ClaimStatus = Convert.ToString(drSearch["ClaimStatus"]);
        //decimal LocationNumber = Convert.ToDecimal(drSearch["LocationNumber"]);
        //// selects records depending on paging criteria and search values.
        //DataSet dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search(FK_LU_Sedgwick_Field_Office, State_PK_ID, WC_FR_Number, Origin_Claim_Number, AssociatedFirstReport, ClaimType, ClaimStatus, LocationNumber, SortBy, SortOrder, PageNumber, PageSize);

        DataSet dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search_New(FK_LU_Sedgwick_Field_Office, Year, Quarter, SortBy, SortOrder, PageNumber, PageSize, clsSession.CurrentLoginEmployeeId);
        if (dsClaimInfo != null)
        {
            DataTable dtFRData = dsClaimInfo.Tables[0];

            //// set values for paging control,so it shows values as needed.
            ctrlPageClaimInfo.TotalRecords = (dsClaimInfo.Tables.Count >= 2) ? Convert.ToInt32(dsClaimInfo.Tables[1].Rows[0][0]) : 0;
            ctrlPageClaimInfo.CurrentPage = (dsClaimInfo.Tables.Count >= 2) ? Convert.ToInt32(dsClaimInfo.Tables[1].Rows[0][2]) : 0;
            ctrlPageClaimInfo.RecordsToBeDisplayed = dtFRData.Rows.Count;

            ctrlPageClaimInfo.SetPageNumbers();

            if (Session["dtClaimReviewGroupSearch"] != null)
            {
                //get the data table from session
                DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                //check datatable have atleast one row
                if (dtSearch.Rows.Count > 0)
                {
                    DataRow drSearch = dtSearch.Rows[0];

                    //get the values from each column of row
                    decimal FK_LU_Sedgwick_Field_Office1 = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
                    LU_Sedgwick_Field_Office objLSFO = new LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office1);
                    lblYear.Text = drSearch["Year"].ToString();
                    lblQuarter.Text = drSearch["Quarter"].ToString();
                    lblSedgwickOffice.Text = objLSFO.Fld_Desc.ToString();
                }
            }

            if (dsClaimInfo.Tables.Count >= 3 && dsClaimInfo.Tables[2].Rows.Count > 0)
            {
                //gvSedgwickOffice.DataSource = dsClaimInfo.Tables[2];
                //gvSedgwickOffice.DataBind();
                lblAvgScore.Text = dsClaimInfo.Tables[2].Rows[0]["AVGScore"].ToString();
                lblScoringClassification.Text = dsClaimInfo.Tables[2].Rows[0]["SCR_SCoreClassification"].ToString();
                lblTotalAvgScore.Text = dsClaimInfo.Tables[2].Rows[0]["Total_of_Average_Numeric_Scores"].ToString();
                lblTotalScoringClassifcatn.Text = dsClaimInfo.Tables[2].Rows[0]["Year_SCoreClassification"].ToString();
            }
            // bind the grid.
            gvClaimReviewGroupSearchGrid.DataSource = dtFRData;
            gvClaimReviewGroupSearchGrid.DataBind();

            // set record numbers retrieved
            lblNumber.Text = (dsClaimInfo.Tables.Count >= 2) ? Convert.ToString(dsClaimInfo.Tables[1].Rows[0][0]) : "0"; //dsClaimInfo.Tables[0].Rows.Count.ToString();

            AttachDetails.InitializeAttachmentDetails(0, "FK_Sedgwick_Claim_Review", "PK_Sedgwick_Attachments", true, 0, Year, Quarter, FK_LU_Sedgwick_Field_Office);
            AttachDetails.BindGroupAttachements();
            AttachDetails.FindControl("gvAttachment").DataBind();
        }
        //}
    }
    //else
    //    Response.Redirect("ClaimSearch.aspx");

    //}

    /// <summary>
    /// Binds the previous grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindPreviousGrid()
    {

        DataSet dsPreviousClaimInfo = Sedgwick_Claim_Group.Previous_Sedgwick_ClaimReview_WithOpenActionItem(FK_LU_Sedgwick_Field_Office, Year, Quarter, PreviousGridSortBy, PreviousGridSortOrder, clsSession.CurrentLoginEmployeeId);

        DataTable dtFRData = dsPreviousClaimInfo.Tables[0];

        // bind the grid.
        grdPreviousClaimReview.DataSource = dtFRData;
        grdPreviousClaimReview.DataBind();
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageClaimInfo.CurrentPage, ctrlPageClaimInfo.PageSize);
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
        foreach (DataControlField field in gvClaimReviewGroupSearchGrid.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvClaimReviewGroupSearchGrid.Columns.IndexOf(field);
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

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetPreviousGridSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in grdPreviousClaimReview.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = grdPreviousClaimReview.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddPreviousGridSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetPreviousGridSortColumnIndex(PreviousGridSortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = PreviousGridSortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

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
    /// Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Redirect to the Claim Information Search page
        Response.Redirect("ClaimReviewWorkSheetGroupSearch.aspx", true);
    }

    /// <summary>
    /// Add Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //Redirect to the Claim Information Search page
        Response.Redirect("ClaimSearch.aspx");
    }

    protected void lnkClaimReviewExportToExcel_Click(object sender, EventArgs e)
    {
        DataSet dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search_New(FK_LU_Sedgwick_Field_Office, Year, Quarter, SortBy, SortOrder, 1, Convert.ToInt32(lblNumber.Text), clsSession.CurrentLoginEmployeeId);
        if (dsClaimInfo != null && dsClaimInfo.Tables.Count > 0)
        {
            DataTable dtTemp = dsClaimInfo.Tables[0];
            //DataColumn dcSedgwickOffice = new System.Data.DataColumn("Sedgwick Field Office");
            //dcSedgwickOffice.DefaultValue = lblSedgwickOffice.Text;
            ////dcSedgwickOffice.SetOrdinal(0);
            //dtTemp.Columns.Add(dcSedgwickOffice);

            //DataColumn dcYear = new System.Data.DataColumn("Year");
            //dcYear.DefaultValue = lblYear.Text;
            ////dcYear.SetOrdinal(1);
            //dtTemp.Columns.Add(dcYear);

            //DataColumn dcQuarter = new System.Data.DataColumn("Quarter");
            //dcQuarter.DefaultValue = lblQuarter.Text;
            ////dcQuarter.SetOrdinal(2);
            //dtTemp.Columns.Add(dcQuarter);

            //dtTemp.Columns["Sedgwick Field Office"].SetOrdinal(0);
            //dtTemp.Columns["Year"].SetOrdinal(1);
            //dtTemp.Columns["Quarter"].SetOrdinal(2);
            dtTemp.Columns["RLCM"].SetOrdinal(3);

            dtTemp.Columns["Origin_Claim_Number"].SetOrdinal(4);
            dtTemp.Columns["Origin_Claim_Number"].ColumnName = "Claim Number";

            dtTemp.Columns["Employee_Name"].SetOrdinal(5);
            dtTemp.Columns["Employee_Name"].ColumnName = "Associate Name";

            dtTemp.Columns["dba"].SetOrdinal(6);
            dtTemp.Columns["dba"].ColumnName = "d/b/a";

            dtTemp.Columns["Sonic_Location_Code"].SetOrdinal(7);
            dtTemp.Columns["Sonic_Location_Code"].ColumnName = "Location Number";

            dtTemp.Columns["Date_of_Accident"].SetOrdinal(8);
            dtTemp.Columns["Date_of_Accident"].ColumnName = "Date Of Loss";

            dtTemp.Columns["ClaimIndicator"].SetOrdinal(9);
            dtTemp.Columns["ClaimIndicator"].ColumnName = "Claim Indicator";

            dtTemp.Columns["Review_Complete"].SetOrdinal(10);
            dtTemp.Columns["Review_Complete"].ColumnName = "Review Complete?";

            dtTemp.Columns.Remove("ID");
            dtTemp.Columns.Remove("PK_Workers_Comp_Claims_ID");
            dtTemp.Columns.Remove("Associated_First_Report");
            dtTemp.Columns.Remove("State_PK_Id");
            dtTemp.Columns.Remove("PK_Sedgwick_Claim_Review");
            dtTemp.Columns.Remove("IsEnable");

            clsGeneral.ExportDataSedgwick(dtTemp, "Claim_Review_Worksheet_Group", lblSedgwickOffice.Text,lblYear.Text,lblQuarter.Text);
        }
    }
    protected void lnkOpenActionItems_Click(object sender, EventArgs e)
    {
        DataSet dsPreviousClaimInfo = Sedgwick_Claim_Group.Previous_Sedgwick_ClaimReview_WithOpenActionItem(FK_LU_Sedgwick_Field_Office, Year, Quarter, PreviousGridSortBy, PreviousGridSortOrder, clsSession.CurrentLoginEmployeeId);
        if (dsPreviousClaimInfo != null && dsPreviousClaimInfo.Tables.Count > 0)
        {
            DataTable dtTemp = dsPreviousClaimInfo.Tables[0];

            //DataColumn dcSedgwickOffice = new System.Data.DataColumn("Sedgwick Field Office");
            //dcSedgwickOffice.DefaultValue = lblSedgwickOffice.Text;
            ////dcSedgwickOffice.SetOrdinal(0);
            //dtTemp.Columns.Add(dcSedgwickOffice);

            //dtTemp.Columns["Sedgwick Field Office"].SetOrdinal(0);
            dtTemp.Columns["RLCM"].SetOrdinal(0);
            dtTemp.Columns["Year"].SetOrdinal(1);
            dtTemp.Columns["Quarter"].SetOrdinal(2);            

            dtTemp.Columns["Origin_Claim_Number"].SetOrdinal(3);
            dtTemp.Columns["Origin_Claim_Number"].ColumnName = "Claim Number";

            dtTemp.Columns["Employee_Name"].SetOrdinal(4);
            dtTemp.Columns["Employee_Name"].ColumnName = "Associate Name";

            dtTemp.Columns["dba"].SetOrdinal(5);
            dtTemp.Columns["dba"].ColumnName = "d/b/a";

            dtTemp.Columns["Sonic_Location_Code"].SetOrdinal(6);
            dtTemp.Columns["Sonic_Location_Code"].ColumnName = "Location Number";

            dtTemp.Columns["Date_of_Accident"].SetOrdinal(7);
            dtTemp.Columns["Date_of_Accident"].ColumnName = "Date Of Loss";

            dtTemp.Columns["ClaimIndicator"].SetOrdinal(8);
            dtTemp.Columns["ClaimIndicator"].ColumnName = "Claim Indicator";

            dtTemp.Columns["MgtSection"].SetOrdinal(9);
            dtTemp.Columns["MgtSection"].ColumnName = "Management Section(s) with Open Action Plan Items";

            dtTemp.Columns.Remove("PK_Workers_Comp_Claims_ID");
            dtTemp.Columns.Remove("Associated_First_Report");
            dtTemp.Columns.Remove("State_PK_Id");
            dtTemp.Columns.Remove("PK_Sedgwick_Claim_Review");
            dtTemp.Columns.Remove("IsEnable");
            

            clsGeneral.ExportDataSedgwick(dtTemp, "Claim_Review_Worksheet_Group", lblSedgwickOffice.Text,lblYear.Text,lblQuarter.Text);
        }

    }

    #region "Grid Events"
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimReviewGroupSearchGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ClaimSummary")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');

            decimal PK = Convert.ToDecimal(strArgs[0]);//Convert.ToDecimal(e.CommandArgument.ToString());
            decimal PK_Sedgwick_Claim_Review = Convert.ToDecimal(strArgs[1]);
            bool bIsSave = Convert.ToBoolean(strArgs[2]);
            Response.Redirect("ClaimSummary.aspx?PK_WCC_ID=" + PK.ToString() + "&PK_SCR=" + PK_Sedgwick_Claim_Review.ToString() + "&IsSave=" + bIsSave + "&IsReturn=false");
        }
        if (e.CommandName == "Remove")
        {
            decimal PK_Sedgwick_Claim_Review = Convert.ToDecimal(e.CommandArgument.ToString());

            Sedgwick_Claim_Review.Delete(PK_Sedgwick_Claim_Review);
            Response.Redirect("ClaimSearchGrid.aspx?Id=" + Encryption.Encrypt(Convert.ToString(FK_LU_Sedgwick_Field_Office)) + "&Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Quarter=" + Encryption.Encrypt(Convert.ToString(Quarter)), true);
        }
    }

    /// <summary>
    /// GridView Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimReviewGroupSearchGrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (App_Access == AccessType.View_Only)
            {
                for (int colIndex = 1; colIndex < e.Row.Cells.Count; colIndex++)
                {
                    string cellText = HttpUtility.HtmlDecode(e.Row.Cells[colIndex].Text).Trim();

                    if (cellText == "Remove")
                    {
                        e.Row.Cells[colIndex].Text = string.Empty;
                    }
                }
            }

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
        if (App_Access == AccessType.View_Only)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image imgRemove = ((Image)e.Row.FindControl("imgRemove"));

                if (imgRemove != null)
                {
                    imgRemove.Visible = false;
                }
            }
        }
    }

    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimReviewGroupSearchGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageClaimInfo.CurrentPage, ctrlPageClaimInfo.PageSize);
        hdnSortBy.Value = SortBy;
        hdnSortOrder.Value = SortOrder;
    }

    /// <summary>
    /// GridView Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdPreviousClaimReview_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != PreviousGridSortBy)
            {
                // update sort image beside the column header 
                AddPreviousGridSortImage(e.Row);
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
        if (App_Access == AccessType.View_Only)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image imgRemove = ((Image)e.Row.FindControl("imgRemove"));

                if (imgRemove != null)
                {
                    imgRemove.Visible = false;
                }
            }
        }
    }

    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdPreviousClaimReview_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        PreviousGridSortOrder = (PreviousGridSortBy == e.SortExpression) ? (PreviousGridSortOrder == "asc" ? "desc" : "asc") : "asc";
        PreviousGridSortBy = e.SortExpression;
        BindPreviousGrid();
    }

    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdPreviousClaimReview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ClaimSummary")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');

            decimal PK = Convert.ToDecimal(strArgs[0]);
            decimal PK_Sedgwick_Claim_Review = Convert.ToDecimal(strArgs[1]);
            bool bIsSave = Convert.ToBoolean(strArgs[2]);
            Response.Redirect("ClaimSummary.aspx?PK_WCC_ID=" + PK.ToString() + "&PK_SCR=" + PK_Sedgwick_Claim_Review.ToString() + "&IsSave=" + bIsSave + "&IsReturn=false");
        }
    }
    #endregion
    #endregion

    
}