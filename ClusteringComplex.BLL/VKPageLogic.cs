using ClusteringComplex.BLL.Interfaces;
using ClusteringComplex.Entities;
using ClusteringComplex.Integration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClusteringComplex.BLL
{
    public class VKPageLogic: IVKPageLogic
    {
        private readonly GreeterIntegration _greeterIntegration;

        public VKPageLogic()
        {
            _greeterIntegration = new GreeterIntegration();
        }
        public IEnumerable<UserFriends> GetInfoUserFriends(VKPage vkPage)
        {
            var info = _greeterIntegration.GetInfoUserFriends(vkPage.Login, vkPage.Password, vkPage.VKId);
            var result = info.Select(x => new UserFriends
            {
                FirstName = x.FirstName,
                LastName = x.LastName
            });
            return result;
        }

        public InfoMapPartition BuildInfoMapPartition(VKPage vkPage)
        {
            var partitions = _greeterIntegration.BuiltInfoMapPartition(vkPage.Login, vkPage.Password, vkPage.VKId);
            var info = _greeterIntegration.GetInfoUserFriends(vkPage.Login, vkPage.Password, vkPage.VKId);

            var partinionsList = partitions.Partition
                .ToList()
                .Select((x, i) => new PartitionUsers
                {
                    PartitionNum = x,
                    User = new UserFriends
                    {
                        FirstName = info[i].FirstName,
                        LastName = info[i].LastName,
                    }
                })
                .ToLookup(x => x.PartitionNum)
                .ToDictionary(x => x.Key, y => y.ToList());

            var result = new InfoMapPartition
            {
                ResultModularity = partitions.ResultModularity,
                ResultTime = TimeSpan.FromSeconds(partitions.ResultTime),
                PartitionsUsers = partinionsList
            };
            return result;
        }


        public InfoMapPartition BuiltInfoMapPartitionContent (VKPage vkPage)
        {
            var partitions = _greeterIntegration.BuiltInfoMapPartitionContent(vkPage.Login, vkPage.Password, vkPage.VKId);
            var info = _greeterIntegration.GetInfoUserFriends(vkPage.Login, vkPage.Password, vkPage.VKId);

            var partinionsList = partitions.Partition
                .ToList()
                .Select((x, i) => new PartitionUsers
                {
                    PartitionNum = x,
                    User = new UserFriends
                    {
                        FirstName = info[i].FirstName,
                        LastName = info[i].LastName,
                    }
                })
                .ToLookup(x => x.PartitionNum)
                .ToDictionary(x => x.Key, y => y.ToList());

            var result = new InfoMapPartition
            {
                ResultModularity = partitions.ResultModularity,
                ResultTime = TimeSpan.FromSeconds(partitions.ResultTime),
                PartitionsUsers = partinionsList
            };
            return result;
        }

        public async Task<ParallelM> ShowParallel(VKPage vkPage)
        {
            ParallelM model = new ParallelM();
            //запускаем все три способа вычиления
            var withThreads = Task.Run(() => GetTime_withThreads(vkPage.Login, vkPage.Password, vkPage.VKId));
            var parallelViaAsyncTasks = GetTime_parallelViaAsyncTasks(vkPage.Login, vkPage.Password, vkPage.VKId);
            var withTPL = Task.Run(() => GetTime_withTPL(vkPage.Login, vkPage.Password, vkPage.VKId));
            var inline = Task.Run(() => GetTime_inline(vkPage.Login, vkPage.Password, vkPage.VKId));

            //ждем когда они все посчитаются
            await Task.WhenAll(new List<Task> { withThreads, parallelViaAsyncTasks, withTPL });

            //сохраняем время в миллисекундах
            model.TimeParallelThreads = await withThreads;
            model.TimeParalleTasks = await parallelViaAsyncTasks;
            model.TimeLibrary = await withTPL;
            model.TimeLinaer = await inline;

            return model;

        }


        private long GetTime_withThreads(string login, string password, int vkid)
        {
            var threads = new List<Thread>();
            threads.Add(new Thread(new ThreadStart(InnerFake1)));
            threads.Add(new Thread(new ThreadStart(InnerFake2)));

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var item in threads)
            {
                item.Start();
            }
            
            WaitAll(threads);
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;

            void InnerFake1()
            {
                var a = _greeterIntegration.BuiltInfoMapPartition(login, password, vkid);
            }

            void InnerFake2()
            {
                var a = _greeterIntegration.BuiltInfoMapPartitionContent(login, password, vkid);
            }
        }

        //вызываем два метода асинхронно, ждем когда оба закончатся
        private async Task<long> GetTime_parallelViaAsyncTasks(string login, string password, int vkid)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var task1 = _greeterIntegration.BuiltInfoMapPartitionAsync(login, password, vkid);
            var task2 = _greeterIntegration.BuiltInfoMapPartitionContentAsync(login, password, vkid);
            await Task.WhenAll(new List<Task> { task1, task2 });
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        //используется TaskparallelLibrary
        private long GetTime_withTPL(string login, string password, int vkid)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.Invoke(
                () => _greeterIntegration.BuiltInfoMapPartition(login, password, vkid),
                () => _greeterIntegration.BuiltInfoMapPartitionContent(login, password, vkid));
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        private long GetTime_inline(string login, string password, int vkid)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _greeterIntegration.BuiltInfoMapPartition(login, password, vkid);
            _greeterIntegration.BuiltInfoMapPartitionContent(login, password, vkid);
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        private static void WaitAll(IEnumerable<Thread> threads)
        {
            if (threads != null)
            {
                foreach (Thread thread in threads)
                {
                    thread.Join();
                }
            }
        }





    }
}
