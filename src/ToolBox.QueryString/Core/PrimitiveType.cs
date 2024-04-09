#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace MrEfka.ToolBox.QueryString.Core;

///<summary>Represents a wrapper around a primitive type.</summary>
public readonly struct PrimitiveType : IEquatable<PrimitiveType>
{
    ///<summary>Holds the wrapped primitive type value.</summary>
    // TODO: Is dynamic a 'valid' type to use here ? 
    private readonly dynamic _value;
    ///<summary>Classification of the primitive type. See <see cref="PrimitiveTypeClass"/> for supported classes.</summary>
    private readonly PrimitiveTypeClass _class;

    #region Constructors
    ///<summary>DO NOT USE</summary>
    ///<exception cref="NotImplementedException"></exception>
    [Obsolete($"Always throws {nameof(NotImplementedException)}", true)]
    public PrimitiveType() => throw new NotImplementedException();
    
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(bool value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Boolean;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(bool? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Boolean;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(sbyte value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(sbyte? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(byte value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(byte? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }    
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(short value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(short? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(ushort value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(ushort? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(int value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(int? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(uint value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(uint? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(nint value) // TO REMOVE ?
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(nuint value) // TO REMOVE ?
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(long value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(long? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(ulong value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(ulong? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(decimal value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(decimal? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(float value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(float? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(double value)
    {
        _value = value;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(double? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = value!;
        _class = PrimitiveTypeClass.Number;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(char value): this(value.ToString()) { }
    
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(char? value)
    {
        ThrowIfNullableHasNoValue(value);
        _value = (value is null ? null! : value.ToString())!;
        _class = PrimitiveTypeClass.String;
    }
    ///<summary>Creates a new instance of<see cref="T:ToolBox.QueryString.PrimitiveType"/> with the provided <paramref name="value"/></summary>
    ///<param name="value">Primitive value to wrap</param>
    public PrimitiveType(string? value)
    {
        _value = value!;
        _class = PrimitiveTypeClass.String;
    }
    #endregion

    #region Overrides
    ///<summary><inheritdoc cref="object.Equals(object?)"/></summary>
    ///<param name="obj"><inheritdoc cref="object.Equals(object?)"/></param>
    ///<returns><inheritdoc cref="object.Equals(object?)"/></returns>
    public override bool Equals(object? obj)
    {
        if (obj is not PrimitiveType primitiveType || _class != primitiveType._class) return false;

        if (_class != PrimitiveTypeClass.String) return _value?.Equals(primitiveType._value);

        return ((_value as string) ?? string.Empty).SequenceEqual((primitiveType._value as string) ?? string.Empty);
    }
    ///<summary><inheritdoc cref="object.GetHashCode()"/></summary>
    ///<returns><inheritdoc cref="object.GetHashCode()"/></returns>
    public override int GetHashCode() => HashCode.Combine(_value, (int)_class) * 801;
    ///<summary><inheritdoc cref="object.ToString()"/></summary>
    ///<returns><inheritdoc cref="object.ToString()"/></returns>
    public override string ToString()
        => (_value is null)
            ? string.Empty
            : _value.ToString();
    #endregion

    #region IEquatable<PrimitiveType> Impl
    ///<summary><inheritdoc cref="object.Equals(object?)"/></summary>
    ///<param name="other"><inheritdoc cref="object.Equals(object?)"/></param>
    ///<returns><inheritdoc cref="object.Equals(object?)"/></returns>
    public bool Equals(PrimitiveType other)
    {
        return Equals((object)other);
    }
    #endregion
    
    #region Comparison Operators
    ///<summary><inheritdoc cref="Equals(PrimitiveType)"/></summary>>
    /// <param name="left">Operator's left hand item</param>
    /// <param name="right">Operator's right hand item</param>
    /// <returns><inheritdoc cref="Equals(PrimitiveType)"/></returns>
    public static bool operator ==(PrimitiveType left, PrimitiveType? right)
    {
        if (right is null && left is { _value: null }) return true;
        return left.Equals(right);
    }
    ///<summary>Negation of the == operator.</summary>>
    /// <param name="left">Operator's left hand item</param>
    /// <param name="right">Operator's right hand item</param>
    /// <returns></returns>
    public static bool operator !=(PrimitiveType left, PrimitiveType? right)
    {
        return !(left == right);
    }
    #endregion

    #region Implicit Conversion operators
    public static implicit operator PrimitiveType(bool val) => new(val);
    public static implicit operator PrimitiveType(bool? val) => new(val);
    public static implicit operator PrimitiveType(byte val) => new(val);
    public static implicit operator PrimitiveType(byte? val) => new(val);
    public static implicit operator PrimitiveType(sbyte val) => new(val);
    public static implicit operator PrimitiveType(sbyte? val) => new(val);
    public static implicit operator PrimitiveType(short val) => new(val);
    public static implicit operator PrimitiveType(short? val) => new(val);
    public static implicit operator PrimitiveType(ushort val) => new(val);
    public static implicit operator PrimitiveType(ushort? val) => new(val);
    public static implicit operator PrimitiveType(int val) => new(val);
    public static implicit operator PrimitiveType(int? val) => new(val);
    public static implicit operator PrimitiveType(uint val) => new(val);
    public static implicit operator PrimitiveType(uint? val) => new(val);
    public static implicit operator PrimitiveType(nint val) => new(val);
    public static implicit operator PrimitiveType(nint? val) => new(val);
    public static implicit operator PrimitiveType(nuint val) => new(val);
    public static implicit operator PrimitiveType(nuint? val) => new(val);
    public static implicit operator PrimitiveType(long val) => new(val);
    public static implicit operator PrimitiveType(long? val) => new(val);
    public static implicit operator PrimitiveType(ulong val) => new(val);
    public static implicit operator PrimitiveType(ulong? val) => new(val);
    public static implicit operator PrimitiveType(decimal val) => new(val);
    public static implicit operator PrimitiveType(decimal? val) => new(val);
    public static implicit operator PrimitiveType(float val) => new(val);
    public static implicit operator PrimitiveType(float? val) => new(val);
    public static implicit operator PrimitiveType(double val) => new(val);
    public static implicit operator PrimitiveType(double? val) => new(val);
    public static implicit operator PrimitiveType(string? val) => new(val);
    public static implicit operator string(PrimitiveType val) => val.ToString();
    #endregion

    #region Internal Instance Methods
    ///<summary>Checks whether the value in the current <see cref="PrimitiveType"/> is null.</summary>>
    /// <returns>true if <see cref="_value"/> is null. Otherwise, false.</returns>
    internal bool IsNull() => this._value is null;
    ///<summary>Returns the string representation of the current <see cref="PrimitiveType"/> instance. When the encapsulated value is a string, the flag <paramref name="quoted"/> tells whether to surround the original value with double quotes.</summary>>
    /// <param name="quoted">Whether to surround the original value with double quotes</param>
    /// <returns>The string</returns>
    internal string ToString(bool quoted)
    {
        string value = this.ToString();
        return quoted && this._class == PrimitiveTypeClass.String ? $"\"{value}\"" : value;
    }
    #endregion

    #region Statics
    ///<summary>Checks whether the given<paramref name="type"/> is considered by this api as a valid primitive type.</summary>
    ///<param name="type">Target type to check.</param>
    ///<returns><see langword="true"/> if valid type detected; otherwise <see langword="false"/></returns>
    internal static bool IsPrimitive(Type? type)
    {
        if (type is null) return false;
    
        var typeCode = Type.GetTypeCode(type);

        return typeCode switch
        {
            TypeCode.Boolean or
                TypeCode.String or
                TypeCode.Byte or
                TypeCode.Decimal or
                TypeCode.Double or
                TypeCode.Int16 or
                TypeCode.Int32 or
                TypeCode.Int64 or
                TypeCode.SByte or
                TypeCode.Single or
                TypeCode.UInt16 or
                TypeCode.UInt32 or
                TypeCode.Char or
                TypeCode.UInt64 => true,
            // Handling nullable
                TypeCode.Object when 
                    type.IsGenericType && 
                    type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                    IsPrimitive(Nullable.GetUnderlyingType(type)!) 
                    => true,
            TypeCode.Object => false,
            _ => false
        };
    }
    ///<summary>Checks whether the value in <paramref name="o"/> is considered by this api as a valid primitive value.</summary>
    ///<remarks>This api assumes null values are primitive, independently from the declared type of <paramref name="o"/>.</remarks>
    ///<param name="o">Value to check.</param>
    ///<returns><see langword="true"/> if <paramref name="o"/> value is primitive; otherwise <see langword="false"/></returns>
    internal static bool IsPrimitive(object? o)
    {
        if (o is null) return true; // Assuming o is of type string or supported nullable, as we dont want to infer the real type.
        return IsPrimitive(o.GetType());
    }
    ///<summary>Attempts to convert the provided given object (<paramref name="o"/>) to a valid<see cref="T:ToolBox.QueryString.PrimitiveType"/>.</summary>
    ///<param name="o">An object representing the value to convert.</param>
    ///<param name="output">When this method returns, contains the <see cref="T:ToolBox.QueryString.PrimitiveType"/> value equivalent of the value contained in <paramref name="o" /> if the conversion succeeded, or <see langword="null" /> if the conversion failed. The conversion fails if the <paramref name="o" /> parameter is not an <see cref="Enum"/> or a <see cref="string"/> or a <see cref="Boolean"/> or any valid native number type. </param>
    ///<returns><see langword="true"/> if conversion succeeded. Otherwise, <see langword="false"/></returns>
    public static bool TryParse(object o, out PrimitiveType? output)
    {
        try
        {
            output = Parse(o);
        }
        catch (Exception)
        {
            output = null;
        }
        return output is not null;
    }
    ///<summary>Attempts to convert the provided given object (<paramref name="o"/>) to a valid<see cref="T:ToolBox.QueryString.PrimitiveType"/>.</summary>
    ///<param name="o">Value to parse</param>
    ///<returns>The created <see cref="T:ToolBox.QueryString.PrimitiveType"/> if conversion succeeded.</returns>
    ///<exception cref="T:System.InvalidCastException">Thrown if conversion fails</exception>
    public static PrimitiveType Parse(object? o)
    {
        // All null values are considered valid and treated as strings, as strings can have null references
        if (o is null) return new((string)null!);

        var type = o.GetType();
        if (type.IsEnum) return new((int)o); // As enum can be parsed to integer numbers
    
        var typeCode = Type.GetTypeCode(type);

        // TODO : Add support to handle implicit conversions to supported types.
        // Ex : class Digit { // Conversion to int provided. }
        // This (Digit class) is not a primitive (IsPrimitive(Digit) => false) but it can be parsed as a primitive.

        return typeCode switch
        {
            TypeCode.Boolean => new((bool)o),
            TypeCode.Byte => new((byte)o),
            TypeCode.Decimal => new((decimal)o),
            TypeCode.Double => new((double)o),
            TypeCode.Int16 => new((short)o),
            TypeCode.Int32 => new((int)o),
            TypeCode.Int64 => new((long)o),
            TypeCode.SByte => new((sbyte)o),
            TypeCode.Single => new((float)o),
            TypeCode.UInt16 => new((ushort)o),
            TypeCode.UInt32 => new((uint)o),
            TypeCode.UInt64 => new((ulong)o),
            TypeCode.String => new((string)o),
            TypeCode.Char => new((char)o),
            TypeCode.Object => ParseNullable(),
            _ => throw new InvalidCastException("Unsupported primitive type")
        };

        PrimitiveType ParseNullable()
        {
            Type underlyingType;
            if (!type.IsGenericType || // Nullables are generic : if not generic, exit
                !(type.GetGenericTypeDefinition() == typeof(Nullable<>)) || // Check generic definition is `Nullable<>`
                !IsPrimitive((underlyingType = Nullable.GetUnderlyingType(type)!))) // Check whether the underlying type is primitive.
                throw new InvalidCastException("Unsupported primitive type");
        
            return Parse(Convert.ChangeType(o, underlyingType));
        }
    }
    #endregion

    #region Privates
    ///<summary>Throws an exception if given<paramref name="value"/> is not null but has no value.</summary>
    ///<remarks>Noticed that on some platforms, it is possible to instantiate a <see cref="Nullable{T}"/> without a value and it is not null. But on other, null value nullable are directly treated as `null`. This method acts as a safety guard to ensure that provided <see cref="Nullable{T}"/> value is either null or not null with a value in it.</remarks>
    ///<param name="value"></param>
    ///<typeparam name="T"></typeparam>
    ///<exception cref="ArgumentException"></exception>
    private static void ThrowIfNullableHasNoValue<T>(T? value) where T: struct
    {
        if (value is not null && !value.HasValue) throw new ArgumentException("Nullable has no value", nameof(value));
    }
    #endregion
}