namespace MrEfka.ToolBox.QueryString.Configuration;

///<summary>Controls how the <see cref="QueryStringHelper"/> handles <see langword="null"/> values while building the query string.</summary>
public enum NullValueHandlingStrategy
{
    ///<summary>Null value field will not be append to the resulting query string</summary>
    Ignore = 1,
    ///<summary>Null value field will be added to the resulting query string without value</summary>
    /// <example>
    ///     string a = null;
    ///     var config = new QueryStringHelperConfiguration() { NullValueHandling = NullValueHandlingStrategy.Always };
    ///     new QueryStringHelper(config).BuildQueryString(a, "a") => `a=`
    /// </example>
    Always = 2,
    ///<summary>Null value field will be added to the resulting query string with value `null` as text</summary>
    /// <example>
    ///     string a = null;
    ///     var config = new QueryStringHelperConfiguration() { NullValueHandling = NullValueHandlingStrategy.TextLower };
    ///     new QueryStringHelper(config).BuildQueryString(a, "a") => `a=null`
    /// </example>
    TextLower = 3,
    ///<summary>Null value field will be added to the resulting query string with value `NULL` as text</summary>
    /// <example>
    ///     string a = null;
    ///     var config = new QueryStringHelperConfiguration() { NullValueHandling = NullValueHandlingStrategy.TextLower };
    ///     new QueryStringHelper(config).BuildQueryString(a, "a") => `a=NULL`
    /// </example>
    TextUpper = 4
}