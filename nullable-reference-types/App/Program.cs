using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            string mike = "Mike";
            SafeHello(mike);
            
            #nullable enable
            string? kelsey = "Kelsey";
            SafeHello(kelsey);
            
            string? nil = null;
            SafeHello(nil);
            #nullable disable
        }
        
        static void SafeHello(string s)
        {
          if(s is null)
            Console.WriteLine($"Hello no one");
          else
            Console.WriteLine($"Hello {s}");
        }
    }
    
    /*
    using System;
    
    internal class Program
    {
    	private static void Main (string[] args)
    	{
    		SafeHello ("Mike");
    		SafeHello ("Kelsey");
    		SafeHello (null);
    	}
    
    	private static void SafeHello (string s)
    	{
    		if (s == null) {
    			Console.WriteLine ("Hello no one");
    		} else {
    			Console.WriteLine ("Hello " + s);
    		}
    	}
    }
    */
    
    /*
    .class private auto ansi beforefieldinit App.Program
    	extends [System.Runtime]System.Object
    {
    	// Methods
    	.method private hidebysig static 
    		void Main (
    			string[] args
    		) cil managed 
    	{
    		// Method begins at RVA 0x2050
    		// Code size 27 (0x1b)
    		.maxstack 8
    		.entrypoint
    
    		IL_0000: ldstr "Mike"
    		IL_0005: call void App.Program::SafeHello(string)
    		IL_000a: ldstr "Kelsey"
    		IL_000f: call void App.Program::SafeHello(string)
    		IL_0014: ldnull
    		IL_0015: call void App.Program::SafeHello(string)
    		IL_001a: ret
    	} // end of method Program::Main
    
    	.method private hidebysig static 
    		void SafeHello (
    			string s
    		) cil managed 
    	{
    		// Method begins at RVA 0x206c
    		// Code size 31 (0x1f)
    		.maxstack 8
    
    		IL_0000: ldarg.00
    		IL_0001: brtrue.s IL_000e
    
    		IL_0003: ldstr "Hello no one"
    		IL_0008: call void [System.Console]System.Console::WriteLine(string)
    		IL_000d: ret
    
    		IL_000e: ldstr "Hello "
    		IL_0013: ldarg.00
    		IL_0014: call string [System.Runtime]System.String::Concat(string, string)
    		IL_0019: call void [System.Console]System.Console::WriteLine(string)
    		IL_001e: ret
    	} // end of method Program::SafeHello
    
    	.method public hidebysig specialname rtspecialname 
    		instance void .ctor () cil managed 
    	{
    		// Method begins at RVA 0x208c
    		// Code size 7 (0x7)
    		.maxstack 8
    
    		IL_0000: ldarg.00
    		IL_0001: call instance void [System.Runtime]System.Object::.ctor()
    		IL_0006: ret
    	} // end of method Program::.ctor
    
    } // end of class App.Program
    */
}
