﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;


using Foundation;
using UIKit;
using static HoraDeTrabajar.App;

namespace HoraDeTrabajar.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IAuthenticate
	{
		 // Define a authenticated user.
		 private MobileServiceUser user;

		 public async Task<bool> Authenticate()
		 {
			 var success = false;
			 var message = string.Empty;
			 try
			 {
				 // Sign in with Facebook login using a server-managed flow.
				 if (user == null)
				 {
					 user = await TodoItemManager.DefaultManager.CurrentClient.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController,
						MobileServiceAuthenticationProvider.Facebook);
						//MobileServiceAuthenticationProvider.MicrosoftAccount);
						//MobileServiceAuthenticationProvider.Twitter);
						//MobileServiceAuthenticationProvider.Google);
					 if (user != null)
					 {
						 message = string.Format("You are now signed-in as {0}.", user.UserId);
						 success = true;
					 }
				 }
			 }
			 catch (Exception ex)
			 {
				message = ex.Message;
			 }

			 // Display the success or failure message.
			 UIAlertView avAlert = new UIAlertView("Sign-in result", message, null, "OK", null);
			 avAlert.Show();

			 return success;
		 }

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// Initialize Azure Mobile Apps
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			// Initialize Xamarin Forms
			global::Xamarin.Forms.Forms.Init ();

			 App.Init(this);
			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

