using System;
using System.Threading.Tasks;

namespace AsyncAwaitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() => MainAsync(args)).Result;
        }


        static async Task<string> MainAsync(string[] args)
        {
            try
            {
                Task task = GetAsync("");

                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        static async Task GetAsync(string url)
        {
            await Task.Delay(100);
            throw new Exception();
        }
    }
}
