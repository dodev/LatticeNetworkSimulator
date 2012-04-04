using System.Collections.Generic;

namespace NetworkSimulator
{
	///
	/// A class to describe the message objects.
	/// Each message object contains its handler,
	/// from and to addresses, and the path to the destination
	///
	public class Message: IListable
	{
		//	the field used to distinguish different messages
		private int msgHandler;
		
		//	property for the IListible interface
		public int Handler
		{
			get{ return this.msgHandler; }
		}
		
		private MsgStat currStat = MsgStat.JustCreated;
		public MsgStat CurrentStatus
		{
			get
			{
				return this.currStat;
			}
			set
			{
				if ( value == MsgStat.Recieved )
				{
					this.recieved = true;
				}
				this.currStat = value;
			}
		}
		
		private int optiomalHops = 0;
		
		public int OptimalHops
		{
			set
			{
				this.optiomalHops = value;
			}
		}
		
		public float HoldTime
		{
			get
			{
				if (this.optiomalHops != 0)
					return this.hops / this.optiomalHops;
				else
					return 0;
			}
				
		}
		
		private bool recieved = false;
		public bool Recieved 
		{
			get
			{
				return this.recieved;
			}
			set
			{
				this.recieved = value;
			}
		}
		
		//	fields to hold the source and destination address
		private int source;
		public int Source
		{
			get
			{
				return this.source;
			}
		}
		
		private int destination;
		public int Destination
		{
			get
			{
				return this.destination;
			}
		}
		
		public List<int> path;
		private int hops = 0;
		
		public int Hops
		{
			get
			{
				return this.hops;
			}
		}
		
		private int currentVrt;
		public int CurrentVrt
		{
			get
			{
				return this.currentVrt;
			}
			set
			{
				this.currentVrt = value;
				this.path.Add(this.CurrentVrt);
				this.hops++;
			}
		}
		
		///
		///	a constructor to initialize the msg
		///
		public Message( int handler, int src, int dst )
		{
			this.msgHandler = System.Math.Abs( handler );
			
			this.source = src;
			this.destination = dst;
			
			this.path = new List<int>();
			
			this.CurrentVrt = src;
			this.currStat = MsgStat.JustCreated;
		}
		
		public override string ToString ()
		{
			return string.Format ("#{0}, {1}->{2} {3}", Handler, source, destination, CurrentStatus);
		}
	}
}

