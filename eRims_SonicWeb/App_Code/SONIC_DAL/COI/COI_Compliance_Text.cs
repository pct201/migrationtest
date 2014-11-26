using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Compliance_Text table.
	/// </summary>
	public sealed class COI_Compliance_Text
	{
		

        #region Feilds
        private decimal _PK_Compliance;
        private string _Compliance_Text;
        private string _IsTurnedOn;
        #endregion

        #region Properties
        /// <summary>  /// Gets or sets the PK_Compliance value. /// </summary> 
        public decimal PK_Compliance {  get { return _PK_Compliance; }  set { _PK_Compliance = value; } }  
        /// <summary>  /// Gets or sets the Compliance_Text value. /// </summary> 
        public string Compliance_Text {  get { return _Compliance_Text; }  set { _Compliance_Text = value; } }
        /// <summary>  /// Gets or sets the IsTurnedOn value. /// </summary> 
        public string IsTurnedOn {  get { return _IsTurnedOn; }  set { _IsTurnedOn = value; } }  
        #endregion

        #region Constructors
        private COI_Compliance_Text() {
            this._PK_Compliance = -1;
            this._Compliance_Text = "";
            this._IsTurnedOn = "";
        }

        /// </summary> 
        public COI_Compliance_Text(decimal PK)
        {
            DataTable dtCOICompliamce = SelectByPK(PK).Tables[0];

            if (dtCOICompliamce.Rows.Count > 0)
            {
                DataRow drCOI_Compliance_Text = dtCOICompliamce.Rows[0];
                this._PK_Compliance = drCOI_Compliance_Text["PK_Compliance"] != DBNull.Value ? Convert.ToDecimal(drCOI_Compliance_Text["PK_Compliance"]) : 0;
                this._Compliance_Text = Convert.ToString(drCOI_Compliance_Text["Compliance_Text"]);
                this._IsTurnedOn = Convert.ToString(drCOI_Compliance_Text["IsTurnedOn"]);
            }
            else
            {
                this._PK_Compliance = -1;
                this._Compliance_Text = "";
                this._IsTurnedOn = "";
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the COI_Compliance_Text table.
        /// </summary>
        /// <returns></returns>
        public void Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Compliance_TextInsert");

            db.AddInParameter(dbCommand, "PK_Compliance", DbType.Decimal, this._PK_Compliance);
            db.AddInParameter(dbCommand, "Compliance_Text", DbType.String, this._Compliance_Text);
            db.AddInParameter(dbCommand, "IsTurnedOn", DbType.String, this._IsTurnedOn);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the COI_Compliance_Text table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Compliance)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Compliance_TextSelectByPK");

            db.AddInParameter(dbCommand, "PK_Compliance", DbType.Decimal, pK_Compliance);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the COI_Compliance_Text table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Compliance_TextSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the COI_Compliance_Text table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Compliance_TextUpdate");

            db.AddInParameter(dbCommand, "PK_Compliance", DbType.Decimal, this._PK_Compliance);
            db.AddInParameter(dbCommand, "Compliance_Text", DbType.String, this._Compliance_Text);
            db.AddInParameter(dbCommand, "IsTurnedOn", DbType.String, this._IsTurnedOn);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the COI_Compliance_Text table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Compliance)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Compliance_TextDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Compliance", DbType.Decimal, pK_Compliance);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
