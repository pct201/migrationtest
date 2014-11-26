using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;


public partial class SONIC_RealEstate_RE_InformationNotes : clsBasePage
{
    #region "Prperties"
    /// <summary>
    /// PK_Purchasing_SC_Notes
    /// </summary>
    private decimal _PK_RE_Notes
    {
        get
        {
            return (ViewState["PK_RE_Notes"] != null ? Convert.ToDecimal(ViewState["PK_RE_Notes"]) : 0);
        }
        set
        {
            ViewState["PK_RE_Notes"] = value;
        }
    }
    #endregion

    #region "Page Event"

    /// <summary>
    /// Handle page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (clsSession.Current_RE_Information_ID > 0)
            {
                RealEstate_Info.PK_RE_Information = clsSession.Current_RE_Information_ID;
                RealEstate_Info.BindrRealEstateInfo();
                _PK_RE_Notes = 0;
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                    {
                        _PK_RE_Notes = index;
                        setControls();
                    }
                }
                else if (App_Access == AccessType.View_Only)
                {
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                }
                else
                    btnViewAudit.Visible = false;
            }
            else
            {
                Response.Redirect("RealEstateAddEdit.aspx?pnl=7", true);
            }
            SetValidations();
        }
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Lease);
    }

    #endregion

    #region "Events"

    /// <summary>
    /// handle Save button click event -to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            RE_Notes objNotes = new RE_Notes();
            setProperties(objNotes);
            if (_PK_RE_Notes > 0)
            {
                objNotes.Update();
            }
            else
            {
                objNotes.Insert();
            }

            if (Request.QueryString["loc"] != null)
                Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=9&op=" + clsSession.Str_RE_Operation, true);
            else
                Response.Redirect("RealEstateAddEdit.aspx?pnl=9", true);
        }
    }

    /// <summary>
    /// Handle Back button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertandReturn_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["loc"] != null)
            Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=9&op=" + clsSession.Str_RE_Operation, true);
        else
            Response.Redirect("RealEstateAddEdit.aspx?pnl=9", true);
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// set properties from controls to save data
    /// </summary>
    /// <param name="objNotes"></param>
    private void setProperties(RE_Notes objNotes)
    {
        objNotes.PK_RE_Notes = _PK_RE_Notes;
        objNotes.FK_RE_Information = clsSession.Current_RE_Information_ID;
        objNotes.Notes = txtNote.Text.Trim();
        objNotes.Note_Date = clsGeneral.FormatDateToStore(txtNoteDate);
        objNotes.Update_Date = DateTime.Now;
        objNotes.Updated_By = clsSession.UserID.ToString();
    }

    /// <summary>
    /// set controls from properties to view data
    /// </summary>
    private void setControls()
    {
        RE_Notes objNotes = new RE_Notes(_PK_RE_Notes);
        txtNote.Text = Convert.ToString(objNotes.Notes);
        txtNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(objNotes.Note_Date);
        lblNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(objNotes.Note_Date);

        if (clsSession.Str_RE_Operation == "view")
        {
            txtNote.ControlType = Controls_LongDescription_LongDescription.CtrlType.Label;
            btnSave.Visible = false;
            trEditDate.Visible = false;
            trViewDate.Visible = true;
            btnRevertandReturn.Text = "Back";
        }
        else
        {
            if (App_Access == AccessType.View_Only)
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }

            trEditDate.Visible = true;
            trViewDate.Visible = false;
        }
    }

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Customer Information"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(76).Tables[0];     
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Note Date":
                    strCtrlsIDs += txtNoteDate.ClientID + ",";
                    strMessages += "Please enter Note Date" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Note":
                    strCtrlsIDs += txtNote.ClientID + ",";
                    strMessages += "Please enter Note" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;        
            }
            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion
}
