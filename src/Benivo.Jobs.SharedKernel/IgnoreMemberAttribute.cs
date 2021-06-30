using System;

namespace Benivo.Jobs.SharedKernel
{
    // source: https://github.com/jhewlett/ValueObject
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}