# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: greeter.proto
"""Generated protocol buffer code."""
from google.protobuf.internal import builder as _builder
from google.protobuf import descriptor as _descriptor
from google.protobuf import descriptor_pool as _descriptor_pool
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(b'\n\rgreeter.proto\"\x1c\n\x0cHelloRequest\x12\x0c\n\x04name\x18\x01 \x01(\t\"\x1d\n\nHelloReply\x12\x0f\n\x07message\x18\x01 \x01(\t\"7\n\x08NewReply\x12\x0f\n\x07message\x18\x01 \x01(\t\x12\t\n\x01i\x18\x02 \x01(\x05\x12\x0f\n\x07\x66\x61kestr\x18\x03 \x01(\t\"C\n\x12\x46riendsInfoRequest\x12\r\n\x05login\x18\x01 \x01(\t\x12\x10\n\x08password\x18\x02 \x01(\t\x12\x0c\n\x04vkid\x18\x03 \x01(\x05\"0\n\x10\x46riendsInfoReply\x12\x1c\n\x07\x66riends\x18\x01 \x03(\x0b\x32\x0b.FriendInfo\"1\n\nFriendInfo\x12\x11\n\tFirstName\x18\x01 \x01(\t\x12\x10\n\x08LastName\x18\x02 \x01(\t\"G\n\x16InfomapRelationRequest\x12\r\n\x05login\x18\x01 \x01(\t\x12\x10\n\x08password\x18\x02 \x01(\t\x12\x0c\n\x04vkid\x18\x03 \x01(\x05\"W\n\x14InfomapRelationReply\x12\x11\n\tpartition\x18\x01 \x03(\x05\x12\x12\n\nresultTime\x18\x02 \x01(\x01\x12\x18\n\x10resultModularity\x18\x03 \x01(\x01\"F\n\x15InfomapContentRequest\x12\r\n\x05login\x18\x01 \x01(\t\x12\x10\n\x08password\x18\x02 \x01(\t\x12\x0c\n\x04vkid\x18\x03 \x01(\x05\"r\n\x13InfomapContentReply\x12\x11\n\tpartition\x18\x01 \x03(\x05\x12\x12\n\nresultTime\x18\x02 \x01(\x01\x12\x1a\n\x12resultTimeBuilding\x18\x03 \x01(\x01\x12\x18\n\x10resultModularity\x18\x04 \x01(\x01\x32\xd8\x02\n\x07Greeter\x12(\n\x08SayHello\x12\r.HelloRequest\x1a\x0b.HelloReply\"\x00\x12\x32\n\x14TestMethodForTatyana\x12\r.HelloRequest\x1a\t.NewReply\"\x00\x12>\n\x12GetFriendsUserInfo\x12\x13.FriendsInfoRequest\x1a\x11.FriendsInfoReply\"\x00\x12X\n$BuiltInfoMapPartitionOnRelationGraph\x12\x17.InfomapRelationRequest\x1a\x15.InfomapRelationReply\"\x00\x12U\n#BuiltInfoMapPartitionOnContentGraph\x12\x16.InfomapContentRequest\x1a\x14.InfomapContentReply\"\x00\x62\x06proto3')

_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, globals())
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'greeter_pb2', globals())
if _descriptor._USE_C_DESCRIPTORS == False:

  DESCRIPTOR._options = None
  _HELLOREQUEST._serialized_start=17
  _HELLOREQUEST._serialized_end=45
  _HELLOREPLY._serialized_start=47
  _HELLOREPLY._serialized_end=76
  _NEWREPLY._serialized_start=78
  _NEWREPLY._serialized_end=133
  _FRIENDSINFOREQUEST._serialized_start=135
  _FRIENDSINFOREQUEST._serialized_end=202
  _FRIENDSINFOREPLY._serialized_start=204
  _FRIENDSINFOREPLY._serialized_end=252
  _FRIENDINFO._serialized_start=254
  _FRIENDINFO._serialized_end=303
  _INFOMAPRELATIONREQUEST._serialized_start=305
  _INFOMAPRELATIONREQUEST._serialized_end=376
  _INFOMAPRELATIONREPLY._serialized_start=378
  _INFOMAPRELATIONREPLY._serialized_end=465
  _INFOMAPCONTENTREQUEST._serialized_start=467
  _INFOMAPCONTENTREQUEST._serialized_end=537
  _INFOMAPCONTENTREPLY._serialized_start=539
  _INFOMAPCONTENTREPLY._serialized_end=653
  _GREETER._serialized_start=656
  _GREETER._serialized_end=1000
# @@protoc_insertion_point(module_scope)
