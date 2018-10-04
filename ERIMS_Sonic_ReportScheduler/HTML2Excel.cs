using System;
using System.Text;
using HtmlAgilityPack;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using OfficeOpenXml.Drawing;


public class HTML2Excel
{
    private string _htmlData;
    ExcelPackage excelWorkbook;
    ExcelWorksheet excelWorksheet;
    int currRowNumber = 1, currColumnNumber = 1, totalNoOfColumnsInRow = 0;
    int nextRow = 1, MaxRowsinColumn = 1;
    int MaxColumnInRow = 1;
    StringBuilder styleBuilder = new StringBuilder();
    Hashtable htGridCells = new Hashtable();
    Hashtable htGridCellsRows = new Hashtable();
    Hashtable htMergedCells = new Hashtable();
    Hashtable htMergedRows = new Hashtable();
    Hashtable htGridRow = new Hashtable();
    Stack cellStack = new Stack();
    bool isTH = false;
    public bool isGrid = false;
    HtmlNode hNodeGlobal;
    bool applycolSpan = false;
    bool isNestedTable = false;
    public bool isUseCSS = false;
    ArrayList blankRows = new ArrayList();
    int nestedLevel = 0;
    double fixWidth = 950;

    bool HasInnerTable = false;
    double minWidth = 25, maxWidth = 150;
    Hashtable htTableCols = new Hashtable();
    bool colSpanSet = false;
    Hashtable htColStyles = new Hashtable();
    public string imagePath = string.Empty;
    bool isPercentWidthSet = false;
    public List<System.Collections.Generic.KeyValuePair<int, double>> columnWidth = new List<KeyValuePair<int, double>>();
    public bool overwriteBorder = true;

    struct tabledef
    {
        public int noOfColumn;
        public int noOfRow;
        public int ColumnID;
        public int RowID;
        public tabledef(int Row, int Column)
        {
            noOfRow = 0;
            noOfColumn = 0;
            ColumnID = 0;
            RowID = 0;
        }
    }
    public HTML2Excel()
    {

    }
    public HTML2Excel(string HTMLData)
    {
        _htmlData = HTMLData;
    }

    public bool Convert2Excel(string outputPath)
    {
        excelWorkbook = new ExcelPackage();
        excelWorksheet = excelWorkbook.Workbook.Worksheets.Add("Report");
        //isGrid = true;
        _htmlData = _htmlData.Replace("<div>", "").Replace("</div>", "");
        _htmlData = _htmlData.Replace("&amp;", "&");

        HtmlDocument hDoc = new HtmlDocument();

        hDoc.LoadHtml(_htmlData);

        if (isUseCSS)
        {
            string cssFile = AppDomain.CurrentDomain.BaseDirectory + @"ERIMS.css";
            GetStyleSheet(cssFile);
        }
        HtmlNodeCollection hNodes = hDoc.DocumentNode.ChildNodes;

        foreach (HtmlNode hNode in hNodes)
        {
            CountDetails(hNode);
            switch (hNode.Name.ToUpper())
            {
                case "TABLE": HandleTABLENode(hNode); break;
                case "TR": HandleTRNode(hNode, false); break;
                case "TD": HandleTDNode(hNode); break;
                default: HandleOtherNode(hNode); break;
            }
        }

        excelWorksheet.View.ShowGridLines = false;
        int totalRows = currRowNumber;
        for (currRowNumber = 1; currRowNumber <= totalRows; currRowNumber++)
            MergeColumns();


        if (isGrid)
        {
            //using (ExcelRange range = excelWorksheet.Cells[1, 1, currRowNumber - 2, MaxColumnInRow])
            //{
            //    range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //    Border border = range.Style.Border;
            //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
            //    range.Style.Font.Size = 10;
            //}

            int RowDeleted = 0;
            for (int rowNo = 1; rowNo <= totalRows; rowNo++)
            {
                bool isBlankRow = true;
                int tempRow = rowNo - RowDeleted;
                for (int colInRow = 1; colInRow <= MaxColumnInRow; colInRow++)
                {
                    if (!string.IsNullOrEmpty(excelWorksheet.Cells[tempRow, colInRow].Text))
                        isBlankRow = false;
                }
                if (isBlankRow)
                {
                    excelWorksheet.DeleteRow(tempRow, 1, true);
                    RowDeleted++;
                }
            }
        }

        //excelWorksheet.Cells.AutoFitColumns();

        //excelWorksheet.Cells[1, MaxColumnInRow + 1, totalRows + 1, excelWorksheet.Cells.Columns].Clear();
        using (ExcelRange range = excelWorksheet.Cells[1, 1, currRowNumber - 2, MaxColumnInRow])
        {
            if (!isPercentWidthSet)
                range.AutoFitColumns(minWidth, maxWidth);
            range.Style.WrapText = true;
        }
        if (columnWidth.Count == 0)
        {
            if (!isPercentWidthSet)
                excelWorksheet.Cells.AutoFitColumns(minWidth, maxWidth);
        }
        else
        {
            foreach (KeyValuePair<int, double> colWidth in columnWidth)
            {
                excelWorksheet.Column(colWidth.Key).Width = colWidth.Value;
            }
        }
        //excelWorksheet.Cells.Style.WrapText = true;

        Byte[] bin = excelWorkbook.GetAsByteArray();

        File.WriteAllBytes(outputPath, bin);

        _htmlData = null;
        //excelWorksheet.Dispose();
        //excelWorkbook.Dispose();



        //File.WriteAllText(@"D:\R & D Work\style.txt", styleBuilder.ToString());

        return true;
    }

    private int HandleTRNode(HtmlNode hNode, bool hasBorder)
    {
        int tempCol = currColumnNumber;
        //nextRow = currRowNumber++;
        MaxRowsinColumn = 1;
        bool columnChanged = false;
        foreach (HtmlNode childNode in hNode.ChildNodes)
        {
            if (childNode.Name != "#text")
            {
                if (htGridCells.Contains(currColumnNumber + 1) && !isNestedTable && !columnChanged)
                {
                    currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]);
                    columnChanged = true;
                }
                switch (childNode.Name.ToUpper())
                {
                    case "TABLE": HandleTABLENode(childNode); break;
                    case "TR": HandleTRNode(childNode, hasBorder); break;

                    case "TD":
                        foreach (HtmlAttribute trAttrib in hNode.Attributes)
                        {
                            if (trAttrib.Name.ToUpper() != "BORDER")
                                childNode.Attributes.Add(trAttrib);
                        }
                        HandleTDNode(childNode);
                        currColumnNumber++;
                        break;
                    case "TH":
                        isTH = true;
                        HandleTDNode(childNode);
                        currColumnNumber++;
                        isTH = false;
                        break;
                }
            }
        }

        //if (!isNestedTable)
        //    MergeColumns();

        //if (hasBorder && currColumnNumber > 1)
        //{
        //    using (ExcelRange range = excelWorksheet.Cells[currRowNumber, 1, currRowNumber, currColumnNumber - 1])
        //    {
        //        range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        //        Border border = range.Style.Border;
        //        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
        //    }
        //}

        int nestedColumns = currColumnNumber - tempCol;
        Color color = Color.Black;
        Color backColor = Color.White;
        bool bold = false, isBoldSet = false, isColorSet = false, isBackcolorSet = false, isFontFamilySet = false;
        string fontFamilty = "Calibri";
        //float font_size = 11;

        #region Style Attributes
        foreach (HtmlAttribute trAttrib in hNode.Attributes)
        {
            //styleBuilder.AppendLine("Name : "+tdAttrib.Name + "    Value :"+tdAttrib.Value);
            switch (trAttrib.Name)
            {
                case "style":
                    string styleVal = trAttrib.Value;
                    string[] styleCollection = styleVal.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string styleAttrib in styleCollection)
                    {
                        string[] nodeVal = styleAttrib.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        if (nodeVal.Length > 1)
                        {
                            switch (nodeVal[0].Trim())
                            {
                                case "color":
                                    color = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                    isColorSet = true;
                                    //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Color.SetColor(color);
                                    break;
                                //case "font-family":
                                //    fontFamilty = nodeVal[1].Trim();
                                //    isFontFamilySet = true;
                                //    break;
                                //case "font-size":
                                //    font_size = float.Parse(nodeVal[1].Trim().Replace("pt", ""));
                                //    break;
                                case "font-weight":
                                    bold = true;
                                    isBoldSet = true;
                                    break;
                                case "background-color":
                                    if (nodeVal[1].ToLower().Contains("rgb"))
                                    {
                                        string[] tempColor = nodeVal[1].Trim().Replace("rgb", "").Replace("(", "").Replace(")", "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        backColor = Color.FromArgb(Convert.ToInt32(tempColor[1]), Convert.ToInt32(tempColor[2]), Convert.ToInt32(tempColor[2]));
                                    }
                                    else
                                        backColor = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                    isBackcolorSet = true;
                                    break;
                                case "border-right":
                                    //if (NoOfCol > 0 && tdAttrib.Value != "0")
                                    using (ExcelRange range = excelWorksheet.Cells[currRowNumber, currColumnNumber - 2, currRowNumber, currColumnNumber - 1])
                                    {
                                        //range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                        Border border = range.Style.Border;
                                        border.Right.Style = ExcelBorderStyle.Thin;
                                    }
                                    break;
                                case "border-left":
                                    //if (NoOfCol > 0 && tdAttrib.Value != "0")
                                    using (ExcelRange range = excelWorksheet.Cells[currRowNumber, tempCol, currRowNumber, tempCol])
                                    {
                                        //range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                        Border border = range.Style.Border;
                                        border.Left.Style = ExcelBorderStyle.Thin;
                                    }
                                    break;
                            }
                        }

                    }

                    break;
                case "class":
                    if (isUseCSS)
                    {
                        string[] styleCollection1 = GetCssClassProperty(parts, trAttrib.Value);
                        foreach (string styleAttrib in styleCollection1)
                        {
                            string[] nodeVal = styleAttrib.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                            if (nodeVal.Length > 1)
                            {
                                switch (nodeVal[0].Trim())
                                {
                                    case "color":
                                        color = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                        isColorSet = true;
                                        //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Color.SetColor(color);
                                        break;
                                    //case "font-family":
                                    //    fontFamilty = nodeVal[1].Trim();
                                    //    isFontFamilySet = true;
                                    //    break;
                                    //case "font-size":
                                    //    font_size = float.Parse(nodeVal[1].Trim().Replace("pt", ""));
                                    //    break;
                                    case "font-weight":
                                        bold = true;
                                        isBoldSet = true;
                                        break;
                                    case "background-color":
                                        if (nodeVal[1].ToLower().Contains("rgb"))
                                        {
                                            string[] tempColor = nodeVal[1].Trim().Replace("rgb", "").Replace("(", "").Replace(")", "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                            backColor = Color.FromArgb(Convert.ToInt32(tempColor[1]), Convert.ToInt32(tempColor[2]), Convert.ToInt32(tempColor[2]));
                                        }
                                        else
                                            backColor = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                        isBackcolorSet = true;
                                        break;
                                }
                            }

                        }
                    }
                    break;

                case "border":
                    if (trAttrib.Value != "0")
                        using (ExcelRange range = excelWorksheet.Cells[currRowNumber, tempCol, currRowNumber, tempCol])
                        {
                            range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            Border border = range.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        }
                    //else
                    //{
                    //    using (ExcelRange range = excelWorksheet.Cells[currRowNumber, tempCol, currRowNumber, tempCol])
                    //    {
                    //        range.Style.Border.BorderAround(ExcelBorderStyle.None);
                    //        Border border = range.Style.Border;
                    //        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.None;
                    //    }
                    //}
                    break;
            }
        }
        if (hNode.Attributes.Count > 0)
        {
            if (currColumnNumber - 1 > 0 && tempCol <= currColumnNumber - 1)
                using (ExcelRange range = excelWorksheet.Cells[currRowNumber, tempCol, currRowNumber, currColumnNumber - 1])
                {

                    //excelWorksheet.Cells["AN7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //excelWorksheet.Cells["AN7"].Style.Font.Bold = true;
                    //excelWorksheet.Cells["AN7"].Style.Fill.BackgroundColor.SetColor(Color.Beige);
                    //excelWorksheet.Cells["AN7"].Style.Font.Color.SetColor(color);

                    //ExcelNamedStyleXml namedStyle = excelWorksheet.Workbook.Styles.CreateNamedStyle(mergeCells.Replace(":", ""));
                    //namedStyle.Style.Font.SetFromFont(new Font(fontFamilty, font_size));
                    //namedStyle.Style.Font.Color.SetColor(Color.White);
                    if (isBackcolorSet)
                    {
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(backColor);
                    }

                    if (range.IsRichText)
                    {
                        for (int tempCol1 = tempCol; tempCol1 < currColumnNumber; tempCol1++)
                        {
                            if (excelWorksheet.Cells[GetExcelColumnName(tempCol1, currRowNumber)].IsRichText)
                            {
                                ExcelRichTextCollection rtfCollection1 = excelWorksheet.Cells[GetExcelColumnName(tempCol1, currRowNumber)].RichText;
                                foreach (ExcelRichText tempRichtext in rtfCollection1)
                                {
                                    if (isColorSet)
                                        tempRichtext.Color = color;
                                    if (isBoldSet)
                                        tempRichtext.Bold = bold;
                                }
                                //if (isFontFamilySet)
                                //    rtfCollection1[0].FontName = fontFamilty;
                                //rtfCollection1[0].Size = font_size;
                            }
                        }
                    }


                    //range.StyleName = namedStyle.Name;

                }
        }
        #endregion

        if ((currColumnNumber - tempCol) > MaxColumnInRow)
            MaxColumnInRow = currColumnNumber - tempCol;

        if (!isNestedTable)
            currColumnNumber = 1;
        else
            currColumnNumber = tempCol;

        if (!applycolSpan && hNode.ChildNodes.Count == 1)
        {
            hNodeGlobal = hNode;
            applycolSpan = true;
        }
        else if (applycolSpan)
        {
            //hNode.ChildNodes.Count;
            applycolSpan = false;
        }

        if (!htTableCols.Contains(currRowNumber))
        {
            htTableCols.Add(currRowNumber, MaxColumnInRow);
        }
        else
        {
            if (Convert.ToInt32(htTableCols[currRowNumber]) > MaxColumnInRow)
            {
                MaxColumnInRow = Convert.ToInt32(htTableCols[currRowNumber]);
            }
            else
            {
                htTableCols[currRowNumber] = MaxColumnInRow;
            }
        }

        return nestedColumns;
    }

    private void HandleTDNode(HtmlNode hNode)
    {
        string colVal = hNode.InnerText;
        colVal = colVal.Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">");
        Color color = Color.Black;
        bool isUnderline = false;
        bool isBold = false;
        int tempColspanCol = currColumnNumber;
        int noOfColspan = 0;
        ExcelHorizontalAlignment cellAlign = ExcelHorizontalAlignment.General;
        bool alignSet = false;
        colSpanSet = false;
        #region Style Attributes
        if (hNode.Attributes.Contains("colspan"))
        {
            noOfColspan = Convert.ToInt32(hNode.Attributes["colspan"].Value) - 1;
        }
        foreach (HtmlAttribute tdAttrib in hNode.Attributes)
        {
            //styleBuilder.AppendLine("Name : "+tdAttrib.Name + "    Value :"+tdAttrib.Value);
            switch (tdAttrib.Name)
            {
                case "colspan":
                    try
                    {
                        string mergeCells = GetExcelColumnName(currColumnNumber, currRowNumber) + ":" + GetExcelColumnName(currColumnNumber + Convert.ToInt32(tdAttrib.Value) - 1, currRowNumber);
                        if (!excelWorksheet.Cells[mergeCells].Merge)
                        {
                            excelWorksheet.Cells[mergeCells].Merge = true;

                            excelWorksheet.Cells[mergeCells].AutoFitColumns(minWidth * (Convert.ToInt32(tdAttrib.Value) - 1), maxWidth * (Convert.ToInt32(tdAttrib.Value) - 1));
                            tempColspanCol = currColumnNumber + Convert.ToInt32(tdAttrib.Value) - 1;
                            colSpanSet = true;
                            if (alignSet)
                                excelWorksheet.Cells[mergeCells].Style.HorizontalAlignment = cellAlign;
                        }
                        //using (ExcelRange range = excelWorksheet.Cells[mergeCells])
                        //{
                        //    range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        //    Border border = range.Style.Border;
                        //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        //}
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case "style":
                    string styleVal = tdAttrib.Value;
                    string[] styleCollection = styleVal.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string styleAttrib in styleCollection)
                    {
                        string[] nodeVal = styleAttrib.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        if (nodeVal.Length > 1)
                        {
                            switch (nodeVal[0].Trim())
                            {
                                case "color":
                                    color = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                    excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Color.SetColor(color);
                                    break;
                                case "font-weight":
                                    if (nodeVal[1].ToLower().Trim() == "bold")
                                    {
                                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Bold = true;
                                        isBold = true;
                                    }
                                    break;
                                case "background-color":
                                    Color backcolor = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                    excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Fill.BackgroundColor.SetColor(backcolor);
                                    if (!htColStyles.Contains(currRowNumber + ":" + currColumnNumber))
                                    {
                                        htColStyles.Add(currRowNumber + ":" + currColumnNumber, backcolor);
                                    }
                                    break;
                                //case "width":
                                //    //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].
                                //    string tempWidth = nodeVal[1].Trim().ToLower().Replace("px", "");
                                //    if (!tempWidth.Contains("%"))
                                //        excelWorksheet.Column(currColumnNumber).Width = (Convert.ToInt32(tempWidth) - 12) / 7d;
                                //    else if (!tempWidth.Contains("100%"))
                                //    {
                                //        excelWorksheet.Column(currColumnNumber).Width = (((fixWidth * Convert.ToInt32(tempWidth.Replace("%", ""))) / 100) - 12 + 5) / 7d + 1;
                                //        isPercentWidthSet = true;
                                //    }
                                //    break;
                                case "border":
                                    if (tdAttrib.Value != "0")
                                        using (ExcelRange range = excelWorksheet.Cells[currRowNumber, currColumnNumber, currRowNumber, currColumnNumber + noOfColspan])
                                        {
                                            range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                            Border border = range.Style.Border;
                                            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                                        }
                                    break;
                            }
                        }

                    }

                    break;
                case "bgcolor":
                    Color backcolor1 = ColorTranslator.FromHtml(tdAttrib.Value);
                    excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Fill.BackgroundColor.SetColor(backcolor1);
                    if (!htColStyles.Contains(currRowNumber + ":" + currColumnNumber))
                    {
                        htColStyles.Add(currRowNumber + ":" + currColumnNumber, backcolor1);
                    }
                    break;
                case "align":
                    if (tdAttrib.Value.ToLower() == "right")
                    {
                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        cellAlign = ExcelHorizontalAlignment.Right;
                        alignSet = true;
                    }
                    if (tdAttrib.Value.ToLower() == "left")
                    {
                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        cellAlign = ExcelHorizontalAlignment.Left;
                        alignSet = true;
                    }
                    if (tdAttrib.Value.ToLower() == "center")
                    {
                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cellAlign = ExcelHorizontalAlignment.Center;
                        alignSet = true;
                    }
                    break;
                case "valign":
                    if (tdAttrib.Value.ToLower() == "top")
                    {
                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    }
                    if (tdAttrib.Value.ToLower() == "bottom")
                    {
                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;
                    }
                    if (tdAttrib.Value.ToLower() == "middle")
                    {
                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }
                    break;
            }
        }
        #endregion

        if (hNode.HasChildNodes)
        {
            int count = hNode.ChildNodes.Count;

            foreach (HtmlNode childNode in hNode.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case "b":

                        //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Bold = true;

                        if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
                        {
                            currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]);
                        }
                        ExcelRichTextCollection rtfCollection = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                        ExcelRichText tempText = rtfCollection.Add(childNode.InnerText.Trim().Replace("\r\n", "").Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("<br>", "\r\n"));
                        tempText.Bold = true;
                        tempText.PreserveSpace = true;
                        if (color != Color.Black)
                        {
                            tempText.Color = color;
                        }
                        break;

                    case "#text":
                        //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Value = colVal;
                        string innerText = childNode.InnerText.Trim().Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("<br>", "\r\n");
                        if (!string.IsNullOrEmpty(innerText))
                        {
                            if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
                            {
                                currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]) - 1;
                            }
                            ExcelRichTextCollection rtfCollection1 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                            //string innerText = childNode.InnerText.Trim().Replace("&nbsp;", " ").Replace("<br>", "\r\n");
                            ExcelRichText tempText1;
                            if (innerText.Contains("$"))
                            {
                                //innerText = innerText.Replace("$", "").Replace("(", "-").Replace(")", "");
                                excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Numberformat.Format = "$#,##0 ;[Red]($#,##0);-";
                                tempText1 = rtfCollection1.Add(innerText);
                                if (innerText.Contains("($"))
                                    color = Color.Red;
                            }
                            else
                            {
                                tempText1 = rtfCollection1.Add(innerText);
                            }
                            if (!isBold && isTH)
                                isBold = true;
                            tempText1.Bold = isBold;
                            tempText1.PreserveSpace = true;
                            if (color != Color.Black)
                            {
                                tempText1.Color = color;
                            }
                            if (isUnderline)
                            {
                                tempText1.UnderLine = true;
                                isUnderline = false;
                            }
                            else
                            {
                                tempText1.UnderLine = false;
                            }
                        }
                        break;
                    case "span":
                        #region Style Attributes
                        foreach (HtmlAttribute tdAttrib in childNode.Attributes)
                        {
                            //styleBuilder.AppendLine("Name : "+tdAttrib.Name + "    Value :"+tdAttrib.Value);
                            switch (tdAttrib.Name)
                            {
                                case "style":
                                    string styleVal = tdAttrib.Value;
                                    string[] styleCollection = styleVal.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                    foreach (string styleAttrib in styleCollection)
                                    {
                                        string[] nodeVal = styleAttrib.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                                        if (nodeVal.Length > 1)
                                        {
                                            switch (nodeVal[0].Trim())
                                            {
                                                case "color":
                                                    color = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                                    excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Color.SetColor(color);
                                                    break;
                                                case "font-weight":
                                                    if (nodeVal[1].ToLower().Trim() == "bold")
                                                    {
                                                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Bold = true;
                                                        isBold = true;
                                                    }
                                                    break;
                                                case "text-decoration":
                                                    if (nodeVal[1].ToLower().Trim() == "underline")
                                                    {
                                                        isUnderline = true;
                                                    }
                                                    break;
                                            }
                                        }

                                    }

                                    break;
                            }
                        }
                        #endregion
                        if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
                        {
                            currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]) - 1;
                        }
                        string tempText111 = childNode.InnerText.Trim().Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("<br>", "\r\n");
                        if (!string.IsNullOrEmpty(tempText111))
                        {
                            ExcelRichTextCollection rtfCollection2 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;

                            ExcelRichText tempText2 = rtfCollection2.Add(tempText111);

                            if (!isBold && isTH)
                                isBold = true;
                            tempText2.Bold = isBold;
                            //tempText2.PreserveSpace = true;
                            if (color != Color.Black)
                            {
                                tempText2.Color = color;
                            }
                            if (isUnderline)
                            {
                                tempText2.UnderLine = true;
                                isUnderline = false;
                            }
                            else
                            {
                                tempText2.UnderLine = false;
                            }
                        }
                        break;
                    case "a":
                        //#region Style Attributes
                        //foreach (HtmlAttribute tdAttrib in childNode.Attributes)
                        //{
                        //    //styleBuilder.AppendLine("Name : "+tdAttrib.Name + "    Value :"+tdAttrib.Value);
                        //    switch (tdAttrib.Name)
                        //    {
                        //        case "style":
                        //            string styleVal = tdAttrib.Value;
                        //            string[] styleCollection = styleVal.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        //            foreach (string styleAttrib in styleCollection)
                        //            {
                        //                string[] nodeVal = styleAttrib.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        //                if (nodeVal.Length > 1)
                        //                {
                        //                    switch (nodeVal[0].Trim())
                        //                    {
                        //                        case "color":
                        //                            color = ColorTranslator.FromHtml(nodeVal[1].Trim());
                        //                            excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Color.SetColor(color);
                        //                            break;
                        //                        case "font-weight":
                        //                            if (nodeVal[1].ToLower().Trim() == "bold")
                        //                            {
                        //                                excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Bold = true;
                        //                                isBold = true;
                        //                            }
                        //                            break;
                        //                    }
                        //                }

                        //            }

                        //            break;
                        //    }
                        //}
                        //#endregion
                        if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
                        {
                            currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]) - 1;
                        }
                        ExcelRichTextCollection rtfCollection2_2 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                        ExcelRichText tempText2_2 = rtfCollection2_2.Add(childNode.InnerText.Trim().Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("<br>", "\r\n"));

                        if (!isBold && isTH)
                            isBold = true;
                        tempText2_2.Bold = isBold;
                        tempText2_2.PreserveSpace = true;
                        if (color != Color.Black)
                        {
                            tempText2_2.Color = color;
                        }
                        break;
                    case "br":
                        ExcelRichTextCollection rtfCollection3 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                        excelWorksheet.Row(currRowNumber).CustomHeight = false;
                        if (colSpanSet)
                            excelWorksheet.Row(currRowNumber).Height = excelWorksheet.Row(currRowNumber).Height + 15;
                        ExcelRichText tempText3 = rtfCollection3.Add(Environment.NewLine);
                        if (isUnderline)
                        {
                            tempText3.UnderLine = true;
                            isUnderline = false;
                        }
                        else
                        {
                            tempText3.UnderLine = false;
                        }
                        if (childNode.HasChildNodes)
                        {
                            foreach (HtmlNode brchildNode in childNode.ChildNodes)
                            {
                                switch (brchildNode.Name)
                                {
                                    case "#text":
                                        string innerText1 = brchildNode.InnerText.Trim().Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("<br>", "\r\n");
                                        if (!string.IsNullOrEmpty(innerText1))
                                        {
                                            ExcelRichText tempText3_1 = rtfCollection3.Add(Environment.NewLine + innerText1);
                                            if (isUnderline)
                                            {
                                                tempText3_1.UnderLine = true;
                                            }
                                            else
                                            {
                                                tempText3_1.UnderLine = false;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case "table":

                        if (!isGrid) //|| isNestedTable || isSecondLevelNestedTable)
                        {
                            HandleNestedTable(childNode);
                        }
                        else
                        {
                            isNestedTable = true;
                            HandleTABLENode(childNode);
                            blankRows.Add(currRowNumber);
                            isNestedTable = false;
                        }
                        break;
                    case "div":
                        foreach (HtmlNode hChildNode in childNode.ChildNodes)
                        {
                            switch (hChildNode.Name.ToUpper())
                            {
                                case "TABLE":
                                    if (isGrid)
                                    {
                                        HandleTABLENode(hChildNode);
                                        blankRows.Add(currRowNumber);
                                    }
                                    else
                                        HandleNestedTable(hChildNode);
                                    break;
                                case "TR": HandleTRNode(hChildNode, false); break;
                                case "TD": HandleTDNode(hChildNode); break;
                                //default: HandleOtherNode(hChildNode); break;
                            }
                        }

                        break;
                    case "img":
                        string url = string.Empty, width = "0", height = "0";

                        foreach (HtmlAttribute tdAttrib in childNode.Attributes)
                        {
                            switch (tdAttrib.Name.ToUpper())
                            {
                                case "SRC":
                                    url = tdAttrib.Value;
                                    break;
                                case "WIDTH":
                                    width = tdAttrib.Value;
                                    break;
                                case "HEIGHT":
                                    height = tdAttrib.Value;
                                    break;

                            }
                        }
                        if (!string.IsNullOrEmpty(url) && !url.Contains("up-arrow") && !url.Contains("down-arrow"))
                        {
                            using (WebClient client = new WebClient())
                            {
                                string imagePath2 = imagePath + Guid.NewGuid().ToString();
                                //client.DownloadFileAsync(new Uri(url), @"c:\temp\image35.png");
                                client.DownloadFile(new Uri(url), imagePath2);
                                Image img = Image.FromFile(imagePath2);

                                ExcelPicture cellImg = excelWorksheet.Drawings.AddPicture("", img);
                                cellImg.From.Column = currColumnNumber - 1;
                                cellImg.From.Row = currRowNumber - 1;
                                cellImg.From.ColumnOff = 1;
                                //cellImg.SetPosition(currRowNumber - 1, 1, currColumnNumber - 1, 3);
                                cellImg.SetSize((int)(Convert.ToInt32(width.ToLower().Replace("px", "")) * 0.94), (int)(Convert.ToInt32(height.ToLower().Replace("px", "")) * 0.34));
                                cellImg.Dispose();

                                File.Delete(imagePath2);
                            }
                        }
                        break;
                }
            }
            if (colSpanSet)
                currColumnNumber = tempColspanCol;
        }
        else
        {
            if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
            {
                currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]) - 1;
            }
            if (colSpanSet)
                currColumnNumber = tempColspanCol;
        }
    }

    private void HandleTABLENode(HtmlNode hNode)
    {
        int startRow = currRowNumber, startCol = currColumnNumber;
        int totalcolsInCurrRow = 1;
        bool hasBorder = false;
        hasBorder = hNode.Attributes.Contains("border");
        int tempColumn = currColumnNumber, nestedColumns;
        int MaxColumnInCurrTable = 1;
        foreach (HtmlNode childNode in hNode.ChildNodes)
        {
            switch (childNode.Name.ToUpper())
            {
                case "TABLE": HandleTABLENode(childNode); break;
                case "TR":
                    foreach (HtmlAttribute trAttrib in hNode.Attributes)
                    {
                        if (trAttrib.Name.ToUpper() != "BORDER")
                            childNode.Attributes.Add(trAttrib);
                    }

                    totalcolsInCurrRow = HandleTRNode(childNode, hasBorder);
                    if (totalcolsInCurrRow > MaxColumnInCurrTable)
                        MaxColumnInCurrTable = totalcolsInCurrRow;
                    if (!isNestedTable)
                    {
                        totalNoOfColumnsInRow = totalcolsInCurrRow;
                        currRowNumber = currRowNumber + MaxRowsinColumn;
                    }
                    else
                    {
                        nestedColumns = totalcolsInCurrRow;
                        if (isGrid || (nestedLevel != 0 && isNestedTable))
                            currRowNumber = currRowNumber + 1;
                    }

                    break;
                case "TH":
                    isTH = true;
                    HandleTDNode(childNode);
                    isTH = false;
                    break;
                case "TD":
                    HandleTDNode(childNode); break;
            }
        }
        int NoOfCol = 0;

        if (isNestedTable)
        {
            currColumnNumber = tempColumn;
            NoOfCol = startCol + MaxColumnInCurrTable - 1;
        }
        else
            NoOfCol = MaxColumnInCurrTable;

        HandleStyle(hNode, startRow, startCol, NoOfCol);
    }

    private void HandleOtherNode(HtmlNode hNode)
    {
        string colVal = hNode.InnerText;
        colVal = colVal.Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">");
        Color color = Color.Black;
        bool isBold = false;

        switch (hNode.Name.ToUpper())
        {
            case "BR":
                currRowNumber = currRowNumber + 1;
                break;
            case "B":
                foreach (HtmlNode childNode in hNode.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "#text":
                            //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Value = colVal;
                            string innerText = childNode.InnerText.Trim().Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("<br>", "\r\n");
                            if (!string.IsNullOrEmpty(innerText))
                            {
                                if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
                                {
                                    currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]);
                                }
                                ExcelRichTextCollection rtfCollection1 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                                ExcelRichText tempText1 = rtfCollection1.Add(innerText);

                                isBold = true;
                                tempText1.Bold = isBold;
                                tempText1.PreserveSpace = true;
                                if (color != Color.Black)
                                {
                                    tempText1.Color = color;
                                }
                            }
                            break;
                    }
                }
                //currRowNumber = currRowNumber + 1;
                break;
            case "#TEXT":
                //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Value = colVal;
                string innerText1 = hNode.InnerText.Trim().Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">").Replace("<br>", "\r\n");
                if (!string.IsNullOrEmpty(innerText1))
                {
                    if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
                    {
                        currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]);
                    }
                    ExcelRichTextCollection rtfCollection2 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                    ExcelRichText tempText2 = rtfCollection2.Add(hNode.InnerText.Replace("&nbsp;", " ").Replace("&lt;", "<").Replace("&gt;", ">"));

                    if (!isBold && isTH)
                        isBold = true;
                    tempText2.Bold = isBold;
                    tempText2.PreserveSpace = true;
                    if (color != Color.Black)
                    {
                        tempText2.Color = color;
                    }
                }
                break;
            case "SPAN":
            case "DIV":
            case "FONT":
            case "HTML":
            case "BODY":
                foreach (HtmlNode hChildNode in hNode.ChildNodes)
                {
                    switch (hChildNode.Name.ToUpper())
                    {
                        case "TABLE": HandleTABLENode(hChildNode); break;
                        case "TR": HandleTRNode(hChildNode, false); break;
                        case "TD": HandleTDNode(hChildNode); break;
                        default: HandleOtherNode(hChildNode); break;
                    }
                }
                break;
            case "IMG":
                string url = string.Empty, width = "0", height = "0";

                foreach (HtmlAttribute tdAttrib in hNode.Attributes)
                {
                    switch (tdAttrib.Name.ToUpper())
                    {
                        case "SRC":
                            url = tdAttrib.Value;
                            break;
                        case "WIDTH":
                            width = tdAttrib.Value.ToLower().Replace("px", "");
                            break;
                        case "HEIGHT":
                            height = tdAttrib.Value.ToLower().Replace("px", "");
                            break;

                    }
                }
                if (!string.IsNullOrEmpty(url))
                {
                    using (WebClient client = new WebClient())
                    {
                        string imagePath = @"D:\R & D Work\Adhoc Reports\Input\" + Guid.NewGuid().ToString();
                        //client.DownloadFileAsync(new Uri(url), @"c:\temp\image35.png");
                        client.DownloadFile(new Uri(url), imagePath);
                        excelWorksheet.Row(currRowNumber).Height = (int)(Convert.ToInt32(height.ToLower().Replace("px", "")) * 1);

                        Image img = Image.FromFile(imagePath);

                        ExcelPicture cellImg = excelWorksheet.Drawings.AddPicture("", img);
                        cellImg.From.Column = currColumnNumber - 1;
                        cellImg.From.Row = currRowNumber - 1;
                        cellImg.EditAs = eEditAs.TwoCell;
                        //cellImg.From.ColumnOff = 1;

                        //cellImg.SetPosition(currRowNumber - 1, 1, currColumnNumber - 1, 3);
                        cellImg.SetSize((int)(Convert.ToInt32(width.ToLower().Replace("px", "")) * 0.94), (int)(Convert.ToInt32(height.ToLower().Replace("px", "")) * 1));
                        cellImg.Dispose();

                        excelWorksheet.Row(currRowNumber).Height = (int)(Convert.ToInt32(height.ToLower().Replace("px", "")) * 1);

                        File.Delete(imagePath);
                    }
                }
                break;
        }
    }

    private static string GetExcelColumnName(int columnNumber, int RowNumber)
    {
        int dividend = columnNumber;
        string columnName = String.Empty;
        int modulo;

        while (dividend > 0)
        {
            modulo = (dividend - 1) % 26;
            columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
            dividend = (int)((dividend - modulo) / 26);
        }

        return string.Concat(columnName, RowNumber.ToString());
    }

    private tabledef GetColumnCountInTable(HtmlNode hNode)
    {
        tabledef currTable = new tabledef();
        foreach (HtmlNode childNode in hNode.ChildNodes)
        {
            switch (childNode.Name.ToUpper())
            {
                //case "TABLE": HandleTABLENode(childNode); break;
                case "TR": currTable.noOfRow++;
                    if (currTable.noOfRow == 1)
                        foreach (HtmlNode childNode1 in childNode.ChildNodes)
                        {
                            switch (childNode1.Name.ToUpper())
                            {
                                //case "TABLE": HandleTABLENode(childNode); break;
                                case "TD":
                                    currTable.noOfColumn++;
                                    foreach (HtmlNode childNode2 in childNode1.ChildNodes)
                                    {
                                        switch (childNode2.Name.ToUpper())
                                        {
                                            case "TABLE":
                                                HasInnerTable = true; break;
                                        }
                                    }
                                    break;
                                case "TH": currTable.noOfColumn++; break;
                            }
                        }
                    break;
                //case "TD": currTable.noOfColumn++; break;
            }
        }
        currTable.RowID = currRowNumber;
        currTable.ColumnID = currColumnNumber;
        if (currTable.noOfColumn == 1 && HasInnerTable) HasInnerTable = false;

        return currTable;
    }

    private void MergeColumns()
    {
        int MaxRows = 0, MaxRowNumber = 0;
        ArrayList columnListOfRows = new ArrayList();
        bool AddnewRow;
        int noOfRowsToAdd = 0;
        if (htGridRow.Contains(currRowNumber))
        {
            ArrayList rowList = (ArrayList)htGridRow[currRowNumber];

            foreach (tabledef tempDef in rowList)
            {
                if (tempDef.noOfRow > MaxRows)
                {
                    MaxRows = tempDef.noOfRow;
                    MaxRowNumber = tempDef.RowID;

                    AddnewRow = false;
                    noOfRowsToAdd = 0;
                }
                else
                {
                    noOfRowsToAdd = MaxRows - tempDef.noOfRow;
                    AddnewRow = true;
                }
                for (int i = tempDef.noOfColumn - 1; i >= 0; i--)
                {
                    columnListOfRows.Add(tempDef.ColumnID + i);
                }
            }
        }
        if (htGridRow.Contains(currRowNumber))
        {

            foreach (tabledef innerTableDef in (ArrayList)(htGridRow[currRowNumber]))
            {
                int topRow = 0;
                if (htGridCellsRows.Contains(innerTableDef.ColumnID))
                {
                    topRow = Convert.ToInt32(htGridCellsRows[innerTableDef.ColumnID]);
                    htGridCellsRows[innerTableDef.ColumnID] = currRowNumber + MaxRows;
                }
                else
                {
                    htGridCellsRows.Add(innerTableDef.ColumnID, currRowNumber + innerTableDef.noOfRow);
                }
                //tabledef innerTableDef =(tabledef)dc.Value;
                for (int currentRow = currRowNumber - 1; currentRow >= topRow; currentRow--)
                {
                    string mergeCells = GetExcelColumnName(innerTableDef.ColumnID, currentRow) + ":" + GetExcelColumnName(innerTableDef.ColumnID + Convert.ToInt32(innerTableDef.noOfColumn) - 1, currentRow);
                    if (!htMergedCells.Contains(mergeCells))//&& !htMergedRows.Contains(currentRow)
                    {
                        try
                        {
                            //if (excelWorksheet.Cells[mergeCells].Merge)
                            //{
                            //    for (int tempI = innerTableDef.ColumnID + 1; tempI <= innerTableDef.ColumnID + Convert.ToInt32(innerTableDef.noOfColumn) - 1; tempI++)
                            //    {
                            //        string tempMergeCells = GetExcelColumnName(innerTableDef.ColumnID, currentRow) + ":" + GetExcelColumnName(tempI, currentRow);
                            //        if (excelWorksheet.Cells[tempMergeCells].Merge)
                            //            excelWorksheet.Cells[tempMergeCells].Merge = false;
                            //    }
                            //}
                            excelWorksheet.Cells[mergeCells].AutoFitColumns(minWidth, maxWidth);
                            excelWorksheet.Cells[mergeCells].Merge = true;
                            htMergedCells.Add(mergeCells, true);
                            if (!htMergedRows.Contains(currentRow))
                                htMergedRows.Add(currentRow, true);
                        }
                        catch
                        {
                            //if (excelWorksheet.Cells[mergeCells].Merge)
                            //    excelWorksheet.Cells[mergeCells].Merge = false;
                            if (!htMergedRows.Contains(currentRow)) htMergedRows.Add(currentRow, true);

                            //using (ExcelRange range = excelWorksheet.Cells[mergeCells])
                            //{
                            //    //range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            //    Border border = range.Style.Border;
                            //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.None;
                            //}
                        }
                    }
                    else
                    {


                    }
                }
                // for rowspans
                for (int colStart = 1; colStart <= MaxColumnInRow + innerTableDef.noOfColumn; colStart++)
                {

                    if ((colStart < innerTableDef.ColumnID || colStart > innerTableDef.ColumnID + innerTableDef.noOfColumn - 1) && !columnListOfRows.Contains(colStart))
                    {
                        string mergeCells = GetExcelColumnName(colStart, currRowNumber) + ":" + GetExcelColumnName(colStart, currRowNumber + MaxRows - 1);

                        if (!htMergedCells.Contains(mergeCells) && currRowNumber != currRowNumber + MaxRows - 1) //&& !excelWorksheet.Cells[mergeCells].Merge)
                        {
                            try
                            {
                                excelWorksheet.Cells[mergeCells].AutoFitColumns(minWidth, maxWidth);
                                string value = string.Empty;
                                bool rightAlign = false;
                                bool isBorder = false;


                                excelWorksheet.Cells[mergeCells].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                                excelWorksheet.Cells[mergeCells].Style.WrapText = true;
                                excelWorksheet.Cells[mergeCells].Merge = true;
                                for (int tempRow = currRowNumber + 1; tempRow <= currRowNumber + MaxRows - 1; tempRow++)
                                {
                                    excelWorksheet.Cells[mergeCells].RichText.Text += excelWorksheet.Cells[tempRow, colStart].RichText.Text;
                                    if (excelWorksheet.Cells[tempRow, colStart].Style.HorizontalAlignment == ExcelHorizontalAlignment.Right)
                                        rightAlign = true;
                                    if (excelWorksheet.Cells[tempRow, colStart].Style.Border.Right.Style != ExcelBorderStyle.None)
                                        isBorder = true;
                                }
                                if (rightAlign)
                                    excelWorksheet.Cells[mergeCells].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                if (!htMergedCells.Contains(mergeCells))
                                    htMergedCells.Add(mergeCells, true);
                                if (isBorder)
                                    excelWorksheet.Cells[mergeCells].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            }
                            catch
                            {
                                //excelWorksheet.Cells[mergeCells].Merge = false;
                                //using (ExcelRange range = excelWorksheet.Cells[mergeCells])
                                //{
                                //    //range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                //    Border border = range.Style.Border;
                                //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.None;
                                //}
                            }
                        }

                    }
                }
            }
        }
    }

    private void CountDetails(HtmlNode hNode)
    {
        HtmlNodeCollection t = hNode.SelectNodes("/table[1]/tr");
    }

    private void HandleNestedTable(HtmlNode childNode)
    {
        #region "Inner Table"
        //goto exit;
        int nestedColumnStart = currColumnNumber, nestedColumnEnd = currColumnNumber;
        int MaxRows = 0, MaxRowNumber;
        //ExcelAddressBase currentAddress = new ExcelAddressBase(excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].FullAddress);                            
        //excelWorksheet.InsertColumn(1, 4);
        tabledef innerTableDef = GetColumnCountInTable(childNode);
        MaxRows = innerTableDef.noOfRow;
        ArrayList columnListOfRows = new ArrayList();
        bool AddnewRow = true;
        int noOfRowsToAdd = 0;
        if (!HasInnerTable)
        {
            if (!htGridRow.Contains(currRowNumber))
            {
                ArrayList rowList = new ArrayList();
                rowList.Add(innerTableDef);
                htGridRow.Add(currRowNumber, rowList);
            }
            else
            {
                ArrayList rowList = (ArrayList)htGridRow[currRowNumber];

                foreach (tabledef tempDef in rowList)
                {
                    if (tempDef.noOfRow > innerTableDef.noOfRow)
                    {
                        MaxRows = tempDef.noOfRow;
                        MaxRowNumber = tempDef.RowID;
                        for (int i = tempDef.noOfColumn - 1; i >= 0; i--)
                        {
                            columnListOfRows.Add(tempDef.ColumnID + i);
                        }
                        AddnewRow = false;
                        noOfRowsToAdd = 0;
                    }
                    else
                    {
                        noOfRowsToAdd = innerTableDef.noOfRow - tempDef.noOfRow;
                        AddnewRow = true;
                    }
                }
                rowList.Add(innerTableDef);
                htGridRow[currRowNumber] = rowList;

            }
        }

        //if (!htGridCells.Contains(currColumnNumber))
        {
            if (!htGridCells.Contains(currColumnNumber))
            {
                excelWorksheet.InsertColumn(currColumnNumber + 1, innerTableDef.noOfColumn - 1);
                try
                {
                    string tempMergeCells = GetExcelColumnName(innerTableDef.ColumnID, currRowNumber) + ":" + GetExcelColumnName(innerTableDef.ColumnID, currRowNumber + innerTableDef.noOfRow - 1);
                    if (excelWorksheet.Cells[tempMergeCells].Merge)
                        excelWorksheet.Cells[tempMergeCells].Merge = false;
                }
                catch (Exception) { }
                ArrayList afterCells = new ArrayList();
                Hashtable htGridCells_Copy = (Hashtable)htGridCells.Clone();
                foreach (DictionaryEntry entry in htGridCells_Copy)
                {
                    if (Convert.ToInt32(entry.Key) > currColumnNumber)
                    {
                        int NextColumns = Convert.ToInt32(entry.Key);
                        afterCells.Add(NextColumns);
                        Hashtable htTemp = (Hashtable)htGridRow.Clone();
                        foreach (DictionaryEntry entry_row in htTemp)
                        {
                            ArrayList rowList = (ArrayList)entry_row.Value;
                            ArrayList newRowList = new ArrayList();
                            foreach (tabledef tempDef in rowList)
                            {
                                tabledef newTempDef = tempDef;
                                if (newTempDef.ColumnID == NextColumns)
                                {
                                    newTempDef.ColumnID = tempDef.ColumnID + innerTableDef.noOfColumn - 1;
                                    htGridCells.Remove(entry.Key);
                                    if (!htGridCells.Contains(newTempDef.ColumnID))
                                        htGridCells.Add(newTempDef.ColumnID, entry.Value);
                                }
                                newRowList.Add(newTempDef);
                            }
                            htGridRow[entry_row.Key] = newRowList;
                        }
                    }
                }

                htGridCells.Add(currColumnNumber, innerTableDef.noOfColumn);

            }
            HasInnerTable = false;
            // for colspans
            //int topRow = 0;
            //if (htGridCellsRows.Contains(currColumnNumber))
            //{
            //    topRow = Convert.ToInt32(htGridCellsRows[currColumnNumber]);
            //    htGridCellsRows[currColumnNumber] = currRowNumber + MaxRows;
            //}
            //else
            //{
            //    htGridCellsRows.Add(currColumnNumber, currRowNumber + innerTableDef.noOfRow);
            //}

            //for (int currentRow = currRowNumber - 1; currentRow > topRow; currentRow--)
            //{
            //    string mergeCells = GetExcelColumnName(currColumnNumber, currentRow) + ":" + GetExcelColumnName(currColumnNumber + Convert.ToInt32(innerTableDef.noOfColumn) - 1, currentRow);
            //    if (!htMergedCells.Contains(mergeCells))//&& !htMergedRows.Contains(currentRow)
            //    {
            //        try
            //        {
            //            excelWorksheet.Cells[mergeCells].Merge = true;
            //            htMergedCells.Add(mergeCells, true);
            //            if (!htMergedRows.Contains(currentRow))
            //                htMergedRows.Add(currentRow, true);
            //        }
            //        catch { if (!htMergedRows.Contains(currentRow))htMergedRows.Add(currentRow, true); }
            //    }
            //    else
            //    {


            //    }
            //}

            //// for rowspans
            //for (int colStart = 1; colStart <= totalNoOfColumnsInRow + innerTableDef.noOfColumn; colStart++)
            //{

            //    if ((colStart < currColumnNumber || colStart > currColumnNumber + innerTableDef.noOfColumn - 1) && !columnListOfRows.Contains(colStart))
            //    {
            //        string mergeCells = GetExcelColumnName(colStart, currRowNumber) + ":" + GetExcelColumnName(colStart, currRowNumber + MaxRows - 1);
            //        if (AddnewRow)
            //        {
            //            // mergeCells = GetExcelColumnName(colStart, currRowNumber) + ":" + GetExcelColumnName(colStart, currRowNumber + MaxRows - 1-noOfRowsToAdd);
            //            //excelWorksheet.Cells[mergeCells].Merge = false;
            //            //excelWorksheet.Select(mergeCells);
            //        }
            //        if (!htMergedCells.Contains(mergeCells) && !excelWorksheet.Cells[mergeCells].Merge)
            //        {
            //            try
            //            {
            //                excelWorksheet.Cells[mergeCells].Merge = true;
            //                htMergedCells.Add(mergeCells, true);
            //            }
            //            catch { }
            //        }

            //    }
            //}
        }

        //currColumnNumber = innerTableDef.noOfColumn - 1;
        int tempRow = currRowNumber;
        isNestedTable = true;
        nestedLevel++;
        HandleTABLENode(childNode);

        if (nestedLevel == 0)
        {
            currRowNumber = tempRow;
            isNestedTable = false;
        }
        else
        {
            if (nestedLevel != 1)
                currRowNumber--;
        }

        //isNestedTable = false;
        //currRowNumber = tempRow;
        nestedLevel--;
        nestedColumnEnd = currColumnNumber;
        currColumnNumber = currColumnNumber + innerTableDef.noOfColumn - 1;

        //nextRow = currRowNumber + MaxRows;

        //excelWorksheet.Cells["A3:E4"].Merge = true;
        //exit:
        #endregion
    }

    private void HandleStyle(HtmlNode hNode, int startRow, int startCol, int NoOfCol)
    {
        Color color = Color.Black;
        bool isBold = false;

        if (htTableCols.Contains(startRow))
        {
            if (Convert.ToInt32(htTableCols[startRow]) > NoOfCol && !overwriteBorder)
                NoOfCol = Convert.ToInt32(htTableCols[startRow]);
        }

        //if (htColStyles.Contains(startRow + ":" + startCol))
        //{
        //    Color backcolor1 = (Color)htColStyles[startRow + ":" + startCol];
        //    using (ExcelRange range = excelWorksheet.Cells[startRow, startCol, currRowNumber - 1, NoOfCol])
        //    {
        //        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //        range.Style.Fill.BackgroundColor.SetColor(backcolor1);
        //    }

        //}

        foreach (HtmlAttribute tdAttrib in hNode.Attributes)
        {
            //styleBuilder.AppendLine("Name : "+tdAttrib.Name + "    Value :"+tdAttrib.Value);
            switch (tdAttrib.Name)
            {
                case "border":
                    if (currRowNumber - 1 >= startRow)
                        if (NoOfCol > 0 && tdAttrib.Value != "0")
                            using (ExcelRange range = excelWorksheet.Cells[startRow, startCol, currRowNumber - 1, NoOfCol])
                            {
                                range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                Border border = range.Style.Border;
                                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                            }
                    break;
                case "style":
                    string styleVal = tdAttrib.Value;
                    string[] styleCollection = styleVal.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string styleAttrib in styleCollection)
                    {
                        string[] nodeVal = styleAttrib.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        if (nodeVal.Length > 1)
                        {
                            switch (nodeVal[0].Trim())
                            {
                                case "color":
                                    color = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                    if (currRowNumber - 1 >= startRow)
                                        using (ExcelRange range = excelWorksheet.Cells[startRow, startCol, currRowNumber - 1, NoOfCol])
                                        {
                                            range.Style.Font.Color.SetColor(color);
                                        }
                                    //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Color.SetColor(color);
                                    break;
                                case "font-weight":
                                    if (nodeVal[1].ToLower().Trim() == "bold")
                                    {
                                        if (currRowNumber - 1 >= startRow)
                                            using (ExcelRange range = excelWorksheet.Cells[startRow, startCol, currRowNumber - 1, NoOfCol])
                                            {
                                                range.Style.Font.Bold = true;
                                            }
                                        //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Bold = true;
                                        isBold = true;
                                    }
                                    break;
                                case "background-color":
                                    Color backcolor = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                    using (ExcelRange range = excelWorksheet.Cells[startRow, startCol, currRowNumber - 1, NoOfCol])
                                    {
                                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        range.Style.Fill.BackgroundColor.SetColor(backcolor);
                                    }
                                    break;
                                case "border":
                                    if (currRowNumber - 1 >= startRow)
                                        if (NoOfCol > 0 && tdAttrib.Value != "0")
                                            using (ExcelRange range = excelWorksheet.Cells[startRow, startCol, currRowNumber - 1, NoOfCol])
                                            {
                                                range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                                                Border border = range.Style.Border;
                                                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                            }
                                    break;
                            }
                        }

                    }

                    break;
            }
        }
    }

    #region CSS Parsing
    //To parse Css file.
    string aa = null;
    static string[] parts;
    private List<string> styleSheets;
    private SortedList<string, StyleClass> scc;

    public SortedList<string, StyleClass> Styles
    {
        get { return this.scc; }
        set { this.scc = value; }
    }
    public void CssParser()
    {
        this.styleSheets = new List<string>();
        this.scc = new SortedList<string, StyleClass>();
    }

    //Get Style sheet to parse
    public void GetStyleSheet(string path)
    {
        CssParser();
        this.styleSheets.Add(path);
        ParseStyleSheet(path);
    }
    public string GetStyleSheet(int index)
    {
        return this.styleSheets[index];
    }

    //Parsing style sheet
    private void ParseStyleSheet(string path)
    {
        string content = CleanUp(File.ReadAllText(path));
        parts = content.Split('}');

        for (int i = 0; i < parts.Length - 1; i++)
        {
            string[] parts1 = parts[i].Split('{');
            string str = parts1[0].ToString().Remove(0, 1);
            aa = aa + str + ",";
        }
        int len = aa.LastIndexOf(',');
        string ss = aa.Remove(len);
        string ss1 = aa.Remove(len - 1);
        string[] parts2 = ss.Split(',');
        GetCssClassProperty(parts, "HeaderStyle");
        //Binding all class of a css file to a drop down list

        //Bind all property of a selected css class
        //GetCssClassProperty(parts, DDLCssClass.SelectedValue);
    }

    private string CleanUp(string s)
    {
        string temp = s;
        string reg = "(/\\*(.|[\r\n])*?\\*/)|(//.*)";
        Regex r = new Regex(reg);
        temp = r.Replace(temp, "");
        temp = temp.Replace("\r", "").Replace("\n", "");
        return temp;
    }

    public class StyleClass
    {
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private SortedList<string, string> _attributes = new SortedList<string, string>();
        public SortedList<string, string> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }
    }
    protected void DDLCssClass_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //To Bind all property of a css class
    private string[] GetCssClassProperty(string[] classArray, string className)
    {
        string[] parts3 = new string[] { };
        for (int i = 0; i < classArray.Length - 1; i++)
        {
            string[] parts1 = classArray[i].Split('{');
            if ("." + className == parts1[0].ToString())
            {
                parts3 = parts1[1].Split(';');
                //for (int j = 0; j < parts3.Length - 1; j++)
                //{
                //    lstClassProperty.Items.Add(parts3[j].ToString());
                //}
                return parts3;
            }
        }
        return parts3;
    }

    #endregion
}
