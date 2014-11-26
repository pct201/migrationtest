using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RightType table.
	/// </summary>
	public sealed class RightType
    {

        #region Fields


        private decimal _RightTypeId;
        private string _RightType;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the RightTypeId value.
        /// </summary>
        public decimal RightTypeId
        {
            get { return _RightTypeId; }
            set { _RightTypeId = value; }
        }


        /// <summary> 
        /// Gets or sets the RightType value.
        /// </summary>
        public string RightTypeName
        {
            get { return _RightType; }
            set { _RightType = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the RightType class. with the default value.

        /// </summary>
        public RightType()
        {

            this._RightTypeId = -1;
            this._RightType = "";

        }



        /// <summary> 

        /// Initializes a new instance of the RightType class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public RightType(decimal PK)
        {

            DataTable dtRightType = SelectByPK(PK).Tables[0];

            if (dtRightType.Rows.Count > 0)
            {

                DataRow drRightType = dtRightType.Rows[0];

                this._RightTypeId = drRightType["RightTypeId"] != DBNull.Value ? Convert.ToDecimal(drRightType["RightTypeId"]) : 0;
                this._RightType = Convert.ToString(drRightType["RightType"]);

            }
            else
            {

                this._RightTypeId = -1;
                this._RightType = "";

            }

        }



        #endregion


        #region Method
        /// <summary>
        /// Inserts a record into the RightType table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightTypeInsert");

            db.AddInParameter(dbCommand, "RightType", DbType.String, this._RightType);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the RightType table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal rightTypeId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightTypeSelectByPK");

            db.AddInParameter(dbCommand, "RightTypeId", DbType.Decimal, rightTypeId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RightType table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightTypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the RightType table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightTypeUpdate");

            db.AddInParameter(dbCommand, "RightTypeId", DbType.Decimal, this._RightTypeId);
            db.AddInParameter(dbCommand, "RightType", DbType.String, this._RightType);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the RightType table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal rightTypeId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightTypeDeleteByPK");

            db.AddInParameter(dbCommand, "RightTypeId", DbType.Decimal, rightTypeId);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
