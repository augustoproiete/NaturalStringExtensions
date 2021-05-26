#region Copyright 2021 C. Augusto Proiete & Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// A comparer to compare any two strings using natural sorting.
    /// </summary>
    public sealed class NaturalStringComparer : IComparer<string?>
    {
        private static readonly Lazy<NaturalStringComparer> _instance = new(isThreadSafe: true);

        /// <summary>
        /// Gets a <see cref="NaturalStringComparer" /> object that performs a case-sensitive ordinal natural string comparison.
        /// </summary>
        /// <returns>A <see cref="NaturalStringComparer" /> object.</returns>
        public static NaturalStringComparer Ordinal => _instance.Value;

        /// <summary>
        /// Gets a <see cref="NaturalStringComparer" /> object that performs a case-sensitive ordinal natural string comparison.
        /// </summary>
        /// <returns>A <see cref="NaturalStringComparer" /> object.</returns>
        [Obsolete("Use NaturalStringComparer.Ordinal instead. Instance is obsolete and will be removed in a future release.")]
        public static NaturalStringComparer Instance => _instance.Value;

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>
        /// Value Condition Less than zero <paramref name="left" /> is less than <paramref name="right" />. Zero <paramref name="left" /> equals <paramref name="right" />. Greater than zero <paramref name="left" /> is greater than <paramref name="right" />.
        /// </returns>
        public int Compare(string? left, string? right)
        {
            if (left is null && right is null)
            {
                return 0;
            }

            if (left is null)
            {
                return -1;
            }

            if (right is null)
            {
                return 1;
            }

            var lengthOfLeft = left.Length;
            var lengthOfRight = right.Length;

            for (int indexLeft = 0, indexRight = 0; indexLeft < lengthOfLeft && indexRight < lengthOfRight; indexLeft++, indexRight++)
            {
                if (char.IsDigit(left[indexLeft]) && char.IsDigit(right[indexRight]))
                {
                    long numericValueLeft = 0;
                    long numericValueRight = 0;

                    for (; indexLeft < lengthOfLeft && char.IsDigit(left[indexLeft]); indexLeft++)
                    {
                        numericValueLeft = numericValueLeft * 10 + left[indexLeft] - '0';
                    }

                    for (; indexRight < lengthOfRight && char.IsDigit(right[indexRight]); indexRight++)
                    {
                        numericValueRight = numericValueRight * 10 + right[indexRight] - '0';
                    }

                    if (numericValueLeft != numericValueRight)
                    {
                        return numericValueLeft > numericValueRight ? 1 : -1;
                    }
                }

                if (indexLeft < lengthOfLeft && indexRight < lengthOfRight && left[indexLeft] != right[indexRight])
                {
                    return left[indexLeft] > right[indexRight] ? 1 : -1;
                }
            }

            return lengthOfLeft - lengthOfRight;
        }
    }
}
