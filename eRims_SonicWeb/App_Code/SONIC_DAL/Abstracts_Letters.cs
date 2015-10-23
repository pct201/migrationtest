using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Abstracts_Letters table.
    /// </summary>
    public sealed class Abstracts_Letters
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Abstracts_Letters;
        private decimal? _FK_Coverage;
        private string _Document_Name;
        private string _Document_Type;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Abstracts_Letters value.
        /// </summary>
        public decimal? PK_Abstracts_Letters
        {
            get { return _PK_Abstracts_Letters; }
            set { _PK_Abstracts_Letters = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Coverage value.
        /// </summary>
        public decimal? FK_Coverage
        {
            get { return _FK_Coverage; }
            set { _FK_Coverage = value; }
        }

        /// <summary>
        /// Gets or sets the Document_Name value.
        /// </summary>
        public string Document_Name
        {
            get { return _Document_Name; }
            set { _Document_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Document_Type value.
        /// </summary>
        public string Document_Type
        {
            get { return _Document_Type; }
            set { _Document_Type = value; }
        }


        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Abstracts_Letters class with default value.
        /// </summary>
        public Abstracts_Letters()
        {

            this._PK_Abstracts_Letters = null;
            this._FK_Coverage = null;
            this._Document_Name = null;
            this._Document_Type = null;

            this._Updated_By = null;
            this._Update_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Abstracts_Letters class based on Primary Key.
        /// </summary>
        public Abstracts_Letters(decimal pK_Abstracts_Letters)
        {
            DataTable dtAbstracts_Letters = SelectByPK(pK_Abstracts_Letters).Tables[0];

            if (dtAbstracts_Letters.Rows.Count == 1)
            {
                DataRow drAbstracts_Letters = dtAbstracts_Letters.Rows[0];
                if (drAbstracts_Letters["PK_Abstracts_Letters"] == DBNull.Value)
                    this._PK_Abstracts_Letters = null;
                else
                    this._PK_Abstracts_Letters = (decimal?)drAbstracts_Letters["PK_Abstracts_Letters"];

                if (drAbstracts_Letters["FK_Coverage"] == DBNull.Value)
                    this._FK_Coverage = null;
                else
                    this._FK_Coverage = (decimal?)drAbstracts_Letters["FK_Coverage"];

                if (drAbstracts_Letters["Document_Name"] == DBNull.Value)
                    this._Document_Name = null;
                else
                    this._Document_Name = (string)drAbstracts_Letters["Document_Name"];

                if (drAbstracts_Letters["Document_Type"] == DBNull.Value)
                    this._Document_Type = null;
                else
                    this._Document_Type = (string)drAbstracts_Letters["Document_Type"];

                if (drAbstracts_Letters["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drAbstracts_Letters["Updated_By"];

                if (drAbstracts_Letters["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drAbstracts_Letters["Update_Date"];

            }
            else
            {
                this._PK_Abstracts_Letters = null;
                this._FK_Coverage = null;
                this._Document_Name = null;
                this._Document_Type = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Selects a single record from the Abstracts_Letters table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_Abstracts_Letters)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Abstracts_LettersSelectByPK");

            db.AddInParameter(dbCommand, "PK_Abstracts_Letters", DbType.Decimal, pK_Abstracts_Letters);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        ///  Note – only Abstracts or Custom letters for Coverage type "Auto”.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(decimal MAJ_COV)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Abstracts_LettersbyMAJ_COV");
            db.AddInParameter(dbCommand, "MAJ_COV", DbType.Decimal, MAJ_COV);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}
