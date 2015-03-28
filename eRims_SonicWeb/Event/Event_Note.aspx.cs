using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Event_Event_Note : System.Web.UI.Page
{
    #region Properties
    /// <summary>
    /// Denotes the Foreign Key of Event
    /// </summary>
    public decimal FK_Event
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }        
    }

    /// <summary>
    /// Denotes list of primary key of Event
    /// </summary>
    public string EventNoteIDs
    {
        get { return clsGeneral.IsNull(ViewState["EventNoteIDs"]) ? string.Empty : Convert.ToString(ViewState["EventNoteIDs"]); }
        set { ViewState["EventNoteIDs"] = value; }
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

            if (_Type.ToLower().Contains("aci"))
                lblListNoteType.Text = "Acadian Note";
            else
                lblListNoteType.Text = "Sonic Event Note";

            if (!string.IsNullOrEmpty(Request.QueryString["viewIDs"]))
            {
                #region " List Notes "
                EventNoteIDs = Request.QueryString["viewIDs"];
                
                // Rebind Grid
                if (!string.IsNullOrEmpty(_Type) && _Type.ToLower() == "acispecificnote")
                    rptNotes.DataSource = clsACI_Event_Notes.SelectByIDs(EventNoteIDs);
                else
                    rptNotes.DataSource = clsSonic_Event_Notes.SelectByIDs(EventNoteIDs);

                rptNotes.DataBind();

                dvNotesList.Style["display"] = "block";
                dvView.Style["display"] = "none";
                //trButtons.Style["display"] = "none";

                #endregion
            }
            else if (!string.IsNullOrEmpty(_Type) && _Type.ToLower().Contains("view"))
            {
                #region "List of All Notes"
                if (!string.IsNullOrEmpty(_Type) && _Type.ToLower() == "aciview")
                    rptNotes.DataSource = clsACI_Event_Notes.SelectByFK_Event(FK_Event, 1, 1000, "Note_Date", "asc");
                else
                    rptNotes.DataSource = clsSonic_Event_Notes.SelectByFK_Event(FK_Event);

                rptNotes.DataBind();
                dvNotesList.Style["display"] = "block";
                dvView.Style["display"] = "none"; 
                #endregion
            }
            else if (FK_Event > 0 && PK_Notes > 0)
            {
                BindNoteDetails();
                BindEventDetail();
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
    private void BindEventDetail()
    {
        clsEvent objEvent = new clsEvent(FK_Event);
        lblEventNo.Text = objEvent.Event_Number;
    }

    private void BindNoteDetails()
    {
        if (_Type == "ACI")
        {
            clsACI_Event_Notes objNotes = new clsACI_Event_Notes(PK_Notes);
            lblNote.Text = objNotes.Note;
            lblNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(objNotes.Note_Date);
            lblNoteType.Text = "Acadian Note";
        }
        else
        {
            clsSonic_Event_Notes objSonicNote = new clsSonic_Event_Notes(PK_Notes);
            lblNote.Text = objSonicNote.Note;
            lblNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(objSonicNote.Note_Date);
            lblNoteType.Text = "Sonic Event Note";
        }
    }
    #endregion

    #region " Events "

    protected void btnPrintSelectedNotes_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["viewIDs"]))
            EventNoteIDs = Request.QueryString["viewIDs"];

        if(_Type.ToLower().Contains("aci"))
            clsPrintEventNotes.PrintSelectedNotes(EventNoteIDs, FK_Event,"ACI");
        else
            clsPrintEventNotes.PrintSelectedNotes(EventNoteIDs, FK_Event, "Sonic");
    }
    
    #endregion
}