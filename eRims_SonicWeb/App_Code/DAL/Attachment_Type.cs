using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Attachment_Type table.
	/// </summary>
	public sealed class Attachment_Type
    {
        #region Fields


        private decimal _PK_ID;
        private string _FLD_desc;
        private string _FLD_code;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_ID value.
        /// </summary>
        public decimal PK_ID
        {
            get { return _PK_ID; }
            set { _PK_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FLD_desc value.
        /// </summary>
        public string FLD_desc
        {
            get { return _FLD_desc; }
            set { _FLD_desc = value; }
        }


        /// <summary> 
        /// Gets or sets the FLD_code value.
        /// </summary>
        public string FLD_code
        {
            get { return _FLD_code; }
            set { _FLD_code = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Attachment_Type class. with the default value.

        /// </summary>
        public Attachment_Type()
        {

            this._PK_ID = -1;
            this._FLD_desc = "";
            this._FLD_code = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Attachment_Type class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Attachment_Type(decimal PK)
        {

            DataTable dtAttachment_Type = SelectByPK(PK).Tables[0];

            if (dtAttachment_Type.Rows.Count > 0)
            {

                DataRow drAttachment_Type = dtAttachment_Type.Rows[0];

                this._PK_ID = drAttachment_Type["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drAttachment_Type["PK_ID"]) : 0;
                this._FLD_desc = Convert.ToString(drAttachment_Type["FLD_desc"]);
                this._FLD_code = Convert.ToString(drAttachment_Type["FLD_code"]);

            }

            else
            {

                this._PK_ID = -1;
                this._FLD_desc = "";
                this._FLD_code = "";

            }

        }



        #endregion


        #region "Methods"

        /// <summary>
		/// Inserts a record into the Attachment_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_TypeInsert");

			db.AddInParameter(dbCommand, "FLD_desc", DbType.String, this._FLD_desc);
			db.AddInParameter(dbCommand, "FLD_code", DbType.String, this._FLD_code);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Attachment_Type table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Attachment_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Attachment_Type table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_TypeUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FLD_desc", DbType.String, this._FLD_desc);
			db.AddInParameter(dbCommand, "FLD_code", DbType.String, this._FLD_code);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Attachment_Type table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Attachment_TypeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
