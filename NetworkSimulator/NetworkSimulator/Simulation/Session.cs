using System;
using System.Threading;

namespace NetworkSimulator
{
	public class Session
	{
		ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
	    ManualResetEvent _pauseEvent = new ManualResetEvent(true);
	    Thread _thread;
		
		private SessionConfig sConf;
		private Network network;
		private MapImage mapImg;
		private MsgListing mListing;
	
	    public Session(SessionConfig scfg, Network net, MapImage map, MsgListing ml)
		{
			this.sConf = scfg;
			this.network = net;
			this.mapImg = map;
			this.mListing = ml;
		}
	
	    public void Start()
	    {
	        _thread = new Thread(DoWork);
	        _thread.Start();
	    }
	
	    public void Pause()
	    {
	        _pauseEvent.Reset();
	    }
	
	    public void Resume()
	    {
	        _pauseEvent.Set();
	    }
	
	    public void Stop()
	    {
	        // Signal the shutdown event
	        _shutdownEvent.Set();
	
	        // Make sure to resume any paused threads
	        _pauseEvent.Set();
	
	        // Wait for the thread to exit
	        _thread.Join();
	    }
	
	    public void DoWork()
	    {
	        while (network.NetworkIterate(sConf.GenPerInterval, sConf.LimitMessages))
	        {
	            _pauseEvent.WaitOne(Timeout.Infinite);
	
	            if (_shutdownEvent.WaitOne(0))
	                break;
				
				this.mapImg.Draw();
				this.mListing.Update();
				
				Thread.Sleep(sConf.Delay);
	        }
	    }
		
		public bool IsWorking()
		{
			return this._thread.IsAlive;
		}

	}
}

