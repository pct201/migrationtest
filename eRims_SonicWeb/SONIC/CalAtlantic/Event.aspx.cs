using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Event_Event : clsBasePage
{

    #region Properties

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Event
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Event"]);
        }
        set { ViewState["PK_Event"] = value; }
    }

    /// <summary>
    /// Denotes the Foreign Key
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
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return ViewState["StrOperation"] != null ? Convert.ToString(ViewState["StrOperation"]) : "view"; }
        set { ViewState["StrOperation"] = value; }
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

    #endregion

    #region Page Event

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PK_Event = clsGeneral.GetQueryStringID(Request.QueryString["eid"]);
            FK_Incident = clsGeneral.GetQueryStringID(Request.QueryString["iid"]);
            StrOperation = Convert.ToString(Request.QueryString["mode"]);
            IsSearch = Convert.ToString(Request.QueryString["Search"]);
            FK_Location = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            if (IsSearch == "1")
            {
                btnReturnToAPModule.Text = "Return to Search";
            }
            if (PK_Event > 0)
            {
                BindDetailForView();
                ucIncidentInfo.FillIncidentInformation(FK_Incident, PK_Event, FK_Location);
            }
        }
        ucIncidentInfo.FillIncidentInformation(FK_Incident, PK_Event, FK_Location);
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        ucIncident.SetSelectedTab(Controls_IncidentTab_IncidentTab.Tab.Event);
    }

    /// <summary>
    /// Event Call when user press Next Step Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        Response.Redirect("Alarm.aspx?iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&eid=" + Encryption.Encrypt(PK_Event.ToString()) + "&loc=" + Encryption.Encrypt(FK_Location.ToString()) + "&mode=" + StrOperation + "&Search=" + IsSearch);

    }

    /// <summary>
    /// Event Called When User change Tab
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPreviousStep_Click(object sender, EventArgs e)
    {
        Response.Redirect("Incident.aspx?iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&loc=" + Encryption.Encrypt(FK_Location.ToString()) + "&mode=" + StrOperation + "&Search=" + IsSearch, true);
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
    /// Event Called When Page is open in View Mode
    /// </summary>
    private void BindDetailForView()
    {
        dvView.Visible = true;
        clsEvent objEvent = new clsEvent(PK_Event);
        if (PK_Event > 0)
        {
            //Event
            if (objEvent.FK_Incident != null)
            {
                FK_Incident = Convert.ToDecimal(objEvent.FK_Incident);
                if (clsGeneral.GetQueryStringID(Request.QueryString["iid"]) < 1)
                {
                    Response.Redirect("Event.aspx?iid=" + Encryption.Encrypt(Convert.ToString(FK_Incident)) + "&eid=" + Encryption.Encrypt(Convert.ToString(PK_Event)) + "&loc=" + Encryption.Encrypt(FK_Location.ToString()) + "&mode=view&Search=" + IsSearch, true);
                }
            }

            lblEventNumber.Text = Convert.ToString(objEvent.Event_Number);
            if (objEvent.FK_LU_Event_Type != null)
                lblEventType.Text = new clsLU_Event_Type((decimal)objEvent.FK_LU_Event_Type).Fld_Desc;
            else
                lblEventType.Text = "";

            lblEventReportDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Report_Date);
            lblEventOccuranceDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Occurence_Date);
            lblInvestigationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Investigation_Report_Date);
            lblDateSendToClient.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Sent);
            //lblEvent_Desc.Text = objEvent.Event_Desc != null ? objEvent.Event_Desc : "";
            if (objEvent.FK_LU_Event_Description != null)
                lblEvent_Desc.Text = new clsLU_Event_Description((decimal)objEvent.FK_LU_Event_Description).Fld_Desc;
            else
                lblEvent_Desc.Text = "";

            lblDate_Opened.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Opened);

            //Event Company Information
            lblCompanyName.Text = objEvent.Company != null ? objEvent.Company : "";
            if (objEvent.FK_LU_Location != null)
                lblCompanyLocation.Text = new clsCal_Atlantic_LU_Location((decimal)objEvent.FK_LU_Location).Fld_Desc;
            else
                lblCompanyLocation.Text = "";
            lblCompanyAddress1.Text = objEvent.Company_Address_1 != null ? objEvent.Company_Address_1 : "";
            lblCompanyAddress2.Text = objEvent.Company_Address_2 != null ? objEvent.Company_Address_2 : "";
            lblCompanyCity.Text = objEvent.Company_City != null ? objEvent.Company_City : "";
            if (objEvent.FK_LU_State != null)
                lblCompanyState.Text = new State((decimal)objEvent.FK_LU_State).FLD_state;
            else
                lblCompanyState.Text = "";

            lblCompanyZipCode.Text = objEvent.Company_ZIP != null ? objEvent.Company_ZIP : "";
            lblCompanyCountry.Text = objEvent.Company_County != null ? objEvent.Company_County : "";
            lblCompanyContactFirstName.Text = objEvent.Company_Contact_First_Name != null ? objEvent.Company_Contact_First_Name : "";
            lblCompanyContactMiddleName.Text = objEvent.Company_Contact_Middle_name != null ? objEvent.Company_Contact_Middle_name : "";
            lblCompanContactLastName.Text = objEvent.Company_Contact_Last_Name != null ? objEvent.Company_Contact_Last_Name : "";

            lblCompanyPhone.Text = objEvent.Company_Contact_Phone != null ? objEvent.Company_Contact_Phone : "";
            lblComapnyEmail.Text = objEvent.Company_Contact_Email != null ? objEvent.Company_Contact_Email : "";
            lblComapnyEmail.Text = objEvent.Company_Contact_Email != null ? objEvent.Company_Contact_Email : "";
            lblCompanyFax.Text = objEvent.Company_Contact_Fax != null ? objEvent.Company_Contact_Fax : "";

            //Event Vehicle Information
            lblVehicleNo.Text = objEvent.Vehicle_Number != null ? objEvent.Vehicle_Number : "";
            lblVIN.Text = objEvent.VIN != null ? objEvent.VIN : "";
            lblVehicleMake.Text = objEvent.Make != null ? objEvent.Make : "";
            lblVehicleModel.Text = objEvent.Model != null ? objEvent.Model : "";
            lblVehicleYear.Text = objEvent.Year != null ? objEvent.Year : "";
            lblCompanyTiled.Text = objEvent.Company_Titled != null ? objEvent.Company_Titled : "";
            lblLicenseTag.Text = objEvent.License_Tag != null ? objEvent.License_Tag : "";

            if (objEvent.FK_LU_State_Registered != null)
                lblVehicleStateRegistered.Text = new State((decimal)objEvent.FK_LU_State_Registered).FLD_state;
            else
                lblVehicleStateRegistered.Text = "";

            //Event Police Information
            lblPoliceDeptName.Text = objEvent.Police_Dept_Name != null ? objEvent.Police_Dept_Name : "";
            lblPolicePhone.Text = objEvent.Police_Phone != null ? objEvent.Police_Phone : "";
            lblOfficeFirstName.Text = objEvent.Police_Contact_First_Name != null ? objEvent.Police_Contact_First_Name : "";
            lblOfficerMiddleName.Text = objEvent.Police_Contact_Middle_name != null ? objEvent.Police_Contact_Middle_name : "";
            lblOfficerLastName.Text = objEvent.Police_Contact_Last_Name != null ? objEvent.Police_Contact_Last_Name : "";
            lblBadgeNo.Text = objEvent.Badge_Number != null ? objEvent.Badge_Number : "";
            lblPoliceFax.Text = objEvent.Facsimile != null ? objEvent.Facsimile : "";
            lblPoliceCellPhone.Text = objEvent.Police_Contact_Cell_Phone != null ? objEvent.Police_Contact_Cell_Phone : "";
            lblPoliceCity.Text = objEvent.Police_Contact_City != null ? objEvent.Police_Contact_City : "";
            lblPoliceAddress1.Text = objEvent.Address_1 != null ? objEvent.Address_1 : "";

            if (objEvent.FK_LU_Police_Dept_State != null)
                lblPoliceState.Text = new State((decimal)objEvent.FK_LU_Police_Dept_State).FLD_state;
            else
                lblPoliceState.Text = "";

            lblPoliceAddress2.Text = objEvent.Address_2 != null ? objEvent.Address_2 : "";
            lblPoliceZip.Text = objEvent.ZIP != null ? objEvent.ZIP : "";
            lblJurisdiction.Text = objEvent.Jurisdiction != null ? objEvent.Jurisdiction : "";
            lblPoliceReportNumber.Text = objEvent.Police_Report_Number != null ? objEvent.Police_Report_Number : "";
            lblPoliceCardNo.Text = objEvent.Case_Number != null ? objEvent.Case_Number : "";
            lblPoliceReportOrderedDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Report_Ordered_Date);
            lblPoliceReportReceivedDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Report_Recieved_Date);
            lblLastModifiedDateTime.Text = objEvent.Update_Date == null ? "" : "Last Modified Date/Time : " + objEvent.Update_Date.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + " ";



        }
    }

    #endregion

}