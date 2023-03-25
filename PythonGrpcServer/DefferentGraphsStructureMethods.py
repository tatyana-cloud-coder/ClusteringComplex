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


class DefferentGraphsStructureMethods(object):
    '''получение графа связей - дружба'''
    def getRelationShipGraph(api, vertices_dict, library):
      if (library == 0):
         g = Graph(directed  =False)
         used = dict()
         for item in vertices_dict.keys():
           g.add_vertices(1)
           used[item] = False
         for item in vertices_dict.keys():
           try:
             friends = getFriendsIDs(api, vertices_dict[item])
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
            friends = getFriendsIDs(api, vertices_dict[item])
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
    
  
    '''получение графа контента - подписка на одно сообщество'''
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
 

    def getInteractionGraph(api, vertices_dict, library):
      if (library == 0):
        g = Graph (directed = False)
        UsersUsersDict =  dict()
        for item in vertices_dict.keys():
          g.add_vertices(1)
          try:
            userPosts = api.wall.get(owner_id = vertices_dict[item])['items']
            jsonStr = json.dumps(userPosts)
            vkPosts = json.loads(jsonStr)
            userLikes = set()
            for vkPost in vkPosts:
              userLikes = userLikes.union(set(api.likes.getList(type = 'post', item_id =vkPost['id'], owner_id = vertices_dict[item], friends_only = 1)['items']))
            UsersUsersDict[vertices_dict[item]] = userLikes
          except vk_api.ApiError:
            print ("Пользователь с ID" + str(vertices_dict[item]) + "недоступен!")
            UsersUsersDict[vertices_dict[item]] = set()
            continue
        for i in range (len(vertices_dict)):
          for j in range (i+1, len(vertices_dict)):
            if (vertices_dict[j] in UsersUsersDict[vertices_dict[i]]):
              g.add_edge(i, j)
      elif (library ==1):
        g = nx.Graph()
        curvertex = 0
        UsersUsersDict =  dict()
        for item in vertices_dict.keys():
          g.add_node(curvertex)
          curvertex +=1
          try:
            userPosts = api.wall.get(owner_id = vertices_dict[item])['items']
            jsonStr = json.dumps(userPosts)
            vkPosts = json.loads(jsonStr)
            userLikes = set()
            UsersUsersDict[vertices_dict[item]] = userLikes
            for vkPost in vkPosts:
              userLikes = userLikes.union(set(api.likes.getList(type = 'post', item_id =vkPost['id'], owner_id = vertices_dict[item], friends_only = 1)['items']))
              UsersUsersDict[vertices_dict[item]] = userLikes
          except vk_api.ApiError:
            print ("Пользователь с ID" + str(vertices_dict[item]) + "недоступен!")
            UsersUsersDict[vertices_dict[item]] = set()
            continue
        for i in range (len(vertices_dict)):
          for j in range (i+1, len(vertices_dict)):
            if (vertices_dict[j] in UsersUsersDict[vertices_dict[i]]):
              g.add_edge(i, j)
      return g


