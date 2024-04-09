namespace MrEfka.ToolBox.QueryString.Configuration;

///<summary>Controls how the <see cref="QueryStringHelper"/> handles empty collections while building the query string.</summary>
/// <remarks>
/// This configuration works only when calling <see cref="QueryStringHelper.BuildQueryString(object, string)"/> with :
/// 
/// <list type="bullet">
/// <item>A not null collection object</item>
/// <item>A not null object which type's is not considered as a primitive type.</item>
/// </list>
///
/// In other cases, defined <see cref="NullValueHandlingStrategy"/> will be applied.
/// </remarks>
public enum EmptyCollectionHandlingStrategy
{
    ///<summary>Empty collections field will not be append to the resulting query string</summary>
    Ignore = 1,
    ///<summary>Null value or empty collections field will be added to the resulting query string without value</summary>
    ///<remarks>Has the same behaviour as <see cref="NullValueHandlingStrategy.Always"/>.</remarks>
    ///<example>
    ///     string[] a = new string[] { };
    ///     var config = new QueryStringHelperConfiguration() { NullValueHandling = EmptyCollectionHandlingStrategy.Always };
    ///     new QueryStringHelper(config).BuildQueryString(a, "a") => `a=`
    ///</example>
    Always = 2,
    ///<summary>Null value or empty collections field will be added to the resulting query string with empty array value `[]`</summary>
    ///<example>
    ///     string[] a = new string[] { };
    ///     var config = new QueryStringHelperConfiguration() { NullValueHandling = EmptyCollectionHandlingStrategy.AlwaysEmpty };
    ///     new QueryStringHelper(config).BuildQueryString(a, "a") => `a=[]`
    ///</example>
    AlwaysEmpty = 3
}