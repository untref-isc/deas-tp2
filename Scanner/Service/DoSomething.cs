using Model;
using Repository;
using System.Runtime.CompilerServices;

namespace Service
{
    public class DoSomething
    {
        private Metric1Repository _repository;

        public DoSomething()
        {
            this._repository = new Metric1Repository();
        }

        public async Task<DoSomethingResult> CalculateAsync()
        {
            DoSomethingResult result = new DoSomethingResult();

            foreach (Metric1 item in await this._repository.GetAllAsync())
            {
                result.List.Add(item.Name);
            }

            return result;
        }
    }
}