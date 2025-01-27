﻿namespace Notify.Domain.SeedWork;

public abstract class TypedIdValueBase(Guid value) : IEquatable<TypedIdValueBase>
{
    public Guid Value { get; } = value;

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is TypedIdValueBase other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public bool Equals(TypedIdValueBase other)
    {
        return Value == other.Value;
    }

    public static bool operator ==(TypedIdValueBase obj1, TypedIdValueBase obj2)
    {
        if (object.Equals(obj1, null))
        {
            if (object.Equals(obj2, null))
            {
                return true;
            }
            return false;
        }
        return obj1.Equals(obj2);
    }
    public static bool operator !=(TypedIdValueBase x, TypedIdValueBase y) 
    {
        return !(x == y);
    }
}