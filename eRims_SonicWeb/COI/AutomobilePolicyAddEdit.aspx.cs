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
using ERIMS.DAL;
public partial class Admin_AutomobilePolicyAddEdit : clsBasePage
{
    #region "Properties"
    string _strOperation = "";
    /// <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string StrOperation
    {
        get
        {
            return _strOperation;
        }
    }
    // FK to indicate Automobile Policy is for which COI
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }

    // PK for Automobile Policy
    public int PK_COI_Automobile_Policies
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PolicyID"]);
        }
        set { ViewState["PolicyID"] = value; }
    }

    #endregion

    #region "Page Events"
    /// <summary>
    /// Page Load Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time.
        if (!IsPostBack)
        {
            if (!clsGeneral.IsNull(Request.QueryString["pnl"]))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Request.QueryString["pnl"] + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(1);", true);

            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                // if COI's FK is not passed redirect to default page.
                if (!clsGeneral.IsNull(Request.QueryString["coi"]))
                {
                    // set FK Coi.
                    FK_COI = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["coi"]));

                    // Load COI Control
                    ucCtrlCOIInfo.PK_COIs = FK_COI;
                    ucCtrlCOIInfo.BindrCOIInfo();

                    //Bind Insurance company drop down
                    clsGeneral.FillIsuranceCompanyDropDown(drpCompany, FK_COI);

                    // if operations(view or edit) is passed in query string.
                    if (!clsGeneral.IsNull(Request.QueryString["op"]))
                    {
                        // if id is passed set primary key.
                        if (!clsGeneral.IsNull(Request.QueryString["id"]))
                        {
                            PK_COI_Automobile_Policies = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }
                        _strOperation = Request.QueryString["op"].ToString();
                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                            BindInsuredGrid();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Automobile_Liability_Policies, PK_COI_Automobile_Policies, false, 3);

                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Automobile_Liability_Policies, PK_COI_Automobile_Policies, true, 3);
                                BindDetailsForEdit();
                                BindInsuredGrid();
                            }
                            else
                                Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                        }
                        BindAttachmentDetails();
                    }
                    else
                    {
                        if (App_Access != AccessType.Administrative_Access)
                            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                SetValidations();
                drpCompany.Focus();
            }
        }
    }

    #endregion

    # region " Private Methods "
    /// <summary>
    /// Bind Attachment Details 
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }

    /// <summary>
    /// Bind Insured Grid
    /// </summary>
    private void BindInsuredGrid()
    {
        DataTable dtAI = COI_AI.SelectByFK_COI_Locations(PK_COI_Automobile_Policies, "Automobile_Policy").Tables[0];
        gvAI.DataSource = dtAI;
        gvAI.DataBind();
        gvAI.Columns[2].Visible = (Request.QueryString["op"] == "view") ? false : true;
    }
    /// <summary>
    /// Save Producer Record 
    /// </summary>
    private void SaveRecord()
    {
        // create a new object for producer.
        COI_Automobile_Policies objAutomobilePolicy = new COI_Automobile_Policies();

        //set values.
        objAutomobilePolicy.PK_COI_Automobile_Policies = PK_COI_Automobile_Policies;
        objAutomobilePolicy.FK_COIs = FK_COI;
        objAutomobilePolicy.Insurance_Company = drpCompany.SelectedValue;
        objAutomobilePolicy.Policy_Number = txtPolicyNumber.Text.Trim();
        objAutomobilePolicy.Issue_Date = uccalIssueDate.DateValue;
        objAutomobilePolicy.Effective_Date = txtEffectiveDate.DateValue;
        objAutomobilePolicy.Expiration_Date = txtExpirationDate.DateValue;
        objAutomobilePolicy.Cancellation_Date = txtCancellationDate.DateValue;
        objAutomobilePolicy.Any_Auto = rdoAnyAuto.SelectedValue;
        objAutomobilePolicy.All_Owned_Vehicles = rdoAllOwnedVehicles.SelectedValue;
        objAutomobilePolicy.Scheduled_Autos = rdoScheduledAutos.SelectedValue;
        objAutomobilePolicy.Hired_Autos = rdoHiredAutos.SelectedValue;
        objAutomobilePolicy.Non_Owned_Autos = rdoNonOwnedAutos.SelectedValue;
        objAutomobilePolicy.Other_Coverage = txtOtherCoverage.Text.Trim();
        objAutomobilePolicy.Combined_Single_Limit = clsGeneral.GetDecimalValue(txtCombinedSingleLimit);
        objAutomobilePolicy.Bodily_Injury_Person = clsGeneral.GetDecimalValue(txtBodilyInjuryPerson);
        objAutomobilePolicy.Bodily_Injury_Accident = clsGeneral.GetDecimalValue(txtBodilyInjuryAccident);
        objAutomobilePolicy.Property_Damage = clsGeneral.GetDecimalValue(txtPropertyDamage);
        objAutomobilePolicy.Notes = txtNotes.Text.Trim();
        objAutomobilePolicy.Update_Date = DateTime.Today;
        objAutomobilePolicy.Updated_By = clsSession.UserName;
        objAutomobilePolicy.Other_Liability1 = txtOtherLiability1.Text.Trim();
        objAutomobilePolicy.Other_Liability_Coverage1 = clsGeneral.GetDecimalValue(txtOtherLiabilityCoverage1);
        objAutomobilePolicy.Other_Liability2 = txtOtherLiability2.Text.Trim();
        objAutomobilePolicy.Other_Liability_Coverage2 = clsGeneral.GetDecimalValue(txtOtherLiabilityCoverage2);
        objAutomobilePolicy.Physical_Damage_Collision = clsGeneral.GetDecimalValue(txtPhysicalDamageCollision);
        objAutomobilePolicy.Physical_Damage_Comprehensive = clsGeneral.GetDecimalValue(txtPhysicalDamageComprehensive);
        // check if insert or update the producer.
        if (PK_COI_Automobile_Policies > 0)
            objAutomobilePolicy.Update();
        else
            PK_COI_Automobile_Policies = objAutomobilePolicy.Insert();

        // add attachment if any
        Attachment.Add(clsGeneral.Tables.Automobile_Liability_Policies, PK_COI_Automobile_Policies);
    }
    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        // create object for curernt Automobile Policy
        COI_Automobile_Policies objAutomobilePolicy = new COI_Automobile_Policies(PK_COI_Automobile_Policies);

        // set values
        drpCompany.SelectedValue = objAutomobilePolicy.Insurance_Company;
        txtPolicyNumber.Text = objAutomobilePolicy.Policy_Number;
        uccalIssueDate.DateValue = objAutomobilePolicy.Issue_Date;
        txtEffectiveDate.DateValue = objAutomobilePolicy.Effective_Date;
        txtExpirationDate.DateValue = objAutomobilePolicy.Expiration_Date;
        txtExpirationDate.DateValue = objAutomobilePolicy.Expiration_Date;
        txtCancellationDate.DateValue = objAutomobilePolicy.Cancellation_Date;
        rdoAnyAuto.SelectedValue = objAutomobilePolicy.Any_Auto;
        rdoAllOwnedVehicles.SelectedValue = objAutomobilePolicy.All_Owned_Vehicles;
        rdoScheduledAutos.SelectedValue = objAutomobilePolicy.Scheduled_Autos;
        rdoHiredAutos.SelectedValue = objAutomobilePolicy.Hired_Autos;
        rdoNonOwnedAutos.SelectedValue = objAutomobilePolicy.Non_Owned_Autos;
        txtOtherCoverage.Text = objAutomobilePolicy.Other_Coverage;
        txtCombinedSingleLimit.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Combined_Single_Limit);
        txtBodilyInjuryPerson.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Bodily_Injury_Person);
        txtBodilyInjuryAccident.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Bodily_Injury_Accident);
        txtOtherLiability1.Text = objAutomobilePolicy.Other_Liability1;
        txtOtherLiabilityCoverage1.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Other_Liability_Coverage1);
        txtOtherLiability2.Text = objAutomobilePolicy.Other_Liability2;
        txtOtherLiabilityCoverage2.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Other_Liability_Coverage2);
        txtPropertyDamage.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Property_Damage);
        txtNotes.Text = objAutomobilePolicy.Notes;
        txtPhysicalDamageCollision.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Physical_Damage_Collision);
        txtPhysicalDamageComprehensive.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Physical_Damage_Comprehensive);
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt Automobile Policy
        COI_Automobile_Policies objAutomobilePolicy = new COI_Automobile_Policies(PK_COI_Automobile_Policies);

        // set values
        lblCompany.Text = objAutomobilePolicy.Insurance_Company;
        lblPolicyNumber.Text = objAutomobilePolicy.Policy_Number;
        lblIssueDate.Text = objAutomobilePolicy.Issue_Date.ToString(AppConfig.DisplayDateFormat);
        lblEffectiveDate.Text = objAutomobilePolicy.Effective_Date.ToString(AppConfig.DisplayDateFormat);
        lblExpirationDate.Text = objAutomobilePolicy.Expiration_Date.ToString(AppConfig.DisplayDateFormat);
        lblCancellationDate.Text = (objAutomobilePolicy.Cancellation_Date != DateTime.MinValue) ? objAutomobilePolicy.Cancellation_Date.ToString(AppConfig.DisplayDateFormat) : string.Empty;
        lblAnyAuto.Text = (objAutomobilePolicy.Any_Auto == "Y") ? "YES" : "NO";
        lblAllOwnedVehicles.Text = (objAutomobilePolicy.All_Owned_Vehicles == "Y") ? "YES" : "NO";
        lblScheduledAutos.Text = (objAutomobilePolicy.Scheduled_Autos == "Y") ? "YES" : "NO";
        lblHiredAutos.Text = (objAutomobilePolicy.Hired_Autos == "Y") ? "YES" : "NO";
        lblNonOwnedAutos.Text = (objAutomobilePolicy.Non_Owned_Autos == "Y") ? "YES" : "NO";
        lblOtherCoverage.Text = objAutomobilePolicy.Other_Coverage;
        lblCombinedSingleLimit.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Combined_Single_Limit);
        lblBodilyInjuryPerson.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Bodily_Injury_Person);
        lblBodilyInjuryAccident.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Bodily_Injury_Accident);
        lblPropertyDamage.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Property_Damage);
        lblNotes.Text = objAutomobilePolicy.Notes;
        lblOtherLiability1.Text = objAutomobilePolicy.Other_Liability1;
        lblOtherLiabilityCoverage1.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Other_Liability_Coverage1);
        lblOtherLiability2.Text = objAutomobilePolicy.Other_Liability2;
        lblOtherLiabilityCoverage2.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Other_Liability_Coverage2);
        lblPhysicalDamageCollision.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Physical_Damage_Collision);
        lblPhysicalDamageComprehensive.Text = clsGeneral.GetStringValue(objAutomobilePolicy.Physical_Damage_Comprehensive);
        lnkGeneralAdd.Style["Display"] = "None";
        lblNote.Style["Display"] = "None";

    }

    #endregion

    #region " Control Events "
    /// <summary>
    /// Handles Row Command Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAI_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveInsured")
        {
            COI_AI.Delete(Convert.ToDecimal(e.CommandArgument));
            BindInsuredGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(2);", true);
        }
    }

    // add or update producer record
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            SaveRecord();
            btnBack_Click(sender, e);
        }
    }
    /// <summary>
    /// Attachment Control Add Attachment Button event 
    /// </summary>
    /// <param name="sender"></param>
    protected void Attachment_btnHandler(object sender)
    {
        // check if producer reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Automobile_Policies > 0)
        {
            Attachment.Add(clsGeneral.Tables.Automobile_Liability_Policies, PK_COI_Automobile_Policies);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(3);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Automobile Liability Policies First');ShowPanel(1);", true);
    }

    // On Back button Click return to Parent Page
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (!clsGeneral.IsNull(Request.QueryString["op"]))
            Response.Redirect("COIAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=7");
        else
            Response.Redirect("COIAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=7");
    }
    /// <summary>
    /// Handles DummyForSave Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDummyForSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        string strPath = string.Empty;

        if (!string.IsNullOrEmpty(hdnPageName.Value))
        {
            if (hdnPageName.Value.IndexOf("?") > 0)
                strPath = hdnPageName.Value + "&Page=AL&prop=" + Encryption.Encrypt(PK_COI_Automobile_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString()) + "&op=" + Request.QueryString["op"];
            else
                strPath = hdnPageName.Value + "?Page=AL&prop=" + Encryption.Encrypt(PK_COI_Automobile_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString());
            Response.Redirect(strPath);
        }
    }
    #endregion

    #region "Dynamic Validations"
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Automobile Liability Policies"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(103).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 8").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Insurance Company":
                    strCtrlsIDs += drpCompany.ClientID + ",";
                    strMessages += "Please select [Automobile Liability Policies]/Insurance Company" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Policy Number":
                    strCtrlsIDs += txtPolicyNumber.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Policy Number" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Issue Date":
                    uccalIssueDate.IsRequiredField = true;
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Effective Date":
                    txtEffectiveDate.IsRequiredField = true;
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Expiration Date":
                    txtExpirationDate.IsRequiredField = true;
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Cancellation Date":
                    txtCancellationDate.IsRequiredField = true;
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Combined Single Limit":
                    strCtrlsIDs += txtCombinedSingleLimit.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Combined Single Limit" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Bodily Injury (Per Person)":
                    strCtrlsIDs += txtBodilyInjuryPerson.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Bodily Injury (Per Person)" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Bodily Injury (Per Accident)":
                    strCtrlsIDs += txtBodilyInjuryAccident.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Bodily Injury (Per Accident)" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Property Damage":
                    strCtrlsIDs += txtPropertyDamage.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Property Damage" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Physical Damage Comprehensive":
                    strCtrlsIDs += txtPhysicalDamageComprehensive.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Physical Damage Comprehensive" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Physical Damage Collision":
                    strCtrlsIDs += txtPhysicalDamageCollision.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Physical Damage Collision" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Other Liability1":
                    strCtrlsIDs += txtOtherLiability1.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Other Liability1" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Other Liability Coverage1":
                    strCtrlsIDs += txtOtherLiabilityCoverage1.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Other Liability1" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Other Liability2":
                    strCtrlsIDs += txtOtherLiability2.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Other Liability2" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Other Liability Coverage2":
                    strCtrlsIDs += txtOtherLiabilityCoverage2.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Other Liability2" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Other":
                    strCtrlsIDs += txtOtherCoverage.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Other" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Automobile Liability Policies]/Notes" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion
}
