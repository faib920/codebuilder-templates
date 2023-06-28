using CodeBuilder.Core;
using CodeBuilder.Core.Source;
using CodeBuilder.Core.Initializers;
using System.Data;

// 用于转换属性类型
[SchemaInitializer(typeof(Column))]
public class CSharpPropertyTypeInitializer : ISchemaInitializer
{
    public void Initialize(dynamic profile, dynamic schema)
    {
        var column = schema as Column;
        column.PropertyType = GetCSharpType(column);
    }
    
    private string GetCSharpType(Column column)
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
                propertyType = "short";
                break;
            case DbType.UInt16:
                propertyType = "ushort";
                break;
            case DbType.Int32:
                propertyType = "int";
                break;
            case DbType.UInt32:
                propertyType = "uint";
                break;
            case DbType.Int64:
                propertyType = "long";
                break;
            case DbType.UInt64:
                propertyType = "ulong";
                break;
            case DbType.Decimal:
                propertyType = "decimal";
                break;
            case DbType.Single:
                propertyType = "float";
                break;
            case DbType.Double:
                propertyType = "double";
                break;
            case DbType.Boolean:
                propertyType = "bool";
                break;
            case DbType.Byte:
            case DbType.SByte:
                propertyType = column.Name.StartsWith("Is") ? "bool" : "int";
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
                propertyType = column.DataType == "timestamp" ? "DateTime" : "byte[]";
                break;
        }

        if (column.IsNullable && propertyType != "string" && column.DbType != DbType.Binary)
        {
            propertyType += "?";
        }

        return propertyType;
    }
}