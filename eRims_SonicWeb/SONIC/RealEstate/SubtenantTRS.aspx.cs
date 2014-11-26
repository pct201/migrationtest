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

public partial class SONIC_RealEstate_SubtenantTRS : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// PK_Re_SubTenant Term Rent Schedule
    /// </summary>
    private decimal _PK_RE_Subtenant_TRS
    {
        get
        {
            return clsGeneral.GetInt(ViewState["_PK_RE_Subtenant_TRS"]);
        }
        set { ViewState["_PK_RE_Subtenant_TRS"] = value; }
    }

    /// <summary>
    /// FK Real Estate Sub Tenant
    /// </summary>
    private decimal _FK_RE_Subtenant
    {
        get
        {
            return clsGeneral.GetInt(ViewState["_FK_RE_Subtenant"]);
        }
        set { ViewState["_FK_RE_Subtenant"] = value; }
    }

    #endregion

    #region "Page Event"
    /// <summary>
    /// Handles page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            RealEstate_Info.PK_RE_Information = clsSession.Current_RE_Information_ID;
            RealEstate_Info.BindrRealEstateInfo();
            _PK_RE_Subtenant_TRS = 0;

            // if ID is passed in querystring
            if (Request.QueryString["id"] != null)
            {
                decimal index;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                {
                    _PK_RE_Subtenant_TRS = index;
                }
            }
            if (Request.QueryString["Subtenant"] != null)
            {
                decimal SubtenantID;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["Subtenant"]), out SubtenantID))
                {
                    _FK_RE_Subtenant = SubtenantID;
                }
            }
            else if (App_Access == AccessType.View_Only)
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }

            // set controls and data
            BindControls();
            SetValidations();
        }
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Lease);
    }

    #endregion

    #region " Methods "

    /// <summary>
    /// Bind Data for Edit
    /// </summary>
    private void BindControls()
    {
        try
        {
            _FK_RE_Subtenant = _FK_RE_Subtenant;
            if (_PK_RE_Subtenant_TRS > 0)
            {
                // create object
                RE_Subtenant_TRS objTrs = new RE_Subtenant_TRS(_PK_RE_Subtenant_TRS);
                // set values in page controls
                lblYear.Text = Convert.ToString(objTrs.Year);
                txtFromDate.Text = clsGeneral.FormatDBNullDateToDisplay(objTrs.From_Date);
                txtToDate.Text = clsGeneral.FormatDBNullDateToDisplay(objTrs.To_Date);
                lblFromdate.Text = clsGeneral.FormatDBNullDateToDisplay(objTrs.From_Date);
                lblToDate.Text = clsGeneral.FormatDBNullDateToDisplay(objTrs.To_Date);
                txtNumberOfMonth.Text = objTrs.Months == null ? "0" : Convert.ToString(objTrs.Months);
                lblNumberofMonth.Text = objTrs.Months == null ? "0" : Convert.ToString(objTrs.Months);
                lblMonthalyRent.Text = clsGeneral.GetStringValue(objTrs.Monthly_Rent);
                lblPercentage.Text = clsGeneral.GetStringValue(objTrs.Percentage_Rate);
                lblAdditional.Text = clsGeneral.GetStringValue(objTrs.Additions);
            }
            else
            {
                // get data for max year 
                DataSet dsDetails = RE_Subtenant_TRS.SelectYearByPK(_FK_RE_Subtenant);

                // if data is available
                if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                {
                    lblYear.Text = Convert.ToString(dsDetails.Tables[0].Rows[0][0]);
                    lblMonthalyRent.Text = clsGeneral.GetStringValue(dsDetails.Tables[0].Rows[0][1]);
                    lblPercentage.Text = Convert.ToString(dsDetails.Tables[0].Rows[0][2]);
                    lblAdditional.Text = clsGeneral.GetStringValue(dsDetails.Tables[0].Rows[0][3]);
                }
                btnViewAudit.Visible = false;
            }

            if (clsSession.Str_RE_Operation == "view")
            {
                btnSave.Visible = false;
                trEditDate.Visible = false;
                trViewDate.Visible = true;
                txtNumberOfMonth.Visible = false;
                lblNumberofMonth.Visible = true;
                btnRevertandReturn.Text = "Back";
            }
            // check if user has only view rights and try to edit record.
            else if (App_Access == AccessType.View_Only)
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please provide proper data to save');", true);
        }
    }

    /// <summary>
    /// set Properties for Save Data
    /// </summary>
    /// <param name="objTrs"></param>
    private void setProperties(RE_Subtenant_TRS objTrs)
    {
        objTrs.PK_RE_Subtenant_TRS = _PK_RE_Subtenant_TRS;
        objTrs.FK_RE_Subtenant = _FK_RE_Subtenant;
        objTrs.Year = Convert.ToInt32(lblYear.Text);
        objTrs.Additions = Convert.ToDecimal(lblAdditional.Text);
        objTrs.From_Date = clsGeneral.FormatNullDateToStore(txtFromDate.Text);
        objTrs.To_Date = clsGeneral.FormatNullDateToStore(txtToDate.Text);
        objTrs.Update_Date = DateTime.Now;
        objTrs.Updated_By = clsSession.UserID;
        objTrs.Monthly_Rent = Convert.ToDecimal(lblMonthalyRent.Text);
        objTrs.Months = clsGeneral.GetDecimalNullableValue(txtNumberOfMonth);
        objTrs.Percentage_Rate = Convert.ToDecimal(lblPercentage.Text);
    }

    #endregion

    #region " Events "

    /// <summary>
    /// Handle Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            try
            {
                // create object
                RE_Subtenant_TRS objTrs = new RE_Subtenant_TRS();
                // set object values from page controls
                setProperties(objTrs);
                // save the record based on PK
                if (_PK_RE_Subtenant_TRS > 0)
                    objTrs.Update();
                else
                    objTrs.Insert();
                if (Request.QueryString["loc"] != null)
                    Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=3&op=" + clsSession.Str_RE_Operation + "&Subtenant=" + Encryption.Encrypt(Convert.ToString(_FK_RE_Subtenant)), true);
                else
                    Response.Redirect("RealEstateAddEdit.aspx?pnl=3", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please provide proper data to save');", true);
            }
        }
    }

    /// <summary>
    /// Handle Revert & Return button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertandReturn_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["loc"] != null)
            Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=3&op=" + clsSession.Str_RE_Operation + "&Subtenant=" + Encryption.Encrypt(Convert.ToString(_FK_RE_Subtenant)), true);
        else
            Response.Redirect("RealEstateAddEdit.aspx?pnl=3", true);
    }

    #endregion

    #region Dynamic Validations

    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Rent Projections - Term Rent Schedule"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(70).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Term Rent Schedule - From Date":
                    strCtrlsIDs += txtFromDate.ClientID + ",";
                    strMessages += "Please enter [Term Rent Schedule]/From Date" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Term Rent Schedule - To Date":
                    strCtrlsIDs += txtToDate.ClientID + ",";
                    strMessages += "Please enter [Term Rent Schedule]/To Date" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Term Rent Schedule - Number of Months":
                    strCtrlsIDs += txtNumberOfMonth.ClientID + ",";
                    strMessages += "Please enter [Term Rent Schedule]/Number of Months" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
            }
            #endregion

        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
        #endregion
    }

    #endregion
}
