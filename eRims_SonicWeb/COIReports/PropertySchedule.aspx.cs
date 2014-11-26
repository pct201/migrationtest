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

public partial class COIReports_PropertySchedule : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataTable dtReport = clsCOIReports.PropertyScheduleTesting().Tables[0];
            btnExport.Visible = dtReport.Rows.Count > 0;
            gvReport.DataSource = GetTotals(dtReport);
            gvReport.DataBind();
            ViewState["dtReport"] = dtReport;

        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        // Export the data into excel spreadsheet
        //GridViewExportUtil.ExportGrid((DataTable)ViewState["dtReport"], "Property Schedule Testing");
        GridViewExportUtil.ExportGrid("Property Schedule Testing",gvReport);
    }

    private DataTable GetTotals(DataTable dtSource)
    {
        // Copy the source table to destination table
        DataTable dtDest = dtSource.Copy();

        int intLoopIndex = 0; // counter for the rows to loop through
        int intRowsAdded = 0; // counter for the rows added
        int intStateTotal = 0;

        // create array for State totals
        decimal[] decStateTotal = new decimal[7];
        for (int j = 0; j <= 6; j++)
            decStateTotal[j] = 0;
        if (dtSource.Rows.Count > 0)
        {
            // loop through the source table
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                intLoopIndex = i; // starting from ith position

                //select rows having the same State name
                DataRow[] drState = dtSource.Select("ST = '" + dtSource.Rows[i]["ST"].ToString() + "'");


                //if array length is 0 then find for null values in State Column
                if (drState.Length == 0)
                    drState = dtSource.Select("ST is null");

                #region "Add Location Totals Row"

                // select Locations for perticular State
                DataRow[] drLocation = dtSource.Select("ST = '" + drState[0]["ST"].ToString() + "' and [STATUS OF LOCATION] = '" + dtSource.Rows[i]["STATUS OF LOCATION"].ToString() + "'");

                // create array for Location totals
                int intLocTotal = 0;
                decimal[] decLocTotal = new decimal[7];
                for (int j = 0; j <= 6; j++)
                    decLocTotal[j] = 0;

                DataRow drLocTotal = dtDest.NewRow();
                // count totals for Locations
                foreach (DataRow dr in drLocation)
                {
                    for (int j = 0; j <= 6; j++)
                    {
                        decLocTotal[j] += (Convert.ToString(dr[j + 19]) != string.Empty) ? Convert.ToDecimal(dr[j + 19]) : 0;
                        drLocTotal[j + 19] = decLocTotal[j] != 0 ? decLocTotal[j].ToString() : string.Empty;
                        decStateTotal[j] += decLocTotal[j];
                    }
                    intLocTotal++;
                    intStateTotal++;
                    intLoopIndex++; // increment the loop index for the next row
                }

                drLocTotal[1] = " Total " + drLocation[0]["STATUS OF LOCATION"].ToString();
                drLocTotal[2] = intLocTotal;
                // insert the row after the last row position 
                dtDest.Rows.InsertAt(drLocTotal, intLoopIndex + intRowsAdded);

                #endregion
                intRowsAdded++; // increment the counter as we have added a row

                dtDest.Rows.InsertAt(dtDest.NewRow(), intLoopIndex + intRowsAdded);
                intRowsAdded++;

                #region "Add State Totals Row"

                if (intStateTotal == drState.Length)
                {
                    DataRow drTotal = dtDest.NewRow();
                    drTotal[1] = dtSource.Rows[i]["ST"].ToString() + " Total";
                    drTotal[2] = intStateTotal;
                    for (int j = 0; j <= 6; j++)
                    {
                        drTotal[j + 19] = decStateTotal[j] != 0 ? decStateTotal[j].ToString() : string.Empty;
                        decStateTotal[j] = 0;
                    }
                    // insert the row after the last row position 
                    dtDest.Rows.InsertAt(drTotal, intLoopIndex + intRowsAdded);
                    intRowsAdded++; // increment the counter as we have added a row
                    dtDest.Rows.InsertAt(dtDest.NewRow(), intLoopIndex + intRowsAdded);
                    intRowsAdded++;
                    intStateTotal = 0;
                }

                #endregion


                i = intLoopIndex - 1; // i will now denote the row position of the next row
            }

        }
        ViewState["dtReport"] = dtDest;
        return dtDest;
    }
}
