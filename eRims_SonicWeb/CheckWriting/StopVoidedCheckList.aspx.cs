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
public partial class CheckWriting_StopVoidedCheckList : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CCheckDetails m_objCheckDetails;
    List<RIMS_Base.CCheckDetails> lstChekDetails = null;
    string strSortExp = string.Empty;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                trDetails.Visible = false;
                trSearch.Visible = true;
            }
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
            trDetails.Visible = true;
            trSearch.Visible = false;
            /* 1=Post Register Check All
             * 2=Post Register Check Between Given Date Range
             * any other value means Inital Non Printed,Non Reprinted ,Non Stopped,Non Void Check
             */
            gvChkStoppedVoided.PageSize = 10;
            gvChkStoppedVoided.DataSource = BindStoppedVoidedCheck(1, Convert.ToDateTime(txtDtStart.Text), Convert.ToDateTime(txtDtEnd.Text));
            gvChkStoppedVoided.DataBind();
            if (lstChekDetails.Count > 0)
            {
                lblTotalAmount.Text = String.Format("{0:c}", Convert.ToDecimal(lstChekDetails[0].TotalAmount));
            }
            else
            {
                lblTotalAmount.Text = "$0.00";
            }
            ddlPage.DataBind();
            ddlPage.SelectedValue = "10";
            lblPageInfo.Text = "Page 1 of " + gvChkStoppedVoided.PageCount.ToString();
            txtPageNo.Text = "1";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvChkStoppedVoided_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
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

            lstChekDetails = BindStoppedVoidedCheck(1, Convert.ToDateTime(txtDtStart.Text), Convert.ToDateTime(txtDtEnd.Text));
            if (ViewState["SortExp"] != null)
                lstChekDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CCheckDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvChkStoppedVoided.DataSource = lstChekDetails;
            gvChkStoppedVoided.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvChkStoppedVoided_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvChkStoppedVoided.PageIndex = e.NewPageIndex;
            GeneralSorting();
            //gvChkStoppedVoided.DataSource = BindStoppedVoidedCheck(1, Convert.ToDateTime(txtDtStart.Text), Convert.ToDateTime(txtDtEnd.Text));
            //gvChkStoppedVoided.DataBind();
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
                gvChkStoppedVoided.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvChkStoppedVoided.PageCount)
            {
                gvChkStoppedVoided.PageIndex = gvChkStoppedVoided.PageCount;
                txtPageNo.Text = gvChkStoppedVoided.PageCount.ToString();
            }
            else
            {
                gvChkStoppedVoided.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvChkStoppedVoided.PageCount.ToString();
            gvChkStoppedVoided.DataSource = BindStoppedVoidedCheck(1, Convert.ToDateTime(txtDtStart.Text), Convert.ToDateTime(txtDtEnd.Text));
            gvChkStoppedVoided.DataBind();

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
            if (gvChkStoppedVoided.PageIndex <= gvChkStoppedVoided.PageCount)
            {
                gvChkStoppedVoided.PageIndex = gvChkStoppedVoided.PageIndex + 1;
                GeneralSorting();
                //gvChkStoppedVoided.DataSource = BindStoppedVoidedCheck(1, Convert.ToDateTime(txtDtStart.Text), Convert.ToDateTime(txtDtEnd.Text));
                //gvChkStoppedVoided.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvChkStoppedVoided.PageIndex + 1) + " of " + gvChkStoppedVoided.PageCount.ToString();
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
            if (gvChkStoppedVoided.PageIndex <= gvChkStoppedVoided.PageCount)
            {
                gvChkStoppedVoided.PageIndex = gvChkStoppedVoided.PageIndex - 1;
                //gvChkStoppedVoided.DataSource = BindStoppedVoidedCheck(1, Convert.ToDateTime(txtDtStart.Text), Convert.ToDateTime(txtDtEnd.Text));
                //gvChkStoppedVoided.DataBind();
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvChkStoppedVoided.PageIndex + 1) + " of " + gvChkStoppedVoided.PageCount.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvChkStoppedVoided.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvChkStoppedVoided.DataSource = BindStoppedVoidedCheck(1, Convert.ToDateTime(txtDtStart.Text), Convert.ToDateTime(txtDtEnd.Text));
            gvChkStoppedVoided.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvChkStoppedVoided.PageCount.ToString();
            txtPageNo.Text = "1";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            trDetails.Visible = false;
            trSearch.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvChkStoppedVoided_RowCreated(object sender, GridViewRowEventArgs e)
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
        foreach (DataControlField field in gvChkStoppedVoided.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvChkStoppedVoided.Columns.IndexOf(field);
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
    #region Private Method
    /// <summary>
    /// Bind Check Which are Printed
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CCheckDetails> BindStoppedVoidedCheck(System.Int64 m_intType, System.DateTime m_DtStart, System.DateTime m_DtEnd)
    {
        try
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            lstChekDetails = m_objCheckDetails.GetStoppedVoidedCheckForDateLimit(m_intType, m_DtStart, m_DtEnd);
            return lstChekDetails;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GeneralSorting()
    {
        try
        {
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            lstChekDetails = BindStoppedVoidedCheck(1, Convert.ToDateTime(txtDtStart.Text), Convert.ToDateTime(txtDtEnd.Text));
            if (ViewState["SortExp"] != null & ViewState["sortDirection"] != null)
            {
                lstChekDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CCheckDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvChkStoppedVoided.DataSource = lstChekDetails;
            gvChkStoppedVoided.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

}
