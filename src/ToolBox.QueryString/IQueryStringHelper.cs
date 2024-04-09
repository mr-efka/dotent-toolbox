namespace MrEfka.ToolBox.QueryString;

///<summary>Helper service for query string building.</summary>
public interface IQueryStringHelper
{
    ///<summary>Builds query string from the provided data source<paramref name="o"/>.</summary>
    ///<param name="o">Source object to load query string values from.</param>
    ///<param name="name"></param>
    ///<returns></returns>
    string BuildQueryString(object o, string name = null!);
    ///<summary>Builds query string from the provided key-value map.</summary>
    /// <remarks>
    /// This API assumes the values in the map are valid supported primitive types.
    /// If at least one value is not a valid supported primitive type, an <see cref="T:System.InvalidCastException"/> will be thrown.
    /// </remarks>
    ///<param name="data">Key-Value map to build query string from.</param>
    ///<returns></returns>
    string BuildQueryString(IDictionary<string, object> data);
    ///<summary>Builds query string from the provided key-value map.</summary>
    string BuildQueryString(IDictionary<string, byte> data);
    ///<summary>Builds query string from the provided key-value map.</summary>
    string BuildQueryString(IDictionary<string, sbyte> data);
    ///<summary>Builds query string from the provided key-value map.</summary>
    string BuildQueryString(IDictionary<string, string> data);
    ///<summary>Builds query string from the provided key-value map.</summary>
    string BuildQueryString(IDictionary<string, int> data);
    ///<summary>Builds query string from the provided key-value map.</summary>
    string BuildQueryString(IDictionary<string, float> data);
    ///<summary>Builds query string from the provided key-value map.</summary>
    string BuildQueryString(IDictionary<string, double> data);
    ///<summary>Builds query string from the provided key-value map.</summary>
    string BuildQueryString(IDictionary<string, decimal> data);
}