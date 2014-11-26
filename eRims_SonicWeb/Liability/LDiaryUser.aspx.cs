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
public partial class Liability_LDiaryUser : System.Web.UI.Page
{
    #region Private Variables

    public RIMS_Base.Biz.CSecurity biz_ObjSecurity;
    List<RIMS_Base.CSecurity> lstSecurity = null;
    protected string val;
    public RIMS_Base.Biz.Diary m_objUserList;
    DataSet m_dsUserList;
    RIMS_Base.Biz.CLiabilityClaim objLiability;
    List<RIMS_Base.CLiabilityClaim> lstLiability;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mode"].ToString() != String.Empty && Session["mode"] != null)
            val = Session["mode"].ToString();

        if (!IsPostBack)
        {
            ViewState["CostCenter"] = null;            

            if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
            {
                objLiability = new RIMS_Base.Biz.CLiabilityClaim();
                lstLiability = new List<RIMS_Base.CLiabilityClaim>();
                try
                {
                    lstLiability = objLiability.Getility_ClaimByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
                    //string Claim_No = lstLiability[0].Claim_Number;
                    ViewState["CostCenter"] = lstLiability[0].FK_Cost_Center;
                    BindUserData(lstLiability[0].FK_Cost_Center);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objLiability = null;
                    lstLiability = null;
                }
            }

        }

    }
    public void BindUserData(string CostCenter)
    {
        try
        {
            //biz_ObjSecurity = new RIMS_Base.Biz.CSecurity();
            //lstSecurity = new List<RIMS_Base.CSecurity>();
            //lstSecurity=biz_ObjSecurity.GetAll();
            //dgUsers.DataSource=lstSecurity;
            //dgUsers.DataBind();

            m_objUserList = new RIMS_Base.Biz.Diary();
            m_dsUserList = new DataSet();
            m_dsUserList = m_objUserList.GetAssignToUser(CostCenter);
            dgUsers.DataSource = m_dsUserList;
            dgUsers.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    // -- Bind the Column of the DataGrid
    protected void dgUsers_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbtnTemp = new LinkButton();
            lbtnTemp = ((LinkButton)(e.Item.FindControl("lbtnUserName")));
            string userName;
            userName = lbtnTemp.CommandArgument.ToString();
            lbtnTemp.Attributes.Add("onclick", "test('" + userName + "');");

            lbtnTemp = ((LinkButton)(e.Item.FindControl("lbtnFirstName")));
            userName = lbtnTemp.CommandArgument.ToString();
            lbtnTemp.Attributes.Add("onclick", "test('" + userName + "');");

            lbtnTemp = ((LinkButton)(e.Item.FindControl("lbtnLastName")));
            userName = lbtnTemp.CommandArgument.ToString();
            lbtnTemp.Attributes.Add("onclick", "test('" + userName + "');");

            lbtnTemp = ((LinkButton)(e.Item.FindControl("lbtnCostCenter")));
            userName = lbtnTemp.CommandArgument.ToString();
            lbtnTemp.Attributes.Add("onclick", "test('" + userName + "');");

            lbtnTemp = ((LinkButton)(e.Item.FindControl("lbtnDivision")));
            userName = lbtnTemp.CommandArgument.ToString();
            lbtnTemp.Attributes.Add("onclick", "test('" + userName + "');");

        }
    }

    protected void dgUsers_SortCommand(object sender, DataGridSortCommandEventArgs e)
    {
        m_objUserList = new RIMS_Base.Biz.Diary();
        m_dsUserList = new DataSet();

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
        DataView dvView = new DataView();
        if (ViewState["CostCenter"] != null)
        {
            m_dsUserList = m_objUserList.GetAssignToUser(ViewState["CostCenter"].ToString());

            dvView = m_dsUserList.Tables[0].DefaultView;
            if (ViewState["SortExp"] != null)
            {
                if (ViewState["sortDirection"].ToString() == "Descending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Desc";
                if (ViewState["sortDirection"].ToString() == "Ascending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Asc";
            }

        }
        // m_dsUserList.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CDiary>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        dgUsers.DataSource = dvView;
        dgUsers.DataBind();


    }

}
