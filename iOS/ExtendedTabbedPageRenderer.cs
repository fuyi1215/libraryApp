﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using TabbedPageDemo.iOS;
using CoreGraphics;
using Library.iOS;

using System.Reflection;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace TabbedPageDemo.iOS
{

    public class ExtendedTabbedPageRenderer : TabbedRenderer
    {
        //public static nfloat TabHeight = 40;

        //TabbedPage _tabbedPage;
        //UIScrollView _tabScrollView;

        //CustomTabButton[] customButtonArray;
        //Dictionary<int, Page> pagesDictionary;



        //#region Overrides

        //public override void ViewDidLoad()
        //{
        //    base.ViewDidLoad();

        //    // Remove Tabbar since we made our own. Comment out if you want to see it
        //    this.TabBar.RemoveFromSuperview();
        //}

        //protected override void OnElementChanged(VisualElementChangedEventArgs e)
        //{
        //    base.OnElementChanged(e);

        //    _tabbedPage = e.NewElement as TabbedPage;
        //    _tabbedPage.PagesChanged += TabbedPagePagesChanged;
        //    _tabbedPage.CurrentPageChanged += TabbedPageCurrentPageChanged;
        //    View.BackgroundColor = UIColor.LightGray;

        //    // create our scroll view which will hold all our tabs 
        //    _tabScrollView = new UIScrollView(new CGRect(0, View.Frame.Top, View.Frame.Width, TabHeight));
        //    _tabScrollView.BackgroundColor = UIColor.Green;

        //    View.AddSubview(_tabScrollView);
        //    View.BringSubviewToFront(_tabScrollView);

        //    if (_tabbedPage != null)
        //    {
        //        // Let's Create Buttons for our tabs and any other statefulness needed
        //        RefreshTabs();
        //    }
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (_tabbedPage != null)
        //        {
        //            _tabbedPage.PagesChanged -= TabbedPagePagesChanged;
        //            _tabbedPage.CurrentPageChanged -= TabbedPageCurrentPageChanged;
        //        }
        //    }

        //    base.Dispose(disposing);
        //}

        //#endregion

        //#region Handlers

        //void TabbedPagePagesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    RefreshTabs();
        //}

        //void TabbedPageCurrentPageChanged(object sender, EventArgs e)
        //{
        //    //update the tab button (if needed)
        //    updateTabButtonForCurrentPage();
        //}

        //void HandleTouchUpInside(object sender, EventArgs e)
        //{
        //    var btn = sender as CustomTabButton;
        //    selectTabButton(btn);
        //}

        //#endregion

        ///// <summary>
        ///// Loop through our list of tabs and create a UIButton to represent each one. Add this button to our tabsScrollView
        ///// We also update the content size property of our scroll view as we add buttons
        ///// </summary>
        //void RefreshTabs()
        //{
        //    if (customButtonArray != null)
        //    {
        //        foreach (var button in customButtonArray)
        //        {
        //            button.TouchUpInside -= HandleTouchUpInside;
        //            button.RemoveFromSuperview();
        //            button.Dispose();
        //        }
        //    }

        //    // lets also get a dictionary with index-values and X.Forms Pages for the different content pages we've defined for our TabbedPage - we will use this to change the displayed page based on the selected tab
        //    pagesDictionary = new Dictionary<int, Page>();

        //    if (_tabbedPage.Children != null && _tabbedPage.Children.Count > 0)
        //    {
        //        nfloat contentOffset = 0f;
        //        customButtonArray = new CustomTabButton[_tabbedPage.Children.Count];

        //        for (var tabIndex = 0; tabIndex < _tabbedPage.Children.Count; tabIndex++)
        //        {
        //            var childTab = _tabbedPage.Children[tabIndex];
        //            var btn = new CustomTabButton();
        //            btn.SetTitle(childTab.Title.ToUpper(), UIControlState.Normal);
        //            btn.SetTitleColor(UIColor.Black, UIControlState.Normal);
        //            btn.SetTitleColor(UIColor.Red, UIControlState.Highlighted);

        //            btn.Tag = (nint)tabIndex; // set the tag of the button to correspond to the tab index for use in click handling
        //            btn.TouchUpInside += HandleTouchUpInside;

        //            if (CustomTabButton.MinimumWidth * _tabbedPage.Children.Count < _tabScrollView.Frame.Width)
        //            {
        //                btn.SetButtonWidth((float)_tabScrollView.Frame.Width / _tabbedPage.Children.Count);
        //            }

        //            btn.Frame = new CGRect(contentOffset, 0, btn.Frame.Width, btn.Frame.Height);
        //            contentOffset += btn.Frame.Size.Width; // update this value each time we are adding a new button

        //            customButtonArray.SetValue(btn, tabIndex);
        //            _tabScrollView.AddSubview(btn);

        //            //keep track of the index <-> page link
        //            pagesDictionary.Add(tabIndex, childTab);
        //        }

        //        _tabScrollView.ContentSize = new CGSize(contentOffset, _tabScrollView.Frame.Height); // update the content size of our scroll view to allow for scrolling

        //        var selectedBtn = GetButtonForCurrentPage();

        //        if (selectedBtn != null)
        //        {
        //            selectTabButton(selectedBtn);
        //        }
        //    }
        //}

        //void updateTabButtonForCurrentPage()
        //{
        //    //see if the page has already been selected and if not do so
        //    if (customButtonArray != null && pagesDictionary != null)
        //    {
        //        var btn = GetButtonForCurrentPage();

        //        if (!btn.IsSelected)
        //        {
        //            selectTabButton(btn);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Updates all the buttons and gives the selected one its selected appearence
        ///// </summary>
        ///// <param name="btn">Button.</param>
        //protected void selectTabButton(CustomTabButton btn)
        //{
        //    if (btn != null)
        //    {
        //        btn.SetButtonSelected();

        //        foreach (var button in customButtonArray)
        //        {
        //            if (button != btn)
        //            {
        //                button.SetButtonDeselected();
        //            }
        //        }

        //        _tabScrollView.ScrollRectToVisible(btn.Frame, true);

        //        HandleCurrentPageChanged((int)btn.Tag);
        //    }
        //}

        //// Sets the content to the new page
        //void HandleCurrentPageChanged(int key)
        //{
        //    _tabbedPage.CurrentPage = pagesDictionary[key];
        //}

        //CustomTabButton GetButtonForCurrentPage()
        //{
        //    if (_tabbedPage.CurrentPage != null)
        //    {
        //        return customButtonArray[_tabbedPage.Children.IndexOf(_tabbedPage.CurrentPage)];
        //    }

        //    return null;
        //}
    


        //UITabBarItemEventArgs 
        //{

        //}
        public ExtendedTabbedPageRenderer() : base()
        {


        }
              //public override void ViewWillLayoutSubviews()
              //{
              //    base.ViewWillLayoutSubviews();

              //    this.TabBar.InvalidateIntrinsicContentSize();

              //    nfloat tabSize = 44.0f;

              //    UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

              //    if (UIInterfaceOrientation.LandscapeLeft == orientation || UIInterfaceOrientation.LandscapeRight == orientation)
              //    {
              //        tabSize = 32.0f;
              //    }

              //    CGRect tabFrame = this.TabBar.Frame;

              //    tabFrame.Height = tabSize;

              //    tabFrame.Y = this.View.Frame.Y;

              //    this.TabBar.Frame = tabFrame;



              //    this.TabBar.ContentMode = UIViewContentMode.Bottom;

              //    // Set the translucent property to NO then back to YES to
              //    // force the UITabBar to reblur, otherwise part of the
              //    // new frame will be completely transparent if we rotate
              //    // from a landscape orientation to a portrait orientation.

              //    this.TabBar.Translucent = false;
              //    this.TabBar.Translucent = true;


              //    this.TabBar.SetNeedsUpdateConstraints();

              //}

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {

        	base.OnElementChanged(e);
        	// Set Text Font for unselected tab states
        	UITextAttributes normalTextAttributes = new UITextAttributes();
        	normalTextAttributes.Font = UIFont.FromName("AppleSDGothicNeo-Regular", 16.0F); // unselected
        	normalTextAttributes.TextColor = UIColor.White;
        	TabBar.TintColor = UIColor.White;

        	UITabBarItem.Appearance.SetTitleTextAttributes(normalTextAttributes, UIControlState.Normal);

        	//TabBarItem.SetTitleTextAttributes(normalTextAttributes, UIControlState.Selected);

        }

        public override UIViewController SelectedViewController
        {
        	get
        	{
        		UITextAttributes selectedTextAttributes = new UITextAttributes();
        		selectedTextAttributes.Font = UIFont.FromName("AppleSDGothicNeo-Bold", 18.0F); // SELECTED
        		selectedTextAttributes.TextColor = UIColor.White;

        		if (base.SelectedViewController != null)
        		{
        			TabBar.UnselectedItemTintColor = UIColor.White;
        			base.SelectedViewController.TabBarItem.SetTitleTextAttributes(selectedTextAttributes, UIControlState.Normal);
        		}
        		//UITabBarItem.Appearance.SetTitleTextAttributes(selectedTextAttributes, UIControlState.Normal);
        		return base.SelectedViewController;
        	}
        	set
        	{
        		base.SelectedViewController = value;

        		foreach (UIViewController viewController in base.ViewControllers)
        		{
        			UITextAttributes normalTextAttributes = new UITextAttributes();

        			normalTextAttributes.Font = UIFont.FromName("AppleSDGothicNeo-Regular", 16.0F); // unselected

        			normalTextAttributes.TextColor = UIColor.White;
        			//TabBar.UnselectedItemTintColor = UIColor.White;
        			//TabBar.TintColor = UIColor.White;
        			//TabBar.SelectedImageTintColor = UIColor.White;
        			viewController.TabBarItem.SetTitleTextAttributes(normalTextAttributes, UIControlState.Normal);

        		}

        	}
        }

    }
	
	
}


