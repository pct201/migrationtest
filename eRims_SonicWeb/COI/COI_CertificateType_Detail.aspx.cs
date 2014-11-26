using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Collections;
using System.Reflection;
using System.ComponentModel;

public partial class COI_COI_CertificateType_Detail : System.Web.UI.Page
{

    #region Properties
    /// <summary>
    /// Year for SLT Safety
    /// </summary>
    private int CertificateTypeID
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["CT_ID"]))
            {
                return Convert.ToInt32(Request.QueryString["CT_ID"]);
            }
            else
            {
                return 0;
            }
        }
    }

    private int intCOI
    {
        get { return Convert.ToInt32(Encryption.Decrypt(Request.QueryString["coi"])); }
    }
    private int PK_COI_Certificate_Detail_ID
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                return Convert.ToInt32(Request.QueryString["id"]);
            }
            else
            {
                return 0;
            }
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindToEnum(typeof(clsGeneral.CertificateType), rdoGeneralRequired);
            BindToEnum(typeof(clsGeneral.CertificateOfLiabInsurAdditionalID), rblAdditionalInsured);
            BindToEnum(typeof(clsGeneral.EviOfCommPropAdditionalID), rblEvi_AddInterest);
            if (CertificateTypeID == 1)
            {
                //this.Page.Title = "Certificate of Liability Insurance";
                pnlCertOfLiabInsur.Style["Display"] = "";
                pnlChooseType.Style["Display"] = "none";
                pnlEviOfCPI.Style["Display"] = "none";
            }
            else if (CertificateTypeID == 2)
            {
                //this.Page.Title = "Evidence of Commercial Property Insurance";
                pnlCertOfLiabInsur.Style["Display"] = "none";
                pnlChooseType.Style["Display"] = "none";
                pnlEviOfCPI.Style["Display"] = "";
            }
            else
            {
                //this.Page.Title = "Choose Certificate Type";
                pnlCertOfLiabInsur.Style["Display"] = "none";
                pnlChooseType.Style["Display"] = "";
                pnlEviOfCPI.Style["Display"] = "none";
            }
            BindControls();
        }
    }

    //private void BindCertificateType()
    //{
    //    rdoGeneralRequired.DataSource = Enum.GetValues(typeof(clsGeneral.CertificateType));
    //    rdoGeneralRequired.DisplayMember = "Value";
    //    rdoGeneralRequired.ValueMember = "Key";
    //}

    public static void BindToEnum(Type enumType, ListControl lc)
    {
        // get the names from the enumeration
        string[] names = Enum.GetNames(enumType);
        // get the values from the enumeration
        Array values = Enum.GetValues(enumType);
        // turn it into a hash table
        Hashtable ht = new Hashtable();
        for (int i = 0; i < names.Length; i++)
            // note the cast to integer here is important
            // otherwise we'll just get the enum string back again
            ht.Add(GetEnumDescription((Enum)values.GetValue(i)), (int)values.GetValue(i));
        // return the dictionary to be bound to
        lc.DataSource = ht;
        lc.DataTextField = "Key";
        lc.DataValueField = "Value";
        lc.DataBind();
    }

    public static string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute),
            false);

        if (attributes != null &&
            attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }

    private void BindControls()
    {
        if (PK_COI_Certificate_Detail_ID > 0)
        {
            COI_CertificateType_Detail objCOI = new COI_CertificateType_Detail(PK_COI_Certificate_Detail_ID);
            if (CertificateTypeID == 1)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeTitle('Certificate of Liability Insurance');", true);
                txtDateIssued.Text = clsGeneral.FormatDBNullDateToDisplay(objCOI.Date_Issued);
                if (!string.IsNullOrEmpty(Convert.ToString(objCOI.Is_Certificate_Signed)))
                    rblSignedCerti.SelectedValue = Convert.ToBoolean(objCOI.Is_Certificate_Signed) == true ? "1" : "0";
                if (!string.IsNullOrEmpty(Convert.ToString(objCOI.Is_Waver_Of_Subrogation)))
                    rblWaverOfSub.SelectedValue = Convert.ToBoolean(objCOI.Is_Waver_Of_Subrogation) == true ? "1" : "0";
                if (!string.IsNullOrEmpty(Convert.ToString(objCOI.Is_Certificate_Include_NOC)))
                    rblCertiIncludes.SelectedValue = Convert.ToBoolean(objCOI.Is_Certificate_Include_NOC) == true ? "1" : "0";

                if (Convert.ToBoolean(objCOI.Is_Certificate_Include_NOC) == true)
                    txtNoOfDays.Enabled = true;
                else
                    txtNoOfDays.Enabled = false;
                txtNoOfDays.Text = Convert.ToString(objCOI.Number_of_Days);

                if (!string.IsNullOrEmpty(objCOI.FK_Additional_IDs))
                {
                    string[] AdditionalIDs = objCOI.FK_Additional_IDs.Split(',');
                    if (AdditionalIDs.Length > 0)
                    {
                        for (int i = 0; i <= AdditionalIDs.Length - 1; i++)
                        {
                            ListItem lst = rblAdditionalInsured.Items.FindByValue(AdditionalIDs[i]);
                            if (lst != null)
                                lst.Selected = true;
                        }
                    }
                }

            }
            else if (CertificateTypeID == 2)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeTitle('Evidence of Commercial Property Insurance');", true);
                txtEvi_DateIssued.Text = clsGeneral.FormatDBNullDateToDisplay(objCOI.Date_Issued);
                if (!string.IsNullOrEmpty(Convert.ToString(objCOI.Is_Certificate_Signed)))
                    rblEvi_SignedCerti.SelectedValue = Convert.ToBoolean(objCOI.Is_Certificate_Signed) == true ? "1" : "0";
                if (!string.IsNullOrEmpty(Convert.ToString(objCOI.Is_MasterClause_Required)))
                    rblMasterNoReq.SelectedValue = Convert.ToBoolean(objCOI.Is_MasterClause_Required) == true ? "1" : "0";
                if (!string.IsNullOrEmpty(Convert.ToString(objCOI.Is_Loss_Payee_Required)))
                    rblLossPayee.SelectedValue = Convert.ToBoolean(objCOI.Is_Loss_Payee_Required) == true ? "1" : "0";

                if (!string.IsNullOrEmpty(objCOI.FK_Additional_IDs))
                {
                    string[] AdditionalIDs = objCOI.FK_Additional_IDs.Split(',');
                    if (AdditionalIDs.Length > 0)
                    {
                        for (int i = 0; i <= AdditionalIDs.Length - 1; i++)
                        {
                            ListItem lst = rblEvi_AddInterest.Items.FindByValue(AdditionalIDs[i]);
                            if (lst != null)
                                lst.Selected = true;
                        }
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeTitle('Choose Certificate Type');", true);
            }
        }
    }

    protected void rdoGeneralRequired_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoGeneralRequired.SelectedValue == "1")
        {
            pnlCertOfLiabInsur.Style["Display"] = "";
            pnlChooseType.Style["Display"] = "none";
            pnlEviOfCPI.Style["Display"] = "none";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeTitle('Certificate of Liability Insurance');", true);
        }
        else if (rdoGeneralRequired.SelectedValue == "2")
        {
            pnlCertOfLiabInsur.Style["Display"] = "none";
            pnlChooseType.Style["Display"] = "none";
            pnlEviOfCPI.Style["Display"] = "";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeTitle('Evidence of Commercial Property Insurance');", true);
        }
        else
        {
            pnlCertOfLiabInsur.Style["Display"] = "none";
            pnlChooseType.Style["Display"] = "";
            pnlEviOfCPI.Style["Display"] = "";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeTitle('Choose Certificate Type');", true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        COI_CertificateType_Detail objCT = new COI_CertificateType_Detail();
        if (!string.IsNullOrEmpty(txtDateIssued.Text))
            objCT.Date_Issued = Convert.ToDateTime(txtDateIssued.Text);
        if (CertificateTypeID == 0)
            objCT.FK_CertificateType_ID = 1;
        else
            objCT.FK_CertificateType_ID = CertificateTypeID;
        objCT.FK_COIs = intCOI;
        objCT.Is_Certificate_Signed = clsGeneral.FormatYesNoToStore(rblSignedCerti);
        objCT.Is_Waver_Of_Subrogation = clsGeneral.FormatYesNoToStore(rblWaverOfSub);
        objCT.Is_Certificate_Include_NOC = clsGeneral.FormatYesNoToStore(rblCertiIncludes);
        if (txtNoOfDays.Text != "" && txtNoOfDays.Enabled)
            objCT.Number_of_Days = Convert.ToInt32(txtNoOfDays.Text);
        int tmp_PK_COI_Certificate_Detail_ID = 0;

        if (PK_COI_Certificate_Detail_ID == 0)
            tmp_PK_COI_Certificate_Detail_ID = objCT.Insert();
        else
        {
            tmp_PK_COI_Certificate_Detail_ID = PK_COI_Certificate_Detail_ID;
            objCT.PK_COI_Certificate_Detail_ID = tmp_PK_COI_Certificate_Detail_ID;
            objCT.Update();
        }
        COI_CertificateType_Additional_Detail.Delete(tmp_PK_COI_Certificate_Detail_ID);

        COI_CertificateType_Additional_Detail objAdditionalCT = new COI_CertificateType_Additional_Detail();

        for (int i = 0; i <= rblAdditionalInsured.Items.Count - 1; i++)
        {
            if (rblAdditionalInsured.Items[i].Selected == true)
            {
                objAdditionalCT.FK_COI_Certificate_Detail_ID = tmp_PK_COI_Certificate_Detail_ID;
                objAdditionalCT.FK_Additional_ID = Convert.ToDecimal(rblAdditionalInsured.Items[i].Value);
                objAdditionalCT.Insert();
            }
        }

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
    }
    protected void btnEVI_Save_Click(object sender, EventArgs e)
    {
        COI_CertificateType_Detail objCT = new COI_CertificateType_Detail();
        if (!string.IsNullOrEmpty(txtEvi_DateIssued.Text))
            objCT.Date_Issued = Convert.ToDateTime(txtEvi_DateIssued.Text);
        if (CertificateTypeID == 0)
            objCT.FK_CertificateType_ID = 2;
        else
            objCT.FK_CertificateType_ID = CertificateTypeID;
        objCT.FK_COIs = intCOI;
        objCT.Is_Certificate_Signed = clsGeneral.FormatYesNoToStore(rblEvi_SignedCerti);
        objCT.Is_MasterClause_Required = clsGeneral.FormatYesNoToStore(rblMasterNoReq);
        objCT.Is_Loss_Payee_Required = clsGeneral.FormatYesNoToStore(rblLossPayee);

        int tmp_PK_COI_Certificate_Detail_ID = 0;

        if (PK_COI_Certificate_Detail_ID == 0)
            tmp_PK_COI_Certificate_Detail_ID = objCT.Insert();
        else
        {
            tmp_PK_COI_Certificate_Detail_ID = PK_COI_Certificate_Detail_ID;
            objCT.PK_COI_Certificate_Detail_ID = tmp_PK_COI_Certificate_Detail_ID;
            objCT.Update();
        }
        COI_CertificateType_Additional_Detail.Delete(tmp_PK_COI_Certificate_Detail_ID);

        COI_CertificateType_Additional_Detail objAdditionalCT = new COI_CertificateType_Additional_Detail();

        for (int i = 0; i <= rblEvi_AddInterest.Items.Count - 1; i++)
        {
            if (rblEvi_AddInterest.Items[i].Selected == true)
            {
                objAdditionalCT.FK_COI_Certificate_Detail_ID = tmp_PK_COI_Certificate_Detail_ID;
                objAdditionalCT.FK_Additional_ID = Convert.ToDecimal(rblEvi_AddInterest.Items[i].Value);
                objAdditionalCT.Insert();
            }
        }

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
    }
    protected void btnEVI_Cancel_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
    }
    protected void rblCertiIncludes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblCertiIncludes.SelectedValue == "1")
            txtNoOfDays.Enabled = true;
        else
        {
            txtNoOfDays.Text = "";
            txtNoOfDays.Enabled = false;
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (rdoGeneralRequired.SelectedValue == "1")
        {
            pnlCertOfLiabInsur.Style["Display"] = "";
            pnlChooseType.Style["Display"] = "none";
            pnlEviOfCPI.Style["Display"] = "none";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeTitle('Certificate of Liability Insurance');", true);
        }
        else if (rdoGeneralRequired.SelectedValue == "2")
        {
            pnlCertOfLiabInsur.Style["Display"] = "none";
            pnlChooseType.Style["Display"] = "none";
            pnlEviOfCPI.Style["Display"] = "";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeTitle('Evidence of Commercial Property Insurance');", true);
        }
        else
        {
            pnlCertOfLiabInsur.Style["Display"] = "none";
            pnlChooseType.Style["Display"] = "";
            pnlEviOfCPI.Style["Display"] = "";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeTitle('Choose Certificate Type');", true);
        }
    }
    protected void btnCancelCertificateType_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
    }
}