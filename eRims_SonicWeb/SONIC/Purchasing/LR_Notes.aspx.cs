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
using ERIMS.DAL;

public partial class SONIC_Purchasing_LR_Notes : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// PK_Purchasing_LR_Notes
    /// </summary>
    private decimal PK_Purchasing_LR_Notes
    {
        get
        {
            return (ViewState["PK_Purchasing_LR_Notes"] != null ? Convert.ToDecimal(ViewState["PK_Purchasing_LR_Notes"]) : 0);
        }
        set
        {
            ViewState["PK_Purchasing_LR_Notes"] = value;
        }
    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (clsSession.Current_LR_Agreement_ID > 0)
            {
                CheckUserRights();
                txtNoteDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    btnLRNotesAudit.Visible = true;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                    {
                        PK_Purchasing_LR_Notes = index;
                        setControls();
                    }
                }
                else
                    btnLRNotesAudit.Visible = false;
            }
            else
            {
                if (clsSession.Current_LR_Agreement_ID > 0)
                    Response.Redirect("LeaseRentalAgreement.aspx?id=" + clsSession.Current_LR_Agreement_ID + "&pnl=3", true);
                else
                    Response.Redirect("LeaseRentalAgreement.aspx?op=add");
            }
            txtNoteDate.Attributes.Add("readonly", "true");
            Purchasing_SearchTAB.StrRedirectTo = "";
            if(clsSession.Str_LR_Agreement_Operation != "view")
              SetValidations();
        }
        if (Purchasing_SearchTAB.Visible)
            Purchasing_SearchTAB.SetSelectedTab(CtrlPurchasing_Search.Tab.Purchasing);
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Handle Sava button event -to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Purchasing_LR_Note objNotes = new Purchasing_LR_Note();
            setProperties(objNotes);
            if (PK_Purchasing_LR_Notes > 0)
            {
                objNotes.Update();
            }
            else
            {
                objNotes.Insert();
            }
            Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(clsSession.Current_LR_Agreement_ID.ToString()) + "&pnl=3", true);
        }
    }

    /// <summary>
    /// Handle Baqck button event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertandReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(clsSession.Current_LR_Agreement_ID.ToString()) + "&pnl=3", true);
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// check user rights
    /// </summary>
    private void CheckUserRights()
    {
        if (App_Access == AccessType.View_Only && clsSession.Str_LR_Agreement_Operation != "view")
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);

    }


    /// <summary>
    /// set propeties from controls to save data
    /// </summary>
    /// <param name="objNotes"></param>
    private void setProperties(Purchasing_LR_Note objNotes)
    {
        objNotes.PK_Purchasing_LR_Notes = PK_Purchasing_LR_Notes;
        objNotes.FK_Purchasing_LR_Agreement = clsSession.Current_LR_Agreement_ID;
        objNotes.Note = txtNote.Text.Trim();
        objNotes.Note_Date = clsGeneral.FormatDateToStore(txtNoteDate);
        objNotes.Update_Date = DateTime.Now;
        objNotes.Updated_By = clsSession.UserID.ToString();
    }

    /// <summary>
    /// set controls from properties to view data
    /// </summary>
    private void setControls()
    {
        DataSet ds = Purchasing_LR_Note.SelectByPK(PK_Purchasing_LR_Notes);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Note_Date"] != null)
            {
                txtNoteDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(ds.Tables[0].Rows[0]["Note_Date"]));
                lblNoteDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(ds.Tables[0].Rows[0]["Note_Date"]));
            }
            else
            {
                txtNoteDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
            }

            if (ds.Tables[0].Rows[0]["Note"] != null)
            {
                txtNote.Text = ds.Tables[0].Rows[0]["Note"].ToString();
            }
        }

        if (clsSession.Str_LR_Agreement_Operation == "view")
        {
            txtNote.ControlType = Controls_LongDescription_LongDescription.CtrlType.Label;
            btnSave.Visible = false;
            txtNoteDate.Visible = false;
            lblNoteDate.Visible = true;
            btnRevertandReturn.Text = "Back";
        }
        else
        {
            txtNoteDate.Visible = true;
            lblNoteDate.Visible = false;
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

        #region "Notes"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(91).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 91").Length > 0) ? "inline-block" : "none";
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
                    txtNote.IsRequired = true;
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
