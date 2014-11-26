using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;
using InfoSoftGlobal;

/**************************************************************************************************************************************
 * File Name:		DashBoard.aspx
 *								  
 * Description:		This page is used for display map with drill down function to display the number of locations at Sonic by state 
 *                  and by county. For display Map FusionMas tool is used. 
 *                  
 **************************************************************************************************************************************/
public partial class DashBoard : clsBasePage
{
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            USStateMap.Text = FusionMaps.RenderMap(AppConfig.SiteURL + "FusionMaps/FCMap_USA.swf", "", GetStateMap(), "MapForState", "997", "500", false, false);

            if (Request.QueryString["IsLogin"] != null)
            {
                if (Request.QueryString["IsLogin"].ToString() == "yes")
                {

                    DataSet dsReportID = First_Report_Wizard.SelectWizardWithUncompleteReport(Convert.ToDecimal(clsSession.CurrentLoginEmployeeId));
                    if (dsReportID.Tables[0].Rows.Count > 0)
                    {
                        //ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:OpenWizardPopup();", true);
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:OpenWizardPopup();", true);
                    }
                }
            }

        }
    }

    /// <summary>
    /// Get State Map
    /// </summary>
    /// <returns></returns>
    private string GetStateMap()
    {
        DataTable dtState = null;
        dtState = Maps.GetSonicDealershipsByState();

        System.Text.StringBuilder strXML = new System.Text.StringBuilder();

        strXML.Append("<map borderColor='e3e3e3' fillAlpha='80' fillColor='ffffcc' useHoverColor='1' hoverColor='FFFFFF' showBevel='0' legendBorderColor='F1f1f1' legendPosition='right' animation='0'");
        strXML.Append("legendAllowDrag='1' useHoverColor='1' legendCaption='Number of Dealerships' legendBorderColor='000000' showCanvasBorder='0' mapTopMargin='1' showShadow='0' markerBorderColor='fff000'>");

        // Color Setting for Legend
        strXML.Append("<colorRange>");
        strXML.Append("<color minValue='0'  maxValue='0.9'  displayValue='None' color='ffff88' />");
        strXML.Append("<color minValue='1'  maxValue='5.9'  displayValue='1 to 5' color='d2b48c' />");
        strXML.Append("<color minValue='6'  maxValue='10.9' displayValue='6 to 10' color='d4bae7' />");
        strXML.Append("<color minValue='11' maxValue='20.9' displayValue='11 to 20' color='edcfdf' />");
        strXML.Append("<color minValue='21' maxValue='30.9' displayValue='21 to 30' color='8f8bd7' />");
        strXML.Append("<color minValue='31' maxValue='" + Int64.MaxValue + "' displayValue='31 or more' color='9ebdec' />");
        strXML.Append("</colorRange>");

        strXML.Append("<data>");

        // set value and id for entity
        string strLink;

        foreach (DataRow dr in dtState.Rows)
        {
            //strLink = HttpUtility.UrlEncode("P-detailsPopUp,width=700,height=400,toolbar=no, scrollbars=no,resizable=no-DashBoard.aspx?state=" + dr["State_Abbreviation"]);
            strLink = Server.UrlEncode("javascript:OpenRegionMap(\"" + dr["State_Abbreviation"].ToString() + "\",\"" + dr["map_swf"].ToString() + "\");");
            strXML.AppendFormat("<entity id='{0}' value='{1}' link='{2}' />", dr["State_Abbreviation"].ToString(), Convert.ToInt32(dr["Total"]), strLink);
        }

        strXML.Append("</data>");

        strXML.Append("<styles>");
        strXML.Append("<definition>");
        strXML.Append("<style type='animation' name='animX' param='_xscale' start='0' duration='1' />");
        strXML.Append("<style type='animation' name='animY' param='_yscale' start='0' duration='1' />");
        strXML.Append("<style type='animation' name='animAlpha' param='_alpha' start='0' duration='1' />");
        strXML.Append("<style type='shadow' name='myShadow' color='FFFFFF' distance='1' />");
        strXML.Append("</definition>");
        strXML.Append("<application>");
        strXML.Append("<apply toObject='PLOT' styles='animX,animY' />");
        strXML.Append("<apply toObject='LABELS' styles='myShadow,animAlpha' />");
        strXML.Append("</application>");
        strXML.Append("</styles>");

        strXML.Append("</map>");

        return strXML.ToString();
    }

    /// <summary>
    /// Button Click Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnHdnStatusPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReport/FirstReportStatus.aspx");
    }

}
