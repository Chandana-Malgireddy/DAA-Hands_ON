using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On4
{
    public class fibonacci
    {
       
        public fibonacci()
        {
            
            fib(5);

        }
        public static int fib(int n)
        {

            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            else
            {
                Console.WriteLine($"fib{(n - 1)}+fib{(n - 2)}",n-1,n-2);
                return fib(n - 1) + fib(n - 2);
            }
            //Call of Stack
            //fib(5)->fib(4)->fib(3)->fib(2)->fib(1)->fib(0)->fib(1)->fib(0)->fib(2)->fib(1)->fib(1)->fib(0)

        }
    }
}
