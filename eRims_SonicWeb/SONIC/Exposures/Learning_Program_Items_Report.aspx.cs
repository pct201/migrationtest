using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_Learning_Program_Items_Report : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    }

    private void BindGrid()
    {
        DataTable dtDetail = Sonic_U_Training.Learning_Program().Tables[0];

        gvLearning_Program.DataSource = dtDetail;
        gvLearning_Program.DataBind();
    }

}