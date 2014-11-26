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
public partial class Policy_StatePopUp : clsBasePage
{
    public RIMS_Base.Biz.CGeneral m_objState;
    List<RIMS_Base.CGeneral> lstState = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            m_objState = new RIMS_Base.Biz.CGeneral();
            lstState = new List<RIMS_Base.CGeneral>();
            lstState = m_objState.GetAllState();
            gvStates.DataSource = lstState;
            gvStates.DataBind();
        }
    }
    protected void gvStates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
}
