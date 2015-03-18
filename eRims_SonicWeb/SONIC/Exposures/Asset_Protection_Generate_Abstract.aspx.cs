using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using Winnovative.WnvHtmlConvert;
using System.IO;
using System.Collections;
using System.Text;

public partial class SONIC_Exposures_Asset_Protection_Generate_Abstract : System.Web.UI.Page
{

    #region Properties

    public decimal LocationID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["LocationID"]);
        }
        set { ViewState["LocationID"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_AP_Property_Security
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_Property_Security"]);
        }
        set { ViewState["PK_AP_Property_Security"] = value; }
    }

    /// <summary>
    /// Denotes the Panel No
    /// </summary>
    public int Panel
    {
        get
        {
            return clsGeneral.GetInt(ViewState["Panel"]);
        }
        set { ViewState["Panel"] = value; }
    }

    /// <summary>
    /// Denotes the Selected Panel Primary Key
    /// </summary>
    public int PKID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PKID"]);
        }
        set { ViewState["PKID"] = value; }
    }

    /// <summary>
    /// Denotes the Vehicle Id Key
    /// </summary>
    public int VID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["VID"]);
        }
        set { ViewState["VID"] = value; }
    }
    #endregion

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                LocationID = Convert.ToDecimal(Request.QueryString["id"]);
            }
            if (Request.QueryString["ps_id"] != null)
            {
                PK_AP_Property_Security = Convert.ToDecimal(Request.QueryString["ps_id"]);
            }
            if (Request.QueryString["panel"] != null)
            {
                Panel = clsGeneral.GetInt(Request.QueryString["panel"]);
            }
            if (Request.QueryString["PKID"] != null)
            {
                PKID = clsGeneral.GetInt(Request.QueryString["PKID"]);
            }
            if (Request.QueryString["VID"] != null)
            {
                VID = clsGeneral.GetInt(Request.QueryString["VID"]);
            }
        }
    }

    #endregion

    #region " Control Events"

    protected void btnGenerateAbstract_OnClick(object sender, EventArgs e)
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        if (rbtnList.SelectedValue == "1")
        {
            GenerateHTML();
            //GenerateHTMLOLD();
        }
        else
        {
            if (PKID == 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please select record to generate abstract report.');javascript:window.close();", true);
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:window.close();", true);
            }
            else
            {
                if (Panel == 1)
                {
                    GenerateHTMLForPropertySecurity();
                }
                else if (Panel == 2)
                {
                    GenerateHTMLForDPD();
                }
                else if (Panel == 3)
                {
                    GenerateHTMLForAL();
                }
                else if (Panel == 4)
                {
                    GenerateHTMLForFraudEvent();
                }
                else if (Panel == 5)
                {
                    //GenerateHTMLForFraudEvent();
                }
            }
        }
    }

    #endregion

    #region "Method"
    /// <summary>
    /// function use for generate html output for report
    /// </summary>
    /// <param name="sbHtml"></param>    
    private void GenerateHTMLOLD()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();

        if (LocationID > 0)
        {

            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";


            clsAP_Property_Security objAP_Property_Security = new clsAP_Property_Security(PK_AP_Property_Security);
            #region "Financial Grid"

            // get datatable for Location
            sbHtml = new System.Text.StringBuilder("");
            GenerateFinancialGrid(sbHtml);
            strEbdy = strEbdy.Replace("[Financial_Grid]", sbHtml.ToString());


            strEbdy = strEbdy.Replace("[CCTV_Company_Name]", objAP_Property_Security.CCTV_Company_Name);
            strEbdy = strEbdy.Replace("[CCTV_Company_Address_1]", objAP_Property_Security.CCTV_Company_Address_1);
            strEbdy = strEbdy.Replace("[CCTV_Company_Address_2]", objAP_Property_Security.CCTV_Company_Address_2);
            strEbdy = strEbdy.Replace("[CCTV_Company_City]", objAP_Property_Security.CCTV_Company_City);
            if (objAP_Property_Security.FK_CCTV_Company_State != null)
            {
                string CompanyState = new State((decimal)objAP_Property_Security.FK_CCTV_Company_State).FLD_state;
                strEbdy = strEbdy.Replace("[CCTV_Company_State]", CompanyState);
            }
            else
                strEbdy = strEbdy.Replace("[CCTV_Company_State]", "");
            strEbdy = strEbdy.Replace("[CCTV_Company_Zip]", objAP_Property_Security.CCTV_Company_Zip);
            strEbdy = strEbdy.Replace("[CCTV_Company_Contact_Name]", objAP_Property_Security.CCTV_Company_Contact_Name);
            strEbdy = strEbdy.Replace("[CCTV_Company_Contact_Telephone]", objAP_Property_Security.CCTV_Comapny_Contact_Telephone);
            strEbdy = strEbdy.Replace("[CCTV_Company_Contact_EMail]", objAP_Property_Security.CCTV_Company_Contact_EMail);
            strEbdy = strEbdy.Replace("[Cal_Atlantic_System]", objAP_Property_Security.Cal_Atlantic_System == "Y" ? "Yes" : "No");
            strEbdy = strEbdy.Replace("[Live_Monitoring]", objAP_Property_Security.Live_Monitoring == "Y" ? "Yes" : "No");
            strEbdy = strEbdy.Replace("[Hours_Monitored_From]", objAP_Property_Security.Hours_Monitored_From);
            strEbdy = strEbdy.Replace("[Hours_Monitored_To]", objAP_Property_Security.Hours_Monitored_To);
            if (objAP_Property_Security.ECC_Back == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccBack]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccBack]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Car_Wash == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccCarWash]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccCarWash]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Front == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccFront]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccFront]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Satellite_Parking == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccSatellite_Parking]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccSatellite_Parking]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Side == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccSide]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccSide]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Zero_Lot_Line == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccZero_Lot_Line]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccZero_Lot_Line]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccOther]", ImgUnchecked); }
            strEbdy = strEbdy.Replace("[Exterior_Camera_Coverage_Desc]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Exterior_Camera_Coverage_Other_Description));

            if (objAP_Property_Security.ICC_Body_Shop == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccBody_Shop]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccBody_Shop]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Cashier == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccCashier]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccCashier]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Computer_Room == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccComputer_Room]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccComputer_Room]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Detail_Bays == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccDetail_Bays]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccDetail_Bays]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Key_Box_Area == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccKey_Box_Area]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccKey_Box_Area]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Parts_Receiving_Area == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccPart_Receiving_Area]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccPart_Receiving_Area]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Service_Department == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccService_Department]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccService_Department]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Service_Lane == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccService_Lane]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccService_Lane]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Showroom == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccShowroom]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccShowroom]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Smart_Safe_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccSmart_Safe_Office]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccSmart_Safe_Office]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccOther]", ImgUnchecked); }
            strEbdy = strEbdy.Replace("[Interior_Camera_Coverage_Other_Description]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Interior_Camera_Coverage_Other_Description));

            strEbdy = strEbdy.Replace("[Burglar_Alarm_System]", objAP_Property_Security.Buglar_Alarm_System == "Y" ? "Yes" : "No");
            strEbdy = strEbdy.Replace("[Is_System_Active_Functioning]", objAP_Property_Security.Is_System_Active_and_Function_Properly == "Y" ? "Yes" : "No");
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Name]", objAP_Property_Security.Burglar_Alarm_Company_Name);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Address1]", objAP_Property_Security.Burglar_Alarm_Company_Address_1);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Address2]", objAP_Property_Security.Burglar_Alarm_Company_Address_2);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_City]", objAP_Property_Security.Burglar_Alarm_Company_City);
            if (objAP_Property_Security.FK_Burglar_Alarm_Company_State != null)
            {
                string strFK_Burglar_Alarm_Company_State = new State((decimal)objAP_Property_Security.FK_Burglar_Alarm_Company_State).FLD_state;
                strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_State]", strFK_Burglar_Alarm_Company_State);
            }
            else
                strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_State]", "");

            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Zip]", objAP_Property_Security.Burglar_Alarm_Company_Zip);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Contact_Name]", objAP_Property_Security.Burglar_Alarm_Company_Contact_Name);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Contact_Telephone]", objAP_Property_Security.Burglar_Alarm_Comapny_Contact_Telephone);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Contact_EMail]", objAP_Property_Security.Burglar_Alarm_Company_Contact_EMail);
            if (objAP_Property_Security.ZD_Collision_Center == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDCollisionCenter]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDCollisionCenter]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDOffice]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDOffice]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Parts == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDParts]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDParts]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDSales_Showroom]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDSales_Showroom]", ImgUnchecked); }

            if (objAP_Property_Security.ZD_Sales == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDService]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDService]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDOther]", ImgUnchecked); }
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Coverage]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Burglar_Alarm_Coverage_Other_Description));
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Coverage_Comment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Burglar_Alarm_Coverage_Comments));
            strEbdy = strEbdy.Replace("[Guard_Company_Name]", objAP_Property_Security.Guard_Company_Name);
            strEbdy = strEbdy.Replace("[Guard_Company_Address1]", objAP_Property_Security.Guard_Company_Address_1);
            strEbdy = strEbdy.Replace("[Guard_Company_Address2]", objAP_Property_Security.Guard_Company_Address_2);
            strEbdy = strEbdy.Replace("[Guard_Company_City]", objAP_Property_Security.Guard_Company_City);
            if (objAP_Property_Security.FK_Guard_Company_State != null)
            {
                string strFK_Guard_Company_State = new State((decimal)objAP_Property_Security.FK_Guard_Company_State).FLD_state;
                strEbdy = strEbdy.Replace("[Guard_Company_State]", strFK_Guard_Company_State);
            }
            else
                strEbdy = strEbdy.Replace("[Guard_Company_State]", "");
            strEbdy = strEbdy.Replace("[Guard_Company_Zip]", objAP_Property_Security.Guard_Company_Zip);
            strEbdy = strEbdy.Replace("[Guard_Company_Contact_Name]", objAP_Property_Security.Guard_Company_Contact_Name);
            strEbdy = strEbdy.Replace("[Guard_Company_Contact_Telephone]", objAP_Property_Security.Guard_Comapny_Contact_Telephone);
            strEbdy = strEbdy.Replace("[Guard_Company_Contact_EMail]", objAP_Property_Security.Guard_Company_Contact_EMail);
            strEbdy = strEbdy.Replace("[Guard_Hours_Monitored_From]", objAP_Property_Security.Guard_Hours_Monitored_From);
            strEbdy = strEbdy.Replace("[Guard_Hours_Monitored_To]", objAP_Property_Security.Guard_Hours_Monitored_To);
            strEbdy = strEbdy.Replace("[Off_Duty_Officer_Name]", objAP_Property_Security.OffDuty_Officer_Name);
            strEbdy = strEbdy.Replace("[Off_Duty_Officer_Telephone]", objAP_Property_Security.OffDuty_Officer_Telephone);
            strEbdy = strEbdy.Replace("[Off_Duty_Officer_Hours_Monitored_From]", objAP_Property_Security.OffDuty_Officer_Hours_Monitored_From);
            strEbdy = strEbdy.Replace("[Off_Duty_Officer_Hours_Monitored_To]", objAP_Property_Security.OffDuty_Officer_Hours_Monitored_To);
            if (objAP_Property_Security.AC_1st_Floor_Only == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACFirstFloorOnly]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACFirstFloorOnly]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Business_Area == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACBusinessArea]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACBusinessArea]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Cashier == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACCashier]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACCashier]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Computer_Room == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACComputer_Room]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACComputer_Room]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Controller_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACController_Office]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACController_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_EnterExit_Building == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACEnter_Exit_Building]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACEnter_Exit_Building]", ImgUnchecked); }
            if (objAP_Property_Security.AC_F_and_I_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACFIOffice]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACFIOffice]", ImgUnchecked); }
            if (objAP_Property_Security.AC_GM_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACGM_Office]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACGM_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Multiple_Floors == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACMultiple_Floors]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACMultiple_Floors]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACParts]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACParts]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Smart_Sales_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACSmart_Safe_Office]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACSmart_Safe_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACOther]", ImgUnchecked); }
            strEbdy = strEbdy.Replace("[Access_Control_Other_Description]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Access_Control_Other_Description));
            if (objAP_Property_Security.FG_EntranceExit_Alarms == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFGEnterenceExitAlarms]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFGEnterenceExitAlarms]", ImgUnchecked); }
            if (objAP_Property_Security.FG_EntranceExit_Gate == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFGEnterenceExitGate]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFGEnterenceExitGate]", ImgUnchecked); }
            if (objAP_Property_Security.F_Back == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFBack]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFBack]", ImgUnchecked); }
            if (objAP_Property_Security.F_Entire_Perimeter == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFEntierPerimeter]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFEntierPerimeter]", ImgUnchecked); }
            if (objAP_Property_Security.F_Front == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFFront]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFFront]", ImgUnchecked); }
            if (objAP_Property_Security.F_Satellite_Parking_Lot == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFSatelliteParkingLot]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFSatelliteParkingLot]", ImgUnchecked); }
            if (objAP_Property_Security.F_Side == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFSide]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFSide]", ImgUnchecked); }
            if (objAP_Property_Security.P_Back == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPBack]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPBack]", ImgUnchecked); }
            if (objAP_Property_Security.P_Entire_Perimeter == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPEntirePerimeter]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPEntirePerimeter]", ImgUnchecked); }
            if (objAP_Property_Security.P_Front == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPFront]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPFront]", ImgUnchecked); }
            if (objAP_Property_Security.P_Satellite_Parking_Lot == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPSatelliteParkingLot]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPSatelliteParkingLot]", ImgUnchecked); }
            if (objAP_Property_Security.P_Side == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPSide]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPSide]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Auto_Tracks == "Y")
            {
                strEbdy = strEbdy.Replace("[imgSITSAutoTracks]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgSITSAutoTracks]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Key_Tracks == "Y")
            {
                strEbdy = strEbdy.Replace("[imgSITSKeyTracks]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgSITSKeyTracks]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgSITSOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgSITSOther]", ImgUnchecked); }

            strEbdy = strEbdy.Replace("[Security_Inventory_Tracking_System_Other_Description]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Security_Inventory_Tracking_System_Other_Description));

            if (objAP_Property_Security.Cap_Index_Crime_Score != null)
                strEbdy = strEbdy.Replace("[Cap_Index_Crime_Score]", Convert.ToString(objAP_Property_Security.Cap_Index_Crime_Score));
            else
                strEbdy = strEbdy.Replace("[Cap_Index_Crime_Score]", "");
            if (objAP_Property_Security.Cap_Index_Risk_Cateogory != null)
                strEbdy = strEbdy.Replace("[Cap_Index_Risk_Category]", new clsLU_AP_Cap_Index_Risk_Category((decimal)objAP_Property_Security.Cap_Index_Risk_Cateogory).Fld_Desc);
            else
                strEbdy = strEbdy.Replace("[Cap_Index_Risk_Category]", "");

            DateTime? BeginDate = null;
            DateTime? EndDate = null;
            if (txtBegin_Date.Text.Trim() != "")
            {
                BeginDate = clsGeneral.FormatDateToStore(txtBegin_Date.Text);
            }
            if (txtEndDate.Text.Trim() != "")
            {
                EndDate = clsGeneral.FormatDateToStore(txtEndDate.Text);
            }

            DataSet ds = clsAP_DPD_FROIs.GetAbstractLetter(LocationID, BeginDate, EndDate);

            #region "Location"

            // get datatable for Location
            sbHtml = new System.Text.StringBuilder("");
            GenerateLocationGrid(sbHtml);
            strEbdy = strEbdy.Replace("[Location_Grid]", sbHtml.ToString());

            #endregion



            #endregion

            #region "DPD FROIs"

            sbHtml = new System.Text.StringBuilder("");
            // get datatable for DPD records
            DataTable dtDPD = ds.Tables[0];
            GenerateDPDFROI(sbHtml, dtDPD);
            strEbdy = strEbdy.Replace("[DPD_Grid]", sbHtml.ToString());
            #endregion

            #region "AL FROIs"

            // get datatable for AL records
            DataTable dtAL = ds.Tables[1];
            sbHtml = new System.Text.StringBuilder("");
            GenerateALFROI(sbHtml, dtAL);
            strEbdy = strEbdy.Replace("[AL_Grid]", sbHtml.ToString());

            #endregion

            #region "Cal-Atlantic"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Cal-Atlantic records
            DataTable dtCAL = ds.Tables[2];
            GenerateCALAtlantic(sbHtml, dtCAL);
            strEbdy = strEbdy.Replace("[CAL_Grid]", sbHtml.ToString());
            #endregion

            #region "Fraud Events"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Fraud_Event records
            DataTable dtFraud = ds.Tables[3];
            GenerateFraudEvent(sbHtml, dtFraud);
            strEbdy = strEbdy.Replace("[Fraud_Grid]", sbHtml.ToString());

            #endregion

            #region "Monitoring Grid"

            DataSet dsMonitoringGrid = clsAP_Property_Security_Monitor_Grids.SelectAllForMonitoringGrid(PK_AP_Property_Security);

            // get datatable for Fraud_Event records
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'CCTV'";
            DataTable dtCCTVMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtCCTVMonitoringGrid);
            strEbdy = strEbdy.Replace("[gvCCTVHoursMonitoringGrid]", sbHtml.ToString());


            //Bind Guard Monitoring Grid
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Guard'";
            DataTable dtGuardMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtGuardMonitoringGrid);
            strEbdy = strEbdy.Replace("[gvGuardsHoursMonitoringGrid]", sbHtml.ToString());

            //Bidn Off Duty Monitoring Grid
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Off-Duty Officer'";
            DataTable dtOffDutyMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtOffDutyMonitoringGrid);
            strEbdy = strEbdy.Replace("[gvOffdutyMonitorGrid]", sbHtml.ToString());

            #endregion

        }

        string strFileName = "Asset Protection Abstract.doc";

        clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
    }

    private void GenerateHTML()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        Hashtable htFindAndReplace = new Hashtable();
        if (LocationID > 0)
        {

            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";


            clsAP_Property_Security objAP_Property_Security = new clsAP_Property_Security(PK_AP_Property_Security);

            #region "Financial Grid"

            // get datatable for Location
            sbHtml = new System.Text.StringBuilder("");
            GenerateFinancialGrid(sbHtml);
            htFindAndReplace.Add("[Financial_Grid]", sbHtml.ToString());

            htFindAndReplace.Add("[CCTV_Company_Name]", objAP_Property_Security.CCTV_Company_Name);

            htFindAndReplace.Add("[CCTV_Company_Address_1]", objAP_Property_Security.CCTV_Company_Address_1);
            htFindAndReplace.Add("[CCTV_Company_Address_2]", objAP_Property_Security.CCTV_Company_Address_2);
            htFindAndReplace.Add("[CCTV_Company_City]", objAP_Property_Security.CCTV_Company_City);
            if (objAP_Property_Security.FK_CCTV_Company_State != null)
            {
                string CompanyState = new State((decimal)objAP_Property_Security.FK_CCTV_Company_State).FLD_state;
                htFindAndReplace.Add("[CCTV_Company_State]", CompanyState);
            }
            else
                htFindAndReplace.Add("[CCTV_Company_State]", "");
            htFindAndReplace.Add("[CCTV_Company_Zip]", objAP_Property_Security.CCTV_Company_Zip);
            htFindAndReplace.Add("[CCTV_Company_Contact_Name]", objAP_Property_Security.CCTV_Company_Contact_Name);
            htFindAndReplace.Add("[CCTV_Company_Contact_Telephone]", objAP_Property_Security.CCTV_Comapny_Contact_Telephone);
            htFindAndReplace.Add("[CCTV_Company_Contact_EMail]", objAP_Property_Security.CCTV_Company_Contact_EMail);
            htFindAndReplace.Add("[Cal_Atlantic_System]", objAP_Property_Security.Cal_Atlantic_System == "Y" ? "Yes" : "No");
            htFindAndReplace.Add("[Live_Monitoring]", objAP_Property_Security.Live_Monitoring == "Y" ? "Yes" : "No");
            htFindAndReplace.Add("[Hours_Monitored_From]", objAP_Property_Security.Hours_Monitored_From);
            htFindAndReplace.Add("[Hours_Monitored_To]", objAP_Property_Security.Hours_Monitored_To);
            if (objAP_Property_Security.ECC_Back == "Y")
            {
                htFindAndReplace.Add("[imgEccBack]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccBack]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Car_Wash == "Y")
            {
                htFindAndReplace.Add("[imgEccCarWash]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccCarWash]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Front == "Y")
            {
                htFindAndReplace.Add("[imgEccFront]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccFront]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Satellite_Parking == "Y")
            {
                htFindAndReplace.Add("[imgEccSatellite_Parking]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccSatellite_Parking]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Side == "Y")
            {
                htFindAndReplace.Add("[imgEccSide]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccSide]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Zero_Lot_Line == "Y")
            {
                htFindAndReplace.Add("[imgEccZero_Lot_Line]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccZero_Lot_Line]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Other == "Y")
            {
                htFindAndReplace.Add("[imgEccOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccOther]", ImgUnchecked); }
            htFindAndReplace.Add("[Exterior_Camera_Coverage_Desc]", objAP_Property_Security.Exterior_Camera_Coverage_Other_Description);

            if (objAP_Property_Security.ICC_Body_Shop == "Y")
            {
                htFindAndReplace.Add("[imgIccBody_Shop]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccBody_Shop]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Cashier == "Y")
            {
                htFindAndReplace.Add("[imgIccCashier]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccCashier]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Computer_Room == "Y")
            {
                htFindAndReplace.Add("[imgIccComputer_Room]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccComputer_Room]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Detail_Bays == "Y")
            {
                htFindAndReplace.Add("[imgIccDetail_Bays]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccDetail_Bays]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Key_Box_Area == "Y")
            {
                htFindAndReplace.Add("[imgIccKey_Box_Area]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccKey_Box_Area]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Parts_Receiving_Area == "Y")
            {
                htFindAndReplace.Add("[imgIccPart_Receiving_Area]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccPart_Receiving_Area]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Service_Department == "Y")
            {
                htFindAndReplace.Add("[imgIccService_Department]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccService_Department]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Service_Lane == "Y")
            {
                htFindAndReplace.Add("[imgIccService_Lane]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccService_Lane]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Showroom == "Y")
            {
                htFindAndReplace.Add("[imgIccShowroom]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccShowroom]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Smart_Safe_Office == "Y")
            {
                htFindAndReplace.Add("[imgIccSmart_Safe_Office]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccSmart_Safe_Office]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Other == "Y")
            {
                htFindAndReplace.Add("[imgIccOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccOther]", ImgUnchecked); }
            htFindAndReplace.Add("[Interior_Camera_Coverage_Other_Description]", objAP_Property_Security.Interior_Camera_Coverage_Other_Description);

            htFindAndReplace.Add("[ECC_Number_Of_External_Cameras]", clsGeneral.FormatCommaSeperatorNumber(objAP_Property_Security.ECC_Number_Of_External_Cameras));
            htFindAndReplace.Add("[ECC_Number_Of_Internal_Cameras]", clsGeneral.FormatCommaSeperatorNumber(objAP_Property_Security.ECC_Number_Of_Internal_Cameras));

            if (objAP_Property_Security.AC_Key_Fobs == "Y")
            {
                htFindAndReplace.Add("[imgAC_Key_Fobs]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgAC_Key_Fobs]", ImgUnchecked); }

            if (objAP_Property_Security.AC_Door_Restrictions == "Y")
            {
                htFindAndReplace.Add("[imgAC_Door_Restrictions]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgAC_Door_Restrictions]", ImgUnchecked); }

            htFindAndReplace.Add("[Burglar_Alarm_System]", objAP_Property_Security.Buglar_Alarm_System == "Y" ? "Yes" : "No");
            htFindAndReplace.Add("[Is_System_Active_Functioning]", objAP_Property_Security.Is_System_Active_and_Function_Properly == "Y" ? "Yes" : "No");
            htFindAndReplace.Add("[Burglar_Alarm_Company_Name]", objAP_Property_Security.Burglar_Alarm_Company_Name);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Address1]", objAP_Property_Security.Burglar_Alarm_Company_Address_1);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Address2]", objAP_Property_Security.Burglar_Alarm_Company_Address_2);
            htFindAndReplace.Add("[Burglar_Alarm_Company_City]", objAP_Property_Security.Burglar_Alarm_Company_City);
            if (objAP_Property_Security.FK_Burglar_Alarm_Company_State != null)
            {
                string strFK_Burglar_Alarm_Company_State = new State((decimal)objAP_Property_Security.FK_Burglar_Alarm_Company_State).FLD_state;
                htFindAndReplace.Add("[Burglar_Alarm_Company_State]", strFK_Burglar_Alarm_Company_State);
            }
            else
                htFindAndReplace.Add("[Burglar_Alarm_Company_State]", "");

            htFindAndReplace.Add("[Burglar_Alarm_Company_Zip]", objAP_Property_Security.Burglar_Alarm_Company_Zip);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Contact_Name]", objAP_Property_Security.Burglar_Alarm_Company_Contact_Name);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Contact_Telephone]", objAP_Property_Security.Burglar_Alarm_Comapny_Contact_Telephone);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Contact_EMail]", objAP_Property_Security.Burglar_Alarm_Company_Contact_EMail);
            if (objAP_Property_Security.ZD_Collision_Center == "Y")
            {
                htFindAndReplace.Add("[imgZDCollisionCenter]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDCollisionCenter]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Office == "Y")
            {
                htFindAndReplace.Add("[imgZDOffice]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDOffice]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Parts == "Y")
            {
                htFindAndReplace.Add("[imgZDParts]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDParts]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Other == "Y")
            {
                htFindAndReplace.Add("[imgZDSales_Showroom]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDSales_Showroom]", ImgUnchecked); }

            if (objAP_Property_Security.ZD_Sales == "Y")
            {
                htFindAndReplace.Add("[imgZDService]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDService]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Other == "Y")
            {
                htFindAndReplace.Add("[imgZDOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDOther]", ImgUnchecked); }
            htFindAndReplace.Add("[Burglar_Alarm_Coverage]", objAP_Property_Security.Burglar_Alarm_Coverage_Other_Description);
            htFindAndReplace.Add("[Burglar_Alarm_Coverage_Comment]", objAP_Property_Security.Burglar_Alarm_Coverage_Comments);
            htFindAndReplace.Add("[Guard_Company_Name]", objAP_Property_Security.Guard_Company_Name);
            htFindAndReplace.Add("[Guard_Company_Address1]", objAP_Property_Security.Guard_Company_Address_1);
            htFindAndReplace.Add("[Guard_Company_Address2]", objAP_Property_Security.Guard_Company_Address_2);
            htFindAndReplace.Add("[Guard_Company_City]", objAP_Property_Security.Guard_Company_City);
            if (objAP_Property_Security.FK_Guard_Company_State != null)
            {
                string strFK_Guard_Company_State = new State((decimal)objAP_Property_Security.FK_Guard_Company_State).FLD_state;
                htFindAndReplace.Add("[Guard_Company_State]", strFK_Guard_Company_State);
            }
            else
                htFindAndReplace.Add("[Guard_Company_State]", "");
            htFindAndReplace.Add("[Guard_Company_Zip]", objAP_Property_Security.Guard_Company_Zip);
            htFindAndReplace.Add("[Guard_Company_Contact_Name]", objAP_Property_Security.Guard_Company_Contact_Name);
            htFindAndReplace.Add("[Guard_Company_Contact_Telephone]", objAP_Property_Security.Guard_Comapny_Contact_Telephone);
            htFindAndReplace.Add("[Guard_Company_Contact_EMail]", objAP_Property_Security.Guard_Company_Contact_EMail);
            htFindAndReplace.Add("[Guard_Hours_Monitored_From]", objAP_Property_Security.Guard_Hours_Monitored_From);
            htFindAndReplace.Add("[Guard_Hours_Monitored_To]", objAP_Property_Security.Guard_Hours_Monitored_To);
            htFindAndReplace.Add("[Off_Duty_Officer_Name]", objAP_Property_Security.OffDuty_Officer_Name);
            htFindAndReplace.Add("[Off_Duty_Officer_Telephone]", objAP_Property_Security.OffDuty_Officer_Telephone);
            htFindAndReplace.Add("[Off_Duty_Officer_Hours_Monitored_From]", objAP_Property_Security.OffDuty_Officer_Hours_Monitored_From);
            htFindAndReplace.Add("[Off_Duty_Officer_Hours_Monitored_To]", objAP_Property_Security.OffDuty_Officer_Hours_Monitored_To);
            if (objAP_Property_Security.AC_1st_Floor_Only == "Y")
            {
                htFindAndReplace.Add("[imgACFirstFloorOnly]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACFirstFloorOnly]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Business_Area == "Y")
            {
                htFindAndReplace.Add("[imgACBusinessArea]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACBusinessArea]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Cashier == "Y")
            {
                htFindAndReplace.Add("[imgACCashier]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACCashier]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Computer_Room == "Y")
            {
                htFindAndReplace.Add("[imgACComputer_Room]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACComputer_Room]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Controller_Office == "Y")
            {
                htFindAndReplace.Add("[imgACController_Office]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACController_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_EnterExit_Building == "Y")
            {
                htFindAndReplace.Add("[imgACEnter_Exit_Building]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACEnter_Exit_Building]", ImgUnchecked); }
            if (objAP_Property_Security.AC_F_and_I_Office == "Y")
            {
                htFindAndReplace.Add("[imgACFIOffice]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACFIOffice]", ImgUnchecked); }
            if (objAP_Property_Security.AC_GM_Office == "Y")
            {
                htFindAndReplace.Add("[imgACGM_Office]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACGM_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Multiple_Floors == "Y")
            {
                htFindAndReplace.Add("[imgACMultiple_Floors]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACMultiple_Floors]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Other == "Y")
            {
                htFindAndReplace.Add("[imgACParts]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACParts]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Smart_Sales_Office == "Y")
            {
                htFindAndReplace.Add("[imgACSmart_Safe_Office]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACSmart_Safe_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Other == "Y")
            {
                htFindAndReplace.Add("[imgACOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACOther]", ImgUnchecked); }
            htFindAndReplace.Add("[Access_Control_Other_Description]", objAP_Property_Security.Access_Control_Other_Description);
            if (objAP_Property_Security.FG_EntranceExit_Alarms == "Y")
            {
                htFindAndReplace.Add("[imgFGEnterenceExitAlarms]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFGEnterenceExitAlarms]", ImgUnchecked); }
            if (objAP_Property_Security.FG_EntranceExit_Gate == "Y")
            {
                htFindAndReplace.Add("[imgFGEnterenceExitGate]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFGEnterenceExitGate]", ImgUnchecked); }
            if (objAP_Property_Security.F_Back == "Y")
            {
                htFindAndReplace.Add("[imgFBack]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFBack]", ImgUnchecked); }
            if (objAP_Property_Security.F_Entire_Perimeter == "Y")
            {
                htFindAndReplace.Add("[imgFEntierPerimeter]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFEntierPerimeter]", ImgUnchecked); }
            if (objAP_Property_Security.F_Front == "Y")
            {
                htFindAndReplace.Add("[imgFFront]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFFront]", ImgUnchecked); }
            if (objAP_Property_Security.F_Satellite_Parking_Lot == "Y")
            {
                htFindAndReplace.Add("[imgFSatelliteParkingLot]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFSatelliteParkingLot]", ImgUnchecked); }
            if (objAP_Property_Security.F_Side == "Y")
            {
                htFindAndReplace.Add("[imgFSide]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFSide]", ImgUnchecked); }
            if (objAP_Property_Security.P_Back == "Y")
            {
                htFindAndReplace.Add("[imgPBack]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPBack]", ImgUnchecked); }
            if (objAP_Property_Security.P_Entire_Perimeter == "Y")
            {
                htFindAndReplace.Add("[imgPEntirePerimeter]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPEntirePerimeter]", ImgUnchecked); }
            if (objAP_Property_Security.P_Front == "Y")
            {
                htFindAndReplace.Add("[imgPFront]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPFront]", ImgUnchecked); }
            if (objAP_Property_Security.P_Satellite_Parking_Lot == "Y")
            {
                htFindAndReplace.Add("[imgPSatelliteParkingLot]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPSatelliteParkingLot]", ImgUnchecked); }
            if (objAP_Property_Security.P_Side == "Y")
            {
                htFindAndReplace.Add("[imgPSide]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPSide]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Auto_Tracks == "Y")
            {
                htFindAndReplace.Add("[imgSITSAutoTracks]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgSITSAutoTracks]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Key_Tracks == "Y")
            {
                htFindAndReplace.Add("[imgSITSKeyTracks]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgSITSKeyTracks]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Other == "Y")
            {
                htFindAndReplace.Add("[imgSITSOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgSITSOther]", ImgUnchecked); }

            htFindAndReplace.Add("[Security_Inventory_Tracking_System_Other_Description]", objAP_Property_Security.Security_Inventory_Tracking_System_Other_Description);

            if (objAP_Property_Security.Cap_Index_Crime_Score != null)
                htFindAndReplace.Add("[Cap_Index_Crime_Score]", Convert.ToString(objAP_Property_Security.Cap_Index_Crime_Score));
            else
                htFindAndReplace.Add("[Cap_Index_Crime_Score]", "");
            if (objAP_Property_Security.Cap_Index_Risk_Cateogory != null)
                htFindAndReplace.Add("[Cap_Index_Risk_Category]", new clsLU_AP_Cap_Index_Risk_Category((decimal)objAP_Property_Security.Cap_Index_Risk_Cateogory).Fld_Desc);
            else
                htFindAndReplace.Add("[Cap_Index_Risk_Category]", "");

            htFindAndReplace.Add("[Total_Hours_CCTV_Monitored_Per_Week]", objAP_Property_Security.Total_Hours_CCTV_Monitored_Per_Week);

            DateTime? BeginDate = null;
            DateTime? EndDate = null;
            if (txtBegin_Date.Text.Trim() != "")
            {
                BeginDate = clsGeneral.FormatDateToStore(txtBegin_Date.Text);
            }
            if (txtEndDate.Text.Trim() != "")
            {
                EndDate = clsGeneral.FormatDateToStore(txtEndDate.Text);
            }

            DataSet ds = clsAP_DPD_FROIs.GetAbstractLetter(LocationID, BeginDate, EndDate);

            #region "Location"

            // get datatable for Location
            sbHtml = new System.Text.StringBuilder("");
            GenerateLocationGrid(sbHtml);
            htFindAndReplace.Add("[Location_Grid]", sbHtml.ToString());

            #endregion



            #endregion

            #region "DPD FROIs"

            sbHtml = new System.Text.StringBuilder("");
            // get datatable for DPD records
            DataTable dtDPD = ds.Tables[0];
            GenerateDPDFROI(sbHtml, dtDPD);
            htFindAndReplace.Add("[DPD_Grid]", sbHtml.ToString());
            #endregion

            #region "AL FROIs"

            // get datatable for AL records
            DataTable dtAL = ds.Tables[1];
            sbHtml = new System.Text.StringBuilder("");
            GenerateALFROI(sbHtml, dtAL);
            htFindAndReplace.Add("[AL_Grid]", sbHtml.ToString());

            #endregion

            #region "Cal-Atlantic"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Cal-Atlantic records
            DataTable dtCAL = ds.Tables[2];
            GenerateCALAtlantic(sbHtml, dtCAL);
            htFindAndReplace.Add("[CAL_Grid]", sbHtml.ToString());
            #endregion

            #region "Fraud Events"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Fraud_Event records
            DataTable dtFraud = ds.Tables[3];
            GenerateFraudEvent(sbHtml, dtFraud);
            htFindAndReplace.Add("[Fraud_Grid]", sbHtml.ToString());

            #endregion

            #region "Monitoring Grid"

            DataSet dsMonitoringGrid = clsAP_Property_Security_Monitor_Grids.SelectAllForMonitoringGrid(PK_AP_Property_Security);

            // get datatable for Fraud_Event records
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'CCTV'";
            DataTable dtCCTVMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtCCTVMonitoringGrid);
            htFindAndReplace.Add("[gvCCTVHoursMonitoringGrid]", sbHtml.ToString());


            //Bind Guard Monitoring Grid
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Guard'";
            DataTable dtGuardMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtGuardMonitoringGrid);
            htFindAndReplace.Add("[gvGuardsHoursMonitoringGrid]", sbHtml.ToString());

            //Bidn Off Duty Monitoring Grid
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Off-Duty Officer'";
            DataTable dtOffDutyMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtOffDutyMonitoringGrid);
            htFindAndReplace.Add("[gvOffdutyMonitorGrid]", sbHtml.ToString());

            #endregion

        }

        string strFileName = "Asset Protection Abstract.doc";

        //clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
        clsGeneral.GenerateWordFromFileAndReplaceText(fsMail.Name, strFileName, htFindAndReplace, Response);
    }

    /// <summary>
    ///  kfunction use for generate html output Property Security Report
    /// </summary>
    private void GenerateHTMLForPropertySecurityOLD()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionPropertySecurityAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();

        if (LocationID > 0)
        {

            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";


            clsAP_Property_Security objAP_Property_Security = new clsAP_Property_Security(PK_AP_Property_Security);
            strEbdy = strEbdy.Replace("[CCTV_Company_Name]", objAP_Property_Security.CCTV_Company_Name);
            strEbdy = strEbdy.Replace("[CCTV_Company_Address_1]", objAP_Property_Security.CCTV_Company_Address_1);
            strEbdy = strEbdy.Replace("[CCTV_Company_Address_2]", objAP_Property_Security.CCTV_Company_Address_2);
            strEbdy = strEbdy.Replace("[CCTV_Company_City]", objAP_Property_Security.CCTV_Company_City);
            if (objAP_Property_Security.FK_CCTV_Company_State != null)
            {
                string CompanyState = new State((decimal)objAP_Property_Security.FK_CCTV_Company_State).FLD_state;
                strEbdy = strEbdy.Replace("[CCTV_Company_State]", CompanyState);
            }
            else
                strEbdy = strEbdy.Replace("[CCTV_Company_State]", "");
            strEbdy = strEbdy.Replace("[CCTV_Company_Zip]", objAP_Property_Security.CCTV_Company_Zip);
            strEbdy = strEbdy.Replace("[CCTV_Company_Contact_Name]", objAP_Property_Security.CCTV_Company_Contact_Name);
            strEbdy = strEbdy.Replace("[CCTV_Company_Contact_Telephone]", objAP_Property_Security.CCTV_Comapny_Contact_Telephone);
            strEbdy = strEbdy.Replace("[CCTV_Company_Contact_EMail]", objAP_Property_Security.CCTV_Company_Contact_EMail);
            strEbdy = strEbdy.Replace("[Cal_Atlantic_System]", objAP_Property_Security.Cal_Atlantic_System == "Y" ? "Yes" : "No");
            strEbdy = strEbdy.Replace("[Live_Monitoring]", objAP_Property_Security.Live_Monitoring == "Y" ? "Yes" : "No");
            strEbdy = strEbdy.Replace("[Hours_Monitored_From]", objAP_Property_Security.Hours_Monitored_From);
            strEbdy = strEbdy.Replace("[Hours_Monitored_To]", objAP_Property_Security.Hours_Monitored_To);
            if (objAP_Property_Security.ECC_Back == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccBack]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccBack]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Car_Wash == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccCarWash]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccCarWash]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Front == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccFront]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccFront]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Satellite_Parking == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccSatellite_Parking]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccSatellite_Parking]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Side == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccSide]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccSide]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Zero_Lot_Line == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccZero_Lot_Line]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccZero_Lot_Line]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgEccOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgEccOther]", ImgUnchecked); }
            strEbdy = strEbdy.Replace("[Exterior_Camera_Coverage_Desc]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Exterior_Camera_Coverage_Other_Description));

            if (objAP_Property_Security.ICC_Body_Shop == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccBody_Shop]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccBody_Shop]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Cashier == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccCashier]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccCashier]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Computer_Room == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccComputer_Room]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccComputer_Room]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Detail_Bays == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccDetail_Bays]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccDetail_Bays]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Key_Box_Area == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccKey_Box_Area]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccKey_Box_Area]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Parts_Receiving_Area == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccPart_Receiving_Area]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccPart_Receiving_Area]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Service_Department == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccService_Department]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccService_Department]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Service_Lane == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccService_Lane]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccService_Lane]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Showroom == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccShowroom]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccShowroom]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Smart_Safe_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccSmart_Safe_Office]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccSmart_Safe_Office]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgIccOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgIccOther]", ImgUnchecked); }
            strEbdy = strEbdy.Replace("[Interior_Camera_Coverage_Other_Description]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Interior_Camera_Coverage_Other_Description));

            strEbdy = strEbdy.Replace("[Burglar_Alarm_System]", objAP_Property_Security.Buglar_Alarm_System == "Y" ? "Yes" : "No");
            strEbdy = strEbdy.Replace("[Is_System_Active_Functioning]", objAP_Property_Security.Is_System_Active_and_Function_Properly == "Y" ? "Yes" : "No");
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Name]", objAP_Property_Security.Burglar_Alarm_Company_Name);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Address1]", objAP_Property_Security.Burglar_Alarm_Company_Address_1);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Address2]", objAP_Property_Security.Burglar_Alarm_Company_Address_2);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_City]", objAP_Property_Security.Burglar_Alarm_Company_City);
            if (objAP_Property_Security.FK_Burglar_Alarm_Company_State != null)
            {
                string strFK_Burglar_Alarm_Company_State = new State((decimal)objAP_Property_Security.FK_Burglar_Alarm_Company_State).FLD_state;
                strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_State]", strFK_Burglar_Alarm_Company_State);
            }
            else
                strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_State]", "");

            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Zip]", objAP_Property_Security.Burglar_Alarm_Company_Zip);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Contact_Name]", objAP_Property_Security.Burglar_Alarm_Company_Contact_Name);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Contact_Telephone]", objAP_Property_Security.Burglar_Alarm_Comapny_Contact_Telephone);
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Company_Contact_EMail]", objAP_Property_Security.Burglar_Alarm_Company_Contact_EMail);
            if (objAP_Property_Security.ZD_Collision_Center == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDCollisionCenter]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDCollisionCenter]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDOffice]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDOffice]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Parts == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDParts]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDParts]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDSales_Showroom]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDSales_Showroom]", ImgUnchecked); }

            if (objAP_Property_Security.ZD_Sales == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDService]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDService]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgZDOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgZDOther]", ImgUnchecked); }
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Coverage]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Burglar_Alarm_Coverage_Other_Description));
            strEbdy = strEbdy.Replace("[Burglar_Alarm_Coverage_Comment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Burglar_Alarm_Coverage_Comments));
            strEbdy = strEbdy.Replace("[Guard_Company_Name]", objAP_Property_Security.Guard_Company_Name);
            strEbdy = strEbdy.Replace("[Guard_Company_Address1]", objAP_Property_Security.Guard_Company_Address_1);
            strEbdy = strEbdy.Replace("[Guard_Company_Address2]", objAP_Property_Security.Guard_Company_Address_2);
            strEbdy = strEbdy.Replace("[Guard_Company_City]", objAP_Property_Security.Guard_Company_City);
            if (objAP_Property_Security.FK_Guard_Company_State != null)
            {
                string strFK_Guard_Company_State = new State((decimal)objAP_Property_Security.FK_Guard_Company_State).FLD_state;
                strEbdy = strEbdy.Replace("[Guard_Company_State]", strFK_Guard_Company_State);
            }
            else
                strEbdy = strEbdy.Replace("[Guard_Company_State]", "");
            strEbdy = strEbdy.Replace("[Guard_Company_Zip]", objAP_Property_Security.Guard_Company_Zip);
            strEbdy = strEbdy.Replace("[Guard_Company_Contact_Name]", objAP_Property_Security.Guard_Company_Contact_Name);
            strEbdy = strEbdy.Replace("[Guard_Company_Contact_Telephone]", objAP_Property_Security.Guard_Comapny_Contact_Telephone);
            strEbdy = strEbdy.Replace("[Guard_Company_Contact_EMail]", objAP_Property_Security.Guard_Company_Contact_EMail);
            strEbdy = strEbdy.Replace("[Guard_Hours_Monitored_From]", objAP_Property_Security.Guard_Hours_Monitored_From);
            strEbdy = strEbdy.Replace("[Guard_Hours_Monitored_To]", objAP_Property_Security.Guard_Hours_Monitored_To);
            strEbdy = strEbdy.Replace("[Off_Duty_Officer_Name]", objAP_Property_Security.OffDuty_Officer_Name);
            strEbdy = strEbdy.Replace("[Off_Duty_Officer_Telephone]", objAP_Property_Security.OffDuty_Officer_Telephone);
            strEbdy = strEbdy.Replace("[Off_Duty_Officer_Hours_Monitored_From]", objAP_Property_Security.OffDuty_Officer_Hours_Monitored_From);
            strEbdy = strEbdy.Replace("[Off_Duty_Officer_Hours_Monitored_To]", objAP_Property_Security.OffDuty_Officer_Hours_Monitored_To);
            if (objAP_Property_Security.AC_1st_Floor_Only == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACFirstFloorOnly]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACFirstFloorOnly]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Business_Area == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACBusinessArea]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACBusinessArea]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Cashier == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACCashier]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACCashier]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Computer_Room == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACComputer_Room]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACComputer_Room]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Controller_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACController_Office]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACController_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_EnterExit_Building == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACEnter_Exit_Building]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACEnter_Exit_Building]", ImgUnchecked); }
            if (objAP_Property_Security.AC_F_and_I_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACFIOffice]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACFIOffice]", ImgUnchecked); }
            if (objAP_Property_Security.AC_GM_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACGM_Office]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACGM_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Multiple_Floors == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACMultiple_Floors]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACMultiple_Floors]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACParts]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACParts]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Smart_Sales_Office == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACSmart_Safe_Office]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACSmart_Safe_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgACOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgACOther]", ImgUnchecked); }
            strEbdy = strEbdy.Replace("[Access_Control_Other_Description]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Access_Control_Other_Description));
            if (objAP_Property_Security.FG_EntranceExit_Alarms == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFGEnterenceExitAlarms]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFGEnterenceExitAlarms]", ImgUnchecked); }
            if (objAP_Property_Security.FG_EntranceExit_Gate == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFGEnterenceExitGate]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFGEnterenceExitGate]", ImgUnchecked); }
            if (objAP_Property_Security.F_Back == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFBack]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFBack]", ImgUnchecked); }
            if (objAP_Property_Security.F_Entire_Perimeter == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFEntierPerimeter]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFEntierPerimeter]", ImgUnchecked); }
            if (objAP_Property_Security.F_Front == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFFront]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFFront]", ImgUnchecked); }
            if (objAP_Property_Security.F_Satellite_Parking_Lot == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFSatelliteParkingLot]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFSatelliteParkingLot]", ImgUnchecked); }
            if (objAP_Property_Security.F_Side == "Y")
            {
                strEbdy = strEbdy.Replace("[imgFSide]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgFSide]", ImgUnchecked); }
            if (objAP_Property_Security.P_Back == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPBack]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPBack]", ImgUnchecked); }
            if (objAP_Property_Security.P_Entire_Perimeter == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPEntirePerimeter]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPEntirePerimeter]", ImgUnchecked); }
            if (objAP_Property_Security.P_Front == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPFront]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPFront]", ImgUnchecked); }
            if (objAP_Property_Security.P_Satellite_Parking_Lot == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPSatelliteParkingLot]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPSatelliteParkingLot]", ImgUnchecked); }
            if (objAP_Property_Security.P_Side == "Y")
            {
                strEbdy = strEbdy.Replace("[imgPSide]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgPSide]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Auto_Tracks == "Y")
            {
                strEbdy = strEbdy.Replace("[imgSITSAutoTracks]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgSITSAutoTracks]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Key_Tracks == "Y")
            {
                strEbdy = strEbdy.Replace("[imgSITSKeyTracks]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgSITSKeyTracks]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[imgSITSOther]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[imgSITSOther]", ImgUnchecked); }

            strEbdy = strEbdy.Replace("[Security_Inventory_Tracking_System_Other_Description]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Property_Security.Security_Inventory_Tracking_System_Other_Description));
            if (objAP_Property_Security.Cap_Index_Crime_Score != null)
                strEbdy = strEbdy.Replace("[Cap_Index_Crime_Score]", Convert.ToString(objAP_Property_Security.Cap_Index_Crime_Score));
            else
                strEbdy = strEbdy.Replace("[Cap_Index_Crime_Score]", "");
            if (objAP_Property_Security.Cap_Index_Risk_Cateogory != null)
                strEbdy = strEbdy.Replace("[Cap_Index_Risk_Category]", new clsLU_AP_Cap_Index_Risk_Category((decimal)objAP_Property_Security.Cap_Index_Risk_Cateogory).Fld_Desc);
            else
                strEbdy = strEbdy.Replace("[Cap_Index_Risk_Category]", "");

            DateTime? BeginDate = null;
            DateTime? EndDate = null;
            if (txtBegin_Date.Text.Trim() != "")
            {
                BeginDate = clsGeneral.FormatDateToStore(txtBegin_Date.Text);
            }
            if (txtEndDate.Text.Trim() != "")
            {
                EndDate = clsGeneral.FormatDateToStore(txtEndDate.Text);
            }

            DataSet ds = clsAP_DPD_FROIs.GetAbstractLetter(LocationID, BeginDate, EndDate);

            #region "Location"

            // get datatable for Location
            sbHtml = new System.Text.StringBuilder("");
            GenerateLocationGrid(sbHtml);
            strEbdy = strEbdy.Replace("[Location_Grid]", sbHtml.ToString());

            #endregion

            #region "Monitoring Grid"

            DataSet dsMonitoringGrid = clsAP_Property_Security_Monitor_Grids.SelectAllForMonitoringGrid(PK_AP_Property_Security);

            // get datatable for Fraud_Event records
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'CCTV'";
            DataTable dtCCTVMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtCCTVMonitoringGrid);
            strEbdy = strEbdy.Replace("[gvCCTVHoursMonitoringGrid]", sbHtml.ToString());


            //Bind Guard Monitoring Grid
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Guard'";
            DataTable dtGuardMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtGuardMonitoringGrid);
            strEbdy = strEbdy.Replace("[gvGuardsHoursMonitoringGrid]", sbHtml.ToString());

            //Bidn Off Duty Monitoring Grid
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Off-Duty Officer'";
            DataTable dtOffDutyMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtOffDutyMonitoringGrid);
            strEbdy = strEbdy.Replace("[gvOffdutyMonitorGrid]", sbHtml.ToString());

            #endregion


        }

        string strFileName = "Asset Protection Abstract.doc";

        clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
    }

    private void GenerateHTMLForPropertySecurity()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionPropertySecurityAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        Hashtable htFindAndReplace = new Hashtable();
        if (LocationID > 0)
        {

            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";


            clsAP_Property_Security objAP_Property_Security = new clsAP_Property_Security(PK_AP_Property_Security);
            htFindAndReplace.Add("[CCTV_Company_Name]", objAP_Property_Security.CCTV_Company_Name);
            htFindAndReplace.Add("[CCTV_Company_Address_1]", objAP_Property_Security.CCTV_Company_Address_1);
            htFindAndReplace.Add("[CCTV_Company_Address_2]", objAP_Property_Security.CCTV_Company_Address_2);
            htFindAndReplace.Add("[CCTV_Company_City]", objAP_Property_Security.CCTV_Company_City);
            if (objAP_Property_Security.FK_CCTV_Company_State != null)
            {
                string CompanyState = new State((decimal)objAP_Property_Security.FK_CCTV_Company_State).FLD_state;
                htFindAndReplace.Add("[CCTV_Company_State]", CompanyState);
            }
            else
                htFindAndReplace.Add("[CCTV_Company_State]", "");
            htFindAndReplace.Add("[CCTV_Company_Zip]", objAP_Property_Security.CCTV_Company_Zip);
            htFindAndReplace.Add("[CCTV_Company_Contact_Name]", objAP_Property_Security.CCTV_Company_Contact_Name);
            htFindAndReplace.Add("[CCTV_Company_Contact_Telephone]", objAP_Property_Security.CCTV_Comapny_Contact_Telephone);
            htFindAndReplace.Add("[CCTV_Company_Contact_EMail]", objAP_Property_Security.CCTV_Company_Contact_EMail);
            htFindAndReplace.Add("[Cal_Atlantic_System]", objAP_Property_Security.Cal_Atlantic_System == "Y" ? "Yes" : "No");
            htFindAndReplace.Add("[Live_Monitoring]", objAP_Property_Security.Live_Monitoring == "Y" ? "Yes" : "No");
            htFindAndReplace.Add("[Hours_Monitored_From]", objAP_Property_Security.Hours_Monitored_From);
            htFindAndReplace.Add("[Hours_Monitored_To]", objAP_Property_Security.Hours_Monitored_To);
            if (objAP_Property_Security.ECC_Back == "Y")
            {
                htFindAndReplace.Add("[imgEccBack]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccBack]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Car_Wash == "Y")
            {
                htFindAndReplace.Add("[imgEccCarWash]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccCarWash]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Front == "Y")
            {
                htFindAndReplace.Add("[imgEccFront]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccFront]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Satellite_Parking == "Y")
            {
                htFindAndReplace.Add("[imgEccSatellite_Parking]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccSatellite_Parking]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Side == "Y")
            {
                htFindAndReplace.Add("[imgEccSide]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccSide]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Zero_Lot_Line == "Y")
            {
                htFindAndReplace.Add("[imgEccZero_Lot_Line]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccZero_Lot_Line]", ImgUnchecked); }
            if (objAP_Property_Security.ECC_Other == "Y")
            {
                htFindAndReplace.Add("[imgEccOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgEccOther]", ImgUnchecked); }
            htFindAndReplace.Add("[ECC_Number_Of_External_Cameras]", clsGeneral.FormatCommaSeperatorNumber(objAP_Property_Security.ECC_Number_Of_External_Cameras));
            htFindAndReplace.Add("[Exterior_Camera_Coverage_Desc]", objAP_Property_Security.Exterior_Camera_Coverage_Other_Description);

            if (objAP_Property_Security.ICC_Body_Shop == "Y")
            {
                htFindAndReplace.Add("[imgIccBody_Shop]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccBody_Shop]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Cashier == "Y")
            {
                htFindAndReplace.Add("[imgIccCashier]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccCashier]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Computer_Room == "Y")
            {
                htFindAndReplace.Add("[imgIccComputer_Room]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccComputer_Room]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Detail_Bays == "Y")
            {
                htFindAndReplace.Add("[imgIccDetail_Bays]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccDetail_Bays]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Key_Box_Area == "Y")
            {
                htFindAndReplace.Add("[imgIccKey_Box_Area]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccKey_Box_Area]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Parts_Receiving_Area == "Y")
            {
                htFindAndReplace.Add("[imgIccPart_Receiving_Area]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccPart_Receiving_Area]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Service_Department == "Y")
            {
                htFindAndReplace.Add("[imgIccService_Department]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccService_Department]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Service_Lane == "Y")
            {
                htFindAndReplace.Add("[imgIccService_Lane]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccService_Lane]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Showroom == "Y")
            {
                htFindAndReplace.Add("[imgIccShowroom]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccShowroom]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Smart_Safe_Office == "Y")
            {
                htFindAndReplace.Add("[imgIccSmart_Safe_Office]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccSmart_Safe_Office]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Other == "Y")
            {
                htFindAndReplace.Add("[imgIccOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgIccOther]", ImgUnchecked); }
            htFindAndReplace.Add("[ECC_Number_Of_Internal_Cameras]", clsGeneral.FormatCommaSeperatorNumber(objAP_Property_Security.ECC_Number_Of_Internal_Cameras));
            htFindAndReplace.Add("[Interior_Camera_Coverage_Other_Description]", objAP_Property_Security.Interior_Camera_Coverage_Other_Description);

            htFindAndReplace.Add("[Burglar_Alarm_System]", objAP_Property_Security.Buglar_Alarm_System == "Y" ? "Yes" : "No");
            htFindAndReplace.Add("[Is_System_Active_Functioning]", objAP_Property_Security.Is_System_Active_and_Function_Properly == "Y" ? "Yes" : "No");
            htFindAndReplace.Add("[Burglar_Alarm_Company_Name]", objAP_Property_Security.Burglar_Alarm_Company_Name);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Address1]", objAP_Property_Security.Burglar_Alarm_Company_Address_1);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Address2]", objAP_Property_Security.Burglar_Alarm_Company_Address_2);
            htFindAndReplace.Add("[Burglar_Alarm_Company_City]", objAP_Property_Security.Burglar_Alarm_Company_City);
            if (objAP_Property_Security.FK_Burglar_Alarm_Company_State != null)
            {
                string strFK_Burglar_Alarm_Company_State = new State((decimal)objAP_Property_Security.FK_Burglar_Alarm_Company_State).FLD_state;
                htFindAndReplace.Add("[Burglar_Alarm_Company_State]", strFK_Burglar_Alarm_Company_State);
            }
            else
                htFindAndReplace.Add("[Burglar_Alarm_Company_State]", "");

            htFindAndReplace.Add("[Burglar_Alarm_Company_Zip]", objAP_Property_Security.Burglar_Alarm_Company_Zip);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Contact_Name]", objAP_Property_Security.Burglar_Alarm_Company_Contact_Name);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Contact_Telephone]", objAP_Property_Security.Burglar_Alarm_Comapny_Contact_Telephone);
            htFindAndReplace.Add("[Burglar_Alarm_Company_Contact_EMail]", objAP_Property_Security.Burglar_Alarm_Company_Contact_EMail);
            if (objAP_Property_Security.ZD_Collision_Center == "Y")
            {
                htFindAndReplace.Add("[imgZDCollisionCenter]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDCollisionCenter]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Office == "Y")
            {
                htFindAndReplace.Add("[imgZDOffice]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDOffice]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Parts == "Y")
            {
                htFindAndReplace.Add("[imgZDParts]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDParts]", ImgUnchecked); }
            if (objAP_Property_Security.ICC_Other == "Y")
            {
                htFindAndReplace.Add("[imgZDSales_Showroom]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDSales_Showroom]", ImgUnchecked); }

            if (objAP_Property_Security.ZD_Sales == "Y")
            {
                htFindAndReplace.Add("[imgZDService]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDService]", ImgUnchecked); }
            if (objAP_Property_Security.ZD_Other == "Y")
            {
                htFindAndReplace.Add("[imgZDOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgZDOther]", ImgUnchecked); }
            htFindAndReplace.Add("[Burglar_Alarm_Coverage]", objAP_Property_Security.Burglar_Alarm_Coverage_Other_Description);
            htFindAndReplace.Add("[Burglar_Alarm_Coverage_Comment]", objAP_Property_Security.Burglar_Alarm_Coverage_Comments);
            htFindAndReplace.Add("[Guard_Company_Name]", objAP_Property_Security.Guard_Company_Name);
            htFindAndReplace.Add("[Guard_Company_Address1]", objAP_Property_Security.Guard_Company_Address_1);
            htFindAndReplace.Add("[Guard_Company_Address2]", objAP_Property_Security.Guard_Company_Address_2);
            htFindAndReplace.Add("[Guard_Company_City]", objAP_Property_Security.Guard_Company_City);
            if (objAP_Property_Security.FK_Guard_Company_State != null)
            {
                string strFK_Guard_Company_State = new State((decimal)objAP_Property_Security.FK_Guard_Company_State).FLD_state;
                htFindAndReplace.Add("[Guard_Company_State]", strFK_Guard_Company_State);
            }
            else
                htFindAndReplace.Add("[Guard_Company_State]", "");
            htFindAndReplace.Add("[Guard_Company_Zip]", objAP_Property_Security.Guard_Company_Zip);
            htFindAndReplace.Add("[Guard_Company_Contact_Name]", objAP_Property_Security.Guard_Company_Contact_Name);
            htFindAndReplace.Add("[Guard_Company_Contact_Telephone]", objAP_Property_Security.Guard_Comapny_Contact_Telephone);
            htFindAndReplace.Add("[Guard_Company_Contact_EMail]", objAP_Property_Security.Guard_Company_Contact_EMail);
            htFindAndReplace.Add("[Guard_Hours_Monitored_From]", objAP_Property_Security.Guard_Hours_Monitored_From);
            htFindAndReplace.Add("[Guard_Hours_Monitored_To]", objAP_Property_Security.Guard_Hours_Monitored_To);
            htFindAndReplace.Add("[Off_Duty_Officer_Name]", objAP_Property_Security.OffDuty_Officer_Name);
            htFindAndReplace.Add("[Off_Duty_Officer_Telephone]", objAP_Property_Security.OffDuty_Officer_Telephone);
            htFindAndReplace.Add("[Off_Duty_Officer_Hours_Monitored_From]", objAP_Property_Security.OffDuty_Officer_Hours_Monitored_From);
            htFindAndReplace.Add("[Off_Duty_Officer_Hours_Monitored_To]", objAP_Property_Security.OffDuty_Officer_Hours_Monitored_To);
            if (objAP_Property_Security.AC_1st_Floor_Only == "Y")
            {
                htFindAndReplace.Add("[imgACFirstFloorOnly]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACFirstFloorOnly]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Business_Area == "Y")
            {
                htFindAndReplace.Add("[imgACBusinessArea]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACBusinessArea]", ImgUnchecked); }

            if (objAP_Property_Security.AC_Key_Fobs == "Y")
            {
                htFindAndReplace.Add("[imgAC_Key_Fobs]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgAC_Key_Fobs]", ImgUnchecked); }


            if (objAP_Property_Security.AC_Cashier == "Y")
            {
                htFindAndReplace.Add("[imgACCashier]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACCashier]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Computer_Room == "Y")
            {
                htFindAndReplace.Add("[imgACComputer_Room]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACComputer_Room]", ImgUnchecked); }

            if (objAP_Property_Security.AC_Door_Restrictions == "Y")
            {
                htFindAndReplace.Add("[imgAC_Door_Restrictions]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgAC_Door_Restrictions]", ImgUnchecked); }


            if (objAP_Property_Security.AC_Controller_Office == "Y")
            {
                htFindAndReplace.Add("[imgACController_Office]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACController_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_EnterExit_Building == "Y")
            {
                htFindAndReplace.Add("[imgACEnter_Exit_Building]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACEnter_Exit_Building]", ImgUnchecked); }
            if (objAP_Property_Security.AC_F_and_I_Office == "Y")
            {
                htFindAndReplace.Add("[imgACFIOffice]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACFIOffice]", ImgUnchecked); }
            if (objAP_Property_Security.AC_GM_Office == "Y")
            {
                htFindAndReplace.Add("[imgACGM_Office]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACGM_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Multiple_Floors == "Y")
            {
                htFindAndReplace.Add("[imgACMultiple_Floors]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACMultiple_Floors]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Other == "Y")
            {
                htFindAndReplace.Add("[imgACParts]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACParts]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Smart_Sales_Office == "Y")
            {
                htFindAndReplace.Add("[imgACSmart_Safe_Office]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACSmart_Safe_Office]", ImgUnchecked); }
            if (objAP_Property_Security.AC_Other == "Y")
            {
                htFindAndReplace.Add("[imgACOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgACOther]", ImgUnchecked); }
            htFindAndReplace.Add("[Access_Control_Other_Description]", objAP_Property_Security.Access_Control_Other_Description);
            if (objAP_Property_Security.FG_EntranceExit_Alarms == "Y")
            {
                htFindAndReplace.Add("[imgFGEnterenceExitAlarms]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFGEnterenceExitAlarms]", ImgUnchecked); }
            if (objAP_Property_Security.FG_EntranceExit_Gate == "Y")
            {
                htFindAndReplace.Add("[imgFGEnterenceExitGate]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFGEnterenceExitGate]", ImgUnchecked); }
            if (objAP_Property_Security.F_Back == "Y")
            {
                htFindAndReplace.Add("[imgFBack]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFBack]", ImgUnchecked); }
            if (objAP_Property_Security.F_Entire_Perimeter == "Y")
            {
                htFindAndReplace.Add("[imgFEntierPerimeter]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFEntierPerimeter]", ImgUnchecked); }
            if (objAP_Property_Security.F_Front == "Y")
            {
                htFindAndReplace.Add("[imgFFront]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFFront]", ImgUnchecked); }
            if (objAP_Property_Security.F_Satellite_Parking_Lot == "Y")
            {
                htFindAndReplace.Add("[imgFSatelliteParkingLot]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFSatelliteParkingLot]", ImgUnchecked); }
            if (objAP_Property_Security.F_Side == "Y")
            {
                htFindAndReplace.Add("[imgFSide]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgFSide]", ImgUnchecked); }
            if (objAP_Property_Security.P_Back == "Y")
            {
                htFindAndReplace.Add("[imgPBack]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPBack]", ImgUnchecked); }
            if (objAP_Property_Security.P_Entire_Perimeter == "Y")
            {
                htFindAndReplace.Add("[imgPEntirePerimeter]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPEntirePerimeter]", ImgUnchecked); }
            if (objAP_Property_Security.P_Front == "Y")
            {
                htFindAndReplace.Add("[imgPFront]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPFront]", ImgUnchecked); }
            if (objAP_Property_Security.P_Satellite_Parking_Lot == "Y")
            {
                htFindAndReplace.Add("[imgPSatelliteParkingLot]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPSatelliteParkingLot]", ImgUnchecked); }
            if (objAP_Property_Security.P_Side == "Y")
            {
                htFindAndReplace.Add("[imgPSide]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgPSide]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Auto_Tracks == "Y")
            {
                htFindAndReplace.Add("[imgSITSAutoTracks]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgSITSAutoTracks]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Key_Tracks == "Y")
            {
                htFindAndReplace.Add("[imgSITSKeyTracks]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgSITSKeyTracks]", ImgUnchecked); }
            if (objAP_Property_Security.SITS_Other == "Y")
            {
                htFindAndReplace.Add("[imgSITSOther]", ImgChecked);
            }
            else { htFindAndReplace.Add("[imgSITSOther]", ImgUnchecked); }

            htFindAndReplace.Add("[Security_Inventory_Tracking_System_Other_Description]", objAP_Property_Security.Security_Inventory_Tracking_System_Other_Description);
            if (objAP_Property_Security.Cap_Index_Crime_Score != null)
                htFindAndReplace.Add("[Cap_Index_Crime_Score]", Convert.ToString(objAP_Property_Security.Cap_Index_Crime_Score));
            else
                htFindAndReplace.Add("[Cap_Index_Crime_Score]", "");
            if (objAP_Property_Security.Cap_Index_Risk_Cateogory != null)
                htFindAndReplace.Add("[Cap_Index_Risk_Category]", new clsLU_AP_Cap_Index_Risk_Category((decimal)objAP_Property_Security.Cap_Index_Risk_Cateogory).Fld_Desc);
            else
                htFindAndReplace.Add("[Cap_Index_Risk_Category]", "");
            
            htFindAndReplace.Add("[Total_Hours_CCTV_Monitored_Per_Week]", objAP_Property_Security.Total_Hours_CCTV_Monitored_Per_Week);

            DateTime? BeginDate = null;
            DateTime? EndDate = null;
            if (txtBegin_Date.Text.Trim() != "")
            {
                BeginDate = clsGeneral.FormatDateToStore(txtBegin_Date.Text);
            }
            if (txtEndDate.Text.Trim() != "")
            {
                EndDate = clsGeneral.FormatDateToStore(txtEndDate.Text);
            }

            DataSet ds = clsAP_DPD_FROIs.GetAbstractLetter(LocationID, BeginDate, EndDate);

            #region "Location"

            // get datatable for Location
            sbHtml = new System.Text.StringBuilder("");
            GenerateLocationGrid(sbHtml);
            htFindAndReplace.Add("[Location_Grid]", sbHtml.ToString());

            #endregion

            #region "Financial Grid"

            // get datatable for Location
            sbHtml = new System.Text.StringBuilder("");
            GenerateFinancialGrid(sbHtml);
            htFindAndReplace.Add("[Financial_Grid]", sbHtml.ToString());

            #endregion

            #region "Monitoring Grid"

            DataSet dsMonitoringGrid = clsAP_Property_Security_Monitor_Grids.SelectAllForMonitoringGrid(PK_AP_Property_Security);

            // get datatable for Fraud_Event records
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'CCTV'";
            DataTable dtCCTVMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtCCTVMonitoringGrid);
            htFindAndReplace.Add("[gvCCTVHoursMonitoringGrid]", sbHtml.ToString());


            //Bind Guard Monitoring Grid
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Guard'";
            DataTable dtGuardMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtGuardMonitoringGrid);
            htFindAndReplace.Add("[gvGuardsHoursMonitoringGrid]", sbHtml.ToString());

            //Bidn Off Duty Monitoring Grid
            sbHtml = new System.Text.StringBuilder("");
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Off-Duty Officer'";
            DataTable dtOffDutyMonitoringGrid = dsMonitoringGrid.Tables[0].DefaultView.ToTable();
            GeneratePropertySecurityMonitoringGrid(sbHtml, dtOffDutyMonitoringGrid);
            htFindAndReplace.Add("[gvOffdutyMonitorGrid]", sbHtml.ToString());

            #endregion


        }

        string strFileName = "Asset Protection Abstract.doc";

        //clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
        clsGeneral.GenerateWordFromFileAndReplaceText(fsMail.Name, strFileName, htFindAndReplace, Response);
    }

    /// <summary>
    /// function use for generate html output for report
    /// </summary>
    /// <param name="sbHtml"></param>
    private void GenerateHTMLForDPDOLD()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionDPDAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();

        if (LocationID > 0)
        {

            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";


            DataTable dtDPD_FROIs_Detail = clsAP_DPD_FROIs.GetDPD_FROIs_DetailByPK(PKID, VID, 1).Tables[0];

            if (dtDPD_FROIs_Detail != null && dtDPD_FROIs_Detail.Rows.Count > 0)
            {

                strEbdy = strEbdy.Replace("[Incident_Number]", dtDPD_FROIs_Detail.Rows[0]["DPD_FR_Number"].ToString());
                strEbdy = strEbdy.Replace("[Date_of_Loss]", clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString()));
                strEbdy = strEbdy.Replace("[Time_of_Loss]", dtDPD_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString());
                strEbdy = strEbdy.Replace("[Cause_of_Loss]", Convert.ToString(dtDPD_FROIs_Detail.Rows[0]["Cause_Of_Loss"]));
                strEbdy = strEbdy.Replace("[VIN#]", Convert.ToString(dtDPD_FROIs_Detail.Rows[0]["VIN"].ToString()));
                strEbdy = strEbdy.Replace("[Make]", dtDPD_FROIs_Detail.Rows[0]["Make"].ToString());
                strEbdy = strEbdy.Replace("[Model]", dtDPD_FROIs_Detail.Rows[0]["Model"].ToString());
                strEbdy = strEbdy.Replace("[Year]", dtDPD_FROIs_Detail.Rows[0]["Year"].ToString());
                strEbdy = strEbdy.Replace("[Type_of_Vehicle]", dtDPD_FROIs_Detail.Rows[0]["TypeOfVehicle"].ToString());
                strEbdy = strEbdy.Replace("[Location_of_Vehicle]", dtDPD_FROIs_Detail.Rows[0]["Present_Location"].ToString());
                strEbdy = strEbdy.Replace("[Location_Address]", dtDPD_FROIs_Detail.Rows[0]["Present_Address"].ToString());
                strEbdy = strEbdy.Replace("[Location_State]", dtDPD_FROIs_Detail.Rows[0]["Present_State"].ToString());
                strEbdy = strEbdy.Replace("[Location_Zip]", dtDPD_FROIs_Detail.Rows[0]["Present_Zip"].ToString());
                strEbdy = strEbdy.Replace("[Invoice_Value]", clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Invoice_Value"]));
                strEbdy = strEbdy.Replace("[Loss_Description]", clsGeneral.ReplaceSpaceAndNewLine(dtDPD_FROIs_Detail.Rows[0]["Loss_Description"].ToString()));
                strEbdy = strEbdy.Replace("[Associated_Claim_Number]", dtDPD_FROIs_Detail.Rows[0]["Claim_Number"].ToString());



                if (dtDPD_FROIs_Detail.Rows[0]["Third_Party_Vendor_Related_Theft"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[3rd_Party_Vendor_Related_Theft]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[3rd_Party_Vendor_Related_Theft]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Access_Control_Failures"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Access_Control_Failures]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Access_Control_Failures]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Breaking_And_Entering"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Breaking_and_Entering]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Breaking_and_Entering]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Burglar_Alarm_Failure"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Burglar_Alarm_Failure]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Burglar_Alarm_Failure]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Camera_Dead_Spot"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Camera_Dead_Spot]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Camera_Dead_Spot]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[CCTV_Monitoring_Failure_(Equipment)]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[CCTV_Monitoring_Failure_(Equipment)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure_By_Operator"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[CCTV_Monitoring_Failure_by_Operator]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[CCTV_Monitoring_Failure_by_Operator]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Design_Weakness_Property_Protection"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Design_weakness_Property_Protection]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Design_weakness_Property_Protection]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Environmental_Obstruction_and_or_Condition_Camera"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Environmental_Obstruction/Condition_Camera]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Environmental_Obstruction/Condition_Camera]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Failure_to_Report_and_or_Late_Report"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Failure_to_Report/Late_Report]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Failure_to_Report/Late_Report]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Key_Swap"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Key_Swap]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Key_Swap]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Lighting_Deficiencies"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Lighting_Deficiencies]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Lighting_Deficiencies]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Lock_Box_Not_Properly_Secured"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Lock_Box_Not_Properly_Secured]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Lock_Box_Not_Properly_Secured]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Negligence_Lack_of_key_Control_Program_Unattended_Keys"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Negligence_Lack_of_Key_Control_Program_Unattended_Keys]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Negligence_Lack_of_Key_Control_Program_Unattended_Keys]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Non_Permissible_User_of_Taking_Vehicle"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Non_Permissible_User_of_Taking_Vehicle]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Non_Permissible_User_of_Taking_Vehicle]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Power_Outage"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Power_Outage]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Power_Outage]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Security_Guard_Failure"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Security_Guard_Failure]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Security_Guard_Failure]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Stolen_Id"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Stolen_Id]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Stolen_Id]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Theft_by_Deception"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Theft_by_Deception]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Theft_by_Deception]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Forcible"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Unauthorized_Building_Entry_(Forcible)]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Unauthorized_Building_Entry_(Forcible)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Unlocked"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Unauthorized_Building_Entry_(Unlocked)]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Unauthorized_Building_Entry_(Unlocked)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Forcible"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Unauthorized_Vehicle_Entry_(Forcible)]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Unauthorized_Vehicle_Entry_(Forcible)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Unlocked"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Unauthorized_Vehicle_Entry_(Unlocked)]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Unauthorized_Vehicle_Entry_(Unlocked)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Vehicle_Taken_By_Tow_Truck"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Vehicle_Taken_by_Tow_Truck]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Vehicle_Taken_by_Tow_Truck]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Weather_Related_Damage_and_or_Loss"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Weather_Related_Damage/Loss]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Weather_Related_Damage/Loss]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Other_Describe"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[Other_Describe]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[Other_Describe]", ImgUnchecked); }


                //strEbdy = strEbdy.Replace("[Investigation_Finding_Other_Description]", dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString());
                //string str = dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString().Replace(" ", "&nbsp;").Replace(Environment.NewLine, "<br />");
                strEbdy = strEbdy.Replace("[Investigation_Finding_Other_Description]", clsGeneral.ReplaceSpaceAndNewLine(dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString()));
                strEbdy = strEbdy.Replace("[What_is_the_incident’s_root_cause]", clsGeneral.ReplaceSpaceAndNewLine(dtDPD_FROIs_Detail.Rows[0]["Root_Cause"].ToString()));
                strEbdy = strEbdy.Replace("[How_can_the_incident_be_prevented_from_happening_again]", clsGeneral.ReplaceSpaceAndNewLine(dtDPD_FROIs_Detail.Rows[0]["Incident_Prevention"].ToString()));
                strEbdy = strEbdy.Replace("[Who_has_been_tasked_with_implementing_practices/procedures_to_prevent_re-occurrence]", dtDPD_FROIs_Detail.Rows[0]["Person_Tasked"].ToString());
                strEbdy = strEbdy.Replace("[Target_Date_of_Completion]", clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString()));
                strEbdy = strEbdy.Replace("[Status_Due_On]", clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Status_Due_On"].ToString()));

                strEbdy = strEbdy.Replace("[Comments]", clsGeneral.ReplaceSpaceAndNewLine(dtDPD_FROIs_Detail.Rows[0]["Comments"].ToString()));
                strEbdy = strEbdy.Replace("[Financial_Loss]", clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Financial_Loss"]));
                strEbdy = strEbdy.Replace("[Recovery]", clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Recovery"]));
                strEbdy = strEbdy.Replace("[Item_Status]", dtDPD_FROIs_Detail.Rows[0]["Item_Status"].ToString() == "O" ? "Open" : "Close");
                strEbdy = strEbdy.Replace("[Claim_Number]", clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Claim_Number"]));

                #region "DPD Witness"

                sbHtml = new System.Text.StringBuilder("");

                // get datatable for Fraud_Event records
                DataTable dtWitness = DPD_Witness.SelectByFK(PKID).Tables[0];
                GenerateDPDWitnessGrid(sbHtml, dtWitness);
                strEbdy = strEbdy.Replace("[Witnesses]", sbHtml.ToString());

                #endregion

            }
        }

        string strFileName = "Asset Protection Abstract.doc";

        clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
    }
    private void GenerateHTMLForDPD()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionDPDAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        Hashtable htFindAndReplace = new Hashtable();
        if (LocationID > 0)
        {

            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";


            DataTable dtDPD_FROIs_Detail = clsAP_DPD_FROIs.GetDPD_FROIs_DetailByPK(PKID, VID, 1).Tables[0];

            if (dtDPD_FROIs_Detail != null && dtDPD_FROIs_Detail.Rows.Count > 0)
            {
                htFindAndReplace.Add("[Incident_Number]", dtDPD_FROIs_Detail.Rows[0]["DPD_FR_Number"].ToString());
                htFindAndReplace.Add("[Date_of_Loss]", clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString()));
                htFindAndReplace.Add("[Time_of_Loss]", dtDPD_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString());
                htFindAndReplace.Add("[Cause_of_Loss]", Convert.ToString(dtDPD_FROIs_Detail.Rows[0]["Cause_Of_Loss"]));
                htFindAndReplace.Add("[VIN#]", Convert.ToString(dtDPD_FROIs_Detail.Rows[0]["VIN"].ToString()));
                htFindAndReplace.Add("[Make]", dtDPD_FROIs_Detail.Rows[0]["Make"].ToString());
                htFindAndReplace.Add("[Model]", dtDPD_FROIs_Detail.Rows[0]["Model"].ToString());
                htFindAndReplace.Add("[Year]", dtDPD_FROIs_Detail.Rows[0]["Year"].ToString());
                htFindAndReplace.Add("[Type_of_Vehicle]", dtDPD_FROIs_Detail.Rows[0]["TypeOfVehicle"].ToString());
                htFindAndReplace.Add("[Location_of_Vehicle]", dtDPD_FROIs_Detail.Rows[0]["Present_Location"].ToString());
                htFindAndReplace.Add("[Location_Address]", dtDPD_FROIs_Detail.Rows[0]["Present_Address"].ToString());
                htFindAndReplace.Add("[Location_State]", dtDPD_FROIs_Detail.Rows[0]["Present_State"].ToString());
                htFindAndReplace.Add("[Location_Zip]", dtDPD_FROIs_Detail.Rows[0]["Present_Zip"].ToString());
                htFindAndReplace.Add("[Invoice_Value]", clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Invoice_Value"]));
                htFindAndReplace.Add("[Loss_Description]", dtDPD_FROIs_Detail.Rows[0]["Loss_Description"].ToString());
                htFindAndReplace.Add("[Associated_Claim_Number]", dtDPD_FROIs_Detail.Rows[0]["Origin_Claim_Number"].ToString());
                htFindAndReplace.Add("[Vehicle_Color]", dtDPD_FROIs_Detail.Rows[0]["Vehicle_Color"].ToString());
                htFindAndReplace.Add("[Police_Case_Number]", dtDPD_FROIs_Detail.Rows[0]["Police_Case_Number"].ToString());
                htFindAndReplace.Add("[Investigating_Police_Department]", dtDPD_FROIs_Detail.Rows[0]["Investigating_Police_Department"].ToString().Trim());


                if (dtDPD_FROIs_Detail.Rows[0]["Vandalism"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Vandalism]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Vandalism]", ImgUnchecked); }


                if (dtDPD_FROIs_Detail.Rows[0]["Third_Party_Vendor_Related_Theft"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[3rd_Party_Vendor_Related_Theft]", ImgChecked);
                }
                else { htFindAndReplace.Add("[3rd_Party_Vendor_Related_Theft]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Access_Control_Failures"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Access_Control_Failures]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Access_Control_Failures]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Breaking_And_Entering"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Breaking_and_Entering]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Breaking_and_Entering]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Burglar_Alarm_Failure"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Burglar_Alarm_Failure]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Burglar_Alarm_Failure]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Camera_Dead_Spot"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Camera_Dead_Spot]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Camera_Dead_Spot]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[CCTV_Monitoring_Failure_(Equipment)]", ImgChecked);
                }
                else { htFindAndReplace.Add("[CCTV_Monitoring_Failure_(Equipment)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure_By_Operator"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[CCTV_Monitoring_Failure_by_Operator]", ImgChecked);
                }
                else { htFindAndReplace.Add("[CCTV_Monitoring_Failure_by_Operator]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Design_Weakness_Property_Protection"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Design_weakness_Property_Protection]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Design_weakness_Property_Protection]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Environmental_Obstruction_and_or_Condition_Camera"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Environmental_Obstruction/Condition_Camera]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Environmental_Obstruction/Condition_Camera]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Failure_to_Report_and_or_Late_Report"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Failure_to_Report/Late_Report]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Failure_to_Report/Late_Report]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Key_Swap"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Key_Swap]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Key_Swap]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Lighting_Deficiencies"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Lighting_Deficiencies]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Lighting_Deficiencies]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Lock_Box_Not_Properly_Secured"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Lock_Box_Not_Properly_Secured]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Lock_Box_Not_Properly_Secured]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Negligence_Lack_of_key_Control_Program_Unattended_Keys"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Negligence_Lack_of_Key_Control_Program_Unattended_Keys]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Negligence_Lack_of_Key_Control_Program_Unattended_Keys]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Non_Permissible_User_of_Taking_Vehicle"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Non_Permissible_User_of_Taking_Vehicle]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Non_Permissible_User_of_Taking_Vehicle]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Power_Outage"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Power_Outage]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Power_Outage]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Security_Guard_Failure"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Security_Guard_Failure]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Security_Guard_Failure]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Stolen_Id"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Stolen_Id]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Stolen_Id]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Theft_by_Deception"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Theft_by_Deception]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Theft_by_Deception]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Forcible"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Unauthorized_Building_Entry_(Forcible)]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Unauthorized_Building_Entry_(Forcible)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Unlocked"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Unauthorized_Building_Entry_(Unlocked)]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Unauthorized_Building_Entry_(Unlocked)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Forcible"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Unauthorized_Vehicle_Entry_(Forcible)]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Unauthorized_Vehicle_Entry_(Forcible)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Unlocked"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Unauthorized_Vehicle_Entry_(Unlocked)]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Unauthorized_Vehicle_Entry_(Unlocked)]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Vehicle_Taken_By_Tow_Truck"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Vehicle_Taken_by_Tow_Truck]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Vehicle_Taken_by_Tow_Truck]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Weather_Related_Damage_and_or_Loss"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Weather_Related_Damage/Loss]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Weather_Related_Damage/Loss]", ImgUnchecked); }

                if (dtDPD_FROIs_Detail.Rows[0]["Other_Describe"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[Other_Describe]", ImgChecked);
                }
                else { htFindAndReplace.Add("[Other_Describe]", ImgUnchecked); }


                //htFindAndReplace.Add("[Investigation_Finding_Other_Description]", dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString());
                //string str = dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString().Replace(" ", "&nbsp;").Replace(Environment.NewLine, "<br />");
                htFindAndReplace.Add("[Investigation_Finding_Other_Description]", dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString());
                htFindAndReplace.Add("[What_is_the_incident’s_root_cause]", dtDPD_FROIs_Detail.Rows[0]["Root_Cause"].ToString());
                htFindAndReplace.Add("[How_can_the_incident_be_prevented_from_happening_again]", dtDPD_FROIs_Detail.Rows[0]["Incident_Prevention"].ToString());
                htFindAndReplace.Add("[Who_has_been_tasked_with_implementing_practices/procedures_to_prevent_re-occurrence]", dtDPD_FROIs_Detail.Rows[0]["Person_Tasked"].ToString());
                htFindAndReplace.Add("[Target_Date_of_Completion]", clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString()));
                htFindAndReplace.Add("[Status_Due_On]", clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Status_Due_On"].ToString()));

                htFindAndReplace.Add("[Comments]", dtDPD_FROIs_Detail.Rows[0]["Comments"].ToString());
                htFindAndReplace.Add("[Financial_Loss]", clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Financial_Loss"]));
                htFindAndReplace.Add("[Recovery]", clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Recovery"]));
                htFindAndReplace.Add("[Item_Status]", dtDPD_FROIs_Detail.Rows[0]["Item_Status"].ToString() == "O" ? "Open" : "Close");
                htFindAndReplace.Add("[Claim_Number]", clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Origin_Claim_Number"]));

                #region "DPD Witness"

                sbHtml = new System.Text.StringBuilder("");

                // get datatable for Fraud_Event records
                DataTable dtWitness = DPD_Witness.SelectByFK(PKID).Tables[0];
                GenerateDPDWitnessGrid(sbHtml, dtWitness);
                htFindAndReplace.Add("[Witnesses]", sbHtml.ToString());

                #endregion

            }
        }


        string strFileName = "Asset Protection Abstract.doc";

        //clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
        clsGeneral.GenerateWordFromFileAndReplaceText(fsMail.Name, strFileName, htFindAndReplace, Response);
    }

    /// <summary>
    /// function use for generate html output AL Report
    /// </summary>
    /// <param name="sbHtml"></param>
    private void GenerateHTMLForALOLD()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionALAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();

        if (PKID > 0)
        {
            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";

            DataTable dtAL_FROIs_Detail = clsAP_AL_FROIs.GetAL_FROIs_DetailByPK(PKID).Tables[0];
            if (dtAL_FROIs_Detail != null && dtAL_FROIs_Detail.Rows.Count > 0)
            {
                #region "Incident Information"
                strEbdy = strEbdy.Replace("[lblAL_Incident_NumberView]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["AL_FR_Number"]));
                strEbdy = strEbdy.Replace("[lblAL_Date_of_Loss]", clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString()));
                strEbdy = strEbdy.Replace("[lblAL_Time_of_Loss]", dtAL_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString());
                strEbdy = strEbdy.Replace("[lblDescription_Of_Loss]", clsGeneral.ReplaceSpaceAndNewLine(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Description_Of_Loss"])));

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Loss_offsite"])))
                    strEbdy = strEbdy.Replace("[Incident_Occurred]", (Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Loss_offsite"])) ? "OffSite" : "OnSite");
                else
                    strEbdy = strEbdy.Replace("[Incident_Occurred]", "");


                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Were_Police_Notified"])))
                    strEbdy = strEbdy.Replace("[rdbAL_WerePoliceNotifiedView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Were_Police_Notified"]) ? "Yes" : "No");
                else
                    strEbdy = strEbdy.Replace("[rdbAL_WerePoliceNotifiedView]", "");

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Pedestrian_Involved"])))
                    strEbdy = strEbdy.Replace("[rdbAL_WerePedestriansInvolvedView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Pedestrian_Involved"]) ? "Yes" : "No");
                else
                    strEbdy = strEbdy.Replace("[rdbAL_WerePedestriansInvolvedView]", "");

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Property_Damage"])))
                    strEbdy = strEbdy.Replace("[rdbAL_propertydamageView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Property_Damage"]) ? "Yes" : "No");
                else
                    strEbdy = strEbdy.Replace("[rdbAL_propertydamageView]", "");

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Witnesses"])))
                    strEbdy = strEbdy.Replace("[rdbAL_WitnessesView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Witnesses"]) ? "Yes" : "No");
                else
                    strEbdy = strEbdy.Replace("[rdbAL_WitnessesView]", "");

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Security_Video_System"])))
                    strEbdy = strEbdy.Replace("[rdbAL_SecurityVideoView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Security_Video_System"]) ? "Yes" : "No");
                else
                    strEbdy = strEbdy.Replace("[rdbAL_SecurityVideoView]", "");

                strEbdy = strEbdy.Replace("[lblWeatherConditions]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Weather_Conditions"]));
                strEbdy = strEbdy.Replace("[lblRoadConditions]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Road_Conditions"]));
                strEbdy = strEbdy.Replace("[lblALClaim_NumberView]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Origin_Claim_Number"]));

                #endregion

                #region "Investigation"

                if (dtAL_FROIs_Detail.Rows[0]["Third_Party_Vendor_Related_Theft"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_3rd_Party_Vendor_Related_TheftView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_3rd_Party_Vendor_Related_TheftView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Access_Control_Failures"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Access_Control_FailuresView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Access_Control_FailuresView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Breaking_And_Entering"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Breaking_and_EnteringView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Breaking_and_EnteringView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Burglar_Alarm_Failure"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Burglar_Alarm_FailureView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Burglar_Alarm_FailureView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Camera_Dead_Spot"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Camera_Dead_SpotView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Camera_Dead_SpotView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_CCTV_Monitoring_FailureView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_CCTV_Monitoring_FailureView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure_By_Operator"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_CCTV_Monitoring_Failure_byOperatorView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_CCTV_Monitoring_Failure_byOperatorView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Design_Weakness_Property_Protection"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Design_weakness_Property_ProtectionView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Design_weakness_Property_ProtectionView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Environmental_Obstruction_and_or_Condition_Camera"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Environmental_Obstruction_ConditionCameraView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Environmental_Obstruction_ConditionCameraView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Failure_to_Report_and_or_Late_Report"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Failure_to_ReportLate_ReportView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Failure_to_ReportLate_ReportView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Key_Swap"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Key_SwapView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Key_SwapView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Lighting_Deficiencies"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Lighting_DeficienciesView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Lighting_DeficienciesView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Lock_Box_Not_Properly_Secured"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_LockBox_Not_Properly_SecuredView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_LockBox_Not_Properly_SecuredView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Negligence_Lack_of_key_Control_Program_Unattended_Keys"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Negligence_Lackof_Key_Control_Program_Unattended_KeysView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Negligence_Lackof_Key_Control_Program_Unattended_KeysView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Non_Permissible_User_of_Taking_Vehicle"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_NonPermissible_User_of_TakingVehicleView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_NonPermissible_User_of_TakingVehicleView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Power_Outage"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Power_OutageView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Power_OutageView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Security_Guard_Failure"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Security_Guard_FailureView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Security_Guard_FailureView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Stolen_Id"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Stolen_IdView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Stolen_IdView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Theft_By_Deception"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Theft_by_DeceptionView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Theft_by_DeceptionView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Forcible"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Unauthorized_Building_Entry_ForcibleView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Unauthorized_Building_Entry_ForcibleView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Unlocked"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Unauthorized_Building_Entry_UnlockedView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Unauthorized_Building_Entry_UnlockedView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Forcible"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Unauthorized_Vehicle_Entry_ForcibleView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Unauthorized_Vehicle_Entry_ForcibleView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Unlocked"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Unauthorized_Vehicle_Entry_UnlockedView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Unauthorized_Vehicle_Entry_UnlockedView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Vehicle_Taken_By_Tow_Truck"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Vehicle_Takenby_Tow_TruckView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Vehicle_Takenby_Tow_TruckView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Weather_Related_Damage_and_or_Loss"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Weather_Related_DamageLossView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Weather_Related_DamageLossView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Other_Describe"].ToString() == "Y")
                {
                    strEbdy = strEbdy.Replace("[chkAL_Other_DescribeView]", ImgChecked);
                }
                else { strEbdy = strEbdy.Replace("[chkAL_Other_DescribeView]", ImgUnchecked); }

                strEbdy = strEbdy.Replace("[lblAL_Investigation_Finding]", clsGeneral.ReplaceSpaceAndNewLine(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"])));

                #endregion

                #region "FROI Review"

                strEbdy = strEbdy.Replace("[lblAL_Root_Cause]", clsGeneral.ReplaceSpaceAndNewLine(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Root_Cause"])));
                strEbdy = strEbdy.Replace("[lblAL_Incident_Prevention]", clsGeneral.ReplaceSpaceAndNewLine(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Incident_Prevention"])));
                strEbdy = strEbdy.Replace("[lblAL_Person_Tasked]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Person_Tasked"]));
                strEbdy = strEbdy.Replace("[lblAL_Target_Date_of_Completion]", clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString()));
                strEbdy = strEbdy.Replace("[lblAL_Status_Due_On]", clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Status_Due_On"].ToString()));
                strEbdy = strEbdy.Replace("[lblAL_Comments]", clsGeneral.ReplaceSpaceAndNewLine(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Comments"])));
                strEbdy = strEbdy.Replace("[lblAL_Financial_Loss]", clsGeneral.GetStringValue(dtAL_FROIs_Detail.Rows[0]["Financial_Loss"]));
                strEbdy = strEbdy.Replace("[lblAL_Recovery]", clsGeneral.GetStringValue(dtAL_FROIs_Detail.Rows[0]["Recovery"]));

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Item_Status"])))
                    strEbdy = strEbdy.Replace("[lblAL_Item_Status]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Item_Status"]) == "O" ? "Open" : "Closed");
                else
                    strEbdy = strEbdy.Replace("[lblAL_Item_Status]", "");


                #endregion

                #region "AL Witness"

                sbHtml = new System.Text.StringBuilder("");

                // get datatable for Fraud_Event records
                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Witnesses"])))
                {
                    if ((Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Witnesses"])) == true)
                    {
                        GenerateALWitnessGrid(sbHtml, dtAL_FROIs_Detail);
                        strEbdy = strEbdy.Replace("[gvAL_WitnessesView]", sbHtml.ToString());
                    }
                    else
                    {
                        strEbdy = strEbdy.Replace("[gvAL_WitnessesView]", sbHtml.ToString());
                    }
                }
                else
                {
                    strEbdy = strEbdy.Replace("[gvAL_WitnessesView]", sbHtml.ToString());
                }


                #endregion
            }
            string strFileName = "Asset Protection Abstract.doc";

            clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);

        }
    }
    private void GenerateHTMLForAL()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionALAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        Hashtable htFindAndReplace = new Hashtable();
        if (PKID > 0)
        {
            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";

            DataTable dtAL_FROIs_Detail = clsAP_AL_FROIs.GetAL_FROIs_DetailByPK(PKID).Tables[0];
            if (dtAL_FROIs_Detail != null && dtAL_FROIs_Detail.Rows.Count > 0)
            {
                #region "Incident Information"
                htFindAndReplace.Add("[lblAL_Incident_NumberView]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["AL_FR_Number"]));
                htFindAndReplace.Add("[lblAL_Date_of_Loss]", clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString()));
                htFindAndReplace.Add("[lblAL_Time_of_Loss]", dtAL_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString());
                htFindAndReplace.Add("[lblDescription_Of_Loss]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Description_Of_Loss"]));

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Loss_offsite"])))
                    htFindAndReplace.Add("[Incident_Occurred]", (Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Loss_offsite"])) ? "OffSite" : "OnSite");
                else
                    htFindAndReplace.Add("[Incident_Occurred]", "");


                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Were_Police_Notified"])))
                    htFindAndReplace.Add("[rdbAL_WerePoliceNotifiedView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Were_Police_Notified"]) ? "Yes" : "No");
                else
                    htFindAndReplace.Add("[rdbAL_WerePoliceNotifiedView]", "");

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Pedestrian_Involved"])))
                    htFindAndReplace.Add("[rdbAL_WerePedestriansInvolvedView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Pedestrian_Involved"]) ? "Yes" : "No");
                else
                    htFindAndReplace.Add("[rdbAL_WerePedestriansInvolvedView]", "");

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Property_Damage"])))
                    htFindAndReplace.Add("[rdbAL_propertydamageView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Property_Damage"]) ? "Yes" : "No");
                else
                    htFindAndReplace.Add("[rdbAL_propertydamageView]", "");

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Witnesses"])))
                    htFindAndReplace.Add("[rdbAL_WitnessesView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Witnesses"]) ? "Yes" : "No");
                else
                    htFindAndReplace.Add("[rdbAL_WitnessesView]", "");

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Security_Video_System"])))
                    htFindAndReplace.Add("[rdbAL_SecurityVideoView]", Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Security_Video_System"]) ? "Yes" : "No");
                else
                    htFindAndReplace.Add("[rdbAL_SecurityVideoView]", "");

                htFindAndReplace.Add("[lblWeatherConditions]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Weather_Conditions"]));
                htFindAndReplace.Add("[lblRoadConditions]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Road_Conditions"]));
                htFindAndReplace.Add("[lblALClaim_NumberView]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Origin_Claim_Number"]));

                #endregion

                #region "Investigation"

                if (dtAL_FROIs_Detail.Rows[0]["Third_Party_Vendor_Related_Theft"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_3rd_Party_Vendor_Related_TheftView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_3rd_Party_Vendor_Related_TheftView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Access_Control_Failures"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Access_Control_FailuresView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Access_Control_FailuresView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Breaking_And_Entering"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Breaking_and_EnteringView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Breaking_and_EnteringView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Burglar_Alarm_Failure"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Burglar_Alarm_FailureView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Burglar_Alarm_FailureView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Camera_Dead_Spot"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Camera_Dead_SpotView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Camera_Dead_SpotView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_CCTV_Monitoring_FailureView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_CCTV_Monitoring_FailureView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure_By_Operator"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_CCTV_Monitoring_Failure_byOperatorView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_CCTV_Monitoring_Failure_byOperatorView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Design_Weakness_Property_Protection"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Design_weakness_Property_ProtectionView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Design_weakness_Property_ProtectionView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Environmental_Obstruction_and_or_Condition_Camera"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Environmental_Obstruction_ConditionCameraView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Environmental_Obstruction_ConditionCameraView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Failure_to_Report_and_or_Late_Report"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Failure_to_ReportLate_ReportView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Failure_to_ReportLate_ReportView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Key_Swap"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Key_SwapView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Key_SwapView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Lighting_Deficiencies"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Lighting_DeficienciesView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Lighting_DeficienciesView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Lock_Box_Not_Properly_Secured"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_LockBox_Not_Properly_SecuredView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_LockBox_Not_Properly_SecuredView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Negligence_Lack_of_key_Control_Program_Unattended_Keys"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Negligence_Lackof_Key_Control_Program_Unattended_KeysView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Negligence_Lackof_Key_Control_Program_Unattended_KeysView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Non_Permissible_User_of_Taking_Vehicle"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_NonPermissible_User_of_TakingVehicleView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_NonPermissible_User_of_TakingVehicleView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Power_Outage"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Power_OutageView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Power_OutageView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Security_Guard_Failure"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Security_Guard_FailureView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Security_Guard_FailureView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Stolen_Id"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Stolen_IdView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Stolen_IdView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Theft_By_Deception"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Theft_by_DeceptionView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Theft_by_DeceptionView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Forcible"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Unauthorized_Building_Entry_ForcibleView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Unauthorized_Building_Entry_ForcibleView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Unlocked"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Unauthorized_Building_Entry_UnlockedView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Unauthorized_Building_Entry_UnlockedView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Forcible"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Unauthorized_Vehicle_Entry_ForcibleView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Unauthorized_Vehicle_Entry_ForcibleView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Unlocked"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Unauthorized_Vehicle_Entry_UnlockedView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Unauthorized_Vehicle_Entry_UnlockedView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Vehicle_Taken_By_Tow_Truck"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Vehicle_Takenby_Tow_TruckView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Vehicle_Takenby_Tow_TruckView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Weather_Related_Damage_and_or_Loss"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Weather_Related_DamageLossView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Weather_Related_DamageLossView]", ImgUnchecked); }

                if (dtAL_FROIs_Detail.Rows[0]["Other_Describe"].ToString() == "Y")
                {
                    htFindAndReplace.Add("[chkAL_Other_DescribeView]", ImgChecked);
                }
                else { htFindAndReplace.Add("[chkAL_Other_DescribeView]", ImgUnchecked); }

                htFindAndReplace.Add("[lblAL_Investigation_Finding]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"]));

                #endregion

                #region "FROI Review"

                htFindAndReplace.Add("[lblAL_Root_Cause]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Root_Cause"]));
                htFindAndReplace.Add("[lblAL_Incident_Prevention]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Incident_Prevention"]));
                htFindAndReplace.Add("[lblAL_Person_Tasked]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Person_Tasked"]));
                htFindAndReplace.Add("[lblAL_Target_Date_of_Completion]", clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString()));
                htFindAndReplace.Add("[lblAL_Status_Due_On]", clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Status_Due_On"].ToString()));
                htFindAndReplace.Add("[lblAL_Comments]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Comments"]));
                htFindAndReplace.Add("[lblAL_Financial_Loss]", clsGeneral.GetStringValue(dtAL_FROIs_Detail.Rows[0]["Financial_Loss"]));
                htFindAndReplace.Add("[lblAL_Recovery]", clsGeneral.GetStringValue(dtAL_FROIs_Detail.Rows[0]["Recovery"]));

                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Item_Status"])))
                    htFindAndReplace.Add("[lblAL_Item_Status]", Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Item_Status"]) == "O" ? "Open" : "Closed");
                else
                    htFindAndReplace.Add("[lblAL_Item_Status]", "");


                #endregion

                #region "AL Witness"

                sbHtml = new System.Text.StringBuilder("");

                // get datatable for Fraud_Event records
                if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Witnesses"])))
                {
                    if ((Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Witnesses"])) == true)
                    {
                        GenerateALWitnessGrid(sbHtml, dtAL_FROIs_Detail);
                        htFindAndReplace.Add("[gvAL_WitnessesView]", sbHtml.ToString());
                    }
                    else
                    {
                        htFindAndReplace.Add("[gvAL_WitnessesView]", sbHtml.ToString());
                    }
                }
                else
                {
                    htFindAndReplace.Add("[gvAL_WitnessesView]", sbHtml.ToString());
                }


                #endregion
            }
            string strFileName = "Asset Protection Abstract.doc";

            //clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
            clsGeneral.GenerateWordFromFileAndReplaceText(fsMail.Name, strFileName, htFindAndReplace, Response);
        }
    }

    /// <summary>
    /// function use for generate html output Cal-Atlantic Report
    /// </summary>
    /// <param name="sbHtml"></param>
    private void GenerateHTMLForCalAtlanticOLD()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionCalAtlanticAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();

        if (PKID > 0)
        {
            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";

            clsAP_Cal_Atlantic objAP_Cal_Atlantic = new clsAP_Cal_Atlantic(PKID);

            DataTable dtEvent = clsAP_Cal_Atlantic.SelectAP_CalAtlanticPKByFKEvent(Convert.ToDecimal(objAP_Cal_Atlantic.FK_Event)).Tables[0];
            strEbdy = strEbdy.Replace("[lblDateOfEvent]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString()));
            strEbdy = strEbdy.Replace("[lblTimeOfEvent]", "");
            strEbdy = strEbdy.Replace("[lblTypeOfEvent]", new clsLU_Event_Type(Convert.ToDecimal(dtEvent.Rows[0]["FK_LU_Event_Type"].ToString())).Fld_Desc);
            strEbdy = strEbdy.Replace("[lblEventReportDate]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Report_Date"].ToString()));
            strEbdy = strEbdy.Replace("[lblInvestigationReportDate]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Investigation_Report_Date"].ToString()));
            strEbdy = strEbdy.Replace("[lblDateOfEvent]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString()));

            if (dtEvent.Rows[0]["FK_LU_Event_Description"] != null && Convert.ToString(dtEvent.Rows[0]["FK_LU_Event_Description"]) != "")
                strEbdy = strEbdy.Replace("[lblFK_LU_Event_Description]", new clsLU_Event_Description((decimal)dtEvent.Rows[0]["FK_LU_Event_Description"]).Fld_Desc);
            else
                strEbdy = strEbdy.Replace("[lblFK_LU_Event_Description]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString()));

            strEbdy = strEbdy.Replace("[lblDate_Opened]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Opened"].ToString()));
            strEbdy = strEbdy.Replace("[lblDateSendToClient]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Sent"].ToString()));
            strEbdy = strEbdy.Replace("[lblEventOccuranceDate]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString()));

            strEbdy = strEbdy.Replace("[lblPotential_Risk]", objAP_Cal_Atlantic.Potential_Risk);
            strEbdy = strEbdy.Replace("[lblAction_Taken]", objAP_Cal_Atlantic.Action_Taken);
            if (objAP_Cal_Atlantic.Was_Law_Enforcement_Notified != null)
                strEbdy = strEbdy.Replace("[lblWas_Law_Enforcement_Notified]", objAP_Cal_Atlantic.Was_Law_Enforcement_Notified == "Y" ? "Yes" : "No");
            else
                strEbdy = strEbdy.Replace("[lblWas_Law_Enforcement_Notified]", "");
            strEbdy = strEbdy.Replace("[lblOfficer_Name]", objAP_Cal_Atlantic.Officer_Name);
            strEbdy = strEbdy.Replace("[lblPhone_Number]", objAP_Cal_Atlantic.Phone_Number);
            strEbdy = strEbdy.Replace("[lblEMail]", objAP_Cal_Atlantic.EMail);
            strEbdy = strEbdy.Replace("[lblLaw_Enforcement_Agency]", objAP_Cal_Atlantic.Law_Enforcement_Agency);
            strEbdy = strEbdy.Replace("[lblLocation]", objAP_Cal_Atlantic.Location);
            strEbdy = strEbdy.Replace("[lblPolice_Report_Number]", objAP_Cal_Atlantic.Police_Report_Number);
            strEbdy = strEbdy.Replace("[lblNotes]", objAP_Cal_Atlantic.Notes);
            strEbdy = strEbdy.Replace("[lblRoot_Cause]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Cal_Atlantic.Root_Cause));
            strEbdy = strEbdy.Replace("[lblEvent_Prevention]", objAP_Cal_Atlantic.Event_Prevention);
            strEbdy = strEbdy.Replace("[lblTask_Prevent_Reoccurance]", objAP_Cal_Atlantic.Person_Tasked);
            strEbdy = strEbdy.Replace("[lblCal_Target_Date_of_Completion]", clsGeneral.FormatDBNullDateToDisplay(objAP_Cal_Atlantic.Target_Date_of_Completion));
            strEbdy = strEbdy.Replace("[lblCal_Status_Due_On]", clsGeneral.FormatDBNullDateToDisplay(objAP_Cal_Atlantic.Status_Due_On));
            strEbdy = strEbdy.Replace("[lblComments]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Cal_Atlantic.Comments));
            strEbdy = strEbdy.Replace("[lblCal_Financial_Loss]", clsGeneral.GetStringValue(objAP_Cal_Atlantic.Financial_Loss));
            strEbdy = strEbdy.Replace("[lblCal_Recovery]", clsGeneral.GetStringValue(objAP_Cal_Atlantic.Recovery));
            if (objAP_Cal_Atlantic.Item_Status != null)
                strEbdy = strEbdy.Replace("[lblCal_Item_Status]", objAP_Cal_Atlantic.Item_Status == "O" ? "Open" : "Closed");
            else
                strEbdy = strEbdy.Replace("[lblCal_Item_Status]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Cal_Atlantic.Comments));

            strEbdy = strEbdy.Replace("[lblAssociatedFROINo]", objAP_Cal_Atlantic.Associated_FROI_Number);
            strEbdy = strEbdy.Replace("[lblAssocaitedClaimNo]", objAP_Cal_Atlantic.Associated_Claim_Number);



            if (objAP_Cal_Atlantic.Auto_Liability == "Y")
            {
                strEbdy = strEbdy.Replace("[rblInsuranceClaimTypeView]", "Auto Liability");
            }
            else if (objAP_Cal_Atlantic.DPD == "Y")
            {
                strEbdy = strEbdy.Replace("[rblInsuranceClaimTypeView]", "DPD");
            }
            else if (objAP_Cal_Atlantic.Premises_Liability == "Y")
            {
                strEbdy = strEbdy.Replace("[rblInsuranceClaimTypeView]", "Premises Liability");
            }
            else if (objAP_Cal_Atlantic.Property_Damage == "Y")
            {
                strEbdy = strEbdy.Replace("[rblInsuranceClaimTypeView]", "Property Damage");
            }

        }

        string strFileName = "Asset Protection Abstract.doc";

        clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
    }
    private void GenerateHTMLForCalAtlantic()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionCalAtlanticAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        Hashtable htFindAndReplace = new Hashtable();
        if (PKID > 0)
        {
            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";

            clsAP_Cal_Atlantic objAP_Cal_Atlantic = new clsAP_Cal_Atlantic(PKID);

            DataTable dtEvent = clsAP_Cal_Atlantic.SelectAP_CalAtlanticPKByFKEvent(Convert.ToDecimal(objAP_Cal_Atlantic.FK_Event)).Tables[0];
            htFindAndReplace.Add("[lblDateOfEvent]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString()));
            htFindAndReplace.Add("[lblTimeOfEvent]", "");
            htFindAndReplace.Add("[lblTypeOfEvent]", new clsLU_Event_Type(Convert.ToDecimal(dtEvent.Rows[0]["FK_LU_Event_Type"].ToString())).Fld_Desc);
            htFindAndReplace.Add("[lblEventReportDate]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Report_Date"].ToString()));
            htFindAndReplace.Add("[lblInvestigationReportDate]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Investigation_Report_Date"].ToString()));
            htFindAndReplace.Add("[lblDateOfEvent]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString()));

            if (dtEvent.Rows[0]["FK_LU_Event_Description"] != null && Convert.ToString(dtEvent.Rows[0]["FK_LU_Event_Description"]) != "")
                htFindAndReplace.Add("[lblFK_LU_Event_Description]", new clsLU_Event_Description((decimal)dtEvent.Rows[0]["FK_LU_Event_Description"]).Fld_Desc);
            else
                htFindAndReplace.Add("[lblFK_LU_Event_Description]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString()));

            htFindAndReplace.Add("[lblDate_Opened]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Opened"].ToString()));
            htFindAndReplace.Add("[lblDateSendToClient]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Sent"].ToString()));
            htFindAndReplace.Add("[lblEventOccuranceDate]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString()));

            htFindAndReplace.Add("[lblPotential_Risk]", objAP_Cal_Atlantic.Potential_Risk);
            htFindAndReplace.Add("[lblAction_Taken]", objAP_Cal_Atlantic.Action_Taken);
            if (objAP_Cal_Atlantic.Was_Law_Enforcement_Notified != null)
                htFindAndReplace.Add("[lblWas_Law_Enforcement_Notified]", objAP_Cal_Atlantic.Was_Law_Enforcement_Notified == "Y" ? "Yes" : "No");
            else
                htFindAndReplace.Add("[lblWas_Law_Enforcement_Notified]", "");
            htFindAndReplace.Add("[lblOfficer_Name]", objAP_Cal_Atlantic.Officer_Name);
            htFindAndReplace.Add("[lblPhone_Number]", objAP_Cal_Atlantic.Phone_Number);
            htFindAndReplace.Add("[lblEMail]", objAP_Cal_Atlantic.EMail);
            htFindAndReplace.Add("[lblLaw_Enforcement_Agency]", objAP_Cal_Atlantic.Law_Enforcement_Agency);
            htFindAndReplace.Add("[lblLocation]", objAP_Cal_Atlantic.Location);
            htFindAndReplace.Add("[lblPolice_Report_Number]", objAP_Cal_Atlantic.Police_Report_Number);
            htFindAndReplace.Add("[lblNotes]", objAP_Cal_Atlantic.Notes);
            htFindAndReplace.Add("[lblRoot_Cause]", objAP_Cal_Atlantic.Root_Cause);
            htFindAndReplace.Add("[lblEvent_Prevention]", objAP_Cal_Atlantic.Event_Prevention);
            htFindAndReplace.Add("[lblTask_Prevent_Reoccurance]", objAP_Cal_Atlantic.Person_Tasked);
            htFindAndReplace.Add("[lblCal_Target_Date_of_Completion]", clsGeneral.FormatDBNullDateToDisplay(objAP_Cal_Atlantic.Target_Date_of_Completion));
            htFindAndReplace.Add("[lblCal_Status_Due_On]", clsGeneral.FormatDBNullDateToDisplay(objAP_Cal_Atlantic.Status_Due_On));
            htFindAndReplace.Add("[lblComments]", objAP_Cal_Atlantic.Comments);
            htFindAndReplace.Add("[lblCal_Financial_Loss]", clsGeneral.GetStringValue(objAP_Cal_Atlantic.Financial_Loss));
            htFindAndReplace.Add("[lblCal_Recovery]", clsGeneral.GetStringValue(objAP_Cal_Atlantic.Recovery));
            if (objAP_Cal_Atlantic.Item_Status != null)
                htFindAndReplace.Add("[lblCal_Item_Status]", objAP_Cal_Atlantic.Item_Status == "O" ? "Open" : "Closed");
            else
                htFindAndReplace.Add("[lblCal_Item_Status]", objAP_Cal_Atlantic.Comments);

            htFindAndReplace.Add("[lblAssociatedFROINo]", objAP_Cal_Atlantic.Associated_FROI_Number);
            htFindAndReplace.Add("[lblAssocaitedClaimNo]", objAP_Cal_Atlantic.Associated_Claim_Number);



            if (objAP_Cal_Atlantic.Auto_Liability == "Y")
            {
                htFindAndReplace.Add("[rblInsuranceClaimTypeView]", "Auto Liability");
            }
            else if (objAP_Cal_Atlantic.DPD == "Y")
            {
                htFindAndReplace.Add("[rblInsuranceClaimTypeView]", "DPD");
            }
            else if (objAP_Cal_Atlantic.Premises_Liability == "Y")
            {
                htFindAndReplace.Add("[rblInsuranceClaimTypeView]", "Premises Liability");
            }
            else if (objAP_Cal_Atlantic.Property_Damage == "Y")
            {
                htFindAndReplace.Add("[rblInsuranceClaimTypeView]", "Property Damage");
            }

        }

        string strFileName = "Asset Protection Abstract.doc";

        //clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
        clsGeneral.GenerateWordFromFileAndReplaceText(fsMail.Name, strFileName, htFindAndReplace, Response);
    }

    /// <summary>
    /// function use for generate html output Fraud Event Report
    /// </summary>
    /// <param name="sbHtml"></param>
    private void GenerateHTMLForFraudEventOLD()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionFraudEventsAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();

        if (PKID > 0)
        {
            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";


            //strEbdy = strEbdy.Replace("[lblPotential_Risk]", objAP_Cal_Atlantic.Potential_Risk);
            //strEbdy = strEbdy.Replace("[lblAction_Taken]", objAP_Cal_Atlantic.Action_Taken);
            //if (objAP_Cal_Atlantic.Was_Law_Enforcement_Notified != null)
            //    strEbdy = strEbdy.Replace("[lblWas_Law_Enforcement_Notified]", objAP_Cal_Atlantic.Was_Law_Enforcement_Notified == "Y" ? "Yes" : "No");
            //else
            //    strEbdy = strEbdy.Replace("[lblWas_Law_Enforcement_Notified]", "");

            clsAP_Fraud_Events objAP_Fraud_Events = new clsAP_Fraud_Events(PKID);

            strEbdy = strEbdy.Replace("[lblFraudNumber]", objAP_Fraud_Events.Fraud_Number);
            strEbdy = strEbdy.Replace("[lblExposurePeriodBeginDate]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Exposure_Period_Begin_Date));
            strEbdy = strEbdy.Replace("[lblExposurePeriodEndDate]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Exposure_Period_End_Date));
            strEbdy = strEbdy.Replace("[lblReportedTo]", objAP_Fraud_Events.Reported_To);
            strEbdy = strEbdy.Replace("[lblReportedDate]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Reported_Date));
            strEbdy = strEbdy.Replace("[lblDesciptionOfEvent]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Description_of_Event));
            strEbdy = strEbdy.Replace("[lblOther_Notification_Description]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Other_Notification_Description));
            strEbdy = strEbdy.Replace("[lblInternal_Review_Purification_Notes]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Internal_Review_Purification_Notes));
            strEbdy = strEbdy.Replace("[lblFraud_Date]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Fraud_Date));
            strEbdy = strEbdy.Replace("[lblHR_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.HR_Assignment));
            strEbdy = strEbdy.Replace("[lblHR_Associate_Contacted]", objAP_Fraud_Events.HR_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_HR_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_HR_Assigned));
            strEbdy = strEbdy.Replace("[lblInternal_Audit_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Internal_Audit_Assignment));
            strEbdy = strEbdy.Replace("[lblInternal_Audit_Associate_Contacted]", objAP_Fraud_Events.Internal_Audit_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_Internal_Audit_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Internal_Audit_Assigned));
            strEbdy = strEbdy.Replace("[lblStore_Controller_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Store_Controller_Assignment));
            strEbdy = strEbdy.Replace("[lblStore_Controller_Associate_Contacted]", objAP_Fraud_Events.Store_Controller_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_Store_Controller_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Store_Controller_Assigned));
            strEbdy = strEbdy.Replace("[lblRegional_Controller_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Regional_Controller_Assignment));
            strEbdy = strEbdy.Replace("[lblRegional_Controller_Associate_Contacted]", objAP_Fraud_Events.Regional_Controller_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_Regional_Controller_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Regional_Controller_Assigned));
            strEbdy = strEbdy.Replace("[lblLegal_Department_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Legal_Department_Assignment));
            strEbdy = strEbdy.Replace("[lblLegal_Department_Associate_Contacted]", objAP_Fraud_Events.Legal_Department_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_Legal_Department_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Legal_Department_Assigned));
            strEbdy = strEbdy.Replace("[lblOutside_Legal_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Outside_Legal_Assignment));
            strEbdy = strEbdy.Replace("[lblOutside_Legal_Associate_Contacted]", objAP_Fraud_Events.Outside_Legal_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_Outside_Legal_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Outside_Legal_Assigned));
            strEbdy = strEbdy.Replace("[lblOperations_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Outside_Legal_Associate_Contacted));
            strEbdy = strEbdy.Replace("[lblOperations_Associate_Contacted]", objAP_Fraud_Events.Operations_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_Operations_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Operations_Assigned));
            strEbdy = strEbdy.Replace("[lblRetail_Lending_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Retail_Lending_Assignment));
            strEbdy = strEbdy.Replace("[lblRetail_Lending_Associate_Contacted]", objAP_Fraud_Events.Retail_Lending_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_Retail_Lending_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Retail_Lending_Assigned));
            strEbdy = strEbdy.Replace("[lblBT_Security_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.BT_Security_Assignment));
            strEbdy = strEbdy.Replace("[lblBT_Security_Associate_Contacted]", objAP_Fraud_Events.BT_Security_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_BT_Security_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_BT_Security_Assigned));
            strEbdy = strEbdy.Replace("[lblOther_Assignment]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Other_Assignment));
            strEbdy = strEbdy.Replace("[lblAssociated_Contacted]", objAP_Fraud_Events.Other_Associate_Contacted);
            strEbdy = strEbdy.Replace("[lblDate_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Other_Assigned));
            strEbdy = strEbdy.Replace("[lblOnSite_Findings]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.OnSite_Findings));
            strEbdy = strEbdy.Replace("[lblTLO_Findings]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.TLO_Findings));
            strEbdy = strEbdy.Replace("[lblStatements_Obtained]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Statements_Obtained));
            strEbdy = strEbdy.Replace("[lblFact_Finding_andor_Due_Diligence]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Fact_Finding_andor_Due_Diligence));
            strEbdy = strEbdy.Replace("[lblLaw_Enforcement_Involvement]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Law_Enforcement_Involvement));
            strEbdy = strEbdy.Replace("[lblDetailed_Deisposition_Game_Plan_Description]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Detailed_Deisposition_Game_Plan_Description));
            strEbdy = strEbdy.Replace("[lblDetail_Description_of_Root_Cause]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Detail_Description_of_Root_Cause));
            strEbdy = strEbdy.Replace("[lblDetail_Description_of_Corrective_Action_andor_Recommendation]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Detail_Description_of_Corrective_Action_andor_Recommendation));
            strEbdy = strEbdy.Replace("[lblReopen_Date]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Reopen_Date));
            strEbdy = strEbdy.Replace("[lblEventComments]", clsGeneral.ReplaceSpaceAndNewLine(objAP_Fraud_Events.Comments));
            strEbdy = strEbdy.Replace("[lblClose_Date]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Close_Date));

            if (objAP_Fraud_Events.Close_File != null)
                strEbdy = strEbdy.Replace("[lblClose_File]", objAP_Fraud_Events.Close_File == "Y" ? "Yes" : "No");
            else
                strEbdy = strEbdy.Replace("[lblClose_File]", "");

            if (objAP_Fraud_Events.Reopen_File != null)
                strEbdy = strEbdy.Replace("[lblReopen_File]", objAP_Fraud_Events.Close_File == "Y" ? "Yes" : "No");
            else
                strEbdy = strEbdy.Replace("[lblReopen_File]", "");

            if (objAP_Fraud_Events.ACC_Suspension == "Y")
            {
                strEbdy = strEbdy.Replace("[chkSuspensionView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkSuspensionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.ACC_Termination == "Y")
            {
                strEbdy = strEbdy.Replace("[chkTerminationView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkTerminationView]", ImgUnchecked); }

            if (objAP_Fraud_Events.ACC_Verbal == "Y")
            {
                strEbdy = strEbdy.Replace("[chkVerbalView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkVerbalView]", ImgUnchecked); }

            if (objAP_Fraud_Events.ACC_Written == "Y")
            {
                strEbdy = strEbdy.Replace("[chkWrittenView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkWrittenView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Account_Payable_Schemes == "Y")
            {
                strEbdy = strEbdy.Replace("[chkAccountPayableSchemesView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkAccountPayableSchemesView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Accounting_Gaps_and_Controls == "Y")
            {
                strEbdy = strEbdy.Replace("[chkAccountingGapsandControlView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkAccountingGapsandControlView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Aging_MFR_Incentives == "Y")
            {
                strEbdy = strEbdy.Replace("[chkMFRIncentivesView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkMFRIncentivesView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Aging_Warranties == "Y")
            {
                strEbdy = strEbdy.Replace("[chkAgingWarrantiesView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkAgingWarrantiesView]", ImgUnchecked); }

            //
            if (objAP_Fraud_Events.Associate_Collusion == "Y")
            {
                strEbdy = strEbdy.Replace("[chkAssociateCollusionView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkAssociateCollusionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Billing_Schemes == "Y")
            {
                strEbdy = strEbdy.Replace("[chkBillingSchemesView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkBillingSchemesView]", ImgUnchecked); }

            if (objAP_Fraud_Events.CA_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[chkCorrectiveActionRecommendationOtherView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkCorrectiveActionRecommendationOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Change_a_Control == "Y")
            {
                strEbdy = strEbdy.Replace("[chkchangeaControlView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkchangeaControlView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Civil_Actrion == "Y")
            {
                strEbdy = strEbdy.Replace("[chkCivilActionView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkCivilActionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Communication_Strategy == "Y")
            {
                strEbdy = strEbdy.Replace("[chkCommunicationStrategyView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkCommunicationStrategyView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Crimimal_Action == "Y")
            {
                strEbdy = strEbdy.Replace("[chkCriminalActionView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkCriminalActionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Current_Systen_Enhancement == "Y")
            {
                strEbdy = strEbdy.Replace("[chkCurrentSystemEnhancementView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkCurrentSystemEnhancementView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Customer_Relations_Hotline == "Y")
            {
                strEbdy = strEbdy.Replace("[chkCustomerRelationsHotLineView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkCustomerRelationsHotLineView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Discovered_Fraud_through_Audits == "Y")
            {
                strEbdy = strEbdy.Replace("[chkDiscoveredFraudthroughAuditsView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkDiscoveredFraudthroughAuditsView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Disposition_Game_Plan_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[chkDispositionGameplanOtherView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkDispositionGameplanOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.External_Scam == "Y")
            {
                strEbdy = strEbdy.Replace("[chkExternalScamView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkExternalScamView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Further_Investigation == "Y")
            {
                strEbdy = strEbdy.Replace("[chkFurtherInvestigationView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkFurtherInvestigationView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Implementation_Policy == "Y")
            {
                strEbdy = strEbdy.Replace("[chkImplementPolicyView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkImplementPolicyView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Improper_Disclosure_to_Customer_F_and_I_Product_Purchase == "Y")
            {
                strEbdy = strEbdy.Replace("[chkImproperDisclosuretoCustomerFandIProductPurchaseView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkImproperDisclosuretoCustomerFandIProductPurchaseView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Improper_Disclosure_to_Customer_Vehicle_Purchase == "Y")
            {
                strEbdy = strEbdy.Replace("[chkImproperDisclosuretoCustomerVehiclePurchaseView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkImproperDisclosuretoCustomerVehiclePurchaseView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Internal_Audit_Control_Breakdown_leading_to_Fraud_Event == "Y")
            {
                strEbdy = strEbdy.Replace("[chkIntrnlAditCntrlLeadToFraudEventView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkIntrnlAditCntrlLeadToFraudEventView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Inventory_Schemes == "Y")
            {
                strEbdy = strEbdy.Replace("[chkInventorySchemesView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkInventorySchemesView]", ImgUnchecked); }

            if (objAP_Fraud_Events.New_System_Change == "Y")
            {
                strEbdy = strEbdy.Replace("[chkNewSystemChangeView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkNewSystemChangeView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Notification_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[chkOtherView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Disposition_Game_Plan_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[chkGamePlanOtherView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkGamePlanOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Operations_No_Adherence_to_Sonic_Policy_And_Playbook == "Y")
            {
                strEbdy = strEbdy.Replace("[chkOperasionsNoAdherencetoSonicPolicyandPlaybookView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkOperasionsNoAdherencetoSonicPolicyandPlaybookView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Results_of_Disposition_Plan == "Y")
            {
                strEbdy = strEbdy.Replace("[chkResultOfDespositionPlanView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkResultOfDespositionPlanView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Retail_Lending == "Y")
            {
                strEbdy = strEbdy.Replace("[chkRetailLendingView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkRetailLendingView]", ImgUnchecked); }

            if (objAP_Fraud_Events.ReTraining == "Y")
            {
                strEbdy = strEbdy.Replace("[chkRetrainingView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkRetrainingView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Root_Cause_Other == "Y")
            {
                strEbdy = strEbdy.Replace("[chkRootCauseOtherView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkRootCauseOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Sonic_Associates_1800_Hotline == "Y")
            {
                strEbdy = strEbdy.Replace("[chkSonicAssociate1800HotLineView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkSonicAssociate1800HotLineView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Store_Red_Flags == "Y")
            {
                strEbdy = strEbdy.Replace("[chkStoreRedFlagsView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkStoreRedFlagsView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Training == "Y")
            {
                strEbdy = strEbdy.Replace("[chkTrainingView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkTrainingView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Vendor_Collusion == "Y")
            {
                strEbdy = strEbdy.Replace("[chkVendorCollusionView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkVendorCollusionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Vendor_Schemes == "Y")
            {
                strEbdy = strEbdy.Replace("[chkVendorSchemesView]", ImgChecked);
            }
            else { strEbdy = strEbdy.Replace("[chkVendorSchemesView]", ImgUnchecked); }


            #region "Fraud Events Notes Grid"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Fraud_Event records
            DataTable FENotesGrid = clsAP_FE_Notes.SelectNotesByFKFraudEvent(PKID).Tables[0];
            GenerateFraudEventNotes(sbHtml, FENotesGrid);
            strEbdy = strEbdy.Replace("[gvNotesGridView]", sbHtml.ToString());

            #endregion

            #region "Fraud Events Transaction Grid"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Fraud_Event records
            DataTable FETransactionGrid = clsAP_FE_Transactions.SelectTransactionByFKFraudEvent(PKID).Tables[0];
            GenerateFraudEventTransactionGrid(sbHtml, FETransactionGrid);
            strEbdy = strEbdy.Replace("[gvFinancialReserveTransactionView]", sbHtml.ToString());

            #endregion

            #region "Fraud Event Financial Matrix"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Fraud_Event records
            DataSet FEFinancialMatrix = clsAP_FE_Transactions.SelectFinancialMatrixValue(PKID);

            strEbdy = strEbdy.Replace("[lblFMReservePotentialLossView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[0].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMReserveExpenseView]", FEFinancialMatrix.Tables[1].Rows[0][0].ToString());
            strEbdy = strEbdy.Replace("[lblFMReserveTotalView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[2].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMPaidPotentialLossView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[3].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMPaidExpenseView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[4].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMPaidTotalView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[5].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMRecoveryPotentialLossView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[6].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMRecoveryExpenseView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[7].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMRecoveryTotalView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[8].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMOutstandingPotentialLossView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[9].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMOutstandingExpenseView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[10].Rows[0][0].ToString()));
            strEbdy = strEbdy.Replace("[lblFMOutstandingTotalView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[11].Rows[0][0].ToString()));

            #endregion

        }

        string strFileName = "Asset Protection Abstract.doc";

        clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
    }
    private void GenerateHTMLForFraudEvent()
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "AssetProtectionFraudEventsAbstract.htm";

        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\Exposures\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        Hashtable htFindAndReplace = new Hashtable();
        if (PKID > 0)
        {
            string ImgChecked, ImgUnchecked;
            ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked.bmp' alt='' style='height:8px;' />";
            ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked.bmp' alt='' style='height:8px;' />";


            //htFindAndReplace.Add("[lblPotential_Risk]", objAP_Cal_Atlantic.Potential_Risk);
            //htFindAndReplace.Add("[lblAction_Taken]", objAP_Cal_Atlantic.Action_Taken);
            //if (objAP_Cal_Atlantic.Was_Law_Enforcement_Notified != null)
            //    htFindAndReplace.Add("[lblWas_Law_Enforcement_Notified]", objAP_Cal_Atlantic.Was_Law_Enforcement_Notified == "Y" ? "Yes" : "No");
            //else
            //    htFindAndReplace.Add("[lblWas_Law_Enforcement_Notified]", "");

            clsAP_Fraud_Events objAP_Fraud_Events = new clsAP_Fraud_Events(PKID);

            htFindAndReplace.Add("[lblFraudNumber]", objAP_Fraud_Events.Fraud_Number);
            htFindAndReplace.Add("[lblExposurePeriodBeginDate]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Exposure_Period_Begin_Date));
            htFindAndReplace.Add("[lblExposurePeriodEndDate]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Exposure_Period_End_Date));
            htFindAndReplace.Add("[lblReportedTo]", objAP_Fraud_Events.Reported_To);
            htFindAndReplace.Add("[lblReportedDate]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Reported_Date));
            htFindAndReplace.Add("[lblDesciptionOfEvent]", objAP_Fraud_Events.Description_of_Event);
            htFindAndReplace.Add("[lblOther_Notification_Description]", objAP_Fraud_Events.Other_Notification_Description);
            htFindAndReplace.Add("[lblInternal_Review_Purification_Notes]", objAP_Fraud_Events.Internal_Review_Purification_Notes);
            htFindAndReplace.Add("[lblFraud_Date]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Fraud_Date));
            htFindAndReplace.Add("[lblHR_Assignment]", objAP_Fraud_Events.HR_Assignment);
            htFindAndReplace.Add("[lblHR_Associate_Contacted]", objAP_Fraud_Events.HR_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_HR_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_HR_Assigned));
            htFindAndReplace.Add("[lblInternal_Audit_Assignment]", objAP_Fraud_Events.Internal_Audit_Assignment);
            htFindAndReplace.Add("[lblInternal_Audit_Associate_Contacted]", objAP_Fraud_Events.Internal_Audit_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_Internal_Audit_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Internal_Audit_Assigned));
            htFindAndReplace.Add("[lblStore_Controller_Assignment]", objAP_Fraud_Events.Store_Controller_Assignment);
            htFindAndReplace.Add("[lblStore_Controller_Associate_Contacted]", objAP_Fraud_Events.Store_Controller_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_Store_Controller_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Store_Controller_Assigned));
            htFindAndReplace.Add("[lblRegional_Controller_Assignment]", objAP_Fraud_Events.Regional_Controller_Assignment);
            htFindAndReplace.Add("[lblRegional_Controller_Associate_Contacted]", objAP_Fraud_Events.Regional_Controller_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_Regional_Controller_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Regional_Controller_Assigned));
            htFindAndReplace.Add("[lblLegal_Department_Assignment]", objAP_Fraud_Events.Legal_Department_Assignment);
            htFindAndReplace.Add("[lblLegal_Department_Associate_Contacted]", objAP_Fraud_Events.Legal_Department_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_Legal_Department_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Legal_Department_Assigned));
            htFindAndReplace.Add("[lblOutside_Legal_Assignment]", objAP_Fraud_Events.Outside_Legal_Assignment);
            htFindAndReplace.Add("[lblOutside_Legal_Associate_Contacted]", objAP_Fraud_Events.Outside_Legal_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_Outside_Legal_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Outside_Legal_Assigned));
            htFindAndReplace.Add("[lblOperations_Assignment]", objAP_Fraud_Events.Outside_Legal_Associate_Contacted);
            htFindAndReplace.Add("[lblOperations_Associate_Contacted]", objAP_Fraud_Events.Operations_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_Operations_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Operations_Assigned));
            htFindAndReplace.Add("[lblRetail_Lending_Assignment]", objAP_Fraud_Events.Retail_Lending_Assignment);
            htFindAndReplace.Add("[lblRetail_Lending_Associate_Contacted]", objAP_Fraud_Events.Retail_Lending_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_Retail_Lending_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Retail_Lending_Assigned));
            htFindAndReplace.Add("[lblBT_Security_Assignment]", objAP_Fraud_Events.BT_Security_Assignment);
            htFindAndReplace.Add("[lblBT_Security_Associate_Contacted]", objAP_Fraud_Events.BT_Security_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_BT_Security_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_BT_Security_Assigned));
            htFindAndReplace.Add("[lblOther_Assignment]", objAP_Fraud_Events.Other_Assignment);
            htFindAndReplace.Add("[lblAssociated_Contacted]", objAP_Fraud_Events.Other_Associate_Contacted);
            htFindAndReplace.Add("[lblDate_Assigned]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Other_Assigned));
            htFindAndReplace.Add("[lblOnSite_Findings]", objAP_Fraud_Events.OnSite_Findings);
            htFindAndReplace.Add("[lblTLO_Findings]", objAP_Fraud_Events.TLO_Findings);
            htFindAndReplace.Add("[lblStatements_Obtained]", objAP_Fraud_Events.Statements_Obtained);
            htFindAndReplace.Add("[lblFact_Finding_andor_Due_Diligence]", objAP_Fraud_Events.Fact_Finding_andor_Due_Diligence);
            htFindAndReplace.Add("[lblLaw_Enforcement_Involvement]", objAP_Fraud_Events.Law_Enforcement_Involvement);
            htFindAndReplace.Add("[lblDetailed_Deisposition_Game_Plan_Description]", objAP_Fraud_Events.Detailed_Deisposition_Game_Plan_Description);
            htFindAndReplace.Add("[lblDetail_Description_of_Root_Cause]", objAP_Fraud_Events.Detail_Description_of_Root_Cause);
            htFindAndReplace.Add("[lblDetail_Description_of_Corrective_Action_andor_Recommendation]", objAP_Fraud_Events.Detail_Description_of_Corrective_Action_andor_Recommendation);
            htFindAndReplace.Add("[lblReopen_Date]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Reopen_Date));
            htFindAndReplace.Add("[lblEventComments]", objAP_Fraud_Events.Comments);
            htFindAndReplace.Add("[lblClose_Date]", clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Close_Date));

            if (objAP_Fraud_Events.Close_File != null)
                htFindAndReplace.Add("[lblClose_File]", objAP_Fraud_Events.Close_File == "Y" ? "Yes" : "No");
            else
                htFindAndReplace.Add("[lblClose_File]", "");

            if (objAP_Fraud_Events.Reopen_File != null)
                htFindAndReplace.Add("[lblReopen_File]", objAP_Fraud_Events.Close_File == "Y" ? "Yes" : "No");
            else
                htFindAndReplace.Add("[lblReopen_File]", "");

            if (objAP_Fraud_Events.ACC_Suspension == "Y")
            {
                htFindAndReplace.Add("[chkSuspensionView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkSuspensionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.ACC_Termination == "Y")
            {
                htFindAndReplace.Add("[chkTerminationView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkTerminationView]", ImgUnchecked); }

            if (objAP_Fraud_Events.ACC_Verbal == "Y")
            {
                htFindAndReplace.Add("[chkVerbalView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkVerbalView]", ImgUnchecked); }

            if (objAP_Fraud_Events.ACC_Written == "Y")
            {
                htFindAndReplace.Add("[chkWrittenView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkWrittenView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Account_Payable_Schemes == "Y")
            {
                htFindAndReplace.Add("[chkAccountPayableSchemesView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkAccountPayableSchemesView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Accounting_Gaps_and_Controls == "Y")
            {
                htFindAndReplace.Add("[chkAccountingGapsandControlView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkAccountingGapsandControlView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Aging_MFR_Incentives == "Y")
            {
                htFindAndReplace.Add("[chkMFRIncentivesView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkMFRIncentivesView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Aging_Warranties == "Y")
            {
                htFindAndReplace.Add("[chkAgingWarrantiesView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkAgingWarrantiesView]", ImgUnchecked); }

            //
            if (objAP_Fraud_Events.Associate_Collusion == "Y")
            {
                htFindAndReplace.Add("[chkAssociateCollusionView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkAssociateCollusionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Billing_Schemes == "Y")
            {
                htFindAndReplace.Add("[chkBillingSchemesView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkBillingSchemesView]", ImgUnchecked); }

            if (objAP_Fraud_Events.CA_Other == "Y")
            {
                htFindAndReplace.Add("[chkCorrectiveActionRecommendationOtherView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkCorrectiveActionRecommendationOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Change_a_Control == "Y")
            {
                htFindAndReplace.Add("[chkchangeaControlView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkchangeaControlView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Civil_Actrion == "Y")
            {
                htFindAndReplace.Add("[chkCivilActionView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkCivilActionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Communication_Strategy == "Y")
            {
                htFindAndReplace.Add("[chkCommunicationStrategyView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkCommunicationStrategyView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Crimimal_Action == "Y")
            {
                htFindAndReplace.Add("[chkCriminalActionView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkCriminalActionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Current_Systen_Enhancement == "Y")
            {
                htFindAndReplace.Add("[chkCurrentSystemEnhancementView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkCurrentSystemEnhancementView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Customer_Relations_Hotline == "Y")
            {
                htFindAndReplace.Add("[chkCustomerRelationsHotLineView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkCustomerRelationsHotLineView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Discovered_Fraud_through_Audits == "Y")
            {
                htFindAndReplace.Add("[chkDiscoveredFraudthroughAuditsView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkDiscoveredFraudthroughAuditsView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Disposition_Game_Plan_Other == "Y")
            {
                htFindAndReplace.Add("[chkDispositionGameplanOtherView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkDispositionGameplanOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.External_Scam == "Y")
            {
                htFindAndReplace.Add("[chkExternalScamView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkExternalScamView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Further_Investigation == "Y")
            {
                htFindAndReplace.Add("[chkFurtherInvestigationView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkFurtherInvestigationView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Implementation_Policy == "Y")
            {
                htFindAndReplace.Add("[chkImplementPolicyView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkImplementPolicyView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Improper_Disclosure_to_Customer_F_and_I_Product_Purchase == "Y")
            {
                htFindAndReplace.Add("[chkImproperDisclosuretoCustomerFandIProductPurchaseView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkImproperDisclosuretoCustomerFandIProductPurchaseView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Improper_Disclosure_to_Customer_Vehicle_Purchase == "Y")
            {
                htFindAndReplace.Add("[chkImproperDisclosuretoCustomerVehiclePurchaseView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkImproperDisclosuretoCustomerVehiclePurchaseView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Internal_Audit_Control_Breakdown_leading_to_Fraud_Event == "Y")
            {
                htFindAndReplace.Add("[chkIntrnlAditCntrlLeadToFraudEventView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkIntrnlAditCntrlLeadToFraudEventView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Inventory_Schemes == "Y")
            {
                htFindAndReplace.Add("[chkInventorySchemesView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkInventorySchemesView]", ImgUnchecked); }

            if (objAP_Fraud_Events.New_System_Change == "Y")
            {
                htFindAndReplace.Add("[chkNewSystemChangeView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkNewSystemChangeView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Notification_Other == "Y")
            {
                htFindAndReplace.Add("[chkOtherView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Disposition_Game_Plan_Other == "Y")
            {
                htFindAndReplace.Add("[chkGamePlanOtherView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkGamePlanOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Operations_No_Adherence_to_Sonic_Policy_And_Playbook == "Y")
            {
                htFindAndReplace.Add("[chkOperasionsNoAdherencetoSonicPolicyandPlaybookView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkOperasionsNoAdherencetoSonicPolicyandPlaybookView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Results_of_Disposition_Plan == "Y")
            {
                htFindAndReplace.Add("[chkResultOfDespositionPlanView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkResultOfDespositionPlanView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Retail_Lending == "Y")
            {
                htFindAndReplace.Add("[chkRetailLendingView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkRetailLendingView]", ImgUnchecked); }

            if (objAP_Fraud_Events.ReTraining == "Y")
            {
                htFindAndReplace.Add("[chkRetrainingView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkRetrainingView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Root_Cause_Other == "Y")
            {
                htFindAndReplace.Add("[chkRootCauseOtherView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkRootCauseOtherView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Sonic_Associates_1800_Hotline == "Y")
            {
                htFindAndReplace.Add("[chkSonicAssociate1800HotLineView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkSonicAssociate1800HotLineView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Store_Red_Flags == "Y")
            {
                htFindAndReplace.Add("[chkStoreRedFlagsView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkStoreRedFlagsView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Training == "Y")
            {
                htFindAndReplace.Add("[chkTrainingView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkTrainingView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Vendor_Collusion == "Y")
            {
                htFindAndReplace.Add("[chkVendorCollusionView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkVendorCollusionView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Vendor_Schemes == "Y")
            {
                htFindAndReplace.Add("[chkVendorSchemesView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkVendorSchemesView]", ImgUnchecked); }

            if (objAP_Fraud_Events.Monthly_AR_Control_Review == "Y")
            {
                htFindAndReplace.Add("[chkMonthly_AR_Control_ReviewView]", ImgChecked);
            }
            else { htFindAndReplace.Add("[chkMonthly_AR_Control_ReviewView]", ImgUnchecked); }
            
            #region "Fraud Events Notes Grid "

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Fraud_Event records
            DataTable FENotesGrid = clsAP_FE_Notes.SelectNotesByFKFraudEvent(PKID).Tables[0];
            GenerateFraudEventNotes(sbHtml, FENotesGrid);
            htFindAndReplace.Add("[gvNotesGridView]", sbHtml.ToString());

            #endregion


            #region "Fraud Events Notes  Grid Partnership"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Fraud_Event records
            DataTable FENotesPropertyGrid = AP_FE_PA_Notes.SelectNotesByFKFraudEvent(PKID, "DESC").Tables[0];
            GenerateFraudEventNotes(sbHtml, FENotesPropertyGrid);
            htFindAndReplace.Add("[gvNotesGridPartnershipView]", sbHtml.ToString());

            #endregion

            #region "Fraud Events Transaction Grid"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Fraud_Event records
            DataTable FETransactionGrid = clsAP_FE_Transactions.SelectTransactionByFKFraudEvent(PKID).Tables[0];
            GenerateFraudEventTransactionGrid(sbHtml, FETransactionGrid);
            htFindAndReplace.Add("[gvFinancialReserveTransactionView]", sbHtml.ToString());

            #endregion

            #region "Fraud Event Financial Matrix"

            sbHtml = new System.Text.StringBuilder("");

            // get datatable for Fraud_Event records
            DataSet FEFinancialMatrix = clsAP_FE_Transactions.SelectFinancialMatrixValue(PKID);

            htFindAndReplace.Add("[lblFMReservePotentialLossView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[0].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMReserveExpenseView]", FEFinancialMatrix.Tables[1].Rows[0][0].ToString());
            htFindAndReplace.Add("[lblFMReserveTotalView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[2].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMPaidPotentialLossView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[3].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMPaidExpenseView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[4].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMPaidTotalView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[5].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMRecoveryPotentialLossView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[6].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMRecoveryExpenseView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[7].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMRecoveryTotalView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[8].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMOutstandingPotentialLossView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[9].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMOutstandingExpenseView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[10].Rows[0][0].ToString()));
            htFindAndReplace.Add("[lblFMOutstandingTotalView]", clsGeneral.GetStringValue(FEFinancialMatrix.Tables[11].Rows[0][0].ToString()));

            #endregion  

        }

        string strFileName = "Asset Protection Abstract.doc";

        //clsGeneral.GenerateWordDoc(strFileName, strEbdy.ToString(), Response);
        clsGeneral.GenerateWordFromFileAndReplaceText(fsMail.Name, strFileName, htFindAndReplace, Response);
    }

    /// <summary>
    /// get Header table row with bottom border and font color
    /// </summary>
    /// <param name="Content"></param>
    /// <returns></returns>
    private string GetHeaderRow(string Content)
    {
        return string.Concat("<tr align='left'> <td style='border-bottom-color: Black; border-bottom-style: solid; border-bottom-width: thin;color: #548DD4;'> <span style='color: #548DD4;'>" + Content + " </span> </td> </tr>");
    }

    /// <summary>
    /// it retuns blank row that is used to generate HTML format email to be sent.
    /// </summary>
    /// <param name="Height">height of the blank row</param>
    /// <returns>blank row HTML tag</returns>
    private string GetBlankRow(int Height)
    {
        //return string.Concat("<tr><td class=\"Spacer\" style=\"height:", Height.ToString(), "px\"></td></tr>");

        return string.Concat("<tr><td height=" + Height.ToString() + "></td></tr>");
        //return string.Concat("<tr><td style=\"height:", Height.ToString(), "px\"></td></tr>");
    }

    /// <summary>
    /// General method to generate html grid for TRS
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtIncentive"></param>
    /// <param name="strHeader"></param>
    private void GenerateLocationGrid(System.Text.StringBuilder sbHtml)
    {
        sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
        sbHtml.Append("<tr valign='top' align='center'>");
        sbHtml.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:17%; align:left;' ><span style='font-size: 14px; font-family: Arial;'><b>Location Number</b></span></td>");
        sbHtml.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:22%; align:left;' ><span style='font-size: 14px; font-family: Arial;'><b>SONIC Location d/b/a</b></span></td>");
        sbHtml.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:26%; align:left;' ><span style='font-size: 14px; font-family: Arial;'><b>Address</b></span></td>");
        sbHtml.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:12%; align:left;' ><span style='font-size: 14px; font-family: Arial;'><b>City</b></span></td>");
        sbHtml.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%; align:left;' ><span style='font-size: 14px; font-family: Arial;'><b>State</b></span></td>");
        sbHtml.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:10%; align:left;' ><span style='font-size: 14px; font-family: Arial;'><b>Zip</b></span></td>");
        sbHtml.Append("</tr>");

        DataTable dtLocationInfo = LU_Location.SelectByPK(LocationID).Tables[0];
        if (dtLocationInfo != null && dtLocationInfo.Rows.Count > 0)
        {

            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:17%; align:left;' ><span style='font-size: 14px; font-family: Arial;'> " + Convert.ToString(dtLocationInfo.Rows[0]["Sonic_Location_Code"]) + "</span> </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:22%; align:left;' ><span style='font-size: 14px; font-family: Arial;'> " + Convert.ToString(dtLocationInfo.Rows[0]["dba"]) + "</span> </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:26%; align:left;' ><span style='font-size: 14px; font-family: Arial;'> " + Convert.ToString(dtLocationInfo.Rows[0]["Address"]) + "</span></td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:12%; align:left;' ><span style='font-size: 14px; font-family: Arial;'> " + Convert.ToString(dtLocationInfo.Rows[0]["City"]) + "</span></td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%; align:left;'><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtLocationInfo.Rows[0]["StateName"]) + "</span></td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:10%; align:left;'><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtLocationInfo.Rows[0]["Zip_Code"]) + "</span></td>");
            sbHtml.Append("</tr>");
        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// General method to generate html grid for TRS
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtIncentive"></param>
    /// <param name="strHeader"></param>
    private void GenerateFinancialGrid(System.Text.StringBuilder sbHtml)
    {
        sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
        sbHtml.Append("<tr valign='top' align='center'>");
        sbHtml.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:17%; align:left;' ><span style='font-size: 14px; font-family: Arial;'><b>Category</b></span></td>");
        sbHtml.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:22%; align:left;' ><span style='font-size: 14px; font-family: Arial;'><b>Total Capex $</b></span></td>");
        sbHtml.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:26%; align:left;' ><span style='font-size: 14px; font-family: Arial;'><b>Total Monthly Charge $</b></span></td>");
        sbHtml.Append("</tr>");

        clsAP_Property_Security_Financials objclsAP_Property_Security_Financials = new clsAP_Property_Security_Financials();
        objclsAP_Property_Security_Financials.FK_AP_Property_Security = PK_AP_Property_Security;
        DataSet dsFinancialGrid = objclsAP_Property_Security_Financials.GetAPPropertySecurityFinancialsFromFK();
        DataTable dtFinancialGrid = dsFinancialGrid.Tables[0];
        if (dtFinancialGrid != null)
        {
            string strTotalCapex, strTotalMonthlyCharge = string.Empty;
            for (int i = 0; i < dtFinancialGrid.Rows.Count; i++)
            {
                if (dtFinancialGrid.Rows[i]["Total_Capex"].ToString() != string.Empty)
                    strTotalCapex = clsGeneral.FormatCommaSeperatorCurrency(dtFinancialGrid.Rows[i]["Total_Capex"]);
                else
                    strTotalCapex = string.Empty;

                if (dtFinancialGrid.Rows[i]["Total_Monthly_Charge"].ToString() != string.Empty)
                    strTotalMonthlyCharge = clsGeneral.FormatCommaSeperatorCurrency(dtFinancialGrid.Rows[i]["Total_Monthly_Charge"]);
                else
                    strTotalMonthlyCharge = string.Empty;

                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:17%; align:left;' ><span style='font-size: 14px; font-family: Arial;'> " + Convert.ToString(dtFinancialGrid.Rows[i]["Category"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:22%; align:left;' ><span style='font-size: 14px; font-family: Arial;'> " + strTotalCapex + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:26%; align:left;' ><span style='font-size: 14px; font-family: Arial;'> " + strTotalMonthlyCharge + "</span></td>");
                sbHtml.Append("</tr>"); 
            }            
        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// General method to generate html grid for DPD
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtIncentive"></param>
    /// <param name="strHeader"></param>
    private void GenerateDPDFROI(System.Text.StringBuilder sbHtml, DataTable dtDPD)
    {
        if (dtDPD.Rows.Count > 0)
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' ><span style='font-size: 14px; font-family: Arial;'><b>DPD First Report Number</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' ><span style='font-size: 14px; font-family: Arial;'><b>Date of Loss</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%' ><span style='font-size: 14px; font-family: Arial;'><b>Cause of Loss</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%' ><span style='font-size: 14px; font-family: Arial;'><b>Make</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%' ><span style='font-size: 14px; font-family: Arial;'><b>Model</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:10%' ><span style='font-size: 14px; font-family: Arial;'><b>Status</b></span></td>");
            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtDPD.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtDPD.Rows[i]["DPD_FR_Number"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' ><span style='font-size: 14px; font-family: Arial;'>" + clsGeneral.FormatDBNullDateToDisplay(dtDPD.Rows[i]["Date_Of_Loss"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtDPD.Rows[i]["Cause_Of_Loss"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtDPD.Rows[i]["Make"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtDPD.Rows[i]["Model"]) + " </span></td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:10%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtDPD.Rows[i]["Item_Status"]) + " </span></td>");
                sbHtml.Append("</tr>");
            }
        }
        else
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%' ><span style='font-size: 14px; font-family: Arial;'><b>No Record found </b></span></td>");
            sbHtml.Append("</tr>");

        }

        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// General method to generate html grid for DPD
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtIncentive"></param>
    /// <param name="strHeader"></param>
    private void GenerateALFROI(System.Text.StringBuilder sbHtml, DataTable dtAL)
    {
        if (dtAL.Rows.Count > 0)
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' ><span style='font-size: 14px; font-family: Arial;'><b>AL First Report Number</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' ><span style='font-size: 14px; font-family: Arial;'><b>Date of Loss</b></span></td>");
            //sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%' > <b>Cause of Loss</td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%' ><span style='font-size: 14px; font-family: Arial;'><b>Make</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%' ><span style='font-size: 14px; font-family: Arial;'><b>Model</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:26%' ><span style='font-size: 14px; font-family: Arial;'><b>Status</b></span></td>");
            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtAL.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtAL.Rows[i]["AL_FR_Number"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' ><span style='font-size: 14px; font-family: Arial;'>" + clsGeneral.FormatDBNullDateToDisplay(dtAL.Rows[i]["Date_Of_Loss"]) + "</span> </td>");
                //sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%;align:left;' >" + Convert.ToString(dtAL.Rows[i]["Cause_Of_Loss"]) + " </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtAL.Rows[i]["Make"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtAL.Rows[i]["Model"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:26%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtAL.Rows[i]["Item_Status"]) + " </span></td>");
                sbHtml.Append("</tr>");
            }
        }
        else
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%' ><span style='font-size: 14px; font-family: Arial;'><b>No Record found </b></span></td>");
            sbHtml.Append("</tr>");

        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// General method to generate html grid for Cal Atlantic
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtIncentive"></param>
    /// <param name="strHeader"></param>
    private void GenerateCALAtlantic(System.Text.StringBuilder sbHtml, DataTable dtCAL)
    {
        if (dtCAL.Rows.Count > 0)
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' ><span style='font-size: 14px; font-family: Arial;'><b>Event Number</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' ><span style='font-size: 14px; font-family: Arial;'><b>Date of Event</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%' ><span style='font-size: 14px; font-family: Arial;'><b>Time of Event</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%' ><span style='font-size: 14px; font-family: Arial;'><b>Type</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%' ><span style='font-size: 14px; font-family: Arial;'><b>FROI</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:10%' ><span style='font-size: 14px; font-family: Arial;'><b>Status</b></span></td>");
            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtCAL.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtCAL.Rows[i]["Event_Number"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' ><span style='font-size: 14px; font-family: Arial;'>" + clsGeneral.FormatDBNullDateToDisplay(dtCAL.Rows[i]["Event_Occurence_Date"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%;' ><span style='font-size: 14px; font-family: Arial;'>" + clsGeneral.FormatDBNullDateToDisplay(dtCAL.Rows[i]["Event_Report_Date"]) + " </span></td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtCAL.Rows[i]["Event_Type"]) + " </span></td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtCAL.Rows[i]["Associated_FROI_Number"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:10%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtCAL.Rows[i]["STATUS"]) + " </span></td>");
                sbHtml.Append("</tr>");
            }
        }
        else
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%' ><span style='font-size: 14px; font-family: Arial;'><b>No Record found </b></span></td>");
            sbHtml.Append("</tr>");

        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    ///  General method to generate html grid for Fraud Event
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtFraud"></param>
    private void GenerateFraudEvent(System.Text.StringBuilder sbHtml, DataTable dtFraud)
    {
        if (dtFraud.Rows.Count > 0)
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' ><span style='font-size: 14px; font-family: Arial;'><b>Fraud Number</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' ><span style='font-size: 14px; font-family: Arial;'><b>Exposure Period Begin Date</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%' ><span style='font-size: 14px; font-family: Arial;'><b>Exposure Period End Date</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%' ><span style='font-size: 14px; font-family: Arial;'><b>Reported To</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%' ><span style='font-size: 14px; font-family: Arial;'><b>Reported Date</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:10%' ><span style='font-size: 14px; font-family: Arial;'><b>Status</b></span></td>");
            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtFraud.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFraud.Rows[i]["Fraud_Number"]) + " </span></td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' ><span style='font-size: 14px; font-family: Arial;'>" + clsGeneral.FormatDBNullDateToDisplay(dtFraud.Rows[i]["Exposure_Period_Begin_Date"]) + " </span></td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:18%;' ><span style='font-size: 14px; font-family: Arial;'>" + clsGeneral.FormatDBNullDateToDisplay(dtFraud.Rows[i]["Exposure_Period_End_Date"]) + " </span></td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFraud.Rows[i]["Reported_To"]) + " </span></td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:16%;' ><span style='font-size: 14px; font-family: Arial;'>" + clsGeneral.FormatDBNullDateToDisplay(dtFraud.Rows[i]["Reported_Date"]) + " </span></td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:1%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFraud.Rows[i]["Close_File"]) + "</span></td>");
                sbHtml.Append("</tr>");
            }
        }
        else
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%' ><span style='font-size: 14px; font-family: Arial;'><b>No Record found </b></span></td>");
            sbHtml.Append("</tr>");

        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// Fraud Event Notes
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtFENotes"></param>
    private void GenerateFraudEventNotes(System.Text.StringBuilder sbHtml, DataTable dtFENotes)
    {
        if (dtFENotes.Rows.Count > 0)
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' ><span style='font-size: 14px; font-family: Arial;'><b>Date</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:75%' ><span style='font-size: 14px; font-family: Arial;'><b>Note Text</b></span></td>");
            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtFENotes.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%; word-wrap:normal;word-break:break-all' ><span style='font-size: 14px; font-family: Arial;'>" + clsGeneral.FormatDBNullDateToDisplay((dtFENotes.Rows[i]["Note_Date"])) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:75% word-wrap:normal;word-break:break-all' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFENotes.Rows[i]["Note"]) + "</span> </td>");
                sbHtml.Append("</tr>");
            }
        }
        else
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%' ><span style='font-size: 14px; font-family: Arial;'><b>No Record found </b></span></td>");
            sbHtml.Append("</tr>");

        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }



    /// <summary>
    /// Fraud Event Financial Risk Exposure Grid
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtFENotes"></param>
    private void GenerateFraudEventTransactionGrid(System.Text.StringBuilder sbHtml, DataTable dtFETransactionGrid)
    {
        if (dtFETransactionGrid.Rows.Count > 0)
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' ><span style='font-size: 14px; font-family: Arial;'><b>Type</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' ><span style='font-size: 14px; font-family: Arial;'><b>Date</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:30%' ><span style='font-size: 14px; font-family: Arial;'><b>Amount</b></span></td>");
            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtFETransactionGrid.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFETransactionGrid.Rows[i]["Type"]) + " " + Convert.ToString(dtFETransactionGrid.Rows[i]["Category"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%;' ><span style='font-size: 14px; font-family: Arial;'>" + clsGeneral.FormatDBNullDateToDisplay((dtFETransactionGrid.Rows[i]["Transaction_Date"])) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:30%' ><span style='font-size: 14px; font-family: Arial;'>" + string.Format("{0:C2}", Convert.ToString(dtFETransactionGrid.Rows[i]["Transaction_Amount"])) + "</span> </td>");
                sbHtml.Append("</tr>");
            }
        }
        else
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%' ><span style='font-size: 14px; font-family: Arial;'><b>No Record found </b></span></td>");
            sbHtml.Append("</tr>");

        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// Fraud Event Property Security Monitoring Grid
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtFENotes"></param>
    private void GeneratePropertySecurityMonitoringGrid(System.Text.StringBuilder sbHtml, DataTable dtFEMonitoringGrid)
    {
        if (dtFEMonitoringGrid.Rows.Count > 0)
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Day Monitoring Begins</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Time Monitoring Begins</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Day Monitoring Ends</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Time Monitoring Ends</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Hours</b></span></td>");

            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtFEMonitoringGrid.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFEMonitoringGrid.Rows[i]["Start_Day"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFEMonitoringGrid.Rows[i]["Start_Time"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFEMonitoringGrid.Rows[i]["End_Day"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFEMonitoringGrid.Rows[i]["End_Time"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtFEMonitoringGrid.Rows[i]["Hours"]) + "</span> </td>");
                sbHtml.Append("</tr>");
            }
        }
        else
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%' ><span style='font-size: 14px; font-family: Arial;'><b>No Record found </b></span></td>");
            sbHtml.Append("</tr>");

        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// DPD Witness
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtFENotes"></param>
    private void GenerateDPDWitnessGrid(System.Text.StringBuilder sbHtml, DataTable dtDPDWitnessGrid)
    {
        if (dtDPDWitnessGrid.Rows.Count > 0)
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Name</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Address</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Phone</b></span></td>");

            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtDPDWitnessGrid.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtDPDWitnessGrid.Rows[i]["Name"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtDPDWitnessGrid.Rows[i]["Address"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtDPDWitnessGrid.Rows[i]["Phone"]) + "</span> </td>");
                sbHtml.Append("</tr>");
            }
        }
        else
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%' ><span style='font-size: 14px; font-family: Arial;'><b>No Record found </b></span></td>");
            sbHtml.Append("</tr>");

        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// AL Witness
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtFENotes"></param>
    private void GenerateALWitnessGrid(System.Text.StringBuilder sbHtml, DataTable dtALWitnessGrid)
    {
        if (dtALWitnessGrid.Rows.Count > 0)
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Name</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Address</b></span></td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'><b>Phone</b></span></td>");

            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtALWitnessGrid.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top' align='center'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtALWitnessGrid.Rows[i]["Witness_Name"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%;' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtALWitnessGrid.Rows[i]["Witness_Address_1"]) + "</span> </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' ><span style='font-size: 14px; font-family: Arial;'>" + Convert.ToString(dtALWitnessGrid.Rows[i]["Witness_Work_Phone"]) + "</span> </td>");
                sbHtml.Append("</tr>");
            }
        }
        else
        {
            sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%' ><span style='font-size: 14px; font-family: Arial;'><b>No Record found </b></span></td>");
            sbHtml.Append("</tr>");

        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    #endregion
}