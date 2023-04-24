using CodeBuilder.Core;
using CodeBuilder.Core.Source;
using CodeBuilder.Core.Initializers;
using System.Data;

// 用于转换属性类型
[SchemaInitializer(typeof(Column))]
public class JavaPropertyTypeInitializer : ISchemaInitializer
{
    public void Initialize(dynamic profile, dynamic schema)
    {
        var column = schema as Column;
        if (profile.Language == Language.Java)
        {
            column.PropertyType = GetJavaType(column);
        }
    }
    
    private string GetJavaType(Column column)
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
            case DbType.UInt16:
                propertyType = "short";
                break;
            case DbType.Int32:
            case DbType.UInt32:
                propertyType = "int";
                break;
            case DbType.Int64:
            case DbType.UInt64:
                propertyType = "long";
                break;
            case DbType.Single:
                propertyType = "float";
                break;
            case DbType.Decimal:
            case DbType.Double:
                propertyType = "double";
                break;
            case DbType.Boolean:
                propertyType = "boolean";
                break;
            case DbType.Byte:
            case DbType.SByte:
                propertyType = "byte";
                break;
            case DbType.Date:
            case DbType.DateTime:
            case DbType.DateTime2:
            case DbType.DateTimeOffset:
                propertyType = "Date";
                break;
            case DbType.Binary:
                propertyType = "byte[]";
                break;
        }

        return propertyType;
    }
}