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
using RIMS_Base.Biz;

public partial class WorkerCompensation_CostCenter_Popup : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.cCostCenter m_objemp;
    List<RIMS_Base.cCostCenter> lstCostDetails = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvCostCenterDetails.PageSize = 10;
            gvCostCenterDetails.DataSource = BindCostCenterDetails();
            gvCostCenterDetails.DataBind();
        }

    }
    #region Event Handlers
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            m_objemp = new RIMS_Base.Biz.cCostCenter();
            lstCostDetails = new List<RIMS_Base.cCostCenter>();
            lstCostDetails = m_objemp.Get_Search_Data(ddlSearch.SelectedValue, txtsearch.Text.Trim());
            gvCostCenterDetails.DataSource = lstCostDetails;
            gvCostCenterDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvCostCenterDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstCostDetails = new List<RIMS_Base.cCostCenter>();
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

            lstCostDetails = BindCostCenterDetails();
            if (ViewState["SortExp"] != null)
                lstCostDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.cCostCenter>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvCostCenterDetails.DataSource = lstCostDetails;
            gvCostCenterDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvCostCenterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["Page"] == "Employee")
                {
                    LinkButton lbtncost = new LinkButton();
                    LinkButton lbtndivision = new LinkButton();
                    LinkButton lbtnaddress = new LinkButton();
                    LinkButton lbtnTemp = new LinkButton();

                    lbtncost = ((LinkButton)(e.Row.FindControl("lbtncostcenter")));
                    lbtndivision = ((LinkButton)(e.Row.FindControl("lbtnDivisionname")));
                    lbtnaddress = ((LinkButton)(e.Row.FindControl("lbtnaddress")));

                    Label lblTemp1 = new Label();
                    lblTemp1 = ((Label)(e.Row.FindControl("lblpkid")));

                    lblTemp1.Attributes.Add("onclick", "fillEmpCC('" + lbtncost.CommandArgument.ToString() + "','" + lbtnaddress.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtncostcenter"))).Attributes.Add("onclick", "fillEmpCC('" + lbtncost.CommandArgument.ToString() + "','" + lbtnaddress.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnDivisionname"))).Attributes.Add("onclick", "fillEmpCC('" + lbtncost.CommandArgument.ToString() + "','" + lbtnaddress.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnaddress"))).Attributes.Add("onclick", "fillEmpCC('" + lbtncost.CommandArgument.ToString() + "','" + lbtnaddress.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                }
             else if (Request.QueryString["Page"] == "Entity")
                {
                    LinkButton lbtncost = new LinkButton();
                    LinkButton lbtndivision = new LinkButton();
                    LinkButton lbtnaddress = new LinkButton();
                    LinkButton lbtnTemp = new LinkButton();

                    lbtncost = ((LinkButton)(e.Row.FindControl("lbtncostcenter")));
                    lbtndivision = ((LinkButton)(e.Row.FindControl("lbtnDivisionname")));
                    lbtnaddress = ((LinkButton)(e.Row.FindControl("lbtnaddress")));

                    Label lblTemp1 = new Label();
                    lblTemp1 = ((Label)(e.Row.FindControl("lblpkid")));

                    lblTemp1.Attributes.Add("onclick", "fillEmpCCPopup('" + lbtncost.CommandArgument.ToString() + "','" + lbtnaddress.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtncostcenter"))).Attributes.Add("onclick", "fillEmpCCPopup('" + lbtncost.CommandArgument.ToString() + "','" + lbtnaddress.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnDivisionname"))).Attributes.Add("onclick", "fillEmpCCPopup('" + lbtncost.CommandArgument.ToString() + "','" + lbtnaddress.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnaddress"))).Attributes.Add("onclick", "fillEmpCCPopup('" + lbtncost.CommandArgument.ToString() + "','" + lbtnaddress.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                }

                    
                else if (Request.QueryString["Page"] == "liabilitycost")
                {
                    LinkButton lbtncost = new LinkButton();
                    LinkButton lbtndivision = new LinkButton();
                    LinkButton lbtnaddress = new LinkButton();
                    LinkButton lbtnTemp = new LinkButton();

                    lbtncost = ((LinkButton)(e.Row.FindControl("lbtncostcenter")));
                    lbtndivision = ((LinkButton)(e.Row.FindControl("lbtnDivisionname")));
                    lbtnaddress = ((LinkButton)(e.Row.FindControl("lbtnaddress")));

                    Label lblTemp1 = new Label();
                    lblTemp1 = ((Label)(e.Row.FindControl("lblpkid")));

                    lblTemp1.Attributes.Add("onclick", "fill_cost_liability('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtncostcenter"))).Attributes.Add("onclick", "fill_cost_liability('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnDivisionname"))).Attributes.Add("onclick", "fill_cost_liability('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnaddress"))).Attributes.Add("onclick", "fill_cost_liability('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                }
                else if (Request.QueryString["Page"]== "WcCostcenter")
                {


                    LinkButton lbtncost = new LinkButton();
                    LinkButton lbtndivision = new LinkButton();
                    LinkButton lbtnaddress = new LinkButton();
                    LinkButton lbtnTemp = new LinkButton();

                    lbtncost = ((LinkButton)(e.Row.FindControl("lbtncostcenter")));
                    lbtndivision = ((LinkButton)(e.Row.FindControl("lbtnDivisionname")));
                    lbtnaddress = ((LinkButton)(e.Row.FindControl("lbtnaddress")));

                    Label lblTemp1 = new Label();
                    lblTemp1 = ((Label)(e.Row.FindControl("lblpkid")));

                    lblTemp1.Attributes.Add("onclick", "fillPayto1('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtncostcenter"))).Attributes.Add("onclick", "fillPayto1('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnDivisionname"))).Attributes.Add("onclick", "fillPayto1('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnaddress"))).Attributes.Add("onclick", "fillPayto1('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "');");

                    //((LinkButton)(e.Row.FindControl("lbtnSocialSeco"))).Attributes.Add("onclick", "fillPayto('" + lbtnTempFirst.CommandArgument.ToString() + "','" + lbtnTempMiddle.CommandArgument.ToString() + "''" + lbtnTempLast.CommandArgument.ToString() + "');");
                }
                else if (Request.QueryString["Page"] == "PropMain")
                {
                    LinkButton lbtncost = new LinkButton();
                    LinkButton lbtndivision = new LinkButton();
                    LinkButton lbtnaddress = new LinkButton();
                    LinkButton lbtnTemp = new LinkButton();

                    lbtncost = ((LinkButton)(e.Row.FindControl("lbtncostcenter")));
                    lbtndivision = ((LinkButton)(e.Row.FindControl("lbtnDivisionname")));
                    lbtnaddress = ((LinkButton)(e.Row.FindControl("lbtnaddress")));

                    Label lblTemp1 = new Label();
                    lblTemp1 = ((Label)(e.Row.FindControl("lblpkid")));

                    lblTemp1.Attributes.Add("onclick", "fillPropMainCC('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtncostcenter"))).Attributes.Add("onclick", "fillPropMainCC('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnDivisionname"))).Attributes.Add("onclick", "fillPropMainCC('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                    ((LinkButton)(e.Row.FindControl("lbtnaddress"))).Attributes.Add("onclick", "fillPropMainCC('" + lbtncost.CommandArgument.ToString() + "','" + lbtndivision.CommandArgument.ToString() + "','" + lblTemp1.Text + "');");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    protected void gvCostCenterDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCostCenterDetails.PageIndex = e.NewPageIndex;
        gvCostCenterDetails.DataSource = BindCostCenterDetails();
        gvCostCenterDetails.DataBind();
    }
    #endregion
    #region Private Methods
    /// <summary>
    /// Get the All Cost Center Details
    /// </summary>
    private List<RIMS_Base.cCostCenter> BindCostCenterDetails()
    {
        try
        {
            m_objemp = new RIMS_Base.Biz.cCostCenter();
            lstCostDetails = new List<RIMS_Base.cCostCenter>();
            lstCostDetails = null;
            if (txtsearch.Text != string.Empty)
            {
                lstCostDetails = m_objemp.Get_Search_Data(ddlSearch.SelectedValue, txtsearch.Text.Trim());
            }
            else
            {
                lstCostDetails = m_objemp.GetAll();
            }
            return lstCostDetails;
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
