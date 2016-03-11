using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Aspose.Words;
using ERIMS.DAL;

public partial class SONIC_RealEstate_LeaseAbstract : System.Web.UI.Page
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key for RE_Information
    /// </summary>
    public decimal _PK_RE_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK"]);
        }
        set
        {
            ViewState["PK"] = value;
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
        decimal pk;
        if (decimal.TryParse(Request.QueryString["id"], out pk))
        {
            _PK_RE_Information = pk;
        }

        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strLisenceFile = AppConfig.SitePath + "\\" + ("Bin") + "\\Aspose.Words.lic";

        //This shows how to license Aspose.Words, if you don't specify a license, 
        //Aspose.Words works in evaluation mode.        
        if (System.IO.File.Exists(strLisenceFile))
        {
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        // Create Blank Document
        Aspose.Words.Document doc = new Aspose.Words.Document();

        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
        // set Property
        builder.PageSetup.PaperSize = PaperSize.Letter;
        //builder.PageSetup.BottomMargin = 40;
        builder.PageSetup.RightMargin = 50;
        builder.PageSetup.LeftMargin = 50;
        builder.Font.Size = 11;
        builder.Font.Bold = false;
        builder.Font.Color = System.Drawing.Color.Black;
        builder.Font.Name = "Calibri";
        builder.InsertParagraph();
        GenerateHTML(sbHtml);
        System.IO.File.WriteAllText(@"D:\Temp\Lease.html", sbHtml.ToString());
        builder.InsertHtml(sbHtml.ToString());
        //builder.Write(litLetter.Text);
        //doc.MailMerge.Execute(dt);
        //Don't need merge fields in the document anymore.
        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;
        doc.MailMerge.DeleteFields();

        //doc.Save("EmployeeAbstract.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        doc.Save(Response, "LeaseAbstract.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));

        Response.End();
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// function use for generate html output for report
    /// </summary>
    /// <param name="sbHtml"></param>
    private void GenerateHTML(System.Text.StringBuilder sbHtml)
    {
        sbHtml.Append("<table width='100%' align='center'>");
        sbHtml.Append("<tr><td width='100%' align='center' style='font-size:16px;'><b>Sonic Automotive - Lease Abstract</b></td></tr>");
        sbHtml.Append("</table>");

        RE_Information objRE = new RE_Information(_PK_RE_Information);

        LU_Location objLocation = new LU_Location(Convert.ToDecimal(objRE.FK_LU_Location));

        sbHtml.Append("<table width='100%'>");

        #region "Location"

        sbHtml.Append(GetHeaderRow("Location Information"));
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("<tr>");
        sbHtml.Append("<td style='width:18%;' valign='top'>DBA</td>");
        sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
        sbHtml.Append("<td style='width:30%;' valign='top'> " + objLocation.dba + " </td>");
        //sbHtml.Append("<td style='width:18%;' valign='top'>Legal Entity</td>");
        //sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
        //sbHtml.Append("<td style='width:30%;' valign='top'> " + objLocation.legal_entity + " </td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td style='width:18%;' valign='top'>Parent Company Legal Entity</td>");
        sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
        sbHtml.Append("<td style='width:30%;' valign='top'> " + objLocation.Parent_Company_LE + " </td>");
        sbHtml.Append("<td style='width:18%;' valign='top'>Parent Company Legal Entity FEIN</td>");
        sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
        sbHtml.Append("<td style='width:30%;' valign='top'> " + objLocation.Parent_Company_LE_FEIN + " </td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td style='width:18%;' valign='top'>Legal Entity (Operations)</td>");
        sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
        sbHtml.Append("<td style='width:30%;' valign='top'> " + objLocation.LE_Operations + " </td>");
        sbHtml.Append("<td style='width:18%;' valign='top'>Legal Entity (Operations) FEIN</td>");
        sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
        sbHtml.Append("<td style='width:30%;' valign='top'> " + objLocation.LE_Operations_FEIN + " </td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td style='width:18%;' valign='top'>Legal Entity (Properties)</td>");
        sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
        sbHtml.Append("<td style='width:30%;' valign='top'> " + objLocation.LE_Properties + " </td>");
        sbHtml.Append("<td style='width:18%;' valign='top'>Legal Entity (Properties) FEIN</td>");
        sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
        sbHtml.Append("<td style='width:30%;' valign='top'> " + objLocation.LE_Properties_FEIN + " </td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Address</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objLocation.Address_1 + " </td>");
        //sbHtml.Append("<td  valign='top'>Federal ID#</td>");
        //sbHtml.Append("<td  valign='top'> :</td>");
        //sbHtml.Append("<td  valign='top'> " + objRE.Federal_Id + " </td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>City</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objLocation.City + " </td>");
        sbHtml.Append("<td  valign='top'>Lease Type</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + (objRE.FK_LU_Lease_Type != null ? new LU_Lease_Type(Convert.ToDecimal(objRE.FK_LU_Lease_Type)).Fld_Desc : "") + " </td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>State</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + (objLocation.State != "" ? new State(Convert.ToDecimal(objLocation.State)).FLD_state : "") + " </td>");
        sbHtml.Append("<td  valign='top'>Landlord</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objRE.Landlord + " </td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Zip</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objLocation.Zip_Code + " </td>");
        sbHtml.Append("<td  valign='top'>Address</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objRE.Landlord_Mailing_Address1 + " </td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Telephone</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objLocation.Dealership_Telephone + " </td>");
        sbHtml.Append("<td  valign='top'>City</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objRE.Landlord_Mailing_City + " </td>");
        sbHtml.Append("</tr>");


        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>County</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objLocation.County + " </td>");
        sbHtml.Append("<td  valign='top'>State</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + (objRE.PK_Landlord_Location_State != null ? new State(Convert.ToDecimal(objRE.PK_Landlord_Location_State)).FLD_state : "") + " </td>");
        sbHtml.Append("</tr>");


        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Region</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objLocation.Region + " </td>");
        sbHtml.Append("<td  valign='top'>Zip</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objRE.Landlord_Mailing_Zip_Code + " </td>");
        sbHtml.Append("</tr>");


        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Tax Parcel #</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objRE.Tax_Parcel_Number + " </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("</tr>");

        sbHtml.Append(GetBlankRow(10));

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>LCD</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + clsGeneral.FormatDBNullDateToDisplay(objRE.Lease_Commencement_Date) + " </td>");
        sbHtml.Append("<td  valign='top'>Project Type</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + (objRE.FK_LU_Project_Type != null ? new LU_Project_Type(Convert.ToDecimal(objRE.FK_LU_Project_Type)).Fld_Desc : "") + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>LED</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + clsGeneral.FormatDBNullDateToDisplay(objRE.Lease_Expiration_Date) + " </td>");
        sbHtml.Append("<td  valign='top'>Date Acquired</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(objRE.Date_Acquired) + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Term</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objRE.Lease_Term_Months + " </td>");
        sbHtml.Append("<td  valign='top'>Date Sold</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(objRE.Date_Sold) + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  colspan='6'><table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
        sbHtml.Append("<td style='width:18%;' valign='top'>Renewals</td>");
        sbHtml.Append("<td style='width:2%;'  valign='top'> :</td>");
        sbHtml.Append("<td style='width:30%;' valign='top'> " + objRE.Renewals + " </td>");
        sbHtml.Append("<td style='width:18%;' valign='top'>Year Built</td>");
        sbHtml.Append("<td style='width:2%;'  valign='top'> :</td>");
        sbHtml.Append("<td style='width:30%;' valign='top'>" + objRE.Year_Built + "</td>");
        sbHtml.Append("</td></tr></table></td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Reminder Date</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + clsGeneral.FormatDBNullDateToDisplay(objRE.Reminder_Date) + " </td>");
        sbHtml.Append("<td  valign='top'>Year Remodeled</td>");
        sbHtml.Append("<td valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objRE.Year_Remodeled + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>LL Notification Date</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + clsGeneral.FormatDBNullDateToDisplay(objRE.Landlord_Notification_Date) + " </td>");
        sbHtml.Append("<td  valign='top'>Regional Vice President</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objRE.Regional_Vice_President + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>&nbsp;</td>");
        sbHtml.Append("<td  valign='top'>&nbsp;</td>");
        sbHtml.Append("<td  valign='top'>&nbsp; </td>");
        sbHtml.Append("<td  valign='top'>Regional Controller</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objRE.Regional_Controller + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Vacate Date</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + clsGeneral.FormatDBNullDateToDisplay(objRE.Vacate_Date) + " </td>");
        sbHtml.Append("<td  valign='top'>General Manager</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objRE.General_Manager + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'>Controller</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objRE.Controller + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'>Loss Control Manager</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objRE.Loss_Control_Manager + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'>Total Acres</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objRE.Total_Acres + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'>Number of Buildings</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objRE.Number_of_Buildings + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'>Total GLA</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objRE.Total_Gross_Leaseable_Area + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'>Land Value</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> $ " + clsGeneral.GetStringValue(objRE.Land_Value) + "</td>");
        sbHtml.Append("</tr>");

        #endregion

        #region "Rent"

        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append(GetHeaderRow("Rent"));
        sbHtml.Append(GetBlankRow(8));

        RE_Rent objR = new RE_Rent(_PK_RE_Information, true);

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Responsible Party</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'>" + objR.Responsible_Party + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Lease Commencement Date </td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(objRE.Lease_Commencement_Date) + "</td>");
        sbHtml.Append("<td  valign='top'>Lease Term in Months </td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + objRE.Lease_Term_Months + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Lease Expiration Date </td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(objRE.Lease_Expiration_Date) + "</td>");
        sbHtml.Append("<td  valign='top'>Prior Lease Commencement Date</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + clsGeneral.FormatDBNullDateToDisplay(objRE.Prior_Lease_Commencement_Date) + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Cancel Options </td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'> " + objR.Cancel_Options + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Renewal Options </td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'> " + objR.Renew_Options + "</td>");
        sbHtml.Append("</tr>");

        //sbHtml.Append("<tr>");
        //sbHtml.Append("<td  valign='top'>Options</td>");
        //sbHtml.Append("<td  valign='top'> :</td>");
        //sbHtml.Append("<td  valign='top' colspan='4'><b>Cancel Options</b> -" + objR.Cancel_Options + Environment.NewLine + ",&nbsp;<b>Renew options</b> -" + objR.Renew_Options + "</td>");
        //sbHtml.Append("</tr>");


        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Notification Due Date</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'> " + clsGeneral.FormatDBNullDateToDisplay(objR.Notification_Due_Date) + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Subtenant Annual Rent</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'> $ " + clsGeneral.GetStringValue(objR.Subtenant_Base_Rent) + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Subtenant Monthly Rent</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'> $ " + clsGeneral.GetStringValue(objR.Subtenant_Monthly_Rent) + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Rent Detail</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'>  " + objR.Rent_Details + "</td>");
        sbHtml.Append("</tr>");


        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Rent Adjustment</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'>  " + objR.Rent_Adjustments + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Escalation</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'> " + (objR.FK_LU_Escalation != null ? new LU_Escalation(Convert.ToDecimal(objR.FK_LU_Escalation)).Fld_Desc : "") + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Percentage Rate</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top' colspan='4'> " + (objR.Percentage_Rate != null ? objR.Percentage_Rate.ToString() : "") + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Inc. Amount</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'> " + clsGeneral.GetStringValue(objR.Increase) + "</td>");
        sbHtml.Append("</tr>");

        #endregion

        sbHtml.Append(GetBlankRow(8));

        #region "Rent TRS"

        sbHtml.Append("<tr>");
        sbHtml.Append("<td colspan='6' valign='top'>");


        if (objR.PK_RE_Rent != null)
        {
            // get datatable for RE_Subtenant_TRS records
            DataTable dtRentTRS = RE_Rent_TRS.SelectByFK(Convert.ToDecimal(objR.PK_RE_Rent.ToString())).Tables[0];
            GenerateTRS(sbHtml, dtRentTRS);
        }
        sbHtml.Append("</td></tr>");
        #endregion

        sbHtml.Append(GetBlankRow(8));

        #region "Rent ORS"

        sbHtml.Append("<tr>");
        sbHtml.Append("<td colspan='6' valign='top'>");

        if (objR.PK_RE_Rent != null)
        {
            DataTable dtRentRRS = RE_Rent_RRS.SelectByFK(Convert.ToDecimal(objR.PK_RE_Rent.ToString())).Tables[0];
            // get datatable for RE_Subtenant_TRS records
            GenerateORS(sbHtml, dtRentRRS);
        }
        sbHtml.Append("</td></tr>");
        #endregion


        #region "Subtenant Information"

        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append(GetHeaderRow("Subtenant Information"));
        sbHtml.Append(GetBlankRow(8));

        //RE_Subtenant objSubtenant = new RE_Subtenant(_PK_RE_Information);
        DataTable dtSubtenant = RE_Subtenant.SelectByFK(_PK_RE_Information).Tables[0];

        for (int i = 0; i < dtSubtenant.Rows.Count; i++)
        {
            sbHtml.Append("<tr align='left'> <td style='order-bottom-color: Black; font-weight:bold; color: #548DD4;' colspan='6'> <span style='color: #548DA4;text-decoration: underline;'>Subtenant Information : " + (i + 1) + " </span> </td> </tr>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'>Subtenant DBA</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'>" + Convert.ToString(dtSubtenant.Rows[i]["Subtenant_DBA"]) + "</td>");
            sbHtml.Append("<td  valign='top'>LCD</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(objRE.Lease_Commencement_Date) + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'>Address</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'>" + Convert.ToString(dtSubtenant.Rows[i]["Subtenant_Mailing_Address1"]) + "</td>");
            sbHtml.Append("<td  valign='top'>LED</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(objRE.Lease_Expiration_Date) + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'>City</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'>" + Convert.ToString(dtSubtenant.Rows[i]["Subtenant_Mailing_City"]) + "</td>");
            sbHtml.Append("<td  valign='top'>Term In Months</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'> " + objRE.Lease_Term_Months + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'>State</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'>" + (!string.IsNullOrEmpty(Convert.ToString(dtSubtenant.Rows[i]["PK_Subtenant_Mailing_State"])) ? new State(Convert.ToDecimal(dtSubtenant.Rows[i]["PK_Subtenant_Mailing_State"])).FLD_state : "") + "</td>");
            sbHtml.Append("<td  valign='top'>Options</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'><b>Cancel Options</b> -" + Convert.ToString(dtSubtenant.Rows[i]["Cancel_Options"]) + Environment.NewLine + ",&nbsp;<b>Renew options</b> -" + Convert.ToString(dtSubtenant.Rows[i]["Renew_Options"]) + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'>Zip</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'>" + Convert.ToString(dtSubtenant.Rows[i]["Subtenant_Mailing_Zip_Code"]) + "</td>");
            sbHtml.Append("<td  valign='top'>Options Notification</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'> " + Convert.ToString(dtSubtenant.Rows[i]["Option_Notification"]) + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'>Telephone</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'>" + Convert.ToString(dtSubtenant.Rows[i]["Subtenant_Telephone"]) + "</td>");
            sbHtml.Append("<td  valign='top'>Notification Due Date</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'> " + clsGeneral.FormatDBNullDateToDisplay(Convert.ToString(dtSubtenant.Rows[i]["Notification_Due_Date"])) + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'>Subtenant Annual Rent</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'> $ " + clsGeneral.GetStringValue(dtSubtenant.Rows[i]["Subtenant_Base_Rent"]) + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'>Subtenant Monthly Rent</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'> $ " + clsGeneral.GetStringValue(dtSubtenant.Rows[i]["Subtenant_Monthly_Rent"]) + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'>Security Deposit</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'> $ " + clsGeneral.GetStringValue(dtSubtenant.Rows[i]["Security_Deposit"]) + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'>Escalation</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'> " + (!string.IsNullOrEmpty(Convert.ToString(dtSubtenant.Rows[i]["FK_LU_Escalation"])) ? new LU_Escalation(Convert.ToDecimal(dtSubtenant.Rows[i]["FK_LU_Escalation"])).Fld_Desc : "") + "</td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'></td>");
            sbHtml.Append("<td  valign='top'>Inc. Rate</td>");
            sbHtml.Append("<td  valign='top'> :</td>");
            sbHtml.Append("<td  valign='top'> " + clsGeneral.GetStringValue(dtSubtenant.Rows[i]["Increase"]) + "</td>");
            sbHtml.Append("</tr>");

            //Subtenant Information ends here

            sbHtml.Append(GetBlankRow(8));

            #region "Subtenant TRS"

            sbHtml.Append("<tr>");
            sbHtml.Append("<td colspan='6' valign='top'>");

            if (!string.IsNullOrEmpty(Convert.ToString(dtSubtenant.Rows[i]["PK_RE_Subtenant"])))
            {
                // get datatable for RE_Subtenant_TRS records
                DataTable dtSubtenantTRS = RE_Subtenant_TRS.SelectByFK(Convert.ToDecimal(dtSubtenant.Rows[i]["PK_RE_Subtenant"])).Tables[0];
                GenerateTRS(sbHtml, dtSubtenantTRS);
            }
            sbHtml.Append("</td></tr>");
            #endregion

            sbHtml.Append(GetBlankRow(8));

            #region "Subtenant ORS"

            sbHtml.Append("<tr>");
            sbHtml.Append("<td colspan='6' valign='top'>");

            if (!string.IsNullOrEmpty(Convert.ToString(dtSubtenant.Rows[i]["PK_RE_Subtenant"])))
            {
                // get datatable for RE_Subtenant_TRS records
                DataTable dtSubtenantORS = RE_SubTenant_ORS.SelectByFK(Convert.ToDecimal(dtSubtenant.Rows[i]["PK_RE_Subtenant"])).Tables[0];
                GenerateORS(sbHtml, dtSubtenantORS);
            }
            sbHtml.Append("</td></tr>");

            #endregion
        }
        #endregion

        #region "Notices"

        RE_Notices objNotice = new RE_Notices(_PK_RE_Information, true);

        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append(GetHeaderRow("Notices"));
        sbHtml.Append(GetBlankRow(8));

        #region "Landlord"

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'><b>If to Landlord :</b></td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'><b>With a Copy to :<b/></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Company Name</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Company + "</td>");
        sbHtml.Append("<td  valign='top' >Company Name</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Copy_Company + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Contact</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Contact + "</td>");
        sbHtml.Append("<td  valign='top' >Contact</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Copy_Contact + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Address 1</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Address1 + "</td>");
        sbHtml.Append("<td  valign='top' >Address 1</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Copy_Address1 + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Address 2</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Address2 + "</td>");
        sbHtml.Append("<td  valign='top' >Address 2</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Copy_Address2 + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >City</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_City + "</td>");
        sbHtml.Append("<td  valign='top' >City</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Copy_City + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >State</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + (objNotice.FK_State_Landlord != null ? new State(Convert.ToDecimal(objNotice.FK_State_Landlord)).FLD_state : "") + "</td>");
        sbHtml.Append("<td  valign='top' >State</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + (objNotice.FK_State_Landlord_Copy != null ? new State(Convert.ToDecimal(objNotice.FK_State_Landlord_Copy)).FLD_state : "") + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Zip</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Zip_Code + "</td>");
        sbHtml.Append("<td  valign='top' >Zip</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Copy_Zip_Code + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Telephone</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Telephone + "</td>");
        sbHtml.Append("<td  valign='top' >Telephone</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Copy_Telephone + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Facsimile</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Facsimile + "</td>");
        sbHtml.Append("<td  valign='top' >Facsimile</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Copy_Facsimile + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >E-Mail</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Email + "</td>");
        sbHtml.Append("<td  valign='top' >E-Mail</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Landlord_Copy_Email + "</td>");
        sbHtml.Append("</tr>");

        #endregion

        sbHtml.Append(GetBlankRow(8));

        #region "Tenant"

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'><b>If to Tenant :</b></td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'><b>With a Copy to :<b/></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Company Name</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Company + "</td>");
        sbHtml.Append("<td  valign='top' >Company Name</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Copy_Company + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Contact</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Contact + "</td>");
        sbHtml.Append("<td  valign='top' >Contact</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Copy_Contact + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Address 1</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Address1 + "</td>");
        sbHtml.Append("<td  valign='top' >Address 1</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Copy_Address1 + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Address 2</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Address2 + "</td>");
        sbHtml.Append("<td  valign='top' >Address 2</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Copy_Address2 + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >City</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_City + "</td>");
        sbHtml.Append("<td  valign='top' >City</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Copy_City + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >State</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + (objNotice.FK_State_Tenant != null ? new State(Convert.ToDecimal(objNotice.FK_State_Tenant)).FLD_state : "") + "</td>");
        sbHtml.Append("<td  valign='top' >State</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + (objNotice.FK_State_Tenant_Copy != null ? new State(Convert.ToDecimal(objNotice.FK_State_Tenant_Copy)).FLD_state : "") + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Zip</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Zip_Code + "</td>");
        sbHtml.Append("<td  valign='top' >Zip</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Copy_Zip_Code + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Telephone</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Telephone + "</td>");
        sbHtml.Append("<td  valign='top' >Telephone</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Copy_Telephone + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Facsimile</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Facsimile + "</td>");
        sbHtml.Append("<td  valign='top' >Facsimile</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Copy_Facsimile + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >E-Mail</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Email + "</td>");
        sbHtml.Append("<td  valign='top' >E-Mail</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Tenant_Copy_Email + "</td>");
        sbHtml.Append("</tr>");

        #endregion

        sbHtml.Append(GetBlankRow(8));

        #region "SubTenant"

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'><b>If to Subtenant :</b></td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("<td  valign='top'><b>With a Copy to :</b></td>");
        sbHtml.Append("<td  valign='top'> </td>");
        sbHtml.Append("<td  valign='top'></td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Company Name</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Company + "</td>");
        sbHtml.Append("<td  valign='top' >Company Name</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Copy_Company + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Contact</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Contact + "</td>");
        sbHtml.Append("<td  valign='top' >Contact</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Copy_Contact + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top'>Address 1</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Address1 + "</td>");
        sbHtml.Append("<td  valign='top' >Address 1</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Copy_Address1 + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Address 2</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Address2 + "</td>");
        sbHtml.Append("<td  valign='top' >Address 2</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Copy_Address2 + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >City</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_City + "</td>");
        sbHtml.Append("<td  valign='top' >City</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Copy_City + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >State</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + (objNotice.FK_State_Subtenant != null ? new State(Convert.ToDecimal(objNotice.FK_State_Subtenant)).FLD_state : "") + "</td>");
        sbHtml.Append("<td  valign='top' >State</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + (objNotice.FK_State_Subtenant_Copy != null ? new State(Convert.ToDecimal(objNotice.FK_State_Subtenant_Copy)).FLD_state : "") + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Zip</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Zip_Code + "</td>");
        sbHtml.Append("<td  valign='top' >Zip</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Copy_Zip_Code + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Telephone</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Telephone + "</td>");
        sbHtml.Append("<td  valign='top' >Telephone</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Copy_Telephone + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >Facsimile</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Facsimile + "</td>");
        sbHtml.Append("<td  valign='top' >Facsimile</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Copy_Facsimile + "</td>");
        sbHtml.Append("</tr>");

        sbHtml.Append("<tr>");
        sbHtml.Append("<td  valign='top' >E-Mail</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Email + "</td>");
        sbHtml.Append("<td  valign='top' >E-Mail</td>");
        sbHtml.Append("<td  valign='top'> :</td>");
        sbHtml.Append("<td  valign='top'>" + objNotice.Subtenant_Copy_Email + "</td>");
        sbHtml.Append("</tr>");

        #endregion

        #endregion

        #region "Repair & Maintainence"
        DataTable dtRepair = RE_Repair_And_Maintenance.SelectByFK(_PK_RE_Information).Tables[0];
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append(GetHeaderRow("Repair/Maintenance"));
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("<tr><td colspan='6'>");
        sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
        sbHtml.Append("<tr valign='top' align='center'>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>HVAC Repairs</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>HVAC Capital</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>Roof Repairs</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>Roof Capital</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>Other Repairs</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > <b>Maintenance Notes</td>");
        sbHtml.Append("</tr>");

        for (int i = 0; i < dtRepair.Rows.Count; i++)
        {
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%;' >" + Convert.ToString(dtRepair.Rows[i]["FK_LU_Responsibilie_Party_HVAC_Repairs"]) + " </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + Convert.ToString(dtRepair.Rows[i]["FK_LU_Responsibilie_Party_HVAC_Capital"]) + " </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + Convert.ToString(dtRepair.Rows[i]["FK_LU_Responsibilie_Party_Roof_Repairs"]) + "</td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + Convert.ToString(dtRepair.Rows[i]["FK_LU_Responsibilie_Party_Roof_Capital"]) + "</td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + Convert.ToString(dtRepair.Rows[i]["FK_LU_Responsibilie_Party_Other_Repairs"]) + "</td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > " + Convert.ToString(dtRepair.Rows[i]["Maintenance_Notes"]) + "</td>");
            sbHtml.Append("</tr>");
        }
        sbHtml.Append(GetBlankRow(8));
        
        sbHtml.Append("</table>");
        sbHtml.Append("</td></tr>");
        #endregion

        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// get Header table row with bottom border and font color
    /// </summary>
    /// <param name="Content"></param>
    /// <returns></returns>
    private string GetHeaderRow(string Content)
    {
        return string.Concat("<tr align='left'> <td style='order-bottom-color: Black; border-bottom-style: solid; border-bottom-width: thin;color: #548DD4;' colspan='6'> <span style='color: #548DD4;'>" + Content + " </span> </td> </tr>");
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
    /// General method to generate html grid for TRS
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtIncentive"></param>
    /// <param name="strHeader"></param>
    private void GenerateTRS(System.Text.StringBuilder sbHtml, DataTable dtTRS)
    {
        sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
        sbHtml.Append("<tr valign='top' align='center'>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > <b>Term Rent Schedule</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>From</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>To</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > <b>Number of Month</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' > <b>Monthly Rent</td>");
        sbHtml.Append("</tr>");

        // loop for print all attachment detail
        for (int i = 0; i < dtTRS.Rows.Count; i++)
        {
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%; align:left;' >&nbsp; Year " + Convert.ToString(dtTRS.Rows[i]["Year"]) + " </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + clsGeneral.FormatDBNullDateToDisplay(dtTRS.Rows[i]["From_Date"]) + " </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + clsGeneral.FormatDBNullDateToDisplay(dtTRS.Rows[i]["To_Date"]) + "</td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > " + clsGeneral.GetStringValue(dtTRS.Rows[i]["Months"]) + "</td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%;align:right;' > " + clsGeneral.GetStringValue(dtTRS.Rows[i]["Monthly_Rent"]) + "&nbsp;</td>");
            sbHtml.Append("</tr>");
        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// General method to generate html grid for ORS
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtIncentive"></param>
    /// <param name="strHeader"></param>
    private void GenerateORS(System.Text.StringBuilder sbHtml, DataTable dtORS)
    {
        sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
        sbHtml.Append("<tr valign='top' align='center'>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > <b>Option Rent Schedule</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>From</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>To</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > <b>Number of Month</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' > <b>Monthly Rent</td>");
        sbHtml.Append("</tr>");

        // loop for print all attachment detail
        for (int i = 0; i < dtORS.Rows.Count; i++)
        {
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%;align:left;' >&nbsp; Option " + Convert.ToString(dtORS.Rows[i]["Option_Period"]) + " </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + clsGeneral.FormatDBNullDateToDisplay(dtORS.Rows[i]["From_Date"]) + " </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + clsGeneral.FormatDBNullDateToDisplay(dtORS.Rows[i]["To_Date"]) + "</td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > " + clsGeneral.GetStringValue(dtORS.Rows[i]["Months"]) + "</td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%;align:right;' > " + clsGeneral.GetStringValue(dtORS.Rows[i]["Monthly_Rent"]) + "&nbsp;</td>");
            sbHtml.Append("</tr>");
        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    /// <summary>
    /// General method to generate html grid for incentive
    /// </summary>
    /// <param name="sbHtml"></param>
    /// <param name="dtIncentive"></param>
    /// <param name="strHeader"></param>
    private void GenerateRepairMaintenance(System.Text.StringBuilder sbHtml, DataTable dtRepair)
    {
        sbHtml.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;' >");
        sbHtml.Append("<tr valign='top' align='Left'>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > <b>Type Of Repair</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>Date PCA Ordered</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > <b>Date PCA Conducted</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > <b>PCA Conducted By</td>");
        sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' > <b>Contractor</td>");
        sbHtml.Append("</tr>");

        // loop for print all attachment detail
        for (int i = 0; i < dtRepair.Rows.Count; i++)
        {
            sbHtml.Append("<tr valign='top' align='Left'>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%;' >" + Convert.ToString(dtRepair.Rows[i]["Repair_Type"]) + " </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + clsGeneral.FormatDBNullDateToDisplay(dtRepair.Rows[i]["Date_PCA_Ordered"]) + " </td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:15%' > " + clsGeneral.FormatDBNullDateToDisplay(dtRepair.Rows[i]["Date_PCA_Conducted"]) + "</td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:25%' > " + Convert.ToString(dtRepair.Rows[i]["PCA_Conducted_By"]) + "</td>");
            sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%;' > " + Convert.ToString(dtRepair.Rows[i]["Contractor"]) + "&nbsp;</td>");
            sbHtml.Append("</tr>");
        }
        sbHtml.Append(GetBlankRow(8));
        sbHtml.Append("</table>");
    }

    #endregion
}
