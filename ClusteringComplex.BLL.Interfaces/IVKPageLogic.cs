using ClusteringComplex.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringComplex.BLL.Interfaces
{
    public interface IVKPageLogic
    {
        IEnumerable<UserFriends> GetInfoUserFriends(VKPage page);

        InfoMapPartition BuildInfoMapPartition(VKPage vkPage);

        InfoMapPartition BuiltInfoMapPartitionContent(VKPage vkPage);

        Task<ParallelM> ShowParallel(VKPage vkPage);
    }
}
