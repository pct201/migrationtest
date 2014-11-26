using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Return_Address table.
    /// </summary>
    public sealed class Return_Address
    {
        
        /// <summary>
        /// Selects all records from the Return_Address table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Return_AddressSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        #region Fields

        private string _First_Name;
        private string _Last_Name;
        private string _Department;
        private string _Company;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private decimal _FK_State;
        private string _ZIP_Code;

        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the First_Name value.
        /// </summary>
        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Last_Name value.
        /// </summary>
        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Department value.
        /// </summary>
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }


        /// <summary> 
        /// Gets or sets the Company value.
        /// </summary>
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_1 value.
        /// </summary>
        public string Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_2 value.
        /// </summary>
        public string Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the City value.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_State value.
        /// </summary>
        public decimal FK_State
        {
            get { return _FK_State; }
            set { _FK_State = value; }
        }


        /// <summary> 
        /// Gets or sets the ZIP_Code value.
        /// </summary>
        public string ZIP_Code
        {
            get { return _ZIP_Code; }
            set { _ZIP_Code = value; }
        }



        #endregion

        #region Constructors

        



        
        public Return_Address()
        {
            DataTable dtReturn_Address = SelectAll().Tables[0];

            if (dtReturn_Address.Rows.Count > 0)
            {

                DataRow drReturn_Address = dtReturn_Address.Rows[0];

                this._First_Name = Convert.ToString(drReturn_Address["First_Name"]);
                this._Last_Name = Convert.ToString(drReturn_Address["Last_Name"]);
                this._Department = Convert.ToString(drReturn_Address["Department"]);
                this._Company = Convert.ToString(drReturn_Address["Company"]);
                this._Address_1 = Convert.ToString(drReturn_Address["Address_1"]);
                this._Address_2 = Convert.ToString(drReturn_Address["Address_2"]);
                this._City = Convert.ToString(drReturn_Address["City"]);
                this._FK_State = drReturn_Address["FK_State"] != DBNull.Value ? Convert.ToDecimal(drReturn_Address["FK_State"]) : 0;
                this._ZIP_Code = Convert.ToString(drReturn_Address["ZIP_Code"]);

            }
            else
            {
                this._First_Name = "";
                this._Last_Name = "";
                this._Department = "";
                this._Company = "";
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._FK_State = -1;
                this._ZIP_Code = "";
                
            }

        }



        #endregion

    }
}
