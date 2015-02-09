using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_FirstReport_OhioWCClaim : clsBasePage
{
    #region "Property"
    public decimal _PK_Workers_Comp_Claims_OH_Id
    {
        get { return (ViewState["PK_ID"] != null) ? Convert.ToDecimal(ViewState["PK_ID"]) : 0; }
        set { ViewState["PK_ID"] = value; }
    }
    public string _strOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]).ToLower(); }
        set { ViewState["strOperation"] = value; }
    }
    #endregion

    #region "Page Load"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAssociatedFirstReport.Attributes.Add("Text", txtAssociatedFirstReport.Text);
        if (!IsPostBack)
        {
            if(App_Access != AccessType.Ohio_Claim_Access && App_Access != AccessType.Administrative_Access)
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

            _strOperation = Request.QueryString["op"] != null ? Request.QueryString["op"].ToString() : "view";

            if (Request.QueryString["id"] != null)
            {
                int PK_inv = 0;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["id"].ToString()), out PK_inv))
                    _PK_Workers_Comp_Claims_OH_Id = PK_inv;
            }
            btnEdit.Visible = false;//Initially this button will be hide.

            if (_strOperation == "view" && _PK_Workers_Comp_Claims_OH_Id > 0)
                BindDetailsforView();
            else
            {
                btnAssociatedFirstReport.Focus();
                if (_PK_Workers_Comp_Claims_OH_Id > 0)
                {
                    // for Edit-View right to Claim Infor
                    if (Module_Access_Mode == AccessType.View_Only)
                    {
                        BindDetailsforView();
                    }
                    else
                        BindDetailsforEdit();
                }
                else
                {
                    DataSet dsGroup = Security.SelectGroupByUserID(Convert.ToDecimal(clsSession.UserID));
                    if (dsGroup.Tables[0].Rows.Count <= 0)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    
                }
                //else if (UserAccessType != AccessType.Administrative_Access)
                //{
                //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                //}
            }
            SetValidations();
        }

        btnAudit.Visible = (_PK_Workers_Comp_Claims_OH_Id > 0);//Visible only if record is Save.

    }

    #endregion

    #region "Event"
   
    /// <summary>
    /// Save records.
    /// </summary>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Workers_Comp_Claims_OH objWC_Claim_OH;
        if (_PK_Workers_Comp_Claims_OH_Id > 0)
            objWC_Claim_OH = new Workers_Comp_Claims_OH(_PK_Workers_Comp_Claims_OH_Id);
        else objWC_Claim_OH = new Workers_Comp_Claims_OH();

        objWC_Claim_OH.PK_Workers_Comp_Claims_OH_Id = _PK_Workers_Comp_Claims_OH_Id;
        objWC_Claim_OH.FROI_Number = "WC-" + hdnid.Value;
        objWC_Claim_OH.Claim_Number = txtClaimNumber.Text;
        if (txtDateClaimEntered.Text != "") objWC_Claim_OH.Date_Entered = Convert.ToDateTime(txtDateClaimEntered.Text);
        else objWC_Claim_OH.Date_Entered = null;
        if (txtDateClaimClosed.Text != "") objWC_Claim_OH.Date_Closed = Convert.ToDateTime(txtDateClaimClosed.Text);
        else objWC_Claim_OH.Date_Closed = null;
        if (txtDateClaimReopened.Text != "") objWC_Claim_OH.Date_Reopened = Convert.ToDateTime(txtDateClaimReopened.Text);
        else objWC_Claim_OH.Date_Reopened = null;
        objWC_Claim_OH.Active_InActive = ddlStatus.Text;

        if (txtDateofFirstTransaction.Text != string.Empty)
            objWC_Claim_OH.Date_Of_First_Transaction = clsGeneral.FormatDBNullDateToDate(txtDateofFirstTransaction.Text);
        else
            objWC_Claim_OH.Date_Of_First_Transaction = null;
        if (txtDateofIncident.Text != "") objWC_Claim_OH.Date_Of_Incident = clsGeneral.FormatDBNullDateToDate(txtDateofIncident.Text);
        else objWC_Claim_OH.Date_Of_Incident = null;
        if (txtAssociateName.Text != "") objWC_Claim_OH.Associate_Name = txtAssociateName.Text;


        System.Data.DataView dvRecord = Workers_Comp_Claims_OH.SelectAssociatedFirstReportByPk(Convert.ToDecimal(hdnid.Value)).Tables[0].DefaultView;

        if (dvRecord[0]["NAME"].ToString() != "") objWC_Claim_OH.Associate_Name = Convert.ToString(dvRecord[0]["NAME"]);
        else objWC_Claim_OH.Associate_Name = null;
        if (dvRecord[0]["dba"].ToString() != "") objWC_Claim_OH.Sonic_Location_Code = Convert.ToString(Workers_Comp_Claims_OH.GetSonicLocationCodeFromdba(Convert.ToString(dvRecord[0]["dba"])));
        else objWC_Claim_OH.Sonic_Location_Code = null;
        if (dvRecord[0]["Date_Of_Incident"].ToString() != "") objWC_Claim_OH.Date_Of_Incident = clsGeneral.FormatDBNullDateToDate(dvRecord[0]["Date_Of_Incident"]);
        else objWC_Claim_OH.Date_Of_Incident = null; 

        //objWC_Claim_OH.Type = txtType.Text;
        //objWC_Claim_OH.Total_Medical = txtTotalMedical.Text != "" ? Convert.ToDecimal(txtTotalMedical.Text) : 0;
        //objWC_Claim_OH.Total_Comp = txtTotalComp.Text != "" ? Convert.ToDecimal(txtTotalComp.Text) : 0;
        //objWC_Claim_OH.Total_Reserve = txtTotalReserve.Text != "" ? Convert.ToDecimal(txtTotalReserve.Text) : 0;
        //objWC_Claim_OH.Unlimited_Cost = txtUnlimitedCost.Text != "" ? Convert.ToDecimal(txtUnlimitedCost.Text) : 0;
        //objWC_Claim_OH.Limited_to_MV = txtLimitedtoMV.Text != "" ? Convert.ToDecimal(txtLimitedtoMV.Text) : 0;
        //objWC_Claim_OH.HC_Percent = txtHCPercent.Text != "" ? Convert.ToDecimal(txtHCPercent.Text) : 0;
        //objWC_Claim_OH.HC_Relief = txtHCRelief.Text != "" ? Convert.ToDecimal(txtHCRelief.Text) : 0;
        //objWC_Claim_OH.Subrogation_Collected = txtSubrogationCollected.Text != "" ? Convert.ToDecimal(txtSubrogationCollected.Text) : 0;
        //objWC_Claim_OH.Claim_Activity = txtClaimActivity.Text;
        objWC_Claim_OH.Total_Paid_To_Date =  txtTotalPaid.Text != "" ? Convert.ToDecimal(txtTotalPaid.Text) : 0;
        objWC_Claim_OH.Updated_By = clsSession.UserName;
        objWC_Claim_OH.Update_Date = DateTime.Now;

        decimal dcGetID = 0;
        // Check for Insert And Update
        if (_PK_Workers_Comp_Claims_OH_Id > 0)
            dcGetID = objWC_Claim_OH.Update();
        else
        {
            dcGetID = _PK_Workers_Comp_Claims_OH_Id = objWC_Claim_OH.Insert();
        }
        // If claim number is exist in either table.
        if (dcGetID == -2 || dcGetID == -3)
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Claim Number cannot be duplicated.');", true);

        else if (_strOperation == "add") Response.Redirect("OhioWCClaim.aspx?id=" + Encryption.Encrypt(_PK_Workers_Comp_Claims_OH_Id.ToString()) + "&op=edit");
        else if (_PK_Workers_Comp_Claims_OH_Id > 0) BindDetailsforEdit();//BIND DETAILS AFTER SUCCESFULL INSERT AND UPDATE 
        txtAssociatedFirstReport.Text = txtAssociatedFirstReport.Attributes["Text"];
        Session["Search"] = "Y";
        Response.Redirect("OhioWCClaimSearch.aspx");
    }

    /// <summary>
    /// Bind details for Edit,if have Admin Access.
    /// </summary>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        _strOperation = "edit";
        BindDetailsforEdit();
    }

    /// <summary>
    /// Button Back Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session["Y"] = "Y";
        Response.Redirect("OhioWCClaimSearch.aspx");
    }

    #endregion

    #region "Method"

    /// <summary>
    /// Bind Details For View
    /// </summary>
    private void BindDetailsforView()
    {
        divEdit.Style["display"] = "none";
        divView.Style["display"] = "block";
        btnSave.Visible = false;
        btnEdit.Visible = false;
        // btnEdit.Visible = (Module_Access_Mode == AccessType.Administrative_Access);
        Workers_Comp_Claims_OH objwc = new Workers_Comp_Claims_OH(_PK_Workers_Comp_Claims_OH_Id);
        if (Convert.ToDecimal(objwc.FROI_Number.Replace("WC-", "")) > 0)
        {
            System.Data.DataView dvRecord = Workers_Comp_Claims_OH.SelectAssociatedFirstReportByPk(Convert.ToDecimal(objwc.FROI_Number.Replace("WC-", ""))).Tables[0].DefaultView;
            if (dvRecord != null && dvRecord.Count > 0)
            {
                lblAssociatedFirstReport.Text = Convert.ToString(dvRecord[0]["WC_FR_NUMBER"]);
                lblClaimNumber.Text = objwc.Claim_Number;
                if (objwc.Date_Closed != null) lblDateClaimClosed.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objwc.Date_Closed));
                if (objwc.Date_Entered != null) lblDateClaimEntered.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objwc.Date_Entered));
                if (objwc.Date_Reopened != null) lblDateClaimReopened.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objwc.Date_Reopened));
                lblEmployeeName.Text = Convert.ToString(dvRecord[0]["NAME"]);
                lblSonicLocation.Text = Convert.ToString(dvRecord[0]["DBA"]);
                lblDateOfIncident.Text = Convert.ToString(dvRecord[0]["Date_Of_Incident"]);
                lblStatus.Text = objwc.Active_InActive;
                //lblType.Text = objwc.Type;
                //lblTotalMedical.Text = Convert.ToString(objwc.Total_Medical) != "" ? "$" + Convert.ToString(objwc.Total_Medical) : Convert.ToString(objwc.Total_Medical);
                //lblTotalComp.Text = Convert.ToString(objwc.Total_Comp) != "" ? "$" + Convert.ToString(objwc.Total_Comp) : Convert.ToString(objwc.Total_Comp);
                //lblTotalReserve.Text =  Convert.ToString(objwc.Total_Reserve) != "" ? "$" + Convert.ToString(objwc.Total_Reserve) :  Convert.ToString(objwc.Total_Reserve);
                //lblUnlimitedCost.Text = Convert.ToString(objwc.Unlimited_Cost) != "" ? "$" + Convert.ToString(objwc.Unlimited_Cost) : Convert.ToString(objwc.Unlimited_Cost);
                //lblLimitedToMV.Text = Convert.ToString(objwc.Limited_to_MV) != "" ? "$" + Convert.ToString(objwc.Limited_to_MV) : Convert.ToString(objwc.Limited_to_MV);
                //lblHCPercent.Text = Convert.ToString(objwc.HC_Percent) != "" ? "$" + Convert.ToString(objwc.HC_Percent) : Convert.ToString(objwc.HC_Percent);
                //lblHCRelief.Text = Convert.ToString(objwc.HC_Relief) != "" ? "$" + Convert.ToString(objwc.HC_Relief) : Convert.ToString(objwc.HC_Relief);
                //lblSubCollected.Text = Convert.ToString(objwc.Subrogation_Collected) != "" ? "$" + Convert.ToString(objwc.Subrogation_Collected) : Convert.ToString(objwc.Subrogation_Collected);
                //lblClaimActivity.Text = Convert.ToString(objwc.Claim_Activity);
                //lblTotalCharged.Text = Convert.ToString(objwc.Total_Charged) != "" ? "$" + Convert.ToString(objwc.Total_Charged) : Convert.ToString(objwc.Total_Charged);
                if (objwc.Date_Of_First_Transaction != null) lblDateOfFirstTransaction.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objwc.Date_Of_First_Transaction));
                lblTotalPaidToDate.Text = Convert.ToString(objwc.Total_Paid_To_Date) != "" ? "$" + Convert.ToString(objwc.Total_Paid_To_Date) : Convert.ToString(objwc.Total_Paid_To_Date);
                Session["Search"] = "Y";
                if (objwc.Imported == "I")
                    btnEdit.Visible = false;

                btnAudit.Visible = true;


            }
        }

    }

    /// <summary>
    /// Bind Details For Edit
    /// </summary>
    private void BindDetailsforEdit()
    {
        divEdit.Style["display"] = "block";
        divView.Style["display"] = "none";
        btnSave.Visible = true;
        btnEdit.Visible = false;

        Workers_Comp_Claims_OH objwc = new Workers_Comp_Claims_OH(_PK_Workers_Comp_Claims_OH_Id);
      
        if (Convert.ToDecimal(objwc.FROI_Number.Replace("WC-", "")) > 0)
        {
            System.Data.DataView dvRecord = Workers_Comp_Claims_OH.SelectAssociatedFirstReportByPk(Convert.ToDecimal(objwc.FROI_Number.Replace("WC-", ""))).Tables[0].DefaultView;
            if (dvRecord != null && dvRecord.Count > 0)
            {
                txtAssociatedFirstReport.Text = Convert.ToString(dvRecord[0]["WC_FR_NUMBER"]);
                txtClaimNumber.Text = objwc.Claim_Number;
                if (objwc.Date_Closed != null) txtDateClaimClosed.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objwc.Date_Closed));
                if (objwc.Date_Entered != null) txtDateClaimEntered.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objwc.Date_Entered));
                if (objwc.Date_Reopened != null) txtDateClaimReopened.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objwc.Date_Reopened));
                //txtEmployeeName.Text = Convert.ToString(dvRecord[0]["NAME"]);
                txtSonicLocation.Text = Convert.ToString(dvRecord[0]["DBA"]);
                hdnid.Value = Convert.ToString(dvRecord[0]["PK_WC_FR_ID"]);
                btnAudit.Visible = true;
                ddlStatus.Text = objwc.Active_InActive;
                if (objwc.Associate_Name != null) txtAssociateName.Text = Convert.ToString(dvRecord[0]["NAME"]);
                if (objwc.Date_Of_Incident != null) txtDateofIncident.Text = Convert.ToString(dvRecord[0]["Date_Of_Incident"]);
                if (objwc.Total_Paid_To_Date != null) txtTotalPaid.Text = objwc.Total_Paid_To_Date.Value.ToString("N2");
                if (objwc.Date_Of_First_Transaction != null) txtDateofFirstTransaction.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objwc.Date_Of_First_Transaction));
                Session["Search"] = "Y";
                //txtType.Text = objwc.Type;
                //txtTotalMedical.Text = Convert.ToString(objwc.Total_Medical);
                //txtTotalComp.Text = Convert.ToString(objwc.Total_Comp);
                //txtTotalReserve.Text = Convert.ToString(objwc.Total_Reserve);
                //txtUnlimitedCost.Text = Convert.ToString(objwc.Unlimited_Cost);
                //txtLimitedtoMV.Text = Convert.ToString(objwc.Limited_to_MV);
                //txtHCPercent.Text = Convert.ToString(objwc.HC_Percent);
                //txtHCRelief.Text = Convert.ToString(objwc.HC_Relief);
                //txtSubrogationCollected.Text = Convert.ToString(objwc.Subrogation_Collected);
                //txtTotalCharged.Text = Convert.ToString(objwc.Total_Charged);
                //txtClaimActivity.Text = objwc.Claim_Activity;
            }

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
        DataTable dtFields = clsScreen_Validators.SelectByScreen(131).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Associated First Report":
                    strCtrlsIDs += txtAssociatedFirstReport.ClientID + ",";
                    strMessages += "Please enter Associated First Report" + ",";
                    Span7.Style["display"] = "inline-block";
                    Span22.Style["display"] = "inline-block";
                    break;
                //case "Employee Name":
                //    strCtrlsIDs += txtEmployeeName.ClientID + ",";
                //    strMessages += "Please enter Employee Name" + ",";
                //    Span1.Style["display"] = "inline-block";
                //    break;
                case "Claim Number":
                    strCtrlsIDs += txtClaimNumber.ClientID + ",";
                    strMessages += "Please enter Claim Number" + ",";
                    Span2.Style["display"] = "inline-block";
                    Span21.Style["display"] = "inline-block";
                    break;
                //case "Sonic Location d/b/a":
                //    strCtrlsIDs += txtSonicLocation.ClientID + ",";
                //    strMessages += "Please enter Sonic Location d/b/a" + ",";
                //    Span3.Style["display"] = "inline-block";
                //    break;
                case "Date Claim Entered":
                    strCtrlsIDs += txtDateClaimEntered.ClientID + ",";
                    strMessages += "Please enter Date Claim Opened" + ",";
                    Span4.Style["display"] = "inline-block";
                    Span26.Style["display"] = "inline-block";
                    break;
                //case "Date Claim Closed":
                //    strCtrlsIDs += ddlStatus.ClientID + ",";
                //    strMessages += "Please enter Claim Status" + ",";
                //    Span5.Style["display"] = "inline-block";
                //    Span27.Style["display"] = "inline-block";
                //    break;
                //case "Date Claim Reopened":
                //    strCtrlsIDs += txtDateClaimReopened.ClientID + ",";
                //    strMessages += "Please enter Date Claim Reopened" + ",";
                //    Span6.Style["display"] = "inline-block";
                //    Span28.Style["display"] = "inline-block";
                    break;
                case "Claim Status":
                    strCtrlsIDs += ddlStatus.ClientID + ",";
                    strMessages += "Please enter Claim Status" + ",";
                    Span8.Style["display"] = "inline-block";
                    Span29.Style["display"] = "inline-block";
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
