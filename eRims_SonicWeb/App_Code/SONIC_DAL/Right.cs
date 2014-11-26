using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Right table.
	/// </summary>
	public sealed class Right
    {
        #region Fields


        private int _PK_Right_ID;
        private string _Right_Name;
        private decimal _Module_ID;
        private decimal _RightType_ID;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Right_ID value.
        /// </summary>
        public int PK_Right_ID
        {
            get { return _PK_Right_ID; }
            set { _PK_Right_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Right_Name value.
        /// </summary>
        public string Right_Name
        {
            get { return _Right_Name; }
            set { _Right_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Module_ID value.
        /// </summary>
        public decimal Module_ID
        {
            get { return _Module_ID; }
            set { _Module_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the RightType_ID value.
        /// </summary>
        public decimal RightType_ID
        {
            get { return _RightType_ID; }
            set { _RightType_ID = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Right class. with the default value.

        /// </summary>
        public Right()
        {

            this._PK_Right_ID = -1;
            this._Right_Name = "";
            this._Module_ID = -1;
            this._RightType_ID = -1;

        }



        /// <summary> 

        /// Initializes a new instance of the Right class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Right(int PK)
        {

            DataTable dtRight = SelectByPK(PK).Tables[0];

            if (dtRight.Rows.Count > 0)
            {

                DataRow drRight = dtRight.Rows[0];

                this._PK_Right_ID = drRight["PK_Right_ID"] != DBNull.Value ? Convert.ToInt32(drRight["PK_Right_ID"]) : 0;
                this._Right_Name = Convert.ToString(drRight["Right_Name"]);
                this._Module_ID = drRight["Module_ID"] != DBNull.Value ? Convert.ToDecimal(drRight["Module_ID"]) : 0;
                this._RightType_ID = drRight["RightType_ID"] != DBNull.Value ? Convert.ToDecimal(drRight["RightType_ID"]) : 0;

            }

            else
            {

                this._PK_Right_ID = -1;
                this._Right_Name = "";
                this._Module_ID = -1;
                this._RightType_ID = -1;

            }

        }



        #endregion




        #region Methods

        /// <summary>
        /// Inserts a record into the Right table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightInsert");

            db.AddInParameter(dbCommand, "Right_Name", DbType.String, this._Right_Name);
            db.AddInParameter(dbCommand, "Module_ID", DbType.Decimal, this._Module_ID);
            db.AddInParameter(dbCommand, "RightType_ID", DbType.Decimal, this._RightType_ID);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Right table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Right_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightSelectByPK");

            db.AddInParameter(dbCommand, "PK_Right_ID", DbType.Int32, pK_Right_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Right table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Right table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightUpdate");

            db.AddInParameter(dbCommand, "PK_Right_ID", DbType.Int32, this._PK_Right_ID);
            db.AddInParameter(dbCommand, "Right_Name", DbType.String, this._Right_Name);
            db.AddInParameter(dbCommand, "Module_ID", DbType.Decimal, this._Module_ID);
            db.AddInParameter(dbCommand, "RightType_ID", DbType.Decimal, this._RightType_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Right table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Right_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RightDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Right_ID", DbType.Int32, pK_Right_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
