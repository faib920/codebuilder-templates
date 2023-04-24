using System.ComponentModel;
using CodeBuilder.Core;

public class ProfileCSharpExt
{
    [Description("命名空间。")]
    public string Namespace { get; set; }

    [Description("是否使用异步编程 async/await。")]
    [DefaultValue(true)]
    public bool Async { get; set; }
}