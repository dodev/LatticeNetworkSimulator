using System;
using System.Drawing;
using System.Collections.Generic;

namespace NetworkSimulator
{
	public class GraphicalVertex : IDrawable
	{
		private Vertex vertex;
		
		public Vertex Vertex
		{
			get
			{
				return this.vertex;
			}
		}
		
		private System.Drawing.Point location;
		
		public static int SizeX = 70;
		public static int SizeY = 70;
		
		public int Handler
		{
			get
			{
				return this.vertex.Handler;
			}
		}
		
		//private System.Drawing.Size size;
		
		public GraphicalVertex( Point _point,  Vertex _vertex)
		{
			this.vertex = _vertex;
			
			this.location = _point;
			
			//this.size = new Size(GraphicalElements.VertexImage.Width, GraphicalElements.VertexImage.Height);
			
		}
		
		
		public Point Center()
		{
			return new Point( 
				this.location.X + (GraphicalVertex.SizeX/2),
				this.location.Y + (GraphicalVertex.SizeY/2)
			);
		}
		
		public void Draw( System.Drawing.Bitmap image )
		{
			Font vertNum = new Font( "Tahoma", 22);
			Font vertStatus = new Font( "Tahoma", 10 );
			int imgX = (int)Math.Round((GraphicalVertex.SizeX - GraphicalElements.VertexImage.Width) / 2f);
			int imgY = (int)Math.Round((GraphicalVertex.SizeY - GraphicalElements.VertexImage.Height) / 2f);
			using ( Graphics drawer = Graphics.FromImage( image ) )
			{
				drawer.DrawImage( GraphicalElements.VertexImage, this.location.X + imgX, this.location.Y +imgY );
				
				drawer.DrawString(
					this.Handler.ToString(),
					vertNum,
					Brushes.DarkBlue,
					(float)(this.location.X+imgX),
					(float)(this.location.Y+imgY)
				);
				
				int redColor = (int)(this.vertex.Status()*400);
				if ( redColor > 255 )
					redColor = 255;
				
				drawer.DrawString(
					(this.vertex.Status()*100).ToString("F2"),
					vertStatus,
					new SolidBrush(Color.FromArgb(redColor,0,0)),
					(float)this.location.X,
					(float)this.location.Y
				);
			}
			vertNum.Dispose();
			vertStatus.Dispose();
		}
		
		public void DrawA( System.Drawing.Bitmap image )
		{
			Font vertNum = new Font( "Tahoma", 22);
			Font vertStatus = new Font( "Tahoma", 10 );
			int imgX = (int)Math.Round((GraphicalVertex.SizeX - GraphicalElements.VertexImage.Width) / 2f);
			int imgY = (int)Math.Round((GraphicalVertex.SizeY - GraphicalElements.VertexImage.Height) / 2f);
			using ( Graphics drawer = Graphics.FromImage( image ) )
			{
				drawer.DrawImage( GraphicalElements.VertexImage, this.location.X + imgX, this.location.Y +imgY );
				
				int redColor = (int)(this.vertex.RelLoadRatio*4);
				if ( redColor > 255 )
					redColor = 255;
				
				drawer.DrawString(
					this.Handler.ToString(),
					vertNum,
					
					new SolidBrush(Color.FromArgb(redColor, 255 - redColor, 0)),
					(float)(this.location.X+imgX),
					(float)(this.location.Y+imgY)
				);
				
				
				
				
				drawer.DrawString(
					(this.vertex.RelLoadRatio).ToString("F2") + "%",
					vertStatus,
					new SolidBrush(Color.FromArgb(redColor,0,0)),
					(float)this.location.X,
					(float)this.location.Y
				);
			}
			vertNum.Dispose();
			vertStatus.Dispose();
		}
		
		public void DrawMessages( Bitmap image, List<Message> msgList )
		{
			int ellipseSz = 15;
			int fontSz = 7;
			int dImgX = (int)Math.Round((GraphicalVertex.SizeX - GraphicalElements.VertexImage.Width) / 2f);
			int dImgY = (int)Math.Round((GraphicalVertex.SizeY - GraphicalElements.VertexImage.Height) / 2f);
			int xBound = this.location.X + dImgX + GraphicalElements.VertexImage.Width;
			int yBound = this.location.Y + dImgY + GraphicalElements.VertexImage.Height;
			int currentX = this.location.X + dImgX;
			int currentY = this.location.Y + dImgY + 10;
			Font msgFont = new Font("Tahoma", fontSz);
			Brush ellipseBrush = Brushes.DarkRed;
			
			
			using ( Graphics drawer = Graphics.FromImage( image ) )
			{
				foreach( Message msg in msgList )
				{
					switch ( msg.CurrentStatus )
					{
					case MsgStat.JustCreated:
						ellipseBrush = Brushes.DarkRed;
						break;
					case MsgStat.OnTheWay:
						ellipseBrush = Brushes.DarkOrange;
						break;
					case MsgStat.JustRecieved:
						ellipseBrush = Brushes.DarkOliveGreen;
						break;
					}
					drawer.FillEllipse( ellipseBrush, currentX, currentY, ellipseSz, ellipseSz );
					drawer.DrawString( msg.Handler.ToString(), msgFont, Brushes.White, currentX, currentY );
					
					if ( currentX < xBound )
					{
						currentX += ellipseSz;
					}
					else if ( currentY < yBound )
					{
						currentX = this.location.X + dImgX;
						currentY += ellipseSz;
					}
					else
					{
						break;
					}
					
				}
			}
		}
	}
}

