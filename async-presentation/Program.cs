using System;
using System.Net;
using System.Threading.Tasks;

namespace async_presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() => MainAsync(args)).Result;
        }

        static async Task<string> MainAsync(string[] args)
        {
            var ipHostEntry = await MyAsyncMethod();

            return "";
        }

        static Task<IPHostEntry> MyAsyncMethod()
        {
            var tcs = new TaskCompletionSource<IPHostEntry>();

            Dns.BeginGetHostEntry("http://google.com", asyncResult => {
                try
                {
                    IPHostEntry result = Dns.EndGetHostEntry(asyncResult);
                    tcs.SetResult(result);
                }
                catch(Exception ex)
                {
                    tcs.SetException(ex);
                }
            }, null);

            return tcs.Task;
        }
    }
}
