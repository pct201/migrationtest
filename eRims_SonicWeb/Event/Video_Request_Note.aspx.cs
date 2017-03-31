using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Event_Video_Request_Note : System.Web.UI.Page
{
    #region Properties
    /// <summary>
    /// Denotes the Foreign Key of Event
    /// </summary>
    public decimal FK_Event_Video_Tracking_Request
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }
    }

    /// <summary>
    /// Denotes list of primary key of Event
    /// </summary>
    public string VideoNoteIDs
    {
        get { return clsGeneral.IsNull(ViewState["VideoNoteIDs"]) ? string.Empty : Convert.ToString(ViewState["VideoNoteIDs"]); }
        set { ViewState["VideoNoteIDs"] = value; }
    }


    /// <summary>
    /// Denotes the Foreign Key of Event
    /// </summary>
    public decimal PK_Notes
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["nid"]) ? Convert.ToInt32(Request.QueryString["nid"]) : -1); }
    }



    /// <summary>
    /// Denotes the Type whether ACI or SONIC
    /// </summary>
    public string _Type
    {
        get { return ViewState["Type"] != null ? Convert.ToString(ViewState["Type"]) : "ACI"; }
        set { ViewState["Type"] = value; }
    }


    #endregion

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _Type = Request.QueryString["type"].ToUpper();

            lblListNoteType.Text = "Video Request Note";

            if (!string.IsNullOrEmpty(Request.QueryString["viewIDs"]))
            {
                #region " List Notes "
                VideoNoteIDs = Request.QueryString["viewIDs"];

                rptNotes.DataSource = clsVideo_Request_Notes.SelectByIDs(VideoNoteIDs);

                rptNotes.DataBind();

                dvNotesList.Style["display"] = "block";
                dvView.Style["display"] = "none";
                //trButtons.Style["display"] = "none";

                #endregion
            }
            else if (!string.IsNullOrEmpty(_Type) && _Type.ToLower().Contains("view"))
            {
                #region "List of All Notes"
                rptNotes.DataSource = clsVideo_Request_Notes.SelectByFK_Event_Video_Tracking_Request(FK_Event_Video_Tracking_Request);

                rptNotes.DataBind();
                dvNotesList.Style["display"] = "block";
                dvView.Style["display"] = "none";
                #endregion
            }
            else if (FK_Event_Video_Tracking_Request > 0 && PK_Notes > 0)
            {
                BindNoteDetails();
                BindVideoDetail();
                dvNotesList.Style["display"] = "none";
                dvView.Style["display"] = "block";
            }
            else
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
        }
    }
    #endregion

    #region Method
    private void BindVideoDetail()
    {
        clsEvent_Video_Tracking_Request objVideo = new clsEvent_Video_Tracking_Request(FK_Event_Video_Tracking_Request);
        lblVideoReqNo.Text = objVideo.Request_Number;
    }

    private void BindNoteDetails()
    {
        clsVideo_Request_Notes objNotes = new clsVideo_Request_Notes(PK_Notes);
        lblNote.Text = objNotes.Note;
        lblNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(objNotes.Note_Date);
        lblNoteType.Text = "Video Request Note";
    }
    #endregion

    #region " Events "

    protected void btnPrintSelectedNotes_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["viewIDs"]))
            VideoNoteIDs = Request.QueryString["viewIDs"];

        clsPrintVideoRequestNotes.PrintSelectedNotes(VideoNoteIDs, FK_Event_Video_Tracking_Request, "Video_Request");
    }

    #endregion
}