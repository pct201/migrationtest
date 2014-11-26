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

public partial class Liability_Policy_search_popup : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CPolicy m_objpolicy;
    List<RIMS_Base.CPolicy> lstpolicy = null;
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
            m_objpolicy = new RIMS_Base.Biz.CPolicy();
            lstpolicy = new List<RIMS_Base.CPolicy>();
            lstpolicy = m_objpolicy.Get_Search_Data(ddlSearch.SelectedValue, txtsearch.Text.Trim());
            gvEmployeeDetails.DataSource = lstpolicy;
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
            lstpolicy = new List<RIMS_Base.CPolicy>();
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

            lstpolicy = BindEmpDetails();
            if (ViewState["SortExp"] != null)
                lstpolicy.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CPolicy >((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvEmployeeDetails.DataSource = lstpolicy;
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



                LinkButton lbtnTempid = new LinkButton();
                LinkButton lbtnpolicyNo = new LinkButton();
                LinkButton lbtnflood = new LinkButton();
                LinkButton lbtnpropery = new LinkButton();
                LinkButton lbtnphydamage = new LinkButton();
                LinkButton lbtnextraExpends  = new LinkButton();
                LinkButton lbtnbusinessintruption = new LinkButton();
                LinkButton lbtntotal = new LinkButton();


                lbtnTempid = ((LinkButton)(e.Row.FindControl("lbtnid")));
                lbtnpolicyNo = ((LinkButton)(e.Row.FindControl("lbtnpolicyno")));
                lbtnflood = ((LinkButton)(e.Row.FindControl("lbtnMiddle")));
                lbtnpropery = ((LinkButton)(e.Row.FindControl("lbtnLastName")));
                lbtnphydamage = ((LinkButton)(e.Row.FindControl("lbtnSocialSeco")));
                lbtnextraExpends = ((LinkButton)(e.Row.FindControl("lbtnSocialSeco")));
                lbtnbusinessintruption = ((LinkButton)(e.Row.FindControl("lbtnSocialSeco")));
                lbtntotal = ((LinkButton)(e.Row.FindControl("lbtnSocialSeco")));



                //Label lblTemp = new Label();
                //lblTemp = ((Label)(e.Row.FindControl("lblpkid")));
                //// Session["empid"] = lbtnTempid.CommandArgument.ToString();
                //lblTemp.Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString()
                //    + "','" + lbtnTempMiddle.CommandArgument.ToString()
                //    + "','" + lbtnTempLast.CommandArgument.ToString() + "','"
                //    + lbtnTempid.CommandArgument.ToString()
                //    + "');");
                //((LinkButton)(e.Row.FindControl("lbtnFirstName"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                //((LinkButton)(e.Row.FindControl("lbtnMiddle"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                //((LinkButton)(e.Row.FindControl("lbtnLastName"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                //((LinkButton)(e.Row.FindControl("lbtnid"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");
                //((LinkButton)(e.Row.FindControl("lbtnSocialSeco"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "','" + lbtnTempLast.CommandArgument.ToString() + "','" + lbtnTempid.CommandArgument.ToString() + "');");




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
    private List<RIMS_Base.CPolicy > BindEmpDetails()
    {
        try
        {
            m_objpolicy = new RIMS_Base.Biz.CPolicy ();
            lstpolicy = new List<RIMS_Base.CPolicy >();
            lstpolicy = null;
            if (txtsearch.Text != string.Empty)
            {
                lstpolicy = m_objpolicy.Get_Search_Data(ddlSearch.SelectedValue, txtsearch.Text.Trim());
            }
            else
            {
                lstpolicy = m_objpolicy.GetAll();
            }
            return lstpolicy;
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
