﻿using System.Net;

var listener = new HttpListener();

listener.Prefixes.Add(@"http://localhost:27001/");
listener.Prefixes.Add(@"http://localhost:27002/");

listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    var userName = request.QueryString["login"];
    var password = request.QueryString["password"];
    StreamWriter writer = new(response.OutputStream);

    if (userName == "password" && password == "username")
    {
        writer.WriteLine($"<h1>Welcome {userName}</h1>");
    }
    else
    {
        writer.WriteLine($"<h1 style='color:red;'>Incorrect login or password</h1>");
    }
    writer.Close();
}


