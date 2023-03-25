using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringComplex.Entities
{
   public class InfoMapPartition
    {
        public Dictionary<int, List<PartitionUsers>> PartitionsUsers { get; set; }
        public List<List<int>> Partitions { get; set; }
        public double ResultModularity { get; set; }
        public TimeSpan ResultTime { get; set; }

        public TimeSpan ResultTimeBuilding { get; set; }

    }
}
