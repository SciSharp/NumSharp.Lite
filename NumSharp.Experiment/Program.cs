using System;
using System.Diagnostics;

namespace NumSharp.Experiment
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            var data = new float[] { 32, 64, 128, 256, 512 };

            // allocate memory in bytes
            var byteSize = data.Length * sizeof(float);
            var storage = new byte[byteSize];

            // copy data to storage
            fixed (void* src = &data[0])
            fixed (void* dst = &storage[0])
            {
                Buffer.MemoryCopy(src, dst, byteSize, byteSize);

                for(int i = 0; i< data.Length; i++)
                {
                    Debug.Assert(*((float*)dst + i) == data[i]);
                }
                    
            }

            Console.ReadLine();
        }
    }
}
