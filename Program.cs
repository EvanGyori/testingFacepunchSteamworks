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
	SteamNetworkingSockets.CreateRelaySocket<MyServer>();
} else {
	// Client
	//MyClient client = SteamNetworkingSockets.ConnectNormal<MyClient>(NetAddress.LocalHost(port));
	SteamNetworkingSockets.ConnectRelay<MyClient>((SteamId)(ulong.Parse(input)));
}

while (true) {
	SteamClient.RunCallbacks();
	if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Q) {
		break;
	}
}

SteamClient.Shutdown();
