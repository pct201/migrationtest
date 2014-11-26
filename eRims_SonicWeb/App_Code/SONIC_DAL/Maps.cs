using System;
using System.Data;
using System.Configuration;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

/// <summary>
/// Summary description for Maps
/// </summary>
public class Maps
{
    public Maps()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    ///  Get number of locations at Sonic by state and by county
    /// </summary>
    /// <returns></returns>
    public static DataTable GetSonicDealershipsByState()
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SonicDealershipsByState");

        return db.ExecuteDataSet(dbCommand).Tables[0];
    }

    /// <summary>
    /// Get number of locations at Sonic by county for the state
    /// </summary>
    /// <param name="strState"></param>
    /// <returns></returns>
    public static DataTable GetSonicDealershipsByCounty(string strState)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SonicDealershipsByCounty");

        db.AddInParameter(dbCommand, "State", DbType.String, strState);

        return db.ExecuteDataSet(dbCommand).Tables[0];
    }

    public static DataTable GetSonicLocationsByState(decimal? FK_State, decimal? FK_County)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("GetSonicLocationsByState");

        db.AddInParameter(dbCommand, "FK_State", DbType.String, FK_State);
        db.AddInParameter(dbCommand, "FK_County", DbType.String, FK_County);

        return db.ExecuteDataSet(dbCommand).Tables[0];
    }

}
