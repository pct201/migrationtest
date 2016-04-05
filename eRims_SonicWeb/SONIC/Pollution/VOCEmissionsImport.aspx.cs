using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using Microsoft.VisualBasic.FileIO;
using System.Collections;
using Excel;
public partial class SONIC_Exposures_VOCEmissionsImport : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Permits
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Permits"]);
        }
        set { ViewState["PK_PM_Permits"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal FK_LU_Location
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_LU_Location"]);
        }
        set { ViewState["FK_LU_Location"] = value; }
    }

    /// <summary>
    /// Denotes primary key for Permits VOC Emissions record
    /// </summary>
    public decimal PK_PM_Permits_VOC_Emissions
    {
        get { return Convert.ToDecimal(ViewState["PK_PM_Permits_VOC_Emissions"]); }
        set { ViewState["PK_PM_Permits_VOC_Emissions"] = value; }
    }

    /// <summary>
    /// Denotes PK for Building table
    /// </summary>
    public decimal FK_Building_ID
    {
        get { return Convert.ToInt32(ViewState["FK_Building_ID"]); }
        set
        {
            ViewState["FK_Building_ID"] = value;
        }
    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (App_Import != AccessType.VOC_Import && !IsUserSystemAdmin && !Convert.ToBoolean(Convert.ToInt32(clsSession.UserRole)))
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

            BindDropdowns();
            decimal FK_PM_Site_Information;
            PK_PM_Permits = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            if (FK_LU_Location > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location;
                ddlLocation.SelectedValue = Convert.ToString(FK_LU_Location);
            }
            else
            {
                Response.Redirect("../Exposures/ExposureSearch.aspx");
            }
        }
    }

    #endregion

    #region "Event"

    /// <summary>
    /// Submit Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (fpFile.FileName.ToLower().Trim().EndsWith(".csv") && (ddlFileType.SelectedIndex == 1))
        {
            string filename = string.Empty;
            string strUploadedFile = clsGeneral.UploadFile(fpFile, AppConfig.strGeneralDocument, Session.SessionID, false, false);
            try
            {
                if (fpFile.HasFile)
                {
                    filename = AppConfig.strGeneralDocument + "\\" + strUploadedFile;
                    //clsPM_Permits_VOC_Emissions objVOCEmission = new clsPM_Permits_VOC_Emissions();
                    //DataTable dt = objVOCEmission.InsertData(filename).Tables[0];
                    string paintCategory = string.Empty, subTotalText = string.Empty, subtotalTextUpdate = string.Empty, fkCategoryIds = string.Empty, categoriIds = string.Empty;
                    Int64 retValue = 0, fK_LU_VOC_Category = 0;
                    int month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
                    int year = Convert.ToInt32(ddlYear.SelectedItem.Value);
                    string strFinal = "<ImportXML>", strFinalUpdate = "<ImportXML>";
                    int duplicateRecords = 0;
                    DataTable dt = new DataTable();

                    #region " CSV to DataTable "
                    StreamReader reader = new StreamReader(filename);
                    using (TextFieldParser csvReader = new TextFieldParser(reader))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        string[] fields = csvReader.ReadFields();
                        foreach (string column in fields)
                        {
                            dt.Columns.Add(column);
                        }
                        while (!csvReader.EndOfData)
                        {
                            fields = csvReader.ReadFields();
                            int colIndex = 0;
                            DataRow dr = dt.NewRow();
                            foreach (string fieldValue in fields)
                            {

                                dr[colIndex] = fieldValue;
                                colIndex++;
                            }
                            dt.Rows.Add(dr);
                        }

                    }
                    #endregion

                    Hashtable htDuplicateItems = new Hashtable();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataTable dtDuplicateImportData = dt.Clone();
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dr["Paint Category"])) && paintCategory.ToUpper() != (Convert.ToString(dr["Paint Category"])).ToUpper())
                            {
                                paintCategory = Convert.ToString(dr["Paint Category"]);
                                paintCategory = paintCategory.Replace("\"", "");
                                fK_LU_VOC_Category = clsLU_VOC_Category.SelectByCategory(paintCategory);
                                fkCategoryIds += fK_LU_VOC_Category + ",";
                                if (fK_LU_VOC_Category > 0)
                                {
                                    categoriIds += fK_LU_VOC_Category + ",";
                                }
                                else
                                {
                                    subTotalText += dr["Paint Category"] + ",";
                                }
                            }

                            string part_Number = Convert.ToString(dr["Part Number"]);

                            if ((fK_LU_VOC_Category > 0) && !string.IsNullOrEmpty(part_Number))
                            {
                                retValue = clsPM_Permits_VOC_Emissions.CheckRecord(month, year, fK_LU_VOC_Category, FK_LU_Location, PK_PM_Permits, part_Number, 0);
                            }
                            else
                            {
                                retValue = 0;
                            }


                            string tempItem = year.ToString() + "||" + month.ToString() + "||" + fK_LU_VOC_Category.ToString() + "||" + FK_LU_Location.ToString() + "||" + part_Number;

                            if (htDuplicateItems.Contains(tempItem))
                            {
                                if (!string.IsNullOrEmpty(part_Number))
                                {
                                    dtDuplicateImportData.ImportRow(dr);
                                    dtDuplicateImportData.Rows[dtDuplicateImportData.Rows.Count - 1]["Paint Category"] = paintCategory;
                                    duplicateRecords++;
                                }
                                // retValue = 2;
                            }
                            else
                            {
                                htDuplicateItems.Add(tempItem, retValue);
                                //retValue = 1;
                            }

                            if (retValue == 1 && !string.IsNullOrEmpty(part_Number))
                            {
                                strFinal = strFinal + "<Section><FK_PM_Permits>" + PK_PM_Permits + "</FK_PM_Permits><Year>" + year + "</Year><Month>" + month + "</Month><Paint_Category>" + fK_LU_VOC_Category + "</Paint_Category><Part_Number>" + Convert.ToString(dr["Part Number"]) + "</Part_Number><Unit>" + Convert.ToString(dr["Unit"]).Replace("\"", "") + "</Unit><Quantity>" + clsGeneral.GetDecimal(dr["Qty"]) + "</Quantity><Gallons>" + clsGeneral.GetDecimal(dr["Gallons"]) + "</Gallons><VOC_Emissions>" + clsGeneral.GetDecimal(dr["VOC Total"]) + "</VOC_Emissions><Updated_By>" + clsSession.UserID + "</Updated_By></Section>";
                            }

                            if (retValue == 2 && !string.IsNullOrEmpty(part_Number))
                            {
                                strFinalUpdate = strFinalUpdate + "<Section><FK_PM_Permits>" + PK_PM_Permits + "</FK_PM_Permits><Year>" + year + "</Year><Month>" + month + "</Month><Paint_Category>" + fK_LU_VOC_Category + "</Paint_Category><Part_Number>" + Convert.ToString(dr["Part Number"]) + "</Part_Number><Unit>" + Convert.ToString(dr["Unit"]).Replace("\"", "") + "</Unit><Quantity>" + clsGeneral.GetDecimal(dr["Qty"]) + "</Quantity><Gallons>" + clsGeneral.GetDecimal(dr["Gallons"]) + "</Gallons><VOC_Emissions>" + clsGeneral.GetDecimal(dr["VOC Total"]) + "</VOC_Emissions><Updated_By>" + clsSession.UserID + "</Updated_By></Section>";
                            }

                        }

                        strFinal += "</ImportXML>";
                        strFinalUpdate += "</ImportXML>";

                        if (dtDuplicateImportData != null && dtDuplicateImportData.Rows.Count > 0)
                        {
                            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('File Import Aborted, Following duplicate entries found.');", true);
                            gvVOCEmission.DataSource = dtDuplicateImportData;
                            gvVOCEmission.DataBind();
                            divVOCData.Visible = true;
                            lblDuplicateEntries.Text = "Number of Duplicate Records : " + duplicateRecords.ToString();
                        }
                        else
                        {
                            clsPM_Permits_VOC_Emissions.ImportXML(strFinal, strFinalUpdate);

                            if (!string.IsNullOrEmpty(categoriIds) && categoriIds.Contains(","))
                            {
                                string[] voc_Category = categoriIds.Split(',');
                                string[] subTotalTextData = subTotalText.Split(',');
                                int count = 0;
                                foreach (string voc_categoryId in voc_Category)
                                {
                                    if (!string.IsNullOrEmpty(voc_categoryId))
                                    {
                                        clsPM_Permits_VOC_Emissions.UpdateSubTotal(subTotalTextData[count], Convert.ToInt32(voc_categoryId), PK_PM_Permits, month, year, Convert.ToString(DateTime.Now), Convert.ToString(clsSession.UserID), false);
                                        count++;
                                    }
                                }
                            }
                            divVOCData.Visible = false;
                            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('File Imported Successfully');", true);
                        }
                    }
                }
            }
            catch
            {
                divVOCData.Visible = false;
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Selected File can not be Imported.');", true);
            }
            finally
            {
                // delete uploaded file
                DeleteUploadedFile(strUploadedFile);
            }
        }
        else if ((fpFile.FileName.ToLower().Trim().EndsWith(".xlsx") || fpFile.FileName.ToLower().Trim().EndsWith(".xls")) && (ddlFileType.SelectedIndex == 2))
        {
            string filename = string.Empty, categoriIds = string.Empty, subTotalText = string.Empty, pkIds = string.Empty;
            decimal fk_LU_Location_ID;
            string strUploadedFile = clsGeneral.UploadFile(fpFile, AppConfig.strGeneralDocument, Session.SessionID, false, false);
            try
            {
                if (fpFile.HasFile)
                {
                    string strFinal = String.Empty;
                    int month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
                    int year = Convert.ToInt32(ddlYear.SelectedItem.Value);

                    filename = AppConfig.strGeneralDocument + "\\" + strUploadedFile;

                    #region "XLSX to DataTable"

                    FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);

                    IExcelDataReader excelReader = null;

                    if (fpFile.FileName.ToLower().Trim().EndsWith(".xls"))
                    {
                        // Reading from a binary Excel file ('97-2003 format; *.xls)
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (fpFile.FileName.ToLower().Trim().EndsWith(".xlsx"))
                    {
                        // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    // DataSet - Create column names from first row
                    excelReader.IsFirstRowAsColumnNames = false;

                    // DataSet - The result of each spreadsheet will be created in the result.Tables
                    DataSet resultExcel = excelReader.AsDataSet();
                    DataTable dtResult = resultExcel.Tables[0];

                    // Free resources (IExcelDataReader is IDisposable)
                    excelReader.Close();

                    DataTable dtFinalResult = new DataTable();
                    dtFinalResult.Columns.Add("fK_LU_VOC_Category", typeof(int));
                    dtFinalResult.Columns.Add("Gallons", typeof(decimal));
                    dtFinalResult.Columns.Add("VOC_Emissions", typeof(decimal));
                    dtFinalResult.Columns.Add("Location", typeof(string));
                    dtFinalResult.Columns.Add("Phone_Number", typeof(string));

                    #endregion

                    for (int i = 6; i < dtResult.Rows.Count; i++)
                    {
                        string paintCategory = string.Empty;
                        paintCategory = Convert.ToString(dtResult.Rows[i][0]);
                        Int64 fK_LU_VOC_Category;
                        fK_LU_VOC_Category = clsLU_VOC_Category.SelectPKByCategory(paintCategory);

                        if (fK_LU_VOC_Category > 0)
                        {
                            subTotalText += paintCategory + ",";
                            categoriIds += fK_LU_VOC_Category + ",";

                            for (int column = 1; column < dtResult.Columns.Count; column += 2)
                            {
                                decimal Gallons = 0, VOCEmissions = 0, PK_PM_Permit_ID;
                                string Location = string.Empty, Phone_Number = string.Empty;

                                if ((column % 2) == 1)
                                {
                                    Location = Convert.ToString(dtResult.Rows[4][column]);
                                    Phone_Number = Convert.ToString(dtResult.Rows[1][column]);
                                }

                                if (Convert.ToString(dtResult.Rows[5][column]).ToUpper() == "GALLONS OF PRODUCT PURCHASED" && Convert.ToString(dtResult.Rows[5][column + 1]).ToUpper() == "VOC (LBS)")
                                {
                                    Gallons = Convert.ToDecimal(dtResult.Rows[i][column]);
                                    VOCEmissions = Convert.ToDecimal(dtResult.Rows[i][column + 1]);
                                }

                                PK_PM_Permit_ID = PM_Permits.SelectByLocationAndPhoneNumber(Location, Phone_Number);

                                if (PK_PM_Permit_ID == 1)
                                { }
                                else
                                {
                                    if (PK_PM_Permit_ID > 0)
                                    {
                                        if (i == 6)
                                        {
                                            pkIds += PK_PM_Permit_ID + ",";
                                        }

                                        dtFinalResult.Rows.Add(fK_LU_VOC_Category, Gallons, VOCEmissions, Location, Phone_Number);
                                        strFinal += "<Section><FK_PM_Permits>" + PK_PM_Permit_ID + "</FK_PM_Permits><Year>" + year + "</Year><Month>" + month + "</Month><Paint_Category>" + fK_LU_VOC_Category + "</Paint_Category><Part_Number>" + null + "</Part_Number><Unit>" + null + "</Unit><Quantity>" + null + "</Quantity><Gallons>" + clsGeneral.GetDecimal(Gallons) + "</Gallons><VOC_Emissions>" + clsGeneral.GetDecimal(VOCEmissions) + "</VOC_Emissions><Updated_By>" + clsSession.UserID + "</Updated_By></Section>";
                                    }
                                    else
                                    {
                                        DataTable dt = LU_Location.SelectByPhoneNumberAndLocation(Location, Phone_Number).Tables[0];
                                        fk_LU_Location_ID = clsGeneral.GetDecimal(dt.Rows[0][0]);

                                        if (fk_LU_Location_ID > 0)
                                        {
                                            FK_Building_ID = clsGeneral.GetDecimal(dt.Rows[0][1]);

                                            if (FK_Building_ID > 0)
                                            {
                                                decimal PK_PM_Site_Information;

                                                PK_PM_Site_Information = PM_Site_Information.SelectByLocationAndBuilding(fk_LU_Location_ID, FK_Building_ID);

                                                if (PK_PM_Site_Information > 0)
                                                {
                                                    PM_Permits objPM_Permits = new PM_Permits();
                                                    objPM_Permits.FK_PM_Site_Information = PK_PM_Site_Information;
                                                    objPM_Permits.FK_Permit_Type = 1;
                                                    objPM_Permits.Updated_By = clsSession.UserID;
                                                    objPM_Permits.Update_Date = DateTime.Now;
                                                    PK_PM_Permit_ID = objPM_Permits.Insert();
                                                }
                                                else
                                                {
                                                    PM_Site_Information objPM_Site_Information = new PM_Site_Information();
                                                    objPM_Site_Information.FK_LU_Location = fk_LU_Location_ID;
                                                    objPM_Site_Information.FK_Building = FK_Building_ID;
                                                    PK_PM_Site_Information = objPM_Site_Information.Insert();

                                                    if (PK_PM_Site_Information > 0)
                                                    {
                                                        PM_Permits objPM_Permits = new PM_Permits();
                                                        objPM_Permits.FK_PM_Site_Information = PK_PM_Site_Information;
                                                        objPM_Permits.FK_Permit_Type = 1;
                                                        objPM_Permits.Updated_By = clsSession.UserID;
                                                        objPM_Permits.Update_Date = DateTime.Now;
                                                        PK_PM_Permit_ID = objPM_Permits.Insert();
                                                    }
                                                }

                                                strFinal += "<Section><FK_PM_Permits>" + PK_PM_Permit_ID + "</FK_PM_Permits><Year>" + year + "</Year><Month>" + month + "</Month><Paint_Category>" + fK_LU_VOC_Category + "</Paint_Category><Part_Number>" + null + "</Part_Number><Unit>" + null + "</Unit><Quantity>" + null + "</Quantity><Gallons>" + clsGeneral.GetDecimal(Gallons) + "</Gallons><VOC_Emissions>" + clsGeneral.GetDecimal(VOCEmissions) + "</VOC_Emissions><Updated_By>" + clsSession.UserID + "</Updated_By></Section>";
                                            }
                                        }
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(strFinal))
                            {
                                strFinal = "<ImportXML>" + strFinal + "</ImportXML>";

                                clsPM_Permits_VOC_Emissions.ImportXML(strFinal, string.Empty);

                                if (!string.IsNullOrEmpty(pkIds) && pkIds.Contains(","))
                                {
                                    string[] pkPermitId = pkIds.Split(',');
                                    int countPKId = 0;

                                    foreach (string pkId in pkPermitId)
                                    {
                                        if (!string.IsNullOrEmpty(pkId))
                                        {
                                            decimal pkID = Convert.ToDecimal(pkPermitId[countPKId]);

                                            if (!string.IsNullOrEmpty(categoriIds) && categoriIds.Contains(","))
                                            {
                                                string[] voc_Category = categoriIds.Split(',');
                                                string[] subTotalTextData = subTotalText.Split(',');
                                                int count = 0;

                                                foreach (string voc_categoryId in voc_Category)
                                                {
                                                    if (!string.IsNullOrEmpty(voc_categoryId))
                                                    {
                                                        clsPM_Permits_VOC_Emissions.UpdateSubTotal(subTotalTextData[count], Convert.ToInt32(voc_categoryId), pkID, month, year, Convert.ToString(DateTime.Now), Convert.ToString(clsSession.UserID), true);
                                                        count++;
                                                    }
                                                }
                                            }
                                            countPKId++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    divVOCData.Visible = false;
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('File Imported Successfully');", true);
                }
            }

            catch 
            {
                divVOCData.Visible = false;
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Selected File can not be Imported.');", true);
            }
            finally
            {
                // delete uploaded file
                DeleteUploadedFile(strUploadedFile);
            }
        }
        else
        {
            if (ddlFileType.SelectedIndex == 1)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Select only CSV File.');", true);
            }
            else if (ddlFileType.SelectedIndex == 2)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Select only XLSX File.');", true);
            }
        }
    }

    /// <summary>
    /// button Cancel Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_Permits.aspx?id=" + Encryption.Encrypt(PK_PM_Permits.ToString()) + "&op=edit" + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location)));
    }

    /// <summary>
    /// Drop Down Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlFileType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFileType.SelectedIndex == 2)
        {
            trFileType.Visible = false;
            tr.Visible = false;
        }
        else
        {
            trFileType.Visible = true;
            tr.Visible = true;
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Deletes exported spreadsheet
    /// </summary>
    /// <param name="strFile">Filename along with path which is to be deleted</param>
    private void DeleteUploadedFile(string strFile)
    {
        // check if filename is not blank
        if (strFile != "")
        {
            // check whether file exists or not
            if (File.Exists(AppConfig.BuildingAttachDocPath + strFile))
            {
                // delete the file
                File.Delete(AppConfig.BuildingAttachDocPath + strFile);
            }
        }
    }

    /// <summary>
    /// Binds all dropdowns
    /// </summary>
    private void BindDropdowns()
    {
        ComboHelper.BindMonth(ddlMonth);
        ddlMonth.Items.Insert(0, new ListItem("-- Select --", "0"));
        ComboHelper.FillYear(new DropDownList[] { ddlYear }, true);
        ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocation }, 0, true, true);
        ddlLocation.Enabled = false;
    }

    /// <summary>
    /// Calculate the SubTotal 
    /// </summary>
    /// <param name="dtVOC"></param>
    /// <returns></returns>
    public decimal GetSubTotal(DataTable dtVOC)
    {
        decimal subtotalCalculate = 0;
        foreach (DataRow drField in dtVOC.Rows)
        {
            if (drField["Quantity"] != null)
            {
                subtotalCalculate += clsGeneral.GetDecimal(drField["Quantity"]) * clsGeneral.GetDecimal(drField["Gallons"]);
            }
        }

        return subtotalCalculate;
    }

    #endregion


}