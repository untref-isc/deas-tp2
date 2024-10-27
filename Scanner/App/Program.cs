using Repository;
using Service;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = ShowAsync();
        }

        private static async Task ShowAsync()
        {
            try
            {
                await new Data().LoadAsync();
                DoSomethingResult result = await new DoSomething().CalculateAsync();

                foreach (string item in result.List)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}