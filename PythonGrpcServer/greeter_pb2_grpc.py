# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

import greeter_pb2 as greeter__pb2


class GreeterStub(object):
    """Missing associated documentation comment in .proto file."""

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.SayHello = channel.unary_unary(
                '/Greeter/SayHello',
                request_serializer=greeter__pb2.HelloRequest.SerializeToString,
                response_deserializer=greeter__pb2.HelloReply.FromString,
                )
        self.TestMethodForTatyana = channel.unary_unary(
                '/Greeter/TestMethodForTatyana',
                request_serializer=greeter__pb2.HelloRequest.SerializeToString,
                response_deserializer=greeter__pb2.NewReply.FromString,
                )
        self.GetFriendsUserInfo = channel.unary_unary(
                '/Greeter/GetFriendsUserInfo',
                request_serializer=greeter__pb2.FriendsInfoRequest.SerializeToString,
                response_deserializer=greeter__pb2.FriendsInfoReply.FromString,
                )
        self.BuiltInfoMapPartitionOnRelationGraph = channel.unary_unary(
                '/Greeter/BuiltInfoMapPartitionOnRelationGraph',
                request_serializer=greeter__pb2.InfomapRelationRequest.SerializeToString,
                response_deserializer=greeter__pb2.InfomapRelationReply.FromString,
                )
        self.BuiltInfoMapPartitionOnContentGraph = channel.unary_unary(
                '/Greeter/BuiltInfoMapPartitionOnContentGraph',
                request_serializer=greeter__pb2.InfomapContentRequest.SerializeToString,
                response_deserializer=greeter__pb2.InfomapContentReply.FromString,
                )


class GreeterServicer(object):
    """Missing associated documentation comment in .proto file."""

    def SayHello(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def TestMethodForTatyana(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def GetFriendsUserInfo(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def BuiltInfoMapPartitionOnRelationGraph(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def BuiltInfoMapPartitionOnContentGraph(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_GreeterServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'SayHello': grpc.unary_unary_rpc_method_handler(
                    servicer.SayHello,
                    request_deserializer=greeter__pb2.HelloRequest.FromString,
                    response_serializer=greeter__pb2.HelloReply.SerializeToString,
            ),
            'TestMethodForTatyana': grpc.unary_unary_rpc_method_handler(
                    servicer.TestMethodForTatyana,
                    request_deserializer=greeter__pb2.HelloRequest.FromString,
                    response_serializer=greeter__pb2.NewReply.SerializeToString,
            ),
            'GetFriendsUserInfo': grpc.unary_unary_rpc_method_handler(
                    servicer.GetFriendsUserInfo,
                    request_deserializer=greeter__pb2.FriendsInfoRequest.FromString,
                    response_serializer=greeter__pb2.FriendsInfoReply.SerializeToString,
            ),
            'BuiltInfoMapPartitionOnRelationGraph': grpc.unary_unary_rpc_method_handler(
                    servicer.BuiltInfoMapPartitionOnRelationGraph,
                    request_deserializer=greeter__pb2.InfomapRelationRequest.FromString,
                    response_serializer=greeter__pb2.InfomapRelationReply.SerializeToString,
            ),
            'BuiltInfoMapPartitionOnContentGraph': grpc.unary_unary_rpc_method_handler(
                    servicer.BuiltInfoMapPartitionOnContentGraph,
                    request_deserializer=greeter__pb2.InfomapContentRequest.FromString,
                    response_serializer=greeter__pb2.InfomapContentReply.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'Greeter', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class Greeter(object):
    """Missing associated documentation comment in .proto file."""

    @staticmethod
    def SayHello(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/Greeter/SayHello',
            greeter__pb2.HelloRequest.SerializeToString,
            greeter__pb2.HelloReply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def TestMethodForTatyana(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/Greeter/TestMethodForTatyana',
            greeter__pb2.HelloRequest.SerializeToString,
            greeter__pb2.NewReply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def GetFriendsUserInfo(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/Greeter/GetFriendsUserInfo',
            greeter__pb2.FriendsInfoRequest.SerializeToString,
            greeter__pb2.FriendsInfoReply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def BuiltInfoMapPartitionOnRelationGraph(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/Greeter/BuiltInfoMapPartitionOnRelationGraph',
            greeter__pb2.InfomapRelationRequest.SerializeToString,
            greeter__pb2.InfomapRelationReply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def BuiltInfoMapPartitionOnContentGraph(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/Greeter/BuiltInfoMapPartitionOnContentGraph',
            greeter__pb2.InfomapContentRequest.SerializeToString,
            greeter__pb2.InfomapContentReply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)
