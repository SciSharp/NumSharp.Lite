using System;
using System.Diagnostics;

namespace NumSharp.Experiment
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            var int32 = new float[] { 32, 64, 128, 256, 512, 1024 };
            var float32 = new float[] { 32.0f, 64.0f, 128.0f, 256.0f, 512.0f, 1024.0f };

            // allocate memory in bytes
            var storage = new Storage("float32", float32.Length);

            // copy data to storage
            storage.Copy(float32);
            storage.Copy(int32);


            Console.ReadLine();
        }
    }
}
