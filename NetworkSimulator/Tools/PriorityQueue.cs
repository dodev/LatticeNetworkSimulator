using System.Collections.Generic;

namespace NetworkSimulator
{
public class PriorityQueue<PRTYPE,DATATYPE>
		where PRTYPE: System.IComparable
	{
		private List<PriorityQueueItem<PRTYPE,DATATYPE>> queue;
		
		public PriorityQueue()
		{
			this.queue = new List<PriorityQueueItem<PRTYPE,DATATYPE>>();
		}
		
		public PriorityQueue( int capacity )
		{
			this.queue = new List<PriorityQueueItem<PRTYPE,DATATYPE>>( capacity );
		}
		
		public PriorityQueueItem<PRTYPE,DATATYPE> this[int index]
		{
			get
			{
				return this.queue[index];
			}
			
		}
		
		//	adding an element, depending on its' priority
		public void Enqueue( PRTYPE priority, DATATYPE data )
		{
			//	the element is alone for now, but not forever alone :)
			if ( this.queue.Count == 0 )
			{
				this.queue.Add( new PriorityQueueItem<PRTYPE, DATATYPE>( priority, data ) );
			}
			//	if there are more elements in the queue
			else
			{
				this.addToQueue( priority, data, 0, this.queue.Count - 1 );
			}
		}
		
		//	a helper method that uses recursive binary search to determine the palce of the new
		//	node in the sorted priority queue
		private void addToQueue( PRTYPE priority, DATATYPE data, int leftBound, int rightBound )
		{
			//	if in the lenght of the range is 0, there is only one element in the range
			if ( leftBound == rightBound )
			{
				//	
				if ( this.queue[leftBound].Priority.CompareTo( priority ) >= 0 )
				{
					this.queue.Insert( leftBound, new PriorityQueueItem<PRTYPE,DATATYPE>( priority, data ) );
				}
				else
				{
					this.queue.Insert( leftBound+1, new PriorityQueueItem<PRTYPE,DATATYPE>( priority, data ) );
				}
			}
			//	if there are 2 or more elements in the given range
			else
			{
				//	find the index of the middle element
				int middle = (int)System.Math.Floor( ((leftBound + rightBound) / 2f) );
				
				//	the element is in the upper section of the range
				if ( this.queue[middle].Priority.CompareTo(priority) > 0 )
				{
					this.addToQueue( priority, data, leftBound, middle );
				}
				//	the element is in the right section of the range
				else if ( this.queue[middle].Priority.CompareTo(priority) < 0 )
				{
					//	middle + 1 fixes a stack overflow bug
					this.addToQueue( priority, data, middle + 1, rightBound );
				}
				//	if the priority is equal to the one of the middle element
				else
				{
					this.queue.Insert( middle, new PriorityQueueItem<PRTYPE,DATATYPE>( priority, data ) );
				}
			}
		}
		
		public void SetPriority( DATATYPE theNodesData, PRTYPE newPriority )
		{
			PriorityQueueItem<PRTYPE,DATATYPE> tmp = this.queue.Find( 
				delegate( PriorityQueueItem<PRTYPE, DATATYPE> currentNode )
				{ 
					return currentNode.Data.Equals( theNodesData );
				} 
			);
			
			this.queue.Remove(tmp);
			
			this.addToQueue( newPriority, theNodesData, 0, this.queue.Count - 1);
		}
		
		public PRTYPE GetPriority( DATATYPE theNodesData )
		{
			return this.queue.Find(
				delegate( PriorityQueueItem<PRTYPE, DATATYPE> currentNode )
				{ 
					return currentNode.Data.Equals( theNodesData );
				}
			).Priority;
		}
		
		public PriorityQueueItem<PRTYPE, DATATYPE> Dequeue()
		{
			if ( this.queue.Count == 0 )
			{
				return default( PriorityQueueItem<PRTYPE, DATATYPE> );
			}
			PriorityQueueItem<PRTYPE, DATATYPE> tmp = this.queue[0];
			this.queue.Remove( this.queue[0] );
			return tmp;
		}
		
		//	used for min priority queue
		public PriorityQueueItem<PRTYPE, DATATYPE> PeekTop()
		{
			if ( this.queue.Count == 0 )
			{
				return default( PriorityQueueItem<PRTYPE, DATATYPE> );
			}
			return this.queue[0];
		}
		
		//	used for max priority queue
		public PriorityQueueItem<PRTYPE, DATATYPE> PeekBottom()
		{
			if ( this.queue.Count == 0 )
			{
				return default( PriorityQueueItem<PRTYPE, DATATYPE> );
			}
			return this.queue[this.queue.Count - 1];
		}
		
		public int Count()
		{
			return this.queue.Count;
		}
		
		public void AddToBottom( PRTYPE priority, DATATYPE data )
		{
			this.queue.Add( new PriorityQueueItem<PRTYPE, DATATYPE>( priority, data ) );			
		}
	}
}

