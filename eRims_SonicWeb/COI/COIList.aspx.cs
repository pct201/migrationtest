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
using System.IO;
using ERIMS.DAL;
public partial class Admin_COIList : clsBasePage
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

    #endregion
    
    #region "Page Events"
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // page is loaded first time
        if (!IsPostBack)
        {
            SortOrder = "asc";
            SortBy = "Insured_Name";
            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                // if page is loaded first time bind grid for first 10 records. on first page.
                BindGrid(1, 10);
                // Query String has a=1 , then it rediret to Generate COI List page
                if (clsGeneral.IsNull(Request.QueryString["a"]))
                {
                    gvCOI.Columns[0].Visible = false;
                    btnAddNew.Visible = (App_Access == AccessType.Administrative_Access);
                    btnGenerateCOI.Visible = false;
                }
                else
                {
                    gvCOI.Columns[0].Visible = true;
                    gvCOI.Columns[gvCOI.Columns.Count - 1].Visible = false;
                    btnAddNew.Visible = false;
                    btnGenerateCOI.Visible = true;
                    btnSearch.Visible = false;
                }
                if (App_Access == AccessType.NotAssigned || App_Access == AccessType.View_Only)
                    btnAddNew.Visible = false;
            }
        }
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        // check for session containing all search values if it is null or not
        // if null then  redirect to search page
        if (Session["dtCOISearch"] != null)
        {
            //get the data table from session
            DataTable dtCOISearch = (DataTable)Session["dtCOISearch"];
            // get the row from data table
            DataRow dr = dtCOISearch.Rows[0];
            //get the values from each column of row
            string strInsuredName = dr["strInsuredName"].ToString();
            string strAddress = dr["strAddress"].ToString();
            string strCity = dr["strCity"].ToString();
            int intState = Convert.ToInt32(dr["intState"]);
            string strIssueDateFrom;
            if (dr["dtIssueDateFrom"].ToString() == string.Empty)
                strIssueDateFrom = ((DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).ToString();
            else
                strIssueDateFrom = dr["dtIssueDateFrom"].ToString();

            string strIssueDateTo;
            if (dr["dtIssueDateTo"].ToString() == string.Empty)
                strIssueDateTo = ((DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).ToString();
            else
                strIssueDateTo = dr["dtIssueDateTo"].ToString();

            string strLocationNum = "";
            string strGeneralPolicyNum = dr["strGeneralPolicyNum"].ToString();
            string strAutoPolicyNum = dr["strAutoPolicyNum"].ToString();
            string strExcessPolicyNum = dr["strExcessPolicyNum"].ToString();
            string strWCPolicyNum = dr["strWCPolicyNum"].ToString();
            string strPropertyPolicyNum = dr["strPropertyPolicyNum"].ToString();
            string strLocationdba = Convert.ToString(dr["strLocationdba"]);
            string strLocationCode = Convert.ToString(dr["strLocationCode"]);

            // selects records depending on paging criteria and search values.
            DataSet dsCOIs = COIs.SearchByPaging(strInsuredName, strAddress, strCity, intState, strIssueDateFrom, strIssueDateTo, strLocationNum, strGeneralPolicyNum, strAutoPolicyNum, strExcessPolicyNum, strWCPolicyNum, strPropertyPolicyNum,strLocationdba,strLocationCode, PageNumber, PageSize, SortBy, SortOrder);
            DataTable dtCOIs = dsCOIs.Tables[0];

            // set values for paging control,so it shows values as needed.
            ctrlPageCOI.TotalRecords = (dsCOIs.Tables.Count >= 2) ? Convert.ToInt32(dsCOIs.Tables[1].Rows[0][0]) : 0;
            ctrlPageCOI.CurrentPage = (dsCOIs.Tables.Count > 1) ? Convert.ToInt32(dsCOIs.Tables[2].Rows[0][2]) : 1;           
            ctrlPageCOI.RecordsToBeDisplayed = dtCOIs.Rows.Count;
            ctrlPageCOI.SetPageNumbers();

            // bind the grid.
            gvCOI.DataSource = dtCOIs;
            gvCOI.DataBind();

            // set record numbers retrieved
            lblNumber.Text = ctrlPageCOI.TotalRecords.ToString();
            ctrlPageCOI.FindControl("drpRecords").Focus();
        }
        else
        {
            //redirect to Search page
            if (clsGeneral.IsNull(Request.QueryString["a"]))
                Response.Redirect("COISearch.aspx");
            else
                Response.Redirect("COISearch.aspx?a=1");
        }
    }
    #endregion

    #region "Control Events"

    /// <summary>
    /// Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("COISearch.aspx");
    }

    /// <summary>
    /// COI Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCOI_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // get the current COI id.
        if (e.CommandName == "ViewCOI")
        {
            // show COI record in view mode
            int COI_ID = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("COIAddEdit.aspx?op=view&id=" + Encryption.Encrypt(COI_ID.ToString()));
        }
        else if (e.CommandName == "EditCOI")
        {
            // show COI record in edit mode
            int COI_ID = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("COIAddEdit.aspx?op=edit&id=" + Encryption.Encrypt(COI_ID.ToString()));
        }
        else if (e.CommandName == "DeleteCOI")
        {
            // Delete Attachment from Attachment Folder
            DataTable dtAttachment = COI_Attachment.SelectByTableName(clsGeneral.TableNames[(int)(clsGeneral.Tables.Certificates_of_Insurance)], Convert.ToInt32(e.CommandArgument)).Tables[0];
            for (int i = 0; i < dtAttachment.Rows.Count; i++)
            {
                string strDocPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)(clsGeneral.Tables.Certificates_of_Insurance)]) + @"\" + dtAttachment.Rows[i]["Attachment_Name"].ToString();
                if (File.Exists(strDocPath))
                    File.Delete(strDocPath);
            }
            //delete the related Insured recod

            COI_Insureds.Delete(new COIs(Convert.ToDecimal(e.CommandArgument)).FK_COI_Insureds);
            // delete selected COI record
            COIs.Delete(Convert.ToDecimal(e.CommandArgument));

            // Bind again the grid after deletion
            BindGrid(ctrlPageCOI.CurrentPage, ctrlPageCOI.PageSize);
        }
    }
  
    /// <summary>
    /// Handles COI Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the row type if it is header row or data row
        if (e.Row.RowType == DataControlRowType.DataRow)        {
           
            if (App_Access == AccessType.Administrative_Access)
            {               
                // get the delete link control
                Button lnkDelete = (Button)e.Row.FindControl("lnkDelete");

                // get insured name and Issue date for the COI
                string strInsured = DataBinder.Eval(e.Row.DataItem, "Insured_Name").ToString().Trim();
                string strIssuedate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Issue_Date")).ToString(AppConfig.DisplayDateFormat);
                strInsured = strInsured.Replace("'", "singlequot");
                //show message for confirmation for deleting the record when clicking on link
                lnkDelete.Attributes.Add("onclick", "javascript:return ConfirmDelete('" + strInsured + "','" + strIssuedate + "');");
            }
            if (App_Access == AccessType.NotAssigned || App_Access == AccessType.View_Only)
            {
                ((Button)e.Row.FindControl("lnkEdit")).Visible = false;
                ((Button)e.Row.FindControl("lnkDelete")).Visible = false;
            }
        }
    }

    /// <summary>
    /// Handles Add New Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        //open COI page in add mode
        Response.Redirect("COIAddEdit.aspx");
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageCOI.CurrentPage, ctrlPageCOI.PageSize);
    }
    /// <summary>
    /// Handles GenerateCOI Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateCOI_Click(object sender, EventArgs e)
    {
        string strCOIs = String.Empty;
        foreach (GridViewRow gRow in gvCOI.Rows)
        {
            CheckBox chkSelect = (CheckBox)gRow.FindControl("chkSelect");
            if (chkSelect.Checked)
            {
                HtmlInputHidden hdnCOIID = (HtmlInputHidden)gRow.FindControl("hdnCOIID");
                strCOIs += hdnCOIID.Value + ",";
            }
        }
        strCOIs = strCOIs.TrimEnd(',');
        Session["COIsToGeneratePDF"] = strCOIs;
        Response.Redirect("GenerateCOI.aspx");
    }

    #endregion

    #region Sorting
    /// <summary>
    /// Handles COI Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCOI_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageCOI.CurrentPage, ctrlPageCOI.PageSize);
    }
   /// <summary>
   /// Handles COI Row Created Event
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void gvCOI_RowCreated(object sender, GridViewRowEventArgs e)
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

    /// <summary>
    /// Add in Column Sort Image
    /// </summary>
    /// <param name="headerRow"></param>
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
    
    //Set Sort Column Image set
    private int GetSortColumnIndex(object strSortExp)
    {
        int intRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvCOI.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {
                intRet = gvCOI.Columns.IndexOf(field);
            }
        }
        return intRet;
    }
    #endregion 
}
