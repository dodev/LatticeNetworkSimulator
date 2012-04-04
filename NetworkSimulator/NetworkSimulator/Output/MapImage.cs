using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetworkSimulator
{
	public class MapImage
	{
		private int width;
		private int height;
		
		private int horizontalNodes;
		private int verticalNodes;
		
		private List<IDrawable> vertexList;
		private List<IDrawable> edgeList;
		
		private MessageList messageList = null;
		
		private Bitmap image;
		
		public Bitmap Image
		{
			get
			{
				return this.image;
			}
		}
		
		private PictureBox picBox;
		
		public MapImage( int _width, int _height, int _horizontalNodes, int _verticalNodes, PictureBox _picBox )
		{
			this.width = _width;
			this.height = _height;
			this.image = new Bitmap( this.width, this.height, System.Drawing.Imaging.PixelFormat.Format32bppArgb );
			this.initMapImage();
			
			this.horizontalNodes = _horizontalNodes;
			this.verticalNodes = _verticalNodes;
			
			this.vertexList = new List<IDrawable>( _horizontalNodes * _verticalNodes );
			this.edgeList = new List<IDrawable>( (_horizontalNodes-1)*_verticalNodes + (_verticalNodes+1)*_horizontalNodes );
			
			this.picBox = _picBox;
		}
		
		//	TODO: welcome message instead of white bg
		private void initMapImage()
		{
			//	filling the image white
			using ( Graphics g = Graphics.FromImage( this.image ) )
			{
				g.FillRectangle( Brushes.White, new Rectangle( 0, 0, this.width, this.height ) );
			}
		}
		
		public void InitGraph(List<IListable> nodeList, List<IListable> _edgeList)
		{
			int horizontalStep = (int)(this.width / (this.horizontalNodes + 1 ) );
			int verticalStep = (int)(this.height / (this.verticalNodes + 1 ) );
			
			List<Point> ptList = new List<Point>();
			
			int hCorrection = (int)(GraphicalVertex.SizeX);
			int vCorrection = (int)(GraphicalVertex.SizeY);
			
			//	calculating points to be drawn to
			for( int j = 1; j <= this.verticalNodes; j++ )
			{
				for( int i = 1; i <= this.horizontalNodes; i++ )
				{
					ptList.Add( new Point( i*horizontalStep - hCorrection, j*verticalStep - vCorrection ) );
				}
			}
			
			if ( nodeList.Count != ptList.Count )
			{
				throw new Exception( "Calculated dimensions and given doesnt match." );
			}
			
			for( int i = 0; i < nodeList.Count; i++ )
			{
				this.vertexList.Add( new GraphicalVertex( ptList[i], (Vertex) nodeList[i] ) );
			}
			
			
			Edge tmp;
			for ( int i = 0; i < _edgeList.Count; i++ )
			{
				tmp = (Edge)_edgeList[i];
				this.edgeList.Add( new GraphicalEdge( tmp, getVrt(tmp.vHandler1), getVrt(tmp.vHandler2) ) );
			}
			
			this.drawEdges();
			this.drawVertices();
			
		}
		
		//	a helper method to find a graphical vertex by given handler
		private GraphicalVertex getVrt( int hndl )
		{
			return (GraphicalVertex)this.vertexList.Find(
				delegate( IDrawable v )
				{
					return ((GraphicalVertex)v).Handler == hndl;
				}
			);
		}
		
		private void drawVertices()
		{
			//	TODO: check for initialized list and so on
			foreach( GraphicalVertex vertex in this.vertexList )
			{
				vertex.Draw( this.image );
			}
		}
		
		private void drawVerticesA()
		{
			//	TODO: check for initialized list and so on
			foreach( GraphicalVertex vertex in this.vertexList )
			{
				vertex.DrawA( this.image );
			}
		}
		
		private void drawEdges()
		{
			foreach( GraphicalEdge edge in this.edgeList )
			{
				edge.Draw( this.image );
			}
		}
		
		private void drawMessages()
		{
			if ( this.messageList != null )
			{
				//	TODO: dynamically pass index from the Vertex class
				int limit = 10;
				List<Message> mList;
				foreach( GraphicalVertex vertex in this.vertexList )
				{
					float status = vertex.Vertex.Status();
					if ( status > 0f )
					{
						mList = this.messageList.GetMsgsOnNode( vertex.Handler, limit );
						if ( mList != null )
							vertex.DrawMessages( this.image, mList );
					}
				}
			}
		}
		
		
		public void Draw()
		{
			this.initMapImage();
			this.drawEdges();
			this.drawVertices();
			if ( this.messageList != null )
			{
				this.drawMessages();
			}
			
			this.picBox.Refresh();
		}
		
		public void SetMsgList( MessageList list )
		{
			if ( list != null )
			{
				this.messageList = list;
			}
		}
		
		public void DrawPaht(int msgHandler)
		{
			Message tmp = this.messageList.Find(msgHandler);
			
			this.initMapImage();
			this.drawEdges();
			this.drawVerticesA();
			
			int first = -1;
			int second = -1;
			
			using(Graphics drawer = Graphics.FromImage(this.image))
			{
				foreach(int vrtHndl in tmp.path)
				{
					second = first;
					first = vrtHndl;
					
					if ((first != -1) && (second != -1))
					{
						GraphicalVertex tmp1 = this.getVrt(first);
						
						GraphicalVertex tmp2 = this.getVrt(second);
						
						Pen ThickRedPen = new Pen( Color.DarkRed, 10f );
						
						drawer.DrawLine( ThickRedPen, tmp1.Center(), tmp2.Center() );
						
						ThickRedPen.Dispose();
					}
				}
			}
			
			this.picBox.Refresh();
		}
		
		public void DrawAnalyticalMap()
		{
			this.initMapImage();
			this.drawEdges();
			this.drawVerticesA();
			
			this.picBox.Refresh();
		}
	}
}

