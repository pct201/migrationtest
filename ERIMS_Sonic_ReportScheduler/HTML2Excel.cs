using System;
using System.Text;
using HtmlAgilityPack;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Collections;


public class HTML2Excel
{
    private string _htmlData;
    ExcelPackage excelWorkbook;
    ExcelWorksheet excelWorksheet;
    int currRowNumber = 1, currColumnNumber = 1, totalNoOfColumnsInRow = 0;
    int nextRow = 1, MaxRowsinColumn = 1;
    StringBuilder styleBuilder = new StringBuilder();
    Hashtable htGridCells = new Hashtable();
    Hashtable htGridCellsRows = new Hashtable();
    Hashtable htMergedCells = new Hashtable();
    Hashtable htMergedRows = new Hashtable();
    Hashtable htGridRow = new Hashtable();
    Stack cellStack = new Stack();
    bool isTH = false;
    HtmlNode hNodeGlobal;
    bool applycolSpan = false;

    bool isNestedTable = false;
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
        try
        {


            excelWorkbook = new ExcelPackage();
            excelWorksheet = excelWorkbook.Workbook.Worksheets.Add("Report");

            HtmlDocument hDoc = new HtmlDocument();
            hDoc.LoadHtml(_htmlData);

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

            //using (ExcelRange range = excelWorksheet.Cells[1, 1, currRowNumber - 2, totalNoOfColumnsInRow])
            //{
            //    range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //    Border border = range.Style.Border;
            //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
            //    range.Style.Font.Size = 10;
            //}

            //excelWorksheet.Cells.AutoFitColumns();
            excelWorksheet.Cells.AutoFitColumns(25, 60);
            excelWorksheet.Cells.Style.WrapText = true;

            //Byte[] bin = excelWorkbook.GetAsByteArray();

            FileInfo outputFile = new FileInfo(outputPath);

            //File.WriteAllBytes(outputPath, bin);        
            excelWorkbook.SaveAs(outputFile);
            _htmlData = null;

            //excelWorksheet.Dispose();
            //excelWorkbook.Dispose();



            //File.WriteAllText(@"D:\R & D Work\style.txt", styleBuilder.ToString());

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
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
        bool bold = false;
        string fontFamilty = "Calibri";
        float font_size = 10;

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
                                    //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Color.SetColor(color);
                                    break;
                                case "font-family":
                                    fontFamilty = nodeVal[1].Trim();
                                    break;
                                case "font-size":
                                    font_size = float.Parse(nodeVal[1].Trim().Replace("pt", ""));
                                    break;
                                case "font-weight":
                                    bold = true;
                                    break;
                                case "background-color":
                                    if (nodeVal[1].ToLower().Contains("rgb"))
                                    {
                                        string[] tempColor = nodeVal[1].Trim().Replace("rgb", "").Replace("(", "").Replace(")", "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        backColor = Color.FromArgb(Convert.ToInt32(tempColor[1]), Convert.ToInt32(tempColor[2]), Convert.ToInt32(tempColor[2]));
                                    }
                                    else
                                        backColor = ColorTranslator.FromHtml(nodeVal[1].Trim());
                                    break;
                            }
                        }

                    }

                    break;
            }
        }
        if (hNode.Attributes.Count > 0)
        {
            using (ExcelRange range = excelWorksheet.Cells[currRowNumber, tempCol, currRowNumber, currColumnNumber - 1])
            {

                //excelWorksheet.Cells["AN7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //excelWorksheet.Cells["AN7"].Style.Font.Bold = true;
                //excelWorksheet.Cells["AN7"].Style.Fill.BackgroundColor.SetColor(Color.Beige);
                //excelWorksheet.Cells["AN7"].Style.Font.Color.SetColor(color);

                //ExcelNamedStyleXml namedStyle = excelWorksheet.Workbook.Styles.CreateNamedStyle(mergeCells.Replace(":", ""));
                //namedStyle.Style.Font.SetFromFont(new Font(fontFamilty, font_size));
                //namedStyle.Style.Font.Color.SetColor(Color.White);
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(backColor);

                if (range.IsRichText)
                {
                    for (int tempCol1 = tempCol; tempCol1 < currColumnNumber; tempCol1++)
                    {
                        if (excelWorksheet.Cells[GetExcelColumnName(tempCol1, currRowNumber)].IsRichText)
                        {
                            ExcelRichTextCollection rtfCollection1 = excelWorksheet.Cells[GetExcelColumnName(tempCol1, currRowNumber)].RichText;
                            rtfCollection1[0].Color = color;
                            rtfCollection1[0].Bold = bold;
                            rtfCollection1[0].FontName = fontFamilty;
                            rtfCollection1[0].Size = font_size;
                        }
                    }
                }


                //range.StyleName = namedStyle.Name;

            }
        }
        #endregion

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

        return nestedColumns;
    }

    private void HandleTDNode(HtmlNode hNode)
    {
        string colVal = hNode.InnerText;
        colVal = colVal.Replace("&nbsp;", " ");
        Color color = Color.Black;

        bool isBold = false;
        int tempColspanCol = currColumnNumber;
        bool colSpanSet = false;
        #region Style Attributes
        foreach (HtmlAttribute tdAttrib in hNode.Attributes)
        {
            //styleBuilder.AppendLine("Name : "+tdAttrib.Name + "    Value :"+tdAttrib.Value);
            switch (tdAttrib.Name)
            {
                case "colspan":
                    try
                    {
                        string mergeCells = GetExcelColumnName(currColumnNumber, currRowNumber) + ":" + GetExcelColumnName(currColumnNumber + Convert.ToInt32(tdAttrib.Value) - 1, currRowNumber);
                        excelWorksheet.Cells[mergeCells].Merge = true;
                        tempColspanCol = currColumnNumber + Convert.ToInt32(tdAttrib.Value) - 1;
                        colSpanSet = true;
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
                            }
                        }

                    }

                    break;
                case "align":
                    if (tdAttrib.Value.ToLower() == "right")
                    {
                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    }
                    if (tdAttrib.Value.ToLower() == "left")
                    {
                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    }
                    if (tdAttrib.Value.ToLower() == "center")
                    {
                        excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

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
                        ExcelRichText tempText = rtfCollection.Add(childNode.InnerText.Replace("&nbsp;", " "));
                        tempText.Bold = true;
                        tempText.PreserveSpace = true;
                        if (color != Color.Black)
                        {
                            tempText.Color = color;
                        }
                        break;
                    case "table":
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
                        HandleTABLENode(childNode);
                        isNestedTable = false;
                        nestedColumnEnd = currColumnNumber;
                        currColumnNumber = currColumnNumber + innerTableDef.noOfColumn - 1;
                        currRowNumber = tempRow;
                        //nextRow = currRowNumber + MaxRows;
                        MaxRowsinColumn = MaxRows;
                        //excelWorksheet.Cells["A3:E4"].Merge = true;
                        //exit:
                        #endregion
                        break;
                    case "#text":
                        //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Value = colVal;
                        if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
                        {
                            currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]) - 1;
                        }
                        ExcelRichTextCollection rtfCollection1 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                        string innerText = childNode.InnerText.Replace("&nbsp;", " ");
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
                        ExcelRichTextCollection rtfCollection2 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                        ExcelRichText tempText2 = rtfCollection2.Add(childNode.InnerText.Replace("&nbsp;", " "));

                        if (!isBold && isTH)
                            isBold = true;
                        tempText2.Bold = isBold;
                        tempText2.PreserveSpace = true;
                        if (color != Color.Black)
                        {
                            tempText2.Color = color;
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
        }
    }

    private void HandleTABLENode(HtmlNode hNode)
    {
        int startRow = currRowNumber, startCol = currColumnNumber;
        int totalcolsInCurrRow = 1;
        bool hasBorder = false;
        hasBorder = hNode.Attributes.Contains("border");
        int tempColumn = currColumnNumber, nestedColumns;
        foreach (HtmlNode childNode in hNode.ChildNodes)
        {
            switch (childNode.Name.ToUpper())
            {
                case "TABLE": HandleTABLENode(childNode); break;
                case "TR":

                    totalcolsInCurrRow = HandleTRNode(childNode, hasBorder);
                    if (!isNestedTable)
                    {
                        totalNoOfColumnsInRow = totalcolsInCurrRow;
                        currRowNumber = currRowNumber + MaxRowsinColumn;
                    }
                    else
                    {
                        nestedColumns = totalcolsInCurrRow;
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
            NoOfCol = startCol + totalcolsInCurrRow - 1;
        }
        else
            NoOfCol = totalcolsInCurrRow;


        Color color = Color.Black;
        bool isBold = false;
        foreach (HtmlAttribute tdAttrib in hNode.Attributes)
        {
            //styleBuilder.AppendLine("Name : "+tdAttrib.Name + "    Value :"+tdAttrib.Value);
            switch (tdAttrib.Name)
            {
                case "border":
                    if (currRowNumber - 1 > startRow)
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
                                    if (currRowNumber - 1 > startRow)
                                        using (ExcelRange range = excelWorksheet.Cells[startRow, startCol, currRowNumber - 1, NoOfCol])
                                        {
                                            range.Style.Font.Color.SetColor(color);
                                        }
                                    //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Color.SetColor(color);
                                    break;
                                case "font-weight":
                                    if (nodeVal[1].ToLower().Trim() == "bold")
                                    {
                                        if (currRowNumber - 1 > startRow)
                                            using (ExcelRange range = excelWorksheet.Cells[startRow, startCol, currRowNumber - 1, NoOfCol])
                                            {
                                                range.Style.Font.Bold = true;
                                            }
                                        //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Style.Font.Bold = true;
                                        isBold = true;
                                    }
                                    break;
                            }
                        }

                    }

                    break;
            }
        }


        HtmlAttributeCollection nodeAttrib = hNode.Attributes;
    }

    private void HandleOtherNode(HtmlNode hNode)
    {
        string colVal = hNode.InnerText;
        colVal = colVal.Replace("&nbsp;", " ");
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
                            if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
                            {
                                currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]);
                            }
                            ExcelRichTextCollection rtfCollection1 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                            ExcelRichText tempText1 = rtfCollection1.Add(childNode.InnerText.Replace("&nbsp;", " "));

                            isBold = true;
                            tempText1.Bold = isBold;
                            tempText1.PreserveSpace = true;
                            if (color != Color.Black)
                            {
                                tempText1.Color = color;
                            }
                            break;
                    }
                }
                //currRowNumber = currRowNumber + 1;
                break;
            case "#TEXT":
                //excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].Value = colVal;
                if (htGridCells.Contains(currColumnNumber) && !isNestedTable)
                {
                    currColumnNumber = currColumnNumber + Convert.ToInt32(htGridCells[currColumnNumber]);
                }
                ExcelRichTextCollection rtfCollection2 = excelWorksheet.Cells[GetExcelColumnName(currColumnNumber, currRowNumber)].RichText;
                ExcelRichText tempText2 = rtfCollection2.Add(hNode.InnerText.Replace("&nbsp;", " "));

                if (!isBold && isTH)
                    isBold = true;
                tempText2.Bold = isBold;
                tempText2.PreserveSpace = true;
                if (color != Color.Black)
                {
                    tempText2.Color = color;
                }
                break;
            case "SPAN":
            case "DIV":
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
                                case "TH": currTable.noOfColumn++; break;
                            }
                        }
                    break;
                //case "TD": currTable.noOfColumn++; break;
            }
        }
        currTable.RowID = currRowNumber;
        currTable.ColumnID = currColumnNumber;

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
                for (int colStart = 1; colStart <= totalNoOfColumnsInRow + innerTableDef.noOfColumn; colStart++)
                {

                    if ((colStart < innerTableDef.ColumnID || colStart > innerTableDef.ColumnID + innerTableDef.noOfColumn - 1) && !columnListOfRows.Contains(colStart))
                    {
                        string mergeCells = GetExcelColumnName(colStart, currRowNumber) + ":" + GetExcelColumnName(colStart, currRowNumber + MaxRows - 1);

                        if (!htMergedCells.Contains(mergeCells)) //&& !excelWorksheet.Cells[mergeCells].Merge)
                        {
                            try
                            {
                                excelWorksheet.Cells[mergeCells].Merge = true;
                                if (!htMergedCells.Contains(mergeCells))
                                    htMergedCells.Add(mergeCells, true);
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



}