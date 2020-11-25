using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace lab_16
{
    class Eratosfen
    {
        private List<int> simple;
        private CancellationToken _token;
 
        public Eratosfen(int MaxNumber)
        {
            this._token = _token;
            simple = new List<int>();
            for (int i = 1; i < MaxNumber; i++)
                simple.Add(i);
            DoEratosfen();
        }
 
        int Step(int Prime, int startFrom)
        {
            int i = startFrom+1;
            int Removed = 0;
            while (i < simple.Count)
                if (simple[i] % Prime == 0)
                {
                    simple.RemoveAt(i);
                    Removed++;
                }
                else
                    i++;
            return Removed;
        }
 
        public List<int> DoEratosfen()
        {
            int i=1;
            while (i < simple.Count)
            {
                Step(simple[i], i);
                i++;
            }

            return simple;
        }

        public async Task<List<int>> DoEratosfenAsync()
        {
            return await Task.Run(() => DoEratosfen());
        }
 
        public List<int> Simple
        {
            get
            {
                return simple;
            }
        }
 
    }
}