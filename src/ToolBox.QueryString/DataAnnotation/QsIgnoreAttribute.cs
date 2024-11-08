namespace MrEfka.ToolBox.QueryString.DataAnnotation;

///<summary>Specifies that the property that this attribute is applied to, will not be involved in querystring generation.</summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class QsIgnoreAttribute: Attribute { }