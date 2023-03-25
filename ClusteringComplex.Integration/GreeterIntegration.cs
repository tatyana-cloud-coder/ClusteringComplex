using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringComplex.Integration
{
    public class GreeterIntegration
    {
        private const string Address = "http://localhost:50051";

        public void SendHello()
        {
            using var channel = GrpcChannel.ForAddress(Address);
            // создаем клиент
            var client = new Greeter.GreeterClient(channel);
            var reply = client.TestMethodForTatyana(new HelloRequest { Name = "Моя звать Си Шарп" });
        }

        public List<FriendInfo> GetInfoUserFriends(string login, string password, int vkid)
        {
            using var channel = GrpcChannel.ForAddress(Address);
            // создаем клиент
            var client = new Greeter.GreeterClient(channel);
            var reply = client.GetFriendsUserInfo(new VKCredentialsRequest { Login = login, Password = password, Vkid = vkid });
            return reply.Friends.ToList();
        }

        public InfomapRelationReply BuiltInfoMapPartition(string login, string password, int vkid)
        {
            using var channel = GrpcChannel.ForAddress(Address);
            // создаем клиент
            var client = new Greeter.GreeterClient(channel);
            var reply = client.BuiltInfoMapPartitionOnRelationGraph(new VKCredentialsRequest { Login = login, Password = password, Vkid = vkid });
            return reply;
        }

        public async Task BuiltInfoMapPartitionAsync(string login, string password, int vkid)
        {
            using var channel = GrpcChannel.ForAddress(Address);
            // создаем клиент
            var client = new Greeter.GreeterClient(channel);
            //тут точно тот метод вызывается?
            var reply = await client.BuiltInfoMapPartitionOnRelationGraphAsync(new VKCredentialsRequest { Login = login, Password = password, Vkid = vkid });

        }

        public InfomapContentReply BuiltInfoMapPartitionContent(string login, string password, int vkid)
        {
            using var channel = GrpcChannel.ForAddress(Address);
            // создаем клиент
            var client = new Greeter.GreeterClient(channel);
            var reply = client.BuiltInfoMapPartitionOnContentGraph(new VKCredentialsRequest { Login = login, Password = password, Vkid = vkid });
            return reply;
        }


        public async Task BuiltInfoMapPartitionContentAsync(string login, string password, int vkid)
        {
            using var channel = GrpcChannel.ForAddress(Address);
            // создаем клиент
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.BuiltInfoMapPartitionOnContentGraphAsync(new VKCredentialsRequest { Login = login, Password = password, Vkid = vkid });

        }

    }
}
