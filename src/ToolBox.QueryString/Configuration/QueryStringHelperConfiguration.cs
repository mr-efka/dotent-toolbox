namespace MrEfka.ToolBox.QueryString.Configuration;

///<summary>Model for configuring <see cref="QueryStringHelper"/> instance.</summary>
public class QueryStringHelperConfiguration
{
    ///<summary><inheritdoc cref="EmptyCollectionHandlingStrategy"/></summary>
    public EmptyCollectionHandlingStrategy? EmptyCollectionHandling { get; set; } = EmptyCollectionHandlingStrategy.Ignore;
    ///<summary><inheritdoc cref="NullValueHandlingStrategy"/></summary>
    public NullValueHandlingStrategy? NullValueHandling { get; set; } = NullValueHandlingStrategy.Ignore;
    ///<summary><inheritdoc cref="QueryStringNamingPolicy"/></summary>
    public QueryStringNamingPolicy? NamingPolicy { get; set; } = QueryStringNamingPolicy.Identity;
    ///<summary><inheritdoc cref="QueryStringNestingStrategy"/></summary>
    public QueryStringNestingStrategy? NestingStrategy { get; set; } = QueryStringNestingStrategy.DotNotation;
    ///<summary>Gets or sets a value indicating whether collection will be rendered in index-like mode (array[0]=value0 and array[1]=value1) or collection set (array=[value0, value1]).</summary>
    public bool? UseArrayIndex { get; set; } = true;
    ///<summary>Gets or sets a value indicating whether strings should be enclosed with double quotes.</summary>
    public bool? UseQuotedStrings { get; set; } = false;
    ///<summary>Gets or sets a value indicating whether uri components should be encoded or raw strings will be returned.</summary>
    ///<remarks>Setting this value to <see langword="false"/> may lead to unwanted behaviours when running in production. Please change this flag only for testing and debugging purposes.</remarks>
    public bool? EncodeUriComponents { get; set; } = true;
    /// <summary>Creates a new instance of <see cref="QueryStringHelperConfiguration"/>.</summary>
    public QueryStringHelperConfiguration() { } 
    /// <summary>Creates a new instance of <see cref="QueryStringHelperConfiguration"/> with the given configuration.</summary>
    internal QueryStringHelperConfiguration(QueryStringHelperConfiguration cfg)
    {
        EmptyCollectionHandling = cfg.EmptyCollectionHandling ?? Default.EmptyCollectionHandling;
        NullValueHandling = cfg.NullValueHandling ?? Default.NullValueHandling;
        NamingPolicy = cfg.NamingPolicy ?? Default.NamingPolicy;
        UseArrayIndex = cfg.UseArrayIndex ?? Default.UseArrayIndex;
        NestingStrategy = cfg.NestingStrategy ?? Default.NestingStrategy;
        EncodeUriComponents = cfg.EncodeUriComponents ?? Default.EncodeUriComponents;
        UseQuotedStrings = cfg.UseQuotedStrings ?? Default.UseQuotedStrings;
    }

    internal static readonly QueryStringHelperConfiguration Default = new()
    {
        EmptyCollectionHandling = EmptyCollectionHandlingStrategy.Ignore,
        NestingStrategy = QueryStringNestingStrategy.DotNotation,
        NullValueHandling = NullValueHandlingStrategy.Ignore,
        NamingPolicy = QueryStringNamingPolicy.Identity,
        UseArrayIndex = true,
        UseQuotedStrings = false,
        EncodeUriComponents = true
    };

    internal const string NullTextLower = "null";
    internal const string NullTextUpper = "NULL";
}