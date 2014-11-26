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
public partial class CheckWriting_CheckEditDelete : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CCheckDetails m_objCheckDetails;
    List<RIMS_Base.CCheckDetails> lstChekDetails = null;
    public RIMS_Base.Biz.CGeneral m_objPayCode;
    List<RIMS_Base.CGeneral> lstPayCode = null;
    public RIMS_Base.Biz.CVendor m_objVendorType;
    List<RIMS_Base.CVendor> lstVendorType = null;
    public RIMS_Base.Biz.CCheckWriting m_objCheckWriting;
    ListItem m_lstCommon;
    public int m_intRetval = -1;
    DataSet m_dsSearch;
    DataSet m_dsFinal;
    public string ClaimType = string.Empty;
    #endregion

    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {

                btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvBankDetails','Delete');");
                //mvChkEditDel.ActiveViewIndex = 0;
                mvChkEditDel.ActiveViewIndex = 0;
            }
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
            m_objCheckWriting = new RIMS_Base.Biz.CCheckWriting();
            m_objCheckWriting.CEDPK_Chk_No = Convert.ToInt64(((Label)fvChkEditDel.FindControl("lblPkId")).Text);
            m_objCheckWriting.Issue_date = Convert.ToDateTime(((TextBox)fvChkEditDel.FindControl("txtIssueDate")).Text);
            m_objCheckWriting.CEDChkPayment = Convert.ToDecimal(((TextBox)fvChkEditDel.FindControl("txtPayAmount")).Text);
            m_objCheckWriting.Payment_Id = ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).SelectedValue;
            m_objCheckWriting.Paycode = ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).SelectedValue;
            m_objCheckWriting.Service_Begin = Convert.ToDateTime(((TextBox)fvChkEditDel.FindControl("txtDtSBegin")).Text);
            m_objCheckWriting.Service_End = Convert.ToDateTime(((TextBox)fvChkEditDel.FindControl("txtDtSEnd")).Text);
            m_objCheckWriting.Invoice_Number = ((TextBox)fvChkEditDel.FindControl("txtInvoiceNo")).Text;
            m_objCheckWriting.Comments = ((TextBox)fvChkEditDel.FindControl("txtComment")).Text;
            m_intRetval = m_objCheckWriting.Update_CEDCheckEditDel(m_objCheckWriting);
            if (m_intRetval >= 0)
            {
                mvChkEditDel.ActiveViewIndex = 1;
                gvChkEditDel.DataSource = GetCheckDetailsForEditDel();
                //gvChkEditDel.DataSource = GetCheckDetailsForSearch();
                gvChkEditDel.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            m_intRetval = m_objCheckDetails.Delete_CheckDetails(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                mvChkEditDel.ActiveViewIndex = 1;               
                //gvChkEditDel.DataSource = GetCheckDetailsForEditDel();               
                gvChkEditDel.DataSource = null;               
                gvChkEditDel.DataBind();
            }

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
            mvChkEditDel.ActiveViewIndex = 1;
            gvChkEditDel.DataSource = GetCheckDetailsForEditDel();
            //gvChkEditDel.DataSource = GetCheckDetailsForSearch();
            gvChkEditDel.DataBind();
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
            mvChkEditDel.ActiveViewIndex = 1;
            gvChkEditDel.DataSource = GetCheckDetailsForEditDel();
            gvChkEditDel.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }     
    }
    protected void gvChkEditDel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
            }
            if (e.CommandName == "EditItem")
            {
                mvChkEditDel.ActiveViewIndex = 2;
                fvChkEditDel.ChangeMode(FormViewMode.Edit);
                //fvChkEditDel.DataSource = GetCheckDetailsForEditDel();
                txtChkNo.Text = e.CommandArgument.ToString();
                fvChkEditDel.DataSource = GetCheckDetailsForSearch();
                fvChkEditDel.DataBind();
            }
            else if (e.CommandName == "View")
            {
                mvChkEditDel.ActiveViewIndex = 2;
                fvChkEditDel.ChangeMode(FormViewMode.ReadOnly);
                //fvChkEditDel.DataSource = GetCheckDetailsForEditDel();
                txtChkNo.Text = e.CommandArgument.ToString();
                fvChkEditDel.DataSource = GetCheckDetailsForSearch();
                fvChkEditDel.DataBind();


            }
            else if (e.CommandName == "AddItem")
            {
                Response.Redirect("EnterPayment.aspx?ClaimNo=" + e.CommandArgument.ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void fvChkEditDel_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvChkEditDel.CurrentMode == FormViewMode.Edit)
            {
               
                ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).DataSource = GetVendorType();
                if (ClaimType == "Workers_Comp")
                 {
                     ((Label)fvChkEditDel.FindControl("lblIOutStand")).Text = "Indemnity";
                     ((Label)fvChkEditDel.FindControl("lblMOutStand")).Text = "Medical";
                    ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).DataTextField = "FLD_DescO";
                    ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).DataValueField = "FLD_Desc";
                }
                else
                {
                    ((Label)fvChkEditDel.FindControl("lblIOutStand")).Text = "Property Damage";
                    ((Label)fvChkEditDel.FindControl("lblMOutStand")).Text = "Bodily Injury";
                    ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).DataTextField = "FLD_Desc";
                    ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).DataValueField = "FLD_Desc";
                }
                
                ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).DataBind();
                m_lstCommon = new ListItem("--Select Payment ID--", "0");
                ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).Items.Insert(0, m_lstCommon);
                if (ClaimType == "Workers_Comp")
                {
                    if (m_dsFinal.Tables[0].Rows[0]["FLD_Desc"].ToString() == "Medical")
                    {
                        ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).SelectedValue = "Bodily Injury";
                    }
                    if (m_dsFinal.Tables[0].Rows[0]["FLD_Desc"].ToString() == "Indemnity")
                    {
                        ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).SelectedValue = "Property Damage";
                    }
                }
                else
                {
                    ((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).SelectedValue = m_dsFinal.Tables[0].Rows[0]["FLD_Desc"].ToString();
                   
                }
                ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).DataSource = GetPayCode();
                ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).DataTextField = "Trans_Code_Description";
                ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).DataValueField = "Trans_Code_Description";
                ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).DataBind();
                m_lstCommon = new ListItem("--Select Paycode--", "0");
                ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).Items.Insert(0, m_lstCommon);
                ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).SelectedValue = m_dsFinal.Tables[0].Rows[0]["PayCode"].ToString();
                //((TextBox)fvChkEditDel.FindControl("txtPayAmount")).Attributes.Add("onkeypress", "javascript:return check(event,'" + ((TextBox)fvChkEditDel.FindControl("txtPayAmount")).ClientID + "');");
            }
            if (fvChkEditDel.CurrentMode == FormViewMode.ReadOnly)
            {

                
                if (ClaimType == "Workers_Comp")
                {
                    ((Label)fvChkEditDel.FindControl("lblIOutStand")).Text = "Indemnity";
                    ((Label)fvChkEditDel.FindControl("lblMOutStand")).Text = "Medical";
                    
                }
                else
                {
                    ((Label)fvChkEditDel.FindControl("lblIOutStand")).Text = "Property Damage";
                    ((Label)fvChkEditDel.FindControl("lblMOutStand")).Text = "Bodily Injury";
      
                }
            }
             

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlPaymentID_SelectedIndexChanged(object sender, EventArgs e)
    {

        ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).DataSource = GetPayCode();
        ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).DataTextField = "Trans_Code_Description";
        ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).DataValueField = "Trans_Code_Description";
        ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).DataBind();
        m_lstCommon = new ListItem("--Select Paycode--", "0");
        ((DropDownList)fvChkEditDel.FindControl("ddlPayCode")).Items.Insert(0, m_lstCommon);


    }
    protected void gvChkEditDel_Sorting(object sender, GridViewSortEventArgs e)
    {
        //lstChekDetails = new List<RIMS_Base.CCheckDetails>();
        //DataSet m_dsTemp = new DataSet();
        //if (ViewState["sortDirection"] == null)
        //    ViewState["sortDirection"] = SortDirection.Ascending;
        //// Changes the sort direction 
        //else
        //{
        //    if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
        //        ViewState["sortDirection"] = SortDirection.Descending;
        //    else
        //        ViewState["sortDirection"] = SortDirection.Ascending;
        //}
        //ViewState["SortExp"] = e.SortExpression;

        ////lstChekDetails = GetCheckDetailsForEditDel();
        ////lstChekDetails = GetCheckDetailsForSearch();
        //m_dsTemp = GetCheckDetailsForSearch();
        ////if (ViewState["SortExp"] != null)
        ////m_dsTemp.Tables[0].DefaultView.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CCheckDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        //gvChkEditDel.DataSource = m_dsTemp;
        //gvChkEditDel.DataBind();
    }
    protected void btnChkSearch_Click(object sender, EventArgs e)
    {
        mvChkEditDel.ActiveViewIndex = 1;
        gvChkEditDel.DataSource = GetCheckDetailsForSearch();
        gvChkEditDel.DataBind();
        if (m_dsFinal.Tables[0].Rows.Count > 0)
            btnDelete.Visible = true;
        else
            btnDelete.Visible = false;

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            mvChkEditDel.ActiveViewIndex = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvChkEditDel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvChkEditDel.PageIndex = e.NewPageIndex;
        GeneralSorting();
        //gvChkEditDel.DataSource = GetCheckDetailsForSearch();
        //gvChkEditDel.DataBind();
    }
    //protected void gvChkEditDel_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Header)
    //    {
    //        if (String.Empty != strSortExp)
    //        {
    //            AddSortImage(e.Row);
    //        }
    //    }
    //}
    //private int GetSortColumnIndex(string strSortExp)
    //{
    //    int nRet = 0;
    //    // Iterate through the Columns collection to determine the index
    //    // of the column being sorted.
    //    foreach (DataControlField field in gvBankDetails.Columns)
    //    {
    //        if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
    //        {
    //            nRet = gvBankDetails.Columns.IndexOf(field);
    //        }
    //    }
    //    return nRet;
    //}
    //private void AddSortImage(GridViewRow headerRow)
    //{

    //    Int32 iCol = GetSortColumnIndex(strSortExp);
    //    if (-1 == iCol)
    //    {
    //        return;
    //    }
    //    // Create the sorting image based on the sort direction.
    //    Image sortImage = new Image();

    //    if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
    //    {
    //        sortImage.ImageUrl = "~/Images/up-arrow.gif";
    //        sortImage.AlternateText = "Descending Order";
    //    }
    //    else
    //    {
    //        sortImage.ImageUrl = "~/Images/down-arrow.gif";
    //        sortImage.AlternateText = "Ascending Order";
    //    }

    //    // Add the image to the appropriate header cell.
    //    headerRow.Cells[iCol].Controls.Add(sortImage);
    //}
    #endregion
    #region Private Methods
    private List<RIMS_Base.CCheckDetails> GetCheckDetailsForEditDel()
    {
        try
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            if(txtSChkNo.Text != string.Empty)
                lstChekDetails = m_objCheckDetails.GetChkDetailEditDel(Convert.ToInt64(txtSChkNo.Text));
            return lstChekDetails;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Get Paycode.
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CGeneral> GetPayCode()
    {
        try
        {
            m_objPayCode = new RIMS_Base.Biz.CGeneral();
            lstPayCode = new List<RIMS_Base.CGeneral>();
            lstPayCode = m_objPayCode.GetPayCode(((DropDownList)fvChkEditDel.FindControl("ddlPaymentID")).SelectedValue);
            return lstPayCode;
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
    /// Get All Vendor Type.
    /// </summary>
    private List<RIMS_Base.CVendor> GetVendorType()
    {
        try
        {
            m_objVendorType = new RIMS_Base.Biz.CVendor();
            lstVendorType = new List<RIMS_Base.CVendor>();
            lstVendorType = m_objVendorType.GetAllVendorType();
            return lstVendorType;
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
    /// Get Check for Given Search Result.
    /// </summary>
    /// <returns></returns>
    private DataSet GetCheckDetailsForSearch()
    {
        try
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            m_dsFinal = new DataSet();
            m_dsSearch = new DataSet();
           // m_dsSearch = m_objCheckDetails.GetCheckDetailsForSearchByChk(txtChkNo.Text);
            if (chkLstClaimType.Items[0].Selected == false && chkLstClaimType.Items[1].Selected == false && chkLstClaimType.Items[2].Selected == false && chkLstClaimType.Items[3].Selected == false)
            {
                m_dsSearch = m_objCheckDetails.GetCheckDetailsForSearch(chkLstClaimType.Items[0].Selected == true ? chkLstClaimType.Items[0].Value : string.Empty, string.Empty, chkLstClaimType.Items[1].Selected == true ? chkLstClaimType.Items[1].Value : string.Empty, chkLstClaimType.Items[2].Selected == true ? chkLstClaimType.Items[2].Value : string.Empty, chkLstClaimType.Items[3].Selected == true ? chkLstClaimType.Items[3].Value : string.Empty, txtClaimNo.Text, txtDtStart.Text, txtDtEnd.Text, txtFDtClose.Text, txtFDtCloseTo.Text, txtChkNo.Text);
                m_dsFinal.Merge(m_dsSearch);

                m_dsSearch = new DataSet();
                m_dsSearch = m_objCheckDetails.GetCheckDetailsForSearch1(chkLstClaimType.Items[0].Selected == true ? chkLstClaimType.Items[0].Value : string.Empty, string.Empty, chkLstClaimType.Items[1].Selected == true ? chkLstClaimType.Items[1].Value : string.Empty, chkLstClaimType.Items[2].Selected == true ? chkLstClaimType.Items[2].Value : string.Empty, chkLstClaimType.Items[3].Selected == true ? chkLstClaimType.Items[3].Value : string.Empty, txtClaimNo.Text, txtDtStart.Text, txtDtEnd.Text, txtFDtClose.Text, txtFDtCloseTo.Text, txtChkNo.Text);
                m_dsFinal.Merge(m_dsSearch);

                m_dsSearch = new DataSet();
                m_dsSearch = m_objCheckDetails.GetCheckDetailsForSearch2(chkLstClaimType.Items[0].Selected == true ? chkLstClaimType.Items[0].Value : string.Empty, string.Empty, chkLstClaimType.Items[1].Selected == true ? chkLstClaimType.Items[1].Value : string.Empty, chkLstClaimType.Items[2].Selected == true ? chkLstClaimType.Items[2].Value : string.Empty, chkLstClaimType.Items[3].Selected == true ? chkLstClaimType.Items[3].Value : string.Empty, txtClaimNo.Text, txtDtStart.Text, txtDtEnd.Text, txtFDtClose.Text, txtFDtCloseTo.Text, txtChkNo.Text);
                m_dsFinal.Merge(m_dsSearch);

                m_dsSearch = new DataSet();
                m_dsSearch = m_objCheckDetails.GetCheckDetailsForSearch3(chkLstClaimType.Items[0].Selected == true ? chkLstClaimType.Items[0].Value : string.Empty, string.Empty, chkLstClaimType.Items[1].Selected == true ? chkLstClaimType.Items[1].Value : string.Empty, chkLstClaimType.Items[2].Selected == true ? chkLstClaimType.Items[2].Value : string.Empty, chkLstClaimType.Items[3].Selected == true ? chkLstClaimType.Items[3].Value : string.Empty, txtClaimNo.Text, txtDtStart.Text, txtDtEnd.Text, txtFDtClose.Text, txtFDtCloseTo.Text, txtChkNo.Text);
                m_dsFinal.Merge(m_dsSearch);
            }
            else if (chkLstClaimType.Items[0].Selected == true)
            {
                m_dsSearch = m_objCheckDetails.GetCheckDetailsForSearch(chkLstClaimType.Items[0].Selected == true ? chkLstClaimType.Items[0].Value : string.Empty, string.Empty, chkLstClaimType.Items[1].Selected == true ? chkLstClaimType.Items[1].Value : string.Empty, chkLstClaimType.Items[2].Selected == true ? chkLstClaimType.Items[2].Value : string.Empty, chkLstClaimType.Items[3].Selected == true ? chkLstClaimType.Items[3].Value : string.Empty, txtClaimNo.Text, txtDtStart.Text, txtDtEnd.Text, txtFDtClose.Text, txtFDtCloseTo.Text, txtChkNo.Text);
                m_dsFinal.Merge(m_dsSearch);
            }
            else if (chkLstClaimType.Items[1].Selected == true)
            {
                m_dsSearch = new DataSet();
                m_dsSearch = m_objCheckDetails.GetCheckDetailsForSearch1(chkLstClaimType.Items[0].Selected == true ? chkLstClaimType.Items[0].Value : string.Empty, string.Empty, chkLstClaimType.Items[1].Selected == true ? chkLstClaimType.Items[1].Value : string.Empty, chkLstClaimType.Items[2].Selected == true ? chkLstClaimType.Items[2].Value : string.Empty, chkLstClaimType.Items[3].Selected == true ? chkLstClaimType.Items[3].Value : string.Empty, txtClaimNo.Text, txtDtStart.Text, txtDtEnd.Text, txtFDtClose.Text, txtFDtCloseTo.Text, txtChkNo.Text);
                m_dsFinal.Merge(m_dsSearch);
            }
            else if (chkLstClaimType.Items[2].Selected == true)
            {
                m_dsSearch = new DataSet();
                m_dsSearch = m_objCheckDetails.GetCheckDetailsForSearch2(chkLstClaimType.Items[0].Selected == true ? chkLstClaimType.Items[0].Value : string.Empty, string.Empty, chkLstClaimType.Items[1].Selected == true ? chkLstClaimType.Items[1].Value : string.Empty, chkLstClaimType.Items[2].Selected == true ? chkLstClaimType.Items[2].Value : string.Empty, chkLstClaimType.Items[3].Selected == true ? chkLstClaimType.Items[3].Value : string.Empty, txtClaimNo.Text, txtDtStart.Text, txtDtEnd.Text, txtFDtClose.Text, txtFDtCloseTo.Text, txtChkNo.Text);
                m_dsFinal.Merge(m_dsSearch);
            }
            else if (chkLstClaimType.Items[3].Selected == true)
            {
                m_dsSearch = new DataSet();
                m_dsSearch = m_objCheckDetails.GetCheckDetailsForSearch3(chkLstClaimType.Items[0].Selected == true ? chkLstClaimType.Items[0].Value : string.Empty, string.Empty, chkLstClaimType.Items[1].Selected == true ? chkLstClaimType.Items[1].Value : string.Empty, chkLstClaimType.Items[2].Selected == true ? chkLstClaimType.Items[2].Value : string.Empty, chkLstClaimType.Items[3].Selected == true ? chkLstClaimType.Items[3].Value : string.Empty, txtClaimNo.Text, txtDtStart.Text, txtDtEnd.Text, txtFDtClose.Text, txtFDtCloseTo.Text, txtChkNo.Text);
                m_dsFinal.Merge(m_dsSearch);
            }
            if (m_dsFinal != null && m_dsFinal.Tables[0].Rows.Count > 0)
            {
                RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
                ClaimType = m_objClaimReservesInfo.GetClaimType(m_dsFinal.Tables[0].Rows[0][0].ToString());
            }


            return m_dsFinal;
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
            //lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            //lstChekDetails = GetCheckDetailsForSearch();
            //if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            //    lstChekDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CCheckDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            //gvChkEditDel.DataSource = lstChekDetails;
            //gvChkEditDel.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    #endregion







}
