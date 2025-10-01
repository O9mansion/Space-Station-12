using System;
using System.Threading.Tasks;
using Content.Server.Core;
// Start all processes that need to be ran
GlobalTick.Initialize();
var network = new NetworkCore();
_ = network.Start();

Console.WriteLine("Hello, World!");
Console.WriteLine("Type 'stop' to end the program.");

while (true)
{
    if (Console.ReadLine()?.Trim().ToLower() == "stop")
    {
        GlobalTick.Stop();
        break;
    } else if (Console.ReadLine()?.Trim().ToLower() == "cmds")
    {
        Console.WriteLine("Available commands:");
        Console.WriteLine("stop - Stops the program.");
        Console.WriteLine("cmds - Displays this list of commands.");
    } else
    {
        Console.WriteLine("Unknown command. Type 'cmds' to view available commands.");
    }
}
