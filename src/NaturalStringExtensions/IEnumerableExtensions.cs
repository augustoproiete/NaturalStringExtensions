#region Copyright 2021-2023 C. Augusto Proiete & Contributors
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
namespace System.Linq
{
    /// <summary>
    /// Provides a set of <see langword="static" /> (<see langword="Shared" /> in Visual Basic) methods for sorting objects that implement <see cref="IEnumerable{T}" /> using the <see cref="NaturalStringComparer" /> comparer.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IEnumerableExtensions
    {
        /// <summary>Sorts the elements of a sequence of strings in natural ascending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">A sequence of values to order.</param>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<string> OrderByNatural(this IEnumerable<string> source) =>
            source.OrderBy(s => s, NaturalStringComparer.OrdinalIgnoreCase);

        /// <summary>Sorts the elements of a sequence of strings in natural ascending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use.</param>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<string> OrderByNatural(this IEnumerable<string> source, StringComparison comparisonType) =>
            source.OrderBy(s => s, NaturalStringComparer.FromComparison(comparisonType));

        /// <summary>Sorts the elements of a sequence of strings in natural descending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">A sequence of values to order.</param>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted in descending order according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<string> OrderByNaturalDescending(this IEnumerable<string> source) =>
            source.OrderByDescending(s => s, NaturalStringComparer.OrdinalIgnoreCase);

        /// <summary>Sorts the elements of a sequence of strings in natural descending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use.</param>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted in descending order according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<string> OrderByNaturalDescending(this IEnumerable<string> source, StringComparison comparisonType) =>
            source.OrderByDescending(s => s, NaturalStringComparer.FromComparison(comparisonType));

        /// <summary>Performs a subsequent ordering of the elements in a sequence of strings in natural ascending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">An <see cref="IOrderedEnumerable{T}" /> that contains elements to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted according to a key.</returns>
        public static IOrderedEnumerable<string> ThenByNatural(this IOrderedEnumerable<string> source) =>
            source.ThenBy(s => s, NaturalStringComparer.OrdinalIgnoreCase);

        /// <summary>Performs a subsequent ordering of the elements in a sequence of strings in natural ascending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">An <see cref="IOrderedEnumerable{T}" /> that contains elements to sort.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted according to a key.</returns>
        public static IOrderedEnumerable<string> ThenByNatural(this IOrderedEnumerable<string> source, StringComparison comparisonType) =>
            source.ThenBy(s => s, NaturalStringComparer.FromComparison(comparisonType));

        /// <summary>Performs a subsequent ordering of the elements in a sequence of strings in natural descending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">An <see cref="IOrderedEnumerable{T}" /> that contains elements to sort.</param>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted in descending order according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<string> ThenByNaturalDescending(this IOrderedEnumerable<string> source) =>
            source.ThenByDescending(s => s, NaturalStringComparer.OrdinalIgnoreCase);

        /// <summary>Performs a subsequent ordering of the elements in a sequence of strings in natural descending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">An <see cref="IOrderedEnumerable{T}" /> that contains elements to sort.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use.</param>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted in descending order according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<string> ThenByNaturalDescending(this IOrderedEnumerable<string> source, StringComparison comparisonType) =>
            source.ThenByDescending(s => s, NaturalStringComparer.FromComparison(comparisonType));

        /// <summary>Sorts the elements of a sequence in natural ascending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="keySelector" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<TSource> OrderByNatural<TSource>(this IEnumerable<TSource> source, Func<TSource, string?> keySelector) =>
            source.OrderBy(keySelector, NaturalStringComparer.OrdinalIgnoreCase);

        /// <summary>Sorts the elements of a sequence in natural ascending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="keySelector" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<TSource> OrderByNatural<TSource>(this IEnumerable<TSource> source, Func<TSource, string?> keySelector, StringComparison comparisonType) =>
            source.OrderBy(keySelector, NaturalStringComparer.FromComparison(comparisonType));

        /// <summary>Sorts the elements of a sequence in natural descending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted in descending order according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="keySelector" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<TSource> OrderByNaturalDescending<TSource>(this IEnumerable<TSource> source, Func<TSource, string?> keySelector) =>
            source.OrderByDescending(keySelector, NaturalStringComparer.OrdinalIgnoreCase);

        /// <summary>Sorts the elements of a sequence in natural descending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted in descending order according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="keySelector" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<TSource> OrderByNaturalDescending<TSource>(this IEnumerable<TSource> source, Func<TSource, string?> keySelector, StringComparison comparisonType) =>
            source.OrderByDescending(keySelector, NaturalStringComparer.FromComparison(comparisonType));

        /// <summary>Performs a subsequent ordering of the elements in a sequence in natural ascending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">An <see cref="IOrderedEnumerable{T}" /> that contains elements to sort.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="keySelector" /> is <see langword="null" />.</exception>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted according to a key.</returns>
        public static IOrderedEnumerable<TSource> ThenByNatural<TSource>(this IOrderedEnumerable<TSource> source, Func<TSource, string?> keySelector) =>
            source.ThenBy(keySelector, NaturalStringComparer.OrdinalIgnoreCase);

        /// <summary>Performs a subsequent ordering of the elements in a sequence in natural ascending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">An <see cref="IOrderedEnumerable{T}" /> that contains elements to sort.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="keySelector" /> is <see langword="null" />.</exception>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted according to a key.</returns>
        public static IOrderedEnumerable<TSource> ThenByNatural<TSource>(this IOrderedEnumerable<TSource> source, Func<TSource, string?> keySelector, StringComparison comparisonType) =>
            source.ThenBy(keySelector, NaturalStringComparer.FromComparison(comparisonType));

        /// <summary>Performs a subsequent ordering of the elements in a sequence in natural descending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">An <see cref="IOrderedEnumerable{T}" /> that contains elements to sort.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted in descending order according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="keySelector" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<TSource> ThenByNaturalDescending<TSource>(this IOrderedEnumerable<TSource> source, Func<TSource, string?> keySelector) =>
            source.ThenByDescending(keySelector, NaturalStringComparer.OrdinalIgnoreCase);

        /// <summary>Performs a subsequent ordering of the elements in a sequence in natural descending order by using the <see cref="NaturalStringComparer" /> comparer.</summary>
        /// <param name="source">An <see cref="IOrderedEnumerable{T}" /> that contains elements to sort.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use.</param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>An <see cref="IOrderedEnumerable{T}" /> whose elements are sorted in descending order according to a key.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="keySelector" /> is <see langword="null" />.</exception>
        public static IOrderedEnumerable<TSource> ThenByNaturalDescending<TSource>(this IOrderedEnumerable<TSource> source, Func<TSource, string?> keySelector, StringComparison comparisonType) =>
            source.ThenByDescending(keySelector, NaturalStringComparer.FromComparison(comparisonType));
    }
}
