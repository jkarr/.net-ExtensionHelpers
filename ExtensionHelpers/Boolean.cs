namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        /// <summary>
        /// Returns a custom string based on the boolean value.
        /// </summary>
        /// <param name="boolean">The boolean value.</param>
        /// <param name="trueValue">The string to return if true.</param>
        /// <param name="falseValue">The string to return if false.</param>
        /// <returns>trueValue or falseValue determined by the boolean.</returns>
        public static string ToCustomString(this bool boolean, string trueValue, string falseValue)
        {
            trueValue = trueValue.IsNullOrEmpty() ? "true" : trueValue;
            falseValue = falseValue.IsNullOrEmpty() ? "false" : falseValue;

            return boolean ? trueValue : falseValue;
        }
    }
}