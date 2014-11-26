using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERIMS.DAL;

/// <summary>
/// Summary description for Tatva_RptLossStratificationSchedule
/// </summary>
public class Tatva_RptLossStratificationSchedule : Tatva_ReportSchedule
{
    #region Fields
    private decimal _PK_ID;
    private decimal _FK_Schedule;
    private string _Claim_Type;
    private string _Policy_Year;
    #endregion

    #region Properties
    /// <summary> 
    /// Gets or sets the PK_ID value.
    /// </summary> 
    public decimal PK_ID
    {
        get { return _PK_ID; }
        set { _PK_ID = value; }
    }

    /// <summary> 
    /// Gets or sets the FK_Schedule value.
    /// </summary> 
    public decimal FK_Schedule
    {
        get { return _FK_Schedule; }
        set { _FK_Schedule = value; }
    }

    /// <summary> 
    /// Gets or sets the Claim_Type value.
    /// </summary> 
    public string Claim_Type
    {
        get { return _Claim_Type; }
        set { _Claim_Type = value; }
    }

    /// <summary> 
    /// Gets or sets the Policy_Year value.
    /// </summary> 
    public string Policy_Year
    {
        get { return _Policy_Year; }
        set { _Policy_Year = value; }
    }
    #endregion

    #region Constructors

    /// <summary> 
    /// Initializes a new instance of the Tatva_RptLossStratificationSchedule class. with the default value.
    /// </summary>
    public Tatva_RptLossStratificationSchedule()
    {
        this._PK_ID = -1;
        this._FK_Schedule = -1;
        this._Claim_Type = "";
        this._Policy_Year = "";
    }

    /// <summary> 
    /// Initializes a new instance of the Tatva_RptLossStratificationSchedule class for passed PrimaryKey with the values set from Database.
    /// </summary>
    public Tatva_RptLossStratificationSchedule(decimal PK)
    {
        DataTable dtTatva_RptLossStratificationSchedule = SelectByPK(PK).Tables[0];
        if (dtTatva_RptLossStratificationSchedule.Rows.Count > 0)
        {
            DataRow drTatva_RptLossStratificationSchedule = dtTatva_RptLossStratificationSchedule.Rows[0];
            this._PK_ID = drTatva_RptLossStratificationSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLossStratificationSchedule["PK_ID"]) : 0;
            this._FK_Schedule = drTatva_RptLossStratificationSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLossStratificationSchedule["FK_Schedule"]) : 0;
            this._Claim_Type = Convert.ToString(drTatva_RptLossStratificationSchedule["Claim_Type"]);
            this._Policy_Year = Convert.ToString(drTatva_RptLossStratificationSchedule["Policy_Year"]);
        }
        else
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Claim_Type = "";
            this._Policy_Year = "";
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Inserts a record into the Tatva_RptLossStratificationSchedule table.
    /// </summary>
    /// <returns></returns>
    public new int Insert()
    {

        this.FK_Schedule = base.Insert();

        //SclSeesion.userid
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLossStratificationScheduleInsert");

        //db.AddInParameter(dbCommand, "Scheduled_Date", DbType.DateTime, this._Scheduled_Date);
        //db.AddInParameter(dbCommand, "FK_Report", DbType.Decimal, this._FK_Report);
        //db.AddInParameter(dbCommand, "Fk_RecipientList", DbType.Decimal, this._Fk_RecipientList);
        db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this.FK_Schedule);
        db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this._Claim_Type);
        db.AddInParameter(dbCommand, "Policy_Year", DbType.String, this._Policy_Year);

        // Execute the query and return the new identity value
        int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

        return returnValue;
    }

    /// <summary>
    /// Selects a single record from the Tatva_RptLossStratificationSchedule table by a primary key.
    /// </summary>
    /// <returns>DataSet</returns>
    public new static DataSet SelectByPK(decimal pK_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLossStratificationScheduleSelectByPK");

        db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

        return db.ExecuteDataSet(dbCommand);
    }
    public static DataSet SelectByFK_Schedule(decimal fK_Schedule)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLossStratificationScheduleSelectByFK_Schedule");

        db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, fK_Schedule);

        return db.ExecuteDataSet(dbCommand);
    }
    #endregion
}
