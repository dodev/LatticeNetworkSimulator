using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace NetworkSimulator
{
	public class MsgListing
	{
		private List<IListable> msgList;
		private ListView theListView;
		
		public bool Calculate = false;
		
		public MsgListing(List<IListable> mList, ListView lView)
		{
			this.msgList = mList;
			this.theListView = lView;
		}
		
		public void Update()
		{
			if (Calculate)
			{
				this.theListView.Items.Clear();
				
				Message tmp;
				foreach(IListable item in msgList)
				{
					tmp = (Message)item;
					
					theListView.Items.Add(new ListViewItem(new string[]{ 
						tmp.Handler.ToString(),
						tmp.Source.ToString(),
						tmp.Destination.ToString(),
						tmp.CurrentStatus.ToString(),
						tmp.Hops.ToString(),
						tmp.HoldTime.ToString("F2")
					}));
				}
				
				this.theListView.EnsureVisible(this.theListView.Items.Count - 1);
				
				this.theListView.Refresh();
			}
		}
	}
}

