using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new UdpClient(27001);
listener.EnableBroadcast = true;

var endpoint = new IPEndPoint(IPAddress.Any, 0);


while (true)
{
    var receiveBuffer = listener.Receive(ref endpoint);
    var message = Encoding.UTF8.GetString(receiveBuffer);
    Console.WriteLine(message);
    Thread.Sleep(100);
    Console.Clear();
}
