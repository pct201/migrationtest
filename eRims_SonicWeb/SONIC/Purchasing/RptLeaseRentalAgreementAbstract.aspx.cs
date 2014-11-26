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
using Aspose.Words;

/**************************************************************************************************************************************
 * File Name:		RptLeaseRentalAgreementAbstract.aspx
 *								  
 * Description:		This page is used for generate abstract report for Lease/Rental Agrrement in Word document using aspose.word tool. 
 * 
 **************************************************************************************************************************************/

public partial class SONIC_Purchasing_RptLeaseRentalAgreementAbstract : System.Web.UI.Page
{
    #region "Declaration"

    /// <summary>
    /// PK for Purchasing_Service_Contract table
    /// </summary>
    public decimal PK_Purchasing_LR_Agreement
    {
        get { return clsGeneral.IsNull(Request.QueryString["id"]) ? 0 : Convert.ToDecimal(Request.QueryString["id"]); }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
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
        builder.PageSetup.RightMargin = 50;
        builder.PageSetup.LeftMargin = 50;
        builder.Font.Size = 11;
        builder.Font.Bold = false;
        builder.Font.Color = System.Drawing.Color.Black;
        builder.Font.Name = "Calibri";
        builder.InsertParagraph();
        GenerateHTML(sbHtml);
        builder.InsertHtml(sbHtml.ToString());
        //builder.Write(litLetter.Text);
        //doc.MailMerge.Execute(dt);
        //Don't need merge fields in the document anymore.
        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;
        doc.MailMerge.DeleteFields();

        //doc.Save("LeaseRentalAgreementAbstract.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        doc.Save(Response, "LeaseRentalAgreementAbstract.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        Response.End();
    }

    /// <summary>
    /// function use for generate html output for report
    /// </summary>
    /// <param name="sbHtml"></param>
    private void GenerateHTML(System.Text.StringBuilder sbHtml)
    {
        //ERIMS.DAL.PurchasingServiceContract.
        DataSet dsReport = Purchasing_LR_Agreement.GetLR_AgreementAbstract(Convert.ToDecimal(Request.QueryString["ID"]));

        sbHtml.Append("<table width='100%' align='center'>");
        sbHtml.Append("<tr><td width='100%' align='center'><b>Sonic Automotive – Lease/Rental Agreement Abstract<b></td></tr>");
        sbHtml.Append("</table>");

        if (dsReport.Tables[0].Rows.Count > 0)
        {
            DataRow drRow = dsReport.Tables[0].Rows[0];

            #region "Lease/Rental Agreement"

            sbHtml.Append("<table width='100%'>");
            sbHtml.Append(GetHeaderRow("Lease/Rental Agreement"));

            sbHtml.Append("<tr>");
            sbHtml.Append("<td style='width:17%;' valign='top'>Supplier</td>");
            sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
            sbHtml.Append("<td style='width:31%;' valign='top'> " + drRow["Supplier"].ToString() + " </td>");
            sbHtml.Append("<td style='width:18%;' valign='top'>Equipment Type</td>");
            sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
            sbHtml.Append("<td style='width:30%;' valign='top'> " + drRow["FK_LU_Equipment_Type"].ToString() + " </td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr valign='top'>");
            sbHtml.Append("<td>Payment Terms</td>");
            sbHtml.Append("<td> :</td>");
            sbHtml.Append("<td> " + drRow["Payment_Terms"].ToString() + " </td>");
            sbHtml.Append("<td>Buyout</td>");
            sbHtml.Append("<td> :</td>");
            sbHtml.Append("<td> $" + clsGeneral.GetStringValue(drRow["Buyout"]) + " </td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>Late Fee</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top'> " + drRow["Late_Fee"].ToString() + " </td>");
            sbHtml.Append("<td valign='top'>Lease/Rental Type</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top'> " + drRow["FK_LU_LR_Type"].ToString() + " </td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>Leased Amount</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top'> $" + clsGeneral.GetStringValue(drRow["Leased_Amount"]) + " </td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>Lease Rate </td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top'> " + drRow["Lease_Rate"] + " </td>");
            //sbHtml.Append("<td valign='top'>Lease Rate Time Period</td>");
            //sbHtml.Append("<td valign='top'> :</td>");
            //sbHtml.Append("<td valign='top'> " + drRow["Lease_Rate_Time_Period"].ToString() + " </td>");
            sbHtml.Append("</tr>");

            sbHtml.Append(GetBlankRow(8));
            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>End of Lease Options</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top' colspan='4'> " + drRow["End_Of_Lease_Options"] + " </td>");
            sbHtml.Append("</tr>");
            sbHtml.Append(GetBlankRow(8));
            sbHtml.Append("<tr valign='top'>");
            sbHtml.Append("<td>Start Date</td>");
            sbHtml.Append("<td> :</td>");
            sbHtml.Append("<td> " + clsGeneral.FormatDBNullDateToDisplay(drRow["Start_Date"]) + " </td>");
            sbHtml.Append("<td>End Date</td>");
            sbHtml.Append("<td> :</td>");
            sbHtml.Append("<td> " + clsGeneral.FormatDBNullDateToDisplay(drRow["End_Date"]) + " </td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>Term in Months</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top'> " + string.Format("{0:#,0.##}", Convert.ToDecimal(drRow["Term_In_Months"])) + " </td>");
            sbHtml.Append("<td valign='top'>Notification Date</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top'> " + clsGeneral.FormatDBNullDateToDisplay(drRow["Notification_Date"]) + " </td>");

            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>Monthly Cost</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top'> $" + clsGeneral.GetStringValue(drRow["Monthly_Cost"]) + " </td>");
            sbHtml.Append("<td valign='top'>Annual Cost</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top'> $" + clsGeneral.GetStringValue(drRow["Annual_Cost"]) + " </td>");
            sbHtml.Append("</tr>");

            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>Total Committed</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top'> $" + clsGeneral.GetStringValue(drRow["Total_Committed"]) + " </td>");
            sbHtml.Append("</tr>");

            //sbHtml.Append(GetBlankRow(8));
            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td valign='top'>Renewal Terms</td>");
            //sbHtml.Append("<td valign='top'> :</td>");
            //sbHtml.Append("<td valign='top' colspan='4'> " + drRow["Renewal_Terms"].ToString() + " </td>");
            //sbHtml.Append("</tr>");
            //sbHtml.Append(GetBlankRow(8));
            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td valign='top'>Notification Terms</td>");
            //sbHtml.Append("<td valign='top'> :</td>");
            //sbHtml.Append("<td valign='top' colspan='4'> " + drRow["Notification_Terms"].ToString() + " </td>");
            //sbHtml.Append("</tr>");
            //sbHtml.Append(GetBlankRow(8));
            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td valign='top'>Applicable Dealers</td>");
            //sbHtml.Append("<td valign='top'> :</td>");
            //sbHtml.Append("<td valign='top' colspan='4'> " + drRow["Applicable_Dealers"].ToString() + " </td>");
            //sbHtml.Append("</tr>");
            //sbHtml.Append(GetBlankRow(8));
            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>Dealership Department</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top' > " + drRow["FK_LU_Dealership_Department"].ToString() + " </td>");
            sbHtml.Append("<td valign='top'>Is COI Needed?</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            if (Convert.ToString(drRow["COI_Needed"]).ToUpper() != "Y")
                sbHtml.Append("<td valign='top'> No </td>");
            else
                sbHtml.Append("<td valign='top'> Yes</td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>Dealership</td>");
            sbHtml.Append("<td valign='top'> :</td>");
            sbHtml.Append("<td valign='top' colspan='4'> " + drRow["FK_LU_Location"].ToString() + " </td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("</table>");

            #endregion

            //#region "Dealership Department"

            //sbHtml.Append("<br /><table width='50%'>");
            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td valign='top'>Dealership Department Grid : </td>");
            //sbHtml.Append("</tr>");
            //sbHtml.Append("</table>");

            //DataTable dtDepartment = Purchasing_SC_Department.SelectAllByServiceContract(Convert.ToInt32(PK_Purchasing_Service_Contract), string.Empty).Tables[0];

            //sbHtml.Append("<table width='50%' cellspacing='0' style='padding-bottom:5px;' >");
            //sbHtml.Append("<tr valign='top' align='center'>");
            //sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%'><b> Department</td>");
            //sbHtml.Append("</tr>");

            //for (int i = 0; i < dtDepartment.Rows.Count; i++)
            //    sbHtml.Append("<tr><td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:100%;' > " + dtDepartment.Rows[i]["Fld_Desc"].ToString() + " </td></tr>");

            //sbHtml.Append("</table>");
            //#endregion
            //#region "Dealership"

            //sbHtml.Append("<br /><table width='80%'>");
            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td valign='top'>Dealership Grid : </td>");
            //sbHtml.Append("</tr>");
            //sbHtml.Append("</table>");

            //DataTable dtDealership = Purchasing_SC_Dealer.SelectByServiceContract(Convert.ToInt32(PK_Purchasing_Service_Contract), string.Empty).Tables[0];

            //sbHtml.Append("<table width='80%' cellspacing='0' style='padding-bottom:5px;'>");
            //sbHtml.Append("<tr valign='top' align='center'>");
            //sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'><b> Dealer Name</td>");
            //sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'><b> Address</td>");
            //sbHtml.Append("</tr>");

            //for (int i = 0; i < dtDealership.Rows.Count; i++)
            //{
            //    sbHtml.Append("<tr valign='top'><td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'> " + dtDealership.Rows[i]["legal_entity"].ToString() + " </td>");
            //    sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'> " + dtDealership.Rows[i]["Address_1"].ToString() + " </td></tr>");
            //}

            //sbHtml.Append("</table>");

            //#endregion

            #region "Assest"

            sbHtml.Append("<br /><table width='100%'>");
            sbHtml.Append("<tr>");
            sbHtml.Append("<td valign='top'>Applicable Assets Grid: </td>");
            sbHtml.Append("</tr>");
            sbHtml.Append("</table>");

            DataTable dtAssest = Purchasing_LR_Asset.SelectByFK_LR(PK_Purchasing_LR_Agreement, string.Empty).Tables[0];

            sbHtml.Append("<table width='70%' cellspacing='0' style='padding-bottom:5px;'>");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'> <b>Asset Type</td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'> <b>Manufacturer</td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'> <b>Supplier</td>");
            sbHtml.Append("</tr>");

            for (int i = 0; i < dtAssest.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top'><td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'> " + dtAssest.Rows[i]["Type"].ToString() + " </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'> " + dtAssest.Rows[i]["Fld_Desc"].ToString() + " </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;'> " + dtAssest.Rows[i]["Supplier"].ToString() + " </td></tr>");
            }

            sbHtml.Append("</table></br>");
            #endregion

            //#region "Contact Information"

            //sbHtml.Append("<br /><table width='100%'>");
            //sbHtml.Append(GetHeaderRow("Contact Information"));

            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td colspan='6'>Supplier</td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td style='width:17%;' valign='top'>Contact Name</td>");
            //sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
            //sbHtml.Append("<td style='width:31%;' valign='top'> " + drRow["Supplier_Contact_Name"].ToString() + " </td>");
            //sbHtml.Append("<td style='width:17%;' valign='top'>Title</td>");
            //sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
            //sbHtml.Append("<td style='width:31%;' valign='top'> " + drRow["Supplier_Title"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr valign='top'>");
            //sbHtml.Append("<td>Address 1</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Supplier_Address_1"].ToString() + " </td>");
            //sbHtml.Append("<td>Address 2</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Supplier_Address_2"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr valign='top'>");
            //sbHtml.Append("<td>City</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Supplier_City"].ToString() + " </td>");
            //sbHtml.Append("<td>State</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["FK_State_Supplier"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td>Zip Code</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Supplier_ZIP_Code"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr valign='top'>");
            //sbHtml.Append("<td>Work Telephone</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Supplier_Work_Telephone"].ToString() + " </td>");
            //sbHtml.Append("<td>Cell Telephone</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Supplier_Cell_Telephone"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr valign='top'>");
            //sbHtml.Append("<td>Fax</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Supplier_Facsimile"].ToString() + " </td>");
            //sbHtml.Append("<td>E-Mail</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Supplier_Email"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td colspan='6'></td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr >");
            //sbHtml.Append("<td valign='top'>Notes</td>");
            //sbHtml.Append("<td valign='top'> :</td>");
            //sbHtml.Append("<td valign='top' colspan='4'> " + drRow["Supplier_Notes"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td colspan='6'></td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td colspan='6'>Sonic</td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td style='width:17%;' valign='top'>Contact Name</td>");
            //sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
            //sbHtml.Append("<td style='width:31%;' valign='top'> " + drRow["Sonic_Contact_Name"].ToString() + " </td>");
            //sbHtml.Append("<td style='width:17%;' valign='top'>Title</td>");
            //sbHtml.Append("<td style='width:2%;' valign='top'> :</td>");
            //sbHtml.Append("<td style='width:31%;' valign='top'> " + drRow["Sonic_Title"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr valign='top'>");
            //sbHtml.Append("<td>Address 1</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Sonic_Address_1"].ToString() + " </td>");
            //sbHtml.Append("<td>Address 2</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Sonic_Address_2"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr valign='top'>");
            //sbHtml.Append("<td>City</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Sonic_City"].ToString() + " </td>");
            //sbHtml.Append("<td>State</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["FK_State_Sonic"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td>Zip Code</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Sonic_ZIP_Code"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr valign='top'>");
            //sbHtml.Append("<td>Work Telephone</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Sonic_Work_Telephone"].ToString() + " </td>");
            //sbHtml.Append("<td>Cell Telephone</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Sonic_Cell_Telephone"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr valign='top'>");
            //sbHtml.Append("<td>Fax</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Sonic_Facsimile"].ToString() + " </td>");
            //sbHtml.Append("<td>E-Mail</td>");
            //sbHtml.Append("<td> :</td>");
            //sbHtml.Append("<td> " + drRow["Sonic_Email"].ToString() + " </td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr>");
            //sbHtml.Append("<td colspan='6'></td>");
            //sbHtml.Append("</tr>");

            //sbHtml.Append("<tr >");
            //sbHtml.Append("<td valign='top'>Notes</td>");
            //sbHtml.Append("<td valign='top'> :</td>");
            //sbHtml.Append("<td valign='top' colspan='4'> " + drRow["Sonic_Notes"].ToString() + " </td>");
            //sbHtml.Append("</tr>");
            //sbHtml.Append("</table>");
            //#endregion

            #region "Lease/Rental Agreement Notes"

            sbHtml.Append("<br /><table width='100%'>");
            sbHtml.Append(GetHeaderRow("Lease/Rental Agreement Notes", "1"));
            sbHtml.Append("</table><br />");

            DataTable dtNotes = Purchasing_LR_Note.SelectByFK_LR(PK_Purchasing_LR_Agreement).Tables[0];

            sbHtml.Append("<table width='100%' cellspacing='0' style='padding-bottom:5px;'>");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%;'> <b>Note Date</td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:80%;'> <b>Note Text</td>");
            sbHtml.Append("</tr>");

            for (int i = 0; i < dtNotes.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top'><td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%;'> " + string.Format("{0:MMM-dd-yyyy}", Convert.ToDateTime(dtNotes.Rows[i]["Note_Date"])) + " </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:80%;'> " + dtNotes.Rows[i]["Note"].ToString() + " </td></tr>");
            }

            sbHtml.Append("</table><br/>");

            #endregion

            #region "Attachment"

            // get attachment detail
            DataTable dtAttachment = ERIMSAttachment.SelectByTableName(clsGeneral.TableNames[(int)clsGeneral.Tables.Purchasing_LR_Agreement], Convert.ToInt32(PK_Purchasing_LR_Agreement)).Tables[0];

            sbHtml.Append("<table width='100%' cellspacing='0'>");
            sbHtml.Append(GetHeaderRow("Attachments", "3"));
            sbHtml.Append("</table><br />");
            sbHtml.Append("<table width='100%' cellspacing='0' style='padding-bottom:5px;' >");
            sbHtml.Append("<tr valign='top' align='center'>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' > <b>Attachment Type</td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:50%' > <b>Attachment Description</td>");
            sbHtml.Append("<td style='background-color: silver;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:30%' > <b>File Name</td>");
            sbHtml.Append("</tr>");

            // loop for print all attachment detail
            for (int i = 0; i < dtAttachment.Rows.Count; i++)
            {
                sbHtml.Append("<tr valign='top'>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:20%' > " + dtAttachment.Rows[i]["Attachment_Type"].ToString() + " </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:50%' > " + dtAttachment.Rows[i]["Attachment_Description"].ToString() + " </td>");
                sbHtml.Append("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 2px;width:30%' > " + dtAttachment.Rows[i]["Attachment_Name1"].ToString() + "</td>");
                sbHtml.Append("</tr>");
            }

            sbHtml.Append("</table>");

            #endregion

        }
    }

    #region "General Methods"

    /// <summary>
    /// it retuns blank row that is used to generate HTML format email to be sent.
    /// </summary>
    /// <param name="Height">height of the blank row</param>
    /// <returns>blank row HTML tag</returns>
    private string GetBlankTable(int Height)
    {
        //return string.Concat("<tr><td class=\"Spacer\" style=\"height:", Height.ToString(), "px\"></td></tr>");
        return string.Concat("<table><tr><td height=" + Height.ToString() + "></td></tr></table>");
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
    /// get Header table row with bottom border and font color
    /// </summary>
    /// <param name="Content"></param>
    /// <returns></returns>
    private string GetHeaderRow(string Content)
    {
        return string.Concat("<tr align='left'> <td style='order-bottom-color: Black; border-bottom-style: solid; border-bottom-width: thin;color: #548DD4;' colspan='6'> <span style='color: #548DD4;'>" + Content + " </span> </td> </tr>");
    }

    /// <summary>
    /// get table header row with colspan
    /// </summary>
    /// <param name="Content"></param>
    /// <param name="colspan"></param>
    /// <returns></returns>
    private string GetHeaderRow(string Content, string colspan)
    {
        return string.Concat("<tr align='left'> <td style='order-bottom-color: Black; border-bottom-style: solid; border-bottom-width: thin;color: #548DD4;' colspan=' " + colspan + "'> <span style='color: #548DD4;'>" + Content + " </span> </td> </tr>");
    }

    #endregion
}
