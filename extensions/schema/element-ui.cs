using System;
using System.ComponentModel;
using System.Data;
using CodeBuilder.Core.Source;
using CodeBuilder.Core.Initializers;

[SchemaExtension(typeof(Column))]
public class ElementUIColumnExtend
{
    [Category("Vue")]
    [Description("元素类型。")]
    public ElementType ElementType { get; set; }
}

public enum ElementType
{
    None,
    Input,
    RadioGroup,
    Checkbox,
    Select,
    Numberbox,
    Cascader,
    Switch,
    TimePicker,
    DateTimePicker
}

// 用于指定easyui的控件类型
[SchemaInitializer(typeof(Column))]
public class ElementTypeInitializer : ISchemaInitializer
{
    public void Initialize(dynamic profile, dynamic schema)
    {
        var column = schema as Column;
        if (column.IsPrimaryKey)
        {
            return;
        }
        if (column.ForeignKey != null)
        {
            schema.ElementType = ElementType.Select;
            return;
        }
        switch (column.DbType)
        {
            case DbType.Int16:
            case DbType.Int32:
            case DbType.Int64:
            case DbType.Decimal:
            case DbType.Double:
            case DbType.Single:
                schema.ElementType = ElementType.Numberbox;
                break;
            case DbType.Date:
            case DbType.DateTime:
            case DbType.DateTime2:
            case DbType.DateTimeOffset:
                schema.ElementType = ElementType.DateTimePicker;
                break;
            case DbType.Boolean:
                schema.ElementType = ElementType.Checkbox;
                break;
            default:
                schema.ElementType = ElementType.Input;
                break;
        }
    }
}