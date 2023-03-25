from google.protobuf.internal import containers as _containers
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from typing import ClassVar as _ClassVar, Iterable as _Iterable, Mapping as _Mapping, Optional as _Optional, Union as _Union

DESCRIPTOR: _descriptor.FileDescriptor

class FriendInfo(_message.Message):
    __slots__ = ["FirstName", "LastName"]
    FIRSTNAME_FIELD_NUMBER: _ClassVar[int]
    FirstName: str
    LASTNAME_FIELD_NUMBER: _ClassVar[int]
    LastName: str
    def __init__(self, FirstName: _Optional[str] = ..., LastName: _Optional[str] = ...) -> None: ...

class FriendsInfoReply(_message.Message):
    __slots__ = ["friends"]
    FRIENDS_FIELD_NUMBER: _ClassVar[int]
    friends: _containers.RepeatedCompositeFieldContainer[FriendInfo]
    def __init__(self, friends: _Optional[_Iterable[_Union[FriendInfo, _Mapping]]] = ...) -> None: ...

class FriendsInfoRequest(_message.Message):
    __slots__ = ["login", "password", "vkid"]
    LOGIN_FIELD_NUMBER: _ClassVar[int]
    PASSWORD_FIELD_NUMBER: _ClassVar[int]
    VKID_FIELD_NUMBER: _ClassVar[int]
    login: str
    password: str
    vkid: int
    def __init__(self, login: _Optional[str] = ..., password: _Optional[str] = ..., vkid: _Optional[int] = ...) -> None: ...

class HelloReply(_message.Message):
    __slots__ = ["message"]
    MESSAGE_FIELD_NUMBER: _ClassVar[int]
    message: str
    def __init__(self, message: _Optional[str] = ...) -> None: ...

class HelloRequest(_message.Message):
    __slots__ = ["name"]
    NAME_FIELD_NUMBER: _ClassVar[int]
    name: str
    def __init__(self, name: _Optional[str] = ...) -> None: ...

class InfomapContentReply(_message.Message):
    __slots__ = ["partition", "resultModularity", "resultTime", "resultTimeBuilding"]
    PARTITION_FIELD_NUMBER: _ClassVar[int]
    RESULTMODULARITY_FIELD_NUMBER: _ClassVar[int]
    RESULTTIMEBUILDING_FIELD_NUMBER: _ClassVar[int]
    RESULTTIME_FIELD_NUMBER: _ClassVar[int]
    partition: _containers.RepeatedScalarFieldContainer[int]
    resultModularity: float
    resultTime: float
    resultTimeBuilding: float
    def __init__(self, partition: _Optional[_Iterable[int]] = ..., resultTime: _Optional[float] = ..., resultTimeBuilding: _Optional[float] = ..., resultModularity: _Optional[float] = ...) -> None: ...

class InfomapContentRequest(_message.Message):
    __slots__ = ["login", "password", "vkid"]
    LOGIN_FIELD_NUMBER: _ClassVar[int]
    PASSWORD_FIELD_NUMBER: _ClassVar[int]
    VKID_FIELD_NUMBER: _ClassVar[int]
    login: str
    password: str
    vkid: int
    def __init__(self, login: _Optional[str] = ..., password: _Optional[str] = ..., vkid: _Optional[int] = ...) -> None: ...

class InfomapRelationReply(_message.Message):
    __slots__ = ["partition", "resultModularity", "resultTime"]
    PARTITION_FIELD_NUMBER: _ClassVar[int]
    RESULTMODULARITY_FIELD_NUMBER: _ClassVar[int]
    RESULTTIME_FIELD_NUMBER: _ClassVar[int]
    partition: _containers.RepeatedScalarFieldContainer[int]
    resultModularity: float
    resultTime: float
    def __init__(self, partition: _Optional[_Iterable[int]] = ..., resultTime: _Optional[float] = ..., resultModularity: _Optional[float] = ...) -> None: ...

class InfomapRelationRequest(_message.Message):
    __slots__ = ["login", "password", "vkid"]
    LOGIN_FIELD_NUMBER: _ClassVar[int]
    PASSWORD_FIELD_NUMBER: _ClassVar[int]
    VKID_FIELD_NUMBER: _ClassVar[int]
    login: str
    password: str
    vkid: int
    def __init__(self, login: _Optional[str] = ..., password: _Optional[str] = ..., vkid: _Optional[int] = ...) -> None: ...

class NewReply(_message.Message):
    __slots__ = ["fakestr", "i", "message"]
    FAKESTR_FIELD_NUMBER: _ClassVar[int]
    I_FIELD_NUMBER: _ClassVar[int]
    MESSAGE_FIELD_NUMBER: _ClassVar[int]
    fakestr: str
    i: int
    message: str
    def __init__(self, message: _Optional[str] = ..., i: _Optional[int] = ..., fakestr: _Optional[str] = ...) -> None: ...
