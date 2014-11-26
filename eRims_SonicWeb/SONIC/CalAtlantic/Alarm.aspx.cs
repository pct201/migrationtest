using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.IO;
using System.Data;

public partial class Alarm_Alarm : clsBasePage
{

    #region Properties

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Alarm_Location
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Alarm_Location"]);
        }
        set { ViewState["PK_Alarm_Location"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Exposure_Alarms
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Exposure_Alarms"]);
        }
        set { ViewState["PK_Exposure_Alarms"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal FK_Incident
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Incident"]);
        }
        set { ViewState["FK_Incident"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal FK_Event
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Event"]);
        }
        set { ViewState["FK_Event"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether come from Search
    /// </summary>
    public string IsSearch
    {
        get { return ViewState["IsSearch"] != null ? Convert.ToString(ViewState["IsSearch"]) : ""; }
        set { ViewState["IsSearch"] = value; }
    }

    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_Location
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Location"]);
        }
        set { ViewState["FK_Location"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return ViewState["StrOperation"] != null ? Convert.ToString(ViewState["StrOperation"]) : "view"; }
        set { ViewState["StrOperation"] = value; }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Event Call on Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FK_Event = clsGeneral.GetQueryStringID(Request.QueryString["eid"]);
            FK_Incident = clsGeneral.GetQueryStringID(Request.QueryString["iid"]);
            StrOperation = Convert.ToString(Request.QueryString["mode"]);
            IsSearch = Convert.ToString(Request.QueryString["Search"]);
            FK_Location = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            if (IsSearch == "1")
            {
                btnReturnToAPModule.Text = "Return to Search";
            }
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            if (StrOperation == "add") Session.Remove("Alarmcriteria");
            if (FK_Event > 0)
            {
                dvView.Visible = true;
                BindGrid(CtrlPaging.CurrentPage, CtrlPaging.PageSize);
                ucIncidentInfo.Visible = true;
                ucIncidentInfo.FillIncidentInformation(FK_Incident, FK_Event, FK_Location);
            }
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        ucIncidentTab.SetSelectedTab(Controls_IncidentTab_IncidentTab.Tab.Alarm);
    }

    /// <summary>
    /// Event Called When User change Tab
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPreviousStep_Click(object sender, EventArgs e)
    {
        Response.Redirect("Event.aspx?iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&eid=" + Encryption.Encrypt(FK_Event.ToString()) + "&loc=" + Encryption.Encrypt(FK_Location.ToString()) + "&mode=" + StrOperation + "&Search=" + IsSearch, true);

    }

    /// <summary>
    /// Back to Asset Protection Module
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturnToAPModule_Click(object sender, EventArgs e)
    {
        if (IsSearch == "1")
        {
            Response.Redirect("EventSearch.aspx?loc=" + Encryption.Encrypt(FK_Location.ToString()));
        }
        else
        {
            Response.Redirect("../Exposures/Asset_Protection.aspx?loc=" + Encryption.Encrypt(FK_Location.ToString()) + "&pnl=" + 4);
        }
    }

    #endregion

    #region Page Methods

    /// <summary>
    /// Bind Alarm Detail for View
    /// </summary>
    private void BindDetailForView()
    {
        dvView.Visible = true;
        clsExposure_Alarms objExposure_Alarms = new clsExposure_Alarms(PK_Exposure_Alarms);

        if (PK_Exposure_Alarms > 0)
        {
            PK_Alarm_Location = Convert.ToDecimal(objExposure_Alarms.FK_Alarm_Location);
            FK_Event = Convert.ToDecimal(objExposure_Alarms.FK_Event);

            if (objExposure_Alarms.FK_LU_Alarm_Type != null)
                lblAlarmType.Text = new LU_Alarm_Type((decimal)objExposure_Alarms.FK_LU_Alarm_Type).Fld_Desc;
            else
                lblAlarmType.Text = "";

            lblAlarmNo.Text = objExposure_Alarms.Alarm_Number;
            lblAlarmDate.Text = clsGeneral.FormatDBNullDateToDisplay(objExposure_Alarms.Alarm_Date);
            lblAlarmTime.Text = objExposure_Alarms.Time_Of_Alarm;
            lblCamaraNo.Text = objExposure_Alarms.Camera_Number;
            lblCamaraName.Text = objExposure_Alarms.Camera_Name;
            lblOperator.Text = objExposure_Alarms.Operator_First_Name + " " + objExposure_Alarms.Operator_Last_name;
            if (objExposure_Alarms.FK_LU_Camera_Type != null)
                lblCamaraType.Text = new LU_Camera_Type((decimal)objExposure_Alarms.FK_LU_Camera_Type).Fld_Desc;
            else
                lblCamaraType.Text = "";

            lblImageDescription.Text = objExposure_Alarms.Description;

            if (objExposure_Alarms.FK_LU_Action_Type != null)
                lblActionType.Text = new LU_Action_Type((decimal)objExposure_Alarms.FK_LU_Action_Type).Fld_Desc;
            else
                lblActionType.Text = "";
            if (objExposure_Alarms.FK_LU_Alarm_Action != null)
                lblActions.Text = new LU_Alarm_Action((decimal)objExposure_Alarms.FK_LU_Alarm_Action).Fld_Desc;
            else
                lblActions.Text = "";
            if (objExposure_Alarms.FK_LU_Alarm_Person != null)
                lblPerson.Text = new LU_Alarm_Person((decimal)objExposure_Alarms.FK_LU_Alarm_Person).Fld_Desc;
            else
                lblPerson.Text = "";
            if (objExposure_Alarms.FK_LU_Alarm_Vehicle != null)
                lblVehicle.Text = new LU_Alarm_Vehicle((decimal)objExposure_Alarms.FK_LU_Alarm_Vehicle).Fld_Desc;
            else
                lblVehicle.Text = "";
            if (objExposure_Alarms.FK_LU_Alarm_Environmental != null)
                lblEnvironmental.Text = new LU_Alarm_Environmental((decimal)objExposure_Alarms.FK_LU_Alarm_Environmental).Fld_Desc;
            else
                lblEnvironmental.Text = "";
            if (objExposure_Alarms.FK_LU_Client_Caused != null)
                lblClientCaused.Text = new LU_Client_Caused((decimal)objExposure_Alarms.FK_LU_Client_Caused).Fld_Desc;
            else
                lblClientCaused.Text = "";
            if (objExposure_Alarms.FK_LU_Equipment_Malfunction != null)
                lblEquipmentMalfunction.Text = new LU_Equipment_Malfunction((decimal)objExposure_Alarms.FK_LU_Equipment_Malfunction).Fld_Desc;
            else
                lblEquipmentMalfunction.Text = "";

            lblBuilding.Text = objExposure_Alarms.Building_Number;

            #region Image
            string _strSiteURL;
            string _strSitePath;
            _strSiteURL = String.Concat(HttpContext.Current.Request.Url.Scheme + "://", HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath);
            if (!_strSiteURL.EndsWith("/")) _strSiteURL = String.Concat(_strSiteURL, "/");
            _strSitePath = String.Concat(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath), @"\");

            //_strSiteURL = _strSiteURL.Replace("localhost", "192.168.0.118");
            string AttachmentDocPath = "Documents/asset_protection_Docs/images";
            string DocPath = string.Concat(_strSiteURL, AttachmentDocPath) + "/";
            if (objExposure_Alarms.Image_Name != null)
            {
                if (File.Exists(_strSitePath + AttachmentDocPath + "/" + objExposure_Alarms.Image_Name))
                {
                    lnkbtnImageView.Visible = true;
                    lnkbtnImageView.OnClientClick = "javascript:return openWindow('" + DocPath + objExposure_Alarms.Image_Name + "');";
                }
                else
                {
                    lnkbtnImageView.Visible = false;
                    lnkbtnImageView.OnClientClick = "javascript:return false;";
                }
            }

            else
            {
                lnkbtnImageView.Visible = false;
                lnkbtnImageView.OnClientClick = "javascript:return false;";
            }

            #endregion

            lblOther.Text = objExposure_Alarms.Other;
            chkIsfaultPositive_View.Checked = Convert.ToBoolean(objExposure_Alarms.FalsePositive);

            lblLastModifiedDateTime.Text = objExposure_Alarms.Update_Date == null ? "" : "Last Modified Date/Time : " + objExposure_Alarms.Update_Date.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + " ";
            //BindGrid(CtrlPaging.CurrentPage, CtrlPaging.PageSize);

        }

        clsAlarm_Location objAlarm_Location = new clsAlarm_Location(PK_Alarm_Location);

        if (PK_Alarm_Location > 0)
        {

            if (objAlarm_Location.FK_LU_Company != null)
                lblCompany.Text = new clsLU_Company((decimal)objAlarm_Location.FK_LU_Company).Fld_Desc;
            else
                lblCompany.Text = "";

            lbllocation.Text = objAlarm_Location.Name;

            lblAddress1.Text = objAlarm_Location.Address_1;
            lblAddress2.Text = objAlarm_Location.Address_2;
            lblCity.Text = objAlarm_Location.City;
            if (objAlarm_Location.FK_LU_State != null)
                lblState.Text = new State((decimal)objAlarm_Location.FK_LU_State).FLD_state;
            else
                lblState.Text = "";
            lblZipCode.Text = objAlarm_Location.ZIP;
            lblCountry.Text = objAlarm_Location.Country;
            //lblBuilding.Text = objAlarm_Location.Building;
            lblContactName.Text = objAlarm_Location.Contact_Name;
            lblContactPhone.Text = objAlarm_Location.Contact_Telephone;
            lblContactEmail.Text = objAlarm_Location.Contact_Email;
            lblSiteCode.Text = objAlarm_Location.Site_Code;


        }

    }

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {

        // selects records depending on paging criteria and search values.
        DataSet dsAlarm = clsExposure_Alarms.AlarmSearch(null, null, null, null, null, 0, 0, 0, 0, 0, null, null, null, null, "Alarm_Number", "asc", PageNumber, PageSize, FK_Event);
        DataTable dtAlarm = dsAlarm.Tables[0];
        CtrlPaging.TotalRecords = (dsAlarm.Tables.Count >= 2) ? Convert.ToInt32(dsAlarm.Tables[1].Rows[0][0]) : 0;
        CtrlPaging.CurrentPage = (dsAlarm.Tables.Count >= 2) ? Convert.ToInt32(dsAlarm.Tables[1].Rows[0][2]) : 0;
        CtrlPaging.RecordsToBeDisplayed = dsAlarm.Tables[0].Rows.Count;
        CtrlPaging.SetPageNumbers();

        // bind the grid.
        gvAlarm.DataSource = dtAlarm;
        gvAlarm.DataBind();

    }

    /// <summary>
    /// Handles event when links are clicked in the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAlarm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
        //decimal dsFK_Incident = Convert.ToDecimal(strCommandArgument[1]);
        //decimal dsFK_Event = Convert.ToDecimal(strCommandArgument[0]);
        //decimal dsPK_Exposure_Alarms = Convert.ToDecimal(strCommandArgument[2]);

        decimal dsFK_Incident = 0;
        decimal.TryParse(Convert.ToString(strCommandArgument[1]), out dsFK_Incident);
        decimal dsFK_Event = 0;
        decimal.TryParse(Convert.ToString(strCommandArgument[0]), out dsFK_Event);
        decimal dsPK_Exposure_Alarms = 0;
        decimal.TryParse(Convert.ToString(strCommandArgument[2]), out dsPK_Exposure_Alarms);


        if (e.CommandName == "ViewAlarm")
        {
            PK_Exposure_Alarms = dsPK_Exposure_Alarms;
            BindDetailForView();
        }
    }

    /// <summary>
    /// To handle pager control event
    /// </summary>
    protected void GetPage()
    {
        BindGrid(CtrlPaging.CurrentPage, CtrlPaging.PageSize);
    }

    #endregion

}

