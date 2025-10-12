using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

TcpListener listener = default;

ConcurrentBag<TcpClient> clients = new();

var ip = IPAddress.Parse("10.2.24.1");
var port = 27001;

listener = new TcpListener(ip, port);

listener.Start();

Console.WriteLine($"Listening on {listener.LocalEndpoint}");



_ = Task.Run(()=>
{
	while (true)
	{
		var message = Console.ReadLine();
		foreach (var client in clients)
		{
			try
			{
				var stream = client.GetStream();
				var bw = new BinaryWriter(stream);
				bw.Write(message!);
				bw.Flush();
			}
			catch (Exception)
			{
                Console.WriteLine($"Client send message failed. Skipping...");
			}
		}
	}
});

while (true)
{
	var client = listener.AcceptTcpClient();
	clients.Add(client);

    Console.WriteLine($"{client.Client.RemoteEndPoint} connected");

	_ = Task.Run(() =>
	{
		try
		{
			var stream = client.GetStream();
			var br = new BinaryReader(stream);
			var bw = new BinaryWriter(stream);
			while (true)
			{
				var message = br.ReadString();
				foreach (var cl in clients)
				{
					if (client.Client.RemoteEndPoint != cl.Client.RemoteEndPoint)
					{
						var clientBw = new BinaryWriter(cl.GetStream());
						clientBw.Write($"{cl.Client.LocalEndPoint}: {message}");
					}
				}
                Console.WriteLine($"Client: {client.Client.RemoteEndPoint}: {message}");
			}
		}
		catch (Exception)
		{
            Console.WriteLine($"Client {client.Client.RemoteEndPoint} disconnected");
		}
	});
}

