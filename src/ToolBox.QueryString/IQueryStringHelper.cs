namespace MrEfka.ToolBox.QueryString;

///<summary>Helper service for query string building.</summary>
public interface IQueryStringHelper
{
    ///<summary>Builds query string from the provided data source <paramref name="o"/>.</summary>
    ///<param name="o">Source object to load query string values from.</param>
    ///<param name="name">If <paramref name="o"/> is a valid primitive type, this value should contain the key name of the query string entry. Otherwise, this value contains the root name for all elements/properties in <paramref name="o"/>. That means elements/properties will be nested according to this value.</param>
    ///<returns>Generated query string.</returns>
    string BuildQueryString(object o, string name = null!);

    ///<summary>Builds query string from the provided key-value map.</summary>
    ///<remarks> This API assumes the values in the map are valid supported primitive types. </remarks>
    ///<param name="data">Key-Value map to build query string from.</param>
    ///<exception cref="T:System.InvalidCastException">If at least one value in data map is not a valid supported primitive type</exception>
    ///<exception cref="T:System.ArgumentException">If at least one key in data map is <see langword="null"/> or empty (<see cref="string.Empty"/>).</exception>
    ///<returns>Generated query string</returns>
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