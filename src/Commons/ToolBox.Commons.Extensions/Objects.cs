namespace MrEfka.ToolBox.Commons.Extensions;

///<summary>Provides utils functions to work with .Net objects</summary>
public static class Objects
{
    ///<summary>Determines whether the specified object is null or equals the default value for its type.</summary>
    ///<typeparam name="T">The type of the default value.</typeparam>
    ///<param name="obj">The object to check.</param>
    ///<returns>True if the specified object is null or equals the default value for its type; otherwise, false.</returns>
    public static bool IsNullOrDefault<T>(this T? obj) => IsNullOrDefault(obj, default(T));
    ///<summary>Determines whether the specified object is null or equals the default value provided.</summary>
    ///<typeparam name="T">The type of the default value.</typeparam>
    ///<param name="obj">The object to check.</param>
    ///<param name="defaultValue">The default value to compare against.</param>
    ///<returns>True if the specified object is null or equals the default value provided; otherwise, false.</returns>
    public static bool IsNullOrDefault<T>(this object? obj, T? defaultValue) => obj is null || obj.Equals(defaultValue);
    ///<summary>Converts the specified object to its JSON representation.</summary>
    ///<param name="obj">The object to be serialized to JSON.</param>
    ///<returns>A JSON string representing the serialized object.</returns>
    public static string ToJson(this object obj) => System.Text.Json.JsonSerializer.Serialize(obj);
    ///<summary>Converts a JSON string representation into an object of type <typeparamref name="T"/>.</summary>
    ///<typeparam name="T">The type of the object to deserialize.</typeparam>
    ///<param name="jsonObjectString">The JSON string to deserialize.</param>
    ///<returns>The deserialized object of type T, or null if deserialization fails.</returns>
    public static T? FromJson<T>(this string? jsonObjectString) => jsonObjectString == default ? default : System.Text.Json.JsonSerializer.Deserialize<T>(jsonObjectString);
    ///<summary>Extracts all messages in given exception.</summary>
    ///<param name="ex">Base exception.</param>
    ///<returns></returns> 
    public static IEnumerable<string> GetAllMessages(this Exception? ex)
    {
        ArgumentNullException.ThrowIfNull(ex, nameof(ex));
        do
        {
            string msg = ex.Message;
            ex = ex.InnerException;
            yield return msg;
        } while (ex is not null);
    }

}