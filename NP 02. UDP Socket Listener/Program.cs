using System.Net.Sockets;
using System.Net;
using System.Text;

IPAddress.TryParse("127.0.0.1", out var ipAddress);

Socket listener = new(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

var connectEp = new IPEndPoint(ipAddress!, 27001);

listener.Bind(connectEp);

EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

var buffer = new byte[ushort.MaxValue];

while (true)
{
    var length = listener.ReceiveFrom(buffer, ref endPoint);
    var message = Encoding.UTF8.GetString(buffer, 0, length);
    Console.Write(message);
}

