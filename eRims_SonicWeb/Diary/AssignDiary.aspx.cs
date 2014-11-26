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
public partial class Diary_AssignDiary : clsBasePage
{
    #region Public Variables
    public RIMS_Base.Biz.Diary m_objClaimList;
    DataSet m_dsClaimList;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    #endregion
    #region Event Handlers
    protected bool SetUserRights()
    {
        try
        {

            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(6, Convert.ToInt32(Session["UserRoleId"].ToString()));
                ViewState["Add"] = lstRightDetails[0].PAdd.ToString();

                ViewState["Edit"] = lstRightDetails[0].PEdit.ToString();
                ViewState["Delete"] = lstRightDetails[0].PDelete.ToString();
                ViewState["View"] = lstRightDetails[0].PView.ToString();
                if (ViewState["Add"].ToString() == "True")
                {
                    btnAssign.Enabled = true;
                }
                else
                {
                    btnAssign.Enabled = false;
                }

                return true;
            }
            else
            {
                Response.Redirect("../Signin.aspx", false);
                return false;
            }

        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        SetUserRights();
        if (!IsPostBack)
        {
            gvClaimToAssign.DataSource = GetClaimListForAssign();
            gvClaimToAssign.DataBind();
        }

    }
    protected void gvClaimToAssign_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        {

            gvClaimToAssign.PageIndex = e.NewPageIndex;
            gvClaimToAssign.DataSource = GetClaimListForAssign();
            gvClaimToAssign.DataBind();
        }
    }
    protected void gvClaimToAssign_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            /*lstBankDetails = new List<RIMS_Base.CBankDetails>();
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

            lstBankDetails = BindBankDetails();
            if (ViewState["SortExp"] != null)
                lstBankDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CBankDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvBankDetails.DataSource = lstBankDetails;
            gvBankDetails.DataBind();*/
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region Private Methods
    private DataSet GetClaimListForAssign()
    {
        try
        {
            m_objClaimList = new RIMS_Base.Biz.Diary();
            m_dsClaimList = new DataSet();
            m_dsClaimList = m_objClaimList.GetClaimToAssign(Convert.ToDecimal(clsSession.UserID));
            return m_dsClaimList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// General Function for Sorting.
    /// </summary>

    #endregion
}
