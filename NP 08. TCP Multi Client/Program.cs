using System.Net;
using System.Net.Sockets;

var client = new TcpClient();
var ip = IPAddress.Parse("10.2.24.1");
var port = 27001;

try
{
	client.Connect(ip, port);
    Console.WriteLine("Connected to server");
	var stream = client.GetStream();
	var br = new BinaryReader(stream);
	var bw = new BinaryWriter(stream);
	var sendingTask = Task.Run(()=>
	{
		while (true)
		{
			var message = Console.ReadLine();
			if (string.IsNullOrEmpty(message)) continue;
			try
			{
				bw.Write(message);
				bw.Flush();
			}
			catch (Exception ex)
			{
                Console.WriteLine($"Sending Error: {ex.Message}");
				break;
			}
		}
	});

	var receivingTask = Task.Run(() =>
	{
		while (true)
		{
			try
			{
				var received = br.ReadString();
                Console.WriteLine($"{received}");
			}
			catch (Exception ex)
			{
                Console.WriteLine($"Receiving error: {ex.Message}");
				break;
			}
		}
	});

	await Task.WhenAny(sendingTask, receivingTask);
}
catch (Exception ex)
{
    Console.WriteLine($"Connection Error: {ex.Message}");
}
finally
{
	client.Close();
}


