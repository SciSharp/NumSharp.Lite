using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace NumSharp.Benchmark
{
    [SimpleJob(launchCount: 1, warmupCount: 2, targetCount: 10)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class StorageBenchmark
    {
        [Benchmark]
        public void StorageInBytes()
        {
            var bytesStorage = new byte[1024 * 1024 * 4];
        }
    }
}
