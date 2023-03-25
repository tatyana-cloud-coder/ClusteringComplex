using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringComplex.Entities
{
    public class ParallelM
    {
        public long TimeLinaer { get; set; }
        public long TimeLibrary { get; set; }

        public long TimeParalleTasks { get; set; }


        public long TimeParallelThreads { get; set; }
    }
}
