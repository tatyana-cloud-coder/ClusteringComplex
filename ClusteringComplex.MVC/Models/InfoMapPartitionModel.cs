using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClusteringComplex.MVC.Models
{
    public class InfoMapPartitionModel
    {
        public Dictionary<int, List<PartitionUsersModel>> PartitionsUsers { get; set; }
        public List<List<int>> Partitions { get; set; }
        public double ResultModularity { get; set; }
        public TimeSpan ResultTime { get; set; }

        public TimeSpan ResultTimeBuilding { get; set; }
    }

    public class PartitionUsersModel
    {
        public int PartitionNum { get; set; }
        public UserFriendsModel User { get; set; }
    }
}
