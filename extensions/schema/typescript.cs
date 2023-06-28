using CodeBuilder.Core;
using CodeBuilder.Core.Source;
using CodeBuilder.Core.Initializers;
using System.Data;

// 用于转换属性类型
[SchemaInitializer(typeof(Column))]
public class TypeScriptPropertyTypeInitializer : ISchemaInitializer
{
    public void Initialize(dynamic profile, dynamic schema)
    {
        var column = schema as Column;
        column.PropertyType = GetTypeScriptType(column);
    }
    
    private string GetTypeScriptType(Column column)
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
            case DbType.Date:
            case DbType.DateTime:
            case DbType.DateTime2:
            case DbType.DateTimeOffset:
                propertyType = "string";
                break;
            case DbType.Int16:
            case DbType.UInt16:
            case DbType.Int32:
            case DbType.UInt32:
            case DbType.Int64:
            case DbType.UInt64:
            case DbType.Decimal:
            case DbType.Double:
            case DbType.Single:
            case DbType.Byte:
            case DbType.SByte:
                propertyType = "number";
                break;
            case DbType.Boolean:
                propertyType = "boolean";
                break;
            default:
                propertyType = "any";
                break;
        }

        return propertyType;
    }
}