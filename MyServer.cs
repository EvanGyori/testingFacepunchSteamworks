using System;
using Steamworks;
using Steamworks.Data;

public class MyServer : SocketManager
{
	Int32 test = 3;

	public override void OnConnected(Connection connection, ConnectionInfo info)
	{
		base.OnConnected(connection, info);
		Console.WriteLine("Server OnConnected");
		Console.WriteLine();

		IntPtr ptr = new(&test);
		connection.SendMessage(ptr, 4);
	}

	public override void OnConnecting(Connection connection, ConnectionInfo info)
	{
		base.OnConnecting(connection, info);
		Console.WriteLine("Server OnConnecting");
		Console.WriteLine();
	}

	public override void OnConnectionChanged(Connection connection, ConnectionInfo info)
	{
		base.OnConnectionChanged(connection, info);
		Console.WriteLine($"Server OnConnectionChanged\nState: {info.State}\nidentity: {info.Identity}\nEndReason: {info.EndReason}\ndetailed:\n{connection.DetailedStatus()}");
		Console.WriteLine();
	}

	public override void OnDisconnected(Connection connection, ConnectionInfo info)
	{
		base.OnDisconnected(connection, info);
		Console.WriteLine("Server OnDisconnected");
		Console.WriteLine();
	}
}
