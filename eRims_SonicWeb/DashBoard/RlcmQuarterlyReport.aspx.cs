using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoSoftGlobal;
using ERIMS.DAL;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using FusionCharts;
using Aspose.Words;

public partial class DashBoard_RlcmQuarterlyReport : clsBasePage
{
    #region "Property"

    string _strRegions = string.Empty;
    string _strRlcms = string.Empty;
    string _strMarket = string.Empty;

    /// <summary>
    /// User id
    /// </summary>
    private int Pk_SecurityId
    {
        get
        {
            if (Session["UserID"] != null)
            { return Convert.ToInt32(Session["UserID"]); }
            else
            { return 0; }
        }
    }

    /// <summary>
    /// idState
    /// </summary>
    private int idState
    {
        get
        {
            if (ddlState.SelectedIndex > -1)
            {
                return Convert.ToInt32(ddlState.SelectedValue);
            }
            else
            {
                return 0;
            }
        }
    }

    private DateTime CurrentFromDate
    {
        get
        {
            return Convert.ToDateTime(txtCurrentFromDate.Text);
        }
    }

    private DateTime CurrentToDate
    {
        get
        {
            return Convert.ToDateTime(txtCurrentToDate.Text);
        }
    }

    private DateTime PriorFromDate
    {
        get
        {
            return Convert.ToDateTime(txtPriorFromDate.Text);
        }
    }

    private DateTime PriorToDate
    {
        get
        {
            return Convert.ToDateTime(txtPriorToDate.Text);
        }
    }

    private string Regions
    {
        get
        {
            //if (idState == 0)
            //{
            _strRegions = MakeCommaSeperatedRegion(false);
            if (_strRegions != string.Empty)
            {
                _strRegions = _strRegions.Remove(_strRegions.LastIndexOf(","));
            }
            return _strRegions;
            //}
            //else { return string.Empty; }
        }
    }

    private string RegionsAll
    {
        get
        {
            //if (idState == 0)
            //{
            _strRegions = MakeCommaSeperatedRegion(true);
            if (_strRegions != string.Empty)
            {
                _strRegions = _strRegions.Remove(_strRegions.LastIndexOf(","));
            }
            return _strRegions;
            //}
            //else { return string.Empty; }
        }
    }

    private string MarketAll
    {
        get
        {
            _strMarket = MakeCommaSeperatedMarket(true);
            if (_strMarket != string.Empty)
            {
                _strMarket = _strMarket.Remove(_strMarket.LastIndexOf(","));
            }
            return _strMarket;
        }

    }

    private string Rlcms
    {
        get
        {
            //if (idState == 0)
            //{
            _strRlcms = MakeCommaSeperatedRlcm();
            if (_strRlcms != string.Empty)
            {
                _strRlcms = _strRlcms.Remove(_strRlcms.LastIndexOf(","));
            }
            return _strRlcms;
            //}
            //else { return string.Empty; }
        }
    }

    private bool SLT
    {
        get
        {
            if (ViewState["SLT"] != null)
            {
                return Convert.ToBoolean(ViewState["SLT"]);
            }
            else
            {
                return false;
            }
        }
        set
        {
            ViewState["SLT"] = value;
        }
    }

    private bool FacilityInspection
    {
        get
        {
            if (ViewState["FacilityInspection"] != null)
            {
                return Convert.ToBoolean(ViewState["FacilityInspection"]);
            }
            else
            {
                return false;
            }
        }
        set
        {
            ViewState["FacilityInspection"] = value;
        }
    }

    private bool SonicUniversity
    {
        get
        {
            if (ViewState["SonicUniversity"] != null)
            {
                return Convert.ToBoolean(ViewState["SonicUniversity"]);
            }
            else
            {
                return false;
            }
        }
        set
        {
            ViewState["SonicUniversity"] = value;
        }
    }

    private bool Investigation
    {
        get
        {
            if (ViewState["Investigation"] != null)
            {
                return Convert.ToBoolean(ViewState["Investigation"]);
            }
            else
            {
                return false;
            }
        }
        set
        {
            ViewState["Investigation"] = value;
        }
    }

    private bool Wc
    {
        get
        {
            if (ViewState["Wc"] != null)
            {
                return Convert.ToBoolean(ViewState["Wc"]);
            }
            else
            {
                return false;
            }
        }
        set
        {
            ViewState["Wc"] = value;
        }
    }

    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlReport.Visible = false;
            pnlCriteria.Visible = true;
            BindDdl();
        }
    }

    /// <summary>
    /// btnRepot click event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReport_Click(object sender, EventArgs e)
    {
        ResetGrid();
        pnlCriteria.Visible = false;
        pnlReport.Visible = true;

        if (rdoSortBy.SelectedValue == "RLCM")
            Label1.Text = "AGGREGATE PERFORMANCE BY RLCM";
        else
            Label1.Text = "AGGREGATE PERFORMANCE BY Region";

        cpeSLTScoring.Collapsed = true;
        cpeSLTScoring.ClientState = "true";
        cpeFacility.Collapsed = true;
        cpeFacility.ClientState = "true";
        cpeUni.Collapsed = true;
        cpeUni.ClientState = "true";
        cpeInvestigation.Collapsed = true;
        cpeInvestigation.ClientState = "true";
        cpeWc.Collapsed = true;
        cpeWc.ClientState = "true";

        string strRegions = string.Empty;
        string strRlcm = string.Empty;
        string strMarket = string.Empty;
        strRlcm = Rlcms;

        //if (strRlcm == string.Empty && !(idState>0))
        //{
        strRegions = RegionsAll;
        //}
        strMarket = MarketAll;

        DataSet ds = new DataSet();
        ds = Charts.RLCMQuarterlyPerformanceReport(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm, rdoSortBy.SelectedValue);

        if (ds.Tables.Count > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "RenderExportComponent();", true);
            divCharts.InnerHtml = string.Empty;
            BindChart(ds);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('No records meet the filter criteria, Report cannot be generated');", true);
            pnlCriteria.Visible = true;
            pnlReport.Visible = false;
        }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtCurrentFromDate.Text = string.Empty;
        txtCurrentToDate.Text = string.Empty;
        txtPriorFromDate.Text = string.Empty;
        txtPriorToDate.Text = string.Empty;
        ddlState.SelectedIndex = 0;
        lstRegion.ClearSelection();
        lstMarket.ClearSelection();
        lstRLCM.ClearSelection();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlCriteria.Visible = true;
        pnlReport.Visible = false;
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (!(gvSLTScoring.Rows.Count > 0) && !(gvRLCMSLTParticipation.Rows.Count > 0) && !(gvTraining.Rows.Count > 0) && !(gvRLCMLagTime.Rows.Count > 0))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('No data available to export.');", true);
        }
        else
        {
            string strXml = string.Empty;
            string strGeneralXml = string.Empty;
            strGeneralXml = clsGeneral.GetGeneralXmlForExcel();

            strXml = GetXmlForSltScoring();
            string excelXml = string.Format(strGeneralXml, strXml);
            DownloadFile(excelXml, "Safety Leadership Teams");
        }
    }

    protected void btnFacilityExport_Click(object sender, EventArgs e)
    {
        if (gvFacilityInspection.Rows.Count > 0)
        {
            string strXml = string.Empty;
            string strGeneralXml = string.Empty;
            strGeneralXml = clsGeneral.GetGeneralXmlForExcel();

            strXml = GetXmlForFacilityInspection();
            string excelXml = string.Format(strGeneralXml, strXml);
            DownloadFile(excelXml, "Facility Inspections");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('No data available to export.');", true);
        }

    }

    protected void btnUniExport_Click(object sender, EventArgs e)
    {
        if (gvSabaTraining.Rows.Count > 0)
        {
            string strXml = string.Empty;
            string strGeneralXml = string.Empty;
            strGeneralXml = clsGeneral.GetGeneralXmlForExcel();

            strXml = GetXmlForSoniUniversity();
            string excelXml = string.Format(strGeneralXml, strXml);
            DownloadFile(excelXml, "Sonic University Training");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('No data available to export.');", true);
        }
    }

    protected void btnWc_Click(object sender, EventArgs e)
    {
        if (gvWc.Rows.Count > 0)
        {
            string strXml = string.Empty;
            string strGeneralXml = string.Empty;

            strGeneralXml = clsGeneral.GetGeneralXmlForExcel();
            strXml = GEtXmlForWc();
            string excelXml = string.Format(strGeneralXml, strXml);
            DownloadFile(excelXml, "Workers Compensation Claims Management & Incident Reduction");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('No data available to export.');", true);
        }
    }

    protected void btnInvestigationExport_Click(object sender, EventArgs e)
    {
        if (gvInvestigation.Rows.Count > 0)
        {
            string strXml = string.Empty;
            string strGeneralXml = string.Empty;

            strGeneralXml = clsGeneral.GetGeneralXmlForExcel();
            strXml = GEtXmlForIncidentInvestigation();
            string excelXml = string.Format(strGeneralXml, strXml);
            DownloadFile(excelXml, "Incident Investigation");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('No data available to export.');", true);
        }
    }

    protected void btnExportAll_Click(object sender, EventArgs e)
    {
        string strXml = string.Empty;
        string strGeneralXml = string.Empty;

        strGeneralXml = clsGeneral.GetGeneralXmlForExcel();

        if (SLT)
        {
            if ((gvSLTScoring.Rows.Count > 0) || (gvRLCMSLTParticipation.Rows.Count > 0) || (gvTraining.Rows.Count > 0) || (gvRLCMLagTime.Rows.Count > 0))
            {
                strXml = GetXmlForSltScoring();
            }
        }
        else
        {
            imgSLTScoring_Click(null, null);

            if ((gvSLTScoring.Rows.Count > 0) || (gvRLCMSLTParticipation.Rows.Count > 0) || (gvTraining.Rows.Count > 0) || (gvRLCMLagTime.Rows.Count > 0))
            {
                strXml = GetXmlForSltScoring();
            }
        }

        if (FacilityInspection)
        {
            if (gvFacilityInspection.Rows.Count > 0)
            {
                strXml = strXml + GetXmlForFacilityInspection();
            }
        }
        else
        {
            imgFacilityInspection_Click(null, null);

            if (gvFacilityInspection.Rows.Count > 0)
            {
                strXml = strXml + GetXmlForFacilityInspection();
            }

        }

        if (SonicUniversity)
        {
            if (gvSabaTraining.Rows.Count > 0)
            {
                strXml = strXml + GetXmlForSoniUniversity();
            }
        }
        else
        {
            imgSonicUnitraining_Click(null, null);
            if (gvSabaTraining.Rows.Count > 0)
            {
                strXml = strXml + GetXmlForSoniUniversity();
            }
        }

        if (Wc)
        {
            if (gvWc.Rows.Count > 0)
            {
                strXml = strXml + GEtXmlForWc();
            }
        }
        else
        {
            imgWc_Click(null, null);
            if (gvWc.Rows.Count > 0)
            {
                strXml = strXml + GEtXmlForWc();
            }
        }

        if (strXml != string.Empty)
        {
            string excelXml = string.Format(strGeneralXml, strXml);
            DownloadFile(excelXml, "RLCM Quarterly Performance Report");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('No data available to export.');", true);
        }
    }

    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        ResetGrid();
        if (rdoSortBy.SelectedValue == "RLCM")
            Label1.Text = "AGGREGATE PERFORMANCE BY RLCM";
        else
            Label1.Text = "AGGREGATE PERFORMANCE BY Region";

        cpeSLTScoring.Collapsed = true;
        cpeSLTScoring.ClientState = "true";
        cpeFacility.Collapsed = true;
        cpeFacility.ClientState = "true";
        cpeUni.Collapsed = true;
        cpeUni.ClientState = "true";
        cpeInvestigation.Collapsed = true;
        cpeInvestigation.ClientState = "true";
        cpeWc.Collapsed = true;
        cpeWc.ClientState = "true";

        string strRegions = string.Empty;
        string strRlcm = string.Empty;
        string strMarket = string.Empty;
        strRlcm = Rlcms;
        strRegions = RegionsAll;
        strMarket = MarketAll;

        DataSet ds = new DataSet();
        ds = Charts.RLCMQuarterlyPerformanceReport(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm, rdoSortBy.SelectedValue);
        string strDir = AppConfig.SitePath + @"temp\";
        if (ds.Tables.Count > 0)
        {
            pnlCriteria.Visible = false;
            pnlReport.Visible = true;
            StringBuilder sb = new StringBuilder();
            string strChart = string.Empty;

            for (int i = 0; i <= ds.Tables.Count - 1; i++)
            {
                if (ds.Tables[i].Rows.Count > 0)
                {
                    strChart = MakeChart(ds.Tables[i], true);
                    string xml = strChart;
                    // string strDir = AppConfig.SitePath + @"temp\";
                    // string strDir = "D:\\Projects\\eRIMS_SONIC_New\\trunk\\eRIMS_Sonic\\eRIMS_SONICWeb\\temp\\";
                    if (!Directory.Exists(strDir))
                    {
                        Directory.CreateDirectory(strDir);
                    }

                    string imageName = "../temp/FusionChart" + i + ".png";
                    ServerSideImageHandler ssh = new ServerSideImageHandler(Server.MapPath("../FusionCharts/MSColumn2D.swf"), 867, 300, xml, string.Empty, Server.MapPath(imageName));
                    ssh.BeginCapture();
                    do
                    {

                    } while (File.Exists(imageName));

                }
            }

            iTextSharp.text.Rectangle pgSize;
            string strPdfpath = Server.MapPath("../temp/FusionChart.pdf");
            pgSize = new iTextSharp.text.Rectangle(867, 300);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(pgSize, 0, 0, 0, 0);
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(strPdfpath, FileMode.Create));
            doc.Open();
            for (int i = 0; i <= ds.Tables.Count - 1; i++)
            {
                string imagepath = Server.MapPath("../temp/FusionChart" + i + ".png");

                try
                {
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath);
                    //Resize image depend upon your need
                    gif.ScaleToFit(867, 300);
                    gif.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    doc.Add(gif);
                }
                catch (iTextSharp.text.DocumentException dex)
                {
                    Response.Write(dex.Message);
                }
                catch (IOException ioex)
                {
                    Response.Write(ioex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
            doc.Close();

            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.AppendHeader("Content-Type", "application/pdf");
            context.Response.AppendHeader("Content-disposition", "attachment; filename=" + "FusionChart.pdf");
            context.Response.WriteFile("../temp/FusionChart.pdf");
            context.Response.Flush();
            if (File.Exists(strDir + "FusionChart.pdf"))
                File.Delete(strDir + "FusionChart.pdf");
            for (int i = 0; i <= ds.Tables.Count - 1; i++)
            {
                if (File.Exists(strDir + "FusionChart" + i + ".png"))
                    File.Delete(strDir + "FusionChart" + i + ".png");
            }

            context.Response.End();
        }

    }

    /// <summary>
    /// binding SLt Scoring Section
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgSLTScoring_Click(object sender, EventArgs e)
    {
        DataSet Ds = new DataSet();
        pnlSLTScoring.Style["display"] = "block";

        if (!(gvSLTScoring.Rows.Count > 0))
        {
            //Setting this property means we have data in grid or we already bind the grid so at the time of export we can use this property to check whether grid is bind or not.
            SLT = true;
            string strRegions = string.Empty;
            string strRlcm = string.Empty;
            string strMarket = string.Empty;
            strRlcm = Rlcms;

            //if (strRlcm == string.Empty && !(idState > 0))
            //{
            strRegions = RegionsAll;
            //}
            strMarket = MarketAll;

            if (rdoSortBy.SelectedValue == "RLCM")
            {
                Ds = Charts.RLCMQuarterlyPerformanceReportGrid_ByRLCM(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, strRlcm);
                ((TemplateField)gvSLTScoring.Columns[0]).HeaderText = "RLCM";
                ((TemplateField)gvRLCMSLTParticipation.Columns[0]).HeaderText = "RLCM";
                ((TemplateField)gvTraining.Columns[0]).HeaderText = "RLCM";
                ((TemplateField)gvRLCMLagTime.Columns[0]).HeaderText = "RLCM";
            }
            else
            {
                Ds = Charts.RLCMQuarterlyPerformanceReportGrid(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, strRlcm);
                ((TemplateField)gvSLTScoring.Columns[0]).HeaderText = "Region";
                ((TemplateField)gvRLCMSLTParticipation.Columns[0]).HeaderText = "Region";
                ((TemplateField)gvTraining.Columns[0]).HeaderText = "Region";
                ((TemplateField)gvRLCMLagTime.Columns[0]).HeaderText = "Region";
            }
            if (Ds != null && Ds.Tables.Count > 0)
            {

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    gvSLTScoring.DataSource = Ds.Tables[0];
                    gvSLTScoring.DataBind();
                }
                else
                {
                    gvSLTScoring.DataSource = null;
                    gvSLTScoring.DataBind();
                }

                if (Ds.Tables[1].Rows.Count > 0)
                {
                    gvRLCMSLTParticipation.DataSource = Ds.Tables[1];
                    gvRLCMSLTParticipation.DataBind();
                }
                else
                {
                    gvRLCMSLTParticipation.DataSource = null;
                    gvRLCMSLTParticipation.DataBind();
                }

                if (Ds.Tables[2].Rows.Count > 0)
                {
                    gvTraining.DataSource = Ds.Tables[2];
                    gvTraining.DataBind();
                }
                else
                {
                    gvTraining.DataSource = null;
                    gvTraining.DataBind();
                }

                if (Ds.Tables[3].Rows.Count > 0)
                {
                    gvRLCMLagTime.DataSource = Ds.Tables[3];
                    gvRLCMLagTime.DataBind();
                }
                else
                {
                    gvRLCMLagTime.DataSource = null;
                    gvRLCMLagTime.DataBind();
                }
                Ds = null;
            }
        }
    }

    /// <summary>
    /// binding Facility Inspection grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgFacilityInspection_Click(object sender, EventArgs e)
    {
        DataSet Ds = new DataSet();

        if (!(gvFacilityInspection.Rows.Count > 0))
        {
            //Setting this property means we have data in grid or we already bind the grid so at the time of export we can use this property to check whether grid is bind or not.
            FacilityInspection = true;

            string strRegions = string.Empty;
            string strRlcm = string.Empty;
            string strMarket = string.Empty;
            strRlcm = Rlcms;

            //if (strRlcm == string.Empty && !(idState > 0))
            //{
            strRegions = RegionsAll;
            //}

            strMarket = MarketAll;
            if (rdoSortBy.SelectedValue == "RLCM")
            {
                Ds = Charts.RLCMFacilityInspections_ByRLCM(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm);
                ((BoundField)gvFacilityInspection.Columns[0]).DataField = "RLCM";
                ((BoundField)gvFacilityInspection.Columns[0]).HeaderText = "RLCM";
            }
            else
            {
                Ds = Charts.RLCMFacilityInspections(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm);
                ((BoundField)gvFacilityInspection.Columns[0]).DataField = "Region";
                ((BoundField)gvFacilityInspection.Columns[0]).HeaderText = "Region";
            }

            if (Ds != null && Ds.Tables[0].Rows.Count > 0)
            {
                divFacility.Style["display"] = "block";
                divFacilityMessgae.Style["display"] = "none";
                gvFacilityInspection.DataSource = Ds.Tables[0];
                gvFacilityInspection.DataBind();
                Ds = null;
            }
            else
            {
                divFacility.Style["display"] = "none";
                divFacilityMessgae.Style["display"] = "block";
                gvFacilityInspection.DataSource = null;
                gvFacilityInspection.DataBind();
            }
        }
    }
    protected void imgInvestigation_Click(object sender, EventArgs e)
    {
        DataSet Ds = new DataSet();

        if (!(gvInvestigation.Rows.Count > 0))
        {
            //Setting this property means we have data in grid or we already bind the grid so at the time of export we can use this property to check whether grid is bind or not.
            Investigation = true;

            string strRegions = string.Empty;
            string strRlcm = string.Empty;
            string strMarket = string.Empty;

            strRlcm = Rlcms;

            //if (strRlcm == string.Empty && !(idState > 0))
            //{
            strRegions = RegionsAll;
            //}
            strMarket = MarketAll;
            if (rdoSortBy.SelectedValue == "RLCM")
            {
                ((TemplateField)gvInvestigation.Columns[0]).HeaderText = "RLCM";
                Ds = Charts.RLCMIncidentInvestigation_ByRLCM(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm);
            }
            else
            {
                ((TemplateField)gvInvestigation.Columns[0]).HeaderText = "Region";
                Ds = Charts.RLCMIncidentInvestigation(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm);
            }

            if (Ds != null && Ds.Tables[0].Rows.Count > 0)
            {
                divInvestigation.Style["display"] = "block";
                divInvestigationMessage.Style["display"] = "none";
                gvInvestigation.DataSource = Ds.Tables[0];
                gvInvestigation.DataBind();
                Ds = null;
            }
            else
            {
                divInvestigation.Style["display"] = "none";
                divInvestigationMessage.Style["display"] = "block";
                gvInvestigation.DataSource = null;
                gvInvestigation.DataBind();
            }
        }
    }

    /// <summary>
    /// Binding Sonic University Training Section
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgSonicUnitraining_Click(object sender, EventArgs e)
    {
        DataSet Ds = new DataSet();

        if (!(gvSabaTraining.Rows.Count > 0))
        {
            //Setting this property means we have data in grid or we already bind the grid so at the time of export we can use this property to check whether grid is bind or not.
            SonicUniversity = true;

            string strRegions = string.Empty;
            string strRlcm = string.Empty;
            string strMarket = string.Empty;

            strRlcm = Rlcms;

            //if (strRlcm == string.Empty && !(idState > 0))
            //{
            strRegions = RegionsAll;
            //}
            strMarket = MarketAll;

            if (rdoSortBy.SelectedValue == "RLCM")
            {
                ((TemplateField)gvSabaTraining.Columns[0]).HeaderText = "RLCM";
                Ds = Charts.RLCMSonicUniversityTraining_ByRLCM(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm);
            }
            else
            {
                ((TemplateField)gvSabaTraining.Columns[0]).HeaderText = "Region";
                Ds = Charts.RLCMSonicUniversityTraining(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm);
            }

            if (Ds != null && Ds.Tables[0].Rows.Count > 0)
            {
                divUni.Style["display"] = "block";
                divUniMessage.Style["display"] = "none";

                gvSabaTraining.DataSource = Ds.Tables[0];
                gvSabaTraining.DataBind();
                Ds = null;
            }
            else
            {
                divUniMessage.Style["display"] = "block";
                divUni.Style["display"] = "none";
                divUniMessage.Visible = true;
                gvSabaTraining.DataSource = null;
                gvSabaTraining.DataBind();
            }
        }
    }

    /// <summary>
    /// Binding Wc grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgWc_Click(object sender, EventArgs e)
    {
        DataSet Ds = new DataSet();

        if (!(gvWc.Rows.Count > 0))
        {
            //Setting this property means we have data in grid or we already bind the grid so at the time of export we can use this property to check whether grid is bind or not.
            Wc = true;
            string strRegions = string.Empty;
            string strRlcm = string.Empty;
            string strMarket = string.Empty;

            strRlcm = Rlcms;

            //if (strRlcm == string.Empty && !(idState > 0))
            //{
            strRegions = RegionsAll;
            //}
            strMarket = MarketAll;

            if (rdoSortBy.SelectedValue == "RLCM")
            {
                Ds = Charts.RLCMWcClaimManagement_ByRLCM(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm);
                ((BoundField)gvWc.Columns[0]).DataField = "RLCM";
                ((BoundField)gvWc.Columns[0]).HeaderText = "RLCM";
            }
            else
            {
                Ds = Charts.RLCMWcClaimManagement(Pk_SecurityId, strRegions, strMarket, idState, CurrentFromDate, CurrentToDate, PriorFromDate, PriorToDate, strRlcm);
                ((BoundField)gvWc.Columns[0]).DataField = "Region";
                ((BoundField)gvWc.Columns[0]).HeaderText = "Region";
            }

            if (Ds != null && Ds.Tables[0].Rows.Count > 0)
            {
                //testSpace.Attributes.Add("style", "text-align: center;");
                divWC.Style["display"] = "block";
                divWCMessage.Style["display"] = "none";
                gvWc.DataSource = Ds.Tables[0];
                gvWc.DataBind();
                Ds = null;
            }
            else
            {
                divWCMessage.Style["display"] = "block";
                divWC.Style["display"] = "none";
                gvWc.DataSource = null;
                gvWc.DataBind();
            }
        }
    }

    /// <summary>
    /// ddl State selected index changed and clearing all grids and list box selection and reseting chart
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lstRegion.ClearSelection();
        //lstRLCM.ClearSelection();
        ResetGrid();
        divCharts.InnerHtml = string.Empty;
    }

    /// <summary>
    /// region list box selected change event clearing all grids and reset ddl state's selected index and reseting chart
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlState.SelectedIndex = 0;
        //lstRLCM.ClearSelection();
        ResetGrid();
        divCharts.InnerHtml = string.Empty;
    }

    protected void lstRLCM_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlState.SelectedIndex = 0;
        //lstRegion.ClearSelection();
        ResetGrid();
        divCharts.InnerHtml = string.Empty;
    }

    protected void gvSLTScoring_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRegion = (Label)e.Row.FindControl("lblRegion");
            Label lblRanking = (Label)e.Row.FindControl("lblRanking");
            Label lblSLT_Score = (Label)e.Row.FindControl("lblSLT_Score");

            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CustomOrder")) == "2")
            {
                e.Row.Font.Bold = true;
            }
        }

        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    e.Row.Cells[0].Text = rdoSortBy.SelectedValue;
        //}
    }

    protected void gvRLCMSLTParticipation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CustomOrder")) == "2")
            {
                e.Row.Font.Bold = true;
            }
        }
    }

    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CustomOrder")) == "2")
            {
                e.Row.Font.Bold = true;
            }
        }
    }

    protected void gvRLCMLagTime_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CustomOrder")) == "2")
            {
                e.Row.Font.Bold = true;
            }
        }
    }

    /// <summary>
    /// gvFaclility Row databoud grid event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFacilityInspection_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPercentagePre = (Label)e.Row.FindControl("lblPercentagePre");
            Label lblPercentageCurr = (Label)e.Row.FindControl("lblPercentageCurr");
            Label lblDefPrior = (Label)e.Row.FindControl("lblDefPrior");
            Label lblDefCurr = (Label)e.Row.FindControl("lblDefCurr");
            Label lblDaysOpenPre = (Label)e.Row.FindControl("lblDaysOpenPre");
            Label lblDaysOpenCurr = (Label)e.Row.FindControl("lblDaysOpenCurr");
            string PercentagePre = string.Empty;
            string PercentageCurr = string.Empty;
            string DefPrior = string.Empty;
            string DefCurr = string.Empty;
            string DaysOpenPre = string.Empty;
            string DaysOpenCurr = string.Empty;

            PercentagePre = clsGeneral.FormatNumber((DataBinder.Eval(e.Row.DataItem, "PercentageCurrentYear")), 0) + "/" + clsGeneral.FormatNumber((DataBinder.Eval(e.Row.DataItem, "PercentageCurrentYearRunningTotal")), 0);
            PercentageCurr = clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "PercentagePriorYear"), 0) + "/" + clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "PercentagePriorYearRunningTotal"), 0);
            DefPrior = clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "TotalDeficienciesCurrentYear"), 0) + "/" + clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "TotalDeficienciesCurrentYearRunningTotal"), 0);
            DefCurr = clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "TotalDeficienciesPriorYear"), 0) + "/" + clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "TotalDeficienciesPriorYearRunningTotal"), 0);
            DaysOpenPre = clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "AvgNoofDaysCurrentYear"), 0) + "/" + clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "AvgNoofDaysCurrentYearRunningTotal"), 0);
            DaysOpenCurr = clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "AvgNoofDaysPriorYear"), 0) + "/" + clsGeneral.FormatNumber(DataBinder.Eval(e.Row.DataItem, "AvgNoofDaysPPriorYearRunningTotal"), 0);

            lblPercentagePre.Text = PercentagePre == "/" ? "" : PercentagePre;
            lblPercentageCurr.Text = PercentageCurr == "/" ? "" : PercentageCurr;
            lblDefPrior.Text = DefPrior == "/" ? "" : DefPrior;
            lblDefCurr.Text = DefCurr == "/" ? "" : DefCurr;
            lblDaysOpenPre.Text = DaysOpenPre == "/" ? "" : DaysOpenPre;
            lblDaysOpenCurr.Text = DaysOpenCurr == "/" ? "" : DaysOpenCurr;

            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CustomOrder")) == "2")
            {
                e.Row.Font.Bold = true;
            }
        }
    }

    protected void gvSabaTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CustomOrder")) == "2")
            {
                e.Row.Font.Bold = true;
            }
        }
    }


    protected void gvInvestigation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CustomOrder")) == "2")
            {
                e.Row.Font.Bold = true;
            }
        }
    }

    protected void gvWc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CustomOrder")) == "2")
            {
                e.Row.Font.Bold = true;
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get Xml for SLT Section
    /// </summary>
    /// <returns></returns>
    private string GetXmlForSltScoring()
    {
        StringBuilder strHTML = new StringBuilder();
        string strStyleId = "s62";

        //SLT scoring Start//
        strHTML.Append("<Worksheet ss:Name='Safety Leadership Teams'>");
        strHTML.Append("<Table><Column ss:Width=\"120\" /><Column ss:Width=\"120\" /><Column ss:Width=\"120\" /><Column ss:Width=\"120\" /><Column ss:Width=\"120\" /><Column ss:Width=\"120\" /><Column ss:Width=\"120\" />");
        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:MergeAcross=\"4\" ss:StyleID=\"s61\"><Data ss:Type=\"String\">SLT Scoring</Data></Cell>");
        strHTML.Append("</Row>");

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data></Cell>");
        strHTML.Append("</Row>");

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + rdoSortBy.SelectedValue + "</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Location/DBA</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Ranking</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Current Points</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Date of Last Meeting Scored</Data></Cell>");
        strHTML.Append("</Row>");



        if (gvSLTScoring.Rows.Count > 0)
        {
            foreach (GridViewRow Row in gvSLTScoring.Rows)
            {
                if (((Label)Row.FindControl("lbldba")).Text == string.Empty)
                { strStyleId = "BoldColumn"; }
                else
                { strStyleId = "s62"; }

                strHTML.Append("<Row>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRegion")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lbldba")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRanking")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblSLT_Score")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblDateScored")).Text + "</Data></Cell>");
                strHTML.Append("</Row>");
            }
        }
        else
        {
            strHTML.Append("<Row>");
            strHTML.Append("<Cell ss:MergeAcross=\"4\" ss:StyleID=\"s28\"><Data ss:Type=\"String\">No Record Found.</Data></Cell>");
            strHTML.Append("</Row>");
        }
        //SLT scoring End//

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data></Cell>");
        strHTML.Append("</Row>");

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:MergeAcross=\"6\" ss:StyleID=\"s61\"><Data ss:Type=\"String\">RLCM SLT Participation</Data></Cell>");
        strHTML.Append("</Row>");

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data></Cell>");
        strHTML.Append("</Row>");

        //RLCM Participation Start//
        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + rdoSortBy.SelectedValue + "</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Location/DBA</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Q1 %</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Q2 %</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Q3 %</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Q4 %</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Annual Participation %</Data></Cell>");
        strHTML.Append("</Row>");

        if (gvRLCMSLTParticipation.Rows.Count > 0)
        {
            foreach (GridViewRow Row in gvRLCMSLTParticipation.Rows)
            {
                if (((Label)Row.FindControl("lbldba")).Text == string.Empty)
                { strStyleId = "BoldColumn"; }
                else
                { strStyleId = "s62"; }

                strHTML.Append("<Row>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRegion")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lbldba")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblQ1")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblQ2")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblQ3")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblQ4")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblAnnual")).Text + "</Data></Cell>");
                strHTML.Append("</Row>");
            }
        }
        else
        {
            strHTML.Append("<Row>");
            strHTML.Append("<Cell ss:MergeAcross=\"6\" ss:StyleID=\"s63\"><Data ss:Type=\"String\">No Record Found.</Data></Cell>");
            strHTML.Append("</Row>");
        }

        //RLCM Participation End//

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data></Cell>");
        strHTML.Append("</Row>");

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:MergeAcross=\"3\" ss:StyleID=\"s61\"><Data ss:Type=\"String\">Quarterly Training Conducted by RLCM</Data></Cell>");
        strHTML.Append("</Row>");

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data></Cell>");
        strHTML.Append("</Row>");


        //Training Start//
        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + rdoSortBy.SelectedValue + "</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Quarter</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Scheduled</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Completed</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Percentage</Data></Cell>");
        strHTML.Append("</Row>");

        if (gvTraining.Rows.Count > 0)
        {
            foreach (GridViewRow Row in gvTraining.Rows)
            {
                if (((Label)Row.FindControl("lblQuarter")).Text == string.Empty)
                { strStyleId = "BoldColumn"; }
                else
                { strStyleId = "s62"; }

                strHTML.Append("<Row>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRegion")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblQuarter")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblScheduled")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblCompleted")).Text + "</Data></Cell>");
                //strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblPercentage")).Text + "</Data></Cell>");
                strHTML.Append("</Row>");
            }
        }
        else
        {
            strHTML.Append("<Row>");
            strHTML.Append("<Cell ss:MergeAcross=\"3\" ss:StyleID=\"s63\"><Data ss:Type=\"String\">No Record Found.</Data></Cell>");
            strHTML.Append("</Row>");
        }
        //Training End//

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data></Cell>");
        strHTML.Append("</Row>");

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:MergeAcross=\"3\" ss:StyleID=\"s61\"><Data ss:Type=\"String\">RLCM Lag Time</Data></Cell>");
        strHTML.Append("</Row>");

        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data></Cell>");
        strHTML.Append("</Row>");

        //RLCM Lag Time Start//
        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + rdoSortBy.SelectedValue + "</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Location/DBA</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Quarter</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Average (Days)</Data></Cell>");
        strHTML.Append("</Row>");

        if (gvRLCMLagTime.Rows.Count > 0)
        {
            foreach (GridViewRow Row in gvRLCMLagTime.Rows)
            {
                if (((Label)Row.FindControl("lbldba")).Text == string.Empty)
                { strStyleId = "BoldColumn"; }
                else
                { strStyleId = "s62"; }

                strHTML.Append("<Row>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRegion")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lbldba")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblQuarter")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblAverageDays")).Text + "</Data></Cell>");
                strHTML.Append("</Row>");
            }
        }
        else
        {
            strHTML.Append("<Row>");
            strHTML.Append("<Cell ss:MergeAcross=\"3\" ss:StyleID=\"s63\"><Data ss:Type=\"String\">No Record Found.</Data></Cell>");
            strHTML.Append("</Row>");
        }

        //RLCM Lag Time End//

        strHTML.Append("</Table>");
        strHTML.Append("</Worksheet>");

        return strHTML.ToString();
    }

    /// <summary>
    /// Get Xml For Facility Inspection Section
    /// </summary>
    /// <returns></returns>
    private string GetXmlForFacilityInspection()
    {
        StringBuilder strHTML = new StringBuilder();
        string strStyleId = "s62";
        string strColumnWidthTag = string.Empty;
        strColumnWidthTag = clsGeneral.GetColumnWidth(gvFacilityInspection, 120);

        strHTML.Append("<Worksheet ss:Name='Facility Inspection'>");
        strHTML.Append("<Table>");
        if (strColumnWidthTag != string.Empty)
            strHTML.Append(strColumnWidthTag);
        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + rdoSortBy.SelectedValue + "</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Location/DBA</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Quarter</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Percentage Completed by Quarter Prior Year/Running Total</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Percentage Completed by Quarter Current Year/Running Total</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Total Number of Deficiencies by Quarter Prior Year/Running Total</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Total Number of Deficiencies by Quarter Current Year/Running Total</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Average Number of Days Open By Quarter Prior Year/Running Total</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Average Number of Days Open By Quarter Current Year/Running Total</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Dashboard Score by Quarter Prior Year/Running Total</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Dashboard Score by Quarter Current Year/Running Total</Data></Cell>");

        strHTML.Append("</Row>");

        if (gvFacilityInspection.Rows.Count > 0)
        {
            foreach (GridViewRow Row in gvFacilityInspection.Rows)
            {
                if (((Label)Row.FindControl("lbldba")).Text == string.Empty)
                { strStyleId = "BoldColumn"; }
                else
                { strStyleId = "s62"; }

                strHTML.Append("<Row>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + Row.Cells[0].Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lbldba")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + Row.Cells[2].Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblPercentagePre")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblPercentageCurr")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblDefPrior")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblDefCurr")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblDaysOpenPre")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblDaysOpenCurr")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + Row.Cells[9].Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + Row.Cells[10].Text + "</Data></Cell>");
                strHTML.Append("</Row>");
            }
        }
        else
        {
            strHTML.Append("<Row>");
            strHTML.Append("<Cell ss:MergeAcross=\"10\" ss:StyleID=\"s63\"><Data ss:Type=\"String\">No Record Found.</Data></Cell>");
            strHTML.Append("</Row>");
        }

        strHTML.Append("</Table>");
        strHTML.Append("</Worksheet>");

        return strHTML.ToString();
    }

    /// <summary>
    /// Get Xml for Sonic University Section
    /// </summary>
    /// <returns></returns>
    private string GetXmlForSoniUniversity()
    {

        StringBuilder strHTML = new StringBuilder();
        string strStyleId = "s62";
        string strColumnWidthTag = string.Empty;
        strColumnWidthTag = clsGeneral.GetColumnWidth(gvSabaTraining, 120);

        strHTML.Append("<Worksheet ss:Name='Sonic University Training'>");
        strHTML.Append("<Table>");
        if (strColumnWidthTag != string.Empty)
            strHTML.Append(strColumnWidthTag);
        strHTML.Append("<Row>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + rdoSortBy.SelectedValue + "</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Location/DBA</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Quarter</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Number To Be Trained/Prior Year</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Number To Be Trained/Current Year</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Number Trained/Prior Year</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Number Trained/Current Year</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Score/Prior Year</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Score/Current Year</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Running Score/Prior Year</Data></Cell>");
        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">Running Score/Current Year</Data></Cell>");

        strHTML.Append("</Row>");

        if (gvSabaTraining.Rows.Count > 0)
        {
            foreach (GridViewRow Row in gvSabaTraining.Rows)
            {
                if (((Label)Row.FindControl("lbldba")).Text == string.Empty)
                { strStyleId = "BoldColumn"; }
                else
                { strStyleId = "s62"; }

                strHTML.Append("<Row>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRegion")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lbldba")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblQuarter")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblTo_Be_Trained_Prev")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblTo_Be_Trained_Curr")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblTotal_Trained_Prev")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblTotal_Trained_Curr")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblScore_Prev")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblScore_Curr")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRun_Score_Prev")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRun_Score_Curr")).Text + "</Data></Cell>");
                strHTML.Append("</Row>");
            }
        }
        else
        {
            strHTML.Append("<Row>");
            strHTML.Append("<Cell ss:MergeAcross=\"10\" ss:StyleID=\"s62\"><Data ss:Type=\"String\">No Record Found.</Data></Cell>");
            strHTML.Append("</Row>");
        }

        strHTML.Append("</Table>");
        strHTML.Append("</Worksheet>");

        return strHTML.ToString();
    }

    /// <summary>
    /// Get xml string for Incident Investigation
    /// </summary>
    /// <returns></returns>
    private string GEtXmlForIncidentInvestigation()
    {
        StringBuilder strHTML = new StringBuilder();
        string strStyleId = "s62";
        string strColumnWidthTag = string.Empty;
        strColumnWidthTag = clsGeneral.GetColumnWidth(gvInvestigation, 120);

        strHTML.Append("<Worksheet ss:Name='Incident Investigation'>");
        strHTML.Append("<Table>");

        if (strColumnWidthTag != string.Empty)
            strHTML.Append(strColumnWidthTag);

        if (gvInvestigation.Rows.Count > 0)
        {
            strHTML.Append("<Row>");

            for (int i = 0; i <= gvInvestigation.HeaderRow.Cells.Count - 1; i++)
            {
                strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + gvInvestigation.HeaderRow.Cells[i].Text + "</Data></Cell>");
            }
            strHTML.Append("</Row>");

            foreach (GridViewRow Row in gvInvestigation.Rows)
            {
                if (((Label)Row.FindControl("lbldba")).Text == string.Empty)
                { strStyleId = "BoldColumn"; }
                else
                { strStyleId = "s62"; }

                strHTML.Append("<Row>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRegion")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lbldba")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblQuarter")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblScore_Prev_Year")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblScore_Curr_Year")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRun_Score_Prev_Year")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRun_Score_Curr_Year")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblLagTime_Prev_Year")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblLagTime_Curr_Year")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRun_LagTime_Prev_Year")).Text + "</Data></Cell>");
                strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lblRun_LagTime_Curr_Year")).Text + "</Data></Cell>");
                strHTML.Append("</Row>");
            }
        }
        else
        {
            strHTML.Append("<Row>");
            strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">No Record Found.</Data></Cell>");
            strHTML.Append("</Row>");
        }

        strHTML.Append("</Table>");
        strHTML.Append("</Worksheet>");

        return strHTML.ToString();
    }

    /// <summary>
    /// Get xml for Wc Section
    /// </summary>
    /// <returns></returns>
    private string GEtXmlForWc()
    {
        StringBuilder strHTML = new StringBuilder();
        string strStyleId = "s62";
        string strColumnWidthTag = string.Empty;
        strColumnWidthTag = clsGeneral.GetColumnWidth(gvWc, 120);

        strHTML.Append("<Worksheet ss:Name='Workers Compensation Claims Management & Incident Reduction'>");
        strHTML.Append("<Table>");

        if (strColumnWidthTag != string.Empty)
            strHTML.Append(strColumnWidthTag);

        if (gvWc.Rows.Count > 0)
        {
            strHTML.Append("<Row>");

            for (int i = 0; i <= gvWc.HeaderRow.Cells.Count - 1; i++)
            {
                strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + gvWc.HeaderRow.Cells[i].Text + "</Data></Cell>");
            }
            strHTML.Append("</Row>");

            foreach (GridViewRow Row in gvWc.Rows)
            {
                if (((Label)Row.FindControl("lbldba")).Text == string.Empty)
                { strStyleId = "BoldColumn"; }
                else
                { strStyleId = "s62"; }

                strHTML.Append("<Row>");
                for (int i = 0; i <= Row.Cells.Count - 1; i++)
                {
                    if (i == 1)
                        strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + ((Label)Row.FindControl("lbldba")).Text + "</Data></Cell>");
                    else
                        strHTML.Append("<Cell ss:StyleID=\"" + strStyleId + "\"><Data ss:Type=\"String\">" + Row.Cells[i].Text + "</Data></Cell>");
                }
                strHTML.Append("</Row>");
            }
        }
        else
        {
            strHTML.Append("<Row>");
            strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">No Record Found.</Data></Cell>");
            strHTML.Append("</Row>");
        }

        strHTML.Append("</Table>");
        strHTML.Append("</Worksheet>");

        return strHTML.ToString();
    }

    private void DownloadFile(string strHTML, string sectionName)
    {
        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        context.Response.AppendHeader("Content-Type", "application/vnd.ms-excel");
        context.Response.AppendHeader("Content-disposition", "attachment; filename=" + sectionName + ".xls");
        context.Response.Write(strHTML);
        context.Response.Flush();
        context.Response.End();
        context = null;
    }

    /// <summary>
    /// Reset all grids sets datasources to null
    /// </summary>
    private void ResetGrid()
    {
        SLT = false;
        SonicUniversity = false;
        FacilityInspection = false;
        Investigation = false;
        Wc = false;

        gvSLTScoring.DataSource = null;
        gvSLTScoring.DataBind();

        gvRLCMSLTParticipation.DataSource = null;
        gvRLCMSLTParticipation.DataBind();

        gvTraining.DataSource = null;
        gvTraining.DataBind();

        gvRLCMLagTime.DataSource = null;
        gvRLCMLagTime.DataBind();

        gvFacilityInspection.DataSource = null;
        gvFacilityInspection.DataBind();

        gvSabaTraining.DataSource = null;
        gvSabaTraining.DataBind();

        gvInvestigation.DataSource = null;
        gvInvestigation.DataBind();

        gvWc.DataSource = null;
        gvWc.DataBind();
    }

    /// <summary>
    /// bind dropdwonlist and list box
    /// </summary>
    private void BindDdl()
    {
        ComboHelper.FillState(new DropDownList[] { ddlState }, 0, true);
        ComboHelper.FillRegionListBox(new ListBox[] { lstRegion }, false);
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
        ComboHelper.FillRlcmListBox(new ListBox[] { lstRLCM }, false);
    }


    /// <summary>
    /// Make comma seperated list of regions
    /// </summary>
    /// <returns></returns>
    private string MakeCommaSeperatedRegion(bool isAll)
    {
        string strRegions = string.Empty;

        foreach (ListItem Li in lstRegion.Items)
        {
            if (Li.Selected)
            {
                strRegions = strRegions + "" + Li.Value.Replace("'", "''") + ",";
            }
        }

        if (strRegions == string.Empty && isAll)
        {
            foreach (ListItem Li in lstRegion.Items)
            {
                strRegions = strRegions + "" + Li.Value.Replace("'", "''") + ",";
            }
        }

        return strRegions;
    }

    private string MakeCommaSeperatedMarket(bool isAll)
    {
        string strMarket = string.Empty;

        foreach (ListItem Li in lstMarket.Items)
        {
            if (Li.Selected)
            {
                strMarket = strMarket + "" + Li.Value.Replace("'", "''") + ",";
            }
        }

        if (strMarket == string.Empty && isAll)
        {
            strMarket = "0,";
            foreach (ListItem Li in lstMarket.Items)
            {
                strMarket = strMarket + "" + Li.Value.Replace("'", "''") + ",";
            }
        }

        return strMarket;
    }

    /// <summary>
    /// Make comma seperated list of Rlcm
    /// </summary>
    /// <returns></returns>
    private string MakeCommaSeperatedRlcm()
    {
        string strRlcm = string.Empty;

        foreach (ListItem Li in lstRLCM.Items)
        {
            if (Li.Selected)
            {
                strRlcm = strRlcm + "" + Li.Value.Replace("'", "''") + ",";
            }
        }

        //if (strRlcm == string.Empty)
        //{
        //    foreach (ListItem Li in lstRLCM.Items)
        //    {
        //        strRlcm = strRlcm + "" + Li.Value.Replace("'", "''") + ",";
        //    }
        //}
        return strRlcm;
    }

    /// <summary>
    /// Bind the chart
    /// </summary>
    /// <param name="ds"></param>
    private void BindChart(DataSet ds)
    {
        StringBuilder sb = new StringBuilder();
        string strChart = string.Empty;

        if (ds != null && ds.Tables.Count > 0)
        {
            for (int i = 0; i <= ds.Tables.Count - 1; i++)
            {
                if (ds.Tables[i].Rows.Count > 0)
                {
                    strChart = MakeChart(ds.Tables[i], false);
                    sb.Append(MakeHtml(strChart));
                    divCharts.InnerHtml = sb.ToString();
                }
            }
        }
    }

    /// <summary>
    /// Make Chart makig chart string
    /// </summary>
    /// <param name="dt">datatable of related chart to be generated</param>    
    /// <returns></returns>
    private string MakeChart(DataTable dt, bool blnNumber)
    {
        StringBuilder strChartXML = new StringBuilder();
        strChartXML.Append("<chart caption='" + dt.Rows[0]["SortValue"].ToString() + "' showLabels='1' showvalues='0' showYAxisValues='0' decimals='0' numDivLines ='0' rotateValues='1' exportEnabled='1' exportAtClient='1' exportHandler='fcBatchExporter' html5exporthandler='fcBatchExporter' exportAction='Save'>");

        strChartXML.Append("<categories>");

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            strChartXML.Append("<category label='" + Convert.ToString(dt.Rows[i]["Type"]) + "' />");
        }

        strChartXML.Append("</categories>");

        decimal Score = 0;
        decimal ToolTip = 0;
        decimal _decAvg = 0;
        string strLink = string.Empty;

        _decAvg = Convert.ToDecimal(dt.Rows[0]["score"]);

        strChartXML.Append("<dataset seriesname='PriorYear' color='ff914c'>");

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {

            Score = Convert.ToDecimal(dt.Rows[i]["PreviousScore"]);
            ToolTip = Convert.ToDecimal(dt.Rows[i]["ToolTip_Previous"]);
            if (Convert.ToString(dt.Rows[i]["Type"]).ToLower() == "aggregate performance")
                ToolTip = (ToolTip / 200) * 100;
            //strLink = Server.UrlEncode("javascript:TotalCasesByMonth(" + i.ToString() + "," + (DateTime.Now.Year - 1).ToString() + ");").Replace("'", "%26apos;").Replace("&", "%26");
            strLink = string.Empty;
            strChartXML.Append("<set value='" + Score.ToString() + "'  link='" + strLink + "' toolText='" + ToolTip.ToString() + "' />");

            Score = 0;
        }

        //GetTreadLineStyle(strChartXML, _decAvg);
        _decAvg = 0;
        strChartXML.Append("</dataset>");

        strChartXML.Append("<dataset seriesname='CurrentYear' color='f6bf18'>");
        //strChartXML.Append("<dataset>");

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {

            Score = Convert.ToDecimal(dt.Rows[i]["Score"]);
            ToolTip = Convert.ToDecimal(dt.Rows[i]["ToolTip_Current"]);
            if (Convert.ToString(dt.Rows[i]["Type"]).ToLower() == "aggregate performance")
                ToolTip = (ToolTip / 200) * 100;
            //Color = Convert.ToString(dtSeries1.Rows[i - 1]["Color"]);            
            //strLink = Server.UrlEncode("javascript:TotalCasesByMonth(" + i.ToString() + "," + (DateTime.Now.Year).ToString() + ");").Replace("'", "%26apos;").Replace("&", "%26");
            strLink = string.Empty;
            strChartXML.Append("<set value='" + Score.ToString() + "'  link='" + strLink + "' toolText='" + ToolTip.ToString() + "' />");

            Score = 0;
        }

        //_decAvg = Convert.ToDecimal(dt.Rows[0]["score"]);
        //GetTreadLineStyle(strChartXML, _decAvg);

        strChartXML.Append("</dataset>");

        GetTreadLineStyle(strChartXML, 0);

        strChartXML.Append("</chart>");

        StringBuilder sbChart = new StringBuilder();
        //sbChart.Append(InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/MSColumn2D.swf?ChartNoDataText=No data to display for:" + dt.Rows[0]["region"].ToString().Replace(" ", "").Replace("-", "") + "", "", strChartXML.ToString(), dt.Rows[0]["region"].ToString().Replace(" ", "").Replace("-", ""), "98%", "300", false, true));
        sbChart.Append(InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/MSColumn2D.swf?ChartNoDataText=No data to display for:" + dt.Rows[0]["SortValue"].ToString().Replace(" ", "").Replace("-", "") + "", "", strChartXML.ToString(), dt.Rows[0]["SortValue"].ToString().Replace(" ", "").Replace("-", "").Replace("/", ""), "98%", "300", false, true));
        if (blnNumber)
            return strChartXML.ToString();
        else
            return sbChart.ToString();
    }

    /// <summary>
    /// Append Chart string to new div
    /// </summary>
    /// <param name="sbChart">Chart string</param>
    /// <returns></returns>
    private string MakeHtml(String sbChart)
    {
        StringBuilder sbHtml = new StringBuilder();
        sbHtml.Append("<div style='border: solid 1px #666666;' class='gen-chart-render'>");
        sbHtml.Append(sbChart);
        sbHtml.Append("</div>");
        sbHtml.Append("<br/>");

        return sbHtml.ToString();
    }

    /// <summary>
    /// Set Property of pages
    /// </summary>
    /// <param name="strChartXML"></param>
    /// <param name="Average"></param>
    private void GetTreadLineStyle(StringBuilder strChartXML, decimal Average)
    {
        // set Tread Lines
        strChartXML.Append("<trendLines>");
        strChartXML.Append("<line startValue='4' color='49563A' displayvalue='Spectator' /> ");
        strChartXML.Append("<line startValue='10' color='49563A' displayvalue='Water boy' /> ");
        strChartXML.Append("<line startValue='16' color='49563A' displayvalue='Second String' /> ");
        strChartXML.Append("<line startValue='22' color='49563A' displayvalue='Starter' /> ");
        strChartXML.Append("<line startValue='28' color='49563A' displayvalue='All Pro' /> ");
        //strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");

        strChartXML.Append("</trendLines>");

        // set Style for Chart objects
        strChartXML.Append("<styles>");
        strChartXML.Append("<definition>");
        strChartXML.Append("<style type='font' name='CaptionFont' color='666666' size='12'/>");
        strChartXML.Append("<style type='font' name='SubCaptionFont' bold='0'/>");
        strChartXML.Append("</definition>");
        strChartXML.Append("<application>");
        strChartXML.Append("<apply toObject='caption' styles='CaptionFont'/>");
        strChartXML.Append("<apply toObject='SubCaption' styles='SubCaptionFont'/>");
        strChartXML.Append("</application>");
        strChartXML.Append("</styles>");
    }

    #endregion
}