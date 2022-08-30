using System;

namespace Monday.Client.Tests;

public static class RandomExtensions
{
    public static ulong NextUInt64(this Random random)
    {
        return (ulong)random.NextInt64();
    }

    public static string NextString(this Random random)
    {
        return Guid.NewGuid().ToString();
    }
}
