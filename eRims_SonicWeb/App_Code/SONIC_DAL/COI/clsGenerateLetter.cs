using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for GenerateLetter
    /// </summary>
    public class clsGenerateLetter
    {
        public clsGenerateLetter()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region "Methods"
        
        public static DataSet SelectForGenerateLetter()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsSelectForGenerateLetter");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet CheckExpiredOrCancelled()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsCheckExpiredOrCancelled");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet CheckForDeficiency(decimal FK_COIs, string Policy_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsCheckForDeficiency");
            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, FK_COIs);
            db.AddInParameter(dbCommand, "Policy_Type", DbType.String, Policy_Type);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet CheckForNonCompliance(decimal PK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsCheckForNonCompliance");
            db.AddInParameter(dbCommand, "PK_COIs", DbType.Decimal, PK_COIs);         
            return db.ExecuteDataSet(dbCommand);
        }

        public static bool IsValidToGenerateLetter(decimal FK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIsIsValidToGenerateLetter");
            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, FK_COIs);
            db.AddOutParameter(dbCommand, "retValue", DbType.Boolean, 1);
            db.ExecuteNonQuery(dbCommand);
            return bool.Parse(dbCommand.Parameters["@retValue"].Value.ToString());
        }



        #endregion

        # region " Amit New Changes "

        public static DataSet GetExpiredOrCancelledCOIs()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetExpiredOrCancelledCOIs");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetInAdequateCoverageCOIs()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetInAdequateCoverageCOIs");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetNonComplianceDeficiency(decimal FK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetNonComplianceDeficiency");
            db.AddInParameter(dbCommand, "PK_COIs", DbType.Decimal, FK_COIs);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetAdditionalInsuredNonCompliance(decimal PK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAdditionalInsuredNonCompliance");
            db.AddInParameter(dbCommand, "PK_COIs", DbType.Decimal, PK_COIs);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectValidCOIForLetter(decimal FK_Signature)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectValidCOIForLetter");
            db.AddInParameter(dbCommand, "FK_Signature", DbType.Decimal, FK_Signature);
            
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectValidCOIForLetter()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Select_ValidCOIForLetter");
        
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetRequiredPoliciesCOIs()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetRequiredPoliciesCOIs");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetPropertyPolicy_NonComplianceDeficiency(decimal FK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Get_PropertyPolicy_NonComplianceDeficiency_Text");
            db.AddInParameter(dbCommand, "PK_COIs", DbType.Decimal, FK_COIs);
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}