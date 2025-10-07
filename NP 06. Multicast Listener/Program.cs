using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new UdpClient(27001);
var multicastIP = IPAddress.Parse("224.0.0.1");

listener.JoinMulticastGroup(multicastIP);

var endpoint = new IPEndPoint(IPAddress.Any, 0);

var i = 0;

while (true)
{
    var receiveBuffer = listener.Receive(ref endpoint);
    var message = Encoding.UTF8.GetString(receiveBuffer);
    Console.WriteLine(message);
    Thread.Sleep(100);
    Console.Clear();
}
