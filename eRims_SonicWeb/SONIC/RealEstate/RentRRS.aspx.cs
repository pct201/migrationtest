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

public partial class SONIC_RealEstate_RentRRS : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// PK_Re_SubTenant Term Rent Schedule
    /// </summary>
    private decimal _PK_RE_Rent_RRS
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Rent_RRS"]);
        }
        set { ViewState["PK_RE_Rent_RRS"] = value; }
    }

    /// <summary>
    /// FK Real Estate Sub Tenant
    /// </summary>
    private decimal _FK_RE_Rent
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_RE_Rent"]);
        }
        set { ViewState["FK_RE_Rent"] = value; }
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
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // bind the information in header
            RealEstate_Info.PK_RE_Information = clsSession.Current_RE_Information_ID;
            RealEstate_Info.BindrRealEstateInfo();

            // set the pk and bind the controls
            _PK_RE_Rent_RRS = 0;
            if (Request.QueryString["id"] != null)
            {
                decimal index;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                {
                    _PK_RE_Rent_RRS = index;
                }
            }
            else if (App_Access == AccessType.View_Only)
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
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
                    // set monthly rent
                    if (eventTarget == "GetMonthlyRent" && eventArgument == "GetMonthlyRent")
                    {
                        lblMonthalyRent.Text = clsGeneral.GetStringValue(RE_Rent_RRS.SelectMonthlyRent(_FK_RE_Rent, Convert.ToDateTime(DtLeaseCommenceDate).Year, Convert.ToDateTime(txtFromDate.Text).Year - 1));
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
            _FK_RE_Rent = Convert.ToInt32(new RE_Rent(clsSession.Current_RE_Information_ID, true).PK_RE_Rent);
            DtLeaseCommenceDate = clsGeneral.FormatDBNullDateToDisplay(new RE_Information(clsSession.Current_RE_Information_ID).Lease_Commencement_Date);

            // if Rent_RRS pk is available 
            if (_PK_RE_Rent_RRS > 0)
            {
                // create object
                RE_Rent_RRS objTrs = new RE_Rent_RRS(_PK_RE_Rent_RRS);
                // set the values to page controls
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
                lblOptionPeriod.Text = Convert.ToString(RE_Rent_RRS.SelectOptionPeriodByPK(_FK_RE_Rent));
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
            // Check if page is in Edit mode and user has read-only right
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
    private void setProperties(RE_Rent_RRS objTrs)
    {
        objTrs.PK_RE_Rent_RRS = _PK_RE_Rent_RRS;
        objTrs.FK_RE_Rent = _FK_RE_Rent;
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
        // if page is vallid 
        if (IsValid)
        {
            try
            {
                // create object 
                RE_Rent_RRS objTrs = new RE_Rent_RRS();
                // set properties of object from page controls
                setProperties(objTrs);

                // insert or update the record based on PK
                if (_PK_RE_Rent_RRS > 0)
                {
                    objTrs.Update();
                }
                else
                {
                    objTrs.Insert();
                }
                if (Request.QueryString["loc"] != null)
                    Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=2&op=" + clsSession.Str_RE_Operation, true);
                else
                    Response.Redirect("RealEstateAddEdit.aspx?pnl=2", true);
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
            Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=2&op=" + clsSession.Str_RE_Operation, true);
        else
            Response.Redirect("RealEstateAddEdit.aspx?pnl=2", true);
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
        DataTable dtFields = clsScreen_Validators.SelectByScreen(69).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Renewal Rent Schedule - From Date":
                    strCtrlsIDs += txtFromDate.ClientID + ",";
                    strMessages += "Please enter [Renewal Rent Schedule]/From Date" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Renewal Rent Schedule - To Date":
                    strCtrlsIDs += txtToDate.ClientID + ",";
                    strMessages += "Please enter [Renewal Rent Schedule]/To Date" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Renewal Rent Schedule - Number of Months":
                    strCtrlsIDs += txtNumberOfMonth.ClientID + ",";
                    strMessages += "Please enter [Renewal Rent Schedule]/Number of Months" + ",";
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
