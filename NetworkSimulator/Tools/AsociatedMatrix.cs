using System.Collections.Generic;

namespace NetworkSimulator
{
	public class AsociatedMatrix<DTYPE>
	{
		private DTYPE[,] matrix;
		
		private int[] hIndex;
		
		private int[] vIndex;
		
		private int vDim;
		private int hDim;
		
		public int VDim
		{
			get
			{
				return this.vDim;
			}
		}
		
		public int HDim
		{
			get
			{
				return this.hDim;
			}
		}
		
		public AsociatedMatrix( int[] vI, int[] hI )
		{
			this.vDim = (int)vI.GetLongLength(0);
			this.hDim = (int)hI.GetLongLength(0);
			
			this.matrix = new DTYPE[this.vDim,this.hDim];
			
			this.hIndex = (int[])hI.Clone();
			this.vIndex = (int[])vI.Clone();
		}
		
		public AsociatedMatrix( List<IListable> vList, List<IListable> hList )
		{
			this.vDim = vList.Count;
			this.hDim = hList.Count;
			
			this.matrix = new DTYPE[this.vDim,this.hDim];
			
			this.vIndex = new int[this.vDim];
			this.hIndex = new int[this.hDim];
			
			for ( int i = 0; i < this.vDim; i++ )
			{
				this.vIndex[i] = vList[i].Handler;
			}
			
			for ( int i = 0; i < this.hDim; i++ )
			{
				this.hIndex[i] = hList[i].Handler;
			}
		}
		
		private int indexOf( int[] arr, int val )
		{
			for( int i = 0; i < arr.GetLength(0); i++ )
			{
				if ( arr[i] == val )
					return i;
			}
			
			//	if no matches were found
			return -1;
		}
		
		public DTYPE GetElement( int v, int h )
		{
			int vI = this.indexOf( this.vIndex, v );
			int hI = this.indexOf( this.hIndex, h );
			
			return this.matrix[vI,hI];
		}
		
		public void SetElement( int v, int h, DTYPE val )
		{
			int vI = this.indexOf( this.vIndex, v );
			int hI = this.indexOf( this.hIndex, h );
			
			this.matrix[vI,hI] = val;
		}

		public DTYPE this[int i, int j]
		{
			get
			{
				return this.GetElement( i, j );
			}
			
			set
			{
				this.SetElement( i, j, value );
			}
		}
		
		//	a method to return all the vertices connected to the sourceVIndex
		//	the max number of vertices is 4, in a regular, rectangular network
		public List<int> GetConnectedVertices( int sourceVIndex )
		{
			List<int> neightbours = new List<int>(4);
			
			int vInd = this.indexOf( this.vIndex, sourceVIndex );
			
			for ( int i = 0; (i < this.hDim) && (neightbours.Count < 4); i++ )
			{
				if ( !this.matrix[vInd,i].Equals(0) )
				{
					for ( int j = 0; j < this.vDim; j++ )
					{
						if ( (j != vInd) && (!this.matrix[j,i].Equals(0)) )
						{
							neightbours.Add( this.vIndex[j] );
							break;
						}
					}
				}
			}
			
			return neightbours;
		}
		
		public DTYPE GetDistance( int v1, int v2 )
		{
			int index1 = this.indexOf( vIndex, v1 );
			int index2 = this.indexOf( vIndex, v2 );
			
			for ( int i = 0; i < hDim; i++ )
			{
				if ( (!this.matrix[index1,i].Equals(0)) && this.matrix[index1,i].Equals(this.matrix[index2,i]) )
				{
					return this.matrix[index1,i];
				}
			}
			
			return default( DTYPE );
		}
	}
}

