using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    static class IEnumeratorExtensions
    {
        /// <summary>
        /// Calls MoveNext() and then returns Current.
        /// </summary>
        /// <returns></returns>
        public static T ReadNext<T>(this IEnumerator<T> instance)
        {
            instance.MoveNext();
            return instance.Current;
        }
    }
}
