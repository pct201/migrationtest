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

public partial class AIG_AIGInfo : System.Web.UI.Page
{
    #region Private Variables
    int m_intAIGInfoId = 0;
    int m_intRetval = -1;
    public int m_intPreventAdd = 0;
    public RIMS_Base.Biz.CAIGInfo m_objAIGInfo;
    List<RIMS_Base.CAIGInfo> lstAIGInfo = null;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "AIGInfo";
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            dvSearch.Visible = true;
            
            if (!IsPostBack)
            {
                btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAIGInfo','Delete');");
                mvAIGInfo.ActiveViewIndex = 0;

                gvAIGInfo.PageSize = 10;

                gvAIGInfo.DataSource = BindAIGInfo();
                gvAIGInfo.DataBind();

                ddlPage.DataBind();
                ddlPage.SelectedValue = "10";
                lblPageInfo.Text = "Page 1 of " + gvAIGInfo.PageCount.ToString();
                txtPageNo.Text = "1";
                ViewState["PreventAdd"] = "N";

            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvAIGInfo.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvAIGInfo.PageCount)
            {
                gvAIGInfo.PageIndex = gvAIGInfo.PageCount;
                txtPageNo.Text = gvAIGInfo.PageCount.ToString();
            }
            else
            {
                gvAIGInfo.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvAIGInfo.PageCount.ToString();
            gvAIGInfo.DataSource = BindAIGInfo();
            gvAIGInfo.DataBind();
            lblAIGInfoTotal.Text = "Total AIG Info Details:" + lstAIGInfo.Count.ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvAIGInfo.PageIndex <= gvAIGInfo.PageCount)
            {
                gvAIGInfo.PageIndex = gvAIGInfo.PageIndex + 1;
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvAIGInfo.PageIndex + 1) + " of " + gvAIGInfo.PageCount.ToString();
                lblAIGInfoTotal.Text = "Total AIG Info Details:" + lstAIGInfo.Count.ToString();
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvAIGInfo.PageIndex <= gvAIGInfo.PageCount)
            {
                gvAIGInfo.PageIndex = gvAIGInfo.PageIndex - 1;
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvAIGInfo.PageIndex + 1) + " of " + gvAIGInfo.PageCount.ToString();
                lblAIGInfoTotal.Text = "Total AIG Info Details:" + lstAIGInfo.Count.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAIGInfo = new RIMS_Base.Biz.CAIGInfo();
            m_intRetval = m_objAIGInfo.AIG_Info_Delete(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                mvAIGInfo.ActiveViewIndex = 0;
                gvAIGInfo.DataSource = BindAIGInfo();
                gvAIGInfo.DataBind();
            }
            lblAIGInfoTotal.Text = "Total AIG Info Details:" + lstAIGInfo.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            dvSearch.Visible = false;
            mvAIGInfo.ActiveViewIndex = 1;
            Bindfv(FormViewMode.Insert);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAIGInfo = new RIMS_Base.Biz.CAIGInfo();
            lstAIGInfo = new List<RIMS_Base.CAIGInfo>();
            lstAIGInfo = m_objAIGInfo.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            gvAIGInfo.DataSource = lstAIGInfo;
            gvAIGInfo.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvAIGInfo.PageCount.ToString();
            lblAIGInfoTotal.Text = "Total Provider Details:" + lstAIGInfo.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objAIGInfo = new RIMS_Base.Biz.CAIGInfo();
                if (fvAIGInfo.CurrentMode == FormViewMode.Insert)
                {
                    m_objAIGInfo.PK_AIG_Info_ID = 0;
                }
                else
                {
                    m_objAIGInfo.PK_AIG_Info_ID = Convert.ToInt32(((Label)fvAIGInfo.FindControl("lblAIGInfoId")).Text);
                }
                m_objAIGInfo.AIGRM_Contract_Number = ((TextBox)fvAIGInfo.FindControl("txtACN")).Text.Replace("'", "''");
                if (((TextBox)fvAIGInfo.FindControl("txtAED")).Text !=  string.Empty)
                    m_objAIGInfo.AIGRM_End_Date = Convert.ToDateTime(((TextBox)fvAIGInfo.FindControl("txtAED")).Text);
                if (((TextBox)fvAIGInfo.FindControl("txtASD")).Text != string.Empty)
                m_objAIGInfo.AIGRM_Start_Date = Convert.ToDateTime(((TextBox)fvAIGInfo.FindControl("txtASD")).Text);
                m_objAIGInfo.Updated_By = "1";
                m_objAIGInfo.Update_Date = System.DateTime.Now.Date;
                m_intRetval = m_objAIGInfo.AIGInfo_InsertUpdate(m_objAIGInfo);
                if (m_intRetval >= 0)
                {
                    mvAIGInfo.ActiveViewIndex = 0;
                    gvAIGInfo.DataSource = BindAIGInfo();
                    gvAIGInfo.DataBind();
                }

            }
            else
            {
                ViewState["PreventAdd"] = "N";
                mvAIGInfo.ActiveViewIndex = 0;
                gvAIGInfo.DataSource = BindAIGInfo();
                gvAIGInfo.DataBind();
            }
            dvSearch.Visible = true;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {

            mvAIGInfo.ActiveViewIndex = 0;
            gvAIGInfo.DataSource = BindAIGInfo();
            gvAIGInfo.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void gvAIGInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
                dvSearch.Visible = false;
                mvAIGInfo.ActiveViewIndex = 1;
                m_intAIGInfoId = Convert.ToInt32(e.CommandArgument.ToString());
            }
            if (e.CommandName == "EditItem")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.Edit);
                
            }
            else if (e.CommandName == "View")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.ReadOnly);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvAIGInfo_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstAIGInfo = new List<RIMS_Base.CAIGInfo>();
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

            lstAIGInfo = BindAIGInfo();
            if (ViewState["SortExp"] != null)
                lstAIGInfo.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CAIGInfo>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvAIGInfo.DataSource = lstAIGInfo;
            gvAIGInfo.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void fvAIGInfo_DataBound(object sender, EventArgs e)
    {
       
    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvAIGInfo.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvAIGInfo.DataSource = BindAIGInfo();
            gvAIGInfo.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvAIGInfo.PageCount.ToString();
            txtPageNo.Text = "1";
            lblAIGInfoTotal.Text = "Total AIG Info Details:" + lstAIGInfo.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    
   
    #endregion
    #region Private Methods
    /// <summary>
    /// Get the All Vendor's Details
    /// </summary>
    private List<RIMS_Base.CAIGInfo> BindAIGInfo()
    {
        try
        {
            m_objAIGInfo = new RIMS_Base.Biz.CAIGInfo();
            lstAIGInfo = new List<RIMS_Base.CAIGInfo>();
            lstAIGInfo = null;
            if (txtSearch.Text != string.Empty)
            {
                lstAIGInfo = m_objAIGInfo.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstAIGInfo = m_objAIGInfo.GetAll();
            }
            lblAIGInfoTotal.Text = "Total Provider Details:" + lstAIGInfo.Count.ToString();
            return lstAIGInfo;
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
    /// Bind the Formview Templates.
    /// </summary>
    /// <param name="fvMode"></param>
    private void Bindfv(FormViewMode fvMode)
    {
        try
        {

            if (fvMode == FormViewMode.Insert)
                fvAIGInfo.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
                fvAIGInfo.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvAIGInfo.ChangeMode(FormViewMode.ReadOnly);
            if (fvMode != FormViewMode.Insert)
            {
                
                m_objAIGInfo = new RIMS_Base.Biz.CAIGInfo();
                lstAIGInfo = new List<RIMS_Base.CAIGInfo>();
                lstAIGInfo = m_objAIGInfo.AIGInfo_GetByID(m_intAIGInfoId);
                fvAIGInfo.DataSource = lstAIGInfo;

            }
            fvAIGInfo.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }

    }
    
    private void GeneralSorting()
    {
        try
        {
            lstAIGInfo = new List<RIMS_Base.CAIGInfo>();
            lstAIGInfo = BindAIGInfo();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
                lstAIGInfo.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CAIGInfo>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvAIGInfo.DataSource = lstAIGInfo;
            gvAIGInfo.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    #endregion
}
