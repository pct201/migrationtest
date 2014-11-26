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
using ERIMS.DAL;

public partial class Policy_PolicyFeature : clsBasePage
{
    #region Public Variables

    int m_intRetval = -1;
    public RIMS_Base.Biz.CPolicy_Features m_objPolicyFeature;
    public DataSet m_dsCommon;

    #endregion

    #region Event Handler

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mvPolicyDetails.ActiveViewIndex = 0;
            if (!IsPostBack)
            {
                lblPolFId.Text = string.Empty;
                dvAttachDetails.Visible = false;
                ViewState["PreventAdd"] = "N";

                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["Mode"] == "Edit")
                    {
                        fvPolicyDetails.ChangeMode(FormViewMode.Edit);
                    }
                    else if (Request.QueryString["Mode"] == "View")
                    {
                        fvPolicyDetails.ChangeMode(FormViewMode.ReadOnly);
                    }
                    else
                    {
                        fvPolicyDetails.ChangeMode(FormViewMode.Insert);
                    }
                    GetPolicyFeature();
                    fvPolicyDetails.DataSource = m_dsCommon.Tables[0].DefaultView;
                    fvPolicyDetails.DataBind();
                    SetValidations();
                }
                else
                {
                    fvPolicyDetails.ChangeMode(FormViewMode.Insert);
                    SetValidations();
                }
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
                m_objPolicyFeature = new RIMS_Base.Biz.CPolicy_Features();
                if (fvPolicyDetails.CurrentMode == FormViewMode.Insert)
                    m_objPolicyFeature.PK_Policy_Features = 0;
                else
                    m_objPolicyFeature.PK_Policy_Features = Convert.ToInt32(lblPolFId.Text);
                m_objPolicyFeature.Feature = ((TextBox)(fvPolicyDetails.FindControl("txtFeatures"))).Text;
                m_objPolicyFeature.FK_Policy = Convert.ToDecimal(Session["PolicyId"].ToString());
                if (((TextBox)(fvPolicyDetails.FindControl("txtLimit"))).Text != string.Empty)
                    m_objPolicyFeature.Limit = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtLimit"))).Text);
                if (((TextBox)(fvPolicyDetails.FindControl("txtDeductible"))).Text != string.Empty)
                    m_objPolicyFeature.Deductible = Convert.ToDecimal(((TextBox)(fvPolicyDetails.FindControl("txtDeductible"))).Text);

                m_objPolicyFeature.Notes = ((TextBox)(fvPolicyDetails.FindControl("txtDesc"))).Text;
                m_objPolicyFeature.Updated_By = Convert.ToDecimal(Session["UserID"].ToString());
                m_intRetval = m_objPolicyFeature.PolicyFeatures_InsertUpdate(m_objPolicyFeature);
                if (m_intRetval > 0)
                {
                    Session["PolicyMode"] = "Edit";
                    Response.Redirect("FCIPolicy.aspx", false);
                }
            }
            else
            {
                Session["PolicyMode"] = "Edit";
                Response.Redirect("FCIPolicy.aspx", false);
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
            if (Session["PolicyMode"].ToString() != "View")
            {
                Session["PolicyMode"] = "Edit";

            }
            Response.Redirect("FCIPolicy.aspx", false);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void fvPolicyDetails_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvPolicyDetails.CurrentMode == FormViewMode.Insert)
            {
                ((Label)fvPolicyDetails.FindControl("lblPolType")).Text = m_dsCommon.Tables[0].Rows[0]["PolicyType"].ToString();
                ((Label)fvPolicyDetails.FindControl("lblPolNo")).Text = m_dsCommon.Tables[0].Rows[0]["Policy_Number"].ToString();
                ((Label)fvPolicyDetails.FindControl("lblCarrier")).Text = m_dsCommon.Tables[0].Rows[0]["Carrier"].ToString();
                ((Label)fvPolicyDetails.FindControl("lblUnderWriter")).Text = m_dsCommon.Tables[0].Rows[0]["Underwriter"].ToString();
                ((Label)fvPolicyDetails.FindControl("lblDtPolBegin")).Text = Convert.ToDateTime(m_dsCommon.Tables[0].Rows[0]["Policy_Begin_Date"].ToString()).Date.ToString("MM/dd/yyyy");
                ((Label)fvPolicyDetails.FindControl("lblDtPolExp")).Text = Convert.ToDateTime(m_dsCommon.Tables[0].Rows[0]["Policy_Expiration_Date"].ToString()).Date.ToString("MM/dd/yyyy"); ;
                ((Label)fvPolicyDetails.FindControl("lblPolYear")).Text = m_dsCommon.Tables[0].Rows[0]["Policy_Year"].ToString();
            }

            if (fvPolicyDetails.CurrentMode == FormViewMode.Edit || fvPolicyDetails.CurrentMode == FormViewMode.ReadOnly)
            {
                dvAttachDetails.Visible = true;
                lblPolFId.Text = Request.QueryString["PfID"].ToString();
                BindAttachmentDetails(Convert.ToInt32(Request.QueryString["PfID"]), fvPolicyDetails.CurrentMode == FormViewMode.Edit);
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    private DataSet GetPolicyFeature()
    {
        try
        {
            m_objPolicyFeature = new RIMS_Base.Biz.CPolicy_Features();
            m_dsCommon = new DataSet();
            m_dsCommon = m_objPolicyFeature.PolicyFeatures_GetByID(Convert.ToDecimal((Request.QueryString["PfID"])), Convert.ToDecimal(Session["PolicyId"].ToString()));
            return m_dsCommon;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    protected void btnAddAttachment_Click(string str)
    {
        if (fvPolicyDetails.CurrentMode == FormViewMode.Edit)
        {
            AddAttachment(Convert.ToInt32(Request.QueryString["PfID"]));
            BindAttachmentDetails(Convert.ToInt32(Request.QueryString["PfID"]), true);
        }
        if (fvPolicyDetails.CurrentMode == FormViewMode.Insert)
        {
            ClientScript.RegisterStartupScript(this.GetType(), System.DateTime.Now.ToString(), "alert('Please save Policy Feature record first!');", true);
        }
    }

    /// <summary>
    /// Insert Attachment in Database.
    /// </summary>
    /// <returns>Integer</returns>
    private void AddAttachment(int intPK)
    {
        if (fvPolicyDetails.FindControl("Attachment") != null)
            ((Controls_ClaimAttachment_Attachment)fvPolicyDetails.FindControl("Attachment")).Add(clsGeneral.Tables.Policy_Features, intPK);
    }

    /// <summary>
    /// Bind The Attachment Details.
    /// </summary>
    /// <returns></returns>
    private void BindAttachmentDetails(int intPK, bool isRemove)
    {
        if ((fvPolicyDetails.FindControl("AttachmentDetails") != null))
        {
            ((Controls_ClaimAttachment_AttachmentDetails)fvPolicyDetails.FindControl("AttachmentDetails")).InitializeAttachmentDetails(clsGeneral.Tables.Policy_Features, intPK, isRemove, 0);
            ((Controls_ClaimAttachment_AttachmentDetails)fvPolicyDetails.FindControl("AttachmentDetails")).Bind();
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
                case "Policy Features - Feature":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtFeatures")).ClientID + ",";
                    strMessages += "Please enter Feature" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span1")).Style["display"] = "inline-block";
                    break;
                case "Policy Features - Limit":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtLimit")).ClientID + ",";
                    strMessages += "Please enter Limit" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span2")).Style["display"] = "inline-block";
                    break;
                case "Policy Features - Deductible":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtDeductible")).ClientID + ",";
                    strMessages += "Please enter Deductible" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span3")).Style["display"] = "inline-block";
                    break;
                case "Policy Features - Notes":
                    strCtrlsIDs += ((TextBox)fvPolicyDetails.FindControl("txtDesc")).ClientID + ",";
                    strMessages += "Please enter Notes" + ",";
                    ((HtmlControl)fvPolicyDetails.FindControl("Span4")).Style["display"] = "inline-block";
                    break;
            }

            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
}
