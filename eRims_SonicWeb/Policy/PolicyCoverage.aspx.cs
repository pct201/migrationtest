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
using System.IO;

public partial class Policy_PolicyCoverage : clsBasePage
{
    #region Public Variables
    public RIMS_Base.Biz.CPolicyCoverage m_objPolicyCovDetails;
    List<RIMS_Base.CPolicyCoverage> lstPolicyCovDetails = null;
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    public RIMS_Base.Biz.CGeneral m_objAttachmentType;
    List<RIMS_Base.CGeneral> lstAttachmentType = null;
    public RIMS_Base.Biz.CPolicy m_objPolicyType;
    List<RIMS_Base.CPolicy> lstPolicyType = null;
    int m_intPolicyCovDetailsId = 0;
    int m_intRetval = -1;
    public int m_intPreventAdd = 0;
    ListItem m_lstCommon;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "PolicyCoverage";
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/PolicyCoverage/");
        dvSearch.Visible = true;
        dvAttachDetails.Visible = false;
        if (!IsPostBack)
        {
            btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvBankDetails','Delete');");
            btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");
            mvPolicyCovDetails.ActiveViewIndex = 0;

            gvPolicyCovDetails.PageSize = 10;
            btnRemove.Visible = false;
            btnMail.Visible = false;
            gvPolicyCovDetails.DataSource = BindPolicyCovDetails();
            gvPolicyCovDetails.DataBind();

            ddlPage.DataBind();
            ddlPage.SelectedValue = "10";
            lblPageInfo.Text = "Page 1 of " + gvPolicyCovDetails.PageCount.ToString();
            txtPageNo.Text = "1";
            ViewState["PreventAdd"] = "N";

        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvPolicyCovDetails.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvPolicyCovDetails.PageCount)
            {
                gvPolicyCovDetails.PageIndex = gvPolicyCovDetails.PageCount;
                txtPageNo.Text = gvPolicyCovDetails.PageCount.ToString();
            }
            else
            {
                gvPolicyCovDetails.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvPolicyCovDetails.PageCount.ToString();
            gvPolicyCovDetails.DataSource = BindPolicyCovDetails();
            gvPolicyCovDetails.DataBind();


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
            if (gvPolicyCovDetails.PageIndex <= gvPolicyCovDetails.PageCount)
            {
                gvPolicyCovDetails.PageIndex = gvPolicyCovDetails.PageIndex + 1;
                gvPolicyCovDetails.DataSource = BindPolicyCovDetails();
                gvPolicyCovDetails.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvPolicyCovDetails.PageIndex + 1) + " of " + gvPolicyCovDetails.PageCount.ToString();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvPolicyCovDetails.PageIndex <= gvPolicyCovDetails.PageCount)
            {
                gvPolicyCovDetails.PageIndex = gvPolicyCovDetails.PageIndex - 1;
                gvPolicyCovDetails.DataSource = BindPolicyCovDetails();
                gvPolicyCovDetails.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvPolicyCovDetails.PageIndex + 1) + " of " + gvPolicyCovDetails.PageCount.ToString();

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
            //m_objPolicyDetails = new RIMS_Base.Biz.CPolicy();
            //m_intRetval = m_objPolicyDetails.Delete_Policy(Request.Form["chkItem"].ToString());
            //if (m_intRetval <= 0)
            //{
            //    mvPolicyDetails.ActiveViewIndex = 0;
            //    gvPolicyCovDetails.DataSource = BindPolicyDetails();
            //    gvPolicyCovDetails.DataBind();
            //}
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
            m_objPolicyCovDetails = new RIMS_Base.Biz.CPolicyCoverage();
            lstPolicyCovDetails = new List<RIMS_Base.CPolicyCoverage>();
            lstPolicyCovDetails = m_objPolicyCovDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            gvPolicyCovDetails.DataSource = lstPolicyCovDetails;
            gvPolicyCovDetails.DataBind();
            lblPolicyCovTotal.Text = "Total Policy Coverage Details:" + lstPolicyCovDetails.Count.ToString();
            lblPageInfo.Text = "Page 1 of " + gvPolicyCovDetails.PageCount.ToString();
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
            mvPolicyCovDetails.ActiveViewIndex = 1;
            Bindfv(FormViewMode.Insert);
            btnRemove.Visible = false;
            btnMail.Visible = false;
            //((Button)fvBankDetails.FindControl("btnSave")).Attributes.Add("onclick", "return Test();");
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
            Page.Validate();
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objPolicyCovDetails = new RIMS_Base.Biz.CPolicyCoverage();
                if (fvPolicyCovDetails.CurrentMode == FormViewMode.Insert)
                {
                    m_objPolicyCovDetails.PK_Policy_Coverage_Id = 0;
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "lblMsg", "var a=document.getElementById('" + lblMessage.ClientID + "');a.innerText=String.format('Duplicate {0} corrective action found, please correct it.','" + txtLocale.Text + "');alert(a.innerText);", true);
                }
                else
                {
                    m_objPolicyCovDetails.PK_Policy_Coverage_Id = Convert.ToInt32(((Label)fvPolicyCovDetails.FindControl("lblPolicyCovDetailsId")).Text);
                }

                m_objPolicyCovDetails.FK_Policy = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlPolicy")).SelectedValue);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtPolCovDesc")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Policy_Coverage = ((TextBox)fvPolicyCovDetails.FindControl("txtPolCovDesc")).Text;
                if (((TextBox)fvPolicyCovDetails.FindControl("txtPolicyDeductible")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Policy_Deductible = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtPolicyDeductible")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtPolLimit")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Occurrence_Limit = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtPolLimit")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtPolLimitGen")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Aggregate_Limit = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtPolLimitGen")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtGLRentDamage")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.GL_Rent_Damage = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtGLRentDamage")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtGLMedical")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.GL_Medical = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtGLMedical")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtGLProducts")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.GL_Products = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtGLProducts")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtALPIP")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.AL_PIP = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtALPIP")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtALMedical")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.AL_Medical = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtALMedical")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtUmbrellaLiabilityLimit")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Umbrella = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtUmbrellaLiabilityLimit")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtOtherLiabilityCoverageType")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Other_Policy_Type = Convert.ToString(((TextBox)fvPolicyCovDetails.FindControl("txtOtherLiabilityCoverageType")).Text);

                m_objPolicyCovDetails.AL_Uninsured = Convert.ToString(((RadioButtonList)fvPolicyCovDetails.FindControl("rblUnisuredMotoristCoverage")).SelectedValue);
                m_objPolicyCovDetails.AL_Underinsured = Convert.ToString(((RadioButtonList)fvPolicyCovDetails.FindControl("rblUnderInsuredMotoristCoverage")).SelectedValue);
              
                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit1")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_1 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit1")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct1")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_1 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct1")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_1 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature1")).SelectedValue);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit2")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_2 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit2")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct2")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_2 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct2")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_2 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature2")).SelectedValue);

                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit3")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_3 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit3")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct3")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_3 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct3")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_3 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature3")).SelectedValue);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit4")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_4 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit4")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct4")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_4 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct4")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_4 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature4")).SelectedValue);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit5")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_5 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit5")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct5")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_5 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct5")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_5 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature5")).SelectedValue);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit6")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_6 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit6")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct6")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_6 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct6")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_6 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature6")).SelectedValue);
                m_objPolicyCovDetails.Updated_By = "1";
                m_objPolicyCovDetails.Update_Date = System.DateTime.Now.Date;
                m_intRetval = m_objPolicyCovDetails.InsertUpdatePolicy_Coverage(m_objPolicyCovDetails);
                if (m_intRetval >= 0)
                {
                    mvPolicyCovDetails.ActiveViewIndex = 0;
                    gvPolicyCovDetails.DataSource = BindPolicyCovDetails();
                    gvPolicyCovDetails.DataBind();
                }

            }
            else
            {
                ViewState["PreventAdd"] = "N";
                mvPolicyCovDetails.ActiveViewIndex = 0;
                gvPolicyCovDetails.DataSource = BindPolicyCovDetails();
                gvPolicyCovDetails.DataBind();
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


            gvPolicyCovDetails.DataSource = BindPolicyCovDetails();
            gvPolicyCovDetails.DataBind();
            mvPolicyCovDetails.ActiveViewIndex = 0;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvPolicyCovDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName != "Sort")
            {
                dvSearch.Visible = false;
                mvPolicyCovDetails.ActiveViewIndex = 1;
                m_intPolicyCovDetailsId = Convert.ToInt32(e.CommandArgument.ToString());
            }
            if (e.CommandName == "EditItem")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.Edit);
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }

            }
            if (e.CommandName == "View")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.ReadOnly);
                fvPolicyCovDetails.ChangeMode(FormViewMode.ReadOnly);
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                btnRemove.Visible = false;
                btnMail.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvPolicyCovDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        lstPolicyCovDetails = new List<RIMS_Base.CPolicyCoverage>();
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

        lstPolicyCovDetails = BindPolicyCovDetails();
        if (ViewState["SortExp"] != null)
            lstPolicyCovDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CPolicyCoverage>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        gvPolicyCovDetails.DataSource = lstPolicyCovDetails;

        gvPolicyCovDetails.DataBind();
    }
    protected void fvPolicyCovDetails_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvPolicyCovDetails.CurrentMode != FormViewMode.ReadOnly)
            {

                ((DropDownList)fvPolicyCovDetails.FindControl("ddlPolicy")).DataSource = GetPolicy();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlPolicy")).DataTextField = "Policy_Number";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlPolicy")).DataValueField = "PK_Policy_Id";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlPolicy")).DataBind();
                m_lstCommon = new ListItem("--Select Policy--", "0");
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlPolicy")).Items.Insert(0, m_lstCommon);


                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature1")).DataSource = GetPolicyFeatures();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature1")).DataTextField = "PolicyFeature";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature1")).DataValueField = "PolicyFeature_Pk_Id";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature1")).DataBind();
                m_lstCommon = new ListItem("--Select Policy Feature--", "0");
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature1")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature2")).DataSource = GetPolicyFeatures();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature2")).DataTextField = "PolicyFeature";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature2")).DataValueField = "PolicyFeature_Pk_Id";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature2")).DataBind();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature2")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature3")).DataSource = GetPolicyFeatures();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature3")).DataTextField = "PolicyFeature";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature3")).DataValueField = "PolicyFeature_Pk_Id";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature3")).DataBind();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature3")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature4")).DataSource = GetPolicyFeatures();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature4")).DataTextField = "PolicyFeature";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature4")).DataValueField = "PolicyFeature_Pk_Id";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature4")).DataBind();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature4")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature5")).DataSource = GetPolicyFeatures();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature5")).DataTextField = "PolicyFeature";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature5")).DataValueField = "PolicyFeature_Pk_Id";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature5")).DataBind();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature5")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature6")).DataSource = GetPolicyFeatures();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature6")).DataTextField = "PolicyFeature";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature6")).DataValueField = "PolicyFeature_Pk_Id";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature6")).DataBind();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature6")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvPolicyCovDetails.FindControl("ddlAttachType")).DataSource = GetAttachmentType();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlAttachType")).DataBind();
                m_lstCommon = new ListItem("--Select Attachment Type--", "0");
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlAttachType")).Items.Insert(0, m_lstCommon);



            }

            if (fvPolicyCovDetails.CurrentMode == FormViewMode.Edit)
            {
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlPolicy")).SelectedValue = lstPolicyCovDetails[0].FK_Policy.ToString();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature1")).SelectedValue = lstPolicyCovDetails[0].FK_Policy_Feature_1.ToString();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature2")).SelectedValue = lstPolicyCovDetails[0].FK_Policy_Feature_2.ToString();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature3")).SelectedValue = lstPolicyCovDetails[0].FK_Policy_Feature_3.ToString();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature4")).SelectedValue = lstPolicyCovDetails[0].FK_Policy_Feature_4.ToString();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature5")).SelectedValue = lstPolicyCovDetails[0].FK_Policy_Feature_5.ToString();
                ((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature6")).SelectedValue = lstPolicyCovDetails[0].FK_Policy_Feature_6.ToString();
                ((RadioButtonList)fvPolicyCovDetails.FindControl("rblUnderinsuredMotoristCoverage")).SelectedValue = lstPolicyCovDetails[0].AL_Underinsured.ToString();
                ((RadioButtonList)fvPolicyCovDetails.FindControl("rblUnisuredMotoristCoverage")).SelectedValue = lstPolicyCovDetails[0].AL_Uninsured.ToString();

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
            gvPolicyCovDetails.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvPolicyCovDetails.DataSource = BindPolicyCovDetails();
            gvPolicyCovDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvPolicyCovDetails.PageCount.ToString();
            txtPageNo.Text = "1";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=PolicyCoverage&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }
            //if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            //{
            //    gvAttachmentDetails.EmptyDataText = "Yash";
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = false;
        if (fvPolicyCovDetails.CurrentMode == FormViewMode.Insert)
        {
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objPolicyCovDetails = new RIMS_Base.Biz.CPolicyCoverage();
                if (fvPolicyCovDetails.CurrentMode == FormViewMode.Insert)
                {
                    m_objPolicyCovDetails.PK_Policy_Coverage_Id = 0;
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "lblMsg", "var a=document.getElementById('" + lblMessage.ClientID + "');a.innerText=String.format('Duplicate {0} corrective action found, please correct it.','" + txtLocale.Text + "');alert(a.innerText);", true);
                }
                else
                {
                    m_objPolicyCovDetails.PK_Policy_Coverage_Id = Convert.ToInt32(((Label)fvPolicyCovDetails.FindControl("lblPolicyCovDetailsId")).Text);
                }

                m_objPolicyCovDetails.FK_Policy = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlPolicy")).SelectedValue);

                if (((TextBox)fvPolicyCovDetails.FindControl("txtPolCovDesc")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Policy_Coverage = ((TextBox)fvPolicyCovDetails.FindControl("txtPolCovDesc")).Text;
                if (((TextBox)fvPolicyCovDetails.FindControl("txtPolicyDeductible")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Policy_Deductible = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtPolicyDeductible")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtPolLimit")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Occurrence_Limit = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtPolLimit")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtPolLimitGen")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Aggregate_Limit = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtPolLimitGen")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtGLRentDamage")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.GL_Rent_Damage = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtGLRentDamage")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtGLMedical")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.GL_Medical = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtGLMedical")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtGLProducts")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.GL_Products = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtGLProducts")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtALPIP")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.AL_PIP = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtALPIP")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtALMedical")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.AL_Medical = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtALMedical")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtUmbrellaLiabilityLimit")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Umbrella = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtUmbrellaLiabilityLimit")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtOtherLiabilityCoverageType")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Other_Policy_Type = Convert.ToString(((TextBox)fvPolicyCovDetails.FindControl("txtOtherLiabilityCoverageType")).Text);

                m_objPolicyCovDetails.AL_Uninsured = Convert.ToString(((RadioButtonList)fvPolicyCovDetails.FindControl("rblUnisuredMotoristCoverage")).SelectedValue);
                m_objPolicyCovDetails.AL_Underinsured = Convert.ToString(((RadioButtonList)fvPolicyCovDetails.FindControl("rblUnderInsuredMotoristCoverage")).SelectedValue);

                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit1")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_1 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit1")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct1")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_1 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct1")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_1 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature1")).SelectedValue);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit2")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_2 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit2")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct2")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_2 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct2")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_2 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature2")).SelectedValue);

                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit3")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_3 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit3")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct3")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_3 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct3")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_3 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature3")).SelectedValue);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit4")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_4 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit4")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct4")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_4 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct4")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_4 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature4")).SelectedValue);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit5")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_5 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit5")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct5")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_5 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct5")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_5 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature5")).SelectedValue);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtLimit6")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Limit_6 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtLimit6")).Text);
                if (((TextBox)fvPolicyCovDetails.FindControl("txtDeduct6")).Text.Trim() != string.Empty)
                    m_objPolicyCovDetails.Deductible_6 = Convert.ToDecimal(((TextBox)fvPolicyCovDetails.FindControl("txtDeduct6")).Text);
                m_objPolicyCovDetails.FK_Policy_Feature_6 = Convert.ToDecimal(((DropDownList)fvPolicyCovDetails.FindControl("ddlSpecificFeature6")).SelectedValue);


                m_objPolicyCovDetails.Updated_By = "1";
                m_objPolicyCovDetails.Update_Date = System.DateTime.Now.Date;
                m_intRetval = m_objPolicyCovDetails.InsertUpdatePolicy_Coverage(m_objPolicyCovDetails);
                ViewState["PreventAdd"] = "Y";
                ((Label)fvPolicyCovDetails.FindControl("lblPolicyCovDetailsId")).Text = m_intRetval.ToString();
            }
            if (m_intRetval >= 0 || ViewState["PreventAdd"].ToString() == "Y")
            {
                dvAttachDetails.Visible = true;

                AddAttachment();
                if (m_intRetval >= 0)
                {
                    gvAttachmentDetails.DataSource = BindAttachmentDetails();
                    gvAttachmentDetails.DataBind();
                    if (lstAttachment.Count > 0)
                    {
                        btnRemove.Visible = true;
                        btnMail.Visible = true;
                    }
                    else
                    {
                        btnRemove.Visible = false;
                        btnMail.Visible = false;
                    }

                }
            }
        }
        else
        {
            dvAttachDetails.Visible = true;
            AddAttachment();
            if (m_intRetval >= 0)
            {
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }

            }
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_intRetval = m_objAttachment.DeleteAttachment(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {

                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }
            }
            dvAttachDetails.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region Private Methods
    /// <summary>
    /// Get Policy Details.
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CPolicyCoverage> BindPolicyCovDetails()
    {
        try
        {
            m_objPolicyCovDetails = new RIMS_Base.Biz.CPolicyCoverage();
            lstPolicyCovDetails = new List<RIMS_Base.CPolicyCoverage>();
            lstPolicyCovDetails = null;
            if (txtSearch.Text != string.Empty)
            {
                lstPolicyCovDetails = m_objPolicyCovDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstPolicyCovDetails = m_objPolicyCovDetails.GetAll();
            }
            lblPolicyCovTotal.Text = "Total Policy Coverage Details:" + lstPolicyCovDetails.Count.ToString();
            return lstPolicyCovDetails;
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
                fvPolicyCovDetails.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
                fvPolicyCovDetails.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvPolicyCovDetails.ChangeMode(FormViewMode.ReadOnly);
            if (fvMode != FormViewMode.Insert)
            {
                dvAttachDetails.Visible = true;
                m_objPolicyCovDetails = new RIMS_Base.Biz.CPolicyCoverage();
                lstPolicyCovDetails = new List<RIMS_Base.CPolicyCoverage>();
                lstPolicyCovDetails = m_objPolicyCovDetails.GetPolicy_CoverageByID(m_intPolicyCovDetailsId);
                fvPolicyCovDetails.DataSource = lstPolicyCovDetails;
            }
            fvPolicyCovDetails.DataBind();

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
    #region Attachment Details
    /// <summary>
    /// Bind The Attachment Details.
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(((Label)fvPolicyCovDetails.FindControl("lblPolicyCovDetailsId")).Text), "PolicyCoverage");
            return lstAttachment;
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
    /// Get All Attachment Type.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetAttachmentType()
    {
        try
        {
            m_objAttachmentType = new RIMS_Base.Biz.CGeneral();
            lstAttachmentType = new List<RIMS_Base.CGeneral>();
            lstAttachmentType = m_objAttachmentType.GetAttachamentType();
            return lstAttachmentType;
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
    /// Upload Documents
    /// </summary>
    private void UploadDocuments()
    {
        try
        {

            //((FileUpload)fvVendorDetails.FindControl("uplCommon")).fi
            m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

            if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
            {
                Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
            }
            //if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName + "\\Photos")))
            //{
            //    Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName + "\\Photos");
            //}
            m_strFileName = GetCustomFileName() + ((FileUpload)fvPolicyCovDetails.FindControl("uplCommon")).FileName.ToString();
            //m_strPath = m_strPath + "\\" + m_strFolderName + "\\Photos\\" + ufFile.GetName().ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;

            //m_strFileName = ufFile.GetName().ToString();
            ((FileUpload)fvPolicyCovDetails.FindControl("uplCommon")).SaveAs(m_strPath);


        }
        catch (Exception ex)
        {
            //Log.Append("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:" + ex.Message);
            //Common.reportError("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:", ex.Message);
            throw ex;
        }
    }
    /// <summary>
    /// Get Custom File Name.
    /// </summary>
    /// <returns></returns>
    private string GetCustomFileName()
    {
        try
        {

            m_strCustomFileName = System.DateTime.Now.ToString("MMddyyhhmmss");

        }
        catch (Exception ex)
        {
            //Log.Append("Error in GetCustomFileName Method of ConditionAssessment's PhotoGraph:" + ex.Message);
            //Common.reportError("Error in GetCustomFileName Method of ConditionAssessment's PhotoGraph:", ex.Message);
            throw ex;
        }
        return m_strCustomFileName;
    }
    /// <summary>
    /// Insert Attachment in Database.
    /// </summary>
    /// <returns>Integer</returns>
    private int AddAttachment()
    {
        try
        {
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "PolicyCoverage";
            m_objAttachment.Foreign_Key = Convert.ToInt32(((Label)fvPolicyCovDetails.FindControl("lblPolicyCovDetailsId")).Text);
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvPolicyCovDetails.FindControl("ddlAttachType")).SelectedValue);
            m_objAttachment.Attachment_Description = ((TextBox)fvPolicyCovDetails.FindControl("txtDescription")).Text;
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = "1";
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            m_intRetval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);
            ((TextBox)fvPolicyCovDetails.FindControl("txtDescription")).Text = string.Empty;
            ((DropDownList)fvPolicyCovDetails.FindControl("ddlAttachType")).SelectedValue = "0";

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_intRetval;
    }
    #endregion

    private List<RIMS_Base.CPolicy> GetPolicy()
    {
        try
        {
            m_objPolicyType = new RIMS_Base.Biz.CPolicy();
            lstPolicyType = new List<RIMS_Base.CPolicy>();
            lstPolicyType = m_objPolicyType.GetAll();
            return lstPolicyType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }

    private List<RIMS_Base.CPolicyCoverage> GetPolicyFeatures()
    {
        try
        {
            RIMS_Base.Biz.CPolicyCoverage m_objPolicyCovFeatures = new RIMS_Base.Biz.CPolicyCoverage();
            List<RIMS_Base.CPolicyCoverage> lstPolicyCovFeatures = new List<RIMS_Base.CPolicyCoverage>();
            lstPolicyCovFeatures = m_objPolicyCovFeatures.GetPolicyFeatures();
            return lstPolicyCovFeatures;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
}
