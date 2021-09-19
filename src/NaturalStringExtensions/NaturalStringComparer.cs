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
using System.ComponentModel;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    /// A comparer to compare any two strings using natural sorting.
    /// </summary>
    public class NaturalStringComparer : INaturalStringComparer
    {
        private readonly StringComparison _comparisonType;
        private readonly IComparer<string?>? _comparer;

        /// <summary>
        /// Compare strings using natural ordinal (binary) sort rules.
        /// </summary>
        public static INaturalStringComparer Ordinal { get; } =
            new NaturalStringComparer(StringComparison.Ordinal);

        /// <summary>
        /// Compare strings using natural ordinal (binary) sort rules and ignoring the case of the strings being compared.
        /// </summary>
        public static INaturalStringComparer OrdinalIgnoreCase { get; } =
            new NaturalStringComparer(StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Compare strings using natural culture-sensitive sort rules and the invariant culture.
        /// </summary>
        public static INaturalStringComparer InvariantCulture { get; } =
            new NaturalStringComparer(StringComparison.InvariantCulture);

        /// <summary>
        /// Compare strings using natural culture-sensitive sort rules, the invariant culture, and ignoring the case of the strings being compared.
        /// </summary>
        public static INaturalStringComparer InvariantCultureIgnoreCase { get; } =
            new NaturalStringComparer(StringComparison.InvariantCultureIgnoreCase);

        /// <summary>
        /// Compare strings using natural culture-sensitive sort rules and the current culture.
        /// </summary>
        public static INaturalStringComparer CurrentCulture { get; } =
            new NaturalStringComparer(StringComparison.CurrentCulture);

        /// <summary>
        /// Compare strings using natural culture-sensitive sort rules, the current culture, and ignoring the case of the strings being compared.
        /// </summary>
        public static INaturalStringComparer CurrentCultureIgnoreCase { get; } =
            new NaturalStringComparer(StringComparison.CurrentCultureIgnoreCase);

        /// <summary>
        /// Gets a <see cref="NaturalStringComparer" /> object that performs a case-sensitive ordinal natural string comparison.
        /// </summary>
        /// <returns>A <see cref="NaturalStringComparer" /> object.</returns>
        [Obsolete("Use NaturalStringComparer.Ordinal instead. Instance is obsolete and will be removed in a future release.")]
        public static INaturalStringComparer Instance => Ordinal;

        /// <summary>
        /// Initializes a new instance of <see cref="NaturalStringComparer"/> class using <see cref="StringComparison.OrdinalIgnoreCase"/>.
        /// </summary>
        public NaturalStringComparer()
            : this(StringComparison.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NaturalStringComparer"/> class with the specified <see cref="StringComparison"/>.
        /// </summary>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use.</param>
        public NaturalStringComparer(StringComparison comparisonType)
        {
            if (!Enum.IsDefined(typeof(StringComparison), comparisonType))
            {
                throw new InvalidEnumArgumentException(nameof(comparisonType), (int)comparisonType, typeof(StringComparison));
            }

            _comparisonType = comparisonType;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NaturalStringComparer"/> class with the specified <see cref="IComparer{T}"/>.
        /// </summary>
        /// <param name="comparer">The <see cref="IComparer{T}"/> to use.</param>
        public NaturalStringComparer(IComparer<string?> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        /// <summary>
        /// Compares two strings and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="left">The first strings to compare.</param>
        /// <param name="right">The second strings to compare.</param>
        /// <returns>
        /// Value Condition Less than zero <paramref name="left" /> is less than <paramref name="right" />. Zero <paramref name="left" /> equals <paramref name="right" />. Greater than zero <paramref name="left" /> is greater than <paramref name="right" />.
        /// </returns>
        public int Compare(string? left, string? right)
        {
            // Let string.Compare handle the case where left or right is null
            if (left is null || right is null)
            {
                if (_comparer is null)
                {
                    return string.Compare(left, right, _comparisonType);
                }

                return _comparer.Compare(left, right);
            }

            var leftSegments = GetSegments(left);
            var rightSegments = GetSegments(right);

            while (leftSegments.MoveNext() && rightSegments.MoveNext())
            {
#if NETSTANDARD2_0 || NETFRAMEWORK_461
                var leftIsNumber = int.TryParse(leftSegments.Current.ToString(), out var leftValue);
                var rightIsNumber = int.TryParse(rightSegments.Current.ToString(), out var rightValue);
#else
                var leftIsNumber = int.TryParse(leftSegments.Current, out var leftValue);
                var rightIsNumber = int.TryParse(rightSegments.Current, out var rightValue);
#endif

                int cmp;

                // If they're both numbers, compare the value
                if (leftIsNumber && rightIsNumber)
                {
                    cmp = leftValue.CompareTo(rightValue);
                    if (cmp != 0)
                    {
                        return cmp;
                    }
                }

                // If left is a number and right is not, left is "lesser than" right
                else if (leftIsNumber)
                {
                    return -1;
                }

                // If right is a number and left is not, left is "greater than" right
                else if (rightIsNumber)
                {
                    return 1;
                }

                // OK, neither are number, compare the segments as text
                if (_comparer is null)
                {
                    cmp = leftSegments.Current.CompareTo(rightSegments.Current, _comparisonType);
                }
                else
                {
                    cmp = _comparer.Compare(left.ToString(), right.ToString());
                }

                if (cmp != 0)
                {
                    return cmp;
                }
            }

            // At this point, either all segments are equal, or one string is shorter than the other

            // If left is shorter, it's "lesser than" right
            if (left.Length < right.Length)
            {
                return -1;
            }

            // If left is longer, it's "greater than" right
            if (left.Length > right.Length)
            {
                return 1;
            }

            // If they have the same length, they're equal
            return 0;
        }

        /// <inheritdoc/>
        public bool IsLessThan(string? left, string? right)
        {
            return Compare(left, right) < 0;
        }

        /// <inheritdoc/>
        public bool IsLessThanOrEqual(string? left, string? right)
        {
            return Compare(left, right) <= 0;
        }

        /// <inheritdoc/>
        public bool IsEqual(string? left, string? right)
        {
            return Compare(left, right) == 0;
        }

        /// <inheritdoc/>
        public bool IsGreaterThan(string? left, string? right)
        {
            return Compare(left, right) > 0;
        }

        /// <inheritdoc/>
        public bool IsGreaterThanOrEqual(string? left, string? right)
        {
            return Compare(left, right) >= 0;
        }

        private static StringSegmentEnumerator GetSegments(string value) => new StringSegmentEnumerator(value);

        private struct StringSegmentEnumerator
        {
            private readonly string _value;
            private int _start;
            private int _length;
            private int _currentPosition;

            public StringSegmentEnumerator(string value)
            {
                _value = value;
                _start = -1;
                _length = 0;
                _currentPosition = 0;
            }

            public ReadOnlySpan<char> Current => _value.AsSpan(_start, _length);

            public bool MoveNext()
            {
                if (_currentPosition >= _value.Length)
                {
                    return false;
                }

                var start = _currentPosition;
                var isFirstCharDigit = char.IsDigit(_value[_currentPosition]);

                while (++_currentPosition < _value.Length && char.IsDigit(_value[_currentPosition]) == isFirstCharDigit)
                {
                }

                _start = start;
                _length = _currentPosition - start;

                return true;
            }
        }
    }
}
