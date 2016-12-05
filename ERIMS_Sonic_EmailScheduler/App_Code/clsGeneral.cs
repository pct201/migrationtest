using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace ERIMS_DAL
{
    class clsGeneral
    {
        public clsGeneral()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataSet SelectAuthorByEmail(string strEmailId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecuritySelectByEmail");

            db.AddInParameter(dbCommand, "EmailId", DbType.String, strEmailId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Facility_Construction_Maintenance_Item table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFacilityConstructionMaintenanceItemByItemNumber(string Item_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemSelectByItem_Number");

            db.AddInParameter(dbCommand, "Item_Number", DbType.String, Item_Number);

            return db.ExecuteDataSet(dbCommand);
        }

    }
}
