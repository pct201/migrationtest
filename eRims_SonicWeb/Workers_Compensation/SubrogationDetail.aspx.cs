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

public partial class WorkerCompensation_SubrogationDetail : System.Web.UI.Page
{
    #region Variable

    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;
    RIMS_Base.Biz.cSubrogationDetail objSubrogationDetail;
    List<RIMS_Base.cSubrogationDetail> lstSubrogationDetail;
    int Subrogation_retVal = -1;
    int Pk_SubrogationDetail = -1;
    public RIMS_Base.Biz.CGeneral objGeneral;

    // -- Attachment
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "Worker_Comp_Subrogation_Detail";
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    int Attach_Retval = -1;

    //
    private System.Collections.ArrayList objList=  new System.Collections.ArrayList();
    private System.Collections.ArrayList arrErrorMessage =  new System.Collections.ArrayList();
    private int iAlertType = 0;

#endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRoleId"] != null)
        {
            m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Worker_Comp_Subrogation_Detail/");
            
            if (!IsPostBack)
            {
                ViewState.Clear();
                hdnTagName.Value = "";
                BindCombos();

                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
               
                btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");

                if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
                {
                    RIMS_Base.Biz.CWorkersComp objWorkerComp = new RIMS_Base.Biz.CWorkersComp();
                    List<RIMS_Base.CWorkersComp> lstWorkerComp = new List<RIMS_Base.CWorkersComp>();
                    try
                    {
                        lstWorkerComp = objWorkerComp.Get_Worker_CompensationByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
                        string Claim_No = lstWorkerComp[0].Claim_Number;
                        DisplayEmployeeInfo(Claim_No);
                    }
                    catch (Exception ex)
                    {
                        throw ex; 
                    }
                    finally
                    {
                        objWorkerComp = null;
                        lstWorkerComp = null;
                    }
                    //ViewAllFromSearchGrid();
                    if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                    {
                        DisplayDynamicLabelsForViewALL();
                        ViewAllFromSearchGrid();
                    }
                    else
                    {
                        DisplayDynamicLabels();
                        RetriveData();
                    }
                }
                else
                {
                    DisplayDynamicLabels();
                }
            }
        }
        else
        {
            Response.Redirect("../Signin.aspx", false);
        }
    }
    #region Employee Information
    private void DisplayEmployeeInfo(string claimNO)
    {
        m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
        lstClaimReservesInfo = new List<RIMS_Base.CCheckWriting>();
        lstClaimReservesInfo = m_objClaimReservesInfo.GetWorkerCompClaimInfoByClaimNo(claimNO);
        lblClaimNum.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
        ViewState["TableName"] = lstClaimReservesInfo[0].TableName.ToString();
        ViewState["TableFK"] = lstClaimReservesInfo[0].TableFK.ToString();

        //if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
        //    rbtnEmployee.Items[0].Selected = true;
        //else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
        //    rbtnEmployee.Items[1].Selected = true;

        rbtnEmployee.Items[0].Selected = true;


        lblLName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDateIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        // --- For the View Page
        //if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
        //    lblEmp.Text = "Yes";
        //else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
        //    lblEmp.Text = "No";

        lblEmp.Text = "Yes";

        lblLastName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFirName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMiddleName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDOIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        lblClaim_No.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
    }
    #endregion

    protected void BindCombos()
    {
        objGeneral = new RIMS_Base.Biz.CGeneral();
        dwThirdState.DataSource = objGeneral.GetAllState();
        dwThirdState.DataTextField = "FLD_state";
        dwThirdState.DataValueField = "PK_ID";
        dwThirdState.DataBind();
        dwThirdState.Items.Insert(0, "--Select State--");

        dwThirdAdmnState.DataSource = objGeneral.GetAllState();
        dwThirdAdmnState.DataTextField = "FLD_state";
        dwThirdAdmnState.DataValueField = "PK_ID";
        dwThirdAdmnState.DataBind();
        dwThirdAdmnState.Items.Insert(0, "--Select State--");

        ddlAttachType.DataSource = objGeneral.GetAttachamentType();
        ddlAttachType.DataTextField = "FLD_Desc";
        ddlAttachType.DataValueField = "FLD_Code";
        ddlAttachType.DataBind();
        ddlAttachType.Items.Insert(0, "--Select Attachment Type--");
        ddlAttachType.SelectedIndex = 1;
    }

    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        InsertUpdateData();
        Response.Redirect("../Workers_Compensation/CheckRegister.aspx");
    }
       
    private void InsertUpdateData()
    {
        try
        {
            objSubrogationDetail = new RIMS_Base.Biz.cSubrogationDetail();
            if (ViewState["Pk_SubrogationDetail"] != null && ViewState["Pk_SubrogationDetail"].ToString() != String.Empty)
            {
                objSubrogationDetail.PK_Subrogation_detail = Convert.ToInt32(ViewState["Pk_SubrogationDetail"].ToString());
                objSubrogationDetail.Updated_By = Session["UserID"].ToString();
                objSubrogationDetail.Update_Date = DateTime.Now;
            }
            objSubrogationDetail.FK_Table_Name = Convert.ToDecimal(ViewState["TableFK"].ToString());
            objSubrogationDetail.Table_Name = ViewState["TableName"].ToString();
            objSubrogationDetail.Policy_Company = txtAppInsPolCompName.Text.Trim().Replace("'", "''");
            objSubrogationDetail.Policy = txtAppInsuPolicy.Text.Trim().Replace("'", "''");
            objSubrogationDetail.Claim_Adjuster = txtAdjusterOnClaim.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TP_Name=txt3Name.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TP_Address_1 = txt3Add1.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TP_Address_2 = txt3Add2.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TP_City = txt3City.Text.Trim().Replace("'", "''");
            if(dwThirdState.SelectedIndex!=0)
                objSubrogationDetail.FK_State_TP = Convert.ToDecimal(dwThirdState.SelectedItem.Value);
            objSubrogationDetail.TP_Zip_Code = txt3Zip.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TP_Telephone = txt3TelNo.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TP_Insurance_Company = txt3InsuranceComp.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TP_Insurance_Number = txt3InsuranceNo.Text.Trim().Replace("'", "''");
            if (txtDONotice.Text != String.Empty)
                objSubrogationDetail.Notice_Date = Convert.ToDateTime(txtDONotice.Text);
            objSubrogationDetail.TPA = txt3Admin.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TPA_Contact = txt3AdminContact.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TPA_Address_1 = txt3AdminAdd1.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TPA_Address_2 = txt3AdminAdd2.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TPA_City = txt3AdminCity.Text.Trim().Replace("'", "''");
            if(dwThirdAdmnState.SelectedIndex!=0)
                objSubrogationDetail.FK_State_TPA= Convert.ToDecimal(dwThirdAdmnState.SelectedItem.Value);
            objSubrogationDetail.TPA_Zip_Code = txt3AdminZip.Text.Trim().Replace("'", "''");
            objSubrogationDetail.TPA_Telephone = txt3AdminTel.Text.Trim().Replace("'", "''");
            if(txtAmtOfRecovery.Text !="")
                objSubrogationDetail.Recovery=Convert.ToDecimal(txtAmtOfRecovery.Text.Trim().Replace("'", "''"));
            if(txtAmtReceive.Text !="")
                objSubrogationDetail.Received=Convert.ToDecimal(txtAmtReceive.Text.Trim().Replace("'", "''"));

           Subrogation_retVal = objSubrogationDetail.InsertUpdateSubrogationDetail(objSubrogationDetail);
           ViewState["Pk_SubrogationDetail"] = Subrogation_retVal;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void RetriveData()
    {
        objSubrogationDetail = new RIMS_Base.Biz.cSubrogationDetail();
        lstSubrogationDetail = new List<RIMS_Base.cSubrogationDetail>();
        if(ViewState["TableFK"]!=null && ViewState["TableFK"].ToString()!="")
        {
            lstSubrogationDetail = objSubrogationDetail.GetSubrogationDetailByID(Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
        }
        if (lstSubrogationDetail.Count > 0)
        {
            ViewState["Pk_SubrogationDetail"] = lstSubrogationDetail[0].PK_Subrogation_detail;
            txtAppInsPolCompName.Text = lstSubrogationDetail[0].Policy_Company;
            txtAppInsuPolicy.Text = lstSubrogationDetail[0].Policy;
            txtAdjusterOnClaim.Text = lstSubrogationDetail[0].Claim_Adjuster;
            txt3Name.Text = lstSubrogationDetail[0].TP_Name;
            txt3Add1.Text = lstSubrogationDetail[0].TP_Address_1;
            txt3Add2.Text = lstSubrogationDetail[0].TP_Address_2;
            txt3City.Text = lstSubrogationDetail[0].TP_City;
            if (lstSubrogationDetail[0].FK_State_TP.ToString() != String.Empty)
                dwThirdState.SelectedIndex = dwThirdState.Items.IndexOf(dwThirdState.Items.FindByValue(lstSubrogationDetail[0].FK_State_TP.ToString()));
            txt3Zip.Text = lstSubrogationDetail[0].TP_Zip_Code;
            txt3TelNo.Text = lstSubrogationDetail[0].TP_Telephone;
            txt3InsuranceComp.Text = lstSubrogationDetail[0].TP_Insurance_Company;
            txt3InsuranceNo.Text = lstSubrogationDetail[0].TP_Insurance_Number;
            if (lstSubrogationDetail[0].Notice_Date.ToString() != String.Empty)
                txtDONotice.Text = Convert.ToDateTime(lstSubrogationDetail[0].Notice_Date).ToShortDateString();
            txt3Admin.Text = lstSubrogationDetail[0].TPA;
            txt3AdminContact.Text = lstSubrogationDetail[0].TPA_Contact;
            txt3AdminAdd1.Text = lstSubrogationDetail[0].TPA_Address_1;
            txt3AdminAdd2.Text = lstSubrogationDetail[0].TPA_Address_2;
            txt3AdminCity.Text = lstSubrogationDetail[0].TPA_City;
            if (lstSubrogationDetail[0].FK_State_TPA.ToString() != String.Empty)
                dwThirdAdmnState.SelectedIndex = dwThirdAdmnState.Items.IndexOf(dwThirdAdmnState.Items.FindByValue(lstSubrogationDetail[0].FK_State_TPA.ToString()));
            txt3AdminZip.Text = lstSubrogationDetail[0].TPA_Zip_Code;
            txt3AdminTel.Text = lstSubrogationDetail[0].TPA_Telephone;
            txtAmtOfRecovery.Text = lstSubrogationDetail[0].Recovery.ToString();
            txtAmtReceive.Text = lstSubrogationDetail[0].Received.ToString();

            gvAttachmentDetails.DataSource= BindAttachmentDetails();
            gvAttachmentDetails.DataBind();

            if (lstAttachment.Count <= 0)
            {
                btnRemove.Visible = false;
            }
        }
    }

    #region Attachment

    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Worker_Comp_Subrogation_Detail&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

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
            //Log.Append("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:" + ex.Message);
            //Common.reportError("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:", ex.Message);
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
    
    private int AddAttachment()
    {
        try
        {
            //InsertUpdateData();
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "SubrogationDetail";
            m_objAttachment.Foreign_Key = Convert.ToInt32(ViewState["Pk_SubrogationDetail"].ToString());
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(ddlAttachType.SelectedValue);
            m_objAttachment.Attachment_Description = txtDescription.Text.Replace("'", "''");
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = Session["UserID"].ToString();
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            Attach_Retval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Attach_Retval;
    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        InsertUpdateData();
        dvAttachDetails.Style["display"] = "block";
        divAttachment.Style["display"] = "block";
        divClaimDetail.Style["display"] = "none";
        divInsurance.Style["display"] = "none";

        hdnTagName.Value = "third";

        AddAttachment();

        ddlAttachType.SelectedIndex = 1;
        txtDescription.Text = "";

        if (Attach_Retval > 0)
        {
            gvAttachmentDetails.DataSource = BindAttachmentDetails();
            gvAttachmentDetails.DataBind();

        }
        btnRemove.Visible = true;
        //dispTagName.Value = "divthird";
    }
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            if(ViewState["Pk_SubrogationDetail"] !=null && ViewState["Pk_SubrogationDetail"].ToString() != string.Empty)
                lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(ViewState["Pk_SubrogationDetail"].ToString()), "SubrogationDetail");
            else
                lstAttachment = m_objAttachment.GetAll(0, 0, "SubrogationDetail");

            if (lstAttachment.Count > 0)
            {
                btnRemove.Visible = true;
                btnMail.Visible = true;
                //btnViewMail.Visible = true;
            }
            else
            {
                btnRemove.Visible = false;
                btnMail.Visible = false;
                //btnViewMail.Visible = false;
            }
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
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            Attach_Retval = m_objAttachment.DeleteAttachment(Request.Form["chkItem"].ToString());
            if (Attach_Retval <= 0)
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
            divAttachment.Style["display"] = "block";
            divClaimDetail.Style["display"] = "none";
            divInsurance.Style["display"] = "none";

            hdnTagName.Value = "third";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Save&View

    protected void btnViewNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Workers_Compensation/CheckRegister.aspx");
    }

    private void ViewAllFromSearchGrid()
    {
        DisplayDataInView();
        divSaveView.Style["display"] = "block";

        divbtn.Style["display"] = "none";
        mainContent.Style["display"] = "none";
        leftdiv.Style["display"] = "none";
        btnBack.Visible = false;
        btnViewNext.Visible = true;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        divSaveView.Style["display"] = "none";

        divbtn.Style["display"] = "block";
        mainContent.Style["display"] = "block";        
        leftdiv.Style["display"] = "block";
    }
    protected void btnSaveView_Click(object sender, EventArgs e)
    {
        DisplayDynamicLabelsForViewALL();
        InsertUpdateData();
        DisplayDataInView();
        divSaveView.Style["display"] = "block";

        divbtn.Style["display"] = "none";
        mainContent.Style["display"] = "none";
        leftdiv.Style["display"] = "none";
    }

    protected void gvAttachView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Worker_Comp_Subrogation_Detail&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void DisplayDataInView()
    {
        objSubrogationDetail = new RIMS_Base.Biz.cSubrogationDetail();
        lstSubrogationDetail = new List<RIMS_Base.cSubrogationDetail>();
        if(ViewState["TableFK"]!=null && ViewState["TableFK"].ToString()!="")
        {
            lstSubrogationDetail = objSubrogationDetail.GetSubrogationDetailByID(Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
        }
        if (lstSubrogationDetail.Count > 0)
        {
            ViewState["Pk_SubrogationDetail"] = lstSubrogationDetail[0].PK_Subrogation_detail;
            lblVDAppInsPolCompName.Text = lstSubrogationDetail[0].Policy_Company;
            lblVDAppInsuPolicy.Text = lstSubrogationDetail[0].Policy;
            lblVDAdjusterOnClaim.Text = lstSubrogationDetail[0].Claim_Adjuster;
            lblVD3Name.Text = lstSubrogationDetail[0].TP_Name;
            lblVD3Add1.Text = lstSubrogationDetail[0].TP_Address_1;
            lblVD3Add2.Text = lstSubrogationDetail[0].TP_Address_2;
            lblVD3City.Text = lstSubrogationDetail[0].TP_City;
            if (lstSubrogationDetail[0].FK_State_TP.ToString() != String.Empty)
                lblVD3State.Text = dwThirdState.Items.FindByValue(lstSubrogationDetail[0].FK_State_TP.ToString()).Text;
            lblVD3Zip.Text = lstSubrogationDetail[0].TP_Zip_Code;
            lblVD3TelNo.Text = lstSubrogationDetail[0].TP_Telephone;
            lblVD3InsuranceComp.Text = lstSubrogationDetail[0].TP_Insurance_Company;
            lblVD3InsuranceNo.Text = lstSubrogationDetail[0].TP_Insurance_Number;
            if (lstSubrogationDetail[0].Notice_Date.ToString() != String.Empty)
                lblVDDONotice.Text = Convert.ToDateTime(lstSubrogationDetail[0].Notice_Date).ToShortDateString();
            lblVD3Admin.Text = lstSubrogationDetail[0].TPA;
            lblVD3AdminContact.Text = lstSubrogationDetail[0].TPA_Contact;
            lblVD3AdminAdd1.Text = lstSubrogationDetail[0].TPA_Address_1;
            lblVD3AdminAdd2.Text = lstSubrogationDetail[0].TPA_Address_2;
            lblVD3AdminCity.Text = lstSubrogationDetail[0].TPA_City;
            if (lstSubrogationDetail[0].FK_State_TPA.ToString() != String.Empty)
                lblVD3AdminState.Text = dwThirdAdmnState.Items.FindByValue(lstSubrogationDetail[0].FK_State_TPA.ToString()).Text;
            lblVD3AdminZip.Text = lstSubrogationDetail[0].TPA_Zip_Code;
            lblVD3AdminTel.Text = lstSubrogationDetail[0].TPA_Telephone;
            lblVDAmtOfRecovery.Text = String.Format("{0:c}", lstSubrogationDetail[0].Recovery);
            lblVDAmtReceive.Text = String.Format("{0:c}", lstSubrogationDetail[0].Received);

            gvAttachView.DataSource = BindAttachmentDetails();
            gvAttachView.DataBind();
            gvAttachView.Columns[0].Visible = false;
        }
    }

    #endregion

    // --- Alert message using coding.
    //public void AddControlToValidate(TextBox objCtl, string strErrorMessage)
    //{
    //    objList.Add(objCtl);
    //    arrErrorMessage.Add(strErrorMessage);
    //}

    //protected override void OnInit(EventArgs e)
    //{
    //    base.OnInit(e);
    //    Page.RegisterOnSubmitStatement("GroupValidation",
    //                    "return ValidateGroupControl();");
    //}
    //protected override void OnPreRender(EventArgs e)
    //{
    //    base.OnPreRender(e);
    //    System.Text.StringBuilder strJavaScript = new System.Text.StringBuilder();

    //    //Generate the Validation Event to Validate control

    //    strJavaScript.Append(@"<script langauge='javascript'>");
    //    strJavaScript.Append(@"function ValidateGroupControl(){var msg='<ui>'; var strError='';");
    //    for (int i = 0; i < objList.Count; i++)
    //    {
    //        strJavaScript.Append(@"if( document.all['ctl00_ContentPlaceHolder1_" +
    //                                 ((TextBox)objList[i]).ID + "'].value==''){");
    //        //Add Alert is Type is set to Alert else 

    //        //build the error message string to be displayed

    //        if (iAlertType == 0)
    //        {
    //            //strJavaScript.Append(@"alert('" + (string)arrErrorMessage[i] +
    //            //                      "');document.all['ctl00_ContentPlaceHolder1_" + ((TextBox)objList[i]).ID +
    //            //                      "'].focus();return false;}");

    //            strJavaScript.Append(@"strError=+'" + (string)arrErrorMessage[i] +
    //                                  "';}");

    //        }
    //        else
    //        {
    //            strJavaScript.Append(@"msg=msg+'<li>" +
    //                                 (string)arrErrorMessage[i] + "</li>';}");
    //        }
    //    }
    //    strJavaScript.Append(@"if(strError.length > 0){ alert(strError); return false; } else { return true; }}</script>");
    //    if (iAlertType == 1)
    //    {
    //        strJavaScript.Append(@"if(msg!=''){document.all['" +
    //                  this.ID + "'].innerHTML=msg+'</ui>';return false;}");
    //    }

    //    //strJavaScript.Append(@"return true;}</script>");
    //    Page.RegisterClientScriptBlock("funValidate", strJavaScript.ToString());
    //}

    #region Display Dynamic Labels
    // -- This lables for the EDIT and ADD 
    private void DisplayDynamicLabels()
    {
        try
        {
            DataSet dstSubrogationDetail = new DataSet();
            objSubrogationDetail = new RIMS_Base.Biz.cSubrogationDetail();
            dstSubrogationDetail = objSubrogationDetail.GetSubrogationDetailLabel();
            for (int i = 0; i < dstSubrogationDetail.Tables[0].Rows.Count; i++)
            {
                if (dstSubrogationDetail.Tables[0].Rows[i]["Control_Type"].ToString() == "Label")
                {
                    if (dstSubrogationDetail.Tables[0].Rows[i]["Control_Name"].ToString() == "Insurance Information")
                    {
                        if (dstSubrogationDetail.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            ((Label)divInsurance.FindControl(dstSubrogationDetail.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSubrogationDetail.Tables[0].Rows[i]["Caption"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    public void DisplayDynamicLabelsForViewALL()
    {
        try
        {
            DataSet dstSubrogationDetail = new DataSet();
            objSubrogationDetail = new RIMS_Base.Biz.cSubrogationDetail();
            dstSubrogationDetail = objSubrogationDetail.GetSubrogationDetailLabel();
            for (int i = 0; i < dstSubrogationDetail.Tables[0].Rows.Count; i++)
            {
                if (dstSubrogationDetail.Tables[0].Rows[i]["Control_Type"].ToString() == "Label" && dstSubrogationDetail.Tables[0].Rows[i]["ViewAll_Label_Name"].ToString() != String.Empty)
                {
                    if (dstSubrogationDetail.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                        ((Label)divSaveView.FindControl(dstSubrogationDetail.Tables[0].Rows[i]["ViewAll_Label_Name"].ToString())).Text = dstSubrogationDetail.Tables[0].Rows[i]["caption"].ToString();
                }
            }

        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    #endregion
}
