using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for Building_Insurance_COPE_Descriptors
    /// </summary>
    public sealed class Building_Insurance_COPE_Descriptors
    {
        public Building_Insurance_COPE_Descriptors()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Return Building Insurance COPE Descriptor record list
        /// </summary>
        /// <returns></returns>
        public static DataSet BuildingInsuranceCOPEDescriptorsSelectALL()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_Insurance_COPE_DescriptorsSelectALL");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Update Building Insurance COPE Descriptor record into table
        /// </summary>
        public static void BuildingInsuranceCOPEDescriptorsUpdate(string strXml)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("BuildingInsuranceCOPEDescriptorsUpdate");
            db.AddInParameter(dbCommand, "strXml", DbType.String, strXml);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Get Active Building Insurance COPE Descriptors records into table
        /// </summary>
        /// <returns></returns>
        public static DataSet GetActiveBuildingInsuranceCOPEDescriptors()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectActiveBuildingInsuranceCOPEDescriptors");
            return db.ExecuteDataSet(dbCommand);
        }

    }
}