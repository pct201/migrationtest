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

public partial class PopUP_CostCenter : System.Web.UI.Page
{
    public RIMS_Base.Biz.CSecurity objSecurity;
    DataSet dstSecurity;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objSecurity = new RIMS_Base.Biz.CSecurity();
            dstSecurity = new DataSet();
            dstSecurity = objSecurity.GetCostCenter();
            gvCostCenter.DataSource = dstSecurity;
            gvCostCenter.DataBind();
        }
    }
}
