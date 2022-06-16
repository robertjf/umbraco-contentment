﻿/* This Source Code has been copied from Lee Kelleher's Umbraco Polyfill library.
 * https://github.com/leekelleher/umbraco-polyfill/blob/main/src/Core/IO/IOHelperPolyfill.cs
 * Modified under the permissions of the MIT License.
 * Modifications are licensed under the Mozilla Public License.
 * Copyright © 2022 Lee Kelleher.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

#if NET472
namespace Umbraco.Core.IO
{
    internal sealed class IOHelperPolyfill : IIOHelper
    {
        public void EnsurePathExists(string path) => IOHelper.EnsurePathExists(path);

        public string FindFile(string virtualPath) => IOHelper.FindFile(virtualPath);

        public bool PathStartsWith(string path, string root, params char[] separators) => IOHelper.PathStartsWith(path, root, separators[0]);
    }
}
#endif
