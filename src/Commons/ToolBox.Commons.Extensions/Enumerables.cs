namespace System.Collections.Generic;

public static partial class Enumerable
{
    /// <summary>
    /// Drop duplicated items in the given <paramref name="enumerable"/> collection. Follow <see cref="HashSet{T}"/> logic.
    /// </summary>
    /// <typeparam name="T">Type of items in the current collection.</typeparam>
    /// <param name="enumerable">Source to drop duplicates from.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> with duplicates removed.</returns>
    public static IEnumerable<T> RemoveDuplicates<T>(this IEnumerable<T> enumerable)
        => new HashSet<T>(enumerable);
    
    /// <summary>
    /// Removes null elements from the enumerable.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="enumerable">The enumerable to remove null elements from.</param>
    /// <returns>An enumerable without null elements.</returns>
    public static IEnumerable<T> DropNulls<T>(this IEnumerable<T> enumerable) => enumerable.Where(x => x is not null);

    /// <summary>
    /// Removes empty or whitespace-only string elements from the enumerable.
    /// </summary>
    /// <remarks>This function do remove null values as per as it uses regular expressions for filtering.</remarks>
    /// <param name="enumerable">The enumerable of strings to filter.</param>
    /// <returns>An enumerable without empty or whitespace-only string elements.</returns>
    public static IEnumerable<string> DropEmptyOrWhiteSpace(this IEnumerable<string> enumerable) => enumerable.Where(x => !System.Text.RegularExpressions.Regex.IsMatch(x, @"^\s+$"));
}