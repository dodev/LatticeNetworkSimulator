namespace NetworkSimulator
{
	public partial class MainForm
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
			this.groupBoxImages = new System.Windows.Forms.GroupBox();
			this.groupBoxImages.SuspendLayout();
			this.groupBoxControls = new System.Windows.Forms.GroupBox();
			this.groupBoxControls.SuspendLayout();
			this.groupBoxConsole = new System.Windows.Forms.GroupBox();
			this.groupBoxConsole.SuspendLayout();
			this.picBoxMap = new System.Windows.Forms.PictureBox();
			//this.comboBoxDimensions = new System.Windows.Forms.ComboBox();
			//this.labelDim = new System.Windows.Forms.Label();
			//this.textBoxNumPkg = new System.Windows.Forms.TextBox();
			this.buttonSettings = new System.Windows.Forms.Button();
			this.buttonTest = new System.Windows.Forms.Button();
			this.buttonPause = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.listBoxConsole = new System.Windows.Forms.ListBox();
			this.listViewMsgs = new System.Windows.Forms.ListView();
			this.cHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chkBoxListing = new System.Windows.Forms.CheckBox();
			this.lblListing = new System.Windows.Forms.Label();
			this.buttonDrawPath = new System.Windows.Forms.Button();			
			this.buttonDrawA = new System.Windows.Forms.Button();
			this.SuspendLayout();
			
			//
			// buttonSettings
			//
			this.buttonSettings.Location = new System.Drawing.Point( 845, 30 );
			this.buttonSettings.Size = new System.Drawing.Size( 160, 25 );
			this.buttonSettings.Text = "New";
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_OnClick);
			
			//
			// buttonTest
			//
			this.buttonTest.Location = new System.Drawing.Point( 845, 60 );
			this.buttonTest.Size = new System.Drawing.Size( 160, 25 );
			this.buttonTest.Text = "Start";
			this.buttonTest.Name = "buttonTest";
			this.buttonTest.Click += new System.EventHandler(this.buttonTest_OnClick);
			
			//
			// buttonPause
			//
			this.buttonPause.Location = new System.Drawing.Point( 845, 90 );
			this.buttonPause.Size = new System.Drawing.Size( 160, 25 );
			this.buttonPause.Text = "Pause";
			this.buttonPause.Name = "buttonPause";
			this.buttonPause.Click += new System.EventHandler(this.buttonPause_OnClick);
			
			//
			// buttonStop
			//
			this.buttonStop.Location = new System.Drawing.Point( 845, 120 );
			this.buttonStop.Size = new System.Drawing.Size( 160, 25 );
			this.buttonStop.Text = "Stop";
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_OnClick);
			
			//
			// buttonDrawPath
			//
			this.buttonDrawPath.Location = new System.Drawing.Point(845, 155);
			this.buttonDrawPath.Size = new System.Drawing.Size( 160, 25 );
			this.buttonDrawPath.Text = "Draw path";
			this.buttonDrawPath.Name = "buttonDrawPath";
			this.buttonDrawPath.Click += new System.EventHandler(this.buttonDrawPath_OnClick);
			
			//
			// buttonDrawA
			//
			this.buttonDrawA.Location = new System.Drawing.Point(845, 185);
			this.buttonDrawA.Size = new System.Drawing.Size( 160, 25 );
			this.buttonDrawA.Text = "Draw analytical";
			this.buttonDrawA.Name = "buttonDrawA";
			this.buttonDrawA.Click += new System.EventHandler(this.buttonDrawA_OnClick);
			
			//
			// chkBoxListing
			//
			this.chkBoxListing.Location = new System.Drawing.Point(845, 210);
			this.chkBoxListing.CheckedChanged += new System.EventHandler(this.chkBoxListing_onChkChanged);
			
			//
			// lblListing
			//
			this.lblListing.Location = new System.Drawing.Point(875, 212);
			this.lblListing.AutoSize = true;
			this.lblListing.Size = new System.Drawing.Size(20, 120);
			this.lblListing.Text = "List messages";
			
			//
			// listViewMsgs
			//
			this.listViewMsgs.Location = new System.Drawing.Point( 835, 240 );
			this.listViewMsgs.Size = new System.Drawing.Size( 260, 390 );
			this.listViewMsgs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]{
				this.cHeader0,
				this.cHeader1,
				this.cHeader2,
				this.cHeader3,
				this.cHeader4,
				this.cHeader5
			});
			this.listViewMsgs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewMsgs.FullRowSelect = true;
            this.listViewMsgs.GridLines = true;
			this.listViewMsgs.UseCompatibleStateImageBehavior = false;
            this.listViewMsgs.View = System.Windows.Forms.View.Details;
			this.listViewMsgs.MultiSelect = false;
			//this.listBoxConsole.Name = "listBoxConsole";
			
			//
			// cHeader0
			//
			this.cHeader0.Text = "#";
			this.cHeader0.Width = 30;
			//
			// cHeader1
			//
			this.cHeader1.Text = "src";
			this.cHeader1.Width = 30;
			//
			// cHeader2
			//
			this.cHeader2.Text = "dst";
			this.cHeader2.Width = 30;
			//
			// cHeader3
			//
			this.cHeader3.Text = "status";
			this.cHeader3.Width = 74;
			//
			// cHeader4
			//
			this.cHeader4.Text = "hps";
			this.cHeader4.Width = 32;
			//
			// cHeader5
			//
			this.cHeader5.Text = "hlt";
			this.cHeader5.Width = 36;
			
			
			//
			// picBoxMap
			//
			this.picBoxMap.Location = new System.Drawing.Point( 20, 25 );
			this.picBoxMap.Size = new System.Drawing.Size( Defaults.MapWidth, Defaults.MapHeight );
			this.picBoxMap.TabStop = false;
			this.picBoxMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			//this.picBoxMap.Image = new System.Drawing.Bitmap( "default.png" ); TODO: add initializing function and check in case of broken path to file.
			
			/*
			//
			// comboBoxDimensions
			//
			this.comboBoxDimensions.Location = new System.Drawing.Point( 845, 50 );
			this.comboBoxDimensions.Size = new System.Drawing.Size( 160, 25 );
			this.comboBoxDimensions.Name = "comboBoxDimensions";
			this.comboBoxDimensions.FormattingEnabled = false;
			// TODO: да махна възможността за въвеждане на текст в полето
			
			//
			// labelDim
			//
			this.labelDim.Location = new System.Drawing.Point( 845, 30 );
			this.labelDim.AutoSize = true;
			this.labelDim.Text = "Dimensions:";
			this.labelDim.Name = "labelDim";
			
			//
			// textBoxNumPkg
			//
			this.textBoxNumPkg.Location = new System.Drawing.Point( 845, 105 );
			this.textBoxNumPkg.Size = new System.Drawing.Size( 160, 25 );
			this.textBoxNumPkg.Name = "textBoxNumPkg";
			*/
			//
			// listBoxConsole
			//
			this.listBoxConsole.Location = new System.Drawing.Point( 15, 645 );
			this.listBoxConsole.Size = new System.Drawing.Size( 995, 115 );
			this.listBoxConsole.Name = "listBoxConsole";
			
			//
			// groupBoxImages 
			//
			this.groupBoxImages.Location = new System.Drawing.Point( 10, 10 );
			this.groupBoxImages.Size = new System.Drawing.Size( 820, 620 );
			this.groupBoxImages.Name = "groupBoxImages";
			this.groupBoxImages.Text = "Map";
			this.groupBoxImages.ResumeLayout( false );
			
			
			//
			// groupBoxControls
			//
			this.groupBoxControls.Location = new System.Drawing.Point( 835, 10 );
			this.groupBoxControls.Size = new System.Drawing.Size( 260, 620 );
			this.groupBoxControls.Name = "groupBoxControls";
			this.groupBoxControls.Text = "Controls";
			this.groupBoxControls.ResumeLayout( false );
			
			//
			// groupBoxConsole
			//
			this.groupBoxConsole.Location = new System.Drawing.Point( 10, 630 );
			this.groupBoxConsole.Size = new System.Drawing.Size( 1005, 130 );
			this.groupBoxConsole.Name = "groupBoxConsole";
			this.groupBoxConsole.Text = "Console";
			this.groupBoxConsole.ResumeLayout( false );
			
			//
			// MainForm
			//
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.MaximizeBox = false;
			this.ClientSize = new System.Drawing.Size( 1100, 768 );
			this.Name = "MainForm";
			this.Text = "Network Simulator";
			this.Controls.Add( this.buttonSettings );
			this.Controls.Add( this.buttonTest );
			this.Controls.Add( this.buttonPause );
			this.Controls.Add( this.buttonStop );
			this.Controls.Add( this.buttonDrawPath );
			this.Controls.Add( this.buttonDrawA );
			this.Controls.Add( this.picBoxMap );
			//this.Controls.Add( this.comboBoxDimensions );
			//this.Controls.Add( this.labelDim );
			//this.Controls.Add( this.textBoxNumPkg );
			this.Controls.Add( this.listBoxConsole );
			this.Controls.Add( this.listViewMsgs );
			this.Controls.Add(this.chkBoxListing);
			this.Controls.Add(this.lblListing);
			this.Controls.Add( this.groupBoxImages );
			this.Controls.Add( this.groupBoxControls );
			this.Controls.Add( this.groupBoxConsole );
			this.ResumeLayout( false );
            this.PerformLayout();
			
		}
		
		private System.Windows.Forms.GroupBox groupBoxImages;
		private System.Windows.Forms.GroupBox groupBoxControls;
		private System.Windows.Forms.GroupBox groupBoxConsole;
		private System.Windows.Forms.PictureBox picBoxMap;
		//private System.Windows.Forms.ComboBox comboBoxDimensions;
		//private System.Windows.Forms.Label labelDim;
		//private System.Windows.Forms.TextBox textBoxNumPkg;
		private System.Windows.Forms.Button buttonTest;
		private System.Windows.Forms.Button buttonSettings;
		private System.Windows.Forms.Button buttonPause;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.ListBox listBoxConsole;
		private System.Windows.Forms.ListView listViewMsgs;
		private System.Windows.Forms.ColumnHeader cHeader0;
		private System.Windows.Forms.ColumnHeader cHeader1;
		private System.Windows.Forms.ColumnHeader cHeader2;
		private System.Windows.Forms.ColumnHeader cHeader3;
		private System.Windows.Forms.ColumnHeader cHeader4;
		private System.Windows.Forms.ColumnHeader cHeader5;
		private System.Windows.Forms.CheckBox chkBoxListing;
		private System.Windows.Forms.Label lblListing;
		private System.Windows.Forms.Button buttonDrawPath;
		private System.Windows.Forms.Button buttonDrawA;
	}
}
