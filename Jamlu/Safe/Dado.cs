using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamlu.Safe
{
    public static class Dado
    {
        public static int D4(string value)
        {
            return value.SafeInt(1, 4);
        }

        public static int D6(string value)
        {
            return value.SafeInt(1, 6);
        }

        public static int D20(string value)
        {
            return value.SafeInt(1, 20);
        }
    }
}
