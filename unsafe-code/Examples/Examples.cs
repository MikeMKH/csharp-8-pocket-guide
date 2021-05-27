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
            DisplayAsBytes((byte*)&x);
            x = 43;
            Console.WriteLine($"x={x} location={(int) p}");
            DisplayAsBytes((byte*)&x);
            Assert.Equal(43, x);
            
            void DisplayAsBytes(byte* p)
            {
                for(int i = 0; i < sizeof(int); i++)
                {
                    Console.Write($"{*p:X2} ");
                    p++;
                }
                Console.WriteLine();
            }
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(25)]
        [InlineData(4243)]
        public unsafe void UnsafeSquare(int x)
        {
            int p = x;
            UnsafeSquare(&p);
            Assert.Equal(x * x, p);
            
            void UnsafeSquare(int* n)
            {
                *n *= *n;
            }
        }
        
        [Fact]
        public unsafe void FixedExample()
        {
            var values = new[] { 1, 2, 3, 4, 5 };
            var length = values.Length;
            
            int sum = 0;
            fixed(int* pointer = &values[0])
            {
                int* p = pointer; // pointer is fixed and cannot be changed
                for(int i = 0; i < length; i++)
                {
                    sum += *p;
                    p += 1;
                }
            }
            
            Assert.Equal(15, sum);
        }
    }
}
