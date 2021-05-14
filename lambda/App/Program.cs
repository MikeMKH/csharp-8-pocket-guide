using System;

namespace App
{
    class Program
    {
        delegate string Greet(string message);
        
        static void Main(string[] args)
        {
            Greet delegateGreet = s => $"delegate: Hello {s}";
            Func<string, string> funcGreet = s => $"func: Hello {s}";
            var captured = "func with captured";
            Func<string, string> funcWithCapturedGreet = s => $"{captured}: Hello {s}";
            
            Console.WriteLine(delegateGreet("as argument"));
            var delegateVariable = delegateGreet("as variable");
            Console.WriteLine(delegateVariable);
            
            Console.WriteLine(funcGreet("as argument"));
            var funcVariable = funcGreet("as variable");
            Console.WriteLine(funcVariable);
            
            Console.WriteLine(funcWithCapturedGreet("as argument"));
            var funcWithCapturedVariable = funcWithCapturedGreet("as variable");
            Console.WriteLine(funcWithCapturedVariable);
        }
    }
    
    /*
    internal class Program
    {
    	private delegate string Greet (string message);
    
    	private static void Main (string[] args)
    	{
    		Greet obj = (string s) => "delegate: Hello " + s;
    		Func<string, string> func = (string s) => "func: Hello " + s;
    		string captured = "func with captured";
    		Func<string, string> func2 = (string s) => captured + ": Hello " + s;
    		Console.WriteLine (obj ("as argument"));
    		Console.WriteLine (obj ("as variable"));
    		Console.WriteLine (func ("as argument"));
    		Console.WriteLine (func ("as variable"));
    		Console.WriteLine (func2 ("as argument"));
    		Console.WriteLine (func2 ("as variable"));
    	}
    }
    
    [Serializable]
    [CompilerGenerated]
    private sealed class _003C_003Ec
    {
    	public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec ();
    
    	public static Greet _003C_003E9__1_0;
    
    	public static Func<string, string> _003C_003E9__1_1;
    
    	internal string _003CMain_003Eb__1_0 (string s)
    	{
    		return "delegate: Hello " + s;
    	}
    
    	internal string _003CMain_003Eb__1_1 (string s)
    	{
    		return "func: Hello " + s;
    	}
    }
    
    [CompilerGenerated]
    private sealed class _003C_003Ec__DisplayClass1_0
    {
    	public string captured;
    
    	internal string _003CMain_003Eb__2 (string s)
    	{
    		return captured + ": Hello " + s;
    	}
    }
    */
    
    /*
    .method private hidebysig static 
    	void Main (
    		string[] args
    	) cil managed 
    {
    	// Method begins at RVA 0x2050
    	// Code size 189 (0xbd)
    	.maxstack 3
    	.entrypoint
    	.locals init (
    		[0] class App.Program/'<>c__DisplayClass1_0',
    		[1] class [System.Runtime]System.Func`2<string, string>,
    		[2] class [System.Runtime]System.Func`2<string, string>
    	)
    
    	IL_0000: newobj instance void App.Program/'<>c__DisplayClass1_0'::.ctor()
    	IL_0005: stloc.00
    	IL_0006: ldsfld class App.Program/Greet App.Program/'<>c'::'<>9__1_0'
    	IL_000b: dup
    	IL_000c: brtrue.s IL_0025
    
    	IL_000e: pop
    	IL_000f: ldsfld class App.Program/'<>c' App.Program/'<>c'::'<>9'
    	IL_0014: ldftn instance string App.Program/'<>c'::'<Main>b__1_0'(string)
    	IL_001a: newobj instance void App.Program/Greet::.ctor(object, native int)
    	IL_001f: dup
    	IL_0020: stsfld class App.Program/Greet App.Program/'<>c'::'<>9__1_0'
    
    	IL_0025: ldsfld class [System.Runtime]System.Func`2<string, string> App.Program/'<>c'::'<>9__1_1'
    	IL_002a: dup
    	IL_002b: brtrue.s IL_0044
    
    	IL_002d: pop
    	IL_002e: ldsfld class App.Program/'<>c' App.Program/'<>c'::'<>9'
    	IL_0033: ldftn instance string App.Program/'<>c'::'<Main>b__1_1'(string)
    	IL_0039: newobj instance void class [System.Runtime]System.Func`2<string, string>::.ctor(object, native int)
    	IL_003e: dup
    	IL_003f: stsfld class [System.Runtime]System.Func`2<string, string> App.Program/'<>c'::'<>9__1_1'
    
    	IL_0044: stloc.11
    	IL_0045: ldloc.00
    	IL_0046: ldstr "func with captured"
    	IL_004b: stfld string App.Program/'<>c__DisplayClass1_0'::captured
    	IL_0050: ldloc.00
    	IL_0051: ldftn instance string App.Program/'<>c__DisplayClass1_0'::'<Main>b__2'(string)
    	IL_0057: newobj instance void class [System.Runtime]System.Func`2<string, string>::.ctor(object, native int)
    	IL_005c: stloc.22
    	IL_005d: dup
    	IL_005e: ldstr "as argument"
    	IL_0063: callvirt instance string App.Program/Greet::Invoke(string)
    	IL_0068: call void [System.Console]System.Console::WriteLine(string)
    	IL_006d: ldstr "as variable"
    	IL_0072: callvirt instance string App.Program/Greet::Invoke(string)
    	IL_0077: call void [System.Console]System.Console::WriteLine(string)
    	IL_007c: ldloc.11
    	IL_007d: ldstr "as argument"
    	IL_0082: callvirt instance !1 class [System.Runtime]System.Func`2<string, string>::Invoke(!0)
    	IL_0087: call void [System.Console]System.Console::WriteLine(string)
    	IL_008c: ldloc.11
    	IL_008d: ldstr "as variable"
    	IL_0092: callvirt instance !1 class [System.Runtime]System.Func`2<string, string>::Invoke(!0)
    	IL_0097: call void [System.Console]System.Console::WriteLine(string)
    	IL_009c: ldloc.22
    	IL_009d: ldstr "as argument"
    	IL_00a2: callvirt instance !1 class [System.Runtime]System.Func`2<string, string>::Invoke(!0)
    	IL_00a7: call void [System.Console]System.Console::WriteLine(string)
    	IL_00ac: ldloc.22
    	IL_00ad: ldstr "as variable"
    	IL_00b2: callvirt instance !1 class [System.Runtime]System.Func`2<string, string>::Invoke(!0)
    	IL_00b7: call void [System.Console]System.Console::WriteLine(string)
    	IL_00bc: ret
    } // end of method Program::Main
    */
}
