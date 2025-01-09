using Steamworks;
using Steamworks.Data;

SteamClient.Init(480, false);
Console.WriteLine(SteamClient.Name);
Console.WriteLine(SteamClient.SteamId);

ushort port = 63794;
//var IP = NetAddress.LocalHost(63794);
var IP = NetAddress.AnyIp(port);

string input = Console.ReadLine();
if (input == "server") {
	//MyServer server = SteamNetworkingSockets.CreateNormalSocket<MyServer>(IP);
	MyServer server = SteamNetworkingSockets.CreateRelaySocket<MyServer>();
	while (true) {
		SteamClient.RunCallbacks();
		server.Receive();
		if (Console.KeyAvailable) {
			var key = Console.ReadKey().Key;
			if (key == ConsoleKey.Q) {
				break;
			} else if (key == ConsoleKey.R) {
				server.MessageConnections();
			} else if (key == ConsoleKey.C) {
				server.DisconnectAll();
			}
		}
	}
} else {
	// Client
	//MyClient client = SteamNetworkingSockets.ConnectNormal<MyClient>(NetAddress.LocalHost(port));
	MyClient client = SteamNetworkingSockets.ConnectRelay<MyClient>((SteamId)(ulong.Parse(input)));
	while (true) {
		SteamClient.RunCallbacks();
		client.Receive();
		if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Q) {
			break;
		}
	}
}


SteamClient.Shutdown();
