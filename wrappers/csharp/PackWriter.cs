// Copyright 2021-2023 Nikita Fediuchin. All rights reserved.
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

using System;
using System.Runtime.InteropServices;

namespace Pack
{
    public static class PackWriter
    {
        [DllImport(Pack.Lib)] private static extern PackResult packFiles(
            string packPath, ulong fileCount, string[] fileItemPaths, bool printProgress);

        public static PackResult PackFiles( string packPath,
            string[] fileItemPaths, bool printProgress = false)
        {
            if (string.IsNullOrEmpty(packPath))
                throw new ArgumentNullException(nameof(packPath));
            if (fileItemPaths.Length == 0)
                throw new ArgumentNullException(nameof(fileItemPaths));
            return packFiles(packPath, (ulong)fileItemPaths.Length / 2, fileItemPaths, printProgress);
        }
    }
}