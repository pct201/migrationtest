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


public partial class Claim_Workers__Compensation : System.Web.UI.Page
{
    #region Private Variables
    public RIMS_Base.Biz.CGeneral objGeneral;
    public RIMS_Base.Biz.CWorkersComp objWorkersComp;
    int m_intRetval = -1;
    // List<RIMS_Base.CCheckRegister> lstCheckRegister = null;
    List<RIMS_Base.CWorkersComp> lstWorkercomp, lstCliamant, lstPolicy;


    public RIMS_Base.Biz.CCheckRegister objCheckRegister;
    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;
    // -- Attachment
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "Workers_Comp";
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    List<RIMS_Base.CCheckRegister> lstCheckRegister = null;
    //public RIMS_Base.Biz.CCheckRegister objCheckRegister;
    int Attach_Retval = -1;
    #endregion

    #region Event Handler
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["Mode"] == "Add")
        {
            Session["WorkerCompID"] = null;
            Session["ViewAll"] = null;
        }

        txtCompRate.Attributes.Add("onKeyPress", "isValid(this)");
        m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Workers_Comp/");
        if (!IsPostBack)
        {
            btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");
            ViewState.Clear();
            dispTagName.Value = "";
            bindCombo();
            btnRemove.Visible = false;
            btnMail.Visible = false;
            gvAttachmentDetails.DataSource = lstAttachment;
            gvAttachmentDetails.DataBind();
            hdnAttachmentChkBox.Value = "NotDisplay";
            if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
            {
                ViewState["PK_Workers_Comp"] = Session["WorkerCompID"].ToString();


                if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                {
                    //View
                    ViewAllFromSearchGrid();
                }
                else
                {
                    //Edit
                    RetriveDataByID();
                    // DispalayCheckRegisterData();

                }
                lblsep.Visible = true;
                lblClaimNumber.Visible = true;
                Div1.Style.Add("display", "block");
                dvDisable.Style.Add("display", "none");
            }
            else
            {

                Div1.Style.Add("display", "none");
                dvDisable.Style.Add("display", "block");
            }





        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "none";
        divsecond.Style["display"] = "none";
        divthird.Style["display"] = "none";
        divfour.Style["display"] = "none";
        LeftDiv.Style["display"] = "none";
        ViewDiv.Style["display"] = "block";
        divbtn.Style["display"] = "none";
        mainContent.Style["display"] = "none";



        InsertData();

        ViewData();

        Div1.Style.Add("display", "block");
        dvDisable.Style.Add("display", "none");

        btnBack.Visible = false;
        btnViewBack.Visible = true;
    }
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        InsertData();
        Response.Redirect("~/Workers_Compensation/WorkerCompensationReserve.aspx");


    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        dvAttachDetails.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divsecond.Style["display"] = "none";
        divthird.Style["display"] = "none";
        divfour.Style["display"] = "block";
        LeftDiv.Style["display"] = "block";
        //ViewD.Style["display"] = "none";
        btnRemove.Visible = true;
        btnMail.Visible = true;
        InsertData();
        AddAttachment();
        if (Attach_Retval > 0)
        {
            gvAttachmentDetails.DataSource = BindAttachmentDetails();
            gvAttachmentDetails.DataBind();

        }
        // dispTagName.Value = "divten";
        txtAttachDesc.Text = "";
        ddlAttachType.SelectedIndex = 1;
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
            dvAttachDetails.Style["display"] = "block";
            divfirst.Style["display"] = "none";
            divsecond.Style["display"] = "none";
            divthird.Style["display"] = "none";
            divfour.Style["display"] = "block";
            //ViewDiv.Style["display"] = "none";
            LeftDiv.Style["display"] = "block";

            // --- highlight the third menu of the Left side.
            // dispTagName.Value = "divten";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {


        Response.Redirect("~/Workers_Compensation/WorkerCompensationReserve.aspx");

    }
    protected void btnViewBack_Click(object sender, EventArgs e)
    {
        divfirst.Style["display"] = "block";
        ViewDiv.Style["display"] = "none";
        mainContent.Style["display"] = "block";
        LeftDiv.Style["display"] = "block";
        divbtn.Style["display"] = "block";

        //-- for the javascript getten()
        hdnAttachmentChkBox.Value = "Display";
        btnBack.Visible = true;
        btnViewBack.Visible = false;
    }
    #endregion

    #region Private Method
    #region Bind All Combos
    private void bindCombo()
    {
        objGeneral = new RIMS_Base.Biz.CGeneral();
        ddlBenefitState.DataSource = objGeneral.GetAllState();
        ddlBenefitState.DataTextField = "FLD_state";
        ddlBenefitState.DataValueField = "Code";
        ddlBenefitState.DataBind();
        ListItem lstItem = new ListItem(" ---------------Select--------------- ", "0");
        ddlBenefitState.Items.Insert(0, lstItem);

        ddlBodyParts.DataSource = objGeneral.GetBodyParts();
        ddlBodyParts.DataTextField = "FLD_desc_Body";
        ddlBodyParts.DataValueField = "PK_ID_Body";
        ddlBodyParts.DataBind();
        ListItem lstbody = new ListItem(" ----------------------------------------------------------------Select----------------------------------------------------------------", "0");
        ddlBodyParts.Items.Insert(0, lstbody);


        dwEntity.DataSource = objGeneral.GetAllEntity();
        dwEntity.DataTextField = "Entity_Description";
        dwEntity.DataValueField = "PK_Entity";
        dwEntity.DataBind();
        ListItem lstItemEntity = new ListItem("----------------------------------------------------------------Select----------------------------------------------------------------", "0");
        dwEntity.Items.Insert(0, lstItemEntity);

        ddlCauseCode.DataSource = objGeneral.GetClaimCause();
        ddlCauseCode.DataTextField = "Claim_Cause_FLD_desc";
        ddlCauseCode.DataValueField = "Claim_Cause_PK_ID";
        ddlCauseCode.DataBind();
        ListItem lstcause = new ListItem(" ----------------------------------------------------------------Select----------------------------------------------------------------", "0");
        ddlCauseCode.Items.Insert(0, lstcause);

        ddlinjuryCode.DataSource = objGeneral.GetInjuryCode();
        ddlinjuryCode.DataTextField = "injury_FLD_desc";
        ddlinjuryCode.DataValueField = "injury_PK_ID";
        ddlinjuryCode.DataBind();
        ListItem lstinjury = new ListItem(" ----------------------------------------------------------------Select----------------------------------------------------------------", "0");
        ddlinjuryCode.Items.Insert(0, lstinjury);
    }
    #endregion

    private void InsertData()
    {
        try
        {
            objWorkersComp = new RIMS_Base.Biz.CWorkersComp();
            if (ViewState["PK_Workers_Comp"] != null && ViewState["PK_Workers_Comp"].ToString() != String.Empty)
            {
                objWorkersComp.PK_Workers_Comp = Convert.ToInt32(ViewState["PK_Workers_Comp"].ToString());

            }
            //....................Claim Identification....................................

            if (rbtStatus.SelectedIndex == 0)
                objWorkersComp.Status = "O";
            else if (rbtStatus.SelectedIndex == 1)
                objWorkersComp.Status = "C";
            else if (rbtStatus.SelectedIndex == 2)
                objWorkersComp.Status = "R";

            if (txtempid.Text != String.Empty)
                objWorkersComp.FK_Claimant = Convert.ToDecimal(txtempid.Text.ToString());

            if (txtCarrierClaimNo.Text != String.Empty)
                objWorkersComp.Carrier_Claim_Number = txtCarrierClaimNo.Text.Trim();

            if (txtDateReportedtoFair.Text != String.Empty)
                objWorkersComp.Date_Reported_To_FairPoint = Convert.ToDateTime(txtDateReportedtoFair.Text);

            if (txtDateClaimOpened.Text != String.Empty)
                objWorkersComp.Date_Claim_Opened = Convert.ToDateTime(txtDateClaimOpened.Text);

            if (rbtnUnion.SelectedIndex == 0)
                objWorkersComp.Union_Member = "Y";
            else if (rbtnUnion.SelectedIndex == 1)
                objWorkersComp.Union_Member = "N";

            if (txtDateClaimClosed.Text != String.Empty)
                objWorkersComp.Date_Claim_Closed = Convert.ToDateTime(txtDateClaimClosed.Text);

            if (dwEntity.SelectedIndex != 0)
                objWorkersComp.FK_Entity = Convert.ToDecimal(dwEntity.SelectedValue.ToString());

            if (txtDateClaimReopened.Text != String.Empty)
                objWorkersComp.Date_Claim_Reopened = Convert.ToDateTime(txtDateClaimReopened.Text);

            if (txtDateofLoss.Text != String.Empty)
                objWorkersComp.Date_Of_Incident = Convert.ToDateTime(txtDateofLoss.Text);

            if (txtlblDateReportedtoCarrier.Text != String.Empty)
                objWorkersComp.Date_Reported_To_Carrier = Convert.ToDateTime(txtlblDateReportedtoCarrier.Text);

            if (ddlBenefitState.SelectedIndex != 0)
                objWorkersComp.Benefit_State = Convert.ToDecimal(ddlBenefitState.SelectedValue.ToString());

            if (txtpolicyid.Text != String.Empty)
                objWorkersComp.FK_Policy = Convert.ToDecimal(txtpolicyid.Text.ToString());

            if (txtCompRate.Text != String.Empty)
                objWorkersComp.Comp_Rate = Convert.ToDecimal(txtCompRate.Text.ToString());

            if (txtTPAName.Text != String.Empty)
                objWorkersComp.TPA = txtTPAName.Text.Trim();

            if (txtlastDate.Text != String.Empty)
                objWorkersComp.Last_Date_Worked = Convert.ToDateTime(txtlastDate.Text);

            if (txtDateRTW.Text != String.Empty)
                objWorkersComp.Date_RTW = Convert.ToDateTime(txtDateRTW.Text);

            if (txtTimeofLoss.Text != String.Empty)
                objWorkersComp.Time_Of_Loss = txtTimeofLoss.Text.Trim();

            if (rbtnTransitional.SelectedIndex == 0)
                objWorkersComp.Transitional_Duty = "Y";
            else if (rbtnTransitional.SelectedIndex == 1)
                objWorkersComp.Transitional_Duty = "N";

            if (rbtnTransDutyRefused.SelectedIndex == 0)
                objWorkersComp.Transitional_Duty_Refused = "Y";
            else if (rbtnTransDutyRefused.SelectedIndex == 1)
                objWorkersComp.Transitional_Duty_Refused = "N";


            if (rbtnTypeofClaim.SelectedIndex == 0)
                objWorkersComp.Claim_Type = "L";
            else if (rbtnTypeofClaim.SelectedIndex == 1)
                objWorkersComp.Claim_Type = "M";


            if (ddlinjuryCode.SelectedIndex != 0)
                objWorkersComp.FK_Injury_Code = Convert.ToDecimal(ddlinjuryCode.SelectedValue.ToString());


            if (ddlCauseCode.SelectedIndex != 0)
                objWorkersComp.FK_Cause_Code = Convert.ToDecimal(ddlCauseCode.SelectedValue.ToString());


            if (ddlBodyParts.SelectedIndex != 0)
                objWorkersComp.FK_Body_Part = Convert.ToDecimal(ddlBodyParts.SelectedValue.ToString());

            if (txtDescOfAcc.Text != String.Empty)
                objWorkersComp.Accident_Description = txtDescOfAcc.Text.Trim();


            if (rbtnFatality.SelectedIndex == 0)
                objWorkersComp.Fatility = "Y";
            else if (rbtnFatality.SelectedIndex == 1)
                objWorkersComp.Fatility = "N";


            if (txtDOB.Text != String.Empty)
                objWorkersComp.DOB = Convert.ToDateTime(txtDOB.Text);

            if (txtDOH.Text != String.Empty)
                objWorkersComp.Date_Of_Hire = Convert.ToDateTime(txtDOH.Text);

            if (rbtnDoesClimant.SelectedIndex == 0)
                objWorkersComp.Legal_Representation = "Y";
            else if (rbtnDoesClimant.SelectedIndex == 1)
                objWorkersComp.Legal_Representation = "N";


            if (txtAttorneyName.Text != String.Empty)
                objWorkersComp.Attorney_Name = txtAttorneyName.Text.Trim();

            if (txtAttTelNo.Text != String.Empty)
                objWorkersComp.Attorney_Telephone = txtAttTelNo.Text.Trim();

            if (txtname.Text != String.Empty)
                objWorkersComp.CR_Name_Internal = txtname.Text.Trim();

            if (txtEMail.Text != String.Empty)
                objWorkersComp.CR_E_Mail_Internal = txtEMail.Text.Trim();

            if (txtTelephone.Text != String.Empty)
                objWorkersComp.CR_Telephone_Internal = txtTelephone.Text.Trim();

            if (txtnameotherparty.Text != String.Empty)
                objWorkersComp.CR_Name_Other = txtnameotherparty.Text.Trim();

            if (txtEmailotherparty.Text != String.Empty)
                objWorkersComp.CR_E_Mail_Other = txtEmailotherparty.Text.Trim();


            if (txttelotherparty.Text != String.Empty)
                objWorkersComp.CR_Telephone_Other = txttelotherparty.Text.Trim();

            m_intRetval = Convert.ToInt32(objWorkersComp.InsertUpdateers_Compensation(objWorkersComp));



            //................Mail Process.............

            if (ViewState["PK_Workers_Comp"] == null || ViewState["PK_Workers_Comp"].ToString() == String.Empty)
            {
                objWorkersComp = new RIMS_Base.Biz.CWorkersComp();
                lstWorkercomp = new List<RIMS_Base.CWorkersComp>();
                Int32 Liabilityid = Convert.ToInt32(m_intRetval);
                lstWorkercomp = objWorkersComp.Get_Worker_CompensationByID(Liabilityid);

                if (lstWorkercomp.Count != 0)
                {
                    string ClaimID = String.Empty;
                    ClaimID = lstWorkercomp[0].Claim_Number;
                    //Need to store last claim number, user has worked with for displaying in Enter payments in Check writing
                    Session["LastClaimNumber"] = ClaimID;
                }

                System.Threading.Thread.Sleep(3000);

                RIMS_Base.Biz.CSecurity m_objSecurity = new RIMS_Base.Biz.CSecurity();
                List<RIMS_Base.CSecurity> lstSecurity = new List<RIMS_Base.CSecurity>();
                lstSecurity = m_objSecurity.GetAdminByID(Convert.ToInt32(1));
                if (lstSecurity.Count > 0)
                {
                    if (lstSecurity[0].Email != string.Empty)
                    {
                        string ClaimID = String.Empty;
                        ClaimID = lstWorkercomp[0].Claim_Number;
                        string msg = "Here are the Details of FCI Worker's Compensation Claim Generated";
                        string claimsg = "FCI - Worker's Compensation Claim Number";
                        string Cli = "Employee Name";
                        string PR = "Dear ";
                        string incDate = "Date of Loss";

                        lstCliamant = objWorkersComp.GetCliamant_ByID(Liabilityid, Convert.ToInt32(lstWorkercomp[0].FK_Claimant));

                        if (lstCliamant.Count != 0)
                        {
                            for (int i = 0; i < lstSecurity.Count; i++)
                            {
                                string body = "<html><body> " + PR + lstSecurity[i].FIRST_NAME + " " + lstSecurity[i].LAST_NAME + "<br/>" + msg + ":" + "<br/>" + claimsg + ":" + ClaimID + "<br/>" + Cli + ":" + lstCliamant[0].Last_Name.Replace("''", "'") + "<br/>" + incDate + ":" + (Convert.ToDateTime(lstWorkercomp[0].Date_Of_Incident)).ToShortDateString() + "</html></body>";
                                sendMail(ConfigurationManager.AppSettings["mailFrom"].ToString(), lstSecurity[i].Email, string.Empty, string.Empty, "FCI - Worker's Compensation Claim Number", body);
                            }
                        }
                    }
                }
            }

            //End Mail Sending



            ViewState["PK_Workers_Comp"] = m_intRetval.ToString();

            Session["WorkerCompID"] = m_intRetval.ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public static string sendMail(string from, string to, string cc, string bcc, string subject, string body)
    {
        if (!AppConfig.AllowMailSending)
            return "";
        // Mail initialization
        System.Web.Mail.MailMessage mailMsg = new System.Web.Mail.MailMessage();
        mailMsg.From = "Erims2<" + from + ">";
        mailMsg.To = to;
        mailMsg.Cc = cc;
        mailMsg.Bcc = bcc;
        mailMsg.Subject = subject;
        mailMsg.BodyFormat = System.Web.Mail.MailFormat.Html;
        mailMsg.Body = body;



        mailMsg.Priority = System.Web.Mail.MailPriority.Normal;
        // Smtp configuration
        System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com";
        // - smtp.gmail.com use smtp authentication
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", from);
        //Password for From mail account.
        //m_strSMTPpwd = DecryptPassword(System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
        // - smtp.gmail.com use port 465 or 587 ifmisBugs@astegic.com/ifmisbugs
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
        // - smtp.gmail.com use STARTTLS (some call this SSL)
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
        // try to send Mail
        try
        {
            System.Web.Mail.SmtpMail.Send(mailMsg);
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    private void ViewData()
    {
        objWorkersComp = new RIMS_Base.Biz.CWorkersComp();
        lstWorkercomp = new List<RIMS_Base.CWorkersComp>();
        lstCliamant = new List<RIMS_Base.CWorkersComp>();
        lstPolicy = new List<RIMS_Base.CWorkersComp>();
        Int32 WorkerId = Convert.ToInt32(ViewState["PK_Workers_Comp"]);
        lstWorkercomp = objWorkersComp.Get_Worker_CompensationByID(WorkerId);
        lstCliamant = objWorkersComp.GetCliamant_ByID(WorkerId, Convert.ToDecimal(lstWorkercomp[0].FK_Claimant));
        lstPolicy = objWorkersComp.GetCarrier_ByID(WorkerId, Convert.ToDecimal(lstWorkercomp[0].FK_Policy));
        try
        {

            if (lstWorkercomp.Count != 0)
            {

                if (lstWorkercomp[0].Claim_Number != String.Empty)
                    lblvclaimnoedit.Text = lstWorkercomp[0].Claim_Number;
                //Need to store last claim number, user has worked with for displaying in Enter payments in Check writing
                Session["LastClaimNumber"] = lblvclaimnoedit.Text;

                if (lstWorkercomp[0].Carrier_Claim_Number != String.Empty)
                    lblvwCarrierClaimno.Text = lstWorkercomp[0].Carrier_Claim_Number;

                if (lstWorkercomp[0].Status == "O")
                    lblvwStatus.Text = "Open";
                else if (lstWorkercomp[0].Status == "C")
                    lblvwStatus.Text = "Closed";
                else if (lstWorkercomp[0].Status == "R")
                    lblvwStatus.Text = "Reopened";

                if (lstCliamant.Count != 0)
                {
                    if (lstCliamant[0].First_Name != String.Empty)
                        lblvwFirstName.Text = lstCliamant[0].First_Name.Replace("''", "'");

                    if (lstCliamant[0].Last_Name != String.Empty)
                        lblvwLastName.Text = lstCliamant[0].Last_Name.Replace("''", "'");

                }
                if (lstPolicy.Count != 0)
                {
                    if (lstPolicy[0].Carrier != String.Empty)
                        lblvwCarrierName.Text = lstPolicy[0].Carrier;

                    if (lstPolicy[0].Policy_Number_Claim != String.Empty)
                        lblvwPolicyNo.Text = lstPolicy[0].Policy_Number_Claim;

                    if (lstPolicy[0].Effective_Policy_Date.ToString() != String.Empty)
                        lblvwPolicyEffecDate.Text = Convert.ToDateTime(lstPolicy[0].Effective_Policy_Date.ToString()).ToShortDateString();

                    if (lstPolicy[0].Expiration_Policy_Date.ToString() != String.Empty)
                        lblvwPolicyExpDate.Text = Convert.ToDateTime(lstPolicy[0].Expiration_Policy_Date.ToString()).ToShortDateString();



                }



                if (lstWorkercomp[0].Date_Reported_To_FairPoint.ToString() != String.Empty)
                    lblvwDateReportedtoFair.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Reported_To_FairPoint.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_Claim_Opened.ToString() != String.Empty)
                    lblvwDateClaimOpened.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Claim_Opened.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Union_Member == "Y")
                    lblvwUnion.Text = "Yes";
                else if (lstWorkercomp[0].Union_Member == "N")
                    lblvwUnion.Text = "No";

                if (lstWorkercomp[0].Date_Claim_Closed.ToString() != String.Empty)
                    lblvwDateClaimClosed.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Claim_Closed.ToString()).ToShortDateString();

                if (lstWorkercomp[0].FK_Entity != null)
                    lblvwEntity.Text = dwEntity.Items.FindByValue(lstWorkercomp[0].FK_Entity.ToString()).Text;

                if (lstWorkercomp[0].Date_Claim_Reopened.ToString() != String.Empty)
                    lblvwDateClaimReopened.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Claim_Reopened.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_Reported_To_Carrier.ToString() != String.Empty)
                    lblvwDateReportedtoCarrier.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Reported_To_Carrier.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_Of_Incident.ToString() != String.Empty)
                    lblvwDateofLoss.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Of_Incident.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Benefit_State != null)
                    lblvwBenefitState.Text = ddlBenefitState.Items.FindByValue(lstWorkercomp[0].Benefit_State.ToString()).Text;

                if (lstWorkercomp[0].Comp_Rate.ToString() != null)
                    lblvwCompRate.Text = lstWorkercomp[0].Comp_Rate.ToString();

                if (lstWorkercomp[0].TPA != String.Empty)
                    lblvwTPAName.Text = lstWorkercomp[0].TPA;

                if (lstWorkercomp[0].Last_Date_Worked.ToString() != String.Empty)
                    lblvwlastDate.Text = Convert.ToDateTime(lstWorkercomp[0].Last_Date_Worked.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_RTW.ToString() != String.Empty)
                    lblvwDateRTW.Text = Convert.ToDateTime(lstWorkercomp[0].Date_RTW.ToString()).ToShortDateString();


                if (lstWorkercomp[0].Transitional_Duty == "Y")
                    lblvwTransitional.Text = "Yes";
                else if (lstWorkercomp[0].Transitional_Duty == "N")
                    lblvwTransitional.Text = "No";


                if (lstWorkercomp[0].Transitional_Duty_Refused == "Y")
                    lblvwTransDutyRefused.Text = "Yes";
                else if (lstWorkercomp[0].Transitional_Duty_Refused == "N")
                    lblvwTransDutyRefused.Text = "No";

                if (lstWorkercomp[0].Claim_Type == "L")
                    lblvwTypeofClaim.Text = "LT";
                else if (lstWorkercomp[0].Claim_Type == "M")
                    lblvwTypeofClaim.Text = "MO";


                if (lstWorkercomp[0].FK_Injury_Code != null)
                    lblvwinjuryCode.Text = ddlinjuryCode.Items.FindByValue(lstWorkercomp[0].FK_Injury_Code.ToString()).Text;

                if (lstWorkercomp[0].FK_Cause_Code != null)
                    lblvwCauseCode.Text = ddlCauseCode.Items.FindByValue(lstWorkercomp[0].FK_Cause_Code.ToString()).Text;

                if (lstWorkercomp[0].FK_Body_Part != null)
                    lblvwBodyParts.Text = ddlBodyParts.Items.FindByValue(lstWorkercomp[0].FK_Body_Part.ToString()).Text;


                if (lstWorkercomp[0].Time_Of_Loss != String.Empty)
                    lblvwTimeofLoss.Text = lstWorkercomp[0].Time_Of_Loss;

                if (lstWorkercomp[0].Accident_Description != String.Empty)
                    lblvwDescOfAcc.Text = lstWorkercomp[0].Accident_Description;

                if (lstWorkercomp[0].Fatility == "Y")
                    lblvwFatality.Text = "Yes";
                else if (lstWorkercomp[0].Fatility == "N")
                    lblvwFatality.Text = "No";

                if (lstWorkercomp[0].DOB.ToString() != String.Empty)
                    lblvwDOB.Text = Convert.ToDateTime(lstWorkercomp[0].DOB.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_Of_Hire.ToString() != String.Empty)
                    lblvwDOH.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Of_Hire.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Legal_Representation == "Y")
                    lblvwDoesClimant.Text = "Yes";
                else if (lstWorkercomp[0].Legal_Representation == "N")
                    lblvwDoesClimant.Text = "No";

                if (lstWorkercomp[0].Attorney_Name != String.Empty)
                    lblvwAttorneyName.Text = lstWorkercomp[0].Attorney_Name;

                if (lstWorkercomp[0].Attorney_Telephone != String.Empty)
                    lblvwAttTelNo.Text = lstWorkercomp[0].Attorney_Telephone;


                if (lstWorkercomp[0].CR_Name_Internal != String.Empty)
                    lblvwename.Text = lstWorkercomp[0].CR_Name_Internal;

                if (lstWorkercomp[0].CR_E_Mail_Internal != String.Empty)
                    lblvweEMail.Text = lstWorkercomp[0].CR_E_Mail_Internal;

                if (lstWorkercomp[0].CR_Telephone_Internal != String.Empty)
                    lblvweTelephone.Text = lstWorkercomp[0].CR_Telephone_Internal;



                if (lstWorkercomp[0].CR_Name_Other != String.Empty)
                    lblvwenameotherparty.Text = lstWorkercomp[0].CR_Name_Other;

                if (lstWorkercomp[0].CR_E_Mail_Other != String.Empty)
                    lblvweEmailotherparty.Text = lstWorkercomp[0].CR_E_Mail_Other;

                if (lstWorkercomp[0].CR_Telephone_Other != String.Empty)
                    lblvwetelotherparty.Text = lstWorkercomp[0].CR_Telephone_Other;

                DispalayCheckRegisterData(lstWorkercomp[0].Claim_Number, "View");

                lstAttachment = BindAttachmentDetails();
                if (lstAttachment.Count > 0)
                {
                    gvAttachView.DataSource = lstAttachment;
                    gvAttachView.DataBind();
                    btnRemove.Visible = true;
                }
                gvAttachView.Columns[0].Visible = false;

            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void RetriveDataByID()
    {
        objWorkersComp = new RIMS_Base.Biz.CWorkersComp();
        lstWorkercomp = new List<RIMS_Base.CWorkersComp>();
        lstCliamant = new List<RIMS_Base.CWorkersComp>();
        lstPolicy = new List<RIMS_Base.CWorkersComp>();
        Int32 WorkerId = Convert.ToInt32(ViewState["PK_Workers_Comp"]);
        lstWorkercomp = objWorkersComp.Get_Worker_CompensationByID(WorkerId);
        lstCliamant = objWorkersComp.GetCliamant_ByID(WorkerId, Convert.ToDecimal(lstWorkercomp[0].FK_Claimant));
        lstPolicy = objWorkersComp.GetCarrier_ByID(WorkerId, Convert.ToDecimal(lstWorkercomp[0].FK_Policy));
        try
        {

            if (lstWorkercomp.Count != 0)
            {


                lblclaimnoedit.Text = lstWorkercomp[0].Claim_Number;
                //Need to store last claim number, user has worked with for displaying in Enter payments in Check writing
                Session["LastClaimNumber"] = lblclaimnoedit.Text;
                if (lstWorkercomp[0].Carrier_Claim_Number != String.Empty)
                    txtCarrierClaimNo.Text = lstWorkercomp[0].Carrier_Claim_Number;

                if (lstWorkercomp[0].Status == "O")
                    rbtStatus.SelectedIndex = 0;
                else if (lstWorkercomp[0].Status == "C")
                    rbtStatus.SelectedIndex = 1;
                else if (lstWorkercomp[0].Status == "R")
                    rbtStatus.SelectedIndex = 2;

                if (lstWorkercomp[0].FK_Claimant.ToString() != null)
                    txtempid.Text = lstWorkercomp[0].FK_Claimant.ToString();

                if (lstWorkercomp[0].FK_Policy.ToString() != null)
                    txtpolicyid.Text = lstWorkercomp[0].FK_Policy.ToString();


                if (lstCliamant.Count != 0)
                {
                    if (lstCliamant[0].First_Name != String.Empty)
                        txtFirstName.Text = lstCliamant[0].First_Name.Replace("''", "'");

                    if (lstCliamant[0].Last_Name != String.Empty)
                        txtLastName.Text = lstCliamant[0].Last_Name.Replace("''", "'");

                }
                if (lstPolicy.Count != 0)
                {
                    if (lstPolicy[0].Carrier != String.Empty)
                        txtCarrierName.Text = lstPolicy[0].Carrier;

                    if (lstPolicy[0].Policy_Number_Claim != String.Empty)
                        txtPolicyNo.Text = lstPolicy[0].Policy_Number_Claim;

                    if (lstPolicy[0].Effective_Policy_Date.ToString() != String.Empty)
                        txtPolicyEffecDate.Text = Convert.ToDateTime(lstPolicy[0].Effective_Policy_Date.ToString()).ToShortDateString();

                    if (lstPolicy[0].Expiration_Policy_Date.ToString() != String.Empty)
                        txtPolicyExpDate.Text = Convert.ToDateTime(lstPolicy[0].Expiration_Policy_Date.ToString()).ToShortDateString();

                }

                if (lstWorkercomp[0].Date_Reported_To_FairPoint.ToString() != String.Empty)
                    txtDateReportedtoFair.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Reported_To_FairPoint.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_Claim_Opened.ToString() != String.Empty)
                    txtDateClaimOpened.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Claim_Opened.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Union_Member == "Y")
                    rbtnUnion.SelectedIndex = 0;
                else if (lstWorkercomp[0].Union_Member == "N")
                    rbtnUnion.SelectedIndex = 1;

                if (lstWorkercomp[0].Date_Claim_Closed.ToString() != String.Empty)
                    txtDateClaimClosed.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Claim_Closed.ToString()).ToShortDateString();

                if (lstWorkercomp[0].FK_Entity != null)
                    dwEntity.SelectedIndex = dwEntity.Items.IndexOf(dwEntity.Items.FindByValue(lstWorkercomp[0].FK_Entity.ToString()));


                if (lstWorkercomp[0].Date_Claim_Reopened.ToString() != String.Empty)
                    txtDateClaimReopened.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Claim_Reopened.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_Reported_To_Carrier.ToString() != String.Empty)
                    txtlblDateReportedtoCarrier.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Reported_To_Carrier.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_Of_Incident.ToString() != String.Empty)
                    txtDateofLoss.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Of_Incident.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Benefit_State != null)
                    ddlBenefitState.SelectedIndex = ddlBenefitState.Items.IndexOf(ddlBenefitState.Items.FindByValue(lstWorkercomp[0].Benefit_State.ToString()));

                if (lstWorkercomp[0].Comp_Rate.ToString() != null)
                    txtCompRate.Text = lstWorkercomp[0].Comp_Rate.ToString();

                if (lstWorkercomp[0].TPA != String.Empty)
                    txtTPAName.Text = lstWorkercomp[0].TPA;


                if (lstWorkercomp[0].Last_Date_Worked.ToString() != String.Empty)
                    txtlastDate.Text = Convert.ToDateTime(lstWorkercomp[0].Last_Date_Worked.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_RTW.ToString() != String.Empty)
                    txtDateRTW.Text = Convert.ToDateTime(lstWorkercomp[0].Date_RTW.ToString()).ToShortDateString();


                if (lstWorkercomp[0].Transitional_Duty == "Y")
                    rbtnTransitional.SelectedIndex = 0;
                else if (lstWorkercomp[0].Transitional_Duty == "N")
                    rbtnTransitional.SelectedIndex = 1;


                if (lstWorkercomp[0].Transitional_Duty_Refused == "Y")
                    rbtnTransDutyRefused.SelectedIndex = 0;
                else if (lstWorkercomp[0].Transitional_Duty_Refused == "N")
                    rbtnTransDutyRefused.SelectedIndex = 1;

                if (lstWorkercomp[0].Claim_Type == "L")
                    rbtnTypeofClaim.SelectedIndex = 0;
                else if (lstWorkercomp[0].Claim_Type == "M")
                    rbtnTypeofClaim.SelectedIndex = 1;



                if (lstWorkercomp[0].FK_Injury_Code != null)
                    ddlinjuryCode.SelectedIndex = ddlinjuryCode.Items.IndexOf(ddlinjuryCode.Items.FindByValue(lstWorkercomp[0].FK_Injury_Code.ToString()));

                if (lstWorkercomp[0].FK_Cause_Code != null)
                    ddlCauseCode.SelectedIndex = ddlCauseCode.Items.IndexOf(ddlCauseCode.Items.FindByValue(lstWorkercomp[0].FK_Cause_Code.ToString()));

                if (lstWorkercomp[0].FK_Body_Part != null)
                    ddlBodyParts.SelectedIndex = ddlBodyParts.Items.IndexOf(ddlBodyParts.Items.FindByValue(lstWorkercomp[0].FK_Body_Part.ToString()));


                if (lstWorkercomp[0].Time_Of_Loss != String.Empty)
                    txtTimeofLoss.Text = lstWorkercomp[0].Time_Of_Loss;

                if (lstWorkercomp[0].Accident_Description != String.Empty)
                    txtDescOfAcc.Text = lstWorkercomp[0].Accident_Description;

                if (lstWorkercomp[0].Fatility == "Y")
                    rbtnFatality.SelectedIndex = 0;
                else if (lstWorkercomp[0].Fatility == "N")
                    rbtnFatality.SelectedIndex = 1;

                if (lstWorkercomp[0].DOB.ToString() != String.Empty)
                    lblvwDOB.Text = Convert.ToDateTime(lstWorkercomp[0].DOB.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Date_Of_Hire.ToString() != String.Empty)
                    txtDOH.Text = Convert.ToDateTime(lstWorkercomp[0].Date_Of_Hire.ToString()).ToShortDateString();

                if (lstWorkercomp[0].Legal_Representation == "Y")
                    rbtnDoesClimant.Text = "Yes";
                else if (lstWorkercomp[0].Legal_Representation == "N")
                    rbtnDoesClimant.Text = "No";



                if (lstWorkercomp[0].Attorney_Name != String.Empty)
                    txtAttorneyName.Text = lstWorkercomp[0].Attorney_Name;

                if (lstWorkercomp[0].Attorney_Telephone != String.Empty)
                    txtAttTelNo.Text = lstWorkercomp[0].Attorney_Telephone;


                if (lstWorkercomp[0].CR_Name_Internal != String.Empty)
                    txtname.Text = lstWorkercomp[0].CR_Name_Internal;

                if (lstWorkercomp[0].CR_E_Mail_Internal != String.Empty)
                    txtEMail.Text = lstWorkercomp[0].CR_E_Mail_Internal;

                if (lstWorkercomp[0].CR_Telephone_Internal != String.Empty)
                    txtTelephone.Text = lstWorkercomp[0].CR_Telephone_Internal;



                if (lstWorkercomp[0].CR_Name_Other != String.Empty)
                    txtnameotherparty.Text = lstWorkercomp[0].CR_Name_Other;

                if (lstWorkercomp[0].CR_E_Mail_Other != String.Empty)
                    txtEmailotherparty.Text = lstWorkercomp[0].CR_E_Mail_Other;

                if (lstWorkercomp[0].CR_Telephone_Other != String.Empty)
                    txttelotherparty.Text = lstWorkercomp[0].CR_Telephone_Other;

                DispalayCheckRegisterData(lstWorkercomp[0].Claim_Number, "Edit");

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

        catch (Exception ex)
        {

            throw ex;

        }
    }

    // --- Display Check Register Information
    private void DispalayCheckRegisterData(string claimNo, string view)
    {
        m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
        lstClaimReservesInfo = new List<RIMS_Base.CCheckWriting>();
        lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(claimNo);
        ViewState["TableName"] = lstClaimReservesInfo[0].TableName.ToString();
        ViewState["TableFK"] = lstClaimReservesInfo[0].TableFK.ToString();
        objCheckRegister = new RIMS_Base.Biz.CCheckRegister();
        if (ViewState["TableFK"] != null && ViewState["TableName"] != null)
        {
            // Commented by Mayuri on  04-Mar-2008
            lstCheckRegister = objCheckRegister.GetCheckRegisterByID(Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            // Commented by Alpesh on  03-Mar-2008
            //lstCheckRegister = objCheckRegister.GetCheckRegisterByID(Convert.ToDecimal(Session["WorkerCompID"].ToString()), ViewState["TableName"].ToString());

        }
        if (view == "Edit")
        {
            if (lstCheckRegister.Count != 0)
            {
                tblDetail.Style["display"] = "block";
                if (lstCheckRegister[0].Indemnity_Incurred != null)
                    lblIndemIncurred.Text = lstCheckRegister[0].Indemnity_Incurred.ToString();
                else
                    lblIndemIncurred.Text = "0.0";
                if (lstCheckRegister[0].Indemnity_Paid != null)
                    lblIndemPaid.Text = lstCheckRegister[0].Indemnity_Paid.ToString();
                else
                    lblIndemPaid.Text = "0.0";
                //if (lstCheckRegister[0].Indemnity_Outstanding != null)
                if (lstCheckRegister[0].Indemnity_Incurred != null && lstCheckRegister[0].Indemnity_Paid != null)
                {
                    decimal? Temp = lstCheckRegister[0].Indemnity_Incurred - lstCheckRegister[0].Indemnity_Paid;
                    lblIndemOutStanding.Text = Temp.ToString();
                }
                else if (lstCheckRegister[0].Indemnity_Incurred != null && lstCheckRegister[0].Indemnity_Paid == null)
                {
                    lblIndemOutStanding.Text = lstCheckRegister[0].Indemnity_Incurred.ToString();
                }
                else if (lstCheckRegister[0].Indemnity_Incurred == null && lstCheckRegister[0].Indemnity_Paid == null)
                {
                    lblIndemOutStanding.Text = "0.0";
                }
                if (lstCheckRegister[0].Indemnity_Current_Month != null)
                    lblIndemCurrentMonth.Text = lstCheckRegister[0].Indemnity_Current_Month.ToString();
                else
                    lblIndemCurrentMonth.Text = "0.0";
                if (lstCheckRegister[0].Medical_Incurred != null)
                    lblMediIncured.Text = lstCheckRegister[0].Medical_Incurred.ToString();
                else
                    lblMediIncured.Text = "0.0";
                if (lstCheckRegister[0].Medical_Paid != null)
                    lblMediPaid.Text = lstCheckRegister[0].Medical_Paid.ToString();
                else
                    lblMediPaid.Text = "0.0";
                //if (lstCheckRegister[0].Medical_Outstanding != null)
                if (lstCheckRegister[0].Medical_Incurred != null && lstCheckRegister[0].Medical_Paid != null)
                {
                    decimal? Temp = lstCheckRegister[0].Medical_Incurred - lstCheckRegister[0].Medical_Paid;
                    lblMediOutStand.Text = Temp.ToString();
                }
                else if (lstCheckRegister[0].Medical_Incurred != null && lstCheckRegister[0].Medical_Paid == null)
                {
                    lblMediOutStand.Text = lstCheckRegister[0].Medical_Incurred.ToString();
                }
                else if (lstCheckRegister[0].Medical_Incurred == null && lstCheckRegister[0].Medical_Paid == null)
                {
                    lblMediOutStand.Text = "0.0";
                }
                if (lstCheckRegister[0].Medical_Current_Month != null)
                    lblMediCurrentMonth.Text = lstCheckRegister[0].Medical_Current_Month.ToString();
                else
                    lblMediCurrentMonth.Text = "0.0";
                if (lstCheckRegister[0].Expense_Incurred != null)
                    lblExpIncurred.Text = lstCheckRegister[0].Expense_Incurred.ToString();
                else
                    lblExpIncurred.Text = "0.0";
                if (lstCheckRegister[0].Expense_Paid != null)
                    lblExpIndemPaid.Text = lstCheckRegister[0].Expense_Paid.ToString();
                else
                    lblExpIndemPaid.Text = "0.0";
                //if (lstCheckRegister[0].Expense_Outstanding != null)
                if (lstCheckRegister[0].Expense_Incurred != null && lstCheckRegister[0].Expense_Paid != null)
                {
                    decimal? Temp = lstCheckRegister[0].Expense_Incurred - lstCheckRegister[0].Expense_Paid;
                    lblExpOutStand.Text = Temp.ToString();
                }
                else if (lstCheckRegister[0].Expense_Incurred != null && lstCheckRegister[0].Expense_Paid == null)
                {
                    lblExpOutStand.Text = lstCheckRegister[0].Expense_Incurred.ToString();
                }
                else if (lstCheckRegister[0].Expense_Incurred == null && lstCheckRegister[0].Expense_Paid == null)
                {
                    lblExpOutStand.Text = "0.0";
                }
                if (lstCheckRegister[0].Expense_Current_Month != null)
                    lblExpCurrentMonth.Text = lstCheckRegister[0].Expense_Current_Month.ToString();
                else
                    lblExpCurrentMonth.Text = "0.0";
            }
            else
            {
                tblDetail.Style["display"] = "none";
                tblNoData.Style["display"] = "block";
            }
        }
        else if (view == "View")
        {
            if (lstCheckRegister.Count != 0)
            {
                tblvwFDetail.Style["display"] = "block";
                if (lstCheckRegister[0].Indemnity_Incurred != null)
                    lblvwIndemIncurred.Text = lstCheckRegister[0].Indemnity_Incurred.ToString();
                else
                    lblvwIndemIncurred.Text = "0.0";
                if (lstCheckRegister[0].Indemnity_Paid != null)
                    lblvwIndemPaid.Text = lstCheckRegister[0].Indemnity_Paid.ToString();
                else
                    lblvwIndemPaid.Text = "0.0";
                //if (lstCheckRegister[0].Indemnity_Outstanding != null)
                if (lstCheckRegister[0].Indemnity_Incurred != null && lstCheckRegister[0].Indemnity_Paid != null)
                {
                    decimal? Temp = lstCheckRegister[0].Indemnity_Incurred - lstCheckRegister[0].Indemnity_Paid;
                    lblvwIndemOutStanding.Text = Temp.ToString();
                }
                else if (lstCheckRegister[0].Indemnity_Incurred != null && lstCheckRegister[0].Indemnity_Paid == null)
                {
                    lblvwIndemOutStanding.Text = lstCheckRegister[0].Indemnity_Incurred.ToString();
                }
                else if (lstCheckRegister[0].Indemnity_Incurred == null && lstCheckRegister[0].Indemnity_Paid == null)
                {
                    lblvwIndemOutStanding.Text = "0.0";
                }
                if (lstCheckRegister[0].Indemnity_Current_Month != null)
                    lblvwIndemCurrentMonth.Text = lstCheckRegister[0].Indemnity_Current_Month.ToString();
                else
                    lblvwIndemCurrentMonth.Text = "0.0";
                if (lstCheckRegister[0].Medical_Incurred != null)
                    lblvwMediIncured.Text = lstCheckRegister[0].Medical_Incurred.ToString();
                else
                    lblvwMediIncured.Text = "0.0";
                if (lstCheckRegister[0].Medical_Paid != null)
                    lblvwMediPaid.Text = lstCheckRegister[0].Medical_Paid.ToString();
                else
                    lblvwMediPaid.Text = "0.0";
                //if (lstCheckRegister[0].Medical_Outstanding != null)
                if (lstCheckRegister[0].Medical_Incurred != null && lstCheckRegister[0].Medical_Paid != null)
                {
                    decimal? Temp = lstCheckRegister[0].Medical_Incurred - lstCheckRegister[0].Medical_Paid;
                    lblvwMediOutStand.Text = Temp.ToString();
                }
                else if (lstCheckRegister[0].Medical_Incurred != null && lstCheckRegister[0].Medical_Paid == null)
                {
                    lblvwMediOutStand.Text = lstCheckRegister[0].Medical_Incurred.ToString();
                }
                else if (lstCheckRegister[0].Medical_Incurred == null && lstCheckRegister[0].Medical_Paid == null)
                {
                    lblvwMediOutStand.Text = "0.0";
                }
                if (lstCheckRegister[0].Medical_Current_Month != null)
                    lblMediCurrentMonth.Text = lstCheckRegister[0].Medical_Current_Month.ToString();
                else
                    lblMediCurrentMonth.Text = "0.0";
                if (lstCheckRegister[0].Expense_Incurred != null)
                    lblvwExpIncurred.Text = lstCheckRegister[0].Expense_Incurred.ToString();
                else
                    lblvwExpIncurred.Text = "0.0";
                if (lstCheckRegister[0].Expense_Paid != null)
                    lblvwExpIndemPaid.Text = lstCheckRegister[0].Expense_Paid.ToString();
                else
                    lblvwExpIndemPaid.Text = "0.0";
                //if (lstCheckRegister[0].Expense_Outstanding != null)
                if (lstCheckRegister[0].Expense_Incurred != null && lstCheckRegister[0].Expense_Paid != null)
                {
                    decimal? Temp = lstCheckRegister[0].Expense_Incurred - lstCheckRegister[0].Expense_Paid;
                    lblvwExpOutStand.Text = Temp.ToString();
                }
                else if (lstCheckRegister[0].Expense_Incurred != null && lstCheckRegister[0].Expense_Paid == null)
                {
                    lblvwExpOutStand.Text = lstCheckRegister[0].Expense_Incurred.ToString();
                }
                else if (lstCheckRegister[0].Expense_Incurred == null && lstCheckRegister[0].Expense_Paid == null)
                {
                    lblvwExpOutStand.Text = "0.0";
                }
                if (lstCheckRegister[0].Expense_Current_Month != null)
                    lblvwExpCurrentMonth.Text = lstCheckRegister[0].Expense_Current_Month.ToString();
                else
                    lblvwExpCurrentMonth.Text = "0.0";
            }
            else
            {
                tblvwFDetail.Style["display"] = "none";
                tblvwFNoData.Style["display"] = "block";
            }
        }
    }
    // --- Display Employee Information
    #endregion

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
            m_objAttachment.Attachment_Table = "Workers_Comp";
            m_objAttachment.Foreign_Key = Convert.ToInt32(ViewState["PK_Workers_Comp"].ToString());
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(ddlAttachType.SelectedIndex = 1);

            m_objAttachment.Attachment_Description = txtAttachDesc.Text.Replace("'", "''");
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

    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            if (ViewState["PK_Workers_Comp"] != null && ViewState["PK_Workers_Comp"].ToString() != "")
                lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(ViewState["PK_Workers_Comp"].ToString()), "Workers_Comp");

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
    private void ViewAllFromSearchGrid()
    {


        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "none";
        divsecond.Style["display"] = "none";
        divthird.Style["display"] = "none";
        divfour.Style["display"] = "none";
        ViewDiv.Style["display"] = "block";

        LeftDiv.Style["display"] = "none";
        divbtn.Style["display"] = "none";
        mainContent.Style["display"] = "none";

        btnViewBack.Visible = false;
        btnBack.Visible = true;

        ViewData();
        //  DispalayCheckRegisterData();

    }
    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvAttachView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

}
