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
using System.IO;

public partial class Liability_LiabilityClaim : System.Web.UI.Page
{
    #region Private Variables

    public RIMS_Base.Biz.CLiabilityClaim objliability;
    List<RIMS_Base.CLiabilityClaim> lstliability, lstproperty, lstEmp, lstEmpAssign, lstCostCenter, lstCliamant;
    public RIMS_Base.Biz.CGeneral objGeneral;
    int m_intRetval = -1;

    // -- Attachment
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "Liability_Claim";
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    int Attach_Retval = -1;


  #endregion

    #region Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString["Liability"] == "Automobile")
            {
                Session["WorkerCompID"] = null;
                Automobile.Style["display"] = "block";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";
                // btnsave.Attributes.Add("onclick", "javascript:return Reqenabletrue()();");
                Session["ClaimType"] = Request.QueryString["Liability"].ToString();
            }
            else if (Request.QueryString["Liability"] == "General")
            {
                Session["WorkerCompID"] = null;
                General.Style["display"] = "block";
                Property.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                leftDiv.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                btnsave.Attributes.Add("onclick", "javascript:Reqenablefalse();");
                Session["ClaimType"] = Request.QueryString["Liability"].ToString();
            }
            else if (Request.QueryString["Liability"] == "PropertyLoss")
            {
                Session["WorkerCompID"] = null;
                Property.Style["display"] = "block";
                General.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                leftDiv.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                btnsave.Attributes.Add("onclick", "javascript:Reqenablefalse();");
                Session["ClaimType"] = Request.QueryString["Liability"].ToString();
            }
            else
            {

                Automobile.Style["display"] = "block";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";

            }
        }

        else
        {
            objliability = new CLiabilityClaim();
            lstliability = new List<RIMS_Base.CLiabilityClaim>();
            lstliability = objliability.Getility_ClaimByID(Convert.ToInt32(Session["WorkerCompID"]));
            if (lstliability[0].FK_Liability_Major_Claim_Type == 1)
            {
                Automobile.Style["display"] = "block";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";
                Session["ClaimType"] = "Automobile";
            }
            else if (lstliability[0].FK_Liability_Major_Claim_Type == 2)
            {
                General.Style["display"] = "block";
                Property.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                leftDiv.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                btnsave.Attributes.Add("onclick", "javascript:Reqenablefalse();");
                Session["ClaimType"] = "General";
            }
            else if (lstliability[0].FK_Liability_Major_Claim_Type == 3)
            {
                Property.Style["display"] = "block";
                General.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                leftDiv.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                btnsave.Attributes.Add("onclick", "javascript:Reqenablefalse();");
                Session["ClaimType"] = "PropertyLoss";
            }

        }

        m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Liability_Claim/");
        if (!IsPostBack)
        {
          
            btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");
            ViewState.Clear();
            dispTagName.Value = "";
            BindCombo();

            gvAttachmentDetails.DataSource = lstAttachment;
            gvAttachmentDetails.DataBind();

            if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
            {
                ViewState["PK_Liability_Claim"] = Session["WorkerCompID"].ToString();

                if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                    ViewAllFromSearchGrid();
              else
                   RetriveDataByID();

            }


          
        }

           
        txthomephone.Attributes.Add("onfocusout", "phoneValidate(this.id)");
        txthomephone.Attributes.Add("onKeyUp", "return PhoneMasking(event,this.value,this);");
        txthomephone.Attributes.Add("onFocus", "return OnRPhoneFocus(this);");
        txthomephone.Attributes.Add("onBlur", "return OnPrBlur(this);");
        txthomephone.Attributes.Add("onKeyPress", "return CheckNum(this);");

        txtworkphone.Attributes.Add("onfocusout", "phoneValidate(this.id)");
        txtworkphone.Attributes.Add("onKeyUp", "return PhoneMasking(event,this.value,this);");
        txtworkphone.Attributes.Add("onFocus", "return OnRPhoneFocus(this);");
        txtworkphone.Attributes.Add("onBlur", "return OnPrBlur(this);");
        txtworkphone.Attributes.Add("onKeyPress", "return CheckNum(this);");

     
        txtpolicephone.Attributes.Add("onfocusout", "phoneValidate(this.id)");
        txtpolicephone.Attributes.Add("onKeyUp", "return PhoneMasking(event,this.value,this);");
        txtpolicephone.Attributes.Add("onFocus", "return OnRPhoneFocus(this);");
        txtpolicephone.Attributes.Add("onBlur", "return OnPrBlur(this);");
        txtpolicephone.Attributes.Add("onKeyPress", "return CheckNum(this);");


        txtsecdriverphone.Attributes.Add("onfocusout", "phoneValidate(this.id)");
        txtsecdriverphone.Attributes.Add("onKeyUp", "return PhoneMasking(event,this.value,this);");
        txtsecdriverphone.Attributes.Add("onFocus", "return OnRPhoneFocus(this);");
        txtsecdriverphone.Attributes.Add("onBlur", "return OnPrBlur(this);");
        txtsecdriverphone.Attributes.Add("onKeyPress", "return CheckNum(this);");

      
        txtclientattophone.Attributes.Add("onfocusout", "phoneValidate(this.id)");
        txtclientattophone.Attributes.Add("onKeyUp", "return PhoneMasking(event,this.value,this);");
        txtclientattophone.Attributes.Add("onFocus", "return OnRPhoneFocus(this);");
        txtclientattophone.Attributes.Add("onBlur", "return OnPrBlur(this);");
        txtclientattophone.Attributes.Add("onKeyPress", "return CheckNum(this);");

        txtdefeattphone.Attributes.Add("onfocusout", "phoneValidate(this.id)");
        txtdefeattphone.Attributes.Add("onKeyUp", "return PhoneMasking(event,this.value,this);");
        txtdefeattphone.Attributes.Add("onFocus", "return OnRPhoneFocus(this);");
        txtdefeattphone.Attributes.Add("onBlur", "return OnPrBlur(this);");
        txtdefeattphone.Attributes.Add("onKeyPress", "return CheckNum(this);");

        txtdefeattFasc.Attributes.Add("onfocusout", "phoneValidate(this.id)");
        txtdefeattFasc.Attributes.Add("onKeyUp", "return PhoneMasking(event,this.value,this);");
        txtdefeattFasc.Attributes.Add("onFocus", "return OnRPhoneFocus(this);");
        txtdefeattFasc.Attributes.Add("onBlur", "return OnPrBlur(this);");
        txtdefeattFasc.Attributes.Add("onKeyPress", "return CheckNum(this);");

        txtclientattoFasc.Attributes.Add("onfocusout", "phoneValidate(this.id)");
        txtclientattoFasc.Attributes.Add("onKeyUp", "return PhoneMasking(event,this.value,this);");
        txtclientattoFasc.Attributes.Add("onFocus", "return OnRPhoneFocus(this);");
        txtclientattoFasc.Attributes.Add("onBlur", "return OnPrBlur(this);");
        txtclientattoFasc.Attributes.Add("onKeyPress", "return CheckNum(this);");

        txtzipcode.Attributes.Add("onKeyPress", "isValid(this)");
        txtdefeattozip.Attributes.Add("onKeyPress", "isValid(this)");
        txtclientattozip.Attributes.Add("onKeyPress", "isValid(this)");
        txtsecdriverzip.Attributes.Add("onKeyPress", "isValid(this)");
        txtpoliceZipcode.Attributes.Add("onKeyPress", "isValid(this)");
        txtsecdriverzip.Attributes.Add("onKeyPress", "isValid(this)");
        txtzipproperty.Attributes.Add("onKeyPress", "isValid(this)");

        txtpercentFlood.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentwindproloss1.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentfireproloss1.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentother1.Attributes.Add("onKeyPress", "isValid(this)");



        txtpercentflood2.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentwind2.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentfire2.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentother2.Attributes.Add("onKeyPress", "isValid(this)");

        txtpercentflood3.Attributes.Add("onKeyPress", "isValid(this)");
        //txtpercentwindproloss1.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentWind3.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentfire3.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentother3.Attributes.Add("onKeyPress", "isValid(this)");

        txtpercentflood4.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentWind4.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentfire4.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentother4.Attributes.Add("onKeyPress", "isValid(this)");

        txtpercentflood5.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentwind5.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentfire5.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentother5.Attributes.Add("onKeyPress", "isValid(this)");

        txtpercentFlood6.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentWind6.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentFire6.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentOther6.Attributes.Add("onKeyPress", "isValid(this)");

        txtpercentFlood7.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentWind7.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentFire7.Attributes.Add("onKeyPress", "isValid(this)");
        txtpercentOther7.Attributes.Add("onKeyPress", "isValid(this)");


        txtnoofweekssch.Attributes.Add("onKeyPress", "isValid(this)");
        txtyearofmenu.Attributes.Add("onKeyPress", "isValid(this)");
        txtdriverage.Attributes.Add("onKeyPress", "isValid(this)");

        txtzipcode.Attributes.Add("onfocusout", "ZipValidate(this.id)");
        txtdefeattozip.Attributes.Add("onfocusout", "ZipValidate(this.id)");
        txtclientattozip.Attributes.Add("onfocusout", "ZipValidate(this.id)");
        txtsecdriverzip.Attributes.Add("onfocusout", "ZipValidate(this.id)");
        txtpoliceZipcode.Attributes.Add("onfocusout", "ZipValidate(this.id)");
        txtsecdriverzip.Attributes.Add("onfocusout", "ZipValidate(this.id)");
        txtzipproperty.Attributes.Add("onfocusout", "ZipValidate(this.id)");





    }
    protected void Next_Click1(object sender, EventArgs e)
    {
        InsertData();
        Response.Redirect("ReserveWorksheetHistoryGrid.aspx");
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString["Liability"] == "Automobile")
            {

                Automobile.Style["display"] = "none";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";

                viewdivfirst.Style["display"] = "block";
                viewdivsecond.Style["display"] = "block";
                viewdivthird.Style["display"] = "block";
                viewdivfour.Style["display"] = "none";
                viewdivfive.Style["display"] = "none";
                viewdivsix.Style["display"] = "none";
                viewdivseven.Style["display"] = "none";
                viewdiveight.Style["display"] = "block";
                viewdivnine.Style["display"] = "block";
                divviewAttach.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                mainContent.Style["display"] = "none";

                ViewDiv.Style["display"] = "block";

                InsertData();
                ViewData();
            }
            else if (Request.QueryString["Liability"] == "General")
            {
                Automobile.Style["display"] = "none";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";

                ViewDiv.Style["display"] = "block";
                viewdivfirst.Style["display"] = "block";
                viewdivsecond.Style["display"] = "block";
                viewdivthird.Style["display"] = "block";
                viewdivfour.Style["display"] = "none";
                viewdivfive.Style["display"] = "none";
                viewdivsix.Style["display"] = "none";
                viewdivseven.Style["display"] = "none";
                viewdiveight.Style["display"] = "none";
                viewdivnine.Style["display"] = "block";
                divviewAttach.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                mainContent.Style["display"] = "none";
                InsertData();
                ViewData();
            }
            else if (Request.QueryString["Liability"] == "PropertyLoss")
            {
                viewdivfirst.Style["display"] = "block";
                viewdivsecond.Style["display"] = "block";
                viewdivthird.Style["display"] = "block";
                viewdivfour.Style["display"] = "block";
                viewdivfive.Style["display"] = "block";
                viewdivsix.Style["display"] = "block";
                viewdivseven.Style["display"] = "block";
                viewdiveight.Style["display"] = "none";
                viewdivnine.Style["display"] = "block";
                divviewAttach.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                mainContent.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";
                ViewDiv.Style["display"] = "block";

                InsertData();
                ViewData();
            }
        }
            else
        {   
            objliability = new CLiabilityClaim();
            lstliability = new List<RIMS_Base.CLiabilityClaim>();
            lstliability = objliability.Getility_ClaimByID(Convert.ToInt32(Session["WorkerCompID"]));
            if (lstliability[0].FK_Liability_Major_Claim_Type == 1)
            {

                Automobile.Style["display"] = "none";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";

                viewdivfirst.Style["display"] = "block";
                viewdivsecond.Style["display"] = "block";
                viewdivthird.Style["display"] = "block";
                viewdivfour.Style["display"] = "none";
                viewdivfive.Style["display"] = "none";
                viewdivsix.Style["display"] = "none";
                viewdivseven.Style["display"] = "none";
                viewdiveight.Style["display"] = "block";
                viewdivnine.Style["display"] = "block";
                divviewAttach.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                mainContent.Style["display"] = "none";

                ViewDiv.Style["display"] = "block";

                InsertData();
                ViewData();

            }

            else if (lstliability[0].FK_Liability_Major_Claim_Type == 2)
            {

                Automobile.Style["display"] = "none";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";

                ViewDiv.Style["display"] = "block";
                viewdivfirst.Style["display"] = "block";
                viewdivsecond.Style["display"] = "block";
                viewdivthird.Style["display"] = "block";
                viewdivfour.Style["display"] = "none";
                viewdivfive.Style["display"] = "none";
                viewdivsix.Style["display"] = "none";
                viewdivseven.Style["display"] = "none";
                viewdiveight.Style["display"] = "none";
                viewdivnine.Style["display"] = "block";
                divviewAttach.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                mainContent.Style["display"] = "none";
                InsertData();
                ViewData();
            }

            else if (lstliability[0].FK_Liability_Major_Claim_Type == 3)
            {

                viewdivfirst.Style["display"] = "block";
                viewdivsecond.Style["display"] = "block";
                viewdivthird.Style["display"] = "block";
                viewdivfour.Style["display"] = "block";
                viewdivfive.Style["display"] = "block";
                viewdivsix.Style["display"] = "block";
                viewdivseven.Style["display"] = "block";
                viewdiveight.Style["display"] = "none";
                viewdivnine.Style["display"] = "block";
                divviewAttach.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                mainContent.Style["display"] = "none";
                Automobile.Style["display"] = "none";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";
                ViewDiv.Style["display"] = "block";


                InsertData();
                ViewData();

            }
           
        }
        btnViewNext.Visible = false;
        btnBack.Visible = true;

        
        //dvAttachDetails.Style["display"] = "none";
        //divfirst.Style["display"] = "none";
        //divsecond.Style["display"] = "none";
        //divthird.Style["display"] = "none";
        //divfour.Style["display"] = "none";
        //divfive.Style["display"] = "none";
        //divsix.Style["display"] = "none";
        //divseven.Style["display"] = "none";
        //diveight.Style["display"] = "none";
        //divnine.Style["display"] = "none";
        //divten.Style["display"] = "none";
        //leftDiv.Style["display"] = "none";
        //ViewDiv.Style["display"] = "block";
        //divbtn.Style["display"] = "none";
        //mainContent.Style["display"] = "none";
       
      
    }
    protected void gvAttachView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
              //  ((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Liability_Claim&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }
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
                    btnRemove.Visible = true;
                else
                    btnRemove.Visible = false;
            }
            dvAttachDetails.Visible = true;
            dvAttachDetails.Style["display"] = "block";
            divfirst.Style["display"] = "none";
            divsecond.Style["display"] = "none";
            divthird.Style["display"] = "none";
            divfour.Style["display"] = "none";
            divfive.Style["display"] = "none";
            divsix.Style["display"] = "none";
            divseven.Style["display"] = "none";
            diveight.Style["display"] = "none";
            divnine.Style["display"] = "none";
            divten.Style["display"] = "block";
            ViewDiv.Style["display"] = "none";
            leftDiv.Style["display"] = "none";

            // --- highlight the third menu of the Left side.
            dispTagName.Value = "divten";
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
               // ((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Liability_Claim&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Add_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {

            if (Request.QueryString["Liability"] == "Automobile")
            {

                dvAttachDetails.Style["display"] = "block";
                divfirst.Style["display"] = "none";
                divsecond.Style["display"] = "none";
                divthird.Style["display"] = "none";
                divfour.Style["display"] = "none";
                divfive.Style["display"] = "none";
                divsix.Style["display"] = "none";
                divseven.Style["display"] = "none";
                diveight.Style["display"] = "none";
                divnine.Style["display"] = "none";
                divten.Style["display"] = "block";
                leftDiv.Style["display"] = "none";
                ViewDiv.Style["display"] = "none";
                btnRemove.Visible = true;
                AddAttachment();
                if (Attach_Retval > 0)
                {
                    gvAttachmentDetails.DataSource = BindAttachmentDetails();
                    gvAttachmentDetails.DataBind();

                }
                dispTagName.Value = "divten";
                txtAttachDesc.Text = "";
                ddlAttachType.SelectedIndex = 0;
                // btnsave.Attributes.Add("onclick", "javascript:return Reqenabletrue()();");
            }
            else if (Request.QueryString["Liability"] == "General")
            {
                dvAttachDetails.Style["display"] = "block";
                divfirst.Style["display"] = "none";
                divsecond.Style["display"] = "none";
                divthird.Style["display"] = "none";
                divfour.Style["display"] = "none";
                divfive.Style["display"] = "none";
                divsix.Style["display"] = "none";
                divseven.Style["display"] = "none";
                diveight.Style["display"] = "none";
                divnine.Style["display"] = "none";
                divten.Style["display"] = "block";
                leftDiv.Style["display"] = "none";
                ViewDiv.Style["display"] = "none";
                btnRemove.Visible = true;
                AddAttachment();
                if (Attach_Retval > 0)
                {
                    gvAttachmentDetails.DataSource = BindAttachmentDetails();
                    gvAttachmentDetails.DataBind();

                }
                dispTagName.Value = "divten";
                txtAttachDesc.Text = "";
                ddlAttachType.SelectedIndex = 0;
                btnsave.Attributes.Add("onclick", "javascript:Reqenablefalse();");
            }
            else if (Request.QueryString["Liability"] == "PropertyLoss")
            {
                dvAttachDetails.Style["display"] = "block";
                divfirst.Style["display"] = "none";
                divsecond.Style["display"] = "none";
                divthird.Style["display"] = "none";
                divfour.Style["display"] = "none";
                divfive.Style["display"] = "none";
                divsix.Style["display"] = "none";
                divseven.Style["display"] = "none";
                diveight.Style["display"] = "none";
                divnine.Style["display"] = "none";
                divten.Style["display"] = "block";
                //  leftDiv.Style["display"] = "none";
                ViewDiv.Style["display"] = "none";
                btnRemove.Visible = true;
                AddAttachment();
                if (Attach_Retval > 0)
                {
                    gvAttachmentDetails.DataSource = BindAttachmentDetails();
                    gvAttachmentDetails.DataBind();

                }
                dispTagName.Value = "divten";
                txtAttachDesc.Text = "";
                ddlAttachType.SelectedIndex = 0;
                btnsave.Attributes.Add("onclick", "javascript:Reqenablefalse();");
            }
        }
            else
            {
                objliability = new CLiabilityClaim();
                lstliability = new List<RIMS_Base.CLiabilityClaim>();
                lstliability = objliability.Getility_ClaimByID(Convert.ToInt32(Session["WorkerCompID"]));
                if (lstliability[0].FK_Liability_Major_Claim_Type == 1)
                {

                    dvAttachDetails.Style["display"] = "block";
                    divfirst.Style["display"] = "none";
                    divsecond.Style["display"] = "none";
                    divthird.Style["display"] = "none";
                    divfour.Style["display"] = "none";
                    divfive.Style["display"] = "none";
                    divsix.Style["display"] = "none";
                    divseven.Style["display"] = "none";
                    diveight.Style["display"] = "none";
                    divnine.Style["display"] = "none";
                    divten.Style["display"] = "block";
                    leftDiv.Style["display"] = "none";
                    ViewDiv.Style["display"] = "none";
                    btnRemove.Visible = true;
                    AddAttachment();
                    if (Attach_Retval > 0)
                    {
                        gvAttachmentDetails.DataSource = BindAttachmentDetails();
                        gvAttachmentDetails.DataBind();

                    }
                    dispTagName.Value = "divten";
                    txtAttachDesc.Text = "";
                    ddlAttachType.SelectedIndex = 0;
                }


                else if (Request.QueryString["Liability"] == "General")
                {
                    dvAttachDetails.Style["display"] = "block";
                    divfirst.Style["display"] = "none";
                    divsecond.Style["display"] = "none";
                    divthird.Style["display"] = "none";
                    divfour.Style["display"] = "none";
                    divfive.Style["display"] = "none";
                    divsix.Style["display"] = "none";
                    divseven.Style["display"] = "none";
                    diveight.Style["display"] = "none";
                    divnine.Style["display"] = "none";
                    divten.Style["display"] = "block";
                    leftDiv.Style["display"] = "none";
                    ViewDiv.Style["display"] = "none";
                    btnRemove.Visible = true;
                    AddAttachment();
                    if (Attach_Retval > 0)
                    {
                        gvAttachmentDetails.DataSource = BindAttachmentDetails();
                        gvAttachmentDetails.DataBind();

                    }
                    dispTagName.Value = "divten";
                    txtAttachDesc.Text = "";
                    ddlAttachType.SelectedIndex = 0;
                    btnsave.Attributes.Add("onclick", "javascript:Reqenablefalse();");
                }
                else if (Request.QueryString["Liability"] == "PropertyLoss")
                {
                    dvAttachDetails.Style["display"] = "block";
                    divfirst.Style["display"] = "none";
                    divsecond.Style["display"] = "none";
                    divthird.Style["display"] = "none";
                    divfour.Style["display"] = "none";
                    divfive.Style["display"] = "none";
                    divsix.Style["display"] = "none";
                    divseven.Style["display"] = "none";
                    diveight.Style["display"] = "none";
                    divnine.Style["display"] = "none";
                    divten.Style["display"] = "block";
                    //  leftDiv.Style["display"] = "none";
                    ViewDiv.Style["display"] = "none";
                    btnRemove.Visible = true;
                    AddAttachment();
                    if (Attach_Retval > 0)
                    {
                        gvAttachmentDetails.DataSource = BindAttachmentDetails();
                        gvAttachmentDetails.DataBind();

                    }
                    dispTagName.Value = "divten";
                    txtAttachDesc.Text = "";
                    ddlAttachType.SelectedIndex = 0;
                    btnsave.Attributes.Add("onclick", "javascript:Reqenablefalse();");
                }

            }

        


        //dvAttachDetails.Style["display"] = "block";
        //divfirst.Style["display"] = "none";
        //divsecond.Style["display"] = "none";
        //divthird.Style["display"] = "none";
        //divfour.Style["display"] = "none";
        //divfive.Style["display"] = "none";
        //divsix.Style["display"] = "none";
        //divseven.Style["display"] = "none";
        //diveight.Style["display"] = "none";
        //divnine.Style["display"] = "none";
        //divten.Style["display"] = "block";
        //leftDiv.Style["display"] = "none";
        //ViewDiv.Style["display"] = "none";
        //btnRemove.Visible = true;
        //AddAttachment();
        //if (Attach_Retval > 0)
        //{
        //    gvAttachmentDetails.DataSource = BindAttachmentDetails();
        //    gvAttachmentDetails.DataBind();

        //}
        //dispTagName.Value = "divten";
        //txtAttachDesc.Text = "";
        //ddlAttachType.SelectedIndex = 0;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        divfirst.Style["display"] = "block";
        mainContent.Style["display"] = "block";
        ViewDiv.Style["display"] = "none";
        if (Session["ClaimType"].ToString() == "Automobile")
        {
            Automobile.Style["display"] = "block";
        }
        if (Session["ClaimType"].ToString() == "General")
        {
            General.Style["display"] = "block";
        }

        if (Session["ClaimType"].ToString() == "PropertyLoss")
        {
            Property.Style["display"] = "block";
        }
        divbtn.Style["display"] = "block";
        btnViewNext.Visible = true;
        btnBack.Visible = false;
    }
    
   #endregion

    #region Private Methods

   #region Bind Combo
    private void BindCombo()
    {
        objGeneral = new RIMS_Base.Biz.CGeneral();
        dwstateowner.DataSource = objGeneral.GetAllState();
        dwstateowner.DataTextField = "FLD_state";
        dwstateowner.DataValueField = "Code";
        dwstateowner.DataBind();
        ListItem lstItem = new ListItem("------------Select------------", "0");
        dwstateowner.Items.Insert(0, lstItem);

        //Collision_Deductible
        dwCollisionDeductible.DataSource = objGeneral.GetCollision_Deductible();
        dwCollisionDeductible.DataTextField = "Collision_FLD_desc";
        dwCollisionDeductible.DataValueField = "Collision_PK_ID";
        dwCollisionDeductible.DataBind();
        ListItem lstItemCollision = new ListItem("------------Select------------", "0");
        dwCollisionDeductible.Items.Insert(0, lstItemCollision);

        //Bind Jurisdication State Combo
        dwjuridicationstate.DataSource = objGeneral.GetAllState();
        dwjuridicationstate.DataTextField = "FLD_state";
        dwjuridicationstate.DataValueField = "PK_ID";
        dwjuridicationstate.DataBind();
        ListItem lstItem1 = new ListItem("------------Select------------", "0");
        dwjuridicationstate.Items.Insert(0, lstItem1);

    
        //Bind Client Attorney State Combo
        dwStateClientAttorney.DataSource = objGeneral.GetAllState();
        dwStateClientAttorney.DataTextField = "FLD_state";
        dwStateClientAttorney.DataValueField = "PK_ID";
        dwStateClientAttorney.DataBind();
        ListItem lstItem3 = new ListItem("------------Select------------", "0");
        dwStateClientAttorney.Items.Insert(0, lstItem3);

        //Bind Defense Attorney State Combo
        dwdefatoostate.DataSource = objGeneral.GetAllState();
        dwdefatoostate.DataTextField = "FLD_state";
        dwdefatoostate.DataValueField = "PK_ID";
        dwdefatoostate.DataBind();
        ListItem lstItem4 = new ListItem("------------Select------------", "0");
        dwdefatoostate.Items.Insert(0, lstItem4);

         //Bind Second Driver State Combo
        dwsecdriverstate.DataSource = objGeneral.GetAllState();
        dwsecdriverstate.DataTextField = "FLD_state";
        dwsecdriverstate.DataValueField = "PK_ID";
        dwsecdriverstate.DataBind();
        ListItem lstItem34 = new ListItem("------------Select------------", "0");
        dwsecdriverstate.Items.Insert(0, lstItem34);

          //Bind police State Combo
        dwpolicestate.DataSource = objGeneral.GetAllState();
        dwpolicestate.DataTextField = "FLD_state";
        dwpolicestate.DataValueField = "PK_ID";
        dwpolicestate.DataBind();
        ListItem lstItem24 = new ListItem("------------Select------------", "0");
        dwpolicestate.Items.Insert(0, lstItem24);


        //Bind Injury Type Combo
        dwinjury.DataSource = objGeneral.GetInjuryCode();
        dwinjury.DataTextField = "injury_FLD_desc";
        dwinjury.DataValueField = "injury_PK_ID";
        dwinjury.DataBind();
        ListItem lstItem6 = new ListItem("------------Select------------", "0");
        dwinjury.Items.Insert(0, lstItem6);

        //Bind  Ncci Nature Combo
        dwNCCInature.DataSource = objGeneral.GetNcciNature();
        dwNCCInature.DataTextField = "NCCI_Nature_Fld_Desc_1";
        dwNCCInature.DataValueField = "NCCI_Nature_PK_Id";
        dwNCCInature.DataBind();
        ListItem lstItem8 = new ListItem("------------Select------------", "0");
        dwNCCInature.Items.Insert(0, lstItem8);

    

        /* 
          * Bind The Claim Cause Combo. 
       */
        dwcause.DataSource = objGeneral.GetClaimCause();
        dwcause.DataTextField = "Claim_Cause_FLD_desc";
        dwcause.DataValueField = "Claim_Cause_PK_ID";
        dwcause.DataBind();
        ListItem lstItem10 = new ListItem("------------Select------------", "0");
        dwcause.Items.Insert(0, lstItem10);

        /* 
          * Bind The NCCI code Combo. 
       */
        dwNCCIcode.DataSource = objGeneral.GetNcciCode();
        dwNCCIcode.DataTextField = "NCCI_Code_FLD_descNccdesc";
        dwNCCIcode.DataValueField = "NCCI_Code_PK_IDNccCode";
        dwNCCIcode.DataBind();
        ListItem lstItem11 = new ListItem("------------Select------------", "0");
        dwNCCIcode.Items.Insert(0, lstItem11);


        /* 
          * Bind The Minor Type Combo. 
       */
        dwminor.DataSource = objGeneral.GetLiabilityminor();
        dwminor.DataTextField = "Lminor_FLD_desc";
        dwminor.DataValueField = "Lminor_PK_ID";
        dwminor.DataBind();
        ListItem lstItem12 = new ListItem("------------Select------------", "0");
        dwminor.Items.Insert(0, lstItem12);

       // /* 
       //   * Bind The Major Type Combo. 
       //*/
       // dwmajorclaim.DataSource = objGeneral.GetLiabilitymajor();
       // dwmajorclaim.DataTextField = "Lmajor_FLD_desc";
       // dwmajorclaim.DataValueField = "Lmajor_PK_ID";
       // dwmajorclaim.DataBind();
       // ListItem lstItem13 = new ListItem("------------Select------------", "0");
       // dwmajorclaim.Items.Insert(0, lstItem13);

        /* 
          * Bind The Hazard Code Combo. 
       */
        dwHazardCode.DataSource = objGeneral.GetHazardCode();
        dwHazardCode.DataTextField = "Fld_Desc1_Hazard";
        dwHazardCode.DataValueField = "PK_Id_Hazard";
        dwHazardCode.DataBind();
        ListItem lstItem14 = new ListItem("------------Select------------", "0");
        dwHazardCode.Items.Insert(0, lstItem14);

        /* 
          * Bind The Fraud Combo. 
       */
        dwFraudClaim.DataSource = objGeneral.GetFraudClaim();
        dwFraudClaim.DataTextField = "FLD_desc_Fraud";
        dwFraudClaim.DataValueField = "PK_ID_Fraud";
        dwFraudClaim.DataBind();
        ListItem lstItem15 = new ListItem("------------Select------------", "0");
        dwFraudClaim.Items.Insert(0, lstItem15);

        /* 
           * Bind The Affected Body Parts Combo. 
        */
        dwbodyparts.DataSource = objGeneral.GetBodyParts();
        dwbodyparts.DataTextField = "FLD_desc_Body";
        dwbodyparts.DataValueField = "PK_ID_Body";
        dwbodyparts.DataBind();
        ListItem lstItem16 = new ListItem("------------Select------------", "0");
        dwbodyparts.Items.Insert(0, lstItem16);

    
        /* 
          * Bind The Attachment Type Combo. 
       */
        ddlAttachType.DataSource = objGeneral.GetAttachamentType();
        ddlAttachType.DataTextField = "FLD_desc";
        ddlAttachType.DataValueField = "PK_ID";
        ddlAttachType.DataBind();
        ListItem lstItem21 = new ListItem(" -----Select----- ", "0");
        ddlAttachType.Items.Insert(0, lstItem21);


        /* 
          * Bind The Incident Nature Combo. 
       */
        dwnaturofinc.DataSource = objGeneral.GetClaimNature();
        dwnaturofinc.DataTextField = "Claim_Nature_FLD_desc";
        dwnaturofinc.DataValueField = "Claim_Nature_PK_ID";
        dwnaturofinc.DataBind();
        ListItem lstItem23 = new ListItem(" ---------------Select--------------- ", "0");
        dwnaturofinc.Items.Insert(0, lstItem23);

        /* 
         * Bind The Incident Nature Combo. 
      */
        dwroadsurface.DataSource = objGeneral.GetRoadSurface();
        dwroadsurface.DataTextField = "Surface_FLD_desc";
        dwroadsurface.DataValueField = "Surface_PK_ID";
        dwroadsurface.DataBind();
        ListItem lstItem33 = new ListItem(" ---------------Select--------------- ", "0");
        dwroadsurface.Items.Insert(0, lstItem33);

        dwroadtype.DataSource = objGeneral.GetRoadType();
        dwroadtype.DataTextField = "Road_FLD_desc";
        dwroadtype.DataValueField = "Road_PK_ID";
        dwroadtype.DataBind();
        ListItem lstItem25 = new ListItem(" ---------------Select--------------- ", "0");
        dwroadtype.Items.Insert(0, lstItem25);

        dwComprehensiveDeductible.DataSource = objGeneral.GetComprehensive();
        dwComprehensiveDeductible.DataTextField = "comprehensive_FLD_desc";
        dwComprehensiveDeductible.DataValueField = "comprehensive_PK_ID";
        dwComprehensiveDeductible.DataBind();
        ListItem lstItem26 = new ListItem(" ---------------Select--------------- ", "0");
        dwComprehensiveDeductible.Items.Insert(0, lstItem26);

        dwoiginalcost.DataSource = objGeneral.GetOriginalCost();
        dwoiginalcost.DataTextField = "orgcost_FLD_desc";
        dwoiginalcost.DataValueField = "orgcost_PK_ID";
        dwoiginalcost.DataBind();
        ListItem lstItem27 = new ListItem(" ---------------Select--------------- ", "0");
        dwoiginalcost.Items.Insert(0, lstItem27);


       
        dwWeatherIncident.DataSource = objGeneral.Getincident();
        dwWeatherIncident.DataTextField = "WeatherDescription";
        dwWeatherIncident.DataValueField = "PK_Weather_Inc";
        dwWeatherIncident.DataBind();
        ListItem lstItem30 = new ListItem(" ---------------Select--------------- ", "0");
        dwWeatherIncident.Items.Insert(0, lstItem30);

        dwwhethercond.DataSource = objGeneral.GetWeatherCondition();
        dwwhethercond.DataTextField = "Weather_FLD_desc";
        dwwhethercond.DataValueField = "Weather_PK_ID";
        dwwhethercond.DataBind();
        ListItem lstItem31 = new ListItem(" ---------------Select--------------- ", "0");
        dwwhethercond.Items.Insert(0, lstItem31);
        
    }
    #endregion

   #region InsertData
 
  private void InsertData()
  {

   try
   {
   
      objliability = new RIMS_Base.Biz.CLiabilityClaim();
      if (ViewState["PK_Liability_Claim"] != null && ViewState["PK_Liability_Claim"].ToString() != String.Empty)
            {
                objliability.PK_Liability_Claim = Convert.ToInt32(ViewState["PK_Liability_Claim"].ToString());
                
            }

            if (Session["ClaimType"].ToString() == "Automobile")
            {
                   
                    objliability.FK_Liability_Major_Claim_Type = 1;
              
            }

            if (Session["ClaimType"].ToString() == "General")
            {

                objliability.FK_Liability_Major_Claim_Type = 2;

            }

            if (Session["ClaimType"].ToString() == "PropertyLoss")
            {

                objliability.FK_Liability_Major_Claim_Type = 3;

            }
        //    objliability.Update_Date = System.DateTime.Now;
           // objliability.Claim_Number = "08-000001-03";
      if (rbtntemployee.SelectedIndex == 0)
            objliability.Employee = "Y";
        else if (rbtntemployee.SelectedIndex == 1)
            objliability.Employee = "N";
     // objliability.FK_Employee_Claimant

        if (txtcosecenter.Text != String.Empty)
            objliability.FK_Cost_Center = txtcosecenter.Text.Trim();


        if (rbtntemployee.SelectedIndex == 0)
             objliability.FK_Employee_Claimant = Convert.ToDecimal(txtclaimantid.Text.Trim());
        else if (rbtntemployee.SelectedIndex == 1)
               objliability.FK_Employee_Claimant = Convert.ToDecimal(txtidclaimant.Text.Trim());
        
      if(txtowner.Text != String.Empty)
          objliability.Owner = txtowner.Text.Trim();

       if(txtAddLine1.Text != String.Empty)
          objliability.Owner_Address_1 = txtAddLine1.Text.Trim();

      if(txtAddLine2.Text != String.Empty)
          objliability.Owner_Address_2 = txtAddLine2.Text.Trim();

      if(txtcity.Text != String.Empty)
          objliability.Owner_City = txtcity.Text.Trim();

       if(txtzipcode.Text != String.Empty)
          objliability.Owner_Zip = txtzipcode.Text.Trim();

       if (dwstateowner.SelectedIndex != 0)
            objliability.FK_State_Owner= Convert.ToDecimal(dwstateowner.SelectedValue.ToString());

       if(txthomephone.Text != String.Empty)
          objliability.Owner_Home_Phone = txthomephone.Text.Trim();

      if(txtworkphone.Text != String.Empty)
          objliability.Owner_Work_Phone = txtworkphone.Text.Trim();

        if(txtclaimDesc.Text != String.Empty)
          objliability.Claim_Description = txtclaimDesc.Text.Trim();

        if (dwnaturofinc.SelectedIndex != 0)
            objliability.Nature = Convert.ToDecimal(dwnaturofinc.SelectedValue.ToString());

       if (txtEstimatetorepair.Text != String.Empty)
           objliability.Estimate = Convert.ToDecimal(txtEstimatetorepair.Text.Trim());  
   
      if (txtActualtorepair.Text != String.Empty)
           objliability.Actual = Convert.ToDecimal(txtActualtorepair.Text.Trim());  
         
       if (dwroadtype.SelectedIndex != 0)
            objliability.FK_Road_Type = Convert.ToDecimal(dwroadtype.SelectedValue.ToString());

        if (dwroadsurface.SelectedIndex != 0)
            objliability.FK_Road_Surface = Convert.ToDecimal(dwroadsurface.SelectedValue.ToString());
            
        if (dwcause.SelectedIndex != 0)
            objliability.FK_Claim_Cause = Convert.ToDecimal(dwcause.SelectedValue.ToString());

        if (dwbodyparts.SelectedIndex != 0)
            objliability.FK_Body_Parts= Convert.ToDecimal(dwbodyparts.SelectedValue.ToString());

       if (dwinjury.SelectedIndex != 0)
            objliability.FK_Injury = Convert.ToDecimal(dwinjury.SelectedValue.ToString());

      if (dwNCCIcode.SelectedIndex != 0)
            objliability.FK_NCCI_Code = Convert.ToDecimal(dwNCCIcode.SelectedValue.ToString());

        if (dwNCCInature.SelectedIndex != 0)
            objliability.FK_NCCI_Nature = Convert.ToDecimal(dwNCCInature.SelectedValue.ToString());

       if (dwHazardCode.SelectedIndex != 0)
            objliability.FK_Hazard_Code = Convert.ToDecimal(dwHazardCode.SelectedValue.ToString());

      
      if(txtlocationdesc.Text != String.Empty)
          objliability.Location_Description = txtlocationdesc.Text.Trim();

       if (dwComprehensiveDeductible.SelectedIndex != 0)
            objliability.FK_Comprehensive_Deductible = Convert.ToDecimal(dwComprehensiveDeductible.SelectedValue.ToString());

       if (dwCollisionDeductible.SelectedIndex != 0)
            objliability.FK_Collision_Deductible = Convert.ToDecimal(dwCollisionDeductible.SelectedValue.ToString());

      
       if (dwoiginalcost.SelectedIndex != 0)
            objliability.FK_Original_Cost = Convert.ToDecimal(dwoiginalcost.SelectedValue.ToString());

      //if (dwmajorclaim.SelectedIndex != 0)
      //      objliability.FK_Liability_Major_Claim_Type = Convert.ToDecimal(dwmajorclaim.SelectedValue.ToString());

        if (dwminor.SelectedIndex != 0)
            objliability.FK_Liability_Minor_Claim_Type = Convert.ToDecimal(dwminor.SelectedValue.ToString());

        if (rtnclaimconvert.SelectedIndex == 0)
            objliability.Convertible = "Y";
        else if (rtnclaimconvert.SelectedIndex == 1)
            objliability.Convertible = "N";

        if (txtincreported.Text != String.Empty)
            objliability.Date_Reported = Convert.ToDateTime(txtincreported.Text);

        if (txtdateofinc.Text != String.Empty)
            objliability.Incident_Date = Convert.ToDateTime(txtdateofinc.Text);

      if (dwFraudClaim.SelectedIndex != 0)
            objliability.FK_Fraud_Claim = Convert.ToDecimal(dwFraudClaim.SelectedValue.ToString());

        if (txtdateclaimreported.Text != String.Empty)
            objliability.Claim_Reopen_Date = Convert.ToDateTime(txtdateclaimreported.Text);


        if (txtclaimopen.Text != String.Empty)
            objliability.Claim_Open_Date = Convert.ToDateTime(txtclaimopen.Text);

        if (txtclaimclosed.Text != String.Empty)
            objliability.Claim_Close_Date = Convert.ToDateTime(txtclaimclosed.Text);

      if (rbtnsurgery.SelectedIndex == 0)
            objliability.Surgery_Required = "Y";
        else if (rbtnsurgery.SelectedIndex == 1)
            objliability.Surgery_Required = "N";

         
      if (txtnoofweekssch.Text != String.Empty)
           objliability.Indemnity_Weeks = Convert.ToDecimal(txtnoofweekssch.Text.Trim());

        if (dwjuridicationstate.SelectedIndex != 0)
            objliability.FK_State_Jurisdiction = Convert.ToDecimal(dwjuridicationstate.SelectedValue.ToString());
      
       if (rbtncivilorcriminal.SelectedIndex == 0)
            objliability.Criminal_Violation = "Y";
        else if (rbtncivilorcriminal.SelectedIndex == 1)
            objliability.Criminal_Violation = "N";

         if (dwWeatherIncident.SelectedIndex != 0)
            objliability.FK_Weather_Incident= Convert.ToDecimal(dwWeatherIncident.SelectedValue.ToString());


        if (txtdatebusireopen.Text != String.Empty)
            objliability.Date_Bus_Reopened = Convert.ToDateTime(txtdatebusireopen.Text);


        if (txtdatebusiclosed.Text != String.Empty)
            objliability.Date_Bus_Closed = Convert.ToDateTime(txtdatebusiclosed.Text);


        if (txtassigntid.Text != String.Empty)
            objliability.FK_Employee = Convert.ToDecimal(txtassigntid.Text.ToString());

      if (txtpercentFlood.Text != String.Empty)
           objliability.Building_Percent_Flood = Convert.ToDecimal(txtpercentFlood.Text.Trim());

         if (txtpercentwindproloss1.Text != String.Empty)
           objliability.Building_Percent_Wind = Convert.ToDecimal(txtpercentwindproloss1.Text.Trim());
      
      if (txtpercentother1.Text != String.Empty)
           objliability.Building_Percent_Other = Convert.ToDecimal(txtpercentother1.Text.Trim());

      if (txtpercentfireproloss1.Text != String.Empty)
           objliability.Building_Percent_Fire= Convert.ToDecimal(txtpercentfireproloss1.Text.Trim());
      
      
      if (txtpercentflood2.Text != String.Empty)
           objliability.Contents_Percent_Flood = Convert.ToDecimal(txtpercentflood2.Text.Trim());

        if (txtpercentwind2.Text != String.Empty)
           objliability.Contents_Percent_Wind = Convert.ToDecimal(txtpercentwind2.Text.Trim());

          if (txtpercentfire2.Text != String.Empty)
           objliability.Contents_Percent_Fire = Convert.ToDecimal(txtpercentfire2.Text.Trim());

      if (txtpercentother2.Text != String.Empty)
           objliability.Contents_Percent_Other = Convert.ToDecimal(txtpercentother2.Text.Trim());

        if (txtpercentflood3.Text != String.Empty)
           objliability.Computers_Percent_Flood = Convert.ToDecimal(txtpercentflood3.Text.Trim());

        if (txtpercentWind3.Text != String.Empty)
           objliability.Computers_Percent_Wind = Convert.ToDecimal(txtpercentWind3.Text.Trim());
      
        if (txtpercentother3.Text != String.Empty)
           objliability.Computers_Percent_Other = Convert.ToDecimal(txtpercentother3.Text.Trim());

       if (txtpercentfire3.Text != String.Empty)
           objliability.Computers_Percent_Fire = Convert.ToDecimal(txtpercentfire3.Text.Trim());


      
       if (txtpercentflood4.Text != String.Empty)
           objliability.ATMs_Percent_Flood = Convert.ToDecimal(txtpercentflood4.Text.Trim());
      
       if (txtpercentWind4.Text != String.Empty)
           objliability.ATMs_Percent_Wind = Convert.ToDecimal(txtpercentWind4.Text.Trim());
      
       if (txtpercentfire4.Text != String.Empty)
           objliability.ATMs_Percent_Fire = Convert.ToDecimal(txtpercentfire4.Text.Trim());
      
       if (txtpercentother4.Text != String.Empty)
           objliability.ATMs_Percent_Other = Convert.ToDecimal(txtpercentother4.Text.Trim());

       if (txtpercentflood5.Text != String.Empty)
           objliability.Leasehold_Improvements_Percent_Flood = Convert.ToDecimal(txtpercentflood5.Text.Trim());
      
       if (txtpercentwind5.Text != String.Empty)
           objliability.Leasehold_Improvements_Percent_Wind = Convert.ToDecimal(txtpercentwind5.Text.Trim());
      
       if (txtpercentfire5.Text != String.Empty)
           objliability.Leasehold_Improvements_Percent_Fire = Convert.ToDecimal(txtpercentfire5.Text.Trim());
      
       if (txtpercentother5.Text != String.Empty)
           objliability.Leasehold_Improvements_Percent_Other = Convert.ToDecimal(txtpercentother5.Text.Trim());




       if (txtpercentFlood6.Text != String.Empty)
           objliability.Signs_Percent_Flood = Convert.ToDecimal(txtpercentFlood6.Text.Trim());
      
       if (txtpercentWind6.Text != String.Empty)
           objliability.Signs_Percent_Wind = Convert.ToDecimal(txtpercentWind6.Text.Trim());
      
       if (txtpercentFire6.Text != String.Empty)
           objliability.Signs_Percent_Fire = Convert.ToDecimal(txtpercentFire6.Text.Trim());
      
       if (txtpercentOther6.Text != String.Empty)
           objliability.Signs_Percent_Other = Convert.ToDecimal(txtpercentOther6.Text.Trim());



       if (txtpercentFlood7.Text != String.Empty)
           objliability.Fine_Arts_Percent_Flood = Convert.ToDecimal(txtpercentFlood7.Text.Trim());
      
       if (txtpercentWind7.Text != String.Empty)
           objliability.Fine_Arts_Percent_Wind = Convert.ToDecimal(txtpercentWind7.Text.Trim());
      
       if (txtpercentFire7.Text != String.Empty)
           objliability.Fine_Arts_Percent_Fire = Convert.ToDecimal(txtpercentFire7.Text.Trim());
      
       if (txtpercentOther7.Text != String.Empty)
           objliability.Fine_Arts_Percent_Other = Convert.ToDecimal(txtpercentOther7.Text.Trim());

      
       if (rbtnwasincidentrep.SelectedIndex == 0)
            objliability.Reported_To_Police = "Y";
        else if (rbtnwasincidentrep.SelectedIndex == 1)
            objliability.Reported_To_Police = "N";


      //if (txtincreportedpolicy.Text != String.Empty)
      //     objliability.Police_Date= Convert.ToDateTime(txtincreportedpolicy.Text);

        if(txtppliceoffname.Text != String.Empty)
          objliability.Police_Officer = txtppliceoffname.Text.Trim();


        if(txtpoliceadd1.Text != String.Empty)
          objliability.Police_Address_1 = txtpoliceadd1.Text.Trim();

        if(txtpoliceadd2.Text != String.Empty)
          objliability.Police_Address_2 = txtpoliceadd2.Text.Trim();

       if(txtpolicecity.Text != String.Empty)
          objliability.Police_City = txtpolicecity.Text.Trim();

        if (dwpolicestate.SelectedIndex != 0)
            objliability.FK_State_Police = Convert.ToDecimal(dwpolicestate.SelectedValue.ToString());

        if(txtpoliceZipcode.Text != String.Empty)
          objliability.Police_Zip_Code = txtpoliceZipcode.Text.Trim();

        if(txtpolicephone.Text != String.Empty)
          objliability.Police_Phone = txtpolicephone.Text.Trim();

      if(txtpolicecommnts.Text != String.Empty)
          objliability.Police_Comments = txtpolicecommnts.Text.Trim();

      if (dwwhethercond.SelectedIndex != 0)
          objliability.FK_Weather = dwwhethercond.SelectedValue.ToString();

       if (rbtnwheretravel.SelectedIndex == 0)
            objliability.Mobile_Restrictions = "Y";
        else if (rbtnwheretravel.SelectedIndex == 1)
            objliability.Mobile_Restrictions = "N";

       if(txtpoinofImpact.Text != String.Empty)
          objliability.Mobile_Impact_Point = txtpoinofImpact.Text.Trim();

      if(txtpartsdamage.Text != String.Empty)
          objliability.Mobile_Parts_Damaged = txtpartsdamage.Text.Trim();

       if(txtmake.Text != String.Empty)
          objliability.Vehicle_Make = txtmake.Text.Trim();

         if(txtmodel.Text != String.Empty)
          objliability.Vehicle_Model = txtmodel.Text.Trim();

       if(txtyearofmenu.Text != String.Empty)
          objliability.Vehicle_Year = Convert.ToDecimal(txtyearofmenu.Text.ToString());
      
         if(txtcolor.Text != String.Empty)
          objliability.Vehicle_Color = txtcolor.Text.Trim();


       if(txtpropertyid.Text != String.Empty)
        objliability.FK_Property = Convert.ToDecimal(txtpropertyid.Text.ToString());

      if(txtvalue.Text != String.Empty)
          objliability.Vehicle_Value = Convert.ToDecimal(txtvalue.Text.ToString());
    
        if (rbtnwheretravel.SelectedIndex == 0)
            objliability.Mobile_Restrictions = "Y";
        else if (rbtnwheretravel.SelectedIndex == 1)
            objliability.Mobile_Restrictions = "N";

       if(txtstoragelocation.Text != String.Empty)
          objliability.Mobile_Storage_Location = txtstoragelocation.Text.Trim();
      
       if(txtvehicleidentino.Text != String.Empty)
          objliability.Vehicle_Identification_Number = txtvehicleidentino.Text.Trim();

        if(txtdriverage.Text != String.Empty)
          objliability.Driver_Age = Convert.ToDecimal(txtdriverage.Text.ToString());

        if (rbtnpermissiongrantedtosecdriver.SelectedIndex == 0)
            objliability.Permission = "Y";
        else if (rbtnpermissiongrantedtosecdriver.SelectedIndex == 1)
            objliability.Permission = "N";

       if(txtnamesecDriver.Text != String.Empty)
          objliability.Second_Driver_Name = txtnamesecDriver.Text.Trim();

         if(txtsecdriveradd1.Text != String.Empty)
          objliability.Second_Driver_Address_1 = txtsecdriveradd1.Text.Trim();

        if(txtsecdriveradd2.Text != String.Empty)
          objliability.Second_Driver_Address_2 = txtsecdriveradd2.Text.Trim();

       if(txtsecdrivercity.Text != String.Empty)
          objliability.Second_Driver_City = txtsecdrivercity.Text.Trim();

      
        if (dwsecdriverstate.SelectedIndex != 0)
            objliability.FK_State_Second_Driver = Convert.ToDecimal(dwsecdriverstate.SelectedValue.ToString());

       if(txtsecdriverzip.Text != String.Empty)
          objliability.Second_Driver_Zip_Code  = txtsecdriverzip.Text.Trim();

       if(txtsecdriverphone.Text != String.Empty)
          objliability.Second_Driver_Phone = txtsecdriverphone.Text.Trim();
      
       if(txtsecdriverinscopmpany.Text != String.Empty)
          objliability.Second_Driver_Ins_Company = txtsecdriverinscopmpany.Text.Trim();

        if(txtsecdriverinspolicyno.Text != String.Empty)
          objliability.Second_Driver_Ins_Number = txtsecdriverinspolicyno.Text.Trim();

        if (rbtnEmergencyMedical.SelectedIndex == 0)
            objliability.EMS_Contacted = "Y";
        else if (rbtnEmergencyMedical.SelectedIndex == 1)
            objliability.EMS_Contacted = "N";

        if(txtlosspayee.Text != String.Empty)
          objliability.Loss_Payee_Automobiles = txtlosspayee.Text.Trim();

      if (txtsuitdate.Text != String.Empty)
          objliability.Suit_Date = Convert.ToDateTime(txtsuitdate.Text);

      if (txtattodiscdate.Text != String.Empty)
         objliability.Attorney_Disclosure_Date = Convert.ToDateTime(txtattodiscdate.Text);
        if(txtproductname.Text  != String.Empty)
         objliability.Liability_Product_Name_new = txtproductname.Text.Trim();



       if(txtclientattoname.Text != String.Empty)
          objliability.Client_Attorney_Name = txtclientattoname.Text.Trim();

       if(txtclientattoadd1.Text != String.Empty)
          objliability.Client_Attorney_Address_1 = txtclientattoadd1.Text.Trim();


       if(txtclientattoadd2.Text != String.Empty)
          objliability.Client_Attorney_Address_2 = txtclientattoadd2.Text.Trim();


        if(txtclientattocity.Text != String.Empty)
          objliability.Client_Attorney_City = txtclientattocity.Text.Trim();

      if (dwStateClientAttorney.SelectedIndex != 0)
            objliability.FK_State_Client_Attorney = Convert.ToDecimal(dwStateClientAttorney.SelectedValue.ToString());

        if(txtclientattozip.Text != String.Empty)
          objliability.Client_Attorney_Zip_Code = txtclientattozip.Text.Trim();

        if(txtclientattophone.Text != String.Empty)
          objliability.Client_Attorney_Phone = txtclientattophone.Text.Trim();

        if(txtclientattoFasc.Text != String.Empty)
          objliability.Client_Attorney_Fax = txtclientattoFasc.Text.Trim();

        if(txtdefeattoname.Text != String.Empty)
          objliability.Defense_Attorney_Name = txtdefeattoname.Text.Trim();

       if(txtdefeattoadd1.Text != String.Empty)
          objliability.Defense_Attorney_Address_1 = txtdefeattoadd1.Text.Trim();

       if(txtdefeattoadd2.Text != String.Empty)
          objliability.Defense_Attorney_Address_2 = txtdefeattoadd2.Text.Trim();

       if(txtdefeattocity.Text != String.Empty)
          objliability.Defense_Attorney_City = txtdefeattocity.Text.Trim();

       if(txtdefeattozip.Text != String.Empty)
          objliability.Defense_Attorney_Zip_Code = txtdefeattozip.Text.Trim();

        if(txtdefeattFasc.Text != String.Empty)
          objliability.Defense_Attorney_Fax = txtdefeattFasc.Text.Trim();

      if (txtdefeattphone.Text != String.Empty)
          objliability.Defense_Attorney_Phone = txtdefeattphone.Text.Trim();

      if (dwdefatoostate.SelectedIndex != 0)
          objliability.FK_State_Defense_Attorney = Convert.ToDecimal(dwdefatoostate.SelectedValue.ToString());


        m_intRetval = Convert.ToInt32(objliability.InsertUpdate_Claim(objliability));

        //workid = m_intRetval;

        ViewState["PK_Liability_Claim"] = m_intRetval.ToString();
       Session["LiabilityID"] = ViewState["PK_Liability_Claim"].ToString();

        }

        catch (Exception ex)
        {
            throw ex;
        }


   }
  
  #endregion
   
   #region ViewData

    /// <summary>
    /// Creteated By Vasant 
    /// It View Data of Liability Claim .
    ///  </summary>
    /// <param name="PK_liability_Claim"> Liability Claim ID </param>
    /// <remarks></remarks>

    private void ViewData()
    
   {
      objliability = new RIMS_Base.Biz.CLiabilityClaim();
      lstliability = new List<RIMS_Base.CLiabilityClaim>();
      Int32 Liabilityid = Convert.ToInt32(ViewState["PK_Liability_Claim"]);
      lstliability = objliability.Getility_ClaimByID(Liabilityid);
      try
      {

          lstproperty = objliability.Get_Property_ByID(Liabilityid, Convert.ToDecimal(lstliability[0].FK_Property));
          if (lstproperty.Count != 0)
          {
              
              lblproperty.Text = lstproperty[0].Stationary_Type;
              lbladd1.Text = lstproperty[0].Stationary_Address_1;
              lbladd2.Text = lstproperty[0].Stationary_Address_2;
              lblcityproperty.Text = lstproperty[0].Stationary_City;
                lblstate.Text = lstproperty[0].Stationary_State;
                lblzipproperty.Text = lstproperty[0].Stationary_Zip;
              //  lblcounty.Text = lstliability[0].Fk_Co
                lblentity.Text = lstproperty[0].FK_Entity.ToString();
                lblowenership.Text = lstproperty[0].Ownership;
                lblwhatfood.Text = lstproperty[0].Flood_Zone;
                lblnoofemployee.Text = lstproperty[0].Number_Of_Employees.ToString();
                lblbuilding.Text = lstproperty[0].Building.ToString();
                lblSigns.Text = lstproperty[0].Signs.ToString();
                lblcomputers.Text = lstproperty[0].Computers.ToString();
                lblATMS.Text = lstproperty[0].ATMs.ToString();
                lblleaseimprovements.Text = lstproperty[0].Lease_Improvements.ToString();
                lbltotal.Text = lstproperty[0].Total.ToString();


          }

          lstCliamant = objliability.GetLiability_CliamantByID(Liabilityid, Convert.ToInt32(lstliability[0].FK_Employee_Claimant));
          if (lstCliamant.Count != 0)
          {
              lbllastname.Text = lstCliamant[0].Cliamant_Last_Name.Replace("''", "'");
              lblfirstname.Text = lstCliamant[0].Cliamant_First_Name.Replace("''", "'");
              lblmiddlename.Text = lstCliamant[0].Cliamant_Middle_Name.Replace("''", "'");


             
          }



          lstEmp = objliability.GetLiabilityEmp_Data_ByID(Liabilityid, Convert.ToInt32(lstliability[0].FK_Employee_Claimant), 1);
          if (lstEmp.Count != 0)
          {
              lbllastname.Text = lstEmp[0].Last_Name.Replace("''", "'");
              lblfirstname.Text = lstEmp[0].First_Name.Replace("''", "'");
              lblmiddlename.Text = lstEmp[0].Middle_Name.Replace("''", "'");
          }

          lstEmpAssign = objliability.GetLiabilityEmp_Data_ByID(Liabilityid, Convert.ToInt32(lstliability[0].FK_Employee), 2);
          if (lstEmpAssign.Count != 0)
          {
              lblassignfirst.Text = lstEmpAssign[0].First_Name.Replace("''", "'");
              lblassignmiddle.Text = lstEmpAssign[0].Middle_Name.Replace("''", "'");
              lblassignlast.Text = lstEmpAssign[0].Last_Name.Replace("''", "'");
               
          }


          
          lstCostCenter= objliability.GetLiability_CostCenterByID(Liabilityid, Convert.ToString(lstliability[0].FK_Cost_Center));
          if (lstCostCenter.Count != 0)
          {
              lblbranchname.Text = lstCostCenter[0].Division_Name;

          }

          lblClaimNo.Text = lstliability[0].Claim_Number;
          // lblClaimNo.Text = lstliability[0].Claim_Number;
           lblcosecenter.Text = lstliability[0].FK_Cost_Center;
           
        
          
             lblcosecenter.Text = lstliability[0].FK_Cost_Center;;

           if (txtbranchname.Text != String.Empty)
              lblbranchname.Text = txtbranchname.Text;

           if (lstliability[0].Employee == "Y")
              lblrbtntemployee.Text = "Yes";
          else if (lstliability[0].Employee == "N")
              lblrbtntemployee.Text = "No";

          lblowner.Text = lstliability[0].Owner;
                   
          lblAddLine1.Text = lstliability[0].Owner_Address_1;

          lblAddLine2.Text = lstliability[0].Owner_Address_2;
                  
          lblcity.Text = lstliability[0].Owner_City;

          lblzipcode.Text = lstliability[0].Owner_Zip;

          lblhomephone.Text = lstliability[0].Owner_Home_Phone;


          lblworkphone.Text = lstliability[0].Owner_Work_Phone;

          

          if (lstliability[0].FK_State_Owner != null)
          lblstateowner.Text = dwstateowner.Items.FindByValue(lstliability[0].FK_State_Owner.ToString()).Text;

          lblclaimDesc.Text =lstliability[0].Claim_Description;

          //if (lstliability[0].FK_na != null)
          //lblnaturofinc.Text = dwnaturofinc.Items.FindByValue(lstliability[0].FK_State_Owner.ToString()).Text;

          lblEstimatetorepair.Text = lstliability[0].Estimate.ToString();
          lblActualtorepair.Text = lstliability[0].Actual.ToString();

          if (lstliability[0].FK_Road_Type != null)
          lblroadtype.Text = dwroadtype.Items.FindByValue(lstliability[0].FK_Road_Type.ToString()).Text;

           if (lstliability[0].FK_Road_Surface != null)
          lblroadsurface.Text = dwroadsurface.Items.FindByValue(lstliability[0].FK_Road_Surface.ToString()).Text;

           if (lstliability[0].FK_Claim_Cause != null)
          lblcause.Text = dwcause.Items.FindByValue(lstliability[0].FK_Claim_Cause.ToString()).Text;

           if (lstliability[0].FK_Body_Parts != null)
          lblbodyparts.Text = dwbodyparts.Items.FindByValue(lstliability[0].FK_Body_Parts.ToString()).Text;

          if (lstliability[0].FK_Injury != null)
          lblinjury.Text = dwinjury.Items.FindByValue(lstliability[0].FK_Injury.ToString()).Text;

            if (lstliability[0].FK_NCCI_Code != null)
          lblNCCIcode .Text = dwNCCIcode.Items.FindByValue(lstliability[0].FK_NCCI_Code.ToString()).Text;

           if (lstliability[0].FK_NCCI_Nature!= null)
          lblNCCInature .Text = dwNCCInature.Items.FindByValue(lstliability[0].FK_NCCI_Nature.ToString()).Text;

          if (lstliability[0].FK_Hazard_Code!= null)
          lblHazardCode.Text = dwHazardCode.Items.FindByValue(lstliability[0].FK_Hazard_Code.ToString()).Text;
            
          lbllocationdesc.Text = lstliability[0].Location_Description;
          
          if (lstliability[0].FK_Collision_Deductible != null)
          lblComprehensiveDeductible.Text = dwComprehensiveDeductible.Items.FindByValue(lstliability[0].FK_Collision_Deductible.ToString()).Text;
            
          if (lstliability[0].FK_Original_Cost != null)
          lbloiginalcost.Text = dwoiginalcost.Items.FindByValue(lstliability[0].FK_Original_Cost.ToString()).Text;

         //if (lstliability[0].FK_Liability_Major_Claim_Type != null)
         // lblmajorclaim.Text = dwmajorclaim.Items.FindByValue(lstliability[0].FK_Liability_Major_Claim_Type.ToString()).Text;

          if (lstliability[0].FK_Liability_Minor_Claim_Type != null)
          lblminor.Text = dwminor.Items.FindByValue(lstliability[0].FK_Liability_Minor_Claim_Type.ToString()).Text;

          if (lstliability[0].FK_Fraud_Claim != null)
          lblFraudClaim.Text = dwFraudClaim.Items.FindByValue(lstliability[0].FK_Fraud_Claim.ToString()).Text;

          if (lstliability[0].Convertible == "Y")
              lblrtnclaimconvert.Text = "Yes";
          else if (lstliability[0].Convertible == "N")
              lblrtnclaimconvert.Text = "No";

          if (lstliability[0].Incident_Date.ToString() != String.Empty)
              lbldateofinc.Text = Convert.ToDateTime(lstliability[0].Incident_Date.ToString()).ToShortDateString();

          if (lstliability[0].Date_Reported.ToString() != String.Empty)
              lblincreported.Text = Convert.ToDateTime(lstliability[0].Date_Reported.ToString()).ToShortDateString();

          if (lstliability[0].Claim_Open_Date.ToString() != String.Empty)
              lblclaimopen.Text = Convert.ToDateTime(lstliability[0].Claim_Open_Date.ToString()).ToShortDateString();


          if (lstliability[0].Claim_Close_Date.ToString() != String.Empty)
              lblclaimclosed.Text = Convert.ToDateTime(lstliability[0].Claim_Close_Date.ToString()).ToShortDateString();

          if (lstliability[0].Claim_Reopen_Date.ToString() != String.Empty)
              lbldateclaimreported.Text = Convert.ToDateTime(lstliability[0].Claim_Reopen_Date.ToString()).ToShortDateString();


           if (lstliability[0].Surgery_Required == "Y")
              lblrbtnsurgery.Text = "Yes";
          else if (lstliability[0].Surgery_Required == "N")
              lblrbtnsurgery.Text = "No";
          
          lblnoofweekssch.Text = lstliability[0].Indemnity_Weeks.ToString();

          if (lstliability[0].FK_State_Jurisdiction != null)
          lbljuridicationstate.Text = dwjuridicationstate.Items.FindByValue(lstliability[0].FK_State_Jurisdiction.ToString()).Text;


      lblassignfirst.Text = txtassignfirst.Text.Replace("''", "'");
          lblassignlast.Text = txtassignlast.Text.Replace("''", "'");
          lblassignmiddle.Text = txtassignmiddle.Text.Replace("''", "'");

           if (lstliability[0].Criminal_Violation == "Y")
              lblrbtncivilorcriminal.Text = "Yes";
          else if (lstliability[0].Criminal_Violation == "N")
              lblrbtncivilorcriminal.Text = "No";

          // if (txtproperty.Text != String.Empty)
          //    lblproperty.Text = txtproperty.Text;

          //  if (txtentity.Text != String.Empty)
          //    lblentity.Text = txtentity.Text;

          //  if (txtadd1.Text != String.Empty)
          //    lbladd1.Text = txtadd1.Text;

          // if (txtadd2.Text != String.Empty)
          //    lbladd2.Text = txtadd2.Text;

          // if (txtcityproperty.Text != String.Empty)
          //    lblcityproperty.Text = txtcityproperty.Text;

          //  if (txtstate.Text != String.Empty)
          //    lblstate.Text = txtstate.Text;

          //  if (txtzipproperty.Text != String.Empty)
          //    lblzipproperty.Text = txtzipproperty.Text;

          
          //   if (txtcounty.Text != String.Empty)
          //    lblcounty.Text = txtcounty.Text;

          //  if (txtowenership.Text != String.Empty)
          //    lblowenership.Text = txtowenership.Text;
          
          //  if (txtwhatfood.Text != String.Empty)
          //    lblwhatfood.Text = txtwhatfood.Text;

          //  if (txtnoofemployee.Text != String.Empty)
          //    lblnoofemployee.Text = txtnoofemployee.Text;

          //  if (txtbuilding.Text != String.Empty)
          //  lblbuilding.Text = txtbuilding.Text;

          //if (txtSigns.Text != String.Empty)
          //  lblbuilding.Text = txtSigns.Text;

            
              if (lstliability[0].FK_Weather_Incident != null)
          lblWeatherIncident.Text = dwWeatherIncident.Items.FindByValue(lstliability[0].FK_Weather_Incident.ToString()).Text;

                        
          lblpolicyNo.Text = lstliability[0].FK_Policy_Number.ToString();

          if (lstliability[0].Date_Bus_Closed.ToString() != String.Empty)
              lbldatebusiclosed.Text = Convert.ToDateTime(lstliability[0].Date_Bus_Closed.ToString()).ToShortDateString();

          if (lstliability[0].Date_Bus_Reopened.ToString() != String.Empty)
              lbldatebusireopen.Text = Convert.ToDateTime(lstliability[0].Date_Bus_Reopened.ToString()).ToShortDateString();

            lblpercentFlood.Text = lstliability[0].Building_Percent_Flood.ToString();
            lblpercentother1.Text = lstliability[0].Building_Percent_Other.ToString();
          lblpercentfireproloss1.Text = lstliability[0].Building_Percent_Fire.ToString();
          lblpercentwindproloss1.Text = lstliability[0].Building_Percent_Wind.ToString();
     
             lblpercentwind2.Text = lstliability[0].Percent_Wind.ToString();

            lblpercentflood2.Text = lstliability[0].Contents_Percent_Flood.ToString();
            lblpercentwind2.Text = lstliability[0].Contents_Percent_Wind.ToString();
            lblpercentfire2.Text = lstliability[0].Contents_Percent_Fire.ToString();
            lblpercentother2.Text = lstliability[0].Computers_Percent_Other.ToString();
            
            lblpercentflood3.Text = lstliability[0].Computers_Percent_Flood.ToString();
            lblpercentWind3.Text = lstliability[0].Computers_Percent_Wind.ToString();
            lblpercentfire3.Text = lstliability[0].Computers_Percent_Fire.ToString();
            lblpercentother3.Text = lstliability[0].Computers_Percent_Other.ToString();
            
            lblpercentflood4.Text = lstliability[0].ATMs_Percent_Flood.ToString();
            lblpercentWind4.Text = lstliability[0].ATMs_Percent_Wind.ToString();
            lblpercentfire4.Text = lstliability[0].ATMs_Percent_Fire.ToString();
            lblpercentother4.Text = lstliability[0].ATMs_Percent_Other.ToString();
            
            lblpercentflood5.Text = lstliability[0].Leasehold_Improvements_Percent_Flood.ToString();
            lblpercentwind5.Text = lstliability[0].Leasehold_Improvements_Percent_Wind.ToString();
            lblpercentfire5.Text = lstliability[0].Leasehold_Improvements_Percent_Fire.ToString();
            lblpercentother5.Text = lstliability[0].Leasehold_Improvements_Percent_Other.ToString();

            lblpercentFlood6.Text = lstliability[0].Signs_Percent_Flood.ToString();
            lblpercentWind6.Text = lstliability[0].Signs_Percent_Other.ToString();
            lblpercentFire6.Text = lstliability[0].Signs_Percent_Fire.ToString();
            lblpercentOther6.Text = lstliability[0].Signs_Percent_Wind.ToString();

           lblpercentFlood7.Text = lstliability[0].Fine_Arts_Percent_Flood.ToString();
            lblpercentWind7.Text = lstliability[0].Fine_Arts_Percent_Wind.ToString();
            lblpercentFire7.Text = lstliability[0].Fine_Arts_Percent_Fire.ToString();
            lblpercentOther7.Text = lstliability[0].Fine_Arts_Percent_Other.ToString();


             if (lstliability[0].Reported_To_Police == "Y")
              lblrbtnwasincrep.Text = "Yes";
          else if (lstliability[0].Reported_To_Police == "N")
              lblrbtnwasincrep.Text = "No";

             if (lstliability[0].Police_Date.ToString() != String.Empty)
              lblincreportedpolicy.Text = Convert.ToDateTime(lstliability[0].Police_Date.ToString()).ToShortDateString();

            lblppliceoffname.Text = lstliability[0].Police_Officer;
          lblpoliceadd1.Text = lstliability[0].Police_Address_1;
           lblpoliceadd2.Text = lstliability[0].Police_Address_2;

           lblpolicecity.Text = lstliability[0].Police_City;

           lblpoliceZipcode.Text = lstliability[0].Police_Zip_Code;

           lblpolicephone.Text = lstliability[0].Police_Phone;

            if (lstliability[0].FK_State_Police != null)
          lblpolicestate.Text = dwpolicestate.Items.FindByValue(lstliability[0].FK_State_Police.ToString()).Text;

            lblpolicecommnts.Text = lstliability[0].Police_Comments;
            lblproductname.Text = lstliability[0].Liability_Product_Name_new;
            if (lstliability[0].FK_Weather != null)
          lblwhethercond.Text = dwwhethercond.Items.FindByValue(lstliability[0].FK_Weather.ToString()).Text;

          //   if (lstliability[0].Mobile_Towed == "Y")
          //    lblrbtnwheretravel.Text = "Yes";
          //else if (lstliability[0].Mobile_Towed == "N")
          //    lblrbtnwheretravel.Text = "No";

            lblpoinofImpact.Text = lstliability[0].Mobile_Impact_Point;
            lblpartsdamage.Text = lstliability[0].Mobile_Parts_Damaged;
            lblmake.Text = lstliability[0].Vehicle_Make;
            lblmodel.Text = lstliability[0].Vehicle_Model;
            lblyearofmenu.Text = lstliability[0].Vehicle_Year.ToString();
            lblcolor.Text = lstliability[0].Vehicle_Color;
            lblvalue.Text = lstliability[0].Vehicle_Value.ToString();


            if (lstliability[0].Mobile_Towed == "Y")
              lblrbtnwasvehicletowed.Text = "Yes";
          else if (lstliability[0].Mobile_Towed == "N")
              lblrbtnwasvehicletowed.Text = "No";

            lblstoragelocation.Text = lstliability[0].Mobile_Storage_Location;
            lbldriverage.Text = lstliability[0].Driver_Age.ToString();
          //  lblpolicycastno.Text = lstliability[0].casToString();

          
            if (lstliability[0].Permission == "Y")
              lblrbtnpermissiongrantedtosecdrive.Text = "Yes";
          else if (lstliability[0].Permission == "N")
              lblrbtnpermissiongrantedtosecdrive.Text = "No";


           lblnamesecDriver.Text = lstliability[0].Second_Driver_Name;
           lblsecdriveradd1 .Text = lstliability[0].Second_Driver_Address_1;
           lblsecdriveradd2 .Text = lstliability[0].Second_Driver_Address_2;
           
           lblsecdrivercity .Text = lstliability[0].Second_Driver_City;
           lblsecdriverstate .Text = lstliability[0].FK_State_Second_Driver.ToString();
           lblsecdriverzip .Text = lstliability[0].Second_Driver_Zip_Code;
           lblsecdriverphone .Text = lstliability[0].Second_Driver_Phone;
           lblsecdriverinscopmpany .Text = lstliability[0].Second_Driver_Ins_Company;
           lblsecdriverinspolicyno .Text = lstliability[0].Second_Driver_Ins_Number;
         

            if (lstliability[0].EMS_Contacted == "Y")
              lblrbtnEmergencyMedical.Text = "Yes";
          else if (lstliability[0].EMS_Contacted == "N")
              lblrbtnEmergencyMedical.Text = "No";
          
          lbllosspayee.Text = lstliability[0].Loss_Payee_Automobiles;

          if (lstliability[0].Suit_Date.ToString() != String.Empty)
          lblsuitdate.Text = Convert.ToDateTime(lstliability[0].Suit_Date.ToString()).ToShortDateString();

            if (lstliability[0].Attorney_Disclosure_Date.ToString() != String.Empty)
          lblattodiscdate.Text = Convert.ToDateTime(lstliability[0].Attorney_Disclosure_Date.ToString()).ToShortDateString();
          
          lblclientattoname.Text = lstliability[0].Client_Attorney_Name;
          lblclientattoadd1.Text = lstliability[0].Client_Attorney_Address_1;
          lblclientattoadd1.Text = lstliability[0].Client_Attorney_Address_2;
          lblclientattocity.Text = lstliability[0].Client_Attorney_City;
          lblclientattozip.Text = lstliability[0].Client_Attorney_Zip_Code;
          lblclientattophone.Text = lstliability[0].Client_Attorney_Phone;
          lblclientattoFasc.Text = lstliability[0].Client_Attorney_Fax;


          lbldefeattoname.Text = lstliability[0].Defense_Attorney_Name;
          lbldefeattoadd1.Text = lstliability[0].Defense_Attorney_Address_1;
          lbldefeattoadd2.Text = lstliability[0].Defense_Attorney_Address_2;
          lbldefeattocity.Text = lstliability[0].Defense_Attorney_City;
          lbldefeattozip.Text = lstliability[0].Defense_Attorney_Zip_Code;
          lbldefeattphone.Text = lstliability[0].Defense_Attorney_Phone;
          lbldefeattFasc.Text = lstliability[0].Defense_Attorney_Fax;

          if (lstliability[0].FK_State_Defense_Attorney != null)
          lbldefatoostate.Text = dwdefatoostate.Items.FindByValue(lstliability[0].FK_State_Defense_Attorney.ToString()).Text;



           if (lstliability[0].FK_State_Client_Attorney != null)
           lblStateClientAttorney.Text = dwStateClientAttorney.Items.FindByValue(lstliability[0].FK_State_Client_Attorney.ToString()).Text;
       // -- retirve Attachment Details.
       lstAttachment = BindAttachmentDetails();
       if (lstAttachment.Count > 0)
       {
           gvAttachView.DataSource = lstAttachment;
           gvAttachView.DataBind();
           btnRemove.Visible = true;
       }
       gvAttachView.Columns[0].Visible = false;
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

   #region RetriveByID

   private void RetriveDataByID()
    {
        objliability = new RIMS_Base.Biz.CLiabilityClaim();
        lstliability = new List<RIMS_Base.CLiabilityClaim>();
        Int32 Liabilityid = Convert.ToInt32(Session["WorkerCompID"].ToString());
        lstliability = objliability.Getility_ClaimByID(Liabilityid);

        if (lstliability.Count != 0)
        {



            lstproperty = objliability.Get_Property_ByID(Liabilityid, Convert.ToDecimal(lstliability[0].FK_Property));
            if (lstproperty.Count != 0)
            {

                txtproperty.Text = lstproperty[0].Stationary_Type;
                txtadd1.Text = lstproperty[0].Stationary_Address_1;
                txtadd2.Text = lstproperty[0].Stationary_Address_2;
                txtcityproperty.Text = lstproperty[0].Stationary_City;
                txtstate.Text = lstproperty[0].Stationary_State;
                txtzipproperty.Text = lstproperty[0].Stationary_Zip;
                //  txtcounty.Text = lstliability[0].Fk_Co
                lblentity.Text = lstproperty[0].FK_Entity.ToString();
                txtowenership.Text = lstproperty[0].Ownership;
                txtwhatfood.Text = lstproperty[0].Flood_Zone;
                txtnoofemployee.Text = lstproperty[0].Number_Of_Employees.ToString();
                txtbuilding.Text = lstproperty[0].Building.ToString();
                txtSigns.Text = lstproperty[0].Signs.ToString();
                txtcomputers.Text = lstproperty[0].Computers.ToString();
                txtATMS.Text = lstproperty[0].ATMs.ToString();
                txtATMS.Text = lstproperty[0].Lease_Improvements.ToString();
                txttotel.Text = lstproperty[0].Total.ToString();


 
           }

           lstCliamant = objliability.GetLiability_CliamantByID(Liabilityid, Convert.ToInt32(lstliability[0].FK_Employee_Claimant));
           if (lstCliamant.Count != 0)
           {
               txtlastname.Text = lstCliamant[0].Cliamant_Last_Name.Replace("''", "'");
               txtfirstname.Text = lstCliamant[0].Cliamant_First_Name.Replace("''", "'");
               txtmiddlename.Text = lstCliamant[0].Cliamant_Middle_Name.Replace("''", "'");
           }


           lstEmp = objliability.GetLiabilityEmp_Data_ByID(Liabilityid, Convert.ToInt32(lstliability[0].FK_Employee_Claimant), 1);
           if (lstEmp.Count != 0)
           {
               txtlastname.Text = lstEmp[0].Last_Name.Replace("''", "'");
               txtfirstname.Text = lstEmp[0].First_Name.Replace("''", "'");
               txtmiddlename.Text = lstEmp[0].Middle_Name.Replace("''", "'");
           }

           lstEmpAssign = objliability.GetLiabilityEmp_Data_ByID(Liabilityid, Convert.ToInt32(lstliability[0].FK_Employee), 2);
           if (lstEmpAssign.Count != 0)
           {
               txtassignfirst.Text = lstEmpAssign[0].First_Name.Replace("''", "'");
               txtassignmiddle.Text = lstEmpAssign[0].Middle_Name.Replace("''", "'");
               txtassignlast.Text = lstEmpAssign[0].Last_Name.Replace("''", "'");

           }

           lstCostCenter = objliability.GetLiability_CostCenterByID(Liabilityid, Convert.ToString(lstliability[0].FK_Cost_Center));
           if (lstCostCenter.Count != 0)
           {
               txtbranchname.Text = lstCostCenter[0].Division_Name; 

           }

           
            txtpropertyid.Text = lstliability[0].FK_Property.ToString();
            txtassigntid.Text = lstliability[0].FK_Employee.ToString();

            if (lstliability[0].Employee == "Y")
            {
                rbtntemployee.SelectedIndex = 0;
                txtclaimantid.Text = lstliability[0].FK_Employee_Claimant.ToString();
            }
            else if (lstliability[0].Employee == "N")
            {
                rbtntemployee.SelectedIndex = 1;
                txtidclaimant.Text = lstliability[0].FK_Employee_Claimant.ToString();
            }

             txtcosecenter.Text = lstliability[0].FK_Cost_Center;
             txtowner.Text = lstliability[0].Owner;
             txtAddLine1.Text = lstliability[0].Owner_Address_1;
             txtAddLine2.Text = lstliability[0].Owner_Address_2;
             txtcity.Text = lstliability[0].Owner_City;
             txtzipcode.Text = lstliability[0].Owner_Zip;
             txthomephone.Text = lstliability[0].Owner_Home_Phone;
             txtworkphone.Text = lstliability[0].Owner_Home_Phone;
             dwstateowner.SelectedIndex = dwstateowner.Items.IndexOf(dwstateowner.Items.FindByValue(lstliability[0].FK_State_Owner.ToString()));

             txtclaimDesc.Text = lstliability[0].Claim_Description;
             dwnaturofinc.SelectedIndex = dwnaturofinc.Items.IndexOf(dwnaturofinc.Items.FindByValue(lstliability[0].Nature.ToString()));
             txtEstimatetorepair.Text = lstliability[0].Actual.ToString();
             txtActualtorepair.Text = lstliability[0].Estimate.ToString();
             dwroadtype.SelectedIndex = dwroadtype.Items.IndexOf(dwroadtype.Items.FindByValue(lstliability[0].FK_Road_Type.ToString()));
             dwroadsurface.SelectedIndex = dwroadsurface.Items.IndexOf(dwroadsurface.Items.FindByValue(lstliability[0].FK_Road_Surface.ToString()));
             dwcause.SelectedIndex = dwcause.Items.IndexOf(dwcause.Items.FindByValue(lstliability[0].FK_Claim_Cause.ToString()));
             dwbodyparts.SelectedIndex = dwbodyparts.Items.IndexOf(dwbodyparts.Items.FindByValue(lstliability[0].FK_Body_Parts.ToString()));
             dwinjury.SelectedIndex = dwinjury.Items.IndexOf(dwinjury.Items.FindByValue(lstliability[0].FK_Injury.ToString()));
             dwNCCIcode.SelectedIndex = dwNCCIcode.Items.IndexOf(dwNCCIcode.Items.FindByValue(lstliability[0].FK_NCCI_Code.ToString()));
             dwNCCInature.SelectedIndex = dwNCCInature.Items.IndexOf(dwNCCInature.Items.FindByValue(lstliability[0].FK_NCCI_Nature.ToString()));
             dwHazardCode.SelectedIndex = dwHazardCode.Items.IndexOf(dwHazardCode.Items.FindByValue(lstliability[0].FK_Hazard_Code.ToString()));
             txtlocationdesc.Text = lstliability[0].Location_Description;
             dwComprehensiveDeductible.SelectedIndex = dwComprehensiveDeductible.Items.IndexOf(dwComprehensiveDeductible.Items.FindByValue(lstliability[0].FK_Comprehensive_Deductible.ToString()));
             dwoiginalcost.SelectedIndex = dwoiginalcost.Items.IndexOf(dwoiginalcost.Items.FindByValue(lstliability[0].FK_Original_Cost.ToString()));
             dwCollisionDeductible.SelectedIndex = dwCollisionDeductible.Items.IndexOf(dwCollisionDeductible.Items.FindByValue(lstliability[0].FK_Collision_Deductible.ToString()));
           //  dwmajorclaim.SelectedIndex = dwmajorclaim.Items.IndexOf(dwmajorclaim.Items.FindByValue(lstliability[0].FK_Liability_Major_Claim_Type.ToString()));
             dwminor.SelectedIndex = dwminor.Items.IndexOf(dwminor.Items.FindByValue(lstliability[0].FK_Liability_Minor_Claim_Type.ToString()));
             
            
            if (lstliability[0].Convertible == "Y")
                 rtnclaimconvert.SelectedIndex = 0;
             else if (lstliability[0].Convertible == "N")
                 rtnclaimconvert.SelectedIndex = 1;

             if (lstliability[0].Incident_Date.ToString() != String.Empty)
                 txtdateofinc.Text = Convert.ToDateTime(lstliability[0].Incident_Date.ToString()).ToShortDateString();

             dwFraudClaim.SelectedIndex = dwFraudClaim.Items.IndexOf(dwFraudClaim.Items.FindByValue(lstliability[0].FK_Fraud_Claim.ToString()));
             dwjuridicationstate.SelectedIndex = dwjuridicationstate.Items.IndexOf(dwjuridicationstate.Items.FindByValue(lstliability[0].FK_State_Jurisdiction.ToString()));

             if (lstliability[0].Date_Reported.ToString() != String.Empty)
                 txtincreported.Text = Convert.ToDateTime(lstliability[0].Date_Reported.ToString()).ToShortDateString();

             if (lstliability[0].Claim_Open_Date.ToString() != String.Empty)
               txtclaimopen.Text = Convert.ToDateTime(lstliability[0].Date_Reported.ToString()).ToShortDateString();


           if (lstliability[0].Claim_Close_Date.ToString() != String.Empty)
               txtclaimclosed.Text = Convert.ToDateTime(lstliability[0].Claim_Close_Date.ToString()).ToShortDateString();

           if (lstliability[0].Claim_Reopen_Date.ToString() != String.Empty)
               txtdateclaimreported.Text = Convert.ToDateTime(lstliability[0].Claim_Reopen_Date.ToString()).ToShortDateString();

           if (lstliability[0].Surgery_Required == "Y")
               rbtnsurgery.SelectedIndex = 0;
           else if (lstliability[0].Surgery_Required == "N")
               rbtnsurgery.SelectedIndex = 1;

           txtnoofweekssch.Text = lstliability[0].Indemnity_Weeks.ToString();


             if (lstliability[0].Criminal_Violation== "Y")
                 rbtncivilorcriminal.SelectedIndex = 0;
             else if (lstliability[0].Criminal_Violation == "N")
               rbtncivilorcriminal.SelectedIndex = 1;

            txtdescloss.Text = lstliability[0].Loss_Description;
            dwWeatherIncident.SelectedIndex = dwWeatherIncident.Items.IndexOf(dwWeatherIncident.Items.FindByValue(lstliability[0].FK_Weather_Incident.ToString()));

            txtpercentwindproloss1.Text = lstliability[0].Building_Percent_Wind.ToString();
            txtpercentfireproloss1.Text = lstliability[0].Building_Percent_Fire.ToString();
            txtpercentother1.Text = lstliability[0].Building_Percent_Other.ToString();
            txtpercentFlood.Text = lstliability[0].Building_Percent_Flood.ToString();

            txtpercentflood2.Text = lstliability[0].Contents_Percent_Flood.ToString();
            txtpercentwind2.Text = lstliability[0].Contents_Percent_Wind.ToString();
            txtpercentfire2.Text = lstliability[0].Contents_Percent_Fire.ToString();
            txtpercentother2.Text = lstliability[0].Contents_Percent_Other.ToString();

            txtpercentflood3.Text = lstliability[0].Computers_Percent_Flood.ToString();
            txtpercentWind3.Text = lstliability[0].Computers_Percent_Wind.ToString();
            txtpercentfire3.Text = lstliability[0].Computers_Percent_Fire.ToString();
            txtpercentother3.Text = lstliability[0].Computers_Percent_Other.ToString();

            txtpercentflood4.Text = lstliability[0].ATMs_Percent_Flood.ToString();
            txtpercentWind4.Text = lstliability[0].ATMs_Percent_Wind.ToString();
            txtpercentfire4.Text = lstliability[0].ATMs_Percent_Fire.ToString();
            txtpercentother4.Text = lstliability[0].ATMs_Percent_Other.ToString();

            txtpercentflood5.Text = lstliability[0].Leasehold_Improvements_Percent_Flood.ToString();
            txtpercentwind5.Text = lstliability[0].Leasehold_Improvements_Percent_Wind.ToString();
            txtpercentfire5.Text = lstliability[0].Leasehold_Improvements_Percent_Fire.ToString();
            txtpercentother5.Text = lstliability[0].Leasehold_Improvements_Percent_Other.ToString();

            txtpercentFlood6.Text = lstliability[0].Signs_Percent_Flood.ToString();
            txtpercentWind6.Text = lstliability[0].Signs_Percent_Wind.ToString();
            txtpercentFire6.Text = lstliability[0].Signs_Percent_Fire.ToString();
            txtpercentOther6.Text = lstliability[0].Signs_Percent_Other.ToString();

            txtpercentFlood7.Text = lstliability[0].Fine_Arts_Percent_Flood.ToString();
            txtpercentWind7.Text = lstliability[0].Fine_Arts_Percent_Wind.ToString();
            txtpercentFire7.Text = lstliability[0].Fine_Arts_Percent_Fire.ToString();
            txtpercentOther7.Text = lstliability[0].Fine_Arts_Percent_Other.ToString();


            if (lstliability[0].Reported_To_Police== "Y")
                 rbtnwasincidentrep.SelectedIndex = 0;
             else if (lstliability[0].Reported_To_Police == "N")
               rbtnwasincidentrep.SelectedIndex = 1;

           txtppliceoffname.Text = lstliability[0].Police_Officer;
           txtpoliceadd1.Text = lstliability[0].Police_Address_1;
           txtpoliceadd2.Text = lstliability[0].Police_Address_2;

           txtpolicecity.Text = lstliability[0].Police_City;
           txtpoliceZipcode.Text = lstliability[0].Police_Zip_Code;
           txtpolicephone.Text = lstliability[0].Police_Phone;
           txtpolicecommnts.Text = lstliability[0].Police_Comments;
           dwpolicestate.SelectedIndex = dwpolicestate.Items.IndexOf(dwpolicestate.Items.FindByValue(lstliability[0].FK_State_Police.ToString()));
          // dwwhethercond.SelectedIndex = dwwhethercond.Items.IndexOf(dwwhethercond.Items.FindByValue(lstliability[0].FK_Weather.ToString()));

           if (lstliability[0].Mobile_Restrictions == "Y")
               rbtnwheretravel.SelectedIndex = 0;
           else if (lstliability[0].Mobile_Restrictions == "N")
               rbtnwheretravel.SelectedIndex = 1;

           txtpoinofImpact.Text = lstliability[0].Mobile_Impact_Point;
           txtpartsdamage.Text = lstliability[0].Mobile_Parts_Damaged;
           txtmake.Text = lstliability[0].Vehicle_Make;
           txtmodel.Text = lstliability[0].Vehicle_Model;

           txtyearofmenu.Text = lstliability[0].Vehicle_Year.ToString();
           txtcolor.Text = lstliability[0].Vehicle_Color;
           txtvalue.Text = lstliability[0].Vehicle_Value.ToString();

           if (lstliability[0].Mobile_Towed== "Y")
               rbtnwasvehicletowed.SelectedIndex = 0;
           else if (lstliability[0].Mobile_Towed == "N")
               rbtnwasvehicletowed.SelectedIndex = 1;

           txtstoragelocation.Text = lstliability[0].Mobile_Storage_Location;
           txtdriverage.Text = lstliability[0].Driver_Age.ToString();
           
            
           if (lstliability[0].Permission == "Y")
               rbtnpermissiongrantedtosecdriver.SelectedIndex = 0;
           else if (lstliability[0].Permission == "N")
               rbtnpermissiongrantedtosecdriver.SelectedIndex = 1;

            txtnamesecDriver.Text = lstliability[0].Second_Driver_Name;
            txtsecdriveradd1.Text = lstliability[0].Second_Driver_Address_1;
            txtsecdriveradd1.Text = lstliability[0].Second_Driver_Address_2;
            txtsecdrivercity.Text = lstliability[0].Second_Driver_City;
            dwsecdriverstate.SelectedIndex = dwsecdriverstate.Items.IndexOf(dwsecdriverstate.Items.FindByValue(lstliability[0].FK_State_Second_Driver.ToString()));
            txtsecdriverzip.Text = lstliability[0].Second_Driver_Zip_Code;
            txtsecdriverphone.Text = lstliability[0].Second_Driver_Phone;
           
            txtsecdriverinscopmpany.Text = lstliability[0].Second_Driver_Ins_Company;
            txtsecdriverinspolicyno.Text = lstliability[0].Second_Driver_Ins_Number;
            txtlosspayee.Text = lstliability[0].Loss_Payee_Automobiles;
           
            if (lstliability[0].EMS_Contacted == "Y")
               rbtnEmergencyMedical.SelectedIndex = 0;
           else if (lstliability[0].EMS_Contacted == "N")
               rbtnEmergencyMedical.SelectedIndex = 1;

               if (lstliability[0].Suit_Date.ToString() != String.Empty)
               txtsuitdate.Text = Convert.ToDateTime(lstliability[0].Suit_Date.ToString()).ToShortDateString();

             if (lstliability[0].Attorney_Disclosure_Date.ToString() != String.Empty)
               txtattodiscdate.Text = Convert.ToDateTime(lstliability[0].Attorney_Disclosure_Date.ToString()).ToShortDateString();
             
            txtclientattoname.Text = lstliability[0].Client_Attorney_Name;
            txtclientattoadd1.Text = lstliability[0].Client_Attorney_Address_1;
            txtclientattoadd2.Text = lstliability[0].Client_Attorney_Address_2;
            txtclientattocity.Text = lstliability[0].Client_Attorney_City;
            txtclientattozip.Text = lstliability[0].Client_Attorney_Zip_Code;
            txtclientattophone.Text = lstliability[0].Client_Attorney_Phone;
            txtclientattoFasc.Text = lstliability[0].Client_Attorney_Phone;
            txtclientattoFasc.Text = lstliability[0].Client_Attorney_City;

            dwStateClientAttorney.SelectedIndex = dwStateClientAttorney.Items.IndexOf(dwStateClientAttorney.Items.FindByValue(lstliability[0].FK_State_Client_Attorney.ToString()));
            txtdefeattoname.Text = lstliability[0].Defense_Attorney_Name;
            txtdefeattoadd1.Text = lstliability[0].Defense_Attorney_Address_1;
            txtdefeattoadd2.Text = lstliability[0].Defense_Attorney_Address_2;
            txtdefeattocity.Text = lstliability[0].Defense_Attorney_City;
            txtdefeattozip.Text = lstliability[0].Defense_Attorney_Phone;
            dwdefatoostate.SelectedIndex = dwdefatoostate.Items.IndexOf(dwdefatoostate.Items.FindByValue(lstliability[0].FK_State_Defense_Attorney.ToString()));
            txtdefeattFasc.Text = lstliability[0].Defense_Attorney_Fax;

            txtproductname.Text = lstliability[0].Liability_Product_Name_new;

             lstAttachment = BindAttachmentDetails();
                 if (lstAttachment.Count > 0)
                 {
                     gvAttachmentDetails.DataSource = lstAttachment;
                     gvAttachmentDetails.DataBind();
                     //dispTagName.Value = "dvAttachDetails";
                     btnRemove.Visible = true;
                     btnMail.Visible = true;
                 }
                 else
                 {
                     btnRemove.Visible = false;
                     btnMail.Visible = false;
                 }
             }
             else
             {
                 btnRemove.Visible = false;
                 btnMail.Visible = false;
             }

               
           
       }
  

   #endregion

    private void ViewAllFromSearchGrid()
    {


        //dvAttachDetails.Style["display"] = "none";
        //divfirst.Style["display"] = "none";
        //divsecond.Style["display"] = "none";
        //divthird.Style["display"] = "none";
        //divfour.Style["display"] = "none";
        //divfive.Style["display"] = "none";
        //divsix.Style["display"] = "none";
        //divseven.Style["display"] = "none";
        //diveight.Style["display"] = "none";
        //divnine.Style["display"] = "none";
        //divten.Style["display"] = "none";
        //ViewDiv.Style["display"] = "block";

        //leftDiv.Style["display"] = "none";
        //divbtn.Style["display"] = "none";
        //mainContent.Style["display"] = "none";

        //Property.Style["display"] = "none";
        //Automobile.Style["display"] = "none";
        //General.Style["display"] = "none";


        //ViewData();

            objliability = new CLiabilityClaim();
            lstliability = new List<RIMS_Base.CLiabilityClaim>();
            lstliability = objliability.Getility_ClaimByID(Convert.ToInt32(Session["WorkerCompID"]));
            if (lstliability[0].FK_Liability_Major_Claim_Type == 1)
            {

                Automobile.Style["display"] = "none";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";

                viewdivfirst.Style["display"] = "block";
                viewdivsecond.Style["display"] = "block";
                viewdivthird.Style["display"] = "block";
                viewdivfour.Style["display"] = "none";
                viewdivfive.Style["display"] = "none";
                viewdivsix.Style["display"] = "none";
                viewdivseven.Style["display"] = "none";
                viewdiveight.Style["display"] = "block";
                viewdivnine.Style["display"] = "block";
                divviewAttach.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                mainContent.Style["display"] = "none";

                ViewDiv.Style["display"] = "block";

               
                ViewData();

            }

            else if (lstliability[0].FK_Liability_Major_Claim_Type == 2)
            {

                Automobile.Style["display"] = "none";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";

                ViewDiv.Style["display"] = "block";
                viewdivfirst.Style["display"] = "block";
                viewdivsecond.Style["display"] = "block";
                viewdivthird.Style["display"] = "block";
                viewdivfour.Style["display"] = "none";
                viewdivfive.Style["display"] = "none";
                viewdivsix.Style["display"] = "none";
                viewdivseven.Style["display"] = "none";
                viewdiveight.Style["display"] = "none";
                viewdivnine.Style["display"] = "block";
                divviewAttach.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                mainContent.Style["display"] = "none";
               
                ViewData();
            }

            else if (lstliability[0].FK_Liability_Major_Claim_Type == 3)
            {

                Automobile.Style["display"] = "none";
                General.Style["display"] = "none";
                Property.Style["display"] = "none";
                leftDiv.Style["display"] = "none";

                viewdivfirst.Style["display"] = "block";
                viewdivsecond.Style["display"] = "block";
                viewdivthird.Style["display"] = "block";
                viewdivfour.Style["display"] = "block";
                viewdivfive.Style["display"] = "block";
                viewdivsix.Style["display"] = "block";
                viewdivseven.Style["display"] = "block";
                viewdiveight.Style["display"] = "none";
                viewdivnine.Style["display"] = "block";
                divviewAttach.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                mainContent.Style["display"] = "none";

                ViewDiv.Style["display"] = "block";
                              
                ViewData();
            }


           



    }


   #region Attachment
    private void UploadDocuments()
   {
       try
       {
           m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

           if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
           {
               Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
           }
           m_strFileName = GetCustomFileName() + uplCommon.FileName.ToString();
           m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
           uplCommon.SaveAs(m_strPath);

       }
       catch (Exception ex)
       {

           throw ex;
       }
   }

   private string GetCustomFileName()
   {
       try
       {
           m_strCustomFileName = System.DateTime.Now.ToString("MMddyyhhmmss");
       }
       catch (Exception ex)
       {
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
           InsertData();
           UploadDocuments();
           m_objAttachment = new RIMS_Base.Biz.CAttachment();
           m_objAttachment.Attachment_Table = "Liability_Claim";
           m_objAttachment.Foreign_Key = Convert.ToInt32(ViewState["PK_Liability_Claim"].ToString());
           m_objAttachment.FK_Attachment_Type = Convert.ToInt32(ddlAttachType.SelectedValue);
           m_objAttachment.Attachment_Description = txtAttachDesc.Text.Replace("'", "''");
           m_objAttachment.Attachment_Name = m_strFileName;
           m_objAttachment.Updated_By = "1";
           m_objAttachment.Update_Date = System.DateTime.Now.Date;
           Attach_Retval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);


       }
       catch (Exception ex)
       {
           throw ex;
       }
       return Attach_Retval;
   }

   private List<RIMS_Base.CAttachment> BindAttachmentDetails()
   {
       try
       {
           m_objAttachment = new RIMS_Base.Biz.CAttachment();
           lstAttachment = new List<RIMS_Base.CAttachment>();
           if (ViewState["PK_Liability_Claim"] != null && ViewState["PK_Liability_Claim"].ToString() != "")
               lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(ViewState["PK_Liability_Claim"].ToString()), "Liability_Claim");

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
 #endregion

 #endregion
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReserveWorksheetHistoryGrid.aspx");
    }

    protected void btnViewNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReserveWorksheetHistoryGrid.aspx");
    }
    protected void rbtntemployee_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rbtntemployee.SelectedIndex == 0)
            Button1.Attributes.Add("OnClick", "javascript:return openEmployeeWindow();");

        else if(rbtntemployee.SelectedIndex == 1)
            Button1.Attributes.Add("OnClick", "javascript:return openClaimantWindow1();");

        
    }
}
