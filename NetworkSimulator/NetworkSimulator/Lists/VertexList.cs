namespace NetworkSimulator
{
	public class VertexList: BasicList
	{
		//	using the number of the generated vertix
		//	for its handler. 
		public static int counter = 0;
		
		
		
		//	calling the constructor of the parent
		public VertexList(): base() {}
		
		public VertexList( int capacity ): base( capacity ) {}
	
		public new Vertex this[int i]
		{
			get
			{
				return (Vertex)this.theList[i];
			}
		}
		
		public void Add( VertexConfig conf )
		{
			while ( !this.isUniqueHandler( ++counter ) );
			
			this.theList.Add( new Vertex( counter, conf ) );
		}
		
		public void Add( VertexConfig conf, int x, int y )
		{
			while ( !this.isUniqueHandler( ++counter ) );
			
			this.theList.Add( new Vertex( counter, conf, x, y ) );
		}
		
		public Vertex Find( int handler )
		{
			return (Vertex)this.TheList.Find(
				delegate( IListable v ) 
				{
					return handler == v.Handler;
				}
			);
		}
		
		public Vertex Find( int x, int y )
		{
			return (Vertex)this.TheList.Find(
				delegate( IListable v )
				{
					Vertex vert = (Vertex)v;
					return (vert.X == x) && (vert.Y == y);
				}
			);
		}
		
	}
}

