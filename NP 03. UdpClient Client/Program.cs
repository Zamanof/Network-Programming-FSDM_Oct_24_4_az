using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();

var connectEndPoint = new IPEndPoint(IPAddress.Loopback, 27001);

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
byte[] bytes = default!;

while (true)
{
    bytes = Encoding.UTF8.GetBytes(messages[i++ % messages.Count]);
    client.Send(bytes, bytes.Length, connectEndPoint);
    Thread.Sleep(100);
}