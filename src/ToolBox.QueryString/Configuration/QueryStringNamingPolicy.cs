using MrEfka.ToolBox.Commons.Extensions;

namespace MrEfka.ToolBox.QueryString.Configuration;

///<summary>Determines the naming policy used to convert a string-based name to another format, such as a camel-casing or snake-casing formats.</summary>
public abstract class QueryStringNamingPolicy
{
    ///<summary>Gets the naming policy for identity : means the names in won't be changed; they will be render as they are read.</summary>
    public static QueryStringNamingPolicy Identity { get; } = new QueryStringNamingPolicyIdentity();
    ///<summary>Gets the naming policy for camel-casing.</summary>
    public static QueryStringNamingPolicy CamelCase { get; } = new QueryStringNamingPolicyCamelCase();
    ///<summary>Gets the naming policy for upper-camel-casing.</summary>
    public static QueryStringNamingPolicy UpperCamelCase { get; } = new QueryStringNamingPolicyUpperCamelCase();
    ///<summary>Gets the naming policy for snake-casing.</summary>
    public static QueryStringNamingPolicy SnakeCase { get; } = new QueryStringNamingPolicySnakeCase();

    ///<summary>When overridden in a derived class, converts the specified name according to the policy.</summary>
    ///<param name="name">The name to convert.</param>
    ///<returns>The converted name.</returns>
    public abstract string ConvertName(string name);
}

internal sealed class QueryStringNamingPolicyIdentity : QueryStringNamingPolicy
{
    public override string ConvertName(string name) => name;
}
internal sealed class QueryStringNamingPolicyCamelCase: QueryStringNamingPolicy
{
    public override string ConvertName(string name) => name.ToCamelCase() ?? string.Empty;
}
internal sealed class QueryStringNamingPolicyUpperCamelCase: QueryStringNamingPolicy
{
    public override string ConvertName(string name) => name.ToUpperCamelCase() ?? string.Empty;
}
internal sealed class QueryStringNamingPolicySnakeCase : QueryStringNamingPolicy
{
    public override string ConvertName(string name) => name.ToSnakeCase() ?? string.Empty;
}