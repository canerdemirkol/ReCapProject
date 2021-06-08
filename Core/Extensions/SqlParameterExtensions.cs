using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class SqlParameterExtensions
    {
        public static SqlParameter Nullable(this SqlParameter s, bool isnullable = false)
        {
            if (isnullable == true && s.Value == null)
                s.Value = DBNull.Value;

            return s;
        }
    }
}
