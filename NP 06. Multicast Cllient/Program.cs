using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();

client.MulticastLoopback = true;

var ip = IPAddress.Parse("224.0.0.1");
var endPoint = new IPEndPoint(ip, 27001);

List<string> messages = [
    @"/\________",
    @"_/\____/\_",
    @"__/\______",
    @"___/\_____",
    @"____/\____",
    @"_____/\___",
    @"______/\__",
    @"_______/\_",
    @"__/\____/\",
    @"_________/",
    @"__________",
    @"\_________"
    ];

var i = 0;
var length = messages.Count;

while (true)
{
    var data = Encoding.UTF8.GetBytes(messages[i++ % length]);
    client.Send(data, data.Length, endPoint);
    Thread.Sleep(100);
}


