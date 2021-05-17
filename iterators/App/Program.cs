using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var number in CountDown())
            {
                Console.WriteLine($"count down: {number}");
            }
        }
        
        /*
        .method private hidebysig static 
        	void Main (
        		string[] args
        	) cil managed 
        {
        	// Method begins at RVA 0x2050
        	// Code size 57 (0x39)
        	.maxstack 2
        	.entrypoint
        	.locals init (
        		[0] class [System.Runtime]System.Collections.Generic.IEnumerator`1<string>,
        		[1] string
        	)
        
        	IL_0000: call class [System.Runtime]System.Collections.Generic.IEnumerable`1<string> App.Program::CountDown()
        	IL_0005: callvirt instance class [System.Runtime]System.Collections.Generic.IEnumerator`1<!0> class [System.Runtime]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
        	IL_000a: stloc.00
        	.try
        	{
        		IL_000b: br.s IL_0024
        		// loop start (head: IL_0024)
        			IL_000d: ldloc.00
        			IL_000e: callvirt instance !0 class [System.Runtime]System.Collections.Generic.IEnumerator`1<string>::get_Current()
        			IL_0013: stloc.11
        			IL_0014: ldstr "count down: "
        			IL_0019: ldloc.11
        			IL_001a: call string [System.Runtime]System.String::Concat(string, string)
        			IL_001f: call void [System.Console]System.Console::WriteLine(string)
        
        			IL_0024: ldloc.00
        			IL_0025: callvirt instance bool [System.Runtime]System.Collections.IEnumerator::MoveNext()
        			IL_002a: brtrue.s IL_000d
        		// end loop
        
        		IL_002c: leave.s IL_0038
        	} // end .try
        	finally
        	{
        		IL_002e: ldloc.00
        		IL_002f: brfalse.s IL_0037
        
        		IL_0031: ldloc.00
        		IL_0032: callvirt instance void [System.Runtime]System.IDisposable::Dispose()
        
        		IL_0037: endfinally
        	} // end handler
        
        	IL_0038: ret
        } // end of method Program::Main        
        */
        
        static IEnumerable<string> CountDown()
        {
            Console.WriteLine(3);
            yield return "three";
            Console.WriteLine(2);
            yield return "two";
            Console.WriteLine(1);
            yield return "one";
        }
        
        /*
        .method private hidebysig static 
        	class [System.Runtime]System.Collections.Generic.IEnumerable`1<string> CountDown () cil managed 
        {
        	.custom instance void [System.Runtime]System.Runtime.CompilerServices.IteratorStateMachineAttribute::.ctor(class [System.Runtime]System.Type) = (
        		01 00 1b 41 70 70 2e 50 72 6f 67 72 61 6d 2b 3c
        		43 6f 75 6e 74 44 6f 77 6e 3e 64 5f 5f 31 00 00
        	)
        	// Method begins at RVA 0x20a8
        	// Code size 8 (0x8)
        	.maxstack 8
        
        	IL_0000: ldc.i4.s -2
        	IL_0002: newobj instance void App.Program/'_003CCountDown_003Ed__1'::.ctor(int32)
        	IL_0007: ret
        } // end of method Program::CountDown
        */
        
        /*
        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.Runtime.CompilerServices;
        
        [CompilerGenerated]
        private sealed class _003CCountDown_003Ed__1 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
        {
        	private int _003C_003E1__state;
        
        	private string _003C_003E2__current;
        
        	private int _003C_003El__initialThreadId;
        
        	string IEnumerator<string>.Current {
        		[DebuggerHidden]
        		get {
        			return _003C_003E2__current;
        		}
        	}
        
        	object IEnumerator.Current {
        		[DebuggerHidden]
        		get {
        			return _003C_003E2__current;
        		}
        	}
        
        	[DebuggerHidden]
        	public _003CCountDown_003Ed__1 (int _003C_003E1__state)
        	{
        		this._003C_003E1__state = _003C_003E1__state;
        		_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
        	}
        
        	[DebuggerHidden]
        	void IDisposable.Dispose ()
        	{
        	}
        
        	private bool MoveNext ()
        	{
        		switch (_003C_003E1__state) {
        		default:
        			return false;
        		case 0:
        			_003C_003E1__state = -1;
        			Console.WriteLine (3);
        			_003C_003E2__current = "three";
        			_003C_003E1__state = 1;
        			return true;
        		case 1:
        			_003C_003E1__state = -1;
        			Console.WriteLine (2);
        			_003C_003E2__current = "two";
        			_003C_003E1__state = 2;
        			return true;
        		case 2:
        			_003C_003E1__state = -1;
        			Console.WriteLine (1);
        			_003C_003E2__current = "one";
        			_003C_003E1__state = 3;
        			return true;
        		case 3:
        			_003C_003E1__state = -1;
        			return false;
        		}
        	}
        
        	bool IEnumerator.MoveNext ()
        	{
        		//ILSpy generated this explicit interface implementation from .override directive in MoveNext
        		return this.MoveNext ();
        	}
        
        	[DebuggerHidden]
        	void IEnumerator.Reset ()
        	{
        		throw new NotSupportedException ();
        	}
        
        	[DebuggerHidden]
        	IEnumerator<string> IEnumerable<string>.GetEnumerator ()
        	{
        		if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId) {
        			_003C_003E1__state = 0;
        			return this;
        		}
        		return new _003CCountDown_003Ed__1 (0);
        	}
        
        	[DebuggerHidden]
        	IEnumerator IEnumerable.GetEnumerator ()
        	{
        		return ((IEnumerable<string>)this).GetEnumerator ();
        	}
        }
        */
    }
}
