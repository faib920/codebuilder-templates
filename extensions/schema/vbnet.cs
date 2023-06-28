using CodeBuilder.Core;
using CodeBuilder.Core.Source;
using CodeBuilder.Core.Initializers;
using System.Data;

// 用于转换属性类型
[SchemaInitializer(typeof(Column))]
public class VBPropertyTypeInitializer : ISchemaInitializer
{
    public void Initialize(dynamic profile, dynamic schema)
    {
        var column = schema as Column;
        column.PropertyType = GetVBType(column);
    }
    
    private string GetVBType(Column column)
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
                propertyType = "String";
                break;
            case DbType.Int16:
                propertyType = "Short";
                break;
            case DbType.UInt16:
                propertyType = "UInt16";
                break;
            case DbType.Int32:
                propertyType = "Integer";
                break;
            case DbType.UInt32:
                propertyType = "UInt32";
                break;
            case DbType.Int64:
                propertyType = "Long";
                break;
            case DbType.UInt64:
                propertyType = "UInt64";
                break;
            case DbType.Decimal:
                propertyType = "Decimal";
                break;
            case DbType.Single:
                propertyType = "Single";
                break;
            case DbType.Double:
                propertyType = "Double";
                break;
            case DbType.Boolean:
                propertyType = "Boolean";
                break;
            case DbType.Byte:
            case DbType.SByte:
                propertyType = column.Name.StartsWith("Is") ? "Boolean" : "Integer";
                break;
            case DbType.Date:
            case DbType.DateTime:
            case DbType.DateTime2:
            case DbType.DateTimeOffset:
                propertyType = "DateTime";
                break;
            case DbType.Guid:
                propertyType = "Guid";
                break;
            case DbType.Binary:
                propertyType = "Byte()";
                break;
        }

        if (column.IsNullable && propertyType != "string" && column.DbType != DbType.Binary)
        {
            propertyType = "Nullable<" + propertyType + ">";
        }

        return propertyType;
    }
}