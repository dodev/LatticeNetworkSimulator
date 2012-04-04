using System.Collections.Generic;

namespace NetworkSimulator
{
	///
	///	A lattice network simulation performed to store and analyze data.
	///	A class to handle the session, store data, and analyze the processes
	///
	public class Network
	{
		//	dimensions of the network
		private int xDim;
		private int yDim;
		
		private int iterations = 0;
		
		//	list of all the vertexes(transmitters)
		private VertexList vertexList;
		
		public List<IListable> VrtList
		{
			get
			{
				return this.vertexList.TheList;
			}
		}
		
		//	list of all the routes(edges)
		private EdgeList edgeList;
		
		public List<IListable> EdgeList
		{
			get
			{
				return this.edgeList.TheList;
			}
		}
		
		private MessageList msgList;
		
		public MessageList MsgList
		{
			get
			{
				return this.msgList;
			}
		}
		
		// property for interfacing with the xDim field
		public int XDim
		{
			get
			{
				return xDim;	
			}
			set
			{
				if ( value > 0)
				{
					this.xDim = value;
				}
				else
				{
					throw new System.Exception( "Only positive and non-null values accepted." );
				}
			}
		}
		
		// propery for interfacing with the yDim field
		public int YDim
		{
			get
			{
				return yDim;	
			}
			set
			{
				if ( value > 0)
				{
					this.yDim = value;
				}
				else
				{
					throw new System.Exception( "Only positive and non-null values accepted." );
				}
			}
		}
		
		private VertexConfig vrtConfig;
		
		public Network(int x, int y, int _base, int buffer, int genLimit, float maxLoadRatio, bool djekstra)
		{
			this.xDim = x;
			this.yDim = y;
			
			this.msgList = new MessageList();
			this.vertexList = new VertexList(x * y);
			this.edgeList = new EdgeList((x-1)*y + (y-1)*x);
			
			if ( djekstra )
			{
				this.vrtConfig = new VertexConfig( buffer, _base,genLimit, maxLoadRatio, this.findRouteD );
			
				this.initVertexList();
			
				this.initEdgeList();
				
				//	initializing the incidency matrix variable with dimensions edges x vertices
				this.incidencyMatrix = new AsociatedMatrix<sbyte>( this.vertexList.TheList, this.edgeList.TheList );
			}
			else
			{
				this.vrtConfig = new VertexConfig( buffer, _base,genLimit, maxLoadRatio, this.findRouteC );
				
				this.initVrtListCoord( x, y );
				
				this.initEdgeListCoord();
			}
		}
		
		private NetworkConfig netConf;
		
		public Network(NetworkConfig netcfg, VertexConfig vrtcfg/*, bool djekstra*/)
		{
			this.netConf = netcfg;
			
			int x = netConf.HNodes;
			int y = netConf.VNodes;
			
			this.msgList = new MessageList();
			this.vertexList = new VertexList(x * y);
			this.edgeList = new EdgeList((x-1)*y + (y-1)*x);
			
			// if !djekstra
			
			vrtcfg.RouteFunc = this.findRouteC;
			this.vrtConfig = vrtcfg;
			this.initVrtListCoord(x, y);
			this.initEdgeListCoord();
		}
		
		//public void ChangeSettings
		
		#region Coordinate Drop algorithm
		
		private void initVrtListCoord( int x, int y )
		{
			for ( int j = 0; j < y; j++ )
			{
				for ( int i = 0; i < x; i++ )
				{
					this.vertexList.Add( this.vrtConfig, i, j);
				}
			}
		}
		
		private void initEdgeListCoord()
		{
			this.xDim = this.netConf.HNodes;
			this.yDim = this.netConf.VNodes;
			
			//	generating the horizontal edges
			//	the Y axis cycle
			for ( int j = 0; j < this.yDim; j++ )
			{
				//	the X axis cycle
				for ( int i = 0; i < (this.xDim - 1); i++ )
				{
					this.edgeList.Add( this.vertexList[(j*this.xDim)+i].Handler, this.vertexList[(j*this.xDim)+(i+1)].Handler );
				}
			}
			
			//	generating the vertical edges
			//	the Y axis cycle
			for ( int j = 0; j < (this.yDim - 1); j++ )
			{
				//	the X axis cycle
				for ( int i = 0; i < this.xDim; i++ )
				{
					this.edgeList.Add( this.vertexList[(j*this.xDim)+i].Handler, this.vertexList[((j+1)*this.xDim)+i].Handler );
				}
			}
		}
		
		private List<Vertex> findRouteC( int hndlSource, int hndlDestination )
		{
			List<Vertex> routePath = new List<Vertex>(4);
			
			//	if the same vertex is given as a source and destination
			//	return an empty list
			if ( hndlSource != hndlDestination )
			{
				Vertex v1 = this.vertexList.Find( hndlSource );
				Vertex v2 = this.vertexList.Find( hndlDestination );
				
				int dx = v2.X - v1.X;
				int dy = v2.Y - v1.Y;
				
				int absDx = System.Math.Abs( dx );
				int absDy = System.Math.Abs( dy );
				
				if ( absDx <= absDy )
				{
					if ( dx != 0 )
					{
						routePath.Add( this.vertexList.Find( v1.X + (dx/absDx), v1.Y) );
						routePath.Add( this.vertexList.Find( v1.X, v1.Y + (dy/absDy) ) );
					}
					else if ( dy != 0 )
					{
						routePath.Add( this.vertexList.Find( v1.X, v1.Y + (dy/absDy) ) );
					}
				}
				else
				{
					if ( dy != 0 )
					{
						routePath.Add( this.vertexList.Find( v1.X, v1.Y + (dy/absDy) ) );
						routePath.Add( this.vertexList.Find( v1.X + (dx/absDx), v1.Y) );
					}
					else
					{
						routePath.Add( this.vertexList.Find( v1.X + (dx/absDx), v1.Y) );
					}
				}
				
				if ( (v1.X != 0) && (v1.X != (this.xDim-1)) && (absDx != 0) )
				{
					routePath.Add( this.vertexList.Find( v1.X - (dx/absDx), v1.Y ) );
				}
				
				if ( (v1.Y != 0) && (v1.Y != (this.yDim-1)) && (absDy != 0) )
				{
					routePath.Add( this.vertexList.Find( v1.X, v1.Y - (dy/absDy) ) );
				}
			}
			
			return routePath;
		}
		
		#endregion
		
		#region Djekstra's algorithm
		
		private AsociatedMatrix<sbyte> incidencyMatrix;
		
		
		//	constructor
		public Network( int x, int y )
		{
			this.XDim = x;
			this.YDim = y;
			
			this.vertexList = new VertexList();
			this.initVertexList();
			
			this.edgeList = new EdgeList();
			this.initEdgeList();
			
			int edgeCount = (this.xDim - 1) * this.yDim + (this.yDim - 1) * this.xDim;
			int vertCount = this.xDim * this.yDim;
			
			//	initializing the incidency matrix variable with dimensions edges x vertices
			this.incidencyMatrix = new AsociatedMatrix<sbyte>( this.vertexList.TheList, this.edgeList.TheList );
		}
		
		
		
		//	generates the initial vertex list
		private void initVertexList()
		{
			int count = this.xDim * this.yDim;
			
			//	creating the vertex list with predefined routing algorithm
			for ( int i = 0; i < count; i++ )
			{
				this.vertexList.Add( this.vrtConfig );
			}
		}
		
		//	generates the initial edge list and connects
		//	vertices in a lattice network
		private void initEdgeList()
		{
			//	generating the horizontal edges
			//	the Y axis cycle
			for ( int j = 0; j < this.yDim; j++ )
			{
				//	the X axis cycle
				for ( int i = 0; i < (this.xDim - 1); i++ )
				{
					this.edgeList.Add( this.vertexList[(j*this.xDim)+i].Handler, this.vertexList[(j*this.xDim)+(i+1)].Handler );
				}
			}
			
			//	generating the vertical edges
			//	the Y axis cycle
			for ( int j = 0; j < (this.yDim - 1); j++ )
			{
				//	the X axis cycle
				for ( int i = 0; i < this.xDim; i++ )
				{
					this.edgeList.Add( this.vertexList[(j*this.xDim)+i].Handler, this.vertexList[((j+1)*this.xDim)+i].Handler );
				}
			}
		}
		
		private void initIncidencyMatrix()
		{
			foreach ( Edge edg in this.edgeList.TheList )
			{
				this.incidencyMatrix[edg.vHandler1,edg.Handler] = 1;
				this.incidencyMatrix[edg.vHandler2,edg.Handler] = 1;
			}
		}
		
		//	Finds the next node to hop to in the route to vertDestination and returns it's handler
		//	if all neighbour nodes are overloaded, than return the source node
		
		private List<Vertex> findRouteD( int hndlSource, int hndlDestination )
		{
			int numNodes = this.xDim * this.yDim;
			PriorityQueue<int, int> minRouteQ = new PriorityQueue<int, int>( numNodes );
			List<Vertex> pathList = new List<Vertex>( numNodes - 1 );
			
			//	marking all vertices with infinite distance
			foreach ( Vertex vrt in this.vertexList.TheList )
			{
				minRouteQ.AddToBottom( int.MaxValue, vrt.Handler );
			}
			
			//	assigning the source vertex 0 distance value
			minRouteQ.SetPriority( hndlSource, 0 );

			int currentHandler = 0;
			int minDistance;
			
			//	going through all vertices
			while ( minRouteQ.Count() != 0 )
			{
				//	checking what's on top of the priority queue
				minDistance = minRouteQ.PeekTop().Priority;
				currentHandler = minRouteQ.PeekTop().Data;
				
				//	removing the current element from the queue
				minRouteQ.Dequeue();
				
				//	all remaining vertices are inaccesible from source
				if ( minDistance == int.MaxValue )
				{
					break;
				}
				
				List<int> currentNeightBours = this.incidencyMatrix.GetConnectedVertices( currentHandler );
				int distFromCurrent;
				
				foreach ( int vHandler in currentNeightBours )
				{
					distFromCurrent = this.incidencyMatrix.GetDistance( currentHandler, vHandler ) + minDistance;
					
					if ( minRouteQ.GetPriority(vHandler) > distFromCurrent )
					{
						minRouteQ.SetPriority( vHandler, distFromCurrent );
						pathList.Add( this.vertexList.Find(vHandler) );
					}
				}
			}
			
			//minRouteQ
			return pathList;
		}
		
		#endregion
		
		
		public bool NetworkIterate( int msgPerInterval, int maxMsgs )
		{
			System.Random rng = new System.Random();
			int newSource = 0;
			int newDest = 0;
			int newMsg = 0;
			
			if ( this.msgList.AllReceived() == false )
			{
				
				for ( int i = 0; i < this.vertexList.Count(); i++ )
				{
					this.vertexList[i].CalculateCurrentQueue();
				}
				
				// generate new msgs
				if ( this.msgList.Count() < maxMsgs )
				{
					//	TODO: do checking of the maxMsgs and msgPerInterval variables
					for ( int i = 0; i < msgPerInterval; i++ )
					{
						bool ok = false;
						while ( ok == false )
						{
							newSource = rng.Next( 0, this.vertexList.Count() - 1 );
							
							if ( this.vertexList[newSource].StatusGenerating() < this.vrtConfig.FullLoadRatio )
							{
								newDest = rng.Next( 0, this.vertexList.Count() - 1 );
								if ( newDest != newSource )
								{
									ok = true;
								}
							}
						}
						
						///newDest = rng.Next( 0, this.vertexList.Count() - 1 );
						
						newMsg = this.msgList.Add(this.vertexList[newSource].Handler, this.vertexList[newDest].Handler);
						this.vertexList[newSource].AddMsg( newMsg );
						
						// calculating optimal hops
						int dx = System.Math.Abs(((Vertex)this.vertexList[newSource]).X - ((Vertex)this.vertexList[newDest]).X);
						int dy = System.Math.Abs(((Vertex)this.vertexList[newSource]).Y - ((Vertex)this.vertexList[newDest]).Y);
						this.msgList.Find(newMsg).OptimalHops = dx + dy;
					}
				}
				
				
				//	iterating through all the vertices
				//	TODO: multithredding
				for ( int i = 0; i < this.vertexList.Count(); i++ )
				{
					this.vertexList[i].Iterate( this.msgList );
				}
				
				iterations++;
				
				return true;
			}
			
			return false;
		}
		
		public void Analyze()
		{
			Vertex tmp;
			float max =-1;
			foreach(IListable item in this.vertexList.TheList)
			{
				tmp = (Vertex)item;
				
				tmp.LoadSum = tmp.StatusSum / this.iterations;
				
				if (tmp.LoadSum > max)
					max = tmp.LoadSum;				
			}
			
			foreach(IListable item in this.vertexList.TheList)
			{
				tmp = (Vertex)item;
				
				tmp.RelLoadRatio = (1f - ((max - tmp.LoadSum)/max))*100f;
			}
		}
	}
}

