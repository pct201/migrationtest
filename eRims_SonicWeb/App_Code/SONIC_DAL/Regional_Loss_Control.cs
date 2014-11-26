using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Regional_Loss_Control table.
	/// </summary>
	public sealed class Regional_Loss_Control
    {
        #region Fields


        private decimal _PK_Regional_Loss_Control_ID;
        private string _Manager;
        private string _Telephone1;
        private string _Telephone2;
        private string _Email;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Regional_Loss_Control_ID value.
        /// </summary>
        public decimal PK_Regional_Loss_Control_ID
        {
            get { return _PK_Regional_Loss_Control_ID; }
            set { _PK_Regional_Loss_Control_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Manager value.
        /// </summary>
        public string Manager
        {
            get { return _Manager; }
            set { _Manager = value; }
        }


        /// <summary> 
        /// Gets or sets the Telephone1 value.
        /// </summary>
        public string Telephone1
        {
            get { return _Telephone1; }
            set { _Telephone1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Telephone2 value.
        /// </summary>
        public string Telephone2
        {
            get { return _Telephone2; }
            set { _Telephone2 = value; }
        }

        /// <summary> 
        /// Gets or sets the Email value.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }


        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Regional_Loss_Control class. with the default value.

        /// </summary>
        public Regional_Loss_Control()
        {

            this._PK_Regional_Loss_Control_ID = -1;
            this._Manager = "";
            this._Telephone1 = "";
            this._Telephone2 = "";
            this._Email = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Regional_Loss_Control class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Regional_Loss_Control(decimal PK)
        {

            DataTable dtRegional_Loss_Control = SelectByPK(PK).Tables[0];

            if (dtRegional_Loss_Control.Rows.Count > 0)
            {

                DataRow drRegional_Loss_Control = dtRegional_Loss_Control.Rows[0];

                this._PK_Regional_Loss_Control_ID = drRegional_Loss_Control["PK_Regional_Loss_Control_ID"] != DBNull.Value ? Convert.ToDecimal(drRegional_Loss_Control["PK_Regional_Loss_Control_ID"]) : 0;
                this._Manager = Convert.ToString(drRegional_Loss_Control["Manager"]);
                this._Telephone1 = Convert.ToString(drRegional_Loss_Control["Telephone1"]);
                this._Telephone2 = Convert.ToString(drRegional_Loss_Control["Telephone2"]);
                this._Email = Convert.ToString(drRegional_Loss_Control["Email"]);
            }

            else
            {

                this._PK_Regional_Loss_Control_ID = -1;
                this._Manager = "";
                this._Telephone1 = "";
                this._Telephone2 = "";
                this._Email = "";
            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the Regional_Loss_Control table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Regional_Loss_ControlInsert");

            db.AddInParameter(dbCommand, "Manager", DbType.String, this._Manager);
            db.AddInParameter(dbCommand, "Telephone1", DbType.String, this._Telephone1);
            db.AddInParameter(dbCommand, "Telephone2", DbType.String, this._Telephone2);
            db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Regional_Loss_Control table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Regional_Loss_Control_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Regional_Loss_ControlSelectByPK");

            db.AddInParameter(dbCommand, "PK_Regional_Loss_Control_ID", DbType.Decimal, pK_Regional_Loss_Control_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Regional_Loss_Control table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Regional_Loss_ControlSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Regional_Loss_Control table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Regional_Loss_ControlUpdate");

            db.AddInParameter(dbCommand, "PK_Regional_Loss_Control_ID", DbType.Decimal, this._PK_Regional_Loss_Control_ID);
            db.AddInParameter(dbCommand, "Manager", DbType.String, this._Manager);
            db.AddInParameter(dbCommand, "Telephone1", DbType.String, this._Telephone1);
            db.AddInParameter(dbCommand, "Telephone2", DbType.String, this._Telephone2);
            db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Regional_Loss_Control table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Regional_Loss_Control_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Regional_Loss_ControlDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Regional_Loss_Control_ID", DbType.Decimal, pK_Regional_Loss_Control_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
	}
}
