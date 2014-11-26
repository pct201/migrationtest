using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.IO;
using System.Data;


namespace eRIMS_Sonic_PurchasingMails
{
    class Purchasing
    {
        public static string strConn;
        
        public Purchasing()
        {
            // 
            // TODO: Add constructor logic here
            //
        }

        public static DataSet GetLRAgreementsForMail()
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_SendMails");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetServiceContractsForMail()
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_SendMails");
            return db.ExecuteDataSet(dbCommand);
        }

        public static string strBorder = "border-bottom:solid 2px Black;border-left:solid 2px Black;border-right:solid 2px Black;border-top:solid 2px Black;";
        public static string ServiceContractAbstract(int PK_Purchasing_Service_Contract)
        {
            FileStream fsMail = new FileStream(clsGeneral.strServicePath + @"\ServiceContractAbstract.htm", FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fsMail);
            string strBody = rd.ReadToEnd().ToString();
            rd.Close();
            fsMail.Close();
            fsMail.Dispose();

            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Service_ContractSelect");

            db.AddInParameter(dbCommand, "PK_Purchasing_Service_Contract", DbType.Decimal, PK_Purchasing_Service_Contract);
            DataTable dtSC = db.ExecuteDataSet(dbCommand).Tables[0];

            if (dtSC.Rows.Count > 0)
            {
                DataRow drSC = dtSC.Rows[0];
                strBody = strBody.Replace("[Supplier]", (!string.IsNullOrEmpty(Convert.ToString(drSC["Supplier"])) ? Convert.ToString(drSC["Supplier"]) : ""));
                strBody = strBody.Replace("[Service Type]", (!string.IsNullOrEmpty(Convert.ToString(drSC["Service_Type"])) ? Convert.ToString(drSC["Service_Type"]) : ""));
                strBody = strBody.Replace("[Start Date]", clsGeneral.FormatDBNullDateToDisplay(drSC["Start_Date"]));
                strBody = strBody.Replace("[End Date]", clsGeneral.FormatDBNullDateToDisplay(drSC["End_Date"]));
                strBody = strBody.Replace("[Term in Months]", Convert.ToString(drSC["Term_In_Months"]).Replace(".00", ""));
                strBody = strBody.Replace("[Service Frequency]", Convert.ToString(drSC["Service_Frequency"]));
                strBody = strBody.Replace("[Monthly Cost]", "$ " + clsGeneral.GetStringValue(drSC["Monthly_Cost"]));
                strBody = strBody.Replace("[Annual Cost]", "$ " + clsGeneral.GetStringValue(drSC["Annual_Cost"]));

                string strServiceContract = "";

                if (drSC["FK_LU_Service_Contract"] != DBNull.Value)
                {
                    dbCommand = db.GetStoredProcCommand("LU_Service_ContractSelect");
                    db.AddInParameter(dbCommand, "PK_LU_Service_Contract", DbType.Decimal, drSC["FK_LU_Service_Contract"]);
                    DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        strServiceContract = Convert.ToString(dr["Fld_Desc"]);
                    }

                }
                strBody = strBody.Replace("[Service Contract]", strServiceContract);
                strBody = strBody.Replace("[Total Committed]", "$ " + clsGeneral.GetStringValue(drSC["Total_Committed"]));
                strBody = strBody.Replace("[Notification Date]", clsGeneral.FormatDBNullDateToDisplay(drSC["Notification_Date"]));
                strBody = strBody.Replace("[Applicable Dealers]", Convert.ToString(drSC["Applicable_Dealers"]));
                // Department Grid
                strBody = strBody.Replace("[Department]", GetDepartmentGrid(PK_Purchasing_Service_Contract));
                // Delarship Grid
                strBody = strBody.Replace("[Dealership]", GetDelarshipGrid(PK_Purchasing_Service_Contract));
                // Applicable Assets Grid
                strBody = strBody.Replace("[Applicable Assets]", GetApplicableAssetsGrid(PK_Purchasing_Service_Contract));
                // Supplier Contact Information Grid
                strBody = strBody.Replace("[Supplier Contact]", GetSupplierContactInfoGrid(PK_Purchasing_Service_Contract));
                // Sonic Contact Information Grid
                strBody = strBody.Replace("[Sonic Contact]", GetSonicContactInfoGrid(PK_Purchasing_Service_Contract));
                // Notes Grid 
                strBody = strBody.Replace("[Notes]", GetNotesGrid(PK_Purchasing_Service_Contract));
                // Notes Grid 
                strBody = strBody.Replace("[Attachments]", GetAttachmentGrid(PK_Purchasing_Service_Contract));

            }
            else
            {
                strBody = strBody.Replace("[Supplier]","");
                strBody = strBody.Replace("[Service Type]","");
                strBody = strBody.Replace("[Start Date]", "");
                strBody = strBody.Replace("[End Date]", "");
                strBody = strBody.Replace("[Term in Months]","");
                strBody = strBody.Replace("[Service Frequency]","");
                strBody = strBody.Replace("[Monthly Cost]", "");
                strBody = strBody.Replace("[Annual Cost]", "");
                strBody = strBody.Replace("[Service Contract]", "");
                strBody = strBody.Replace("[Total Committed]","");
                strBody = strBody.Replace("[Notification Date]", "");
                strBody = strBody.Replace("[Applicable Dealers]", "");               
                strBody = strBody.Replace("[Department]", "");               
                strBody = strBody.Replace("[Dealership]", "");              
                strBody = strBody.Replace("[Applicable Assets]", "");                
                strBody = strBody.Replace("[Supplier Contact]", "");                
                strBody = strBody.Replace("[Sonic Contact]", "");               
                strBody = strBody.Replace("[Notes]", "");               
                strBody = strBody.Replace("[Attachments]", "");
            }
            dtSC.Dispose();
            return strBody.ToString();
        }
        public static string GetDepartmentGrid(int PK_Purchasing_Service_Contract)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DepartmentSelectBySC");
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, PK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "strSortBy", DbType.String, "");
            DataSet ds = db.ExecuteDataSet(dbCommand);
            StringBuilder strHtmlDepartment = new StringBuilder();
            strHtmlDepartment.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strHtmlDepartment.Append("<tr>");
            strHtmlDepartment.Append("<td style='background-color: #9a9a9a; " + strBorder + "' align='center'><strong>Department</strong></td>");
            strHtmlDepartment.Append("</tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHtmlDepartment.Append("<tr>");
                strHtmlDepartment.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["FLD_Desc"] + "</td>");
                strHtmlDepartment.Append("</tr>");
            }
            strHtmlDepartment.Append("</table>");
            ds.Dispose();
            return strHtmlDepartment.ToString();
        }
        public static string GetDelarshipGrid(int PK_Purchasing_Service_Contract)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DealerSelectByServiceContract");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Dealer", DbType.Decimal, PK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "strSortBy", DbType.String, string.Empty);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, DBNull.Value);

            DataSet ds = db.ExecuteDataSet(dbCommand); 
            StringBuilder strHtmlDelarship = new StringBuilder();
            strHtmlDelarship.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strHtmlDelarship.Append("<tr>");
            strHtmlDelarship.Append("<td style='background-color: #9a9a9a; " + strBorder + "' align='center'><strong>Dealer Name</strong></td>");
            strHtmlDelarship.Append("<td style='background-color: #9a9a9a; " + strBorder + "' align='center'><strong>Address</strong></td>");
            strHtmlDelarship.Append("</tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHtmlDelarship.Append("<tr>");
                strHtmlDelarship.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["dba"] + "</td>");
                strHtmlDelarship.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Address_1"] + "</td>");
                strHtmlDelarship.Append("</tr>");
            }
            strHtmlDelarship.Append("</table>");
            ds.Dispose();
            return strHtmlDelarship.ToString();
        }
        public static string GetApplicableAssetsGrid(int PK_Purchasing_Service_Contract)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_AssetSelectByFK_SC");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, PK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "strSortBy", DbType.String, string.Empty);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            StringBuilder strHtmlApplicableAssets = new StringBuilder();
            strHtmlApplicableAssets.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strHtmlApplicableAssets.Append("<tr>");
            strHtmlApplicableAssets.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center'><strong>Asset Type</strong></td>");
            strHtmlApplicableAssets.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center'><strong>Manufacturer</strong></td>");
            strHtmlApplicableAssets.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center'><strong>Supplier</strong></td>");
            strHtmlApplicableAssets.Append("</tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHtmlApplicableAssets.Append("<tr>");
                strHtmlApplicableAssets.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Type"] + "</td>");
                strHtmlApplicableAssets.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Fld_Desc"] + "</td>");
                strHtmlApplicableAssets.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Supplier"] + "</td>");
                strHtmlApplicableAssets.Append("</tr>");
            }
            strHtmlApplicableAssets.Append("</table>");
            ds.Dispose();
            return strHtmlApplicableAssets.ToString();
        }
        public static string GetSupplierContactInfoGrid(int PK_Purchasing_Service_Contract)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Select_ContactInformation");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, PK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "FK_Contact_Type", DbType.Decimal, 2);
            db.AddInParameter(dbCommand, "SearchType", DbType.String, "SC");
            DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
            StringBuilder strHtmlSupplierContact = new StringBuilder();
            strHtmlSupplierContact.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strHtmlSupplierContact.Append("<tr>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>Supplier</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>ContactDate</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>ContactName</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='30%'><strong>Address</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='25%'><strong>Work Telephone</strong></td>");
            strHtmlSupplierContact.Append("</tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string strState = "", strZipCode = "", strCity = "", strAddress1 = "", strAddress2 = "";
                string strContactDetail = "";
                strCity = Convert.ToString(dt.Rows[i]["City"]);
                strState = Convert.ToString(dt.Rows[i]["FLD_abbreviation"]);
                strZipCode = Convert.ToString(dt.Rows[i]["ZIP_Code"]);
                strAddress1 = Convert.ToString(dt.Rows[i]["Address_1"]);
                strAddress2 = Convert.ToString(dt.Rows[i]["Address_2"]);
                if (strAddress1 != "")
                {
                    strAddress1 = strAddress1 + "</br>";
                }
                if (strAddress2 != "")
                {
                    strAddress2 = strAddress2 + "</br>";
                }
                if (strCity != "")
                {
                    if (strState != "")
                    {
                        strContactDetail = strCity + ", " + strState + " " + strZipCode;
                    }
                    else
                    {
                        strContactDetail = strCity + " " + strZipCode;
                    }
                }
                else
                {
                    strContactDetail = strState + " " + strZipCode;
                }
                strHtmlSupplierContact.Append("<tr>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["Supplier"] + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + String.Format("{0:MMM-dd-yyyy}", dt.Rows[i]["ContactDate"]) + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["ContactName"] + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + strAddress1 + strAddress2 + strContactDetail + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["Work_Telephone"] + "</td>");
                strHtmlSupplierContact.Append("</tr>");
            }
            strHtmlSupplierContact.Append("</table>");
            dt.Dispose();
            return strHtmlSupplierContact.ToString();
        }
        public static string GetSonicContactInfoGrid(int PK_Purchasing_Service_Contract)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Select_ContactInformation");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, PK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "FK_Contact_Type", DbType.Decimal, 1);
            db.AddInParameter(dbCommand, "SearchType", DbType.String, "SC");
            
            DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
            StringBuilder strHtmlSupplierContact = new StringBuilder();
            strHtmlSupplierContact.Append("<table cellspacing='0' cellpadding='0' border='1' width='100%'>");
            strHtmlSupplierContact.Append("<tr>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>Supplier</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>ContactDate</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>ContactName</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='30%'><strong>Address</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='25%'><strong>Work Telephone</strong></td>");
            strHtmlSupplierContact.Append("</tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string strState = "", strZipCode = "", strCity = "", strAddress1 = "", strAddress2 = "";
                string strContactDetail = "";
                strCity = Convert.ToString(dt.Rows[i]["City"]);
                strState = Convert.ToString(dt.Rows[i]["FLD_abbreviation"]);
                strZipCode = Convert.ToString(dt.Rows[i]["ZIP_Code"]);
                strAddress1 = Convert.ToString(dt.Rows[i]["Address_1"]);
                strAddress2 = Convert.ToString(dt.Rows[i]["Address_2"]);
                if (strAddress1 != "")
                {
                    strAddress1 = strAddress1 + "</br>";
                }
                if (strAddress2 != "")
                {
                    strAddress2 = strAddress2 + "</br>";
                }
                if (strCity != "")
                {
                    if (strState != "")
                    {
                        strContactDetail = strCity + ", " + strState + " " + strZipCode;
                    }
                    else
                    {
                        strContactDetail = strCity + " " + strZipCode;
                    }
                }
                else
                {
                    strContactDetail = strState + " " + strZipCode;
                }
                strHtmlSupplierContact.Append("<tr>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["Supplier"] + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + String.Format("{0:MMM-dd-yyyy}", dt.Rows[i]["ContactDate"]) + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["ContactName"] + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + strAddress1 + strAddress2 + strContactDetail + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["Work_Telephone"] + "</td>");
                strHtmlSupplierContact.Append("</tr>");
            }
            strHtmlSupplierContact.Append("</table>");
            dt.Dispose();
            return strHtmlSupplierContact.ToString();
        }
        public static string GetNotesGrid(int PK_Purchasing_Service_Contract)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_NotesSelectAllByServiceContract");
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, PK_Purchasing_Service_Contract);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            StringBuilder strHtmlNotes = new StringBuilder();
            strHtmlNotes.Append("<table cellspacing='0' cellpadding='0' border='1' width='100%'>");
            strHtmlNotes.Append("<tr>");
            strHtmlNotes.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='20%'><strong>Note Date</strong></td>");
            strHtmlNotes.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center'><strong>Note Text</strong></td>");
            strHtmlNotes.Append("</tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHtmlNotes.Append("<tr>");
                strHtmlNotes.Append("<td align='left' valign='top' style='" + strBorder + "'>" + String.Format("{0:MMM-dd-yyyy}", ds.Tables[0].Rows[i]["Note_Date"]) + "</td>");
                strHtmlNotes.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Note"] + "</td>");
                strHtmlNotes.Append("</tr>");
            }
            strHtmlNotes.Append("</table>");
            ds.Dispose();
            return strHtmlNotes.ToString();
        }
        public static string GetAttachmentGrid(int PK_Purchasing_Service_Contract)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectByTableName");

            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, "Purchasing_Service_Contract");
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, PK_Purchasing_Service_Contract);

            DataSet ds = db.ExecuteDataSet(dbCommand);
            StringBuilder strHtmlAttachment = new StringBuilder();
            strHtmlAttachment.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strHtmlAttachment.Append("<tr>");
            strHtmlAttachment.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='20%'><strong>Attachment Type</strong></td>");
            strHtmlAttachment.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='45%'><strong>Attachment Description</strong></td>");
            strHtmlAttachment.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='25%'><strong>File Name</strong></td>");
            strHtmlAttachment.Append("</tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHtmlAttachment.Append("<tr>");
                strHtmlAttachment.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Attachment_Type"] + "</td>");
                strHtmlAttachment.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Attachment_Description"] + "</td>");
                strHtmlAttachment.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Attachment_Name1"] + "</td>");
                strHtmlAttachment.Append("</tr>");
            }
            strHtmlAttachment.Append("</table>");
            ds.Dispose();
            return strHtmlAttachment.ToString();
        }

        #region "LR Agreement"

        public static string LRAgreement(int PK_Purchasing_LR_Agreement)
        {
            FileStream fsMail = new FileStream(clsGeneral.strServicePath + @"\LRAgreement.htm", FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fsMail);
            string strBody = rd.ReadToEnd().ToString();
            rd.Close();
            fsMail.Close();
            fsMail.Dispose();
            DataTable dt = SelectByPK(PK_Purchasing_LR_Agreement);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                SetDefaultValuesForDBNull(dr);
                strBody = strBody.Replace("[Supplier]", (!string.IsNullOrEmpty(Convert.ToString(dr["Supplier"])) ? Convert.ToString(dr["Supplier"]) : ""));
                strBody = strBody.Replace("[Equipment Type]", dr["Equipment_Type"].ToString());
                strBody = strBody.Replace("[Payment Terms]", dr["payment_Terms"].ToString());
                strBody = strBody.Replace("[Buyout]", "$ " + clsGeneral.GetStringValue(Convert.ToDecimal(dr["buyout"].ToString())));
                strBody = strBody.Replace("[Late Fee]", dr["late_Fee"].ToString());
                strBody = strBody.Replace("[Lease/Rental Type]", dr["LU_LR_Type"].ToString());
                strBody = strBody.Replace("[Leased Amount]", "$ " + clsGeneral.GetStringValue(Convert.ToDecimal(dr["leased_Amount"].ToString())));
                strBody = strBody.Replace("[Lease Factor]", (!string.IsNullOrEmpty(Convert.ToString(dr["lease_Rate"])) ? Convert.ToString(dr["lease_Rate"]) : ""));
                strBody = strBody.Replace("[Lease/Rental Agreement Notes]", dr["end_Of_Lease_Options"].ToString());
                strBody = strBody.Replace("[Start Date]", clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(dr["start_Date"].ToString())))));
                strBody = strBody.Replace("[End Date]", clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(dr["End_Date"].ToString())))));
                strBody = strBody.Replace("[Status]", (!string.IsNullOrEmpty(Convert.ToString(dr["Status"])) ? Convert.ToString(dr["Status"]) : ""));
                strBody = strBody.Replace("[Term in Months]", Convert.ToDecimal(dr["term_In_Months"].ToString()).ToString().Replace(".00", ""));
                strBody = strBody.Replace("[Notification Date]", clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(dr["notification_Date"].ToString())))));
                strBody = strBody.Replace("[Monthly Cost]", "$ " + clsGeneral.GetStringValue(Convert.ToDecimal(dr["monthly_Cost"].ToString())));
                strBody = strBody.Replace("[Annual Cost]", "$ " + clsGeneral.GetStringValue(Convert.ToDecimal(dr["annual_Cost"].ToString())));
                strBody = strBody.Replace("[Total Committed]", "$ " + clsGeneral.GetStringValue(Convert.ToDecimal(dr["total_Committed"].ToString())));
                strBody = strBody.Replace("[Customer/Contract Number]", (!string.IsNullOrEmpty(Convert.ToString(dr["customer_contract_number"])) ? Convert.ToString(dr["customer_contract_number"]) : ""));
                strBody = strBody.Replace("[Auto Renew Options]", (!string.IsNullOrEmpty(Convert.ToString(dr["LU_Auto_Renew"])) ? Convert.ToString(dr["LU_Auto_Renew"]) : ""));
                strBody = strBody.Replace("[Auto Renew Other]", (!string.IsNullOrEmpty(Convert.ToString(dr["auto_Renew_Other"])) ? Convert.ToString(dr["auto_Renew_Other"]) : ""));
                strBody = strBody.Replace("[Dealership Department]", (!string.IsNullOrEmpty(Convert.ToString(dr["LU_Dealership_Department"])) ? Convert.ToString(dr["LU_Dealership_Department"]) : ""));

                // Delarship Grid
                strBody = strBody.Replace("[Dealership]", GetDelarshipGrid_LR(PK_Purchasing_LR_Agreement));
                // Applicable Assets Grid
                strBody = strBody.Replace("[Applicable Assets]", GetApplicableAssetsGrid_LR(PK_Purchasing_LR_Agreement));
                // Supplier Contact Information Grid
                strBody = strBody.Replace("[Supplier Contact]", GetSupplierContactInfoGrid_LR(PK_Purchasing_LR_Agreement));
                // Sonic Contact Information Grid
                strBody = strBody.Replace("[Sonic Contact]", GetSonicContactInfoGrid_LR(PK_Purchasing_LR_Agreement));
                // Notes Grid 
                strBody = strBody.Replace("[Notes]", GetNotesGrid_LR(PK_Purchasing_LR_Agreement));
                // Notes Grid 
                strBody = strBody.Replace("[Attachments]", GetAttachmentGrid_LR(PK_Purchasing_LR_Agreement));
            }
            else
            {
                strBody = strBody.Replace("[Supplier]", "");
                strBody = strBody.Replace("[Equipment Type]", "");
                strBody = strBody.Replace("[Payment Terms]", "");
                strBody = strBody.Replace("[Buyout]", "");
                strBody = strBody.Replace("[Late Fee]", "");
                strBody = strBody.Replace("[Lease/Rental Type]","");
                strBody = strBody.Replace("[Leased Amount]", "");
                strBody = strBody.Replace("[Lease Factor]","");
                strBody = strBody.Replace("[Lease/Rental Agreement Notes]", "");
                strBody = strBody.Replace("[Start Date]", "");
                strBody = strBody.Replace("[End Date]", "");
                strBody = strBody.Replace("[Status]", "");
                strBody = strBody.Replace("[Term in Months]","");
                strBody = strBody.Replace("[Notification Date]","");
                strBody = strBody.Replace("[Monthly Cost]","");
                strBody = strBody.Replace("[Annual Cost]","");
                strBody = strBody.Replace("[Total Committed]","");
                strBody = strBody.Replace("[Customer/Contract Number]","");
                strBody = strBody.Replace("[Auto Renew Options]", "");
                strBody = strBody.Replace("[Auto Renew Other]", "");
                strBody = strBody.Replace("[Dealership Department]", "");               
                strBody = strBody.Replace("[Dealership]","");               
                strBody = strBody.Replace("[Applicable Assets]", "");               
                strBody = strBody.Replace("[Supplier Contact]", "");              
                strBody = strBody.Replace("[Sonic Contact]", "");               
                strBody = strBody.Replace("[Notes]","");                
                strBody = strBody.Replace("[Attachments]", "");
            }


            dt.Dispose();
            return strBody.ToString();
        }
        public static DataTable SelectByPK(decimal pK_Purchasing_LR_Agreement)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_AgreementSelectByPK_Windowservice");

            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Agreement", DbType.Decimal, pK_Purchasing_LR_Agreement);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        public static string GetDelarshipGrid_LR(int pK_Purchasing_LR_Dealer)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_DealerSelectByLR_Agreement");

            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Dealer", DbType.Decimal, pK_Purchasing_LR_Dealer);
            db.AddInParameter(dbCommand, "strSortBy", DbType.String, "");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, null);

            DataSet ds = db.ExecuteDataSet(dbCommand);
            StringBuilder strHtmlDelarship = new StringBuilder();
            strHtmlDelarship.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strHtmlDelarship.Append("<tr>");
            strHtmlDelarship.Append("<td style='background-color: #9a9a9a; " + strBorder + "' align='center'><strong>Dealer Name</strong></td>");
            strHtmlDelarship.Append("<td style='background-color: #9a9a9a; " + strBorder + "' align='center'><strong>Address</strong></td>");
            strHtmlDelarship.Append("</tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHtmlDelarship.Append("<tr>");
                strHtmlDelarship.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["dba"] + "</td>");
                strHtmlDelarship.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Address_1"] + "</td>");
                strHtmlDelarship.Append("</tr>");
            }
            strHtmlDelarship.Append("</table>");
            ds.Dispose();
            return strHtmlDelarship.ToString();
        }
        public static string GetApplicableAssetsGrid_LR(int _fK_Purchasing_LR_Agreement)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_AssetSelectByFK_LR");

            db.AddInParameter(dbCommand, "FK_Purchasing_LR_Agreement", DbType.Decimal, _fK_Purchasing_LR_Agreement);
            db.AddInParameter(dbCommand, "strSortBy", DbType.String, "");

            DataSet ds = db.ExecuteDataSet(dbCommand);
            StringBuilder strHtmlApplicableAssets = new StringBuilder();
            strHtmlApplicableAssets.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strHtmlApplicableAssets.Append("<tr>");
            strHtmlApplicableAssets.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center'><strong>Asset Type</strong></td>");
            strHtmlApplicableAssets.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center'><strong>Manufacturer</strong></td>");
            strHtmlApplicableAssets.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center'><strong>Supplier</strong></td>");
            strHtmlApplicableAssets.Append("</tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHtmlApplicableAssets.Append("<tr>");
                strHtmlApplicableAssets.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Type"] + "</td>");
                strHtmlApplicableAssets.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Fld_Desc"] + "</td>");
                strHtmlApplicableAssets.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Supplier"] + "</td>");
                strHtmlApplicableAssets.Append("</tr>");
            }
            strHtmlApplicableAssets.Append("</table>");
            ds.Dispose();
            return strHtmlApplicableAssets.ToString();
        }
        public static DataTable GetPurchasing_SonicAndSupplier_ContactInformation(decimal FK_Table_Name, decimal FK_Contact_Type, string SearchType)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Select_ContactInformation");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, FK_Table_Name);
            db.AddInParameter(dbCommand, "FK_Contact_Type", DbType.Decimal, FK_Contact_Type);
            db.AddInParameter(dbCommand, "SearchType", DbType.String, SearchType);
            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        public static string GetSupplierContactInfoGrid_LR(int PK_Purchasing_LR_Agreement)
        {
            DataTable dt = GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_LR_Agreement, 2, "");
            StringBuilder strHtmlSupplierContact = new StringBuilder();
            strHtmlSupplierContact.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strHtmlSupplierContact.Append("<tr>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>Supplier</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>ContactDate</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>ContactName</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='30%'><strong>Address</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='25%'><strong>Work Telephone</strong></td>");
            strHtmlSupplierContact.Append("</tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string strState = "", strZipCode = "", strCity = "", strAddress1 = "", strAddress2 = "";
                string strContactDetail = "";
                strCity = Convert.ToString(dt.Rows[i]["City"]);
                strState = Convert.ToString(dt.Rows[i]["FLD_abbreviation"]);
                strZipCode = Convert.ToString(dt.Rows[i]["ZIP_Code"]);
                strAddress1 = Convert.ToString(dt.Rows[i]["Address_1"]);
                strAddress2 = Convert.ToString(dt.Rows[i]["Address_2"]);
                if (strAddress1 != "")
                {
                    strAddress1 = strAddress1 + "</br>";
                }
                if (strAddress2 != "")
                {
                    strAddress2 = strAddress2 + "</br>";
                }
                if (strCity != "")
                {
                    if (strState != "")
                    {
                        strContactDetail = strCity + ", " + strState + " " + strZipCode;
                    }
                    else
                    {
                        strContactDetail = strCity + " " + strZipCode;
                    }
                }
                else
                {
                    strContactDetail = strState + " " + strZipCode;
                }
                strHtmlSupplierContact.Append("<tr>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["Supplier"] + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + String.Format("{0:MMM-dd-yyyy}", dt.Rows[i]["ContactDate"]) + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["ContactName"] + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + strAddress1 + strAddress2 + strContactDetail + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["Work_Telephone"] + "</td>");
                strHtmlSupplierContact.Append("</tr>");
            }
            strHtmlSupplierContact.Append("</table>");
            dt.Dispose();
            return strHtmlSupplierContact.ToString();
        }
        public static string GetSonicContactInfoGrid_LR(int PK_Purchasing_LR_Agreement)
        {
            DataTable dt = GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_LR_Agreement, 1, "");
            StringBuilder strHtmlSupplierContact = new StringBuilder();
            strHtmlSupplierContact.Append("<table cellspacing='0' cellpadding='0' border='1' width='100%'>");
            strHtmlSupplierContact.Append("<tr>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>Supplier</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>ContactDate</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='15%'><strong>ContactName</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='30%'><strong>Address</strong></td>");
            strHtmlSupplierContact.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='25%'><strong>Work Telephone</strong></td>");
            strHtmlSupplierContact.Append("</tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string strState = "", strZipCode = "", strCity = "", strAddress1 = "", strAddress2 = "";
                string strContactDetail = "";
                strCity = Convert.ToString(dt.Rows[i]["City"]);
                strState = Convert.ToString(dt.Rows[i]["FLD_abbreviation"]);
                strZipCode = Convert.ToString(dt.Rows[i]["ZIP_Code"]);
                strAddress1 = Convert.ToString(dt.Rows[i]["Address_1"]);
                strAddress2 = Convert.ToString(dt.Rows[i]["Address_2"]);
                if (strAddress1 != "")
                {
                    strAddress1 = strAddress1 + "</br>";
                }
                if (strAddress2 != "")
                {
                    strAddress2 = strAddress2 + "</br>";
                }
                if (strCity != "")
                {
                    if (strState != "")
                    {
                        strContactDetail = strCity + ", " + strState + " " + strZipCode;
                    }
                    else
                    {
                        strContactDetail = strCity + " " + strZipCode;
                    }
                }
                else
                {
                    strContactDetail = strState + " " + strZipCode;
                }
                strHtmlSupplierContact.Append("<tr>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["Supplier"] + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + String.Format("{0:MMM-dd-yyyy}", dt.Rows[i]["ContactDate"]) + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["ContactName"] + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + strAddress1 + strAddress2 + strContactDetail + "</td>");
                strHtmlSupplierContact.Append("<td align='left' valign='top' style='" + strBorder + "'>" + dt.Rows[i]["Work_Telephone"] + "</td>");
                strHtmlSupplierContact.Append("</tr>");
            }
            strHtmlSupplierContact.Append("</table>");
            dt.Dispose();
            return strHtmlSupplierContact.ToString();
        }
        public static string GetNotesGrid_LR(int PK_Purchasing_LR_Agreement)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_NoteSelectByFK_LR");

            db.AddInParameter(dbCommand, "FK_Purchasing_LR_Agreement", DbType.Decimal, PK_Purchasing_LR_Agreement);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            StringBuilder strHtmlNotes = new StringBuilder();
            strHtmlNotes.Append("<table cellspacing='0' cellpadding='0' border='1' width='100%'>");
            strHtmlNotes.Append("<tr>");
            strHtmlNotes.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='20%'><strong>Note Date</strong></td>");
            strHtmlNotes.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center'><strong>Note Text</strong></td>");
            strHtmlNotes.Append("</tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHtmlNotes.Append("<tr>");
                strHtmlNotes.Append("<td align='left' valign='top' style='" + strBorder + "'>" + String.Format("{0:MMM-dd-yyyy}", ds.Tables[0].Rows[i]["Note_Date"]) + "</td>");
                strHtmlNotes.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Note"] + "</td>");
                strHtmlNotes.Append("</tr>");
            }
            strHtmlNotes.Append("</table>");
            ds.Dispose();
            return strHtmlNotes.ToString();
        }
        public static string GetAttachmentGrid_LR(int PK_Purchasing_LR_Agreement)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectByTableName");

            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, "Purchasing_LR_Agreement");
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, PK_Purchasing_LR_Agreement);

            DataSet ds = db.ExecuteDataSet(dbCommand);
            StringBuilder strHtmlAttachment = new StringBuilder();
            strHtmlAttachment.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
            strHtmlAttachment.Append("<tr>");
            strHtmlAttachment.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='20%'><strong>Attachment Type</strong></td>");
            strHtmlAttachment.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='45%'><strong>Attachment Description</strong></td>");
            strHtmlAttachment.Append("<td style='background-color: #9a9a9a;" + strBorder + "' align='center' width='25%'><strong>File Name</strong></td>");
            strHtmlAttachment.Append("</tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strHtmlAttachment.Append("<tr>");
                strHtmlAttachment.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Attachment_Type"] + "</td>");
                strHtmlAttachment.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Attachment_Description"] + "</td>");
                strHtmlAttachment.Append("<td align='left' valign='top' style='" + strBorder + "'>" + ds.Tables[0].Rows[i]["Attachment_Name1"] + "</td>");
                strHtmlAttachment.Append("</tr>");
            }
            strHtmlAttachment.Append("</table>");
            ds.Dispose();
            return strHtmlAttachment.ToString();
        }

        /// <summary>
        /// set default value for datarow column based on type
        /// </summary>
        /// <param name="dr"></param>
        public static void SetDefaultValuesForDBNull(DataRow dr)
        {
            foreach (DataColumn col in dr.Table.Columns)
            {
                if (Convert.IsDBNull(dr[col]))
                {
                    switch (col.DataType.ToString())
                    {
                        case "System.Int32":
                        case "System.Decimal":
                        case "System.Double":
                            dr[col] = 0;
                            break;
                        // break 
                        case "System.String":
                            dr[col] = string.Empty;
                            break;
                        case "System.DateTime":
                            dr[col] = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                            break;
                        default:
                            break;
                        // break 
                    }
                }
            }
        }

        #endregion

    }
}
