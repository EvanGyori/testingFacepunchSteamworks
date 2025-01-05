using Steamworks;
using Steamworks.Data;

public class MyServer : SocketManager
{
	public override void OnConnected(Connection connection, ConnectionInfo info)
	{
		base.OnConnected(connection, info);
		Console.WriteLine("Server OnConnected");
	}

	public override void OnConnecting(Connection connection, ConnectionInfo info)
	{
		base.OnConnecting(connection, info);
		Console.WriteLine("Server OnConnecting");
	}

	public override void OnConnectionChanged(Connection connection, ConnectionInfo info)
	{
		base.OnConnectionChanged(connection, info);
		Console.WriteLine($"Server OnConnectionChanged\nState: {info.State}\nidentity: {info.Identity}\nEndReason: {info.EndReason}\ndetailed:\n{connection.DetailedStatus()}");
	}

	public override void OnDisconnected(Connection connection, ConnectionInfo info)
	{
		base.OnDisconnected(connection, info);
		Console.WriteLine("Server OnDisconnected");
	}
}
