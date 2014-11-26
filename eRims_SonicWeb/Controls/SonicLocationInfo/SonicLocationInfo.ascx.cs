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

public partial class Controls_SonicLocationInfo_SonicLocationInfo : System.Web.UI.UserControl
{
    decimal _decLocationID = 0m;
    decimal _PK_SLT_Meeting_Schedule = 0m;
    bool _ShowSLT_Meeting = false;
    bool _isVisible = true;

    public decimal LocationID
    {
        get { return _decLocationID; }
        set { _decLocationID = value; }
    }
    
    public bool ShowSLT_Meeting
    {
        get { return _ShowSLT_Meeting; }
        set { _ShowSLT_Meeting = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             FillGird();
            
        }
    }

    public void FillGird()
    {
        DataSet dsLocation = new DataSet();
        dsLocation = LU_Location.SelectByPK(LocationID);

        gvLocation.DataSource = dsLocation;
        gvLocation.DataBind();
        gvLocation.Visible = Visible;
        if (ShowSLT_Meeting == true)
            gvLocation.Columns[5].Visible = true;
        else
            gvLocation.Columns[5].Visible = false;
    }
}
