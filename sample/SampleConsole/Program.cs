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
