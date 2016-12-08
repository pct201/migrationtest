using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace ERIMS_DAL
{
    /// <summary>
    /// Data Access class for Events
    /// </summary>
    public sealed class Event
    {
        public enum Claim_Major_Coverage : int
        {
            WC = 10,
            GL = 20,
            Auto = 30,
            PD = 40,
            Cargo = 50,
            Legal = 70,
            Custom_Bonds = 100,
            ExecutiveRisk = 90,
            Equipment = 60,
            Personal_Injury = 80,
            Incident = 99,
            Incident_Cargo = 999,
            Event = 1,
            Management = 110
        }

        /// <summary>
        /// Insert Events from csv file
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public DataSet InsertEvents(string FilePath)
        {
            Database db = null;
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();
            try
            {

                db = DatabaseFactory.CreateDatabase();
                dbCommand = db.GetStoredProcCommand("Import_Event");
                dbCommand.CommandTimeout = 1000000;
                db.AddInParameter(dbCommand, "FilePath", DbType.String, FilePath);
                db.AddInParameter(dbCommand, "IsMaster", DbType.Boolean, true);
                ds = db.ExecuteDataSet(dbCommand);
                //string returnValue = Convert.ToString(db.ExecuteScalar(dbCommand));
                return ds;
            }
            catch (Exception ex)
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
                if (db != null)
                {
                    db = null;
                }
                throw ex;
            }
        }

        /// <summary>
        /// Insert Event Records from csv file
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string InsertEventRecords(string FilePath)
        {
            Database db = null;
            DbCommand dbCommand = null;
            try
            {
                db = DatabaseFactory.CreateDatabase();
                dbCommand = db.GetStoredProcCommand("Import_Event");
                dbCommand.CommandTimeout = 1000000;
                db.AddInParameter(dbCommand, "FilePath", DbType.String, FilePath);
                db.AddInParameter(dbCommand, "IsMaster", DbType.Boolean, false);

                string returnValue = Convert.ToString(db.ExecuteScalar(dbCommand));
                return returnValue;
            }
            catch (Exception ex)
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
                if (db != null)
                {
                    db = null;
                }
                throw ex;
            }

        }

        /// <summary>
        /// Inserting Groups from csv file
        /// </summary>
        /// <param name="FilePath">Contains file path for file which is begin imported.</param>
        public void InsertGroups(string FilePath)
        {
            Database db = null;
            DbCommand dbCommand = null;
            try
            {
                db = DatabaseFactory.CreateDatabase();
                dbCommand = db.GetStoredProcCommand("Import_Groups");
                dbCommand.CommandTimeout = 1000000;
                db.AddInParameter(dbCommand, "FilePath", DbType.String, FilePath);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
                if (db != null)
                {
                    db = null;
                }

                throw ex;
            }
        }

        /// <summary>
        /// Inserting Users from csv file
        /// </summary>
        /// <param name="FilePath">Contains file path for file which is begin imported.</param>
        public void InsertUsers(string FilePath)
        {
            Database db = null;
            DbCommand dbCommand = null;
            try
            {
                db = DatabaseFactory.CreateDatabase();
                dbCommand = db.GetStoredProcCommand("Import_Users");
                dbCommand.CommandTimeout = 1000000;
                db.AddInParameter(dbCommand, "FilePath", DbType.String, FilePath);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
                if (db != null)
                {
                    db = null;
                }
                throw ex;
            }
        }

        // <summary>
        /// Import Export ACI Data
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public void ImportExportACIData()
        {
            Database db = null;
            DbCommand dbCommand = null;
            try
            {
                db = DatabaseFactory.CreateDatabase();
                dbCommand = db.GetStoredProcCommand("ImportSonicData");
                dbCommand.CommandTimeout = 1000000;
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
                if (db != null)
                {
                    db = null;
                }
                throw ex;
            }

        }

        /// <summary>
        /// Get Event Abstract Data
        /// </summary>
        /// <param name="strSelectedEvents"></param>
        /// <returns></returns>
        public static DataSet GetEventAbstractLetterData(decimal PK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetEventAbstractLetterData");
            dbCommand.CommandTimeout = 1000000;
            db.AddInParameter(dbCommand, "PK_Event", DbType.Decimal, PK_Event);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Email for Event Update date
        /// </summary>
        /// <param name="strSelectedEvents"></param>
        /// <returns></returns>
        public static DataSet GetEmailsByEventUpdateDate(DateTime StartUpdateDate, DateTime EndUpdateDate, bool Is_ACI_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetEmailsByEventUpdateDate");
            dbCommand.CommandTimeout = 1000000;
            db.AddInParameter(dbCommand, "StartUpdateDate", DbType.DateTime, StartUpdateDate);
            db.AddInParameter(dbCommand, "EndUpdateDate", DbType.DateTime, EndUpdateDate);
            db.AddInParameter(dbCommand, "Is_ACI_Event", DbType.Boolean, Is_ACI_Event);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
