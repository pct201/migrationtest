using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for AppConfig
/// </summary>
/// 
public class AppConfig
{
    # region " Private Variables "

    /// <summary>
    /// indicate the error log mode
    /// </summary>    
    /// 
    public static string _strHtmltoPDFConverterKey = "5M/VxNXE0NPE0srUxNfVytXWyt3d3d0=";
    private static string _strErroLogMode;
    private static string _strSiteURL;
    private static string _strSitePath;
    private static string _strImageURL;
    private static string _strThemeImageURL;
    private static string _strDisplayDateFormat;
    private static string _strSQLDateFormat;
    private static string _strDocumentsPath;
    private static string _strDocumentsURL;

    private static string _strWC_FRPath;
    private static string _strWC_FRURL;
    private static string _strAL_FRPath;
    private static string _strAL_FRURL;
    private static string _strDPD_FRPath;
    private static string _strDPD_FRURL;
    private static string _strProperty_FRPath;
    private static string _strProperty_FRURL;
    private static string _strPL_FRPath;
    private static string _strPL_FRURL;
    private static string _strEnviro_AttachmentPath;
    private static string _strEnviro_AttachmentURL;
    private static string _strBuildingAttachDocPath;
    private static string _strBuildingAttachDocURL;

    private static string _strAdditionalInsuredDocPath;
    private static string _strAdditionalInsuredDocURL;

    private static string _strLeaseSubleaseDocPath;
    private static string _strLeaseSubleaseDocURL;

    private static string _strInspectionDocPath;
    private static string _strInspectionDocURL;

    private static string _strPropertyCOIDocPath;
    private static string _strPropertyCOIDocURL;

    private static string _strPropertyAssessmentDocPath;
    private static string _strPropertyAssessmentDocURL;

    private static string _strExecutiveRiskDocPath;
    private static string _strExecutiveRiskDocURL;

    private static string _strInvestigatorNotesDocPath;
    private static string _strInvestigatorNotesDocURL;

    private static string _strExecutive_Risk_ContactsDocPath;
    private static string _strExecutive_Risk_ContactsDocURL;

    private static string _strPremiumAllocationPath;


    private static string _strExecutiveRiskCarrierDocPath;
    private static string _strExecutiveRiskCarrierImageURL;
    private static string _strDefenseAttorneyDocPath;
    private static string _strDefenseAttorneyIamgeURL;
    private static string _strPlantiffAttorneyDocPath;
    private static string _strPlantiffAttorneyImageURL;
    private static string _strExecutiveRiskExpensesDocPath;
    private static string _strExecutiveRiskExpensesImageURL;
    private static string _strPurchasingServiceContractDocPath;
    private static string _strPurchasingServiceContractImagePath;

    private static string _strWCClaimDocPath;
    private static string _strWCClaimImageURL;
    private static string _strALClaimDocPath;
    private static string _strALClaimImageURL;
    private static string _strPLClaimDocPath;
    private static string _strPLClaimImageURL;
    private static string _strDPDClaimDocPath;
    private static string _strDPDClaimImageURL;
    private static string _strPropertyClaimDocPath;
    private static string _strPropertyClaimImageURL;

    private static long _maxRequestLength;
    private static string _MailFrom;
    private static string _MailTo;
    private static string _MailCC;
    private static string _SMTPserver;
    private static string _SMTPpwd;
    private static string _Port;
    private static string _ClaimEmailID;
    private static string _EPM_MaiTo;

    private static string _strPurchasingAssetDocPath;
    private static string _strPurchasingAssetImageURL;
    private static string _strPurchasing_LR_AgreementDocPath;
    private static string _strPurchasing_LR_AgreementImagePath;

    private static string _strRealEstateDocPath;
    private static string _strRealEstateImageURL;
    private static string _strInspectionFocusAreaDocURL;
    private static string _strInspectionFocusAreaDocPath;
    private static string _WC_FR_EmailID;
    private static string _PolicyDocURL;
    private static string _PolicyDocPath;

    private static string _PolicyFeatureDocURL;
    private static string _PolicyFeatureDocPath;

    private static string _strSabaTrainingDocPath;
    private static string _strSabaTrainingDocURL;
    private static bool _bAllowMailSending;

    private static string _strNoRiskImageURL;
    private static string _strRiskImageURL;

    private static string _Risk_ProfileDocURL;
    private static string _Risk_ProfileDocPath;

    private static string _Certificates_of_InsuranceDocURL;
    private static string _Certificates_of_InsuranceDocPath;

    private static string _strRiskProfileDocPath;
    private static string _strRiskProfileImageURL;
    private static string _strCOIDocPath;
    private static string _strCOIImageURL;
    private static string _strProducersDocPath;
    private static string _strProducersImageURL;
    private static string _strInsuranceCompanyDocPath;
    private static string _strInsuranceCompanyImageURL;
    private static string _strGeneralPolicyDocPath;
    private static string _strGeneralPolicyImageURL;
    private static string _strAutomobilePolicyDocPath;
    private static string _strAutomobilePolicyImageURL;
    private static string _strExcessPolicyDocPath;
    private static string _strExcessPolicyImageURL;
    private static string _strWCPolicyDocPath;
    private static string _strWCPolicyImageURL;
    private static string _strPropertyPolicyDocPath;
    private static string _strPropertyPolicyImageURL;
    private static string _strLocationDocPath;
    private static string _strLocationImageURL;

    private static string _strAdditionalInsuredImageURL;
    private static string _strProfessionalPolicyDocPath;
    private static string _strProfessionalPolicyImageURL;
    private static string _strLiquorPolicyDocPath;
    private static string _strLiquorPolicyImageURL;
    private static string _strOwnersDocPath;
    private static string _strOwnersImageUrl;
    private static string _strCopiesdocPath;
    private static string _strCopiesImageURL;

    private static string _strLetterHistoryDocPath;
    private static string _strLetterHistoryImageURL;

    private static string _strFranchiseDocPath;
    private static string _strFranchiseImageURL;

    private static string _strCRMCustomerDocPath;
    private static string _strCRMCustomerImageURL;

    private static string _strCRMNonCustomerDocPath;
    private static string _strCRMNonCustomerImageURL;

    private static string _strPM_SI_UP_AttachmentsDocPath;
    private static string _strPM_SI_UP_AttachmentsImageURL;

    private static string _strPM_Compliance_Reporting_OSHA_AttachmentsDocPath;
    private static string _strPM_Compliance_Reporting_OSHA_AttachmentsImageURL;

    private static string _strPM_SI_FI_AttachmentsDocPath;
    private static string _strPM_SI_FI_AttachmentsImageURL;

    private static string _strPermits_AttachmentsDocPath;
    private static string _strPermits_AttachmentsImageURL;

    private static string _strChemicalInventory_AttachmentsDocPath;
    private static string _strChemicalInventory_AttachmentsImageURL;

    private static string _strPaintInventory_AttachmentsDocPath;
    private static string _strPaintInventory_AttachmentsImageURL;

    private static string _strReceiving_TSDF_AttachmentsDocPath;
    private static string _strReceiving_TSDF_AttachmentsImageURL;

    private static string _strWaste_Hauler_AttachmentsDocPath;
    private static string _strWaste_Hauler_AttachmentsImageURL;

    private static string _strWaste_Removal_AttachmentsDocPath;
    private static string _strWaste_Removal_AttachmentsImageURL;

    private static string _strFrequency_AttachmentsDocPath;
    private static string _strFrequency_AttachmentsImageURL;

    private static string _strPhase_I_AttachmentsDocPath;
    private static string _strPhase_I_AttachmentsImageURL;

    private static string _strEPA_Inspection_AttachmentsDocPath;
    private static string _strEPA_Inspection_AttachmentsImageURL;

    private static string _strRemediation_Grid_AttachmentsDocPath;
    private static string _strRemediation_Grid_AttachmentsImageURL;

    private static string _strViolation_AttachmentsDocPath;
    private static string _strViolation_AttachmentsImageURL;

    private static string _strSite_Info_AttachmentDocPath;
    private static string _strSite_Info_AttachmentImageURL;

    private static string _strEquipment_Tank_AttachmentDocPath;
    private static string _strEquipment_Tank_AttachmentImageURL;

    private static string _strEquipment_Spray_Booth_AttachmentDocPath;
    private static string _strEquipment_Spray_Booth_AttachmentImageURL;

    private static string _strEquipment_OWS_AttachmentDocPath;
    private static string _strEquipment_OWS_AttachmentImageURL;

    private static string _strEquipment_Hydraulic_Lift_AttachmentDocPath;
    private static string _strEquipment_Hydraulic_Lift_AttachmentImageURL;

    private static string _strEquipment_PGCC_AttachmentDocPath;
    private static string _strEquipment_PGCC_AttachmentImageURL;

    private static string _strCR_Grids_AttachmentDocPath;
    private static string _strCR_Grids_AttachmentImageURL;

    private static string _strPM_Equipment_AttachmentDocPath;
    private static string _strPM_Equipment_AttachmentImageURL;

    private static string _strSLT_TrainingDocsPath;
    private static string _strSLT_TrainingImageURL;
    private static string _strSLT_SafetyWalkDocPath;
    private static string _strSLT_SafetyWalkImageURL;

    private static string _strEPMDocumentPath;
    private static string _strEPMDocumentURL;

    private static string _strFCPDocumentPath;
    private static string _strFCPDocumentURL;

    private static string _strAMDocumentPath;
    private static string _strAMDocumentURL;

    private static string _strEPM_AttachmentDocPath;
    private static string _strEPM_AttachmentImageURL;

    private static string _strAPDocumentPath;
    private static string _strAPDocumentURL;

    private static string _strGeneralDocument;

    private static DateTime _New_SLT_Safety_Walk_Date;
    private static int _SLT_Meeting_CutOff_Day;

    private static string _InvestigationDocPath;

    # endregion

    # region " Public Properties "

    /// <summary>
    /// indicate the error log mode
    /// </summary>
    public static string ErroLogMode
    {
        get { return _strErroLogMode; }
    }
    /// <summary>
    /// get and set sitepath.[virtual path]
    /// </summary>
    public static string SiteURL
    {
        get { return _strSiteURL; }
        set { _strSiteURL = value; }
    }
    /// <summary>
    /// get Physical path of application
    /// </summary>
    public static string SitePath
    {
        get { return _strSitePath; }
    }
    /// <summary>
    /// get Image URL
    /// </summary>
    public static string ImageURL
    {
        get { return _strImageURL; }
    }
    /// <summary>
    /// get Thumbnil Image Path
    /// </summary>
    public static string ThemeImageURL
    {
        get { return _strThemeImageURL; }
    }
    /// <summary>
    /// get Date Format that used to display
    /// </summary>
    public static string DisplayDateFormat
    {
        get { return _strDisplayDateFormat; }
    }
    /// <summary>
    /// get MaxRequest Length
    /// </summary>
    public static long MaxRequestLength
    {
        get { return _maxRequestLength; }
    }
    /// <summary>
    /// SMTP server to be used to send email
    /// </summary>
    public static string SMTPServer
    {
        get { return _SMTPserver; }
    }
    /// <summary>
    /// From address to be used to send eamil
    /// </summary>
    public static string FromAddress
    {
        get { return ""; }
    }

    public static string RiskImageURL
    {
        get { return _strRiskImageURL; }
    }
    public static string NoRiskImageURL
    {
        get { return _strNoRiskImageURL; }
    }

    public static string DocumentsPath
    {
        get { return _strDocumentsPath; }
    }

    public static string DocumentsURL
    {
        get { return _strDocumentsURL; }
    }

    /// <summary>
    /// Univarsal SQL Format is used while inserting value into db.
    /// it returns string in Univarsal date Format.
    /// </summary>
    public static string SQLDateFormat
    {
        get { return _strSQLDateFormat; }
    }

    private static string _strASPLoginURL;
    /// <summary>
    /// when session expired , redirect to this page , that is the ASP page from existing system.
    /// </summary>
    public static string ASPLoginURL
    {
        get { return _strASPLoginURL; }
    }

    /// <summary>
    /// get Doc Path for WC_FR 
    /// </summary>
    public static string WC_FRDocPath
    {
        get { return _strWC_FRPath; }
    }
    /// <summary>
    /// get and set Image URL for WC_FR
    /// </summary>
    public static string WC_FRImageURL
    {
        get { return _strWC_FRURL; }
    }
    /// <summary>
    /// Get Doc Path for AL_FR
    /// </summary>
    public static string AL_FRDocPath
    {
        get { return _strAL_FRPath; }
    }
    /// <summary>
    /// Get Image path for AL_FR
    /// </summary>
    public static string AL_FRImageURL
    {
        get { return _strAL_FRURL; }
    }
    /// <summary>
    /// Get and Set Doc Path for DPD_FR
    /// </summary>
    public static string DPD_FRDocPath
    {
        get { return _strDPD_FRPath; }
    }
    /// <summary>
    /// Get Image path for DPD_FR
    /// </summary>
    public static string DPD_FRImageURL
    {
        get { return _strDPD_FRURL; }
    }
    /// <summary>
    /// Get Doc Path for Property_FR
    /// </summary>
    public static string Property_FRDocPath
    {
        get { return _strProperty_FRPath; }
    }
    /// <summary>
    /// Get IMage path for Property_FR
    /// </summary>
    public static string Property_FRImageURL
    {
        get { return _strProperty_FRURL; }
    }
    /// <summary>
    /// Get DOc path for PL_FR
    /// </summary>
    public static string PL_FRDocPath
    {
        get { return _strPL_FRPath; }
    }
    /// <summary>
    /// Get Image URL for PL_FR
    /// </summary>
    public static string PL_FRImageURL
    {
        get { return _strPL_FRURL; }
    }
    /// <summary>
    /// Get from Email  ID
    /// </summary>
    public static string MailFrom
    {
        get { return _MailFrom; }
    }
    /// <summary>
    /// Get To Email ID
    /// </summary>
    public static string MailTo
    {
        get { return _MailTo; }
    }
    /// <summary>
    /// Get CC Email ID
    /// </summary>
    public static string MailCC
    {
        get { return _MailCC; }
    }
    /// <summary>
    /// Get Environment Folder Attachment Physical Path
    /// </summary>    
    public static string EnvirontmentPath
    {
        get { return _strEnviro_AttachmentPath; }
    }

    /// <summary>
    /// Get Environment Folder Attachment Virtual Path (URL)
    /// </summary>
    public static string EnvirontmentURL
    {
        get { return _strEnviro_AttachmentURL; }
    }

    public static string BuildingAttachDocPath
    {
        get { return _strBuildingAttachDocPath; }
    }

    public static string BuildingAttachDocURL
    {
        get { return _strBuildingAttachDocURL; }
    }

    public static string AdditionalInsuredDocPath
    {
        get { return _strAdditionalInsuredDocPath; }
    }

    public static string AdditionalInsuredDocURL
    {
        get { return _strAdditionalInsuredDocURL; }
    }

    public static string InspectionDocPath
    {
        get { return _strInspectionDocPath; }
    }

    public static string InspectionDocURL
    {
        get { return _strInspectionDocURL; }
    }

    public static string InspectionFocusAreaDocURL
    {
        get { return _strInspectionFocusAreaDocURL; }
    }

    public static string InspectionFocusAreaDocPath
    {
        get { return _strInspectionFocusAreaDocPath; }
    }

    public static string LeaseSubleaseDocPath
    {
        get { return _strLeaseSubleaseDocPath; }
    }

    public static string LeaseSubleaseDocURL
    {
        get { return _strLeaseSubleaseDocURL; }
    }

    public static string PropertyCOIDocPath
    {
        get { return _strPropertyCOIDocPath; }
    }

    public static string PropertyCOIDocURL
    {
        get { return _strPropertyCOIDocURL; }
    }

    public static string PropertyAssessmentDocPath
    {
        get { return _strPropertyAssessmentDocPath; }
    }

    public static string PropertyAssessmentDocURL
    {
        get { return _strPropertyAssessmentDocURL; }
    }

    public static DateTime SqlMinDateValue
    {
        get { return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; }
    }
    public static string SMTPpwd
    {
        get { return _SMTPpwd; }
    }
    public static string Port
    {
        get { return _Port; }
    }
    public static string InvestigatorNotesDocPath
    {
        get { return _strInvestigatorNotesDocPath; }
    }
    public static string InvestigatorNotesDocURL
    {
        get { return _strInvestigatorNotesDocURL; }
    }

    public static string ExecutiveRiskDocPath
    {
        get { return _strExecutiveRiskDocPath; }
    }

    public static string ExecutiveRiskDocURL
    {
        get { return _strExecutiveRiskDocURL; }
    }

    public static string Executive_Risk_ContactsDocPath
    {
        get { return _strExecutive_Risk_ContactsDocPath; }
    }

    public static string Executive_Risk_ContactsDocURL
    {
        get { return _strExecutive_Risk_ContactsDocURL; }
    }
    public static string ExecutiveRiskCarrierDocPath
    {
        get { return _strExecutiveRiskCarrierDocPath; }
    }
    public static string ExecutiveRiskCarrierImageURL
    {
        get { return _strExecutiveRiskCarrierImageURL; }
    }

    public static string DefenseAttorneyDocPath
    {
        get { return _strDefenseAttorneyDocPath; }
    }

    public static string DefenseAttorneyIamgeURL
    {
        get { return _strDefenseAttorneyIamgeURL; }
    }

    public static string PlantiffAttorneyDocPath
    {
        get { return _strPlantiffAttorneyDocPath; }
    }

    public static string PlantiffAttorneyImageURL
    {
        get { return _strPlantiffAttorneyImageURL; }
    }

    public static string ExecutiveRiskExpensesDocPath
    {
        get { return _strExecutiveRiskExpensesDocPath; }
    }

    public static string ExecutiveRiskExpensesImageURL
    {
        get { return _strExecutiveRiskExpensesImageURL; }
    }

    public static string WCClaimDocPath
    {
        get { return _strWCClaimDocPath; }
    }

    public static string WCClaimImageURL
    {
        get { return _strWCClaimImageURL; }
    }

    public static string ALClaimDocPath
    {
        get { return _strALClaimDocPath; }
    }

    public static string ALClaimImageURL
    {
        get { return _strALClaimImageURL; }
    }

    public static string PLClaimDocPath
    {
        get { return _strPLClaimDocPath; }
    }

    public static string PLClaimImageURL
    {
        get { return _strPLClaimImageURL; }
    }
    public static string DPDClaimDocPath
    {
        get { return _strDPDClaimDocPath; }
    }

    public static string DPDClaimImageURL
    {
        get { return _strDPDClaimImageURL; }
    }

    public static string PropertyClaimDocPath
    {
        get { return _strPropertyClaimDocPath; }
    }

    public static string PropertyClaimImageURL
    {
        get { return _strPropertyClaimImageURL; }
    }
    public static string ClaimEmailID
    {
        get { return _ClaimEmailID; }
    }
    public static string EPM_MaiTo
    {
        get { return _EPM_MaiTo; }
    }

    public static string PremiumAllocationPath
    {
        get { return _strPremiumAllocationPath; }
    }


    public static string PurchasingAssetDocPath
    {
        get { return _strPurchasingAssetDocPath; }
    }
    public static string PurchasingAssetImageURL
    {
        get { return _strPurchasingAssetImageURL; }
    }
    public static string PurchasingServiceContractDocPath
    {
        get { return _strPurchasingServiceContractDocPath; }
    }
    public static string PurchasingServiceContractImageURL
    {
        get { return _strPurchasingServiceContractImagePath; }
    }

    public static string Purchasing_LR_AgreementDocPath
    {
        get { return _strPurchasing_LR_AgreementDocPath; }
    }
    public static string Purchasing_LR_AgreementImageURL
    {
        get { return _strPurchasing_LR_AgreementImagePath; }
    }
    public static string WC_FR_EmailID
    {
        get { return _WC_FR_EmailID; }
    }

    public static string RealEstateDocPath
    {
        get { return _strRealEstateDocPath; }
    }
    public static string RealEstateImageURL
    {
        get { return _strRealEstateImageURL; }
    }

    public static string PolicyDocPath
    {
        get { return _PolicyDocPath; }
    }
    public static string PolicyDocURL
    {
        get { return _PolicyDocURL; }
    }


    public static string PolicyFeatureDocPath
    {
        get { return _PolicyFeatureDocPath; }
    }

    public static string PolicyFeatureDocURL
    {
        get { return _PolicyFeatureDocURL; }
    }

    public static string SabaTrainingDocPath
    {
        get { return _strSabaTrainingDocPath; }
    }
    public static string SabaTrainingDocURL
    {
        get { return _strSabaTrainingDocURL; }
    }

    public static bool AllowMailSending
    {
        get { return _bAllowMailSending; }
    }
    //COI
    public static string Risk_ProfileDocPath
    {
        get { return _Risk_ProfileDocPath; }
    }

    public static string Risk_ProfileDocURL
    {
        get { return _Risk_ProfileDocURL; }
    }
    public static string Certificates_of_InsuranceDocPath
    {
        get { return _Certificates_of_InsuranceDocPath; }
    }

    public static string Certificates_of_InsuranceDocURL
    {
        get { return _Certificates_of_InsuranceDocURL; }
    }

    public static string RiskProfileDocPath
    {
        get { return _strRiskProfileDocPath; }
    }

    public static string RiskProfileImageURL
    {
        get { return _strRiskProfileImageURL; }
    }
    public static string ProducersDocPath
    {
        get { return _strProducersDocPath; }
    }

    public static string ProducersImageURL
    {
        get { return _strProducersImageURL; }
    }

    public static string COIDocPath
    {
        get { return _strCOIDocPath; }
    }

    public static string COIImageURL
    {
        get { return _strCOIImageURL; }
    }

    public static string InsuranceCompanyDocPath
    {
        get { return _strInsuranceCompanyDocPath; }
    }
    public static string InsuranceCompanyImageURL
    {
        get { return _strInsuranceCompanyImageURL; }
    }

    public static string GeneralPolicyDocPath
    {
        get { return _strGeneralPolicyDocPath; }
    }
    public static string GeneralPolicyImageURL
    {
        get { return _strGeneralPolicyImageURL; }
    }
    public static string AutomobilePolicyDocPath
    {
        get { return _strAutomobilePolicyDocPath; }
    }
    public static string AutomobilePolicyImageURL
    {
        get { return _strAutomobilePolicyImageURL; }
    }
    public static string ExcessPolicyDocPath
    {
        get { return _strExcessPolicyDocPath; }
    }
    public static string ExcessPolicyImageURL
    {
        get { return _strExcessPolicyImageURL; }
    }
    public static string WCPolicyDocPath
    {
        get { return _strWCPolicyDocPath; }
    }
    public static string WCPolicyImageURL
    {
        get { return _strWCPolicyImageURL; }
    }
    public static string PropertyPolicyDocPath
    {
        get { return _strPropertyPolicyDocPath; }
    }
    public static string PropertyPolicyImageURL
    {
        get { return _strPropertyPolicyImageURL; }
    }
    public static string LocationDocPath
    {
        get { return _strLocationDocPath; }
    }
    public static string LocationImageURL
    {
        get { return _strLocationImageURL; }
    }

    public static string OwnersDocPath
    {
        get { return _strOwnersDocPath; }
    }
    public static string OwnersImageURL
    {
        get { return _strOwnersImageUrl; }
    }
    public static string LetterHistoryDocPath
    {
        get { return _strLetterHistoryDocPath; }
    }
    public static string AdditionalInsuredImageURL
    {
        get { return _strAdditionalInsuredImageURL; }
    }
    public static string ProfessionalPolicyDocPath
    {
        get { return _strProfessionalPolicyDocPath; }
    }
    public static string ProfessionalPolicyImageURL
    {
        get { return _strProfessionalPolicyImageURL; }
    }

    public static string LiquorPolicyDocPath
    {
        get { return _strLiquorPolicyDocPath; }
    }
    public static string LiquorPolicyImageURL
    {
        get { return _strLiquorPolicyImageURL; }
    }

    public static string CopiesDocPath
    {
        get { return _strCopiesdocPath; }
    }
    public static string CopiesImageURL
    {
        get { return _strCopiesImageURL; }
    }

    public static string FranchiseDocPath
    {
        get { return _strFranchiseDocPath; }
    }

    public static string FranchiseImageURL
    {
        get { return _strFranchiseImageURL; }
    }

    public static string CRMCustomerDocPath
    {
        get { return _strCRMCustomerDocPath; }
    }

    public static string CRMCustomerImageURL
    {
        get { return _strCRMCustomerImageURL; }
    }

    public static string CRMNonCustomerDocPath
    {
        get { return _strCRMNonCustomerDocPath; }
    }

    public static string CRMNonCustomerImageURL
    {
        get { return _strCRMNonCustomerImageURL; }
    }
    //Pollution
    public static string PM_SI_UP_AttachmentsDocPath
    {
        get { return _strPM_SI_UP_AttachmentsDocPath; }
    }

    public static string PM_Compliance_Reporting_OSHA_AttachmentsDocPath
    {
        get { return _strPM_Compliance_Reporting_OSHA_AttachmentsDocPath; }
    }

    public static string PM_SI_UP_AttachmentsImageURL
    {
        get { return _strPM_SI_UP_AttachmentsImageURL; }
    }

    public static string PM_Compliance_Reporting_OSHA_AttachmentsImageURL
    {
        get { return _strPM_Compliance_Reporting_OSHA_AttachmentsImageURL; }
    }

    public static string PM_SI_FI_AttachmentsDocPath
    {
        get { return _strPM_SI_FI_AttachmentsDocPath; }
    }

    public static string PM_SI_FI_AttachmentsImageURL
    {
        get { return _strPM_SI_FI_AttachmentsImageURL; }
    }

    public static string Permits_AttachmentsDocPath
    {
        get { return _strPermits_AttachmentsDocPath; }
    }

    public static string Permits_AttachmentsImageURL
    {
        get { return _strPermits_AttachmentsImageURL; }
    }

    public static string ChemicalInventory_AttachmentsDocPath
    {
        get { return _strChemicalInventory_AttachmentsDocPath; }
    }

    public static string ChemicalInventory_AttachmentsImageURL
    {
        get { return _strChemicalInventory_AttachmentsImageURL; }
    }

    public static string PaintInventory_AttachmentsDocPath
    {
        get { return _strPaintInventory_AttachmentsDocPath; }
    }

    public static string PaintInventory_AttachmentsImageURL
    {
        get { return _strPaintInventory_AttachmentsImageURL; }
    }

    public static string Receiving_TSDF_AttachmentsDocPath
    {
        get { return _strReceiving_TSDF_AttachmentsDocPath; }
    }

    public static string Receiving_TSDF_AttachmentsImageURL
    {
        get { return _strReceiving_TSDF_AttachmentsImageURL; }
    }

    public static string Waste_Hauler_AttachmentsDocPath
    {
        get { return _strWaste_Hauler_AttachmentsDocPath; }
    }

    public static string Waste_Hauler_AttachmentsImageURL
    {
        get { return _strWaste_Hauler_AttachmentsImageURL; }
    }

    public static string Waste_Removal_AttachmentsDocPath
    {
        get { return _strWaste_Removal_AttachmentsDocPath; }
    }

    public static string Waste_Removal_AttachmentsImageURL
    {
        get { return _strWaste_Removal_AttachmentsImageURL; }
    }

    public static string Frequency_AttachmentsDocPath
    {
        get { return _strFrequency_AttachmentsDocPath; }
    }

    public static string Frequency_AttachmentsImageURL
    {
        get { return _strFrequency_AttachmentsImageURL; }
    }

    public static string Phase_I_AttachmentsDocPath
    {
        get { return _strPhase_I_AttachmentsDocPath; }
    }

    public static string Phase_I_AttachmentsImageURL
    {
        get { return _strPhase_I_AttachmentsImageURL; }
    }

    public static string EPA_Inspection_AttachmentsDocPath
    {
        get { return _strEPA_Inspection_AttachmentsDocPath; }
    }

    public static string EPA_Inspection_AttachmentsImageURL
    {
        get { return _strEPA_Inspection_AttachmentsImageURL; }
    }

    public static string Remediation_Grid_AttachmentsDocPath
    {
        get { return _strRemediation_Grid_AttachmentsDocPath; }
    }

    public static string Remediation_Grid_AttachmentsImageURL
    {
        get { return _strRemediation_Grid_AttachmentsImageURL; }
    }

    public static string Violation_AttachmentsDocPath
    {
        get { return _strViolation_AttachmentsDocPath; }
    }

    public static string Violation_AttachmentsImageURL
    {
        get { return _strViolation_AttachmentsImageURL; }
    }

    public static string Site_Info_AttachmentDocPath
    {
        get { return _strSite_Info_AttachmentDocPath; }
    }

    public static string Site_Info_AttachmentImageURL
    {
        get { return _strSite_Info_AttachmentImageURL; }
    }

    public static string StrEquipment_Spray_Booth_AttachmentImageURL
    {
        get { return _strEquipment_Spray_Booth_AttachmentImageURL; }
    }

    public static string StrEquipment_Spray_Booth_AttachmentDocPath
    {
        get { return _strEquipment_Spray_Booth_AttachmentDocPath; }
    }

    public static string StrEquipment_OWS_AttachmentImageURL
    {
        get { return _strEquipment_OWS_AttachmentImageURL; }
    }

    public static string StrEquipment_OWS_AttachmentDocPath
    {
        get { return _strEquipment_OWS_AttachmentDocPath; }
    }

    public static string StrEquipment_Hydraulic_Lift_AttachmentImageURL
    {
        get { return _strEquipment_Hydraulic_Lift_AttachmentImageURL; }
    }

    public static string StrEquipment_Hydraulic_Lift_AttachmentDocPath
    {
        get { return _strEquipment_Hydraulic_Lift_AttachmentDocPath; }
    }

    public static string StrEquipment_PGCC_AttachmentImageURL
    {
        get { return _strEquipment_PGCC_AttachmentImageURL; }
    }

    public static string StrEquipment_PGCC_AttachmentDocPath
    {
        get { return _strEquipment_PGCC_AttachmentDocPath; }
    }

    public static string StrCR_Grids_AttachmentImageURL
    {
        get { return _strCR_Grids_AttachmentImageURL; }
    }

    public static string StrCR_Grids_AttachmentDocPath
    {
        get { return _strCR_Grids_AttachmentDocPath; }
    }

    public static string StrEquipment_Tank_AttachmentImageURL
    {
        get { return _strEquipment_Tank_AttachmentImageURL; }
    }

    public static string StrEquipment_Tank_AttachmentDocPath
    {
        get { return _strEquipment_Tank_AttachmentDocPath; }
    }

    public static string StrPM_Equipment_AttachmentDocPath
    {
        get { return _strPM_Equipment_AttachmentDocPath; }
    }
    public static string StrPM_Equipment_AttachmentImageURL
    {
        get { return _strPM_Equipment_AttachmentImageURL; }
    }

    public static string strSLT_SafetyWalkDocPath
    {
        get { return _strSLT_SafetyWalkDocPath; }
    }
    public static string strSLT_SafetyWalkImageURL
    {
        get { return _strSLT_SafetyWalkImageURL; }
    }
    public static string strSLT_TrainingDocsPath
    {
        get { return _strSLT_TrainingDocsPath; }
    }
    public static string strSLT_TrainingImageURL
    {
        get { return _strSLT_TrainingImageURL; }
    }

    public static string strEPMDocumentPath
    {
        get { return _strEPMDocumentPath; }
    }
    public static string strEPMDocumentURL
    {
        get { return _strEPMDocumentURL; }
    }

    public static string strFCPDocumentPath
    {
        get { return _strFCPDocumentPath; }
    }
    public static string strFCPDocumentURL
    {
        get { return _strFCPDocumentURL; }
    }

    public static string strAMDocumentPath
    {
        get { return _strAMDocumentPath; }
    }

    public static string strAMDocumentURL
    {
        get { return _strAMDocumentURL; }
    }

    public static string strEPM_AttachmentDocPath
    {
        get { return _strEPM_AttachmentDocPath; }
    }
    public static string strEPM_AttachmentImageURL
    {
        get { return _strEPM_AttachmentImageURL; }
    }

    public static string strAPDocumentPath
    {
        get { return _strAPDocumentPath; }
    }
    public static string strAPDocumentURL
    {
        get { return _strAPDocumentURL; }
    }

    public static string strGeneralDocument
    {
        get { return _strGeneralDocument; }
    }

    public static DateTime New_SLT_Safety_Walk_Date
    {
        get { return _New_SLT_Safety_Walk_Date; }
    }

    public static int SLT_Meeting_CutOff_Day
    {
        get { return _SLT_Meeting_CutOff_Day; }
    }

    public static string InvestigationDocPath
    {
        get { return _InvestigationDocPath; }
        set { _InvestigationDocPath = value; }
        
    }
    #endregion

    # region " Public Functions "


    /// <summary>
    /// Method is Called only once throughout the Application.
    /// Variables those are needed throughout the Application and whose values remains same are set in this method.
    /// </summary>
    public static void OnApplicationStart()
    {
        // set SiteURL and SitePath
        //_strSiteURL = String.Concat("http://", HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath);
        _strSiteURL = String.Concat(HttpContext.Current.Request.Url.Scheme + "://", HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath);
        if (!_strSiteURL.EndsWith("/")) _strSiteURL = String.Concat(_strSiteURL, "/");
        _strSitePath = String.Concat(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath), @"\");
        //_strSiteURL = _strSiteURL.Replace("webserver", "www.tatvasoft.com");
        //_strSiteURL = _strSiteURL.Replace("localhost", "www.tatvasoft.com");
        SiteURL = _strSiteURL;

        // set Image URL
        _strImageURL = String.Concat(SiteURL, ConfigurationManager.AppSettings["ImagesURL"]);

        //getting date from when new module implemented.
        _New_SLT_Safety_Walk_Date = Convert.ToDateTime(ConfigurationManager.AppSettings["New_SLT_Safety_Walk_Date"]);

        //getting cutoff day for creating slt meeting in next month
        //doing dynamic as per mail from steve on 05-Jun-2014 Subject:-"FW: SLT Notes - Stone Mountain Toyota"

        _SLT_Meeting_CutOff_Day = Convert.ToInt16(ConfigurationManager.AppSettings["SLT_Meeting_CutOff_Day"]);

        // set Theme Image URL
        _strThemeImageURL = String.Concat(SiteURL, ConfigurationManager.AppSettings["ThemeImagesURL"]);

        //set display date format
        _strDisplayDateFormat = ConfigurationManager.AppSettings["DisplayDateFormat"];
        //set date format in which all date are stored in db
        _strSQLDateFormat = ConfigurationManager.AppSettings["SQLDateFormat"];

        string AttachmentDocPath = ConfigurationManager.AppSettings["AttachmentDocs"];
        _strDocumentsPath = string.Concat(SitePath, AttachmentDocPath) + "\\";
        _strDocumentsURL = string.Concat(SiteURL, AttachmentDocPath) + "/";

        // indicate the error log mode
        _strErroLogMode = ConfigurationManager.AppSettings["ErroLogMode"].ToString().ToLower();
        // set max request length
        _maxRequestLength = Convert.ToInt64(ConfigurationManager.AppSettings["maxRequestLength"]);
        //when session expired , redirect to this page , that is the ASP page from existing system.
        _strASPLoginURL = string.Concat(SiteURL, ConfigurationManager.AppSettings["ASPLoginURL"]);
        //set physical path of WC_FR
        _strWC_FRPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["WC_FRDocs"] + "\\");
        //set virtual path of WC_FR
        _strWC_FRURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["WC_FRDocs"] + "/");
        //set physical path of AL_FR
        _strAL_FRPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["AL_FRDocs"] + "\\");
        //set virtual path of AL_FR
        _strAL_FRURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["AL_FRDocs"] + "/");
        //set physical path of DPD_FR
        _strDPD_FRPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["DPD_FRDocs"] + "\\");
        //set Virtual Path of DPD_FR
        _strDPD_FRURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["DPD_FRDocs"] + "/");
        //set physical path of Property_FR
        _strProperty_FRPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Property_FRDocs"] + "\\");
        //set virtual path of Property_FR
        _strProperty_FRURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Property_FRDocs"] + "/");
        //set physical path of PL_FR
        _strPL_FRPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PL_FRDocs"] + "\\");
        //set Virtual path of PL_FR
        _strPL_FRURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PL_FRDocs"] + "/");
        //set From Mail
        _MailFrom = ConfigurationManager.AppSettings["SMTPmail"];
        //set To mail
        _MailTo = ConfigurationManager.AppSettings["TestmailTo"];
        //set CC mail
        _MailCC = ConfigurationManager.AppSettings["mailCC"];
        //set SMTP server name
        _SMTPserver = ConfigurationManager.AppSettings["SMTPserver"];
        //SMTP Password
        _SMTPpwd = ConfigurationManager.AppSettings["SMTPPwd"];
        //SMTP POrt
        _Port = ConfigurationManager.AppSettings["Port"];
        //Claim From Email ID
        _ClaimEmailID = ConfigurationManager.AppSettings["ClaimEmailID"];
        //
        _EPM_MaiTo = ConfigurationManager.AppSettings["EPM_MaiTo"];
        //set physical path of Environment
        _strEnviro_AttachmentPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["EnvironDoc"] + "\\");
        //set Virtual path of Environment
        _strEnviro_AttachmentURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["EnvironDoc"] + "/");

        _strBuildingAttachDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["BuildingDocs"] + "\\");
        _strBuildingAttachDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["BuildingDocs"] + "/");


        _strAdditionalInsuredDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["AdditionalInsuredDocs"] + "\\");
        _strAdditionalInsuredDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["AdditionalInsuredDocs"] + "/");

        _strLeaseSubleaseDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["LeaseSubleaseDocs"] + "\\");
        _strLeaseSubleaseDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["LeaseSubleaseDocs"] + "/");

        _strPropertyCOIDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PropertyCOIDocs"] + "\\");
        _strPropertyCOIDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PropertyCOIDocs"] + "/");

        _strPropertyAssessmentDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PropertyAssessmentDocs"] + "\\");
        _strPropertyAssessmentDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PropertyAssessmentDocs"] + "/");

        _strInspectionDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["InspectionDocs"] + "\\");
        _strInspectionDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["InspectionDocs"] + "/");

        _strInspectionFocusAreaDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["InspectionFocusAreaDocs"] + "\\");
        _strInspectionFocusAreaDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["InspectionFocusAreaDocs"] + "/");

        _strExecutiveRiskDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["ExecutiveRiskDocs"] + "\\");
        _strExecutiveRiskDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["ExecutiveRiskDocs"] + "/");

        _strInvestigatorNotesDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["InvestigatorNotesDocs"] + "\\");
        _strInvestigatorNotesDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["InvestigatorNotesDocs"] + "/");

        _strExecutive_Risk_ContactsDocPath = string.Concat(SitePath, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Executive_Risk_ContactsDocs"] + "\\");
        _strExecutive_Risk_ContactsDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Executive_Risk_ContactsDocs"] + "/");

        _strExecutiveRiskCarrierDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["ExecutiveRiskCarrierDocs"] + "\\");
        _strExecutiveRiskCarrierImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["ExecutiveRiskCarrierDocs"] + "/");

        _strDefenseAttorneyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["DefenseAttorneyDocs"] + "\\");
        _strDefenseAttorneyIamgeURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["DefenseAttorneyDocs"] + "/");


        _strPlantiffAttorneyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PlantiffAttorneyDocs"] + "\\");
        _strPlantiffAttorneyImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PlantiffAttorneyDocs"] + "/");

        _strExecutiveRiskExpensesDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["ExecutiveRiskExpensesDocs"] + "\\");
        _strExecutiveRiskExpensesImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["ExecutiveRiskExpensesDocs"] + "/");

        _strWCClaimDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["WCClaimDocs"] + "\\");
        _strWCClaimImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["WCClaimDocs"] + "/");

        _strALClaimDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["ALClaimDocs"] + "\\");
        _strALClaimImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["ALClaimDocs"] + "/");

        _strPLClaimDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PLClaimDocs"] + "\\");
        _strPLClaimImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PLClaimDocs"] + "/");
        _strDPDClaimDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["DPDClaimDocs"] + "\\");
        _strDPDClaimImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["DPDClaimDocs"] + "/");

        _strPremiumAllocationPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PremiumAllocationPath"] + "\\");

        _strPropertyClaimDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PropertyClaimDocs"] + "\\");
        _strPropertyClaimImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PropertyClaimDocs"] + "/");

        _strPurchasingAssetDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PurchasingDocs"] + "\\");
        _strPurchasingAssetImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PurchasingDocs"] + "/");

        _strPurchasingServiceContractDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PurchasingServiceContractDocPath"] + "\\");
        _strPurchasingServiceContractImagePath = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PurchasingServiceContractDocPath"] + "/");

        _strPurchasing_LR_AgreementDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Purchasing_LR_AgreementDocPath"] + "\\");
        _strPurchasing_LR_AgreementImagePath = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Purchasing_LR_AgreementDocPath"] + "/");

        _strRealEstateDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["RealEstateDocs"] + "\\");
        _strRealEstateImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["RealEstateDocs"] + "/");

        //WC FR From Email ID
        if (!string.IsNullOrEmpty(Convert.ToString(ConfigurationManager.AppSettings["WC_FR_EmailID"])))
            _WC_FR_EmailID = ConfigurationManager.AppSettings["WC_FR_EmailID"];
        else
            _WC_FR_EmailID = null;

        _PolicyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Policy"] + "\\");
        _PolicyDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Policy"] + "/");

        _PolicyFeatureDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PolicyFeature"] + "\\");
        _PolicyFeatureDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PolicyFeature"] + "/");

        _strSabaTrainingDocPath = string.Concat(SitePath, AttachmentDocPath, @"\", ConfigurationManager.AppSettings["SabaTrainingDoc"] + "\\");
        _strSabaTrainingDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["SabaTrainingDoc"] + "/");

        //COI
        _Risk_ProfileDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["RiskProfile"] + "\\");
        _Risk_ProfileDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["RiskProfile"] + "/");

        _Certificates_of_InsuranceDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["CertificatesofInsurance"] + "\\");
        _Certificates_of_InsuranceDocURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["CertificatesofInsurance"] + "/");

        object objMailSending = ConfigurationManager.AppSettings["AllowMailSending"];
        bool bOutMail;
        if (bool.TryParse(Convert.ToString(objMailSending), out bOutMail))
            _bAllowMailSending = bOutMail;
        else
            _bAllowMailSending = false;

        _strRiskImageURL = string.Concat(_strImageURL, @"\rdb-red.gif");
        _strNoRiskImageURL = string.Concat(_strImageURL, @"\rdb-green.gif");

        _strRiskProfileDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["RiskProfileDocs"] + "\\");
        _strRiskProfileImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["RiskProfileDocs"] + "/");

        _strCOIDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["COIDocs"] + "\\");
        _strCOIImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["COIDocs"] + "/");

        _strProducersDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["ProducersDocs"] + "\\");
        _strProducersImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["ProducersDocs"] + "/");

        _strInsuranceCompanyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["InsuranceCompanyDocs"] + "\\");
        _strInsuranceCompanyImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["InsuranceCompanyDocs"] + "/");

        _strGeneralPolicyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["GeneralPolicyDocs"] + "\\");
        _strGeneralPolicyImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["GeneralPolicyDocs"] + "/");

        _strAutomobilePolicyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["AutomobilePolicyDocs"] + "\\");
        _strAutomobilePolicyImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["AutomobilePolicyDocs"] + "/");

        _strExcessPolicyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["ExcessPolicyDocs"] + "\\");
        _strExcessPolicyImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["ExcessPolicyDocs"] + "/");

        _strWCPolicyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["WCPolicyDocs"] + "\\");
        _strWCPolicyImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["WCPolicyDocs"] + "/");

        _strPropertyPolicyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PropertyPolicyDocs"] + "\\");
        _strPropertyPolicyImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PropertyPolicyDocs"] + "/");

        _strLocationDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["LocationDocs"] + "\\");
        _strLocationImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["LocationDocs"] + "/");

        _strAdditionalInsuredDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["AdditionalInsuredDocs"] + "\\");
        _strAdditionalInsuredImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["AdditionalInsuredDocs"] + "/");

        _strProfessionalPolicyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["ProfessionalPolicyDocs"] + "\\");
        _strProfessionalPolicyImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["ProfessionalPolicyDocs"] + "/");

        _strLiquorPolicyDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["LiquorPolicyDocs"] + "\\");
        _strLiquorPolicyImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["LiquorPolicyDocs"] + "/");

        _strOwnersDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["OwnersDocs"] + "\\");
        _strOwnersImageUrl = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["OwnersDocs"] + "/");

        _strCopiesdocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["CopiesDocs"] + "\\");
        _strCopiesImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["CopiesDocs"] + "/");

        _strLetterHistoryDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["LetterHistoryDocs"] + "\\");
        _strLetterHistoryImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["LetterHistoryDocs"] + "/");

        _strFranchiseDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["FranchiseDocs"] + "\\");
        _strFranchiseImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["FranchiseDocs"] + "/");

        _strCRMCustomerDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["CRMCustomerDocs"] + "\\");
        _strCRMCustomerImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["CRMCustomerDocs"] + "/");

        _strCRMNonCustomerDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["CRMNonCustomerDocs"] + "\\");
        _strCRMNonCustomerImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["CRMNonCustomerDocs"] + "/");

        _strPM_SI_UP_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PM_SI_UP_AttachmentsDocs"] + "\\");
        _strPM_SI_UP_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PM_SI_UP_AttachmentsDocs"] + "/");

        _strPM_Compliance_Reporting_OSHA_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PM_Compliance_Reporting_OSHA_AttachmentsDocs"] + "\\");
        _strPM_Compliance_Reporting_OSHA_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PM_Compliance_Reporting_OSHA_Attachments"] + "/");

        _strPM_SI_FI_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PM_SI_FI_AttachmentsDocs"] + "\\");
        _strPM_SI_FI_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PM_SI_FI_AttachmentsDocs"] + "/");

        _strPermits_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Permits_Attachments"] + "\\");
        _strPermits_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Permits_Attachments"] + "/");

        _strChemicalInventory_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["ChemicalInventory"] + "\\");
        _strChemicalInventory_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["ChemicalInventory"] + "/");

        _strPaintInventory_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PaintInventory"] + "\\");
        _strPaintInventory_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PaintInventory"] + "/");

        _strReceiving_TSDF_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Receiving_TSDF"] + "\\");
        _strReceiving_TSDF_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Receiving_TSDF"] + "/");

        _strWaste_Hauler_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Waste_Hauler"] + "\\");
        _strWaste_Hauler_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Waste_Hauler"] + "/");

        _strWaste_Removal_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Waste_Removal"] + "\\");
        _strWaste_Removal_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Waste_Removal"] + "/");

        _strFrequency_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Frequency"] + "\\");
        _strFrequency_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Frequency"] + "/");

        _strPhase_I_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Phase_I"] + "\\");
        _strPhase_I_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Phase_I"] + "/");

        _strEPA_Inspection_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["EPA_Inspection"] + "\\");
        _strEPA_Inspection_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["EPA_Inspection"] + "/");

        _strRemediation_Grid_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Remediation_Grid"] + "\\");
        _strRemediation_Grid_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Remediation_Grid"] + "/");

        _strViolation_AttachmentsDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Violation"] + "\\");
        _strViolation_AttachmentsImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Violation"] + "/");

        _strSite_Info_AttachmentDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PM_AttachmentDocs"] + "\\");
        _strSite_Info_AttachmentImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PM_AttachmentDocs"] + "/");


        _strEquipment_Hydraulic_Lift_AttachmentDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Equipment_Hydraulic_LiftDocs"] + "\\");
        _strEquipment_Hydraulic_Lift_AttachmentImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Equipment_Hydraulic_LiftDocs"] + "/");

        _strEquipment_OWS_AttachmentDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Equipment_OWS_AttachmentDocs"] + "\\");
        _strEquipment_OWS_AttachmentImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Equipment_OWS_AttachmentDocs"] + "/");

        _strEquipment_PGCC_AttachmentDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Equipment_PGCC_AttachmentDocs"] + "\\");
        _strEquipment_PGCC_AttachmentImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Equipment_PGCC_AttachmentDocs"] + "/");

        _strCR_Grids_AttachmentDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["CR_Grids_AttachmentDocs"] + "\\");
        _strCR_Grids_AttachmentImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["CR_Grids_AttachmentDocs"] + "/");

        _strEquipment_Spray_Booth_AttachmentDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Equipment_Spray_Booth_AttachmentDocs"] + "\\");
        _strEquipment_Spray_Booth_AttachmentImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Equipment_Spray_Booth_AttachmentDocs"] + "/");

        _strEquipment_Tank_AttachmentDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Equipment_Tank_AttachmentDocs"] + "\\");
        _strEquipment_Tank_AttachmentImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Equipment_Tank_AttachmentDocs"] + "/");

        _strPM_Equipment_AttachmentDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["PM_Equipment_AttachmentsDocs"] + "\\");
        _strPM_Equipment_AttachmentImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["PM_Equipment_AttachmentsDocs"] + "/");

        _strSLT_SafetyWalkDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["SLT_SafetyWalkDocs"] + "\\");
        _strSLT_SafetyWalkImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["SLT_SafetyWalkDocs"] + "/");
        _strSLT_TrainingDocsPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["SLT_TrainingDocs"] + "\\");
        _strSLT_TrainingImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["SLT_TrainingDocs"] + "/");

        _strEPMDocumentPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["EPM_Docs"] + "\\");
        _strEPMDocumentURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["EPM_Docs"] + "/");

        _strFCPDocumentPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["FCP_Docs"] + "\\");
        _strFCPDocumentURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["FCP_Docs"] + "/");

        _strAMDocumentPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["AM_Docs"] + "\\");
        _strAMDocumentURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["AM_Docs"] + "/");

        _strEPM_AttachmentDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["EPM_Attachment"] + "\\");
        _strEPM_AttachmentImageURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["EPM_Attachment"] + "/");

        _strAPDocumentPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Asset_Protection_Docs"] + "\\");
        _strAPDocumentURL = string.Concat(SiteURL, AttachmentDocPath, "/", ConfigurationManager.AppSettings["Asset_Protection_Docs"] + "/");

        _InvestigationDocPath = string.Concat(SitePath, AttachmentDocPath, "\\", ConfigurationManager.AppSettings["Investigation"] + "\\");
        
        _strGeneralDocument = string.Concat(SitePath, AttachmentDocPath);
    }
    # endregion
}

