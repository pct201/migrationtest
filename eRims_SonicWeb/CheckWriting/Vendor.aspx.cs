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
using System.Collections.Generic;

public partial class CheckWriting_Vendor : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CVendor m_objVendorDetails;
    List<RIMS_Base.CVendor> lstVendorDetails = null;
    string strSortExp = string.Empty;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //gvVendorDetails.PageSize = 10;
            gvVendorDetails.DataSource = BindVendorDetails();
            gvVendorDetails.DataBind();
        }

    }
    #region Event Handlers
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            m_objVendorDetails = new RIMS_Base.Biz.CVendor();
            lstVendorDetails = new List<RIMS_Base.CVendor>();
            lstVendorDetails = m_objVendorDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            gvVendorDetails.DataSource = lstVendorDetails;
            gvVendorDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvVendorDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstVendorDetails = new List<RIMS_Base.CVendor>();
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            // Changes the sort direction 
            else
            {
                if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                    ViewState["sortDirection"] = SortDirection.Descending;
                else
                    ViewState["sortDirection"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = strSortExp = e.SortExpression;

            lstVendorDetails = BindVendorDetails();
            if (ViewState["SortExp"] != null)
                lstVendorDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CVendor>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvVendorDetails.DataSource = lstVendorDetails;
            gvVendorDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvVendorDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbtnTemp = new LinkButton();
                lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnVendorName")));
                Label lblTemp = new Label();
                lblTemp = ((Label)(e.Row.FindControl("lblPKId")));
                //string Temp = string.Empty;
                //Temp = "javascript:return fillPayto(" + lbtnTemp.CommandArgument.ToString() + "," + lblTemp.Text + ");";

                lbtnTemp.Attributes.Add("onclick", "javascript:return fillPayto('" + lbtnTemp.CommandArgument.ToString().Replace("'", "\\'") + "','" + lblTemp.Text + "');");
                ((LinkButton)(e.Row.FindControl("lbtnVendorTaxId"))).Attributes.Add("onclick", "javascript:return fillPayto('" + lbtnTemp.CommandArgument.ToString().Replace("'", "\\'") + "','" + lblTemp.Text + "');");
                ((LinkButton)(e.Row.FindControl("lbtnVendorType"))).Attributes.Add("onclick", "javascript:return fillPayto('" + lbtnTemp.CommandArgument.ToString().Replace("'", "\\'") + "','" + lblTemp.Text + "');");

                //lbtnTemp.Attributes.Add("onclick", Temp);
                //((LinkButton)(e.Row.FindControl("lbtnVendorTaxId"))).Attributes.Add("onclick", Temp);
                //((LinkButton)(e.Row.FindControl("lbtnVendorType"))).Attributes.Add("onclick", Temp);



            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    protected void gvVendorDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
        }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvVendorDetails.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvVendorDetails.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 iCol = GetSortColumnIndex(strSortExp);
        if (-1 == iCol)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();

        if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
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
    #region Private Methods
    /// <summary>
    /// Get the All Vendor's Details
    /// </summary>
    private List<RIMS_Base.CVendor> BindVendorDetails()
    {
        try
        {
            m_objVendorDetails = new RIMS_Base.Biz.CVendor();
            lstVendorDetails = new List<RIMS_Base.CVendor>();
            lstVendorDetails = null;
            if (txtSearch.Text != string.Empty)
            {
                lstVendorDetails = m_objVendorDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstVendorDetails = m_objVendorDetails.GetAll();
            }
            return lstVendorDetails;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    /// <summary>
    /// General Function for Sorting.
    /// </summary>
    private void GeneralSorting()
    {
        try
        {
            lstVendorDetails = new List<RIMS_Base.CVendor>();
            lstVendorDetails = BindVendorDetails();
            if (ViewState["sortDirection"] != null && ViewState["SortExp"] != null)
            {
                lstVendorDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CVendor>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvVendorDetails.DataSource = lstVendorDetails;
            gvVendorDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

}
