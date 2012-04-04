using System;
using System.Windows.Forms;

namespace NetworkSimulator
{
	public partial class MainForm : Form
	{
		MapImage map;
		Network network;
		Session session;
		MsgListing mListing;
		
		SessionConfig sConf;
		NetworkConfig nConf;
		VertexConfig vConf;
		
		SettingsForm sf;
		
		///
		/// Default construcor
		///
		public MainForm()
		{
			this.InitComponents();
			
			this.sConf = new SessionConfig(
				Defaults.Delay,
				Defaults.sessionCount,
				Defaults.sessionGenLimit
			);
			
			this.nConf = new NetworkConfig(
				Defaults.HNodes,
				Defaults.VNodes
			);
			
			this.vConf = new VertexConfig(
				Defaults.Buffer,
				Defaults.Base,
				Defaults.GenLimit,
				Defaults.MaxLoadRatio,
				null // the routing function depends on the network
			);
			
			//this.initSimulation();
		}
		
		private void initSimulation()
		{
			this.network = new Network(
				this.nConf,
				this.vConf
			);
			
			this.map = new MapImage(
				Defaults.MapWidth,
				Defaults.MapHeight,
				nConf.HNodes,
				nConf.VNodes,
				this.picBoxMap
			);
			this.map.InitGraph(
				network.VrtList,
				network.EdgeList
			);
			this.map.SetMsgList( network.MsgList );
			this.picBoxMap.Image = map.Image;
			
			mListing = new MsgListing(this.network.MsgList.TheList, this.listViewMsgs);
			
			this.session = new Session(
				this.sConf,
				this.network,
				this.map,
				this.mListing				
			);
		}
		
		private void buttonTest_OnClick( object o, EventArgs e)
		{			
			this.session.Start();
		}
		
		private bool pauseStart = true;
		
		private void buttonPause_OnClick( object o, EventArgs e)
		{			
			this.session.Pause();
			if (this.pauseStart == true)
			{
				this.session.Pause();
				this.pauseStart = false;
				this.buttonPause.Text = "Resume";
				
				//	disable some of the dangerous buttons
				//this.btnStopCmp.Enabled = false;
				//this.btnCmpVideo.Enabled = false;
			}
			else
			{
				this.session.Resume();
				this.pauseStart= true;
				this.buttonPause.Text = "Pause";
				
				//	disable some of the dangerous buttons
				//this.btnStopCmp.Enabled = true;
				//this.btnCmpVideo.Enabled = true;
			}
		}
		
		private void buttonStop_OnClick( object o, EventArgs e)
		{			
			this.session.Stop();
		}
		
		private void buttonSettings_OnClick( object o, EventArgs e)
		{
			sf = new SettingsForm(sConf, nConf, vConf);
			sf.SetValues();
			sf.ShowDialog();
			
			if (sf.isOK == true)
				this.initSimulation();
		}
		
		private void chkBoxListing_onChkChanged( object o, EventArgs e)
		{
			this.mListing.Calculate = this.chkBoxListing.Checked;
			
			if (this.mListing.Calculate == false)
			{
				this.listViewMsgs.Items.Clear();
			}
			else
			{
				this.mListing.Update();
			}
		}
		
		private void buttonDrawPath_OnClick( object o, EventArgs e)
		{
			ListView.SelectedListViewItemCollection selItems = this.listViewMsgs.SelectedItems;
			
			this.map.DrawPaht(int.Parse(selItems[0].SubItems[0].Text));
			
		}
		
		private void buttonDrawA_OnClick( object o, EventArgs e)
		{
			this.network.Analyze();
			this.map.DrawAnalyticalMap();
		}
		
	}
}

