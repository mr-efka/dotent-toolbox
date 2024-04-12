namespace MrEfka.ToolBox.Commons.Extensions;

///<summary>Provides Utils functions to work with .Net enumerable</summary>
public static class Enumerables
{
    ///<summary>Drop duplicated items in the given <paramref name="enumerable"/> collection. Follow <see cref="HashSet{T}"/> logic.</summary>
    /// <typeparam name="T">Type of items in the current collection.</typeparam>
    /// <param name="enumerable">Source to drop duplicates from.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> with duplicates removed.</returns>
    public static IEnumerable<T> RemoveDuplicates<T>(this IEnumerable<T> enumerable) => new HashSet<T>(enumerable);
    ///<summary>Determines whether the elements of a sequence of values, selected by a key, form a consecutive sequence.</summary>
    /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
    /// <param name="enumerable">The sequence of values to check.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <returns><see langword="true"/> if the sequence is consecutive; otherwise, <see langword="false"/>.</returns>
    public static bool IsConsecutive<T>(this IEnumerable<T> enumerable, Func<T, long> keySelector)
    {
        ArgumentNullException.ThrowIfNull(enumerable, nameof(enumerable));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

        return enumerable.Select((x, idx) => keySelector(x) - idx).Distinct().Count() == 1;
    }
    ///<summary>Removes null elements from the enumerable.</summary>
    ///<typeparam name="T">The type of elements in the enumerable.</typeparam>
    ///<param name="enumerable">The enumerable to remove null elements from.</param>
    ///<returns>An enumerable without null elements.</returns>
    public static IEnumerable<T> DropNulls<T>(this IEnumerable<T> enumerable) => enumerable.Where(x => x is not null);
    ///<summary>Removes empty or whitespace-only string elements from the enumerable.</summary>
    ///<remarks>This function do remove null values as per as it uses regular expressions for filtering.</remarks>
    ///<param name="enumerable">The enumerable of strings to filter.</param>
    ///<returns>An enumerable without empty or whitespace-only string elements.</returns>
    public static IEnumerable<string> DropEmptyOrWhiteSpace(this IEnumerable<string> enumerable) => enumerable.Where(x => !System.Text.RegularExpressions.Regex.IsMatch(x, @"^\s+$"));

}