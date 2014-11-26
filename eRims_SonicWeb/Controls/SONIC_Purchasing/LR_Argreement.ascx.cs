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
public partial class CtrlLRAgreement : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (clsSession.Current_LR_Agreement_ID > 0)
            {
                // bind the property identification information
                BindIdentificationInformation();
            }
        }
    }

    private void BindIdentificationInformation()
    {
        // create a new executive risk identification object.            
        Purchasing_LR_Agreement objLR = new Purchasing_LR_Agreement(clsSession.Current_LR_Agreement_ID);

        lblSupplier.Text = objLR.Supplier;
        lblEquipementType.Text = new LU_Equipment_Type(objLR.FK_LU_Equipment_Type).Fld_Desc;
        //lblStartDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objLR.Start_Date)));
        //lblEnddate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objLR.End_Date)));
        lblStartDate.Text = (objLR.Start_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? "" : Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objLR.Start_Date)).ToString("MMM-dd-yyyy"));
        lblEnddate.Text = (objLR.End_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? "" : Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objLR.End_Date)).ToString("MMM-dd-yyyy"));
        lblDepartment.Text = new LU_Dealership_Department(objLR.FK_LU_Dealership_Department).Fld_Desc;

        //LU_Location objLocation = new LU_Location(objLR.FK_LU_Location);
        //lblLocation.Text = objLocation.dba + " - " + objLocation.Address_1 + ", " + objLocation.City + ", " + new State(objLocation.State == "" ? 0 : Convert.ToDecimal(objLocation.State)).FLD_state;


        DataSet dsLocation = Purchasing_LR_Dealer.SelectByLR_Agreement(clsSession.Current_LR_Agreement_ID, "Asc");
        if (dsLocation != null && dsLocation.Tables.Count > 0 && dsLocation.Tables[0].Rows.Count > 0)
        {
            string strLocation = "";
            if (dsLocation.Tables[0].Rows.Count == 1)
            {
                strLocation = Convert.ToString(dsLocation.Tables[0].Rows[0]["dba"]) + " - " + Convert.ToString(dsLocation.Tables[0].Rows[0]["city"]) + ", " + Convert.ToString(dsLocation.Tables[0].Rows[0]["state"]);
                lblLocation.Text =strLocation;
            }
            else
            {
                strLocation = "Multiple <br/>";
                DataTable dtLocation = dsLocation.Tables[0].DefaultView.ToTable(true, new string[] { "dba", "city", "state" });
                if (dtLocation != null && dtLocation.Rows.Count > 1)
                {
                    DataTable dtState = dtLocation.DefaultView.ToTable(true, "state");

                    if (dtState != null)
                    {
                        dtState.DefaultView.Sort = "[state] asc";
                        foreach (DataRow dr in dtState.Rows)
                        {
                            strLocation += Convert.ToString(dr["state"]) + " <br/>";
                        }
                    }
                    lblLocation.Text = strLocation;
                }
                else
                {
                    strLocation += Convert.ToString(dtLocation.Rows[0]["city"]) + ", " + Environment.NewLine + Convert.ToString(dtLocation.Rows[0]["state"]);
                    lblLocation.Text = strLocation;
                }
            }
        }
    }
}
