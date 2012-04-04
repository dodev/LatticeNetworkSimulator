using System.Drawing;

namespace NetworkSimulator
{
	public class GraphicalEdge : IDrawable
	{
		private Edge edge;
		
		private GraphicalVertex vert1;
		private GraphicalVertex vert2;
		
		
		public GraphicalEdge( Edge _edge, GraphicalVertex _vert1, GraphicalVertex _vert2 )
		{
			this.edge = _edge;
			this.vert1 = _vert1;
			this.vert2 = _vert2;
		}
		
		public void Draw( System.Drawing.Bitmap image )
		{
			Pen ThickOrangePen = new Pen( Color.OrangeRed, 10f );
			using( Graphics drawer = Graphics.FromImage(image) )
			{
				drawer.DrawLine( ThickOrangePen, vert1.Center(), vert2.Center() );
			}
			ThickOrangePen.Dispose();
		}
		
	}
}

