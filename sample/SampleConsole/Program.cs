using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsortedVersions = new List<LibraryVersion>
            {
                new LibraryVersion { VersionNumber = "10.1.0" },
                new LibraryVersion { VersionNumber = "20.2.3" },
                new LibraryVersion { VersionNumber = "2.1.0" },
                new LibraryVersion { VersionNumber = "1.1.0" },
                new LibraryVersion { VersionNumber = "10.0.0" },
                new LibraryVersion { VersionNumber = "2.0.0" },
                new LibraryVersion { VersionNumber = "10.2.0" },
                new LibraryVersion { VersionNumber = "1.0.0" },
                new LibraryVersion { VersionNumber = "20.2.0" },
                new LibraryVersion { VersionNumber = "20.1.0" },
            };

            var versionsAlphabetical = unsortedVersions.OrderBy(v => v.VersionNumber);
            Console.WriteLine("Alphabetical:");

            foreach (var version in versionsAlphabetical)
            {
                Console.WriteLine($"- {version.VersionNumber}");
            }

            Console.WriteLine();

            var versionsNatural = unsortedVersions.OrderByNatural(v => v.VersionNumber);
            Console.WriteLine("Natural:");

            foreach (var version in versionsNatural)
            {
                Console.WriteLine($"- {version.VersionNumber}");
            }
        }
    }
}
