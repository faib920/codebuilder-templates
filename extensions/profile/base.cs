using System.ComponentModel;
using CodeBuilder.Core;
using CodeBuilder.Core.Template;
using CodeBuilder.Core.Initializers;

public class ProfileBaseExt
{
    [Description("项目编码。")]
    [RequiredCheck]
    public string ProjectCode { get; set; }
    
    [Description("项目名称。")]
    public string ProjectName { get; set; }
	
    [Description("公司名称。")]
    public string CompanyName { get; set; }

    [Description("作者。")]
    public string Author { get; set; }
    
    [Description("表名转类名的替换正则。")]
    public string TableRegex { get; set; }
        
    [Description("字段名转类名的替换正则。")]
    public string ColumeRegex { get; set; }

    [Description("表转换的命名方式。Original 延续原始名称；Pascal 首字母大写，适用于用_分隔的命名，如 customer_base 转换为 CustomerBase；Camel 首字母小写，如 customer_base 转换为 customerBase。")]
    public NamingMode TableNamingMode { get; set; }

    [Description("字段转换的命名方式。Original 延续原始名称；Pascal 首字母大写，适用于用_分隔的命名，如 product_id 转换为 ProductId；Camel 首字母小写，如 product_id 转换为 productId。")]
    public NamingMode ColumnNamingMode { get; set; }
}