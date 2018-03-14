using System;
using UIKit;
using CoreGraphics;
using Library.Views.CollapseListView;

namespace Library.iOS
{
	
	   public class NativeListCell : UITableViewCell
	{

		private static bool isIpad = AppDelegate.DeviceType == Enums.DeviceType.IPAD;
		public static int HEIGHT { set; get; } = 400;
		public static int ParentItemLeftPadding = 20;
		public static int ChildItemLeftPadding = 25;
		public static int FontSize = 12;

		//public static float HEIGHT = (int)(Math.Min(AppDelegate.DeviceWidth, AppDelegate.DeviceHeight) / 4);
		public static float WIDTH = (int)(Math.Min(AppDelegate.DeviceWidth, AppDelegate.DeviceHeight) / 2);

		UIView seperatorLine { get; set; }

		public UILabel lbl_Title { get; set; }


		public UIButton btnApply { get; set; }

		public UIImageView img_RightIcon { get; set; }


		public bool IsSelected { get; set; }

		public string Title
		{
			set
			{
				lbl_Title.Text = value;

			}
			get
			{
				return lbl_Title.Text;
			}
		}


		public NativeListCell()
		{
			
		}
		public NativeListCell(UITableViewCellStyle style, string identifier, CGRect tblFrame, nfloat height) : base(style, identifier)
		{
			if (tblFrame != null)
			{
				WIDTH = (float)tblFrame.Width;
			}

			//var HEIGHT = (int)80;


			BackgroundColor = UIColor.Clear;

			//ContentView.Frame = new CGRect(0, 0, WIDTH, HEIGHT);

			ContentView.BackgroundColor = UIColor.FromRGB(242, 242, 242);
			//ContentView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
			//UIView SubContainerView = new UIView(ContentView.Frame);
			//SubContainerView.ClipsToBounds = true;
			//SubContainerView.BackgroundColor = UIColor.Green;
			//	seperatorLine = new UIView(new CGRect(0, HEIGHT - 1, WIDTH, 1));
			//	seperatorLine.BackgroundColor = UIColor.LightGray;
			//	seperatorLine.Alpha = 0.3f;
			//seperatorLine.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
			//

			lbl_Title = new UILabel(new CGRect(0, ContentView.Frame.Y, WIDTH,1));
			//lbl_Title = new UILabel();
			lbl_Title.TextColor = UIColor.White;
			lbl_Title.Font = UIFont.BoldSystemFontOfSize(FontSize);
			lbl_Title.LineBreakMode = UILineBreakMode.WordWrap;
			lbl_Title.Lines = 0;



			//lbl_Title.AdjustsFontSizeToFitWidth = true;
			lbl_Title.BackgroundColor = UIColor.LightGray;
			//lbl_Title.SizeToFit();
			//var asf = lbl_Title.HeightAnchor;
			//HEIGHT = (int) lbl_Title.Frame.Y;
			//btnApply = new UIButton();
			//btnApply.SetTitle("Apply", UIControlState.Normal);
			//btnApply.SetTitleColor(UIColor.White, UIControlState.Normal);
			//btnApply.BackgroundColor = UIColor.FromRGB(207, 10, 44);
			//btnApply.AutoresizingMask = UIViewAutoresizing.All;
			//img_RightIcon = new UIImageView(new CGRect(
			//	ContentView.Frame.Width - NativeListCell.HEIGHT - 20,
			//	0,
			//	NativeListCell.HEIGHT,
			//	NativeListCell.HEIGHT
			//));
			//img_RightIcon.ContentMode = UIViewContentMode.Center;
			//img_RightIcon.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin;

			//SubContainerView.AddSubview(btnApply);
			//ContentView.SizeToFit();
			//lbl_Title.AutosizesSubviews = true;
			//lbl_Title.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

			//SubContainerView.AddSubview();
			//SubContainerView.AddSubview(seperatorLine);
			//SubContainerView.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
			//SubContainerView.AddSubview(img_RightIcon);
			//lbl_Title.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
			//lbl_Title.SizeToFit();
			ContentView.AddSubview(lbl_Title);

			//
		}
	}


}
