using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanEcoModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean MyOcean = new Ocean();
            MyOcean.inizialize();
            MyOcean.run();

        }
    }
}
