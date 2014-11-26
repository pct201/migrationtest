#region Includes
using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Configuration;
using System.Globalization;
using System.Data.Common;
#endregion

namespace RIMS_Base.Dal
{
    [Serializable]
    public class CPropertySearch: RIMS_Base.CPropertySearch
    {
        public override List<RIMS_Base.CPropertySearch> GetAll(RIMS_Base.CPropertySearch Objoyee)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetPropertySearch");
                dbHelper.AddInParameter(cmd, "@Location_Code", DbType.Decimal, Objoyee.Location_Code);
                dbHelper.AddInParameter(cmd, "@Entity", DbType.Decimal, Objoyee.Entity);
                dbHelper.AddInParameter(cmd, "@Property_Type", DbType.Decimal, Objoyee.Property_Type);
                dbHelper.AddInParameter(cmd, "@Address1", DbType.String, Objoyee.Address1);
                dbHelper.AddInParameter(cmd, "@Address2", DbType.String, Objoyee.Address2);
                dbHelper.AddInParameter(cmd, "@City", DbType.String, Objoyee.City);
                dbHelper.AddInParameter(cmd, "@State", DbType.Decimal, Objoyee.State);
                dbHelper.AddInParameter(cmd, "@ZipCode", DbType.String, Objoyee.ZipCode);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPropertySearch> results = new List<RIMS_Base.CPropertySearch>();
                while (reader.Read())
                {
                    CPropertySearch objEmp = new CPropertySearch();
                    objEmp = MapFrom(reader);
                    results.Add(objEmp);
                }
                reader.Close();
                return results;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteProperty(decimal PK_PropertyID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_Delete");
                dbHelper.AddInParameter(cmd, "@PK_PropertyID", DbType.Decimal, PK_PropertyID);
                dbHelper.ExecuteNonQuery(cmd);
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        protected RIMS_Base.Dal.CPropertySearch MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CPropertySearch objoyee = new RIMS_Base.Dal.CPropertySearch();
            if (!Convert.IsDBNull(reader["PK_Property_COPE"])) { objoyee.PK_Property_ID = Convert.ToDecimal(reader["PK_Property_COPE"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location"])) { objoyee.Str_Location_Code = Convert.ToString(reader["Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Entity"])) { objoyee.Str_Entity = Convert.ToString(reader["Entity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property_Type"])) { objoyee.Str_Property_Type = Convert.ToString(reader["Property_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address"])) { objoyee.Address1 = Convert.ToString(reader["Address"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["City"])) { objoyee.City = Convert.ToString(reader["City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["State"])) { objoyee.Str_State = Convert.ToString(reader["State"], CultureInfo.InvariantCulture); }
            return objoyee;
        }

    }
}
