using CodeBuilder.Core;
using CodeBuilder.Core.Source;
using CodeBuilder.Core.Initializers;
using System.Data;

// 用于转换属性类型
[SchemaInitializer(typeof(Column))]
public class PythonPropertyTypeInitializer : ISchemaInitializer
{
    public void Initialize(dynamic profile, dynamic schema)
    {
        var column = schema as Column;
        column.PropertyType = GetPythonType(column);
    }
    
    private string GetPythonType(Column column)
    {
        var propertyType = column.PropertyType;
        if (column.DbType == null)
        {
            return propertyType;
        }

        switch ((DbType)column.DbType)
        {
            case DbType.String:
            case DbType.StringFixedLength:
            case DbType.AnsiString:
            case DbType.AnsiStringFixedLength:
                propertyType = "string";
                break;
            case DbType.Int16:
                propertyType = "int16";
                break;
            case DbType.UInt16:
                propertyType = "uint16";
                break;
            case DbType.Int32:
                propertyType = "int";
                break;
            case DbType.UInt32:
                propertyType = "uint";
                break;
            case DbType.Int64:
                propertyType = "int64";
                break;
            case DbType.UInt64:
                propertyType = "uint64";
                break;
            case DbType.Single:
                propertyType = "float32";
                break;
            case DbType.Decimal:
            case DbType.Double:
                propertyType = "float64";
                break;
            case DbType.Boolean:
                propertyType = "bool";
                break;
            case DbType.Byte:
                propertyType = "int8";
                break;
            case DbType.SByte:
                propertyType = "uint8";
                break;
            case DbType.Date:
            case DbType.DateTime:
            case DbType.DateTime2:
            case DbType.DateTimeOffset:
                propertyType = "time.Time";
                break;
            case DbType.Binary:
                propertyType = "[]uint8";
                break;
        }

        return propertyType;
    }
}