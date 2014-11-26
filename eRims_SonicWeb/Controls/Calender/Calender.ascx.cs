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

public partial class Controls_Calender : System.Web.UI.UserControl
{
    #region " Private Variable "
    private bool _IsRequiredField = false;
    private string _ErrorMessage = "";
    /// <summary>
    /// If True then it will in this contorl you can select date that is less than current date,else can't
    /// </summary>
    private bool _CompareCurrentDate = false;

    /// <summary>
    /// if this id is specified then value of textbox whose id is specified is considered as start date.
    /// and current control value is considered as end date. End Date >= Start Date.
    /// </summary>
    private string _StartDateClientId = "";

    /// <summary>
    /// message that appears when condition is violated for startdateclientid specified.
    /// </summary>
    private string _msgStartDate = "Error : No Message Specified";

    /// <summary>
    /// if this id is specified then value of textbox whose id is specified is considered as end date.
    /// and current control value is considered as start date. End Date >= Start Date.
    /// </summary>
    private string _EndDateClientId = "";

    /// <summary>
    /// message that appears when condition is violated for enddateclientid specified.
    /// </summary>
    private string _msgEndDate = "Error : No Message Specified";




    /// <summary>
    /// Date Format into which this control will display the date.
    /// </summary>
    private string DisplayDateFormat = AppConfig.DisplayDateFormat;


    private string UTFFormat = AppConfig.SQLDateFormat;

    private DateTime MinDate = Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString());

    #endregion

    # region " Private Function "

    /// <summary>
    /// If Valid Value is passed then it returns Valid Date after Parsing the date string.
    /// else it returns value with Minimumn value of DateTime Object.
    /// Used to Get DateTime object for Perticular Date in String.
    /// </summary>
    /// <param name="strDate">
    /// Value to be converted to DateTime.
    /// this date string must be in format Specified by DispalyDateFormat.
    /// </param>
    /// <returns>
    /// /// If Valid Value is passed then it returns Valid Date after Parsing the date string.
    /// else it returns value with Minimumn value of DateTime Object.
    /// </returns>
    private DateTime GetDateTimeFromString(string strDate)
    {
        DateTime dtTemp; // temp date time to get DateTime Value from string.
        DateTime.TryParseExact(strDate, DisplayDateFormat, System.Threading.Thread.CurrentThread.CurrentCulture, System.Globalization.DateTimeStyles.None, out dtTemp);
        // if strDate is blank or null or string can't be converted to date time then dtTemp will contain Min Value of Date Time.
        //return dtTemp; 
        if (dtTemp == DateTime.MinValue)
        {
            return MinDate;
        }
        else
        {
            return dtTemp;
        }
    }

    /// <summary>
    /// Used to Find Weather String can be successfully Converted to DateTime or not.
    /// it Considers Format Specified by DisplayDateFormat.
    /// </summary>
    /// <param name="strDate">Date String needed to be Checked for Valid Date Time.</param>
    /// <returns>True, if Valid DateTime else False</returns>
    private bool IsValidDateTime(string strDate)
    {
        if (GetDateTimeFromString(strDate) == MinDate)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Set Date in Text Box depending on Passed Value.
    /// Date Must be in Correct Format (DisplayDateFormat)
    /// </summary>
    /// <param name="strDate">Date To Be Set</param>
    private void SetDate(string strDate)
    {
        DateTime dtTemp = GetDateTimeFromString(strDate);
        if (dtTemp != MinDate)
        {
            TextBox_Text = dtTemp.ToString(DisplayDateFormat);
        }
        else
        {
            TextBox_Text = "";
        }
    }

    /// <summary>
    /// Set Date in Text Box depending on Passed Value.    
    /// </summary>
    /// <param name="strDate">Date To Be Set</param>
    private void SetDate(DateTime dt)
    {
        if (dt != MinDate)
        {
            TextBox_Text = clsGeneral.FormatDate(dt);
        }
    }

    /// <summary>
    /// Used to Get Selected Date String
    /// </summary>
    /// <returns></returns>
    private string GetDate()
    {
        string strDate = TextBox_Text;
        if (strDate.Length == 0)
        {
            return "";
        }
        DateTime dtTemp = GetDateTimeFromString(strDate);
        if (dtTemp != MinDate)
        {
            return dtTemp.ToString(DisplayDateFormat);
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// Used to Get Selected Date as DateTime
    /// </summary>
    /// <returns></returns>
    private DateTime GetDateValue()
    {
        string strDate = TextBox_Text;
        return GetDateTimeFromString(strDate);
    }

    /// <summary>
    /// Used To Get Selected Date in UTF Format String
    /// </summary>
    /// <returns></returns>
    private string GetDateUTF()
    {
        string strDate = TextBox_Text;
        if (strDate.Length == 0)
        {
            return "";
        }
        DateTime dtTemp = GetDateTimeFromString(strDate);
        if (dtTemp != MinDate)
        {
            return dtTemp.ToString(UTFFormat);
        }
        else
        {
            return "";
        }
    }

    #endregion

    # region " Private Property "
    public bool IsRequiredField
    {
        get { return _IsRequiredField; }
        set {_IsRequiredField =value ; }
    }

    public string ErrorMessage
    {
        get { return _ErrorMessage; }
        set {_ErrorMessage =value; }

    }
    /// <summary>
    /// Property to Get and Set TextBox Value - Date
    /// </summary>
    private string TextBox_Text
    {
        get
        {
            string strRetval = Request.Form[txtDate.ClientID.Replace("_", "$")];
            if (string.IsNullOrEmpty(strRetval))
            {
                strRetval = Request.Form[txtDate.ClientID];
                if (string.IsNullOrEmpty(strRetval))
                {
                    //return txtDate.Text;
                    return "";
                }
                else
                {
                    return strRetval;
                }
            }
            else
            {
                return strRetval;
            }
        }
        set { txtDate.Text =  value; }
    }

    #endregion

    # region " Public Control Property "
    string _RegularExpressionMessage = "";

    public string RegularExpressionMessage
    {
        get {return _RegularExpressionMessage; }
        set { _RegularExpressionMessage = value; }
    }
    public string OnFocusOutFunction
    {
        get { return Convert.ToString(ViewState["OnFocusOut"]); }
        set { ViewState["OnFocusOut"] = value; }
    }

    /// <summary>
    /// Gets or sets Selected DateTime as String.
    /// While setting value if value is not a valid date then value is not set.
    /// </summary>
    public string DateString
    {
        set { SetDate(value); }
        get { return GetDate(); }
    }

    /// <summary>
    /// Gets Selected DateTime as String in UTF Format    
    /// </summary>
    public string DateUTFString
    {
        get { return GetDateUTF(); }
    }

    /// <summary>
    /// Gets or sets Selected DateTime as DateTime value.
    /// While setting value if value is not a valid date then value is not set.
    /// </summary>
    public DateTime DateValue
    {
        set { SetDate(value); }
        get { return GetDateValue(); }
    }

    /// <summary>
    /// Gets or sets If DateTime is Mandetory field or not.    
    /// </summary>
    public bool IsRequired
    {
        get
        {
            return reqDate.Enabled;
        }
        set
        {
            reqDate.Enabled = value;
        }
    }

    /// <summary>
    /// Gets or sets TabIndex.    
    /// </summary>
    public short TabIndex
    {
        get
        {
            return txtDate.TabIndex;
        }
        set
        {
            txtDate.TabIndex = value;
        }
    }
    /// <summary>
    /// If True then it will in this contorl you can select date that is less than current date,else can't
    /// </summary>
    public bool CompareCurrentDate
    {
        get { return _CompareCurrentDate; }
        set { _CompareCurrentDate = value; }
    }

    ///// <summary>
    ///// If Readonly = Treu,don't allow option to select Date.
    ///// </summary>
    //public bool IsReadOnly
    //{
    //    get
    //    {
    //        return !imgCal.Visible;
    //    }
    //    set
    //    {
    //        imgCal.Visible = !value;
    //    }
    //}

    /// <summary>
    /// Client Id of text box,needed while comparision is needed to be done.
    /// </summary>
    public string TxtClientID
    {
        get { return txtDate.ClientID; }
    }

    /// <summary>
    /// Client ID of required field validator to enable or disable
    /// </summary>
    public string ReqFieldClientID
    {
        get { return reqDate.ClientID; }
    }
    /// <summary>
    /// if this id is specified then value of textbox whose id is specified is considered as start date.
    /// and current control value is considered as end date. End Date >= Start Date.
    /// </summary>
    public string StartDateClientId
    {
        get { return _StartDateClientId; }
        set { _StartDateClientId = value; }
    }

    public string MsgStartDate
    {
        get { return _msgStartDate; }
        set { _msgStartDate = value; }
    }

    public string EndDateClientId
    {
        get { return _EndDateClientId; }
        set { _EndDateClientId = value; }
    }


    public string MsgEndDate
    {
        get { return _msgEndDate; }
        set { _msgEndDate = value; }
    }


    ///////// <summary>
    ///////// Format in which date should be displayed.
    ///////// </summary>
    //////public string DisplayDateFormat
    //////{
    //////    get
    //////    {
    //////        return _DisplayDateFormat; 
    //////    }
    //////    set
    //////    {
    //////        _DisplayDateFormat = value;
    //////    }
    //////}

    # endregion

    # region "Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        //Set Error Message
        reqDate.ErrorMessage = _ErrorMessage;
        revCal.ErrorMessage = _RegularExpressionMessage;
        reqDate.Enabled = _IsRequiredField;
        //// register the javascript.
        if (this.Page.ClientScript.IsClientScriptIncludeRegistered("keyJS") == false)
        {
            this.Page.ClientScript.RegisterClientScriptInclude("keyJS", AppConfig.SiteURL + "JavaScript/calendar.js");
            this.Page.ClientScript.RegisterClientScriptInclude("keyJS", AppConfig.SiteURL + "JavaScript/Calendar_new.js");
            this.Page.ClientScript.RegisterClientScriptInclude("keyJS", AppConfig.SiteURL + "JavaScript/calendar-en.js");
            this.Page.ClientScript.RegisterClientScriptInclude("keyJS", AppConfig.SiteURL + "JavaScript/Calendar.js");
        }
         //txtDate.Attributes.Add("onchange", "javascript:alert('Test')");

        //// register the Style Sheet Link
        //if (this.Page.ClientScript.IsClientScriptBlockRegistered(typeof(string), "keyCSS") == false)
        //{

        //    this.Page.ClientScript.RegisterClientScriptBlock(typeof(string), "keyCSS", "<link href='" + AppConfig.SiteURL + "Controls/Calender/StyleSheet.css' rel='stylesheet' type='text/css'/>");
        //}
        //if (!this.Page.IsPostBack)
        //{
            
        //    // validation for date entered by user manually..
        //    txtDate.Attributes.Add("onkeypress", "javascript:return FormatDate(event,'" + txtDate.ClientID + "');");
        //    txtDate.Attributes.Add("onblur", "javascript:return CheckValidDate('" + txtDate.ClientID + "','" + this.CompareCurrentDate.ToString() + "','" + this.StartDateClientId + "','" + this.MsgStartDate + "','" + this.EndDateClientId + "','" + this.MsgEndDate + "','" + this.DisplayDateFormat.ToLower() + "');");
        //    if (OnFocusOutFunction != string.Empty)
        //    {
        //        txtDate.Attributes.Add("onfocusout", "javascript:if (CheckValidDate('" + txtDate.ClientID + "','" + this.CompareCurrentDate.ToString() + "','" + this.StartDateClientId + "','" + this.MsgStartDate + "','" + this.EndDateClientId + "','" + this.MsgEndDate + "','" + this.DisplayDateFormat.ToLower() + "')) {" + OnFocusOutFunction + "}");
        //    }
        //    //Set Select and Clear Button Click
        //    imgCal.Attributes.Add("onclick", "javascript:OpenCalender('" + this.txtDate.ClientID + "','dvComments',event,'" + this.CompareCurrentDate.ToString() + "','" + this.StartDateClientId + "','" + this.MsgStartDate + "','" + this.EndDateClientId + "','" + this.MsgEndDate + "','" + this.DisplayDateFormat.ToLower() + "');");            
        //}
        //else
        //{
        //    SetDate(TextBox_Text); // this will set date to previous state in case of postback
        //}
    }

    #endregion
}
