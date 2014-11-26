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

public partial class Liability_Claimant_search : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CClaimant m_objClaimant;
    List<RIMS_Base.CClaimant> lstClaimant = null;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            gvEmployeeDetails.PageSize = 10;
            gvEmployeeDetails.DataSource = BindEmpDetails();
            gvEmployeeDetails.DataBind();

        }

    }
    #region Event Handlers
    protected void btnSearch_Click1(object sender, EventArgs e)
    {

        try
        {
            m_objClaimant = new RIMS_Base.Biz.CClaimant();
            lstClaimant = new List<RIMS_Base.CClaimant>();
            lstClaimant = m_objClaimant.Get_Search_Data(ddlSearch.SelectedValue,txtsearch.Text.Trim());
            gvEmployeeDetails.DataSource = lstClaimant;
            gvEmployeeDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvEmployeeDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstClaimant = new List<RIMS_Base.CClaimant>();
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
            ViewState["SortExp"] = e.SortExpression;

            lstClaimant = BindEmpDetails();
            if (ViewState["SortExp"] != null)
                lstClaimant.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CClaimant>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvEmployeeDetails.DataSource = lstClaimant;
            gvEmployeeDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvEmployeeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                if (Request.QueryString["Page"] == "ClaimSearch")
                {
                    LinkButton lbtnTempid = new LinkButton();
                    LinkButton lbtnTempFirst = new LinkButton();
                    LinkButton lbtnTempMiddle = new LinkButton();
                    LinkButton lbtnTempLast = new LinkButton();
                    LinkButton lbtnSocialSeco = new LinkButton();

                    lbtnTempid = ((LinkButton)(e.Row.FindControl("lblpkid")));
                    lbtnTempFirst = ((LinkButton)(e.Row.FindControl("lbtnFirstName")));
                    lbtnTempMiddle = ((LinkButton)(e.Row.FindControl("lbtnMiddle")));
                    lbtnTempLast = ((LinkButton)(e.Row.FindControl("lbtnLastName")));
                    lbtnSocialSeco = ((LinkButton)(e.Row.FindControl("lbtnSocialSeco")));

                    lbtnTempid.Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString()
                        + "','" + lbtnTempMiddle.CommandArgument.ToString()
                        + "','" + lbtnTempLast.CommandArgument.ToString() + "','"
                        + lbtnTempid.CommandArgument.ToString()
                        + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnFirstName"))).Attributes.Add("onclick", "fillClaimSearch('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnMiddle"))).Attributes.Add("onclick", "fillClaimSearch('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnLastName"))).Attributes.Add("onclick", "fillClaimSearch('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnid"))).Attributes.Add("onclick", "fillClaimSearch('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnSocialSeco"))).Attributes.Add("onclick", "fillClaimSearch('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                }
                else
                {
                    LinkButton lbtnTempid = new LinkButton();
                    LinkButton lbtnTempFirst = new LinkButton();
                    LinkButton lbtnTempMiddle = new LinkButton();
                    LinkButton lbtnTempLast = new LinkButton();
                    LinkButton lbtnSocialSeco = new LinkButton();

                    lbtnTempid = ((LinkButton)(e.Row.FindControl("lblpkid")));
                    lbtnTempFirst = ((LinkButton)(e.Row.FindControl("lbtnFirstName")));
                    lbtnTempMiddle = ((LinkButton)(e.Row.FindControl("lbtnMiddle")));
                    lbtnTempLast = ((LinkButton)(e.Row.FindControl("lbtnLastName")));
                    lbtnSocialSeco = ((LinkButton)(e.Row.FindControl("lbtnSocialSeco")));



                    //  Label lblTemp = new Label();
                    // lblTemp = ((Label)(e.Row.FindControl("lblpkid")));
                    // Session["empid"] = lbtnTempid.CommandArgument.ToString();
                    lbtnTempid.Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString()
                        + "','" + lbtnTempMiddle.CommandArgument.ToString()
                        + "','" + lbtnTempLast.CommandArgument.ToString() + "','"
                        + lbtnTempid.CommandArgument.ToString()
                        + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnFirstName"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnMiddle"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnLastName"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnid"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnSocialSeco"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    #endregion
    #region Private Methods
    /// <summary>
    /// Get the All Employee's Details
    /// </summary>
    private List<RIMS_Base.CClaimant> BindEmpDetails()
    {
        try
        {
            m_objClaimant = new RIMS_Base.Biz.CClaimant();
            lstClaimant = new List<RIMS_Base.CClaimant>();
            lstClaimant = null;
            if (txtsearch.Text != string.Empty)
            {
                lstClaimant = m_objClaimant.Get_Search_Data(ddlSearch.SelectedValue, txtsearch.Text.Trim());
            }
            else
            {
                lstClaimant = m_objClaimant.GetAll();
            }
            return lstClaimant;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    #endregion

}
