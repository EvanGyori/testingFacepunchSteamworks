using System;
using Steamworks;
using Steamworks.Data;

public class MyClient : ConnectionManager
{
	Int32 test = 321;

	public void MessageConnection()
	{
		unsafe { fixed (Int32* val = &test) {
			IntPtr ptr = new((void*) val);
			Connection.SendMessage(ptr, 4, SendType.Reliable | SendType.NoNagle);
		}}
	}

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
		Console.WriteLine($"Client OnConnectionChanged\nState: {info.State}\nSteamId: {info.Identity.SteamId}\nEndReason: {info.EndReason}");
		Console.WriteLine($"Is SteamId? {info.Identity.IsSteamId}");
		Console.WriteLine($"Detailed Connection: {Connection.DetailedStatus()}");
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
