using Xamarin.Forms;
using Library.Views.CollapseListView;
using Library.iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using System.Drawing;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(RendererListView))]
namespace Library.iOS
{
	
	public class RendererListView : ViewRenderer<ExtendedListView, UITableView>
	{
		public RendererListView()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<ExtendedListView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				
				SetNativeControl(new UITableView()
				{
					BackgroundColor = UIColor.White,
					//RowHeight = NativeListCell.HEIGHT,
					RowHeight = UITableView.AutomaticDimension,
					EstimatedRowHeight = new System.nfloat(40),
					AutoresizingMask = UIViewAutoresizing.FlexibleHeight,
					SeparatorStyle = UITableViewCellSeparatorStyle.None,
					Bounces = true,
					BouncesZoom = true,
					ScrollEnabled = true,

					//SizeExtensions =
					SectionFooterHeight = 0,
					//CGRect
					SectionHeaderHeight = NativeListCell.HEIGHT,

					//The following two lines are written to disable the default behaviour of section header movement with cells
					TableHeaderView = new UIView(new CGRect(0, 0, 100, NativeListCell.HEIGHT)),
					ContentInset = new UIEdgeInsets(-NativeListCell.HEIGHT, 0, 0, 0)
				});
			}

			if (e.OldElement != null)
			{
				// unsubscribe
			}

			if (e.NewElement != null)
			{
				
				// subscribe
				var s = new SettingsListSource(e.NewElement);
				Control.Source = s;

				//Control.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == ExtendedListView.ItemsProperty.PropertyName)
			{
				
				// update the Items list in the UITableViewSource
				var s = new SettingsListSource(Element);
				Control.Source = s;
				//Control.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
			}
		}

		public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			//Control.SizeToFit();
			return Control.GetSizeRequest(widthConstraint, heightConstraint, 44, 44);
		}
	}

}
