using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public sealed class Polynomial
    {
        private static readonly double COMPARISON = 10e-5;
        private readonly double[] coefficients;

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="polynomial_coefficients">Polynomial coefficients</param>
        /// <exception cref="ArgumentNullException">
        /// If Parameters should not be represent as null array
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If Length should be great then zero
        /// </exception>
        public Polynomial(params double[] polynomial_coefficients)
        {
            CheckData(polynomial_coefficients);
            coefficients = new double[polynomial_coefficients.Length];
            polynomial_coefficients.CopyTo(coefficients, 0);
        }

        /// <summary>
        /// Property to get power of Polynomial
        /// </summary>
        public int Power { get => coefficients.Length - 1; }

        public double this[int index]
        {
            get
            {
                return coefficients[index];
            }

            private set
            {
                coefficients[index] = value;
            }
        }
        #region Overriding methods
        /// <summary>
        /// Get string representation of polynomial
        /// </summary>
        /// <returns>String representation of polynomial</returns>
        public override string ToString()
        {
            string stringPolynomial = string.Empty;
            int power = GetCoefficients().Length - 1;
            foreach (double coeff in GetCoefficients())
            {
                if (power == 0)
                {
                    stringPolynomial = string.Concat(stringPolynomial, $"{coeff}");
                }
                else
                {
                    stringPolynomial = string.Concat(stringPolynomial, $"{coeff}*x^{power}+");
                }

                power--;
            }

            return stringPolynomial;
        }

        /// <summary>
        /// Equals of two polynomial objects
        /// </summary>
        /// <param name="another">Object to compare with</param>
        /// <returns> Result of Equals </returns>
        public override bool Equals(object another)
        {
            if (another == null || GetType() != another.GetType())
            {
                return false;
            }
            else
            {
                return this == (Polynomial)another;
            }
        }

        /// <summary>
        /// Get hash code of polynomial
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                for (int i = 0; i < Power; i++)
                {
                    hash = hash * 23 + coefficients[i].GetHashCode();
                }

                return hash;
            }
        }

        #endregion

        #region Overriding operators
        /// <summary>
        /// Multiplication operator
        /// </summary>
        /// <param name="thirst">First operand</param>
        /// <param name="second">Second operand</param>
        /// <returns>Result of multiplication</returns>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            double[] shortest = first.GetCoefficients();
            double[] longest = second.GetCoefficients();

            double[] result = new double[shortest.Length + longest.Length - 1];

            for (int i = 0; i < shortest.Length; i++)
            {
                for (int j = 0; j < longest.Length; j++)
                {
                    result[i + j] += shortest[i] * longest[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Sum operator
        /// </summary>
        /// <param name="first">First operand</param>
        /// <param name="second">Second operand</param>
        /// <returns>Result of Sum</returns>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            (double[] shortest, double[] longest) normalizedArrays = BringToSameState(first, second);
            double[] shortest = normalizedArrays.shortest;
            double[] longest = normalizedArrays.longest;

            double[] result = new double[longest.Length];

            for (int i = 0; i < longest.Length; i++)
            {
                result[i] = shortest[i] + longest[i];
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Difference operator
        /// </summary>
        /// <param name="first">First operand</param>
        /// <param name="second">Second First operand</param>
        /// <returns>Result of difference</returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            bool firstIsShortest = first.GetCoefficients().Length < second.GetCoefficients().Length;
            (double[] shortest, double[] longest) normalizedArrays = BringToSameState(first, second);

            double[] shortest = normalizedArrays.shortest;
            double[] longest = normalizedArrays.longest;

            double[] result = new double[longest.Length];

            if (firstIsShortest)
            {
                for (int i = 0; i < longest.Length; i++)
                {
                    result[i] = shortest[i] - longest[i];
                }
            }
            else
            {
                for (int i = 0; i < longest.Length; i++)
                {
                    result[i] = longest[i] - shortest[i];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Difference operator
        /// </summary>
        /// <param name="first">First operand</param>
        /// <param name="second">Second First operand</param>
        /// <returns>Result of difference</returns>
        public static Polynomial operator -(double first, Polynomial second)
        {
            double[] singleValue = { first };
            Polynomial result = new Polynomial(singleValue);
            return result - second;
        }

        /// <summary>
        /// Multiplication operator for single value and polynomial
        /// </summary>
        /// <param name="lhs">First operand</param>
        /// <param name="rhs">Second operand</param>
        /// <returns>Result of multiplication</returns>
        public static Polynomial operator *(double first, Polynomial second)
        {
            double[] singleValue = { first };
            Polynomial result = new Polynomial(singleValue);
            return result * second;
        }

        /// <summary>
        /// Equals operator
        /// </summary>
        /// <param name="first">First operand</param>
        /// <param name="second">Second operand</param>
        /// <returns>Result of Equals</returns>
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }

            if (first.Power != first.Power)
            {
                return false;
            }

            for (int i = 0; i < first.coefficients.Length; i++)
            {
                if (!(Math.Abs(first[i] - second[i]) < COMPARISON))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Not Equals operator
        /// </summary>
        /// <param name="first">First operator</param>
        /// <param name="second">Second operator</param>
        /// <returns>Result of not Equals</returns>
        public static bool operator !=(Polynomial first, Polynomial second)
            => !(first == second);

        private static (double[], double[]) BringToSameState(Polynomial leftCoefficents, Polynomial rightsCoefficents)
        {
            double[] first = leftCoefficents.GetCoefficients();
            double[] second = rightsCoefficents.GetCoefficients();

            double[] longest = (first.Length >= second.Length) ? first : second;
            double[] shortest = (longest == first) ? second : first;

            double[] result = new double[longest.Length];
            Array.Copy(shortest, result, shortest.Length);

            RightShift(ref result, longest.Length - shortest.Length);

            return (result, longest);
        }

        private static void RightShift(ref double[] givenArray, int count)
        {
            count = count % givenArray.Length;
            double[] tmp = new double[givenArray.Length];

            for (int i = givenArray.Length - 1; i >= 0; i--)
            {
                tmp[i] = givenArray[(i - count + givenArray.Length) % givenArray.Length];
            }

            givenArray = tmp;
        }

        #endregion
        #region Private methods
        private void CheckData(double[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Parameters should not be represent as null array");
            }

            if (data.Length == 0)
            {
                throw new ArgumentException(nameof(data), "Length should be great then zero");
            }
        }

        private double[] GetCoefficients()
        {
            var copy = new double[coefficients.Length];
            Array.Copy(coefficients, copy, coefficients.Length);
            return copy;
        }
        #endregion
    }
}
