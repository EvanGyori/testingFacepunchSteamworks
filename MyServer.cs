using System;
using Steamworks;
using Steamworks.Data;

public class MyServer : SocketManager
{
	Int32 test = 1;

	public void MessageConnections()
	{
		foreach (Connection connection in Connected) {
			unsafe { fixed (Int32* val = &test) {
				IntPtr ptr = new((void*) val);
				connection.SendMessage(ptr, 4, SendType.Reliable | SendType.NoNagle);
			}}
		}
	}

	public void DisconnectAll()
	{
		foreach (Connection connection in Connected) {
			connection.Close();
		}
	}

	public override void OnConnected(Connection connection, ConnectionInfo info)
	{
		base.OnConnected(connection, info);
		Console.WriteLine("Server OnConnected");
		Console.WriteLine();

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
		Console.WriteLine($"Server OnConnectionChanged\nState: {info.State}\nidentity: {info.Identity.SteamId}\nEndReason: {info.EndReason}\ndetailed:\n{connection.DetailedStatus()}");
		Console.WriteLine();
	}

	public override void OnDisconnected(Connection connection, ConnectionInfo info)
	{
		base.OnDisconnected(connection, info);
		Console.WriteLine("Server OnDisconnected");
		Console.WriteLine();
	}

	public override void OnMessage(Connection connection, NetIdentity identity, IntPtr data, int size, long messageNum, long recvTime, int channel)
	{
		base.OnMessage(connection, identity, data, size, messageNum, recvTime, channel);
		Console.WriteLine($"Server OnMessage\nsize: {size}\nmessageNum: {messageNum}\nrecvTime: {recvTime}\nchannel: {channel}");
		unsafe {
			Console.WriteLine($"data: {*(Int32*)data}");
		}
		Console.WriteLine();
	}
}
