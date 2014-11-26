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

public partial class Controls_Navigation_Navigation : System.Web.UI.UserControl
{

    #region "Events Declaration"
    public delegate void dlgGetPage();
    public event dlgGetPage GetPage;
    #endregion

    #region "Properties"
    public int RecordsToBeDisplayed;
    /// <summary>
    /// Current page to be displayed
    /// </summary>
    public int CurrentPage
    {
        get
        {
            object obj = this.ViewState["CurrPage"];
            if (obj == null)
                return 1;
            else
                return Convert.ToInt32(this.ViewState["CurrPage"]);
        }
        set
        {
            this.ViewState["CurrPage"] = value;            
        }
    }

    /// <summary>
    /// Total records in the table
    /// </summary>
    public int TotalRecords
    {
        get { return Convert.ToInt32(this.ViewState["TotalRecords"]); }
        set { this.ViewState["TotalRecords"] = value; }
    }

    /// <summary>
    /// Number of records per page
    /// </summary>
    //public int PageSize
    //{
    //    get { return drpRecords.SelectedItem != null ? Convert.ToInt32(drpRecords.SelectedItem.Text) : 10; }
        
    //}

    public int PageSize
    {
        get { return drpRecords.SelectedItem != null ? Convert.ToInt32(drpRecords.SelectedItem.Text) : clsSession.NumberOfSearchRows; }
        set
        {

            ListItem lst = drpRecords.Items.FindByText(value.ToString());
            if (lst != null)
            {
                drpRecords.ClearSelection();
                lst.Selected = true;
            }
        }
    }

    /// <summary>
    /// Total number of pages available
    /// </summary>
    public int TotalPages
    {
        get { return Convert.ToInt32(ViewState["TotalPages"]); }
        set { ViewState["TotalPages"] = value; }
    }
    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        // if loaded first time
        if (!IsPostBack)
        {
            // fills the records to be displyaed
            FillDropDownRecords();

            // set pagenumber
            SetPageNumbers();
        }
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Writes the current page number and total page numbers
    /// Also enables or disables next-previous links
    /// </summary>
    public void SetPageNumbers()
    {
        if (!string.IsNullOrEmpty(drpRecords.SelectedValue))
            clsSession.NumberOfSearchRows = Convert.ToInt32(drpRecords.SelectedValue);

        
        if (RecordsToBeDisplayed > 0)
        {
            if (CurrentPage == 0)
                CurrentPage = 1;
            // show current page number.
            lblCurrentPage.Text = CurrentPage.ToString();

            // calculate and show total pages.
            int division = TotalRecords / PageSize;
            int reminder = TotalRecords % PageSize;
            int totalPages = (division > 0) ? (division + ((reminder > 0) ? 1 : 0)) : 1;
            lblTotalPage.Text = totalPages.ToString();
            TotalPages = totalPages;
            // set current page number.
            txtPageNumber.Text = CurrentPage.ToString();

            // enable disable next previous links
            if (CurrentPage <= 1)
                imgPrevious.Enabled = false;
            else
            { imgPrevious.Enabled = true; }

            if (CurrentPage == totalPages)
                imgNext.Enabled = false;
            else
            { imgNext.Enabled = true; }
        }
        else
        {
            if (CurrentPage == 0)
                CurrentPage = 1;
            // show current page number.
            lblCurrentPage.Text = CurrentPage.ToString();

            // calculate and show total pages.            
            int totalPages = 1;
            lblTotalPage.Text = totalPages.ToString();

            // set current page number.
            txtPageNumber.Text = CurrentPage.ToString();

            // enable disable next previous links
            if (CurrentPage == 1)
                imgPrevious.Enabled = false;
            else
            { imgPrevious.Enabled = true; }

            if (CurrentPage == totalPages)
                imgNext.Enabled = false;
            else
            { imgNext.Enabled = true; }
        }
    }


    /// <summary>
    /// Fills the record numbers to be displayed per page
    /// </summary>
    private void FillDropDownRecords()
    {
        int increment = 0;
        for (int i = 0; i < 5; i++)
        {
            increment = increment + 10;
            drpRecords.Items.Add(increment.ToString());
        }
        drpRecords.Items.Insert(0, "1");
        drpRecords.SelectedIndex = 1;
    }

    #endregion

    #region "Controls Events"
    protected void drpRecords_SelectedIndexChanged(object sender, EventArgs e)
    {
        // current page will be if the number typed in the textbox, otherwise 1
        CurrentPage = (txtPageNumber.Text != string.Empty)? Convert.ToInt32(txtPageNumber.Text):1;

        // call the GetPage event. to bind the grid
        GetPage();

        // show page numbers and links in paging control.
        SetPageNumbers();
    }

    protected void imgPrevious_Click(object sender, EventArgs e)
    {
        //Decrement the current page number and set other values
        CurrentPage = CurrentPage - 1;

        // call the GetPage event.
        GetPage();

        // shwo page numbers and links in the control.
        SetPageNumbers();
    }

    protected void imgNext_Click(object sender, EventArgs e)
    {
        //increment the current page number and set other values
        CurrentPage = CurrentPage + 1;

        // call the GetPage event.
        GetPage();

        // shwo page numbers and links in the control.
        SetPageNumbers();
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        
        //current page will be the number typed in the textbox
        CurrentPage = Convert.ToInt32(txtPageNumber.Text);

        if (CurrentPage > TotalPages)
            CurrentPage = TotalPages;

        // call the GetPage event.
        GetPage();

        // shwo page numbers and links in the control.
        SetPageNumbers();
    }
    #endregion

}
