using System;
using System.ComponentModel;
using CodeBuilder.Core.Source;
using CodeBuilder.Core.Template;
using CodeBuilder.Core.Initializers;

[SchemaExtension(typeof(Column))]
public class VueColumnExtend
{
    [Category("Vue")]
    [Description("是否可作查询条件。")]
    public bool Conditional { get; set; }
}

//当没有指定 Module 时，将文件路径中的\\移走
public class ModuleOutputProcessor : IPartitionOutputParser
{
    //Profile是否有Module属性
    private bool? hasModuleProp;
    
    public void Parse(OutputParseContext context)
    {
        hasModuleProp ??= context.Profile.GetType().GetProperty("Module") != null;
        if ((bool)hasModuleProp && string.IsNullOrEmpty(context.Profile.Module))
        {
            if (context.Result.IndexOf("api\\") != -1)
            {
                context.Result = context.Result.Replace("api\\", "api");
            }
            else if (context.Result.IndexOf("views\\") != -1)
            {
                context.Result = context.Result.Replace("views\\", "views");
            }
        }
    }
}