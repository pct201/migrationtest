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
public partial class Diary_Search : clsBasePage
{
    
    #region Public Variables
    public RIMS_Base.Biz.Diary m_objDiaryDetails;
    List<RIMS_Base.CDiary> lstDiaryDetails = null;
    int nRetVal = -1;
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
                    btnClear.Enabled = true;
                }
                else
                {
                    btnClear.Enabled = false;
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
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //SetUserRights();
        if (!IsPostBack)
        {           
            gvUser.PageSize = 10;
            gvUser.DataSource = GetDiaryData();
            gvUser.DataBind();
            ddlPage.DataBind();
            ddlPage.SelectedValue = "10";
            lblPageInfo.Text = "Page 1 of " + Convert.ToString(gvUser.PageCount);
            txtPageNo.Text = "1";
        }
    }
    /// <summary>
    /// Handle Go Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvUser.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvUser.PageCount)
            {
                gvUser.PageIndex = gvUser.PageCount;
                txtPageNo.Text = Convert.ToString(gvUser.PageCount);
            }
            else
            {
                gvUser.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + Convert.ToString(txtPageNo.Text) + " of " + Convert.ToString(gvUser.PageCount);
            gvUser.DataSource = GetDiaryData();
            gvUser.DataBind();
            lblBankDetailsTotal.Text = "Total Diary:" + Convert.ToString(lstDiaryDetails.Count);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Handle Next Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvUser.PageIndex <= gvUser.PageCount)
            {
                gvUser.PageIndex = gvUser.PageIndex + 1;
                GeneralSorting();              
                lblPageInfo.Text = "Page " + Convert.ToString(gvUser.PageIndex + 1) + " of " + Convert.ToString(gvUser.PageCount);
                lblBankDetailsTotal.Text = "Total Bank Details:" + Convert.ToString(lstDiaryDetails.Count);
            }
        }
        catch (Exception ex)
        {
        }
    }
    /// <summary>
    /// Handle Previous Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvUser.PageIndex <= gvUser.PageCount)
            {
                gvUser.PageIndex = gvUser.PageIndex - 1;              
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvUser.PageIndex + 1) + " of " + Convert.ToString(gvUser.PageCount);
                lblBankDetailsTotal.Text = "Total Bank Details:" + Convert.ToString(lstDiaryDetails.Count);
            }
        }
        catch (Exception ex)
        {
        }
    }
    /// <summary>
    /// Page Selected Index Change Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvUser.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvUser.DataSource = GetDiaryData();
            gvUser.DataBind();
            lblPageInfo.Text = "Page 1 of " + Convert.ToString(gvUser.PageCount);
            txtPageNo.Text = "1";
            lblBankDetailsTotal.Text = "Total Diary:" + Convert.ToString(lstDiaryDetails.Count);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUser_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstDiaryDetails = new List<RIMS_Base.CDiary>();
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

            lstDiaryDetails = GetDiaryData();
            if (ViewState["SortExp"] != null)
                lstDiaryDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CDiary>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvUser.DataSource = lstDiaryDetails;
            gvUser.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Handle Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            m_objDiaryDetails = new RIMS_Base.Biz.Diary();
            lstDiaryDetails = new List<RIMS_Base.CDiary>();
            lstDiaryDetails = m_objDiaryDetails.Search_DiaryData(txtSearch.Text.Trim(), Convert.ToDecimal(clsSession.UserID));
            gvUser.DataSource = lstDiaryDetails;
            gvUser.DataBind();
            lblPageInfo.Text = "Page 1 of " + Convert.ToString(gvUser.PageCount);
            lblBankDetailsTotal.Text = "Total Diary:" + Convert.ToString(lstDiaryDetails.Count);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Handle clear Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            m_objDiaryDetails = new RIMS_Base.Biz.Diary();
            m_objDiaryDetails.Pk_Assign_Id = Convert.ToInt32(Request.Form["chkItem"]);
            nRetVal = m_objDiaryDetails.UpdateClaimAssign(m_objDiaryDetails);
            if (nRetVal > 0)
            {
                gvUser.DataSource = GetDiaryData();
                gvUser.DataBind();
            }
            else
            {
                clsGeneral.ShowAlert("Please select any record.", this);
                return;
            }
            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvUser.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvUser.PageCount)
            {
                gvUser.PageIndex = gvUser.PageCount;
                txtPageNo.Text = Convert.ToString(gvUser.PageCount);
            }
            else
            {
                gvUser.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + Convert.ToString(gvUser.PageCount);
            lblBankDetailsTotal.Text = "Total Diary:" + Convert.ToString(lstDiaryDetails.Count);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region Private Methods
    /// <summary>
    /// Get Diary Data
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CDiary> GetDiaryData()
    {
        try
        {
            m_objDiaryDetails = new RIMS_Base.Biz.Diary();
            lstDiaryDetails = new List<RIMS_Base.CDiary>();
            if (txtSearch.Text != string.Empty)
            {
                lstDiaryDetails = m_objDiaryDetails.Search_DiaryData(txtSearch.Text.Trim(), Convert.ToDecimal(clsSession.UserID));
            }
            else
            {
                lstDiaryDetails = m_objDiaryDetails.Search_DiaryData(string.Empty, Convert.ToDecimal(clsSession.UserID));
            }
            lblBankDetailsTotal.Text = "Total Diary:" + Convert.ToString(lstDiaryDetails.Count);
            return lstDiaryDetails;
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
    /// General Sorting 
    /// </summary>
    private void GeneralSorting()
    {
        try
        {
            lstDiaryDetails = new List<RIMS_Base.CDiary>();
            lstDiaryDetails = GetDiaryData();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
                lstDiaryDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CDiary>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvUser.DataSource = lstDiaryDetails;
            gvUser.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

}
