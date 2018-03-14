using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Foundation;
using Library.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WebView), typeof(CustomWebViewRendererIOS))]

namespace Library.iOS
{
		class CustomWebViewRendererIOS : WebViewRenderer
		{
			protected override void OnElementChanged(VisualElementChangedEventArgs e)
			{
				base.OnElementChanged(e);
				this.ScalesPageToFit = true;
				this.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

                var cookieUrl = new Uri("https://evergreen.lib.in.us/eg/opac/home");
                var cookieJar = NSHttpCookieStorage.SharedStorage;
                cookieJar.AcceptPolicy = NSHttpCookieAcceptPolicy.Always;
                foreach (var aCookie in cookieJar.Cookies)
                {
                    cookieJar.DeleteCookie(aCookie);
                }

                var jCookies = UserInfo.CookieContainer.GetCookies(cookieUrl);
                IList<NSHttpCookie> eCookies =
                    (from object jCookie in jCookies
                    where jCookie != null
                    select (Cookie)jCookie
                    into netCookie
                    select new NSHttpCookie(netCookie)).ToList();
                cookieJar.SetCookies(eCookies.ToArray(), cookieUrl, cookieUrl);
			}
		}
	}

