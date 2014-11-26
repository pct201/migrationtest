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
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using System.IO;

public partial class COI_GenerateLetters : clsBasePage
{
    // NOTE : 2A referes record for step 2A given in the doc. that is either it's expired or cancelled.
    // 2B referres reocords for step 2B give in the doc. that is inadequate reocord. means minimum value is not 
    // set for COI as defined by it's Risk Profile.
    // 2C refferes record for non compliance

    # region " Constants "

    // table names and array of those tables used to fetch values for 
    // policies one by one from select 2A and 2B tables
    private const string tblGeneralPolicy = "COI_General_Policies";
    private const string tblAutomobilePolicy = "COI_Automobile_Policies";
    private const string tblExcessPolicy = "COI_Excess_Policies";
    private const string tblWCPolicy = "COI_WC_Policies";
    private const string tblProfessionalPolicy = "COI_Professional_Policies";
    private const string tblPropertyPolicy = "COI_Property_Policies";
    private const string tblLiquorPOlicy = "COI_Liquor_Policies";
    private string[] arrPolicyTables = { tblGeneralPolicy, tblAutomobilePolicy, tblExcessPolicy, tblWCPolicy, tblProfessionalPolicy, tblPropertyPolicy, tblLiquorPOlicy };
    //private const string strPrintPageBreak = "<div style=\"page-break-after: always\">&nbsp;</div>";

    private const string strPrintPageBreak = "<br style=\"page-break-before: always\">";
    //private const string strFontSize = "-22";
    private const string strFontSize = "12";
    private const string strEnvelopeFontSize = "15";
    //private const string strFontSize = "16";
    //private const string strLandscapSetting = "style='writing-mode: tb-rl;height: 80%;margin: 10% 0%'";
    private const string strLandscapSetting = "";
    #endregion

    #region "Properties"

    private DataTable dtCOI
    {
        get { return (DataTable)ViewState["dtCOI"]; }
        set { ViewState["dtCOI"] = value; }
    }

    private DataTable dtRequiredPoliciesCOIs
    {
        get { return (DataTable)ViewState["dtRequiredPoliciesCOIs"]; }
        set { ViewState["dtRequiredPoliciesCOIs"] = value; }
    }

    private DataTable dt2A
    {
        get { return (DataTable)ViewState["dt2A"]; }
        set { ViewState["dt2A"] = value; }
    }

    private DataTable dt2B
    {
        get { return (DataTable)ViewState["dt2B"]; }
        set { ViewState["dt2B"] = value; }
    }


    #endregion

    # region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (App_Access == AccessType.View_Only)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                if (App_Access == AccessType.Administrative_Access)
                {

                   

                    DataTable dtSign = COI_Signature.SelectAll().Tables[0];
                    drpSignature.DataSource = dtSign;
                    drpSignature.DataTextField = "Fld_Desc";
                    drpSignature.DataValueField = "PK_COI_Signature";
                    drpSignature.DataBind();
                    drpSignature.Items.Insert(0, "--Select--");
                    drpSignature.Focus();
                }
            }
        }
    }

    #endregion

    #region "Other Controls Events"
    protected void lnkPrintLetters_Click(object sender, EventArgs e)
    {
        //clsGeneral.SaveFile(litLetter.Text, "d:\\", "COIDOC.DOC");
        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        Aspose.Words.Document doc = new Aspose.Words.Document();

        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
        //builder.Font.Size = 12;
        //builder.Font.Bold = false;
        //builder.Font.Color = System.Drawing.Color.Black;
        //builder.Font.Name = "Times New Roman";
        builder.PageSetup.PaperSize = PaperSize.Letter;
        builder.PageSetup.BottomMargin = 40;
        builder.PageSetup.TopMargin = 40;
        builder.PageSetup.LeftMargin = 40;
        builder.PageSetup.RightMargin = 40;
        builder.InsertParagraph();
        builder.InsertHtml(litLetter.Text);


        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;

        doc.MailMerge.DeleteFields();
        //doc.Save("CertificateOfInsurance.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        doc.Save(Response, "CertificateOfInsurance.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        //doc.Save("D:\\COIDOCS.html", SaveFormat.Html);
        Response.End();        
    }

    protected void lnkPrintEnvelopes_Click(object sender, EventArgs e)
    {
        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        Aspose.Words.Document doc = new Aspose.Words.Document();

        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);

        builder.PageSetup.TopMargin = 60.0;
        builder.PageSetup.BottomMargin = 50.0;
        builder.PageSetup.PaperSize = PaperSize.EnvelopeDL;
        builder.Font.Size = 12;
        builder.Font.Bold = false;
        builder.Font.Color = System.Drawing.Color.Black;
        builder.Font.Name = "Times New Roman";
        builder.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;
        builder.InsertParagraph();
        builder.InsertHtml(litEnvelopes.Text);
        //builder.Write(litLetter.Text);
        //doc.MailMerge.Execute(dt);
        //Don't need merge fields in the document anymore.
        doc.MailMerge.DeleteFields();

        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;
        //doc.Save("CertificateOfInsurance.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        doc.Save(Response, "CertificateOfInsurance.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        Response.End();
        ///////////
    }
    #endregion

    # region " Private Functions "

    /// <summary>
    /// for each policy we have to specify some Text on letter.
    /// this function returns this text. like General Policy,Automobile Policy based on table name of policy passed.
    /// </summary>
    /// <param name="strTableName">table name in db for which we need the text</param>
    /// <returns></returns>
    private string GetPolicyNameByTableName(string strTableName)
    {
        string retVal = "";
        switch (strTableName)
        {
            case "COI_General_Policies":
                retVal = "General Liability";
                break;
            case "COI_Automobile_Policies":
                retVal = "Automobile Liability";
                break;
            case "COI_Excess_Policies":
                retVal = "Excess Liability";
                break;
            case "COI_WC_Policies":
                retVal = "WC Liability";
                break;
            case "COI_Property_Policies":
                retVal = "Property Liability";
                break;
            case "COI_Professional_Policies":
                retVal = "Professional Liability";
                break;
            case "COI_Liquor_Policies":
                retVal = "Other Liability";
                break;
        }
        return retVal;
    }

    /// <summary>
    /// for each coverage field we have to show some text on letter.
    /// this function returns this text. like Occurence Coverage for General_OCCurence,etc.
    /// </summary>
    /// <param name="strFieldName">field name from db</param>
    /// <returns></returns>
    private string GetCoverageNameByFieldName(string strFieldName)
    {
        string retVal = "";
        switch (strFieldName)
        {

            case "General_Occurence_Coverage":
                retVal = "General Occurence Coverage";
                break;
            case "General_Fire_Damage":
                retVal = "General Fire Damage Coverage";
                break;
            case "General_Medical_Expense":
                retVal = "General Medical Expense Coverage";
                break;
            case "General_Personal_Advertising_Inju":
                retVal = "General Personal Advertising InjuCoverage";
                break;
            case "General_General_Aggregate":
                retVal = "General General Aggregate Coverage";
                break;
            case "General_Products_Operations_Produ":
                retVal = "General Products Operations ProduCoverage";
                break;
            case "General_Stop_Gap_Coverage":
                retVal = "General Stop Gap Coverage";
                break;
            case "General_Auto_Coverage":
                retVal = "General Auto Coverage";
                break;
            case "Auto_Combined_Single_Limit":
                retVal = "Auto Combined Single Limit Coverage";
                break;
            case "Auto_Bodily_Injury_Person":
                retVal = "Auto Bodily Injury Person Coverage";
                break;
            case "Auto_Bodily_Injury_Accident":
                retVal = "Auto Bodily Injury Accident Coverage";
                break;
            case "Auto_Property_Damage":
                retVal = "Auto Property Damage Coverage";
                break;
            case "Excess_Occurrence_Coverage":
                retVal = "Excess Occurrence Coverage";
                break;
            case "Excess_Aggregate_Coverage":
                retVal = "Excess Aggregate Coverage";
                break;
            case "Excess_Retention_Amount":
                retVal = "Excess Retention Amount Coverage";
                break;
            case "Excess_Accept_Limits_Coverage":
                retVal = "Excess Accept Limits Coverage";
                break;
            case "Excess_Special_Umbrella_Coverage":
                retVal = "Excess Special Umbrella Coverage";
                break;
            case "WC_Accident":
                retVal = "WC Accident Coverage";
                break;
            case "WC_Disease_Each":
                retVal = "WC Disease Each Coverage";
                break;
            case "WC_Disease_Limit":
                retVal = "WC Disease Limit Coverage";
                break;
            case "Property_Deductible":
                retVal = "Property Deductible Coverage";
                break;
            case "Property_Flood_Coverage":
                retVal = "Property Flood Coverage";
                break;
            case "Property_Wind_Hail_Coverage":
                retVal = "Property Wind Hail Coverage";
                break;
            case "Property_Earth_Movement_Coverage":
                retVal = "Property Earth Movement Coverage";
                break;
            case "Property_BI_Occurrence":
                retVal = "Property BI Occurrence Coverage";
                break;
            case "Property_BI_Aggregate":
                retVal = "Property BI Aggregate Coverage";
                break;
            case "Property_Building_Occurrence":
                retVal = "Property Building Occurrence Coverage";
                break;
            case "Property_Building_Aggregate":
                retVal = "Property Building Aggregate Coverage";
                break;
            case "Property_Equipment_Occurrence":
                retVal = "Property Equipment Occurrence Coverage";
                break;
            case "Property_Equipment_Aggregate":
                retVal = "Property Equipment Aggregate Coverage";
                break;
            case "Property_Sign_Occurrence":
                retVal = "Property Sign Occurrence Coverage";
                break;
            case "Property_SIgn_Aggregate":
                retVal = "Property SIgn Aggregate Coverage";
                break;
            case "Property_Glass_Occurrence":
                retVal = "Property Glass Occurrence Coverage";
                break;
            case "Property_Glass_Aggregate":
                retVal = "Property Glass Aggregate Coverage";
                break;
            case "Professional_Occurence":
                retVal = "Professional Occurrence Coverage";
                break;
            case "Professional_Aggregate":
                retVal = "Professional Aggregate Coverage";
                break;
            case "Liquor_Occurence":
                retVal = "Other Liability Occurrence Coverage";
                break;
            case "Liquor_Aggregate":
                retVal = "Other Liability Aggregate Coverage";
                break;
            case "Update_Date":
                retVal = "Update DateCoverage";
                break;
            case "Updated_By":
                retVal = "Updated ByCoverage";
                break;
        }
        return retVal;
    }

    /// <summary>
    /// it retuns blank row that is used to generate HTML format email to be sent.
    /// </summary>
    /// <param name="Height">height of the blank row</param>
    /// <returns>blank row HTML tag</returns>
    private string GetBlankRow(int Height)
    {
        //return string.Concat("<tr><td class=\"Spacer\" style=\"height:", Height.ToString(), "px\"></td></tr>");

        return string.Concat("<tr><td height=" + Height.ToString() + "></td></tr>");
        //return string.Concat("<tr><td style=\"height:", Height.ToString(), "px\"></td></tr>");
    }

    /// <summary>
    /// return an HTML tag for a row with it's content
    /// </summary>
    /// <param name="Content"></param>
    /// <returns></returns>
    private string GetContentRow(string Content)
    {
        return string.Concat("<tr><td>", Content, "</td></tr>");
    }

    /// <summary>
    /// add a reocrd in letter history db table for currently generated letter.
    /// </summary>
    /// <param name="dt2A">it contains records for expired or cancelled</param>
    /// <param name="dt2B">it contains records for inadequate coverage</param>
    /// <param name="dt2C">it contains records for noncompliance</param>
    /// <param name="PK_COI">Primary key of cuurent COI</param>
    /// <param name="intLevel">level of level to be generated</param>
    /// <param name="strLevelText">level text to be added in letter history based on level</param>
    private void AddCoverageStatusToLetterHistory(DataTable dt2A, DataTable dt2B, DataTable dt2C, decimal PK_COI, int intLevel, string strLevelText, string strLetter, string strEnvelopes)
    {
        // create new letter history record
        COI_Letter_History objLetterHistory = new COI_Letter_History();

        // array to hold record for perticular policy
        // it's used to count the number of rows.and get status from it.
        DataRow[] drPolicy2A;

        // set status for general policy        

        // get records for current coi whose policy is general policy
        drPolicy2A = dt2A.Select("Policy_Type = '" + arrPolicyTables[0] + "' AND PK_COIs = " + PK_COI.ToString());

        // if records found satisfying 2A condition,it's status could be Cancelled(2) or Expired(1)        
        if (drPolicy2A.Length > 0)
            // we already fetch record specifying order by , so we have to get top record to fetch the status
            objLetterHistory.FK_COI_Coverage_Status_General = Convert.ToInt16(drPolicy2A[0]["Status"]);
        else if (dt2B.Select("Policy_Type = '" + arrPolicyTables[0] + "' AND PK_COIs = " + PK_COI.ToString()).Length > 0)
            // if record found in 2B, then it must have status Inadequate (4)
            objLetterHistory.FK_COI_Coverage_Status_General = 4;
        else
            // if no record found for general policy for 2,3 or 4 , make it active.
            objLetterHistory.FK_COI_Coverage_Status_General = 1;


        // set status for automobile policy
        // logic is same as general policy
        drPolicy2A = dt2A.Select("Policy_Type = '" + arrPolicyTables[1] + "' AND PK_COIs = " + PK_COI.ToString());
        if (drPolicy2A.Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_Automobile = Convert.ToInt16(drPolicy2A[0]["Status"]);
        else if (dt2B.Select("Policy_Type = '" + arrPolicyTables[1] + "' AND PK_COIs = " + PK_COI.ToString()).Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_Automobile = 4;
        else
            objLetterHistory.FK_COI_Coverage_Status_Automobile = 1;

        // set status for excess policy
        // logic is same as general policy
        drPolicy2A = dt2A.Select("Policy_Type = '" + arrPolicyTables[2] + "' AND PK_COIs = " + PK_COI.ToString());
        if (drPolicy2A.Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_Excess = Convert.ToInt16(drPolicy2A[0]["Status"]);
        else if (dt2B.Select("Policy_Type = '" + arrPolicyTables[2] + "' AND PK_COIs = " + PK_COI.ToString()).Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_Excess = 4;
        else
            objLetterHistory.FK_COI_Coverage_Status_Excess = 1;

        // set status for WC policy
        // logic is same as general policy
        drPolicy2A = dt2A.Select("Policy_Type = '" + arrPolicyTables[3] + "' AND PK_COIs = " + PK_COI.ToString());
        if (drPolicy2A.Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_WC = Convert.ToInt16(drPolicy2A[0]["Status"]);
        else if (dt2B.Select("Policy_Type = '" + arrPolicyTables[3] + "' AND PK_COIs = " + PK_COI.ToString()).Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_WC = 4;
        else
            objLetterHistory.FK_COI_Coverage_Status_WC = 1;

        // set status for WC policy
        // logic is same as general policy
        drPolicy2A = dt2A.Select("Policy_Type = '" + arrPolicyTables[4] + "' AND PK_COIs = " + PK_COI.ToString());
        if (drPolicy2A.Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_Prfessional = Convert.ToInt16(drPolicy2A[0]["Status"]);
        else if (dt2B.Select("Policy_Type = '" + arrPolicyTables[4] + "' AND PK_COIs = " + PK_COI.ToString()).Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_Prfessional = 4;
        else
            objLetterHistory.FK_COI_Coverage_Status_Prfessional = 1;

        // set status for WC policy
        // logic is same as general policy
        drPolicy2A = dt2A.Select("Policy_Type = '" + arrPolicyTables[5] + "' AND PK_COIs = " + PK_COI.ToString());
        if (drPolicy2A.Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_Property = Convert.ToInt16(drPolicy2A[0]["Status"]);
        else if (dt2B.Select("Policy_Type = '" + arrPolicyTables[5] + "' AND PK_COIs = " + PK_COI.ToString()).Length > 0)
            objLetterHistory.FK_COI_Coverage_Status_Property = 4;
        else
            objLetterHistory.FK_COI_Coverage_Status_Property = 1;



        // set field for non compliancy defficiency

        DataRow dr = dt2C.Rows[0];

        // for each field belongs to non compliance , if it's N we have to set Y in letter history and vice versa
        objLetterHistory.Cancellation_Notice = (dr["Cancellation_Notice"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.Primary_Provided = (dr["Primary_Provided"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.All_Locations = (dr["All_Locations"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.Signed_Certificate_Received = (dr["Signed_Certificate_Received"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.Insured_Name_Same = (dr["Insured_Name_Same"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.AM_Best = (dr["AM_Best"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.Ordinance_Law = (dr["Ordinance_Law"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.Subrogation_Waiver = (dr["Subrogation_Waiver"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.Perils_Insured_Form = (dr["Perils_Insured_Form"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.Replacement_Cost = (dr["Replacement_Costs"].ToString() == "N") ? "Y" : "N";

        objLetterHistory.Property_On_Acord = (dr["Property_On_Acord"].ToString() == "N") ? "Y" : "N";


        // set other fields
        objLetterHistory.Date_Letter_Sent = DateTime.Today; // current date
        objLetterHistory.FK_COIs = PK_COI; // set current coi
        objLetterHistory.Sent_By_EMail = "Y"; // send email
        objLetterHistory.Update_Date = DateTime.Today; // set current date
        objLetterHistory.Updated_By = ""; // not specified for now

        // set level text based on level passed
        switch (intLevel)
        {
            case 1:
                objLetterHistory.LeveL_1_Text = strLevelText;
                break;
            case 2:
                objLetterHistory.LeveL_2_Text = strLevelText;
                break;
            case 3:
                objLetterHistory.LeveL_3_Text = strLevelText;
                break;
            case 4:
                objLetterHistory.LeveL_4_Text = strLevelText;
                break;
        }

        // set letter level in history table
        objLetterHistory.FK_COI_Noncompliance_Level = intLevel;

        objLetterHistory.Letter = strLetter;
        objLetterHistory.Envelopes = strEnvelopes;

        // add history record
        objLetterHistory.Insert();

    }

    /// <summary>
    /// Generates PDF for HTML text
    /// </summary>
    /// <param name="strLetterText">HTML Text</param>
    private void GenerateLetterPDF(string strLetterText, string strType)
    {
        aspPDF.EASYPDF pdf = new aspPDF.EASYPDF();
        pdf.Create();

        // set page orientation either 0 for portrait or 1 for landscap 
        if (strType == "Letter")
        {
            pdf.Page("Letter", 0);
            pdf.SetMargins(30, 30, 10, 0);
        }
        else
        {
            pdf.Page("Letter", 1);
            pdf.SetMargins(70, 30, 10, 0);
        }

        pdf.AddHTML(strLetterText);
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment; filename=CertificateOfInsurance.PDF");

        Response.BinaryWrite((byte[])pdf.SaveVariant());
        Response.Flush();
        Response.Close();
        Response.End();
    }


    private void BindSignatureDropdown(string strSignatures)
    {
        DataTable dtSign = COI_Signature.SelectByIDs(strSignatures).Tables[0];
        drpSignature.DataSource = dtSign;
        drpSignature.DataTextField = "Fld_Desc";
        drpSignature.DataValueField = "PK_COI_Signature";
        drpSignature.DataBind();
        drpSignature.Items.Insert(0, "--Select--");
    }

    private string GetSignaturesList(DataTable dt)
    {
        string strSignatures = "";
        foreach (DataRow dr in dt.Rows)
        {
            strSignatures = dr["FK_COI_Signature"].ToString() + ",";
        }
        strSignatures = strSignatures.TrimEnd(',');

        return strSignatures;
    }

    private string GetEnvelopeContents(string Contact_First_Name, string Contact_Last_Name, string Insured_Name, string Address_1, string Address_2, string City, decimal FK_State, string Zip_Code)
    {
        StringBuilder Envelopes = new StringBuilder();
        // all blank row height can be set by this constant
        const int RowSpacing = 8;
        // starting envelope body                            
        Envelopes.Append("<html><head><style>.break { page-break-before: always; }</style></head><body><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\" >");


        /*************** Changed code *************************/

        //Envelopes.Append(GetBlankRow(RowSpacing));
        //Envelopes.Append(GetBlankRow(RowSpacing));
        Envelopes.Append(GetContentRow("<table width='100%'><tr><td width='7%'>&nbsp;</td><td align=left style=\"width:90%;vertical-align:top\">Risk Management Department</td></tr></table>"));

        string strEnvelopeAddress;
        strEnvelopeAddress = "<table width='100%'>";
        strEnvelopeAddress = strEnvelopeAddress + GetContentRow(Contact_First_Name + " " + Contact_Last_Name);
        strEnvelopeAddress = strEnvelopeAddress + GetContentRow(Insured_Name);
        strEnvelopeAddress = strEnvelopeAddress + GetContentRow(Address_1);

        if (!string.IsNullOrEmpty(Address_2))
            strEnvelopeAddress = strEnvelopeAddress + GetContentRow(Address_2);
        COI_State objstate1 = new COI_State(FK_State);
        string strAddress = "";
        strAddress = City;
        if (!string.IsNullOrEmpty(objstate1.FLD_state))
            strAddress = strAddress != string.Empty ? strAddress + ", " + objstate1.FLD_state : objstate1.FLD_state;
        if (Zip_Code != string.Empty)
            strAddress = strAddress != string.Empty ? strAddress + " " + Zip_Code : Zip_Code;

        if (strAddress != string.Empty)
            strEnvelopeAddress = strEnvelopeAddress + GetContentRow(strAddress) + "</table>";
        strEnvelopeAddress = GetContentRow("<table style=\"width:100%\"><tr><td width=\"35%\">&nbsp;</td><td align=\"left\">" + strEnvelopeAddress + "</td></tr></table>");

        //Envelopes.Append("<table style=\"width:100%\">");

        Envelopes.Append(GetBlankRow(RowSpacing));
        Envelopes.Append(GetBlankRow(RowSpacing));
        Envelopes.Append(GetBlankRow(RowSpacing));
        Envelopes.Append(GetBlankRow(RowSpacing));
        Envelopes.Append(GetBlankRow(RowSpacing));

        //Envelopes.Append("</table>");
        Envelopes.Append(strEnvelopeAddress);
        /******************************************************/


        Envelopes.Append("</table></body></html>");

        return Envelopes.ToString();
    }
    # endregion

    #region "Control Events"

    protected void btnGenerate_Click(object sender, EventArgs e)
    {

        // get list of cois along with it's level to generate letter.
        dtCOI = clsGenerateLetter.SelectValidCOIForLetter(Convert.ToDecimal(drpSignature.SelectedValue)).Tables[0];

        // get list of cois along with policy type(general,excess,professional etc)
        // for which Required is set to Y but no record added to the policy for that COI.
        dtRequiredPoliciesCOIs = clsGenerateLetter.GetRequiredPoliciesCOIs().Tables[0];

        // get records with policytype(to indicate record is for which policy),pkcoi and status
        // if it's cancelled then 2, expired then 1
        dt2A = clsGenerateLetter.GetExpiredOrCancelledCOIs().Tables[0];

        // get records policytype(db table name of policy for which deficiency is found)
        // coverage name(field name of coverage),coi,it's level and status(always 4).
        dt2B = clsGenerateLetter.GetInAdequateCoverageCOIs().Tables[0];

        // get selected signature
        string strSignature = drpSignature.SelectedValue;

        // letter contains , coverage part and no compliance part
        // letter header contains - header text as per letter format
        // letter footer contains - footer text as per leeter format given.(e.g: copies,signature etc.)
        StringBuilder Letter, LetterFooter, LetterHeader, Envelopes, EnvelopesCC;
        // initalize string builters for letter contents like header,footer,etc.
        Letter = new StringBuilder("");
        LetterHeader = new StringBuilder("");
        LetterFooter = new StringBuilder("");
        Envelopes = new StringBuilder("");
        EnvelopesCC = new StringBuilder("");
        string strCurrentLetterText = "";
        string strCurrentEnvelopeAddress = "";

        // generate return address that is needed for all the reports
        Return_Address objReturnAddress = new Return_Address();
        StringBuilder ReturnAddress = new StringBuilder();
        string ReturnAddressEnvelop = "";
        ReturnAddress.Append(objReturnAddress.Company + "<br>");
        ReturnAddress.Append(objReturnAddress.Address_1 + "<br>");

        if (objReturnAddress.Address_2.Length > 0)
        {
            ReturnAddress.Append(objReturnAddress.Address_2 + "<br>");
        }

        ReturnAddress.Append(objReturnAddress.City + ", " + new State(objReturnAddress.FK_State).FLD_state + " " + objReturnAddress.ZIP_Code + "<br>");
        ReturnAddressEnvelop = ReturnAddress.ToString() + objReturnAddress.First_Name + ", " + objReturnAddress.Last_Name + " " + objReturnAddress.Department;

        // count the number of Cois those are liable for generating letters
        int COICount = dtCOI.Rows.Count;
        if (COICount > 0)
        {
            // if any COI is found

            // all blank row height can be set by this constant
            const int RowSpacing = 8;

            int Count2A, Count2B, CountRequiredPolicy; // used to get no of reocrds
            DataRow[] dr2A, dr2B, drRequiredPolicy;
            int PK_COI, intLevel;
            COIs objCOI;
            bool GenerateLetter = false;
            // if at end it's true then letter will be generated and sent an email else not.

            for (int i = 0; i < COICount; i++)
            {
                // loop through coi...
                // check for each coi to generate letter or not.

                // initialize generate letter status for current coi
                GenerateLetter = false;
                //GenerateLetter = true;

                // cretae object of current coi and set it's primary key in this variable
                PK_COI = Convert.ToInt32(dtCOI.Rows[i]["PK_COIs"]);
                intLevel = Convert.ToInt32(dtCOI.Rows[i]["intLevel"]);
                objCOI = new COIs(PK_COI);

                // initalize string builters for letter contents like header,footer,etc.
                Letter.Length = 0;
                LetterHeader.Length = 0;
                LetterFooter.Length = 0;

                if (intLevel == 0)
                {
                    # region " Generate Letter for No Certificate Received "

                    if (objCOI.Signed_Certificate_Received == "N")
                    {
                        // append details to letter realted to COI.(LETTER HEADER)
                        # region " Letter Header "

                        // starting letter body
                        if (i == 0)
                        {
                            LetterHeader.Append("<html><head><style>.break{ page-break-before: always; }</style></head>");
                            LetterHeader.Append("<body>");
                        }

                        LetterHeader.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
                        // company logo and return adddress
                        LetterHeader.Append(GetContentRow("<table><tr><td><img src='" + AppConfig.SiteURL + "CompanyLogo.jpg'/></td><td>&nbsp;&nbsp;</td><td style=\"vertical-align:top\">" + ReturnAddress.ToString() + "</td></tr></table>"));
                        //LetterHeader.Append(GetContentRow("<table><tr><td><img src='" + AppConfig.SiteURL + "CompanyLogo.jpg'/></td>"));
                        //LetterHeader.Append(GetContentRow(ReturnAddress.ToString()));
                        //LetterHeader.Append("</table>");
                        //LetterHeader.Append(GetContentRow("<table><tr><td><img src='" + AppConfig.SitePath + "CompanyLogo.jpg'/></td></tr></table>"));
                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetContentRow(DateTime.Today.ToString(AppConfig.DisplayDateFormat)));
                        LetterHeader.Append(GetBlankRow(RowSpacing));

                        COI_Insureds objInsured = new COI_Insureds(objCOI.FK_COI_Insureds);
                        LetterHeader.Append(GetContentRow(objInsured.Insured_Name));
                        // LetterHeader.Append(GetContentRow(objInsured.Contact_First_Name + " " + objInsured.Contact_Last_Name));
                        LetterHeader.Append(GetContentRow(objInsured.Address_1));
                        if (!string.IsNullOrEmpty(objInsured.Address_2))
                            LetterHeader.Append(GetContentRow(objInsured.Address_2));

                        //COI_State objstate = new COI_State(objInsured.FK_State);
                        if (string.IsNullOrEmpty(objInsured.Fld_State))
                        {
                            LetterHeader.Append(GetContentRow(objInsured.City + " " + objInsured.Zip_Code));
                        }
                        else
                        {
                            LetterHeader.Append(GetContentRow(objInsured.City + ", " + objInsured.Fld_State + " " + objInsured.Zip_Code));
                        }
                        //objstate = null;

                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetContentRow("Dear" + " " + objInsured.Insured_Name));
                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        #endregion

                        # region " Actual Letter Content "

                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        //below text is changed as per discussion on skype of steve and nikunj on 3-Jun-2014. 
                        //LetterHeader.Append(GetContentRow("The Certificate of Insurance that you have provided contains the following deficiencies that need to be corrected within the next 30 days:"));
                        LetterHeader.Append(GetContentRow("No Certificate of Insurance (COI) has been received and a COI is required for your location for the current year."));                        
                        LetterHeader.Append(GetBlankRow(RowSpacing));

                        #endregion

                        // append details to letter realted to COI.(LETTER FOOTER)
                        # region " Letter Footer "

                        // adding signature
                        //COI_Signature objSignature = new COI_Signature(objCOI.FK_COI_Signature);
                        COI_Signature objSignature = new COI_Signature(Convert.ToDecimal(drpSignature.SelectedValue));
                        LetterFooter.Append(GetBlankRow(RowSpacing));
                        //LetterFooter.Append(GetContentRow(objSignature.Closing));
                        //LetterFooter.Append(GetBlankRow(RowSpacing));
                        LetterFooter.Append(GetContentRow("Sincerely,"));
                        LetterFooter.Append(GetBlankRow(RowSpacing));
                        LetterFooter.Append(GetContentRow(objSignature.Fld_Desc));
                        // LetterFooter.Append(GetContentRow(objSignature.Title_Department));
                        //LetterFooter.Append(GetContentRow("Phone: " + objSignature.Phone + " Facsimile: " + objSignature.Facsimile));
                        //LetterFooter.Append(GetContentRow("E-Mail: " + objSignature.EMail));
                        LetterFooter.Append(GetBlankRow(RowSpacing));
                        LetterFooter.Append(GetBlankRow(RowSpacing));

                        // all the copies should be added at end of letter.
                        DataTable dtCopies = COI_Copies.SelectByFK_COIs(PK_COI).Tables[0];
                        dtCopies.DefaultView.Sort = "Contact_Last_Name,Contact_First_Name,Name";
                        dtCopies = dtCopies.DefaultView.ToTable();
                        int CountCopy = dtCopies.Rows.Count;
                        EnvelopesCC.Length = 0;
                        if (CountCopy > 0)
                        {
                            LetterFooter.Append(GetContentRow("cc: "));
                            for (int c = 0; c < CountCopy; c++)
                            {
                                string strCC = string.Empty;
                                string strCCLname = Convert.ToString(dtCopies.Rows[c]["Contact_Last_Name"]);
                                string strCCFName = Convert.ToString(dtCopies.Rows[c]["Contact_First_Name"]);
                                string strContactTitle = Convert.ToString(dtCopies.Rows[c]["Contact_Title"]);
                                string strCCCompany = Convert.ToString(dtCopies.Rows[c]["Name"]);
                                string strCCAddress1 = Convert.ToString(dtCopies.Rows[c]["Address_1"]);
                                string strCCAddress2 = Convert.ToString(dtCopies.Rows[c]["Address_2"]);
                                string strCCCity = Convert.ToString(dtCopies.Rows[c]["City"]);
                                string strCCState = Convert.ToString(dtCopies.Rows[c]["FK_State"]);

                                decimal FK_State = strCCState != string.Empty ? Convert.ToDecimal(strCCState) : -1;
                                strCCState = strCCState != string.Empty ? new State(FK_State).FLD_state : string.Empty;
                                string strCCZip = Convert.ToString(dtCopies.Rows[c]["Zip_Code"]);

                                strCC = strCCFName;
                                if (strCCLname != string.Empty)
                                    strCC = strCC != string.Empty ? strCC + " " + strCCLname : strCCLname;
                                if (strContactTitle != string.Empty)
                                    strCC = strCC != string.Empty ? strCC + ", " + strContactTitle : strContactTitle;
                                if (strCCCompany != string.Empty)
                                    strCC = strCC != string.Empty ? strCC + ", " + strCCCompany : strCCCompany;
                                //if (strCCAddress1 != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + " - " + strCCAddress1 : strCCAddress1;
                                //if (strCCAddress2 != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + ", " + strCCAddress2 : strCCAddress2;
                                //if (strCCCity != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + ", " + strCCCity : strCCCity;
                                //if (strCCState != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + ", " + strCCState : strCCState;
                                //if (strCCZip != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + " " + strCCZip : strCCZip;

                                LetterFooter.Append(GetContentRow(strCC));

                                // generate contentes for each Envelope Copies if Generate Envelop is set 
                                if (Convert.ToString(dtCopies.Rows[c]["Envelope"]) == "Y")
                                {
                                    EnvelopesCC.Append(GetEnvelopeContents(strCCFName, strCCLname, strCCCompany, strCCAddress1, strCCAddress2, strCCCity, FK_State, strCCZip));
                                    if (c < CountCopy - 1)
                                        EnvelopesCC.Append(strPrintPageBreak);
                                }
                            }
                        }

                        LetterFooter.Append("</table>");
                        // end of letter for current coi    

                        if (i == COICount - 1)
                        {
                            LetterFooter.Append("</body></html>");
                        }

                        strCurrentLetterText = LetterHeader.ToString() + Letter.ToString() + LetterFooter.ToString();

                        //// create copy of the same letter for each copies
                        string strLetterText = strCurrentLetterText;
                        for (int c = 0; c < CountCopy; c++)
                        {
                            strLetterText = strLetterText + strPrintPageBreak + strCurrentLetterText;
                        }
                        strCurrentLetterText = strLetterText;

                        #endregion

                        # region " Generate Envelopes "

                        Envelopes.Length = 0;

                        // Get envelope contents
                        Envelopes.Append(GetEnvelopeContents(objInsured.Contact_First_Name, objInsured.Contact_Last_Name, objInsured.Insured_Name, objInsured.Address_1, objInsured.Address_2, objInsured.City, objInsured.FK_State, objInsured.Zip_Code));
                        // print for each CC along with the addressee
                        if (EnvelopesCC.Length > 0)
                            Envelopes.Append(strPrintPageBreak + EnvelopesCC);

                        # endregion


                        if (litEnvelopes.Text.Length > 0)
                            litEnvelopes.Text = string.Concat(litEnvelopes.Text, strPrintPageBreak, Envelopes.ToString());
                        else
                            litEnvelopes.Text = string.Concat(litEnvelopes.Text, Envelopes.ToString());

                        
                        // add the letter text to print
                        if (litLetter.Text.Length > 0)
                             litLetter.Text = string.Concat(litLetter.Text, strPrintPageBreak, strCurrentLetterText);                            
                        else
                            litLetter.Text = string.Concat(litLetter.Text, strCurrentLetterText);
                        
                    }
                    #endregion
                }
                else
                {

                    DataTable dtPropNonCompliance = clsGenerateLetter.GetPropertyPolicy_NonComplianceDeficiency(PK_COI).Tables[0];

                    # region " Coverage Details Generation "

                    // generate string for letter as per format given
                    //Letter.Append(GetContentRow("<b>Coverage Status</b>"));

                    // count the no of policies to loop through it.
                    // right now there are 6 policies
                    int PolicyCount = arrPolicyTables.Length;
                    for (int k = 0; k < PolicyCount; k++)
                    {
                        // get rows for Required Policies
                        drRequiredPolicy = dtRequiredPoliciesCOIs.Select("Policy_Type = '" + arrPolicyTables[k] + "' AND PK_COIs = " + PK_COI.ToString() + " AND FK_COI_Signature = " + strSignature);

                        // get rows for 2A condition
                        dr2A = dt2A.Select("Policy_Type = '" + arrPolicyTables[k] + "' AND PK_COIs = " + PK_COI.ToString() + " AND FK_COI_Signature = " + strSignature);

                        // get rows for 2B condition
                        dr2B = dt2B.Select("Policy_Type = '" + arrPolicyTables[k] + "' AND PK_COIs = " + PK_COI.ToString() + " AND FK_COI_Signature = " + strSignature);

                        // set varaibles to find weather any coverage defficiency(cancelled,expired or indaequate) found or not.
                        Count2A = dr2A.Length;
                        Count2B = dr2B.Length;
                        CountRequiredPolicy = drRequiredPolicy.Length;

                        if (Count2A > 0 || Count2B > 0 || CountRequiredPolicy > 0)
                        {
                            //Letter.Append(GetBlankRow(RowSpacing));
                            Letter.Append(GetContentRow("<I>" + GetPolicyNameByTableName(arrPolicyTables[k]) + "</I>"));
                            Letter.Append(GetBlankRow(RowSpacing));

                            // as atleast one record found then letter should be generated.
                            if (GenerateLetter == false)
                                GenerateLetter = true;

                            //check for Required Policy not found.
                            for (int j = 0; j < CountRequiredPolicy; j++)
                            {
                                // write down each row for current policy.                                
                                Letter.Append(GetContentRow("At least one " + GetPolicyNameByTableName(arrPolicyTables[k]) + " Policy is required and none are included on the COI."));
                            }

                            //check for step 2A                                        
                            for (int j = 0; j < Count2A; j++)
                            {
                                // if status = 3(Expired) then state the expired date along with policy type and policy number
                                // else same for cancelled policy
                                if (Convert.ToString(dr2A[j]["Status"]) == "3")
                                {
                                    // write down each row for current policy along with policy number.
                                    Letter.Append(GetContentRow(" Policy Number " + dr2A[j]["Policy_Number"] + " EXPIRED on " + Convert.ToDateTime(dr2A[j]["dtStatus"]).ToString(AppConfig.DisplayDateFormat) + "."));
                                }
                                else
                                {
                                    Letter.Append(GetContentRow(" Policy Number " + dr2A[j]["Policy_Number"] + " was CANCELLED on " + Convert.ToDateTime(dr2A[j]["dtStatus"]).ToString(AppConfig.DisplayDateFormat) + "."));
                                }
                            }


                            //check for step 2B                                     
                            for (int j = 0; j < Count2B; j++)
                            {
                                // write down each row for current policy alogn with policy number , inadequate value and minimum value and coverage name to be testted.
                                Letter.Append(GetContentRow(" Policy Number " + dr2B[j]["Policy_Number"] + " " + GetCoverageNameByFieldName(dr2B[j]["Coverage_Name"].ToString()) + " reported is $" + dr2B[j]["Inadequate_Coverage"] + " and must be at least $" + dr2B[j]["Minimum_Coverage"]));
                            }

                            if ((arrPolicyTables[k]) == "COI_Property_Policies")
                            {
                                foreach (DataRow drProp in dtPropNonCompliance.Rows)
                                {
                                    if (Convert.ToString(drProp["Boiler"]) == "Yes")
                                        Letter.Append(GetContentRow(" Policy Number " + drProp["Policy_Number"] + " " + "Boiler and Machinery coverage is not included"));
                                    if (Convert.ToString(drProp["Earthquake"]) == "Yes")
                                        Letter.Append(GetContentRow(" Policy Number " + drProp["Policy_Number"] + " " + "Earthquake coverage is not included"));
                                    if (Convert.ToString(drProp["Flood"]) == "Yes")
                                        Letter.Append(GetContentRow(" Policy Number " + drProp["Policy_Number"] + " " + "Flood coverage is not included"));
                                }
                            }

                            Letter.Append(GetBlankRow(RowSpacing));
                        }

                    }

                    #endregion

                    # region Compliance check
                    //Check if any of the compliance is turned off. 
                    //If turned off then display on letter
                    DataTable dtComp = COIs.Select(PK_COI).Tables[0];
                    if (dtComp.Rows.Count > 0)
                    {
                        DataRow dr = dtComp.Rows[0];
                        StringBuilder ComplianceCheck = new StringBuilder();

                        if (dr["Compliance_01"].ToString() == "N" && new COI_Compliance_Text(1).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(1).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }
                        if (dr["Compliance_02"].ToString() == "N" && new COI_Compliance_Text(2).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(2).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }
                        if (dr["Compliance_03"].ToString() == "N" && new COI_Compliance_Text(3).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(3).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }
                        if (dr["Compliance_04"].ToString() == "N" && new COI_Compliance_Text(4).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(4).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }
                        if (dr["Compliance_05"].ToString() == "N" && new COI_Compliance_Text(5).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(5).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }
                        if (dr["Compliance_06"].ToString() == "N" && new COI_Compliance_Text(6).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(6).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }
                        if (dr["Compliance_07"].ToString() == "N" && new COI_Compliance_Text(7).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(7).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }
                        if (dr["Compliance_08"].ToString() == "N" && new COI_Compliance_Text(8).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(8).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }
                        if (dr["Compliance_09"].ToString() == "N" && new COI_Compliance_Text(9).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(9).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }
                        if (dr["Compliance_10"].ToString() == "N" && new COI_Compliance_Text(10).IsTurnedOn == "Y")
                        {
                            ComplianceCheck.Append(GetContentRow("The compliance condition " + COI_Compliance_Text.SelectByPK(10).Tables[0].Rows[0]["Compliance_Text"].ToString() + " is not met by the existing COI."));
                        }

                        if (ComplianceCheck.Length > 0)
                        {
                            // if any record found set the header of this section.
                            Letter.Append(GetBlankRow(RowSpacing));
                            Letter.Append(GetContentRow("<table>" + ComplianceCheck.ToString() + "</table>"));
                        }
                    }
                    # endregion

                    # region " Non Compliance Details Generation "

                    // check for step 2c
                    // there must be a single record for each COI.
                    // either it satisfy all conditions for non compliancy or it may not satisfy any one or more.
                    DataTable dtNonCompliance = clsGenerateLetter.GetNonComplianceDeficiency(PK_COI).Tables[0];

                    if (dtNonCompliance.Rows.Count > 0)
                    {
                        DataRow dr = dtNonCompliance.Rows[0];
                        StringBuilder NonComplianceDetails = new StringBuilder("<table width='100%'>");

                        if (dr["Cancellation_Notice"].ToString() == "N" || dr["Primary_Provided"].ToString() == "N" ||
                             dr["Signed_Certificate_Received"].ToString() == "N" || dr["Insured_Name_Same"].ToString() == "N" ||
                             dr["AM_Best"].ToString() == "N" || dr["Ordinance_Law"].ToString() == "N" || dr["Subrogation_Waiver"].ToString() == "N")
                        {
                            NonComplianceDetails.Append(GetContentRow("<b>Noncompliance/Deficiencies</b>"));
                            NonComplianceDetails.Append(GetBlankRow(RowSpacing));
                        }
                        
                        //cehck for different non compliace fields and set message according to field
                        if (dr["Cancellation_Notice"].ToString() == "N")
                        { NonComplianceDetails.Append(GetContentRow("Cancellation Notice Under 30 Days")); }

                        if (dr["Primary_Provided"].ToString() == "N")
                        { NonComplianceDetails.Append(GetContentRow("Insurance is Primary and Non-Contributory with Other Insurance – Wording Not Provided")); }

                        //if (dr["All_Locations"].ToString() == "N")
                        //{ NonComplianceDetails.Append(GetContentRow("All Locations not on Certificate")); }

                        if (dr["Signed_Certificate_Received"].ToString() == "N")
                        { NonComplianceDetails.Append(GetContentRow("Original or Signed Certificate not Provided")); }

                        if (dr["Insured_Name_Same"].ToString() == "N")
                        { NonComplianceDetails.Append(GetContentRow("Insured Name on Policies and Certificates not same as Franchise Entity Business Name")); }

                        if (dr["AM_Best"].ToString() == "N")
                        { NonComplianceDetails.Append(GetContentRow("AM Best Rating Missing")); }

                        if (dr["Ordinance_Law"].ToString() == "N")
                        { NonComplianceDetails.Append(GetContentRow("Ordinance or Law not provided")); }

                        if (dr["Subrogation_Waiver"].ToString() == "N")
                        { NonComplianceDetails.Append(GetContentRow("Waiver of Subrogation not provided")); }

                        //if (dr["Perils_Insured_Form"].ToString() == "N")
                        //{ NonComplianceDetails.Append(GetContentRow("Insured Perils – Special Form not provided")); }

                        //if (dr["Replacement_Costs"].ToString() == "N")
                        //{ NonComplianceDetails.Append(GetContentRow("100% Replacement Cost Values not provided")); }

                        //if (dr["Property_On_Acord"].ToString() == "N")
                        //{ NonComplianceDetails.Append(GetContentRow("Evidence of Property on Acord 24, 27 or 28 not provided")); }

                        //if (dr["B_I_Included_In_Verification"].ToString() == "N")
                        //{ NonComplianceDetails.Append(GetContentRow("Business Interruption not Included in Property Verification")); }

                        if (NonComplianceDetails.Length > 0)
                        {
                            // if atleast one field found with has defficiency , letter should be generated.
                            if (GenerateLetter == false)
                                GenerateLetter = true;

                            // if any record found set the header of this section.
                            Letter.Append(GetBlankRow(RowSpacing));
                            NonComplianceDetails.Append("</table>");
                            //Letter.Append(GetContentRow("<b>Noncompliance/Deficiencies</b>"));
                            //Letter.Append(GetBlankRow(RowSpacing));
                            Letter.Append(GetContentRow(NonComplianceDetails.ToString()));
                        }
                    }

                    //get Additional insured non compliance detail for perticular COI
                    DataTable dtAI = clsGenerateLetter.GetAdditionalInsuredNonCompliance(PK_COI).Tables[0];

                    foreach (DataRow drAI in dtAI.Rows)
                    {
                        Letter.Append(GetContentRow("The Additional Insured, " + drAI["First_Name"].ToString() + " " + drAI["Last_Name"].ToString() + ", is not included on the COI and must be shown on the COI."));
                    }

                    #endregion


                    if (GenerateLetter)
                    {
                        # region " get the Text to be Added for Letter "
                        // add record to letter history page.
                        string strLevelText = "";
                        switch (intLevel)
                        {
                            case 1:
                                strLevelText = objCOI.LeveL_1_Text;
                                break;
                            case 2:
                                strLevelText = objCOI.LeveL_2_Text;
                                break;
                            case 3:
                                strLevelText = objCOI.LeveL_3_Text;
                                break;
                            case 4:
                                strLevelText = objCOI.LeveL_4_Text;
                                break;
                        }

                        #endregion

                        // append details to letter realted to COI.(LETTER HEADER)
                        # region " Letter Header "

                        // starting letter body
                        LetterHeader.Append("<html><head><style>.break { page-break-before: always; }</style></head><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">");

                        // company logo and return adddress
                        LetterHeader.Append(GetContentRow("<table><tr><td><img src='" + AppConfig.SiteURL + "CompanyLogo.jpg'/></td><td>&nbsp;</td><td style=\"vertical-align:top\">" + ReturnAddress.ToString() + "</td></tr></table>"));
                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetContentRow(DateTime.Today.ToString(AppConfig.DisplayDateFormat)));
                        LetterHeader.Append(GetBlankRow(RowSpacing));

                        COI_Insureds objInsured = new COI_Insureds(objCOI.FK_COI_Insureds);
                        // LetterHeader.Append(GetContentRow(objInsured.Contact_First_Name + " " + objInsured.Contact_Last_Name));
                        LetterHeader.Append(GetContentRow(objInsured.Insured_Name));
                        LetterHeader.Append(GetContentRow(objInsured.Address_1));
                        if (!string.IsNullOrEmpty(objInsured.Address_2))
                            LetterHeader.Append(GetContentRow(objInsured.Address_2));
                        //COI_State objstate = new COI_State(objInsured.FK_State);
                        LetterHeader.Append(GetContentRow(objInsured.City + ", " + objInsured.Fld_State + " " + objInsured.Zip_Code));

                        LetterHeader.Append(GetBlankRow(RowSpacing));
                        LetterHeader.Append(GetContentRow("Dear" + " " + objInsured.Insured_Name));
                        LetterHeader.Append(GetBlankRow(RowSpacing));

                        if (!string.IsNullOrEmpty(strLevelText))
                        {
                            LetterHeader.Append(GetContentRow(strLevelText));
                        }
                        else
                        {
                            LetterHeader.Append(GetContentRow("The Certificate of Insurance that you have provided contains the following deficiencies that need to be corrected within the next 30 days:"));
                        }                        
                        LetterHeader.Append(GetBlankRow(RowSpacing));

                        // gnerating letter for deficiency
                        if (!string.IsNullOrEmpty(Letter.ToString()))
                        {
                            LetterHeader.Append(GetContentRow("<b> Coverage Status</b>"));
                            LetterHeader.Append(GetBlankRow(RowSpacing));
                        }
                        //// gnerating letter for deficiency
                        //if (Letter.Length > 0)
                        //{
                        //    LetterHeader.Append(GetContentRow("<b>Noncompliance/Deficiencies</b>"));
                        //    LetterHeader.Append(GetBlankRow(RowSpacing));
                        //}
                        #endregion

                        // append details to letter realted to COI.(LETTER FOOTER)
                        # region " Letter Footer "

                        //if (strLevelText.Length > 0)
                        //{
                        //    LetterFooter.Append(GetBlankRow(RowSpacing));
                        //    LetterFooter.Append(GetContentRow(strLevelText));
                        //}
                        LetterFooter.Append(GetBlankRow(RowSpacing));
                        // adding signature
                        COI_Signature objSignature = new COI_Signature(Convert.ToDecimal(drpSignature.SelectedValue));
                        LetterFooter.Append(GetBlankRow(RowSpacing));
                        LetterFooter.Append(GetContentRow(objSignature.Closing));
                        LetterFooter.Append(GetBlankRow(RowSpacing));
                        LetterFooter.Append(GetContentRow("Sincerely,"));
                        LetterFooter.Append(GetBlankRow(RowSpacing));
                        LetterFooter.Append(GetContentRow(objSignature.Fld_Desc));
                        //LetterFooter.Append(GetContentRow(objSignature.Title_Department));
                        //LetterFooter.Append(GetContentRow("Phone: " + objSignature.Phone + " Facsimile: " + objSignature.Facsimile));
                        //LetterFooter.Append(GetContentRow("E-Mail: " + objSignature.EMail));
                        //LetterFooter.Append(GetBlankRow(RowSpacing));
                        LetterFooter.Append(GetBlankRow(RowSpacing));

                        // all the copies should be added at end of letter.
                        DataTable dtCopies = COI_Copies.SelectByFK_COIs(PK_COI).Tables[0];
                        dtCopies.DefaultView.Sort = "Contact_Last_Name,Contact_First_Name,Name";
                        dtCopies = dtCopies.DefaultView.ToTable();
                        int CountCopy = dtCopies.Rows.Count;
                        EnvelopesCC.Length = 0;
                        if (CountCopy > 0)
                        {
                            LetterFooter.Append(GetContentRow("cc: "));
                            for (int c = 0; c < CountCopy; c++)
                            {
                                string strCC = string.Empty;
                                string strCCLname = Convert.ToString(dtCopies.Rows[c]["Contact_Last_Name"]);
                                string strCCFName = Convert.ToString(dtCopies.Rows[c]["Contact_First_Name"]);
                                string strContactTitle = Convert.ToString(dtCopies.Rows[c]["Contact_Title"]);
                                string strCCCompany = Convert.ToString(dtCopies.Rows[c]["Name"]);
                                string strCCAddress1 = Convert.ToString(dtCopies.Rows[c]["Address_1"]);
                                string strCCAddress2 = Convert.ToString(dtCopies.Rows[c]["Address_2"]);
                                string strCCCity = Convert.ToString(dtCopies.Rows[c]["City"]);
                                string strCCState = Convert.ToString(dtCopies.Rows[c]["FK_State"]);

                                decimal FK_State = strCCState != string.Empty ? Convert.ToDecimal(strCCState) : -1;
                                strCCState = strCCState != string.Empty ? new State(FK_State).FLD_state : string.Empty;
                                string strCCZip = Convert.ToString(dtCopies.Rows[c]["Zip_Code"]);

                                strCC = strCCFName;
                                if (strCCLname != string.Empty)
                                    strCC = strCC != string.Empty ? strCC + " " + strCCLname : strCCLname;
                                if (strContactTitle != string.Empty)
                                    strCC = strCC != string.Empty ? strCC + ", " + strContactTitle : strContactTitle;
                                if (strCCCompany != string.Empty)
                                    strCC = strCC != string.Empty ? strCC + ", " + strCCCompany : strCCCompany;
                                //if (strCCAddress1 != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + " - " + strCCAddress1 : strCCAddress1;
                                //if (strCCAddress2 != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + ", " + strCCAddress2 : strCCAddress2;
                                //if (strCCCity != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + ", " + strCCCity : strCCCity;
                                //if (strCCState != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + ", " + strCCState : strCCState;
                                //if (strCCZip != string.Empty)
                                //    strCC = strCC != string.Empty ? strCC + " " + strCCZip : strCCZip;

                                LetterFooter.Append(GetContentRow(strCC));

                                // generate contentes for each Envelope Copies if Generate Envelop is set 
                                if (Convert.ToString(dtCopies.Rows[c]["Envelope"]) == "Y")
                                {
                                    EnvelopesCC.Append(GetEnvelopeContents(strCCFName, strCCLname, strCCCompany, strCCAddress1, strCCAddress2, strCCCity, FK_State, strCCZip));
                                    if (c < CountCopy - 1)
                                        EnvelopesCC.Append(strPrintPageBreak);
                                }
                            }
                        }

                        // end of letter for current coi                            
                        LetterFooter.Append("</br></html>");
                        strCurrentLetterText = LetterHeader.ToString() + Letter.ToString() + LetterFooter.ToString();

                        //// create copy of the same letter for each copies
                        string strLetterText = strCurrentLetterText;
                        for (int c = 0; c < CountCopy; c++)
                        {
                            strLetterText = strLetterText + strPrintPageBreak + strCurrentLetterText;
                        }
                        strCurrentLetterText = strLetterText;

                        #endregion

                        # region " Generate Envelopes "

                        Envelopes.Length = 0;

                        // Get envelope contents
                        Envelopes.Append(GetEnvelopeContents(objInsured.Contact_First_Name, objInsured.Contact_Last_Name, objInsured.Insured_Name, objInsured.Address_1, objInsured.Address_2, objInsured.City, objInsured.FK_State, objInsured.Zip_Code));
                        // print for each CC along with the addressee
                        if (EnvelopesCC.Length > 0)
                            Envelopes.Append(strPrintPageBreak + EnvelopesCC);

                        # endregion


                        if (litEnvelopes.Text.Length > 0)
                            litEnvelopes.Text = string.Concat(litEnvelopes.Text, strPrintPageBreak, Envelopes.ToString());
                        else
                            litEnvelopes.Text = string.Concat(litEnvelopes.Text, Envelopes.ToString());

                        // add the letter text to print
                        if (litLetter.Text.Length > 0)
                            litLetter.Text = string.Concat(litLetter.Text, strPrintPageBreak, strCurrentLetterText);
                        else
                            litLetter.Text = string.Concat(litLetter.Text, strCurrentLetterText);

                        // add record in letter history for future reference.
                        AddCoverageStatusToLetterHistory(dt2A, dt2B, dtNonCompliance, PK_COI, intLevel, strLevelText, strCurrentLetterText, Envelopes.ToString());

                    }

                }

            }
            if (litLetter.Text.Length > 0)
            {
                dvLinks.Style["Display"] = "block";
                dvSignature.Style["Display"] = "none";
                lblMessage.Text = " Letters Generated Successfully. You can Print Letters and/or Envelopes using below Links. ";

                // if atleast one letter is generated, print it.
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "PrintLetterDoc", "javascript:PrintLetter();", true);
            }
            else
            {
                dvLinks.Style["Display"] = "block";
                dvSignature.Style["Display"] = "none";
                lblMessage.Text = " No Letters Generated.";
                lnkPrintEnvelopes.Visible = false;
                lnkPrintLetters.Visible = false;
            }
        }
        else
        {
            dvLinks.Style["Display"] = "block";
            dvSignature.Style["Display"] = "none";
            lblMessage.Text = " No Letters Generated.";
            lnkPrintEnvelopes.Visible = false;
            lnkPrintLetters.Visible = false;
        }
    }


    #endregion
}
