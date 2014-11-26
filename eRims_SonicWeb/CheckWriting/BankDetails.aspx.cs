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

public partial class BankDetails : System.Web.UI.Page
{
    #region Private Variables
    int m_intBankDetailsId = 0;
    int m_intRetval = -1;
    public RIMS_Base.Biz.CBankDetails m_objBankDetails;
    List<RIMS_Base.CBankDetails> lstBankDetails = null;
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    public RIMS_Base.Biz.CGeneral m_objState;
    List<RIMS_Base.CGeneral> lstState = null;
    ListItem m_lstCommon;
    string strSortExp = String.Empty;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            dvSearch.Visible = true;
            if (!IsPostBack)
            {
                if (SetUserRights() == true)
                {
                    btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvBankDetails','Delete');");
                    mvBankDetails.ActiveViewIndex = 0;

                    gvBankDetails.PageSize = 10;

                    gvBankDetails.DataSource = BindBankDetails();
                    gvBankDetails.DataBind();

                    ddlPage.DataBind();
                    ddlPage.SelectedValue = "10";
                    lblPageInfo.Text = "Page 1 of " + gvBankDetails.PageCount.ToString();
                    txtPageNo.Text = "1";
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected bool SetUserRights()
    {
        try
        {

            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(18, Convert.ToInt32(Session["UserRoleId"].ToString()));
                ViewState["Add"] = lstRightDetails[0].PAdd.ToString();
                ViewState["Edit"] = lstRightDetails[0].PEdit.ToString();
                ViewState["Delete"] = lstRightDetails[0].PDelete.ToString();
                ViewState["View"] = lstRightDetails[0].PView.ToString();
                if (ViewState["Add"].ToString() == "True")
                {
                    btnAddNew.Enabled = true;
                }
                else
                {
                    btnAddNew.Enabled = false;
                }
                if (ViewState["Delete"].ToString() == "True")
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
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
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvBankDetails.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvBankDetails.PageCount)
            {
                gvBankDetails.PageIndex = gvBankDetails.PageCount;
                txtPageNo.Text = gvBankDetails.PageCount.ToString();
            }
            else
            {
                gvBankDetails.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvBankDetails.PageCount.ToString();
            gvBankDetails.DataSource = BindBankDetails();
            gvBankDetails.DataBind();
            lblBankDetailsTotal.Text = "Total Bank Details:" + lstBankDetails.Count.ToString();

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
            if (gvBankDetails.PageIndex <= gvBankDetails.PageCount)
            {
                gvBankDetails.PageIndex = gvBankDetails.PageIndex + 1;
                GeneralSorting();
                //gvBankDetails.DataSource = BindBankDetails();
                //gvBankDetails.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvBankDetails.PageIndex + 1) + " of " + gvBankDetails.PageCount.ToString();
                lblBankDetailsTotal.Text = "Total Bank Details:" + lstBankDetails.Count.ToString();
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
            if (gvBankDetails.PageIndex <= gvBankDetails.PageCount)
            {
                gvBankDetails.PageIndex = gvBankDetails.PageIndex - 1;
                //gvBankDetails.DataSource = BindBankDetails();
                //gvBankDetails.DataBind();
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvBankDetails.PageIndex + 1) + " of " + gvBankDetails.PageCount.ToString();
                lblBankDetailsTotal.Text = "Total Bank Details:" + lstBankDetails.Count.ToString();
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
            m_objBankDetails = new RIMS_Base.Biz.CBankDetails();
            m_intRetval = m_objBankDetails.Delete_Details(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                mvBankDetails.ActiveViewIndex = 0;
                gvBankDetails.DataSource = BindBankDetails();
                gvBankDetails.DataBind();
            }
            lblBankDetailsTotal.Text = "Total Bank Details:" + lstBankDetails.Count.ToString();
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
            mvBankDetails.ActiveViewIndex = 1;
            Bindfv(FormViewMode.Insert);
            //((Button)fvBankDetails.FindControl("btnSave")).Attributes.Add("onclick", "return Test();");
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
            m_objBankDetails = new RIMS_Base.Biz.CBankDetails();
            lstBankDetails = new List<RIMS_Base.CBankDetails>();
            lstBankDetails = m_objBankDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            //gvBankDetails.DataSource = m_objBankDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim()); 
            gvBankDetails.DataSource = lstBankDetails;
            gvBankDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvBankDetails.PageCount.ToString();
            lblBankDetailsTotal.Text = "Total Bank Details:" + lstBankDetails.Count.ToString();
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
            m_objBankDetails = new RIMS_Base.Biz.CBankDetails();
            if (fvBankDetails.CurrentMode == FormViewMode.Insert)
            {
                m_objBankDetails.PK_Bank_Details_ID = 0;
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "lblMsg", "var a=document.getElementById('" + lblMessage.ClientID + "');a.innerText=String.format('Duplicate {0} corrective action found, please correct it.','" + txtLocale.Text + "');alert(a.innerText);", true);
            }
            else
            {
                m_objBankDetails.PK_Bank_Details_ID = Convert.ToInt32(((Label)fvBankDetails.FindControl("lblBankDetailsId")).Text);
            }
            m_objBankDetails.Fld_Bank_Name = ((TextBox)fvBankDetails.FindControl("txtBankName")).Text;
            m_objBankDetails.Fld_Address_1 = ((TextBox)fvBankDetails.FindControl("txtAddress1")).Text;
            m_objBankDetails.Fld_Address_2 = ((TextBox)fvBankDetails.FindControl("txtAddress2")).Text;
            m_objBankDetails.Fld_City = ((TextBox)fvBankDetails.FindControl("txtCity")).Text;
            m_objBankDetails.Fld_State = ((DropDownList)fvBankDetails.FindControl("ddlState")).SelectedValue;
            m_objBankDetails.Fld_Zip = ((TextBox)fvBankDetails.FindControl("txtZip")).Text;
            m_objBankDetails.Fld_AccountNo = ((TextBox)fvBankDetails.FindControl("txtAccountNo")).Text;
            m_objBankDetails.Fld_RoutingNo = ((TextBox)fvBankDetails.FindControl("txtRoutingNo")).Text;
            m_objBankDetails.Fld_Bank_State = ((DropDownList)fvBankDetails.FindControl("ddlBankState")).SelectedValue;
            m_objBankDetails.Fld_Bank_No1 = ((TextBox)fvBankDetails.FindControl("txtBankNo1")).Text;
            m_objBankDetails.Fld_Bank_No2 = ((TextBox)fvBankDetails.FindControl("txtBankNo2")).Text;
            m_objBankDetails.Updated_By = Session["UserID"].ToString();
            m_objBankDetails.Update_Date = System.DateTime.Now.Date;
            m_intRetval = m_objBankDetails.InsertUpdate_Details(m_objBankDetails);
            if (m_intRetval >= 0)
            {
                mvBankDetails.ActiveViewIndex = 0;
                gvBankDetails.DataSource = BindBankDetails();
                gvBankDetails.DataBind();
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
            mvBankDetails.ActiveViewIndex = 0;
            gvBankDetails.DataSource = BindBankDetails();
            gvBankDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvBankDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //if (txtPageNo.Text != string.Empty && Convert.ToInt32(txtPageNo.Text) <= gvBankDetails.PageCount)
        {

            //gvBankDetails.PageIndex = e.NewPageIndex+1;
            //gvBankDetails.DataSource = BindBankDetails();
            //gvBankDetails.DataBind();


        }
    }
    protected void gvBankDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
                dvSearch.Visible = false;
                mvBankDetails.ActiveViewIndex = 1;
                m_intBankDetailsId = Convert.ToInt32(e.CommandArgument.ToString());
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
    protected void gvBankDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstBankDetails = new List<RIMS_Base.CBankDetails>();
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

            lstBankDetails = BindBankDetails();
            if (ViewState["SortExp"] != null)
                lstBankDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CBankDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvBankDetails.DataSource = lstBankDetails;
            gvBankDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void fvBankDetails_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvBankDetails.CurrentMode != FormViewMode.ReadOnly)
            {

                ((DropDownList)fvBankDetails.FindControl("ddlState")).DataSource = GetState();
                ((DropDownList)fvBankDetails.FindControl("ddlState")).DataTextField = "FLD_state";
                ((DropDownList)fvBankDetails.FindControl("ddlState")).DataValueField = "FLD_abbreviation";
                ((DropDownList)fvBankDetails.FindControl("ddlState")).DataBind();
                m_lstCommon = new ListItem("--Select State--", "0");
                ((DropDownList)fvBankDetails.FindControl("ddlState")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvBankDetails.FindControl("ddlBankState")).DataSource = GetState();
                ((DropDownList)fvBankDetails.FindControl("ddlBankState")).DataTextField = "FLD_state";
                ((DropDownList)fvBankDetails.FindControl("ddlBankState")).DataValueField = "FLD_abbreviation";
                ((DropDownList)fvBankDetails.FindControl("ddlBankState")).DataBind();
                m_lstCommon = new ListItem("--Select State--", "0");
                ((DropDownList)fvBankDetails.FindControl("ddlBankState")).Items.Insert(0, m_lstCommon);



            }

            if (fvBankDetails.CurrentMode == FormViewMode.Edit)
            {
                ((DropDownList)fvBankDetails.FindControl("ddlState")).SelectedValue = lstBankDetails[0].Fld_State.ToString();
                ((DropDownList)fvBankDetails.FindControl("ddlBankState")).SelectedValue = lstBankDetails[0].Fld_Bank_State.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvBankDetails.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvBankDetails.DataSource = BindBankDetails();
            gvBankDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvBankDetails.PageCount.ToString();
            txtPageNo.Text = "1";
            lblBankDetailsTotal.Text = "Total Bank Details:" + lstBankDetails.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvBankDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
            else
            {
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[1].Controls.Add(sortImage);
            }
        }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvBankDetails.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvBankDetails.Columns.IndexOf(field);
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
        Image sortImage = new Image();

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
    #endregion
    #region Private Methods
    /// <summary>
    /// Get the All Bank's Details
    /// </summary>
    private List<RIMS_Base.CBankDetails> BindBankDetails()
    {
        try
        {
            m_objBankDetails = new RIMS_Base.Biz.CBankDetails();
            lstBankDetails = new List<RIMS_Base.CBankDetails>();
            if (txtSearch.Text != string.Empty)
            {
                lstBankDetails = m_objBankDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstBankDetails = m_objBankDetails.GetAll();
            }
            lblBankDetailsTotal.Text = "Total Bank Details:" + lstBankDetails.Count.ToString();
            return lstBankDetails;
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
    /// Get All State.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetState()
    {
        try
        {
            m_objState = new RIMS_Base.Biz.CGeneral();
            lstState = new List<RIMS_Base.CGeneral>();
            lstState = m_objState.GetAllState();
            return lstState;
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
                fvBankDetails.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
                fvBankDetails.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvBankDetails.ChangeMode(FormViewMode.ReadOnly);
            if (fvMode != FormViewMode.Insert)
            {

                m_objBankDetails = new RIMS_Base.Biz.CBankDetails();
                lstBankDetails = new List<RIMS_Base.CBankDetails>();
                lstBankDetails = m_objBankDetails.Get_DetailsByID(m_intBankDetailsId);
                fvBankDetails.DataSource = lstBankDetails;
            }
            fvBankDetails.DataBind();
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
    /// General Sorting.
    /// </summary>
    private void GeneralSorting()
    {
        try
        {
            lstBankDetails = new List<RIMS_Base.CBankDetails>();
            lstBankDetails = BindBankDetails();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                lstBankDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CBankDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvBankDetails.DataSource = lstBankDetails;
            gvBankDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    protected void gvBankDetails_DataBound(object sender, EventArgs e)
    {

    }
    protected void gvBankDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["Edit"].ToString() == "True")
            {
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = true;
            }
            else
            {
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = false;
            }
            if (ViewState["View"].ToString() == "True")
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = true;
            }
            else
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = false;
            }
        }
    }
}
