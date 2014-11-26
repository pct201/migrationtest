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
using aspPDF;
using WebSupergoo.ABCpdf6;
using WebSupergoo.ABCpdf6.Atoms;
using WebSupergoo.ABCpdf6.Internal;
using WebSupergoo.ABCpdf6.Objects;
using WebSupergoo.ABCpdf6.Operations;
using WebSupergoo.ABCpdf6.Drawing;
using WebSupergoo.ABCpdf6.Drawing.Drawing2D;
using WebSupergoo.ABCpdf6.Drawing.Text;
using System.Drawing;
using RIMS_Base.Biz;


public partial class CheckWriting_PrintCheck : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    public RIMS_Base.Biz.CCheckDetails m_objCheckDetails;
    List<RIMS_Base.CCheckDetails> lstChekDetails = null;
    public RIMS_Base.Biz.CCheckDetails m_objPDF;
    DataSet m_dsPDF;
    public string m_strFileName = string.Empty;
    public int m_intRetVal = -1;
    string strSortExp = string.Empty;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {

        btnPrintCheck.Attributes.Add("onclick", "javascript:return ConfirmPrint();");
        if (Request.QueryString.Count > 0)
        {
            gvChkPrint.Columns[0].Visible = false; //Hide checkboxes
            if (Request.QueryString["Pre"] == "1")
            {
                if (!IsPostBack)
                {
                    btnPrintCheck.Visible = false;
                    gvChkPrint.PageSize = 10;
                    gvChkPrint.DataSource = BindChecksForPrint();
                    gvChkPrint.DataBind();
                    lblHeader.Text = "Pre-Check Register";
                    if (lstChekDetails.Count > 0)
                    {
                        lblTotalAmount.Text = String.Format("{0:c}", Convert.ToDecimal(lstChekDetails[0].TotalAmount));
                    }
                    else
                    {
                        lblTotalAmount.Text = "$0.00";
                    }
                    ddlPage.DataBind();
                    ddlPage.SelectedValue = "10";
                    lblPageInfo.Text = "Page 1 of " + gvChkPrint.PageCount.ToString();
                    txtPageNo.Text = "1";
                }
            }

        }
        else
        {
            if (!IsPostBack)
            {
                SetUserRights();
                gvChkPrint.PageSize = 10;
                gvChkPrint.DataSource = BindChecksForPrint();
                gvChkPrint.DataBind();
                lblHeader.Text = "Print Checks";
                if (lstChekDetails.Count > 0)
                {
                    lblTotalAmount.Text = String.Format("{0:c}", Convert.ToDecimal(lstChekDetails[0].TotalAmount));
                    btnPrintCheck.Visible = true;
                }
                else
                {
                    lblTotalAmount.Text = "$0.00";
                    btnPrintCheck.Visible = false;
                }
                ddlPage.DataBind();
                ddlPage.SelectedValue = "10";
                lblPageInfo.Text = "Page 1 of " + gvChkPrint.PageCount.ToString();
                txtPageNo.Text = "1";
            }
        }

    }
    protected bool SetUserRights()
    {
        try
        {

            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(12, Convert.ToInt32(Session["UserRoleId"].ToString()));
                ViewState["Add"] = lstRightDetails[0].PAdd.ToString();
                ViewState["Edit"] = lstRightDetails[0].PEdit.ToString();
                ViewState["Delete"] = lstRightDetails[0].PDelete.ToString();
                ViewState["View"] = lstRightDetails[0].PView.ToString();
                if (ViewState["Add"].ToString() == "True")
                {
                    btnPrintCheck.Enabled = true;
                }
                else
                {
                    btnPrintCheck.Enabled = false;
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
    protected void btnPrintCheck_Click(object sender, EventArgs e)
    {
        try
        {
            ////Response.Buffer = true;
            ////Response.Clear();
            ////Response.ClearContent();
            ////Response.ClearHeaders();

            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            m_objCheckDetails.Updated_By = Session["UserID"].ToString();
            m_intRetVal = m_objCheckDetails.Chek_MakePrinted(Request.Form["chkItem"].ToString(), m_objCheckDetails.Updated_By);
            //GeneratePDF();
            GeneratePDFReportingService();
            ////lblMessage.Text = "Pdf Document Has Been Generated.";
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment; filename=" + m_strFileName);
            //Response.WriteFile(m_strFileName);
            //Response.End();

            if (m_intRetVal <= 0)
            {
                gvChkPrint.DataSource = BindChecksForPrint();
                gvChkPrint.DataBind();
                if (lstChekDetails.Count > 0)
                {
                    lblTotalAmount.Text = "$" + lstChekDetails[0].TotalAmount;
                    btnPrintCheck.Visible = true;
                }
                else
                {
                    lblTotalAmount.Text = "$0.00";
                    btnPrintCheck.Visible = false;
                }
            }
            ////Response.Buffer = true;
            ////Response.Clear();
            ////Response.ClearContent();
            ////Response.ClearHeaders();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvChkPrint_Sorting(object sender, GridViewSortEventArgs e)
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

        lstChekDetails = BindChecksForPrint();
        if (ViewState["SortExp"] != null)
            lstChekDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CCheckDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        gvChkPrint.DataSource = lstChekDetails;
        gvChkPrint.DataBind();
    }
    protected void gvChkPrint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView gv = new GridView();
        //gv.DataSource = gvChkPrint.DataSource;
        //gv.DataBind();
        //gv.Sorting += new GridViewSortEventHandler(gvChkPrint_Sorting);

        gvChkPrint.PageIndex = e.NewPageIndex;
        GeneralSorting();
        //gvChkPrint.DataSource = BindChecksForPrint();
        //gvChkPrint.DataBind();
    }
    protected void lnkBtnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            gvChkPrint.AllowPaging = false;
            gvChkPrint.DataSource = BindChecksForPrint();
            gvChkPrint.DataBind();
            gvChkPrint.GridLines = GridLines.Both;
            if (Request.QueryString["Pre"] == "1")
            {
                GridViewExportUtil.Export("PreCheckRegister" + System.DateTime.Now.ToString("MMddyyhhmmss") + ".xls", this.gvChkPrint);
            }
            else
            {
                GridViewExportUtil.Export("PrintCheck" + System.DateTime.Now.ToString("MMddyyhhmmss") + ".xls", this.gvChkPrint);
            }
            gvChkPrint.AllowPaging = true;
            gvChkPrint.DataSource = BindChecksForPrint();
            gvChkPrint.DataBind();
            gvChkPrint.GridLines = GridLines.None;
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
                gvChkPrint.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvChkPrint.PageCount)
            {
                gvChkPrint.PageIndex = gvChkPrint.PageCount;
                txtPageNo.Text = gvChkPrint.PageCount.ToString();
            }
            else
            {
                gvChkPrint.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvChkPrint.PageCount.ToString();
            gvChkPrint.DataSource = BindChecksForPrint();
            gvChkPrint.DataBind();

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
            if (gvChkPrint.PageIndex <= gvChkPrint.PageCount)
            {
                gvChkPrint.PageIndex = gvChkPrint.PageIndex + 1;
                GeneralSorting();
                //gvChkPrint.DataSource = BindChecksForPrint();
                //gvChkPrint.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvChkPrint.PageIndex + 1) + " of " + gvChkPrint.PageCount.ToString();
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
            if (gvChkPrint.PageIndex <= gvChkPrint.PageCount)
            {
                gvChkPrint.PageIndex = gvChkPrint.PageIndex - 1;
                //gvChkPrint.DataSource = BindChecksForPrint();
                //gvChkPrint.DataBind();
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvChkPrint.PageIndex + 1) + " of " + gvChkPrint.PageCount.ToString();
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
            gvChkPrint.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvChkPrint.DataSource = BindChecksForPrint();
            gvChkPrint.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvChkPrint.PageCount.ToString();
            txtPageNo.Text = "1";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvChkPrint_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
            else
            {
                System.Web.UI.WebControls.Image sortImage = new   System.Web.UI.WebControls.Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[1].Controls.Add(sortImage);
            }
        }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvChkPrint.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvChkPrint.Columns.IndexOf(field);
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
    #endregion
    #region Private Method
    /// <summary>
    /// Bind check which are not Pritned
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CCheckDetails> BindChecksForPrint()
    {
        try
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            lstChekDetails = m_objCheckDetails.GetChecksForPrint();
            return lstChekDetails;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// General Function for Sorting.
    /// </summary>
    private void GeneralSorting()
    {
        try
        {
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            lstChekDetails = BindChecksForPrint();
            if (ViewState["sortDirection"] != null && ViewState["SortExp"] != null)
            {
                lstChekDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CCheckDetails>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvChkPrint.DataSource = lstChekDetails;
            gvChkPrint.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Fucntion for Generate PDF When Print Check.
    /// </summary>
    //private void GeneratePDF()
    //{
    //    try
    //    {
    //        m_objPDF=new RIMS_Base.Biz.CCheckDetails();
    //        m_dsPDF = m_objPDF.GetDataForPDF(Request.Form["chkItem"].ToString());
    //        aspPDF.EASYPDF PDF = new aspPDF.EASYPDF();
    //        PDF.Create();
    //        PDF.Page("A4", 0);
    //        PDF.SetTrueTypeFont("MICR1", "IDAutomationMICR", 11, 1);
    //        for (int m_intCounter = 0; m_intCounter < m_dsPDF.Tables[0].Rows.Count; m_intCounter++)
    //        {
    //            if (m_intCounter > 0)
    //            {
    //                PDF.AddPage();
    //            }
    //            PDF.AddGraphicPos(415, 130, Server.MapPath("../Images/signature.gif"));
    //            //PDF.AddGraphicPos(60, 12, Server.MapPath("../Images/copyonly.gif"));
    //            PDF.SetMargins(10, 10, 10, 10);
    //            PDF.AddBox (437, 80, 537, 117);
    //            PDF.SetFont ("F2", 12, "#000000");
    //            PDF.AddTextPos(10, 25, m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Bank_Name"].ToString());
    //            PDF.SetFont ("F1", 12, "#000000");
    //            PDF.AddTextPos (10, 41, m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Address_1"].ToString());
    //            PDF.AddTextPos (10, 58, m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Address_2"].ToString());
    //            PDF.AddTextPos (10, 74, m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_City"].ToString()+" "+m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_State"].ToString()+" "+m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Zip"].ToString());
    //            PDF.SetFont ("F1", 7, "#000000");
    //            PDF.AddTextPos (260, 21, "SUNTRUST BANK");
    //            PDF.AddTextPos (339, 20, m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Bank_No1"].ToString());
    //            PDF.AddLine(256, 52, 256, 52);
    //            PDF.AddTextPos (344, 34, m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Bank_No2"].ToString());
    //            PDF.SetFont( "F2", 15, "#000000");
    //            PDF.AddTextPos( 448, 27, m_dsPDF.Tables[0].Rows[m_intCounter]["Check_Number"].ToString());
    //            PDF.SetFont ("F1", 11, "#000000");
    //            PDF.AddTextPos (448, 53, "DATE");
    //            PDF.AddTextPos (448, 69, m_dsPDF.Tables[0].Rows[m_intCounter]["Rec_Issue_Date"].ToString());
    //            PDF.SetFont ("F2", 10, "#000000");
    //            PDF.AddTextPos (460, 93, "AMOUNT");
    //            PDF.AddTextPos (454, 108, "$*" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());
    //            PDF.AddTextPos (10, 95, "PAY");
    //            PDF.SetFont ("F2", 11, "#000000");
    //            PDF.AddTextPos (10, 156, "TO");
    //            PDF.AddTextPos (10, 169, "THE");
    //            PDF.AddTextPos (10, 183, "ORDER");
    //            PDF.AddTextPos (10, 196, "OF");
    //            PDF.SetFont ("F1", 10, "#000000");
    //            PDF.AddLine (420, 165, 536, 165);
    //            PDF.AddLine (420, 190, 536, 190);
    //            PDF.SetFont ("F1", 10, "#000000");
    //            PDF.AddTextPos(10, 111, Words_Money(Convert.ToDecimal(m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString())));
    //            PDF.AddTextPos (64, 155, m_dsPDF.Tables[0].Rows[m_intCounter]["Employee_Name"].ToString());
    //            PDF.AddTextPos (64, 171, m_dsPDF.Tables[0].Rows[m_intCounter]["PayeeAddress1"].ToString());
    //            PDF.AddTextPos (64, 187, m_dsPDF.Tables[0].Rows[m_intCounter]["PayeeAddress2"].ToString());
    //            PDF.SetFont ("F1", 7, "#000000");
    //            PDF.AddTextPos (416, 202, "Not valid without facsimile signature");
    //            PDF.SetFont ("F2", 13, "#000000");
    //            PDF.AddTextPos (10, 299, "Employer");
    //            PDF.SetFont( "F1", 10, "#000000");
    //            PDF.AddTextPos (10, 320, "");//This is Value of Employer
    //            PDF.SetFont ("F2", 13, "#000000");
    //            PDF.AddTextPos (10, 347, "Employee");
    //            PDF.SetFont ("F1", 10, "#000000");
    //            PDF.AddTextPos(10, 368, m_dsPDF.Tables[0].Rows[m_intCounter]["Employee_Name"].ToString());
    //            PDF.SetFont("F2", 12, "#000000");
    //            PDF.AddTextPos (270, 306, "Check Amount");
    //            PDF.AddTextPos (270, 322, "Check Date");
    //            PDF.AddTextPos (270, 338, "Employee");
    //            PDF.AddTextPos (270, 354, "Claim No");
    //            PDF.AddTextPos (270, 370, "Date of Loss");
    //            PDF.AddTextPos (270, 386, "Adjuster");
    //            PDF.AddTextPos (270, 402, "Payee Name");
    //            PDF.AddTextPos (270, 418, "Payment Type");

    //            PDF.AddTextPos (270, 450, "Invoice Number");

    //            PDF.AddTextPos (270, 434, "Service Dates");
    //            PDF.SetFont ("F2", 13, "#000000");
    //            PDF.AddTextPos (10, 448, "Payable Comments");
    //            PDF.SetFont( "F1", 10, "#000000");
    //            PDF.AddTextPos(10, 467,  m_dsPDF.Tables[0].Rows[m_intCounter]["Comments"].ToString());
    //            PDF.SetFont( "F2", 10, "#000000");
    //            PDF.AddTextPos (293, 590, "Service Amount");
    //            PDF.AddTextPos (394, 590, "Approved Amount");
    //            PDF.AddTextWidth( 510, 590, 59, "Reduction");
    //            PDF.SetFont ("F1", 10, "#000000");
    //            PDF.AddTextPos(330, 616, "$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());
    //            PDF.AddTextPos(445, 616, "$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());
    //            PDF.AddTextPos (536, 616, "$0.00");
    //            PDF.SetFont ("F2", 10, "#000000");
    //            PDF.AddTextPos (203, 637, "Totals");


    //            PDF.AddTextPos(330, 637, "$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());
    //            PDF.AddTextPos(444, 637, "$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());
    //            PDF.AddTextPos (536, 637, "$0.00");
    //            PDF.AddTextPos (365, 336, ":");
    //            PDF.AddTextPos (365, 320, ":");
    //            PDF.AddTextPos (365, 368, ":");
    //            PDF.AddTextPos (365, 352, ":");
    //            PDF.AddTextPos (365, 384, ":");
    //            PDF.AddTextPos (365, 400, ":");
    //            PDF.AddTextPos (365, 304, ":");
    //            PDF.AddTextPos (365, 416, ":");
    //            PDF.AddTextPos (365, 432, ":");

    //            PDF.AddTextPos (365, 448, ":");

    //            PDF.SetFont ("F1", 10, "#000000");
    //            PDF.AddTextPos(380, 304, "$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());
    //            PDF.AddTextPos(380, 320, m_dsPDF.Tables[0].Rows[m_intCounter]["Rec_Issue_Date"].ToString());
    //            PDF.AddTextPos(380, 336, m_dsPDF.Tables[0].Rows[m_intCounter]["Employee_Name"].ToString());
    //            PDF.SetFont( "F1", 10, "#000000");
    //            PDF.AddTextPos( 380, 352, "");
    //            PDF.SetFont ("F1", 10, "#000000");
    //            PDF.AddTextPos(380, 352, m_dsPDF.Tables[0].Rows[m_intCounter]["Claim_Number"].ToString());
    //            PDF.AddTextPos (380, 368, "");//Date of Loss
    //            PDF.AddTextPos (380, 384, "");//Adjuster
    //            PDF.AddTextPos(456, 368, "");//This is AM
    //            PDF.AddTextPos(380, 400, m_dsPDF.Tables[0].Rows[m_intCounter]["Payee_Name"].ToString());
    //            PDF.AddTextPos(380, 416, m_dsPDF.Tables[0].Rows[m_intCounter]["Payment_Id"].ToString());
    //            PDF.AddTextPos(380, 432, m_dsPDF.Tables[0].Rows[m_intCounter]["Service_Begin"].ToString());
    //            PDF.AddTextPos (445, 432, "To :");
    //            PDF.AddTextPos(475, 432, m_dsPDF.Tables[0].Rows[m_intCounter]["Service_End"].ToString());

    //            PDF.AddTextPos(380, 448, m_dsPDF.Tables[0].Rows[m_intCounter]["Invoice_Number"].ToString());


    //            PDF.SetProperty (400, "1");
    //            PDF.SetProperty (400, "1");
    //            PDF.AddLine (333, 24, 370, 24);
    //            PDF.SetFont("MICR1", 13, "");
    //            PDF.AddTextPos(80, 241, m_dsPDF.Tables[0].Rows[m_intCounter]["Check_Number"].ToString());
    //            //PDF.SetFont ("F1", 7, "#000000");
    //            //PDF.AddTextPos(260, 32, m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_RoutingNo"].ToString());
    //            PDF.SetFont ("F1", 12, "#000000");
    //            PDF.AddTextPos(110, 241, m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_RoutingNo"].ToString());
    //            PDF.AddTextPos(140, 241, m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_AccountNo"].ToString());
    //        }

    //        Response.Buffer = true;
    //        Response.Clear();
    //        Response.ClearContent();
    //        Response.ClearHeaders();

    //        Response.ContentType = "application/pdf";
    //        PDF.License("C:\\WINDOWS\\system32\\easypdf.lic");
    //        Response.AddHeader("content-disposition", "attachment; filename=MyPDF.PDF");
    //        Response.BinaryWrite((byte[])PDF.SaveVariant());
    //        Response.End();
    //        PDF = null;

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }



    //}
    private void GeneratePDF()
    {
        m_objPDF = new RIMS_Base.Biz.CCheckDetails();
        m_dsPDF = m_objPDF.GetDataForPDF(Request.Form["chkItem"].ToString());
        Doc theDoc = new Doc();
        int SignId = 0;
        XImage theImg;
        theDoc.Width = 1;
        theDoc.FontSize = 12;
        theDoc.TopDown = true;
        for (int m_intCounter = 0; m_intCounter < m_dsPDF.Tables[0].Rows.Count; m_intCounter++)
        {
            if (m_intCounter > 0)
            {
                theDoc.Page = theDoc.AddPage();
            }
            theDoc.Rect.String = "0 0 1000 1000";
            theDoc.Font = theDoc.AddFont("Arial");
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 25;
            // theDoc.AddText("Mueller Water Products");//ssValues(1)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Bank_Name"].ToString());

            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 41;
            theDoc.FontSize = 10;
            //theDoc.AddText("1200 Abernathy Road");//ssValues(2)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Address_1"].ToString());

            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 58;
            theDoc.FontSize = 10;
            //theDoc.AddText("Suite 1200");//ssValues(3)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Address_2"].ToString());

            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 74;
            theDoc.FontSize = 10;
            //theDoc.AddText("Atlanta GA 30328");//ssValues(4)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_City"].ToString() + " " + m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_State"].ToString() + " " + m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Zip"].ToString());

            theDoc.FontSize = 7;
            theDoc.Pos.X = 260;
            theDoc.Pos.Y = 21;
            theDoc.AddText("SUNTRUST BANK");

            theDoc.FontSize = 11;
            theDoc.Pos.X = 448;
            theDoc.Pos.Y = 53;
            theDoc.AddText("DATE");

            theDoc.FontSize = 11;
            theDoc.Pos.X = 448;
            theDoc.Pos.Y = 69;
            //theDoc.AddText("1/21/2008");//ssValues(10)
            theDoc.AddText(Convert.ToDateTime(m_dsPDF.Tables[0].Rows[m_intCounter]["Rec_Issue_Date"].ToString()).ToShortDateString());


            theDoc.FontSize = 11;
            theDoc.Pos.X = 460;
            theDoc.Pos.Y = 93;
            theDoc.AddText("AMOUNT");

            theDoc.FontSize = 10;
            theDoc.Pos.X = 454;
            theDoc.Pos.Y = 108;
            // theDoc.AddText("$*1.00");////ssValues(11)
            theDoc.AddText("$*" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());

            theDoc.FontSize = 10;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 95;
            theDoc.AddText("PAY");

            theDoc.FontSize = 11;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 156;
            theDoc.AddText("TO");

            theDoc.FontSize = 11;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 170;
            theDoc.AddText("THE");

            theDoc.FontSize = 11;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 183;
            theDoc.AddText("ORDER");

            theDoc.FontSize = 11;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 197;
            theDoc.AddText("OF");


            theDoc.FontSize = 8;
            theDoc.Pos.X = 339;
            theDoc.Pos.Y = 20;
            //theDoc.AddText("64-079");//ssValues(8)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Bank_No1"].ToString());

            theDoc.FontSize = 8;
            theDoc.Pos.X = 344;
            theDoc.Pos.Y = 34;
            //theDoc.AddText("611");//ssValues(9)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_Bank_No2"].ToString());

            theDoc.FontSize = 9;
            theDoc.Pos.X = 416;
            theDoc.Pos.Y = 202;
            theDoc.AddText("Not valid without facsimile signature");

            theDoc.FontSize = 10;
            theDoc.Pos.X = 64;
            theDoc.Pos.Y = 155;
            //theDoc.AddText("Hinton Henry");//ssValues(12)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Employee_Name"].ToString());

            theDoc.FontSize = 10;
            theDoc.Pos.X = 64;
            theDoc.Pos.Y = 171;
            //theDoc.AddText("532 Selma Road");//ssValues(13)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["PayeeAddress1"].ToString());

            theDoc.FontSize = 10;
            theDoc.Pos.X = 64;
            theDoc.Pos.Y = 187;
            //theDoc.AddText("Bessemer, AL 35020");//ssValues(14)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["PayeeAddress2"].ToString());


            theDoc.FontSize = 15;
            theDoc.Pos.X = 448;
            theDoc.Pos.Y = 27;
            //theDoc.AddText("00020367");//ssValues(26)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Check_Number"].ToString());

            theDoc.FontSize = 10;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 111;
            theDoc.AddText(Words_Money(Convert.ToDecimal(m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString())));

            theDoc.FontSize = 14;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 299;
            theDoc.AddText("EMPLOYER");

            theDoc.FontSize = 14;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 347;
            theDoc.AddText("EMPLOYEE");

            theDoc.FontSize = 10;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 320;
            //theDoc.AddText("-");//ssValues(15) Employer

            theDoc.FontSize = 10;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 368;
            //theDoc.AddText("Hinton Henry");//ssValues(16)
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Employee_Name"].ToString());

            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 306;
            theDoc.AddText("Check Amount");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 322;
            theDoc.AddText("Check Date");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 338;
            theDoc.AddText("Employee");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 354;
            theDoc.AddText("Claim No");
            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 370;
            theDoc.AddText("Date of Loss");
            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 386;
            theDoc.AddText("Adjuster");
            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 402;
            theDoc.AddText("Payee Name");
            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 418;
            theDoc.AddText("Payment Type");
            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 450;
            theDoc.AddText("Invoice Number");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 270;
            theDoc.Pos.Y = 434;
            theDoc.AddText("Service Dates");

            theDoc.FontSize = 14;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 448;
            theDoc.AddText("Payable Comments");

            theDoc.FontSize = 10;
            theDoc.Pos.X = 293;
            theDoc.Pos.Y = 590;
            theDoc.AddText("Service Amount");

            theDoc.FontSize = 10;
            theDoc.Pos.X = 394;
            theDoc.Pos.Y = 590;
            theDoc.AddText("Approved Amount");

            theDoc.FontSize = 10;
            theDoc.Pos.X = 510;
            theDoc.Pos.Y = 590;
            theDoc.AddText("Reduction");

            theDoc.FontSize = 10;
            theDoc.Pos.X = 203;
            theDoc.Pos.Y = 637;
            theDoc.AddText("Totals");

            theDoc.FontSize = 10;
            theDoc.Pos.X = 330;
            theDoc.Pos.Y = 637;
            //theDoc.AddText("$1.00");//ssValues(11)
            theDoc.AddText("$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());

            theDoc.FontSize = 10;
            theDoc.Pos.X = 444;
            theDoc.Pos.Y = 637;
            //theDoc.AddText("$1.00");//ssValues(11)
            theDoc.AddText("$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());


            theDoc.FontSize = 10;
            theDoc.Pos.X = 536;
            theDoc.Pos.Y = 637;
            theDoc.AddText("$0.00");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 336;
            theDoc.AddText(":");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 320;
            theDoc.AddText(":");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 368;
            theDoc.AddText(":");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 352;
            theDoc.AddText(":");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 384;
            theDoc.AddText(":");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 400;
            theDoc.AddText(":");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 304;
            theDoc.AddText(":");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 416;
            theDoc.AddText(":");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 432;
            theDoc.AddText(":");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 365;
            theDoc.Pos.Y = 448;
            theDoc.AddText(":");

            theDoc.FontSize = 10;
            theDoc.Pos.X = 10;
            theDoc.Pos.Y = 467;
            //theDoc.AddText("ssvalues(24)");//ssvalues(24) Payable Comments
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Comments"].ToString());

            theDoc.FontSize = 10;
            theDoc.Pos.X = 330;
            theDoc.Pos.Y = 616;
            //theDoc.AddText("$1.00");//ssvalues(11)
            theDoc.AddText("$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());

            theDoc.FontSize = 10;
            theDoc.Pos.X = 445;
            theDoc.Pos.Y = 616;
            //theDoc.AddText("$1.00");//ssvalues(11)
            theDoc.AddText("$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());

            theDoc.FontSize = 10;
            theDoc.Pos.X = 536;
            theDoc.Pos.Y = 616;
            theDoc.AddText("$0.00");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 380;
            theDoc.Pos.Y = 306;
            //        theDoc.AddText("$1.00");//ssvalues(11)Check Amount
            theDoc.AddText("$" + m_dsPDF.Tables[0].Rows[m_intCounter]["check_Amount"].ToString());


            theDoc.FontSize = 12;
            theDoc.Pos.X = 380;
            theDoc.Pos.Y = 320;
            //theDoc.AddText("1/21/2008");//ssvalues(10)Check Date
            theDoc.AddText(Convert.ToDateTime(m_dsPDF.Tables[0].Rows[m_intCounter]["Rec_Issue_Date"].ToString()).ToShortDateString());

            theDoc.FontSize = 12;
            theDoc.Pos.X = 380;
            theDoc.Pos.Y = 336;
            //theDoc.AddText("Hinton Henry");//ssvalues(16) Employee
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Employee_Name"].ToString());

            theDoc.FontSize = 12;
            theDoc.Pos.X = 380;
            theDoc.Pos.Y = 352;
            //theDoc.AddText("07-01083-01");//ssvalues(18) ClaimNo
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Claim_Number"].ToString());

            theDoc.FontSize = 12;
            theDoc.Pos.X = 380;
            theDoc.Pos.Y = 368;
            //theDoc.AddText("Dec 7 2007 12:00");//ssvalues(19) DateofLoss

            theDoc.FontSize = 12;
            theDoc.Pos.X = 456;
            theDoc.Pos.Y = 368;
            // theDoc.AddText("AM");//ssvalues(25) 

            theDoc.FontSize = 12;
            theDoc.Pos.X = 380;
            theDoc.Pos.Y = 400;
            //theDoc.AddText("Hinton Henry");//ssvalues(12) Payee Name
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Payee_Name"].ToString());

            theDoc.FontSize = 12;
            theDoc.Pos.X = 380;
            theDoc.Pos.Y = 416;
            //theDoc.AddText("Medical");//ssvalues(21) Payment Type
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Payment_Id"].ToString());

            theDoc.FontSize = 12;
            theDoc.Pos.X = 380;
            theDoc.Pos.Y = 432;
            //theDoc.AddText("1/21/2008");//ssvalues(22) service start date
            theDoc.AddText(Convert.ToDateTime(m_dsPDF.Tables[0].Rows[m_intCounter]["Service_Begin"].ToString()).ToShortDateString());

            theDoc.FontSize = 12;
            theDoc.Pos.X = 445;
            theDoc.Pos.Y = 432;
            theDoc.AddText("To :");

            theDoc.FontSize = 12;
            theDoc.Pos.X = 475;
            theDoc.Pos.Y = 432;
            //theDoc.AddText("1/21/2008");//ssvalues(23) service end date
            theDoc.AddText(Convert.ToDateTime(m_dsPDF.Tables[0].Rows[m_intCounter]["Service_End"].ToString()).ToShortDateString());

            theDoc.FontSize = 12;
            theDoc.Pos.X = 380;
            theDoc.Pos.Y = 448;
            //theDoc.AddText(" ");//ssvalues(33) Invoice Number
            theDoc.AddText(m_dsPDF.Tables[0].Rows[m_intCounter]["Invoice_Number"].ToString());

            theDoc.FontSize = 13;
            theDoc.Font = theDoc.AddFont("MICR");
            theDoc.Pos.X = 80;
            theDoc.Pos.Y = 241;
            theDoc.AddText("C" + m_dsPDF.Tables[0].Rows[m_intCounter]["Check_Number"].ToString() + "C A" + m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_RoutingNo"].ToString() + "A " + m_dsPDF.Tables[0].Rows[m_intCounter]["Fld_AccountNo"].ToString() + "C");

            #region commented
            /*   theDoc.Rect.String = "335 30 365 31"; //Line near suntrust bank
              theDoc.Color.Blue = 0;
              theDoc.Color.Red = 0;
              theDoc.Color.Green = 0;
              theDoc.FillRect();

              theDoc.Rect.String = "415 167 540 168"; //line below signature
              theDoc.Color.Blue = 0;
              theDoc.Color.Red = 0;
              theDoc.Color.Green = 0;
              theDoc.FillRect();

              theDoc.Rect.String = "415 198 540 199";//line below signature
              theDoc.Color.Blue = 0;
              theDoc.Color.Red = 0;
              theDoc.Color.Green = 0;
              theDoc.FillRect();

              //Code for rectangle around amount
              theDoc.Rect.String = "437 85 540 86";
              theDoc.Color.Blue = 0;
              theDoc.Color.Red = 0;
              theDoc.Color.Green = 0;
              theDoc.FillRect();


              theDoc.Rect.String = "437 125 540 126";
              theDoc.Color.Blue = 0;
              theDoc.Color.Red = 0;
              theDoc.Color.Green = 0;
              theDoc.FillRect();
              //vertical lines
              //running a loop because of line's width and color problem
              for (int y = 1; y < 100; y++)
              {
                  theDoc.Rect.String = "437 86 437 126";
                  theDoc.Color.Blue = 0;
                  theDoc.Color.Red = 0;
                  theDoc.Color.Green = 0;
                  theDoc.FillRect();

                  theDoc.Rect.String = "540 86 540 126";
                  theDoc.Color.Blue = 0;
                  theDoc.Color.Red = 0;
                  theDoc.Color.Green = 0;
                  theDoc.FillRect();
              }*/
            #endregion

            theDoc.AddLine(335, 30, 365, 30);
            theDoc.AddLine(415, 167, 540, 167);
            theDoc.AddLine(415, 198, 540, 198);
            theDoc.AddLine(437, 85, 540, 85);
            theDoc.AddLine(437, 125, 540, 125);
            theDoc.AddLine(437, 86, 437, 126);
            theDoc.AddLine(540, 86, 540, 126);

            theImg = new XImage();
            theImg.SetFile(Server.MapPath("../Images/signature.jpg"));
            theDoc.Rect.String = "415 130 540 166";//left top right bottom

            if (m_intCounter == 0)
            {
                SignId = theDoc.AddImageObject(theImg, false);
            }
            else
            {
                theDoc.AddImageCopy(SignId);
            }
            theImg.Clear();
        }
        for (int m_intCounter = 1; m_intCounter <= theDoc.PageCount; m_intCounter++)
        {
            theDoc.PageNumber = m_intRetVal;
            theDoc.Flatten();
        }

        m_strFileName = Server.MapPath("PrintChecks_" + System.DateTime.Now.ToString("MMddyyhhmmss") + ".pdf");
        theDoc.Save(m_strFileName);
        theDoc.Clear();


    }
    private void GeneratePDFReportingService()
    {
        try
        {

            rptViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rptViewer.ServerReport.ReportServerUrl = new System.Uri(System.Configuration.ConfigurationSettings.AppSettings["ReportingService.reportservice"]);
            rptViewer.ServerReport.ReportPath = System.Configuration.ConfigurationSettings.AppSettings["ReportPath"] + Request["Path"] + "/rptPrintCheckPDF";
            rptViewer.AsyncRendering = false;
            Microsoft.Reporting.WebForms.ReportParameter p1 = new Microsoft.Reporting.WebForms.ReportParameter("pk_Check_No", Request.Form["chkItem"].ToString());
            rptViewer.ServerReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter[] { p1 });
            rptViewer.ServerReport.Refresh();


            string mimeType, encoding, extension, deviceInfo;
            string[] streamids;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string format = "PDF"; //Desired format goes here (PDF, Excel, or Image)
            deviceInfo =
            "<DeviceInfo>" +
            "<SimplePageHeaders>True</SimplePageHeaders>" +
            "</DeviceInfo>";
            byte[] bytes = rptViewer.ServerReport.Render(format, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
            //Response.Clear();

            if (format == "PDF")
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-disposition", "attachment;filename=output.pdf");
            }
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /// <summary>
    /// Function for Get Given Amount in Words.
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    private string Words_Money(decimal num)
    {
        Int64 dollars;
        Int64 cents;
        string dollars_result;
        string cents_result;
        string Result_Words_Money;
        //  Dollars.
        dollars = Convert.ToInt64(num);
        dollars_result = Words_1_all(dollars);
        if ((dollars_result.Length == 0))
        {
            dollars_result = "Zero";
        }
        //if ((dollars_result == "one")) {
        //    dollars_result = dollars_result;
        //}
        //else {
        //    dollars_result = dollars_result;
        //}
        //  Cents.
        cents = Convert.ToInt64(((num - dollars) * 100));
        if ((Convert.ToDouble(cents) != 0))
        {
            cents_result = (" and " + (cents + "/100 "));
        }
        else
        {
            cents_result = " and 00/100 ";
        }
        //  Combine the results.
        Result_Words_Money = (dollars_result + cents_result);
        for (int i = Result_Words_Money.Length; (i <= 80); i++)
        {
            Result_Words_Money = (Result_Words_Money + "*");
        }
        return Result_Words_Money;
    }
    private string Words_1_all(Int64 num)
    {
        Int64[] power_value = new Int64[6];
        string[] power_name = new string[6];
        Int64 digits;
        string result = string.Empty;
        //  Initialize the power names and values.
        power_name[1] = "Trillion";
        power_name[2] = "Billion";
        power_name[3] = "Million";
        power_name[4] = "Thousand";
        power_name[5] = "";

        power_value[1] = 1000000000000;
        power_value[2] = 1000000000;
        power_value[3] = 1000000;
        power_value[4] = 1000;
        power_value[5] = 1;

        for (int i = 1; (i <= 5); i++)
        {
            //  See if we have digits in this range.
            if ((num >= power_value[i]))
            {
                //  Get the digits.
                digits = Convert.ToInt64((num / power_value[i]));
                //  Add the digits to the result.
                if ((result.Length > 0))
                {
                    result = (result + ", ");
                }
                result = (result + (Words_1_999(digits) + (" " + power_name[i])));
                //  Get the number without these digits.
                num = (num - (digits * power_value[i]));
            }
        }
        return result.Trim();
    }
    private string Words_1_999(Int64 num)
    {
        Int64 hundreds;
        Int64 remainder;
        string result = string.Empty;
        hundreds = num / 100;
        remainder = (num - (hundreds * 100));
        if ((hundreds > 0))
        {
            result = (Words_1_19(hundreds) + " Hundred ");
        }
        if ((remainder > 0))
        {
            result = (result + Words_1_99(remainder));
        }
        return result.Trim();
    }
    private string Words_1_99(Int64 num)
    {
        string result = string.Empty;
        Int64 tens;
        tens = num / 10;
        if ((tens <= 1))
        {
            //  1 <= num <= 19
            result = (result + (" " + Words_1_19(num)));
        }
        else
        {
            //  20 <= num
            //  Get the tens digit word.
            switch (tens)
            {
                case 2:
                    result = "Twenty";
                    break;
                case 3:
                    result = "Thirty";
                    break;
                case 4:
                    result = "Forty";
                    break;
                case 5:
                    result = "Fifty";
                    break;
                case 6:
                    result = "Fixty";
                    break;
                case 7:
                    result = "Seventy";
                    break;
                case 8:
                    result = "Eighty";
                    break;
                case 9:
                    result = "Ninety";
                    break;
            }
            //  Add the ones digit number.
            result = (result + (" " + Words_1_19((num
                            - (tens * 10)))));
        }
        return result.Trim();
    }
    //  Return a word for this value between 1 and 19.
    private string Words_1_19(Int64 num)
    {
        string Words_1_19 = string.Empty;
        switch (num)
        {
            case 1:
                Words_1_19 = "One";
                break;
            case 2:
                Words_1_19 = "Two";
                break;
            case 3:
                Words_1_19 = "Three";
                break;
            case 4:
                Words_1_19 = "Four";
                break;
            case 5:
                Words_1_19 = "Five";
                break;
            case 6:
                Words_1_19 = "Six";
                break;
            case 7:
                Words_1_19 = "Seven";
                break;
            case 8:
                Words_1_19 = "Eight";
                break;
            case 9:
                Words_1_19 = "Nine";
                break;
            case 10:
                Words_1_19 = "Ten";
                break;
            case 11:
                Words_1_19 = "Eleven";
                break;
            case 12:
                Words_1_19 = "Twelve";
                break;
            case 13:
                Words_1_19 = "Thirteen";
                break;
            case 14:
                Words_1_19 = "Fourteen";
                break;
            case 15:
                Words_1_19 = "Fifteen";
                break;
            case 16:
                Words_1_19 = "Sixteen";
                break;
            case 17:
                Words_1_19 = "Seventeen";
                break;
            case 18:
                Words_1_19 = "Eightteen";
                break;
            case 19:
                Words_1_19 = "Nineteen";
                break;
        }
        return Words_1_19;
    }
    #endregion


}
