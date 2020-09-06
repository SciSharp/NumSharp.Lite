using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NumSharp.Experiment
{
    public unsafe class Storage
    {
        byte[] storage;
        string dtype;
        long size;
        long byteSize;

        public Storage(string dtype, long size)
        {
            this.size = size;
            this.dtype = dtype;

            byteSize = size * sizeof(float);
            storage = new byte[byteSize];
        }

        public void Copy<T>(T[] data)
            where T: unmanaged
        {
            fixed (void* src = &data[0])
            fixed (void* dst = &storage[0])
            {
                Buffer.MemoryCopy(src, dst, byteSize, byteSize);

                // for debug
                for (int i = 0; i < data.Length; i++)
                {
                    Console.WriteLine($"copy {*((T*)dst + i)} -> {data[0]}");
                    // Debug.Assert(*((float*)dst + i) == *((float*)src + i));
                }
            }
        }

        public T[] ToArray<T>()
        {
            var data = new T[size];
            return data;
        }
    }
}
