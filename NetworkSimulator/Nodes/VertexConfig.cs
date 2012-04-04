namespace NetworkSimulator
{
	public class VertexConfig
	{
		private int buffer;
		private int _base;
		private int genLimit;
		private FindRoute routeFunc;
		private float fullLoadRatio;
		
		public int Buffer
		{
			get
			{
				return this.buffer;
			}
			set
			{
				this.buffer = value;
			}
		}
		
		public int Base
		{
			get
			{
				return this._base;
			}
			set
			{
				this._base = value;
			}
		}
		
		public int GenLimit
		{
			get
			{
				return this.genLimit;
			}
			set
			{
				this.genLimit = value;
			}
		}
		
		public FindRoute RouteFunc
		{
			get
			{
				return this.routeFunc;
			}
			set
			{
				this.routeFunc = value;
			}
		}
		
		public float FullLoadRatio
		{
			get
			{
				return this.fullLoadRatio;
			}
			set
			{
				this.fullLoadRatio = value;
			}
		}
		
		public VertexConfig( int buf, int bas, int gen, float flratio, FindRoute rtfunc )
		{
			this.buffer = buf;
			this._base = bas;
			this.genLimit = gen;
			this.fullLoadRatio = flratio;
			this.routeFunc = rtfunc;
		}
	}
}

