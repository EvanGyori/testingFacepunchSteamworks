using Steamworks;
using Steamworks.Data;

public class MyClient : ConnectionManager
{
	public override void OnConnected(ConnectionInfo info)
	{
		base.OnConnected(info);
		Console.WriteLine("Client OnConnected");
	}

	public override void OnConnecting(ConnectionInfo info)
	{
		base.OnConnecting(info);
		Console.WriteLine("Client OnConnecting");
	}

	public override void OnConnectionChanged(ConnectionInfo info)
	{
		base.OnConnectionChanged(info);
		Console.WriteLine($"Client OnConnectionChanged\nState: {info.State}\nidentity: {info.Identity}\nEndReason: {info.EndReason}");
	}

	public override void OnDisconnected(ConnectionInfo info)
	{
		base.OnDisconnected(info);
		Console.WriteLine("Client OnDisconnected");
	}

}
