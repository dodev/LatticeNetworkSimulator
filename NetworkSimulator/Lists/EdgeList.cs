namespace NetworkSimulator
{
	public class EdgeList: BasicList
	{
		//	using the number of the generated edge
		//	for its handler. NB 0 - inactive
		public static int counter = 1;
		
		public EdgeList(): base() {}
		public EdgeList(int count): base(count) {}
		
		public int Add( int vert1, int vert2 )
		{
			while ( !this.isUniqueHandler( ++counter ) );
			
			this.theList.Add( new Edge( counter, vert1, vert2 ) );
			
			return counter;
		}
	}
}

