using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace NaturalStringExtensions.Tests
{
    public class NaturalStringComparerTests
    {
        [Fact]
        public void Compare_uses_natural_sorting_when_comparing_the_two_strings()
        {
            const string left = "Folder 10";
            const string right = "Folder 5";

            var result = new NaturalStringComparer().Compare(left, right);

            result.Should().Be(1);
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
            };

            var expectedOutput = new[]
            {
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
            NaturalStringComparer.Instance.Should().NotBeNull()
                .And.BeOfType<NaturalStringComparer>();
        }
    }
}
