using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_SLTSafetyWalk_SLT_Safety_Walk_Management_Monthly_Grid : clsBasePage
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

    /// <summary>
    /// Month for SLT Safety
    /// </summary>
    private string Month
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Month"]))
            {
                return Encryption.Decrypt(Request.QueryString["Month"]);
            }
            else
            {
                return string.Empty;
            }
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // set the default sort field and sort order
            SortBy = "Temp_Sort_Order,Sort_Order";
            SortOrder = "ASC";

            lblYear.Text = Year.ToString();
            lblMonth.Text = Month.ToString();
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
        DataSet dsMonthlyQuestions = LU_SLT_Safety_Walk_Focus_Area.Search(Year,Month, false,SortBy, SortOrder, PageNumber, PageSize);
        if(dsMonthlyQuestions != null)
        {
            if (dsMonthlyQuestions.Tables.Count > 0)
            {
                DataTable dtMonthlyQuestions = dsMonthlyQuestions.Tables[0];

                //// set values for paging control,so it shows values as needed.
                ctrlPageMonthlyQue.TotalRecords = (dsMonthlyQuestions.Tables.Count >= 3) ? Convert.ToInt32(dsMonthlyQuestions.Tables[2].Rows[0][0]) : 0;
                ctrlPageMonthlyQue.CurrentPage = (dsMonthlyQuestions.Tables.Count >= 3) ? Convert.ToInt32(dsMonthlyQuestions.Tables[2].Rows[0][2]) : 0;
                ctrlPageMonthlyQue.RecordsToBeDisplayed = dtMonthlyQuestions.Rows.Count;
                ctrlPageMonthlyQue.SetPageNumbers();

                // bind the grid.
                gvMonthlyQuestions.DataSource = dtMonthlyQuestions;
                gvMonthlyQuestions.DataBind();
                dtMonthlyQuestions.DefaultView.RowFilter = " Active = 'Y'";
                dtMonthlyQuestions = dtMonthlyQuestions.DefaultView.ToTable();
                if (dtMonthlyQuestions.Rows.Count >= 5)
                    btnAdd.Visible = false;
                else
                    btnAdd.Visible = true;

                // set record numbers retrieved
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
        BindGrid(ctrlPageMonthlyQue.CurrentPage, ctrlPageMonthlyQue.PageSize);
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
        foreach (DataControlField field in gvMonthlyQuestions.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvMonthlyQuestions.Columns.IndexOf(field);
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
    protected void gvMonthlyQuestions_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageMonthlyQue.CurrentPage, ctrlPageMonthlyQue.PageSize);
    }

    /// <summary>
    /// GridView Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMonthlyQuestions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkActive = (LinkButton)e.Row.FindControl("lnkActive");
            LinkButton lnkSort_Order = (LinkButton)e.Row.FindControl("lnkSort_Order");

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
                DataSet dsMonthlyQuestions = LU_SLT_Safety_Walk_Focus_Area.Search(Year, Month, false,SortBy, SortOrder, ctrlPageMonthlyQue.CurrentPage, ctrlPageMonthlyQue.PageSize);

                DataTable dtMonthlyQuestions = dsMonthlyQuestions.Tables[0];

                // bind the grid.
                dtMonthlyQuestions.DefaultView.RowFilter = " Active = 'Y'";
                dtMonthlyQuestions = dtMonthlyQuestions.DefaultView.ToTable();

                if (lnkSort_Order.Text == "1")
                    ((ImageButton)e.Row.FindControl("imgUp")).Visible = false;
                else if (lnkSort_Order.Text == dtMonthlyQuestions.Rows.Count.ToString())
                    ((ImageButton)e.Row.FindControl("imgDown")).Visible = false;
                if (lnkSort_Order.Text == "1" && dtMonthlyQuestions.Rows.Count == 1)
                {
                    ((ImageButton)e.Row.FindControl("imgUp")).Visible = false;
                    ((ImageButton)e.Row.FindControl("imgDown")).Visible = false;
                }
            }
        }
    }

    protected void gvMonthlyQuestions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("SLT_Safety_Walk_Management_Monthly.aspx?id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)), true);
        }
        if (e.CommandName == "up")
        {
            LU_SLT_Safety_Walk_Focus_Area.UpdateSortOrder_Monthly(Convert.ToDecimal(e.CommandArgument),e.CommandName);
            BindGrid(ctrlPageMonthlyQue.CurrentPage, ctrlPageMonthlyQue.PageSize);
        }
        if (e.CommandName == "down")
        {
            LU_SLT_Safety_Walk_Focus_Area.UpdateSortOrder_Monthly(Convert.ToDecimal(e.CommandArgument), e.CommandName);
            BindGrid(ctrlPageMonthlyQue.CurrentPage, ctrlPageMonthlyQue.PageSize);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("SLT_Safety_Walk_Management_Monthly.aspx?id=" + Encryption.Encrypt("0") +"&Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)), true);
    }
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        Response.Redirect("MonthlyQuestions.aspx", true);
    }

    protected void btnhdnReload_Click(object sender, EventArgs e)
    {
        BindGrid(ctrlPageMonthlyQue.CurrentPage, ctrlPageMonthlyQue.PageSize);
    }
}