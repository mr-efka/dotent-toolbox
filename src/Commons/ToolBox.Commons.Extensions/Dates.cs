namespace MrEfka.ToolBox.Commons.Extensions;

///<summary>Provides utils function to work with .Net Dates</summary>
public static class Dates
{
    ///<summary>Returns the end of the day date for the given DateTime.</summary>
    ///<param name="date">The DateTime value for which to get the end of the day date.</param>
    ///<returns>The end of the day date for the given DateTime.</returns>
    public static DateTime ToEndDayDate(this DateTime date) => ToEndDayDateCompute(date);

    ///<summary>Returns the end of the day date for the given DateTime.</summary>
    ///<param name="date">The DateTime value for which to get the end of the day date.</param>
    ///<returns>The end of the day date for the given DateTime.</returns>
    public static DateTime ToEndDayDate(this DateTime? date) =>
        date is null ? throw new ArgumentNullException(nameof(date)) : ToEndDayDateCompute(date.Value);
    
    private static DateTime ToEndDayDateCompute(DateTime date) => date.Date.AddDays(1).AddTicks(-1);
}