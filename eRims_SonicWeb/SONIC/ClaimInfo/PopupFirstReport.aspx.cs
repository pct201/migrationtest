using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SONIC_FirstReport_PopupFirstReport : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy
    {
        get { return Convert.ToString(ViewState["SortBy"]); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder
    {
        get { return Convert.ToString(ViewState["SortOrder"]); }
        set { ViewState["SortOrder"] = value; }
    }

    private int _PageSize
    {
        get { return Convert.ToInt32(ViewState["PageSize"]); }
        set { ViewState["PageSize"] = value; }
    }

    private int _PageNum
    {
        get { return Convert.ToInt32(ViewState["PageNum"]); }
        set { ViewState["PageNum"] = value; }
    }

    #endregion

    #region "Page Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _SortOrder = "Asc";
            _SortBy = "WC_FR_NUMBER";
            BindGrid();
        }
    }
    #endregion

    #region "Method"
    private void BindGrid()
    {
        string Regional = string.Empty;
        Nullable<decimal> CurrentEmployee = new ERIMS.DAL.Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        DataSet dsRegion = ERIMS.DAL.Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;

        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;

        DataView dvRecord = ERIMS.DAL.Workers_Comp_Claims_OH.SelectAssociatedFirstReport(Regional, CurrentEmployee).Tables[0].DefaultView;
        dvRecord.Sort = _SortBy + " " + _SortOrder;
        gvFirstReport.DataSource = dvRecord;
        gvFirstReport.DataBind();
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(_SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = _SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

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
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvFirstReport.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvFirstReport.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    #endregion

    #region "GridView Events"

    /// <summary>
    /// Handles event when grid header link is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFirstReport_Sorting(object sender, GridViewSortEventArgs e)
    {
        // set the sort order and sort column
        _SortBy = e.SortExpression;
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";

        // binds the grid
        BindGrid();
    }

    protected void gvFirstReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy)
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

    protected void gvFirstReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strPK_WC_FR_ID = "", strWC_FR_NUMBER = "", strEmpName = "", strDBA = "", strDateOfIncident = "", strSonic_Location_Code = "";

                strPK_WC_FR_ID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PK_WC_FR_ID"));
                strWC_FR_NUMBER = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "WC_FR_NUMBER"));
                strEmpName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name"));
                strDBA = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DBA"));
                strDateOfIncident = Convert.ToString(clsGeneral.FormatDBNullDateToDisplay(DataBinder.Eval(e.Row.DataItem, "Date_Of_Incident")));
                strSonic_Location_Code = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sonic_Location_Code")); 

                string strJSFunction = "return SelectValue('" + strPK_WC_FR_ID + "','" + strWC_FR_NUMBER + "','" + strEmpName + "','" + strDBA + "','" + strSonic_Location_Code + "','" + strDateOfIncident + "');";

                ((LinkButton)(e.Row.FindControl("lnkWC_FR_NUMBER"))).Attributes.Add("onclick", strJSFunction);
                ((LinkButton)(e.Row.FindControl("lnkNAME"))).Attributes.Add("onclick", strJSFunction);
                ((LinkButton)(e.Row.FindControl("lnkDBA"))).Attributes.Add("onclick", strJSFunction);
                ((LinkButton)(e.Row.FindControl("lnkDate_Of_Incident"))).Attributes.Add("onclick", strJSFunction);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Handles event when grid page link is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFirstReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // set new page index
        gvFirstReport.PageIndex = e.NewPageIndex;

        // bind the grid
        BindGrid();
    }
    #endregion
}
