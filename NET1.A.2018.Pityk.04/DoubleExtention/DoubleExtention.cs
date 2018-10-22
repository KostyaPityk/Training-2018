using System;
using System.Runtime.InteropServices;

namespace DoubleExtention
{
    /// <summary>
    /// Represents class that expands the possibilities of System.Double
    /// by implementing method to represent System.Double into its binary string
    /// representation according to IEEE 754 rules
    /// </summary>
    public static class DoubleExtention
    {
        private const int SIZEOFLONG = 64;

        /// <summary>
        /// Extension method for System.Double to convert double to 
        /// IEEE 754 binary representation
        /// </summary>
        /// <param name="number">Double value to be converted to string</param>
        /// <returns>Representation of System.Double in IEEE 754</returns>
        public static string ToBinaryString(double number)
        {
            CustomDoubleToLongBits converter = new CustomDoubleToLongBits() { Double = number };
            long doubleBits = converter.Long;

            return ToBinaryString(doubleBits, SIZEOFLONG);
        }

        private static string ToBinaryString(long value, int bytes)
        {
            string result = string.Empty;

            for (int i = 0; i < bytes; i++)
            {
                result = result.Insert(0, (value & 1).ToString());
                value >>= 1;
            }

            return result.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CustomDoubleToLongBits
        {
            public double Double { private get => doubleValue; set => doubleValue = value; }

            public long Long { get => longValue; private set => longValue = value; }

            [FieldOffset(0)] private double doubleValue;
            [FieldOffset(0)] private long longValue;
        }
    }
}
