namespace EVESharp.Types;

public class PyNone : PyDataType
{
    public const int HASH_VALUE = -1;
    
    public override int GetHashCode ()
    {
        return HASH_VALUE;
    }

    public override string ToString ()
    {
        return $"{GetType ().Name}: [ NONE ]";
    }
}