namespace NetworkSimulator
{
	///
	/// A class to handle the edges
	///	An edge connects two vertices
	///
	public class Edge: IListable
	{
		//	the handler
		private int edgeHandler;
		
		public int Handler
		{
			get { return this.edgeHandler; }
		}
		
		//	fields containing the handlers of the vertices
		//	that the edge connects
		private int vertexHandler1;
		private int vertexHandler2;
		
		public int vHandler1
		{
			get
			{
				return this.vertexHandler1;
			}
		}
		
		public int vHandler2
		{
			get
			{
				return this.vertexHandler2;
			}
		}
		
		//	flags if the edge is active or not
		private bool active;
		
		//	constructor
		public Edge( int handler, int vert1, int vert2 )
		{
			if ( vert1 == vert2 )
			{
				throw new System.Exception( "No cyclic edges allowed." );
			}
			else
			{
				this.vertexHandler1 = vert1;
				this.vertexHandler2 = vert2;
				this.edgeHandler = handler;
			}
			
			this.active = true;
		}
		
		//	switch the edge on
		public void TurnOn()
		{
			this.active = true;
		}
		
		//	switch the edge on
		public void TurnOff()
		{
			this.active = false;
		}
		
		//	checks if the edge connects two vertices
		public bool Connects( int a, int b )
		{
			if ( this.active &&
			   ((this.vertexHandler1 == a) && (this.vertexHandler2 == b) ||
				(this.vertexHandler1 == b) && (this.vertexHandler2 == a)) )
			{
				return true;
			}
			
			return false;
		}
		
	}
}

