#region Copyright 2021-2022 C. Augusto Proiete & Contributors
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
    /// Extension methods to <see cref="IComparer{T}"/> to make it easier to use <see cref="NaturalStringComparer"/>
    /// </summary>
    public static class IComparerOfStringExtensions
    {
        /// <summary>
        /// Create a <see cref="NaturalStringComparer"/> with the <paramref name="comparer"/> provided
        /// for comparing strings using natural sorting.
        /// </summary>
        /// <param name="comparer">The <see cref="IComparer{T}"/> to use.</param>
        /// <returns>An instance of <see cref="NaturalStringComparer"/> with the <paramref name="comparer"/> provided.</returns>
        public static INaturalStringComparer AsNatural(this IComparer<string?> comparer)
        {
            return new NaturalStringComparer(comparer);
        }
    }
}
