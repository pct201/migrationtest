using ERIMS.DAL;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_FacilityInspectionList : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private string OperationMode
    {
        get { return Convert.ToString(ViewState["OperationMode"]); }
        set { ViewState["OperationMode"] = value; }
    }

    #endregion

    #region Page Load Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["loc"] != null)
            {
                Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.FacilityInspection);
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                }
                else
                    Response.Redirect("ExposureSearch.aspx");

                Session["ExposureLocation"] = FK_LU_Location_ID;

                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();

                // Bind Grid
                BindGrid();
                OperationMode = "View";
            }
            else
            {
                Response.Redirect("ExposureSearch.aspx");
            }
        }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Grid View Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInspection_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "InspectionDetails")
        {
            Response.Redirect(String.Format("FacilityInspection.aspx?loc={0}&item={1}&op={2}", Request.QueryString["loc"].ToString(), Encryption.Encrypt(e.CommandArgument.ToString()), OperationMode));
        }
        else if (e.CommandName == "Prepare")
        {
            string fileName = this.PrepareInspectionReport(Convert.ToInt64(e.CommandArgument));
            ScriptManager.RegisterStartupScript(this, GetType(), "btnSave", "javascript: window.open('" + AppConfig.SiteURL + "/Download.aspx?inspection=true&fileName=" + fileName + "&orgName=InspectionItemReport.xlsx','_blank')", true);
        }
        else if (e.CommandName == "Mail")
        {
            string fileName = this.PrepareInspectionReport(Convert.ToInt64(e.CommandArgument));
            ScriptManager.RegisterStartupScript(this, GetType(), "openAttachmentPoppup", "javascript:SendInspectionEmail('" + fileName + "');", true);
        }
    }

    /// <summary>
    /// Button Edit Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        trAddNew.Visible = true;
        OperationMode = "Edit";
    }

    protected void lnkAddNewInspection_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("FacilityInspection.aspx?loc={0}", Request.QueryString["loc"].ToString()));
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Method to Bind Grid
    /// </summary>
    private void BindGrid()
    {
        gvInspection.DataSource = Facility_Construction_Inspection.SelectByLocation(FK_LU_Location_ID).Tables[0];
        gvInspection.DataBind();
    }

    /// <summary>
    /// Method to prepare inspection report details
    /// </summary>
    /// <param name="pK_Facility_Construction_Inspection"></param>
    /// <returns></returns>
    private string PrepareInspectionReport(Int64 pK_Facility_Construction_Inspection)
    {
        DataTable dtInspection = Facility_Construction_Inspection.SelectByPkInpsection(Convert.ToInt32(pK_Facility_Construction_Inspection)).Tables[0];
        DataRow drInspectionRow = dtInspection.Rows[0];

        // Code to Export To Excel From List            
        ExcelPackage wb = new ExcelPackage();
        // XLWorkbook wb = new XLWorkbook();
        ExcelWorksheet ws = wb.Workbook.Worksheets.Add("InspectionItemReport.xlsx");
        // Add Title
        ws.Cells["A1"].Value = "eRims2 Construction Project Management Inspection Item Report";
        ws.Cells["D1"].Value = "Date : " + clsGeneral.FormatDateToDisplay(DateTime.Now);

        ws.Cells["A3"].Value = "Building Number : " + Convert.ToString(drInspectionRow["Building_Number"]);
        ws.Column(1).Width = ws.Cells["A3"].Value.ToString().Length + 10;

        ws.Cells["A4"].Value = "Location : " + Convert.ToString(drInspectionRow["Location"]);
        ws.Column(1).Width = ws.Cells["A4"].Value.ToString().Length + 10;

        ws.Cells["A5"].Value = "Inspector : " + Convert.ToString(drInspectionRow["Inspector"]);
        ws.Column(1).Width = ws.Cells["A5"].Value.ToString().Length + 10;

        ws.Cells["A6"].Value = "Inspection Date : " + (!string.IsNullOrEmpty(Convert.ToString(drInspectionRow["Inspection_Date"])) ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drInspectionRow["Inspection_Date"])) : "");
        ws.Column(1).Width = ws.Cells["A6"].Value.ToString().Length + 10;

        int count = 0;
        char startCharCols = 'A';
        int startIndexCols = 8;
        #region CreatingColumnHeaders

        string DataCell = startCharCols.ToString() + startIndexCols;
        ws.Cells[DataCell].Value = "ITEM";
        ws.Column(1).Width = ws.Cells[DataCell].Value.ToString().Length + 50;
        ws.Cells[DataCell].Style.Font.Bold = true;
        ws.Cells[DataCell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        ws.Cells[DataCell].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        startCharCols++;

        DataCell = startCharCols.ToString() + startIndexCols;
        ws.Cells[DataCell].Value = "Condition";
        ws.Column(2).Width = ws.Cells[DataCell].Value.ToString().Length + 15;
        ws.Cells[DataCell].Style.Font.Bold = true;
        ws.Cells[DataCell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        ws.Cells[DataCell].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        count++;
        startCharCols++;

        DataCell = startCharCols.ToString() + startIndexCols;
        ws.Cells[DataCell].Value = "Est Cost";
        ws.Column(3).Width = ws.Cells[DataCell].Value.ToString().Length + 15;
        ws.Cells[DataCell].Style.Font.Bold = true;
        ws.Cells[DataCell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        ws.Cells[DataCell].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        count++;
        startCharCols++;

        DataCell = startCharCols.ToString() + startIndexCols;
        ws.Cells[DataCell].Value = "Est Start Date";
        ws.Column(4).Width = ws.Cells[DataCell].Value.ToString().Length + 15;
        ws.Cells[DataCell].Style.Font.Bold = true;
        ws.Cells[DataCell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        ws.Cells[DataCell].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

        count++;
        startCharCols++;

        DataCell = startCharCols.ToString() + startIndexCols;
        ws.Cells[DataCell].Value = "Assigned To";
        ws.Column(5).Width = ws.Cells[DataCell].Value.ToString().Length + 15;
        ws.Cells[DataCell].Style.Font.Bold = true;
        ws.Cells[DataCell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        ws.Cells[DataCell].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        count++;

        string Range = "A1:C1";
        ws.Cells[Range].Merge = true;
        ws.Cells[Range].Style.Font.Size = 14;
        ws.Cells[Range].Style.Font.Bold = true;

        ws.Cells[Range].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; //  .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
        ws.Cells[Range].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;//.SetHorizontal(XLAlignmentHorizontalValues.Left);
        ws.Cells[Range].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);//  LeftBorder = XLBorderStyleValues.Thin;            

        Range = "A2:" + startCharCols.ToString() + "2";
        ws.Cells[Range].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

        Range = "A3:E7";
        ws.Cells[Range].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        ws.Cells[Range].Style.Font.Bold = true;

        Range = "D1:E1";
        ws.Cells[Range].Merge = true;
        ws.Cells[Range].Style.Font.Size = 14;
        ws.Cells[Range].Style.Font.Bold = true;

        ws.Cells[Range].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; //  .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
        ws.Cells[Range].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;//.SetHorizontal(XLAlignmentHorizontalValues.Left);
        ws.Cells[Range].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);//  LeftBorder = XLBorderStyleValues.Thin;            

        Color colFromHexForInspection = System.Drawing.ColorTranslator.FromHtml("#A4A4A4");
        ws.Cells["A8:E8"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        ws.Cells["A8:E8"].Style.Fill.BackgroundColor.SetColor(colFromHexForInspection);

        #endregion

        char startCharData = 'A';
        int startIndexData = 10;

        #region Column Rows Binding

        if (!string.IsNullOrEmpty(Convert.ToString(drInspectionRow["FK_Facility_Inspection_Area"])))
        {
            ws.Cells["A9"].Value = Convert.ToString(drInspectionRow["FocusArea"]).ToUpper();
            ws.Cells["A9"].Style.WrapText = true;
            ws.Cells["A9"].Style.Font.Bold = true;
            ws.Cells["A9:E9"].Merge = true;
            ws.Cells["A9:E9"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            ws.Cells["A9:E9"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#D8D8D8");
            ws.Cells["A9:E9"].Style.Fill.BackgroundColor.SetColor(colFromHex);

            foreach (DataRow drInspectionItem in dtInspection.Rows)
            {
                string dataCellRow = startCharData.ToString() + startIndexData;

                ws.Cells[dataCellRow].Value = Convert.ToString(drInspectionItem["Description"]);
                ws.Cells[dataCellRow].Style.WrapText = true;
                ws.Cells[dataCellRow].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                startCharData++;

                dataCellRow = startCharData.ToString() + startIndexData;
                ws.Cells[dataCellRow].Value = Convert.ToString(drInspectionItem["Condition"]);
                ws.Cells[dataCellRow].Style.WrapText = true;
                ws.Cells[dataCellRow].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                startCharData++;

                dataCellRow = startCharData.ToString() + startIndexData;
                ws.Cells[dataCellRow].Value = !string.IsNullOrEmpty(Convert.ToString(drInspectionItem["Estimated_Cost"])) ? "$ " + clsGeneral.FormatCommaSeperatorCurrency(drInspectionItem["Estimated_Cost"]) : "";
                ws.Cells[dataCellRow].Style.WrapText = true;
                ws.Cells[dataCellRow].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                startCharData++;

                dataCellRow = startCharData.ToString() + startIndexData;
                ws.Cells[dataCellRow].Value = !string.IsNullOrEmpty(Convert.ToString(drInspectionItem["Estimate_Start_Date"])) ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drInspectionItem["Estimate_Start_Date"])) : "";
                ws.Cells[dataCellRow].Style.WrapText = true;
                ws.Cells[dataCellRow].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                startCharData++;

                dataCellRow = startCharData.ToString() + startIndexData;
                ws.Cells[dataCellRow].Value = Convert.ToString(drInspectionItem["AssignedTo"]);
                ws.Cells[dataCellRow].Style.WrapText = true;
                ws.Cells[dataCellRow].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                startCharData = 'A';
                startIndexData++;
            }
        }

        #endregion

        // Save data to file

        // Flush the workbook to the Response.OutputStream
        using (MemoryStream memoryStream = new MemoryStream())
        {
            System.IO.DirectoryInfo directoryName = new DirectoryInfo(clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.InspectionReport]));
            if (!Directory.Exists(directoryName.ToString()))
            {
                Directory.CreateDirectory(directoryName.ToString());
            }

            foreach (FileInfo file in directoryName.GetFiles())
            {
                try
                {
                    if (file.CreationTime.Hour <= (DateTime.Now.Hour - 2))
                    {
                        file.Delete();
                    }
                }
                catch
                {
                }
            }

            wb.SaveAs(memoryStream);
            Byte[] bin = memoryStream.ToArray();
            string fileName = Convert.ToString(Guid.NewGuid()) + ".xlsx";

            string strfile = string.Format(directoryName.ToString() + "\\" + fileName);
            FileStream fs = new FileStream(strfile, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bin);
            bw.Close();
            return fileName;
        }
    }

    #endregion

}