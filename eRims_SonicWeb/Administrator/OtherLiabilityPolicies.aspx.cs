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

public partial class Administration_OtherLiabilityPolicies : clsBasePage
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
    // PK for Producer
    public int PK_COI_Other_Policies
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PolicyID"]);
        }
        set { ViewState["PolicyID"] = value; }
    }
    #endregion

    #region "Page Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtSearch.Focus();
            SortOrder = "asc";
            SortBy = "Fld_Desc";
            BindGrid(1, 10, string.Empty);
        }
    }
    #endregion

    #region "Methods"

    private void BindGrid(int PageNumber, int PageSize, string strFld_Desc)
    {
        // selects records depending on paging criteria.
        DataSet dsSecurity = COI_Other_Policy_LiabilityType.SelectByPaging(PageNumber, PageSize, strFld_Desc.Replace("'", "''"), SortBy, SortOrder);
        DataTable dtSecurity = dsSecurity.Tables[0];

        // set values for paging control
        ctrlPageSecurity.TotalRecords = (dsSecurity.Tables.Count > 1) ? Convert.ToInt32(dsSecurity.Tables[1].Rows[0][0]) : 0;
        ctrlPageSecurity.CurrentPage = (dsSecurity.Tables.Count > 1) ? Convert.ToInt32(dsSecurity.Tables[1].Rows[0][2]) : 1;
        ctrlPageSecurity.RecordsToBeDisplayed = dtSecurity.Rows.Count;
        ctrlPageSecurity.SetPageNumbers();
        // bind the grid.
        gvPolicyTypes.DataSource = dtSecurity;
        gvPolicyTypes.DataBind();

        // set record numbers retrieved
        lblNumber.Text = ctrlPageSecurity.TotalRecords.ToString();
    }
    protected void GetPage()
    {
        BindGrid(ctrlPageSecurity.CurrentPage, ctrlPageSecurity.PageSize, txtSearch.Text.Trim());
    }
    private void BindControlforEdit(Int32 PK)
    {
        DataTable dt = COI_Other_Policy_LiabilityType.SelectByPK(PK).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtPolicyName.Text = dt.Rows[0]["Fld_Desc"].ToString();
            hdnPK.Value = PK.ToString();
        }
    }
    #endregion

    #region "Grid Events"

    protected void gvPolicyTypes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "UpdatePT")
        {
            dvAddMode.Visible = true;
            dvAddMode.Style["display"] = "block";
            PK_COI_Other_Policies = Convert.ToInt32(e.CommandArgument);
            txtPolicyName.Focus();
            BindControlforEdit(PK_COI_Other_Policies);

        }
        else if (e.CommandName == "DeleteDT")
        {
            COI_Other_Policy_LiabilityType obj = new COI_Other_Policy_LiabilityType();
            obj.PK_Other_Policy_Types = Convert.ToInt32(e.CommandArgument);

            obj.Delete();
           // ctrlPageSecurity.CurrentPage = 1;
            GetPage();
        }
    }
    protected void gvPolicyTypes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the row type if it is header row or data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }

    }
    protected void gvPolicyTypes_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }

    #endregion

    #region "Control Events"

    protected void btnAddPolicy_Click(object sender, EventArgs e)
    {
        txtPolicyName.Text = "";
        txtPolicyName.Focus();
        dvAddMode.Visible = true;
        dvAddMode.Style["display"] = "block";
        PK_COI_Other_Policies = 0;

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetPage();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        COI_Other_Policy_LiabilityType obj = new COI_Other_Policy_LiabilityType(Convert.ToDecimal(hdnPK.Value));
        obj.Fld_Desc = txtPolicyName.Text;
        obj.PK_Other_Policy_Types = PK_COI_Other_Policies;
        if (PK_COI_Other_Policies > 0)
        {
            obj.Update();
        }
        else
        {
            obj.Insert();
        }
        BindGrid(1, 10, string.Empty);
        dvAddMode.Style["display"] = "none";
        // GetPage();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        dvResult.Visible = true;
        dvAddMode.Visible = false;
    }
    #endregion

    #region "Sorting"

    protected void gvSecurity_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageSecurity.CurrentPage, ctrlPageSecurity.PageSize, txtSearch.Text.Trim());
    }
    protected void gvSecurity_RowCreated(object sender, GridViewRowEventArgs e)
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
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 intCol = GetSortColumnIndex(SortBy);
        if (intCol == -1)
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
        headerRow.Cells[intCol].Controls.Add(sortImage);
    }
    private int GetSortColumnIndex(object strSortExp)
    {
        int intRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvPolicyTypes.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {
                intRet = gvPolicyTypes.Columns.IndexOf(field);
            }
        }
        return intRet;
    }

    #endregion
}
