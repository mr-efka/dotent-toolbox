using System.Reflection;

namespace MrEfka.ToolBox.Commons.Extensions;

///<summary>Provides utils functions for .Net reflection</summary>
public static class Reflections
{
    ///<summary>Checks whether the provided <paramref name="memberInfo"/> has attributes of type <typeparamref name="T"/> in his custom attributes collection.</summary>
    /// <typeparam name="T">Type of the attribute to check for.</typeparam>
    /// <param name="memberInfo">Member to evaluate.</param>
    /// <param name="inherit"><inheritdoc cref="MemberInfo.GetCustomAttributes(bool)"/></param>
    /// <returns><see langword="true"/> if the attribute is defined on the <see cref="MemberInfo"/>, otherwise <see langword="false"/></returns>
    public static bool HasAttributesOfType<T>(this MemberInfo memberInfo, bool inherit = true) where T : Attribute
    {
        ArgumentNullException.ThrowIfNull(memberInfo);
        var attrs = memberInfo.GetCustomAttributes<T>(inherit);
        return attrs.Any();
    }
}