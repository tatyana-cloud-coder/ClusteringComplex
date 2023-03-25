from concurrent import futures
import logging

#Импорты для работы GRPC
import grpc
import greeter_pb2
import greeter_pb2_grpc

#Импорты для питонячих скриптов
import sys
import numpy as np
import math
from igraph import Graph
import networkx as nx
import time
import community as community_louvain
#import community.community_louvain as louvain
import networkx.algorithms.community as nx_comm
import vk_api
import json
import requests
import random
from sklearn.metrics.cluster import normalized_mutual_info_score as mi

#Класс на основе .proto-файла (контракта)
class Greeter(greeter_pb2_grpc.GreeterServicer):

    def SayHello(self, request, context):
        print("Принял приветик от " + request.name)
        return greeter_pb2.HelloReply(message='Hello, %s!' % request.name)

    def TestMethodForTatyana(self, request, context):
        print("Принял приветик от Татьяны " + request.name)
        return greeter_pb2.NewReply(message='Hello2, %s!' % request.name, i = 5, fakestr='ffffff')

    def GetFriendsUserInfo (self, request, context):
         friends_list = VKAlgorithms.getInfoUserFriendsAlgorithm (request.login, request.password, request.vkid)
         reply = greeter_pb2.FriendsInfoReply()
         for item in friends_list:
            reply.friends.append(item.MapToFriendInfoMessage())
         return reply
    
    def BuiltInfoMapPartitionOnRelationGraph(self, request, context):
        resultPartition, resultTime, resultModularity = VKAlgorithms.buildInfomapPartitionFriendsRelation (request.login, request.password, request.vkid)
        return greeter_pb2.InfomapRelationReply(partition = resultPartition, resultTime = resultTime, resultModularity = resultModularity);

    def BuiltInfoMapPartitionOnContentGraph(self, request, context):
        resultPartition, resultTime, resultTimeBuilding, resultModularity = VKAlgorithms.buildInfomapPartitionFriendsContent (request.login, request.password, request.vkid)
        return greeter_pb2.InfomapContentReply(partition = resultPartition, resultTime = resultTime, resultTimeBuilding = resultTimeBuilding, resultModularity = resultModularity);

class VKWorker:
    #Авторизация vk
    def AuthVK(login, password):
        vk_session = vk_api.VkApi(login, password)
        try:
            vk_session.auth(token_only=True)
            return vk_session.get_api() 
        except vk_api.AuthError as error_msg:
            print(error_msg)
            return
    #Получение информации о друзьях пользователя
    def getUserFriendsInfo(api, userId):
        friends_list = []
        #res = ""
        users = api.users.get(user_ids = api.friends.get(user_id = userId)['items'])
        for i in range(len(users)):
            friends_list.append(Friend(users[i]['first_name'], users[i]['last_name']))
            #res += str(i) + " - " + str(users[i]['first_name']) + " " + str(users[i]['last_name'] + "/n")
        return friends_list
    #получение словаря - (номер вершины, друг)
    def getFriendsDict(api, userId):
        friends_dict = dict()
        friends_list = api.friends.get(user_id = userId)['items']
        id = 0
        for item in friends_list:
            friends_dict[id] = item 
            id += 1
        return friends_dict
 
class GraphWorker:
    #получение графа контента - подписка на одно сообщество
    def getContentGraph(api, vertices_dict, library):
      if (library == 0):
         #инициализируем граф
         g = Graph (directed = False)
         subscribes = dict()
         myList = vertices_dict.keys()
         #добавляем все вершины
         for item in myList:
           g.add_vertices(1)
           try:
             subscribes[item] = set(api.users.getSubscriptions(user_id = vertices_dict[item])['groups']['items'])
           except vk_api.ApiError:
             print("Пользователь с ID" + str(vertices_dict[item]) + "закрыт!")
             subscribes[item] = set()
         for i in range(len(myList)):
           for j in range (i+1, len(myList)):
             if (len(subscribes[i].intersection(subscribes[j]))>0):
               g.add_edge(i,j)
      elif library ==1:
         curvertex = 0
         subscribes = dict()
         myList = vertices_dict.keys()
         g = nx.Graph()
         #добавляем все вершины
         for item in myList:
           g.add_node(curvertex)
           curvertex += 1
           try:
             subscribes[item] = set(api.users.getSubscriptions(user_id = vertices_dict[item])['groups']['items'])
           except vk_api.ApiError:
             print("Пользователь с ID" + str(vertices_dict[item]) + "закрыт!")
             subscribes[item] = set()
         for i in range(len(myList)):
           for j in range (i+1, len(myList)):
             if (len(subscribes[i].intersection(subscribes[j]))>0):
               g.add_edge(i,j)
      else:
        return None
      return g
    #получение графа связей - дружба
    def getRelationShipGraph(api, vertices_dict, library):
      if (library == 0):
         g = Graph(directed  =False)
         used = dict()
         for item in vertices_dict.keys():
           g.add_vertices(1)
           used[item] = False
         for item in vertices_dict.keys():
           try:
             friends = api.friends.get(user_id = vertices_dict[item])['items']
           except vk_api.ApiError:
             print("Страница пользователя с id ", vertices_dict[item] ,"недоступна")
             continue
           for jtem in vertices_dict.keys():
             if (not used[jtem] and item != jtem and vertices_dict[jtem] in friends):
               g.add_edge (item, jtem)
           used[item] = True
      elif (library == 1):
        curvertex = 0
        g = nx.Graph()
        used = dict()
        for item in vertices_dict.keys():
          g.add_node(curvertex)
          used[item] = False
          curvertex += 1
        for item in vertices_dict.keys():
          try:
            friends = api.friends.get(user_id = vertices_dict[item])['items']
          except vk_api.ApiError:
            print("Страница пользователя с id ", vertices_dict[item] ,"недоступна")
            continue
          for jtem in vertices_dict.keys():
            if (not used[jtem] and item != jtem and vertices_dict[jtem] in friends):
              g.add_edge (item, jtem)
          used[item] = True
      else:
        return None
      return g 
   



class VKAlgorithms:
    def getInfoUserFriendsAlgorithm (login, password, vkid):
        api = VKWorker.AuthVK(login, password)
        return VKWorker.getUserFriendsInfo(api, vkid)
    def buildInfomapPartitionFriendsRelation (login, password, vkid):
        api = VKWorker.AuthVK(login, password)
        vertices_dict = VKWorker.getFriendsDict (api, vkid)
        relationGraph = GraphWorker.getRelationShipGraph(api, vertices_dict, 0)
        start = time.time()
        infoMap = relationGraph.community_infomap()
        resultTime = time.time() - start
        resultPartition = infoMap.membership
        resultModularity = relationGraph.modularity(infoMap)
        return resultPartition, resultTime, resultModularity
    def buildInfomapPartitionFriendsContent (login, password, vkid):
        api = VKWorker.AuthVK(login, password)
        vertices_dict = VKWorker.getFriendsDict (api, vkid)
        start = time.time()
        contentGraph = GraphWorker.getContentGraph(api, vertices_dict, 0)
        resultTimeBuilding = time.time() - start
        start = time.time()
        infoMap = contentGraph.community_infomap()
        resultTime = time.time() - start
        resultPartition = infoMap.membership
        resultModularity = contentGraph.modularity(infoMap)
        return resultPartition, resultTime, resultTimeBuilding, resultModularity

class Friend(object):
    def __init__(self, firstName, lastName):
        self.firstName = firstName
        self.lastName = lastName

    def MapToFriendInfoMessage(self):
        return greeter_pb2.FriendInfo(FirstName = self.firstName, LastName = self.lastName)





#Запуск серера на порту 50051
def serve():
    port = '50051'
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    greeter_pb2_grpc.add_GreeterServicer_to_server(Greeter(), server)
    server.add_insecure_port('[::]:' + port)
    print("Server started, listening on " + port)
    server.start()
    server.wait_for_termination()

#Типа метод Main
if __name__ == '__main__':
    logging.basicConfig()
    serve()