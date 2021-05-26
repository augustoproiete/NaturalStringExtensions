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
    public class NaturalStringComparerTests
    {
        [Theory]
        [InlineData("Folder 5", "Folder 10", -1)]
        [InlineData("Folder 5", "Folder 5", 0)]
        [InlineData("Folder 10", "Folder 5", 1)]
        [InlineData("00Folder 5", "00Folder 10", -1)]
        [InlineData("00Folder 5", "00Folder 5", 0)]
        [InlineData("00Folder 10", "00Folder 5", 1)]
        public void Compare_uses_natural_sorting_when_comparing_the_two_strings(string left, string right, int expected)
        {
            var result = new NaturalStringComparer().Compare(left, right);

            result.Should().Be(expected);
        }

        [Fact]
        public void Linq_OrderBy_using_NaturalStringComparer_orders_items_using_natural_sorting()
        {
            var input = new[]
            {
                "Folder 3",
                "Folder 13",
                "Folder 1",
                "Folder 26",
                "Folder 10",
                "Folder 6",
                "Folder 4",
                "Folder 5",
                "Folder 2",
                "00Folder 5",
                "00Folder 1",
                "00Folder 10",
            };

            var expectedOutput = new[]
            {
                "00Folder 1",
                "00Folder 5",
                "00Folder 10",
                "Folder 1",
                "Folder 2",
                "Folder 3",
                "Folder 4",
                "Folder 5",
                "Folder 6",
                "Folder 10",
                "Folder 13",
                "Folder 26",
            };

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
                "Folder 1",
                "Folder 26",
                "Folder 10",
                "Folder 6",
                "Folder 4",
                "Folder 5",
                "Folder 2",
                "00Folder 5",
                "00Folder 1",
                "00Folder 10",
            };

            var expected = new[]
            {
                "00Folder 1",
                "00Folder 5",
                "00Folder 10",
                "Folder 1",
                "Folder 2",
                "Folder 3",
                "Folder 4",
                "Folder 5",
                "Folder 6",
                "Folder 10",
                "Folder 13",
                "Folder 26",
            };

            Array.Sort(input, NaturalStringComparer.Ordinal);

            input.Should().BeEquivalentTo(expected)
                .And.ContainInOrder(expected);
        }

        [Theory]
        [InlineData("Folder", "Folder")]
        [InlineData("FolderWithLongName", "Folder")]
        [InlineData("Folder", "FolderWithLongName")]
        public void Compare_returns_difference_in_length_of_the_two_strings(string left, string right)
        {
            var result = new NaturalStringComparer().Compare(left, right);

            result.Should().Be(left.Length - right.Length);
        }

        [Fact]
        public void Can_access_singleton_instance()
        {
            NaturalStringComparer.Ordinal.Should().NotBeNull()
                .And.BeOfType<NaturalStringComparer>();
        }
    }
}
