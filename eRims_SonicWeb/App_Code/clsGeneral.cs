using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO.Compression;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Aspose;
using Aspose.Words;
using Winnovative.WnvHtmlConvert;
using System.ComponentModel;
using System.Collections;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

/// <summary>
/// Summary description for clsGeneral
/// </summary>
public class clsGeneral : System.Web.UI.Page
{
    public clsGeneral()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public enum SonicPageMode
    {
        View = 0,
        Edit = 1
    }

    /// <summary>
    /// User Status Enum,.
    /// </summary>
    public enum UserStatus
    {        
        InActive=3,        
        Pending=2,
        Active=1
    }


    #region " Get or Set QueryString"
    public static Decimal GetQueryStringID(string strID)
    {
        strID = (strID == null ? string.Empty : strID);
        decimal index;
        decimal PK_ID = 0;
        if (strID != string.Empty)
        {
            strID = Encryption.Decrypt(Convert.ToString(strID));
            if (decimal.TryParse(strID, out index))
                PK_ID = index;
        }
        return PK_ID;
    }

    public static int GetPanelId(string strId)
    {
        strId = (strId == null ? string.Empty : strId);
        int intOUT;
        int intID = 1;
        if (int.TryParse(strId, out  intOUT))
            intID = intOUT;
        return intID;
    }
    #endregion

    # region " Public Enums "


    /// <summary>
    /// string array used to get table name depending on the table array.
    /// </summary>
    public static string[] TableNames = { "WC_FR", "AL_FR", "DPD_FR", "Property_FR", "PL_FR", "Executive_Risk", "Executive_Risk_Carrier", "Defense_Attorney", "Plaintiff_Attorney", "Executive_Risk_Expenses", "Investigator_Notes", "Executive_Risk_Contacts", "WCClaim", "ALClaim", "PLClaim", "DPDClaim", "PropertyClaim", "Purchasing_Asset", "Purchasing_Service_Contract", "Purchasing_LR_Agreement", "RE_Information", "Policy", "Policy_Features", "Additional_Insured", "Automobile_Liability_Policies", "Insurance_Companies", "General_Liability_Policies", "Property_Policies", "Risk_Profile", "Producers", "WC_Policies", "Certificates_of_Insurance", "COI_Liquor_Policies", "Location", "Letter_History", "Owners", "Professional_Liability_Policies", "Excess_Liability_Policies", "Copies", "Insureds", "Franchise", "CRM_Customer", "CRM_Non_Customer", "Investigation", "", "", "Maintenance", "InspectionReport", "Property_Claims" };

    public static string[] ExposureTableNames = { "Property_Building", "Property_Ownership_SubLease", "Property_Assessment", "Inspection", "Inspection_Responses", "SLT_Safety_Walk_Attachments", "SLT_BT_Security_Walk_Attachments" };

    public static string[] ClaimTableName = { "WCClaim", "ALClaim", "PLClaim" };

    public static string[] PollutionTableName = { "PM_SI_UP_Attachments", "PM_SI_FI_Attachments", "PM_Permits_Attachments", "PM_CR_CI_Attachments", "PM_CR_PI_Attachments", "PM_Receiving_TSDF_Attachments", "PM_Waste_Hauler_Attachments", "PM_Waste_Removal_Attachments", "PM_Frequency_Attachments", "PM_Phase_I_Attachments", "PM_EPA_Inspection_Attachments", "PM_Remediation_Grid_Attachments", "PM_Violation_Attachments", "PM_Attachments", "PM_Equipment_Attachments", "PM_Equipment_Tank", "PM_Equipment_Spray_Booth", "PM_Equipment_OWS", "PM_Equipment_Hydraulic_Lift", "PM_Equipment_PGCC", "PM_CR_Grids_Attachments", "PM_Compliance_Reporting_OSHA_Attachments", "PM_Hearing_Conservation_Attachments", "PM_Respiratory_Protection_Attachments" };

    public static string[] SLT_TablesNames = { "SLT_Safety_Walk", "SLT_Training", "SLT_Meeting_Review", "Main_Wall_Attachment", "SLT_BT_Security_Walk", "Dashboard_Wall_Attachment" };

    public static string[] VideoRequestStatus = { "", "Submitted", "Sonic Approved", "Sonic Denied", "ACI Delivered", "Closed", "Pending"};

    /// <summary>
    /// enum is used to get table name to be used.
    /// </summary>
    public enum Tables : int
    {
        WC_FR = 0,
        AL_FR = 1,
        DPD_FR = 2,
        Property_FR = 3,
        PL_FR = 4,
        Executive_Risk = 5,
        Executive_Risk_Carrier = 6,
        Defense_Attorney = 7,
        Plaintiff_Attorney = 8,
        Executive_Risk_Expenses = 9,
        Investigator_Notes = 10,
        Executive_Risk_Contacts = 11,
        WCClaim = 12,
        ALClaim = 13,
        PLClaim = 14,
        DPDClaim = 15,
        PropertyClaim = 16,
        Purchasing_Asset = 17,
        Purchasing_Service_Contract = 18,
        Purchasing_LR_Agreement = 19,
        RE_Information = 20,
        Policy = 21,
        Policy_Features = 22,
        //---COI---
        Additional_Insured = 23,
        Automobile_Liability_Policies = 24,
        Insurance_Companies = 25,
        General_Liability_Policies = 26,
        Property_Policies = 27,
        Risk_Profile = 28,
        Producers = 29,
        WC_Policies = 30,
        Certificates_of_Insurance = 31,
        COI_Liquor_Policies = 32,
        Location = 33,
        Letter_History = 34,
        Owners = 35,
        Professional_Liability_Policies = 36,
        Excess_Liability_Policies = 37,
        Copies = 38,
        Insureds = 39,
        Franchise = 40,
        CRM_Customer = 41,
        CRM_Non_Customer = 42,
        Investigation = 43,

        Event = 44,
        Management = 45,
        Maintenance = 46,
        InspectionReport = 47,
        Property_Claims = 48,
        Event_Video_Tracking_Request = 49
    }

    public enum Major_Coverage : int
    {
        Event = 18,
        Management = 19,
        Property_Claims = 21,
        Event_Video_Tracking_Request = 22
    }

    public enum Claim_Tables : int
    {
        WCClaim = 0,
        ALClaim = 1,
        PLClaim = 2,
        DPDClaim = 3,
        PropertyClaim = 4,
        COIClaim = 5
    }

    public enum AP_Tables : int
    {
        AP_AL_FROIs = 0,
        AP_DPD_FROIs = 1
    }

    public enum COIs_Tables : int
    {
        COIs = 1,
    }

    public enum Exposure_Tables : int
    {
        Property_Building = 0,
        Property_Ownership_SubLease = 1,
        Property_Assessment = 2,
        Inspection = 3,
        Inspection_Responses = 4,
        SLT_Safety_Walk_Attachments = 5,
        SLT_BT_Security_Walk_Attachments = 6
    }

    public enum Exposure_Enviroment_Table
    {
        Enviro_Equipment = 0,
        Enviro_Permit = 1,
        Enviro_Inspection = 2,
        Enviro_SPCC = 3,
        Enviro_Phase1 = 4,
    }

    public enum EmailTYpe : int
    {
        Attachment = 1
    }

    public enum CRM_Tables
    {
        CRM_Customer = 1,
        CRM_Non_Customer = 2
    }
    public enum CRM_Note_Type : int
    {
        CRM_Customer_Complaint = 1,
        CRM_Customer_Notes = 2,
        CRM_Notes = 3,
        CRM_Resolution = 4
    }

    public enum Pollution_Tables : int
    {
        PM_SI_UP_Attachments = 0,
        PM_SI_FI_Attachments = 1,
        PM_Permits_Attachments = 2,
        PM_CR_CI_Attachments = 3,
        PM_CR_PI_Attachments = 4,
        PM_Receiving_TSDF_Attachments = 5,
        PM_Waste_Hauler_Attachments = 6,
        PM_Waste_Removal_Attachments = 7,
        PM_Frequency_Attachments = 8,
        PM_Phase_I_Attachments = 9,
        PM_EPA_Inspection_Attachments = 10,
        PM_Remediation_Grid_Attachments = 11,
        PM_Violation_Attachments = 12,
        PM_Attachments = 13,
        PM_Equipment_Attachments = 14,
        PM_Equipment_Tank = 15,
        PM_Equipment_Spray_Booth = 16,
        PM_Equipment_OWS = 17,
        PM_Equipment_Hydraulic_Lift = 18,
        PM_Equipment_PGCC = 19,
        PM_CR_Grids_Attachments = 20,
        PM_Compliance_Reporting_OSHA_Attachments = 21,
        PM_Hearing_Conservation_Attachments = 22,
        PM_Respiratory_Protection_Attachments = 23
    }

    public enum SLT_Tables : int
    {
        SLT_Safety_Walk = 0,
        SLT_Training = 1,
        SLT_Meeting_Review = 2, //#Issue 3439 pt. 4
        Main_Wall_Attachment = 3,
        SLT_BT_Security_Walk = 4,
        Dashboard_Wall_Attachment = 5
    }

    public enum VideoRequest_Status : int
    {
        Submitted = 1,
        Sonic_Approved = 2,
        Sonic_Denied = 3,
        ACI_Delivered = 4,
        Closed = 5,
        Pending = 6
    }

    //public enum TextBoxCssClass
    //{
    //    txtAddEdit = 0,
    //    txtView = 1
    //}

    ///// <summary>
    ///// set css class and mode of text box(readonly or read write) 
    ///// </summary>
    ///// <param name="objTextBox"></param>
    ///// <param name="CssClass"></param>
    ///// <returns></returns>
    //public static void setTextBoxMode(TextBox objTextBox, TextBoxCssClass CssClass)
    //{
    //    if (CssClass == TextBoxCssClass.txtAddEdit)
    //    {
    //        objTextBox.ReadOnly = false;
    //    }
    //    else
    //    {
    //        objTextBox.ReadOnly = true;
    //    }
    //    objTextBox.CssClass = CssClass.ToString();
    //}

    /// <summary>
    /// Fill Insurance Company Drop Down
    /// </summary>
    /// <param name="drpCompany"></param>
    /// <param name="FK_COI"></param>
    public static void FillIsuranceCompanyDropDown(DropDownList drpCompany, int FK_COI)
    {
        DataTable dtCompany = ERIMS.DAL.COI_Insurance_Companies.SelectByFK_COIs(FK_COI).Tables[0];
        drpCompany.DataSource = dtCompany;
        drpCompany.DataTextField = "Company";
        drpCompany.DataValueField = "Company";
        drpCompany.DataBind();
        drpCompany.Items.Insert(0, "--Select--");
    }

    /// <summary>
    /// return the doc path depending on the table used.
    /// </summary>
    /// <param name="tbl"></param>
    /// <returns></returns>
    public static string GetAttachmentDocPath(string tbl)
    {
        string strUploadPath = "";

        if (tbl == TableNames[(int)clsGeneral.Tables.WC_FR])
        {
            strUploadPath = AppConfig.WC_FRDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.AL_FR])
        {
            strUploadPath = AppConfig.AL_FRDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.DPD_FR])
        {
            strUploadPath = AppConfig.DPD_FRDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Property_FR])
        {
            strUploadPath = AppConfig.Property_FRDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.PL_FR])
        {
            strUploadPath = AppConfig.PL_FRDocPath;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Property_Building])
        {
            strUploadPath = AppConfig.BuildingAttachDocPath;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Property_Ownership_SubLease])
        {
            strUploadPath = AppConfig.LeaseSubleaseDocPath;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Property_Assessment])
        {
            strUploadPath = AppConfig.PropertyAssessmentDocPath;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Inspection])
        {
            strUploadPath = AppConfig.InspectionDocPath;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Inspection_Responses])
        {
            strUploadPath = AppConfig.InspectionFocusAreaDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Executive_Risk])
        {
            strUploadPath = AppConfig.ExecutiveRiskDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Investigator_Notes])
        {
            strUploadPath = AppConfig.InvestigatorNotesDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Executive_Risk_Contacts])
        {
            strUploadPath = AppConfig.Executive_Risk_ContactsDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Executive_Risk_Carrier])
        {
            strUploadPath = AppConfig.ExecutiveRiskCarrierDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Defense_Attorney])
        {
            strUploadPath = AppConfig.DefenseAttorneyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Plaintiff_Attorney])
        {
            strUploadPath = AppConfig.PlantiffAttorneyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Executive_Risk_Expenses])
        {
            strUploadPath = AppConfig.ExecutiveRiskExpensesDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.WCClaim])
        {
            strUploadPath = AppConfig.WCClaimDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.ALClaim])
        {
            strUploadPath = AppConfig.ALClaimDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.PLClaim])
        {
            strUploadPath = AppConfig.PLClaimDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.DPDClaim])
        {
            strUploadPath = AppConfig.DPDClaimDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.PropertyClaim])
        {
            strUploadPath = AppConfig.PropertyClaimDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Purchasing_Asset])
        {
            strUploadPath = AppConfig.PurchasingAssetDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Purchasing_Service_Contract])
        {
            strUploadPath = AppConfig.PurchasingServiceContractDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Purchasing_LR_Agreement])
        {
            strUploadPath = AppConfig.Purchasing_LR_AgreementDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.RE_Information])
        {
            strUploadPath = AppConfig.RealEstateDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Policy])
        {
            strUploadPath = AppConfig.PolicyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Policy_Features])
        {
            strUploadPath = AppConfig.PolicyFeatureDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Risk_Profile])
        {
            strUploadPath = AppConfig.Risk_ProfileDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Certificates_of_Insurance])
        {
            strUploadPath = AppConfig.Certificates_of_InsuranceDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.General_Liability_Policies])
        {
            strUploadPath = AppConfig.GeneralPolicyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Insurance_Companies])
        {
            strUploadPath = AppConfig.InsuranceCompanyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Letter_History])
        {
            strUploadPath = AppConfig.LetterHistoryDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Location])
        {
            strUploadPath = AppConfig.LocationDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Owners])
        {
            strUploadPath = AppConfig.OwnersDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Producers])
        {
            strUploadPath = AppConfig.ProducersDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Professional_Liability_Policies])
        {
            strUploadPath = AppConfig.ProfessionalPolicyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Property_Policies])
        {
            strUploadPath = AppConfig.PropertyPolicyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Risk_Profile])
        {
            strUploadPath = AppConfig.RiskProfileDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.WC_Policies])
        {
            strUploadPath = AppConfig.WCPolicyDocPath;
        }
        if (tbl == TableNames[(int)clsGeneral.Tables.Additional_Insured])
        {
            strUploadPath = AppConfig.AdditionalInsuredDocPath;
        }
        if (tbl == TableNames[(int)clsGeneral.Tables.Automobile_Liability_Policies])
        {
            strUploadPath = AppConfig.AutomobilePolicyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Excess_Liability_Policies])
        {
            strUploadPath = AppConfig.ExcessPolicyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.COI_Liquor_Policies])
        {
            strUploadPath = AppConfig.LiquorPolicyDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Copies])
        {
            strUploadPath = AppConfig.CopiesDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Franchise])
        {
            strUploadPath = AppConfig.FranchiseDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.CRM_Customer])
        {
            strUploadPath = AppConfig.CRMCustomerDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.CRM_Non_Customer])
        {
            strUploadPath = AppConfig.CRMNonCustomerDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_SI_UP_Attachments])
        {
            strUploadPath = AppConfig.PM_SI_UP_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Compliance_Reporting_OSHA_Attachments])
        {
            strUploadPath = AppConfig.PM_Compliance_Reporting_OSHA_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_SI_FI_Attachments])
        {
            strUploadPath = AppConfig.PM_SI_FI_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Permits_Attachments])
        {
            strUploadPath = AppConfig.Permits_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_CR_CI_Attachments])
        {
            strUploadPath = AppConfig.ChemicalInventory_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_CR_PI_Attachments])
        {
            strUploadPath = AppConfig.PaintInventory_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Receiving_TSDF_Attachments])
        {
            strUploadPath = AppConfig.Receiving_TSDF_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Waste_Hauler_Attachments])
        {
            strUploadPath = AppConfig.Waste_Hauler_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Waste_Removal_Attachments])
        {
            strUploadPath = AppConfig.Waste_Removal_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Frequency_Attachments])
        {
            strUploadPath = AppConfig.Frequency_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Phase_I_Attachments])
        {
            strUploadPath = AppConfig.Phase_I_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_EPA_Inspection_Attachments])
        {
            strUploadPath = AppConfig.EPA_Inspection_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Remediation_Grid_Attachments])
        {
            strUploadPath = AppConfig.Remediation_Grid_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Violation_Attachments])
        {
            strUploadPath = AppConfig.Violation_AttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Attachments])
        {
            strUploadPath = AppConfig.Site_Info_AttachmentDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_Attachments])
        {
            strUploadPath = AppConfig.StrPM_Equipment_AttachmentDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_Tank])
        {
            strUploadPath = AppConfig.StrEquipment_Tank_AttachmentDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_Spray_Booth])
        {
            strUploadPath = AppConfig.StrEquipment_Spray_Booth_AttachmentDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_Hydraulic_Lift])
        {
            strUploadPath = AppConfig.StrEquipment_Hydraulic_Lift_AttachmentDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_OWS])
        {
            strUploadPath = AppConfig.StrEquipment_OWS_AttachmentDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_PGCC])
        {
            strUploadPath = AppConfig.StrEquipment_PGCC_AttachmentDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_CR_Grids_Attachments])
        {
            strUploadPath = AppConfig.StrCR_Grids_AttachmentDocPath;
        }

        else if (tbl == SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_Safety_Walk])
        {
            strUploadPath = AppConfig.strSLT_SafetyWalkDocPath;
        }
        else if (tbl == SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_BT_Security_Walk])
        {
            strUploadPath = AppConfig.strSLT_BTSecurityWalkDocPath;
        }
        else if (tbl == SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_Training])
        {
            strUploadPath = AppConfig.strSLT_TrainingDocsPath;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.SLT_Safety_Walk_Attachments])
        {
            strUploadPath = AppConfig.strSLT_SafetyWalkDocPath;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.SLT_BT_Security_Walk_Attachments])
        {
            strUploadPath = AppConfig.strSLT_BTSecurityWalkDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Investigation])
        {
            strUploadPath = AppConfig.InvestigationDocPath;
        }
        else if (tbl == SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_Meeting_Review])
        {
            strUploadPath = AppConfig.strSLT_MeetingReviewDocsPath;
        }
        else if (tbl == SLT_TablesNames[(int)clsGeneral.SLT_Tables.Main_Wall_Attachment])
        {
            strUploadPath = AppConfig.strMain_Wall_Attachment;
        }
        else if (tbl == SLT_TablesNames[(int)clsGeneral.SLT_Tables.Dashboard_Wall_Attachment])
        {
            strUploadPath = AppConfig.strDashboard_Wall_Attachment;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Maintenance])
        {
            strUploadPath = AppConfig.MaintenanceDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.InspectionReport])
        {
            strUploadPath = AppConfig.InspectionDocPath;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Property_Claims])
        {
            strUploadPath = AppConfig.Property_ClaimsPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Hearing_Conservation_Attachments])
        {
            strUploadPath = AppConfig.PM_Hearing_ConservationAttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Respiratory_Protection_Attachments])
        {
            strUploadPath = AppConfig.PM_Respiratory_Protection_AttachmentsDocPath;
        }

        return strUploadPath;

    }

    /// <summary>
    /// return the doc path depending on the table used.
    /// </summary>
    /// <param name="tbl"></param>
    /// <returns></returns>
    public static string GetClaimAttachmentDocPath(string tbl)
    {
        string strUploadPath = "";
        if (tbl == ClaimTableName[(int)clsGeneral.Claim_Tables.WCClaim])
        {
            strUploadPath = AppConfig.WCClaimDocPath;
        }
        else if (tbl == ClaimTableName[(int)clsGeneral.Claim_Tables.ALClaim])
        {
            strUploadPath = AppConfig.ALClaimDocPath;
        }
        else if (tbl == ClaimTableName[(int)clsGeneral.Claim_Tables.PLClaim])
        {
            strUploadPath = AppConfig.PLClaimDocPath;
        }

        return strUploadPath;
    }

    /// <summary>
    /// return the image url depending on the table used.
    /// </summary>
    /// <param name="tbl"></param>
    /// <returns></returns>
    public static string GetClaimAttachmentImageURL(string tbl)
    {
        string strUploadPath = "";
        if (tbl == ClaimTableName[(int)clsGeneral.Claim_Tables.WCClaim])
        {
            strUploadPath = AppConfig.WCClaimImageURL;
        }
        else if (tbl == ClaimTableName[(int)clsGeneral.Claim_Tables.ALClaim])
        {
            strUploadPath = AppConfig.ALClaimImageURL;
        }
        else if (tbl == ClaimTableName[(int)clsGeneral.Claim_Tables.PLClaim])
        {
            strUploadPath = AppConfig.PLClaimImageURL;
        }

        return strUploadPath;
    }


    /// <summary>
    /// return the image url depending on the table used.
    /// </summary>
    /// <param name="tbl"></param>
    /// <returns></returns>
    public static string GetAttachmentImageURL(string tbl)
    {
        string strUploadPath = "";
        if (tbl == TableNames[(int)clsGeneral.Tables.WC_FR])
        {
            strUploadPath = AppConfig.WC_FRImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.AL_FR])
        {
            strUploadPath = AppConfig.AL_FRImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.DPD_FR])
        {
            strUploadPath = AppConfig.DPD_FRImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Property_FR])
        {
            strUploadPath = AppConfig.Property_FRImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.PL_FR])
        {
            strUploadPath = AppConfig.PL_FRImageURL;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Property_Building])
        {
            strUploadPath = AppConfig.BuildingAttachDocURL;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Property_Ownership_SubLease])
        {
            strUploadPath = AppConfig.LeaseSubleaseDocURL;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Property_Assessment])
        {
            strUploadPath = AppConfig.PropertyAssessmentDocURL;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Inspection])
        {
            strUploadPath = AppConfig.InspectionDocURL;
        }
        else if (tbl == ExposureTableNames[(int)clsGeneral.Exposure_Tables.Inspection_Responses])
        {
            strUploadPath = AppConfig.InspectionFocusAreaDocURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Executive_Risk])
        {
            strUploadPath = AppConfig.ExecutiveRiskDocURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Investigator_Notes])
        {
            strUploadPath = AppConfig.InvestigatorNotesDocURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Executive_Risk_Contacts])
        {
            strUploadPath = AppConfig.Executive_Risk_ContactsDocURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Executive_Risk_Carrier])
        {
            strUploadPath = AppConfig.ExecutiveRiskCarrierImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Defense_Attorney])
        {
            strUploadPath = AppConfig.DefenseAttorneyIamgeURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Plaintiff_Attorney])
        {
            strUploadPath = AppConfig.PlantiffAttorneyImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Executive_Risk_Expenses])
        {
            strUploadPath = AppConfig.ExecutiveRiskExpensesImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.WCClaim])
        {
            strUploadPath = AppConfig.WCClaimImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.ALClaim])
        {
            strUploadPath = AppConfig.ALClaimImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.PLClaim])
        {
            strUploadPath = AppConfig.PLClaimImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.DPDClaim])
        {
            strUploadPath = AppConfig.DPDClaimImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.PropertyClaim])
        {
            strUploadPath = AppConfig.PropertyClaimImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Purchasing_Asset])
        {
            strUploadPath = AppConfig.PurchasingAssetImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Purchasing_Service_Contract])
        {
            strUploadPath = AppConfig.PurchasingServiceContractImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Purchasing_LR_Agreement])
        {
            strUploadPath = AppConfig.Purchasing_LR_AgreementImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.RE_Information])
        {
            strUploadPath = AppConfig.RealEstateImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Policy])
        {
            strUploadPath = AppConfig.PolicyDocURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Policy_Features])
        {
            strUploadPath = AppConfig.PolicyFeatureDocURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Risk_Profile])
        {
            strUploadPath = AppConfig.Risk_ProfileDocURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Certificates_of_Insurance])
        {
            strUploadPath = AppConfig.Certificates_of_InsuranceDocURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.General_Liability_Policies])
        {
            strUploadPath = AppConfig.GeneralPolicyImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Location])
        {
            strUploadPath = AppConfig.LocationImageURL;
        }
        if (tbl == TableNames[(int)clsGeneral.Tables.Additional_Insured])
        {
            strUploadPath = AppConfig.AdditionalInsuredImageURL;
        }
        if (tbl == TableNames[(int)clsGeneral.Tables.Automobile_Liability_Policies])
        {
            strUploadPath = AppConfig.AutomobilePolicyImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Excess_Liability_Policies])
        {
            strUploadPath = AppConfig.ExcessPolicyImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.WC_Policies])
        {
            strUploadPath = AppConfig.WCPolicyImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Property_Policies])
        {
            strUploadPath = AppConfig.PropertyPolicyImageURL;
        }

        else if (tbl == TableNames[(int)clsGeneral.Tables.Professional_Liability_Policies])
        {
            strUploadPath = AppConfig.ProfessionalPolicyImageURL;
        }

        else if (tbl == TableNames[(int)clsGeneral.Tables.COI_Liquor_Policies])
        {
            strUploadPath = AppConfig.LiquorPolicyImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Insurance_Companies])
        {
            strUploadPath = AppConfig.InsuranceCompanyImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Producers])
        {
            strUploadPath = AppConfig.ProducersImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Owners])
        {
            strUploadPath = AppConfig.OwnersImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Copies])
        {
            strUploadPath = AppConfig.CopiesImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.Franchise])
        {
            strUploadPath = AppConfig.FranchiseImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.CRM_Customer])
        {
            strUploadPath = AppConfig.CRMCustomerImageURL;
        }
        else if (tbl == TableNames[(int)clsGeneral.Tables.CRM_Non_Customer])
        {
            strUploadPath = AppConfig.CRMNonCustomerImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_SI_UP_Attachments])
        {
            strUploadPath = AppConfig.PM_SI_UP_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Compliance_Reporting_OSHA_Attachments])
        {
            strUploadPath = AppConfig.PM_Compliance_Reporting_OSHA_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_SI_FI_Attachments])
        {
            strUploadPath = AppConfig.PM_SI_FI_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Permits_Attachments])
        {
            strUploadPath = AppConfig.Permits_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_CR_CI_Attachments])
        {
            strUploadPath = AppConfig.ChemicalInventory_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_CR_PI_Attachments])
        {
            strUploadPath = AppConfig.PaintInventory_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Receiving_TSDF_Attachments])
        {
            strUploadPath = AppConfig.Receiving_TSDF_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Waste_Hauler_Attachments])
        {
            strUploadPath = AppConfig.Waste_Hauler_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Waste_Removal_Attachments])
        {
            strUploadPath = AppConfig.Waste_Removal_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Frequency_Attachments])
        {
            strUploadPath = AppConfig.Frequency_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Phase_I_Attachments])
        {
            strUploadPath = AppConfig.Phase_I_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_EPA_Inspection_Attachments])
        {
            strUploadPath = AppConfig.EPA_Inspection_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Remediation_Grid_Attachments])
        {
            strUploadPath = AppConfig.Remediation_Grid_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Violation_Attachments])
        {
            strUploadPath = AppConfig.Violation_AttachmentsImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Attachments])
        {
            strUploadPath = AppConfig.Site_Info_AttachmentImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_Tank])
        {
            strUploadPath = AppConfig.StrEquipment_Tank_AttachmentImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_Spray_Booth])
        {
            strUploadPath = AppConfig.StrEquipment_Spray_Booth_AttachmentImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_Hydraulic_Lift])
        {
            strUploadPath = AppConfig.StrEquipment_Hydraulic_Lift_AttachmentImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_OWS])
        {
            strUploadPath = AppConfig.StrEquipment_OWS_AttachmentImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_PGCC])
        {
            strUploadPath = AppConfig.StrEquipment_PGCC_AttachmentImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_CR_Grids_Attachments])
        {
            strUploadPath = AppConfig.StrCR_Grids_AttachmentImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Equipment_Attachments])
        {
            strUploadPath = AppConfig.StrPM_Equipment_AttachmentImageURL;
        }
        else if (tbl == SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_Safety_Walk])
        {
            strUploadPath = AppConfig.strSLT_SafetyWalkImageURL;
        }
        else if (tbl == SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_Training])
        {
            strUploadPath = AppConfig.strSLT_TrainingImageURL;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Hearing_Conservation_Attachments])
        {
            strUploadPath = AppConfig.PM_Hearing_ConservationAttachmentsDocPath;
        }
        else if (tbl == PollutionTableName[(int)clsGeneral.Pollution_Tables.PM_Respiratory_Protection_Attachments])
        {
            strUploadPath = AppConfig.PM_Respiratory_Protection_AttachmentsDocPath;
        }
        return strUploadPath;
    }

    /// <summary>
    /// Redirects back to the COI page from 
    /// the currenly opened page with the grid displaying on top of the page
    /// </summary>
    /// <param name="currentPage">currenly opened page</param>
    /// <param name="strGrid">the grid band to be displayed on top of the COI page</param>
    /// <param name="FK_COI">the primary key for COI</param>
    public static void RedirectToCOIPage(System.Web.UI.Page currentPage, string strGrid, decimal FK_COI)
    {
        string retUrl = "";
        if (!clsGeneral.IsNull(HttpContext.Current.Request.QueryString["op"]))
            retUrl = "COIAddEdit.aspx?op=" + HttpContext.Current.Request.QueryString["op"] + "&id=" + FK_COI.ToString() + "#" + strGrid;
        else
            retUrl = "COIAddEdit.aspx?op=edit&id=" + FK_COI.ToString() + "#" + strGrid;


        currentPage.ClientScript.RegisterStartupScript(currentPage.GetType(), "redirectPage", "javascript:RedirectToPage('" + retUrl + "');", true);
    }

    /// <summary>
    /// return the doc path depending on the Folder Name.
    /// </summary>
    /// <param name="FolderName"> Name of Folder</param>
    /// <returns> Physical Path of Environment Attachment file </returns>
    public static string GetEnvironment_AttachmentDocPath(string FolderName)
    {
        string strUploadPath = "";

        strUploadPath = AppConfig.EnvirontmentPath + FolderName + "\\";

        return strUploadPath;
    }
    /// <summary>
    /// return the doc path depending on the Folder Name.
    /// </summary>
    /// <param name="FolderName"> Name of Folder</param>
    /// <returns> Physical Path of Environment Attachment file </returns>
    public static string GetEnvironment_AttachmentURL(string FolderName)
    {
        string strUploadURL = "";

        strUploadURL = AppConfig.EnvirontmentURL + FolderName + "/";

        return strUploadURL;
    }

    # endregion

    #region " IO Functions like Upload,Copy,Created Directory , Clear Directory "

    /// <summary>
    /// Creates directory if it doesn't exists
    /// </summary>
    /// <param name="strPath"></param>
    public static void CreateDirectory(string strPath)
    {
        if (!Directory.Exists(strPath))
        {
            Directory.CreateDirectory(strPath);
        }
    }

    /// <summary>
    /// remove all the files from this directory.
    /// if directory doesn't exists , create a blank directory.
    /// </summary>
    /// <param name="strDirPath"></param>
    public static void ClearDirectory(string strDirPath)
    {
        CreateDirectory(strDirPath);
        foreach (string strFileName in Directory.GetFiles(strDirPath))
        {
            File.Delete(strFileName);
        }
    }

    /// <summary>
    /// copy file
    /// </summary>
    /// <param name="strFilePathFrom">full src file path</param>
    /// <param name="strFilePathTo">full dest file path</param>
    /// <param name="OverWrite">if owerwrite = false , file will be renamed if needed.</param>
    /// <param name="RemoveAllFiles">remove all other file from des dir.</param>
    /// <returns>File name(not full path)</returns>
    public static string CopyFile(string strFilePathFrom, string strFilePathTo, bool OverWrite, bool RemoveAllFiles)
    {
        if (strFilePathFrom.Contains("/"))
            strFilePathFrom = strFilePathFrom.Replace('/', '\\');

        if (strFilePathTo.Contains("/"))
            strFilePathTo = strFilePathTo.Replace('/', '\\');


        if (RemoveAllFiles)
        {
            string strDir = GetFilePath(strFilePathTo);
            ClearDirectory(strDir);
        }

        // if don't want to over write rename the file.
        if (!OverWrite)
        {
            strFilePathTo = GetFileNameToSave(strFilePathTo);
        }

        File.Copy(strFilePathFrom, strFilePathTo, OverWrite);

        return GetFileName(strFilePathTo);
    }

    /// <summary>
    /// Copy File with rename.
    /// </summary>
    /// <param name="strSrcFilePath">Source File path</param>
    /// <param name="strDestFilePath">Destination Direcotory</param>
    /// <param name="strDestFileName">New File Name without extension</param>
    /// <param name="OverWrite">if true overwrite else not.</param>
    /// <param name="RemoveAllFiles">if true remove all other files from destination directory.</param>
    /// <remarks></remarks>
    /// <returns>File name(not full path)</returns>
    public static string CopyFile(string strSrcFilePath, string strDestFilePath, string strDestFileName, bool OverWrite, bool RemoveAllFiles)
    {
        if (!strDestFilePath.EndsWith("\\"))
        {
            strDestFilePath = string.Concat(strDestFilePath, "\\");
        }

        if (strDestFilePath.Contains("/"))
            strDestFilePath = strDestFilePath.Replace('/', '\\');

        if (strSrcFilePath.Contains("/"))
            strSrcFilePath = strSrcFilePath.Replace('/', '\\');

        if (RemoveAllFiles)
        {
            ClearDirectory(strDestFilePath);
        }
        string strExt = clsGeneral.GetExtension(strSrcFilePath);

        // if don't want to over write rename the file.
        string strFilePathTo = string.Concat(strDestFilePath, strDestFileName, strExt);
        if (!OverWrite)
        {
            strFilePathTo = GetFileNameToSave(strFilePathTo);
        }

        File.Copy(strSrcFilePath, strFilePathTo, OverWrite);

        return GetFileName(strFilePathTo);
    }

    /// <summary>
    /// when uploading and copying if don't need to overwrite, rename the file and return new file name.
    /// </summary>
    /// <param name="strFullName">full path to file name</param>
    /// <returns>returns new file name if already a filename with that name exists</returns>
    public static string GetFileNameToSave(string strFullName)
    {
        // get the path to which we need to save the file.
        string strPath = GetFilePath(strFullName);

        // get the extension of file name that will be used to create new file if it exists
        string strExt = GetExtension(strFullName);

        //string strFileName = GetFileName(strFullName).Replace(strExt, "").Trim();
        
        string strFileName = string.Empty;
        // get filename without extension
        if (!string.IsNullOrEmpty(strExt))
            strFileName = GetFileName(strFullName).Replace(strExt, "").Trim();
        else
            strFileName = GetFileName(strFullName);

        // append time
        strFileName = System.DateTime.Now.ToString("MMddyyhhmmss") + strFileName.Replace(",", "").Replace(";", "").Replace("&", "");

        if (File.Exists(strFullName))
        {
            // create a first file name.
            int FileCount = 1;
            string strRetVal = string.Concat(strPath, strFileName, FileCount.ToString(), strExt);
            while (File.Exists(strRetVal))
            {
                FileCount++;
                strRetVal = string.Concat(strPath, strFileName, FileCount.ToString(), strExt);
            }
            //strRetVal = System.DateTime.Now.ToString("MMddyyhhmmss") + strRetVal;
            return strRetVal;
        }
        else
        {
            return string.Concat(strPath, strFileName, strExt);
        }

    }

    /// <summary>
    /// Uploads file. this function is used if you need to upload file with different name.
    /// </summary>
    /// <param name="fp">FileUploadControl which contains the file</param>
    /// <param name="strPath">Path to which file needed to be uploaded</param>
    /// <param name="strFileName">File Name - if not passed a file name from fileupload control will be used.</param>
    /// <param name="RemoveAllFiles">if true,all other files at strPath will be deleted.</param>
    /// <param name="OverWrite">OverWrite file if exists or not. if no then it will rename file to be uploaded.</param>
    /// <returns>filename with extension</returns>
    public static string UploadFile(FileUpload fp, string strPath, string strFileName, bool RemoveAllFiles, bool OverWrite)
    {

        if (fp.FileContent.Length > 0 && fp.FileContent.Length <= AppConfig.MaxRequestLength)
        {
            CreateDirectory(strPath);
            if (RemoveAllFiles)
            {
                ClearDirectory(strPath);
            }
            if (!strPath.EndsWith("\\"))
            {
                strPath = string.Concat(strPath, "\\");
            }
            if (strPath.Contains("/"))
                strPath = strPath.Replace('/', '\\');

            if (string.IsNullOrEmpty(strFileName))
            {
                strFileName = fp.FileName;
            }
            else
            {
                strFileName = string.Concat(strFileName, clsGeneral.GetExtension(fp.FileName));
            }
            // now check for file name exists or not. and option for overwrite
            string strFulleName = string.Concat(strPath, strFileName);
            if (OverWrite)
            {
                // if overwrite is allowed then remove if already exists.
                if (File.Exists(strFulleName))
                {
                    File.Delete(strFulleName);
                }
                fp.PostedFile.SaveAs(strFulleName);
            }
            else
            {
                // if overwrite is not allowed then get filename to save.
                strFulleName = GetFileNameToSave(strFulleName);
                fp.PostedFile.SaveAs(strFulleName);

                // set return value = only filename.
                strFileName = GetFileName(strFulleName);
            }

            return strFileName;
        }
        else
        {
            HttpContext.Current.Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=The file you are attempting to upload is too large, please try again with a smaller file.");
            return "";
        }
    }

    /// <summary>
    /// Uploads file.
    /// </summary>
    /// <param name="fp">FileUploadControl which contains the file</param>
    /// <param name="strPath">Path to which file needed to be uploaded</param>
    /// <param name="RemoveAllFiles">if true,all other files at strPath will be deleted.</param>
    /// <param name="OverWrite">OverWrite file if exists or not. if no then it will rename file to be uploaded.</param>
    /// <returns>filename with extension</returns>
    public static string UploadFile(FileUpload fp, string strPath, bool RemoveAllFiles, bool OverWrite)
    {
        string strRetVal = "";
        if (fp.FileContent.Length > 0 && fp.FileContent.Length <= AppConfig.MaxRequestLength)
        {
            // set path.
            if (!strPath.EndsWith("\\"))
            {
                strPath = string.Concat(strPath, "\\");
            }
            if (strPath.Contains("/"))
                strPath = strPath.Replace('/', '\\');

            // create dir if doesnt' exists
            CreateDirectory(strPath);

            // clear direct. if needed
            if (RemoveAllFiles)
            {
                ClearDirectory(strPath);
            }

            // now check for file name exists or not. and option for overwrite
            string strFulleName = string.Concat(strPath, fp.FileName);
            if (OverWrite)
            {
                // if overwrite is allowed then remove if already exists.
                if (File.Exists(strFulleName))
                {
                    File.Delete(strFulleName);
                }
                fp.PostedFile.SaveAs(strFulleName);
            }
            else
            {
                // if overwrite is not allowed then get filename to save.
                strFulleName = GetFileNameToSave(strFulleName);
                fp.PostedFile.SaveAs(strFulleName);

                // set return value = only filename.
                strRetVal = GetFileName(strFulleName);
            }
            return strRetVal;
        }
        else
        {
            HttpContext.Current.Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=The file you are attempting to upload is too large, please try again with a smaller file.");
            return "";
        }

    }

    #endregion

    #region " Utility Functions "

    /// <summary>
    /// Display Incident Type
    /// </summary>
    /// <param name="strIncidentType"></param>
    /// <returns></returns>
    public static string GetDPDIncidentType(object obj)
    {
        string strIncidentType = Convert.ToString(obj);
        string strType = string.Empty;
        if (!string.IsNullOrEmpty(strIncidentType))
        {
            switch (strIncidentType)
            {
                case "1":
                    strType = "MVA-Single";
                    break;
                case "2":
                    strType = "MVA-Multiple";
                    break;
                case "3":
                    strType = "Fraud";
                    break;
                case "4":
                    strType = "Theft";
                    break;
                case "5":
                    strType = "Partial Theft";
                    break;
                case "6":
                    strType = "Vandalism";
                    break;
                case "7":
                    strType = "Hail";
                    break;
                case "8":
                    strType = "Flood";
                    break;
                case "9":
                    strType = "Fire";
                    break;
                case "10":
                    strType = "Wind";
                    break;
                default:
                    strType = string.Empty;
                    break;
            }
        }
        return strType;
    }

    /// <summary>
    /// Returns FileName with extension from passed URL or FilePath.
    /// </summary>
    /// <param name="strFilePath"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static string GetFileName(string strFilePath)
    {
        string strRetVal = strFilePath;
        if (!string.IsNullOrEmpty(strRetVal))
        {
            if (strFilePath.Contains("\\") && strFilePath.Contains("/"))
            {
                int ForwardSlashIndex = strFilePath.IndexOf("/");
                int BackSlashIndex = strFilePath.IndexOf("\\");
                if (ForwardSlashIndex > BackSlashIndex)
                {
                    strRetVal = strFilePath.Substring(strFilePath.LastIndexOf("/") + 1);
                }
                else
                {
                    strRetVal = strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1);
                }
            }
            else if (strFilePath.Contains("\\"))
            {
                strRetVal = strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1);
            }
            else if (strFilePath.Contains("/"))
            {
                strRetVal = strFilePath.Substring(strFilePath.LastIndexOf("/") + 1);
            }
        }
        else
        {
            strRetVal = "";
        }
        return strRetVal;
    }

    /// <summary>
    /// Returns extension of file with .(dot)
    /// </summary>
    /// <param name="strFile">it can be fileURL,filePath or filename.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static string GetExtension(string strFile)
    {
        string strRetVal = "";
        if ((strFile.Contains(".")))
        {
            strRetVal = strFile.Substring(strFile.LastIndexOf("."));
        }
        return strRetVal;
    }

    /// <summary>
    /// Retuns URL or Path in which file resides
    /// </summary>
    /// <param name="strFilePath">Complete File Path</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static string GetFilePath(string strFilePath)
    {
        string strRetVal = strFilePath;
        if (!string.IsNullOrEmpty(strRetVal))
        {
            if (strFilePath.Contains("\\") && strFilePath.Contains("/"))
            {
                int ForwardSlashIndex = strFilePath.IndexOf("/");
                int BackSlashIndex = strFilePath.IndexOf("\\");
                if (ForwardSlashIndex > BackSlashIndex)
                {
                    strRetVal = strFilePath.Substring(0, strFilePath.LastIndexOf("/") + 1);
                }
                else
                {
                    strRetVal = strFilePath.Substring(0, strFilePath.LastIndexOf("\\") + 1);
                }
            }
            else if (strFilePath.Contains("\\"))
            {
                strRetVal = strFilePath.Substring(0, strFilePath.LastIndexOf("\\") + 1);
            }
            else if (strFilePath.Contains("/"))
            {
                strRetVal = strFilePath.Substring(0, strFilePath.LastIndexOf("/") + 1);
            }
        }
        else
        {
            strRetVal = "";
        }
        return strRetVal;
    }

    /// <summary>
    /// Check whether file/folder name is valid or not. 
    /// </summary>
    /// <param name="filename"> Name of file or Folder</param>
    /// <returns>Boolean</returns>
    public static bool IsValidFilename(string filename)
    {
        // Get a list of invalid file characters.
        char[] invalidFileChars = Path.GetInvalidFileNameChars();
        return (filename.IndexOfAny(invalidFileChars) < 0);

    }

    /// <summary>
    /// used to get value of control
    /// </summary>
    /// <param name="ClientId"></param>
    /// <returns></returns>
    public static string RequestValue(string ClientId)
    {

        string strVal = HttpContext.Current.Request.Form[ClientId.Replace("_", "$")];
        if (strVal == string.Empty)
            strVal = "0";
        return strVal;
    }

    /// <summary>
    /// check if object that needed to be converted to STRIN is null or blank or not.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsNull(object obj)
    {
        if (obj == null)
            return true;
        else
        {
            string str = Convert.ToString(obj);
            return string.IsNullOrEmpty(str);
        }
    }

    /// <summary>
    /// if object is not able to be converted to int, it returns 0
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static int GetInt(object obj)
    {
        string strObj = Convert.ToString(obj);
        int result;
        int.TryParse(strObj, out result);
        return result;
    }

    public static decimal GetDecimal(object obj)
    {
        string strObj = Convert.ToString(obj);
        decimal result;
        decimal.TryParse(strObj, out result);
        return result;
    }

    /// <summary>
    /// if object is not able to be converted to long, it returns 0
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static long GetLong(object obj)
    {
        string strObj = Convert.ToString(obj);
        long result;
        long.TryParse(strObj, out result);
        return result;
    }

    /// <summary>
    /// checks for the textbox value and converts it into decimal , if empty value then 0
    /// </summary>
    /// <param name="txtObject"></param>
    /// <returns></returns>
    public static decimal GetDecimalValue(TextBox txtObject)
    {
        if (txtObject.Text != string.Empty)
        {
            return Convert.ToDecimal(txtObject.Text.Trim().Replace(",", ""));
        }
        else
            return 0;
    }

    /// <summary>
    /// checks for the textbox value and converts it into decimal , if empty value then 0
    /// </summary>
    /// <param name="txtObject"></param>
    /// <returns></returns>
    public static Nullable<decimal> GetDecimalNullableValue(TextBox txtObject)
    {
        if (txtObject.Text != string.Empty)
        {
            return Convert.ToDecimal(txtObject.Text.Trim().Replace(",", ""));
        }
        else
            return null;
    }

    public static object FormatDecimalToStoreInDB(Nullable<decimal> objVal)
    {
        if (objVal == null)
            return DBNull.Value;
        else
            return objVal;
    }

    public static string FormatDBNULLTostring(object ObjString)
    {
        if (ObjString == DBNull.Value || ObjString == null || ObjString == "")
            return string.Empty;
        else
            return Convert.ToString(ObjString);
    }

    /// <summary>
    /// Converts decimal value to string to be displayed in labels
    /// </summary>
    /// <param name="decValue"></param>
    /// <returns></returns>
    public static string GetStringValue(object objValue)
    {
        if (objValue == null || objValue == DBNull.Value)
            return string.Empty;
        else
            return Convert.ToDecimal(objValue).ToString("C").Replace("$", "");
    }

    /// <summary>
    /// Sets the dates for the labels which are not mendatory fields,
    /// it may have Minvalue (01/01/1975) which should return an empty string
    /// </summary>
    /// <param name="objDT"></param>
    /// <returns></returns>
    public static string FormatDateToDisplay(DateTime objDate)
    {
        if (objDate != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
            return objDate.ToString(AppConfig.DisplayDateFormat);
        else
            return string.Empty;
    }

    public static string FormatDBNullDateTimeToDisplay(object objDate)
    {
        if (objDate == DBNull.Value || objDate == null)
            return string.Empty;
        else
            return Convert.ToDateTime(objDate).ToString(AppConfig.DisplayDateFormat.Replace("HH:mm", "").Trim() + " HH:mm");
    }

    public static string FormatDBNullDateTimeToMilitaryDateTime(object objDate)
    {
        if (objDate == DBNull.Value || objDate == null)
            return string.Empty;
        else
            return Convert.ToDateTime(objDate).ToString(AppConfig.DisplayDateFormat.Replace("HH:mm", "").Trim() + " HHmm");
    }

    /// <summary>
    /// return Date in short date format if it is null then it return minimum value 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static DateTime FormatDateToStore(object objDate)
    {
        if (!String.IsNullOrEmpty(Convert.ToString(objDate)))
        {
            return Convert.ToDateTime(objDate.ToString());
        }
        else
        {
            return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }
    }

    /// <summary>
    /// used to format time from 00:00 to 0000 format
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static int FormatTimeToStore(object objTime)
    {
        if (!String.IsNullOrEmpty(objTime.ToString()))
            return Convert.ToInt32(objTime.ToString().Remove(2, 1));
        else
            return 0000;
    }

    /// <summary>
    /// used to format time from 0000 to 00:00 format
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string FormatTimeToDisplay(object objTime)
    {
        if (!String.IsNullOrEmpty(objTime.ToString()) && (objTime.ToString() != "0"))
            return objTime.ToString().Insert(2, ":");
        else
            return String.Empty;
    }

    /// <summary>
    /// return Date in short date format if it is null then it return minimum value 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static DateTime FormatDateToStore(TextBox objDate)
    {
        if (!String.IsNullOrEmpty(objDate.Text.Trim()))
        {
            return Convert.ToDateTime(objDate.Text.Trim());
        }
        else
        {
            return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }
    }

    /// <summary>
    /// Sets the dates for the labels which are not mandatory fields,
    /// it may have null value which should return an empty string
    /// </summary>
    /// <param name="objDate"></param>
    /// <returns></returns>
    public static string FormatDBNullDateToDisplay(object objDate)
    {
        if (objDate == DBNull.Value || objDate == null || objDate == "")
            return string.Empty;
        else
        {
            if (Convert.ToDateTime(objDate) != System.Data.SqlTypes.SqlDateTime.MinValue)
                return Convert.ToDateTime(objDate).ToString(AppConfig.DisplayDateFormat);
            else
                return "";
        }
    }

    /// <summary>
    /// Sets the dates for the labels which are not mendatory fields,
    /// it may have null value which should return an empty string
    /// </summary>
    /// <param name="objDate"></param>
    /// <returns></returns>
    /// Note:- verify before using this function it will return current date when null Date Passed
    public static DateTime FormatDBNullDateToDate(object objDate)
    {
        if (objDate == DBNull.Value || objDate == null || objDate == "")
            return DateTime.Now;
        else
        {
            if (Convert.ToDateTime(objDate) != System.Data.SqlTypes.SqlDateTime.MinValue)
                return Convert.ToDateTime(objDate);
            else
                return DateTime.Now;
        }
    }

    /// <summary>
    /// Sets the dates for the labels which are not mandatory fields,
    /// it may have null value which should return an empty string
    /// </summary>
    /// <param name="objDate"></param>
    /// <returns></returns>
    public static string FormatDBNullDateToDisplay_Claim(object objDate)
    {
        if (objDate == DBNull.Value || objDate == null)
            return string.Empty;
        else
            return FormatDateToDisplay(Convert.ToDateTime(objDate));
    }

    /// <summary>
    /// return Date in short date format if it is null then it return null value
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static Nullable<DateTime> FormatNullDateToStore(string strDate)
    {
        if (!String.IsNullOrEmpty(strDate.Trim()))
        {
            return Convert.ToDateTime(strDate.Trim());
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Convert Object To Nullable boolean Value
    /// </summary>
    /// <param name="objBoolValue"> Object </param>
    /// <returns> Nullable<bool> </returns>
    public static Nullable<bool> GetNullBooleanValue(object objBoolValue)
    {
        if (objBoolValue == DBNull.Value || objBoolValue == null)
        {
            return null;
        }
        else
        {
            return Convert.ToBoolean(objBoolValue);
        }
    }
    /// <summary>
    /// Use to get Yes NO value from Radio BUtton list
    /// </summary>
    /// <param name="objRdo"></param>
    /// <returns></returns>
    public static Nullable<bool> FormatYesNoToStore(RadioButtonList objRdo)
    {
        if (objRdo.SelectedIndex > -1)
            return Convert.ToBoolean(Convert.ToInt32(objRdo.SelectedValue));
        else
            return null;
    }

    /// <summary>
    /// used to store Yes/No value into DB
    /// </summary>
    /// <param name="objVal"></param>
    /// <returns></returns>
    public static object FormatYesNoToStoreInDB(Nullable<bool> objVal)
    {
        if (objVal != null)
            return objVal;
        else
            return DBNull.Value;
    }

    /// <summary>
    /// Used to display No and Yes as per value return from radio button list.
    /// </summary>
    /// <param name="objVal"></param>
    /// <returns></returns>
    public static string FormatYesNoToDisplayForView(object objVal)
    {
        if (objVal == null || objVal == DBNull.Value)
            return "";
        else
            return (Convert.ToBoolean(objVal) == false ? "No" : "Yes");

    }

    public static string FormatYesNoToDisplay(object objVal)
    {
        if (objVal == null || objVal == DBNull.Value)
            return "";
        else
            return (objVal.ToString() == "N" ? "No" : "Yes");

    }

    public static string FormatCommaSeperatorNumber(object objVal)
    {
        if (objVal == null || objVal == DBNull.Value)
            return "";
        else
            return (String.Format("{0:N0}", Convert.ToDecimal(objVal.ToString())));

    }

    public static string FormatCommaSeperatorCurrency(object objVal)
    {
        if (objVal == null || objVal == DBNull.Value)
            return "";
        else
            return (String.Format("{0:N2}", Convert.ToDecimal(objVal.ToString())));

    }

    /// <summary>
    /// Used to display No and Yes as per value return from radio button list.
    /// </summary>
    /// <param name="objVal"></param>
    /// <returns></returns>
    public static string FormatYesNoUnknownToDisplayForView(object objVal)
    {
        if (objVal == null || objVal == DBNull.Value)
            return "Unknown";
        else
            return (Convert.ToBoolean(objVal) == false ? "No" : "Yes");

    }


    /// <summary>
    /// select radio button item as per value from DB
    /// </summary>
    /// <param name="objRdo"></param>
    /// <param name="objVal"></param>
    public static void FormatYesNoToDisplayForEdit(RadioButtonList objRdo, object objVal)
    {
        if (objVal == null || objVal == DBNull.Value)
            objRdo.SelectedIndex = -1;
        else
            objRdo.SelectedValue = Convert.ToInt32(objVal).ToString();
    }

    public static void FormatYesNoToDisplayForEdit(RadioButtonList objRdo, string objVal)
    {
        if (objVal == null || objVal == "")
            objRdo.ClearSelection();
        else
            objRdo.SelectedValue = objVal;
    }

    /// <summary>
    /// Combines two addresses
    /// </summary>
    /// <param name="objAddress1"></param>
    /// <param name="objAddress2"></param>
    /// <returns></returns>
    public static string FormatAddress(object objAddress1, object objAddress2, object objCity, object objState, object objZipcode)
    {
        string strAddress = string.Empty;
        if (!string.IsNullOrEmpty(Convert.ToString(objAddress1)))
            strAddress = objAddress1.ToString().Trim();
        if (!string.IsNullOrEmpty(Convert.ToString(objAddress2)))
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, ",&nbsp;", objAddress2.ToString().Trim()) : objAddress2.ToString().Trim();
        if (!string.IsNullOrEmpty(Convert.ToString(objCity)))
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, ",&nbsp;", objCity.ToString().Trim()) : objCity.ToString().Trim();
        if (!string.IsNullOrEmpty(Convert.ToString(objState)))
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, ",&nbsp;", objState.ToString().Trim()) : objState.ToString().Trim();
        if (!string.IsNullOrEmpty(Convert.ToString(objZipcode)))
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, "&nbsp;", objZipcode.ToString().Trim()) : objZipcode.ToString().Trim();


        return strAddress;
    }

    /// <summary>
    /// Combines first name and last name
    /// </summary>
    /// <param name="objFirstName"></param>
    /// <param name="objLastName"></param>
    /// <returns></returns>
    public static string FormatName(object objFirstName, object objLastName)
    {
        string strName = string.Empty;
        if (!string.IsNullOrEmpty(objFirstName.ToString().Trim()))
            strName = objFirstName.ToString().Trim();
        if (!string.IsNullOrEmpty(objLastName.ToString().Trim()))
            strName = (strName != string.Empty) ? string.Concat(strName, "&nbsp;", objLastName.ToString().Trim()) : objLastName.ToString().Trim();

        return strName;
    }


    /// <summary>
    /// Compress the String
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string CompressString(string strtext)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(strtext);
        MemoryStream ms = new MemoryStream();

        using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
        {
            zip.Write(buffer, 0, buffer.Length);
        }

        ms.Position = 0;
        MemoryStream outStream = new MemoryStream();

        byte[] compressed = new byte[ms.Length];
        ms.Read(compressed, 0, compressed.Length);

        byte[] gzBuffer = new byte[compressed.Length + 4];
        System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
        System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
        return Convert.ToBase64String(gzBuffer);
    }

    // Decompress the String
    public static string DecompressString(string compressedText)
    {
        byte[] gzBuffer = Convert.FromBase64String(compressedText);
        using (MemoryStream ms = new MemoryStream())
        {
            int msgLength = BitConverter.ToInt32(gzBuffer, 0);
            ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

            byte[] buffer = new byte[msgLength];

            ms.Position = 0;
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
            {
                zip.Read(buffer, 0, buffer.Length);
            }

            return Encoding.UTF8.GetString(buffer);
        }
    }

    /// <summary>
    /// Show Alert message from server side 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pg"></param>
    public static void ShowAlert(string message, System.Web.UI.Page pg)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("alert(\'");
        sb.Append(message.ToString());
        sb.Append("\')");
        ScriptManager.RegisterClientScriptBlock(pg, pg.GetType(), "ShowError", sb.ToString(), true);
    }

    #endregion

    # region " SEnd Emails "

    /// <summary>
    /// Sends an mail message using the SMTP server defined in web.config
    /// </summary>
    /// <param name="From">Sender address</param>
    /// <param name="To">Recepient address(Comma Seperated)</param>
    /// <param name="BCC">Bcc recepient(Comma Seperated)</param>
    /// <param name="CC">Cc recepient(Comma Seperated)</param>
    /// <param name="Subject">Subject of mail message</param>
    /// <param name="Body">Body of mail message</param>
    /// <param name="IsHTML">true to send email in html format</param>
    /// <returns>true if mail is sent successfully</returns>
    /// <remarks></remarks>        
    public static bool SendMailMessage(string strFrom, string strTo, string strBCC, string strCC, string strSubject, string strBody, bool boolIsHTML)
    {
        if (!AppConfig.AllowMailSending)
            return false;
        // Instantiate a new instance of MailMessage
        MailMessage mMailMessage = new MailMessage();

        if (!clsGeneral.IsNull(strFrom))
        {
            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(strFrom);
        }

        char[] arrSplitChar = { ',' };
        if (!clsGeneral.IsNull(strTo))
        {
            string[] arrTo = strTo.Split(arrSplitChar);
            foreach (string strTOID in arrTo)
            {
                // Set the recepient address of the mail message
                mMailMessage.To.Add(new MailAddress(strTOID));
            }
        }


        // Check if the bcc value is nothing or an empty string
        if (!clsGeneral.IsNull(strBCC))
        {
            string[] arrBCC = strTo.Split(arrSplitChar);
            foreach (string strBCCID in arrBCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(strBCCID));
            }
        }

        // Check if the cc value is nothing or an empty value
        if (!string.IsNullOrEmpty(strCC))
        {
            string[] arrCC = strCC.Split(arrSplitChar);
            foreach (string strCCID in arrCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.CC.Add(new MailAddress(strCCID));
            }
        }

        // Set the subject of the mail message
        mMailMessage.Subject = strSubject;
        // Set the body of the mail message
        mMailMessage.Body = strBody;

        // Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = boolIsHTML;
        // Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal;

        // Instantiate a new instance of SmtpClient
        SmtpClient mSmtpClient = new SmtpClient(AppConfig.SMTPServer, Convert.ToInt32(AppConfig.Port));

        mSmtpClient.Credentials = new NetworkCredential(strFrom, AppConfig.SMTPpwd);

        try
        {
            // Send the mail message
            mSmtpClient.Send(mMailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            //CommonHelper.DisposeOf(mMailMessage);
            //CommonHelper.DisposeOf(mSmtpClient);
        }

    }
    /// <summary>
    /// Used to Send EMail with Attachment
    /// </summary>
    /// <param name="strFrom"></param>
    /// <param name="strTo"></param>
    /// <param name="strBCC"></param>
    /// <param name="strCC"></param>
    /// <param name="strSubject"></param>
    /// <param name="strBody"></param>
    /// <param name="boolIsHTML"></param>
    /// <param name="strAttachments"></param>
    /// <returns></returns>
    public static bool SendMailMessage(string strFrom, string strTo, string strBCC, string strCC, string strSubject, string strBody, bool boolIsHTML, string[] strAttachments)
    {
        if (!AppConfig.AllowMailSending)
            return false;
        // Instantiate a new instance of MailMessage
        MailMessage mMailMessage = new MailMessage();

        if (!clsGeneral.IsNull(strFrom))
        {
            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(strFrom);
        }

        char[] arrSplitChar = { ',' };
        if (!clsGeneral.IsNull(strTo))
        {
            string[] arrTo = strTo.Split(arrSplitChar);
            foreach (string strTOID in arrTo)
            {
                // Set the recepient address of the mail message
                mMailMessage.To.Add(new MailAddress(strTOID));
            }
        }


        // Check if the bcc value is nothing or an empty string
        if (!clsGeneral.IsNull(strBCC))
        {
            string[] arrBCC = strBCC.Split(arrSplitChar);
            foreach (string strBCCID in arrBCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(strBCCID));
            }
        }

        // Check if the cc value is nothing or an empty value
        if (!string.IsNullOrEmpty(strCC))
        {
            string[] arrCC = strCC.Split(arrSplitChar);
            foreach (string strCCID in arrCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.CC.Add(new MailAddress(strCCID));
            }
        }
        foreach (string strAttachment in strAttachments)
        {
            if (File.Exists(strAttachment))
            {
                mMailMessage.Attachments.Add(new Attachment(strAttachment));
            }
        }

        
        // Set the subject of the mail message
        mMailMessage.Subject = strSubject;
        // Set the body of the mail message
        mMailMessage.Body = strBody;

        // Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = boolIsHTML;
        // Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal;

        // Instantiate a new instance of SmtpClient
        SmtpClient mSmtpClient = new SmtpClient(AppConfig.SMTPServer, Convert.ToInt32(AppConfig.Port));

        mSmtpClient.Credentials = new NetworkCredential(strFrom, AppConfig.SMTPpwd);

        try
        {
            // Send the mail message
            mSmtpClient.Send(mMailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            mMailMessage.Dispose();
            mMailMessage = null;
            mSmtpClient = null;
            //CommonHelper.DisposeOf(mMailMessage);
            //CommonHelper.DisposeOf(mSmtpClient);
        }


    }

    public static bool SendMailMessageForNewTicket(string strFrom, string strTo, string strBCC, string strCC, string strSubject, string strBody, bool boolIsHTML, string[] strAttachments, string PK_Facility_Construction_Maintenance_Item)
    {
        if (!AppConfig.AllowMailSending)
            return false;
        // Instantiate a new instance of MailMessage
        MailMessage mMailMessage = new MailMessage();

        if (!clsGeneral.IsNull(strFrom))
        {
            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(strFrom);
        }

        char[] arrSplitChar = { ',' };
        if (!clsGeneral.IsNull(strTo))
        {
            string[] arrTo = strTo.Split(arrSplitChar);
            foreach (string strTOID in arrTo)
            {
                // Set the recepient address of the mail message
                mMailMessage.To.Add(new MailAddress(strTOID));
            }
        }


        // Check if the bcc value is nothing or an empty string
        if (!clsGeneral.IsNull(strBCC))
        {
            string[] arrBCC = strBCC.Split(arrSplitChar);
            foreach (string strBCCID in arrBCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(strBCCID));
            }
        }

        // Check if the cc value is nothing or an empty value
        if (!string.IsNullOrEmpty(strCC))
        {
            string[] arrCC = strCC.Split(arrSplitChar);
            foreach (string strCCID in arrCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.CC.Add(new MailAddress(strCCID));
            }
        }
        foreach (string strAttachment in strAttachments)
        {
            if (File.Exists(strAttachment))
            {
                mMailMessage.Attachments.Add(new Attachment(strAttachment));
            }
        }


        // Set the subject of the mail message
        mMailMessage.Subject = strSubject;
        // Set the body of the mail message
        mMailMessage.Body = strBody;

        // Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = boolIsHTML;
        // Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal;

        mMailMessage.Headers.Add("Message-ID", PK_Facility_Construction_Maintenance_Item + "-" + Guid.NewGuid() + "@me.com ");
        // Instantiate a new instance of SmtpClient
        SmtpClient mSmtpClient = new SmtpClient(AppConfig.SMTPServer, Convert.ToInt32(AppConfig.Port));
        mSmtpClient.EnableSsl = true;
        mSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        mSmtpClient.Credentials = new NetworkCredential(strFrom, AppConfig.SMTPpwd);
        
        //mMailMessage.Headers.Add("Message-ID", PK_Facility_Construction_Maintenance_Item + "#-#" + Guid.NewGuid() + "@me.com ");
        //// Instantiate a new instance of SmtpClient
        //SmtpClient mSmtpClient = new SmtpClient(AppConfig.MaintenanceSMTPServer, Convert.ToInt32(AppConfig.MaintenanceSMTPPort));
        //mSmtpClient.EnableSsl = Convert.ToBoolean(AppConfig.MaintenanceSMTPEnableSsl);
        //mSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //mSmtpClient.Credentials = new NetworkCredential(strFrom, AppConfig.MaintenanceSMTPPswd);

        try
        {
            // Send the mail message
            mSmtpClient.Send(mMailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            mMailMessage.Dispose();
            mMailMessage = null;
            mSmtpClient = null;
            //CommonHelper.DisposeOf(mMailMessage);
            //CommonHelper.DisposeOf(mSmtpClient);
        }
    }
    /// <summary>
    /// Used to Send EMail with Attachment
    /// </summary>
    /// <param name="strFrom"></param>
    /// <param name="strTo"></param>
    /// <param name="strBCC"></param>
    /// <param name="strCC"></param>
    /// <param name="strSubject"></param>
    /// <param name="strBody"></param>
    /// <param name="boolIsHTML"></param>
    /// <param name="strAttachments"></param>
    /// <returns></returns>
    public static bool SendMailWithNewFileName(string strFrom, string strTo, string strBCC, string strCC, string strSubject, string strBody, bool boolIsHTML, string[] strAttachments,string[] strNewFileName)
    {
        if (!AppConfig.AllowMailSending)
            return false;
        // Instantiate a new instance of MailMessage
        MailMessage mMailMessage = new MailMessage();

        if (!clsGeneral.IsNull(strFrom))
        {
            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(strFrom);
        }

        char[] arrSplitChar = { ',' };
        if (!clsGeneral.IsNull(strTo))
        {
            string[] arrTo = strTo.Split(arrSplitChar);
            foreach (string strTOID in arrTo)
            {
                // Set the recepient address of the mail message
                mMailMessage.To.Add(new MailAddress(strTOID));
            }
        }


        // Check if the bcc value is nothing or an empty string
        if (!clsGeneral.IsNull(strBCC))
        {
            string[] arrBCC = strBCC.Split(arrSplitChar);
            foreach (string strBCCID in arrBCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(strBCCID));
            }
        }

        // Check if the cc value is nothing or an empty value
        if (!string.IsNullOrEmpty(strCC))
        {
            string[] arrCC = strCC.Split(arrSplitChar);
            foreach (string strCCID in arrCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.CC.Add(new MailAddress(strCCID));
            }
        }
        MemoryStream[] msArray = new MemoryStream[strAttachments.Length];
        foreach (string strAttachment in strAttachments)
        {

            int i = 0;
            if (File.Exists(strAttachment))
            {
                msArray[i] = new MemoryStream(File.ReadAllBytes(strAttachment));
                mMailMessage.Attachments.Add(new Attachment(msArray[i], strNewFileName[i]));
                i++;
            }
        }


        // Set the subject of the mail message
        mMailMessage.Subject = strSubject;
        // Set the body of the mail message
        mMailMessage.Body = strBody;

        // Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = boolIsHTML;
        // Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal;

        // Instantiate a new instance of SmtpClient
        SmtpClient mSmtpClient = new SmtpClient(AppConfig.SMTPServer, Convert.ToInt32(AppConfig.Port));

        mSmtpClient.Credentials = new NetworkCredential(strFrom, AppConfig.SMTPpwd);

        try
        {
            // Send the mail message
            mSmtpClient.Send(mMailMessage);
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
        finally
        {
            mMailMessage.Dispose();
            mMailMessage = null;
            mSmtpClient = null;
            //CommonHelper.DisposeOf(mMailMessage);
            //CommonHelper.DisposeOf(mSmtpClient);
            foreach (MemoryStream ms in msArray)
            {
                if (ms != null)
                    ms.Close();
            }
        }


    }

    # endregion

    #region "Export to Excel"
    /// <summary>
    /// Used to Export Data for Specified File Name
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="fileName"></param>
    public static void ExportData(DataTable dt, string fileName)
    {
        System.Text.StringBuilder sb = new StringBuilder();

        // include headers
        foreach (DataColumn td in dt.Columns)
            sb.AppendFormat("\"{0}\"{1}", td.ColumnName, "\t");

        // new line
        sb.AppendFormat("{0}", Environment.NewLine);

        // include data
        foreach (DataRow dr in dt.Rows)
        {
            foreach (DataColumn td in dt.Columns)
                sb.AppendFormat("\"{0}\"{1}", (dr[td.ColumnName] != DBNull.Value) ? dr[td.ColumnName].ToString() : string.Empty, "\t");

            sb.AppendFormat("{0}", Environment.NewLine);
        }

        HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + fileName + ".xls");
        HttpContext.Current.Response.ContentType = "Application/x-msexcel";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }

    public static void ExportDataSedgwick(DataTable dt, string fileName, string SedgwickOffice, string Year, string Quarter)
    {
        System.Text.StringBuilder sb = new StringBuilder();

        sb.Append("<table width=100><tr><td style='font-weight: bold;'>Sedgwick Field Office</td><td align=right>");
        sb.Append(SedgwickOffice);
        sb.Append("</td></tr><tr><td style='font-weight: bold;'>Year<td>");
        sb.Append(Year);
        sb.Append("</td></tr><tr><td style='font-weight: bold;'>Quarter<td>");
        sb.Append(Quarter);
        sb.Append("</td></tr><tr><td></td></tr><br style='mso-data-placement:same-cell;' /></table><table border='1'><tr>");


        //sb.Append("<table border='1'><tr>");
        // include headers

        foreach (DataColumn td in dt.Columns)
            sb.Append("<th>" + td.ColumnName + "</th>");
        sb.Append("</tr>");
        // new line
        //sb.AppendFormat("{0}", Environment.NewLine);

        // include data
        foreach (DataRow dr in dt.Rows)
        {
            sb.Append("<tr>");
            foreach (DataColumn td in dt.Columns)
            {
                if (td.DataType != typeof(DateTime))
                    sb.Append("<td>" + ((dr[td.ColumnName] != DBNull.Value) ? dr[td.ColumnName].ToString() : string.Empty) + "</td>");
                else
                    sb.Append("<td>" + ((dr[td.ColumnName] != DBNull.Value) ? clsGeneral.FormatDBNullDateToDisplay_Claim(dr[td.ColumnName].ToString()) : string.Empty) + "</td>");
            }
            sb.Append("</tr>");
            //sb.AppendFormat("{0}", Environment.NewLine);
        }
        sb.Append("</table>");
        HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + fileName + ".xls");
        HttpContext.Current.Response.ContentType = "Application/x-msexcel";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }

    #endregion
    /// <summary>
    /// Used to Compare two dates. as  per their Mode
    /// </summary>
    /// <param name="strStart"></param>
    /// <param name="strEnd"></param>
    /// <param name="Mode"></param>
    /// <returns></returns>
    public static string CompareDate(string strStart, string strEnd, string Mode)
    {
        DateTime dtStart = clsGeneral.FormatDateToStore(strStart);
        DateTime dtEnd = clsGeneral.FormatDateToStore(strEnd);
        TimeSpan t = dtEnd - dtStart;

        double diff = -1;
        switch (Mode)
        {
            case "year":
                {
                    double StartMonths = (dtStart.Year - 1) * 12 + dtStart.Month;
                    double EndMonths = (dtEnd.Year - 1) * 12 + dtEnd.Month;
                    diff = Math.Round((EndMonths - StartMonths) / 12 - 0.5);
                }
                break;
            case "month":
                {
                    double StartMonths = (dtStart.Year - 1) * 12 + dtStart.Month;
                    double EndMonths = (dtEnd.Year - 1) * 12 + dtEnd.Month;
                    diff = EndMonths - StartMonths;
                }
                break;
            case "day":
                {
                    diff = t.Days;
                }
                break;
            case "hour":
                {
                    diff = t.Hours;
                }
                break;
            case "minute":
                {
                    diff = t.Minutes;
                }
                break;
            default:
                return "INVALID";
                break;
        }
        return diff.ToString();
    }
    /// <summary>
    /// used to Read the Text File. used to send the Email while related Email Template is Read.
    /// </summary>
    /// <param name="strFilePath"></param>
    /// <returns></returns>
    public static string ReadTextFile(string strFilePath)
    {
        string EntireFile;
        System.IO.StreamReader oRead = null;

        try
        {
            oRead = System.IO.File.OpenText(strFilePath);
            EntireFile = oRead.ReadToEnd();
        }
        catch (Exception ex)
        {
            EntireFile = "";
        }
        finally
        {
            DisposeOf(oRead);
        }
        return EntireFile;
    }
    /// <summary>
    /// Used to Dispose the object manually.
    /// </summary>
    /// <param name="object"></param>
    public static void DisposeOf(object @object)
    {
        if ((@object != null))
        {
            if (@object is IDisposable)
            {
                ((IDisposable)@object).Dispose();
            }

            @object = null;
        }
    }

    #region Check Password Strength(Must have one character,one digit,one special character like ~`!@#$%^&*_+-=,and Password length must be greater or equal to 7)
    /// <summary>
    /// used to check Passwrd strength.
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public static bool CheckPassword(string password)
    {
        if (password == null || password.Length < 7)
        {
            return false;
        }
        bool hasLetter = false;
        bool hasDigit = false;
        bool hasOther = false;
        foreach (char c in password)
        {
            // check Letter.
            if (hasLetter == false)
            {
                if (Char.IsLetter(c))
                {
                    hasLetter = true;
                }
            }
            // Check Digit
            if (hasDigit == false)
            {
                if (Char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }
            // Check Special Characters like ~`!@#$%^&*_+-=
            if (hasOther == false)
            {
                if (c == 42 || c == 45 || c == 33 || c == 35 || c == 36 || c == 37 || c == 38 || c == 43 || c == 64 || c == 61 || c == 96 || c == 126 || c == 94 || c == 96)
                {
                    hasOther = true;
                }
            }
        }
        if (hasLetter == false)
        {
            return false;
        }
        else if (hasDigit == false)
        {
            return false;
        }
        else if (hasOther == false)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    #endregion

    /// <summary>
    /// Sets the dates for the labels which are not mendatory fields,
    /// it may have Minvalue (01/01/1975) which should return an empty string
    /// </summary>
    /// <param name="objDT"></param>
    /// <returns></returns>
    public static string FormatDate(DateTime objDT)
    {
        if (!(objDT <= (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue))
            return objDT.ToString(AppConfig.DisplayDateFormat);
        else
            return string.Empty;
    }

    ///<summery>
    ///to SendMail function is called in which all paramters are set
    ///</summery>
    public static void SendMail(string mailfrom, string mailto, string mailcc, string mailbcc, string subject, string body, string[] strFilePath)
    {
        if (!AppConfig.AllowMailSending)
            return;
        System.Net.Mail.MailMessage objMailMesg = new System.Net.Mail.MailMessage(mailfrom, mailto);
        //OrderDetails objOrderDtl = clsSession.CurrentOrderDetails;
        foreach (string strAttachment in strFilePath)
        {
            if (File.Exists(strAttachment))
            {
                System.Net.Mail.Attachment MailAttachment = new System.Net.Mail.Attachment(strAttachment);
                if (MailAttachment != null)
                {

                    objMailMesg.Attachments.Add(MailAttachment);
                }
            }
        }
        //if (strFilePath.Length != 0)
        //{
        //    System.Net.Mail.Attachment MailAttachment = new System.Net.Mail.Attachment(strFilePath);
        //    if (MailAttachment != null)
        //    {

        //        objMailMesg.Attachments.Add(MailAttachment);
        //    }
        //}
        if (mailcc != "")
            objMailMesg.CC.Add(mailcc);
        if (mailbcc != "")
            objMailMesg.Bcc.Add(mailbcc);

        objMailMesg.Subject = subject;
        objMailMesg.Body = body;
        objMailMesg.IsBodyHtml = true;
        System.Net.Mail.SmtpClient objSMTP = new System.Net.Mail.SmtpClient();
        objSMTP.Host = AppConfig.SMTPServer;
        objSMTP.Port = 587;
        objSMTP.Send(objMailMesg);
    }

    /// <summary>
    /// Add Hoc Report Send Emails
    /// </summary>
    /// <param name="Subject"></param>
    /// <param name="FilePath"></param>
    /// <param name="FileName"></param>
    /// <param name="dcRecipientList"></param>
    /// <returns></returns>
    public static bool SendAdHocReport(string Subject, string FilePath, string FileName, decimal dcRecipientList)
    {
        bool isSuccess = true;
        DataTable dtRecipients = ERIMS.DAL.Tatva_RecipientListMatrix.SelectOneRecordWithRecipientList(Convert.ToDecimal(dcRecipientList)).Tables[0];

        ERIMS.DAL.Security objSecurity = new ERIMS.DAL.Security(Convert.ToInt32(clsSession.UserID));
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(objSecurity.Email);
        mail.Subject = "eRIMS Sonic :: " + Subject;

        if (File.Exists(FilePath))
            mail.Attachments.Add(new System.Net.Mail.Attachment(File.OpenRead(FilePath), string.IsNullOrEmpty(FileName) ? Path.GetFileName(FilePath) : FileName));

        SmtpClient mSmtpClient = new SmtpClient();
        mSmtpClient.Host = ConfigurationManager.AppSettings["SMTPServer"].ToString();
        mSmtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPmail"], ConfigurationManager.AppSettings["SMTPPwd"]);
        try
        {
            if (dtRecipients.Rows.Count > 0)
            {

                for (int i = 0; i < dtRecipients.Rows.Count; i++)
                {
                    mail.Body = dtRecipients.Rows[i]["FirstName"].ToString() + " " + dtRecipients.Rows[i]["LastName"].ToString() + ",<br /><br />Please find the " + Subject + " Attached with this mail.<br /><br />Thankyou!<br />" + clsSession.FirstName + " " + clsSession.LastName;
                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(dtRecipients.Rows[i]["Email"].ToString()));
                    mSmtpClient.Send(mail);
                    mail.To.Clear();
                }

            }
            else
                isSuccess = false;
        }
        catch (Exception)
        {
            isSuccess = false;
        }
        finally
        {
            mail.Dispose();
            if (File.Exists(FilePath))
                File.Delete(FilePath);
        }
        return isSuccess;
    }

    /// <summary>
    /// used to supress string. like return 123456 to 123***
    /// </summary>
    /// <param name="strText"></param>
    /// <param name="intStartPoint"></param>
    /// <returns></returns>
    public static string SupressString(string strText, int intStartPoint)
    {
        string rtnString = "";
        for (int inti = 0; inti < strText.Length; inti++)
        {
            if (inti >= intStartPoint)
            {
                //rtnString += "*";
                rtnString += strText[inti].ToString();
            }
            else
            {
                rtnString += "*";
                //rtnString += strText[inti].ToString();
            }
        }
        return rtnString;
    }

    /// <summary>
    /// set default value for datarow column based on type
    /// </summary>
    /// <param name="dr"></param>
    public static void SetDefaultValuesForDBNull(DataRow dr)
    {
        foreach (DataColumn col in dr.Table.Columns)
        {
            if (Convert.IsDBNull(dr[col]))
            {
                switch (col.DataType.ToString())
                {
                    case "System.Int32":
                    case "System.Decimal":
                    case "System.Double":
                        dr[col] = 0;
                        break;
                    // break 
                    case "System.String":
                        dr[col] = string.Empty;
                        break;
                    case "System.DateTime":
                        dr[col] = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                        break;
                    default:
                        break;
                    // break 
                }
            }
        }
    }

    /// <summary>
    /// set ToolTip for Dropdown
    /// </summary>
    /// <param name="drps"></param>    
    public static void SetDropDownToolTip(ListBox[] drps)
    {
        for (int i = 0; i < drps.Length; i++)
        {
            foreach (ListItem li in drps[i].Items)
                li.Attributes.Add("title", li.Text);
        }
    }

    public static void SetDropDownToolTip(DropDownList[] drps)
    {
        for (int i = 0; i < drps.Length; i++)
        {
            foreach (ListItem li in drps[i].Items)
                li.Attributes.Add("title", li.Text);
        }
    }

    /// <summary>
    /// Selects by table name(General).
    /// </summary>
    /// <returns>DataSet</returns>
    public static DataSet SelectByTableName(string tableName)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand(tableName + "SelectAll");

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// set ToolTip for Dropdown
    /// </summary>
    /// <param name="drps"></param>
    public static void SetListBoxToolTip(ListBox[] lsts)
    {
        for (int i = 0; i < lsts.Length; i++)
        {
            foreach (ListItem li in lsts[i].Items)
                li.Attributes.Add("title", li.Text);
        }
    }

    /// <summary>
    /// Sets the selected item by value or text for dropdown
    /// </summary>
    /// <param name="drpDwn"></param>
    /// <param name="objVal"></param>
    /// <param name="FindByValue"></param>
    public static void SetDropdownValue(DropDownList drpDwn, object objVal, bool FindByValue)
    {
        drpDwn.ClearSelection();
        if (!string.IsNullOrEmpty(Convert.ToString(objVal)))
        {
            ListItem lst = null;
            if (FindByValue)
                lst = drpDwn.Items.FindByValue(objVal.ToString());
            else
                lst = drpDwn.Items.FindByText(objVal.ToString());

            if (lst != null)
                lst.Selected = true;
        }
    }

    public static decimal GetMailContentLength(string strContent)
    {
        int intSize = System.Text.Encoding.UTF8.GetByteCount(strContent);

        return (intSize / 1048576.00M);
    }

    public static decimal GetMailAttachmentSize(string[] strAttachmentPath)
    {
        long _FileSize = 0;
        foreach (string strFile in strAttachmentPath)
        {
            try
            {
                FileInfo fiFile = new FileInfo(strFile);
                _FileSize += fiFile.Length;
            }
            catch
            {
                _FileSize = 0;
            }
        }
        return (_FileSize / 1048576.00M);
    }

    /// <summary>
    /// Combines two addresses
    /// </summary>
    /// <param name="objAddress1"></param>
    /// <param name="objAddress2"></param>
    /// <returns></returns>
    public static string FormatBuildingAddress(object objAddress1, object objAddress2, object objCity, object objState, object objZipcode)
    {
        string strAddress = string.Empty;
        if (!string.IsNullOrEmpty(Convert.ToString(objAddress1)))
            strAddress = objAddress1.ToString().Trim();
        if (!string.IsNullOrEmpty(Convert.ToString(objAddress2)))
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, "<br/>", objAddress2.ToString().Trim()) : objAddress2.ToString().Trim();
        if (!string.IsNullOrEmpty(Convert.ToString(objCity)))
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, "<br/>", objCity.ToString().Trim()) : objCity.ToString().Trim();
        else
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, "<br/>") : "";
        if (!string.IsNullOrEmpty(Convert.ToString(objState)))
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, ",&nbsp;", objState.ToString().Trim()) : objState.ToString().Trim();
        if (!string.IsNullOrEmpty(Convert.ToString(objZipcode)))
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, "&nbsp;", objZipcode.ToString().Trim()) : objZipcode.ToString().Trim();


        return strAddress;
    }
    /// <summary>
    /// Generate word doc
    /// </summary>
    /// <param name="strFileName"></param>
    /// <param name="strText"></param>
    /// <param name="Response"></param>
    public static void GenerateWordDoc(string strFileName, string strText, HttpResponse Response)
    {
        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        Aspose.Words.Document doc = new Aspose.Words.Document();

        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
        //builder.Font.Size = 12;
        //builder.Font.Bold = false;
        //builder.Font.Color = System.Drawing.Color.Black;
        builder.PageSetup.PaperSize = PaperSize.Letter;
        builder.PageSetup.BottomMargin = 40;
        builder.PageSetup.TopMargin = 40;
        builder.PageSetup.LeftMargin = 40;
        builder.PageSetup.RightMargin = 40;
        //builder.Font.Name = "Arial";
        builder.InsertParagraph();
        builder.InsertHtml(strText.Trim());

        //builder.Write(litLetter.Text);
        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;
        //NodeCollection nc = doc.GetChildNodes(NodeType.Table, true);
        //foreach (Aspose.Words.Tables.Table tab in nc)
        //{
        //    string s= tab.GetText();
        //    Aspose.Words.Tables.RowCollection rc = tab.Rows;

        //    foreach (Aspose.Words.Tables.Row r in rc)
        //    {
        //        Aspose.Words.Tables.CellCollection cc = r.Cells;

        //        foreach (Aspose.Words.Tables.Cell c in cc)
        //        {
        //            c.CellFormat.FitText = false;
        //            c.CellFormat.WrapText = true;

        //        }
        //    }
        //    //tab.AutoFit(Aspose.Words.Tables.AutoFitBehavior.FixedColumnWidths);
        //}
        doc.MailMerge.DeleteFields();
        //doc.Save(strFileName, Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        doc.Save(Response, strFileName, ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        Response.End();
        ///////////
    }
    public static string SaveFile(string strFileText, string strPath, string strFileName)
    {
        string strRetVal = "";
        // set path.
        if (!strPath.EndsWith("\\"))
        {
            strPath = string.Concat(strPath, "\\");
        }
        if (strPath.Contains("/"))
            strPath = strPath.Replace('/', '\\');

        // create dir if doesnt' exists
        CreateDirectory(strPath);

        // now check for file name exists or not. and option for overwrite
        string strFulleName = string.Concat(strPath, strFileName);

        // if overwrite is not allowed then get filename to save.
        strFulleName = GetFileNameToSave(strFulleName);

        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        Aspose.Words.Document doc = new Aspose.Words.Document();

        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
        //builder.Font.Size = 12;
        //builder.Font.Bold = false;
        //builder.Font.Color = System.Drawing.Color.Black;
        builder.PageSetup.PaperSize = PaperSize.Letter;
        builder.PageSetup.BottomMargin = 40;
        builder.PageSetup.TopMargin = 40;
        builder.PageSetup.LeftMargin = 40;
        builder.PageSetup.RightMargin = 40;
        //builder.Font.Name = "Arial";
        builder.InsertParagraph();
        builder.InsertHtml(strFileText);
        //builder.Write(litLetter.Text);

        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;

        doc.MailMerge.DeleteFields();
        doc.Save(strFulleName, Aspose.Words.SaveFormat.Doc);

        // set return value = only filename.
        strRetVal = GetFileName(strFulleName);

        return strRetVal;
    }

    public static string SaveJobRequestForm(string strFileText, string strPath, string strFileName)
    {
        string strRetVal = "";
        // set path.
        if (!strPath.EndsWith("\\"))
        {
            strPath = string.Concat(strPath, "\\");
        }
        if (strPath.Contains("/"))
            strPath = strPath.Replace('/', '\\');

        // create dir if doesnt' exists
        CreateDirectory(strPath);

        // now check for file name exists or not. and option for overwrite
        string strFulleName = string.Concat(strPath, strFileName);

        // if overwrite is not allowed then get filename to save.
        strFulleName = GetFileNameToSave(strFulleName);

        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        Aspose.Words.Document doc = new Aspose.Words.Document();

        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
        //builder.Font.Size = 12;
        //builder.Font.Bold = false;
        //builder.Font.Color = System.Drawing.Color.Black;
        builder.PageSetup.PaperSize = PaperSize.Letter;
        builder.PageSetup.BottomMargin = 40;
        builder.PageSetup.TopMargin = 40;
        builder.PageSetup.LeftMargin = 40;
        builder.PageSetup.RightMargin = 40;
        //builder.Font.Name = "Arial";
        builder.InsertParagraph();
        builder.InsertHtml(strFileText);
        builder.MoveToSection(0);
        builder.MoveToHeaderFooter(HeaderFooterType.FooterPrimary);
        builder.PageSetup.PageNumberStyle = NumberStyle.Number;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.Write("Page ");
        builder.InsertField("PAGE", "");
        builder.Write(" of ");
        builder.InsertField("NUMPAGES", "");
        Section section = doc.Sections[0];
        section.PageSetup.PageStartingNumber = 1;
        section.PageSetup.RestartPageNumbering = true;
        section.PageSetup.PageNumberStyle = NumberStyle.Arabic;
        //builder.Write(litLetter.Text);

        doc.MailMerge.DeleteFields();
        doc.Save(strFulleName, Aspose.Words.SaveFormat.Doc);

        // set return value = only filename.
        strRetVal = GetFileName(strFulleName);

        return strRetVal;
    }

    public static int GetQuarterFromDate(DateTime? objdt)
    {
        if (objdt == null)
            return 1;
        else
        {
            int intQuarter = 0;
            DateTime dt = Convert.ToDateTime(objdt);
            int intMonth = dt.Month;
            if (intMonth >= 1 && intMonth <= 3) return 1;
            else if (intMonth >= 4 && intMonth <= 6) return 2;
            else if (intMonth >= 7 && intMonth <= 9) return 3;
            else if (intMonth >= 10) return 4;
            return intQuarter;
        }
    }

    public static string SaveFilePDF(string strFileText, string strPath, string strFileName)
    {
        string strRetVal = "";
        // set path.
        if (!strPath.EndsWith("\\"))
        {
            strPath = string.Concat(strPath, "\\");
        }
        if (strPath.Contains("/"))
            strPath = strPath.Replace('/', '\\');

        // create dir if doesnt' exists
        CreateDirectory(strPath);

        // now check for file name exists or not. and option for overwrite
        string strFulleName = string.Concat(strPath, strFileName);

        // if overwrite is not allowed then get filename to save.
        strFulleName = GetFileNameToSave(strFulleName);

        PdfConverter objPdf = new PdfConverter();
        objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;

        objPdf.PdfDocumentOptions.TopMargin = 5;
        objPdf.PdfDocumentOptions.LeftMargin = 10;
        objPdf.PdfDocumentOptions.RightMargin = 10;
        objPdf.PdfDocumentOptions.BottomMargin = 1;
        objPdf.PdfDocumentOptions.ShowHeader = false;
        objPdf.PdfDocumentOptions.EmbedFonts = false;
        //if (strFileName == "Invoice.pdf" || strFileName == "Hold Notice JacintoPort.pdf")
        //{
        //    objPdf.PdfDocumentOptions.ShowFooter = false;
        //}
        //else
        //{
        //    objPdf.PdfDocumentOptions.ShowFooter = true;
        //    System.Drawing.Image logoImg = System.Drawing.Image.FromFile(AppConfig.SitePath + "Images/letter-footer-pdf.JPG");
        //    objPdf.PdfFooterOptions.FooterImage = logoImg;
        //    objPdf.PdfFooterOptions.FooterTextYLocation = 100;
        //}
        objPdf.PdfDocumentOptions.LiveUrlsEnabled = true;
        objPdf.RightToLeftEnabled = false;
        objPdf.PdfSecurityOptions.CanPrint = true;
        objPdf.PdfSecurityOptions.CanEditContent = true;
        objPdf.PdfSecurityOptions.UserPassword = "";
        objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;
        objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;

        //objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Custom;
        //objPdf.PdfDocumentOptions.CustomPdfPageSize = new System.Drawing.SizeF(10f, 10f);

        StringBuilder sbHtml = new StringBuilder();
        sbHtml.Append(strFileText);

        objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";
        //Byte[] pdfByte = null;
        //pdfByte = objPdf.GetPdfBytesFromHtmlString(sbHtml.ToString());

        objPdf.SavePdfFromHtmlStringToFile(strFileText, strFulleName);

        // set return value = only filename.
        strRetVal = GetFileName(strFulleName);

        return strRetVal;
    }

    public static void SendMail(string mailfrom, string mailto, string mailcc, string mailbcc, string subject, string body, string strFilePath)
    {
        if (!AppConfig.AllowMailSending)
            return;
        System.Net.Mail.MailMessage objMailMesg = new System.Net.Mail.MailMessage(mailfrom, mailto);

        if (mailcc != "")
            objMailMesg.CC.Add(mailcc);
        if (mailbcc != "")
            objMailMesg.Bcc.Add(mailbcc);

        objMailMesg.Subject = subject;
        objMailMesg.Body = body;
        objMailMesg.IsBodyHtml = true;

        System.Net.Mail.SmtpClient objSMTP = new System.Net.Mail.SmtpClient();
        objSMTP.Host = AppConfig.SMTPServer;
        objSMTP.Port = Convert.ToInt32(AppConfig.Port);
        objSMTP.Send(objMailMesg);
    }

    /// <summary>
    /// Get General cml file for Excel file
    /// which contains style related data
    /// </summary>
    /// <returns></returns>
    public static string GetGeneralXmlForExcel()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<?xml version=\"1.0\"?>\r\n<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n");
        sb.Append(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n	xmlns:x=\"urn:schemas- microsoft-com:office:excel\"\r\n	xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">\r\n");
        sb.Append("<Styles>\r\n <Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>");
        sb.Append("\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>\r\n<Protection/>\r\n </Style>\r\n");

        sb.Append("<Style ss:ID=\"BoldColumn\">\r\n");
        sb.Append("<Borders>");
        sb.Append("<Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/></Borders>");
        sb.Append("<Font x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n");

        sb.Append("<Style ss:ID=\"NumberBoldColumn\">\r\n");
        sb.Append("<Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Top\" ss:WrapText=\"1\"/>\r\n");
        sb.Append("<Borders>");
        sb.Append("<Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/></Borders>");
        sb.Append("<Font x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n");

        sb.Append("<Style ss:ID=\"s61\">\r\n");
        sb.Append("<Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Top\" ss:WrapText=\"1\"/>\r\n");
        sb.Append("<Borders>");
        sb.Append("<Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/></Borders>");
        sb.Append("<Font x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n");

        sb.Append("<Style ss:ID=\"s62\">\r\n ");
        sb.Append("<Borders>");
        sb.Append("<Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/></Borders>");
        sb.Append("<NumberFormat ss:Format=\"@\"/>\r\n</Style>\r\n");

        sb.Append("<Style ss:ID=\"s63\">\r\n ");
        sb.Append("<Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Top\" ss:WrapText=\"1\"/>\r\n");
        sb.Append("<Borders>");
        sb.Append("<Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/>");
        sb.Append("<Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#000000\"/></Borders>");
        sb.Append("<NumberFormat ss:Format=\"@\"/>\r\n</Style>\r\n");

        sb.Append("<Style ss:ID=\"Decimal\">\r\n<NumberFormat ss:Format=\"0.0000\"/>\r\n </Style>\r\n");
        sb.Append("<Style ss:ID=\"Integer\">\r\n<NumberFormat ss:Format=\"0\"/>\r\n </Style>\r\n");
        sb.Append("<Style ss:ID=\"DateLiteral\">\r\n<NumberFormat ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n");

        sb.Append("<Style ss:ID=\"s28\">\r\n");
        sb.Append("<Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Top\" ss:ReadingOrder=\"LeftToRight\" ss:WrapText=\"1\"/>\r\n");
        sb.Append("<Font x:CharSet=\"1\" ss:Size=\"9\" ss:Color=\"#808080\" ss:Underline=\"Single\"/>\r\n");
        sb.Append("<Interior ss:Color=\"#FFFFFF\" ss:Pattern=\"Solid\"/></Style>\r\n</Styles>\r\n {0}</Workbook>");

        return sb.ToString();
    }

    /// <summary>
    /// Set Column width
    /// </summary>
    /// <param name="gv">GridView</param>
    /// <param name="width">Widht of column to be set</param>
    /// <returns></returns>
    public static string GetColumnWidth(GridView gv, int width)
    {
        if (!(width > 0))
            width = 120;

        StringBuilder sb = new StringBuilder();

        if (gv.HeaderRow != null && gv.HeaderRow.Cells.Count > 0)
        {
            for (int i = 0; i <= gv.HeaderRow.Cells.Count - 1; i++)
            {
                sb.Append("<Column ss:Width=\"" + width.ToString() + "\"/>");
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Set Column width
    /// </summary>
    /// <param name="dt">Datatable</param>
    /// <param name="width">Widht of column to be set</param>
    /// <returns></returns>
    public static string GetColumnWidth(DataTable dt, int width)
    {
        if (!(width > 0))
            width = 120;

        StringBuilder sb = new StringBuilder();

        if (dt != null && dt.Columns.Count > 0)
        {
            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                sb.Append("<Column ss:Width=\"" + width.ToString() + "\"/>");
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Format Number with specified floating point
    /// </summary>
    /// <param name="obj">Object to format</param>
    /// <param name="Floatingpoint">indicates how many floating point you needed in your output</param>
    /// <returns></returns>
    public static string FormatNumber(object obj, int Floatingpoint)
    {
        if (obj == null)
        {
            obj = 0;
        }
        return string.Format("{0, 0:N" + Floatingpoint + "}", obj);
    }

    public enum CertificateType
    {
        [Description("Certificate of Liability Insurance")]
        Certificate_of_Liability_Insurance = 1,
        [Description("Evidence of Commercial Property Insurance")]
        Evidence_of_Commercial_Property_Insurance = 2
    }

    public enum CertificateOfLiabInsurAdditionalID
    {
        [Description("Sonic Automotive")]
        Sonic_Automotive = 1,
        [Description("Master Landlord")]
        Master_Landlord = 2,
        [Description("Mortgagee")]
        Mortgagee = 3
    }

    public enum EviOfCommPropAdditionalID
    {
        [Description("Mortgagee")]
        Mortgagee = 1,
        [Description("Lenders Loss Payee")]
        Lenders_Loss_Payee = 2,
        [Description("Contract of Sale")]
        Contract_of_Sale = 3,
        [Description("Master Landlord of Location")]
        Master_Landlord_of_Location = 4
    }


    /// <summary>
    /// return string in HTML format if it is null then it return  string.empty value
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ReplaceSpaceAndNewLine(string strText)
    {
        if (!string.IsNullOrEmpty(strText))
        {
            return strText.Replace(" ", "&nbsp;").Replace(Environment.NewLine, "<br />");
        }
        else
        {
            return string.Empty;
        }
    }

    public static void GenerateWordFromFileAndReplaceText(string inputFileName, string strFileName, Hashtable htKeyValue, HttpResponse Response)
    {
        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        LoadOptions fileOptions = new LoadOptions();
        fileOptions.LoadFormat = LoadFormat.Html;
        Aspose.Words.Document doc = new Aspose.Words.Document(inputFileName, fileOptions);
        foreach (Section sec in doc.Sections)
        {
            sec.PageSetup.PaperSize = PaperSize.Letter;
            sec.PageSetup.BottomMargin = 30;
            sec.PageSetup.TopMargin = 30;
            sec.PageSetup.LeftMargin = 40;
            sec.PageSetup.RightMargin = 40;
        }
        foreach (DictionaryEntry entry in htKeyValue)
        {
            if (entry.Value != null)
            {
                if (entry.Value.ToString().StartsWith("<img"))
                {
                    SearchAndReplaceImage imgCls = new SearchAndReplaceImage();
                    WebClient client = new WebClient();
                    string matchString = Regex.Match(entry.Value.ToString(), "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value;
                    imgCls.setImage(client.DownloadData(matchString));
                    doc.Range.Replace(new Regex(Regex.Escape(entry.Key.ToString())), imgCls, true);
                }
                else if (entry.Value.ToString().StartsWith("<table"))
                {
                    SearchAndReplaceTable tblCls = new SearchAndReplaceTable();
                    tblCls.setHTML(entry.Value.ToString());
                    doc.Range.Replace(new Regex(Regex.Escape(entry.Key.ToString())), tblCls, false);
                }
                else
                    doc.Range.Replace(entry.Key.ToString(), entry.Value.ToString().Replace("\r\n", ControlChar.LineBreak), false, false);
            }
            else
                doc.Range.Replace(entry.Key.ToString(), string.Empty, false, false);
        }
        //Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        //if (table != null)
        //    table.AllowAutoFit = false;
        removePageBreaks(ref doc);
        doc.MailMerge.DeleteFields();
        //doc.Save(@"D:\Share\1.doc", Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        doc.Save(Response, strFileName, ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        //Response.End();
    }

    public static string GenerateWordFromFileAndReplaceText(string inputFileName, string strPath, string strFileName, Hashtable htKeyValue)
    {
        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        LoadOptions fileOptions = new LoadOptions();
        fileOptions.LoadFormat = LoadFormat.Html;
        Aspose.Words.Document doc = new Aspose.Words.Document(inputFileName, fileOptions);
        foreach (Section sec in doc.Sections)
        {
            sec.PageSetup.PaperSize = PaperSize.Letter;
            sec.PageSetup.BottomMargin = 30;
            sec.PageSetup.TopMargin = 30;
            sec.PageSetup.LeftMargin = 40;
            sec.PageSetup.RightMargin = 40;
        }
        foreach (DictionaryEntry entry in htKeyValue)
        {
            if (entry.Value != null)
            {
                if (entry.Value.ToString().StartsWith("<img"))
                {
                    SearchAndReplaceImage imgCls = new SearchAndReplaceImage();
                    WebClient client = new WebClient();
                    string matchString = Regex.Match(entry.Value.ToString(), "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value;
                    imgCls.setImage(client.DownloadData(matchString));
                    doc.Range.Replace(new Regex(Regex.Escape(entry.Key.ToString())), imgCls, true);
                }
                else if (entry.Value.ToString().StartsWith("<table"))
                {
                    SearchAndReplaceTable tblCls = new SearchAndReplaceTable();
                    tblCls.setHTML(entry.Value.ToString());
                    doc.Range.Replace(new Regex(Regex.Escape(entry.Key.ToString())), tblCls, false);
                }
                else
                    doc.Range.Replace(entry.Key.ToString(), entry.Value.ToString().Replace("\r\n", ControlChar.LineBreak), false, false);
            }
            else
                doc.Range.Replace(entry.Key.ToString(), string.Empty, false, false);
        }
        //Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        //if (table != null)
        //    table.AllowAutoFit = false;
        removePageBreaks(ref doc);
        doc.MailMerge.DeleteFields();
        //doc.Save(@"D:\Share\1.doc", Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));

        // set path.
        if (!strPath.EndsWith("\\"))
        {
            strPath = string.Concat(strPath, "\\");
        }
        if (strPath.Contains("/"))
            strPath = strPath.Replace('/', '\\');

        // create dir if doesnt' exists
        CreateDirectory(strPath);

        // now check for file name exists or not. and option for overwrite
        string strFulleName = string.Concat(strPath, strFileName);

        // if overwrite is not allowed then get filename to save.
        strFulleName = GetFileNameToSave(strFulleName);

        doc.Save(strFulleName, Aspose.Words.SaveFormat.Doc);

        return strFulleName;
    }
    private static void removePageBreaks(ref Document doc)
    {

        // Retrieve all paragraphs in the document.

        NodeCollection paragraphs = doc.GetChildNodes(NodeType.Paragraph, true);

        // Iterate through all paragraphs

        foreach (Paragraph para in paragraphs)
        {
            // If the paragraph has a page break before set then clear it.
            if (para.ParagraphFormat.PageBreakBefore)
                para.ParagraphFormat.PageBreakBefore = false;
            // Check all runs in the paragraph for page breaks and remove them.
            foreach (Run run in para.Runs)
            {
                if (run.Text.Contains(ControlChar.PageBreak))
                    run.Text = run.Text.Replace(ControlChar.PageBreak, "");
            }
        }



    }
    private class SearchAndReplaceImage : IReplacingCallback
    {
        byte[] image;
        public void setImage(byte[] imgData)
        {
            image = imgData;
        }
        public ReplaceAction Replacing(ReplacingArgs e)
        {
            Document doc = (Document)e.MatchNode.Document;
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.MoveTo(e.MatchNode);
            builder.InsertImage(image);
            return ReplaceAction.Replace;
        }
    }
    private class SearchAndReplaceTable : IReplacingCallback
    {
        string htmlData = string.Empty;
        public void setHTML(string stringhtml)
        {
            htmlData = stringhtml;
        }
        public ReplaceAction Replacing(ReplacingArgs e)
        {
            Document doc = (Document)e.MatchNode.Document;
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.MoveTo(e.MatchNode);
            builder.InsertHtml(htmlData);
            return ReplaceAction.Replace;
        }
    }
    public static string Encode_Url(string StrFilename)
    {
        string Result;

        Result = StrFilename;
        Result = Result.Replace("%", "%25");
        Result = Result.Replace("<", "%3C");
        Result = Result.Replace(">", "%3E");
        Result = Result.Replace("#", "%23");
        Result = Result.Replace("{", "%7B");
        Result = Result.Replace("}", "%7D");
        Result = Result.Replace("|", "%7C");
        //Result = Result.Replace("\\","%5C") ;     
        Result = Result.Replace("^", "%5E");
        Result = Result.Replace("~", "%7E");
        Result = Result.Replace("[", "%5B");
        Result = Result.Replace("]", "%5D");
        Result = Result.Replace("`", "%60");
        Result = Result.Replace(";", "%3B");
        Result = Result.Replace("/", "%2F");
        Result = Result.Replace("?", "%3F");
        Result = Result.Replace(":", "%3A");
        Result = Result.Replace("@", "%40");
        Result = Result.Replace("=", "%3D");
        Result = Result.Replace("&", "%26");
        Result = Result.Replace("$", "%24");
        Result = Result.Replace("-", "%2D");
        Result = Result.Replace("+", "%2B");
        return Result;

    }

    public static void OutlookAttachmentsInsert(DateTime Date_Attached, string DirectoryName)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("OutlookAttachmentsInsert");

        db.AddInParameter(dbCommand, "Date_Attached", DbType.DateTime, Date_Attached);
        db.AddInParameter(dbCommand, "DirectoryName", DbType.String, DirectoryName);

        db.ExecuteNonQuery(dbCommand);
    }

    public static string SaveFileLandscape(string strFileText, string strPath, string strFileName)
    {
        string strRetVal = "";
        // set path.
        if (!strPath.EndsWith("\\"))
        {
            strPath = string.Concat(strPath, "\\");
        }
        if (strPath.Contains("/"))
            strPath = strPath.Replace('/', '\\');

        clsGeneral.CreateDirectory(strPath);

        // now check for file name exists or not. and option for overwrite
        string strFulleName = string.Concat(strPath, strFileName);

        // if overwrite is not allowed then get filename to save.
        strFulleName = GetFileNameToSave(strFulleName);

        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        Aspose.Words.Document doc = new Aspose.Words.Document();

        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
        //builder.Font.Size = 12;
        //builder.Font.Bold = false;
        //builder.Font.Color = System.Drawing.Color.Black;
        builder.PageSetup.PaperSize = PaperSize.Letter;
        builder.PageSetup.BottomMargin = 40;
        builder.PageSetup.TopMargin = 40;
        builder.PageSetup.LeftMargin = 40;
        builder.PageSetup.RightMargin = 40;
        builder.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;
        //builder.Font.Name = "Arial";
        builder.InsertParagraph();
        builder.InsertHtml(strFileText);
        //builder.Write(litLetter.Text);

        doc.MailMerge.DeleteFields();
        doc.Save(strFulleName, Aspose.Words.SaveFormat.Doc);

        // set return value = only filename.
        strRetVal = clsGeneral.GetFileName(strFulleName);

        return strRetVal;
    }

    public static int GetIntMajorCoverage(string strMajor_Coverage)
    {
        if (!string.IsNullOrEmpty(strMajor_Coverage))
            return (int)(clsGeneral.Major_Coverage)Enum.Parse(typeof(clsGeneral.Major_Coverage), strMajor_Coverage, true);
        else
            return 0;
    }

    /// <summary>
    /// Set Directory to create new zip file
    /// </summary>
    /// <param name="strAttachments"></param>
    /// <param name="strzipDir"></param>
    public static void SetZipDirectory(string[] strAttachments, string strzipDir)
    {
        //if (Directory.Exists(strzipDir)) Directory.Delete(strzipDir, true);
        if (Directory.Exists(strzipDir))
        {
            string[] files = Directory.GetFiles(strzipDir);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
        }
        if (File.Exists(strzipDir + ".Zip")) File.Delete(strzipDir + ".Zip");
        Directory.CreateDirectory(strzipDir);
        for (int j = 0; j < strAttachments.Length; j++)
        {
            if (strAttachments[j] != null)
            {
                string Attachmentname = strAttachments[j];
                FileInfo fi = new FileInfo(Attachmentname);
                FileInfo fiTo = new FileInfo(strzipDir + "\\" + fi.Name);//if in destination same file name already exist then not copied
                if (fi.Exists && !fiTo.Exists)
                {
                    File.Copy(Attachmentname, strzipDir + "\\" + fi.Name);
                }
            }
        }
    }

    /// <summary>
    /// Download Zip
    /// </summary>
    /// <param name="SourcePath"></param>
    public static void DownloadZIP(string SourcePath)
    {
        ConvertZIP(SourcePath);
        System.IO.FileInfo file = new System.IO.FileInfo(SourcePath + ".Zip");
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
        HttpContext.Current.Response.AddHeader("Content-Disposition", ("attachment; filename=" + file.Name + "; size=") + file.Length.ToString());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.WriteFile(file.FullName);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// Create Zip file
    /// </summary>
    /// <param name="SourcePath"></param>
    public static void ConvertZIP(string SourcePath)
    {
        string destinationPath = SourcePath + ".Zip";
        FastZipEvents events = new FastZipEvents();
        events.ProcessFile = ProcessFileMethod;
        FastZip fZip = new FastZip();
        fZip.CreateZip(destinationPath, SourcePath, true, "");
    }

    /// <summary>
    /// Used to create zip file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private static void ProcessFileMethod(object sender, ScanEventArgs args)
    {
        try
        {
            string str = args.Name;
        }
        catch (Exception ex)
        {

        }

    }

    public static void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
    {
        System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);

        // Prevent using images internal thumbnail
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

        if (OnlyResizeIfWider)
        {
            if (FullsizeImage.Width <= NewWidth)
            {
                NewWidth = FullsizeImage.Width;
            }
        }

        int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
        if (NewHeight > MaxHeight)
        {
            // Resize with height instead
            NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
            NewHeight = MaxHeight;
        }

        System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

        // Clear handle to original file so that we can overwrite it if necessary
        FullsizeImage.Dispose();

        // Save resized picture
        NewImage.Save(NewFile);
    }

}

