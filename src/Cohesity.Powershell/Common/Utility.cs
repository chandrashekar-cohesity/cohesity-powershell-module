using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesity.Powershell.Common
{
    class Utility
    {
        public static List<long?> ConvertToNullableLong(long[] list)
        {
            if(null == list)
            {
                return null;
            }
            List<long> obj = new List<long>(list);
            return obj.ConvertAll<long?>(new System.Converter<long, long?>(Common.Utility.ConvertLong));
        }
        public static long? ConvertLong(long param)
        {
            return param;
        }
    }
}
