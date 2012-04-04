namespace NetworkSimulator
{
	///
	/// A class providing the basic needed functionality for a list of nodes
	///
	public class BasicList
	{
		//	the field containing the the list of nodes of the IListable interface
		protected System.Collections.Generic.List<IListable> theList;
		
		public System.Collections.Generic.List<IListable> TheList
		{
			get
			{
				return this.theList;
			}
		}
		
		///
		///	default constructor
		///
		public BasicList()
		{
			this.theList = new System.Collections.Generic.List<NetworkSimulator.IListable>();
		}
		
		public BasicList( int capacity )
		{
			this.theList = new System.Collections.Generic.List<NetworkSimulator.IListable>( capacity );
		}
		
		//	indexer
		public IListable this[int i]
		{
			get
			{
				return this.theList[i];
			}
			set
			{
				this.theList[i] = value;
			}
			
		}
		
		///
		/// checks the list for duplicate handler fields
		///
		protected bool isUniqueHandler( int newHandler )
		{
			foreach ( IListable tester in this.theList )
			{
				if ( tester.Handler == newHandler )
					return false;
			}
			return true;
		}
		
		public bool isEmpty()
		{
			return (this.theList.Count == 0);
		}
		
		public int Count()
		{
			return this.theList.Count;
		}
	}
}

