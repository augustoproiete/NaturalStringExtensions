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

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace NaturalStringExtensions.Tests
{
    // ReSharper disable once InconsistentNaming
    public class IEnumerableExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void OrderByNatural_is_equivalent_to_OrderBy_KeySelector_with_NaturalStringComparer(StringComparison comparisonType)
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(v => v, NaturalStringComparer.FromComparison(comparisonType));

            var result = versions
                .OrderByNatural(comparisonType);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void OrderByNaturalDescending_is_equivalent_to_OrderByDescending_KeySelector_with_NaturalStringComparer(StringComparison comparisonType)
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderByDescending(v => v, NaturalStringComparer.FromComparison(comparisonType));

            var result = versions
                .OrderByNaturalDescending(comparisonType);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ThenByNatural_is_equivalent_to_ThenBy_KeySelector_with_NaturalStringComparer(StringComparison comparisonType)
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(_ => "A", StringComparerFromComparison(comparisonType))
                .ThenBy(v => v, NaturalStringComparer.FromComparison(comparisonType));

            var result = versions
                .OrderBy(_ => "A", StringComparerFromComparison(comparisonType))
                .ThenByNatural(comparisonType);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ThenByNaturalDescending_is_equivalent_to_ThenByDescending_KeySelector_with_NaturalStringComparer(StringComparison comparisonType)
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(_ => "A", StringComparerFromComparison(comparisonType))
                .ThenByDescending(v => v, NaturalStringComparer.FromComparison(comparisonType));

            var result = versions
                .OrderBy(_ => "A", StringComparerFromComparison(comparisonType))
                .ThenByNaturalDescending(comparisonType);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void OrderByNatural_KeySelector_is_equivalent_to_OrderBy_KeySelector_with_NaturalStringComparer(StringComparison comparisonType)
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(v => v, NaturalStringComparer.FromComparison(comparisonType));

            var result = versions
                .OrderByNatural(v => v, comparisonType);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void OrderByNaturalDescending_KeySelector_is_equivalent_to_OrderByDescending_KeySelector_with_NaturalStringComparer(StringComparison comparisonType)
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderByDescending(v => v, NaturalStringComparer.FromComparison(comparisonType));

            var result = versions
                .OrderByNaturalDescending(v => v, comparisonType);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ThenByNatural_KeySelector_is_equivalent_to_ThenBy_KeySelector_with_NaturalStringComparer(StringComparison comparisonType)
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(_ => "A", StringComparerFromComparison(comparisonType))
                .ThenBy(v => v, NaturalStringComparer.FromComparison(comparisonType));

            var result = versions
                .OrderBy(_ => "A", StringComparerFromComparison(comparisonType))
                .ThenByNatural(v => v, comparisonType);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ThenByNaturalDescending_KeySelector_is_equivalent_to_ThenByDescending_KeySelector_with_NaturalStringComparer(StringComparison comparisonType)
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(_ => "A", StringComparerFromComparison(comparisonType))
                .ThenByDescending(v => v, NaturalStringComparer.FromComparison(comparisonType));

            var result = versions
                .OrderBy(_ => "A", StringComparerFromComparison(comparisonType))
                .ThenByNaturalDescending(v => v, comparisonType);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        public static IEnumerable<object[]> TestData
        {
            get
            {
                var allComparisons = Enum.GetValues(typeof(StringComparison)).Cast<StringComparison>();

                return allComparisons
                    .Select(comparisonType => new object[]
                        {
                            comparisonType,
                        }
                    );
            }
        }

        private StringComparer StringComparerFromComparison(StringComparison comparisonType)
        {
            return comparisonType switch
            {
                StringComparison.CurrentCulture => StringComparer.CurrentCulture,
                StringComparison.CurrentCultureIgnoreCase => StringComparer.CurrentCultureIgnoreCase,
                StringComparison.InvariantCulture => StringComparer.InvariantCulture,
                StringComparison.InvariantCultureIgnoreCase => StringComparer.InvariantCultureIgnoreCase,
                StringComparison.Ordinal => StringComparer.Ordinal,
                StringComparison.OrdinalIgnoreCase => StringComparer.OrdinalIgnoreCase,
                _ => throw new ArgumentException($"{comparisonType} is not supported", nameof(comparisonType)),
            };
        }
    }
}
