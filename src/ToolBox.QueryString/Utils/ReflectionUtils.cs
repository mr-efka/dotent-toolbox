using System;
namespace MrEfka.ToolBox.QueryString.Utils;

/// <summary>
/// Utility class to get collection's underlying element type.
/// </summary>
/// <remarks>
/// Thanks to [Honey the CodeWitch](https://www.codeproject.com/Tips/5267157/How-to-Get-a-Collection-Element-Type-Using-Reflect)
/// </remarks>
public static class ReflectionUtils
{
    /// <summary>
    /// Indicates whether or not the specified type is a list.
    /// </summary>
    /// <param name="type">The type to query</param>
    /// <returns>True if the type is a list, otherwise false</returns>
    public static bool IsList(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (typeof(System.Collections.IList).IsAssignableFrom(type))
            return true;
        foreach (var it in type.GetInterfaces())
            if (it.IsGenericType && typeof(IList<>) == it.GetGenericTypeDefinition())
                return true;
        return false;
    }
    /// <summary>
    /// Retrieves the collection element type from this type
    /// </summary>
    /// <param name="type">The type to query</param>
    /// <returns>The element type of the collection or null if the type was not a collection
    /// </returns>
    public static Type? GetCollectionElementType(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        // first try the generic way
        // this is easy, just query the IEnumerable<T> interface for its generic parameter
        var enumerableType = typeof(IEnumerable<>);
        foreach (var bt in type.GetInterfaces())
            if (bt.IsGenericType && bt.GetGenericTypeDefinition() == enumerableType)
                return bt.GetGenericArguments()[0];

        // now try the non-generic way

        // if it's a dictionary we always return DictionaryEntry
        if (typeof(System.Collections.IDictionary).IsAssignableFrom(type))
            return typeof(System.Collections.DictionaryEntry);

        // if it's a list we look for an Item property with an int index parameter
        // where the property type is anything but object
        if (typeof(System.Collections.IList).IsAssignableFrom(type))
        {
            foreach (var prop in type.GetProperties())
            {
                if ("Item" == prop.Name && typeof(object) != prop.PropertyType)
                {
                    var ipa = prop.GetIndexParameters();
                    if (1 == ipa.Length && typeof(int) == ipa[0].ParameterType)
                    {
                        return prop.PropertyType;
                    }
                }
            }
        }

        // if it's a collection, we look for an Add() method whose parameter is 
        // anything but object
        if (typeof(System.Collections.ICollection).IsAssignableFrom(type))
        {
            foreach (var meth in type.GetMethods())
            {
                if (meth.Name == "Add")
                {
                    var parameterInfos = meth.GetParameters();
                    if (parameterInfos.Length == 1 && typeof(object) != parameterInfos[0].ParameterType)
                        return parameterInfos[0].ParameterType;
                }
            }
        }
        if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
            return typeof(object);
        return null;
    }
}

