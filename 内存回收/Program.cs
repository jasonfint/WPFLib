using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 内存回收
{
    class Program
    {

        static void DisplayMemory()
        {
            Console.WriteLine("Total memory: {0:###,###,###,##0} bytes", GC.GetTotalMemory(true));
        }
        static void Main(string[] args)
        {
            DisplayMemory();
            Console.WriteLine();
            TestClassHasEvent hasevent = new TestClassHasEvent();
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("--- New Listener #{0} ---", i + 1);
                var listener = new TestListener(hasevent);
                //var listener = new TestListener(new TestClassHasEvent());
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                DisplayMemory();

            }
            Console.Read();
        }
    }
}
