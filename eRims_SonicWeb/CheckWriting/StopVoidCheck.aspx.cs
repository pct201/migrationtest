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
using System.Collections.Generic;
using System.IO;
using System.Xml;
using RIMS_Base.Biz;

public partial class CheckWriting_StopVoidCheck : System.Web.UI.Page
{
    #region Public Variable
    public RIMS_Base.Biz.CCheckDetails m_objCheckDetails;
    List<RIMS_Base.CCheckDetails> lstChekDetails = null;
    public int m_intRetVal = -1;
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    public string m_strExcelFileName = string.Empty;
    public string m_strExcelFilePath = string.Empty;
    public string m_strExcelVirutalPath = string.Empty;
    public string m_strScript = string.Empty;
    protected System.Web.UI.WebControls.Table colorTable;
    string strSortExp = string.Empty;
    #endregion
    #region Event Handler
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                btnStopCheck.Attributes.Add("onclick", "javascript:return ConfirmStopVoid('Stop Payment');");
                btnVoidCheck.Attributes.Add("onclick", "javascript:return ConfirmStopVoid('Void');");
                gvChkStopVoid.PageSize = 10;
                gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
                gvChkStopVoid.DataBind();
                if (lstChekDetails.Count > 0)
                {
                    lblTotalAmount.Text = String.Format("{0:c}", Convert.ToDecimal(lstChekDetails[0].TotalAmount));
                    btnStopCheck.Visible = true;
                    btnVoidCheck.Visible = true;
                }
                else
                {
                    lblTotalAmount.Text = "$0.00";
                    btnStopCheck.Visible = false;
                    btnVoidCheck.Visible = false;
                }
                lblHeader.Text = "Stop Payment / Void";
                ddlPage.DataBind();
                ddlPage.SelectedValue = "10";
                lblPageInfo.Text = "Page 1 of " + gvChkStopVoid.PageCount.ToString();
                txtPageNo.Text = "1";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected bool SetUserRights()
    {
        try
        {

            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(14, Convert.ToInt32(Session["UserRoleId"].ToString()));
                ViewState["Add"] = lstRightDetails[0].PAdd.ToString();
                ViewState["Edit"] = lstRightDetails[0].PEdit.ToString();
                ViewState["Delete"] = lstRightDetails[0].PDelete.ToString();
                ViewState["View"] = lstRightDetails[0].PView.ToString();
                if (ViewState["Add"].ToString() == "True")
                {
                    btnStopCheck.Enabled = true;
                    btnVoidCheck.Enabled = true;
                }
                else
                {
                    btnStopCheck.Enabled = false;
                    btnVoidCheck.Enabled = false;
                }

                return true;
            }
            else
            {
                Response.Redirect("../Signin.aspx", false);
                return false;
            }

        }
        catch (Exception ex)
        {
            throw;
        }

    }
    protected void btnStopCheck_Click(object sender, EventArgs e)
    {
        try
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            m_objCheckDetails.Updated_By = Session["UserID"].ToString();
            m_intRetVal = m_objCheckDetails.Chek_MakeStop(Request.Form["chkItem"].ToString(), m_objCheckDetails.Updated_By);
            if (m_intRetVal <= 0)
            {
                gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
                gvChkStopVoid.DataBind();
                if (lstChekDetails.Count > 0)
                {
                    lblTotalAmount.Text = "$" + lstChekDetails[0].TotalAmount;
                    btnStopCheck.Visible = true;
                    btnVoidCheck.Visible = true;
                }
                else
                {
                    lblTotalAmount.Text = "$0.00";
                    btnStopCheck.Visible = false;
                    btnVoidCheck.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnVoidCheck_Click(object sender, EventArgs e)
    {
        try
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            m_objCheckDetails.Updated_By = Session["UserID"].ToString();
            m_intRetVal = m_objCheckDetails.Chek_MakeVoid(Request.Form["chkItem"].ToString(), m_objCheckDetails.Updated_By);
            if (m_intRetVal <= 0)
            {
                gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
                gvChkStopVoid.DataBind();
                if (lstChekDetails.Count > 0)
                {
                    lblTotalAmount.Text = "$" + lstChekDetails[0].TotalAmount;
                    btnStopCheck.Visible = true;
                    btnVoidCheck.Visible = true;
                }
                else
                {
                    lblTotalAmount.Text = "$0.00";
                    btnStopCheck.Visible = false;
                    btnVoidCheck.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvChkStopVoid_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            // Changes the sort direction 
            else
            {
                if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                    ViewState["sortDirection"] = SortDirection.Descending;
                else
                    ViewState["sortDirection"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = strSortExp = e.SortExpression;

            lstChekDetails = BindCheckToStopVoid(0);
            if (ViewState["SortExp"] != null)
                lstChekDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CCheckDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvChkStopVoid.DataSource = lstChekDetails;
            gvChkStopVoid.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
    protected void gvChkStopVoid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvChkStopVoid.PageIndex = e.NewPageIndex;
            GeneralSorting();
            //gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
            //gvChkStopVoid.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkBtnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            gvChkStopVoid.AllowPaging = false;
            gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
            gvChkStopVoid.DataBind();
            gvChkStopVoid.GridLines = GridLines.Both;
            GridViewExportUtil.Export("StopVoidCheck" + System.DateTime.Now.ToString("MMddyyhhmmss") + ".xls", this.gvChkStopVoid);
            gvChkStopVoid.AllowPaging = true;
            gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
            gvChkStopVoid.DataBind();
            gvChkStopVoid.GridLines = GridLines.None;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvChkStopVoid.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvChkStopVoid.PageCount)
            {
                gvChkStopVoid.PageIndex = gvChkStopVoid.PageCount;
                txtPageNo.Text = gvChkStopVoid.PageCount.ToString();
            }
            else
            {
                gvChkStopVoid.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvChkStopVoid.PageCount.ToString();
            gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
            gvChkStopVoid.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvChkStopVoid.PageIndex <= gvChkStopVoid.PageCount)
            {
                gvChkStopVoid.PageIndex = gvChkStopVoid.PageIndex + 1;
                GeneralSorting();
                //gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
                //gvChkStopVoid.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvChkStopVoid.PageIndex + 1) + " of " + gvChkStopVoid.PageCount.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvChkStopVoid.PageIndex <= gvChkStopVoid.PageCount)
            {
                gvChkStopVoid.PageIndex = gvChkStopVoid.PageIndex - 1;
                //gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
                //gvChkStopVoid.DataBind();
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvChkStopVoid.PageIndex + 1) + " of " + gvChkStopVoid.PageCount.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvChkStopVoid.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvChkStopVoid.DataSource = BindCheckToStopVoid(0);
            gvChkStopVoid.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvChkStopVoid.PageCount.ToString();
            txtPageNo.Text = "1";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvChkStopVoid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
        }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvChkStopVoid.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvChkStopVoid.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 iCol = GetSortColumnIndex(strSortExp);
        if (-1 == iCol)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();

        if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }
    public override void VerifyRenderingInServerForm(Control control) { }
    #endregion
    #region Private Method
    /// <summary>
    /// Bind Check Which are Printed
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CCheckDetails> BindCheckToStopVoid(System.Int64 m_intType)
    {
        try
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            lstChekDetails = m_objCheckDetails.GetStoppedVoidedCheck(m_intType);
            return lstChekDetails;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// General Sorting.
    /// </summary>
    private void GeneralSorting()
    {
        try
        {
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            lstChekDetails = BindCheckToStopVoid(0);
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                lstChekDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CCheckDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvChkStopVoid.DataSource = lstChekDetails;
            gvChkStopVoid.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    /// <summary>
    /// Exports dataset to excel file
    /// </summary>
    /// <param name="source"></param>
    /// <param name="fileName"></param>
    public static void exportToExcel(DataSet source, string fileName)
    {
        try
        {

            System.IO.StreamWriter excelDoc;

            excelDoc = new System.IO.StreamWriter(fileName);
            const string startExcelXML = "<xml version>\r\n<Workbook " +
                  "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                  " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                  "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                  "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                  "office:spreadsheet\">\r\n <Styles>\r\n " +
                  "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                  "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                  "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                  "\r\n <Protection/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                  "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                  "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                  " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                  "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                  "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                  "ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n " +
                  "</Styles>\r\n ";
            const string endExcelXML = "</Workbook>";

            int rowCount = 0;
            int sheetCount = 1;
            /*
           <xml version>
           <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
           xmlns:o="urn:schemas-microsoft-com:office:office"
           xmlns:x="urn:schemas-microsoft-com:office:excel"
           xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">
           <Styles>
           <Style ss:ID="Default" ss:Name="Normal">
             <Alignment ss:Vertical="Bottom"/>
             <Borders/>
             <Font/>
             <Interior/>
             <NumberFormat/>
             <Protection/>
           </Style>
           <Style ss:ID="BoldColumn">
             <Font x:Family="Swiss" ss:Bold="1"/>
           </Style>
           <Style ss:ID="StringLiteral">
             <NumberFormat ss:Format="@"/>
           </Style>
           <Style ss:ID="Decimal">
             <NumberFormat ss:Format="0.0000"/>
           </Style>
           <Style ss:ID="Integer">
             <NumberFormat ss:Format="0"/>
           </Style>
           <Style ss:ID="DateLiteral">
             <NumberFormat ss:Format="mm/dd/yyyy;@"/>
           </Style>
           </Styles>
           <Worksheet ss:Name="Sheet1">
           </Worksheet>
           </Workbook>
           */
            excelDoc.Write(startExcelXML);
            excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
            excelDoc.Write("<Table>");
            excelDoc.Write("<Row>");
            for (int x = 0; x < source.Tables[0].Columns.Count; x++)
            {
                excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                excelDoc.Write(source.Tables[0].Columns[x].ColumnName);
                excelDoc.Write("</Data></Cell>");
            }
            excelDoc.Write("</Row>");
            foreach (DataRow x in source.Tables[0].Rows)
            {
                rowCount++;
                //if the number of rows is > 64000 create a new page to continue output
                if (rowCount == 64000)
                {
                    rowCount = 0;
                    sheetCount++;
                    excelDoc.Write("</Table>");
                    excelDoc.Write(" </Worksheet>");
                    excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                    excelDoc.Write("<Table>");
                }
                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                for (int y = 0; y < source.Tables[0].Columns.Count; y++)
                {
                    System.Type rowType;
                    rowType = x[y].GetType();
                    switch (rowType.ToString())
                    {
                        case "System.String":
                            string XMLstring = x[y].ToString();
                            XMLstring = XMLstring.Trim();
                            XMLstring = XMLstring.Replace("&", "&");
                            XMLstring = XMLstring.Replace(">", ">");
                            XMLstring = XMLstring.Replace("<", "<");
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                           "<Data ss:Type=\"String\">");
                            excelDoc.Write(XMLstring);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DateTime":
                            //Excel has a specific Date Format of YYYY-MM-DD followed by  
                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                            //The Following Code puts the date stored in XMLDate 
                            //to the format above
                            DateTime XMLDate = (DateTime)x[y];
                            string XMLDatetoString = ""; //Excel Converted Date
                            XMLDatetoString = XMLDate.Year.ToString() +
                                 "-" +
                                 (XMLDate.Month < 10 ? "0" +
                                 XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                 "-" +
                                 (XMLDate.Day < 10 ? "0" +
                                 XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                 "T" +
                                 (XMLDate.Hour < 10 ? "0" +
                                 XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                 ":" +
                                 (XMLDate.Minute < 10 ? "0" +
                                 XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                 ":" +
                                 (XMLDate.Second < 10 ? "0" +
                                 XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                 ".000";
                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                         "<Data ss:Type=\"DateTime\">");
                            excelDoc.Write(XMLDatetoString);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Boolean":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                        "<Data ss:Type=\"String\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                    "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                  "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DBNull":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                  "<Data ss:Type=\"String\">");
                            excelDoc.Write("");
                            excelDoc.Write("</Data></Cell>");
                            break;
                        default:
                            throw (new Exception(rowType.ToString() + " not handled."));
                    }
                }
                excelDoc.Write("</Row>");
            }
            excelDoc.Write("</Table>");
            excelDoc.Write(" </Worksheet>");
            excelDoc.Write(endExcelXML);
            excelDoc.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
