using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using MvvmHelpers;
namespace Library
{
	public class ViewModelBase: BaseViewModel
	{
		protected Page page;
		protected ContentView view;

		public ViewModelBase()
		{
			

		}
		public ViewModelBase(Page _page)
		{
			this.page = _page;

		}
		public ViewModelBase(ContentView _view)
		{
			this.view = _view;
		}
	}


}
