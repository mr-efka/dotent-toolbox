# ToolBox.Commons.Extensions

Provides various extension methods to simplify you .Net developments.

### Available APIs
* **Strings**
```csharp
    ///<summary>Converts the specified string to title case (except for words that are entirely in uppercase, which are considered to be acronyms).</summary>
    ///<param name="value">What to convert</param>
    ///<param name="removeSpaces">If <see langword="true"/>, all white-space characters are dropped from the resulting string.</param>
    string? ToTitleCase(this string? value, bool removeSpaces = false)
    ///<summary>Transforms the value, making it human-friendly. Words first characters are uppercase and all white-space characters are dropped.</summary>
    ///<param name="value">What to convert</param>
    string? ToUpperCamelCase(this string? value)
    ///<summary>Transforms the value, making it human-friendly. All white-space characters are dropped and words first characters are uppercase except for the first one.</summary>
    ///<param name="value">What to convert</param>
    ///<returns></returns>
    string? ToCamelCase(this string? value)
    ///<summary>Transforms the value by inserting the <paramref name="separator"/> before each upper-cased character, except the first one.</summary>
    ///<param name="value">What to convert</param>
    ///<param name="separator">Separating character</param>
    ///<param name="lowerCased">Flag that indicates whether the resulting string should be lowercased.</param>
    ///<param name="throwIfValueIsNull">When using this function as static class method call, this flag indicates whether to throw an error when <paramref name="value"/> is null. If false, null is returned.</param>
    string? ToSeparatorCase(this string? value, in char separator [, bool throwIfValueIsNull = true, bool lowerCased = true])
    ///<summary>Transforms the value, making it human-friendly. Words are separated by an underscore.</summary>
    ///<param name="value">What to convert</param>
    string? ToSnakeCase(this string value [, bool throwIfValueIsNull = true])
    ///<summary>Transforms the value, making it human-friendly. Words are separated by a dash.</summary>
    ///<param name="value">What to convert</param>
    string? ToKebabCase(this string value [, bool throwIfValueIsNull = true])
    ///<summary>Transforms the value, making it human-friendly. Words are separated by a dash and all lowercased.</summary>
    ///<param name="value">What to convert</param>
    string? ToKebabCaseLower(this string value [,bool throwIfValueIsNull = true])
    ///<summary>Transforms the value, making it human-friendly. Words are separated by an underscore and all lowercased.</summary>
    ///<param name="value">What to convert</param>
    string Slugify(this string value) => ToKebabCaseLower(value, false);    
```

* **Enumerable**
```csharp
    ///<summary>Drop duplicated items in the given <paramref name="enumerable"/> collection. Follow <see cref="HashSet{T}"/> logic.</summary>
    /// <typeparam name="T">Type of items in the current collection.</typeparam>
    /// <param name="enumerable">Source to drop duplicates from.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> with duplicates removed.</returns>
    IEnumerable<T> RemoveDuplicates<T>(this IEnumerable<T> enumerable)
    ///<summary>Removes null elements from the enumerable.</summary>
    ///<typeparam name="T">The type of elements in the enumerable.</typeparam>
    ///<param name="enumerable">The enumerable to remove null elements from.</param>
    ///<returns>An enumerable without null elements.</returns>
    IEnumerable<T> DropNulls<T>(this IEnumerable<T> enumerable)
    ///<summary>Removes empty or whitespace-only string elements from the enumerable.</summary>
    ///<remarks>This function do remove null values as per as it uses regular expressions for filtering.</remarks>
    ///<param name="enumerable">The enumerable of strings to filter.</param>
    ///<returns>An enumerable without empty or whitespace-only string elements.</returns>
    IEnumerable<string> DropEmptyOrWhiteSpace(this IEnumerable<string> enumerable)
    ///<summary>Determines whether the elements of a sequence of values, selected by a key, form a consecutive sequence.</summary>
    /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
    /// <param name="enumerable">The sequence of values to check.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <returns><see langword="true"/> if the sequence is consecutive; otherwise, <see langword="false"/>.</returns>
    public static bool IsConsecutive<T>(this IEnumerable<T> enumerable, Func<T, long> keySelector)   
```
* **Dates**
```csharp
    ///<summary>Returns the end of the day date for the given DateTime.</summary>
    ///<param name="date">The DateTime value for which to get the end of the day date.</param>
    ///<returns>The end of the day date for the given DateTime.</returns>
    DateTime ToEndDayDate(this DateTime date)
```

* **Objects**
```csharp
    ///<summary>Determines whether the specified object is null or equals the default value for its type.</summary>
    ///<typeparam name="T">The type of the default value.</typeparam>
    ///<param name="obj">The object to check.</param>
    ///<returns>True if the specified object is null or equals the default value for its type; otherwise, false.</returns>
    bool IsNullOrDefault<T>(this T? obj)
    ///<summary>Determines whether the specified object is null or equals the default value provided.</summary>
    ///<typeparam name="T">The type of the default value.</typeparam>
    ///<param name="obj">The object to check.</param>
    ///<param name="defaultValue">The default value to compare against.</param>
    ///<returns>True if the specified object is null or equals the default value provided; otherwise, false.</returns>
    bool IsNullOrDefault<T>(this object? obj, T? defaultValue)
    ///<summary>Converts the specified object to its JSON representation.</summary>
    ///<param name="obj">The object to be serialized to JSON.</param>
    ///<returns>A JSON string representing the serialized object.</returns>
    string ToJson(this object obj)
    ///<summary>Converts a JSON string representation into an object of type <typeparamref name="T"/>.</summary>
    ///<typeparam name="T">The type of the object to deserialize.</typeparam>
    ///<param name="jsonObjectString">The JSON string to deserialize.</param>
    ///<returns>The deserialized object of type T, or null if deserialization fails.</returns>
    T? FromJson<T>(this string? jsonObjectString)
    ///<summary>Extracts all messages in given exception.</summary>
    ///<param name="ex">Base exception.</param>
    IEnumerable<string> GetAllMessages(this Exception? ex)
```

## Authors

- **Mr Efka** - _Initial work_ - [Mr efka](https://github.com/mr-efka)

## License

This project is licensed under the BSD 2-Clause License - see the [LICENSE](LICENSE) file for details.