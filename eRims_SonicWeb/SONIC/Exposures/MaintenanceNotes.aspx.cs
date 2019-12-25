using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_MaintenanceNotes : System.Web.UI.Page
{
    #region "Properties"
    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes FK for Facility_Maintenance_Notes table
    /// </summary>
    public int FK_Facility_Construction_Maintenance_Item
    {
        get { return Convert.ToInt32(ViewState["FK_Facility_Construction_Maintenance_Item"]); }
        set { ViewState["FK_Facility_Construction_Maintenance_Item"] = value; }
    }

    /// <summary>
    /// Denotes PK for Facility_Maintenance_Notes table
    /// </summary>
    public int PK_Facility_Maintenance_Notes
    {
        get { return Convert.ToInt32(ViewState["PK_Facility_Maintenance_Notes"]); }
        set { ViewState["PK_Facility_Maintenance_Notes"] = value; }
    }

    public DataTable dtNotes_FacilityMaintenance
    {
        get
        {
            DataTable dtTemp1 = new DataTable("Notes");
            if (ViewState["dtNotes"] == null)
            {
                dtTemp1.Columns.Add("PK_Facility_Maintenance_Notes");
                dtTemp1.Columns.Add("Note");
                dtTemp1.Columns.Add("Note_Date");
                dtTemp1.Columns.Add("AuthorName");
            }
            else
            {
                dtTemp1 = (DataTable)ViewState["dtNotes"];
            }
            return dtTemp1;
        }
        set
        {
            ViewState["dtNotes"] = value;
        }
    }

    #endregion

    #region Page Load Events

    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.FacilityMaintenance);
        if (!IsPostBack)
        {
            if (Request.QueryString["loc"] != null && Request.QueryString["item"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                }
                else
                    Response.Redirect("ExposureSearch.aspx");

                Session["ExposureLocation"] = FK_LU_Location_ID;

                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();

                pnlNotesEdit.Visible = true;

                int maintenanceId;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["item"]), out maintenanceId))
                {
                    FK_Facility_Construction_Maintenance_Item = maintenanceId;
                }
                else
                    Response.Redirect("ExposureSearch.aspx");

                int noteId;
                if (Request.QueryString["subitem"] != null)
                {
                    if (int.TryParse(Encryption.Decrypt(Request.QueryString["subitem"]), out noteId))
                    {
                        PK_Facility_Maintenance_Notes = noteId;
                    }
                    else
                        Response.Redirect("ExposureSearch.aspx");
                }

                if (Request.QueryString["op"] != null && Request.QueryString["op"].ToString().ToUpper() == "VIEW")
                {
                    pnlNotesEdit.Visible = false;
                    pnlNotesView.Visible = true;
                }
                dtNotes_FacilityMaintenance = (DataTable)Session["dtNotes"];
                //if (FK_Facility_Construction_Maintenance_Item > 0)
                //{
                BindNoteDetails();
                //}
            }
            else
            {
                Response.Redirect("ExposureSearch.aspx");
            }
        }
    }

    #endregion

    #region Page Control Events

    /// <summary>
    /// Save Notes Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNoteSave_Click(object sender, EventArgs e)
    {
        if (FK_Facility_Construction_Maintenance_Item != 0)
        {
            Facility_Maintenance_Notes facility_Maintenance_Notes = new Facility_Maintenance_Notes();
            facility_Maintenance_Notes.Note = txtNote.Text;
            facility_Maintenance_Notes.Note_Date = !string.IsNullOrEmpty(txtNoteDate.Text) ? clsGeneral.FormatNullDateToStore(txtNoteDate.Text) : clsGeneral.FormatDateToStore(DateTime.Now);
            facility_Maintenance_Notes.FK_Facility_Maintenance_Item = FK_Facility_Construction_Maintenance_Item;
            facility_Maintenance_Notes.PK_Facility_Maintenance_Notes = PK_Facility_Maintenance_Notes;
            facility_Maintenance_Notes.Author_Table = "Security";
            facility_Maintenance_Notes.FK_Author = Convert.ToInt32(clsSession.UserID);

            if (PK_Facility_Maintenance_Notes > 0)
            {
                facility_Maintenance_Notes.PK_Facility_Maintenance_Notes = PK_Facility_Maintenance_Notes;
                facility_Maintenance_Notes.Update();
            }
            else
            {
                PK_Facility_Maintenance_Notes = facility_Maintenance_Notes.Insert();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "btnSave", "javascript: alert('Notes details saved successfully.');", true);
            pnlNotesEdit.Visible = false;
            pnlNotesView.Visible = true;
        }
        else
        {
            if (PK_Facility_Maintenance_Notes > 0)
            {
                DataRow[] dr = dtNotes_FacilityMaintenance.Select("PK_Facility_Maintenance_Notes = " + PK_Facility_Maintenance_Notes);
                dr[0]["Note"] = txtNote.Text;
                dr[0]["Note_Date"] = string.IsNullOrEmpty(txtNoteDate.Text) ? DateTime.Now.ToString().Substring(0, 10) : (txtNoteDate.Text).ToString().Substring(0, 10);
                Session["dtNotes"] = dtNotes_FacilityMaintenance;
            }
            else
            {
                DataTable dtTemp = dtNotes_FacilityMaintenance;
                DataRow drNote = dtTemp.NewRow();
                Random generator = new Random();
                PK_Facility_Maintenance_Notes = generator.Next(0, 999999);
                drNote["PK_Facility_Maintenance_Notes"] = PK_Facility_Maintenance_Notes;
                drNote["Note"] = txtNote.Text;
                drNote["Note_Date"] = string.IsNullOrEmpty(txtNoteDate.Text) ? DateTime.Now.ToString().Substring(0, 10) : (txtNoteDate.Text).ToString().Substring(0, 10);
                drNote["AuthorName"] = (clsSession.LastName == string.Empty ? "" : clsSession.LastName + " ") + (clsSession.FirstName == string.Empty ? "" : clsSession.FirstName) + "- Sonic";

                dtTemp.Rows.Add(drNote);
                ViewState["dtNotes"] = dtTemp;
                dtNotes_FacilityMaintenance = (DataTable)ViewState["dtNotes"];
                Session["dtNotes"] = dtNotes_FacilityMaintenance;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "btnSave", "javascript: alert('Notes details saved successfully.');", true);
            pnlNotesEdit.Visible = false;
            pnlNotesView.Visible = true;
        }

        BindNoteDetails();
    }

    /// <summary>
    /// Redirect to back page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertAndReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("FacilityMaintenance_Item.aspx?loc={0}&item={1}&op={2}&flag=1", Request.QueryString["loc"].ToString(), Request.QueryString["item"].ToString(), "View"));
    }

    /// <summary>
    /// Edit button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNoteEdit_Click(object sender, EventArgs e)
    {
        pnlNotesEdit.Visible = true;
        pnlNotesView.Visible = false;
    }

    #endregion

    #region Private Method

    /// <summary>
    /// Binds Notes Details
    /// </summary>
    private void BindNoteDetails()
    {
        if (FK_Facility_Construction_Maintenance_Item != 0)
        {
            Facility_Maintenance_Notes facility_Maintenance_Notes = new Facility_Maintenance_Notes(PK_Facility_Maintenance_Notes);
            txtNoteDate.Text = lblNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(facility_Maintenance_Notes.Note_Date);
            txtNote.Text = lblNote.Text = facility_Maintenance_Notes.Note;
        }
        else if (dtNotes_FacilityMaintenance.Rows.Count > 0 && PK_Facility_Maintenance_Notes != 0)
        {
            DataRow[] dr = dtNotes_FacilityMaintenance.Select("PK_Facility_Maintenance_Notes = " + PK_Facility_Maintenance_Notes);
            txtNoteDate.Text = lblNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(dr[0]["Note_Date"].ToString());
            txtNote.Text = lblNote.Text = dr[0]["Note"].ToString();
        }

    }

    #endregion
}