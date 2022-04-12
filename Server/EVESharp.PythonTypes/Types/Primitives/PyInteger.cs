namespace EVESharp.PythonTypes.Types.Primitives;

public class PyInteger : PyDataType
{
    public enum IntegerTypeEnum
    {
        Long,
        Int,
        Short,
        Byte
    }

    public long Value { get; }

    public IntegerTypeEnum IntegerType { get; }

    public PyInteger (long value)
    {
        Value       = value;
        IntegerType = IntegerTypeEnum.Long;
    }

    public PyInteger (int value)
    {
        Value       = value;
        IntegerType = IntegerTypeEnum.Int;
    }

    public PyInteger (short value)
    {
        Value       = value;
        IntegerType = IntegerTypeEnum.Short;
    }

    public PyInteger (byte value)
    {
        Value = value;
        if (value > sbyte.MaxValue)
            IntegerType = IntegerTypeEnum.Short;
        else
            IntegerType = IntegerTypeEnum.Byte;
    }

    public PyInteger (sbyte value)
    {
        Value       = value;
        IntegerType = IntegerTypeEnum.Byte;
    }

    private bool Equals (PyInteger other)
    {
        if (ReferenceEquals (null, other)) return false;

        return Value.Equals (other.Value);
    }

    public override int GetHashCode ()
    {
        return Value.GetHashCode ();
    }

    public static bool operator == (PyInteger left, PyInteger right)
    {
        if (ReferenceEquals (left, right)) return true;
        if (ReferenceEquals (null, left)) return false;

        return left.Equals (right);
    }

    public static bool operator != (PyInteger obj, PyInteger other)
    {
        return !(obj == other);
    }

    public static bool operator > (PyInteger obj, PyInteger other)
    {
        return obj.Value > other.Value;
    }

    public static bool operator >= (PyInteger obj, PyInteger other)
    {
        return obj.Value >= other.Value;
    }

    public static bool operator <= (PyInteger obj, PyInteger other)
    {
        return obj.Value <= other.Value;
    }

    public static bool operator < (PyInteger obj, PyInteger other)
    {
        return obj.Value < other.Value;
    }

    public static implicit operator double? (PyInteger obj)
    {
        return obj?.Value;
    }

    public static implicit operator ulong? (PyInteger obj)
    {
        return (ulong?) obj?.Value;
    }

    public static implicit operator long? (PyInteger obj)
    {
        return obj?.Value;
    }

    public static implicit operator uint? (PyInteger obj)
    {
        return (uint?) obj?.Value;
    }

    public static implicit operator int? (PyInteger obj)
    {
        return (int?) obj?.Value;
    }

    public static implicit operator ushort? (PyInteger obj)
    {
        return (ushort?) obj?.Value;
    }

    public static implicit operator short? (PyInteger obj)
    {
        return (short?) obj?.Value;
    }

    public static implicit operator byte? (PyInteger obj)
    {
        return (byte?) obj?.Value;
    }

    public static implicit operator sbyte? (PyInteger obj)
    {
        return (sbyte?) obj?.Value;
    }

    public static implicit operator ulong (PyInteger obj)
    {
        return (ulong) obj.Value;
    }

    public static implicit operator double (PyInteger obj)
    {
        return obj.Value;
    }

    public static implicit operator long (PyInteger obj)
    {
        return obj.Value;
    }

    public static implicit operator uint (PyInteger obj)
    {
        return (uint) obj.Value;
    }

    public static implicit operator int (PyInteger obj)
    {
        return (int) obj.Value;
    }

    public static implicit operator ushort (PyInteger obj)
    {
        return (ushort) obj.Value;
    }

    public static implicit operator short (PyInteger obj)
    {
        return (short) obj.Value;
    }

    public static implicit operator byte (PyInteger obj)
    {
        return (byte) obj.Value;
    }

    public static implicit operator sbyte (PyInteger obj)
    {
        return (sbyte) obj.Value;
    }

    public static implicit operator PyInteger (ulong value)
    {
        return new PyInteger ((long) value);
    }

    public static implicit operator PyInteger (long value)
    {
        return new PyInteger (value);
    }

    public static implicit operator PyInteger (uint value)
    {
        return new PyInteger (value);
    }

    public static implicit operator PyInteger (int value)
    {
        return new PyInteger (value);
    }

    public static implicit operator PyInteger (ushort value)
    {
        return new PyInteger (value);
    }

    public static implicit operator PyInteger (short value)
    {
        return new PyInteger (value);
    }

    public static implicit operator PyInteger (byte value)
    {
        return new PyInteger (value);
    }

    public static implicit operator PyInteger (sbyte value)
    {
        return new PyInteger (value);
    }

    public override string ToString ()
    {
        return Value.ToString ();
    }
}