using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Incident_Incident : clsBasePage
{

    #region Property

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Incident
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Incident"]);
        }
        set { ViewState["PK_Incident"] = value; }
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

    #region Page Events

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PK_Incident = clsGeneral.GetQueryStringID(Request.QueryString["iid"]);
            StrOperation = Convert.ToString(Request.QueryString["mode"]);
            IsSearch = Convert.ToString(Request.QueryString["Search"]);
            FK_Location = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            BindGrid(1, 100);
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            if (IsSearch == "1")
            {
                btnReturnToAPModule.Text = "Return to Search";
            }

            if (PK_Incident > 0)
            {
                if (StrOperation.ToLower() == "view")
                {
                    BindDetailForView();
                }

                ucIncidentInfo.FillIncidentInformation(PK_Incident, 0, FK_Location);
                ucIncidentInfo.Visible = true;
            }

            ucIncidentTab.SetSelectedTab(Controls_IncidentTab_IncidentTab.Tab.Incident);
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        ucIncidentTab.SetSelectedTab(Controls_IncidentTab_IncidentTab.Tab.Incident);
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
    /// Bind Incident For View
    /// </summary>
    private void BindDetailForView()
    {
        dvView.Visible = true;
        clsIncident objclsIncident = new clsIncident(PK_Incident);
        if (PK_Incident > 0)
        {
            lblIncidentNo.Text = objclsIncident.Incident_Number;
            lblIncidentDate.Text = clsGeneral.FormatDBNullDateToDisplay(objclsIncident.Incident_Date);
            lblIncidentTime.Text = objclsIncident.Incident_Time;
            if (objclsIncident.FK_LU_Classification != null)
                lblClassification.Text = new LU_Classification((decimal)objclsIncident.FK_LU_Classification).Fld_Desc;
            else
                lblClassification.Text = "";
            lblIncident_Desc.Text = objclsIncident.Incident_Desc;
            lblDate_Opened.Text = clsGeneral.FormatDBNullDateToDisplay(objclsIncident.Date_Opened);

        }
    }

    /// <summary>
    /// Binds the Event grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        // selects records depending on paging criteria and search values.
        DataSet dsEvent = clsEvent.EventSearch(null, null, null, null, null, null, null, 0, 0, 0, 0, 0, null, null, null, null, null, null, null, null
                        , "Event_Number", "asc", PageNumber, PageSize, PK_Incident,null,null);
        DataTable dtEvent = dsEvent.Tables[0];
        CtrlPaging.TotalRecords = (dsEvent.Tables.Count >= 2) ? Convert.ToInt32(dsEvent.Tables[1].Rows[0][0]) : 0;
        CtrlPaging.CurrentPage = (dsEvent.Tables.Count >= 2) ? Convert.ToInt32(dsEvent.Tables[1].Rows[0][2]) : 0;
        CtrlPaging.RecordsToBeDisplayed = dsEvent.Tables[0].Rows.Count;
        CtrlPaging.SetPageNumbers();
        // bind the grid.
        gvEvent.DataSource = dtEvent;
        gvEvent.DataBind();

    }

    /// <summary>
    /// Handles event when links are clicked in the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
        //decimal FK_Incident = Convert.ToDecimal(strCommandArgument[1]);
        //decimal PK_Event = Convert.ToDecimal(strCommandArgument[0]);

        decimal FK_Incident = 0;
        decimal.TryParse(Convert.ToString(strCommandArgument[1]), out FK_Incident);
        decimal PK_Event = 0;
        decimal.TryParse(Convert.ToString(strCommandArgument[0]), out PK_Event);

        if (e.CommandName == "ViewEvent")
        {
            Response.Redirect("Event.aspx?iid=" + Encryption.Encrypt(Convert.ToString(FK_Incident)) + "&eid=" + Encryption.Encrypt(Convert.ToString(PK_Event)) + "&loc=" + Encryption.Encrypt(FK_Location.ToString()) + "&mode=view&Search=" + IsSearch, true);
        }
    }

    /// <summary>
    ///  Handle the pager control event
    /// </summary>
    protected void GetPage()
    {
        BindGrid(CtrlPaging.CurrentPage, CtrlPaging.PageSize);
    }

    #endregion

}