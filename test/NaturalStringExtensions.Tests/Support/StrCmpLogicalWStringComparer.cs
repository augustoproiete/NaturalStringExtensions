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

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NaturalStringExtensions.Tests.Support
{
    internal class StrCmpLogicalWStringComparer : IComparer<string?>
    {
        public StrCmpLogicalWStringComparer()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new NotSupportedException($"{nameof(StrCmpLogicalWStringComparer)} is only supported on Windows");
            }
        }

        public int Compare(string? left, string? right)
        {
            return StrCmpLogicalW(left, right);
        }

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        private static extern int StrCmpLogicalW(string? psz1, string? psz2);
    }
}
