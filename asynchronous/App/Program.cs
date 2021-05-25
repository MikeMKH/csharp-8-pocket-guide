using System;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int result = await ComplexCalculationAsync();
            Console.WriteLine(result);
        }
        
        static int ComplexCalculation()
        {
            double x = 2;
            for (int i = 1; i < 100000000; i++) x += Math.Sqrt(x) + i;
            return (int) x;
        }
        
        static Task<int> ComplexCalculationAsync()
        {
            return Task.Run(() => ComplexCalculation());
        }
    }
    
    /*
    private static void _003CMain_003E (string[] args)
    {
    	Main (args).GetAwaiter ().GetResult ();
    }
    
    [Serializable]
    [CompilerGenerated]
    private sealed class _003C_003Ec
    {
    	public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec ();
    
    	public static Func<int> _003C_003E9__2_0;
    
    	internal int _003CComplexCalculationAsync_003Eb__2_0 ()
    	{
    		return ComplexCalculation ();
    	}
    }
    
    [StructLayout (LayoutKind.Auto)]
    [CompilerGenerated]
    private struct _003CMain_003Ed__0 : IAsyncStateMachine
    {
    	public int _003C_003E1__state;
    
    	public AsyncTaskMethodBuilder _003C_003Et__builder;
    
    	private TaskAwaiter<int> _003C_003Eu__1;
    
    	private void MoveNext ()
    	{
    		int num = _003C_003E1__state;
    		try {
    			TaskAwaiter<int> awaiter;
    			if (num != 0) {
    				awaiter = ComplexCalculationAsync ().GetAwaiter ();
    				if (!awaiter.IsCompleted) {
    					num = (_003C_003E1__state = 0);
    					_003C_003Eu__1 = awaiter;
    					_003C_003Et__builder.AwaitUnsafeOnCompleted (ref awaiter, ref this);
    					return;
    				}
    			} else {
    				awaiter = _003C_003Eu__1;
    				_003C_003Eu__1 = default(TaskAwaiter<int>);
    				num = (_003C_003E1__state = -1);
    			}
    			Console.WriteLine (awaiter.GetResult ());
    		} catch (Exception exception) {
    			_003C_003E1__state = -2;
    			_003C_003Et__builder.SetException (exception);
    			return;
    		}
    		_003C_003E1__state = -2;
    		_003C_003Et__builder.SetResult ();
    	}
    
    	void IAsyncStateMachine.MoveNext ()
    	{
    		//ILSpy generated this explicit interface implementation from .override directive in MoveNext
    		this.MoveNext ();
    	}
    
    	[DebuggerHidden]
    	private void SetStateMachine (IAsyncStateMachine stateMachine)
    	{
    		_003C_003Et__builder.SetStateMachine (stateMachine);
    	}
    
    	void IAsyncStateMachine.SetStateMachine (IAsyncStateMachine stateMachine)
    	{
    		//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
    		this.SetStateMachine (stateMachine);
    	}
    }
    */
}
