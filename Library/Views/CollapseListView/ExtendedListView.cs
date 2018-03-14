using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Library.Views.CollapseListView
{
	public class ExtendedListView : View
	{
		public static readonly BindableProperty ItemsProperty =
			BindableProperty.Create("Items", typeof(List<EntityClass>), typeof(ExtendedListView), new List<EntityClass>());

		public List<EntityClass> Items
		{
			get { return (List<EntityClass>)GetValue(ItemsProperty); }
			set { SetValue(ItemsProperty, value); }
		}

		public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

		public void NotifyItemSelected(object item)
		{

			if (ItemSelected != null)
				ItemSelected(this, new SelectedItemChangedEventArgs(item));
		}

	}
}
