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
using System.Linq;
using FluentAssertions;
using Xunit;

namespace NaturalStringExtensions.Tests
{
    // ReSharper disable once InconsistentNaming
    public class IEnumerableExtensionsTests
    {
        [Fact]
        public void OrderByNatural_is_equivalent_to_OrderBy_KeySelector_with_NaturalStringComparer()
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(v => v, NaturalStringComparer.Instance);

            var result = versions
                .OrderByNatural();

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Fact]
        public void OrderByNaturalDescending_is_equivalent_to_OrderByDescending_KeySelector_with_NaturalStringComparer()
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderByDescending(v => v, NaturalStringComparer.Instance);

            var result = versions
                .OrderByNaturalDescending();

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Fact]
        public void ThenByNatural_is_equivalent_to_ThenBy_KeySelector_with_NaturalStringComparer()
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(_ => "A", StringComparer.Ordinal)
                .ThenBy(v => v, NaturalStringComparer.Instance);

            var result = versions
                .OrderBy(_ => "A", StringComparer.Ordinal)
                .ThenByNatural();

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Fact]
        public void ThenByNaturalDescending_is_equivalent_to_ThenByDescending_KeySelector_with_NaturalStringComparer()
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(_ => "A", StringComparer.Ordinal)
                .ThenByDescending(v => v, NaturalStringComparer.Instance);

            var result = versions
                .OrderBy(_ => "A", StringComparer.Ordinal)
                .ThenByNaturalDescending();

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Fact]
        public void OrderByNatural_KeySelector_is_equivalent_to_OrderBy_KeySelector_with_NaturalStringComparer()
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(v => v, NaturalStringComparer.Instance);

            var result = versions
                .OrderByNatural(v => v);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Fact]
        public void OrderByNaturalDescending_KeySelector_is_equivalent_to_OrderByDescending_KeySelector_with_NaturalStringComparer()
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderByDescending(v => v, NaturalStringComparer.Instance);

            var result = versions
                .OrderByNaturalDescending(v => v);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Fact]
        public void ThenByNatural_KeySelector_is_equivalent_to_ThenBy_KeySelector_with_NaturalStringComparer()
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(_ => "A", StringComparer.Ordinal)
                .ThenBy(v => v, NaturalStringComparer.Instance);

            var result = versions
                .OrderBy(_ => "A", StringComparer.Ordinal)
                .ThenByNatural(v => v);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }

        [Fact]
        public void ThenByNaturalDescending_KeySelector_is_equivalent_to_ThenByDescending_KeySelector_with_NaturalStringComparer()
        {
            var versions = new[]
            {
                "2.1.0",
                "1.0.0",
                "10.3.0",
                "20.4.0",
            };

            var expected = versions
                .OrderBy(_ => "A", StringComparer.Ordinal)
                .ThenByDescending(v => v, NaturalStringComparer.Instance);

            var result = versions
                .OrderBy(_ => "A", StringComparer.Ordinal)
                .ThenByNaturalDescending( v => v);

            result.Should().BeEquivalentTo(expected,
                options => options.WithStrictOrdering());
        }
    }
}
