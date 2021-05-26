using System;
using Xunit;

/*
  add to <PropertyGroup> <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
*/

namespace Examples
{
    public class Examples
    {
       
        [Fact]
        public unsafe void StackallocExample()
        {
            int* p = stackalloc int [1];
            for(int i = 0; i < 10; i++)
            {
              Console.Write($"{(char) p[i]}"); // spy
            }
            Console.WriteLine();
            
            *p = 10;
            Assert.Equal(10, p[0]);
        }
        
        [Fact]
        public unsafe void PointerExample()
        {
            int x = 42;
            int* p = &x;
            Console.WriteLine($"x={x} location={(int) p}");
            x = 43;
            Console.WriteLine($"x={x} location={(int) p}");
            Assert.Equal(43, x);
        }
    }
}
