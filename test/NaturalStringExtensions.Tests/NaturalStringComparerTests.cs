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
using System.Runtime.InteropServices;
using Xunit;
using FluentAssertions;
using NaturalStringExtensions.Tests.Support;

namespace NaturalStringExtensions.Tests
{
    public class NaturalStringComparerTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Compare_uses_natural_sorting_when_comparing_the_two_strings(string left, string right, StringComparison comparison, int expected)
        {
            var result = new NaturalStringComparer(comparison).Compare(left, right);

            result.Should().Be(expected);
        }

        [Fact]
        public void Linq_OrderBy_using_NaturalStringComparer_orders_items_using_natural_sorting()
        {
            var input = new[]
            {
                "Folder 3",
                "Folder 13",
                "FOlder 1",
                "Folder 1",
                "Folder 26",
                "Folder 10",
                "Folder 6",
                "Folder 4",
                "Folder 5",
                "FOlder 5",
                "Folder 2",
                "00Folder 5",
                "00Folder 1",
                "00FOlder 1",
                "00Folder 10",
            };

            var expectedOutput = new[]
            {
                "00Folder 1",
                "00FOlder 1",
                "00Folder 5",
                "00Folder 10",
                "FOlder 1",
                "Folder 1",
                "Folder 2",
                "Folder 3",
                "Folder 4",
                "Folder 5",
                "FOlder 5",
                "Folder 6",
                "Folder 10",
                "Folder 13",
                "Folder 26",
            };

            var output = input.OrderBy(s => s, new NaturalStringComparer()).ToArray();

            output.Should().BeEquivalentTo(expectedOutput)
                .And.ContainInOrder(expectedOutput);
        }

        [SkippableFact]
        public void NaturalStringComparer_OrdinalIgnoreCase_behaves_like_Windows_StrCmpLogicalW_API()
        {
            Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));

            var input = new[]
            {
                "Folder 3",
                "Folder 13",
                "FOlder 1",
                "Folder 1",
                "Folder 26",
                "Folder 10",
                "Folder 6",
                "Folder 4",
                "Folder 5",
                "FOlder 5",
                "Folder 2",
                "00Folder 5",
                "00Folder 1",
                "00FOlder 1",
                "00Folder 10",
            };

            var expectedOutput = input.OrderBy(s => s, new StrCmpLogicalWStringComparer()).ToArray();

            var output = input.OrderBy(s => s, new NaturalStringComparer()).ToArray();

            output.Should().BeEquivalentTo(expectedOutput)
                .And.ContainInOrder(expectedOutput);
        }

        [Fact]
        public void Can_sort_array_of_string_using_natural_sorting()
        {
            var input = new[]
            {
                "Folder 3",
                "Folder 13",
                "FOlder 1",
                "Folder 1",
                "Folder 26",
                "Folder 10",
                "Folder 6",
                "Folder 4",
                "Folder 5",
                "FOlder 5",
                "Folder 2",
                "00Folder 5",
                "00Folder 1",
                "00FOlder 1",
                "00Folder 10",
            };

            var expected = new[]
            {
                "00Folder 1",
                "00FOlder 1",
                "00Folder 5",
                "00Folder 10",
                "FOlder 1",
                "Folder 1",
                "Folder 2",
                "Folder 3",
                "Folder 4",
                "Folder 5",
                "FOlder 5",
                "Folder 6",
                "Folder 10",
                "Folder 13",
                "Folder 26",
            };

            Array.Sort(input, NaturalStringComparer.OrdinalIgnoreCase);

            input.Should().BeEquivalentTo(expected)
                .And.ContainInOrder(expected);
        }

        [Theory]
        [InlineData("v1.2.3", "v1.10.0", true)]
        [InlineData("v1.10.0", "v1.2.3", false)]
        [InlineData("v1.2.3", "v1.2.3", false)]
        public void IsLessThan_uses_natural_string_comparison(string left, string right, bool expected)
        {
            var result = NaturalStringComparer.OrdinalIgnoreCase.IsLessThan(left, right);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("v1.2.3", "v1.10.0", true)]
        [InlineData("v1.10.0", "v1.2.3", false)]
        [InlineData("v1.2.3", "v1.2.3", true)]
        public void IsLessThanOrEqual_uses_natural_string_comparison(string left, string right, bool expected)
        {
            var result = NaturalStringComparer.OrdinalIgnoreCase.IsLessThanOrEqual(left, right);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("v1.2.3", "v1.10.0", false)]
        [InlineData("v1.10.0", "v1.2.3", false)]
        [InlineData("v1.2.3", "v1.2.3", true)]
        public void IsEqual_uses_natural_string_comparison(string left, string right, bool expected)
        {
            var result = NaturalStringComparer.OrdinalIgnoreCase.IsEqual(left, right);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("v1.2.3", "v1.10.0", false)]
        [InlineData("v1.10.0", "v1.2.3", true)]
        [InlineData("v1.2.3", "v1.2.3", false)]
        public void IsGreaterThan_uses_natural_string_comparison(string left, string right, bool expected)
        {
            var result = NaturalStringComparer.OrdinalIgnoreCase.IsGreaterThan(left, right);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("v1.2.3", "v1.10.0", false)]
        [InlineData("v1.10.0", "v1.2.3", true)]
        [InlineData("v1.2.3", "v1.2.3", true)]
        public void IsGreaterThanOrEqual_uses_natural_string_comparison(string left, string right, bool expected)
        {
            var result = NaturalStringComparer.OrdinalIgnoreCase.IsGreaterThanOrEqual(left, right);
            result.Should().Be(expected);
        }

        [Fact]
        public void Can_access_singleton_instances()
        {
            NaturalStringComparer.Ordinal.Should().NotBeNull()
                .And.BeOfType<NaturalStringComparer>();

            NaturalStringComparer.OrdinalIgnoreCase.Should().NotBeNull()
                .And.BeOfType<NaturalStringComparer>();

            NaturalStringComparer.InvariantCulture.Should().NotBeNull()
                .And.BeOfType<NaturalStringComparer>();

            NaturalStringComparer.InvariantCultureIgnoreCase.Should().NotBeNull()
                .And.BeOfType<NaturalStringComparer>();

            NaturalStringComparer.CurrentCulture.Should().NotBeNull()
                .And.BeOfType<NaturalStringComparer>();

            NaturalStringComparer.CurrentCultureIgnoreCase.Should().NotBeNull()
                .And.BeOfType<NaturalStringComparer>();
        }

        public static IEnumerable<object[]> TestData
        {
            get
            {
                var allComparisons = Enum.GetValues(typeof(StringComparison)).Cast<StringComparison>();

                var testCasesAllComparisons = new[]
                {
                    new { Left = "Folder", Right = "Folder", Expected = 0 },
                    new { Left = "Folder10", Right = "Folder5", Expected = 1 },
                    new { Left = "Folder5", Right = "Folder10", Expected = -1 },
                };

                var testCasesAllComparisonsMatrix =
                    from t in testCasesAllComparisons
                    from c in allComparisons
                    select new { t.Left, t.Right, Comparison = c, t.Expected };

                var testCasesAllCaseSensitive = new[]
                {
                    new { Left = "Folder", Right = "FOlder", Comparison = StringComparison.Ordinal, Expected = 32 },
                    new { Left = "FOlder", Right = "Folder", Comparison = StringComparison.Ordinal, Expected = -32 },
                    new { Left = "Folder5", Right = "FOlder5", Comparison = StringComparison.Ordinal, Expected = 32 },
                    new { Left = "FOlder5", Right = "Folder5", Comparison = StringComparison.Ordinal, Expected = -32 },
                    new { Left = "Folder5", Right = "FOlder1", Comparison = StringComparison.Ordinal, Expected = 32 },
                    new { Left = "FOlder1", Right = "Folder5", Comparison = StringComparison.Ordinal, Expected = -32 },
                    new { Left = "000Folder5", Right = "000FOlder1", Comparison = StringComparison.Ordinal, Expected = 32 },
                    new { Left = "000FOlder1", Right = "000Folder5", Comparison = StringComparison.Ordinal, Expected = -32 },
                };

                var testCasesAllCaseInsensitive = new[]
                {
                    new { Left = "Folder", Right = "FOlder", Comparison = StringComparison.OrdinalIgnoreCase, Expected = 0 },
                    new { Left = "FOlder", Right = "Folder", Comparison = StringComparison.OrdinalIgnoreCase, Expected = 0 },
                    new { Left = "Folder5", Right = "FOlder5", Comparison = StringComparison.OrdinalIgnoreCase, Expected = 0 },
                    new { Left = "FOlder5", Right = "Folder5", Comparison = StringComparison.OrdinalIgnoreCase, Expected = 0 },
                    new { Left = "Folder5", Right = "FOlder1", Comparison = StringComparison.OrdinalIgnoreCase, Expected = 1 },
                    new { Left = "FOlder1", Right = "Folder5", Comparison = StringComparison.OrdinalIgnoreCase, Expected = -1 },
                    new { Left = "000Folder5", Right = "000FOlder1", Comparison = StringComparison.OrdinalIgnoreCase, Expected = 1 },
                    new { Left = "000FOlder1", Right = "000Folder5", Comparison = StringComparison.OrdinalIgnoreCase, Expected = -1 },
                };

                return testCasesAllComparisonsMatrix
                    .Concat(testCasesAllCaseSensitive)
                    .Concat(testCasesAllCaseInsensitive)
                    .Select(x => new object[]
                        {
                            x.Left,
                            x.Right,
                            x.Comparison,
                            x.Expected,
                        }
                    );
            }
        }
    }
}
