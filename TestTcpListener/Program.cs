// See https://aka.ms/new-console-template for more information

using System.Net;

Console.WriteLine("Hello, World!");

try
{
    if (args.Length > 0)
    {
        int portnumber = int.Parse(args[0]);

        IPHostEntry entry;
        string testString = "ninecrows.ddns.net"; // "10.1.1.1";
        entry = Dns.Resolve(testString);


    }
    else
    {
        Console.Write("Usage: TestTcpListener portnumber\n");
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
