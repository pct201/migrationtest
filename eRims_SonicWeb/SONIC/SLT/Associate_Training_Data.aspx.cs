using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_SLT_Associate_Training_Data : System.Web.UI.Page
{
    /// <summary>
    /// Get DBA Parameter
    /// </summary>
    public string DBA
    {
        get
        {
            return (string.IsNullOrEmpty(Request.QueryString["dba"]) ? string.Empty : Server.UrlDecode(Request.QueryString["dba"]).Replace("&apos;", "'"));
        }
    }

    /// <summary>
    /// Get Year parameter
    /// </summary>
    public Int32 Year
    {
        get
        {
            return clsGeneral.GetInt(Request.QueryString["year"]);
        }
    }

    private int _Quarter;

    public int Quarter
    {
        get { return _Quarter; }
        set { _Quarter = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(DBA))
            {
                Quarter = (DateTime.Now.Month + 2) / 3;
                BindTrainingDetail();
            }
        }
    }

    private void BindTrainingDetail()
    {

        DataTable dtDetail = Sonic_U_Training.Associate_Training_Data(Quarter, DBA, Year).Tables[0];

        gvEmployeeDetail.DataSource = dtDetail;
        gvEmployeeDetail.DataBind();
    }

}