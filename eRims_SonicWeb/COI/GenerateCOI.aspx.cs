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
using System.Text;
using ERIMS.DAL;
using Aspose.Words;
using Aspose.Words.Drawing;
using System.IO;
public partial class COI_GenerateCOI : clsBasePage
{

    #region "Variables"
    private const string strPrintPageBreak = "<!-PAGE BREAK>";
    string[,] STR_INSURANCE_COMPANIES = new string[1, 2];
    int INT_LOCATION_PRINTED = 0;
    DataTable DT_POLICY_INFO = null;
    #endregion

    #region "Page Load"
    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                // check for the session 
                if (clsGeneral.IsNull(Session["COIsToGeneratePDF"]))
                    Response.Redirect("COISearch.aspx?a=1");
                else
                {
                    // get array for the PK_COIs
                    string PK_COIs = Session["COIsToGeneratePDF"].ToString();
                    string[] strCOIs = PK_COIs.Split(',');

                    // loop through all COIs to generate PDF
                    foreach (string COI in strCOIs)
                    {
                        INT_LOCATION_PRINTED = 0;
                        // generate a blank datatable template having policy information
                        GeneratePolicyInfoDataTable();

                        decimal FK_COI = Convert.ToDecimal(COI);

                        #region CERTIFICATE OF INSURANCE
                        // get Locations for perticular COI
                        DataTable dtLocations = COI_Locations.SelectByFK_COIs(FK_COI).Tables[0];
                        if (dtLocations.Rows.Count > 1)
                        {
                            // loop through all location rows in datatable
                            foreach (DataRow drLocation in dtLocations.Rows)
                            {
                                // generate PDF having a location
                                GenerateCOIPDF(FK_COI, Convert.ToDecimal(drLocation[0]));

                                // increment counter for printing location
                                INT_LOCATION_PRINTED++;
                            }
                        }
                        else
                        {
                            // generate PDF having no location info but other info
                            GenerateCOIPDF(FK_COI, 0);
                        }
                        #endregion

                        #region EVIDENCE OF PROPERTY

                        // get the property data for a COI
                        DataTable dtProperty = COI_Property_Policies.SelectByFK_COIs(FK_COI).Tables[0];
                        if (dtProperty.Rows.Count > 0)
                        {
                            // loop through each property record 
                            foreach (DataRow drProperty in dtProperty.Rows)
                            {
                                decimal PK_COI_Property = Convert.ToDecimal(drProperty[0]);
                                COI_Property_Policies objProperty = new COI_Property_Policies(PK_COI_Property);

                                // get the location records for a Property
                                DataTable dtLocationsEvi = COI_Locations.SelectByFK_COI_Property_Policies(PK_COI_Property).Tables[0];

                                int intPolicyRowIndex = 0; // counter for the policy row

                                // loop through each location row
                                foreach (DataRow drLocationEvi in dtLocationsEvi.Rows)
                                {
                                    // get policy info row
                                    DataRow drPolicy = DT_POLICY_INFO.Rows[intPolicyRowIndex];

                                    if (drPolicy != null)
                                    {
                                        // print location info and policy info on PDF
                                        GeneratePropertyEvidencePDF(FK_COI, Convert.ToDecimal(drLocationEvi[0]), objProperty.Insurance_Company, drPolicy);

                                        // increment the policy row index
                                        intPolicyRowIndex++;
                                    }
                                    else
                                    {
                                        // generate the blank policy info row
                                        DataRow dr = DT_POLICY_INFO.NewRow();
                                        foreach (DataColumn dc in DT_POLICY_INFO.Columns)
                                        {
                                            dr[dc] = "";
                                        }

                                        // print location info and blank policy info on PDF
                                        GeneratePropertyEvidencePDF(FK_COI, Convert.ToDecimal(drLocationEvi[0]), objProperty.Insurance_Company, dr);
                                    }
                                }

                                // if still there is policy info add it on PDf
                                for (int i = intPolicyRowIndex; i < DT_POLICY_INFO.Rows.Count; i++)
                                {
                                    GeneratePropertyEvidencePDF(FK_COI, 0, objProperty.Insurance_Company, DT_POLICY_INFO.Rows[i]);
                                }
                            }
                        }
                        #endregion
                    }
                    lblMessage.Text = " Certificate Of Insurance Generated Successfully. You can Print using below link. ";
                }
             }
        }
    }
    #endregion

    /// <summary>
    /// Function Policy Info 
    /// </summary>
    private void GeneratePolicyInfoDataTable()
    {
        DT_POLICY_INFO = new DataTable();
        DataColumn dcFK = new DataColumn("PK_Policy", typeof(string));
        DataColumn dcPolicyType = new DataColumn("Policy_type", typeof(string));
        DataColumn dcComp = new DataColumn("Insurance_Company", typeof(string));
        DataColumn dcPolicyNum = new DataColumn("Policy_Number", typeof(string));
        DataColumn dcExpirationDate = new DataColumn("Expiration_Date", typeof(string));
        DataColumn dcEffectiveDate = new DataColumn("Effective_Date", typeof(string));


        DT_POLICY_INFO.Columns.Add(dcFK);
        DT_POLICY_INFO.Columns.Add(dcPolicyType);
        DT_POLICY_INFO.Columns.Add(dcComp);
        DT_POLICY_INFO.Columns.Add(dcPolicyNum);
        DT_POLICY_INFO.Columns.Add(dcExpirationDate);
        DT_POLICY_INFO.Columns.Add(dcEffectiveDate);

    }
    /// <summary>
    /// Handle Print Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPrint_Click(object sender, EventArgs e)
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
        builder.Font.Size = 12;
        builder.Font.Bold = false;
        builder.Font.Color = System.Drawing.Color.Black;
        builder.Font.Name = "Times New Roman";
        builder.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;
        builder.InsertParagraph();
        builder.InsertHtml(ltrPrintCOI.Text);
        //builder.Write(litLetter.Text);
        //doc.MailMerge.Execute(dt);
        //Don't need merge fields in the document anymore.
        doc.MailMerge.DeleteFields();

        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;
        //doc.Save("CertificateOfInsurance.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        doc.Save(Response, "CertificateOfInsurance.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));

        Response.End();
    }

    #region "---------------- CERTIFICATE OF INSURANCE ----------------------------"

    private void GenerateCOIPDF(decimal FK_COI, decimal PK_Location)
    {
        StringBuilder sbDate = new StringBuilder();
        sbDate.Append(TABLE("100%", "0", "0", ""));
        sbDate.Append(TD("100%", "center", "valign=top", "DATE", COIContentType.SectionHeader) + "</tr>");
        sbDate.Append(TR("100%", "center", "", clsGeneral.FormatDBNullDateToDisplay(new COIs(FK_COI).Issue_Date), COIContentType.Data));
        sbDate.Append(ENDTABLE().Replace("</tr>", ""));

        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("85%", "center", "valign='middle'", SetPageHeader(), COIContentType.None));
        sb.Append(TD("15%", "center", "valign=top", sbDate.ToString(), COIContentType.None));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("55%", "left", "", SetProducerDetails(FK_COI) + "<br>" + SetInsuredDetails(FK_COI), COIContentType.None));
        sb.Append(TD("45%", "left", "", SetInsuranceCompanyDetails(FK_COI), COIContentType.None));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", ""));
        sb.Append(TD("100%", "left", "", "COVERAGES", COIContentType.InformationContent));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("100%", "center", "", SetCoveragesHeaderInfo(), COIContentType.None));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "2", "BgColor='black'"));
        sb.Append(TD("5%", "center", "BgColor='white'", "CO<br>LTR", COIContentType.SectionHeader));
        sb.Append(TD("22%", "center", "BgColor='white'", "TYPE OF INSURANCE", COIContentType.SectionHeader));
        sb.Append(TD("17%", "center", "BgColor='white'", "POLICY NUMBER", COIContentType.SectionHeader));
        sb.Append(TD("12%", "center", "BgColor='white'", "POLICY EFFECTIVE<BR>DATE(MM/DD/YY)", COIContentType.SectionHeader));
        sb.Append(TD("12%", "center", "BgColor='white'", "POLICY EXPIRATION<BR>DATE(MM/DD/YY)", COIContentType.SectionHeader));
        sb.Append(TD("20%", "center", "BgColor='white'", "COVERED PROPERTY", COIContentType.SectionHeader));
        sb.Append(TD("12%", "center", "BgColor='white'", "LIMITS", COIContentType.SectionHeader) + "</tr>");
        if (INT_LOCATION_PRINTED == 0)
        {
            sb.Append(GetGeneralPolicyDetails(FK_COI));
            sb.Append(GetAutomobilePolicyDetails(FK_COI));
            sb.Append(GetExcessPolicyDetails(FK_COI));
            sb.Append(GetWCPolicyDetails(FK_COI));
        }
        else
        {
            sb.Append(GetBlankPolicyDetails("GENERAL LIABILITY"));
            sb.Append(GetBlankPolicyDetails("AUTOMOBILE LIABILITY"));
            sb.Append(GetBlankPolicyDetails("EXCESS LIABILITY"));
            sb.Append(GetBlankPolicyDetails("WC LIABILITY"));
        }
        sb.Append(GetBlankPolicyDetails("OTHER"));
        sb.Append(ENDTABLE().Replace("</tr>", ""));

        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("100%", "center", "", SetLocationInfo(PK_Location), COIContentType.None));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("100%", "left", "valign='top' height='40'", "SPECIAL CONDITIONS/OTHER COVERAGES", COIContentType.SectionHeader));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", ""));
        sb.Append(TD("50%", "left", "", "CERTIFICATE HOLDER", COIContentType.InformationContent));
        sb.Append(TD("50%", "left", "", "CANCELLATION", COIContentType.InformationContent));
        sb.Append(ENDTABLE());

        sb.Append(Set_CertiHolder_And_Cancellation_DTL(FK_COI));

        if (ltrPrintCOI.Text.Length > 0)
            ltrPrintCOI.Text += strPrintPageBreak + sb.ToString();
        else
            ltrPrintCOI.Text = sb.ToString();

        //ltrPrintCOI.Visible = true;
    }

    #region "PAGE HEADER"
    private string SetPageHeader()
    {
        StringBuilder sbHeader = new StringBuilder();
        sbHeader.Append(TABLE("100%", "0", "0", "height='5'"));
        sbHeader.Append(TD("15%", "center", "", "<u><I>ACORD</I></u>", COIContentType.PageHeader));
        sbHeader.Append(TD("85%", "center", "", "CERTIFICATE OF PROPERTY INSURANCE", COIContentType.PageHeader));
        sbHeader.Append(ENDTABLE());
        return sbHeader.ToString();
    }
    #endregion

    #region "PRODUCER"
    private string SetProducerDetails(decimal FK_COI)
    {
        StringBuilder sbContent = new StringBuilder();
        DataTable dtProducer = COI_Producers.SelectByFK_COIs(FK_COI).Tables[0];
        if (dtProducer.Rows.Count > 0)
        {
            COI_Producers objProducer = new COI_Producers(Convert.ToDecimal(dtProducer.Rows[0][0]));
            string strName = clsGeneral.FormatName(objProducer.Contact_First_Name, objProducer.Contact_Last_Name);
            string strAddress = clsGeneral.FormatAddress(objProducer.Address_1, objProducer.Address_2, objProducer.City, new COI_State(objProducer.FK_State).FLD_abbreviation, objProducer.Zip_Code);
            string strContent = objProducer.Contact_Title + "<br>" + strName + "<br>" + strAddress + "<br>Ph.#: " + objProducer.Contact_Phone;

            sbContent.Append(TABLE("80%", "0", "0", "align='center'"));
            sbContent.Append(TD("100%", "Left", "height='40'", strContent, COIContentType.Data));
            sbContent.Append(ENDTABLE());
        }

        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("100%", "0", "0", "").Replace("<tr>", ""));
        sb.Append(TR("100%", "left", "valign='top'", "PRODUCER", COIContentType.SectionHeader));
        sb.Append(TR("100%", "left", "", sbContent.ToString(), COIContentType.None));
        sb.Append(ENDTABLE().Replace("</tr>", ""));
        return sb.ToString();
    }
    #endregion

    #region "INSURANCE COMPANIES"
    private string SetInsuranceCompanyDetails(decimal FK_COI)
    {

        StringBuilder sbContent = new StringBuilder();
        DataTable dtCompany = COI_Insurance_Companies.SelectByFK_COIs(FK_COI).Tables[0];
        if (dtCompany.Rows.Count > 0)
        {
            STR_INSURANCE_COMPANIES = new string[dtCompany.Rows.Count, 2];
            sbContent.Append(TABLE("100%", "0", "0", "align='center' border='0'").Replace("<tr>", ""));
            int CharCode = 65, i = 0;
            foreach (DataRow dr in dtCompany.Rows)
            {
                string strCoLetter = char.ConvertFromUtf32(CharCode);
                string strCompany = dr["Company"].ToString();
                STR_INSURANCE_COMPANIES[i, 0] = strCoLetter;
                STR_INSURANCE_COMPANIES[i, 1] = strCompany;
                sbContent.Append("<tr>");
                sbContent.Append(TD("20%", "center", "", "Company<br>" + strCoLetter, COIContentType.SectionHeader));
                sbContent.Append(TD("80%", "left", "height='40'", strCompany, COIContentType.Data));
                sbContent.Append("</tr>");
                CharCode++;
                i++;
            }
            sbContent.Append(ENDTABLE().Replace("</tr>", ""));
        }

        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("100%", "0", "5", "").Replace("<tr>", ""));
        sb.Append(TR("100%", "left", "valign='top'", "THIS CERTIFICATE IS ISSUED AS A MATTER OF INFORMATION ONLY AND CONFERS NO RIGHTS UPON THE CERTIFICATE HOLDER. " +
            "THIS CERTIFICATE DOES NOT AMEND, EXTEND OR ALTER THE COVERAGE AFFORDED BY THE POLICIES BELOW.", COIContentType.InformationContent));
        sb.Append("</tr>");
        sb.Append(TR("100%", "center", "", "COMPANIES AFFORDING COVERAGE", COIContentType.InformationContent));
        sb.Append(TR("100%", "center", "", sbContent.ToString(), COIContentType.None));
        sb.Append(ENDTABLE().Replace("</tr>", ""));
        return sb.ToString();
    }
    #endregion

    #region "ISURED"
    private string SetInsuredDetails(decimal FK_COI)
    {
        StringBuilder sbContent = new StringBuilder();
        COIs objCOI = new COIs(FK_COI);
        DataTable dtInsured = COI_Insureds.Select(objCOI.FK_COI_Insureds).Tables[0];
        if (dtInsured.Rows.Count > 0)
        {
            COI_Insureds objInsured = new COI_Insureds(Convert.ToDecimal(dtInsured.Rows[0][0]));
            string strName = clsGeneral.FormatName(objInsured.Contact_First_Name, objInsured.Contact_Last_Name);
            string strAddress = clsGeneral.FormatAddress(objInsured.Address_1, objInsured.Address_2, objInsured.City, new COI_State(objInsured.FK_State).FLD_abbreviation, objInsured.Zip_Code);

            string strContent = objInsured.Contact_Title + "<br>" + strName + "<br>" + strAddress + "<br>Ph.#: " + objInsured.Contact_Phone;

            sbContent.Append(TABLE("80%", "0", "0", "align='center'"));
            sbContent.Append(TD("100%", "Left", "height='40'", strContent, COIContentType.Data));
            sbContent.Append(ENDTABLE());
        }

        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("100%", "0", "0", "").Replace("<tr>", ""));
        sb.Append(TR("100%", "left", "valign='top'", "INSURED", COIContentType.SectionHeader));
        sb.Append(TR("100%", "left", "", sbContent.ToString(), COIContentType.None));
        sb.Append(ENDTABLE().Replace("</tr>", ""));
        return sb.ToString();
    }
    #endregion

    #region "COVERAGES"

    private string SetCoveragesHeaderInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("90%", "0", "0", "align='center' border='0'"));
        sb.Append(TD("100%", "left", "",
            "THIS IS TO CERTIFY THAT THE POLICIES OF INSURANCE LISTED BELOW HAVE BEEN INSURED NAMED ABOVE FOR THE POLICY PERIOD INDICATED, " +
            "NORTHWITHSTANDING ANY REQUIREMENT, TERM OR CONDITION OF ANY CONTRACT OR OTHER DOCUMENT WITH RESPECT TO WHICH THIS CERTIFICATE " +
            "MAY BE ISSUED OR MAY PERTAIN, THE INSURANCE AFFORDED BY THE POLICIES DESCRIBED HEREIN IS SUBJECT TO ALL THE TERMS,EXCLUSIONS " +
            "AND CONDITIONS OF SUCH POLICIES. LIMITS SHOWN MAY HAVE BEEN REDUCED BY PAID CLAIMS.", COIContentType.GeneralContent));
        sb.Append(ENDTABLE());
        return sb.ToString();
    }

    #region "GENERAL LIABILITY POLICY"
    private string GetGeneralPolicyDetails(decimal FK_COI)
    {

        DataTable dtPolicy = COI_General_Policies.SelectByFK_COIs(FK_COI).Tables[0];
        if (dtPolicy.Rows.Count > 0)
        {
            StringBuilder sbContent = new StringBuilder();
            foreach (DataRow dr in dtPolicy.Rows)
            {
                COI_General_Policies objPolicy = new COI_General_Policies(Convert.ToDecimal(dr["PK_COI_General_Policies"]));

                string strCoLetter = "";
                for (int i = 0; i < STR_INSURANCE_COMPANIES.Length / 2; i++)
                {
                    if (objPolicy.Insurance_Company == STR_INSURANCE_COMPANIES[i, 1])
                        strCoLetter = STR_INSURANCE_COMPANIES[i, 0];
                }

                StringBuilder sbType = new StringBuilder();
                sbType.Append(TABLE("100%", "0", "0", "border='0'"));
                sbType.Append(TD("100%", "left", "colspan='2'", "GENERAL LIABILITY", COIContentType.GeneralContent));
                sbType.Append(ENDTABLE());
                sbType.Append(TABLE("100%", "0", "0", "border='0'"));
                sbType.Append(TD("10%", "center", "valign='top'", objPolicy.Commercial_Liability == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("90%", "left", "", "COMMERCIAL GENERAL LIABILITY", COIContentType.GeneralContent));
                sbType.Append("</tr><tr>");
                sbType.Append(TD("", "center", "valign='top'", objPolicy.Occurrence_Liability == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("", "left", "", "OCCUR", COIContentType.GeneralContent));
                sbType.Append(ENDTABLE());

                StringBuilder sbProperty = new StringBuilder();
                sbProperty.Append(TABLE("100%", "0", "0", "border='0'").Replace("<tr>", ""));
                sbProperty.Append(TR("100%", "left", "", "GENERAL AGGREGATE", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "PRODUCTS-COMP/OPS AGGREGATE", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "PERSONAL & ADVERTISING INJURY", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "EACH OCCURRENCE", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "FIRE DAMAGE (Any one fire)", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "MEDICAL EXPENSE (Any one person)", COIContentType.GeneralContent));
                sbProperty.Append(ENDTABLE().Replace("</tr>", ""));

                StringBuilder sbLimits = new StringBuilder();
                sbLimits.Append(TABLE("100%", "0", "0", "border='0'").Replace("<tr>", ""));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.General_Aggregate), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Products_Operations), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Personal_Advertising_Injury), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Occurrence_Covereage), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Fire_Damage), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Medical_Expense), COIContentType.Data));
                sbLimits.Append(ENDTABLE().Replace("</tr>", ""));


                string strEffectiveDate = objPolicy.Effective_Date.ToString("MM/dd/yy");
                string strExpirationDate = objPolicy.Expiration_Date.ToString("MM/dd/yy");

                sbContent.Append("<tr>");
                sbContent.Append(TD("", "center", "BgColor='white'", strCoLetter, COIContentType.GeneralContent));
                sbContent.Append(TD("", "left", "BgColor='white'", sbType.ToString(), COIContentType.None));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Policy_Number, COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", strEffectiveDate, COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", strExpirationDate, COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", sbProperty.ToString(), COIContentType.None));
                sbContent.Append(TD("", "center", "BgColor='white'", sbLimits.ToString(), COIContentType.None));
                sbContent.Append("</tr>");

                AppendPolicyInfo_DataRow(objPolicy.PK_COI_General_Policies.ToString(), "GENERAL", objPolicy.Policy_Number, objPolicy.Insurance_Company, strEffectiveDate, strExpirationDate);
            }
            return sbContent.ToString();
        }
        else
            return GetBlankPolicyDetails("GENERAL LIABILITY");

    }
    #endregion

    #region "AUTOMOBILE LIABILITY POLICY"
    private string GetAutomobilePolicyDetails(decimal FK_COI)
    {
        DataTable dtPolicy = COI_Automobile_Policies.SelectByFK_COIs(FK_COI).Tables[0];
        if (dtPolicy.Rows.Count > 0)
        {
            StringBuilder sbContent = new StringBuilder();
            foreach (DataRow dr in dtPolicy.Rows)
            {
                COI_Automobile_Policies objPolicy = new COI_Automobile_Policies(Convert.ToDecimal(dr["PK_COI_Automobile_Policies"]));

                string strCoLetter = "";
                for (int i = 0; i < STR_INSURANCE_COMPANIES.Length / 2; i++)
                {
                    if (objPolicy.Insurance_Company == STR_INSURANCE_COMPANIES[i, 1])
                        strCoLetter = STR_INSURANCE_COMPANIES[i, 0];
                }

                StringBuilder sbType = new StringBuilder();
                sbType.Append(TABLE("100%", "0", "0", "border='0'"));
                sbType.Append(TD("100%", "left", "colspan='2'", "AUTOMOBILE LIABILITY", COIContentType.GeneralContent));
                sbType.Append(ENDTABLE());
                sbType.Append(TABLE("100%", "0", "0", "border='0'"));
                sbType.Append(TD("10%", "center", "valign='top'", objPolicy.Any_Auto == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("90%", "left", "", "ANY AUTO", COIContentType.GeneralContent));
                sbType.Append("</tr><tr>");
                sbType.Append(TD("", "center", "valign='top'", objPolicy.All_Owned_Vehicles == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("", "left", "", "ALL OWNED AUTOS", COIContentType.GeneralContent));
                sbType.Append("</tr><tr>");
                sbType.Append(TD("", "center", "valign='top'", objPolicy.Scheduled_Autos == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("", "left", "", "SCHEDULED AUTOS", COIContentType.GeneralContent));
                sbType.Append("</tr><tr>");
                sbType.Append(TD("", "center", "valign='top'", objPolicy.Hired_Autos == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("", "left", "", "SCHEDULED AUTOS", COIContentType.GeneralContent));
                sbType.Append("</tr><tr>");
                sbType.Append(TD("", "center", "valign='top'", objPolicy.Non_Owned_Autos == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("", "left", "", "HIRED AUTOS", COIContentType.GeneralContent));
                sbType.Append(ENDTABLE());



                StringBuilder sbProperty = new StringBuilder();
                sbProperty.Append(TABLE("100%", "0", "0", "border='0'").Replace("<tr>", ""));
                sbProperty.Append(TR("100%", "left", "", "COMBINED SINGLE LIMIT", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "BODILY INJURY(Per person)", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "BODILY INJURY(Per accident)", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "PROPERTY DAMAGE", COIContentType.GeneralContent));
                sbProperty.Append(ENDTABLE().Replace("</tr>", ""));

                StringBuilder sbLimits = new StringBuilder();
                sbLimits.Append(TABLE("100%", "0", "0", "border='0'").Replace("<tr>", ""));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Combined_Single_Limit), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Bodily_Injury_Person), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Bodily_Injury_Accident), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Property_Damage), COIContentType.Data));
                sbLimits.Append(ENDTABLE().Replace("</tr>", ""));

                string strEffectiveDate = objPolicy.Effective_Date.ToString("MM/dd/yy");
                string strExpirationDate = objPolicy.Expiration_Date.ToString("MM/dd/yy");

                sbContent.Append("<tr>");
                sbContent.Append(TD("", "center", "BgColor='white'", strCoLetter, COIContentType.GeneralContent));
                sbContent.Append(TD("", "left", "BgColor='white'", sbType.ToString(), COIContentType.None));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Policy_Number, COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Effective_Date.ToString("MM/dd/yy"), COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Expiration_Date.ToString("MM/dd/yy"), COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", sbProperty.ToString(), COIContentType.None));
                sbContent.Append(TD("", "center", "BgColor='white'", sbLimits.ToString(), COIContentType.None));
                sbContent.Append("</tr>");

                AppendPolicyInfo_DataRow(objPolicy.PK_COI_Automobile_Policies.ToString(), "AUTOMOBILE", objPolicy.Policy_Number, objPolicy.Insurance_Company, strEffectiveDate, strExpirationDate);
            }
            return sbContent.ToString();
        }
        else
            return GetBlankPolicyDetails("AUTOMOBILE LIABILITY");

    }
    #endregion

    #region "EXCESS LIABILITY POLICY"
    private string GetExcessPolicyDetails(decimal FK_COI)
    {

        DataTable dtPolicy = COI_Excess_Policies.SelectByFK_COIs(FK_COI).Tables[0];
        if (dtPolicy.Rows.Count > 0)
        {
            StringBuilder sbContent = new StringBuilder();
            foreach (DataRow dr in dtPolicy.Rows)
            {
                COI_Excess_Policies objPolicy = new COI_Excess_Policies(Convert.ToDecimal(dr["PK_COI_Excess_Policies"]));

                string strCoLetter = "";
                for (int i = 0; i < STR_INSURANCE_COMPANIES.Length / 2; i++)
                {
                    if (objPolicy.Insurance_Company == STR_INSURANCE_COMPANIES[i, 1])
                        strCoLetter = STR_INSURANCE_COMPANIES[i, 0];
                }

                StringBuilder sbType = new StringBuilder();
                sbType.Append(TABLE("100%", "0", "0", "border='0'"));
                sbType.Append(TD("100%", "left", "colspan='2'", "EXCESS LIABILITY", COIContentType.GeneralContent));
                sbType.Append(ENDTABLE());
                sbType.Append(TABLE("100%", "0", "0", "border='0'"));
                sbType.Append(TD("10%", "center", "valign='top'", objPolicy.Umbrealla_Form == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("90%", "left", "", "UMBRELLA FORM", COIContentType.GeneralContent));
                sbType.Append("</tr><tr>");
                sbType.Append(TD("", "center", "valign='top'", objPolicy.Special_Umbrella == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("", "left", "", "OTHER THAN UMBRELLA FORM", COIContentType.GeneralContent));
                sbType.Append(ENDTABLE());



                StringBuilder sbProperty = new StringBuilder();
                sbProperty.Append(TABLE("100%", "0", "0", "border='0'").Replace("<tr>", ""));
                sbProperty.Append(TR("100%", "left", "", "EACH OCCURANCE", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "AGGREGATE", COIContentType.GeneralContent));
                sbProperty.Append(ENDTABLE().Replace("</tr>", ""));

                StringBuilder sbLimits = new StringBuilder();
                sbLimits.Append(TABLE("100%", "0", "0", "border='0'").Replace("<tr>", ""));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Occurrence_Coverage), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Aggregate_Coverage), COIContentType.Data));
                sbLimits.Append(ENDTABLE().Replace("</tr>", ""));

                string strEffectiveDate = objPolicy.Effective_Date.ToString("MM/dd/yy");
                string strExpirationDate = objPolicy.Expiration_Date.ToString("MM/dd/yy");
                sbContent.Append("<tr>");
                sbContent.Append(TD("", "center", "BgColor='white'", strCoLetter, COIContentType.GeneralContent));
                sbContent.Append(TD("", "left", "BgColor='white'", sbType.ToString(), COIContentType.None));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Policy_Number, COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Effective_Date.ToString("MM/dd/yy"), COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Expiration_Date.ToString("MM/dd/yy"), COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", sbProperty.ToString(), COIContentType.None));
                sbContent.Append(TD("", "center", "BgColor='white'", sbLimits.ToString(), COIContentType.None));
                sbContent.Append("</tr>");

                AppendPolicyInfo_DataRow(objPolicy.PK_COI_Excess_Policies.ToString(), "EXCESS", objPolicy.Policy_Number, objPolicy.Insurance_Company, strEffectiveDate, strExpirationDate);
            }
            return sbContent.ToString();
        }
        else
            return GetBlankPolicyDetails("EXCESS LIABILITY");

    }
    #endregion

    #region "WC LIABILITY POLICY"
    private string GetWCPolicyDetails(decimal FK_COI)
    {
        DataTable dtPolicy = COI_WC_Policies.SelectByFK_COIs(FK_COI).Tables[0];
        if (dtPolicy.Rows.Count > 0)
        {
            StringBuilder sbContent = new StringBuilder();
            foreach (DataRow dr in dtPolicy.Rows)
            {
                COI_WC_Policies objPolicy = new COI_WC_Policies(Convert.ToDecimal(dr["PK_COI_WC_Policies"]));

                string strCoLetter = "";
                for (int i = 0; i < STR_INSURANCE_COMPANIES.Length / 2; i++)
                {
                    if (objPolicy.Insurance_Company == STR_INSURANCE_COMPANIES[i, 1])
                        strCoLetter = STR_INSURANCE_COMPANIES[i, 0];
                }

                StringBuilder sbType = new StringBuilder();
                sbType.Append(TABLE("100%", "0", "0", "border='0'"));
                sbType.Append(TD("100%", "left", "colspan='2'", "WC LIABILITY", COIContentType.GeneralContent));
                sbType.Append(ENDTABLE());
                sbType.Append(TABLE("100%", "0", "0", "border='0'"));
                sbType.Append(TD("10%", "center", "valign='top'", objPolicy.State_Limits == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("90%", "left", "", "WC STATE LIMITS", COIContentType.GeneralContent));
                sbType.Append("</tr><tr>");
                sbType.Append(TD("", "center", "valign='top'", objPolicy.Leased_Employees == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("", "left", "", "LEASED EMPLOYEES INCLUDED", COIContentType.GeneralContent));
                sbType.Append("</tr><tr>");
                sbType.Append(TD("", "center", "valign='top'", objPolicy.State_Funded == "Y" ? "X" : "&nbsp;", COIContentType.GeneralContent));
                sbType.Append(TD("", "left", "", "STATE FUNDED", COIContentType.GeneralContent));
                sbType.Append(ENDTABLE());



                StringBuilder sbProperty = new StringBuilder();
                sbProperty.Append(TABLE("100%", "0", "0", "border='0'").Replace("<tr>", ""));
                sbProperty.Append(TR("100%", "left", "", "EACH ACCIDENT", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "DISEASE-POLICE LIMIT", COIContentType.GeneralContent));
                sbProperty.Append(TR("100%", "left", "", "DISEASE-EACH EMPLOYEE", COIContentType.GeneralContent));
                sbProperty.Append(ENDTABLE().Replace("</tr>", ""));

                StringBuilder sbLimits = new StringBuilder();
                sbLimits.Append(TABLE("100%", "0", "0", "border='0'").Replace("<tr>", ""));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Accident), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Disease_Limit), COIContentType.Data));
                sbLimits.Append(TR("100%", "left", "", FormatAmount(objPolicy.Disease_Each), COIContentType.Data));
                sbLimits.Append(ENDTABLE().Replace("</tr>", ""));

                string strEffectiveDate = objPolicy.Effective_Date.ToString("MM/dd/yy");
                string strExpirationDate = objPolicy.Expiration_Date.ToString("MM/dd/yy");
                sbContent.Append("<tr>");
                sbContent.Append(TD("", "center", "BgColor='white'", strCoLetter, COIContentType.GeneralContent));
                sbContent.Append(TD("", "left", "BgColor='white'", sbType.ToString(), COIContentType.None));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Policy_Number, COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Effective_Date.ToString("MM/dd/yy"), COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", objPolicy.Expiration_Date.ToString("MM/dd/yy"), COIContentType.Data));
                sbContent.Append(TD("", "center", "BgColor='white'", sbProperty.ToString(), COIContentType.None));
                sbContent.Append(TD("", "center", "BgColor='white'", sbLimits.ToString(), COIContentType.None));
                sbContent.Append("</tr>");

                AppendPolicyInfo_DataRow(objPolicy.PK_COI_WC_Policies.ToString(), "WC", objPolicy.Policy_Number, objPolicy.Insurance_Company, strEffectiveDate, strExpirationDate);
            }
            return sbContent.ToString();
        }
        else
            return GetBlankPolicyDetails("WC LIABILITY");

    }
    #endregion



    private string GetBlankPolicyDetails(string strPolicyName)
    {
        StringBuilder sbContent = new StringBuilder();
        sbContent.Append("<tr>");
        sbContent.Append(TD("", "center", "BgColor='white' height='40'", "", COIContentType.None));
        sbContent.Append(TD("", "left", "BgColor='white'", strPolicyName, COIContentType.GeneralContent));
        sbContent.Append(TD("", "center", "BgColor='white'", "", COIContentType.None));
        sbContent.Append(TD("", "center", "BgColor='white'", "", COIContentType.None));
        sbContent.Append(TD("", "center", "BgColor='white'", "", COIContentType.None));
        sbContent.Append(TD("", "center", "BgColor='white'", "", COIContentType.None));
        sbContent.Append(TD("", "center", "BgColor='white'", "", COIContentType.None));
        sbContent.Append("</tr>");
        return sbContent.ToString();
    }
    #endregion

    #region "LOCATION"
    private string SetLocationInfo(decimal PK_Locations)
    {
        StringBuilder sbContent = new StringBuilder();
        COI_Locations objLocation = new COI_Locations(PK_Locations);

        string strName = objLocation.Name;
        string strAddress = clsGeneral.FormatAddress(objLocation.Address_1, objLocation.Address_2, objLocation.City, new COI_State(objLocation.FK_State).FLD_abbreviation, objLocation.Zip_Code);
        string strContent = strName + "<br>" + strAddress;

        sbContent.Append(TABLE("80%", "0", "0", "align='center'"));
        sbContent.Append(TD("100%", "Left", "height='40'", strContent, COIContentType.Data));
        sbContent.Append(ENDTABLE());


        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("100%", "0", "0", "").Replace("<tr>", ""));
        sb.Append(TR("100%", "left", "valign='top'", "LOCATION OF PREMISES/DESCRIPTION OF PROPERTY", COIContentType.SectionHeader));
        sb.Append(TR("100%", "left", "", sbContent.ToString(), COIContentType.None));
        sb.Append(ENDTABLE().Replace("</tr>", ""));
        return sb.ToString();
    }
    #endregion

    #region "CERTIFICATE HOLDER & CANCELLATION"
    private string Set_CertiHolder_And_Cancellation_DTL(decimal FK_COI)
    {
        StringBuilder sbHolder = new StringBuilder();
        sbHolder.Append(TABLE("80%", "0", "0", "height='40' align='center'"));
        DataTable dtCertiHolder = COI_Certificate_Holder.SelectAll().Tables[0];
        if (dtCertiHolder.Rows.Count > 0)
        {
            COI_Certificate_Holder objHolder = new COI_Certificate_Holder(Convert.ToDecimal(dtCertiHolder.Rows[0][0]));
            string strName = clsGeneral.FormatName(objHolder.Contact_First_Name, objHolder.Contact_Last_Name);
            string strAddress = clsGeneral.FormatAddress(objHolder.Address_1, objHolder.Address_2, objHolder.City, new State(objHolder.FK_State).FLD_abbreviation, objHolder.Zip_Code);
            sbHolder.Append(TD("100%", "left", "", objHolder.Company + "<Br>" + strName + "<br>" + strAddress, COIContentType.Data));
        }
        sbHolder.Append(ENDTABLE());

        StringBuilder sbCancel = new StringBuilder();
        sbCancel.Append(TABLE("95%", "0", "0", "align='center'"));
        sbCancel.Append(TD("100%", "left", "",
            "SHOULD ANY OF THE ABOVE DESCRIBED POLICIES BE CANCELLED BEFORE THE EXPIRATION DATE THEREOF, THE ISSUING COMPANY WILL ENDEAVOR " +
            "TO MAIL <U><b>&nbsp;&nbsp;&nbsp;" + new COIs(FK_COI).Cancellation_Notice + "&nbsp;&nbsp;&nbsp;</b></U> DAYS WRITTEN NOTICE TO " +
            "THE CERTIFICATION HOLDER NAMED TO THE LEFT, BUT FAILURE TO MAIL SUCH NOTICE SHELL IMPOSE NO OBLIGATION OR LIABILITY OD ANY " +
            "KIND UPON THE COMPANY, ITS AGENTS OR REPRESENTATIVES.", COIContentType.GeneralContent));
        sbCancel.Append(ENDTABLE());

        StringBuilder sbAuth = new StringBuilder();
        sbAuth.Append(TABLE("100%", "0", "", ""));
        sbAuth.Append(TD("100%", "left", "", "&nbsp;AUTHORIZED REPRESENTATIVE", COIContentType.SectionHeader) + "</tr>");
        sbAuth.Append(TR("100%", "left", "", "&nbsp;", COIContentType.None));
        sbAuth.Append(TR("100%", "left", "", "&nbsp;", COIContentType.None));
        sbAuth.Append(ENDTABLE().Replace("</tr>", ""));

        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("50%", "left", "valign='top'", sbHolder.ToString(), COIContentType.None));
        sb.Append(TD("50%", "left", "", sbCancel.ToString() + sbAuth.ToString(), COIContentType.None));
        sb.Append(ENDTABLE());
        return sb.ToString();
    }
    #endregion

    private void AppendPolicyInfo_DataRow(string PK, string PolicyType, string PolicyNumber, string InsuraceComp, string EffectiveDate, string ExpirationDate)
    {
        DataRow drPolicyInfo = DT_POLICY_INFO.NewRow();
        drPolicyInfo["PK_Policy"] = PK;
        drPolicyInfo["Policy_type"] = PolicyType;
        drPolicyInfo["Insurance_Company"] = InsuraceComp;
        drPolicyInfo["Policy_Number"] = PolicyNumber;
        drPolicyInfo["Expiration_Date"] = ExpirationDate;
        drPolicyInfo["Effective_Date"] = EffectiveDate;
        DT_POLICY_INFO.Rows.Add(drPolicyInfo);
    }

    #endregion

    #region "--------------- EVIDENCE OF PROPERTY ---------------------------------"

    private void GeneratePropertyEvidencePDF(decimal FK_COI, decimal PK_Location, string strCompany, DataRow drPolicy)
    {
        StringBuilder sbDate = new StringBuilder();
        sbDate.Append(TABLE("100%", "0", "0", ""));
        sbDate.Append(TD("100%", "center", "valign=top", "DATE", COIContentType.SectionHeader) + "</tr>");
        sbDate.Append(TR("100%", "center", "", clsGeneral.FormatDBNullDateToDisplay(new COIs(FK_COI).Issue_Date), COIContentType.Data));
        sbDate.Append(ENDTABLE().Replace("</tr>", ""));

        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("85%", "center", "valign='middle'", SetPropertyPageHeader(), COIContentType.None));
        sb.Append(TD("15%", "center", "valign=top", sbDate.ToString(), COIContentType.None));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("100%", "left", "",
            "THIS EVIDENCE OF PROPERTY INSURANCE IS ISSUED AS A MATTER OF INFORMATION ONLY AND CONFERS NO RIGHTS UPON THE ADDITIONAL " +
            "INTEREST NAMED BELOW. THIS EVIDENCE OF PROPERTY INSURANCE DOES NOT AMEND, EXTEND OR ALTER THE COVERAGE AFFORDED BY THE POLICY BELOW ", COIContentType.InformationContent));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("50%", "left", "", SetEvidenceAgencyInfo(), COIContentType.None));
        sb.Append(TD("50%", "left", "", SetEvidenceInsuranceCompDetails(strCompany), COIContentType.None));
        sb.Append("</tr><tr>");
        sb.Append(TD("50%", "left", "", SetEvidenceInsuredDetails(FK_COI), COIContentType.None));
        sb.Append(TD("50%", "left", "", SetEvidencePolicyInfo(drPolicy), COIContentType.None));
        sb.Append(ENDTABLE().Replace("</tr>", ""));

        sb.Append(TABLE("100%", "0", "0", ""));
        sb.Append(TD("100%", "left", "", "PROPERTY INFORMATION", COIContentType.InformationContent));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "2", "BgColor='black'").Replace("<tr>", ""));
        sb.Append(TR("100%", "left", "BgColor='white'", SetEvidenceLocactionInfo(PK_Location), COIContentType.None));
        sb.Append(TR("100%", "left", "BgColor='white'",
            "THE POLICIES OF INSURANCE LISTED BELOW HAVE BEEN ISSUED TO THE INSURED NAMED ABOVE FOR THE POLICY PERIOD INDICATED. " +
            "NORTHWITHSTANDING ANY REQUIREMENT, TERM OR CONDITION OF ANY CONTRACT OR OTHER DOCUMENT WITH RESPECT TO WHICH THIS " +
            "EVIDENCE OF PROPERTY INSURANNCE MAY BE ISSUED OR MAY PERTAIN, THE INSURANCE AFFORDED BY THE POLICIES DESCRIBED HEREIN IS " +
            "SUBJECT TO ALL THE TERMS, EXCLUSIONS AND CONDITIONS OF SUCH POLICIES. LIMITS SHOWN MAY HAVE BEEN REDUCED BY PAID CLAIMS.", COIContentType.GeneralContent));
        sb.Append(ENDTABLE().Replace("</tr>", ""));

        sb.Append(TABLE("100%", "0", "0", ""));
        sb.Append(TD("100%", "left", "", "COVERAGE INFORMATION", COIContentType.InformationContent));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "2", "BgColor='black'"));
        sb.Append(TD("60%", "center", "BgColor='white'", "COVERAGE / PERILS / FORMS", COIContentType.SectionHeader));
        sb.Append(TD("25%", "center", "BgColor='white'", "AMOUNT OF INSURANCE", COIContentType.SectionHeader));
        sb.Append(TD("15%", "center", "BgColor='white'", "DEDUCTIBLE", COIContentType.SectionHeader) + "</tr><tr>");

        sb.Append(TD("60%", "center", "BgColor='white' height='100'", SetEvidenceCoverageInfo(), COIContentType.None));
        sb.Append(TD("25%", "center", "BgColor='white'", SetEvidenceAmountInfo(PK_Location), COIContentType.None));
        sb.Append(TD("15%", "center", "BgColor='white'", SetEvidenceDeductibleInfo(PK_Location), COIContentType.None));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", ""));
        sb.Append(TD("100%", "left", "", "REMARKS (Including Special Conditions)", COIContentType.InformationContent));
        sb.Append(ENDTABLE());


        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("100%", "left", "height='50'", "&nbsp;", COIContentType.InformationContent));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", ""));
        sb.Append(TD("100%", "left", "", "CANCELLATION", COIContentType.InformationContent));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "0", "border='1' BorderColor='black'"));
        sb.Append(TD("100%", "left", "",
            "SHOULD ANY OF THE ABOVE DESCRIBED POLICIES BE CANCELLED BEFORE THE EXPIRATION DATE THEREOF, THE ISSUING COMPANY WILL ENDEAVOR " +
            "TO MAIL <U><b>&nbsp;&nbsp;&nbsp;" + new COIs(FK_COI).Cancellation_Notice + "&nbsp;&nbsp;&nbsp;</b></U> DAYS WRITTEN NOTICE TO " +
            "THE CERTIFICATION HOLDER NAMED TO THE LEFT, BUT FAILURE TO MAIL SUCH NOTICE SHELL IMPOSE NO OBLIGATION OR LIABILITY OD ANY " +
            "KIND UPON THE COMPANY, ITS AGENTS OR REPRESENTATIVES.", COIContentType.GeneralContent));
        sb.Append(ENDTABLE());


        sb.Append(TABLE("100%", "0", "0", ""));
        sb.Append(TD("100%", "left", "", "ADDITIONAL INTEREST", COIContentType.InformationContent));
        sb.Append(ENDTABLE());

        sb.Append(TABLE("100%", "0", "2", "BgColor='black'"));
        sb.Append(TD("50%", "left", "height='40' BgColor='white'", "NAME AND ADDRESS", COIContentType.SectionHeader));
        sb.Append(TD("50%", "left", "height='40' BgColor='white'", "LENDER SERVICING AGENT NAME AND ADDRESS", COIContentType.SectionHeader));
        sb.Append("</TR><TR>");
        sb.Append(TD("50%", "left", "height='20' BgColor='white'", "MORTGAGEE<br>LOSS PAYEE", COIContentType.GeneralContent));
        sb.Append(TD("50%", "left", "height='20' BgColor='white'", "AUTHORISED REPRESENTATIVE", COIContentType.SectionHeader));
        sb.Append(ENDTABLE());

        if (ltrPrintCOI.Text.Length > 0)
            ltrPrintCOI.Text += strPrintPageBreak + sb.ToString();
        else
            ltrPrintCOI.Text = sb.ToString();

        //ltrPrintCOI.Visible = true;
    }

    private string SetPropertyPageHeader()
    {
        StringBuilder sbHeader = new StringBuilder();
        sbHeader.Append(TABLE("100%", "0", "0", "height='5'"));
        sbHeader.Append(TD("15%", "center", "", "<u><I>ACORD</I></u>", COIContentType.PageHeader));
        sbHeader.Append(TD("85%", "center", "", "EVIDENCE OF PROPERTY INSURANCE", COIContentType.PageHeader));
        sbHeader.Append(ENDTABLE());
        return sbHeader.ToString();
    }

    #region "INSURANCE COMPANIES"
    private string SetEvidenceInsuranceCompDetails(string strCompany)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("90%", "0", "0", "align='center'"));
        sb.Append(TD("100%", "left", "", strCompany, COIContentType.Data));
        sb.Append(ENDTABLE());

        StringBuilder sbHeader = new StringBuilder();
        sbHeader.Append(TABLE("100%", "0", "0", ""));
        sbHeader.Append(TD("100%", "left", "", "COMPANY", COIContentType.SectionHeader) + "</tr>");
        sbHeader.Append(TR("100%", "center", "", sb.ToString(), COIContentType.None));
        sbHeader.Append(ENDTABLE().Replace("</tr>", ""));
        return sbHeader.ToString();
    }
    #endregion

    #region "ISURED"
    private string SetEvidenceInsuredDetails(decimal FK_COI)
    {
        StringBuilder sbContent = new StringBuilder();
        COIs objCOI = new COIs(FK_COI);
        DataTable dtInsured = COI_Insureds.Select(objCOI.FK_COI_Insureds).Tables[0];
        if (dtInsured.Rows.Count > 0)
        {
            COI_Insureds objInsured = new COI_Insureds(Convert.ToDecimal(dtInsured.Rows[0][0]));
            string strName = clsGeneral.FormatName(objInsured.Contact_First_Name, objInsured.Contact_Last_Name);
            string strAddress = clsGeneral.FormatAddress(objInsured.Address_1, objInsured.Address_2, objInsured.City, new COI_State(objInsured.FK_State).FLD_abbreviation, objInsured.Zip_Code);

            string strContent = objInsured.Contact_Title + "<br>" + strName + "<br>" + strAddress + "<br>Ph.#: " + objInsured.Contact_Phone;

            sbContent.Append(TABLE("80%", "0", "0", "align='center'"));
            sbContent.Append(TD("100%", "Left", "height='40'", strContent, COIContentType.Data));
            sbContent.Append(ENDTABLE());
        }

        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("100%", "0", "0", "").Replace("<tr>", ""));
        sb.Append(TR("100%", "left", "valign='top'", "INSURED", COIContentType.SectionHeader));
        sb.Append(TR("100%", "left", "", sbContent.ToString(), COIContentType.None));
        sb.Append(ENDTABLE().Replace("</tr>", ""));
        return sb.ToString();
    }
    #endregion

    private string SetEvidenceAgencyInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(TABLE("100%", "0", "0", ""));
        sb.Append(TD("100%", "0", "height='20'", "AGENCY", COIContentType.SectionHeader));
        sb.Append(ENDTABLE());

        StringBuilder sb1 = new StringBuilder();
        sb1.Append(TABLE("100%", "0", "0", ""));
        sb1.Append(TD("40%", "left", "", "FAX<br>(A/C,No):", COIContentType.SectionHeader));
        sb1.Append(TD("60%", "left", "", "E-MAIL<br>ADDRESS :", COIContentType.SectionHeader));
        sb1.Append(ENDTABLE());

        StringBuilder sb2 = new StringBuilder();
        sb2.Append(TABLE("100%", "0", "0", ""));
        sb2.Append(TD("60%", "left", "", "CODE:", COIContentType.SectionHeader));
        sb2.Append(TD("40%", "left", "", "SUB CODE:", COIContentType.SectionHeader));
        sb2.Append(ENDTABLE());

        StringBuilder sb3 = new StringBuilder();
        sb3.Append(TABLE("100%", "0", "0", ""));
        sb3.Append(TD("100%", "0", "", "AGENCY<br>CUSTOMER ID #", COIContentType.SectionHeader));
        sb3.Append(ENDTABLE());

        StringBuilder sbContent = new StringBuilder();
        sbContent.Append(TABLE("100%", "0", "0", "").Replace("<tr>", ""));
        sbContent.Append(TR("100%", "left", "", sb.ToString(), COIContentType.None));
        sbContent.Append(TR("100%", "left", "", sb1.ToString(), COIContentType.None));
        sbContent.Append(TR("100%", "left", "", sb2.ToString(), COIContentType.None));
        sbContent.Append(TR("100%", "left", "", sb3.ToString(), COIContentType.None));
        sbContent.Append(ENDTABLE());

        return sbContent.ToString();


        
    }

    private string SetEvidencePolicyInfo(DataRow drPolicy)
    {
        string strPolicyNumber = "<table width='90%' align='center'><tr><td width='100%' align='left'>" + FormatContent(COIContentType.Data, drPolicy["Policy_Number"].ToString()) + "</td></tr></table>";
        string strEffectiveDate = "<table width='90%' align='center'><tr><td width='100%' align='left'>" + FormatContent(COIContentType.Data, drPolicy["Effective_Date"].ToString()) + "</td></tr></table>";
        string strExpirationDate = "<table width='90%' align='center'><tr><td width='100%' align='left'>" + FormatContent(COIContentType.Data, drPolicy["Expiration_Date"].ToString()) + "</td></tr></table>";
        
        StringBuilder sb1 = new StringBuilder();
        sb1.Append(TABLE("100%", "0", "0", ""));
        sb1.Append(TD("50%","left","","LOAN NUMBER",COIContentType.SectionHeader));
        sb1.Append(TD("50%", "left", "", "POLICY NUMBER", COIContentType.SectionHeader).Replace("</td>",""));
        sb1.Append(strPolicyNumber + "</td>");
        sb1.Append(ENDTABLE());

        StringBuilder sb2 = new StringBuilder();
        sb2.Append(TABLE("100%", "0", "0", ""));
        sb2.Append(TD("30%", "left", "", "EFFECTIVE DATE", COIContentType.SectionHeader).Replace("</td>", ""));
        sb2.Append(strEffectiveDate + "</td>");
        sb2.Append(TD("30%", "left", "", "EXPIRATION DATE", COIContentType.SectionHeader).Replace("</td>", ""));
        sb2.Append(strExpirationDate + "</td>");
        sb2.Append(TD("40%", "center", "valign='bottom'", "CONTINUED UNTIL<br>TERMINATED IF CHECKED", COIContentType.GeneralContent));
        sb2.Append(ENDTABLE());

        StringBuilder sb3 = new StringBuilder();
        sb3.Append(TABLE("100%", "0", "0", ""));
        sb3.Append(TD("100%", "left", "HEIGHT='20'", "THIS REPLACES PRIOR EVIDENCE DATED:", COIContentType.InformationContent));
        sb3.Append(ENDTABLE());

        return sb1.ToString() + sb2.ToString() + sb3.ToString();
    }

    private string SetEvidenceLocactionInfo(decimal PK_Location)
    {
        COI_Locations objLocation = new COI_Locations(PK_Location);

        string strName = objLocation.Name;
        string strAddress = clsGeneral.FormatAddress(objLocation.Address_1, objLocation.Address_2, objLocation.City, new COI_State(objLocation.FK_State).FLD_abbreviation, objLocation.Zip_Code);

        StringBuilder sbContent = new StringBuilder();
        sbContent.Append(TABLE("90%", "0", "0", "align='center'"));
        sbContent.Append(TD("100%", "left", "height='40'", strName + "<br>" + strAddress, COIContentType.Data));
        sbContent.Append(ENDTABLE());
        return sbContent.ToString();
    }

    private string SetEvidenceCoverageInfo()
    {
        StringBuilder sbCoverage = new StringBuilder();
        sbCoverage.Append(TABLE("100%", "0", "0", "").Replace("<tr>",""));
        sbCoverage.Append(TR("100%", "left", "", "FLOOD", COIContentType.GeneralContent));
        sbCoverage.Append(TR("100%", "left", "", "WIND", COIContentType.GeneralContent));
        sbCoverage.Append(TR("100%", "left", "", "EARTH MOVEMENT", COIContentType.GeneralContent));
        sbCoverage.Append(TR("100%", "left", "", "BUILDING AGGREGATE", COIContentType.GeneralContent));
        sbCoverage.Append(ENDTABLE().Replace("</tr>", ""));
        return sbCoverage.ToString();
    }

    private string SetEvidenceAmountInfo(decimal PK_Location)
    {
        COI_Locations objLocation = new COI_Locations(PK_Location);
        StringBuilder sbCoverage = new StringBuilder();
        sbCoverage.Append(TABLE("100%", "0", "0", "").Replace("<tr>", ""));
        sbCoverage.Append(TR("100%", "left", "", FormatAmount(objLocation.Flood_Coverage), COIContentType.Data));
        sbCoverage.Append(TR("100%", "left", "", FormatAmount(objLocation.Wind_Hail_Coverage), COIContentType.Data));
        sbCoverage.Append(TR("100%", "left", "", FormatAmount(objLocation.Earth_Movement_Coverage), COIContentType.Data));
        sbCoverage.Append(TR("100%", "left", "", FormatAmount(objLocation.Building_Aggregate), COIContentType.Data));
        sbCoverage.Append(ENDTABLE().Replace("</tr>", ""));
        return sbCoverage.ToString();
    }

    private string SetEvidenceDeductibleInfo(decimal PK_Location)
    {
        COI_Locations objLocation = new COI_Locations(PK_Location);
        StringBuilder sbCoverage = new StringBuilder();
        sbCoverage.Append(TABLE("100%", "0", "0", "").Replace("<tr>", ""));
        sbCoverage.Append(TR("100%", "left", "", "&nbsp;", COIContentType.Data));
        sbCoverage.Append(TR("100%", "left", "", "&nbsp;", COIContentType.Data));
        sbCoverage.Append(TR("100%", "left", "", "&nbsp;", COIContentType.Data));
        sbCoverage.Append(TR("100%", "left", "", FormatAmount(objLocation.Building_Deductible), COIContentType.Data));
        sbCoverage.Append(ENDTABLE().Replace("</tr>", ""));
        return sbCoverage.ToString();
    }
    #endregion

    #region "HTML"
    private enum COIContentType
    {
        Data = 1,
        SectionHeader = 2,
        PageHeader = 3,
        GeneralContent = 4,
        InformationContent = 5,
        None = 6
    }

    private string FormatContent(COIContentType objContent, string strContent)
    {
        string strReturnVal = "";
        switch (objContent)
        {
            case COIContentType.PageHeader:
                strReturnVal = "<font size='5'>" + strContent + "</font>";
                break;
            case COIContentType.SectionHeader:
                strReturnVal = "<font size='-4'><b>" + strContent + "</b></font>";
                break;
            case COIContentType.GeneralContent:
                strReturnVal = "<font size='-4'>" + strContent + "</font>";
                break;
            case COIContentType.Data:
                strReturnVal = "<font size='-4' face='Times New Roman'>" + strContent + "</font>";
                break;
            case COIContentType.InformationContent:
                strReturnVal = "<font size='-3'><b>" + strContent + "</b></font>";
                break;
        }
        return strReturnVal;
    }

    private string TABLE(string Width, string CellPadding, string CellSpacing, string Style)
    {
        StringBuilder sbTable = new StringBuilder();
        sbTable.Append("<table cellpadding='" + CellPadding + "' cellspacing='" + CellSpacing + "' width='" + Width + "' " + Style + "><tr>");        
        return sbTable.ToString();
    }

    private string TD(string TDWidth, string TDAlign, string TDStyle, string TDContent, COIContentType ContType)
    {
        string strHTML = "<td ";

        if (TDWidth != string.Empty)
        { strHTML += "width='" + TDWidth + "' "; }

        if (TDAlign != string.Empty)
        { strHTML += "align='" + TDAlign + "' "; }

        if (TDStyle != string.Empty)
        { strHTML += TDStyle; }

        if (ContType == COIContentType.None)
            strHTML += ">" + TDContent + "</td>";
        else
            strHTML += ">" + FormatContent(ContType, TDContent) + "</td>";

        return strHTML;
    }

    private string TR(string TDWidth, string TDAlign, string TDStyle, string TDContent, COIContentType ContType)
    {
        string strHTML = "<tr><td ";

        if (TDWidth != string.Empty)
        { strHTML += "width='" + TDWidth + "' "; }

        if (TDAlign != string.Empty)
        { strHTML += "align='" + TDAlign + "' "; }

        if (TDStyle != string.Empty)
        { strHTML += TDStyle; }


        if (ContType == COIContentType.None)
            strHTML += ">" + TDContent + "</td>";
        else
            strHTML += ">" + FormatContent(ContType, TDContent) + "</td></tr>";

        return strHTML;
    }

    private string ENDTABLE()
    {
        return "</tr></table>";
    }

    #endregion

    #region "Other Methods"

    private string FormatAmount(Nullable<decimal> decAmount)
    {
        string strAmount = string.Empty;
        if (decAmount != null)
        {
            if ((decimal)decAmount != 0)
            {
                strAmount = "$ " + clsGeneral.GetStringValue(decAmount);
            }
        }
        return strAmount;
    }

    #endregion
}
