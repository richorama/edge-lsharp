using LSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class EdgeCompiler
{
    public Func<object, Task<object>> CompileFunc(IDictionary<string, object> parameters)
    {
        var command = ((string)parameters["source"]).Trim();
        if (command.ToLower().EndsWith(".ls"))
        {
            command = File.ReadAllText(command);
        }

        var runtime = new Runtime(System.Console.In, System.Console.Out, System.Console.Error);
        var result = runtime.EvalStrings(command);

        return (dynamic context) => {
            // eval returned a value, so return it
            if (!(result is Function)) return Task.FromResult(result);
             
            // eval retuned a fucntion, so execute in a new thread
            var tcs = new TaskCompletionSource<object>();
            var ts = new ThreadStart(() => 
            {
                tcs.SetResult((result as Function).Call(context));
            });
            new Thread(ts).Start();
            return tcs.Task;
        };
    }
}
