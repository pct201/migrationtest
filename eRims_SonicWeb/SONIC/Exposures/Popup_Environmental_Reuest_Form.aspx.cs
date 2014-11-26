using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using Winnovative.WnvHtmlConvert;
using System.IO;
using System.Collections;
using System.Text;
using System.Data;

public partial class SONIC_Exposures_Popup_Environmental_Reuest_Form : clsBasePage
{
    #region " Properties "
    /// <summary>
    /// denotes Primary Key of EPM_Identification table
    /// </summary>
    public decimal PK_EPM_Identification
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Identification"]); }
        set { ViewState["PK_EPM_Identification"] = value; }
    }

    /// <summary>
    /// denotes Location ID
    /// </summary>
    public decimal Location_ID
    {
        get { return Convert.ToDecimal(ViewState["Location_ID"]); }
        set { ViewState["Location_ID"] = value; }
    }
    #endregion

    #region "Page Load event"
    /// <summary>
    /// handles Page load event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PK_EPM_Identification = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"].ToString()));
            Location_ID = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["loc"].ToString()));
            lblSubject.Text = "Environmental Request Form";
            clsEPM_Consultant ObjEPM_Consultant = new clsEPM_Consultant(Convert.ToInt32(PK_EPM_Identification));
            txtToEmail.Text = ObjEPM_Consultant.Constulant_Email;
        }
    }
    #endregion

    #region " Control events "
    /// <summary>
    /// handles Save Button's click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string strFilePath = "";
        strFilePath = "EPM-Environmental_Request_Form.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();


        if (PK_EPM_Identification > 0)
        {
            clsEPM_Identification ObjEPM_Identification = new clsEPM_Identification(PK_EPM_Identification);
            clsEPM_Consultant ObjEPM_Consultant = new clsEPM_Consultant(Convert.ToInt32(PK_EPM_Identification));
            clsEPM_Schedule ObjEPM_Schedule = new clsEPM_Schedule(Convert.ToInt32(PK_EPM_Identification));

            Security ObjSecurity = new Security(Convert.ToDecimal(clsSession.UserID));
            string strProject_Type = "";
            if (ObjEPM_Identification.FK_LU_EPM_Project_Type != null)
                strProject_Type = new LU_EPM_Project_Type((decimal)ObjEPM_Identification.FK_LU_EPM_Project_Type).Fld_Desc;
            else
                strProject_Type = "";

            string strRequesting_Entity = "";
            if (ObjEPM_Identification.FK_LU_EPM_Requesting_Entity != null)
                strRequesting_Entity = new LU_EPM_Requesting_Agency((decimal)ObjEPM_Identification.FK_LU_EPM_Requesting_Entity).Fld_Desc;
            else
                strRequesting_Entity = "";

            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";

            string strBuilding = "";
            DataSet dsBuilding = clsEPM_Consultant.GetBuildingsForJobRequestForm(PK_EPM_Identification);
            if (dsBuilding.Tables.Count > 0)
            {
                DataTable dtBuilding = clsEPM_Consultant.GetBuildingsForJobRequestForm(PK_EPM_Identification).Tables[0];
                if (dtBuilding != null && dtBuilding.Rows.Count > 0)
                {
                    for (int i = 0; i < dtBuilding.Rows.Count; i++)
                    {
                        strBuilding += dtBuilding.Rows[i]["Building_Occupacy"].ToString() + "<br/>";
                    }
                }
            }

            DataTable dtLocationInfo = LU_Location.SelectByPK(Location_ID).Tables[0];
            string Location_Number = "", Sonic_Location_dba = "", Location_Address = "", Location_City = "", Location_State = "", Location_Zip = "";
            if (dtLocationInfo != null && dtLocationInfo.Rows.Count > 0)
            {
                Location_Number = dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString();
                Sonic_Location_dba = dtLocationInfo.Rows[0]["dba"].ToString();
                Location_Address = dtLocationInfo.Rows[0]["Address"].ToString();
                Location_City = dtLocationInfo.Rows[0]["City"].ToString();
                Location_State = dtLocationInfo.Rows[0]["StateName"].ToString();
                Location_Zip = dtLocationInfo.Rows[0]["Zip_Code"].ToString();
            }

            string strCompanion_to_Project = "";
            DataTable dtCompanion_to_Project = clsEPM_Identification.SelectByFK(Convert.ToDecimal(ObjEPM_Identification.FK_EPM_Identification)).Tables[0];
            if (dtCompanion_to_Project != null && dtCompanion_to_Project.Rows.Count > 0)
            {
                strCompanion_to_Project = dtCompanion_to_Project.Rows[0]["Comp_Project"].ToString();
            }

            strEbdy = strEbdy.Replace("[Date]", clsGeneral.FormatDBNullDateToDisplay(DateTime.Now));
            strEbdy = strEbdy.Replace("[Sonic_Department_Requesting_Work]", strRequesting_Entity);

            #region " Location Info "

            strEbdy = strEbdy.Replace("[Project_Number]", ObjEPM_Identification.Project_Number);
            strEbdy = strEbdy.Replace("[Location_Number]", Location_Number);
            strEbdy = strEbdy.Replace("[City]", Location_City);
            strEbdy = strEbdy.Replace("[Address]", Location_Address);
            strEbdy = strEbdy.Replace("[Sonic_Location_dba]", Sonic_Location_dba);
            strEbdy = strEbdy.Replace("[State]", Location_State);
            strEbdy = strEbdy.Replace("[Zip]", Location_Zip);

            #endregion

            strEbdy = strEbdy.Replace("[Companion_to_Project]", strCompanion_to_Project);
            strEbdy = strEbdy.Replace("[Building]", strBuilding);

            #region " Equipment "

            DataTable dtEPM_Equipment = clsEPM_Identification_Equipment.SelectByFK(PK_EPM_Identification).Tables[0];
            if (dtEPM_Equipment != null && dtEPM_Equipment.Rows.Count > 0)
            {
                DataRow[] drHydraulic_Lift = dtEPM_Equipment.Select("Fld_Desc = 'Hydraulic Lift'");
                if (drHydraulic_Lift.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgHydraulic_Lift]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgHydraulic_Lift]", ImgUnchecked); }

                DataRow[] drOil_and_Water_Separator = dtEPM_Equipment.Select("Fld_Desc = 'Oil and Water Separator'");
                if (drOil_and_Water_Separator.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgOil_and_Water_Separator]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgOil_and_Water_Separator]", ImgUnchecked); }

                DataRow[] drPaint_Booth = dtEPM_Equipment.Select("Fld_Desc = 'Paint Booth'");
                if (drPaint_Booth.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgPaint_Booth]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgPaint_Booth]", ImgUnchecked); }

                DataRow[] drPaint_Gun_Cleaning_Cabinet = dtEPM_Equipment.Select("Fld_Desc = 'Paint Gun Cleaning Cabinet'");
                if (drPaint_Gun_Cleaning_Cabinet.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgPaint_Gun_Cleaning_Cabinet]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgPaint_Gun_Cleaning_Cabinet]", ImgUnchecked); }

                DataRow[] drPrep_Station = dtEPM_Equipment.Select("Fld_Desc = 'Prep Station'");
                if (drPrep_Station.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgPrep_Station]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgPrep_Station]", ImgUnchecked); }
            }
            else
            {
                strEbdy = strEbdy.Replace("[imgHydraulic_Lift]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgOil_and_Water_Separator]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgPaint_Booth]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgPaint_Gun_Cleaning_Cabinet]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgPrep_Station]", ImgUnchecked);
            }

            #endregion

            #region " Project Type "
            if (strProject_Type == "Asbestos Survey") { strEbdy = strEbdy.Replace("[imgAsbestos_Survey]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgAsbestos_Survey]", ImgUnchecked); }

            if (strProject_Type == "Consultant Services") { strEbdy = strEbdy.Replace("[imgConsultant_Services]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgConsultant_Services]", ImgUnchecked); }

            if (strProject_Type == "Environmental Assessment") { strEbdy = strEbdy.Replace("[imgEnvironmental_Assessment]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgEnvironmental_Assessment]", ImgUnchecked); }

            if (strProject_Type == "Environmental Remediation") { strEbdy = strEbdy.Replace("[imgEnvironmental_Remediation]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgEnvironmental_Remediation]", ImgUnchecked); }

            if (strProject_Type == "Inspection") { strEbdy = strEbdy.Replace("[imgInspection]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgInspection]", ImgUnchecked); }

            if (strProject_Type == "Mold Inspection") { strEbdy = strEbdy.Replace("[imgMold_Inspection]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgMold_Inspection]", ImgUnchecked); }

            if (strProject_Type == "Phase I") { strEbdy = strEbdy.Replace("[imgPhase_I]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgPhase_I]", ImgUnchecked); }

            if (strProject_Type == "Phase II") { strEbdy = strEbdy.Replace("[imgPhase_II]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgPhase_II]", ImgUnchecked); }

            if (strProject_Type == "Remediation") { strEbdy = strEbdy.Replace("[imgRemediation]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgRemediation]", ImgUnchecked); }

            if (strProject_Type == "SPCC Development") { strEbdy = strEbdy.Replace("[imgSPCC_Development]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgSPCC_Development]", ImgUnchecked); }

            if (strProject_Type == "Spill Response") { strEbdy = strEbdy.Replace("[imgSpill_Response]", ImgChecked); }
            else { strEbdy = strEbdy.Replace("[imgSpill_Response]", ImgUnchecked); }

            #endregion

            #region " Purpose of Project "
            DataTable dtPurpoe_Of_project = clsEPM_Identification_PurposeOfProject.SelectByFK(PK_EPM_Identification).Tables[0];
            if (dtPurpoe_Of_project != null && dtPurpoe_Of_project.Rows.Count > 0)
            {
                DataRow[] drLease_Termination = dtPurpoe_Of_project.Select("Fld_Desc = 'Lease Termination'");
                if (drLease_Termination.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgLease_Termination]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgLease_Termination]", ImgUnchecked); }

                DataRow[] drNew_Lease = dtPurpoe_Of_project.Select("Fld_Desc = 'New Lease'");
                if (drNew_Lease.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgNew_Lease]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgNew_Lease]", ImgUnchecked); }

                DataRow[] drPurchase = dtPurpoe_Of_project.Select("Fld_Desc = 'Purchase'");
                if (drPurchase.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgPurchase]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgPurchase]", ImgUnchecked); }

                DataRow[] drRefinance = dtPurpoe_Of_project.Select("Fld_Desc = 'Refinance'");
                if (drRefinance.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgRefinance]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgRefinance]", ImgUnchecked); }

                DataRow[] drSale = dtPurpoe_Of_project.Select("Fld_Desc = 'Sale'");
                if (drSale.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgSale]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgSale]", ImgUnchecked); }

                DataRow[] drOther = dtPurpoe_Of_project.Select("Fld_Desc = 'Other'");
                if (drOther.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgOther]", ImgChecked);
                    strEbdy = strEbdy.Replace("[Other]", ObjEPM_Identification.Other_PurposeOfProject);
                }
                else { strEbdy = strEbdy.Replace("[imgOther]", ImgUnchecked); strEbdy = strEbdy.Replace("[Other]", null); }
            }
            else
            {
                strEbdy = strEbdy.Replace("[imgLease_Termination]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgNew_Lease]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgPurchase]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgRefinance]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgSale]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgOther]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[Other]", null);
            }
            #endregion

            #region " Existing Documents "
            DataTable dtExistingDocs = clsEPM_Identification_ExistingDocuments.SelectByFK(PK_EPM_Identification).Tables[0];
            if (dtExistingDocs != null && dtExistingDocs.Rows.Count > 0)
            {
                DataRow[] drPreviousPhaseI_ESA = dtExistingDocs.Select("Fld_Desc = 'Previous Phase I ESA'");
                if (drPreviousPhaseI_ESA.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgPrevious_PhaseI_ESA]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgPrevious_PhaseI_ESA]", ImgUnchecked); }

                DataRow[] drPreviousPhaseII_ESA = dtExistingDocs.Select("Fld_Desc = 'Previous Phase II ESA'");
                if (drPreviousPhaseII_ESA.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgPrevious_PhaseII_ESA]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgPrevious_PhaseII_ESA]", ImgUnchecked); }

                DataRow[] drPrevious_Regulatory_Documents = dtExistingDocs.Select("Fld_Desc = 'Previous Regulatory Documents'");
                if (drPrevious_Regulatory_Documents.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgPrevious_Regulatory_Documents]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgPrevious_Regulatory_Documents]", ImgUnchecked); }

                DataRow[] drPrevious_Remediation_Documents = dtExistingDocs.Select("Fld_Desc = 'Previous Remediation Documents'");
                if (drPrevious_Remediation_Documents.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgPrevious_Remediation_Documents]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgPrevious_Remediation_Documents]", ImgUnchecked); }

                DataRow[] drSite_PlansConstruction_Drawings = dtExistingDocs.Select("Fld_Desc = 'Site Plans/Construction Drawings'");
                if (drSite_PlansConstruction_Drawings.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgSite_PlansConstruction_Drawings]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgSite_PlansConstruction_Drawings]", ImgUnchecked); }
            }
            else
            {
                strEbdy = strEbdy.Replace("[imgPrevious_PhaseI_ESA]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgPrevious_PhaseII_ESA]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgPrevious_Regulatory_Documents]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgPrevious_Remediation_Documents]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgSite_PlansConstruction_Drawings]", ImgUnchecked);
            }

            #endregion

            #region " Schedule "
            strEbdy = strEbdy.Replace("[Date_to_Consultant]", clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Schedule.Date_To_Consultant));
            strEbdy = strEbdy.Replace("[RM_Notification_Date]", clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Schedule.RM_Notification_Date));
            strEbdy = strEbdy.Replace("[Estimated_Start_Date]", clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Schedule.Estimated_Project_Start_Date));
            strEbdy = strEbdy.Replace("[Actual_Start_Date]", clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Schedule.Actual_Project_Start_Date));
            strEbdy = strEbdy.Replace("[Estimated_Completion_Date]", clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Schedule.Estimated_Project_Completion_Date));
            strEbdy = strEbdy.Replace("[Actual_Completion_Date]", clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Schedule.Actual_Project_Completion_Date));

            #endregion

            #region " Target Area "

            DataTable dtEPM_TargetArea = clsEPM_Identification_TargetArea.SelectByFK(PK_EPM_Identification).Tables[0];
            if (dtEPM_TargetArea != null && dtEPM_TargetArea.Rows.Count > 0)
            {
                DataRow[] drCar_Wash = dtEPM_TargetArea.Select("Fld_Desc = 'Car Wash'");
                if (drCar_Wash.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgCar_Wash]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgCar_Wash]", ImgUnchecked); }

                DataRow[] drCollision_Center = dtEPM_TargetArea.Select("Fld_Desc = 'Collision Center'");
                if (drCollision_Center.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgCollision_Center]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgCollision_Center]", ImgUnchecked); }

                DataRow[] drDetail = dtEPM_TargetArea.Select("Fld_Desc = 'Detail'");
                if (drDetail.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgDetail]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgDetail]", ImgUnchecked); }

                DataRow[] drEntireSite = dtEPM_TargetArea.Select("Fld_Desc = 'Entire Site'");
                if (drEntireSite.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgEntire_Site]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgEntire_Site]", ImgUnchecked); }

                DataRow[] drLand_un_developed = dtEPM_TargetArea.Select("Fld_Desc = 'Land (un-developed)'");
                if (drLand_un_developed.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgLand_un_developed]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgLand_un_developed]", ImgUnchecked); }

                DataRow[] drOffice = dtEPM_TargetArea.Select("Fld_Desc = 'Office'");
                if (drOffice.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgOffice]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgOffice]", ImgUnchecked); }

                DataRow[] drOther_Describe = dtEPM_TargetArea.Select("Fld_Desc = 'Other – Describe'");
                if (drOther_Describe.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgOther_Describe]", ImgChecked);
                    strEbdy = strEbdy.Replace("[Other_Describe]", ObjEPM_Identification.Other_Target_Area);
                }
                else { strEbdy = strEbdy.Replace("[imgOther_Describe]", ImgUnchecked); strEbdy = strEbdy.Replace("[Other_Describe]", null); }

                DataRow[] drParking_Lot = dtEPM_TargetArea.Select("Fld_Desc = 'Parking Lot'");
                if (drParking_Lot.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgParking_Lot]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgParking_Lot]", ImgUnchecked); }

                DataRow[] drParts = dtEPM_TargetArea.Select("Fld_Desc = 'Parts'");
                if (drParts.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgParts]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgParts]", ImgUnchecked); }

                DataRow[] drPond = dtEPM_TargetArea.Select("Fld_Desc = 'Pond'");
                if (drPond.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgPond]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgPond]", ImgUnchecked); }

                DataRow[] drSales = dtEPM_TargetArea.Select("Fld_Desc = 'Sales'");
                if (drSales.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgSales]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgSales]", ImgUnchecked); }

                DataRow[] drService_Department_Inside = dtEPM_TargetArea.Select("Fld_Desc = 'Service Department – Inside'");
                if (drService_Department_Inside.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgService_Department_Inside]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgService_Department_Inside]", ImgUnchecked); }

                DataRow[] drService_Department_Outside = dtEPM_TargetArea.Select("Fld_Desc = 'Service Department - Outside'");
                if (drService_Department_Outside.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgService_Department_Outside]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgService_Department_Outside]", ImgUnchecked); }

                DataRow[] drService_Drive = dtEPM_TargetArea.Select("Fld_Desc = 'Service Drive'");
                if (drService_Drive.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgService_Drive]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgService_Drive]", ImgUnchecked); }

                DataRow[] drShowroom = dtEPM_TargetArea.Select("Fld_Desc = 'Showroom'");
                if (drShowroom.Length > 0)
                {
                    strEbdy = strEbdy.Replace("[imgShowroom]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[imgShowroom]", ImgUnchecked); }
            }
            else
            {
                strEbdy = strEbdy.Replace("[imgCar_Wash]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgCollision_Center]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgDetail]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgEntire_Site]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgLand_un_developed]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgOffice]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgOther_Describe]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgParking_Lot]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgParts]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgPond]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgSales]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgService_Department_Inside]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgService_Department_Outside]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgService_Drive]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[imgShowroom]", ImgUnchecked);
                strEbdy = strEbdy.Replace("[Other_Describe]", null);
            }

            #endregion

            #region " Requesting Entity "

            //if (strRequesting_Entity == "Corporate Development") { strEbdy = strEbdy.Replace("[imgCorporate_Development]", ImgChecked); }
            //else { strEbdy = strEbdy.Replace("[imgCorporate_Development]", ImgUnchecked); }

            //if (strRequesting_Entity == "Facilities") { strEbdy = strEbdy.Replace("[imgFacilities]", ImgChecked); }
            //else { strEbdy = strEbdy.Replace("[imgFacilities]", ImgUnchecked); }

            //if (strRequesting_Entity == "Real Estate") { strEbdy = strEbdy.Replace("[imgReal_Estate]", ImgChecked); }
            //else { strEbdy = strEbdy.Replace("[imgReal_Estate]", ImgUnchecked); }

            //if (strRequesting_Entity == "Landlord") { strEbdy = strEbdy.Replace("[imgLandlord]", ImgChecked); }
            //else { strEbdy = strEbdy.Replace("[imgLandlord]", ImgUnchecked); }

            //if (strRequesting_Entity == "Other - Describe") { strEbdy = strEbdy.Replace("[imgOther_Describe]", ImgChecked); strEbdy = strEbdy.Replace("[Other_Describe_Requesting_Entity]", ObjEPM_Identification.Other_Requesting_Entity); }
            //else { strEbdy = strEbdy.Replace("[imgOther_Describe]", ImgUnchecked); strEbdy = strEbdy.Replace("[Other_Describe_Requesting_Entity]", null); }

            //if (strRequesting_Entity == "Risk Management") { strEbdy = strEbdy.Replace("[imgRisk_Management]", ImgChecked); }
            //else { strEbdy = strEbdy.Replace("[imgRisk_Management]", ImgUnchecked); }

            #endregion

            if (ObjEPM_Identification.Title_of_Person_Requesting_Work != null)
                strEbdy = strEbdy.Replace("[Person_Requesting_Work]", ObjEPM_Identification.Person_Requesting_Work + " / " + ObjEPM_Identification.Title_of_Person_Requesting_Work);
            else
                strEbdy = strEbdy.Replace("[Person_Requesting_Work]", ObjEPM_Identification.Person_Requesting_Work);

            #region " Consultant Info "
            string strState = "";
            if (ObjEPM_Consultant.FK_State != null)
            {
                strState = new State((decimal)ObjEPM_Consultant.FK_State).FLD_state;
            }
            else
                strState = "";
            strEbdy = strEbdy.Replace("[Consultant]", ObjEPM_Consultant.HH_Or_Other == true ? "Hart & Hickman" : "Other Consultant");
            strEbdy = strEbdy.Replace("[Address]", ObjEPM_Consultant.Consultant_Address_1 + ", " + ObjEPM_Consultant.Consultant_Address_2);
            strEbdy = strEbdy.Replace("[City_State_Zip]", ObjEPM_Consultant.Consultant_City + ", " + strState + ", " + ObjEPM_Consultant.Consultant_Zip_Code);
            strEbdy = strEbdy.Replace("[Consultant_Contact]", ObjEPM_Consultant.Consultant_Contact_Name);
            strEbdy = strEbdy.Replace("[Consultant_Phone_Number]", ObjEPM_Consultant.Consutlant_Telephone);
            #endregion

            strEbdy = strEbdy.Replace("[Current_Land_Use1]", null);
            strEbdy = strEbdy.Replace("[Current_Land_Use2]", null);
            strEbdy = strEbdy.Replace("[Intended_Future_Land_Use1]", null);
            strEbdy = strEbdy.Replace("[Intended_Future_Land_Use2]", null);
            strEbdy = strEbdy.Replace("[Contact_Name]", null);
            strEbdy = strEbdy.Replace("[Contact_Phone_Num]", null);
            strEbdy = strEbdy.Replace("[Contact_Mail]", null);
            strEbdy = strEbdy.Replace("[Is_Project_Confidential]", null);

            string strFileName = "eRIMS2 - Sonic - Environmental Project Management Module - Job Request Form.doc";
            //clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
            string strFilepath = clsGeneral.SaveJobRequestForm(strEbdy.ToString(), AppConfig.strEPM_AttachmentDocPath, strFileName);
            string[] strAttachments = new string[1];
            strAttachments[0] = AppConfig.strEPM_AttachmentDocPath + strFilepath;
            clsGeneral.SendMailMessage(AppConfig.MailFrom, txtToEmail.Text.Trim(), string.Empty, ObjSecurity.Email, "Environmental Request Form", txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, strAttachments);
            ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Mail sent successfully');window.opener.AskfForLogoff=false;self.close();", true);
        }
    }

    /// <summary>
    /// Handles Cancel Button's click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:window.opener.AskfForLogoff=false;self.close();", true);
    }
    #endregion
}