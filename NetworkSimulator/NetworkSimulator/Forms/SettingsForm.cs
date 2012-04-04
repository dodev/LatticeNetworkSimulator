using System;
using System.Windows.Forms;

namespace NetworkSimulator
{
	public partial class SettingsForm : Form
	{
		SessionConfig sConf;
		NetworkConfig nConf;
		VertexConfig vConf;
		
		public bool isOK = false;
		
		public SettingsForm(
			SessionConfig _sConf,
			NetworkConfig _nConf,
			VertexConfig _vConf
			)
		{
			this.InitComponents();
			
			this.sConf = _sConf;
			this.nConf = _nConf;
			this.vConf = _vConf;
			
			// this.setValues();
		}
		
		
		public void SetDefaults()
		{
			this.xNodes.Text = Defaults.HNodes.ToString();
			this.yNodes.Text = Defaults.VNodes.ToString();
			this.maxMsgs.Text = Defaults.sessionCount.ToString();
			this.msgPerInt.Text = Defaults.sessionGenLimit.ToString();
			this.buffer.Text = Defaults.Buffer.ToString();
			this.baseBuf.Text = Defaults.Base.ToString();
			this.delay.Text = Defaults.Delay.ToString();
			this.genPerInt.Text = Defaults.GenLimit.ToString();
		}
		
		public void SetValues()
		{
			this.xNodes.Text = this.nConf.HNodes.ToString();
			this.yNodes.Text = this.nConf.VNodes.ToString();
			this.maxMsgs.Text = this.sConf.LimitMessages.ToString();
			this.msgPerInt.Text = this.sConf.GenPerInterval.ToString();
			this.buffer.Text = this.vConf.Buffer.ToString();
			this.baseBuf.Text = this.vConf.Base.ToString();
			this.delay.Text = this.sConf.Delay.ToString();
			this.genPerInt.Text = this.vConf.GenLimit.ToString();
		}
		
		private void save_onClick(object o, EventArgs e)
		{
			this.vConf.Buffer = int.Parse(this.buffer.Text);
			this.vConf.Base = int.Parse(this.baseBuf.Text);
			this.vConf.GenLimit = int.Parse(this.genPerInt.Text);
			this.nConf.HNodes = int.Parse(this.xNodes.Text);
			this.nConf.VNodes = int.Parse(this.yNodes.Text);
			this.sConf.Delay = int.Parse(this.delay.Text);
			this.sConf.GenPerInterval = int.Parse(this.msgPerInt.Text);
			this.sConf.LimitMessages = int.Parse(this.maxMsgs.Text);
			
			this.isOK = true;
			
			this.Close();
		}
		
		private void defaults_onClick(object o, EventArgs e)
		{
			this.SetDefaults();
		}
	}
}

