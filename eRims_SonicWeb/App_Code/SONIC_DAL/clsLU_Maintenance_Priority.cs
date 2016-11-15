using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for clsLU_Maintenance_Priority
    /// </summary>
    public class clsLU_Maintenance_Priority
    {
        #region Private variables used to hold the property values

        private decimal? _PK_LU_Maintenance_Priority;
        private string _Description;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Maintenance_Priority value.
        /// </summary>
        public decimal? PK_LU_Maintenance_Priority
        {
            get { return _PK_LU_Maintenance_Priority; }
            set { _PK_LU_Maintenance_Priority = value; }
        }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        #endregion

        
		#region Default Constructors

		/// <summary>
        /// Initializes a new instance of the cls_LU_Maintenance_Priority class with default value.
		/// </summary>
		public clsLU_Maintenance_Priority() 
		{


		}

		#endregion

		#region Primary Constructors

        public clsLU_Maintenance_Priority(decimal pK_LU_Maintenance_Priority) 
		{
            DataTable drLU_Maintenance_Priority = SelectByPK(pK_LU_Maintenance_Priority).Tables[0];

            if (drLU_Maintenance_Priority.Rows.Count == 1)
			{
                SetValue(drLU_Maintenance_Priority.Rows[0]);

			}

		}
        /// <summary>
        /// Initializes a new instance of the cls_LU_Maintenance_Priority class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Maintenance_Priority)
        {
            if (drLU_Maintenance_Priority["PK_LU_Maintenance_Priority"] == DBNull.Value)
                this._PK_LU_Maintenance_Priority = null;
            else
                this._PK_LU_Maintenance_Priority = (decimal?)drLU_Maintenance_Priority["PK_LU_Maintenance_Priority"];

            if (drLU_Maintenance_Priority["Description"] == DBNull.Value)
                this._Description = null;
            else
                this._Description = (string)drLU_Maintenance_Priority["Description"];
        }

        #endregion

        /// <summary>
        /// Selects a single record from the LU_Facility_Maintenance_Status table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pk_LU_Maintenance_Priority)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Maintenance_PrioritySelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Maintenance_Priority", DbType.Decimal, pk_LU_Maintenance_Priority);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the LU_Facility_Maintenance_Status table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByDescription(string description)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Maintenance_PrioritySelectByDescription");

            db.AddInParameter(dbCommand, "Description", DbType.String, description);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Facility_Maintenance_Status table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Maintenance_PrioritySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }
    }
}