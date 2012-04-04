namespace NetworkSimulator
{
	public class PriorityQueueItem<P,D>
		where P: System.IComparable
	{
		public P Priority;
		
		public D Data;
		
		public PriorityQueueItem( P pr, D dt )
		{
			this.Priority = pr;
			this.Data = dt;
		}
	}
}

