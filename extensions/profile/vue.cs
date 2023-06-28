using System.ComponentModel;
using CodeBuilder.Core;
using CodeBuilder.Core.Template;
using CodeBuilder.Core.Initializers;

public class ProfileVueExt
{
    [Description("模块名称。")]
    public string Module { get; set; } = "";
}