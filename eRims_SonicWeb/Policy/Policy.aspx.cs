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

public partial class Policy_Policy : clsBasePage
{
    #region Public Variables
    int m_intPolicyDetailsId = 0;
    int m_intRetval = -1;
    public int m_intPreventAdd = 0;
    public RIMS_Base.Biz.CPolicy m_objPolicyDetails;
    List<RIMS_Base.CPolicy> lstPolicyDetails = null;
    public RIMS_Base.Biz.CGeneral m_objAttachmentType;
    List<RIMS_Base.CGeneral> lstAttachmentType = null;
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    ListItem m_lstCommon;
    public RIMS_Base.Biz.CPolicy m_objPolicyType;
    List<RIMS_Base.CPolicy> lstPolicyType = null;
    public RIMS_Base.Biz.CPolicy m_objPolicyStatus;
    List<RIMS_Base.CPolicy> lstPolicyStatus = null;
    public RIMS_Base.Biz.CPolicy m_objCovCode;
    List<RIMS_Base.CPolicy> lstCovCode = null;


    public string m_strPath = string.Empty;
    public string m_strFolderName = "Policy";
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    #endregion
    #region Event Handler
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (fvPolicyDetails.CurrentMode != FormViewMode.ReadOnly)
            //{
            //    PostBackTrigger pt = new PostBackTrigger();
            //    pt.ControlID = ((Button)fvPolicyDetails.FindControl("btnAddAttachment")).ClientID;
            //    UpdatePanelTriggerCollection n = new UpdatePanelTriggerCollection();

            //    pnlVendorDetail.Triggers.Insert(0, pt);
            //}
            
                
           
            m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Policy/");
            dvSearch.Visible = true;
            dvAttachDetails.Visible = false;
            if (!IsPostBack)
            {
                btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvBankDetails','Delete');");
                btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");
                mvPolicyDetails.ActiveViewIndex = 0;

                gvPolicyDetails.PageSize = 10;
                btnRemove.Visible = false;
                btnMail.Visible = false;
                gvPolicyDetails.DataSource = BindPolicyDetails();
                gvPolicyDetails.DataBind();

                ddlPage.DataBind();
                ddlPage.SelectedValue = "10";
                lblPageInfo.Text = "Page 1 of " + gvPolicyDetails.PageCount.ToString();
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
                gvPolicyDetails.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvPolicyDetails.PageCount)
            {
                gvPolicyDetails.PageIndex = gvPolicyDetails.PageCount;
                txtPageNo.Text = gvPolicyDetails.PageCount.ToString();
            }
            else
            {
                gvPolicyDetails.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvPolicyDetails.PageCount.ToString();
            gvPolicyDetails.DataSource = BindPolicyDetails();
            gvPolicyDetails.DataBind();
            lblPolicyTotal.Text = "Total Policy Details:" + lstPolicyDetails.Count.ToString();


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
            if (gvPolicyDetails.PageIndex <= gvPolicyDetails.PageCount)
            {
                gvPolicyDetails.PageIndex = gvPolicyDetails.PageIndex + 1;
                gvPolicyDetails.DataSource = BindPolicyDetails();
                gvPolicyDetails.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvPolicyDetails.PageIndex + 1) + " of " + gvPolicyDetails.PageCount.ToString();
                lblPolicyTotal.Text = "Total Policy Details:" + lstPolicyDetails.Count.ToString();
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
            if (gvPolicyDetails.PageIndex <= gvPolicyDetails.PageCount)
            {
                gvPolicyDetails.PageIndex = gvPolicyDetails.PageIndex - 1;
                gvPolicyDetails.DataSource = BindPolicyDetails();
                gvPolicyDetails.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvPolicyDetails.PageIndex + 1) + " of " + gvPolicyDetails.PageCount.ToString();
                lblPolicyTotal.Text = "Total Policy Details:" + lstPolicyDetails.Count.ToString();
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
            m_objPolicyDetails = new RIMS_Base.Biz.CPolicy();
            m_intRetval = m_objPolicyDetails.Delete_Policy(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                mvPolicyDetails.ActiveViewIndex = 0;
                gvPolicyDetails.DataSource = BindPolicyDetails();
                gvPolicyDetails.DataBind();
            }
            lblPolicyTotal.Text = "Total Policy Details:" + lstPolicyDetails.Count.ToString();
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
            mvPolicyDetails.ActiveViewIndex = 1;
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            m_objPolicyDetails = new RIMS_Base.Biz.CPolicy();
            lstPolicyDetails = new List<RIMS_Base.CPolicy>();
            lstPolicyDetails = m_objPolicyDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            gvPolicyDetails.DataSource = lstPolicyDetails;
            gvPolicyDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvPolicyDetails.PageCount.ToString();
            lblPolicyTotal.Text = "Total Policy Details:" + lstPolicyDetails.Count.ToString();
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
            //Page.Validate();
            //if (Page.IsValid)
            {
                if (ViewState["PreventAdd"].ToString() == "N")
                {
                    m_objPolicyDetails = new RIMS_Base.Biz.CPolicy();
                    if (fvPolicyDetails.CurrentMode == FormViewMode.Insert)
                    {
                        m_objPolicyDetails.PK_Policy_Id = 0;
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "lblMsg", "var a=document.getElementById('" + lblMessage.ClientID + "');a.innerText=String.format('Duplicate {0} corrective action found, please correct it.','" + txtLocale.Text + "');alert(a.innerText);", true);
                    }
                    else
                    {
                        m_objPolicyDetails.PK_Policy_Id = Convert.ToInt64(((Label)fvPolicyDetails.FindControl("lblPolicyDetailsId")).Text);
                    }

                    m_objPolicyDetails.FK_Policy_Type = Convert.ToDecimal(((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).SelectedValue);
                    if (((TextBox)fvPolicyDetails.FindControl("txtPolNo")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Policy_Number = ((TextBox)fvPolicyDetails.FindControl("txtPolNo")).Text;
                    if (((TextBox)fvPolicyDetails.FindControl("txtNCCI")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.NCCI_Classification_Code = ((TextBox)fvPolicyDetails.FindControl("txtNCCI")).Text;
                    
                        m_objPolicyDetails.FK_Coverage_Code = Convert.ToDecimal(((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).SelectedValue);
                        if (((TextBox)fvPolicyDetails.FindControl("txtCarrier")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Carrier = ((TextBox)fvPolicyDetails.FindControl("txtCarrier")).Text;
                    if (((TextBox)fvPolicyDetails.FindControl("txtUnderWriter")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Underwriter = ((TextBox)fvPolicyDetails.FindControl("txtUnderWriter")).Text;
                    if (((TextBox)fvPolicyDetails.FindControl("txtDtPolBegin")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Policy_Begin_Date = Convert.ToDateTime(((TextBox)fvPolicyDetails.FindControl("txtDtPolBegin")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtDtPolExp")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Policy_Expiration_Date = Convert.ToDateTime(((TextBox)fvPolicyDetails.FindControl("txtDtPolExp")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtStates")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.States_Covered = Request.Form[((TextBox)fvPolicyDetails.FindControl("txtStates")).UniqueID.ToString()].ToString();
                    m_objPolicyDetails.FK_Policy_Status = Convert.ToDecimal(((DropDownList)fvPolicyDetails.FindControl("ddlPolStatus")).SelectedValue);
                    if (((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Annual_Premium = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtClientId")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Client_Id = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtClientId")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtClientLocCode")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Client_Location_Code = ((TextBox)fvPolicyDetails.FindControl("txtClientLocCode")).Text;
                    if (((TextBox)fvPolicyDetails.FindControl("txtDtContEnd")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Contract_End_Date = Convert.ToDateTime(((TextBox)fvPolicyDetails.FindControl("txtDtContEnd")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtDtContEnd")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Contract_Start_Date = Convert.ToDateTime(((TextBox)fvPolicyDetails.FindControl("txtDtContStart")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtContNo")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Contract_Number = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtContNo")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtFedNo")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Employer_Fed_ID_No = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtFedNo")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtEmpSICNo")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Employer_SIC = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtEmpSICNo")).Text);
                    m_objPolicyDetails.Deductible = ((RadioButtonList)fvPolicyDetails.FindControl("rdbLstDeduct")).SelectedValue;
                    if (((TextBox)fvPolicyDetails.FindControl("txtDivAIG")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Division_AIG = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtDivAIG")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtPolPrefix")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Policy_Prefix = ((TextBox)fvPolicyDetails.FindControl("txtPolPrefix")).Text;
                    if (((TextBox)fvPolicyDetails.FindControl("txtISO")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Insured_ISO_Cat = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtISO")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtLayerNo")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Layer_Number = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtLayerNo")).Text);
                    if (((TextBox)fvPolicyDetails.FindControl("txtCovDesc")).Text.Trim() != string.Empty)
                        m_objPolicyDetails.Coverage_Description = ((TextBox)fvPolicyDetails.FindControl("txtCovDesc")).Text;

                    m_objPolicyDetails.Updated_By = "1";
                    m_objPolicyDetails.Update_Date = System.DateTime.Now.Date;
                    m_intRetval = m_objPolicyDetails.InsertUpdate_Policy(m_objPolicyDetails);
                    if (m_intRetval >= 0)
                    {
                        mvPolicyDetails.ActiveViewIndex = 0;
                        gvPolicyDetails.DataSource = BindPolicyDetails();
                        gvPolicyDetails.DataBind();
                    }

                }
                else
                {
                    ViewState["PreventAdd"] = "N";
                    mvPolicyDetails.ActiveViewIndex = 0;
                    gvPolicyDetails.DataSource = BindPolicyDetails();
                    gvPolicyDetails.DataBind();
                }
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


            gvPolicyDetails.DataSource = BindPolicyDetails();
            gvPolicyDetails.DataBind();
            mvPolicyDetails.ActiveViewIndex = 0;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvPolicyDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
                dvSearch.Visible = false;
                mvPolicyDetails.ActiveViewIndex = 1;
                m_intPolicyDetailsId = Convert.ToInt32(e.CommandArgument.ToString());
            }
            if (e.CommandName == "EditItem")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.Edit);
                //((GridView)fvPolicyDetails.FindControl("gvAttachmentDetails")).DataSource = BindAttachmentDetails();
                //((GridView)fvPolicyDetails.FindControl("gvAttachmentDetails")).DataBind();
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
                //((GridView)fvPolicyDetails.FindControl("gvAttachmentDetails")).DataSource = BindAttachmentDetails();
                //((GridView)fvPolicyDetails.FindControl("gvAttachmentDetails")).DataBind();
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
    protected void gvPolicyDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        lstPolicyDetails = new List<RIMS_Base.CPolicy>();
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

        lstPolicyDetails = BindPolicyDetails();
        if (ViewState["SortExp"] != null)
            lstPolicyDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CPolicy>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        gvPolicyDetails.DataSource = lstPolicyDetails;
        gvPolicyDetails.DataBind();
    }
    protected void fvPolicyDetails_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvPolicyDetails.CurrentMode != FormViewMode.ReadOnly)
            {
               
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolStatus")).DataSource = GetPolicyStatus();
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolStatus")).DataTextField = "PolicyStatusFLD_desc";
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolStatus")).DataValueField = "PolicyStatusPK_ID";
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolStatus")).DataBind();
                m_lstCommon = new ListItem("--Select Policy Status--", "0");
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolStatus")).Items.Insert(0, m_lstCommon);
                //((DropDownList)fvPolicyDetails.FindControl("ddlState")).Items.Insert(0, "--Select State--");

                ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).DataSource = GetPolicyType();
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).DataTextField = "PolicyTypeFLD_desc";
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).DataValueField = "PolicyTypePK_ID";
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).DataBind();
                m_lstCommon = new ListItem("--Select Policy Type--", "0");
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).Items.Insert(0, m_lstCommon);
                //((DropDownList)fvPolicyDetails.FindControl("ddlType")).Items.Insert(0, "--Select Policy Type--");

                ((DropDownList)fvPolicyDetails.FindControl("ddlAttachType")).DataSource = GetAttachmentType();
                ((DropDownList)fvPolicyDetails.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvPolicyDetails.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
                ((DropDownList)fvPolicyDetails.FindControl("ddlAttachType")).DataBind();
                m_lstCommon = new ListItem("--Select Attachment Type--", "0");
                ((DropDownList)fvPolicyDetails.FindControl("ddlAttachType")).Items.Insert(0, m_lstCommon);
               
               // ((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Attributes.Add("onkeypress", "return check(event,'" + ((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).ClientID + "');");

            }

            if (fvPolicyDetails.CurrentMode == FormViewMode.Edit)
            {
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).SelectedValue = lstPolicyDetails[0].FK_Policy_Type.ToString();
                ((DropDownList)fvPolicyDetails.FindControl("ddlPolStatus")).SelectedValue = lstPolicyDetails[0].FK_Policy_Status.ToString();
                ((RadioButtonList)fvPolicyDetails.FindControl("rdbLstDeduct")).SelectedValue = lstPolicyDetails[0].Deductible.ToString();

                ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).DataSource = GetCoverageCode(0);
                ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).DataTextField = "CovCode_FLD_Code";
                ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).DataValueField = "CovCode_PK_Id";
                ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).DataBind();
                m_lstCommon = new ListItem("--Select Coverage Code--", "0");
                ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).Items.Insert(0, m_lstCommon);
                ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).SelectedValue = lstPolicyDetails[0].FK_Coverage_Code.ToString();
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
            gvPolicyDetails.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvPolicyDetails.DataSource = BindPolicyDetails();
            gvPolicyDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvPolicyDetails.PageCount.ToString();
            txtPageNo.Text = "1";
            lblPolicyTotal.Text = "Total Policy Details:" + lstPolicyDetails.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlPolType_SelectedIndexChanged(object sender, EventArgs e)
    {
        dvSearch.Visible = false;
        if (((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).SelectedIndex > 0)
        {

            ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).DataSource = GetCoverageCode(Convert.ToDecimal(((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).SelectedValue));
            ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).DataTextField = "CovCode_FLD_Code";
            ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).DataValueField = "CovCode_PK_Id";
            ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).DataBind();
            m_lstCommon = new ListItem("--Select Coverage Code--", "0");
            ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).Items.Insert(0, m_lstCommon);

        }
        else
        {
            ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).Items.Clear();
            m_lstCommon = new ListItem("--Select Coverage Code--", "0");
            ((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).Items.Insert(0, m_lstCommon);

        }


    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = false;
        if (fvPolicyDetails.CurrentMode == FormViewMode.Insert)
        {
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objPolicyDetails = new RIMS_Base.Biz.CPolicy();
                if (fvPolicyDetails.CurrentMode == FormViewMode.Insert)
                {
                    m_objPolicyDetails.PK_Policy_Id = 0;
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "lblMsg", "var a=document.getElementById('" + lblMessage.ClientID + "');a.innerText=String.format('Duplicate {0} corrective action found, please correct it.','" + txtLocale.Text + "');alert(a.innerText);", true);
                }
                else
                {
                    m_objPolicyDetails.PK_Policy_Id = Convert.ToInt32(((Label)fvPolicyDetails.FindControl("lblPolicyDetailsId")).Text);
                }
                m_objPolicyDetails.FK_Policy_Type = Convert.ToDecimal(((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).SelectedValue);

                if (((TextBox)fvPolicyDetails.FindControl("txtPolNo")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Policy_Number = ((TextBox)fvPolicyDetails.FindControl("txtPolNo")).Text;
                if (((TextBox)fvPolicyDetails.FindControl("txtNCCI")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.NCCI_Classification_Code = ((TextBox)fvPolicyDetails.FindControl("txtNCCI")).Text;

                m_objPolicyDetails.FK_Coverage_Code = Convert.ToDecimal(((DropDownList)fvPolicyDetails.FindControl("ddlCovCode")).SelectedValue);
                if (((TextBox)fvPolicyDetails.FindControl("txtCarrier")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Carrier = ((TextBox)fvPolicyDetails.FindControl("txtCarrier")).Text;
                if (((TextBox)fvPolicyDetails.FindControl("txtUnderWriter")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Underwriter = ((TextBox)fvPolicyDetails.FindControl("txtUnderWriter")).Text;
                if (((TextBox)fvPolicyDetails.FindControl("txtDtPolBegin")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Policy_Begin_Date = Convert.ToDateTime(((TextBox)fvPolicyDetails.FindControl("txtDtPolBegin")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtDtPolExp")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Policy_Expiration_Date = Convert.ToDateTime(((TextBox)fvPolicyDetails.FindControl("txtDtPolExp")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtStates")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.States_Covered = Request.Form[((TextBox)fvPolicyDetails.FindControl("txtStates")).UniqueID.ToString()].ToString();
                m_objPolicyDetails.FK_Policy_Status = Convert.ToDecimal(((DropDownList)fvPolicyDetails.FindControl("ddlPolStatus")).SelectedValue);
                if (((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Annual_Premium = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtClientId")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Client_Id = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtClientId")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtClientLocCode")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Client_Location_Code = ((TextBox)fvPolicyDetails.FindControl("txtClientLocCode")).Text;
                if (((TextBox)fvPolicyDetails.FindControl("txtDtContEnd")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Contract_End_Date = Convert.ToDateTime(((TextBox)fvPolicyDetails.FindControl("txtDtContEnd")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtDtContEnd")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Contract_Start_Date = Convert.ToDateTime(((TextBox)fvPolicyDetails.FindControl("txtDtContStart")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtContNo")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Contract_Number = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtContNo")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtFedNo")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Employer_Fed_ID_No = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtFedNo")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtEmpSICNo")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Employer_SIC = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtEmpSICNo")).Text);
                m_objPolicyDetails.Deductible = ((RadioButtonList)fvPolicyDetails.FindControl("rdbLstDeduct")).SelectedValue;
                if (((TextBox)fvPolicyDetails.FindControl("txtDivAIG")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Division_AIG = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtDivAIG")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtPolPrefix")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Policy_Prefix = ((TextBox)fvPolicyDetails.FindControl("txtPolPrefix")).Text;
                if (((TextBox)fvPolicyDetails.FindControl("txtISO")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Insured_ISO_Cat = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtISO")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtLayerNo")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Layer_Number = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtLayerNo")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtCovDesc")).Text.Trim() != string.Empty)
                    m_objPolicyDetails.Coverage_Description = ((TextBox)fvPolicyDetails.FindControl("txtCovDesc")).Text;

                m_objPolicyDetails.Updated_By = "1";
                m_objPolicyDetails.Update_Date = System.DateTime.Now.Date;
                m_intRetval = m_objPolicyDetails.InsertUpdate_Policy(m_objPolicyDetails);
                ViewState["PreventAdd"] = "Y";
                ((Label)fvPolicyDetails.FindControl("lblPolicyDetailsId")).Text = m_intRetval.ToString();
            }
            if (m_intRetval >= 0 || ViewState["PreventAdd"].ToString() == "Y")
            {
                dvAttachDetails.Visible = true;

                AddAttachment();
                if (m_intRetval >= 0)
                {
                    //((GridView)fvPolicyDetails.FindControl("gvAttachmentDetails")).DataSource = BindAttachmentDetails();
                    //((GridView)fvPolicyDetails.FindControl("gvAttachmentDetails")).DataBind();
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
                //((GridView)fvPolicyDetails.FindControl("gvAttachmentDetails")).DataSource = BindAttachmentDetails();
                //((GridView)fvPolicyDetails.FindControl("gvAttachmentDetails")).DataBind();
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
    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Policy&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
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
    private List<RIMS_Base.CPolicy> BindPolicyDetails()
    {
        try
        {
            m_objPolicyDetails = new RIMS_Base.Biz.CPolicy();
            lstPolicyDetails = new List<RIMS_Base.CPolicy>();
            lstPolicyDetails = null;
            if (txtSearch.Text != string.Empty)
            {
                lstPolicyDetails = m_objPolicyDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstPolicyDetails = m_objPolicyDetails.GetAll();
            }
            lblPolicyTotal.Text = "Total Policy Details:" + lstPolicyDetails.Count.ToString();
            return lstPolicyDetails;
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
            {
                fvPolicyDetails.ChangeMode(FormViewMode.Insert);
                //((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Attributes.Add("onkeypress", "return check(event," + ((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).ClientID + ");");
            }
            else if (fvMode == FormViewMode.Edit)
                fvPolicyDetails.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvPolicyDetails.ChangeMode(FormViewMode.ReadOnly);
            if (fvMode != FormViewMode.Insert)
            {
                dvAttachDetails.Visible = true;
                m_objPolicyDetails = new RIMS_Base.Biz.CPolicy();
                lstPolicyDetails = new List<RIMS_Base.CPolicy>();
                lstPolicyDetails = m_objPolicyDetails.GetPolicyByID(m_intPolicyDetailsId);
                fvPolicyDetails.DataSource = lstPolicyDetails;
            }
            fvPolicyDetails.DataBind();
            if (fvMode == FormViewMode.Edit || fvMode == FormViewMode.Insert)
                ((Button)fvPolicyDetails.FindControl("btnStates")).Attributes.Add("onclick", "javascript:return openWindowState();");
            //else if(fvMode==FormViewMode.Insert)
            //    ((Button)fvPolicyDetails.FindControl("btnStates")).Attributes.Add("onclick", "javascript:return openWindowState();");
            //((Button)fvPolicyDetails.FindControl("btnAddAttachment")).Attributes.Add("onclick", "return Temp1(" + ((RequiredFieldValidator)fvPolicyDetails.FindControl("rfvAttachType")).ClientID + ");");

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
    /// Get All Policy Type.
    /// </summary>
    private List<RIMS_Base.CPolicy> GetPolicyType()
    {
        try
        {
            m_objPolicyType = new RIMS_Base.Biz.CPolicy();
            lstPolicyType = new List<RIMS_Base.CPolicy>();
            lstPolicyType = m_objPolicyType.GetAllPolicyType();
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
    /// <summary>
    /// Get All Policy Status.
    /// </summary>
    private List<RIMS_Base.CPolicy> GetPolicyStatus()
    {
        try
        {
            m_objPolicyStatus = new RIMS_Base.Biz.CPolicy();
            lstPolicyStatus = new List<RIMS_Base.CPolicy>();
            lstPolicyStatus = m_objPolicyStatus.GetAllPolicyStatus();
            return lstPolicyStatus;
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
    /// Get the Covereage Code when policy type changed.
    /// </summary>
    /// <param name="m_dPolType"></param>
    /// <returns></returns>
    private List<RIMS_Base.CPolicy> GetCoverageCode(System.Decimal m_dPolType)
    {
        try
        {
            m_objCovCode = new RIMS_Base.Biz.CPolicy();
            lstCovCode = new List<RIMS_Base.CPolicy>();
            lstCovCode = m_objCovCode.GetCovCodeByPolType(m_dPolType);
            return lstCovCode;
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
    #region Attachment Detail
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
            lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(((Label)fvPolicyDetails.FindControl("lblPolicyDetailsId")).Text), "Policy");
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
            m_strFileName = GetCustomFileName() + ((FileUpload)fvPolicyDetails.FindControl("uplCommon")).FileName.ToString();
            //m_strPath = m_strPath + "\\" + m_strFolderName + "\\Photos\\" + ufFile.GetName().ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;

            //m_strFileName = ufFile.GetName().ToString();
            ((FileUpload)fvPolicyDetails.FindControl("uplCommon")).SaveAs(m_strPath);


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
            m_objAttachment.Attachment_Table = "Policy";
            m_objAttachment.Foreign_Key = Convert.ToInt32(((Label)fvPolicyDetails.FindControl("lblPolicyDetailsId")).Text);
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvPolicyDetails.FindControl("ddlAttachType")).SelectedValue);
            //m_objAttachment.FK_Attachment_Type = 1;
            m_objAttachment.Attachment_Description = ((TextBox)fvPolicyDetails.FindControl("txtDescription")).Text;
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = "1";
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            m_intRetval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);
            ((TextBox)fvPolicyDetails.FindControl("txtDescription")).Text = string.Empty;
            ((DropDownList)fvPolicyDetails.FindControl("ddlAttachType")).SelectedValue = "0";

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_intRetval;
    }

    #endregion
}
