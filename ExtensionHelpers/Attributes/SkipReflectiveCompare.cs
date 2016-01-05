using System;

namespace ExtensionHelpers.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SkipReflectiveCompare : Attribute
    {
    }
}