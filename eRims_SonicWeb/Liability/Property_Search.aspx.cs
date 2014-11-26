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

public partial class Liability_Property_Search : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CProperty m_objproperty;
    List<RIMS_Base.CProperty> lstpropertyDetails = null;
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
            m_objproperty = new RIMS_Base.Biz.CProperty();
            lstpropertyDetails = new List<RIMS_Base.CProperty>();
            lstpropertyDetails = m_objproperty.Get_Search_Data(ddlSearch.SelectedValue, txtsearch.Text.Trim());
            gvEmployeeDetails.DataSource = lstpropertyDetails;
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
            lstpropertyDetails = new List<RIMS_Base.CProperty>();
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

            lstpropertyDetails = BindEmpDetails();
            if (ViewState["SortExp"] != null)
                lstpropertyDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CProperty>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvEmployeeDetails.DataSource = lstpropertyDetails;
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


                LinkButton lbtnpropertyname = new LinkButton();
                LinkButton lbtnAdd1 = new LinkButton();
                LinkButton lbtnAdd2 = new LinkButton();
                LinkButton lbtnentity = new LinkButton();
                LinkButton lbtncity = new LinkButton();
                LinkButton lbtnstate = new LinkButton();
                LinkButton lbtnzip = new LinkButton();
                LinkButton lbtncounty = new LinkButton();
                LinkButton lbtnowener = new LinkButton();
                LinkButton lbtnfloodzone = new LinkButton();
                LinkButton lbtnemployee = new LinkButton();
                LinkButton lbtnbuilding = new LinkButton();
                LinkButton lbtncontents = new LinkButton();
                LinkButton lbtnAtms = new LinkButton();
                LinkButton lbtnsigns = new LinkButton();
                LinkButton lbtncomputer = new LinkButton();
                LinkButton lbtnlease = new LinkButton();
                LinkButton lbtntotal = new LinkButton();
                LinkButton lbtnTemp = new LinkButton();
                LinkButton lbtnPropertyType = new LinkButton();
                LinkButton lbtnLocation = new LinkButton();




                lbtnpropertyname = ((LinkButton)(e.Row.FindControl("lbtnProperty")));
                lbtnAdd1 = ((LinkButton)(e.Row.FindControl("lbtnadd1")));
                lbtnAdd2 = ((LinkButton)(e.Row.FindControl("lbtnadd2")));
                lbtnentity = ((LinkButton)(e.Row.FindControl("lbtnEntity")));
                lbtncity = ((LinkButton)(e.Row.FindControl("lbtnCity")));
                lbtnstate = ((LinkButton)(e.Row.FindControl("lbtnState")));
                lbtnzip = ((LinkButton)(e.Row.FindControl("lbtnZip")));
                lbtncounty = ((LinkButton)(e.Row.FindControl("lbtnCounty")));
                lbtnowener = ((LinkButton)(e.Row.FindControl("lbtnOwnership")));
                lbtnfloodzone = ((LinkButton)(e.Row.FindControl("lbtnZone")));
                lbtnemployee = ((LinkButton)(e.Row.FindControl("lbtnEmployees")));
                lbtnbuilding = ((LinkButton)(e.Row.FindControl("lbtnBuilding")));
                lbtncontents = ((LinkButton)(e.Row.FindControl("lbtnContents")));
                lbtnAtms = ((LinkButton)(e.Row.FindControl("lbtnATMs")));
                lbtnAtms = ((LinkButton)(e.Row.FindControl("lbtnSigns")));
                lbtncomputer = ((LinkButton)(e.Row.FindControl("lbtnComputers")));
                lbtnlease = ((LinkButton)(e.Row.FindControl("lbtnImprovements")));
                lbtntotal = ((LinkButton)(e.Row.FindControl("lbtnTotal")));
                lbtnTemp = ((LinkButton)(e.Row.FindControl("lblpkid")));

                lbtnPropertyType = ((LinkButton)(e.Row.FindControl("lbtnStationary")));
                lbtnLocation = ((LinkButton)(e.Row.FindControl("lbtnLocation")));

                ((LinkButton)(e.Row.FindControl("lbtnLocation"))).Attributes.Add("onclick", "fillPayto('"
                       + lbtnpropertyname.CommandArgument.ToString()
                       + "','" + lbtnAdd1.CommandArgument.ToString()
                       + "','" + lbtnAdd2.CommandArgument.ToString()
                       + "','" + lbtnentity.CommandArgument.ToString()
                       + "','" + lbtncity.CommandArgument.ToString()
                       + "','" + lbtnstate.CommandArgument.ToString()
                       + "','" + lbtnzip.CommandArgument.ToString()
                       + "','" + lbtncounty.CommandArgument.ToString()
                       + "','" + lbtnowener.CommandArgument.ToString()
                       + "','" + lbtnfloodzone.CommandArgument.ToString()
                       + "','" + lbtnemployee.CommandArgument.ToString()
                       + "','" + lbtnbuilding.CommandArgument.ToString()
                       + "','" + lbtncontents.CommandArgument.ToString()
                       + "','" + lbtnAtms.CommandArgument.ToString()
                       + "','" + lbtnsigns.CommandArgument.ToString()
                       + "','" + lbtncomputer.CommandArgument.ToString()
                       + "','" + lbtnlease.CommandArgument.ToString()
                       + "','" + lbtntotal.CommandArgument.ToString()
                       + "','" + lbtnTemp.CommandArgument.ToString()
                       + "');");

                ((LinkButton)(e.Row.FindControl("lbtnStationary"))).Attributes.Add("onclick", "fillPayto('"
                       + lbtnpropertyname.CommandArgument.ToString()
                       + "','" + lbtnAdd1.CommandArgument.ToString()
                       + "','" + lbtnAdd2.CommandArgument.ToString()
                       + "','" + lbtnentity.CommandArgument.ToString()
                       + "','" + lbtncity.CommandArgument.ToString()
                       + "','" + lbtnstate.CommandArgument.ToString()
                       + "','" + lbtnzip.CommandArgument.ToString()
                       + "','" + lbtncounty.CommandArgument.ToString()
                       + "','" + lbtnowener.CommandArgument.ToString()
                       + "','" + lbtnfloodzone.CommandArgument.ToString()
                       + "','" + lbtnemployee.CommandArgument.ToString()
                       + "','" + lbtnbuilding.CommandArgument.ToString()
                       + "','" + lbtncontents.CommandArgument.ToString()
                       + "','" + lbtnAtms.CommandArgument.ToString()
                       + "','" + lbtnsigns.CommandArgument.ToString()
                       + "','" + lbtncomputer.CommandArgument.ToString()
                       + "','" + lbtnlease.CommandArgument.ToString()
                       + "','" + lbtntotal.CommandArgument.ToString()
                       + "','" + lbtnTemp.CommandArgument.ToString()
                       + "');");
                 // Label lblTemp = new Label();
                 //  lblTemp = ((Label)(e.Row.FindControl("lblpkid")));
                // Session["empid"] = lbtnTempEmpid.CommandArgument.ToString();
                ((LinkButton)(e.Row.FindControl("lblpkid"))).Attributes.Add("onclick", "fillPayto('"
                        + lbtnpropertyname.CommandArgument.ToString()
                        + "','" + lbtnAdd1.CommandArgument.ToString()
                        + "','" + lbtnAdd2.CommandArgument.ToString()
                        + "','" + lbtnentity.CommandArgument.ToString()
                        + "','" + lbtncity.CommandArgument.ToString()
                        + "','" + lbtnstate.CommandArgument.ToString()
                        + "','" + lbtnzip.CommandArgument.ToString()
                        + "','" + lbtncounty.CommandArgument.ToString()
                        + "','" + lbtnowener.CommandArgument.ToString()
                        + "','" + lbtnfloodzone.CommandArgument.ToString()
                        + "','" + lbtnemployee.CommandArgument.ToString()
                        + "','" + lbtnbuilding.CommandArgument.ToString()
                        + "','" + lbtncontents.CommandArgument.ToString()
                        + "','" + lbtnAtms.CommandArgument.ToString()
                        + "','" + lbtnsigns.CommandArgument.ToString()
                        + "','" + lbtncomputer.CommandArgument.ToString()
                        + "','" + lbtnlease.CommandArgument.ToString()
                        + "','" + lbtntotal.CommandArgument.ToString()
                        + "','" + lbtnTemp.CommandArgument.ToString()
                        + "');");

                ((LinkButton)(e.Row.FindControl("lbtnProperty"))).Attributes.Add("onclick", "fillPayto('"
                    + lbtnpropertyname.CommandArgument.ToString()
                    + "','" + lbtnAdd1.CommandArgument.ToString()
                    + "','" + lbtnAdd2.CommandArgument.ToString()
                    + "','" + lbtnentity.CommandArgument.ToString()
                    + "','" + lbtncity.CommandArgument.ToString()
                    + "','" + lbtnstate.CommandArgument.ToString()
                    + "','" + lbtnzip.CommandArgument.ToString()
                    + "','" + lbtncounty.CommandArgument.ToString()
                    + "','" + lbtnowener.CommandArgument.ToString()
                    + "','" + lbtnfloodzone.CommandArgument.ToString()
                    + "','" + lbtnemployee.CommandArgument.ToString()
                    + "','" + lbtnbuilding.CommandArgument.ToString()
                    + "','" + lbtncontents.CommandArgument.ToString()
                    + "','" + lbtnAtms.CommandArgument.ToString()
                    + "','" + lbtnsigns.CommandArgument.ToString()
                    + "','" + lbtncomputer.CommandArgument.ToString()
                    + "','" + lbtnlease.CommandArgument.ToString()
                    + "','" + lbtntotal.CommandArgument.ToString()
                    + "','" + lbtnTemp.CommandArgument.ToString()
                    + "');");
                ((LinkButton)(e.Row.FindControl("lbtnadd1"))).Attributes.Add("onclick", "fillPayto('"
                      + lbtnpropertyname.CommandArgument.ToString()
                    + "','" + lbtnAdd1.CommandArgument.ToString()
                    + "','" + lbtnAdd2.CommandArgument.ToString()
                    + "','" + lbtnentity.CommandArgument.ToString()
                    + "','" + lbtncity.CommandArgument.ToString()
                    + "','" + lbtnstate.CommandArgument.ToString()
                    + "','" + lbtnzip.CommandArgument.ToString()
                    + "','" + lbtncounty.CommandArgument.ToString()
                    + "','" + lbtnowener.CommandArgument.ToString()
                    + "','" + lbtnfloodzone.CommandArgument.ToString()
                    + "','" + lbtnemployee.CommandArgument.ToString()
                    + "','" + lbtnbuilding.CommandArgument.ToString()
                    + "','" + lbtncontents.CommandArgument.ToString()
                    + "','" + lbtnAtms.CommandArgument.ToString()
                    + "','" + lbtnsigns.CommandArgument.ToString()
                    + "','" + lbtncomputer.CommandArgument.ToString()
                    + "','" + lbtnlease.CommandArgument.ToString()
                    + "','" + lbtntotal.CommandArgument.ToString()
                    + "','" + lbtnTemp.CommandArgument.ToString()
                    + "');");
                ((LinkButton)(e.Row.FindControl("lbtnadd2"))).Attributes.Add("onclick", "fillPayto('"
                       + lbtnpropertyname.CommandArgument.ToString()
                    + "','" + lbtnAdd1.CommandArgument.ToString()
                    + "','" + lbtnAdd2.CommandArgument.ToString()
                    + "','" + lbtnentity.CommandArgument.ToString()
                    + "','" + lbtncity.CommandArgument.ToString()
                    + "','" + lbtnstate.CommandArgument.ToString()
                    + "','" + lbtnzip.CommandArgument.ToString()
                    + "','" + lbtncounty.CommandArgument.ToString()
                    + "','" + lbtnowener.CommandArgument.ToString()
                    + "','" + lbtnfloodzone.CommandArgument.ToString()
                    + "','" + lbtnemployee.CommandArgument.ToString()
                    + "','" + lbtnbuilding.CommandArgument.ToString()
                    + "','" + lbtncontents.CommandArgument.ToString()
                    + "','" + lbtnAtms.CommandArgument.ToString()
                    + "','" + lbtnsigns.CommandArgument.ToString()
                    + "','" + lbtncomputer.CommandArgument.ToString()
                    + "','" + lbtnlease.CommandArgument.ToString()
                    + "','" + lbtntotal.CommandArgument.ToString()
                    + "','" + lbtnTemp.CommandArgument.ToString()
                    + "');");
                ((LinkButton)(e.Row.FindControl("lbtnEntity"))).Attributes.Add("onclick", "fillPayto('"
                            + lbtnpropertyname.CommandArgument.ToString()
                    + "','" + lbtnAdd1.CommandArgument.ToString()
                    + "','" + lbtnAdd2.CommandArgument.ToString()
                    + "','" + lbtnentity.CommandArgument.ToString()
                    + "','" + lbtncity.CommandArgument.ToString()
                    + "','" + lbtnstate.CommandArgument.ToString()
                    + "','" + lbtnzip.CommandArgument.ToString()
                    + "','" + lbtncounty.CommandArgument.ToString()
                    + "','" + lbtnowener.CommandArgument.ToString()
                    + "','" + lbtnfloodzone.CommandArgument.ToString()
                    + "','" + lbtnemployee.CommandArgument.ToString()
                    + "','" + lbtnbuilding.CommandArgument.ToString()
                    + "','" + lbtncontents.CommandArgument.ToString()
                    + "','" + lbtnAtms.CommandArgument.ToString()
                    + "','" + lbtnsigns.CommandArgument.ToString()
                    + "','" + lbtncomputer.CommandArgument.ToString()
                    + "','" + lbtnlease.CommandArgument.ToString()
                    + "','" + lbtntotal.CommandArgument.ToString()
                    + "','" + lbtnTemp.CommandArgument.ToString()
                    + "');");

                ((LinkButton)(e.Row.FindControl("lbtnCity"))).Attributes.Add("onclick", "fillPayto('"
                           + lbtnpropertyname.CommandArgument.ToString()
                   + "','" + lbtnAdd1.CommandArgument.ToString()
                   + "','" + lbtnAdd2.CommandArgument.ToString()
                   + "','" + lbtnentity.CommandArgument.ToString()
                   + "','" + lbtncity.CommandArgument.ToString()
                   + "','" + lbtnstate.CommandArgument.ToString()
                   + "','" + lbtnzip.CommandArgument.ToString()
                   + "','" + lbtncounty.CommandArgument.ToString()
                   + "','" + lbtnowener.CommandArgument.ToString()
                   + "','" + lbtnfloodzone.CommandArgument.ToString()
                   + "','" + lbtnemployee.CommandArgument.ToString()
                   + "','" + lbtnbuilding.CommandArgument.ToString()
                   + "','" + lbtncontents.CommandArgument.ToString()
                   + "','" + lbtnAtms.CommandArgument.ToString()
                   + "','" + lbtnsigns.CommandArgument.ToString()
                   + "','" + lbtncomputer.CommandArgument.ToString()
                   + "','" + lbtnlease.CommandArgument.ToString()
                   + "','" + lbtntotal.CommandArgument.ToString()
                   + "','" + lbtnTemp.CommandArgument.ToString()
                   + "');");

                ((LinkButton)(e.Row.FindControl("lbtnState"))).Attributes.Add("onclick", "fillPayto('"
                           + lbtnpropertyname.CommandArgument.ToString()
                   + "','" + lbtnAdd1.CommandArgument.ToString()
                   + "','" + lbtnAdd2.CommandArgument.ToString()
                   + "','" + lbtnentity.CommandArgument.ToString()
                   + "','" + lbtncity.CommandArgument.ToString()
                   + "','" + lbtnstate.CommandArgument.ToString()
                   + "','" + lbtnzip.CommandArgument.ToString()
                   + "','" + lbtncounty.CommandArgument.ToString()
                   + "','" + lbtnowener.CommandArgument.ToString()
                   + "','" + lbtnfloodzone.CommandArgument.ToString()
                   + "','" + lbtnemployee.CommandArgument.ToString()
                   + "','" + lbtnbuilding.CommandArgument.ToString()
                   + "','" + lbtncontents.CommandArgument.ToString()
                   + "','" + lbtnAtms.CommandArgument.ToString()
                   + "','" + lbtnsigns.CommandArgument.ToString()
                   + "','" + lbtncomputer.CommandArgument.ToString()
                   + "','" + lbtnlease.CommandArgument.ToString()
                   + "','" + lbtntotal.CommandArgument.ToString()
                   + "','" + lbtnTemp.CommandArgument.ToString()
                   + "');");

                ((LinkButton)(e.Row.FindControl("lbtnZip"))).Attributes.Add("onclick", "fillPayto('"
                           + lbtnpropertyname.CommandArgument.ToString()
                   + "','" + lbtnAdd1.CommandArgument.ToString()
                   + "','" + lbtnAdd2.CommandArgument.ToString()
                   + "','" + lbtnentity.CommandArgument.ToString()
                   + "','" + lbtncity.CommandArgument.ToString()
                   + "','" + lbtnstate.CommandArgument.ToString()
                   + "','" + lbtnzip.CommandArgument.ToString()
                   + "','" + lbtncounty.CommandArgument.ToString()
                   + "','" + lbtnowener.CommandArgument.ToString()
                   + "','" + lbtnfloodzone.CommandArgument.ToString()
                   + "','" + lbtnemployee.CommandArgument.ToString()
                   + "','" + lbtnbuilding.CommandArgument.ToString()
                   + "','" + lbtncontents.CommandArgument.ToString()
                   + "','" + lbtnAtms.CommandArgument.ToString()
                   + "','" + lbtnsigns.CommandArgument.ToString()
                   + "','" + lbtncomputer.CommandArgument.ToString()
                   + "','" + lbtnlease.CommandArgument.ToString()
                   + "','" + lbtntotal.CommandArgument.ToString()
                   + "','" + lbtnTemp.CommandArgument.ToString()
                   + "');");

                ((LinkButton)(e.Row.FindControl("lbtnCounty"))).Attributes.Add("onclick", "fillPayto('"
                           + lbtnpropertyname.CommandArgument.ToString()
                   + "','" + lbtnAdd1.CommandArgument.ToString()
                   + "','" + lbtnAdd2.CommandArgument.ToString()
                   + "','" + lbtnentity.CommandArgument.ToString()
                   + "','" + lbtncity.CommandArgument.ToString()
                   + "','" + lbtnstate.CommandArgument.ToString()
                   + "','" + lbtnzip.CommandArgument.ToString()
                   + "','" + lbtncounty.CommandArgument.ToString()
                   + "','" + lbtnowener.CommandArgument.ToString()
                   + "','" + lbtnfloodzone.CommandArgument.ToString()
                   + "','" + lbtnemployee.CommandArgument.ToString()
                   + "','" + lbtnbuilding.CommandArgument.ToString()
                   + "','" + lbtncontents.CommandArgument.ToString()
                   + "','" + lbtnAtms.CommandArgument.ToString()
                   + "','" + lbtnsigns.CommandArgument.ToString()
                   + "','" + lbtncomputer.CommandArgument.ToString()
                   + "','" + lbtnlease.CommandArgument.ToString()
                   + "','" + lbtntotal.CommandArgument.ToString()
                   + "','" + lbtnTemp.CommandArgument.ToString()
                   + "');");

                ((LinkButton)(e.Row.FindControl("lbtnOwnership"))).Attributes.Add("onclick", "fillPayto('"
                           + lbtnpropertyname.CommandArgument.ToString()
                   + "','" + lbtnAdd1.CommandArgument.ToString()
                   + "','" + lbtnAdd2.CommandArgument.ToString()
                   + "','" + lbtnentity.CommandArgument.ToString()
                   + "','" + lbtncity.CommandArgument.ToString()
                   + "','" + lbtnstate.CommandArgument.ToString()
                   + "','" + lbtnzip.CommandArgument.ToString()
                   + "','" + lbtncounty.CommandArgument.ToString()
                   + "','" + lbtnowener.CommandArgument.ToString()
                   + "','" + lbtnfloodzone.CommandArgument.ToString()
                   + "','" + lbtnemployee.CommandArgument.ToString()
                   + "','" + lbtnbuilding.CommandArgument.ToString()
                   + "','" + lbtncontents.CommandArgument.ToString()
                   + "','" + lbtnAtms.CommandArgument.ToString()
                   + "','" + lbtnsigns.CommandArgument.ToString()
                   + "','" + lbtncomputer.CommandArgument.ToString()
                   + "','" + lbtnlease.CommandArgument.ToString()
                   + "','" + lbtntotal.CommandArgument.ToString()
                   + "','" + lbtnTemp.CommandArgument.ToString()
                   + "');");

                ((LinkButton)(e.Row.FindControl("lbtnZone"))).Attributes.Add("onclick", "fillPayto('"
                           + lbtnpropertyname.CommandArgument.ToString()
                   + "','" + lbtnAdd1.CommandArgument.ToString()
                   + "','" + lbtnAdd2.CommandArgument.ToString()
                   + "','" + lbtnentity.CommandArgument.ToString()
                   + "','" + lbtncity.CommandArgument.ToString()
                   + "','" + lbtnstate.CommandArgument.ToString()
                   + "','" + lbtnzip.CommandArgument.ToString()
                   + "','" + lbtncounty.CommandArgument.ToString()
                   + "','" + lbtnowener.CommandArgument.ToString()
                   + "','" + lbtnfloodzone.CommandArgument.ToString()
                   + "','" + lbtnemployee.CommandArgument.ToString()
                   + "','" + lbtnbuilding.CommandArgument.ToString()
                   + "','" + lbtncontents.CommandArgument.ToString()
                   + "','" + lbtnAtms.CommandArgument.ToString()
                   + "','" + lbtnsigns.CommandArgument.ToString()
                   + "','" + lbtncomputer.CommandArgument.ToString()
                   + "','" + lbtnlease.CommandArgument.ToString()
                   + "','" + lbtntotal.CommandArgument.ToString()
                   + "','" + lbtnTemp.CommandArgument.ToString()
                   + "');");

                ((LinkButton)(e.Row.FindControl("lbtnEmployees"))).Attributes.Add("onclick", "fillPayto('"
                           + lbtnpropertyname.CommandArgument.ToString()
                   + "','" + lbtnAdd1.CommandArgument.ToString()
                   + "','" + lbtnAdd2.CommandArgument.ToString()
                   + "','" + lbtnentity.CommandArgument.ToString()
                   + "','" + lbtncity.CommandArgument.ToString()
                   + "','" + lbtnstate.CommandArgument.ToString()
                   + "','" + lbtnzip.CommandArgument.ToString()
                   + "','" + lbtncounty.CommandArgument.ToString()
                   + "','" + lbtnowener.CommandArgument.ToString()
                   + "','" + lbtnfloodzone.CommandArgument.ToString()
                   + "','" + lbtnemployee.CommandArgument.ToString()
                   + "','" + lbtnbuilding.CommandArgument.ToString()
                   + "','" + lbtncontents.CommandArgument.ToString()
                   + "','" + lbtnAtms.CommandArgument.ToString()
                   + "','" + lbtnsigns.CommandArgument.ToString()
                   + "','" + lbtncomputer.CommandArgument.ToString()
                   + "','" + lbtnlease.CommandArgument.ToString()
                   + "','" + lbtntotal.CommandArgument.ToString()
                   + "','" + lbtnTemp.CommandArgument.ToString()
                   + "');");


                ((LinkButton)(e.Row.FindControl("lbtnBuilding"))).Attributes.Add("onclick", "fillPayto('"
                         + lbtnpropertyname.CommandArgument.ToString()
                 + "','" + lbtnAdd1.CommandArgument.ToString()
                 + "','" + lbtnAdd2.CommandArgument.ToString()
                 + "','" + lbtnentity.CommandArgument.ToString()
                 + "','" + lbtncity.CommandArgument.ToString()
                 + "','" + lbtnstate.CommandArgument.ToString()
                 + "','" + lbtnzip.CommandArgument.ToString()
                 + "','" + lbtncounty.CommandArgument.ToString()
                 + "','" + lbtnowener.CommandArgument.ToString()
                 + "','" + lbtnfloodzone.CommandArgument.ToString()
                 + "','" + lbtnemployee.CommandArgument.ToString()
                 + "','" + lbtnbuilding.CommandArgument.ToString()
                 + "','" + lbtncontents.CommandArgument.ToString()
                 + "','" + lbtnAtms.CommandArgument.ToString()
                 + "','" + lbtnsigns.CommandArgument.ToString()
                 + "','" + lbtncomputer.CommandArgument.ToString()
                 + "','" + lbtnlease.CommandArgument.ToString()
                 + "','" + lbtntotal.CommandArgument.ToString()
                 + "','" + lbtnTemp.CommandArgument.ToString()
                 + "');");


                ((LinkButton)(e.Row.FindControl("lbtnContents"))).Attributes.Add("onclick", "fillPayto('"
                         + lbtnpropertyname.CommandArgument.ToString()
                 + "','" + lbtnAdd1.CommandArgument.ToString()
                 + "','" + lbtnAdd2.CommandArgument.ToString()
                 + "','" + lbtnentity.CommandArgument.ToString()
                 + "','" + lbtncity.CommandArgument.ToString()
                 + "','" + lbtnstate.CommandArgument.ToString()
                 + "','" + lbtnzip.CommandArgument.ToString()
                 + "','" + lbtncounty.CommandArgument.ToString()
                 + "','" + lbtnowener.CommandArgument.ToString()
                 + "','" + lbtnfloodzone.CommandArgument.ToString()
                 + "','" + lbtnemployee.CommandArgument.ToString()
                 + "','" + lbtnbuilding.CommandArgument.ToString()
                 + "','" + lbtncontents.CommandArgument.ToString()
                 + "','" + lbtnAtms.CommandArgument.ToString()
                 + "','" + lbtnsigns.CommandArgument.ToString()
                 + "','" + lbtncomputer.CommandArgument.ToString()
                 + "','" + lbtnlease.CommandArgument.ToString()
                 + "','" + lbtntotal.CommandArgument.ToString()
                 + "','" + lbtnTemp.CommandArgument.ToString()
                 + "');");


                ((LinkButton)(e.Row.FindControl("lbtnATMs"))).Attributes.Add("onclick", "fillPayto('"
                         + lbtnpropertyname.CommandArgument.ToString()
                 + "','" + lbtnAdd1.CommandArgument.ToString()
                 + "','" + lbtnAdd2.CommandArgument.ToString()
                 + "','" + lbtnentity.CommandArgument.ToString()
                 + "','" + lbtncity.CommandArgument.ToString()
                 + "','" + lbtnstate.CommandArgument.ToString()
                 + "','" + lbtnzip.CommandArgument.ToString()
                 + "','" + lbtncounty.CommandArgument.ToString()
                 + "','" + lbtnowener.CommandArgument.ToString()
                 + "','" + lbtnfloodzone.CommandArgument.ToString()
                 + "','" + lbtnemployee.CommandArgument.ToString()
                 + "','" + lbtnbuilding.CommandArgument.ToString()
                 + "','" + lbtncontents.CommandArgument.ToString()
                 + "','" + lbtnAtms.CommandArgument.ToString()
                 + "','" + lbtnsigns.CommandArgument.ToString()
                 + "','" + lbtncomputer.CommandArgument.ToString()
                 + "','" + lbtnlease.CommandArgument.ToString()
                 + "','" + lbtntotal.CommandArgument.ToString()
                 + "','" + lbtnTemp.CommandArgument.ToString()
                 + "');");


                ((LinkButton)(e.Row.FindControl("lbtnComputers"))).Attributes.Add("onclick", "fillPayto('"
                        + lbtnpropertyname.CommandArgument.ToString()
                + "','" + lbtnAdd1.CommandArgument.ToString()
                + "','" + lbtnAdd2.CommandArgument.ToString()
                + "','" + lbtnentity.CommandArgument.ToString()
                + "','" + lbtncity.CommandArgument.ToString()
                + "','" + lbtnstate.CommandArgument.ToString()
                + "','" + lbtnzip.CommandArgument.ToString()
                + "','" + lbtncounty.CommandArgument.ToString()
                + "','" + lbtnowener.CommandArgument.ToString()
                + "','" + lbtnfloodzone.CommandArgument.ToString()
                + "','" + lbtnemployee.CommandArgument.ToString()
                + "','" + lbtnbuilding.CommandArgument.ToString()
                + "','" + lbtncontents.CommandArgument.ToString()
                + "','" + lbtnAtms.CommandArgument.ToString()
                + "','" + lbtnsigns.CommandArgument.ToString()
                + "','" + lbtncomputer.CommandArgument.ToString()
                + "','" + lbtnlease.CommandArgument.ToString()
                + "','" + lbtntotal.CommandArgument.ToString()
                + "','" + lbtnTemp.CommandArgument.ToString()
                + "');");

                ((LinkButton)(e.Row.FindControl("lbtnImprovements"))).Attributes.Add("onclick", "fillPayto('"
                        + lbtnpropertyname.CommandArgument.ToString()
                + "','" + lbtnAdd1.CommandArgument.ToString()
                + "','" + lbtnAdd2.CommandArgument.ToString()
                + "','" + lbtnentity.CommandArgument.ToString()
                + "','" + lbtncity.CommandArgument.ToString()
                + "','" + lbtnstate.CommandArgument.ToString()
                + "','" + lbtnzip.CommandArgument.ToString()
                + "','" + lbtncounty.CommandArgument.ToString()
                + "','" + lbtnowener.CommandArgument.ToString()
                + "','" + lbtnfloodzone.CommandArgument.ToString()
                + "','" + lbtnemployee.CommandArgument.ToString()
                + "','" + lbtnbuilding.CommandArgument.ToString()
                + "','" + lbtncontents.CommandArgument.ToString()
                + "','" + lbtnAtms.CommandArgument.ToString()
                + "','" + lbtnsigns.CommandArgument.ToString()
                + "','" + lbtncomputer.CommandArgument.ToString()
                + "','" + lbtnlease.CommandArgument.ToString()
                + "','" + lbtntotal.CommandArgument.ToString()
                + "','" + lbtnTemp.CommandArgument.ToString()
                + "');");

                ((LinkButton)(e.Row.FindControl("lbtnTotal"))).Attributes.Add("onclick", "fillPayto('"
                        + lbtnpropertyname.CommandArgument.ToString()
                + "','" + lbtnAdd1.CommandArgument.ToString()
                + "','" + lbtnAdd2.CommandArgument.ToString()
                + "','" + lbtnentity.CommandArgument.ToString()
                + "','" + lbtncity.CommandArgument.ToString()
                + "','" + lbtnstate.CommandArgument.ToString()
                + "','" + lbtnzip.CommandArgument.ToString()
                + "','" + lbtncounty.CommandArgument.ToString()
                + "','" + lbtnowener.CommandArgument.ToString()
                + "','" + lbtnfloodzone.CommandArgument.ToString()
                + "','" + lbtnemployee.CommandArgument.ToString()
                + "','" + lbtnbuilding.CommandArgument.ToString()
                + "','" + lbtncontents.CommandArgument.ToString()
                + "','" + lbtnAtms.CommandArgument.ToString()
                + "','" + lbtnsigns.CommandArgument.ToString()
                + "','" + lbtncomputer.CommandArgument.ToString()
                + "','" + lbtnlease.CommandArgument.ToString()
                + "','" + lbtntotal.CommandArgument.ToString()
                + "','" + lbtnTemp.CommandArgument.ToString()
                + "');");

                ((LinkButton)(e.Row.FindControl("lblpkid"))).Attributes.Add("onclick", "fillPayto('"
                       + lbtnpropertyname.CommandArgument.ToString()
               + "','" + lbtnAdd1.CommandArgument.ToString()
               + "','" + lbtnAdd2.CommandArgument.ToString()
               + "','" + lbtnentity.CommandArgument.ToString()
               + "','" + lbtncity.CommandArgument.ToString()
               + "','" + lbtnstate.CommandArgument.ToString()
               + "','" + lbtnzip.CommandArgument.ToString()
               + "','" + lbtncounty.CommandArgument.ToString()
               + "','" + lbtnowener.CommandArgument.ToString()
               + "','" + lbtnfloodzone.CommandArgument.ToString()
               + "','" + lbtnemployee.CommandArgument.ToString()
               + "','" + lbtnbuilding.CommandArgument.ToString()
               + "','" + lbtncontents.CommandArgument.ToString()
               + "','" + lbtnAtms.CommandArgument.ToString()
               + "','" + lbtnsigns.CommandArgument.ToString()
               + "','" + lbtncomputer.CommandArgument.ToString()
               + "','" + lbtnlease.CommandArgument.ToString()
               + "','" + lbtntotal.CommandArgument.ToString()
               + "','" + lbtnTemp.CommandArgument.ToString()
               + "');");

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
    private List<RIMS_Base.CProperty> BindEmpDetails()
    {
        try
        {
            m_objproperty = new RIMS_Base.Biz.CProperty();
            lstpropertyDetails = new List<RIMS_Base.CProperty>();
            lstpropertyDetails = null;
            if (txtsearch.Text != string.Empty)
            {
                lstpropertyDetails = m_objproperty.Get_Search_Data(ddlSearch.SelectedValue, txtsearch.Text.Trim());
            }
            else
            {
                lstpropertyDetails = m_objproperty.GetAll();
            }
            return lstpropertyDetails;
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
