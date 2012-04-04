namespace NetworkSimulator
{
	public class NetworkConfig
	{
		private int hNodes;
		private int vNodes;
		
		public int HNodes
		{
			get
			{
				return this.hNodes;
			}
			set
			{
				this.hNodes = value;
			}
		}
		
		public int VNodes
		{
			get
			{
				return this.vNodes;
			}
			set
			{
				this.vNodes = value;
			}
		}
		
		public NetworkConfig(int hn, int vn)
		{
			this.hNodes = hn;
			this.vNodes = vn;
		}
	}
}

