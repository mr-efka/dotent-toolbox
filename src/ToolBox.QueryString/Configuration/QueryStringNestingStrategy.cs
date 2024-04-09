namespace MrEfka.ToolBox.QueryString.Configuration;

///<summary> Controls how the <see cref="QueryStringHelper"/> will hierarchically nest properties/values while building the query string.</summary>
public enum QueryStringNestingStrategy
{
    ///<summary>Use OOP dot notation to nest properties/values.</summary>
    DotNotation = 1,
    ///<summary>Use square brackets to nest properties/values</summary>
    ArrayLike = 2
}