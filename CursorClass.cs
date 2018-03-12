public ZipCodeViewModel SearchZipCode(string zipcode)  
{  
    ZipCodeViewModel  entity = null;  
    // This code consider the EntityContext has set before, in another part of this app.  
    using (var _context = new EntityContext()) {  
  
        db.Connection.Open();  
  
        using (var cmd = db.Connection.CreateCommand()) {  
            OracleParameter param;  
            List<OracleParameter> listParam = new List<OracleParameter>();  
  
            param = new OracleParameter();  
            param.ParameterName = "P_ZIPCODE";  
            param.Direction = ParameterDirection.Input;  
            param.OracleDbType = OracleDbType.Varchar2;  
            param.Value = zipcode;  
            listParam.Add(param);  
  
            param = new OracleParameter();  
            param.ParameterName = "CURSOR_SELECT";  
            param.Direction = ParameterDirection.Output;  
            param.OracleDbType = OracleDbType.RefCursor;  
            param.Value = zipcode;  
            listParam.Add(param);  
  
            cmd.CommandText = "SP_ADDRESS_SEL";  
            cmd.CommandType = CommandType.StoreProcedure;  
            cmd.Parameters.AddRange(listaParam.ToArray());  
  
            _context.Database.Connection.Open();  
  
            using (OracleDataReader reader = cmd.ExecuteReader())  
            {  
                if (reader.Read())   
                {  
                    entity = new ZipCodeViewModel();  
  
                    entity.ZipCode = zipcode;  
  
                    if (reader["ADDRESS"] != DBNull.Value)  
                    {  
                        entity.Address = reader.GetString(reader.GetOrdinal("ADDRESS"));  
                    }  
  
  
                    if (reader["NEIGHBORHOOD"] != DBNull.Value)  
                    {  
                        entity.Address = reader.GetString(reader.GetOrdinal("NEIGHBORHOOD"));  
                    }  
  
  
                    if (reader["CITY"] != DBNull.Value)  
                    {  
                        entity.Address = reader.GetString(reader.GetOrdinal("CITY"));  
                    }  
  
  
                    if (reader["STATE"] != DBNull.Value)  
                    {  
                        entity.Address = reader.GetString(reader.GetOrdinal("STATE"));  
                    }  
                }  
             }  
        }  
    }  
}
