using System.Collections;
using System.Reflection;
using MrEfka.ToolBox.Commons.Extensions;
using MrEfka.ToolBox.QueryString.Configuration;
using MrEfka.ToolBox.QueryString.Core;
using MrEfka.ToolBox.QueryString.DataAnnotation;

namespace MrEfka.ToolBox.QueryString;

///<summary>Service Impl for <see cref="IQueryStringHelper"/>.</summary>
public class QueryStringHelper: IQueryStringHelper
{
    ///<summary>Holds the current helper's configuration.</summary>
    private readonly QueryStringHelperConfiguration _configuration;
    
    ///<summary>Initializes a new instance of <see cref="QueryStringHelper"/> with the <see cref="QueryStringHelperConfiguration.Default"/> configuration.</summary>
    public QueryStringHelper() => _configuration = QueryStringHelperConfiguration.Default;
    
    ///<summary>Creates a new instance of <see cref="QueryStringHelper"/> with the given configuration.</summary>
    ///<param name="cfg"></param>
    public QueryStringHelper(QueryStringHelperConfiguration cfg) => _configuration = new QueryStringHelperConfiguration(cfg);

    #region Public APIs
    ///<summary>Builds query string from the provided data source <paramref name="o"/>.</summary>
    ///<param name="o">Source object to load query string values from.</param>
    ///<param name="name">If <paramref name="o"/> is a valid primitive type, this value should contain the key name of the query string entry. Otherwise, this value contains the root name for all elements/properties in <paramref name="o"/>. That means elements/properties will be nested according to this value.</param>
    ///<returns></returns>
    public string BuildQueryString(object? o, string name = null!)
    {
        // Handling null input
        if (o is null) return BuildQueryStringEntry(name, new PrimitiveType((string?)o));
        
        // Handling default Primitive values or valid parsable values.
        if (PrimitiveType.TryParse(o, out var oAsPrimitive)) return BuildQueryStringEntry(name, oAsPrimitive!.Value);

        // Handling complex types : interfaces, collections, other objects.
        var type = o.GetType();
        //if (type.IsInterface) return BuildQueryStringEntry(name, new((string?)o));

        // Handling collections
        var elementType = ReflectionUtility.GetCollectionElementType(type);
        if (elementType is not null) // Means it is a collection
        {
            var collection = o as IEnumerable;
            // If nested element type is primitive, directly build query string using supported API
            if (PrimitiveType.IsPrimitive(elementType))
            {
                var primitives = 
                (
                    from object? item in collection! 
                    select PrimitiveType.Parse(item)
                ).ToArray();
                
                return BuildQueryStringEntry(name, primitives, _configuration.UseArrayIndex!.Value);
            }
            return string.Join('&',
                collection!
                    .Cast<object?>()
                    .Select((obj, idx) => BuildQueryString(obj!, BuildFurtherName(name, string.Empty, idx)))
                    .Where(x => !string.IsNullOrEmpty(x))
            );
        }
        
        // Handling other object types.
        return string.Join('&', type.GetProperties().Where(p => p.CanRead && !ShouldExcludeProperty(p))
            .Select(p => BuildQueryString(p.GetValue(o)!, name: BuildFurtherName(name, p.Name)))
            .Where(x => !string.IsNullOrEmpty(x))
        );
    }
    
    ///<summary>Builds query string from the provided key-value map.</summary>
    ///<remarks> This API assumes the values in the map are valid supported primitive types. </remarks>
    ///<param name="data">Key-Value map to build query string from.</param>
    ///<exception cref="T:System.InvalidCastException">If at least one value in data map is not a valid supported primitive type</exception>
    ///<exception cref="T:System.ArgumentException">If at least one key in data map is <see langword="null"/> or empty (<see cref="System.String.Empty"/>).</exception>
    ///<returns>Generated query string</returns>
    public string BuildQueryString(IDictionary<string, object> data) =>
        string.Join('&', data.Select(kv => BuildQueryStringEntry(kv.Key, PrimitiveType.Parse(kv.Value))).Where(x=> !string.IsNullOrEmpty(x)));
    
    ///<summary>Builds query string from the provided key-value map.</summary>
    public string BuildQueryString(IDictionary<string, byte> data) =>
        string.Join('&', data.Select(kv => BuildQueryStringEntry(kv.Key, new PrimitiveType(kv.Value))).Where(x=> !string.IsNullOrEmpty(x)));

    ///<summary>Builds query string from the provided key-value map.</summary>
    public string BuildQueryString(IDictionary<string, sbyte> data) =>
        string.Join('&', data.Select(kv => BuildQueryStringEntry(kv.Key, new PrimitiveType(kv.Value))).Where(x=> !string.IsNullOrEmpty(x)));
    
    ///<summary>Builds query string from the provided key-value map.</summary>
    public string BuildQueryString(IDictionary<string, string> data) =>
        string.Join('&', data.Select(kv => BuildQueryStringEntry(kv.Key, new PrimitiveType(kv.Value))).Where(x=> !string.IsNullOrEmpty(x)));
    
    ///<summary>Builds query string from the provided key-value map.</summary>
    public string BuildQueryString(IDictionary<string, int> data) =>
        string.Join('&', data.Select(kv => BuildQueryStringEntry(kv.Key, new PrimitiveType(kv.Value))).Where(x=> !string.IsNullOrEmpty(x)));
    
    ///<summary>Builds query string from the provided key-value map.</summary>
    public string BuildQueryString(IDictionary<string, float> data) =>
        string.Join('&', data.Select(kv => BuildQueryStringEntry(kv.Key, new PrimitiveType(kv.Value))).Where(x=> !string.IsNullOrEmpty(x)));
    
    ///<summary>Builds query string from the provided key-value map.</summary>
    public string BuildQueryString(IDictionary<string, double> data) =>
        string.Join('&', data.Select(kv => BuildQueryStringEntry(kv.Key, new PrimitiveType(kv.Value))).Where(x=> !string.IsNullOrEmpty(x)));
    
    ///<summary>Builds query string from the provided key-value map.</summary>
    public string BuildQueryString(IDictionary<string, decimal> data) =>
        string.Join('&', data.Select(kv => BuildQueryStringEntry(kv.Key, new PrimitiveType(kv.Value))).Where(x=> !string.IsNullOrEmpty(x)));
    #endregion
    
    ///<summary>Builds array-like query string entry for a single key.</summary>
    ///<param name="key">Entry key</param>
    ///<param name="o"></param>
    ///<param name="useIndex"></param>
    ///<returns></returns>
    private string BuildQueryString(string key, IReadOnlyCollection<PrimitiveType> o, bool useIndex = false)
        => BuildQueryStringEntry(key, o.ToArray(), useIndex);
    
    ///<summary>Builds query string from a custom provided dictionary of <see cref="T:ToolBox.QueryString.PrimitiveType"/></summary>
    ///<param name="o">Source dictionary to build the query string from.</param>
    ///<returns></returns>
    private string BuildQueryString(IDictionary<string, PrimitiveType> o)
        => string.Join('&', o.Select(BuildQueryStringEntry));
    
    private string BuildQueryStringEntry(string key, PrimitiveType value, bool sqbEncloseVal = false)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(paramName: nameof(key));

        var (content, reject) = ProcessNullValueHandling(value);
        var entryValue = _configuration.EncodeUriComponents!.Value ? Uri.EscapeDataString(content) : content;
        entryValue = sqbEncloseVal ? $"[{entryValue}]" : entryValue;
        
        return reject ? content : $"{key}={entryValue}";
    }

    private string BuildQueryStringEntry(KeyValuePair<string, PrimitiveType> kv)
        => BuildQueryStringEntry(BuildFurtherName(parent: string.Empty, child: kv.Key), kv.Value);
        
    private string BuildQueryStringEntry(string key, PrimitiveType[] value, bool useIndex = false)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(paramName: nameof(key));
        if (!value.Any())
            return _configuration.EmptyCollectionHandling switch
            {
                EmptyCollectionHandlingStrategy.Ignore => String.Empty,
                EmptyCollectionHandlingStrategy.Always => BuildQueryStringEntry(BuildFurtherName(parent: string.Empty, child: key), string.Empty),
                EmptyCollectionHandlingStrategy.AlwaysEmpty => BuildQueryStringEntry(BuildFurtherName(parent: string.Empty, child: key), "[]"),
                _ => throw new ArgumentOutOfRangeException()
            };
        
        // TODO --DISCARDED: Remove square brackets from query string value to prevent escape.

        return useIndex
            ? string.Join('&', value.Select((item, idx) => BuildQueryStringEntry(BuildFurtherName(parent: key, child: string.Empty, index: idx), item)))
            : BuildQueryStringEntry(key, new PrimitiveType(string.Join(',', value)), sqbEncloseVal: true);
    }

    #region Utils Methods
    ///<summary>Handles null values in <see cref="PrimitiveType"/> according to the configured <see cref="NullValueHandlingStrategy"/>.</summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private (string Content, bool Reject) ProcessNullValueHandling(PrimitiveType value)
    {
        if (value.IsNull())
            return _configuration.NullValueHandling switch
            {
                NullValueHandlingStrategy.Always => (string.Empty, false),
                NullValueHandlingStrategy.TextLower => (QueryStringHelperConfiguration.NullTextLower, false),
                NullValueHandlingStrategy.TextUpper => (QueryStringHelperConfiguration.NullTextUpper, false),
                NullValueHandlingStrategy.Ignore => (string.Empty, true),
                _ => throw new ArgumentOutOfRangeException()
            };
        return (value.ToString(_configuration.UseQuotedStrings!.Value), false);
    }

    ///<summary>Build the key part of a querystring entry. Uses the parent name for nesting purposes.</summary>
    /// <param name="parent">Base name to nest <paramref name="child"/> into.</param>
    /// <param name="child">Current property name.</param>
    /// <param name="index">While iterating on a collection of objects, this parameter helps to index items in the collection.</param>
    /// <returns>Generated entry name</returns>
    /// <exception cref="ArgumentOutOfRangeException">If invalid <see cref="QueryStringNestingStrategy"/> was defined in the configuration.</exception>
    private string BuildFurtherName(string parent, string child, int? index = null)
    {
        Func<string, string> converter = _configuration.NamingPolicy!.ConvertName;
        child = converter(child);
        
        if (parent is null or {Length: 0}) return child;
        parent = index is not null && (_configuration.UseArrayIndex!.Value)
            ? string.Concat(converter(parent), "[", index.ToString(), "]")
            : converter(parent);

        if (child is null or { Length: 0 }) return parent;
        return _configuration.NestingStrategy switch
        {
            QueryStringNestingStrategy.DotNotation => string.Concat(parent, ".", child),
            QueryStringNestingStrategy.ArrayLike => string.Concat(parent, "[", child, "]"),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private bool ShouldExcludeProperty(PropertyInfo? p)
    {
        if (p is null) return false;
        return p.HasAttributesOfType<QsIgnoreAttribute>();
    }
    
    #endregion
}