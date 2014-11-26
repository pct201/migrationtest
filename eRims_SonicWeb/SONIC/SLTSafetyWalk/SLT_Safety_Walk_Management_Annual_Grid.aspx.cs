using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_SLTSafetyWalk_SLT_Safety_Walk_Management_Annual_Grid : clsBasePage
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
    /// Year for SLT Safety
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

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // set the default sort field and sort order
            SortBy = "Temp_Sort_Order,intMonth";
            SortOrder = "ASC";

            lblYear.Text = Year.ToString();
            // Bind Grid
            BindGrid(1, 10);
        }
    }

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        DataSet dsMonthlyQuestions = LU_SLT_Safety_Walk_Focus_Area.Search(Year, "",true, SortBy, SortOrder, PageNumber, PageSize);
        if (dsMonthlyQuestions != null)
        {
            if (dsMonthlyQuestions.Tables.Count > 0)
            {
                DataTable dtMonthlyQuestions = dsMonthlyQuestions.Tables[0];

                //// set values for paging control,so it shows values as needed.
                ctrlPageAnnualQue.TotalRecords = (dsMonthlyQuestions.Tables.Count >= 3) ? Convert.ToInt32(dsMonthlyQuestions.Tables[2].Rows[0][0]) : 0;
                ctrlPageAnnualQue.CurrentPage = (dsMonthlyQuestions.Tables.Count >= 3) ? Convert.ToInt32(dsMonthlyQuestions.Tables[2].Rows[0][2]) : 0;
                ctrlPageAnnualQue.RecordsToBeDisplayed = dtMonthlyQuestions.Rows.Count;
                ctrlPageAnnualQue.SetPageNumbers();

                // bind the grid.
                gvAnnualQuestions.DataSource = dtMonthlyQuestions;
                gvAnnualQuestions.DataBind();
                if (Convert.ToInt32(dsMonthlyQuestions.Tables[1].Rows[0][0]) >= 12)
                    btnAdd.Visible = false;
                else
                    btnAdd.Visible = true;
                if (gvAnnualQuestions.Rows.Count > 0)
                {
                    ImageButton lnkUp = (gvAnnualQuestions.Rows[0].FindControl("imgUp") as ImageButton);
                    ImageButton lnkDown = (gvAnnualQuestions.Rows[gvAnnualQuestions.Rows.Count - 1].FindControl("imgDown") as ImageButton);
                    lnkUp.Visible = false;
                    lnkDown.Visible = false;
                }
                //set record numbers retrieved
                lblNumber.Text = (dsMonthlyQuestions.Tables.Count >= 3) ? Convert.ToString(dsMonthlyQuestions.Tables[2].Rows[0][0]) : "0"; //dsClaimInfo.Tables[0].Rows.Count.ToString(); 
                if (dtMonthlyQuestions.Rows.Count == 0)
                    ahrefEditFocusArea.Visible = false;
            }
        }
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageAnnualQue.CurrentPage, ctrlPageAnnualQue.PageSize);
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
        foreach (DataControlField field in gvAnnualQuestions.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvAnnualQuestions.Columns.IndexOf(field);
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
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAnnualQuestions_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageAnnualQue.CurrentPage, ctrlPageAnnualQue.PageSize);
    }

    /// <summary>
    /// GridView Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAnnualQuestions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkActive = (LinkButton)e.Row.FindControl("lnkActive");
            HiddenField lnkSort_Order = (HiddenField)e.Row.FindControl("hdnIntMonth");

            if (lnkActive != null)
            {
                //lnkActive.Text = Convert.ToString(e.Row.RowIndex);
                if (lnkActive.Text == "N")
                {
                    ((ImageButton)e.Row.FindControl("imgUp")).Visible = false;
                    ((ImageButton)e.Row.FindControl("imgDown")).Visible = false;
                }
            }
            if (lnkSort_Order != null)
            {
                DataSet dsMonthlyQuestions = LU_SLT_Safety_Walk_Focus_Area.Search(Year, "",true, SortBy, SortOrder, ctrlPageAnnualQue.CurrentPage, ctrlPageAnnualQue.PageSize);

                DataTable dtMonthlyQuestions = dsMonthlyQuestions.Tables[0];

                // bind the grid.
                dtMonthlyQuestions.DefaultView.RowFilter = " Active = 'Y'";
                dtMonthlyQuestions = dtMonthlyQuestions.DefaultView.ToTable();

                if (lnkSort_Order.Value == "1")
                    ((ImageButton)e.Row.FindControl("imgUp")).Visible = false;
                else if (lnkSort_Order.Value == dtMonthlyQuestions.Rows.Count.ToString())
                    ((ImageButton)e.Row.FindControl("imgDown")).Visible = false;
                else if (lnkSort_Order.Value == "12")
                    ((ImageButton)e.Row.FindControl("imgDown")).Visible = false;
                if (lnkSort_Order.Value == "1" && dtMonthlyQuestions.Rows.Count == 1)
                {
                    ((ImageButton)e.Row.FindControl("imgUp")).Visible = false;
                    ((ImageButton)e.Row.FindControl("imgDown")).Visible = false;
                }
            }
        }
    }

    protected void gvAnnualQuestions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("SLT_Safety_Walk_Management_Annual.aspx?id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&Year=" + Encryption.Encrypt(Convert.ToString(Year)), true);
        }
        if (e.CommandName == "up")
        {
            LU_SLT_Safety_Walk_Focus_Area.UpdateSortOrder_Annual(Convert.ToDecimal(e.CommandArgument), e.CommandName);
            BindGrid(ctrlPageAnnualQue.CurrentPage, ctrlPageAnnualQue.PageSize);
        }
        if (e.CommandName == "down")
        {
             LU_SLT_Safety_Walk_Focus_Area.UpdateSortOrder_Annual(Convert.ToDecimal(e.CommandArgument), e.CommandName);
            BindGrid(ctrlPageAnnualQue.CurrentPage, ctrlPageAnnualQue.PageSize);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("SLT_Safety_Walk_Management_Annual.aspx?id=" + Encryption.Encrypt("0") + "&Year=" + Encryption.Encrypt(Convert.ToString(Year)), true);
    }
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        Response.Redirect("AnnualQuestions.aspx", true);
    }
    protected void btnhdnReload_Click(object sender, EventArgs e)
    {
        BindGrid(ctrlPageAnnualQue.CurrentPage, ctrlPageAnnualQue.PageSize);
    }
}