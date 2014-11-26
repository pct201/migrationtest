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
 * File Name:		DealershipsByCounty.aspx
 *								  
 * Description:		This page is used for display map for the number of locations at Sonic by state by county. 
 *                  For display Map FusionMas tool is used. 
 *                  
 **************************************************************************************************************************************/
public partial class DashBoard_DealershipsByCounty : clsBasePage
{
    #region "Declaration"

    /// <summary>
    /// property for state Parameter
    /// </summary>
    public string StateName
    {
        get
        {
            return Request.QueryString["state"].ToString();
        }
    }

    /// <summary>
    /// property for MapName Parameter
    /// </summary>
    public string MapName
    {
        get
        {
            return Request.QueryString["mp_id"].ToString();
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["state"]) && !string.IsNullOrEmpty(Request.QueryString["mp_id"]))
                USStateMap.Text = FusionMaps.RenderMap(AppConfig.SiteURL + "FusionMaps/" + MapName, "", GetStateMap(), "MapForCounty", "997", StateName.ToUpper() == "TX" ? "500" : "450", false, false);
        }
    }

    /// <summary>
    /// Generate XML String Data for Map from database
    /// </summary>
    /// <returns></returns>
    private string GetStateMap()
    {
        DataTable dtState = null;
        dtState = Maps.GetSonicDealershipsByCounty(StateName.ToString());

        System.Text.StringBuilder strXML = new System.Text.StringBuilder();

        strXML.Append("<map borderColor='e3e3e3' fillAlpha='80' fillColor='ffffcc' useHoverColor='1' hoverColor='FFFFFF' showBevel='0' legendBorderColor='F1f1f1' legendPosition='right' animation='0'");
        strXML.Append("legendAllowDrag='1' useHoverColor='1' legendCaption='Number of Dealerships' legendBorderColor='000000' showCanvasBorder='0' mapTopMargin='1' showShadow='0' markerBorderColor='fff000'>");

        // Color Setting for Legend
        strXML.Append("<colorRange>");
        strXML.Append("<color minValue='0' maxValue='0.9' maxValue='0' displayValue='None' color='ffff88' />");
        strXML.Append("<color minValue='1' maxValue='5.9' displayValue='1 to 5' color='d2b48c' />");
        strXML.Append("<color minValue='6' maxValue='10.9' displayValue='6 to 10' color='d4bae7' />");
        strXML.Append("<color minValue='11'maxValue='20.9' displayValue='11 to 20' color='edcfdf' />");
        strXML.Append("<color minValue='21'maxValue='30.9'  displayValue='21 to 30' color='8f8bd7' />");
        strXML.Append("<color minValue='31' maxValue='" + Int64.MaxValue + "' displayValue='31 or more' color='9ebdec' />");
        strXML.Append("</colorRange>");

        strXML.Append("<data>");
        string strLink;
        if (dtState.Rows.Count > 0)
            lblheader.Text = "Sonic Dealerships By County for " + dtState.Rows[0]["state"].ToString() + " (" + dtState.Rows[0]["State_Abbreviation"].ToString() + ")";

        //foreach (DataRow dr in dtState.Rows)
        //    strXML.AppendFormat("<entity id='{0}' value='{1}' />", dr["FIPS_County"].ToString(), Convert.ToInt32(dr["Total"]));

        foreach (DataRow dr in dtState.Rows)
        {
            strLink = Server.UrlEncode("javascript:OpenSonicLocation(\"" + Encryption.Encrypt(dr["Pk_State"].ToString()) + "\",\"" + Encryption.Encrypt(dr["FIPS_County"].ToString()) + "\",\"" + Encryption.Encrypt(dr["State"].ToString()) + "\",\"" + Encryption.Encrypt(dr["County"].ToString()) + "\");");
            strXML.AppendFormat("<entity id='{0}' value='{1}' link='{2}' />", dr["FIPS_County"].ToString(), Convert.ToInt32(dr["Total"]), strLink);
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
}
