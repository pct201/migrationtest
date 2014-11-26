using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.IO;
using System.Data;
using BAL;
using System.Web.UI.HtmlControls;

public partial class SONIC_Sedgwick_ClaimReviewWorksheetSearchGrid : clsBasePage
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
    /// Selected Claim ids in grid.
    /// </summary>
    public string SelectedClaimIds
    {
        get { return (!clsGeneral.IsNull(Session["ClaimIds"]) ? Session["ClaimIds"].ToString() : string.Empty); }
        set { Session["ClaimIds"] = value; }
    }

    /// <summary>
    /// holds all cliamids in comma seperated form
    /// </summary>
    private string AllClaimIds
    {
        get { return (!clsGeneral.IsNull(ViewState["AllClaimIds"]) ? ViewState["AllClaimIds"].ToString() : string.Empty); }
        set { ViewState["AllClaimIds"] = value; }
    }

    private bool isAllchecked
    {
        get { return (!clsGeneral.IsNull(ViewState["isAllchecked"]) ? Convert.ToBoolean(ViewState["isAllchecked"]) : false); }
        set { ViewState["isAllchecked"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SelectedClaimIds = null;

            // set the default sort field and sort order
            SortBy = "Origin_Claim_Number";
            SortOrder = "ASC";

            if (App_Access == AccessType.View_Only)
            {
                btnAddToClaimReview.Visible = false;
            }

            // Bind Grid
            BindGrid(1, 50);
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
    }

    protected void gvClaimReviewGroupSearchGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chkAll = (CheckBox)e.Row.FindControl("chkAllCheckClaim");

            if (App_Access == AccessType.View_Only)
            {
                chkAll.Visible = false;
            }
            else 
            {
                chkAll.Visible = true;
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkb = (CheckBox)e.Row.FindControl("chkClaimNumber");

            if (App_Access == AccessType.View_Only)
            {
                chkb.Visible = false;
            }
            else
            {
                //Find dropdown control & get values
                HtmlInputHidden hdnPK_Workers_Comp_Claims_ID = (HtmlInputHidden)e.Row.FindControl("hdnPK_Workers_Comp_Claims_ID");
                string Pk_Claim = hdnPK_Workers_Comp_Claims_ID.Value;

                //Find checkbox and checked/Unchecked based on values                

                if (SelectedClaimIds.Contains(Pk_Claim.ToString()))
                {
                    chkb.Checked = true;
                }
                else
                {
                    chkb.Checked = false;
                }
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
        if (Session["dtClaimReviewWorkSheetSearch"] != null)
        {
            //get the data table from session
            DataTable dtSearch = (DataTable)Session["dtClaimReviewWorkSheetSearch"];
            //check datatable have atleast one row
            if (Session["dtClaimReviewGroupSearch"] != null)
            {
                //get the data table from session
                DataTable dtClaimReviewGroupSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                //check datatable have atleast one row
                if (dtClaimReviewGroupSearch.Rows.Count > 0)
                {
                    DataRow drClaimReviewGroupSearch = dtClaimReviewGroupSearch.Rows[0];

                    //get the values from each column of row
                    decimal FK_LU_Sedgwick_Field_Office1 = Convert.ToDecimal(drClaimReviewGroupSearch["FK_LU_Sedgwick_Field_Office"]);
                    LU_Sedgwick_Field_Office objLSFO = new LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office1);

                    lblYear.Text = drClaimReviewGroupSearch["Year"].ToString();
                    lblQuarter.Text = drClaimReviewGroupSearch["Quarter"].ToString();
                    lblSedgwickOffice.Text = objLSFO.Fld_Desc.ToString();


                    if (dtSearch.Rows.Count > 0)
                    {
                        DataRow drSearch = dtSearch.Rows[0];

                        //get the values from each column of row
                        decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
                        decimal State_PK_ID = Convert.ToDecimal(drSearch["State_PK_ID"]);
                        decimal WC_FR_Number = 0; //Convert.ToDecimal(drSearch["WC_FR_Number"]);
                        string Origin_Claim_Number = Convert.ToString(drSearch["Origin_Claim_Number"]);
                        Int32 AssociatedFirstReport = Convert.ToInt32(drSearch["AssociatedFirstReport"]);
                        string ClaimType = Convert.ToString(drSearch["ClaimType"]);
                        string ClaimStatus = Convert.ToString(drSearch["ClaimStatus"]);
                        decimal LocationNumber = Convert.ToDecimal(drSearch["LocationNumber"]);
                        Nullable<DateTime> DateFROMAccident;
                        Nullable<DateTime> DateToAccident;
                        if (Convert.ToDateTime(drSearch["DateFromAccident"]) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                            DateFROMAccident = clsGeneral.FormatDateToStore(drSearch["DateFromAccident"]);
                        else
                            DateFROMAccident = null;

                        if (Convert.ToDateTime(drSearch["DateToAccident"]) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                            DateToAccident = clsGeneral.FormatDateToStore(drSearch["DateToAccident"]);
                        else
                            DateToAccident = null;

                        string LT_Med_Only_FlagForWC = Convert.ToString(drSearch["LT_Med_Only_FlagForWC"]);
                        string LT_Med_Only_FlagForNS = Convert.ToString(drSearch["LT_Med_Only_FlagForNS"]);
                        // selects records depending on paging criteria and search values.
                        DataSet dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search(FK_LU_Sedgwick_Field_Office, Convert.ToInt32(drClaimReviewGroupSearch["Year"]), Convert.ToInt32(drClaimReviewGroupSearch["Quarter"]), State_PK_ID, WC_FR_Number, Origin_Claim_Number, AssociatedFirstReport, ClaimType, DateFROMAccident, DateToAccident, ClaimStatus, LocationNumber,LT_Med_Only_FlagForWC,LT_Med_Only_FlagForNS, SortBy, SortOrder, PageNumber, PageSize);

                        if (dsClaimInfo != null && dsClaimInfo.Tables.Count > 0)
                        {
                            DataTable dtFRData = dsClaimInfo.Tables[0];

                            //// set values for paging control,so it shows values as needed.
                            ctrlPageClaimInfo.TotalRecords = (dsClaimInfo.Tables.Count >= 4) ? Convert.ToInt32(dsClaimInfo.Tables[1].Rows[0][0]) : 0;
                            ctrlPageClaimInfo.CurrentPage = (dsClaimInfo.Tables.Count >= 4) ? Convert.ToInt32(dsClaimInfo.Tables[2].Rows[0][2]) : 0;
                            ctrlPageClaimInfo.RecordsToBeDisplayed = dtFRData.Rows.Count;
                            ctrlPageClaimInfo.SetPageNumbers();


                            //if (dsClaimInfo.Tables.Count >= 4 && dsClaimInfo.Tables[3].Rows.Count > 0)
                            //{
                            //    gvSedgwickOffice.DataSource = dsClaimInfo.Tables[3];
                            //    gvSedgwickOffice.DataBind();
                            //}
                            // bind the grid.
                            gvClaimReviewGroupSearchGrid.DataSource = dtFRData;
                            gvClaimReviewGroupSearchGrid.DataBind();

                            if (dsClaimInfo.Tables[4].Rows.Count > 0)
                            {
                                AllClaimIds = Convert.ToString(dsClaimInfo.Tables[4].Rows[0][0]);
                            }                            

                            // set record numbers retrieved
                            lblNumber.Text = (dsClaimInfo.Tables.Count >= 3) ? Convert.ToString(dsClaimInfo.Tables[1].Rows[0][0]) : "0"; //dsClaimInfo.Tables[0].Rows.Count.ToString(); 
                        }
                        else
                        {
                            gvClaimReviewGroupSearchGrid.DataSource = null;
                            gvClaimReviewGroupSearchGrid.DataBind();
                            // set record numbers retrieved
                            lblNumber.Text = "0"; 
                        }
                    }
                }
            }
        }
        else
            Response.Redirect("ClaimSearch.aspx");

    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        GetSelectedClaimsIds();
        BindGrid(ctrlPageClaimInfo.CurrentPage, ctrlPageClaimInfo.PageSize);

        if (!string.IsNullOrEmpty(SelectedClaimIds))
        {
            CheckBox HeaderCheckbox = gvClaimReviewGroupSearchGrid.HeaderRow.Cells[0].FindControl("chkAllCheckClaim") as CheckBox;

            if (!HeaderCheckbox.Checked && isAllchecked == true)
            {
                HeaderCheckbox.Checked = true;
            }
        }
        else
        {
            CheckBox HeaderCheckbox = gvClaimReviewGroupSearchGrid.HeaderRow.Cells[0].FindControl("chkAllCheckClaim") as CheckBox;

            if (!HeaderCheckbox.Checked)
            {
                HeaderCheckbox.Checked = false;
            }
        }        

        if (!string.IsNullOrEmpty(SelectedClaimIds))
        {
            btnAddToClaimReview.Style["display"] = "";
        }
        else
        {
            btnAddToClaimReview.Style["display"] = "none";
        }
    }

    private void GetSelectedClaimsIds()
    {
        string strPK = "";
        string strClaimId = string.Empty;

        if (string.IsNullOrEmpty(SelectedClaimIds))
            strPK = SelectedClaimIds;
        else
            strPK = SelectedClaimIds + ",";

        foreach (GridViewRow gRow in gvClaimReviewGroupSearchGrid.Rows)
        {
            strClaimId = ((HtmlInputHidden)gRow.FindControl("hdnPK_Workers_Comp_Claims_ID")).Value;

            if (((CheckBox)gRow.FindControl("chkClaimNumber")).Checked)
            {
                if (!strPK.Contains(strClaimId))
                    strPK = strPK + strClaimId + ",";
            }
            else
            {
                strPK = strPK.Replace(strClaimId, "").Replace(",,", ",").Replace(" ,","");
            }
        }

        strPK = strPK.TrimEnd(',').TrimStart(',');

        SelectedClaimIds = strPK;
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
    /// Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SelectedClaimIds = null;
        //Redirect to the Claim Information Search page
        Response.Redirect("ClaimSearch.aspx", true);
    }
    protected void btntest_Click(object sender, EventArgs e)
    {
        //bool isChecked = Convert.ToBoolean(Request["__EVENTARGUMENT"]);

        int isChecked = Convert.ToInt32(Request["__EVENTARGUMENT"]);

        if (isChecked == 1)
        {
            isAllchecked = true;
            SelectedClaimIds = AllClaimIds;

            foreach (GridViewRow gRow in gvClaimReviewGroupSearchGrid.Rows)
            {
                CheckBox chk = ((CheckBox)gRow.FindControl("chkClaimNumber"));

                if (!chk.Checked)
                {
                    chk.Checked = true;
                }
            }

        }
        else if (isChecked == 0)
        {
            isAllchecked = false;

            SelectedClaimIds = null;

            foreach (GridViewRow gRow in gvClaimReviewGroupSearchGrid.Rows)
            {
                CheckBox chk = ((CheckBox)gRow.FindControl("chkClaimNumber"));

                if (chk.Checked)
                {
                    chk.Checked = false;
                }
            }
        }
        else
        {
            isAllchecked = false;
            CheckBox HeaderCheckbox = gvClaimReviewGroupSearchGrid.HeaderRow.Cells[0].FindControl("chkAllCheckClaim") as CheckBox;

            if (HeaderCheckbox.Checked)
            {
                HeaderCheckbox.Checked = false;
            }
        }

        if (!string.IsNullOrEmpty(SelectedClaimIds))
        {
            btnAddToClaimReview.Style["display"] = "";
        }
        else
        {
            btnAddToClaimReview.Style["display"] = "none";
        }
    }

    /// <summary>
    /// Claim Review Button Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddToClaimReview_Click(object sender, EventArgs e)
    {
        //string strPK = "";

        //foreach (GridViewRow gRow in gvClaimReviewGroupSearchGrid.Rows)
        //{
        //    if (((CheckBox)gRow.FindControl("chkClaimNumber")).Checked)
        //        strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK_Workers_Comp_Claims_ID")).Value + ",";
        //}

        //strPK = strPK.TrimEnd(',');

        //if (strPK != string.Empty)
        GetSelectedClaimsIds();

        if (SelectedClaimIds != string.Empty)
        {

           
            //string[] strClaimCompID = SelectedClaimIds.Split(',');
            //for (int i = 0; i < strClaimCompID.Length; i++)
            //{
            //    decimal PK_SCR = 0;
            //    decimal PK_SCG = 0;
            //    Sedgwick_Claim_Review objSCR = new Sedgwick_Claim_Review();

            //    Sedgwick_Claim_Group objSCG = new Sedgwick_Claim_Group();
                if (Session["dtClaimReviewGroupSearch"] != null)
                {
                    DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                    if (dtSearch.Rows.Count > 0)
                    {
                        DataRow drSearch = dtSearch.Rows[0];
                        decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);

                         Sedgwick_Claim_Review objSCR = new Sedgwick_Claim_Review();
                         objSCR.Sedgwick_Claim_Review_CopyFromPreviousQuarter(FK_LU_Sedgwick_Field_Office, SelectedClaimIds, Convert.ToInt32(drSearch["Year"].ToString()), Convert.ToInt32(drSearch["Quarter"].ToString()), clsSession.UserID, DateTime.Now, Convert.ToDecimal(clsSession.CurrentLoginEmployeeId));
                        //objSCG.FK_LU_Sedgwick_Field_Office = FK_LU_Sedgwick_Field_Office;
                        //objSCG.Year = Convert.ToInt32(drSearch["Year"].ToString());
                        //objSCG.Quarter = Convert.ToInt32(drSearch["Quarter"].ToString());
                        //objSCG.Review_Complete = null;
                        //objSCG.Update_Date = DateTime.Now.Date;
                        //objSCG.Updated_By = clsSession.UserID;
                        //PK_SCG = objSCG.Insert();

                        //objSCR.PK_Sedgwick_Claim_Review = 0;
                        //objSCR.FK_Sedgwick_Claim_Group = Convert.ToDecimal(PK_SCG);
                        //objSCR.FK_Workers_Comp_Claims = Convert.ToDecimal(strClaimCompID[i]);
                        //objSCR.Claim_Review_Complete = "N";

                        //objSCR.Overall_Comments = "";
                        //objSCR.Date_Of_File_Review = null;
                        //objSCR.Date_Of_Last_Review = null;
                        //objSCR.Sedgwick_Team_Leader = "";
                        //objSCR.Adjuster = "";
                        //objSCR.Update_Date = DateTime.Now.Date;
                        //objSCR.Updated_By = clsSession.UserID;
                        //PK_SCR = objSCR.Insert();
                    }
                }
            //    DataSet dsClaimReviewList = LU_Sedgwick_Evaluation.SelectAllDistinctMgtSection();
            //    DataTable dtWCTransList = dsClaimReviewList.Tables[0];

            //    foreach (DataRow row in dtWCTransList.Rows)
            //    {
            //        string MgtSection = row["Management_Section"].ToString();

            //        DataSet dsEvaluationList = LU_Sedgwick_Evaluation.SelectBy_MgtSection(MgtSection, Convert.ToDecimal(PK_SCR));
            //        DataTable dtEvaluationList = dsEvaluationList.Tables[0];

            //        foreach (DataRow Childrow in dtEvaluationList.Rows)
            //        {
            //            decimal PK_LU_Sedgwick_Evaluation = Convert.ToDecimal(Childrow["FK_LU_Sedgwick_Evaluation"]);
            //            Sedgwick_Claim_RLCM_Comments objSCRC = new Sedgwick_Claim_RLCM_Comments();
            //            objSCRC.Comments = "";

            //            decimal PK_Sedgwick_Claim_RLCM_Comments;
            //            PK_Sedgwick_Claim_RLCM_Comments = 0;

            //            if (PK_Sedgwick_Claim_RLCM_Comments > 0)
            //                objSCRC.PK_Sedgwick_Claim_RLCM_Comments = PK_Sedgwick_Claim_RLCM_Comments;

            //            if (PK_SCR > 0)
            //                objSCRC.FK_Sedgwick_Claim_Review = Convert.ToDecimal(PK_SCR);

            //            objSCRC.FK_LU_Sedgwick_Evaluation = PK_LU_Sedgwick_Evaluation;
            //            objSCRC.Management_Section = MgtSection.ToString();
            //            objSCRC.Update_Date = DateTime.Now.Date;
            //            objSCRC.Updated_By = clsSession.UserID;
            //            if (PK_Sedgwick_Claim_RLCM_Comments == 0)
            //                objSCRC.Insert();
            //            else
            //                objSCRC.Update();
            //        }

            //        DataSet dsNestedClaimReviewList = Sedgwick_Claim_Action_Plan.SelectBy_MgtSection(MgtSection, Convert.ToDecimal(PK_SCR));
            //        DataTable dtNestedTransList = dsNestedClaimReviewList.Tables[0];

            //        foreach (DataRow ActionPlanrow in dtNestedTransList.Rows)
            //        {

            //            Sedgwick_Claim_Action_Plan objCAP = new Sedgwick_Claim_Action_Plan();

            //            objCAP.Actual_Date = null;
            //            objCAP.Target_Date = null;
            //            objCAP.RLCM_Sedgwick = "RLCM";
            //            objCAP.Action_Item = null;
            //            objCAP.Management_Section = MgtSection.ToString();
            //            objCAP.FK_Sedgwick_Claim_Review = Convert.ToDecimal(PK_SCR);
            //            objCAP.Update_Date = DateTime.Now.Date;
            //            objCAP.Updated_By = clsSession.UserID;
            //            decimal PK_Sedgwick_Claim_Action_Plan;
            //            PK_Sedgwick_Claim_Action_Plan = 0;

            //            if (PK_Sedgwick_Claim_Action_Plan > 0)
            //                objCAP.PK_Sedgwick_Claim_Action_Plan = PK_Sedgwick_Claim_Action_Plan;

            //            objCAP.Update_Date = DateTime.Now.Date;
            //            objCAP.Updated_By = clsSession.UserID;

            //            if (PK_Sedgwick_Claim_Action_Plan == 0)
            //                objCAP.Insert();
            //            else
            //                objCAP.Update();
            //        }


            //        objSCR.PK_Sedgwick_Claim_Review = Convert.ToDecimal(PK_SCR);
            //        objSCR.FK_Workers_Comp_Claims = Convert.ToDecimal(strClaimCompID[i]); //Convert.ToDecimal(Request.QueryString["PK_WCC_ID"]);
            //        objSCR.Medical_Score = 0;
            //        objSCR.Diability_Score = 0;
            //        objSCR.Leadership_Score = 0;
            //        objSCR.Litigation_Score = 0;
            //        objSCR.Subrogation_Score = 0;
            //        objSCR.Settlemente_Closure_Score = 0;
            //        objSCR.Reserves_Score = 0;

            //        objSCR.Claim_Review_Complete = "N";

            //        objSCR.Overall_Comments = "";
            //        objSCR.Date_Of_File_Review = null;
            //        objSCR.Date_Of_Last_Review = null;
            //        objSCR.Sedgwick_Team_Leader = "";
            //        objSCR.Adjuster = "";
            //        objSCR.Update_Date = DateTime.Now.Date;
            //        objSCR.Updated_By = clsSession.UserID;
            //    }
            //    objSCR.Update();
            //}
        }
        if (Session["dtClaimReviewGroupSearch"] != null)
        {
            DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
            if (dtSearch.Rows.Count > 0)
            {
                DataRow drSearch = dtSearch.Rows[0];
                Response.Redirect("ClaimSearchGrid.aspx?Id=" + Encryption.Encrypt(drSearch["FK_LU_Sedgwick_Field_Office"].ToString()) + "&Year=" + Encryption.Encrypt(drSearch["Year"].ToString()) + "&Quarter=" + Encryption.Encrypt(drSearch["Quarter"].ToString()), true);
            }
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
            Response.Redirect("ClaimSummary.aspx?PK_WCC_ID=" + PK.ToString() + "&PK_SCR=" + PK_Sedgwick_Claim_Review.ToString() + "&IsSave=false");
        }
    }
    #endregion
    #endregion
}