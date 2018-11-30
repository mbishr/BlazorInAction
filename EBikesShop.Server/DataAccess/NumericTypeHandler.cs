using System;
using System.Data;
using Dapper;

namespace EBikesShop.Server
{
    // This helps Dapper to convert SQLite Numeric to C# decimal and vice versa.
    // This is needed because SQLite sends diffrent types based on value e.g. long for 8.0 and double for 8.25.
    public class NumericTypeHandler : SqlMapper.TypeHandler<decimal>
    {
        public override void SetValue(IDbDataParameter parameter, decimal value)
        {
            parameter.Value = value;
        }

        public override decimal Parse(object value)
        {
            return Convert.ToDecimal(value);
        }
    }
}