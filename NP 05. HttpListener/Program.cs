using System.Net;

var listener = new HttpListener();

listener.Prefixes.Add(@"http://localhost:27001/");
listener.Prefixes.Add(@"http://localhost:27002/");

listener.Start();


while (true)
{
    var context = listener.GetContext();

    var request = context.Request;
    var response = context.Response;
    //Console.WriteLine(request);
    //Console.WriteLine(request.RawUrl);

    // ?login=moguda&password=123456 - query string
    // (?key1=value&key2=value2&...)
    var rawUrl = request.RawUrl;
    //var queryString = rawUrl.Split('?')[1];
    //var queryString = rawUrl[2..];
    //Console.WriteLine(queryString);
    //var datas = queryString.Split('&');
    //for (int i = 0; i < datas.Length; i++)
    //{
    //    var data = datas[i].Split('=');
    //    Console.WriteLine($"{data[0]} - {data[1]}");
    //}

    //Console.WriteLine(request.QueryString);

    //foreach (string key in request.QueryString.Keys)
    //{
    //    Console.WriteLine($"{key} - {request.QueryString[key]}");
    //}

    //response.AddHeader("Content-Type", "text/plain");

    StreamWriter writer = new StreamWriter(response.OutputStream);
    var login = request.QueryString["login"];
    //writer.Write($"Welcome {login}");

    //writer.WriteLine($"<h1 style='color:red;'>Welcome {login}</h1>");
    //writer.WriteLine($"<a href='https://google.com/search?q={login}'>Search</a>");
    //writer.WriteLine($"<img src='https://avatars.githubusercontent.com/u/123265575?v=4'/>");

    var html = $"""
        <h1 style='color:red;'>Welcome {login}</h1>
        <a href='https://google.com/search?q={login}'>Search</a>
        <img src='https://avatars.githubusercontent.com/u/123265575?v=4'/>
        """;
    writer.Write(html);


    writer.Close();
}
