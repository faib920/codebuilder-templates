using System.ComponentModel;
using CodeBuilder.Core;

public class ProfileJavaExt
{
    [Description("包名。")]
    [RequiredCheck]
    public string Package { get; set; }
}