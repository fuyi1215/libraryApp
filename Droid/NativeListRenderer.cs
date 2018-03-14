using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Library.Droid;
using Android.Widget;
using Android.Views;
using System;
using Library.Views.CollapseListView;

[assembly: ExportRenderer (typeof (ExtendedListView), typeof (NativeExpanderRenderer))]
namespace Library.Droid
{
	public class NativeExpanderRenderer : ViewRenderer<ExtendedListView, global::Android.Widget.ExpandableListView>, ExpandableListView.IOnChildClickListener
	{
		protected override void OnElementChanged (ElementChangedEventArgs<ExtendedListView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				SetNativeControl (new global::Android.Widget.ExpandableListView (Forms.Context));
			}
			if (e.OldElement != null) {
				// unsubscribe
			}
			if (e.NewElement != null) {
				// subscribe
				Control.SetAdapter (new DataAdopter (Forms.Context as Android.App.Activity, e.NewElement.Items));
				Control.SetGroupIndicator (null);
				Control.SetOnChildClickListener (this);
			}
		}

		public bool OnChildClick (ExpandableListView parent, Android.Views.View clickedView, int groupPosition, int childPosition, long id)
		{
			var item = DataAdopter.DataList [groupPosition].ChildItems [childPosition];
			if (item != null) {
				if (item.OnClickListener != null) {
					item.OnClickListener.Invoke (item);
				} else {
					item.IsSelected = !item.IsSelected;
				}
			}
			return false;
		}


	}
}
