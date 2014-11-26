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

public partial class SONIC_RealEstate_SubtenantORS : clsBasePage
{

    #region "Properties"

    /// <summary>
    /// PK_Re_SubTenant Term Rent Schedule
    /// </summary>
    private decimal _PK_RE_SubTenant_ORS
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_SubTenant_ORS"]);
        }
        set { ViewState["PK_RE_SubTenant_ORS"] = value; }
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

    /// <summary>
    /// FK Real Estate Sub Tenant
    /// </summary>
    public string DtLeaseCommenceDate
    {
        get
        {
            return (ViewState["DtLeaseCommenceDate"] != null ? Convert.ToString(ViewState["DtLeaseCommenceDate"]) : string.Empty);
        }
        set { ViewState["DtLeaseCommenceDate"] = value; }
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
            // set RE Information PK and bind the information in the header
            RealEstate_Info.PK_RE_Information = clsSession.Current_RE_Information_ID;
            RealEstate_Info.BindrRealEstateInfo();
            _PK_RE_SubTenant_ORS = 0;

            // if id is passed on querystring then set pk
            if (Request.QueryString["id"] != null)
            {
                decimal index;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                {
                    _PK_RE_SubTenant_ORS = index;
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
            else if (App_Access == AccessType.View_Only)    // if access rights are not set 
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }

            // bind page in view mode
            BindControls();
            SetValidations();
        }
        else
        {
            try
            {
                // get event target and event argument
                string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
                string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

                if (eventTarget != string.Empty && eventArgument != string.Empty)
                {
                    if (eventTarget == "GetMonthlyRent" && eventArgument == "GetMonthlyRent")
                    {
                        lblMonthalyRent.Text = clsGeneral.GetStringValue(RE_SubTenant_ORS.SelectMonthlyRent(_FK_RE_Subtenant, Convert.ToDateTime(DtLeaseCommenceDate).Year, Convert.ToDateTime(txtFromDate.Text).Year - 1));
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please provide proper data to save');", true);
            }
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
            DtLeaseCommenceDate = clsGeneral.FormatDBNullDateToDisplay(new RE_Information(clsSession.Current_RE_Information_ID).Lease_Commencement_Date);
            if (_PK_RE_SubTenant_ORS > 0)
            {
                RE_SubTenant_ORS objTrs = new RE_SubTenant_ORS(_PK_RE_SubTenant_ORS);

                lblOptionPeriod.Text = Convert.ToString(objTrs.Option_Period);
                txtFromDate.Text = clsGeneral.FormatDBNullDateToDisplay(objTrs.From_Date);
                txtToDate.Text = clsGeneral.FormatDBNullDateToDisplay(objTrs.To_Date);
                lblFromdate.Text = clsGeneral.FormatDBNullDateToDisplay(objTrs.From_Date);
                lblToDate.Text = clsGeneral.FormatDBNullDateToDisplay(objTrs.To_Date);
                txtNumberOfMonth.Text = objTrs.Months == null ? "0" : Convert.ToString(objTrs.Months);
                lblNumberofMonth.Text = objTrs.Months == null ? "0" : Convert.ToString(objTrs.Months);
                lblMonthalyRent.Text = clsGeneral.GetStringValue(objTrs.Monthly_Rent);
            }
            else
            {
                lblOptionPeriod.Text = Convert.ToString(RE_SubTenant_ORS.SelectOptionPeriodByPK(_FK_RE_Subtenant));
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
            // ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please provide proper data to save');", true);
        }
    }

    /// <summary>
    /// set Properties for Save Data
    /// </summary>
    /// <param name="objTrs"></param>
    private void setProperties(RE_SubTenant_ORS objTrs)
    {
        objTrs.PK_RE_SubTenant_ORS = _PK_RE_SubTenant_ORS;
        objTrs.FK_RE_Subtenant = _FK_RE_Subtenant;
        if (lblOptionPeriod.Text != "")
            objTrs.Option_Period = Convert.ToInt32(lblOptionPeriod.Text);

        objTrs.From_Date = clsGeneral.FormatNullDateToStore(txtFromDate.Text);
        objTrs.To_Date = clsGeneral.FormatNullDateToStore(txtToDate.Text);
        objTrs.Update_Date = DateTime.Now;
        objTrs.Updated_By = clsSession.UserID;
        objTrs.Monthly_Rent = Convert.ToDecimal(lblMonthalyRent.Text);
        objTrs.Months = clsGeneral.GetDecimalNullableValue(txtNumberOfMonth);
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
        // if page is valid
        if (IsValid)
        {
            try
            {
                // create object
                RE_SubTenant_ORS objTrs = new RE_SubTenant_ORS();

                // set object values from page control
                setProperties(objTrs);

                // insert or update the record based on PK
                if (_PK_RE_SubTenant_ORS > 0)
                {
                    objTrs.Update();
                }
                else
                {
                    objTrs.Insert();
                }
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
    /// <summary>
    /// Set all validations on page
    /// </summary>
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
                case "Option Rent Schedule - From Date":
                    strCtrlsIDs += txtFromDate.ClientID + ",";
                    strMessages += "Please enter Option Rent Schedule - From Date" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Option Rent Schedule - To Date":
                    strCtrlsIDs += txtToDate.ClientID + ",";
                    strMessages += "Please enter Option Rent Schedule - To Date" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Option Rent Schedule - Number of Months":
                    strCtrlsIDs += txtNumberOfMonth.ClientID + ",";
                    strMessages += "Please enter Option Rent Schedule - Number of Months" + ",";
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
