namespace MrEfka.ToolBox.QueryString.DataAnnotation;

///<summary>Specifies the name that is displayed in the generated querystring relatively to the target property. Warn about no check is performed this value. The caller is fully responsible of this value, which will be rawly rendered in the generated string (no conversion and no encoding)</summary>
///<remarks>Note that using this attribute with <see cref="QsIgnoreAttribute"/> has no effect while is has lower priority than <see cref="QsIgnoreAttribute"/>.</remarks>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class QsNameAttribute: Attribute
{
    ///<summary>User defined name</summary>
    internal string Name { get; }
    ///<summary>Initializes a new instance of <see cref="QsNameAttribute"/> with the specified name</summary>
    /// <param name="name">Name to use in the querystring for the target property.</param>
    public QsNameAttribute(string name) => Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
}