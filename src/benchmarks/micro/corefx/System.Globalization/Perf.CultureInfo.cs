// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;

namespace System.Globalization.Tests
{
    public class Perf_CultureInfo
    {
        [Benchmark]
        public CultureInfo GetCurrentCulture() => CultureInfo.CurrentCulture;

        [Benchmark]
        public CultureInfo GetInvariantCulture() => CultureInfo.InvariantCulture;
    }
}
