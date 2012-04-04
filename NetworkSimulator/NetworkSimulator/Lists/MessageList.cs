using System.Collections.Generic;

namespace NetworkSimulator
{
	///
	///	Contains the list of generated and used by the current session
	///
	public class MessageList: BasicList
	{
		private int cnt = 1;
		//	calling the constructor of the parent
		public MessageList():base(){}
		
		///
		///	Check the isUniqueHandler rule and add a new item to the list
		///
		public int Add( int src, int dst )
		{
			//System.Random rng = new System.Random();			
			
			int newHandler;
			
			while ( !this.isUniqueHandler( newHandler = cnt++ ) );
			
			this.theList.Add( new Message( newHandler, src, dst ) );
			
			return newHandler;
		}
		
		public Message Find( int handler )
		{
			if ( handler < 0 )
				return null;
			
			return (Message)this.theList.Find(
				delegate(IListable l)
				{
					return l.Handler == handler;
				}
			);
		}
		
		public bool AllReceived()
		{
			if ( this.isEmpty() )
				return false;
			
			Message tmpMsg;
			foreach( IListable msg in this.theList )
			{
				tmpMsg = (Message)msg;
				if ( tmpMsg.Recieved == false )
					return false;
			}
			
			return true;
		}
		
		public List<Message> GetMsgsOnNode( int currVrt, int limit )
		{
			if ( this.isEmpty() )
				return null;
			
			//	limit is the max num of msg that can exist in a vertexes queue
			List<Message> msgList = new List<Message>( limit );
			Message tmpMsg;
			
			foreach( IListable msg in this.theList )
			{
				tmpMsg = (Message)msg;
				if ( (tmpMsg.CurrentVrt == currVrt) && (tmpMsg.Recieved == false) )
				{
					msgList.Add( tmpMsg );
				}
			}
			
			return msgList;
		}
	}
}

