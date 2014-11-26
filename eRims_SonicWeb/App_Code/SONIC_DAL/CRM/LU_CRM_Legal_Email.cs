using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_CRM_Legal_Email table.
    /// </summary>
    public sealed class LU_CRM_Legal_Email
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_CRM_Legal_Email;
        private string _Recipients;
        private string _CC_Recpients;
        private string _Subject;
        private string _Body;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_CRM_Legal_Email value.
        /// </summary>
        public decimal? PK_LU_CRM_Legal_Email
        {
            get { return _PK_LU_CRM_Legal_Email; }
            set { _PK_LU_CRM_Legal_Email = value; }
        }

        /// <summary>
        /// Gets or sets the Recipients value.
        /// </summary>
        public string Recipients
        {
            get { return _Recipients; }
            set { _Recipients = value; }
        }

        /// <summary>
        /// Gets or sets the CC_Recpients value.
        /// </summary>
        public string CC_Recpients
        {
            get { return _CC_Recpients; }
            set { _CC_Recpients = value; }
        }

        /// <summary>
        /// Gets or sets the Subject value.
        /// </summary>
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        /// <summary>
        /// Gets or sets the Body value.
        /// </summary>
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }

        /// <summary>
        /// Gets or sets the Active value.
        /// </summary>
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the LU_CRM_Legal_Email class with default value.
        /// </summary>
        public LU_CRM_Legal_Email()
        {

            this._PK_LU_CRM_Legal_Email = null;
            this._Recipients = null;
            this._CC_Recpients = null;
            this._Subject = null;
            this._Body = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_CRM_Legal_Email class based on Primary Key.
        /// </summary>
        public LU_CRM_Legal_Email(decimal pK_LU_CRM_Legal_Email)
        {
            DataTable dtLU_CRM_Legal_Email = SelectByPK(pK_LU_CRM_Legal_Email).Tables[0];

            if (dtLU_CRM_Legal_Email.Rows.Count == 1)
            {
                DataRow drLU_CRM_Legal_Email = dtLU_CRM_Legal_Email.Rows[0];
                if (drLU_CRM_Legal_Email["PK_LU_CRM_Legal_Email"] == DBNull.Value)
                    this._PK_LU_CRM_Legal_Email = null;
                else
                    this._PK_LU_CRM_Legal_Email = (decimal?)drLU_CRM_Legal_Email["PK_LU_CRM_Legal_Email"];

                if (drLU_CRM_Legal_Email["Recipients"] == DBNull.Value)
                    this._Recipients = null;
                else
                    this._Recipients = (string)drLU_CRM_Legal_Email["Recipients"];

                if (drLU_CRM_Legal_Email["CC_Recpients"] == DBNull.Value)
                    this._CC_Recpients = null;
                else
                    this._CC_Recpients = (string)drLU_CRM_Legal_Email["CC_Recpients"];

                if (drLU_CRM_Legal_Email["Subject"] == DBNull.Value)
                    this._Subject = null;
                else
                    this._Subject = (string)drLU_CRM_Legal_Email["Subject"];

                if (drLU_CRM_Legal_Email["Body"] == DBNull.Value)
                    this._Body = null;
                else
                    this._Body = (string)drLU_CRM_Legal_Email["Body"];

                if (drLU_CRM_Legal_Email["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_CRM_Legal_Email["Active"];

            }
            else
            {
                this._PK_LU_CRM_Legal_Email = null;
                this._Recipients = null;
                this._CC_Recpients = null;
                this._Subject = null;
                this._Body = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_CRM_Legal_Email table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Legal_EmailInsert");


            if (string.IsNullOrEmpty(this._Recipients))
                db.AddInParameter(dbCommand, "Recipients", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Recipients", DbType.String, this._Recipients);

            if (string.IsNullOrEmpty(this._CC_Recpients))
                db.AddInParameter(dbCommand, "CC_Recpients", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CC_Recpients", DbType.String, this._CC_Recpients);

            if (string.IsNullOrEmpty(this._Subject))
                db.AddInParameter(dbCommand, "Subject", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subject", DbType.String, this._Subject);

            if (string.IsNullOrEmpty(this._Body))
                db.AddInParameter(dbCommand, "Body", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Body", DbType.String, this._Body);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_CRM_Legal_Email table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_CRM_Legal_Email)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Legal_EmailSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Legal_Email", DbType.Decimal, pK_LU_CRM_Legal_Email);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_CRM_Legal_Email table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Legal_EmailSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_CRM_Legal_Email table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Legal_EmailUpdate");


            db.AddInParameter(dbCommand, "PK_LU_CRM_Legal_Email", DbType.Decimal, this._PK_LU_CRM_Legal_Email);

            if (string.IsNullOrEmpty(this._Recipients))
                db.AddInParameter(dbCommand, "Recipients", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Recipients", DbType.String, this._Recipients);

            if (string.IsNullOrEmpty(this._CC_Recpients))
                db.AddInParameter(dbCommand, "CC_Recpients", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CC_Recpients", DbType.String, this._CC_Recpients);

            if (string.IsNullOrEmpty(this._Subject))
                db.AddInParameter(dbCommand, "Subject", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subject", DbType.String, this._Subject);

            if (string.IsNullOrEmpty(this._Body))
                db.AddInParameter(dbCommand, "Body", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Body", DbType.String, this._Body);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Deletes a record from the LU_CRM_Legal_Email table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_CRM_Legal_Email)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Legal_EmailDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Legal_Email", DbType.Decimal, pK_LU_CRM_Legal_Email);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
