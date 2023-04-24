using System.ComponentModel;
using CodeBuilder.Core;
using CodeBuilder.Core.Source;
using CodeBuilder.Core.Initializers;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

// 用于格式化类名
[SchemaInitializer(typeof(Table))]
public class ClassNameInitializer : ISchemaInitializer
{
    public IDevHosting Hosting { get; set; }

    public void Initialize(dynamic profile, dynamic schema)
    {
        var table = schema as Table;
        var tableName = table.Name;

        // 正则替换前缀
        if (!string.IsNullOrEmpty(profile.TableRegex))
        {
            var regx = new Regex(profile.TableRegex);
            if (regx.IsMatch(tableName))
            {
                tableName = regx.Replace(tableName, string.Empty);
            }
        }

        // Pascal 命名
        if (profile.TableNamingMode == NamingMode.Pascal)
        {
            table.ClassName = SchemaHelper.PascalFormat(tableName);
        }
        // Camel 命名
        else if (profile.TableNamingMode == NamingMode.Camel)
        {
            table.ClassName = SchemaHelper.CamelFormat(tableName);
        }
        else
        {
            table.ClassName = tableName.Replace(" ", string.Empty).Replace("-", "_");
        }
    }
}

// 用于格式化属性名
[SchemaInitializer(typeof(Column))]
public class PropertyNameInitializer : ISchemaInitializer
{
    public void Initialize(dynamic profile, dynamic schema)
    {
        var column = schema as Column;
        var columnName = column.Name;

        // 正则替换前缀
        if (!string.IsNullOrEmpty(profile.ColumeRegex))
        {
            var regx = new Regex(profile.ColumeRegex);
            if (regx.IsMatch(columnName))
            {
                columnName = regx.Replace(columnName, string.Empty);
            }
        }

        // Pascal 命名
        if (profile.ColumnNamingMode == NamingMode.Pascal)
        {
            column.PropertyName = SchemaHelper.PascalFormat(columnName);
        }
        // Camel 命名
        else if (profile.ColumnNamingMode == NamingMode.Camel)
        {
            column.PropertyName = SchemaHelper.CamelFormat(columnName);
        }
        else
        {
            column.PropertyName = columnName.Replace(" ", string.Empty).Replace("-", "_");
        }
    }
}

internal class SchemaHelper
{
    // Pascal 命名转换
    public static string PascalFormat(string name)
    {
        var sb = new StringBuilder();
        foreach (var arr in name.Split('_', ' '))
        {
            if (arr.Length > 0)
            {
                sb.Append(arr.Substring(0, 1).ToUpper());
                sb.Append(arr.Substring(1).ToLower());
            }
        }

        return sb.ToString();
    }
    // Camel 命名转换
    public static string CamelFormat(string name)
    {
        var sb = new StringBuilder();
        foreach (var arr in name.Split('_', ' '))
        {
            if (arr.Length > 0)
            {
                if (sb.Length == 0)
                {
                    sb.Append(arr.Substring(0, 1).ToLower());
                }
                else
                {
                    sb.Append(arr.Substring(0, 1).ToUpper());
                }
                sb.Append(arr.Substring(1).ToLower());
            }
        }

        return sb.ToString();
    }
}