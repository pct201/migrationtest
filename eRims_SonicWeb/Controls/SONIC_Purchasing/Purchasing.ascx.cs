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
/// <summary>
/// Date : 30 MAY 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// Displays Executive Risk identification information on each page of
/// Executive Risk module 
/// 
/// Functionality:
/// Checks for the ID availability
/// and gets the information from DB and sets values in controls
/// </summary>
public partial class CtrlPurchasing : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (clsSession.Current_Purchasing_Service_Contract_ID > 0)
            {
                // bind the property identification information
                BindIdentificationInformation();
            }
        }
    }

    public void BindIdentificationInformation()
    {
        // create a new executive risk identification object.            
        PurchasingServiceContract objSC = new PurchasingServiceContract();
        if (objSC.View(clsSession.Current_Purchasing_Service_Contract_ID))
        {
            lblSupplier.Text = objSC.Supplier;
            lblServiceType.Text = objSC.Service_Type;
            //lblStartDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objSC.Start_Date)));
            //lblEnddate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objSC.End_Date)));
            //Convert.ToDateTime(Eval("Acquisition_Date")) == System.Data.SqlTypes.SqlDateTime.MinValue ? "" : Eval("Acquisition_Date","{0:MMM-dd-yyyy}")
            lblStartDate.Text = (objSC.Start_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? "" : Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objSC.Start_Date)).ToString("MMM-dd-yyyy"));
            lblEnddate.Text = (objSC.End_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? "" : Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objSC.End_Date)).ToString("MMM-dd-yyyy"));

            rptDepartment.DataSource = Purchasing_SC_Department.SelectAllByServiceContract(clsSession.Current_Purchasing_Service_Contract_ID, string.Empty);
            rptDepartment.DataBind();
            rptLocation.DataSource = Purchasing_SC_Dealer.SelectByServiceContract(clsSession.Current_Purchasing_Service_Contract_ID, string.Empty);
            rptLocation.DataBind();
        }
    }
}
