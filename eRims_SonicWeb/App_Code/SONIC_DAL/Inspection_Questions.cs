using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Inspection_Questions table.
    /// </summary>
    public sealed class Inspection_Questions
    {
        #region Fields


        private int _PK_Inspection_Questions_ID;
        private string _Item_Number_Focus_Area;
        private string _Question_Number;
        private string _Question_Text;
        private string _Guidance_Text;
        private string _Deficient_Answer;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Inspection_Questions_ID value.
        /// </summary>
        public int PK_Inspection_Questions_ID
        {
            get { return _PK_Inspection_Questions_ID; }
            set { _PK_Inspection_Questions_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Item_Number_Focus_Area value.
        /// </summary>
        public string Item_Number_Focus_Area
        {
            get { return _Item_Number_Focus_Area; }
            set { _Item_Number_Focus_Area = value; }
        }


        /// <summary> 
        /// Gets or sets the Question_Number value.
        /// </summary>
        public string Question_Number
        {
            get { return _Question_Number; }
            set { _Question_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Question_Text value.
        /// </summary>
        public string Question_Text
        {
            get { return _Question_Text; }
            set { _Question_Text = value; }
        }


        /// <summary> 
        /// Gets or sets the Guidance_Text value.
        /// </summary>
        public string Guidance_Text
        {
            get { return _Guidance_Text; }
            set { _Guidance_Text = value; }
        }

        public string Deficient_Answer
        {
            get { return _Deficient_Answer; }
            set { _Deficient_Answer = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Inspection_Questions class. with the default value.

        /// </summary>
        public Inspection_Questions()
        {

            this._PK_Inspection_Questions_ID = -1;
            this._Item_Number_Focus_Area = "";
            this._Question_Number = "";
            this._Question_Text = "";
            this._Guidance_Text = "";
            this._Deficient_Answer = "N";
        }



        /// <summary> 

        /// Initializes a new instance of the Inspection_Questions class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Inspection_Questions(int PK)
        {

            DataTable dtInspection_Questions = SelectByPK(PK).Tables[0];

            if (dtInspection_Questions.Rows.Count > 0)
            {

                DataRow drInspection_Questions = dtInspection_Questions.Rows[0];

                this._PK_Inspection_Questions_ID = drInspection_Questions["PK_Inspection_Questions_ID"] != DBNull.Value ? Convert.ToInt32(drInspection_Questions["PK_Inspection_Questions_ID"]) : 0;
                this._Item_Number_Focus_Area = Convert.ToString(drInspection_Questions["Item_Number_Focus_Area"]);
                this._Question_Number = Convert.ToString(drInspection_Questions["Question_Number"]);
                this._Question_Text = Convert.ToString(drInspection_Questions["Question_Text"]);
                this._Guidance_Text = Convert.ToString(drInspection_Questions["Guidance_Text"]);
                this._Deficient_Answer = Convert.ToString(drInspection_Questions["Deficient_Answer"]);

            }

            else
            {

                this._PK_Inspection_Questions_ID = -1;
                this._Item_Number_Focus_Area = "";
                this._Question_Number = "";
                this._Question_Text = "";
                this._Guidance_Text = "";
                this._Deficient_Answer = "N";
            }

        }



        #endregion


        #region Methods

        /// <summary>
        /// Inserts a record into the Inspection_Questions table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsInsert");

            db.AddInParameter(dbCommand, "Item_Number_Focus_Area", DbType.String, this._Item_Number_Focus_Area);
            db.AddInParameter(dbCommand, "Question_Number", DbType.String, this._Question_Number);
            db.AddInParameter(dbCommand, "Question_Text", DbType.String, this._Question_Text);
            db.AddInParameter(dbCommand, "Guidance_Text", DbType.String, this._Guidance_Text);
            db.AddInParameter(dbCommand, "Deficient_Answer", DbType.String, this._Deficient_Answer);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Inspection_Questions table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Inspection_Questions_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Inspection_Questions_ID", DbType.Int32, pK_Inspection_Questions_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Inspection_Questions table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Inspection_Questions table for Administration Area.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllForAdmin()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsSelectAllForAdmin");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Inspection_Questions table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsUpdate");

            db.AddInParameter(dbCommand, "PK_Inspection_Questions_ID", DbType.Int32, this._PK_Inspection_Questions_ID);
            db.AddInParameter(dbCommand, "Item_Number_Focus_Area", DbType.String, this._Item_Number_Focus_Area);
            db.AddInParameter(dbCommand, "Question_Number", DbType.String, this._Question_Number);
            db.AddInParameter(dbCommand, "Question_Text", DbType.String, this._Question_Text);
            db.AddInParameter(dbCommand, "Guidance_Text", DbType.String, this._Guidance_Text);
            db.AddInParameter(dbCommand, "Deficient_Answer", DbType.String, this._Deficient_Answer);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Inspection_Questions table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Inspection_Questions_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Inspection_Questions_ID", DbType.Int32, pK_Inspection_Questions_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectAllFocusAreas()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsSelectAllFocusAreas");

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Get  All Inspection Question Text 
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllQuestion()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAllQuestionText");

            return db.ExecuteDataSet(dbCommand);
        }


        public static DataSet SelectByFocusArea(decimal PK_LU_Location_ID, bool bSelectForAdd, string Focus_Area)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsSelectByFocusArea");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, PK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Focus_Area", DbType.String, Focus_Area);
            db.AddInParameter(dbCommand, "bSelectForAdd", DbType.Boolean, bSelectForAdd);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
