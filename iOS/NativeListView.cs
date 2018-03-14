using System;
using CoreGraphics;
using UIKit;
using System.Collections.Generic;
using Foundation;
using System.Linq;
using Library.Views.CollapseListView;


namespace Library.iOS
{



	public class SettingsListSource : UITableViewSource
	{
		public static List<EntityClass> Settings { get; set; }

		protected string cellIdentifier = typeof(NativeListCell).Name;

		public SettingsListSource()
		{
			Settings = new List<EntityClass>();
		}

		//		public SettingsListSource (List<EntityClass> data)
		//		{
		//			Settings = data;
		//		}

		public SettingsListSource(ExtendedListView data)
		{
			Settings = data.Items.ToList();
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return (nint)Settings.Count();
		}

		public override string TitleForHeader(UITableView tableView, nint section)
		{
			return Settings[(int)section].Title;
		}
		public override string TitleForFooter(UITableView tableView, nint section)
		{
			return Settings[(int)section].Description;
		}

		public override nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			return 70;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			if (Settings[(int)section].IsSelected)
			{
				return (nint)(Settings[(int)section].ChildItems != null ? Settings[(int)section].ChildItems.Count : 0);
			}
			else {
				return 0;
			}
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			if (OnRowSelected != null)
			{
				OnRowSelected(this, new RowSelectedEventArgs(tableView, indexPath));
			}

			//Code to change the status of the right icon in the row items		
			var item = Settings[indexPath.Section].ChildItems[indexPath.Row];
			if (item != null)
			{

				if (item.OnClickListener != null)
				{
					item.OnClickListener.Invoke(item);
				}
				else {
					item.IsSelected = !item.IsSelected;
				}
				tableView.ReloadSections(NSIndexSet.FromIndex(indexPath.Section), UITableViewRowAnimation.Automatic);


			}
			tableView.DeselectRow(indexPath, true);

		}

		//	public override UIView 
		//	{

		//}  

		private const float HEIGHT = 70;
		//private nfloat height { get; set; }
		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			var btn = new UIButton(new CGRect(0, 0, tableView.Frame.Width, HEIGHT));
			btn.TitleEdgeInsets = new UIEdgeInsets(btn.TitleEdgeInsets.Top, NativeListCell.ParentItemLeftPadding, btn.TitleEdgeInsets.Bottom, btn.TitleEdgeInsets.Right);
			btn.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			//ADD SEPERATOR LINE AT BOTTOM
			var seperatorLine = new UIView(new CGRect(0, HEIGHT - 1, tableView.Frame.Width, 1));
			seperatorLine.BackgroundColor = UIColor.LightGray;
			seperatorLine.Alpha = 0.3f;
			seperatorLine.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			btn.AddSubview(seperatorLine);

			btn.SetTitle(Settings[(int)section].Title, UIControlState.Normal);
			btn.Font = UIFont.BoldSystemFontOfSize(NativeListCell.FontSize);
			btn.BackgroundColor = UIColor.Clear;
			btn.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			btn.SetTitleColor(UIColor.DarkGray, UIControlState.Normal);
			btn.TouchUpInside += (sender, e) =>
			{
				//put in your code to toggle your boolean value here
				if (Settings[(int)section].OnClickListener != null)
				{
					Settings[(int)section].OnClickListener.Invoke(Settings[(int)section]);

				}

				Settings[(int)section].IsSelected = !Settings[(int)section].IsSelected;



				//reload this section
				tableView.ReloadSections(NSIndexSet.FromIndex(section), UITableViewRowAnimation.Automatic);
				//tableView.RowHeight = height;
				//tableView.r
				//tableView.VisibleCells[1].SizeToFit();
				//tableView.AutosizesSubviews = true;
				//tableView.ReloadData();


			};

			//tableView.DataSource = new GrowRowTableDataSource(this);
			//TableView.Delegate = new GrowRowTableDelegate(this);
			//tableView.RowHeight = UITableView.AutomaticDimension;
			//tableView.EstimatedRowHeight = 40f;
			//tableView.ReloadData();
			//
			//tableView.RowHeight = height;
			//tableView.SizeToFit();
			return btn;
		}


		public class RowSelectedEventArgs : EventArgs
		{
			public UITableView tableView { get; set; }

			public NSIndexPath indexPath { get; set; }

			public RowSelectedEventArgs(UITableView tableView, NSIndexPath indexPath) : base()
			{
				this.tableView = tableView;

				this.indexPath = indexPath;
			}
		}

		public event EventHandler<RowSelectedEventArgs> OnRowSelected;

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{

			var item = Settings[indexPath.Section].ChildItems[indexPath.Row];
			var cell = (NativeListCell)tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
				cell = new NativeListCell(UITableViewCellStyle.Default, cellIdentifier, tableView.Frame, UITableView.AutomaticDimension);
			//cell.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
			//tableView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
			cell.Title = item.Title;

			//cell.Description = item.Description;

			//if (!string.IsNullOrEmpty(item.SelectedStateIcon) && !string.IsNullOrEmpty(item.DeselectedStateIcon))
			//{
			//	cell.img_RightIcon.Image = !item.IsSelected ? UIImage.FromBundle(item.DeselectedStateIcon) : UIImage.FromBundle(item.SelectedStateIcon);
			//	cell.img_RightIcon.Hidden = false;
			//}
			//else {
			//	cell.img_RightIcon.Hidden = true;
			//}
			cell.lbl_Title.SizeToFit();
			var frame = cell.lbl_Title.Frame;
			tableView.RowHeight = frame.Height;
			//cell.lbl_Title.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
			//cell.AutoresizingMask = UIViewAutoresizing.All;
			//height = cell.lbl_Title.IntrinsicContentSize.Height * 5;
			//cell.lbl_Title.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
			//tableView.AutoresizingMask = UIViewAutoresizing.All;
			return cell;
		}




	}


}

