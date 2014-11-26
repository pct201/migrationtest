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
using System.IO;
using System.Collections.Generic;
using ERIMS.DAL;
public partial class Policy_FCIPolicy : clsBasePage
{
    #region Public Variables
    int m_intRetval = -1;
    public int m_intPreventAdd = 0;
    public RIMS_Base.Biz.CFCIPolicy m_objPolicyDetails;
    public RIMS_Base.Biz.CFCIPolicy m_objLayer;
    public RIMS_Base.Biz.CGeneral m_objAttachmentType;
    List<RIMS_Base.CGeneral> lstAttachmentType = null;
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    public RIMS_Base.Biz.CPolicy m_objPolicyType;
    List<RIMS_Base.CPolicy> lstPolicyType = null;
    public RIMS_Base.Biz.CGeneral m_objEntity;
    public RIMS_Base.Biz.CPolicy_Features m_objPF;
    ListItem m_lstCommon;
    DataSet m_dsCommon;
    DataSet m_dsPF;
    string strSortExp = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "Policy";
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    DataView dvView = new DataView();
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {

        m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/" + m_strFolderName + "/");
        if (!IsPostBack)
        {
            ViewState["PreventAdd"] = "N";
            mvPolicyDetails.ActiveViewIndex = 0;
            if ((Session["PolicyMode"] != null))
            {

                if (Session["PolicyMode"].ToString() == "Edit")
                {
                    lblPolID.Text = Session["PolicyId"].ToString();
                    fvPolicyDetails.ChangeMode(FormViewMode.Edit);
                    m_dsCommon = new DataSet();
                    m_objPolicyDetails = new RIMS_Base.Biz.CFCIPolicy();
                    m_dsCommon = m_objPolicyDetails.Policy_GetByID(Convert.ToDecimal(lblPolID.Text));
                    fvPolicyDetails.DataSource = m_dsCommon.Tables[0].DefaultView;
                    fvPolicyDetails.DataBind();
                    SetValidations();
                    BindAttachmentDetails(Convert.ToInt32(lblPolID.Text), true);
                    ClientScript.RegisterStartupScript(this.GetType(), System.DateTime.Now.ToString(), "LayerChange();QuotaChange();", true);
                }
                else if (Session["PolicyMode"].ToString() == "View")
                {
                    lblPolID.Text = Session["PolicyId"].ToString();
                    fvPolicyDetails.ChangeMode(FormViewMode.ReadOnly);
                    m_dsCommon = new DataSet();
                    m_objPolicyDetails = new RIMS_Base.Biz.CFCIPolicy();
                    m_dsCommon = m_objPolicyDetails.Policy_GetByID(Convert.ToDecimal(lblPolID.Text));
                    fvPolicyDetails.DataSource = m_dsCommon.Tables[0].DefaultView;
                    fvPolicyDetails.DataBind();
                    BindAttachmentDetails(Convert.ToInt32(lblPolID.Text), false);
                }
                else
                {
                    fvPolicyDetails.ChangeMode(FormViewMode.Insert);
                    SetValidations();
                    BindAttachmentDetails(0, false);
                    ClientScript.RegisterStartupScript(this.GetType(), System.DateTime.Now.ToString(), "LayerChange();QuotaChange();", true);
                }
            }
            else
            {
                fvPolicyDetails.ChangeMode(FormViewMode.Insert);
                SetValidations();
                ClientScript.RegisterStartupScript(this.GetType(), System.DateTime.Now.ToString(), "LayerChange();QuotaChange();", true);
            }
        }

    }
    protected void fvPolicyDetails_DataBound(object sender, EventArgs e)
    {
        if (fvPolicyDetails.CurrentMode != FormViewMode.ReadOnly)
        {
            //((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).DataSource = GetPolicyType();
            //((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).DataTextField = "PolicyTypeFLD_desc";
            //((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).DataValueField = "PolicyTypePK_ID";
            //((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).DataBind();
            m_lstCommon = new ListItem("--Select Policy Type--", "0");
            ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).Items.Insert(0, m_lstCommon);

            ComboHelper.FillLocationdbaOnly(new DropDownList[] { ((DropDownList)fvPolicyDetails.FindControl("ddlLocation")) }, 0, true);

            ComboHelper.FillProgram(new DropDownList[] { ((DropDownList)fvPolicyDetails.FindControl("ddlProgram")) }, true);
            m_objLayer = new RIMS_Base.Biz.CFCIPolicy();

            ((DropDownList)fvPolicyDetails.FindControl("ddlLayerNo")).DataSource = m_objLayer.GetPolicyLayer();
            ((DropDownList)fvPolicyDetails.FindControl("ddlLayerNo")).DataTextField = "FLD_Desc";
            ((DropDownList)fvPolicyDetails.FindControl("ddlLayerNo")).DataValueField = "PK_ID";
            ((DropDownList)fvPolicyDetails.FindControl("ddlLayerNo")).DataBind();
            m_lstCommon = new ListItem("--Select Layer--", "0");
            ((DropDownList)fvPolicyDetails.FindControl("ddlLayerNo")).Items.Insert(0, m_lstCommon);

            System.Web.UI.HtmlControls.HtmlTableRow tr = (System.Web.UI.HtmlControls.HtmlTableRow)fvPolicyDetails.FindControl("trFSR");
            if (((RadioButtonList)fvPolicyDetails.FindControl("rdoFinancial_Security_Required")).SelectedValue == "Y")
            {
                tr.Style.Add("display", "block");
            }
            else
            {
                tr.Style.Add("display", "none");
            }
            RadioButtonList rdo = (RadioButtonList)fvPolicyDetails.FindControl("rdoFinancial_Security_Required");
            rdo.Attributes.Add("onclick", "CheckFSR(this,'" + tr.ID + "');");

        }
        if (fvPolicyDetails.CurrentMode == FormViewMode.Edit)
        {

            ((DropDownList)fvPolicyDetails.FindControl("ddlLocation")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["Fk_Entity"].ToString();
            ((DropDownList)fvPolicyDetails.FindControl("ddlLayerNo")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["Fk_Layer"].ToString();
            ((RadioButtonList)fvPolicyDetails.FindControl("rblDeductible")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["Deductible"].ToString();
            ((RadioButtonList)fvPolicyDetails.FindControl("rdbCF")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["Coverage_Form"].ToString();
            ((RadioButtonList)fvPolicyDetails.FindControl("rdbLayer")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["Layered_Program"].ToString();
            ((RadioButtonList)fvPolicyDetails.FindControl("rdbQuota")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["Quota_Share"].ToString();
            ((RadioButtonList)fvPolicyDetails.FindControl("rdbRetro")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["Retroactive"].ToString();
            ((DropDownList)fvPolicyDetails.FindControl("ddlProgram")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["ProgramID"].ToString();
            ComboHelper.FillPolicyType(new DropDownList[] { ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")) }, Convert.ToDecimal(((DropDownList)fvPolicyDetails.FindControl("ddlProgram")).SelectedValue), true);
            ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["Fk_Policy_Type"].ToString();
            ((RadioButtonList)fvPolicyDetails.FindControl("rdoFinancial_Security_Required")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["Financial_Security_Required"].ToString();
            ((DropDownList)fvPolicyDetails.FindControl("ddlType")).SelectedValue = m_dsCommon.Tables[0].Rows[0]["FK_Financial_Security_Type"].ToString();

            System.Web.UI.HtmlControls.HtmlTableRow tr = (System.Web.UI.HtmlControls.HtmlTableRow)fvPolicyDetails.FindControl("trFSR");
            if (((RadioButtonList)fvPolicyDetails.FindControl("rdoFinancial_Security_Required")).SelectedValue == "Y")
            {
                tr.Style.Add("display", "block");
            }
            else
            {
                tr.Style.Add("display", "none");
            }
            RadioButtonList rdo = (RadioButtonList)fvPolicyDetails.FindControl("rdoFinancial_Security_Required");
            rdo.Attributes.Add("onclick", "CheckFSR(this,'" + tr.ID + "');");



        }
        if (fvPolicyDetails.CurrentMode == FormViewMode.ReadOnly)
        {



            string format = "#,##0.00;-$#,##0.00;Zero";
            decimal Amt = Convert.ToDecimal(((Label)fvPolicyDetails.FindControl("lblAnnPremium")).Text);
            ((Label)fvPolicyDetails.FindControl("lblAnnPremium")).Text = Amt.ToString(format);
            if (((Label)fvPolicyDetails.FindControl("lblDedAmount")).Text != "")
            {
                Amt = Convert.ToDecimal(((Label)fvPolicyDetails.FindControl("lblDedAmount")).Text);
                ((Label)fvPolicyDetails.FindControl("lblDedAmount")).Text = Amt.ToString(format);
            }
            if (((Label)fvPolicyDetails.FindControl("lblPreOccLimit")).Text != "")
            {
                Amt = Convert.ToDecimal(((Label)fvPolicyDetails.FindControl("lblPreOccLimit")).Text);
                ((Label)fvPolicyDetails.FindControl("lblPreOccLimit")).Text = Amt.ToString(format);
            }
            if (((Label)fvPolicyDetails.FindControl("lblAggLimit")).Text != "")
            {
                Amt = Convert.ToDecimal(((Label)fvPolicyDetails.FindControl("lblAggLimit")).Text);
                ((Label)fvPolicyDetails.FindControl("lblAggLimit")).Text = Amt.ToString(format);
            }
            if (((Label)fvPolicyDetails.FindControl("lblUnderlying")).Text != "")
            {
                Amt = Convert.ToDecimal(((Label)fvPolicyDetails.FindControl("lblUnderlying")).Text);
                ((Label)fvPolicyDetails.FindControl("lblUnderlying")).Text = Amt.ToString(format);
            }
            if (((Label)fvPolicyDetails.FindControl("lblShareLimit")).Text != "")
            {
                Amt = Convert.ToDecimal(((Label)fvPolicyDetails.FindControl("lblShareLimit")).Text);
                ((Label)fvPolicyDetails.FindControl("lblShareLimit")).Text = Amt.ToString(format);
            }
            System.Web.UI.HtmlControls.HtmlTableRow tr = (System.Web.UI.HtmlControls.HtmlTableRow)fvPolicyDetails.FindControl("trFSR");
            if (((Label)fvPolicyDetails.FindControl("lblFinancial_Security_Required")).Text != "")
            {
                if (((Label)fvPolicyDetails.FindControl("lblFinancial_Security_Required")).Text == "Yes")
                {
                    tr.Style.Add("display", "block");
                }
                else
                {
                    tr.Style.Add("display", "none");
                }
            }
            Label lblFSR = (Label)fvPolicyDetails.FindControl("lblType");
            if (lblFSR != null)
            {
                if (lblFSR.Text != "")
                {
                    if (lblFSR.Text == "1")
                        lblFSR.Text = "LOC";
                    else if (lblFSR.Text == "2")
                        lblFSR.Text = "Cash";
                    else if (lblFSR.Text == "3")
                        lblFSR.Text = "Other";
                    else
                        lblFSR.Text = "";
                }
            }
        }
        if (fvPolicyDetails.CurrentMode != FormViewMode.Insert)
        {
            BindPolicyFeature();
        }




    }
    protected void lnkPF_Click(object sender, EventArgs e)
    {
        try
        {
            if (fvPolicyDetails.CurrentMode == FormViewMode.Insert || fvPolicyDetails.CurrentMode == FormViewMode.Edit)
            {
                m_objPolicyDetails = new RIMS_Base.Biz.CFCIPolicy();
                if (fvPolicyDetails.CurrentMode == FormViewMode.Insert)
                {
                    m_objPolicyDetails.PK_Policy_Id = 0;

                }
                else
                {
                    m_objPolicyDetails.PK_Policy_Id = Convert.ToInt32(lblPolID.Text);
                }
                m_objPolicyDetails.FK_Policy_Type = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlPolType"))).SelectedValue);
                m_objPolicyDetails.Policy_Number = ((TextBox)fvPolicyDetails.FindControl("txtPolNo")).Text;
                m_objPolicyDetails.Carrier = ((TextBox)fvPolicyDetails.FindControl("txtCarrier")).Text;
                m_objPolicyDetails.Underwriter = ((TextBox)fvPolicyDetails.FindControl("txtUnderWriter")).Text;
                m_objPolicyDetails.Policy_Begin_Date = clsGeneral.FormatDateToStore((TextBox)fvPolicyDetails.FindControl("txtDtPolBegin"));
                m_objPolicyDetails.Policy_Expiration_Date = clsGeneral.FormatDateToStore((TextBox)fvPolicyDetails.FindControl("txtDtPolExp"));
                if (((TextBox)fvPolicyDetails.FindControl("txtPolYear")).Text != string.Empty)
                    m_objPolicyDetails.Policy_Year = Convert.ToInt32(((TextBox)fvPolicyDetails.FindControl("txtPolYear")).Text);
                m_objPolicyDetails.FK_Entity = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlLocation"))).SelectedValue);
                if (((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Text != string.Empty)
                    m_objPolicyDetails.Annual_Premium = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtSLF")).Text != string.Empty)
                    m_objPolicyDetails.Surplus_Lines_Fees = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtSLF")).Text);
                m_objPolicyDetails.Deductible = ((RadioButtonList)fvPolicyDetails.FindControl("rblDeductible")).SelectedValue;
                if (((TextBox)fvPolicyDetails.FindControl("txtDedAmt")).Text != string.Empty)
                    m_objPolicyDetails.Deductible_Amount = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtDedAmt")).Text);
                m_objPolicyDetails.Coverage_Form = ((RadioButtonList)fvPolicyDetails.FindControl("rdbCF")).SelectedValue;
                if (((TextBox)fvPolicyDetails.FindControl("txtPreOccLimit")).Text != string.Empty)
                    m_objPolicyDetails.Per_Occurrence_Limit = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtPreOccLimit")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtAggLimit")).Text != string.Empty)
                    m_objPolicyDetails.Aggregate_Limit = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtAggLimit")).Text);
                m_objPolicyDetails.Layered_Program = ((RadioButtonList)fvPolicyDetails.FindControl("rdbLayer")).SelectedValue;

                if (m_objPolicyDetails.Layered_Program.ToUpper() == "Y")
                {
                    m_objPolicyDetails.FK_Layer = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlLayerNo"))).SelectedValue);

                    if (((TextBox)fvPolicyDetails.FindControl("txtUnderlying")).Text != string.Empty)
                        m_objPolicyDetails.Underlying_Limit = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtUnderlying")).Text);
                }
                else
                    m_objPolicyDetails.FK_Layer = 0;

                m_objPolicyDetails.Quota_Share = ((RadioButtonList)fvPolicyDetails.FindControl("rdbQuota")).SelectedValue;

                if (m_objPolicyDetails.Quota_Share.ToUpper() == "Y")
                {
                    if (((TextBox)fvPolicyDetails.FindControl("txtSharePC")).Text != string.Empty)
                        m_objPolicyDetails.Share_Precentage = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtSharePC")).Text);

                    if (((TextBox)fvPolicyDetails.FindControl("txtShareLimit")).Text != string.Empty)
                        m_objPolicyDetails.Share_Limit = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtShareLimit")).Text);
                }

                m_objPolicyDetails.Retroactive = ((RadioButtonList)fvPolicyDetails.FindControl("rdbRetro")).SelectedValue;
                m_objPolicyDetails.Updated_By = Convert.ToDecimal(clsSession.UserID.ToString());

                m_objPolicyDetails.ProgramID = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlProgram"))).SelectedValue);
                m_objPolicyDetails.TPA = Convert.ToString(((TextBox)(fvPolicyDetails.FindControl("txtTPA"))).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtStore_Deductible")).Text != string.Empty)
                    m_objPolicyDetails.Store_Deductible = Convert.ToDecimal((((TextBox)fvPolicyDetails.FindControl("txtStore_Deductible")).Text));
                m_objPolicyDetails.Financial_Security_Required = Convert.ToString(((RadioButtonList)(fvPolicyDetails.FindControl("rdoFinancial_Security_Required"))).SelectedValue);
                if (m_objPolicyDetails.Financial_Security_Required.ToString() == "Y")
                    m_objPolicyDetails.FK_Financial_Security_Type = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlType"))).SelectedValue);
                else
                    m_objPolicyDetails.FK_Financial_Security_Type = 0;
                m_objPolicyDetails.Policy_Notes = Convert.ToString(((TextBox)((UserControl)(fvPolicyDetails.FindControl("txtPolicy_Notes"))).FindControl("txtNote")).Text);
                if (((TextBox)(fvPolicyDetails.FindControl("txtOriginal_Amount"))).Text != string.Empty)
                    m_objPolicyDetails.Original_Amount = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtOriginal_Amount"))).Text);
                m_objPolicyDetails.Original_Amount_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtOriginal_Amount_Date")));
                if (((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_1"))).Text != string.Empty)
                    m_objPolicyDetails.Change_Amount_1 = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_1"))).Text);
                m_objPolicyDetails.Change_Amount_1_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_1_Date")));
                if (((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_2"))).Text != string.Empty)
                    m_objPolicyDetails.Change_Amount_2 = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_2"))).Text);
                m_objPolicyDetails.Change_Amount_2_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_2_Date")));
                if (((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_3"))).Text != string.Empty)
                    m_objPolicyDetails.Change_Amount_3 = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_3"))).Text);
                m_objPolicyDetails.Change_Amount_3_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_3_Date")));
                if (((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_4"))).Text != string.Empty)
                    m_objPolicyDetails.Change_Amount_4 = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_4"))).Text);
                m_objPolicyDetails.Change_Amount_4_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_4_Date")));
                bool CheckConditions = false;
                //Check duplicate record.
                if (m_objPolicyDetails.Layered_Program == "Y" && m_objPolicyDetails.Quota_Share == "N")
                {
                    int RtnVal = m_objPolicyDetails.PolicyDuplicateCheck(m_objPolicyDetails);
                    if (RtnVal > 0)
                    {
                        CheckConditions = true;
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "alert('Record already exists having same \"Program\",\"Policy Type\",\"Policy Year\" and \"Layer Number\".');", true);
                    }
                }

                //check Shared Percentage condition
                if (m_objPolicyDetails.Layered_Program == "Y" && m_objPolicyDetails.Quota_Share == "Y")
                {
                    int RtnVal = m_objPolicyDetails.CheckSharedPercentagePolicy(m_objPolicyDetails);
                    if (RtnVal > 100)
                    {
                        CheckConditions = true;
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "alert('Total Shared Percentage of the records having same \"Program\",\"Policy Type\",\"Policy Year\" and \"Layer Number\", is more than 100.');", true);
                    }
                }

                if (CheckConditions == false)
                {
                    m_intRetval = m_objPolicyDetails.Policy_InsertUpdate(m_objPolicyDetails);
                    if (m_intRetval >= 0)
                    {
                        Session["PolicyId"] = m_intRetval;
                        Response.Redirect("PolicyFeature.aspx?Mode=Insert&PfID=0", false);
                    }
                }

            }
            else
            {
                Response.Redirect("PolicyFeature.aspx?Mode=Insert&PfID=0", false);
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

            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objPolicyDetails = new RIMS_Base.Biz.CFCIPolicy();
                if (fvPolicyDetails.CurrentMode == FormViewMode.Insert)
                {
                    m_objPolicyDetails.PK_Policy_Id = 0;

                }
                else
                {
                    m_objPolicyDetails.PK_Policy_Id = Convert.ToInt32(lblPolID.Text);
                }
                m_objPolicyDetails.FK_Policy_Type = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlPolType"))).SelectedValue);
                m_objPolicyDetails.Policy_Number = ((TextBox)fvPolicyDetails.FindControl("txtPolNo")).Text;
                m_objPolicyDetails.Carrier = ((TextBox)fvPolicyDetails.FindControl("txtCarrier")).Text;
                m_objPolicyDetails.Underwriter = ((TextBox)fvPolicyDetails.FindControl("txtUnderWriter")).Text;
                m_objPolicyDetails.Policy_Begin_Date = clsGeneral.FormatDateToStore((TextBox)fvPolicyDetails.FindControl("txtDtPolBegin"));
                m_objPolicyDetails.Policy_Expiration_Date = clsGeneral.FormatDateToStore((TextBox)fvPolicyDetails.FindControl("txtDtPolExp"));
                if (((TextBox)fvPolicyDetails.FindControl("txtPolYear")).Text != string.Empty)
                    m_objPolicyDetails.Policy_Year = Convert.ToInt32(((TextBox)fvPolicyDetails.FindControl("txtPolYear")).Text);
                m_objPolicyDetails.FK_Entity = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlLocation"))).SelectedValue);
                if (((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Text != string.Empty)
                    m_objPolicyDetails.Annual_Premium = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtSLF")).Text != string.Empty)
                    m_objPolicyDetails.Surplus_Lines_Fees = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtSLF")).Text);
                m_objPolicyDetails.Deductible = ((RadioButtonList)fvPolicyDetails.FindControl("rblDeductible")).SelectedValue;
                if (((TextBox)fvPolicyDetails.FindControl("txtDedAmt")).Text != string.Empty)
                    m_objPolicyDetails.Deductible_Amount = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtDedAmt")).Text);
                m_objPolicyDetails.Coverage_Form = ((RadioButtonList)fvPolicyDetails.FindControl("rdbCF")).SelectedValue;
                if (((TextBox)fvPolicyDetails.FindControl("txtPreOccLimit")).Text != string.Empty)
                    m_objPolicyDetails.Per_Occurrence_Limit = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtPreOccLimit")).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtAggLimit")).Text != string.Empty)
                    m_objPolicyDetails.Aggregate_Limit = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtAggLimit")).Text);
                m_objPolicyDetails.Layered_Program = ((RadioButtonList)fvPolicyDetails.FindControl("rdbLayer")).SelectedValue;

                if (m_objPolicyDetails.Layered_Program.ToUpper() == "Y")
                {
                    m_objPolicyDetails.FK_Layer = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlLayerNo"))).SelectedValue);

                    if (((TextBox)fvPolicyDetails.FindControl("txtUnderlying")).Text != string.Empty)
                        m_objPolicyDetails.Underlying_Limit = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtUnderlying")).Text);
                }
                else
                    m_objPolicyDetails.FK_Layer = 0;

                m_objPolicyDetails.Quota_Share = ((RadioButtonList)fvPolicyDetails.FindControl("rdbQuota")).SelectedValue;

                if (m_objPolicyDetails.Quota_Share.ToUpper() == "Y")
                {
                    if (((TextBox)fvPolicyDetails.FindControl("txtSharePC")).Text != string.Empty)
                        m_objPolicyDetails.Share_Precentage = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtSharePC")).Text);

                    if (((TextBox)fvPolicyDetails.FindControl("txtShareLimit")).Text != string.Empty)
                        m_objPolicyDetails.Share_Limit = Convert.ToDecimal(((TextBox)fvPolicyDetails.FindControl("txtShareLimit")).Text);
                }

                m_objPolicyDetails.Retroactive = ((RadioButtonList)fvPolicyDetails.FindControl("rdbRetro")).SelectedValue;
                m_objPolicyDetails.Updated_By = Convert.ToDecimal(clsSession.UserID.ToString());

                m_objPolicyDetails.ProgramID = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlProgram"))).SelectedValue);
                m_objPolicyDetails.TPA = Convert.ToString(((TextBox)(fvPolicyDetails.FindControl("txtTPA"))).Text);
                if (((TextBox)fvPolicyDetails.FindControl("txtStore_Deductible")).Text != string.Empty)
                    m_objPolicyDetails.Store_Deductible = Convert.ToDecimal((((TextBox)fvPolicyDetails.FindControl("txtStore_Deductible")).Text));
                m_objPolicyDetails.Financial_Security_Required = Convert.ToString(((RadioButtonList)(fvPolicyDetails.FindControl("rdoFinancial_Security_Required"))).SelectedValue);
                if (m_objPolicyDetails.Financial_Security_Required.ToString() == "Y")
                    m_objPolicyDetails.FK_Financial_Security_Type = Convert.ToDecimal(((DropDownList)(fvPolicyDetails.FindControl("ddlType"))).SelectedValue);
                else
                    m_objPolicyDetails.FK_Financial_Security_Type = 0;
                m_objPolicyDetails.Policy_Notes = Convert.ToString(((TextBox)((UserControl)(fvPolicyDetails.FindControl("txtPolicy_Notes"))).FindControl("txtNote")).Text);
                if (((TextBox)(fvPolicyDetails.FindControl("txtOriginal_Amount"))).Text != string.Empty)
                    m_objPolicyDetails.Original_Amount = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtOriginal_Amount"))).Text);
                m_objPolicyDetails.Original_Amount_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtOriginal_Amount_Date")));
                if (((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_1"))).Text != string.Empty)
                    m_objPolicyDetails.Change_Amount_1 = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_1"))).Text);
                m_objPolicyDetails.Change_Amount_1_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_1_Date")));
                if (((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_2"))).Text != string.Empty)
                    m_objPolicyDetails.Change_Amount_2 = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_2"))).Text);
                m_objPolicyDetails.Change_Amount_2_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_2_Date")));
                if (((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_3"))).Text != string.Empty)
                    m_objPolicyDetails.Change_Amount_3 = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_3"))).Text);
                m_objPolicyDetails.Change_Amount_3_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_3_Date")));
                if (((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_4"))).Text != string.Empty)
                    m_objPolicyDetails.Change_Amount_4 = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_4"))).Text);
                m_objPolicyDetails.Change_Amount_4_Date = clsGeneral.FormatDateToStore((TextBox)(fvPolicyDetails.FindControl("txtChange_Amount_4_Date")));

                bool CheckConditions = false;
                //Check duplicate record.
                if (m_objPolicyDetails.Layered_Program == "Y" && m_objPolicyDetails.Quota_Share == "N")
                {
                    int RtnVal = m_objPolicyDetails.PolicyDuplicateCheck(m_objPolicyDetails);
                    if (RtnVal > 0)
                    {
                        CheckConditions = true;
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "alert('Record already exists having same \"Program\",\"Policy Type\",\"Policy Year\" and \"Layer Number\".');", true);
                    }
                }

                //check Shared Percentage condition
                if (m_objPolicyDetails.Layered_Program == "Y" && m_objPolicyDetails.Quota_Share == "Y")
                {
                    int RtnVal = m_objPolicyDetails.CheckSharedPercentagePolicy(m_objPolicyDetails);
                    if (RtnVal > 100)
                    {
                        CheckConditions = true;
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "alert('Total Shared Percentage of the records having same \"Program\",\"Policy Type\",\"Policy Year\" and \"Layer Number\", is more than 100.');", true);
                    }
                }

                if (CheckConditions == false)
                {
                    m_intRetval = m_objPolicyDetails.Policy_InsertUpdate(m_objPolicyDetails);
                    if (m_intRetval >= 0)
                    {
                        AddAttachment(m_intRetval);
                        Response.Redirect("PolicySearchResult.aspx", false);
                    }
                }
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
            Response.Redirect("PolicySearchResult.aspx", false);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /// <summary>
    /// Add Attachment Button Click Event
    /// </summary>
    /// <param name="str"></param>
    protected void btnAddAttachment_Click(string str)
    {

        if (fvPolicyDetails.CurrentMode == FormViewMode.Edit)
        {
            //Add AttachmentbtnSave

            AddAttachment(Convert.ToInt32(lblPolID.Text));
            BindAttachmentDetails(Convert.ToInt32(lblPolID.Text), true);
        }
        if (fvPolicyDetails.CurrentMode == FormViewMode.Insert)
        {
            ClientScript.RegisterStartupScript(this.GetType(), System.DateTime.Now.ToString(), "alert('First Save Policy!');", true);
        }
    }

    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFeatures_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataSet m_dsTemp = new DataSet();
            m_objPF = new RIMS_Base.Biz.CPolicy_Features();

            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Descending;
            // Changes the sort direction 
            else
            {
                if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                    ViewState["sortDirection"] = SortDirection.Descending;
                else
                    ViewState["sortDirection"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = strSortExp = e.SortExpression;
            m_dsTemp = m_objPF.PolicyFeatures_ByPolicyID(Convert.ToDecimal(Session["PolicyId"].ToString()));
            dvView = m_dsTemp.Tables[0].DefaultView;
            if (ViewState["SortExp"] != null)
            {
                if (ViewState["sortDirection"].ToString() == "Descending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Desc";
                if (ViewState["sortDirection"].ToString() == "Ascending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Asc";
            }
            ((GridView)fvPolicyDetails.FindControl("gvFeatures")).DataSource = dvView;
            ((GridView)fvPolicyDetails.FindControl("gvFeatures")).DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
   /// <summary>
   /// Row Created Event
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void gvFeatures_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp || ViewState["SortExp"] != null)
            {
                AddSortImage(e.Row);
            }
            else
            {
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[0].Controls.Add(sortImage);
            }
        }
    }
    /// <summary>
    /// Selected Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlProgram = (DropDownList)sender;
        ComboHelper.FillPolicyType(new DropDownList[] { ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")) }, Convert.ToDecimal(ddlProgram.SelectedValue), true);
        ClientScript.RegisterStartupScript(this.GetType(), System.DateTime.Now.ToString(), "LayerChange();QuotaChange();", true);
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void gvFeatures_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Remove")
            {
                m_objPF = new RIMS_Base.Biz.CPolicy_Features();
                m_objPF.PolicyFeatures_Delete(Convert.ToDecimal(e.CommandArgument.ToString()));
                BindPolicyFeature();
            }

        }
        catch { throw; }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in ((GridView)fvPolicyDetails.FindControl("gvFeatures")).Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = ((GridView)fvPolicyDetails.FindControl("gvFeatures")).Columns.IndexOf(field);
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
    private void BindPolicyFeature()
    {
        try
        {
            m_objPF = new RIMS_Base.Biz.CPolicy_Features();
            m_dsPF = new DataSet();
            m_dsPF = m_objPF.PolicyFeatures_ByPolicyID(Convert.ToDecimal(Session["PolicyId"].ToString()));
            ((GridView)fvPolicyDetails.FindControl("gvFeatures")).DataSource = m_dsPF.Tables[0].DefaultView;
            ((GridView)fvPolicyDetails.FindControl("gvFeatures")).DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        DataTable dtFields = clsScreen_Validators.SelectByScreen(95).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        string strCtrlsIDs = "";
        string strMessages = "";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "

            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Program":
                    strCtrlsIDs += ((DropDownList)fvPolicyDetails.FindControl("ddlProgram")).ClientID + ",";
                    strMessages += "Please select Program" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span1")).Style["display"] = "inline-block";
                    break;
                case "Policy Type":
                    strCtrlsIDs += ((DropDownList)fvPolicyDetails.FindControl("ddlPolType")).ClientID + ",";
                    strMessages += "Please select Policy Type" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span2")).Style["display"] = "inline-block";
                    break;
                case "Insurance Carrier":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtCarrier")).ClientID + ",";
                    strMessages += "Please enter Insurance Carrier" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span3")).Style["display"] = "inline-block";
                    break;
                case "Underwriter":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtUnderWriter")).ClientID + ",";
                    strMessages += "Please enter Underwriter" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span4")).Style["display"] = "inline-block";
                    break;
                case "TPA":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtTPA")).ClientID + ",";
                    strMessages += "Please enter TPA" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span5")).Style["display"] = "inline-block";
                    break;
                case "Policy Number":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtPolNo")).ClientID + ",";
                    strMessages += "Please enter Policy Number" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span6")).Style["display"] = "inline-block";
                    break;
                case "Policy Effective Date":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtDtPolBegin")).ClientID + ",";
                    strMessages += "Please enter Policy Effective Date" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span7")).Style["display"] = "inline-block";
                    break;
                case "Policy Expiration Date":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtDtPolExp")).ClientID + ",";
                    strMessages += "Please enter Policy Expiration Date" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span8")).Style["display"] = "inline-block";
                    break;
                case "Policy Year":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtPolYear")).ClientID + ",";
                    strMessages += "Please enter Policy Year" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span9")).Style["display"] = "inline-block";
                    break;
                case "Location":
                    strCtrlsIDs += ((DropDownList)fvPolicyDetails.FindControl("ddlLocation")).ClientID + ",";
                    strMessages += "Please select Location" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span10")).Style["display"] = "inline-block";
                    break;
                case "Annual Premium":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtPolAnnPremium")).ClientID + ",";
                    strMessages += "Please enter Annual Premium" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span11")).Style["display"] = "inline-block";
                    break;
                case "Surplus Lines Fees":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtSLF")).ClientID + ",";
                    strMessages += "Please enter Surplus Lines Fees" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span12")).Style["display"] = "inline-block";
                    break;            
                case "Deductible Amount":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtDedAmt")).ClientID + ",";
                    strMessages += "Please enter Deductible Amount" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span14")).Style["display"] = "inline-block";
                    break;            
                case "Store Deductible":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtStore_Deductible")).ClientID + ",";
                    strMessages += "Please enter Store Deductible" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span16")).Style["display"] = "inline-block";
                    break;
                case "Per Occurrence Limit":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtPreOccLimit")).ClientID + ",";
                    strMessages += "Please enter Per Occurrence Limit" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span17")).Style["display"] = "inline-block";
                    break;
                case "Aggregate Limit":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtAggLimit")).ClientID + ",";
                    strMessages += "Please enter Aggregate Limit" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span18")).Style["display"] = "inline-block";
                    break;              
                case "If Layered, Layer Number":
                    strCtrlsIDs += ((DropDownList)fvPolicyDetails.FindControl("ddlLayerNo")).ClientID + ",";
                    strMessages += "Please select If Layered- Layer Number" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span20")).Style["display"] = "inline-block";
                    break;
                case "Underlying Limit":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtUnderlying")).ClientID + ",";
                    strMessages += "Please enter Underlying Limit" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span21")).Style["display"] = "inline-block";
                    break;              
                case "Share Percentage":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtSharePC")).ClientID + ",";
                    strMessages += "Please enter Share Percentage" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span23")).Style["display"] = "inline-block";
                    break;
                case "Share Limit":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtShareLimit")).ClientID + ",";
                    strMessages += "Please enter Share Limit" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span24")).Style["display"] = "inline-block";
                    break;              
                case "Original Amount":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtOriginal_Amount")).ClientID + ",";
                    strMessages += "Please enter Original Amount" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span27")).Style["display"] = "inline-block";
                    break;
                case "Original Amount Date":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtOriginal_Amount_Date")).ClientID + ",";
                    strMessages += "Please enter Original Amount Date" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span28")).Style["display"] = "inline-block";
                    break;
                case "Change Amount 1":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtChange_Amount_1")).ClientID + ",";
                    strMessages += "Please enter Change Amount 1" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span29")).Style["display"] = "inline-block";
                    break;
                case "Change Amount Date 1":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtChange_Amount_1_Date")).ClientID + ",";
                    strMessages += "Please enter Change Amount Date 1" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span30")).Style["display"] = "inline-block";
                    break;
                case "Change Amount 2":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtChange_Amount_2")).ClientID + ",";
                    strMessages += "Please enter Change Amount 2" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span31")).Style["display"] = "inline-block";
                    break;
                case "Change Amount Date 2":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtChange_Amount_2_Date")).ClientID + ",";
                    strMessages += "Please enter Change Amount Date 2" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span32")).Style["display"] = "inline-block";
                    break;
                case "Change Amount 3":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtChange_Amount_3")).ClientID + ",";
                    strMessages += "Please enter Change Amount 3" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span33")).Style["display"] = "inline-block";
                    break;
                case "Change Amount Date 3":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtChange_Amount_3_Date")).ClientID + ",";
                    strMessages += "Please enter Change Amount Date 3" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span34")).Style["display"] = "inline-block";
                    break;
                case "Change Amount 4":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtChange_Amount_4")).ClientID + ",";
                    strMessages += "Please enter Change Amount 4" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span35")).Style["display"] = "inline-block";
                    break;
                case "Change Amount Date 4":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtChange_Amount_4_Date")).ClientID + ",";
                    strMessages += "Please enter Change Amount Date 4" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span36")).Style["display"] = "inline-block";
                    break;
                case "Policy Notes":   
                    strCtrlsIDs += ((TextBox)((UserControl)(fvPolicyDetails.FindControl("txtPolicy_Notes"))).FindControl("txtNote")).ClientID + ",";
                    strMessages += "Please enter Policy Notes" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span37")).Style["display"] = "inline-block";
                    break;
                case "Type":
                    strCtrlsIDs += ((DropDownList)fvPolicyDetails.FindControl("ddlType")).ClientID + ",";
                    strMessages += "Please select Type" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span38")).Style["display"] = "inline-block";
                    break;
            }

            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion
    #region Attachment Detail
    /// <summary>
    /// Bind The Attachment Details.
    /// </summary>
    /// <returns></returns>
    private void BindAttachmentDetails(int intPK, bool isRemove)
    {
        if ((fvPolicyDetails.FindControl("AttachmentDetails") != null))
        {
            ((Controls_ClaimAttachment_AttachmentDetails)fvPolicyDetails.FindControl("AttachmentDetails")).InitializeAttachmentDetails(clsGeneral.Tables.Policy, intPK, isRemove, 0);
            ((Controls_ClaimAttachment_AttachmentDetails)fvPolicyDetails.FindControl("AttachmentDetails")).Bind();
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
    private void AddAttachment(int intPK)
    {
        if (fvPolicyDetails.FindControl("Attachment") != null)
            ((Controls_ClaimAttachment_Attachment)fvPolicyDetails.FindControl("Attachment")).Add(clsGeneral.Tables.Policy, intPK);
    }

    #endregion
}
