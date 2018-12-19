using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Soft_WindowsApp.Bussiness
{
    public class Sequences
    {
        public static int index = 100;
        public static int Increment()
        {
            return index++;
        }
        public static int SetIndex()
        {
            return index = 1;
        }
    }
}
