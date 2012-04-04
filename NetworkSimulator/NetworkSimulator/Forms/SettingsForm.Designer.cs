namespace NetworkSimulator
{
	public partial class SettingsForm
	{
		/// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }
		
		/// <summary>
		/// Initializes the components of the Form 
		/// </summary>
		private void InitComponents()
		{
			this.mainGroup = new System.Windows.Forms.GroupBox();
			this.mainGroup.SuspendLayout();
			this.xNodes = new System.Windows.Forms.NumericTextBox();
			this.yNodes = new System.Windows.Forms.NumericTextBox();
			this.maxMsgs = new System.Windows.Forms.NumericTextBox();
			this.msgPerInt = new System.Windows.Forms.NumericTextBox();
			this.buffer = new System.Windows.Forms.NumericTextBox();
			this.baseBuf = new System.Windows.Forms.NumericTextBox();
			this.delay = new System.Windows.Forms.NumericTextBox();
			this.genPerInt = new System.Windows.Forms.NumericTextBox();
			this.lblBase = new System.Windows.Forms.Label();
			this.lblBuffer = new System.Windows.Forms.Label();
			this.lblMaxMsgs = new System.Windows.Forms.Label();
			this.lblMsgPerInt = new System.Windows.Forms.Label();
			this.lblXNodes = new System.Windows.Forms.Label();
			this.lblYNodes = new System.Windows.Forms.Label();
			this.lblDelay = new System.Windows.Forms.Label();
			this.lblGPI = new System.Windows.Forms.Label();
			this.save = new System.Windows.Forms.Button();
			this.defaults = new System.Windows.Forms.Button();
			this.SuspendLayout();
			
			//
			// xNodes
			//
			this.xNodes.Location = new System.Drawing.Point(15, 20);
			this.xNodes.Size = new System.Drawing.Size(80, 20);
			this.xNodes.TabStop = true;
			this.xNodes.Name = "xNodes";
			
			//
			// lblXNodes
			//
			this.lblXNodes.Location = new System.Drawing.Point(105, 22);
			this.lblXNodes.Size = new System.Drawing.Size(100, 20);
			this.lblXNodes.Text = "X nodes";
			this.lblXNodes.TabStop = false;
			
			//
			// yNodes
			//
			this.yNodes.Location = new System.Drawing.Point(15, 50);
			this.yNodes.Size = new System.Drawing.Size(80, 20);
			this.yNodes.TabStop = true;
			this.yNodes.Name = "yNodes";
			
			//
			// lblYNodes
			//
			this.lblYNodes.Location = new System.Drawing.Point(105, 52);
			this.lblYNodes.Size = new System.Drawing.Size(100, 20);
			this.lblYNodes.Text = "Y nodes";
			this.lblYNodes.TabStop = false;
			
			//
			// maxMsgs
			//
			this.maxMsgs.Location = new System.Drawing.Point(15, 80);
			this.maxMsgs.Size = new System.Drawing.Size(80, 20);
			this.maxMsgs.TabStop = true;
			this.maxMsgs.Name = "maxMsgs";
			
			//
			// lblMaxMsgs
			//
			this.lblMaxMsgs.Location = new System.Drawing.Point(105, 82);
			this.lblMaxMsgs.Size = new System.Drawing.Size(100, 20);
			this.lblMaxMsgs.Text = "Max messages";
			this.lblMaxMsgs.TabStop = false;
			
			//
			// msgPerInt
			//
			this.msgPerInt.Location = new System.Drawing.Point(15, 110);
			this.msgPerInt.Size = new System.Drawing.Size(80, 20);
			this.msgPerInt.TabStop = true;
			this.msgPerInt.Name = "msgPerInt";
			
			//
			// lblMsgPerInt
			//
			this.lblMsgPerInt.Location = new System.Drawing.Point(105, 112);
			this.lblMsgPerInt.Size = new System.Drawing.Size(100, 20);
			this.lblMsgPerInt.Text = "Messages per interval";
			this.lblMsgPerInt.TabStop = false;
			
			//
			// buffer
			//
			this.buffer.Location = new System.Drawing.Point(15, 140);
			this.buffer.Size = new System.Drawing.Size(80, 20);
			this.buffer.TabStop = true;
			this.buffer.Name = "buffer";
			
			//
			// lblBuffer
			//
			this.lblBuffer.Location = new System.Drawing.Point(105, 142);
			this.lblBuffer.Size = new System.Drawing.Size(100, 20);
			this.lblBuffer.Text = "Buffer";
			this.lblBuffer.TabStop = false;
			
			//
			// baseBuf
			//
			this.baseBuf.Location = new System.Drawing.Point(15, 170);
			this.baseBuf.Size = new System.Drawing.Size(80, 20);
			this.baseBuf.TabStop = true;
			this.baseBuf.Name = "baseBuf";
			
			//
			// lblBase
			//
			this.lblBase.Location = new System.Drawing.Point(105, 172);
			this.lblBase.Size = new System.Drawing.Size(100, 20);
			this.lblBase.Text = "Base buffer";
			this.lblBase.TabStop = false;
			
			//
			//	delay
			//
			this.delay.Location = new System.Drawing.Point(15, 200);
			this.delay.Size = new System.Drawing.Size(80, 20);
			this.delay.TabStop = true;
			
			//
			//	lblDelay
			//
			this.lblDelay.Location = new System.Drawing.Point( 105, 202);
			this.lblDelay.Size = new System.Drawing.Size(100, 20);
			this.lblDelay.Text = "Delay(ms)";
			this.lblDelay.TabStop = false;
			
			//
			//	genPerInt
			//
			this.genPerInt.Location = new System.Drawing.Point(15, 230);
			this.genPerInt.Size = new System.Drawing.Size(80, 20);
			this.genPerInt.TabStop = true;
			
			//
			//	lblGPI
			//
			this.lblGPI.Location = new System.Drawing.Point( 105, 232);
			this.lblGPI.Size = new System.Drawing.Size(150, 20);
			this.lblGPI.Text = "Generated/inerval in a node";
			this.lblGPI.TabStop = false;
			
			//
			// mainGroup
			//
			this.mainGroup.Location = new System.Drawing.Point(5,5);
			this.mainGroup.Size = new System.Drawing.Size(260,255);
			this.mainGroup.Name = "mainGroup";
			this.mainGroup.Text = "";
			this.mainGroup.ResumeLayout( false );
			
			//
			// save
			//
			this.save.Location = new System.Drawing.Point(30, 265);
			this.save.Size = new System.Drawing.Size(100, 25);
			this.save.Text = "Save and apply";
			this.save.Click += new System.EventHandler(this.save_onClick);
			
			//
			// default
			//
			this.defaults.Location = new System.Drawing.Point(140, 265);
			this.defaults.Size = new System.Drawing.Size(100, 25);
			this.defaults.Text = "Defaults";
			this.defaults.Click += new System.EventHandler(this.defaults_onClick);
			
			
			//
			// SettingsForm
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.MaximizeBox = false;
			this.ClientSize = new System.Drawing.Size( 270, 300);
			this.Name = "SettingsForm";
			this.Text = "Network Simulator - Settings";
			this.Controls.Add(this.xNodes);
			this.Controls.Add(this.lblXNodes);
			this.Controls.Add(this.yNodes);
			this.Controls.Add(this.lblYNodes);
			this.Controls.Add(this.maxMsgs);
			this.Controls.Add(this.lblMaxMsgs);
			this.Controls.Add(this.msgPerInt);
			this.Controls.Add(this.lblMsgPerInt);
			this.Controls.Add(this.buffer);
			this.Controls.Add(this.lblBuffer);
			this.Controls.Add(this.baseBuf);
			this.Controls.Add(this.lblBase);
			this.Controls.Add(this.delay);
			this.Controls.Add(this.lblDelay);
			this.Controls.Add(this.genPerInt);
			this.Controls.Add(this.lblGPI);
			this.Controls.Add(this.mainGroup);
			this.Controls.Add(this.save);
			this.Controls.Add(this.defaults);
			this.ResumeLayout( false );
            this.PerformLayout();
		}
		
		private System.Windows.Forms.GroupBox mainGroup;
		private System.Windows.Forms.NumericTextBox xNodes;
		private System.Windows.Forms.NumericTextBox yNodes;
		private System.Windows.Forms.NumericTextBox maxMsgs;
		private System.Windows.Forms.NumericTextBox msgPerInt;
		private System.Windows.Forms.NumericTextBox buffer;
		private System.Windows.Forms.NumericTextBox baseBuf;
		private System.Windows.Forms.NumericTextBox genPerInt;
		private System.Windows.Forms.NumericTextBox delay;
		private System.Windows.Forms.Label lblXNodes;
		private System.Windows.Forms.Label lblYNodes;
		private System.Windows.Forms.Label lblMaxMsgs;
		private System.Windows.Forms.Label lblMsgPerInt;
		private System.Windows.Forms.Label lblBase;
		private System.Windows.Forms.Label lblBuffer;
		private System.Windows.Forms.Label lblDelay;
		private System.Windows.Forms.Label lblGPI;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button defaults;
	}
}
