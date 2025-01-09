using System;
using Steamworks;
using Steamworks.Data;

public class MyClient : ConnectionManager
{
	public override void OnConnected(ConnectionInfo info)
	{
		base.OnConnected(info);
		Console.WriteLine("Client OnConnected");
		Console.WriteLine();
	}

	public override void OnConnecting(ConnectionInfo info)
	{
		base.OnConnecting(info);
		Console.WriteLine("Client OnConnecting");
		Console.WriteLine();
	}

	public override void OnConnectionChanged(ConnectionInfo info)
	{
		base.OnConnectionChanged(info);
		Console.WriteLine($"Client OnConnectionChanged\nState: {info.State}\nidentity: {info.Identity}\nEndReason: {info.EndReason}");
		Console.WriteLine();
	}

	public override void OnDisconnected(ConnectionInfo info)
	{
		base.OnDisconnected(info);
		Console.WriteLine("Client OnDisconnected");
		Console.WriteLine();
	}

	public override void OnMessage(IntPtr data, int size, long messageNum, long recvTime, int channel)
	{
		base.OnMessage(data, size, messageNum, recvTime, channel);
		Console.WriteLine($"Client OnMessage\nsize: {size}\nmessageNum: {messageNum}\nrecvTime: {recvTime}\nchannel: {channel}");
		unsafe {
			Console.WriteLine($"data: {*(Int32*)data}");
		}
		Console.WriteLine();
	}
}
