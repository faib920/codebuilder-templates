# CodeBuilder Templates

　CodeBuilder 的模板仓库，提供各种语言的模板定义。

## 安装说明
　前往 [http://fireasy.cn/codebuilder](http://fireasy.cn/codebuilder) 下载安装。

　将本仓库的 extensions、templates 目录复制到工具运行目录下。

## 目录说明

### *extensions*
　存放各模板的扩展类文件(csharp、vb)。

* `common` 公共类

| 文件 | 说明 |
| ---- | ---- |
| base.cs | 基础定义，枚举 |

* `profile` 变量扩展类

| 文件 | 说明 |
| ---- | ---- |
| base.cs | 基础的变量扩展，类名属性名的命名规则，语言转换等等 |
| csharp.cs | C#语言的变量扩展, Namespace, Async |
| java.cs | Java语言的变量扩展, Package |
| template.t4.abp-efcore.cs | 模板 abp-efcore 的变量扩展 |
| template.t4.fireasy-std.cs | fireasy 的基础变量扩展 |
| template.t4.fireasy-base.cs | 模板 fireasy-base 的变量扩展 |
| template.t4.fireasy-mvc.cs | 模板 fireasy-mvc 的变量扩展 |
| template.t4.fireasy-mvc-service.cs | 模板 fireasy-mvc-service 的变量扩展 |

　用于模板的扩展命名约定：template + `模板引擎` + `模板名称`

* `schema` 框架(字段/字段)扩展类

| 文件 | 说明 |
| ---- | ---- |
| base.cs | 类名及属性名命名转换 |
| csharp.cs | C#语言的属性类型转换 |
| java.cs | Java语言的属性类型转换 |
| go.cs | Go语言的属性类型转换 |
| vbnet.cs | VB.NET语言的属性类型转换 |
| template.t4.fireasy-base.cs | 模板 fireasy-base 的架构扩展 |
| template.t4.fireasy-mvc.cs | 模板 fireasy-mvc、fireasy-mvc-service 的架构扩展 |

　用于模板的扩展命名约定：template + `模板引擎` + `模板名称`

## *templates*
　存放各种模板，*.template 是定义文件，对应的部件模板文件存放在对应的文件夹中。

* T4

| 模板 | 语言 | 说明 |
| ---- | ---- | ---- |
| abp-efcore | C# | 基于 Volo.Abp + EfCore 的项目，包含 Application、Contracts、Domain 和 Shard Dto 几部分 |
| abp-efcore-full-net6 | C# | 基于 Volo.Abp + EfCore 的完整的DDD项目，包含解决方案，生成即可运行 |
| class-csharp | C# | C# 的实体类文件，纯类文件未继承和映射 |
| class-java | Java | Java 的实体类文件，纯类文件未继承和映射 |
| entityframework6 | C# | 基于 EntityFramework 6 的实体类及 DbContext |
| entityframeworkcore | C# | 基于 EfCore 的实体类及 DbContext |
| fireasy-base | C# | 基于 Fireasy 的实体类及 DbContext |
| fireasy-mvc | C# | 基于 Fireasy 的 Mvc 项目，包含实体类、DbContext、Controller 和 View |
| fireasy-mvc-service | C# | 基于 Fireasy 的 Mvc 项目，包含实体类、DbContext、Service、Controller 和 View |
| fireasy-mvc-service-full-core3.1 | C# | 基于 Fireasy 的 Mvc 完整项目，使用 Razor 视图及 EasyUI，包含解决方案，生成即可运行 |
| fireasy-three-tier | C# | 基于 Fireasy 的三层结构，包含 Model、DAL 和 BLL |
| freesql | C# | 基于 FreeSql 的实体类和仓储 |
| go-gorm | Go | 基于 Gorm 的 Model 示例 |
| htmldoc | Html | 将数据库结构输出 HTML 文档 |
| java_spring_myybatis | Java | 基于 Spring + Mybatis 的 Java 项目 |
| sql-ddl | SQL | 用于生成 Oracle、MySql 和 SqlServer 的 DDL 脚本 |
| sqlsugar | C# | 基于 SqlSugar 的实体类 |

* Razor

| 模板 | 语言 | 说明 |
| ---- | ---- | ---- |
| class | C# | 实体类示例 |
| entityframework | C# | 基于 EntityFramework 的实体类及 DbContext |

* NVelocity

| 模板 | 语言 | 说明 |
| ---- | ---- | ---- |
| class | C# | 实体类示例 |

## 模板定义

```json
{
  "Name": "test", //名称
  "Author": "fireasy", //作者
  "Version": 1.0, //版本
  "Description": "", //描述
  "Language": "CSharp", //语言
  "Category": "test", //类别
  "Partitions": [
    {
      "Name": "Solution", //部件名称
      "FileName": "solution.tt", //模板文件名(相对路径)
      "Output": "{ProjectCode}.sln", //输出文件名
      "Loop": 0, //循环 0:无 1:表 2:关系
      "Syntax": "XML", //语法
      "Color": "0,128,128" //颜色(R,G,B)
    }
  ], //部件
  "Groups": [
    {
      "Name": "Entities", //组名称
      "Color": null, //颜色
      "Groups": [], //子组
      "Partitions": [
        {
          "Name": "实体", //部件名称
          "FileName": "entities\\entity.tt", //模板文件名(相对路径)
          "Output": "{ProjectCode}\\Entities\\{ClassName}.cs", //输出文件名
          "Loop": 1, //循环 0:无 1:表 2:关系
          "Syntax": "C#", //语法
          "Color": null //颜色(R,G,B)
        }
      ] //组下的部件
    }
  ], //组
  "Extension": {
    "UseBase": true, //使用基本类文件 base.cs、base.vb
    "Common": [], //公共扩展
    "Schema": [
      "csharp.cs"
    ], //架构扩展
    "Profile": [
      "csharp.cs",
      "template.t4.abp-efcore.cs"
    ] //变量扩展
  } //扩展
}
```
