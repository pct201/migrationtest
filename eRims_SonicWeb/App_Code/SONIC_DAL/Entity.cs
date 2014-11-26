using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Entity table.
    /// </summary>
    public sealed class Entity
    {
        #region Fields

        private decimal _PK_Entity;
        private string _Description;
        private string _Code;

        #endregion

        #region Properties

        /// <summary> 
        /// Gets or sets the PK_Entity value.
        /// </summary>
        public decimal PK_Entity
        {
            get { return _PK_Entity; }
            set { _PK_Entity = value; }
        }

        /// <summary> 
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary> 
        /// Gets or sets the Code value.
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Entity class. with the default value.
        /// </summary>
        public Entity()
        {
            this._PK_Entity = -1;
            this._Description = "";
            this._Code = "";
        }

        /// <summary> 
        /// Initializes a new instance of the Entity class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Entity(decimal PK)
        {
            DataTable dtEntity = SelectByPK(PK).Tables[0];
            if (dtEntity.Rows.Count > 0)
            {
                DataRow drEntity = dtEntity.Rows[0];
                this._PK_Entity = drEntity["PK_Entity"] != DBNull.Value ? Convert.ToDecimal(drEntity["PK_Entity"]) : 0;
                this._Description = Convert.ToString(drEntity["Description"]);
                this._Code = Convert.ToString(drEntity["Code"]);
            }
            else
            {
                this._PK_Entity = -1;
                this._Description = "";
                this._Code = "";
            }
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Inserts a record into the Entity table.
        /// </summary>
        /// <returns></returns>
        public void Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EntityInsert");
            db.AddInParameter(dbCommand, "PK_Entity", DbType.Decimal, this._PK_Entity);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Entity table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EntitySelectByPK");
            db.AddInParameter(dbCommand, "PK_Entity", DbType.Decimal, pK_Entity);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Entity table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EntitySelectAll");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Entity table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EntityUpdate");

            db.AddInParameter(dbCommand, "PK_Entity", DbType.Decimal, this._PK_Entity);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Entity table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EntityDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Entity", DbType.Decimal, pK_Entity);

            db.ExecuteNonQuery(dbCommand);
        }


        //public static DataSet SelectDescriptions()
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("EntitySelectDescription");

        //    return db.ExecuteDataSet(dbCommand);
        //}

        //public static DataSet SelectWithLocation()
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("EntiySelectWithLocation");

        //    return db.ExecuteDataSet(dbCommand);
        //}
        public static DataSet SelectDescriptions(decimal pK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EntitySelectDescription");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectWithLocation(decimal pK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EntiySelectWithLocation");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        ///  This function return Eniry records for Passed User ID.
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static DataSet SelectByUserID(decimal UserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Entity_SelectByUser");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectForExecutiveRisk()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EntitySelectForExecutiveRisk");
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
