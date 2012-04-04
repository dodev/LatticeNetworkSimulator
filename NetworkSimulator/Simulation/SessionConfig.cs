namespace NetworkSimulator
{
	public class SessionConfig
	{
		private int delay;
		private int limitMessages;
		private int genPerInterval;
		
		public int Delay
		{
			get
			{
				return this.delay;
			}
			set
			{
				this.delay = value;
			}
		}
		
		public int LimitMessages
		{
			get
			{
				return this.limitMessages;
			}
			set
			{
				this.limitMessages = value;
			}
		}
		
		public int GenPerInterval
		{
			get
			{
				return this.genPerInterval;
			}
			set
			{
				this.genPerInterval = value;
			}
		}
		
		public SessionConfig(int del, int lm, int gpi)
		{
			this.delay = del;
			this.limitMessages = lm;
			this.genPerInterval = gpi;			
		}
	}
}

