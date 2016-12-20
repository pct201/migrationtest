using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for Sonic_U_Training
    /// </summary>
    public class Sonic_U_Training
    {
        public Sonic_U_Training()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// select by search criteria
        /// </summary>
        /// <returns></returns>
        public static DataSet Associate_Training_Search(decimal? Associate, int year, int quarter,decimal? fk_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_University_Training_Data");
            db.AddInParameter(dbCommand, "FK_Employee_ID", DbType.Decimal, Associate);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, year);
            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, quarter);
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, fk_LU_Location);

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        public static void Manage_Training_Data_InsertUpdate(string Employee_Id, string Code, int year, int quarter, decimal FK_Employee, string Class_Name, bool Completed, decimal? fk_LU_Location, decimal? PK_Sonic_U_Associate_Training_Manual)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Manage_Training_Data_InsertUpdate");
            db.AddInParameter(dbCommand, "Employee_Id", DbType.String, Employee_Id);
            db.AddInParameter(dbCommand, "Code", DbType.String, Code);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, year);
            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, quarter);
            db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, FK_Employee);
            db.AddInParameter(dbCommand, "Class_Name", DbType.String, Class_Name);
            db.AddInParameter(dbCommand, "Completed", DbType.Boolean, Completed);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, fk_LU_Location);
            db.AddInParameter(dbCommand, "PK_Sonic_U_Associate_Training_Manual", DbType.Decimal, PK_Sonic_U_Associate_Training_Manual);           

            dbCommand.CommandTimeout = 10000;
            db.ExecuteNonQuery(dbCommand);
        }

        public static void Complete_Sonic_U_Training(int year, int quarter, decimal fK_Employee,string code,  bool completed)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Complete_Sonic_U_Training");
            db.AddInParameter(dbCommand, "Year", DbType.Int32, year);
            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, quarter);
            db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, fK_Employee);
            db.AddInParameter(dbCommand, "Code", DbType.String, code);
            db.AddInParameter(dbCommand, "Completed", DbType.Boolean, completed);

            dbCommand.CommandTimeout = 10000;
            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet Associate_Training_Data(int quarter, string dba,int year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Associate_Training_Data");
            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, quarter);
            db.AddInParameter(dbCommand, "dba", DbType.String, dba);
            db.AddInParameter(dbCommand, "year", DbType.Int32, year);

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Learning_Program(int year,int quarter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Learning_Program_Curr_Quarter");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, year);
            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, quarter);

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select all Code
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllCode()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SelectAllSonicUTrainingRequiredClassesCode");

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select All Delearship Name
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllDealershipName()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SelectAllSonicUTrainingDealershipName");

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select All department
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllDepartment()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SelectAllSonicUTrainingDepartment");

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select All Learning Program
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllLearningProgram()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SelectAllSonicUTrainingLearningProgram");

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select all Asset
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllAsset()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SelectAllSonicUTrainingAsset");

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select All Learning Program status
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllLearningProgramStatus()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SelectAllSonicUTrainingLearningProgramStatus");

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select all Asset Status
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllAssetStatus()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SelectAllSonicUTrainingAssetStatus");

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        ///Check for Admin or RLCM User
        /// </summary>
        /// <returns></returns>
        public static int  CheckForAdminOrRLCMUser(int pk_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CheckAdminORRLCMUser");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, pk_Security_ID);

            //dbCommand.CommandTimeout = 10000;
            return Convert.ToInt16(db.ExecuteScalar(dbCommand));
        }

        public static void Import_Sonic_U_Training_Associate_Base()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Import_Sonic_U_Training_Associate_Base");

            dbCommand.CommandTimeout = 10000;
            db.ExecuteScalar(dbCommand);
        }

    }
}