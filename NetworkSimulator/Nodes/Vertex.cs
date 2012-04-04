using System;
using System.Collections.Generic;

namespace NetworkSimulator
{
	///
	/// A class to represent a vertex in the graph.
	/// Holds a list with the messages currently in him
	/// (aka memory); contains a method to route messages;
	/// has a limit of messages in the list.
	///
	public class Vertex: IListable
	{
		private int vertHandler;
		private int x;
		private int y;
		
		private VertexConfig config;
		
		private Queue<int> memory;
		private Queue<int> genMemory;
		private Queue<int> recieveMemory;
		
		private int currentProcQ;
		private int currentGenerateQ;
		private int currentRecieveQ;
		
		private float statusSum = 0;
		
		public float StatusSum
		{
			get
			{
				return this.statusSum;
			}
		}
		
		private float loadSum = 0;
		
		public float LoadSum
		{
			get
			{
				return this.loadSum;
			}
			set
			{
				this.loadSum = value;
			}
		}
		
		private float relLoadRatio = 0;
		
		public float RelLoadRatio
		{
			get
			{
				return this.relLoadRatio;
			}
			set
			{
				this.relLoadRatio = value;
			}
		}
		
		public int Handler
		{
			get { return this.vertHandler; }
		}
		
		public int X
		{
			get
			{
				return this.x;
			}
		}
		
		public int Y
		{
			get
			{
				return this.y;
			}
		}
		
		public Vertex( int handler, VertexConfig conf )
		{
			this.vertHandler = handler;
			this.config = conf;
			
			this.initMemory();
		}
		
		public Vertex( int handler, VertexConfig conf, int _x, int _y )
		{
			this.vertHandler = handler;
			this.config = conf;
			
			this.x = _x;
			this.y = _y;
			
			this.initMemory();
		}
		
		private void initMemory()
		{
			this.memory = new Queue<int>();
			this.genMemory = new Queue<int>();
			this.recieveMemory = new Queue<int>();
			
			this.currentProcQ = 0;
			this.currentGenerateQ = 0;
			this.currentRecieveQ = 0;
		}
		
		public bool Recieve( Message msg )
		{
			if ( this.IsFull() )
				return false;
			
			memory.Enqueue( msg.Handler );
			msg.CurrentVrt = this.Handler;
			
			return true;
		}
		
		///
		///	Calculating the maximum number of actions for the current iteration
		///
		public void CalculateCurrentQueue()
		{
			this.currentProcQ = ( memory.Count > this.config.Base ) ? this.config.Base : memory.Count;
			this.currentGenerateQ = this.genMemory.Count;
			this.currentRecieveQ = this.recieveMemory.Count;
		}
		
		///
		///	Returns the load ratio (0;1) for the genMemory queue
		///
		public float StatusGenerating()
		{
			if ( this.config.GenLimit != 0 )
				return (float)this.genMemory.Count / (float)this.config.GenLimit;
			else
				return 0f;
		}
		
		///
		///	Returns the overall load ratio of the instance
		///
		public float Status()
		{
			if ( this.config.Buffer != 0 )
			{
				float inTheBuffer = (float)(this.memory.Count - this.currentProcQ) / (float)this.config.Buffer;
				return inTheBuffer + this.StatusGenerating()*0.01f + this.recieveMemory.Count*0.001f;
			}
			else
				return 0f;
		}
		
		public bool IsFull()
		{
			return this.Status() > this.config.FullLoadRatio;
		}
		
		public void AddMsg( int msgHndl )
		{
			this.genMemory.Enqueue( msgHndl );
		}
		
		public void Iterate( MessageList msgList )
		{
			Message tmpMsg;
			
			//	processing recieved messages from the previous iteration
			while ( this.currentRecieveQ > 0)
			{
				msgList.Find( this.recieveMemory.Dequeue() ).CurrentStatus = MsgStat.Recieved;
				this.currentRecieveQ--;
			}
			
			//	adding freshly created messages to the main queue
			//	if there is no space left, add them back to the gen queue
			while (this.currentGenerateQ > 0 )
			{
				tmpMsg = msgList.Find( this.genMemory.Dequeue() );
				if ( this.IsFull() )
				{
					this.genMemory.Enqueue( tmpMsg.Handler );
				}
				else
				{
					this.memory.Enqueue( tmpMsg.Handler );
					tmpMsg.CurrentStatus = MsgStat.OnTheWay;
				}
				this.currentGenerateQ--;				
			}
			
			//	sending messages in the base
			while ( this.currentProcQ > 0 )
			{
				tmpMsg = msgList.Find( this.memory.Dequeue() );
				//	if the message has reached its final destination
				if ( this.Handler == tmpMsg.Destination )
				{
					tmpMsg.CurrentStatus = MsgStat.JustRecieved;
					this.recieveMemory.Enqueue( tmpMsg.Handler );
				}
				//	if the message has been successfully sent remove it from the memory,
				//	put it in the end of the queue, otherwise.
				else if ( this.sendMsg( tmpMsg ) == false )
				{
					this.memory.Enqueue( tmpMsg.Handler );
				}
				this.currentProcQ--;
			}
			
			this.statusSum += this.Status();
		}
		
		private bool sendMsg( Message msg )
		{
			List<Vertex> psblNxtStp = this.config.RouteFunc( this.Handler, msg.Destination );
			
			foreach ( Vertex vrt in psblNxtStp )
			{
				if ( vrt.Recieve( msg ) )
					return true;
			}
			
			return false;
		}
	}
}

