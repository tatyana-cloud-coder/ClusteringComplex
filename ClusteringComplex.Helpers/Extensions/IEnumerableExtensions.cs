using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringComplex.Helpers.Extensions
{
    public static class Extensions
    {
        public static List<List<T>> Split<T>(this List<T> arr, int size)
        {
            return arr.Select((s, i) => arr.Skip(i * size).Take(size).ToList()).Where(a => a.Any()).ToList();
        }
    }
}
