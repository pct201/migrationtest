using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Layer table.
	/// </summary>
	public sealed class Layer
    {
        #region Fields


        private decimal _PK_Layer;
        private string _Fld_Desc;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Layer value.
        /// </summary>
        public decimal PK_Layer
        {
            get { return _PK_Layer; }
            set { _PK_Layer = value; }
        }


        /// <summary> 
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Layer class. with the default value.

        /// </summary>
        public Layer()
        {

            this._PK_Layer = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Layer class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Layer(decimal PK)
        {

            DataTable dtLayer = SelectByPK(PK).Tables[0];

            if (dtLayer.Rows.Count > 0)
            {

                DataRow drLayer = dtLayer.Rows[0];

                this._PK_Layer = drLayer["PK_Layer"] != DBNull.Value ? Convert.ToDecimal(drLayer["PK_Layer"]) : 0;
                this._Fld_Desc = Convert.ToString(drLayer["Fld_Desc"]);

            }

            else
            {

                this._PK_Layer = -1;
                this._Fld_Desc = "";

            }

        }



        #endregion


        #region "Methods"
        /// <summary>
		/// Inserts a record into the Layer table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LayerInsert");

			db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Layer table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Layer)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LayerSelectByPK");

			db.AddInParameter(dbCommand, "PK_Layer", DbType.Decimal, pK_Layer);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Layer table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LayerSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Layer table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LayerUpdate");

			db.AddInParameter(dbCommand, "PK_Layer", DbType.Decimal, this._PK_Layer);
			db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Layer table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Layer)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LayerDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Layer", DbType.Decimal, pK_Layer);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
